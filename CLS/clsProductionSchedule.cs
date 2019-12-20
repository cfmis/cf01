using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsProductionSchedule
    {

        /// <summary>
        /// 查詢生產部門
        /// </summary>
        /// <returns></returns>
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public static DataTable GetAllPrd_dept()
        {
            DataTable dtDept = new DataTable();
            try
            {
                string strSql = @" select int9loc,int9desc from int09 ";

                dtDept = clsPublicOfPad.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtDept;
        }
        //提取急單類型
        public static DataTable GetUrgentGrade()
        {
            DataTable dtUrgent = new DataTable();
            try
            {
                string strSql = @"select flag_id,flag_desc from bs_flag_desc Where doc_type='UG' AND flag0='Y' order by flag_id ";

                dtUrgent = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtUrgent;
        }

        //提取生產狀態
        public static DataTable GetPrdStatus()
        {
            DataTable dtPrdStatus = new DataTable();
            try
            {
                string strSql = @"select flag_id,flag_desc from bs_flag_desc Where doc_type='PD' AND flag0='Y' order by flag_id ";

                dtPrdStatus = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPrdStatus;
        }
        /// <summary>
        /// 查詢工作類型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWorkType()
        {
            DataTable dtworktype = new DataTable();
            try
            {
                string strSql = @" select work_type_id,rtrim(work_type_desc) as work_type_desc from work_type ";

                dtworktype = clsPublicOfPad.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtworktype;
        }
        /// <summary>
        /// 查詢生產機器
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMachine(string dep)
        {
            DataTable dtMachine = new DataTable();
            try
            {
                string strSql = @" select machine_id,rtrim(machine_id)+'--'+rtrim(machine_desc) as machine_desc from machine_tb where dep='" + dep + "'";

                dtMachine = clsPublicOfPad.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtMachine;
        }
        /// <summary>
        /// 獲取相關制單物料信息
        /// </summary>
        /// <param name="mo_id"></param>
        /// <param name="prd_dept"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        //獲取制單資料
        public static DataTable GetMo_dataById(string mo_id, string fdep,string tdep, string item)
        {
            DataTable dtmo_data = new DataTable();
            try
            {
                string strSql = @" SELECT DISTINCT b.goods_id,c.name as name,b.prod_qty,b.next_wp_id,d.materiel_id AS mat_item,e.name AS mat_item_desc,b.sequence_id,b.ver
                       from jo_bill_mostly a 
                       INNER join jo_bill_goods_details b on a.within_code=b.within_code and a.id=b.id  and a.ver=b.ver
                       INNER JOIN it_goods c on b.within_code=c.within_code and b.goods_id=c.id 
                       INNER JOIN jo_bill_materiel_details d ON b.within_code=d.within_code and b.id=d.id and b.ver=d.ver and b.sequence_id=d.upper_sequence
                       INNER JOIN it_goods e ON d.within_code=e.within_code and d.materiel_id=e.id
                       WHERE a.within_code='0000'  And a.mo_id = '" + mo_id + "'";
                if (fdep != "")
                    strSql += " And b.wp_id = '" + fdep + "' ";
                if (tdep != "")
                    strSql += " And b.next_wp_id = '" + tdep + "' ";
                if (item != "")
                {
                    strSql += " And b.goods_id ='" + item + "'";
                }

                dtmo_data = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtmo_data;
        }

        /// <summary>
        /// 獲取物料描述
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static DataTable GetItemDesc(string item)
        {
            DataTable dtitem = new DataTable();
            try
            {
                string strSql = @" SELECT name from it_goods a WHERE a.within_code='0000'  And a.id = '" + item + "' ";

                dtitem = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtitem;
        }

        /// <summary>
        /// 添加制單編號資料
        /// </summary>
        /// <param name="prd_records"></param>
        /// <returns></returns>
        public static int AddProductionRecords(product_records prd_records)
        {
            int Result = 0;
            try
            {
                string strSql = @"insert into product_records (prd_id,prd_pdate,prd_date, prd_dep, prd_mo, prd_item, prd_qty
                                                                ,prd_weg, prd_machine, prd_work_type, prd_worker, prd_class
                                                                ,prd_group, prd_start_time, prd_end_time, prd_normal_time, prd_ot_time
                                                                ,line_num,hour_run_num,hour_std_qty,kg_pcs,difficulty_level
                                                                ,mat_item,mat_item_desc,mat_item_lot,to_dep,work_code
                                                                ,ok_qty,ok_weg,no_ok_qty,no_ok_weg,sample_no,sample_weg,member_no,per_hour_std_qty,prd_id_ref
                                                                ,prd_owndep,work_class,actual_weg,actual_qty,crusr,crtim)
                                                     Values(@prd_id,@prd_pdate,@prd_date, @prd_dep, @prd_mo, @prd_item, @prd_qty
                                                            ,@prd_weg, @prd_machine, @prd_work_type, @prd_worker, @prd_class
                                                            ,@prd_group, @prd_start_time, @prd_end_time, @prd_normal_time, @prd_ot_time
                                                            ,@line_num, @hour_run_num, @hour_std_qty, @kg_pcs,@difficulty_level
                                                            ,@mat_item,@mat_item_desc,@mat_item_lot,@to_dep,@work_code
                                                            ,@ok_qty,@ok_weg,@no_ok_qty,@no_ok_weg,@sample_no,@sample_weg,@member_no,@per_hour_std_qty,@prd_id_ref
                                                            ,@prd_owndep,@work_class,@actual_weg,@actual_qty,@crusr,GETDATE())";

                SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@prd_id",prd_records.prd_id),
                        new SqlParameter("@prd_pdate",prd_records.prd_pdate),
                        new SqlParameter("@prd_date",prd_records.prd_date),
                        new SqlParameter("@prd_dep",prd_records.prd_dep),
                        new SqlParameter("@prd_mo",prd_records.prd_mo),
                        new SqlParameter("@prd_item",prd_records.prd_item),
                        new SqlParameter("@prd_qty",prd_records.prd_qty),
                        new SqlParameter("@prd_weg",Math.Round(prd_records.prd_weg,2)),
                        new SqlParameter("@prd_machine",prd_records.prd_machine),
                        new SqlParameter("@prd_work_type",prd_records.prd_work_type),
                        new SqlParameter("@prd_worker",prd_records.prd_worker),
                        new SqlParameter("@prd_class",prd_records.prd_class),
                        new SqlParameter("@prd_group",prd_records.prd_group),
                        new SqlParameter("@prd_start_time",prd_records.prd_start_time),
                        new SqlParameter("@prd_end_time",prd_records.prd_end_time),
                        new SqlParameter("@prd_normal_time",Math.Round(prd_records.prd_normal_time,3)),
                        new SqlParameter("@prd_ot_time",Math.Round(prd_records.prd_ot_time,3)),
                        new SqlParameter("@line_num",prd_records.line_num),
                        new SqlParameter("@hour_run_num",prd_records.hour_run_num),
                        new SqlParameter("@hour_std_qty",prd_records.hour_std_qty),
                        new SqlParameter("@kg_pcs",prd_records.kg_pcs),
                        new SqlParameter("@crusr",prd_records.crusr),
                        new SqlParameter("@difficulty_level",prd_records.difficulty_level),
                        new SqlParameter("@mat_item",prd_records.mat_item),
                        new SqlParameter("@mat_item_desc",prd_records.mat_item_desc),
                        new SqlParameter("@mat_item_lot",prd_records.mat_item_lot),
                        new SqlParameter("@to_dep",prd_records.to_dep),
                        new SqlParameter("@work_code",prd_records.work_code),
                        new SqlParameter("@ok_qty",prd_records.ok_qty),
                        new SqlParameter("@ok_weg",prd_records.ok_weg),
                        new SqlParameter("@no_ok_qty",prd_records.no_ok_qty),
                        new SqlParameter("@no_ok_weg",prd_records.no_ok_weg),
                        new SqlParameter("@sample_no",prd_records.sample_no),
                        new SqlParameter("@sample_weg",prd_records.sample_weg),
                        new SqlParameter("@member_no",prd_records.member_no),
                        new SqlParameter("@per_hour_std_qty",prd_records.per_hour_std_qty),
                        new SqlParameter("@prd_id_ref",prd_records.prd_id_ref),
                        new SqlParameter("@prd_owndep",prd_records.prd_owndep),
                        new SqlParameter("@work_class",prd_records.work_class),
                        new SqlParameter("@actual_weg",prd_records.actual_weg),
                        new SqlParameter("@actual_qty",prd_records.actual_qty)
                    };

                

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
                //以下這段取消，不會再自動插入到安排的計劃中，改由PMC自行安排 2015/08/03
//                if (Result > 0)
//                {
//                int MaxArrange_seq = clsProductionSchedule.GetMaxArrange_seq(prd_records.prd_dep, prd_records.prd_machine);
//                    int arrange_seq = MaxArrange_seq + 1;

//                    strSql = @"INSERT INTO product_arrange(arrange_id, prd_dep, prd_mo, prd_item, to_dep
//                                                         , arrange_date, arrange_seq, arrange_qty
//                                                         , arrange_machine, crusr, crtim)
//                                                  VALUES(@arrange_id, @prd_dep, @prd_mo, @prd_item
//                                                        , @to_dep, @arrange_date, @arrange_seq, @arrange_qty
//                                                        , @arrange_machine, @crusr, GETDATE())";

//                    SqlParameter[] paras2 = new SqlParameter[] {
//                       new SqlParameter("@arrange_id",prd_records.prd_id),
//                       new SqlParameter("@prd_dep",prd_records.prd_dep),
//                       new SqlParameter("@prd_mo",prd_records.prd_mo),
//                       new SqlParameter("@prd_item",prd_records.prd_item),
//                       new SqlParameter("@to_dep",prd_records.to_dep),
//                       new SqlParameter("@arrange_date",prd_records.prd_pdate),
//                       new SqlParameter("@arrange_seq",arrange_seq),
//                       new SqlParameter("@arrange_qty",prd_records.prd_qty),
//                       new SqlParameter("@arrange_machine",prd_records.prd_machine),
//                       new SqlParameter("@crusr",prd_records.amusr)
//                    };

//                    int ArrangeResult = clsPublicOfPad.ExecuteNonQuery(strSql, paras2, false);
//                }

                //以上這段取消，不會再自動插入到安排的計劃中，改由PMC自行安排 2015/08/03


                //更新安排計劃中的生產ID
                if (Result > 0)
                {
                    strSql = @"Update product_arrange Set prd_id=@prd_id Where prd_dep=@prd_dep AND prd_mo=@prd_mo AND prd_item=@prd_item";
                    SqlParameter[] paras2 = new SqlParameter[] {
                       new SqlParameter("@prd_id",prd_records.prd_id),
                       new SqlParameter("@prd_dep",prd_records.prd_dep),
                       new SqlParameter("@prd_mo",prd_records.prd_mo),
                       new SqlParameter("@prd_item",prd_records.prd_item)
                    };
                    int ArrangeResult = clsPublicOfPad.ExecuteNonQuery(strSql, paras2, false);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 編輯制單編號資料
        /// </summary>
        /// <param name="prd_records"></param>
        /// <returns></returns>
        public static int UpdateProductionRecords(product_records prd_records)
        {
            int Result = 0;
            try
            {
                string strSql = @"update product_records set prd_pdate = @prd_pdate,prd_date = @prd_date,prd_qty =@prd_qty,prd_weg=@prd_weg,prd_machine=@prd_machine,prd_work_type=@prd_work_type
                                  ,prd_worker=@prd_worker,prd_class=@prd_class,prd_group=@prd_group,prd_start_time=@prd_start_time,prd_end_time=@prd_end_time
                                  ,prd_normal_time=@prd_normal_time,prd_ot_time=@prd_ot_time,line_num=@line_num,hour_run_num=@hour_run_num,hour_std_qty=@hour_std_qty
                                  ,kg_pcs=@kg_pcs,amtim=@amtim,amusr=@amusr,difficulty_level=@difficulty_level
                                  ,mat_item=@mat_item,mat_item_desc=@mat_item_desc,mat_item_lot=@mat_item_lot,to_dep=@to_dep,work_code=@work_code
                                  ,ok_qty=@ok_qty,ok_weg=@ok_weg,no_ok_qty=@no_ok_qty,no_ok_weg=@no_ok_weg,sample_no=@sample_no
                                  ,sample_weg=@sample_weg,member_no=@member_no,per_hour_std_qty=@per_hour_std_qty,prd_id_ref=@prd_id_ref,prd_owndep=@prd_owndep,work_class=@work_class
                                  ,actual_weg=@actual_weg,actual_qty=@actual_qty
                                  Where prd_id = @prd_id";

                SqlParameter[] paras = new SqlParameter[] { 
                        new SqlParameter("@prd_pdate",prd_records.prd_pdate),
                        new SqlParameter("@prd_date",prd_records.prd_date),
                        new SqlParameter("@prd_qty",prd_records.prd_qty),
                        new SqlParameter("@prd_weg",Math.Round(prd_records.prd_weg,2)),
                        new SqlParameter("@prd_machine",prd_records.prd_machine),
                        new SqlParameter("@prd_work_type",prd_records.prd_work_type),
                        new SqlParameter("@prd_worker",prd_records.prd_worker),
                        new SqlParameter("@prd_class",prd_records.prd_class),
                        new SqlParameter("@prd_group",prd_records.prd_group),
                        new SqlParameter("@prd_start_time",prd_records.prd_start_time),
                        new SqlParameter("@prd_end_time",prd_records.prd_end_time),
                        new SqlParameter("@prd_normal_time",Math.Round(prd_records.prd_normal_time,3)),
                        new SqlParameter("@prd_ot_time",Math.Round(prd_records.prd_ot_time,3)),
                        new SqlParameter("@line_num",prd_records.line_num),
                        new SqlParameter("@hour_run_num",prd_records.hour_run_num),
                        new SqlParameter("@hour_std_qty",prd_records.hour_std_qty),
                        new SqlParameter("@kg_pcs",prd_records.kg_pcs),
                        new SqlParameter("@amtim",prd_records.amtim),
                        new SqlParameter("@amusr",prd_records.amusr),
                        new SqlParameter("@prd_id",prd_records.prd_id),
                        new SqlParameter("@difficulty_level",prd_records.difficulty_level),
                        new SqlParameter("@mat_item",prd_records.mat_item),
                        new SqlParameter("@mat_item_desc",prd_records.mat_item_desc),
                        new SqlParameter("@mat_item_lot",prd_records.mat_item_lot),
                        new SqlParameter("@to_dep",prd_records.to_dep),
                        new SqlParameter("@work_code",prd_records.work_code),
                        new SqlParameter("@ok_qty",prd_records.ok_qty),
                        new SqlParameter("@ok_weg",prd_records.ok_weg),
                        new SqlParameter("@no_ok_qty",prd_records.no_ok_qty),
                        new SqlParameter("@no_ok_weg",prd_records.no_ok_weg),
                        new SqlParameter("@sample_no",prd_records.sample_no),
                        new SqlParameter("@sample_weg",prd_records.sample_weg),
                        new SqlParameter("@member_no",prd_records.member_no),
                        new SqlParameter("@per_hour_std_qty",prd_records.per_hour_std_qty),
                        new SqlParameter("@prd_id_ref",prd_records.prd_id_ref),
                        new SqlParameter("@prd_owndep",prd_records.prd_owndep),
                        new SqlParameter("@work_class",prd_records.work_class),
                        new SqlParameter("@actual_weg",prd_records.actual_weg),
                        new SqlParameter("@actual_qty",prd_records.actual_qty)
                    };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 更新磅貨數量、重量
        /// </summary>
        /// <param name="prd_records"></param>
        /// <returns></returns>
        public static int UpdatePrrdActualQty(product_records prd_records)
        {
            int Result = 0;
            try
            {
                string strSql = @"update product_records set actual_qty = @actual_qty,actual_weg =@actual_weg,mat_item=@mat_item,mat_item_lot=@mat_item_lot
                                ,actual_pack_num=@actual_pack_num,conf_flag=@conf_flag,conf_time=@conf_time
                                  Where prd_id = @prd_id";

                SqlParameter[] paras = new SqlParameter[] { 
                        new SqlParameter("@actual_qty",Math.Round(prd_records.actual_qty,2)),
                        new SqlParameter("@actual_weg",Math.Round(prd_records.actual_weg,2)),
                        new SqlParameter("@actual_pack_num",prd_records.actual_pack_num),
                        new SqlParameter("@mat_item",prd_records.mat_item),
                        new SqlParameter("@mat_item_lot",prd_records.mat_item_lot),
                        new SqlParameter("@conf_flag",prd_records.conf_flag),
                        new SqlParameter("@conf_time",prd_records.conf_time),
                        new SqlParameter("@prd_id",prd_records.prd_id),
                    };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 更新物料每KG對應的數量表
        /// </summary>
        /// <param name="prd_records"></param>
        /// <param name="kg_pcs_rate"></param>
        /// <returns></returns>
        public static int InsertOrUpdateItem_rate(product_records prd_records, int kg_pcs_rate)
        {
            int Result = 0;
            try
            {
                string strSql = "";

                if (kg_pcs_rate > 0)
                {
                    strSql += @" Update item_rate Set rate=@rate,cr_date=@cr_date
                               Where dep=@dep And mat_item=@mat_item ";
                }
                else
                {
                    strSql += @"Insert into item_rate (dep, mat_item, rate, cr_date)
                                                values(@dep,@mat_item,@rate,@cr_date)";
                }
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@rate",prd_records.kg_pcs),
                    new SqlParameter("@cr_date",prd_records.prd_date),
                    new SqlParameter("@dep",prd_records.prd_dep),
                    new SqlParameter("@mat_item",prd_records.prd_item)
                };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 刪除制單編號的資料
        /// </summary>
        /// <param name="prd_id"></param>
        /// <param name="record_id"></param>
        /// <returns></returns>
        public static int DeleteProductionRecords(int prd_id)
        {
            int Result = 0;
            try
            {
                string strSql1 = @" SELECT transfer_flag FROM product_records 
                                   WHERE prd_id = '" + prd_id + "' And transfer_flag ='' ";
                DataTable dtres = clsPublicOfPad.GetDataTable(strSql1);
                if (dtres.Rows.Count > 0)
                {
                    string strSql2 = @" DELETE FROM product_records WHERE prd_id = '" + prd_id + "'";
                    strSql2 += @" DELETE FROM product_records_worker WHERE prd_id = '" + prd_id + "'";
                    strSql2 += @" DELETE FROM product_records_defective WHERE prd_id = '" + prd_id + "'";

                    Result = clsPublicOfPad.ExecuteNonQuery(strSql2, null, false);
                }
                else
                {
                    MessageBox.Show("該記錄已提交到電腦系統,不能刪除!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        public static List<product_records> GetPrdMachineStatus(string dept, string worktype, int pageSize)
        {
            List<product_records> lsPms = new List<product_records>();
            DataTable dtBase = new DataTable();
            try
            {

                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@dept",dept)
                };

                dtBase = clsPublicOfPad.ExecuteProcedureReturnTable("Produce_Work_Status", paras);
                if (dtBase.Rows.Count > 0)
                {
                    int totalPages;
                    int r = 1;
                    int j = 0;
                    if ((dtBase.Rows.Count % pageSize) == 0)
                    {
                        totalPages = dtBase.Rows.Count / pageSize;
                    }
                    else
                    {
                        totalPages = (dtBase.Rows.Count / pageSize) + 1;
                    }

                    for (int i = 0; i < dtBase.Rows.Count; i++)
                    {
                        if (j == pageSize)
                        {
                            j = 0;
                            r = r + 1;
                        }
                        product_records objModel = new product_records();
                        objModel.prd_id = clsUtility.FormatNullableInt32(dtBase.Rows[i]["prd_id"]);
                        objModel.prd_dep = (dtBase.Rows[i]["prd_dep"].ToString() != null ? dtBase.Rows[i]["prd_dep"].ToString().Trim() : "");
                        objModel.prd_mo = (dtBase.Rows[i]["prd_mo"].ToString() != null ? dtBase.Rows[i]["prd_mo"].ToString().Trim() : "");
                        objModel.prd_item = (dtBase.Rows[i]["prd_item"].ToString() != null ? dtBase.Rows[i]["prd_item"].ToString().Trim() : "");
                        objModel.prd_qty = clsUtility.FormatNullableInt32(dtBase.Rows[i]["prd_qty"]);
                        objModel.prd_date = (dtBase.Rows[i]["prd_date"].ToString() != null ? dtBase.Rows[i]["prd_date"].ToString().Trim() : "");
                        objModel.prd_weg = clsUtility.FormatNullableFloat(dtBase.Rows[i]["prd_weg"]);
                        objModel.machine_desc = (dtBase.Rows[i]["machine_desc"].ToString() != null ? dtBase.Rows[i]["machine_desc"].ToString().Trim() : "");
                        objModel.prd_machine = (dtBase.Rows[i]["machine_id"].ToString() != null ? dtBase.Rows[i]["machine_id"].ToString().Trim() : "");
                        objModel.prd_work_type = (dtBase.Rows[i]["work_type_id"].ToString() != null ? dtBase.Rows[i]["work_type_id"].ToString().Trim() : "");
                        objModel.work_type_decs = (dtBase.Rows[i]["work_type_desc"].ToString() != null ? dtBase.Rows[i]["work_type_desc"].ToString().Trim() : "");
                        objModel.prd_worker = (dtBase.Rows[i]["prd_worker"].ToString() != null ? dtBase.Rows[i]["prd_worker"].ToString().Trim() : "");
                        objModel.prd_class = (dtBase.Rows[i]["prd_class"].ToString() != null ? dtBase.Rows[i]["prd_class"].ToString().Trim() : "");
                        objModel.prd_group = (dtBase.Rows[i]["prd_group"].ToString() != null ? dtBase.Rows[i]["prd_group"].ToString().Trim() : "");
                        objModel.prd_start_time = (dtBase.Rows[i]["prd_start_time"].ToString() != null ? dtBase.Rows[i]["prd_start_time"].ToString().Trim() : "");
                        objModel.prd_end_time = (dtBase.Rows[i]["prd_end_time"].ToString() != null ? dtBase.Rows[i]["prd_end_time"].ToString().Trim() : "");
                        objModel.prd_normal_time = clsUtility.FormatNullableFloat(dtBase.Rows[i]["prd_normal_time"]);
                        objModel.prd_ot_time = clsUtility.FormatNullableFloat(dtBase.Rows[i]["prd_ot_time"]);
                        objModel.line_num = clsUtility.FormatNullableInt32(dtBase.Rows[i]["line_num"]);
                        objModel.hour_run_num = clsUtility.FormatNullableInt32(dtBase.Rows[i]["hour_run_num"]);
                        objModel.hour_std_qty = clsUtility.FormatNullableInt32(dtBase.Rows[i]["hour_std_qty"]);
                        objModel.kg_pcs = clsUtility.FormatNullableInt32(dtBase.Rows[i]["kg_pcs"]);
                        objModel.qc_flag = (dtBase.Rows[i]["qc_flag"].ToString() != null ? dtBase.Rows[i]["qc_flag"].ToString().Trim() : "");
                        objModel.pageIndex = r;

                        lsPms.Add(objModel);

                        j++;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lsPms;
        }

        /// <summary>
        /// 更新工號表時，先檢查是否存在，若存在則先刪除，後重新插入
        /// </summary>
        /// <param name="prd_id"></param>
        /// <returns></returns>
        public static int DeletePrdWorker(int prd_id)
        {
            int Result = 0;
            try
            {
                string strSql1 = @" SELECT prd_id FROM product_records_worker 
                                   WHERE prd_id = '" + prd_id + "'";
                DataTable dtres = clsPublicOfPad.GetDataTable(strSql1);
                if (dtres.Rows.Count > 0)
                {
                    strSql1 = @" DELETE FROM product_records_worker WHERE prd_id = '" + prd_id + "'";

                    Result = clsPublicOfPad.ExecuteNonQuery(strSql1, null, false);
                }
                else
                    Result = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        //刪除次品記錄表
        public static int DeletePrdDefective(int prd_id)
        {
            int Result = 0;
            try
            {
                string strSql1 = @" SELECT prd_id FROM product_records_defective 
                                   WHERE prd_id = '" + prd_id + "'";
                DataTable dtres = clsPublicOfPad.GetDataTable(strSql1);
                if (dtres.Rows.Count > 0)
                {
                    strSql1 = @" DELETE FROM product_records_defective WHERE prd_id = '" + prd_id + "'";

                    Result = clsPublicOfPad.ExecuteNonQuery(strSql1, null, false);
                }
                else
                    Result = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        public static int AddPrdWorker(int prd_id, string prd_worker, string crusr, DateTime crtim)
        {
            int Result = 0;
            try
            {
                string strSql = @"insert into product_records_worker (prd_id, prd_worker,crusr,crtim)
                                                     Values(@prd_id, @prd_worker,@crusr,@crtim)";

                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@prd_id",prd_id),
                    new SqlParameter("@prd_worker",prd_worker),
                    new SqlParameter("@crusr",crusr),
                    new SqlParameter("@crtim",crtim)
                };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        public static int AddPrdDefective(int prd_id, string seq,string defective_id,string oth_defective, string crusr, DateTime crtim)
        {
            int Result = 0;
            try
            {
                string strSql = @"insert into product_records_defective (prd_id, seq,defective_id,oth_defective,crusr,crtim)
                                                     Values(@prd_id, @seq,@defective_id,@oth_defective,@crusr,@crtim)";

                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@prd_id",prd_id),
                    new SqlParameter("@seq",seq),
                    new SqlParameter("@defective_id",defective_id),
                    new SqlParameter("@oth_defective",oth_defective),
                    new SqlParameter("@crusr",crusr),
                    new SqlParameter("@crtim",crtim)
                };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        /// <summary>
        /// 提取機器生產狀態
        /// </summary>
        /// <param name="select_type"></param>
        /// <param name="dept"></param>
        /// <param name="machine_id"></param>
        /// <returns></returns>
        public static DataTable GetPrdMachineStatus1(int select_type, string dept,string workshop,string AreaId, string machine_id)
        {
            DataTable dtBase = new DataTable();
            try
            {

                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@select_type",select_type)
                   ,new SqlParameter("@dep",dept)
                   ,new SqlParameter("@workshop",workshop)
                   ,new SqlParameter("@areaid",AreaId)
                   ,new SqlParameter("@machine_id",machine_id)
                };

                dtBase = clsPublicOfPad.ExecuteProcedureReturnTable("machinestatus", paras);//DBUtility.pad_db + 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtBase;
        }

        /// <summary>
        /// 提取生產記錄，用於磅貨使用
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="prd_date1"></param>
        /// <param name="prd_date2"></param>
        /// <param name="mo1"></param>
        /// <param name="conf_date1"></param>
        /// <param name="conf_date2"></param>
        /// <param name="qc_flag"></param>
        /// <param name="conf_flag"></param>
        /// <returns></returns>
        public static DataTable GetProductQtyConfirm(string dep, string prd_date1, string prd_date2, string mo1, string conf_date1, string conf_date2, string qc_flag, string conf_flag)
        {
            DataTable dtBase = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@dep",dep)
                   ,new SqlParameter("@prd_date1",prd_date1)
                   ,new SqlParameter("@prd_date2",prd_date2)
                   ,new SqlParameter("@mo1",mo1)
                   ,new SqlParameter("@conf_date1",conf_date1)
                   ,new SqlParameter("@conf_date2",conf_date2)
                   ,new SqlParameter("@qc_flag",qc_flag)
                   ,new SqlParameter("@conf_flag",conf_flag)
                };

                dtBase = clsPublicOfPad.ExecuteProcedureReturnTable("usp_ProductQtyConfirm", paras);//DBUtility.pad_db + 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtBase;
        }

        /// <summary>
        /// 添加並單數據
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        public static int AddSingleProd_Record(List<product_records_dist_mo> lsModel)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                //判斷是否存在
                // DataTable dtIsExist = GetSingleProduct_Record(pModel.prd_id.ToString(), pModel.prd_mo);

                for (int i = 0; i < lsModel.Count; i++)
                {
                    strSql += string.Format(@"INSERT INTO product_records_dist_mo
                                                           (prd_id_ref, prd_mo_sub, prd_item_sub, prd_qty_sub, crusr, crtim)
                                                     VALUES({0}, '{1}', '{2}', {3}, '{4}', '{5}') "
                                                            , lsModel[i].prd_id_ref, lsModel[i].prd_mo_sub, lsModel[i].prd_item_sub, lsModel[i].prd_qty_sub
                                                            , lsModel[i].crusr, lsModel[i].crtim);
                }

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, null, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 修改並單數據
        /// </summary>
        /// <param name="lsModel"></param>
        /// <returns></returns>
        public static int UpdateSingleProd_Record(List<product_records_dist_mo> lsModel)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                for (int i = 0; i < lsModel.Count; i++)
                {
                    strSql += string.Format(@"UPDATE product_records_dist_mo 
                                              SET prd_qty_sub='{0}',amusr='{1}',amtim='{2}'
                                              WHERE prd_id='{3}' AND prd_mo='{4}' "
                                                 , lsModel[i].prd_qty_sub, lsModel[i].amusr, lsModel[i].amtim
                                                 , lsModel[i].prd_id_ref, lsModel[i].prd_mo_sub);
                }

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, null, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        //插入分單記錄
        public static int AddDistMo(int prd_id_ref, string prd_mo_sub, string prd_item_sub, int prd_qty_sub, string crusr, DateTime crtim)
        {
            int Result = 0;
            try
            {
                string strSql = @"insert into product_records_dist_mo (prd_id_ref,prd_mo_sub,prd_item_sub,prd_qty_sub,crusr,crtim)
                                                     Values(@prd_id_ref,@prd_mo_sub,@prd_item_sub,@prd_qty_sub,@crusr,@crtim)";

                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@prd_id_ref",prd_id_ref),
                    new SqlParameter("@prd_mo_sub",prd_mo_sub),
                    new SqlParameter("@prd_item_sub",prd_item_sub),
                    new SqlParameter("@prd_qty_sub",prd_qty_sub),
                    new SqlParameter("@crusr",crusr),
                    new SqlParameter("@crtim",crtim)
                };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        //分單時，累加生產數量
        public static int SumPrdQty(int prd_id, int prd_qty, string amusr, DateTime amtim)
        {
            int Result = 0;
            try
            {
                string strSql = @"Update product_records Set prd_qty=prd_qty+@prd_qty,amusr=@amusr,amtim=@amtim 
                    Where prd_id=@prd_id";

                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@prd_id",prd_id),
                    new SqlParameter("@prd_qty",prd_qty),
                    new SqlParameter("@amusr",amusr),
                    new SqlParameter("@amtim",amtim)
                };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        //刪除分單記錄
        public static int DelDistMo(int prd_id_ref)
        {
            int Result = 0;
            try
            {
                string strSql = @"Delete From product_records_dist_mo Where prd_id_ref=@prd_id_ref";

                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@prd_id_ref",prd_id_ref)
                };

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        #region 安排生產計劃
        public static int AddOrUpdatePrdocutionArrange(product_arrange objModel, int insert_mode)
        {
            int Result = 0;
            string strSql = "";
            SqlParameter[] paras = null;

            if (insert_mode==1)//新增排程
            {
                int prd_id = GetPrdId(objModel.prd_dep, objModel.prd_mo, objModel.prd_item);//獲取已生產制單的生產ID
                strSql = @"INSERT INTO product_arrange(arrange_id, prd_dep, prd_mo, prd_item, prd_ver
                                           , to_dep, prd_seq, arrange_date, arrange_seq, arrange_qty,mo_urgent,cust_o_date,req_f_date
                                           , estimated_date, estimated_time, req_time, arrange_machine,prd_id,rec_status,prd_worker,prd_status,crusr, crtim)
                                           VALUES(@arrange_id, @prd_dep, @prd_mo, @prd_item, @prd_ver
                                           , @to_dep, @prd_seq, @arrange_date, @arrange_seq, @arrange_qty,@mo_urgent,@cust_o_date,@req_f_date
                                          , @estimated_date, @estimated_time, @req_time, @arrange_machine,@prd_id,@rec_status,@prd_worker,@prd_status, @crusr, GETDATE())";

                paras = new SqlParameter[] {
                   new SqlParameter("@arrange_id",objModel.arrange_id),
                   new SqlParameter("@prd_dep",objModel.prd_dep),
                   new SqlParameter("@prd_mo",objModel.prd_mo),
                   new SqlParameter("@prd_item",objModel.prd_item),
                   new SqlParameter("@prd_ver",objModel.prd_ver),
                   new SqlParameter("@to_dep",objModel.to_dep),
                   new SqlParameter("@prd_seq",objModel.prd_seq),
                   new SqlParameter("@arrange_date",objModel.arrange_date),
                   new SqlParameter("@arrange_seq",objModel.arrange_seq),
                   new SqlParameter("@arrange_qty",objModel.arrange_qty),
                   new SqlParameter("@mo_urgent",objModel.mo_urgent),
                   new SqlParameter("@cust_o_date",objModel.cust_o_date),
                   new SqlParameter("@req_f_date",objModel.req_f_date),
                   new SqlParameter("@estimated_date",objModel.estimated_date),
                   new SqlParameter("@estimated_time",objModel.estimated_time),
                   new SqlParameter("@req_time",Math.Round(objModel.req_time,3)),
                   new SqlParameter("@arrange_machine",objModel.arrange_machine),
                   new SqlParameter("@prd_id",prd_id),
                   new SqlParameter("@rec_status",objModel.rec_status),
                   new SqlParameter("@prd_worker",objModel.prd_worker),
                   new SqlParameter("@prd_status",objModel.prd_status),
                   new SqlParameter("@crusr",objModel.crusr)
                };
            }
            else
            {
                if (insert_mode == 0)//修改排程
                {
                    strSql = @"UPDATE product_arrange SET arrange_date=@arrange_date,estimated_date=@estimated_date,estimated_time=@estimated_time
                     ,req_time=@req_time,arrange_machine=@arrange_machine,estimated_start_date=@estimated_start_date,estimated_start_time=@estimated_start_time
                     ,prd_worker=@prd_worker,mo_urgent=@mo_urgent,cust_o_date=@cust_o_date,req_f_date=@req_f_date,prd_status=@prd_status
                     ,amusr=@amusr, amtim=GETDATE()
                     WHERE arrange_id=@arrange_id ";
                    paras = new SqlParameter[] {
                  new SqlParameter("@arrange_id",objModel.arrange_id),
                  new SqlParameter("@arrange_date",objModel.arrange_date),
                  new SqlParameter("@estimated_date",objModel.estimated_date),
                  new SqlParameter("@estimated_time",objModel.estimated_time),
                  new SqlParameter("@estimated_start_date",objModel.estimated_start_date),
                  new SqlParameter("@estimated_start_time",objModel.estimated_start_time),
                  new SqlParameter("@req_time",Math.Round(objModel.req_time,3)),
                  new SqlParameter("@arrange_machine",objModel.arrange_machine),
                  new SqlParameter("@mo_urgent",objModel.mo_urgent),
                  new SqlParameter("@cust_o_date",objModel.cust_o_date),
                  new SqlParameter("@req_f_date",objModel.req_f_date),
                  new SqlParameter("@prd_worker",objModel.prd_worker),
                  new SqlParameter("@prd_status",objModel.prd_status),
                  new SqlParameter("@amusr",DBUtility._user_id),
                };
                }
                else
                    if (insert_mode == 2)//取消排程
                    {
                        strSql = @"UPDATE product_arrange SET rec_status=@rec_status,amusr=@amusr, amtim=GETDATE()
                     WHERE arrange_id=@arrange_id ";
                        paras = new SqlParameter[] {
                  new SqlParameter("@arrange_id",objModel.arrange_id),
                  new SqlParameter("@rec_status",objModel.rec_status),
                  new SqlParameter("@amusr",DBUtility._user_id),
                };
                    }
                    else
                        if (insert_mode == 3)//刪除排程
                        {
                            strSql = @"DELETE FROM product_arrange WHERE arrange_id=@arrange_id ";
                            paras = new SqlParameter[] {
                  new SqlParameter("@arrange_id",objModel.arrange_id),
                };
                        }
            }
            Result = clsPublicOfPad.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }

        public static int InsertPrdocutionArrange(List<product_arrange> detailsList)
        {
            int Result = 0;
            string strSql = "";
            int arrange_id = 0;
            int arrange_seq = 0;
            string wp_id = "";
            string sequence_id="",next_wp_id="";
            string comp_type = DBUtility.comp_type;
            int ver=0;
            arrange_id = GetMaxArrange_id() + 1;
            
            for (int i = 0; i < detailsList.Count; i++)
            {
                int MaxArrange_seq = GetMaxArrange_seq(detailsList[i].prd_dep, detailsList[i].arrange_machine);
                arrange_seq = MaxArrange_seq + 1;
                if (detailsList[i].prd_dep == "J07")
                    wp_id = "510";
                else
                    wp_id = detailsList[i].prd_dep;
                DataTable tbWip = GetMoWip(detailsList[i].prd_mo, wp_id, "", detailsList[i].prd_item);
                if (tbWip.Rows.Count > 0)
                {
                    sequence_id = tbWip.Rows[0]["sequence_id"].ToString();
                    next_wp_id = tbWip.Rows[0]["next_wp_id"].ToString();
                    ver = Convert.ToInt32(tbWip.Rows[0]["ver"].ToString());
                }
                else
                {
                    sequence_id = "";
                    next_wp_id = "";
                    ver = 0;
                }

                int prd_id = GetPrdId(detailsList[i].prd_dep, detailsList[i].prd_mo, detailsList[i].prd_item);//獲取已生產制單的生產ID

                strSql += string.Format(@"INSERT INTO product_arrange(
                              arrange_id, prd_dep, prd_mo, prd_item, prd_ver, to_dep, prd_seq, arrange_date, arrange_seq, arrange_qty
                              ,mo_urgent,cust_o_date,req_f_date, estimated_date, estimated_time, req_time, arrange_machine,prd_id,rec_status,crusr
                              ,wf_doc_id,wf_seq,prd_status,crtim)
                              VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}'
                              ,'{16}','{17}','{18}','{19}','{20}','{21}','{22}',GETDATE()) "
                              , arrange_id, detailsList[i].prd_dep, detailsList[i].prd_mo, detailsList[i].prd_item, ver, next_wp_id
                              , sequence_id, detailsList[i].arrange_date, arrange_seq, detailsList[i].arrange_qty
                              , "", detailsList[i].cust_o_date, detailsList[i].req_f_date, detailsList[i].estimated_date, detailsList[i].estimated_time, detailsList[i].req_time
                              , detailsList[i].arrange_machine, prd_id, detailsList[i].rec_status, detailsList[i].crusr, detailsList[i].wf_doc_id, detailsList[i].wf_seq
                              , detailsList[i].prd_status);
                //將安排標識更新到發貨表中
                strSql += string.Format(@" UPDATE dgcf_db.dbo.pu_deliver_details SET arrange_flag='Y' 
                              WHERE comp_type='{0}' AND doc_id='{1}' AND seq='{2}'", comp_type, detailsList[i].wf_doc_id, detailsList[i].wf_seq);
                arrange_id = arrange_id + 1;
            }
            if (strSql != "")
            {
                Result = clsPublicOfPad.ExecuteSqlUpdate(strSql);//更新明細記錄

            }
            else
            {
                Result = 0;

            }
            return Result;
        }

        //獲取制單資料
        public static DataTable GetMoWip(string mo_id, string fdep, string tdep, string item)
        {
            DataTable dtmo_data = new DataTable();
            try
            {
                string strSql = @" SELECT DISTINCT b.goods_id,b.prod_qty,b.next_wp_id,b.sequence_id,a.ver
                       from jo_bill_mostly a 
                       INNER join jo_bill_goods_details b on a.within_code=b.within_code and a.id=b.id and a.ver=b.ver
                       WHERE a.within_code='0000'  And a.mo_id = '" + mo_id + "'";
                if (fdep != "")
                    strSql += " And b.wp_id = '" + fdep + "' ";
                if (tdep != "")
                    strSql += " And b.next_wp_id = '" + tdep + "' ";
                if (item != "")
                {
                    strSql += " And b.goods_id ='" + item + "'";
                }
                strSql += " ORDER BY b.sequence_id";
                dtmo_data = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtmo_data;
        }

        //查找排程記錄
        public static DataTable CheckProductionArrange(string prd_dep,string prd_mo,string prd_item)
        {
            DataTable dtPrd = new DataTable();
            try
            {
                string strSql1 = @" SELECT prd_id FROM product_arrange 
                    WHERE prd_dep = '" + prd_dep + "' AND prd_mo = '" + prd_mo + "' AND prd_item = '" + prd_item + "'";
                dtPrd = clsPublicOfPad.GetDataTable(strSql1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPrd;
        }

        //提取車間工作區
        public static DataTable LoadWorkShopArea(string dep,string WorkShop)
        {
            DataTable dtArea = new DataTable();
            try
            {
                string strSql1 = @" SELECT areaid,rtrim(areadesc) AS areadesc FROM bs_workshoparea 
                    WHERE dep = '" + dep + "' AND workshop = '"+WorkShop+"'";
                dtArea = clsPublicOfPad.GetDataTable(strSql1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtArea;
        }
        //批量添加生產計劃排程
        public static int ImputPrdocutionArrangeBatch(List<product_arrange> lsModel)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                for (int i = 0; i < lsModel.Count; i++)
                {
                    int arrange_id = GetMaxArrange_id() + 1;//提取序號
                    int MaxArrange_seq = GetMaxArrange_seq(lsModel[i].prd_dep, lsModel[i].arrange_machine);//提取排程序號
                    int arrange_seq = MaxArrange_seq + 1;
                    int prd_id = GetPrdId(lsModel[i].prd_dep, lsModel[i].prd_mo, lsModel[i].prd_item);//獲取已生產制單的生產ID
                    strSql += string.Format(@" INSERT INTO product_arrange(arrange_id, prd_dep, prd_mo, prd_item, prd_ver,to_dep
                              , prd_seq, arrange_date, arrange_seq, arrange_qty,arrange_machine,prd_id,rec_status,crusr, crtim)
                              Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',GETDATE())"
                              , arrange_id, lsModel[i].prd_dep, lsModel[i].prd_mo, lsModel[i].prd_item, lsModel[i].prd_ver, lsModel[i].to_dep
                              , lsModel[i].prd_seq, lsModel[i].arrange_date,arrange_seq,lsModel[i].arrange_qty
                              , lsModel[i].arrange_machine, lsModel[i].arrange_id, lsModel[i].rec_status, lsModel[i].crusr);
                }
//                strSql += string.Format(@" INSERT INTO mo_status_print(wp_id, mo_id, goods_id, next_wp_id, ver, print_status
//                                , crusr, crtim)
//                                Values('{0}','{1}','{2}','{3}',{4},'{5}','{6}',GETDATE())"
//                                , lsModel[0].prd_dep, lsModel[0].prd_dep, lsModel[0].prd_dep
//                                , lsModel[0].prd_dep, lsModel[0].prd_dep
//                                , lsModel[0].prd_dep, lsModel[0].crusr);
                if (strSql != "")
                {
                    Result = clsPublicOfPad.ExecuteNonQuery(strSql, null, false);
                }
                else
                {
                    MessageBox.Show("數據已存在，請重新選擇需要保存的數據。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 保存調整生產順序后的計劃單。
        /// </summary>
        /// <param name="dtPa"></param>
        /// <returns></returns>
        public static int SaveChangeArrangeSeq(DataTable dtPa)
        {
            int Result = 0;
            string strSql = "";
            for (int i = 0; i < dtPa.Rows.Count; i++)
            {
                strSql += string.Format(@"UPDATE product_arrange 
                                          SET arrange_seq='{0}',estimated_date='{1}', estimated_time='{2}',estimated_start_date='{3}', estimated_start_time='{4}' ,req_time='{5}' 
                                          WHERE arrange_id='{6}' "
                                           , dtPa.Rows[i]["arrange_seq"], dtPa.Rows[i]["estimated_date"], dtPa.Rows[i]["estimated_time"], dtPa.Rows[i]["estimated_start_date"]
                                           , dtPa.Rows[i]["estimated_start_time"], dtPa.Rows[i]["req_time"], dtPa.Rows[i]["arrange_id"]);
            }

            Result = clsPublicOfPad.ExecuteNonQuery(strSql, null, false);

            return Result;
        }

        /// <summary>
        /// 保存調整生產順序后的計劃單。
        /// </summary>
        /// <param name="dtPa"></param>
        /// <returns></returns>
        public static int DeleteProductArrange(string Pa_id)
        {
            int Result = 0;
            string strSql = @"DELETE FROM product_arrange WHERE arrange_id='" + Pa_id + "'";
            Result = clsPublicOfPad.ExecuteNonQuery(strSql, null, false);

            return Result;
        }

        /// <summary>
        /// 獲取生產計劃安排
        /// </summary>
        /// <param name="prd_dep"></param>
        /// <param name="mo_id"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        public static DataTable GetProductArrange(string strSort,string prd_dep, string mo_id, string goods_id, string machine,int complete_state,int is_machine,int status)
        {
            DataTable dtPA = new DataTable();

            string strSql = @"SELECT A.arrange_id, A.prd_dep, A.prd_mo, A.prd_item, A.prd_ver
                                , A.to_dep, A.prd_seq, A.arrange_date, A.arrange_seq, A.arrange_qty
                                , A.estimated_date, A.estimated_time,A.estimated_start_date, A.estimated_start_time ,A.req_time
                                , A.arrange_machine, A.crusr, A.crtim, A.amusr, A.amtim 
                                , B.prd_date, B.prd_start_time,B.hour_std_qty,b.prd_end_time,b.prd_qty,a.rec_status,c.name AS goods_name,b.prd_req_time
                                ,a.mo_urgent,d.art_image,e.urgent_desc,a.cust_o_date,a.req_f_date,a.prd_worker
                            FROM product_arrange a
                            LEFT JOIN product_records B ON A.prd_id=B.prd_id
                            LEFT JOIN dgcf_db.dbo.geo_it_goods c ON a.prd_item COLLATE Chinese_Taiwan_Stroke_CI_AS =c.id
                            LEFT JOIN dgcf_db.dbo.bs_artwork d ON c.blueprint_id=d.art_code
                            LEFT JOIN dgcf_db.dbo.bs_urgent_grade e ON a.mo_urgent COLLATE Chinese_Taiwan_Stroke_CI_AS =e.urgent_id
                            WHERE 1>0 ";
            if (prd_dep != "")
            {
                strSql += " AND A.prd_dep='" + prd_dep + "' ";
            }

            if (mo_id != "")
            {
                strSql += " AND A.prd_mo='" + mo_id + "'";
            }

            if (goods_id != "")
            {
                strSql += " AND A.prd_item='" + goods_id + "'";
            }

            if (machine != "")
            {
                strSql += " AND A.arrange_machine='" + machine + "'";
            }
            if (complete_state == 0)//未完成
            {
                strSql += " AND b.prd_end_time='" + "" + "'";
            }
            else 
            {
                if (complete_state == 1)//已完成
                {
                    strSql += " AND b.prd_qty >= a.arrange_qty AND b.prd_end_time<>'" + "" + "'";
                }
                else
                {
                    if (complete_state == 2)//生產中
                    {
                        strSql += " AND b.prd_start_time<>'" + "" + "'"+" AND b.prd_end_time='" + "" + "'";
                    }
                }
            }
            if (is_machine == 0)//未設定機器
                strSql += " AND a.arrange_machine='" + "" + "'";
            else
            {
                if (is_machine == 1)//已設定機器
                    strSql += " AND a.arrange_machine <>'" + "" + "'";
            }
            if(status==0)
                strSql += " AND a.rec_status ='" + "0" + "'";
            else
                strSql += " AND a.rec_status ='" + "1" + "'";
            //strSql += " AND A.arrange_qty>0 AND A.arrange_qty <> '' ";
            strSql += " ORDER BY ";
            if (strSort != "")
                strSql += strSort;
            else
                strSql += " a.prd_dep,a.arrange_machine,a.arrange_seq";

            dtPA = clsPublicOfPad.GetDataTable(strSql);

            return dtPA;
        }

        /// <summary>
        ///獲取同一部門、機器下的最大生產順序號 
        /// </summary>
        /// <param name="prd_dep"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        public static int GetMaxArrange_seq(string prd_dep, string machine)
        {
            int MaxSeq = 0;
            string strSql = @"SELECT  MAX(arrange_seq) FROM product_arrange WHERE prd_dep='" + prd_dep + "' AND arrange_machine='" + machine + "'";
            string strSeq = clsPublicOfPad.ExecuteSqlReturnObject(strSql);
            if (strSeq != "")
            {
                MaxSeq = Convert.ToInt32(strSeq);
            }

            return MaxSeq;
        }

        ///獲取已在生產的制單的ID
        /// </summary>
        /// <param name="prd_dep"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        public static int GetPrdId(string prd_dep, string prd_mo,string prd_item)
        {
            int prd_id = 0;
            string strSql = @"SELECT  prd_id FROM product_records WHERE prd_dep='" + prd_dep + "' AND prd_mo='" + prd_mo + "' AND prd_item='" + prd_item + "'";
            string strPrd_id = clsPublicOfPad.ExecuteSqlReturnObject(strSql);
            if (strPrd_id != "")
            {
                prd_id = Convert.ToInt32(strPrd_id);
            }

            return prd_id;
        }

        /// <summary>
        ///獲取序號 
        /// </summary>
        /// <param name="prd_dep"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        public static int GetMaxArrange_id()
        {
            int MaxSeq = 0;
            string strSql = @"SELECT  MAX(arrange_id) FROM product_arrange ";
            string strSeq = clsPublicOfPad.ExecuteSqlReturnObject(strSql);
            if (strSeq != "")
            {
                MaxSeq = Convert.ToInt32(strSeq);
            }

            return MaxSeq;
        }

        #endregion


    }
}
