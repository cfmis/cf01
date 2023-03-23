using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using System.Data.SqlClient;
using System.Threading;
using cf01.CLS;
using cf01.Forms;

namespace cf01.MM
{
    public partial class frmSetProductRecordCost : Form
    {
        public frmSetProductRecordCost()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!findVaildData())
                return;
            findData();
        }
        private void findData()
        {
            txtPrdDep.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //**********************
            findDataProcess(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (dgvDetails.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private bool findVaildData()
        {
            if (txtPrdDep.Text.Trim() == "")
            {
                MessageBox.Show("部門不能為空!");
                txtPrdDep.Focus();
                return false;
            }
            if (txtPrdDateFrom.EditValue == null || txtPrdDateFrom.EditValue.ToString() == "")
            {
                MessageBox.Show("生產單日期為空!");
                txtPrdDateFrom.Focus();
                return false;
            }
            if (txtPrdDateTo.EditValue == null || txtPrdDateTo.EditValue.ToString() == "")
            {
                MessageBox.Show("生產單日期為空!");
                txtPrdDateTo.Focus();
                return false;
            }
            return true;
        }
        private void findDataProcess()
        {
            string strSql = "";
            string prd_dep = txtPrdDep.Text;
            string prd_date_from = txtPrdDateFrom.Text;
            string prd_date_to = txtPrdDateTo.Text;
            strSql = "Select a.prd_dep,a.prd_mo,a.prd_item,b.name AS prd_item_cdesc,a.prd_qty,a.prd_date,a.job_type,a.work_code,a.prd_group" +
                ",a.prd_start_time,a.prd_end_time,a.prd_normal_time,a.prd_ot_time,a.prd_weg,a.prd_machine"+
                ",a.process_id,a.process_price,a.process_unit,a.process_cost"+
                " From dgcf_pad.dbo.product_records a" +
                " Left Join geo_it_goods b On a.prd_item COLLATE chinese_taiwan_stroke_CI_AS=b.id " +
                " Where a.prd_dep='" + prd_dep + "'" +
                " And a.prd_date >='" + prd_date_from + "' And a.prd_date <='" + prd_date_to + "'" +
                " And a.prd_work_type ='A02' And a.prd_qty > 0 ";
            DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);
            dtPrd.Columns.Add("chk_flag", typeof(bool));
            for (int i = 0; i < dtPrd.Rows.Count; i++)
            {
                dtPrd.Rows[i]["chk_flag"] = false;
            }
            dgvDetails.DataSource = dtPrd;
            gcDetails.DataSource = dtPrd;
            //gridView1.DataSource = dtPrd;
            //DataGridViewRow dr = dgvDetails.Rows[row];
            //txtSizeGroupSeq.Text = dr.Cells["colSizeGroupSeq"].Value.ToString();
            bindDgvCombox();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrdDateFrom_Leave(object sender, EventArgs e)
        {
            txtPrdDateTo.Text = txtPrdDateFrom.Text;
        }

        private void txtMachineFrom_Leave(object sender, EventArgs e)
        {
            txtMachineTo.Text = txtMachineFrom.Text;
        }

        private void txtMoFrom_Leave(object sender, EventArgs e)
        {
            txtMoTo.Text = txtMoFrom.Text;
        }

        private void txtJobTypeFrom_Leave(object sender, EventArgs e)
        {
            txtJobTypeTo.Text = txtJobTypeFrom.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool chkFlag = chkSelect.Checked;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                DataGridViewRow crItem = dgvDetails.Rows[i];
                crItem.Cells["colSelect"].Value = chkFlag;
            }
        }

        private void frmSetProductRecordCost_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
        }
        private void bindJob_type()
        {
            lueJob_type.Properties.DataSource = loadJob_type();
            lueJob_type.Properties.ValueMember = "Process_id";
            lueJob_type.Properties.DisplayMember = "Process_name";
        }
        private DataTable loadJob_type()
        {
            string strSql = "";
            strSql = "Select Rtrim(Process_id) AS Process_id,Rtrim(Process_name) AS Process_name,Product_qty,Cost_price" +
                " From jo_dept_product_cost Where Dept_id='" + txtPrdDep.Text + "'";
            DataTable dtJob_type = clsPublicOfCF01.GetDataTable(strSql);
            return dtJob_type;
        }

        private void txtPrdDep_Leave(object sender, EventArgs e)
        {
            if (txtPrdDep.Text != "")
                bindJob_type();
        }

        private void bindDgvCombox()
        {
            //DataGridViewComboBoxColumn dgvComboBox = dgvDetails.Columns["colProcess_id"] as DataGridViewComboBoxColumn;
            //dgvComboBox.DataSource = loadJob_type();
            //dgvComboBox.DisplayMember = "Process_id";
            //dgvComboBox.ValueMember = "Process_name";
            repositoryItemLookUpEdit1.DataSource= loadJob_type();
            repositoryItemLookUpEdit1.ValueMember = "Process_id";
            repositoryItemLookUpEdit1.DisplayMember = "Process_name";

            //RepositoryItemLookUpEdit lookUp = new RepositoryItemLookUpEdit();
            //lookUp.DataSource = loadJob_type();
            //lookUp.DisplayMember = "Process_id";
            //lookUp.ValueMember = "Process_name";

            //gridControl1.RepositoryItems.Add(lookUp);
            //gridView1.Columns().Item("gridColumn2").ColumnEdit = lookUp;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string filePath = @"c:\vue01\index.html";

            string dirPath = @"c:\vue01";

            System.Collections.Specialized.StringCollection strcoll = new System.Collections.Specialized.StringCollection(); //收集路径

            strcoll.Add(filePath);

            //strcoll.Add(dirPath);

            Clipboard.SetFileDropList(strcoll);//将要复制的文件货文件夹路径放入剪切板

        }
    }
}
