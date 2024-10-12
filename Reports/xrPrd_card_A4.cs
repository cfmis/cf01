using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data;

namespace cf01.Reports
{
    public partial class xrPrd_card_A4 : DevExpress.XtraReports.UI.XtraReport
    {       
        public xrPrd_card_A4()
        {
            InitializeComponent();         
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
      

        public void SetReportDataSource()
        {
            //因涉及到修改DataSet的内部属性，建议创建副本进行操作。
           // DataSet ds = reportData.Copy();//创建副本
            //重要！！！给组(GroupHeader)绑定主键字段            
            GroupField gf = new GroupField("id"+"mo_id"+"goods_id", XRColumnSortOrder.Ascending);
            GroupHeader1.GroupFields.Add(gf);
        }


        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] 
            { new GroupField("id", XRColumnSortOrder.Ascending),
              new GroupField("mo_id", XRColumnSortOrder.Ascending),
              new GroupField("goods_id", XRColumnSortOrder.Ascending),
            });
            
        }


    }
}
