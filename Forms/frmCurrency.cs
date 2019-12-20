using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmCurrency : Form

    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示     
        DataTable dtCountry = new DataTable();
        
        public frmCurrency()
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

        private void frmCurrency_Load(object sender, EventArgs e)
        {
            string sql_country;
            if (DBUtility._language == "2")
            {
                sql_country = @"SELECT id,edesc as [desc] FROM dbo.bs_country";
            }
            else
            {
                sql_country = @"SELECT id,cdesc as [desc] FROM dbo.bs_country";
            }
            //國家代碼  
            dtCountry = clsPublicOfCF01.GetDataTable(sql_country);
            DataRow row1 = dtCountry.NewRow();//插一空行
            dtCountry.Rows.Add(row1);
            dtCountry.DefaultView.Sort = "id ASC";//排序
            dtCountry = dtCountry.DefaultView.ToTable();//排序後重新賦值
            txtCountry_id.Properties.DataSource = dtCountry;
            txtCountry_id.Properties.ValueMember = "id";
            txtCountry_id.Properties.DisplayMember = "id";

        }

        private void frmCurrency_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtCountry.Dispose();
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

    

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;
            string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM bs_currency WHERE id='{0}'", doc);
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

        private bool Save_Before_Valid() //保存前檢查
        {
            if (txtID.Text == "" || txtCdesc.Text == "")
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

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strsql = String.Format("SELECT A.id,A.cdesc,A.edesc,A.currency_sign,A.country_id,B.cdesc as country_name,A.sunaccount_rate,A.bp_formula,A.remark as rmk,A.crusr,A.crtim,A.amusr,A.amtim FROM dbo.bs_currency A,bs_country B WHERE A.id='{0}' AND A.country_id=B.id", temp_id);
                DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                dgvDetails.DataSource = dt;
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
                    SetObjValue.ClearObjValue(this.Controls,"2");                       
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                }
                Set_Master_Data(dt);
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.Text = dtName.Rows[0]["id"].ToString();
            txtEdesc.Text = dtName.Rows[0]["edesc"].ToString();
            txtCdesc.Text = dtName.Rows[0]["cdesc"].ToString();
            txtCountry_id.EditValue = dtName.Rows[0]["country_id"].ToString();
            txtCountry_name.Text = dtName.Rows[0]["country_name"].ToString();
            txtBp_formula.Text = dtName.Rows[0]["bp_formula"].ToString();
            txtSunaccount_rate.Text = dtName.Rows[0]["sunaccount_rate"].ToString();            
            txtRemark.Text = dtName.Rows[0]["rmk"].ToString();
            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dtName.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dtName.Rows[0]["amtim"].ToString();
        }

        private void Set_Row_Position(string _doc) //定位到當前行 
        {
            Find();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (_doc == dgvDetails.Rows[i].Cells["id"].Value.ToString())
                {                    
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["id"]; //設置光標定位到當前選中的行
                    dgvDetails.Rows[i].Selected = true;
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
                if (Valid_Doc())
                    return;

                const string sql_new =
                    @"INSERT INTO bs_currency(id,cdesc,edesc,country_id,bp_formula,sunaccount_rate,remark,crusr,crtim) values" +
                    "(@id,@cdesc,@edesc,@country_id,@bp_formula,@sunaccount_rate,@remark,@crusr,getdate())";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text.Trim());                        
                        myCommand.Parameters.AddWithValue("@country_id", txtCountry_id.EditValue);
                        myCommand.Parameters.AddWithValue("@bp_formula", txtBp_formula.Text.Trim());
                        myCommand.Parameters.AddWithValue("@sunaccount_rate", txtSunaccount_rate.Text);
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());                       
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
                    @"UPDATE bs_currency SET edesc=@edesc,cdesc=@cdesc,country_id=@country_id,bp_formula=@bp_formula," +
                    "sunaccount_rate=@sunaccount_rate,remark=@remark,amusr=@amusr,amtim=getdate() WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@country_id", txtCountry_id.EditValue);
                        myCommand.Parameters.AddWithValue("@bp_formula", txtBp_formula.Text.Trim());
                        myCommand.Parameters.AddWithValue("@sunaccount_rate", txtSunaccount_rate.Text);                        
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());
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

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }

            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM bs_currency WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
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

        private void Find() //查詢出所有數據
        {            
            string strSql = @"SELECT A.id,A.cdesc,A.edesc,A.currency_sign,A.country_id,B.cdesc as country_name,A.sunaccount_rate,"+
                "A.bp_formula,A.remark as rmk,A.crusr,A.crtim,A.amusr,A.amtim FROM dbo.bs_currency A,bs_country B WHERE A.country_id*=B.id";            
            dgvDetails.Focus();
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dt;
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
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtID.Text = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
                txtCdesc.Text = dgvDetails.CurrentRow.Cells["cdesc"].Value.ToString();
                txtEdesc.Text = dgvDetails.CurrentRow.Cells["edesc"].Value.ToString();
                txtCountry_id.EditValue = dgvDetails.CurrentRow.Cells["Country_id"].Value.ToString();
                txtCountry_name.Text = dgvDetails.CurrentRow.Cells["country_name"].Value.ToString();
                txtBp_formula.Text = dgvDetails.CurrentRow.Cells["bp_formula"].Value.ToString();
                txtSunaccount_rate.Text = dgvDetails.CurrentRow.Cells["sunaccount_rate"].Value.ToString();
                txtRemark.Text = dgvDetails.CurrentRow.Cells["rmk"].Value.ToString();
                txtCrusr.Text = dgvDetails.CurrentRow.Cells["crusr"].Value.ToString();
                txtCrtim.Text = dgvDetails.CurrentRow.Cells["crtim"].Value.ToString();
                txtAmusr.Text = dgvDetails.CurrentRow.Cells["amusr"].Value.ToString();
                txtAmtim.Text = dgvDetails.CurrentRow.Cells["amtim"].Value.ToString();
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

        private void txtCountry_id_Leave(object sender, EventArgs e)
        {
            DataRow[] dr = dtCountry.Select(String.Format("id='{0}'", txtCountry_id.EditValue));
            if (dr.Length > 0)
            {
                txtCountry_name.Text = dr[0]["desc"].ToString().Trim();
            }
            dtCountry.Select();            
        }
          
     
    }
}
