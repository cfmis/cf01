using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmPass : Form
    {
        private clsUser clsUser = new clsUser();
        private bool isPass;
        public frmPass()
        {
            InitializeComponent();
        }     

        private void frmPass_Load(object sender, EventArgs e)
        {           
            isPass = false;
            txtUserid.Text = DBUtility._user_id;
            txtUserid.Focus();
            //設置默認的獲得焦點的控件
            ActiveControl = txtPassword;  //設置獲得點的控件必須與txtPassword.Focus()一起使用否則不起作用
            txtPassword.Focus();
            AcceptButton = btn_ok;//設置btn_ok按鈕響應Enter鍵
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string userid = txtUserid.Text.Trim();
            string pwd = txtPassword.Text.Trim();

            if (userid != "")
            {
                if (isPass != true)  //用戶直接按確定鈕
                {
                    txtUserName.Text = clsUser.IsExistUser(userid);
                    if (txtUserName.Text != "")
                    {
                        isPass = true;
                    }
                }
                if (isPass) //用戶帳號正確
                {
                    if (clsUser. GetUserInfo(userid, pwd)) //傳兩個參數,以判斷當前用戶密碼是否正確
                    {                       
                        this.DialogResult = DialogResult.OK; //當賦此值時，窗體自行關閉             
                    }
                    else
                    {                        
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                    }
                }
                else
                {
                    txtUserName.Text = "";
                    txtUserid.Focus();
                    txtUserid.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("用戶帳號不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserid.Focus();
            }
        }
     
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserid_Validated(object sender, EventArgs e)
        {
            string strUserid = txtUserid.Text.Trim();
            if (strUserid != "")  //輸入的帳號是否為空
            {
                string UserName = clsUser.IsExistUser(strUserid);
                if (UserName != "")  //返回的用戶名不為空，說明用戶存在
                {
                    txtUserName.Text = UserName;
                    isPass = true;
                }
                else
                {
                    txtUserName.Text = "";
                    txtUserid.Text = "";
                    txtUserid.Focus();
                    isPass = false;
                }
            }
            else
            {
                txtUserName.Text = "";
                isPass = false;
            }
        }
        
    }
}
