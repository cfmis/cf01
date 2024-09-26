using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrButtonWork : DevExpress.XtraReports.UI.XtraReport
    {
        public xrButtonWork()
        {
            InitializeComponent();
        }

        private void xrButtonWork_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {            
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }

    }
}
