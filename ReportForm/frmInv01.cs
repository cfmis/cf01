using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RKLib.ExportData;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmInv01 : Form
    {
        private DataTable dt = new DataTable();

        public frmInv01()
        {
            InitializeComponent();
        }

        private void frmInv01_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("發票細表");
            comboBox1.Items.Add("按客戶匯總表");
            comboBox1.Items.Add("按洋行匯總表");
            comboBox1.Items.Add("按營業員匯總表");
            comboBox1.Items.Add("按牌子匯總表");
            comboBox1.Items.Add("按跟單匯總表");

            BindDataGridView("1");
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string _type = "";
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedItem.ToString() == "")
                _type = "1";
            else
                _type = (comboBox1.SelectedIndex + 1).ToString();
            clsCommonUse c = new clsCommonUse();
            DataTable dt1 = c.getDataProcedure("z_load_inv01",
                new object[] { _type, textBox1.Text, textBox2.Text, dateTimeBox1.Text.ToString(), dateTimeBox2.Text.ToString(), textBox3.Text,
                textBox4.Text,textBox11.Text,textBox12.Text,textBox13.Text,textBox14.Text,textBox15.Text,textBox16.Text,textBox5.Text,textBox6.Text});
            BindDataGridView(_type);
            dgvDetails.DataSource = dt1;
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            DvExportToExcel();
        }

        private void BTNPREVIEW_Click(object sender, EventArgs e)
        {
            Reports.crtInv01 r = new Reports.crtInv01();
            r.SetDataSource(dt);
            frmPrint p = new frmPrint();
            p.crystalReportViewer1.ReportSource = r;
            p.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            // Export all the details
            try
            {
                // Get the datatable to export			
                //DataTable dtEmployee = dsEmployee.Tables["Employee"].Copy();

                // Export all the details to Excel
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dt, Export.ExportFormat.Excel, "C:\\3\\EmployeesInfo.xls");
                lblMessage.Text = "Successfully exported to C:\\EmployeesInfo.xls";
            }
            catch (Exception Ex)
            {
                lblMessage.Text = Ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindDataGridView("1");
        }

        private void BindDataGridView(string dgvType)
        {
            dgvDetails.Columns.Clear();
            if (dgvType == "1")
            {
                dgvDetails.Columns.Add("id", "發票編號");
                dgvDetails.Columns["id"].DataPropertyName = "id";
                dgvDetails.Columns.Add("oi_date", "發票日期");
                dgvDetails.Columns["oi_date"].DataPropertyName = "oi_date";
                dgvDetails.Columns.Add("sequence_id", "序號");
                dgvDetails.Columns["sequence_id"].DataPropertyName = "sequence_id";
                dgvDetails.Columns.Add("mo_id", "制單編號");
                dgvDetails.Columns["mo_id"].DataPropertyName = "mo_id";
                dgvDetails.Columns.Add("goods_id", "產品編號");
                dgvDetails.Columns["goods_id"].DataPropertyName = "goods_id";
                dgvDetails.Columns.Add("goods_name", "產品描述");
                dgvDetails.Columns["goods_name"].DataPropertyName = "goods_name";
                dgvDetails.Columns.Add("u_invoice_qty", "發票數量");
                dgvDetails.Columns["u_invoice_qty"].DataPropertyName = "u_invoice_qty";
                dgvDetails.Columns.Add("goods_unit", "數量單位");
                dgvDetails.Columns["goods_unit"].DataPropertyName = "goods_unit";
                dgvDetails.Columns.Add("sec_qty", "發票重量");
                dgvDetails.Columns["sec_qty"].DataPropertyName = "sec_qty";
                dgvDetails.Columns.Add("invoice_price", "發票單價");
                dgvDetails.Columns["invoice_price"].DataPropertyName = "invoice_price";
                dgvDetails.Columns.Add("p_unit", "單價單位");
                dgvDetails.Columns["p_unit"].DataPropertyName = "p_unit";
                dgvDetails.Columns.Add("total_sum", "金額");
                dgvDetails.Columns["total_sum"].DataPropertyName = "total_sum";
                dgvDetails.Columns.Add("m_id", "貨幣代號");
                dgvDetails.Columns["m_id"].DataPropertyName = "m_id";
                dgvDetails.Columns.Add("i_qty_pcs", "數量(PCS)");
                dgvDetails.Columns["i_qty_pcs"].DataPropertyName = "i_qty_pcs";
                dgvDetails.Columns.Add("i_amt_hkd", "金額(HKD)");
                dgvDetails.Columns["i_amt_hkd"].DataPropertyName = "i_amt_hkd";
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
                dgvDetails.Columns.Add("contract_cid", "客戶PO");
                dgvDetails.Columns["contract_cid"].DataPropertyName = "contract_cid";
                dgvDetails.Columns.Add("order_id", "OC編號");
                dgvDetails.Columns["order_id"].DataPropertyName = "order_id";
                dgvDetails.Columns.Add("seller_id1", "跟單員");
                dgvDetails.Columns["seller_id1"].DataPropertyName = "seller_id1";
            }
            else
            {
                string f1_text = "";
                string f2_text = "";
                if (dgvType == "2")
                {
                    f1_text = "客戶編號";
                    f2_text = "客戶描述";
                }
                else
                    if (dgvType == "3")
                    {
                        f1_text = "洋行代號";
                        f2_text = "洋行描述";
                    }
                    else
                        if (dgvType == "4")
                        {
                            f1_text = "營業員代號";
                            f2_text = "營業員描述";
                        }
                        else
                            if (dgvType == "5")
                            {
                                f1_text = "牌子編號";
                                f2_text = "牌子描述";
                            }
                            else
                                if (dgvType == "6")
                                {
                                    f1_text = "跟單員";
                                    f2_text = "跟單員描述";
                                }
                dgvDetails.Columns.Add("f_type", f1_text);
                dgvDetails.Columns["f_type"].DataPropertyName = "f_type";
                dgvDetails.Columns.Add("f_name", f2_text);
                dgvDetails.Columns["f_name"].DataPropertyName = "f_name";
                dgvDetails.Columns.Add("i_qty_pcs", "數量(PCS)");
                dgvDetails.Columns["i_qty_pcs"].DataPropertyName = "i_qty_pcs";
                dgvDetails.Columns.Add("i_amt_hkd", "金額(HKD)");
                dgvDetails.Columns["i_amt_hkd"].DataPropertyName = "i_amt_hkd";
                dgvDetails.Columns.Add("sec_qty", "發票重量(KGS)");
                dgvDetails.Columns["sec_qty"].DataPropertyName = "sec_qty";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            string filePath = "f1.xls";
            System.Web.UI.WebControls.DataGrid excel = new System.Web.UI.WebControls.DataGrid();
            System.Web.UI.WebControls.TableItemStyle AlternatingStyle = new TableItemStyle();
            System.Web.UI.WebControls.TableItemStyle headerStyle = new TableItemStyle();
            System.Web.UI.WebControls.TableItemStyle itemStyle = new TableItemStyle();
            AlternatingStyle.BackColor = System.Drawing.Color.LightGray;
            headerStyle.BackColor = System.Drawing.Color.LightGray;
            headerStyle.Font.Bold = true;
            headerStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            itemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center; ;

            excel.AlternatingItemStyle.MergeWith(AlternatingStyle);
            excel.HeaderStyle.MergeWith(headerStyle);
            excel.ItemStyle.MergeWith(itemStyle);
            excel.GridLines = GridLines.Both;
            excel.HeaderStyle.Font.Bold = true;
            excel.DataSource = dt.DefaultView;//输出DataTable的内容 
            excel.DataBind();
            excel.RenderControl(htmlWriter);

            string filestr = "c:\\3\\" + filePath;  //filePath是文件的路径 
            int pos = filestr.LastIndexOf("\\");
            string file = filestr.Substring(0, pos);
            if (!Directory.Exists(file))
            {
                Directory.CreateDirectory(file);
            }
            System.IO.StreamWriter sw = new StreamWriter(filestr);
            sw.Write(stringWriter.ToString());
            sw.Close();

        }

        public void DvExportToExcel()
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
                                if (columnNo == 18 || columnNo == 24)//營業員
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

        private void button4_Click(object sender, EventArgs e)
        {
            string _connString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString1"];
            string _type = "";
            SqlConnection con = new SqlConnection(_connString);
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "z_load_inv01"; //指定存储过程名称
            SqlCmd.Connection = con;  //指定sql命令的连接属性
            SqlCmd.CommandTimeout = 1800;//連接30分鐘
            //指定存储过程的参数并赋值
            SqlCmd.Parameters.Add("@_id1", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_id1"].Value = textBox1.Text;
            SqlCmd.Parameters.Add("@_id2", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_id2"].Value = textBox2.Text;
            SqlCmd.Parameters.Add("@_date1", SqlDbType.Text, 20);
            SqlCmd.Parameters["@_date1"].Value = dateTimeBox1.Text.ToString();
            SqlCmd.Parameters.Add("@_date2", SqlDbType.Text, 20);
            SqlCmd.Parameters["@_date2"].Value = dateTimeBox2.Text.ToString();
            SqlCmd.Parameters.Add("@_sec1", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_sec1"].Value = textBox3.Text;
            SqlCmd.Parameters.Add("@_sec2", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_sec2"].Value = textBox4.Text;
            SqlCmd.Parameters.Add("@_mo1", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_mo1"].Value = textBox11.Text;
            SqlCmd.Parameters.Add("@_mo2", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_mo2"].Value = textBox12.Text;
            SqlCmd.Parameters.Add("@_item1", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_item1"].Value = textBox13.Text;
            SqlCmd.Parameters.Add("@_item2", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_item2"].Value = textBox14.Text;
            SqlCmd.Parameters.Add("@_citem1", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_citem1"].Value = textBox15.Text;
            SqlCmd.Parameters.Add("@_citem2", SqlDbType.Text, 10);
            SqlCmd.Parameters["@_citem2"].Value = textBox16.Text;
            SqlCmd.Parameters.Add("@_cust1", SqlDbType.Text, 8);
            SqlCmd.Parameters["@_cust1"].Value = textBox5.Text;
            SqlCmd.Parameters.Add("@_cust2", SqlDbType.Text, 8);
            SqlCmd.Parameters["@_cust2"].Value = textBox6.Text;

            SqlCmd.Parameters.Add("@_type", SqlDbType.Text, 1);
            SqlCmd.Parameters["@_type"].Value = _type;
            //SqlDataAdapter da = new SqlDataAdapter(strSql, con);

            DataSet ds = new DataSet();
            con.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                da.Fill(ds, "ivm01");
                dt = ds.Tables["ivm01"];
                BindDataGridView("1");
                dgvDetails.DataSource = ds.Tables["ivm01"];
                if (ds.Tables["ivm01"].Rows.Count == 0)//(dgvDetails.Rows.Count == 0)
                    MessageBox.Show("沒有找到符合條件的記錄!", "系統信息", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message, "系統信息", MessageBoxButtons.OK);
            }

            con.Close();
            //DataView dView = new DataView(ds.Tables["ivm01"]);
            //dView.Sort = "id";

        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString1"];
            SqlConnection con = new SqlConnection(_connString);
            /*
            string strSql = "select a.id,a.oi_date,b.sequence_id,b.mo_id,b.goods_id,c.name AS goods_name,convert(decimal(15,0),b.u_invoice_qty) As u_invoice_qty,b.goods_unit,convert(decimal(10,2),b.sec_qty) As sec_qty,a.it_customer,d.name As cust_name" +
                ",convert(decimal(10,2),b.invoice_price) as invoice_price,b.p_unit,convert(decimal(15,2),b.total_sum) as total_sum" +
                ",convert(decimal(20,0),(b.u_invoice_qty*e.rate)) As i_qty_pcs,convert(decimal(20,2),(b.u_invoice_qty*e.rate)*(b.invoice_price/f.rate)) As i_amt_hkd,a.m_id,a.seller_id " +
                " From so_invoice_mostly a " +
                " Inner Join so_invoice_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver " +
                " Inner Join (Select Max(within_code) as within_code,id,Max(ver) as ver From so_invoice_mostly where id>='' ";
            if (textBox1.Text.ToString() != "")
            {
                strSql = strSql + " and id >= " + "'" + textBox1.Text.ToString() + "'";
            }
            if (textBox2.Text.ToString() != "")
            {
                strSql = strSql + " and id <= " + "'" + textBox2.Text.ToString() + "'";
            }
            if (dateTimeBox1.Text != null||dateTimeBox2.Text != null)
            {
                strSql = strSql + " and oi_date between " + "'"+dateTimeBox1.Text +"'"+ " AND "+"'"+dateTimeBox2.Text+"'";
            }
            strSql = strSql + " Group by id ) t2  ON a.within_code=t2.within_code AND a.id=t2.id AND a.ver=t2.ver";
            strSql = strSql + " Left Outer Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id " +
                " Left Outer Join it_customer d On a.it_customer=d.id" +
                " Left Outer Join it_coding e On b.within_code=e.within_code And b.goods_unit=e.unit_code " +
                " Left Outer Join it_coding f On b.within_code=f.within_code And b.goods_unit=f.unit_code ";
            strSql=strSql + " where e.id='*' And f.id='*' ";
            */
            string strSql = "select a.id,a.oi_date,b.sequence_id,b.mo_id,b.goods_id,c.name AS goods_name,convert(decimal(15,0),b.u_invoice_qty) As u_invoice_qty,b.goods_unit,convert(decimal(10,2),b.sec_qty) As sec_qty,a.it_customer,d.name As cust_name" +
                ",convert(decimal(10,2),b.invoice_price) as invoice_price,b.p_unit,convert(decimal(15,2),b.total_sum) as total_sum" +
                ",convert(decimal(20,0),(b.u_invoice_qty*e.rate)) As i_qty_pcs,convert(decimal(20,2),(b.u_invoice_qty*e.rate)*(b.invoice_price/f.rate)) As i_amt_hkd,a.m_id,a.seller_id " +
                " From so_invoice_mostly a " +
                " Inner Join so_invoice_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver " +
                " Left Outer Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id " +
                " Left Outer Join it_customer d On a.it_customer=d.id" +
                " Left Outer Join it_coding e On b.within_code=e.within_code And b.goods_unit=e.unit_code " +
                " Left Outer Join it_coding f On b.within_code=f.within_code And b.goods_unit=f.unit_code ";
            strSql = strSql + " Where a.state <> 'V' AND e.id='*' And f.id='*' ";
            if (textBox1.Text.ToString() != "")
            {
                strSql = strSql + " and a.id >= " + "'" + textBox1.Text.ToString() + "'";
            }
            if (textBox2.Text.ToString() != "")
            {
                strSql = strSql + " and a.id <= " + "'" + textBox2.Text.ToString() + "'";
            }
            if (dateTimeBox1.Text != null || dateTimeBox2.Text != null)
            {
                strSql = strSql + " and a.oi_date between " + "'" + dateTimeBox1.Text + "'" + " AND " + "'" + dateTimeBox2.Text + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "ivm01");
            con.Close();
            //DataView dView = new DataView(ds.Tables["ivm01"]);
            //dView.Sort = "id";
            BindDataGridView("1");
            dgvDetails.DataSource = ds.Tables["ivm01"];
            //dt = ds.Tables["ivm01"].Copy();
            if (dgvDetails.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄", "系統信息", MessageBoxButtons.OK);
            //textBox4.Text = Math.Round(Convert.ToDouble("12.6570"), 2, MidpointRounding.AwayFromZero).ToString();
            /*
            BusinessRuler.LoadCfData objUnit = new BusinessRuler.LoadCfData(this.dgvDetails);
            objUnit.UpdateDataGrid(strSql);
            
            */
        }


    }
}
