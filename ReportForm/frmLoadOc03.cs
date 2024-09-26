using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ModuleClass;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Reflection;
using System.Threading;
using cf01.Forms;
using cf01.CLS;


namespace cf01.ReportForm
{
    public partial class frmLoadOc03 : Form
    {

       // private string fileNameString;

        clsCommonUse commUse = new clsCommonUse();

        //string lang_id = PropertyClass.LanguageId;
        string lang_id = DBUtility._language;
        string user_id = "small_lam";//DBUtility._user_id;

        public frmLoadOc03()
        {
            InitializeComponent();
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("訂單日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
            }
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(new ThreadStart(StartSomeWorkFromUIThread));
            thread.IsBackground = true;
            thread.Start();
        }
        private void find_data()
        {
            string dat1 = "", dat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false)
                dat1 = this.dateEdit1.Text.ToString();// Convert.ToDateTime(this.dateEdit1.EditValue).ToString("yyyy/mm/dd");
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
                dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
            int f_type, mo_group_select;
            mo_group_select = cmbMoGroup.SelectedIndex;
            string mo_group;
            mo_group = "ALL";
            if (cmbCpl.SelectedIndex == -1 || cmbCpl.SelectedItem.ToString() == "")
                f_type = 1;
            else
                f_type = cmbCpl.SelectedIndex + 1;
            if (mo_group_select == -1 || cmbMoGroup.SelectedItem.ToString() == "" || mo_group_select == 0)
                mo_group = "ALL";
            else
                if (mo_group_select <= 27)
                    mo_group = Convert.ToChar(64 + mo_group_select).ToString();
                else
                    if (mo_group_select == 28)//PDD
                        mo_group = "PDD";

            DataTable dt = commUse.getDataProcedure("z_load_oc03",
                new object[] { 1,f_type,lang_id,mo_group,user_id,textBox1.Text, textBox2.Text, dat1, dat2
                    ,textBox3.Text, textBox4.Text,textBox5.Text,textBox6.Text,textBox11.Text,textBox12.Text
                    ,textBox8.Text,textBox9.Text,textBox10.Text});
            dgvDetails.DataSource = dt;

            //查詢操作結束，隱藏進度指示器
            progressIndicatorAbout.Stop();
            progressIndicatorAbout.Visible = false;


        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoadOc03_Load(object sender, EventArgs e)
        {
            this.Text = "Oorder Status";
            this.dateEdit1.EditValue = DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
            this.dateEdit2.EditValue = DateTime.Now.ToString("yyyy/MM/dd");

            clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            forminit.GenerateContorl();

            //綁定表格
            //commUse.BuilDataGridView(dgvDetails, "frmloadoc03_grid1", lang_id);
            //commUse.BuilDataGridView(dgvPrdDetails, "frmloadoc03_grid2", lang_id);
            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "order_complete_status" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbCpl, "formname", "show_name", strsql, "v_dict_group");
            strsql = "Select * from v_dict_group where formname=" + "'" + "Mo_Group" + "'" +
                    " AND language_id =" + "'" + lang_id + "'" + " Order By tb_col_sort";
            commUse.BindComboBox(cmbMoGroup, "formname", "show_name", strsql, "v_dict_group");
            //cmbCpl.Items.Add("0--No Complete");
            //cmbCpl.Items.Add("1--Complete");
            //cmbCpl.Items.Add("2--All");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox4.Text = textBox3.Text;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }

        private void cmdExp_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync(); // 运行 backgroundWorker 组件

            frmProgressBar form = new frmProgressBar(this.backgroundWorker1);// 显示进度条窗体 
            form.ShowDialog(this);
            form.Close();


        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                string strMo = this.dgvDetails["mo_id", this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
                textBox7.Text = strMo;
                loadMo(strMo);
            }
        }
        private void loadMo(string mo)
        {

            DataTable dt = commUse.getDataProcedure("z_load_oc03",
                new object[] { 2, 1, lang_id, "", user_id, "", "", "", "", "", "", "", "", mo, "", "", "", "" });
            dgvPrdDetails.DataSource = dt;
        }


        private void btnFindBrand_Click(object sender, EventArgs e)
        {
            //ReportForm.frmLoadBrand frmBrand = new ReportForm.frmLoadBrand();
            frmFindDataBase frmBrand = new frmFindDataBase(btnFindBrand.Name);
            frmBrand.Owner = this;
            frmBrand.ShowDialog();
            textBox1.Text = DBUtility.get_query_id;
            textBox2.Text = DBUtility.get_query_id;
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            //ReportForm.frmLoadCust frmCust = new ReportForm.frmLoadCust();
            frmFindDataBase frmCust = new frmFindDataBase(btnFindCustomer.Name);
            frmCust.Owner = this;
            frmCust.ShowDialog();
            textBox3.Text = DBUtility.get_query_id;
            textBox4.Text = DBUtility.get_query_id;
        }

