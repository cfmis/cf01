using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace cf01.Reports
{
    public partial class xrTakeMoSample_Card : DevExpress.XtraReports.UI.XtraReport
    {
        public xrTakeMoSample_Card()
        {
            InitializeComponent();
        }
        void BindImage()
        {
            string art_path = DBUtility.imagePath + GetCurrentColumnValue("picture_name");
            if (File.Exists(art_path))
            {
                picArt.ImageUrl = art_path;
                picArt1.ImageUrl = art_path;
            }
            else
            {
                picArt.ImageUrl = null;
                picArt1.ImageUrl = null;
            }
        }

        private void xrTakeMoSample_Card_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            BindImage();
        }

        private void xrPrintTime_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            xrPrintTime.Text = "DateTime: " + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm");
        }
    }
}
