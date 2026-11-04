using cf01.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsCombinePart
    {
        static clsPublicOfGEO clsErp = new clsPublicOfGEO();
        static PubFunDAL pubFunction = new PubFunDAL();
        static StringBuilder sbSql = new StringBuilder();
        public clsCombinePart()
        {
        }

        public static string GetMaxID(string year_month)
        {
            string result = string.Empty, bill_code = string.Empty, strPrefix = "D";
            string strSql = string.Format(@"Select pkey,bill_code From sys_bill_max_separate WHERE within_code='0000' AND bill_id='ST09' AND year_month='{0}'", year_month); //ST11
            DataTable dtBillMax = clsErp.GetDataTable(strSql);
            if (dtBillMax.Rows.Count > 0)
            {
                bill_code = "AC" + year_month + (int.Parse(dtBillMax.Rows[0]["bill_code"].ToString().Trim().Substring(6, 4)) + 1).ToString().PadLeft(4, '0'); //ST09:AC26020004;//ST11:AD26100008
                int p_key = int.Parse(dtBillMax.Rows[0]["pkey"].ToString());
                strSql = string.Format(@"Update sys_bill_max_separate With(rowlock) SET bill_code='{0}' WHERE pkey={1}", bill_code, p_key);
            }
            else
            {
                bill_code = "AC" + year_month + "0001";
                strSql = string.Format(
                @"INSERT INTO sys_bill_max_separate(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) Values
                ('0000', 'ST09', '{0}', '{1}', '', '', '', '', '')", year_month, bill_code);
            }
            result = (clsErp.ExecuteSqlUpdate(strSql) < 0) ? "-1" : bill_code;
            result = strPrefix + result;
            return result;
        }

        public static string Save(mdlCompinePart  mdlHead, List<mdlCompinePartDetails> lstDetails)
        {
            string sql_i = "", maxId = "", strResult = "";
            int result = 0;
            string strDate= clsUtility.GetCurrentDateTime();
            strDate = strDate.Substring(2, 5).Replace("-", "");//2610
            maxId = GetMaxID(strDate);
            StringBuilder sb = new StringBuilder();
            sb.Append(@" SET XACT_ABORT ON ");
            sb.Append(@" BEGIN TRANSACTION ");
            mdlHead.id = maxId;
            
            sql_i = string.Format(
               @" INSERT INTO st_inventory_mostly(within_code,id,inventory_date,ii_location,state,transfers_state,update_count,create_by,create_date,
                                                    update_by, update_date, department_id, origin,bill_type_no,servername,turn_type)
               Values('0000','{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',   '{8}','{9}','{10}','{11}','{12}','{13}','{14}' )",
               mdlHead.id,mdlHead.inventory_date,mdlHead.ii_location,mdlHead.state,mdlHead.transfers_state,mdlHead.update_count,mdlHead.create_by,mdlHead.create_date,
               mdlHead.update_by,mdlHead.update_date,mdlHead.department_id,mdlHead.origin,mdlHead.bill_type_no,mdlHead.servername,mdlHead.turn_type);
            sb.Append(sql_i);
            sql_i = "";
            foreach (mdlCompinePartDetails dr in lstDetails)
            {
                dr.id = maxId;
                sql_i = string.Format(
                @" INSERT INTO st_i_subordination
                (within_code,id,sequence_id,goods_id,goods_name,base_unit,unit,rate,ib_qty,i_amount,inventory_issuance,ii_code,ii_lot_no,inventory_receipt,ir_code,ir_lot_no,
                average_cost,state,transfers_state,ib_weight,i_weight,mo_id,obligate_mo_id,only_detail,goods_id_new,goods_name_new,sec_unit) 
                Values ('0000','{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},'{9}','{10}',  '{11}','{12}','{13}','{14}',{15},'{16}','{17}',
                {18},{19},'{20}','{21}','{22}','{23}','{24}','{25}')",
                dr.id,dr.sequence_id,dr.goods_id,dr.goods_name,dr.base_unit,dr.unit,dr.rate,dr.ib_qty,dr.i_amount,dr.inventory_issuance,dr.ii_code,
                dr.ii_lot_no,dr.inventory_receipt,dr.ir_code,dr.ir_lot_no,dr.average_cost,dr.state,dr.transfers_state,
                dr.ib_weight,dr.i_weight,dr.mo_id,dr.obligate_mo_id,dr.only_detail,dr.goods_id_new,dr.goods_name_new,dr.sec_unit);
                sb.Append(sql_i);
            }
            sb.Append(@" COMMIT TRANSACTION ");
            clsPublicOfGEO clsConErp = new clsPublicOfGEO();
            result = clsConErp.ExecuteSqlUpdate(sb.ToString());
            sb.Clear();
            strResult = (result >= 0) ? maxId : "";
            return strResult;
        }

       
        public static string CheckApproveState(string id)
        {
            string result = "0";
            string sql_f = string.Format(@"SELECT state FROM st_inventory_mostly with(nolock) WHERE within_code='0000' And id='{0}'", id);
            result = clsErp.ExecuteSqlReturnObject(sql_f);
            return result;
        }
      

        //批準或反批準：倉庫發料/倉庫轉倉/R單轉正單/轉貨品編碼、轉批號 共用
        public static string Approve(mdlCompinePart head, string user_id, string approve_type, string turnType)
        {
            string within_code = "0000";
            string result = "", is_active_name, is_turn_type = "", strSql = "", ls_dept2;
            string ls_id, ls_origin, ls_mrp_id, ls_sequence_id, ls_unit_code, ls_servername;
            string ls_goods_id, ls_dept_id, ls_wp_id, ls_next_wp_id, ls_mo_id, ls_obligate_mo_id, ls_ir_lot_no, ls_ii_lot_no, ls_goods_id_new;
            int ll_count, ll_count2, ll_cnt, ll_cnt_state1, ll_cnt_state3, ll_cnt_state4, rst = 0;
            decimal ldec_qty, ldec_i_amount, ldec_i_weight;
            string ldt_date, ldt_check_date;
            is_turn_type = turnType;  //区分类型：A--倉庫發料;B--倉庫轉倉;C--R單轉正單;D--轉貨品編碼、轉批號;E--廢料合拼
            ldt_check_date = clsPublic.GetDbDateTime("L");//批準日期(長日期時間)
            is_active_name = approve_type == "1" ? "pfc_ok" : "pfc_unok";
            DataTable dtFind = new DataTable();

            if (is_active_name == "pfc_ok")
            {
                //批準前各模塊資料合法性檢查
                DataTable dtDetail = new DataTable();
                strSql = string.Format(
                @"Select sequence_id, mo_id, goods_id, inventory_issuance, inventory_receipt, obligate_mo_id,goods_id_new,ii_lot_no,ir_lot_no
                From st_i_subordination
                Where id='{0}' and within_code='{1}' ORDER BY sequence_id", head.id, within_code);
                dtDetail = clsErp.ExecuteSqlReturnDataTable(strSql);
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    ls_sequence_id = dtDetail.Rows[i]["sequence_id"].ToString();
                    ls_mo_id = dtDetail.Rows[i]["mo_id"].ToString();
                    ls_goods_id = dtDetail.Rows[i]["goods_id"].ToString();
                    ls_wp_id = dtDetail.Rows[i]["inventory_issuance"].ToString();
                    ls_next_wp_id = dtDetail.Rows[i]["inventory_receipt"].ToString();
                    ls_obligate_mo_id = dtDetail.Rows[i]["obligate_mo_id"].ToString();
                    ls_goods_id_new = dtDetail.Rows[i]["goods_id_new"].ToString();
                    ls_ir_lot_no = dtDetail.Rows[i]["ir_lot_no"].ToString();
                    ls_ii_lot_no = dtDetail.Rows[i]["ii_lot_no"].ToString();
                    ls_mo_id = !string.IsNullOrEmpty(ls_mo_id) ? ls_mo_id : "";
                    ls_goods_id = !string.IsNullOrEmpty(ls_goods_id) ? ls_goods_id : "";
                    ls_wp_id = !string.IsNullOrEmpty(ls_wp_id) ? ls_wp_id : "";
                    ls_next_wp_id = !string.IsNullOrEmpty(ls_next_wp_id) ? ls_next_wp_id : "";
                    ls_obligate_mo_id = !string.IsNullOrEmpty(ls_obligate_mo_id) ? ls_obligate_mo_id : "";
                    ls_ir_lot_no = !string.IsNullOrEmpty(ls_ir_lot_no) ? ls_ir_lot_no : "";
                    ls_ii_lot_no = !string.IsNullOrEmpty(ls_ii_lot_no) ? ls_ii_lot_no : "";
                    ls_goods_id_new = !string.IsNullOrEmpty(ls_goods_id_new) ? ls_goods_id_new : "";

                    //A--倉庫發料
                    if (turnType == "A")
                    {
                        if (ls_wp_id != "" && ls_next_wp_id != "" && ls_wp_id == ls_next_wp_id && ls_wp_id != "818")
                        {
                            result = "-1" + "Row[" + ls_sequence_id + "]" + "轉出倉與轉入倉不可以相同!";
                            break;
                        }
                        ll_cnt = 0;
                        strSql = string.Format(
                        @"Select Count(1) as cnt From jo_bill_mostly A WITH(NOLOCK),jo_bill_goods_details B WITH(NOLOCK)
                        Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state Not In('2','V') And 
                        A.within_code='{0}' And A.mo_id='{1}' And B.goods_id='{2}' And B.wp_id='{3}' And B.next_wp_id='{4}'",
                            within_code, ls_mo_id, ls_goods_id, ls_wp_id, ls_next_wp_id);
                        dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                        ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                        if (ll_cnt == 0)
                        {
                            strSql = string.Format(
                            @"Select Count(1) as cnt                 
                            From jo_bill_mostly a WITH(NOLOCK),
                                jo_bill_goods_details b WITH(NOLOCK),
                                jo_bill_materiel_details c WITH(NOLOCK)
                            Where a.within_code = b.within_code and a.id = b.id and a.ver = b.ver and a.state not in ('2','V') and
                            b.within_code = c.within_code and b.id = c.id and b.ver = c.ver and b.sequence_id = c.upper_sequence and
                            a.within_code='{0}' And a.mo_id='{1}' and c.materiel_id='{2}' and c.location='{3}' and b.wp_id='{4}'",
                                within_code, ls_mo_id, ls_goods_id, ls_wp_id, ls_next_wp_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                        }
                        if (ll_cnt <= 0)
                        {
                            result = "-1" + "Row[" + ls_sequence_id + "]" + "流程上規定的交貨與實際交貨不一至！";
                            break;
                        }
                        ll_cnt = 0;
                        strSql = string.Format(
                        @"Select Count(1) cnt       
                        From jo_bill_mostly a WITH(NOLOCK),
                            jo_bill_goods_details b WITH(NOLOCK),
                            jo_bill_materiel_details c WITH(NOLOCK)
                        Where a.within_code = b.within_code and a.id = b.id and a.ver = b.ver and a.state not in ('2', 'V') and
                            b.within_code = c.within_code and b.id = c.id and b.ver = c.ver and b.sequence_id = c.upper_sequence and
                            a.within_code='{0}' and a.mo_id='{1}' and c.materiel_id='{2}' and c.location='{3}' and b.wp_id='{4}' and isnull(b.hold,'')<>'' ",
                        within_code, ls_mo_id, ls_goods_id, ls_wp_id, ls_next_wp_id);
                        dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                        ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                        if (ll_cnt > 0)
                        {
                            result = "-1" + "Row[" + ls_sequence_id + "]" + "工單已經被Hold,不允許進行后續的流程！" + "],[" + ls_mo_id + "],[" + ls_goods_id + "]";
                            break;
                        }
                        //--判断除了当前流程之后有没有对QC的流程(20130916 huangyun固定702部门)
                        ls_dept2 = "";
                        strSql = string.Format(
                        @"Select Top 1 next_wp_id as dept2  
                        From jo_bill_mostly a WITH(NOLOCK),jo_bill_goods_details b WITH(NOLOCK)
                        Where a.within_code='{0}' And a.within_code=b.within_code And a.state not in ('2','V')
				            And a.id = b.id And a.ver = b.ver And a.mo_id='{1}' And b.goods_id='{2}'
                            And b.wp_id ='{3}' And b.next_wp_id='702' And Isnull(b.next_wp_id,'')<>'{4}'",
                        within_code, ls_mo_id, ls_goods_id, ls_wp_id, ls_next_wp_id);
                        dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                        if (dtFind.Rows.Count > 0)
                        {
                            ls_dept2 = dtFind.Rows[0]["dept2"].ToString();
                        }
                        ls_dept2 = string.IsNullOrEmpty(ls_dept2) ? "" : ls_dept2;
                        if (ls_dept2 != "" && ls_next_wp_id != "702")
                        {
                            ll_cnt = 0;
                            strSql = string.Format(
                            @"Select Count(1) as cnt                 
                            From so_order_manage a WITH(NOLOCK),so_order_details b WITH(NOLOCK),so_order_production_bom c WITH(NOLOCK)
                            Where a.within_code = b.within_code and a.id = b.id and a.ver = b.ver and
                                b.within_code = c.within_code and b.id = c.id and b.ver = c.ver and
                                a.state not in('2', 'V') and b.state not in('2','V') and b.sequence_id = c.upper_sequence And
                                c.within_code='{0}' And c.charge_dept='{1}' And c.next_wp_id='{2}' And b.mo_id='{3}' And c.goods_id='{4}'",
                            within_code, ls_wp_id, ls_next_wp_id, ls_mo_id, ls_goods_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_cnt == 0)
                            {
                                ll_cnt = 0;
                                strSql = string.Format(
                                @"Select Count(1) as cnt                    
                                From st_inventory_mostly a WITH(NOLOCK),st_i_subordination b WITH(NOLOCK)
                                Where a.within_code='{0}' And a.within_code = b.within_code And a.state not in ('2','V')
						            And a.id=b.id And b.mo_id='{0}' And b.goods_id='{1}'
                                    And b.inventory_issuance ='{2}' And b.inventory_receipt='{3}' And A.turn_type='{4}'",
                                within_code, ls_mo_id, ls_goods_id, ls_wp_id, ls_dept2, "A");
                                dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                                ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                                //判斷是否有相開對應QC生產計畫的移交單
                                if (ll_cnt <= 0)
                                {
                                    result = "-1" + "Row[" + ls_sequence_id + "]" + "沒有相關QC的轉倉單!";
                                    break;
                                }
                            }
                        }
                    } //--end if (turnType == "A")

                    //--必須檢查轉出、轉入倉是倉管部門(部門資料)或倉庫組(倉位資料)時才允許保存。
                    if (is_turn_type == "B") //正常仓库转仓,与计划单流程无关
                    {
                        //貨品編碼為原料(ML開頭)，保存時需檢查頁數與庫存頁數是否相同，不相同不允許保存                    
                        if (ls_goods_id.Substring(0, 2).ToUpper() == "ML" && ls_mo_id != ls_obligate_mo_id)
                        {
                            result = "-1" + "Row[" + ls_sequence_id + "]" + "庫存頁數與當前頁數必須相同!";
                            break;
                        }
                        if (ls_wp_id != "802")//(P487)當轉出倉802原料倉時，不用檢查轉入倉庫是倉管部門或倉庫組，因802倉會定期發料到車間，是不按流程的.
                        {
                            ll_cnt = 0;
                            strSql = string.Format(
                            @"Select Count(1) as cnt From cd_productline WITH(NOLOCK)
                            Where within_code='{0}' And id='{1}' And Isnull(state,'0')<>'2'", within_code, ls_wp_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_cnt == 0)//去部门资料中判断
                            {
                                ll_cnt = 0;
                                strSql = string.Format(
                                @"Select Count(1) as cnt From cd_department A WITH(NOLOCK),cd_productline B WITH(NOLOCK)
                                Where A.within_code=B.within_code And A.location=B.id
                                    And B.within_code='{0}' And Isnull(A.wh_dept,'0')='1' And B.id='{1}'", within_code, ls_wp_id);
                                dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                                ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                                if (ll_cnt == 0)
                                {
                                    result = "-1" + "Row[" + ls_sequence_id + "]" + "所選倉庫必须为倉管部門!" + "轉出倉[" + ls_wp_id + "]";
                                    break;
                                }
                                //--判断转入仓
                                ll_cnt = 0;
                                strSql = string.Format(
                                @"Select Count(1) as cnt From cd_productline WITH(NOLOCK)
                                Where within_code='{0}' And id='{1}' And Isnull(state,'0')<>'2'", within_code, ls_next_wp_id);
                                dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                                ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                                if (ll_cnt == 0)//去部门资料中判断
                                {
                                    ll_cnt = 0;
                                    strSql = string.Format(
                                    @"Select Count(1) as cnt From cd_department A WITH(NOLOCK),cd_productline B WITH(NOLOCK)
                                    Where A.within_code=B.within_code And A.location=B.id
                                       And B.within_code='{0}' And Isnull(A.wh_dept,'0')='1' And B.id='{1}'", within_code, ls_next_wp_id);
                                    dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                                    ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                                }
                                if (ll_cnt == 0)
                                {
                                    result = "-1" + "Row[" + ls_sequence_id + "]" + "所選倉庫必须为倉管部門!" + "轉入倉[" + ls_next_wp_id + "]";
                                    break;
                                }
                            }
                        }
                    } // end of if (is_turn_type=="B")

                    //C--R單轉正單
                    if (is_turn_type == "C")
                    {
                        /*
                        //R单转仓时,页 数必须为R单
                        if (ls_mo_id != "" && ls_obligate_mo_id != "" && ls_mo_id.Substring(0, 1) != "R" && ls_obligate_mo_id.Substring(0, 1) != "R")
                        {
                            result = "-1" + "Row[" + ls_sequence_id + "]" + "頁數或者庫存頁數必须為R單頁數!";
                            break;
                        }*/
                        //R单转出,转入仓位必须相同
                        if (ls_wp_id != "" && ls_next_wp_id != "" && ls_wp_id != ls_next_wp_id)
                        {
                            result = "-1" + "Row[" + ls_sequence_id + "]" + "當為R單時時,轉出倉和轉入倉必须相同!";
                            break;
                        }
                        //轉入、轉出倉相同; 頁數、庫存頁數不能為空且不可以相同,庫存頁數或頁數中須有一個是R開頭;頁數(不是庫存頁數)中須存在此貨品編號//判断是否为R单的情况
                        if (ls_wp_id == ls_next_wp_id && ls_mo_id != "" && ls_obligate_mo_id != "" && ls_mo_id != ls_obligate_mo_id)
                        {
                            ll_cnt = 0;
                            strSql = string.Format(
                            @"Select Count(1) as cnt                
                            From jo_bill_mostly A WITH(NOLOCK),jo_bill_goods_details B WITH(NOLOCK)
                            Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state Not In('2','V') And 
                                  A.within_code='{0}' And A.mo_id='{1}' And B.goods_id='{2}'", within_code, ls_mo_id, ls_goods_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_cnt == 0)
                            {
                                strSql = string.Format(
                                @"Select Count(1) as cnt                
                                From jo_bill_mostly a WITH(NOLOCK),jo_bill_goods_details b WITH(NOLOCK),jo_bill_materiel_details c WITH(NOLOCK)
                                Where a.within_code = b.within_code And a.id = b.id And a.ver = b.ver And a.state not in ('2','V') And
                                      b.within_code=c.within_code And b.id=c.id And b.ver=c.ver And b.sequence_id=c.upper_sequence And
                                      a.within_code='{0}' And a.mo_id='{1}' And c.materiel_id='{2}'", within_code, ls_mo_id, ls_goods_id);
                                dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                                ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            }
                            if (ll_cnt <= 0)
                            {
                                result = "-1" + "Row[" + ls_sequence_id + "]" + "當前頁數中不存此貨品編號!";
                                break;
                            }
                        }
                    }//end of if (is_turn_type=="C")

                    //D:轉貨品編號、轉批號
                    if (is_turn_type == "D" || is_turn_type == "E")
                    {
                        if (is_turn_type == "D")
                        {
                            if ((ls_ir_lot_no == ls_ii_lot_no && ls_goods_id == ls_goods_id_new) || (ls_ir_lot_no != ls_ii_lot_no && ls_goods_id != ls_goods_id_new))
                            {
                                result = "-1" + "Row[" + ls_sequence_id + "]" + "貨品编碼和批號必須且只能修改其中一个!";
                                break;
                            }
                        }
                    }

                    if (result != "")
                    {
                        return result;
                    }
                } //--end for
            }


            if (is_active_name == "pfc_ok" || is_active_name == "pfc_unok")
            {
                ls_id = head.id;
                ls_origin = head.origin;
                ldt_date = head.inventory_date;
                ls_dept_id = head.department_id;
                ls_servername = head.servername;
                if (is_active_name == "pfc_unok")
                {
                    ldt_check_date = "";//old code: head.check_date;
                }
                strSql = string.Format(
                @"Select sequence_id,unit,i_amount,i_weight,inventory_issuance,inventory_receipt,mo_id,goods_id,obligate_mo_id
				From st_i_subordination WITH(nolock) Where id ='{0}' And within_code ='{1}'", head.id, within_code);
                DataTable dt = clsErp.ExecuteSqlReturnDataTable(strSql);
                string sql_update = string.Empty;                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ls_sequence_id = dt.Rows[i]["sequence_id"].ToString();
                    if (is_turn_type == "A")
                    {
                        ls_unit_code = dt.Rows[i]["unit"].ToString();
                        ldec_i_amount = decimal.Parse(dt.Rows[i]["i_amount"].ToString());
                        ldec_i_weight = decimal.Parse(dt.Rows[i]["i_weight"].ToString());
                        ls_wp_id = dt.Rows[i]["inventory_issuance"].ToString();
                        ls_next_wp_id = dt.Rows[i]["inventory_receipt"].ToString();
                        ls_mo_id = dt.Rows[i]["mo_id"].ToString();
                        ls_goods_id = dt.Rows[i]["goods_id"].ToString();
                        ls_obligate_mo_id = dt.Rows[i]["obligate_mo_id"].ToString();
                        strSql = string.Format(
                        @"Select count(1) as cnt 
                        From jo_bill_mostly A WITH(nolock),jo_bill_goods_details B WITH(NOLOCK)
                        Where A.within_code = B.within_code And A.id = B.id And A.ver = B.ver
                          And A.state Not In('2','V') And A.within_code ='{0}' And A.mo_id ='{1}'
                          And B.goods_id ='{2}' And B.next_wp_id ='{3}' And (B.wp_id ='{4}' Or Left('{5}', 1)='R')",
                        within_code, ls_mo_id, ls_goods_id, ls_next_wp_id, ls_wp_id, ls_obligate_mo_id);
                        dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                        ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                        if (ll_count > 0)
                        {
                            sql_update = string.Format(
                            @" Update B WITH(ROWLOCK)
					        Set	B.c_qty=Isnull(B.c_qty,0) +
                            Case When '{6}'='pfc_ok' 
                                 Then dbo.FN_CHANGE_UNITS(B.within_code,B.goods_id,'{7}',B.goods_unit,Isnull({8},0)) 
                                 Else -dbo.FN_CHANGE_UNITS(B.within_code,B.goods_id,'{7}',B.goods_unit,Isnull({8},0)) 
                            End,
						    B.c_qty_ok = Isnull(B.c_qty_ok,0) +  
                            Case When '{6}'='pfc_ok' 
                                 Then dbo.FN_CHANGE_UNITS(B.within_code,B.goods_id,'{7}',B.goods_unit,Isnull({8},0)) 
                                 Else -dbo.FN_CHANGE_UNITS(B.within_code,B.goods_id,'{7}',B.goods_unit,Isnull({8},0)) 
                            End,
						    B.c_sec_qty = Isnull(B.c_sec_qty,0) + Case When '{6}'='pfc_ok' Then Isnull({9},0) Else -Isnull({9},0) End,
						    B.c_sec_qty_ok = Isnull(B.c_sec_qty_ok,0) + Case When '{6}'='pfc_ok' Then Isnull({9},0) Else -Isnull({9},0) End
					        From jo_bill_mostly A,jo_bill_goods_details B
					        Where A.within_code = B.within_code And A.id = B.id And A.ver = B.ver
						    And A.state Not In('2','V') And A.within_code ='{0}' And A.mo_id ='{1}'
						    And B.goods_id = '{2}' And B.next_wp_id ='{3}' And (b.wp_id ='{4}' Or Left('{5}',1)='R')",
                            within_code, ls_mo_id, ls_goods_id, ls_next_wp_id, ls_wp_id, ls_obligate_mo_id, is_active_name, ls_unit_code, ldec_i_amount, ldec_i_weight);
                            sql_update = RetunSqlString(sql_update); //已包含事務代碼
                            result = clsErp.ExecuteSqlUpdateReturnString(sql_update);
                            if (result == "")
                            {
                                result = "00";
                            }
                            else
                            {
                                //保存失敗!
                                result += "-1數據保存失敗!" + is_active_name + result;
                                break;
                            }
                            //--
                            sql_update = string.Format(
                            @" Update B WITH(ROWLOCK)
					        Set B.goods_state=(Case When (Isnull(B.prod_qty,0)-Isnull(B.c_qty,0)<= 0) Then '4' Else (Case When Isnull(B.c_qty,0)>0 Then '3' Else '1' End) End)
					        From jo_bill_mostly A,jo_bill_goods_details B
					        Where A.within_code = B.within_code And A.id = B.id And A.ver = B.ver
						    And A.state Not In('2','V') And A.within_code='{0}' And A.mo_id='{1}'
						    And B.goods_id='{2}' And B.next_wp_id ='{3}' And (b.wp_id ='{4}' Or Left('{5}',1)='R')",
                            within_code, ls_mo_id, ls_goods_id, ls_next_wp_id, ls_wp_id, ls_obligate_mo_id);
                            sql_update = RetunSqlString(sql_update);
                            result = clsErp.ExecuteSqlUpdateReturnString(sql_update);                           
                            if (result == "")
                            {
                                result = "00";
                            }
                            else
                            {
                                //保存失敗!
                                result += "-1數據保存失敗!" + is_active_name + result;
                                break;
                            }
                            //--
                            ll_count = 0;
                            strSql = string.Format(
                            @"Select count(1) as cnt					
					        From jo_bill_mostly M WITH (nolock) 
                            Inner Join jo_bill_goods_details D WITH (nolock) On M.within_code=D.within_code And M.id=D.id And M.ver=D.ver
						    Inner Join jo_bill_materiel_details DD WITH (nolock)
                                On D.within_code=DD.within_code And D.id=DD.id And D.ver=DD.ver And D.sequence_id=DD.upper_sequence
					        Where M.state Not In('2','V') And M.within_code='{0}' And M.mo_id='{1}' And D.wp_id='{2}' And DD.materiel_id='{3}'",
                            within_code, ls_mo_id, ls_next_wp_id, ls_goods_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_count > 0)
                            {
                                sql_update = string.Format(
                                @" Update D WITH(ROWLOCK) 
                                Set predept_rechange_qty=Isnull(D.predept_rechange_qty,0) + Case When '{4}'='pfc_ok' Then IsNull({5},0) else - IsNull({5},0) End,
							        predept_rechange_sec_qty=Isnull(D.predept_rechange_sec_qty,0) + Case When '{4}'='pfc_ok' Then IsNull({6},0) else -IsNull({6},0) End
						        From jo_bill_mostly M 
                                Inner Join jo_bill_goods_details D On M.within_code = D.within_code And M.id = D.id And M.ver = D.ver
						        Inner Join jo_bill_materiel_details DD On D.within_code=DD.within_code And D.id=DD.id And D.ver=DD.ver And D.sequence_id=DD.upper_sequence
						        Where M.within_code='{0}' And M.mo_id='{1}' And M.state Not In('2','V') And D.wp_id='{2}' And DD.materiel_id='{3}'",
                                within_code, ls_mo_id, ls_next_wp_id, ls_goods_id, is_active_name, ldec_i_amount, ldec_i_weight);
                                sql_update = RetunSqlString(sql_update);  
                                result = clsErp.ExecuteSqlUpdateReturnString(sql_update);
                                if (result == "")
                                {
                                    result = "00";
                                }
                                else
                                {
                                    //保存失敗!
                                    result += "-1數據保存失敗!" + is_active_name + result;
                                    break;
                                }
                            }

                            //--start 从触发器中移过来
                            ll_cnt = 0;
                            ll_cnt_state1 = 0;
                            ll_cnt_state3 = 0;
                            ll_cnt_state4 = 0;
                            //--
                            strSql = string.Format(
                            @"Select Sum(1) as cnt,
							Sum(Case When Isnull(B.goods_state,'0') = '1' Then 1 Else 0 End) as cnt_state1,
							Sum(Case When Isnull(B.goods_state,'0') = '3' Then 1 Else 0 End) as cnt_state3,
							Sum(Case When Isnull(B.goods_state,'0') = '4' Then 1 Else 0 End) as cnt_state4                    
                            From jo_bill_mostly A WITH (NOLOCK),jo_bill_goods_details B WITH (NOLOCK)
					        Where A.within_code = B.within_code And A.id = B.id And A.ver = B.ver And
						      A.within_code ='{0}' And A.mo_id ='{1}' And A.state Not In('2','V')", within_code, ls_mo_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_cnt = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            ll_cnt_state1 = int.Parse(dtFind.Rows[0]["cnt_state1"].ToString());
                            ll_cnt_state3 = int.Parse(dtFind.Rows[0]["cnt_state3"].ToString());
                            ll_cnt_state4 = int.Parse(dtFind.Rows[0]["cnt_state4"].ToString());
                            if (ll_cnt > 0)//如果明细有生产中的数据,主表的状态也要为生产中
                            {
                                sql_update = string.Format(
                                @" Update M WITH(ROWLOCK) 
                                Set M.state =(Case When({2} > 0) Then '3' When({3}={4}) Then '4' When({3}={4}) Then '1' Else M.state End)
                                From jo_bill_mostly M
                                Where M.within_code='{0}' And M.mo_id='{1}' And M.state Not In('2','3','V')",
                                within_code, ls_mo_id, ll_cnt_state3, ll_cnt, ll_cnt_state4, ll_cnt_state1);
                                sql_update = RetunSqlString(sql_update);
                                result = clsErp.ExecuteSqlUpdateReturnString(sql_update);
                                if (result == "")
                                {
                                    result = "00";
                                }
                                else
                                {
                                    result += "-1數據保存失敗!" + is_active_name + result;
                                    break;
                                }
                            }
                        }// end of if (ll_count > 0)
                    } //-- end of if(is_turn_type == "A")


                    //更新交易表
                    ll_count = 0;
                    if (is_turn_type == "A")
                    {
                        strSql = string.Format(
                        @"Select Count(1) as cnt            
                        From st_cc_details_schedule WITH(NOLOCK)
                        Where within_code ='{0}' And id ='{1}' And upper_sequence ='{2}'", within_code, ls_id, ls_sequence_id);
                    }
                    else
                    {
                        strSql = string.Format(
                        @"Select Count(1) as cnt            
                        From st_i_subordination WITH(nolock)
                        Where id ='{0}' And sequence_id ='{1}' And within_code ='{2}'", ls_id, ls_sequence_id, within_code);
                    }
                    dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                    ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                    //**star ll_count>0
                    
                    if (ll_count > 0)
                    {
                        if (is_active_name == "pfc_ok")
                        {
                            ll_count = 0;
                            strSql = string.Format(
                            @"Select count(1) as cnt                        
                            From st_business_record  WITH(NOLOCK)
                            Where within_code='{0}' And id='{1}' And sequence_id='{2}' And action_id='28'", within_code, ls_id, ls_sequence_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_count == 0)
                            {
                                sql_update = string.Format(
                                @" Insert Into st_business_record(within_code,id,goods_id,goods_name,unit,base_unit,rate,action_time,action_id,ii_qty,
								    ii_location_id,ii_code,operator,check_date,sequence_id,ib_qty,qty,sec_unit,sec_qty,
								    lot_no,
								    mo_id,dept_id,servername)
					            Select	a.within_code,a.id,a.goods_id,a.goods_name,a.unit,a.base_unit,a.rate,'{3}',
                                        '28',
								        a.i_amount ,
								        a.inventory_issuance,a.ii_code,'{4}','{5}',
								        a.sequence_id,
								        dbo.FN_CHANGE_UNITBYCV(a.within_code,a.goods_id,a.unit,1,'','','*'),
								        round(dbo.FN_CHANGE_UNITBYCV(a.within_code,a.goods_id,a.unit,a.i_amount,'','','/'),4),
								        (Select gross_unit From it_price_storage Where it_price_storage.within_code=a.within_code And it_price_storage.id=a.goods_id),
								        a.i_weight,
								        Isnull(a.ii_lot_no,a.ir_lot_no),--//库存出批号
								        a.obligate_mo_id,
								        '{6}','{7}'
					            From st_i_subordination A
					            Where A.within_code='{0}' And A.id='{1}' And A.sequence_id='{2}'",
                                within_code, ls_id, ls_sequence_id, ldt_date, user_id, ldt_check_date, ls_dept_id, ls_servername);
                                result = clsErp.ExecuteSqlUpdateReturnString(sql_update);
                                if (result == "")
                                {
                                    result = "00";
                                }
                                else
                                {
                                    result = "-1數據保存失敗!<" + is_active_name + ">(" + "st_business_record)[28]" + result;
                                    break;
                                }

                                //--更新库存
                                result = pubFunction.of_update_st_details("I", "28", ls_id, ls_sequence_id, ldt_check_date, "");
                                if (result.Substring(0, 2) == "-1")
                                {
                                    result = "-1數據保存失敗!<" + is_active_name + ">(" + "st_details)" + result;
                                    break;
                                }
                            }
                            //--start 20131022 huangyun 因为'轉貨品編號'功能是同一个部门操作,所以不需要单独去进行签收操作

                        }// --end if is_active_name = 'pfc_ok' Then

                        //反批准时操作
                        if (is_active_name == "pfc_unok")
                        {
                            ll_count = 0;
                            strSql = string.Format(
                            @"Select count(1) as cnt
                            From st_business_record WITH(NOLOCK)
                            Where within_code='{0}' And id='{1}' And sequence_id='{2}' And action_id='28'",
                            within_code, ls_id, ls_sequence_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_count > 0)
                            {
                                //先更新库存,再删除交易数据
                                result = pubFunction.of_update_st_details("D", "28", ls_id, ls_sequence_id, ldt_check_date, "");
                                if (result.Substring(0, 2) == "-1")
                                {
                                    result = "-1數據保存失敗!<" + is_active_name + ">(" + "st_details)" + result;
                                    break;
                                }
                                sql_update = string.Format(
                                @" Delete From st_business_record Where within_code='{0}' And id='{1}' And sequence_id='{2}' And action_id='28'",
                                within_code, ls_id, ls_sequence_id);
                                sql_update = RetunSqlString(sql_update);
                                rst = clsErp.ExecuteSqlUpdate(sql_update);
                                result = (rst >= 0) ? "" : "-1";
                                if (result == "")
                                {
                                    result = "00";
                                }
                                else
                                {
                                    result = "-1數據保存失敗!<" + is_active_name + ">(" + "st_business_record)" + result;
                                    break;
                                }
                            }
                        }
                    }//-- end of ll_count > 0
                }//--end for
                if (result == "")
                {
                    result = "00";
                }
                if (result.Substring(0, 2) == "-1")
                {
                    return result;
                }

                //物料更新
                strSql = string.Format(
                @"Select a.sequence_id,Isnull(a.i_amount,0) as i_amount,Isnull(a.i_weight,0) as i_weight,a.mrp_id,
                    (Case When c.kind='03' Then a.i_weight Else a.i_amount End) as qty
			    From st_i_subordination a0,st_cc_details_schedule a, it_goods b,cd_units c
                Where a0.within_code = a.within_code and a0.id = a.id and
                    a0.sequence_id = a.upper_sequence and a.within_code = b.within_code And a.goods_id = b.id And
                    b.within_code = c.within_code And b.unit_code = c.id And
                    a.within_code='{0}' And a.id='{1}'", within_code, ls_id);
                DataTable dtFind2 = clsErp.ExecuteSqlReturnDataTable(strSql);
                for (int i = 0; i < dtFind2.Rows.Count; i++)
                {
                    ls_sequence_id = dtFind2.Rows[i]["sequence_id"].ToString();
                    ldec_i_amount = decimal.Parse(dtFind2.Rows[i]["i_amount"].ToString());
                    ldec_i_weight = decimal.Parse(dtFind2.Rows[i]["i_weight"].ToString());
                    ls_mrp_id = dtFind2.Rows[i]["mrp_id"].ToString();
                    ldec_qty = decimal.Parse(dtFind2.Rows[i]["qty"].ToString());
                    if (is_turn_type == "A")
                    {
                        strSql = string.Format(
                        @"Select Count(1) as cnt 
                        From jo_bill_mostly a WITH(NOLOCK),
                             jo_bill_materiel_details b WITH(NOLOCK),
                             st_cc_details_schedule c WITH(NOLOCK)
                        Where a.within_code=b.within_code and a.id=b.id and a.ver=b.ver and a.state not in('2','V') and
                            b.within_code=c.within_code and b.id=c.ref_id and b.sequence_id=c.ref_sequence_id and IsNull(c.state,'0')<>'2' and
                            c.within_code='{0}' and c.id ='{1}' And c.sequence_id='{2}'",
                        within_code, ls_id, ls_sequence_id);
                        dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                        ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                        if (ll_count > 0)
                        {
                            sql_update = string.Format(
                            @" Update jo_bill_materiel_details WITH(ROWLOCK)
				            Set i_qty = IsNull(b.i_qty,0) + Case When '{3}'='pfc_ok' Then Isnull({4},0) Else -Isnull({4},0) end,
						        i_sec_qty = IsNull(b.i_sec_qty,0) +  Case When '{3}'='pfc_ok' Then Isnull({5},0) Else -Isnull({5},0) End
				            From jo_bill_mostly a,jo_bill_materiel_details b,st_cc_details_schedule c
				            Where a.within_code=b.within_code and a.id=b.id and a.ver=b.ver and a.state not in('2','V') and
						        b.within_code=c.within_code and b.id=c.ref_id and b.sequence_id=c.ref_sequence_id and IsNull(c.state,'0')<>'2' and
						        c.within_code='{0}' and c.id='{1}' And c.sequence_id='{2}'",
                            within_code, ls_id, ls_sequence_id, is_active_name, ldec_i_amount, ldec_i_weight);
                            sql_update = RetunSqlString(sql_update);
                            rst = clsErp.ExecuteSqlUpdate(sql_update);
                            result = (rst >= 0) ? "" : "-1";
                            if (result == "")
                            {
                                result = "00";
                            }
                            else
                            {
                                result = "-1數據保存失敗!" + result;
                                break;
                            }
                            ll_count = 0;
                            //更新库存预留表
                            strSql = string.Format(@"Select Count(1) as cnt From mrp_st_details_lot WITH (NOLOCK) Where within_code='{0}' And id='{1}'", within_code, ls_mrp_id);
                            dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                            ll_count = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                            if (ll_count > 0)
                            {
                                sql_update = string.Format(
                                @" Update mrp_st_details_lot WITH(ROWLOCK) 
                                  Set issue_qty=IsNull(issue_qty, 0) + Case When '{2}'='pfc_ok' Then IsNull({3},0) Else -IsNull({3},0) End
                                  Where within_code='{0}' And id ='{1}'",
                                within_code, ls_mrp_id, is_active_name, ldec_qty);
                            }
                            sql_update = RetunSqlString(sql_update);
                            result = clsErp.ExecuteSqlUpdateReturnString(strSql);
                            if (result == "")
                            {
                                result = "00";
                            }
                            else
                            {
                                result = "-1數據保存失敗!" + result;
                                break;
                            }
                        }
                    } //--enf If is_turn_type = 'A' Then

                    //更新交易表
                    strSql = string.Format(
                    @"Select count(1) as cnt
                    From st_business_record WITH(NOLOCK)
                    Where within_code='{0}' And id ='{1}' And sequence_id ='{2}' And action_id='28'", within_code, ls_id, ls_sequence_id);
                    dtFind = clsErp.ExecuteSqlReturnDataTable(strSql);
                    ll_count2 = int.Parse(dtFind.Rows[0]["cnt"].ToString());
                    if (is_active_name == "pfc_ok")
                    {
                        if (ll_count2 == 0)
                        {
                            sql_update = string.Format(
                            @" Insert Into st_business_record(within_code,id,goods_id,goods_name,unit,base_unit,rate,action_time,action_id,ii_qty,
						            ii_location_id,ii_code,operator,check_date,sequence_id,lot_no,
						            ib_qty,qty,sec_unit,sec_qty,mo_id,dept_id,servername)
				            Select A.within_code,A.id,A.goods_id,A.goods_name,A.unit,A.base_unit,A.rate,'{3}','28',A.i_amount,
						            A.inventory_issuance,A.ii_code,'{4}','{5}',A.sequence_id,
						            IsNull(A.ref_lot_no,A.ir_lot_no),
						            dbo.FN_CHANGE_UNITBYCV(A.within_code,A.goods_id,A.unit,1,'','','*'),
						            round(dbo.FN_CHANGE_UNITBYCV(A.within_code,A.goods_id,A.unit,A.i_amount,'','','/'),4),
						            (Select gross_unit From it_price_storage Where it_price_storage.within_code=A.within_code And it_price_storage.id=A.goods_id),
						            A.i_weight,A.obligate_mo_id,'{6}','{7}'
				            From st_cc_details_schedule A
				            Where A.within_code='{0}' And A.id='{1}' And A.sequence_id='{2}'",
                            within_code, ls_id, ls_sequence_id, ldt_date, user_id, ldt_check_date, ls_dept_id, ls_servername);
                            sql_update = RetunSqlString(sql_update);
                            result = clsErp.ExecuteSqlUpdateReturnString(sql_update);
                            if (result == "")
                            {
                                result = "00";
                            }
                            else
                            {
                                result = "-1數據保存失敗!<" + is_active_name + ">(st_business_record)[28]" + result;
                                break;
                            }
                            //--更新库存
                            result = pubFunction.of_update_st_details("I", "28", ls_id, ls_sequence_id, ldt_check_date, "");//= -1 Then                           
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = "-1數據保存失敗!<" + is_active_name + ">(st_details)" + result;
                                break;
                            }
                        }
                    }// -- end of If(is_active_name == 'pfc_ok')

                    //反批准时处理
                    if (is_active_name == "pfc_unok")
                    {
                        if (ll_count2 > 0)
                        {
                            //先更新库存,再删除交易数据
                            result = pubFunction.of_update_st_details("D", "28", ls_id, ls_sequence_id, ldt_check_date, "");
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = "-1數據保存失敗!<" + is_active_name + ">(st_details)" + result;
                                break;
                            }
                            //--
                            sql_update = string.Format(
                            @" Delete From st_business_record 
				            Where within_code='{0}' And id='{1}' And sequence_id='{2}' And action_id='28'", within_code, ls_id, ls_sequence_id);
                            sql_update = RetunSqlString(sql_update);
                            result = clsErp.ExecuteSqlUpdateReturnString(sql_update);
                            if (result == "")
                            {
                                result = "00";
                            }
                            else
                            {
                                result = "-1數據保存失敗!<" + is_active_name + ">(st_business_record)" + result;
                                break;
                            }
                        }
                    }// -- end of If is_active_name=='pfc_unok'
                } // --end for loop

            } //--end of if (is_active_name == "pfc_ok" || is_active_name == "pfc_unok")

            //批準/反批準成功時需手動更新主表的狀態
            if (result.Substring(0, 2) == "00")
            {
                bool is_pfc_ok = (is_active_name == "pfc_ok") ? true : false;
                string checkDate = is_pfc_ok ? ldt_check_date : "";
                string checkBy = is_pfc_ok ? user_id : "";
                string state = is_pfc_ok ? "1" : "0";
                strSql = string.Format(
                @"Update st_inventory_mostly with(Rowlock) 
                  SET check_date=(Case When '{2}'<>'' Then '{2}' Else null End), check_by='{3}',
                       update_date=(Case When '{2}'<>'' Then '{2}' Else getdate() End),update_by='{4}',state='{5}' 
                  WHERE within_code='{0}' And id='{1}'", within_code, head.id, checkDate, checkBy, user_id, state);                
                result = clsErp.ExecuteSqlUpdateReturnString(strSql);
                result = (result == "") ? "00" : "-1" + result;
            }
            return result;
        }//-- end 批準/反批準

        public static string RetunSqlString(string strSql)
        {
            string str = string.Empty;            
            sbSql.Clear();
            sbSql.Append(" SET XACT_ABORT ON ");
            sbSql.Append(" BEGIN TRANSACTION ");
            sbSql.Append(strSql);
            sbSql.Append(@" COMMIT TRANSACTION ");
            str = sbSql.ToString();
            sbSql.Clear();
            return str;
        }

        //************** 
    }
}
