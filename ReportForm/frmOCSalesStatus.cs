using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;


namespace cf01.ReportForm
{
    public partial class frmOCSalesStatus : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataSet dts = new DataSet();
        DataTable dtReport = new DataTable();
  
        public frmOCSalesStatus()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOCSalesStatus_Load(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            }

            txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            this.ActiveControl = txtDat2;  
            txtDat2.Focus();
        }

        private void frmOCSalesStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
            dts.Dispose();
            clsConErp = null;
            clsApp = null;
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
            if (txtDat1.Text == "" && txtDat2.Text == "" )
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDat1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@date_s",txtDat1.Text),
                new SqlParameter("@date_e",txtDat2.Text)    
            };            
            dts = clsConErp.ExecuteProcedureReturnDataSet("z_oc_sales_status", paras, null);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            dtReport = dts.Tables[0];            
            if (dtReport.Rows.Count == 0)
            {
                dtReport.Clear();
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dgvDetails.DataSource = null;
                rdb1.Checked = true;
                Set_Column_Properties(0);
            }
        }      

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }    

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDat2.EditValue = txtDat1.EditValue;
        }  

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel xls = new ExpToExcel();
            xls.ExportExcel(dgvDetails);
        }

     
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void rdb1_Click(object sender, EventArgs e)
        {
            Set_Column_Properties(0);
        }

        private void rdb2_Click(object sender, EventArgs e)
        {
            Set_Column_Properties(1);
        }

        private void rdb3_Click(object sender, EventArgs e)
        {            
            Set_Column_Properties(2);
        }

        private void Set_Column_Properties(int options)
        {
            if (dts.Tables.Count == 0)
            {
                return;
            }
            dgvDetails.Columns.Clear();
            dtReport = dts.Tables[options];
            dgvDetails.DataSource = null ;
            dgvDetails.DataSource = dtReport;                   
            //禁止列排序
            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

    }
}
