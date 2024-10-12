using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using cf01.Reports;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmPuReturnConf : Form
    {
        private string _userid = DBUtility._user_id.ToUpper();
        public frmPuReturnConf()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitBindCombox()
        {
            string strSql = "select flag_id,flag_desc from bs_flag_desc Where doc_type='RC' AND pu_conf_state='Y' order by flag_id ";
            DataTable tbState = clsPublicOfCF01.GetDataTable(strSql);
            cmbCpl_state.DataSource = tbState;
            cmbCpl_state.DisplayMember = "flag_desc";
            cmbCpl_state.ValueMember = "flag_id";
            cmbCpl_state.SelectedIndex = 1;

            strSql = "select transport_id,transport_cdesc from bs_transport_type ";
            DataTable tbTransport = clsPublicOfCF01.GetDataTable(strSql);
            cmbTransport_type.DataSource = tbTransport;
            cmbTransport_type.DisplayMember = "transport_cdesc";
            cmbTransport_type.ValueMember = "transport_id";

            strSql = "select vend_id from bs_vendor_info order by vend_id ";
            DataTable tbVend_id = clsPublicOfCF01.GetDataTable(strSql);
            cmbVend_id.DataSource = tbVend_id;
            cmbVend_id.DisplayMember = "vend_id";
            cmbVend_id.ValueMember = "vend_id";
        }

        private void frmPuReturnConf_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            mkDoc_date1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            mkDoc_date2.Text = mkDoc_date1.Text;
            InitBindCombox();
        }

        private void FindData()
        {
            string strSql = "";
            string date1 = mkDoc_date1.Text.Trim();
            string date2 = mkDoc_date2.Text.Trim();
            //只顯示CF已發貨的記錄：rec_state='01'
            strSql = "Select a.doc_id,a.doc_date,b.seq,b.prd_mo,b.prd_item,c.name AS item_cdesc,b.in_qty,b.act_in_qty AS per_prod_qty,b.in_weg"+
                ",b.act_in_qty,b.act_in_weg,b.rec_state,b.in_pack,b.act_in_pack" +
                ",d.flag_desc,e.flag_desc AS cpl_flag_desc,b.rec_type,b.rec_type_reason,b.ref_doc_id,b.ref_seq,b.remark,a.vend_id,f.transport_cdesc" +
                " From pu_return_head a" +
                " Inner Join pu_return_details b ON a.comp_type=b.comp_type And a.doc_id=b.doc_id" +
                " left join geo_it_goods c on b.prd_item=c.id COLLATE  Chinese_Taiwan_Stroke_CI_AS" +
                " Left Join bs_flag_desc d ON b.rec_state=d.flag_id" +
                " Left Join bs_flag_desc e ON b.cpl_state=e.flag_id" +
                " Left Join bs_transport_type f ON a.transport_type=f.transport_id" +
                " Where a.comp_type='DG'AND d.doc_type='OP'AND e.doc_type='RC' ";
            if (cmbCpl_state.SelectedIndex > 0)
                strSql += " AND b.cpl_state ='" + cmbCpl_state.SelectedValue.ToString().Trim() + "'";
            if (date1 != "/  /" && date2 != "/  /")
            {
                date2 = Convert.ToDateTime(date2).AddDays(1).ToString("yyyy/MM/dd");
                strSql += " AND a.doc_date >= '" + date1 + "' AND a.doc_date < '" + date2 + "'";
            }
            if (cmbTransport_type.SelectedIndex>0)
                strSql += " AND a.transport_type = '" + cmbTransport_type.SelectedValue.ToString().Trim() + "'";
            if (cmbVend_id.SelectedIndex > 0)
            {
                strSql += " AND a.vend_id = '" + cmbVend_id.SelectedValue.ToString().Trim() + "'";
            }
            if (txtDoc_id1.Text.Trim() != "" && txtDoc_id2.Text.Trim() != "")
            {
                strSql += " AND a.doc_id >= '" + txtDoc_id1.Text.Trim() + "' AND a.doc_id <= '" + txtDoc_id2.Text.Trim() + "'";
            }
            if (txtPrd_mo1.Text.Trim() != "" && txtPrd_mo2.Text.Trim() != "")
            {
                strSql += " AND b.prd_mo >= '" + txtPrd_mo1.Text.Trim() + "' AND b.prd_mo <= '" + txtPrd_mo2.Text.Trim() + "'";
            }
            strSql += " Order by a.vend_id,a.doc_id,a.doc_date";
            DataTable tbDetails = clsPublicOfCF01.GetDataTable(strSql);
            if (cmbCpl_state.SelectedIndex != 2)//如果是提取未錄入單據的，就要設置默認值
                SetTbDefaultValue(tbDetails);
            dgvDetails.DataSource = tbDetails;
            chkSelectAll.Checked = false;

        }
        protected void SetTbDefaultValue(DataTable tbPu)
        {
            for (int i = 0; i < tbPu.Rows.Count; i++)
            {
                tbPu.Rows[i]["act_in_weg"] = tbPu.Rows[i]["in_weg"].ToString();
                tbPu.Rows[i]["act_in_qty"] = tbPu.Rows[i]["in_qty"].ToString();
                tbPu.Rows[i]["per_prod_qty"] = tbPu.Rows[i]["in_qty"].ToString();
                tbPu.Rows[i]["act_in_pack"] = tbPu.Rows[i]["in_pack"].ToString();
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void SaveProcess(int save_type)
        {
            string strSql = "";
            string result = "";
            string cpl_state = "02";
            if (save_type == 1)
                cpl_state = "02";
            else
                cpl_state = "01";
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["colChkRec"].EditedFormattedValue)
                {
                    string doc_id = dgvDetails.Rows[i].Cells["colDoc_id"].Value.ToString();
                    string seq = dgvDetails.Rows[i].Cells["colSeq"].Value.ToString();
                    string ref_doc_id = dgvDetails.Rows[i].Cells["colRef_doc_id"].Value.ToString();
                    string ref_seq = dgvDetails.Rows[i].Cells["colRef_seq"].Value.ToString();
                    double act_in_weg = Convert.ToDouble(dgvDetails.Rows[i].Cells["colAct_in_weg"].Value);
                    double act_in_qty = Convert.ToDouble(dgvDetails.Rows[i].Cells["colAct_in_qty"].Value);
                    double act_in_pack = Convert.ToDouble(dgvDetails.Rows[i].Cells["colAct_in_pack"].Value);
                    if (save_type == 2)//如果是取消收貨，則為扣除
                    {
                        act_in_weg = 0 - act_in_weg;
                        act_in_qty = 0 - act_in_qty;
                        act_in_pack = 0 - act_in_pack;
                    }
                    strSql += string.Format(@"UPDATE pu_return_details SET act_in_weg=act_in_weg+'{0}',act_in_qty=act_in_qty+'{1}'
                                ,act_in_pack=act_in_pack+'{2}',cpl_state='{3}',crusr='{4}',crtim=GETDATE()
                                WHERE doc_id='{5}' AND seq='{6}' ", act_in_weg, act_in_qty, act_in_pack, cpl_state, _userid, doc_id, seq);
                    strSql += string.Format(@"UPDATE pu_deliver_details SET act_in_weg=act_in_weg+'{0}',act_in_qty=act_in_qty+'{1}',crusr='{2}',crtim=GETDATE()
                                WHERE doc_id='{3}' AND seq='{4}' ", act_in_weg, act_in_qty, _userid, ref_doc_id, ref_seq);

                }
            }
            if (strSql != "")
            {
                result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
                if (result == "")
                {
                    chkSelectAll.Checked = false;
                    result = "更新標識成功!";
                }
            }
            MessageBox.Show(result);

            FindData();
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            SaveProcess(1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveProcess(2);
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                Boolean blSetValue = true;
                if (chkSelectAll.Checked)
                {
                    blSetValue = true;//Select All                    
                }
                else
                {
                    blSetValue = false;
                }
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    dgvDetails.Rows[i].Cells["colChkRec"].Value = blSetValue;
                }

            }
        }

        private void btnPrintCrads_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                //txtDep.Focus();

                //**********************
                show_workcard(); //数据处理
                //**********************

            }
        }
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


            DataRow dr = null;
            string order_unit;
            int order_qty, order_qty_pcs;
            for (int j = 0; j < dgvDetails.RowCount; j++)
            {
                if ((bool)dgvDetails.Rows[j].Cells["colChkRec"].EditedFormattedValue)
                {
                    Remark = "";
                    Request_date = "2016/03/17";// dgvDetails.Rows[j].Cells["t_complete_date"].Value.ToString().Trim();
                    dep = "501";// dgvDetails.Rows[j].Cells["wp_id"].Value.ToString().Trim();
                    mo = dgvDetails.Rows[j].Cells["colPrd_mo"].Value.ToString().Trim();
                    item = dgvDetails.Rows[j].Cells["colPrd_item"].Value.ToString().Trim();
                    if (dep != "" && mo != "" && item != "")
                    {
                        DataTable dt_wk = clsMo_for_jx.GetGoods_DetailsById(dep, mo, item);
                        DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(item);
                        DataTable dtPosition = clsMo_for_jx.GetPosition(item);
                        DataTable dtQty = clsMo_for_jx.GetOrderQty(mo);//獲取訂單數量
                        DataTable dtPs = clsMo_for_jx.GetPeQtyAndStep(item);
                        DataTable dtColor = clsMo_for_jx.GetColorInfo(dep, mo, item);

                        order_unit = "";
                        order_qty = 0;
                        order_qty_pcs = 0;
                        if (dtQty.Rows.Count > 0)
                        {
                            order_unit = dtQty.Rows[0]["goods_unit"].ToString();
                            order_qty = Convert.ToInt32(dtQty.Rows[0]["order_qty"]);
                            order_qty_pcs = Convert.ToInt32(dtQty.Rows[0]["order_qty_pcs"]);
                        }
                        if (dt_wk.Rows.Count > 0)
                        {
                            int Per_qty = Convert.ToInt32(dgvDetails.Rows[j].Cells["colPer_prod_qty"].Value);  //每次生產數量per_prod_qty
                            int Total_qty = Convert.ToInt32(dgvDetails.Rows[j].Cells["colIn_qty"].Value);    //生產總量prod_qty
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

                                dr["wp_id"] = dt_wk.Rows[0]["wp_id"].ToString();
                                dr["mo_id"] = dt_wk.Rows[0]["mo_id"].ToString();
                                dr["goods_id"] = dt_wk.Rows[0]["goods_id"].ToString();
                                dr["goods_name"] = dt_wk.Rows[0]["name"].ToString();
                                dr["prod_qty"] = clsUtility.NumberConvert(dt_wk.Rows[0]["prod_qty"]);
                                dr["goods_unit"] = dt_wk.Rows[0]["goods_unit"].ToString();
                                dr["within_code"] = dt_wk.Rows[0]["within_code"].ToString();
                                dr["id"] = dt_wk.Rows[0]["id"].ToString();
                                dr["ver"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["ver"]);
                                dr["sequence_id"] = dt_wk.Rows[0]["sequence_id"].ToString();
                                dr["blueprint_id"] = dt_wk.Rows[0]["blueprint_id"].ToString();
                                dr["production_remark"] = dt_wk.Rows[0]["production_remark"].ToString();
                                dr["remark"] = dt_wk.Rows[0]["remark"].ToString();
                                dr["next_wp_id"] = dt_wk.Rows[0]["next_wp_id"].ToString();
                                dr["predept_rechange_qty"] = clsUtility.FormatNullableDecimal(dt_wk.Rows[0]["predept_rechange_qty"]);
                                dr["order_qty"] = clsUtility.NumberConvert(order_qty);
                                dr["order_unit"] = order_unit;
                                dr["color"] = dt_wk.Rows[0]["color"].ToString();
                                dr["base_qty"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["base_qty"]);
                                dr["unit_code"] = dt_wk.Rows[0]["unit_code"].ToString();
                                dr["base_rate"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["base_rate"]);
                                dr["basic_unit"] = dt_wk.Rows[0]["basic_unit"].ToString();
                                dr["order_qty_pcs"] = clsUtility.NumberConvert(order_qty_pcs);
                                string next_dep_id = dt_wk.Rows[0]["next_wp_id"].ToString(); //dgvDetails.Rows[j].Cells["next_wp_id"].Value.ToString().Trim();
                                DataRow[] drDept = dt_wk.Select("next_wp_id='" + next_dep_id + "'");
                                dr["next_dep_name"] = drDept[0]["next_wp_name"].ToString();
                                Request_date = drDept[0]["t_complete_date"].ToString();

                                dr["customer_id"] = dt_wk.Rows[0]["customer_id"].ToString();
                                dr["brand_id"] = dt_wk.Rows[0]["brand_id"].ToString();
                                dr["get_color_sample"] = dt_wk.Rows[0]["get_color_sample"].ToString();
                                dr["do_color1"] = dt_wk.Rows[0]["get_color_sample"];
                                dr["page_num"] = i;
                                dr["total_page"] = NumPage;
                                dr["c_sec_qty_ok"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["c_sec_qty_ok"]);
                                dr["get_color_sample_name"] = dt_wk.Rows[0]["get_color_sample_name"];
                                dr["vendor_id"] = dt_wk.Rows[0]["vendor_id"];
                                dr["depRemark"] = Remark;
                                dr["request_date"] = Convert.ToDateTime(Request_date).ToString("yyyy/MM/dd");

                                if (dtArt.Rows.Count > 0)
                                {
                                    dr["art_id"] = dtArt.Rows[0]["art_id"].ToString();
                                    dr["picture_name"] = dtArt.Rows[0]["picture_name"].ToString();
                                }

                                if (dtColor.Rows.Count > 0)
                                {
                                    dr["color_name"] = dtColor.Rows[0]["color_name"].ToString();
                                    dr["do_color"] = dtColor.Rows[0]["do_color"].ToString();
                                }

                                if (dtPosition.Rows.Count > 0)
                                {
                                    dr["position_id"] = clsUtility.FormatNullableString(dtPosition.Rows[0]["id"]);
                                    dr["mould_no"] = clsUtility.FormatNullableString(dtPosition.Rows[0]["mould_no"]);
                                }

                                if (dep == "302")
                                {
                                    dr["report_name"] = "生產單";
                                }
                                else
                                {
                                    dr["report_name"] = "工序卡";
                                }

                                if (dt_wk.Rows[0]["t_complete_date"].ToString() != "" && dt_wk.Rows[0]["t_complete_date"].ToString() != null)
                                {
                                    dr["t_complete_date"] = Convert.ToDateTime(dt_wk.Rows[0]["t_complete_date"]).ToString("yyyy/MM/dd");
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
                                dr["BarCode"] = clsMo_for_jx.ReturnBarCode(dt_wk.Rows[0]["mo_id"] + "0" + dt_wk.Rows[0]["ver"] + dt_wk.Rows[0]["sequence_id"].ToString().Substring(2, 2));
                                //貨倉位置
                                dr["goods_position"] = clsMo_for_jx.ReturnGoodsPosition(dt_wk.Rows[0]["goods_id"].ToString(), dt_wk.Rows[0]["next_wp_id"].ToString());
                                dtNewWork.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtNewWork.Rows.Count > 0)
            {
                xtaWork_jx xr = new xtaWork_jx();
                xr.DataSource = dtNewWork;
                xr.ShowPreviewDialog();
            }
        }

        private void btnExportToExce_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                //**********************
                DvExportExcel(); //数据处理
                //**********************
            }
        }

        private void DvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                for (int i = 0; i < dgvDetails.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容
                string col_value;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                    {

                        if (columnNo > 0)
                        {
                            tempstr += "\t";
                        }
                        col_value = "";
                        if (dgvDetails.Rows[rowNo].Cells[columnNo].Value != null)
                        {
                            if (columnNo != 14)
                                col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                            else
                                col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value + "\"";//日期轉換為字符
                        }
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void cmbCpl_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnableBtn();
        }

        protected void SetEnableBtn()
        {
            btnConf.Enabled = false;
            btnCancel.Enabled = false;
            int sli = cmbCpl_state.SelectedIndex;
            if (sli == 1)
            {
                btnConf.Enabled = true;
                btnCancel.Enabled = false;
            }
            else
            {
                if (sli == 2)
                {
                    btnConf.Enabled = false;
                    btnCancel.Enabled = true;
                }
            }
        }
    }
}
