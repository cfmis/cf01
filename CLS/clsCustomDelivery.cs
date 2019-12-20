using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cf01.CLS
{
   
    public class clsCustomDelivery
    {
        //private static string within_code = DBUtility.within_code;
        //private static string userid = DBUtility._user_id;
        //private static string remote_db = DBUtility.remote_db;
        private static clsPublicOfGEO clsConnGeo = new clsPublicOfGEO();

        public static DataTable Get_Vat_DeliveryBill(string id, string mo_id)
        {
            string strSql =
            @"Select Convert(bit,0) as is_select,A.id,Convert(varchar(10),A.issues_date,120) as issues_date,B.sequence_id,B.mo_id,B.goods_id,B.goods_name,
            CONVERT(int,B.issues_qty) as issues_qty,B.issues_unit,CONVERT(decimal(28,2),B.sec_qty) as sec_qty,B.sec_unit,B.remark,B.order_id
            From so_issues_mostly A with(nolock),so_issues_details B with(nolock)
            WHERE A.within_code=B.within_code and A.id=B.id and A.state not in ('2','V','0') AND A.within_code ='0000'";
            if (!string.IsNullOrEmpty(id))
                strSql += " and A.id='" + id + "'";
            strSql += " and (A.type ='VDI' OR A.type='VDJ')";
            if (!string.IsNullOrEmpty(mo_id))
                strSql += " and B.mo_id='" + mo_id + "'";       
            DataTable dtVat = clsConnGeo.GetDataTable(strSql);
            return dtVat;
        }
    }
}
