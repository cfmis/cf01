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
    public partial class frmInvData : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtReport = new DataTable();
        
        public frmInvData()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmInvData_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDat2.Text))
            //{
            //    txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            //}

            ////定義焦點位置
            //txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            this.ActiveControl = txtDat2;  
            txtDat2.Focus();
            
        }

        private void frmInvData_FormClosed(object sender, FormClosedEventArgs e)
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
            if (txtDat1.Text == "" && txtDat2.Text == "" && textBox1.Text =="" )
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
                new SqlParameter("@date_e",txtDat2.Text),
                new SqlParameter("@brand_id",textBox1.Text)
                
            };            
            dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("p_rpt_inv_date", paras);           
            dgvDetails.DataSource = dtReport;       

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }                    
            }
            else
            {
                dtReport.Clear();               
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ExpToExcel oxls = new ExpToExcel();
            oxls.ExportExcel(dgvDetails);
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
