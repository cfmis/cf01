using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlTransferLoc
    {
        public string id;
        public string con_date;
        public string mo_id;
        public string goods_id;
        public string loc;
        public string t_dep;
        public string lot_no;
        public string obligate_mo_id;
        public string so_no;
        public string so_sequence_id;
        public float qty;
        public float weg;
        public string crusr;
    }

    public class storeissue
    {
        public string id;
        public string con_date;
        public string mo_id;
        public string goods_id;
        public string loc;
        public string t_dep;
        public string lot_no;
        public string obligate_mo_id;
        public string ref_id;
        public string ref_sequence_id;
        public string jo_sequence_id;
        public string line_lot_no;
        public string line_mo_id;
        public int line_qty;
        public double line_weg;
        public int qty;
        public double weg;
        public string order_no;
        public string so_sequence_id;
        public int order_qty;
        public string mrp_id;
        public string remark;
        public string crusr;
    }
    public class takemosample
    {
        public string id;
        public string con_date;
        public string it_customer;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public string loc;
        public string contract_cid;
        public string lot_no;
        public string obligate_mo_id;
        public string customer_goods;
        public string ref_sequence_id;
        public string line_lot_no;
        public string line_mo_id;
        public int line_qty;
        public double line_weg;
        public int qty;
        public double weg;
        public string order_no;
        public string so_sequence_id;
        public int order_qty;
        public string mrp_id;
        public string crusr;
    }
    public class soinvoice_head
    {
        public string id;
        public int ver;
        public string separate;
        public DateTime ship_date;
        public string it_customer;
        public string seller_id;
        public string m_id;
        public string bill_type_no;
        public string phone;
        public string fax;
        public string email;
        public string linkman;
        public string l_phone;
        public double exchange_rate;
        public string po_no;
        public string issues_wh;
        public string merchandiser;
        public string merchandiser_phone;
        public string shipping_methods;
        public string sales_group;
        public string address_id;
    }
    public class soinvoice_details
    {
        public string id;
        public int ver;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public string goods_unit;
        public Decimal u_invoice_qty;
        public Decimal u_invoice_qty_pcs;
        public Decimal sec_qty;
        public string sec_unit;
        public string location_id;
        public string carton_code;
        public string shipment_suit;
        public string remark;
        public int package_num;
        public string box_no;
        public string order_id;
        public int so_ver;
        public string so_sequence_id;
        public string table_head;
        public string customer_goods;
        public string customer_color_id;
        public string contract_cid;
        public string spec;
        public string is_print;
        public string state;
    }

    public class soinvoice_head_geo
    {
        public string id;
        public int ver;
        public string separate;
        public DateTime ship_date;
        public string it_customer;
        public string seller_id;
        public string m_id;
        public string bill_type_no;
        public string phone;
        public string fax;
        public string email;
        public string linkman;
        public string l_phone;
        public double exchange_rate;
        public double m_rate;
        public string po_no;
        public string issues_wh;
        public string flag;
        public string name;
        public string address;
        public string p_id;
        public string pc_id;
        public string cd_disc;
        public float disc_rate;
        public float disc_amt;
        public float disc_spare;
        public float other_fare;
        public float goods_sum;
        public float tax_sum;
        public float total_sum;
        public float ncr_amount;
        public float ncrb_amount;
        public string update_count;
        public string area;
        public string as_id;
        public string merchandiser;
        public string merchandiser_phone;
        public string finally_buyer;
        public string bill_address;
        public string confirm_status;
        public string packinglistno;
        public string mo_group;
        public string servername;
        public string fake_bill_address;
        public string fake_address;
        public string voucher_id;
        public string fake_name;
    }

    public class soinvoice_details_geo
    {
        public string id;
        public int ver;
        public string ship_date;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public string goods_unit;
        public float u_invoice_qty;
        public float u_invoice_qty_pcs;
        public float sec_qty;
        public string sec_unit;
        public string location_id;
        public string carton_code;
        public string shipment_suit;
        public string remark;
        public int package_num;
        public string box_no;
        public string order_id;
        public int so_ver;
        public string so_sequence_id;
        public string table_head;
        public string customer_goods;
        public string customer_color_id;
        public string contract_cid;
        public string spec;
        public string is_print;
        public string lot_no;
    }
    public class so_zipper_order_head
    {
        public string id;
        public DateTime order_date;
        public string it_customer;
        public string cust_po;
        public string mo_group;
        public string crusr;
        public DateTime crtim;
    }
    public class so_zipper_order_details
    {
        public string id;
        public string sequence_id;
        public string prd_seq;
        public string mo_group;
        public string mo_id;
        public string goods_id;
        public string mat_type;
        public decimal order_qty;
        public decimal sample_qty;
        public string goods_unit;
        public string spec_id;
        public string spec_oth;
        public string cust_goods_style;
        public string color_c;
        public string color_y;
        public string color_oth;
        public string manu_craft_group;
        public string manu_craft_id;
        public string manu_craft_cdesc;
        public string manu_craft_oth;
        public string prd_process_id;
        public string prd_process_cdesc;
        public string prd_process_oth;
        public string prd_process_color;
        public string prd_process_id1;
        public string prd_process_cdesc1;
        public string prd_process_oth1;
        public string prd_process_color1;
        public string zipper_head;
        public string zipper_head_oth;
        public string naked_select;
        public string naked_cdesc;
        public string zipper_tooth;
        public string zipper_color;
        public string zipper_color_oth;
        public string pull_card_no;
        public string pull_card_color_id;
        public string pull_card_color;
        public string test_std;
        public string test_std_cdesc;
        public string prd_use;
        public string prd_use_oth;
        public string cloth_type;
        public string size;
        public string size_unit;
        public string size_cm;
        public string size_inc;
        public string size_diff;
        public string size_diff_oth;
        public string pack_type;
        public string pack_type_oth;
        public string wash_type;
        public string wash_type_oth;
        public string brand_id;
        public string remark1;
        public string remark2;
        public string no_mag_test;
        public string crusr;
        public DateTime crtim;
    }

    public class so_zipper_pr_head
    {
        public string id;
        public string ap_date;
        public string beginning_time;
        public string end_time;
        public string create_date;
        public string userid;
        public string dep;
    }
    public class so_zipper_pr_details
    {
        public string id;
        public string sequence_id;
        public string goods_id;
        public string goods_name;
        public string goods_unit;
        public decimal ap_qty;
        public string remark;
        public string req_date;
        public decimal sec_qty;
        public string sec_unit;
        public string mo_id;
        public string sub_sequence_id;
        public string old_id;
        public string old_sequence_id;
    }

    public class custom_delivry_details
    {
        public string id;
        public string issues_date;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public float issues_qty;
        public string issues_unit;
        public float sec_qty;
        public string sec_unit;
        public string remark;
        public string order_id;
    }

    public class StTransferHead
    {
        public string id;
        public string transfer_date;
        public string bill_type_no;
        public string group_no;
        public string remark;
    }

    public class StTransferDetails
    {
        public string id;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public string shipment_suit;
        public string location_id;
        public decimal transfer_amount;
        public decimal sec_qty;
        public decimal nwt;
        public decimal gross_wt;
        public decimal package_num;
        public string position_first;
        public decimal inventory_qty;
        public decimal inventory_sec_qty;
        public string remark;
    }
    public class StTransferDetailsPart
    {
        public string sequence_id;
        public string goods_id;
        public string location;
        public decimal con_qty;
        public decimal sec_qty;
        public decimal inventory_qty;
        public decimal inventory_sec_qty;
    }
    public class PackListHead
    {
        public string id;
        public string packing_date;
        public string sailing_date;
        public string type;
        public string origin_id;
        public string customer_id;
        public string customer;
        public string linkman;
        public string phone;
        public string fax;
        public string shipping_tool;
        public string remark;
    }
    public class PackListDetails
    {
        public string id;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string shipment_suit;
        public string box_no;
        public string po_no;
        public string goods_name;
        public string goods_ename;
        public string order_id;
        public string ref_id;
        public decimal pcs_qty;
        public string unit_code;
        public decimal pbox_qty;
        public string symbol;
        public string sec_unit;
        public int box_qty;
        public decimal cube_ctn;
        public decimal nw_each;
        public decimal gw_each;
        public decimal total_cube;
        public decimal tal_nw;
        public decimal tal_gw;
        public string remark;
        public string tr_id;
        public string tr_id_seq;
        public decimal tr_id_weg;
        public string carton_size;
    }

    public class st_delivery_prepare
    {
        public string id;
        public string group_no;
        public string linkman;
        public string transfer_date;
        public string create_by;
        public string create_date;
        public string update_by;
        public string update_date;
        public string state;
        public string transfers_state;
        public string remark;
        public string row_status;
    }

    public class st_delivery_prepare_detail
    {
        public string id;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public decimal plan_qty;
        public decimal move_qty;
        public string base_unit;
        public string up_deptment;
        public string state;
    }

    public class st_delivery_find
    {
        public string id1;
        public string id2;
        public string group_no;        
        public string transfer_date1;
        public string transfer_date2;
        public string create_by1;
        public string create_by2;
        public string mo_id1;
        public string mo_id2;

    }

    public class packing_mo_records
    {
        public int prd_id;
        public string mo_id;
        public decimal qty;
        public decimal weg;
        public string box_no;
    }
}
