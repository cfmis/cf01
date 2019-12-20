using System;
using System.IO;
namespace cf01.Reports
{
    public partial class xtaWork_No_BarCodeA4 : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWork_No_BarCodeA4()
        {
            InitializeComponent();
        }

        void BindImage()
        {
            string art_path = GetCurrentColumnValue("picture_name").ToString();
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

        private void xtaWork_No_BarCodeA4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string per_qty = GetCurrentColumnValue("per_qty").ToString();
            if (string.IsNullOrEmpty(per_qty))
            {
                per_qty = "0";
            }
            per_qty = per_qty.Replace(",", "");            
            if (Int32.Parse(per_qty) == 0)
            {
               lblper_qty.Text = GetCurrentColumnValue("prod_qty").ToString();
            }

            //net_weight
        }

        private void lblnet_weight_TextChanged(object sender, EventArgs e)
        {
            if (lblnet_weight.Text == "0.0")
            {
                lblnet_weight.Visible = false;
            }
            else
            {
                lblnet_weight.Visible = true;
            }
        }
    }
}
