using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using cf01.MDL;


namespace cf01.CLS
{
    public static class clsOcImport
    {
        private static string within_code = DBUtility.within_code;
        private static string userid = DBUtility._user_id;
        private static string remote_db = DBUtility.remote_db;
        public static DataTable GetOcData()
        {
            string strSql = "";
            string within_code = DBUtility.within_code;
            strSql += " Select *" +
                " From so_oc_import a " +
                " Where a.id=0";
            DataTable dtMo = clsPublicOfCF01.GetDataTable(strSql);
            return dtMo;
        }
        public static string Save(DataTable dtOc)
        {
            int Result = 0;
            string strSql = "";
            string user_id = DBUtility._user_id;//
            string create_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string doc_id = "FD-"+create_time.Substring(0, 4) + create_time.Substring(5, 2) + create_time.Substring(8, 2)
                + create_time.Substring(11, 2) + create_time.Substring(14, 2) + create_time.Substring(17, 2);
            for (int i = 0; i < dtOc.Rows.Count; i++)
            {
                DataRow drOc = dtOc.Rows[i];
                strSql = @"insert into so_oc_import (cust_code,cs_order,item_code, item_name,color,season
                ,m_s,buyer,cancel,unit_price,curr,qty,unit,amt,product_date,po,po_batch,po_date
                ,ship_to,delivery,color_confirm,rm_no,revise_date,remarks,season1,division,order_purpose
                ,size_name,table_head,brand_id,season_id,mo_type,mo_dep,mo_group
                ,oc_type,order_date,hk_req_date,state,import_flag,doc_id,create_user,create_time)
                Values(@cust_code,@cs_order,@item_code, @item_name,@color,@season
                ,@m_s,@buyer,@cancel,@unit_price,@curr,@qty,@unit,@amt,@product_date,@po,@po_batch,@po_date
                ,@ship_to,@delivery,@color_confirm,@rm_no,@revise_date,@remarks,@season1,@division,@order_purpose
                ,@size_name,@table_head,@brand_id,@season_id,@mo_type,@mo_dep,@mo_group
                ,@oc_type,@order_date,@hk_req_date,@state,@import_flag,@doc_id,@create_user,@create_time)";
                SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@cust_code",drOc["cust_code"].ToString().Trim()),
                        new SqlParameter("@cs_order",drOc["cs_order"].ToString().Trim()),
                        new SqlParameter("@item_code",drOc["item_code"].ToString().Trim()),
                        new SqlParameter("@item_name",drOc["item_name"].ToString().Trim()),
                        new SqlParameter("@color",drOc["color"].ToString().Trim()),
                        new SqlParameter("@season",drOc["season"].ToString().Trim()),

                        new SqlParameter("@m_s",drOc["m_s"].ToString().Trim()),
                        new SqlParameter("@buyer",drOc["buyer"].ToString().Trim()),
                        new SqlParameter("@cancel",drOc["cancel"].ToString().Trim()),
                        new SqlParameter("@unit_price",drOc["unit_price"]),
                        new SqlParameter("@curr",drOc["curr"].ToString().Trim()),
                        new SqlParameter("@qty",drOc["qty"]),
                        new SqlParameter("@unit",drOc["unit"].ToString().Trim()),
                        new SqlParameter("@amt",drOc["amt"]),
                        new SqlParameter("@product_date",drOc["product_date"].ToString().Trim()),
                        new SqlParameter("@po",drOc["po"].ToString().Trim()),
                        new SqlParameter("@po_batch",drOc["po_batch"].ToString().Trim()),
                        new SqlParameter("@po_date",drOc["po_date"].ToString().Trim()),

                        new SqlParameter("@ship_to",drOc["ship_to"].ToString().Trim()),
                        new SqlParameter("@delivery",drOc["delivery"].ToString().Trim()),
                        new SqlParameter("@color_confirm",drOc["color_confirm"].ToString().Trim()),
                        new SqlParameter("@rm_no",drOc["rm_no"].ToString().Trim()),
                        new SqlParameter("@revise_date",drOc["revise_date"].ToString().Trim()),
                        new SqlParameter("@remarks",drOc["remarks"].ToString().Trim()),
                        new SqlParameter("@season1",drOc["season1"].ToString().Trim()),
                        new SqlParameter("@division",drOc["division"].ToString().Trim()),
                        new SqlParameter("@order_purpose",drOc["order_purpose"].ToString().Trim()),

                        new SqlParameter("@size_name",drOc["size_name"].ToString().Trim()),
                        new SqlParameter("@table_head",drOc["table_head"].ToString().Trim()),
                        new SqlParameter("@brand_id",drOc["brand_id"].ToString().Trim()),
                        new SqlParameter("@season_id",drOc["season_id"].ToString().Trim()),
                        new SqlParameter("@mo_type",drOc["mo_type"].ToString().Trim()),
                        new SqlParameter("@mo_dep",drOc["mo_dep"].ToString().Trim()),
                        new SqlParameter("@mo_group",drOc["mo_group"].ToString().Trim()),

                        new SqlParameter("@oc_type",drOc["oc_type"].ToString().Trim()),
                        new SqlParameter("@order_date",drOc["order_date"].ToString().Trim()),
                        new SqlParameter("@hk_req_date",drOc["hk_req_date"].ToString().Trim()),
                        new SqlParameter("@state","0"),
                        new SqlParameter("@import_flag","0"),
                        new SqlParameter("@doc_id",doc_id),
                        new SqlParameter("@create_user",user_id),
                        new SqlParameter("@create_time",create_time)
                    };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            }
            return doc_id;
        }

    }
}
