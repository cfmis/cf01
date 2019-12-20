using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.MDL;
using RUI.PC;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmVendor : Form
    {

        private clsUtility.enumOperationType operationType;
        private DataTable dtVendor = new DataTable();

        public frmVendor()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;
            TxtboxEnabledIsTrueOrFalse(false);
            TxtboxTips();
            BindCombox();

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

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Find(txtVendcode_Q.Text.Trim(), txtVend_en_name_Q.Text.Trim(), txtVend_chs_name_Q.Text.Trim());
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (e.RowIndex == -1)
                    return;

                txtVendcode.Text = dtVendor.Rows[e.RowIndex]["vendor_id"].ToString();
                txtVendtype.Text = dtVendor.Rows[e.RowIndex]["vendtype"].ToString();
                txtVend_en_name.Text = dtVendor.Rows[e.RowIndex]["vendname"].ToString();
                txtVend_chs_name.Text = dtVendor.Rows[e.RowIndex]["vendor_name"].ToString();
                txtVendcounn.Text = dtVendor.Rows[e.RowIndex]["account"].ToString();
                txtVendctact.Text = dtVendor.Rows[e.RowIndex]["contacts"].ToString();
                txtVendtel.Text = dtVendor.Rows[e.RowIndex]["tel"].ToString();
                txtVendfax.Text = dtVendor.Rows[e.RowIndex]["fax"].ToString();
                txtVendemail.Text = dtVendor.Rows[e.RowIndex]["email"].ToString();
                txtVendpterm.Text = dtVendor.Rows[e.RowIndex]["terms"].ToString();
                cmbVendcurr.Text = dtVendor.Rows[e.RowIndex]["m_id"].ToString();
                mktxtVendopen.Text = dtVendor.Rows[e.RowIndex]["opening"].ToString();
                mktVendclose.Text = dtVendor.Rows[e.RowIndex]["logout"].ToString();
                txtVendrmk.Text = dtVendor.Rows[e.RowIndex]["remark"].ToString();
                txtVend_longen_name.Text = dtVendor.Rows[e.RowIndex]["vendlname"].ToString();
                txtVend_longchs_name.Text = dtVendor.Rows[e.RowIndex]["vendlcname"].ToString();
                txtVend_en_add1.Text = dtVendor.Rows[e.RowIndex]["address_en"].ToString();
                txtVend_en_add2.Text = dtVendor.Rows[e.RowIndex]["vendadd2"].ToString();
                txtVend_en_add3.Text = dtVendor.Rows[e.RowIndex]["vendadd3"].ToString();
                txtVend_chs_add1.Text = dtVendor.Rows[e.RowIndex]["address_chs"].ToString();
                txtVend_chs_add2.Text = dtVendor.Rows[e.RowIndex]["vendcadd2"].ToString();
                txtVend_chs_add3.Text = dtVendor.Rows[e.RowIndex]["vendcadd3"].ToString();

            }
        }

        private void AddNew()
        {
            operationType = clsUtility.enumOperationType.Add;
            TxtboxEnabledIsTrueOrFalse(true);
            TxtboxClear();

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;
            TxtboxEnabledIsTrueOrFalse(true);

            BTNSAVE.Enabled = true;
            BTNNEW.Enabled = false;
            BTNDELETE.Enabled = false;
            BTNEDIT.Enabled = false;
        }

        /// <summary>
        /// 保存新增或編輯的供應商信息
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                mdlVendor objVendor = new mdlVendor();
                objVendor.vendcode = txtVendcode.Text.Trim();
                objVendor.vendtype = txtVendtype.Text.Trim();
                objVendor.vendname = txtVend_en_name.Text.Trim();
                objVendor.vendlname = txtVend_longen_name.Text.Trim();
                objVendor.vendcname = txtVend_chs_name.Text.Trim();
                objVendor.vendlcname = txtVend_longchs_name.Text.Trim();
                objVendor.vendcoun = txtVendcounn.Text.Trim();
                objVendor.vendctact = txtVendctact.Text.Trim();
                objVendor.vendtel = txtVendtel.Text.Trim();
                objVendor.vendfax = txtVendfax.Text.Trim();
                objVendor.vendemail = txtVendemail.Text.Trim();
                objVendor.vendpterm = txtVendpterm.Text.Trim();
                objVendor.vendadd1 = txtVend_en_add1.Text.Trim();
                objVendor.vendadd2 = txtVend_en_add2.Text.Trim();
                objVendor.vendadd3 = txtVend_en_add3.Text.Trim();
                objVendor.vendcadd1 = txtVend_chs_add1.Text.Trim();
                objVendor.vendcadd2 = txtVend_chs_add2.Text.Trim();
                objVendor.vendcadd3 = txtVend_chs_add3.Text.Trim();
                objVendor.vendcurr = cmbVendcurr.Text;
                objVendor.vendopen = mktxtVendopen.Text.Trim();
                objVendor.vendclose = mktVendclose.Text.Trim();
                objVendor.vendrmk = txtVendrmk.Text.Trim();

                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsVendor.AddVendor(objVendor);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsVendor.UpdateVendor(objVendor);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    operationType = clsUtility.enumOperationType.Save;
                    MessageBox.Show("保存成功！");
                    TxtboxEnabledIsTrueOrFalse(false);

                    BTNSAVE.Enabled = false;
                    BTNNEW.Enabled = true;
                    BTNEDIT.Enabled = true;
                    BTNDELETE.Enabled = true;

                    Find(txtVendcode.Text.Trim(), "", "");

                }
                else
                {
                    MessageBox.Show("保存失敗！");
                }
            }
        }


        /// <summary>
        ///刪除供應商信息 
        /// </summary>
        private void Delete()
        {
            if (this.dgvDetails.Rows.Count > 0)
            {
                if (MessageBox.Show("確定要刪除該數據嗎？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strVendorId = this.dgvDetails.CurrentRow.Cells["colVendor_id"].Value.ToString();
                    int Result = clsVendor.DeleteVendor(strVendorId);
                    if (Result > 0)
                    {
                        operationType = clsUtility.enumOperationType.Delete;
                        MessageBox.Show("刪除成功！");
                        Find("", "", "");
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗！");
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有數據可以刪除。");
            }
        }

        /// <summary>
        /// 根據條件查詢供應商信息
        /// </summary>
        /// <param name="pVendcode"></param>
        /// <param name="pVendname"></param>
        /// <param name="pVendcname"></param>
        private void Find(string pVendcode, string pVendname, string pVendcname)
        {
            dtVendor = clsVendor.GetVendors(pVendcode, pVendname, pVendcname);

            this.dgvDetails.DataSource = dtVendor;
            this.dgvDetails.Refresh();
        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;
            TxtboxEnabledIsTrueOrFalse(false);
            TxtboxClear();
            TxtboxTips();

            BTNSAVE.Enabled = false;
            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNDELETE.Enabled = true;
        }

        /// <summary>
        /// 文本框變為可用
        /// </summary>
        void TxtboxEnabledIsTrueOrFalse(bool flag)
        {
            if (operationType == clsUtility.enumOperationType.Add)
            {
                txtVendcode.Enabled = true;
            }
            else
            {
                txtVendcode.Enabled = false;
            }
            txtVendtype.Enabled = flag;
            txtVend_en_name.Enabled = flag;
            txtVend_longen_name.Enabled = flag;
            txtVend_chs_name.Enabled = flag;
            txtVend_longchs_name.Enabled = flag;
            txtVendcounn.Enabled = flag;
            txtVendctact.Enabled = flag;
            txtVendtel.Enabled = flag;
            txtVendfax.Enabled = flag;
            txtVendemail.Enabled = flag;
            txtVendpterm.Enabled = flag;
            txtVend_en_add1.Enabled = flag;
            txtVend_en_add2.Enabled = flag;
            txtVend_en_add3.Enabled = flag;
            txtVend_chs_add1.Enabled = flag;
            txtVend_chs_add2.Enabled = flag;
            txtVend_chs_add3.Enabled = flag;
            cmbVendcurr.Enabled = flag;
            mktxtVendopen.Enabled = flag;
            mktVendclose.Enabled = flag;
            txtVendrmk.Enabled = flag;
        }

        /// <summary>
        ///文本框清空 
        /// </summary>
        void TxtboxClear()
        {
            txtVendcode.Text = "";
            txtVendtype.Text = "";
            txtVend_en_name.Text = "";
            txtVend_chs_name.Text = "";
            txtVendcounn.Text = "";
            txtVendctact.Text = "";
            txtVendtel.Text = "";
            txtVendfax.Text = "";
            txtVendemail.Text = "";
            txtVendpterm.Text = "";
            cmbVendcurr.Text = "";
            mktxtVendopen.Text = "";
            mktVendclose.Text = "";
            txtVendrmk.Text = "";
        }

        /// <summary>
        /// 文本框提示
        /// </summary>
        void TxtboxTips()
        {
            txtVend_longen_name.Text = "供應商英文全稱";
            txtVend_longchs_name.Text = "供應商中文全稱";
            txtVend_en_add1.Text = "英文地址1";
            txtVend_en_add2.Text = "英文地址2";
            txtVend_en_add3.Text = "英文地址3";
            txtVend_chs_add1.Text = "中文地址1";
            txtVend_chs_add2.Text = "中文地址2";
            txtVend_chs_add3.Text = "中文地址3";
        }

        /// <summary>
        /// 綁定貨幣類型
        /// </summary>
        void BindCombox()
        {
            cmbVendcurr.Items.Add("USD");
            cmbVendcurr.Items.Add("HKD");
            cmbVendcurr.Items.Add("RMB");
        }

        /// <summary>
        /// 文本框驗證
        /// </summary>
        /// <returns></returns>
        private bool ValidateText()
        {
            if (txtVendcode.Text.Trim() == "")
            {
                MessageBox.Show("供應商編號不能為空。");
                txtVendcode.Focus();
                return false;
            }

            if (txtVend_en_name.Text.Trim() == "" && txtVend_chs_name.Text.Trim() == "")
            {
                MessageBox.Show("供應商名稱不能都為空，請輸入中文或英文名稱。");
                txtVend_en_name.Focus();
                return false;
            }

            if (!Verify.StringValidating(txtVendtel.Text.Trim(), Verify.enumValidatingType.AllNumber))
            {
                MessageBox.Show("電話號碼為數字格式，請輸入正確的格式。");
                txtVendtel.Focus();
                txtVendtel.SelectAll();
                return false;
            }

            if (txtVendemail.Text.Trim() != "")
            {
                if (!clsValidRule.IsEmail(txtVendemail.Text.Trim()))
                {
                    MessageBox.Show("郵箱格式不正確，請重新輸入。");
                    txtVendemail.Focus();
                    txtVendemail.SelectAll();
                    return false;
                }
            }

            if (mktxtVendopen.Text.Trim().Length == 10)
            {
                if (!clsValidRule.CheckDateFormat(mktxtVendopen.Text.Trim()))
                {
                    MessageBox.Show("開戶日期日期格式不正確，請輸入正確的格式(yyyy/MM/dd)。");
                    mktxtVendopen.Focus();
                    mktxtVendopen.SelectAll();
                    return false;
                }
            }

            if (mktVendclose.Text.Trim().Length == 10)
            {
                if (!clsValidRule.CheckDateFormat(mktVendclose.Text.Trim()))
                {
                    MessageBox.Show("註銷日期格式不正確，請輸入正確的格式(yyyy/MM/dd)。");
                    mktVendclose.Focus();
                    mktVendclose.SelectAll();
                    return false;
                }
            }

            return true;
        }

        private void txtVend_longen_name_Enter(object sender, EventArgs e)
        {
            txtVend_longen_name.Text = "";
        }

        private void txtVend_longchs_name_Enter(object sender, EventArgs e)
        {
            txtVend_longchs_name.Text = "";
        }

        private void txtVend_en_add1_Enter(object sender, EventArgs e)
        {
            txtVend_en_add1.Text = "";
        }

        private void txtVend_en_add2_Enter(object sender, EventArgs e)
        {
            txtVend_en_add2.Text = "";
        }

        private void txtVend_en_add3_Enter(object sender, EventArgs e)
        {
            txtVend_en_add3.Text = "";
        }

        private void txtVend_chs_add1_Enter(object sender, EventArgs e)
        {
            txtVend_chs_add1.Text = "";
        }

        private void txtVend_chs_add2_Enter(object sender, EventArgs e)
        {
            txtVend_chs_add2.Text = "";
        }

        private void txtVend_chs_add3_Enter(object sender, EventArgs e)
        {
            txtVend_chs_add3.Text = "";
        }





    }
}
