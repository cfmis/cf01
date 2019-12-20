using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.IO;
using System.Web.UI;
using cf01.MDL;
using cf01.CLS;
using cf01.ModuleForm;

namespace cf01.Forms
{
    public partial class frmUserRole : Form
    {
        private mdlUser User = null;
        private mdlUserPopedom dtUP = null;
        private DataTable dtUserPopedom = new DataTable();
        private DataTable dts = null;
        private List<mdlUserPopedom> lsUserPopedom = null;

        private string FormName;
        public frmUserRole(mdlUser model)
        {
            InitializeComponent();
            User = model;

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmUserRole_Load(object sender, EventArgs e)
        {
            txtUserName.Text = User.Uname;
            txtuRole.Text = User.Role.Rname;
            BindingTree(User.Role.Rid);

            txtuRole.Enabled = false;
            txtUserName.Enabled = false;
            BTNSAVE.Enabled = false;
            dgvUserPopedom.ReadOnly = true;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;

            dgvUserPopedom.ReadOnly = false;
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            BTNEDIT.Enabled = true;
            BTNSAVE.Enabled = false;
            dgvUserPopedom.ReadOnly = true;
        }

        private void BindingTree(int Rid)
        {
            dts = clsRoleManage.GetGrantMenuByRid(false, Rid);

            DataRow[] r1s = dts.Select("Pid=0");

            treeView1.CheckBoxes = true;
            foreach (DataRow r1 in r1s)
            {
                string Gid = r1["Gid"].ToString();
                string Gdesc = r1["Gdesc"].ToString();
                string FuncName = r1["FuncName"].ToString();
                TreeNode root1 = new TreeNode(Gdesc);
                root1.Name = Gid;
                if (FuncName != "" && FuncName != null)
                {
                    root1.Tag = FuncName;
                }
                root1.Checked = r1["Rid"].ToString() == "" ? false : true;
                treeView1.Nodes.Add(root1);

                DataRow[] r2s = dts.Select("Pid=" + Gid);
                foreach (DataRow r2 in r2s)
                {
                    Gid = r2["Gid"].ToString();
                    Gdesc = r2["Gdesc"].ToString();
                    FuncName = r2["FuncName"].ToString();
                    TreeNode root2 = new TreeNode(Gdesc);
                    root2.Name = Gid;
                    if (FuncName != "" && FuncName != null)
                    {
                        root2.Tag = FuncName;
                    }
                    root2.Checked = r2["Rid"].ToString() == "" ? false : true;
                    root1.Nodes.Add(root2);

                    DataRow[] r3s = dts.Select("Pid=" + Gid);
                    foreach (DataRow r3 in r3s)
                    {
                        Gid = r3["Gid"].ToString();
                        Gdesc = r3["Gdesc"].ToString();
                        FuncName = r3["FuncName"].ToString();
                        TreeNode root3 = new TreeNode(Gdesc);
                        root3.Name = Gid;
                        if (FuncName != "" && FuncName != null)
                        {
                            root3.Tag = FuncName;
                        }
                        root3.Checked = r3["Rid"].ToString() == "" ? false : true;
                        root2.Nodes.Add(root3);
                    }
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag != null)
            {
                FormName = treeView1.SelectedNode.Tag.ToString();
                GetUserPopedomByPara(FormName);
            }

        }

        void GetUserPopedomByPara(string pFrmName)
        {
            dtUserPopedom = clsRoleManage.QueryButton(txtUserName.Text.Trim(), pFrmName);
            if (dtUserPopedom.Rows.Count > 0)
            {
                dgvUserPopedom.DataSource = null;
                dgvUserPopedom.AutoGenerateColumns = false;
                dgvUserPopedom.DataSource = dtUserPopedom;
                dgvUserPopedom.Refresh();
            }
        }


        public void Save()
        {
            SaveButtonState();
            if (lsUserPopedom.Count > 0)
            {
                int Reuslt = clsRoleManage.InsertUserPopedom(lsUserPopedom);

                if (Reuslt > 0)
                {
                    MessageBox.Show("保存成功！");
                    GetUserPopedomByPara(FormName);

                    BTNEDIT.Enabled = true;
                    BTNSAVE.Enabled = false;
                    dgvUserPopedom.ReadOnly = true;
                }
            }
        }


        private void SaveButtonState()
        {
            lsUserPopedom = new List<mdlUserPopedom>();
            for (int i = 0; i < dtUserPopedom.Rows.Count; i++)
            {
                dtUP = new mdlUserPopedom();
                if (dtUserPopedom.Rows[i]["Window_id"].ToString() == dgvUserPopedom.Rows[i].Cells["colWindow_id"].Value.ToString())
                {
                    dtUP.Usr_No = User.Uname;
                    dtUP.Window_Id = dgvUserPopedom.Rows[i].Cells["colWindow_id"].Value.ToString();
                    dtUP.C1_Id = dgvUserPopedom.Rows[i].Cells["colC1_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC1_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C1_State = 1;
                    }
                    else
                    {
                        dtUP.C1_State = 0;
                    }
                    dtUP.C2_Id = dgvUserPopedom.Rows[i].Cells["colC2_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC2_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C2_State = 1;
                    }
                    else
                    {
                        dtUP.C2_State = 0;
                    }
                    dtUP.C3_Id = dgvUserPopedom.Rows[i].Cells["colC3_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC3_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C3_State = 1;
                    }
                    else
                    {
                        dtUP.C3_State = 0;
                    }
                    dtUP.C4_Id = dgvUserPopedom.Rows[i].Cells["colC4_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC4_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C4_State = 1;
                    }
                    else
                    {
                        dtUP.C4_State = 0;
                    }
                    dtUP.C5_Id = dgvUserPopedom.Rows[i].Cells["colC5_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC5_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C5_State = 1;
                    }
                    else
                    {
                        dtUP.C5_State = 0;
                    }
                    dtUP.C6_Id = dgvUserPopedom.Rows[i].Cells["colC6_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC6_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C6_State = 1;
                    }
                    else
                    {
                        dtUP.C6_State = 0;
                    }
                    dtUP.C7_Id = dgvUserPopedom.Rows[i].Cells["colC7_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC7_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C7_State = 1;
                    }
                    else
                    {
                        dtUP.C7_State = 0;
                    }
                    dtUP.C8_Id = dgvUserPopedom.Rows[i].Cells["colC8_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC8_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C8_State = 1;
                    }
                    else
                    {
                        dtUP.C8_State = 0;
                    }
                    dtUP.C9_Id = dgvUserPopedom.Rows[i].Cells["colC9_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC9_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C9_State = 1;
                    }
                    else
                    {
                        dtUP.C9_State = 0;
                    }
                    dtUP.C10_Id = dgvUserPopedom.Rows[i].Cells["colC10_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC10_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C10_State = 1;
                    }
                    else
                    {
                        dtUP.C10_State = 0;
                    }                    
                    dtUP.C11_Id = dgvUserPopedom.Rows[i].Cells["colC11_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC11_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C11_State = 1;
                    }
                    else
                    {
                        dtUP.C11_State = 0;
                    }
                    dtUP.C12_Id = dgvUserPopedom.Rows[i].Cells["colC12_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC12_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C12_State = 1;
                    }
                    else
                    {
                        dtUP.C12_State = 0;
                    }
                    dtUP.C13_Id = dgvUserPopedom.Rows[i].Cells["colC13_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC13_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C13_State = 1;
                    }
                    else
                    {
                        dtUP.C13_State = 0;
                    }
                    dtUP.C14_Id = dgvUserPopedom.Rows[i].Cells["colC14_ID"].Value.ToString();
                    if ((bool)dgvUserPopedom.Rows[i].Cells["colC14_STATE"].EditedFormattedValue == true)
                    {
                        dtUP.C14_State = 1;
                    }
                    else
                    {
                        dtUP.C14_State = 0;
                    }

                    lsUserPopedom.Add(dtUP);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked == true)
                {
                    CheckNode(e.Node, true);
                }
                else
                {
                    CheckNode(e.Node, false);
                }
            }
        }

        private void CheckNode(TreeNode node, bool flag)
        {
            if (node.Nodes.Count == 0)
            {
                node.Checked = flag;
                if (flag == true)
                {
                    if (node.Level == 2)
                    {
                        node.Parent.Checked = true;
                        node.Parent.Parent.Checked = true;
                    }
                    else if (node.Level == 1)
                    {
                        node.Parent.Checked = true;
                    }
                }
            }
            else
            {
                foreach (TreeNode Tn in node.Nodes)
                {
                    CheckNode(Tn, flag);
                }
                node.Checked = flag;
            }
        }

    }
}
