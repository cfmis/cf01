using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrPurDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        string m_date_from, m_date_to;
        public xrPurDelivery(string p_date_from, string p_date_to)
        {
           
            InitializeComponent();
            m_date_from =p_date_from;
            m_date_to = p_date_to;
        }

        private void xrPurDelivery_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組            
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("date_ym", XRColumnSortOrder.Ascending) });
            lblrange_date.Text = String.Format("入單日期范圍：{0} ~ {1}", m_date_from, m_date_to);
        }

    }
}