        private void SaveToExcel(DataGridView _dgv, BackgroundWorker _worker)//
        {
            string fileNameString = ExpToExcel.GetFileName(_dgv);
            if (fileNameString == "" || fileNameString == null)
            {
                return;
            }

            int rowscount = _dgv.Rows.Count;
            int colscount = _dgv.Columns.Count;
            int intValue = 0;
            //创建空EXCEL对象
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objSheet = null;
            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.Worksheets[1];//强制类型转换
                //设置EXCEL不可见(后台运行)   
                objExcel.Visible = false;
                int order_qty_pcs, cpl_qty_pcs, inv_qty_pcs;
                string req_dat, cpl_dat, inv_dat;

                //向Excel中写入表格的表头   
                int displayColumnsCount = 1;
                for (int i = 0; i <= _dgv.ColumnCount - 1; i++)
                {
                    if (_dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = _dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //設置行的字體
                Microsoft.Office.Interop.Excel.Range rg1 = (Microsoft.Office.Interop.Excel.Range)
                        objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[1, colscount]];
                rg1.Font.Bold = true;
                rg1.Font.Size = 10;
                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= _dgv.RowCount - 1; row++)
                {
                    Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)
                        objSheet.Range[objSheet.Cells[row + 2, 1], objSheet.Cells[row + 2, colscount]];
                    //rg.Font.Bold = true;
                    rg.Font.Size = 10;
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (_dgv.Columns[col].Visible == true)
                        {
                            if (col != 7)
                                objExcel.Cells[row + 2, displayColumnsCount] = _dgv.Rows[row].Cells[col].Value.ToString().Trim();
                            else
                                objExcel.Cells[row + 2, displayColumnsCount] = "'" + _dgv.Rows[row].Cells[col].Value.ToString().Trim();//營業員
                            if (col == 20)
                            {
                                if (_dgv.Rows[row].Cells[col].Value != null)
                                    order_qty_pcs = Convert.ToInt32(_dgv.Rows[row].Cells[col].Value);//訂單數量
                                else
                                    order_qty_pcs = 0;
                                if (_dgv.Rows[row].Cells[col + 6].Value != null)
                                    req_dat = _dgv.Rows[row].Cells[col + 6].Value.ToString();//客人要求交貨日期
                                else
                                    req_dat = "";
                                if (_dgv.Rows[row].Cells[col + 1].Value != null)
                                    cpl_qty_pcs = Convert.ToInt32(_dgv.Rows[row].Cells[col + 1].Value);//完成(回港)數量
                                else
                                    cpl_qty_pcs = 0;
                                if (_dgv.Rows[row].Cells[col + 4].Value != null)
                                    cpl_dat = _dgv.Rows[row].Cells[col + 4].Value.ToString();//完成(回港)日期
                                else
                                    cpl_dat = "";
                                if (_dgv.Rows[row].Cells[col + 2].Value != null)
                                    inv_qty_pcs = Convert.ToInt32(_dgv.Rows[row].Cells[col + 2].Value);//發票數量
                                else
                                    inv_qty_pcs = 0;
                                if (_dgv.Rows[row].Cells[col + 7].Value != null)
                                    inv_dat = _dgv.Rows[row].Cells[col + 7].Value.ToString();//交貨(發票)日期
                                else
                                    inv_dat = "";
                                if (order_qty_pcs > inv_qty_pcs && string.Compare(DateTime.Now.ToString("yyyy/MM/dd"), req_dat) > 0)//未完成，已過期(即當前日期大於要求日期)
                                {
                                    rg.Interior.ColorIndex = 3;
                                    rg.Interior.Pattern = -4105;
                                }
                                else
                                {
                                    if (inv_qty_pcs >= order_qty_pcs && string.Compare(inv_dat, req_dat) > 0)//已完成，但交貨期大於要求日期
                                    {
                                        rg.Interior.ColorIndex = 22;
                                        rg.Interior.Pattern = -4105;
                                    }
                                    else
                                    {
                                        if (inv_qty_pcs >= order_qty_pcs && string.Compare(inv_dat, req_dat) < 0)//已完成，但交貨期小於要求日期
                                        {
                                            rg.Interior.ColorIndex = 28;
                                            rg.Interior.Pattern = -4105;
                                        }
                                    }
                                }
                            }
                            displayColumnsCount++;
                        }
                    }
                    intValue++;

                    Thread.Sleep(100);
                    string strMessage = ((100 * intValue) / rowscount).ToString() + "%";
                    _worker.ReportProgress(((100 * intValue) / rowscount), strMessage); //注意：这里向子窗体返回两个信息值，一个用于进度条，一个用于label的。
                    System.Windows.Forms.Application.DoEvents();



                }

                //objSheet.Columns.EntireColumn.AutoFit();//列宽自适应
                //保存文件   
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objSheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox10.Text = textBox9.Text;
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            textBox12.Text = textBox11.Text;
        }

        private void BTNExpMo_Click(object sender, EventArgs e)
        {
            ExpToExcel expxls = new ExpToExcel();
            expxls.DvExportToExcel(dgvPrdDetails);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SaveToExcel(dgvDetails, worker);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
            }
            else
            {
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.DvExportExcel();
        }
        private void DvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                for (int i = 0; i < dgvDetails.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容
                string col_value;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                    {

                        if (columnNo > 0)
                        {
                            tempstr += "\t";
                        }
                        if (columnNo != 7)
                            col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        else
                            col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value + "\"";
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox1.Focus();

        }
        private void StartSomeWorkFromUIThread()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new EventHandler(RunsOnWorkerThread), null);

                find_data();
            }
            else
            {
                RunsOnWorkerThread(this, null);
            }
        }

        private void RunsOnWorkerThread(object sender, EventArgs e)
        {
            Thread.Sleep(500);

            progressIndicatorAbout.Visible = true;
            progressIndicatorAbout.Start();
            progressIndicatorAbout.CircleColor = Color.LightGreen;
            progressIndicatorAbout.Show();
        }

    }
}
