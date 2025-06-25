using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsPrdTransfer
    {
        /// <summary>
        /// 查詢已確認收貨的移交單
        /// </summary>
        /// <param name="pIn_dept">收貨部門</param>
        /// <param name="pOut_dept">發貨部門</param>
        /// <param name="pCon_date_from">收貨日期</param>
        /// <param name="pCon_date_to"></param>
        /// <returns></returns>
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public static DataTable GetTransferInfo(string pIn_dept, string pOut_dept, 
                                               string pCon_date_from, string pCon_date_to,int Select_Index, 
                                               string mo1,string mo2,bool adj_flag)
        {
            DataTable dtTransfer = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder(
                                  @"SELECT Distinct a.mo_id ,a.id ,a.sequence_id ,a.goods_id ,a.lot_no
                                        ,a.con_qty ,a.sec_qty ,a.package_num ,a.actual_qty ,a.actual_weg
                                        ,a.actual_pack ,Convert(varchar(10),b.con_date,111) as con_date ,b.out_dept ,b.in_dept ,c.name as goods_name
                                        ,Convert(varchar(20),a.crtim,20) as crtim,a.imput_flag,Convert(varchar(20),a.imput_time,20) as imput_time,a.adj_flag
                                  FROM jo_materiel_con_details as a WITH(NOLOCK)
                                  INNER JOIN jo_materiel_con_mostly b WITH(NOLOCK) on a.within_code=b.within_code and a.id=b.id
                                  LEFT JOIN dgsql2.dgcf_db.dbo.geo_it_goods c WITH(NOLOCK) on a.goods_id=c.id COLLATE Chinese_Taiwan_Stroke_CI_AS                                  
                                  WHERE b.within_code='0000' ");

                if (pIn_dept != "")
                {
                    sb.Append(String.Format(" AND b.in_dept='{0}' ", pIn_dept));
                }
                if (pOut_dept != "")
                {
                    sb.Append(String.Format(" AND b.out_dept='{0}' ", pOut_dept));
                }
                if (pCon_date_from != "" && pCon_date_to != "")
                {
                    sb.Append(String.Format(" AND a.crtim>='{0}' and a.crtim<='{1}'", pCon_date_from, pCon_date_to));
                }
                if (mo1 != "" && mo2 != "")
                {
                    sb.Append(String.Format(" AND a.mo_id>='{0}' and a.mo_id<='{1}'", mo1, mo2));
                }
                if (adj_flag == false)
                {
                    sb.Append(string.Format(" AND a.adj_flag <> '{0}'", "Y"));
                }
                sb.Append(" Order By a.id,a.sequence_id");

                DataTable dtTemp = clsPublicOfPad.GetDataTable(sb.ToString());//根據條件查出PAD生成移交數據
                DataTable dtHadPrint = dtTemp.Copy();
                DataTable dtNoPrint = dtTemp.Copy();
                dtHadPrint.Rows.Clear();
                dtNoPrint.Rows.Clear();
                DataTable dtMoStatePrint = clsMoStatePrint.GetMoStatePrintForTrans(pOut_dept, pIn_dept);//查出已列印的歷史數據
                if (dtTemp.Rows.Count > 0 && dtMoStatePrint.Rows.Count > 0)
                {
                    DataRow[] drs ;
                    string strFilter;
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        strFilter = string.Format(@"wp_id='{0}' and mo_id='{1}' and goods_id='{2}' and next_wp_id='{3}'",
                            dtTemp.Rows[i]["out_dept"], dtTemp.Rows[i]["mo_id"],
                            dtTemp.Rows[i]["goods_id"], dtTemp.Rows[i]["in_dept"]);
                        drs = dtMoStatePrint.Select(strFilter);
                        if (drs.Length > 0)
                        {
                            dtHadPrint.Rows.Add(dtTemp.Rows[i].ItemArray); //查找出已列印的數據添加到表dtHadPrint中
                        }
                        else
                        {
                            dtNoPrint.Rows.Add(dtTemp.Rows[i].ItemArray);  //未曾列印過的數據
                        }
                        
                        ////bool IsRepeat = false;
                        //for (int j = 0; j < dtMoStatePrint.Rows.Count; j++)
                        //{
                        //    if (dtTemp.Rows[i]["out_dept"].ToString() == dtMoStatePrint.Rows[j]["wp_id"].ToString() &&
                        //        dtTemp.Rows[i]["mo_id"].ToString() == dtMoStatePrint.Rows[j]["mo_id"].ToString() &&
                        //        dtTemp.Rows[i]["goods_id"].ToString() == dtMoStatePrint.Rows[j]["goods_id"].ToString() &&
                        //        dtTemp.Rows[i]["in_dept"].ToString() == dtMoStatePrint.Rows[j]["next_wp_id"].ToString())
                        //    {
                        //        dtHadPrint.Rows.Add(dtTemp.Rows[i].ItemArray); //查找出已列印的數據添加到表dtHadPrint中
                        //        //IsRepeat = true;
                        //    }
                        //    else
                        //    {
                        //        //if (j == dtMoStatePrint.Rows.Count - 1 && IsRepeat == false)
                        //        if (j == dtMoStatePrint.Rows.Count - 1)
                        //        {
                        //            dtNoPrint.Rows.Add(dtTemp.Rows[i].ItemArray);
                        //        }
                        //    }
                        //}                        

                    }
                }

                switch (Select_Index)
                {
                    case 0:
                        dtTransfer = dtNoPrint; //未列印的記錄
                        break;
                    case 1:
                        dtTransfer = dtHadPrint; //已列印的記錄
                        break;
                    case 2:
                        dtTransfer = dtTemp;    //全部的記錄(即包括未列印、已列印)
                        break;
                } 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtTransfer;
        }

        /// <summary>
        /// 查詢已確認收貨的移交單 for frmShowPlan
        /// </summary>
        /// <param name="pMo_id"></param>
        /// <returns></returns>
        public static DataTable GetTransferInfoByShowPlan(string pMo_id)
        {
            DataTable dtTransfer = new DataTable();
            try
            {
                string strSql = @"SELECT distinct a.mo_id ,a.id ,a.sequence_id ,a.goods_id ,a.lot_no
                                         ,a.con_qty ,a.sec_qty ,a.package_num ,a.actual_qty ,a.actual_weg
                                         ,a.actual_pack ,convert(varchar(10),b.con_date,111)as con_date ,b.out_dept ,b.in_dept ,c.name as goods_name
                                  FROM jo_materiel_con_details as a
                                  INNER JOIN jo_materiel_con_mostly b on a.within_code=b.within_code and a.id=b.id
                                  LEFT JOIN dgsql2.dgcf_db.dbo.geo_it_goods c on a.goods_id=c.id  COLLATE Chinese_Taiwan_Stroke_CI_AS ";

                strSql += " WHERE a.mo_id='" + pMo_id + "' ";

                dtTransfer = clsPublicOfPad.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtTransfer;
        }


        /// <summary>
        /// 獲取生產單信息
        /// </summary>
        /// <param name="pMo_id"></param>
        /// <param name="pGoods_id"></param>
        /// <returns></returns>
        public static DataTable GetPOData(string pMo_id, string pWp_id, string pMater_id,bool noPrintQc)
        {
            DataTable dtPO = new DataTable();
            try
            {
                string oc_test_name;//OC的測試項目
                string strSql = @" SELECT  DISTINCT b.id,b.wp_id ,'' as prd_dept_name ,a.mo_id ,b.goods_id ,c.name as goods_name ,convert(varchar(10),b.t_complete_date,111)as t_complete_date
                                           , b.next_wp_id ,d.name AS next_wp_name ,convert(DECIMAL(18,0),b.order_qty)as order_qty ,convert(DECIMAL(18,0),b.prod_qty)as prod_qty ,b.goods_unit
                                           , a.customer_id ,a.remark ,f.production_remark ,f.nickle_free,f.plumbum_free,g.do_color ,g.name as color_name,'' as picture_name ,a.ver ,b.sequence_id ,'' as BarCode
                                    FROM  dbo.jo_bill_mostly a with(nolock)
                                    INNER JOIN dbo.jo_bill_goods_details b with(nolock)ON  a.within_code = b.within_code AND  a.id = b.id AND  a.ver = b.ver
                                    INNER JOIN dbo.Jo_bill_materiel_details m with(nolock)ON b.within_code=m.within_code and b.id=m.id and b.ver=m.ver and b.sequence_id=m.upper_sequence
                                    INNER JOIN dbo.it_goods c with(nolock) ON  b.within_code = c.within_code AND  b.goods_id = c.id
                                    INNER JOIN dbo.cd_department d ON b.within_code=d.within_code And b.next_wp_id=d.id
                                    LEFT OUTER JOIN dbo.so_order_details e with(nolock) ON a.within_code=e.within_code AND a.mo_id=e.mo_id AND a.so_sequence_id=e.sequence_id
                                    LEFT OUTER JOIN dbo.so_order_special_info f with(nolock) ON e.within_code=f.within_code AND e.id=f.id AND e.sequence_id=f.upper_sequence AND e.ver=f.ver
                                    LEFT OUTER JOIN cd_color g with(nolock) on c.within_code=g.within_code and c.color=g.id
                                    WHERE a.mo_id='" + pMo_id + "'AND b.wp_id='" + pWp_id + "' AND m.materiel_id='" + pMater_id + "'";

                if (noPrintQc == true)
                    strSql += " AND b.next_wp_id <> '701' AND b.next_wp_id <> '702' ";
                dtPO = clsConErp.GetDataTable(strSql);

                if (dtPO.Rows.Count > 0)
                {
                    oc_test_name = GetOcQcTest(pMo_id);//獲取OC的QC測試項目
                    for (int i = 0; i < dtPO.Rows.Count; i++)
                    {
                        dtPO.Rows[i]["prd_dept_name"] = GetDept_name(dtPO.Rows[i]["wp_id"].ToString());  //獲得部門名稱
                        //if (dtPO.Rows[i]["ver"].ToString() != "0")
                        //    dtPO.Rows[i]["mo_id"] = dtPO.Rows[i]["mo_id"].ToString().Trim() + "(" + dtPO.Rows[i]["ver"].ToString().Trim() + ")";
                        //取得圖片
                        DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(dtPO.Rows[i]["goods_id"].ToString());
                        if (dtArt.Rows.Count > 0)
                        {
                            dtPO.Rows[i]["picture_name"] = dtArt.Rows[0]["picture_name"];
                        }
                        dtPO.Rows[i]["production_remark"] = (dtPO.Rows[i]["nickle_free"].ToString().Trim() == "1" ? "無叻;" : "")
                            +(dtPO.Rows[i]["plumbum_free"].ToString().Trim() == "1" ? "無鉛;" : "")
                            + dtPO.Rows[i]["production_remark"].ToString().Trim() + oc_test_name ;
                        //生成條碼內容
                        dtPO.Rows[i]["BarCode"] = clsMo_for_jx.ReturnBarCode(dtPO.Rows[i]["mo_id"].ToString() + "0" + dtPO.Rows[i]["ver"].ToString() + dtPO.Rows[i]["sequence_id"].ToString().Substring(2, 2));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPO;
        }
        //獲取部門描述
        public static string GetDept_name(string pDept_id)
        {
            string Dept_name = "";
            try
            {
                DataTable dtDept = new DataTable();
                string strSql = @" SELECT id,name FROM cd_department WHERE id ='" + pDept_id + "'";
                dtDept = clsConErp.GetDataTable(strSql);

                if (dtDept.Rows.Count > 0)
                {
                    Dept_name = dtDept.Rows[0]["name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Dept_name;
        }
        //獲取OC中QC的特別測試
        public static string GetOcQcTest(string mo_id)
        {
            string test_name = "";
            try
            {
                DataTable dtOcQcTest = new DataTable();
                string strSql = @"SELECT a.mo_id, b.sequence_id,b.test_item_type, b.test_item_id,c.test_item_name
                        FROM dbo.so_order_details a 
                        INNER JOIN dbo.So_order_special_qc b ON  a.within_code = b.within_code AND  a.id = b.id AND  a.ver = b.ver  AND a.sequence_id = b.upper_sequence
                        INNER JOIN dbo.cd_qc_test_item c ON  b.within_code = c.within_code AND  b.test_item_type = c.test_item_type AND  b.test_item_id = c.test_item_id
                        WHERE  a.within_code = '0000' AND  a.mo_id = '" + mo_id + "'" + " AND b.test_item_type='INSIDE' ";
                dtOcQcTest = clsConErp.GetDataTable(strSql);
                for (int i = 0; i < dtOcQcTest.Rows.Count;i++ )
                {
                    test_name += ";"+dtOcQcTest.Rows[i]["test_item_name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return test_name;

        }
        /// <summary>
        /// 獲取配件名稱及顏色
        /// </summary>
        /// <param name="pmo_id"></param>
        /// <returns></returns>
        public static DataTable GetPartsOfColor(string p_id,string pmo_id,string seq)
        {
            DataTable dtParts = new DataTable();
            try
            {
                string strSql = 
                @" SELECT distinct a.goods_id as part_goods_id ,b.name as part_goods_name ,Isnull(c.picture_name_h,'') as picture_name,e.name as color_name ,'' as Ser_no ,'' as mo_id
                FROM so_order_details d with(nolock)
                INNER JOIN  so_order_bom a with(nolock) ON d.id=a.id And d.sequence_id = a.upper_sequence
                INNER JOIN it_goods b with(nolock) ON a.within_code=b.within_code And a.goods_id=b.id
                LEFT JOIN dbo.cd_pattern c with(nolock) ON b.within_code=c.within_code And b.blueprint_id=c.id
                LEFT JOIN dbo.cd_color e with(nolock) ON b.within_code=e.within_code And b.color = e.id
                WHERE d.mo_id='" + pmo_id + "'";
                strSql = 
                @"SELECT DISTINCT b.materiel_id AS part_goods_id,c.name AS part_goods_name,Isnull(d.picture_name_h,'') as picture_name,e.name as color_name,'' as Ser_no,'' as mo_id
                FROM jo_bill_goods_details a with(nolock)
                INNER JOIN  jo_bill_materiel_details b with(nolock) ON a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.sequence_id = b.upper_sequence
                INNER JOIN it_goods c with(nolock) on b.within_code=c.within_code And b.materiel_id=c.id
                LEFT JOIN dbo.cd_pattern d with(nolock) ON c.within_code=d.within_code And c.blueprint_id=d.id
                LEFT JOIN dbo.cd_color e with(nolock) ON c.within_code=e.within_code And c.color = e.id
                WHERE a.id='" + p_id + "'" + " and a.sequence_id='"+seq+"'";
                dtParts = clsConErp.GetDataTable(strSql);

                if (dtParts.Rows.Count > 0)
                {
                    //過濾重複數據
                    DataView myDataView = new DataView(dtParts);
                    //此处可加任意数据项组合  
                    string[] strComuns = { "part_goods_id", "part_goods_name", "picture_name", "color_name", "Ser_no", "mo_id" };
                    dtParts = myDataView.ToTable(true, strComuns);

                    //添加序號
                    for (int i = 0; i < dtParts.Rows.Count; i++)
                    {
                        dtParts.Rows[i]["Ser_no"] = (i + 1);
                        dtParts.Rows[i]["mo_id"] = pmo_id;
                        dtParts.Rows[i]["part_goods_name"] = String.Format("{0}|{1}", dtParts.Rows[i]["part_goods_name"], dtParts.Rows[i]["color_name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtParts;
        }

        #region 安排生產功能
        /// <summary>
        /// 獲取物料信息
        /// </summary>
        /// <param name="mo_id">制單編號</param>
        /// <param name="prd_dept">生產部門</param>
        /// <param name="item">物料編號</param>
        /// <returns></returns>
        public static DataTable GetMo_dataById(string mo_id, string prd_dept, string item)
        {
            DataTable dtMo_data = new DataTable();
            try
            {
                string strSql = @"SELECT b.goods_id,c.name as name,b.prod_qty,b.next_wp_id,d.materiel_id AS mat_item,e.name AS mat_item_desc
                                   from jo_bill_mostly a 
                                   INNER join jo_bill_goods_details b on a.within_code=b.within_code and a.id=b.id 
                                   INNER JOIN it_goods c on b.within_code=c.within_code and b.goods_id=c.id 
                                   INNER JOIN jo_bill_materiel_details d ON b.within_code=d.within_code and b.id=d.id and b.ver=d.ver and b.sequence_id=d.upper_sequence
                                   INNER JOIN it_goods e ON d.within_code=e.within_code and d.materiel_id=e.id
                                   WHERE a.within_code='0000'  And a.mo_id = '" + mo_id + "' And b.wp_id = '" + prd_dept + "' And d.materiel_id ='" + item + "'";
                strSql += " AND b.next_wp_id <> '701' AND b.next_wp_id <> '702' ";//不將到QC的加入安排生產
                dtMo_data = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtMo_data;
        }

        /// <summary>
        /// 添加制單編號資料
        /// </summary>
        /// <param name="prd_records"></param>
        /// <returns></returns>
        public static int AddProductionRecords(List<product_records> lsPrdRecords)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                for (int i = 0; i < lsPrdRecords.Count; i++)
                {
                    strSql += string.Format(@" INSERT INTO product_records
                                                          (prd_id ,prd_dep ,prd_date ,prd_mo ,prd_item ,prd_qty ,prd_work_type ,crtim ,crusr,prd_pdate)
                                                    VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',GETDATE(),'{8}','{9}') "
                                                           , lsPrdRecords[i].prd_id, lsPrdRecords[i].prd_dep, lsPrdRecords[i].prd_date, lsPrdRecords[i].prd_mo, lsPrdRecords[i].prd_item
                                                           , lsPrdRecords[i].prd_qty, lsPrdRecords[i].prd_work_type, lsPrdRecords[i].crtim, lsPrdRecords[i].crusr, lsPrdRecords[i].prd_pdate);
                }

                Result = clsPublicOfPad.ExecuteNonQuery(strSql, null, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }



        #endregion


    }
}
