using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.MDL;
using RUI.PC;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmCustomerInfo : Form
    {
        private DataTable dtCustInfo = new DataTable();
        private clsUtility.enumOperationType operationType;

        public frmCustomerInfo()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(Name, Controls);
            control.GenerateContorl();
        }

        private void frmCustomerInfo_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;
            TxtboxEnabledIsTrueOrFalse(false);
            TxtboxTips();
            BindComboxCurr();
            BindComboxArea();

            BTNSAVE.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
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
            Find(txtCustcode_Q.Text.Trim(), txtCust_en_name_Q.Text.Trim(), txtCust_chs_name_Q.Text.Trim());
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

                txtCustcode.Text = dtCustInfo.Rows[e.RowIndex]["custcode"].ToString();
                txtCusttype.Text = dtCustInfo.Rows[e.RowIndex]["custtype"].ToString();
                txtCust_en_name.Text = dtCustInfo.Rows[e.RowIndex]["custname"].ToString();
                txtCust_chs_name.Text = dtCustInfo.Rows[e.RowIndex]["custcname"].ToString();
                txtCustcounn.Text = dtCustInfo.Rows[e.RowIndex]["account"].ToString();
                txtCustctact.Text = dtCustInfo.Rows[e.RowIndex]["contacts"].ToString();
                txtCusttel.Text = dtCustInfo.Rows[e.RowIndex]["tel"].ToString();
                txtCustfax.Text = dtCustInfo.Rows[e.RowIndex]["fax"].ToString();
                txtCustemail.Text = dtCustInfo.Rows[e.RowIndex]["email"].ToString();
                txtCustpterm.Text = dtCustInfo.Rows[e.RowIndex]["terms"].ToString();
                cmbCustcurr.Text = dtCustInfo.Rows[e.RowIndex]["m_id"].ToString();
                mktxtCustopen.Text = dtCustInfo.Rows[e.RowIndex]["opening"].ToString();
                mktxtCustclose.Text = dtCustInfo.Rows[e.RowIndex]["logout"].ToString();
                txtCustrmk.Text = dtCustInfo.Rows[e.RowIndex]["remark"].ToString();
                txtcust_longen_name.Text = dtCustInfo.Rows[e.RowIndex]["custlname"].ToString();
                txtCust_longchs_name.Text = dtCustInfo.Rows[e.RowIndex]["custlcname"].ToString();
                txtCust_en_add1.Text = dtCustInfo.Rows[e.RowIndex]["address_en"].ToString();
                txtCust_en_add2.Text = dtCustInfo.Rows[e.RowIndex]["custadd2"].ToString();
                txtCust_en_add3.Text = dtCustInfo.Rows[e.RowIndex]["custadd3"].ToString();
                txtCust_chs_add1.Text = dtCustInfo.Rows[e.RowIndex]["address_chs"].ToString();
                txtCust_chs_add2.Text = dtCustInfo.Rows[e.RowIndex]["custcadd2"].ToString();
                txtCust_chs_add3.Text = dtCustInfo.Rows[e.RowIndex]["custcadd3"].ToString();
                cmbArea.Text = dtCustInfo.Rows[e.RowIndex]["custarea"].ToString();
            }
        }

        private void AddNew()
        {
            operationType = clsUtility.enumOperationType.Add;
            TxtboxEnabledIsTrueOrFalse(true);
            TxtboxClear();

            BTNSAVE.Enabled = true;
            BTNEDIT.Enabled = false;
            BTNNEW.Enabled = false;
            BTNDELETE.Enabled = false;
        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;
            TxtboxEnabledIsTrueOrFalse(true);

            BTNSAVE.Enabled = true;
            BTNEDIT.Enabled = false;
            BTNNEW.Enabled = false;
            BTNDELETE.Enabled = false;
        }

        /// <summary>
        /// 保存新增或編輯的客戶信息
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                mdlCustomer objModel = new mdlCustomer() { 
                    custcode = txtCustcode.Text.Trim(), 
                    custtype = txtCusttype.Text.Trim(), 
                    custname = txtCust_en_name.Text.Trim(),
                    custlname = txtcust_longen_name.Text.Trim(), 
                    custcname = txtCust_chs_name.Text.Trim(), 
                    custlcname = txtCust_longchs_name.Text.Trim(), 
                    custcoun = txtCustcounn.Text.Trim(),
                    custctact = txtCustctact.Text.Trim(), 
                    custtel = txtCusttel.Text.Trim(), 
                    custemail = txtCustemail.Text.Trim(), 
                    custfax = txtCustfax.Text.Trim(),
                    custpterm = txtCustpterm.Text.Trim(), 
                    custadd1 = txtCust_en_add1.Text.Trim(), 
                    custadd2 = txtCust_en_add2.Text.Trim(), 
                    custadd3 = txtCust_en_add3.Text.Trim(), 
                    custcadd1 = txtCust_chs_add1.Text.Trim(), 
                    custcadd2 = txtCust_chs_add2.Text.Trim(), 
                    custcadd3 = txtCust_chs_add3.Text.Trim(), 
                    custarea = cmbArea.SelectedValue.ToString(), 
                    custcurr = cmbCustcurr.SelectedValue.ToString(), 
                    custopen = mktxtCustopen.Text.Trim(), 
                    custclose = mktxtCustclose.Text.Trim(), 
                    custrmk = txtCustrmk.Text.Trim() 
                };

                int Result = 0;
                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsCustomer.AddCustomer(objModel);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsCustomer.UpdateCustomer(objModel);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                    operationType = clsUtility.enumOperationType.Save;
                    TxtboxEnabledIsTrueOrFalse(false);

                    BTNNEW.Enabled = true;
                    BTNEDIT.Enabled = true;
                    BTNDELETE.Enabled = true;
                    BTNSAVE.Enabled = false;

                    Find(txtCustcode.Text.Trim(), "", "");
                }
                else
                {
                    MessageBox.Show("保存失敗！");
                }
            }
        }

        /// <summary>
        /// 刪除客戶信息
        /// </summary>
        private void Delete()
        {
            if (dgvDetails.RowCount > 0)
            {
                if (MessageBox.Show("確定是否刪除該條數據？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strCuid = dgvDetails.CurrentRow.Cells["colCustcode"].Value.ToString();
                    int Result = clsCustomer.DeleteCustomer(strCuid);

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
                MessageBox.Show("沒有可以刪除的數據.");
            }
        }

        /// <summary>
        /// 根據條件查詢客戶信息
        /// </summary>
        /// <param name="pCustcode"></param>
        /// <param name="pCust_en_name"></param>
        /// <param name="pCust_chs_name"></param>
        private void Find(string pCustcode, string pCust_en_name, string pCust_chs_name)
        {
            dtCustInfo = clsCustomer.GetCustomers(pCustcode, pCust_en_name, pCust_chs_name);

            dgvDetails.DataSource = dtCustInfo;
            dgvDetails.Refresh();
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
        /// 文本框變為不可用
        /// </summary>
        void TxtboxEnabledIsTrueOrFalse(bool flag)
        {
            if (operationType == clsUtility.enumOperationType.Add)
            {
                txtCustcode.Enabled = true;
            }
            else
            {
                txtCustcode.Enabled = false;
            }
            txtCusttype.Enabled = flag;
            txtCust_en_name.Enabled = flag;
            txtcust_longen_name.Enabled = flag;
            txtCust_chs_name.Enabled = flag;
            txtCust_longchs_name.Enabled = flag;
            txtCustcounn.Enabled = flag;
            txtCustctact.Enabled = flag;
            txtCusttel.Enabled = flag;
            txtCustfax.Enabled = flag;
            txtCustemail.Enabled = flag;
            txtCustpterm.Enabled = flag;
            txtCust_en_add1.Enabled = flag;
            txtCust_en_add2.Enabled = flag;
            txtCust_en_add3.Enabled = flag;
            txtCust_chs_add1.Enabled = flag;
            txtCust_chs_add2.Enabled = flag;
            txtCust_chs_add3.Enabled = flag;
            cmbArea.Enabled = flag;
            cmbCustcurr.Enabled = flag;
            mktxtCustclose.Enabled = flag;
            mktxtCustopen.Enabled = flag;
            txtCustrmk.Enabled = flag;
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        void TxtboxClear()
        {
            txtCustcode.Text = "";
            txtCusttype.Text = "";
            txtCust_en_name.Text = "";
            txtCust_chs_name.Text = "";
            txtCustcounn.Text = "";
            txtCustctact.Text = "";
            txtCusttel.Text = "";
            txtCustfax.Text = "";
            txtCustemail.Text = "";
            txtCustpterm.Text = "";
            cmbArea.Text = "";
            cmbCustcurr.Text = "";
            mktxtCustopen.Text = "    /  /  ";
            mktxtCustclose.Text = "    /  /  ";
            txtCustrmk.Text = "";
        }

        /// <summary>
        /// 文本框提示
        /// </summary>
        void TxtboxTips()
        {
            txtcust_longen_name.Text = "客戶英文全稱";
            txtCust_longchs_name.Text = "客戶中文全稱";
            txtCust_en_add1.Text = "英文地址1";
            txtCust_en_add2.Text = "英文地址2";
            txtCust_en_add3.Text = "英文地址3";
            txtCust_chs_add1.Text = "中文地址1";
            txtCust_chs_add2.Text = "中文地址2";
            txtCust_chs_add3.Text = "中文地址3";

        }

        /// <summary>
        /// 綁定貨幣類型
        /// </summary>
        void BindComboxCurr()
        {
            cmbCustcurr.DataSource = clsGetDataForComboBox.GetCurrency();
            cmbCustcurr.DisplayMember = "id";
            cmbCustcurr.ValueMember = "id";
        }

        /// <summary>
        ///綁定區域 
        /// </summary>
        void BindComboxArea()
        {
            cmbArea.DataSource = clsGetDataForComboBox.GetArea();
            cmbArea.DisplayMember = "id";
            cmbArea.ValueMember = "id";
        }

        /// <summary>
        /// 文本框驗證
        /// </summary>
        /// <returns></returns>
        private bool ValidateText()
        {
            if (txtCustcode.Text.Trim() == "")
            {
                MessageBox.Show("客戶編號不能為空。");
                txtCustcode.Focus();
                return false;
            }

            if (txtCust_en_name.Text.Trim() == "" && txtCust_chs_name.Text.Trim() == "")
            {
                MessageBox.Show("客戶名稱不能都為空，請輸入客戶英文名稱或中文名稱。");
                txtCust_en_name.Focus();
                return false;
            }

            if (!Verify.StringValidating(txtCusttel.Text.Trim(), Verify.enumValidatingType.AllNumber))
            {
                MessageBox.Show("電話號碼為數字格式，請輸入正確的格式。");
                txtCusttel.Focus();
                txtCusttel.SelectAll();
                return false;
            }

            if (txtCustemail.Text.Trim() != "")
            {
                if (!clsValidRule.IsEmail(txtCustemail.Text.Trim()))
                {
                    MessageBox.Show("郵箱格式不正確，請重新輸入。");
                    txtCustemail.Focus();
                    txtCustemail.SelectAll();
                    return false;
                }
            }

            if (mktxtCustopen.Text.Trim().Length == 10)
            {
                if (!clsValidRule.CheckDateFormat(mktxtCustopen.Text.Trim()))
                {
                    MessageBox.Show("開戶日期日期格式不正確，請輸入正確的格式(yyyy/MM/dd)。");
                    mktxtCustopen.Focus();
                    mktxtCustopen.SelectAll();
                    return false;
                }
            }

            if (mktxtCustclose.Text.Trim().Length == 10)
            {
                if (!clsValidRule.CheckDateFormat(mktxtCustclose.Text.Trim()))
                {
                    MessageBox.Show("註銷日期格式不正確，請輸入正確的格式(yyyy/MM/dd)。");
                    mktxtCustclose.Focus();
                    mktxtCustclose.SelectAll();
                    return false;
                }
            }
            return true;
        }

        private void txtcust_longen_name_Enter(object sender, EventArgs e)
        {
            txtcust_longen_name.Text = "";
        }

        private void txtCust_longchs_name_Enter(object sender, EventArgs e)
        {
            txtCust_longchs_name.Text = "";
        }

        private void txtCust_en_add1_Enter(object sender, EventArgs e)
        {
            txtCust_en_add1.Text = "";
        }

        private void txtCust_en_add2_Enter(object sender, EventArgs e)
        {
            txtCust_en_add2.Text = "";
        }

        private void txtCust_en_add3_Enter(object sender, EventArgs e)
        {
            txtCust_en_add3.Text = "";
        }

        private void txtCust_chs_add1_Enter(object sender, EventArgs e)
        {
            txtCust_chs_add1.Text = "";
        }

        private void txtCust_chs_add2_Enter(object sender, EventArgs e)
        {
            txtCust_chs_add2.Text = "";
        }

        private void txtCust_chs_add3_Enter(object sender, EventArgs e)
        {
            txtCust_chs_add3.Text = "";
        }





    }
}
