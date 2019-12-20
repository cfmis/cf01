using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    /// <summary>
    /// 產品QC記錄
    /// </summary>
    public class product_qc_records
    {
        public int id;
        public string seq_no;
        public string seq_id;
        public string dep_no;
        public string prd_date;
        public string mo_no;
        public string mat_item;
        public string mat_color;
        public int lot_qty;
        public int facade_actual_qty;
        public int size_actual_qty;
        public string actual_size;
        public string mat_logo;
        public string oth_desc;
        public int no_pass_qty;
        public string check_result;
        public string do_result;
        public string do_sample;
        public string crusr;
        public string qc_date;
        public string qc_no_ok;
        public string qc_ok;
        public string mo_source;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
    }

    /// <summary>
    ///產品報告 
    /// </summary>
    public class product_records
    {
        public int prd_id;
        public string prd_dep;
        public string prd_date;
        public string prd_mo;
        public string prd_item;
        public int prd_qty;
        public float prd_weg;
        public string prd_machine;
        public string machine_desc;
        public string prd_work_type;
        public string work_type_decs;
        public string prd_worker;
        public string prd_class;
        public string prd_group;
        public string prd_start_time;
        public string prd_end_time;
        public string prd_req_time;
        public float prd_normal_time;
        public float prd_ot_time;
        public int line_num;
        public int hour_run_num;
        public int hour_std_qty;
        public int per_hour_std_qty;
        public int kg_pcs;
        public string qc_flag;
        public string mat_item;
        public string mat_item_desc;
        public string mat_item_lot;
        public float actual_qty;
        public decimal actual_weg;
        public int actual_pack_num;
        public string conf_flag;
        public DateTime conf_time;
        public string imput_flag;
        public string transfer_flag;
        public DateTime transfer_time;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
        public int temp_qty;
        public int pageIndex;
        public string difficulty_level;
        public string to_dep;
        public float prd_run_qty;
        public int speed_lever;
        public string work_code;
        public int pack_num;
        public int start_run;
        public int end_run;
        public int ok_qty;
        public decimal ok_weg;
        public int no_ok_qty;
        public decimal no_ok_weg;
        public int sample_no;
        public decimal sample_weg;
        public int member_no;
        public int prd_id_ref;
        public string prd_pdate;
        public string job_type;
        public string work_class;
        public string prd_owndep;
    }

    /// <summary>
    /// 並單
    /// </summary>
    public class product_records_dist_mo
    {
        public int prd_id_ref;
        public string prd_mo_sub;
        public string prd_item_sub;
        public string prd_item_desc;
        public int prd_qty_sub;
        public string transfer_flag;
        public DateTime transfer_time;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;

    }

    /// <summary>
    ///生產安排 
    /// </summary>
    public class product_arrange
    {
        public int arrange_id;
        public string prd_dep;
        public string prd_mo;
        public string prd_item;
        public int prd_ver;
        public string to_dep;
        public string prd_seq;
        public string arrange_date;
        public int arrange_seq;
        public int arrange_qty;
        public string estimated_date;
        public string estimated_time;
        public string estimated_start_date;
        public string estimated_start_time;
        public float req_time;
        public string arrange_machine;
        public string prd_group;
        public string rec_status;
        public string mo_urgent;
        public string cust_o_date;
        public string req_f_date;
        public string wf_doc_id;
        public string wf_seq;
        public string prd_worker;
        public string prd_status;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;

    }

}
