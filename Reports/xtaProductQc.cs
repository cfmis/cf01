using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;


namespace cf01.Reports
{
    public partial class xtaProductQc : DevExpress.XtraReports.UI.XtraReport
    {
       private DataTable dtQC = new DataTable();
        public xtaProductQc(DataTable pdtQc)
        {
            InitializeComponent();
            dtQC = pdtQc;

            BindCheckBox();
        }
        
        private void BindCheckBox()
        {
            this.DataSource=dtQC;
            for (int i = 0; i < dtQC.Rows.Count; i++)
            {
                xrckb_Qc_ok.Checked = Convert.ToBoolean(dtQC.Rows[i]["qc_ok"]);
                xrckb_Qc_ng.Checked = Convert.ToBoolean(dtQC.Rows[i]["qc_no_ok"]);
            }

            //
            //www.cnblogs.com/whlalhj/archive/2010/01/20/1652338.html
        }






       
    }
}
