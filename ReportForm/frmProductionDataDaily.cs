using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using cf01.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmProductionDataDaily : Form
    {
        public frmProductionDataDaily()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductionDataDaily_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            mskDat1.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            mskDat2.Text = mskDat1.Text;
            txtDep.Text = "302";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            LoadData();
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void LoadData()
        {
            string dat1 = "";
            string dat2 = "";
            dat1 = mskDat1.Text;
            dat2 = mskDat2.Text;

            if (dat1.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(dat1))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat1.Focus();
                    return;
                }
            }
            else
                dat1 = "";

            if (dat2.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(dat2))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat2.Focus();
                    return;
                }
                dat2 = Convert.ToDateTime(dat2).AddDays(1).ToString("yyyy/MM/dd");
            }
            else
                dat2 = "";


            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@dep", txtDep.Text),
                new SqlParameter("@dat1", dat1),
                new SqlParameter("@dat2", dat2)
                };
            DataTable dtReport = clsPublicOfCF01.ExecuteProcedure("usp_pd_productiondata_daily", paras);


            dgvDetails.DataSource = dtReport;

            if (dtReport.Rows.Count == 0)
                MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            DvExportExcel();
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
                        if (columnNo != 0)
                            col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        else
                            //col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value + "\"";
                        col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }
    }
}
