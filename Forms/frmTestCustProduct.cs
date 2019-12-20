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
    public partial class frmTestCustProduct : Form
    {
        private clsUtility.enumOperationType OperationType;

        public frmTestCustProduct()
        {
            InitializeComponent();
        }

        private void frmTestCustProduct_Load(object sender, EventArgs e)
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
                        if (txtCustProd_id.Text.Trim() != "")
                        {
                            DataTable dtIsExsit = clsTestProductPlan.GetCustProduct(txtCustProd_id.Text.Trim(), "");
                            if (dtIsExsit.Rows.Count > 0)
                            {
                                MessageBox.Show("此編號已存在！");
                                txtCustProd_id.Focus();
                                txtCustProd_id.SelectAll();
                                return;
                            }

                            Result = clsTestProductPlan.AddCustProduct(txtCustProd_id.Text.Trim(), txtCustProd_cdesc.Text.Trim(), txtCustProd_edesc.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("編號不能為空。");
                            txtCustProd_id.Focus();
                            return;
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        Result = clsTestProductPlan.UpdateCustProduct(txtCustProd_id.Text.Trim(), txtCustProd_cdesc.Text.Trim(), txtCustProd_edesc.Text.Trim());
                    }
                    break;
            }

            if (Result > 0)
            {
                GetCustProduct(txtCustProd_id.Text.Trim(), "");
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
                Result = clsTestProductPlan.DeleteCustProduct(dgvCustProduct.CurrentRow.Cells["colCustProd_id"].Value.ToString());
                if (Result > 0)
                {
                    GetCustProduct(txtCustProd_id_sq.Text.Trim(), txtCustProd_cdesc_sq.Text.Trim());
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
            GetCustProduct(txtCustProd_id_sq.Text.Trim(), txtCustProd_cdesc_sq.Text.Trim());
        }

        private void dgvCustProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                return;

            if (dgvCustProduct.Rows.Count > 0)
            {
                txtCustProd_id.Text = dgvCustProduct.CurrentRow.Cells["colCustProd_id"].Value.ToString();
                txtCustProd_cdesc.Text = dgvCustProduct.CurrentRow.Cells["colCustProd_cdesc"].Value.ToString();
                txtCustProd_edesc.Text = dgvCustProduct.CurrentRow.Cells["colCustProd_edesc"].Value.ToString();
            }
        }

        private void GetCustProduct(string CustProd_id, string CustProd_cdesc)
        {
            DataTable dtCustProduct = clsTestProductPlan.GetCustProduct(CustProd_id, CustProd_cdesc);
            dgvCustProduct.DataSource = dtCustProduct;
            dgvCustProduct.Refresh();
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

                        txtCustProd_id.Enabled = true;
                        txtCustProd_cdesc.Enabled = true;
                        txtCustProd_edesc.Enabled = true;

                        txtCustProd_id.Text = "";
                        txtCustProd_cdesc.Text = "";
                        txtCustProd_edesc.Text = "";
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Update:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        txtCustProd_id.Enabled = false;
                        txtCustProd_cdesc.Enabled = true;
                        txtCustProd_edesc.Enabled = true;
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Delete:
                    {
                        txtCustProd_id.Text = "";
                        txtCustProd_cdesc.Text = "";
                        txtCustProd_edesc.Text = "";
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Cancel:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtCustProd_id.Enabled = false;
                        txtCustProd_cdesc.Enabled = false;
                        txtCustProd_edesc.Enabled = false;

                        txtCustProd_id.Text = "";
                        txtCustProd_cdesc.Text = "";
                        txtCustProd_edesc.Text = "";
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Save:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        txtCustProd_id.Enabled = false;
                        txtCustProd_cdesc.Enabled = false;
                        txtCustProd_edesc.Enabled = false;
                    }
                    break;
                case cf01.CLS.clsUtility.enumOperationType.Load:
                    {
                        //btnNew.Enabled = true;
                        //btnEdit.Enabled = true;
                        //btnDelete.Enabled = true;
                        //btnSave.Enabled = false;
                        //btnCancel.Enabled = false;

                        txtCustProd_id.Enabled = false;
                        txtCustProd_cdesc.Enabled = false;
                        txtCustProd_edesc.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }



    }
}
