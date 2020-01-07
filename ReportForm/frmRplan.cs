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
using cf01.Forms;
using System.Threading;


namespace cf01.ReportForm
{
    public partial class frmRplan : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtReport = new DataTable();
        public frmRplan()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmRplan_Load(object sender, EventArgs e)
        {

            dtReport = clsBaseData.Get_Department();
            DataRow dr0 = dtReport.NewRow(); //插一空行        
            dtReport.Rows.InsertAt(dr0, 0);
            txtDept1.Properties.DataSource = dtReport;
            txtDept1.Properties.ValueMember = "id";
            txtDept1.Properties.DisplayMember = "cdesc";

            txtDept2.Properties.DataSource = dtReport;
            txtDept2.Properties.ValueMember = "id";
            txtDept2.Properties.DisplayMember = "cdesc";

            if (string.IsNullOrEmpty(txtDat1.Text))
            {
                txtDat1.EditValue = DateTime.Now.AddDays(-1);
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1); 
            }
            txtDept1.Focus();
        }

        private void frmRplan_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
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
            txtDept1.Focus();
            string dept1 = "";
            string dept2 = "";
            if (string.IsNullOrEmpty(txtDept1.Text))
            {
                dept1 = "";
            }
            else
            {
                dept1 = txtDept1.EditValue.ToString();
            }
            if (string.IsNullOrEmpty(txtDept2.Text))
            {
                dept2 = "";
            }
            else
            {
                dept2 = txtDept2.EditValue.ToString();
            }

            if (txtDat1.Text == "" && txtDat2.Text == "" && dept1 == "" && dept2 == "" && txtMo1.Text == "" && txtMo2.Text == "")
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDept1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            StringBuilder sb = new StringBuilder(
            @"Select b.charge_dept,a.id,a.order_date,a.mo_id,b.goods_id,b.goods_name,
            b.order_qty,a.repair_mo_id,c.f_production_date,c.remark,a.state,a.create_by           
            From jo_production_repair_mostly a with(nolock)
            INNER JOIN jo_production_repair_details b with(nolock) ON a.within_code =b.within_code and a.id=b.id 
            LEFT JOIN jo_bill_mostly c ON a.within_code=c.within_code AND a.repair_mo_id=c.mo_id and c.state not in ('2','V')
            LEFT JOIN cd_department d ON b.within_code=d.within_code AND b.charge_dept=d.id
            WHERE a.within_code ='0000'");
            if(!string.IsNullOrEmpty(txtDat1.Text))
            {                
                sb.Append(string.Format(" And a.order_date >='{0}'",txtDat1.Text));
            }
            if(!string.IsNullOrEmpty(txtDat2.Text))
            {                
                sb.Append(string.Format(" And a.order_date <='{0}'",txtDat2.Text));
            }
            if (!string.IsNullOrEmpty(txtMo1.Text))
            {
                sb.Append(string.Format(" And a.mo_id>='{0}'", txtMo1.Text));
            }
            if (!string.IsNullOrEmpty(txtMo2.Text))
            {
                sb.Append(string.Format(" And a.mo_id<='{0}'", txtMo2.Text));
            }
            if(!string.IsNullOrEmpty(dept1))
            {                
                sb.Append(string.Format(" And b.charge_dept>='{0}'",dept1));
            }
            if(!string.IsNullOrEmpty(dept2))
            {                
                sb.Append(string.Format(" And b.charge_dept<='{0}'",dept2));
            }
            sb.Append(" AND a.state NOT IN ('2','V')");
            sb.Append(" ORDER BY a.order_date,a.repair_mo_id,a.mo_id");
           
           
            DataTable dtReport = new DataTable();
            dtReport = clsConErp.GetDataTable(sb.ToString());           
            dgvDetails.DataSource = dtReport;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

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
            //if (dgvDetails.Rows.Count == 0)
            //{
            //    MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}            
            ////加載報表                
            //cf01.Reports.xrPlateSelect oRepot = new cf01.Reports.xrPlateSelect() { DataSource = dtReport };
            //oRepot.CreateDocument();
            //oRepot.PrintingSystem.ShowMarginsWarning = false;
            //oRepot.ShowPreview();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDept1_Click(object sender, EventArgs e)
        {
            txtDept1.SelectAll();
        }

        private void txtDept2_Click(object sender, EventArgs e)
        {
            txtDept2.SelectAll();
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
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        private void BTNEXCEL_Details_Click(object sender, EventArgs e)
        {
            //if (dgvDetails.Rows.Count == 0)
            //{
            //    MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //Excel(dgvDetails);
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtDept2.EditValue = txtDept1.EditValue;
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

     
    }
}
