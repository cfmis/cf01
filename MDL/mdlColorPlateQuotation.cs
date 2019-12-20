using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    /// <summary>
    /// 顏色單價設定
    /// </summary>
    public class mdlColorPlateQuotation
    {
        public string color_id;
        public string vendor_id;
        public string valid_date;
        public string color_desc;
        public string vend_color;
        public int fee;
        public string unit;
        public string quotation_no;
        public string quotation_date;
    }

    /// <summary>
    /// 電鍍費
    /// </summary>
    public class mdlmt_plate_fee
    {
        public string mt_item;
        public string valid_date;
        public decimal mt_fee;
        public string mt_unit;
        public string mt_curr;
        public string cr_usr;
        public DateTime cr_tim;
        public string am_usr;
        public DateTime am_tim;
    }

    /// <summary>
    /// 
    /// </summary>
    public class rece_goods_plate
    {
        public int id;
        public string vendor_id;
        public string rec_id;
        public string ir_date;
        public string sequence_id;
        public string mo_id;
        public string goods_id;
        public string vendor_invoice_no;
        public int t_ir_qty;
        public int price;
        public string ir_unit;
        public int sec_qty;
        public int sec_price;
        public string sec_unit;
        public string p_unit;
        public int min_consume_amount;
        public int package_num;
        public string do_color;
        public int total_amt;
    }


}
