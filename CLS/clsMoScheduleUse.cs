using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Data;
//using OfficeOpenXml;
//using OfficeOpenXml.Drawing;

namespace cf01.CLS
{
    public static class clsMoScheduleUse
    {
        

        public static string DataToExcel(string fileName,System.Data.DataTable dtExcel)
        {
            

            string result = "";

            //filePath = savePath + fileName;
            result = fileName;// excelFileName;
            try
            {
                // 创建Excel应用程序对象
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                var ev = excel.Version;
                //excel.Visible = true;       //激活Excel
                Workbook wBook = excel.Workbooks.Add(true);
                Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;
                //var wSheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.ActiveSheet;
                int excelRow = 1;
                int total_cols = 13;//總列數
                wSheet.Cells[excelRow, 1] = "部門排期表";
                Range titleRange = wSheet.Range[wSheet.Cells[excelRow, 1], wSheet.Cells[excelRow, total_cols]];
                titleRange.MergeCells = true;//合併單元格
                titleRange.Font.Size = 10;
                titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中  
                wSheet.Rows[excelRow].RowHeight = 30;
                excelRow++;
                wSheet.Cells[excelRow, 1] = "序號";
                wSheet.Cells[excelRow, 2] = "制單編號";
                wSheet.Cells[excelRow, 3] = "排期日期";
                wSheet.Cells[excelRow, 4] = "狀態";
                wSheet.Cells[excelRow, 5] = "圖樣";
                wSheet.Cells[excelRow, 6] = "PMC要求日期";
                wSheet.Cells[excelRow, 7] = "訂單數量";
                wSheet.Cells[excelRow, 8] = "要求數量";
                wSheet.Cells[excelRow, 9] = "部門复期";
                wSheet.Cells[excelRow, 10] = "完成數量";
                wSheet.Cells[excelRow, 11] = "未完成數量";
                wSheet.Cells[excelRow, 12] = "供應商";
                wSheet.Cells[excelRow, 13] = "下部門";
                wSheet.Rows[excelRow].RowHeight = 30;
                excelRow++;
                string picPath = DBUtility.imagePath;// context.Server.MapPath("~/") + "images\\";
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    DataRow dr = dtExcel.Rows[i];
                    
                    wSheet.Cells[excelRow, 1] = "\'" + dr["schedule_seq"].ToString();
                    wSheet.Cells[excelRow, 2] = dr["prd_mo"].ToString();
                    wSheet.Cells[excelRow, 3] = "\'" + dr["schedule_date"].ToString(); 
                    wSheet.Cells[excelRow, 4] = dr["urgent_flag"].ToString();
                    wSheet.Cells[excelRow, 5] = "";
                    wSheet.Cells[excelRow, 6] = "\'" + dr["pmc_rq_date"].ToString(); 
                    wSheet.Cells[excelRow, 7] = dr["order_qty"].ToString();
                    wSheet.Cells[excelRow, 8] = dr["pl_qty"].ToString();
                    wSheet.Cells[excelRow, 9] = "\'" + dr["dep_rp_date"].ToString();
                    wSheet.Cells[excelRow, 10] = dr["prd_qty"].ToString();
                    wSheet.Cells[excelRow, 11] = dr["not_cp_qty"].ToString();
                    wSheet.Cells[excelRow, 12] = dr["next_vend_id"].ToString();
                    wSheet.Cells[excelRow, 13] = "'"+dr["next_wp_id"].ToString();
                    string imagePath = picPath + dr["art_image"].ToString().Trim();
                    if (File.Exists(imagePath))
                    {
                        Microsoft.Office.Interop.Excel.Range cell = wSheet.Cells[excelRow, 5]; // 设置插入图片的位置
                        Microsoft.Office.Interop.Excel.Shape picture = wSheet.Shapes.AddPicture(
                            imagePath,
                            Microsoft.Office.Core.MsoTriState.msoFalse,  // 链接到文件
                            Microsoft.Office.Core.MsoTriState.msoCTrue,  // 保存图片
                            (float)cell.Left,
                            (float)cell.Top,
                            45, // 图片宽度
                            45  // 图片高度
                        );
                    }

                    wSheet.Rows[excelRow].RowHeight = 50;
                    
                    excelRow++;
                }

                ////标题  
                //for (int i = 0; i < 27; i++)
                //{
                //    Microsoft.Office.Interop.Excel.Range titleRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, i + 1]];//选中标题  
                //    titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中  
                //}
                excelRow--;//退回一行


                //设置边框
                Microsoft.Office.Interop.Excel.Range allRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[excelRow, total_cols]];
                allRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                allRange.Font.Size = 10;
                allRange.WrapText = true;
                ////////带有千位分隔符、2位小数和减号的标准数字格式
                ////////rng.NumberFormat = "# ##0.00:-# ##0.00"
                allRange = wSheet.Range[wSheet.Cells[2, 7], wSheet.Cells[excelRow, 7]];
                allRange.NumberFormat = "###,###,###";
                allRange = wSheet.Range[wSheet.Cells[2, 8], wSheet.Cells[excelRow, 8]];
                allRange.NumberFormat = "###,###,###";
                allRange = wSheet.Range[wSheet.Cells[2, 10], wSheet.Cells[excelRow, 10]];
                allRange.NumberFormat = "###,###,###";
                allRange = wSheet.Range[wSheet.Cells[2, 11], wSheet.Cells[excelRow, 11]];
                allRange.NumberFormat = "###,###,###";
                //allRange = wSheet.Range[wSheet.Cells[2, 9], wSheet.Cells[excelRow, 9]];
                //allRange.NumberFormat = "###,##0.00";
                wSheet.Columns[1].ColumnWidth = 4;
                wSheet.Columns[2].ColumnWidth = 9;
                wSheet.Columns[3].ColumnWidth = 9;
                wSheet.Columns[4].ColumnWidth = 6;
                wSheet.Columns[5].ColumnWidth = 8;
                wSheet.Columns[6].ColumnWidth = 10;
                wSheet.Columns[7].ColumnWidth = 7;
                wSheet.Columns[8].ColumnWidth = 7;
                wSheet.Columns[9].ColumnWidth = 7;
                wSheet.Columns[10].ColumnWidth = 7;
                wSheet.Columns[11].ColumnWidth = 7;
                wSheet.Columns[12].ColumnWidth = 7;
                wSheet.Columns[13].ColumnWidth = 6;

                //wSheet.Columns.EntireColumn.AutoFit();//列宽自适应

                //wSheet.Columns[1].Hidden = true;
                //wSheet.Columns[2].Hidden = true;

                // 设置禁止弹出保存和覆盖的询问提示框
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                //保存工作薄

                //wBook.Save();

                //每次保存激活的表，这样才能多次操作保存不同的Excel表，默认保存位置是在”我的文档"
                //excel.ActiveWorkbook.SaveCopyAs(filePath);
                //wBook.SaveAs(filePath + fileName);
                object m_objOpt = Missing.Value;
                wBook.SaveAs(fileName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                wBook.Close();
                wBook = null;
                NAR(wBook);
                excel.Quit();
                excel = null;
                NAR(excel);
                GC.Collect();

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            //if (result == "")
            //    result = "已匯出數據到Excel文件!";
            return result;
        }

        private static void NAR(object o)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o) > 0) ;
            }
            catch { }
            finally
            {
                o = null;
            }
        }


    }
}
