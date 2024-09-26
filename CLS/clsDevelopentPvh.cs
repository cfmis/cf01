using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsDevelopentPvh
    {
        public static void SetDropBox(DevExpress.XtraEditors.LookUpEdit obj, string strType)
        {
            string strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", strType);
            System.Data.DataTable dtObj = new System.Data.DataTable();
            dtObj = clsPublicOfCF01.GetDataTable(strSql);
            obj.Properties.DataSource = dtObj;
            obj.Properties.ValueMember = "id";
            obj.Properties.DisplayMember = "id";
        }

        public static string GetPvhNo(string strSerial_no,string strContents)
        {
            string strSql = string.Format(
            @"SELECT TOP 1 ISNULL(abbrev_id,'') AS abbrev_id FROM development_pvh_type WHERE type ='divisions' and contents='{0}'", strContents);
            string prefix= clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            string mm = strSerial_no.Substring(4, 2);//月份
            string yy = strSerial_no.Substring(2, 2);//取年份
            //舊代碼取消于2022/08/01
            //strSql = "SELECT MAX(pvh_submit_ref) AS pvh_submit_ref FROM development_pvh WHERE pvh_submit_ref LIKE "+ "'"+ prefix +"CF-" + mm + "%/" + yy + "'";
            //2022/08/01更改新的取編號規則,不同的DEVISON共用相同的遞增序號
            strSql = string.Format(
                @"SELECT MAX(S.pvh_submit_ref) AS pvh_submit_ref 
                  FROM (SELECT Right(pvh_submit_ref,12) AS pvh_submit_ref
	                    FROM development_pvh 
	                    WHERE [date]>='2022-05-10' AND pvh_submit_ref<>'' AND RIGHT(pvh_submit_ref,12) LIKE '%CF-{0}%/{1}'
	                   ) S",mm,yy);            
            string result = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            if (string.IsNullOrEmpty(result))
            {
                result = prefix + "CF-" + mm + "0001" + "/" + yy;
            }
            else
            {
                int index_start = result.IndexOf("-") + 3;
                result = prefix + "CF-" + mm + (int.Parse(result.Substring(index_start, 4)) + 1).ToString().PadLeft(4, '0') + "/" + yy; ; //THSCF-120001/21
            }            
            return result;
        }
        public static string GetPvhNoForUs(string strSerial_no)
        {
            string result = "";
            string mm = strSerial_no.Substring(4, 2);//月份
            string yy = strSerial_no.Substring(2, 2);//取年份
            string prefix = "TH-CF-";
            ////TH-CF-02001/22
            string sql = "SELECT MAX(reference_number) AS reference_number FROM development_us_pvh WHERE reference_number LIKE '" + prefix + mm + "%/" + yy + "'";
            result = clsPublicOfCF01.ExecuteSqlReturnObject(sql);
            if (string.IsNullOrEmpty(result))
            {
                result = prefix + mm + "001" + "/" + yy;
            }
            else
            {
                result = prefix + mm + (Int32.Parse(result.Substring(8, 3)) + 1).ToString().PadLeft(3, '0') + "/" + yy; ;
            }
            return result;
        }

        public static DataTable GetPvhCustomerInfo(string strMo)
        {
            string remote_db = DBUtility.remote_db;
            string strSql = string.Format(
            @"SELECT SUBSTRING(goods_id,4,7) AS artwork,ISNULL(customer_goods,'') AS customer_goods ,
            ISNULL(customer_size,'') AS customer_size,ISNULL(customer_color_name,'') AS customer_color_name
            FROM {0}so_order_details WHERE within_code='0000' AND mo_id='{1}'", remote_db, strMo);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        public static DataTable GetProcessTypeInfo(string strType)
        {
            string strSql = string.Format(@"SELECT contents FROM development_pvh_type WHERE type='{0}' ORDER BY sort", strType);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        public static DataTable GetProcess(string field_type)
        {
            string strSql = string.Format(@"SELECT Convert(bit, 0) AS flagSelect,contents FROM development_pvh_type WHERE type='{0}' ORDER BY sort", field_type);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        public static void SetCountry(DevExpress.XtraEditors.LookUpEdit objMat, DevExpress.XtraEditors.LookUpEdit objL3, DevExpress.XtraEditors.LookUpEdit objL4)
        {
            objL3.EditValue = objMat.GetColumnValue("name1").ToString();
            objL4.EditValue = objMat.GetColumnValue("name2").ToString();

            //    string strMatValue = "";
            //    string strCountry = "";
            //    strMatValue = objMat.EditValue.ToString();
            //    if (!string.IsNullOrEmpty(strMatValue))
            //    {
            //        switch (strMatValue)
            //        {
            //            case "BRASS":
            //                strCountry = "KOREA REPUBLIC OF";
            //                break;
            //            case "ZINC ALLOY":
            //                strCountry = "JAPAN";
            //                break;
            //            case "POLYESTER":
            //                strCountry = "CHINA";
            //                break;
            //            case "POLYAMIDE / NYLON":
            //                strCountry = "CHINA";
            //                break;
            //            case "RECYCLED ZINC ALLOY":
            //                strCountry = "BELGIUM";
            //                break;
            //            default:
            //                strCountry = "";
            //                break;
            //        }
            //        objCountry.EditValue = strCountry;
            //    }
            //}
        }

        public static DataTable Find_Data(string id1,string id2, string pvh_submit_ref1,string pvh_submit_ref2,
            string date1,string date2,string plm_material_code1,string mo_id1,string mo_id2,string mo_id3,string colour1,string size1)
        {
            string sql = @"SELECT * FROM development_pvh with(nolock) WHERE 1=1 ";
            if (id1 != "" || id2 != "" || pvh_submit_ref1 !=""|| pvh_submit_ref2!="" 
                || date1 !="" || date2 != "" || plm_material_code1 != "" || mo_id1!="" || mo_id2 !="" || mo_id3 !="" ||
                colour1!="" || size1!="")
            {
                if (id1 != "")
                {
                    sql += string.Format(" and serial_no>='{0}'", id1);
                }
                if (id2 != "")
                {
                    sql += string.Format(" and serial_no<='{0}'", id2);
                }
                if (pvh_submit_ref1 != "")
                {
                    sql += string.Format(" and pvh_submit_ref>='{0}'", pvh_submit_ref1);
                }
                if (pvh_submit_ref2 != "")
                {
                    sql += string.Format(" and pvh_submit_ref<='{0}'", pvh_submit_ref2);
                }
                if (date1 != "")
                {
                    sql += string.Format(" and date>='{0}'", date1);
                }
                if (date2 != "")
                {
                    sql += string.Format(" and date<='{0}'", date2);
                }
                if (plm_material_code1 != "")
                {
                    sql += string.Format(" and plm_material_code like '%{0}%'", plm_material_code1);
                }                
                if (mo_id1 != "")
                {
                    sql += string.Format(" and mo_id1='{0}'", mo_id1);
                }
                if (mo_id2 != "")
                {
                    sql += string.Format(" and mo_id2='{0}'", mo_id2);
                }
                if (mo_id3 != "")
                {
                    sql += string.Format(" and mo_id3='{0}'", mo_id3);
                }
                if (colour1 != "")
                {
                    sql += string.Format(" and colour like '%{0}%'", colour1);
                }
                if (size1 != "")
                {
                    sql += string.Format(" and size like '%{0}%'", size1);
                }
            }

            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            return dt;
        }

        public static void SetCertificate(DevExpress.XtraEditors.LookUpEdit objCertType, DevExpress.XtraEditors.TextEdit obyNo,
            DevExpress.XtraEditors.TextEdit obyDate, DevExpress.XtraEditors.TextEdit obyHolder)
        {            
            string strVal = objCertType.EditValue.ToString();
            string strSql = string.Format(
            @"SELECT ISNULL(remark,'') AS remark,ISNULL(remark2,'') AS remark2,ISNULL(remark3,'') AS remark3
            FROM development_pvh_type WHERE type='{0}' and contents='{1}' ORDER BY sort", "certificate_type", strVal);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                obyNo.Text = dt.Rows[0]["remark"].ToString();
                obyDate.Text = dt.Rows[0]["remark2"].ToString();
                obyHolder.Text = dt.Rows[0]["remark3"].ToString();
            }           
        }


        /* strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "material_finish"); 
            DataTable dtMatFinish = clsPublicOfCF01.GetDataTable(strSql);
            lueCert1_mat_finish.Properties.DataSource = dtMatFinish;
            lueCert1_mat_finish.Properties.ValueMember = "id";
            lueCert1_mat_finish.Properties.DisplayMember = "id";*/

    }
}
