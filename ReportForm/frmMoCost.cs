using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;
using System.IO;
using cf01.Forms;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace cf01.ReportForm
{
    public partial class frmMoCost : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        System.Data.DataTable dtReport = new System.Data.DataTable();
        public frmMoCost()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.panel1.Controls);
        }

        private void frmMoCost_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDat1.Text))
            //{
            //    txtDat1.EditValue = DateTime.Now.AddDays(-1);
            //}
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            }

            txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            this.ActiveControl = txtDat2;  
            txtDat2.Focus();
            
        }

        private void frmMoCost_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
            clsApp = null;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.panel1.Controls)>0)
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
            dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_inv_mo_cost", paras);           
            dgvDetails1.DataSource = dtReport;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtReport.Rows.Count == 0)
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
            if (dgvDetails1.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           ExpToExcel objxls=new ExpToExcel();
           //objxls.ExportExcel(dgvDetails1);
           objxls.ExportToExcel_Fast(dgvDetails1);
           objxls = null;
        }

        
    }
}
