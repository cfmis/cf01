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
    public class clsPublicOfPad
    {
        private static String strConn = DBUtility.dgcf_pad_connectionString;

        public static int GenNo(string gen_id)
        {
            int gen_no = 0;
            DataTable dtGenNo = GetDataTable("Select gen_no from gen_no where gen_id=" + "'" + gen_id + "'");
            if (dtGenNo.Rows.Count > 0)
            {
                if (updGenNo(1, gen_id) > 0)
                    gen_no = (int)dtGenNo.Rows[0]["gen_no"];
                else
                    gen_no = 0;
            }
            else
            {
                if (updGenNo(0, gen_id) > 0)
                    gen_no = 1;
                else
                    gen_no = 0;
            }
            return gen_no;
        }

        private static int updGenNo(int upd_type, string gen_id)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                if (upd_type == 1)
                    strSql = "Update gen_no Set gen_no=gen_no+1 Where gen_id=@gen_id";
                else
                    strSql = "Insert Into gen_no (gen_id,gen_no) Values (@gen_id,2)";

                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@gen_id",gen_id)
                };

                Result = ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 執行SQL，返回 DataTable 類型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(string strSQL)
        {
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(strSQL, conn))
                    {
                        da.Fill(dtData);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dtData;
        }

        /// <summary>
        /// 執行存儲過程返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable ExecuteProcedureReturnTable(string strSql, SqlParameter[] paras)
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

        //插入記錄到排程表
        public static int ExecuteSqlUpdate(string strSql)
        {
            int Result_str =0;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSql;
                Result_str=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//
            }
            return Result_str;
        }

        //通過BarCode查找物料編號、部門等資料
        public static DataTable BarCodeToItem(string org_barcode)
        {

            DataTable dtBarCode = new DataTable();
            dtBarCode.Columns.Add("barcode_type", typeof(string));
            dtBarCode.Columns.Add("mo_id", typeof(string));
            dtBarCode.Columns.Add("goods_id", typeof(string));
            dtBarCode.Columns.Add("wp_id", typeof(string));
            dtBarCode.Columns.Add("next_wp_id", typeof(string));
            dtBarCode.Columns.Add("doc_id", typeof(string));
            dtBarCode.Columns.Add("doc_seq", typeof(string));
            DataRow dr = dtBarCode.NewRow();
            string barcode = org_barcode.Trim();
            int barcode_length = barcode.Length;

            if (barcode_length >= 13)
            {
                if (barcode_length == 16 || barcode_length == 17)//移交單的條碼/17為無生產流程的退單的條碼(RW)17
                {
                    if (barcode.Substring(0, 2) != "RW")//條形碼按單據編號查詢
                    {
                        dr["doc_id"] = barcode.Substring(0, 12);
                        dr["doc_seq"] = barcode.Substring(12, 4) + "h";
                    }
                    else//無生產流程的退單
                    {
                        dr["doc_id"] = barcode.Substring(0, 13);
                        dr["doc_seq"] = barcode.Substring(13, 4) + "h";
                    }
                    dr["barcode_type"] = "11";
                }
                else
                {
                    if ((barcode_length == 15 && barcode.Substring(0, 3) == "DAA") || (barcode_length == 15 && barcode.Substring(0, 3) == "DAB"))//倉庫發貨的條碼
                    {
                        dr["doc_id"] = barcode.Substring(0, 11);//貨倉發貨：條形碼按單據編號查詢
                        dr["doc_seq"] = barcode.Substring(11, 4) + "h";
                        dr["barcode_type"] = "12";
                    }
                    else//按制單編號查詢的條碼
                    {
                        string strSql = "";
                        string mo_id = "";
                        string seq_id = "";
                        string remote_db = DBUtility.remote_db;
                        DataTable dtItem = new DataTable();
                        mo_id = barcode.Substring(0, 9);
                        seq_id = "00" + barcode.Substring(11, 2) + "h";
                        if (barcode_length == 13)
                            strSql = " SELECT a.mo_id,b.goods_id,b.wp_id,b.next_wp_id FROM " + remote_db + "jo_bill_mostly a " +
                                    " Inner Join " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                                           " WHERE a.within_code='" + "0000" + "' AND a.mo_id ='" + mo_id + "' " + " AND b.sequence_id='" + seq_id + "'";
                        else
                        {
                            string seq_id_part = "";
                            seq_id_part = "1000" + barcode.Substring(13, 2) + "h";
                            strSql = " SELECT a.mo_id,c.materiel_id AS goods_id,c.location AS wp_id,b.wp_id AS next_wp_id " +
                                    " FROM " +
                                    remote_db + "jo_bill_mostly a " +
                                    " Inner Join " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                                    " Inner Join " + remote_db + "jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence" +
                                    " WHERE a.within_code='" + "0000" + "' AND a.mo_id ='" + mo_id + "' " + " AND b.sequence_id='" + seq_id + "'" + " AND c.sequence_id='" + seq_id_part + "'";
                        }

                        dtItem = GetDataTable(strSql);
                        if (dtItem.Rows.Count == 0)
                            MessageBox.Show("通過條碼提取的物料編號不存在!");
                        else
                        {
                            dr["barcode_type"] = "2";//條形碼從計劃單中獲取制單資料
                            dr["mo_id"] = dtItem.Rows[0]["mo_id"].ToString();
                            dr["goods_id"] = dtItem.Rows[0]["goods_id"].ToString();
                            dr["wp_id"] = dtItem.Rows[0]["wp_id"].ToString();
                            dr["next_wp_id"] = dtItem.Rows[0]["next_wp_id"].ToString();

                        }
                    }
                }
                dtBarCode.Rows.Add(dr);
            }
            else
                MessageBox.Show("未登記的條形碼!" + org_barcode);

            return dtBarCode;
        }

        /// <summary>
        /// 執行SQL，返回 dataTable 類型
        /// </summary>
        /// <returns></returns>
        public static DataTable ExecuteSqlReturnDataTable(string strSQL)
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
