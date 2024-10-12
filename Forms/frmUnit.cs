using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RUI.PC;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmUnit : Form
    {
        private clsUtility.enumOperationType operationType;
        public frmUnit()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmUnit_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;

            txtUnit_Id.Enabled = true;
            txtEn_desc.Enabled = false;
            txtCh_desc.Enabled = false;

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

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (operationType == clsUtility.enumOperationType.Add || operationType == clsUtility.enumOperationType.Update)
            {
                return;   //如果是在新增或編輯狀態，不執行一下操作
            }

            if (dgvDetails.RowCount > 0)
            {
                txtUnit_Id.Text = dgvDetails.Rows[e.RowIndex].Cells["colUnit_id"].Value.ToString();
                txtEn_desc.Text = dgvDetails.Rows[e.RowIndex].Cells["colUnit_desc"].Value.ToString();
                txtCh_desc.Text = dgvDetails.Rows[e.RowIndex].Cells["colUnit_cdesc"].Value.ToString();

                txtUnit_Id.Enabled = false;
            }
        }

        private void AddNew()
        {
            operationType = clsUtility.enumOperationType.Add;
            txtUnit_Id.Enabled = true;
            txtEn_desc.Enabled = true;
            txtCh_desc.Enabled = true;

            txtUnit_Id.Text = "";
            txtEn_desc.Text = "";
            txtCh_desc.Text = "";

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
            BTNFIND.Enabled = false;
        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;
            txtUnit_Id.Enabled = false;
            txtEn_desc.Enabled = true;
            txtCh_desc.Enabled = true;

            BTNNEW.Enabled = true;
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
                            Result = clsBs_Unit.AddUnit(txtUnit_Id.Text.Trim().ToUpper(), txtEn_desc.Text.Trim(), txtCh_desc.Text.Trim());
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsBs_Unit.UpdateUnit(txtUnit_Id.Text.Trim().ToUpper(), txtEn_desc.Text.Trim(), txtCh_desc.Text.Trim());
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                    operationType = clsUtility.enumOperationType.Save;
                    Find();
                  
                    txtUnit_Id.Enabled = true;
                    txtEn_desc.Enabled = false;
                    txtCh_desc.Enabled = false;

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

                    string strUnit_id = dgvDetails.CurrentRow.Cells["colUnit_id"].Value.ToString();
                    int Result = clsBs_Unit.DeleteUnit(strUnit_id);
                    if (Result > 0)
                    {
                        MessageBox.Show("刪除成功！");
                        operationType = clsUtility.enumOperationType.Delete;
                        txtUnit_Id.Text = "";
                        txtEn_desc.Text = "";
                        txtCh_desc.Text = "";

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
            dgvDetails.DataSource = clsBs_Unit.GetUnitsData(txtUnit_Id.Text.Trim());
            dgvDetails.Refresh();
        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;

            txtUnit_Id.Text = "";
            txtEn_desc.Text = "";
            txtCh_desc.Text = "";

            txtUnit_Id.Enabled = true;
            txtEn_desc.Enabled = false;
            txtCh_desc.Enabled = false;

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNDELETE.Enabled = true;
            BTNFIND.Enabled = true;
            BTNSAVE.Enabled = false;
        }

        private bool ValidateText()
        {
            if (txtUnit_Id.Text.Trim() == "")
            {
                MessageBox.Show("單位ID不能為空，請輸入單位ID。");
                txtUnit_Id.Focus();
                return false;
            }

            if (!Verify.StringValidating(txtUnit_Id.Text.Trim(), Verify.enumValidatingType.LetterAndNumber))
            {
                MessageBox.Show("單位ID只能是數字和字母，請重新輸入。");
                txtUnit_Id.Focus();
                txtUnit_Id.SelectAll();
                return false;
            }

            //if (txtEn_desc.Text.Trim() == "")
            //{
            //    MessageBox.Show("英文描述不能為空，請輸入描述。");
            //    txtEn_desc.Focus();
            //    return false;
            //}
            //if (txtCh_desc.Text.Trim() == "")
            //{
            //    MessageBox.Show("中文描述不能為空，請輸入描述。");
            //    txtCh_desc.Focus();
            //    return false;
            //}

            return true;
        }



    }
}
