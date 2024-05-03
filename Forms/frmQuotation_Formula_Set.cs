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
    public partial class frmQuotation_Formula_Set : Form
    {
        DataTable dtDetail = new DataTable();         
        public string brand_Selected = "";
        private string strFormula = "";
        public frmQuotation_Formula_Set(string formula)
        {
            InitializeComponent();
            strFormula = formula;
        }

        private void frmQuotation_Formula_Set_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtDetail.Dispose();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quotation_Formula_Set_Load(object sender, EventArgs e)
        {
            clsQuotation.Set_Brand_id2(txtBrand_id);
            clsQuotation.Set_Brand_id2(txtBrand_id1);
            clsQuotation.Set_Brand_id2(txtBrand_id2);
            if (!string.IsNullOrEmpty(strFormula))
            {
                txtBrand_id1.EditValue = strFormula;
                txtBrand_id2.EditValue = strFormula;
                Find_Data();
            }            
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find_Data();
        }

        private void Find_Data()
        { 
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@brand_id1",txtBrand_id1.EditValue),
                new SqlParameter("@brand_id2",txtBrand_id2.EditValue)
            };
            dtDetail = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_formula_find", paras);
            dtDetail.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));
            dgvDetails.DataSource = dtDetail;            
            if (dtDetail.Rows.Count == 0)
            {
                MessageBox.Show(string.Format("沒有滿足查詢條件的數據!", txtUsd1.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                DataGridViewRow dgvrow = new DataGridViewRow();
                dgvrow = dgvDetails.CurrentRow;
                Set_head(dgvrow);
            }
        }

        private void Set_head(DataGridViewRow pdr)
        {           
            txtBrand_id.EditValue = pdr.Cells["brand_id"].Value.ToString();
            txtUsd1.Text = pdr.Cells["usd1"].Value.ToString();
            txtUsd2.Text = pdr.Cells["usd2"].Value.ToString();
            txtRmb1.Text = pdr.Cells["rmb1"].Value.ToString();
            txtRmb2.Text = pdr.Cells["rmb2"].Value.ToString();
            txtHkd1.Text = pdr.Cells["hkd1"].Value.ToString();
            txtHkd2.Text = pdr.Cells["hkd2"].Value.ToString();
            txtUsd3.Text = pdr.Cells["usd3"].Value.ToString();
            txtDiscount.Text = pdr.Cells["discount"].Value.ToString();
            txtRemark.Text = pdr.Cells["remark"].Value.ToString();
            txtvndbp1.Text = pdr.Cells["vndbp1"].Value.ToString();
            txtvndusd1.Text = pdr.Cells["vndusd1"].Value.ToString();
            txtvnd1.Text = pdr.Cells["vnd1"].Value.ToString();

            lblVndusd1.Text = pdr.Cells["usd2"].Value.ToString();

            string strCheck = pdr.Cells["bp_hkd_ex"].Value.ToString();
            if (string.IsNullOrEmpty(strCheck) || strCheck == "False")
            {
                chkBp_hkd_ex.Checked = false;
            }
            else
            {
                chkBp_hkd_ex.Checked = true;
            }
        }

        private void BTNOK_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                DataRow[] dr = dtDetail.Select("flag_select=true");
                if (dr.Length == 0)
                {
                    MessageBox.Show("請首選擇要一條要翻單的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dr.Length > 1)
                {
                    MessageBox.Show("注意：一次只可以選其中的一張報價單來翻單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                brand_Selected = dr[0]["brand_id"].ToString();
                this.Close();
            }
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.EditValue = txtBrand_id1.EditValue;
        }

     

        
    }
}
