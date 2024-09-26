using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace cf01.Reports
{
    public partial class xrTakeMoSample_A4 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrTakeMoSample_A4()
        {
            InitializeComponent();
        }

        void BindImage()
        {
            string art_path = DBUtility.imagePath + GetCurrentColumnValue("picture_name");
            if (File.Exists(art_path))
            {
                picArt.ImageUrl = art_path;
            }
            else
            {
                picArt.ImageUrl = null;
            }
        }

        private void xrTakeMoSample_A4_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            BindImage();
        }

        private void xrLabel32_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            xrPageNo.Text = "Page:" + (e.PageIndex + 1).ToString() + "/" + e.PageCount.ToString();
        }

        private void xrPrintTime_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            xrPrintTime.Text = "DateTime: " + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm");
        }

        private void xrPrintUser_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            xrPrintUser.Text = "User: " + DBUtility._user_id;
        }

        private void xrTakeMoSample_A4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }

    }
}
