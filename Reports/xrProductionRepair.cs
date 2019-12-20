using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrProductionRepair : DevExpress.XtraReports.UI.XtraReport
    {
        private string order_date1, order_date2;
        public xrProductionRepair(string pDate1,string pDate2)
        {           
            InitializeComponent();
            order_date1 = pDate1;
            order_date2 = pDate2;

            txtsec_qty_sum.DataBindings.Add("Text", DataSource, "sec_qty");//小計欄位需這樣綁定
            txtamt_deduction_sum.DataBindings.Add("Text", DataSource, "amt_deduction");//小計欄位需這樣綁定
           
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("vendor_id", XRColumnSortOrder.Ascending), new GroupField("no", XRColumnSortOrder.Ascending) });
            this.txtdate_range.Text = String.Format("申請日期范圍：{0} ~ {1}", order_date1, order_date2);
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrchkIs_ac_deduct.Checked = GetCurrentColumnValue("is_ac_deduct").ToString() == "True" ? true : false;
        }

    }
}
