//*************************************************
//**電鍍部補料申請單
//Create by: Allen Leung 2019-02-20
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
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmProductionRepair : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編輯的狀態
        public static string str_language = "0";
        public static string query_id;
        public bool save_flag;      
      

        DataTable dtMostly = new DataTable();
        DataTable dtDetails = new DataTable();
        DataTable dtTempDel = new DataTable();      

        private clsAppPublic clsApp = new clsAppPublic();
        
        public frmProductionRepair()
        {
            InitializeComponent();
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();            
            str_language = DBUtility._language;
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
        }

        private void frmProductionRepair_Load(object sender, EventArgs e)
        {
            //外發部門
            DataTable dtDept = clsMoRepair.GetDept();
            luedepartment_id.Properties.DataSource = dtDept;
            luedepartment_id.Properties.ValueMember = "id";
            luedepartment_id.Properties.DisplayMember = "cdesc";

            //外發供應商
            DataTable dtVendor_id = clsMoRepair.GetVendor();
            luevendor_id.Properties.DataSource = dtVendor_id;
            luevendor_id.Properties.ValueMember = "id";
            luevendor_id.Properties.DisplayMember = "cdesc";

            //補單原因
            DataTable dtReasonRepair = clsMoRepair.GetReasonRepair();
            clReason_repair.DataSource = dtReasonRepair;
            clReason_repair.ValueMember = "cdesc";
            clReason_repair.DisplayMember = "cdesc";
            
            //表結構
            dtMostly = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.jo_pp_repair_mostly Where 1=0");
            bdsMostly.DataSource = dtMostly;
            Set_Data_Binding();
            dtDetails = clsPublicOfCF01.GetDataTable(@"Select *,details_remark as goods_name FROM dbo.jo_pp_repair_details Where 1=0");
            bdsDetail.DataSource = dtDetails;
            gridControl1.DataSource = bdsDetail;
            dtTempDel = dtDetails.Clone();

        }

        private void Set_Data_Binding()
        {
            //對象數據綁定
            txtID.DataBindings.Add("Text", bdsMostly, "id");
            dtorder_date.DataBindings.Add("EditValue", bdsMostly, "order_date");
            luedepartment_id.DataBindings.Add("EditValue", bdsMostly, "department_id");
            luevendor_id.DataBindings.Add("EditValue", bdsMostly, "vendor_id");
            txtlister_by.DataBindings.Add("Text", bdsMostly, "lister_by");
            memremark.DataBindings.Add("Text", bdsMostly, "remark");

            txtCreate_by.DataBindings.Add("Text", bdsMostly, "create_by");
            txtCreate_date.DataBindings.Add("Text", bdsMostly, "create_date");
            txtupdate_by.DataBindings.Add("Text", bdsMostly, "update_by");
            txtupdate_date.DataBindings.Add("Text", bdsMostly, "update_date");
        }     


        private void frmProductionRepair_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtTempDel.Dispose();
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
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            DataTable dtReport = clsMoRepair.Find_Data_By_Mo(txtID.Text);
            using (xrProductionRepair_mo myRpt = new xrProductionRepair_mo() { DataSource = dtReport })
            {
                myRpt.CreateDocument();
                myRpt.PrintingSystem.ShowMarginsWarning = false;
                myRpt.ShowPreviewDialog();
            }

        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {           
            if (mState !="")
            {               
               return;
            }

            frmProductionRepair_Find frmFind = new frmProductionRepair_Find();
            frmFind.ShowDialog();
            frmFind.Dispose();
            if (query_id != "")
            {
                Find_doc(query_id);
            }
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

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
        
            SetButtonSatus(false);
            Set_Grid_Status(true);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            SetObjValue.ClearObjValue(panel1.Controls, "1");            
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);
            //txtID.Text =clsMoRepair.GetDocNo();
            luedepartment_id.EditValue ="501";
            dtorder_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
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

            SetObjValue.SetEditBackColor(panel1.Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;            
            luedepartment_id.Enabled = true;
            luedepartment_id.BackColor = Color.White;
            luevendor_id.Enabled = true;
            luevendor_id.BackColor = Color.White;

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
                const string sql_del = "Update dbo.jo_pp_repair_mostly Set sate='2',update_by=@user_id,update_date=getdate() WHERE id=@id";               
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
                        bdsMostly.Clear();                        
                        bdsDetail.Clear();                        
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
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "currency_id", "HKD");
                SetFocuse(dgvDetails, dgvDetails.FocusedRowHandle, "mo_id"); //重定位到新增行并定位焦點單元格
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
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "mo_id")) || String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "ref_id")))
                    {
                        _flag = true;
                        MessageBox.Show("頁數或外發加工單編號不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        SetFocuse(dgvDetails, curRow, "mo_id");
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
            dtorder_date.Enabled = true;
            dtorder_date.BackColor = Color.White;
            luedepartment_id.Enabled  = true;
            luedepartment_id.BackColor = Color.White;
            luevendor_id.Enabled = true;
            luevendor_id.BackColor = Color.White;
        }

        private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                //主表
                string sql_h = String.Format(@"SELECT * FROM dbo.jo_pp_repair_mostly with(nolock) WHERE id ='{0}' AND state<>'2'", temp_id);
                //明細表
                string sql_d2 = String.Format(
                @"SELECT b.*,c.name as goods_name
                FROM dbo.jo_pp_repair_mostly a with(nolock) 
                Inner join dbo.jo_pp_repair_details b with(nolock) on a.id=b.id
                Inner join dbo.geo_it_goods c with(nolock) on b.goods_id=c.id
                WHERE a.id=b.id and a.id='{0}' and a.state<>'2'", temp_id);

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
                txtID.Text = clsMoRepair.GetDocNo(luevendor_id.EditValue.ToString());
            }
            if (txtID.Text == "" || dtorder_date.Text == "" || luedepartment_id.Text == "" || luevendor_id.Text =="")
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
                SetFocuse(dgvDetails, 0, "mo_id"); //重定位到新增行并定位焦點單元格,相當于刷新數據，使數據立即生效
                //SetFocuse(dgvDetails, dgvDetails.RowCount-1, "mo_id");
            }
            bool check_details_flag = true;                       
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetRowCellValue(i, "mo_id").ToString() == "" || dgvDetails.GetRowCellValue(i, "ref_id").ToString() == "")
                {
                    check_details_flag = false;
                    MessageBox.Show("明細資料中的頁數或外發加工單編號不可為空!", "提示信息"); ;
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
            @"INSERT INTO dbo.jo_pp_repair_mostly(id,department_id,order_date,vendor_id,vendor_name,remark,lister_by,state,create_by,create_date)            
			VALUES (@id,@department_id,CASE LEN(@order_date) WHEN 0 THEN null ELSE @order_date END,@vendor_id,@vendor_name,@remark,@lister_by,'0',@user_id,getdate())";
            //更新主表
            const string sql_update =
            @"UPDATE dbo.jo_pp_repair_mostly 
            SET department_id=@department_id,order_date=CASE LEN(@order_date) WHEN 0 THEN null ELSE @order_date END,
                vendor_id=@vendor_id,vendor_name=@vendor_name,remark=@remark,lister_by=@lister_by,update_by=@user_id,update_date=getdate()            
            Where id=@id";

            //新增明細表
            const string sql_detail_insert =
            @"INSERT INTO dbo.jo_pp_repair_details(id,sequence_id,mo_id,ref_id,ref_id_date,goods_id,do_color,qty,sec_qty,amt_deduction,currency_id,reason_repair,details_remark,is_deduct_amount,is_ac_deduct,ac_bill_id)
            Values(@id,@sequence_id,@mo_id,@ref_id,CASE LEN(@ref_id_date) WHEN 0 THEN null ELSE @ref_id_date END,
            @goods_id,@do_color,@qty,@sec_qty,@amt_deduction,@currency_id,@reason_repair,@details_remark,@is_deduct_amount,@is_ac_deduct,@ac_bill_id)";
            //更新明細表
            const string sql_detail_update =
            @"UPDATE dbo.jo_pp_repair_details
            SET mo_id=@mo_id,ref_id=@ref_id,ref_id_date=CASE LEN(@ref_id_date) WHEN 0 THEN null ELSE @ref_id_date END,
            goods_id=@goods_id,do_color=@do_color,qty=@qty,sec_qty=@sec_qty,amt_deduction=@amt_deduction,currency_id=@currency_id,reason_repair=@reason_repair,details_remark=@details_remark,is_deduct_amount=@is_deduct_amount,
            is_ac_deduct=@is_ac_deduct,ac_bill_id=@ac_bill_id 
            WHERE id=@id and sequence_id=@sequence_id";
            const string sql_item_d = @"DELETE FROM dbo.jo_pp_repair_details WHERE id=@id AND sequence_id=@sequence_id";

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
                        if (clsMoRepair.Valid_Doc(txtID.Text))
                        {
                            //新增的報價編號已存在時重新取值
                            txtID.Text = clsMoRepair.GetDocNo(luevendor_id.EditValue.ToString());
                        }
                        myCommand.CommandText = sql_insert;
                    }
                    else
                    {
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    myCommand.Parameters.AddWithValue("@department_id", luedepartment_id.EditValue);
                    myCommand.Parameters.AddWithValue("@order_date", dtorder_date.Text);
                    myCommand.Parameters.AddWithValue("@vendor_id", luevendor_id.EditValue);
                    myCommand.Parameters.AddWithValue("@vendor_name", luevendor_id.Text.Substring(10));
                    myCommand.Parameters.AddWithValue("@lister_by", txtlister_by.Text);
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
                    if (dgvDetails.RowCount > 0)
                    {
                        string strSeq_id = "",rowStatus;
                        bool is_deduct_amount, is_ac_deduct;
                        //dgvDetails.CloseEditor();
                        bdsDetail.EndEdit();
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
                                myCommand.Parameters.AddWithValue("@sequence_id", dtDetails.Rows[i]["sequence_id"].ToString());
                                myCommand.Parameters.AddWithValue("@mo_id", dtDetails.Rows[i]["mo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@ref_id", dtDetails.Rows[i]["ref_id"].ToString());
                                myCommand.Parameters.AddWithValue("@ref_id_date", clsApp.Return_String_Date(dtDetails.Rows[i]["ref_id_date"].ToString()));
                                myCommand.Parameters.AddWithValue("@goods_id", dtDetails.Rows[i]["goods_id"].ToString());
                                myCommand.Parameters.AddWithValue("@do_color", dtDetails.Rows[i]["do_color"].ToString());
                                myCommand.Parameters.AddWithValue("@qty",string.IsNullOrEmpty(dtDetails.Rows[i]["qty"].ToString())?0:int.Parse(dtDetails.Rows[i]["qty"].ToString()));
                                myCommand.Parameters.AddWithValue("@sec_qty", clsApp.Return_Float_Value(dtDetails.Rows[i]["sec_qty"].ToString()));//重量
                                myCommand.Parameters.AddWithValue("@amt_deduction", clsApp.Return_Float_Value(dtDetails.Rows[i]["amt_deduction"].ToString()));//扣款金額
                                myCommand.Parameters.AddWithValue("@currency_id", dtDetails.Rows[i]["currency_id"].ToString());                                
                                myCommand.Parameters.AddWithValue("@reason_repair", dtDetails.Rows[i]["reason_repair"].ToString());
                                myCommand.Parameters.AddWithValue("@details_remark", dtDetails.Rows[i]["details_remark"].ToString());
                               
                                if (dtDetails.Rows[i]["is_deduct_amount"].ToString() == "True")
                                    is_deduct_amount = true;
                                else
                                    is_deduct_amount = false;
                                myCommand.Parameters.AddWithValue("@is_deduct_amount", is_deduct_amount);
                                //會計部是否已購款
                                if (dtDetails.Rows[i]["is_ac_deduct"].ToString() == "True")
                                    is_ac_deduct = true;
                                else
                                    is_ac_deduct = false;
                                myCommand.Parameters.AddWithValue("@is_ac_deduct", is_ac_deduct);
                                myCommand.Parameters.AddWithValue("@ac_bill_id", dtDetails.Rows[i]["ac_bill_id"].ToString());
                                                               
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
            dtorder_date.Enabled = true;
            dtorder_date.BackColor = Color.White;
            luedepartment_id.Enabled = true;
            luedepartment_id.BackColor = Color.White;
            luevendor_id.Enabled = true;
            luevendor_id.BackColor = Color.White;          
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


        private void clMo_id_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                dgvDetails.CloseEditor();
                string ls_mo_id, ls_vendor_id;
                ls_mo_id = dgvDetails.GetRowCellDisplayText(dgvDetails.FocusedRowHandle, "mo_id");
                ls_vendor_id = luevendor_id.EditValue.ToString();
                if (!string.IsNullOrEmpty(ls_mo_id))
                {
                    string ls_sql = string.Format(
                    @"SELECT A.id,convert(varchar(10),A.issue_date,120) as issue_date,B.goods_id,convert(int,B.prod_qty) as prod_qty,B.sec_qty,
                    Round(convert(float,B.total_prices),2) as total_prices,C.name as goods_name,C.do_color                    
                    FROM dgerp2.cferp.dbo.op_outpro_out_mostly A with(nolock) 
	                    INNER JOIN dgerp2.cferp.dbo.op_outpro_out_displace B with(nolock) ON A.within_code=B.within_code And A.id=B.id
	                    INNER JOIN dgerp2.cferp.dbo.it_goods C with(nolock) ON B.within_code=C.within_code and B.goods_id=C.id
                    WHERE A.vendor_id='{0}' and A.state NOT IN ('0','2') and B.mo_id='{1}'
                    Order by A.issue_date,A.id", ls_vendor_id,ls_mo_id);
                    DataTable dtOutpro_out = clsPublicOfCF01.GetDataTable(ls_sql);
                    clGoods_id.DataSource = dtOutpro_out;
                    clGoods_id.DisplayMember = "goods_id";
                    clGoods_id.ValueMember = "goods_id";

                    if (dtOutpro_out.Rows.Count == 0)
                    {
                        MessageBox.Show("無效的頁數資料!", "提示信息");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_id", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_id_date", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "do_color", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_qty", 0);
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "qty", 0);
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "amt_deduction", 0);
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "reason_repair", "");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "details_remark", "");                        
                        SetFocuse(dgvDetails, dgvDetails.FocusedRowHandle, "mo_id");
                    }
                    else
                    {
                        if (dtOutpro_out.Rows.Count == 1)
                        {
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_id", dtOutpro_out.Rows[0]["id"].ToString());
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_id_date", dtOutpro_out.Rows[0]["issue_date"].ToString());
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", dtOutpro_out.Rows[0]["goods_id"].ToString());
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", dtOutpro_out.Rows[0]["goods_name"].ToString());
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "do_color", dtOutpro_out.Rows[0]["do_color"].ToString());
                        }
                    }
                }
            }
        }
      
        private void SetId()
        {
            if (mState != "NEW")
            {
                return;
            }
            if (luedepartment_id.Text != "" && luevendor_id.Text != "")
            {                
                txtID.Text = clsMoRepair.GetDocNo(luevendor_id.EditValue.ToString());
            }
        }

        private void luevendor_id_EditValueChanged(object sender, EventArgs e)
        {
            SetId();          
        }

        private void luedepartment_id_EditValueChanged(object sender, EventArgs e)
        {
            SetId();
        }

        private void clGoods_id_EditValueChanged(object sender, EventArgs e)
        {          
            LookUpEdit objItem = (LookUpEdit)sender;
            string ls_id, ls_order_date, ls_goods_id,ls_goods_name,ls_do_color;
            ls_goods_id = objItem.EditValue.ToString();
            int indexSelect = clGoods_id.GetDataSourceRowIndex("goods_id", ls_goods_id);
            ls_order_date = clGoods_id.GetDataSourceValue("issue_date", indexSelect).ToString();
            ls_id = clGoods_id.GetDataSourceValue("id", indexSelect).ToString();
            ls_goods_name = clGoods_id.GetDataSourceValue("goods_name", indexSelect).ToString();
            ls_do_color = clGoods_id.GetDataSourceValue("do_color", indexSelect).ToString();
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_id_date", ls_order_date);
            //dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", ls_goods_id);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_id", ls_id);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", ls_goods_name);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "do_color", ls_do_color);


            
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (mState != "")
            {
                txtID.Focus();
            }
        }

        private void clIs_ac_deduct_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "is_deduct_amount").ToString() == "False")
            {
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_ac_deduct", false);
                clsUtility.myMessageBox("注意：外發電鍍部需首先要勾上需扣除電鍍費！", "提示信息");               
            }
        }

     



    }
}
