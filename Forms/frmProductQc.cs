using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.MDL;
using cf01.Reports;
using System.Text.RegularExpressions;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmProductQc : Form
    {
        DataTable dtMo_item = new DataTable();
        private DataSet ds_prdbase, ds_rate, ds_size;
        private string edit_mode = "3";//新增狀態
        private string usrid = DBUtility._user_id.ToUpper();
        private string find_flag = "0";
        private int mult_lot = -1;

        public frmProductQc()
        {
            InitializeComponent();

            InitControl();
        }

        void InitControl()
        {
            string strSql;

            if (usrid == "QC01" || usrid == "CFIPQC1")
                textDep1.Text = "102";
            else
            {
                if (usrid == "QC02")
                    textDep1.Text = "302";
            }
            Font a = new Font("GB2312", 11);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.ReadOnly = true;


            strSql = "Select * From qc_item_std Where qc_type ='A02' ";//外觀抽樣數
            ds_rate = clsPublicOfPad.ExcuteSqlReturnDataSet(strSql, "qc_facade_rate");
            strSql = "Select * From qc_item_std Where qc_type ='A03' ";//尺寸抽樣數
            ds_size = clsPublicOfPad.ExcuteSqlReturnDataSet(strSql, "qc_size_rate");


            textDep1.Focus();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (clsValidRule.CheckDateIsEmpty(this.mktQCDate1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mktQCDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktQCDate1.Text) == false || clsValidRule.CheckDateFormat(this.mktQCDate2.Text) == false)
                {
                    MessageBox.Show("QC日期不正確!");
                    this.mktQCDate1.Focus();
                    return;
                }
            }
            if (textDep1.Text.Trim() == "")
            {
                MessageBox.Show("請輸入查詢部門!");
                this.textDep1.Focus();
                return;
            }
            FindPoQC();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            SavePoQC();
        }

        private void rdbYesQc_Click(object sender, EventArgs e)
        {
            BTNFIND_Click(sender, e);
            //FindPoQC();
        }

        private void rdbNoQc_Click(object sender, EventArgs e)
        {
            BTNFIND_Click(sender, e);
        }

        private void rdbAll_Click(object sender, EventArgs e)
        {
            BTNFIND_Click(sender, e);
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            find_flag = "0";
            edit_mode = "3";
            if (dgvDetails.RowCount > 0)
            {
                if (e.RowIndex == -1)
                    return;

                FillControls(e.RowIndex);
                mult_lot = -1;//恢復為單批次記錄狀態
            }
        }
        /// <summary>
        /// 根據條件查詢數據
        /// </summary>
        private void FindPoQC()
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;
            strWhere = " WHERE a.dep_no >= " + " '' ";

            if (textDep1.Text.Trim() != "")
                strWhere += " AND a.dep_no =  " + "'" + textDep1.Text.Trim() + "'";
            if (mktQCDate1.Text.Trim() != "/  /")
                strWhere += " AND a.qc_date >=  " + "'" + mktQCDate1.Text + "'";
            if (mktQCDate2.Text.Trim() != "/  /")
                strWhere += " AND a.qc_date <=  " + "'" + mktQCDate2.Text + "'";
            if (textMo_no.Text != "")
            {
                strWhere += " AND a.mo_no like  " + "'%" + textMo_no.Text.Trim() + "%'";
            }

            if (txtPrd_item1.Text != "")
                strWhere += " AND a.mat_item =  " + "'" + txtPrd_item1.Text.Trim() + "'";
            if (cmbMoSource1.SelectedIndex == 1)
                strWhere += " AND a.mo_source =  '出貨'";
            else
            {
                if (cmbMoSource1.SelectedIndex == 2)
                    strWhere += " AND a.mo_source =  '來料'";
            }
            this.BindDataGridView(strWhere);

            if (dgvDetails.RowCount > 0)
            {
                FillControls(0);
            }


        }

        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = @" Select a.id,a.dep_no,a.prd_date,a.qc_date,a.mo_no,a.mat_item,a.seq_no,a.seq_id
                                  ,a.lot_qty,0 AS facade_sample_qty,0 AS facade_std_ac,0 AS facade_std_re,0 AS size_sample_qty
                                  ,0 AS size_std_ac,0 AS size_std_re,a.crusr,CONVERT(varchar(50),a.crtim,20) AS crtim,a.mat_color
                                  ,a.facade_actual_qty,a.size_actual_qty,a.actual_size,a.mat_logo,a.oth_desc
                                  ,a.no_pass_qty,a.do_result,a.qc_no_ok,a.qc_ok,CONVERT(VARCHAR(240),b.name) AS mat_desc,a.do_sample,a.mo_source
                             FROM product_qc_records a
                             LEFT JOIN dgcf_db.dbo.geo_it_goods b ON a.mat_item=b.id COLLATE chinese_taiwan_stroke_CI_AS " + strWhere;
            strSql += " Order By a.qc_date,a.seq_id Desc";
            ds_prdbase = clsPublicOfPad.ExcuteSqlReturnDataSet(strSql, "tb_prd");
            this.dgvDetails.DataSource = ds_prdbase.Tables["tb_prd"];
            int cur_qty, min_rate, max_rate;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                for (int j = 0; j < ds_rate.Tables["qc_facade_rate"].Rows.Count; j++)
                {

                    cur_qty = Convert.ToInt32(dgvDetails.Rows[i].Cells["lot_qty"].Value);
                    min_rate = Convert.ToInt32(ds_rate.Tables["qc_facade_rate"].Rows[j]["qty_min_rate"]);
                    max_rate = Convert.ToInt32(ds_rate.Tables["qc_facade_rate"].Rows[j]["qty_max_rate"]);
                    if (cur_qty - min_rate >= 0 && cur_qty - max_rate < 0)
                    {
                        dgvDetails.Rows[i].Cells["facade_sample_qty"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                        dgvDetails.Rows[i].Cells["facade_std_ac"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["std_ac"].ToString();
                        dgvDetails.Rows[i].Cells["facade_std_re"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["std_re"].ToString();
                        //dgvDetails.Rows[i].Cells["facade_actual_qty"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                    }
                }

                for (int k = 0; k < ds_size.Tables["qc_size_rate"].Rows.Count; k++)
                {

                    cur_qty = Convert.ToInt32(dgvDetails.Rows[i].Cells["lot_qty"].Value);
                    min_rate = Convert.ToInt32(ds_size.Tables["qc_size_rate"].Rows[k]["qty_min_rate"]);
                    max_rate = Convert.ToInt32(ds_size.Tables["qc_size_rate"].Rows[k]["qty_max_rate"]);
                    if (cur_qty - min_rate >= 0 && cur_qty - max_rate < 0)
                    {
                        dgvDetails.Rows[i].Cells["size_sample_qty"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                        //dgvDetails.Rows[i].Cells["size_actual_qty"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                        dgvDetails.Rows[i].Cells["size_std_ac"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["std_ac"].ToString();
                        dgvDetails.Rows[i].Cells["size_std_re"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["std_re"].ToString();
                    }
                }
            }
        }

        // 保存QC完成的數據
        private void SavePoQC()
        {
            product_qc_records objModel = new product_qc_records();
            if (ValidateCheckResult())
            {
                if (txtPrd_id.Text.Trim() == "")//如果是空，則代表是新增狀態
                    txtPrd_id.Text = clsPublicOfPad.GenNo("frmProductQc").ToString();//自動產生序列號
                objModel.id = Convert.ToInt32(txtPrd_id.Text);
                objModel.dep_no = txtDep.Text.Trim();
                objModel.prd_date = txtPrd_date.Text.Trim();
                objModel.qc_date = txtQc_Date.Text.Trim();
                objModel.mo_no = txtPrd_mo.Text.Trim();
                objModel.mat_item = cmbPrd_item.Text.Trim();
                objModel.mat_color = txtMat_color.Text.Trim();
                objModel.lot_qty = (txtLot_qty.Text != "" ? Convert.ToInt32(txtLot_qty.Text) : 0);
                objModel.facade_actual_qty = (txtFacade_actual_qty.Text != "" ? Convert.ToInt32(txtFacade_actual_qty.Text) : 0);
                objModel.size_actual_qty = (txtSize_actual_qty.Text != "" ? Convert.ToInt32(txtSize_actual_qty.Text) : 0);
                objModel.actual_size = txtActual_size.Text.Trim();
                objModel.mat_logo = txtMat_logo.Text.Trim();
                objModel.oth_desc = txtOth_desc.Text.Trim();
                objModel.do_sample = cmbDoSample.Text.Trim();
                objModel.no_pass_qty = (txtNo_pass_qty.Text != "" ? Convert.ToInt32(txtNo_pass_qty.Text) : 0);
                objModel.seq_no = (txtSeq_no.Text == "" ? "001" : txtSeq_no.Text.Trim());
                objModel.mo_source = cmbMoSource.Text;
                objModel.qc_ok = "";
                objModel.qc_no_ok = "";
                objModel.seq_id = txtSeq_id.Text.Trim();
                if (chkQc_ok.Checked == true)
                {
                    objModel.qc_ok = "Y";
                }
                if (chkQc_no_ok.Checked == true)
                {
                    objModel.qc_no_ok = "N";
                }
                objModel.do_result = txtDo_result.Text.ToString();
                objModel.crusr = usrid;
                objModel.crtim = DateTime.Now;
                objModel.amtim = DateTime.Now;
                objModel.amusr = usrid;
                DataTable dtres = new DataTable();
                string strSql1 = "";
                strSql1 = @" SELECT id FROM product_qc_records WHERE id = '" + Convert.ToInt32(txtPrd_id.Text) + "' AND seq_no = '" + objModel.seq_no + "'";
                int Result = 0;
                dtres = clsPublicOfPad.GetDataTable(strSql1);
                if (dtres.Rows.Count <= 0)
                {
                    Result = clsProductQCRecords.AddProductQCRecords(objModel);
                }
                else
                {
                    Result = clsProductQCRecords.UpdateProductQCRecords(objModel);
                }
                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                    mult_lot = -1;//恢復為單批次記錄狀態
                    FindPoQC();
                }
                else
                {
                    MessageBox.Show("保存失敗!");
                }
            }
        }

        /// <summary>
        /// 驗證文本框格式
        /// </summary>
        /// <returns></returns>
        private bool ValidateCheckResult()
        {
            if (txtDep.Text.Trim() == "")
            {
                MessageBox.Show("部門不能為空!");
                txtDep.Focus();
                return false;
            }
            if (txtPrd_mo.Text.Trim() == "")
            {
                MessageBox.Show("制單編號不能為空!");
                txtPrd_mo.Focus();
                return false;
            }
            if (cmbPrd_item.Text.Trim() == "")
            {
                MessageBox.Show("物料編號不能為空!");
                cmbPrd_item.Focus();
                return false;
            }
            if (cmbMoSource.Text.Trim() == "")
            {
                MessageBox.Show("來源不能為空!");
                cmbMoSource.Focus();
                return false;
            }
            if (txtLot_qty.Text.Trim() == "")
            {
                MessageBox.Show("批量不能為空!");
                txtLot_qty.Focus();
                return false;
            }
            if (chkQc_ok.Checked == true && chkQc_no_ok.Checked == true)
            {
                MessageBox.Show("檢驗結果不能同時選中 OK 或 NG ，請重新選擇QC結果。");
                return false;
            }
            if (chkQc_ok.Checked == false && chkQc_no_ok.Checked == false)
            {
                MessageBox.Show("檢驗結果無效!");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 填充文本框
        /// </summary>
        /// <param name="i"></param>
        private void FillControls(int i)
        {
            string strPrd_item = (dgvDetails.Rows[i].Cells["colMat_item"].Value != null ? dgvDetails.Rows[i].Cells["colMat_item"].Value.ToString() : "");
            txtMat_logo.Text = (dgvDetails.Rows[i].Cells["Mat_logo"].Value != null ? dgvDetails.Rows[i].Cells["Mat_logo"].Value.ToString() : "");
            txtActual_size.Text = (dgvDetails.Rows[i].Cells["Actual_size"].Value != null ? dgvDetails.Rows[i].Cells["Actual_size"].Value.ToString() : "");

            txtPrd_id.Text = (dgvDetails.Rows[i].Cells["colId"].Value != null ? dgvDetails.Rows[i].Cells["colId"].Value.ToString() : "");
            txtSeq_id.Text = (dgvDetails.Rows[i].Cells["colSeq_id"].Value != null ? dgvDetails.Rows[i].Cells["colSeq_id"].Value.ToString() : "");
            txtPrd_date.Text = (dgvDetails.Rows[i].Cells["Prd_date"].Value != null ? dgvDetails.Rows[i].Cells["Prd_date"].Value.ToString() : "");
            txtDep.Text = (dgvDetails.Rows[i].Cells["dep_no"].Value != null ? dgvDetails.Rows[i].Cells["dep_no"].Value.ToString() : "");
            txtPrd_mo.Text = (dgvDetails.Rows[i].Cells["colMo_no"].Value != null ? dgvDetails.Rows[i].Cells["colMo_no"].Value.ToString() : "");
            
            txtMat_desc.Text = (dgvDetails.Rows[i].Cells["mat_desc"].Value != null ? dgvDetails.Rows[i].Cells["mat_desc"].Value.ToString() : "");
            txtQc_Date.Text = (dgvDetails.Rows[i].Cells["Qc_date"].Value != null ? dgvDetails.Rows[i].Cells["Qc_date"].Value.ToString() : "");
            txtOth_desc.Text = (dgvDetails.Rows[i].Cells["Oth_desc"].Value != null ? dgvDetails.Rows[i].Cells["Oth_desc"].Value.ToString() : "");
            txtNo_pass_qty.Text = (dgvDetails.Rows[i].Cells["No_pass_qty"].Value != null ? dgvDetails.Rows[i].Cells["No_pass_qty"].Value.ToString() : "");
            txtMat_color.Text = (dgvDetails.Rows[i].Cells["Mat_color"].Value != null ? dgvDetails.Rows[i].Cells["Mat_color"].Value.ToString() : "");
            txtLot_qty.Text = (dgvDetails.Rows[i].Cells["Lot_qty"].Value != null ? dgvDetails.Rows[i].Cells["Lot_qty"].Value.ToString() : "");
            txtDo_result.Text = (dgvDetails.Rows[i].Cells["Do_result"].Value != null ? dgvDetails.Rows[i].Cells["Do_result"].Value.ToString() : "");
            txtFacade_actual_qty.Text = (dgvDetails.Rows[i].Cells["Facade_actual_qty"].Value != null ? dgvDetails.Rows[i].Cells["Facade_actual_qty"].Value.ToString() : "");
            txtSize_actual_qty.Text = (dgvDetails.Rows[i].Cells["Size_actual_qty"].Value != null ? dgvDetails.Rows[i].Cells["Size_actual_qty"].Value.ToString() : "");
            txtSeq_no.Text = (dgvDetails.Rows[i].Cells["seq_no"].Value != null ? dgvDetails.Rows[i].Cells["seq_no"].Value.ToString() : "");
            cmbDoSample.Text = (dgvDetails.Rows[i].Cells["colDoSample"].Value != null ? dgvDetails.Rows[i].Cells["colDoSample"].Value.ToString() : "");
            cmbMoSource.Text = (dgvDetails.Rows[i].Cells["colMoSource"].Value != null ? dgvDetails.Rows[i].Cells["colMoSource"].Value.ToString() : "");
            chkQc_ok.Checked = false;
            chkQc_no_ok.Checked = false;
            if (dgvDetails.Rows[i].Cells["Qc_ok"].Value != null && dgvDetails.Rows[i].Cells["Qc_ok"].Value.ToString() == "Y")
                chkQc_ok.Checked = true;
            if (dgvDetails.Rows[i].Cells["Qc_no_ok"].Value != null && dgvDetails.Rows[i].Cells["Qc_no_ok"].Value.ToString() == "Y")
                chkQc_no_ok.Checked = true;
            GetMo_itme("strPrd_item");
            cmbPrd_item.Text = strPrd_item;
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void chkQc_ok_Click(object sender, EventArgs e)
        {
            chkQc_no_ok.Checked = false;
        }

        private void chkQc_no_ok_Click(object sender, EventArgs e)
        {
            chkQc_ok.Checked = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintRoport_Click(object sender, EventArgs e)
        {
            GetProductQcRecord();

        }

        private void GetProductQcRecord()
        {
            DataTable dtQcRecrod = new DataTable();
            if (dgvDetails.RowCount > 0)
            {
                dtQcRecrod.Rows.Clear();
                dtQcRecrod.Columns.Add("ser_no", typeof(int));
                dtQcRecrod.Columns.Add("prd_mo", typeof(string));
                dtQcRecrod.Columns.Add("NameAddSize", typeof(string));
                dtQcRecrod.Columns.Add("mat_color", typeof(string));
                dtQcRecrod.Columns.Add("lot_qty", typeof(int));
                dtQcRecrod.Columns.Add("facade_actual_qty", typeof(int));
                dtQcRecrod.Columns.Add("facade_std_ac", typeof(int));
                dtQcRecrod.Columns.Add("facade_std_re", typeof(int));
                dtQcRecrod.Columns.Add("size_actual_qty", typeof(int));
                dtQcRecrod.Columns.Add("size_std_ac", typeof(int));
                dtQcRecrod.Columns.Add("size_std_re", typeof(int));
                dtQcRecrod.Columns.Add("actual_size", typeof(string));
                dtQcRecrod.Columns.Add("mat_logo", typeof(string));
                dtQcRecrod.Columns.Add("oth_desc", typeof(string));
                dtQcRecrod.Columns.Add("no_pass_qty", typeof(int));
                dtQcRecrod.Columns.Add("qc_ok", typeof(bool));
                dtQcRecrod.Columns.Add("qc_no_ok", typeof(bool));
                dtQcRecrod.Columns.Add("do_result", typeof(string));
                DataRow dr = null;

                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    dr = dtQcRecrod.NewRow();
                    dr["ser_no"] = i + 1;
                    dr["prd_mo"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["colMo_no"].Value);
                    dr["facade_std_ac"] = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["facade_std_ac"].Value);
                    dr["facade_std_re"] = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["facade_std_re"].Value);
                    dr["facade_actual_qty"] = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["facade_actual_qty"].Value);
                    dr["size_actual_qty"] = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["size_actual_qty"].Value);
                    dr["size_std_ac"] = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["size_std_ac"].Value);
                    dr["size_std_re"] = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["size_std_re"].Value);
                    dr["mat_color"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["mat_color"].Value);
                    dr["lot_qty"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["lot_qty"].Value);
                    dr["actual_size"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["actual_size"].Value);
                    dr["mat_logo"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["mat_logo"].Value);
                    dr["oth_desc"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["oth_desc"].Value);
                    dr["no_pass_qty"] = (dgvDetails.Rows[i].Cells["no_pass_qty"].Value.ToString() != "" ? clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["no_pass_qty"].Value) : 0);
                    dr["do_result"] = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["do_result"].Value);
                    dr["NameAddSize"] = Regex.Replace(clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["mat_desc"].Value), @"\s", "");
                    string strQC_NO_OK = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["qc_no_ok"].Value).Trim();
                    string strQC_OK = clsUtility.FormatNullableString(dgvDetails.Rows[i].Cells["qc_ok"].Value).Trim();
                    if (strQC_NO_OK != "")
                    {
                        dr["qc_no_ok"] = true;
                    }
                    else
                    {
                        dr["qc_no_ok"] = false;
                    }

                    if (strQC_OK != "")
                    {
                        dr["qc_ok"] = true;
                    }
                    else
                    {
                        dr["qc_ok"] = false;
                    }

                    dtQcRecrod.Rows.Add(dr);
                }
            }
            if (dtQcRecrod.Rows.Count > 0)
            {
                xtaProductQc xQc = new xtaProductQc(dtQcRecrod);
                xQc.ShowPreviewDialog();
            }
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    string strbarcode = txtBarCode.Text.Trim().ToUpper();
                    string goods_id = "";
                    if (strbarcode.Length == 30 || strbarcode.Length == 13)
                    {
                        if (strbarcode.Length == 30)
                        {
                            txtDep.Text = strbarcode.Substring(0, 3);
                            txtPrd_mo.Text = strbarcode.Substring(3, 9);
                            goods_id = strbarcode.Substring(12, 18);
                        }
                        else//如果是12位的條形碼，就要通過計劃查找出物料編號、部門等記錄
                        {
                            DataTable dtItem = clsPublicOfPad.BarCodeToItem(strbarcode);
                            if (dtItem.Rows.Count > 0)
                            {
                                txtDep.Text = dtItem.Rows[0]["wp_id"].ToString().Trim();
                                txtPrd_mo.Text = strbarcode.Substring(0, 9);
                                goods_id = dtItem.Rows[0]["goods_id"].ToString().Trim();
                            }
                        }
                        textDep1.Text = txtDep.Text;
                    }
                    initValue();
                    GetMo_itme(goods_id);
                    txtBarCode.Text = "";
                    break;
            }


            

        }

        private void mktQCDate1_TextChanged(object sender, EventArgs e)
        {
            mktQCDate2.Text = mktQCDate1.Text;
        }

        private void textMo_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrd_mo_Leave(object sender, EventArgs e)
        {
            initValue();
            if (txtPrd_mo.Text != "" && txtDep.Text != "")
            {
                GetMo_itme("");
            }
            
        }
        //初始化值
        private void initValue()
        {
            if (cmbMoSource.Text.Trim() == "")
            {
                MessageBox.Show("來源不能為空!");
                cmbMoSource.Focus();
                return;
            }
            find_flag = "1";
            ClearForm();
            txtQc_Date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtPrd_date.Text = txtQc_Date.Text;
            txtSeq_id.Text = clsProductQCRecords.GetMaxSeq(txtDep.Text.Trim(), txtQc_Date.Text.Trim(), cmbMoSource.Text.Trim());//獲取部門當日日期最大序號
        }
        //獲取制單編號資料，并綁定物料編號
        private void GetMo_itme(string item)
        {
            cmbPrd_item.Items.Clear();
            try
            {
                dtMo_item = clsProductQCRecords.GetMoData(txtPrd_mo.Text.Trim(), txtDep.Text.Trim(), item,cmbMoSource.SelectedIndex);
                if (dtMo_item.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMo_item.Rows.Count; i++)
                    {
                        cmbPrd_item.Items.Add(dtMo_item.Rows[i]["goods_id"].ToString().Trim());
                    }
                    cmbPrd_item.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPrd_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void ClearForm()
        {
            txtPrd_id.Text = "";
            cmbPrd_item.Text = "";
            txtMat_desc.Text = "";
            txtActual_size.Text = "";
            txtMat_logo.Text = "";
            txtOth_desc.Text = "";
            txtDo_result.Text = "";
            txtNo_pass_qty.Text = "";
            txtMat_color.Text = "";
            txtFacade_actual_qty.Text = "";
            txtSize_actual_qty.Text = "";
            txtLot_qty.Text = "";
            txtSeq_id.Text = "";
            chkQc_ok.Checked = false;
            chkQc_no_ok.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            edit_mode = "1";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit_mode = "2";
        }

        private void frmProductQc_Load(object sender, EventArgs e)
        {
            mktQCDate1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            cmbDoSample.Items.Add("");
            cmbDoSample.Items.Add("原瓣");
            cmbDoSample.Items.Add("布瓣");
            cmbDoSample.Items.Add("批瓣");
            cmbDoSample.Items.Add("不對瓣");

            cmbMoSource.Items.Add("出貨");
            cmbMoSource.Items.Add("來料");

            cmbMoSource1.Items.Add("");
            cmbMoSource1.Items.Add("出貨");
            cmbMoSource1.Items.Add("來料");
        }
        

        //獲取測試標準值
        private void GetTestQty()
        {
            int cur_qty;
            cur_qty = Convert.ToInt32(txtLot_qty.Text);
            int min_rate, max_rate;
            int i = 0;
            for (int j = 0; j < ds_rate.Tables["qc_facade_rate"].Rows.Count; j++)
            {
                min_rate = Convert.ToInt32(ds_rate.Tables["qc_facade_rate"].Rows[j]["qty_min_rate"]);
                max_rate = Convert.ToInt32(ds_rate.Tables["qc_facade_rate"].Rows[j]["qty_max_rate"]);
                if (cur_qty - min_rate >= 0 && cur_qty - max_rate < 0)
                {
                    txtFacade_actual_qty.Text = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                    //dgvDetails.Rows[i].Cells["facade_sample_qty"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                    //dgvDetails.Rows[i].Cells["facade_std_ac"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["std_ac"].ToString();
                    //dgvDetails.Rows[i].Cells["facade_std_re"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["std_re"].ToString();
                    //dgvDetails.Rows[i].Cells["facade_actual_qty"].Value = ds_rate.Tables["qc_facade_rate"].Rows[j]["sample_qty"].ToString();
                }
            }

            for (int k = 0; k < ds_size.Tables["qc_size_rate"].Rows.Count; k++)
            {
                min_rate = Convert.ToInt32(ds_size.Tables["qc_size_rate"].Rows[k]["qty_min_rate"]);
                max_rate = Convert.ToInt32(ds_size.Tables["qc_size_rate"].Rows[k]["qty_max_rate"]);
                if (cur_qty - min_rate >= 0 && cur_qty - max_rate < 0)
                {
                    txtSize_actual_qty.Text = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                    //dgvDetails.Rows[i].Cells["size_sample_qty"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                    ////dgvDetails.Rows[i].Cells["size_actual_qty"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["sample_qty"].ToString();
                    //dgvDetails.Rows[i].Cells["size_std_ac"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["std_ac"].ToString();
                    //dgvDetails.Rows[i].Cells["size_std_re"].Value = ds_size.Tables["qc_size_rate"].Rows[k]["std_re"].ToString();
                }
            }
        }

        private void txtQc_Date_Leave(object sender, EventArgs e)
        {
            txtSeq_id.Text = clsProductQCRecords.GetMaxSeq(txtDep.Text.Trim(), txtQc_Date.Text.Trim(),cmbMoSource.Text.Trim());//獲取當日日期最大序號
        }

        private void dgvDetails_Leave(object sender, EventArgs e)
        {
            find_flag = "1";
        }

        private void txtLot_qty_TextChanged(object sender, EventArgs e)
        {
            if (find_flag == "1")
            {
                if (txtLot_qty.Text.Trim() != "")
                    GetTestQty();
            }
        }

        private void cmbPrd_item_TextChanged(object sender, EventArgs e)
        {
            if (cmbPrd_item.Text.Trim() == "" || cmbPrd_item.Text.Trim().Length < 18)
                return;
            string prd_item;
            prd_item = cmbPrd_item.Text.Trim();
            DataTable dtColor = new DataTable();
            DataTable dtArt = new DataTable();
            dtColor = clsProductQCRecords.GetMat_Color(prd_item.Substring(14, 4));
            dtArt = clsProductQCRecords.GetMat_Logo(prd_item.Substring(4, 7));
            if (find_flag == "1")
            {

                if (dtMo_item.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMo_item.Rows.Count; i++)
                    {
                        if (cmbPrd_item.Text.Trim() == dtMo_item.Rows[i]["goods_id"].ToString().Trim()
                            && dtMo_item.Rows[i]["prod_qty"] != null)
                            txtLot_qty.Text = Convert.ToInt32(dtMo_item.Rows[i]["prod_qty"]).ToString();
                    }
                }
                txtActual_size.Text = clsProductQCRecords.GetSize(prd_item.Substring(11, 3));
                if (dtArt.Rows.Count > 0)
                    txtMat_logo.Text = dtArt.Rows[0]["name"].ToString();

                if (dtColor.Rows.Count > 0)
                    txtMat_color.Text = dtColor.Rows[0]["name"].ToString();
            }
            txtMat_desc.Text = clsProductQCRecords.GetMatDesc(prd_item);
            if (dtColor.Rows.Count > 0)
                txtDoColor.Text = dtColor.Rows[0]["do_color"].ToString();
            //獲取產品圖像
            picArt.Image = null;
            if (dtArt.Rows.Count > 0)
            {
                string picFile = "";
                picFile = dtArt.Rows[0]["picture_name"].ToString().Trim();
                if (File.Exists(DBUtility.imagePath + picFile))
                    picArt.Image = Image.FromFile(DBUtility.imagePath + picFile);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtPrd_id.Text.Trim() == "")
                return;
            if (MessageBox.Show("確定要刪除嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int prd_id = Convert.ToInt32(txtPrd_id.Text);
                int re = clsProductQCRecords.DeleteProductQCRecords(prd_id,txtSeq_no.Text.Trim());
                if (re > 0)
                {
                    MessageBox.Show("刪除成功!");

                    BTNFIND_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("刪除失敗!");
                }
            }
        }

        private void textDep1_TextChanged(object sender, EventArgs e)
        {
            txtDep.Text = textDep1.Text;
        }

        private void txtDep_TextChanged(object sender, EventArgs e)
        {
            textDep1.Text = txtDep.Text;
        }

        private void cmbMoSource_Leave(object sender, EventArgs e)
        {
            txtPrd_mo_Leave(sender,e);
        }
    }
}
