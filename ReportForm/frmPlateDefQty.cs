using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.IO;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmPlateDefQty : Form
    {
       
        public frmPlateDefQty()
        {
            InitializeComponent();
            clsPublic objPublic = new clsPublic(this.Name, this.Controls);
            objPublic.GenerateData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.Text = txtDat1.Text;
        }

        private void txtRecDat1_Leave(object sender, EventArgs e)
        {
            txtRecDat2.Text = txtRecDat1.Text;
        }

        private void textId1_Leave(object sender, EventArgs e)
        {
            textId2.Text = textId1.Text;
        }

        private void textRecId1_Leave(object sender, EventArgs e)
        {
            textRecId2.Text = textRecId1.Text;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string dat1, dat2, in_dat1, in_dat2;
            dat1 = "";
            dat2 = "";
            in_dat1 = "";
            in_dat2 = "";
            int show_type;
            show_type = 1;
            if (clsValidRule.CheckDateIsEmpty(this.txtDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.txtDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.txtDat1.Text) == false || clsValidRule.CheckDateFormat(this.txtDat2.Text) == false)
                {
                    MessageBox.Show("發貨日期不正確!");
                    this.txtDat1.Focus();
                    return;
                }
                else
                {
                    dat1 = this.txtDat1.Text.ToString();
                    dat2 = Convert.ToDateTime(this.txtDat2.Text).AddDays(1).ToString("yyyy/MM/dd");
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.txtRecDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.txtRecDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.txtRecDat1.Text) == false || clsValidRule.CheckDateFormat(this.txtRecDat2.Text) == false)
                {
                    MessageBox.Show("收貨日期不正確!");
                    this.txtRecDat1.Focus();
                    return;
                }
                else
                {
                    in_dat1 = this.txtRecDat1.Text.ToString();
                    in_dat2 = Convert.ToDateTime(this.txtRecDat2.Text).AddDays(1).ToString("yyyy/MM/dd");
                }
            }
            if (this.rbShowQty1.Checked == true)
                show_type = 1;
            if (this.rbShowQty2.Checked == true)
                show_type = 2;
            clsCommonUse c = new clsCommonUse();
            DataTable dt = c.getDataProcedure("pr_plate_def_qty",
                    new object[] { show_type, dat1, dat2, in_dat1, in_dat2
                        , textId1.Text, textId2.Text, textRecId1.Text, textRecId2.Text, textMo1.Text, textMo2.Text });
            dgvDetails.DataSource = dt;
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.DvExportExcel();
        }

        private void textMo1_Leave(object sender, EventArgs e)
        {
            textMo2.Text = textMo1.Text;
        }
    }
}
