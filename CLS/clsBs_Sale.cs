using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using cf01.MDL;
using System.Windows.Forms;
using System.Data;

namespace cf01.CLS
{
    public class clsBs_Sale
    {
        /// <summary>
        /// 新增營業員
        /// </summary>
        /// <param name="objSaler"></param>
        /// <returns></returns>
        public static int AddSaler(mdlSale objSaler)
        {
            int Result = 0;
            try
            {
                string IsExist = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format("SELECT sale_code FROM bs_sale WHERE sale_code='{0}' ", objSaler.sale_code));
                if (IsExist == "")
                {
                    string strSql = @" INSERT INTO bs_sale (sale_code, sale_desc, sale_cdesc, sale_short_name, sale_group, crusr, crtim) 
                                                     VALUES(@sale_code, @sale_desc, @sale_cdesc, @sale_short_name, @sale_group, @crusr, GETDATE()) ";
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@sale_code",objSaler.sale_code),
                       new SqlParameter("@sale_desc",objSaler.sale_desc),
                       new SqlParameter("@sale_cdesc",objSaler.sale_cdesc),
                       new SqlParameter("@sale_short_name",objSaler.sale_short_name),
                       new SqlParameter("@sale_group",objSaler.sale_group),
                       new SqlParameter("@crusr",objSaler.crusr)
                    };

                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                }
                else
                {
                    MessageBox.Show("此營業員編號已存在,請輸入新的編號.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 編輯營業員
        /// </summary>
        /// <param name="objSaler"></param>
        /// <returns></returns>
        public static int UpdateSaler(mdlSale objSaler)
        {
            int Result = 0;
            try
            {
                string strSql = @" UPDATE bs_sale SET sale_desc=@sale_desc, sale_cdesc=@sale_cdesc, sale_short_name=@sale_short_name, sale_group=@sale_group, amusr=@crusr, amtim=GETDATE() 
                                   WHERE sale_code=@sale_code ";
                SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@sale_code",objSaler.sale_code),
                       new SqlParameter("@sale_desc",objSaler.sale_desc),
                       new SqlParameter("@sale_cdesc",objSaler.sale_cdesc),
                       new SqlParameter("@sale_short_name",objSaler.sale_short_name),
                       new SqlParameter("@sale_group",objSaler.sale_group),
                       new SqlParameter("@crusr",objSaler.crusr)
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
        /// 刪除營業員信息
        /// </summary>
        /// <param name="pSalerCode"></param>
        /// <returns></returns>
        public static int DeleteSaler(string pSaleCode)
        {
            int Result = 0;
            try
            {
                string strSql = @" DELETE FROM bs_sale WHERE sale_code=@sale_code ";
                SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter("@sale_code",pSaleCode)
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
        /// 查詢營業員信息
        /// </summary>
        /// <param name="pSalerCode"></param>
        /// <returns></returns>
        public static DataTable GetSaler(string pSaleCode)
        {
            DataTable dtSaler = new DataTable();
            try
            {
                string strSql = @" SELECT sale_code, sale_desc, sale_cdesc, sale_short_name as Short_name, sale_group as own_groups, crusr, crtim, amusr, amtim FROM bs_sale ";
                if (pSaleCode != "")
                {
                    strSql += " WHERE sale_code='" + pSaleCode + "' ";
                }

                dtSaler = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtSaler;
        }
    }
}
