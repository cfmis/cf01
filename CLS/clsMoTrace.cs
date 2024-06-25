using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public static class clsMoTrace
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private static string within_code = DBUtility.within_code;
        private static string remote_db = DBUtility.remote_db;
        public static DataTable GetMoOc(string mo_id)
        {
            string strSql = "";
            strSql = " Select Convert(Varchar(10),a.order_date,111) As order_date,b.mo_id,b.goods_id,Convert(Int,(b.order_qty*c.rate)) As order_qty_pcs" +
                " From so_order_manage a " +
                " Inner Join so_order_details b On a.within_code = b.within_code And a.id = b.id And a.ver = b.ver" +
                " Inner Join it_coding c On b.within_code = c.within_code And b.goods_unit = c.unit_code " +
                " Where b.within_code='" + within_code + "'And b.mo_id='" + mo_id + "' And c.id = '*' ";
            DataTable dtOc = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtOc;
        }
        public static DataTable GetMoPlan(string mo_id)
        {
            string strSql = "";
            strSql = "Select Convert(Varchar(10),a.bill_date,111) As pl_date"+
                ",b.flag,b.sequence_id,a.mo_id,b.goods_id,c.name As goods_cname"+
                ",b.wp_id,d.name As wp_desc,b.next_wp_id,e.name As next_wp_desc" +
                ",Convert(Int,b.prod_qty) As prod_qty,Convert(Int,b.obligate_qty) As obligate_qty"+
                ",Convert(Varchar(10),b.t_complete_date,111) As t_complete_date,Convert(Int,b.c_qty_ok) As c_qty_ok,Convert(decimal(18, 2),b.c_sec_qty_ok) As c_sec_qty_ok" +
                ",b.pre_dept,Convert(Int,b.predept_rechange_qty) AS pre_qty_ok,Convert(decimal(18, 2),b.predept_rechange_sec_qty) AS pre_weg_ok" +
                ",b.vendor_id,f.name As vend_cname"+
                " From jo_bill_mostly a " +
                " Inner Join jo_bill_goods_details b On a.within_code = b.within_code And a.id = b.id And a.ver = b.ver" +
                " Inner Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id"+
                " Left Join cd_department d On b.within_code=d.within_code And b.wp_id=d.id"+
                " Left Join cd_department e On b.within_code=e.within_code And b.wp_id=e.id" +
                " Left Join it_vendor f On b.within_code=f.within_code And b.vendor_id=f.id " +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "'";
            strSql += " Order By b.sequence_id ";
            DataTable dtPlan = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtPlan;
        }


        public static DataTable GetMoOp(string mo_id,string dep_id, string goods_id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@mo_id", mo_id)
                ,new SqlParameter("@dep_id", dep_id)
                ,new SqlParameter("@goods_id", goods_id)
                };
            DataTable dtOp = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_MoTrace_OutProcess", parameters);
            return dtOp;
        }
        public static DataTable GetMoTr(string mo_id, string dep_id, string goods_id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@mo_id", mo_id)
                ,new SqlParameter("@dep_id", dep_id)
                ,new SqlParameter("@goods_id", goods_id)
                };
            DataTable dtTr = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_MoTrace_Transfer", parameters);
            return dtTr;
        }
    }
}
