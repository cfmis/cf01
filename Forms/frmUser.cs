using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmUser : Form
    {
        private clsUser clsUser = new clsUser();
        private mdlUser modelUser = null;
        public string Operation;

        public frmUser(mdlUser model)
        {
            InitializeComponent();
            modelUser = model;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            BindcmbRole();
            BindUserGroup();

            InitControl();

        }

        void BindcmbRole()
        {
            DataTable dt = clsRoleManage.GetAllRole();
            cmbRole.DataSource = dt;
            cmbRole.DisplayMember = "Rname";
            cmbRole.ValueMember = "Rid";
            cmbRole.Text = "";
        }

        void BindUserGroup()
        {
            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'and typ_code<>'0'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    cmbUser_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }
            }
        }

        void InitControl()
        {
            txtUserName.Text = modelUser.Uname;
            txtUser_desc.Text = modelUser.Uname_Desc;

            if (!string.IsNullOrEmpty(modelUser.Language))
            {
                cmbLanguage.SelectedIndex = int.Parse(modelUser.Language);
            }
            else
                cmbLanguage.SelectedIndex = 0;
            if (modelUser.Role==null)
                cmbRole.Text = "";
            else
                cmbRole.Text = modelUser.Role.Rname.ToString();
            cmbUser_group.Text = modelUser.user_group;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateTextInput())
            {
                mdlUser User = new mdlUser();
                User.Uid = modelUser.Uid;
                User.Uname = txtUserName.Text.Trim();
                User.Uname_Desc = txtUser_desc.Text.Trim();
                User.Pwd = modelUser.Pwd;
                User.user_group = cmbUser_group.Text;

                Role modelRole = new Role();
                modelRole.Rid = Convert.ToInt32(cmbRole.SelectedValue);
                modelRole.Rname = cmbRole.Text.ToString();
                User.Language = cmbLanguage.SelectedIndex.ToString();
                User.Role = modelRole;

                switch (Operation)
                {
                    case "AddNew":
                        {
                            try
                            {
                                int Result = clsUser.AddUserInfo(User);
                                if (Result > 0)
                                {
                                    this.lblTitle.Visible = false;
                                    MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }

                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        break;
                    case "Update":
                        {
                            try
                            {
                                int Result = clsUser.UpdateUserInfo(User);
                                if (Result > 0)
                                {
                                    this.lblTitle.Visible = false;
                                    MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        break;
                }
            }
        }

        private bool ValidateTextInput()
        {
            if (cmbRole.Text == "")
            {
                MessageBox.Show("請選擇角色。");
                return false;
            }
            if (cmbLanguage.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇系統語言。");
                return false;
            }
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出？") == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.rid = cmbRole.SelectedIndex;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelUser.Language = cmbLanguage.SelectedIndex.ToString();
        }

        private void txtUser_desc_Validated(object sender, EventArgs e)
        {
            modelUser.Uname_Desc = txtUser_desc.Text.Trim();  //值保存至屬性
        }

        private void txtUserName_Validated(object sender, EventArgs e)
        {
            //string userid = txtUserName.Text.Trim();
            //this.Uname = userid; //用戶ID
            //if (userid != "")
            //{
            //    string sqlstr = "Select * from dbo.tb_sy_user Where uname='" + userid + "'";
            //    //DataTable dt = cf01.DataAccess.LoadSqlData.FillByAllData(sqlstr).Tables[0];
            //    DataTable dt = DBUtility.GetDataTable(sqlstr);
            //    if (dt.Rows.Count > 0) //用戶存在                
            //    {
            //        this.rid = (int)dt.Rows[0]["Rid"];    //角色
            //        DataTable dt_role = DBUtility.GetDataTable("Select * from dbo.tb_sy_role where rid=" + this.rid);
            //        cmbRole.Text = dt_role.Rows[0]["rname"].ToString();
            //        txtUser_desc.Text = dt.Rows[0]["Uname_desc"].ToString();
            //        this.uname_desc = txtUser_desc.Text.Trim();  //用戶描述
            //        int i = Convert.ToInt32(dt.Rows[0]["language"].ToString());
            //        cmbLanguage.Text = cmbLanguage.Items[i].ToString();
            //        this.language = cmbLanguage.SelectedIndex.ToString(); //語言
            //        this.lblTitle.Visible = false;
            //    }
            //    else
            //    {
            //        txtUser_desc.Text = userid;
            //        this.uname_desc = userid; //用戶描述                    
            //        cmbRole.Text = "";
            //        cmbLanguage.Text = cmbLanguage.Items[0].ToString();
            //        this.lblTitle.Visible = true;
            //    }
            //}
        }

    }
}
