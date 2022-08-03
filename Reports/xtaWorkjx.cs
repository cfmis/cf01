using System;
using System.IO;
using cf01.ModuleClass;

namespace cf01.Reports
{
    public partial class xtaWorkjx : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWorkjx()
        {
            InitializeComponent();
        }

        void BindImage()
        {
            string art_path = DBUtility.imagePath + GetCurrentColumnValue("picture_name");
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

        private void txtWp_id_TextChanged(object sender, EventArgs e)
        {
            if (txtWp_id.Text == "302")
            {
                lblWp_id_jx.Text = "J01";
                //xrPanel1.Visible = false;
            }
            else
                if (txtWp_id.Text == "102" || txtWp_id.Text == "104")
                {
                    lblWp_id_jx.Text = "J03";
                    //xrPanel1.Visible = false;
                }
                else
                {
                    lblWp_id_jx.Text = "";
                    //xrPanel1.Visible = true;
                }
        }
    }
}
