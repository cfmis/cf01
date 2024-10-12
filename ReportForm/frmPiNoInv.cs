using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using cf01.CLS;
using System.Threading;
using cf01.Forms;

namespace cf01.ReportForm
{
    public partial class frmPiNoInv : Form
    {

        public frmPiNoInv()
        {
            InitializeComponent();
        }

        private void frmPiNoInv_Load(object sender, EventArgs e)
        {
            BindDataGridView("99");
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string _type = "80";
            string dat1 = "", dat2 = "", crdat1 = "", crdat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("訂單日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
                else
                {
                    dat1 = this.dateEdit1.Text.ToString();
                    dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit3.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit4.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit3.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit4.Text) == false)
                {
                    MessageBox.Show("建立日期不正確!");
                    this.dateEdit3.Focus();
                    return;
                }
                else
                {
                    crdat1 = this.dateEdit3.Text.ToString();
                    crdat2 = Convert.ToDateTime(this.dateEdit4.Text).AddDays(1).ToString("yyyy/MM/dd");
                }
            }
            if (rbNoInv.Checked == true)
                _type = "80";
            else
                if (rbHaveInv.Checked == true)
                    _type = "81";
                else
                    if (rbAllOc.Checked == true)
                        _type = "82";
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            clsCommonUse c = new clsCommonUse();
            DataTable dt = c.getDataProcedure("pr_pinoinvoice",
                new object[] { _type, textBox1.Text, textBox2.Text, dat1, dat2,crdat1
                ,crdat2, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text
                , textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text
                ,textBox13.Text,textBox14.Text,textBox15.Text,textBox16.Text,textBox17.Text,textBox18.Text,"",""});
            BindDataGridView(_type);
            dgvDetails.DataSource = dt;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

        private void BindDataGridView(string dvgType)
        {
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add("mo_id", "制單編號");
            dgvDetails.Columns["mo_id"].DataPropertyName = "mo_id";
            dgvDetails.Columns.Add("order_date", "訂單日期");
            dgvDetails.Columns["order_date"].DataPropertyName = "order_date";
            dgvDetails.Columns.Add("sequence_id", "序號");
            dgvDetails.Columns["sequence_id"].DataPropertyName = "sequence_id";
            dgvDetails.Columns.Add("goods_id", "產品編號");
            dgvDetails.Columns["goods_id"].DataPropertyName = "goods_id";
            dgvDetails.Columns.Add("goods_name", "產品描述");
            dgvDetails.Columns["goods_name"].DataPropertyName = "goods_name";
            dgvDetails.Columns.Add("order_qty", "訂單數量");
            dgvDetails.Columns["order_qty"].DataPropertyName = "order_qty";
            dgvDetails.Columns.Add("goods_unit", "數量單位");
            dgvDetails.Columns["goods_unit"].DataPropertyName = "goods_unit";
            dgvDetails.Columns.Add("unit_price", "單價");
            dgvDetails.Columns["unit_price"].DataPropertyName = "unit_price";
            dgvDetails.Columns.Add("p_unit", "單價單位");
            dgvDetails.Columns["p_unit"].DataPropertyName = "p_unit";
            dgvDetails.Columns.Add("it_customer", "客戶編號");
            dgvDetails.Columns["it_customer"].DataPropertyName = "it_customer";
            dgvDetails.Columns.Add("cust_name", "客戶描述");
            dgvDetails.Columns["cust_name"].DataPropertyName = "cust_name";
            dgvDetails.Columns.Add("agent", "洋行代號");
            dgvDetails.Columns["agent"].DataPropertyName = "agent";
            dgvDetails.Columns.Add("brand_id", "牌子編號");
            dgvDetails.Columns["brand_id"].DataPropertyName = "brand_id";
            dgvDetails.Columns.Add("seller_id", "營業員代號");
            dgvDetails.Columns["seller_id"].DataPropertyName = "seller_id";
            dgvDetails.Columns.Add("customer_goods", "客戶產品編號");
            dgvDetails.Columns["customer_goods"].DataPropertyName = "customer_goods";
            dgvDetails.Columns.Add("contract_id", "客戶PO");
            dgvDetails.Columns["contract_id"].DataPropertyName = "contract_id";
            dgvDetails.Columns.Add("id", "OC編號");
            dgvDetails.Columns["id"].DataPropertyName = "id";
            dgvDetails.Columns.Add("merchandiser", "跟單員代號");
            dgvDetails.Columns["merchandiser"].DataPropertyName = "merchandiser";
            dgvDetails.Columns.Add("amt_bef_dis", "金額(折扣前)");
            dgvDetails.Columns["amt_bef_dis"].DataPropertyName = "amt_bef_dis";
            dgvDetails.Columns.Add("disc_rate", "折扣%");
            dgvDetails.Columns["disc_rate"].DataPropertyName = "disc_rate";
            dgvDetails.Columns.Add("total_sum", "金額(折扣後)");
            dgvDetails.Columns["total_sum"].DataPropertyName = "total_sum";
            dgvDetails.Columns.Add("m_id", "貨幣代號");
            dgvDetails.Columns["m_id"].DataPropertyName = "m_id";
            dgvDetails.Columns.Add("oc_qty_pcs", "數量(PCS)");
            dgvDetails.Columns["oc_qty_pcs"].DataPropertyName = "oc_qty_pcs";
            dgvDetails.Columns.Add("oc_amt_hkd", "金額_HKD(折扣前)");
            dgvDetails.Columns["oc_amt_hkd"].DataPropertyName = "oc_amt_hkd";
            dgvDetails.Columns.Add("oc_amt_hkd_dis", "金額_HKD(折扣後)");
            dgvDetails.Columns["oc_amt_hkd_dis"].DataPropertyName = "oc_amt_hkd_dis";
            dgvDetails.Columns.Add("c_date", "建立日期");
            dgvDetails.Columns["c_date"].DataPropertyName = "c_date";
            dgvDetails.Columns.Add("m_state", "狀態");
            dgvDetails.Columns["m_state"].DataPropertyName = "m_state";
            dgvDetails.Columns.Add("d_state", "狀態");
            dgvDetails.Columns["d_state"].DataPropertyName = "d_state";
            dgvDetails.Columns.Add("inv_doc", "發票編號");
            dgvDetails.Columns["inv_doc"].DataPropertyName = "inv_doc";
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

                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                    {
                        if (dgvDetails.Columns[columnNo].Visible == true)
                        {
                            if (columnNo > 0)
                            {
                                tempstr += "\t";
                            }
                            if (dgvDetails.Rows[rowNo].Cells[columnNo].Value != null)
                                if (columnNo == 9 || columnNo == 17)
                                    tempstr += "'" + dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                                else
                                    tempstr += dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                            else
                                tempstr += "";
                        }
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
            }
        }

        private void dateEdit1_Leave(object sender, EventArgs e)
        {
            this.dateEdit2.Text = this.dateEdit1.Text;
        }

        private void dateEdit3_Leave(object sender, EventArgs e)
        {
            this.dateEdit4.Text = this.dateEdit3.Text;
        }

       
    }
}
