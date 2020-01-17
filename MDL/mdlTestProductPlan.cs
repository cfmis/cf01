using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlTestItemMostly
    {
        public string id;
        public string type;
        public string cdesc;
        public string edesc;
        public string remark;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;

        public string isExsit;   //原本已存在的數據
        public List<mdlTestItemDetails> lsDetails = new List<mdlTestItemDetails>();
    }

    public class mdlTestItemDetails
    {
        public string id;
        public string seq_id;
        public string test_item_id;
        public string test_item_cdesc;
        public string remark;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;

        public string isExsit;   //原本已存在的數據
    }

    public class mdlTestExcel
    {
        public string mat_id;
        public string seq_id;
        public string color_id;
        public string finish_name;
        public string poduct_type_id;
        public string pattern_id;
        public string trim_color_code;
        public string trim_code;
        public string test_item_id;
        public string test_report_no;
        public string expiry_date;
        public string ref_mo;
        public string remark;
        public string test_report_path;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
        public string size;
        public string cf_color;
        public string sales_group;
        public string doc_type;

        public string report_date;
        public string brand;
        public string invoice_id;
        public string invoice_date;
        public float amount;
        public string amount_unit;
        public string own_reference;
        public string remark2;

    }

    public class mdlTestInvoiceData
    {
        public string test_report_no;        
        public string sales_group;
        public string mat_id;
        public string color_id;
        public string product_type_id;
        public string cust_color ;
        public string trim_code;
        public string test_item_id;
        public string expiry_date;
        public string ref_mo;      
          
    }

    public class mdlTestItem
    {
        public string id;
        public string cdesc;
        public string edesc;
    }
}
