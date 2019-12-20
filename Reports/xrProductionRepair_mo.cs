using System;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrProductionRepair_mo : DevExpress.XtraReports.UI.XtraReport
    {      
        public xrProductionRepair_mo()
        {           
            InitializeComponent(); 
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("mo_id_seq_id", XRColumnSortOrder.Ascending) });
            
        }

      
    }
}
