using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.Forms;
using cf01.ModuleClass;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmUserList : Form
    {
        private clsUser clsUser = new clsUser();
        enum enuOperation
        {
            AddNew,
            Update
        }
        public frmUserList()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            InitGridData();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            InitGridData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtUserId.Text = dgvDetails.Rows[e.RowIndex].Cells["colUname"].Value.ToString();
                txtUserName.Text = dgvDetails.Rows[e.RowIndex].Cells["colUname_desc"].Value.ToString();
            }
        }

        /// <summary>
        /// 編輯用戶
        /// </summary>
        private void Edit()
        {
            if (dgvDetails.RowCount > 0)
            {
                int icurrInex = dgvDetails.CurrentRow.Index;
                if (dgvDetails.Rows[icurrInex].Cells["colRid"].Value != null)
                {
                    DataTable dt = (DataTable)dgvDetails.DataSource;
                    string strUname = dt.Rows[icurrInex]["Uname"].ToString();
                    string strDesc = dt.Rows[icurrInex]["Uname_desc"].ToString();

                    mdlUser ModelUser = new mdlUser();
                    ModelUser.Uid = Convert.ToInt32(dt.Rows[icurrInex]["Uid"]);
                    ModelUser.Uname = strUname;
                    ModelUser.Uname_Desc = strDesc;
                    string strlanguage = "0";
                    //0--繁體中文
                    //1--簡體中文
                    //2--English
                    if (dt.Rows[icurrInex]["language"].ToString() == "繁體中文")
                        strlanguage = "0";
                    if (dt.Rows[icurrInex]["language"].ToString() == "簡體中文")
                        strlanguage = "1";
                    if (dt.Rows[icurrInex]["language"].ToString() == "English")
                        strlanguage = "2";
                    ModelUser.Language = strlanguage;//Convert.ToChar(dt.Rows[icurrInex]["language"]);  // todo:增加 language 列
                    ModelUser.user_group = dt.Rows[icurrInex]["user_group"].ToString();

                    Role modelRole = new Role();
                    modelRole.Rid = Convert.ToInt32(dt.Rows[icurrInex]["Rid"]);
                    modelRole.Rname = dt.Rows[icurrInex]["Rname"].ToString();
                    ModelUser.Role = modelRole;

                    frmUser frmU = new frmUser(ModelUser);
                    frmU.Operation = enuOperation.Update.ToString();
                    frmU.ShowDialog();

                    InitGridData();

                }
                else
                {
                    MessageBox.Show("请给用户分配角色！");
                }
            }
            else
            {
                MessageBox.Show("沒有可進行編輯的用戶！");
            }
        }

        /// <summary>
        /// 新增用戶
        /// </summary>
        private void Add()
        {
            if (dgvDetails.RowCount > 0)
            {
                string strUname = dgvDetails.CurrentRow.Cells["colUname"].Value.ToString();
                bool IsExist = clsUser.IsExistForAdd(strUname);

                if (IsExist)
                {
                    mdlUser ModelUser = new mdlUser();
                    ModelUser.Uname = strUname;
                    ModelUser.Uname_Desc = dgvDetails.CurrentRow.Cells["colUname_desc"].Value.ToString();
                    ModelUser.Pwd = dgvDetails.CurrentRow.Cells["colPwd"].Value.ToString();

                    frmUser frmU = new frmUser(ModelUser);
                    frmU.Operation = enuOperation.AddNew.ToString();
                    if (frmU.ShowDialog() == DialogResult.OK)
                    {

                    }
                    InitGridData();
                }
                else
                {
                    MessageBox.Show(strUname + "用户信息已添加，請重查找未添加的用戶！");
                }
            }
            else
            {
                MessageBox.Show("請重新查找未添加的用戶！");
            }
        }

        private void InitGridData()
        {
            DataTable dtUserInfo = clsUser.QueryUserInfo(txtUserId.Text.Trim(), txtUserName.Text.Trim());
            if (dtUserInfo.Rows.Count > 0)
            {
                dgvDetails.AutoGenerateColumns = false;
                dgvDetails.AllowUserToAddRows = false;
                dgvDetails.DataSource = dtUserInfo;
                dgvDetails.Refresh();
            }
            else
            {
                dgvDetails.DataSource = null;
            }
        }

        private void Find()
        {
            if (CheckText())
            {
                DataTable dt = clsUser.GetUserById(txtUserId.Text.Trim(), txtUserName.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dgvDetails.AutoGenerateColumns = false;
                    dgvDetails.AllowUserToAddRows = false;
                    dgvDetails.DataSource = dt;
                    dgvDetails.Refresh();
                }
                else
                {
                    dgvDetails.DataSource = null;
                }
            }
        }

        private bool CheckText()
        {
            if (txtUserId.Text == "" && txtUserName.Text == "")
            {
                MessageBox.Show("请输入查询條件！");
                return false;
            }
            return true;
        }

        private void Delete()
        {
            if (dgvDetails.RowCount > 0)
            {
                if (dgvDetails.CurrentRow.Cells["colRid"].Value != null)
                {
                    if (MessageBox.Show("確認要刪除該用戶？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int Uid = Convert.ToInt32(dgvDetails.CurrentRow.Cells["colUid"].Value);
                        int Result = clsUser.DelUserInfo(Uid);
                        if (Result > 0)
                        {
                            MessageBox.Show("用户已删除！");
                            txtUserId.Text = "";
                            txtUserName.Text = "";

                            InitGridData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("該用戶不是CF系統用戶，無法刪除。");
                }
            }
            else
            {
                MessageBox.Show("沒有可以刪除的用戶信息。");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            int icurrIndex = dgvDetails.CurrentRow.Index;
            if (dgvDetails.Rows[icurrIndex].Cells["colRid"].Value != null)
            {
                mdlUser ModelUser = new mdlUser();
                ModelUser.Uname = dgvDetails.Rows[icurrIndex].Cells["colUname"].Value.ToString();
                ModelUser.Uid = Convert.ToInt32(dgvDetails.Rows[icurrIndex].Cells["colUid"].Value);

                Role roleModel = new Role();
                roleModel.Rid = Convert.ToInt32(dgvDetails.Rows[icurrIndex].Cells["colRid"].Value);
                roleModel.Rname = dgvDetails.Rows[icurrIndex].Cells["colRname"].Value.ToString();
                ModelUser.Role = roleModel;

                frmUserRole frmUR = new frmUserRole(ModelUser);
                if (frmUR.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else
            {
                MessageBox.Show("请为该用户分配角色！");
            }
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text = "";
        }







    }
}
