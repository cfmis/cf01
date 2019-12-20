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

namespace cf01.Forms
{
    public partial class frmQuotation_Copy : Form
    {        
        DataTable dtDetails = new DataTable();
        public DataRow[] dr_copy = null;
        public frmQuotation_Copy()
        {
            InitializeComponent();
        }

        private void frmQuotation_Copy_FormClosed(object sender, FormClosedEventArgs e)
        {            
            dtDetails.Dispose();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            dr_copy = null;
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dr_copy = null;
            StringBuilder sb = new StringBuilder(string.Format(
            @"SELECT A.id,A.quota_date,A.customer_id,ISNULL(C.name,'') AS name_customer,A.term_id,A.address_id,A.remark,A.remark_other,
            A.money_id,A.valid_date,A.contact as contact_h,A.tel,A.fax,A.email,A.isusd,A.ishkd,A.isrmb,
            B.seq_id,B.brand,B.division,B.contact,B.material,B.size,B.product_desc,B.cust_code,B.cf_code,B.cust_color,B.cf_color,B.price_usd,B.price_hkd,
            B.price_rmb,B.moq,B.price_unit,B.remark as remark_d,B.temp_code,B.ver,B.moq_unit,B.season,B.salesman,B.mwq,B.lead_time_min,B.lead_time_max,
            B.lead_time_unit,B.md_charge,B.md_charge_cny,B.moq_for_test,B.number_enter,B.hkd_ex_fty,B.sales_group,B.usd_dap,B.usd_lab_test_prx,B.ex_fty_hkd,B.ex_fty_usd,
            B.usd_ex_fty,B.discount,B.disc_price_usd,B.disc_price_hkd,B.disc_price_rmb,B.disc_hkd_ex_fty,B.actual_price,B.actual_price_type,B.die_mould_usd,B.die_mould_cny
            FROM dbo.quotation_mostly A with(nolock)
	            INNER JOIN dbo.quotation_details B with(nolock) ON A.id=B.id 
	            LEFT JOIN {0}it_customer C ON C.within_code='0000' and A.customer_id=C.id COLLATE Chinese_Taiwan_Stroke_CI_AS
            WHERE 1>0 ", DBUtility.remote_db));
            if (txtQuotation1.Text != "")
                sb.Append(string.Format(" AND A.id>='{0}'", txtQuotation1.Text));
            if (txtQuotation2.Text != "")
                sb.Append(string.Format(" AND A.id<='{0}'", txtQuotation2.Text));
            if (txtDat1.Text != "")
                sb.Append(string.Format(" AND A.quota_date>='{0}'", txtDat1.Text));
            if (txtDat2.Text != "")
                sb.Append(string.Format(" AND A.quota_date<='{0}'", txtDat2.Text));
            if (txtCust_id1.Text != "")
                sb.Append(string.Format(" AND A.customer_id>='{0}'", txtCust_id1.Text));
            if (txtCust_id2.Text != "")
                sb.Append(string.Format(" AND A.customer_id<='{0}'", txtCust_id2.Text));
            if (txtBrand_id1.Text != "")
                sb.Append(string.Format(" AND B.brand>='{0}'", txtBrand_id1.Text));
            if (txtBrand_id2.Text != "")
                sb.Append(string.Format(" AND B.brand<='{0}'", txtBrand_id2.Text));
            sb.Append(" ORDER BY A.id,B.seq_id");
           
            dtDetails = clsPublicOfCF01.GetDataTable(sb.ToString());
            dtDetails.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));    
            dgvDetails.DataSource = dtDetails;
            if (dtDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dtDetails.AcceptChanges();
            if (dgvDetails.RowCount > 0)
            {
                dr_copy = dtDetails.Select("flag_select=true");
                if (dr_copy.Length == 0)
                {
                    MessageBox.Show("請至少要選擇一條要翻單的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.Close();
            }
        }

        private void txtQuotation1_Leave(object sender, EventArgs e)
        {
            txtQuotation2.Text = txtQuotation1.Text;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void txtCust_id1_Leave(object sender, EventArgs e)
        {
            txtCust_id2.Text = txtCust_id1.Text;
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.Text = txtBrand_id1.Text;
        }     
    }
}
