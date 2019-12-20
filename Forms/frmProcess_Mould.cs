using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;


namespace cf01.Forms
{
    public partial class frmProcess_Mould : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mDept = "";
        public static string ID_Search = "";
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;

        public string goodsid = "";
        public string prddep = "";
      
        public bool save_flag;
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public string test_public_path = "";

        DataTable dtProcess_mostly = new DataTable();       
        DataTable dtFind= new DataTable();


        public frmProcess_Mould()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
            str_language = DBUtility._language;            
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
        }

        private void frmProcess_Mould_Load(object sender, EventArgs e)
        {            
            //分類
            DataTable dtDept = clsProcessData.Get_dept();
            txtDept_id.Properties.DataSource = dtDept;
            txtDept_id.Properties.ValueMember = "dep_id";
            txtDept_id.Properties.DisplayMember = "dep_cdesc";
            
            txtdep.Text = "322";
                                  
            //生成gridview1明細表結構
            dtProcess_mostly = clsPublicOfCF01.GetDataTable("Select * From dbo.bs_process_mould Where 1=0");
            gridControl1.DataSource = dtProcess_mostly;
            //臨時項目刪除表結構
            //dtTempDel = dtProcess_details.Clone();

            if (prddep != "" && goodsid != "")
            {
                Find_doc(prddep, goodsid);
                if (gridView1.RowCount == 0)
                {
                    AddNew();
                }
            }

            Set_Grid_Status(false);
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();//刪除主檔資料
        }

        private void BTNITEMADD_Click(object sender, EventArgs e)
        {            
            //AddNew_Item();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtRemark_mould.Focus();//Toolscript焦點問題
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string strsql = 
            @"Select A.dept_id,A.goods_id,B.name as goods_name 
            FROM dbo.bs_process_mould A with(nolock),
            dgerp2.cferp.dbo.it_goods B with(nolock)
            WHERE B.within_code='0000' and B.id=A.goods_id COLLATE Chinese_PRC_CI_AS ";

            if (txtdep.Text != "")
                strsql += string.Format(" AND dept_id='{0}'", txtdep.Text);
            if (txtProcess_id1.Text != "")
                strsql += string.Format(" AND goods_id='{0}'", txtProcess_id1.Text);
            if(txtProcess_id2.Text !="")
                strsql += string.Format(" AND goods_id='{0}'", txtProcess_id2.Text);

            dtFind = clsPublicOfCF01.GetDataTable(strsql);
            dgvFind.DataSource = dtFind;
            dgvFind.Columns[0].HeaderText = "部門";
            dgvFind.Columns[0].Width =70;
            dgvFind.Columns[1].HeaderText = "貨品編碼";
            dgvFind.Columns[1].Width = 200;
            dgvFind.Columns[2].HeaderText = "貨品名稱";
            dgvFind.Columns[2].Width = 280;
            if(dtFind.Rows.Count==0)
            {
                MessageBox.Show("找不到符合條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtDept_id.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");

            txtDept_id.Enabled = true;
            txtGoods_id.Enabled = true;
            txtDept_id.Properties.ReadOnly = false;
            txtGoods_id.Properties.ReadOnly = false;

            if (goodsid != "")
            {
                txtGoods_id.Text = goodsid;
            }

            txtDept_id.EditValue = "322";
            DataRow dr = dtProcess_mostly.NewRow(); //插一空行
            dtProcess_mostly.Rows.InsertAt(dr, 0);

            dtProcess_mostly.Clear();
            gridControl1.DataSource = dtProcess_mostly;
            groupBox1.Visible = false;
        }

        private void Edit()  //編輯
        {
            if (txtDept_id.Text == "" && txtGoods_id.Text=="")
            {
                return;
            }
            
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            //Set_Grid_Status(true);
            mState = "EDIT";

            txtGoods_id.Properties.ReadOnly = true;
            txtGoods_id.Enabled = false;
            txtGoods_id.BackColor = System.Drawing.Color.White;            
           
            txtDept_id.Properties.ReadOnly = true;
            txtDept_id.Enabled = false;
            txtDept_id.BackColor = System.Drawing.Color.White;

            groupBox1.Visible = false;
                      
        }

        private void SetButtonSatus(bool _flag) //設置工具欄
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;         
            BTNDELETE.Enabled = _flag;           
            BTNFIND.Enabled = _flag;           
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            //BTNITEMADD.Enabled = !_flag;
            //BTNITEMDEL.Enabled = !_flag;
            
        }

        private void Set_Grid_Status(bool _flag) // 表格可編號否
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag;
            //gridView2.OptionsBehavior.Editable = _flag;                       
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtGoods_id.Text) && String.IsNullOrEmpty(txtDept_id.Text))
            {
                return;
            }                   

            DialogResult result = MessageBox.Show("註意：此操作將刪除當前資料,請謹慎操作!,是否真的要刪除?", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = @"DELETE FROM dbo.bs_process_mould WHERE dept_id=@dept_id AND goods_id=@goods_id";                
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@dept_id", txtDept_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.EditValue.ToString());                        
                        myCommand.ExecuteNonQuery();                        
                        
                        myTrans.Commit(); //數據提交                        
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(this.Controls, "1");
                        //dtProcess_details.Clear();                        
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
        
        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            SetObjValue.ClearObjValue(this.Controls, "2");
            Set_Grid_Status(false);
            txtGoods_id.Enabled = true ;

            dtProcess_mostly.Clear();
            gridControl1.DataSource = dtProcess_mostly;
            groupBox1.Visible = true;

            mState = "";
            if (!String.IsNullOrEmpty(mDept) && !String.IsNullOrEmpty(mID))
            {
                Find_doc(mDept,mID);
            }
        }

        private void Find_doc(string pDept,string pID) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(pDept) && !String.IsNullOrEmpty(pID))
            {
                string strsql = String.Format(
                        @"SELECT * FROM dbo.bs_process_mould with(nolock) WHERE dept_id='{0}' AND goods_id='{1}'", pDept, pID);
                dtProcess_mostly = clsPublicOfCF01.GetDataTable(strsql);
                if (dtProcess_mostly.Rows.Count > 0)
                {
                    txtDept_id.EditValue = dtProcess_mostly.Rows[0]["dept_id"].ToString();
                    txtGoods_id.Text = dtProcess_mostly.Rows[0]["goods_id"].ToString();
                    Set_Master_Data(dtProcess_mostly);
                }
                gridControl1.DataSource = dtProcess_mostly;
                mDept = txtDept_id.EditValue.ToString();
                mID = txtGoods_id.Text;//保存臨時的ID號 
            }
        }

        private void Save()  //保存
        {
            if (!Save_Before_Valid())
            {
                return;
            }  

            save_flag = false;

            #region  保存新增
            if (mState == "NEW")
            {
                if (Valid_Doc())
                {
                    return;
                }
                const string sql_i = 
                @"INSERT bs_process_mould(dept_id,goods_id,time_loop,time_spray,counts1,time_die_thimble,counts2,time_mould_begin,time_mould_work,test_mould_by,remark_mould,crusr,crtim)
                     VALUES(@dept_id,@goods_id,@time_loop,@time_spray,@counts1,@time_die_thimble,@counts2,@time_mould_begin,@time_mould_work,@test_mould_by,@remark_mould,@crusr,getdate())";                   
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {                        
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@dept_id", txtDept_id.EditValue);
                        myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.EditValue);
                        myCommand.Parameters.AddWithValue("@time_loop", txtTime_loop.Text.Trim());
                        myCommand.Parameters.AddWithValue("@time_spray", txtTime_spray.Text.Trim());
                        myCommand.Parameters.AddWithValue("@counts1", txtCounts1.Text);
                        myCommand.Parameters.AddWithValue("@time_die_thimble", txtTime_die_thimble.Text);
                        myCommand.Parameters.AddWithValue("@counts2", txtCounts2.Text);
                        myCommand.Parameters.AddWithValue("@time_mould_begin", txtTime_mould_begin.Text);
                        myCommand.Parameters.AddWithValue("@time_mould_work", txtTime_mould_work.Text);
                        myCommand.Parameters.AddWithValue("@test_mould_by", txtTest_mould_by.Text);
                        myCommand.Parameters.AddWithValue("@remark_mould", txtRemark_mould.Text);
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
            #endregion

            #region 保存編輯
            if (mState == "EDIT")
            {                                
                const string sql_update =
                    @"UPDATE bs_process_mould
                      SET time_loop=@time_loop,time_spray=@time_spray,counts1=@counts1,time_die_thimble=@time_die_thimble,
                          counts2=@counts2,time_mould_begin=@time_mould_begin,time_mould_work=@time_mould_work,test_mould_by=@test_mould_by,
                          remark_mould=@remark_mould,amusr=@amusr,amtim=getdate()
                      WHERE dept_id=@dept_id AND goods_id=@goods_id";
                               
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@dept_id", txtDept_id.EditValue);
                        myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.EditValue);
                        myCommand.Parameters.AddWithValue("@time_loop", txtTime_loop.Text.Trim());
                        myCommand.Parameters.AddWithValue("@time_spray", txtTime_spray.Text.Trim());
                        myCommand.Parameters.AddWithValue("@counts1", txtCounts1.Text);
                        myCommand.Parameters.AddWithValue("@time_die_thimble", txtTime_die_thimble.Text);
                        myCommand.Parameters.AddWithValue("@counts2", txtCounts2.Text);
                        myCommand.Parameters.AddWithValue("@time_mould_begin", txtTime_mould_begin.Text);
                        myCommand.Parameters.AddWithValue("@time_mould_work", txtTime_mould_work.Text);
                        myCommand.Parameters.AddWithValue("@test_mould_by", txtTest_mould_by.Text);
                        myCommand.Parameters.AddWithValue("@remark_mould", txtRemark_mould.Text);                                           
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
            #endregion
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            Set_Grid_Status(false);
            mState = "";
            //txtGoods_id.Enabled = false;  
            txtGoods_id.Enabled = true;  
            groupBox1.Visible = true ;                       

            if (save_flag)
            {
                Find_doc(txtDept_id.EditValue.ToString(),txtGoods_id.EditValue.ToString());
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (txtDept_id.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "部門及貨品編號不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;           
            string strSql = String.Format("Select '1' FROM dbo.bs_process_mould WHERE dept_id='{0}' and goods_id='{1}'", txtDept_id.EditValue,txtGoods_id.EditValue);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("註意：該部門及貨品編號已存在" + String.Format("【{0}】【{1}】!", txtDept_id.EditValue, txtGoods_id.EditValue), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
            
        }
              

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void Set_Master_Data(DataTable dt) //綁定主檔資料
        {
            txtDept_id.EditValue = dt.Rows[0]["dept_id"].ToString();
            txtGoods_id.EditValue = dt.Rows[0]["goods_id"].ToString();
            txtTime_loop.Text = dt.Rows[0]["time_loop"].ToString();
            txtTime_spray.Text = dt.Rows[0]["time_spray"].ToString();
            txtCounts1.Text = dt.Rows[0]["counts1"].ToString();
            txtTime_die_thimble.Text = dt.Rows[0]["time_die_thimble"].ToString();
            txtCounts2.Text = dt.Rows[0]["counts2"].ToString();
            txtTime_mould_begin.Text = dt.Rows[0]["time_mould_begin"].ToString();
            txtTime_mould_work.Text = dt.Rows[0]["time_mould_work"].ToString();
            txtTest_mould_by.Text = dt.Rows[0]["test_mould_by"].ToString();
            txtRemark_mould.Text=dt.Rows[0]["remark_mould"].ToString();
            txtCrusr.Text = dt.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dt.Rows[0]["amtim"].ToString();
        }
      

        private void txtPrd_dep_Leave(object sender, EventArgs e)
        {            
            Find_doc();     
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (mState == "NEW")
            {
                string strgoods_id = txtGoods_id.Text;
                if (strgoods_id == "" && txtDept_id.Text == "")
                {
                    return;
                }
                string sql = string.Format("SELECT '1' From dbo.bs_process_mould with(nolock) Where dept_id='{0}' and goods_id='{1}'", txtDept_id.EditValue, strgoods_id);
                strgoods_id = clsPublicOfCF01.ExecuteSqlReturnObject(sql);
                if (strgoods_id != "")
                {
                    MessageBox.Show("此貨品編碼已存在!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtGoods_id.Focus();
                    return;
                }
            }
            Find_doc();
        }

        private void Find_doc()
        {
            string strGoods_id = "";
            if (txtGoods_id.Text == "")
            {
                strGoods_id = "";
            }
            else
            {
                strGoods_id = txtGoods_id.Text.ToUpper();
            }

            if (!String.IsNullOrEmpty(strGoods_id) && !String.IsNullOrEmpty(txtDept_id.Text))
            {
                if (mState == "")
                {
                    Find_doc(txtDept_id.EditValue.ToString(), txtGoods_id.Text);
                }
            }
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.Rows.Count > 0)
            {                
                Find_doc(dgvFind.CurrentRow.Cells["dept_id"].Value.ToString(), dgvFind.CurrentRow.Cells["goods_id"].Value.ToString());
            }
        }

        private void txtProcess_id1_Leave(object sender, EventArgs e)
        {
            txtProcess_id2.Text = txtProcess_id1.Text;
        }

        private void txtPrd_dep_Click(object sender, EventArgs e)
        {
            txtDept_id.SelectAll();
        }

    }
}
