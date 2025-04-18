using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.CLS
{
    public static class clsMoSchedule
    {
        private static string within_code = DBUtility.within_code;
        private static string userid = DBUtility._user_id;
        private static string remote_db = DBUtility.remote_db;
        //private static clsPublicOfCF01 clsConnCF01 = new clsPublicOfCF01();

        public static string SaveMoSchedule(List<mdlMoSchedule> lsMo)
        {
            string result = "";
            string strSql = "";
            string id = "";
            string create_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            strSql = string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");

            for (int i = 0; i < lsMo.Count; i++)
            {
                string strSql1 = "";
                if (lsMo[i].schedule_id == "")
                {
                    id = lsMo[i].prd_dep + create_time.Substring(0, 4) + create_time.Substring(5, 2) + create_time.Substring(8, 2) + create_time.Substring(11, 2)
                        + create_time.Substring(14, 2) + create_time.Substring(17, 2) + (i + 1).ToString().PadLeft(4, '0');
                    strSql1 = @" Insert Into mo_schedule ( " +
                        "schedule_id,prd_dep,schedule_date,schedule_seq,prd_mo,prd_item" +
                        ",order_date,order_qty,pl_qty,schedule_qty " +
                        ",pmc_rq_date,pmc_rp_date,dep_rp_date,prd_machine" +
                        ",prd_worker,req_module_time,start_time,end_time,urgent_flag,status" +
                        ",update_user,update_time,req_prd_time,req_tot_time" +
                        ",machine_std_run_num,machine_std_line_num,machine_std_qty,need_mon_num" +
                        ",module_type,prd_group,next_wp_id,next_goods_id,next_vend_id" +
                        " ) Values (" +
                        "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'" +
                        ",'{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}'" +
                        ",'{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}'" +
                        ",'{29}','{30}','{31}','{32}'" +
                        ")";
                }
                else
                {
                    id = lsMo[i].schedule_id;
                    strSql1 = @" Update mo_schedule Set " +
                        " prd_dep='{1}',schedule_date='{2}',schedule_seq='{3}',prd_mo='{4}',prd_item='{5}'" +
                        ",order_date='{6}',order_qty='{7}',pl_qty='{8}',schedule_qty='{9}' " +
                        ",pmc_rq_date='{10}',pmc_rp_date='{11}',dep_rp_date='{12}',prd_machine='{13}'" +
                        ",prd_worker='{14}',req_module_time='{15}',start_time='{16}',end_time='{17}',urgent_flag='{18}',status='{19}'" +
                        ",update_user='{20}',update_time='{21}',req_prd_time='{22}',req_tot_time='{23}'" +
                        ",machine_std_run_num='{24}',machine_std_line_num='{25}',machine_std_qty='{26}',need_mon_num='{27}'" +
                        ",module_type='{28}',prd_group='{29}',next_wp_id='{30}',next_goods_id='{31}',next_vend_id='{32}'" +
                        " Where schedule_id='{0}'";
                }
                strSql += string.Format(strSql1
                    , id, lsMo[i].prd_dep, lsMo[i].schedule_date, lsMo[i].schedule_seq, lsMo[i].prd_mo
                    , lsMo[i].prd_item, lsMo[i].order_date, lsMo[i].order_qty, lsMo[i].pl_qty, lsMo[i].schedule_qty
                    , lsMo[i].pmc_rq_date, lsMo[i].pmc_rp_date, lsMo[i].dep_rp_date, lsMo[i].prd_machine, lsMo[i].prd_worker
                    , lsMo[i].req_module_time, lsMo[i].start_time, lsMo[i].end_time, lsMo[i].urgent_flag, lsMo[i].status
                    , userid, create_time, lsMo[i].req_prd_time, lsMo[i].req_tot_time
                    , lsMo[i].machine_std_run_num, lsMo[i].machine_std_line_num, lsMo[i].machine_std_qty, lsMo[i].need_mon_num
                    , lsMo[i].module_type, lsMo[i].prd_group, lsMo[i].next_wp_id, lsMo[i].next_goods_id, lsMo[i].next_vend_id
                    );
            }

            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        //將制單按機器排期
        public static string SaveScheduleMachine(List<mdlMoSchedule> lsMo)
        {
            string result = "";
            string strSql = "";
            string create_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            strSql = string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");

            for (int i = 0; i < lsMo.Count; i++)
            {
                strSql += string.Format(@" Update mo_schedule Set " +
                    " prd_machine='{1}',schedule_seq='{2}',update_user='{3}',update_time='{4}'" +
                    " Where schedule_id='{0}'"
                    , lsMo[i].schedule_id, lsMo[i].prd_machine, lsMo[i].schedule_seq, userid, create_time
                    );
            }

            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        //////設置制單狀態
        public static string SaveSetMoStatus(List<mdlMoSchedule> lsMo)
        {
            string result = "";
            string strSql = "";
            string create_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            strSql = string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");

            for (int i = 0; i < lsMo.Count; i++)
            {
                strSql += string.Format(@" Update mo_schedule Set " +
                    " status='{1}',update_user='{2}',update_time='{3}'" +
                    " Where schedule_id='{0}'"
                    , lsMo[i].schedule_id, lsMo[i].status, userid, create_time
                    );
            }

            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        public static DataTable LoadMoSchedule(string prd_dep,string prd_group,string prd_machine
            ,int sch_by_machine,string mo_status, string user_id)
        {
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@prd_dep",prd_dep)
                        ,new SqlParameter("@prd_group",prd_group)
                        ,new SqlParameter("@prd_machine",prd_machine)
                        ,new SqlParameter("@sch_by_machine",sch_by_machine)
                        ,new SqlParameter("@mo_status",mo_status)
                        ,new SqlParameter("@user_id",user_id)};
            DataTable dtScheduler = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_mo_schedule", paras);
            dtScheduler.Columns.Add("ArtWork", typeof(Image)); // 图片列
            for (int i=0;i<dtScheduler.Rows.Count;i++)
            {
                if (dtScheduler.Rows[i]["art_image"].ToString() != "")
                    dtScheduler.Rows[i]["ArtWork"] = Image.FromFile(DBUtility.imagePath + dtScheduler.Rows[i]["art_image"]);
            }
            return dtScheduler;
        }
        public static string SaveScheduleBase(mdlMoScheduleBase objBase)
        {
            string strSql = "",strSql1="";
            if (LoadScheduleBase(objBase.prd_dep).Rows.Count == 0)
                strSql1 = @" Insert Into mo_schedule_base ("+
                "prd_dep,schedule_date,start_prd_time,noon_break,afternoon_break,evening_break"+
                ",work_in1,work_out1,work_in2,work_out2,work_in3,work_out4" +
                ",break_in3,break_out3,break_in4,break_out4"+
                " ) " +
                " Values ( "+
                " '{0}','{1}','{2}','{3}','{4}','{5}',{6}',{7}',{8}',{9}'" +
                ",'{10}','{11}','{12}','{13}','{14}','{15}'"+
                " ) ";
            else
                strSql1 = @" Update mo_schedule_base Set start_prd_time='{2}',noon_break='{3}',afternoon_break='{4}',evening_break='{5}' " +
                    ",work_in1='{6}',work_out1='{7}',work_in2='{8}',work_out2='{9}',work_in3='{10}',work_out3='{11}'" +
                    ",break_in3='{12}',break_out3='{13}',break_in4='{14}',break_out4='{15}'"+
                    " Where prd_dep='{0}' And schedule_date='{1}' ";
            strSql += string.Format(strSql1
                    , objBase.prd_dep, objBase.schedule_date, objBase.start_prd_time, objBase.noon_break, objBase.afternoon_break, objBase.evening_break
                    , objBase.work_in1, objBase.work_out1, objBase.work_in2, objBase.work_out2, objBase.work_in3, objBase.work_out3
                    , objBase.break_in3, objBase.break_out3, objBase.break_in4, objBase.break_out4
                    );
            string result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static DataTable LoadScheduleBase(string prd_dep)
        {
            string strSql = "";
            strSql += " Select prd_dep,schedule_date,work_in1,work_out1,work_in2,work_out2,work_in3,work_out3" +
                ",break_in3,break_out3,break_in4,break_out4" +
                ",start_prd_time,noon_break,afternoon_break,evening_break" +
                " From mo_schedule_base " +
                " Where prd_dep='" + prd_dep + "' And schedule_date='" + "2025" + "'";
            DataTable dtBase = clsPublicOfCF01.GetDataTable(strSql);
            return dtBase;
        }
        //public static DataTable GetPrdDetails(string prd_dep,string prd_item)
        //{
        //    string strSql = " Select dep_id,goods_id,prd_group,prd_machine,hour_std_qty" +
        //        " From bs_dep_goods_group" +
        //        " Where dep_id='" + prd_dep + "' And goods_id='" + prd_item + "'";
        //    DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);
        //    return dtPrd;
        //}
        public static int GetScheduleSeq(string prd_dep)
        {
            int result = 600;
            string strSql = "Select Top 1 schedule_seq" +
                " From mo_schedule Where prd_dep='" + prd_dep + "' And status='01'";
            DataTable dtSeq= clsPublicOfCF01.GetDataTable(strSql);
            if (dtSeq.Rows.Count == 0)
                result = 1;
            return result;
        }
    }
}
