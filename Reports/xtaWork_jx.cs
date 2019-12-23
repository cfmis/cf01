using System;
using System.IO;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xtaWork_jx : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWork_jx()
        {
            InitializeComponent();
        }

        void BindImage()
        {
            string art_path = "";// DBUtility.imagePath + GetCurrentColumnValue("picture_name");
            clsPublicOfGEO clsConErp = new clsPublicOfGEO();
            art_path = clsConErp.getErpImagePath()+ GetCurrentColumnValue("picture_name");
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
            }
            else
                if (txtWp_id.Text == "102" || txtWp_id.Text == "104")
                {
                    lblWp_id_jx.Text = "J03";                    
                }
                else
                {
                    lblWp_id_jx.Text = "";                   
                }
        }
    }
}
