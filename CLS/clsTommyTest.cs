using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsTommyTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="primary_name">主鍵字段</param>
        /// <returns></returns>
        public static string GetSeqNo(string table_name, string primary_name)
        {
            //tommy_test_record,serial_no
            string str_yyyymm = clsPublicOfCF01.ExecuteSqlReturnObject("Select Substring(CONVERT(varchar(10),GETDATE(),112),1,6)");

            string strsql = string.Format(@"SELECT MAX({1}) AS seq_max FROM {0} with(nolock) WHERE {1} LIKE '{2}%'", table_name, primary_name, str_yyyymm);
            System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            string strMax = "";
            if (!string.IsNullOrEmpty(dt.Rows[0]["seq_max"].ToString()))
            {
                strMax = dt.Rows[0]["seq_max"].ToString();
                strMax = strMax.Substring(6, 4);
                strMax = str_yyyymm + (Convert.ToInt32(strMax) + 1).ToString("0000");
            }
            else
            {
                strMax = str_yyyymm + "0001";
            }
            return strMax;
        }

        public static int Get_int(string pString)
        {
            int Result;
            if (string.IsNullOrEmpty(pString))
                Result = 0;
            else
                Result = int.Parse(pString);
            return Result;
        }
    }
}
