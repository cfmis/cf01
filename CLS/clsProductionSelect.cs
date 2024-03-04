using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsProductionSelect
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public static DataTable GetJobType(string dep)
        {
            DataTable dtJobType = new DataTable();
            string strSql = "";
            if(dep.Substring(0,1)=="5")
            {
                strSql = " SELECT dept_id As dep,rtrim(process_id) As job_type,rtrim(process_name) As job_desc,rtrim(remark) As remark" +
                    " FROM jo_dept_product_cost " +
                    " Where dept_id ='501' And quo_flag='Y' " +
                    " order by process_id";
                dtJobType = clsPublicOfCF01.GetDataTable(strSql);
            }
            else
            {
                strSql = " SELECT dep,job_type,job_desc,'' As remark FROM job_type Where dep='" + dep + "' And s_flag is null" +
                " order by job_type";
                dtJobType = clsPublicOfPad.GetDataTable(strSql);
            }
            return dtJobType;
        }
        public static DataTable GetDepGroup(string dep,string groupType)
        {
            DataTable dtJobType = new DataTable();
            string strSql = "";
            strSql = " SELECT work_group,group_desc FROM work_group WHERE ( dep='" + dep + "'" + " AND group_type='" + groupType + "') " + " OR dep='" + "000" + "' ";
            dtJobType = clsPublicOfPad.GetDataTable(strSql);
            return dtJobType;
        }
        public static DataTable GetDefective()
        {
            string strSql = "";
            strSql = " SELECT defective_id,defective_cdesc FROM defective_tb";
            DataTable dtDefective = clsPublicOfPad.GetDataTable(strSql);
            return dtDefective;
        }
        public static DataTable GetLastPrdEndTime(string dep,string depGroup)
        {
            string strsql_part;
            string sql;
            string last_date = System.DateTime.Now.ToString("yyyy/MM/dd");
            strsql_part = " (Select Max(prd_id) AS prd_id " +
                " From product_records with(nolock) Where " +
                " prd_dep= '" + dep + "'"
                + " and prd_date ='" + last_date + "'"
                + " and prd_group='" + depGroup + "'"
                + " and prd_start_time <>'" + "" + "' and prd_end_time <>'" + "" + "'"
                + " ) c ";

            sql = " Select a.*,rtrim(b.work_type_desc) as work_type_desc " +
            " From product_records a " +
            " Left outer join work_type b on a.prd_work_type=b.work_type_id " +
            " Inner Join " + strsql_part + " on a.prd_id=c.prd_id";
            DataTable dtLastTime = clsPublicOfPad.GetDataTable(sql);
            return dtLastTime;
        }

        public static string GetPrdWorker(string wid)
        {
            string hrm1name = "";
            string sql = " Select a.hrm1wid,a.hrm1name " +
                    " From dgsql1.dghr.dbo.hrm01 a " +
                    " Where a.hrm1wid = " + "'" + wid + "'";
            DataTable dtWid = clsPublicOfPad.GetDataTable(sql);
            if (dtWid.Rows.Count > 0)
                hrm1name = dtWid.Rows[0]["hrm1name"].ToString();
            return hrm1name;
        }

        public static DataTable GetTotalPrdQty(string dep,string mo_id,string goods_id)
        {
            string sql = " Select sum(prd_qty) as prd_qty From product_records a with(nolock)" +
                " Where a.prd_dep = " + "'" + dep + "'" +
                " And a.prd_mo = " + "'" + mo_id + "'" +
                " And a.prd_item = " + "'" + goods_id + "'" +
                " And a.prd_work_type = '" + "A03" + "'" +
                " And a.prd_start_time <> '' " + " And a.prd_end_time <> '' ";
            DataTable dtShowQty = clsPublicOfPad.GetDataTable(sql);
            return dtShowQty;
        }

        public static DataTable GetKgPcsRate(string dep, string goods_id)
        {
            string sql = " select dep,mat_item,rate,cr_date  from item_rate ";
            sql += " Where dep = " + "'" + dep + "'";
            sql += " And mat_item = " + "'" + goods_id + "'";
            DataTable dtKgPcsRate = clsPublicOfPad.GetDataTable(sql);
            return dtKgPcsRate;
        }

        public static DataTable GetPrdWorkerDetails(string prd_id)
        {
            string sql = "";
            sql += " Select a.prd_worker,b.hrm1name " +
                " From product_records_worker a with(nolock) " +
                " Left Join dgsql1.dghr.dbo.hrm01 b on a.prd_worker=b.hrm1wid  COLLATE Chinese_PRC_CI_AS" +
                " Where a.prd_id = " + "'" + (prd_id != "" ? Convert.ToInt32(prd_id) : 0) + "'";
            DataTable dtWorker = clsPublicOfPad.GetDataTable(sql);
            return dtWorker;
        }
    }
}
