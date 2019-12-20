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
    public partial class frmTestMatType : Form
    {
        private clsUtility.enumOperationType OperationType;

        public frmTestMatType()
        {
            InitializeComponent();

            clsControlInfoHelper formInit = new clsControlInfoHelper(this.Name, this.Controls);
            formInit.GenerateContorl();
        }

        private void frmTestMatType_Load(object sender, EventArgs e)
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
                        if (txtMat_id.Text != "")
                        {
                            DataTable dtIsExsit = clsTestProductPlan.GetMatTypeData(txtMat_id.Text.Trim(), "");
                            if (dtIsExsit.Rows.Count > 0)
                            {
                                MessageBox.Show("此材料編號已存在。");
                                txtMat_id.Focus();
                                txtMat_id.SelectAll();
                                return;
                            }

                            Result = clsTestProductPlan.AddMatType(txtMat_id.Text.Trim(), txtMat_cdesc.Text.Trim(), txtMat_edesc.Text.Trim(), txtSeq_id.Text.Trim(), txtRemark.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("編號不能為空。");
                            txtMat_id.Focus();
                            return;
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        Result = clsTestProductPlan.UpdateMatType(txtMat_id.Text.Trim(), txtMat_cdesc.Text.Trim(), txtMat_edesc.Text.Trim(), txtSeq_id.Text.Trim(), txtRemark.Text.Trim());
                    }
                    break;
            }
            if (Result > 0)
            {
                GetMat_type(txtMat_id.Text.Trim(), txtMat_cdesc.Text.Trim());
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
                if (dgvMat_type.Rows.Count > 0)
                {
                    int Result = 0;
                    Result = clsTestProductPlan.DeleteMatType(dgvMat_type.CurrentRow.Cells["colMat_id"].Value.ToString());
                    if (Result > 0)
                    {
                        GetMat_type(txtMat_id_sq.Text.Trim(), txtMat_name_sq.Text.Trim());
                        OperationType = clsUtility.enumOperationType.Delete;
                        ControlState();
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗！");
                    }
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
            GetMat_type(txtMat_id_sq.Text.Trim(), txtMat_name_sq.Text.Trim());
        }

        private void GetMat_type(string mat_id, string mat_name)
        {
            DataTable dtMat_type = clsTestProductPlan.GetMatTypeData(mat_id, mat_name);
            dgvMat_type.DataSource = dtMat_type;
            dgvMat_type.Refresh();
        }

        private void dgvMat_type_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                return;

            if (dgvMat_type.Rows.Count > 0)
            {
                txtMat_id.Text = dgvMat_type.CurrentRow.Cells["colMat_id"].Value.ToString();
                txtMat_cdesc.Text = dgvMat_type.CurrentRow.Cells["colMat_cdesc"].Value.ToString();
                txtMat_edesc.Text = dgvMat_type.CurrentRow.Cells["colMat_edesc"].Value.ToString();
                txtSeq_id.Text = dgvMat_type.CurrentRow.Cells["colSeq_id"].Value.ToString();
                txtRemark.Text = dgvMat_type.CurrentRow.Cells["colRemark"].Value.ToString();
            }
        }

        /// <summary>
        /// 控制表單控件的狀體
        /// </summary>
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

                        txtMat_id.Enabled = true;
                        txtMat_cdesc.Enabled = true;
                        txtMat_edesc.Enabled = true;
                        txtSeq_id.Enabled = true;
                        txtRemark.Enabled = true;

                        txtMat_id.Text = "";
                        txtMat_cdesc.Text = "";
                        txtMat_edesc.Text = "";
                        txtSeq_id.Text = "";
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

                        txtMat_id.Enabled = false;
                        txtMat_cdesc.Enabled = true;
                        txtMat_edesc.Enabled = true;
                        txtSeq_id.Enabled = true;
                        txtRemark.Enabled = true;
                    }
                    break;
                case clsUtility.enumOperationType.Delete:
                    {
                        txtMat_id.Text = "";
                        txtMat_cdesc.Text = "";
                        txtMat_edesc.Text = "";
                        txtSeq_id.Text = "";
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

                        txtMat_id.Enabled = false;
                        txtMat_cdesc.Enabled = false;
                        txtMat_edesc.Enabled = false;
                        txtSeq_id.Enabled = false;
                        txtRemark.Enabled = false;

                        txtMat_id.Text = "";
                        txtMat_cdesc.Text = "";
                        txtMat_edesc.Text = "";
                        txtSeq_id.Text = "";
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

                        txtMat_id.Enabled = false;
                        txtMat_cdesc.Enabled = false;
                        txtMat_edesc.Enabled = false;
                        txtSeq_id.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        //btnNew.Enabled = true;
                        //btnEdit.Enabled = true;
                        //btnDelete.Enabled = true;
                        //btnSave.Enabled = false;
                        //btnCancel.Enabled = false;

                        txtMat_id.Enabled = false;
                        txtMat_cdesc.Enabled = false;
                        txtMat_edesc.Enabled = false;
                        txtSeq_id.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
