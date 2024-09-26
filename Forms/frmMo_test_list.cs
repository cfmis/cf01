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


namespace cf01.Forms
{
    public partial class frmMo_test_list : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public string mID = "";    //臨時的主鍵值
        public string mVer = "";
        public static string ID_Search = "";       
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public string _max_ver = "";
       
        public string stControl = "BTNNEW,BTNEDIT,BTNDELETE,BTNITEMADD,BTNITEMDEL,BTNSAVE,BTNPRINT,BTNFIND,BTNNEWVER,BTNEXCEL";


        public bool save_flag;
        public string strArea = "";
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public string test_public_path = "";
        private clsAppPublic clsAppPublic = new clsAppPublic();
        DataTable dtTest_mostly = new DataTable();
        DataTable dtTest_details = new DataTable();
        DataTable dtTempDel = new DataTable();
        DataTable dtTestItem = new DataTable();
        DataTable dtType_condition = new DataTable();

        DataTable dtData_dropbox = new DataTable();
        DataTable dtData_mo = new DataTable();
        


        public frmMo_test_list()
        {
            InitializeComponent();            
            //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            //control.GenerateContorl();
            str_language = DBUtility._language;
            //NextControl oNext = new NextControl(this, "2");
            //oNext.EnterToTab();
            clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
        }

        private void frmTestStandard_Load(object sender, EventArgs e)
        {
            //分類            
            //生成gridview1明細表結構
            dtTest_details = clsPublicOfCF01.GetDataTable("Select * From dbo.bs_mo_test_list_details Where 1=0");
            gridControl1.DataSource = dtTest_details;
            //臨時項目刪除表結構
            dtTempDel = dtTest_details.Clone();

            //gridview1測試項目下拉列表框
            try
            {
                string strSql =
                    @"Select id,id+' ['+name+']' as cdesc 
                    From dbo.cd_department
                    WHERE ISNULL(dept_type,'') <>'M' AND ISNULL(wh_dept,'')<>'1' 
                        AND substring(id,1,1) not in ('Y','V','U','K','J','H','E','B','A') 
                        AND SUBSTRING(id,1,2) not in ('92','92','93','94','95','96','97','98','PL')
                        AND id not in ('888','902','P00','P11','822','401','911','100','200','300')
                    ORDER BY id";
                dtTestItem = clsConErp.GetDataTable(strSql);

                cldept.DataSource = dtTestItem;
                cldept.ValueMember = "id";
                cldept.DisplayMember = "cdesc";
                cldept.ShowHeader = false;
                cldept.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

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
            AddNew_Item();
        }

        private void BTNITEMDEL_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = gridView1.FocusedRowHandle;
                //將當前行刪除幷加到臨時表中
                DataRow newRow = dtTempDel.NewRow();
                newRow["mo_id"] = txtID.Text;
                newRow["ver"] = txtVer.Text;
                newRow["seq_id"] = gridView1.GetRowCellDisplayText(curRow, "seq_id");
                //newRow["dept_test"] = gridView1.GetRowCellDisplayText(curRow, "dept_test");                
                newRow["dept_test"] = gridView1.GetRowCellValue(curRow, "dept_test");
                dtTempDel.Rows.Add(newRow);
                gridView1.DeleteRow(curRow);//移走當前行                
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtRemark.Focus();//Toolscript焦點問題
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            frmMo_test_list_find frmTest = new frmMo_test_list_find();
            frmTest.ShowDialog();
            if (frmMo_test_list.ID_Search != "")
            {
                Find_doc(frmMo_test_list.ID_Search);
            }
            frmMo_test_list.ID_Search = "";
            frmTest.Dispose();
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
            txtID.Enabled = true;
            txtVer.Text = "0";           
            txtID.Properties.ReadOnly = false;            
            DataRow dr = dtTest_mostly.NewRow(); //插一空行
            dtTest_mostly.Rows.InsertAt(dr, 0);

            dtTest_details.Clear();
            gridControl1.DataSource = dtTest_details;
        }

