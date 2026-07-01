using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        public xrDelivery()
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
            //2016-01-14暫時取消
            ////CL-K0035 新廠噴油部
            ////CL-K0036 江西廠噴油部
            //if (lbl_flag.Text == "CL-K0036" || lbl_flag.Text == "CL-K0035")
            //{
            //   xrPnl.Visible = true;               
            //}
            //else
            //{
            //   xrPnl.Visible = false;                
            //}
        }

        private void txtQc_dept_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GetCurrentColumnValue("qc_dept").ToString()))
            {
                txtQc_dept.Visible = false;               
            }
            else
            {
                txtQc_dept.Visible = true;              
            }            
        }

        private void xrLabel59_TextChanged(object sender, EventArgs e)
        {
            lblVendor.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("next_vendor_id").ToString()) ? false : true;            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            pnlQc.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("qc_dept").ToString()) ? false : true;
            pnlHold.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("flag_hold").ToString().Trim()) ? false : true;
            pnlShadingColor.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("shading_color").ToString().Trim()) ? false : true;

            //2026/07/01 Allen Leung
            string wp_id = GetCurrentColumnValue("out_dept").ToString();
            string next_wp_id = GetCurrentColumnValue("in_dept").ToString();
            string wh = "";
            if (next_wp_id.Substring(0, 1) == "8" || wp_id.Substring(0, 1) == "8" )
                wh = next_wp_id.Substring(0, 1) == "8" ? next_wp_id: wp_id ;
            else
                wh = "";
            if (wh == "")
                txtLocation.Text = "貨  架:";
            else
                txtLocation.Text = $"{wh}倉貨架:";
        }
    }
}
