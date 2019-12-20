using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrhg_plate : DevExpress.XtraReports.UI.XtraReport
    {
        public xrhg_plate()
        {
            InitializeComponent();
        }

        private void xrhg_plate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }

    }
}
