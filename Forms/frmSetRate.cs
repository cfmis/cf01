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
using Microsoft.Office.Interop.Excel;
using System.Reflection;

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
            try
            {
                Inport_excel();
                flag_import = true;
            }
            catch (SqlException E)
            {
                flag_import = false;
                throw new Exception(E.Message);
            }
        }

        private void Inport_excel()
        {
            //將導入的EXCEL轉成Datatble
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("goods_id", typeof(string));
            dt.Columns.Add("rate", typeof(Int32));
            //*****
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();//{ Visible = true };                  
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(strFile_Excel,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[1];

            int row_total = xSheet.UsedRange.Rows.Count;//總行數
            bool lb_flag = true;
            Microsoft.Office.Interop.Excel.Range rng;
            try
            {
                for (int i = 2; i <= row_total; i++)
                {
                    DataRow dr = dt.NewRow();
                    rng = xSheet.Cells[i, "A"]; //Goods_id 
                    dr[0] = rng.get_Value();
                    rng = xSheet.Cells[i, "B"]; //RATE
                    dr[1] = rng.get_Value();
                    dt.Rows.Add(dr);
                }
                xApp.Application.DisplayAlerts = false; //禁止彈出是否保存對話框
                xSheet = null;
                xBook = null;
                xApp.Quit(); //这一句是非常重要的，否则Excel对象不能从内存中退出 
                xApp = null;
            }
            catch (Exception E)
            {
                lb_flag = false;
                throw new Exception(E.Message);
            }
            finally
            {
                if (xApp != null)
                {
                    xApp.Quit();
                    xBook = null;
                    xSheet = null;
                    xBook.Close();
                    GC.Collect();
                }
            }
            if (lb_flag == false)
            {
                return;
            }
            
            System.Data.DataTable dtExcel = dt;
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

            string sql_f = "";
            string strGoods_id = "";
            float iRate = 0;
            System.Data.DataTable dtfind = new System.Data.DataTable();
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

                    if (dtfind.Rows.Count == 0)
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
                    myCommand.Parameters.AddWithValue("@basic", "0");
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                    myCommand.ExecuteNonQuery();
                }
                //myTrans.Commit(); //數據提交
            }
            catch (Exception E)
            {
                //myTrans.Rollback(); //數據回滾  
                MessageBox.Show("出錯貨品編號" + strGoods_id, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        } 

    }
}
