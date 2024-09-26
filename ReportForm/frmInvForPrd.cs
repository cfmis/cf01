using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmInvForPrd : Form
    {
      
        public frmInvForPrd()
        {
            InitializeComponent();
        }

        private void frmInvForPrd_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("發票明細表");
            comboBox1.Items.Add("按產品編號分析");
            BindDataGridView("1");
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string _type = "";
            string dat1 = "", dat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("發票日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false)
                dat1 = this.dateEdit1.Text.ToString();// Convert.ToDateTime(this.dateEdit1.EditValue).ToString("yyyy/mm/dd");
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
                dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedItem.ToString() == "")
                _type = "1";
            else
                _type = (comboBox1.SelectedIndex + 1).ToString();
            clsCommonUse c = new clsCommonUse();
            DataTable dt1 = c.getDataProcedure("z_load_g_inv01",
                new object[] { _type,textBox1.Text, textBox2.Text, dat1, dat2, textBox3.Text,
                textBox4.Text,textBox11.Text,textBox12.Text,textBox13.Text,textBox14.Text,textBox15.Text,textBox16.Text,textBox5.Text,textBox6.Text});
            BindDataGridView(_type);
            dgvDetails.DataSource = dt1;
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            ExpToExcel expxls = new ExpToExcel();
            expxls.DvExportToExcel(dgvDetails);
        }

        private void BindDataGridView(string dgvType)
        {
            dgvDetails.Columns.Clear();
            if (dgvType == "1")
            {
                dgvDetails.Columns.Add("ivm1inv", "發票編號");
                dgvDetails.Columns["ivm1inv"].DataPropertyName = "ivm1inv";
                dgvDetails.Columns.Add("ivm1dat", "發票日期");
                dgvDetails.Columns["ivm1dat"].DataPropertyName = "ivm1dat";
                dgvDetails.Columns.Add("ivm2seq", "序號");
                dgvDetails.Columns["ivm2seq"].DataPropertyName = "ivm2seq";
                dgvDetails.Columns.Add("ivm2item", "產品編號");
                dgvDetails.Columns["ivm2item"].DataPropertyName = "ivm2item";
                dgvDetails.Columns.Add("inm1cdesc", "產品描述");
                dgvDetails.Columns["inm1cdesc"].DataPropertyName = "inm1cdesc";
                dgvDetails.Columns.Add("ivm2mo", "制單編號");
                dgvDetails.Columns["ivm2mo"].DataPropertyName = "ivm2mo";
                dgvDetails.Columns.Add("ivm2qty", "發票數量");
                dgvDetails.Columns["ivm2qty"].DataPropertyName = "ivm2qty";
                dgvDetails.Columns.Add("ivm2unit1", "數量單位");
                dgvDetails.Columns["ivm2unit1"].DataPropertyName = "ivm2unit1";
                dgvDetails.Columns.Add("ivm2uprc", "單價");
                dgvDetails.Columns["ivm2uprc"].DataPropertyName = "ivm2uprc";
                dgvDetails.Columns.Add("ivm2unit", "單價單位");
                dgvDetails.Columns["ivm2unit"].DataPropertyName = "ivm2unit";
                dgvDetails.Columns.Add("ivm1curr", "貨幣單位");
                dgvDetails.Columns["ivm1curr"].DataPropertyName = "ivm1curr";
                dgvDetails.Columns.Add("ivm2rate", "數量(PCS)");
                dgvDetails.Columns["ivm2rate"].DataPropertyName = "ivm2rate";
                dgvDetails.Columns.Add("ivm2amt", "折扣前金額(HKD)");
                dgvDetails.Columns["ivm2amt"].DataPropertyName = "ivm2amt";
                dgvDetails.Columns.Add("ivm2dis", "折扣");
                dgvDetails.Columns["ivm2dis"].DataPropertyName = "ivm2dis";
                dgvDetails.Columns.Add("ivm2amt_dis", "折扣後金額(HKD)");
                dgvDetails.Columns["ivm2amt_dis"].DataPropertyName = "ivm2amt_dis";
                dgvDetails.Columns.Add("ivm1cust", "客戶編號");
                dgvDetails.Columns["ivm1cust"].DataPropertyName = "ivm1cust";
                dgvDetails.Columns.Add("custcname", "客戶描述");
                dgvDetails.Columns["custcname"].DataPropertyName = "custcname";
                dgvDetails.Columns.Add("mom1ord", "客戶PO");
                dgvDetails.Columns["mom1ord"].DataPropertyName = "mom1ord";
                dgvDetails.Columns.Add("mom1sec", "營業員");
                dgvDetails.Columns["mom1sec"].DataPropertyName = "mom1sec";
                dgvDetails.Columns.Add("mom1sec1", "營業描述");
                dgvDetails.Columns["mom1sec1"].DataPropertyName = "mom1sec";
                dgvDetails.Columns.Add("mom1brand", "牌子編號");
                dgvDetails.Columns["mom1brand"].DataPropertyName = "mom1brand";
                dgvDetails.Columns.Add("mom1own", "洋行代號");
                dgvDetails.Columns["mom1own"].DataPropertyName = "mom1own";
                dgvDetails.Columns.Add("ivm1rst", "發票類型");
                dgvDetails.Columns["ivm1rst"].DataPropertyName = "ivm1rst";
            }
            else
            {
                if (dgvType == "2")
                {
                    dgvDetails.Columns.Add("ivm2item", "產品編號");
                    dgvDetails.Columns["ivm2item"].DataPropertyName = "ivm2item";
                    dgvDetails.Columns.Add("inm1cdesc", "產品描述");
                    dgvDetails.Columns["inm1cdesc"].DataPropertyName = "inm1cdesc";
                    dgvDetails.Columns.Add("ivm2uprc", "單價");
                    dgvDetails.Columns["ivm2uprc"].DataPropertyName = "ivm2uprc";
                    dgvDetails.Columns.Add("ivm2unit", "單價單位");
                    dgvDetails.Columns["ivm2unit"].DataPropertyName = "ivm2unit";
                    dgvDetails.Columns.Add("ivm1curr", "貨幣代號");
                    dgvDetails.Columns["ivm1curr"].DataPropertyName = "ivm1curr";
                    dgvDetails.Columns.Add("ivm2mo", "制單張數");
                    dgvDetails.Columns["ivm2mo"].DataPropertyName = "ivm2mo";
                    dgvDetails.Columns.Add("ivm2qty", "數量(PCS)");
                    dgvDetails.Columns["ivm2qty"].DataPropertyName = "ivm2qty";
                    dgvDetails.Columns.Add("ivm2amt", "金額(HKD)");
                    dgvDetails.Columns["ivm2amt"].DataPropertyName = "ivm2amt";
                }
            }
            }

        private void dateEdit1_Leave(object sender, EventArgs e)
        {
            dateEdit2.Text = dateEdit1.Text;
        }

       
    }
}
