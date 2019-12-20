using System;
using DevExpress.XtraReports.UI;
using System.Data;



namespace cf01.Reports
{
    public partial class xrQcTestReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet dtsAll = new DataSet(); 
        readonly DevExpress.XtraPrinting.PaddingInfo m_padLeft = new DevExpress.XtraPrinting.PaddingInfo() { Left = 15 };
        public xrQcTestReport1(DataSet ds)
        {
            InitializeComponent();
            SetReportDataSource(ds);
            BindDetails();              
        }

        public void SetReportDataSource(DataSet reportData)
        {
            dtsAll = reportData.Copy();//创建副本
            dtsAll.Tables[0].TableName = "dtMostly";
            dtsAll.Tables[1].TableName = "dtDetails1";
     
            //重要！！！给组(GroupHeader)绑定主键字段
            //本报表是按业务单号分组
            GroupField gf = new GroupField("id", XRColumnSortOrder.Ascending);
            GroupHeader1.GroupFields.Add(gf);

            //给数据集建立主外键关系
            DataColumn parentColumn = dtsAll.Tables["dtMostly"].Columns["id"];
            DataColumn childColumn1 = dtsAll.Tables["dtDetails1"].Columns["id"];
            DataRelation R1 = new DataRelation("R1", parentColumn, childColumn1);
            dtsAll.Relations.Add(R1);
          
            //绑定主表的数据源
            this.DataMember = "dtMostly";
            this.DataSource = dtsAll;

            //绑定明细表的数据源
            this.DetailReport.DataMember = "R1";
            this.DetailReport.DataSource = dtsAll;
            lblitem_no.DataBindings.Add("Text", dtsAll, "R1.item_no");
            lblcontents.DataBindings.Add("Text", dtsAll, "R1.contents");
                        
        }

        private void BindDetails()
        {               
            xrTable4.Rows.Clear();
            for (int i = 0; i < dtsAll.Tables["dtDetails2"].Rows.Count; i++)
            {
                //綁定單元格
                XRTableCell ltc_test_item_id = new XRTableCell()
                {
                    WidthF = 590,
                    Text = dtsAll.Tables["dtDetails2"].Rows[i]["test_item_id"].ToString()
                };
                XRTableCell ltc_test_require = new XRTableCell()
                {
                    WidthF = 819,
                    Text = dtsAll.Tables["dtDetails2"].Rows[i]["test_require"].ToString()
                };
                XRTableCell ltc_test_result = new XRTableCell()
                {
                    WidthF = 338,
                    Text = dtsAll.Tables["dtDetails2"].Rows[i]["test_result"].ToString()
                };
                XRTableCell ltc_test_is_pass = new XRTableCell()
                {
                    WidthF = 180,
                    Text = dtsAll.Tables["dtDetails2"].Rows[i]["test_is_pass"].ToString() == "True" ? "Pass" : "Fail",
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                };

                XRTableRow tr = new XRTableRow();
                tr.Cells.AddRange(new XRTableCell[] { ltc_test_item_id, ltc_test_require, ltc_test_result, ltc_test_is_pass });
                tr.Borders = DevExpress.XtraPrinting.BorderSide.All;
                tr.Padding = m_padLeft;
                xrTable4.Rows.Add(tr);

                //if (i % 2 != 0)
                //{
                //    tr.BackColor = Color.LightGray;
                //}
            }

        }

    

    }
}
