using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    /// <summary>
    /// 添加角色
    /// </summary>
    public partial class frmRole : Form
    {
        private clsUtility.enumOperationType operationType;
        public frmRole()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            txtRoleID.Enabled = false;
            txtRoleDesc.Enabled = true;
            BTNSAVE.Enabled = false;

            InitGridData();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoleDesc.Text = dataGridView1.Rows[e.RowIndex].Cells["colRname"].Value.ToString();
            txtRoleID.Text = dataGridView1.Rows[e.RowIndex].Cells["colRid"].Value.ToString();
        }

        private void InitGridData()
        {
            DataTable dtRole = clsRoleManage.GetAllRole();
            if (dtRole.Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dtRole;
                dataGridView1.Refresh();
            }
        }

        /// <summary>
        /// Add
        /// </summary>
        private void Add()
        {
            operationType = clsUtility.enumOperationType.Add;
            txtRoleDesc.Text = "";
            txtRoleID.Text = "";


            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
            BTNFIND.Enabled = false;
        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
            BTNFIND.Enabled = false;
        }

        private void Find()
        {
            if (txtRoleDesc.Text.Trim() != "")
            {
                DataTable dtRole = clsRoleManage.QueryRoleByRname(txtRoleDesc.Text.Trim());
                if (dtRole.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtRole;
                    dataGridView1.Refresh();
                }
            }
            else
            {
                InitGridData();
            }
        }

        private void Delete()
        {

        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;
            txtRoleDesc.Text = "";
            txtRoleID.Text = "";

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNSAVE.Enabled = false;
            BTNDELETE.Enabled = true;
            BTNFIND.Enabled = true;
        }

        /// <summary>
        /// 保存新增或編輯的角色信息
        /// </summary>
        private void Save()
        {
            if (txtRoleDesc.Text.Trim() == "")
            {
                MessageBox.Show("请输入角色描述！");
                txtRoleDesc.Focus();
                return;
            }

            int Result = 0;
            switch (operationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        if (IsExist(txtRoleDesc.Text.Trim()))
                        {
                            try
                            {
                                Result = clsRoleManage.AddRole(txtRoleDesc.Text.Trim());
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("(" + txtRoleDesc.Text.Trim() + ")角色已經存在!");
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        Role ModelRole = new Role();
                        ModelRole.Rid = Convert.ToInt32(txtRoleID.Text.Trim());
                        ModelRole.Rname = txtRoleDesc.Text.Trim();
                        try
                        {
                            Result = clsRoleManage.UpdateRole(ModelRole);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    break;

                default:
                    break;
            }
            if (Result > 0)
            {
                MessageBox.Show("修改完成！");
                InitGridData();

                BTNNEW.Enabled = true;
                BTNEDIT.Enabled = true;
                BTNSAVE.Enabled = false;
                BTNDELETE.Enabled = true;
                BTNFIND.Enabled = true;
            }
        }

        /// <summary>
        /// 判斷該角色是否存在
        /// </summary>
        /// <param name="RoleDesc"></param>
        /// <returns></returns>
        private bool IsExist(string RoleDesc)
        {
            DataTable dts = clsRoleManage.QueryRoleByRname(RoleDesc);
            if (dts.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




    }
}
