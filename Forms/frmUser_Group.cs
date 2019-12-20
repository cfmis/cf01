using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using System.Text;

namespace cf01.Forms
{
    public partial class frmUser_Group : Form

    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;       
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示     
        DataTable dtUser_group = new DataTable();
        private DataTable dtGroup = new DataTable();
        
        public frmUser_Group()
        {
            InitializeComponent();

            str_language = DBUtility._language;

            try
            {
                clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                control.GenerateContorl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性

        }

        private void frmUser_Group_Load(object sender, EventArgs e)
        {
            string strSql = @"Select typ_code AS id,typ_code+' ('+typ_cdesc+')' AS cdesc From bs_type Where typ_group='3'";
            DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(strSql);
            txtGroup_id.Properties.DataSource = dtSales_Group;
            txtGroup_id.Properties.ValueMember = "id";
            txtGroup_id.Properties.DisplayMember = "cdesc";

            dtGroup = dtSales_Group.Copy();

            //生成gridview1明細表結構
            strSql = @"SELECT usrid,grpid,usrusr AS crusr,usrtim AS crtim,usrhrst,grpid as old_grpid 
                        FROM dbo.sy_user_group WHERE 1=0";
            dtUser_group = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dtUser_group;
        }

        private void frmUser_Group_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvDetails.Dispose();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNDEL_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            Excel();
        }


