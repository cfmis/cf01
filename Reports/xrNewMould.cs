using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrNewMould : DevExpress.XtraReports.UI.XtraReport
    {
        public xrNewMould()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrPictureBox1.ImageUrl = GetCurrentColumnValue("picture_name").ToString();
            xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        }

    }
}
