using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace cf01.Forms
{
    public partial class frmConfig : Form
    {
        public static bool flag_readonly = true;  //讀取或配置連接信息的變量
        private bool flag_test;
        public frmConfig()
        {
            InitializeComponent();
            flag_test = false;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string strcon = GetString();//組裝的連接字符串
            if (strcon != "" && flag_test)
            {
                strcon = DBUtility.Encrypt(strcon);//加密 
                DBUtility.UpdateAppConfig("conn_string_dgsql1", strcon); //保存
                MessageBox.Show("數據庫連接配置成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("配置信息不可為空，或先進行連接測試！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 將字符連接在一起
        /// </summary>
        /// <returns></returns>
        private string GetString()
        {
            string strcon = "";
            string strSeverName = txt_Servername.Text.Trim();
            string strDatabase = txt_database.Text.Trim();
            string strLoginid = txt_loginid.Text.Trim();
            string strPassword = txt_password.Text.Trim();
            strcon = "server=" + strSeverName + ";database =" + strDatabase + ";uid=" + strLoginid + ";pwd=" + strPassword+";";
            return strcon;
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            flag_test = false;
            string strcon = GetString();
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    flag_test = true;
                    conn.Close();
                    MessageBox.Show("連接數據庫成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    flag_test = false;
                }
            }
            catch (SqlException)
            {
                //throw new Exception(E.Message);
                MessageBox.Show("連接數據庫出錯,請返回檢查！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            if (flag_readonly) //只讀
            {
                txt_Servername.ReadOnly = true;
                txt_database.ReadOnly = true;
                txt_loginid.ReadOnly = true;
                txt_password.ReadOnly = true;
                btn_test.Enabled = false;
                btn_test.Visible = false;
                btn_save.Enabled = false;
                btn_save.Visible = false;

                string sqlstring = DBUtility.GetAppConfig("conn_string_dgsql1");
                sqlstring = DBUtility.Decrypt(sqlstring);               
                sqlstring = sqlstring.Replace(" ", "");//去掉空格
                sqlstring = sqlstring.ToUpper();

                txt_Servername.Text = GetConString(sqlstring,"SERVER=", 7);
                txt_database.Text = GetConString(sqlstring,"DATABASE=", 9);
                txt_loginid.Text = GetConString(sqlstring,"UID=", 4);
                txt_password.Text = GetConString(sqlstring,"PWD=", 4);
            }
            else
            {
                txt_Servername.ReadOnly = false;
                txt_database.ReadOnly = false;
                txt_loginid.ReadOnly = false;
                txt_password.ReadOnly = false;
                btn_test.Enabled = true;
                btn_test.Visible = true;
                btn_save.Enabled = true;
                btn_save.Visible = true;
            }
        }

        /// <summary>
        /// 分解數據庫連接字符串
        /// </summary>
        /// <returns></returns>
        private string GetConString(string con_string,string strname, int len)
        {
            int i;
            int location = 0;
            string str = "";
            string strChar = "";

            int lenth = con_string.Length;
            location = con_string.IndexOf(strname);
            for (i = 0; (i < lenth); ++i)
            {
                strChar = con_string.Substring(location + len + i, 1);
                if (strChar != ";")
                {
                    str = str + strChar;
                }
                else
                {
                    break;
                }
            }
            return str;
        }




    }
}
