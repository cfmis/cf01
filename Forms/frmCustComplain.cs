//*************************************************
//**客戶投訴資料 可取制單更改中的異常單作數據源，也可手動自由輸入
//Create by: Allen Leung 2019-01-15
//*************************************************
/*
 * Create Date:2019-01-10
 * Create by Allen Leung
 * 程序備註：
 *  客戶投訴資料
 * 1、可從GEO客戶異常單中帶出資料，導出
 * 2、QC部門可自己錄入資料
*/
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
    public partial class frmCustComplain : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編輯的狀態
        public static string str_language = "0";
        public static string query_id;
        public bool save_flag;
      

        DataTable dtMostly = new DataTable();
        DataTable dtDetails = new DataTable();
        DataTable dtDeptResponsible = new DataTable();
        DataTable dtTempDel = new DataTable();      

        private clsAppPublic clsApp = new clsAppPublic();
        
        public frmCustComplain()
        {
            InitializeComponent();
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();            
            str_language = DBUtility._language;
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
        }

        private void frmCustComplain_Load(object sender, EventArgs e)
        {
            DataTable dtCust = clsCustComplain.GetCustomerData();
            luecustomer_id.Properties.DataSource = dtCust;
            luecustomer_id.Properties.ValueMember = "id";
            luecustomer_id.Properties.DisplayMember = "id";
            //營業員
            DataTable dtSeller = clsCustComplain.GetSellerData();
            lueseller_id.Properties.DataSource = dtSeller;
            lueseller_id.Properties.ValueMember = "id";
            lueseller_id.Properties.DisplayMember = "cdesc";

            //責任部門
            DataTable dtDept = clsCustComplain.GetComplainDept(); 
            clDepartment.DataSource = dtDept;
            clDepartment.ValueMember = "id";
            clDepartment.DisplayMember = "id";

            DataTable dtUnit = clsCustComplain.GetUnit();
            clUnit_code.DataSource = dtUnit;
            clUnit_code.ValueMember = "id";
            clUnit_code.DisplayMember = "id";

            //原因分類
            DataTable dtPerson = clsCustComplain.GetPersonType();
            luereason_type.Properties.DataSource = dtPerson;
            luereason_type.Properties.ValueMember = "person_type";
            luereason_type.Properties.DisplayMember = "person_type";
            
            
            //表結構
            dtMostly = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.so_cust_complain_mostly Where 1=0");
            bdsMostly.DataSource = dtMostly;
            Set_Data_Binding();
            dtDeptResponsible = clsPublicOfCF01.GetDataTable(@"select * from dbo.so_cust_complain_dept_responsible Where 1=0");
            bdsDept.DataSource = dtDeptResponsible;
            gridControl2.DataSource = bdsDept;
            dtDetails = clsPublicOfCF01.GetDataTable(@"Select * FROM dbo.so_cust_complain_details Where 1=0");
            bdsDetail.DataSource = dtDetails;
            gridControl1.DataSource = bdsDetail;

            dtTempDel = dtDetails.Clone();

        }

        private void Set_Data_Binding()
        {
            //對象數據綁定
            txtID.DataBindings.Add("Text", bdsMostly, "id");
            dtappellate_date.DataBindings.Add("EditValue", bdsMostly, "appellate_date");
            luecustomer_id.DataBindings.Add("EditValue", bdsMostly, "customer_id");
            txtCustomer_name.DataBindings.Add("Text", bdsMostly, "customer_name");
            bteexception_note_id.DataBindings.Add("Text", bdsMostly, "exception_note_id");
            lueseller_id.DataBindings.Add("EditValue", bdsMostly, "seller_id");
            txtnew_mo_id.DataBindings.Add("Text", bdsMostly, "new_mo_id");

            memreslove_pro_revert.DataBindings.Add("Text", bdsMostly, "reslove_pro_revert");
            luereason_type.DataBindings.Add("EditValue", bdsMostly, "reason_type");
            txtreason_type_big.DataBindings.Add("Text", bdsMostly, "reason_type_big");
            memessential_reason_dept.DataBindings.Add("Text", bdsMostly, "essential_reason_dept");
            memessential_reason_qc.DataBindings.Add("Text", bdsMostly, "essential_reason_qc");

            memdept_correct_step.DataBindings.Add("Text", bdsMostly, "dept_correct_step");
            txtdept_responsible_person1.DataBindings.Add("Text", bdsMostly, "dept_responsible_person1");
            dtdept_date1.DataBindings.Add("EditValue", bdsMostly, "dept_date1");          
            memdept_prevent_recurrent_step.DataBindings.Add("Text", bdsMostly, "dept_prevent_recurrent_step");
            txtdept_responsible_person2.DataBindings.Add("Text", bdsMostly, "dept_responsible_person2");
            dtdept_date2.DataBindings.Add("EditValue", bdsMostly, "dept_date2");

            memqc_correct_step.DataBindings.Add("Text", bdsMostly, "qc_correct_step");
            txtqc_responsible_person1.DataBindings.Add("Text", bdsMostly, "qc_responsible_person1");
            dtqc_date1.DataBindings.Add("EditValue", bdsMostly, "qc_date1");
            memqc_prevent_recurrent_step.DataBindings.Add("Text", bdsMostly, "qc_prevent_recurrent_step");
            txtqc_responsible_person2.DataBindings.Add("Text", bdsMostly, "qc_responsible_person2");
            dtqc_date2.DataBindings.Add("EditValue", bdsMostly, "qc_date2");
            memqc_amend_effect_confirm.DataBindings.Add("Text", bdsMostly, "qc_amend_effect_confirm");
            txtqc_exception_note_by.DataBindings.Add("Text", bdsMostly, "qc_exception_note_by");
            dtqc_exception_note_date.DataBindings.Add("EditValue", bdsMostly, "qc_exception_note_date");

            memremark.DataBindings.Add("Text", bdsMostly, "remark");
            txtCreate_by.DataBindings.Add("Text", bdsMostly, "create_by");
            txtCreate_date.DataBindings.Add("Text", bdsMostly, "create_date");
            txtupdate_by.DataBindings.Add("Text", bdsMostly, "update_by");
            txtupdate_date.DataBindings.Add("Text", bdsMostly, "update_date");

            dtbill_date.DataBindings.Add("EditValue", bdsMostly, "bill_date");
            txtbill_create_by.DataBindings.Add("Text", bdsMostly, "bill_create_by");            
            dtbill_create_date.DataBindings.Add("EditValue", bdsMostly, "bill_create_date");
        }     


        private void frmCustComplain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtTempDel.Dispose();         
            dtDeptResponsible.Dispose();
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
                dr["dept_id"] = dgvDetails.GetRowCellValue(curRow, "dept_id");
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
            txtID.Focus();
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

            SqlParameter[] paras=new SqlParameter[]{

                new SqlParameter("@id",txtID.Text)
            };
            DataTable dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_cust_complain_report", paras);
            using (xrCustComplain myRpt = new xrCustComplain() { DataSource = dtReport })
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
        
            frmCustComplain_Find frmFind = new frmCustComplain_Find();
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
           
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            BTNITEMADD.Enabled = !_flag;
            BTNFIND.Enabled = _flag;
            BTNITEMDEL.Enabled = !_flag;

            btnAdd1.Enabled = !_flag;
            btnDel1.Enabled = !_flag;

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
            txtID.Text =clsCustComplain.GetDocNo();
            dtappellate_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            dtDetails.Clear();
            bdsDetail.DataSource = dtDetails;
            //dtDept.Clear();
            //bdsDept.DataSource = dtDept;
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
            txtID.BackColor = System.Drawing.Color.White;
            bteexception_note_id.Properties.ReadOnly = false;
            bteexception_note_id.BackColor = System.Drawing.Color.White;
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
                const string sql_del = "Update dbo.so_cust_complain_mostly Set sate='2',update_by=@user_id,update_date=getdate() WHERE id=@id";               
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
                        bdsDept.Clear();
                        bdsDetail.Clear();
                        //MessageBox.Show("數據刪除成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (dgvDetails.RowCount == 6)
                {
                    MessageBox.Show("同一張單據最多只可以添加6筆數據！", "提示信息");
                    return;
                }
                Set_Grid_Status(true);
                dgvDetails.AddNewRow();//新增
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount).ToString("0000"));
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
            //測試項目必須有輸入
            bool _flag = false;
            if (dgvDetails.RowCount > 0)
            {
                memremark.Focus();                
                int curRow = 0;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    curRow = dgvDetails.GetRowHandle(i);
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "mo_id")) || String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "goods_id")))
                    {
                        _flag = true;
                        MessageBox.Show("頁數或貨品編碼不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
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
            dgvDept.OptionsBehavior.Editable = _flag;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);           

            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "2");
            Set_Grid_Status(false);
            dtTempDel.Clear();
            bdsMostly.CancelEdit();//取消數據綁定
            bdsDept.CancelEdit();
            bdsDetail.CancelEdit();
            dtDetails.RejectChanges();
            dtDeptResponsible.RejectChanges();           
            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {               
                Find_doc(mID);
            }
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;
            bteexception_note_id.Properties.ReadOnly = true;
            bteexception_note_id.BackColor = Color.White;

        }

        private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                //主表
                string sql_h = String.Format(
                @"SELECT * FROM dbo.so_cust_complain_mostly with(nolock) WHERE id ='{0}' AND state<>'2'", temp_id);
                //責任部門
                string sql_d1 = String.Format(
                @"SELECT b.* FROM dbo.so_cust_complain_mostly a with(nolock),dbo.so_cust_complain_dept_responsible b with(nolock) WHERE a.id=b.id and a.id='{0}' and a.state<>'2'", temp_id);
                //明細表
                string sql_d2 = String.Format(
                @"SELECT b.* FROM dbo.so_cust_complain_mostly a with(nolock),dbo.so_cust_complain_details b with(nolock) WHERE a.id=b.id and a.id='{0}' and a.state<>'2'", temp_id);

                dtMostly = clsPublicOfCF01.GetDataTable(sql_h);
                dtDeptResponsible = clsPublicOfCF01.GetDataTable(sql_d1);
                dtDetails = clsPublicOfCF01.GetDataTable(sql_d2);
                bdsMostly.DataSource = dtMostly;
                bdsDept.DataSource = dtDeptResponsible;
                bdsDetail.DataSource = dtDetails;
                mID = txtID.Text; //保存臨時的ID
            }
        }

        //private void GetDocNo() //取最大單據編號
        //{
        //    string strYear = clsPublicOfCF01.ExecuteSqlReturnObject("Select substring(convert(varchar(10),GETDATE(),120),1,4)");
        //    string strDoc = String.Format("CCA{0}", strYear);
        //    string strSeq;
        //    string strMaxSeq;            
        //    DataTable dtMaxSeq = new DataTable();
        //    dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(id) as id FROM dbo.so_cust_complain_mostly WHERE id LIKE '{0}%'", strDoc));
        //    if (String.IsNullOrEmpty(dtMaxSeq.Rows[0]["id"].ToString()))
        //    {
        //        strSeq = "001";
        //    }
        //    else
        //    {
        //        strMaxSeq = dtMaxSeq.Rows[0]["id"].ToString();
        //        strSeq = strMaxSeq.Substring(strMaxSeq.Length - 3);
        //        strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000");
        //    }
        //    strMaxSeq = strDoc + strSeq;
        //    txtID.Text = strMaxSeq;
        //}

        //private string Get_Details_Seq(string pID) //取明細的序號
        //{
        //    DataTable dtMaxseq = new DataTable();
        //    dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(sequence_id) as sequence_id FROM dbo.so_cust_complain_details with(nolock) WHERE id ='{0}'", pID));

        //    string strSeq;
        //    if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["sequence_id"].ToString()))
        //    {
        //        strSeq = "0001";
        //    }
        //    else
        //    {
        //        strSeq = dtMaxseq.Rows[0]["sequence_id"].ToString();
        //        strSeq = strSeq.Substring(0, 4);
        //        strSeq = (Convert.ToInt32(strSeq) + 1).ToString("0000");
        //    }
        //    dtMaxseq.Dispose();
        //    return strSeq;
        //}

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (mState == "NEW")
            {
              txtID.Text =clsCustComplain.GetDocNo();
            }
            if (txtID.Text == "" || dtappellate_date.Text == "" || luereason_type.Text == "" )
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
            for (int i=0; i < dgvDept.RowCount; i++)
            {
                if (dgvDept.GetRowCellValue(i, "dept_id").ToString() == "" )
                {
                    check_details_flag = false;
                    MessageBox.Show("關系部門中的【部門】不可為空", "提示信息");
                    dgvDept.Focus();
                    break;
                }
            }
            if (!check_details_flag)
            {
                return;
            }
           
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetRowCellValue(i, "mo_id").ToString() == "" || dgvDetails.GetRowCellValue(i, "goods_id").ToString() == "")
                {
                    check_details_flag = false;
                    MessageBox.Show("明細資料中的頁數或貨品編號不可為空", "提示信息"); ;
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
            @"INSERT INTO dbo.so_cust_complain_mostly(id,appellate_date,exception_note_id,customer_id,customer_name,seller_id,new_mo_id,reslove_pro_revert,reason_type,reason_type_big,essential_reason_dept,
            essential_reason_qc,dept_correct_step,dept_prevent_recurrent_step,dept_responsible_person1,dept_date1,dept_responsible_person2,dept_date2,qc_correct_step,
            qc_responsible_person1,qc_date1,qc_prevent_recurrent_step,qc_responsible_person2,qc_date2,qc_amend_effect_confirm,qc_exception_note_by,qc_exception_note_date,remark,create_by,create_date, bill_date,bill_create_by,bill_create_date)
			VALUES (@id, CASE LEN(@appellate_date) WHEN 0 THEN null ELSE @appellate_date END,@exception_note_id,@customer_id,@customer_name,@seller_id,@new_mo_id,@reslove_pro_revert,@reason_type,@reason_type_big,@essential_reason_dept,@essential_reason_qc,
            @dept_correct_step,@dept_prevent_recurrent_step,@dept_responsible_person1,CASE LEN(@dept_date1) WHEN 0 THEN null ELSE @dept_date1 END,@dept_responsible_person2,CASE LEN(@dept_date2) WHEN 0 THEN null ELSE @dept_date2 END,
            @qc_correct_step,@qc_responsible_person1,CASE LEN(@qc_date1) WHEN 0 THEN null ELSE @qc_date1 END,
            @qc_prevent_recurrent_step,@qc_responsible_person2,CASE LEN(@qc_date2) WHEN 0 THEN null ELSE @qc_date2 END,@qc_amend_effect_confirm,@qc_exception_note_by,CASE LEN(@qc_exception_note_date) WHEN 0 THEN null ELSE @qc_exception_note_date END,@remark,@user_id,getdate(),
            @bill_date,@bill_create_by,@bill_create_date)";
            //更新主表
            const string sql_update =
            @"UPDATE dbo.so_cust_complain_mostly 
            SET appellate_date=CASE LEN(@appellate_date) WHEN 0 THEN null ELSE @appellate_date END,exception_note_id=@exception_note_id,customer_id=@customer_id,customer_name=@customer_name,seller_id=@seller_id,new_mo_id=@new_mo_id,
            reslove_pro_revert=@reslove_pro_revert,reason_type=@reason_type,reason_type_big=@reason_type_big,essential_reason_dept=@essential_reason_dept,essential_reason_qc=@essential_reason_qc,
            dept_correct_step=@dept_correct_step,dept_prevent_recurrent_step=@dept_prevent_recurrent_step,dept_responsible_person1=@dept_responsible_person1,dept_date1=CASE LEN(@dept_date1) WHEN 0 THEN null ELSE @dept_date1 END,
            dept_responsible_person2=@dept_responsible_person2,dept_date2=CASE LEN(@dept_date2) WHEN 0 THEN null ELSE @dept_date2 END,qc_correct_step=@qc_correct_step,qc_responsible_person1=@qc_responsible_person1,qc_date1=CASE LEN(@qc_date1) WHEN 0 THEN null ELSE @qc_date1 END,
            qc_prevent_recurrent_step=@qc_prevent_recurrent_step,qc_responsible_person2=@qc_responsible_person2,qc_date2=CASE LEN(@qc_date2) WHEN 0 THEN null ELSE @qc_date2 END,qc_amend_effect_confirm=@qc_amend_effect_confirm,
            qc_exception_note_by=@qc_exception_note_by,qc_exception_note_date=CASE LEN(@qc_exception_note_date) WHEN 0 THEN null ELSE @qc_exception_note_date END,remark=@remark,update_by=@user_id,update_date=getdate(),
            bill_date=CASE LEN(@bill_date) WHEN 0 THEN null ELSE @bill_date END,bill_create_by=@bill_create_by,bill_create_date=CASE LEN(@bill_create_date) WHEN 0 THEN null ELSE @bill_create_date END
            Where id=@id";

            //新增明細表
            const string sql_detail_insert =
            @"INSERT INTO dbo.so_cust_complain_details(id,sequence_id,mo_id,goods_id,goods_name,oc_info,order_qty,unit_code,arrive_date,exception_detail,disposal_pro,solve_date,remark,ref_id)
            VALUES(@id,@sequence_id,@mo_id,@goods_id,@goods_name,@oc_info,@order_qty,@unit_code,CASE LEN(@arrive_date) WHEN 0 THEN null ELSE @arrive_date END,@exception_detail,@disposal_pro,
            CASE LEN(@solve_date) WHEN 0 THEN null ELSE @solve_date END,@remark,@ref_id)";
            //更新明細表
            const string sql_detail_update =
            @"UPDATE dbo.so_cust_complain_details
            SET mo_id=@mo_id,goods_id=@goods_id,goods_name=@goods_name,oc_info=@oc_info,order_qty=@order_qty,unit_code=@unit_code,
            arrive_date=CASE LEN(@arrive_date) WHEN 0 THEN null ELSE @arrive_date END,exception_detail=@exception_detail,disposal_pro=@disposal_pro,
            solve_date=CASE LEN(@solve_date) WHEN 0 THEN null ELSE @solve_date END,remark=@remark,ref_id=@ref_id 
            WHERE id=@id and sequence_id=@sequence_id";
            const string sql_item_d = @"DELETE FROM dbo.so_cust_complain_details WHERE id=@id AND sequence_id=@sequence_id";


            //新增關聯責任部門明細表
            const string sql_insert_dept = @"INSERT INTO dbo.so_cust_complain_dept_responsible(id,sequence_id,dept_id,responsible,remark) VALUES(@id,@sequence_id,@dept_id,@responsible,@remark)";
            //更新關聯責任部門明細表
            const string sql_update_dept = @"Update dbo.so_cust_complain_dept_responsible Set dept_id=@dept_id,responsible=@responsible,remark=@remark WHERE id=@id,sequence_id=@sequence_id";
            
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
                        if (clsCustComplain.Valid_Doc(txtID.Text))
                        {
                            //新增的報價編號已存在時重新取值
                          txtID.Text = clsCustComplain.GetDocNo();
                        }
                        myCommand.CommandText = sql_insert;
                    }
                    else
                    {
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    myCommand.Parameters.AddWithValue("@exception_note_id", bteexception_note_id.Text);
                    myCommand.Parameters.AddWithValue("@appellate_date", dtappellate_date.EditValue);
                    myCommand.Parameters.AddWithValue("@customer_id", luecustomer_id.EditValue);
                    myCommand.Parameters.AddWithValue("@customer_name", txtCustomer_name.Text);
                    myCommand.Parameters.AddWithValue("@seller_id", lueseller_id.EditValue);
                    myCommand.Parameters.AddWithValue("@new_mo_id", txtnew_mo_id.Text);
                    myCommand.Parameters.AddWithValue("@reslove_pro_revert", memreslove_pro_revert.Text);
                    myCommand.Parameters.AddWithValue("@reason_type", luereason_type.EditValue);
                    myCommand.Parameters.AddWithValue("@reason_type_big", txtreason_type_big.Text);                    
                    myCommand.Parameters.AddWithValue("@essential_reason_dept", memessential_reason_dept.Text);
                    myCommand.Parameters.AddWithValue("@essential_reason_qc", memessential_reason_qc.Text);
                                                                          
                    myCommand.Parameters.AddWithValue("@dept_correct_step",memdept_correct_step.Text);
                    myCommand.Parameters.AddWithValue("@dept_responsible_person1", txtdept_responsible_person1.Text );
                    myCommand.Parameters.AddWithValue("@dept_date1", dtdept_date1.Text);
                    myCommand.Parameters.AddWithValue("@dept_prevent_recurrent_step", memdept_prevent_recurrent_step.Text);                    
                    myCommand.Parameters.AddWithValue("@dept_responsible_person2", txtdept_responsible_person2.Text);
                    myCommand.Parameters.AddWithValue("@dept_date2", dtdept_date2.Text);

                    myCommand.Parameters.AddWithValue("@qc_correct_step", memqc_correct_step.Text);
                    myCommand.Parameters.AddWithValue("@qc_responsible_person1", txtqc_responsible_person1.Text);
                    myCommand.Parameters.AddWithValue("@qc_date1", dtqc_date1.Text);

                    myCommand.Parameters.AddWithValue("@qc_prevent_recurrent_step", memqc_prevent_recurrent_step.Text);
                    myCommand.Parameters.AddWithValue("@qc_responsible_person2", txtqc_responsible_person2.Text);
                    myCommand.Parameters.AddWithValue("@qc_date2", dtqc_date2.Text);

                    myCommand.Parameters.AddWithValue("@qc_amend_effect_confirm", memqc_amend_effect_confirm.Text);
                    myCommand.Parameters.AddWithValue("@qc_exception_note_by", txtqc_exception_note_by.Text);
                    myCommand.Parameters.AddWithValue("@qc_exception_note_date", dtqc_exception_note_date.Text);
                    myCommand.Parameters.AddWithValue("@remark", memremark.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);

                    myCommand.Parameters.AddWithValue("@bill_date", dtbill_date.EditValue);
                    myCommand.Parameters.AddWithValue("@bill_create_by", txtbill_create_by.Text);
                    myCommand.Parameters.AddWithValue("@bill_create_date", dtbill_create_date.EditValue);
                   // ,bill_create_by,
                    myCommand.ExecuteNonQuery();

                    //保存或新增關係部門責任者確認
                    if (dgvDept.RowCount > 0)
                    {
                        string row_status="";
                        for (int i = 0; i < dtDeptResponsible.Rows.Count; i++)
                        {
                            row_status = dtDeptResponsible.Rows[i].RowState.ToString();
                            if (row_status == "Added" || row_status == "Modified")
                            {
                                myCommand.Parameters.Clear();
                                if (row_status == "Added")
                                {
                                    myCommand.CommandText = sql_insert_dept;
                                }
                                if (row_status == "Modified")
                                {
                                    myCommand.CommandText = sql_update_dept;
                                }                                
                                myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                myCommand.Parameters.AddWithValue("@sequence_id", dtDeptResponsible.Rows[i]["sequence_id"].ToString());//序號
                                myCommand.Parameters.AddWithValue("@dept_id", dtDeptResponsible.Rows[i]["dept_id"].ToString());
                                myCommand.Parameters.AddWithValue("@responsible", dtDeptResponsible.Rows[i]["responsible"].ToString());
                                myCommand.Parameters.AddWithValue("@remark", dtDeptResponsible.Rows[i]["remark"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }


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
                        string strSeq_id = "";
                        string rowStatus;
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
                                strSeq_id=dtDetails.Rows[i]["sequence_id"].ToString();
                                myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                myCommand.Parameters.AddWithValue("@sequence_id", dtDetails.Rows[i]["sequence_id"].ToString());
                                myCommand.Parameters.AddWithValue("@mo_id", dtDetails.Rows[i]["mo_id"].ToString());
                                myCommand.Parameters.AddWithValue("@goods_id", dtDetails.Rows[i]["goods_id"].ToString());
                                myCommand.Parameters.AddWithValue("@goods_name", dtDetails.Rows[i]["goods_name"].ToString());
                                myCommand.Parameters.AddWithValue("@oc_info", dtDetails.Rows[i]["oc_info"].ToString());
                                myCommand.Parameters.AddWithValue("@order_qty", int.Parse(dtDetails.Rows[i]["order_qty"].ToString()));
                                myCommand.Parameters.AddWithValue("@unit_code", dtDetails.Rows[i]["unit_code"].ToString());
                                myCommand.Parameters.AddWithValue("@arrive_date", clsApp.Return_String_Date(dtDetails.Rows[i]["arrive_date"].ToString()));//
                                myCommand.Parameters.AddWithValue("@exception_detail", dtDetails.Rows[i]["exception_detail"].ToString());
                                myCommand.Parameters.AddWithValue("@disposal_pro", dtDetails.Rows[i]["disposal_pro"].ToString());
                                myCommand.Parameters.AddWithValue("@solve_date", clsApp.Return_String_Date(dtDetails.Rows[i]["solve_date"].ToString()));//
                                myCommand.Parameters.AddWithValue("@remark", dtDetails.Rows[i]["remark"].ToString());
                                myCommand.Parameters.AddWithValue("@ref_id", dtDetails.Rows[i]["ref_id"].ToString()); 
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
            bteexception_note_id.Properties.ReadOnly = true;
            bteexception_note_id.BackColor = Color.White;
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

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            if (mState == "")
            {
                return;
            }
            frmFindDataBase frmCust = new frmFindDataBase(btnFindCustomer.Name) { Owner = this };
            frmCust.ShowDialog();
            luecustomer_id.EditValue = DBUtility.get_query_id;
            
        }

        private void luereason_type_EditValueChanged(object sender, EventArgs e)
        {
           txtreason_type_big.Text = luereason_type.GetColumnValue("person_type_big").ToString();
        }

        private void bteexception_note_id_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mState == "NEW")
            {
                //循環加入多條新測試項目                           
                using (frmCustComplainFromNotices frmNotices = new frmCustComplainFromNotices())
                {
                    frmNotices.ShowDialog();
                    if (frmNotices.listComplain.Count >0)
                    {
                        int i = 0;
                        foreach (mdlCustComplain mdlComplain in frmNotices.listComplain)
                        {
                            i += 1;
                            if (i == 1)
                            {
                                //給主檔資料賦值
                                bteexception_note_id.Text = mdlComplain.ref_id;
                                //dtappellate_date.EditValue = mdlComplain.bill_date;
                                luecustomer_id.EditValue = mdlComplain.customer_id;
                                lueseller_id.EditValue = mdlComplain.seller_id;
                                txtnew_mo_id.Text = mdlComplain.new_mo_id;
                                memremark.Text = mdlComplain.remark;

                                dtbill_date.EditValue = mdlComplain.bill_date;
                                txtbill_create_by.Text = mdlComplain.bill_create_by;
                                dtbill_create_date.EditValue = mdlComplain.bill_create_date;
                            }
                            //添加表格明細                           
                            bdsDetail.AddNew();
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text.Trim());
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id",dgvDetails.RowCount.ToString("0000"));
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", mdlComplain.mo_id);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", mdlComplain.goods_id);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", mdlComplain.goods_name);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "order_qty", mdlComplain.order_qty);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "unit_code", mdlComplain.unit_code);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "oc_info", mdlComplain.oc_info); 
                        }                                          
                    }
                }
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

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dgvDept.AddNewRow();
            dgvDept.SetRowCellValue(dgvDept.FocusedRowHandle, "id",txtID.Text );
            dgvDept.SetRowCellValue(dgvDept.FocusedRowHandle, "sequence_id", dgvDept.RowCount.ToString("000"));
            SetFocuse(dgvDept, dgvDept.FocusedRowHandle, "dept_id");

        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            if (dgvDept.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("確定要刪除關系責任部門?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = dgvDept.FocusedRowHandle;               
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@id",dgvDept.GetRowCellValue(curRow, "id").ToString()),
                    new SqlParameter("@sequence_id",dgvDept.GetRowCellValue(curRow, "sequence_id").ToString())
                };
                try
                {
                    clsPublicOfCF01.ExecuteNonQuery("Delete From dbo.so_cust_complain_dept_responsible Where id=@id And sequence_id=@sequence_id", paras, false);
                    dgvDept.DeleteRow(curRow);//移走當前行
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }

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

        private void dgvDept_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (dgvDept.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = dgvDept.GetDataRow(e.RowHandle).RowState.ToString();
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
                string mo_id = dgvDetails.GetRowCellDisplayText(dgvDetails.FocusedRowHandle, "mo_id");
                if (!string.IsNullOrEmpty(mo_id))
                {
                    string sql = string.Format(
                    @"select id,goods_id,goods_name,goods_unit,convert(int,order_qty) as order_qty,convert(date,arrive_date,120) as arrive_date 
                    from dgerp2.cferp.dbo.so_order_details with(nolock)
                    Where within_code='0000' and mo_id='{0}'",mo_id);
                    DataTable dtMo = clsPublicOfCF01.GetDataTable(sql);
                    if (dtMo.Rows.Count > 0)
                    {
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", dtMo.Rows[0]["goods_id"].ToString());
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", dtMo.Rows[0]["goods_name"].ToString());
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "oc_info", dtMo.Rows[0]["id"].ToString());
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "unit_code", dtMo.Rows[0]["goods_unit"].ToString());
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "order_qty", dtMo.Rows[0]["order_qty"].ToString());
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "arrive_date", dtMo.Rows[0]["arrive_date"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("無效的頁數資料!", "提示信息");
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", "");
                        SetFocuse(dgvDetails, dgvDetails.FocusedRowHandle, "mo_id");
                    }
                }
            }
        }

        private void luecustomer_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                txtCustomer_name.Text = luecustomer_id.GetColumnValue("cdesc").ToString();
            }
        }

        



    }
}
