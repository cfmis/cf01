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
    public class clsProductType
    {
        /// <summary>
        /// 新增產品種類
        /// </summary>
        /// <param name="objPrductType"></param>
        /// <returns></returns>
        public static int AddProductType(mdlProductType objPrductType)
        {
            int Result = 0;
            try
            {
                string IsExist = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format("SELECT prd_code FROM bs_product_type WHERE prd_code='{0}' ", objPrductType.prd_code));

                if (IsExist == "")
                {
                    string strSql = @" INSERT INTO bs_product_type(prd_code, prd_desc, prd_cdesc, prd_group, crusr, crtim)
                                                        VALUES(@prd_code, @prd_desc, @prd_cdesc, @prd_group, @crusr,GETDATE()) ";
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@prd_code",objPrductType.prd_code),
                       new SqlParameter("@prd_desc",objPrductType.prd_desc),
                       new SqlParameter("@prd_cdesc",objPrductType.prd_cdesc),
                       new SqlParameter("@prd_group",objPrductType.prd_group),
                       new SqlParameter("@crusr",objPrductType.crusr)
                    };
                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                }
                else
                {
                    MessageBox.Show("此產品種類編號已存在，請輸入新的編號。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 編輯產品種類
        /// </summary>
        /// <param name="objPrductType"></param>
        /// <returns></returns>
        public static int UpdateProductType(mdlProductType objPrductType)
        {
            int Result = 0;
            try
            {
                string strSql = @" UPDATE bs_product_type SET prd_desc=@prd_desc, prd_cdesc=@prd_cdesc, prd_group=@prd_group, amusr=@amusr, amtim=GETDATE()
                                   WHERE prd_code=@prd_code ";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@prd_code",objPrductType.prd_code),
                    new SqlParameter("@prd_desc",objPrductType.prd_desc),
                    new SqlParameter("@prd_cdesc",objPrductType.prd_cdesc),
                    new SqlParameter("@prd_group",objPrductType.prd_group),
                    new SqlParameter("@amusr",objPrductType.amusr)
               };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 刪除產品種類
        /// </summary>
        /// <param name="pPrdCode"></param>
        /// <returns></returns>
        public static int DeleteProductType(string pPrdCode)
        {
            int Result = 0;
            try
            {
                string strSql = @"DELETE FROM bs_product_type WHERE prd_code=@prd_code ";
                SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter("@prd_code",pPrdCode)
               };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 獲取產品種類
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProductType(string pPrdCode)
        {
            DataTable dtPrd_Type = new DataTable();
            try
            {
                string strSql = @" SELECT prd_code, prd_desc, prd_cdesc, prd_group as own_groups, crusr, crtim, amusr, amtim FROM bs_product_type ";
                if (pPrdCode != "")
                {
                    strSql += " WHERE prd_code='" + pPrdCode + "'";
                }
                dtPrd_Type = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPrd_Type;
        }

    }
}
