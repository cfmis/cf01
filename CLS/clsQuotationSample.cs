using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsQuotationSample
    {
        public static string cust_artwork_path = @"\\192.168.3.12\cf_artwork\quo_photo";
        public static DataTable GetEmptyStrutre()
        {
            string strsql =
            @"SELECT input_date,seq_id,season,plm_code,artwork_path,cf_code,product_desc,material,size,macys_color_code,mo_id,
            ready_date,cf_color_code,ex_fty_usd,ex_fty_usd_new,price_unit,moq_pcs,surcharge,md_charge,art_approved_by,submission_date,
            sample_approved_date,remark,create_by,create_date,update_by,update_date,id,serial_no,row_flag,'0' as bgcolor
            FROM quotation_sample Order by serial_no Desc,seq_id ";
            DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
            {
                string serial_no = dt.Rows[0]["serial_no"].ToString();
                string bgcolor = dt.Rows[0]["bgcolor"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(serial_no != dt.Rows[i]["serial_no"].ToString())//組改變時
                    {
                        if(bgcolor == "0")
                        {
                            dt.Rows[i]["bgcolor"] = "1";
                            bgcolor = "1";
                        }
                        else
                        {
                            dt.Rows[i]["bgcolor"] = "0";
                        }
                    }
                    else
                    {
                        dt.Rows[i]["bgcolor"] = bgcolor;
                    }
                    serial_no = dt.Rows[i]["serial_no"].ToString();
                }
            }
            dt.AcceptChanges();           
            return dt;
        }
        public static string GetSerialNo()
        {
            string result = "";
            string strsql = @"SELECT dbo.fn_get_str_datetime() as serial_no";
            System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            string str_serial_no = dt.Rows[0]["serial_no"].ToString();
            result = !string.IsNullOrEmpty(str_serial_no) ? str_serial_no : "";            
            return str_serial_no;          
        }
    }
}
