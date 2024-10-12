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
    public partial class frmProcess_Goods : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mMat_item = "";
        public string mPrd_item = "";
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        DataTable dtDetail = new DataTable();
        DataTable dtProcess_list = new DataTable();
        
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示


        public frmProcess_Goods()
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


        private void frmProcess_Goods_Load(object sender, EventArgs e)
        {            
            DataTable dtDept = clsProcessData.Get_dept();
            txtID.Properties.DataSource = dtDept;
            txtID.Properties.ValueMember = "dep_id";
            txtID.Properties.DisplayMember = "dep_cdesc";
            
            DataTable dtProcess = clsProcessData.GetProcess_Group_ID();
            txtProcess_group_id.Properties.DataSource = dtProcess;
            txtProcess_group_id.Properties.ValueMember = "id";
            txtProcess_group_id.Properties.DisplayMember = "id";

            BTNSAVE.Enabled = false;
            BTNCANCEL.Enabled = false;

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
            string strDept = txtID.EditValue.ToString();
            string strMat_item = txtMat_item.Text;
            string strPrd_item = txtPrd_item.Text;
            string strSql = String.Format("Select '1' FROM dbo.bs_process_goods with(nolock) WHERE prd_dep='{0}' AND mat_item='{1}' AND prd_item='{2}'", strDept, strMat_item, strPrd_item);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + String.Format("【{0},{1},{2}】", strDept, strMat_item, strPrd_item), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (txtID.Text == "" || txtPrd_item.Text == "" || txtMat_item.Text == "" || txtProcess_group_id.EditValue.ToString()=="")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "部門,原料編號、下部門貨品編號、工序組別資料不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Find_doc(string pDept,string pMat_item,string pPrd_item) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(pDept) && !String.IsNullOrEmpty(pMat_item) && !String.IsNullOrEmpty(pPrd_item))
            {
                string strsql = String.Format(@"SELECT A.prd_dep,A.mat_item,A.prd_item,A.process_group_id,A.crusr,A.crtim,A.amusr,A.amtim, 
                                              (B.cdesc+' | '+ B.goods_size+' | '+B.process_color+' | '+B.artwork_shape) AS cdesc 
                                        FROM dbo.bs_process_goods A with(nolock) 
                                        LEFT JOIN bs_process_group_head B ON A.process_group_id=B.id
                                        WHERE A.prd_dep='{0}' AND A.mat_item='{1}' AND prd_item='{2}'", pDept, pMat_item, pPrd_item);
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
                    mMat_item = txtMat_item.Text;
                    mPrd_item = txtPrd_item.Text;
                }
                Set_Master_Data(dtDetail);
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.EditValue = dtName.Rows[0]["prd_dep"].ToString();
            txtMat_item.Text = dtName.Rows[0]["mat_item"].ToString();
            txtPrd_item.Text = dtName.Rows[0]["prd_item"].ToString();
            txtProcess_group_id.EditValue = dtName.Rows[0]["process_group_id"].ToString();
            txtProcess_group_id_desc.Text = dtName.Rows[0]["cdesc"].ToString();
            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dtName.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dtName.Rows[0]["amtim"].ToString();            
        }

        private void Set_Row_Position(string pDept,string pMat_item,string pPrd_item) //定位到當前行 
        {
            Find();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (pDept == dgvDetails.Rows[i].Cells["prd_dep"].Value.ToString() && 
                    pMat_item == dgvDetails.Rows[i].Cells["mat_item"].Value.ToString() &&
                    pPrd_item == dgvDetails.Rows[i].Cells["prd_item"].Value.ToString()
                    )
                {
                    dgvDetails.Rows[i].Selected = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["prd_dep"]; //設置光標定位到當前選中的行
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
            dtProcess_list.Clear();
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
            txtMat_item.Properties.ReadOnly = true;
            txtMat_item.BackColor = System.Drawing.Color.White;
            txtPrd_item.Properties.ReadOnly = true;
            txtPrd_item.BackColor = System.Drawing.Color.White;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            txtID.Properties.ReadOnly = false ;
            txtID.Enabled  = true;
            dgvDetails.Enabled = true;

            mState = "";
            if (!String.IsNullOrEmpty(mID) && !String.IsNullOrEmpty(mMat_item) && !String.IsNullOrEmpty(mPrd_item))
            {
                Find_doc(mID,mMat_item,mPrd_item);
            }
        }

        private void Save()  //保存新增或修改的資料
        {
            txtMat_item.Focus();
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
                        @"INSERT INTO bs_process_goods(prd_dep,mat_item,prd_item,process_group_id,crusr,crtim) 
                        Values(@prd_dep,@mat_item,@prd_item,@process_group_id,@crusr,getdate())";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@mat_item", txtMat_item.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prd_item", txtPrd_item.Text.Trim());
                        myCommand.Parameters.AddWithValue("@process_group_id", txtProcess_group_id.EditValue);  
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
                const string sql_update = @"UPDATE bs_process_goods 
                                            SET process_group_id=@process_group_id,amusr=@amusr,amtim=getdate() 
                                            WHERE prd_dep=@prd_dep AND mat_item=@mat_item AND prd_item=@prd_item";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@mat_item", txtMat_item.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prd_item", txtPrd_item.Text);
                        myCommand.Parameters.AddWithValue("@process_group_id", txtProcess_group_id.EditValue);  
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
            
            Set_Row_Position(txtID.EditValue.ToString(),txtMat_item.Text,txtPrd_item.Text);
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
                const string sql_del = "DELETE FROM bs_process_goods WHERE prd_dep=@prd_dep AND mat_item=@mat_item AND prd_item=@prd_item"; ;
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@mat_item", txtMat_item.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prd_item", txtPrd_item.Text);
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
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT A.prd_dep,A.mat_item,A.prd_item,A.process_group_id,A.crusr,A.crtim,A.amusr,A.amtim, 
                                    (B.cdesc+' | '+ B.goods_size+' | '+B.process_color+' | '+B.artwork_shape) AS cdesc 
                        FROM dbo.bs_process_goods A with(nolock) 
                             LEFT JOIN bs_process_group_head B ON A.process_group_id=B.id
                        Where 1>0
                    ");
            if (!string.IsNullOrEmpty(txtGoods_find.Text))
            {
                sb.Append(String.Format(" AND A.mat_item Like '%{0}%'", txtGoods_find.Text));
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sb.ToString());
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

        private void Find_Data()
        {
            string strID = txtID.EditValue.ToString();
            string strMat_item = txtMat_item.Text;
            string strPrd_item = txtPrd_item.Text;
            if (!String.IsNullOrEmpty(strID) &&
                !String.IsNullOrEmpty(strMat_item) &&
                !String.IsNullOrEmpty(strPrd_item))
            {
                if (mState == "")
                {
                    Find_doc(strID, strMat_item, strPrd_item);
                }
                //else
                //{
                //    txtMat_item.Text = txtID.GetColumnValue("cdesc").ToString();
                //}
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtID.EditValue = dgvDetails.CurrentRow.Cells["prd_dep"].Value.ToString();
                txtMat_item.Text = dgvDetails.CurrentRow.Cells["mat_item"].Value.ToString();
                txtPrd_item.EditValue = dgvDetails.CurrentRow.Cells["prd_item"].Value.ToString();
                txtProcess_group_id.EditValue = dgvDetails.CurrentRow.Cells["process_group_id"].Value.ToString();                
                dtProcess_list = clsProcessData.Get_Process_Details(txtID.EditValue.ToString(), txtProcess_group_id.EditValue.ToString());
                dgvProcess_list.DataSource = dtProcess_list;
                txtProcess_group_id_desc.Text = dgvDetails.CurrentRow.Cells["cdesc"].Value.ToString();   
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

        private void txtProcess_group_id_Leave(object sender, EventArgs e)
        {
            txtProcess_group_id_desc.Text = txtProcess_group_id.GetColumnValue("cdesc").ToString();
        }

        private void txtProcess_group_id_Click(object sender, EventArgs e)
        {
            txtProcess_group_id.SelectAll();
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            txtID.SelectAll();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            Find_Data();
        }

        private void txtMat_item_Leave(object sender, EventArgs e)
        {            
            Check_Item(txtMat_item.Text,"1");
        }

        private void txtPrd_item_Leave(object sender, EventArgs e)
        {
            Check_Item(txtPrd_item.Text,"2");
        }

        private void Check_Item(string pItem,string pSelect)
        {
            if (!string.IsNullOrEmpty(pItem))
            {
                if (mState == "NEW")
                {
                    if (!clsProcessData.IsExists_Item(pItem))
                    {
                        MessageBox.Show("貨品編號不存在!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (pSelect == "1")
                        {
                            txtMat_item.SelectAll();
                            txtMat_item.Focus();
                        }
                        else
                        {
                            txtPrd_item.SelectAll();
                            txtPrd_item.Focus();
                        }

                        return;
                    }
                }
                Find_Data();
            }
        }
      

     

     


    }
}
