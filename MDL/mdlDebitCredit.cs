using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlDebitCredit
    {
        public string id;
        public string issues_date;
        public string type;
        public string it_customer;
        public string name;
        public string cd_seller;
        public string sales_group;

        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string goods_name;
        public string contract_cid;
        public int invoice_qty;
        public string issues_unit;
        public decimal sec_qty;
        public string sec_unit;
        public string location_id;
        public string order_id;
        public string invoice_id;
    }

    public class mdlLocationCust
    {
        public string location_id;
        public string it_customer;
    }


}
