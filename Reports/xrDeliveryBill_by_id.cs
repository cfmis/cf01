using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDeliveryBill_by_id : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDeliveryBill_by_id()
        {
            InitializeComponent();
            Sec_qty_sum.DataBindings.Add("Text", DataSource, "sec_qty");//小計欄位需這樣綁定
            packag_sum.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
             //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }

        private void lblpackage_sum_TextChanged(object sender, EventArgs e)
        {
            if (lblpackage_sum.Text != "0")
            {
                lblpackage_sum.Visible = true;                
            }
            else
            {
                lblpackage_sum.Visible = false;              
            }
        }

    }
}
