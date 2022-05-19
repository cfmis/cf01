using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xrQuotation : DevExpress.XtraReports.UI.XtraReport
    {
        public xrQuotation()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id_h", XRColumnSortOrder.Ascending) });
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            
            string strhkd = GetCurrentColumnValue("ishkd").ToString();
            if (GetCurrentColumnValue("ishkd").ToString() == "True")
            {
                //xrLblhkd.Visible = true;
                txthkd.Visible = true;
            }
            else
            {
                //xrLblhkd.Visible = false;
                txthkd.Visible = false;
            }
            if (GetCurrentColumnValue("isusd").ToString() == "True")
            {
                //xrLblusd.Visible = true;
                txtusd.Visible = true;
            }
            else
            {
                //xrLblusd.Visible = false;
                txtusd.Visible = false;
            }
            if (GetCurrentColumnValue("isrmb").ToString() == "True")
            {
                //xrLblrmb.Visible = true;
                txtrmb.Visible = true;
            }
            else
            {
                //xrLblrmb.Visible = false;
                txtrmb.Visible = false;
            }            

            //string strExpress = GetCurrentColumnValue("money_id").ToString();
            //switch (strExpress)
            //{
            //    case "HKD":
            //        xrLblusd.Visible = false;
            //        txtusd.Visible = false;
            //        xrLblhkd.Visible = true;
            //        txthkd.Visible = true;
            //        xrLblrmb.Visible = false;
            //        txtrmb.Visible = false;
            //        break;
            //    case "USD":
            //        xrLblusd.Visible = true;
            //        txtusd.Visible = true;
            //        xrLblhkd.Visible = false;
            //        txthkd.Visible = false;
            //        xrLblrmb.Visible = false;
            //        txtrmb.Visible = false;
            //        break;
            //    case "RMB":
            //        xrLblusd.Visible = false;
            //        txtusd.Visible = false;
            //        xrLblhkd.Visible = false;
            //        txthkd.Visible = false;
            //        xrLblrmb.Visible = true;
            //        txtrmb.Visible = true;
            //        break;
            //    default ://條件之外顯示HKD
            //        xrLblusd.Visible = false;
            //        txtusd.Visible = false;
            //        xrLblhkd.Visible = true;
            //        txthkd.Visible = true;
            //        xrLblrmb.Visible = false;
            //        txtrmb.Visible = false;
            //        break;
            //}            
        }

        private void xrLabel30_TextChanged(object sender, EventArgs e)
        {
            if (xrLabel30.Text == "0")
                xrLabel30.Visible = false;
            else
                xrLabel30.Visible = true;
        }

        private void xrLabel32_TextChanged(object sender, EventArgs e)
        {
            if (xrLabel32.Text == "H")
            {
                xrLabel32.Text = "100PCS";
            }  
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

        private void txtmd_charge_cny_TextChanged(object sender, EventArgs e)
        {
            string md_chargee = GetCurrentColumnValue("md_charge").ToString();
            if (md_chargee == "0.00")
            {
                txtmd_charge.Visible = false;
                txtmd_charge_cny.Visible = false;
            }
            else
            {
                txtmd_charge.Visible = true;
                txtmd_charge_cny.Visible = true;
            }
        }
    }
}
