using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDgDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDgDelivery()
        {
            InitializeComponent();

            lblSec_qty.DataBindings.Add("Text", DataSource, "sec_qty");//小計欄位需這樣綁定
            lblPackage_num.DataBindings.Add("Text", DataSource, "package_num");

            lblSec_qtyTotal.DataBindings.Add("Text", DataSource, "sec_qty");//小計欄位需這樣綁定
            lblPackage_numTotal.DataBindings.Add("Text", DataSource, "package_num");
        }

        private void txtoi_date_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strdate = GetCurrentColumnValue("oi_date").ToString();
            if (string.IsNullOrEmpty(strdate))
            {
                return;
            }
            txtoi_date.Text = DateTime.Parse(strdate).Date.ToString("yyyy/MM/dd");
        }

        private void lblIsAproved_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string state = GetCurrentColumnValue("state").ToString();
            if (state == "0")
                lblIsAproved.Visible = true;
            else
                lblIsAproved.Visible = false;
        }

        private void lblPackage_num_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string packageNum = GetCurrentColumnValue("package_num").ToString();
            if (packageNum == "0")
                lblPackage_num.Visible = false;
            else
                lblPackage_num.Visible = true;

        }

        private void lblBox_no_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string boxNo = GetCurrentColumnValue("box_no").ToString();
            if (boxNo == "0")
                lblBox_no.Visible = false;
            else
                lblBox_no.Visible = true;

        }
    }
}
