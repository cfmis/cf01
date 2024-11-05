using System;
using DevExpress.XtraReports.UI;
using System.Data;

namespace cf01.Reports
{
    public partial class xrFullCheck : DevExpress.XtraReports.UI.XtraReport
    {
        public xrFullCheck()
        {
            InitializeComponent();
            SetGroup();
        }

        
        public void SetGroup()
        {    
            //重要！！！给组(GroupHeader)绑定要分組的字段 
            GroupField gf = new GroupField("mo_id", XRColumnSortOrder.Ascending); //排序的問題20170517更改
            GroupHeader1.GroupFields.Add(gf); 
          

            
        }

        

      
    }
}
