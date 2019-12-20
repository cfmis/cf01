using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;//反射
using cf01.ModuleClass;

namespace cf01.Forms
{
    public partial class frm_Main : Form
    {
        frmSplash frm_splash;
        string name;
        string UserName;
        string pwd;
        bool isexit = false;
        public static DataTable dt;
        public static bool isRunMain = false;
        public static string user_id = ""; // 此變量由Login畫面轉值，debug 時可設爲"admin"
        public static string user_name = "";
        public static string user_pwd = "";
        private static string lang = "0";
        public static frm_Main pMainWin;

        public frm_Main()
        {
            InitializeComponent();
            frm_splash = new frmSplash();
            frm_splash.Show();

            this.name = user_id;
            this.UserName = user_name;
            this.pwd = user_pwd;
            lang = DBUtility._language;
            dt = Grant.getAllGrant(lang, name);
            this.isexit = false;
            pMainWin = this;
        }

        private void frm_t_Load(object sender, EventArgs e)
        {
            //=========設置Tree Menu=======
            frm_Main_sub frmb = new frm_Main_sub();
            openMDI(frmb, true);
            frmb.Dock = DockStyle.Fill;
            //=============================

            //取出这个用户所在的角色的所有的权限
            DataRow[] drArr = Grant.getGrant(lang, name, pwd);
            //if (drArr.Length  == 0)
            //{
            //    MessageBox.Show("該用戶的權限暫未開通!");
            //    this.Close();
            //}
            //添加主菜单
            ToolStripMenuItem tsi;
            foreach (DataRow dr in drArr)
            {
                //主菜单的条件Pid =0
                if (dr["Pid"].ToString() == "0")
                {
                    tsi = new ToolStripMenuItem(dr["Gname"].ToString());
                    menuStrip.Items.Add(tsi);//把一级菜单添加到菜单栏上
                    if (dr["Gname"].ToString() != "窗口" && dr["Gname"].ToString() != "Windows")
                    {
                        AddChildMenu(tsi, Convert.ToInt32(dr["Gid"]), dr["Uname"].ToString());//递归调用的方法
                    }

                    if (dr["Gname"].ToString() == "窗口" || dr["Gname"].ToString() == "Windows")
                    {
                        this.menuStrip.MdiWindowListItem = tsi; //this.窗口列表menuStrip1MenuItem;
                    }
                }
            }

            //沒置狀態條
            this.lblUserinfo.Text = String.Format("Login ID : {0}   Date : {1:yyyy-MM-dd}",UserName, DateTime.Now);

        }

        /// <summary>
        /// 递归调用的方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void AddChildMenu(ToolStripMenuItem tsi1, int pid, string userName)
        {
            DataRow[] drArr = dt.Select(String.Format("Pid={0} and Uname='{1}'", pid, userName));//查出这个菜单的所有的子菜单
            ToolStripMenuItem tsi;
            foreach (DataRow dr in drArr)
            {
                tsi = new ToolStripMenuItem(dr["Gname"].ToString());//实例化一个菜单项                
                tsi.Tag = dr["FormName"].ToString();//保存窗体名称
                if (dr["FormName"].ToString() != "" || dr["Gname"].ToString() == "退出系統(&X)" || dr["Gname"].ToString() == "Exit(&X)")//如果这个菜单有对应的窗体
                {
                    tsi.Click += new EventHandler(tsi_Click);//订阅菜单点擊事件
                }
                tsi1.DropDown.Items.Add(tsi);//在菜单项上添加子菜单
                AddChildMenu(tsi, Convert.ToInt32(dr["Gid"]), dr["Uname"].ToString());//递归调用的方法
            }
        }


        /// <summary>
        /// 事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsi_Click(object sender, EventArgs e)
        {
            string path_formname = "";
            string formname = "";
            ToolStripMenuItem tsi = sender as ToolStripMenuItem;//得到事件源，强转为菜单项            
            path_formname = tsi.Tag.ToString();
            if (tsi.Text == "退出系統(&X)" || tsi.Text == "Exit(&X)")
            {
                this.Close();  //調用主窗體中的CLOSE方法                
            }


            //获取实际的窗体名
            formname = path_formname.Substring(path_formname.LastIndexOf(".") + 1, (path_formname.Length - (path_formname.LastIndexOf(".") + 1)));
            //检查如果窗体已运行，则不再建立
            if (checkChildFrmExist(formname) == false)
            {
                Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
                Form f = (Form)asb.CreateInstance("cf01." + path_formname);//利用反射，根据数据库中的字段值创建窗体对象             
                //if (path_formname != "" && (path_formname != "EXIT")) // && (path_formname != "Cascade") && (path_formname != "TileVertical")
                //&& (path_formname != "TileHorizontal") && (path_formname != "ArrangeIcons") && (path_formname != "EXIT"))
                if (path_formname != "" && (path_formname != "Exit(&X)"))
                {
                    f.MdiParent = this;
                    f.WindowState = FormWindowState.Maximized;
                    f.Text = tsi.Text; //設置窗體標題
                    f.Show();
                }
            }
        }


        public void openMDI(Form frm, bool full)
        {
            frm.MdiParent = this;
            if (full)
            {
                frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
            }
            frm.Show();
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
                    break;
                }
            }
            return isExist_flag;
        }

        private void frm_t_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isexit == false)
            {
                if (MessageBox.Show("確定退出系統?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    foreach (Form childForm in MdiChildren)
                    {
                        childForm.Close();
                    }
                    isexit = true; //設置系統退出變量
                    pMainWin.Dispose();
                    Application.Exit();
                }
                else
                {
                    isexit = false; //設置系統退出變量                
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frm_splash.Dispose();       //关闭SplashScreen

            this.WindowState = FormWindowState.Maximized;//.Normal;      //打开主界面

            timer1.Enabled = false;    //关闭timer1
        }


    }


}

