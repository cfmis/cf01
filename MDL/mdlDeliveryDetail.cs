using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlDeliveryDetail
    {
    }
    public class mdlDeliveryHead
    {
        public string ID;
        public string transfer_date;
        public string id_type;
        public string mo_group;
        public string state;
    }
    public class mdlDeliveryDetails
    {
        public string ID;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public decimal transfer_amount;
        public decimal sec_qty;
        public decimal nwt;
        public decimal gross_wt;
        public string unit;
        public string sec_unit;
        public string package_num;
        public string position_first;
        public string location_id;
        public string lot_no;
        public string remark;
        public string state;
    }
    public class mdlDeliveryDetailsPart
    {
        public string ID;
        public string upper_sequence;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public decimal con_qty;
        public decimal sec_qty;
        public string unit_code;
        public string sec_unit;
        public string location;
        public string lot_no;
    }
}
