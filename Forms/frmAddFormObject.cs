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
    public partial class frmAddFormObject : cf01.BaseParentForm
    {
        string strWhere = "";
        string lang_id = DBUtility._language;
        string user_id = DBUtility._user_id;

        clsCommonUse commUse = new clsCommonUse();
        public frmAddFormObject()
        {
            InitializeComponent();
        }

        public override void Add()
        {
            this.textFormName.Focus();
        }
        public override bool Bef_Save()
        {
            if (this.valid_data())
            {
                return true;
            }
            return false;
        }
        public override void Find()
        {
            this.BindDataGridView("");
        }
        public override void Edit()
        {
            this.textColWidth.Focus();
        }
        public override void textBox_edit_status(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textFormName.ReadOnly = false;
                this.textObjType.ReadOnly = false;
                this.textObjId.ReadOnly = false;
                this.textColWidth.ReadOnly = false;
                this.textColVisible.ReadOnly = false;
                this.textColType.ReadOnly = false;
                this.textColSort.ReadOnly = false;
                this.textObjName.ReadOnly = false;
                this.textReadOnly.ReadOnly = false;
            }
            else if (edit_flag == "2")
            {
                this.textFormName.ReadOnly = true;
                this.textObjType.ReadOnly = true;
                this.textObjId.ReadOnly = true;
                this.textColWidth.ReadOnly = false;
                this.textColVisible.ReadOnly = false;
                this.textColType.ReadOnly = false;
                this.textColSort.ReadOnly = false;
                this.textObjName.ReadOnly = false;
                this.textReadOnly.ReadOnly = false;
            }
            else if (edit_flag == "3")
            {
                this.textFormName.ReadOnly = true;
                this.textObjType.ReadOnly = true;
                this.textObjId.ReadOnly = true;
                this.textColWidth.ReadOnly = true;
                this.textColVisible.ReadOnly = true;
                this.textColType.ReadOnly = true;
                this.textColSort.ReadOnly = true;
                this.textObjName.ReadOnly = true;
                this.textReadOnly.ReadOnly = true;
            }
        }
        public override void textBox_clear(string edit_flag)
        {
            if (edit_flag == "1")
            {
                //this.textFormName.Text = "";
                //this.textObjType.Text = "";
                //this.textObjId.Text = "";
                this.textColWidth.Text = "";
                this.textColVisible.Text = "Y";
                //this.textColType.Text = "";
                this.textColSort.Text = "";
                this.textObjName.Text = "";
                this.textReadOnly.Text = "Y";
            }
            else if (edit_flag == "3")
            {
            }
        }
        private bool valid_data()
        {
            if (this.textFormName.Text == "")
            {
                MessageBox.Show("表單名不能為空!");
                this.textFormName.Focus();
                return false;
            }
            if (this.textObjType.Text == "")
            {
                MessageBox.Show("控件類型不能為空!");
                this.textObjType.Focus();
                return false;
            }
            if (this.textObjId.Text == "")
            {
                MessageBox.Show("控件代號不能為空!");
                this.textObjId.Focus();
                return false;
            }

            return true;
        }
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT a.formname,a.obj_type,a.obj_id,a.obj_name,a.col_width,col_visible,col_type,col_sort,col_readonly";
            strSql += " FROM tb_sy_form_object a " + strWhere;
            strSql += " ORDER BY col_sort";
            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "tb_obj").Tables["tb_obj"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            if (dgvDetails.RowCount > 0)
            {
                FillControls();
            }
        }
        public override bool Save()
        {
            string strCode = "";
            bool update_flag = true;
            if (this.toolStrip1.Tag.ToString() == "1")
            {
                strCode = "select formname from tb_sy_form_object where formname = " + "'" + textFormName.Text.Trim() + "'"
                        + " and obj_type = " + "'" + textObjType.Text.Trim() + "'" + " and obj_id = " + "'" + textObjId.Text.Trim() + "'";
                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                    if (dtRows.Rows.Count <= 0)
                    {

                        strCode = "INSERT INTO tb_sy_form_object (formname,obj_type,obj_id,obj_name,col_width,col_visible,col_type,col_sort,col_readonly) ";
                        strCode += " VALUES(@formname,@obj_type,@obj_id,@obj_name,@col_width,@col_visible,@col_type,@col_sort,@col_readonly)";

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
                        this.textFormName.Focus();
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
                    strCode = "UPDATE tb_sy_form_object SET obj_name=@obj_name,col_width=@col_width,col_sort=@col_sort" +
                        ",col_visible=@col_visible,col_type=@col_type,col_readonly=@col_readonly ";
                    strCode += " WHERE formname = @formname AND obj_type=@obj_type AND obj_id=@obj_id ";

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
            strWhere = " WHERE formname = " + "'" + textFormName.Text.Trim() + "'" + " and obj_type = " + "'" + textObjType.Text.Trim() + "'" + " and obj_id = " + "'" + textObjId.Text.Trim() + "'";
            this.BindDataGridView(strWhere);
        }
        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@formname", textFormName.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@obj_type", textObjType.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@obj_id", textObjId.Text.Trim());
            if (textColWidth.Text != "")
            {
                commUse.Cmd.Parameters.AddWithValue("@col_width", Convert.ToInt32(textColWidth.Text));
            }
            else
                commUse.Cmd.Parameters.AddWithValue("@col_width", 80);
            if (textColSort.Text != "")
            {
                commUse.Cmd.Parameters.AddWithValue("@col_sort", Convert.ToInt32(textColSort.Text));
            }
            else
                commUse.Cmd.Parameters.AddWithValue("@col_sort", 1);
            commUse.Cmd.Parameters.AddWithValue("@col_visible", textColVisible.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@col_type", textColType.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@obj_name", textObjName.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@col_readonly", textReadOnly.Text.Trim());

        }

        private void FillControls()
        {
            this.textFormName.Text = this.dgvDetails[0, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textObjType.Text = this.dgvDetails[1, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textObjId.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textObjName.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textColWidth.Text = this.dgvDetails[4, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textColVisible.Text = this.dgvDetails[5, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textColType.Text = this.dgvDetails[6, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textColSort.Text = this.dgvDetails[7, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textReadOnly.Text = this.dgvDetails[8, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
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
        public override bool Del()
        {
            bool del_flag = true;
            //更新数据库
            try
            {
                string strCode = "";
                strCode = "DELETE FROM tb_sy_form_object WHERE formname = @formname AND obj_type = @obj_type AND obj_id = @obj_id ";
                ParametersAddValue();

                if (commUse.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("記錄已刪除", "系統信息");
                    this.BindDataGridView("");
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

        private void button1_Click(object sender, EventArgs e)
        {
            strWhere = " WHERE formname like '%" + textBox1.Text.Trim() + "%'" + " and obj_type like '%" + textBox2.Text.Trim() + "%'" + " and obj_id like '%" + textBox3.Text.Trim() + "%'";
            this.BindDataGridView(strWhere);
        }

        private void frmAddFormObject_Load(object sender, EventArgs e)
        {
            //綁定表格
            //commUse.BuilDataGridView_New(dgvDetails, "frmDemo","dgvDemo", lang_id);
            toolStrip1.Tag = "3";
        }

        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Forms.frmNewDictionary frm = new Forms.frmNewDictionary();
            frm.Owner = this;
            frm.ShowDialog();
        }
    }
}
