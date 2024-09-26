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
    public partial class frmAddForm : cf01.BaseParentForm
    {
        string strWhere = "";

        clsCommonUse commUse = new clsCommonUse();
        public frmAddForm()
        {
            InitializeComponent();
        }
        public override void Add()
        {
            this.textFid.Focus();
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
                strCode = "select * from tb_sy_func where fid = " + "'" + textFid.Text.Trim() + "'";
                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                    if (dtRows.Rows.Count <= 0)
                    {
                        strCode = "INSERT INTO tb_sy_func (fid,FuncDesc,ActiveFunc,FuncName) ";
                        strCode += " VALUES(@fid,@FuncDesc,@ActiveFunc,@FuncName)";

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
                        this.textFid.Focus();
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
                    strCode = "UPDATE tb_sy_func SET FuncDesc=@FuncDesc,ActiveFunc=@ActiveFunc,FuncName=@FuncName ";
                    strCode += " WHERE fid = @fid";

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
            strWhere = " WHERE fid = " + "'" + textFid.Text.Trim() + "'";
            this.BindDataGridView(strWhere);
        }
        public override void Find()
        {
            this.BindDataGridView("");
        }
        public override void Edit()
        {
            this.textFuncDesc.Focus();
        }
        public override void textBox_edit_status(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textFid.ReadOnly = false;
                this.textFuncDesc.ReadOnly = false;
                this.textActiveFunc.ReadOnly = false;
                this.textFuncName.ReadOnly = false;
            }
            else if (edit_flag == "2")
            {
                this.textFid.ReadOnly = true;
                this.textFuncDesc.ReadOnly = false;
                this.textActiveFunc.ReadOnly = false;
                this.textFuncName.ReadOnly = false;
            }
            else if (edit_flag == "3")
            {
                this.textFid.ReadOnly = true;
                this.textFuncDesc.ReadOnly = true;
                this.textActiveFunc.ReadOnly = true;
                this.textFuncName.ReadOnly = true;
            }
        }
        public override void textBox_clear(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textFid.Text = "";
                this.textFuncDesc.Text = "";
                this.textActiveFunc.Text = "";
                this.textFuncName.Text = "";
            }
            else if (edit_flag == "3")
            {
            }
        }
        private bool valid_data()
        {
            if (this.textFid.Text == "")
            {
                MessageBox.Show("代碼不能為空!");
                this.textFid.Focus();
                return false;
            }
            if (this.textFuncDesc.Text == "")
            {
                MessageBox.Show("代碼描述不能為空!");
                this.textFuncDesc.Focus();
                return false;
            }
            if (this.textActiveFunc.Text == "")
            {
                MessageBox.Show("調用功能不能為空!");
                this.textActiveFunc.Focus();
                return false;
            }
            if (this.textFuncName.Text == "")
            {
                MessageBox.Show("表單名不能為空!");
                this.textFuncName.Focus();
                return false;
            }
            return true;
        }

        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@fid", Convert.ToInt32(textFid.Text));
            commUse.Cmd.Parameters.AddWithValue("@FuncDesc", textFuncDesc.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@ActiveFunc", textActiveFunc.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@FuncName", textFuncName.Text.Trim());

        }
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT a.fid,a.FuncDesc,a.ActiveFunc,a.FuncName";
            strSql += " FROM tb_sy_func a " + strWhere;
            strSql += " ORDER BY a.fid ";
            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "tb_sy_func").Tables["tb_sy_func"];
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
            this.textFid.Text = this.dgvDetails[0, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textFuncDesc.Text = this.dgvDetails[1, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textActiveFunc.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textFuncName.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
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
        public override bool Bef_Del()
        {
            DialogResult MsgBoxResult;//设置对话框的返回值
            MsgBoxResult = MessageBox.Show("確定要刪除嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.No)
            {
                return false;
            }
            return true;

        }
        public override bool Del()
        {
            bool del_flag = true;
            //更新数据库
            try
            {
                string strCode = "";
                strCode = "DELETE FROM tb_sy_func WHERE fid = @fid";
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

        private void frmAddForm_Load(object sender, EventArgs e)
        {
            toolStrip1.Tag = "3";
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


    }
}
