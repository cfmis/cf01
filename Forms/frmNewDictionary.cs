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
    public partial class frmNewDictionary : cf01.BaseParentForm
    {
        string strWhere = "";

        clsCommonUse commUse = new clsCommonUse();

        public frmNewDictionary()
        {
            InitializeComponent();
        }
        public override void Add()
        {
            this.textObj_Id.Focus();
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
                strCode = "select * from tb_sy_dictionary_obj where obj_id = " + "'" + textObj_Id.Text.Trim() + "'";
                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                    if (dtRows.Rows.Count<=0)
                    {
                        strCode = "INSERT INTO tb_sy_dictionary_obj (obj_id,obj_desc,col_field,img_path) ";
                        strCode += " VALUES(@obj_id,@obj_desc,@col_field,@img_path)";

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
                    strCode = "UPDATE tb_sy_dictionary_obj SET obj_desc=@obj_desc,col_field=@col_field,img_path=@img_path ";
                    strCode += " WHERE obj_id = @obj_id";

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

            return update_flag;
        }
        public override void Aft_Save()
        {
            this.toolStrip1.Tag = "3";
            //this.control_status(this.toolStrip1.Tag.ToString());
            this.textBox_edit_status(this.toolStrip1.Tag.ToString());
            this.textBox_clear(this.toolStrip1.Tag.ToString());
            strWhere = " WHERE obj_id = " + "'" + textObj_Id.Text.Trim() + "'";
            this.BindDataGridView(strWhere);
        }
        public override void Find()
        {
            this.BindDataGridView("");
        }
        public override void Edit()
        {
            this.textObj_Desc.Focus();
        }
        public override void textBox_edit_status(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textObj_Id.ReadOnly = false;
                this.textObj_Desc.ReadOnly = false;
                this.textCol_Field.ReadOnly = false;
                this.textImg_path.ReadOnly = false;
            }
            else if (edit_flag == "2")
            {
                this.textObj_Id.ReadOnly = true;
                this.textObj_Desc.ReadOnly = false;
                this.textCol_Field.ReadOnly = false;
                this.textImg_path.ReadOnly = false;
            }
            else if (edit_flag == "3")
            {
                this.textObj_Id.ReadOnly = true;
                this.textObj_Desc.ReadOnly = true;
                this.textCol_Field.ReadOnly = true;
                this.textImg_path.ReadOnly = true;
            }
        }
        public override void textBox_clear(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textObj_Id.Text = "";
                this.textObj_Desc.Text = "";
                this.textCol_Field.Text = "";
                this.textImg_path.Text = "";
            }
            else if (edit_flag == "3")
            {
            }
        }
        private bool valid_data()
        {
            if (this.textObj_Id.Text == "")
            {
                MessageBox.Show("代碼不能為空!");
                this.textObj_Id.Focus();
                return false;
            }
            if (this.textObj_Desc.Text == "")
            {
                MessageBox.Show("代碼描述不能為空!");
                this.textObj_Desc.Focus();
                return false;
            }

            return true;
        }

        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@obj_id", textObj_Id.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@obj_desc", textObj_Desc.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@img_path", textImg_path.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@col_field", textCol_Field.Text.Trim());

        }
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT a.obj_id,a.obj_desc,a.col_field,a.img_path";
            strSql += " FROM tb_sy_dictionary_obj a " + strWhere;

            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "tb_dictionary_obj").Tables["tb_dictionary_obj"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            if (this.dgvDetails.RowCount > 0)
            {
                this.FillControls();
            }
        }
        private void FillControls()
        {
            this.textObj_Id.Text = this.dgvDetails[0, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textObj_Desc.Text = this.dgvDetails[1, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textCol_Field.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textImg_path.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "3")
            {
                if (dgvDetails.RowCount > 0)
                {
                    FillControls();
                }
            }
        }

        private void dgvDetails_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (toolStrip1.Tag.ToString() == "3")
            //{
            //    if (dgvDetails.RowCount > 0)
            //    {
            //        FillControls();
            //    }
            //}
        }
        public override bool Del()
        {
            bool del_flag = true;
            //更新数据库
            try
            {
                string strCode = "";
                strCode = "DELETE FROM tb_sy_dictionary_obj WHERE obj_id = @obj_id";
                ParametersAddValue();

                if (commUse.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("記錄已刪除", "系統信息");
                    this.BindDataGridView("");
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

        public override bool Bef_Del()
        {
            string strCode = "";
            bool allow_del_flag = true;
            strCode = "select * from tb_sy_dictionary_lang where obj_id = " + "'" + textObj_Id.Text.Trim() + "'";
            try
            {
                DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                if (dtRows.Rows.Count>0)
                {
                    MessageBox.Show("在語言表中存在這個記錄,不能刪除!");
                    allow_del_flag = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系統信息");
                allow_del_flag = false;
            }
            return allow_del_flag;
        }
        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Forms.frmNewDictLang frmNewDictLang = new Forms.frmNewDictLang(1, this.textObj_Id.Text.ToString());
            frmNewDictLang.Owner = this;
            frmNewDictLang.ShowDialog();
        }

    }
}
