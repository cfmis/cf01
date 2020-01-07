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
            string sql = @"SELECT id,id+'['+name+']' AS cdesc FROM cd_productline WHERE type<>'07' AND state='0' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 外發加工供應商
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Plate_Vendor()
        {
            string sql = @"SELECT id,id + '[' + name + ']' as cdesc FROM it_vendor WHERE isnull(Abbrev_id,'')<> '' AND state ='1' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }
        
    }
}
