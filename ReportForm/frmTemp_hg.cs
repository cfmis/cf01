using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmTemp_hg : Form
    {
        DataTable dtReport = new DataTable();
        
        public frmTemp_hg()
        {
            InitializeComponent();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {


            dtReport = clsPublicOfCF01.GetDataTable(
                @"SELECT id,po_no,vendor_id,vendor_name,mo_id,goods_name,color,qty,sec_qty,convert(varchar(10),con_date,120) as con_date 
                FROM temp_hg_plate order by id,mo_id");
            dgvhg.DataSource = dtReport;
            if (dtReport.Rows.Count == 0)
            {              
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          

        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //加載報表                
            cf01.Reports.xrhg_plate oRepot = new cf01.Reports.xrhg_plate() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
