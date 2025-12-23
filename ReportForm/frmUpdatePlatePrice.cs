using cf01.CLS;
using cf01.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmUpdatePlatePrice : Form
    {
        System.Data.DataTable dtImport = new System.Data.DataTable();
        clsToolBarNew objToolbar;

        public frmUpdatePlatePrice()
        {
            InitializeComponent();
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();
        }

        private void frmUpdatePlatePrice_Load(object sender, EventArgs e)
        {
            //將導入的EXCEL轉成Datatble 
            dtImport.Columns.Add("vendor_id", typeof(string)); 
            dtImport.Columns.Add("vendor_name", typeof(string)); 
            dtImport.Columns.Add("quotation_id", typeof(string)); 
            dtImport.Columns.Add("cf_color", typeof(string)); 
            dtImport.Columns.Add("price", typeof(decimal));
            dtImport.Columns.Add("price_unit", typeof(string));
            dtImport.Columns.Add("m_id", typeof(string));
            dtImport.Columns.Add("prod_type", typeof(string)); //產品種類
            dtImport.Columns.Add("plate_process", typeof(string)); //掛電，滾電
            dtImport.Columns.Add("plate_type", typeof(string)); //電鍍顏色 無叻
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string fileName = "";
            //導入EXCEL頁數
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "Execl files (*.xls)|*.xls",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    Title = "導入匯總文件的路徑",
                    FileName = null
                };
                openFileDialog1.ShowDialog();
                fileName = openFileDialog1.FileName;
                if (fileName == "")
                {
                    return;
                }

                //導入EXCEL
                ExcelToDatable(fileName);
                dgv1.DataSource = dtImport;
                

                bool update_flag = true;
                if (dtImport.Rows.Count > 0)
                {
                    //插入數據庫dgsql2中的jo_plate_price_update表
                    string sql_del = "TRUNCATE TABLE jo_plate_price_update";
                    string result = clsPublicOfCF01.ExecuteSqlUpdate(sql_del);
                    if (result == "")
                    {
                        string sql_insert = "";
                        decimal decPrice = 0;
                        for (int i=0;i< dtImport.Rows.Count; i++)
                        {
                            decPrice = decimal.Parse(dtImport.Rows[i]["price"].ToString());
                            sql_insert = string.Format(
                            @"Insert into jo_plate_price_update(vendor_id,vendor_name,quotation_id,cf_color,price,prod_type,plate_type,plate_process,price_unit,m_id) Values
                            ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')",
                            dtImport.Rows[i]["vendor_id"].ToString(), dtImport.Rows[i]["vendor_name"].ToString(), dtImport.Rows[i]["quotation_id"].ToString(),
                            dtImport.Rows[i]["cf_color"].ToString(), decPrice, dtImport.Rows[i]["prod_type"].ToString(), dtImport.Rows[i]["plate_type"].ToString(),
                            dtImport.Rows[i]["plate_process"].ToString(), dtImport.Rows[i]["price_unit"].ToString(), dtImport.Rows[i]["m_id"].ToString());
                            result = clsPublicOfCF01.ExecuteSqlUpdate(sql_insert);
                            if(result != "")
                            {
                                update_flag = false;
                                break;
                            }
                        }
                    }
                }
               
                if (update_flag)
                {
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@user_id",DBUtility._user_id)
                    };

                    frmProgress wForm = new frmProgress();
                    new Thread((ThreadStart)delegate {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();
                    //************************
                    //数据处理
                    DataTable dtblReturn = clsPublicOfCF01.ExecuteProcedure("usp_update_plate", paras);
                    //************************
                    wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                    

                    if (dtblReturn.Rows.Count > 0 && dtblReturn.Rows[0][0].ToString() == "OK")
                    {
                        MessageBox.Show("單價更新成功！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("單價更新失敗！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("單價更新失敗！！", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (SqlException E)
            {
                MessageBox.Show($"EXCEL文件導入失敗！[{E.Message}]！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new Exception(E.Message);
            }
        }


        private void ExcelToDatable(string filesExcel)
        {
            dtImport.Clear();
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();//{ Visible = true };                  
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(filesExcel,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet xSheet;
         
            xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[1];
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            int rowPrecessing = 0;
            int rowTotal = xSheet.UsedRange.Rows.Count;//總行數
            progressBar1.Maximum = rowTotal;

            try
            {               
                Microsoft.Office.Interop.Excel.Range rng;
                DataRow drow = null;
                for (int ii = 2; ii <= rowTotal; ii++)
                {
                    rowPrecessing = ii;//記錄正在更新的行
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }                   
                    drow = dtImport.NewRow();
                    rng = xSheet.Cells[ii, "A"]; 
                    drow["vendor_id"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "B"];    
                    drow["vendor_name"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "C"];
                    drow["quotation_id"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "D"]; 
                    drow["cf_color"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "E"]; 
                    drow["price"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "F"];
                    drow["price_unit"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "G"];
                    drow["m_id"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "H"];
                    drow["prod_type"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "I"];
                    drow["plate_process"] = rng.get_Value();
                    rng = xSheet.Cells[ii, "J"]; 
                    drow["plate_type"] = rng.get_Value();

                    dtImport.Rows.Add(drow);
                }
            }
            catch (Exception E)
            {
                xSheet = null;
                dtImport.Clear();
                throw new Exception(E.Message);
            }
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            //if (x == 2)
            //{
            //    xApp.Application.DisplayAlerts = false; //禁止彈出是否保存對話框
            //    xBook.Close();
            //    xSheet = null;
            //    xBook = null;
            //}           
            if (xApp != null)
            {
                xApp.Quit(); //这一句是非常重要的，否则Excel对象不能从内存中退出 
                xBook = null;
                xApp = null;
                GC.Collect();
            }
        }



    }
}
