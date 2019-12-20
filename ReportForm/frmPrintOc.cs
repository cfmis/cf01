using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using cf01.CLS;
using cf01.Forms;

namespace cf01.ReportForm
{
    public partial class frmPrintOc : Form
    {
        private DataTable dt = new DataTable();
        private string sql_select_type = "1";

        public frmPrintOc()
        {
            InitializeComponent();
        }

        private void frmPrintOc_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("訂單明細表");
            comboBox1.Items.Add("按客戶匯總表");
            comboBox1.Items.Add("按洋行匯總表");
            comboBox1.Items.Add("按營業員匯總表");
            comboBox1.Items.Add("按牌子匯總表");
            comboBox1.Items.Add("按跟單匯總表");
            comboBox1.Items.Add("按物料類型匯總表");

            BindDataGridView("1");
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            textBox1.Text = (comboBox1.SelectedIndex + 1).ToString();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void BindDataGridView(string dvgType)
        {
            dgvDetails.Columns.Clear();
            if (dvgType == "1")
            {
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
                dgvDetails.Columns.Add("oc_amt_hkd_aft_dis", "金額_HKD(折扣後)");
                dgvDetails.Columns["oc_amt_hkd_aft_dis"].DataPropertyName = "oc_amt_hkd_aft_dis";
                dgvDetails.Columns.Add("c_date", "建立日期");
                dgvDetails.Columns["c_date"].DataPropertyName = "c_date";
                dgvDetails.Columns.Add("m_state", "狀態");
                dgvDetails.Columns["m_state"].DataPropertyName = "m_state";
                dgvDetails.Columns.Add("big_class", "大類");
                dgvDetails.Columns["big_class"].DataPropertyName = "big_class";
                dgvDetails.Columns.Add("prd_type_desc1", "大類描述");
                dgvDetails.Columns["prd_type_desc1"].DataPropertyName = "prd_type_desc1";
                dgvDetails.Columns.Add("base_class", "小類");
                dgvDetails.Columns["base_class"].DataPropertyName = "base_class";
                dgvDetails.Columns.Add("prd_type_desc2", "小類描述");
                dgvDetails.Columns["prd_type_desc2"].DataPropertyName = "prd_type_desc2";
                dgvDetails.Columns.Add("mat_code", "物料種類");
                dgvDetails.Columns["mat_code"].DataPropertyName = "mat_code";
                dgvDetails.Columns.Add("mat_desc", "物料種類描述");
                dgvDetails.Columns["mat_desc"].DataPropertyName = "mat_desc";
                dgvDetails.Columns.Add("customer_color_id", "客戶產品顏色");
                dgvDetails.Columns["customer_color_id"].DataPropertyName = "customer_color_id";
                dgvDetails.Columns.Add("season", "季度");
                dgvDetails.Columns["season"].DataPropertyName = "season";
            }
            else
            {
                string f1_text = "";
                string f2_text = "";
                if (dvgType == "2")
                {
                    f1_text = "客戶編號";
                    f2_text = "客戶描述";
                }
                else
                {
                    if (dvgType == "3")
                    {
                        f1_text = "洋行代號";
                        f2_text = "洋行描述";
                    }
                    else
                    {
                        if (dvgType == "4")
                        {
                            f1_text = "營業員代號";
                            f2_text = "營業員描述";
                        }
                        else
                        {
                            if (dvgType == "5")
                            {
                                f1_text = "牌子編號";
                                f2_text = "牌子描述";
                            }
                            else
                            {
                                if (dvgType == "6")
                                {
                                    f1_text = "跟單員編號";
                                    f2_text = "跟單員描述";
                                }
                                else
                                {
                                    if (dvgType == "7")
                                    {
                                        f1_text = "物料種類";
                                        f2_text = "物料種類描述";
                                        dgvDetails.Columns.Add("brand_id", "牌子編號");
                                        dgvDetails.Columns["brand_id"].DataPropertyName = "brand_id";
                                        dgvDetails.Columns.Add("brand_name", "牌子描述");
                                        dgvDetails.Columns["brand_name"].DataPropertyName = "brand_name";
                                    }
                                }
                            }
                        }
                    }
                }
                dgvDetails.Columns.Add("f_type", f1_text);
                dgvDetails.Columns["f_type"].DataPropertyName = "f_type";
                dgvDetails.Columns.Add("f_name", f2_text);
                dgvDetails.Columns["f_name"].DataPropertyName = "f_name";
                if (dvgType == "7")
                {
                    dgvDetails.Columns.Add("prd_type1", "產品種類大類");
                    dgvDetails.Columns["prd_type1"].DataPropertyName = "prd_type1";
                    dgvDetails.Columns.Add("prd_type_desc1", "產品種類大類_描述");
                    dgvDetails.Columns["prd_type_desc1"].DataPropertyName = "prd_type_desc1";
                    dgvDetails.Columns.Add("prd_type2", "產品種類細類");
                    dgvDetails.Columns["prd_type2"].DataPropertyName = "prd_type2";
                    dgvDetails.Columns.Add("prd_type_desc2", "產品種類細類_描述");
                    dgvDetails.Columns["prd_type_desc2"].DataPropertyName = "prd_type_desc2";
                }
                dgvDetails.Columns.Add("count_mo_num", "制單個數");
                dgvDetails.Columns["count_mo_num"].DataPropertyName = "count_mo_num";
                dgvDetails.Columns.Add("oc_qty_pcs", "數量(PCS)");
                dgvDetails.Columns["oc_qty_pcs"].DataPropertyName = "oc_qty_pcs";
                dgvDetails.Columns.Add("oc_amt_hkd_aft_dis", "金額(HKD)折扣後");
                dgvDetails.Columns["oc_amt_hkd_aft_dis"].DataPropertyName = "oc_amt_hkd_aft_dis";
            }
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
                                if (columnNo == 18)
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

        private void Find()
        {
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
                    MessageBox.Show("訂單建立不正確!");
                    this.dateEdit3.Focus();
                    return;
                }
                else
                {
                    crdat1 = this.dateEdit3.Text.ToString();
                    crdat2 = Convert.ToDateTime(this.dateEdit4.Text).AddDays(1).ToString("yyyy/MM/dd");
                }
            }

