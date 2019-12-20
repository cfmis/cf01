using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmNewDictLang : cf01.BaseParentForm
    {

        string strWhere = "";
        clsCommonUse commUse = new clsCommonUse();

        public frmNewDictLang(int obj_form, string obj_id)
        {
            InitializeComponent();
            textObj_Id.Text = obj_id;
            if (obj_form == 1)//如果是表單的控件
            {
                this.radioForm.Checked = true;
                this.radioMenu.Checked = false;
            }
            else//如果是菜單的控件
            {
                this.radioMenu.Checked = true;
                this.radioForm.Checked = false;
            }
        }


        public override void textBox_edit_status(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textShow_name.ReadOnly = false;
                this.textLanguage_id.ReadOnly = false;
            }
            else if (edit_flag == "2")
            {
                this.textShow_name.ReadOnly = false;
                this.textLanguage_id.ReadOnly = true;
            }
            else if (edit_flag == "3")
            {
                this.textShow_name.ReadOnly = true;
                this.textLanguage_id.ReadOnly = true;
            }
        }
        public override void textBox_clear(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textShow_name.Text = "";
                this.textLanguage_id.Text = "";
            }
            else if (edit_flag == "3")
            {
            }
        }
        public override void Edit()
        {
            this.textShow_name.Focus();
        }
        public override void Add()
        {
            this.textLanguage_id.Focus();
        }
        private bool valid_data()
        {
            if (this.textObj_Id.Text == "")
            {
                MessageBox.Show("代碼不能為空!");
                this.textObj_Id.Focus();
                return false;
            }
            if (this.textShow_name.Text == "")
            {
                MessageBox.Show("顯示的名稱不能為空!");
                this.textShow_name.Focus();
                return false;
            }
            if (this.textLanguage_id.Text == "")
            {
                MessageBox.Show("語言代號不能為空!");
                this.textLanguage_id.Focus();
                return false;
            }
            return true;
        }
        public override bool Bef_Save()
        {
            if (this.valid_data())
            {
                return true;
            }
            return false;
        }
        public override bool Save()
        {
            string strCode = "";
            bool update_flag = true;
            if (this.toolStrip1.Tag.ToString() == "1")
            {
                if (this.radioForm.Checked == true)
                {
                    strCode = "select obj_id from tb_sy_dictionary_lang where obj_id = '" + textObj_Id.Text.Trim() + "'" +
                    " AND language_id = ' " + textLanguage_id.Text.Trim() + " ' ";
                }
                else
                {
                    strCode = "select gid from tb_sy_grant_lang where gid = '" + textObj_Id.Text.Trim() + "'" +
                    " AND language_id = ' " + textLanguage_id.Text.Trim() + " ' ";
                }
                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);

                    if (dtRows.Rows.Count <= 0)
                    {
                        if (this.radioForm.Checked == true)
                        {
                            strCode = "INSERT INTO tb_sy_dictionary_lang (obj_id,language_id,show_name) ";
                            strCode += "VALUES(@obj_id,@language_id,@show_name)";
                        }
                        else
                        {
                            strCode = "INSERT INTO tb_sy_grant_lang (gid,language_id,show_name) ";
                            strCode += "VALUES(@obj_id,@language_id,@show_name)";
                        }

                        ParametersAddValue();

                        if (commUse.ExecDataBySql(strCode) > 0)
                        {
                            MessageBox.Show("儲存成功！", "系統信息");
                            update_flag = true;
                            //this.();
                        }
                        else
                        {
                            MessageBox.Show("儲存成功！", "系統信息");
                            update_flag = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("編碼重複，請重新設置！", "系統信息");
                        this.textObj_Id.Focus();
                        update_flag = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系統信息");
                    update_flag = false;
                }
            }
            else if (this.toolStrip1.Tag.ToString() == "2")//修改
            {
                //更新数据库
                try
                {
                    if (this.radioForm.Checked == true)
                    {
                        strCode = "UPDATE tb_sy_dictionary_lang SET show_name = @show_name ";
                        strCode += " WHERE obj_id = @obj_id AND language_id = @language_id";
                    }
                    else
                    {
                        strCode = "UPDATE tb_sy_grant_lang SET show_name = @show_name ";
                        strCode += " WHERE gid = @obj_id AND language_id = @language_id";
                    }

                    ParametersAddValue();

                    if (commUse.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("儲存成功！", "系統信息");
                        update_flag = true;
                        //this.BindDataGridView("");
                        //ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("儲存失敗！", "系統信息");
                        update_flag = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系統信息");
                    update_flag = false;
                    throw ex;
                }
            }
            this.toolStrip1.Tag = "3";
            //this.control_status(this.toolStrip1.Tag.ToString());
            this.textBox_edit_status(this.toolStrip1.Tag.ToString());
            this.textBox_clear(this.toolStrip1.Tag.ToString());
            if (this.radioForm.Checked == true)
                strWhere = " WHERE a.obj_id = '" + textObj_Id.Text.Trim() + "'";
            else
                strWhere = " WHERE a.gid = '" + textObj_Id.Text.Trim() + "'";
            this.BindDataGridView(strWhere);
            return update_flag;
        }
        public override void Find()
        {
            this.BindDataGridView("");
        }
        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            if (this.radioForm.Checked == true)
                commUse.Cmd.Parameters.AddWithValue("@obj_id", textObj_Id.Text.Trim());
            else
                commUse.Cmd.Parameters.AddWithValue("@obj_id", Convert.ToInt32(textObj_Id.Text));
            commUse.Cmd.Parameters.AddWithValue("@language_id", textLanguage_id.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@show_name", textShow_name.Text.Trim());

        }
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;
            if (this.radioForm.Checked == true)
            {
                strSql = "SELECT a.obj_id,a.obj_desc,a.col_field,a.img_path,b.language_id,b.show_name";
                strSql += " FROM tb_sy_dictionary_obj a INNER JOIN tb_sy_dictionary_lang b ON a.obj_id=b.obj_id " + strWhere;
            }
            else
            {
                strSql = "SELECT a.gid,a.gdesc,b.language_id,b.show_name";
                strSql += " FROM tb_sy_grant a INNER JOIN tb_sy_grant_lang b ON a.gid=b.gid " + strWhere;
            }
            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "tb_dictionary").Tables["tb_dictionary"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void frmNewDictLang_Load(object sender, EventArgs e)
        {
            toolStrip1.Tag = "3";
            if (this.radioForm.Checked == true)
                strWhere = " WHERE a.obj_id = '" + textObj_Id.Text.Trim() + "'";
            else
                strWhere = " WHERE a.gid = '" + textObj_Id.Text.Trim() + "'";
            this.BindDataGridView(strWhere);
        }
        private void FillControls()
        {
            if (this.radioForm.Checked == true)
            {
                this.textShow_name.Text = this.dgvDetails[5, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
                this.textLanguage_id.Text = this.dgvDetails[4, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
            }
            else
            {
                this.textShow_name.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
                this.textLanguage_id.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "3")
            {
                if (dgvDetails.RowCount > 0)
                {
                    this.FillControls();
                }
            }
        }
        public override bool Del()
        {
            bool del_flag = true;
            //更新数据库
            try
            {
                string strCode = "";
                if (this.radioForm.Checked == true)
                    strCode = "DELETE FROM tb_sy_dictionary_lang WHERE obj_id = @obj_id AND language_id = @language_id";
                else
                    strCode = "DELETE FROM tb_sy_grant_lang WHERE gid = @obj_id AND language_id = @language_id";
                ParametersAddValue();

                if (commUse.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("記錄已刪除", "系統信息");
                    if (this.radioForm.Checked == true)
                        strWhere = " WHERE a.obj_id = '" + textObj_Id.Text.Trim() + "'";
                    else
                        strWhere = " WHERE a.gid = '" + textObj_Id.Text.Trim() + "'";
                    this.BindDataGridView(strWhere);
                    //ControlStatus();
                }
                else
                {
                    MessageBox.Show("刪除記錄失敗！", "系統信息");
                    del_flag = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系統信息");
                throw ex;
            }
            return del_flag;
        }
    }
}
