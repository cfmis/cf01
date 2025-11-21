using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmLogin : Form
    {
        private clsUser clsUser = new clsUser();
        public frmLogin()
        {
            InitializeComponent();
        }
         
        private bool isPass { get; set; } //自定義屬性
        private void frmLogin_Load(object sender, EventArgs e)
        {
            isPass = false;            
            //===============2016-12-23添加以下代碼
            string strUser_info, userid, usser_name;
            strUser_info = GetMachineName();
            if (strUser_info == "")
            {
                userid = "";
                usser_name = "";
            }
            else
            {
                userid = strUser_info.Substring(0, strUser_info.IndexOf("&"));
                usser_name = strUser_info.Substring(strUser_info.IndexOf("&") + 1);
            }
            txtUserid.Text = userid;
            txtUserName.Text = usser_name;
            //==============

            string iIndex = DBUtility.GetAppConfig("language");//獲取默認的語言
            int i = int.Parse(iIndex); //Convert.ToInt16(iIndex);
            cmbLanguage.Text = cmbLanguage.Items[i].ToString();


            //設置默認的獲得焦點的控件
            this.ActiveControl = txtPassword;  //設置獲得點的控件必須與txtPassword.Focus()一起使用否則不起作用
            txtPassword.Focus();
            this.AcceptButton = btn_ok;//設置btn_ok按鈕響應Enter鍵           

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
                    if (clsUser.GetUserInfo(userid, pwd)) //傳兩個參數,以判斷當前用戶密碼是否正確
                    {
                        Forms.frm_Main.user_id = txtUserid.Text.Trim();                        
                        Forms.frm_Main.isRunMain = true; //設置調用主窗體的條件
                        //Forms.frm_Main.user_name = txtUserid.Text.Trim();                       
                        Forms.frm_Main.user_name = txtUserName.Text.Trim();
                        Forms.frm_Main.user_pwd = txtPassword.Text;

                        //if (this.cmbLanguage.Text != "") 
                        // {
                        //    //frmMainForm.lang = cmbLanguage.SelectedIndex.ToString();                            
                        //}
                        //MessageBox.Show(DBUtility._language);
                        //SaveLoginInfo(); //保存用戶登入信息
                        Save_LoginInfo();
                        DBUtility._user_id = userid;  //2014-08-15 因取消SaveLoginInfo()而增加此行代碼
                        DBUtility.user_name = txtUserName.Text.Trim();
                        DBUtility._language = cmbLanguage.SelectedIndex.ToString(); //設置用戶登入語言臨時公共變量   2014-08-01 因取消SaveLoginInfo()而增加此行代碼

                        /*
                        if (cmbLanguage.SelectedIndex == -1 || cmbLanguage.SelectedItem.ToString() == "")
                            PropertyClass.LanguageId = "0";
                        else
                            PropertyClass.LanguageId = cmbLanguage.SelectedIndex.ToString();
                         */
                        //關閉Login窗體
                        Close();
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
                MessageBox.Show("用戶帳號不可為空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserid.Focus();
            }
        }

        private void Save_LoginInfo()
        {
            //保存用戶信息
            string strMachine_id = System.Environment.MachineName;
            string strUserid = txtUserid.Text;
            string strUserName = txtUserName.Text;
            string strsql_f = string.Format("Select '1' From sys_login with(nolock) Where machine_id='{0}'", strMachine_id);
            string strsql_i = string.Format("INSERT INTO sys_login(machine_id,user_id,user_name) Values('{0}','{1}','{2}')", strMachine_id, strUserid, strUserName);
            string strsql_u = string.Format("Update sys_login SET user_id='{0}',user_name='{1}' Where machine_id='{2}'",strUserid,strUserName, strMachine_id);
            using (DataTable dt = clsPublicOfCF01.GetDataTable(strsql_f))
            {
                string result;
                if (dt.Rows.Count == 0)
                    result = clsPublicOfCF01.ExecuteSqlUpdate(strsql_i);
                else
                    result = clsPublicOfCF01.ExecuteSqlUpdate(strsql_u);
            }
        }

        private void SaveLoginInfo()
        {
            //保存用戶信息
            string strUserid = txtUserid.Text;
            string strUserName = txtUserName.Text;
            string strLanguage = cmbLanguage.SelectedIndex.ToString();
            if (strUserid != DBUtility.GetAppConfig("userid"))
            {
                DBUtility.UpdateAppConfig("userid", strUserid);

            }
            else
            {
                DBUtility._user_id = strUserid; //基類表單調用
            }
            if (strUserName != DBUtility.GetAppConfig("userName"))
            {
                DBUtility.UpdateAppConfig("userName", strUserName);
            }
            if (strLanguage != DBUtility.GetAppConfig("language")) //暫時不用,改為在權限設置中設定
            {
                DBUtility.UpdateAppConfig("language", cmbLanguage.SelectedIndex.ToString());
            }


            //判斷當前用戶選擇的語言與數據中保存的語言如不同，則更新數據中該用戶的登入語言
            string strSql = String.Format("Select language From  dbo.tb_sy_user where uname='{0}'", strUserid);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            DataRow[] dr = dt.Select();
            string strlang = dr[0]["language"].ToString().Trim();
            dt.Dispose();
            if (strlang != strLanguage)
            {
                try
                {
                    clsUser.UpdateUserLanguage(strLanguage, strUserid);
                    DBUtility._language = strLanguage; //設置用戶登入語言臨時公共變量                
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void txtUserid_TextChanged(object sender, EventArgs e)
        {

        }


        private static string GetMachineName()
        {
            try
            {
                string strReturn = "";
                string strmac_id = System.Environment.MachineName;
                using (SqlConnection sqlcon = new SqlConnection(DBUtility.connectionString))
                {
                    sqlcon.Open();
                    string strSql = string.Format(@"Select user_id,user_name From sys_login Where machine_id='{0}'", strmac_id);
                    SqlCommand sqlcom = new SqlCommand(strSql, sqlcon);
                    SqlDataReader sqlrd = sqlcom.ExecuteReader();
                    while (sqlrd.Read())
                    {
                        strReturn = string.Format("{0}&{1}", sqlrd[0], sqlrd[1]);                        
                    }
                    sqlrd.Close();
                }
                return strReturn;
            }
            catch //(Exception e)
            {
                return "";
            }
        }



    }
}
