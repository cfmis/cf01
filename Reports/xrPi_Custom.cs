using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrPi_Custom : XtraReport
    {
        public xrPi_Custom()
        {
            InitializeComponent();
            lblTotal_sum.DataBindings.Add("Text", DataSource, "total_sum");//小計欄位需這樣綁定                        
            lblTotal_sum_s.DataBindings.Add("Text", DataSource, "total_sum");
        }

        void BindImage(string pFile)
        {
            xrPictureBox1.ImageUrl = pFile;
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strFile = GetCurrentColumnValue("picture").ToString();
            if (!string.IsNullOrEmpty(strFile))
            {
                if (System.IO.File.Exists(strFile))
                {
                    BindImage(strFile);
                }
                else
                {                   
                    xrPictureBox1.ImageUrl = null ;
                }
            }
            else
            {
                xrPictureBox1.ImageUrl = null ;
            }          
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }
    }
}
