using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing;

namespace cf01.CLS
{
    public static class clsPlateDelivery
    {
        public static string ExpToExcel(int typeIndex, int rowCount, System.Data.DataTable dtRpt, System.Data.DataTable dtRptReturn, ProgressBar progressBar1, bool isArt)
        {
            switch (typeIndex)
            {
                case 0:
                    //if (SaveDataTableToExcel_rpt1_sheets(dtRpt, dtRptReturn, saveFile, progressBar1, isArt))
                    if (ToExcelRpt1(dtRpt, dtRptReturn, progressBar1,isArt))
                    {
                        MessageBox.Show("匯出成功!", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    break;
                case 1:
                    bool flag = true;
                    string saveFile = "";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
                    saveFileDialog.FilterIndex = 0;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.CreatePrompt = true;
                    saveFileDialog.Title = "保存爲Excel文件";
                    saveFileDialog.ShowDialog();
                    if (saveFileDialog.FileName.IndexOf(":") < 0)
                    {
                        flag = false;  //點擊了"取消"
                    }
                    if (flag)
                    {
                        saveFile = saveFileDialog.FileName;
                        if (SaveDataTableToExcel_rpt2(dtRpt, saveFile, progressBar1, isArt))
                        {
                            MessageBox.Show("匯出成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }                        
                    break;
                case 2:
                    MessageBox.Show("107追貨表未完善此匯出功能!", "提示信息");
                    break;
            }            
            return "";
        }

        #region 報表格式1匯出到多個Sheet中
        static bool SaveDataTableToExcel_rpt1_sheets(System.Data.DataTable excelTable, System.Data.DataTable dtOutReurn, string filePath, ProgressBar progressBar1, bool isArt)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            if (app == null)
            {
                MessageBox.Show("無法創建Excel對象，可能你的機子上未安裝Excel.");
                return false;
            }

            try
            {
                app.Visible = false;
                //设置禁止弹出保存和覆盖的询问提示框
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = true;
                Workbook wBook = app.Workbooks.Add(true);
                //添加工作表创建的sheet的个数   
                wBook.Worksheets.Add(Missing.Value, Missing.Value, Convert.ToInt32(1), Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                //wBook.Worksheets.Add(Missing.Value, Missing.Value, Convert.ToInt32(dtVendor.Rows.Count), Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

                string cell_art = "";
                string cell_N = "";
                string cell_O = "";
                string cell_P = "";
                string cell_Q = "";
                string cell_R = "";
                string cell_S = "";
                string cell_T = "";
                string cell_U = "";
                //获取一个工作表
                //Worksheet sheet = wBook.Worksheets[i + 1] as Worksheet;
                Worksheet sheet = wBook.Worksheets[1] as Worksheet;
                sheet.Name = "追貨報表";
                //給sheet第一行設置各列表頭
                sheet.Cells[1, 1] = "客戶編號";
                sheet.Cells[1, 2] = "單據編號";
                sheet.Cells[1, 3] = "發貨日期";
                sheet.Cells[1, 4] = "狀態";
                sheet.Cells[1, 5] = "制單編號";
                sheet.Cells[1, 6] = "物料編號";
                sheet.Cells[1, 7] = "圖樣";
                sheet.Cells[1, 8] = "物料名稱";
                sheet.Cells[1, 9] = "顏色做法";
                sheet.Cells[1, 10] = "計划回港日期";
                sheet.Cells[1, 11] = "生產數量";
                sheet.Cells[1, 12] = "訂單數量";
                sheet.Cells[1, 13] = "完成數量";
                sheet.Cells[1, 14] = "發貨數量";
                sheet.Cells[1, 15] = "發貨重量";
                sheet.Cells[1, 16] = "總的發貨數量";
                sheet.Cells[1, 17] = "總的發貨重量";
                sheet.Cells[1, 18] = "總的收貨數量";
                sheet.Cells[1, 19] = "總的收貨重量";
                sheet.Cells[1, 20] = "差額數量";
                sheet.Cells[1, 21] = "差額重量";
                sheet.Cells[1, 22] = "備註";
                sheet.Cells[1, 23] = "返電次數";
                sheet.Cells[1, 24] = "部門回覆";
                sheet.Cells[1, 25] = "PMC回覆";

                //添加數據
                if (excelTable.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = excelTable.Rows.Count;
                    //***************

                    int row = excelTable.Rows.Count;
                    int col = excelTable.Columns.Count-3;
                    float picleft, pictop;
                    string str = "";
                    for (int k = 1; k < row; k++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        sheet.Rows.RowHeight = 55; //行高  
                        sheet.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            str = excelTable.Rows[k][j].ToString();
                            if (j != 6)//第7欄爲圖樣所在的欄   
                            {
                                sheet.Cells[k + 2, j + 1] = str;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(str) && File.Exists(str))
                                {
                                    if (isArt)
                                    {
                                        cell_art = "G" + (k + 2); //圖樣單元格坐標,從第二行開始 
                                        Range pic2 = sheet.get_Range(cell_art, Missing.Value);
                                        //Range pic2 = sheet.get_Range("A1", "B2"); //Sample                                        
                                        pic2.Select();
                                        picleft = Convert.ToSingle(pic2.Left) + 5;
                                        pictop = Convert.ToSingle(pic2.Top) + 5;
                                        sheet.Shapes.AddPicture(str, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, picleft, pictop, 45, 45);
                                    }
                                }
                            }

                            //設置背景色
                            cell_N = "N" + (k + 2);
                            cell_O = "O" + (k + 2);
                            cell_P = "P" + (k + 2);
                            cell_Q = "Q" + (k + 2);
                            cell_R = "R" + (k + 2);
                            cell_S = "S" + (k + 2);
                            cell_T = "T" + (k + 2);
                            cell_U = "U" + (k + 2);
                            Range cell_NO = sheet.get_Range(cell_N, cell_O);
                            cell_NO.Interior.Color = System.Drawing.Color.Tan;
                            Range cell_PQ = sheet.get_Range(cell_P, cell_Q);
                            cell_PQ.Interior.Color = System.Drawing.Color.FromArgb(255, 255, 192);
                            Range cell_RS = sheet.get_Range(cell_R, cell_S);
                            cell_RS.Interior.Color = System.Drawing.Color.Violet;
                            Range cell_TU = sheet.get_Range(cell_T, cell_U);
                            cell_TU.Interior.Color = System.Drawing.Color.CornflowerBlue;
                            //cell_ST.Font.ColorIndex = System.Drawing.Color.Red ;                               
                        }
                    }
                }//添加數據結束

                //最後一個工作表添加退料的Sheet
                //Worksheet sheet_return = app.Worksheets[sheet_total + 1] as Worksheet;
                Worksheet sheetReturn = app.Worksheets[2] as Worksheet;
                sheetReturn.Name = "外發退料";
                sheetReturn.Cells[1, 1] = "單據編號";
                sheetReturn.Cells[1, 2] = "供應商編號";
                sheetReturn.Cells[1, 3] = "供應商名稱";
                sheetReturn.Cells[1, 4] = "退貨日期";
                sheetReturn.Cells[1, 5] = "頁數";
                sheetReturn.Cells[1, 6] = "貨品編號";
                sheetReturn.Cells[1, 7] = "貨品名稱";
                sheetReturn.Cells[1, 8] = "貨品編號(加工後)";
                sheetReturn.Cells[1, 9] = "退貨數量";
                sheetReturn.Cells[1, 10] = "退貨重量";

                //添加數據
                if (dtOutReurn.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = dtOutReurn.Rows.Count;
                    //***************

                    int row = dtOutReurn.Rows.Count;
                    int col = dtOutReurn.Columns.Count;
                    for (int k = 0; k < row; k++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        sheetReturn.Rows.RowHeight = 20; //行高  
                        sheetReturn.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            string str = dtOutReurn.Rows[k][j].ToString();
                            sheetReturn.Cells[k + 2, j + 1] = str;
                        }
                    }
                }

                //保存工作簿                   
                wBook.Save();
                //保存excel文件   
                app.Save(filePath);
                app.SaveWorkspace(filePath);
                app.Quit();
                wBook = null;
                sheet = null;
                sheetReturn = null;
                app = null;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        static bool SaveDataTableToExcel_rpt2(System.Data.DataTable excelTable, string filePath, ProgressBar progressBar1, bool isArt)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                app.Visible = false;
                Workbook wBook = app.Workbooks.Add(true);
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet;
                if (excelTable.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = excelTable.Rows.Count;
                    //***************

                    int row = excelTable.Rows.Count;
                    string cell_art;
                    int col = excelTable.Columns.Count;
                    for (int i = 0; i < row; i++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        wSheet.Rows.RowHeight = 55; //行高
                        wSheet.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            string str = excelTable.Rows[i][j].ToString();
                            if (j != 8)//第9欄爲圖樣所在的欄
                            {
                                wSheet.Cells[i + 2, j + 1] = str;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(str) && File.Exists(str))
                                {
                                    if (isArt)
                                    {
                                        cell_art = "I" + (i + 2); //圖樣單元格坐標,從第二行開始
                                        Range pic2 = wSheet.get_Range(cell_art, Missing.Value);
                                        pic2.Select();
                                        float picleft, pictop;
                                        picleft = Convert.ToSingle(pic2.Left) + 5;
                                        pictop = Convert.ToSingle(pic2.Top) + 5;
                                        wSheet.Shapes.AddPicture(str, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, picleft, pictop, 45, 45);
                                    }
                                }
                            }
                        }
                    }
                }

                //第一行設置表頭名稱
                int size = excelTable.Columns.Count;
                for (int i = 0; i < size; i++)
                {
                    // wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName;
                    string col_name = excelTable.Columns[i].ColumnName;
                    switch (col_name)
                    {
                        case "vendor_id":
                            wSheet.Cells[1, 1 + i] = "客戶編號";
                            break;
                        case "id":
                            wSheet.Cells[1, 1 + i] = "單據編號";
                            break;
                        case "issue_date":
                            wSheet.Cells[1, 1 + i] = "收貨日期";
                            break;
                        case "issue_date_ok":
                            wSheet.Cells[1, 1 + i] = "電回天數";
                            break;
                        case "mo_type":
                            wSheet.Cells[1, 1 + i] = "狀態";
                            break;
                        case "mo_id":
                            wSheet.Cells[1, 1 + i] = "制單編號";
                            break;
                        case "goods_id":
                            wSheet.Cells[1, 1 + i] = "物料編號";
                            break;
                        case "name":
                            wSheet.Cells[1, 1 + i] = "物料名稱";
                            break;
                        case "artwork":
                            wSheet.Cells[1, 1 + i] = "圖樣";
                            break;
                        case "do_color":
                            wSheet.Cells[1, 1 + i] = "顏色做法";
                            break;
                        case "plan_qty":
                            wSheet.Cells[1, 1 + i] = "生產數量";
                            break;
                        case "order_qty":
                            wSheet.Cells[1, 1 + i] = "訂單數量";
                            break;
                        case "c_qty_ok":
                            wSheet.Cells[1, 1 + i] = "完成數量";
                            break;
                        case "prod_qty":
                            wSheet.Cells[1, 1 + i] = "最後一次入庫數量";
                            break;
                        case "sec_qty":
                            wSheet.Cells[1, 1 + i] = "最後一次入庫重量";
                            break;
                        case "in_qty_total":
                            wSheet.Cells[1, 1 + i] = "總收貨數量";
                            break;
                        case "in_sec_qty_total":
                            wSheet.Cells[1, 1 + i] = "總收貨重量";
                            break;
                        case "out_qty_total":
                            wSheet.Cells[1, 1 + i] = "最後一次交下部門數量";
                            break;
                        case "out_sec_qty_total":
                            wSheet.Cells[1, 1 + i] = "最後一次交下部門重量";
                            break;
                        case "next_wp_id":
                            wSheet.Cells[1, 1 + i] = "下部門";
                            break;
                        case "dept_reply":
                            wSheet.Cells[1, 1 + i] = "部門回覆";
                            break;
                        default:
                            break;
                    }
                }
                //设置禁止弹出保存和覆盖的询问提示框   
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //保存工作簿                   
                wBook.Save();
                //保存excel文件   
                app.Save(filePath);
                app.SaveWorkspace(filePath);
                app.Quit();
                wSheet = null;
                wBook = null;
                app = null;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public static string ExpToExcelByVendor(System.Data.DataTable dtExcel, System.Data.DataTable dtVendor)
        {
            string result = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            string fileName = "XXX外發加工每日追貨表" + DateTime.Now.Date.ToString("yyyyMMdd");
            saveFile.FileName = fileName;
            saveFile.Filter = "Excel files(*.xlsx)|*.xlsx";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFile.FileName;
            }
            else
            {
                fileName = "";
            }
            if (fileName != "")
            {
                string vendor_id = "", vendor_name = "", title = "", sheet_name = "", fileNameNew = "";
                string imgLogo = Environment.CurrentDirectory + @"\images\logo.bmp";                
                for (int i = 0; i < dtVendor.Rows.Count; i++)
                {
                    vendor_id = dtVendor.Rows[i]["vendor_id"].ToString();
                    vendor_name = dtVendor.Rows[i]["vendor_name"].ToString();
                    vendor_name = string.IsNullOrEmpty(vendor_name) ? vendor_id : vendor_name;
                    fileNameNew = fileName;
                    fileNameNew = fileNameNew.Replace("XXX", vendor_name+"-");
                    //string picPath = DBUtility.GetArtWorkPath();
                    System.Data.DataTable dtNewExcel = new System.Data.DataTable();
                    DataView dv = dtExcel.DefaultView;                                       
                    using (var package = new ExcelPackage())
                    {                           
                       for (int x = 0; x < 2; x++)
                       {
                            if (x == 0)
                            {
                                //sheet1
                                //設置過慮條件
                                dv.RowFilter = $"vendor_id ='{ vendor_id } ' And id_return='P'";
                                sheet_name = "正單";
                                title = "外發加工每日追貨單";
                                dtNewExcel = dv.ToTable();
                            }
                            else
                            {
                                //sheet2
                                dv.RowFilter = $"vendor_id ='{ vendor_id }' And id_return='R'";
                                sheet_name = "返電單";
                                title = "返電單";
                                dtNewExcel = dv.ToTable(); 
                            }
                            var worksheet = package.Workbook.Worksheets.Add(sheet_name); //var worksheet,這里是只是一個引用地址，是指向package.Workbook.Worksheets
                            worksheet.PrinterSettings.PaperSize = ePaperSize.A4; // 设置纸张为 A4
                            worksheet.PrinterSettings.Orientation = eOrientation.Portrait; // 设置页面纵向
                            // worksheet.PrinterSettings.Orientation = eOrientation.Landscape; // 设置页面横向
                            worksheet.PrinterSettings.TopMargin = (decimal)(0.17 / 2.54);    // 上边距，0.17 厘米
                            worksheet.PrinterSettings.BottomMargin = (decimal)(0.17 / 2.54); // 下边距，0.17 厘米
                            worksheet.PrinterSettings.LeftMargin = (decimal)(0.17 / 2.54);   // 左边距，0.17 厘米
                            worksheet.PrinterSettings.RightMargin = (decimal)(0.17 / 2.54);  // 右边距，0.17 厘米                                
                            // 设置合并单元格
                            worksheet.Cells["E2:F2"].Merge = true; // 合并 E2:F2
                            worksheet.Cells["E2"].Value = "公司 : 精豐";
                            worksheet.Cells["I2:J2"].Merge = true; // 合并 I2:J2
                            worksheet.Cells["I2"].Value = "聯絡人: 盧志豪";
                            worksheet.Cells["I2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left; // 水平居左
                            worksheet.Cells["L2:O2"].Merge = true; // 合并 L2:O2
                            worksheet.Cells["L2"].Value = System.DateTime.Now.ToString("yyyy.MM.dd");
                            worksheet.Cells["H2"].Value = $"共有{dtNewExcel.Rows.Count}單";
                            worksheet.Cells["E4:G4"].Merge = true; // 合并 E4:G4
                            worksheet.Cells["E4"].Value = $"供應商：{dtVendor.Rows[i]["vendor_name"].ToString()}";
                            worksheet.Cells["I4:J4"].Merge = true; // 合并 I4:J4
                            worksheet.Cells["I4"].Value = $"聯絡人 :{dtVendor.Rows[i]["linkman"].ToString()}";
                            worksheet.Cells["I4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left; // 水平居左
                            worksheet.Cells["K4:O4"].Merge = true; // 合并 K4:O4
                            worksheet.Cells["K4"].Value = "注 : 請在次日上午回復";//??
                            worksheet.Cells["A6:O6"].Merge = true; // 合并 A6 到 O6                        
                            worksheet.Cells["A6"].Value = title; // 设置值                                                                                                                                             // 设置合并单元格的样式（可选）
                            worksheet.Cells["A1:O7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中
                            worksheet.Cells["A1:O7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;   // 垂直居中
                            worksheet.Cells["A1:O7"].Style.Font.Bold = true; // 设置字体加粗
                            worksheet.Row(1).Height = 24;//设置行高度
                            worksheet.Row(2).Height = 24;
                            worksheet.Row(3).Height = 24;
                            worksheet.Row(4).Height = 24;
                            worksheet.Row(5).Height = 24;
                            worksheet.Row(6).Height = 35;
                            worksheet.Row(7).Height = 42;

                            //插入LOGO圖片
                            worksheet.Cells["B2:C5"].Merge = true; // 合并 B2:C5                                                                        
                            string imagePath = imgLogo;//string imagePath = drExcel["图片路径"].ToString();
                            if (File.Exists(imagePath)) // 确保图片路径有效
                            {
                                var picture = worksheet.Drawings.AddPicture($"Image{1}", new FileInfo(imagePath));
                                picture.SetPosition(1, -15, 1, 6); // 设置图片位置
                                picture.SetSize(120, 120);         // 设置图片大小
                            }
                            //worksheet.Row(1).Height = 50; // 设置第 1 行的高度为 20 点                                 
                            int excelRow = 7;
                            //prgStatus.Minimum = 0;
                            //prgStatus.Value = 0;
                            //填充表頭樣位與數據區
                            FillExcel(worksheet, dtNewExcel, excelRow, x);
                            string cellRange = "H2";
                            SetCellBackgroundColor(worksheet, cellRange, Color.LightGreen);
                            cellRange = $"L2:O2";
                            SetCellBackgroundColor(worksheet, cellRange, Color.Yellow);
                            cellRange = $"K4:O4";
                            SetCellBackgroundColor(worksheet, cellRange, Color.Yellow);
                            cellRange = $"A6:O6";
                            if (x == 0)
                            {
                                SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(255, 204, 153));//自定義橙色
                            }
                            else
                            {
                                SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(255, 255, 153));//自定義淺黃色
                                SetCellFontColor(worksheet, "I7", Color.Red);// 设置单元格的字体颜色为红色
                                SetCellFontColor(worksheet, "J7", Color.Red);// 设置单元格的字体颜色为红色                                
                                //cell.Style.Font.Bold = true; // 设置字体为粗体                                
                            }
                            cellRange = $"A7:O7";
                            SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(204, 255, 255));//自定義淺藍色
                            cellRange = $"J7";
                            SetCellBackgroundColor(worksheet, cellRange, Color.Yellow);
                            cellRange = $"L7";
                            SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(180, 130, 218));//自定義淺紫色
                        } //--enf of for(x=0;x<2;x++)
                        FileInfo file = new FileInfo(fileNameNew);
                        package.SaveAs(file);//保存Excel文件                       
                    } //end of using()                    
                } //--enf of for (int i=0;i<dtVendor.Rows.Count;i++)
                MessageBox.Show("Excel文件導出成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            return result;
        }

        private static void SetCellBackgroundColor(ExcelWorksheet worksheet, string cellAddress, Color color)
        {
            var cell = worksheet.Cells[cellAddress];
            var fill = cell.Style.Fill;
            fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            fill.BackgroundColor.SetColor(color);
            cell.Style.Fill = fill; // 重寫填充樣式以應用更改
        }

        private static void SetCellFontColor(ExcelWorksheet worksheet, string cellAddress, Color color)
        {
            var cell = worksheet.Cells[cellAddress];
            cell.Style.Font.Color.SetColor(color);// 设置单元格的字体颜色            
        }

        //按生產車間/組別匯出105
        private static void FillExcel(ExcelWorksheet worksheet, System.Data.DataTable dtNewExcel, int excelRow,int type)
        {
            //prgStatus.Maximum = dtNewExcel.Rows.Count;
            worksheet.Cells[excelRow, 1].Value = "序號";
            worksheet.Cells[excelRow, 2].Value = "加工單號";
            worksheet.Cells[excelRow, 3].Value = "狀態";
            worksheet.Cells[excelRow, 4].Value = "單號";
            worksheet.Cells[excelRow, 5].Value = "貨名";
            worksheet.Cells[excelRow, 6].Value = "顏色";
            worksheet.Cells[excelRow, 7].Value = "重量";
            worksheet.Cells[excelRow, 8].Value = "發貨日期";
            worksheet.Cells[excelRow, 9].Value = "電鍍廠回復日期";
            worksheet.Cells[excelRow, 10].Value = "我廠要求日期";
            worksheet.Cells[excelRow, 11].Value = "實際交回日期";
            worksheet.Cells[excelRow, 12].Value = "還欠我司重量";
            worksheet.Cells[excelRow, 13].Value = "返電原因";
            worksheet.Cells[excelRow, 14].Value = "返電";
            worksheet.Cells[excelRow, 15].Value = "備註";           
            worksheet.Row(excelRow).Height = 42; // 设置第7行的高度为42
            for (int i = 0; i < dtNewExcel.Rows.Count; i++)
            {
                //prgStatus.Value = i;
                DataRow drExcel = dtNewExcel.Rows[i];
                excelRow += 1;
                worksheet.Cells[excelRow, 1].Value = (i+1).ToString();
                worksheet.Cells[excelRow, 2].Value = drExcel["id"].ToString().Trim();
                worksheet.Cells[excelRow, 3].Value = drExcel["mo_type"].ToString();
                worksheet.Cells[excelRow, 4].Value = drExcel["mo_id"].ToString();
                worksheet.Cells[excelRow, 5].Value = drExcel["goods_name"].ToString();
                worksheet.Cells[excelRow, 6].Value = drExcel["do_color"].ToString(); 
                worksheet.Cells[excelRow, 7].Value = drExcel["sec_qty"].ToString();
                worksheet.Cells[excelRow, 8].Value = drExcel["issue_date"].ToString();//發貨日期
                worksheet.Cells[excelRow, 9].Value = ""; //電鍍廠回復日期
                worksheet.Cells[excelRow, 10].Value = drExcel["t_complete_date"];//我廠要求日期
                worksheet.Cells[excelRow, 11].Value = "";//實際交回日期
                worksheet.Cells[excelRow, 12].Value = drExcel["remark_wet"].ToString();//還欠我司重量
                worksheet.Cells[excelRow, 13].Value = (type == 0) ? "" : drExcel["remark"].ToString();//返電原因
                worksheet.Cells[excelRow, 14].Value = (type == 0) ? "" : drExcel["return_total"].ToString();//返電次數
                worksheet.Cells[excelRow, 15].Value = "";
                /*
                //string imagePath = drExcel["图片路径"].ToString();
                string imagePath = picPath + drExcel["art_image"].ToString().Trim();
                if (File.Exists(imagePath)) // 确保图片路径有效
                {
                    var picture = worksheet.Drawings.AddPicture($"Image{excelRow - 1}", new FileInfo(imagePath));
                    picture.SetPosition(excelRow - 1, 0, 15, 0); // 设置图片位置
                    picture.SetSize(60, 60);          // 设置图片大小
                }
                worksheet.Row(excelRow).Height = 50; // 设置第 1 行的高度为 20 点
                */
            }
            worksheet.Column(1).Width = 4.5;
            worksheet.Column(2).Width = 14.5;
            worksheet.Column(3).Width = 9;
            worksheet.Column(4).Width = 11;
            worksheet.Column(5).Width = 36;
            worksheet.Column(6).Width = 19;
            worksheet.Column(7).Width = 9;
            worksheet.Column(8).Width = 11;
            worksheet.Column(9).Width = 11;
            worksheet.Column(10).Width = 9;
            worksheet.Column(11).Width = 9;
            worksheet.Column(12).Width = 9;
            worksheet.Column(13).Width = 19;
            worksheet.Column(14).Width = 5;
            worksheet.Column(15).Width = 17;

            /*
            //Cells[excelRow, 13]
            // 设置动态范围
            string colStr = $"H1:H{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"I1:I{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"J1:J{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"K1:K{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            //worksheet.Cells["B1:B10"].Style.Numberformat.Format = "#,##0.00"; // 千分位小数格式
            //worksheet.Cells["C1:C10"].Style.Numberformat.Format = "$#,##0.00"; // 千分位货币格式           

            // 设置某一列不可见
            //worksheet.Column(6).Hidden = true; // 隐藏物料編號
            //worksheet.Row(2).Height = 40; // 设置第 1 行的高度为 20 点
            */
            //某列居中
            int rowEnd = dtNewExcel.Rows.Count;
            if (rowEnd > 0)
            {
                string cellRang = $"A8:O{7 + rowEnd}";
                worksheet.Cells[cellRang].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中                
            }

            // 动态确定表格范围
            //string tableRange = $"A1:R{worksheet.Dimension.End.Row}"; // 表格范围
            string tableRange = $"A6:{ExcelAddress.GetAddress(worksheet.Dimension.End.Row, worksheet.Dimension.End.Column)}";
            var tableCells = worksheet.Cells[tableRange];

            // 为整个表格添加边框
            tableCells.Style.Border.BorderAround(ExcelBorderStyle.Thick); // 表格外边框设置为粗线
            tableCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;    // 表格顶部边框
            tableCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; // 表格底部边框
            tableCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;   // 表格左边边框
            tableCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;  // 表格右边边框            
            tableCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; //垂直居中
            // 设置整个表格的字体大小
            tableCells.Style.Font.Size = 10; // 设置字体大小为10
            tableCells.Style.Font.Name = "新細明體";
            worksheet.Cells["A6:O6"].Style.Font.Size = 14; // 设置字体大小为10
            // 设置整个表格内容自动换行
            tableCells.Style.WrapText = true;
            // 冻结第一行
            worksheet.View.FreezePanes(8, 2); // 从第7行、第1列开始滚动，冻结第一行
            // 设置打印标题行（固定第 1~7 行为标题）
            worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:7"]; // 固定标题为第1~7行
            worksheet.PrinterSettings.Scale = 75; // 缩放到 80%
        }

        #region 報表格式1匯出到多個Sheet中
        static bool ToExcelRpt1(System.Data.DataTable excelTable, System.Data.DataTable dtOutReurn, ProgressBar progressbar1, bool isArt)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            string fileName = "外發加工追貨表" + DateTime.Now.Date.ToString("yyyyMMdd");
            saveFile.FileName = fileName;
            saveFile.Filter = "Excel files(*.xlsx)|*.xlsx";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFile.FileName;
            }
            else
            {
                fileName = "";
            }
            if(fileName == "")
            {
                return false;
            }
            string sheet_name = "", imagePath="";
            using (var package = new ExcelPackage())
            {
                for (int x = 0; x < 2; x++)
                {
                    if (x == 0)
                    {
                        //sheet1
                        sheet_name = "追貨報表";
                        var worksheet = package.Workbook.Worksheets.Add(sheet_name); //var worksheet,這里是只是一個引用地址，是指向package.Workbook.Worksheets
                        worksheet.PrinterSettings.PaperSize = ePaperSize.A4; // 设置纸张为 A4
                        worksheet.PrinterSettings.Orientation = eOrientation.Portrait; // 设置页面纵向 ,eOrientation.Landscape; // 设置页面横向                       
                        worksheet.PrinterSettings.TopMargin = (decimal)(0.17 / 2.54);    // 上边距，0.17 厘米
                        worksheet.PrinterSettings.BottomMargin = (decimal)(0.17 / 2.54); // 下边距，0.17 厘米
                        worksheet.PrinterSettings.LeftMargin = (decimal)(0.17 / 2.54);   // 左边距，0.17 厘米
                        worksheet.PrinterSettings.RightMargin = (decimal)(0.17 / 2.54);  // 右边距，0.17 厘米                                
                        worksheet.Cells[1, 1].Value = "客戶編號";
                        worksheet.Cells[1, 2].Value = "單據編號";
                        worksheet.Cells[1, 3].Value = "發貨日期";
                        worksheet.Cells[1, 4].Value = "狀態";
                        worksheet.Cells[1, 5].Value = "制單編號";
                        worksheet.Cells[1, 6].Value = "物料編號";
                        worksheet.Cells[1, 7].Value = "圖樣";
                        worksheet.Cells[1, 8].Value = "物料名稱";
                        worksheet.Cells[1, 9].Value = "顏色做法";
                        worksheet.Cells[1, 10].Value = "計划回港日期";
                        worksheet.Cells[1, 11].Value = "生產數量";
                        worksheet.Cells[1, 12].Value = "訂單數量";
                        worksheet.Cells[1, 13].Value = "完成數量";
                        worksheet.Cells[1, 14].Value = "發貨數量";
                        worksheet.Cells[1, 15].Value = "發貨重量";
                        worksheet.Cells[1, 16].Value = "總的發貨數量";
                        worksheet.Cells[1, 17].Value = "總的發貨重量";
                        worksheet.Cells[1, 18].Value = "總的收貨數量";
                        worksheet.Cells[1, 19].Value = "總的收貨重量";
                        worksheet.Cells[1, 20].Value = "差額數量";
                        worksheet.Cells[1, 21].Value = "差額重量";
                        worksheet.Cells[1, 22].Value = "備註";
                        worksheet.Cells[1, 23].Value = "返電次數";
                        worksheet.Cells[1, 24].Value = "部門回覆";
                        worksheet.Cells[1, 25].Value = "PMC回覆";
                        worksheet.Cells["A1:Y1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中
                        worksheet.Cells["A1:Y1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;   // 垂直居中
                        worksheet.Cells["A1:Y1"].Style.Font.Bold = true; // 设置字体加粗
                        worksheet.Row(1).Height = 40;//设置行高度                                                                     
                       
                        progressbar1.Enabled = true;
                        progressbar1.Visible = true;
                        progressbar1.Value = 0;
                        progressbar1.Step = 1;
                        progressbar1.Maximum = excelTable.Rows.Count;
                        //填充表頭樣位與數據區
                        int excelRow = 1;
                        DataRow drExcel;
                        for (int i = 0; i < excelTable.Rows.Count; i++)
                        {
                            progressbar1.Value = i;
                            //顯示進度條
                            progressbar1.Value += progressbar1.Step;
                            if (progressbar1.Value == progressbar1.Maximum)
                            {
                                progressbar1.Enabled = false;
                                progressbar1.Visible = false;
                            }
                            drExcel = excelTable.Rows[i];
                            excelRow += 1;                           
                            worksheet.Cells[excelRow, 1].Value = drExcel["vendor_id"].ToString();
                            worksheet.Cells[excelRow, 2].Value = drExcel["id"].ToString().Trim();
                            worksheet.Cells[excelRow, 3].Value = drExcel["issue_date"].ToString();
                            worksheet.Cells[excelRow, 4].Value = drExcel["mo_type"].ToString();
                            worksheet.Cells[excelRow, 5].Value = drExcel["mo_id"].ToString();
                            worksheet.Cells[excelRow, 6].Value = drExcel["goods_id"].ToString();
                            worksheet.Cells[excelRow, 8].Value = drExcel["goods_name"].ToString();
                            worksheet.Cells[excelRow, 9].Value = drExcel["do_color"].ToString(); 
                            worksheet.Cells[excelRow, 10].Value = drExcel["date_hk"].ToString();//"計划回港日期";
                            worksheet.Cells[excelRow, 11].Value = clsPublic.ReturnFloat2(drExcel["plan_qty"].ToString());//計劃數量
                            worksheet.Cells[excelRow, 12].Value = clsPublic.ReturnFloat2(drExcel["order_qty"].ToString());//訂單數量
                            worksheet.Cells[excelRow, 13].Value = clsPublic.ReturnFloat2(drExcel["c_qty_ok"].ToString());//完成數量
                            worksheet.Cells[excelRow, 14].Value = clsPublic.ReturnFloat2(drExcel["prod_qty"].ToString());//發貨數量
                            worksheet.Cells[excelRow, 15].Value = clsPublic.ReturnFloat2(drExcel["sec_qty"].ToString());
                            worksheet.Cells[excelRow, 16].Value = clsPublic.ReturnFloat2(drExcel["out_qty_total"].ToString()); 
                            worksheet.Cells[excelRow, 17].Value = clsPublic.ReturnFloat2(drExcel["out_sec_qty_total"].ToString()); 
                            worksheet.Cells[excelRow, 18].Value = clsPublic.ReturnFloat2(drExcel["in_qty_total"].ToString()); 
                            worksheet.Cells[excelRow, 19].Value = clsPublic.ReturnFloat2(drExcel["in_sec_qty_total"].ToString());
                            worksheet.Cells[excelRow, 20].Value = clsPublic.ReturnFloat2(drExcel["qty_differ"].ToString()); 
                            worksheet.Cells[excelRow, 21].Value = clsPublic.ReturnFloat2(drExcel["sec_qty_differ"].ToString());
                            worksheet.Cells[excelRow, 22].Value = drExcel["remark"].ToString();
                            worksheet.Cells[excelRow, 23].Value = drExcel["return_total"].ToString();
                            worksheet.Cells[excelRow, 24].Value = drExcel["dept_reply"].ToString(); 
                            worksheet.Cells[excelRow, 25].Value = drExcel["pmc_reply"].ToString();
                            if (isArt)
                            {
                                worksheet.Row(excelRow).Height = 45; // 设置行高度为45
                                worksheet.Column(7).Width = 8;
                                //string imagePath = drExcel["图片路径"].ToString();
                                imagePath = drExcel["artwork"].ToString(); //"圖樣";
                                if (File.Exists(imagePath)) // 确保图片路径有效
                                {
                                    //行數是從0~N行,列也是從0~N列
                                    var picture = worksheet.Drawings.AddPicture($"Image{excelRow-1}", new FileInfo(imagePath));
                                    picture.SetPosition(excelRow-1, 5, 7-1, 5); // 设置图片位置
                                    picture.SetSize(50, 50);          // 设置图片大小，實際相當于40x40
                                }
                            }
                            else
                            {
                                worksheet.Row(excelRow).Height = 20; // 设置行高度为20
                                worksheet.Cells[excelRow, 7].Value = "";
                            }
                        } //--end for  
                        string cellRange = "";
                        //標題行居中
                        int rowEnd = excelTable.Rows.Count;
                        if (rowEnd > 0)
                        {
                            rowEnd = rowEnd + 1;
                            cellRange = "A1:Y1";
                            worksheet.Cells[cellRange].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中
                            cellRange = $"N2:O{rowEnd}";
                            SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(210, 180, 140));//啡                            
                            cellRange = $"P2:Q{rowEnd}";
                            SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(255, 255, 192));//黃
                            cellRange = $"R2:S{rowEnd}";
                            SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(238, 130, 238));//粉
                            cellRange = $"T2:U{rowEnd}";
                            SetCellBackgroundColor(worksheet, cellRange, Color.FromArgb(100, 149, 237));//藍

                            // 动态确定表格范围
                            //string tableRange = $"A1:R{worksheet.Dimension.End.Row}"; // 表格范围
                            //string tableRange = $"A2:{ExcelAddress.GetAddress(worksheet.Dimension.End.Row, worksheet.Dimension.End.Column)}";
                            cellRange = $"A1:Y{rowEnd}";
                            var tableCells = worksheet.Cells[cellRange];
                            // 为整个表格添加边框
                            tableCells.Style.Border.BorderAround(ExcelBorderStyle.Thick); // 表格外边框设置为粗线
                            tableCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;    // 表格顶部边框
                            tableCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; // 表格底部边框
                            tableCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;   // 表格左边边框
                            tableCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;  // 表格右边边框            
                            tableCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // 垂直居中                                                                                                                    
                            tableCells.Style.Font.Size = 10; //设置整个表格的字体大小, 设置字体大小为10
                            tableCells.Style.Font.Name = "新細明體";
                            tableCells.Style.WrapText = true; // 设置整个表格内容自动换行
                        }
                        worksheet.Column(1).Width = 9.57;
                        worksheet.Column(2).Width = 12.43;
                        worksheet.Column(3).Width = 10;
                        worksheet.Column(4).Width = 8;
                        worksheet.Column(5).Width = 10;
                        worksheet.Column(6).Width = 21;
                        worksheet.Column(8).Width = 27;
                        worksheet.Column(9).Width = 18;
                        worksheet.Column(10).Width = 8.71;
                        worksheet.Column(11).Width = 6.29;
                        worksheet.Column(12).Width = 6.29;
                        worksheet.Column(13).Width = 6.29;
                        worksheet.Column(14).Width = 6.29;
                        worksheet.Column(15).Width = 6.29;
                        worksheet.Column(16).Width = 7.43;
                        worksheet.Column(17).Width = 7.43;
                        worksheet.Column(18).Width = 7.43;
                        worksheet.Column(19).Width = 7.43;
                        worksheet.Column(20).Width = 6.29;
                        worksheet.Column(21).Width = 6.29;
                        worksheet.Column(22).Width = 13;
                        worksheet.Column(23).Width = 6;
                        worksheet.Column(24).Width = 6;
                        worksheet.Column(25).Width = 6;
                        cellRange = "A1:Y1";
                        worksheet.Cells[cellRange].Style.Font.Size = 10; // 设置字体大小为10
                        worksheet.Cells[cellRange].Style.WrapText = true;//標題欄内容自动换行
                        

                        // 冻结第一行
                        worksheet.View.FreezePanes(2, 2); // 从第7行、第2列开始滚动，冻结第一行
                        // 设置打印标题行（固定第 1~1 行为标题）
                        worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:1"]; // 固定标题为第1~1行
                        worksheet.PrinterSettings.Scale = 75; // 缩放到 80%
                    }
                    else
                    {
                        //sheet2                       
                        sheet_name = "外發退料";
                        var worksheet = package.Workbook.Worksheets.Add(sheet_name); //var worksheet,這里是只是一個引用地址，是指向package.Workbook.Worksheets
                        worksheet.PrinterSettings.PaperSize = ePaperSize.A4; // 设置纸张为 A4
                        worksheet.PrinterSettings.Orientation = eOrientation.Portrait; // 设置页面纵向,eOrientation.Landscape; // 设置页面横向
                        worksheet.PrinterSettings.TopMargin = (decimal)(0.17 / 2.54);    // 上边距，0.17 厘米
                        worksheet.PrinterSettings.BottomMargin = (decimal)(0.17 / 2.54); // 下边距，0.17 厘米
                        worksheet.PrinterSettings.LeftMargin = (decimal)(0.17 / 2.54);   // 左边距，0.17 厘米
                        worksheet.PrinterSettings.RightMargin = (decimal)(0.17 / 2.54);  // 右边距，0.17 厘米                          
                        worksheet.Cells[1, 1].Value = "單據編號";
                        worksheet.Cells[1, 2].Value = "供應商編號";
                        worksheet.Cells[1, 3].Value = "供應商名稱";
                        worksheet.Cells[1, 4].Value = "退貨日期";
                        worksheet.Cells[1, 5].Value = "頁數";
                        worksheet.Cells[1, 6].Value = "貨品編號";
                        worksheet.Cells[1, 7].Value = "貨品名稱";
                        worksheet.Cells[1, 8].Value = "貨品編號(加工後)";
                        worksheet.Cells[1, 9].Value = "退貨數量";
                        worksheet.Cells[1, 10].Value = "退貨重量";
                        string cellRange = "A1:J1";
                        worksheet.Cells[cellRange].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中
                        worksheet.Cells[cellRange].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;   // 垂直居中
                        worksheet.Cells[cellRange].Style.Font.Bold = true; // 设置字体加粗
                        worksheet.Row(1).Height = 24;//设置行高度   

                        progressbar1.Enabled = true;
                        progressbar1.Visible = true;
                        progressbar1.Value = 0;
                        progressbar1.Step = 1;
                        progressbar1.Maximum = dtOutReurn.Rows.Count;
                        int excelRow = 1;
                        DataRow drExcel;
                        for (int i = 0; i < dtOutReurn.Rows.Count; i++)
                        {
                            //顯示進度條
                            progressbar1.Value += progressbar1.Step;
                            if (progressbar1.Value == progressbar1.Maximum)
                            {
                                progressbar1.Enabled = false;
                                progressbar1.Visible = false;
                            }
                            drExcel = dtOutReurn.Rows[i];
                            excelRow += 1;
                            worksheet.Cells[excelRow, 1].Value = drExcel["id"].ToString();
                            worksheet.Cells[excelRow, 2].Value = drExcel["vendor_id"].ToString().Trim();
                            worksheet.Cells[excelRow, 3].Value = drExcel["vendor_name"].ToString();
                            worksheet.Cells[excelRow, 4].Value = drExcel["ir_date"].ToString();
                            worksheet.Cells[excelRow, 5].Value = drExcel["mo_id"].ToString();
                            worksheet.Cells[excelRow, 6].Value = drExcel["goods_id"].ToString();
                            worksheet.Cells[excelRow, 7].Value = drExcel["goods_name"].ToString();
                            worksheet.Cells[excelRow, 8].Value = drExcel["goods_id_f"].ToString();
                            worksheet.Cells[excelRow, 9].Value = clsPublic.ReturnFloat2(drExcel["qty"].ToString());
                            worksheet.Cells[excelRow, 10].Value = clsPublic.ReturnFloat2(drExcel["sec_qty"].ToString());
                            worksheet.Row(excelRow).Height = 20; // 设置行高度为20  
                        }
                        
                        int rowEnd = dtOutReurn.Rows.Count;
                        if (rowEnd > 0)
                        {
                            // 动态确定表格范围
                            //string tableRange = $"A1:R{worksheet.Dimension.End.Row}"; // 表格范围
                            //string tableRange = $"A1:{ExcelAddress.GetAddress(worksheet.Dimension.End.Row, worksheet.Dimension.End.Column)}";
                            cellRange = $"A1:J{rowEnd + 1}";
                            var tableCells = worksheet.Cells[cellRange];
                            // 为整个表格添加边框
                            tableCells.Style.Border.BorderAround(ExcelBorderStyle.Thick); // 表格外边框设置为粗线
                            tableCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;    // 表格顶部边框
                            tableCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; // 表格底部边框
                            tableCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;   // 表格左边边框
                            tableCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;  // 表格右边边框            
                            tableCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // 垂直居中                                                                                                                    
                            tableCells.Style.Font.Size = 10; // 设置字体大小为10// 设置整个表格的字体大小
                            tableCells.Style.Font.Name = "新細明體";
                            tableCells.Style.WrapText = true; // 设置整个表格内容自动换行
                        }
                        //標題行居中
                        cellRange = "A1:J1";
                        worksheet.Cells[cellRange].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中   
                        worksheet.Cells[cellRange].Style.Font.Size = 10; // 设置字体大小为10 
                        // 冻结第一行
                        worksheet.View.FreezePanes(2, 1); // 从第2行、第1列开始滚动，冻结第一行
                        // 设置打印标题行（固定第 1~7 行为标题）
                        worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:1"]; // 固定标题为第1~7行
                        worksheet.PrinterSettings.Scale = 75; // 缩放到 80%
                    }

                } //--enf of for(x=0;x<2;x++)                
                FileInfo file = new FileInfo(fileName);
                package.SaveAs(file); //保存Excel文件 
            } //end of using()

            return true;
        }
        #endregion
    }
}