        // ===============以下爲自定義方法=======================

        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDEL.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
        }
           

        private bool Valid_Doc(string pUser_id,string pGroup_id) //檢查主建是否已存在
        {
            bool flag;           
            string strSql = String.Format("Select '1' FROM sy_user_group WHERE usrid='{0}' AND grpid='{1}'", pUser_id, pGroup_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + String.Format("【{0}】,【{1}】", pUser_id, pGroup_id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            if (txtID.Text == "" || txtGroup_id.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "用戶賬號或組別資料不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strsql = String.Format(@"SELECT usrid,grpid,usrusr AS crusr,usrtim AS crtim,usrhrst,grpid as old_grpid FROM dbo.sy_user_group WHERE usrid='{0}' AND ISNULL(usrhrst,'')='Y'", temp_id);
                dtUser_group = clsPublicOfCF01.GetDataTable(strsql);
                dgvDetails.DataSource = dtUser_group;
                if (dtUser_group.Rows.Count == 0)
                {
                    if (str_language == "2")
                    {
                        msgCustom = "The User ID does not exist.";
                    }
                    else
                    {
                        msgCustom = "沒有符合該用戶帳號的數據!";
                    }
                    MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetObjValue.ClearObjValue(this.Controls,"2");                       
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                }
                Set_Master_Data(dtUser_group);
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.Text = dtName.Rows[0]["usrid"].ToString();            
            txtGroup_id.EditValue = dtName.Rows[0]["grpid"].ToString();            
            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtOld_grpid.Text = dtName.Rows[0]["old_grpid"].ToString(); 
        }

        private void Set_Row_Position(string _doc) //定位到當前行 
        {
            Find();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (_doc == dgvDetails.Rows[i].Cells["usrid"].Value.ToString())
                {
                    dgvDetails.Rows[i].Selected = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["usrid"]; //設置光標定位到當前選中的行
                    break;
                }
            }
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
            btnSelect_group.Enabled = true;
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls,true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID);
            }
            btnSelect_group.Enabled = false;
            dgvGroup.DataSource = null;
        }

        private void Save()  //保存新增或修改的資料
        {
            if (!Save_Before_Valid())
            {
                return;
            }
            bool save_flag = false;
            if (mState == "NEW")
            { 
                if (Valid_Doc(txtID.Text.Trim(), txtGroup_id.EditValue.ToString())==false)
                {
                    save_flag = Data_Insert(txtGroup_id.EditValue.ToString());
                }

                for (int i = 0; i < dgvGroup.Rows.Count; i++)
                {
                    if ((bool)dgvGroup.Rows[i].Cells["chkSelect"].EditedFormattedValue)
                    {
                        string strGroup = dgvGroup.Rows[i].Cells["id"].Value.ToString();
                        if (Valid_Doc(txtID.Text.Trim(), strGroup)==true)
                        {
                            continue;//只新增不存在的
                        }                            
                        save_flag = Data_Insert(strGroup);
                    }
                }
            }

            if (mState == "EDIT")
            {
                const string sql_update =
                    @"UPDATE sy_user_group SET grpid=@grpid,usrusr=@crusr,usrtim=getdate(),usrhrst='Y' WHERE usrid=@usrid AND grpid=@old_grpid";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@usrid", txtID.Text.Trim());                     
                        myCommand.Parameters.AddWithValue("@grpid", txtGroup_id.EditValue);
                        myCommand.Parameters.AddWithValue("@old_grpid", txtOld_grpid.Text); 
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        save_flag = true;
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        save_flag = false;
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }
            }

            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            mState = "";
            btnSelect_group.Enabled = false;
            dgvGroup.DataSource = null;

            Set_Row_Position(txtID.Text.Trim());
            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Data_Insert(string pGroup_id)
        {
            bool save_flag = false;
            const string sql_new =
                   @"INSERT INTO sy_user_group(usrid,grpid,usrusr,usrtim,usrhrst) values(@usrid,@grpid,@crusr,getdate(),'Y')";
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.CommandText = sql_new;
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@usrid", txtID.Text.Trim());
                    myCommand.Parameters.AddWithValue("@grpid", pGroup_id);
                    myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                }
            }
            return save_flag;
        }


        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM sy_user_group WHERE usrid=@usrid AND grpid=@grpid";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@usrid", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@grpid", txtGroup_id.EditValue.ToString());
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }

            }
        }

        private void Find() //查詢出所有數據
        {
            StringBuilder myString = new StringBuilder(@"SELECT usrid,grpid,usrusr as crusr,usrtim as crtim,usrhrst,grpid AS old_grpid 
                            FROM dbo.sy_user_group WHERE 1>0 ");
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                myString.Append(string.Format(" AND usrid='{0}'", textBox2.Text));
            }
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                myString.Append(string.Format(" AND grpid='{0}'",textBox1.Text));
            }
            myString.Append(@" AND ISNULL(usrhrst,'')='Y'");            
            dgvDetails.Focus();
            dtUser_group = clsPublicOfCF01.GetDataTable(myString.ToString());
            dgvDetails.DataSource = dtUser_group;
        }

        private void Print() //通用的打印方法
        {
            if (dgvDetails.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvDetails);
            }
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(dgvDetails);
            }
        }


        //===========以下爲控件中的方法================
        private void txtID_Leave(object sender, EventArgs e)
        {            
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                if (mState == "")
                {
                    Find_doc(txtID.Text);
                }

                if (mState == "NEW")
                {
                    DataTable dt = clsPublicOfCF01.GetDataTable(string.Format("SELECT '1' FROM dbo.tb_sy_user WHERE Uname='{0}'",txtID.Text));
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("該用戶資料不存在!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtID.Text = "";
                        txtID.Focus();
                    }
                }
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtID.Text = dgvDetails.CurrentRow.Cells["usrid"].Value.ToString();                
                txtGroup_id.EditValue = dgvDetails.CurrentRow.Cells["grpid"].Value.ToString();                
                txtCrusr.Text = dgvDetails.CurrentRow.Cells["crusr"].Value.ToString();
                txtCrtim.Text = dgvDetails.CurrentRow.Cells["crtim"].Value.ToString();
                txtOld_grpid.Text = dgvDetails.CurrentRow.Cells["old_grpid"].Value.ToString();
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void txtGroup_id_Click(object sender, EventArgs e)
        {
            txtOld_grpid.SelectAll();
        }

        private void btnSelect_group_Click(object sender, EventArgs e)
        {
            dgvGroup.DataSource = dtGroup;
        }

        private void dgvGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroup.RowCount > 0)
            {
                if (string.IsNullOrEmpty(txtGroup_id.Text))
                {
                    txtGroup_id.EditValue = dgvGroup.CurrentRow.Cells["id"].Value.ToString();
                }
            }
        }
        
       
          
     
    }
}
