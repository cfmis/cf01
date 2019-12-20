using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmQuotation_LabTest : Form
    {
        readonly string m_brand_id,m_prod_id;       
        DataTable dtLabTest=new DataTable();
        public frmQuotation_LabTest(string p_brand_id,string p_prod_id,string p_usd_ex_fty)
        {                    
            InitializeComponent();
            m_brand_id = p_brand_id;
            m_prod_id = p_prod_id;
            txtUsd_ex_fty.Text = p_usd_ex_fty;
            txtBrand_id.Text = p_brand_id;
           
        }

        private void frmQuotation_LabTest_Load(object sender, EventArgs e)
        {
            string ls_sql = string.Format(
                @"SELECT prod_id,brand_id,range_begin,range_end,cost_lab_test,price_add,unit_code,remark 
                FROM quotation_labtest_formula 
                WHERE prod_id='{0}' and brand_id ='{1}'
                ORDER BY prod_id,id", m_prod_id, m_brand_id);
            dtLabTest = clsPublicOfCF01.GetDataTable(ls_sql);
            dgvLabTest.DataSource = dtLabTest;
            if (dtLabTest.Rows[0]["unit_code"].ToString() == "GRS")
                txtUnit.Text = "GRS";
            else
                txtUnit.Text = "K";
            ls_sql = string.Format(@"SELECT Isnull(usd3,0.000) usd3 FROM quotation_formula WHERE brand_id='{0}'", m_brand_id);
            string ls_rate = clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql);
            if (ls_rate != "")
                txtRate.Text = ls_rate;
            else
                txtRate.Text = "0.000";
        }

        private void frmQuotation_LabTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtLabTest.Dispose();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Calculate_Price();
            }            
        }

        private void Calculate_Price()
        {
            if (dgvLabTest.RowCount > 0)
            {
                if (txtInput.Text != "" && txtUsd_ex_fty.Text != "")
                {
                    if (txtUnit.Text == "GRS")
                        txtQty_pcs.Text = (Int32.Parse(txtInput.Text) * 144).ToString(); //GRS
                    else
                        txtQty_pcs.Text = (Int32.Parse(txtInput.Text) * 1000).ToString();//K

                    float lf_rang_qty, lf_usd_ex_fty, lf_price_add = 0.00f, lf_price_finish = 0.00f, lf_cost_test = 0.0f, lf_range_begin = 0.0f, lf_range_end = 0.0f, lf_rate;
                    lf_rang_qty = float.Parse(txtInput.Text);
                    lf_usd_ex_fty = float.Parse(txtUsd_ex_fty.Text);

                    DataRow[] drs = dtLabTest.Select(string.Format("prod_id='{0}' and brand_id='{1}' and range_begin<={2} and range_end>={2}", m_prod_id, m_brand_id, lf_rang_qty));
                    if (drs.Length > 0)
                    {
                        foreach (DataRow dr in drs)
                        {                            
                            lf_range_begin = float.Parse(dr["range_begin"].ToString());
                            lf_range_end = float.Parse(dr["range_end"].ToString());
                            lf_cost_test = float.Parse(dr["cost_lab_test"].ToString());
                            lf_price_add = float.Parse(dr["price_add"].ToString());
                        }
                        
                        //公式
                        //最終單價USD
                        lf_price_finish = lf_usd_ex_fty + lf_cost_test / lf_range_begin + lf_price_add;
                        txtPriceFinish.Text = Math.Round(lf_price_finish, 2).ToString();                        
                        //最終單價HKD
                        if (txtRate.Text != "")
                            lf_rate = float.Parse(txtRate.Text);
                        else
                            lf_rate = 0.00f;
                        txtPriceFinish_hkd.Text = Math.Round(Math.Round(lf_price_finish, 2)*lf_rate,2).ToString();
                        //范圍
                        txtRange_begin.Text = lf_range_begin.ToString();
                        txtRange_end.Text = lf_range_end.ToString();
                    }
                }
            }
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            Calculate_Price();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
