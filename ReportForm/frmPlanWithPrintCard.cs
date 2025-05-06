﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using cf01.ModuleClass;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using cf01.Reports;
using System.Reflection;
using cf01.CLS;
using cf01.MDL;
using cf01.Forms;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmPlanWithPrintCard : Form
    {
        private CheckBox CheckBox1 = new CheckBox();

        private DataTable dtMoPlan;
        clsCommonUse commUse = new clsCommonUse();

        public frmPlanWithPrintCard()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmPlan01_Load(object sender, EventArgs e)
        {
            ////綁定表格
            //commUse.BuilDataGridView(dgvDetails, "frmPlanWithPrintCard_grid", DBUtility._language);

            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "frmPlan01_rpt_type" + "'" +
                    " AND language_id =" + "'" + DBUtility._language + "'";
            commUse.BindComboBox(cmbReportType, "formname", "show_name", strsql, "v_dict_group");
            AddCheckBox();
            InitQueryValue();
            if (frmMoSchedule.sendDep!="")
            {
                txtDep.Text = frmMoSchedule.sendDep;
                txtChkDate1.Text = System.DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd HH:mm:ss");
                txtChkDate2.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            txtNextWip.Text = "128";
        }

        /// <summary>
        ///添加全選框 
        /// </summary>
        private void AddCheckBox()
        {
            //CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
            //CheckBox1.Visible = false;
            //CheckBox1.Text = "全選";

        }


        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            txtMo1.Focus();
            if (!ValidateDateType())
                return;
            chkSelectAll.Checked = false;
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            find_data(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

        }

        private bool ValidateDateType()
        {
            if (txtRqDate1.Text.Trim() != "" || txtRqDate2.Text.Trim() != "")
            {
                if (clsValidRule.CheckDateValid(txtRqDate1.Text) == false || clsValidRule.CheckDateValid(txtRqDate2.Text) == false)
                {
                    MessageBox.Show("要求日期不正確!");
                    this.txtRqDate1.Focus();
                    return false;
                }
            }
            if (txtPlDate1.Text.Trim() != "" || txtPlDate2.Text.Trim() != "")
            {
                if (clsValidRule.CheckDateValid(txtPlDate1.Text) == false || clsValidRule.CheckDateValid(txtPlDate2.Text) == false)
                {
                    MessageBox.Show("計劃單日期不正確!");
                    this.txtPlDate1.Focus();
                    return false;
                }
            }
            if (txtChkDate1.Text.Trim() != "" || txtChkDate2.Text.Trim() != "")
            {
                if (clsValidRule.CheckDateValid(txtChkDate1.Text) == false || clsValidRule.CheckDateValid(txtChkDate2.Text) == false)
                {
                    MessageBox.Show("批準日期不正確!");
                    this.txtChkDate1.Focus();
                    return false;
                }
            }
            return true;
        }

        private void txtPrd_item1_TextChanged(object sender, EventArgs e)
        {
            txtPrd_item2.Text = txtPrd_item1.Text;
        }

        private void txtMo1_TextChanged(object sender, EventArgs e)
        {
            txtMo2.Text = txtMo1.Text;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtMo1.Focus();
            DvExportExcel(3); //匯出数据处理
        }

        private void tsBtnExportToExce_Click(object sender, EventArgs e)
        {
            txtMo1.Focus();
            DvExportExcel(1); //匯出数据处理
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.upd_mo_status();
        }

        private void tsbtnPrintCrads_Click(object sender, EventArgs e)
        {
            txtMo1.Focus();
            bool flagSelect = false;
            for (int i = 0; i < dtMoPlan.Rows.Count; i++)
            {
                if ((bool)dtMoPlan.Rows[i]["select_flag"])
                {
                    flagSelect = true;
                    break;
                }
            }
            if (!flagSelect)
            {
                MessageBox.Show("請首先選中需要列印的數據!", "提示信息");
                return;
            }
            //**********************
            show_workcard(1); //数据处理
                              //**********************

        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {
            List<mdlQueryValue> lsQV = new List<mdlQueryValue>();
            clsUtility.GetValue(this.panel1.Controls, lsQV, this.Name);

            if (lsQV.Count > 0)
            {
                int Result = clsQueryValue.AddOrUpdateQueryValue(lsQV);
                if (Result > 0)
                {
                    MessageBox.Show("查詢條件已保存。");
                }
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        private void find_data()
        {
            string cmpDat1 = "", cmpDat2 = "";
            string chkDat1 = "", chkDat2 = "";
            string planDat1 = "", planDat2 = "";
            int show_ver = 0;
            int zero_qty = 0;
            int isprint = 0;
            cmpDat1 = txtRqDate1.Text;
            cmpDat2 = txtRqDate2.Text;
            chkDat1 = txtChkDate1.Text;
            chkDat2 = txtChkDate2.Text;
            planDat1 = txtRqDate1.Text;
            planDat2 = txtRqDate2.Text;
            if (rdbNoPrint.Checked == true)//不包含已列印的記錄
                isprint = 0;
            if (rdbIsPrint.Checked == true)//只包含已列印的記錄
                isprint = 1;
            if (rdbAllPrint.Checked == true)//包含已列印的記錄
                isprint = 2;
            int f_type;
            if (cmbReportType.SelectedIndex == -1 || cmbReportType.SelectedItem.ToString() == "")
                f_type = 1;
            else
                f_type = cmbReportType.SelectedIndex + 1;
            if (rdbZeroVer.Checked == true)
                show_ver = 0;
            if (rdbNoZeroVer.Checked == true)
                show_ver = 1;
            if (rdbAllVer.Checked == true)
                show_ver = 2;
            if (chkReqPrdQty.Checked == true)//若包含生產數為零的記錄
                zero_qty = 1;
            //z_plan01//usp_LoadDepPlan   @old_arrange_date
            DataTable dt = commUse.getDataProcedure("usp_LoadPlanNew",
                new object[] { f_type, show_ver,isprint, "JX", txtDep.Text,"", cmpDat1, cmpDat2, planDat1, planDat2, chkDat1, chkDat2, txtMo1.Text, txtMo2.Text
                    ,txtPrd_item1.Text,txtPrd_item2.Text,zero_qty,0});
            //dtMoPlan = commUse.getDataProcedure("usp_LoadPlan",
            //    new object[] { f_type, show_ver,isprint, "JX", txtDep.Text,"", cmpDat1, cmpDat2, planDat1, planDat2, chkDat1, chkDat2, txtMo1.Text, txtMo2.Text
            //        ,txtPrd_item1.Text,txtPrd_item2.Text,zero_qty,0,""});
            
            if (chkSimplePlan.Checked == false)
            {
                dtMoPlan = dt;
            }else
            {
                foreach (DataRow MyDataRow in dt.Select("order_qty > c_qty_ok AND pre_dep_deliver_flag <> '上部門欠件' AND wp_id <> next_wp_id AND next_wp_id<>'702' AND substring(mo_id,1,1)<>'Y' "))//
                {
                    dtMoPlan.ImportRow(MyDataRow);
                }
            }
            // 添加布尔型字段并设置默认值
            DataColumn boolColumn = new DataColumn("select_flag", typeof(bool))
            {
                DefaultValue = false // 设置默认值为 true
            };
            dtMoPlan.Columns.Add(boolColumn);
            gcPlanDetails.DataSource = dtMoPlan;
        }

        /// <summary>
        /// 匯出Excel
        /// </summary>
        private void DvExportExcel(int rpt_type)
        {
            if (dtMoPlan.Rows.Count == 0)
            {
                MessageBox.Show("沒有待匯出的記錄!");
                return;
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string file_name = saveFile.FileName;
                clsMoScheduleUse.ExpToExcelPlan(file_name, dtMoPlan, rpt_type);
            }
        }

        /// <summary>
        /// 更新制單狀態
        /// </summary>
        private void upd_mo_status()
        {
            string FileName = "";
            this.openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            //"Excel文件(*.xls)|*.xls|所有檔案(*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)//獲取Excel文件
                FileName = this.openFileDialog1.FileName;
            else
                return;

            string strCode = null;

            //將Excel文件匯入到Datatable

            System.Data.DataTable dtFromExcel = new System.Data.DataTable(); //c.GetDataFromExcel(FileName, false, 1);
            //dgvDetails.DataSource = dtFromExcel;
            string mo_id, mo_req_status;
            string usr = DBUtility._user_id;
            DateTime tim = DateTime.Now;
            bool upd_status = true;
            int RowCount = dtFromExcel.Rows.Count;//行数
            for (int i = 1; i < RowCount; i++)
            {
                mo_id = dtFromExcel.Rows[i][0].ToString().Trim();
                mo_req_status = dtFromExcel.Rows[i][1].ToString().Trim();
                if (mo_id.Length > 10)
                    mo_id = mo_id.Substring(0, 9);
                if (mo_req_status.Length > 80)
                    mo_req_status = mo_req_status.Substring(0, 79);
                //添加
                strCode = "select mo_id from mo_status where mo_id = '" + mo_id + "'";
                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                    if (dtRows.Rows.Count <= 0)
                    {
                        strCode = "INSERT INTO mo_status(mo_id,mo_req_status,cr_usr,cr_tim) ";
                        strCode += "VALUES(@mo_id,@mo_req_status,@usr,@tim)";

                        this.ParametersAddValue(mo_id, mo_req_status, usr, tim);
                        if (commUse.ExecDataBySql(strCode) > 0)
                        {
                            //MessageBox.Show("儲存成功！", "系統信息");
                        }
                        else
                        {
                            upd_status = false;
                            break;
                        }
                    }
                    else
                    {
                        //更新数据库
                        try
                        {
                            strCode = "UPDATE mo_status SET mo_req_status = @mo_req_status,am_usr=@usr,am_tim=@tim ";
                            strCode += " WHERE mo_id = @mo_id";
                            this.ParametersAddValue(mo_id, mo_req_status, usr, tim);
                            if (commUse.ExecDataBySql(strCode) > 0)
                            {
                                //MessageBox.Show("儲存成功！", "系統信息");
                            }
                            else
                            {
                                upd_status = false;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            upd_status = false;
                            MessageBox.Show(ex.Message, "系統信息");
                        }
                    }
                }
                catch (Exception ex)
                {
                    upd_status = false;
                    MessageBox.Show(ex.Message, "系統信息");
                }
            }
            if (upd_status == true)
                MessageBox.Show("更新制單狀態成功！", "系統信息");
            else
                MessageBox.Show("更新制單狀態失敗！", "系統信息");
        }

        private void ParametersAddValue(string mo_id, string mo_req_status, string usr, DateTime tim)
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@mo_id", mo_id);
            commUse.Cmd.Parameters.AddWithValue("@mo_req_status", mo_req_status);
            commUse.Cmd.Parameters.AddWithValue("@usr", usr);
            commUse.Cmd.Parameters.AddWithValue("@tim", tim);
        }

        /// <summary>
        ///獲取數據，并顯示工序卡 
        /// </summary>
        private void show_workcard(int rpt_type)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            string dep="", mo="", item="", Remark="",next_goods_id="";

            ////建立工序卡臨時表
            DataTable dtNewWork = CreateNewWork();
            DataRow dr = null;
            string order_unit;
            int order_qty, order_qty_pcs;
            string plate_remark = "";
            DataTable dt_wk = new DataTable();
            DataTable dtPosition = new DataTable();
            DataTable dtQty = new DataTable();
            DataTable dtPs = new DataTable();
            DataTable dtNextNextItem = new DataTable();
            DataTable dtCurrentWipItem = new DataTable();
            DataTable dtNextItem = new DataTable();
            string do_color_next_dep = "";
            string next_dep_id = "";
            for (int j = 0; j < dtMoPlan.Rows.Count; j++)
            {
                DataRow dgr = dtMoPlan.Rows[j];
                if ((bool)dgr["select_flag"])
                {
                    //DataGridViewRow dgr = dgvDetails.Rows[j];
                    Remark = "";
                    mo = dgr["mo_id"].ToString().Trim();
                    if (rpt_type == 1)//列印當前部門的工序卡
                    {
                        dep = dgr["wp_id"].ToString().Trim();
                        item = dgr["goods_id"].ToString().Trim();
                        //當前貨品的下部門的貨品、顏色做法
                        next_goods_id = dgr["next_goods_id"].ToString().Trim(); //2023/03/02
                        do_color_next_dep = dgr["next_do_color"].ToString().Trim(); //clsMo_for_jx.Get_do_color_next_dep(mo, item, dep);
                        next_dep_id = dgr["next_wp_id"].ToString().Trim();
                    }
                    else//列印下部門的工序卡
                    {
                        dep = txtNextWip.Text.Trim();
                        if (dgr["next_wp_id"].ToString().Trim() != dep)
                            continue;
                        item = dgr["next_goods_id"].ToString().Trim();

                        //獲取當前貨品的下部門的貨品、顏色做法
                        //這裡是將當前貨品作為下部門的原料來查找，所以找出來的已是下部門的資料
                        dtNextItem = clsMo_for_jx.GetNextItem(mo, item);
                        if (dtNextItem.Rows.Count > 0)
                        {
                            next_goods_id = dtNextItem.Rows[0]["goods_id"].ToString();// dgr["next_next_goods_id"].Value.ToString().Trim(); //2023/03/02
                            do_color_next_dep = dtNextItem.Rows[0]["do_color"].ToString();
                            //next_dep_id = dtNextItem.Rows[0]["wp_id"].ToString();
                        }
                        else
                        {
                            next_goods_id = "";
                            do_color_next_dep = "";
                            //next_dep_id = "";
                        }
                        dtCurrentWipItem = clsMo_for_jx.GetCurrentWipData(dep,mo, item);
                    }
                    
                    if (dep != "" && mo != "" && item != "")
                    {
                        dt_wk = clsMo_for_jx.GetGoods_DetailsById(dep, mo, item); //獲取工序卡大部分數據
                        //DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(item);
                        dtPosition = clsMo_for_jx.GetPosition(item);
                        dtQty = clsMo_for_jx.GetOrderQty(mo);//獲取訂單數量
                        dtPs = clsMo_for_jx.GetPeQtyAndStep(item);
                        //通過下部門貨品再找下下部門的貨品資料
                        dtNextNextItem = clsMo_for_jx.GetNextNextItem(mo, next_goods_id);
                        //DataTable dtColor = clsMo_for_jx.GetColorInfo(dep, mo, item);
                        //DataTable dtPlate_Remark = clsMo_for_jx.Get_Plate_Remark(mo);                       

                        order_unit = "";
                        order_qty = 0;
                        order_qty_pcs = 0;
                        if (dtQty.Rows.Count > 0)
                        {
                            order_unit = dtQty.Rows[0]["goods_unit"].ToString();
                            order_qty = Convert.ToInt32(dtQty.Rows[0]["order_qty"]);
                            order_qty_pcs = Convert.ToInt32(dtQty.Rows[0]["order_qty_pcs"]);
                            plate_remark=  dtQty.Rows[0]["plate_remark"].ToString();
                        }
                        if (dt_wk.Rows.Count > 0)
                        {
                            DataRow drDtWk = dt_wk.Rows[0];
                            string strBarCode = clsMo_for_jx.ReturnBarCode(drDtWk["mo_id"] + "0" + drDtWk["ver"] + drDtWk["sequence_id"].ToString().Substring(2, 2));

                            int Per_qty = Convert.ToInt32(dgr["per_prod_qty"]);  //每次生產數量
                            int Total_qty = Convert.ToInt32(dgr["prod_qty"]);    //生產總量
                            int qty_remaining = 0; //2024/01/31 ADD ALLEN
                            int NumPage = 0;     //報表頁數                            
                            if (Total_qty > 0 && Per_qty > 0)
                            {
                                if (Total_qty % Per_qty > 0)
                                {
                                    NumPage = (Total_qty / Per_qty) + 1;
                                    qty_remaining = Total_qty % Per_qty; //2024/01/31 ADD ALLEN
                                }
                                else
                                {
                                    NumPage = (Total_qty / Per_qty);
                                    qty_remaining = 0; //2024/01/31 ADD ALLEN
                                }
                            }
                            else
                            {
                                NumPage = 1;
                            }
                            if (rpt_type == 2)//當列印當前部門的下部門工序卡時
                                next_dep_id = drDtWk["next_wp_id"].ToString();
                            for (int i = 1; i <= NumPage; i++)
                            {
                                dr = dtNewWork.NewRow();
                                //dr["BarCode"] = drDtWk["item_barcode"].ToString().Trim();
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
                                //string dept= drDtWk["next_wp_id"].ToString();
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
                                
                                DataRow[] drDept = dt_wk.Select("next_wp_id='" + next_dep_id + "'");
                                if (next_dep_id == "702")
                                {
                                    dr["next_wp_id"] = "702"; //當有測式工序卡時部門名稱與描述不一致的情況.2023/09/14改為手動賦值.
                                }
                                dr["next_dep_name"] = (drDept.Length > 0) ? drDept[0]["next_wp_name"].ToString() : "";                                
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
                                dr["request_date"] = drDtWk["t_complete_date"];// Request_date;
                                dr["color_name"] = drDtWk["color_name"].ToString();
                                dr["do_color"] = drDtWk["do_color"].ToString();
                                dr["wh_location"] = drDtWk["wh_location"].ToString();
                                //if (dtPlate_Remark.Rows.Count > 0)
                                //{
                                //    dr["plate_remark"] = dtQty.Rows[0]["plate_remark"];
                                //}
                                //if (dtArt.Rows.Count > 0)
                                //{
                                dr["art_id"] = "";// dtArt.Rows[0]["art_id"].ToString();
                                if (rpt_type == 1)//如果是列印當前部門的
                                    dr["picture_name"] = dgr["picture_name"].ToString().Trim();// dtArt.Rows[0]["picture_name"].ToString();
                                else//如果是列印當前部門的下部門的
                                    dr["picture_name"] = dtCurrentWipItem.Rows[0]["picture_name"];
                                //}

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

                                if (!string.IsNullOrEmpty(drDtWk["t_complete_date"].ToString()))
                                {
                                    dr["t_complete_date"] = Convert.ToDateTime(drDtWk["t_complete_date"]).ToString("yyyy/MM/dd");
                                }
                                if (!string.IsNullOrEmpty(drDtWk["arrive_date"].ToString()))
                                {
                                    dr["arrive_date"] = Convert.ToDateTime(drDtWk["arrive_date"]).ToString("yyyy/MM/dd");
                                }

                                //--start 2024/03/13 add qc info by allen
                                dr["qc_dept"] = drDtWk["qc_dept"].ToString();
                                dr["qc_name"] = drDtWk["qc_name"].ToString();
                                dr["qc_qty"] = drDtWk["qc_qty"].ToString();
                                if(next_dep_id=="702" || next_dep_id == "722")
                                {
                                    dr["qc_dept"] = "";
                                    dr["qc_name"] = "";
                                    dr["qc_qty"] = "";
                                }
                                //--end 2024/03/13 add by allen

                                if (i == NumPage && Per_qty != 0)
                                {                                   
                                    dr["per_qty"] = (qty_remaining>0)? clsUtility.NumberConvert(qty_remaining): clsUtility.NumberConvert(Per_qty);                                    
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
                                ////條碼Barcode
                                dr["BarCode"] = strBarCode;
                                //貨倉位置
                                //dr["goods_position"] = drDtWk["wh_location"].ToString(); //clsMo_for_jx.ReturnGoodsPosition(drDtWk["goods_id"].ToString(), drDtWk["next_wp_id"].ToString());
                                dr["do_color_next_dep"] = do_color_next_dep;
                                if (rpt_type == 1)//如果是列印當前部門的
                                {
                                    dr["next_goods_id"] = dgr["next_goods_id"].ToString().Trim();
                                    dr["next_do_color"] = dgr["next_do_color"].ToString().Trim();
                                    dr["next_vendor_id"] = dgr["next_vendor_id"].ToString().Trim();
                                    dr["next_goods_name"] = dgr["next_goods_name"].ToString().Trim();
                                    dr["next_next_wp_id"] = dgr["next_next_wp_id"].ToString().Trim();
                                    dr["next_next_dep_name"] = dgr["next_next_dep_name"].ToString().Trim();
                                }
                                else//如果是列印當前部門的下部門的
                                {
                                    if (dtNextItem.Rows.Count > 0)
                                    {
                                        //////下部門
                                        dr["next_goods_id"] = dtNextItem.Rows[0]["goods_id"].ToString();
                                        dr["next_do_color"] = dtNextItem.Rows[0]["do_color"].ToString();
                                        dr["next_goods_name"] = dtNextItem.Rows[0]["goods_name"].ToString();
                                        //////下下部門
                                        dr["next_next_wp_id"] = dtNextItem.Rows[0]["next_wp_id"].ToString();
                                        dr["next_next_dep_name"] = dtNextItem.Rows[0]["next_wp_name"].ToString();
                                    }
                                    else
                                    {
                                        dr["next_next_wp_id"] = "";
                                        dr["next_next_dep_name"] = "";//drDtWk["vendor_id"]
                                    }
                                    dr["next_vendor_id"] = drDtWk["vendor_id"];

                                }
                                dr["prod_date"] = "";
                                if(dtNextNextItem.Rows.Count>0)
                                {
                                    dr["next_next_goods_id"] = dtNextNextItem.Rows[0]["next_next_goods_id"].ToString();
                                    dr["next_next_do_color"] = dtNextNextItem.Rows[0]["next_next_do_color"].ToString();
                                }
                                dr["qty_remaining"] = qty_remaining; //2024/01/31 ADD ALLEN
                                dr["stantard_qty"] = "";//clsUtility.FormatNullableInt32(drDtWk["base_rate"]);
                                dr["qc_test"] = drDtWk["qc_test"].ToString();
                                dtNewWork.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtNewWork.Rows.Count > 0)
            {             
                if (txtDep.Text == "302" || txtDep.Text == "322")
                {
                    xtaWork_jx xr = new xtaWork_jx() { DataSource = dtNewWork };
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreviewDialog();
                }
                else
                {                   
                    xtaWork_No_BarCode xr = new xtaWork_No_BarCode() { DataSource = dtNewWork };
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreviewDialog();
                }
            }

        }


        private DataTable CreateNewWork()
        {
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
            dtNewWork.Columns.Add("arrive_date", typeof(string));
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
            //dtNewWork.Columns.Add("goods_position", typeof(string));
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

            dtNewWork.Columns.Add("next_next_goods_id", typeof(string));
            dtNewWork.Columns.Add("next_next_do_color", typeof(string));
            dtNewWork.Columns.Add("qty_remaining", typeof(int));

            //2024/03/12
            dtNewWork.Columns.Add("qc_dept", typeof(string));
            dtNewWork.Columns.Add("qc_name", typeof(string));
            dtNewWork.Columns.Add("qc_qty", typeof(string));
            dtNewWork.Columns.Add("stantard_qty", typeof(string));
            dtNewWork.Columns.Add("qc_test", typeof(string));
            return dtNewWork;
        }
        /// <summary>
        /// 加載 User上次查詢條件 
        /// </summary>
        private void InitQueryValue()
        {
            DataTable dtvalue = clsQueryValue.GetQueryValue(this.Name, DBUtility._user_id);
            if (dtvalue.Rows.Count > 0)
            {
                for (int i = 0; i < dtvalue.Rows.Count; i++)
                {
                    string strObj_id = dtvalue.Rows[i]["obj_id"].ToString();
                    string strOjb_Value = dtvalue.Rows[i]["obj_value"].ToString();

                    if (txtDep.Name == strObj_id)
                    {
                        txtDep.Text = strOjb_Value;
                    }

                    if (txtChkDate2.Name == strObj_id)
                    {
                        txtChkDate1.Text = strOjb_Value;
                        txtChkDate2.Text = DateTime.Now.AddSeconds(-300).ToString("yyyy/MM/dd HH:mm:ss");
                    }

                    if (txtRqDate2.Name == strObj_id)
                    {
                        txtRqDate1.Text = strOjb_Value;
                        //txtRqDate2.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    }

                    if (txtPlDate2.Name == strObj_id)
                    {
                        txtPlDate1.Text = strOjb_Value;
                        //txtPlDate2.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    }

                    if (txtMo1.Name == strObj_id)
                    {
                        txtMo1.Text = strOjb_Value;
                    }
                    if (txtMo2.Name == strObj_id)
                    {
                        txtMo2.Text = strOjb_Value;
                    }
                    if (cmbReportType.Name == strObj_id)
                    {
                        cmbReportType.SelectedIndex = Convert.ToInt32(strOjb_Value);
                    }
                    if (rdbAllVer.Name == strObj_id)
                    {
                        rdbAllVer.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }
                    if (rdbNoZeroVer.Name == strObj_id)
                    {
                        rdbNoZeroVer.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }
                    if (rdbNoZeroVer.Name == strObj_id)
                    {
                        rdbNoZeroVer.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }

                    if (chkReqPrdQty.Name == strObj_id)
                    {
                        chkReqPrdQty.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }

                    if (rdbNoPrint.Name == strObj_id)
                    {
                        rdbNoPrint.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }

                    if (rdbIsPrint.Name == strObj_id)
                    {
                        rdbIsPrint.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }

                    if (rdbAllPrint.Name == strObj_id)
                    {
                        rdbAllPrint.Checked = clsUtility.FormatNullableBool(strOjb_Value);
                    }

                }
            }
        }

        private void dgvDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex == -1 & e.ColumnIndex == 0)
            //{
            //    Point p = dgvDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
            //    //p.Offset(dgvDetails.Left, dgvDetails.Top);
            //    p.Offset(120, 130);
            //    CheckBox1.Location = p;
            //    CheckBox1.Size = dgvDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
            //    CheckBox1.Visible = true;
            //    CheckBox1.BringToFront();
            //}
        }

        private void btnExpToExcelJx_Click(object sender, EventArgs e)
        {
            txtMo1.Focus();
            DvExportExcel(2);//匯出數據處理
        }

        private void btnPrintNextWp_Click(object sender, EventArgs e)
        {
            show_workcard(2);
        }

        private void btnMoSchedule_Click(object sender, EventArgs e)
        {
            txtMo1.Focus();
            bool selectFlag = false;
            for (int i = 0; i < dtMoPlan.Rows.Count; i++)
            {
                if ((bool)dtMoPlan.Rows[i]["select_flag"])
                {
                    selectFlag = true;
                    break;
                }
            }
            if (selectFlag == false)
            {
                MessageBox.Show("沒有儲存的記錄!");
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            SaveMoSchedule(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            
        }
        private void SaveMoSchedule()
        {
            
            List<mdlMoSchedule> lsModel = new List<mdlMoSchedule>();
            int seq_step = clsMoSchedule.GetScheduleSeq(dtMoPlan.Rows[0]["wp_id"].ToString().Trim());
            for (int i = 0; i < dtMoPlan.Rows.Count; i++)
            {
                if ((bool)dtMoPlan.Rows[i]["select_flag"])
                {
                    DataRow drMo = dtMoPlan.Rows[i];
                    mdlMoSchedule objModel = new mdlMoSchedule();
                    objModel.schedule_id = "";
                    objModel.schedule_seq = seq_step.ToString("D3").PadLeft(3, '0');
                    objModel.schedule_date = System.DateTime.Now.ToString("yyyy/MM/dd");
                    objModel.prd_dep = drMo["wp_id"].ToString().Trim();
                    objModel.prd_mo = drMo["mo_id"].ToString().Trim();
                    objModel.prd_item = drMo["goods_id"].ToString().Trim();
                    //DataTable dtPrd = clsMoSchedule.GetPrdDetails(objModel.prd_dep, objModel.prd_item);
                    objModel.prd_group = drMo["prd_group"].ToString().Trim();
                    objModel.pmc_rq_date = drMo["t_complete_date"].ToString().Trim();
                    objModel.next_wp_id = drMo["next_wp_id"].ToString().Trim();
                    objModel.next_goods_id = drMo["next_goods_id"].ToString().Trim();
                    objModel.next_vend_id = drMo["next_vendor_id"].ToString().Trim();
                    objModel.order_date = drMo["order_date"].ToString().Trim();
                    objModel.order_qty = clsValidRule.ConvertStrToInt(drMo["order_qty"].ToString());
                    objModel.pl_qty = clsValidRule.ConvertStrToInt(drMo["prod_qty"].ToString());
                    objModel.schedule_qty = objModel.pl_qty;


                    objModel.prd_machine = drMo["prd_machine"].ToString().Trim();
                    objModel.machine_std_qty = clsValidRule.ConvertStrToInt(drMo["machine_std_qty"].ToString());
                    objModel.machine_std_run_num = clsValidRule.ConvertStrToInt(drMo["machine_rate"].ToString());
                    if(objModel.machine_std_run_num == 0)
                    {
                        if(objModel.prd_dep=="322")
                        {
                            objModel.machine_std_run_num = 450;
                        }
                    }
                    //需生產時間a.machine_mul,a.machine_rate,a.machine_std_qty
                    objModel.machine_std_line_num = clsValidRule.ConvertStrToInt(drMo["machine_mul"].ToString());
                    if (objModel.machine_std_line_num == 0)
                    {
                        if (objModel.prd_dep == "322")
                            objModel.machine_std_line_num = 6;
                        else
                            objModel.machine_std_line_num = 1;
                    }
                    objModel.need_mon_num = ((int)(objModel.schedule_qty / objModel.machine_std_line_num) + 1);
                    //if (objModel.machine_std_qty == 0)
                    objModel.machine_std_qty = objModel.machine_std_run_num * objModel.machine_std_line_num;
                    if (objModel.machine_std_qty != 0)
                        objModel.req_prd_time = Math.Round(objModel.schedule_qty / objModel.machine_std_qty, 2);
                    
                    objModel.req_tot_time = objModel.req_module_time + objModel.req_prd_time;

                    objModel.module_type = "00";
                    string status_desc = drMo["status_desc"].ToString().Trim();
                    objModel.urgent_flag = "00";
                    if (status_desc == "急單" || status_desc == "急")
                        objModel.urgent_flag = "02";
                    else if (status_desc == "特急" || status_desc == "特急單")
                        objModel.urgent_flag = "03";
                    else if (status_desc == "超特急" || status_desc == "超特急單")
                        objModel.urgent_flag = "04";
                    objModel.status = "01";
                    
                    lsModel.Add(objModel);
                    seq_step++;
                }
            }

            if (lsModel.Count > 0)
            {
                string result = clsMoSchedule.SaveMoSchedule(lsModel);
                if (result =="")
                {
                    //MessageBox.Show("生成排期表成功!");
                    if (frmMoSchedule.sendDep != "")
                        this.Close();
                }
                else
                {
                    MessageBox.Show("生成排期表失敗!");
                }
            }
        }

        private void txtPlDate1_Leave(object sender, EventArgs e)
        {
            txtPlDate2.Text = txtPlDate1.Text;
        }

        private void txtRqDate1_Leave(object sender, EventArgs e)
        {
            txtRqDate2.Text = txtRqDate1.Text;
        }

        private void txtPrd_item1_Leave(object sender, EventArgs e)
        {
            txtPrd_item2.Text = txtPrd_item1.Text;
        }

        private void txtMo1_Leave(object sender, EventArgs e)
        {
            txtMo2.Text = txtMo1.Text;
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            bool selectFlag = false;
            if (chkSelectAll.Checked == true)
                selectFlag = true;
            for (int i = 0; i < dtMoPlan.Rows.Count; i++)
            {
                dtMoPlan.Rows[i]["select_flag"] = selectFlag;
               
            }
        }

        private void gvPlanDetails_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();// "G" + 
                }
            }
        }
    }
}
