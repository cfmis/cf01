using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsSameColorControl
    {
        public static DataTable LoadAllData()
        {
            string sql_f =string.Format(
            @"SELECT a.serial_no,a.seq_id,a.mo_id,a.goods_id,b.name As goods_name,a.sales_group,a.flag_pass,a.flag_color,a.remark,
            a.update_by,a.update_date,a.id,a.input_date,a.row_flag,'0' As bgcolor
            FROM {0}so_order_same_color a with(nolock),{0}it_goods b 
            WHERE '0000'=b.within_code And a.goods_id=b.id 
            Order By serial_no,seq_id", DBUtility.remote_db);
            DataTable dtDetail = clsPublicOfCF01.GetDataTable(sql_f);
            return dtDetail;
        }

        public static DataTable GetFindData(string dat1,string dat2,string moId1,string moId2,string goodsId,string group)
        {
           
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@input_date1",dat1),
                new SqlParameter("@input_date2",dat2),
                new SqlParameter("@mo_id1",moId1),
                new SqlParameter("@mo_id2",moId2),
                new SqlParameter("@goods_id",goodsId),
                new SqlParameter("@sales_group",group)
            };
            DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("p_find_same_color", paras);
            return dt;
        }

        public static string Delete(int id)
        {
            string result = "";
            string sql_del = string.Format("Delete FROM {0}so_order_same_color WHERE id={1}",DBUtility.remote_db, id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(sql_del);
            return result;
        }
    }
}
