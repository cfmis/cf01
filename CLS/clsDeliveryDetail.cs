using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public static class clsDeliveryDetail
    {
        private static string within_code = DBUtility.within_code;
        private static string userid = DBUtility._user_id;
        //private static string remote_db = DBUtility.remote_db;
        private static string remote_db = "dgerp5.cferp.dbo.";
        private static clsPublicOfGEO clsGeoCon = new clsPublicOfGEO();
        public static string SaveMostly(mdlDeliveryHead objMostly)
        {
            int Result = 0;
            string strSql = "";
            string user_id = DBUtility._user_id;//
            string create_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string doc_id = GenID(objMostly.id_type, objMostly.transfer_date, objMostly.mo_group);
            strSql = "INSERT INTO st_transfer_mostly " +
                " (within_code, id,type,transfer_date,state" +
                ",transfers_state,update_count,create_date,create_by,update_date" +
                ",update_by,origin,bill_type_no,group_no,servername ) " +
                " VALUES " +
                " (@within_code, @id,@type,@transfer_date,@state" +
                ",@transfers_state,@update_count,@create_date,@create_by,@update_date" +
                ",@update_by,@origin,@bill_type_no,@group_no,@servername)";
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@within_code",within_code),
                        new SqlParameter("@id",doc_id),
                        new SqlParameter("@type","0"),
                        new SqlParameter("@transfer_date",objMostly.transfer_date),
                        new SqlParameter("@state","0"),
                        new SqlParameter("@transfers_state","0"),
                        new SqlParameter("@update_count","1"),
                        new SqlParameter("@create_date",create_time),
                        new SqlParameter("@create_by",user_id),
                        new SqlParameter("@update_date",create_time),
                        new SqlParameter("@update_by",user_id),
                        new SqlParameter("@origin","1"),
                        new SqlParameter("@bill_type_no",objMostly.id_type),
                        new SqlParameter("@group_no",objMostly.mo_group),
                        new SqlParameter("@servername","hkserver.cferp.dbo")
                    };
            Result = clsGeoCon.ExecuteNonQuery(strSql, paras, false);
            return doc_id;
        }
        private static string GenID(string id_type,string transfer_date,string mo_group)
        {
            string id = "";
            string year_month = transfer_date.Substring(2, 2) + transfer_date.Substring(5, 2) + transfer_date.Substring(8, 2);
            string bill_id = "ST04";
            string bill_text2 = mo_group == "" ? "0" : mo_group;
            string bill_code = "";//SN0025101506
            int pkey = 0;
            string id_start = id_type + bill_text2 + "0" + year_month;
            string strSql = "";
            strSql = "SELECT pkey,bill_code" +
                " FROM sys_bill_max_separate" +
                " WHERE within_code = '" + within_code + "' AND bill_id = '" + bill_id +
                    "' AND year_month = '" + year_month + "' AND bill_text1 = '" + id_type + "' AND bill_text2='" + bill_text2 + "'";
            DataTable dtBill = clsGeoCon.ExecuteSqlReturnDataTable(strSql);
            if(dtBill.Rows.Count>0)
            {
                pkey = Convert.ToInt32(dtBill.Rows[0]["pkey"]);
                bill_code = dtBill.Rows[0]["bill_code"].ToString();
                int seq = (Convert.ToInt32(bill_code.Substring(10, 2)) + 1);
                id = id_start + (Convert.ToInt32(bill_code.Substring(10, 2)) + 1).ToString().PadLeft(2, '0');
                strSql = " UPDATE sys_bill_max_separate Set bill_code='" + id + "' Where pkey='" + pkey + "'";
            }
            else
            {
                id = id_start + "01";
                strSql = string.Format(@" INSERT INTO sys_bill_max_separate (within_code,bill_code,bill_id,year_month
                    ,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) " +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'" +
                    " )"
                    , within_code, id, bill_id, year_month, id_type, bill_text2, "", "", "");
            }
            clsGeoCon.ExecuteSqlUpdate(strSql);
            return id;
        }
        public static DataTable LoadMostlyData(string ID)
        {
            string strSql = "";
            strSql = " Select id,type,Convert(Varchar(20),transfer_date,111) AS transfer_date,state" +
                ",transfers_state,update_count,Convert(Varchar(20),create_date,120) AS create_date,create_by" +
                ",Convert(Varchar(20),update_date,120) AS update_date,update_by" +
                ",origin,bill_type_no,group_no,Convert(Varchar(20),check_date,120) AS check_date,check_by" +
                " From st_transfer_mostly " +
                " Where within_code='" + within_code + "' And id='" + ID + "'";
            DataTable dtMostly = clsGeoCon.ExecuteSqlReturnDataTable(strSql);
            return dtMostly;
        }
        public static DataTable LoadGoodsData(string mo_id,string goods_id)
        {
            string strSql = "";
            strSql = " Select a.goods_id,b.name AS goods_cname,(a.order_qty*c.rate) AS order_qty" +
                " From so_order_details a " +
                " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id " +
                " Left Join it_coding c On a.within_code=c.within_code And a.goods_unit=c.unit_code " +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "' And a.goods_id='" + goods_id + "' And c.id='*'";
            DataTable dtOc = clsGeoCon.ExecuteSqlReturnDataTable(strSql);
            return dtOc;
        }
        public static DataTable LoadGoodsDetails(string ID)
        {
            string strSql = "";
            strSql = " Select a.id,a.sequence_id,a.mo_id,a.goods_id,b.name AS goods_cname,a.transfer_amount,a.sec_qty" +
                ",a.unit,a.sec_unit,a.package_num,a.position_first,a.nwt,a.gross_wt,a.location_id,a.lot_no" +
                " From st_transfer_detail a " +
                " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id " +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + ID + "'";
            DataTable dtTran = clsGeoCon.ExecuteSqlReturnDataTable(strSql);
            return dtTran;
        }
    }
}
