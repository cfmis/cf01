//*************************************************
//**鈕部每日生產數工作記錄
//Create by: Allen Leung 2019-03-14
//*************************************************

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
    public partial class frmButtonWork: Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編輯的狀態
        public static string str_language = "0";
        public static string query_id;
        public bool save_flag;      
      

        DataTable dtMostly = new DataTable();
        DataTable dtDetails = new DataTable();
        DataTable dtTempDel = new DataTable();
        DataTable dtFind = new DataTable();

        private clsAppPublic clsApp = new clsAppPublic();
        
        public frmButtonWork()
        {
            InitializeComponent();
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();   
            clsApp.Initialize_find_value(this.Name, this.panel2.Controls); 
            
            str_language = DBUtility._language;

            //NextControl oNext = new NextControl(this, "2");
            //oNext.EnterToTab();
        }

        private void frmButtonWork_Load(object sender, EventArgs e)
        {
            //外發部門
            DataTable dtDept = clsButtonWork.GetDept();
            luedepartment_id.Properties.DataSource = dtDept;
            luedepartment_id.Properties.ValueMember = "id";
            luedepartment_id.Properties.DisplayMember = "cdesc";

            //表結構
            dtMostly = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.jo_button_work_mostly Where 1=0");
            bdsMostly.DataSource = dtMostly;
            Set_Data_Binding();
            dtDetails = clsPublicOfCF01.GetDataTable(
            @"Select id,sequence_id,group_type,Convert(varchar(10),work_date,120) as work_date,work_time_normal_s,work_time_normal_e,workers_normal,
            work_time_overtime_s,work_time_overtime_e,workers_overtime,running_machines,qty_total,details_remark
            FROM dbo.jo_button_work_details Where 1=0");
            bdsDetail.DataSource = dtDetails;
            gridControl1.DataSource = bdsDetail;
            dtTempDel = dtDetails.Clone();

            if (dtDate1.Text == "")
            {                
                dtDate1.EditValue = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd").Substring(0, 10); 
            }
            if (dtDate2.Text == "")
            {
                dtDate2.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10); 
            }
        }

        private void Set_Data_Binding()
        {
            //對象數據綁定
            txtID.DataBindings.Add("Text", bdsMostly, "id");
            dtcon_date.DataBindings.Add("EditValue", bdsMostly, "con_date");
            luedepartment_id.DataBindings.Add("EditValue", bdsMostly, "department_id");            
            memremark.DataBindings.Add("Text", bdsMostly, "remark");

            txtCreate_by.DataBindings.Add("Text", bdsMostly, "create_by");
            txtCreate_date.DataBindings.Add("Text", bdsMostly, "create_date");
            txtupdate_by.DataBindings.Add("Text", bdsMostly, "update_by");
            txtupdate_date.DataBindings.Add("Text", bdsMostly, "update_date");
        }

        private void frmButtonWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtTempDel.Dispose();
            dtFind.Dispose();
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

                ////移走查找面頁中的行
                //for (int i = dgvFind.Rows.Count - 1; i >= 0; i--)
                //{
                //    if (dgvFind.Rows[i].Cells["quotaion_id"].Value.ToString() == txtID.Text &&
                //        dgvFind.Rows[i].Cells["version_h"].Value.ToString() == txtVersion.Text &&
                //        dgvFind.Rows[i].Cells["seqno"].Value.ToString() == seq_id_del)
                //    {
                //        dtReport.Rows.RemoveAt(i);
                //    }
                //}
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

            using (xrButtonWork myRpt = new xrButtonWork() { DataSource = dtFind })
            {
                myRpt.CreateDocument();
                myRpt.PrintingSystem.ShowMarginsWarning = false;
                myRpt.ShowPreviewDialog();
            }

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

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            tabControl1.SelectTab(0);
            SetButtonSatus(false);
            Set_Grid_Status(true);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            SetObjValue.ClearObjValue(panel1.Controls, "1");            
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);            
            luedepartment_id.EditValue ="102";
            dtcon_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            dtDetails.Clear();
            bdsDetail.DataSource = dtDetails;           
            gridControl1.DataSource = bdsDetail;
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
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;            
            luedepartment_id.Enabled = true;
            luedepartment_id.BackColor = Color.White;            
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
                const string sql_del = "Update dbo.jo_button_work_mostly Set state='2',update_by=@user_id,update_date=getdate() WHERE id=@id";               
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
                dgvDetails.AddNewRow();//新增
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount).ToString("000"));
                SetFocuse(dgvDetails, dgvDetails.FocusedRowHandle, "group_type"); //重定位到新增行并定位焦點單元格
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
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "group_type")))
                    {
                        _flag = true;
                        MessageBox.Show("車間組別或工種不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetFocuse(dgvDetails, curRow, "group_type");
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
            dtDetails.RejectChanges();
                     
            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {               
                Find_doc(mID);
            }
            
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;            
            luedepartment_id.Enabled  = true;
            luedepartment_id.BackColor = Color.White;            
        }

        private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                //主表
                string sql_h = String.Format(@"SELECT * FROM dbo.jo_button_work_mostly with(nolock) WHERE id ='{0}' AND state<>'2'", temp_id);
                //明細表
                string sql_d2 = String.Format(
                @"SELECT b.id,b.sequence_id,b.group_type,convert(varchar(10),b.work_date,120) as work_date,b.work_time_normal_s,b.work_time_normal_e,b.workers_normal,
                b.work_time_overtime_s,b.work_time_overtime_e,b.workers_overtime,b.running_machines,b.qty_total,b.details_remark
                FROM dbo.jo_button_work_mostly a with(nolock) 
                Inner join dbo.jo_button_work_details b with(nolock) on a.id=b.id                
                WHERE a.id='{0}' and a.state<>'2'", temp_id);

                dtMostly = clsPublicOfCF01.GetDataTable(sql_h);                
                dtDetails = clsPublicOfCF01.GetDataTable(sql_d2);
                bdsMostly.DataSource = dtMostly;                
                bdsDetail.DataSource = dtDetails;
                mID = txtID.Text; //保存臨時的ID
            }
        }


        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (mState == "NEW")
            {
                txtID.Text = clsButtonWork.GetDocNo(luedepartment_id.EditValue.ToString());
            }
            if (txtID.Text == "" || luedepartment_id.Text == "" )
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
                SetFocuse(dgvDetails, 0, "group_type"); //重定位到新增行并定位焦點單元格,相當于刷新數據，使數據立即生效               
            }
            bool check_details_flag = true;                       
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetRowCellValue(i, "group_type").ToString() == "")
                {
                    check_details_flag = false;
                    MessageBox.Show("車間、組別或工種不可為空!", "提示信息"); ;
                    dgvDetails.Focus();
                    break;
                }
            }
            if (!check_details_flag)
            {
                return;
            }

            save_flag = false;
            //新增主表
            const string sql_insert =
            @"INSERT INTO dbo.jo_button_work_mostly(id,con_date,department_id,remark,create_by,create_date)            
			VALUES (@id,CASE LEN(@con_date) WHEN 0 THEN null ELSE @con_date END,@department_id,@remark,@user_id,getdate())";
            //更新主表
            const string sql_update =
            @"UPDATE dbo.jo_button_work_mostly 
            SET department_id=@department_id,con_date=CASE LEN(@con_date) WHEN 0 THEN null ELSE @con_date END,
                remark=@remark,update_by=@user_id,update_date=getdate()            
            Where id=@id";

            //新增明細表
            const string sql_detail_insert =
            @"INSERT INTO dbo.jo_button_work_details(
             id,sequence_id,group_type,work_date,work_time_normal_s,work_time_normal_e,workers_normal,work_time_overtime_s,work_time_overtime_e,
             workers_overtime,running_machines,qty_total,details_remark)
            Values(@id,@sequence_id,@group_type,CASE LEN(@work_date) WHEN 0 THEN null ELSE @work_date END,
            @work_time_normal_s,@work_time_normal_e,@workers_normal,@work_time_overtime_s,@work_time_overtime_e,@workers_overtime,@running_machines,@qty_total,@details_remark)";
            //更新明細表
            const string sql_detail_update =
            @"UPDATE dbo.jo_button_work_details
            SET group_type=@group_type,work_date=CASE LEN(@work_date) WHEN 0 THEN null ELSE @work_date END,
            work_time_normal_s=@work_time_normal_s,work_time_normal_e=@work_time_normal_e,workers_normal=@workers_normal,work_time_overtime_s=@work_time_overtime_s,work_time_overtime_e=@work_time_overtime_e,workers_overtime=@workers_overtime,
            running_machines=@running_machines,qty_total=@qty_total,details_remark=@details_remark
            WHERE id=@id and sequence_id=@sequence_id";
            const string sql_item_d = @"DELETE FROM dbo.jo_button_work_details WHERE id=@id AND sequence_id=@sequence_id";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    if (mState == "NEW")
                    {
                        if (clsButtonWork.Valid_Doc(txtID.Text))
                        {
                            //新增的報價編號已存在時重新取值
                            txtID.Text = clsButtonWork.GetDocNo(luedepartment_id.EditValue.ToString());
                        }
                        myCommand.CommandText = sql_insert;
                    }
                    else
                    {
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    myCommand.Parameters.AddWithValue("@department_id", luedepartment_id.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@con_date", dtcon_date.Text);                    
                    myCommand.Parameters.AddWithValue("@remark", memremark.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);                   
                    myCommand.ExecuteNonQuery();

                    //處理明細表
                    //刪除明細資料
                    if (mState == "EDIT")
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
                        string strSeq_id = "",rowStatus;                       
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
                                    //strSeq_id = dtDetails.Rows[i]["sequence_id"].ToString();//編輯狀態原序號保持不變
                                }                                
                                myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                strSeq_id=dtDetails.Rows[i]["sequence_id"].ToString();
                                myCommand.Parameters.AddWithValue("@sequence_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@group_type", dtDetails.Rows[i]["group_type"].ToString());
                                myCommand.Parameters.AddWithValue("@work_date", clsApp.Return_String_Date(dtDetails.Rows[i]["work_date"].ToString()));
                                myCommand.Parameters.AddWithValue("@work_time_normal_s", dtDetails.Rows[i]["work_time_normal_s"].ToString());                               
                                myCommand.Parameters.AddWithValue("@work_time_normal_e", dtDetails.Rows[i]["work_time_normal_e"].ToString());
                                myCommand.Parameters.AddWithValue("@workers_normal", dtDetails.Rows[i]["workers_normal"].ToString());
                                myCommand.Parameters.AddWithValue("@work_time_overtime_s", dtDetails.Rows[i]["work_time_overtime_s"].ToString());
                                myCommand.Parameters.AddWithValue("@work_time_overtime_e", dtDetails.Rows[i]["work_time_overtime_e"].ToString());
                                myCommand.Parameters.AddWithValue("@workers_overtime", dtDetails.Rows[i]["workers_overtime"].ToString());
                                myCommand.Parameters.AddWithValue("@running_machines", dtDetails.Rows[i]["running_machines"].ToString());                                
                                myCommand.Parameters.AddWithValue("@qty_total", string.IsNullOrEmpty(dtDetails.Rows[i]["qty_total"].ToString()) ? 0 : Int32.Parse(dtDetails.Rows[i]["qty_total"].ToString()));                           
                                myCommand.Parameters.AddWithValue("@details_remark", dtDetails.Rows[i]["details_remark"].ToString());
                                                           
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
                    myTrans.Dispose();
                }
            }

            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            Set_Grid_Status(false);
            mState = "";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;            
            luedepartment_id.Enabled = true;
            luedepartment_id.BackColor = Color.White;                   
            dtTempDel.Clear();
           
            if (save_flag)
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
      
        private void SetId()
        {
            if (mState != "NEW")
            {
                return;
            }
            if (luedepartment_id.Text != "" )
            {
                txtID.Text = clsButtonWork.GetDocNo(luedepartment_id.EditValue.ToString());
            }
        }

        private void luedepartment_id_EditValueChanged(object sender, EventArgs e)
        {
            SetId();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mState != "")
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

            dtFind = clsButtonWork.Find_Data(txtDept1.Text, txtDept2.Text, dat1, dat2, txtId1.Text, txtId2.Text);
            dgvFind.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查找條件的數據!", "提示信息");
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

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.Text = txtDept1.Text;
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

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (BTNSAVE.Selected == true)
            {
                memremark.Focus();
            }
        }
        

    }
}
