using System;
using System.Collections.Generic;
using System.Linq;
using cf01.MDL;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public class clsCostAlloy
    {
        /// <summary>
        /// 保存排位數數據
        /// </summary>
        /// <param name="strEditState"></param>
        /// <param name="mdlCost"></param>
        /// <param name="dgrv"></param>
        /// <param name="dtblDetail"></param>
        /// <returns></returns>
        public static bool Save(string strEditState, mdlCostAlloy mdlCost, DataGridView dgrv, DataTable dtblDetail)
        {
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO pp_cost_mould(dept_id,company,id,cost_pcs,cost_process,cost,cost_qty,remark,create_by,create_date)
            VALUES(@company,@id,@cost_pcs,@cost_process,@remark,@user_id,getdate())";
            const string sql_update =
            @"UPDATE pp_cost_mould SET cost_pcs=@cost_pcs,cost_process=@cost_process,cost,cost_qty,remark=@remark,update_by=@user_id,update_date=getdate()
            WHERE dept_id=@dept_id and company=@company and id=@id ";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    if (strEditState == "1")
                    {
                        //新增狀態
                        myCommand.Parameters.Clear();
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.AddWithValue("@dept_id", mdlCost.dept_id);
                        myCommand.Parameters.AddWithValue("@company", mdlCost.company);
                        myCommand.Parameters.AddWithValue("@id", mdlCost.id);
                        myCommand.Parameters.AddWithValue("@cost_pcs", mdlCost.cost_pcs);
                        myCommand.Parameters.AddWithValue("@cost_process", mdlCost.cost_process);
                        myCommand.Parameters.AddWithValue("@cost", mdlCost.cost);
                        myCommand.Parameters.AddWithValue("@cost_qty", mdlCost.cost_qty);
                        myCommand.Parameters.AddWithValue("@remark", mdlCost.remark);
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        //編輯狀態
                        float fltCost_pcs = 0.000f, fltCost_process = 0.000f, fltCost=0.00f;
                        int intCost_qty = 0;
                        myCommand.CommandText = sql_update;
                        for (int i = 0; i < dgrv.RowCount; i++)
                        {
                            if (dtblDetail.Rows[i].RowState == DataRowState.Modified)
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@dept_id", dgrv.Rows[i].Cells["dept_id"].Value.ToString()); 
                                myCommand.Parameters.AddWithValue("@company", dgrv.Rows[i].Cells["company"].Value.ToString());    
                                myCommand.Parameters.AddWithValue("@id", dgrv.Rows[i].Cells["id"].Value.ToString());                               
                                if (string.IsNullOrEmpty(dgrv.Rows[i].Cells["cost_pcs"].Value.ToString()))
                                {
                                    fltCost_pcs = 0.00f;
                                }
                                else
                                {
                                    fltCost_pcs = float.Parse(dgrv.Rows[i].Cells["cost_pcs"].Value.ToString());
                                }
                                if (string.IsNullOrEmpty(dgrv.Rows[i].Cells["cost_process"].Value.ToString()))
                                {
                                    fltCost_process = 0.00f;
                                }
                                else
                                {
                                    fltCost_process = float.Parse(dgrv.Rows[i].Cells["cost_process"].Value.ToString());
                                }

                                if (string.IsNullOrEmpty(dgrv.Rows[i].Cells["cost"].Value.ToString()))
                                {
                                    fltCost = 0.00f;
                                }
                                else
                                {
                                    fltCost = float.Parse(dgrv.Rows[i].Cells["cost"].Value.ToString());
                                }
                                if (string.IsNullOrEmpty(dgrv.Rows[i].Cells["cost_qty"].Value.ToString()))
                                {
                                    intCost_qty = 0;
                                }
                                else
                                {
                                    intCost_qty = int.Parse(dgrv.Rows[i].Cells["cost_qty"].Value.ToString());
                                }
                          
                                myCommand.Parameters.AddWithValue("@cost_pcs", fltCost_pcs);
                                myCommand.Parameters.AddWithValue("@cost_process", fltCost_process);
                                myCommand.Parameters.AddWithValue("@remark", dgrv.Rows[i].Cells["remark"].Value.ToString());
                                myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                myCommand.ExecuteNonQuery();
                                save_flag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }

            }
            return save_flag;
        }

        /// <summary>
        /// delete current record
        /// </summary>
        /// <param name="strBrand"></param>
        /// <param name="strMoq_unit"></param>
        /// <returns></returns>
        public static bool Delete(string strDept_id,string strCompany,int intId)
        {
            bool isDelete;
            string strDel = string.Format(@"Delete FROM pp_cost_mould Where dept_id='{0}' and company='{1}' and id='{2}'", strDept_id, strCompany, intId);
            if (clsPublicOfCF01.ExecuteSqlUpdate(strDel) == "")
            {
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
            return isDelete;
        }

        /// <summary>
        /// 檢查排位數主鍵是否已經存在
        /// </summary>
        /// <param name="strBrand"></param>
        /// <param name="strMoq_unit"></param>
        /// <returns></returns>
        public static bool Check_Is_Exists(string strDept_id, string strCompany, string strId)
        {
            bool isExists;
            string strSql = string.Format(@"SELECT '1' FROM pp_cost_mould Where dept_id='{0}' and company='{1}' and id='{2}'", strDept_id, strCompany, strId);
            if (clsPublicOfCF01.ExecuteSqlReturnObject(strSql) != "")
            {
                isExists = true;
            }
            else
            {
                isExists = false;
            }
            return isExists;
        }


        /// <summary>
        /// 保存報價資料
        /// </summary>
        /// <param name="gdvCost"></param>
        /// <returns></returns>
        public static bool Save_Quotation(DevExpress.XtraGrid.Views.Grid.GridView gdvCost)
        {
            //同一頁數同一物料在表中不可以重復
            bool save_flag = false;
            string user_id = DBUtility._user_id;
            const string sql_i =
           @"INSERT INTO pp_cost_product(date_quotation,mo_id,ver,goods_id,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs
		    ,cost_total,cost_mould,complete_date,remark,create_by,create_date)
            VALUES(@date_quotation,@mo_id,@ver,@goods_id,@company,@qty_per_set,@prod_qty,@prod_weight,@cost_per_pcs
		    ,@cost_total,@cost_mould,CASE LEN(@complete_date) WHEN 0 THEN null ELSE @complete_date END,@remark,@user_id,getdate())";

            string strsql_f_quo; 
            const string strsql_u_quo =
            @"Update pp_cost_product Set ver=@ver,company=@company,qty_per_set=@qty_per_set,prod_qty=@prod_qty,prod_weight=@prod_weight,cost_per_pcs=@cost_per_pcs,
            cost_total=@cost_total,cost_mould=@cost_mould,remark=@remark,mo_id=@mo_id,goods_id=@goods_id,
            complete_date=CASE LEN(@complete_date) WHEN 0 THEN null ELSE @complete_date END,update_by=@user_id,update_date=getdate()
            Where id=@id";

            const string sql_i_history =
            @"Insert pp_cost_product_history(date_quotation,mo_id,goods_id,ver,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs,cost_total
            ,cost_mould,complete_date,remark,update_by,update_date,state_approve)
            Select date_quotation,mo_id,goods_id,ver,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs,cost_total,
            cost_mould,complete_date,remark,@user_id,getdate(),state_approve FROM pp_cost_product WHERE id=@id";
            //const string sql_del = "DELETE FROM pp_cost_product WHERE id=@id";

            //物料排位對照表
            string sql_f = "";
            const string sql_new =
            @"Insert Into pp_cost_goods_mould(goods_id,qty_per_set,create_by,create_date) Values(@goods_id,@qty_per_set,@user_id,getdate())";
            const string sql_u=
            @"Update pp_cost_goods_mould set qty_per_set=@qty_per_set,update_by=@user_id,update_date=getdate() Where goods_id =@goods_id";
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                string strDate, strMo_id, strVer, strGoods_id, strComplete_date, strRemark,strId,strCompany;
                strDate = clsPublicOfCF01.ExecuteSqlReturnObject("select convert(varchar(10),getdate(),120)");
                int intQty_per_set, intProd_qty,intId;
                float fltProd_weight, fltCost_per_pcs, fltCost_total, fltCost_mould;                
                List<mdlGoods_id> mylist = new List<mdlGoods_id>();
                try
                {
                    for (int i = 0; i < gdvCost.RowCount; i++)
                    {
                        intQty_per_set = int.Parse(gdvCost.GetRowCellValue(i, "qty_per_set").ToString());
                        if (gdvCost.GetRowCellValue(i, "select_flag").ToString() == "True" && gdvCost.GetRowCellValue(i, "id").ToString() == "0" && intQty_per_set>0)
                        {                            
                            strMo_id = gdvCost.GetRowCellValue(i, "mo_id").ToString();
                            strVer = gdvCost.GetRowCellValue(i, "ver").ToString();
                            strGoods_id = gdvCost.GetRowCellValue(i, "goods_id").ToString();
                            strCompany = gdvCost.GetRowCellValue(i, "company").ToString();
                            mdlGoods_id myMdl = new mdlGoods_id() 
                            { 
                                goods_id = strGoods_id, 
                                qty_per_set = intQty_per_set 
                            };
                            mylist.Add(myMdl);                           
                            intProd_qty = int.Parse(gdvCost.GetRowCellValue(i, "prod_qty").ToString());
                            fltProd_weight = float.Parse(gdvCost.GetRowCellValue(i, "prod_weight").ToString());
                            fltCost_per_pcs = float.Parse(gdvCost.GetRowCellValue(i, "cost_per_pcs").ToString());
                            fltCost_total = float.Parse(gdvCost.GetRowCellValue(i, "cost_total").ToString());
                            fltCost_mould = float.Parse(gdvCost.GetRowCellValue(i, "cost_mould").ToString());
                            strComplete_date = gdvCost.GetRowCellValue(i, "complete_date").ToString();
                            if (string.IsNullOrEmpty(strComplete_date))
                            {
                                strComplete_date = "";
                            }
                            else
                            {
                                strComplete_date = Convert.ToDateTime(strComplete_date).ToString("yyyy-MM-dd");
                            }
                            strRemark = gdvCost.GetRowCellValue(i, "remark").ToString();

                            strsql_f_quo =string.Format(@"Select id From pp_cost_product with(nolock) Where mo_id='{0}' And goods_id='{1}'",strMo_id,strGoods_id);                                                     
                            strId=clsPublicOfCF01.ExecuteSqlReturnObject(strsql_f_quo);
                            if (strId == "")
                            {
                                myCommand.Parameters.Clear();
                                myCommand.CommandText = sql_i;
                                myCommand.Parameters.AddWithValue("@date_quotation", strDate);
                                myCommand.Parameters.AddWithValue("@mo_id", strMo_id);
                                myCommand.Parameters.AddWithValue("@ver", strVer);
                                myCommand.Parameters.AddWithValue("@goods_id", strGoods_id);
                                myCommand.Parameters.AddWithValue("@company", strCompany);
                                myCommand.Parameters.AddWithValue("@qty_per_set", intQty_per_set);
                                myCommand.Parameters.AddWithValue("@prod_qty", intProd_qty);
                                myCommand.Parameters.AddWithValue("@prod_weight", fltProd_weight);
                                myCommand.Parameters.AddWithValue("@cost_per_pcs", fltCost_per_pcs);
                                myCommand.Parameters.AddWithValue("@cost_total", fltCost_total);
                                myCommand.Parameters.AddWithValue("@cost_mould", fltCost_mould);
                                myCommand.Parameters.AddWithValue("@remark", strRemark);
                                myCommand.Parameters.AddWithValue("@complete_date", strComplete_date);
                                myCommand.Parameters.AddWithValue("@user_id", user_id);
                                myCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                
                                intId = int.Parse(strId);
                                //已有的報價單（mo_id,goods_id為主鍵）更新前，復制到另歷史表
                                myCommand.Parameters.Clear();
                                myCommand.CommandText = sql_i_history;
                                myCommand.Parameters.AddWithValue("@id", intId);
                                myCommand.Parameters.AddWithValue("@user_id", user_id);
                                myCommand.ExecuteNonQuery();

                                //更新已有的報價單（mo_id,goods_id為主鍵）
                                myCommand.Parameters.Clear();
                                myCommand.CommandText = strsql_u_quo;                               
                                myCommand.Parameters.AddWithValue("@date_quotation", strDate);
                                myCommand.Parameters.AddWithValue("@mo_id", strMo_id);
                                myCommand.Parameters.AddWithValue("@ver", strVer);
                                myCommand.Parameters.AddWithValue("@goods_id", strGoods_id);
                                myCommand.Parameters.AddWithValue("@company", strCompany);
                                myCommand.Parameters.AddWithValue("@qty_per_set", intQty_per_set);
                                myCommand.Parameters.AddWithValue("@prod_qty", intProd_qty);
                                myCommand.Parameters.AddWithValue("@prod_weight", fltProd_weight);
                                myCommand.Parameters.AddWithValue("@cost_per_pcs", fltCost_per_pcs);
                                myCommand.Parameters.AddWithValue("@cost_total", fltCost_total);
                                myCommand.Parameters.AddWithValue("@cost_mould", fltCost_mould);
                                myCommand.Parameters.AddWithValue("@remark", strRemark);
                                myCommand.Parameters.AddWithValue("@complete_date", strComplete_date);
                                myCommand.Parameters.AddWithValue("@user_id", user_id);
                                myCommand.Parameters.AddWithValue("@id", intId);
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //更新貨料排位數對照表
                    DataTable dt = new DataTable();
                    mylist = mylist.Distinct().ToList();//去掉重復
                    foreach (mdlGoods_id lst in mylist)
                    {                        
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@goods_id", lst.goods_id);
                        myCommand.Parameters.AddWithValue("@qty_per_set", lst.qty_per_set);
                        myCommand.Parameters.AddWithValue("@user_id", user_id);
                        sql_f = string.Format("Select qty_per_set from dbo.pp_cost_goods_mould with(nolock) where goods_id ='{0}'", lst.goods_id);
                        dt = clsPublicOfCF01.GetDataTable(sql_f);
                        if (dt.Rows.Count == 0)
                        {
                            myCommand.CommandText = sql_new;
                            myCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            if (int.Parse(dt.Rows[0]["qty_per_set"].ToString()) != lst.qty_per_set)
                            {
                                myCommand.CommandText = sql_u;
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }                    

                    ////刪除已存在的報價單
                    //for (int i = 0; i < dtDel.Rows.Count; i++)
                    //{
                    //    //備份到歷史表
                    //    myCommand.CommandText = sql_i_history;
                    //    myCommand.Parameters.Clear();
                    //    myCommand.Parameters.AddWithValue("@id", dtDel.Rows[i]["id"].ToString());                        
                    //    myCommand.ExecuteNonQuery();
                    //    //刪除
                    //    myCommand.CommandText = sql_del;
                    //    myCommand.Parameters.Clear();
                    //    myCommand.Parameters.AddWithValue("@id", dtDel.Rows[i]["id"].ToString());
                    //    myCommand.ExecuteNonQuery();
                    //}         
          
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }

            return save_flag;
        }


        /// <summary>
        /// 刪除報價資料
        /// </summary>
        /// <param name="intId"></param>
        /// <returns></returns>
        public static bool Delete_Quotation(int intId)
        {
            bool isDelete;
            const string sql_i_history =
           @"Insert pp_cost_product_history
           (date_quotation,mo_id,goods_id,ver,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs,cost_total,
            cost_mould,complete_date,remark,update_by,update_date,state_approve)
            Select date_quotation,mo_id,goods_id,ver,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs,cost_total,
            cost_mould,complete_date,remark,@user_id as update_by,getdate() as update_date,state_approve 
            FROM dbo.pp_cost_product with(nolock) WHERE id=@id";
            const string sql_del = "DELETE FROM dbo.pp_cost_product WHERE id=@id";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {                    
                    myCommand.Parameters.Clear();
                    myCommand.CommandText = sql_i_history;
                    myCommand.Parameters.AddWithValue("@id", intId);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                    myCommand.ExecuteNonQuery();
                   
                    myCommand.Parameters.Clear();
                    myCommand.CommandText = sql_del;
                    myCommand.Parameters.AddWithValue("@id", intId);
                    
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit();
                    isDelete = true;
                }
                catch (Exception E)
                {
                    //數據回滾
                    myTrans.Rollback();
                    isDelete = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }
           
            return isDelete;
        }

        /// <summary>
        /// 查詢已保存報價單資料
        /// </summary>
        /// <param name="strDate1"></param>
        /// <param name="strDate2"></param>
        /// <returns></returns>
        public static DataTable GetQuotationData(string strDate1,string strDate2,string strCompany)
        {
            string strsql = string.Format(
            @"Select ROW_NUMBER()OVER(partition by A.date_quotation,A.company ORDER BY A.date_quotation,A.company,A.mo_id,A.goods_id) as seq, 
            convert(varchar(10),A.date_quotation,120) as date_quotation,A.mo_id,A.goods_id,A.ver,A.company,A.qty_per_set,A.prod_qty,
            A.prod_weight,A.cost_per_pcs,A.cost_total,Convert(int,A.cost_mould) as cost_mould,convert(varchar(10),A.complete_date,120) as complete_date,A.remark,
            A.state_approve,B.name as goods_name,dbo.Fn_get_picture_name('0000',A.goods_id,'in') AS picture_name,A.company as org_company,A.qty_per_set as org_qty_per_set,A.id
            From dgsql2.dgcf_db.dbo.pp_cost_product A with(nolock) 
            Inner Join dgerp2.cferp.dbo.it_goods B with(nolock) 
            ON B.within_code='0000' AND A.goods_id COLLATE Chinese_PRC_CI_AS = B.id 
            WHERE A.date_quotation>='{0}' And A.date_quotation<='{1}'", strDate1, strDate2);
            if (strCompany != "")
            {
                strsql += string.Format(" AND A.company='{0}'", strCompany);
            }            
            clsPublicOfGEO objGEO = new clsPublicOfGEO();
            DataTable dt = objGEO.GetDataTable(strsql);
            objGEO = null;
            return dt; 
        }

        public static bool Modify_Quotation(DevExpress.XtraGrid.Views.Grid.GridView gdvCost)
        {
            //同一頁數同一物料在表中不可以重復
            bool save_flag = false;
            string user_id = DBUtility._user_id;           
            const string strsql_u_quo =
            @"Update pp_cost_product Set ver=@ver,company=@company,qty_per_set=@qty_per_set,prod_qty=@prod_qty,prod_weight=@prod_weight,cost_per_pcs=@cost_per_pcs,
            cost_total=@cost_total,cost_mould=@cost_mould,remark=@remark,mo_id=@mo_id,goods_id=@goods_id,
            complete_date=@complete_date,update_by=@user_id,update_date=getdate() Where id=@id";
            const string sql_i_history =
            @"Insert pp_cost_product_history(date_quotation,mo_id,goods_id,ver,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs,cost_total
            ,cost_mould,complete_date,remark,update_by,update_date,state_approve)
            Select date_quotation,mo_id,goods_id,ver,company,qty_per_set,prod_qty,prod_weight,cost_per_pcs,cost_total,
            cost_mould,complete_date,remark,@user_id,getdate(),state_approve FROM pp_cost_product WHERE id=@id";           

            //更新物料排位對照表  
            string sql_f = "";
            const string sql_new =
            @"Insert Into pp_cost_goods_mould(goods_id,qty_per_set,create_by,create_date) Values(@goods_id,@qty_per_set,@user_id,getdate())";
            const string sql_u =
            @"Update pp_cost_goods_mould set qty_per_set=@qty_per_set,update_by=@user_id,update_date=getdate() Where goods_id =@goods_id";
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                string strDate, strMo_id, strVer, strGoods_id, strComplete_date, strRemark, strId, strCompany;                
                int intQty_per_set, intProd_qty, intId;
                float fltProd_weight, fltCost_per_pcs, fltCost_total, fltCost_mould;
                List<mdlGoods_id> mylist = new List<mdlGoods_id>();
                try
                {
                    for (int i = 0; i < gdvCost.RowCount; i++)
                    {
                        intQty_per_set = int.Parse(gdvCost.GetRowCellValue(i, "qty_per_set").ToString());
                        strId = gdvCost.GetRowCellValue(i, "id").ToString();
                        if ((gdvCost.GetRowCellValue(i, "company").ToString() != gdvCost.GetRowCellValue(i, "org_company").ToString() ||
                           gdvCost.GetRowCellValue(i, "qty_per_set").ToString() != gdvCost.GetRowCellValue(i, "org_qty_per_set").ToString()) 
                           && intQty_per_set > 0)
                        {
                            strDate = gdvCost.GetRowCellValue(i, "date_quotation").ToString(); ;
                            strMo_id = gdvCost.GetRowCellValue(i, "mo_id").ToString();
                            strVer = gdvCost.GetRowCellValue(i, "ver").ToString();
                            strGoods_id = gdvCost.GetRowCellValue(i, "goods_id").ToString();
                            strCompany = gdvCost.GetRowCellValue(i, "company").ToString();
                            mdlGoods_id myMdl = new mdlGoods_id()
                            {
                                goods_id = strGoods_id,
                                qty_per_set = intQty_per_set
                            };
                            mylist.Add(myMdl);
                            intProd_qty = int.Parse(gdvCost.GetRowCellValue(i, "prod_qty").ToString());
                            fltProd_weight = float.Parse(gdvCost.GetRowCellValue(i, "prod_weight").ToString());
                            fltCost_per_pcs = float.Parse(gdvCost.GetRowCellValue(i, "cost_per_pcs").ToString());
                            fltCost_total = float.Parse(gdvCost.GetRowCellValue(i, "cost_total").ToString());
                            fltCost_mould = float.Parse(gdvCost.GetRowCellValue(i, "cost_mould").ToString());
                            strComplete_date = gdvCost.GetRowCellValue(i, "complete_date").ToString();
                            if (string.IsNullOrEmpty(strComplete_date))
                            {
                                strComplete_date = "";
                            }
                            else
                            {
                                strComplete_date = Convert.ToDateTime(strComplete_date).ToString("yyyy-MM-dd");
                            }
                            strRemark = gdvCost.GetRowCellValue(i, "remark").ToString();
                            intId = int.Parse(strId);

                            //已有的報價單（mo_id,goods_id為主鍵）更新前，復制到另歷史表
                            myCommand.Parameters.Clear();
                            myCommand.CommandText = sql_i_history;
                            myCommand.Parameters.AddWithValue("@id", intId);
                            myCommand.Parameters.AddWithValue("@user_id", user_id);
                            myCommand.ExecuteNonQuery();

                            //更新已有的報價單（mo_id,goods_id為主鍵）
                            myCommand.Parameters.Clear();
                            myCommand.CommandText = strsql_u_quo;
                            myCommand.Parameters.AddWithValue("@date_quotation", strDate);
                            myCommand.Parameters.AddWithValue("@mo_id", strMo_id);
                            myCommand.Parameters.AddWithValue("@ver", strVer);
                            myCommand.Parameters.AddWithValue("@goods_id", strGoods_id);
                            myCommand.Parameters.AddWithValue("@company", strCompany);
                            myCommand.Parameters.AddWithValue("@qty_per_set", intQty_per_set);
                            myCommand.Parameters.AddWithValue("@prod_qty", intProd_qty);
                            myCommand.Parameters.AddWithValue("@prod_weight", fltProd_weight);
                            myCommand.Parameters.AddWithValue("@cost_per_pcs", fltCost_per_pcs);
                            myCommand.Parameters.AddWithValue("@cost_total", fltCost_total);
                            myCommand.Parameters.AddWithValue("@cost_mould", fltCost_mould);
                            myCommand.Parameters.AddWithValue("@remark", strRemark);
                            myCommand.Parameters.AddWithValue("@complete_date", strComplete_date);
                            myCommand.Parameters.AddWithValue("@user_id", user_id);
                            myCommand.Parameters.AddWithValue("@id", intId);
                            myCommand.ExecuteNonQuery();                            
                        }
                    }

                    //更新貨料排位數對照表                    
                    DataTable dt = new DataTable();
                    mylist = mylist.Distinct().ToList();//去掉重復
                    foreach (mdlGoods_id lst in mylist)
                    {
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@goods_id", lst.goods_id);
                        myCommand.Parameters.AddWithValue("@qty_per_set", lst.qty_per_set);
                        myCommand.Parameters.AddWithValue("@user_id", user_id);
                        sql_f = string.Format("Select qty_per_set From dbo.pp_cost_goods_mould with(nolock) Where goods_id ='{0}'", lst.goods_id);
                        dt = clsPublicOfCF01.GetDataTable(sql_f);
                        if (dt.Rows.Count == 0)
                        {
                            myCommand.CommandText = sql_new;
                            myCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            if (int.Parse(dt.Rows[0]["qty_per_set"].ToString()) != lst.qty_per_set)
                            {
                                myCommand.CommandText = sql_u;
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }

            return save_flag;
        }

    }
}
