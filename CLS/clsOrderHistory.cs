using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cf01.CLS
{
    public class clsOrderHistory
    {
        private static string userid = DBUtility._user_id.ToUpper();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        public static DataTable LoadOcData(string mo_id,string date_from,string date_to,string mo_group,string sel_id
            ,string goods_id,string goods_name,string po_no,string mat_code,string prd_type,string art_code,string size_id,string clr_id
            ,string cust_item,string cust_color,string cust_code,string brand_id,string season
            ,string recNumber)
        {
            string strSql = "";
            string wh_str = "", wh_str1 = "";
            string sl_str = "";
            string jo_str = "";
            strSql += " Select aa.* From ( ";
            sl_str += " Select ";
            if (recNumber != "")
                sl_str += " Top " + recNumber;
            sl_str += " 'M' As MFlag" + ",b.mo_id,Convert(Varchar(50),a.order_date,111) AS order_date" +
                ",b.sequence_id,b.goods_id,b.goods_name,Convert(int,b.order_qty) As order_qty,b.goods_unit" +
                ",Convert(decimal(18,2),b.unit_price) As unit_price" +
                ",b.p_unit,a.m_id,b.total_sum,'0' As primary_key "+
                ",a.it_customer,e.name As cust_cname,a.contract_id,b.brand_id"+
                ",b.add_remark,b.plate_remark,b.customer_goods,b.customer_color_id,a.seller_id"+
                ",Convert(Varchar(10),b.arrive_date,111) AS arrive_date,a.season";
            jo_str += " From so_order_manage a " +
                " Inner Join so_order_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver " +
                " Left Join it_customer e On a.within_code=e.within_code And a.it_customer=e.id";
            wh_str = " Where a.within_code='" + within_code + "' And a.state<>'2' And a.state<>'V' And b.state<>'2' And b.state<>'V' ";
            if (date_from != "" && date_to !="")
            {
                string date_to1 = Convert.ToDateTime(date_to).AddDays(1).ToString("yyyy/MM/dd");
                wh_str += " And a.order_date >= '" + date_from + "' And a.order_date < '" + date_to1 + "'";
            }
            if (cust_code != "")
                wh_str += " And a.it_customer = '" + cust_code + "'";
            if (po_no != "")
                wh_str += " And a.contract_id Like '%" + po_no + "%'";
            if (sel_id != "")
                wh_str += " And a.selller_id = '" + sel_id + "'";
            if (mo_id != "")
                wh_str += " And b.mo_id = '" + mo_id + "'";
            if (goods_id != "")
                wh_str1 += " And b.goods_id Like '%" + goods_id + "%'";
            if (goods_name != "")
                wh_str1 += " And b.goods_name Like '%" + goods_name + "%'";
            if (mo_group != "")
                wh_str += " And b.mo_group = '" + mo_group + "'";

            if (brand_id != "")
                wh_str += " And b.brand_id = '" + brand_id + "'";
            if (cust_item != "")
                wh_str += " And b.customer_goods Like '%" + cust_item + "%'";
            if (cust_color != "")
                wh_str += " And b.customer_color_id Like '%" + cust_code + "%'";
            if (season != "")
                wh_str += " And a.season = '" + season + "'";
            strSql += sl_str + jo_str + wh_str + wh_str1;

            if (goods_id != "" || goods_name != "")
            {
                sl_str = "";
                wh_str1 = "";
                strSql += " Union ";
                sl_str += " Select ";
                if (recNumber != "")
                    sl_str += " Top " + recNumber;
                sl_str += " ' ' As MFlag" + ",b.mo_id,Convert(Varchar(50),a.order_date,111) AS order_date" +
                ",c.sequence_id,c.goods_id,d.name As goods_name,Convert(int,b.order_qty) As order_qty,b.goods_unit" +
                ",Convert(decimal(18,2),b.unit_price) As unit_price" +
                ",b.p_unit,a.m_id,b.total_sum,c.primary_key " +
                ",a.it_customer,e.name As cust_cname,a.contract_id,b.brand_id" +
                ",b.add_remark,b.plate_remark,b.customer_goods,b.customer_color_id,a.seller_id" +
                ",Convert(Varchar(10),b.arrive_date,111) AS arrive_date,a.season";
                jo_str += " Inner Join so_order_bom c On b.within_code=c.within_code And b.id=c.id And b.ver=c.ver And b.sequence_id=c.upper_sequence ";
                jo_str += " Inner Join it_goods d On c.within_code=d.within_code And c.goods_id=d.id ";
                if (goods_name != "")
                    wh_str1 += " And d.name Like '%" + goods_name + "%'";
                if (goods_id != "")
                    wh_str1 += " And c.goods_id Like '%" + goods_id + "%'";
                if (mat_code != "")
                    wh_str1 += " And d.datum = '" + mat_code + "'";
                if (prd_type != "")
                    wh_str1 += " And d.base_class = '" + prd_type + "'";
                if (art_code != "")
                    wh_str1 += " And d.blueprint_id = '" + art_code + "'";
                if (size_id != "")
                    wh_str1 += " And d.size_id = '" + size_id + "'";
                if (clr_id != "")
                    wh_str1 += " And d.color = '" + clr_id + "'";
                strSql += sl_str + jo_str + wh_str + wh_str1;
            }
            strSql += " ) aa ";
            strSql += " Order By aa.mo_id,aa.MFlag Desc,aa.primary_key,aa.sequence_id ";
            DataTable dtOcDetails = clsPublicOfGEO.GetDataTable(strSql);
            dtOcDetails.Columns.Add("SelectFlag", typeof(bool));
            return dtOcDetails;
        }



        public static DataTable LoadOcDataDetails(string mo_id)
        {
            string strSql = "";
            strSql = " Select Top 100 " + "b.mo_id,Convert(Varchar(50),a.order_date,111) AS order_date" +
                ",c.goods_id,d.name As goods_name,c.primary_key,Convert(int,b.order_qty) As order_qty,b.goods_unit" +
                ",Convert(decimal(18,2),b.unit_price) As unit_price" +
                ",b.p_unit,a.m_id,b.total_sum,'0' As primary_key " +
                ",a.it_customer,e.name As cust_cname,a.contract_id,b.brand_id" +
                ",b.add_remark,b.plate_remark,b.customer_goods,b.customer_color_id,a.seller_id" +
                ",Convert(Varchar(10),b.arrive_date,111) AS arrive_date,a.season" +
                ",b.goods_id As goods_id_m,b.goods_name As goods_name_m" +
            " From so_order_manage a " +
                " Inner Join so_order_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver " +
                " Inner Join so_order_bom c On b.within_code=c.within_code And b.id=c.id And b.ver=c.ver And b.sequence_id=c.upper_sequence " +
                " Inner Join it_goods d On c.within_code=d.within_code And c.goods_id=d.id " +
                " Left Join it_customer e On a.within_code=e.within_code And a.it_customer=e.id" +
            " Where a.within_code='" + within_code + "' And a.state<>'2' And a.state<>'V' And b.state<>'2' And b.state<>'V' ";
            strSql += " And b.mo_id = '" + mo_id + "'";

            strSql += " Order By b.mo_id,c.primary_key Desc,c.sequence_id ";
            DataTable dtOcDetails = clsPublicOfGEO.GetDataTable(strSql);
            return dtOcDetails;
        }


        public static DataTable LoadWipData(string mo_id, string date_from, string date_to, string mo_group, string sel_id
            , string goods_id, string goods_name, string po_no, string mat_code, string prd_type, string art_code, string size_id, string clr_id
            , string cust_item, string cust_color, string cust_code, string brand_id, string season
            , string recNumber)
        {
            string strSql = "";
            strSql += " Select ";
            if (recNumber != "")
                strSql += " Top " + recNumber;
            strSql += "a.mo_id,a.ver,Convert(Varchar(50),a.bill_date,111) AS bill_date" +
                ",b.sequence_id,b.goods_id,c.name As goods_name,Convert(int,b.prod_qty) As prod_qty" +
                ",b.wp_id,b.next_wp_id,Convert(int,b.c_qty_ok) As c_qty_ok,Convert(decimal(18,2),b.c_sec_qty_ok) As c_sec_qty_ok" +
                ",CASE WHEN b.c_qty_ok >0 THEN Convert(decimal(18,4),(b.c_sec_qty_ok / b.c_qty_ok)*1000) ELSE 0 END As WegK" +
                ",c.do_color,Convert(Varchar(50),b.f_complete_date,111) AS f_complete_date";
            strSql += " From jo_bill_mostly a " +
                " Inner Join jo_bill_goods_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver " +
                " Inner Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id ";
            strSql += " Where a.within_code='" + within_code + "' And a.state<>'2' And a.state<>'V' ";
            if (mo_id != "")
                strSql += " And a.mo_id = '" + mo_id + "'";
            if (goods_name != "")
                strSql += " And c.name Like '%" + goods_name + "%'";
            if (goods_id != "")
                strSql += " And b.goods_id Like '%" + goods_id + "%'";
            if (date_from != "" && date_to != "")
            {
                string date_to1 = Convert.ToDateTime(date_to).AddDays(1).ToString("yyyy/MM/dd");
                strSql += " And a.bill_date >= '" + date_from + "' And a.bill_date < '" + date_to1 + "'";
            }
            strSql += " Order By a.mo_id,b.sequence_id";
            DataTable dtWip = clsPublicOfGEO.GetDataTable(strSql);
            dtWip.Columns.Add("SelectFlag", typeof(bool));
            return dtWip;
        }
        public static DataTable LoadWipMatData(string mo_id, string seq)
        {
            string strSql = "";
            strSql += " Select ";
            strSql += "a.mo_id,c.sequence_id,c.materiel_id,d.name As goods_name,Convert(int,c.fl_qty) As fl_qty" +
                ",c.unit,c.sec_qty,c.sec_unit,c.location,Convert(int,c.i_qty) As i_qty" +
                ",Convert(decimal(18,2),c.i_sec_qty) As i_sec_qty" +
                ",CASE WHEN c.i_qty >0 THEN Convert(decimal(18,4),(c.i_sec_qty / c.i_qty)*1000) ELSE 0 END As WegK";
            strSql += " From jo_bill_mostly a " +
                " Inner Join jo_bill_goods_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver " +
                " Inner Join jo_bill_materiel_details c On b.within_code=c.within_code And b.id=c.id And b.ver=c.ver And b.sequence_id=c.upper_sequence"+
                " Inner Join it_goods d On c.within_code=d.within_code And c.materiel_id=d.id ";
            strSql += " Where a.within_code='" + within_code + "' And a.state<>'2' And a.state<>'V' ";
            if (mo_id != "")
                strSql += " And a.mo_id = '" + mo_id + "'";
            if (seq != "")
                strSql += " And b.sequence_id = '" + seq + "'";
            strSql += " Order By a.mo_id,c.sequence_id";
            DataTable dtWip = clsPublicOfGEO.GetDataTable(strSql);
            return dtWip;
        }
    }
}
