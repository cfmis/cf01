using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using cf01.CLS;


namespace cf01.Forms
{
    public partial class frmSize : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom ;
        public int row_delete;
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示

        public frmSize()
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

            dgvSize.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            dgvSize.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
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

        private void BTNDELETE_Click(object sender, EventArgs e)
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
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
        }    

        private bool Valid_Doc()
        {
            bool flag;
            string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM bs_size WHERE size_id='{0}'", doc);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + String.Format("【{0}】", doc), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        private void Find_doc(string temp_id)
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strsql = String.Format("SELECT size_id AS id,size_cdesc AS cdesc,size_desc AS edesc,size_rmk as rmk,crusr,crtim,amusr,amtim FROM dbo.bs_size WHERE size_id='{0}'", temp_id);
                DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                dgvSize.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    if (str_language == "2")
                    {
                        msgCustom = "The NO. of the data does not exist.";
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
                }
                Set_Master_Data(dt);
            }
        }

        private bool Save_Before_Valid()
        {
            if (txtID.Text == "" || txtSize_cdesc.Text == "" || txtSize_desc.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "編號或描述資料不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.Text = dtName.Rows[0]["id"].ToString();
            txtSize_desc.Text = dtName.Rows[0]["edesc"].ToString();
            txtSize_cdesc.Text = dtName.Rows[0]["cdesc"].ToString();
            txtSize_rmk.Text = dtName.Rows[0]["rmk"].ToString();
            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dtName.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dtName.Rows[0]["amtim"].ToString();
        }

        private void Set_Row_Position(string _doc)
        {
            //定位到當前行           
            Find();
            for (int i = 0; i < dgvSize.RowCount; i++)
            {
                if (_doc == dgvSize.Rows[i].Cells["id"].Value.ToString())
                {                    
                    dgvSize.CurrentCell = dgvSize.Rows[i].Cells["id"]; //設置光標定位到當前選中的行
                    dgvSize.Rows[i].Selected = true;
                    break;
                }
            }
        }
    
        private void AddNew()
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void Edit()
        {
            if (dgvSize.RowCount == 0)
            {
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls,true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
        }

        private void Save()
        {
            if (!Save_Before_Valid())
            {
                return;
            }

            bool save_flag = false;

            if (mState == "NEW")
            {
                if (Valid_Doc())
                    return;

                const string sql_new = "INSERT INTO bs_size(size_id,size_desc,size_cdesc,size_rmk,crusr,crtim) values(@size_id,@size_desc,@size_cdesc,@size_rmk,@crusr,getdate())";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@size_id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size_desc", txtSize_desc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size_cdesc", txtSize_cdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size_rmk", txtSize_rmk.Text.Trim());
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
                const string sql_update = "UPDATE bs_size SET size_desc=@size_desc,size_cdesc=@size_cdesc,size_rmk=@size_rmk,amusr=@amusr,amtim=getdate() WHERE size_id=@size_id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@size_id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size_desc", txtSize_desc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size_cdesc", txtSize_cdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size_rmk", txtSize_rmk.Text.Trim());
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
            SetObjValue.SetEditBackColor(this.Controls,false);
            mState = "";

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

        private void Cancel()
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls,false);
            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID);
            }
        }

        private void Delete()
        {
            if (dgvSize.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }

            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM bs_size WHERE size_id=@size_id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@size_id", txtID.Text.Trim());
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvSize.Rows.Remove(dgvSize.CurrentRow);//移走當前行
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

        private void Find()
        {
            dgvSize.Focus();
            DataTable dt = clsPublicOfCF01.GetDataTable("SELECT size_id as id,size_cdesc AS cdesc,size_desc AS edesc,size_rmk as rmk,crusr,crtim,amusr,amtim FROM dbo.bs_size");
            dgvSize.DataSource = dt;
        }

        private void Print()
        {
            if (dgvSize.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvSize);
            }
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvSize.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(dgvSize);
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
            }
        }

        private void dgvSize_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSize.RowCount > 0)
            {                
                txtID.Text = dgvSize.CurrentRow.Cells["id"].Value.ToString();
                txtSize_cdesc.Text = dgvSize.CurrentRow.Cells["cdesc"].Value.ToString();
                txtSize_desc.Text = dgvSize.CurrentRow.Cells["edesc"].Value.ToString();
                txtSize_rmk.Text = dgvSize.CurrentRow.Cells["rmk"].Value.ToString();
                txtCrusr.Text = dgvSize.CurrentRow.Cells["crusr"].Value.ToString();
                txtCrtim.Text = dgvSize.CurrentRow.Cells["crtim"].Value.ToString();
                txtAmusr.Text = dgvSize.CurrentRow.Cells["amusr"].Value.ToString();
                txtAmtim.Text = dgvSize.CurrentRow.Cells["amtim"].Value.ToString();
            }
        }      

        private void dgvSize_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvSize.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvSize.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvSize.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

    }   
    
}
