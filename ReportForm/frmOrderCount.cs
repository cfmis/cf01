using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;
using System.IO;
using cf01.Forms;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing;

namespace cf01.ReportForm
{
    public partial class frmOrderCount : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        //private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        int groups ;
        System.Data.DataTable dtReport = new System.Data.DataTable();
        System.Data.DataTable dtReport2 = new System.Data.DataTable();
        System.Data.DataTable dtGroup = new System.Data.DataTable();
        System.Data.DataTable dtReport_summary_brand = new System.Data.DataTable();
        System.Data.DataTable dtReport_summary_customer = new System.Data.DataTable();
        public frmOrderCount()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOrderCount_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDat1.Text))
            //{
            //    txtDat1.EditValue = DateTime.Now.AddDays(-1);
            //}
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            }

            txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            this.ActiveControl = txtDat2;  
            txtDat2.Focus();
            
        }

        private void frmOrderCount_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
            dtReport2.Dispose();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        { 
            if (txtDat1.Text == "" && txtDat2.Text == "" )
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDat1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@date_begin",txtDat1.Text),
                new SqlParameter("@date_end",txtDat2.Text)    
            };
            //dtReport = new System.Data.DataTable();
            DataSet dts = clsPublicOfCF01.ExecuteProcedureReturnDataSet("usp_get_oc_by_sales_group", paras, null);
            dtGroup = dts.Tables[2];
            DataRow dtrw = dtGroup.NewRow();
            dtrw["mo_group"] = "Summary";//添加SummarySheet
            dtGroup.Rows.Add(dtrw);
            groups = dtGroup.Rows.Count; // dts.Tables[2].Rows.Count;

            dtReport = dts.Tables[0];
            dgvDetails.DataSource = dtReport;
            dtReport2 = dts.Tables[1];
            dgvDetails2.DataSource = dtReport2;
            //2021/08/27 export to excel add summary sheet
            dtReport_summary_brand= dts.Tables[3];
            dtReport_summary_customer = dts.Tables[4];

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                for (int i = 0; i < dgvDetails2.Columns.Count; i++)
                {
                    dgvDetails2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }       
            }
            else
            {
                dtReport.Clear();
                dtReport2.Clear();
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioGroup1.SelectedIndex == 0)
            {
                dgvDetails.Visible = true;
                dgvDetails2.Visible = false;
            }
            else
            {
                dgvDetails.Visible = false;
                dgvDetails2.Visible = true;
            }

        }      

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }    

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //抽取出匯了EXCEL的公共部分
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("無法創建Excel對象,可能當前電腦尚未安安裝有Excel辦公軟件！");
                return;
            }
            xlApp.Visible = false;
            //设置禁止弹出保存和覆盖的询问提示框
            xlApp.DisplayAlerts = false;
            xlApp.AlertBeforeOverwriting = true;
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Title = "保存EXECL文件",
                Filter = "EXECL文件|*.xls",
                FilterIndex = 1
            };
            string saveFile = "";
            int FormatNum;//保存excel文件的格式
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveFile = saveDialog.FileName;
                if (File.Exists(saveFile))
                {
                    File.Delete(saveFile);
                }        
                string Version = xlApp.Version;//excel版本號//獲取當前使用excel版本號
                if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                {
                    FormatNum = -4143;
                }
                else //you use excel 2007 or later
                {
                    FormatNum = 56;
                }                
            }
            else
            {
                return;
            }

            if (radioGroup1.SelectedIndex==0)
                ExcelByBrand(saveFile,xlApp, FormatNum);
            else
                ExcelByCustomer(saveFile, xlApp, FormatNum);
        }     

        private void ExcelByBrand(string saveFile,Microsoft.Office.Interop.Excel.Application xlApp, int FormatNum) //匯出EXCEL
        {
            try
            {
                Workbook wBook = xlApp.Workbooks.Add(true);
                //添加工作表创建的sheet的个数   
                wBook.Worksheets.Add(Missing.Value, Missing.Value, groups-1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                string strSalesGroup;
                Worksheet sheet;
                //設置進度條屬性
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dtGroup.Rows.Count;
                Range range = null;
                for (int i = 0; i < dtGroup.Rows.Count; i++)
                {                        
                    //顯示進度條
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }                    
                    //获取一个工作表
                    sheet = wBook.Worksheets[i + 1] as Worksheet;
                    strSalesGroup = dtGroup.Rows[i]["mo_group"].ToString();//組別
                    if (strSalesGroup != "Summary")
                    {                       
                        sheet.Name = strSalesGroup + "組";//設置Sheet的名稱
                        DataRow[] ary_dr = dtReport.Select(string.Format("mo_group='{0}'", strSalesGroup));
                        //給sheet第一行表頭  
                        sheet.Cells[1, 1] = String.Format("落單日期：{0}~{1}", txtDat1.Text, txtDat2.Text);
                        sheet.Range["A1:I1"].Merge(0);//合并单元格
                        sheet.Rows[1].Font.Bold = true;//粗體
                        sheet.Rows[1].RowHeight = 20;
                        //sheet.Rows[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        //給sheet第二行設置各列表頭                    
                        sheet.Cells[2, 1] = "牌子編碼";
                        sheet.Cells[2, 2] = "牌子名稱";
                        sheet.Cells[2, 3] = "收費頁數(張數)";
                        sheet.Cells[2, 4] = "免費頁數(張數)";
                        sheet.Cells[3, 4] = "不含W單";
                        sheet.Cells[3, 5] = "W單";
                        sheet.Cells[2, 6] = "總訂單數(PCS)";
                        sheet.Cells[2, 7] = "收費總金額(HKD)";
                        sheet.Cells[2, 8] = "免費總金額_不包含W單(HKD)";
                        sheet.Cells[2, 9] = "免費總金額_W單(HKD)";

                        sheet.Range["A2:A3"].Merge(0);//合并单元格
                        sheet.Range["B2:B3"].Merge(0);//合并单元格
                        sheet.Range["C2:C3"].Merge(0);//合并单元格
                        sheet.Range["D2:E2"].Merge(0);//合并单元格
                        sheet.Range["D3:D3"].Merge(0);//合并单元格
                        sheet.Range["E3:E3"].Merge(0);//合并单元格

                        sheet.Range["F2:F3"].Merge(0);//合并单元格
                        sheet.Range["G2:G3"].Merge(0);//合并单元格
                        sheet.Range["H2:H3"].Merge(0);//合并单元格
                        sheet.Range["I2:I3"].Merge(0);//合并单元格

                        sheet.get_Range("A2", "A3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("B2", "B3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("C2", "C3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("D2", "E2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("D3", "D3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("E3", "E3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        sheet.get_Range("F2", "F3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("G2", "G3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("H2", "H3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("I2", "I3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //sheet.Cells[2, 6] = "收費總金額(HKD)";
                        //sheet.Cells[2, 7] = "免費總金額(HKD)";
                        //sheet.Rows[2].Font.Bold = true;//粗體
                        range = (Range)sheet.get_Range("A1", "I3");//获取Excel多个单元格区域：本例做为Excel表头
                        range.Cells.Interior.Color = System.Drawing.Color.FromArgb(191, 191, 191).ToArgb();
                        int lastRow = 0;
                        if (ary_dr.Length > 0)
                        {
                            int k = 0;
                            foreach (DataRow dr in ary_dr)
                            {
                                sheet.Rows.Font.Size = 10;
                                sheet.Cells[4 + k, 1] = dr["brand_id"];
                                sheet.Cells[4 + k, 2] = dr["brand_name"];
                                sheet.Cells[4 + k, 3] = dr["mo_count"];
                                sheet.Cells[4 + k, 4] = dr["mo_count_is_free"];
                                sheet.Cells[4 + k, 5] = dr["mo_count_is_free_w"];

                                sheet.Cells[4 + k, 6] = dr["order_qty"];
                                sheet.Cells[4 + k, 7] = dr["amount_hkd"];
                                sheet.Cells[4 + k, 8] = dr["amount_hkd_is_free"];
                                sheet.Cells[4 + k, 9] = dr["amount_hkd_is_free_w"];
                                k = k + 1;
                            }
                            sheet.Columns[2].ColumnWidth = 28;
                            sheet.Columns[3].ColumnWidth = 11;
                            sheet.Columns[4].ColumnWidth = 11;
                            sheet.Columns[5].ColumnWidth = 11;

                            sheet.Columns[6].ColumnWidth = 13;
                            sheet.Columns[7].ColumnWidth = 13;
                            sheet.Columns[8].ColumnWidth = 23;
                            sheet.Columns[9].ColumnWidth = 18;
                            //
                            lastRow = 4 + k - 1;
                            sheet.Rows[lastRow].Font.Bold = true;//最后一行粗體 
                            string As = string.Format("A{0}", lastRow);
                            string Ie = string.Format("I{0}", lastRow);
                            range = null;
                            range = (Range)sheet.get_Range(As, Ie);//获取Excel多个单元格区域：本例做为Excel表头
                            range.Cells.Interior.Color = System.Drawing.Color.FromArgb(241, 230, 220).ToArgb(); //设置单元格的背景色 
                            //列宽自适应
                            //sheet.Columns.EntireColumn.AutoFit();
                            
                            //劃格線
                            //获取Excel多个单元格区域
                            string bottom_right = string.Format("I{0}", lastRow);//右下角座標
                            Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range("A1", bottom_right);
                            //单元格边框线类型(线型,虚线型)
                            excelRange.Borders.LineStyle = 1;
                            excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            //設置數字顯示格式
                            range = sheet.get_Range("C4", "F"+ lastRow.ToString());//获取多个单元格
                            range.NumberFormat = "#,##0";//整數
                            range = sheet.get_Range("G4", bottom_right);//获取多个单元格
                            range.NumberFormat = "#,##0.00"; 
                        }                        
                    }
                    else
                    {
                        //Summary sheet
                        sheet = GetSummarySheet(sheet, dtReport_summary_brand);
                    }
                    
                }//for loop

                //保存工作簿                   
                //wBook.Save();
                wBook.Saved = true;
                //保存excel文件 
                wBook.SaveAs(saveFile, FormatNum);
                //xlApp.Save(saveFile);
                //xlApp.SaveWorkspace(saveFile);
                xlApp.Quit();
                wBook = null;
                sheet = null;
                xlApp = null;
                GC.Collect();//强行销毁
                MessageBox.Show("匯出Excel成功！", "提示信息");
            }
            catch (Exception err)
            {
                MessageBox.Show("匯出Excel出错！错误原因：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ExcelByCustomer(string saveFile, Microsoft.Office.Interop.Excel.Application xlApp, int FormatNum) //匯出EXCEL
        {
                try
                {
                    //xlApp.Visible = false;
                    ////设置禁止弹出保存和覆盖的询问提示框
                    //xlApp.DisplayAlerts = false;
                    //xlApp.AlertBeforeOverwriting = true;
                    Workbook wBook = xlApp.Workbooks.Add(true);
                    //添加工作表创建的sheet的个数   
                    wBook.Worksheets.Add(Missing.Value, Missing.Value, groups - 1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                    string strSalesGroup;
                    Worksheet sheet;
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = dtGroup.Rows.Count;
                    Range range = null;
                    for (int i = 0; i < dtGroup.Rows.Count; i++)
                    {
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //获取一个工作表
                        sheet = wBook.Worksheets[i + 1] as Worksheet;
                        strSalesGroup = dtGroup.Rows[i]["mo_group"].ToString();//組別
                        if (strSalesGroup != "Summary")
                        {
                            sheet.Name = strSalesGroup + "組";//設置Sheet的名稱
                            DataRow[] ary_dr = dtReport2.Select(string.Format("mo_group='{0}'", strSalesGroup));
                            //給sheet第一行表頭  
                            sheet.Cells[1, 1] = String.Format("落單日期：{0}~{1}", txtDat1.Text, txtDat2.Text);
                            sheet.Range["A1:K1"].Merge(0);//合并单元格
                            sheet.Rows[1].Font.Bold = true;//粗體
                            sheet.Rows[1].RowHeight = 20;
                            //sheet.Rows[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            //給sheet第二行設置各列表頭    
                            sheet.Cells[2, 1] = "客戶編碼";
                            sheet.Cells[2, 2] = "客戶名稱";
                            sheet.Cells[2, 3] = "牌子編碼";
                            sheet.Cells[2, 4] = "牌子名稱";
                            sheet.Cells[2, 5] = "收費頁數(張數)";
                            sheet.Cells[2, 6] = "免費頁數(張數)";
                            sheet.Cells[3, 6] = "不包含W單";
                            sheet.Cells[3, 7] = "W單";

                            sheet.Cells[2, 8] = "總訂單數(PCS)";
                            sheet.Cells[2, 9] = "收費總金額(HKD)";
                            sheet.Cells[2, 10] = "免費總金額_不包含W單(HKD)";
                            sheet.Cells[2, 11] = "免費總金額_W單(HKD)";


                            sheet.Range["A2:A3"].Merge(0);//合并单元格
                            sheet.Range["B2:B3"].Merge(0);//合并单元格
                            sheet.Range["C2:C3"].Merge(0);//合并单元格
                            sheet.Range["D2:D3"].Merge(0);//合并单元格
                            sheet.Range["E2:E3"].Merge(0);//合并单元格
                            sheet.Range["F2:G2"].Merge(0);//合并单元格
                            sheet.Range["F3:F3"].Merge(0);//合并单元格
                            sheet.Range["G3:G3"].Merge(0);//合并单元格

                            sheet.Range["H2:H3"].Merge(0);//合并单元格
                            sheet.Range["I2:I3"].Merge(0);//合并单元格
                            sheet.Range["J2:J3"].Merge(0);//合并单元格
                            sheet.Range["K2:K3"].Merge(0);//合并单元格

                            sheet.get_Range("A2", "A3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("B2", "B3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("C2", "C3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("D2", "D3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("E2", "E3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("F3", "F3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("G3", "G3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            sheet.get_Range("H2", "H3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("I2", "I3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("J2", "J3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            sheet.get_Range("K2", "K3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            //sheet.Cells[2, 6] = "收費總金額(HKD)";
                            //sheet.Cells[2, 7] = "免費總金額(HKD)";
                            //sheet.Rows[2].Font.Bold = true;//粗體
                            range = (Range)sheet.get_Range("A1", "K3");//获取Excel多个单元格区域：本例做为Excel表头
                            range.Cells.Interior.Color = System.Drawing.Color.FromArgb(191, 191, 191).ToArgb();
                            int lastRow = 0;
                            if (ary_dr.Length > 0)
                            {
                                int k = 0;
                                foreach (DataRow dr in ary_dr)
                                {
                                    sheet.Rows.Font.Size = 10;
                                    sheet.Cells[4 + k, 1] = dr["it_customer"];
                                    sheet.Cells[4 + k, 2] = dr["name_customer"];
                                    sheet.Cells[4 + k, 3] = dr["brand_id"];
                                    sheet.Cells[4 + k, 4] = dr["brand_name"];
                                    sheet.Cells[4 + k, 5] = dr["mo_count"];
                                    sheet.Cells[4 + k, 6] = dr["mo_count_is_free"];
                                    sheet.Cells[4 + k, 7] = dr["mo_count_is_free_w"];
                                    sheet.Cells[4 + k, 8] = dr["order_qty"];
                                    sheet.Cells[4 + k, 9] = dr["amount_hkd"];
                                    sheet.Cells[4 + k, 10] = dr["amount_hkd_is_free"];
                                    sheet.Cells[4 + k, 11] = dr["amount_hkd_is_free_w"];
                                    k = k + 1;
                                }
                                sheet.Columns[2].ColumnWidth = 28;
                                sheet.Columns[3].ColumnWidth = 8;
                                sheet.Columns[4].ColumnWidth = 30;
                                sheet.Columns[5].ColumnWidth = 11;
                                sheet.Columns[6].ColumnWidth = 13;
                                sheet.Columns[7].ColumnWidth = 13;
                                sheet.Columns[8].ColumnWidth = 13;
                                sheet.Columns[9].ColumnWidth = 13;
                                sheet.Columns[10].ColumnWidth = 23;
                                sheet.Columns[11].ColumnWidth = 18;
                                
                                //設置最后一行
                                lastRow = 4 + k - 1;
                                sheet.Rows[lastRow].Font.Bold = true;//最后一行粗體 
                                string As = string.Format("A{0}", lastRow);
                                string Ke = string.Format("K{0}", lastRow);
                                range = null;
                                range = (Range)sheet.get_Range(As, Ke);//获取Excel多个单元格区域：本例做为Excel表头
                                range.Cells.Interior.Color = System.Drawing.Color.FromArgb(241, 230, 220).ToArgb();//设置单元格的背景色 
                                //列宽自适应        
                                //sheet.Columns.EntireColumn.AutoFit();

                                //劃線
                                //获取Excel多个单元格区域
                                string bottom_right = string.Format("K{0}", lastRow);//右下角座標                                
                                Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range("A1", bottom_right);
                                //单元格边框线类型(线型,虚线型)
                                excelRange.Borders.LineStyle = 1;
                                excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                                //設置數字顯示格式
                                range = sheet.get_Range("E4", "H" + lastRow.ToString());//获取多个单元格
                                range.NumberFormat = "#,##0";//整數
                                range = sheet.get_Range("I4", bottom_right);//获取多个单元格
                                range.NumberFormat = "#,##0.00";
                            }
                        }
                        else
                        {
                            //Summary sheet
                            sheet = GetSummarySheet(sheet, dtReport_summary_customer);
                        }
                    }//for loop
                    

                    //保存工作簿                   
                    //wBook.Save();
                    wBook.Saved = true;
                        //保存excel文件 
                        wBook.SaveAs(saveFile, FormatNum);
                        //xlApp.Save(saveFile);
                        //xlApp.SaveWorkspace(saveFile);
                        xlApp.Quit();
                        wBook = null;
                        sheet = null;
                        xlApp = null;
                        GC.Collect();//强行销毁
                        MessageBox.Show("匯出Excel成功！", "提示信息");
                }
                catch (Exception err)
                {
                    MessageBox.Show("匯出Excel出错！错误原因：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            //}
        }

        private Worksheet GetSummarySheet(Worksheet sheet, System.Data.DataTable dtblSummary)
        {
            //給sheet第一行表頭
            Range range = null;// 创建一个空的单元格对象
            sheet.Name = "Summary";//設置Sheet的名稱 
            sheet.Cells[1, 1] = string.Format("落單日期：{0}~{1}", txtDat1.Text, txtDat2.Text);
            sheet.Range["A1:H1"].Merge(0);//合并单元格
            sheet.Rows[1].Font.Bold = true;//粗體
            sheet.Rows[1].RowHeight = 20;
            sheet.Rows[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //給sheet第二行設置各列表頭                    
            sheet.Cells[2, 1] = "Group";
            sheet.Cells[2, 2] = "No of MO(收費)";
            sheet.Cells[2, 3] = "No of MO(免費單-不包括W單)";
            sheet.Cells[2, 4] = "No of MO(免費單-只包括W單)";
            sheet.Cells[2, 5] = "總訂單數(PCS)";
            sheet.Cells[2, 6] = "收費總金額(HKD)";
            sheet.Cells[2, 7] = "免費總金額_不包含W單(HKD)";
            sheet.Cells[2, 8] = "免費總金額_只包括W單(HKD)";
            sheet.Rows[2].RowHeight = 18;
            sheet.Rows[2].Font.Bold = true;//粗體
            range = (Range)sheet.get_Range("A1", "H2");//获取Excel多个单元格区域：本例做为Excel表头
            range.Cells.Interior.Color = System.Drawing.Color.FromArgb(191, 191, 191).ToArgb();
            //sheet.get_Range("A2", "A3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            sheet.Rows[2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            int lastRow = 0;
            if (dtblSummary.Rows.Count > 0)
            {
                int k = 0;
                for (int x = 0; x < dtblSummary.Rows.Count; x++)               
                {
                    sheet.Rows.Font.Size = 10;
                    sheet.Cells[3 + k, 1] = dtblSummary.Rows[x]["mo_group"].ToString();
                    sheet.Cells[3 + k, 2] = dtblSummary.Rows[x]["mo_count"];
                    sheet.Cells[3 + k, 3] = dtblSummary.Rows[x]["mo_count_is_free"];
                    sheet.Cells[3 + k, 4] = dtblSummary.Rows[x]["mo_count_is_free_w"];
                    sheet.Cells[3 + k, 5] = dtblSummary.Rows[x]["order_qty"];
                    sheet.Cells[3 + k, 6] = dtblSummary.Rows[x]["amount_hkd"];
                    sheet.Cells[3 + k, 7] = dtblSummary.Rows[x]["amount_hkd_is_free"];
                    sheet.Cells[3 + k, 8] = dtblSummary.Rows[x]["amount_hkd_is_free_w"];
                    sheet.Rows[3 + k].RowHeight = 18;
                    k = k + 1;
                }
                sheet.Columns[1].ColumnWidth = 6;
                sheet.Columns[2].ColumnWidth = 14;
                sheet.Columns[3].ColumnWidth = 26;
                sheet.Columns[4].ColumnWidth = 26;
                sheet.Columns[5].ColumnWidth = 16;
                sheet.Columns[6].ColumnWidth = 16;
                sheet.Columns[7].ColumnWidth = 26;
                sheet.Columns[8].ColumnWidth = 26;
                lastRow = 3 + k - 1;
                sheet.Rows[lastRow].Font.Bold = true;//最后一行粗體  

                string As = string.Format("A{0}", lastRow);
                string He = string.Format("H{0}", lastRow);
                range = null;
                range = (Range)sheet.get_Range(As, He);//获取Excel多个单元格区域：本例做为Excel表头
                range.Cells.Interior.Color = System.Drawing.Color.FromArgb(241, 230, 220).ToArgb();//设置单元格的背景色
                //劃線
                //获取Excel多个单元格区域
                string bottom_right = string.Format("H{0}", lastRow);//右下角座標
                Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range("A1", bottom_right);
                //单元格边框线类型(线型,虚线型)
                excelRange.Borders.LineStyle = 1;
                excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //設置數字顯示格式
                range = sheet.get_Range("B3", "E" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0";//整數
                range = sheet.get_Range("F3", bottom_right);//获取多个单元格
                range.NumberFormat = "#,##0.00";

            }
            return sheet;
        }


        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
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

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                dgvDetails.Visible = true;
                dgvDetails2.Visible = false;
            }
            else
            {
                dgvDetails.Visible = false;
                dgvDetails2.Visible = true;
            }
        }

     
    }
}
