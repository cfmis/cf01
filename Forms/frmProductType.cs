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
    public partial class frmProductType : Form
    {
        private clsUtility.enumOperationType operationType;

        public frmProductType()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmProductType_Load(object sender, EventArgs e)
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
            Find(txtPrd_code.Text.Trim());
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

                txtPrd_code.Text = dgvDetails.CurrentRow.Cells["colPrd_type_code"].Value.ToString();
                lueGroup.EditValue = dgvDetails.CurrentRow.Cells["colPrd_group"].Value.ToString().Trim();
                txtPrd_en_desc.Text = dgvDetails.CurrentRow.Cells["colPrd_en_desc"].Value.ToString();
                txtPrd_chs_desc.Text = dgvDetails.CurrentRow.Cells["colPrd_chs_desc"].Value.ToString();

                txtPrd_code.Enabled = false;
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
        /// 保存新增或編輯的產品種類信息
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                mdlProductType objPrd_type = new mdlProductType();
                objPrd_type.prd_code = txtPrd_code.Text.Trim();
                objPrd_type.prd_group = lueGroup.EditValue.ToString();
                objPrd_type.prd_desc = txtPrd_en_desc.Text.Trim();
                objPrd_type.prd_cdesc = txtPrd_chs_desc.Text.Trim();
                objPrd_type.crusr = DBUtility._user_id;
                objPrd_type.amusr = DBUtility._user_id;

                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsProductType.AddProductType(objPrd_type);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsProductType.UpdateProductType(objPrd_type);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                    operationType = clsUtility.enumOperationType.Save;
                    Find(txtPrd_code.Text.Trim());

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
                    string Prd_code = dgvDetails.CurrentRow.Cells["colPrd_type_code"].Value.ToString();
                    int Result = clsProductType.DeleteProductType(Prd_code);
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
        private void Find(string pPrdCode)
        {
            this.dgvDetails.DataSource = clsProductType.GetProductType(pPrdCode);
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
            lueGroup.Properties.ValueMember = "grp_code";
            lueGroup.Properties.DisplayMember = "grp_code";
        }


        /// <summary>
        /// 文本框驗證
        /// </summary>
        /// <returns></returns>
        private bool ValidateText()
        {
            if (txtPrd_code.Text.Trim() == "")
            {
                MessageBox.Show("產品種類編號不能為空，請輸入編號。");
                txtPrd_code.Focus();
                return false;
            }

            if (lueGroup.Text == "")
            {
                MessageBox.Show("請選擇所屬組別。");
                lueGroup.Focus();
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
                txtPrd_code.Enabled = false;
            }
            else
            {
                txtPrd_code.Enabled = true;
            }
            lueGroup.Enabled = flag;
            txtPrd_en_desc.Enabled = flag;
            txtPrd_chs_desc.Enabled = flag;
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        void TxtBoxClear()
        {
            txtPrd_code.Text = "";
            lueGroup.EditValue = "";
            txtPrd_en_desc.Text = "";
            txtPrd_chs_desc.Text = "";
        }

    }
}
