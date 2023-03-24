using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using cf01.MDL;
using System.IO;
using System.Data;

namespace cf01.CLS
{
    public class clsQuotation
    {
        /// <summary>
        /// 報價單資料匯入EXCEL
        /// </summary>
        /// <param name="_ExcelFile"></param>
        /// <param name="progressBar"></param>
        /// <returns></returns>       
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        private static clsAppPublic clsAppPublic = new clsAppPublic();
        public static string cust_artwork_path = @"\\192.168.3.12\cf_artwork\quo_photo";

        public static bool Process_Excel(string _ExcelFile, System.Windows.Forms.ProgressBar progressBar)
        {
            //创建Application对象
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application() { Visible = true };
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(_ExcelFile,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[1];
            //Microsoft.Office.Interop.Excel.Range rng1 = xSheet.get_Range("A1", Type.Missing);
            //string str = rng1.Value2;            

            //檢查EXCEL欄位是否符合要求
            const string strFields =
            @"Sales Group,Quote Date,Season,Season Desc,Brand,Brand Desc,Division,Contact,Material,Size,Product Desc,Customer Code,CF Code,Customer Color,CF Color,USD,HKD,RMB,Price Unit,
            Salesman,MOQ,MOQ Desc,MOQ Unit,MWQ,MWQ Unit,Lead Time Min,Lead Time Max,Lead Time Unit,Mould Charge in,Mould Charge CNY,Mould Charge Unit,Remark,Comment,Die Mould USD,Die Mould CNY,
            Account Code,Valid Date,Number Eenter,HKD EX-FTY,USD EX-FTY,Date Req Rcvd,AW,Sub_1,Sub_2,Sub_3,Sub_4,Sub_5,Sub_6,Sub_7,Status,Sample Request,Needle Test,Other Remark,Remark For PDD,
            PLM Code,Trim Color Code,Test Sample For HK,SMS,Sample Card,Meeting Recap,USD DAP,USD Lab Test Prx,MOQ For Test,Formula ID,Create by,Term Price Remark,";

            const string strSql_i =
            @"Insert into quotation 
            (ver,sales_group,temp_code,[date],brand,brand_desc,season,season_desc,formula_id,division,contact,material,[size],product_desc,cust_code,cf_code,cust_color,cf_color,price_usd,price_hkd,price_rmb,price_unit,salesman,moq,moq_desc,moq_unit,mwq,mwq_unit,
            lead_time_min,lead_time_max,lead_time_unit,md_charge,md_charge_cny,md_charge_unit,remark,comment,die_mould_usd,die_mould_cny,account_code,valid_date,number_enter,hkd_ex_fty,usd_ex_fty,date_req,aw,
            Sub_1,Sub_2,Sub_3,Sub_4,Sub_5,Sub_6,Sub_7,status,sample_request,needle_test,remark_other,remark_pdd,crusr,crtim,plm_code,trim_color_code,test_sample_hk,sms,sample_card,meeting_recap,usd_dap,usd_lab_test_prx,moq_for_test,rmb_remark,termremark)            
            VALUES
            (@ver,@sales_group,@temp_code,CASE LEN(@date) WHEN 0 THEN null ELSE @date END,@brand,@brand_desc,@season,@season_desc,@formula_id,@division,@contact,@material,@size,@product_desc,@cust_code,@cf_code,@cust_color,@cf_color,@price_usd,@price_hkd,@price_rmb,
            @price_unit,@salesman,@moq,@moq_desc,@moq_unit,@mwq,@mwq_unit,@lead_time_min,@lead_time_max,@lead_time_unit,@md_charge,@md_charge_cny,@md_charge_unit,@remark,@comment,@die_mould_usd,@die_mould_cny,@account_code,@valid_date,@number_enter,@hkd_ex_fty,@usd_ex_fty,@date_req,@aw,
            @Sub_1,@Sub_2,@Sub_3,@Sub_4,@Sub_5,@Sub_6,@Sub_7,@status,@sample_request,@needle_test,@remark_other,@remark_pdd,@user_id,getdate(),@plm_code,@trim_color_code,@test_sample_hk,@sms,@sample_card,@meeting_recap,@usd_dap,@usd_lab_test_prx,@moq_for_test,@rmb_remark,@termremark)";
            const string strSql_i_sub =
            @"INSERT INTO quotation_group(temp_code,seq_id,group_id,crusr,crtim) VALUES(@temp_code,'001',@group_id,@user_id,getdate())";
            const string strsql_sub_mo =
               @"Insert into quotation_sub(temp_code,seq_id,sub,crusr,crtim) Values(@temp_code,@seq_id,@sub_mo,@user_id,getdate())";

            //檢查字段的排列順序是否正確
            System.Data.DataTable dt = clsPublicOfCF01.GetDataTable("SELECT seq,column_name FROM quotation_excel Order by seq");
            System.Data.DataRow[] dr = null;
            bool result = true, flag_column = true, flag_seq = true;
            string clsName = "", strCheck_seq = "";
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                //execl 表頭名是否正確
                Microsoft.Office.Interop.Excel.Range rng = xSheet.Cells[1, i];
                clsName = rng.get_Value() + ",";
                if (!strFields.Contains(clsName))
                {
                    flag_column = false;
                    break;
                }
                //表頭各個欄位排列次序是否正確
                dr = dt.Select(string.Format("seq={0}", i));
                if (dr[0]["column_name"].ToString() != rng.get_Value())
                {
                    strCheck_seq = rng.get_Value();
                    flag_seq = false;
                    break;
                }
            }

            if (!flag_column || !flag_seq)
            {
                xSheet = null;
                xBook = null;
                xApp.Quit(); //將Excel对象从内存中退出
                xApp = null;
                if (!flag_column)
                    MessageBox.Show(string.Format("欄位名稱[{0}]不正確,請返回檢查!", clsName), "提示信息", MessageBoxButtons.OK);
                else
                    MessageBox.Show(string.Format("欄位名稱[{0}]排列次序不正確,請返回檢查!", strCheck_seq), "提示信息", MessageBoxButtons.OK);
                result = false;
            }
            else
            {
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
                    string group;
                    string temp_doc = "",create_by="",ls_formula="",ls_rmb_remark="";
                    using (SqlCommand myCommand = new SqlCommand() { Connection = sqlconn, Transaction = myTrans })
                    //using (SqlCommand myCommand = new SqlCommand() { Connection = sqlconn })
                    {
                        string[] arySub = new string[7];
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
                            rng = xSheet.Cells[ii, "BP"]; //更新標識欄位                            
                            if (rng.get_Value() == "OK")
                            {
                                myTrans.Commit(); //數據提交
                                continue;    //已更新成功過的不再更新
                            }
                            rng = xSheet.Cells[ii, "A"]; //Sales Group
                            group = rng.Text;

                            if (string.IsNullOrEmpty(group))
                            {
                                break;
                                //group = "0";
                            }
                            myCommand.Parameters.AddWithValue("@ver", "0");
                            myCommand.Parameters.AddWithValue("@sales_group", group);
                            temp_doc = Get_Quote_SeqNo();
                            myCommand.Parameters.AddWithValue("@temp_code", temp_doc);
                            rng = xSheet.Cells[ii, "B"];   //Quote_Date
                            //myCommand.Parameters.AddWithValue("@date", clsAppPublic.Return_String_Date(Quote_Date));
                            myCommand.Parameters.AddWithValue("@date", rng.Text);
                            rng = xSheet.Cells[ii, "C"]; //Season
                            myCommand.Parameters.AddWithValue("@season", rng.Text);
                            rng = xSheet.Cells[ii, "D"]; //Season Desc      
                            myCommand.Parameters.AddWithValue("@season_desc", rng.Text);
                            rng = xSheet.Cells[ii, "E"]; //Brand                 
                            myCommand.Parameters.AddWithValue("@brand", rng.Text);
                            rng = xSheet.Cells[ii, "F"]; //Brand Desc
                            myCommand.Parameters.AddWithValue("@brand_desc", rng.Text);
                            rng = xSheet.Cells[ii, "G"]; //Division
                            myCommand.Parameters.AddWithValue("@division", rng.Text);
                            rng = xSheet.Cells[ii, "H"]; //Contact
                            myCommand.Parameters.AddWithValue("@contact", rng.Text);
                            rng = xSheet.Cells[ii, "I"]; //Material
                            myCommand.Parameters.AddWithValue("@material", rng.Text);
                            rng = xSheet.Cells[ii, "J"]; //Size
                            myCommand.Parameters.AddWithValue("@size", rng.Text);
                            rng = xSheet.Cells[ii, "K"]; //Product Desc
                            myCommand.Parameters.AddWithValue("@product_desc", rng.Text);
                            rng = xSheet.Cells[ii, "L"]; //Customer Code
                            myCommand.Parameters.AddWithValue("@cust_code", rng.Text);
                            rng = xSheet.Cells[ii, "M"]; //CF Code
                            myCommand.Parameters.AddWithValue("@cf_code", rng.Text);
                            rng = xSheet.Cells[ii, "N"]; //Customer Color
                            myCommand.Parameters.AddWithValue("@cust_color", rng.Text);
                            rng = xSheet.Cells[ii, "O"]; //CF Color
                            myCommand.Parameters.AddWithValue("@cf_color", rng.Text);
                            rng = xSheet.Cells[ii, "P"]; //USD
                            myCommand.Parameters.AddWithValue("@price_usd", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "Q"]; //HKD
                            myCommand.Parameters.AddWithValue("@price_hkd", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "R"]; //RMB
                            myCommand.Parameters.AddWithValue("@price_rmb", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "S"]; //Price Unit
                            myCommand.Parameters.AddWithValue("@price_unit", rng.Text);
                            rng = xSheet.Cells[ii, "T"]; //Salesman
                            myCommand.Parameters.AddWithValue("@salesman", rng.Text);
                            rng = xSheet.Cells[ii, "U"]; //MOQ
                            myCommand.Parameters.AddWithValue("@moq", int.Parse(Get_int_string(rng.Text)));//clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "V"]; //MOQ Desc
                            myCommand.Parameters.AddWithValue("@moq_desc", rng.Text);
                            rng = xSheet.Cells[ii, "W"]; //MOQ Unit
                            myCommand.Parameters.AddWithValue("@moq_unit", rng.Text);
                            rng = xSheet.Cells[ii, "X"]; //MWQ                           
                            myCommand.Parameters.AddWithValue("@mwq", int.Parse(Get_int_string(rng.Text)));//clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "Y"]; //MWQ Unit
                            myCommand.Parameters.AddWithValue("@mwq_unit", rng.Text);
                            rng = xSheet.Cells[ii, "Z"]; //Lead Time Min
                            myCommand.Parameters.AddWithValue("@lead_time_min", int.Parse(Get_int_string(rng.Text)));
                            rng = xSheet.Cells[ii, "AA"]; //Lead Time Max
                            myCommand.Parameters.AddWithValue("@lead_time_max", int.Parse(Get_int_string(rng.Text)));
                            rng = xSheet.Cells[ii, "AB"]; //Lead Time Unit
                            myCommand.Parameters.AddWithValue("@lead_time_unit", rng.Text);
                            rng = xSheet.Cells[ii, "AC"]; //Mould Charge in
                            myCommand.Parameters.AddWithValue("@md_charge", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "AD"]; //Mould Charge CNY
                            myCommand.Parameters.AddWithValue("@md_charge_cny", rng.Text);
                            rng = xSheet.Cells[ii, "AE"]; //Mould Charge Unit
                            myCommand.Parameters.AddWithValue("@md_charge_unit", rng.Text);
                            rng = xSheet.Cells[ii, "AF"]; //Remark
                            myCommand.Parameters.AddWithValue("@remark", rng.Text);
                            rng = xSheet.Cells[ii, "AG"]; //Comment
                            myCommand.Parameters.AddWithValue("@comment", rng.Text);
                            rng = xSheet.Cells[ii, "AH"]; //Die Mould USD
                            myCommand.Parameters.AddWithValue("@die_mould_usd", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "AI"]; //Die Mould CNY
                            myCommand.Parameters.AddWithValue("@die_mould_cny", rng.Text);
                            rng = xSheet.Cells[ii, "AJ"]; //Account Code
                            myCommand.Parameters.AddWithValue("@account_code", rng.Text);
                            rng = xSheet.Cells[ii, "AK"]; //Number Eenter
                            myCommand.Parameters.AddWithValue("@number_enter", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "AL"]; //HKD EX-FTY
                            myCommand.Parameters.AddWithValue("@hkd_ex_fty", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "AM"]; //USD EX-FTY
                            myCommand.Parameters.AddWithValue("@usd_ex_fty", clsAppPublic.Return_Float_Value(rng.Text));
                            rng = xSheet.Cells[ii, "AN"]; //Valid Date
                            //myCommand.Parameters.AddWithValue("@valid_date", clsAppPublic.Return_String_Date(rng.Text));
                            myCommand.Parameters.AddWithValue("@valid_date", rng.Text);
                            rng = xSheet.Cells[ii, "AO"]; //Date Req Rcvd
                            myCommand.Parameters.AddWithValue("@date_req", rng.Text);
                            rng = xSheet.Cells[ii, "AP"]; //AW
                            myCommand.Parameters.AddWithValue("@aw", rng.Text);
                            rng = xSheet.Cells[ii, "AQ"]; //Sub_1
                            arySub[0] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_1", rng.Text);
                            rng = xSheet.Cells[ii, "AR"]; //Sub_2
                            arySub[1] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_2", rng.Text);
                            rng = xSheet.Cells[ii, "AS"]; //Sub_3
                            arySub[2] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_3", rng.Text);
                            rng = xSheet.Cells[ii, "AT"]; //Sub_4
                            arySub[3] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_4", rng.Text);
                            rng = xSheet.Cells[ii, "AU"]; //Sub_5
                            arySub[4] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_5", rng.Text);
                            rng = xSheet.Cells[ii, "AV"]; //Sub_6
                            arySub[5] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_6", rng.Text);
                            rng = xSheet.Cells[ii, "AW"]; //Sub_7
                            arySub[6] = rng.Text;
                            myCommand.Parameters.AddWithValue("@Sub_7", rng.Text);
                            rng = xSheet.Cells[ii, "AX"]; //Status
                            myCommand.Parameters.AddWithValue("@status", rng.Text);
                            rng = xSheet.Cells[ii, "AY"]; //Sample Request
                            myCommand.Parameters.AddWithValue("@sample_request", rng.Text);
                            rng = xSheet.Cells[ii, "AZ"]; //Needle Test
                            myCommand.Parameters.AddWithValue("@needle_test", rng.Text);
                            rng = xSheet.Cells[ii, "BA"]; //Other Remark
                            myCommand.Parameters.AddWithValue("@remark_other", rng.Text);
                            rng = xSheet.Cells[ii, "BB"]; //Remark For PDD
                            myCommand.Parameters.AddWithValue("@remark_pdd", rng.Text);
                            rng = xSheet.Cells[ii, "BC"]; //PLM Code
                            myCommand.Parameters.AddWithValue("@plm_code", rng.Text);
                            rng = xSheet.Cells[ii, "BD"]; //Trim Color Code
                            myCommand.Parameters.AddWithValue("@trim_color_code", rng.Text);
                            rng = xSheet.Cells[ii, "BE"]; //Test Sample For HK
                            myCommand.Parameters.AddWithValue("@test_sample_hk", rng.Text);
                            rng = xSheet.Cells[ii, "BF"]; //SMS
                            myCommand.Parameters.AddWithValue("@sms", rng.Text);
                            rng = xSheet.Cells[ii, "BG"]; //Sample Card
                            myCommand.Parameters.AddWithValue("@sample_card", rng.Text);
                            rng = xSheet.Cells[ii, "BH"]; //Meeting Recap
                            myCommand.Parameters.AddWithValue("@meeting_recap", rng.Text);
                            rng = xSheet.Cells[ii, "BI"]; //USD DAP
                            myCommand.Parameters.AddWithValue("@usd_dap", rng.Text);
                            rng = xSheet.Cells[ii, "BJ"]; //USD Lap Test Prx
                            myCommand.Parameters.AddWithValue("@usd_lab_test_prx", rng.Text);
                            rng = xSheet.Cells[ii, "BK"]; //MOQ For Test   
                            //myCommand.Parameters.AddWithValue("@moq_for_test", rng.Text);
                            myCommand.Parameters.AddWithValue("@moq_for_test", int.Parse(Get_int_string(rng.Text)));                           
                            rng = xSheet.Cells[ii, "BL"]; //Formula ID
                            ls_formula = string.IsNullOrEmpty(rng.Text) ? "*" : rng.Text;
                            myCommand.Parameters.AddWithValue("@formula_id", ls_formula);
                            rng = xSheet.Cells[ii, "BM"]; //Create By
                            create_by = string.IsNullOrEmpty(rng.Text) ? DBUtility._user_id : rng.Text;
                            myCommand.Parameters.AddWithValue("@user_id", create_by);
                            rng = xSheet.Cells[ii, "BN"]; //Term Price Remark
                            myCommand.Parameters.AddWithValue("@termremark", rng.Text);
                            //myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            ls_rmb_remark = Get_Rmb_Remark(ls_formula);
                            myCommand.Parameters.AddWithValue("@rmb_remark", ls_rmb_remark);
                            myCommand.ExecuteNonQuery();                            

                            //更新組別
                            myCommand.CommandText = strSql_i_sub;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@temp_code", temp_doc);
                            myCommand.Parameters.AddWithValue("@group_id", group);
                            myCommand.Parameters.AddWithValue("@user_id", create_by);
                            myCommand.ExecuteNonQuery();
                          
                            //更新Sub_MO
                            string seq_id;
                            for (int j = 0; j < arySub.Length; j++)
                            {
                                if (!string.IsNullOrEmpty(arySub[j].Trim()))
                                {
                                    seq_id = String.Format("{0:D3}", j + 1);
                                    myCommand.CommandText = strsql_sub_mo;
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@temp_code", temp_doc);
                                    myCommand.Parameters.AddWithValue("@seq_id", seq_id);
                                    myCommand.Parameters.AddWithValue("@sub_mo", arySub[j]);
                                    myCommand.Parameters.AddWithValue("@user_id", create_by);
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                            myTrans.Commit(); //數據提交
                            rng = xSheet.Cells[ii, "BO"]; //記錄是否更新成功的標識                            
                            rng = xSheet.get_Range("BO" + ii, Missing.Value);
                            rng.Value2 = "OK";
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
                    rng = xSheet.get_Range("BO" + row_precessing, Missing.Value);
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
            }

            return result;
        }

         private static string Get_int_string(string pString)
        {
            string strInt;
            if (string.IsNullOrEmpty(pString))
                strInt = "0";
            else
                strInt = pString;
            return strInt;
        }

        public static string Get_Quote_SeqNo()
        {
            const string strsql = @"SELECT MAX(temp_code) AS seq_max FROM quotation with(nolock)";
            System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            string strMax = "";
            if (!string.IsNullOrEmpty(dt.Rows[0]["seq_max"].ToString()))
            {
                strMax = dt.Rows[0]["seq_max"].ToString();
                strMax = strMax.Substring(1, 9);
                strMax = "Z" + (Convert.ToInt32(strMax) + 1).ToString("000000000");
            }
            else
            {
                strMax = "Z" + "000000001";
            }
            return strMax;
        }

        public static string Return_New_Version(string pOldVer)
        {
            string strVer = (Convert.ToInt16(pOldVer) + 1).ToString();
            return strVer;
        }

        public static DataTable GetUserGroup()
        {
            //string strSql = string.Format(@"Select '1' From sys_user where user_id='{0}' AND (group_id='DG_PDD' OR group_id='HK_PDD')", DBUtility._user_id); 
            //2023/03/23改為從CF01中取group_id
            string strSql = string.Format(@"Select user_group As group_id From tb_sy_user Where uname='{0}' AND (user_group='DG_PDD' OR user_group='HK_PDD')", DBUtility._user_id);
            System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        public static void IsDisplayRemark_PDD(DataGridView dgv, DataGridViewColumn clsName)
        {
            //顯示HK PDD,DG PDD備註
                     
            System.Data.DataTable dt = GetUserGroup(); 
            //false--不可見;true--可見
            if (dt.Rows.Count == 0)
            {
                //用戶id=ADMIN時 HK,DG備註全顯示
                clsName.Visible = (DBUtility._user_id.ToUpper() == "ADMIN") ? true : false;
            }
            else
            {
                if (dt.Rows[0]["group_id"].ToString() == "HK_PDD")
                {
                    //HK,DG備註全顯示
                    clsName.Visible = true;
                }
                if (dt.Rows[0]["group_id"].ToString() == "DG_PDD" && clsName.Name=="remark_pdd_dg")
                {
                    //只顯示DG備註
                    clsName.Visible = true;
                }                
            }
        }

        public static void Set_Brand_id(DevExpress.XtraEditors.LookUpEdit obj)
        {
            const string strSql =
            @"SELECT S.id,S.cdesc,S.type_desc 
            FROM
            (SELECT id,name AS cdesc,'牌子' AS type_desc,'0' as seq FROM cd_brand with(nolock)
            UNION
            SELECT id,name AS cdesc,CASE customer_group WHEN '2' then '洋行' ELSE '普通客戶' END AS type_desc,'1' AS seq
            FROM it_customer with(nolock) WHERE state='1') S
            ORDER BY S.seq,S.id,S.type_desc";
            System.Data.DataTable dtDept = new System.Data.DataTable();
            dtDept = clsPublicOfGEO.GetDataTable(strSql);

            System.Data.DataRow dr1 = dtDept.NewRow();//插一空行   
            dr1["id"] = "**";
            dr1["cdesc"] = "所有的牌子";
            dtDept.Rows.InsertAt(dr1, 0);

            System.Data.DataRow dr = dtDept.NewRow();//插一空行 
            dr["id"] = "*";
            dr["cdesc"] = "所有的牌子";
            dtDept.Rows.InsertAt(dr, 0);

            System.Data.DataRow dr2 = dtDept.NewRow();//插一空行 
            dr2["id"] = "";
            dtDept.Rows.InsertAt(dr2, 0);
            obj.Properties.DataSource = dtDept;
            obj.Properties.ValueMember = "id";
            obj.Properties.DisplayMember = "id";
        }

        /// <summary>
        /// 根據不同牌子定義單價不同的小數位
        /// </summary>
        /// <param name="pBrand_id"></param>
        /// <returns></returns>
        public static int Get_Decimal(string pBrand_id)
        {
            //COAC牌子作特別處理，小數點取3位，其他牌子取2位
            //JOUL牌子作特別處理，小數點取3位，其他牌子取2位2016-10-12
            string strBrand_id, strResult,sql;
            if (string.IsNullOrEmpty(pBrand_id))
                strBrand_id = "";
            else
            {
                if (pBrand_id == "*" || pBrand_id == "**")
                {
                    strBrand_id = "*";
                }
                else
                {                    
                    //因有些是直接用客戶編號當作牌子，所以增加以下處理方法
                    sql = string.Format(@"SELECT '1' FROM quotation_decimal WHERE brand_id='{0}'", pBrand_id);
                    strResult = clsPublicOfCF01.ExecuteSqlReturnObject(sql);
                    if (strResult == "1")
                    {
                        strBrand_id = pBrand_id; //客戶編號當作牌子
                    }
                    else
                    {
                        strBrand_id = pBrand_id.Substring(0, 5); //有牌子編號的按此方法處理                       
                    }
                }
            }
            sql = string.Format(@"SELECT '1' FROM quotation_decimal WHERE brand_id='{0}'", strBrand_id);
            strResult = clsPublicOfCF01.ExecuteSqlReturnObject(sql);
            int iDecimal;
            if (strResult == "1")
                iDecimal = 3;
            else
                iDecimal = 2;
            return iDecimal;
        }


        /// <summary>
        /// 依據牌子找到對應的公式，如參數為空，則取默認的值
        /// </summary>
        /// <param name="Brand_id","strFormula_id","hkBP","princ_unit","copyType","vnBP"></param>        
        public static mdlFormula_Result Get_Cust_Formula(string pBrand_id, string strFormula_id, string hkBP, string pUnit,string edit_state, string vnBP,bool flag_vn)
        {
            int iDecimal = Get_Decimal(pBrand_id);
            //*--------------------------------------------------------
            //PCS,SET,所有牌子取小數點后三位 2021.09.28 Sze 
            const string strDecimal3 = "PCS,SET,PC";
            if (strDecimal3.Contains(pUnit.ToUpper()))
            {
                iDecimal = 3;
            }
            //*---------------------------------------------------------

            mdlFormula_Result objResult = new mdlFormula_Result();
            const string strSql_all =
                @"SELECT brand_id,usd1,usd2,Isnull(usd3,0) as usd3,rmb1,rmb2,hkd1,hkd2,bp_hkd_ex,discount,vndbp1,vndusd1,vnd1  
                FROM dbo.quotation_formula WHERE brand_id='*'";
            System.Data.DataTable dt = new System.Data.DataTable();
            if (string.IsNullOrEmpty(strFormula_id))
            {
                //如果不輸入計價公式,則以公共計價公式"*"
                dt = clsPublicOfCF01.GetDataTable(strSql_all);
            }
            else
            {
                string strSql = string.Format(
                    @"SELECT brand_id,usd1,usd2,Isnull(usd3,0) as usd3,rmb1,rmb2,hkd1,hkd2,bp_hkd_ex,discount,vndbp1,vndusd1,vnd1 
                    FROM dbo.quotation_formula WHERE brand_id='{0}'", strFormula_id);
                dt = clsPublicOfCF01.GetDataTable(strSql);
                //輸入的牌子非空，但找不到對應公式參數時重取默認的公共計價公式參數
                if (dt.Rows.Count == 0)
                {
                    dt = clsPublicOfCF01.GetDataTable(strSql_all);
                }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("請設置好公式參數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                objResult.price_usd = 0;
                objResult.price_hkd = 0;
                objResult.price_rmb = 0;
                objResult.price_vnd = 0;
                objResult.hkd_ex_fty = 0;
                objResult.usd_ex_fty = 0;                               
                objResult.discount = 0;

                objResult.vnd_bp = 0;
                objResult.price_vnd_usd = 0;
                objResult.price_vnd = 0;
                objResult.price_vnd_grs = 0;
                objResult.price_vnd_pcs = 0;
                return objResult;//如果找不到對應計價公式則直接返回
            }
            float bp, usd1, usd2, rmb1, rmb2, hkd1, hkd2, usd3, discount,vn_bp, vndbp1,vndusd1,vnd1;
            bp = string.IsNullOrEmpty(hkBP) ? 0.00f : float.Parse(hkBP);
            vn_bp = string.IsNullOrEmpty(vnBP) ? 0.00f : float.Parse(vnBP);

            usd1 = float.Parse(dt.Rows[0]["usd1"].ToString());
            usd2 = float.Parse(dt.Rows[0]["usd2"].ToString());
            rmb1 = float.Parse(dt.Rows[0]["rmb1"].ToString());
            rmb2 = float.Parse(dt.Rows[0]["rmb2"].ToString());
            hkd1 = float.Parse(dt.Rows[0]["hkd1"].ToString());
            hkd2 = float.Parse(dt.Rows[0]["hkd2"].ToString());
            usd3 = string.IsNullOrEmpty(dt.Rows[0]["usd3"].ToString()) ? 0.00f : float.Parse(dt.Rows[0]["usd3"].ToString());           
            discount = string.IsNullOrEmpty(dt.Rows[0]["discount"].ToString()) ? 0.00f : float.Parse(dt.Rows[0]["discount"].ToString()); //折扣率
            objResult.discount = discount;
            //越南計算公式參數
            vndbp1 = float.Parse(dt.Rows[0]["vndbp1"].ToString());
            vndusd1 = float.Parse(dt.Rows[0]["vndusd1"].ToString());
            vnd1 = float.Parse(dt.Rows[0]["vnd1"].ToString());                       
                       
            //USD公式：(入機數 X 1.15)/7.72 保留兩們小數點
            //RMB 17%VAT 公式：入機數*1.17*0.82
            float number_input = bp > 0 ? bp : 0.00f;
            if (number_input > 0)
            {
                objResult.price_usd = float.Parse(Math.Round((number_input * usd1) / usd2, iDecimal).ToString());//USD公式：(入機數 X 1.15)/7.72 保留3位小數點
                //RMB 17%VAT 公式：入機數*1.17*0.82
                //objResult.price_rmb = float.Parse(Math.Round(number_input * rmb1 * rmb2, iDecimal).ToString()); //2021.09.28 cancel
                //*----------------------------2021.09.28
                objResult.price_rmb = float.Parse(Math.Round(number_input * rmb1 * rmb2, 2).ToString()); //2021.09.28 iDecimal update to 2                
                //*----------------------------
            }
            else
            {
                objResult.price_usd = 0;
                objResult.price_rmb = 0;
            }

            //計算越南單價 start,原來的其它單價計算不變 2023/02/07
            //if (copyType == "1")
            //{               
            int rate_price_unit = 1;                
            switch (pUnit.ToUpper())
            {
                case "SET":
                case "PCS":
                case "PC":
                    rate_price_unit = 1;
                    break;
                case "DZS":
                case "DZ":
                    rate_price_unit = 12;
                    break;
                case "GRS":
                case "GR":
                    rate_price_unit = 144;
                    break;
                case "K":
                case "THD":
                    rate_price_unit = 1000;
                    break;
                case "H":
                    rate_price_unit = 100;
                    break;
                default:
                    rate_price_unit = 1;
                    break;
            }
            if (number_input > 0 && flag_vn)
            {
                //vn_bp是傳進來的參數
                objResult.vnd_bp = float.Parse(Math.Round(number_input * (1 + vndbp1 / 100), 2).ToString());//計算之后的越南BP
                if (edit_state == "EDIT")
                {
                    if (vn_bp > 0 && vn_bp != objResult.vnd_bp)
                    {
                        //if (edit_state == "EDIT")
                        //{
                        //    objResult.vnd_bp = vn_bp;//如果手動更改了VN_BP,則以手勸更改的為準
                        //}
                        objResult.vnd_bp = vn_bp;
                    }
                }
                objResult.price_vnd_usd = float.Parse(Math.Round(objResult.vnd_bp / vndusd1, 2).ToString());
                objResult.price_vnd = float.Parse(Math.Round(objResult.price_vnd_usd * vnd1,0).ToString());//原單位單價
                //PCS單價
                if ("PCS,PC,SET".Contains(pUnit.ToUpper()))                    
                    objResult.price_vnd_pcs = objResult.price_vnd;//轉為PCS單價                   
                else                    
                    objResult.price_vnd_pcs = float.Parse(Math.Round(objResult.price_vnd / rate_price_unit, 0).ToString());                    
                //GRS單價
                if ("GRS,GR".Contains(pUnit.ToUpper()))                    
                    objResult.price_vnd_grs = objResult.price_vnd;//直接等于GRS單價                    
                else                    
                    objResult.price_vnd_grs = objResult.price_vnd_pcs * 144;//轉為GRS單價
            }
            else
            {
                objResult.vnd_bp = 0;
                objResult.price_vnd_usd = 0;
                objResult.price_vnd = 0;
                objResult.price_vnd_pcs = 0;
                objResult.price_vnd_grs = 0;
            }
            //} //計算越南單價 end 


            //HKD公式：USD$欄*7.8
            if (objResult.price_usd > 0)
                number_input = objResult.price_usd;
            else
                number_input = 0.00f;
            if (number_input > 0)
                objResult.price_hkd = float.Parse(Math.Round(number_input * hkd1, iDecimal).ToString());
            else
                objResult.price_hkd = 0;

            //HKD EX-FTY 公式：HKD$ *0.9
            if (objResult.price_hkd > 0)
                number_input = objResult.price_hkd;
            else
                number_input = 0.00f;

            if (number_input > 0)
                objResult.hkd_ex_fty = float.Parse(Math.Round(number_input * hkd2, iDecimal).ToString());
            else
                objResult.hkd_ex_fty = 0;

            //2016-10-28 增加以下代碼
            //對不同的單位進行四舍五入 
            /*----------------------------------------------------   
             * //const string str1 = "PCS,SET,DZ,DZS,PC,Pcs,pcs,Set,set";//小單位            
            if (str1.Contains(pUnit)) //小單位
            {
                //objResult.price_hkd=clsAppPublic.Return_Float_Value(String.Format("{0:N1}", objResult.price_hkd));//1位;
                objResult.price_hkd = (float)Math.Round(objResult.price_hkd, 1);//1位小數
                objResult.hkd_ex_fty = (float)Math.Round(objResult.hkd_ex_fty, 1);//1位小數
                ////2位或3位小數視iDecimal而定
                //objResult.price_usd =(float)Math.Round(objResult.price_usd,iDecimal);
                //objResult.price_rmb =(float)Math.Round(objResult.price_rmb,iDecimal);
            }
            */ //----------------------------------------------------
            const string str2 = "GRS,H,K,THD,GR";  //大單位
            if (str2.Contains(pUnit.ToUpper()))
            {
                if (objResult.price_hkd > 1)
                    objResult.price_hkd = (float)Math.Round(objResult.price_hkd);//四舍五入保留整
                else
                    objResult.price_hkd = (float)Math.Round(objResult.price_hkd, 2);//四舍五入保留2位小數
                if (objResult.hkd_ex_fty > 1)
                    objResult.hkd_ex_fty = (float)Math.Round(objResult.hkd_ex_fty); //四舍五入保留整
                else
                    objResult.hkd_ex_fty = (float)Math.Round(objResult.hkd_ex_fty, 2); //四舍五入保留2位小數
            }
            //2016-10-28

            //設置HKD EX-FTY是否與BP保持一致
            if (dt.Rows.Count > 0)
            {
                string strCheck = dt.Rows[0]["bp_hkd_ex"].ToString();
                if (strCheck == "True")
                {
                    objResult.hkd_ex_fty = bp;
                }
            }
            //hkd_ex_fty/usd3
            objResult.usd_ex_fty = usd3 > 0 ? float.Parse(Math.Round(objResult.hkd_ex_fty / usd3, iDecimal).ToString()) : 0;

            //2017-03-21 katie要求處理RMB,保留一位小數CARV-01
            if (pBrand_id.Contains("CARV-01"))
            {
                objResult.price_rmb = float.Parse(Math.Round(objResult.price_rmb, 1).ToString());
            }            

            return objResult;
        }

        /// <summary>
        /// 計算折扣公式 2016-11-15, 2021/09/28增加單價單位參數pUnit
        /// </summary>
        /// <param name="pBrand_id"></param>
        /// <param name="pDisc"></param>
        /// <param name="stuDisc"></param>
        /// <returns></returns>
        public static mdlFormula_Result Get_Cust_Formula_Disc(string pBrand_id, string pDisc, mdlFormula_Result stuDisc,string pUnit)
        {
            int iDecimal = Get_Decimal(pBrand_id);
            //*--------------------------------------------------------
            //PCS,SET,所有牌子取小數點后三位 2021.09.28 Sze 
            const string strDecimal3 = "PCS,SET,PC";
            if (strDecimal3.Contains(pUnit.ToUpper()))
            {
                iDecimal = 3;
            }
            //*---------------------------------------------------------

            float fltDisc;
            if (string.IsNullOrEmpty(pDisc))
                fltDisc = 0;
            else
                fltDisc = clsAppPublic.Return_Float_Value(pDisc);

            mdlFormula_Result objResult = new mdlFormula_Result();
            if (fltDisc == 0)
            {
                objResult.disc_price_usd = stuDisc.price_usd;
                objResult.disc_price_hkd = stuDisc.price_hkd;
                objResult.disc_price_rmb = stuDisc.price_rmb;
                objResult.disc_hkd_ex_fty = stuDisc.hkd_ex_fty;
            }
            else
            {
                objResult.disc_price_usd = (float)Math.Round(stuDisc.price_usd * (1 - fltDisc / 100), iDecimal);
                objResult.disc_price_hkd = (float)Math.Round(stuDisc.price_hkd * (1 - fltDisc / 100), iDecimal);
                //objResult.disc_price_rmb = (float)Math.Round(stuDisc.price_rmb * (1 - fltDisc / 100), iDecimal); //2021.09.28 cancel
                objResult.disc_price_rmb = (float)Math.Round(stuDisc.price_rmb * (1 - fltDisc / 100), 2); //2021.09.28 iDecimal updated to 2
                objResult.disc_hkd_ex_fty = (float)Math.Round(stuDisc.hkd_ex_fty * (1 - fltDisc / 100), iDecimal);
            }
            return objResult;
        }

        public static void Export_To_Excel(DataGridView dgv)
        {
            //統一全選列的列名稱
            string field_name;
            string field_select_name = "flag_select";//因不定價與報價調用同一個類的代碼
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                field_name = dgv.Columns[i].Name;
                //因選擇字段的列名稱有可能是flagselect 和flag_select,故用變量代替
                if (field_name == "flagSelect")
                {
                    field_select_name = "flagSelect";
                    break;
                }
            }

            //判斷是否有選取的行
            bool isSelect = false;
            for (int rowNo = 0; rowNo < dgv.RowCount; rowNo++) //開始行循環
            {
                if (dgv.Rows[rowNo].Cells[field_select_name].Value.ToString() == "True")
                {
                    isSelect = true;
                    break;
                }                
            }
            if (isSelect == false)
            {
                MessageBox.Show("請選取要匯出EXCEL的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }        
            
            //匯出EXCEL
            SaveFileDialog saveFile = new SaveFileDialog() { 
                Filter = "Excel files(*.xls)|*.xls", 
                FilterIndex = 0, 
                RestoreDirectory = true, 
                CreatePrompt = true, 
                Title = "导出Excel文件到" 
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                const string strSub_mo = "sub_1,sub_2,sub_3,sub_4,sub_5,sub_6,sub_7";
                string str = " ";
                //写标题
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    field_name = dgv.Columns[i].Name;
                    if (dgv.Columns[i].Visible || strSub_mo.Contains(field_name))
                    {
                        if (i > 0)
                        {
                            str += "\t";
                        }
                        str += dgv.Columns[i].HeaderText;// dv.Table.Columns[i].ColumnName;
                    }
                    else
                        continue;
                }
                sw.WriteLine(str);


                //写内容
                string col_value,tempstr = " ";
                for (int rowNo = 0; rowNo < dgv.RowCount; rowNo++) //開始行循環
                {
                    if (dgv.Rows[rowNo].Cells[field_select_name].Value.ToString() == "True")
                    {
                        tempstr = " ";
                        for (int cl = 0; cl < dgv.ColumnCount; cl++) //開始列循環
                        {
                            field_name = dgv.Columns[cl].Name;//取得列名稱
                            if (dgv.Columns[cl].Visible || strSub_mo.Contains(field_name))
                            {
                                if (cl > 0)
                                {
                                    tempstr += "\t";
                                }
                                col_value = dgv.Rows[rowNo].Cells[cl].Value.ToString().Trim();
                                //string l_strResult =  你的字符串.Replace("\n", "").Replace(" ","").Replace("\t","").Replace("\r","");
                                col_value = col_value.Replace("\n", "").Replace("\t", "").Replace("\r", "");
                                if (field_name == "date" || field_name == "valid_date" || field_name== "flag_vnd_date") //定價日期或有效日期
                                {
                                    if (!string.IsNullOrEmpty(col_value))
                                    {
                                        col_value = DateTime.Parse(col_value).ToString("yyyy/MM/dd");
                                    }
                                }
                                tempstr += col_value;
                            }
                            else
                                continue;
                        }
                        sw.WriteLine(tempstr);
                    }
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("匯出EXCEL成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static string Get_Rmb_Remark(string ls_formula)
        {
            string ls_rmb_remark="";
            if (string.IsNullOrEmpty(ls_formula))
                ls_rmb_remark = "";
            else
            {
                System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(string.Format("select rmb1,rmb2 from quotation_formula where brand_id='{0}'", ls_formula));
                if (dt.Rows.Count > 0 )
                {
                    if (dt.Rows[0]["rmb1"].ToString() != "0.000")
                        ls_rmb_remark = String.Format("BP×{0}×{1}", dt.Rows[0]["rmb1"], dt.Rows[0]["rmb2"]);
                    else
                        ls_rmb_remark = "";
                }
                dt.Dispose();
            }
            return ls_rmb_remark;
        }

        public static void Set_Unit(DevExpress.XtraEditors.LookUpEdit obj)
        {
            System.Data.DataTable dtUnit = new System.Data.DataTable();
            dtUnit = clsPublicOfCF01.GetDataTable(@"SELECT '' AS id Union SELECT unit_id as id FROM dbo.bs_unit Where unit_id<>'000'");
            obj.Properties.DataSource = dtUnit;
            obj.Properties.ValueMember = "id";
            obj.Properties.DisplayMember = "id";
        }

        public static bool Check_Artwork(string strArtwork)
        {
            bool isExists = false;
            string artwork = string.IsNullOrEmpty(strArtwork) ? "" : strArtwork;
            string strSql = string.Format(@"SELECT '1' FROM {0}cd_pattern with(nolock) WHERE within_code='0000' AND id='{1}'", DBUtility.remote_db, artwork);            
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = clsPublicOfCF01.GetDataTable(strSql);
            isExists = (dt.Rows.Count > 0) ? true : false;
            return isExists;
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
                   Convert.ToSingle(rng.Left) + 5, Convert.ToSingle(rng.Top) + 5, rng.Width - 5, rng.Height - 5);   //插入图片 
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
        }

        public static bool Check_Formula_Batch_Update(string ls_user_id)
        {
            bool lb_result=false ;
            string ls_sql = string.Format("select state from dbo.v_user_popedom where USR_NO='{0}' AND Window_id ='frmQuotation_Formula' AND id='BTNSAVE'", ls_user_id);
            System.Data.DataTable dtState = new System.Data.DataTable();
            dtState = clsPublicOfCF01.GetDataTable(ls_sql);
            if (dtState.Rows.Count > 0)
            {
                if(dtState.Rows[0]["state"].ToString()=="True")
                    lb_result = true;
                else
                    lb_result = false;
            }
            else
            {
                lb_result = false;
            }
            return lb_result;
        }

        public static string GetConString(string _all_path, string _public_path)
        {
            string str_result = "";
            int lenth_all = _all_path.Length;
            int lenth_public = _public_path.Length;
            str_result = _all_path.Substring(lenth_public, lenth_all - lenth_public);
            return str_result;
        }

        /// <summary>
        /// 按用戶自定義的排序次序生成DataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetSortDataTable(DataGridView dgv)
        {
            DataView dv = (dgv.DataSource as System.Data.DataTable).DefaultView;//得到DataView
            if (dgv.SortedColumn != null)//判断是否有排序
            {
                dv.Sort = dgv.SortedColumn.DataPropertyName + (dgv.SortOrder == System.Windows.Forms.SortOrder.Ascending ? " asc" : " desc");//排序
            }
            return dv.ToTable();//返回DataTable
        }

        public static bool CheckPriceUnit(string unit)
        {
            bool flag = true;
            if (string.IsNullOrEmpty(unit))
            {
                MessageBox.Show("單價單位不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
            }
            return flag;
        }

    }

  }

