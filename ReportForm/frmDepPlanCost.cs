using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using cf01.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmDepPlanCost : Form
    {
        public frmDepPlanCost()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }
        private void findData()
        {
            txtMoFrom.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            findDataProcess(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void findDataProcess()
        {
            int Report_type = 0;
            if (rdgReportType.SelectedIndex == 1)
                Report_type = 1;
            string Plan_date_from = txtOrderDateFrom.Text;
            string Plan_date_to = txtOrderDateTo.Text;
            string strSql = "usp_CountOrderPlanCost";
            SqlParameter[] parameters = {new SqlParameter("@isSetCost", Report_type)
                        ,new SqlParameter("@order_date1", Plan_date_from)
                        ,new SqlParameter("@order_date2", Plan_date_to)
                        ,new SqlParameter("@mo_from", txtMoFrom.Text)
                        ,new SqlParameter("@mo_to", txtMoTo.Text)
                        };

            Color colorLine = Color.FromArgb(224, 224, 224);
            DataTable dtCost = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, parameters);
            dgvDetails.DataSource = dtCost;
            if (this.dgvDetails.Rows.Count != 0)
            {
                for (int i = 1; i < this.dgvDetails.Rows.Count;)
                {
                    this.dgvDetails.Rows[i].DefaultCellStyle.BackColor = colorLine;// System.Drawing.Color.SlateGray;//.DarkGray;//.Pink;
                    i += 2;
                }
            }
        }

        private void frmProductProcessCost_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            rdgReportType.SelectedIndex = 1;
        }


        private void txtMoFrom_Leave(object sender, EventArgs e)
        {
            txtMoTo.Text = txtMoFrom.Text;
        }

        private void btnExpToExcl_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

        /// <summary>
        /// 匯出Excel
        /// </summary>
        private void DvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {


                //frmProgress wForm = new frmProgress();
                //new Thread((ThreadStart)delegate
                //{
                //    wForm.TopMost = true;
                //    wForm.ShowDialog();
                //}).Start();

                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";

                //写标题
                for (int i = 0; i < dgvDetails.ColumnCount; i++)
                {
                    str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                    str += "\t";
                }
                sw.WriteLine(str);

                //写内容
                string col_value;

                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount - 1; columnNo++)
                    {
                        if (dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() != null)
                        {
                            if (columnNo == 13)
                                //col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() + "\"";
                                col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                            else
                                col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        }
                        else
                            col_value = "";
                        tempstr += col_value;
                        tempstr += "\t";
                    }
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void txtOrderDateFrom_Leave(object sender, EventArgs e)
        {
            txtOrderDateTo.Text = txtOrderDateFrom.Text;
        }
    }
}
