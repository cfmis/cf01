using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;

namespace cf01.ReportForm
{
    public partial class frmInvoiceTotalAmount : Form
    {
        DataSet dts;
        clsPublicOfGEO clsERP = new clsPublicOfGEO();
        DataTable dtCust = new DataTable();
        public frmInvoiceTotalAmount()
        {
            InitializeComponent();
        }

        private void frmInvoiceTotalAmount_Load(object sender, EventArgs e)
        {
            string strsql = @"SELECT '' AS id,'' as cdesc UNION SELECT id,name AS cdesc FROM it_customer with(nolock) WHERE customer_group<>'2' and state='1' ORDER BY id";
            dtCust = clsERP.GetDataTable(strsql);
            txtCust1.Properties.DataSource = dtCust;
            txtCust1.Properties.ValueMember = "id";
            txtCust1.Properties.DisplayMember = "id";

            txtCust2.Properties.DataSource = dtCust;
            txtCust2.Properties.ValueMember = "id";
            txtCust2.Properties.DisplayMember = "id";
            dgvDetails2.Location =new System.Drawing.Point(1, 103);

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtCust1.EditValue.ToString() == "" && txtCust2.EditValue.ToString() == "" && txtDat1.Text == "" && txtDat2.Text == "")
            {
                MessageBox.Show("查詢條件不可為空!", "提示信息");
                return;
            }
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@it_customer1",txtCust1.EditValue),
                new SqlParameter("@it_customer2",txtCust2.EditValue),
                new SqlParameter("@date_invoice1",txtDat1.Text),
                new SqlParameter("@date_invoice2",txtDat2.Text)
            };

            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //
            dts = clsERP.ExecuteProcedureReturnDataSet("z_total_customer_amount", paras, null);
            //
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            Set_dgvdetails();            
            dgvDetails1.DataSource = dts.Tables[0];
            dgvDetails2.DataSource = dts.Tables[1];

            if (dts.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查詢條件的數據!", "提示信息");               
            }
        }

        private void Set_dgvdetails()
        {
            if (radGrp1.SelectedIndex == 0)
            {
                dgvDetails1.Visible = true;
                dgvDetails2.Visible = false;
            }
            else
            {
                dgvDetails2.Visible = true;
                dgvDetails1.Visible = false;
            }
        }

        private void radGrp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_dgvdetails();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvDetails1.Rows.Count == 0)
            {
                MessageBox.Show("沒有要匯出的數據!", "提示信息");
                return;
            }
            ExpToExcel objXls = new ExpToExcel();
            if(radGrp1.SelectedIndex == 0)
                objXls.ExportExcel(dgvDetails1);
            else
                objXls.ExportExcel(dgvDetails2);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoiceTotalAmount_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtCust = null;
            dts = null;
            clsERP = null;
        }

        private void txtCust1_Leave(object sender, EventArgs e)
        {
            txtCust2.EditValue = txtCust1.EditValue;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.Text = txtDat1.Text;
        }
    }
}
