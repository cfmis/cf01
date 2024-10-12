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
    public partial class frmGrantManage : Form
    {

        public frmGrantManage()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmGrantManage_Load(object sender, EventArgs e)
        {
            BindTreeView();
            BTNSAVE.Enabled = false;
            treeView1.Enabled = false;
            treeView2.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            treeView1.Enabled = true;
            treeView2.Enabled = true;
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView2.LabelEdit = false;
            treeView2.Nodes.Clear();
            string strRname = treeView1.SelectedNode.Text;
            int Rid = Convert.ToInt32(treeView1.SelectedNode.Name);

            BindingTree(Rid);
        }

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked == false)
                {
                    CheckNode(e.Node, false);
                }
                else
                {
                    CheckNode(e.Node, true);
                }
            }
        }

        private void BindingTree(int Rid)
        {
            DataTable dts = clsRoleManage.GetGrantMenuByRid(true, Rid);

            DataRow[] r1s = dts.Select("Pid=0");

            treeView2.CheckBoxes = true;
            foreach (DataRow r1 in r1s)
            {
                string Gid = r1["Gid"].ToString();
                string Gdesc = r1["Gdesc"].ToString();
                TreeNode root1 = new TreeNode(Gdesc);
                root1.Name = Gid;
                root1.Checked = r1["Rid"].ToString() == "" ? false : true;
                treeView2.Nodes.Add(root1);

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

        private void BindTreeView()
        {
            DataTable dt = clsRoleManage.GetAllRole();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode treeNode1 = new TreeNode(dt.Rows[i]["Rname"].ToString());
                treeNode1.Name = dt.Rows[i]["Rid"].ToString();
                treeView1.Nodes.Add(treeNode1);
            }
        }

        public void Save()
        {
            string strRname = treeView1.SelectedNode.Text;
            string strRid = treeView1.SelectedNode.Name;
            DataTable dtNode = GetTreeViewCheckData();
            try
            {
                int Result = clsRoleManage.AddRoleGrant(strRid, dtNode);
                if (Result > 0)
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BTNEDIT.Enabled = true;
                    BTNSAVE.Enabled = false;
                    treeView1.Enabled = false;
                    treeView2.Enabled = false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetTreeViewCheckData()
        {
            DataTable dt_grant = new DataTable();
            DataColumn colGid = new DataColumn("Gid", typeof(int));
            DataColumn colGdesc = new DataColumn("Gdesc", typeof(string));
            dt_grant.Columns.Add(colGid);
            dt_grant.Columns.Add(colGdesc);
            DataRow dr = null;
            foreach (TreeNode node in treeView2.Nodes)
            {
                if (node.Checked)
                {
                    dr = dt_grant.NewRow();
                    dr["Gdesc"] = node.Text;
                    dr["Gid"] = node.Name;
                    dt_grant.Rows.Add(dr);
                }
                foreach (TreeNode node2 in node.Nodes)
                {
                    if (node2.Checked)
                    {
                        dr = dt_grant.NewRow();
                        dr["Gdesc"] = node2.Text;
                        dr["Gid"] = node2.Name;
                        dt_grant.Rows.Add(dr);
                    }
                    foreach (TreeNode node3 in node2.Nodes)
                    {
                        if (node3.Checked)
                        {
                            dr = dt_grant.NewRow();
                            dr["Gdesc"] = node3.Text;
                            dr["Gid"] = node3.Name;
                            dt_grant.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt_grant;
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
                foreach (TreeNode n in node.Nodes)
                {
                    CheckNode(n, flag);
                }
                node.Checked = flag;

            }
        }




    }
}
