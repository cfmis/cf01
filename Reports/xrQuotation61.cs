using System;
using DevExpress.XtraReports.UI;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xrQuotation61 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrQuotation61()
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

        private void txtMd_charge_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("md_charge").ToString() == "0.00")
            {
                //txtMd_charge.Text = GetCurrentColumnValue("remark").ToString();
                txtMd_charge.Text = "";
            }
            else
            {
                //txtMd_charge.Text = String.Format("{0} / {1}\r--------------------------\r{2}", GetCurrentColumnValue("md_charge"), GetCurrentColumnValue("md_charge_cny"), GetCurrentColumnValue("remark"));
                txtMd_charge.Text = String.Format("{0} / {1}", GetCurrentColumnValue("md_charge"), GetCurrentColumnValue("md_charge_cny"));
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
       

     
       
    }
}
