using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.ModuleClass;

namespace cf01.CLS
{
    public class clsPublicOfCF01
    {
        /*--------------------------------------------------------------------- 連接數據dgsql2.dgcf_db數據的方法類------------------------------------------------------------------------*/
        private static String strConn = DBUtility.connectionString;

        /// <summary>
        /// 執行SQL，返回 dataTable 類型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(string strSQL)
        {
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
                    sda.Fill(dtData);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dtData;
        }

        /// <summary>
        /// 執行SQL 語句，返回string
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static String ExecuteSqlReturnObject(string strSQL)
        {
            string objStrValue = "";
            try
            {
                DataTable dts = GetDataTable(strSQL);
                if (dts.Rows.Count > 0)
                {
                    objStrValue = dts.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return objStrValue;
        }

        /// <summary>
        /// 執行sql 語句或存儲過程，返回結果 int 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <param name="isProce"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string strSql, SqlParameter[] paras, bool isProce)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    if (isProce)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    Result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 執行存儲過程，返回DataTable
        /// </summary>
        /// <param name="proce"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable ExecuteProcedureReturnTable(string proce, SqlParameter[] paras)
        {
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = proce;
                    cmd.CommandTimeout = 1800;//連接30分鐘
                    cmd.Parameters.AddRange(paras);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtData;
        }

        /// <summary>
        /// 執行存儲過程，返回DataSet
        /// </summary>
        /// <param name="proce"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataSet ExecuteProcedureReturnDataSet(string proce, SqlParameter[] paras, string TableName)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();                    
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = proce;
                    cmd.CommandTimeout = 1800;//連接30分鐘
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    if (!string.IsNullOrEmpty(TableName))
                    {
                        sda.Fill(ds, TableName);
                    }
                    else
                    {
                        sda.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        /// <summary>
        ///執行Sql語句，返回DataSet 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataSet ExcuteSqlReturnDataSet(string strSql, string TableName)
        {
            SqlConnection m_Conn = null;
            DataSet ds = new DataSet();
            try
            {
                m_Conn = new SqlConnection(strConn);
            }
            catch (Exception er)
            {
                throw er;
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(strSql, m_Conn);
                if (!string.IsNullOrEmpty(TableName))
                {
                    sda.Fill(ds, TableName);
                }
                else
                {
                    sda.Fill(ds);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            m_Conn.Close();
            return ds;
        }
        public static string ExecuteSqlUpdate(string strSql)
        {
            string Result_str = "";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Result_str = ex.Message;//
            }
            return Result_str;
        }


        public static bool ExecuteSqlUpdateQuery(StringBuilder toquery)
        {
            bool result = false;
            string err_str;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand(toquery.ToString(), conn);
            try
            {
                if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                {
                    result = true;

                }
                conn.Close();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
                err_str = ex.Message;
            }
            return result;
        }

        /// <summary>
        ///執行存儲過程，返回dataTable 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable ExecuteProcedure(string strSql, SqlParameter[] paras)
        {
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paras);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtData;
        }
    }
}
