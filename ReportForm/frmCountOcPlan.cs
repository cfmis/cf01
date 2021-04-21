using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace cf01.ReportForm
{
    public partial class frmCountOcPlan : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        //private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtblReport = new DataTable();
        public frmCountOcPlan()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmCountOcPlan_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtblReport.Dispose();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            //txtId1.Focus();
            string date_s = txtDat1.Text;
            string date_e = txtDat2.Text;
            if (date_s == "" && date_s == "")
            {
                MessageBox.Show("查詢條件不可為空!", "提示信息");
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
          
            dtblReport = clsPublicOfCF01.ExecuteProcedureReturnTable("p_kpi_oc_plan", paras);
            dgvDetails.DataSource = dtblReport;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtblReport.Rows.Count == 0)            
            {               
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);               
            }
        }          

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.Text = txtDat1.Text;
        }

        private void frmCountOcPlan_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                txtDat1.EditValue = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd").Substring(0, 10);
            }           
            this.ActiveControl = txtDat2;
            txtDat2.Focus();
        }
    }
}
