using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;
using System.IO;
using cf01.Forms;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace cf01.ReportForm
{
    public partial class frmOcCustomer : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();       
        int groups ;
        System.Data.DataTable dtReport = new System.Data.DataTable();
        System.Data.DataTable dtReport2 = new System.Data.DataTable();
        System.Data.DataTable dtGroup = new System.Data.DataTable();
        public frmOcCustomer()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOcCustomer_Load(object sender, EventArgs e)
        {           
            //if (string.IsNullOrEmpty(txtDat2.Text))
            //{
            //    txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            //}

            //txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            //this.ActiveControl = txtDat2;  
            //txtDat2.Focus();

            string strSql = string.Format(@"Select '' as id,'' as cdesc union Select id ,id+' ('+name+')' AS cdesc From {0}cd_mo_type Where mo_type='3' and id>'3'", DBUtility.remote_db);         
            System.Data.DataTable dtSales_Group = new System.Data.DataTable();
            dtSales_Group = clsPublicOfCF01.GetDataTable(strSql);
            luesales_group_id.Properties.DataSource = dtSales_Group;
            luesales_group_id.Properties.ValueMember = "id";
            luesales_group_id.Properties.DisplayMember = "cdesc";

            strSql = string.Format(@"Select '' as id,'' as cdesc union Select id,id+' ('+name+')' AS cdesc From {0}cd_country Where state='0'", DBUtility.remote_db);
            System.Data.DataTable dtCountry = new System.Data.DataTable();
            dtCountry = clsPublicOfCF01.GetDataTable(strSql);
            luecountry_id.Properties.DataSource = dtCountry;
            luecountry_id.Properties.ValueMember = "id";
            luecountry_id.Properties.DisplayMember = "cdesc";

            strSql = string.Format(@"Select '' as id,'' as cdesc union Select id,id+' ('+name+')' AS cdesc From {0}cd_zone Where state='0'", DBUtility.remote_db);
            System.Data.DataTable dtArea = new System.Data.DataTable();
            dtArea = clsPublicOfCF01.GetDataTable(strSql);
            luearea.Properties.DataSource = dtArea;
            luearea.Properties.ValueMember = "id";
            luearea.Properties.DisplayMember = "cdesc";


            
        }

        private void frmOcCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
            dtReport2.Dispose();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        { 
            //if (txtDat1.Text == "" && txtDat2.Text == "" )
            //{
            //    MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtDat1.Focus();
            //    return;
            //}

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@date_begin",txtDat1.Text),
                new SqlParameter("@date_end",txtDat2.Text),
                new SqlParameter("@sales_group_id",luesales_group_id.EditValue),
                new SqlParameter("@country_id",luecountry_id.EditValue),
                new SqlParameter("@area",luearea.EditValue),
                new SqlParameter("@final_destination",txtfinal_destination.Text)                
            };            
            dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_cust_area_country", paras);           
            dgvDetails.DataSource = dtReport;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            //TataTable過濾問題
            //DataView dv = dtReport.DefaultView;
            //if (txtSales_group.Text != "")
            //{               
            //    dv.RowFilter = string.Format("mo_group='{0}'", txtSales_group.Text);                
            //}
            //dgvDetails.DataSource = dv;
           
            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }                 
            }
            else
            {
                dtReport.Clear();               
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDat2.EditValue = txtDat1.EditValue;
        }  

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //ExpToExcel xls = new ExpToExcel();
            //xls.ExportExcel(dgvDetails);         
            Export_To_Excel();
            
        }

       
        private void Export_To_Excel()
        {
            if (dgvDetails.RowCount > 0)
            {               
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    /*saveDialog.DefaultExt = "";*/
                    Title = "保存EXECL文件",
                    Filter = "EXECL文件|*.xls",
                    FilterIndex = 1
                };
                if (saveDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string FileName = saveDialog.FileName;
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }
                int FormatNum;//保存excel文件的格式
                string Version;//excel版本號

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
                    return;
                }
                Version = xlApp.Version;//獲取當前使用excel版本號
                if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                {
                    FormatNum = -4143;
                }
                else //you use excel 2007 or later
                {
                    FormatNum = 56;
                }
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                worksheet.Rows[1].Font.Size = 9;
                worksheet.Rows[1].Font.Bold = true;//粗體                    
                //sheet第一行表頭
                worksheet.Cells[1, 1] = "營業組别";
                worksheet.Cells[1, 2] = "客户編號";
                worksheet.Cells[1, 3] = "客户名稱";
                worksheet.Cells[1, 4] = "送貨地址";
                worksheet.Cells[1, 5] = "國家/地區";
                worksheet.Cells[1, 6] = "國家/地區名稱";
                worksheet.Cells[1, 7] = "区域代碼";
                worksheet.Cells[1, 8] = "区域名稱";
                worksheet.Cells[1, 9] = "付款方式";
                worksheet.Cells[1, 10] = "價格條件";
                worksheet.Cells[1, 11] = "最絡目的地";
                worksheet.Cells[1, 12] = "總金額(HKD)";                
                worksheet.Rows[1].RowHeight = 20;
                worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //標題自動換行
                Microsoft.Office.Interop.Excel.Range Range1 = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", "L1");
                Range1.WrapText = true;

                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dgvDetails.RowCount;
                //寫入數值
                for (int r = 0; r < dgvDetails.RowCount; r++)//行
                {
                    //顯示進度條
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }       
                    worksheet.Cells[r + 2, 1] = dgvDetails.Rows[r].Cells["mo_group"].Value.ToString();
                    worksheet.Cells[r + 2, 2] = dgvDetails.Rows[r].Cells["customer_id"].Value.ToString();
                    worksheet.Cells[r + 2, 3] = dgvDetails.Rows[r].Cells["customer_name"].Value.ToString();
                    worksheet.Cells[r + 2, 4] = dgvDetails.Rows[r].Cells["s_address"].Value.ToString();
                    worksheet.Cells[r + 2, 5] = dgvDetails.Rows[r].Cells["c_code"].Value.ToString();
                    worksheet.Cells[r + 2, 6] = dgvDetails.Rows[r].Cells["country_name"].Value.ToString();
                    worksheet.Cells[r + 2, 7] = dgvDetails.Rows[r].Cells["area"].Value.ToString();
                    worksheet.Cells[r + 2, 8] = dgvDetails.Rows[r].Cells["area_name"].Value.ToString();
                    worksheet.Cells[r + 2, 9] = dgvDetails.Rows[r].Cells["payment_id"].Value.ToString();
                    worksheet.Cells[r + 2, 10] = dgvDetails.Rows[r].Cells["price_condition"].Value.ToString();
                    worksheet.Cells[r + 2, 11] = dgvDetails.Rows[r].Cells["final_destination"].Value.ToString();
                    worksheet.Cells[r + 2, 12] = dgvDetails.Rows[r].Cells["amt_hkd"].Value.ToString();                                                            
                    worksheet.Rows[r + 2].Font.Size = 9;
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                worksheet.Columns[1].ColumnWidth = 5;
                //worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Columns[2].ColumnWidth = 7;
                worksheet.Columns[3].ColumnWidth = 35;
                worksheet.Columns[4].ColumnWidth = 62;
                worksheet.Columns[5].ColumnWidth = 6;
                worksheet.Columns[6].ColumnWidth = 13;
                worksheet.Columns[7].ColumnWidth = 4;
                worksheet.Columns[8].ColumnWidth = 5;
                worksheet.Columns[9].ColumnWidth = 10;
                worksheet.Columns[10].ColumnWidth = 21;
                worksheet.Columns[11].ColumnWidth = 10;
                worksheet.Columns[12].ColumnWidth = 5;
                //畫边框线
                //获取Excel多个单元格区域
                string range_right = string.Format("L{0}", dgvDetails.RowCount + 2);//右下角座標
                Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", range_right);
                //单元格边框线类型(线型,虚线型)
                excelRange.Borders.LineStyle = 1;
                excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                
                if (FileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        //workbook.SaveCopyAs(saveFileName);
                        workbook.SaveAs(FileName, FormatNum);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                    }
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;
                xlApp.Quit();
                GC.Collect();//强行销毁
                // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("匯出EXCEL成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtSales_group_Leave(object sender, EventArgs e)
        {
            //if (dtReport.Rows.Count > 0 && txtSales_group.Text!="")
            //{
            //    DataView dv = dtReport.DefaultView;
            //    if (txtSales_group.Text != "")
            //    {
            //        dv.RowFilter = string.Format("mo_group='{0}'", txtSales_group.Text);
            //    }
            //    dgvDetails.DataSource = dv;
            //}
        }


     
    }
}
