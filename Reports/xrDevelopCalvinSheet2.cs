using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDevelopCalvinSheet2 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDevelopCalvinSheet2()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        { 
            txtdate.Text = Convert.ToDateTime(GetCurrentColumnValue("date")).ToString("yyyy/MM/dd");        
            chksubmit1.Checked = GetCurrentColumnValue("submit1").ToString() == "True" ? true : false;
            chksubmit2.Checked = GetCurrentColumnValue("submit2").ToString() == "True" ? true : false;
            chksubmit3.Checked = GetCurrentColumnValue("submit3").ToString() == "True" ? true : false;
            chkurgent.Checked = GetCurrentColumnValue("urgent").ToString() == "True" ? true : false;           

            chkck_mens.Checked = GetCurrentColumnValue("ck_mens").ToString() == "True" ? true : false;           
            chkck_df.Checked = GetCurrentColumnValue("ck_df").ToString() == "True" ? true : false;
            chkck_formal.Checked = GetCurrentColumnValue("ck_formal").ToString() == "True" ? true : false;
            chkck_womens.Checked = GetCurrentColumnValue("ck_womens").ToString() == "True" ? true : false;
            chkck_kids.Checked = GetCurrentColumnValue("ck_kids").ToString() == "True" ? true : false;
            chkck_accessories.Checked = GetCurrentColumnValue("ck_accessories").ToString() == "True" ? true : false;
            chkck_jeans.Checked = GetCurrentColumnValue("ck_jeans").ToString() == "True" ? true : false;
            chkck_swim.Checked = GetCurrentColumnValue("ck_swim").ToString() == "True" ? true : false;
            chkck_underwear.Checked = GetCurrentColumnValue("ck_underwear").ToString() == "True" ? true : false;
            chkmk.Checked = GetCurrentColumnValue("mk").ToString() == "True" ? true : false;
            chkck_sportswear.Checked = GetCurrentColumnValue("ck_sportswear").ToString() == "True" ? true : false;
        }


        private void txttitered_qty1_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty1").ToString() == "0")            
                txttiered_qty1.Visible = false;
            else
                txttiered_qty1.Visible = true;
        }

        private void txttitered_qty2_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty2").ToString() == "0")            
                txttiered_qty2.Visible = false;
            else
                txttiered_qty2.Visible = true;
        }

        private void txttitered_qty3_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty3").ToString() == "0")            
                txttiered_qty3.Visible = false;
            else
                txttiered_qty3.Visible = true;
        }

        private void txttitered_qty4_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty4").ToString() == "0")            
                txttiered_qty4.Visible = false;
            else
                txttiered_qty4.Visible = true;
        }

        private void txttitered_qty5_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty5").ToString() == "0")            
                txttiered_qty5.Visible = false;
            else
                txttiered_qty5.Visible = true;
        }

        private void xrLabel30_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price1").ToString() == "0.00")            
                pnlPrice1.Visible = false;
            else
                pnlPrice1.Visible = true;
        }

        private void xrLabel41_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price2").ToString() == "0.0000")            
                pnlPrice2.Visible = false;
            else
                pnlPrice2.Visible = true;
        }

        private void xrLabel43_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price3").ToString() == "0.0000")            
                pnlPrice3.Visible = false;
            else
                pnlPrice3.Visible = true;
        }

        private void xrLabel45_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price4").ToString() == "0.0000")            
                pnlPrice4.Visible = false;
            else
                pnlPrice4.Visible = true;
        }

        private void xrLabel47_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price5").ToString() == "0.0000")            
                pnlPrice5.Visible = false;
            else
                pnlPrice5.Visible = true;
        }

    }
}
