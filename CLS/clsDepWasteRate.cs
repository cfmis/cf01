using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsDepWasteRate
    {
        private static string userid = DBUtility._user_id.ToUpper();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;

        public static DataTable loadDep()
        {
            string strSql = "Select a.dep_id,a.dep_cdesc" +
                " From bs_dep a" +
                " Order By a.dep_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        public static DataTable loadDepWasteRate()
        {
            string strSql = "Select a.DepId,a.WasteRate,b.dep_cdesc AS DepCdesc" +
                " From bs_DepWasteRate a" +
                " Left Join bs_dep b ON a.DepId=b.dep_id" +
                " Order By a.DepId";
            DataTable dt= clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        public static string updateDepWasteRate(string depId,decimal wasteRate)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (checkDepWasteRate(depId) == true)
                strSql += string.Format(@" Update bs_DepWasteRate Set WasteRate='{0}' Where DepId='{1}'"
                    , wasteRate, depId);
            else
                strSql += string.Format(@" Insert Into bs_DepWasteRate (DepId,WasteRate) Values ('{0}','{1}')"
                    , depId, wasteRate);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        private static bool checkDepWasteRate(string depId)
        {
            bool result = false;
            string strSql = "Select DepId From bs_DepWasteRate Where DepId='" + depId + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = true;
            return result;
        }
    }
}
