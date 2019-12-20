using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using cf01.ModuleClass;


namespace cf01.CLS
{
    public class clsPublicOfGEO
    {
        /*--------------------------------------------------------------------- 連接數據dgerp2.cferp數據的方法類------------------------------------------------------------------------*/
        //private static String strConn = DBUtility.conn_str_dgerp2;
        private String strConn = DBUtility.conn_str_dgerp2;
        private clsAppPublic clsAppPublic = new clsAppPublic();


        public clsPublicOfGEO()
        {
            //根据本机IP，连接哪一边(HK)的数据库
            string localIp = clsAppPublic.GetLocalIP();
            if(localIp.Length >= 11)
            {
            if (localIp.Substring(0, 11) == "192.168.168")
                strConn = DBUtility.conn_str_hkerp1;
            else if (localIp.Substring(0, 10) == "192.168.18" || localIp.Substring(0, 10) == "192.168.19")
                strConn = DBUtility.conn_str_lnerp1;
            }
        }
        
        public string getErpImagePath()
        {
            string imagePath = "";
            //根据本机IP，连接哪一边(HK)的数据库
            string localIp = clsAppPublic.GetLocalIP();
            if (localIp.Length >= 11 && localIp.Substring(0, 11) == "192.168.168")
                imagePath = @"\\192.168.168.15\cf_artwork\Artwork\";
            else
                imagePath = @"\\192.168.3.12\cf_artwork\Artwork\";
            return imagePath;
        }


        public DataTable GetDataTable(string strSQL)
        {
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
                    sda.Fill(dtData);
                    sda.Dispose();
                    conn.Close();
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
        public String ExecuteSqlReturnObject(string strSQL)
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
        public int ExecuteNonQuery(string strSql, SqlParameter[] paras, bool isProce)
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
        public DataTable ExecuteProcedureReturnTable(string proce, SqlParameter[] paras)
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
                    cmd.CommandTimeout = 1800;//連接30分鐘
                    cmd.CommandText = proce;
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
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
        public DataSet ExecuteProcedureReturnDataSet(string proce, SqlParameter[] paras, string TableName)
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
                    cmd.CommandTimeout = 1800;//連接30分鐘
                    cmd.CommandText = proce;
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    if(!string.IsNullOrEmpty(TableName))                    
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
        public DataSet ExcuteSqlReturnDataSet(string strSql, string TableName)
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

        public int ExecuteSqlUpdate(string strSql)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSql;
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }


        /// <summary>
        /// 執行SQL，返回 dataTable 類型
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteSqlReturnDataTable(string strSQL)
        {
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
                    sda.Fill(dtData);
                    sda.Dispose();
                    conn.Close();
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
