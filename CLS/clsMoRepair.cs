using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public class clsMoRepair
    {
        /// <summary>
        /// 返回部門資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDept()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"Select '107' as id,'鈕--噴油' as cdesc union Select id,name as cdesc From dgerp2.cferp.dbo.cd_department Where id>='500' and id<'599' and state='0'");
            return dt;
        }

        /// <summary>
        /// 返回供應商資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVendor()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"Select id,id+'--'+name as cdesc From dgerp2.cferp.dbo.it_vendor Where Isnull(Abbrev_id,'')<>'' and state='1' order by id");
            return dt;
        }

        /// <summary>
        /// 返回補料原因
        /// </summary>
        /// <returns></returns>
        public static DataTable GetReasonRepair()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(
            @"select a.typ_code as id,a.typ_cdesc as cdesc from bs_type a,bs_type_group b where a.typ_group=b.gtyp_code and a.typ_group='ZA' order by a.typ_code");
            return dt;
        }

        public static string GetDocNo(string pVendor_id) //取最大單據編號
        {
            string ls_result = "", ls_year_month, ls_year,ls_month,ls_doc,ls_seq,ls_max_seq;
            ls_year_month = clsPublicOfCF01.ExecuteSqlReturnObject("Select substring(convert(varchar(10),GETDATE(),120),1,7)");
            ls_year = ls_year_month.Substring(0, 4);
            ls_month = ls_year_month.Substring(5, 2);
            ls_doc = String.Format("{0}-{1}{2}-", pVendor_id.Substring(3,5), ls_year,ls_month);
            
            DataTable dtMaxSeq = new DataTable();
            dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(id) as id FROM dbo.jo_pp_repair_mostly WHERE id LIKE '{0}%'", ls_doc));
            if (String.IsNullOrEmpty(dtMaxSeq.Rows[0]["id"].ToString()))
            {
                ls_seq = "001";
            }
            else
            {
                ls_max_seq = dtMaxSeq.Rows[0]["id"].ToString();
                ls_seq = ls_max_seq.Substring(ls_max_seq.Length - 3);
                ls_seq = (Convert.ToInt32(ls_seq) + 1).ToString("000");
            }
            ls_max_seq = ls_doc + ls_seq;
            ls_result = ls_max_seq;
            return ls_result;
        }

        /// <summary>
        /// 返回明細數據
        /// </summary>
        /// <param name="pDept_id1"></param>
        /// <param name="pDept_id2"></param>
        /// <param name="pVendor_id1"></param>
        /// <param name="pVendor_id2"></param>
        /// <param name="pDate1"></param>
        /// <param name="pDate2"></param>
        /// <param name="pMo_id1"></param>
        /// <param name="pMo_id2"></param>
        /// <param name="pId1"></param>
        /// <param name="pId2"></param>
        /// <param name="pIs_deduct_amount"></param>
        /// <returns></returns>
        public static DataTable Find_Data( string pDept_id1,string pDept_id2,string pVendor_id1,string pVendor_id2,
            string pDate1, string pDate2, string pMo_id1, string pMo_id2, string pId1, string pId2, int pIs_deduct_amount,int pIs_ac_deduct)
        {
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@dept_id1",pDept_id1),new SqlParameter("@dept_id2",pDept_id2),
                new SqlParameter("@vendor_id1",pVendor_id1),new SqlParameter("@vendor_id2",pVendor_id2),
                new SqlParameter("@date1",pDate1),new SqlParameter("@date2",pDate2),
                new SqlParameter("@mo_id1",pMo_id1),new SqlParameter("@mo_id2",pMo_id2),
                new SqlParameter("@id1",pId1),new SqlParameter("@id2",pId2),
                new SqlParameter("@is_deduct_amount",pIs_deduct_amount),
                new SqlParameter("@is_ac_deduct",pIs_ac_deduct)
           };
            DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_production_repair", paras);
            return dt;
        }

        public static DataTable Find_Data_By_Mo(string pId)
        {
           string ls_sql= string.Format(
                @"SELECT a.id,convert(varchar(10),a.order_date,120) as order_date,a.department_id,a.lister_by,b.sequence_id,b.mo_id,b.goods_id,
                c.name as goods_name,b.reason_repair,b.qty,b.reason_repair,b.details_remark,b.mo_id+b.sequence_id as mo_id_seq_id,d.dep_cdesc
                FROM dbo.jo_pp_repair_mostly a with(nolock) 
                Inner join dbo.jo_pp_repair_details b with(nolock) on a.id=b.id
                Inner join dbo.geo_it_goods c with(nolock) on b.goods_id=c.id
                Inner join dbo.bs_dep d on a.department_id=d.dep_id
                WHERE a.id='{0}' and a.state='0' Order By a.id,b.sequence_id", pId);           
            
            DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
            return dt;
        }

        public static bool Valid_Doc(string id) //主建是否已存在
        {
            bool lb_flag;
            string ls_sql = String.Format("Select '1' FROM dbo.jo_pp_repair_mostly with(nolock) WHERE id='{0}'", id);
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
    }
}
