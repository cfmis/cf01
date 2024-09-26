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
    public partial class frmSale : Form
    {
        private clsUtility.enumOperationType operationType;

        public frmSale()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmSale_Load(object sender, EventArgs e)
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
            Find(txtSalerCode.Text.Trim());
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

                txtSalerCode.Text = dgvDetails.CurrentRow.Cells["colSaleCode"].Value.ToString();
                lueGroup.EditValue = dgvDetails.CurrentRow.Cells["colSaleGroup"].Value.ToString().Trim();
                txtSale_chs_desc.Text = dgvDetails.CurrentRow.Cells["colSale_chs_desc"].Value.ToString();
                txtSale_en_desc.Text = dgvDetails.CurrentRow.Cells["colSale_en_desc"].Value.ToString();
                txtShort_name.Text = dgvDetails.CurrentRow.Cells["colShort_name"].Value.ToString();

                txtSalerCode.Enabled = false;
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
        /// 保存新增或編輯的營業員信息
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                mdlSale objSaler = new mdlSale();
                objSaler.sale_code = txtSalerCode.Text.Trim();
                objSaler.sale_group = lueGroup.EditValue.ToString();
                objSaler.sale_desc = txtSale_en_desc.Text.Trim();
                objSaler.sale_cdesc = txtSale_chs_desc.Text.Trim();
                objSaler.sale_short_name = txtShort_name.Text.Trim();
                objSaler.crusr = DBUtility._user_id;
                objSaler.amusr = DBUtility._user_id;

                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsBs_Sale.AddSaler(objSaler);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsBs_Sale.UpdateSaler(objSaler);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                    operationType = clsUtility.enumOperationType.Save;
                    Find(txtSalerCode.Text.Trim());

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
                    string SaleCode = dgvDetails.CurrentRow.Cells["colSaleCode"].Value.ToString();
                    int Result = clsBs_Sale.DeleteSaler(SaleCode);
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
        private void Find(string pSaleCode)
        {
            this.dgvDetails.DataSource = clsBs_Sale.GetSaler(pSaleCode);
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
            if (txtSalerCode.Text.Trim() == "")
            {
                MessageBox.Show("營業員編號不能為空，請輸入編號。");
                txtSalerCode.Focus();
                return false;
            }

            if (lueGroup.Text.Length > 4)
            {
                MessageBox.Show("所屬組別字符長度不能大於4。");
                lueGroup.Focus();
                lueGroup.SelectAll();
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
                txtSalerCode.Enabled = false;
            }
            else
            {
                txtSalerCode.Enabled = true;
            }
            lueGroup.Enabled = flag;
            txtSale_en_desc.Enabled = flag;
            txtSale_chs_desc.Enabled = flag;
            txtShort_name.Enabled = flag;
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        void TxtBoxClear()
        {
            txtSalerCode.Text = "";
            lueGroup.EditValue = "";
            txtSale_en_desc.Text = "";
            txtSale_chs_desc.Text = "";
            txtShort_name.Text = "";
        }




    }
}
