using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmOcNoQc : Form
    {

        public frmOcNoQc()
        {
            InitializeComponent();
        }

        private void frmOcNoQc_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string _type = "90";
            string dat1 = "", dat2 = "", crdat1 = "", crdat2 = "";
            BindDataGridView();


            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("訂單日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false)
                dat1 = this.dateEdit1.Text.ToString();
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
                dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit3.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit4.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit3.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit4.Text) == false)
                {
                    MessageBox.Show("訂單建立日期不正確!");
                    this.dateEdit3.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit3.Text) == false)
                crdat1 = this.dateEdit3.Text.ToString();
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit4.Text) == false)
                crdat2 = Convert.ToDateTime(this.dateEdit4.Text).AddDays(1).ToString("yyyy/MM/dd");

            if (rbNoInv.Checked == true)
                _type = "90";
            else
                if (rbHaveInv.Checked == true)
                    _type = "91";
                else
                    if (rbAllOc.Checked == true)
                        _type = "92";
            clsCommonUse c = new clsCommonUse();
            DataTable dt = c.getDataProcedure("z_load_oc01",
                new object[] { _type, textBox1.Text, textBox2.Text, dat1, dat2,crdat1
                ,crdat2, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text
                , textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text
                ,textBox13.Text,textBox14.Text,textBox15.Text,textBox16.Text,textBox17.Text,textBox18.Text});
            dgvDetails.DataSource = dt;
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

        private void BindDataGridView()
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
            dgvDetails.Columns.Add("oc_qty_pcs", "數量(PCS)");
            dgvDetails.Columns["oc_qty_pcs"].DataPropertyName = "oc_qty_pcs";
            dgvDetails.Columns.Add("c_date", "建立日期");
            dgvDetails.Columns["c_date"].DataPropertyName = "c_date";
            dgvDetails.Columns.Add("m_state", "狀態");
            dgvDetails.Columns["m_state"].DataPropertyName = "m_state";
            dgvDetails.Columns.Add("d_state", "狀態");
            dgvDetails.Columns["d_state"].DataPropertyName = "d_state";
            dgvDetails.Columns.Add("goods_qc", "物料編號QC");
            dgvDetails.Columns["goods_qc"].DataPropertyName = "goods_qc";
            dgvDetails.Columns.Add("charge_dept", "負責部門");
            dgvDetails.Columns["charge_dept"].DataPropertyName = "charge_dept";
            dgvDetails.Columns.Add("next_wp_id", "接收部門");
            dgvDetails.Columns["next_wp_id"].DataPropertyName = "next_wp_id";
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
                                if (columnNo == 10 || columnNo == 17)
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
            dateEdit2.Text = dateEdit1.Text;
        }

        private void dateEdit3_Leave(object sender, EventArgs e)
        {
            dateEdit4.Text = dateEdit3.Text;
        }

     
    }
}
