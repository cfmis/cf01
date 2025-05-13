﻿using System;
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
        


        //////------------------------以下匯出排期表---------------------------
        public static string ExpToExcelEPP(string prd_dep, string fileName, System.Data.DataTable dtExcel, int rpt_type,ProgressBar prgStatus)
        {
            string group_name = "prd_group";
            if (prd_dep == "322" || prd_dep=="203")
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
                    if (prd_dep == "322" || prd_dep == "203")
                    {
                        if (rpt_type == 1)
                        {
                            dv.RowFilter = "prd_dep = " + "'" + prd_dep + "'";
                        }
                        else
                            dv.RowFilter = "prd_machine = " + "'" + dtGroups.Rows[sheet_seq][group_name].ToString().Trim() + "'";
                    }
                    else
                        dv.RowFilter = "prd_group = " + "'" + dtGroups.Rows[sheet_seq][group_name].ToString().Trim() + "'";

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
                    prgStatus.Minimum = 0;
                    
                    prgStatus.Value = 0;
                    if (rpt_type == 1)
                        FillExcel102(worksheet, dtNewExcel, prd_dep, excelRow, picPath, prgStatus);
                    else     // 按機器匯出
                        FillExcelByMachine(worksheet, dtNewExcel, prd_dep, excelRow, picPath, prgStatus);
                }
                // 保存 Excel 文件
                FileInfo file = new FileInfo(fileName);
                package.SaveAs(file);
                prgStatus.Value = 0;
                MessageBox.Show("Excel 文件导出成功！");
            }
            return "";
        }
        //按生產車間/組別匯出
        private static void FillExcel102(ExcelWorksheet worksheet, System.Data.DataTable dtNewExcel,string prd_dep, int excelRow,string picPath, ProgressBar prgStatus)
        {
            prgStatus.Maximum = dtNewExcel.Rows.Count;
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
            if (prd_dep != "322")
                worksheet.Cells[excelRow, 16].Value = "組別";
            else
                worksheet.Cells[excelRow, 16].Value = "供應商";
            worksheet.Cells[excelRow, 17].Value = "部門備註";
            worksheet.Cells[excelRow, 18].Value = "PMC備註";
            worksheet.Row(excelRow).Height = 30; // 设置第 1 行的高度为 20 点
            for (int i = 0; i < dtNewExcel.Rows.Count; i++)
            {
                prgStatus.Value = i;
                DataRow drExcel = dtNewExcel.Rows[i];
                excelRow = i + 3;
                worksheet.Cells[excelRow, 1].Value = drExcel["schedule_seq"].ToString();//"\'" + 
                worksheet.Cells[excelRow, 2].Value = drExcel["prd_mo"].ToString();
                worksheet.Cells[excelRow, 3].Value = drExcel["schedule_date"].ToString();//"'" + 
                worksheet.Cells[excelRow, 4].Value = drExcel["pass_days"].ToString().Trim() + "\r\n" + drExcel["urgent_flag_cdesc"].ToString().Trim();
                worksheet.Cells[excelRow, 5].Value = drExcel["prd_item"].ToString(); ;
                worksheet.Cells[excelRow, 6].Value = drExcel["goods_name"].ToString();
                worksheet.Cells[excelRow, 7].Value = "";
                worksheet.Cells[excelRow, 8].Value = drExcel["pmc_rq_date"].ToString();
                worksheet.Cells[excelRow, 9].Value = drExcel["order_qty"];
                worksheet.Cells[excelRow, 10].Value = drExcel["pl_qty"];
                worksheet.Cells[excelRow, 11].Value = drExcel["cp_qty"];
                worksheet.Cells[excelRow, 12].Value = drExcel["not_cp_qty"];
                worksheet.Cells[excelRow, 13].Value = drExcel["prd_qty"];
                worksheet.Cells[excelRow, 14].Value = drExcel["next_wp_id"].ToString();
                worksheet.Cells[excelRow, 15].Value = drExcel["dep_rp_date"].ToString();//"\'" + 
                if (prd_dep != "322")
                    worksheet.Cells[excelRow, 16].Value = drExcel["prd_group"].ToString();
                else
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
            worksheet.Column(5).Hidden = true; // 隐藏物料編號
            if (prd_dep == "322" || prd_dep == "202")
            {
                worksheet.PrinterSettings.Scale = 75; // 缩放到 75%
            }
            else
            {
                //worksheet.Column(16).Hidden = true;
                worksheet.PrinterSettings.Scale = 75; // 缩放到 80%
            }


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
        private static void FillExcelByMachine(ExcelWorksheet worksheet, System.Data.DataTable dtNewExcel, string prd_dep, int excelRow, string picPath, ProgressBar prgStatus)
        {
            
            prgStatus.Maximum = dtNewExcel.Rows.Count;
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
                prgStatus.Value = i;
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

        //////------------------------匯出生產計劃單---------------------------
        public static void ExpToExcelPlan1(StreamWriter sw, System.Data.DataTable dtExcel)
        {
            string str = " ";
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
            str += "\t" + "下下部門";
            str += "\t" + "下下部門描述";
            str += "\t" + "急單狀態";
            str += "\t" + "機器小時標準";
            sw.WriteLine(str);
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                DataRow drExcel = dtExcel.Rows[i];
                string tempstr = " ";
                tempstr += "\'" + drExcel["wp_id"].ToString();
                tempstr += "\t" + drExcel["mo_id"].ToString();
                tempstr += "\t" + drExcel["sequence_id"].ToString();
                tempstr += "\t" + drExcel["goods_id"].ToString();
                tempstr += "\t" + drExcel["goods_name"].ToString();
                tempstr += "\t" + drExcel["next_wp_id"].ToString();
                tempstr += "\t" + drExcel["prod_qty"];
                tempstr += "\t" + drExcel["per_prod_qty"];
                tempstr += "\t" + drExcel["order_qty"];
                tempstr += "\t" + drExcel["c_qty_ok"];
                tempstr += "\t" + "\'" + drExcel["t_complete_date"].ToString();
                tempstr += "\t" + "\'" + drExcel["f_complete_date"].ToString();
                tempstr += "\t" + drExcel["overdue_days"].ToString();
                tempstr += "\t" + drExcel["pre_dep_deliver_flag"].ToString();
                tempstr += "\t" + drExcel["pre_deliver_max_dat"].ToString();
                tempstr += "\t" + drExcel["m_overdue_days"].ToString();
                tempstr += "\t" + drExcel["ver"].ToString();
                tempstr += "\t" + "\'" + drExcel["bill_date"].ToString();
                tempstr += "\t" + "\'" + drExcel["check_date"].ToString();
                tempstr += "\t" + "\'" + drExcel["seller_id"].ToString();
                tempstr += "\t" + drExcel["art"].ToString();
                tempstr += "\t" + drExcel["picture_name"].ToString();
                tempstr += "\t" + drExcel["goods_unit"].ToString();
                tempstr += "\t" + drExcel["s_qty"];
                tempstr += "\t" + drExcel["obligate_qty"];
                tempstr += "\t" + drExcel["pre_dep_mt_seq"].ToString();
                tempstr += "\t" + drExcel["pre_wp_id"].ToString();
                tempstr += "\t" + drExcel["pre_dep_mt_item"].ToString();
                tempstr += "\t" + drExcel["pre_dep_mt_name"].ToString();
                tempstr += "\t" + drExcel["pre_dep_prod_qty"].ToString();
                tempstr += "\t" + drExcel["pre_dep_qty_ok"].ToString();
                tempstr += "\t" + "\'" + drExcel["pre_dep_t_dat"].ToString();
                tempstr += "\t" + "\'" + drExcel["pre_dep_f_dat"].ToString();
                tempstr += "\t" + drExcel["dep_keep_day"].ToString();
                tempstr += "\t" + drExcel["vendor_id"].ToString();
                tempstr += "\t" + drExcel["vendor_name"].ToString();
                tempstr += "\t" + drExcel["mo_state_desc"].ToString();
                tempstr += "\t" + drExcel["plan_complete"].ToString();
                tempstr += "\t" + drExcel["status_desc"].ToString();
                tempstr += "\t" + drExcel["shading_color"].ToString();
                tempstr += "\t" + drExcel["rec_flag"].ToString();
                tempstr += "\t" + drExcel["do_color"].ToString();
                tempstr += "\t" + drExcel["next_wp_cdesc"].ToString();
                tempstr += "\t" + drExcel["next_vendor_id"].ToString();
                tempstr += "\t" + drExcel["next_goods_id"].ToString();
                tempstr += "\t" + drExcel["next_goods_name"].ToString();
                tempstr += "\t" + drExcel["next_do_color"].ToString();
                tempstr += "\t" + drExcel["next_color_cdesc"].ToString();
                tempstr += "\t" + drExcel["next_next_wp_id"].ToString();
                tempstr += "\t" + drExcel["next_next_dep_name"].ToString();
                tempstr += "\t" + drExcel["status_desc"].ToString();
                tempstr += "\t" + drExcel["hour_std_qty"];
                sw.WriteLine(tempstr);
            }
        }

        public static void ExpToExcelPlan2(StreamWriter sw, System.Data.DataTable dtExcel)
        {
            string str = "";
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
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                DataRow drExcel = dtExcel.Rows[i];
                string tempstr = "";
                tempstr += "\'" + drExcel["wp_id"].ToString();
                tempstr += "\t" + drExcel["mo_id"].ToString();
                tempstr += "\t" + drExcel["bill_date"].ToString();
                tempstr += "\t" + drExcel["goods_id"].ToString();
                tempstr += "\t" + drExcel["goods_name"].ToString();
                tempstr += "\t" + drExcel["prod_qty"];
                tempstr += "\t" + "";
                tempstr += "\t" + "1";
                tempstr += "\t" + drExcel["per_prod_qty"];
                tempstr += "\t" + drExcel["t_complete_date"].ToString();
                tempstr += "\t" + drExcel["order_qty"];
                tempstr += "\t" + drExcel["next_wp_id"].ToString();
                tempstr += "\t" + drExcel["next_wp_cdesc"].ToString();
                tempstr += "\t" + drExcel["do_color"].ToString();
                tempstr += "\t" + "";
                tempstr += "\t" + "\'" + drExcel["check_date"].ToString();
                tempstr += "\t" + drExcel["picture_name"].ToString();
                tempstr += "\t" + "\'" + drExcel["bill_date"].ToString();
                tempstr += "\t" + drExcel["next_do_color"].ToString();
                tempstr += "\t" + drExcel["ver"].ToString();
                tempstr += "\t" + drExcel["next_vendor_id"].ToString();
                tempstr += "\t" + drExcel["c_qty_ok"];
                sw.WriteLine(tempstr);
            }
        }
        public static void ExpToExcelPlan3(StreamWriter sw, System.Data.DataTable dtExcel)
        {
            string str = "";
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
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                DataRow drExcel = dtExcel.Rows[i];
                string tempstr = "";
                tempstr += "\'" + (i + 1).ToString();//序號
                tempstr += "\t" + drExcel["wp_id"].ToString();
                tempstr += "\t" + drExcel["status_desc"].ToString();
                tempstr += "\t" + drExcel["mo_id"].ToString();
                tempstr += "\t" + drExcel["goods_id"].ToString();
                tempstr += "\t" + drExcel["goods_name"].ToString();
                tempstr += "\t" + drExcel["prod_qty"];
                tempstr += "\t" + drExcel["pre_dep_qty_ok"];
                tempstr += "\t" + drExcel["c_qty_ok"];
                tempstr += "\t" + drExcel["pre_deliver_max_dat"].ToString();
                tempstr += "\t" + "";
                tempstr += "\t" + "";
                tempstr += "\t" + "\'" + drExcel["plan_complete"].ToString();
                tempstr += "\t" + drExcel["shading_color"].ToString();
                sw.WriteLine(tempstr);
            }
            
        }
    }
}
