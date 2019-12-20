using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrProductCosting : DevExpress.XtraReports.UI.XtraReport
    {
        public xrProductCosting()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xlbStrSetFlag.Text = "";
            if (xlbIsSetFlag.Text.ToString() == "True")
                xlbStrSetFlag.Text = "Y";
        }

    }
}
