using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;//反射
using cf01.ModuleClass;
using System.Drawing;

namespace cf01.Forms
{
    public partial class frm_Main_sub : Form
    {
        string name;
        string pwd;
        DataTable dt;
        public static bool isRunMain = false;
        //public static string user_name = ""; //debug
        //public static string user_pwd = "";
        private static string lang = "0";
        
        public frm_Main_sub()
        {
            InitializeComponent();
            //this.name = frm_Main.user_name;
            this.name = frm_Main.user_id;
            this.pwd = frm_Main.user_pwd;
            lang = DBUtility._language;
            dt = frm_Main.dt;
        }

        private void frm_test_Load(object sender, EventArgs e)
        {           
            //設置菜單
            if (DBUtility._language == "0")
            {
                this.Text = "菜單瀏覽";
            }
            else
            {
                this.Text = "Menu List";
            }
            
            try
            {
                InitMenu();
                MenuTree.ExpandAll();
                MenuTree.SelectedNode = MenuTree.Nodes[0];
            }
            catch
            {
                MenuTree.Nodes.Clear();
            }
        }

        protected void InitMenu()
        {
            //取出这个用户所在的角色的所有的权限
            DataRow[] drArr = Grant.getGrant(lang, name, pwd);

            //添加主菜单
            TreeNode TopNode;
            foreach (DataRow dr in drArr)
            {
                if (dr["Gname"].ToString() != "窗口" && dr["Gname"].ToString() != "Windows")
                {
                    //主菜单的条件Pid =0
                    if (String.Compare(dr["Pid"].ToString(), "0", false) == 0)
                    {
                        TopNode = new TreeNode();
                        TopNode.Text = SetCaption(dr["Gname"].ToString());
                        TopNode.Tag = dr["FormName"].ToString();//保存表單名                       
                        MenuTree.Nodes.Add(TopNode);
                        AddChildNode(TopNode, Convert.ToInt32(dr["Gid"]), dr["Uname"].ToString());//递归调用
                        //TopNode.ImageIndex = TopNode.SelectedImageIndex = 2;                        
                    }
                }
                
            }
        }


        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void AddChildNode(TreeNode subNode, int pid, string userName)
        {
            DataRow[] drArr = dt.Select(String.Format("Pid={0} and Uname='{1}'", pid, userName));//查出这个菜单的所有的子菜单            
            if (drArr.Length == 0)
            {
                subNode.ImageIndex = subNode.SelectedImageIndex = 1;
            }
            TreeNode subNode1;
            foreach (DataRow dr in drArr)
            {
                subNode1 = new TreeNode();//实例化一个菜单项
                subNode1.Text = SetCaption(dr["Gname"].ToString());//实例化一个菜单项
                string strFormname = dr["FormName"].ToString();
                subNode1.Tag = strFormname;//保存表單名
                subNode.Nodes.Add(subNode1);
                AddChildNode(subNode1, Convert.ToInt32(dr["Gid"]), dr["Uname"].ToString());//递归调用的方法                     

            }
        }

        private static string SetCaption(string strCation)
        {
            int iLen = 0;
            if (strCation.IndexOf("&") >= 0)
            {
                iLen = strCation.Trim().Length - 4;
            }
            else
            {
                iLen = strCation.Trim().Length;
            }
            strCation = strCation.Substring(0, iLen);
            return strCation;
        }

        private void MenuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            string path_formname = e.Node.Tag.ToString().Trim();
            Open_Form(path_formname, e.Node);

            //以下為舊代碼
            //string path_formname = e.Node.Tag.ToString().Trim();
            //// 原代碼：IF (path_formname != "") 
            //if (String.Compare(path_formname, "", false) != 0)        
            //{
            //    //获取实际的窗体名
            //    string formname = path_formname.Substring(path_formname.LastIndexOf(".") + 1, (path_formname.Length - (path_formname.LastIndexOf(".") + 1)));
            //    //检查如果窗体已运行，则不再建立                
            //    if (checkChildFrmExist(formname) == false)
            //    {
            //        Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
            //        Form f = (Form)asb.CreateInstance("cf01." + path_formname);//利用反射，根据数据库中的字段值创建窗体对象             
            //        //f.MdiParent = this;                   
            //        f.MdiParent = frm_Main.pMainWin;
            //        f.WindowState = FormWindowState.Normal;// FormWindowState.Maximized;
            //        f.Text = e.Node.Text; //設置窗體標題
            //        f.Show();
                    
            //    }
            //}
        }

        private static bool checkChildFrmExist(string childFrmName)
        {
            bool isExist_flag = false;
            foreach (Form childFrm in frm_Main.pMainWin.MdiChildren)
            {
                if (childFrm.Name == childFrmName)                 
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Maximized;
                    }
                    childFrm.Activate();                    
                    isExist_flag = true;
                    break ;
                }
            }            
            return isExist_flag;
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
            {
                MenuTree.ExpandAll();
                MenuTree.SelectedNode = MenuTree.Nodes[0];                
            }
            else
            {
                MenuTree.CollapseAll();
            }            
        }

        private void frm_Main_sub_Resize(object sender, EventArgs e)
        {
            SetLogoLocation();            
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SetLogoLocation();
        }

        private void SetLogoLocation()
        {
            this.pictureBox1.Location = new Point(palRight.Width / 2 - (this.pictureBox1.Width / 2),
                                                 palRight.Height / 2 - (this.pictureBox1.Height / 2));
        }

        private void MenuTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {           
            string path_formname = e.Node.Tag.ToString().Trim();
            Open_Form(path_formname,e.Node);
        }

        private void Open_Form(string strFormName,TreeNode node)
        {
            if (node.Nodes.Count > 0)
                return;
            if (!string.IsNullOrEmpty(strFormName))
            {
                //获取实际的窗体名
                string formname = strFormName.Substring(strFormName.LastIndexOf(".") + 1, (strFormName.Length - (strFormName.LastIndexOf(".") + 1)));
                //检查如果窗体已运行，则不再建立                
                if (checkChildFrmExist(formname) == false)
                {
                    Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
                    Form f = (Form)asb.CreateInstance("cf01." + strFormName);//利用反射，根据数据库中的字段值创建窗体对象             
                    //f.MdiParent = this;                   
                    f.MdiParent = frm_Main.pMainWin;
                    f.WindowState = FormWindowState.Normal;// FormWindowState.Maximized;
                    f.Text = node.Text; //設置窗體標題
                    f.Show();
                }
            }

        }


        }
        
    
    }
