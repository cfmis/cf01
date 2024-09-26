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
    public class clsMaterialType
    {
        /// <summary>
        /// 新增物料種類
        /// </summary>
        /// <param name="objMat_type"></param>
        /// <returns></returns>
        public static int AddMaterialType(mdlMaterialType objMat_type)
        {
            int Result = 0;
            try
            {
                string IsExist = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format("SELECT mat_code FROM bs_mat_type WHERE mat_code='{0}' ", objMat_type.mat_code));
                if (IsExist == "")
                {
                    string strSql = @" INSERT INTO bs_mat_type(mat_code, mat_desc, mat_cdesc, mat_group, crusr, crtim)
                                                        VALUES(@mat_code, @mat_desc, @mat_cdesc, @mat_group, @crusr, GETDATE()) ";
                    SqlParameter[] paras = new SqlParameter[]{
                       new SqlParameter("@mat_code",objMat_type.mat_code),
                       new SqlParameter("@mat_desc",objMat_type.mat_desc),
                       new SqlParameter("@mat_cdesc",objMat_type.mat_cdesc),
                       new SqlParameter("@mat_group",objMat_type.mat_group),
                       new SqlParameter("@crusr",objMat_type.crusr)
                    };
                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                }
                else
                {
                    MessageBox.Show("此物料種類代號已存在，請輸入新的代號。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 編輯物料種類
        /// </summary>
        /// <param name="objMat_type"></param>
        /// <returns></returns>
        public static int UpdateMaterialType(mdlMaterialType objMat_type)
        {
            int Result = 0;
            try
            {
                string strSql = @" UPDATE bs_mat_type SET  mat_desc=@mat_desc, mat_cdesc=@mat_cdesc, mat_group=@mat_group, amusr=@amusr, amtim=GETDATE()
                                   WHERE mat_code=@mat_code ";
                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@mat_code",objMat_type.mat_code),
                   new SqlParameter("@mat_desc",objMat_type.mat_desc),
                   new SqlParameter("@mat_cdesc",objMat_type.mat_cdesc),
                   new SqlParameter("@mat_group",objMat_type.mat_group),
                   new SqlParameter("@amusr",objMat_type.amusr)
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
        /// 刪除物料種類信息
        /// </summary>
        /// <param name="pMatCode"></param>
        /// <returns></returns>
        public static int DeleteMaterialType(string pMatCode)
        {
            int Result = 0;
            try
            {
                string strSql = @" DELETE FROM bs_mat_type WHERE mat_code=@mat_code ";
                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@mat_code",pMatCode)
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
        /// 根據條件查詢物料種類信息
        /// </summary>
        /// <param name="pMatCode"></param>
        /// <returns></returns>
        public static DataTable GetMaterialType(string pMatCode)
        {
            DataTable dtMat_type = new DataTable();
            try
            {
                string strSql = @"SELECT mat_code, mat_desc, mat_cdesc, mat_group as own_groups, crusr, crtim, amusr, amtim FROM bs_mat_type ";
                if (pMatCode != "")
                {
                    strSql += " WHERE mat_code='" + pMatCode + "'";
                }

                dtMat_type = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtMat_type;
        }

    }
}
