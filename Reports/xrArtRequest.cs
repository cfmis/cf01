using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace cf01.Reports
{
    public partial class xrlArtRequest : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtMostly = new DataTable(); //聲明一DataTable類型的對象以接受傳進來的參數對象
        public xrlArtRequest(DataTable _dt)
        {
            InitializeComponent();
            dtMostly = _dt;
        }

        private void xrArtRequest_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
             xrNeed_reply.DataBindings.Add("Checked", dtMostly, "need_reply");
             xrNeed_reply1.DataBindings.Add("Checked", dtMostly, "need_reply");
             xrRequ_3d_drawing.DataBindings.Add("Checked", dtMostly, "requ_3d_drawing");
        }


        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //dtMostly.Rows[0]["art_requ_id"].ToString();
            //subRpt.getDetail(GetCurrentColumnValue(dsTest.Tables(0).Columns(0).ToString()))
            xrArtRequest_sub subRpt = new xrArtRequest_sub();
            xrSubreport1.ReportSource = subRpt;
            subRpt.getDetail(xrlArt_requ_id.Text, xrVer.Text);
        }

        private void xrArtwork_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrArtwork.ImageUrl = GetCurrentColumnValue("art_image").ToString();
            xrArtwork.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
        }
    }
}
