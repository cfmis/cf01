using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrSoEnglish : DevExpress.XtraReports.UI.XtraReport
    {
        decimal totalSum = 0;
        decimal totalDiscAmt = 0;
        public xrSoEnglish(decimal total_sum,decimal disc_amt)
        {
            InitializeComponent();

            totalSum = total_sum;
            totalDiscAmt = disc_amt;
            txtTotalSum.DataBindings.Add("Text", DataSource, "total_sum"); //明細綁定
            txtTotalSumEnd.DataBindings.Add("Text", DataSource, "total_sum");  //小計總金額綁定
        }        

        void BindImage(string pFile)
        {
            xrPictureBox2.ImageUrl = pFile;
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                    xrPictureBox2.ImageUrl = null;
                }
            }
            else
            {
                xrPictureBox2.ImageUrl = null;
            }
        }

        private void txtCustomer_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string itCustomer = GetCurrentColumnValue("it_customer").ToString();
            string name = GetCurrentColumnValue("english_customer_name").ToString();
            switch (itCustomer)
            {
                case "DO-S0505":
                    name = name.Replace("(for Sample order only)", "") + "(" + itCustomer.Trim() + ")";
                    break;
                case "DO-S0228":
                    name = name.Trim();
                    break;
                default:
                    name = name.Trim() + "(" + itCustomer.Trim() + ")";
                    break;
            }
            txtCustomer.Text = name;            
        }

        private void txtUnitPrice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal unitPrice = decimal.Parse(GetCurrentColumnValue("unit_price").ToString());
            txtUnitPrice.Text = string.Format("{0:N4}", unitPrice);
        }

        private void txtOrderQty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal orderQty = decimal.Parse(GetCurrentColumnValue("order_qty").ToString());
            txtOrderQty.Text = string.Format("{0:N0}", orderQty);
        }

        private void txtDiscRate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string disc_rate = GetCurrentColumnValue("disc_rate").ToString();
            if (string.IsNullOrEmpty(disc_rate))
            {
                txtDiscRate.Text = "";
            }
            else
            {
                decimal discRate = decimal.Parse(disc_rate);
                if (discRate > 0)
                {
                    txtDiscRate.Text = string.Format("{0:N2}", discRate);
                }
                else
                {
                    txtDiscRate.Text = "";
                }
            }           
        }

        private void txtTotalSum_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal totalSum = decimal.Parse(GetCurrentColumnValue("total_sum").ToString());
            txtTotalSum.Text = string.Format("{0:N2}", totalSum);
        }

        private void txtCustomerColorId_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string itCustomer = GetCurrentColumnValue("it_customer").ToString();
            string goodsId = GetCurrentColumnValue("goods_id").ToString();
            if(itCustomer== "DU-G0002" && goodsId.Substring(0, 2) == "F0")
            {
                txtCustomerColorId.Visible = false;
            }
            else
            {
                txtCustomerColorId.Visible = true;
            }
        }

        private void txtCol_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string itCustomer = GetCurrentColumnValue("it_customer").ToString();
            string goodsId = GetCurrentColumnValue("goods_id").ToString();
            if(string.IsNullOrEmpty(itCustomer) || (itCustomer== "DU-G0002" && goodsId.Substring(0, 2) == "F0"))
            {
                txtCol.Visible = false;
            }
            else
            {
                txtCol.Visible = true;
            }          
        }

        private void SetDiscount()
        {
            //原金額
            //decimal goodsSum = decimal.Parse(GetCurrentColumnValue("goods_sum").ToString());            
            txtTotalSum_sum.Text = string.Format("{0:N2}", totalSum + totalDiscAmt);  //"{0:N2}"
            //折扣額
            //decimal disc_amt = decimal.Parse(txtDiscAmt_sum.Text);             
            txtDiscAmt_sum.Text = string.Format("{0:N2}", totalDiscAmt);  //{0:##,###,#00.00}
            pnlDiscount.Visible = (totalDiscAmt <= 0)? false : true;            
        }

        private void xrSoEnglish_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("p_key", XRColumnSortOrder.Ascending) });
            SetDiscount();
        }

        private void txtSign_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sellerId = GetCurrentColumnValue("seller_id").ToString(); 
            string agent = GetCurrentColumnValue("agent").ToString();
            string brandId = GetCurrentColumnValue("brand_id").ToString();
            agent = string.IsNullOrEmpty(agent) ? "" : "/" + agent;           
            brandId = string.IsNullOrEmpty(brandId) ? "" : "/" + brandId;
            txtSign.Text = sellerId + agent + brandId;
        }
     
    }
}
