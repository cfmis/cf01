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
    public partial class frmArtWork : Form
    {
        private clsUtility.enumOperationType operationType;

        public frmArtWork()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmArtWork_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;
            TxtboxEnableIsTrueOrFalse(false);
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

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Find(txtAtr_code_Q.Text.Trim(), txtArt_en_desc_Q.Text.Trim(), txtArt_chs_desc_Q.Text.Trim());
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

                txtArt_code.Text = dgvDetails.CurrentRow.Cells["colArt_code"].Value.ToString();
                lueGroup.EditValue = dgvDetails.CurrentRow.Cells["colArt_group"].Value.ToString().Trim();
                txtArt_en_desc.Text = dgvDetails.CurrentRow.Cells["colArt_en_desc"].Value.ToString();
                txtArt_chs_desc.Text = dgvDetails.CurrentRow.Cells["colArt_chs_desc"].Value.ToString();
                txtArt_brand.Text = dgvDetails.CurrentRow.Cells["colArt_brand"].Value.ToString();
                txtArt_customer.Text = dgvDetails.CurrentRow.Cells["colArt_customer"].Value.ToString();
                txtArt_creater.Text = dgvDetails.CurrentRow.Cells["colArt_creater"].Value.ToString();
                txtArt_image.Text = dgvDetails.CurrentRow.Cells["colArt_image"].Value.ToString();
                txtArt_tech_document.Text = dgvDetails.CurrentRow.Cells["colArt_tech_documents"].Value.ToString();
            }
        }

        private void AddNew()
        {
            operationType = clsUtility.enumOperationType.Add;
            TxtboxEnableIsTrueOrFalse(true);
            TxtBoxClear();

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;
            TxtboxEnableIsTrueOrFalse(true);

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;

        }

        /// <summary>
        /// 保存新增或編輯的圖樣代號信息
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                mdlArtWork objArtWork = new mdlArtWork();
                objArtWork.art_code = txtArt_code.Text.Trim();
                objArtWork.art_group = lueGroup.EditValue.ToString();
                objArtWork.art_desc = txtArt_en_desc.Text.Trim();
                objArtWork.art_cdesc = txtArt_chs_desc.Text.Trim();
                objArtWork.art_brand = txtArt_brand.Text.Trim();
                objArtWork.art_customer = txtArt_customer.Text.Trim();
                objArtWork.art_creater = txtArt_creater.Text.Trim();
                objArtWork.art_image = txtArt_image.Text.Trim();
                objArtWork.art_tech_documents = txtArt_tech_document.Text.Trim();
                objArtWork.crusr = DBUtility._user_id;
                objArtWork.amusr = DBUtility._user_id;

                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsArtWork.AddArtWork(objArtWork);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsArtWork.UpdateArtWork(objArtWork);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                    operationType = clsUtility.enumOperationType.Save;

                    Find(txtArt_code.Text.Trim(), "", "");

                    TxtboxEnableIsTrueOrFalse(false);
                    BTNNEW.Enabled = true;
                    BTNEDIT.Enabled = true;
                    BTNSAVE.Enabled = false;
                    BTNDELETE.Enabled = true;

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
                    string Art_code = dgvDetails.CurrentRow.Cells["colArt_code"].Value.ToString();
                    int Result = clsArtWork.DeleteArtWork(Art_code);
                    if (Result > 0)
                    {
                        operationType = clsUtility.enumOperationType.Delete;
                        MessageBox.Show("刪除成功！");
                        Find("", "", "");
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
        private void Find(string pArtCode, string pArt_en_desc, string pArt_chs_desc)
        {
            this.dgvDetails.DataSource = clsArtWork.GetArtWork(pArtCode, pArt_en_desc, pArt_chs_desc);
            this.dgvDetails.Refresh();
        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;
            TxtboxEnableIsTrueOrFalse(false);
            TxtBoxClear();

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNSAVE.Enabled = false;
            BTNDELETE.Enabled = true;
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
            if (txtArt_code.Text.Trim() == "")
            {
                MessageBox.Show("圖樣編號不能為空，請輸入編號。");
                txtArt_code.Focus();
                return false;
            }
           
            return true;
        }

        /// <summary>
        /// 文本框是否可用
        /// </summary>
        /// <param name="flag"></param>
        void TxtboxEnableIsTrueOrFalse(bool flag)
        {
            if (operationType == clsUtility.enumOperationType.Add)
            {
                txtArt_code.Enabled = true;
            }
            else
            {
                txtArt_code.Enabled = false;
            }
            lueGroup.Enabled = flag;
            txtArt_en_desc.Enabled = flag;
            txtArt_chs_desc.Enabled = flag;
            txtArt_brand.Enabled = flag;
            txtArt_customer.Enabled = flag;
            txtArt_creater.Enabled = flag;
            txtArt_image.Enabled = flag;
            txtArt_tech_document.Enabled = flag;
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        void TxtBoxClear()
        {
            txtArt_code.Text = "";
            lueGroup.EditValue = "";
            txtArt_en_desc.Text = "";
            txtArt_chs_desc.Text = "";
            txtArt_brand.Text = "";
            txtArt_customer.Text = "";
            txtArt_creater.Text = "";
            txtArt_image.Text = "";
            txtArt_tech_document.Text = "";
        }




    }
}
