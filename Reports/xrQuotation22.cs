using System;
using DevExpress.XtraReports.UI;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xrQuotation22 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrQuotation22()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id_h", XRColumnSortOrder.Ascending) });
        }

        private void xrLabel30_TextChanged(object sender, EventArgs e)
        {
            if (xrLabel30.Text == "0")
                xrLabel30.Visible = false;
            else
                xrLabel30.Visible = true;
        }

        //private void xrLabel32_TextChanged(object sender, EventArgs e)
        //{
        //    if (xrLabel32.Text == "H")
        //    {
        //        xrLabel32.Text = "100PCS";
        //    }  
        //}

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

        private void txtmd_charge_cny_TextChanged(object sender, EventArgs e)
        {
            string md_chargee_vn = GetCurrentColumnValue("md_charge_vn").ToString();
            if (md_chargee_vn == "0.00")
            {
                txtmd_charge_vn.Visible = false;
                txtmd_charge_cny.Visible = false;
            }
            else
            {
                txtmd_charge_vn.Visible = true;
                txtmd_charge_cny.Visible = true;
            }
        }

        //private void txtPrice_vnd_pcs_TextChanged(object sender, EventArgs e)
        //{
        //    string strPrice_vnd_pcs = GetCurrentColumnValue("price_vnd_pcs").ToString();
        //    txtPrice_vnd_pcs.Text = strPrice_vnd_pcs.Replace(".000", "");
        //}

        //private void txtPrice_vnd_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    //decimal price_vnd = decimal.Parse(GetCurrentColumnValue("price_vnd").ToString());
        //    //if (price_vnd > 0)
        //    //    txtPrice_vnd_usd.Text = string.Format("{0:###,###}", price_vnd);
        //    //else
        //    //    txtPrice_vnd_usd.Text = "0";
        //}

        private void txtPrice_vnd_pcs_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal price_vnd_pcs = decimal.Parse(GetCurrentColumnValue("price_vnd_pcs").ToString());
            if (price_vnd_pcs > 0)
                txtPrice_vnd_pcs.Text = string.Format("{0:###,###}", price_vnd_pcs);
            else
                txtPrice_vnd_pcs.Text = "0";
        }

        private void txtPrice_vnd_usd_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strPrice_vnd_usd = GetCurrentColumnValue("price_vnd_usd").ToString();
            txtPrice_vnd_usd.Text = strPrice_vnd_usd.Replace(".000", "");
        }
    }
}
