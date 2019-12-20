using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmSetRate : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();

        public frmSetRate()
        {
            InitializeComponent();
            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);
        }
        bool flag_import;
        string strFile_Excel = "";
        private void BTNIMPORT_Click(object sender, EventArgs e)
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
            Load_Excel();
            if (flag_import)
            {
                MessageBox.Show("導入EXCEL成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("導入EXCEL失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void Load_Excel()
        {
            //僅限小等于office2003,之前的版本
            //導入EXCEL頁數
            const String strExcel = @"SELECT Distinct [goods_id],[rate] FROM [Sheet1$]";
            try
            {
                Inport_excel(strExcel);
                flag_import = true;
            }
            catch (SqlException E)
            {
                flag_import = false;
                throw new Exception(E.Message);
            }
        }

        private void Inport_excel(string _strExcel)
        {
            String connStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0;", strFile_Excel);
            using (OleDbDataAdapter da = new OleDbDataAdapter(_strExcel, connStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (Exception E)
                {                                         
                    throw new Exception(E.Message);                   
                }
                finally
                {
                    da.Dispose();
                }

                System.Data.DataTable dtExcel = ds.Tables[0];
                dgvDetails.DataSource = dtExcel;
                
                SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);                
                sqlconn.Open();
                //2015-12-30去掉事務提交，因貨品相同，數量不同時會出錯
                //SqlTransaction myTrans = sqlconn.BeginTransaction();
                const string strSql_i =
               @"Insert into it_coding (within_code,id,basic_unit,sequence_id,corresponding_code,unit_code,count_mode,rate,base_qty,
                    transfers_state,state,basic,create_by,create_date)
                VALUES
                (@within_code,@id,@basic_unit,@sequence_id,@goods_id,@unit_code,@count_mode,Round(@rate,0),@base_qty,
                    @transfers_state,@state,@basic,@user_id,getdate())";
                const string strSql_u =
                @"Update it_coding SET corresponding_code=@goods_id,
                    unit_code=@unit_code,count_mode=@count_mode,rate=Round(@rate,0),base_qty=@base_qty,transfers_state=@transfers_state,
                    state=@state,basic=@basic,update_by=@user_id,update_date=getdate()
                WHERE within_code=@within_code and id=@id and basic_unit=@basic_unit and sequence_id=@sequence_id";
                
                string sql_f="";
                string strGoods_id = "";
                float iRate = 0;                
                DataTable dtfind = new DataTable();
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dtExcel.Rows.Count;
                SqlCommand myCommand = new SqlCommand() { Connection = sqlconn };//, Transaction = myTrans };
                myCommand.CommandTimeout = 1800;//連接30分鐘
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
                        
                        strGoods_id = dtExcel.Rows[i]["goods_id"].ToString().Trim();                       
                        iRate = clsApp.Return_Float_Value(dtExcel.Rows[i]["rate"].ToString());
                        if (string.IsNullOrEmpty(strGoods_id) || iRate <= 0)
                        {
                            continue;
                        }

                        sql_f = string.Format(@"Select '1' FROM it_coding Where within_code='{0}' and id='{1}' and basic_unit='{2}' and sequence_id='{3}'",
                            "0000", strGoods_id, "PCS", "0001");
                        //srtResult = clsConErp.ExecuteSqlReturnObject(sql_f);
                        dtfind = clsConErp.GetDataTable(sql_f);
                        
                        if(dtfind.Rows.Count==0)
                        {
                            myCommand.CommandText = strSql_i;
                        }
                        else
                        {
                            myCommand.CommandText = strSql_u;
                        }
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", "0000");
                        myCommand.Parameters.AddWithValue("@id", dtExcel.Rows[i]["goods_id"].ToString().Trim());
                        myCommand.Parameters.AddWithValue("@basic_unit", "PCS");
                        myCommand.Parameters.AddWithValue("@sequence_id", "0001");
                        myCommand.Parameters.AddWithValue("@goods_id", dtExcel.Rows[i]["goods_id"].ToString().Trim());
                        myCommand.Parameters.AddWithValue("@unit_code", "KG");
                        myCommand.Parameters.AddWithValue("@count_mode", "1");
                        myCommand.Parameters.AddWithValue("@rate", clsApp.Return_Float_Value(dtExcel.Rows[i]["rate"].ToString()));
                        myCommand.Parameters.AddWithValue("@base_qty", 1);
                        myCommand.Parameters.AddWithValue("@transfers_state", "0");
                        myCommand.Parameters.AddWithValue("@state", "0");
                        myCommand.Parameters.AddWithValue("@basic","0" );
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                    }
                    //myTrans.Commit(); //數據提交
                }
                catch (Exception E)
                {
                    //myTrans.Rollback(); //數據回滾  
                    MessageBox.Show("出錯貨品編號"+strGoods_id, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    throw new Exception(E.Message);
                }
                finally
                {
                    sqlconn.Close();
                    sqlconn.Dispose();
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        } 

    }
}
