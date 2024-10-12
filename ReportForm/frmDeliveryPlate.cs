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
    public partial class frmDeliveryPlate : Form
    {
        clsPublicOfGEO clsGeo = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtTotal = new DataTable();
        DataTable dtDetail = new DataTable();
        public frmDeliveryPlate()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmDeliveryPlate_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDat2.Text))
            //{
            //    txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            //}

            ////定義焦點位置
            //txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            //this.ActiveControl = txtDat2;  
            //txtDat2.Focus();
            
        }

        private void frmDeliveryPlate_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtTotal.Dispose();
            dtDetail.Dispose();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, panel1.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(panel1.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        { 
            if (txtDate1.Text == "" && txtDate2.Text == "" &&txtDept1.Text ==""&&txtDept2.Text =="" && txtId1.Text == "" && txtId2.Text=="" )
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDate1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@con_date_s",DateTime.Parse(txtDate1.Text).Date.ToString("yyyy-MM-dd")),
                new SqlParameter("@con_date_e",DateTime.Parse(txtDate2.Text).Date.ToString("yyyy-MM-dd")),
                new SqlParameter("@dept_id_s",txtDept1.Text),
                new SqlParameter("@dept_id_e",txtDept2.Text),
                new SqlParameter("@handover_id_s",txtId1.Text),
                new SqlParameter("@handover_id_e",txtId2.Text)
            };
            DataSet dts = clsGeo.ExecuteProcedureReturnDataSet("p_rpt_turn_over_summary_plate", paras,"");
            dtTotal = dts.Tables[0];
            dtDetail = dts.Tables[1];
            dgvTotal.DataSource = dtTotal;
            dgvDetail.DataSource = dtDetail;
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtTotal.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < dgvTotal.Columns.Count; i++)
                {
                    dgvTotal.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }                
            }
            else
            {                             
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }      

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }    

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDate2.EditValue = txtDate1.EditValue;
        }  

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvTotal.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel oxls = new ExpToExcel();
            oxls.ExportToExcel_Fast(dgvTotal);
        }
                 
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvTotal.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvTotal.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvTotal.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.Text = txtDept1.Text;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel oxls = new ExpToExcel();
            oxls.ExportToExcel_Fast(dgvDetail);
        }
    }
}
