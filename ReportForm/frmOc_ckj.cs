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
    public partial class frmOc_ckj : Form
    {       
        DataTable dtBrand = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataSet dsCkj = new DataSet();

        public frmOc_ckj()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOc_ckj_Load(object sender, EventArgs e)
        {
            string strSQL = @"SELECT id,name as cdesc From dbo.cd_brand with(nolock) ORDER BY id";
            dtBrand = clsConErp.GetDataTable(strSQL);
            DataRow dr0 = dtBrand.NewRow(); //插一空行        
            dtBrand.Rows.InsertAt(dr0, 0);
            txtBrand_id1.Properties.DataSource = dtBrand;
            txtBrand_id1.Properties.ValueMember = "id";
            txtBrand_id1.Properties.DisplayMember = "id";

            txtBrand_id2.Properties.DataSource = dtBrand;
            txtBrand_id2.Properties.ValueMember = "id";
            txtBrand_id2.Properties.DisplayMember = "id";

            if (string.IsNullOrEmpty(txtDat1.Text))
            {
                txtDat1.EditValue = DateTime.Now;
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now;
            }
            txtBrand_id1.Focus();
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
            txtBrand_id1.Focus();
            string brand_id1 = "";
            string brand_id2 = "";
            if (string.IsNullOrEmpty(txtBrand_id1.Text))
            {
                brand_id1 = "";
            }
            else
            {
                brand_id1 = txtBrand_id1.EditValue.ToString();
            }
            if (string.IsNullOrEmpty(txtBrand_id2.Text))
            {
                brand_id2 = "";
            }
            else
            {
                brand_id2 = txtBrand_id2.EditValue.ToString();
            }

            if (txtDat1.Text == "" && txtDat2.Text == "" && brand_id1 == "" && brand_id2 == "")
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBrand_id1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]
            {                   
                    new SqlParameter("@brand_id1", brand_id1),
                    new SqlParameter("@brand_id2", brand_id2),
                    new SqlParameter("@date1", txtDat1.Text),
                    new SqlParameter("@date2",  txtDat2.Text)
            };
            //DataTable dtReport = new DataTable();
            //dtReport=clsConErp.ExecuteProcedureReturnTable("z_rpt_oc_ckj", paras);
            //dgvDetails.DataSource = dtReport;
            dsCkj  = clsConErp.ExecuteProcedureReturnDataSet("z_rpt_oc_ckj", paras,null);            
            dgvDetails.DataSource = dsCkj.Tables[0];
            dgvSum.DataSource = dsCkj.Tables[1];
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (this.dgvDetails.Columns.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < this.dgvDetails.Columns.Count; i++)
                {
                    this.dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;                    
                }
            }
            else
            {
                //dtReport.Clear();          
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

        private void txtBrand_id1_Click(object sender, EventArgs e)
        {
            txtBrand_id1.SelectAll();
        }

        private void txtBrand_id2_Click(object sender, EventArgs e)
        {
            txtBrand_id2.SelectAll();
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

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.EditValue = txtBrand_id1.EditValue;
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

        private void BTNTOTAL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }                      
            ExpToExcel oxls = new ExpToExcel();
            oxls.ExportExcel(dgvSum);            
            
        }
    }
}
