using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrPlateSelect : DevExpress.XtraReports.UI.XtraReport
    {
        public xrPlateSelect()
        {
            InitializeComponent();
            //小計欄位需這樣綁定
            //每組小計
            lblmembers.DataBindings.Add("Text", DataSource, "members");
            lblprd_normal_time.DataBindings.Add("Text", DataSource, "prd_normal_time");
            lblweg_normal.DataBindings.Add("Text", DataSource, "weg_normal");
            lblqty_normal.DataBindings.Add("Text", DataSource, "qty_normal");

            lblprd_ot_time.DataBindings.Add("Text", DataSource, "prd_ot_time");
            lblweg_ot.DataBindings.Add("Text", DataSource, "weg_ot");
            lblqty_ot.DataBindings.Add("Text", DataSource, "qty_ot");

            lblnormal_ot_time.DataBindings.Add("Text", DataSource, "normal_ot_time");
            lblweg_normal_ot.DataBindings.Add("Text", DataSource, "weg_normal_ot");
            lblqty_normal_ot.DataBindings.Add("Text", DataSource, "qty_normal_ot");
            
            //報表尾匯總
            lblmembers_total.DataBindings.Add("Text", DataSource, "members");
            lblprd_normal_time_total.DataBindings.Add("Text", DataSource, "prd_normal_time");
            lblweg_normal_total.DataBindings.Add("Text", DataSource, "weg_normal");
            lblqty_normal_total.DataBindings.Add("Text", DataSource, "qty_normal");

            lblprd_ot_time_total.DataBindings.Add("Text", DataSource, "prd_ot_time");
            lblweg_ot_total.DataBindings.Add("Text", DataSource, "weg_ot");
            lblqty_ot_total.DataBindings.Add("Text", DataSource, "qty_ot");

            lblnormal_ot_time_total.DataBindings.Add("Text", DataSource, "normal_ot_time");
            lblweg_normal_ot_total.DataBindings.Add("Text", DataSource, "weg_normal_ot");
            lblqty_normal_ot_total.DataBindings.Add("Text", DataSource, "qty_normal_ot");
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("dep_group", XRColumnSortOrder.Ascending) });
        }

    }
}
