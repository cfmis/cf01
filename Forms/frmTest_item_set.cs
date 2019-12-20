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
    public partial class frmTest_item_set : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private clsAppPublic clsAppPublic = new clsAppPublic();
        public string mID = "";    //臨時的主鍵值
        public string mProd_type = "";
        public static string ID_Search = "";
        public static string Prod_type_Search = "";
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;

        public bool save_flag;
        public string strArea = "";
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public string test_public_path = "";
        DataTable dtTest_item_mostly = new DataTable();
        DataTable dtTest_item_details = new DataTable();
        DataTable dtTempDel = new DataTable();
        DataTable dtTestItem = new DataTable();
        DataTable dtType_condition = new DataTable();


        public frmTest_item_set()
        {
            InitializeComponent();
            //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            //control.GenerateContorl();
            //clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            str_language = DBUtility._language;
            //NextControl oNext = new NextControl(this, "2");
            //oNext.EnterToTab();
        }

        private void frmTest_item_set_Load(object sender, EventArgs e)
        {
            //分類
            clsTestProductPlan.SetType(txtType);
            //產品類型
            clsTestProductPlan.SetProductType(txtProd_type);

            //生成gridview1明細表結構
            dtTest_item_details = clsPublicOfCF01.GetDataTable("Select * From dbo.bs_test_item_details Where 1=0");
            gridControl1.DataSource = dtTest_item_details;
            //臨時項目刪除表結構
            dtTempDel = dtTest_item_details.Clone();

            //gridview1測試項目下拉列表框
            try
            {
                string strSql = @"SELECT test_item_id as id,test_item_name as cdesc,english_name as edesc FROM dbo.cd_qc_test_item";
                dtTestItem = clsConErp.GetDataTable(strSql);

                clTest_item_id.DataSource = dtTestItem;
                clTest_item_id.ValueMember = "id";
                clTest_item_id.DisplayMember = "id";
                clTest_item_id.ShowHeader = false;
                clTest_item_id.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
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
                newRow["id"] = txtID.EditValue.ToString();
                newRow["prod_type"] = txtProd_type.EditValue.ToString();
                newRow["seq_id"] = gridView1.GetRowCellDisplayText(curRow, "seq_id");
                newRow["test_item_id"] = gridView1.GetRowCellDisplayText(curRow, "test_item_id");
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
            //Print();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            frmTest_item_set_find frmTest = new frmTest_item_set_find();
            frmTest.ShowDialog();
            if (frmTest_item_set.ID_Search != "")
            {
                Find_doc(frmTest_item_set.ID_Search,frmTest_item_set.Prod_type_Search);
            }
            frmTest_item_set.ID_Search = "";
            frmTest.Dispose();
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtType.Focus();
            SetButtonSatus(false);            
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
            txtType.Enabled = true;
            txtID.Enabled = true;
            txtType.Properties.ReadOnly = false;
            txtID.Properties.ReadOnly = false;
            DataRow dr = dtTest_item_mostly.NewRow(); //插一空行
            dtTest_item_mostly.Rows.InsertAt(dr, 0);

            dtTest_item_details.Clear();
            gridControl1.DataSource = dtTest_item_details;
        }

        private void Edit()  //編輯
        {
            if (txtType.Text == "")
            {
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

            txtType.Properties.ReadOnly = true;
            txtType.BackColor = System.Drawing.Color.White;
            txtType.Enabled = false;
            txtType.BackColor = System.Drawing.Color.White;
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
            clsAppPublic.SetToolBarEnable(this.Name, this.Controls);

        }

        private void Set_Grid_Status(bool _flag) // 表格可編號否
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag;
            //gridView2.OptionsBehavior.Editable = _flag;                       
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtType.Text))
            {
                return;
            }

            //DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = MessageBox.Show("此操作將刪除主表及明細中的資料,請謹慎操作!", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = @"Update dbo.bs_test_item_mostly SET state='2' WHERE id=@id And prod_type=@prod_type";

                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@prod_type", txtProd_type.EditValue.ToString());
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit(); //數據提交                        
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(this.Controls, "1");
                        dtTest_item_details.Clear();
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
            if (!String.IsNullOrEmpty(txtID.Text.Trim()) && !String.IsNullOrEmpty(txtType.Text) && !String.IsNullOrEmpty(txtProd_type.Text)) // 有內容
            {
                if (Check_Details_Valid())
                {
                    return;
                }
                Set_Grid_Status(true);
                gridView1.AddNewRow();//新增
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id", txtID.EditValue);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "prod_type", txtProd_type.EditValue);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq_id", (gridView1.RowCount + 1).ToString("000"));

                ColumnView view = (ColumnView)gridView1;//初始單元格焦點
                view.FocusedColumn = view.Columns["test_item_id"];
                view.Focus();
            }
            else
            {
                MessageBox.Show("主表的分類,測試類別,產品類型不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtType.Focus();
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
                // view.FocusedColumn = view.Columns["test_item_id"];                
                int curRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    curRow = gridView1.GetRowHandle(i);
                    if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "test_item_id")))
                    {
                        _flag = true;
                        MessageBox.Show("測試項目編號不可以爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)gridView1;
                        view1.FocusedColumn = view1.Columns["test_item_id"]; //設置單元格焦點                        
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
            dtTest_item_details.Clear();
            gridControl1.DataSource = dtTest_item_details;

            mState = "";
            if (!String.IsNullOrEmpty(mID) && !String.IsNullOrEmpty(mProd_type))
            {
                Find_doc(mID, mProd_type);
            }
        }

        private void Find_doc(string pID,string pProd_type) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(pID))
            {
                string sql_h = String.Format(
                        @"SELECT * FROM dbo.bs_test_item_mostly WITH(nolock) 
                        WHERE id ='{0}' and prod_type='{1}' AND state='{2}'", pID,pProd_type,"0");
                string sql_d = String.Format(
                        @"SELECT B.* FROM dbo.bs_test_item_mostly A with(nolock),dbo.bs_test_item_details B with(nolock) 
                        WHERE A.id = B.id AND A.prod_type=B.prod_type AND A.id='{0}' AND A.prod_type='{1}' AND A.state='{2}'", pID,pProd_type,"0");
                dtTest_item_mostly = clsPublicOfCF01.GetDataTable(sql_h);
                if (dtTest_item_mostly.Rows.Count > 0)
                {
                    txtType.EditValue = dtTest_item_mostly.Rows[0]["type"].ToString();
                    Set_Drop_Box();
                    Set_Master_Data(dtTest_item_mostly);
                }
                else
                {
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                dtTest_item_details.Clear();
                dtTest_item_details = clsPublicOfCF01.GetDataTable(sql_d);
                gridControl1.DataSource = dtTest_item_details;
                mID = txtID.EditValue.ToString();//保存臨時的ID號 
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

            if (IsRepeat()) //檢查明細是否有重覆測試項目
            {
                return;
            }

            save_flag = false;
            string strProd_type = "";
            if (string.IsNullOrEmpty(txtProd_type.EditValue.ToString()))
            {
                strProd_type = "";
            }
            else
            {
                strProd_type = txtProd_type.EditValue.ToString();
            }
            #region  保存新增
            if (mState == "NEW")
            {
                if (Valid_Doc())
                {
                    return;
                }
                const string sql_i =
                    @"INSERT INTO dbo.bs_test_item_mostly(id,prod_type,type,cdesc,edesc,remark,state,crusr,crtim) values
                       (@id,@prod_type,@type,@cdesc,@edesc,@remark,@state,@crusr,getdate())";

                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@prod_type", strProd_type);                        
                        myCommand.Parameters.AddWithValue("@type", txtType.EditValue);
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text.Trim());                
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                        myCommand.Parameters.AddWithValue("@state", "0");
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                        //保存明細
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_test_item_details(id,prod_type,seq_id,test_item_id,test_item_cdesc,test_item_edesc,remark)
                                    VALUES(@id,@prod_type,@seq_id,@test_item_id,@test_item_cdesc,@test_item_edesc,@remark)";
                            string strSeq_id = "";
                            for (int i = 0; i < dtTest_item_details.Rows.Count; i++)
                            {
                                //curRow = gridView1.GetRowHandle(i);
                                myCommand.CommandText = sql_item_i;
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                                myCommand.Parameters.AddWithValue("@prod_type", txtProd_type.EditValue);
                                strSeq_id = Get_Details_Seq(txtID.EditValue.ToString(), txtProd_type.EditValue.ToString()); //新增狀態重取最大序號
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@test_item_id", dtTest_item_details.Rows[i]["test_item_id"].ToString());
                                myCommand.Parameters.AddWithValue("@test_item_cdesc", dtTest_item_details.Rows[i]["test_item_cdesc"].ToString());
                                myCommand.Parameters.AddWithValue("@test_item_edesc", dtTest_item_details.Rows[i]["test_item_edesc"].ToString());
                                myCommand.Parameters.AddWithValue("@remark", dtTest_item_details.Rows[i]["remark"].ToString());
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
                    @"UPDATE bs_test_item_mostly
                      SET cdesc=@cdesc,edesc=@edesc,products_type=@products_type,remark=@remark,amusr=@update_by,amtim=getdate()
                      WHERE id=@id and prod_type=@prod_type and state=@state";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@prod_type", txtProd_type.EditValue);                        
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text);
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text);
                        myCommand.Parameters.AddWithValue("@products_type", strProd_type);
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                        myCommand.Parameters.AddWithValue("@state", "0");
                        myCommand.Parameters.AddWithValue("@update_by", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();

                        //刪除明細資料
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            const string sql_item_d = @"DELETE FROM dbo.bs_test_item_details WHERE id=@id and prod_type=@prod_type AND seq_id=@seq_id AND test_item_id=@test_item_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                            myCommand.Parameters.AddWithValue("@prod_type", txtProd_type.EditValue);
                            myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());
                            myCommand.Parameters.AddWithValue("@test_item_id", dtTempDel.Rows[i]["test_item_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }

                        //保存明細資料
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_test_item_details(id,prod_type,seq_id,test_item_id,test_item_cdesc,test_item_edesc,remark)
                                    VALUES(@id,@prod_type,@seq_id,@test_item_id,@test_item_cdesc,@test_item_edesc,@remark)";
                            const string sql_item_u =
                                @"UPDATE bs_test_item_details 
                                        SET test_item_id=@test_item_id,test_item_cdesc=@test_item_cdesc,test_item_edesc=@test_item_edesc,remark=@remark
                                  WHERE id=@id and prod_type=@prod_type AND seq_id=@seq_id ";//AND test_item_id=@test_item_id";
                            for (int i = 0; i < dtTest_item_details.Rows.Count; i++)
                            {
                                rowStatus = dtTest_item_details.Rows[i].RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                    {
                                        myCommand.CommandText = sql_item_i;
                                        strSeq_id = Get_Details_Seq(txtID.EditValue.ToString(),txtProd_type.EditValue.ToString()); //新增狀態重新取最大序號
                                    }
                                    if (rowStatus == "Modified")
                                    {
                                        myCommand.CommandText = sql_item_u;
                                        strSeq_id = dtTest_item_details.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                    }
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                                    myCommand.Parameters.AddWithValue("@prod_type", txtProd_type.EditValue);
                                    myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                    myCommand.Parameters.AddWithValue("@test_item_id", dtTest_item_details.Rows[i]["test_item_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@test_item_cdesc", dtTest_item_details.Rows[i]["test_item_cdesc"].ToString());
                                    myCommand.Parameters.AddWithValue("@test_item_edesc", dtTest_item_details.Rows[i]["test_item_edesc"].ToString());
                                    myCommand.Parameters.AddWithValue("@remark", dtTest_item_details.Rows[i]["remark"].ToString());
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
            txtID.Enabled = false;
            dtTempDel.Clear();
            if (save_flag)
            {
                Find_doc(txtID.EditValue.ToString(),txtProd_type.EditValue.ToString());
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (txtID.Text == "" || txtType.Text == "" || txtProd_type.Text=="")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "分類、測試類別、產品類型不可爲空！";
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
            string doc = txtID.EditValue.ToString();
            string prod_type = txtProd_type.EditValue.ToString();
            string strSql = String.Format("Select '1' FROM dbo.bs_test_item_mostly WHERE id='{0}' and prod_type='{1}'", doc, prod_type);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("註意：該測試類別,產品類型已存在" + String.Format("【{0}{1}】!", doc, prod_type), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        public static string Get_Details_Seq(string _id,string _prod_type) //取明細的序號
        {
            DataTable dtMaxseq = new DataTable();

            dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.bs_test_item_details with(nolock) WHERE id ='{0}' and prod_type='{1}'", _id,_prod_type));

            string strSeq;
            if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
            {
                strSeq = "001";
            }
            else
            {
                strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = (Convert.ToInt16(strSeq) + 1).ToString("000");
            }
            dtMaxseq.Dispose();
            return strSeq;
        }

        private void clTest_item_id_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit objItem = (LookUpEdit)sender;
            string strid = objItem.Text;
            int indexSelect = clTest_item_id.GetDataSourceRowIndex("id", strid);
            string strcdesc = clTest_item_id.GetDataSourceValue("cdesc", indexSelect).ToString();
            string strdesc = clTest_item_id.GetDataSourceValue("edesc", indexSelect).ToString();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_item_cdesc", strcdesc);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_item_edesc", strdesc);
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
            txtType.EditValue = dt.Rows[0]["type"].ToString();
            txtID.EditValue = dt.Rows[0]["id"].ToString();
            txtProd_type.EditValue = dt.Rows[0]["prod_type"].ToString();
            txtCdesc.Text = dt.Rows[0]["cdesc"].ToString();
            txtEdesc.Text = dt.Rows[0]["edesc"].ToString();
            txtRemark.Text = dt.Rows[0]["remark"].ToString();
            txtCrusr.Text = dt.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dt.Rows[0]["amtim"].ToString();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                if (mState == "NEW") //新增模式
                {
                    if (Valid_Doc())
                    {
                        //如果已存在,調出資料
                        string temp_id = txtID.EditValue.ToString();
                        Cancel();
                        Find_doc(txtID.EditValue.ToString(),txtProd_type.EditValue.ToString());
                    }
                }
            }
        }

        private bool IsRepeat() //測試項目編號不允許有重覆
        {
            if (gridView1.RowCount < 2)
            {
                return false;
            }
            bool result = false;
            string strTest_Item_id = "";
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                strTest_Item_id = gridView1.GetRowCellDisplayText(i, "test_item_id");
                for (int j = i + 1; j <= gridView1.RowCount - 1; j++)
                {
                    if (strTest_Item_id == gridView1.GetRowCellDisplayText(j, "test_item_id"))
                    {
                        MessageBox.Show("測試項目編號不可以有重覆!\n\n" + string.Format("【{0}】", strTest_Item_id),
                                                  myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        private void txtType_Leave(object sender, EventArgs e)
        {
            Set_Drop_Box();
        }

        private void Set_Drop_Box()
        {
            string strType = txtType.EditValue.ToString();
            if (strType != "")
            {
                switch (strType)
                {
                    case "A"://產品類別
                        clsTestProductPlan.SetProductType(txtID);
                        break;
                    case "B"://牌子類別
                        clsTestProductPlan.SetBrandType(txtID);
                        break;
                    case "C"://顏色類別
                        clsTestProductPlan.SetColorType(txtID);
                        break;
                    case "D"://材質
                        clsTestProductPlan.SetMatType(txtID);
                        break;
                    case "E"://V組 PVH
                        clsTestProductPlan.SetPvhType(txtID,"E");
                        break;
                    case "F"://V組 VFA
                        clsTestProductPlan.SetPvhType(txtID,"F");
                        break;
                }

            }
            else
            {
                txtID.Properties.DataSource = null;
            }
        }

        private void txtID_EditValueChanged(object sender, EventArgs e)
        {
            if (txtID.EditValue.ToString() != "")
            {
                txtCdesc.Text = txtID.GetColumnValue("cdesc").ToString();
                txtEdesc.Text = txtID.GetColumnValue("edesc").ToString();
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



    }
}
