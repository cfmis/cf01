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
            lblUser_id.Text = DBUtility.user_name;

            lblCon_qty_sum.DataBindings.Add("Text", DataSource, "con_qty");//合計欄位綁定
            lblSec_qty_sum.DataBindings.Add("Text", DataSource, "sec_qty");            
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

        private void lblAdd_days_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {           
            string strDays = GetCurrentColumnValue("add_days").ToString();
            if (!string.IsNullOrEmpty(strDays))
            {               
                if (GetCurrentColumnValue("row_no").ToString() == "1")
                {
                    lblAdd_days.Visible = true;
                }
                else
                {
                    lblAdd_days.Visible = false;
                }
            }
            else
            {
                lblAdd_days.Visible = false;
            }
        }
    }
}
