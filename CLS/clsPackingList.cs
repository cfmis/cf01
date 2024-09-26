using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsPackingList
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private string within_code = DBUtility.within_code;
        private string userid = DBUtility._user_id;

        //提取單位
        public DataTable getUnit(string unit_type)
        {
            string strSql = "";
            strSql = "Select id,name From cd_units Where kind='" + unit_type + "' Order By id";
            DataTable dt = clsConErp.ExecuteSqlReturnDataTable(strSql);
            DataRow newRow;
            newRow = dt.NewRow();
            dt.Rows.Add(newRow);
            dt.DefaultView.Sort = "id";
            return dt;
        }
        //提取紙箱尺寸
        public DataTable getBoxSize()
        {
            string strSql = "";
            strSql = "Select id,name From cd_carton_size Order By id";
            DataTable dt = clsConErp.ExecuteSqlReturnDataTable(strSql);
            DataRow newRow;
            newRow = dt.NewRow();
            dt.Rows.Add(newRow);
            dt.DefaultView.Sort = "id";
            return dt;
        }

        //產生新的裝箱單號
        public string addNewDoc(PackListHead objModel)
        {
            int result = 0;
            string strSql = "";
            string strSql_f = "";
            string id = "";
            string id1 = "";
            string bill_id = "PL02";
            string bill_code = "";
            string type = objModel.type;
            id1 = type;
            strSql_f = "Select bill_code From sys_bill_max_separate Where within_code='" + within_code + "' AND bill_id='" + bill_id +
            "' AND bill_text1='" + type + "'";
            DataTable tbGenNo = clsConErp.ExecuteSqlReturnDataTable(strSql_f);
            if (tbGenNo.Rows.Count > 0)
            {
                bill_code = tbGenNo.Rows[0]["bill_code"].ToString();
                bill_code = id1 + (Convert.ToInt32(bill_code.Substring(2, 10)) + 1).ToString().PadLeft(10, '0');
                strSql += string.Format(@"Update sys_bill_max_separate Set bill_code='{0}' Where within_code='{1}' AND bill_id='{2}' AND bill_text1='{3}'"
                    , bill_code, within_code, bill_id, type);
            }
            else
            {
                bill_code = id1 + "0000000001";
                strSql += string.Format(@"INSERT INTO sys_bill_max_separate (within_code,bill_id,bill_text1) " +
                    " VALUES ('{0}','{1}','{2}')"
                    , within_code, bill_id, type);
            }
            id =  "D" +bill_code;
            //插入發貨記錄主表
            strSql += string.Format(@"INSERT INTO xl_packing_list(" +
                "within_code,id,packing_date,type,origin_id,sailing_date,customer_id,linkman,phone,fax,shipping_tool,remark,create_by,create_date,packing_type,state) " +
                " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',GETDATE(),'{13}','{14}')"
                , within_code, id, objModel.packing_date, type, objModel.origin_id, objModel.sailing_date, objModel.customer_id
                , objModel.linkman, objModel.phone, objModel.fax, objModel.shipping_tool, objModel.remark, userid, "1", "0");
            result = clsConErp.ExecuteSqlUpdate(strSql);
            if (result == 0)
                id = "";
            return id;

        }

        public DataTable findOcData(string mo_id)
        {
            string strSql = "";
            strSql = "Select a.id,a.it_customer,a.contract_id" +
                " From so_order_manage a " +
                " Inner Join so_order_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver" +
                " where b.within_code='" + within_code + "' And b.mo_id='" + mo_id + "'";
            DataTable dtCust = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtCust;
        }

        public DataTable findCustData(string cust)
        {
            string strSql = "";
            strSql = "Select a.id,b.phone,b.fax,b.s_address,b.e_address,b.linkman,a.name As cust_cname" +
                " From it_customer a " +
                " Left Join it_shipment_address b On a.within_code=b.within_code And a.id=b.id" +
                " where a.within_code='" + within_code + "' And a.id='" + cust + "'";
            DataTable dtCust = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtCust;
        }
        public DataTable findGoodsData(string goods_id)
        {
            string strSql = "";
            strSql = "Select a.id,a.name As goods_name,a.english_name As goods_ename,b.name As color_name" +
                " From it_goods a " +
                " Left Join cd_color b On a.within_code=b.within_code And a.color=b.id" +
                " where a.within_code='" + within_code + "' And a.id='" + goods_id + "'";
            DataTable dtGoods = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtGoods;
        }

        //產生新的裝箱單號
        public string updateData(bool new_rec_flag,PackListHead objModelHead,PackListDetails objModelDetails)
        {
            int result = 0;
            string strSql = "";

            string id = objModelDetails.id;

            if (new_rec_flag == false)
            {
                string strSql_f = "";
                if (id == "")
                {
                    string id1 = "";
                    string bill_id = "PL02";
                    string bill_code = "";
                    string type = objModelHead.type;
                    id1 = type;
                    strSql_f = "Select bill_code From sys_bill_max_separate Where within_code='" + within_code + "' AND bill_id='" + bill_id +
                    "' AND bill_text1='" + type + "'";
                    DataTable tbGenNo = clsConErp.ExecuteSqlReturnDataTable(strSql_f);
                    if (tbGenNo.Rows.Count > 0)
                    {
                        bill_code = tbGenNo.Rows[0]["bill_code"].ToString();
                        bill_code = id1 + (Convert.ToInt32(bill_code.Substring(2, 10)) + 1).ToString().PadLeft(10, '0');
                        strSql += string.Format(@"Update sys_bill_max_separate Set bill_code='{0}' Where within_code='{1}' AND bill_id='{2}' AND bill_text1='{3}'"
                            , bill_code, within_code, bill_id, type);
                    }
                    else
                    {
                        bill_code = id1 + "0000000001";
                        strSql += string.Format(@"INSERT INTO sys_bill_max_separate (within_code,bill_id,bill_text1) " +
                            " VALUES ('{0}','{1}','{2}')"
                            , within_code, bill_id, type);
                    }
                    id = "D" + bill_code;
                    //插入發貨記錄主表
                    strSql += string.Format(@"INSERT INTO xl_packing_list(" +
                        "within_code,id,packing_date,type,origin_id,sailing_date,customer_id,customer,linkman,phone,fax,shipping_tool,remark,create_by,create_date,packing_type,state) " +
                        " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',GETDATE(),'{14}','{15}')"
                        , within_code, id, objModelHead.packing_date, type, objModelHead.origin_id, objModelHead.sailing_date, objModelHead.customer_id, objModelHead.customer
                        , objModelHead.linkman, objModelHead.phone, objModelHead.fax, objModelHead.shipping_tool, objModelHead.remark, userid, "1", "0");
                }
                else
                    strSql += string.Format(@"UPDATE xl_packing_list " +
                        " Set packing_date='{0}',sailing_date='{1}',customer_id='{2}',customer='{3}',linkman='{4}',phone='{5}',fax='{6}',shipping_tool='{7}'" +
                        ",remark='{8}',update_by='{9}',update_date=GETDATE() " +
                        " Where within_code='{10}' And id='{11}'"
                        , objModelHead.packing_date, objModelHead.sailing_date, objModelHead.customer_id, objModelHead.customer, objModelHead.linkman
                        , objModelHead.phone, objModelHead.fax, objModelHead.shipping_tool, objModelHead.remark, userid, within_code, id);
            }
            //strSql = "";
            //id = "DPA0000124921";
            string seq = "";
            if (objModelDetails.sequence_id == "")
            {
                seq = getSeq("xl_packing_list_details", id, 4);//設置主表記錄序號
                strSql += string.Format(@"INSERT INTO xl_packing_list_details (" +
                    " within_code,id,sequence_id,mo_id,item_no,descript,english_goods_name,shipment_suit,box_no,po_no,order_id,ref_id,pcs_qty,unit_code" +
                    " ,pbox_qty,symbol,sec_unit,box_qty,cube_ctn,nw_each,gw_each,total_cube,tal_nw,tal_gw,remark,tr_id,tr_sequence_id,sec_qty,carton_size" +
                    " ,length,width,height) " +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}'" +
                    " ,'{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}')"
                    , within_code, id, seq, objModelDetails.mo_id, objModelDetails.goods_id, objModelDetails.goods_name, objModelDetails.goods_ename
                    , objModelDetails.shipment_suit, objModelDetails.box_no, objModelDetails.po_no, objModelDetails.order_id, objModelDetails.ref_id, objModelDetails.pcs_qty
                    , objModelDetails.unit_code
                    , objModelDetails.pbox_qty, objModelDetails.symbol, objModelDetails.sec_unit, objModelDetails.box_qty, objModelDetails.cube_ctn, objModelDetails.nw_each
                    , objModelDetails.gw_each, objModelDetails.total_cube, objModelDetails.tal_nw, objModelDetails.tal_gw, objModelDetails.remark
                    , objModelDetails.tr_id, objModelDetails.tr_id_seq, objModelDetails.tr_id_weg, objModelDetails.carton_size
                    , 0, 0, 0);
            }
            else
            {
                seq = objModelDetails.sequence_id;
                strSql += string.Format(@"UPDATE xl_packing_list_details " +
                    " Set mo_id='{0}',item_no='{1}',descript='{2}',english_goods_name='{3}',shipment_suit='{4}',box_no='{5}',po_no='{6}',order_id='{7}',ref_id='{8}'" +
                    ",pcs_qty='{9}',unit_code='{10}',pbox_qty='{11}',symbol='{12}',sec_unit='{13}',box_qty='{14}',cube_ctn='{15}',nw_each='{16}'" +
                    " ,gw_each='{17}',total_cube='{18}',tal_nw='{19}',tal_gw='{20}',remark='{21}',tr_id='{22}',tr_sequence_id='{23}',sec_qty='{24}',carton_size='{25}'" +
                    " Where within_code='{26}' And id='{27}' And sequence_id='{28}' "
                    , objModelDetails.mo_id, objModelDetails.goods_id, objModelDetails.goods_name, objModelDetails.goods_ename
                    , objModelDetails.shipment_suit, objModelDetails.box_no, objModelDetails.po_no, objModelDetails.order_id, objModelDetails.ref_id, objModelDetails.pcs_qty
                    , objModelDetails.unit_code, objModelDetails.pbox_qty, objModelDetails.symbol, objModelDetails.sec_unit, objModelDetails.box_qty
                    , objModelDetails.cube_ctn, objModelDetails.nw_each, objModelDetails.gw_each, objModelDetails.total_cube, objModelDetails.tal_nw
                    , objModelDetails.tal_gw, objModelDetails.remark, objModelDetails.tr_id, objModelDetails.tr_id_seq, objModelDetails.tr_id_weg, objModelDetails.carton_size
                    , within_code, id, seq);
            }

            if (new_rec_flag == true)
                id = seq;
            result = clsConErp.ExecuteSqlUpdate(strSql);
            if (result == 0)
                id = "";
            return id;

        }

        private string getSeq(string tb_name, string id,int seq_len)
        {
            string seq = "";
            string strSql;
            strSql = "Select Max(sequence_id) AS max_seq From " + tb_name + " Where within_code='" + within_code + "' AND id='" + id + "'";
            DataTable tbGenNo = clsConErp.ExecuteSqlReturnDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
                seq = "0001";
            else
                seq = (Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(0, seq_len)) + 1).ToString().PadLeft(seq_len, '0');
            seq = seq + "h";
            return seq;
        }

        public int deleteHead(string id)
        {
            int result = 0;
            string strSql = "";
            strSql += string.Format(@" Delete From xl_packing_list " +
                    " Where within_code='{0}' And id='{1}'"
                    , within_code, id);
            result = clsConErp.ExecuteSqlUpdate(strSql);
            return result;
        }
        public int deleteDetails(string id, string seq)
        {
            int result = 0;
            string strSql = "";
            strSql += string.Format(@" Delete From xl_packing_list_details " +
                    " Where within_code='{0}' And id='{1}' And sequence_id='{2}'"
                    , within_code, id, seq);
            result = clsConErp.ExecuteSqlUpdate(strSql);
            return result;
        }

        public DataTable loadTranDetailsByMo(string mo_id, bool set_flag)
        {
            string strSql = "";
            if (set_flag == true)
            {
                strSql = "Select b.goods_id,b.goods_name,Convert(Int,b.transfer_amount) As order_qty_o,b.unit As goods_unit,a.id,b.sequence_id,b.sec_qty" +
                    " ,Convert(Int,b.package_num) As package_num,Convert(Decimal(18,2),b.gross_wt) As gross_wt,b.nwt" +
                    " From st_transfer_mostly a" +
                    " Inner Join st_transfer_detail b On a.within_code=b.within_code And a.id=b.id" +
                    " Where b.within_code='" + within_code + "' And b.mo_id='" + mo_id + "' And a.state<>'2' ";

            }
            else
            {
                strSql = "Select c.goods_id,d.name As goods_name,Convert(Int,c.con_qty) As order_qty_o,c.unit_code As goods_unit,a.id,c.sequence_id,b.sec_qty" +
                    " ,Convert(Int,b.package_num) As package_num,Convert(Decimal(18,2),c.sec_qty) As gross_wt,c.sec_qty As nwt" +
                    " From st_transfer_mostly a" +
                    " Inner Join st_transfer_detail b On a.within_code=b.within_code And a.id=b.id" +
                    " Inner Join st_transfer_detail_part c On b.within_code=c.within_code And b.id=c.id And b.sequence_id=c.upper_sequence" +
                    " Left Join it_goods d On c.within_code=d.within_code And c.goods_id=d.id" +
                    " Where b.within_code='" + within_code + "' And b.mo_id='" + mo_id + "' And a.state<>'2' ";

            }
            strSql += " And a.bill_type_no IS NOT NULL "
                + " Order By a.transfer_date Desc ";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }
        public DataTable checkIdState(string id1,string id2,string dat1,string dat2)
        {
            string strSql = "Select id,state From xl_packing_list a where a.within_code='" + within_code + "'";
            if (id1 != "" && id2 == "")
                strSql += " And a.id='" + id1 + "'";
            if (id1 != "" && id2 != "")
                strSql += " And a.id>='" + id1 + "' And a.id<='" + id2 + "'";
            if (dat1 != "" && dat2 != "")
                strSql += " And a.packing_date>='" + dat1 + "' And a.packing_date<'" + dat2 + "'";
            DataTable dtId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtId;
        }

        public DataTable loadIdMostly(string id,string dat)
        {


            string strSql = "Select id,Convert(Varchar(20),packing_date,111) As packing_date,Convert(Varchar(20),sailing_date,111) As sailing_date" +
                ",type,origin_id,customer_id,customer,linkman,phone,fax,shipping_tool,remark,create_by,Convert(Varchar(20),create_date,120) As create_date" +
                ",update_by,Convert(Varchar(20),update_date,120) As update_date,state" +
                " From xl_packing_list " +
                " Where within_code='" + within_code + "' And type='PA' ";
            if(id!="")
                strSql += " And id='" + id + "'";
            if (dat != "")
            {
                string dat2 = Convert.ToDateTime(dat).AddDays(1).ToString("yyyy/MM/dd");
                strSql += " And packing_date>='" + dat + "' And packing_date<'" + dat2 + "'";
            }
            strSql += " Order By create_date Desc,id Desc";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }
        public DataTable loadPackListDetails(string id)
        {
            string strSql = "Select a.id,Convert(Varchar(20),a.packing_date,111) As packing_date,a.customer_id,a.customer As cust_cname,a.destination,a.linkman,a.phone,a.fax" +
                ",b.sequence_id,b.mo_id,b.item_no,b.shipment_suit,b.box_no,b.po_no,b.descript,b.english_goods_name,e.name As color_name,b.order_id,b.ref_id,Convert(INT,b.pcs_qty) As pcs_qty" +
                ",b.unit_code,Convert(INT,b.pbox_qty) As pbox_qty,Convert(INT,b.box_qty) As box_qty,b.symbol,b.sec_unit,Convert(Decimal(10,2),b.cube_ctn) As cube_ctn" +
                ",Convert(Decimal(10,2),b.nw_each) As nw_each,Convert(Decimal(10,2),b.gw_each) As gw_each,Convert(Decimal(10,2),b.total_cube) As total_cube" +
                ",Convert(Decimal(10,2),b.tal_nw) As tal_nw,Convert(Decimal(10,2),b.tal_gw) As tal_gw,b.remark,b.tr_id,b.tr_sequence_id,Convert(Decimal(10,2),b.sec_qty) As sec_qty" +
                ",b.carton_size,f.name As carton_size_name" +
                " From xl_packing_list a" +
                " Inner Join xl_packing_list_details b On a.within_code=b.within_code And a.id=b.id" +
                " Inner Join it_goods d On b.within_code=d.within_code And b.item_no=d.id"+
                " Left Join cd_color e On d.within_code=e.within_code And d.color=e.id"+
                " Left Join cd_carton_size f On b.within_code=f.within_code And b.carton_size=f.id"+
                " Where a.within_code='" + within_code + "' And a.id='" + id + "'" +
                " Order By b.sequence_id ";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }

        public DataTable loadPackListPrint(string id)
        {
            string strSql = "Select a.id,Convert(Varchar(20),a.packing_date,111) As packing_date,a.customer_id,a.customer As cust_cname,a.destination,a.linkman,a.phone,a.fax" +
                ",b.sequence_id,b.mo_id,b.item_no,b.shipment_suit,b.box_no,b.po_no,b.descript,b.english_goods_name,e.name As color_name,b.order_id,b.ref_id,Convert(INT,b.pcs_qty) As pcs_qty" +
                ",b.unit_code,Convert(INT,b.pbox_qty) As pbox_qty,Convert(INT,b.box_qty) As box_qty,b.symbol,b.sec_unit,Convert(Decimal(10,2),b.cube_ctn) As cube_ctn" +
                ",Convert(Decimal(10,2),b.nw_each) As nw_each,Convert(Decimal(10,2),b.gw_each) As gw_each,Convert(Decimal(10,2),b.total_cube) As total_cube" +
                ",Convert(Decimal(10,2),b.tal_nw) As tal_nw,Convert(Decimal(10,2),b.tal_gw) As tal_gw,b.remark,b.tr_id,b.tr_sequence_id,Convert(Decimal(10,2),b.sec_qty) As sec_qty" +
                ",b.carton_size,f.name As carton_size_name,h.invoice_remark" +
                " From xl_packing_list a" +
                " Inner Join xl_packing_list_details b On a.within_code=b.within_code And a.id=b.id" +
                " Inner Join it_goods d On b.within_code=d.within_code And b.item_no=d.id" +
                " Left Join cd_color e On d.within_code=e.within_code And d.color=e.id" +
                " Left Join cd_carton_size f On b.within_code=f.within_code And b.carton_size=f.id" +
                " Inner Join so_order_details g On b.within_code=g.within_code And b.mo_id=g.mo_id" +
                " Left Join so_order_special_info h On g.within_code=h.within_code And g.id=h.id And g.ver=h.ver And g.sequence_id=h.upper_sequence" +
                " Where a.within_code='" + within_code + "' And a.id='" + id + "'" +
                " Order By b.sequence_id ";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }


        public string loadDetailsByMo(string mo_id)
        {
            string result = "";
            string strSql = "Select a.id" +
                " From xl_packing_list a" +
                " Inner Join xl_packing_list_details b On a.within_code=b.within_code And a.id=b.id" +
                " Where b.within_code='" + within_code + "' And b.mo_id='" + mo_id + "' And a.type='PA' "
                + " Order By a.packing_date Desc ";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            if (tbId.Rows.Count > 0)
                result = tbId.Rows[0]["id"].ToString();
            return result;
        }
    }
}
