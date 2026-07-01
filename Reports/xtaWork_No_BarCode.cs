using System;
using System.IO;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xtaWork_No_BarCode : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWork_No_BarCode()
        {
            InitializeComponent();
        }

        void BindImage()
        {
            string art_path = "";// GetCurrentColumnValue("picture_name").ToString();
            clsPublicOfGEO clsConErp = new clsPublicOfGEO();
            art_path = clsConErp.getErpImagePath() + GetCurrentColumnValue("picture_name");
            if (File.Exists(art_path))
            {
                xrPictureBox1.ImageUrl = art_path;
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();            
        }

        private void xtaWork_No_BarCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string per_qty = GetCurrentColumnValue("per_qty").ToString();
            if (string.IsNullOrEmpty(per_qty))
            {
                per_qty = "0";
            }
            per_qty = per_qty.Replace(",", "");
            if (int.Parse(per_qty) == 0)
            {
                lblper_qty.Text = GetCurrentColumnValue("prod_qty").ToString();
            }
        }

        private void lblnet_weight_TextChanged(object sender, EventArgs e)
        {
            lblnet_weight.Visible = (lblnet_weight.Text == "0.0") ? false : true;           
        }

        private void xrLabel25_TextChanged(object sender, EventArgs e)
        {
            //start 2023/10/06 
            string qty_remaining = GetCurrentColumnValue("qty_remaining").ToString();
            if (string.IsNullOrEmpty(qty_remaining))
            {
                qty_remaining = "0";
            }
            int page_num = int.Parse(GetCurrentColumnValue("page_num").ToString());
            int total_page = int.Parse(GetCurrentColumnValue("total_page").ToString());
            qty_remaining = qty_remaining.Replace(",", "");
            if (int.Parse(qty_remaining) > 0 && page_num == total_page)
            {
                lblper_qty.Text = GetCurrentColumnValue("qty_remaining").ToString();
            }
        }

        private void txtQc_dept_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GetCurrentColumnValue("qc_dept").ToString()))
            {
                txtQc_dept.Visible = false;
            }
            else
            {
                txtQc_dept.Visible = true;
            }
            //txtQc_dept.Visible = (string.IsNullOrEmpty(GetCurrentColumnValue("qc_dept").ToString())) ? false : true;            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            pnlQc.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("qc_dept").ToString()) ? false : true;
            pnlHold.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("flag_hold").ToString().Trim()) ? false : true;
            pnlShadingColor.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("shading_color").ToString().Trim()) ? false : true;
        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string wp_id = GetCurrentColumnValue("wp_id").ToString();
            string next_wp_id = GetCurrentColumnValue("next_wp_id").ToString();
            string wh = "";
            if (next_wp_id.Substring(0, 1) == "8" || wp_id.Substring(0, 1) == "8")
                wh = next_wp_id.Substring(0, 1) == "8"? next_wp_id : wp_id;                
            else
                wh = "";
            if (wh == "")
                txtLocation.Text = "貨  架:";
            else
                txtLocation.Text = $"{wh}倉貨架:";
        }
    }
}
