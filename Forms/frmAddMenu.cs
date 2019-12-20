using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmAddMenu : cf01.BaseParentForm
    {
        private DataTable dts = null;
        string strWhere = "";
        clsCommonUse commUse = new clsCommonUse();

        public frmAddMenu()
        {
            InitializeComponent();
        }
        private void frmAddMenu_Load(object sender, EventArgs e)
        {
            this.toolStrip1.Tag = "3";
            this.BindingTree(1);
        }
        private void BindingTree(int Rid)
        {
            dts = clsRoleManage.GetGrantMenuByRid(true, Rid);

            DataRow[] r1s = dts.Select("Pid=0");

            treeView1.CheckBoxes = false;//是否顯示復選框
            treeView1.Nodes.Clear();
            foreach (DataRow r1 in r1s)
            {
                string Gid = r1["Gid"].ToString();
                string Gdesc = r1["Gdesc"].ToString();
                TreeNode root1 = new TreeNode(Gdesc);
                root1.Name = Gid;
                root1.Checked = r1["Rid"].ToString() == "" ? false : true;
                treeView1.Nodes.Add(root1);

                DataRow[] r2s = dts.Select("Pid=" + Gid);
                foreach (DataRow r2 in r2s)
                {
                    Gid = r2["Gid"].ToString();
                    Gdesc = r2["Gdesc"].ToString();
                    TreeNode root2 = new TreeNode(Gdesc);
                    root2.Name = Gid;
                    root2.Checked = r2["Rid"].ToString() == "" ? false : true;
                    root1.Nodes.Add(root2);

                    DataRow[] r3s = dts.Select("Pid=" + Gid);
                    foreach (DataRow r3 in r3s)
                    {
                        Gid = r3["Gid"].ToString();
                        Gdesc = r3["Gdesc"].ToString();
                        TreeNode root3 = new TreeNode(Gdesc);
                        root3.Name = Gid;
                        root3.Checked = r3["Rid"].ToString() == "" ? false : true;
                        root2.Nodes.Add(root3);
                    }
                }
            }
        }




        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string strFrmName = treeView1.SelectedNode.Text;
            int IntGid = Convert.ToInt32(treeView1.SelectedNode.Name);
            this.textPid.Text = IntGid.ToString();
            this.textPidDesc.Text = strFrmName;
            this.textBox_clear("1");
            strWhere = " WHERE a.pid = " + "'" + IntGid.ToString() + "'";
            this.BindDataGridView(strWhere);
        }


        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT a.gid,a.gDesc,a.fid,b.funcdesc,a.gid_sort,a.Pid,c.gdesc AS pid_gdesc";
            strSql += " FROM tb_sy_grant a Left Join tb_sy_func b On a.fid=b.fid ";
            strSql += " Left Join tb_sy_grant c On a.pid=c.gid";
            strSql += strWhere;
            strSql += " ORDER BY a.gid ";
            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "tb_sy_grant").Tables["tb_sy_grant"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            //this.FillControls();
            this.textBox_clear("1");
            if (this.dgvDetails.RowCount > 0 && this.toolStrip1.Tag.ToString() == "3")
            {
                this.FillControls();
            }
        }
        private void FillControls()
        {
            this.textGid.Text = this.dgvDetails[0, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textGdesc.Text = this.dgvDetails[1, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textFid.Text = this.dgvDetails[2, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textFuncDesc.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textGidSort.Text = this.dgvDetails[4, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textPid.Text = this.dgvDetails[5, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.textPidDesc.Text = this.dgvDetails[6, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDetails.RowCount > 0 && this.toolStrip1.Tag.ToString() == "3")
            {
                this.FillControls();
            }
        }

        public override void Add()
        {
            this.textGid.Focus();
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
                strCode = "select gid from tb_sy_grant where gid = " + "'" + textGid.Text.Trim() + "'";
                try
                {
                    DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);

                    if (dtRows.Rows.Count <= 0)
                    {
                        strCode = "INSERT INTO tb_sy_grant (lang,gid,gdesc,pid,fid,gid_sort) ";
                        strCode += " VALUES(@lang,@gid,@gdesc,@pid,@fid,@gid_sort)";

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
                    strCode = "UPDATE tb_sy_grant SET gdesc=@gdesc,pid=@pid,fid=@fid,gid_sort=@gid_sort ";
                    strCode += " WHERE gid = @gid";

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
            strWhere = " WHERE a.gid = " + "'" + textGid.Text.Trim() + "'";
            this.BindDataGridView(strWhere);
            this.BindingTree(1);
        }
        public override void Find()
        {
            strWhere = "";
            this.BindDataGridView(strWhere);
        }
        public override void Edit()
        {
            this.textGdesc.Focus();
        }
        public override void textBox_edit_status(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textGid.ReadOnly = false;
                this.textGdesc.ReadOnly = false;
                this.textFid.ReadOnly = false;
                this.textFuncDesc.ReadOnly = true;
                this.textGidSort.ReadOnly = false;
                this.checkPid.Enabled = true;
            }
            else if (edit_flag == "2")
            {
                this.textGid.ReadOnly = true;
                this.textGdesc.ReadOnly = false;
                this.textFid.ReadOnly = false;
                this.textFuncDesc.ReadOnly = true;
                this.textGidSort.ReadOnly = false;
                this.checkPid.Enabled = false;
            }
            else if (edit_flag == "3")
            {
                this.textGid.ReadOnly = true;
                this.textGdesc.ReadOnly = true;
                this.textFid.ReadOnly = true;
                this.textFuncDesc.ReadOnly = true;
                this.textGidSort.ReadOnly = true;
                this.checkPid.Enabled = false;
            }
        }
        public override void textBox_clear(string edit_flag)
        {
            if (edit_flag == "1")
            {
                this.textGid.Text = "";
                this.textGdesc.Text = "";
                this.textFid.Text = "";
                this.textFuncDesc.Text = "";
                this.textGidSort.Text = "";
                this.checkPid.Checked = false;
            }
            else if (edit_flag == "2")
            {
                this.checkPid.Checked = false;
            }
            else if (edit_flag == "3")
            {
                this.checkPid.Checked = false;
            }
        }
        private bool valid_data()
        {
            if (this.textGid.Text == "")
            {
                MessageBox.Show("菜單序號不能為空!");
                this.textGid.Focus();
                return false;
            }
            if (this.textPid.Text == "")
            {
                MessageBox.Show("菜單上級節點不能為空!");
                this.textPid.Focus();
                return false;
            }
            if (this.textGid.Text == this.textPid.Text)
            {
                MessageBox.Show("本級節點不能和上級節點相同!");
                this.textGid.Focus();
                return false;
            }
            return true;
        }

        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@lang", "0");
            commUse.Cmd.Parameters.AddWithValue("@gid", Convert.ToInt32(textGid.Text));
            commUse.Cmd.Parameters.AddWithValue("@gdesc", textGdesc.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@fid", textFid.Text != "" ? Convert.ToInt32(textFid.Text) : 0);
            if (this.checkPid.Checked == false)
                commUse.Cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(textPid.Text));
            else
                commUse.Cmd.Parameters.AddWithValue("@pid", 0);//如果添加的是根節點
            commUse.Cmd.Parameters.AddWithValue("@gid_sort", textGidSort.Text != "" ? Convert.ToInt32(textGidSort.Text) : 0);

        }
        public override bool Bef_Del()
        {

            DialogResult MsgBoxResult;//设置对话框的返回值
            MsgBoxResult = MessageBox.Show("確定要刪除嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.No)
            {
                return false;
            }
            string strCode = "";
            strCode = "select gid from tb_sy_grant where pid = " + "'" + textGid.Text.Trim() + "'";
            try
            {
                DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                if (dtRows.Rows.Count>0)
                {
                    MessageBox.Show("這個節點存在下級節點,不能刪除！", "系統信息");
                    this.textFid.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系統信息");
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
                strCode = "DELETE FROM tb_sy_grant WHERE gid = @gid";
                ParametersAddValue();

                if (commUse.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("記錄已刪除", "系統信息");
                    this.BindDataGridView("");
                    this.BindingTree(1);
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
            }
            return del_flag;
        }

        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sent_obj_id = this.textGid.Text.ToString();
            Forms.frmNewDictLang frmNewDictLang = new Forms.frmNewDictLang(2, sent_obj_id);
            frmNewDictLang.Owner = this;
            frmNewDictLang.ShowDialog();
        }
    }
}
