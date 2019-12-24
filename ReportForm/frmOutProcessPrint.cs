using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.Reports;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.IO;
using cf01.CLS;
using cf01.ModuleClass;
using cf01.Forms;
using System.Threading;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmOutProcessPrint : Form
    {
       private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
       private DataTable dtPlate = new DataTable();
       private DataTable dtMo_Data = new DataTable();
       public frmOutProcessPrint()
        {
            InitializeComponent();
        }

        private void frmOut_Process_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            const string strSQL = @"SELECT id,id+' ['+ name +']' AS cdesc FROM it_vendor 
                WHERE within_code ='0000' AND state ='1' AND type='OP'
                ORDER BY id";
            DataTable dtVendor = clsConErp.GetDataTable(strSQL);
            DataRow dr0 = dtVendor.NewRow(); //插一空行        
            dtVendor.Rows.InsertAt(dr0, 0);
            txtVendor_id1.Properties.DataSource = dtVendor;
            txtVendor_id1.Properties.ValueMember = "id";
            txtVendor_id1.Properties.DisplayMember = "cdesc";

            txtVendor_id2.Properties.DataSource = dtVendor;
            txtVendor_id2.Properties.ValueMember = "id";
            txtVendor_id2.Properties.DisplayMember = "cdesc";

            txtDat1.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            txtDat2.Text = txtDat1.Text;
        }
     
        //private void BTNFIND_Click(object sender, EventArgs e)
        //{
        //    txtVendor_id2.Focus();
        //    if (txtDat1.Text == "" && txtDat2.Text == "" && txtID1.Text == "" && txtID2.Text == "" && txtVendor_id1.Text == "" && txtVendor_id2.Text == "")
        //    {
        //        MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    LoadData();
        //}

        private void loadData()
        {
            string within_code = DBUtility.within_code;
            string strSql = "";
            strSql += " Select a.id,Convert(VARCHAR(20),a.issue_date,111) AS issue_date,a.vendor_id,a.vendor" +
                ",a.department_id,d.name AS DepCdesc,b.sequence_id,b.mo_id,b.goods_id,c.name AS goods_cname,b.do_color" +
                ",b.prod_qty,b.goods_unit" +
                ",b.sec_qty,b.sec_unit,b.package_num,Convert(VARCHAR(20),b.t_complete_date,111) AS RequestReturnDate" +
                " FROM op_outpro_out_mostly a" +
                " INNER JOIN op_outpro_out_displace b ON a.within_code=b.within_code AND a.id=b.id" +
                " INNER JOIN it_goods c ON b.within_code=c.within_code AND b.goods_id=c.id" +
                " INNER JOIN cd_department d ON a.within_code=d.within_code AND a.department_id=d.id" +
                " WHERE a.within_code='" + within_code + "' AND a.state<>'2'";
            if (txtDat1.Text != "" && txtDat2.Text != "")
            {
                string dateTo = Convert.ToDateTime(txtDat2.Text).AddDays(1).ToString("yyyy/MM/dd");
                strSql += " AND a.issue_date>='" + txtDat1.Text.Trim() + "' AND a.issue_date<'" + dateTo + "'";
            }
            if (txtVendor_id1.EditValue != "" && txtVendor_id2.EditValue != "")
                strSql += " AND a.vendor_id>='" + txtVendor_id1.EditValue + "' AND a.vendor_id<='" + txtVendor_id2.EditValue + "'";
            if (txtDepFrom.Text != "" && txtDepTo.Text != "")
                strSql += " AND a.department_id>='" + txtDepFrom.Text + "' AND a.department_id<='" + txtDepTo.Text + "'";
            if (txtMoFrom.Text != "" && txtMoTo.Text != "")
                strSql += " AND b.mo_id>='" + txtMoFrom.Text + "' AND b.mo_id<='" + txtMoTo.Text + "'";
            if (txtID1.Text != "" && txtID2.Text != "")
                strSql += " AND a.id>='" + txtID1.Text + "' AND a.id<='" + txtID2.Text + "'";
            strSql += " ORDER BY a.department_id,a.vendor_id,a.issue_date,a.id";



            //dtPlate = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_OutProcessPrint", paras);
            clsPublicOfGEO clsGeo = new clsPublicOfGEO();
            dtPlate = clsGeo.GetDataTable(strSql);
            dtPlate.Columns.Add("SelectFlag", typeof(bool));
            //.ExecuteProcedureReturnTable("usp_OutProcessPrint", paras);
            dgvDetails.DataSource = dtPlate;
            if (dtPlate.Rows.Count > 0)
            {
                for (int i = 0; i < dtPlate.Rows.Count; i++)
                    dtPlate.Rows[i]["SelectFlag"] = false;
            }
            else
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private static bool CheckDate(object obj)
        {
            string strdate = ((DateEdit)obj).Text;
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {              
                MessageBox.Show("輸入的日期有誤!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
            return Flag;
        }

        private void txtDat2_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat2.Text;
            if (!string.IsNullOrEmpty(strDate))
            {
                CheckDate(sender); 
            }
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {
            txtID2.Text = txtID1.Text;
        }
        private void frmOut_Process_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConErp = null;
            dtPlate = null;
            dtMo_Data = null;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            chkSelectAll.Checked = false;
            findData();
        }
        private void findData()
        {
            txtVendor_id2.Focus();
            if (txtDat1.Text == "" && txtDat2.Text == "" && txtID1.Text == "" && txtID2.Text == "" && txtVendor_id1.Text == "" && txtVendor_id2.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            loadData(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMoFrom_Leave(object sender, EventArgs e)
        {
            txtMoTo.Text = txtMoFrom.Text;
        }

        private void txtDepFrom_Leave(object sender, EventArgs e)
        {
            txtDepTo.Text = txtDepFrom.Text;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat1.Text;
            if (string.IsNullOrEmpty(strDate))
            {
                return;
            }

            if (CheckDate(sender))
            {
                txtDat2.EditValue = txtDat1.EditValue;               
            }
        }

        private void txtVendor_id1_Leave(object sender, EventArgs e)
        {
            txtVendor_id2.EditValue = txtVendor_id1.EditValue;
        }

        private void txtVendor_id1_Click(object sender, EventArgs e)
        {
            txtVendor_id1.SelectAll();
        }

        private void txtVendor_id2_Click(object sender, EventArgs e)
        {
            txtVendor_id2.SelectAll();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtDepFrom.Focus();
                bool selectFlag = false;
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    if ((bool)dgvDetails.Rows[i].Cells["colSelectFlag"].EditedFormattedValue)
                    {
                        selectFlag = true;
                        break;
                    }
                }
                if (selectFlag == false)
                {
                    MessageBox.Show("沒有選擇列印的記錄!");
                    return;
                }
                //**********************
                show_workcard(); //数据处理
                //**********************

            }
        }


        /// <summary>
        ///獲取數據，并顯示工序卡 
        /// </summary>
        private void show_workcard()
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            String dep, mo, item, Request_date, Remark;

            DataTable dtNewWork = new DataTable();
            dtNewWork.Columns.Add("wp_id", typeof(string));
            dtNewWork.Columns.Add("mo_id", typeof(string));
            dtNewWork.Columns.Add("goods_id", typeof(string));
            dtNewWork.Columns.Add("goods_name", typeof(string));
            dtNewWork.Columns.Add("prod_qty", typeof(string));
            dtNewWork.Columns.Add("goods_unit", typeof(string));
            dtNewWork.Columns.Add("within_code", typeof(string));
            dtNewWork.Columns.Add("id", typeof(string));
            dtNewWork.Columns.Add("ver", typeof(string));
            dtNewWork.Columns.Add("sequence_id", typeof(string));
            dtNewWork.Columns.Add("blueprint_id", typeof(string));
            dtNewWork.Columns.Add("production_remark", typeof(string));
            dtNewWork.Columns.Add("remark", typeof(string));
            dtNewWork.Columns.Add("next_wp_id", typeof(string));
            dtNewWork.Columns.Add("predept_rechange_qty", typeof(decimal));
            dtNewWork.Columns.Add("order_qty", typeof(string));
            dtNewWork.Columns.Add("order_unit", typeof(string));
            dtNewWork.Columns.Add("color", typeof(string));
            dtNewWork.Columns.Add("base_qty", typeof(int));
            dtNewWork.Columns.Add("unit_code", typeof(string));
            dtNewWork.Columns.Add("base_rate", typeof(int));
            dtNewWork.Columns.Add("basic_unit", typeof(string));
            dtNewWork.Columns.Add("art_id", typeof(string));
            dtNewWork.Columns.Add("picture_name", typeof(string));
            dtNewWork.Columns.Add("color_name", typeof(string));
            dtNewWork.Columns.Add("do_color", typeof(string));
            dtNewWork.Columns.Add("order_qty_pcs", typeof(string));
            dtNewWork.Columns.Add("next_dep_name", typeof(string));
            dtNewWork.Columns.Add("customer_id", typeof(string));
            dtNewWork.Columns.Add("brand_id", typeof(string));
            dtNewWork.Columns.Add("get_color_sample", typeof(string));
            dtNewWork.Columns.Add("do_color1", typeof(string));
            dtNewWork.Columns.Add("page_num", typeof(int));
            dtNewWork.Columns.Add("per_qty", typeof(string));
            dtNewWork.Columns.Add("t_complete_date", typeof(string));
            dtNewWork.Columns.Add("total_page", typeof(int));
            dtNewWork.Columns.Add("get_color_sample_name", typeof(string));
            dtNewWork.Columns.Add("vendor_id", typeof(string));
            dtNewWork.Columns.Add("c_sec_qty_ok", typeof(int));
            dtNewWork.Columns.Add("depRemark", typeof(string));
            dtNewWork.Columns.Add("request_date", typeof(string));
            dtNewWork.Columns.Add("position_id", typeof(string));
            dtNewWork.Columns.Add("report_name", typeof(string));
            dtNewWork.Columns.Add("crtime", typeof(string));
            dtNewWork.Columns.Add("mould_no", typeof(string));
            dtNewWork.Columns.Add("BarCode", typeof(string));
            dtNewWork.Columns.Add("goods_position", typeof(string));
            dtNewWork.Columns.Add("pe_qty", typeof(string));
            dtNewWork.Columns.Add("step", typeof(string));
            dtNewWork.Columns.Add("do_color_next_dep", typeof(string));
            dtNewWork.Columns.Add("plate_remark", typeof(string));

            dtNewWork.Columns.Add("net_weight", typeof(string));
            dtNewWork.Columns.Add("wh_location", typeof(string));

            dtNewWork.Columns.Add("next_goods_id", typeof(string));
            dtNewWork.Columns.Add("next_do_color", typeof(string));
            dtNewWork.Columns.Add("next_next_wp_id", typeof(string));
            dtNewWork.Columns.Add("next_vendor_id", typeof(string));
            dtNewWork.Columns.Add("next_goods_name", typeof(string));
            dtNewWork.Columns.Add("next_next_dep_name", typeof(string));
            dtNewWork.Columns.Add("prod_date", typeof(string));

            DataRow dr = null;
            string order_unit;
            int order_qty, order_qty_pcs;
            string plate_remark = "";
            for (int j = 0; j < dgvDetails.RowCount; j++)
            {
                if ((bool)dgvDetails.Rows[j].Cells["colSelectFlag"].EditedFormattedValue)
                {
                    DataGridViewRow dgr = dgvDetails.Rows[j];
                    Remark = "";
                    Request_date = dgr.Cells["colRequestReturnDate"].Value.ToString().Trim();
                    dep = dgr.Cells["colDepId"].Value.ToString().Trim();
                    mo = dgr.Cells["colMoId"].Value.ToString().Trim();
                    item = dgr.Cells["colGoodsId"].Value.ToString().Trim();
                    if (dep != "" && mo != "" && item != "")
                    {
                        DataTable dt_wk = clsMo_for_jx.GetGoods_DetailsById(dep, mo, item);
                        DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(item);
                        DataTable dtPosition = clsMo_for_jx.GetPosition(item);
                        DataTable dtQty = clsMo_for_jx.GetOrderQty(mo);//獲取訂單數量
                        DataTable dtPs = clsMo_for_jx.GetPeQtyAndStep(item);
                        //DataTable dtColor = clsMo_for_jx.GetColorInfo(dep, mo, item);
                        //DataTable dtPlate_Remark = clsMo_for_jx.Get_Plate_Remark(mo);
                        DataTable dtNextDep = clsMo_for_jx.getNextDepItem(mo, dep, item);
                        //當前貨品的下部門顏色做法
                        string do_color_next_dep = dgr.Cells["colDoColor"].Value.ToString().Trim(); //clsMo_for_jx.Get_do_color_next_dep(mo, item, dep);

                        order_unit = "";
                        order_qty = 0;
                        order_qty_pcs = 0;
                        if (dtQty.Rows.Count > 0)
                        {
                            order_unit = dtQty.Rows[0]["goods_unit"].ToString();
                            order_qty = Convert.ToInt32(dtQty.Rows[0]["order_qty"]);
                            order_qty_pcs = Convert.ToInt32(dtQty.Rows[0]["order_qty_pcs"]);
                            plate_remark = dtQty.Rows[0]["plate_remark"].ToString();
                        }
                        if (dt_wk.Rows.Count > 0)
                        {
                            DataRow drDtWk = dt_wk.Rows[0];
                            int Per_qty = Convert.ToInt32(dgr.Cells["colProdQty"].Value);  //每次生產數量
                            int Total_qty = Convert.ToInt32(dgr.Cells["colProdQty"].Value);    //生產總量
                            int NumPage = 0;     //報表頁數
                            if (Total_qty > 0 && Per_qty > 0)
                            {
                                if (Total_qty % Per_qty > 0)
                                {
                                    NumPage = (Total_qty / Per_qty) + 1;
                                }
                                else
                                {
                                    NumPage = (Total_qty / Per_qty);
                                }
                            }
                            else
                            {
                                NumPage = 1;
                            }

                            for (int i = 1; i <= NumPage; i++)
                            {
                                dr = dtNewWork.NewRow();

                                dr["wp_id"] = drDtWk["wp_id"].ToString();
                                dr["mo_id"] = drDtWk["mo_id"].ToString();
                                dr["goods_id"] = drDtWk["goods_id"].ToString();
                                dr["goods_name"] = drDtWk["name"].ToString();
                                dr["prod_qty"] = clsUtility.NumberConvert(drDtWk["prod_qty"]);
                                dr["goods_unit"] = drDtWk["goods_unit"].ToString();
                                dr["within_code"] = drDtWk["within_code"].ToString();
                                dr["id"] = drDtWk["id"].ToString();
                                dr["ver"] = clsUtility.FormatNullableInt32(drDtWk["ver"]);
                                dr["sequence_id"] = drDtWk["sequence_id"].ToString();
                                dr["blueprint_id"] = drDtWk["blueprint_id"].ToString();
                                dr["production_remark"] = drDtWk["production_remark"].ToString();
                                dr["remark"] = drDtWk["remark"].ToString();
                                dr["next_wp_id"] = drDtWk["next_wp_id"].ToString();
                                dr["predept_rechange_qty"] = clsUtility.FormatNullableDecimal(drDtWk["predept_rechange_qty"]);
                                dr["order_qty"] = clsUtility.NumberConvert(order_qty);
                                dr["order_unit"] = order_unit;
                                dr["color"] = drDtWk["color"].ToString();
                                dr["base_qty"] = clsUtility.FormatNullableInt32(drDtWk["base_qty"]);
                                dr["unit_code"] = drDtWk["unit_code"].ToString();
                                dr["base_rate"] = clsUtility.FormatNullableInt32(drDtWk["base_rate"]);
                                dr["basic_unit"] = drDtWk["basic_unit"].ToString();
                                dr["order_qty_pcs"] = clsUtility.NumberConvert(order_qty_pcs);
                                dr["plate_remark"] = plate_remark;
                                //string next_dep_id = "aaa";// dgr.Cells["next_wp_id"].Value.ToString().Trim();
                                //DataRow[] drDept = dt_wk.Select("next_wp_id='" + next_dep_id + "'");
                                dr["customer_id"] = drDtWk["customer_id"].ToString();
                                dr["brand_id"] = drDtWk["brand_id"].ToString();
                                dr["get_color_sample"] = drDtWk["get_color_sample"].ToString();
                                dr["do_color1"] = drDtWk["get_color_sample"];
                                dr["page_num"] = i;
                                dr["total_page"] = NumPage;
                                dr["c_sec_qty_ok"] = clsUtility.FormatNullableInt32(drDtWk["c_sec_qty_ok"]);
                                dr["get_color_sample_name"] = drDtWk["get_color_sample_name"];
                                dr["vendor_id"] = drDtWk["vendor_id"];
                                dr["depRemark"] = Remark;
                                dr["request_date"] = Request_date;
                                dr["color_name"] = drDtWk["color_name"].ToString();
                                dr["do_color"] = drDtWk["do_color"].ToString();
                                //if (dtPlate_Remark.Rows.Count > 0)
                                //{
                                //    dr["plate_remark"] = dtPlate_Remark.Rows[0]["plate_remark"];
                                //}

                                if (dtArt.Rows.Count > 0)
                                {
                                dr["art_id"] = dtArt.Rows[0]["art_id"].ToString();
                                dr["picture_name"] = dtArt.Rows[0]["picture_name"].ToString();
                                }

                                //if (dtColor.Rows.Count > 0)
                                //{
                                //    dr["color_name"] = dtColor.Rows[0]["color_name"].ToString();
                                //    dr["do_color"] = dtColor.Rows[0]["do_color"].ToString();
                                //}

                                if (dtPosition.Rows.Count > 0)
                                {
                                    dr["position_id"] = clsUtility.FormatNullableString(dtPosition.Rows[0]["id"]);
                                    dr["mould_no"] = clsUtility.FormatNullableString(dtPosition.Rows[0]["mould_no"]);
                                }

                                if (dep == "302" || dep == "322")
                                    dr["report_name"] = "生產單" + "(" + dep + ")";
                                else
                                    dr["report_name"] = "工序卡" + "(" + dep + ")";

                                if (drDtWk["t_complete_date"].ToString() != "" && drDtWk["t_complete_date"].ToString() != null)
                                {
                                    dr["t_complete_date"] = Convert.ToDateTime(drDtWk["t_complete_date"]).ToString("yyyy/MM/dd");
                                }

                                if (i == NumPage && Per_qty != 0)
                                {
                                    if (Total_qty % Per_qty > 0)
                                    {
                                        dr["per_qty"] = clsUtility.NumberConvert(Total_qty % Per_qty);
                                    }
                                    else
                                    {
                                        dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                                    }
                                }
                                else
                                {
                                    dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                                }

                                if (dtPs.Rows.Count > 0)
                                {
                                    dr["pe_qty"] = dtPs.Rows[0]["pe_qty"].ToString();
                                    dr["step"] = dtPs.Rows[0]["step"].ToString();
                                }
                                //條碼Barcode
                                dr["BarCode"] = clsMo_for_jx.ReturnBarCode(drDtWk["mo_id"] + "0" + drDtWk["ver"] + drDtWk["sequence_id"].ToString().Substring(2, 2));
                                //貨倉位置
                                dr["goods_position"] = clsMo_for_jx.ReturnGoodsPosition(drDtWk["goods_id"].ToString(), drDtWk["next_wp_id"].ToString());
                                dr["do_color_next_dep"] = do_color_next_dep;
                                if (dtNextDep.Rows.Count > 0)
                                {
                                    DataRow drNextDep = dtNextDep.Rows[0];
                                    dr["next_wp_id"] = drNextDep["next_wp_id"];
                                    dr["next_dep_name"] = drNextDep["next_dep_name"];
                                    dr["next_goods_id"] = drNextDep["next_goods_id"];
                                    dr["next_do_color"] = drNextDep["next_do_color"];
                                    dr["next_vendor_id"] = drNextDep["next_vendor_id"];
                                    dr["next_goods_name"] = drNextDep["next_goods_name"];
                                }
                                dr["next_next_wp_id"] = "";// dgr.Cells["next_next_wp_id"].Value.ToString();
                                dr["next_next_dep_name"] = "";// dgr.Cells["next_next_dep_name"].Value.ToString();
                                dr["prod_date"] = "";
                                dtNewWork.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            //if (dtNewWork.Rows.Count > 0)
            //{
            //    xtaWorkjx xr = new xtaWorkjx();
            //    xr.DataSource = dtNewWork;
            //    xr.ShowPreviewDialog();
            //}

            if (dtNewWork.Rows.Count > 0)
            {
                //xtaWork_jx xr = new xtaWork_jx();舊報表注釋于2016-03-04
                //xr.DataSource = dtNewWork;
                //xr.ShowPreviewDialog();

                //xtaWorkjx xr = new xtaWorkjx() { DataSource = dtNewWork };
                xtaWork_No_BarCode xr = new xtaWork_No_BarCode() { DataSource = dtNewWork };
                xr.CreateDocument();
                xr.PrintingSystem.ShowMarginsWarning = false;
                xr.ShowPreview();
            }

        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            bool selectFlag = false;
            if (chkSelectAll.Checked == true)
                selectFlag = true;
            for (int i = 0; i <= this.dgvDetails.RowCount - 1; i++)
            {
                this.dgvDetails.Rows[i].Cells["colSelectFlag"].Value = selectFlag;
                //if ((bool)dgvDetails.Rows[i].Cells["colSelectFlag"].EditedFormattedValue)
                //{
                //    this.dgvDetails.Rows[i].Cells["colSelectFlag"].Value = false;
                //}
                //else
                //{
                //    this.dgvDetails.Rows[i].Cells["colSelectFlag"].Value = true;
                //}
            }
        }
    }
}
