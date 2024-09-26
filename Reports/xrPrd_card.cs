using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data;

namespace cf01.Reports
{
    public partial class xrPrd_card : DevExpress.XtraReports.UI.XtraReport
    {
        //private DataTable dtPOInfo = new DataTable();
        //private DataTable dtPartsInfo = new DataTable();
        public DataSet dsProduct = new DataSet();
        public xrPrd_card(DataSet dsRpt)
        {
            InitializeComponent();           
            dsProduct = dsRpt;
            //this.DataSource = dsProduct.Tables[0];            
            SetReportDataSource(dsProduct);            
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
      

        public void SetReportDataSource(DataSet reportData)
        {
            //因涉及到修改DataSet的内部属性，建议创建副本进行操作。
            DataSet ds = reportData.Copy();//创建副本
            //重要！！！给组(GroupHeader)绑定主键字段            
            GroupField gf = new GroupField("mo_id", XRColumnSortOrder.Ascending);
            GroupHeader1.GroupFields.Add(gf);


            //给数据集建立主外键关系          
            DataColumn parentColumn = ds.Tables[0].Columns["mo_id"];
            DataColumn childColumn = ds.Tables[1].Columns["mo_id"];           
            DataRelation R1 = new DataRelation("R1", parentColumn, childColumn);         
            ds.Relations.Add(R1);           

            //绑定主表的数据源            
            this.DataMember = ds.Tables[0].TableName;//表名
            this.DataSource = ds;
            lblNext_wp_id.DataBindings.Add("Text", ds.Tables[0], "next_wp_id");
            lblNext_wp_name.DataBindings.Add("Text", ds.Tables[0], "next_wp_name");
            lblSup_bom_no.DataBindings.Add("Text", ds.Tables[0], "sup_bom_no");            
            lblGoods_name.DataBindings.Add("Text", ds.Tables[0], "goods_name");
            lblMd_no.DataBindings.Add("Text", ds.Tables[0], "md_no");
            lblMd_no_ver.DataBindings.Add("Text", ds.Tables[0], "md_no_ver");         
            
            //绑定明细表的数据源
            this.DetailReport.DataMember = "R1";
            this.DetailReport.DataSource = ds;
            
            //自动绑定明细表XRLabel的数据源           
            //表格1
            lblProcess_group_id.DataBindings.Add("Text", ds, "R1.process_group_id");
            lblProcess_id.DataBindings.Add("Text", ds, "R1.process_id");
            lblCdesc.DataBindings.Add("Text", ds, "R1.cdesc");
            lblGrind_ratio.DataBindings.Add("Text", ds, "R1.grind_ratio");
            lblRotate_speed.DataBindings.Add("Text", ds, "R1.rotate_speed");
            lblMaterial.DataBindings.Add("Text", ds, "R1.material");
            lblGrind_time.DataBindings.Add("Text", ds, "R1.grind_time");
        }


    }
}
