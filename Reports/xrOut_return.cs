﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrOut_return : DevExpress.XtraReports.UI.XtraReport
    {
        public xrOut_return()
        {
            InitializeComponent();            
            lblPack_num.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty.DataBindings.Add("Text", DataSource, "t_ir_qty");
            lblSec_qty.DataBindings.Add("Text", DataSource, "sec_qty");
            lblPackag_num_total.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty_total.DataBindings.Add("Text", DataSource, "t_ir_qty");
            lblSec_qty_total.DataBindings.Add("Text", DataSource, "sec_qty");
        }

        void BindImage(string pFile)
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
                    xrPictureBox1.ImageUrl = null ;
                }
            }
            else
            {
                xrPictureBox1.ImageUrl = null ;
            }
            // BindImage();
            //  GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("page_num", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
        }    
              

        private void lblOp_price_TextChanged(object sender, EventArgs e)
        {
            if (lblOp_price.Text == "0")
            {
                lblOp_price.Visible = false;
            }
            else
            {
                lblOp_price.Visible = true;
            }
        }

        private void xrLabel7_TextChanged(object sender, EventArgs e)
        {
            if (xrLabel7.Text.Substring(1, 3) != "510")
            {
                lbl501.Text = "電鍍備註";
            }
            else
            {
                lbl501.Text = "噴油備註";
            }
        }
    }
}
