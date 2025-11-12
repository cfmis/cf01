using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsPlate
    {
        
        public string ModifyExcelFile(string filePath)
        {
            string result ="";
            clsPublicOfGEO clsErp = new clsPublicOfGEO();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("no", typeof(string));
            dt.Columns.Add("vendor_id", typeof(string));
            dt.Columns.Add("mo_id", typeof(string)); 
            dt.Columns.Add("status", typeof(string)); 
            dt.Columns.Add("goods_id", typeof(string));
            dt.Columns.Add("dept_response", typeof(string));
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook workbook = null;
            try
            {
                //创建Excel应用程序实例
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false; // 设置Excel不可见
                excelApp.DisplayAlerts = false; // 关闭警告提示

                // 打开现有的Excel工作簿
                workbook = excelApp.Workbooks.Open(filePath,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //获取第一个工作表
                Worksheet worksheet = (Worksheet)workbook.Worksheets[2];
                int rowCount = worksheet.UsedRange.Rows.Count;
                if (rowCount <= 1)
                {
                    result = "導入的資料不可為空!";
                    return result;
                }
                //給第1列編序號
               
                
                Range rng;
                //檢查列是否存在
                string strNo = "", strId = "", strStatus = "", strStatusDesc = "", strResponse = "";
                rng = (Range)worksheet.Cells[1, 1];//NO
                strNo = rng.Value;
                rng = (Range)worksheet.Cells[1, 2];//加工單號
                strId = rng.Value;
                rng = (Range)worksheet.Cells[1, 7]; //狀態編號
                strStatus = rng.Value;
                rng = (Range)worksheet.Cells[1, 8]; //狀態編號描述
                strStatusDesc = rng.Value;
                rng = (Range)worksheet.Cells[1, 9];//部門回覆
                strResponse = rng.Value;
                if (strNo != "NO" || strId != "加工單號" || strStatus != "狀態編號" || strStatusDesc != "狀態描述" || strResponse != "部門回覆")
                {
                    result = "表頭位欄名稱不正確!請參考設置:" + "\n\r" + "A欄:NO" + "\n\r" + "B欄:加工單號" + "\n\r" + "G欄:狀態編號" + "\n\r" + "H欄:狀態描述" + "\n\r" + "I欄:部門回覆";
                    return result;
                }

                int no = 0;
                string mo_id = "", status = "", goods_id = "", response="";
                DataRow dr = null;
                for (int i = 1; i <= rowCount; i++)
                {
                    if (i > 1)
                    {
                        no = i - 1;
                        worksheet.Cells[i, 1] = no; //No
                        rng = (Range)worksheet.Cells[i, 4];//自定義的狀態序號
                        mo_id = rng.Value;
                        rng = (Range)worksheet.Cells[i, 7];//狀態編號
                        status = rng.Value;
                        rng = (Range)worksheet.Cells[i, 10];//貨品編號
                        goods_id = rng.Value;
                        rng = (Range)worksheet.Cells[i, 9];//部門回覆
                        response = rng.Value;
                        dr = dt.NewRow();
                        dr["no"] = no;
                        dr["vendor_id"] = "";
                        dr["mo_id"] = mo_id;
                        dr["status"] = status;
                        dr["goods_id"] = goods_id;
                        dr["dept_response"] = response;
                        dt.Rows.Add(dr);
                    }
                }

                SqlParameter[] paras1 = new SqlParameter[]
                {                    
                    new SqlParameter ("@import_data",SqlDbType.Structured) {Value = dt}
                };
                DataSet dts = clsErp.ExecuteProcedureReturnDataSet("z_plate_expired", paras1, null);
                dt = dts.Tables[0];
                string strFilter = "";
                DataRow[] drs = null;
                for (int i = 1; i <= rowCount; i++)
                {
                    if (i > 1)
                    {
                        rng = (Range)worksheet.Cells[i, 1];
                        no = (int)rng.Value;
                        strFilter = string.Format("no={0}", no);
                        drs = dt.Select(strFilter);
                        if (drs.Length > 0)
                        {
                            rng = (Range)worksheet.Cells[i, 2]; //單據號
                            rng.Value = drs[0]["id"].ToString();
                            rng = (Range)worksheet.Cells[i, 8]; //狀態描述
                            rng.Value = drs[0]["status_desc"].ToString();
                            rng = (Range)worksheet.Cells[i, 9]; //部門回覆
                            rng.Value = drs[0]["dept_response"].ToString();
                        }
                    }                       
                }                   
                // 保存修改
                workbook.Save();
                result = "";                
            }
            catch (Exception ex)
            {
                result = ex.Message;               
            }
            finally
            {
                //释放COM对象，避免内存泄漏
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                result = "";
            }
            return result;
        }

        // 使用文件对话框选择Excel文件的方法
        public string SelectExcelFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.Filter = "Excel文件 (*.xlsx)|*.xlsx|Excel文件 (*.xls)|*.xls";
                openFileDialog.Filter = "Excel文件 (*.xls)|*.xls";
                openFileDialog.Title = "選擇Excel文件";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }


    }
}
