using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;
using System.Threading;
using cf01.Forms;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmOcSummary: Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private DataTable dtReport = new DataTable();       
        private DataSet dsReport = new DataSet();
        private clsAppPublic clsApp = new clsAppPublic();

        public frmOcSummary()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOcSummary_Load(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(txtDat1.Text))
            {
                txtDat1.EditValue = DateTime.Now.AddDays(-1);
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now;
            }            
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtDat2.Focus();
            if (txtDat1.Text == "")
            {
                MessageBox.Show("開始日期不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDat1.Focus();
                return;
            }

            if (txtDat1.Text == "" && txtDat2.Text == "" )
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter("@date1", txtDat1.Text),
                new SqlParameter("@date2",  txtDat2.Text)
            };

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //dtReport = clsConErp.ExecuteProcedureReturnTable("z_rpt_oc_summary", paras);
            dsReport = clsConErp.ExecuteProcedureReturnDataSet("z_rpt_oc_summary", paras, null);
            dtReport = dsReport.Tables[0];

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            dgvDetails.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < this.dgvDetails.Columns.Count; i++)
                {
                    this.dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;                    
                }
            }
            else
            {
                dtReport.Clear();          
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
            cf01.Reports.xrPlateSelect oRepot = new cf01.Reports.xrPlateSelect() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDat1.Text) && string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = txtDat1.EditValue;
            }
        }
  

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }     
            Excel();
        }

        private void Print() //通用的打印方法
        {
            if (dgvDetails.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvDetails);
            }
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                //ExpToExcel.DataGridViewToExcel(dgvDetails);
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        private void btnNotplan_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count != 0)
            {
                frmOcSummary_details frm = new frmOcSummary_details(dsReport);
                frm.ShowDialog();
                frm.Dispose();
            }
            else 
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
        }
    }
}
