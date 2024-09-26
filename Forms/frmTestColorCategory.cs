using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmTestColorCategory : Form
    {
        private clsUtility.enumOperationType OperationType;

        public frmTestColorCategory()
        {
            InitializeComponent();

            clsControlInfoHelper formInit = new clsControlInfoHelper(this.Name, this.Controls);
            formInit.GenerateContorl();
        }

        private void frmTestColorCategory_Load(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Load;
            ControlState();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Add;
            ControlState();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Update;
            ControlState();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Result = 0;
            switch (OperationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        if (txtColorCategory_id.Text != "")
                        {
                            DataTable dtIsExsit = clsTestProductPlan.GetColorCategory(txtColorCategory_id.Text.Trim(), "");
                            if (dtIsExsit.Rows.Count > 0)
                            {
                                MessageBox.Show("此編號已存在，請重新輸入。");
                                txtColorCategory_id.Focus();
                                txtColorCategory_id.SelectAll();
                                return;
                            }

                            Result = clsTestProductPlan.AddColorCategory(txtColorCategory_id.Text, txtColorCategory_cdesc.Text.Trim(), txtColorCategory_edesc.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("編號不能為空。");
                            txtColorCategory_id.Focus();
                            return;
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        Result = clsTestProductPlan.UpdateColorCategory(txtColorCategory_id.Text.Trim(), txtColorCategory_cdesc.Text.Trim(), txtColorCategory_edesc.Text.Trim());
                    }
                    break;
            }

            if (Result > 0)
            {
                GetColorCategory(txtColorCategory_id.Text.Trim(), "");
                OperationType = clsUtility.enumOperationType.Save;
                ControlState();
            }
            else
            {
                MessageBox.Show("保存出錯！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定刪除該條記錄?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int Result = 0;
                Result = clsTestProductPlan.DeleteColorCategory(dgvColorCategory.CurrentRow.Cells["colColorCategory_id"].Value.ToString());
                if (Result > 0)
                {
                    GetColorCategory(txtColorCategory_id_sq.Text.Trim(), txtColorCategory_cdesc_sq.Text.Trim());
                    OperationType = clsUtility.enumOperationType.Delete;
                    ControlState();
                }
                else
                {
                    MessageBox.Show("刪除失敗！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Cancel;
            ControlState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetColorCategory(txtColorCategory_id_sq.Text.Trim(), txtColorCategory_cdesc_sq.Text.Trim());
        }

        private void dgvColorProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                return;

            if (dgvColorCategory.Rows.Count > 0)
            {
                txtColorCategory_id.Text = dgvColorCategory.CurrentRow.Cells["colColorCategory_id"].Value.ToString();
                txtColorCategory_cdesc.Text = dgvColorCategory.CurrentRow.Cells["colCc_cdesc"].Value.ToString();
                txtColorCategory_edesc.Text = dgvColorCategory.CurrentRow.Cells["colCc_edesc"].Value.ToString();
            }
        }

        private void GetColorCategory(string pCC_id, string pCC_cdesc)
        {
            DataTable dtCC = clsTestProductPlan.GetColorCategory(pCC_id, pCC_cdesc);
            dgvColorCategory.DataSource = dtCC;
            dgvColorCategory.Refresh();
        }

        private void ControlState()
        {
            switch (OperationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        txtColorCategory_id.Enabled = true;
                        txtColorCategory_cdesc.Enabled = true;
                        txtColorCategory_edesc.Enabled = true;

                        txtColorCategory_id.Text = "";
                        txtColorCategory_cdesc.Text = "";
                        txtColorCategory_edesc.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        txtColorCategory_id.Enabled = false;
                        txtColorCategory_cdesc.Enabled = true;
                        txtColorCategory_edesc.Enabled = true;
                    }
                    break;
                case clsUtility.enumOperationType.Delete:
                    {
                        txtColorCategory_id.Text = "";
                        txtColorCategory_cdesc.Text = "";
                        txtColorCategory_edesc.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtColorCategory_id.Enabled = false;
                        txtColorCategory_cdesc.Enabled = false;
                        txtColorCategory_edesc.Enabled = false;

                        txtColorCategory_id.Text = "";
                        txtColorCategory_cdesc.Text = "";
                        txtColorCategory_edesc.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtColorCategory_id.Enabled = false;
                        txtColorCategory_cdesc.Enabled = false;
                        txtColorCategory_edesc.Enabled = false;
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        //btnNew.Enabled = true;
                        //btnEdit.Enabled = true;
                        //btnDelete.Enabled = true;
                        //btnSave.Enabled = false;
                        //btnCancel.Enabled = false;

                        txtColorCategory_id.Enabled = false;
                        txtColorCategory_cdesc.Enabled = false;
                        txtColorCategory_edesc.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
