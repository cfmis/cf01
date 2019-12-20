using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrAlloyQuotation : XtraReport
    {
        public xrAlloyQuotation()
        {
            InitializeComponent();

            lblprod_qty.DataBindings.Add("Text", DataSource, "prod_qty");//小計欄位需這樣綁定
            lblcost_total.DataBindings.Add("Text", DataSource, "cost_total");
            lblcost_mould.DataBindings.Add("Text", DataSource, "cost_mould");

            lblprod_qty_sum.DataBindings.Add("Text", DataSource, "prod_qty");//小計欄位需這樣綁定
            lblcost_total_sum.DataBindings.Add("Text", DataSource, "cost_total");
            lblcost_mould_sum.DataBindings.Add("Text", DataSource, "cost_mould");
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("date_quotation", XRColumnSortOrder.Ascending), new GroupField("company", XRColumnSortOrder.Ascending) });
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
                    xrPictureBox1.ImageUrl = null;
                }
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }            
        }

        private void lblcost_mould_TextChanged(object sender, EventArgs e)
        {
            if (lblcost_mould.Text == "0")
            {
                lblcost_mould.Visible = false;
            }
            else
            {
                lblcost_mould.Visible = true;
            }
        }

        private void lblProd_weight_TextChanged(object sender, EventArgs e)
        {

            if (lblProd_weight.Text == "0.00")
            {
                lblProd_weight.Visible = false;
            }
            else
            {
                lblProd_weight.Visible = true;
            }
        }

       
     

    }
}
