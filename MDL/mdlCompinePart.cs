using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlCompinePart
    {
        public string id;
        public string inventory_date;
        public string ii_location; //601
        public string state; //0
        public string transfers_state;//0
        public string update_count; //1
        public string create_by;
        public string create_date;
        public string update_by;
        public string update_date;
        public string department_id; //''
        public string origin; //1
        public string bill_type_no; //'01'
        public string servername; //'hkserver.cferp.dbo'
        public string turn_type; //'D'
    }

    public class mdlCompinePartDetails
    {
        public string id;
        public string sequence_id;
        public string goods_id;
        public string base_unit; //'PCS'
        public string unit; //'PCS'
        public decimal rate; //1.00
        public decimal ib_qty;
        public decimal i_amount;
        public string inventory_issuance;
        public string ii_code;
        public string ii_lot_no;
        public string inventory_receipt;
        public string ir_code;
        public string ir_lot_no;
        public string average_cost; //0
        public string state; //0
        public string transfers_state; //0
        public decimal ib_weight; //0.00
        public decimal i_weight; //0.00
        public string mo_id;
        public string obligate_mo_id;
        public string only_detail; //1
        public string goods_id_new;
        public string goods_name_new;
        public string sec_unit;
    }
}
