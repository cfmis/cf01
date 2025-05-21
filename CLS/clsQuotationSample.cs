using cf01.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsQuotationSample
    {
        public static string cust_artwork_path = @"\\192.168.3.12\cf_artwork\quo_photo";
        public static DataTable GetEmptyStrutre()
        {
            SqlParameter[] paras = new SqlParameter[] {
                 new SqlParameter("@serial_no",""),
            };
            DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("p_find_quotation_sample_init", paras);                           
            if (dt.Rows.Count > 0)
            {
                dt = SetGridDataBackgroudColor(dt);
            }
            return dt;            
        }
        public static string GetSerialNo()
        {
            string result = "";
            string strsql = @"SELECT dbo.fn_z_get_serialno_for_datetime() as serial_no";
            System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            string str_serial_no = dt.Rows[0]["serial_no"].ToString();
            result = !string.IsNullOrEmpty(str_serial_no) ? str_serial_no : "";            
            return str_serial_no;          
        }

        public static string Delete(int id)
        {
            string result = "";
            string sql_del = string.Format("Delete FROM quotation_sample WHERE id={0}", id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(sql_del);
            return result;
        }

        public static DataSet FindDataByMdl(mdlQuotationSample mdl)
        {
            DataSet dts = new DataSet();           
            string create_date2 = "";
            if (!string.IsNullOrEmpty(mdl.create_date2))
            {
                create_date2 = DateTime.Parse(mdl.create_date2).Date.AddDays(1).ToString("yyyy-MM-dd");
            }
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@input_date1",mdl.input_date),
                new SqlParameter("@input_date2",mdl.input_date2),
                new SqlParameter("@season",mdl.season),
                new SqlParameter("@plm_code",mdl.plm_code),
                new SqlParameter("@cf_code",mdl.cf_code),
                new SqlParameter("@material",mdl.material),
                new SqlParameter("@size",mdl.size),
                new SqlParameter("@macys_color_code",mdl.macys_color_code),
                new SqlParameter("@mo_id",mdl.mo_id),
                new SqlParameter("@cf_color_code",mdl.cf_color_code),
                new SqlParameter("@brand_desc",mdl.brand_desc),
                new SqlParameter("@excel_type",mdl.excel_type),
                new SqlParameter("@create_by",mdl.create_by),
                new SqlParameter("@create_date1",mdl.create_date),
                new SqlParameter("@create_date2",create_date2),
                new SqlParameter("@flag_ck",mdl.flag_ck)
            };
            dts = clsPublicOfCF01.ExecuteProcedureReturnDataSet("p_find_quotation_sample", paras,null);            
            return dts;
        }

        public static DataTable FindBasePriceByMdl(mdlQuotationSample mdl)
        {
            DataTable dt = new DataTable();            
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@user_id",DBUtility._user_id),
                new SqlParameter("@sales_group",mdl.create_by),
                new SqlParameter("@material",mdl.material),
                new SqlParameter("@cust_code",mdl.plm_code),
                new SqlParameter("@cust_color",mdl.macys_color_code),//客戶的顏色
                new SqlParameter("@cf_code",mdl.cf_code),
                new SqlParameter("@cf_color",mdl.cf_color_code),
                new SqlParameter("@season",mdl.season),
                new SqlParameter("@size",mdl.size),
                new SqlParameter("@mo_id",mdl.mo_id)
            };
            dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_find_of_sample", paras);
            return dt;
        }

        public static DataTable SetGridDataBackgroudColor(DataTable dt)
        { 
            string bgcolor = "0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    bgcolor = dt.Rows[i - 1]["bgcolor"].ToString();                 
                    if (dt.Rows[i-1]["serial_no"].ToString() != dt.Rows[i]["serial_no"].ToString())
                    {
                        //組改變時                
                        if (bgcolor == "0")
                        {
                            dt.Rows[i]["bgcolor"] = "1";                            
                        }
                        else
                        {
                            dt.Rows[i]["bgcolor"] = "0";
                        }
                    }
                    else
                    {
                        dt.Rows[i]["bgcolor"] = bgcolor;//同組
                    }
                }               
            }            
            dt.AcceptChanges();//恢復正常的Rowstate狀態,否則按編輯按鈕時表格背景色會亂
            return dt;
        }
        public static string getSampleArt(string serialNo)
        {
            string result = "";
            string strSql = string.Format(@"Select Max(Isnull(artwork_path,'')) As artwork_path From quotation_sample Where serial_no='{0}'", serialNo);
            result = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            return result;
        }

        public static void ExportToExcel(DataGridView dgv,string isOpen,string formatBy)
        {
            if (dgv.RowCount > 0)
            {
                //bool fileSaved = false; 
                string FileName = "";
                if (isOpen == "")
                {
                    SaveFileDialog saveDialog = new SaveFileDialog()
                    {
                        /*saveDialog.DefaultExt = "";*/
                        Title = "保存EXECL文件",
                        Filter = "EXECL文件|*.xls",
                        FilterIndex = 1
                    };
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileName = saveDialog.FileName;
                        if (File.Exists(FileName))
                        {
                            File.Delete(FileName);
                        }
                    }
                }
                
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("無法創建Excel對象,可能您的電腦上未安装Excel");
                    return;
                }
                string version = xlApp.Version;//獲取當前使用excel版本號 
                //FormatNum=-4143--You use Excel 97-2003; FormatNum=56--you use excel 2007 or later
                int FormatNum = Convert.ToDouble(version) < 12 ? -4143 : 56; //保存excel文件的格式               
                Microsoft.Office.Interop.Excel.Workbook workbook = xlApp.Workbooks.Add(true);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                //第一行为表頭 寫入欄位標題
                if (formatBy != "CK")
                {
                    worksheet.Cells[1, 1] = "Season";
                    worksheet.Cells[1, 2] = "PLM";
                    worksheet.Cells[1, 3] = "Artwork";//圖樣列
                    worksheet.Cells[1, 4] = "CF CODE";
                    worksheet.Cells[1, 5] = "Product Description";
                    worksheet.Cells[1, 6] = "Material";
                    worksheet.Cells[1, 7] = "Size";
                    worksheet.Cells[1, 8] = "Macys Color Code";
                    worksheet.Cells[1, 9] = "MO#";
                    worksheet.Cells[1, 10] = "Ready date";
                    worksheet.Cells[1, 11] = "CF Color Code";
                    worksheet.Cells[1, 12] = "Ex-fty(USD) --all price are not including 3rd part test";
                    worksheet.Cells[1, 13] = "Ex-fty (USD)-special price";
                    worksheet.Cells[1, 14] = "Unit";
                    worksheet.Cells[1, 15] = "MOQ (PCS)";
                    worksheet.Cells[1, 16] = "Surcharge";
                    worksheet.Cells[1, 17] = "Mould Engraving Charge";
                    worksheet.Cells[1, 18] = "Artwork Approved Date/by";
                    worksheet.Cells[1, 19] = "Submission Date";
                    worksheet.Cells[1, 20] = "Sample Approved Date/by";
                    worksheet.Cells[1, 21] = "Macy's System";
                    worksheet.Cells[1, 22] = "Excel Type";
                }
                else
                {
                    worksheet.Cells[1, 1] = "Brand (Division)";
                    worksheet.Cells[1, 2] = "SEASON";
                    worksheet.Cells[1, 3] = "Image";//圖樣列
                    worksheet.Cells[1, 4] = "PLM";
                    worksheet.Cells[1, 5] = "Product Description";
                    worksheet.Cells[1, 6] = "Material";
                    worksheet.Cells[1, 7] = "CF Code";
                    worksheet.Cells[1, 8] = "MO#";
                    worksheet.Cells[1, 9] = "Ready Date";
                    worksheet.Cells[1, 10] = "Size";
                    worksheet.Cells[1, 11] = "Customer Color Code";
                    worksheet.Cells[1, 12] = "CF Color";
                    worksheet.Cells[1, 13] = "EX-FTY HK (USD)";
                    worksheet.Cells[1, 14] = "Builk Lead Time";
                    worksheet.Cells[1, 15] = "MOQ";
                    worksheet.Cells[1, 16] = "Quality Issue";
                    worksheet.Cells[1, 17] = "Artwork Approved Date/by";
                    worksheet.Cells[1, 18] = "Submission Date";
                    worksheet.Cells[1, 19] = "Excel Type";
                }
                worksheet.Rows[1].Font.Size = 10;
                worksheet.Rows[1].Font.Bold = true;//粗體
                worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//表頭欄位水平居中                    
                worksheet.Rows[1].RowHeight = 45;
                worksheet.Rows[2].Font.Bold = false;
                worksheet.Columns[3].ColumnWidth = 20;//圖樣列寬度
                worksheet.Rows[2].RowHeight = 66;

                cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();

                //寫入數值                    
                string rang_begin = "", merge_rang = "", status = "", range_A, range_V, artwork_path = "", serial_no;
                string a_value, b_value, d_value, e_value, f_value, g_value, n_value, p_value;               
                int row_index = 1, row_total = 0, seq_id = 0;
                serial_no = dgv.Rows[0].Cells["serial_no"].Value.ToString();
                DataTable dt = new DataTable();
                Microsoft.Office.Interop.Excel.Range rang_curr_row;
                for (int r = 0; r < dgv.RowCount; r++)//行
                {
                    row_index += 1;
                    worksheet.Rows[row_index].RowHeight = dgv.Rows[r].Cells["row_height"].Value;//每行高
                    worksheet.Rows[row_index].Font.Size = 9;
                    worksheet.Rows[row_index].Font.Bold = false;
                    if (formatBy != "CK")
                    {                        
                        worksheet.Cells[row_index, 1] = "";// dgv.Rows[r].Cells["season"].Value.ToString(); //A*
                        worksheet.Cells[row_index, 2] = "";// dgv.Rows[r].Cells["plm_code"].Value.ToString(); //B*                                                          
                        worksheet.Cells[row_index, 4] = "";// dgv.Rows[r].Cells["cf_code"].Value.ToString(); //D*
                        worksheet.Cells[row_index, 5] = "";// dgv.Rows[r].Cells["product_desc"].Value.ToString(); //E*
                        worksheet.Cells[row_index, 6] = "";// dgv.Rows[r].Cells["material"].Value.ToString(); //F*
                        worksheet.Cells[row_index, 7] = dgv.Rows[r].Cells["size"].Value.ToString(); //G
                        worksheet.Cells[row_index, 8] = dgv.Rows[r].Cells["macys_color_code"].Value.ToString();//H
                        worksheet.Cells[row_index, 9] = dgv.Rows[r].Cells["mo_id"].Value.ToString();//I
                        worksheet.Cells[row_index, 10] = dgv.Rows[r].Cells["ready_date"].Value.ToString(); //J
                        worksheet.Cells[row_index, 11] = dgv.Rows[r].Cells["cf_color_code"].Value.ToString(); //K
                        worksheet.Cells[row_index, 12] = dgv.Rows[r].Cells["ex_fty_usd"].Value.ToString();  //L
                        worksheet.Cells[row_index, 13] = dgv.Rows[r].Cells["ex_fty_usd_new"].Value.ToString(); //M
                        worksheet.Cells[row_index, 14] = "";// dgv.Rows[r].Cells["price_unit"].Value.ToString(); //N*
                        worksheet.Cells[row_index, 15] = dgv.Rows[r].Cells["moq_pcs"].Value.ToString();//O
                        worksheet.Cells[row_index, 16] = "";// dgv.Rows[r].Cells["surcharge"].Value.ToString(); //P*
                        worksheet.Cells[row_index, 17] = dgv.Rows[r].Cells["md_charge"].Value.ToString();
                        worksheet.Cells[row_index, 18] = dgv.Rows[r].Cells["art_approved_by"].Value.ToString();
                        worksheet.Cells[row_index, 19] = "'" + dgv.Rows[r].Cells["submission_date"].Value.ToString();
                        worksheet.Cells[row_index, 20] = dgv.Rows[r].Cells["sample_approved_date"].Value.ToString();
                        worksheet.Cells[row_index, 21] = dgv.Rows[r].Cells["macy_system"].Value.ToString();
                        worksheet.Cells[row_index, 22] = dgv.Rows[r].Cells["excel_type"].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[row_index, 1] = "";// dgv.Rows[r].Cells["brand_desc"].Value.ToString(); A
                        worksheet.Cells[row_index, 2] = "";// dgv.Rows[r].Cells["season"].Value.ToString(); B                                                       
                        worksheet.Cells[row_index, 4] = "";// dgv.Rows[r].Cells["plm_code"].Value.ToString(); D
                        worksheet.Cells[row_index, 5] = "";// dgv.Rows[r].Cells["product_desc"].Value.ToString();E
                        worksheet.Cells[row_index, 6] = "";// dgv.Rows[r].Cells["material"].Value.ToString(); F
                        worksheet.Cells[row_index, 7] = "";// dgv.Rows[r].Cells["cf_code"].Value.ToString(); G
                        worksheet.Cells[row_index, 8] = dgv.Rows[r].Cells["mo_id"].Value.ToString();
                        worksheet.Cells[row_index, 9] = dgv.Rows[r].Cells["ready_date"].Value.ToString();
                        worksheet.Cells[row_index, 10] = dgv.Rows[r].Cells["size"].Value.ToString();
                        worksheet.Cells[row_index, 11] = dgv.Rows[r].Cells["macys_color_code"].Value.ToString();
                        worksheet.Cells[row_index, 12] = dgv.Rows[r].Cells["cf_color_code"].Value.ToString();
                        worksheet.Cells[row_index, 13] = dgv.Rows[r].Cells["ex_fty_usd"].Value.ToString();
                        worksheet.Cells[row_index, 14] = dgv.Rows[r].Cells["bulk_lead_time"].Value.ToString();
                        worksheet.Cells[row_index, 15] = dgv.Rows[r].Cells["moq_pcs"].Value.ToString();
                        worksheet.Cells[row_index, 16] = dgv.Rows[r].Cells["quality_issue"].Value.ToString();
                        worksheet.Cells[row_index, 17] = dgv.Rows[r].Cells["art_approved_by"].Value.ToString();
                        worksheet.Cells[row_index, 18] = "'" + dgv.Rows[r].Cells["submission_date"].Value.ToString();
                        worksheet.Cells[row_index, 19] = dgv.Rows[r].Cells["excel_type"].Value.ToString();
                    }
                    status = dgv.Rows[r].Cells["status"].Value.ToString();
                    status = string.IsNullOrEmpty(status) ? "" : status;
                    if (status == "CANCELLED")
                    {
                        range_A = "A" + row_index;
                        if (formatBy != "CK") 
                            range_V = "V" + row_index;
                        else
                            range_V = "S" + row_index;
                        rang_curr_row = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range(range_A, range_V);
                        rang_curr_row.Font.Strikethrough = true; // 添加删除线效果
                        rang_curr_row.Font.Color = System.Drawing.Color.Red;//字體顏色
                    }
                    row_total = int.Parse(dgv.Rows[r].Cells["rs"].Value.ToString());//每組有幾行
                    seq_id = int.Parse(dgv.Rows[r].Cells["seq_id"].Value.ToString()); //當前行的序號
                    a_value = dgv.Rows[r].Cells["season"].Value.ToString();
                    b_value = dgv.Rows[r].Cells["plm_code"].Value.ToString();
                    d_value = dgv.Rows[r].Cells["cf_code"].Value.ToString();
                    e_value = dgv.Rows[r].Cells["product_desc"].Value.ToString();
                    f_value = dgv.Rows[r].Cells["material"].Value.ToString();
                    g_value = dgv.Rows[r].Cells["cf_code"].Value.ToString(); //CK
                    n_value = dgv.Rows[r].Cells["price_unit"].Value.ToString();
                    p_value = dgv.Rows[r].Cells["surcharge"].Value.ToString();
                    if (r == 0 && seq_id == row_total && seq_id == 1)
                    {
                        //圖樣,第一行,且只有一行,自己作一組
                        artwork_path = dgv.Rows[r].Cells["artwork_path"].Value.ToString();
                        artwork_path = !string.IsNullOrEmpty(artwork_path) ? artwork_path : "";
                        InsertPicture("C2:C2", worksheet, artwork_path);
                    }
                    if (seq_id == 1)
                    {
                        //要合并的列只符第一次值
                        worksheet.Cells[row_index, 1] = a_value;
                        worksheet.Cells[row_index, 2] = b_value;
                        worksheet.Cells[row_index, 4] = d_value;
                        worksheet.Cells[row_index, 5] = e_value;
                        worksheet.Cells[row_index, 6] = f_value;
                        if (formatBy != "CK")
                        {
                            worksheet.Cells[row_index, 14] = n_value;
                            worksheet.Cells[row_index, 16] = p_value;
                        }
                        else
                        {                         
                            worksheet.Cells[row_index, 7] = g_value;
                        }                        
                    }
                    if (r > 0)
                    {
                        if (dgv.Rows[r].Cells["serial_no"].Value.ToString() == serial_no)
                        {
                            //同組
                            if (seq_id == row_total) //同組最后一行
                            {
                                merge_rang = GetMergeRang("C", row_index, row_total); //合并的區域
                                worksheet.Range[merge_rang].Merge(0);//合并单元格
                                artwork_path = dgv.Rows[r].Cells["artwork_path"].Value.ToString(); //每組序號01中對應的圖樣路徑
                                artwork_path = !string.IsNullOrEmpty(artwork_path) ? artwork_path : "";
                                if (artwork_path == "")
                                {
                                    //當圖樣路徑是空時,重取此組別中存在的路徑,正常同組只有一張圖樣
                                    artwork_path = getSampleArt(serial_no);
                                }
                                if (File.Exists(artwork_path))
                                {
                                    rang_begin = "C" + (row_index - row_total + 1);//插入圖樣的開始位置
                                    InsertPicture(rang_begin, worksheet, artwork_path);//插入圖片,同組第一行插入
                                }
                                if(formatBy !="CK")
                                    SetMergeRange(worksheet, row_index, row_total,"");//設置哪些列要合并
                                else
                                    SetMergeRange(worksheet, row_index, row_total, "CK");//設置哪些列要合并                                 
                            }
                        }
                        else
                        {
                            //不同組
                            if (seq_id == row_total && row_total > 1)//不同組最后一行
                            {
                                merge_rang = GetMergeRang("C", row_index, row_total);//合并區域
                                worksheet.Range[merge_rang].Merge(0);//合并单元格                                                                    
                                artwork_path = dgv.Rows[r].Cells["artwork_path"].Value.ToString();//每組序號01中對應的圖樣路徑
                                artwork_path = !string.IsNullOrEmpty(artwork_path) ? artwork_path : "";
                                if (artwork_path == "")
                                {
                                    //當圖樣路徑是空時,重取此組別中存在的路徑,正常同組只有一張圖樣
                                    artwork_path = getSampleArt(serial_no);
                                }
                                if (File.Exists(artwork_path))
                                {
                                    rang_begin = "C" + (row_index - row_total + 1);
                                    InsertPicture(rang_begin, worksheet, artwork_path);//插入圖片,同組第一行插入
                                }
                                if (formatBy != "CK")
                                    SetMergeRange(worksheet, row_index, row_total, "");//合并區域   
                                else
                                    SetMergeRange(worksheet, row_index, row_total, "CK");//合并區域
                            }
                            if (seq_id == row_total && row_total == 1)
                            {
                                //同組只有一行的情況                                   
                                //插入圖片
                                artwork_path = dgv.Rows[r].Cells["artwork_path"].Value.ToString();//每組序號01中對應的圖樣路徑
                                artwork_path = !string.IsNullOrEmpty(artwork_path) ? artwork_path : "";
                                if (File.Exists(artwork_path))
                                {
                                    rang_begin = "C" + row_index;
                                    InsertPicture(rang_begin, worksheet, artwork_path);//插入圖片,同組第一行插入
                                }
                            }
                        }
                    } //--end of for r>0

                    //表格只有一行時
                    if (r == 0 && dgv.RowCount == 1)
                    {
                        //插入圖片
                        if (File.Exists(artwork_path))
                        {
                            rang_begin = "C" + row_index;
                            InsertPicture(rang_begin, worksheet, artwork_path);//插入圖片
                        }
                    }
                    //隱藏某一行                       
                    if (dgv.Rows[r].Cells["flag_hidden"].Value.ToString() == "True")
                    {
                        Microsoft.Office.Interop.Excel.Range rangeRow = worksheet.Rows[row_index];
                        rangeRow.EntireRow.Hidden = true;
                    }
                    serial_no = dgv.Rows[r].Cells["serial_no"].Value.ToString();
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
                string range_right = "";
                if (formatBy != "CK")
                {
                    worksheet.Columns[1].ColumnWidth = 6;//SEASON
                    worksheet.Columns[2].ColumnWidth = 9;//PLM
                    worksheet.Columns[3].ColumnWidth = 20;//ARTWORK
                    worksheet.Columns[4].ColumnWidth = 10;//CF CODE
                    worksheet.Columns[5].ColumnWidth = 21;//Product Description
                    worksheet.Columns[6].ColumnWidth = 12;//Material
                    worksheet.Columns[7].ColumnWidth = 17;//Size
                    worksheet.Columns[8].ColumnWidth = 21;//Macys Color Code
                    worksheet.Columns[9].ColumnWidth = 10;//MO#
                    worksheet.Columns[10].ColumnWidth = 12;//Ready date
                    worksheet.Columns[11].ColumnWidth = 22;//CF Color Code
                    worksheet.Columns[12].ColumnWidth = 12;//Ex-fty(USD)
                    worksheet.Columns[13].ColumnWidth = 9;//Ex-fty (USD)-special price
                    worksheet.Columns[14].ColumnWidth = 4;//Unit
                    worksheet.Columns[15].ColumnWidth = 6;//MOQ (PCS)
                    worksheet.Columns[16].ColumnWidth = 15;//Surcharge
                    worksheet.Columns[17].ColumnWidth = 30;//Mould Engraving Charge
                    worksheet.Columns[18].ColumnWidth = 18;//Artwork Approved Date/by
                    worksheet.Columns[19].ColumnWidth = 10;//Submission Date
                    worksheet.Columns[20].ColumnWidth = 41;//Sample Approved Date/by
                    worksheet.Columns[21].ColumnWidth = 35;//Macy's System
                    worksheet.Columns[22].ColumnWidth = 10;//Excel Type
                    range_right = string.Format("V{0}", dgv.RowCount + 1);//右下角座標
                }
                else
                {
                    worksheet.Columns[3].ColumnWidth = 20;//ARTWORK
                    range_right = string.Format("S{0}", dgv.RowCount + 1);//右下角座標
                }
                //畫边框线
                //获取Excel多个单元格区域                
                Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", range_right);
                //单元格边框线类型(线型,虚线型)
                excelRange.Borders.LineStyle = 1;
                excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                //字體
                excelRange.Font.Name = "Arial";
                Microsoft.Office.Interop.Excel.Range headerRange;
                headerRange = (formatBy != "CK") ? (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", "V1") : (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", "S1");
                headerRange.Interior.Color = System.Drawing.Color.Yellow.ToArgb(); //OK
                //headerRange.Interior.Color = System.Drawing.Color.FromArgb(255, 197, 153).ToArgb();//出錯可能不支持此顏色             
                headerRange.WrapText = true;  //自动换行
                //headerRange.EntireRow.AutoFit();//行高根据内容自动调整                    

                wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                if (FileName != "" && isOpen == "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveAs(FileName, FormatNum);                       
                        MessageBox.Show("匯出EXCEL成功!" + "\r\n" + FileName, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {                      
                        MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                    }
                    workbook.Close();
                    xlApp.Quit();
                }
                if (isOpen == "open")
                {
                    xlApp.Visible = true;//開啟EXCEL                    
                }
                rang_curr_row = null;
                excelRange = null;
                headerRange = null;
                xlApp = null;
                ReleaseExcel(xlApp, workbook, worksheet);
                GC.Collect();
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }        

        private static string GetMergeRang(string columnName,int current_row_index,int row_total)
        {
            string merge_value = "";
            merge_value = columnName + (current_row_index - row_total + 1) + ":" + columnName + current_row_index; //A2:A4          
            return merge_value;
        }

        private static void InsertPicture(string RangeName, Microsoft.Office.Interop.Excel._Worksheet sheet, string PicturePath)
        {
            Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(RangeName, Type.Missing);
            rng.Select();
            try
            {
                sheet.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue,
                   Convert.ToSingle(rng.Left) + 5, Convert.ToSingle(rng.Top) + 5, rng.Width - 10, 70 - 15);   //插入图片 
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
        }

        private static void SetMergeRange(Microsoft.Office.Interop.Excel.Worksheet worksheet,int row_index, int row_total,string formaBy)
        {
            string merge_rang="";
            merge_rang = GetMergeRang("A", row_index, row_total);
            worksheet.Range[merge_rang].Merge(0);//合并单元格 
            merge_rang = GetMergeRang("B", row_index, row_total);
            worksheet.Range[merge_rang].Merge(0);//合并单元格
            merge_rang = GetMergeRang("D", row_index, row_total);
            worksheet.Range[merge_rang].Merge(0);//合并单元格  
            merge_rang = GetMergeRang("E", row_index, row_total);
            worksheet.Range[merge_rang].Merge(0);//合并单元格 
            merge_rang = GetMergeRang("F", row_index, row_total);
            worksheet.Range[merge_rang].Merge(0);//合并单元格
            if (formaBy != "CK")
            {
                merge_rang = GetMergeRang("N", row_index, row_total);
                worksheet.Range[merge_rang].Merge(0);//合并单元格 
                merge_rang = GetMergeRang("P", row_index, row_total);
                worksheet.Range[merge_rang].Merge(0);//合并单元格 
            }
            else
            {
                //CK FORMAT
                merge_rang = GetMergeRang("G", row_index, row_total);
                worksheet.Range[merge_rang].Merge(0);//合并单元格 
            }
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

        /// <summary>
        /// 銷毁excel對象
        /// </summary>
        private static void ReleaseExcel(Microsoft.Office.Interop.Excel.Application xlApp, Microsoft.Office.Interop.Excel.Workbook workbook,Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {           
            if (worksheet != null)
            {
                //清空excelSheet対象
                //System.Runtime.InteropServices.Marshal.ReleaseComObject((object)worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                worksheet = null;
            }
            if (workbook != null)
            {
                //清空excelBook対象
                //System.Runtime.InteropServices.Marshal.ReleaseComObject((object)workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
            if (xlApp != null)
            {
                //清空excelApp対象
                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;
                //System.Runtime.InteropServices.Marshal.ReleaseComObject((object)xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;                
            }
        }



    }
}
