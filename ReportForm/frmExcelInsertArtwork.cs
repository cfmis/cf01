using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using cf01.CLS;
using cf01;

namespace cf01.ReportForm
{
    public partial class frmExcelInsertArtwork : Form
    {
        public clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        
        public frmExcelInsertArtwork()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strFile_Excel;
            OpenFileDialog openFileDialog1 = new OpenFileDialog { 
                Filter = "Execl files (*.xls)|*.xls", 
                FilterIndex = 0, 
                RestoreDirectory = true, 
                Title = "導入EXCEL文件路徑", 
                FileName = null 
            };
            openFileDialog1.ShowDialog();
            strFile_Excel = openFileDialog1.FileName;
            Refresh();
            if (string.IsNullOrEmpty(strFile_Excel))
            {
                return;
            }
            if (!File.Exists(strFile_Excel))
            {
                MessageBox.Show("指定的EXCEL文件不存在，請返回檢查!");
                return;
            }
            //2016-06-11新增的導入方法
            //可記錄每行導入狀態            
            if (Process_Excel(strFile_Excel, progressBar1))
            {
                MessageBox.Show("操作成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("操作失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool Process_Excel(string _ExcelFile, System.Windows.Forms.ProgressBar progressBar)
        {
            bool result;
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application() { Visible = true };
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(_ExcelFile,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet xSheet;
            int iSheets = xBook.Sheets.Count;
            try
            {                
                for (int i = 1; i <= iSheets; i++)                
                {
                    xBook.Worksheets[i].Activate();
                    xSheet = xSheet = xBook.Worksheets[i] as Worksheet;
                    progressBar.Enabled = true;
                    progressBar.Visible = true;
                    progressBar.Value = 0;
                    progressBar.Step = 1;                   
                    Microsoft.Office.Interop.Excel.Range rng;
                    xSheet.Columns["R:R"].ColumnWidth = 12; //設置圖片列寬度
                    rng = xSheet.Cells[1, "R"];                    
                    rng.Value2 = "圖樣";
                    xSheet.Columns[17].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //豎直方向居中對齊
                    xSheet.Range["R1:R1"].Merge(0);//合并单元格

                    int row_precessing = 0;
                    int row_total = xSheet.UsedRange.Rows.Count;//總行數
                    progressBar.Maximum = row_total;

                    string goods_id, strPictrue_name;                    
                    for (int ii = 2; ii <= row_total; ii++)
                    {
                        row_precessing = ii;//記錄更在更新的行
                        progressBar.Value += progressBar.Step;
                        if (progressBar.Value == progressBar.Maximum)
                        {
                            progressBar.Enabled = false;
                            progressBar.Visible = false;
                        }
                        xSheet.Rows[ii].RowHeight = 70;                       
                        rng = xSheet.Cells[ii, "G"]; //貨品編號 
                        goods_id = rng.get_Value();
                        //取圖樣路徑
                        strPictrue_name = clsConErp.ExecuteSqlReturnObject(string.Format("Select dbo.Fn_get_picture_name('0000','{0}','out')", goods_id));
                        if (File.Exists(strPictrue_name))
                        {
                            //InsertPicture("Q" + ii, xSheet, strPictrue_name);//插入圖片
                            InsertPicture("R" + ii, xSheet, strPictrue_name);//插入圖片
                        }
                    }
                    //xBook.Save();                    
                    progressBar.Enabled = false;
                    progressBar.Visible = false;                   
                }
                
            }
            catch (Exception E)
            {
                result = false;
                throw new Exception(E.Message);
            }
            finally
            {
                xBook.Save();
                xSheet = null;
                xBook = null;
                if (xApp != null)
                {
                    xApp.Quit();
                }
                result = true;
            }
            return result;
        }

        /// 将图片插入到指定的单元格位置，并设置图片的宽度和高度。
        /// 注意：图片必须是绝对物理路径
        /// </summary>
        /// <param name="RangeName">单元格名称，例如：B4</param>
        /// <param name="PicturePath">要插入图片的绝对路径。</param>
        public static void InsertPicture(string RangeName, Microsoft.Office.Interop.Excel._Worksheet sheet, string PicturePath)
        {
            Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(RangeName, Type.Missing);
            rng.Select();            
            try
            {               
                sheet.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue,
                   Convert.ToSingle(rng.Left) + 5, Convert.ToSingle(rng.Top) + 5, rng.Width - 10, rng.Height - 10);   //插入图片 
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        public bool Process_Excel_of_artwork(string _ExcelFile, System.Windows.Forms.ProgressBar progressBar)
        {
            bool result;
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application() { Visible = true };
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(_ExcelFile,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet xSheet;
            int iSheets = xBook.Sheets.Count;
            try
            {
                string goods_id;
                string strPictrue_name = "";
                for (int i = 1; i <= iSheets; i++)
                {
                    xBook.Worksheets[i].Activate();
                    xSheet = xSheet = xBook.Worksheets[i] as Worksheet;
                    progressBar.Enabled = true;
                    progressBar.Visible = true;
                    progressBar.Value = 0;
                    progressBar.Step = 1;
                    Microsoft.Office.Interop.Excel.Range rng;
                    xSheet.Columns["F:F"].ColumnWidth = 12; //設置圖片列寬度
                    rng = xSheet.Cells[1, "G"]; 
                    rng.Value2 = "七位圖樣";
                    xSheet.Columns[8].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //圖片列豎直方向居中對齊
                    xSheet.Range["F1:F1"].Merge(0);//合并单元格

                    int row_precessing = 0;
                    int row_total = xSheet.UsedRange.Rows.Count;//總行數
                    progressBar.Maximum = row_total;
                 
                    for (int ii = 2; ii <= row_total; ii++)
                    {
                        row_precessing = ii;//記錄更在更新的行
                        progressBar.Value += progressBar.Step;
                        if (progressBar.Value == progressBar.Maximum)
                        {
                            progressBar.Enabled = false;
                            progressBar.Visible = false;
                        }
                        xSheet.Rows[ii].RowHeight = 70;
                        rng = xSheet.Cells[ii, "G"]; //七位圖樣
                        goods_id = rng.get_Value();
                        //取圖樣路徑
                        strPictrue_name = SetArtwork(goods_id.Trim());
                        if (strPictrue_name != "")
                        {
                            InsertPicture("F" + ii, xSheet, strPictrue_name);//插入圖片
                        }                        
                    }
                    //xBook.Save();                    
                    progressBar.Enabled = false;
                    progressBar.Visible = false;
                }

            }
            catch (Exception E)
            {
                result = false;
                throw new Exception(E.Message);
            }
            finally
            {
                xBook.Save();
                xSheet = null;
                xBook = null;
                if (xApp != null)
                {
                    xApp.Quit();
                }
                result = true;
            }
            return result;
        }

        private string SetArtwork(string artwork_code)
        {
            string result = "";
            if (!string.IsNullOrEmpty(artwork_code))
            {
               
                if (artwork_code.Length >= 7)
                {                   
                    string strArtwork = artwork_code.Substring(0, 7);
                    string strSql = string.Format(
                    @"SELECT Top 1 id,picture_name FROM cd_pattern_details 
                    Where within_code='0000' AND id='{0}' And ISNULL(picture_name,'')<>''
                    Order by sequence_id", strArtwork);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt = clsConErp.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        strArtwork = DBUtility.imagePath + dt.Rows[0]["picture_name"].ToString();
                        result = (File.Exists(strArtwork)) ? strArtwork : "";                        
                    }
                }
            }
            return result;
        }

        private void frmExcelInsertArtwork_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConErp = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFile_Excel;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Execl files (*.xls)|*.xls",
                FilterIndex = 0,
                RestoreDirectory = true,
                Title = "導入EXCEL文件路徑",
                FileName = null
            };
            openFileDialog1.ShowDialog();
            strFile_Excel = openFileDialog1.FileName;
            Refresh();
            if (string.IsNullOrEmpty(strFile_Excel))
            {
                return;
            }
            if (!File.Exists(strFile_Excel))
            {
                MessageBox.Show("指定的EXCEL文件不存在，請返回檢查!");
                return;
            }
            //2016-06-11新增的導入方法
            //可記錄每行導入狀態            
            if (Process_Excel_of_artwork(strFile_Excel, progressBar1))
            {
                MessageBox.Show("操作成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("操作失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
