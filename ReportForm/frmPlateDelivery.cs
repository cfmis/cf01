using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using System.Data.SqlClient;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraEditors;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using cf01.CLS;
using System.Drawing;

namespace cf01.ReportForm
{
    public partial class frmPlateDelivery : Form
    {
        clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        string strUser_id = DBUtility._user_id;
        string str_language = "0";
        bool flag_inport;       
        string rpt_type;
        System.Data.DataTable dtRpt1 = new System.Data.DataTable();
        System.Data.DataTable dtRpt2 = new System.Data.DataTable();
        System.Data.DataTable dtRpt3 = new System.Data.DataTable();
        DataSet dts = new DataSet();       
        System.Data.DataTable dtExcel = new System.Data.DataTable();
        System.Data.DataTable dtOutReurn = new System.Data.DataTable();
        System.Data.DataTable dtVendor = new System.Data.DataTable();
        System.Data.DataTable dtImport = new System.Data.DataTable();
      

        public frmPlateDelivery()
        {
            InitializeComponent();
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            gridView1.BestFitColumns(); //列寬自適應
            gridView1.IndicatorWidth = 40;
            gridView2.IndicatorWidth = 40;
            str_language = DBUtility._language;
            rpt_type = "1";
        }

        private void frmPlateDelivery_Load(object sender, EventArgs e)
        {
            txtSend_Date2.EditValue = DateTime.Now;
            txtSend_Date1.EditValue = DateTime.Now.AddDays(-30);

            string sql = string.Format(@"Select id,id+'('+name+')' AS cdesc From {0}cd_mo_type Where within_code = '0000' and mo_type = 'B1'", DBUtility.remote_db);
            System.Data.DataTable dtReason = clsPublicOfCF01.GetDataTable(sql);
            lueShortReason.Properties.DataSource = dtReason;
            lueShortReason.Properties.ValueMember = "id";
            lueShortReason.Properties.DisplayMember = "cdesc";

            //將導入的EXCEL轉成Datatble 
            dtImport.Columns.Add("user_id", typeof(string)); //未完成頁數
            dtImport.Columns.Add("mo_id", typeof(string)); //未完成頁數
            dtImport.Columns.Add("rpt_type", typeof(string)); //報表類型
            dtImport.Columns.Add("mo_type", typeof(string)); //急/特急狀態
            dtImport.Columns.Add("wp_id", typeof(string)); //當前部門
            dtImport.Columns.Add("mo_type_sort", typeof(string)); //特急狀態排序
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            flag_inport = false;
            string dat1 = txtSend_Date1.Text;
            string dat2 = txtSend_Date2.Text;
            if (string.IsNullOrEmpty(dat1) || string.IsNullOrEmpty(dat2))
            {
                MessageBox.Show("日期不可爲空！");
                txtSend_Date1.Focus();
            }

            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    rpt_type = "1";
                    break;
                case 1:
                    rpt_type = "2";
                    break;
                case 2:
                    rpt_type = "3";
                    break;
            } 

            Load_Excel();
            
            if (flag_inport)  //導入EXCEL成功
            {
                //顯示進度
                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();

                //************************
                Load_Data(); //数据处理
                //************************
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            }
        }

