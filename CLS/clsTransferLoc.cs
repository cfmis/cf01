using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsTransferLoc
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private String remote_db = DBUtility.remote_db;
        private String within_code = DBUtility.within_code;

        //產生新的發料單號
        public string AddNewDoc(mdlTransferLoc objModel)
        {
            int result = 0;
            string strSql = "";
            string strSql_f = "";
            string id = "";
            string id1 = "";
            string bill_id = "ST10";
            string bill_code = "";
            string dat = objModel.con_date;//"2000/01/01";
            string year_month = dat.Substring(2, 2) + dat.Substring(5, 2);
            id1 = "AB" + year_month;
            strSql_f = "Select bill_code From sys_bill_max_separate Where within_code='" + within_code + "' AND bill_id='" + bill_id +
            "' AND year_month='" + year_month + "'";
            DataTable tbGenNo = clsConErp.GetDataTable(strSql_f);
            if (tbGenNo.Rows.Count > 0)
            {
                bill_code = tbGenNo.Rows[0]["bill_code"].ToString();
                bill_code = id1 + (Convert.ToInt32(bill_code.Substring(6, 4)) + 1).ToString().PadLeft(4, '0');
                strSql += string.Format(@"Update sys_bill_max_separate Set bill_code='{0}' Where within_code='{1}' AND bill_id='{2}' AND year_month='{3}'"
                    , bill_code, within_code, bill_id, year_month);
            }
            else
            {
                bill_code = id1 + "0001";
                strSql += string.Format(@"INSERT INTO sys_bill_max_separate (within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) " +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
                    , within_code, bill_id, year_month, bill_code, "", "", "", "", "");
            }
            id = "D" + bill_code;
            int update_count = 1;
            //插入發貨記錄主表
            strSql += string.Format(@"INSERT INTO st_inventory_mostly(" +
                "within_code,id,inventory_date,bill_type_no,state,transfers_state,origin,turn_type,servername,update_count"+
                ",create_by,create_date,update_by,update_date) " +
                " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',GETDATE(),'{11}',GETDATE())"
                , within_code, id, objModel.con_date, "01", "0", "0", "1", "B", "hkserver.cferp.dbo", update_count, objModel.crusr, objModel.crusr);
            if (strSql != "")
                result = clsConErp.ExecuteSqlUpdate(strSql);
            if (result == 0)
                id = "";
            return id;

        }

        //查找單據狀態
        public DataTable checkDocStatus(string id)
        {
            DataTable dtId = new DataTable();
            string strSql = "Select a.state From st_inventory_mostly a Where a.within_code='" + within_code + "' and a.id='" + id + "'";
            dtId = clsConErp.GetDataTable(strSql);
            return dtId;
        }

        //插入發貨記錄到明細表
        public string AddStoreRec(List<mdlTransferLoc> listDetail)
        {
            int result = 0;
            string strSql = "";
            string base_unit = "PCS";
            string state = "0";
            string transfers_state = "0";
            string sub_seq = "";
            string unit = "PCS";
            string only_detail = "1";
            int rate = 1;
            sub_seq = GetSeq("st_i_subordination", listDetail[0].id, 4);//獲取明細表記錄序號

            for (int i = 0; i < listDetail.Count; i++)
            {
                if (i > 0)
                    sub_seq = (Convert.ToInt32(sub_seq.Substring(0, 4)) + 1).ToString().PadLeft(4, '0') + "h";
                strSql += string.Format(@"INSERT INTO st_i_subordination(" +
                    " within_code,id,sequence_id,goods_id,base_unit,unit,rate,i_amount,inventory_issuance,ii_code,ii_lot_no" +
                    ",inventory_receipt,ir_code,ir_lot_no,state,transfers_state,i_weight,mo_id,obligate_mo_id,only_detail,so_no,so_sequence_id)" +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'" +
                    ",'{19}','{20}','{21}')"
                    , within_code, listDetail[i].id, sub_seq, listDetail[i].goods_id, base_unit, unit, rate, listDetail[i].qty, listDetail[i].loc, listDetail[i].loc
                    , listDetail[i].lot_no, listDetail[i].t_dep, listDetail[i].t_dep, listDetail[i].lot_no, state, transfers_state, listDetail[i].weg, listDetail[i].mo_id
                    , listDetail[i].obligate_mo_id, only_detail, listDetail[i].so_no, listDetail[i].so_sequence_id);
            }
            if (strSql != "")
                result = clsConErp.ExecuteSqlUpdate(strSql);
            if (result == 0)
                sub_seq = "";
            return sub_seq;
        }
        private string GetSeq(string tb_name, string id, int seq_len)
        {
            string seq = "";
            string strSql;
            strSql = "Select Max(sequence_id) AS max_seq From " + tb_name + " Where within_code='" + within_code + "' AND id='" + id + "'";
            DataTable tbGenNo = clsConErp.GetDataTable(strSql);
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

    }
}
