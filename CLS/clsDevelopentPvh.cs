using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsDevelopentPvh
    {
        public static void SetDropBox(DevExpress.XtraEditors.LookUpEdit obj,string strType)
        {
            string strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", strType);
            //switch (strType)
            //{
            //    case "divisions":
                   
            //        break;
                
            //}
            System.Data.DataTable dtObj = new System.Data.DataTable();
            dtObj = clsPublicOfCF01.GetDataTable(strSql);
            obj.Properties.DataSource = dtObj;
            obj.Properties.ValueMember = "id";
            obj.Properties.DisplayMember = "id";
        }

        public static string GetPvhNo(string strSerial_no)
        {
            string result = "";
            string mm = strSerial_no.Substring(4, 2);//月份
            string yy = strSerial_no.Substring(2, 2);//取年份
            string sql = "SELECT MAX(pvh_submit_ref) AS pvh_submit_ref FROM development_pvh WHERE pvh_submit_ref LIKE 'CF-" + mm + "-%/" + yy+"'";
            result = clsPublicOfCF01.ExecuteSqlReturnObject(sql);
            if (string.IsNullOrEmpty(result))
            {
                result = "CF-" + mm + "-" + "001" + "/" + yy;
            }
            else
            {
                result = "CF-" + mm + "-" + (Int32.Parse(result.Substring(6, 3)) + 1).ToString().PadLeft(3, '0') + "/" + yy; ; //CF-12-001/21
            }
            return result;
        }
    }
}
