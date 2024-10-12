using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrPackChanged_Cust : DevExpress.XtraReports.UI.XtraReport
    {
        public xrPackChanged_Cust()
        {
            InitializeComponent();
        }

        private void txtMo_id1_TextChanged(object sender, EventArgs e)
        {
            //是否顯示LOGO
            if (GetCurrentColumnValue("analysis_codes_1").ToString() == "1" || GetCurrentColumnValue("is_company_logo").ToString() == "1")
                p_cf_logo.Visible = true;
            else
                p_cf_logo.Visible = false;

            bool Flag;
            if (GetCurrentColumnValue("print_eng_text").ToString() == "0")//客人標簽顯示中文界面     
                Flag = true;
            else
                Flag = false;
            Display_cn_en(Flag);
        }

        private void Display_cn_en(bool flag)
        {
            //true 顯示中文界面
            lblgoods_name.Visible = flag;
            lblgoods_name_en.Visible = !flag;
            txtGoods_name.Visible = flag;
            txtGoods_name_en.Visible = !flag;

            lblColor.Visible = flag;
            lblColor_en.Visible = !flag;
            txtCF_color.Visible = flag;
            txtCF_color_en.Visible = !flag;

            lblCust_name.Visible = flag;
            lblCust_name_en.Visible = !flag;
            txt_Cust_name.Visible = flag;
            txt_Cust_name_en.Visible = !flag;

            lblPO.Visible = flag;
            lblPO_en.Visible = !flag;

            lblCust_goods_id.Visible = flag;
            lblCust_goods_id_en.Visible = !flag;

            lblCust_goods_name.Visible = flag;
            lblCust_goods_name_en.Visible = !flag;

            lblCust_color.Visible = flag;
            lblCust_color_en.Visible = !flag;

            lblStyle_no.Visible = flag;
            lblStyle_no_en.Visible = !flag;

            lblSize.Visible = flag;
            lblSize_en.Visible = !flag;

            lblMo.Visible = flag;
            lblMo_en.Visible = !flag;

            lblQty.Visible = flag;
            lblQty_en.Visible = !flag;

            lblRemark.Visible = flag;
            lblRemark_en.Visible = !flag;
        }

        private void xrPictureBox3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage(xrPictureBox3);
        }

        private void BindImage(XRPictureBox pict)
        {
            string strFile = GetCurrentColumnValue("picture_name").ToString();
            if (!string.IsNullOrEmpty(strFile))
            {
                if (System.IO.File.Exists(strFile))
                    pict.ImageUrl = strFile;
                else
                    pict.ImageUrl = null;
            }
            else
                pict.ImageUrl = null;
        } 
    }
}
