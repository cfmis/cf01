using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xtaWork : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWork()
        {
            InitializeComponent();
           // BindImage();

        }
        void BindImage()
        {
            xrPictureBox1.ImageUrl =DBUtility.imagePath + GetCurrentColumnValue("picture_name");
           // xrPictureBox1.Image.
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();
           // GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("page_num", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
        }
    }
}