        private void Load_Excel()
        {                     
            string fileName = "";
            //導入EXCEL頁數
            try
            {
                //2019-12-26取消舊代碼,因部分電腦上不支持此方法
                //const String strsql_g = "SELECT 未完成頁數,[急/特急狀態],當前部門 FROM [大貨單$]";
                //const String strsql_n = "SELECT 未完成頁數,[急/特急狀態],當前部門 FROM [NS未完成頁數$]";
              
                //2019-12-26更改為新的導入EXCEL方式   
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "Execl files (*.xls)|*.xls",
                    FilterIndex = 0,
                    RestoreDirectory = true,
                    Title = "導入匯總文件路徑",
                    FileName = null
                };
                openFileDialog1.ShowDialog();
                fileName = openFileDialog1.FileName;
                dtImport.Clear();

                if (chkMo.Checked)
                {
                    if (fileName != "")
                    {
                        ExcelToDatable(fileName);
                    }
                    else
                    {
                        chkMo.Checked = false;
                    }
                }
                flag_inport = true;
            }
            catch (SqlException E)
            {
                flag_inport = false;
                throw new Exception(E.Message);
            }
            
        }

        //private void dvwPlate_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    //顯示行數
        //    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
        //       e.RowBounds.Location.Y,
        //       dgwPlate.RowHeadersWidth - 4,
        //       e.RowBounds.Height);

        //    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
        //        dgwPlate.RowHeadersDefaultCellStyle.Font,
        //        rectangle,
        //        dgwPlate.RowHeadersDefaultCellStyle.ForeColor,
        //        TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Load_Data()
        {
            //調用存儲過程           
            string user_id = DBUtility._user_id;
            string dat1 = txtSend_Date1.Text;
            string dat2 = txtSend_Date2.Text;
            //去掉重復的數據
            DataView dvw = new DataView(dtImport);
            //true表示保留原始表的结构，后面的参数是去重的列名
            System.Data.DataTable distinctTable = dvw.ToTable(true, "user_id", "mo_id", "rpt_type", "mo_type", "wp_id", "mo_type_sort");
            dtImport.Clear();
            dtImport = distinctTable.Copy();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@type", rpt_type),
                new SqlParameter ("@dat1", dat1),
                new SqlParameter ("@dat2", dat2),
                new SqlParameter ("@user_id", user_id),
                new SqlParameter ("@import_data",SqlDbType.Structured) {Value = dtImport}
            };

            switch (rpt_type)
            {
                case "1":
                    dts = clsConErp.ExecuteProcedureReturnDataSet("z_plate_delivery_rpt1", parm, null);
                    dtRpt1.Clear();
                    dtRpt1 = dts.Tables[0];

                    string issueDate = "", completeDate = "", curDate = "";
                    int send_qty = 0, in_qty_total = 0;
                    for (int i=0;i<dtRpt1.Rows.Count;i++)
                    {
                        //tempId = dtRpt1.Rows[i]["temp_id"].ToString()+(i + 1).ToString("00000");
                        //start 2025/10/28 add 
                        issueDate = dtRpt1.Rows[i]["issue_date"].ToString();
                        completeDate = dtRpt1.Rows[i]["t_complete_date"].ToString();
                        curDate = DateTime.Now.Date.ToString("yyyy/MM/dd");
                        send_qty = int.Parse(dtRpt1.Rows[i]["out_qty_total"].ToString());
                        in_qty_total = int.Parse(dtRpt1.Rows[i]["in_qty_total"].ToString());
                        issueDate = DateTime.Parse(issueDate).Date.AddDays(3).ToString("yyyy/MM/dd");//發貨日期加3日                       
                        if (DateTime.Parse(issueDate).Date < DateTime.Parse(curDate).Date && in_qty_total < send_qty)
                        {
                            dtRpt1.Rows[i]["flag_brg"] = "1";
                        }
                        // end 2025/10/28 add 
                    }
                    dtOutReurn = dts.Tables[1];   //外發退料
                    dtVendor = dts.Tables[2];
                    grdControl.DataSource = dtRpt1;
                    grdControl.MainView = gridView1;
                    chkSelectAll.Visible = true;
                    break;
                case "2":
                case "3":
                    string strProc = "z_plate_delivery";
                    if (rpt_type == "2")
                    {
                        dtRpt2.Clear();
                        dtRpt2 = clsConErp.ExecuteProcedureReturnTable(strProc, parm);
                        grdControl.DataSource = dtRpt2;
                        grdControl.MainView = gridView2;
                        chkSelectAll.Visible = false;
                    }
                    else
                    {
                        dtRpt3.Clear();
                        dtRpt3 = clsConErp.ExecuteProcedureReturnTable(strProc, parm);
                        grdControl.DataSource = dtRpt3;
                        grdControl.MainView = gridView3;
                        chkSelectAll.Visible = false;
                    }
                    break;
            }
        }

    

        private void Inport_excel(string _filename, string _strsql)
        {
            string connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0 ", _filename);
            using (OleDbDataAdapter da = new OleDbDataAdapter(_strsql, connStr))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                string strUser_id = DBUtility._user_id;
                string strmo_id;
                string strmo_type;
                string strwp_id;
                int mo_type_sort;

                System.Data.DataTable dtExcel = ds.Tables[0];                 
                SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);
                sqlconn.Open();

                string strSql_f = "Select 1 from dbo.z_rpt_plate Where user_id=@user_id and mo_id=@mo_id and rpt_type=@rpt_type";
                string strSql_i = "Insert into z_rpt_plate (user_id,mo_id,rpt_type,mo_type,wp_id,mo_type_sort) values (@user_id,@mo_id,@rpt_type,@mo_type,@wp_id,@mo_type_sort)";
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dtExcel.Rows.Count;

                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }

                    strmo_id = dtExcel.Rows[i]["未完成頁數"].ToString().Trim();
                    if (string.IsNullOrEmpty(strmo_id))
                    {
                        continue;
                    }
                    strmo_type = dtExcel.Rows[i]["急/特急狀態"].ToString().Trim();
                    strwp_id = dtExcel.Rows[i]["當前部門"].ToString().Trim();
                    mo_type_sort = strmo_type.Length;

                    SqlCommand cmd = new SqlCommand(strSql_f, sqlconn);
                    cmd.Parameters.AddWithValue("@user_id", strUser_id);
                    cmd.Parameters.AddWithValue("@mo_id", strmo_id);
                    cmd.Parameters.AddWithValue("@rpt_type", rpt_type);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        cmd.Dispose();
                        dr.Close();
                        dr.Dispose();
                        SqlCommand sqlcmd = new SqlCommand(strSql_i, sqlconn);
                        sqlcmd.Parameters.AddWithValue("@user_id", strUser_id);
                        sqlcmd.Parameters.AddWithValue("@mo_id", strmo_id);
                        sqlcmd.Parameters.AddWithValue("@rpt_type", rpt_type);
                        sqlcmd.Parameters.AddWithValue("@mo_type", strmo_type);
                        sqlcmd.Parameters.AddWithValue("@wp_id", strwp_id);
                        sqlcmd.Parameters.AddWithValue("@mo_type_sort", mo_type_sort);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();
                    }
                    else
                    {
                        cmd.Dispose();
                        dr.Close();
                        dr.Dispose();
                    }
                }

                progressBar1.Enabled = false;
                progressBar1.Visible = false;
                sqlconn.Close();
                sqlconn.Dispose();
            }
        }

        private void ExcelToDatable(string ls_files_excel)
        {
            dtImport.Clear();
            //未完成頁數,[急/特急狀態],當前部門
            //*****
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();//{ Visible = true };                  
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(ls_files_excel,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet xSheet;

            for (int x = 1; x < 3; x++)
            {
                xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[x];
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;

                int rowPrecessing = 0;
                int rowTotal = xSheet.UsedRange.Rows.Count;//總行數
                progressBar1.Maximum = rowTotal;
                
                try
                {
                    string moTypeSort = "";
                    Microsoft.Office.Interop.Excel.Range rng;
                    DataRow dr = null;
                    for (int ii = 2; ii <= rowTotal; ii++)
                    {
                        rowPrecessing = ii;//記錄正在更新的行
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        dr = dtImport.NewRow();
                        dr["user_id"] = strUser_id;
                        rng = xSheet.Cells[ii, "C"]; //未完成頁數        
                        dr["mo_id"] = rng.get_Value();
                        dr["rpt_type"] = "1";
                        rng = xSheet.Cells[ii, "J"]; //急/特急狀態
                        dr["mo_type"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "M"]; //當前部門  原來是Z??b
                        dr["wp_id"] = "";// rng.get_Value(); 舊的匯總表同一頁數原來只有一行，舊的匯總表發現有多行，存儲過程用頁數去關聯將引起重復，所以這里導入時要去掉部門
                        moTypeSort = dr["mo_type"].ToString().Trim();
                        moTypeSort = string.IsNullOrEmpty(moTypeSort) ? "" : moTypeSort;
                        dr["mo_type_sort"] = moTypeSort.Length;
                        dtImport.Rows.Add(dr);
                    }
                }
                catch (Exception E)
                {                    
                    xSheet = null;
                    throw new Exception(E.Message);
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;
                if (x == 2)
                {
                    xApp.Application.DisplayAlerts = false; //禁止彈出是否保存對話框
                    xBook.Close();
                    xSheet = null;
                    xBook = null;
                }
            } //--end (int x=1;x<3;x++) 
                      
            if (xApp != null)
            {
                xApp.Quit(); //这一句是非常重要的，否则Excel对象不能从内存中退出 
                xBook = null;
                xApp = null;
                GC.Collect();
            }
        }


        /// <summary>
        /// 參數ls_files_excel 導入EXCEL文件名
        /// 參數li_sheet_name 導入哪一個Sheet: 1--大貨單;2--NS未完成頁數
        /// </summary>
        /// <param name="ls_files_excel"></param>
        /// <param name="li_sheet_name"></param>
        private void Excel_To_Datable(string ls_files_excel)
        {
            ////未完成頁數,[急/特急狀態],當前部門
            //*****
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();//{ Visible = true };                  
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(ls_files_excel,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            int row_precessing = 0;
            int row_total = 0;
            Microsoft.Office.Interop.Excel.Worksheet xSheet;
            try
            {
                for (int i = 1; i < 3; i++)
                {
                    xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[i];
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;

                    row_precessing = 0;
                    row_total = xSheet.UsedRange.Rows.Count;//總行數
                    progressBar1.Maximum = row_total;
                    
                    Microsoft.Office.Interop.Excel.Range rng;
                    string moTypeSort = "";
                    for (int ii = 2; ii <= row_total; ii++)
                    {
                        row_precessing = ii;//記錄更在更新的行
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        DataRow dr = dtImport.NewRow();
                        dr["user_id"] = strUser_id;
                        rng = xSheet.Cells[ii, "C"]; //未完成頁數        
                        dr["mo_id"] = rng.get_Value();
                        dr["rpt_type"] = "2";
                        rng = xSheet.Cells[ii, "J"]; //急/特急狀態
                        dr["mo_type"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "M"]; //當前部門  原來是Z??b
                        dr["wp_id"] = "";// rng.get_Value(); 舊的匯總表同一頁數原來只有一行，舊的匯總表發現有多行，存儲過程用頁數去關聯將引起重復，所以這里導入時要去掉部門
                        moTypeSort = dr["mo_type"].ToString().Trim();
                        moTypeSort = string.IsNullOrEmpty(moTypeSort) ? "" : moTypeSort;
                        dr["mo_type_sort"] = moTypeSort.Length;
                        dtImport.Rows.Add(dr);
                    }
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                if (xApp != null)
                {                    
                    xBook.Close();
                    xBook = null;
                    xSheet = null;
                    xApp.Quit();                  
                    GC.Collect();
                }
            }
                         
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //顯示行號
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //顯示行號
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void txtSend_Date1_Leave(object sender, EventArgs e)
        {
            string strdate = txtSend_Date1.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
            if (txtSend_Date2.EditValue == null)
            {
                txtSend_Date2.EditValue = txtSend_Date1.EditValue;
            }
        }

        private void txtSend_Date2_Leave(object sender, EventArgs e)
        {
            string strdate = txtSend_Date2.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
        }

        private void CheckDate(object obj, string strdate)
        {
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg = (str_language == "2") ? "Data Fromat is Error." : "輸入的日期有誤！";
                MessageBox.Show(strMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //old code cancel in 2025/10/29
            //SaveFileDialog saveFileDialog = new SaveFileDialog() { Title = "导出Excel", Filter = "Excel文件(*.xls)|*.xls" };
            //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            //if (dialogResult == DialogResult.OK)
            //{
            //    grdControl.ExportToXls(saveFileDialog.FileName);
            //    DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //new code add 2025/10/19
            string result = clsPlateDelivery.ExpToExcelAll(dtRpt1);
            if (result == "")
            {
                MessageBox.Show("匯出EXCEL完成!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
        //
        }
     

        private void frmPlateDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtRpt1.Dispose();
            dtRpt2.Dispose();
            dtExcel.Dispose();
            dtOutReurn.Dispose();
        }


        private void btnRpt2_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dtTemp = new System.Data.DataTable();
            dtTemp = dtRpt1.Copy();
            int index=0, rowCount = 0;
            index = radioGroup1.SelectedIndex;
            if (index == 0)
            {
                rowCount = gridView1.RowCount;
                dtTemp = dtRpt1.Copy();
            }
            if (index == 1)
            {
                rowCount = gridView2.RowCount;
                dtTemp = dtRpt2.Copy(); 
            }
            if (index == 2)
            {
                rowCount = gridView3.RowCount;
                dtTemp = dtRpt3.Copy();
            }
            if (rowCount == 0)
            {
                return;
            }           
            clsPlateDelivery.ExpToExcel(index, rowCount, dtTemp, dtOutReurn, progressBar1,chkArt.Checked);
        }
        

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    lblSend.Text = "發貨日期";
                    grdControl.DataSource = dtRpt1;
                    grdControl.MainView = gridView1;
                    chkSelectAll.Visible = true;
                    break;
                case 1:
                    lblSend.Text = "收貨日期";
                    grdControl.DataSource = dtRpt2;
                    grdControl.MainView = gridView2;
                    chkSelectAll.Visible = false;
                    break;
                case 2:
                    lblSend.Text = "移交日期";
                    grdControl.DataSource = dtRpt3;
                    grdControl.MainView = gridView3;
                    chkSelectAll.Visible = false;
                    break;
            }
        }

        private void chkSelectAll_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                if (dtRpt1.Rows.Count > 0)
                {
                    for(int i=0;i< dtRpt1.Rows.Count; i++)
                    {
                        dtRpt1.Rows[i]["flag_select"] = true;
                    }
                }
                else
                {
                    chkSelectAll.Checked = false;
                }
            }
            else
            {
                if (dtRpt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dtRpt1.Rows.Count; i++)
                    {
                        dtRpt1.Rows[i]["flag_select"] = false;
                    }
                }
                else
                {
                    chkSelectAll.Checked = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {          
            if (radioGroup1.SelectedIndex != 0)
            {
                return;
            }
            if(dtRpt1.Rows.Count==0)
            {
                return;
            }
            bool flagSelect = false;
            gridView1.CloseEditor();
            for (int i=0;i< gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "flag_select").ToString() == "True")
                {
                    flagSelect = true;
                    break;
                }
            }
            if(flagSelect == false)
            {
                MessageBox.Show("請選中要保存的行！","系統提示",MessageBoxButtons.OK);
                return;
            }
            bool flagSave = false;
            string sql_i ="", sql_u ="", user_id = DBUtility._user_id, p_id = "", temp_id = "";
            sql_i =
            @"INSERT INTO dbo.mo_schedule_plate(p_id, vendor_id, id, mo_id, goods_id, remark_wet,update_by,update_date)
			VALUES (@p_id, @vendor_id, @id, @mo_id, @goods_id, @remark_wet,@user_id,getdate())";
            sql_u =
            @"UPDATE dbo.mo_schedule_plate
			SET remark_wet=@remark_wet,update_by=@user_id,update_date=getdate()
            WHERE p_id=@p_id And vendor_id=@vendor_id And id=@id And mo_id=@mo_id And goods_id=@goods_id";            
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    string flag = "";
                    for (int i = 0; i < dtRpt1.Rows.Count; i++)
                    {
                        flag = dtRpt1.Rows[i]["flag_select"].ToString();
                        if (flag == "True")
                        {
                            myCommand.Parameters.Clear();
                            p_id = dtRpt1.Rows[i]["p_id"].ToString();
                            temp_id = dtRpt1.Rows[i]["temp_id"].ToString();
                            if(p_id != temp_id)
                            {
                                p_id = temp_id;
                                myCommand.CommandText = sql_i;
                                dtRpt1.Rows[i]["p_id"] = p_id;
                            }
                            else
                            {
                                myCommand.CommandText = sql_u;
                            }                       
                            myCommand.Parameters.AddWithValue("@p_id", p_id);
                            myCommand.Parameters.AddWithValue("@vendor_id", dtRpt1.Rows[i]["vendor_id"].ToString());
                            myCommand.Parameters.AddWithValue("@id", dtRpt1.Rows[i]["id"].ToString());
                            myCommand.Parameters.AddWithValue("@mo_id", dtRpt1.Rows[i]["mo_id"].ToString());
                            myCommand.Parameters.AddWithValue("@goods_id", dtRpt1.Rows[i]["goods_id"].ToString());
                            myCommand.Parameters.AddWithValue("@remark_wet", dtRpt1.Rows[i]["remark_wet"].ToString());
                            myCommand.Parameters.AddWithValue("@user_id", user_id);
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    flagSave = true;
                    for (int i = 0; i < dtRpt1.Rows.Count; i++)
                    {
                        dtRpt1.Rows[i]["flag_select"] = false;
                    }
                    chkSelectAll.Checked = false;
                    dtRpt1.AcceptChanges();
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    flagSave = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }
            if (flagSave)
            {
                MessageBox.Show("保存成功！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRpt3_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                System.Data.DataTable dtTemp = dtRpt1.Copy();
                clsPlateDelivery.ExpToExcelByVendor(dtTemp, dtVendor );
            }
        }

        private void btnShowMore_Click(object sender, EventArgs e)
        {
            btnShowMore.Text = (btnShowMore.Text == ">>") ? "<<" : ">>";
            panel2.Visible = !panel2.Visible;           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex != 0)
            {
                return;
            }
            if (dtRpt1.Rows.Count == 0)
            {
                return;
            }
            //檢查GEO中是否有外發加單強制完成的權限
            string user_id = DBUtility._user_id;
            if (user_id.ToUpper() != "ADMIN")
            {
                if (!CheckPermission(user_id, "W_OUT_PROCESS_OUT_COMPLETE", "PB_CONFIRM"))
                {
                    return;
                }
            }

            bool flagSelect = false;
            gridView1.CloseEditor();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "flag_select").ToString() == "True")
                {
                    flagSelect = true;
                    break;
                }
            }
            if (flagSelect == false)
            {
                MessageBox.Show("請首先選中要保存的行！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strSql1 = string.Empty, strSql2 = string.Empty, strSelect = string.Empty, id = string.Empty, mo_id = string.Empty, goods_id = string.Empty;
            string shortReason = string.Empty;
            decimal out_qty_total = 0, in_qty_total = 0;
            bool flagCheck = true;
            for (int i = 0; i < dtRpt1.Rows.Count; i++)
            {
                strSelect = dtRpt1.Rows[i]["flag_select"].ToString();
                if (strSelect == "True")
                {
                    id = dtRpt1.Rows[i]["id"].ToString();
                    mo_id = dtRpt1.Rows[i]["mo_id"].ToString();
                    goods_id = dtRpt1.Rows[i]["goods_id"].ToString();
                    out_qty_total = decimal.Parse(dtRpt1.Rows[i]["out_qty_total"].ToString());
                    in_qty_total = decimal.Parse(dtRpt1.Rows[i]["in_qty_total"].ToString());
                    if(in_qty_total <= 0)
                    {
                        MessageBox.Show($"第 【{(i+1).ToString()}】行"+"\n\r"+$"單號:【{id}】"+ "\n\r"+$"頁數:【{mo_id}】"+"\n\r"+$"貨品:【{goods_id}】"+"\n\r"+"未曾收過貨，不可以做外發加工單強制完成！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        flagCheck = false;
                        break;
                    }                        
                }
            }
            if (!flagCheck)
            {
                return;
            }
            shortReason = lueShortReason.EditValue.ToString();
            if (string.IsNullOrEmpty(shortReason))
            {
                MessageBox.Show("短缺原因設置不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueShortReason.Focus();
                return;
            }
            //正常外發加工單
            strSql1 =
            @"UPDATE dbo.op_outpro_out_displace SET state='G',short_reason=@short_reason WHERE within_code='0000' And id=@id And mo_id=@mo_id And goods_id=@goods_id";
            //返電單
            strSql2 =
            @"UPDATE dbo.op_return_details SET state='G',short_reason=@short_reason WHERE within_code='0000' And id=@id And mo_id=@mo_id And goods_id=@goods_id";
            bool flagSave = false;
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {                        
                    for (int i = 0; i < dtRpt1.Rows.Count; i++)
                    {
                        strSelect = dtRpt1.Rows[i]["flag_select"].ToString();
                        if (strSelect == "True")
                        {
                            myCommand.Parameters.Clear();
                            id = dtRpt1.Rows[i]["id"].ToString();
                            mo_id = dtRpt1.Rows[i]["mo_id"].ToString();
                            goods_id = dtRpt1.Rows[i]["goods_id"].ToString();
                            myCommand.CommandText = (id.Substring(0, 1) == "P") ? strSql1 : strSql2;                               
                            myCommand.Parameters.AddWithValue("@id", id);
                            myCommand.Parameters.AddWithValue("@mo_id", mo_id);                            
                            myCommand.Parameters.AddWithValue("@goods_id", goods_id);
                            myCommand.Parameters.AddWithValue("@short_reason", shortReason);
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    flagSave = true;
                    //移除已做外發強制完成的行
                    DataRow drow = null; 
                    for (int i = dtRpt1.Rows.Count-1; i>=0; i--)
                    {
                        if(dtRpt1.Rows[i]["flag_select"].ToString()== "True")
                        {
                            drow = dtRpt1.Rows[i];
                            dtRpt1.Rows.Remove(drow);                               
                        }
                    }
                    chkSelectAll.Checked = false;
                    dtRpt1.AcceptChanges();
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    flagSave = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }
            if (flagSave)
            {
                MessageBox.Show("短缺原因設置成功！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("短缺原因設置失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOKPlan_Click(object sender, EventArgs e)
        {
            //檢查GEO中是否有生產計劃強制完成的權限
            string user_id = DBUtility._user_id;
            if (user_id.ToUpper() != "ADMIN")
            {
                if(!CheckPermission(user_id, "W_MANU_JO_COMPLETE", "PB_COMPLETE"))
                {                    
                    return;
                }
            }
            string strSql = string.Empty, strSelect = string.Empty, mo_id = string.Empty, goods_id = string.Empty, wp_id = string.Empty;
            int order_qty = 0, c_qty_ok = 0;
            bool flagCheck = true;
            for (int i = 0; i < dtRpt1.Rows.Count; i++)
            {
                strSelect = dtRpt1.Rows[i]["flag_select"].ToString();
                if (strSelect == "True")
                {
                    mo_id = dtRpt1.Rows[i]["mo_id"].ToString();
                    goods_id = dtRpt1.Rows[i]["goods_id"].ToString();
                    order_qty = int.Parse(dtRpt1.Rows[i]["order_qty"].ToString());
                    c_qty_ok = int.Parse(dtRpt1.Rows[i]["c_qty_ok"].ToString());
                    if(c_qty_ok < order_qty)
                    {
                        MessageBox.Show($"第 【{(i + 1).ToString()}】行" + "\n\r" + $"頁數:【{mo_id}】" + "\n\r" + $"貨品:【{goods_id}】" + "\n\r" + "注意：完成數量必須大于或等于訂單數量,當前操作無效！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        flagCheck = false;
                        break;
                    }
                }
            }
            if (!flagCheck)
            {
                return;
            }
                        
            strSql =
            @"UPDATE b Set b.state ='G',force_by=@user_id,force_date=GETDATE()
              From jo_bill_mostly a, jo_bill_goods_details b
              Where a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.within_code='0000' And a.mo_id=@mo_id And
              b.within_code ='0000' And b.goods_id=@goods_id And b.wp_id =@wp_id And b.next_wp_id <>'702'";           
            bool flagSave = false;
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    for (int i = 0; i < dtRpt1.Rows.Count; i++)
                    {
                        strSelect = dtRpt1.Rows[i]["flag_select"].ToString();
                        if (strSelect == "True")
                        {
                            myCommand.Parameters.Clear();
                            mo_id = dtRpt1.Rows[i]["mo_id"].ToString();
                            goods_id = dtRpt1.Rows[i]["goods_id"].ToString();
                            wp_id = dtRpt1.Rows[i]["id"].ToString().Substring(1,3);
                            myCommand.CommandText = strSql;                      
                            myCommand.Parameters.AddWithValue("@mo_id", mo_id);
                            myCommand.Parameters.AddWithValue("@goods_id", goods_id);
                            myCommand.Parameters.AddWithValue("@wp_id", wp_id);
                            myCommand.Parameters.AddWithValue("@user_id", user_id);
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    flagSave = true;
                    //移除已做外發強制完成的行
                    DataRow drow = null;
                    for (int i = dtRpt1.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtRpt1.Rows[i]["flag_select"].ToString() == "True")
                        {
                            drow = dtRpt1.Rows[i];
                            dtRpt1.Rows.Remove(drow);
                        }
                    }
                    chkSelectAll.Checked = false;
                    dtRpt1.AcceptChanges();
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    flagSave = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }
            if (flagSave)
            {
                MessageBox.Show("生產計劃強制完成功！！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("生產計劃強制完失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckPermission(string userId,string windowId,string functionId)
        {
            bool rtn = true;
            string result = "";
            string sql = string.Format(
            @"SELECT '1' as POPEDOM FROM {0}UPM_USER_POPEDOM WHERE WITHIN_CODE='0000' and USR_NO='{1}' and Window_id='{2}' and C1_ID='{3}'",
            DBUtility.remote_db, userId, windowId, functionId);
            result = clsPublicOfCF01.ExecuteSqlReturnObject(sql);
            if (result == "")
            {
                MessageBox.Show($"當前用戶{userId}權限不足！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtn = false;
            }
            return rtn;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (gridView1.GetDataRow(e.RowHandle) == null)
            //{
            //    return;
            //}
            //string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            //if (rowStatus == "Added" || rowStatus == "Modified")
            //{
            //    e.Appearance.ForeColor = Color.Black;
            //    e.Appearance.BackColor = Color.Red;//.LemonChiffon;
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string result = "", filePath = "";
            clsPlate modifier = new clsPlate();
            filePath = modifier.SelectExcelFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                //顯示進度
                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();

                //************************
                result = modifier.ModifyExcelFile(filePath); //数据处理
                //************************
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                if (result == "")
                {
                    MessageBox.Show("Excel文件修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"操作失敗：{result}", "錯誤提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
