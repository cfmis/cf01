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

namespace cf01.Forms
{
    public partial class frmColorGroup : Form
    {
        private string edit_flag = "0";
        private string userid = DBUtility._user_id;
        private bool append_mode=false;
        private bool edit_mode = false;
        private int select_tab = 0;
        private string remote_db = DBUtility.remote_db;
        public frmColorGroup()
        {
            InitializeComponent();
        }

        private void initControls()
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew();
        }
        private void addNew()
        {
            append_mode = true;
            edit_mode = true;
            edit_flag = "1";
            cleanTextBox(1);
            setTextBoxEnabled();
            if (select_tab == 0)
                txtClr_Grp.Focus();
            else
                if (select_tab == 1)
                    txtClr_Id.Focus();
        }
        private void cleanTextBox(int clean_part)
        {
            if (select_tab == 0)
            {
                txtClr_Grp.Text = "";
                txtCdesc.Text = "";
            }
            else
                if (select_tab == 1)
                {
                    txtClr_Id.Text = "";
                    txtClr_Cdesc.Text = "";
                }

        }
        private bool checkValid()
        {
            if (txtClr_Grp.Text == "")
            {
                MessageBox.Show("顏色組別編號不能為空!");
                txtClr_Grp.Focus();
                return false;
            }
            if (select_tab == 0)
            {
                if (edit_flag == "1")//如果是新增狀態，檢查是否已存在編號
                {
                    if (checkExistId(0) == true)
                    {
                        MessageBox.Show("編號已存在,不能新增!");
                        return false;
                    }
                }
                else
                {
                    if (edit_flag == "2")//如果是編輯狀態，檢查是否已存在編號
                    {
                        if (checkExistId(0) == false)
                        {
                            MessageBox.Show("沒有要編輯的記錄!");
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (checkExistId(0) == false)
                {
                    MessageBox.Show("顏色組別記錄不存在!");
                    return false;
                }
                if (select_tab == 1)
                {
                    if (txtClr_Id.Text == "")
                    {
                        MessageBox.Show("顏色編號不能為空!");
                        txtClr_Id.Focus();
                        return false;
                    }
                    if (edit_flag == "1")//如果是新增狀態，檢查是否已存在編號
                    {
                        if (checkExistId(1) == true)
                        {
                            MessageBox.Show("編號已存在,不能新增!");
                            return false;
                        }
                    }
                    else
                    {
                        if (edit_flag == "2")//如果是編輯狀態，檢查是否已存在編號
                        {
                            if (checkExistId(1) == false)
                            {
                                MessageBox.Show("沒有要編輯的記錄!");
                                return false;
                            }
                        }
                    }
                }

            }
            return true;
        }
        private bool checkExistId(int type)
        {
            string clr_grp = txtClr_Grp.Text;
            if (type == 0)
            {
                string strSql = " Select clr_grp From mm_color_group Where clr_grp='" + clr_grp + "'";
                DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
                if (dtId.Rows.Count > 0)
                    return true;
            }
            else
                if (type == 1)
                {
                    string strSql = " Select clr_grp From mm_color_group_details Where clr_id='" + txtClr_Id.Text + "'";
                    DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
                    if (dtId.Rows.Count > 0)
                        return true;
                }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (edit_mode == false)
            {
                MessageBox.Show("不是編輯狀態!");
                return;
            }
            if (!checkValid())
                return;
            string clr_grp = "";
            string strSql = "";
            string result = "";
            clr_grp = txtClr_Grp.Text;
            if (select_tab == 0)
            {
                string cdesc = txtCdesc.Text;
                if (edit_flag == "1")//新增
                    strSql = string.Format(@"INSERT INTO mm_color_group (clr_grp,cdesc,crusr,crtim)
                    VALUES ('{0}','{1}','{2}',GETDATE())", clr_grp, cdesc, userid);
                else
                    strSql = string.Format(@"UPDATE mm_color_group SET cdesc='{0}',crusr='{1}',crtim=GETDATE()
                    WHERE clr_grp='{2}'"
                        , cdesc, userid, clr_grp);
            }
            else
                if (select_tab == 1)
                {
                    string clr_id = txtClr_Id.Text;
                    if (edit_flag == "1")//新增
                        strSql = string.Format(@"INSERT INTO mm_color_group_details (clr_grp,clr_id,crusr,crtim)
                    VALUES ('{0}','{1}','{2}',GETDATE())", clr_grp, clr_id, userid);
                    else
                        strSql = string.Format(@"UPDATE mm_color_group_details SET crusr='{1}',crtim=GETDATE()
                    WHERE clr_grp='{1}' And clr_id='{2}'"
                            , userid, clr_grp,clr_id);
                }

            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                loadData();
                setTextBoxEnabled();
                addNew();
            }
        }
        private void loadData()
        {
            string strSql = "";
            if (select_tab == 0)
            {
                strSql = "Select * from mm_color_group order by clr_grp";
                DataTable dtClr_Grp = clsPublicOfCF01.GetDataTable(strSql);
                dgvDetails.DataSource = dtClr_Grp;
            }
            else
                if (select_tab == 1)
                {
                    strSql = "Select a.*,c.cdesc AS color_group_cdesc,b.clr_cdesc" +
                        " from mm_color_group_details a"+
                        " Inner Join mm_color_group c On a.clr_grp=c.clr_grp" +
                        " Left Join bs_color b ON a.clr_id=b.clr_code" +
                        " Where a.clr_grp='" + txtClr_Grp.Text + "' order by a.clr_grp,a.clr_id";
                    DataTable dtClr_Id = clsPublicOfCF01.GetDataTable(strSql);
                    dgvClr_Id.DataSource = dtClr_Id;
                }
        }
        private void fillTextBox(int rows)
        {
            edit_flag = "0";
            append_mode = false;
            edit_mode = false;
            setTextBoxEnabled();
            if (select_tab == 0)
            {
                if (dgvDetails.Rows.Count == 0)
                    return;
                cleanTextBox(0);//全部清空文本框
                DataGridViewRow CurrentRow = dgvDetails.Rows[rows];
                txtClr_Grp.Text = CurrentRow.Cells["colClr_Grp"].Value.ToString();
                txtCdesc.Text = CurrentRow.Cells["colCdesc"].Value.ToString();
            }
            else
                if (select_tab == 1)
                {
                    if (dgvClr_Id.Rows.Count == 0)
                        return;
                    cleanTextBox(0);//全部清空文本框
                    DataGridViewRow CurrentRow = dgvClr_Id.Rows[rows];
                    txtClr_Id.Text = CurrentRow.Cells["colClr_Id"].Value.ToString();
                    txtClr_Cdesc.Text = CurrentRow.Cells["colClr_Cdesc"].Value.ToString();
                }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillTextBox(dgvDetails.CurrentCell.RowIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            edit_flag = "2";
            append_mode = false;
            edit_mode = true;
            setTextBoxEnabled();
        }
        private void setTextBoxEnabled()
        {
            if (select_tab == 0)
            {
                txtClr_Grp.Properties.ReadOnly = !append_mode;
                if (append_mode == true && edit_mode == true)

                    txtClr_Grp.BackColor = Color.White;
                else
                    txtClr_Grp.BackColor = Color.Silver;
            }
            else
                if (select_tab == 1)
                {
                    txtClr_Id.Properties.ReadOnly = !append_mode;
                    if (append_mode == true && edit_mode == true)

                        txtClr_Id.BackColor = Color.White;
                    else
                        txtClr_Id.BackColor = Color.Silver;
                }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            string result = "";
            string clr_grp = txtClr_Grp.Text;
            string strSql = "";
            if (select_tab == 0)
            {
                if (checkExistId(0) == false)
                {
                    MessageBox.Show("沒有要刪除的記錄!");
                    return;
                }
                DataTable dtId;
                strSql = " Select clr_grp From mm_color_group_details Where clr_grp='" + clr_grp + "'";
                dtId = clsPublicOfCF01.GetDataTable(strSql);
                if (dtId.Rows.Count > 0)
                {
                    MessageBox.Show("顏色明細表中還存在記錄,不能刪除!");
                    return;
                }
                else
                {
                    strSql = " Select clr_grp From mm_color_group_size Where clr_grp='" + clr_grp + "'";
                    dtId = clsPublicOfCF01.GetDataTable(strSql);
                    if (dtId.Rows.Count > 0)
                    {
                        MessageBox.Show("尺寸明細表中還存在記錄,不能刪除!");
                        return;
                    }
                }
                strSql = string.Format(@"DELETE mm_color_group WHERE clr_grp='{0}'", clr_grp);
                result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            }
            else
                if (select_tab == 1)
                {
                    if (checkExistId(1) == false)
                    {
                        MessageBox.Show("沒有要刪除的記錄!");
                        return;
                    }
                    strSql = string.Format(@"DELETE mm_color_group_details WHERE clr_grp='{0}' And clr_id='{1}'", clr_grp, txtClr_Id.Text.Trim());
                    result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
                }

            if (result != "")
                MessageBox.Show("刪除記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                loadData();
                setTextBoxEnabled();
                cleanTextBox(0);//清空全部文本框
            }
        }

        private void xtc1_Click(object sender, EventArgs e)
        {
            select_tab = xtc1.SelectedTabPageIndex;
            setTextBoxEnabled();
            cleanTextBox(0);
            loadData();
        }

        private void dgvClr_Id_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillTextBox(dgvClr_Id.CurrentCell.RowIndex);
        }

        private void txtSize_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void frmColorGroup_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            dgvClr_Id.AutoGenerateColumns = false;
            initControls();
            setTextBoxEnabled();
            loadData();
        }
    }
}