        private void Edit()  //編輯
        {
            if (txtID.Text == "")
            {
                return;
            }
            string sql = string.Format("Select MAX(ver) AS ver From bs_mo_test_list_head Where mo_id='{0}'", txtID.Text);
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            if (dt.Rows[0]["ver"].ToString() != txtVer.Text)
            {
                MessageBox.Show("當前版本不可編輯，只能對最大版本進行編輯!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
            txtID.Enabled = false;
            txtID.BackColor = System.Drawing.Color.White;           
        }

        private void SetButtonSatus(bool _flag) //設置工具欄
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            BTNITEMADD.Enabled = !_flag;
            BTNITEMDEL.Enabled = !_flag;

            BTNNEWVER.Enabled = _flag;
            btnSelectVer.Enabled = _flag;
            clsAppPublic.SetToolBarEnable(this.Name,this.Controls);//重新設置按鈕權限

        }

        private void Set_Grid_Status(bool _flag) // 表格可編輯否
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag;
            //gridView2.OptionsBehavior.Editable = _flag;                       
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtItem_id.Text))
            {
                return;
            }
            //DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = MessageBox.Show("此操作將刪除該頁數主表及明細中全部版本資料,請謹慎操作!", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = @"DELETE FROM dbo.bs_mo_test_list_head WHERE mo_id=@mo_id";

                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@mo_id", txtID.EditValue.ToString());
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit(); //數據提交                        
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(this.Controls, "1");
                        dtTest_details.Clear();
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

        private void AddNew_Item()
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim()) && !String.IsNullOrEmpty(txtItem_id.Text)) // 有內容
            {
                if (Check_Details_Valid())
                {
                    return;
                }
                Set_Grid_Status(true);
                gridView1.AddNewRow();//新增
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "mo_id", txtID.EditValue);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ver", txtVer.Text);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq_id", (gridView1.RowCount + 1).ToString("000"));

                ColumnView view = (ColumnView)gridView1;//初始單元格焦點
                view.FocusedColumn = view.Columns["dept_test"];
                view.Focus();
            }
            else
            {
                MessageBox.Show("主表的頁數,貨品編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
            }
        }

        private bool Check_Details_Valid() //檢查明細資料的有效性
        {
            //測試項目必須有輸入
            bool _flag = false;
            if (gridView1.RowCount > 0)
            {
                txtRemark.Focus();
                //因toolStrip控件焦點問題
                //設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，附止取到的值爲空
                // ColumnView view = (ColumnView)gridView1 ;
                // view.FocusedColumn = view.Columns["dept_test"];                
                int curRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    curRow = gridView1.GetRowHandle(i);
                    if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "dept_test")))
                    {
                        _flag = true;
                        MessageBox.Show("負責部門不可以爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)gridView1;
                        view1.FocusedColumn = view1.Columns["dept_test"]; //設置單元格焦點                        
                        break;
                    }
                }
            }
            return _flag;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            SetObjValue.ClearObjValue(this.Controls, "2");
            Set_Grid_Status(false);

            dtTempDel.Clear();
            dtTest_details.Clear();
            gridControl1.DataSource = dtTest_details;

            mState = "";
            txtID.Enabled = true;
            if (!String.IsNullOrEmpty(mID)&&!String.IsNullOrEmpty(mVer))
            {
                Find_doc(mID);
            }
        }

        private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string sql_h = String.Format(
                        @"SELECT A.* FROM dbo.bs_mo_test_list_head A with(nolock) WHERE A.mo_id ='{0}' AND 
                           A.ver=(Select MAX(ver) From bs_mo_test_list_head Where mo_id=A.mo_id)",temp_id);
                string sql_d = String.Format(
                        @"SELECT B.* 
                        FROM dbo.bs_mo_test_list_head A with(nolock),
                             dbo.bs_mo_test_list_details B with(nolock) 
                        WHERE A.mo_id = B.mo_id AND A.ver=B.ver AND A.mo_id='{0}' AND 
                             A.ver=(Select MAX(ver) From bs_mo_test_list_head Where mo_id=A.mo_id)",temp_id);
                dtTest_mostly = clsPublicOfCF01.GetDataTable(sql_h);
                if (dtTest_mostly.Rows.Count > 0)
                {
                    txtID.EditValue = dtTest_mostly.Rows[0]["mo_id"].ToString();
                    Set_Master_Data(dtTest_mostly);
                }
                else
                {
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                dtTest_details.Clear();
                dtTest_details = clsPublicOfCF01.GetDataTable(sql_d);
                gridControl1.DataSource = dtTest_details;
                mID = txtID.Text;//保存臨時的ID號
                mVer = txtVer.Text;
            }
        }

        private void Find_doc(string temp_id,string pVer) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string sql_h = String.Format(
                        @"SELECT A.* FROM dbo.bs_mo_test_list_head A with(nolock) WHERE A.mo_id ='{0}' AND A.ver='{1}'", temp_id,pVer);
                string sql_d = String.Format(
                        @"SELECT B.* 
                        FROM dbo.bs_mo_test_list_head A with(nolock),
                             dbo.bs_mo_test_list_details B with(nolock) 
                        WHERE A.mo_id = B.mo_id AND A.ver=B.ver AND A.mo_id='{0}' AND A.ver='{1}'", temp_id, pVer);
                dtTest_mostly = clsPublicOfCF01.GetDataTable(sql_h);
                if (dtTest_mostly.Rows.Count > 0)
                {
                    txtID.EditValue = dtTest_mostly.Rows[0]["mo_id"].ToString();
                    Set_Master_Data(dtTest_mostly);
                }
                else
                {
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                dtTest_details.Clear();
                dtTest_details = clsPublicOfCF01.GetDataTable(sql_d);
                gridControl1.DataSource = dtTest_details;
                mID = txtID.Text;//保存臨時的ID號               
            }
        }

        private void Save()  //保存
        {
            if (!Save_Before_Valid())
            {
                return;
            }
            if (Check_Details_Valid())//檢查明細資料的有效性
            {
                return;
            }

            save_flag = false;
            bool result_qc = false; //檢查結果
            bool result_chk = false; //頁數整個流程是否OK.

            #region  保存新增
            if (mState == "NEW")
            {
                if (Valid_Doc())
                {
                    return;
                }                
                const string sql_i =
                    @"INSERT INTO dbo.bs_mo_test_list_head(mo_id,ver,item_id,brand,mould_id,cust_item_id,artwork,size,cust_color,remark,crusr,crtim,result) 
                      VALUES(@mo_id,@ver,@item_id,@brand,@mould_id,@cust_item_id,@artwork,@size,@cust_color,@remark,@crusr,getdate(),@result)";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@mo_id", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                        myCommand.Parameters.AddWithValue("@item_id", txtItem_id.EditValue);
                        myCommand.Parameters.AddWithValue("@brand", txtBrand_id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@mould_id", txtMould_id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cust_item_id", txtCust_item_id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@artwork", txtArtwork.Text.Trim());
                        myCommand.Parameters.AddWithValue("@size", txtSize.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cust_color", txtCust_color.Text);
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);                        
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        
                        if (chkResult.Checked)
                        {
                            result_chk = true;
                        }
                        else
                        {
                            result_chk = false;
                        }
                        myCommand.Parameters.AddWithValue("@result", result_chk);
                        myCommand.ExecuteNonQuery();

                        //保存明細
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_mo_test_list_details
                                  (mo_id,ver,seq_id,dept_test,result_test,date_test,dept_next,date_dept_next,receipt_by,receipt_date,remark) VALUES
                                  (@mo_id,@ver,@seq_id,@dept_test,@result_test,Case When Len(@date_test)=0 Then null ELSE @date_test END,@dept_next,
                                  Case When Len(@date_dept_next)=0 Then null ELSE @date_dept_next END,@receipt_by,
                                  Case When Len(@receipt_date)=0 Then null ELSE @receipt_date END,@remark)";
                            string strSeq_id = "";
                            for (int i = 0; i < dtTest_details.Rows.Count; i++)
                            {
                                //curRow = gridView1.GetRowHandle(i);
                                myCommand.CommandText = sql_item_i;
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@mo_id", txtID.Text);
                                myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                                strSeq_id = Get_Details_Seq(txtID.EditValue.ToString(), txtVer.Text); //新增狀態重取最大序號
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@dept_test", dtTest_details.Rows[i]["dept_test"].ToString());
                                result_qc = false;
                                string qc_result = dtTest_details.Rows[i]["result_test"].ToString();
                                if (qc_result == "True")
                                {
                                    result_qc = true;
                                }
                                else
                                {
                                    result_qc = false;
                                }
                                myCommand.Parameters.AddWithValue("@result_test", result_qc);

                                string strDate = GetDateString(dtTest_details.Rows[i]["date_test"].ToString());
                                myCommand.Parameters.AddWithValue("@date_test", strDate);
                                myCommand.Parameters.AddWithValue("@dept_next", dtTest_details.Rows[i]["dept_next"].ToString());
                                myCommand.Parameters.AddWithValue("@date_dept_next", GetDateString(dtTest_details.Rows[i]["date_dept_next"].ToString()));
                                myCommand.Parameters.AddWithValue("@receipt_by", dtTest_details.Rows[i]["receipt_by"].ToString());
                                myCommand.Parameters.AddWithValue("@receipt_date", GetDateString(dtTest_details.Rows[i]["receipt_date"].ToString()));
                                myCommand.Parameters.AddWithValue("@remark", dtTest_details.Rows[i]["remark"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }
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
                string rowStatus = "";
                string strSeq_id = "";
                const string sql_update =
                    @"UPDATE dbo.bs_mo_test_list_head 
                      SET item_id=@item_id,
                          brand=@brand,
                          mould_id=@mould_id,
                          cust_item_id=@cust_item_id,
                          artwork=@artwork,
                          size=@size,cust_color=@cust_color,
                          remark=@remark,
                          amusr=@amusr,amtim=getdate(),
                          result=@result
                      WHERE mo_id=@mo_id and ver=@ver";
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@mo_id", txtID.Text);
                        myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                        myCommand.Parameters.AddWithValue("@item_id", txtItem_id.Text);
                        myCommand.Parameters.AddWithValue("@brand", txtBrand_id.Text);
                        myCommand.Parameters.AddWithValue("@mould_id", txtMould_id.Text);
                        myCommand.Parameters.AddWithValue("@cust_item_id", txtCust_item_id.Text);
                        myCommand.Parameters.AddWithValue("@artwork", txtArtwork.Text);                        
                        myCommand.Parameters.AddWithValue("@size", txtSize.Text);
                        myCommand.Parameters.AddWithValue("@cust_color", txtCust_color.Text);
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                        myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);
                        if (chkResult.Checked)
                        {
                            result_chk = true;
                        }
                        else
                        {
                            result_chk = false;
                        }
                        myCommand.Parameters.AddWithValue("@result", result_chk);
                        myCommand.ExecuteNonQuery();

                        //刪除明細資料
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            const string sql_item_d = @"DELETE FROM dbo.bs_mo_test_list_details WHERE mo_id=@mo_id AND ver=@ver AND seq_id=@seq_id and dept_test=@dept_test";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@mo_id", txtID.Text);
                            myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                            myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());
                            myCommand.Parameters.AddWithValue("@dept_test", dtTempDel.Rows[i]["dept_test"].ToString());  
                            myCommand.ExecuteNonQuery();
                        }

                        //保存明細資料
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                 @"INSERT INTO bs_mo_test_list_details
                                  (mo_id,ver,seq_id,dept_test,result_test,date_test,dept_next,date_dept_next,receipt_by,receipt_date,remark) VALUES
                                  (@mo_id,@ver,@seq_id,@dept_test,@result_test,
                                  CASE When Len(@date_test)=0 Then null ELSE @date_test END,@dept_next,
                                  CASE When Len(@date_dept_next)=0 Then null ELSE @date_dept_next END,@receipt_by,
                                  CASE When Len(@receipt_date)=0 Then null ELSE @receipt_date END,@remark)";
                            const string sql_item_u =
                                @"UPDATE bs_mo_test_list_details 
                                  SET dept_test=@dept_test,result_test=@result_test,
                                      date_test=CASE WHEN LEN(@date_test)=0 THEN null ELSE @date_test END,
                                      dept_next=@dept_next,date_dept_next=CASE WHEN LEN(@date_dept_next)=0 THEN null ELSE @date_dept_next END,
                                      receipt_by=@receipt_by,receipt_date=CASE WHEN LEN(@receipt_date)=0 THEN null ELSE @receipt_date END,
                                      remark=@remark
                                  WHERE mo_id=@mo_id AND ver=@ver AND seq_id=@seq_id";
                            for (int i = 0; i < dtTest_details.Rows.Count; i++)
                            {
                                rowStatus = dtTest_details.Rows[i].RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                    {
                                        myCommand.CommandText = sql_item_i;
                                        strSeq_id = Get_Details_Seq(txtID.Text,txtVer.Text); //新增狀態重新取最大序號
                                    }
                                    if (rowStatus == "Modified")
                                    {
                                        myCommand.CommandText = sql_item_u;
                                        strSeq_id = dtTest_details.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                    }
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@mo_id", txtID.Text);
                                    myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                                    myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                    myCommand.Parameters.AddWithValue("@dept_test", dtTest_details.Rows[i]["dept_test"].ToString());
                                    result_qc = false;
                                    string qc_result = dtTest_details.Rows[i]["result_test"].ToString();
                                    if (qc_result == "True")
                                    {
                                        result_qc = true;
                                    }
                                    else
                                    {
                                        result_qc = false;
                                    }
                                    myCommand.Parameters.AddWithValue("@result_test", result_qc);
                                    myCommand.Parameters.AddWithValue("@date_test", GetDateString(dtTest_details.Rows[i]["date_test"].ToString()));
                                    myCommand.Parameters.AddWithValue("@dept_next", dtTest_details.Rows[i]["dept_next"].ToString());
                                    myCommand.Parameters.AddWithValue("@date_dept_next",  GetDateString(dtTest_details.Rows[i]["date_dept_next"].ToString()));
                                    myCommand.Parameters.AddWithValue("@receipt_by", dtTest_details.Rows[i]["receipt_by"].ToString());
                                    myCommand.Parameters.AddWithValue("@receipt_date", GetDateString(dtTest_details.Rows[i]["receipt_date"].ToString()));
                                    myCommand.Parameters.AddWithValue("@remark", dtTest_details.Rows[i]["remark"].ToString());
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                        }
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
            
            txtID.Enabled = true;
            dtTempDel.Clear();
            if (save_flag)
            {
                Find_doc(txtID.Text);
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (txtID.Text == "" || txtItem_id.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "頁數、貨品編號不可爲空!";
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
            string doc = txtID.Text;
            string strSql = String.Format("Select '1' FROM dbo.bs_mo_test_list_head WHERE mo_id='{0}' and ver='{1}'", doc,txtVer.Text);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("註意：該頁數已存在" + String.Format("【{0}】!", doc), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        public static string Get_Details_Seq(string _id,string _ver) //取明細的序號
        {
            DataTable dtMaxseq = new DataTable();

            dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format(@"SELECT MAX(seq_id) as seq_id FROM dbo.bs_mo_test_list_details with(nolock) 
                                                                    WHERE mo_id ='{0}' And ver='{1}'", _id, _ver));

            string strSeq;
            if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
            {
                strSeq = "001";
            }
            else
            {
                strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000");                
            }
            dtMaxseq.Dispose();
            return strSeq;
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
            txtID.Text = dt.Rows[0]["mo_id"].ToString();
            txtVer.Text = dt.Rows[0]["ver"].ToString();
            txtItem_id.EditValue = dt.Rows[0]["item_id"].ToString();            
            txtBrand_id.Text = dt.Rows[0]["brand"].ToString();
            txtMould_id.Text = dt.Rows[0]["mould_id"].ToString();
            txtCust_item_id.Text = dt.Rows[0]["cust_item_id"].ToString();
            txtCust_color.Text = dt.Rows[0]["cust_color"].ToString();
            txtArtwork.Text = dt.Rows[0]["artwork"].ToString();
            txtSize.Text = dt.Rows[0]["size"].ToString();
            txtRemark.Text = dt.Rows[0]["remark"].ToString();
            txtCrusr.Text = dt.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dt.Rows[0]["amtim"].ToString();
            chkResult.Checked = (bool)dt.Rows[0]["result"];
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            string strMo = txtID.Text ;
            if (!String.IsNullOrEmpty(strMo))
            {
                if (mState == "NEW") //新增模式
                {
                    if (Valid_Doc())
                    {
                        //如果已存在,調出資料                       
                        Cancel();
                        Find_doc(strMo);
                    }
                    else
                    {
                        //檢查MO是否存在
                        if (CheckMO(strMo))
                        {
                            Get_MO_Data(strMo);
                        }
                        else
                        {
                            MessageBox.Show("註意：該頁數幷不存在!" + String.Format("【{0}】!", strMo), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtID.Text = "";
                        }                       
                    }
                }
                else
                {
                    Get_MO_Data(strMo);
                    Find_doc(strMo);
                }
            }
        }

        private void Print() //通用的列印方法
        {
            if (gridView1.RowCount > 0)
            {
                DevExpress.XtraPrinting.PrintingSystem printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
                DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
                // Add the link to the printing system's collection of links.
                printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });

                // Assign a control to be printed by this link.
                printableComponentLink1.Component = gridControl1;

                // Set the paper orientation to Landscape.
                printableComponentLink1.Landscape = true;//橫向縱向設置

                //显示打印预览
                printableComponentLink1.ShowPreview();

                //直接送至打印機
                //printableComponentLink1.PrintDlg();                
            }
        }

        private void Get_MO_Data(string pMO)
        {
            dtData_mo.Clear();
            dtData_dropbox.Clear();
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@mo_id", pMO) };
            DataSet ds = clsPublicOfCF01.ExecuteProcedureReturnDataSet("usp_get_mo_date", paras, null);
            dtData_dropbox = ds.Tables[0];
            dtData_mo = ds.Tables[1];
            txtItem_id.Properties.DataSource = dtData_dropbox;
            txtItem_id.Properties.ValueMember = "id";
            txtItem_id.Properties.DisplayMember = "id";
            txtItem_id.ItemIndex = 0;
        }

        private void txtItem_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState == "NEW")
            {
                if (!string.IsNullOrEmpty(txtItem_id.EditValue.ToString()))
                {
                    DataRow[] dw = dtData_mo.Select(string.Format("id='{0}'", txtItem_id.EditValue));
                    txtBrand_id.Text = dw[0]["brand_id"].ToString();
                    txtMould_id.Text = dw[0]["mould_id"].ToString();
                    txtCust_item_id.Text = dw[0]["cust_item_id"].ToString();
                    txtCust_color.Text = dw[0]["cust_color"].ToString();
                    txtArtwork.Text = dw[0]["artwork"].ToString();
                    txtSize.Text = dw[0]["size"].ToString();
                }
            }            
        }

        private string GetDateString(string pDate)
        {
            string strDate = "";
            if (string.IsNullOrEmpty(pDate))
            {
                strDate = "";
            }
            else
            {
                strDate = Convert.ToDateTime(pDate).ToString("yyyy-MM-dd");
            }
            return strDate;
        }

        private void btnNewVer_Click(object sender, EventArgs e)
        {
            string strSql = "";
            if (mState == "" && !string.IsNullOrEmpty(txtID.Text) && gridView1.RowCount > 0)
            {
                strSql = String.Format("SELECT MAX(ver) AS ver FROM dbo.bs_mo_test_list_head with(nolock) WHERE mo_id='{0}' ", txtID.Text);
                DataTable dtMaxVer = clsPublicOfCF01.GetDataTable(strSql);
                string temp_max_ver = dtMaxVer.Rows[0]["ver"].ToString();//取最大版本
                if (temp_max_ver != txtVer.Text)
                {
                    MessageBox.Show("當前版本不可產生新版本！" + "\n" + "\n" + "請選擇最後一個版本號來做新版本!", myMsg.msgTitle,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                return;
            }

            DialogResult result = MessageBox.Show("當前操作將產生新的版本！" + "\n" + "\n" + "是否要進行此操作?", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {                
                string ver_new = (Convert.ToInt16(txtVer.Text) + 1).ToString();
                strSql = string.Format(@"Select '1' From dbo.bs_mo_test_list_head with(nolock) Where mo_id='{0}' and ver={1}", txtID.Text, ver_new);
                DataTable dtMaxVer = clsPublicOfCF01.GetDataTable(strSql);
                if (dtMaxVer.Rows.Count == 0)
                {
                    int iResult = 0;
                    SqlParameter[] paras = new SqlParameter[]
                    {                    
                        new SqlParameter("@mo_id",txtID.Text),
                        new SqlParameter("@ver",txtVer.Text),
                        new SqlParameter("@max_ver",ver_new)
                    };

                    try
                    {
                        iResult = clsPublicOfCF01.ExecuteNonQuery("usp_mo_list_new_version", paras, true);
                    }
                    catch (Exception E)
                    {
                        throw new Exception(E.Message);
                    }

                    if (iResult < 0)
                    {
                        string strMsg = String.Format("頁數測試流程：{0} 已成功生成新的版本【{1}】 ", txtID.Text, ver_new);                        
                        Find_doc(txtID.Text);
                        MessageBox.Show(strMsg, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("此版本已經有新的版本【{0}】,請返回檢查！", ver_new), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }


        private void btnSelectVer_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(mID))
            {
                Open_multi_ver(mID);
            }
        }


        private void Open_multi_ver(string _pId)
        {
            if (mState == "")
            {
                frmMo_test_list_ver frm = new frmMo_test_list_ver(_pId);
                frm.ShowDialog();
                if (!String.IsNullOrEmpty(frm._Requ_id) && !String.IsNullOrEmpty(frm._ver))
                {
                    Find_doc(frm._Requ_id, frm._ver);
                }
                frm.Dispose();
            }
        }

        public bool CheckMO(string pMO)
        {
            bool flag = false;
            string strSql = string.Format(
                             @"SELECT '1' FROM so_order_manage A 
	                          INNER JOIN so_order_details B 
		                          ON A.within_code=B.within_code AND A.id=B.id and A.ver=B.ver 
                              WHERE A.within_code='0000' AND A.state NOT IN ('2','V') AND B.mo_id ='{0}'", pMO);
            DataTable dt = clsConErp.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }


    }
}
