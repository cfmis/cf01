using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlQuotation
    {
        public string trim_code;
        public string brand;
        public string brand_desc;
        public string season;
        public string season_desc;
        public string cf_code;
        public string cust_color;
        public string cf_color;
        public string product_desc;
        public string size;
        public float price_hkd;
        public float price_usd;
        public float hkd_ex_fty;
        public float usd_ex_fty;
        public string price_unit;
        public string lead_time_max;

        public string material;
        public string sub;
    }

    /// <summary>
    ///保存PB公式計算值
    /// </summary>
    public class mdlFormula_Result
    {
        public float price_usd;
        public float price_hkd;
        public float price_rmb;
        public float hkd_ex_fty;
        public float usd_ex_fty;

        public float vnd_bp;
        public float price_vnd_usd;
        public float price_vnd;
        public float price_vnd_grs;
        public float price_vnd_pcs;
        
        public float discount;
        public float disc_price_usd;
        public float disc_price_hkd;
        public float disc_price_rmb;
        public float disc_hkd_ex_fty;
        public float disc_price_vnd;
    }

    /// <summary>
    /// 從報價單基本資料中添加到報價單
    /// </summary>
    public class mdlQuotation_Reprot
    {
        public string brand;
        public string division;
        public string contact;
        public string material;
        public string size;
        public string product_desc;
        public string cust_code;
        public string cf_code;
        public string cust_color;
        public string cf_color;
        public float price_usd;
        public float price_hkd;
        public float price_rmb;        
        public int moq;
        public string price_unit;
        public string temp_code;
        public string ver;
        public string remark;

        public string moq_desc;
        public string moq_unit;
        public string season;
        public string salesman;
        public int mwq;
        public int lead_time_min;
        public int lead_time_max;
        public string lead_time_unit;
        public float md_charge;
        public string md_charge_cny;
        public float number_enter;
        public float hkd_ex_fty;
        public float usd_ex_fty;
        public string sales_group;
        public float moq_for_test;
        public float usd_dap;
        public float usd_lab_test_prx;
        public float ex_fty_hkd;
        public float ex_fty_usd;

        public float discount;
        public float disc_price_usd;
        public float disc_price_hkd;
        public float disc_price_rmb;
        public float disc_hkd_ex_fty;
        public float disc_price_vnd;
        public float die_mould_usd;
        public string die_mould_cny;
        public string rmb_remark;
        public string cust_artwork;
        
        public float price_vnd_usd;
        public float price_vnd;
        public float price_vnd_grs;
        public float price_vnd_pcs;

        public string cf_color_id;
        public string material_type;
        public string product_type;
    }

    public class mdlGroup_Grant
    {
        public string user_id;
        public string group_id;
        public string brand_id;
        public string flag_Old_Record;
    }

    public class mdlQuotationSample
    {
        public string input_date;
        public string season;
        public string plm_code;
        public string cf_code;
        public string material;
        public string size;
        public string macys_color_code;
        public string mo_id;      
        public string cf_color_code;
        public string create_by; 
        public string create_date;
        public string input_date2;
        public string create_date2;
        public string brand_desc;
        public int flag_ck;
        public string excel_type;
    }

    public class mdlDiscountPrice
    {
        public string temp_code;
        public string seq_id;
        public float number_enter;
        public float price_usd;
        public float price_hkd;
        public float price_rmb;
        public float hkd_ex_fty;
        public float usd_ex_fty;
        public string price_unit;
        public float vnd_bp;
        public float price_vnd_usd;
        public float price_vnd;
        public float price_vnd_grs;
        public float price_vnd_pcs;
        public float moq_qty;
        public string moq_unit;
        public string valid_date;
        public string remark;
    }

    /*
     gridView1.SetRowCellValue(cur_row, "", dtPriceDisc.Rows[j]["number_enter"]);
    gridView1.SetRowCellValue(cur_row, "price_usd", dtPriceDisc.Rows[j]["price_usd"].ToString());
    gridView1.SetRowCellValue(cur_row, "price_hkd", dtPriceDisc.Rows[j]["price_hkd"].ToString());
    gridView1.SetRowCellValue(cur_row, "price_rmb", dtPriceDisc.Rows[j]["price_rmb"].ToString());
    gridView1.SetRowCellValue(cur_row, "hkd_ex_fty", dtPriceDisc.Rows[j]["hkd_ex_fty"]);
    gridView1.SetRowCellValue(cur_row, "usd_ex_fty", dtPriceDisc.Rows[j]["usd_ex_fty"]);
    gridView1.SetRowCellValue(cur_row, "price_unit", dtPriceDisc.Rows[j][""].ToString());
    gridView1.SetRowCellValue(cur_row, "vnd_bp", dtPriceDisc.Rows[j][""]);
    gridView1.SetRowCellValue(cur_row, "price_vnd_usd", dtPriceDisc.Rows[j][""].ToString());
    gridView1.SetRowCellValue(cur_row, "price_vnd", dtPriceDisc.Rows[j][""].ToString());
    gridView1.SetRowCellValue(cur_row, "price_vnd_grs", dtPriceDisc.Rows[j][""].ToString());
    gridView1.SetRowCellValue(cur_row, "price_vnd_pcs", dtPriceDisc.Rows[j][""].ToString());
    gridView1.SetRowCellValue(cur_row, "moq", dtPriceDisc.Rows[j][""].ToString());
    gridView1.SetRowCellValue(cur_row, "", "PCS");
    */
}