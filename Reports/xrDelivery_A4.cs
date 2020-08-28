using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDelivery_A4 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDelivery_A4()
        {
            InitializeComponent();
        }

        private void BindImage(string pFile)
        {
            xrPictureBox1.ImageUrl = pFile;
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

        private void lbl_flag_TextChanged(object sender, EventArgs e)
        {  
            //暫取消2016-01-14
            ////CL-K0035 新廠噴油部
            ////CL-K0036 江西廠噴油部
            //if (lbl_flag.Text == "CL-K0036" || lbl_flag.Text == "CL-K0035")
            //{
            //    xrPnl.Visible = true;
            //    //xrPnl2.Visible = true;
            //}
            //else
            //{
            //    xrPnl.Visible = false;
            //    //xrPnl2.Visible = false;
            //}
        }

    }
}
