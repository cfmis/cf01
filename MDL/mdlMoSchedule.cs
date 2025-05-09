using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlMoSchedule
    {
        public string schedule_id { get; set; }
        public string prd_dep { get; set; }
        public string prd_group { get; set; }
        public string schedule_date { get; set; }
        public string now_date { get; set; }
        public string schedule_seq { get; set; }
        public string prd_mo { get; set; }
        public string prd_item { get; set; }
        public string order_date { get; set; }
        public int order_qty { get; set; }
        public int pl_qty { get; set; }
        public int schedule_qty { get; set; }
        public int need_mon_num { get; set; }
        public int cp_qty { get; set; }
        public string pmc_rq_date { get; set; }
        public string pmc_rp_date { get; set; }
        public string dep_rp_date { get; set; }
        public string prd_machine { get; set; }
        public decimal machine_std_run_num { get; set; }
        public decimal machine_std_line_num { get; set; }
        public decimal machine_std_qty { get; set; }
        public string prd_worker { get; set; }
        public decimal req_module_time { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public decimal req_prd_time { get; set; }
        public decimal req_tot_time { get; set; }
        public string urgent_flag { get; set; }
        public string status { get; set; }
        public string update_flag { get; set; }
        public string next_wp_id { get; set; }
        public string next_goods_id { get; set; }
        public string next_vend_id { get; set; }
        public string module_type { get; set; }
        public string mo_remark { get; set; }
        public string dep_remark { get; set; }
        public string module_no { get; set; }
        public string module_install { get; set; }
    }
    public class mdlMoScheduleBase
    {
        public string prd_dep { get; set; }
        public string schedule_date { get; set; }
        public string start_prd_time { get; set; }
        public decimal noon_break { get; set; }
        public decimal afternoon_break { get; set; }
        public decimal evening_break { get; set; }
        public string work_in1 { get; set; }
        public string work_out1 { get; set; }
        public string work_in2 { get; set; }
        public string work_out2 { get; set; }
        public string work_in3 { get; set; }
        public string work_out3 { get; set; }
        public string break_in3 { get; set; }
        public string break_out3 { get; set; }
        public string break_in4 { get; set; }
        public string break_out4 { get; set; }
    }

}
