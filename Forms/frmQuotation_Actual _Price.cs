using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmQuotation_Actual_Price : Form
    {
        private string current_cny;
        public string selected_price;
        public frmQuotation_Actual_Price(string strPrice)
        {
            InitializeComponent();
            current_cny = strPrice;
            selected_price = "";
        }

        private void frmQuotation_Actual_Price_Load(object sender, EventArgs e)
        {
            cmbPrice.Items.Clear();
            switch (current_cny)
            {                
                case "HKD":                   
                    cmbPrice.Items.Add("HKD");
                    cmbPrice.Items.Add("HKD EX-FTY");
                    break;
                case "USD":                  
                    cmbPrice.Items.Add("USD");
                    cmbPrice.Items.Add("USD EX-FTY");
                    break;
                case "RMB":
                    cmbPrice.Items.Add("RMB");
                    break;
                default :
                    cmbPrice.Items.Add("");
                    break;
            }
            cmbPrice.Text = cmbPrice.Items[0].ToString();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbPrice.Text == "")
            {
                MessageBox.Show("請選擇實際報價的單價類型");
                cmbPrice.Focus();
                return;
            }
            selected_price = cmbPrice.Text;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            selected_price = "";
            this.Close();
        }

        private void frmQuotation_Actual_Price_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cmbPrice.Text == "")
            {
                selected_price = "";
            }
        }
    }
}
