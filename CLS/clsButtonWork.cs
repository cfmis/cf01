using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public class clsButtonWork
    {
        public static string GetDocNo(string pDept_id) //取最大單據編號
        {
            string ls_result = "", ls_year_month, ls_year, ls_month, ls_doc, ls_seq, ls_max_seq;
            ls_year_month = clsPublicOfCF01.ExecuteSqlReturnObject("Select Substring(convert(varchar(10),GETDATE(),120),1,7)");
            ls_year = ls_year_month.Substring(0, 4);
            ls_month = ls_year_month.Substring(5, 2);
            ls_doc = String.Format("{0}-{1}{2}-", pDept_id, ls_year, ls_month);

            DataTable dtMaxSeq = new DataTable();
            dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(id) as id FROM dbo.jo_button_work_mostly WHERE id LIKE '{0}%'", ls_doc));
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

        public static bool Valid_Doc(string id) //主建是否已存在
        {
            bool lb_flag;
            string ls_sql = String.Format("Select '1' FROM dbo.jo_button_work_mostly with(nolock) WHERE id='{0}'", id);
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
        /// 返回部門資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDept()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable(@"Select id,name as cdesc From dgerp2.cferp.dbo.cd_department Where id>='102' and id<'999' and state='0'");
            return dt;
        }


        public static DataTable Find_Data_By_id(string pId)
        {
            string ls_sql = string.Format(
                @"SELECT a.id,Convert(varchar(10),a.con_date,120) as con_date,a.department_id,a.remark,
                b.sequence_id,b.group_type,convert(varchar(10),b.work_date,120) as work_date,b.work_time_normal_s,b.work_time_normal_e,b.workers_normal,
                b.work_time_overtime_s,b.work_time_overtime_e,b.workers_overtime,b.running_machines,b.qty_total,b.details_remark
                FROM dbo.jo_button_work_mostly a with(nolock) 
                Inner join dbo.jo_button_work_details b with(nolock) on a.id=b.id
                WHERE a.id='{0}' and a.state='0' Order By a.id,b.sequence_id", pId);
            DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
            return dt;
        }


        public static DataTable Find_Data(string pDept_id1, string pDept_id2, string pDate1, string pDate2, string pId1, string pId2)
        {
           StringBuilder lsb = new StringBuilder(
                @"SELECT a.id,Convert(varchar(10),a.con_date,120) as con_date,a.department_id,a.remark,
                b.sequence_id,b.group_type,convert(varchar(10),b.work_date,120) as work_date,b.work_time_normal_s,b.work_time_normal_e,b.workers_normal,
                b.work_time_overtime_s,b.work_time_overtime_e,b.workers_overtime,b.running_machines,b.qty_total,b.details_remark,c.dep_cdesc as department_name
                FROM dbo.jo_button_work_mostly a with(nolock) 
                Inner join dbo.jo_button_work_details b with(nolock) on a.id=b.id               
                Inner join dbo.bs_dep c on a.department_id=c.dep_id
                WHERE 1=1 ");
           if (pId1 != "")
           {
               lsb.Append(string.Format(@" AND a.id>='{0}'",pId1));
           }
            if (pId2 != "")
           {
               lsb.Append(string.Format(@" AND a.id<='{0}'",pId2));
           }
           if (pDept_id1 != "")
           {
               lsb.Append(string.Format(@" AND a.department_id>='{0}'",pDept_id1));
           }
           if (pDept_id2 != "")
           {
               lsb.Append(string.Format(@" AND a.department_id<='{0}'", pDept_id2));
           }
           if (pDate1 != "")
           {
               lsb.Append(string.Format(@" AND a.con_date>='{0}'", pDate1));
           }
           if (pDate2 != "")
           {
               lsb.Append(string.Format(@" AND a.con_date<='{0}'", pDate2));
           }
           lsb.Append(" and a.state='0' Order By a.id,b.sequence_id");
           DataTable dt = clsPublicOfCF01.GetDataTable(lsb.ToString());
           return dt;
        }

    }
}
