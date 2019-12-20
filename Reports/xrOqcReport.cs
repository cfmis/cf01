using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using cf01.ReportForm;
using System.Data;

namespace cf01.Reports
{
    public partial class xrOqcReport : DevExpress.XtraReports.UI.XtraReport
    {       
        public xrOqcReport(DataSet dts)
        {
            InitializeComponent();           
            SetReportDataSource(dts);
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
            DataColumn childColumn1 = ds.Tables[2].Columns["mo_id"];
            DataRelation R1 = new DataRelation("R1", parentColumn, childColumn);
            DataRelation R2 = new DataRelation("R2", parentColumn, childColumn1);
            ds.Relations.Add(R1);
            ds.Relations.Add(R2);

            //绑定主表的数据源            
            this.DataMember = ds.Tables[0].TableName;//表名
            this.DataSource = ds;
            chkSampling.DataBindings.Add("Checked", ds.Tables[0], "sampling");
            chkAll_inspection.DataBindings.Add("Checked", ds.Tables[0], "all_inspection");
            chkReinspection.DataBindings.Add("Checked", ds.Tables[0], "reinspection");
            chkQualified.DataBindings.Add("Checked", ds.Tables[0], "qualified");
            chkUnqualified_final.DataBindings.Add("Checked", ds.Tables[0], "unqualified_final");
            
            //绑定明细表的数据源
            this.DetailReport.DataMember = "R1";
            this.DetailReport.DataSource = ds;

            this.DetailReport1.DataMember = "R2";
            this.DetailReport1.DataSource = ds;

            //自动绑定明细表XRLabel的数据源           
            //表格1
            lbl1Seq.DataBindings.Add("Text",ds, "R1.seq");
            lbl1Item.DataBindings.Add("Text", ds, "R1.item");
            lbl1Standard.DataBindings.Add("Text", ds, "R1.standard");
            lbl1Result.DataBindings.Add("Text",ds,"R1.result");
            lbl1Remark.DataBindings.Add("Text",ds,"R1.remark");
            //表格2
            lbl2Seq.DataBindings.Add("Text", ds, "R2.seq");
            lbl2Item.DataBindings.Add("Text", ds, "R2.item");
            lbl2Tool.DataBindings.Add("Text", ds, "R2.tool");
            lbl2mresult1.DataBindings.Add("Text", ds, "R2.m_result_1");
            lbl2mresult2.DataBindings.Add("Text", ds, "R2.m_result_2");
            lbl2mresult3.DataBindings.Add("Text", ds, "R2.m_result_3");
            lbl2mresult4.DataBindings.Add("Text", ds, "R2.m_result_4");
            lbl2mresult5.DataBindings.Add("Text", ds, "R2.m_result_5");
            lbl2mresult6.DataBindings.Add("Text", ds, "R2.m_result_6");
            lbl2mresult7.DataBindings.Add("Text", ds, "R2.m_result_7");
            lbl2mresult8.DataBindings.Add("Text", ds, "R2.m_result_8");
            chk2Qualified.DataBindings.Add("Checked", ds, "R2.Qualified");
            chk2Unqualified.DataBindings.Add("Checked", ds, "R2.unqualified");
            lbl2Remark.DataBindings.Add("Text", ds, "R2.remark");
        }
     
    }
}
