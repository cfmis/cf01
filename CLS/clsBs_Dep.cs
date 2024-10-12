using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using System.Data;

namespace cf01.CLS
{
    public class clsBs_Dep
    {
        /// <summary>
        /// 新增部門信息
        /// </summary>
        /// <param name="pDept_id"></param>
        /// <param name="pDept_desc"></param>
        /// <param name="pDept_cdesc"></param>
        /// <param name="pDept_group"></param>
        /// <returns></returns>
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        public static int AddDepartment(string pDept_id, string pDept_desc, string pDept_cdesc, string pDept_group)
        {
            int Result = 0;
            try
            {
                string strUnitId = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format(" SELECT dep_id FROM bs_dep WHERE dep_id='{0}' ", pDept_id));
                if (strUnitId == "")
                {
                    string strSql = @" INSERT INTO bs_dep(dep_id,dep_desc,dep_cdesc,dep_group,crusr,crtim)VALUES(@dep_id,@dep_desc,@dep_cdesc,@dep_group,@crusr,GETDATE()) ";
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@dep_id",pDept_id),
                       new SqlParameter("@dep_desc",pDept_desc),
                       new SqlParameter("@dep_cdesc",pDept_cdesc),
                       new SqlParameter("@dep_group",pDept_group),
                       new SqlParameter("@crusr",DBUtility._user_id)
                    };

                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                }
                else
                {
                    MessageBox.Show("該Id已存在,請重新輸入部門Id.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 修改部門信息
        /// </summary>
        /// <param name="pDept_id"></param>
        /// <param name="pDept_desc"></param>
        /// <param name="pDept_cdesc"></param>
        /// <param name="pDept_group"></param>
        /// <returns></returns>
        public static int UpdateDepartment(string pDept_id, string pDept_desc, string pDept_cdesc, string pDept_group)
        {
            int Result = 0;
            try
            {
                string strSql = @" UPDATE bs_dep SET dep_desc=@dep_desc,dep_cdesc=@dep_cdesc,dep_group=@dep_group,amusr=@amusr,amtim=GETDATE() WHERE dep_id=@dep_id ";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@dep_id",pDept_id),
                    new SqlParameter("@dep_desc",pDept_desc),
                    new SqlParameter("@dep_cdesc",pDept_cdesc),
                    new SqlParameter("@dep_group",pDept_group),
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
        /// 刪除部門信息
        /// </summary>
        /// <param name="pDept_id"></param>
        /// <returns></returns>
        public static int DeleteDepartment(string pDept_id)
        {
            int Result = 0;
            try
            {
                string strSql = @" DELETE FROM bs_dep WHERE dep_id=@dep_id ";
                SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter("@dep_id",pDept_id)
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
        /// 查詢部門信息
        /// </summary>
        /// <param name="pDept_id"></param>
        /// <returns></returns>
        public static DataTable GetDepartments(string pDept_id)
        {
            DataTable dtDept = new DataTable();
            try
            {
                string strSql = @" SELECT dep_id,dep_desc,dep_cdesc,dep_group,crusr,crtim,amusr,amtim FROM bs_dep ";
                if (pDept_id != "")
                {
                    strSql += " WHERE dep_id='" + pDept_id + "' ";
                }

                dtDept = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtDept;
        }

        /// <summary>
        ///dgerp2.cferp.cd_department 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllDepartment()
        {
            DataTable dtDept = new DataTable();
            try
            {
                string strSql = @" SELECT id,name FROM cd_department";
                dtDept = clsPublicOfGEO.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtDept;
        }

        public static DataTable GetAll_WH()
        {
            DataTable dtDept = new DataTable();
            try
            {
                string strSql = @"SELECT id,name FROM cd_productline WHERE within_code ='0000' AND storehouse_group='DG' AND type='01' and state<>'2'";
                dtDept = clsPublicOfGEO.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtDept;
        }
    }
}
