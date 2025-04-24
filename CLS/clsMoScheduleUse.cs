using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Reflection;
//using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace cf01.CLS
{
    public static class clsMoScheduleUse
    {

        //////-----------------------------以下這個用傳統Excel匯出的，但速度很慢------------------------
        //public static string DataToExcel(string prd_dep, string fileName, System.Data.DataTable dtFromExcel, int rpt_type)
        //{

        //    System.Data.DataTable dtExcel = dtFromExcel.Copy();
        //    string result = "";

        //    //filePath = savePath + fileName;
        //    //result = fileName;// excelFileName;
        //    try
        //    {
        //        // 创建Excel应用程序对象
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //        //var ev = excel.Version;
        //        //excel.Visible = true;       //激活Excel

        //        Workbook wBook = excel.Workbooks.Add(true);
        //        //Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;
        //        var xlSheet = wBook.Sheets as Sheets;//Microsoft.Office.Interop.Excel.Sheets;
        //        int sheet_num = 1;
        //        string group_name = "prd_group";
        //        if (prd_dep == "322")
        //            group_name = "prd_machine";
        //        System.Data.DataTable dtGroups = dtExcel.DefaultView.ToTable(true, group_name);
        //        sheet_num = dtGroups.Rows.Count;
        //        //////如果是合金部，選擇了總表，則不用分機器，匯出所有記錄即可
        //        if (prd_dep == "322" && rpt_type == 1)
        //            sheet_num = 1;
        //        if (sheet_num > 1)
        //            xlSheet.Add(Type.Missing, xlSheet[1], sheet_num - 1, Type.Missing);//(Microsoft.Office.Interop.Excel.Worksheet)
        //        for (int sheet_seq = 0; sheet_seq < sheet_num; sheet_seq++)
        //        {
        //            int curr_sheet = sheet_seq + 1;
        //            string group_tittle = dtGroups.Rows[sheet_seq][group_name].ToString().Trim() != "" ? dtGroups.Rows[sheet_seq][group_name].ToString().Trim() : "未定組別";
        //            if (prd_dep == "322" && rpt_type == 1)
        //                group_tittle = prd_dep;
        //            else
        //                group_tittle = " ( " + group_tittle + " )";
        //            wBook.Worksheets[curr_sheet].Name = group_tittle;
        //            wBook.Sheets[curr_sheet].Activate();
        //            Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;

        //            //var wSheet = (Microsoft.Office.Interop.Excel._Worksheet)wBook.ActiveSheet;
        //            // 设置页面大小为 A4
        //            wSheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
        //            // 设置页面横向/纵向
        //            wSheet.PageSetup.Orientation = XlPageOrientation.xlPortrait; // 纵向
        //                                                                         //wSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape; // 横向
        //            wSheet.PageSetup.PrintTitleRows = "$1:$2"; // 第一行作为标题
        //            //wSheet.PageSetup.PrintTitleColumns = "$A:$A"; // 第一列作为标题（可选）

        //            wSheet.PageSetup.LeftMargin = excel.InchesToPoints(0.17); // 左边距 0.5 英寸
        //            wSheet.PageSetup.RightMargin = excel.InchesToPoints(0.17); // 右边距 0.5 英寸
        //            wSheet.PageSetup.TopMargin = excel.InchesToPoints(0.17); // 上边距 1 英寸
        //            wSheet.PageSetup.BottomMargin = excel.InchesToPoints(0.17); // 下边距 1 英寸

        //            int excelRow = 1;
        //            int total_cols = 18;//總列數
        //            if (rpt_type == 2)
        //                total_cols = 20;
        //            //////如果是合金部，選擇了總表，則不用分機器，匯出所有記錄即可

        //            wSheet.Cells[excelRow, 1] = "部門排期表" + group_tittle;
        //            Range titleRange = wSheet.Range[wSheet.Cells[excelRow, 1], wSheet.Cells[excelRow, total_cols]];
        //            titleRange.MergeCells = true;//合併單元格
        //            titleRange.Font.Size = 10;
        //            titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中  
        //            wSheet.Rows[excelRow].RowHeight = 30;
        //            System.Data.DataTable dtNewExcel = new System.Data.DataTable();
        //            DataView dv = dtExcel.DefaultView;
        //            if (prd_dep != "322")
        //                dv.RowFilter = "prd_group = " + "'" + dtGroups.Rows[sheet_seq][group_name].ToString().Trim() + "'";
        //            else
        //            {
        //                if (rpt_type == 1)
        //                    dv.RowFilter = "prd_dep = " + "'" + prd_dep + "'";
        //                else
        //                    dv.RowFilter = "prd_machine = " + "'" + dtGroups.Rows[sheet_seq][group_name].ToString().Trim() + "'";
        //            }

        //            dtNewExcel = dv.ToTable();
        //            DataToExcel102(prd_dep, excelRow, wSheet, dtNewExcel, excel, total_cols);

        //        }
        //        //保存工作薄

        //        //wBook.Save();

        //        //每次保存激活的表，这样才能多次操作保存不同的Excel表，默认保存位置是在”我的文档"
        //        //excel.ActiveWorkbook.SaveCopyAs(filePath);
        //        //wBook.SaveAs(filePath + fileName);
        //        object m_objOpt = Missing.Value;
        //        wBook.SaveAs(fileName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
        //        wBook.Close();
        //        wBook = null;
        //        NAR(wBook);
        //        excel.Quit();
        //        excel = null;
        //        NAR(excel);
        //        GC.Collect();

        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.Message;
        //    }
        //    //if (result == "")
        //    //    result = "已匯出數據到Excel文件!";
        //    return result;
        //}
        //private static void DataToExcel102(string prd_dep, int row, Worksheet wSheet, System.Data.DataTable dtExcel
        //    , Microsoft.Office.Interop.Excel.Application excel, int total_cols)
        //{
        //    int excelRow = row;
        //    excelRow++;
        //    wSheet.Cells[excelRow, 1] = "序號";
        //    wSheet.Cells[excelRow, 2] = "制單編號";
        //    wSheet.Cells[excelRow, 3] = "排期日期";
        //    wSheet.Cells[excelRow, 4] = "狀態";
        //    wSheet.Cells[excelRow, 5] = "產品編號";
        //    wSheet.Cells[excelRow, 6] = "產品描述";
        //    wSheet.Cells[excelRow, 7] = "圖片";
        //    wSheet.Cells[excelRow, 8] = "PMC要求日期";
        //    wSheet.Cells[excelRow, 9] = "訂單數量";
        //    wSheet.Cells[excelRow, 10] = "要求數量";
        //    wSheet.Cells[excelRow, 11] = "完成數量";
        //    wSheet.Cells[excelRow, 12] = "未完成數量";
        //    wSheet.Cells[excelRow, 13] = "生產數量";
        //    wSheet.Cells[excelRow, 14] = "下部門";
        //    wSheet.Cells[excelRow, 15] = "部門复期";
        //    wSheet.Cells[excelRow, 16] = "供應商";
        //    wSheet.Cells[excelRow, 17] = "部門備註";
        //    wSheet.Cells[excelRow, 18] = "PMC備註";
        //    wSheet.Rows[excelRow].RowHeight = 30;
        //    excelRow++;
        //    string picPath = DBUtility.imagePath;// context.Server.MapPath("~/") + "images\\";
        //    for (int i = 0; i < dtExcel.Rows.Count; i++)
        //    {
        //        DataRow dr = dtExcel.Rows[i];

        //        wSheet.Cells[excelRow, 1] = "\'" + dr["schedule_seq"].ToString();
        //        wSheet.Cells[excelRow, 2] = dr["prd_mo"].ToString();
        //        wSheet.Cells[excelRow, 3] = "\'" + dr["schedule_date"].ToString();
        //        wSheet.Cells[excelRow, 4] = dr["urgent_flag_cdesc"].ToString();
        //        wSheet.Cells[excelRow, 5] = dr["prd_item"].ToString(); ;
        //        wSheet.Cells[excelRow, 6] = dr["goods_name"].ToString();
        //        wSheet.Cells[excelRow, 7] = "";
        //        wSheet.Cells[excelRow, 8] = "\'" + dr["pmc_rq_date"].ToString();
        //        wSheet.Cells[excelRow, 9] = dr["order_qty"].ToString();
        //        wSheet.Cells[excelRow, 10] = dr["pl_qty"].ToString();
        //        wSheet.Cells[excelRow, 11] = dr["cp_qty"].ToString();
        //        wSheet.Cells[excelRow, 12] = dr["not_cp_qty"].ToString();
        //        wSheet.Cells[excelRow, 13] = dr["prd_qty"].ToString();
        //        wSheet.Cells[excelRow, 14] = "'" + dr["next_wp_id"].ToString();
        //        wSheet.Cells[excelRow, 15] = "\'" + dr["dep_rp_date"].ToString();
        //        wSheet.Cells[excelRow, 16] = dr["next_vend_id"].ToString();
        //        wSheet.Cells[excelRow, 17] = dr["dep_remark"].ToString();
        //        wSheet.Cells[excelRow, 18] = dr["mo_remark"].ToString();
        //        string imagePath = picPath + dr["art_image"].ToString().Trim();
        //        if (File.Exists(imagePath))
        //        {
        //            Microsoft.Office.Interop.Excel.Range cell = wSheet.Cells[excelRow, 7]; // 设置插入图片的位置
        //            Microsoft.Office.Interop.Excel.Shape picture = wSheet.Shapes.AddPicture(
        //                imagePath,
        //                Microsoft.Office.Core.MsoTriState.msoFalse,  // 链接到文件
        //                Microsoft.Office.Core.MsoTriState.msoCTrue,  // 保存图片
        //                (float)cell.Left,
        //                (float)cell.Top,
        //                45, // 图片宽度
        //                45  // 图片高度
        //            );
        //        }

        //        wSheet.Rows[excelRow].RowHeight = 60;

        //        excelRow++;
        //    }

        //    ////标题  
        //    //for (int i = 0; i < 27; i++)
        //    //{
        //    //    Microsoft.Office.Interop.Excel.Range titleRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, i + 1]];//选中标题  
        //    //    titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中  
        //    //}
        //    excelRow--;//退回一行


        //    //设置边框
        //    Microsoft.Office.Interop.Excel.Range allRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[excelRow, total_cols]];
        //    allRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        //    allRange.Font.Size = 10;
        //    allRange.WrapText = true;
        //    ////////带有千位分隔符、2位小数和减号的标准数字格式
        //    ////////rng.NumberFormat = "# ##0.00:-# ##0.00"
        //    allRange = wSheet.Range[wSheet.Cells[2, 9], wSheet.Cells[excelRow, 9]];
        //    allRange.NumberFormat = "###,###,###";
        //    allRange = wSheet.Range[wSheet.Cells[2, 10], wSheet.Cells[excelRow, 10]];
        //    allRange.NumberFormat = "###,###,###";
        //    allRange = wSheet.Range[wSheet.Cells[2, 11], wSheet.Cells[excelRow, 11]];
        //    allRange.NumberFormat = "###,###,###";
        //    allRange = wSheet.Range[wSheet.Cells[2, 12], wSheet.Cells[excelRow, 12]];
        //    allRange.NumberFormat = "###,###,###";
        //    allRange = wSheet.Range[wSheet.Cells[2, 13], wSheet.Cells[excelRow, 13]];
        //    allRange.NumberFormat = "###,###,###";
        //    //allRange = wSheet.Range[wSheet.Cells[2, 9], wSheet.Cells[excelRow, 9]];
        //    //allRange.NumberFormat = "###,##0.00";
        //    wSheet.Columns[1].ColumnWidth = 3;
        //    wSheet.Columns[2].ColumnWidth = 9;
        //    wSheet.Columns[3].ColumnWidth = 8;
        //    wSheet.Columns[4].ColumnWidth = 5;
        //    wSheet.Columns[5].ColumnWidth = 8;
        //    wSheet.Columns[6].ColumnWidth = 12;
        //    wSheet.Columns[7].ColumnWidth = 9;
        //    wSheet.Columns[8].ColumnWidth = 8;
        //    wSheet.Columns[9].ColumnWidth = 6.5;
        //    wSheet.Columns[10].ColumnWidth = 6.5;
        //    wSheet.Columns[11].ColumnWidth = 6.5;
        //    wSheet.Columns[12].ColumnWidth = 6.5;
        //    wSheet.Columns[13].ColumnWidth = 6.5;
        //    wSheet.Columns[14].ColumnWidth = 4;
        //    wSheet.Columns[15].ColumnWidth = 8;
        //    wSheet.Columns[16].ColumnWidth = 7;
        //    wSheet.Columns[17].ColumnWidth = 7;
        //    wSheet.Columns[18].ColumnWidth = 7;
        //    //wSheet.Columns.EntireColumn.AutoFit();//列宽自适应

        //    wSheet.Columns[5].Hidden = true;
        //    if (prd_dep != "322")
        //        wSheet.Columns[16].Hidden = true;
        //    //wSheet.Columns[2].Hidden = true;

        //    wSheet.PageSetup.Zoom = 80; // 设置缩放比例为 80%

        //    // 设置禁止弹出保存和覆盖的询问提示框
        //    excel.DisplayAlerts = false;
        //    excel.AlertBeforeOverwriting = false;

        //}

        //private static void NAR(object o)
        //{
        //    try
        //    {
        //        while (System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o) > 0) ;
        //    }
        //    catch { }
        //    finally
        //    {
        //        o = null;
        //    }
        //}
        //////-----------------------------以上這個用傳統Excel匯出的，但速度很慢------------------------
        public static string ExpToExcelEPP(string prd_dep, string fileName, System.Data.DataTable dtFromExcel, int rpt_type)
        {
            System.Data.DataTable dtExcel = dtFromExcel.Copy();
            string group_name = "prd_group";
            if (prd_dep == "322")
            {
                if (rpt_type == 1)
                    group_name = "prd_dep";
                else
                    group_name = "prd_machine";
            }
            System.Data.DataTable dtGroups = dtExcel.DefaultView.ToTable(true, group_name);
            string picPath = DBUtility.GetArtWorkPath();// context.Server.MapPath("~/") + "images\\";
            
            using (var package = new ExcelPackage())
            {
                for (int sheet_seq = 0; sheet_seq < dtGroups.Rows.Count; sheet_seq++)
                {
                    string group_tittle = dtGroups.Rows[sheet_seq][group_name].ToString().Trim() != "" ? dtGroups.Rows[sheet_seq][group_name].ToString().Trim() : "未定組別";
                    System.Data.DataTable dtNewExcel = new System.Data.DataTable();
                    DataView dv = dtExcel.DefaultView;
                    if (prd_dep != "322")
                        dv.RowFilter = "prd_group = " + "'" + dtGroups.Rows[sheet_seq][group_name].ToString().Trim() + "'";
                    else
                    {
                        if (rpt_type == 1)
                        {
                            dv.RowFilter = "prd_dep = " + "'" + prd_dep + "'";
                        }
                        else
                            dv.RowFilter = "prd_machine = " + "'" + dtGroups.Rows[sheet_seq][group_name].ToString().Trim() + "'";
                    }

                    dtNewExcel = dv.ToTable();


                    var worksheet = package.Workbook.Worksheets.Add(group_tittle);
                    worksheet.PrinterSettings.PaperSize = ePaperSize.A4; // 设置纸张为 A4
                    worksheet.PrinterSettings.Orientation = eOrientation.Portrait; // 设置页面纵向
                    // worksheet.PrinterSettings.Orientation = eOrientation.Landscape; // 设置页面横向
                    worksheet.PrinterSettings.TopMargin = (decimal)(0.17 / 2.54);    // 上边距，0.17 厘米
                    worksheet.PrinterSettings.BottomMargin = (decimal)(0.17 / 2.54); // 下边距，0.17 厘米
                    worksheet.PrinterSettings.LeftMargin = (decimal)(0.17 / 2.54);   // 左边距，0.17 厘米
                    worksheet.PrinterSettings.RightMargin = (decimal)(0.17 / 2.54);  // 右边距，0.17 厘米
                    int excelRow = 1;
                    //string colStr = $"A{excelRow}:{total_rows}{excelRow}";
                    // 设置合并单元格
                    //worksheet.Cells["A1:R1"].Merge = true; // 合并 A1 到 R1
                    worksheet.Cells["A1"].Value = "部門排期表" + " ( " + group_tittle + " )"; // 设置值
                    // 设置合并单元格的样式（可选）
                    worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 水平居中
                    worksheet.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;   // 垂直居中
                    worksheet.Cells["A1"].Style.Font.Bold = true; // 设置字体加粗
                    worksheet.Row(excelRow).Height = 30; // 设置第 1 行的高度为 20 点
                    excelRow++;
                    
                    if (rpt_type == 1)
                        FillExcel102(worksheet, dtNewExcel, prd_dep, excelRow, picPath);
                    else     // 按機器匯出
                        FillExcelByMachine(worksheet, dtNewExcel, prd_dep, excelRow, picPath);
                }
                // 保存 Excel 文件
                FileInfo file = new FileInfo(fileName);
                package.SaveAs(file);

                MessageBox.Show("Excel 文件导出成功！");
            }
            return "";
        }
        //按生產車間/組別匯出
        private static void FillExcel102(ExcelWorksheet worksheet, System.Data.DataTable dtNewExcel,string prd_dep, int excelRow,string picPath)
        {
            worksheet.Cells["A1:R1"].Merge = true; // 合并 A1 到 R1

            worksheet.Cells[excelRow, 1].Value = "序號";
            worksheet.Cells[excelRow, 2].Value = "制單編號";
            worksheet.Cells[excelRow, 3].Value = "排期日期";
            worksheet.Cells[excelRow, 4].Value = "狀態";
            worksheet.Cells[excelRow, 5].Value = "產品編號";
            worksheet.Cells[excelRow, 6].Value = "產品描述";
            worksheet.Cells[excelRow, 7].Value = "圖片";
            worksheet.Cells[excelRow, 8].Value = "PMC要求日期";
            worksheet.Cells[excelRow, 9].Value = "訂單數量";
            worksheet.Cells[excelRow, 10].Value = "要求數量";
            worksheet.Cells[excelRow, 11].Value = "完成數量";
            worksheet.Cells[excelRow, 12].Value = "未完成數量";
            worksheet.Cells[excelRow, 13].Value = "生產數量";
            worksheet.Cells[excelRow, 14].Value = "下部門";
            worksheet.Cells[excelRow, 15].Value = "部門复期";
            worksheet.Cells[excelRow, 16].Value = "供應商";
            worksheet.Cells[excelRow, 17].Value = "部門備註";
            worksheet.Cells[excelRow, 18].Value = "PMC備註";
            worksheet.Row(excelRow).Height = 30; // 设置第 1 行的高度为 20 点
            for (int i = 0; i < dtNewExcel.Rows.Count; i++)
            {
                DataRow drExcel = dtNewExcel.Rows[i];
                excelRow = i + 3;
                worksheet.Cells[excelRow, 1].Value = drExcel["schedule_seq"].ToString();//"\'" + 
                worksheet.Cells[excelRow, 2].Value = drExcel["prd_mo"].ToString();
                worksheet.Cells[excelRow, 3].Value = drExcel["schedule_date"].ToString();//"'" + 
                worksheet.Cells[excelRow, 4].Value = drExcel["urgent_flag_cdesc"].ToString();
                worksheet.Cells[excelRow, 5].Value = drExcel["prd_item"].ToString(); ;
                worksheet.Cells[excelRow, 6].Value = drExcel["goods_name"].ToString();
                worksheet.Cells[excelRow, 7].Value = "";
                worksheet.Cells[excelRow, 8].Value = drExcel["pmc_rq_date"].ToString();
                worksheet.Cells[excelRow, 9].Value = drExcel["order_qty"];
                worksheet.Cells[excelRow, 10].Value = drExcel["pl_qty"];
                worksheet.Cells[excelRow, 11].Value = drExcel["cp_qty"];
                worksheet.Cells[excelRow, 12].Value = drExcel["not_cp_qty"];
                worksheet.Cells[excelRow, 13].Value = drExcel["prd_qty"];
                worksheet.Cells[excelRow, 14].Value = "'" + drExcel["next_wp_id"].ToString();
                worksheet.Cells[excelRow, 15].Value = drExcel["dep_rp_date"].ToString();//"\'" + 
                worksheet.Cells[excelRow, 16].Value = drExcel["next_vend_id"].ToString();
                worksheet.Cells[excelRow, 17].Value = drExcel["dep_remark"].ToString();
                worksheet.Cells[excelRow, 18].Value = drExcel["mo_remark"].ToString();
                //string imagePath = drExcel["图片路径"].ToString();
                string imagePath = picPath + drExcel["art_image"].ToString().Trim();
                if (File.Exists(imagePath)) // 确保图片路径有效
                {
                    var picture = worksheet.Drawings.AddPicture($"Image{excelRow - 1}", new FileInfo(imagePath));
                    picture.SetPosition(excelRow - 1, 0, 6, 0); // 设置图片位置
                    picture.SetSize(60, 60);          // 设置图片大小
                }
                worksheet.Row(excelRow).Height = 50; // 设置第 1 行的高度为 20 点
            }

            worksheet.Column(1).Width = 4;
            worksheet.Column(2).Width = 10;
            worksheet.Column(3).Width = 9;
            worksheet.Column(4).Width = 5;
            worksheet.Column(5).Width = 8;
            worksheet.Column(6).Width = 14;
            worksheet.Column(7).Width = 9;
            worksheet.Column(8).Width = 9;
            worksheet.Column(9).Width = 7.5;
            worksheet.Column(10).Width = 7.5;
            worksheet.Column(11).Width = 7.5;
            worksheet.Column(12).Width = 7.5;
            worksheet.Column(13).Width = 7.5;
            worksheet.Column(14).Width = 5;
            worksheet.Column(15).Width = 9;
            worksheet.Column(16).Width = 7;
            worksheet.Column(17).Width = 7;
            worksheet.Column(18).Width = 7;
            //Cells[excelRow, 13]
            // 设置动态范围
            string colStr = $"I1:I{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"J1:J{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"K1:K{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"L1:L{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"M1:M{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            //worksheet.Cells["B1:B10"].Style.Numberformat.Format = "#,##0.00"; // 千分位小数格式
            //worksheet.Cells["C1:C10"].Style.Numberformat.Format = "$#,##0.00"; // 千分位货币格式
            // 设置某一列不可见
            worksheet.Column(5).Hidden = true; // 隐藏第2列（B列）
            if (prd_dep != "322")
                worksheet.Column(16).Hidden = true;
            worksheet.PrinterSettings.Scale = 80; // 缩放到 80%

            // 动态确定表格范围
            //string tableRange = $"A1:R{worksheet.Dimension.End.Row}"; // 表格范围
            string tableRange = $"A1:{ExcelAddress.GetAddress(worksheet.Dimension.End.Row, worksheet.Dimension.End.Column)}";
            var tableCells = worksheet.Cells[tableRange];

            // 为整个表格添加边框
            tableCells.Style.Border.BorderAround(ExcelBorderStyle.Thick); // 表格外边框设置为粗线
            tableCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;    // 表格顶部边框
            tableCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; // 表格底部边框
            tableCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;   // 表格左边边框
            tableCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;  // 表格右边边框
            tableCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // 垂直居中
            // 设置整个表格的字体大小
            tableCells.Style.Font.Size = 10; // 设置字体大小为10
            tableCells.Style.Font.Name = "新細明體";
            // 冻结第一行
            worksheet.View.FreezePanes(3, 1); // 从第2行、第1列开始滚动，冻结第一行
            // 设置打印标题行（固定第 1~2 行为标题）
            worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"]; // 固定标题为第1~2行
            // 设置整个表格内容自动换行
            tableCells.Style.WrapText = true;
        }

        //////按機器分表匯出
        private static void FillExcelByMachine(ExcelWorksheet worksheet, System.Data.DataTable dtNewExcel, string prd_dep, int excelRow, string picPath)
        {
            worksheet.Cells["A1:V1"].Merge = true; // 合并 A1 到 R1

            worksheet.Cells[excelRow, 1].Value = "序號";
            worksheet.Cells[excelRow, 2].Value = "制單編號";
            worksheet.Cells[excelRow, 3].Value = "狀態";
            worksheet.Cells[excelRow, 4].Value = "產品編號";
            worksheet.Cells[excelRow, 5].Value = "產品描述";
            worksheet.Cells[excelRow, 6].Value = "圖片";
            worksheet.Cells[excelRow, 7].Value = "訂單日期";
            worksheet.Cells[excelRow, 8].Value = "要求日期";
            worksheet.Cells[excelRow, 9].Value = "訂單數量";
            worksheet.Cells[excelRow, 10].Value = "要求數量";
            worksheet.Cells[excelRow, 11].Value = "完成數量";
            worksheet.Cells[excelRow, 12].Value = "未完成數量";
            worksheet.Cells[excelRow, 13].Value = "生產數量";
            worksheet.Cells[excelRow, 14].Value = "模具編號";
            worksheet.Cells[excelRow, 15].Value = "上模";
            worksheet.Cells[excelRow, 16].Value = "每碑";
            worksheet.Cells[excelRow, 17].Value = "需要碑數";
            worksheet.Cells[excelRow, 18].Value = "預計需時";
            worksheet.Cells[excelRow, 19].Value = "預計開始時間";
            worksheet.Cells[excelRow, 20].Value = "預計結束時間";
            worksheet.Cells[excelRow, 21].Value = "電鍍顏色";
            worksheet.Cells[excelRow, 22].Value = "備註";
            worksheet.Row(excelRow).Height = 30; // 设置第 1 行的高度为 20 点
            for (int i = 0; i < dtNewExcel.Rows.Count; i++)
            {
                DataRow drExcel = dtNewExcel.Rows[i];
                excelRow = i + 3;
                worksheet.Cells[excelRow, 1].Value = drExcel["module_type"].ToString();
                worksheet.Cells[excelRow, 2].Value = drExcel["prd_mo"].ToString();
                worksheet.Cells[excelRow, 3].Value = drExcel["urgent_flag_cdesc"].ToString();
                worksheet.Cells[excelRow, 4].Value = drExcel["prd_item"].ToString();
                worksheet.Cells[excelRow, 5].Value = drExcel["goods_name"].ToString();
                worksheet.Cells[excelRow, 6].Value = "";
                worksheet.Cells[excelRow, 7].Value = drExcel["order_date"].ToString();
                worksheet.Cells[excelRow, 8].Value = drExcel["pmc_rq_date"].ToString();
                worksheet.Cells[excelRow, 9].Value = drExcel["order_qty"];
                worksheet.Cells[excelRow, 10].Value = drExcel["pl_qty"];
                worksheet.Cells[excelRow, 11].Value = drExcel["cp_qty"];
                worksheet.Cells[excelRow, 12].Value = drExcel["not_cp_qty"];
                worksheet.Cells[excelRow, 13].Value = drExcel["prd_qty"];
                worksheet.Cells[excelRow, 14].Value = drExcel["module_no"].ToString();
                worksheet.Cells[excelRow, 15].Value = drExcel["module_install"].ToString();
                worksheet.Cells[excelRow, 16].Value = drExcel["machine_std_line_num"];
                worksheet.Cells[excelRow, 17].Value = drExcel["need_mon_num"];
                worksheet.Cells[excelRow, 18].Value = drExcel["req_tot_time"];
                worksheet.Cells[excelRow, 19].Value = drExcel["start_time"].ToString();
                worksheet.Cells[excelRow, 20].Value = drExcel["end_time"].ToString();
                worksheet.Cells[excelRow, 21].Value = drExcel["next_do_color"].ToString();
                worksheet.Cells[excelRow, 22].Value = drExcel["dep_remark"].ToString();
                //string imagePath = drExcel["图片路径"].ToString();
                string imagePath = picPath + drExcel["art_image"].ToString().Trim();
                if (File.Exists(imagePath)) // 确保图片路径有效
                {
                    var picture = worksheet.Drawings.AddPicture($"Image{excelRow - 1}", new FileInfo(imagePath));
                    picture.SetPosition(excelRow - 1, 0, 5, 0); // 设置图片位置
                    picture.SetSize(60, 60);          // 设置图片大小
                }
                worksheet.Row(excelRow).Height = 50; // 设置第 1 行的高度为 20 点
            }

            worksheet.Column(1).Width = 4;
            worksheet.Column(2).Width = 10;
            worksheet.Column(3).Width = 9;
            worksheet.Column(4).Width = 5;
            worksheet.Column(5).Width = 8;
            worksheet.Column(6).Width = 14;
            worksheet.Column(7).Width = 9;
            worksheet.Column(8).Width = 9;
            worksheet.Column(9).Width = 7.5;
            worksheet.Column(10).Width = 7.5;
            worksheet.Column(11).Width = 7.5;
            worksheet.Column(12).Width = 7.5;
            worksheet.Column(13).Width = 7.5;
            worksheet.Column(14).Width = 5;
            worksheet.Column(15).Width = 9;
            worksheet.Column(16).Width = 7;
            worksheet.Column(17).Width = 7;
            worksheet.Column(18).Width = 7;
            worksheet.Column(19).Width = 16;
            worksheet.Column(20).Width = 16;
            worksheet.Column(21).Width = 7;
            worksheet.Column(22).Width = 7;
            //Cells[excelRow, 13]
            // 设置动态范围
            string colStr = $"I1:I{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"J1:J{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"K1:K{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"L1:L{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            colStr = $"M1:M{excelRow}"; // 动态计算行数
            worksheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
            //worksheet.Cells["B1:B10"].Style.Numberformat.Format = "#,##0.00"; // 千分位小数格式
            //worksheet.Cells["C1:C10"].Style.Numberformat.Format = "$#,##0.00"; // 千分位货币格式
            // 设置某一列不可见
            worksheet.Column(4).Hidden = true; // 隐藏第2列（B列）
            worksheet.PrinterSettings.Scale = 80; // 缩放到 80%

            // 动态确定表格范围
            //string tableRange = $"A1:R{worksheet.Dimension.End.Row}"; // 表格范围
            string tableRange = $"A1:{ExcelAddress.GetAddress(worksheet.Dimension.End.Row, worksheet.Dimension.End.Column)}";
            var tableCells = worksheet.Cells[tableRange];

            // 为整个表格添加边框
            tableCells.Style.Border.BorderAround(ExcelBorderStyle.Thick); // 表格外边框设置为粗线
            tableCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;    // 表格顶部边框
            tableCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; // 表格底部边框
            tableCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;   // 表格左边边框
            tableCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;  // 表格右边边框
            tableCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // 垂直居中
            // 设置整个表格的字体大小
            tableCells.Style.Font.Size = 10; // 设置字体大小为10
            tableCells.Style.Font.Name = "新細明體";
            // 冻结第一行
            worksheet.View.FreezePanes(3, 1); // 从第2行、第1列开始滚动，冻结第一行
            // 设置打印标题行（固定第 1~2 行为标题）
            worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"]; // 固定标题为第1~2行
            // 设置整个表格内容自动换行
            tableCells.Style.WrapText = true;
        }
    }
}
