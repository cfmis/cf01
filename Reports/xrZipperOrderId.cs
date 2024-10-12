using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrZipperOrderId : DevExpress.XtraReports.UI.XtraReport
    {
        public xrZipperOrderId()
        {
            InitializeComponent();
        }

        private void xr_ZipperOrder_Id_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("sequence_id", XRColumnSortOrder.Ascending) });


            
        }

        private void txtMat_type_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {

        }

        private void txtMat_type_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void xrZipperOrderId_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        {
            
        }

        private void xrPrintTime_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            xrPrintTime.Text = "DateTime: " + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm");
        }

        private void xrPrintUser_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            xrPrintUser.Text = "User: " + DBUtility._user_id;
        }

    }
}
