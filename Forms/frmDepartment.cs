using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using RUI.PC;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmDepartment : Form
    {
        private clsUtility.enumOperationType operationType;
        public frmDepartment()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;
            BindGroup();

            TxtBoxIsTrueOrFalse(false);
            BTNSAVE.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();
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

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (operationType == clsUtility.enumOperationType.Add || operationType == clsUtility.enumOperationType.Update)
            {
                return;   //如果是在新增或編輯狀態，不執行一下操作
            }

            if (dgvDetails.RowCount > 0)
            {
                txtDept_id.Text = dgvDetails.Rows[e.RowIndex].Cells["colDep_id"].Value.ToString();
                txtDept_desc.Text = dgvDetails.Rows[e.RowIndex].Cells["colDep_desc"].Value.ToString();
                txtDept_cdesc.Text = dgvDetails.Rows[e.RowIndex].Cells["colDep_cdesc"].Value.ToString();
                lueGroup.EditValue = dgvDetails.Rows[e.RowIndex].Cells["colDep_group"].Value.ToString().Trim();

                txtDept_id.Enabled = false;
            }
        }

        private void AddNew()
        {
            operationType = clsUtility.enumOperationType.Add;
            TxtBoxIsTrueOrFalse(true);

            TxtBoxClear();


            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
            BTNFIND.Enabled = false;

        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;
            TxtBoxIsTrueOrFalse(true);

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
            BTNFIND.Enabled = false;
        }

        private void Save()
        {
            if (ValidateText())
            {
                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsBs_Dep.AddDepartment(txtDept_id.Text.Trim().ToUpper(), txtDept_cdesc.Text.Trim(), txtDept_desc.Text.Trim(), lueGroup.EditValue.ToString());
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsBs_Dep.UpdateDepartment(txtDept_id.Text.Trim().ToUpper(), txtDept_cdesc.Text.Trim(), txtDept_desc.Text.Trim(), lueGroup.EditValue.ToString());
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                    operationType = clsUtility.enumOperationType.Save;
                    Find();
                    TxtBoxIsTrueOrFalse(false);

                    BTNNEW.Enabled = true;
                    BTNEDIT.Enabled = true;
                    BTNDELETE.Enabled = true;
                    BTNFIND.Enabled = true;
                    BTNSAVE.Enabled = false;
                }
            }
        }

        private void Delete()
        {
            if (dgvDetails.RowCount > 0)
            {
                if (MessageBox.Show("請確認是否刪除該數據？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDept_id = dgvDetails.CurrentRow.Cells["colDep_id"].Value.ToString();
                    int Result = clsBs_Dep.DeleteDepartment(strDept_id);

                    if (Result > 0)
                    {
                        MessageBox.Show("數據刪除成功！");
                        operationType = clsUtility.enumOperationType.Delete;
                        TxtBoxClear();

                        Find();
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有數據可以進行刪除。");
            }
        }

        private void Find()
        {
            dgvDetails.DataSource = clsBs_Dep.GetDepartments(txtDept_id.Text.Trim());
            dgvDetails.Refresh();
        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;
            TxtBoxIsTrueOrFalse(false);
            TxtBoxClear();

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNDELETE.Enabled = true;
            BTNFIND.Enabled = true;
            BTNSAVE.Enabled = false;
        }

        /// <summary>
        /// 綁定組別
        /// </summary>
        private void BindGroup()
        {
            lueGroup.Properties.DataSource = clsGetDataForComboBox.GetGroup();
            lueGroup.Properties.DisplayMember = "grp_code";
            lueGroup.Properties.ValueMember = "grp_code";
        }

        private bool ValidateText()
        {
            if (txtDept_id.Text.Trim() == "")
            {
                MessageBox.Show("部門ID不能為空，請輸入部門ID。");
                txtDept_id.Focus();
                return false;
            }

            if (!Verify.StringValidating(txtDept_id.Text.Trim(), Verify.enumValidatingType.LetterAndNumber))
            {
                MessageBox.Show("部門ID只能是數據和字母，請重新輸入。");
                txtDept_id.Focus();
                txtDept_id.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 文本框是否可用
        /// </summary>
        /// <param name="flag"></param>
        void TxtBoxIsTrueOrFalse(bool flag)
        {
            if (operationType == clsUtility.enumOperationType.Update)
            {
                txtDept_id.Enabled = false;
            }
            else
            {
                txtDept_id.Enabled = true;
            }
            lueGroup.Enabled = flag;
            txtDept_desc.Enabled = flag;
            txtDept_cdesc.Enabled = flag;
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        void TxtBoxClear()
        {
            txtDept_id.Text = "";
            lueGroup.EditValue = "";
            txtDept_desc.Text = "";
            txtDept_cdesc.Text = "";
        }



    }
}
