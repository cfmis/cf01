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
    public partial class frmProcess_Type_Prod : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        private DataTable dtDetail = new DataTable();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示

        public frmProcess_Type_Prod()
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

        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProcess_Type_Prod_Load(object sender, EventArgs e)
        {
            string strSql = @"SELECT id,name as cdesc FROM dbo.cd_goods_class With(nolock) WHERE state<>'2'";
            DataTable dtProd_type = clsConErp.GetDataTable(strSql);
            txtID.Properties.DataSource = dtProd_type;
            txtID.Properties.ValueMember = "id";
            txtID.Properties.DisplayMember = "id";  

            DataTable dtPss_type = clsPublicOfCF01.GetDataTable("SELECT id FROM bs_process_group_type ORDER BY seq_id");
            txtPrss_type.Properties.DataSource = dtPss_type;
            txtPrss_type.Properties.ValueMember = "id";
            txtPrss_type.Properties.DisplayMember = "id";  
            
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
            string doc = txtID.EditValue.ToString();
            string strSql = String.Format("Select '1' FROM dbo.bs_process_type_prod with(nolock) WHERE prd_type='{0}'", doc);
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
            if (txtID.Text == "" || txtCdesc.Text == "" || txtPrss_type.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "編號,描述,工序類型資料不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Find_doc(string pID) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(pID))
            {
                string strsql = String.Format("SELECT prd_type,prd_desc,prss_type,crusr,crtim,amusr,amtim FROM dbo.bs_process_type_prod WHERE prd_type='{0}'", pID);
                dtDetail = clsPublicOfCF01.GetDataTable(strsql);
                dgvDetails.DataSource = dtDetail;
                if (dtDetail.Rows.Count == 0)
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
                    mID = txtID.EditValue.ToString();//保存臨時的ID號
                }
                Set_Master_Data(dtDetail);
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.EditValue = dtName.Rows[0]["prd_type"].ToString();            
            txtCdesc.Text = dtName.Rows[0]["prd_desc"].ToString();
            txtPrss_type.EditValue = dtName.Rows[0]["Prd_type"].ToString();
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
                if (_doc == dgvDetails.Rows[i].Cells["prd_type"].Value.ToString())
                {
                    dgvDetails.Rows[i].Selected = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["prd_type"]; //設置光標定位到當前選中的行
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
            txtID.Properties.ReadOnly = false ;
            dgvDetails.Enabled = false;
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            dgvDetails.Enabled = false ;
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            txtID.Properties.ReadOnly = false ;
            txtID.Enabled  = true;
            dgvDetails.Enabled = true;

            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID);
            }
        }

        private void Save()  //保存新增或修改的資料
        {
            txtCdesc.Focus();
            if (!Save_Before_Valid())
            {
                return;
            }

            bool save_flag = false;

            if (mState == "NEW")
            {
                if (Valid_Doc())
                    return;

                const string sql_new = "INSERT INTO bs_process_type_prod(prd_type,prd_desc,prss_type,crusr,crtim) values(@prd_type,@prd_desc,@prss_type,@crusr,getdate())";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_type", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@prd_desc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prss_type", txtPrss_type.EditValue);                        
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
                const string sql_update = @"UPDATE bs_process_type_prod SET prd_desc=@prd_desc,prss_type=@prss_type,amusr=@amusr,amtim=getdate() 
                                            WHERE prd_type=@prd_type";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_type", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@prd_desc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prss_type", txtPrss_type.EditValue);
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
            txtID.Properties.ReadOnly = false;
            txtID.Enabled = true ;

            dgvDetails.Enabled = true;
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
                const string sql_del = "DELETE FROM bs_process_type_prod WHERE prd_type=@prd_type";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_type", txtID.EditValue);
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
            dgvDetails.Focus();
            dtDetail = clsPublicOfCF01.GetDataTable("SELECT prd_type,prd_desc,prss_type,crusr,crtim,amusr,amtim FROM dbo.bs_process_type_prod");
            dgvDetails.DataSource = dtDetail;
        }

        private void Print() //通用的打印方法
        {
            if (dgvDetails.RowCount > 0)
            {                
                clsGeneralDataConvert.GridView_To_Print(dgvDetails);
            }
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                clsGeneralDataConvert.GridView_To_Excel(dgvDetails);
            }
        }


        //===========以下爲控件中的方法================
        private void txtID_Leave(object sender, EventArgs e)
        {
            string strID =txtID.EditValue.ToString();
            if (!String.IsNullOrEmpty(strID))
            {
                if (mState == "")
                {
                    Find_doc(strID);
                }
                else
                {
                    txtCdesc.Text = txtID.GetColumnValue("cdesc").ToString();
                }
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtID.EditValue = dgvDetails.CurrentRow.Cells["prd_type"].Value.ToString();
                txtCdesc.Text = dgvDetails.CurrentRow.Cells["prd_desc"].Value.ToString();
                txtPrss_type.EditValue = dgvDetails.CurrentRow.Cells["prss_type"].Value.ToString();               
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
            


    }
}
