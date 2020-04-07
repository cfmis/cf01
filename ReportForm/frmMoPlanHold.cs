using cf01.CLS;
using cf01.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmMoPlanHold : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private DataTable dtReport = new DataTable();
        private DataSet dsReport = new DataSet();
        private clsAppPublic clsApp = new clsAppPublic();

        public frmMoPlanHold()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
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

            if (txtDat1.Text == "" && txtDat2.Text == "")
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@order_date_s", txtDat1.Text),
                new SqlParameter("@order_date_e",  txtDat2.Text),
                new SqlParameter("@it_customer",  txtit_customer.Text),
                new SqlParameter("@brand_id",  txtBrand_id.Text),
                new SqlParameter("@sales_group",  txtSales_group.Text)
            };

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            
            dsReport = clsConErp.ExecuteProcedureReturnDataSet("z_rpt_mo_hold", paras, null);
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

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Excel();
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

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
