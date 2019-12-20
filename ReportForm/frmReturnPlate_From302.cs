using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.Forms;

namespace cf01.ReportForm
{
    public partial class frmReturnPlate_From302 : Form
    {
        clsCommonUse commUse = new clsCommonUse();
        public frmReturnPlate_From302()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReturnPlate_From302_Load(object sender, EventArgs e)
        {
            txtDep.Text = "302";
            mktDate1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            mktDate2.Text = mktDate1.Text;
            dgvDetails.AutoGenerateColumns = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            findData(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            
        }
        private void findData()
        {
            string dat1 = "", dat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mktDate1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mktDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktDate1.Text) == false || clsValidRule.CheckDateFormat(this.mktDate2.Text) == false)
                {
                    MessageBox.Show("日期不正確!");
                    this.mktDate1.Focus();
                    return;
                }
                else
                {
                    dat1 = mktDate1.Text;
                    dat2 = Convert.ToDateTime(mktDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
                }
            }

            DataTable dt1 = commUse.getDataProcedure("usp_ReturnPlate_From302",
                new object[] { txtDep.Text, txtMo.Text,dat1,dat2});
            dgvDetails.DataSource = dt1;
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
                        if (columnNo != 1)
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

    }
}
