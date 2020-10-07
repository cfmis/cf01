using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.IO;
using System.Threading;

namespace cf01.Forms
{
    public partial class frmOrderCosting : Form
    {
        public static string getProductId = "";
        public frmOrderCosting()
        {
            InitializeComponent();
        }


        private void txtMo_from_Leave(object sender, EventArgs e)
        {
            txtMo_to.Text = txtMo_from.Text;
        }

        private void txtItem_from_Leave(object sender, EventArgs e)
        {
            txtItem_to.Text = txtItem_from.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderCosting_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            if (getProductId == "")
            {
                txtDateFrom.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
                txtDateTo.Text = txtDateFrom.Text;
            }
            else
            {
                txtItem_from.Text = getProductId;
                txtItem_to.Text = txtItem_from.Text;
                btnFind_Click(sender, e);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            txtMo_to.Focus();
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
            int type = 3;
            if (rdbIsCosting.Checked == true)
                type = 1;
            else if (rdbNoCosting.Checked == true)
                type = 0;
            DataTable dtOrderCosting = clsMmCosting.findOrderCosting(type, txtDateFrom.Text, txtDateTo.Text, txtItem_from.Text
                , txtItem_to.Text, txtMo_from.Text, txtMo_to.Text);
            dgvDetails.DataSource = dtOrderCosting;
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合條件的記錄!");
                return;
            }
            Color colorLine = Color.FromArgb(224, 224, 224);
            if (this.dgvDetails.Rows.Count != 0)
            {
                for (int i = 1; i < this.dgvDetails.Rows.Count;)
                {
                    this.dgvDetails.Rows[i].DefaultCellStyle.BackColor = colorLine;// System.Drawing.Color.Pink;//.DarkGray;//;
                    i += 2;
                }
            }
        }
        private void txtDateFrom_Leave(object sender, EventArgs e)
        {
            txtDateTo.Text = txtDateFrom.Text;
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
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
    }
}
