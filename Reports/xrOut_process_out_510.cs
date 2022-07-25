using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrOut_process_out_510 : DevExpress.XtraReports.UI.XtraReport
    {
        private bool isShowPrice;
        private bool isShowColorQty;
        public xrOut_process_out_510(bool is_show_price,bool is_show_color_qty)
        {
            InitializeComponent();
            isShowPrice = is_show_price;
            isShowColorQty = is_show_color_qty;
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
            if (isShowPrice)
            {
                //lblPrice.Visible = true;
                if (lblPrice.Text == "0")
                {
                    lblPrice.Visible = false;
                }
                else
                {
                    lblPrice.Visible = true;
                }
            }
            else
            {
                lblPrice.Visible = false;
            }
        }

        private void lblSec_price_TextChanged(object sender, EventArgs e)
        {
            if (isShowPrice)
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
            else
                lblSec_price.Visible = false;
        }

        private void lblMould_fee_TextChanged(object sender, EventArgs e)
        {
            if (isShowPrice)
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
            else
                lblMould_fee.Visible = false;
        }

        private void lblTotal_prices_TextChanged(object sender, EventArgs e)
        {
            if (isShowPrice)
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
            else
                lblTotal_prices.Visible = false;
        }

        private void txtfl_by_TextChanged(object sender, EventArgs e)
        {
            if (txtfl_by.Text == "501")
            {
                //string strid = xrLabel7.Text.Substring(5,7);
                //string strrmk = GetCurrentColumnValue("process_request").ToString();
                //if(strrmk.Length>=3)
                //    strrmk = strrmk.Substring(0, 3);                 
                
                txtMo_id1.Visible = false;      
                txtMo_id2.Visible = true;
                txtMo_id3.Visible = true;
            }
            else
            {
                txtMo_id1.Visible = true;
                txtMo_id2.Visible = false;
                txtMo_id3.Visible = false;
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

        private void txtColor_qty_TextChanged(object sender, EventArgs e)
        {
            if (isShowColorQty)
            {
                if (GetCurrentColumnValue("color_qty").ToString() != "0")
                {
                    txtColor_qty.Visible = true;
                }
                else
                {
                    txtColor_qty.Visible = false;
                }
            }
            else
            {
                txtColor_qty.Visible = false;
            }
            
        }
    }
}
