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


namespace cf01.ReportForm
{
    public partial class frmPlateDelivery : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public string strUser_id = DBUtility._user_id;
        public static string str_language = "0";
        public bool flag_inport;       
        public string rpt_type;
        public System.Data.DataTable dtRpt1 = new System.Data.DataTable();
        public System.Data.DataTable dtRpt2 = new System.Data.DataTable();
        public System.Data.DataTable dtRpt3 = new System.Data.DataTable();
        public DataSet ds = new DataSet();       
        public System.Data.DataTable dtExcel = new System.Data.DataTable();
        public System.Data.DataTable dtOut_reurn = new System.Data.DataTable();

        public frmPlateDelivery()
        {
            InitializeComponent();
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "Execl files (*.xls)|*.xls", FilterIndex = 0, RestoreDirectory = true, Title = "導入匯總文件路徑", FileName = null };
            openFileDialog1.ShowDialog();
            string FileName = openFileDialog1.FileName;
            Refresh();
            if (FileName != "")
            {
                //刪除舊的頁數                           
                SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);
                sqlconn.Open();
                const string sql_del = "Delete From dbo.z_rpt_plate where user_id =@user_id and rpt_type=@rpt_type";
                SqlCommand sqlcmd = new SqlCommand(sql_del, sqlconn);
                sqlcmd.Parameters.AddWithValue("@user_id", strUser_id);
                sqlcmd.Parameters.AddWithValue("@rpt_type", rpt_type);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();
                sqlconn.Close();

                //導入EXCEL頁數               
                try
                {
                    //2019-12-26取消舊代碼
                    //const String strsql_g = "SELECT 未完成頁數,[急/特急狀態],當前部門 FROM [大貨單$]";
                    //const String strsql_n = "SELECT 未完成頁數,[急/特急狀態],當前部門 FROM [NS未完成頁數$]";
                    //Inport_excel(FileName, strsql_g); //大貨單
                    //Inport_excel(FileName, strsql_n); //NS未完成頁數

                    //2019-12-26更改為新的導入EXCEL方式
                    Excel_To_Datable(FileName, 1); //大貨單
                    Excel_To_Datable(FileName, 2); //NS未完成頁數
                    flag_inport = true;
                }
                catch (SqlException E)
                {
                    flag_inport = false;
                    throw new Exception(E.Message);
                }
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

