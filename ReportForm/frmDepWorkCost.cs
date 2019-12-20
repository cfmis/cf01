using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using cf01.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmDepWorkCost : Form
    {
        public frmDepWorkCost()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }
        private void findData()
        {
            txtPrd_dep.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();


            //**********************
            string prdDep = txtPrd_dep.Text;
            int rptType = rdgRptType.SelectedIndex;
            string prdDateFrom = txtPlanDateFrom.Text;
            string prdDateTo = txtPlanDateTo.Text;
            string strSql = "usp_DepCosting";
            SqlParameter[] parameters1 = {new SqlParameter("@rpt_type", rptType)
                        ,new SqlParameter("@Prd_dep", prdDep)
                        ,new SqlParameter("@prd_date_from", prdDateFrom)
                        ,new SqlParameter("@prd_date_to", prdDateTo)
                        };


            DataTable dtMoCost = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, parameters1);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });


            if (rptType == 0)
                DtExportExcelMoCost(dtMoCost);
            else
                DtExportExcelWorkCost(dtMoCost);

            return;

            //**********************
            string Prd_dep = txtPrd_dep.Text;
            int Report_type = rdgReportType.SelectedIndex;
            string Prd_date_from = txtPlanDateFrom.Text;
            string Prd_date_to = txtPlanDateTo.Text;
            strSql = "usp_DepWorkCost";
            SqlParameter[] parameters = {new SqlParameter("@Report_type", Report_type)
                        ,new SqlParameter("@Prd_dep", Prd_dep)
                        ,new SqlParameter("@prd_date_from", Prd_date_from)
                        ,new SqlParameter("@prd_date_to", Prd_date_to)
                        ,new SqlParameter("@mo_from", txtMoFrom.Text)
                        ,new SqlParameter("@mo_to", txtMoTo.Text)
                        };


            DataTable dtCost = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, parameters);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });


            if (Report_type == 0)
            {
                dgvSum.DataSource = dtCost;
                dgvSum.Visible = true;
                dgvDetails.Visible = false;
            }
            else if (Report_type == 1)
            {
                //dgvDetails.DataSource = dtCost;
                //dgvSum.Visible = false;
                //dgvDetails.Visible = true;

                DtExportExcel(dtCost);
            }
            else if (Report_type == 2)
                DtExportExcelMo(dtCost);
            else
                DtExportExcelMoTotal(dtCost);
        }
        private void findDataProcess()
        {
            string Prd_dep = txtPrd_dep.Text;
            int Report_type = rdgReportType.SelectedIndex;
            string Prd_date_from = txtPlanDateFrom.Text;
            string Prd_date_to = txtPlanDateTo.Text;
            string strSql = "usp_DepWorkCost";
            SqlParameter[] parameters = {new SqlParameter("@Report_type", Report_type)
                        ,new SqlParameter("@Prd_dep", Prd_dep)
                        ,new SqlParameter("@prd_date_from", Prd_date_from)
                        ,new SqlParameter("@prd_date_to", Prd_date_to)
                        ,new SqlParameter("@mo_from", txtMoFrom.Text)
                        ,new SqlParameter("@mo_to", txtMoTo.Text)
                        };


            DataTable dtCost = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, parameters);

            //if (Report_type == 0)
            //{
            //    dgvSum.DataSource = dtCost;
            //    dgvSum.Visible = true;
            //    dgvDetails.Visible = false;
            //}
            //else if (Report_type == 1)
            //{
            //    //dgvDetails.DataSource = dtCost;
            //    //dgvSum.Visible = false;
            //    //dgvDetails.Visible = true;

            //    DtExportExcel(dtCost);
            //}
            //else if (Report_type == 2)
            //    DtExportExcelMo(dtCost);
            //else
            //    DtExportExcelMoTotal(dtCost);

            //查詢操作結束，隱藏進度指示器
            progressIndicatorAbout.Stop();
            progressIndicatorAbout.Visible = false;
        }

        private void frmProductProcessCost_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            dgvSum.AutoGenerateColumns = false;
        }


        private void txtPlanDateFrom_Leave(object sender, EventArgs e)
        {
            txtPlanDateTo.Text = txtPlanDateFrom.Text;
        }

        private void txtMoFrom_Leave(object sender, EventArgs e)
        {
            txtMoTo.Text = txtMoFrom.Text;
        }

        private void btnExpToExcl_Click(object sender, EventArgs e)
        {

            //findData();

            Thread thread = new Thread(new ThreadStart(StartSomeWorkFromUIThread));
            thread.IsBackground = true;
            thread.Start();

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void StartSomeWorkFromUIThread()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new EventHandler(RunsOnWorkerThread), null);
                findDataProcess();
                
            }
            else
            {
                RunsOnWorkerThread(this, null);
            }
        }

        private void RunsOnWorkerThread(object sender, EventArgs e)
        {
            Thread.Sleep(500);

            progressIndicatorAbout.Visible = true;
            progressIndicatorAbout.Start();
            progressIndicatorAbout.CircleColor = Color.LightGreen;
            progressIndicatorAbout.Show();
        }
        /// <summary>
        /// 匯出Excel
        /// </summary>
        private void DvExportExcel()
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题
                for (int i = 0; i < dgvSum.ColumnCount; i++)
                {
                    str += dgvSum.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                    str += "\t";
                }
                sw.WriteLine(str);

                //写内容
                string col_value;

                for (int rowNo = 0; rowNo < dgvSum.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvSum.ColumnCount; columnNo++)
                    {
                        if (dgvSum.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() != null)
                        {
                            if (columnNo == 0)
                                //col_value = "=\"" + dgvSum.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() + "\"";
                                col_value = dgvSum.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                            else
                                col_value = dgvSum.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        }
                        else
                            col_value = "";
                        tempstr += col_value;
                        tempstr += "\t";
                    }
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        /// <summary>
        /// 匯出Excel按工號小計
        /// </summary>
        private void DtExportExcel(DataTable dt)
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";

                //写标题

                str = "部門";
                str += "\t"+"生產日期";
                str += "\t" + "星期";
                str += "\t" + "工號";
                str += "\t" + "制單編號";
                str += "\t" + "物料編號";
                str += "\t" + "物料描述";
                str += "\t" + "生產數量";
                str += "\t" + "生產重量";
                str += "\t" + "碑數";
                str += "\t" + "加工單價";
                str += "\t" + "基數";
                str += "\t" + "加工費用";
                str += "\t" + "生產類型";
                str += "\t" + "生產類型";
                str += "\t" + "生產機器";
                str += "\t" + "機器描述";
                str += "\t" + "每行(碑)數";
                str += "\t" + "工種";
                str += "\t" + "工種描述";
                str += "\t" + "加工費公式";
                str += "\t" + "加工費公式";
                str += "\t" + "生產開始時間";
                str += "\t" + "生產結束時間";
                str += "\t" + "正常班時數(總)";
                str += "\t" + "加班時數(總)";
                str += "\t" + "正常班時數";
                str += "\t" + "正常班數量";
                str += "\t" + "加班時數";
                str += "\t" + "加班數量";
                str += "\t" + "正常 + 加班時數";
                str += "\t" + "正常 + 加班數量";
                str += "\t" + "工號";
                str += "\t" + "假期標識";
                str += "\t" + "正常班時數";
                str += "\t" + "加班時數";
                str += "\t" + "請假時數";
                str += "\t" + "正常班工資";
                str += "\t" + "加班工資";
                str += "\t" + "正常 + 加班工資";
                str += "\t" + "標準總薪";
                str += "\t" + "每月工作天數";
                str += "\t" + "每天工作時數";
                str += "\t" + "時薪(平時)";
                str += "\t" + "時薪(節假日)";
                str += "\t" + "夜班倍數";
                str += "\t" + "平時加班倍數";
                str += "\t" + "禮拜六、日加班倍數";
                str += "\t" + "節假日加班倍數";
                str += "\t" + "薪資類型(3-包薪類不計加班費)";
                str += "\t" + "姓名";
                str += "\t" + "職位";
                str += "\t" + "員工類別";
                str += "\t" + "部門描述";
                sw.WriteLine(str);

                //写内容

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tempstr = " ";
                    DataRow dr = dt.Rows[i];
                    tempstr = "=\"" + dr["Prd_dep1"].ToString() + "\"";
                    tempstr += "\t" + "=\"" + dr["Prd_date1"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_weekday"].ToString();
                    tempstr += "\t" + "=\"" + dr["Prd_worker1"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_mo"].ToString();
                    tempstr += "\t" + dr["Prd_item"].ToString();
                    tempstr += "\t" + dr["Prd_item_cdesc"].ToString();
                    tempstr += "\t" + dr["Prd_qty"].ToString();
                    tempstr += "\t" + dr["Prd_weg"].ToString();
                    tempstr += "\t" + dr["Prd_run_qty"].ToString();
                    tempstr += "\t" + dr["Cost_price"].ToString();
                    tempstr += "\t" + dr["Product_qty"].ToString();
                    tempstr += "\t" + dr["Prd_item_cost"].ToString();
                    tempstr += "\t" + dr["Prd_work_type"].ToString();
                    tempstr += "\t" + dr["Work_type_desc"].ToString();
                    tempstr += "\t" + dr["Prd_machine"].ToString();
                    tempstr += "\t" + dr["Machine_desc"].ToString();
                    tempstr += "\t" + dr["Line_num"].ToString();
                    tempstr += "\t" + dr["Job_type"].ToString();
                    tempstr += "\t" + dr["Job_desc"].ToString();
                    tempstr += "\t" + dr["Process_id"].ToString();
                    tempstr += "\t" + dr["Process_name"].ToString();
                    tempstr += "\t" + dr["Prd_start_time"].ToString();
                    tempstr += "\t" + dr["Prd_end_time"].ToString();
                    tempstr += "\t" + dr["Prd_normal_time"].ToString();
                    tempstr += "\t" + dr["Prd_ot_time"].ToString();
                    tempstr += "\t" + dr["Nl_time"].ToString();
                    tempstr += "\t" + dr["Nl_qty"].ToString();
                    tempstr += "\t" + dr["Ot_time"].ToString();
                    tempstr += "\t" + dr["Ot_qty"].ToString();
                    tempstr += "\t" + dr["Wk_time"].ToString();
                    tempstr += "\t" + dr["Wk_qty"].ToString();
                    tempstr += "\t" + "=\"" + dr["hrt2wid"].ToString() + "\"";
                    tempstr += "\t" + dr["hrt2wdat"].ToString();
                    tempstr += "\t" + dr["hrt2wh"].ToString();
                    tempstr += "\t" + dr["sot"].ToString();
                    tempstr += "\t" + dr["hrt8leave"].ToString();
                    tempstr += "\t" + dr["day_fee"].ToString();
                    tempstr += "\t" + dr["ot_fee"].ToString();
                    tempstr += "\t" + dr["tot_fee"].ToString();
                    tempstr += "\t" + dr["pay1bsalary"].ToString();
                    tempstr += "\t" + dr["pay1smonth"].ToString();
                    tempstr += "\t" + dr["pay1sday"].ToString();
                    tempstr += "\t" + dr["ot_pay1"].ToString();
                    tempstr += "\t" + dr["ot_pay2"].ToString();
                    tempstr += "\t" + dr["pay1db1"].ToString();
                    tempstr += "\t" + dr["pay1db2"].ToString();
                    tempstr += "\t" + dr["pay1db3"].ToString();
                    tempstr += "\t" + dr["pay1db4"].ToString();
                    tempstr += "\t" + dr["pay1pke"].ToString();
                    tempstr += "\t" + dr["Prd_worker_name"].ToString();
                    tempstr += "\t" + dr["hrc5name"].ToString();
                    tempstr += "\t" + dr["hrm1corp"].ToString();
                    tempstr += "\t" + dr["Prd_dep_cdesc"].ToString();
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        /// <summary>
        /// 匯出Excel按制單編號小計
        /// </summary>
        private void DtExportExcelMo(DataTable dt)
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";

                //写标题

                str = "部門";
                str += "\t" + "生產日期";
                str += "\t" + "星期";
                str += "\t" + "工號";
                str += "\t" + "制單編號";
                str += "\t" + "物料編號";
                str += "\t" + "物料描述";
                str += "\t" + "生產數量";
                str += "\t" + "生產重量";
                str += "\t" + "碑數";
                str += "\t" + "加工單價";
                str += "\t" + "基數";
                str += "\t" + "加工費用";
                str += "\t" + "生產類型";
                str += "\t" + "生產類型";
                str += "\t" + "生產機器";
                str += "\t" + "機器描述";
                str += "\t" + "每行(碑)數";
                str += "\t" + "工種";
                str += "\t" + "工種描述";
                str += "\t" + "加工費公式";
                str += "\t" + "加工費公式";
                str += "\t" + "生產開始時間";
                str += "\t" + "生產結束時間";
                str += "\t" + "正常班時數(總)";
                str += "\t" + "加班時數(總)";
                str += "\t" + "正常班時數";
                str += "\t" + "正常班數量";
                str += "\t" + "加班時數";
                str += "\t" + "加班數量";
                str += "\t" + "正常 + 加班時數";
                str += "\t" + "正常 + 加班數量";
                str += "\t" + "每小時工資(員工工資/總生產時間)";
                str += "\t" + "生產工資(生產時間*每小時工資(員工工資/總生產時間))";
                str += "\t" + "校模工資平均到制單";
                str += "\t" + "文員工資平均到制單";
                str += "\t" + "(生產 + 校模+文員)工資";
                str += "\t" + "校模技工總薪";
                str += "\t" + "文員(班長、主管等)總薪";
                str += "\t" + "生產制單單數";
                str += "\t" + "正常班時數(考勤)";
                str += "\t" + "正常班工資(考勤)";
                str += "\t" + "加班班時數(考勤)";
                str += "\t" + "加班工資(考勤)";
                str += "\t" + "正常+加班時數(考勤)";
                str += "\t" + "正常+加班工資(考勤)";
                str += "\t" + "員工累計生產時數";
                str += "\t" + "部門合計數量";
                str += "\t" + "部門合計工資";
                str += "\t" + "部門每PCS工資";
                str += "\t" + "訂單金額(HKD)";
                str += "\t" + "姓名";
                str += "\t" + "職位";
                str += "\t" + "員工類別";
                str += "\t" + "部門描述";
                str += "\t" + "查詢日期記錄";
                sw.WriteLine(str);

                //写内容

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tempstr = " ";
                    DataRow dr = dt.Rows[i];
                    tempstr = "=\"" + dr["Prd_dep"].ToString() + "\"";
                    tempstr += "\t" + "=\"" + dr["Prd_date"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_weekday"].ToString();
                    tempstr += "\t" + "=\"" + dr["Prd_worker"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_mo"].ToString();
                    tempstr += "\t" + dr["Prd_item"].ToString();
                    tempstr += "\t" + dr["Prd_item_cdesc"].ToString();
                    tempstr += "\t" + dr["Prd_qty"].ToString();
                    tempstr += "\t" + dr["Prd_weg"].ToString();
                    tempstr += "\t" + dr["Prd_run_qty"].ToString();
                    tempstr += "\t" + dr["Cost_price"].ToString();
                    tempstr += "\t" + dr["Product_qty"].ToString();
                    tempstr += "\t" + dr["Prd_item_cost"].ToString();
                    tempstr += "\t" + dr["Prd_work_type"].ToString();
                    tempstr += "\t" + dr["Work_type_desc"].ToString();
                    tempstr += "\t" + dr["Prd_machine"].ToString();
                    tempstr += "\t" + dr["Machine_desc"].ToString();
                    tempstr += "\t" + dr["Line_num"].ToString();
                    tempstr += "\t" + dr["Job_type"].ToString();
                    tempstr += "\t" + dr["Job_desc"].ToString();
                    tempstr += "\t" + dr["Process_id"].ToString();
                    tempstr += "\t" + dr["Process_name"].ToString();
                    tempstr += "\t" + dr["Prd_start_time"].ToString();
                    tempstr += "\t" + dr["Prd_end_time"].ToString();
                    tempstr += "\t" + dr["Prd_normal_time"].ToString();
                    tempstr += "\t" + dr["Prd_ot_time"].ToString();
                    tempstr += "\t" + dr["Nl_time"].ToString();
                    tempstr += "\t" + dr["Nl_qty"].ToString();
                    tempstr += "\t" + dr["Ot_time"].ToString();
                    tempstr += "\t" + dr["Ot_qty"].ToString();
                    tempstr += "\t" + dr["Wk_time"].ToString();
                    tempstr += "\t" + dr["Wk_qty"].ToString();
                    tempstr += "\t" + dr["hour_fee"].ToString();
                    tempstr += "\t" + dr["Worker_pay"].ToString();
                    tempstr += "\t" + dr["day_avg_check_fee"].ToString();
                    tempstr += "\t" + dr["day_avg_clerk_fee"].ToString();
                    tempstr += "\t" + dr["prd_check_clerk_fee"].ToString();
                    tempstr += "\t" + dr["day_tot_check_fee"].ToString();
                    tempstr += "\t" + dr["day_tot_clerk_fee"].ToString();
                    tempstr += "\t" + dr["Prd_mo_count"].ToString();
                    tempstr += "\t" + dr["day_nl_time"].ToString();
                    tempstr += "\t" + dr["day_nl_fee"].ToString();
                    tempstr += "\t" + dr["day_ot_time"].ToString();
                    tempstr += "\t" + dr["day_ot_fee"].ToString();
                    tempstr += "\t" + dr["day_tot_time"].ToString();
                    tempstr += "\t" + dr["day_fee"].ToString();
                    tempstr += "\t" + dr["Wk_time_worker"].ToString();
                    tempstr += "\t" + dr["day_prd_qty"].ToString();
                    tempstr += "\t" + dr["day_tot_pay"].ToString();
                    tempstr += "\t" + dr["qty_avg_price"].ToString();
                    tempstr += "\t" + dr["order_amt_hkd"].ToString();
                    tempstr += "\t" + dr["Prd_worker_name"].ToString();
                    tempstr += "\t" + dr["hrc5name"].ToString();
                    tempstr += "\t" + dr["hrm1corp"].ToString();
                    tempstr += "\t" + dr["Prd_dep_cdesc"].ToString();
                    tempstr += "\t" + dr["period_flag"].ToString();
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }


        /// <summary>
        /// 匯出Excel按制單編號匯總
        /// </summary>
        private void DtExportExcelMoTotal(DataTable dt)
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";

                //写标题
                str += "部門";
                str += "\t" + "制單編號";
                str += "\t" + "生產日期";
                str += "\t" + "生產數量";
                str += "\t" + "生產重量";
                str += "\t" + "碑數";
                str += "\t" + "加工費用";
                str += "\t" + "正常班時數(總)";
                str += "\t" + "加班時數(總)";
                str += "\t" + "正常班時數";
                str += "\t" + "正常班數量";
                str += "\t" + "加班時數";
                str += "\t" + "加班數量";
                str += "\t" + "正常 + 加班時數";
                str += "\t" + "正常 + 加班數量";
                str += "\t" + "生產工資(生產時間*每小時工資(員工工資/總生產時間))";
                str += "\t" + "校模工資平均到制單";
                str += "\t" + "文員工資平均到制單";
                str += "\t" + "(生產 + 校模+文員)工資";
                //str += "\t" + "生產制單單數";
                //str += "\t" + "校模技工總薪";
                //str += "\t" + "文員(班長、主管等)總薪";
                str += "\t" + "訂單金額(HKD)";
                str += "\t" + "部門描述";
                sw.WriteLine(str);

                //写内容

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tempstr = " ";
                    DataRow dr = dt.Rows[i];
                    tempstr = "=\"" + dr["Prd_dep"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_mo"].ToString();
                    tempstr += "\t" + "=\"" + dr["Prd_date"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_qty"].ToString();
                    tempstr += "\t" + dr["Prd_weg"].ToString();
                    tempstr += "\t" + dr["Prd_run_qty"].ToString();
                    tempstr += "\t" + dr["Prd_item_cost"].ToString();
                    tempstr += "\t" + dr["Prd_normal_time"].ToString();
                    tempstr += "\t" + dr["Prd_ot_time"].ToString();
                    tempstr += "\t" + dr["Nl_time"].ToString();
                    tempstr += "\t" + dr["Nl_qty"].ToString();
                    tempstr += "\t" + dr["Ot_time"].ToString();
                    tempstr += "\t" + dr["Ot_qty"].ToString();
                    tempstr += "\t" + dr["Wk_time"].ToString();
                    tempstr += "\t" + dr["Wk_qty"].ToString();
                    tempstr += "\t" + dr["Worker_pay"].ToString();
                    tempstr += "\t" + dr["day_avg_check_fee"].ToString();
                    tempstr += "\t" + dr["day_avg_clerk_fee"].ToString();
                    tempstr += "\t" + dr["prd_check_clerk_fee"].ToString();
                    //tempstr += "\t" + dr["Prd_mo_count"].ToString();
                    //tempstr += "\t" + dr["day_tot_check_fee"].ToString();
                    //tempstr += "\t" + dr["day_tot_clerk_fee"].ToString();
                    tempstr += "\t" + dr["order_amt_hkd"].ToString();
                    tempstr += "\t" + dr["Prd_dep_cdesc"].ToString();
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
            }
            else
            {
            }
        }

        /// <summary>
        /// 匯出Excel按制單編號小計
        /// </summary>
        private void DtExportExcelMoCost(DataTable dt)
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";

                //写标题
                str = "部門";
                str += "\t" + "生產日期";
                str += "\t" + "星期";
                str += "\t" + "工號";
                str += "\t" + "姓名";
                str += "\t" + "制單編號";
                str += "\t" + "物料編號";
                str += "\t" + "物料描述";
                str += "\t" + "生產數量";
                str += "\t" + "加工費用(由部門定价)";
                str += "\t" + "單價(由工人工資)";
                str += "\t" + "加工費用(由工人工資)";
                str += "\t" + "單價(由文員工資)";
                str += "\t" + "加工費用(由文員工資)";
                str += "\t" + "合計費用(由工人+文員工資)";
                str += "\t" + "部門定价";
                str += "\t" + "基數";
                str += "\t" + "部門工人總工資";
                str += "\t" + "部門工人總數量";
                str += "\t" + "部門工人總單數";
                str += "\t" + "部門文員總工資";
                str += "\t" + "部門文員總數量";
                str += "\t" + "部門文員總單數";
                str += "\t" + "生產類型";
                str += "\t" + "生產類型描述";
                str += "\t" + "生產機器";
                str += "\t" + "機器描述";
                str += "\t" + "生產重量";
                str += "\t" + "生產碑數";
                str += "\t" + "生產開始時間";
                str += "\t" + "生產結束時間";
                str += "\t" + "正常班時數";
                str += "\t" + "正常班數量";
                str += "\t" + "加班時數";
                str += "\t" + "加班數量";
                str += "\t" + "工種";
                str += "\t" + "工種描述";
                str += "\t" + "加工費公式";
                str += "\t" + "加工費公式";
                str += "\t" + "組別";
                str += "\t" + "員工類別";
                str += "\t" + "正常班時數(考勤)";
                str += "\t" + "請假時數(考勤)";
                str += "\t" + "正常班工資";
                str += "\t" + "加班時數(考勤)";
                str += "\t" + "加班工資(考勤)";
                str += "\t" + "合計工資(考勤)";
                str += "\t" + "標準總薪";
                str += "\t" + "生效月份";
                str += "\t" + "月份天數";
                str += "\t" + "標準小時";
                str += "\t" + "正常班小時工資";
                str += "\t" + "加班小時工資";
                str += "\t" + "倍數1";
                str += "\t" + "倍數2";
                str += "\t" + "倍數3";
                str += "\t" + "倍數4";
                str += "\t" + "包薪";
                str += "\t" + "部門描述";
                
                sw.WriteLine(str);

                //写内容

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tempstr = " ";
                    DataRow dr = dt.Rows[i];
                    tempstr = "=\"" + dr["Prd_dep"].ToString() + "\"";
                    tempstr += "\t" + "=\"" + dr["Prd_date"].ToString() + "\"";
                    tempstr += "\t" + dr["Prd_weekday"].ToString();
                    tempstr += "\t" + "=\"" + dr["Prd_worker"].ToString() + "\"";
                    tempstr += "\t" + dr["hrm1name"].ToString();
                    tempstr += "\t" + dr["Prd_mo"].ToString();
                    tempstr += "\t" + dr["Prd_item"].ToString();
                    tempstr += "\t" + dr["Prd_item_cdesc"].ToString();
                    tempstr += "\t" + dr["Prd_qty"].ToString();
                    tempstr += "\t" + dr["Prd_item_cost"].ToString();
                    tempstr += "\t" + dr["Prd_qty_avg_price"].ToString();
                    tempstr += "\t" + dr["Prd_mo_fee"].ToString();
                    tempstr += "\t" + dr["Prd_qty_avg_price1"].ToString();
                    tempstr += "\t" + dr["Prd_mo_fee1"].ToString();
                    tempstr += "\t" + dr["Prd_mo_fee_t"].ToString();
                    tempstr += "\t" + dr["Cost_price"].ToString();
                    tempstr += "\t" + dr["Product_qty"].ToString();
                    tempstr += "\t" + dr["Dep_day_tot_fee"].ToString();
                    tempstr += "\t" + dr["Prd_qty_day_tot"].ToString();
                    tempstr += "\t" + dr["Prd_mo_no"].ToString();
                    tempstr += "\t" + dr["Dep_day_tot_fee1"].ToString();
                    tempstr += "\t" + dr["Prd_qty_day_tot1"].ToString();
                    tempstr += "\t" + dr["Prd_mo_no1"].ToString();
                    tempstr += "\t" + dr["Prd_work_type"].ToString();
                    tempstr += "\t" + dr["Work_type_desc"].ToString();
                    tempstr += "\t" + dr["Prd_machine"].ToString();
                    tempstr += "\t" + dr["Machine_desc"].ToString();
                    tempstr += "\t" + dr["Prd_weg"].ToString();
                    tempstr += "\t" + dr["Prd_run_qty"].ToString();
                    tempstr += "\t" + dr["Prd_start_time"].ToString();
                    tempstr += "\t" + dr["Prd_end_time"].ToString();
                    tempstr += "\t" + dr["Nl_time"].ToString();
                    tempstr += "\t" + dr["Nl_qty"].ToString();
                    tempstr += "\t" + dr["Ot_time"].ToString();
                    tempstr += "\t" + dr["Ot_qty"].ToString();
                    tempstr += "\t" + dr["Job_type"].ToString();
                    tempstr += "\t" + dr["Job_desc"].ToString();
                    tempstr += "\t" + dr["Process_id"].ToString();
                    tempstr += "\t" + dr["Process_name"].ToString();
                    tempstr += "\t" + dr["Prd_group"].ToString();
                    tempstr += "\t" + dr["hrm1corp"].ToString();
                    tempstr += "\t" + dr["hrt2wh"].ToString();
                    tempstr += "\t" + dr["hrt8leave"].ToString();
                    tempstr += "\t" + dr["day_fee"].ToString();
                    tempstr += "\t" + dr["sot"].ToString();
                    tempstr += "\t" + dr["ot_fee"].ToString();
                    tempstr += "\t" + dr["day_tot_fee"].ToString();
                    tempstr += "\t" + dr["pay1bsalary"].ToString();
                    tempstr += "\t" + dr["pay1month"].ToString();
                    tempstr += "\t" + dr["pay1smonth"].ToString();
                    tempstr += "\t" + dr["pay1sday"].ToString();
                    tempstr += "\t" + dr["ot_pay1"].ToString();
                    tempstr += "\t" + dr["ot_pay2"].ToString();
                    tempstr += "\t" + dr["pay1db1"].ToString();
                    tempstr += "\t" + dr["pay1db2"].ToString();
                    tempstr += "\t" + dr["pay1db3"].ToString();
                    tempstr += "\t" + dr["pay1db4"].ToString();
                    tempstr += "\t" + dr["pay1pke"].ToString();
                    tempstr += "\t" + dr["dep_cdesc"].ToString();
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }


        /// <summary>
        /// 匯出Excel按制單編號小計
        /// </summary>
        private void DtExportExcelWorkCost(DataTable dt)
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";

                //写标题
                str = "生產部門";
                str += "\t" + "部門描述";
                str += "\t" + "上班日期";
                str += "\t" + "星期";
                str += "\t" + "假期標識";
                str += "\t" + "工號";
                str += "\t" + "姓名";
                str += "\t" + "上班時數";
                str += "\t" + "請假時數";
                str += "\t" + "正常班工資";
                str += "\t" + "加班時數1";
                str += "\t" + "加班工資1";
                str += "\t" + "加班時數2";
                str += "\t" + "加班工資2";
                str += "\t" + "正常+加班工資";
                str += "\t" + "部門合計生產數量";
                str += "\t" + "部門合計生產單數";
                str += "\t" + "標準總薪";
                str += "\t" + "生效月份";
                str += "\t" + "月份工作天數";
                str += "\t" + "每天上班小時";
                str += "\t" + "小時工資";
                str += "\t" + "小時加班工資";
                str += "\t" + "倍數1";
                str += "\t" + "倍數2";
                str += "\t" + "倍數3";
                str += "\t" + "倍數4";
                str += "\t" + "包薪";
                str += "\t" + "職位描述";
                str += "\t" + "考勤部門";
                str += "\t" + "部門描述";

                sw.WriteLine(str);

                //写内容

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tempstr = " ";
                    DataRow dr = dt.Rows[i];
                    tempstr = "=\"" + dr["Prd_dep"].ToString() + "\"";
                    tempstr += "\t" + dr["Dep_cdesc"].ToString();
                    tempstr += "\t" + "=\"" + dr["hrt2fdat"].ToString() + "\"";
                    tempstr += "\t" + dr["hrt2weekday"].ToString();
                    tempstr += "\t" + dr["hrt2wdat"].ToString();
                    tempstr += "\t" + "=\"" + dr["hrt2wid"].ToString() + "\"";
                    tempstr += "\t" + dr["hrm1name"].ToString();
                    tempstr += "\t" + dr["hrt2wh"].ToString();
                    tempstr += "\t" + dr["hrt8leave"].ToString();
                    tempstr += "\t" + dr["day_fee"].ToString();
                    tempstr += "\t" + dr["sot1"].ToString();
                    tempstr += "\t" + dr["ot_fee1"].ToString();
                    tempstr += "\t" + dr["sot2"].ToString();
                    tempstr += "\t" + dr["ot_fee2"].ToString();
                    tempstr += "\t" + dr["day_tot_fee"].ToString();
                    tempstr += "\t" + dr["day_prd_qty"].ToString();
                    tempstr += "\t" + dr["prd_mo_no"].ToString();
                    tempstr += "\t" + dr["pay1bsalary"].ToString();
                    tempstr += "\t" + dr["pay1month"].ToString();
                    tempstr += "\t" + dr["pay1smonth"].ToString();
                    tempstr += "\t" + dr["pay1sday"].ToString();
                    tempstr += "\t" + dr["ot_pay1"].ToString();
                    tempstr += "\t" + dr["ot_pay2"].ToString();
                    tempstr += "\t" + dr["pay1db1"].ToString();
                    tempstr += "\t" + dr["pay1db2"].ToString();
                    tempstr += "\t" + dr["pay1db3"].ToString();
                    tempstr += "\t" + dr["pay1db4"].ToString();
                    tempstr += "\t" + dr["pay1pke"].ToString();
                    tempstr += "\t" + dr["hrc5name"].ToString();
                    tempstr += "\t" + dr["hrm1stat2"].ToString();
                    tempstr += "\t" + dr["hrc4name"].ToString();
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }


    }
}
