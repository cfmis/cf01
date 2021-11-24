using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrOut_process_out_vendor : DevExpress.XtraReports.UI.XtraReport
    {
        public xrOut_process_out_vendor()
        {
            InitializeComponent();            
            lblPack_num.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty.DataBindings.Add("Text", DataSource, "sec_qty");

            lblPackag_num_total.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty_total.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty_total.DataBindings.Add("Text", DataSource, "sec_qty");
        }
       

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }

        private void xrLabel18_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("vendor_id").ToString() == "CL-T0011")
            {               
                lblTitle1.Visible = true; //大通              
                lblTitle2.Visible = false;//榮烽
            }
            else
            {
                lblTitle1.Visible = false;
                lblTitle2.Visible = true;
            }
        }
    }
}
