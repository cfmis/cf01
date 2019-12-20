using System;
namespace cf01.Reports
{
    public partial class xrTrimsSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public xrTrimsSheet()
        {
            InitializeComponent();
        }

        private void xrTrimsSheet_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            chknew_submit.Checked = GetCurrentColumnValue("new_submit").ToString() == "True" ? true : false;
            chkcounter.Checked = GetCurrentColumnValue("counter").ToString() == "True" ? true : false;
            chknew_development.Checked = GetCurrentColumnValue("new_development").ToString() == "True" ? true : false;

            
        }

    }
}
