using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDevelopCalvinSheet1 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDevelopCalvinSheet1()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //txtdate.Text = Convert.ToDateTime(GetCurrentColumnValue("form_date1")).ToString("yyyy/MM/dd");            
            chkmachine_washable.Checked = GetCurrentColumnValue("machine_washable").ToString() == "True" ? true : false;
            chkdrycleanable.Checked = GetCurrentColumnValue("drycleanable").ToString() == "True" ? true : false;
            chkdryclean_only.Checked = GetCurrentColumnValue("dryclean_only").ToString() == "True" ? true : false;
            chkdo_not_dryclean.Checked = GetCurrentColumnValue("do_not_dryclean").ToString() == "True" ? true : false;
            chkuse_for_swimwear.Checked = GetCurrentColumnValue("use_for_swimwear").ToString() == "True" ? true : false;
            chkuse_for_childrenswear.Checked = GetCurrentColumnValue("use_for_childrenswear").ToString() == "True" ? true : false;
            chkcannot_pass_needle.Checked = GetCurrentColumnValue("cannot_pass_needle").ToString() == "True" ? true : false;

            chkck_mens.Checked = GetCurrentColumnValue("ck_mens").ToString() == "True" ? true : false;
            chkck_womens.Checked = GetCurrentColumnValue("ck_womens").ToString() == "True" ? true : false;
            chck_df.Checked = GetCurrentColumnValue("ck_df").ToString() == "True" ? true : false;
            chkck_formal.Checked = GetCurrentColumnValue("ck_formal").ToString() == "True" ? true : false;
            chkck_kids.Checked = GetCurrentColumnValue("ck_kids").ToString() == "True" ? true : false;
            chkck_accessories.Checked = GetCurrentColumnValue("ck_accessories").ToString() == "True" ? true : false;
            chkck_jeans.Checked = GetCurrentColumnValue("ck_jeans").ToString() == "True" ? true : false;
            chkck_swim.Checked = GetCurrentColumnValue("ck_swim").ToString() == "True" ? true : false;
            chkck_underwear.Checked = GetCurrentColumnValue("ck_underwear").ToString() == "True" ? true : false;
            chkMK.Checked = GetCurrentColumnValue("mk").ToString() == "True" ? true : false;
            chkck_sportswear.Checked = GetCurrentColumnValue("ck_sportswear").ToString() == "True" ? true : false;
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
