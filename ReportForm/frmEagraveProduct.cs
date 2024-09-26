using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;
using System.Data;

namespace cf01.ReportForm
{
    public partial class frmEagraveProduct : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();           
        //System.Data.DataTable dtReport = new System.Data.DataTable();        
        public frmEagraveProduct()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.panel1.Controls);
        }

        private void frmEagraveProduct_Load(object sender, EventArgs e)
        {            
            txtDept_id.Text = "401";
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            }
            if (txtDat2.Text != "")
            {
                //設置日期1為1月1號起
                string ls_date = DateTime.Parse(txtDat2.Text).Date.ToString("yyyy/MM/dd");
                ls_date = ls_date.Substring(0, 8) + "01";
                txtDat1.EditValue = ls_date;
            }            
            this.ActiveControl = txtDat2;  
            txtDat2.Focus();
            
        }

        private void frmEagraveProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            //dtReport.Dispose();
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
            if (txtDept_id.Text =="" )
            {
                MessageBox.Show("部門不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDept_id.Focus();
                return;
            }
            if (txtDat1.Text == "" && txtDat2.Text == "" )
            {
                MessageBox.Show("生產日期不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new SqlParameter("@dept_id",txtDept_id.Text ),
                new SqlParameter("@date_s",txtDat1.Text),
                new SqlParameter("@date_e",txtDat2.Text)    
            };
            DataSet dts=clsPublicOfCF01.ExecuteProcedureReturnDataSet("usp_engrave_product", paras,null);
            //dtReport = dts.Tables[0];
            dgvDetails1.DataSource = dts.Tables[0];
            dgvDetails2.DataSource = dts.Tables[1]; 
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dts.Tables[0].Rows.Count == 0)
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
            if (rdobTotal.Checked)
            {
                objxls.ExportToExcel_Fast(dgvDetails1);
            }
            else
            {
                objxls.ExportToExcel_Fast(dgvDetails2);
            }
            objxls = null;
        }

        private void rdobDetails_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdobDetails.Checked)
            {
                dgvDetails1.Visible = false;
                dgvDetails2.Visible = true;
            }
        }

        private void rdobTotal_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdobTotal.Checked)
            {
                dgvDetails2.Visible = false;
                dgvDetails1.Visible = true;
            }
        }

        
    }
}
