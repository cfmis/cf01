using System;
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

        DataTable dt1, dt2;
        clsCommonUse commUse = new clsCommonUse();

        public frmPlanWithPrintCard()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmPlan01_Load(object sender, EventArgs e)
        {
            //綁定表格
            commUse.BuilDataGridView(dgvDetails, "frmPlanWithPrintCard_grid", DBUtility._language);

            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "frmPlan01_rpt_type" + "'" +
                    " AND language_id =" + "'" + DBUtility._language + "'";
            commUse.BindComboBox(cmbReportType, "formname", "show_name", strsql, "v_dict_group");
            dgvDetails.AutoGenerateColumns = false;
            AddCheckBox();
            InitQueryValue();
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
            if (clsValidRule.CheckDateIsEmpty(this.mkCmpDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkCmpDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mkCmpDat1.Text) == false || clsValidRule.CheckDateFormat(this.mkCmpDat2.Text) == false)
                {
                    MessageBox.Show("要求日期不正確!");
                    this.mkCmpDat1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.mkPlanDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkPlanDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mkPlanDat1.Text) == false || clsValidRule.CheckDateFormat(this.mkPlanDat2.Text) == false)
                {
                    MessageBox.Show("計劃單日期不正確!");
                    this.mkPlanDat1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.mkChkDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkChkDat2.Text) == false)
            {
                //if (clsValidRule.CheckDateTimeFormat(this.mkChkDat1.Text) == false || clsValidRule.CheckDateTimeFormat(this.mkChkDat2.Text) == false)
                //{
                //    MessageBox.Show("批準日期不正確!");
                //    this.mkChkDat1.Focus();
                //    return;
                //}
            }
            checkBox2.Checked = false;
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
            if (!clsUtility.CheckDate(mkChkDat1.Text.Trim()))
            {
                mkChkDat1.Focus();
                mkChkDat1.SelectAll();
                return false;
            }
            return true;
        }

        private void mkPlanDat1_Leave(object sender, EventArgs e)
        {
            mkPlanDat2.Text = mkPlanDat1.Text;
        }

        private void mkChkDat1_Leave(object sender, EventArgs e)
        {

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
            if (dgvDetails.RowCount > 0)
            {
                //**********************
                DvExportExcel_1(); //数据处理
                //**********************
            }
        }

        private void tsBtnExportToExce_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                //**********************
                DvExportExcel("ALL"); //数据处理
                //**********************
            }
        }

        private void chkSimplePlan_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (chkSimplePlan.Checked == true)
                    this.showSimplePlan();
                else
                    dgvDetails.DataSource = dt1;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.upd_mo_status();
        }

        private void tsbtnPrintCrads_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtDep.Focus();
                bool flagSelect = false;
                for (int j = 0; j < dgvDetails.RowCount; j++)
                {
                    if ((bool)dgvDetails.Rows[j].Cells["CheckBox"].EditedFormattedValue)
                    {
                        flagSelect = true;
                        break;
                    }
                }
                if (!flagSelect)
                {
                    MessageBox.Show("請首先選中需要列印的數據!","提示信息");
                    return;
                }
                //**********************
                show_workcard(); //数据处理
                //**********************

            }
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
            if (clsValidRule.CheckDateIsEmpty(this.mkCmpDat1.Text) == false)
                cmpDat1 = mkCmpDat1.Text;
            if (clsValidRule.CheckDateIsEmpty(this.mkCmpDat2.Text) == false)
                cmpDat2 = mkCmpDat2.Text;
            if (clsValidRule.CheckDateIsEmpty(this.mkChkDat1.Text) == false)
                chkDat1 = mkChkDat1.Text;
            if (clsValidRule.CheckDateIsEmpty(this.mkChkDat2.Text) == false)
                chkDat2 = mkChkDat2.Text;
            if (clsValidRule.CheckDateIsEmpty(this.mkPlanDat1.Text) == false)
                planDat1 = mkCmpDat1.Text;
            if (clsValidRule.CheckDateIsEmpty(this.mkPlanDat2.Text) == false)
                planDat2 = mkCmpDat2.Text;
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
            //z_plan01//usp_LoadDepPlan
            dt1 = commUse.getDataProcedure("usp_LoadPlan",
                new object[] { f_type, show_ver,isprint, "JX", txtDep.Text,"", cmpDat1, cmpDat2, planDat1, planDat2, chkDat1, chkDat2, txtMo1.Text, txtMo2.Text
                    ,txtPrd_item1.Text,txtPrd_item2.Text,zero_qty,0,""});
            dgvDetails.DataSource = dt1;

            if (chkSimplePlan.Checked == true)
            {
                this.showSimplePlan();
            }
        }

        /// <summary>
        /// 匯出Excel
        /// </summary>
        private void DvExportExcel(string expType)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {


                //frmProgress wForm = new frmProgress();
                //new Thread((ThreadStart)delegate
                //{
                //    wForm.TopMost = true;
                //    wForm.ShowDialog();
                //}).Start();

                Stream myStream;
                myStream = saveFile.OpenFile();

                //如果匯出到Excel中文變亂碼，可以嘗試改一下這個編碼方式
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));//utf-8

                //Response.Charset = "utf-8";
                //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); 
                string str = " ";
                if (expType == "ALL")
                {
                    str += "負責部門";
                    str += "\t" + "制單編號";
                    str += "\t" + "序號";
                    str += "\t" + "物料編號";
                    str += "\t" + "物料描述";
                    str += "\t" + "移交部門";
                    str += "\t" + "生產數量(PCS)";
                    str += "\t" + "每張生產數量";
                    str += "\t" + "訂單數量";
                    str += "\t" + "完成數量(PCS）";
                    str += "\t" + "要求日期";
                    str += "\t" + "完成日期";
                    str += "\t" + "過期天數";
                    str += "\t" + "前部門交貨標識";
                    str += "\t" + "上部門最大交貨期";
                    str += "\t" + "過期天數";
                    str += "\t" + "版本號";
                    str += "\t" + "建立日期";
                    str += "\t" + "審批日期";
                    str += "\t" + "營業員";
                    str += "\t" + "圖樣代號";
                    str += "\t" + "圖樣路徑";
                    str += "\t" + "數量單位";
                    str += "\t" + "要求數量(PCS)";
                    str += "\t" + "預留數量(PCS)";
                    str += "\t" + "上部門記錄序號";
                    str += "\t" + "上部門";
                    str += "\t" + "上部門物料編號";
                    str += "\t" + "上部門物料描述";
                    str += "\t" + "上部門生產數量";
                    str += "\t" + "上部門完成數量";
                    str += "\t" + "上部門預計交貨期";
                    str += "\t" + "上部門實際交貨期";
                    str += "\t" + "本部門逗留天數";
                    str += "\t" + "供應商";
                    str += "\t" + "供應商描述";
                    str += "\t" + "制單生產狀態";
                    str += "\t" + "計劃回港日期";
                    str += "\t" + "制單要求狀態";
                    str += "\t" + "批色";
                    str += "\t" + "記錄標識";
                    str += "\t" + "顏色做法";
                    str += "\t" + "收貨部門描述";
                    str += "\t" + "下部門供應商";
                    str += "\t" + "下部門物料編號";
                    str += "\t" + "下部門物料描述";
                    str += "\t" + "下部門顏色做法";
                    str += "\t" + "下部門顏色描述";
                    sw.WriteLine(str);

                    //写内容
                    string col_value;
                    bool IsWrite = false;  //是否寫入

                    for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                    {
                        string tempstr = " ";
                        for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                        {
                            if (columnNo > 0)
                            {
                                if (dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() != null)
                                    col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                                else
                                    col_value = "";
                                tempstr += col_value;
                                tempstr += "\t";
                            }
                        }
                        sw.WriteLine(tempstr);
                    }
                }
                else
                {
                    str += "負責部門";
                    str += "\t" + "制單編號";
                    str += "\t" + "制單日期";
                    str += "\t" + "物料編號";
                    str += "\t" + "物料描述";
                    str += "\t" + "生產數量(PCS)";
                    str += "\t" + "備註";
                    str += "\t" + "列印份數";
                    str += "\t" + "每張生產數量";
                    str += "\t" + "要求日期";
                    str += "\t" + "訂單數量";
                    str += "\t" + "移交部門";
                    str += "\t" + "部門描述";
                    str += "\t" + "顏色做法";
                    str += "\t" + "建檔人";
                    str += "\t" + "審批日期";
                    str += "\t" + "圖片位置";
                    str += "\t" + "建檔日期";
                    str += "\t" + "顏色描述";
                    str += "\t" + "版本號";
                    str += "\t" + "供應商編號";
                    str += "\t" + "完成數量";
                    
                    sw.WriteLine(str);

                    //写内容
                    string col_value;
                    bool IsWrite = false;  //是否寫入

                    for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                    {
                        string tempstr = "";
                        DataGridViewRow dgr = dgvDetails.Rows[rowNo];
                        tempstr +=dgr.Cells[1].Value.ToString();
                        tempstr += "\t" + dgr.Cells[2].Value.ToString();
                        tempstr += "\t" + "=\"" + dgr.Cells[18].Value.ToString() + "\"";
                        tempstr += "\t" + dgr.Cells[4].Value.ToString();
                        tempstr += "\t" + dgr.Cells[5].Value.ToString();
                        tempstr += "\t" + dgr.Cells[7].Value.ToString();
                        tempstr += "\t" + "";
                        tempstr += "\t" + "1";
                        tempstr += "\t" + dgr.Cells[8].Value.ToString();
                        tempstr += "\t" + "=\"" + dgr.Cells[11].Value.ToString() + "\"";
                        tempstr += "\t" + "=\"" + dgr.Cells[9].Value.ToString() + "\"";
                        tempstr += "\t" + dgr.Cells[6].Value.ToString();
                        tempstr += "\t" + dgr.Cells[43].Value.ToString();
                        tempstr += "\t" + dgr.Cells[47].Value.ToString();
                        tempstr += "\t" + "";
                        tempstr += "\t" + "=\"" + dgr.Cells[19].Value.ToString() + "\"";
                        tempstr += "\t" + dgr.Cells[22].Value.ToString();
                        tempstr += "\t" + "=\"" + dgr.Cells[18].Value.ToString() + "\"";
                        tempstr += "\t" + dgr.Cells[48].Value.ToString();
                        tempstr += "\t" + dgr.Cells[17].Value.ToString();
                        tempstr += "\t" + dgr.Cells[44].Value.ToString();
                        tempstr += "\t" + dgr.Cells[10].Value.ToString();
                        sw.WriteLine(tempstr);
                    }
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        /// <summary>
        /// 簡易匯出Excel
        /// </summary>
        private void DvExportExcel_1()
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

                //frmProgress wForm = new frmProgress();
                //new Thread((ThreadStart)delegate
                //{
                //    wForm.TopMost = true;
                //    wForm.ShowDialog();
                //}).Start();

                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));



                string str = " ";
                //写标题
                str += "序號";
                str += "\t" + "收貨部門";
                str += "\t" + "狀態";
                str += "\t" + "制單編號";
                str += "\t" + "產品編號";
                str += "\t" + "產品描述";
                str += "\t" + "應生產數量";
                str += "\t" + "上部門來貨數量";
                str += "\t" + "已完成數量";
                str += "\t" + "上部門來貨期";
                str += "\t" + "回覆";
                str += "\t" + "備註";
                str += "\t" + "計劃回港日期";
                str += "\t" + "批色";
                sw.WriteLine(str);
                //写内容
                string col_value;
                bool IsWrite = false;  // is Write in ?

                int excelNo = 1;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    ////過濾重複的記錄
                    //if (rowNo >= 1)
                    //{
                    //    if (dgvDetails.Rows[rowNo].Cells[2].Value.ToString() == dgvDetails.Rows[rowNo - 1].Cells[2].Value.ToString())        //判斷制單編號是否相同
                    //    {
                    //        if (dgvDetails.Rows[rowNo].Cells[28].Value.ToString() == dgvDetails.Rows[rowNo - 1].Cells[28].Value.ToString())  //判斷相同制單編號單據，上部門物料編號是否相同
                    //        {
                    //            IsWrite = false;
                    //        }
                    //        else
                    //        {
                    //            IsWrite = true;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        IsWrite = true;
                    //    }
                    //}
                    //else
                    //{
                    //    IsWrite = true;
                    //}

                    //if (IsWrite)
                    //{
                        string tempstr = " ";
                        tempstr += excelNo.ToString();//序號
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[6].Value.ToString().Trim();//收貨部門
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[39].Value.ToString().Trim();//狀態
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[2].Value.ToString().Trim();//制單編號
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[4].Value.ToString().Trim();//商品編號
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[5].Value.ToString().Trim();//商品描述
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[7].Value.ToString().Trim();//應生產數量
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[31].Value.ToString().Trim();//上部門來貨數量
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[10].Value.ToString().Trim();//已完成數量
                        col_value = dgvDetails.Rows[rowNo].Cells[15].Value.ToString().Trim();//上部門來貨期
                        if (col_value != "")
                            col_value = col_value.Substring(5, 5);
                        else
                            col_value = "";
                        tempstr += "\t" + col_value;//上部門來貨期
                        tempstr += "\t" + " ";//回覆
                        tempstr += "\t" + " ";//備註
                        col_value = dgvDetails.Rows[rowNo].Cells[38].Value.ToString().Trim();//計劃回港日期
                        if (col_value != "")
                            col_value = col_value.Substring(5, 5);
                        else
                            col_value = "";
                        tempstr += "\t" + col_value;//計劃回港日期
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[39].Value.ToString().Trim();//批色
                        sw.WriteLine(tempstr);

                        excelNo++;
                    //}
                }

                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        /// <summary>
        /// 只顯示簡易計劃
        /// </summary>
        private void showSimplePlan()
        {
            dt2 = dt1.Clone();
            foreach (DataRow MyDataRow in dt1.Select("order_qty > c_qty_ok AND pre_dep_deliver_flag <> '上部門欠件' AND wp_id <> next_wp_id AND next_wp_id<>'702' AND substring(mo_id,1,1)<>'Y' "))//
            {
                dt2.ImportRow(MyDataRow);
            }

            dgvDetails.DataSource = dt2;
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
        private void show_workcard()
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            string dep="", mo="", item="", Request_date="", Remark="",next_goods_id="";

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

            DataRow dr = null;
            string order_unit;
            int order_qty, order_qty_pcs;
            string plate_remark = "";
            DataTable dt_wk = new DataTable();
            DataTable dtPosition = new DataTable();
            DataTable dtQty = new DataTable();
            DataTable dtPs = new DataTable();
            DataTable dtNextNextItem = new DataTable();
            for (int j = 0; j < dgvDetails.RowCount; j++)
            {
                if ((bool)dgvDetails.Rows[j].Cells["CheckBox"].EditedFormattedValue)
                {
                    DataGridViewRow dgr = dgvDetails.Rows[j];
                    Remark = "";
                    Request_date = dgr.Cells["t_complete_date"].Value.ToString().Trim();
                    dep = dgr.Cells["wp_id"].Value.ToString().Trim();
                    mo = dgr.Cells["mo_id"].Value.ToString().Trim();
                    item = dgr.Cells["goods_id"].Value.ToString().Trim();
                    next_goods_id = dgr.Cells["next_goods_id"].Value.ToString().Trim(); //2023/03/02
                    if (dep != "" && mo != "" && item != "")
                    {
                        dt_wk = clsMo_for_jx.GetGoods_DetailsById(dep, mo, item);
                        //DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(item);
                        dtPosition = clsMo_for_jx.GetPosition(item);
                        dtQty = clsMo_for_jx.GetOrderQty(mo);//獲取訂單數量
                        dtPs = clsMo_for_jx.GetPeQtyAndStep(item);
                        dtNextNextItem = clsMo_for_jx.GetNextNextItem(mo, next_goods_id);
                        //DataTable dtColor = clsMo_for_jx.GetColorInfo(dep, mo, item);
                        //DataTable dtPlate_Remark = clsMo_for_jx.Get_Plate_Remark(mo);
                        //當前貨品的下部門顏色做法
                        string do_color_next_dep = dgr.Cells["next_do_color"].Value.ToString().Trim(); //clsMo_for_jx.Get_do_color_next_dep(mo, item, dep);
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

                            int Per_qty = Convert.ToInt32(dgr.Cells["per_prod_qty"].Value);  //每次生產數量
                            int Total_qty = Convert.ToInt32(dgr.Cells["prod_qty"].Value);    //生產總量
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
                                string next_dep_id = dgr.Cells["next_wp_id"].Value.ToString().Trim();
                                DataRow[] drDept = dt_wk.Select("next_wp_id='" + next_dep_id + "'");
                                dr["next_dep_name"] = drDept[0]["next_wp_name"].ToString();

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
                                dr["wh_location"] = drDtWk["wh_location"].ToString();
                                //if (dtPlate_Remark.Rows.Count > 0)
                                //{
                                //    dr["plate_remark"] = dtQty.Rows[0]["plate_remark"];
                                //}

                                //if (dtArt.Rows.Count > 0)
                                //{
                                dr["art_id"] = "";// dtArt.Rows[0]["art_id"].ToString();
                                    dr["picture_name"] = dgr.Cells["picture_name"].Value.ToString().Trim();// dtArt.Rows[0]["picture_name"].ToString();
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
                                ////條碼Barcode
                                dr["BarCode"] = strBarCode;
                                //貨倉位置
                                //dr["goods_position"] = drDtWk["wh_location"].ToString(); //clsMo_for_jx.ReturnGoodsPosition(drDtWk["goods_id"].ToString(), drDtWk["next_wp_id"].ToString());
                                dr["do_color_next_dep"] = do_color_next_dep;

                                dr["next_goods_id"] = dgr.Cells["next_goods_id"].Value.ToString();
                                dr["next_do_color"] = dgr.Cells["next_do_color"].Value.ToString();
                                dr["next_next_wp_id"] = dgr.Cells["next_next_wp_id"].Value.ToString();
                                dr["next_vendor_id"] = dgr.Cells["next_vendor_id"].Value.ToString();
                                dr["next_goods_name"] = dgr.Cells["next_goods_name"].Value.ToString();
                                dr["next_next_dep_name"] = dgr.Cells["next_next_dep_name"].Value.ToString();
                                dr["prod_date"] = "";
                                if(dtNextNextItem.Rows.Count>0)
                                {
                                    dr["next_next_goods_id"] = dtNextNextItem.Rows[0]["next_next_goods_id"].ToString();
                                    dr["next_next_do_color"] = dtNextNextItem.Rows[0]["next_next_do_color"].ToString();
                                }
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

                if (txtDep.Text == "302" || txtDep.Text == "322")
                {
                    xtaWork_jx xr = new xtaWork_jx() { DataSource = dtNewWork };
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreviewDialog();
                }
                else
                {
                    //xtaWorkjx xr = new xtaWorkjx() { DataSource = dtNewWork };
                    xtaWork_No_BarCode xr = new xtaWork_No_BarCode() { DataSource = dtNewWork };
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreviewDialog();
                }
            }

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

                    if (mkChkDat2.Name == strObj_id)
                    {
                        mkChkDat1.Text = strOjb_Value;
                        mkChkDat2.Text = DateTime.Now.AddSeconds(-300).ToString("yyyy/MM/dd HH:mm:ss");
                    }

                    if (mkCmpDat2.Name == strObj_id)
                    {
                        mkCmpDat1.Text = strOjb_Value;
                        //mkCmpDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    }

                    if (mkPlanDat2.Name == strObj_id)
                    {
                        mkPlanDat1.Text = strOjb_Value;
                        //mkPlanDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
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

        private void dgvDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 & e.ColumnIndex == 0)
            {
                Point p = dgvDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                //p.Offset(dgvDetails.Left, dgvDetails.Top);
                p.Offset(120, 130);
                CheckBox1.Location = p;
                CheckBox1.Size = dgvDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
                CheckBox1.Visible = true;
                CheckBox1.BringToFront();
            }
        }

        private void btnExpToExcelJx_Click(object sender, EventArgs e)
        {
            DvExportExcel("JX");
        }

        private void btnArrangeMo_Click(object sender, EventArgs e)
        {
            bool selectFlag = false;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["CheckBox"].EditedFormattedValue)
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
            List<mdlProductArrange> lsModel = new List<mdlProductArrange>();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["CheckBox"].EditedFormattedValue)
                {
                    DataGridViewRow dgr = dgvDetails.Rows[i];
                    mdlProductArrange objModel = new mdlProductArrange();
                    objModel.nowDate = System.DateTime.Now.ToString("yyyy/MM/dd");
                    objModel.prdDep = dgr.Cells["wp_id"].Value.ToString();
                    objModel.prdMo = dgr.Cells["mo_id"].Value.ToString();
                    objModel.prdVer = clsUtility.FormatNullableInt32(dgr.Cells["ver"].Value);
                    objModel.prdItem = dgr.Cells["goods_id"].Value.ToString();
                    objModel.toDep = dgr.Cells["next_wp_id"].Value.ToString();
                    objModel.arrangeSeq = "";
                    objModel.arrangeQty = Convert.ToSingle(dgr.Cells["prod_qty"].Value);
                    objModel.prdSeq = "";
                    objModel.crTim = DateTime.Now;
                    objModel.crUsr = DBUtility._user_id;
                    lsModel.Add(objModel);
                }
            }

            if (lsModel.Count > 0)
            {
                int result = clsMoStatePrint.arrangeProductMo(lsModel);
                if (result > 0)
                {
                    MessageBox.Show("生成排期表成功!");
                }
                else
                {
                    MessageBox.Show("生成排期表失敗!");
                }
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            bool selectFlag = false;
            if (checkBox2.Checked == true)
                selectFlag = true;
            for (int i = 0; i <= this.dgvDetails.RowCount - 1; i++)
            {
                this.dgvDetails.Rows[i].Cells["CheckBox"].Value = selectFlag;
                //    if ((bool)dgvDetails.Rows[i].Cells["CheckBox"].EditedFormattedValue)
                //    {
                //        this.dgvDetails.Rows[i].Cells["CheckBox"].Value = false;
                //    }
                //    else
                //    {
                //        this.dgvDetails.Rows[i].Cells["CheckBox"].Value = true;
                //    }
            }
        }


    }
}
