using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public class clsBkWork
    {
        /// <summary>
        /// 匯入供應商送貨單資料
        /// </summary>
        /// <param name="_ExcelFile"></param>
        /// <param name="progressBar"></param>
        /// <returns></returns>
        public static bool Process_Excel(string _ExcelFile, System.Windows.Forms.ProgressBar progressBar)
        {
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application() { Visible = true };
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(_ExcelFile,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[1];

            //檢查EXCEL欄位是否符合要求
            //const string strFields =@"供應商,送貨單號,送貨日期";
            const string strSql_i =
            @"INSERT INTO jo_buckle_work_assy(id,con_date,artwork,dept_id,area,container_id,layer_id,location_id,contents,box_no,line_no,mo_id,mould_id,remark,create_by,create_date)
             VALUES(@id,@con_date,@artwork,@dept_id,@area,@container_id,@layer_id,@location_id,@contents,@box_no,@line_no,@mo_id,@mould_id,@remark,@user_id,getdate())";

            bool result = false;

            progressBar.Enabled = true;
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Step = 1;

            int row_precessing = 0;
            int row_total = xSheet.UsedRange.Rows.Count;//總行數
            progressBar.Maximum = row_total;

            SqlConnection sqlconn = new SqlConnection(DBUtility.connectionString);
            sqlconn.Open();
            SqlTransaction myTrans = sqlconn.BeginTransaction();
            Microsoft.Office.Interop.Excel.Range rng;
            try
            {
                using (SqlCommand myCommand = new SqlCommand() { Connection = sqlconn, Transaction = myTrans })
                {
                    string ls_id = "";
                    string ls_con_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    int i = 0;
                    for (int ii = 2; ii <= row_total; ii++)
                    {
                        if (ii > 2)
                        {
                            //需重新初連接及事務
                            myCommand.Connection = sqlconn;
                            myTrans = sqlconn.BeginTransaction();//開啟事務為手動提交
                            myCommand.Transaction = myTrans;
                        }
                        myCommand.CommandText = strSql_i;
                        row_precessing = ii;//記錄更在更新的行
                        progressBar.Value += progressBar.Step;
                        if (progressBar.Value == progressBar.Maximum)
                        {
                            progressBar.Enabled = false;
                            progressBar.Visible = false;
                        }

                        myCommand.Parameters.Clear();
                        rng = xSheet.Cells[ii, "M"]; //更新標識欄位                            
                        if (rng.get_Value() == "OK")
                        {
                            myTrans.Commit(); //數據提交
                            continue;         //已更新成功過的不再更新
                        }
                        //處理序號
                        if (i == 0)
                        {
                            ls_id = clsPur.getSerialNo("jo_buckle_work_assy");
                        }
                        else
                        {
                            ls_id = ls_id.Substring(0, 4) + (int.Parse(ls_id.Substring(4, 6)) + 1).ToString("000000");
                        }
                        myCommand.Parameters.AddWithValue("@id", ls_id);
                        myCommand.Parameters.AddWithValue("@con_date", ls_con_date);                        
                        rng = xSheet.Cells[ii, "A"]; //圖樣
                        myCommand.Parameters.AddWithValue("@artwork", rng.Text);
                        rng = xSheet.Cells[ii, "B"]; //部門
                        myCommand.Parameters.AddWithValue("@dept_id", rng.Text);
                        rng = xSheet.Cells[ii, "C"]; //地區
                        myCommand.Parameters.AddWithValue("@area", rng.Text);
                        rng = xSheet.Cells[ii, "D"]; //柜號
                        myCommand.Parameters.AddWithValue("@container_id", rng.Text);
                        rng = xSheet.Cells[ii, "E"]; //層數
                        myCommand.Parameters.AddWithValue("@layer_id", rng.Text);
                        rng = xSheet.Cells[ii, "F"]; //位置
                        myCommand.Parameters.AddWithValue("@location_id", rng.Text);
                        rng = xSheet.Cells[ii, "G"]; //說明
                        myCommand.Parameters.AddWithValue("@contents", rng.Text);
                        rng = xSheet.Cells[ii, "H"]; //箱號
                        myCommand.Parameters.AddWithValue("@box_no", rng.Text);
                        rng = xSheet.Cells[ii, "I"]; //線號
                        myCommand.Parameters.AddWithValue("@line_no", rng.Text);
                        rng = xSheet.Cells[ii, "J"]; //頁數
                        myCommand.Parameters.AddWithValue("@mo_id", rng.Text);
                        rng = xSheet.Cells[ii, "K"]; //模具編號
                        myCommand.Parameters.AddWithValue("@mould_id", rng.Text);
                        rng = xSheet.Cells[ii, "L"]; //備註
                        myCommand.Parameters.AddWithValue("@remark", rng.Text);

                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit(); //數據提交
                        //rng = xSheet.Cells[ii, "L"]; //記錄是否更新成功的標識
                        rng = xSheet.get_Range("M" + ii, Missing.Value);
                        rng.Value2 = "OK";
                        i += 1;
                    }

                    xBook.Save();
                    xSheet = null;
                    xBook = null;
                    xApp.Quit(); //这一句是非常重要的，否则Excel对象不能从内存中退出 
                    xApp = null;
                    result = true;
                }
            }
            catch (Exception E)
            {
                myTrans.Rollback(); //數據回滾                    
                rng = xSheet.get_Range("M" + row_precessing, Missing.Value);
                rng.Value2 = "NG";
                rng.Interior.ColorIndex = 6; //设置Range的背景色 
                xBook.Save();
                result = false;
                throw new Exception(E.Message);
            }
            finally
            {
                sqlconn.Close();
                sqlconn.Dispose();
                myTrans.Dispose();
                if (xApp != null)
                {
                    xApp.Quit();
                    xBook = null;
                    xSheet = null;
                    xBook.Close();
                }

            }
            progressBar.Enabled = false;
            progressBar.Visible = false;

            return result;
        }

    }
}
