using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using cf01.CLS;
using cf01.Forms;
using System.Threading;

namespace cf01.ReportForm
{
    public partial class frmTommy : Form
    {
        private clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        bool flag_import;
        string strFile_Excel;
        public frmTommy()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            open_excel();
        }

        private void open_excel()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "Execl files (*.xls)|*.xls", FilterIndex = 0, RestoreDirectory = true, Title = "導入EXCEL文件路徑", FileName = null };
            openFileDialog1.ShowDialog();
            strFile_Excel = openFileDialog1.FileName;
            Refresh();
            if (string.IsNullOrEmpty(strFile_Excel))
            {
                return;
            }
            if (!File.Exists(strFile_Excel))
            {
                MessageBox.Show("指定的EXCEL文件不存在，請返回檢查!");
                return;
            }

            flag_import = false;            
            Load_Excel("1");
            if (flag_import)
            {
                MessageBox.Show("導入EXCEL成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("導入EXCEL失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_Excel(string _type)
        {
            //僅限小等于office2003,之前的版本
            //導入EXCEL頁數
            String strExcel = "";
            if (_type == "1")
            {
                //Tommy 報表
                //strExcel =
                //    @"SELECT [trim_code],[brand],[description],[size],[cust_color],[season] FROM [Sheet1$]";
                strExcel =
                    @"SELECT [trim_code],[brand],[season],[artwork] FROM [Sheet1$]";
            }
            try
            {
                if (_type == "1")
                    Import_excel1(strExcel);
                

                flag_import = true;
            }
            catch (SqlException E)
            {
                flag_import = false;
                throw new Exception(E.Message);
            }
        }

        private void Import_excel1(string _strExcel)
        {
            //刪除舊資料
            const string strSql_d = @"truncate table tmp_rpt_tommy";
            using(SqlConnection con = new SqlConnection(DBUtility.conn_str_dgerp2))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand() { Connection = con })
                {
                    cmd.CommandText = strSql_d;
                    cmd.ExecuteNonQuery();
                }
            }

            String connStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0;", strFile_Excel);
            using (OleDbDataAdapter da = new OleDbDataAdapter(_strExcel, connStr))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                System.Data.DataTable dtExcel = ds.Tables[0];
                SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);
                sqlconn.Open();
                SqlTransaction myTrans = sqlconn.BeginTransaction();

//                const string strSql_i = @"Insert into temp_rpt_tommy (trim_code,brand,desc_en,size,cust_color,season) VALUES 
//                                        (@trim_code,@brand,@description,@size,@cust_color,@season)";
                const string strSql_i = @"Insert into tmp_rpt_tommy (trim_code,brand,season,artwork) VALUES 
                                        (@trim_code,@brand,@season,@artwork)";
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                string ii = "";
                string strarwork;
                progressBar1.Maximum = dtExcel.Rows.Count;
                using (SqlCommand myCommand = new SqlCommand() { Connection = sqlconn, Transaction = myTrans })
                {
                    myCommand.CommandText = strSql_i;
                    try
                    {
                        for (int i = 0; i < dtExcel.Rows.Count; i++)
                        {
                            progressBar1.Value += progressBar1.Step;
                            if (progressBar1.Value == progressBar1.Maximum)
                            {
                                progressBar1.Enabled = false;
                                progressBar1.Visible = false;
                            }
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@trim_code", dtExcel.Rows[i]["trim_code"].ToString().Trim());
                            myCommand.Parameters.AddWithValue("@brand", dtExcel.Rows[i]["brand"].ToString().Trim());
                            //myCommand.Parameters.AddWithValue("@size", dtExcel.Rows[i]["size"].ToString().Trim());
                            //myCommand.Parameters.AddWithValue("@cust_color", dtExcel.Rows[i]["cust_color"].ToString().Trim());
                            myCommand.Parameters.AddWithValue("@season", dtExcel.Rows[i]["season"].ToString().Trim());
                            strarwork = dtExcel.Rows[i]["artwork"].ToString().Trim();                            
                            myCommand.Parameters.AddWithValue("@artwork", strarwork.Length==7 ? strarwork.Substring(0, 7) : strarwork.Substring(0));
                            myCommand.ExecuteNonQuery();
                            ii = i.ToString();
                        }
                        myTrans.Commit(); //數據提交
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾  
                        MessageBox.Show(ii, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        sqlconn.Close();
                        sqlconn.Dispose();
                    }
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;

                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();
                
                SqlParameter[] paras=new SqlParameter[]{new SqlParameter("@brandid","")};
                dgvDetails.DataSource = clsPublicOfGEO.ExecuteProcedureReturnTable("z_rpt_tommy_new", paras);

                wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Excel();
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
