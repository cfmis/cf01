using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsOrderFareCharge
    {
        /// <summary>
        /// 是否存在頁數
        /// </summary>
        /// <returns></returns>
        public static string IsExistsMo(string mo_id)
        {
            string ls_result = "";           
            DataTable dtMo = new DataTable();
            dtMo = clsPublicOfCF01.GetDataTable(string.Format("SELECT mo_id FROM dbo.mo_test_report_charge WHERE mo_id ='{0}'", mo_id));
            if (dtMo.Rows.Count>0)
            {
                ls_result = dtMo.Rows[0]["mo_id"].ToString();                
            }
            else
            {
                ls_result = "";
            }           
            return ls_result;
        }
        public static int UpdateMo(string mo_id,string remark,bool isReport)
        {
            int result = 0;
            string sql_i = @"INSERT INTO mo_test_report_charge(mo_id,remark,create_by,create_date) VALUES(@mo_id,@remark,@user_id,getdate())";
            string sql_u = @"UPDATE mo_test_report_charge SET remark=@remark,create_by=@user_id,create_date=getdate() WHERE mo_id=@mo_id";
            string sql_d = string.Format(@"DELETE FROM mo_test_report_charge WHERE mo_id='{0}'",mo_id);
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@mo_id",mo_id),
                new SqlParameter("@remark",remark),
                new SqlParameter("@user_id", DBUtility._user_id)
            };
            if (IsExistsMo(mo_id) =="")
            {
                if (isReport)
                {
                    result = clsPublicOfCF01.ExecuteNonQuery(sql_i, paras, false);
                }
            }else
            {
                //頁數存在說明已有測試報告
                if (isReport)
                {
                    result = clsPublicOfCF01.ExecuteNonQuery(sql_u, paras, false);
                }else
                {
                    //移除,等于取消某頁數還沒測試報告
                    result = clsPublicOfCF01.ExecuteNonQuery(sql_d, paras, false);
                }
            }
            return result;
        }
    }
}
