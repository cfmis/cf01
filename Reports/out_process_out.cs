using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class out_process_out : DevExpress.XtraReports.UI.XtraReport
    {
        public out_process_out()
        {
            InitializeComponent();            
            lblPack_num.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty.DataBindings.Add("Text", DataSource, "sec_qty");
            lblPackag_num_total.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty_total.DataBindings.Add("Text", DataSource, "prod_qty");
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
         
        private void lblGet_color_sample_TextChanged(object sender, EventArgs e)
        {
            //首先設置要隱藏對象的Visible爲 false;
            if (lblGet_color_sample.Text == "生產部")
            {
                lblColor.Visible = true;
                lblGet_color_sample.Visible = true;
            }
            else
            {
                lblColor.Visible = false;
                lblGet_color_sample.Visible = false;
            }
        }

        private void lblPrice_TextChanged(object sender, EventArgs e)
        {
            if (lblPrice.Text == "0")
            {
                lblPrice.Visible = false;
            }
            else
            {
                lblPrice.Visible = true ;     
            }
        }

        private void lblSec_price_TextChanged(object sender, EventArgs e)
        {
            if (lblSec_price.Text == "0")
            {
                lblSec_price.Visible = false;
            }
            else
            {
                lblSec_price.Visible = true;
            }
        }

        private void lblMould_fee_TextChanged(object sender, EventArgs e)
        {
            if (lblMould_fee.Text == "0")
            {
                lblMould_fee.Visible = false;
            }
            else
            {
                lblMould_fee.Visible = true;
            }
        }

        private void lblTotal_prices_TextChanged(object sender, EventArgs e)
        {
            if (lblTotal_prices.Text == "0")
            {
                lblTotal_prices.Visible = false;
            }
            else
            {
                lblTotal_prices.Visible = true;
            }
        }

    }
}
