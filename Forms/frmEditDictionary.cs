using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.ModuleClass;

namespace cf01.Forms
{
    public partial class frmEditDictionary : Form
    {
        clsCommonUse commUse = new clsCommonUse();
        string lang_id = DBUtility._language;

        public frmEditDictionary()
        {
            InitializeComponent();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditDictionary_Load(object sender, EventArgs e)
        {
            string strsql;

            MyInitForm forminit = new MyInitForm();
            forminit.SetForm(this.Name, this.Controls, "frmEditDictionary_label");

            strsql = "Select * from v_dict_group where formname=" + "'" + "frmeditdictionary_filter" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbFieldName, "formname", "show_name", strsql, "v_dict_group");

            strsql = "Select * from v_dict_group where formname=" + "'" + "operator_word" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbOperator, "formname", "show_name", strsql, "v_dict_group");

            strsql = "Select * from v_dict_group where formname=" + "'" + "language_id" + "'";
            commUse.BindComboBox(cmbLanguage, "formname", "show_name", strsql, "v_dict_group");

            commUse.BuilDataGridView(dgvDetails, "frmeditdictionary_grd1", lang_id);

            toolStrip1.Tag = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT a.formname,b.col_code,b.language_id,b.col_name,b.show_name";
            strSql += " FROM tb_sy_dict_group a INNER JOIN tb_sy_dictionary b ON a.dict_col_code=b.col_code" + strWhere; ;

            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "v_dict_group").Tables["v_dict_group"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void btmFind_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;
            string tb_field = "formname";
            string keyWord;
            keyWord = txtKeyWord.Text.Trim();
            int f_type;
            f_type = cmbFieldName.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    tb_field = " a.formname ";
                    break;
                case 2:
                    tb_field = " b.col_code ";
                    break;
                case 3:
                    tb_field = " b.language_id ";
                    break;
                case 4:
                    tb_field = " b.col_name ";
                    break;
                case 5:
                    tb_field = " b.show_name ";
                    break;
            }
            f_type = cmbOperator.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    strWhere = " WHERE " + tb_field + " like " + "'%" + keyWord + "%'";
                    break;
                case 2:
                    strWhere = " WHERE " + tb_field + " = " + "'%" + keyWord + "%'";
                    break;
                default:
                    break;
            }
            f_type = cmbLanguage.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    strWhere += " AND b.language_id = " + "'" + "0" + "'";
                    break;
                case 2:
                    strWhere += " AND b.language_id = " + "'" + "1" + "'";
                    break;
                case 3:
                    strWhere += " AND b.language_id = " + "'" + "2" + "'";
                    break;
                default:
                    break;
            }
            this.BindDataGridView(strWhere);
        }

        private void FillControls()
        {
            this.txtFormname.Text = this.dgvDetails[0, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
            this.txtColCode.Text = this.dgvDetails[1, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
            this.txtColName.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
            this.txtLanguage.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
            //this.txtLanguage.SelectedValue = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value;
            this.txtShowName.Text = this.dgvDetails[4, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() != "EDIT")
            {
                if (dgvDetails.RowCount > 0)
                {
                    /*
                    //对于基础类型帐户信息，不许修改帐户代码、帐户名称、会计科目
                    if (dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString() == "01"
                       || dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString() == "02")
                    {
                        txtAccountCode.Enabled = false;
                        txtAccountName.Enabled = false;
                        cbxAccSubject.Enabled = false;
                    }
                    else
                    {
                        txtAccountCode.Enabled = true;
                        txtAccountName.Enabled = true;
                        cbxAccSubject.Enabled = true;
                    }

                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSAccount", dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString()))
                    {
                        txtAccountCode.Enabled = false;
                    }
                    else
                    {
                        txtAccountCode.Enabled = true;
                    }
                    */
                    FillControls();
                }
            }
        }
        private void ControlStatus()
        {
            //按钮切换状态及授权控制
            this.BTNSAVE.Enabled = !this.BTNSAVE.Enabled;
            this.BTNCANCEL.Enabled = !this.BTNCANCEL.Enabled;
            /*
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            */
            //窗体控件状态切换
            this.txtFormname.ReadOnly = !this.txtFormname.ReadOnly;
            this.txtColCode.ReadOnly = !this.txtColCode.ReadOnly;
            this.txtColName.ReadOnly = !this.txtColName.ReadOnly;
            this.txtLanguage.ReadOnly = !this.txtLanguage.ReadOnly;
            this.txtShowName.ReadOnly = !this.txtShowName.ReadOnly;
        }
        private void ClearControls()
        {
            //窗体控件状态切换
            this.txtFormname.Text = "";
            this.txtColCode.Text = "";
            this.txtColName.Text = "";
            //this.cbxAccSubject.SelectedIndex = -1;
            this.txtLanguage.Text = "";
            this.txtShowName.Text = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("不能使用此功能！", "系統信息");
            return;
            /*
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //表示添加状态
            txtFormname.Enabled = true;
            txtColCode.Enabled = true;
            txtColName.Enabled = true;
            txtLanguage.Enabled = true;
            txtShowName.Enabled = true;
             */
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            //ClearControls();
            toolStrip1.Tag = "EDIT"; //表示修改状态
            txtFormname.Enabled = false;
            txtColCode.Enabled = false;
            txtColName.Enabled = false;
            txtLanguage.Enabled = false;
        }

        private void toolReflush_Click(object sender, EventArgs e)
        {
            this.BindDataGridView("");
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "";
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;
            if (String.IsNullOrEmpty(txtColCode.Text.Trim()))
            {
                MessageBox.Show("標籤系統編號不能為空！", "系統信息");
                txtColCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtLanguage.Text.Trim()))
            {
                MessageBox.Show("語言代號不能為空！", "系統信息");
                txtLanguage.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtShowName.Text.Trim()))
            {
                MessageBox.Show("標籤顯示描述不能為空！", "系統信息");
                txtShowName.Focus();
                return;
            }
            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from tb_sy_dictionary where col_code = '" + txtColCode.Text.Trim() + "'" +
                    " AND language_id = ' " + txtLanguage.Text.Trim() + " ' ";

                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                    if (dtRows.Rows.Count <= 0)
                    {
                        strCode = "INSERT INTO tb_sy_dictionary(col_code,language_id,show_name) ";
                        strCode += "VALUES(@col_code,@language_id,@show_name)";

                        ParametersAddValue();

                        if (commUse.ExecDataBySql(strCode) > 0)
                        {
                            MessageBox.Show("儲存成功！", "系統信息");
                            this.BindDataGridView("");
                            ControlStatus();
                        }
                        else
                        {
                            MessageBox.Show("儲存成功！", "系統信息");
                        }
                    }
                    else
                    {
                        MessageBox.Show("編碼重複，請重新設置！", "系統信息");
                        this.txtColCode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系統信息");
                }
            }

            //修改
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strOldShowName = null; //未修改之前的顯示標籤

                strOldShowName = this.dgvDetails[4, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();

                //若顯示標籤被修改过
                if (strOldShowName != txtShowName.Text.Trim())
                {
                    strCode = "select * from tb_sy_dictionary where col_code = '" + txtColCode.Text.Trim() + "'" +
                        " AND language_id = ' " + txtLanguage.Text.Trim() + " ' ";

                    try
                    {
                        DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                        if (dtRows.Rows.Count > 0)
                        {
                            MessageBox.Show("編碼重複，請重新設置！", "系統信息");
                            this.txtShowName.Focus();

                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "系統信息");
                    }
                }

                //更新数据库
                try
                {
                    strCode = "UPDATE tb_sy_dictionary SET show_name = @show_name ";
                    strCode += " WHERE col_code = @col_codex AND language_id = @language_idx";
                    commUse.Cmd.Parameters.Clear();
                    commUse.Cmd.Parameters.AddWithValue("@show_name", txtShowName.Text.Trim());
                    commUse.Cmd.Parameters.AddWithValue("@col_codex", txtColCode.Text.Trim());
                    commUse.Cmd.Parameters.AddWithValue("@language_idx", txtLanguage.Text.Trim());
                    //ParametersAddValue();

                    if (commUse.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("儲存成功！", "系統信息");
                        this.BindDataGridView("");
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("儲存失敗！", "系統信息");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系統信息");
                    throw ex;
                }
            }

            toolStrip1.Tag = "";
        }
        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@col_code", txtColCode.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@language_id", txtLanguage.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@show_name", txtShowName.Text.Trim());
            /*
            if (cbxAccSubject.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@AccSubject", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AccSubject", cbxAccSubject.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtAccMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@AccMoney", 0); //设置账户的默认金额为0，保证帐户的初始金额不为空
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AccMoney", Decimal.Round(Convert.ToDecimal(txtAccMoney.Text.Trim()), 2));//初始帐户金额
            }
             */
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("不能使用此功能！", "系統信息");
            return;
        }


    }
}
