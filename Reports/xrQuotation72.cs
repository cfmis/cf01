using System;
using DevExpress.XtraReports.UI;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xrQuotation72 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrQuotation72()
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
