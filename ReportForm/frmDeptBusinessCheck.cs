using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraReports.UI;
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
    public partial class frmDeptBusinessCheck : Form
    {
        clsPublicOfGEO clsGeo = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtDelivery = new DataTable();
        public frmDeptBusinessCheck()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, panel1.Controls);
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurDelivery_Load(object sender, EventArgs e)
        {           
            DataTable dtDept = clsBaseData.Get_Dept();
            DataRow dr0 = dtDept.NewRow(); //插一空行
            dtDept.Rows.InsertAt(dr0, 0);
            cboDept_id1.Properties.DataSource = dtDept;
            cboDept_id1.Properties.ValueMember = "id";
            cboDept_id1.Properties.DisplayMember = "cdesc";

            cboDept_id2.Properties.DataSource = dtDept;
            cboDept_id2.Properties.ValueMember = "id";
            cboDept_id2.Properties.DisplayMember = "cdesc";

            if (dtDat1.Text == "" && dtDat2.Text == "")
            {
                dtDat1.EditValue = DateTime.Now.AddDays(-8).Date.ToString("yyyy-MM-dd");
                dtDat2.EditValue = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
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
            string strDept_id1 = cboDept_id1.EditValue.ToString();
            string strDept_id2 = cboDept_id2.EditValue.ToString();

            if (strDept_id1 == "" && strDept_id2 == "" && dtDat1.Text == "" && dtDat2.Text == "" )
            {
                MessageBox.Show("查詢條件不可以全部爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }                      
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@dept_id",strDept_id1),
                new SqlParameter("@dept_id_end",strDept_id2),
                new SqlParameter("@date_begin", dtDat1.EditValue.ToString()),
                new SqlParameter("@date_end", dtDat2.EditValue.ToString())                            
            };

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            dtDelivery = clsGeo.ExecuteProcedureReturnTable("z_rpt_dept_business_check", paras);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtDelivery.Rows.Count > 0)
            {
                dgvDetails.DataSource = dtDelivery;
            }
            else
            {                
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }       

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDat2.EditValue = dtDat1.EditValue;
        }

        private void cboDept_id1_Leave(object sender, EventArgs e)
        {
            cboDept_id2.EditValue = cboDept_id1.EditValue;
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

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dtDelivery.Rows.Count == 0)
            {
                MessageBox.Show("沒有需要匯出的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel oxls = new ExpToExcel();
            oxls.ExportExcel(dgvDetails);
        }



    }
}
