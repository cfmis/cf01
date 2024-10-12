using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace cf01.CLS
{
    public class clsMoStatePrint
    {
        /// <summary>
        /// 添加打印的單據
        /// </summary>
        /// <param name="lsModel"></param>
        /// <returns></returns>
        public static int AddMoStatePrint(List<mdlMoStatePrint> lsModel)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                for (int i = 0; i < lsModel.Count; i++)
                {
                    DataTable dtIsExist = GetMoStatePrint(lsModel[i].wp_id, lsModel[i].mo_id, lsModel[i].goods_id);
                    if (dtIsExist.Rows.Count <= 0)
                    {
                        strSql += string.Format(@" INSERT INTO mo_status_print(wp_id, mo_id, goods_id, next_wp_id, ver, print_status, crusr, crtim)
                                                                        Values('{0}','{1}','{2}','{3}',{4},'{5}','{6}',GETDATE())"
                                                                             , lsModel[i].wp_id, lsModel[i].mo_id, lsModel[i].goods_id, lsModel[i].next_wp_id, lsModel[i].ver
                                                                             , lsModel[i].print_status, lsModel[i].crusr);
                    }
                }
                
                if (strSql != "")
                {
                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, null, false);
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


        //更新已儲存調整的標識
        public static int updateAdjFlag(List<mdlAdjFlag> lsModel)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                for (int i = 0; i < lsModel.Count; i++)
                {
                    strSql += string.Format(@" UPDATE jo_materiel_con_details SET adj_flag='{0}' Where within_code='{1}' AND id='{2}' AND sequence_id='{3}'"
                           , lsModel[i].adj_flag, "0000",lsModel[i].doc_id, lsModel[i].doc_seq);

                }
                //, lsModel[i].crtim
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
        /// 編輯已打印的單據
        /// </summary>
        /// <param name="lsModel"></param>
        /// <returns></returns>
        public static int UpdateMoStatePrint(List<mdlMoStatePrint> lsModel)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                for (int i = 0; i < lsModel.Count; i++)
                {
                    //strSql += string.Format(@" "
                    //                                                    , lsModel[i].wp_id, lsModel[i].mo_id, lsModel[i].goods_id, lsModel[i].next_wp_id, lsModel[i].ver
                    //                                                    , lsModel[i].print_status, lsModel[i].crusr, lsModel[i].crtim);
                }
                if (strSql != "")
                {
                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, null, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 查詢已打印的單據
        /// </summary>
        /// <param name="wp_id"></param>
        /// <param name="mo_id"></param>
        /// <param name="goods_id"></param>
        /// <returns></returns>
        public static DataTable GetMoStatePrint(string wp_id, string mo_id, string goods_id)
        {
            DataTable dtBase = new DataTable();
            try
            {
                string strSql = @" SELECT wp_id, mo_id, goods_id, next_wp_id, ver, print_status, crusr, crtim, amusr, amtim 
                                  FROM mo_status_print ";
                if (wp_id != "")
                {
                    strSql += " WHERE wp_id='" + wp_id + "' ";

                    if (mo_id != "")
                    {
                        strSql += "AND mo_id='" + mo_id + "' ";
                    }

                    if (goods_id != "")
                    {
                        strSql += "AND goods_id='" + goods_id + "' ";
                    }
                }
                else
                {
                    if (mo_id != "")
                    {
                        strSql += "WHERE mo_id='" + mo_id + "' ";

                        if (goods_id != "")
                        {
                            strSql += "AND goods_id='" + goods_id + "' ";
                        }
                    }
                    else
                    {
                        if (goods_id != "")
                        {
                            strSql += "WHERE goods_id='" + goods_id + "' ";
                        }
                    }
                }

                dtBase = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtBase;
        }

        /// <summary>
        /// 根據負責部門和下一部門查詢已打印的記錄
        /// </summary>
        /// <param name="wp_id"></param>
        /// <param name="next_wp_id"></param>
        /// <returns></returns>
        public static DataTable GetMoStatePrintForTrans(string wp_id, string next_wp_id)
        {
            DataTable dtBase = new DataTable();
            try
            {
                string strSql = @" SELECT wp_id, mo_id, goods_id, next_wp_id, ver, print_status, crusr, crtim, amusr, amtim 
                                  FROM mo_status_print ";
                if (wp_id != "")
                {
                    strSql += " WHERE wp_id='" + wp_id + "' ";

                    if (next_wp_id != "")
                    {
                        strSql += "AND next_wp_id='" + next_wp_id + "' ";
                    }
                }
                else
                {
                    if (next_wp_id != "")
                    {
                        strSql += "WHERE next_wp_id='" + next_wp_id + "' ";
                    }
                }

                dtBase = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtBase;
        }

        public static int arrangeProductMo(List<mdlProductArrange> lsModel)
        {
            int result = 0;
            string dtt = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                string id = findArrangeProductMo(lsModel[i].prdDep, lsModel[i].prdMo, lsModel[i].prdItem);
                if (id == "")
                {
                    id = lsModel[i].prdDep + dtt.Substring(0, 4) + dtt.Substring(5, 2) + dtt.Substring(8, 2) + dtt.Substring(11, 2) + dtt.Substring(14, 2) + dtt.Substring(17, 2) + (i + 1).ToString().PadLeft(4, '0');
                    strSql += string.Format(@" Insert Into dgcf_pad.dbo.product_arrange (arrange_id,now_date,prd_dep,prd_mo,prd_item,prd_ver,to_dep,prd_seq,arrange_seq,arrange_qty
                                ,crusr,crtim ) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',GETDATE())"
                                , id, lsModel[i].nowDate, lsModel[i].prdDep, lsModel[i].prdMo, lsModel[i].prdItem, lsModel[i].prdVer, lsModel[i].toDep, lsModel[i].prdSeq
                                , lsModel[i].arrangeId, lsModel[i].arrangeQty, lsModel[i].crUsr);
                }
                else
                    strSql += string.Format(@" Update dgcf_pad.dbo.product_arrange SET now_date='{1}',prd_dep='{2}',prd_mo='{3}',prd_item='{4}',prd_ver='{5}'
                                ,to_dep='{6}',prd_seq='{7}',arrange_seq='{8}',arrange_qty='{9}',amusr='{10}',amtim=GETDATE()
                                Where arrange_id='{0}' "
                                , id, lsModel[i].nowDate, lsModel[i].prdDep, lsModel[i].prdMo, lsModel[i].prdItem, lsModel[i].prdVer, lsModel[i].toDep, lsModel[i].prdSeq
                                , lsModel[i].arrangeId, lsModel[i].arrangeQty, lsModel[i].crUsr);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteNonQuery(strSql, null, false);
            return result;
        }

        private static string findArrangeProductMo(string prdDep,string prdMo,string prdItem)
        {
            string result = "";
            string strSql = "Select arrange_id From dgcf_pad.dbo.product_arrange" +
                " Where prd_dep='" + prdDep + "' And prd_mo='" + prdMo + "' And prd_item='" + prdItem + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = dt.Rows[0]["arrange_id"].ToString();
            return result;
        }

    }
}
