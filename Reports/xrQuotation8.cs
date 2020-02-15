using System;
using DevExpress.XtraReports.UI;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xrQuotation8 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrQuotation8()
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
       
    }
}
