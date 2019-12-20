//**********************************
// QC測試報告
// Author: Allen Leung 
// Date:   2019-03-25
//**********************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using cf01.ReportForm;
using System.Data.SqlClient;
using cf01.MDL;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmQcTestReport: Form
    {
        public string m_ID = "";    //臨時的主鍵值
        public string m_State = ""; //新增或編輯的狀態
        public string m_language = "0";       
        public bool m_save_flag;      

        DataTable dtMostly = new DataTable();
        DataTable dtDetails = new DataTable();
        DataTable dtDetails_result = new DataTable();
        DataTable dtTempDel = new DataTable();
        DataTable dtFind = new DataTable();

        private clsAppPublic clsApp = new clsAppPublic();
        
        public frmQcTestReport()
        {
            InitializeComponent();
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar(); 
  
            clsApp.Initialize_find_value(this.Name, this.panel2.Controls);
            m_language = DBUtility._language;

            //NextControl oNext = new NextControl(this, "2");
            //oNext.EnterToTab();
        }

        private void frmQcTestReport_Load(object sender, EventArgs e)
        {
            //客戶編號
            DataTable dtCust = clsCustComplain.GetCustomerData();
            luecustomer_id.Properties.DataSource = dtCust;
            luecustomer_id.Properties.ValueMember = "id";
            luecustomer_id.Properties.DisplayMember = "id";           

            //表結構
            dtMostly = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.qc_test_mostly Where 1=0");
            bdsMostly.DataSource = dtMostly;
            Set_Data_Binding();
            //明細表結構
            dtDetails = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.qc_test_details Where 1=0");
            bdsDetail.DataSource = dtDetails;
            gridControl1.DataSource = bdsDetail;
            //明細表結構2
            dtDetails_result = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.qc_test_details_result Where 1=0");
            bdsDetail_result.DataSource = dtDetails_result;
            gridControl2.DataSource = bdsDetail_result;

            DataTable dtItem_no = clsQcTestReport.GetProduct_Item_No();
            clItem_no.DataSource = dtItem_no;
            clItem_no.ValueMember = "cdesc";
            clItem_no.DisplayMember = "cdesc";

            DataTable dtTest_item_id = clsQcTestReport.GetTest_Item_No();
            clTest_item_id.DataSource = dtTest_item_id;
            clTest_item_id.ValueMember = "cdesc";
            clTest_item_id.DisplayMember = "cdesc";


            dtTempDel = dtDetails.Clone();

            if (dtDate1.Text == "")
            {                
                dtDate1.EditValue = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd").Substring(0, 10); 
            }
            if (dtDate2.Text == "")
            {
                dtDate2.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10); 
            }
            dgvFind.AutoGenerateColumns = false;
        }

        private void Set_Data_Binding()
        {
            //對象數據綁定
            txtID.DataBindings.Add("Text", bdsMostly, "id");
            dtcon_date.DataBindings.Add("EditValue", bdsMostly, "con_date");
            luecustomer_id.DataBindings.Add("EditValue", bdsMostly, "customer_id");
            txtcustomer_name.DataBindings.Add("Text", bdsMostly, "customer_name");
            txtcontact.DataBindings.Add("Text", bdsMostly, "contact");
            memremark.DataBindings.Add("Text", bdsMostly, "remark");

            txtCreate_by.DataBindings.Add("Text", bdsMostly, "create_by");
            txtCreate_date.DataBindings.Add("Text", bdsMostly, "create_date");
            txtupdate_by.DataBindings.Add("Text", bdsMostly, "update_by");
            txtupdate_date.DataBindings.Add("Text", bdsMostly, "update_date");
        }

        private void frmQcTestReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtTempDel.Dispose();
            dtFind.Dispose();
            dtDetails_result.Dispose();
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

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNITEMADD_Click(object sender, EventArgs e)
        {
            AddNew_Item();
        }

        private void BTNITEMDEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("確定要刪除當前行?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {                            
                //將當前行刪除幷加到臨時表中
                int curRow = dgvDetails.FocusedRowHandle;   
                DataRow dr = dtTempDel.NewRow();
                dr["id"] = txtID.Text;                
                dr["sequence_id"] = dgvDetails.GetRowCellDisplayText(curRow, "sequence_id");                
                dtTempDel.Rows.Add(dr);
                dgvDetails.DeleteRow(curRow);//移走當前行
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {            
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dgvFind.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataSet dts = BindRpt();             
            using (xrQcTestReport1 myRpt = new xrQcTestReport1(dts))
            {
                myRpt.CreateDocument();
                myRpt.PrintingSystem.ShowMarginsWarning = false;
                myRpt.ShowPreviewDialog();
            }

        }

        private DataSet BindRpt()
        {
            DataSet ds = clsQcTestReport.GetReportData(txtID.Text);
            ds.Tables[0].TableName = "dtMostly";
            ds.Tables[1].TableName = "dtDetails1";
            ds.Tables[2].TableName = "dtDetails2";
            ////给数据集建立主外键关系（主从表）
            //DataColumn ParentColumn = ds.Tables["dtMostly"].Columns["id"];
            //DataColumn ChildColumn1 = ds.Tables["dtDetails1"].Columns["id"];
            //DataColumn ChildColumn2 = ds.Tables["dtDetails2"].Columns["id"];
            //DataRelation Rel_1 = new DataRelation("RelationColumn", ParentColumn, ChildColumn1);
            //DataRelation Rel_2 = new DataRelation("RelationColumn2", ParentColumn, ChildColumn2);
            //ds.Relations.Add(Rel_1);
            //ds.Relations.Add(Rel_2);
            return ds;
        }

        private void SetButtonSatus(bool _flag) //設置工具欄
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
           
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            BTNITEMADD.Enabled = !_flag;            
            BTNITEMDEL.Enabled = !_flag;

            btnAdd1.Enabled = !_flag;
            btnDel1.Enabled = !_flag;

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private void AddNew()  //新增
        {
            m_State = "NEW";
            txtID.Focus();
            tabControl1.SelectTab(0);
            SetButtonSatus(false);
            Set_Grid_Status(true);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            SetObjValue.ClearObjValue(panel1.Controls, "1");            
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);
            dtcon_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            dtDetails.Clear();
            dtDetails_result.Clear();
            txtID.Text = clsQcTestReport.GetDocNo();
            bdsDetail.DataSource = dtDetails;           
            gridControl1.DataSource = bdsDetail;
            bdsDetail_result.DataSource = dtDetails_result;
            gridControl2.DataSource = bdsDetail_result;
        }

        private void Edit()  //編輯
        {
            if (txtID.Text == "")
            {
                return;
            }
            if (dgvDetails.RowCount == 0)
            {
                return;
            }           
            SetButtonSatus(false);
            tabControl1.SelectTab(0);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            Set_Grid_Status(true);
            m_State = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;            
            luecustomer_id.Enabled = true;
            luecustomer_id.BackColor = Color.White;            
        }

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            DialogResult result = MessageBox.Show("確定要刪除當前資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string ls_id_delete = txtID.Text;
                const string sql_del = "Update dbo.qc_test_mostly Set state='2',update_by=@user_id,update_date=getdate() WHERE id=@id";               
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交                       
                        SetObjValue.ClearObjValue(this.panel1.Controls, "1");
                        dtMostly.Clear();
                        dtDetails.Clear();
                        clsUtility.myMessageBox("數據刪除成功！", "提示信息");
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                        myCon.Dispose();
                        myTrans.Dispose();
                    }
                }

                //移走表格中已刪除的記錄
                //应该采用倒序循环刪除,因为正序删除时索引会发生变化
                for (int i = dgvFind.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgvFind.Rows[i].Cells["id1"].Value.ToString() == ls_id_delete)
                    {
                        dtFind.Rows.RemoveAt(i);
                    }
                }               
            }            
        }

        private void AddNew_Item()
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
            {
                if (Check_Details_Valid())
                {
                    return;
                }                
                Set_Grid_Status(true);

                using (frmQcTestReport_Add_List1 ofrm= new frmQcTestReport_Add_List1("1") )
                {
                    ofrm.ShowDialog();                    
                    if (ofrm.m_item_list.Count > 0)
                    {
                        foreach (string ls_item_no in ofrm.m_item_list)
                        {
                            dgvDetails.AddNewRow();//新增
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount).ToString("000"));
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "item_no", ls_item_no);
                        }
                        SetFocuse(dgvDetails, dgvDetails.FocusedRowHandle, "item_no"); //重定位到新增行并定位焦點單元格
                    }       
                } 
                
            }
            else
            {
                MessageBox.Show("編號不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
            }
        }

        private bool Check_Details_Valid() //檢查明細資料的有效性
        {
            //必須有輸入
            bool _flag = false;
            if (dgvDetails.RowCount > 0)
            {
                memremark.Focus();                
                int curRow = 0;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    curRow = dgvDetails.GetRowHandle(i);
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "item_no")))
                    {
                        _flag = true;
                        MessageBox.Show("產品測試項目列表不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetFocuse(dgvDetails, curRow, "item_no");
                        break;
                    }
                }
            }
            return _flag;
        }

        private void Set_Grid_Status(bool _flag) // 表格可編號否
        {
            //false--不可編輯;true--可以編輯
            dgvDetails.OptionsBehavior.Editable = _flag;
            dgvDetails_result.OptionsBehavior.Editable = _flag;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "2");
            Set_Grid_Status(false);
            dtTempDel.Clear();
            bdsMostly.CancelEdit();//取消數據綁定            
            bdsDetail.CancelEdit();
            bdsDetail_result.CancelEdit();
            dtDetails.RejectChanges();
            dtDetails_result.RejectChanges();
                     
            m_State = "";
            if (!String.IsNullOrEmpty(m_ID))
            {               
                Find_doc(m_ID);
            }            
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;            
            //luecustomer_id.Enabled  = true;
            //luecustomer_id.BackColor = Color.White;            
        }

        private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                //主表
                string ls_sql_h = String.Format(@"SELECT * FROM dbo.qc_test_mostly with(nolock) WHERE id ='{0}' AND state<>'2'", temp_id);
                //明細表1
                string ls_sql_d1 = String.Format(
                @"SELECT b.id,b.sequence_id,b.item_no,b.contents,b.details_remark
                FROM dbo.qc_test_mostly a with(nolock) 
                Inner join dbo.qc_test_details b with(nolock) on a.id=b.id                
                WHERE a.id='{0}' and a.state<>'2'", temp_id);
                //明細表2
                string ls_sql_d2 = String.Format(
                @"SELECT b.id,b.sequence_id,b.test_item_id,b.test_require,b.test_result,b.test_is_pass,b.details_remark2
                FROM dbo.qc_test_mostly a with(nolock) 
                INNER JOIN dbo.qc_test_details_result b with(nolock) on a.id=b.id                
                WHERE a.id='{0}' and a.state<>'2'", temp_id);

                dtMostly = clsPublicOfCF01.GetDataTable(ls_sql_h);
                dtDetails = clsPublicOfCF01.GetDataTable(ls_sql_d1);
                dtDetails_result = clsPublicOfCF01.GetDataTable(ls_sql_d2);
                bdsMostly.DataSource = dtMostly;                
                bdsDetail.DataSource = dtDetails;
                bdsDetail_result.DataSource = dtDetails_result;
                m_ID = txtID.Text; //保存臨時的ID
            }
        }


        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            //if (m_State == "NEW")
            //{
            //    txtID.Text = clsQcTestReport.GetDocNo();
            //}
            if (txtID.Text == "" || luecustomer_id.Text == "" || dtcon_date.Text =="" )
            {
                MessageBox.Show("注意:藍色字欄位資料不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Save()
        {            
            if (!Save_Before_Valid())
            {
                return;
            }
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("明細資料不可為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                SetFocuse(dgvDetails, 0, "item_no"); //重定位到新增行并定位焦點單元格,相當于刷新數據，使數據立即生效               
            }
            bool check_details_flag = true;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetRowCellValue(i, "item_no").ToString() == "")
                {
                    check_details_flag = false;
                    MessageBox.Show("產品項目列表不可為空!", "提示信息"); ;
                    dgvDetails.Focus();
                    break;
                }
            }
            if (!check_details_flag)
            {
                return;
            }

            m_save_flag = false;
            //新增主表
            const string sql_insert =
            @"INSERT INTO dbo.qc_test_mostly(id,con_date,customer_id,customer_name,contact,remark,state,create_by,create_date)            
			VALUES (@id,CASE LEN(@con_date) WHEN 0 THEN null ELSE @con_date END,@customer_id,@customer_name,@contact,@remark,'0',@user_id,getdate())";
            //更新主表
            const string sql_update =
            @"UPDATE dbo.qc_test_mostly 
            SET con_date=CASE LEN(@con_date) WHEN 0 THEN null ELSE @con_date END,customer_id=@customer_id,customer_name=@customer_name,
                contact=@contact,remark=@remark,update_by=@user_id,update_date=getdate()            
            Where id=@id";

            //新增明細表1
            const string sql_detail_insert =
            @"INSERT INTO dbo.qc_test_details(id,sequence_id,item_no,contents,details_remark) Values (@id,@sequence_id,@item_no,@contents,@details_remark)";
            //更新明細表1
            const string sql_detail_update =
            @"UPDATE dbo.qc_test_details SET item_no=@item_no,contents=@contents,details_remark=@details_remark WHERE id=@id and sequence_id=@sequence_id";

            //新增明細表2
            const string sql_detail_insert2 =
            @"INSERT INTO dbo.qc_test_details_result (id,sequence_id,test_item_id,test_require,test_result,test_is_pass,details_remark2) 
                Values(@id,@sequence_id,@test_item_id,@test_require,@test_result,@test_is_pass,@details_remark2)";
            //更新明細表2
            const string sql_detail_update2 =
            @"UPDATE dbo.qc_test_details_result
            SET test_item_id=@test_item_id,test_require=@test_require,test_result=@test_result,test_is_pass=@test_is_pass,details_remark2=@details_remark2 
            WHERE id=@id and sequence_id=@sequence_id";
            
            const string sql_item_d = @"DELETE FROM dbo.qc_test_details WHERE id=@id AND sequence_id=@sequence_id";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    if (m_State == "NEW")
                    {
                        if (clsQcTestReport.Valid_Doc(txtID.Text))
                        {
                            //新增的報價編號已存在時重新取值
                            txtID.Text = clsQcTestReport.GetDocNo();
                        }
                        myCommand.CommandText = sql_insert;
                    }
                    else
                    {
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    myCommand.Parameters.AddWithValue("@customer_id", luecustomer_id.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@customer_name", txtcustomer_name.Text);
                    myCommand.Parameters.AddWithValue("@con_date", dtcon_date.Text);
                    myCommand.Parameters.AddWithValue("@contact", dtcon_date.Text); 
                    myCommand.Parameters.AddWithValue("@remark", memremark.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);                   
                    myCommand.ExecuteNonQuery();

                    //處理明細表
                    //刪除明細資料
                    if (m_State == "EDIT")
                    {
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());                         
                            myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    //保存或新增明細資料
                    //dgvDetails.CloseEditor();
                    if (dgvDetails.RowCount > 0)
                    {
                        string ls_seq_id = "", rowStatus;                       
                        for (int i = 0; i < dtDetails.Rows.Count; i++)
                        {
                            rowStatus = dtDetails.Rows[i].RowState.ToString();
                            if (rowStatus == "Added" || rowStatus == "Modified")
                            {
                                myCommand.Parameters.Clear();
                                if (rowStatus == "Added")
                                {
                                    myCommand.CommandText = sql_detail_insert;
                                    //strSeq_id = Get_Details_Seq(txtID.Text.Trim()); //新增狀態重新取最大序號                           
                                }
                                if (rowStatus == "Modified")
                                {
                                    myCommand.CommandText = sql_detail_update;                                    
                                }
                                myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());//item_no,,
                                ls_seq_id = dtDetails.Rows[i]["sequence_id"].ToString();
                                myCommand.Parameters.AddWithValue("@sequence_id", ls_seq_id);
                                myCommand.Parameters.AddWithValue("@item_no", dtDetails.Rows[i]["item_no"].ToString());
                                myCommand.Parameters.AddWithValue("@contents", dtDetails.Rows[i]["contents"].ToString());
                                myCommand.Parameters.AddWithValue("@details_remark", dtDetails.Rows[i]["details_remark"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //保存或新增明細資料2
                    //dgvDetails_result.CloseEditor();
                    if (dgvDetails_result.RowCount > 0)
                    {
                        string ls_seq_id = "", rowStatus;
                        for (int i = 0; i < dtDetails_result.Rows.Count; i++)
                        {
                            rowStatus = dtDetails_result.Rows[i].RowState.ToString();
                            if (rowStatus == "Added" || rowStatus == "Modified")
                            {
                                myCommand.Parameters.Clear();
                                if (rowStatus == "Added")
                                {
                                    myCommand.CommandText = sql_detail_insert2;                                                    
                                }
                                if (rowStatus == "Modified")
                                {
                                    myCommand.CommandText = sql_detail_update2;
                                }
                                myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                ls_seq_id = dtDetails_result.Rows[i]["sequence_id"].ToString();
                                myCommand.Parameters.AddWithValue("@sequence_id", ls_seq_id);
                                myCommand.Parameters.AddWithValue("@test_item_id", dtDetails_result.Rows[i]["test_item_id"].ToString());
                                myCommand.Parameters.AddWithValue("@test_require", dtDetails_result.Rows[i]["test_require"].ToString());
                                myCommand.Parameters.AddWithValue("@test_result", dtDetails_result.Rows[i]["test_result"].ToString());
                                myCommand.Parameters.AddWithValue("@test_is_pass", dtDetails_result.Rows[i]["test_is_pass"].ToString()=="True"?true :false );
                                myCommand.Parameters.AddWithValue("@details_remark2", dtDetails_result.Rows[i]["details_remark2"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    myTrans.Commit(); //數據提交
                    m_save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    m_save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }

            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            Set_Grid_Status(false);
            m_State = "";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;
            dtTempDel.Clear();
           
            if (m_save_flag)
            {
                Find_doc(txtID.Text);                
                clsUtility.myMessageBox("資料保存成功！", "提示信息");
            }
            else
            {
                MessageBox.Show("資料保存失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }            
        }

        /// <summary>
        /// 設置某單元格獲得焦點
        /// </summary>
        /// <param name="view"></param>
        /// <param name="rowHandle"></param>
        /// <param name="columnName"></param>
        private static void SetFocuse(DevExpress.XtraGrid.Views.Grid.GridView dev_view, Int32 rowHandle, string columnName)
        {
            dev_view.Focus();
            dev_view.FocusedRowHandle = rowHandle;
            dev_view.FocusedColumn = dev_view.Columns[columnName];
            dev_view.ShowEditor();            
        }

        private void dgvDetails_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (dgvDetails.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = dgvDetails.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        } 
     
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (m_State != "")
            {
                return;
            }

            string dat1, dat2;
            if (dtDate1.Text != "")
                dat1 = Convert.ToDateTime(dtDate1.Text).ToString("yyyy/MM/dd");
            else
                dat1 = "";
            if (dtDate2.Text != "")
                dat2 = Convert.ToDateTime(dtDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            else
                dat2 = "";

            dtFind = clsQcTestReport.Find_Data(txtMo_id1.Text, dat1, dat2, txtId1.Text, txtId2.Text);
            dgvFind.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("無滿足查找條件的數據!", "提示信息");
            }
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.RowCount > 0)
            {
                if (txtID.Text != dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString())
                {
                    txtID.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString();
                    Find_doc(txtID.Text);                    
                }
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.panel2.Controls) > 0)
                clsUtility.myMessageBox("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void dtDate1_Leave(object sender, EventArgs e)
        {
            dtDate2.EditValue = dtDate1.EditValue;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void dgvDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }    
        }

        private void dgvDetails_result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (BTNSAVE.Selected == true)
            {
                memremark.Focus();
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            using (frmQcTestReport_Add_List1 ofrm = new frmQcTestReport_Add_List1("2"))
            {
                ofrm.ShowDialog();
                if (ofrm.m_item_list.Count > 0)
                {
                    foreach (string ls_item_no in ofrm.m_item_list)
                    {
                        dgvDetails_result.AddNewRow();//新增
                        dgvDetails_result.SetRowCellValue(dgvDetails_result.FocusedRowHandle, "id", txtID.Text);
                        dgvDetails_result.SetRowCellValue(dgvDetails_result.FocusedRowHandle, "sequence_id", (dgvDetails_result.RowCount).ToString("000"));
                        dgvDetails_result.SetRowCellValue(dgvDetails_result.FocusedRowHandle, "test_item_id", ls_item_no);
                    }
                    SetFocuse(dgvDetails_result, dgvDetails_result.FocusedRowHandle, "test_item_id"); //重定位到新增行并定位焦點單元格
                }
            }
        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            if (dgvDetails_result.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("確定要刪除當前測試項目?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = dgvDetails_result.FocusedRowHandle;
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@id",dgvDetails_result.GetRowCellValue(curRow, "id").ToString()),
                    new SqlParameter("@sequence_id",dgvDetails_result.GetRowCellValue(curRow, "sequence_id").ToString())
                };
                try
                {
                    clsPublicOfCF01.ExecuteNonQuery("Delete From dbo.qc_test_details_result Where id=@id And sequence_id=@sequence_id", paras, false);
                    dgvDetails_result.DeleteRow(curRow);//移走當前行
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvDetails_result_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (dgvDetails_result.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = dgvDetails_result.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }
        

    }
}
