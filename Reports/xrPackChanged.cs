using System;
using DevExpress.XtraReports.UI;
using System.Data;

namespace cf01.Reports
{
    public partial class xrPackChanged : DevExpress.XtraReports.UI.XtraReport
    {
        public xrPackChanged(DataSet dsPack,DataTable dtList)
        {
            InitializeComponent();
           // dsPack.Tables["pack_h"].DefaultView.Sort = "seq ASC";

            DataSet dsReprot = new DataSet();
            dsReprot = dsPack;
            DataTable dt = dtList.Copy();
            dsReprot.Tables.Add(dt);//建立關系用到的從表
           // dsReprot.Tables[2].TableName = "pack_list";   
            dsReprot.Tables[3].TableName = "pack_list";

            SetReportDataSource(dsReprot);
        }

        /// <summary>
        /// 设置主从表的数据源
        /// </summary>
        /// <param name="reportData"></param>
        public void SetReportDataSource(DataSet reportData)
        {
            //因涉及到修改DataSet的内部属性，建议创建副本进行操作。
            DataSet ds = reportData.Copy();//创建副本

            //重要！！！给组(GroupHeader)绑定要分組的字段            
            //GroupField gf = new GroupField("pkey", XRColumnSortOrder.Ascending);           
            GroupField gf = new GroupField("id_seq", XRColumnSortOrder.Ascending); //排序的問題20170517更改
            GroupHeader1.GroupFields.Add(gf);           
          

            //给数据集建立主外键关系
            DataColumn parentColumn = ds.Tables["pack_h"].Columns["pkey"];
            DataColumn childColumn = ds.Tables["pack_list"].Columns["pkey"];
            DataRelation R1 = new DataRelation("R1", parentColumn, childColumn);
            ds.Relations.Add(R1);

            //绑定主表的数据源
            //ds.Tables["pack_h"].DefaultView.Sort = "pkey ASC";//**********            
            this.DataMember = "pack_h";
            this.DataSource = ds;
            

            //绑定明细表的数据源
            this.DetailReport.DataMember = "R1";
            this.DetailReport.DataSource = ds;

            //自动绑定明细表XRLabel的数据源            
            d_goods_id.DataBindings.Add("Text", ds, "R1.goods_id");
            d_department.DataBindings.Add("Text", ds, "R1.department");
            d_order_qty.DataBindings.Add("Text", ds, "R1.order_qty");
            d_name.DataBindings.Add("Text", ds, "R1.name");

            //xrLabel15.DataBindings.Add("Text", ds, "R1.Amount");//绑定小计(当前单据的总金额)
            //xrLabel23.DataBindings.Add("Text", ds, "R1.Amount");//绑定总计(所有单据的总金额)
        }

        private void txtMo_id_TextChanged(object sender, EventArgs e)
        {
            string strShow_flag = GetCurrentColumnValue("show_flag").ToString();
            if (string.IsNullOrEmpty(strShow_flag) || strShow_flag == "0")                           
                lblDG_D.Visible = false;            
            else            
                lblDG_D.Visible = true;
            
            //是否顯示LOGO
            if(GetCurrentColumnValue("analysis_codes_1").ToString()=="1" || GetCurrentColumnValue("is_company_logo").ToString()=="1")            
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

        /// <summary>
        /// true 顯示中文,false 顯示英文
        /// </summary>
        /// <param name="flag"></param>
        private void Display_cn_en(bool flag)
        {
            //true 顯示中文界面
            lblgoods_name.Visible = flag ;
            lblgoods_name_en.Visible = !flag;
            txtGoods_name.Visible = flag;
            txtGoods_name_en.Visible = !flag;

            lblColor.Visible = flag;
            lblColor_en.Visible = !flag;
            txtCF_color.Visible = flag;
            txtCF_color_en.Visible = !flag;

            lblCust_name.Visible =flag;
            lblCust_name_en.Visible = !flag;                
            txt_Cust_name.Visible = flag;
            txt_Cust_name_en.Visible = !flag;

            lblPO.Visible = flag;
            lblPO_en.Visible = !flag;
                
            lblCust_goods_id.Visible =flag ;
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

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage(xrPictureBox1);           
        }

        private void xrPictureBox3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage(xrPictureBox3);
        }

        private void xrLabel10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strdate = GetCurrentColumnValue("transfer_date").ToString();
            if(string.IsNullOrEmpty(strdate))
            {
                return;
            }
            xrLabel10.Text = DateTime.Parse(strdate).Date.ToString("yyyy/MM/dd");
        }

        private void lblShippmark_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //2025/11/20 DL-C0191客戶所有訂單全部顯示：箱內要放船頭辦
            string CustID = GetCurrentColumnValue("it_customer").ToString();
            lblShippmark.Visible = (CustID == "DL-C0191") ? true : false;
            
            //-- start 2025/11/20 cancel PO：6629開頭的顯示：箱內要放船頭辦
            //string shippMark = GetCurrentColumnValue("contract_cid").ToString();
            //string salesGroup = GetCurrentColumnValue("group_number").ToString();
            //shippMark = string.IsNullOrEmpty(shippMark) ? "" : shippMark.Trim();
            //salesGroup = string.IsNullOrEmpty(salesGroup) ? "" : salesGroup;
            //if(shippMark.Length>=4)
            //{
            //    if (shippMark.Substring(0, 4) == "6629" && salesGroup == "1S")
            //        lblShippmark.Visible = true;
            //    else
            //        lblShippmark.Visible = false;
            //}
            //else
            //    lblShippmark.Visible = false;
            //-- end
        }
    }
}
