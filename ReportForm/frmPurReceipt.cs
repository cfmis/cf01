using cf01.CLS;
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
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmPurReceipt : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtDelivery = new DataTable();
        public frmPurReceipt()
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
                dtDat1.EditValue = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");
                dtDat2.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
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

            if (strDept_id1 == "" && strDept_id2 == "" && dtDat1.Text == "" && dtDat2.Text == "" &&txtid1.Text=="" && txtid2.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string is_include_mat = "0";
            if(chkMl.Checked)
            {
                is_include_mat = "1";
            }
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@order_date_s", dtDat1.Text),
                new SqlParameter("@order_date_e", dtDat2.Text),
                new SqlParameter("@dept_id_s",strDept_id1),
                new SqlParameter("@dept_id_e",strDept_id2),
                new SqlParameter("@id_s",txtid1.Text),
                new SqlParameter("@id_e",txtid2.Text),
                new SqlParameter("@is_include_mat",is_include_mat)
            };

            dtDelivery = clsPublicOfCF01.ExecuteProcedureReturnTable("p_rpt_pur_delivery", paras);
            if (dtDelivery.Rows.Count > 0)
            {
                dgvDetails.DataSource = dtDelivery;
            }
            else
            {                
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dtDelivery.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataRow[] drs = dtDelivery.Select("flag_select=true");
            if(drs.Length==0)
            {
                MessageBox.Show("請選中需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dtReport = dtDelivery.Clone();
            foreach (DataRow dr in drs)
            {
                dtReport.ImportRow(dr);
            }           
            using (xrPurReceipt rpt = new xrPurReceipt() { DataSource = dtReport })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
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

        private void txtid1_Leave(object sender, EventArgs e)
        {
            txtid2.Text = txtid1.Text;
        }

        private void chkSelectAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (dtDelivery.Rows.Count == 0)
            {
                return;
            }
            bool select_all;
            if (this.chkSelectAll.Checked)
            {
                select_all = true;                
            }
            else
            {
                select_all = false;
            }
            for (int i = 0; i < dtDelivery.Rows.Count; i++)
            {
                dtDelivery.Rows[i]["flag_select"] = select_all;
            }
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

            DataGridView grd = sender as DataGridView;           
            if (grd.Rows[e.RowIndex].Cells["flag_select"].Value.ToString() == "True")
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            else
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
