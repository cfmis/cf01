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
    public partial class frmProcess_Group : Form
    {

        public string mID = "";    //臨時的主鍵值
        public string mDept = "";
        public static string ID_Search = "";
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
      
        public bool save_flag;
        public string strArea = "";
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public string test_public_path = "";

        DataTable dtProcess_mostly = new DataTable();
        DataTable dtProcess_details = new DataTable();
        DataTable dtTempDel = new DataTable();        
        DataTable dtTestItem = new DataTable();
        DataTable dtType_condition = new DataTable();
        DataTable dtFind= new DataTable();


        public frmProcess_Group()
        {
            InitializeComponent();
            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
            str_language = DBUtility._language;
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
        }

        private void frmProcess_Group_Load(object sender, EventArgs e)
        {            
            //分類
            DataTable dtDept = clsProcessData.Get_dept();
            txtPrd_dep.Properties.DataSource = dtDept;
            txtPrd_dep.Properties.ValueMember = "dep_id";
            txtPrd_dep.Properties.DisplayMember = "dep_cdesc";

            txtdep.Properties.DataSource = dtDept;
            txtdep.Properties.ValueMember = "dep_id";
            txtdep.Properties.DisplayMember = "dep_id";
            txtdep.EditValue = "322";

                                  
            //生成gridview1明細表結構
            dtProcess_details = clsPublicOfCF01.GetDataTable("Select prd_dep,id,process_id,process_id as old_process_id From dbo.bs_process_group_details Where 1=0");
            gridControl1.DataSource = dtProcess_details;
            //臨時項目刪除表結構
            dtTempDel = dtProcess_details.Clone();

            //gridview1測試項目下拉列表框
            string strSql = @"Select id,id+' | '+ cdesc +' / '+ 
                                CONVERT(varchar(10),ISNULL(rotate_speed,0))+' / '+
                                ISNULL(grind_ratio,'-')+' / '+isnull(grind_stone,'-')+' / '+
                                ISNULL(polished_beads,'-')+' / '+convert(varchar(10),isnull(grind_time,0)) as cdesc 
                              FROM bs_process ORDER BY id";

            dtTestItem = clsPublicOfCF01.GetDataTable(strSql);               
            clProcess_id.DataSource = dtTestItem;
            clProcess_id.ValueMember = "id";
            clProcess_id.DisplayMember = "cdesc";
            clProcess_id.ShowHeader = false;
            
      
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
                newRow["prd_dep"] = txtPrd_dep.EditValue.ToString();
                newRow["id"] = txtID.Text;
                newRow["process_id"] = gridView1.GetRowCellValue(curRow, "process_id");
                dtTempDel.Rows.Add(newRow);
                gridView1.DeleteRow(curRow);//移走當前行                
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtCdesc.Focus();//Toolscript焦點問題
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("Select prd_dep AS dept_id,id AS process_group_id FROM dbo.bs_process_group_head with(nolock) WHERE 1>0 ");
            if (txtdep.Text != "")            
                sbSql.Append(string.Format(" AND prd_dep='{0}'",txtdep.EditValue));            
            if(txtProcess_id1.Text!="")
            {
                sbSql.Append(string.Format(" AND id>='{0}'",txtProcess_id1.Text));
            }
            if(txtProcess_id2.Text !="")
                sbSql.Append(string.Format(" AND id<='{0}'", txtProcess_id2.Text));
            dtFind = clsPublicOfCF01.GetDataTable(sbSql.ToString());
            dgvFind.DataSource = dtFind;
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtPrd_dep.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");

            txtPrd_dep.Enabled = true;
            txtID.Enabled = true;
            txtPrd_dep.Properties.ReadOnly = false;
            txtID.Properties.ReadOnly = false;
            


            DataRow dr = dtProcess_mostly.NewRow(); //插一空行
            dtProcess_mostly.Rows.InsertAt(dr, 0);

            dtProcess_details.Clear();
            gridControl1.DataSource = dtProcess_details;
            groupBox1.Visible = false;
        }

        private void Edit()  //編輯
        {
            if (txtPrd_dep.Text == "" && txtID.Text=="")
            {
                return;
            }
            
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.Enabled = false;
            txtID.BackColor = System.Drawing.Color.White;            
           
            txtPrd_dep.Properties.ReadOnly = true;
            txtPrd_dep.Enabled = false;
            txtPrd_dep.BackColor = System.Drawing.Color.White;

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
            BTNITEMADD.Enabled = !_flag;
            BTNITEMDEL.Enabled = !_flag;
            
        }

        private void Set_Grid_Status(bool _flag) // 表格可編號否
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag;
            //gridView2.OptionsBehavior.Editable = _flag;                       
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtPrd_dep.Text))
            {
                return;
            }                   

            //DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = MessageBox.Show("註意：此操作將刪除主表及明細中的資料,請謹慎操作!,是否真的要刪除?", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = @"DELETE FROM dbo.bs_process_group_head WHERE prd_dep=@prd_dep AND id=@id";
                const string sql_del_details = @"DELETE FROM dbo.bs_process_group_details WHERE prd_dep=@prd_dep AND id=@id";
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", txtPrd_dep.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue.ToString()); 
                       
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = sql_del_details;//刪除主檔
                        myCommand.ExecuteNonQuery();
                        
                        myTrans.Commit(); //數據提交                        
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(this.Controls, "1");
                        dtProcess_details.Clear();                        
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
            txtID.Focus();
            if (txtID.Text != "__-__-_-_" 
                && !String.IsNullOrEmpty(txtPrd_dep.Text)) // 有內容
            {
                if (Check_Details_Valid())
                {
                    return;
                }
                Set_Grid_Status(true);
                gridView1.AddNewRow();//新增               
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "prd_dep",txtPrd_dep.EditValue);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id", txtID.EditValue);

                ColumnView view = (ColumnView)gridView1;//初始單元格焦點
                view.FocusedColumn = view.Columns["process_id"];
                view.Focus();

                txtID.Properties.ReadOnly = true;
                txtID.BackColor = System.Drawing.Color.White;
                txtID.Enabled = false;
                txtID.BackColor = System.Drawing.Color.White;

                txtPrd_dep.Properties.ReadOnly = true;
                txtPrd_dep.BackColor = System.Drawing.Color.White;
                txtPrd_dep.Enabled = false;
                txtPrd_dep.BackColor = System.Drawing.Color.White;
            }
            else
            {
                MessageBox.Show("主表的部門及工序組別不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrd_dep.Focus();
            }
        }

        private bool Check_Details_Valid() //檢查明細資料的有效性
        {
            //測試項目必須有輸入
            bool _flag = false;
            if (gridView1.RowCount > 0)
            {
                txtCdesc.Focus();
                //因toolStrip控件焦點問題
                //設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，附止取到的值爲空
                // ColumnView view = (ColumnView)gridView1 ;
                // view.FocusedColumn = view.Columns["test_item_id"];                
                int curRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    curRow = gridView1.GetRowHandle(i);
                    if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "process_id")))
                    {
                        _flag = true;
                        MessageBox.Show("工序編號不可以爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)gridView1;
                        view1.FocusedColumn = view1.Columns["process_id"]; //設置單元格焦點                        
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
            txtID.Enabled = false ;

            dtTempDel.Clear();
            dtProcess_details.Clear();
            gridControl1.DataSource = dtProcess_details;
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
                string sql_h = String.Format(
                        @"SELECT * FROM dbo.bs_process_group_head with(nolock) 
                        WHERE prd_dep='{0}' AND id='{1}'", pDept, pID);
                string sql_d = String.Format(
                        @"SELECT prd_dep,id,process_id,process_id as old_process_id FROM dbo.bs_process_group_details with(nolock) 
                        WHERE prd_dep='{0}' AND id='{1}'", pDept, pID);
                dtProcess_mostly = clsPublicOfCF01.GetDataTable(sql_h);
                if (dtProcess_mostly.Rows.Count > 0)
                {
                    txtPrd_dep.EditValue = dtProcess_mostly.Rows[0]["prd_dep"].ToString();
                    txtID.Text = dtProcess_mostly.Rows[0]["id"].ToString(); 
                    Set_Master_Data(dtProcess_mostly);
                }
                else
                {
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                dtProcess_details.Clear();
                dtProcess_details = clsPublicOfCF01.GetDataTable(sql_d);
                gridControl1.DataSource = dtProcess_details;
                mDept = txtPrd_dep.EditValue.ToString();
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

            #region  保存新增
            if (mState == "NEW")
            {
                if (Valid_Doc())
                {
                    return;
                }
                const string sql_i = @"INSERT bs_process_group_head(prd_dep,id,cdesc,edesc,goods_desc,goods_size,process_color,artwork_shape,crusr,crtim)
                                              VALUES(@prd_dep,@id,@cdesc,@edesc,@goods_desc,@goods_size,@process_color,@artwork_shape,@crusr,getdate()";                   
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();                        
                        myCommand.Parameters.AddWithValue("@prd_dep", txtPrd_dep.EditValue);
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);                       
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@goods_desc", txtGoods_desc.Text);
                        myCommand.Parameters.AddWithValue("@goods_size", txtGoods_size.Text);
                        myCommand.Parameters.AddWithValue("@process_color", txtProcess_color.Text);
                        myCommand.Parameters.AddWithValue("@artwork_shape", txtArtwork_shape.Text);
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);                        
                        myCommand.ExecuteNonQuery();

                        //保存明細
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_process_group_details(prd_dep,id,process_id,crusr,crtim)
                                    VALUES(@prd_dep,@id,@process_id,@crusr,getdate())";                            
                            for (int i = 0; i < dtProcess_details.Rows.Count; i++)
                            {
                                //curRow = gridView1.GetRowHandle(i);
                                myCommand.CommandText = sql_item_i;
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@prd_dep", txtPrd_dep.EditValue);  
                                myCommand.Parameters.AddWithValue("@id", txtID.EditValue);                           
                                myCommand.Parameters.AddWithValue("@process_id", dtProcess_details.Rows[i]["process_id"].ToString());
                                myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);                                                           
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
                const string sql_update =
                    @"UPDATE bs_process_group_head
                      SET cdesc=@cdesc,edesc=@edesc,goods_desc=@goods_desc,goods_size=@goods_size,
                          process_color=@process_color,artwork_shape=@artwork_shape,amusr=@amusr,amtim=getdate()
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
                        myCommand.Parameters.AddWithValue("@prd_dep", txtPrd_dep.EditValue);
                        myCommand.Parameters.AddWithValue("@id", txtID.Text);
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text);
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text);
                        myCommand.Parameters.AddWithValue("@goods_desc", txtGoods_desc.Text);
                        myCommand.Parameters.AddWithValue("@goods_size", txtGoods_size.Text);
                        myCommand.Parameters.AddWithValue("@process_color", txtProcess_color.Text);
                        myCommand.Parameters.AddWithValue("@artwork_shape", txtArtwork_shape.Text);                     
                        myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();

                        //刪除明細資料
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            const string sql_item_d = @"DELETE FROM dbo.bs_process_group_details WHERE prd_dep=@prd_dep AND id=@id AND process_id=@process_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@prd_dep", dtTempDel.Rows[i]["prd_dep"].ToString());
                            myCommand.Parameters.AddWithValue("@id", dtTempDel.Rows[i]["id"].ToString());
                            myCommand.Parameters.AddWithValue("@process_id", dtTempDel.Rows[i]["process_id"].ToString());                            
                            myCommand.ExecuteNonQuery();
                        }

                        //保存明細資料
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_process_group_details(prd_dep,id,process_id,crusr,crtim)
                                    VALUES(@prd_dep,@id,@process_id,@crusr,getdate())";
                            const string sql_item_u =
                                @"UPDATE bs_process_group_details SET process_id=@process_id,crusr=@crusr,crtim=getdate()
                                  WHERE prd_dep=@prd_dep AND id=@id AND process_id=@old_process_id";
                            for (int i = 0; i < dtProcess_details.Rows.Count; i++)
                            {
                                rowStatus = dtProcess_details.Rows[i].RowState.ToString();
                               // string old_process_id = dtProcess_details.Rows[i][]
                                DataRow dr = dtProcess_details.Rows[i];
                               
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                    {
                                        myCommand.CommandText = sql_item_i;               
                                    }
                                    if (rowStatus == "Modified")
                                    {
                                        myCommand.CommandText = sql_item_u;
                                        //strSeq_id = dtProcess_details.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                    }
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@prd_dep", txtPrd_dep.EditValue);
                                    myCommand.Parameters.AddWithValue("@id", txtID.Text);
                                    myCommand.Parameters.AddWithValue("@process_id", dtProcess_details.Rows[i]["process_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@old_process_id", dtProcess_details.Rows[i]["old_process_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);                                                               
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
                        
            groupBox1.Visible = true ;
                       

            if (save_flag)
            {
                Find_doc(txtPrd_dep.EditValue.ToString(),txtID.EditValue.ToString());
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (txtID.Text == "__-__-_-_" || txtPrd_dep.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "部門及工序組別編號不可爲空！";
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
            string strSql = String.Format("Select '1' FROM dbo.bs_process_group_head WHERE prd_dep='{0}' and id='{1}'", txtPrd_dep.EditValue,txtID.EditValue);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("註意：該編號已存在" + String.Format("【{0}】【{1}】!", txtPrd_dep.EditValue, txtID.EditValue), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            txtPrd_dep.EditValue = dt.Rows[0]["prd_dep"].ToString();
            txtID.EditValue = dt.Rows[0]["id"].ToString();            
            txtCdesc.Text = dt.Rows[0]["cdesc"].ToString();
            txtEdesc.Text = dt.Rows[0]["edesc"].ToString();
            txtCrusr.Text = dt.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dt.Rows[0]["amtim"].ToString();
        }
     
        private bool IsRepeat() //測試項目編號不允許有重覆
        {
            if (gridView1.RowCount < 2)
            {
                return false;
            }
            bool result = false;
            string strProcess_id = "";
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                strProcess_id = gridView1.GetRowCellDisplayText(i, "process_id");
                for (int j = i + 1; j <= gridView1.RowCount - 1; j++)
                {
                    if (strProcess_id == gridView1.GetRowCellDisplayText(j, "process_id"))
                    {
                        MessageBox.Show("工序編號不可以有重覆!\n\n" + string.Format("【{0}】", strProcess_id), 
                                                  myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
      

        private void txtPrd_dep_Leave(object sender, EventArgs e)
        {            
            Find_doc();     
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            Find_doc();
        }

        private void Find_doc()
        {
            string strid = "";
            if (txtID.Text == "__-__-_-_" || txtID.Text == "")
            {
                strid = "";
            }
            else
            {
                strid = txtID.Text.ToUpper();
            }
            
            if (!String.IsNullOrEmpty(strid) && !String.IsNullOrEmpty(txtPrd_dep.Text))
            {
                if (mState == "")
                {
                    Find_doc(txtPrd_dep.EditValue.ToString(), txtID.Text);
                }
            }
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.Rows.Count > 0)
            {                
                Find_doc(dgvFind.CurrentRow.Cells["dept_id"].Value.ToString(), dgvFind.CurrentRow.Cells["process_group_id"].Value.ToString());
            }
        }

        private void txtProcess_id1_Leave(object sender, EventArgs e)
        {
            txtProcess_id2.Text = txtProcess_id1.Text;
        }

        private void txtPrd_dep_Click(object sender, EventArgs e)
        {
            txtPrd_dep.SelectAll();
        }

    }
}
