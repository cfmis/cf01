using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsCombinePart
    {
        private static clsPublicOfGEO clsErp = new clsPublicOfGEO();
        //static string remote_db = DBUtility.remote_db;
        public clsCombinePart()
        {
        }

        public static string GetMaxID(string year_month)
        {
            string result = string.Empty, bill_code = string.Empty;
            string strSql = string.Format(@"Select pkey,bill_code From sys_bill_max_separate WHERE within_code='0000' AND bill_id='ST11' AND year_month='{1}'", year_month);
            DataTable dtBillMax = clsErp.GetDataTable(strSql);
            if (dtBillMax.Rows.Count > 0)
            {
                bill_code = "DAD" + year_month + (int.Parse(dtBillMax.Rows[0]["bill_code"].ToString().Trim().Substring(6, 4)) + 1).ToString().PadLeft(4, '0'); //AD26100008
                int p_key = int.Parse(dtBillMax.Rows[0]["pkey"].ToString());
                strSql = string.Format(@"Update sys_bill_max_separate With(rowlock) SET bill_code='{0}' WHERE pkey={1}", bill_code, p_key);
                if (clsErp.ExecuteSqlUpdate(strSql) < 0)
                {
                    result = "-1";
                }
                else
                {
                    result = bill_code;
                }
            }
            else
            {
                bill_code = "DAD" + year_month + "0001";
                strSql = string.Format(
                @"INSERT INTO sys_bill_max_separate(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) Values
                ('0000', 'ST11', '{0}', '{1}', '', '', '', '', '')", year_month, bill_code);
                if (clsErp.ExecuteSqlUpdate(strSql) < 0)
                {
                    result = "-1";
                }
                else
                {
                    result = bill_code;
                }
            }
            return result;
        }

        ////獲取部門移交單批號
        //public static string GetDeptLotNo(string out_dept, string in_dept)
        //{
        //    string result = "";
        //    string strSql = string.Format(
        //    @" DECLARE @lot_no nvarchar(20) 
        //       EXEC usp_create_lot_no '{0}','{1}','{2}',@lot_no OUTPUT 
        //       SELECT @lot_no AS lot_no",
        //    "0000", out_dept, out_dept);
        //    DataTable dt = clsErp.ExecuteSqlReturnDataTable(strSql);
        //    result = dt.Rows[0]["lot_no"].ToString();
        //    return result;
        //}
    }
}
