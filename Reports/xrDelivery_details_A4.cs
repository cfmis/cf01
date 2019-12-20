using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDelivery_details_A4 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDelivery_details_A4()
        {
            InitializeComponent();
            lblUser_id.Text = DBUtility._user_id;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        } 

        private void lblpackage_TextChanged(object sender, EventArgs e)
        {
            if (lblpackage.Text == "1")
            {
                lblpackage.Visible = false;
            }
            else
            {
                lblpackage.Visible = true;
            }           
        }

    }
}
