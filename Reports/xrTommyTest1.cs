using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrTommyTest1 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrTommyTest1()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtdate.Text = Convert.ToDateTime(GetCurrentColumnValue("date")).ToString("yyyy/MM/dd");            
            chkmachine_washable.Checked = GetCurrentColumnValue("machine_washable").ToString() == "True" ? true : false;
            chkdrycleanable.Checked = GetCurrentColumnValue("drycleanable").ToString() == "True" ? true : false;
            chkdryclean_only.Checked = GetCurrentColumnValue("dryclean_only").ToString() == "True" ? true : false;
            chkdo_not_dryclean.Checked = GetCurrentColumnValue("do_not_dryclean").ToString() == "True" ? true : false;
            chkcan_tumble_drying.Checked = GetCurrentColumnValue("can_tumble_drying").ToString() == "True" ? true : false;            
            chkuse_for_swimwear.Checked = GetCurrentColumnValue("use_for_swimwear").ToString() == "True" ? true : false;
            chkuse_for_childrenswear.Checked = GetCurrentColumnValue("use_for_childrenswear").ToString() == "True" ? true : false;
            chkcannot_pass_needle.Checked = GetCurrentColumnValue("cannot_pass_needle").ToString() == "True" ? true : false;

            chkcs_mens.Checked = GetCurrentColumnValue("cs_mens").ToString() == "True" ? true : false;
            chkcs_womens.Checked = GetCurrentColumnValue("cs_womens").ToString() == "True" ? true : false;
            chkcs_boys.Checked = GetCurrentColumnValue("cs_boys").ToString() == "True" ? true : false;
            chkcs_girls.Checked = GetCurrentColumnValue("cs_girls").ToString() == "True" ? true : false;
            chkthm.Checked = GetCurrentColumnValue("thm").ToString() == "True" ? true : false;
            chkthd.Checked = GetCurrentColumnValue("thd").ToString() == "True" ? true : false;
            chkbranding.Checked = GetCurrentColumnValue("branding").ToString() == "True" ? true : false;
            chkth_spw_msw.Checked = GetCurrentColumnValue("th_spw_msw").ToString() == "True" ? true : false;
            chkth_spw_wsw.Checked = GetCurrentColumnValue("th_spw_wsw").ToString() == "True" ? true : false;
            chkth_col_msw.Checked = GetCurrentColumnValue("th_col_msw").ToString() == "True" ? true : false;
            chkth_col_wsw.Checked = GetCurrentColumnValue("th_col_wsw").ToString() == "True" ? true : false;
            chkth_kids.Checked = GetCurrentColumnValue("th_kids").ToString() == "True" ? true : false;
            chkth_swim.Checked = GetCurrentColumnValue("th_swim").ToString() == "True" ? true : false;
            chkth_underwear.Checked = GetCurrentColumnValue("th_underwear").ToString() == "True" ? true : false;
            chkth_acc_ftw.Checked = GetCurrentColumnValue("th_acc_ftw").ToString() == "True" ? true : false;
            chkth_tailored.Checked = GetCurrentColumnValue("th_tailored").ToString() == "True" ? true : false;
            chktommy_jeans.Checked = GetCurrentColumnValue("tommy_jeans").ToString() == "True" ? true : false;
            chkth_sport.Checked = GetCurrentColumnValue("th_sport").ToString() == "True" ? true : false;
            chkdivision.Checked = GetCurrentColumnValue("division").ToString() == "True" ? true : false;
        }

        private void xrLabel30_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("price1").ToString() == "0.0000")
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

        private void txttiered_qty1_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty1").ToString() == "0")            
                txttiered_qty1.Visible = false;
            else
                txttiered_qty1.Visible = true;
        }

        private void txttiered_qty2_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty2").ToString() == "0")            
                txttiered_qty2.Visible = false;
            else
                txttiered_qty2.Visible = true;
        }

        private void txttiered_qty3_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty3").ToString() == "0")            
                txttiered_qty3.Visible = false;
            else
                txttiered_qty3.Visible = true;
        }

        private void txttiered_qty4_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty4").ToString() == "0")            
                txttiered_qty4.Visible = false;
            else
                txttiered_qty4.Visible = true;
        }

        private void txttiered_qty5_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("tiered_qty5").ToString() == "0")            
                txttiered_qty5.Visible = false;
            else
                txttiered_qty5.Visible = true;
        }

    }
}
