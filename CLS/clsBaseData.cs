using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsBaseData
    {
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        
        /// <summary>
        /// 部門資料
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Department()
        {
            string sql = @"SELECT id,id+'['+name+']' AS cdesc FROM cd_productline WHERE within_code='0000' and type<>'07' AND state='0' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 外發加工供應商
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Plate_Vendor()
        {
            string sql = @"SELECT id,id + '[' + name + ']' as cdesc FROM within_code='0000' and it_vendor WHERE isnull(Abbrev_id,'')<> '' AND state ='1' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }

        public static DataTable loadDep()
        {
            string strSql = "Select a.dep_id,a.dep_cdesc" +
                " From bs_dep a" +
                " Order By a.dep_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
    }
}
