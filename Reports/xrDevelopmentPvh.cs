using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDevelopmentPvh : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDevelopmentPvh()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        { 
              
            chksubmit1.Checked = GetCurrentColumnValue("submit1").ToString() == "True" ? true : false;
            chksubmit2.Checked = GetCurrentColumnValue("submit2").ToString() == "True" ? true : false;
            chksubmit3.Checked = GetCurrentColumnValue("submit3").ToString() == "True" ? true : false;
            chkurgent.Checked = GetCurrentColumnValue("urgent_bulk_order").ToString() == "True" ? true : false;           
            
        }        

        private void lblPrice1_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price1").ToString() == "0.0000")
                lblPrice1.Visible = false;
            else
                lblPrice1.Visible = true;
        }

        private void lblPrice2_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price2").ToString() == "0.0000")
                lblPrice2.Visible = false;
            else
                lblPrice2.Visible = true;
        }

        private void lblPrice3_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price3").ToString() == "0.0000")
                lblPrice3.Visible = false;
            else
                lblPrice3.Visible = true;
        }

        private void lblPrice4_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price4").ToString() == "0.0000")
                lblPrice4.Visible = false;
            else
                lblPrice4.Visible = true;
        }

        private void lblPrice5_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price5").ToString() == "0.0000")
                lblPrice5.Visible = false;
            else
                lblPrice5.Visible = true;
        }

        private void lblPrice6_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price6").ToString() == "0.0000")
                lblPrice6.Visible = false;
            else
                lblPrice6.Visible = true;
        }

        private void lblPercent1_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("raw_mat1_percent").ToString() == "0")
                lblPercent1.Visible = false;
            else
                lblPercent1.Visible = true;
        }
        private void lblPercent2_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("raw_mat2_percent").ToString() == "0")
                lblPercent2.Visible = false;
            else
                lblPercent2.Visible = true;
        }

        private void lblPercent3_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("raw_mat3_percent").ToString() == "0")
                lblPercent3.Visible = false;
            else
                lblPercent3.Visible = true;
        }
        
        private void lblPercentTotal_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("percent_total").ToString() == "0")
                lblPercentTotal.Visible = false;
            else
                lblPercentTotal.Visible = true;
        }

        private void xrLabel64_TextChanged(object sender, EventArgs e)
        {
            xrLabel64.Text = DateTime.Parse(GetCurrentColumnValue("date").ToString()).Date.ToString("dd/MM/yyyy");
        }

        private void lblRsl_certificate_expiry_date_TextChanged(object sender, EventArgs e)
        {
            string val = GetCurrentColumnValue("rsl_certificate_expiry_date").ToString();
            if (!string.IsNullOrEmpty(val))
            {
                lblRsl_certificate_expiry_date.Text = DateTime.Parse(val).Date.ToString("dd-MM-yy");
            }
            
        }
    }
}
