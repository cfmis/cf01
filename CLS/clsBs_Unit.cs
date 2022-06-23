using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using cf01.ModuleClass;
using System.Data.SqlClient;

namespace cf01.CLS
{
    public class clsBs_Unit
    {
        /// <summary>
        /// 新增單位信息
        /// </summary>
        /// <param name="pEn_desc"></param>
        /// <param name="pCh_desc"></param>
        /// <returns></returns>
        public static int AddUnit(string pUnit_Id, string pEn_desc, string pCh_desc)
        {
            int Result = 0;
            try
            {
                string strUnitId = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format(" select  unit_id from bs_unit where unit_id='{0}' ", pUnit_Id));
                if (strUnitId == "")
                {
                    string strSql = @" INSERT INTO bs_unit(unit_id,unit_desc,unit_cdesc,crusr,crtim)VALUES(@unit_id,@unit_desc,@unit_cdesc,@crusr,GETDATE()) ";
                    SqlParameter[] paras = new SqlParameter[] { 
                      new SqlParameter("@unit_id",pUnit_Id),
                      new SqlParameter("@unit_desc",pEn_desc),
                      new SqlParameter("@unit_cdesc",pCh_desc),
                      new SqlParameter("@crusr",DBUtility._user_id)
                    };

                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                }
                else
                {
                    MessageBox.Show("該Id已存在,請重新輸入單位Id.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Result;
        }

        /// <summary>
        /// 編輯單位信息
        /// </summary>
        /// <param name="pEn_desc"></param>
        /// <param name="pCh_desc"></param>
        /// <returns></returns>
        public static int UpdateUnit(string pUnit_Id, string pEn_desc, string pCh_desc)
        {
            int Result = 0;
            try
            {
                string strSql = @" UPDATE bs_unit SET unit_desc=@unit_desc,unit_cdesc=@unit_cdesc,amusr=@amusr,amtim=GETDATE() WHERE unit_id=@unit_id ";
                SqlParameter[] paras = new SqlParameter[] { 
                      new SqlParameter("@unit_id",pUnit_Id),
                      new SqlParameter("@unit_desc",pEn_desc),
                      new SqlParameter("@unit_cdesc",pCh_desc),
                      new SqlParameter("@amusr",DBUtility._user_id)
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
        ///刪除單位信息 
        /// </summary>
        /// <param name="pUnit_id"></param>
        /// <returns></returns>
        public static int DeleteUnit(string pUnit_Id)
        {
            int Result = 0;
            try
            {
                string strSql = @" DELETE FROM bs_unit WHERE unit_id=@unit_id ";
                SqlParameter[] paras = new SqlParameter[] { 
                      new SqlParameter("@unit_id",pUnit_Id)
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
        /// 查詢單位信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUnitsData(string pUnit_Id)
        {
            DataTable dtUnit = new DataTable();
            try
            {
                string strSql = @" SELECT unit_id,unit_desc,unit_cdesc,crusr,crtim,amusr,amtim FROM bs_unit ";
                if (pUnit_Id != "")
                {
                    strSql += " WHERE unit_id='" + pUnit_Id + "' ";
                }

                dtUnit = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtUnit;
        }
        public static DataTable LoadUnit(string unit_flag)
        {
            string strSql = @" SELECT unit_id,unit_desc,unit_cdesc FROM bs_unit ";
            if (unit_flag != "")
            {
                strSql += " WHERE unit_flag='" + unit_flag + "' ";
            }

            DataTable dtUnit = clsPublicOfCF01.GetDataTable(strSql);
            return dtUnit;
        }

    }
}
