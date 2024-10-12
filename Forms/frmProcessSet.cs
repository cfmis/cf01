using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmProcessSet : Form
    {

        public string mID = "";    //臨時的主鍵值
        public string mDept = "";  //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        MsgInfo myMsg = new MsgInfo();
        DataTable dtDetails = new DataTable();
        public frmProcessSet()
        {
            InitializeComponent();

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

            NextControl oNext = new NextControl(this, "1");
            oNext.EnterToTab();
        }

        private void frmProcess_Type_Size_Load(object sender, EventArgs e)
        {
            DataTable dtDept = clsProcessData.Get_dept();
            txtDept.Properties.DataSource = dtDept;
            txtDept.Properties.ValueMember = "dep_id";
            txtDept.Properties.DisplayMember = "dep_cdesc";  
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            dtDetails = clsProcessData.Find_Doc();            
            dgvDetails.DataSource = dtDetails;            
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            clsGeneralDataConvert.GridView_To_Print(dgvDetails);            
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            clsGeneralDataConvert.GridView_To_Excel(dgvDetails);
        }

        private void txtDept_Click(object sender, EventArgs e)
        {
            txtDept.SelectAll();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {           
            Find_Doc(txtDept.EditValue.ToString(), txtID.Text);
        }

        private void txtDept_Leave(object sender, EventArgs e)
        {
            Find_Doc(txtDept.EditValue.ToString(), txtID.Text);
        }


        // ===============以下爲自定義義方法=======================

     

        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
        }      
        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
            dgvDetails.Enabled = false;
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            SetButtonSatus(true);            
            SetObjValue.SetEditBackColor(this.Controls, false);
            txtDept.Properties.ReadOnly = false;
            txtDept.Enabled = true;
            mState = "";
            dgvDetails.Enabled = true;
            if (!String.IsNullOrEmpty(mID) && !String.IsNullOrEmpty(mID))
            {
                Find(mDept,mID);
            }            
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            mState = "EDIT";

            txtID.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
            txtDept.Properties.ReadOnly = true;
            txtDept.BackColor = System.Drawing.Color.White;
            dgvDetails.Enabled = false;
        }

        private void Find(string pDept,string pID) //查詢出所有數據
        {
            dgvDetails.Focus();
            dtDetails = clsProcessData.Find_Doc(pDept, pID);
            dgvDetails.DataSource = dtDetails;
        }

        private void Find_Doc(string pDept, string pID)
        {
            if (String.IsNullOrEmpty(pDept) || String.IsNullOrEmpty(pID))
            {
                return;
            }

            if (mState != "")
            {
                return;
            }

            dtDetails = clsProcessData.Find_Doc(pDept, pID);           
            dgvDetails.DataSource = dtDetails;
            if (dtDetails.Rows.Count == 0)
            {
                if (str_language == "2")
                {
                    msgCustom = "The Code of the data does not exist.";
                }
                else
                {
                    msgCustom = "編號資料不存在！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetObjValue.ClearObjValue(this.Controls, "2");
                return;
            }
            else
            {
                mID = txtID.Text;//保存臨時的ID號
                mDept = txtDept.EditValue.ToString();
            }
            Set_Master_Data(dtDetails);
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtDept.EditValue = dtName.Rows[0]["prd_dep"].ToString();
            txtID.Text = dtName.Rows[0]["id"].ToString();
            txtcdesc.Text = dtName.Rows[0]["cdesc"].ToString();
            txtRotate_speed.Text = dtName.Rows[0]["Rotate_speed"].ToString();

            makGrind_ratio.Text = dtName.Rows[0]["grind_ratio"].ToString();
            txtGrind_stone.Text = dtName.Rows[0]["grind_stone"].ToString();
            txtPolished_beads.Text = dtName.Rows[0]["Polished_beads"].ToString();
            txtGrind_time.Text = dtName.Rows[0]["grind_time"].ToString();

            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dtName.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dtName.Rows[0]["amtim"].ToString();

        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {                
                txtDept.EditValue = dgvDetails.CurrentRow.Cells["prd_dep"].Value.ToString();
                txtID.Text = dgvDetails.CurrentRow.Cells["id"].Value.ToString();                            
                txtcdesc.Text = dgvDetails.CurrentRow.Cells["cdesc"].Value.ToString();
                txtRotate_speed.Text = dgvDetails.CurrentRow.Cells["rotate_speed"].Value.ToString();
                makGrind_ratio.Text = dgvDetails.CurrentRow.Cells["grind_ratio"].Value.ToString();
                txtGrind_stone.Text = dgvDetails.CurrentRow.Cells["grind_stone"].Value.ToString();
                txtPolished_beads.Text = dgvDetails.CurrentRow.Cells["polished_beads"].Value.ToString();
                txtGrind_time.Text = dgvDetails.CurrentRow.Cells["grind_time"].Value.ToString();
                txtCrusr.Text = dgvDetails.CurrentRow.Cells["crusr"].Value.ToString();
                txtCrtim.Text = dgvDetails.CurrentRow.Cells["crtim"].Value.ToString();
                txtAmusr.Text = dgvDetails.CurrentRow.Cells["amusr"].Value.ToString();
                txtAmtim.Text = dgvDetails.CurrentRow.Cells["amtim"].Value.ToString();
            }
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            if (txtID.Text == "" || txtDept.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Code or Description Data cannot be empty.";
                }
                else
                {
                    msgCustom = "部門編號或工序編號！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Save()  //保存新增或修改的資料
        {
            if (!Save_Before_Valid())
            {
                return;
            }

            int iSpeed = 0;
            if (!string.IsNullOrEmpty(txtRotate_speed.Text))
                iSpeed = Convert.ToInt32(txtRotate_speed.Text);
            else
                iSpeed = 0;
            int iGrind_time = 0;
            if (!string.IsNullOrEmpty(txtGrind_time.Text))
                iGrind_time = Convert.ToInt32(txtGrind_time.Text);
            else
                iGrind_time = 0;

            bool save_flag = false;
            if (mState == "NEW")
            {
                if (Valid_Doc())
                    return;

                const string sql_new =
                    @"INSERT INTO bs_process(prd_dep,id,cdesc,machine,rotate_speed,grind_ratio,grind_stone,polished_beads,grind_time,crusr,crtim)
                    VALUES(@prd_dep,@id,@cdesc,@machine,@rotate_speed,@grind_ratio,@grind_stone,@polished_beads,@grind_time,@crusr,GETDATE())";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtDept.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());                       
                        myCommand.Parameters.AddWithValue("@cdesc", txtcdesc.Text.Trim());                        
                        myCommand.Parameters.AddWithValue("@machine", txtcdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@rotate_speed", iSpeed); 
                        myCommand.Parameters.AddWithValue("@grind_ratio", makGrind_ratio.Text);
                        myCommand.Parameters.AddWithValue("@grind_stone", txtGrind_stone.Text.Trim());
                        myCommand.Parameters.AddWithValue("@polished_beads", txtPolished_beads.Text);
                        myCommand.Parameters.AddWithValue("@grind_time", iGrind_time);                       
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

            if (mState == "EDIT")
            {
                const string sql_update =
                    @"Update bs_process set cdesc=@cdesc,machine=@machine,rotate_speed=@rotate_speed,grind_ratio=@grind_ratio,
                            grind_stone=@grind_stone,polished_beads=@polished_beads,grind_time=@grind_time,amusr=@amusr,amtim=GETDATE()
                      WHERE prd_dep=@prd_dep AND id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtDept.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cdesc", txtcdesc.Text.Trim());                       
                        myCommand.Parameters.AddWithValue("@machine", txtcdesc.Text.Trim());                        
                        myCommand.Parameters.AddWithValue("@rotate_speed", iSpeed);
                        myCommand.Parameters.AddWithValue("@grind_ratio", makGrind_ratio.Text);
                        myCommand.Parameters.AddWithValue("@grind_stone", txtGrind_stone.Text.Trim());
                        myCommand.Parameters.AddWithValue("@polished_beads", txtPolished_beads.Text);                        
                        myCommand.Parameters.AddWithValue("@grind_time", iGrind_time);                                              
                        myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);

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
            txtDept.Properties.ReadOnly = false;
            txtDept.Enabled = true;
            mState = "";
            dgvDetails.Enabled = true;

            Set_Row_Position(txtDept.EditValue.ToString() ,txtID.Text.Trim());
            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;
            string prd_dep = txtDept.EditValue.ToString();
            string id = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM dbo.bs_process WHERE prd_dep='{0}' and id='{1}'", prd_dep,id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + String.Format("部門：{0},工序號：{1}", prd_dep, id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }
        
        private void Set_Row_Position(string pDept,string pID) //定位到當前行 
        {
            dtDetails = clsProcessData.Find_Doc();
            dgvDetails.DataSource = dtDetails;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (pDept == dgvDetails.Rows[i].Cells["prd_dep"].Value.ToString() && pID == dgvDetails.Rows[i].Cells["id"].Value.ToString())
                {
                    dgvDetails.Rows[i].Selected = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["id"]; //設置光標定位到當前選中的行
                    break;
                }
            }
        }

        private void txtRotate_speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。          
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtRotate_speed.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtRotate_speed.Text, out oldf);
                    b2 = float.TryParse(txtRotate_speed.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txtGrind_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtGrind_time.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtGrind_time.Text, out oldf);
                    b2 = float.TryParse(txtGrind_time.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
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
                const string sql_del = "DELETE FROM dbo.bs_process WHERE prd_dep=@prd_dep AND id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtDept.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
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
     
     

    


    }
}
