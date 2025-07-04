﻿using cf01.MDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsTransferout
    {
        private static clsPublicOfGEO clsErp = new clsPublicOfGEO();
        private static PubFunDAL pubFun = new PubFunDAL();
        static StringBuilder sbSql = new StringBuilder();        


        //轉出單最大單據號
        public static string GetMaxID(string billId, string billType, string groupNo, int serialLen)
        {
            string result = "";
            string strSql = string.Format("Select dbo.fn_zz_sys_bill_max_separate_out('{0}','{1}','{2}',{3}) as max_id", billId, billType, groupNo, serialLen);
            result = clsErp.ExecuteSqlReturnObject(strSql);
            return result;
        }

        public static int DelTransferOut(string id)
        {
            int rtn = 0;
            string sql_u = string.Format(@"Update st_transfer_mostly Set state='2' WHERE within_code='0000' And id='{0}'", id);
            rtn = clsErp.ExecuteSqlUpdate(sql_u);
            return rtn;
        }

        public static int CheckMoIsDgD(string bill_type_no, string mo_id)
        {
            //20130327增加开LN单时，只能是东莞D页数的判断
            string special_info_style = "";
            int ll_return = 1;
            string sql = string.Format(
            @"Select ISNULL(C.special_info_style,'0') as special_info_style
            From so_order_manage A with(nolock)
                 INNER JOIN so_order_details B with(nolock) ON A.within_code=B.within_code And A.id=B.id And A.ver=B.ver 
                 INNER JOIN so_order_special_info C with(nolock) 
                        ON B.within_code=C.within_code And B.id=C.id And B.ver=C.ver And B.sequence_id=C.upper_sequence
            Where B.within_code='0000' And B.mo_id='{0}' And A.state Not In('2','V') And B.state Not In('2','V')", mo_id);
            special_info_style = clsErp.ExecuteSqlReturnObject(sql);
            if (special_info_style == "")
            {
                special_info_style = "0";
            }
            switch (bill_type_no)
            {
                case "LN":
                    if (special_info_style != "1")
                    {
                        ll_return = -1;
                        MessageBox.Show("頁數：" + mo_id + "不是東莞D頁數，不允許開在東莞出貨(LN)單中！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case "DN":
                    if (special_info_style == "1")
                    {
                        ll_return = -1;
                        MessageBox.Show("回港(DN)單中,不允許開東莞D頁數(" + mo_id + ")", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
            }
            return ll_return;
        }

        
        public static DataTable FindData(string id1,string id2,string dat1,string dat2,string billTypeNo,string groupNo,string moId1,string moId2)
        {
            DataTable dt = new DataTable();
            string str =
            @"Select a.id,a.transfer_date,a.bill_type_no,a.group_no,b.sequence_id,b.mo_id,b.goods_id,b.goods_name,b.transfer_amount,b.unit,
            b.sec_qty,b.sec_unit
            FROM st_transfer_mostly a with(nolock),st_transfer_detail b with(nolock)
            WHERE a.within_code=b.within_code And a.id=b.id ";
            if (id1 != "")
            {
                str += $" And a.id>='{id1}'";
            }
            if (id2 != "")
            {
                str += $" And a.id<='{id2}'";
            }
            if (dat1 != "")
            {
                str += $" And a.transfer_date>='{dat1}'";
            }
            if (dat2 != "")
            {
                str += $" And a.transfer_date<='{dat2}'";
            }
            if (groupNo != "")
            {
                str += $" And a.group_no='{groupNo}'";
            }
            if (billTypeNo != "")
            {
                str += $" And a.bill_type_no='{billTypeNo}'";
            }
            str +=" And a.type='0' And a.state<>'2'";
            if (moId1 != "")
            {
                str += $" And b.mo_id>='{moId1}'";
            }
            if (moId2 != "")
            {
                str += $" And b.mo_id<='{moId2}'";
            }
            str += " Order by a.id,b.sequence_id";
            dt = clsErp.ExecuteSqlReturnDataTable(str);
            return dt;
        }

        public static decimal of_set_sec_qty(string as_goods_id, string as_unit_code, decimal adec_qty, decimal adec_sec_qty, string as_location_id, string as_carton_code, string as_mo_id)
        {
            //当修改数量时自动计算相应的重量
            //从销售发票现有的函数移动过来(销售发票,东莞D出货,成品拆分组装,销售出货中使用)
            //根据库存数据更新重量
            decimal ldec_location_qty, ldec_location_sec_qty, ldec_sec_qty = 0;
            decimal ldc_mo_qty, ldc_mo_sec_qty;
            //P043--start 20120425 当仓库为S01时，查询条件不加页数
            //--20130329 原来添加的页数条件搞反了
            string sql_f = "", gs_company = "0000";
            if (as_location_id.ToUpper() != "S01") //门市
            {
                sql_f = string.Format(
                @"Select sum(qty) as location_qty, sum(sec_qty) as location_sec_qty From st_details_lot 
                Where within_code='{0}' And goods_id='{1}' And location_id ='{2}' And carton_code='{3}' and mo_id='{4}'",
                gs_company, as_goods_id, as_location_id, as_carton_code, as_mo_id);
            }
            else
            {
                sql_f = string.Format(
                @"Select sum(qty) as location_qty, sum(sec_qty) as location_sec_qty From st_details_lot 
                Where within_code='{0}' And goods_id ='{1}' And location_id='{2}' And carton_code='{3}'",
                 gs_company, as_goods_id, as_location_id, as_carton_code);

            }
            DataTable dt = clsErp.ExecuteSqlReturnDataTable(sql_f);
            if (dt.Rows.Count > 0)
            {
                ldec_location_qty = decimal.Parse(dt.Rows[0]["location_qty"].ToString());
                ldec_location_sec_qty = decimal.Parse(dt.Rows[0]["location_sec_qty"].ToString());
            }
            else
            {
                ldec_location_qty = 0;
                ldec_location_sec_qty = 0;
            }
            //--end 20120425

            //P357--start 取出当前页数的库存           
            sql_f = string.Format(
            @"Select Sum(qty) as mo_qty, Sum(sec_qty) as mo_sec_qty From st_details_lot
            Where within_code='{0}' And goods_id='{1}' And location_id='{2}' And carton_code='{3}' and mo_id='{4}'",
            gs_company, as_goods_id, as_location_id, as_carton_code, as_mo_id);
            dt = clsErp.ExecuteSqlReturnDataTable(sql_f);
            if (dt.Rows.Count > 0)
            {
                ldc_mo_qty = decimal.Parse(dt.Rows[0]["mo_qty"].ToString());
                ldc_mo_sec_qty = decimal.Parse(dt.Rows[0]["mo_sec_qty"].ToString());
            }
            else
            {
                ldc_mo_qty = 0;
                ldc_mo_sec_qty = 0;
            }
            //--end 20121101

            //If Isnull(adec_qty)Then adec_qty = 0
            //If Isnull(adec_sec_qty) Then adec_sec_qty = 0

            //--
            string str_sec_qty = "";
            if (ldec_location_qty == 0 && ldec_location_sec_qty == 0)
            {
                ldec_sec_qty = adec_sec_qty;
            }
            else
            {
                if (ldec_location_qty == 0 || ldec_location_sec_qty == 0)
                {
                    ldec_sec_qty = 0;
                }
                else
                {
                    str_sec_qty = (adec_qty * ldec_location_sec_qty / ldec_location_qty).ToString();
                    ldec_sec_qty = decimal.Parse(str_sec_qty.Substring(0, str_sec_qty.IndexOf('.') + 3));
                }
            }

            //P357--start
            if (adec_qty == ldc_mo_qty)
            {
                ldec_sec_qty = ldc_mo_sec_qty;
            }
            //--end 20121101 

            return ldec_sec_qty;

        }

        public static DataTable GetPackingData(string groupNo, string moID, string updateTime1, string updateTime2,string flagDgd)
        {
            string sql_f = string.Format(
            @"SELECT CAST(0 as bit) As flag_select,A.mo_id,A.goods_id,A.qty,A.weg,A.weg_gross,A.mo_group,A.package_num,A.carton_size,
            CASE WHEN ISNULL(C.special_info_style,'0')='0' THEN '' ELSE '東莞D' END As flag_dgd,A.update_date,
            CASE WHEN LEN(A.goods_id)<18 THEN '' ELSE '底三件走貨' END AS suit_flag
            FROM {0}packing_mo_label A with(nolock)
            INNER JOIN {1}so_order_details B with(nolock) ON B.within_code='0000' AND B.mo_id=A.mo_id
            INNER JOIN {1}so_order_special_info C with(nolock)ON B.within_code=C.within_code and B.id=C.id and B.ver=C.ver AND B.sequence_id=C.upper_sequence
            WHERE A.qty>0 And A.upd_flag='0'", DBUtility.pad_db1, DBUtility.remote_db);
            if (groupNo != "")
            {
                sql_f += $" And A.mo_group='{groupNo}'";
            }
            if (moID != "")
            {
                sql_f += $" And A.mo_id='{moID}'";
            }
            if (updateTime1 != "")
            {
                sql_f += $" And A.update_date>='{updateTime1}'";
            }
            if (updateTime2 != "")
            {
                sql_f += $" And A.update_date<'{updateTime2}'";
            }
            if (flagDgd == "1")
            {
                sql_f += " And ISNULL(C.special_info_style,'0')='1'";
            }
            sql_f += " Order by CONVERT(varchar(10),A.update_date,120),A.mo_id,A.goods_id,A.update_date";
            DataTable dt = clsPublicOfPad.ExecuteSqlReturnDataTable(sql_f);
            return dt;
        }

        public static DataSet GetPackingBomData(List<packing_mo> moList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("mo_id", System.Type.GetType("System.String"));
            dt.Columns.Add("goods_id", System.Type.GetType("System.String"));
            for (int i = 0; i < moList.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["mo_id"] = moList[i].mo_id;
                row["goods_id"] = moList[i].goods_id;
                dt.Rows.Add(row);
            }
            string ProcName = "zz_packing_lable_bom_data";
            SqlParameter[] paras = {
                new SqlParameter("@mo_data",SqlDbType.Structured) {Value = dt}
            };
            DataSet dts = clsErp.ExecuteProcedureReturnDataSet(ProcName, paras, "");
            return dts;
        }

        /// <summary>
        /// Allen 2022-08-23
        /// 集合轉成DataTable
        /// 調用方式：DataTable dt = CommonDAL.ListToDataTable<Entity>(listData);
        /// 參數:Entity 即為實體數據模型,必須預先定義,
        ///     listData,與Entity類相同的集合數據
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IEnumerable<T> list)
        {
            PropertyInfo[] modelItemType = typeof(T).GetProperties();
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(modelItemType.Select(Columns => new DataColumn(Columns.Name, Columns.PropertyType)).ToArray());
            if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in modelItemType)
                    {
                        object obj = pi.GetValue(list.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] dataRow = tempList.ToArray();
                    dataTable.LoadDataRow(dataRow, true);
                }
            }
            return dataTable;
        }

        public static int Save(TransferInHead headData, List<TransferInDetails> lstDetailData1, List<TransferDetailPart> lstDetailData2,
               List<TransferInDetails> lstDelData1, List<TransferDetailPart> lstDelData2, string user_id)
        {
            int result = 0;
            string str = "", ls_servername = "hkserver.cferp.dbo";
            string lot_no = "";
            string id = headData.id;
            string head_insert_status = headData.head_status;
            string within_code = "0000";
            string type = "0", state = "0", updateCount = "1";
            string transfersState = "0";
            string origin = "1";
            string baseUnit = "PCS";
            string strSuit = "0";
            decimal rate = 1;
            decimal packageNum = 0;
            decimal inventoryQty = 0, inventorySecQty = 0;
            decimal accountWeight = 0;

            sbSql.Clear();
            sbSql.Append(" SET XACT_ABORT ON ");
            sbSql.Append(" BEGIN TRANSACTION ");

            if (head_insert_status == "NEW")//全新的單據
            {
                bool id_exists = clsPublic.CheckIdIsExists("st_transfer_mostly", id);
                string bill_id = "ST04";
                if (id_exists)
                {
                    //已存在此單據號,重新取最大單據號                    
                    headData.id = GetMaxID(bill_id, headData.bill_type_no, headData.group_no, 2);//DNV024101802
                }
                //***begin 更新系統表組裝轉換的最大單據編號
                string dept_id = headData.department_id;//105
                string year_month = ""; //model.id.Substring(6, 4);//
                string bill_code = "";  //model.id.Substring(0, 11);DNV024101802
                string bill_type_no = headData.bill_type_no;
                string group_no = headData.group_no;

                year_month = headData.id.Substring(4, 6);   //241018
                bill_code = headData.id.Trim();   //DNV024101802
                string sqlSysUpdate = "";
                string sql_sys_i = string.Format(
                @" INSERT INTO sys_bill_max_separate(within_code, bill_code, bill_id,year_month, bill_text1,bill_text2, bill_text3,bill_text4,bill_text5) 
                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','','','')",
                within_code, bill_code, bill_id, year_month, bill_type_no, group_no);
                string sql_sys_u = string.Format(
                @" UPDATE sys_bill_max_separate SET bill_code='{0}' WHERE within_code='{1}' And bill_id='{2}' And year_month='{3}' And bill_text1='{4}' And bill_text2='{5}'",
                bill_code, within_code, bill_id, year_month, bill_type_no, group_no);
                if (bill_code.Substring(10, 2) != "01")
                    sqlSysUpdate = sql_sys_u;
                else
                    sqlSysUpdate = sql_sys_i;
                str = sqlSysUpdate;
                sbSql.Append(str);
                //***end 更新系統表組裝轉換的最大單據編號 

                //插入主表
                str = string.Format(
                @" Insert Into st_transfer_mostly
                (within_code,id,transfer_date,type,transfers_state,handler,remark,department_id,origin,bill_type_no,group_no,state,servername,update_count,create_by,create_date) 
                Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',getdate())",
                within_code, id, headData.transfer_date, type, transfersState, headData.handler, headData.remark, headData.department_id, origin,
                headData.bill_type_no, headData.group_no, state, ls_servername, updateCount, headData.create_by);
                sbSql.Append(str);

                //插入明細表一                
                foreach (var item in lstDetailData1)
                {
                    lot_no = !string.IsNullOrEmpty(item.lot_no) ? item.lot_no : clsPublic.GetDeptLotNo(item.location_id, item.location_id);//自動生成批號
                    //改变list中某个元素值 (例子: var model = list.Where(c => c.ID == ).FirstOrDefault(); model.Value1 = ;)
                    //历遍移交單臨時數組,更改批號與組裝單批號一致
                    //lstTurnOver.ForEach(i =>
                    //{
                    //    if (i.id == item.id && i.sequence_id == item.sequence_id)
                    //    {
                    //        i.lot_no = lot_no;
                    //    }
                    //});        
                    strSuit = (item.shipment_suit) ? "1" : "0";
                    str = string.Format(
                    @" Insert Into st_transfer_detail
                    (within_code,id,sequence_id,goods_id,goods_name,base_unit,unit,rate,inventory_qty,inventory_sec_qty,transfer_amount,location_id,carton_code,lot_no,state,remark,
                    transfers_state, account_weight, sec_unit, sec_qty, mo_id, nwt, gross_wt, package_num, shipment_suit, move_location_id, move_carton_code) Values 
                    ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}',{17},'{18}',{19},'{20}',{21},{22},{23},{24},'{25}','{26}')",
                    within_code, headData.id, item.sequence_id, item.goods_id, item.goods_name, baseUnit, item.unit, rate, inventoryQty, inventorySecQty, item.transfer_amount, item.location_id, item.carton_code, lot_no, state, item.remark,
                    transfersState, accountWeight, item.sec_unit, item.sec_qty, item.mo_id, item.nwt, item.gross_wt, packageNum, strSuit, item.move_location_id, item.move_carton_code);
                    sbSql.Append(str);
                }

                //插入明細表二
                decimal joQty = 0, cQty = 0;
                foreach (var item in lstDetailData2)
                {
                    str = string.Format(
                    @" Insert Into st_transfer_detail_part(
                    within_code,id,upper_sequence,sequence_id,mo_id,goods_id,jo_qty,c_qty,con_qty,unit_code,remark,sec_unit,sec_qty,location,carton_code,bom_qty,lot_no,inventory_qty,inventory_sec_qty)
                    Values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},'{9}','{10}','{11}',{12},'{13}','{14}',{15},'{16}',{17},{18})",
                    within_code, headData.id, item.upper_sequence, item.sequence_id, item.mo_id, item.goods_id, joQty, cQty, item.con_qty, item.unit_code, item.remark, item.sec_unit, item.sec_qty,
                    item.location, item.location, item.bom_qty, item.lot_no, item.inventory_qty, item.inventory_sec_qty);
                    sbSql.Append(str);
                }
            }
            else //已保存基礎上進行增刪改
            {
                //首先處理刪除(表格一) 
                //注意加選項with(ROWLOCK),只有用到主鍵時才會用到行級鎖
                if (lstDelData1 != null)
                {
                    foreach (var item in lstDelData1)
                    {
                        str = string.Format(
                            @" DELETE FROM st_transfer_detail with(ROWLOCK) Where within_code='0000' AND id='{0}' AND sequence_id='{1}'",
                            item.id, item.sequence_id);
                        sbSql.Append(str);
                    }
                }
                //首先處理刪除(表格二)
                if (lstDelData2 != null)
                {
                    foreach (var item in lstDelData2)
                    {
                        str = string.Format(
                        @" DELETE FROM st_transfer_detail_part with(ROWLOCK) WHERE within_code='0000' AND id='{0}' AND upper_sequence='{1}' AND sequence_id='{2}'",
                        item.id, item.upper_sequence, item.sequence_id);
                        sbSql.Append(str);
                    }
                }
                
                //更新轉出單主檔               
                str = string.Format(
                @" UPDATE st_transfer_mostly with(ROWLOCK) 
                SET transfer_date='{2}',handler='{3}',remark='{4}', department_id='{5}',bill_type_no='{6}',group_no='{7}',
                state='{8}',update_by='{9}',update_date=getdate(),update_count= Convert(nvarchar(5),Convert(int,update_count)+1)
                WHERE within_code='{0}' AND id='{1}'",
                within_code, headData.id, headData.transfer_date, headData.handler, headData.remark, headData.department_id, headData.bill_type_no, headData.group_no,
                headData.state, headData.update_by);
                sbSql.Append(str);
                //更新明細表一
                foreach (var item in lstDetailData1)
                {
                    if (!string.IsNullOrEmpty(item.row_status))
                    {
                        strSuit = (item.shipment_suit) ? "1" : "0";
                        lot_no = !string.IsNullOrEmpty(item.lot_no) ? item.lot_no : clsPublic.GetDeptLotNo(item.location_id, item.location_id);//自動生成批號
                        //item.row_status非空,數據有新增或修改                        
                        if (item.row_status == "EDIT")
                        {                           
                            //更新轉出單明細 少了base_unit不用更新
                            str = string.Format(
                            @" UPDATE st_transfer_detail with(Rowlock) 
                            Set goods_id='{3}',goods_name='{4}',unit='{5}',rate={6},inventory_qty={7},inventory_sec_qty={8},transfer_amount={9},location_id='{10}',carton_code='{11}',
                            lot_no='{12}',state='{13}',remark='{14}',transfers_state='{15}',account_weight={16},sec_unit='{17}',sec_qty={18},mo_id='{19}',nwt={20},gross_wt={21},package_num={22},
                            shipment_suit={23},move_location_id='{24}',move_carton_code='{25}'
                            WHERE within_code='{0}' AND id='{1}' AND sequence_id='{2}'", within_code, headData.id, item.sequence_id,
                            item.goods_id, item.goods_name, item.unit, rate, inventoryQty, inventorySecQty, item.transfer_amount, item.location_id, item.carton_code, lot_no, state, item.remark,
                            transfersState, accountWeight, item.sec_unit, item.sec_qty, item.mo_id, item.nwt, item.gross_wt, packageNum, strSuit, item.move_location_id, item.move_carton_code);
                            sbSql.Append(str);
                        }
                        else //INSERT ITEM//有項目新增
                        {
                            //組裝轉換明細,插入新增的記錄                            
                            str = string.Format(
                            @" Insert Into st_transfer_detail
                            (within_code,id,sequence_id,goods_id,goods_name,base_unit,unit,rate,inventory_qty,inventory_sec_qty,transfer_amount,location_id,carton_code,lot_no,state,remark,
                            transfers_state, account_weight, sec_unit, sec_qty, mo_id, nwt, gross_wt, package_num, shipment_suit, move_location_id, move_carton_code) Values 
                            ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}',{17},'{18}',{19},'{20}',{21},{22},{23},{24},'{25}','{26}')",
                            within_code, headData.id, item.sequence_id, item.goods_id, item.goods_name, baseUnit, item.unit, rate, inventoryQty, inventorySecQty, item.transfer_amount, item.location_id, item.carton_code, lot_no, state, item.remark,
                            transfersState, accountWeight, item.sec_unit, item.sec_qty, item.mo_id, item.nwt, item.gross_wt, packageNum, strSuit, item.move_location_id, item.move_carton_code);
                            sbSql.Append(str);
                        } //end of item add
                    } //end is edit
                } //end for

                //更新明細表二
                decimal joQty = 0, cQty = 0;
                foreach (var item in lstDetailData2)
                {
                    if (!string.IsNullOrEmpty(item.row_status))
                    {
                        if (item.row_status == "EDIT")
                        {
                            str = string.Format(
                            @" UPDATE st_transfer_detail_part with(Rowlock) 
                            SET mo_id='{4}',goods_id='{5}',jo_qty={6}, c_qty={7},con_qty={8},unit_code='{9}',sec_qty={10},sec_unit='{11}',remark='{12}',
                            location='{13}',carton_code='{14}',bom_qty={15},lot_no='{16}',inventory_qty={17},inventory_sec_qty={18}
                            WHERE within_code='{0}' AND id='{1}' AND upper_sequence='{2}' AND sequence_id='{3}'", within_code, headData.id, item.upper_sequence, item.sequence_id,
                            item.mo_id, item.goods_id, joQty, cQty, item.con_qty, item.unit_code, item.sec_qty, item.sec_unit, item.remark,
                            item.location, item.carton_code, item.bom_qty, item.lot_no, item.inventory_qty, item.inventory_sec_qty);
                        }
                        else
                        {
                            //插入明細表二
                            str = string.Format(
                            @" Insert Into st_transfer_detail_part(
                            within_code,id,upper_sequence,sequence_id,mo_id,goods_id,jo_qty,c_qty,con_qty,unit_code,remark,sec_unit,sec_qty,location,carton_code,bom_qty,lot_no,inventory_qty,inventory_sec_qty)
                            Values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},'{9}','{10}','{11}',{12},'{13}','{14}',{15},'{16}',{17},{18})",
                            within_code, headData.id, item.upper_sequence, item.sequence_id, item.mo_id, item.goods_id, joQty, cQty, item.con_qty, item.unit_code, item.remark, item.sec_unit, item.sec_qty,
                            item.location, item.carton_code, item.bom_qty, item.lot_no, item.inventory_qty, item.inventory_sec_qty);
                            sbSql.Append(str);
                        }
                        sbSql.Append(str);
                    }
                }
            }

            sbSql.Append(@" COMMIT TRANSACTION ");
            result = clsErp.ExecuteSqlUpdate(sbSql.ToString());
            sbSql.Clear();
            return result;
        }//--end of SAVE

  
        public static string GetMaxIDStock(string bill_id, int serial_len)
        {
            string result = "";
            string strSql = string.Format(@"SELECT dbo.fn_zz_sys_bill_max_separate_st('{0}',{1}) as id", bill_id, serial_len);
            result = clsErp.ExecuteSqlReturnObject(strSql); // Return value DWA25040931
            return result;
        }

        //檢查單據號是否已存在
        public static bool CheckIdIsExists(string tableName, string id)
        {
            bool result = false;
            string strSql = string.Format(@"Select id FROM {0} with(nolock) Where within_code='0000' AND id='{1}'", tableName, id);
            DataTable dt = clsErp.ExecuteSqlReturnDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = true;
            else
                result = false;
            return result;
        }

        public static string SaveAdjData(st_adjustment_mostly headData, List<st_a_subordination> lstDetailData1, string user_id)
        {
            string str = "", within_code = "0000";
            StringBuilder sbSql = new StringBuilder(" SET XACT_ABORT ON ");
            sbSql.Append(" BEGIN TRANSACTION ");
            string id = headData.id;
            string bill_id = "ST02";
            if (headData.head_status == "NEW")//全新的單據
            {
                bool id_exists = CheckIdIsExists("st_adjustment_mostly", id);
                if (id_exists)
                {
                    //已存在此單據號,重新取最大單據號
                    //取最大單號
                    headData.id = GetMaxIDStock(bill_id, 4);
                }
                //更新系統表移交單最大單號
                id = headData.id;
                string bill_Code = id.Substring(1);   //biiCode value is  DWA23090452-->WA23090452
                string year_month = id.Substring(3, 4);//2309
                string strSql_i = string.Format(
                @" INSERT INTO sys_bill_max_separate(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) 
                VALUES('0000','{0}','{1}','{2}','','','','','')", bill_id, year_month, bill_Code);
                string strSql_u = string.Format(
                @" UPDATE sys_bill_max_separate SET bill_code='{0}' 
                WHERE within_code='0000' And bill_id='{1}' And year_month='{2}' And bill_text1='' And bill_text2='' And bill_text3='' And bill_text4='' And bill_text5='' ",
                bill_Code, bill_id, year_month);
                string sql_sys_update2 = "";
                if (bill_Code.Substring(6, 4) != "0001")
                    sql_sys_update2 = strSql_u;
                else
                    sql_sys_update2 = strSql_i;
                str = sql_sys_update2;
                sbSql.Append(str);

                //生成庫存調整單               
                string update_count = "1", transfers_state = "0", node = "1", servername = "hkserver.cferp.dbo", sequence_id = "";
                decimal price = 0;
                int index;
                if (lstDetailData1.Count > 0)
                {
                    //主檔                   
                    str = string.Format(
                    @" Insert Into st_adjustment_mostly(within_code,id,department_id,date,mode,handler,remark,state,transfers_state,update_count,adjust_reason,servername,
                    create_by,create_date,update_by,update_date) VALUES
                    ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',getdate(),'{12}',getdate())",
                    within_code, headData.id, headData.department_id, headData.date, node, headData.handler, headData.remark, headData.state, transfers_state, update_count, headData.adjust_reason, servername, headData.create_by);
                    sbSql.Append(str);
                    //明細
                    index = 0;
                    foreach (var item in lstDetailData1)
                    {
                        index += 1;
                        //sequence_id = objNum.GetSequenceID(index);// index.ToString().PadLeft(4, '0')+"h"; //序號   
                        sequence_id = clsPublic.GetSequenceID(index); //序號 
                        str = string.Format(
                        @" Insert Into st_a_subordination
                        (within_code,id,sequence_id,mo_id,goods_id,location,carton_code,qty,unit,ib_amount, price,transfers_state,sec_unit,sec_qty,ib_weight,lot_no,remark) Values
                        ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}',{9},{10},'{11}','{12}',{13},{14},'{15}','{16}')",
                        within_code, headData.id, sequence_id, item.mo_id, item.goods_id, item.location, item.location, item.qty, "PCS", item.ib_amount, price, transfers_state, "KG",
                        item.sec_qty, item.ib_weight, item.lot_no, item.remark);
                        sbSql.Append(str);
                    }
                }
            }
            sbSql.Append(@" COMMIT TRANSACTION ");
            string result = clsErp.ExecuteSqlUpdateReturnString(sbSql.ToString());//保存成功返回 空格

            //保存成功，接著批準
            if (result == "")
            {               
                string active_name = "pfc_ok", ldt_check_date = "";
                //設置全局的批準日期
                ldt_check_date = clsPublic.GetDbDateTime("L");//批準日期(長日期時間)
                headData.check_date = ldt_check_date;
                result = ApproveAdjustment(headData, ldt_check_date, active_name, user_id); //保存成功返回00，失敗返回-1
            }
            else
                result = "-1" + result;
            sbSql.Clear();
            return result;
        }

        /// <summary>
        /// 移交單批準
        /// 單獨移交單畫面的批準只有一張移交單,有別于組裝轉換
        /// 批準庫存調整,更改庫存調整的批準狀態,交易的生成,庫存的更改
        /// </summary>
        /// <param name="headData"></param>       
        /// <param name="check_date"></param>
        /// <param name="user_id"></param>
        /// <returns>返回字串00,表示成功</returns>     
        public static string ApproveAdjustment(st_adjustment_mostly headData, string check_date, string active_name, string user_id)
        {
            //更新移交單相關庫存
            string window_id = "";
            string result = SetAdjustmentStBusiness(headData.id, check_date, active_name, "JO", user_id, window_id); //active_name:"pfc_ok","pfc_unok"

            if (result.Substring(0, 2) == "00") // SetReturnRechangeStBusiness()執行成功
            {
                bool is_pfc_ok = (active_name == "pfc_ok") ? true : false;
                string checkDate = is_pfc_ok ? check_date : "";
                string checkBy = is_pfc_ok ? user_id : "";
                string state = is_pfc_ok ? "1" : "0";
                string strSql = string.Format(
                @" Update st_adjustment_mostly with(Rowlock) 
                    SET check_date=(Case When '{2}'<>'' Then '{2}' Else null End), check_by='{3}',
                        update_date=(Case When '{2}'<>'' Then '{2}' Else getdate() End),update_by='{4}',state='{5}' 
                    WHERE within_code='{0}' And id='{1}'", "0000", headData.id, checkDate, checkBy, user_id, state);
                result = clsErp.ExecuteSqlUpdateReturnString(strSql);
                result = (result == "") ? "00" : "-1" + result;
            }
            return result;
        }

        /// <summary>
        /// 生成調整單交易數據(返回值為字符串,字串前兩位:-1代表失敗;00:成功)
        /// </summary>
        /// <param name="as_id">移交單據編號</param>
        /// <param name="as_check_date">當前批準日期時間</param>
        /// <param name="as_active_name">pfc_ok/pfc_unok</param>
        /// <param name="as_bill_type">"JO:移交單"</param>
        /// <param name="as_user_id"></param>
        /// <returns></returns>
        public static string SetAdjustmentStBusiness(string as_id, string as_check_date, string as_active_name, string as_bill_type, string as_user_id, string as_window_id)
        {
            string result = "00";//strStatus字符串前兩位:-1代表失敗;00:成功
            string str = "", strSql = "", within_code = "0000";

            string ls_id, ls_goods_id, ls_error = "", ls_check_date = "";
            string ls_mode, ls_location, ls_carton_code, ls_lot_no, ls_unit, ls_sec_unit, ls_sequence_id;
            decimal ldc_qty, ldc_sec_qty, ldc_stock_qty, ldc_stock_sec_qty, ldc_adjust_qty, ldc_adjust_sec_qty;
            int ll_count;
            ls_id = as_id;
            StringBuilder sbSql = new StringBuilder(" SET XACT_ABORT ON ");
            sbSql.Append(" BEGIN TRANSACTION ");
            DataTable dt = new DataTable();
            if (as_active_name == "pfc_ok")
            {
                ls_check_date = as_check_date;               
                //无条件控制负数的出现
                result = pubFun.wf_check_inventory_qty(as_id, "w_st_adjustment");//调整
                if (result.Substring(0, 2) == "-1")
                {
                    return result;
                }
                DataTable dtCount = new DataTable();
                strSql = string.Format(
                @"Select A.mode,B.sequence_id,B.goods_id,B.location,B.carton_code,B.lot_no,B.unit,B.sec_unit,B.qty,B.sec_qty
                From st_adjustment_mostly A with(nolock), st_a_subordination B with(nolock)
                Where A.within_code=B.within_code And A.id=B.id And A.within_code='{0}' And A.id='{1}'", within_code, ls_id);
                dt = clsErp.ExecuteSqlReturnDataTable(strSql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ls_mode = dt.Rows[i]["mode"].ToString();
                    ls_sequence_id = dt.Rows[i]["sequence_id"].ToString();
                    ls_goods_id = dt.Rows[i]["goods_id"].ToString();
                    ls_location = dt.Rows[i]["location"].ToString();
                    ls_carton_code = dt.Rows[i]["carton_code"].ToString();
                    ls_lot_no = dt.Rows[i]["lot_no"].ToString();
                    ls_unit = dt.Rows[i]["unit"].ToString();
                    ls_sec_unit = dt.Rows[i]["sec_unit"].ToString();
                    ldc_qty = decimal.Parse(dt.Rows[i]["qty"].ToString());
                    ldc_sec_qty = decimal.Parse(dt.Rows[i]["sec_qty"].ToString());
                    ll_count = 0;
                    strSql = string.Format(
                    @"Select Count(1) as cnt From st_business_record WITH(NOLOCK) 
                    Where within_code='{0}' And id ='{1}' And sequence_id='{2}' And action_id='03'",
                    within_code, ls_id, ls_sequence_id);
                    dtCount = clsErp.ExecuteSqlReturnDataTable(strSql);
                    ll_count = int.Parse(dtCount.Rows[0]["cnt"].ToString());

                    //***批準***
                    if (as_active_name.ToLower() == "pfc_ok" && ll_count == 0)
                    {
                        if (ls_lot_no.Length > 0)
                        {
                            strSql = string.Format(
                            @"Select qty, sec_qty From st_details_lot with(nolock)
                            Where within_code='{0}' And location_id='{1}' And carton_code='{2}' And goods_id='{3}' And lot_no='{4}'",
                            within_code, ls_location, ls_carton_code, ls_goods_id, ls_lot_no);
                        }
                        else
                        {
                            strSql = string.Format(
                            @"Select Sum(Isnull(qty, 0)) as qty, Sum(Isnull(sec_qty, 0)) as sec_qty                           
                            From st_details_lot
                            Where within_code='{0}' And location_id='{1}' And carton_code='{2}' And goods_id='{3}' And lot_no='{4}'",
                            within_code, ls_location, ls_carton_code, ls_goods_id, ls_lot_no);
                        }
                        dtCount = clsErp.ExecuteSqlReturnDataTable(strSql);
                        if (dtCount.Rows.Count > 0)
                        {
                            ldc_stock_qty = decimal.Parse(dtCount.Rows[0]["qty"].ToString());
                            ldc_stock_sec_qty = decimal.Parse(dtCount.Rows[0]["sec_qty"].ToString());
                        }
                        else
                        {
                            ldc_stock_qty = 0;
                            ldc_stock_sec_qty = 0;
                        }
                        //--start 转化为当前单位
                        strSql = string.Format(
                        @"Select Top 1 DBO.FN_CHANGE_UNITBYCV('{0}','{1}','{2}','{3}','','','*') as stock_qty,
									   DBO.fn_change_units_sec('{0}','{1}', '','{4}','{5}') as stock_sec_qty
                          From sysobjects", within_code, ls_goods_id, ls_unit, ldc_stock_qty, ls_sec_unit, ldc_stock_sec_qty);
                        dtCount = clsErp.ExecuteSqlReturnDataTable(strSql);
                        if (!string.IsNullOrEmpty(dtCount.Rows[0]["stock_qty"].ToString()))
                            ldc_stock_qty = decimal.Parse(dtCount.Rows[0]["stock_qty"].ToString());
                        else
                            ldc_stock_qty = 0;
                        if (!string.IsNullOrEmpty(dtCount.Rows[0]["stock_sec_qty"].ToString()))
                            ldc_stock_sec_qty = decimal.Parse(dtCount.Rows[0]["stock_sec_qty"].ToString());
                        else
                            ldc_stock_sec_qty = 0;
                        //--end 转化为当前单位
                        if (ls_mode == "1")//--在原数量上进行调整
                        {
                            ldc_adjust_qty = ldc_qty;
                            ldc_adjust_sec_qty = ldc_sec_qty;
                        }
                        else
                        {
                            ldc_adjust_qty = ldc_stock_qty - ldc_qty;
                            ldc_adjust_sec_qty = ldc_stock_sec_qty - ldc_sec_qty;
                        }
                        //--
                        str = string.Format(
                        @" Insert Into st_business_record
                           (within_code,id,sequence_id,goods_id,goods_name,unit,action_time,action_id,ii_qty,sec_qty,sec_unit,
                           ii_location_id, ii_code, check_date, 
                           ib_qty, qty, lot_no, mo_id, dept_id, servername)
                        Select B.within_code,B.id,B.sequence_id,B.goods_id,B.goods_name,B.unit,A.date,'03', {4} , {5} ,B.sec_unit,
                               B.location,B.carton_code,  '{6}',
                               dbo.FN_CHANGE_UNITBYCV(B.within_code, B.goods_id, B.unit, 1,'','','*') as ib_qty,
                               Round(dbo.FN_CHANGE_UNITBYCV(B.within_code, B.goods_id, B.unit, {7} ,'','','/'), 4) as qty,
                               B.lot_no,B.mo_id,A.department_id,A.servername
                        FROM st_adjustment_mostly A With(nolock), st_a_subordination B With(nolock)
                        WHERE A.within_code=B.within_code And A.id=B.id And B.within_code='{0}' And B.id='{1}' And B.sequence_id='{2}' And B.goods_id='{3}'",
                        within_code, ls_id, ls_sequence_id, ls_goods_id, ldc_adjust_qty, ldc_adjust_sec_qty, ls_check_date, ldc_adjust_qty);
                        sbSql.Append(str);
                    } //end of if pfc_ok
                    //***批準結束***
                }  //end of for

                sbSql.Append(@" COMMIT TRANSACTION ");
                result = clsErp.ExecuteSqlUpdateReturnString(sbSql.ToString());                
                sbSql.Clear();
                if (result != "")
                {
                    result = "-1" + "批準失敗!<" + result + ">";
                    return result;
                }
                else
                    result = "00";

                //--统一更新库存
                if (as_active_name.ToLower() == "pfc_ok")
                {
                    result = pubFun.of_update_st_details("I", "03", ls_id, "*", ls_check_date, ls_error);
                    if (result.Substring(0, 2) == "-1")
                    {
                        result = result + "\r\n" + "庫存數據保存失败![统一更新库存]+" + "\r\n" + "<" + as_active_name + ">(st_details)" + "\r\n";
                        return result;
                    }
                    else
                        result = "00";
                }

            } //end fo if (as_active_name == "pfc_ok" || as_active_name == "pfc_unok")            
            return result;
        }//--end SetAdjustmentStBusiness()


        /// <summary>
        /// 批準/反批準,生成組裝單,移交單的交易,庫存更新等(失敗返回的字串前兩位是"-1")
        /// </summary>
        /// <param name="id">轉出單號</param>        
        /// <param name="user_id">當前用戶</param>
        /// <param name="approve_type">approve_type:1--批準;0--反批準</param>
        /// <returns>返回字串為空,表示成功</returns> 
        public static string Approve(TransferInHead head, string user_id, string approve_type)
        {
            string result = "", sqlUpdate = "", gs_company = "0000", sql_f = "";
            string active_name = (approve_type == "1") ? "批準" : "反批準";
            string is_active_name = (approve_type == "1") ? "pfc_ok" : "pfc_unok";
            string ls_id, ls_location_id, ls_move_location, ls_move_carton_code, ls_sequence_id, ls_mo_id, ls_shipment_suit, ls_error = "";
            string ls_goods_id, ls_unit_code, ls_department_id, ls_servername, ls_F0_goods, ls_upper_sequence, ls_carton_code, ls_obligate_mo_id;
            string ldt_mo_max_date = "", ldt_check_date = "", ldt_transfer_date = "", ldt_actual_bto_hk_date = "";
            int ll_count = 0, ll_count_order = 0;
            decimal ldc_qty, ldc_sec_qty, ldc_gross_wt, ldc_package_num, ldc_wt_sec_qty;
            DataTable dt = new DataTable();
            DataTable dtFind = new DataTable();

            //--
            ls_id = head.id;
            ldt_check_date = clsPublic.GetDbDateTime("L");//批準日期(長日期時間)
            ldt_check_date = (is_active_name == "pfc_ok") ? ldt_check_date : head.check_date;
            ldt_transfer_date = head.transfer_date;
            ls_department_id = head.department_id;
            ls_servername = "hkserver.cferp.dbo";
            //--

            //--start 批準
            if (is_active_name == "pfc_ok" || is_active_name == "pfc_unok")
            {
                //設置全局的批準日期
                sql_f = string.Format(
                @"Select a.location_id,a.move_location_id,a.move_carton_code,a.sequence_id,a.mo_id,IsNull(a.shipment_suit,'0') as shipment_suit,a.goods_id,a.transfer_amount,a.sec_qty,a.unit
                From st_transfer_detail a With(nolock) Where a.within_code='{0}' And a.id='{1}' Order by a.id,a.sequence_id", gs_company, ls_id);
                dt = clsErp.ExecuteSqlReturnDataTable(sql_f);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ls_location_id = dt.Rows[i]["location_id"].ToString();
                    ls_move_location = dt.Rows[i]["move_location_id"].ToString();
                    ls_move_carton_code = dt.Rows[i]["move_carton_code"].ToString();
                    ls_sequence_id = dt.Rows[i]["sequence_id"].ToString();
                    ls_mo_id = dt.Rows[i]["mo_id"].ToString();
                    ls_shipment_suit = dt.Rows[i]["shipment_suit"].ToString();
                    ls_goods_id = dt.Rows[i]["goods_id"].ToString();
                    ldc_qty = decimal.Parse(dt.Rows[i]["transfer_amount"].ToString());
                    ldc_sec_qty = decimal.Parse(dt.Rows[i]["sec_qty"].ToString());
                    ls_unit_code = dt.Rows[i]["unit"].ToString();
                    ls_F0_goods = ls_goods_id;
                    if (is_active_name == "pfc_unok")
                    {
                        //先清空销售明细的数据
                        sqlUpdate = string.Format(
                        @"Update B WITH(ROWLOCK)
                        Set B.actual_bto_hk_date = Null, B.actual_bto_hk_qty = Null
                        From so_order_manage A, so_order_details B
                        Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state not in('2','V')
						      And A.within_code='{0}' And B.mo_id='{1}' And B.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id);
                        result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                        if (result == "")
                            result = "00";
                        else
                        {
                            result = RetrunResult(result, active_name, "(so_order_details)");
                            return result;
                        }
                        // SetNull(ldt_mo_max_date) //2025/05/08 修改 Convert(nvarchar(10),Max(Isnull(check_date, create_date)),121) As max_date 
                        sql_f = string.Format(
                        @"Select Convert(nvarchar(19),Max(Isnull(check_date, create_date)),121) As max_date
                        From st_transfer_mostly A with(nolock), st_transfer_detail B with(nolock)
                        Where A.within_code = B.within_code And A.id = B.id  And A.state = '1'
                              And B.goods_id ='{0}' And B.mo_id ='{1}' And A.id<>'{2}'", ls_goods_id, ls_mo_id, ls_id);
                        dtFind = clsErp.ExecuteSqlReturnDataTable(sql_f);
                        ldt_mo_max_date = dtFind.Rows[0]["max_date"].ToString();
                    }
                    //---
                    ldt_actual_bto_hk_date = (is_active_name == "pfc_ok") ? ldt_check_date : ldt_mo_max_date;
                    sql_f = string.Format(
                    @"SELECT Count(1) as cnt FROM st_transfer_detail_part WITH(NOLOCK) WHERE within_code='{0}' AND id='{1}' And upper_sequence='{2}'", gs_company, ls_id, ls_sequence_id);
                    ll_count = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                    //--start 20130412 wangwei 增加回写销售订单中，实际回港日期、实际回港数量
                    //--20130419 wangwei 此处是更新非套件的实际回港数据，将此段代码提前到找FO编号前面
                    //--非套件
                    if (ll_count < 1 || ls_goods_id.Substring(0, 3) != "F0-")
                    {
                        ll_count_order = 0;
                        sql_f = string.Format(
                        @"Select Count(1) as ll_cnt                        
                        From so_order_manage A WITH(NOLOCK),so_order_details B WITH(NOLOCK),so_order_bom C WITH(NOLOCK)
                        Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state not in('2','V')
					        And B.within_code=C.within_code And B.id=C.id And B.ver=C.ver And B.sequence_id=C.upper_sequence
                            And A.within_code='{0}' And B.mo_id='{1}' And C.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id);
                        ll_count_order = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count_order > 0)
                        {
                            //----非套件，批准、反批准时写销售订单实际回港数据
                            sqlUpdate = string.Format(
                            @"Update C WITH(ROWLOCK)
                            Set C.actual_bto_hk_date= (Case When('{3}'='pfc_ok') Then '{4}' Else '{5}' End),
								C.actual_bto_hk_qty=ISNULL(C.actual_bto_hk_qty,0)+dbo.FN_CHANGE_UNITS(C.within_code,C.goods_id,'{6}',B.goods_unit,Isnull({7},0)) * (Case When('{3}'='pfc_ok') Then 1 When('{3}'='pfc_unok') Then -1 Else 0 End),
								C.is_backhk = (Case When('{3}'='pfc_ok') Then '1' Else '0' End) --//--将散件的回港标志加入到此处
					        From so_order_manage A,so_order_details B,so_order_bom C
                            Where A.within_code = B.within_code And A.id = B.id And A.ver = B.ver And A.state not in('2','V')
						        And B.within_code = C.within_code And B.id = C.id And B.ver = C.ver And B.sequence_id = C.upper_sequence
                                And A.within_code='{0}' And B.mo_id='{1}' And C.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id, is_active_name, ldt_check_date, ldt_mo_max_date, ls_unit_code, ldc_qty);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(so_order_bom)");
                                return result;
                            }
                        }
                        //--得到F0编号
                        sql_f = string.Format(
                        @"Select B.goods_id                       
                        From so_order_manage A WITH(ROWLOCK),
                            so_order_details B WITH(ROWLOCK),
						    so_order_bom C WITH(ROWLOCK)
                        Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver
                              And B.within_code=C.within_code And B.id=C.id And B.ver=C.ver And B.sequence_id=C.upper_sequence
                              And A.state Not In('2','V') And Isnull(C.primary_key,'0')='1'
                              And A.within_code='{0}' And B.mo_id='{1}' And C.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id);
                        ls_F0_goods = clsErp.ExecuteSqlReturnObject(sql_f);

                        //--如果是非套件，先扣除转出仓的库存，判断方法改成判断明细是否有资料2011-03-01
                        if (is_active_name == "pfc_ok")
                        {
                            sqlUpdate = string.Format(
                            @"Insert Into st_business_record(within_code,id,goods_id,goods_name,unit,base_unit,rate,action_time,action_id,ii_qty,
                                     ii_location_id, ii_code, check_date, sequence_id, lot_no, mo_id, ib_qty, qty, dept_id, sec_unit, sec_qty,
                                     wt_sec_qty, pack_qty, servername, shelf)
                            Select within_code, id, goods_id, goods_name, unit, base_unit, rate,'{3}',
								        '48',--//转出单(-)
								        transfer_amount,location_id,carton_code,'{4}',sequence_id,lot_no,mo_id,
								        dbo.FN_CHANGE_UNITBYCV(within_code, goods_id, unit, 1,'','','*'),
								        Round(dbo.FN_CHANGE_UNITBYCV(within_code, goods_id,unit,transfer_amount,'','','/'), 4),'{5}',sec_unit,sec_qty,
								        gross_wt,package_num,'{6}',shelf
                            From st_transfer_detail 
                            Where within_code='{0}' And id='{1}' And sequence_id='{2}'", gs_company, ls_id, ls_sequence_id, ldt_transfer_date, ldt_check_date, ls_department_id, ls_servername);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(st_business_record)");
                                return result;
                            }
                            //--更新库存
                            result = pubFun.of_update_st_details("I", "48", ls_id, ls_sequence_id, ldt_check_date, ls_error);
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = RetrunResult(result, active_name, "(st_details)");
                                return result;
                            }
                            else
                            {
                                result = "00";
                            }

                            //start 20131018 将交易表中的批号回写过来,因为流动仓的批号要与现在的实际交易中的批号一样
                            sqlUpdate = string.Format(
                            @"Update A WITH(ROWLOCK)
                            Set A.lot_no = B.lot_no
                            From st_transfer_detail A, st_business_record B
                            Where A.within_code = B.within_code And A.id = B.id And A.sequence_id = B.sequence_id And B.action_id ='48'
                                  And A.within_code='{0}' And A.id='{1}' And A.sequence_id='{2}' And Isnull(A.lot_no,'')=''", gs_company, ls_id, ls_sequence_id);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(st_transfer_detail)");
                                return result;
                            }
                            //end 20131018
                        }// --end if(is_active_name=="pfc_ok")
                    } //--end of IF --非套件

                    //--套件，F0出货
                    if (ll_count > 0 && ls_goods_id.Substring(0, 3) == "F0-")
                    {
                        //--start 20130412 wangwei 增加回写销售订单中，实际回港日期、实际回港数量
                        ll_count_order = 0;
                        sql_f = string.Format(
                        @"Select Count(1) as cnt                        
                        From so_order_manage A WITH(NOLOCK),so_order_details B WITH(NOLOCK)
                        Where A.within_code = B.within_code And A.id = B.id And A.ver = B.ver And A.state not in('2','V')
						      And A.within_code ='{0}' And B.mo_id ='{1}' And B.goods_id ='{2}'", gs_company, ls_mo_id, ls_goods_id);
                        ll_count_order = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count_order > 0)
                        {
                            //--F0在写sales bom时，将批准和反批准写到一起
                            sqlUpdate = string.Format(
                            @"Update C WITH(ROWLOCK)
                            Set C.actual_bto_hk_date=(Case When('{3}'='pfc_ok') Then '{4}' Else '{5}' End),
							    C.actual_bto_hk_qty=Isnull(C.actual_bto_hk_qty,0) + Isnull(C.dosage,0) * Dbo.FN_CHANGE_UNITS(B.within_code,B.goods_id,'{6}',B.goods_unit,Isnull({7},0)) * (Case When('{3}'='pfc_ok') Then 1 When('{3}'='pfc_unok') Then -1 Else 0 End)
					        From so_order_manage A,
								 so_order_details B,
                                 so_order_bom C
                            Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state not in('2','V')
							        And B.within_code=C.within_code And B.id=C.id And B.ver=C.ver And B.sequence_id=C.upper_sequence
                                    And B.within_code='{0}' And B.mo_id='{1}' And B.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id, is_active_name, ldt_check_date, ldt_mo_max_date, ls_unit_code, ldc_qty);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(so_order_bom)(2)");
                                return result;
                            }
                        }
                    }
                    //--start更新生产计划单的数量
                    if (ls_goods_id.Substring(0, 3) == "F0-")
                    {
                        ll_count_order = 0;
                        sql_f = string.Format(
                        @"Select Count(1) as cnt                        
                         From jo_bill_mostly A WITH(NOLOCK),jo_bill_goods_details B WITH(NOLOCK)
                         Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state Not In('2','V')
                               And A.within_code='{0}' And A.mo_id='{1}' And B.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id);
                        ll_count_order = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count_order > 0)
                        {
                            sqlUpdate = string.Format(
                            @"Update B WITH(ROWLOCK)
                            Set B.c_qty=Isnull(B.c_qty,0) + Dbo.FN_CHANGE_UNITS(B.within_code,B.goods_id,'{3}',B.goods_unit,Isnull({4},0))*(Case When('{5}'='pfc_ok') Then 1 When('{5}'='pfc_unok') Then -1 Else 0 End),
							    B.c_qty_ok =Isnull(B.c_qty_ok,0) + Dbo.FN_CHANGE_UNITS(B.within_code, B.goods_id,'{6}', B.goods_unit,Isnull({4},0)) * (Case When('{5}'='pfc_ok') Then 1 When('{5}'='pfc_unok') Then -1 Else 0 End),
							    B.c_sec_qty =Isnull(B.c_sec_qty,0) + Isnull({7},0) * (Case When('{5}'='pfc_ok') Then 1 When('{5}'='pfc_unok') Then -1 Else 0 End),
							    B.c_sec_qty_ok = Isnull(B.c_sec_qty_ok,0) + Isnull({7},0) * (Case When('{5}'='pfc_ok') Then 1 When('{5}'='pfc_unok') Then -1 Else 0 End),
							    B.f_complete_date = (Case When('{5}'='pfc_ok') Then '{8}' Else null End)
					        From jo_bill_mostly A, jo_bill_goods_details B
                            Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state not in('2','V')
							      And A.within_code='{0}' And A.mo_id='{1}' And B.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id, ls_unit_code, ldc_qty, is_active_name, ls_unit_code, ldc_sec_qty, ldt_transfer_date);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(jo_bill_goods_details)(1)");
                                return result;
                            }
                        }
                    }
                    //--end 更新生产计划单的数量

                    if (is_active_name == "pfc_ok")
                    {
                        //--start 20130419 wangwei 当批准时，要判断销此页数是否全部回港了，如果是，就更新销售明细表中的回港
                        //--要先判断是否存在这样的数据，才更新
                        ll_count = 0;
                        sql_f = string.Format(
                        @"Select Count(1) as cnt                        
                        From so_order_manage A WITH(NOLOCK),so_order_details B WITH(NOLOCK)
                        Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state Not In('2','V') And B.within_code='{0}' And B.mo_id='{1}'
                             And (Not Exists(Select 1 From so_order_bom C Where B.within_code=C.within_code And B.id=C.id And B.ver=C.ver And B.sequence_id=C.upper_sequence
                                             And B.order_qty * Isnull(C.dosage,0) >isnull(C.actual_bto_hk_qty,0)))", gs_company, ls_mo_id);
                        ll_count = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count > 0)
                        {
                            sqlUpdate = string.Format(
                            @"Update B WITH(ROWLOCK)
                            Set B.actual_bto_hk_date =(Select Max(C1.actual_bto_hk_date) From so_order_bom C1 Where B.within_code=C1.within_code And B.id=C1.id And B.ver=C1.ver And B.sequence_id=C1.upper_sequence),
							    B.actual_bto_hk_qty =(Select C2.actual_bto_hk_qty/Nullif(C2.dosage, 0) From so_order_bom C2
                                                      Where B.within_code=C2.within_code And B.id=C2.id And B.ver=C2.ver And B.sequence_id=C2.upper_sequence And Isnull(C2.primary_key,'')='1' )                                                     
					        From so_order_manage A, so_order_details B
                            Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.state Not In('2','V') And B.within_code='{0}' And B.mo_id='{1}'", gs_company, ls_mo_id);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(so_order_details)(2)");
                                return result;
                            }
                        }
                        //--
                        sqlUpdate = string.Format(
                        @"INSERT INTO ST_BUSINESS_RECORD(WITHIN_CODE, ID, GOODS_ID, GOODS_NAME, UNIT, BASE_UNIT, RATE, ACTION_TIME, ACTION_ID, II_QTY,
                                II_LOCATION_ID, II_CODE, CHECK_DATE, SEQUENCE_ID, LOT_NO, mo_id, IB_QTY, QTY, dept_id, sec_unit, sec_qty,
                                wt_sec_qty, pack_qty, servername, shelf)
                        SELECT WITHIN_CODE, ID, GOODS_ID, GOODS_NAME, UNIT, BASE_UNIT, RATE,'{3}',
								'47',--//转出单(+)
								TRANSFER_AMOUNT,Isnull(move_location_id,'ZZZ'),Isnull(move_location_id,'ZZZ'),
								'{4}',SEQUENCE_ID,LOT_NO,mo_id,
							    DBO.FN_CHANGE_UNITBYCV(WITHIN_CODE, GOODS_ID,UNIT, 1,'','','*'),
							    ROUND(DBO.FN_CHANGE_UNITBYCV(WITHIN_CODE,GOODS_ID,UNIT,TRANSFER_AMOUNT,'','','/'),4),'{5}',sec_unit,sec_qty,
								gross_wt,package_num,'{6}',shelf
                        FROM  ST_TRANSFER_DETAIL
                        WHERE WITHIN_CODE='{0}' AND ID='{1}' AND SEQUENCE_ID='{2}'", gs_company, ls_id, ls_sequence_id, ldt_transfer_date, ldt_check_date, ls_department_id, ls_servername);
                        result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                        if (result == "")
                            result = "00";
                        else
                        {
                            result = RetrunResult(result, active_name, "(st_business_record)(2)");
                            return result;
                        }
                        //--更新库存
                        result = pubFun.of_update_st_details("I", "47", ls_id, ls_sequence_id, ldt_check_date, ls_error);
                        if (result.Substring(0, 2) == "-1")
                        {
                            result = RetrunResult(result, active_name, "(st_details)");
                            return result;
                        }
                        else
                        {
                            result = "00";
                        }
                    }// enf of pfc_ok

                    if (is_active_name == "pfc_unok")
                    {
                        ll_count_order = 0;
                        sql_f = string.Format(
                        @"Select Count(1) as cnt                        
                        From st_business_record WITH(NOLOCK)
                        Where within_code ='{0}' And id='{1}' And sequence_id='{2}' And action_id In('47','48')", gs_company, ls_id, ls_sequence_id);
                        ll_count_order = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count_order > 0)
                        {
                            //先更新库存,再删除交易数据
                            result = pubFun.of_update_st_details("D", "48", ls_id, ls_sequence_id, ldt_check_date, ls_error);
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = RetrunResult(result, active_name, "(st_details)");
                                return result;
                            }
                            else
                            {
                                result = "00";
                            }

                            //先更新库存,再删除交易数据
                            result = pubFun.of_update_st_details("D", "47", ls_id, ls_sequence_id, ldt_check_date, ls_error);
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = RetrunResult(result, active_name, "(st_details)");
                                return result;
                            }
                            else
                            {
                                result = "00";
                            }
                            sqlUpdate = string.Format(
                            @"Delete From st_business_record WITH(ROWLOCK)
                              Where within_code='{0}' And id='{1}' And sequence_id='{2}' And action_id In('47','48')", gs_company, ls_id, ls_sequence_id);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(st_business_record)");
                                return result;
                            }
                        }
                    }// end of pfc_unok
                } // end of for Loop

                //--如果是套件出货，扣除Sales Bom的库存  2010-05-19
                sql_f = string.Format(
                @"Select b.sequence_id,b.upper_sequence,b.con_qty,b.goods_id,b.location,b.carton_code,b.mo_id as obligate_mo_id,a.mo_id,
                (Case When a.gross_wt-a.sec_qty>0 Then a.gross_wt-a.sec_qty Else 0 End) as gross_wt,Isnull(a.package_num,0) as package_num
                From st_transfer_detail a with(nolock),st_transfer_detail_part b with(nolock)
                Where a.id=b.id And a.sequence_id=b.upper_sequence And b.within_code='{0}' And b.id='{1}'", gs_company, ls_id);
                dt = clsErp.GetDataTable(sql_f);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ls_sequence_id = dt.Rows[i]["sequence_id"].ToString();
                    ls_upper_sequence = dt.Rows[i]["upper_sequence"].ToString();
                    ldc_qty = decimal.Parse(dt.Rows[i]["con_qty"].ToString());
                    ls_goods_id = dt.Rows[i]["goods_id"].ToString();
                    ls_location_id = dt.Rows[i]["location"].ToString();
                    ls_carton_code = dt.Rows[i]["carton_code"].ToString();
                    ls_obligate_mo_id = dt.Rows[i]["obligate_mo_id"].ToString();
                    ls_mo_id = dt.Rows[i]["mo_id"].ToString();
                    ldc_gross_wt = clsPublic.ReturnFloat2(dt.Rows[i]["gross_wt"].ToString());
                    ldc_package_num = clsPublic.ReturnFloat2(dt.Rows[i]["package_num"].ToString());
                    if (is_active_name == "pfc_ok")
                    {
                        //--只有不存在才增加，防同步冲突jeff 2011-03-21
                        sql_f = string.Format(
                        @"Select Count(1) as cnt FROM st_business_record WITH(NOLOCK) 
                        Where within_code='{0}' And id ='{1}' And action_id='36' And sequence_id='{2}' And goods_id='{3}'", gs_company, ls_id, ls_sequence_id, ls_goods_id);
                        ll_count = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count == 0)
                        {
                            ll_count_order = 0;
                            sql_f = string.Format(
                            @"Select count(1) as cnt					        
					        From so_order_manage a WITH (NOLOCK),
								 so_order_details b WITH (NOLOCK),
								 so_order_bom c
					        Where a.within_code=b.within_code And a.id=b.id And a.ver=b.ver 
								  And b.within_code=c.within_code And b.id=c.id And b.ver=c.ver And b.sequence_id=c.upper_sequence
								  And a.state Not In ('2','V')  And b.state Not In('2','V') And c.primary_key='1'
								  And a.within_code='{0}' And b.mo_id='{1}' And c.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id);
                            ll_count_order = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                            //--暂时采用的方法是，毛重：全部放在主件上，包数：主件和配件都一样	
                            ldc_wt_sec_qty = (ll_count_order > 0) ? ldc_gross_wt : ldc_gross_wt;
                            //--插入库存交易表
                            sqlUpdate = string.Format(
                            @"INSERT INTO st_business_record(within_code,id,goods_id,goods_name,unit,action_time,action_id,ii_qty,ii_location_id,
									ii_code,rate,sequence_id,check_date,ib_qty,qty,mo_id,lot_no,sec_qty,sec_unit,pack_qty,wt_sec_qty,servername)
					        SELECT b.within_code,b.id,b.goods_id,b.goods_name,b.unit_code,a.transfer_date,
							        '36',--//转出单(Sales Bom)
							        Abs(b.con_qty),b.location,b.carton_code,0 as swit_rate,b.sequence_id,'{4}',
							        Abs(dbo.FN_CHANGE_UNITBYCV(b.within_code,b.goods_id,b.unit_code,1,'','','*')),
							        Abs(round(dbo.FN_CHANGE_UNITBYCV(b.within_code,b.goods_id,b.unit_code,b.con_qty,'','','/'),4)),
							        b.mo_id,b.lot_no,Abs(b.sec_qty),b.sec_unit,{5},abs(b.sec_qty) +{6},'{7}'
					        FROM 	st_transfer_mostly a,
								    st_transfer_detail_part b
					        Where 	a.within_code=b.within_code And a.id=b.id And Isnull(b.location,'')<>'' And a.within_code='{0}'
								    And a.id ='{1}' And b.upper_sequence ='{2}' And b.sequence_id='{3}'",
                            gs_company, ls_id, ls_upper_sequence, ls_sequence_id, ldt_check_date, ldc_package_num, ldc_wt_sec_qty, ls_servername);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(st_business_record)(4)");
                                return result;
                            }
                            //--更新库存
                            result = pubFun.of_update_st_details("I", "36", ls_id, ls_sequence_id, ldt_check_date, ls_error);
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = RetrunResult(result, active_name, "(st_details)");
                                return result;
                            }
                            else
                            {
                                result = "00";
                            }
                            //start 将交易表中的批号回写过来,因为流动仓的批号要与现在的实际交易中的批号一样
                            sqlUpdate = string.Format(
                            @"Update A WITH(ROWLOCK)
					        Set	A.lot_no = B.lot_no
					        From st_transfer_detail_part A,st_business_record B
					        Where A.within_code = B.within_code And A.id = B.id And A.sequence_id = B.sequence_id And B.action_id ='36'
								  And A.within_code='{0}' And A.id='{1}' And A.upper_sequence='{2}' And A.sequence_id='{3}'  And Isnull(A.lot_no,'')=''",
                            gs_company, ls_id, ls_upper_sequence, ls_sequence_id);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(st_transfer_detail_part)(lot_no)");
                                return result;
                            }
                            //end 
                        }//--enf if (ll_count == 0)

                    }// end if(is_active_name == "pfc_ok")  

                    //--
                    if (is_active_name == "pfc_unok")
                    {
                        ll_count = 0;
                        sql_f = string.Format(
                        @"Select Count(1) as cnt                        
                        FROM st_business_record WITH(NOLOCK)
                        Where within_code='{0}' And id='{1}' And action_id='36' And sequence_id='{2}' And goods_id='{3}'", gs_company, ls_id, ls_sequence_id, ls_goods_id);
                        ll_count = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                        if (ll_count > 0)
                        {
                            //先更新库存,再删除交易数据
                            result = pubFun.of_update_st_details("D", "36", ls_id, ls_sequence_id, ldt_check_date, ls_error);
                            if (result.Substring(0, 2) == "-1")
                            {
                                result = RetrunResult(result, active_name, "(st_details)");
                                return result;
                            }
                            else
                            {
                                result = "00";
                            }
                            //--
                            sqlUpdate = string.Format(
                            @"Delete FROM st_business_record WITH(ROWLOCK)
                            Where within_code ='{0}' And id ='{1}' And action_id ='36' And sequence_id='{2}' And goods_id ='{3}'",
                            gs_company, ls_id, ls_sequence_id, ls_goods_id);
                            result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                            if (result == "")
                                result = "00";
                            else
                            {
                                result = RetrunResult(result, active_name, "(st_business_record)(5)");
                                return result;
                            }
                        }
                    }
                    //--
                    sqlUpdate = string.Format(
                    @"Update C WITH(ROWLOCK)
                    Set C.is_backhk = (Case When('{3}'='pfc_ok') Then '1' Else '0' End)
			        From so_order_manage a ,
						so_order_details b,
                        so_order_bom C
                    Where a.within_code = b.within_code And a.id = b.id And a.ver = b.ver And A.state Not In('2','V')
                        And b.within_code =C.within_code And b.id=C.id And b.ver=C.ver And b.sequence_id=C.upper_sequence
                        And a.within_code ='{0}' And b.mo_id='{1}' And C.goods_id='{2}'", gs_company, ls_mo_id, ls_goods_id, is_active_name);
                    result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                    if (result == "")
                        result = "00";
                    else
                    {
                        result = RetrunResult(result, active_name, "(so_order_bom)(3)");
                        return result;
                    }

                    //--更新库存预留表2010-04-22
                    sql_f = string.Format(@"Select mo_id From st_transfer_detail Where within_code='{0}' And id='{1}' And sequence_id='{2}'", gs_company, ls_id, ls_upper_sequence);
                    ls_mo_id = clsErp.ExecuteSqlReturnObject(sql_f);
                    ll_count = 0;
                    sql_f = string.Format(
                    @"Select Count(1) as cnt From mrp_st_details_lot WITH(NOLOCK)
                    Where within_code='{0}' And mo_id='{1}' And obligate_mo_id='{2}' And location_id='{3}' And carton_code='{4}' And goods_id='{5}'",
                    gs_company, ls_mo_id, ls_obligate_mo_id, ls_location_id, ls_carton_code, ls_goods_id);
                    ll_count = int.Parse(clsErp.ExecuteSqlReturnObject(sql_f));
                    //******
                    if (ll_count > 0)
                    {
                        sqlUpdate = string.Format(
                        @"Update mrp_st_details_lot WITH(ROWLOCK)
                        Set issue_qty=IsNull(issue_qty, 0) +{6}*(Case When('{7}'='pfc_ok') Then 1 When('{7}'='pfc_unok') Then -1 Else 0 End)
				        Where within_code='{0}' And mo_id='{1}' And obligate_mo_id='{2}' And location_id='{3}' And carton_code='{4}' And goods_id='{5}'",
                        gs_company, ls_mo_id, ls_obligate_mo_id, ls_location_id, ls_carton_code, ls_goods_id, ldc_qty, is_active_name);
                        result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                        if (result == "")
                            result = "00";
                        else
                        {
                            result = RetrunResult(result, active_name, "(mrp_st_details_lot)(1)");
                            return result;
                        }
                    }
                } //--end for 如果是套件出货

                //更新批準/反批準狀態
                if (result.Substring(0, 2) == "00")
                {
                    if (is_active_name == "pfc_ok")
                    {
                        sqlUpdate = string.Format(
                        @"Update st_transfer_mostly with(Rowlock) SET check_date='{2}',check_by='{3}',update_date='{2}',update_by='{3}',state='1'
                        WHERE within_code='{0}' and id='{1}'", gs_company, ls_id, ldt_check_date, head.update_by);
                    }
                    else
                    {
                        sqlUpdate = string.Format(
                        @"Update st_transfer_mostly with(Rowlock) SET check_date=null,check_by=null,state='0',update_by='{2}',update_date=getdate()
                         WHERE within_code='{0}' and id='{1}'", gs_company, ls_id, head.update_by);
                    }
                    result = clsErp.ExecuteSqlUpdateReturnString(sqlUpdate);
                    if (result == "")
                        result = "00";
                    else
                    {
                        result = RetrunResult(result, active_name, "(st_transfer_mostly)(Approve/UnApprove)");
                        return result;
                    }
                }

            } //--end if (is_active_name=="pfc_ok" || is_active_name=="pfc_unok")

            return result;
        }

        public static string RetrunResult(string strResult, string active_name, string strTable)
        {
            string result = "-1" + strResult + "\r\n" + "更新库存失败!+" + "\r\n" + string.Format(@"<{0}>{1}", active_name, strTable) + "\r\n";
            return result;
        }

        public static string GetStateByID(string id)
        {

            string sql_f = $"Select state From st_transfer_mostly with(nolock) Where within_code='0000' And id='{id}'";
            string result = clsErp.ExecuteSqlReturnObject(sql_f);
            return result;
        }

        public static bool CheckIsTransferIn(DataTable dt)
        {
            string sql = "", moId = "", goodsId = "", id = "", sequenceId = "";           
            bool result = false;
            DataTable dtCount = new DataTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                moId = dt.Rows[i]["mo_id"].ToString();
                goodsId = dt.Rows[i]["goods_id"].ToString();
                id = dt.Rows[i]["id"].ToString();
                sequenceId = dt.Rows[i]["sequence_id"].ToString();
                sql = string.Format(
                @"SELECT Count(1) As rtn From st_transfer_mostly A with(nolock),st_transfer_detail B with(nolock)
                WHERE A.id=B.id And A.within_code=B.within_code And A.type='1' And A.state<>'2' And B.mo_id='{0}' And
                B.goods_id='{1}' And B.transfer_out_id='{2}' And B.transfer_out_sequence_id='{3}'",
                moId, goodsId, id, sequenceId);
                dtCount = clsErp.ExecuteSqlReturnDataTable(sql);
                if(dtCount.Rows[0]["rtn"].ToString() != "0")
                {
                    result = true;
                    break; //已存在,退出循環
                }
            }
            return result;
        }

        public static DataTable GetStockLotNo(string locationId,string goodsId,string moId)
        {
            string sql = string.Format(
            @"SELECT a.lot_no,a.qty,a.sec_qty,a.mo_id,Isnull(d.name,'') As vendor_name
            FROM st_details_lot a
	            Left Outer Join it_goods b On a.within_code = b.within_code And a.goods_id = b.id
                Left Outer Join cd_productline c On a.within_code=c.within_code And a.location_id=c.id
                Left Outer Join it_vendor d on a.within_code =d.within_code and a.vendor_id=d.id
            WHERE a.within_code='0000' And a.location_id='{0}' And a.carton_code='{0}' And a.goods_id='{1}' And 
	            ('{2}'='*' Or Isnull(a.mo_id,'')='{2}') And a.state<>'2' And a.qty >0 And c.type<>'07'",
            locationId, goodsId, moId);
            DataTable dtLotNo = new DataTable();
            dtLotNo = clsErp.ExecuteSqlReturnDataTable(sql);
            return dtLotNo;
        }
    }
}
