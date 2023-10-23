using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDeliveryPrepare : DevExpress.XtraReports.UI.XtraReport
    {
        string user_id = string.Empty;
        public xrDeliveryPrepare(string user)
        {
            InitializeComponent();
            user_id = user;
        }

        private void xrPurOutBuy_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組            
            //GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("date_ym", XRColumnSortOrder.Ascending) });
            
            // lblr
            //ange_date.Text = String.Format("入單日期范圍：{0} ~ {1}", m_date_from, m_date_to);
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strFile = GetCurrentColumnValue("picture_name").ToString();
            if (!string.IsNullOrEmpty(strFile))
            {
                if (System.IO.File.Exists(strFile))
                {
                    BindImage(strFile);
                }
                else
                {
                    xrPictureBox1.ImageUrl = null;
                }
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }
        }

        void BindImage(string pFile)
        {
            xrPictureBox1.ImageUrl = pFile;
        }

        private void txtUser_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtUser.Text = user_id;
        }

        private void xrLabel33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal plan_qty = decimal.Parse(GetCurrentColumnValue("plan_qty").ToString());
            if (plan_qty > 0)
                xrLabel33.Text = string.Format("{0:###,###}", plan_qty);
            else
                xrLabel33.Text = "0";
        }

        private void xrLabel34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal move_qty = decimal.Parse(GetCurrentColumnValue("move_qty").ToString());
            if (move_qty > 0)
                xrLabel34.Text = string.Format("{0:###,###}", move_qty);
            else
                xrLabel34.Text = "0";
        }

        private void xrLabel35_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal hk_qty = decimal.Parse(GetCurrentColumnValue("hk_qty").ToString());
            if (hk_qty > 0)
                xrLabel35.Text = string.Format("{0:###,###}", hk_qty);
            else
                xrLabel35.Text = "0";
        }
    }
}
