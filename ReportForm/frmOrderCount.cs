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
            groups = dts.Tables[2].Rows.Count;
            dtReport = dts.Tables[0];
            dgvDetails.DataSource = dtReport;
            dtReport2 = dts.Tables[1];
            dgvDetails2.DataSource = dtReport2;

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
            if (radioGroup1.SelectedIndex==0)
                Excel();
            else
                Excel2();
        }     

        private void Excel() //匯出EXCEL
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("無法創建Excel對象,可能當前電腦尚未安安裝有Excel辦公軟件！");
                return;
            }
            SaveFileDialog saveDialog = new SaveFileDialog()
            {                
                Title = "保存EXECL文件",
                Filter = "EXECL文件|*.xls",
                FilterIndex = 1
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFile = saveDialog.FileName;
                if (File.Exists(saveFile))
                {
                    File.Delete(saveFile);
                }
                int FormatNum;//保存excel文件的格式
                string Version = xlApp.Version;//excel版本號//獲取當前使用excel版本號
                if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                {
                    FormatNum = -4143;
                }
                else //you use excel 2007 or later
                {
                    FormatNum = 56;
                }

                try
                {
                    xlApp.Visible = false;
                    //设置禁止弹出保存和覆盖的询问提示框
                    xlApp.DisplayAlerts = false;
                    xlApp.AlertBeforeOverwriting = true;
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
                    for (int i = 0; i < dtGroup.Rows.Count; i++)
                    {                        
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        strSalesGroup = dtGroup.Rows[i]["mo_group"].ToString();//組別
                        //获取一个工作表
                        sheet = wBook.Worksheets[i + 1] as Worksheet;
                        sheet.Name = strSalesGroup+"組";//設置Sheet的名稱
                        DataRow[] ary_dr = dtReport.Select(string.Format("mo_group='{0}'", strSalesGroup));
                        //給sheet第一行表頭  
                        sheet.Cells[1, 1] = String.Format("落單日期：{0}~{1}", txtDat1.Text, txtDat2.Text);                        
                        sheet.Range["A1:H1"].Merge(0);//合并单元格
                        sheet.Rows[1].Font.Bold = true;//粗體
                        sheet.Rows[1].RowHeight = 20;
                        //sheet.Rows[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        //給sheet第二行設置各列表頭                    
                        sheet.Cells[2, 1] = "牌子編碼";
                        sheet.Cells[2, 2] = "牌子名稱";
                        sheet.Cells[2, 3] = "收費頁數(張數)";
                        sheet.Cells[2, 4] = "免費頁數(張數)";
                        sheet.Cells[3, 4] = "不包含W單";
                        sheet.Cells[3, 5] = "W單";

                        sheet.Cells[2, 6] = "總訂單數(PCS)";
                        sheet.Cells[2, 7] = "收費總金額(HKD)";
                        sheet.Cells[2, 8] = "免費總金額(HKD)";

                        sheet.Range["A2:A3"].Merge(0);//合并单元格
                        sheet.Range["B2:B3"].Merge(0);//合并单元格
                        sheet.Range["C2:C3"].Merge(0);//合并单元格
                        sheet.Range["D2:E2"].Merge(0);//合并单元格
                        sheet.Range["D3:D3"].Merge(0);//合并单元格
                        sheet.Range["E3:E3"].Merge(0);//合并单元格

                        sheet.Range["F2:F3"].Merge(0);//合并单元格
                        sheet.Range["G2:G3"].Merge(0);//合并单元格
                        sheet.Range["H2:H3"].Merge(0);//合并单元格

                        sheet.get_Range("A2", "A3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("B2", "B3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("C2", "C3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("D2", "E2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("D3", "D3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("E3", "E3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        sheet.get_Range("F2", "F3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("G2", "G3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        sheet.get_Range("H2", "H3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //sheet.Cells[2, 6] = "收費總金額(HKD)";
                        //sheet.Cells[2, 7] = "免費總金額(HKD)";
                        //sheet.Rows[2].Font.Bold = true;//粗體
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
                                k = k + 1;
                            }
                            sheet.Columns[2].ColumnWidth = 28;
                            sheet.Columns[3].ColumnWidth = 11;
                            sheet.Columns[4].ColumnWidth = 11;
                            sheet.Columns[5].ColumnWidth = 11;

                            sheet.Columns[6].ColumnWidth = 13;
                            sheet.Columns[7].ColumnWidth = 13;
                            sheet.Columns[8].ColumnWidth = 13;
                        }
                        //sheet.Columns.EntireColumn.AutoFit();//列宽自适应
                    }

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
        }


        private void Excel2() //匯出EXCEL
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("無法創建Excel對象,可能當前電腦尚未安安裝有Excel辦公軟件！");
                return;
            }
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Title = "保存EXECL文件",
                Filter = "EXECL文件|*.xls",
                FilterIndex = 1
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFile = saveDialog.FileName;
                if (File.Exists(saveFile))
                {
                    File.Delete(saveFile);
                }
                int FormatNum;//保存excel文件的格式
                string Version = xlApp.Version;//excel版本號//獲取當前使用excel版本號
                if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                {
                    FormatNum = -4143;
                }
                else //you use excel 2007 or later
                {
                    FormatNum = 56;
                }

                try
                {
                    xlApp.Visible = false;
                    //设置禁止弹出保存和覆盖的询问提示框
                    xlApp.DisplayAlerts = false;
                    xlApp.AlertBeforeOverwriting = true;
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
                    for (int i = 0; i < dtGroup.Rows.Count; i++)
                    {
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }

                        strSalesGroup = dtGroup.Rows[i]["mo_group"].ToString();//組別
                        //获取一个工作表
                        sheet = wBook.Worksheets[i + 1] as Worksheet;
                        sheet.Name = strSalesGroup + "組";//設置Sheet的名稱
                        DataRow[] ary_dr = dtReport2.Select(string.Format("mo_group='{0}'", strSalesGroup));
                        //給sheet第一行表頭  
                        sheet.Cells[1, 1] = String.Format("落單日期：{0}~{1}", txtDat1.Text, txtDat2.Text);
                        sheet.Range["A1:J1"].Merge(0);//合并单元格
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
                        sheet.Cells[2, 10] = "免費總金額(HKD)";
                       

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
                        //sheet.Cells[2, 6] = "收費總金額(HKD)";
                        //sheet.Cells[2, 7] = "免費總金額(HKD)";
                        //sheet.Rows[2].Font.Bold = true;//粗體
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
                                k = k + 1;
                            }
                            sheet.Columns[2].ColumnWidth = 28;
                            sheet.Columns[3].ColumnWidth = 28;
                            sheet.Columns[4].ColumnWidth = 11;
                            sheet.Columns[5].ColumnWidth = 11;
                            sheet.Columns[6].ColumnWidth = 11;

                            sheet.Columns[8].ColumnWidth = 13;
                            sheet.Columns[9].ColumnWidth = 13;
                            sheet.Columns[10].ColumnWidth = 13;
                            
                        }
                        //sheet.Columns.EntireColumn.AutoFit();//列宽自适应
                    }

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
