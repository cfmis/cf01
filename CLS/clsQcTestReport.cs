using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cf01.CLS
{
    public class clsQcTestReport
    {
        /// <summary>
        /// 取最大單據編號
        /// </summary>
        /// <returns></returns>
        public static string GetDocNo()
        {
            string ls_result = "", ls_year_month, ls_year, ls_month, ls_doc, ls_seq, ls_max_seq;
            ls_year_month = clsPublicOfCF01.ExecuteSqlReturnObject("Select Substring(convert(varchar(10),GETDATE(),120),1,7)");
            ls_year = ls_year_month.Substring(0, 4);
            ls_month = ls_year_month.Substring(5, 2);
            ls_doc = String.Format("{0}{1}{2}", "QA", ls_year, ls_month);

            DataTable dtMaxSeq = new DataTable();
            dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(id) as id FROM dbo.qc_test_mostly WHERE id LIKE '{0}%'", ls_doc));
            if (String.IsNullOrEmpty(dtMaxSeq.Rows[0]["id"].ToString()))
            {
                ls_seq = "0001";
            }
            else
            {
                ls_max_seq = dtMaxSeq.Rows[0]["id"].ToString();
                ls_seq = ls_max_seq.Substring(ls_max_seq.Length - 4);
                ls_seq = (Convert.ToInt32(ls_seq) + 1).ToString("0000");
            }
            ls_max_seq = ls_doc + ls_seq;
            ls_result = ls_max_seq;
            return ls_result;
        }
        
        /// <summary>
        /// 返回測試產品項目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProduct_Item_No()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT typ_code as id,typ_cdesc as cdesc FROM dbo.bs_type WHERE typ_group ='ZB' order by typ_code");
            return dt;
        }
        /// <summary>
        /// 返回測試項目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTest_Item_No()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT typ_code as id,typ_cdesc as cdesc FROM dbo.bs_type WHERE typ_group ='ZC' order by typ_code");
            return dt;
        }

        //查詢按鈕
        public static DataTable Find_Data(string pmo_id1, string pDate1, string pDate2, string pId1, string pId2)
        {
            StringBuilder lsb = new StringBuilder(
            @"SELECT a.id,Convert(varchar(10),a.con_date,120) as con_date,a.customer_id,a.customer_name,a.contact,a.remark,
            b.sequence_id,b.item_no,b.contents,b.details_remark
            FROM dbo.qc_test_mostly a with(nolock) 
            Inner join dbo.qc_test_details b with(nolock) on a.id=b.id 
            WHERE 1=1 ");
            //,c.test_item_id,c.test_require,c.test_result,c.test_is_pass,c.details_remark2
            // Left join dbo.qc_test_details_result c with(nolock) on a.id=c.id
            if (pId1 != "")
            {
                lsb.Append(string.Format(@" AND a.id>='{0}'", pId1));
            }
            if (pId2 != "")
            {
                lsb.Append(string.Format(@" AND a.id<='{0}'", pId2));
            }
            if (pDate1 != "")
            {
                lsb.Append(string.Format(@" AND a.con_date>='{0}'", pDate1));
            }
            if (pDate2 != "")
            {
                lsb.Append(string.Format(@" AND a.con_date<='{0}'", pDate2));
            }
            if (pmo_id1 != "")
            {
                lsb.Append(string.Format(@" AND b.contents like '%{0}%'", pmo_id1));
            }                       
            lsb.Append(" AND a.state='0' Order By a.id,b.sequence_id");
            DataTable dt = clsPublicOfCF01.GetDataTable(lsb.ToString());
            return dt;
        }

        public static bool Valid_Doc(string id) //主建是否已存在
        {
            bool lb_flag;
            string ls_sql = String.Format("Select '1' FROM dbo.qc_test_mostly with(nolock) WHERE id='{0}'", id);
            DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
            if (dt.Rows.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("單據編號" + String.Format("【{0}】已存在！", id), "提示信息");
                lb_flag = true;
            }
            else
            {
                lb_flag = false;
            }
            dt.Dispose();
            return lb_flag;
        }

        /// <summary>
        /// 返回測試產品項目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProduct_Item_Select()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT Cast(0 as bit) AS flag_select,typ_code as id,typ_cdesc as item_no FROM dbo.bs_type WHERE typ_group ='ZB' order by typ_code");
            return dt;
        }

        /// <summary>
        /// 返回測試項目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTest_Item_Select()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT Cast(0 as bit) AS flag_select,typ_code as id,typ_cdesc as item_no FROM dbo.bs_type WHERE typ_group ='ZC' order by typ_code");
            return dt;
        }

        public static DataSet GetReportData(string id)
        {
            string ls_sql = string.Format("Select id,customer_id,customer_name,contact,convert(varchar(10),con_date,120) as con_date,remark FROM dbo.qc_test_mostly with(nolock) WHERE id='{0}' ", id);
            ls_sql += string.Format("Select * FROM dbo.qc_test_details with(nolock) WHERE id='{0}' order by sequence_id ", id);
            ls_sql += string.Format("Select * FROM dbo.qc_test_details_result with(nolock) WHERE id='{0}' order by sequence_id", id);                
            DataSet dts = clsPublicOfCF01.ExcuteSqlReturnDataSet(ls_sql,"");
            return dts;
        }
    }
}
