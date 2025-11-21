using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using cf01.Forms;
using cf01.CLS;
using cf01.ModuleClass;

namespace cf01.ReportForm
{
    public partial class frmPlan01 : Form
    {
        public frmPlan01()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
            CheckForIllegalCrossThreadCalls = false;
        }
      
        
        System.Data.DataTable dt1, dt2;
        clsCommonUse commUse = new clsCommonUse();

        string lang_id = DBUtility._language;

        private void frmPlan01_Load(object sender, EventArgs e)
        {
            
            mkCmpDat1.Text = DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
            mkCmpDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");

            progressIndicatorAbout.Visible = false;

            //綁定表格
            commUse.BuilDataGridView(dgvDetails, "frmPlan01_grid", lang_id);
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            dgvDetails.Refresh();
            //增加圖片列
            //DataGridViewImageColumn colImage = new DataGridViewImageColumn();
            //colImage.HeaderText = "圖片";
            //colImage.Name = "colImage";
            //colImage.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dgvDetails.Columns.Add(colImage);

            //mkDat1.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"); 
            //datCmp1.Value = datCmp1.Value.AddDays(-90);
            //datChk1.Value = datChk1.Value.AddDays(-90);
            //datPlan1.Value = datPlan1.Value.AddDays(-90);


            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "frmPlan01_rpt_type" + "'" +
                    " AND language_id =" + "'" + lang_id + "'" + " Order By tb_col_sort";
            commUse.BindComboBox(cmbReportType, "formname", "show_name", strsql, "v_dict_group");

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            if (clsValidRule.CheckDateIsEmpty(this.mkCmpDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkCmpDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mkCmpDat1.Text) == false || clsValidRule.CheckDateFormat(this.mkCmpDat2.Text) == false)
                {
                    MessageBox.Show("要求完成日期格式不正確!");
                    this.mkCmpDat1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.mkPlanDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkPlanDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mkPlanDat1.Text) == false || clsValidRule.CheckDateFormat(this.mkPlanDat2.Text) == false)
                {
                    MessageBox.Show("計劃單日期格式不正確!");
                    this.mkPlanDat1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.mkChkDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkChkDat2.Text) == false)
            {
                if (clsValidRule.CheckDateTimeFormat(this.mkChkDat1.Text) == false || clsValidRule.CheckDateTimeFormat(this.mkChkDat2.Text) == false)
                {
                    MessageBox.Show("批準日期格式不正確!");
                    this.mkChkDat1.Focus();
                    return;
                }
            }
            if (chkArrange.Checked == true)
            {
                if (clsValidRule.CheckDateFormat(this.mkOldArrangeDate.Text) == false)
                {
                    MessageBox.Show("最近一次排期日期格式不正確!");
                    mkOldArrangeDate.Focus();
                    return;
                }
            }

            //new System.Threading.Thread(new System.Threading.ThreadStart(invokeThread)).Start();
            //return;
            Thread thread = new Thread(new ThreadStart(StartSomeWorkFromUIThread));
            thread.IsBackground = true;
            thread.Start();
            
        }


        // 使用invoke方法
        public delegate void dTest();
        void invokeThread()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();
            //for (int i = 0; i < 100; i++)
            //{
                if (this.InvokeRequired)
                {
                    //this.Invoke(new dTest(test));
                BeginInvoke(new EventHandler(RunsOnWorkerThread), null);

                find_data();
            }
                else
                {
                    test();
                }
                System.Threading.Thread.Sleep(10);
            //}
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        // 模拟一个实际应用
        // 对label1付值后立马检查他的值,如果已经被改过则抛出异常

        void test()
        {
            string strText = Guid.NewGuid().ToString();
            this.label1.Text = strText;
            if (this.label1.Text != strText)
            {
                // 测试性能时把这一句注释掉！！！！！！！！！！！！！！！！！！！！！！1
                throw new Exception(" label1的值意外改变 ");
            }
        } 

        private void find_data()
        {
            dgvDetails.DataSource = null;
            dgvDetails.Refresh();
            string pdat1, pdat2, cdat1, cdat2, chkdat1, chkdat2;
            int f_type;
            int show_ver = 2;
            int zero_qty = 0;
            int isprint = 0;
            int sp_rpt_type = 0;
            string old_arrange_date = "";
            if (clsValidRule.CheckDateIsEmpty(this.mkCmpDat1.Text) == false)
                cdat1 = this.mkCmpDat1.Text;
            else
                cdat1 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mkCmpDat2.Text) == false)
                cdat2 = this.mkCmpDat2.Text;
            else
                cdat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mkPlanDat1.Text) == false)
                pdat1 = this.mkPlanDat1.Text;
            else
                pdat1 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mkPlanDat2.Text) == false)
                pdat2 = this.mkPlanDat2.Text;
            else
                pdat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mkChkDat1.Text) == false)
                chkdat1 = this.mkChkDat1.Text;
            else
                chkdat1 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mkChkDat2.Text) == false)
                chkdat2 = this.mkChkDat2.Text;
            else
                chkdat2 = "";
            if (cmbReportType.SelectedIndex == -1 || cmbReportType.SelectedItem.ToString() == "")
                f_type = 1;
            else
                f_type = cmbReportType.SelectedIndex + 1;
            if (chkReqPrdQty.Checked == true)//若包含生產數為零的記錄
                zero_qty = 1;
            if (rdbNoPrint.Checked == true)//不包含已列印的記錄
                isprint = 0;
            if (rdbIsPrint.Checked == true)//只包含已列印的記錄
                isprint = 1;
            if (rdbAllPrint.Checked == true)//包含已列印的記錄
                isprint = 2;
            if (chkArrange.Checked == true)
            {
                sp_rpt_type = 1;
                old_arrange_date = mkOldArrangeDate.Text;
            }//usp_plan01
            dt1 = commUse.getDataProcedure("usp_LoadDepPlan",
                new object[] { f_type,show_ver,isprint, "DG", txtDep.Text,txtTdep.Text, cdat1, cdat2, pdat1, pdat2, chkdat1, chkdat2, txtMo1.Text, txtMo2.Text
                    ,txtPrd_item1.Text,txtPrd_item2.Text,zero_qty,sp_rpt_type,old_arrange_date});

            if (sp_rpt_type == 1)//生成排期表
            {
                

                //查詢操作結束，隱藏進度指示器
                progressIndicatorAbout.Stop();
                progressIndicatorAbout.Visible = false;
                MessageBox.Show("排期記錄已完成查找!");
                //ExpArrangeData();
                
                return;
            }
            this.dgvDetails.DataSource = dt1;


            // this.reportViewer1.LocalReport.DataSources.Clear();
            // this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt1));

            //向報表傳遞單個參數
            //ReportParameter rp = new ReportParameter("chk_dat2", this.mkChkDat2.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });

            //向報表傳遞多個參數

            //List<ReportParameter> parameterList = new List<ReportParameter>();
            //parameterList.Add(new ReportParameter("chk_dat1", this.mkChkDat1.Text));
            //parameterList.Add(new ReportParameter("chk_dat2", this.mkChkDat2.Text));
            //this.reportViewer1.LocalReport.SetParameters(parameterList);

            ////显示报表
            //this.reportViewer1.RefreshReport();
            if (chkSimplePlan.Checked == true)
            {
                this.showSimplePlan();
            }

            //查詢操作結束，隱藏進度指示器
            progressIndicatorAbout.Stop();
            progressIndicatorAbout.Visible = false;

        }

        private void StartSomeWorkFromUIThread()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new EventHandler(RunsOnWorkerThread), null);
                
                find_data();
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

        private void txtMo1_Leave(object sender, EventArgs e)
        {
            txtMo2.Text = txtMo1.Text;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private bool ValidateDateType()
        {
            if (!clsUtility.CheckDate(mkChkDat1.Text.Trim()))
            {
                mkChkDat1.Focus();
                mkChkDat1.SelectAll();
                return false;
            }

            //if (!clsPublic.CheckDate(mkChkDat2.Text.Trim()))
            //{
            //    mkChkDat2.Focus();
            //    mkChkDat2.SelectAll();
            //    return false;
            //}
            //if (!clsPublic.CheckDate(mkCmpDat1.Text.Trim()))
            //{
            //    mkCmpDat1.Focus();
            //    mkCmpDat1.SelectAll();
            //    return false;
            //}

            //if (!clsPublic.CheckDate(mkCmpDat2.Text.Trim()))
            //{
            //    mkCmpDat2.Focus();
            //    mkCmpDat2.SelectAll();
            //    return false;
            //}
            return true;
        }

        private void mkPlanDat1_Leave(object sender, EventArgs e)
        {
            mkPlanDat2.Text = mkPlanDat1.Text;
        }


        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedIndex == 0)
            {
                mkChkDat1.Text = "";
                mkChkDat2.Text = "";
                mkCmpDat1.Text = DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
                mkCmpDat2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
            else
            {
                mkChkDat1.Text = DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd") + " 00:00";
                mkChkDat2.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                mkCmpDat1.Text = "";
                mkCmpDat2.Text = "";
            }
        }

        private void tsBtnExportToExce_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

        private void SaveToExcel(DataGridView _dgv, BackgroundWorker _worker)
        {
            string fileNameString = ExpToExcel.GetFileName(_dgv);
            if (fileNameString == "" || fileNameString == null)
            {
                return;
            }

            int rowscount = _dgv.Rows.Count;
            int colscount = 13;//Excel表格總欄數 _dgv.Columns.Count;
            int intValue = 0;
            string cur_id_seq, per_id_seq;

            string RangeName, PicturePath;
            object m_objOpt = System.Reflection.Missing.Value;

            //创建空EXCEL对象
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objSheet1 = null;
            Microsoft.Office.Interop.Excel.Worksheet objSheet2 = null;
            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.Worksheets[1];//强制类型转换
                objSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.Worksheets[2];
                //设置EXCEL不可见(后台运行)   
                objExcel.Visible = false;

                //向工作表Sheet1中写入表格的表头   
                objSheet1.Cells[1, 1] = "序號";
                objSheet1.Cells[1, 2] = "收貨部門";
                objSheet1.Cells[1, 3] = "上部門來貨期";
                objSheet1.Cells[1, 4] = "狀態";
                objSheet1.Cells[1, 5] = "制單編號";
                objSheet1.Cells[1, 6] = "產品編號";
                objSheet1.Cells[1, 7] = "產品描述";
                objSheet1.Cells[1, 8] = "圖片";
                objSheet1.Cells[1, 9] = "應生產數量";
                objSheet1.Cells[1, 10] = "已完成數量";
                objSheet1.Cells[1, 11] = "回覆";
                objSheet1.Cells[1, 12] = "備註";
                objSheet1.Cells[1, 13] = "計劃回港日期";

                //向工作表Sheet2中写入表格的表头   
                objSheet2.Cells[1, 1] = "序號";
                objSheet2.Cells[1, 2] = "收貨部門";
                objSheet2.Cells[1, 3] = "上部門來貨期";
                objSheet2.Cells[1, 4] = "狀態";
                objSheet2.Cells[1, 5] = "制單編號";
                objSheet2.Cells[1, 6] = "產品編號";
                objSheet2.Cells[1, 7] = "產品描述";
                objSheet2.Cells[1, 8] = "圖片";
                objSheet2.Cells[1, 9] = "應生產數量";
                objSheet2.Cells[1, 10] = "已完成數量";
                objSheet2.Cells[1, 11] = "回覆";
                objSheet2.Cells[1, 12] = "備註";
                objSheet2.Cells[1, 13] = "計劃回港日期";

                //設置工作表Sheet1行的字體
                Microsoft.Office.Interop.Excel.Range rg1 = (Microsoft.Office.Interop.Excel.Range)
                        objSheet1.Range[objSheet1.Cells[1, 1], objSheet1.Cells[1, colscount]];
                rg1.Font.Bold = true;
                rg1.Font.Size = 10;

                //設置工作表Sheet2行的字體
                Microsoft.Office.Interop.Excel.Range rg2 = (Microsoft.Office.Interop.Excel.Range)
                        objSheet2.Range[objSheet2.Cells[1, 1], objSheet2.Cells[1, colscount]];
                rg2.Font.Bold = true;
                rg2.Font.Size = 10;

                int Sheet1_row = 2;//寫入Excel開始的行數
                int Sheet2_row = 2;
                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= _dgv.RowCount - 1; row++)
                {
                    //cur_id_seq 當前記錄；per_id_seq 前一筆記錄，用來判斷是否重複
                    cur_id_seq = _dgv.Rows[row].Cells[39].Value.ToString().Trim();
                    if (row == 0)
                        per_id_seq = "";
                    else
                        per_id_seq = _dgv.Rows[row - 1].Cells[39].Value.ToString().Trim();
                    if (cur_id_seq != per_id_seq)//去掉重複的記錄
                    {
                        if (_dgv.Rows[row].Cells[1].Value.ToString().Trim().Substring(0, 1) == "S" || _dgv.Rows[row].Cells[1].Value.ToString().Trim().Substring(0, 1) == "N")
                        {
                            Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)
                                objSheet2.Range[objSheet2.Cells[Sheet2_row, 1], objSheet2.Cells[Sheet2_row, colscount]];
                            //rg.Font.Bold = true;
                            rg.Font.Size = 10;
                            rg.RowHeight = 61;

                            objSheet2.Cells[Sheet2_row, 1] = (Sheet2_row - 1).ToString();//序號
                            objSheet2.Cells[Sheet2_row, 2] = _dgv.Rows[row].Cells[5].Value.ToString().Trim();//收貨部門
                            if (_dgv.Rows[row].Cells[13].Value.ToString().Trim() != "")
                                objSheet2.Cells[Sheet2_row, 3] = _dgv.Rows[row].Cells[13].Value.ToString().Trim().Substring(5, 5);//上部門最大交貨期
                            objSheet2.Cells[Sheet2_row, 4] = _dgv.Rows[row].Cells[37].Value.ToString().Trim();//制單要求狀態
                            objSheet2.Cells[Sheet2_row, 5] = _dgv.Rows[row].Cells[1].Value.ToString().Trim();//制單編號
                            objSheet2.Cells[Sheet2_row, 6] = _dgv.Rows[row].Cells[3].Value.ToString().Trim();//物料編號
                            objSheet2.Cells[Sheet2_row, 7] = _dgv.Rows[row].Cells[4].Value.ToString().Trim();//物料描述
                            objSheet2.Cells[Sheet2_row, 9] = _dgv.Rows[row].Cells[6].Value.ToString().Trim();//生產數量
                            objSheet2.Cells[Sheet2_row, 10] = _dgv.Rows[row].Cells[8].Value.ToString().Trim();//完成數量
                            if (_dgv.Rows[row].Cells[36].Value.ToString().Trim() != "")
                                objSheet2.Cells[Sheet2_row, 13] = _dgv.Rows[row].Cells[36].Value.ToString().Trim().Substring(5, 5);//計劃回港日期

                            RangeName = "H" + Sheet2_row.ToString();
                            PicturePath = _dgv.Rows[row].Cells[20].Value.ToString().Trim();//圖片路徑
                            if (PicturePath != "")
                            {
                                rg = (Microsoft.Office.Interop.Excel.Range)objSheet2.get_Range(RangeName, m_objOpt);//图片在單元格中的坐标
                                float PicLeft, PicTop; //图片在單元格中的停靠位置（单位：points）
                                PicLeft = Convert.ToSingle(rg.Left + 0.5);
                                PicTop = Convert.ToSingle(rg.Top + 0.5);
                                float PicWidth, PicHeight;//圖片在單元格中的寬、高（单位：points）
                                PicWidth = 60;
                                PicHeight = 60;
                                objSheet2.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse,
                                    Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft, PicTop, PicWidth, PicHeight);
                            }

                            Sheet2_row++;
                        }
                        else
                        {
                            Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)
                                  objSheet1.Range[objSheet1.Cells[Sheet1_row, 1], objSheet1.Cells[Sheet1_row, colscount]];
                            //rg.Font.Bold = true;
                            rg.Font.Size = 10;
                            rg.RowHeight = 61;

                            objSheet1.Cells[Sheet1_row, 1] = (Sheet1_row - 1).ToString();//序號
                            objSheet1.Cells[Sheet1_row, 2] = _dgv.Rows[row].Cells[5].Value.ToString().Trim();//收貨部門
                            if (_dgv.Rows[row].Cells[13].Value.ToString().Trim() != "")
                                objSheet1.Cells[Sheet1_row, 3] = _dgv.Rows[row].Cells[13].Value.ToString().Trim().Substring(5, 5);//上部門最大交貨期
                            objSheet1.Cells[Sheet1_row, 4] = _dgv.Rows[row].Cells[37].Value.ToString().Trim();//制單要求狀態
                            objSheet1.Cells[Sheet1_row, 5] = _dgv.Rows[row].Cells[1].Value.ToString().Trim();//制單編號
                            objSheet1.Cells[Sheet1_row, 6] = _dgv.Rows[row].Cells[3].Value.ToString().Trim();//物料編號
                            objSheet1.Cells[Sheet1_row, 7] = _dgv.Rows[row].Cells[4].Value.ToString().Trim();//物料描述
                            objSheet1.Cells[Sheet1_row, 9] = _dgv.Rows[row].Cells[6].Value.ToString().Trim();//生產數量
                            objSheet1.Cells[Sheet1_row, 10] = _dgv.Rows[row].Cells[8].Value.ToString().Trim();//完成數量
                            if (_dgv.Rows[row].Cells[36].Value.ToString().Trim() != "")
                                objSheet1.Cells[Sheet1_row, 13] = _dgv.Rows[row].Cells[36].Value.ToString().Trim().Substring(5, 5);//計劃回港日期

                            RangeName = "H" + Sheet1_row.ToString();
                            PicturePath = _dgv.Rows[row].Cells[20].Value.ToString().Trim();//圖片路徑
                            if (PicturePath != "")
                            {
                                rg = (Microsoft.Office.Interop.Excel.Range)objSheet1.get_Range(RangeName, m_objOpt);//图片在單元格中的坐标
                                float PicLeft, PicTop; //图片在單元格中的停靠位置（单位：points）
                                PicLeft = Convert.ToSingle(rg.Left + 0.5);
                                PicTop = Convert.ToSingle(rg.Top + 0.5);
                                float PicWidth, PicHeight;//圖片在單元格中的寬、高（单位：points）
                                PicWidth = 60;
                                PicHeight = 60;
                                objSheet1.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse,
                                    Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft, PicTop, PicWidth, PicHeight);
                            }

                            Sheet1_row++;
                        }
                    }

                    intValue++;
                    Thread.Sleep(100);
                    string strMessage = ((100 * intValue) / rowscount).ToString() + "%";
                    _worker.ReportProgress(((100 * intValue) / rowscount), strMessage); //注意：这里向子窗体返回两个信息值，一个用于进度条，一个用于label的。
                    System.Windows.Forms.Application.DoEvents();
                }
                objSheet1.Columns.EntireColumn.AutoFit();//列宽自适应
                objSheet2.Columns.EntireColumn.AutoFit();

                RangeName = "H1";
                rg1 = (Microsoft.Office.Interop.Excel.Range)objSheet1.get_Range(RangeName, m_objOpt);//图片在單元格中的坐标
                rg1.ColumnWidth = 10;
                rg2 = (Microsoft.Office.Interop.Excel.Range)objSheet2.get_Range(RangeName, m_objOpt);
                rg2.ColumnWidth = 10;

                objSheet1.PageSetup.PrintGridlines = true;
                objSheet1.PageSetup.LeftMargin = 1;
                objSheet1.PageSetup.RightMargin = 1;
                objSheet2.PageSetup.PrintGridlines = true;
                objSheet2.PageSetup.LeftMargin = 1;
                objSheet2.PageSetup.RightMargin = 1;

                //保存文件   
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objSheet1 = null;
                objSheet2 = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;

            this.SaveToExcel(dgvDetails, worker);
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

                for (int i = 0; i < dgvDetails.ColumnCount; i++)//最後兩欄組別、機器代碼不用匯出，影響到Excel報表計算
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容
                string pre_id, cur_id, col_value;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    cur_id = dgvDetails.Rows[rowNo].Cells[39].Value.ToString().Trim();
                    if (rowNo == 0)
                        pre_id = "";
                    else
                        pre_id = dgvDetails.Rows[rowNo - 1].Cells[39].Value.ToString().Trim();
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)//最後兩欄組別、機器代碼不用匯出，影響到Excel報表計算
                    {

                        if (columnNo > 0)
                        {
                            tempstr += "\t";
                        }
                        if (cur_id == pre_id && columnNo < 24)//去掉重複的記錄
                            col_value = "";
                        else
                            if (dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() != null)
                                col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                            else
                                col_value = "";
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }
        private void cmdShowData_Click(object sender, EventArgs e)
        {
            if (this.cmdShowData.Text == "顯示報表")
            {
                this.cmdShowData.Text = "顯示表格";
                 this.dgvDetails.Visible = false;
            }
            else
            {
                this.cmdShowData.Text = "顯示報表";
                this.dgvDetails.Visible = true;
            }
        }

        private void showSimplePlan()
        {
            /*
            while (this.dgvDetails.Rows.Count != 0)
            {
                this.dgvDetails.Rows.RemoveAt(0);
            }
             */
            dt2 = dt1.Clone();
            //foreach (DataRow MyDataRow in dt1.Select("Region = 'WA'"))
            foreach (DataRow MyDataRow in dt1.Select("order_qty > c_qty_ok AND wp_id <> next_wp_id AND next_wp_id<>'702' AND substring(mo_id,1,1)<>'Y' "))// AND pre_dep_deliver_flag <> '上部門欠件'
            {
                dt2.ImportRow(MyDataRow);
            }

            dgvDetails.DataSource = dt2;
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

      
       

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDep_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ExpSimpePlan_Click(object sender, EventArgs e)
        {
           
            this.backgroundWorker1.RunWorkerAsync(); // 运行 backgroundWorker 组件

            frmProgressBar form = new frmProgressBar(this.backgroundWorker1);// 显示进度条窗体 
            form.ShowDialog(this);
            form.Close();
        }

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
            System.Data.DataTable dtFromExcel = DataOperator(FileName);  //GetDataFromExcel(FileName, false, 1);
            //dgvDetails.DataSource = dtFromExcel;
            string mo_id, mo_req_status,sent_bef_year;
            string usr = DBUtility._user_id;
            DateTime tim = DateTime.Now;
            bool upd_status = true;
            int RowCount = dtFromExcel.Rows.Count;//行数
            for (int i = 0; i < RowCount; i++)
            {
                mo_id = dtFromExcel.Rows[i][0].ToString().Trim();
                mo_req_status = dtFromExcel.Rows[i][1].ToString().Trim();
                sent_bef_year = dtFromExcel.Rows[i][2].ToString().Trim();
                if (mo_id.Length > 10)
                    mo_id = mo_id.Substring(0, 9);
                if (mo_req_status.Length > 80)
                    mo_req_status = mo_req_status.Substring(0, 79);
                //添加
                strCode = "select mo_id from mo_status where mo_id = '" + mo_id + "'";
                try
                {
                    System.Data.DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);

                    if (dtRows.Rows.Count<=0)
                    {
                        strCode = "INSERT INTO mo_status(mo_id,mo_req_status,sent_bef_year,cr_usr,cr_tim) ";
                        strCode += " VALUES(@mo_id,@mo_req_status,@sent_bef_year,@usr,@tim)";

                        this.ParametersAddValue(mo_id, mo_req_status,sent_bef_year, usr, tim);
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
                            strCode = "UPDATE mo_status SET mo_req_status = @mo_req_status,sent_bef_year=@sent_bef_year,am_usr=@usr,am_tim=@tim ";
                            strCode += " WHERE mo_id = @mo_id";
                            this.ParametersAddValue(mo_id, mo_req_status,sent_bef_year, usr, tim);
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
                            throw ex;
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

        private void ParametersAddValue(string mo_id, string mo_req_status,string sent_bef_year, string usr, DateTime tim)
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@mo_id", mo_id);
            commUse.Cmd.Parameters.AddWithValue("@mo_req_status", mo_req_status);
            commUse.Cmd.Parameters.AddWithValue("@sent_bef_year", sent_bef_year);
            commUse.Cmd.Parameters.AddWithValue("@usr", usr);
            commUse.Cmd.Parameters.AddWithValue("@tim", tim);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.upd_mo_status();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.DvExportExcel_1();
        }

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
                str += "\t" + "記錄號";
                str += "\t" + "生產組別";
                str += "\t" + "生產機器";
                str += "\t" + "到貨狀態";
                str += "\t" + "落單日期";
                sw.WriteLine(str);
                //写内容
                string pre_id, cur_id, col_value;
                int excelNo = 1;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    cur_id = dgvDetails.Rows[rowNo].Cells[39].Value.ToString().Trim();
                    if (rowNo == 0)
                        pre_id = "";
                    else
                        pre_id = dgvDetails.Rows[rowNo - 1].Cells[39].Value.ToString().Trim();
                    if (cur_id != pre_id)//重複的記錄不寫入
                    {
                        string tempstr = " ";
                        tempstr += excelNo.ToString();//序號
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[5].Value.ToString().Trim();//收貨部門
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[37].Value.ToString().Trim();//狀態
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[1].Value.ToString().Trim();//制單編號
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[3].Value.ToString().Trim();//商品編號
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[4].Value.ToString().Trim();//商品描述
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[6].Value.ToString().Trim();//應生產數量
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[29].Value.ToString().Trim();//上部門來貨數量
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[8].Value.ToString().Trim();//已完成數量
                        col_value = dgvDetails.Rows[rowNo].Cells[13].Value.ToString().Trim();//上部門來貨期
                        if (col_value != "")
                            col_value = col_value.Substring(5, 5);
                        else
                            col_value = "";
                        tempstr += "\t" + col_value;//上部門來貨期
                        tempstr += "\t" + " ";//回覆
                        tempstr += "\t" + " ";//備註
                        col_value = dgvDetails.Rows[rowNo].Cells[36].Value.ToString().Trim();//計劃回港日期
                        if (col_value != "")
                            col_value = col_value.Substring(5, 5);
                        else
                            col_value = "";
                        tempstr += "\t" + col_value;//計劃回港日期
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[38].Value.ToString().Trim();//批色
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[39].Value.ToString().Trim();//批色
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[40].Value.ToString().Trim();//生產組別
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[41].Value.ToString().Trim();//生產機器
                        tempstr += "\t" + dgvDetails.Rows[rowNo].Cells[12].Value.ToString().Trim();//到貨狀態
                        tempstr += "\t" + "=\"" + dgvDetails.Rows[rowNo].Cells[42].Value.ToString().Trim() + "\"";//落單日期
                        sw.WriteLine(tempstr);

                        excelNo++;
                    }
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void ExpArrangeData()
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
                str += "序號";
                str += "\t" + "狀態";
                str += "\t" + "落單日期";//追貨狀態
                str += "\t" + "到貨狀態";
                str += "\t" + "制單編號";
                str += "\t" + "排期日期";
                str += "\t" + "產品編號";
                str += "\t" + "產品描述";
                str += "\t" + "應生產數量";
                str += "\t" + "上部門來貨數量";
                str += "\t" + "已完成數量";
                str += "\t" + "上部門來貨期";
                str += "\t" + "pmc要求完成日期";
                str += "\t" + "部門復期";
                str += "\t" + "下部門";
                str += "\t" + "計劃回港日期";
                str += "\t" + "組別";
                //str += "\t" + "生產機器";
                sw.WriteLine(str);
                //写内容
                //string col_value;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DataRow dr = dt1.Rows[i];
                    string tempstr = " ";
                    tempstr += dr["arrange_seq"].ToString();//序號
                    tempstr += "\t" + dr["mo_urgent_cdesc"].ToString();//狀態
                    tempstr += "\t" + "=\"" + dr["order_date"].ToString() + "\"";//落單日期//追貨狀態mo_req_status
                    tempstr += "\t" + dr["pre_dep_deliver_flag"].ToString();//到貨狀態
                    tempstr += "\t" + dr["mo_id"].ToString();//制單編號
                    tempstr += "\t" + "=\"" + dr["arrange_date"].ToString() + "\"";//排期日期
                    tempstr += "\t" + dr["goods_id"].ToString();//產品編號
                    tempstr += "\t" + dr["goods_name"].ToString();//產品描述
                    tempstr += "\t" + dr["req_qty"].ToString();//應生產數量
                    tempstr += "\t" + dr["pre_prd_dep_qty"].ToString();//上部門來貨數量
                    tempstr += "\t" + dr["prd_cpl_qty"].ToString();//已完成數量
                    tempstr += "\t" + "=\"" + dr["pre_prd_dep_date"].ToString() + "\"";//上部門來貨期
                    tempstr += "\t" + "=\"" + dr["req_f_date"].ToString() + "\"";//pmc要求完成日期
                    tempstr += "\t" + "=\"" + dr["dep_rep_date"].ToString() + "\"";//部門復期
                    tempstr += "\t" + dr["next_wp_id"].ToString();//下部門
                    tempstr += "\t" + "=\"" + dr["req_hk_date"].ToString() + "\"";//計劃回港日期
                    tempstr += "\t" + dr["dep_group"].ToString();//組別
                    
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }
        private System.Data.DataTable DataOperator(string fileName)
        {
            DataSet ds = new DataSet();
            string myString = "Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source =  " + fileName + ";Extended Properties=Excel 8.0";
            OleDbConnection oconn = new OleDbConnection(myString);
            try
            {

                oconn.Open();
                
                OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", oconn);
                oda.Fill(ds);
                oconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //StrHlp.WebMessageBox(this.Page, "錯誤!");
                //txtAddMo.Text = ex.Message;
            }
            return ds.Tables[0];
        }

        private void txtPrd_item1_Leave(object sender, EventArgs e)
        {
            txtPrd_item2.Text = txtPrd_item1.Text;
        }

        private void chkArrange_Click(object sender, EventArgs e)
        {
            mkOldArrangeDate.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            string strSql = "";
            strSql = "Select Max(now_date) AS now_date  From dgcf_pad.dbo.product_arrange Where Prd_dep='" + txtDep.Text.Trim() + "'";
            System.Data.DataTable dt = commUse.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                mkOldArrangeDate.Text = dt.Rows[0]["now_date"].ToString();
        }

        private void btnArrange_Click(object sender, EventArgs e)
        {
            ExpArrangeData();
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

        private void mkChkDat1_Leave(object sender, EventArgs e)
        {
            mkChkDat2.Text = mkChkDat1.Text;
        }

       

    }
}
