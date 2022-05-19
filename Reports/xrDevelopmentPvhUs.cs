using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDevelopmentPvhUs : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDevelopmentPvhUs()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            chkdivision_mens.Checked = GetCurrentColumnValue("division_mens").ToString() == "True" ? true : false;
            chkdivision_mens.Checked = GetCurrentColumnValue("division_mens").ToString() == "True" ? true : false;
            chkdivision_womens.Checked = GetCurrentColumnValue("division_womens").ToString() == "True" ? true : false;
            chkdivision_boys.Checked = GetCurrentColumnValue("division_boys").ToString() == "True" ? true : false;
            chkdivision_girls.Checked = GetCurrentColumnValue("division_girls").ToString() == "True" ? true : false;
            chkdivision_branding.Checked = GetCurrentColumnValue("division_branding").ToString() == "True" ? true : false;
            chkdivision_swim.Checked = GetCurrentColumnValue("division_swim").ToString() == "True" ? true : false;
            chkdivision_denim.Checked = GetCurrentColumnValue("division_denim").ToString() == "True" ? true : false;
            chkdivision_th_accy.Checked = GetCurrentColumnValue("division_th_accy").ToString() == "True" ? true : false;
            chkdivision_tommy_jeans.Checked = GetCurrentColumnValue("division_tommy_jeans").ToString() == "True" ? true : false;
            chkdivision_specialty.Checked = GetCurrentColumnValue("division_specialty").ToString() == "True" ? true : false;
            chkdivision_adaptive.Checked = GetCurrentColumnValue("division_adaptive").ToString() == "True" ? true : false;
            chkdivision_mercedez_benz.Checked = GetCurrentColumnValue("division_mercedez_benz").ToString() == "True" ? true : false;
            chktrim_conform_yes.Checked = GetCurrentColumnValue("trim_conform_yes").ToString() == "True" ? true : false;
            chktrim_conform_no.Checked = GetCurrentColumnValue("trim_conform_no").ToString() == "True" ? true : false;
            chktrim_comply_yes.Checked = GetCurrentColumnValue("trim_comply_yes").ToString() == "True" ? true : false;
            chktrim_comply_no.Checked = GetCurrentColumnValue("trim_comply_no").ToString() == "True" ? true : false;
            chktick_box_oekotex.Checked = GetCurrentColumnValue("tick_box_oekotex").ToString() == "True" ? true : false;
            chktick_box_bluesign.Checked = GetCurrentColumnValue("tick_box_bluesign").ToString() == "True" ? true : false;
            chktick_box_party_testing.Checked = GetCurrentColumnValue("tick_box_party_testing").ToString() == "True" ? true : false;

            chkoekotex_class1.Checked = GetCurrentColumnValue("oekotex_class1").ToString() == "True" ? true : false;
            chkoekotex_class2.Checked = GetCurrentColumnValue("oekotex_class2").ToString() == "True" ? true : false;
            chksus_grs.Checked = GetCurrentColumnValue("sus_grs").ToString() == "True" ? true : false;
            chksus_pcs.Checked = GetCurrentColumnValue("sus_pcs").ToString() == "True" ? true : false;
            chksus_gots.Checked = GetCurrentColumnValue("sus_gots").ToString() == "True" ? true : false;
            chksus_fsc.Checked = GetCurrentColumnValue("sus_fsc").ToString() == "True" ? true : false;
            chksus_lwg.Checked = GetCurrentColumnValue("sus_lwg").ToString() == "True" ? true : false;
            chksus_other.Checked = GetCurrentColumnValue("sus_other").ToString() == "True" ? true : false;

            chksug_machine_wash.Checked = GetCurrentColumnValue("sug_machine_wash").ToString() == "True" ? true : false;
            chksug_hand_wash_only.Checked = GetCurrentColumnValue("sug_hand_wash_only").ToString() == "True" ? true : false;
            chksug_do_not_dryclean.Checked = GetCurrentColumnValue("sug_do_not_dryclean").ToString() == "True" ? true : false;
            chksug_dryclean_only.Checked = GetCurrentColumnValue("sug_dryclean_only").ToString() == "True" ? true : false;
            chksug_swimwear.Checked = GetCurrentColumnValue("sug_swimwear").ToString() == "True" ? true : false;
            chksug_childrenwear.Checked = GetCurrentColumnValue("sug_childrenwear").ToString() == "True" ? true : false;
            chksug_pass_needle.Checked = GetCurrentColumnValue("sug_pass_needle").ToString() == "True" ? true : false;
            chksug_turn_inside_out.Checked = GetCurrentColumnValue("sug_turn_inside_out").ToString() == "True" ? true : false;

            chkcolor_archroma.Checked = GetCurrentColumnValue("color_archroma").ToString() == "True" ? true : false;
            chkcolor_pantone.Checked = GetCurrentColumnValue("color_pantone").ToString() == "True" ? true : false;
            chkcolor_csi.Checked = GetCurrentColumnValue("color_csi").ToString() == "True" ? true : false;
            chkcolor_th_stand.Checked = GetCurrentColumnValue("color_th_stand").ToString() == "True" ? true : false;
            chkcolor_supplier.Checked = GetCurrentColumnValue("color_supplier").ToString() == "True" ? true : false;

            chkdimen_size_inch.Checked = GetCurrentColumnValue("dimen_size_inch").ToString() == "True" ? true : false;
            chkdimen_size_mm.Checked = GetCurrentColumnValue("dimen_size_mm").ToString() == "True" ? true : false;
            chkbest_can_do.Checked = GetCurrentColumnValue("best_can_do").ToString() == "True" ? true : false;
            chkfor_approval_yes.Checked = GetCurrentColumnValue("for_approval_yes").ToString() == "True" ? true : false;
            chkfor_color_yes.Checked = GetCurrentColumnValue("for_color_yes").ToString() == "True" ? true : false;
            chkfor_bulk_ref_yes.Checked = GetCurrentColumnValue("for_bulk_ref_yes").ToString() == "True" ? true : false;
            chksub_submit1.Checked = GetCurrentColumnValue("sub_submit1").ToString() == "True" ? true : false;
            chksub_submit2.Checked = GetCurrentColumnValue("sub_submit2").ToString() == "True" ? true : false;
            chksub_urgent.Checked = GetCurrentColumnValue("sub_urgent").ToString() == "True" ? true : false;

            chkstatus_approved.Checked = GetCurrentColumnValue("status_approved").ToString() == "True" ? true : false;
            chkstatus_correct.Checked = GetCurrentColumnValue("status_correct").ToString() == "True" ? true : false;
            chkstatus_resubmit.Checked = GetCurrentColumnValue("status_resubmit").ToString() == "True" ? true : false;
            chkstatus_cancelled.Checked = GetCurrentColumnValue("status_cancelled").ToString() == "True" ? true : false;

            chktrim_review_yes.Checked = GetCurrentColumnValue("trim_review_yes").ToString() == "True" ? true : false;
            chktrim_review_no.Checked = GetCurrentColumnValue("trim_review_no").ToString() == "True" ? true : false;
            chkdepth_lighter.Checked = GetCurrentColumnValue("depth_lighter").ToString() == "True" ? true : false;
            chkdepth_deeper.Checked = GetCurrentColumnValue("depth_deeper").ToString() == "True" ? true : false;
            chkchroma_brighter.Checked = GetCurrentColumnValue("chroma_brighter").ToString() == "True" ? true : false;
            chkchroma_duller.Checked = GetCurrentColumnValue("chroma_duller").ToString() == "True" ? true : false;
            chkhue_yellower.Checked = GetCurrentColumnValue("hue_yellower").ToString() == "True" ? true : false;
            chkhue_redder.Checked = GetCurrentColumnValue("hue_redder").ToString() == "True" ? true : false;
            chkhue_bluer.Checked = GetCurrentColumnValue("hue_bluer").ToString() == "True" ? true : false;
            chkhue_greener.Checked = GetCurrentColumnValue("hue_greener").ToString() == "True" ? true : false;
            
        }        

        private void txtTrim_1k_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("trim_1k").ToString() == "0.0000")
                txtTrim_1k.Visible = false;
            else
                txtTrim_1k.Visible = true;
        }

        private void txtTrim_flat_price_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("trim_flat_price").ToString() == "0.0000")
                txtTrim_flat_price.Visible = false;
            else
                txtTrim_flat_price.Visible = true;
        }

        private void txtTrim_1k_3k_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("trim_1k_3k").ToString() == "0.0000")
                txtTrim_1k_3k.Visible = false;
            else
                txtTrim_1k_3k.Visible = true;
        }

        private void txtTrim_3k_5k_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("trim_3k_5k").ToString() == "0.0000")
                txtTrim_3k_5k.Visible = false;
            else
                txtTrim_3k_5k.Visible = true;
        }

        private void txtmaterial_per1_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("material_per1").ToString() == "0")
                txtmaterial_per1.Visible = false;
            else
                txtmaterial_per1.Visible = true;
        }

        private void txtmaterial_per2_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("material_per2").ToString() == "0")
                txtmaterial_per2.Visible = false;
            else
                txtmaterial_per2.Visible = true;
        }

        private void txtmaterial_per3_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("material_per3").ToString() == "0")
                txtmaterial_per3.Visible = false;
            else
                txtmaterial_per3.Visible = true;
        }

        private void txtmaterial_per4_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("material_per4").ToString() == "0")
                txtmaterial_per4.Visible = false;
            else
                txtmaterial_per4.Visible = true;
        }

        private void txtSample_submis_date_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSample_submis_date.Text))
            {
                txtSample_submis_date.Text = DateTime.Parse(GetCurrentColumnValue("sample_submis_date").ToString()).Date.ToString("dd/MM/yyyy");
            }
        }

        private void txtdelivery_date_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtdelivery_date.Text))
            {
               // txtdelivery_date.Text = DateTime.Parse(GetCurrentColumnValue("delivery_date").ToString()).Date.ToString("dd/MM/yyyy");
            }            
        }
    }    
}
