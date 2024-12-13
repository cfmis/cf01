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
    public partial class frmSetPlateRemark : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string strLanguage = "0";
        public string msgCustom ;
        public int row_delete;
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示

        public frmSetPlateRemark()
        {
            InitializeComponent();
            strLanguage = DBUtility._language;
            try
            {
                clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                control.GenerateContorl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvPlateRemak.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            dgvPlateRemak.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
        }

        private void frmSetPlateRemark_Load(object sender, EventArgs e)
        {
            FindAllData();
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
            txtPlate_remark.Focus();
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
            FindAllData();
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

        private bool ValidDoc()
        {
            //檢查編號是否已存在
            bool flag;
            string id = txtID.Text.Trim();
            string strSql = string.Format("Select '1' FROM {0}it_goods_plate_remark WHERE within_code='{1}' And id='{2}'", DBUtility.remote_db, "0000", id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + string.Format("【{0}】", id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        private void FindDoc(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string strsql = string.Format(
                @"SELECT a.id,b.name as goods_name,a.mo_group,a.plate_remark,a.create_by,a.create_date,a.update_by,a.update_date 
                FROM {0}it_goods_plate_remark a,{0}it_goods b 
                WHERE a.within_code=b.within_code And a.id=b.id And a.within_code='{1}' And a.id='{2}'",DBUtility.remote_db, "0000", id);
                DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                dgvPlateRemak.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    msgCustom = (strLanguage == "2") ? "The NO. of the data does not exist." : "輸入的貨品編號資料并不存在！";                    
                    MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                }
                SetMasterData(dt);
            }
        }

        private void CheckItem(string id)
        {
            //校驗輸入的貨品編號是否正確
            if (string.IsNullOrEmpty(id))
            {
                return ;
            }            
            string strsql = string.Format(
            @"SELECT id,name FROM {0}it_goods WHERE within_code='{1}' And id='{2}'", DBUtility.remote_db,"0000", id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            if (dt.Rows.Count == 0)
            {
                msgCustom = (strLanguage == "2") ? "The NO. of the data does not exist." : "輸入的貨品編碼資料并不存在！";
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = "";
                txtMo_group.Text = "";
                txtPlate_remark.Text = "";
                txtGoods_name.Text = "";
                txtCreate_by.Text = "";
                txtCreate_date.Text = "";
                txtUpdate_by.Text = "";
                txtUpdate_date.Text = "";
                //SetObjValue.ClearObjValue(this.Controls, "2");               
            }
            else
            {
                txtGoods_name.Text = dt.Rows[0]["name"].ToString();
                mID = txtID.Text;//保存臨時的ID號               
            }
        }

        private bool SaveBeforeValid()
        {
            if (txtID.Text == "" || txtPlate_remark.Text == "")
            {
                msgCustom = (strLanguage == "2") ? "Item No. or remark data cannot be empty." : "編號或電鍍備註資料不可爲空！";               
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetMasterData(DataTable dtName)
        {
            txtID.Text = dtName.Rows[0]["id"].ToString();           
            txtGoods_name.Text = dtName.Rows[0]["goods_name"].ToString();
            txtMo_group.Text = dtName.Rows[0]["mo_group"].ToString();
            txtPlate_remark.Text = dtName.Rows[0]["plate_remark"].ToString();
            txtCreate_by.Text = dtName.Rows[0]["create_by"].ToString();
            txtCreate_date.Text = dtName.Rows[0]["create_date"].ToString();
            txtUpdate_by.Text = dtName.Rows[0]["update_by"].ToString();
            txtUpdate_date.Text = dtName.Rows[0]["update_date"].ToString();
        }

        private void SetRowPosition(string id)
        {
            //定位到當前行           
            FindAllData();
            for (int i = 0; i < dgvPlateRemak.RowCount; i++)
            {
                if (id == dgvPlateRemak.Rows[i].Cells["id"].Value.ToString())
                {                    
                    dgvPlateRemak.CurrentCell = dgvPlateRemak.Rows[i].Cells["id"]; //設置光標定位到當前選中的行
                    dgvPlateRemak.Rows[i].Selected = true;
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
            if (dgvPlateRemak.RowCount == 0)
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
            if (!SaveBeforeValid())
            {
                return;
            }
            bool save_flag = false;
            if (mState == "NEW")
            {
                if (ValidDoc())
                {
                    return;
                }
                string sql_new = "Insert Into it_goods_plate_remark(within_code,id,mo_group,plate_remark,create_by,create_date) Values(@within_code,@id,@mo_group,@plate_remark,@user_id,getdate())";
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", "0000");
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());                        
                        myCommand.Parameters.AddWithValue("@mo_group", txtMo_group.Text);
                        myCommand.Parameters.AddWithValue("@plate_remark", txtPlate_remark.Text.Trim());
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
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
                string sql_update =
                @"Update it_goods_plate_remark Set plate_remark=@plate_remark,mo_group=@mo_group,update_by=@user_id,update_date=getdate() 
                Where within_code=@within_code And id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", "0000");
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());                        
                        myCommand.Parameters.AddWithValue("@mo_group", txtMo_group.Text);
                        myCommand.Parameters.AddWithValue("@plate_remark", txtPlate_remark.Text.Trim());
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
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
            SetRowPosition(txtID.Text.Trim());
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
            if (!string.IsNullOrEmpty(mID))
            {
                FindDoc(mID);
            }
        }

        private void Delete()
        {
            if (dgvPlateRemak.RowCount == 0 && string.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sqlDel =string.Format(
                @"DELETE FROM it_goods_plate_remark WHERE within_code='{0}' and id='{1}'","0000", txtID.Text.Trim());
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sqlDel;
                        //myCommand.Parameters.Clear();
                        //myCommand.Parameters.AddWithValue("@size_id", txtID.Text.Trim());
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvPlateRemak.Rows.Remove(dgvPlateRemak.CurrentRow);//移走當前行
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

        private void FindAllData()
        {
            //Find All Data
            dgvPlateRemak.Focus();
            string sql = string.Format(
            @"SELECT a.id,b.name as goods_name,a.mo_group,a.plate_remark,a.create_by,a.create_date,a.update_by,a.update_date 
             FROM {0}it_goods_plate_remark a,{0}it_goods b WHERE a.within_code=b.within_code and a.id=b.id", DBUtility.remote_db);
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            dgvPlateRemak.DataSource = dt;            
        }

        private void Print()
        {
            if (dgvPlateRemak.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvPlateRemak);
            }
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvPlateRemak.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(dgvPlateRemak);
            }
        }


        //===========以下爲控件中的方法================   

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (mState == "")
                {
                    //FindDoc(txtID.Text);
                }
                else
                {
                    //編輯時
                    CheckItem(txtID.Text);                    
                }
            }
        }

        private void dgvSize_SelectionChanged(object sender, EventArgs e)
        {           
            if (dgvPlateRemak.CurrentRow == null )
            {
                return;
            }          
            txtID.Text = dgvPlateRemak.CurrentRow.Cells["id"].Value.ToString();
            txtGoods_name.Text = dgvPlateRemak.CurrentRow.Cells["goods_name"].Value.ToString();
            txtMo_group.Text = dgvPlateRemak.CurrentRow.Cells["mo_group"].Value.ToString();
            txtPlate_remark.Text = dgvPlateRemak.CurrentRow.Cells["plate_remark"].Value.ToString();
            txtCreate_by.Text = dgvPlateRemak.CurrentRow.Cells["create_by"].Value.ToString();
            txtCreate_date.Text = dgvPlateRemak.CurrentRow.Cells["create_date"].Value.ToString();
            txtUpdate_by.Text = dgvPlateRemak.CurrentRow.Cells["update_by"].Value.ToString();
            txtUpdate_date.Text = dgvPlateRemak.CurrentRow.Cells["update_date"].Value.ToString();
            
        }      

        private void dgvSize_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvPlateRemak.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvPlateRemak.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvPlateRemak.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

      
    }   
    
}
