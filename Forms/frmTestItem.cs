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
    public partial class frmTestItem : Form
    {
        private clsUtility.enumOperationType OperationType;

        public frmTestItem()
        {
            InitializeComponent();
        }

        private void frmTestItem_Load(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Load;
            ControlState();

            clsControlInfoHelper formInit = new clsControlInfoHelper(this.Name, this.Controls);
            formInit.GenerateContorl();
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
                        if (txtItem_id.Text != "")
                        {
                            DataTable dtIsExsit = clsTestProductPlan.GetTestItem(txtItem_id.Text.Trim(), "");
                            if (dtIsExsit.Rows.Count > 0)
                            {
                                MessageBox.Show("此編號已存在，請重新輸入。");
                                txtItem_id.Focus();
                                txtItem_id.SelectAll();
                                return;
                            }

                            Result = clsTestProductPlan.AddTestItem(txtItem_id.Text, txtItem_cdesc.Text.Trim(), txtItem_edesc.Text.Trim(), txtRemark.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("編號不能為空。");
                            txtItem_id.Focus();
                            return;
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        Result = clsTestProductPlan.UpdateTestItem(txtItem_id.Text, txtItem_cdesc.Text.Trim(), txtItem_edesc.Text.Trim(), txtRemark.Text.Trim());
                    }
                    break;
            }

            if (Result > 0)
            {
                GetTestItem(txtItem_id.Text.Trim(), "");
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
                Result = clsTestProductPlan.DeleteTestItem(dgvTestItem.CurrentRow.Cells["colItem_id"].Value.ToString());
                if (Result > 0)
                {
                    GetTestItem(txtItem_id_sq.Text.Trim(), txtItem_cdesc_sq.Text.Trim());
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
            GetTestItem(txtItem_id_sq.Text.Trim(), txtItem_cdesc_sq.Text.Trim());
        }

        private void dgvTestItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                return;

            if (dgvTestItem.Rows.Count > 0)
            {
                txtItem_id.Text = dgvTestItem.CurrentRow.Cells["colItem_id"].Value.ToString();
                txtItem_cdesc.Text = dgvTestItem.CurrentRow.Cells["colItem_cdesc"].Value.ToString();
                txtItem_edesc.Text = dgvTestItem.CurrentRow.Cells["colItem_edesc"].Value.ToString();
                txtRemark.Text = dgvTestItem.CurrentRow.Cells["colRemark"].Value.ToString();
            }
        }

        private void GetTestItem(string Item_id, string Item_cedesc)
        {
            DataTable dtItem = clsTestProductPlan.GetTestItem(Item_id, Item_cedesc);
            dgvTestItem.DataSource = dtItem;
            dgvTestItem.Refresh();
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

                        txtItem_id.Enabled = true;
                        txtItem_cdesc.Enabled = true;
                        txtItem_edesc.Enabled = true;
                        txtRemark.Enabled = true;

                        txtItem_id.Text = "";
                        txtItem_cdesc.Text = "";
                        txtItem_edesc.Text = "";
                        txtRemark.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        txtItem_id.Enabled = false;
                        txtItem_cdesc.Enabled = true;
                        txtItem_edesc.Enabled = true;
                        txtRemark.Enabled = true;
                    }
                    break;
                case clsUtility.enumOperationType.Delete:
                    {
                        txtItem_id.Text = "";
                        txtItem_cdesc.Text = "";
                        txtItem_edesc.Text = "";
                        txtRemark.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtItem_id.Enabled = false;
                        txtItem_cdesc.Enabled = false;
                        txtItem_edesc.Enabled = false;
                        txtRemark.Enabled = false;

                        txtItem_id.Text = "";
                        txtItem_cdesc.Text = "";
                        txtItem_edesc.Text = "";
                        txtRemark.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtItem_id.Enabled = false;
                        txtItem_cdesc.Enabled = false;
                        txtItem_edesc.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtItem_id.Enabled = false;
                        txtItem_cdesc.Enabled = false;
                        txtItem_edesc.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }



    }
}
