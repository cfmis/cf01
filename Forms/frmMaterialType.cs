using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmMaterialType : Form
    {
        private clsUtility.enumOperationType operationType;

        public frmMaterialType()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmMaterialType_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;
            TxtBoxIsTrueOrFalse(false);
            BTNSAVE.Enabled = false;

            BindGroup();
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
            Find(txtMat_code.Text.Trim());
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
                if (e.RowIndex == -1)
                    return;

                txtMat_code.Text = dgvDetails.CurrentRow.Cells["colMat_code"].Value.ToString();
                lueGroup.EditValue = dgvDetails.CurrentRow.Cells["colMat_group"].Value.ToString().Trim();
                txtMat_chs_desc.Text = dgvDetails.CurrentRow.Cells["colMat_chs_desc"].Value.ToString();
                txtMat_en_desc.Text = dgvDetails.CurrentRow.Cells["colMat_en_desc"].Value.ToString();

                txtMat_code.Enabled = false;
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

        /// <summary>
        /// 保存新增或編輯的物料種類信息
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                mdlMaterialType objMat_type = new mdlMaterialType();
                objMat_type.mat_code = txtMat_code.Text.Trim();
                objMat_type.mat_group = lueGroup.EditValue.ToString();
                objMat_type.mat_desc = txtMat_en_desc.Text.Trim();
                objMat_type.mat_cdesc = txtMat_chs_desc.Text.Trim();
                objMat_type.crusr = DBUtility._user_id;
                objMat_type.amusr = DBUtility._user_id;

                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsMaterialType.AddMaterialType(objMat_type);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsMaterialType.UpdateMaterialType(objMat_type);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                    operationType = clsUtility.enumOperationType.Save;
                    Find(txtMat_code.Text.Trim());

                    TxtBoxIsTrueOrFalse(false);
                    BTNNEW.Enabled = true;
                    BTNEDIT.Enabled = true;
                    BTNSAVE.Enabled = false;
                    BTNDELETE.Enabled = true;
                    BTNFIND.Enabled = true;
                }
                else
                {
                    MessageBox.Show("保存失敗！");
                }
            }
        }

        private void Delete()
        {
            if (dgvDetails.RowCount > 0)
            {
                if (MessageBox.Show("確定要刪除該條數據？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mat_code = dgvDetails.CurrentRow.Cells["colMat_code"].Value.ToString();
                    int Result = clsMaterialType.DeleteMaterialType(Mat_code);
                    if (Result > 0)
                    {
                        MessageBox.Show("刪除成功！");
                        operationType = clsUtility.enumOperationType.Delete;
                        Find("");
                        TxtBoxClear();
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗！");
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可進行刪除的數據。");
            }
        }

        /// <summary>
        /// 根據條件查詢
        /// </summary>
        /// <param name="pSaleCode"></param>
        private void Find(string pMatCode)
        {
            this.dgvDetails.DataSource = clsMaterialType.GetMaterialType(pMatCode);
            this.dgvDetails.Refresh();
        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;
            TxtBoxIsTrueOrFalse(false);
            TxtBoxClear();

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNSAVE.Enabled = false;
            BTNDELETE.Enabled = true;
            BTNFIND.Enabled = true;
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

        /// <summary>
        /// 文本框驗證
        /// </summary>
        /// <returns></returns>
        private bool ValidateText()
        {
            if (txtMat_code.Text.Trim() == "")
            {
                MessageBox.Show("物料種類編號不能為空，請輸入編號。");
                txtMat_code.Focus();
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
                txtMat_code.Enabled = false;
            }
            else
            {
                txtMat_code.Enabled = true;
            }
            lueGroup.Enabled = flag;
            txtMat_en_desc.Enabled = flag;
            txtMat_chs_desc.Enabled = flag;
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        void TxtBoxClear()
        {
            txtMat_code.Text = "";
            lueGroup.EditValue = "";
            txtMat_en_desc.Text = "";
            txtMat_chs_desc.Text = "";
        }

 

    }
}
