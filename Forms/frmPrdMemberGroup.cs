using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmPrdMemberGroup : Form
    {
        private string _userid = DBUtility._user_id.ToUpper();
        public frmPrdMemberGroup()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void initControls()
        {
            //初始化生產部門
            DataTable dtPrd_dept = clsProductionSchedule.GetAllPrd_dept();
            cmbProductDept.DataSource = dtPrd_dept;
            cmbProductDept.DisplayMember = "int9loc";
            cmbProductDept.ValueMember = "int9loc";
        }
        private void InitComBoxGroup()
        {
            string group_type = "2";
            if (cmbProductDept.SelectedValue.ToString() == "203")
                group_type = "1";
            string strSql = "";
            strSql = " SELECT Rtrim(work_group) AS work_group,group_desc FROM work_group WHERE ( dep='" + cmbProductDept.Text.Trim() + "'" + " AND group_type='" + group_type + "') " + " OR dep='" + "000" + "' ";
            DataTable dtGroup = clsPublicOfPad.GetDataTable(strSql);
            if (dtGroup.Rows.Count > 0)
            {
                cmbGroup.DataSource = dtGroup;
                cmbGroup.DisplayMember = "work_group";
                cmbGroup.ValueMember = "work_group";
            }
        }

        private void cmbProductDept_Leave(object sender, EventArgs e)
        {
            InitComBoxGroup();
            loadPrdGroupMember();
        }

        private void frmPrdMemberGroup_Load(object sender, EventArgs e)
        {
            initControls();
            cmbProductDept.Text = frmProductionSelect.sent_dep;
            cmbGroup.Text = frmProductionSelect.sent_group;
            loadPrdGroupMember();
        }

        private void loadPrdGroupMember()
        {

            string strSql = "";
            strSql = " SELECT prd_dep,prd_group,prd_worker FROM product_group_member WHERE prd_dep='" + cmbProductDept.Text.Trim() + "'" + " AND prd_group='" + cmbGroup.Text.Trim() + "' ";
            DataTable dtGroupMember = clsPublicOfPad.GetDataTable(strSql);
            //if (dtGroupMember.Rows.Count > 0)
            //{
                dgvDetails.DataSource = dtGroupMember;
            //}
            //else
            //    dgvDetails.DataSource = null;
        }

        private void cmbGroup_Leave(object sender, EventArgs e)
        {
            loadPrdGroupMember();
        }

        private void txtMember_Leave(object sender, EventArgs e)
        {
            if (txtMember.Text.Trim() != "")
                txtMember.Text = txtMember.Text.PadLeft(10, '0');
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cmbGroup.Focus();
            if (cmbProductDept.Text.Trim() == "")
            {
                MessageBox.Show("部門編號不能為空!");
                cmbProductDept.Focus();
                return;
            }
            if (cmbGroup.Text.Trim() == "")
            {
                MessageBox.Show("組別不能為空!");
                cmbGroup.Focus();
                return;
            }
            if (txtMember.Text.Trim() == "")
            {
                MessageBox.Show("工號不能為空!");
                txtMember.Focus();
                return;
            }
            string strSql = "";
            strSql = " SELECT prd_dep,prd_group,prd_worker FROM product_group_member WHERE prd_dep='" + cmbProductDept.Text.Trim()
                + "'" + " AND prd_group='" + cmbGroup.Text.Trim() + "' AND prd_worker='" + txtMember.Text.Trim() + "'";

            DataTable dtGroupMember = clsPublicOfPad.GetDataTable(strSql);
            if (dtGroupMember.Rows.Count == 0)
            {

                strSql = @"Insert Into product_group_member (prd_dep,prd_group,prd_worker,crusr,crtim) Values (@prd_dep,@prd_group,@prd_worker,@crusr,@tim)";
                SqlParameter[] paras2 = new SqlParameter[] {
                       new SqlParameter("@prd_dep",cmbProductDept.Text.Trim()),
                       new SqlParameter("@prd_group",cmbGroup.Text.Trim()),
                       new SqlParameter("@prd_worker",txtMember.Text.Trim()),
                       new SqlParameter("@crusr",_userid),
                       new SqlParameter("@tim",System.DateTime.Now)
                    };
                int ArrangeResult = clsPublicOfPad.ExecuteNonQuery(strSql, paras2, false);
                if (ArrangeResult > 0)
                {
                    MessageBox.Show("儲存記錄成功!");
                    txtMember.Focus();
                    loadPrdGroupMember();
                    
                }
                else
                    MessageBox.Show("儲存記錄失敗!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = @"Delete From product_group_member Where prd_dep=@prd_dep And prd_group=@prd_group And prd_worker=@prd_worker";
            SqlParameter[] paras2 = new SqlParameter[] {
                       new SqlParameter("@prd_dep",cmbProductDept.Text.Trim()),
                       new SqlParameter("@prd_group",cmbGroup.Text.Trim()),
                       new SqlParameter("@prd_worker",txtMember.Text.Trim())
                    };
            int ArrangeResult = clsPublicOfPad.ExecuteNonQuery(strSql, paras2, false);
            if (ArrangeResult > 0)
            {
                MessageBox.Show("刪除記錄成功!");
                loadPrdGroupMember();
            }
            else
                MessageBox.Show("刪除記錄失敗!");
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtMember.Text=dgvDetails
            //fillTextBox(dgvDetails.CurrentCell.RowIndex);
            DataGridViewRow CurrentRow = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex];
            cmbProductDept.Text=CurrentRow.Cells["colPrd_dep"].Value.ToString();
            cmbGroup.Text = CurrentRow.Cells["colPrd_group"].Value.ToString();
            txtMember.Text = CurrentRow.Cells["colPrd_worker"].Value.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMember.Text = "";
        }
    }
}
