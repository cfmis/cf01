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
    public partial class frmTestProductType : Form
    {
        private clsUtility.enumOperationType OperationType;

        public frmTestProductType()
        {
            InitializeComponent();
        }

        private void frmTestProductType_Load(object sender, EventArgs e)
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
                case cf01.CLS.clsUtility.enumOperationType.Add:
                    {
                        if (txtPT_id.Text != "")
                        {
                            DataTable dtIsExsit = clsTestProductPlan.GetProductType(txtPT_id.Text.Trim(), "");
                            if (dtIsExsit.Rows.Count > 0)
                            {
                                MessageBox.Show("此編號已存在，請重新輸入。");
                                txtPT_id.Focus();
                                txtPT_id.SelectAll();
                                return;
                            }

                            Result = clsTestProductPlan.AddProductType(txtPT_id.Text.Trim(), txtPT_cdesc.Text.Trim(), txtPT_edesc.Text.Trim(), txtRemark.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("編號不能為空。");
                            txtPT_id.Focus();
                            return;
                        }
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Update:
                    {
                        Result = clsTestProductPlan.UpdateProductType(txtPT_id.Text, txtPT_cdesc.Text.Trim(), txtPT_edesc.Text.Trim(), txtRemark.Text.Trim());
                    }
                    break;
            }
            if (Result > 0)
            {
                GetProductType(txtPT_id.Text.Trim(), "");
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
                Result = clsTestProductPlan.DeleteProductType(dgvProductType.CurrentRow.Cells["colPt_id"].Value.ToString());
                if (Result > 0)
                {
                    GetProductType(txtPT_id_sq.Text.Trim(), txtPT_cdesc_sq.Text.Trim());
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
            GetProductType(txtPT_id_sq.Text.Trim(), txtPT_cdesc_sq.Text.Trim());
        }

        private void dgvProductType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                return;

            if (dgvProductType.Rows.Count > 0)
            {
                txtPT_id.Text = dgvProductType.CurrentRow.Cells["colPt_id"].Value.ToString();
                txtPT_cdesc.Text = dgvProductType.CurrentRow.Cells["colPt_cdesc"].Value.ToString();
                txtPT_edesc.Text = dgvProductType.CurrentRow.Cells["colPt_edesc"].Value.ToString();
                txtRemark.Text = dgvProductType.CurrentRow.Cells["colRemark"].Value.ToString();
            }
        }

        private void GetProductType(string Pt_id, string Pt_cdesc)
        {
            DataTable dtPt = clsTestProductPlan.GetProductType(Pt_id, Pt_cdesc);
            dgvProductType.DataSource = dtPt;
            dgvProductType.Refresh();
        }

        private void ControlState()
        {
            switch (OperationType)
            {
                case cf01.CLS.clsUtility.enumOperationType.Add:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        txtPT_id.Enabled = true;
                        txtPT_cdesc.Enabled = true;
                        txtPT_edesc.Enabled = true;
                        txtRemark.Enabled = true;

                        txtPT_id.Text = "";
                        txtPT_cdesc.Text = "";
                        txtPT_edesc.Text = "";
                        txtRemark.Text = "";
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Update:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        txtPT_id.Enabled = false;
                        txtPT_cdesc.Enabled = true;
                        txtPT_edesc.Enabled = true;
                        txtRemark.Enabled = true;
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Delete:
                    {
                        txtPT_id.Text = "";
                        txtPT_cdesc.Text = "";
                        txtPT_edesc.Text = "";
                        txtRemark.Text = "";
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Cancel:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtPT_id.Enabled = false;
                        txtPT_cdesc.Enabled = false;
                        txtPT_edesc.Enabled = false;
                        txtRemark.Enabled = false;

                        txtPT_id.Text = "";
                        txtPT_cdesc.Text = "";
                        txtPT_edesc.Text = "";
                        txtRemark.Text = "";
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Save:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtPT_id.Enabled = false;
                        txtPT_cdesc.Enabled = false;
                        txtPT_edesc.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Load:
                    {
                        //btnNew.Enabled = true;
                        //btnEdit.Enabled = true;
                        //btnDelete.Enabled = true;
                        //btnSave.Enabled = false;
                        //btnCancel.Enabled = false;

                        txtPT_id.Enabled = false;
                        txtPT_cdesc.Enabled = false;
                        txtPT_edesc.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
