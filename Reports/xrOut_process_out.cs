using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrOut_process_out : DevExpress.XtraReports.UI.XtraReport
    {
        public bool isShowPrice;
        public bool isShowPlateRemark;       
        public xrOut_process_out(bool is_show_price,bool is_show_plate_remark)
        {
            InitializeComponent();
            isShowPrice = is_show_price;
            isShowPlateRemark = is_show_plate_remark;           

            lblPack_num.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty.DataBindings.Add("Text", DataSource, "sec_qty");
            lblActual_prod_qty.DataBindings.Add("Text", DataSource, "actual_prod_qty");
            lblActual_sec_qty.DataBindings.Add("Text", DataSource, "actual_sec_qty");

            lblPackag_num_total.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty_total.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty_total.DataBindings.Add("Text", DataSource, "sec_qty");
            lblActual_prod_qty_total.DataBindings.Add("Text", DataSource, "actual_prod_qty");
            lblActual_sec_qty_total.DataBindings.Add("Text", DataSource, "actual_sec_qty");
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
            // 是否顯示單價
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
            // 是否顯示單價
            if (isShowPrice)
            {
                //lblSec_price.Visible = true;
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
            {
                lblSec_price.Visible = false;
            }
        }

        private void lblMould_fee_TextChanged(object sender, EventArgs e)
        {            
            // 是否顯示單價
            if (isShowPrice)
            {
                //lblMould_fee.Visible = true;
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
            {
                lblMould_fee.Visible = false;
            }
        }

        private void lblTotal_prices_TextChanged(object sender, EventArgs e)
        {            
            // 是否顯示單價
            if (isShowPrice)
            {
                //lblTotal_prices.Visible = true;
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
            {
                lblTotal_prices.Visible = false;
            }
        }

        private void lblPlateRemark_TextChanged(object sender, EventArgs e)
        {
            // 是否顯示電鍍備註
            if (isShowPlateRemark)
            {
                lblPlateRemark.Visible = true;                
            }
            else
            {
                lblPlateRemark.Visible = false;
            }
        }
        private void txtfl_by_TextChanged(object sender, EventArgs e)
        {
            if (txtfl_by.Text != "501")
            {
                //txtMo_id1.Visible = true;
                txtSeq.Visible = true;
                txtMo_id2.Visible = false;                            
            }
            else
            {
                //txtMo_id1.Visible = false;    
                txtSeq.Visible = false;
                txtMo_id2.Visible = true;                         
            }
        }

        private void xrOut_process_out_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (isDisplayPrice)
            //{
            //    lblPrice.Visible = true;
            //    lblSec_price.Visible = true;
            //    lblMould_fee.Visible = true;
            //    lblTotal_prices.Visible = true;
            //}
            //else
            //{
            //    lblPrice.Visible = false;
            //    lblSec_price.Visible = false;
            //    lblMould_fee.Visible = false;
            //    lblTotal_prices.Visible = false;
            //}
        }

        private void xrLabel7_TextChanged(object sender, EventArgs e)
        {
            if(xrLabel7.Text.Substring(1,3) != "510")
            {
                lbl501.Text = "電鍍備註";
            }else
            {
                lbl501.Text = "噴油備註";                
            }
        }

        private void txtColor_qty_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("id").ToString().Substring(1, 3) == "510")
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
      

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (GetCurrentColumnValue("dept_flag").ToString() == "LN")
            //{
            //    //下部是JX部門時字體加粗
            //    this.dept_flag.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //}
        }

        private void next_wp_id_TextChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("dept_flag").ToString() == "LN")
            {
                //下部是JX部門時字體加粗
                this.next_wp_id.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                this.next_wp_id.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Italic,System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strdate = GetCurrentColumnValue("issue_date").ToString();
            if (string.IsNullOrEmpty(strdate))
            {
                return;
            }
            xrLabel4.Text = DateTime.Parse(strdate).Date.ToString("yyyy/MM/dd");
        }

        private void xrLabel29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strdate = GetCurrentColumnValue("t_complete_date").ToString();
            if (string.IsNullOrEmpty(strdate))
            {
                return;
            }
            xrLabel29.Text = DateTime.Parse(strdate).Date.ToString("yyyy/MM/dd");
        }

        private void lblVendor_id_TextChanged(object sender, EventArgs e)
        {
            string strVendorId = GetCurrentColumnValue("vendor_id").ToString();
            if(!"CL-K0036,CL-K0035".Contains(strVendorId))
            {
                lblActual_prod_qty.Visible = true;
                lblActual_sec_qty.Visible = true;
                lblActual_prod_qty_total.Visible = true;
                lblActual_sec_qty_total.Visible = true;
                xrLine14.Visible = true;
                xrLine15.Visible = true;
            }
            else
            {
                lblActual_prod_qty.Visible = false;
                lblActual_sec_qty.Visible = false;
                lblActual_prod_qty_total.Visible = false;
                lblActual_sec_qty_total.Visible = false;
                xrLine14.Visible = false;
                xrLine15.Visible = false;
            }            
        }
    }
}
