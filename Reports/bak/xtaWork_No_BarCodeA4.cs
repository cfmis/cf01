﻿using cf01.CLS;
using System;
using System.IO;
namespace cf01.Reports
{
    public partial class xtaWork_No_BarCodeA4 : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWork_No_BarCodeA4()
        {
            InitializeComponent();
        }

        void BindImage()
        { 
            string art_path = "";
            clsPublicOfGEO clsConErp = new clsPublicOfGEO();
            art_path = clsConErp.getErpImagePath() + GetCurrentColumnValue("picture_name");           
            if (File.Exists(art_path))
            {
                xrPictureBox1.ImageUrl = art_path;
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }

        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();
        }

        private void xtaWork_No_BarCodeA4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string per_qty = GetCurrentColumnValue("per_qty").ToString();
            if (string.IsNullOrEmpty(per_qty))
            {
                per_qty = "0";
            }
            per_qty = per_qty.Replace(",", "");            
            if (Int32.Parse(per_qty) == 0)
            {
               lblper_qty.Text = GetCurrentColumnValue("prod_qty").ToString();
            }
          
            //net_weight
        }

        private void lblnet_weight_TextChanged(object sender, EventArgs e)
        {
            if (lblnet_weight.Text == "0.0")
            {
                lblnet_weight.Visible = false;
            }
            else
            {
                lblnet_weight.Visible = true;
            }
        }      

        private void xrLabel25_TextChanged(object sender, EventArgs e)
        {
            //start 2023/10/06 
            string qty_remaining = GetCurrentColumnValue("qty_remaining").ToString();
            if (string.IsNullOrEmpty(qty_remaining))
            {
                qty_remaining = "0";
            }
            int page_num = int.Parse(GetCurrentColumnValue("page_num").ToString());
            int total_page = int.Parse(GetCurrentColumnValue("total_page").ToString());
            qty_remaining = qty_remaining.Replace(",", "");
            if (Int32.Parse(qty_remaining) > 0 && page_num == total_page)
            {
                lblper_qty.Text = GetCurrentColumnValue("qty_remaining").ToString();
            }
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
    }
}
