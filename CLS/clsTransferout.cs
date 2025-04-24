using cf01.MDL;
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
            string sql_u = string.Format(@"Updage st_transfer_mostly Set state='2' WHERE within_code='0000' And id='{0}'", id);
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
            CASE WHEN A.suit_flag<>'1' THEN '' ELSE '底三件走貨' END AS suit_flag
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
                sql_f += $" And ISNULL(C.special_info_style,'0')='1'";
            }
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
            //dt = ListToDataTable<packing_mo>(moList);
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
                    item.location, item.carton_code, item.bom_qty, item.lot_no, item.inventory_qty, item.inventory_sec_qty);
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
                        //item.row_status非空,數據有新增或修改                        
                        if (item.row_status == "EDIT")
                        {
                            lot_no = !string.IsNullOrEmpty(item.lot_no) ? item.lot_no : clsPublic.GetDeptLotNo(item.location_id, item.location_id);//自動生成批號
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
                            lot_no = !string.IsNullOrEmpty(item.lot_no) ? item.lot_no : clsPublic.GetDeptLotNo(item.location_id, item.location_id);//自動生成批號
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
            result = clsErp.ExecuteSqlReturnObject(strSql); // Return value DT10560134510
            return result;
        }



    }
}
