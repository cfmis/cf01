using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrArtwork : DevExpress.XtraReports.UI.XtraReport
    {
        public xrArtwork()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrPictureBox1.ImageUrl = GetCurrentColumnValue("picture_name").ToString();
            xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        }     

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrLabel1.Text = String.Format("{0}\r{1}\r{2}", GetCurrentColumnValue("name_prc"), GetCurrentColumnValue("name_en"), GetCurrentColumnValue("customer_goods")); // "TEST";
        }

    }
}
