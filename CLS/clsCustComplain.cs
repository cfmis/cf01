using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
namespace cf01.CLS
{
    public class clsCustComplain
    {
        /// <summary>
        /// 返回客戶資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCustomerData()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"Select '' as id,'' as cdesc Union Select id,name as cdesc from dgerp2.cferp.dbo.it_customer where state='1' order by id");
            return dt;
        }
        /// <summary>
        /// //返回營業員
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSellerData()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"select S.id,S.name cdesc from (select id,name,isnull(state,'') as state from dgerp2.cferp.dbo.cd_personnel where LEN(id)<7) S where S.state <>'2'");
            return dt;
        }

        /// <summary>
        /// 返回責任部門
        /// </summary>
        /// <returns></returns>
        public static DataTable GetComplainDept()
        {            
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT dept_id as id FROM dbo.so_cust_complain_dept");
            return dt;
        }

        /// <summary>
        /// 返回單位資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUnit()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT '' AS id Union SELECT unit_id as id FROM dbo.bs_unit Where unit_id<>'000'");
            return dt;
        }

        
        /// <summary>
        /// 返回原因分類
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPersonType()
        {
            DataTable dt= clsPublicOfCF01.GetDataTable(
            @"SELECT S.person_type,S.person_type_big FROM 
            (Select '' as person_type,'' as person_type_big ,'' as typ_group,'' as typ_code
            union select b.typ_cdesc,a.gtyp_cdesc,b.typ_group,b.typ_code
            from bs_type_group a,bs_type b 
            where a.gtyp_code=b.typ_group and a.gtyp_code>='PS1' and a.gtyp_code<='PS9') S
            order by S.typ_group,S.typ_code");
            return dt;
        }
        
        public static DataTable findIdDetails(string id1, string id2, string cust_id1, string cust_id2,string date1, string date2, string mo_id1, string mo_id2 )
        {
            SqlParameter[] paras=new SqlParameter[]{
               new SqlParameter("@id1",id1),
               new SqlParameter("@id2",id2),
               new SqlParameter("@cust_id1",cust_id1),
               new SqlParameter("@cust_id2",cust_id2),
               new SqlParameter("@date1",date1),
               new SqlParameter("@date2",date2),
               new SqlParameter("@mo_id1",mo_id1),
               new SqlParameter("@mo_id2",mo_id2)
            };
            DataTable dtIdDetails = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_cust_complain_find", paras);
            return dtIdDetails;
        }

        public static string GetDocNo() //取最大單據編號
        {
            string str_result = "";
            string strYear = clsPublicOfCF01.ExecuteSqlReturnObject("Select substring(convert(varchar(10),GETDATE(),120),1,4)");
            string strDoc = String.Format("CCA{0}", strYear);
            string strSeq;
            string strMaxSeq;
            DataTable dtMaxSeq = new DataTable();
            dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(id) as id FROM dbo.so_cust_complain_mostly WHERE id LIKE '{0}%'", strDoc));
            if (String.IsNullOrEmpty(dtMaxSeq.Rows[0]["id"].ToString()))
            {
                strSeq = "001";
            }
            else
            {
                strMaxSeq = dtMaxSeq.Rows[0]["id"].ToString();
                strSeq = strMaxSeq.Substring(strMaxSeq.Length - 3);
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000");
            }
            strMaxSeq = strDoc + strSeq;
            str_result = strMaxSeq;
            return str_result;            
        }

        public static bool Valid_Doc(string id) //主建是否已存在
        {
            bool flag;            
            string strSql = String.Format("Select '1' FROM dbo.so_cust_complain_mostly with(nolock) WHERE id='{0}'", id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("單據編號" + String.Format("【{0}】已存在！", id), "提示信息");
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }
     
    }
}