            const string strProc = "z_plate_delivery";
            SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter ("@type", rpt_type),
                   new SqlParameter ("@dat1", dat1),
                   new SqlParameter ("@dat2", dat2),
                   new SqlParameter ("@user_id", user_id)
                };

            switch (rpt_type)
            {
                case "1":
                    dtRpt1.Clear();
                    ds = clsConErp.ExecuteProcedureReturnDataSet(strProc, paras, null);
                    dtRpt1 = ds.Tables[0];
                    dtOut_reurn = ds.Tables[1];   //外發退料
                    grdControl.DataSource = dtRpt1;
                    grdControl.MainView = gridView1;
                    break;
                case "2":
                    dtRpt2.Clear();
                    dtRpt2 = clsConErp.ExecuteProcedureReturnTable(strProc, paras);
                    grdControl.DataSource = dtRpt2;
                    grdControl.MainView = gridView2;
                    break;
                case "3":
                    dtRpt3.Clear();
                    dtRpt3 = clsConErp.ExecuteProcedureReturnTable(strProc, paras);
                    grdControl.DataSource = dtRpt3;
                    grdControl.MainView = gridView3;
                    break;
            }

            //if (rpt_type == "1")
            //{
            //    dtRpt1.Clear();
            //    ds = clsConErp.ExecuteProcedureReturnDataSet(strProc, paras, null);
            //    dtRpt1 = ds.Tables[0];
            //    dtOut_reurn = ds.Tables[1];   //外發退料
            //    grdControl.DataSource = dtRpt1;
            //}
            //else
            //{
            //    dtRpt2.Clear();
            //    dtRpt2 = clsConErp.ExecuteProcedureReturnTable(strProc, paras);
            //    grdControl.DataSource = dtRpt2;
            //}


            //if (rpt_type == "1")
            //{
            //    grdControl.MainView = gridView1;
            //}
            //else
            //{
            //    grdControl.MainView = gridView2;
            //    //dtReport.Clear();               
            //    //dtReport = dtRpt2.Clone(); //COPY表結構 
            //    //for (int i = 0; i < dtRpt2.Rows.Count; i++)
            //    //{
            //    //    dtReport.ImportRow(dtRpt2.Rows[i]);
            //    //}
            //}
        }

    

        private void Inport_excel(string _filename, string _strsql)
        {
            String connStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0 ", _filename);
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

                const string strSql_f = "Select 1 from dbo.z_rpt_plate Where user_id=@user_id and mo_id=@mo_id and rpt_type=@rpt_type";
                const string strSql_i = "Insert into z_rpt_plate (user_id,mo_id,rpt_type,mo_type,wp_id,mo_type_sort) values (@user_id,@mo_id,@rpt_type,@mo_type,@wp_id,@mo_type_sort)";
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
                    if (String.IsNullOrEmpty(strmo_id))
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



        /// <summary>
        /// 參數ls_files_excel 導入EXCEL文件名
        /// 參數li_sheet_name 導入哪一個Sheet: 1--大貨單;2--NS未完成頁數
        /// </summary>
        /// <param name="ls_files_excel"></param>
        /// <param name="li_sheet_name"></param>
        private void Excel_To_Datable(string ls_files_excel,int li_sheet_name)
        {            
            //將導入的EXCEL轉成Datatble
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("未完成頁數", typeof(string));
            dt.Columns.Add(@"急/特急狀態", typeof(string));
            dt.Columns.Add("當前部門", typeof(string));
            //未完成頁數,[急/特急狀態],當前部門
            //*****
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();//{ Visible = true };
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(ls_files_excel,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[li_sheet_name];                        

            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            int row_precessing = 0;
            int row_total = xSheet.UsedRange.Rows.Count;//總行數
            progressBar1.Maximum = row_total;

            bool lb_flag = true;
            Microsoft.Office.Interop.Excel.Range rng;
            try
            {                           
                for (int ii = 2; ii <= row_total; ii++)
                {
                    row_precessing = ii;//記錄更在更新的行
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }
                    DataRow dr = dt.NewRow();
                    rng = xSheet.Cells[ii, "C"]; //未完成頁數        
                    dr[0] = rng.get_Value();
                    rng = xSheet.Cells[ii, "J"]; //急/特急狀態
                    dr[1] = rng.get_Value();
                    rng = xSheet.Cells[ii, "Z"]; //當前部門
                    dr[2] = rng.get_Value();
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
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            //*************************

            //如導入成功,將頁數寫入數據庫
            if (lb_flag)
            {
                string strUser_id = DBUtility._user_id;
                string strmo_id;
                string strmo_type;
                string strwp_id;
                int mo_type_sort;
                System.Data.DataTable dtExcel = dt;
                
                SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);
                sqlconn.Open();

                const string strSql_f = "Select 1 from dbo.z_rpt_plate Where user_id=@user_id and mo_id=@mo_id and rpt_type=@rpt_type";
                const string strSql_i = "Insert into z_rpt_plate (user_id,mo_id,rpt_type,mo_type,wp_id,mo_type_sort) values (@user_id,@mo_id,@rpt_type,@mo_type,@wp_id,@mo_type_sort)";
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
                    if (String.IsNullOrEmpty(strmo_id))
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

        private static void CheckDate(object obj, string strdate)
        {
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Data Fromat is Error.";
                else
                    strMsg = "輸入的日期有誤！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Title = "导出Excel", Filter = "Excel文件(*.xls)|*.xls" };
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                grdControl.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (radioButton2.Checked)
            //{
            //    //if (dtReport != null)
            //    //{
            //    //    if (dtReport.Rows.Count > 0)                    
            //    //    {
            //    //        //加載報表
            //    //        xrPlateDelivery mMyRepot = new xrPlateDelivery() { DataSource = dtReport };
            //    //        mMyRepot.ShowPreview();
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("請先查詢分選報表！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("請先查詢分選報表！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //}
            //}

        }
     

        private void frmPlateDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtRpt1.Dispose();
            dtRpt2.Dispose();
            dtExcel.Dispose();
            dtOut_reurn.Dispose();

            //dtVendor.Dispose();
            //dtVendor_total.Dispose();
            //SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);
            //sqlconn.Open();
            //const string sql_del = "Delete From dbo.tmp_rpt_plate where user_id =@user_id and rpt_type=@rpt_type";
            //SqlCommand sqlcmd = new SqlCommand(sql_del, sqlconn);
            //sqlcmd.Parameters.AddWithValue("@user_id", strUser_id);
            //sqlcmd.Parameters.AddWithValue("@rpt_type", rpt_type);
            //sqlcmd.ExecuteNonQuery();
            //sqlcmd.Dispose();
            //sqlconn.Close();
        }


        private void btnRpt2_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex==0 && gridView1.RowCount == 0)
            {
                return;
            }
            if (radioGroup1.SelectedIndex == 1 && gridView2.RowCount == 0)
            {
                return;
            }
            if (radioGroup1.SelectedIndex == 2 && gridView3.RowCount == 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "保存爲Excel文件";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName.IndexOf(":") < 0)
            {
                return; //點擊了"取消"
            }
            string saveFile = saveFileDialog.FileName;
            int li_index = radioGroup1.SelectedIndex;
            switch (li_index)
            {
                case 0:
                    if (SaveDataTableToExcel_rpt1_sheets(dtRpt1, saveFile))
                    {
                        MessageBox.Show("匯出成功!", "提示信息");
                    }
                    break;
                case 1:
                    if (SaveDataTableToExcel_rpt2(dtRpt2, saveFile))
                    {
                        MessageBox.Show("匯出成功!", "提示信息");
                    }
                    break ;
                case 2:
                    MessageBox.Show("107追貨表未完善此匯出功能!", "提示信息");
                    break;

            }
            
            
            
            //if (radioButton1.Checked)
            //{
            //    if (SaveDataTableToExcel_rpt1_sheets(dtRpt1, saveFile))
            //    {
            //        MessageBox.Show("匯出成功!", "提示信息");
            //    }
            //}

            //if (radioButton2.Checked)
            //{
            //    if (SaveDataTableToExcel_rpt2(dtRpt2, saveFile))
            //    {
            //        MessageBox.Show("匯出成功!", "提示信息");
            //    }
            //}
        }

        private  bool SaveDataTableToExcel_rpt2(System.Data.DataTable excelTable, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                app.Visible = false;
                Workbook wBook = app.Workbooks.Add(true);
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet;
                if (excelTable.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = excelTable.Rows.Count;
                    //***************

                    int row = excelTable.Rows.Count;
                    string cell_art;
                    int col = excelTable.Columns.Count;
                    for (int i = 0; i < row; i++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        wSheet.Rows.RowHeight = 55; //行高
                        wSheet.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            string str = excelTable.Rows[i][j].ToString();
                            if (j != 8)//第9欄爲圖樣所在的欄
                            {
                                wSheet.Cells[i + 2, j + 1] = str;
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(str) && File.Exists(str))
                                {
                                    if (chkArt.Checked)
                                    {
                                        cell_art = "I" + (i + 2); //圖樣單元格坐標,從第二行開始
                                        Range pic2 = wSheet.get_Range(cell_art, Missing.Value);
                                        pic2.Select();
                                        float picleft, pictop;
                                        picleft = Convert.ToSingle(pic2.Left) + 5;
                                        pictop = Convert.ToSingle(pic2.Top) + 5;
                                        wSheet.Shapes.AddPicture(str, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, picleft, pictop, 45, 45);
                                    }
                                }
                            }
                        }
                    }
                }

                //第一行設置表頭名稱
                int size = excelTable.Columns.Count;
                for (int i = 0; i < size; i++)
                {
                    // wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName;
                    string col_name = excelTable.Columns[i].ColumnName;
                    switch (col_name)
                    {
                        case "vendor_id":
                            wSheet.Cells[1, 1 + i] = "客戶編號";
                            break;
                        case "id":
                            wSheet.Cells[1, 1 + i] = "單據編號";
                            break;
                        case "issue_date":
                            wSheet.Cells[1, 1 + i] = "收貨日期";
                            break;
                        case "issue_date_ok":
                            wSheet.Cells[1, 1 + i] = "電回天數";
                            break;
                        case "mo_type":
                            wSheet.Cells[1, 1 + i] = "狀態";
                            break;
                        case "mo_id":
                            wSheet.Cells[1, 1 + i] = "制單編號";
                            break;
                        case "goods_id":
                            wSheet.Cells[1, 1 + i] = "物料編號";
                            break;
                        case "name":
                            wSheet.Cells[1, 1 + i] = "物料名稱";
                            break;
                        case "artwork":
                            wSheet.Cells[1, 1 + i] = "圖樣";
                            break;
                        case "do_color":
                            wSheet.Cells[1, 1 + i] = "顏色做法";
                            break;
                        case "plan_qty":
                            wSheet.Cells[1, 1 + i] = "生產數量";
                            break;
                        case "order_qty":
                            wSheet.Cells[1, 1 + i] = "訂單數量";
                            break;
                        case "c_qty_ok":
                            wSheet.Cells[1, 1 + i] = "完成數量";
                            break;
                        case "prod_qty":
                            wSheet.Cells[1, 1 + i] = "最後一次入庫數量";
                            break;
                        case "sec_qty":
                            wSheet.Cells[1, 1 + i] = "最後一次入庫重量";
                            break;
                        case "in_qty_total":
                            wSheet.Cells[1, 1 + i] = "總收貨數量";
                            break;
                        case "in_sec_qty_total":
                            wSheet.Cells[1, 1 + i] = "總收貨重量";
                            break;
                        case "out_qty_total":
                            wSheet.Cells[1, 1 + i] = "最後一次交下部門數量";
                            break;
                        case "out_sec_qty_total":
                            wSheet.Cells[1, 1 + i] = "最後一次交下部門重量";
                            break;
                        case "next_wp_id":
                            wSheet.Cells[1, 1 + i] = "下部門";
                            break;
                        case "dept_reply":
                            wSheet.Cells[1, 1 + i] = "部門回覆";
                            break;
                        default:
                            break;
                    }
                }
                //设置禁止弹出保存和覆盖的询问提示框   
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //保存工作簿                   
                wBook.Save();
                //保存excel文件   
                app.Save(filePath);
                app.SaveWorkspace(filePath);
                app.Quit();
                wSheet = null;
                wBook = null;
                app = null;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //舊的代碼，暫時沒用到
        private bool SaveDataTableToExcel_rpt1(System.Data.DataTable excelTable, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                app.Visible = false;
                Workbook wBook = app.Workbooks.Add(true);
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet;
                if (excelTable.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = excelTable.Rows.Count;
                    //***************

                    int row = excelTable.Rows.Count;
                    //string cell_art;
                    int col = excelTable.Columns.Count;
                    for (int i = 0; i < row; i++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        wSheet.Rows.RowHeight = 20; //行高  
                        wSheet.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            string str = excelTable.Rows[i][j].ToString();
                            wSheet.Cells[i + 2, j + 1] = str;
                        }
                    }
                }

                //第一行設置表頭名稱
                int size = excelTable.Columns.Count;
                for (int i = 0; i < size; i++)
                {
                    // wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName;
                    string col_name = excelTable.Columns[i].ColumnName;
                    switch (col_name)
                    {
                        case "vendor_id":
                            wSheet.Cells[1, 1 + i] = "客戶編號";
                            break;
                        case "id":
                            wSheet.Cells[1, 1 + i] = "單據編號";
                            break;
                        case "issue_date":
                            wSheet.Cells[1, 1 + i] = "發貨日期";
                            break;
                        case "mo_type":
                            wSheet.Cells[1, 1 + i] = "狀態";
                            break;
                        case "mo_id":
                            wSheet.Cells[1, 1 + i] = "制單編號";
                            break;
                        case "goods_id":
                            wSheet.Cells[1, 1 + i] = "物料編號";
                            break;
                        case "name":
                            wSheet.Cells[1, 1 + i] = "物料名稱";
                            break;
                        case "artwork":
                            wSheet.Cells[1, 1 + i] = "圖樣";
                            break;
                        case "do_color":
                            wSheet.Cells[1, 1 + i] = "顏色做法";
                            break;
                        case "plan_qty":
                            wSheet.Cells[1, 1 + i] = "生產數量";
                            break;
                        case "order_qty":
                            wSheet.Cells[1, 1 + i] = "訂單數量";
                            break;
                        case "c_qty_ok":
                            wSheet.Cells[1, 1 + i] = "完成數量";
                            break;
                        case "prod_qty":
                            wSheet.Cells[1, 1 + i] = "發貨數量";
                            break;
                        case "sec_qty":
                            wSheet.Cells[1, 1 + i] = "發貨重量";
                            break;
                        case "out_qty_total":
                            wSheet.Cells[1, 1 + i] = "總的發貨數量";
                            break;
                        case "out_sec_qty_total":
                            wSheet.Cells[1, 1 + i] = "總的發貨重量";
                            break;
                        case "in_qty_total":
                            wSheet.Cells[1, 1 + i] = "總的收貨數量";
                            break;
                        case "in_sec_qty_total":
                            wSheet.Cells[1, 1 + i] = "總的收貨重量";
                            break;
                        case "qty_differ":
                            wSheet.Cells[1, 1 + i] = "差額數量";
                            break;
                        case "sec_qty_differ":
                            wSheet.Cells[1, 1 + i] = "差額重量";
                            break;
                        case "remark":
                            wSheet.Cells[1, 1 + i] = "備註";
                            break;
                        case "return_total":
                            wSheet.Cells[1, 1 + i] = "返電次數";
                            break;
                        case "dept_reply":
                            wSheet.Cells[1, 1 + i] = "部門回覆";
                            break;
                        case "pmc_reply":
                            wSheet.Cells[1, 1 + i] = "PMC回覆";
                            break;
                        default:
                            break;
                    }
                }
                //设置禁止弹出保存和覆盖的询问提示框   
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //保存工作簿                   
                wBook.Save();
                //保存excel文件   
                app.Save(filePath);
                app.SaveWorkspace(filePath);
                app.Quit();
                app = null;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        #region 報表格式1匯出到多個Sheet中
        private bool SaveDataTableToExcel_rpt1_sheets(System.Data.DataTable excelTable, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            if (app == null)
            {
                MessageBox.Show("無法創建Excel對象，可能你的機子上未安裝Excel.");
                return false;
            }

            try
            {
                app.Visible = false;
                //设置禁止弹出保存和覆盖的询问提示框
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = true;
                Workbook wBook = app.Workbooks.Add(true);
                //添加工作表创建的sheet的个数   
                wBook.Worksheets.Add(Missing.Value, Missing.Value, Convert.ToInt32(1), Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                //wBook.Worksheets.Add(Missing.Value, Missing.Value, Convert.ToInt32(dtVendor.Rows.Count), Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

                string cell_art = "";
                string cell_N = "";
                string cell_O = "";
                string cell_P = "";
                string cell_Q = "";
                string cell_R = "";
                string cell_S = "";
                string cell_T = "";
                string cell_U = "";
                //获取一个工作表
                //Worksheet sheet = wBook.Worksheets[i + 1] as Worksheet;
                Worksheet sheet = wBook.Worksheets[1] as Worksheet;
                sheet.Name = "追貨報表";
                //給sheet第一行設置各列表頭
                sheet.Cells[1, 1] = "客戶編號";
                sheet.Cells[1, 2] = "單據編號";
                sheet.Cells[1, 3] = "發貨日期";
                sheet.Cells[1, 4] = "狀態";
                sheet.Cells[1, 5] = "制單編號";
                sheet.Cells[1, 6] = "物料編號";
                sheet.Cells[1, 7] = "圖樣";
                sheet.Cells[1, 8] = "物料名稱";
                sheet.Cells[1, 9] = "顏色做法";
                sheet.Cells[1, 10] = "計划回港日期";
                sheet.Cells[1, 11] = "生產數量";
                sheet.Cells[1, 12] = "訂單數量";
                sheet.Cells[1, 13] = "完成數量";
                sheet.Cells[1, 14] = "發貨數量";
                sheet.Cells[1, 15] = "發貨重量";
                sheet.Cells[1, 16] = "總的發貨數量";
                sheet.Cells[1, 17] = "總的發貨重量";
                sheet.Cells[1, 18] = "總的收貨數量";
                sheet.Cells[1, 19] = "總的收貨重量";
                sheet.Cells[1, 20] = "差額數量";
                sheet.Cells[1, 21] = "差額重量";
                sheet.Cells[1, 22] = "備註";
                sheet.Cells[1, 23] = "返電次數";
                sheet.Cells[1, 24] = "部門回覆";
                sheet.Cells[1, 25] = "PMC回覆";

                //添加數據
                if (excelTable.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = excelTable.Rows.Count;
                    //***************

                    int row = excelTable.Rows.Count;
                    int col = excelTable.Columns.Count;
                    float picleft, pictop;
                    string str = "";
                    for (int k = 0; k < row; k++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        sheet.Rows.RowHeight = 55; //行高  
                        sheet.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            str = excelTable.Rows[k][j].ToString();
                            if (j != 6)//第7欄爲圖樣所在的欄   
                            {
                                sheet.Cells[k + 2, j + 1] = str;
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(str) && File.Exists(str))
                                {
                                    if (chkArt.Checked)
                                    {
                                        cell_art = "G" + (k + 2); //圖樣單元格坐標,從第二行開始 
                                        Range pic2 = sheet.get_Range(cell_art, Missing.Value);
                                        //Range pic2 = sheet.get_Range("A1", "B2"); //Sample                                        
                                        pic2.Select();
                                        picleft = Convert.ToSingle(pic2.Left) + 5;
                                        pictop = Convert.ToSingle(pic2.Top) + 5;
                                        sheet.Shapes.AddPicture(str, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, picleft, pictop, 45, 45);
                                    }
                                }
                            }

                            //設置背景色
                            cell_N = "N" + (k + 2);
                            cell_O = "O" + (k + 2);
                            cell_P = "P" + (k + 2);
                            cell_Q = "Q" + (k + 2);
                            cell_R = "R" + (k + 2);
                            cell_S = "S" + (k + 2);
                            cell_T = "T" + (k + 2);
                            cell_U = "U" + (k + 2);
                            Range cell_NO = sheet.get_Range(cell_N, cell_O);
                            cell_NO.Interior.Color = System.Drawing.Color.Tan;
                            Range cell_PQ = sheet.get_Range(cell_P, cell_Q);
                            cell_PQ.Interior.Color = System.Drawing.Color.FromArgb(255, 255, 192);
                            Range cell_RS = sheet.get_Range(cell_R, cell_S);
                            cell_RS.Interior.Color = System.Drawing.Color.Violet;
                            Range cell_TU = sheet.get_Range(cell_T, cell_U);
                            cell_TU.Interior.Color = System.Drawing.Color.CornflowerBlue;
                            //cell_ST.Font.ColorIndex = System.Drawing.Color.Red ;                               
                        }
                    }
                }//添加數據結束




                //最後一個工作表添加退料的Sheet
                //Worksheet sheet_return = app.Worksheets[sheet_total + 1] as Worksheet;
                Worksheet sheet_return = app.Worksheets[2] as Worksheet;
                sheet_return.Name = "外發退料";
                sheet_return.Cells[1, 1] = "單據編號";
                sheet_return.Cells[1, 2] = "供應商編號";
                sheet_return.Cells[1, 3] = "供應商名稱";
                sheet_return.Cells[1, 4] = "退貨日期";
                sheet_return.Cells[1, 5] = "頁數";
                sheet_return.Cells[1, 6] = "貨品編號";
                sheet_return.Cells[1, 7] = "貨品名稱";
                sheet_return.Cells[1, 8] = "貨品編號(加工後)";
                sheet_return.Cells[1, 9] = "退貨數量";
                sheet_return.Cells[1, 10] = "退貨重量";

                //添加數據
                if (dtOut_reurn.Rows.Count > 0)
                {
                    //***************
                    //設置進度條屬性
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = dtOut_reurn.Rows.Count;
                    //***************

                    int row = dtOut_reurn.Rows.Count;
                    int col = dtOut_reurn.Columns.Count;
                    for (int k = 0; k < row; k++)
                    {
                        //************
                        //顯示進度條
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        //*************

                        sheet_return.Rows.RowHeight = 20; //行高  
                        sheet_return.Rows.Font.Size = 10;
                        for (int j = 0; j < col; j++)
                        {
                            string str = dtOut_reurn.Rows[k][j].ToString();
                            sheet_return.Cells[k + 2, j + 1] = str;
                        }
                    }
                }


                //保存工作簿                   
                wBook.Save();
                //保存excel文件   
                app.Save(filePath);
                app.SaveWorkspace(filePath);
                app.Quit();
                wBook = null;
                sheet = null;
                sheet_return = null;
                app = null;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    lblSend.Text = "發貨日期";
                    break;
                case 1:
                    lblSend.Text = "收貨日期";                
                    break;
                case 2:
                    lblSend.Text = "移交日期";
                    break;
            }
        }

    }
}
