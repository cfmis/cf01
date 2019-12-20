using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;


namespace cf01.ReportForm
{
    public partial class frmInvoiceCommision : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtReport = new DataTable();
  
        public frmInvoiceCommision()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmInvoiceCommision_Load(object sender, EventArgs e)
        {
            //客戶資料           
            string strSql = string.Format(
            @"SELECT '' AS id,'' AS cdesc UNION SELECT A.id,A.name as cdesc 
            FROM {0}it_customer A with(nolock)
            WHERE A.within_code='0000' AND A.state<>'2'
            ORDER BY A.id", DBUtility.remote_db);
            DataTable dtCust = new DataTable();
            dtCust = clsPublicOfCF01.GetDataTable(strSql);
            txtCustomer_id1.Properties.DataSource = dtCust;
            txtCustomer_id1.Properties.ValueMember = "id";
            txtCustomer_id1.Properties.DisplayMember = "id";

            txtCustomer_id2.Properties.DataSource = dtCust;
            txtCustomer_id2.Properties.ValueMember = "id";
            txtCustomer_id2.Properties.DisplayMember = "id";

            if (txtSalesGroup.Text == "")
            {
                txtSalesGroup.Text = "K";
            }
           
        }

        private void frmInvoiceCommision_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo1.Text == "" && txtInvoiceNo2.Text == "" && txtDat1.Text == "" && txtDat2.Text == "" && txtCustomer_id1.Text == "" && txtCustomer_id2.Text == "")
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInvoiceNo1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@invoice_s",txtInvoiceNo1.Text),
                new SqlParameter("@invoice_e",txtInvoiceNo2.Text),
                new SqlParameter("@customer_id_s",txtCustomer_id1.EditValue),
                new SqlParameter("@customer_id_e",txtCustomer_id2.EditValue),
                new SqlParameter("@inv_date_s",txtDat1.Text),
                new SqlParameter("@inv_date_e",txtDat2.Text),
                new SqlParameter("@sales_group",txtSalesGroup.Text)  
            };
            dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_invoice_comission",paras);
            dgvDetails.DataSource = dtReport; 
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
           
            if (dtReport.Rows.Count == 0)
            {                
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            
        }      

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }    

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDat2.EditValue = txtDat1.EditValue;
        }  

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel xls = new ExpToExcel();
            xls.ExportExcel(dgvDetails);
        }

     
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }  

        private void txtCustomer_id1_Leave(object sender, EventArgs e)
        {
            txtCustomer_id2.EditValue = txtCustomer_id1.EditValue;
        }

    }
}
