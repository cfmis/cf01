using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using cf01.CLS;


namespace cf01.Reports
{
    public partial class xrQcTestReport : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet dtsAll = new DataSet();        
        DataTable dtMostly = new DataTable();
        DataTable dtDetails1 = new DataTable();
        DataTable dtDetails2 = new DataTable();
        readonly DevExpress.XtraPrinting.PaddingInfo m_padLeft = new DevExpress.XtraPrinting.PaddingInfo() { Left = 15 };

        public xrQcTestReport(DataSet ds)
        {
            InitializeComponent();
            dtsAll = ds;            
            dtMostly = dtsAll.Tables[0];
            dtDetails1 = dtsAll.Tables[1];            
            dtDetails2 = dtsAll.Tables[2];

            //绑定主表    
            this.DataSource = dtMostly;
            BindDetails_1();
            BindDetails_2();            
        }
    
        //public void SetReportDataSource(DataSet dts_report)
        //{
        //    DataSet dts = dts_report.Copy();//创建副本
        //    GroupField gf = new GroupField("id", XRColumnSortOrder.Ascending);
        //    GroupHeader1.GroupFields.Add(gf);

        //    //给数据集建立主外键关系
        //    DataColumn parentColumn = dts.Tables["dtMostly"].Columns["id"];
        //    DataColumn childColumn1 = dts.Tables["dtDetails1"].Columns["id"];
        //    DataColumn childColumn2 = dts.Tables["dtDetails2"].Columns["id"];
        //    DataRelation R1 = new DataRelation("R1", parentColumn, childColumn1);
        //    DataRelation R2 = new DataRelation("R2", parentColumn, childColumn2);
        //    dts.Relations.Add(R1);
        //    dts.Relations.Add(R2);
            
        //    this.DataMember = "dtMostly";
        //    this.DataSource = dts;

        //    //绑定明细表的数据源
        //    this.DetailReport.DataMember = "R2";
        //    this.DetailReport.DataSource = dts;

        //}

        
        private void BindDetails_1()
        {           
            //xrTable1.Rows.Clear();
            ////綁定單元格第一行（表頭）
            //XRTableCell ltc1 = new XRTableCell() { WidthF = 590, Text = "項目/Item List" };
            //XRTableCell ltc2 = new XRTableCell() { WidthF = 1326, Text = "內容/Comments" };                   
            //XRTableRow tr0 = new XRTableRow();
            //tr0.Cells.AddRange(new XRTableCell[] { ltc1, ltc2 });
            //tr0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //tr0.Font = new Font("Arial", 10F, ((FontStyle)((FontStyle.Bold))), GraphicsUnit.Point, ((byte)(0)));
            //tr0.Borders = DevExpress.XtraPrinting.BorderSide.All;
            //xrTable1.Rows.Add(tr0);
            //tr0.BackColor = Color.LightGray;           
            xrTable2.Rows.Clear();                       
            for (int i = 0; i < dtDetails1.Rows.Count; i++)
            {               
                //綁定單元格 
                XRTableCell ltc_item_no = new XRTableCell()
                {
                    WidthF = 590,
                    Text = dtDetails1.Rows[i]["item_no"].ToString()+"                     "
                };
                XRTableCell ltc_contents = new XRTableCell() {
                    WidthF = 1326,                
                    Text = dtDetails1.Rows[i]["contents"].ToString()                     
                };
                
                XRTableRow tr = new XRTableRow();
                tr.Font = new Font("Arial", 10F);                
                tr.Cells.AddRange(new XRTableCell[] { ltc_item_no, ltc_contents});
                tr.Borders = DevExpress.XtraPrinting.BorderSide.All;
                tr.Padding = m_padLeft;
                xrTable2.Rows.Add(tr);
            }                   
        }

        private void BindDetails_2()
        {            
            ////綁定單元格第一行（表頭）
            //string ss = "測試項目" + "\n\r\n\r" + "Testing Item";
            //XRTableCell ltc1 = new XRTableCell() { WidthF = 500, Text = ss};
            //XRTableCell ltc2 = new XRTableCell() { WidthF = 700, Text = "測試方法和要求/Testing methond & Requirement" };
            //XRTableCell ltc3 = new XRTableCell() { WidthF = 200, Text = "測試成績/Test Result" };
            //XRTableCell ltc4 = new XRTableCell() { WidthF = 150, Text = "評定/Appraise" };
           
            
            //XRTableRow tr0 = new XRTableRow();
            //tr0.Cells.AddRange(new XRTableCell[] { ltc1, ltc2, ltc3, ltc4 });
            //tr0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //tr0.Font = new Font("Arial", 9F, ((FontStyle)((FontStyle.Bold))), GraphicsUnit.Point, ((byte)(0)));
            //tr0.Borders = DevExpress.XtraPrinting.BorderSide.All;
            //xrTable2.Rows.Add(tr0);
            //tr0.BackColor = Color.LightGray;            
            xrTable4.Rows.Clear();
            for (int i = 0; i < dtDetails2.Rows.Count; i++)
            {
                //綁定單元格
                XRTableCell ltc_test_item_id = new XRTableCell()
                {
                     WidthF = 590,                    
                    Text = dtDetails2.Rows[i]["test_item_id"].ToString()
                };
                XRTableCell ltc_test_require = new XRTableCell()
                {
                    WidthF = 753,                     
                    Text = dtDetails2.Rows[i]["test_require"].ToString()
                };
                XRTableCell ltc_test_result = new XRTableCell()
                {
                    WidthF = 375,                  
                    Text = dtDetails2.Rows[i]["test_result"].ToString()
                };
                XRTableCell ltc_test_is_pass = new XRTableCell()
                {
                    WidthF = 198,
                    Text = dtDetails2.Rows[i]["test_is_pass"].ToString() == "True" ? "Pass" : "Fail",
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
