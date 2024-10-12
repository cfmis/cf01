using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsStTransferToHk
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private string within_code = DBUtility.within_code;
        private string userid = DBUtility._user_id;
        //組別

        public DataTable getTypeNo(string mo_type)
        {
            string strSql = "";
            strSql = "Select id,name From cd_mo_type where mo_type='" + mo_type + "'" + " Order By id";
            DataTable dt = clsConErp.ExecuteSqlReturnDataTable(strSql);
            if (mo_type == "SOURCE99")
            {

                DataRow newRow;
                newRow = dt.NewRow();
                newRow["id"] = "1";
                newRow["name"] = "手動輸入";
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["id"] = "2";
                newRow["name"] = "銷售訂單";
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["id"] = "3";
                newRow["name"] = "轉出單";
                dt.Rows.Add(newRow);
            }
            dt.DefaultView.Sort = "id";
            return dt;
        }
        //產生新的轉出單號
        public string addNewDoc(StTransferHead objModel)
        {
            int result = 0;
            string strSql = "";
            string strSql_f = "";
            string id = "";
            string id1 = "";
            string bill_id = "ST04";
            string bill_code = "";
            string dat = objModel.transfer_date;//"2000/01/01";//
            string year_month = dat.Substring(2, 2) + dat.Substring(5, 2) + dat.Substring(8, 2);
            string bill_type_no = objModel.bill_type_no;
            string group_no = objModel.group_no;
            id1 = bill_type_no + group_no + "0" + year_month;
            strSql_f = "Select bill_code From sys_bill_max_separate Where within_code='" + within_code + "' AND bill_id='" + bill_id +
            "' AND year_month='" + year_month + "' AND bill_text1='" + bill_type_no + "' AND bill_text2='" + group_no + "'";
            DataTable tbGenNo = clsConErp.ExecuteSqlReturnDataTable(strSql_f);
            if (tbGenNo.Rows.Count > 0)
            {
                bill_code = tbGenNo.Rows[0]["bill_code"].ToString();
                bill_code = id1 + (Convert.ToInt32(bill_code.Substring(10, 2)) + 1).ToString().PadLeft(2, '0');
                strSql += string.Format(@"Update sys_bill_max_separate Set bill_code='{0}' Where within_code='{1}' AND bill_id='{2}' AND year_month='{3}' AND bill_text1='{4}' AND bill_text2='{5}'"
                    , bill_code, within_code, bill_id, year_month, bill_type_no, group_no);
            }
            else
            {
                bill_code = id1 + "01";
                strSql += string.Format(@"INSERT INTO sys_bill_max_separate (within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) " +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
                    , within_code, bill_id, year_month, bill_code, bill_type_no, group_no, "", "", "");
            }
            id =bill_code;
            int update_count = 1;
            //插入發貨記錄主表
            strSql += string.Format(@"INSERT INTO st_transfer_mostly(" +
                "within_code,id,transfer_date,bill_type_no,state,group_no,department_id,handler,remark,type,transfers_state,origin,servername,update_count,create_by,create_date) " +
                " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',GETDATE())"
                , within_code, id, dat, bill_type_no, "0", group_no, "", "", objModel.remark, "0", "0", "1", "hkserver.cferp.dbo", update_count, userid);
            result = clsConErp.ExecuteSqlUpdate(strSql);
            if (result == 0)
                id = "";
            return id;

        }
        public DataTable findGoodsFromOc(string mo_id,string goods_id, bool set_flag)
        {
            string strSql = "";
            if (set_flag == true)
            {
                strSql = "Select a.goods_id,b.name As goods_name,Convert(INT,a.order_qty) AS order_qty_o,a.goods_unit,Convert(INT,a.order_qty*c.rate) AS order_qty " +
                    " From so_order_details a" +
                    " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id" +
                    " Inner Join it_coding c On a.within_code=c.within_code And a.goods_unit=c.unit_code " +
                    " where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "' And c.id='" + "*" + "'";
                if (goods_id != "")
                    strSql += " And a.goods_id='" + goods_id + "'";
            }
            else
            {
                strSql = "Select b.goods_id,c.name As goods_name,Convert(INT,a.order_qty) AS order_qty_o,a.goods_unit,Convert(INT,a.order_qty*d.rate) AS order_qty " +
                    " From so_order_details a" +
                    " Inner Join so_order_bom b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.sequence_id=b.upper_sequence" +
                    " Left Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                    " Inner Join it_coding d On a.within_code=d.within_code And a.goods_unit=d.unit_code " +
                    " where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "' And d.id='" + "*" + "'";
                if (goods_id != "")
                    strSql += " And b.goods_id='" + goods_id + "'";
            }
            DataTable dtGoods_id = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtGoods_id;
        }
        public DataTable findGoodsStByOc(string loc,string mo_id, string goods_id)
        {
            string strSql = "";

            strSql = "Select d.location_id,a.mo_id,b.goods_id,c.name As goods_name,Sum(d.qty) As st_qty,Sum(d.sec_qty) As st_weg" +
                ",Max(b.dosage) AS dosage,00000000.0000 As count_qty,00000000.0000 As count_weg,'' AS sequence_id " +
                " From so_order_details a" +
                " Inner Join so_order_bom b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.sequence_id=b.upper_sequence" +
                " Left Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                " Inner Join st_details_lot d On a.within_code=d.within_code And a.mo_id=d.mo_id And b.goods_id=d.goods_id" +
                " where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "' And d.location_id='" + loc + "' And d.carton_code='" + loc + "'";
                if (goods_id != "")
                    strSql += " And b.goods_id='" + goods_id + "'";
                strSql += " Group By d.location_id,a.mo_id,b.goods_id,c.name";
            DataTable dtGoods_id = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtGoods_id;
        }
        public DataTable findGoodsSt(string loc, string mo_id, string goods_id)
        {
            string strSql = "";

            strSql = "Select a.goods_id,Sum(a.qty) As st_qty,Sum(a.sec_qty) As st_weg " +
                " From st_details_lot a " +
                " where a.within_code='" + within_code + "' And a.mo_id='" + mo_id +
                "' And a.location_id='" + loc + "' And a.carton_code='" + loc + "' And a.qty>0 ";
            if (goods_id != "")
                strSql += " And a.goods_id='" + goods_id + "'";
            strSql += " Group By a.goods_id";
            DataTable dtGoodsSt = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtGoodsSt;
        }
        public DataTable checkIdState(string id)
        {
            string strSql = "Select id,state From st_transfer_mostly a where a.within_code='" + within_code + "' And a.id='" + id + "'";
            DataTable dtId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return dtId;
        }
        //產生新的轉出單號
        public string updateTranDetails(StTransferDetails objModel, List<StTransferDetailsPart> listDetail)
        {
            int result = 0;
            string strSql = "";
            string seq = "";
            string sub_seq = "";
            string unit_code = "PCS", sec_unit = "KG";
            if (objModel.sequence_id == "")
            {
                seq = getSeq("st_transfer_detail", objModel.id, 4);//設置主表記錄序號
                sub_seq = getSeq("st_transfer_detail_part", objModel.id, 4);//設置明細表記錄序號
                strSql += string.Format(@"INSERT INTO st_transfer_detail(" +
                    " within_code,id,sequence_id,mo_id,goods_id,goods_name,shipment_suit,location_id,carton_code,transfer_amount,sec_qty,nwt,gross_wt,package_num,position_first,inventory_qty,inventory_sec_qty,remark" +
                    ",unit,sec_unit,base_unit,move_location_id,move_carton_code) " +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')"
                    , within_code, objModel.id, seq, objModel.mo_id, objModel.goods_id, objModel.goods_name, objModel.shipment_suit, objModel.location_id, objModel.location_id, objModel.transfer_amount
                    , objModel.sec_qty, objModel.nwt, objModel.gross_wt, objModel.package_num, objModel.position_first, objModel.inventory_qty, objModel.inventory_sec_qty, objModel.remark
                    , unit_code, sec_unit, unit_code, objModel.location_id, objModel.location_id);
                for (int i = 0; i < listDetail.Count; i++)
                {
                    if (i > 0)
                        sub_seq = (Convert.ToInt32(sub_seq.Substring(0, 4)) + 1).ToString().PadLeft(4, '0') + "h";
                    strSql += string.Format(@"INSERT INTO st_transfer_detail_part(" +
                    " within_code,id,upper_sequence,sequence_id,mo_id,goods_id,con_qty,sec_qty,location,carton_code,inventory_qty,inventory_sec_qty" +
                    ",unit_code,sec_unit,jo_qty,c_qty,bom_qty) " +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')"
                    , within_code, objModel.id, seq, sub_seq, objModel.mo_id, listDetail[i].goods_id, listDetail[i].con_qty, listDetail[i].sec_qty, listDetail[i].location, listDetail[i].location
                    , listDetail[i].inventory_qty, listDetail[i].inventory_sec_qty
                    , unit_code, sec_unit, 0, 0, 1);
                }
            }
            else
            {
                seq = objModel.sequence_id;
                strSql += string.Format(@" UPDATE st_transfer_detail SET " +
                    " transfer_amount='{0}',sec_qty='{1}',nwt='{2}',gross_wt='{3}',package_num='{4}',position_first='{5}',inventory_qty='{6}',inventory_sec_qty='{7}',remark='{8}'" +
                    " Where within_code='{9}' And id='{10}' And sequence_id='{11}'"
                    , objModel.transfer_amount, objModel.sec_qty, objModel.nwt, objModel.gross_wt, objModel.package_num, objModel.position_first, objModel.inventory_qty
                    , objModel.inventory_sec_qty, objModel.remark, within_code, objModel.id, seq);
                for (int i = 0; i < listDetail.Count; i++)
                {
                    sub_seq = listDetail[i].sequence_id;
                    strSql += string.Format(@" UPDATE st_transfer_detail_part SET " +
                    " con_qty='{0}',sec_qty='{1}',location='{2}',carton_code='{3}',inventory_qty='{4}',inventory_sec_qty='{5}'" +
                    " Where within_code='{6}' And id='{7}' And upper_sequence='{8}' And sequence_id='{9}' "
                    , listDetail[i].con_qty, listDetail[i].sec_qty, listDetail[i].location, listDetail[i].location, listDetail[i].inventory_qty, listDetail[i].inventory_sec_qty
                    , within_code, objModel.id, seq, listDetail[i].sequence_id);
                }
            }
            result = clsConErp.ExecuteSqlUpdate(strSql);

            if (result == 0)
                seq = "";
            return seq;
        }
        private string getSeq(string tb_name, string id, int seq_len)
        {
            string seq = "";
            string strSql;
            strSql = "Select Max(sequence_id) AS max_seq From " + tb_name + " Where within_code='" + within_code + "' AND id='" + id + "'";
            DataTable tbGenNo = clsConErp.ExecuteSqlReturnDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
            {
                if (seq_len == 4)
                    seq = "0001";
                else
                    if (seq_len == 5)
                        seq = "00001";
            }
            else
                seq = (Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(0, seq_len)) + 1).ToString().PadLeft(seq_len, '0');
            seq = seq + "h";
            return seq;
        }
        public DataTable loadTranMostly(string id)
        {
            string strSql = "Select * From st_transfer_mostly Where within_code='" + within_code + "' And id='" + id + "'";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }
        public DataTable loadTranDetails(string id)
        {
            string strSql = "Select a.*,b.name AS goods_name" +
                " From st_transfer_detail a" +
                " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id" +
                " Where a.within_code='" + within_code + "' And a.id='" + id + "'"
                + " Order By a.sequence_id Desc ";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }
        public string loadTranDetailsByMo(string mo_id)
        {
            string result = "";
            string strSql = "Select a.id" +
                " From st_transfer_mostly a" +
                " Inner Join st_transfer_detail b On a.within_code=b.within_code And a.id=b.id" +
                " Where b.within_code='" + within_code + "' And b.mo_id='" + mo_id + "' And a.bill_type_no IS NOT NULL "
                + " Order By a.transfer_date Desc ";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            if (tbId.Rows.Count > 0)
                result = tbId.Rows[0]["id"].ToString();
            return result;
        }
        public DataTable loadTranDetailsPart(string id,string seq)
        {
            string strSql = "Select a.id,a.sequence_id,a.mo_id,a.goods_id,b.name AS goods_name,a.con_qty As count_qty,a.sec_qty As count_weg" +
                ",a.inventory_qty As st_qty,a.inventory_sec_qty As st_weg,a.location As location_id,a.lot_no" +
                " From st_transfer_detail_part a" +
                " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id" +
                " Where a.within_code='" + within_code + "' And a.id='" + id + "' And upper_sequence='" + seq + "'"
                + " Order By a.sequence_id";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }
        public int deleteHead(string id)
        {
            int result = 0;
            string strSql = "";
            strSql += string.Format(@" Delete From st_transfer_mostly " +
                    " Where within_code='{0}' And id='{1}'"
                    , within_code, id);
            result = clsConErp.ExecuteSqlUpdate(strSql);
            return result;
        }
        public int deleteDetails(string id, string seq)
        {
            int result = 0;
            string strSql = "";
            strSql += string.Format(@" Delete From st_transfer_detail " +
                    " Where within_code='{0}' And id='{1}' And sequence_id='{2}'"
                    , within_code, id, seq);
            strSql += string.Format(@" Delete From st_transfer_detail_part " +
                    " Where within_code='{0}' And id='{1}' And upper_sequence='{2}'"
                    , within_code, id, seq);
            result = clsConErp.ExecuteSqlUpdate(strSql);
            return result;
        }
        public DataTable findTranDoc(string id1,string id2,string dat1,string dat2,string mo_id1,string mo_id2,string state)
        {
            string strSql = "Select a.id,Convert(Varchar(20),a.transfer_date,111) As transfer_date,a.state" +
                ",b.sequence_id,b.mo_id,b.goods_id,b.transfer_amount,b.sec_qty,b.nwt,b.gross_wt" +
                " From st_transfer_mostly a";
            if (mo_id1 == "" && mo_id2 == "")
                strSql += " Left Join ";
            else
                strSql += " Inner Join ";
            strSql += "st_transfer_detail b On a.within_code=b.within_code And a.id=b.id" +
                " Where a.within_code='" + within_code + "'";
            if (id1 != "" && id2 != "")
                strSql += " And a.id>='" + id1 + "' And a.id<='" + id2 + "'";
            if (dat1 != "" && dat2 != "")
                strSql += " And a.transfer_date>='" + dat1 + "' And a.transfer_date<'" + dat2 + "'";
            if (mo_id1 != "" && mo_id2 != "")
                strSql += " And b.mo_id>='" + mo_id1 + "' And b.mo_id<='" + mo_id2 + "'";
            if (state != "")
                strSql += " And a.state='" + state + "'";
            strSql += " And a.bill_type_no IS NOT NULL";
            strSql += " Order By a.transfer_date Desc,a.id";
            DataTable tbId = clsConErp.ExecuteSqlReturnDataTable(strSql);
            return tbId;
        }
    }
}
