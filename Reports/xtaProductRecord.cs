using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace cf01.Reports
{
    public partial class xtaProductRecord : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtPrd = new DataTable();

        public xtaProductRecord(DataTable dtPrdf)
        {
            InitializeComponent();
            dtPrd = dtPrdf;
        }

        private void xtaProductRecord_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }

        private void xrLabel31_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel31.Text = (xrLabel31.Text.Trim() == "0" ? "" : xrLabel31.Text);
            xrLabel32.Text = (xrLabel32.Text.Trim() == "0.0000" ? "" : xrLabel32.Text);
            xrLabel25.Text = (xrLabel25.Text.Trim() == "0" ? "" : xrLabel25.Text);
            xrLabel30.Text = (xrLabel30.Text.Trim() == "0" ? "" : xrLabel30.Text);
            xrLabel21.Text = (xrLabel21.Text.Trim() == "0" ? "" : xrLabel21.Text);
            xrLabel22.Text = (xrLabel22.Text.Trim() == "0" ? "" : xrLabel22.Text);
            xrLabel18.Text = (xrLabel18.Text.Trim() == "0" ? "" : xrLabel18.Text);
            xrLabel19.Text = (xrLabel19.Text.Trim() == "0" ? "" : xrLabel19.Text);
            xrLabel7.Text = (xrLabel7.Text.Trim() == "0" ? "" : xrLabel7.Text);
            xrLabel8.Text = (xrLabel8.Text.Trim() == "0" ? "" : xrLabel8.Text);
            xrLabel26.Text = (xrLabel26.Text.Trim() == "0" ? "" : xrLabel26.Text);
            xrLabel27.Text = (xrLabel27.Text.Trim() == "0" ? "" : xrLabel27.Text);
        }

        private void xrLabel28_TextChanged(object sender, EventArgs e)
        {
            xrLabel28.Text = (xrLabel28.Text.Replace(" ", "") == "0" ? "" : xrLabel28.Text);
        }

        private void xrLabel29_TextChanged(object sender, EventArgs e)
        {
            xrLabel29.Text = (xrLabel29.Text.Replace(" ", "") == "0" ? "" : xrLabel29.Text);
        }
    }
}
