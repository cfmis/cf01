using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace cf01.ReportForm
{
    public partial class frmOverdueDays : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        //clsPublicOfGEO clsDb = new clsPublicOfGEO();
        System.Data.DataTable dtReport = new System.Data.DataTable();
                
        public frmOverdueDays()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOverdueDays_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();           
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
            if (string.IsNullOrEmpty(txtDays.Text))
            {
                MessageBox.Show("日期范圍必須輸入!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDays.Focus();
                return;
            }
            if (int.Parse(txtDays.Text) <= 0)
            {
                MessageBox.Show("日期范圍輸入有誤!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDays.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@days",txtDays.Text)
            };
            dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("z_rpt_overdue_days", paras);           
            dgvDetails.DataSource = dtReport;       

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }                    
            }
            else
            {
                dtReport.Clear();               
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }      

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }   

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //ExpToExcel oxls = new ExpToExcel();
            //oxls.ExportExcel(dgvDetails);
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
            string file_default= "外發加工過期超過7天("+ DateTime.Now.ToString("yyyy-MM-dd")+")";
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Title = "保存EXECL文件",
                Filter = "EXECL文件|*.xls",
                FilterIndex = 1,
                FileName = file_default
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
            this.ExportToExcel(saveFile, xlApp, FormatNum);
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

            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["flag_old_data"].Value.ToString() == "1")
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;                
            }
        }

        private void frmOverdueDays_Load(object sender, EventArgs e)
        {
            if (txtDays.Text == "")
            {
                txtDays.Text = "60";
            }
        }

        private void ExportToExcel(string saveFile, Microsoft.Office.Interop.Excel.Application xlApp, int FormatNum) //匯出EXCEL
        {
            try
            {
                Workbook wBook = xlApp.Workbooks.Add(true);
                //添加工作表创建的sheet的个数   
                wBook.Worksheets.Add(Missing.Value, Missing.Value, 1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Worksheet sheet;     
                sheet = wBook.Worksheets[1] as Worksheet;//获取一个工作表
                sheet.Name = "sheet1"; //設置Sheet的名稱
                //設置進度條屬性
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dtReport.Rows.Count;
                Range range = null;
                sheet.Rows[1].Font.Bold = true;//粗體
                sheet.Rows[1].RowHeight = 20;
                //sheet.Rows[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //給sheet第一行設置各列表頭
                sheet.Cells[1, 1] = "供應商";
                sheet.Cells[1, 2] = "供應商名稱";
                sheet.Cells[1, 3] = "外發類別";
                sheet.Cells[1, 4] = "頁數";
                sheet.Cells[1, 5] = "貨品編號";
                sheet.Cells[1, 6] = "貨品描述";
                sheet.Cells[1, 7] = "發貨日期";
                sheet.Cells[1, 8] = "要求交貨日期";
                sheet.Cells[1, 9] = "過期天數";
                sheet.Cells[1, 10] = "未返數量";
                sheet.Cells[1, 11] = "未返重量";
                sheet.Cells[1, 12] = "發貨數量";
                sheet.Cells[1, 13] = "發貨重量";
                sheet.Cells[1, 14] = "收貨數量";
                sheet.Cells[1, 15] = "收貨重量";
                sheet.Cells[1, 16] = "加工單號";
                sheet.Cells[1, 17] = "收貨入倉日期";
                sheet.Cells[1, 18] = "計劃生產數量";
                sheet.Cells[1, 19] = "計劃完成數量";
                //sheet.Range["A2:A3"].Merge(0);//合并单元格
                //sheet.get_Range("A1", "S1").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; 
                range = (Range)sheet.get_Range("A1", "S1");//获取Excel多个单元格区域：本例做为Excel表头
                range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                range.Cells.Interior.Color = System.Drawing.Color.FromArgb(191, 191, 191).ToArgb();
                range.Font.Size = 10;//设置字体大小
                string flag_color = "", As = "", Se = "";
                int lastRow = 0;
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    //顯示進度條
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }
                    //DataRow[] ary_dr = dtReport.Select(string.Format("mo_group='{0}'", strSalesGroup));                   
                    //sheet.Cells[1, 1] = string.Format("匯出日期：{0}", DateTime.Now.ToString("yyyy-MM-dd"));
                    sheet.Rows.Font.Size = 10;
                    sheet.Cells[2 + i, 1] = dtReport.Rows[i]["vendor_id"].ToString();
                    sheet.Cells[2 + i, 2] = dtReport.Rows[i]["vendor_name"].ToString();
                    sheet.Cells[2 + i, 3] = dtReport.Rows[i]["vendor_type"].ToString();
                    sheet.Cells[2 + i, 4] = dtReport.Rows[i]["mo_id"].ToString();
                    sheet.Cells[2 + i, 5] = dtReport.Rows[i]["goods_id"].ToString();
                    sheet.Cells[2 + i, 6] = dtReport.Rows[i]["goods_name"].ToString();
                    sheet.Cells[2 + i, 7] = dtReport.Rows[i]["issue_date"].ToString();
                    sheet.Cells[2 + i, 8] = dtReport.Rows[i]["delivery_date"].ToString();
                    sheet.Cells[2 + i, 9] = dtReport.Rows[i]["overdue_days"].ToString();
                    sheet.Cells[2 + i, 10] = dtReport.Rows[i]["qty_diff"].ToString();
                    sheet.Cells[2 + i, 11] = dtReport.Rows[i]["sec_qty_diff"].ToString();
                    sheet.Cells[2 + i, 12] = dtReport.Rows[i]["out_qty"].ToString();
                    sheet.Cells[2 + i, 13] = dtReport.Rows[i]["out_sec_qty"].ToString();
                    sheet.Cells[2 + i, 14] = dtReport.Rows[i]["in_qty"].ToString();
                    sheet.Cells[2 + i, 15] = dtReport.Rows[i]["in_sec_qty"].ToString();
                    sheet.Cells[2 + i, 16] = dtReport.Rows[i]["id"].ToString();
                    sheet.Cells[2 + i, 17] = dtReport.Rows[i]["ir_date"].ToString();
                    sheet.Cells[2 + i, 18] = dtReport.Rows[i]["prod_qty"].ToString();
                    sheet.Cells[2 + i, 19] = dtReport.Rows[i]["c_qty_ok"].ToString();                    
                    flag_color = dtReport.Rows[i]["flag_old_data"].ToString();
                    if (flag_color == "1")
                    {
                        //設置行背景色
                        As = string.Format("A{0}", 2 + i);
                        Se = string.Format("S{0}", 2 + i);
                        range = (Range)sheet.get_Range(As, Se);//获取Excel多个单元格区域
                        range.Cells.Interior.Color = System.Drawing.Color.Pink;//.FromArgb(242, 220, 219).ToArgb(); //设置单元格的背景色
                    }
                    lastRow = 2 + i; //設置最后一行
                }//for loop
                string bottom_right = string.Format("S{0}", lastRow);//右下角座標
                Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range("A1", bottom_right);
                //单元格边框线类型(线型,虚线型)
                excelRange.Borders.LineStyle = 1;
                excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //設置數字顯示格式
                range = sheet.get_Range("I2", "J" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0";//整數
                range = sheet.get_Range("K2", "K" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0.00"; //未返重量
                range = sheet.get_Range("L2", "L" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0";//整數 //發貨數量
                range = sheet.get_Range("M2", "M" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0.00"; //發貨重量
                range = sheet.get_Range("N2", "N" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0";//整數 //收貨數量
                range = sheet.get_Range("Q2", "Q" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0.00";//收貨重量
                range = sheet.get_Range("R2", "S" + lastRow.ToString());//获取多个单元格
                range.NumberFormat = "#,##0";//整數
                sheet.Columns[1].ColumnWidth = 10;
                sheet.Columns[2].ColumnWidth = 10;
                sheet.Columns[3].ColumnWidth = 10;
                sheet.Columns[4].ColumnWidth = 10;
                sheet.Columns[5].ColumnWidth = 20;
                sheet.Columns[6].ColumnWidth = 22;
                sheet.Columns[7].ColumnWidth = 11;
                sheet.Columns[8].ColumnWidth = 11;
                sheet.Columns[9].ColumnWidth = 8;
                sheet.Columns[10].ColumnWidth = 8;
                sheet.Columns[11].ColumnWidth = 8;
                sheet.Columns[12].ColumnWidth = 8;
                sheet.Columns[13].ColumnWidth = 8;
                sheet.Columns[14].ColumnWidth = 8;
                sheet.Columns[15].ColumnWidth = 8;
                sheet.Columns[16].ColumnWidth = 11;
                sheet.Columns[17].ColumnWidth = 12;
                sheet.Columns[18].ColumnWidth = 10;
                sheet.Columns[19].ColumnWidth = 8;
                lastRow = lastRow + 2;
                sheet.Cells[lastRow, 1] = "**備註: 背景色Highlight的行為前一周曾有過期匯出.";
                As = string.Format("A{0}", lastRow);
                Se = string.Format("S{0}", lastRow);
                range = (Range)sheet.get_Range(As, Se);//获取Excel多个单元格区域                
                range.Merge(0);                
                //range.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
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
}
