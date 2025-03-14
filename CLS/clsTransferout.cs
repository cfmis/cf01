using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsTransferout
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();


        //轉出單最大單據號
        public static string GetMaxID(string billId, string billType, string groupNo, int serialLen)
        {
            string result = "";
            string strSql = string.Format("Select dbo.fn_zz_sys_bill_max_separate_out('{0}','{1}','{2}',{3}) as max_id", billId, billType, groupNo, serialLen);
            result = clsConErp.ExecuteSqlReturnObject(strSql);
            return result;
        }

        public static int DelTransferOut(string id)
        {
            int rtn =0;
            string sql_u = string.Format(@"Updage st_transfer_mostly Set state='2' WHERE within_code='0000' And id='{0}'", id);
            rtn = clsConErp.ExecuteSqlUpdate(sql_u);
            return rtn;
        }


        //public static bool Check_Add_Popedom(string window_id)
        //{
        //    bool flag = false;
        //    string strsql = string.Format(@"Select C2_STATE FROM tb_sy_user_popedom WHERE usr_no='{0}' and Window_id='{1}' and C2_ID='BTNNEW'", DBUtility._user_id, window_id);
        //    DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
        //    if (dt.Rows.Count == 0)
        //    {
        //        flag = false;
        //    }
        //    if (dt.Rows[0]["C2_STATE"].ToString() == "True")
        //        flag = true;
        //    else
        //        flag = false;
        //    return flag;
        //}



    }
}
