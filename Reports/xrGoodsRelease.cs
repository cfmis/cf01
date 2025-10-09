using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrGoodsRelease : DevExpress.XtraReports.UI.XtraReport
    {
        public xrGoodsRelease()
        {
            InitializeComponent();
           
        }

        private void xrLabel5_TextChanged(object sender, EventArgs e)
        {
            string strDate = GetCurrentColumnValue("bill_date").ToString();
            strDate = DateTime.Parse(strDate).Date.ToString("yyyy/MM/dd");
            
        }

        private void txtBillDate_TextChanged(object sender, EventArgs e)
        {
            string strDate = GetCurrentColumnValue("bill_date").ToString();
            strDate = DateTime.Parse(strDate).Date.ToString("yyyy/MM/dd");
            txtBillDate.Text = strDate.Substring(0,4);
        }

        private void txtBillDate_mm_TextChanged(object sender, EventArgs e)
        {
            string strDate = GetCurrentColumnValue("bill_date").ToString();
            strDate = DateTime.Parse(strDate).Date.ToString("yyyy/MM/dd");
            txtBillDate_mm.Text = strDate.Substring(5, 2);
        }

        private void txtBillDate_dd_TextChanged(object sender, EventArgs e)
        {
            string strDate = GetCurrentColumnValue("bill_date").ToString();
            strDate = DateTime.Parse(strDate).Date.ToString("yyyy/MM/dd");
            txtBillDate_dd.Text = strDate.Substring(8, 2);
        }

        private void xrGoodsRelease_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strReason = GetCurrentColumnValue("reason").ToString();
            switch (strReason)
            {
                case "廠商自帶":
                    xrCheckBox1.Checked = true;
                    break;
                case "委外維修":
                    xrCheckBox2.Checked = true;
                    break;
                case "租賃":
                    xrCheckBox3.Checked = true;
                    break;
                case "處理客訴":
                    xrCheckBox4.Checked = true;
                    break;
                case "報廢出售":
                    xrCheckBox5.Checked = true;
                    break;
                case "其它":
                    xrCheckBox6.Checked = true;
                    break;
            }
        }
    }
}