            //顯示查詢進度圖片
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            clsCommonUse c = new clsCommonUse();
            DataTable dt = c.getDataProcedure("z_load_oc01",
                new object[] { sql_select_type, textBox1.Text, textBox2.Text, dat1, dat2,crdat1
                ,crdat2, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text
                , textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text
                ,textBox13.Text,textBox14.Text,textBox15.Text,textBox16.Text,textBox17.Text,textBox18.Text
                ,txtSeason1.Text,txtSeason2.Text});
            BindDataGridView(sql_select_type);
            dgvDetails.DataSource = dt;

            //結束查詢進度圖片
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox4.Text = textBox3.Text;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox8.Text = textBox7.Text;
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox10.Text = textBox9.Text;
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            textBox12.Text = textBox11.Text;
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            textBox14.Text = textBox13.Text;
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            textBox16.Text = textBox15.Text;
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            textBox18.Text = textBox17.Text;
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1 || this.comboBox1.SelectedItem.ToString() == "")
                sql_select_type = "1";
            else
                sql_select_type = (this.comboBox1.SelectedIndex + 1).ToString();
        }

        private void dateEdit1_Leave(object sender, EventArgs e)
        {
            dateEdit2.Text = dateEdit1.Text;
        }

        private void dateEdit3_Leave(object sender, EventArgs e)
        {
            dateEdit4.Text = dateEdit3.Text;
        }

        private void txtSeason1_TextChanged(object sender, EventArgs e)
        {
            txtSeason2.Text = txtSeason1.Text;
        }



    }
}
