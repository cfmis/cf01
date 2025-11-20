/*
 * Create by :   Allen Leung
 * Create Date : 2019-03-07
 * remark:
 * 鈕部工模制程流程表
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.Reports;
using cf01.ModuleClass;
using System.Drawing;
using cf01.MDL;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmMould_Process : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public DataTable dtReSet = new DataTable();             
        public string mState = ""; 
        clsToolBarNew objToolbar;
        clsAppPublic clsApp = new clsAppPublic();
        DataGridViewRow dgvrow = new DataGridViewRow();
        public static List<mdlOcRemark> mList = new List<mdlOcRemark>();

        public frmMould_Process()
        {
            InitializeComponent();
            dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmMould_Process_Load(object sender, EventArgs e)
        {
            const string sql = @"SELECT a.*,b.name as goods_name,b.name as picture_name From jo_mould_button a,geo_it_goods b where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            if (dtcon_date1.Text == "")
            {
                dtcon_date1.EditValue = DateTime.Now.AddDays(-7).Date.ToString("yyyy/MM/dd");
            }
            else
            {
                dtcon_date1.EditValue = DateTime.Parse(dtcon_date1.EditValue.ToString()).Date.ToString("yyyy/MM/dd");
            }
            if (dtcon_date2.Text == "")
            {
                dtcon_date2.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            }
            else
            {
                dtcon_date2.EditValue = DateTime.Parse(dtcon_date2.EditValue.ToString()).Date.ToString("yyyy/MM/dd");
            }
            chkPrintAll.Checked = false;
        }

        //private void Set_Data_Binding()
        //{
        //    //對象數據綁定
        //    txtID.DataBindings.Add("Text", bds1, "id");
        //    txtmould_id.DataBindings.Add("Text", bds1, "mould_id");
        //    dtapplication_date.DataBindings.Add("EditValue", bds1, "application_date");
        //    dtcon_date.DataBindings.Add("EditValue", bds1, "con_date");
        //    dtrequire_finish_date.DataBindings.Add("EditValue", bds1, "require_finish_date");
        //    txtlister_by.DataBindings.Add("Text", bds1, "lister_by");
        //    txtmo_id.DataBindings.Add("Text", bds1, "mo_id");
        //    txtgoods_id.DataBindings.Add("Text", bds1, "goods_id");
        //    txtgoods_name.DataBindings.Add("Text", bds1, "goods_name");
        //    chksample_yes.DataBindings.Add("Checked", bds1, "sample_yes");
        //    chksample_no.DataBindings.Add("Checked", bds1, "sample_no");
        //    chkmd_new.DataBindings.Add("Checked", bds1, "md_new");
        //    chkmd_reproduced.DataBindings.Add("Checked", bds1, "md_reproduced");
        //    dtuniversal_machine_receive.DataBindings.Add("EditValue", bds1, "universal_machine_receive");
        //    txtuniversal_machine_receive_sign.DataBindings.Add("Text", bds1, "universal_machine_receive_sign");
        //    dtuniversal_machine_md_receive.DataBindings.Add("EditValue", bds1, "universal_machine_md_receive");
        //    txtuniversal_machine_md_receive_sign.DataBindings.Add("Text", bds1, "universal_machine_md_receive_sign");
        //    dtuniversal_machine_test.DataBindings.Add("EditValue", bds1, "universal_machine_test");
        //    txtuniversal_machine_test_sign.DataBindings.Add("Text", bds1, "universal_machine_test_sign");
        //    dtuniversal_machine_confirm.DataBindings.Add("EditValue", bds1, "universal_machine_confirm");
        //    txtuniversal_machine_confirm_sign.DataBindings.Add("Text", bds1, "universal_machine_confirm_sign");

        //    dteye_machine_receive.DataBindings.Add("EditValue", bds1, "eye_machine_receive");
        //    txteye_machine_receive_sign.DataBindings.Add("Text", bds1, "eye_machine_receive_sign");
        //    dteye_machine_md_receive.DataBindings.Add("EditValue", bds1, "eye_machine_md_receive");
        //    txteye_machine_md_receive_sign.DataBindings.Add("Text", bds1, "eye_machine_md_receive_sign");
        //    dteye_machine_test.DataBindings.Add("EditValue", bds1, "eye_machine_test");
        //    txteye_machine_test_sign.DataBindings.Add("Text", bds1, "eye_machine_test_sign");
        //    dteye_machine_confirm.DataBindings.Add("EditValue", bds1, "eye_machine_confirm");
        //    txteye_machine_confirm_sign.DataBindings.Add("Text", bds1, "eye_machine_confirm_sign");
        //    txtmould_qty.DataBindings.Add("Text", bds1, "mould_qty");
        //    memmould_instructions.DataBindings.Add("Text", bds1, "mould_instructions");
        //    memmould_require.DataBindings.Add("Text", bds1, "mould_require");
        //    txtdrawing_no.DataBindings.Add("Text", bds1, "drawing_no");            

        //    txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
        //    txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
        //    txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
        //    txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");
        //}     

        private void SetButtonSatus(bool _flag)
        {
            btnNew.Enabled = _flag;
            btnEdit.Enabled = _flag;
            btnDelete.Enabled = _flag;
            //BTNNEWCOPY.Enabled = _flag;
            btnPrint.Enabled = _flag;
            btnSave.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            if (objToolbar != null)
            {
                objToolbar.SetToolBar();
            }
        }       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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

        private void AddNew()
        {
            tabControl1.SelectTab(0);
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            dgvDetails.Enabled = false; //表格可以編輯
      
            //新增時設置初始值
            dtcon_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();
            dtcon_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            txtlister_by.Text = DBUtility._user_id;

            txtID.Focus();
        }

        private void Save()
        {
            txtID.Focus();
            if (txtID.Text == "" && dtcon_date.Text == "")
            {
                MessageBox.Show("模具編號.、入單日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtcon_date.Focus();
                return;
            }
            if (lueVer.EditValue.ToString() == "")
            {
                MessageBox.Show("版本不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lueVer.Focus();
                return;
            }

            //新增時判斷主鍵是否已存在
            if (mState == "NEW")
            {
                if (!ValidData())
                {
                    return;
                }
            }
            //bds1.EndEdit();
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO jo_mould_button(id,ver,con_date,require_finish_date,goods_id,mould_id,mould_location,application_date,sample_yes,sample_no,md_new,md_reproduced,lister_by,mo_id,
            universal_machine_receive,universal_machine_receive_sign,universal_machine_md_receive,universal_machine_md_receive_sign,universal_machine_test,universal_machine_test_sign,
            universal_machine_confirm,universal_machine_confirm_sign,eye_machine_receive,eye_machine_receive_sign,eye_machine_md_receive,eye_machine_md_receive_sign,eye_machine_test,
            eye_machine_test_sign,eye_machine_confirm,eye_machine_confirm_sign,mould_instructions,mould_qty,mould_require,drawing_no,create_by,create_date)
            VALUES(@id,@ver,@con_date,CASE LEN(@require_finish_date) WHEN 0 THEN null ELSE @require_finish_date END,@goods_id,@mould_id,@mould_location,
            CASE LEN(@application_date) WHEN 0 THEN null ELSE @application_date END,@sample_yes,@sample_no,@md_new,@md_reproduced,@lister_by,@mo_id,
            CASE LEN(@universal_machine_receive) WHEN 0 THEN null ELSE @universal_machine_receive END ,@universal_machine_receive_sign,
            CASE LEN(@universal_machine_md_receive) WHEN 0 THEN null ELSE @universal_machine_md_receive END ,@universal_machine_md_receive_sign,
            CASE LEN(@universal_machine_test) WHEN 0 THEN null ELSE @universal_machine_test END,@universal_machine_test_sign,
            CASE LEN(@universal_machine_confirm) WHEN 0 THEN null ELSE @universal_machine_confirm END,@universal_machine_confirm_sign,
            CASE LEN(@eye_machine_receive) WHEN 0 THEN null ELSE @eye_machine_receive END,@eye_machine_receive_sign,
            CASE LEN(@eye_machine_md_receive) WHEN 0 THEN null ELSE @eye_machine_md_receive END,@eye_machine_md_receive_sign,
            CASE LEN(@eye_machine_test) WHEN 0 THEN null ELSE @eye_machine_test END,@eye_machine_test_sign,
            CASE LEN(@eye_machine_confirm) WHEN 0 THEN null ELSE @eye_machine_confirm END,@eye_machine_confirm_sign,
            @mould_instructions,@mould_qty,@mould_require,@drawing_no,@user_id,getdate())";

            const string sql_update =
            @"Update jo_mould_button 
            SET con_date=@con_date,require_finish_date= CASE LEN(@require_finish_date) WHEN 0 THEN null ELSE @require_finish_date END ,goods_id=@goods_id,mould_id=@mould_id,mould_location=@mould_location,
            application_date=CASE LEN(@application_date) WHEN 0 THEN null ELSE @application_date END ,sample_yes=@sample_yes,sample_no=@sample_no,
            md_new=@md_new,md_reproduced=@md_reproduced,lister_by=@lister_by,mo_id=@mo_id,
            universal_machine_receive=CASE LEN(@universal_machine_receive) WHEN 0 THEN null ELSE @universal_machine_receive END ,universal_machine_receive_sign=@universal_machine_receive_sign,
            universal_machine_md_receive=CASE LEN(@universal_machine_md_receive) WHEN 0 THEN null ELSE @universal_machine_md_receive END ,universal_machine_md_receive_sign=@universal_machine_md_receive_sign,
            universal_machine_test= CASE LEN(@universal_machine_test) WHEN 0 THEN null ELSE @universal_machine_test END ,universal_machine_test_sign=@universal_machine_test_sign,
            universal_machine_confirm=CASE LEN(@universal_machine_confirm) WHEN 0 THEN null ELSE @universal_machine_confirm END,universal_machine_confirm_sign=@universal_machine_confirm_sign,
            eye_machine_receive=CASE LEN(@eye_machine_receive) WHEN 0 THEN null ELSE @eye_machine_receive END,eye_machine_receive_sign=@eye_machine_receive_sign,
            eye_machine_md_receive=CASE LEN(@eye_machine_md_receive) WHEN 0 THEN null ELSE @eye_machine_md_receive END,eye_machine_md_receive_sign=@eye_machine_md_receive_sign,
            eye_machine_test=CASE LEN(@eye_machine_test) WHEN 0 THEN null ELSE @eye_machine_test END,eye_machine_test_sign=@eye_machine_test_sign,
            eye_machine_confirm=CASE LEN(@eye_machine_confirm) WHEN 0 THEN null ELSE @eye_machine_confirm END,eye_machine_confirm_sign=@eye_machine_confirm_sign,
            mould_instructions=@mould_instructions,mould_qty=@mould_qty,mould_require=@mould_require,drawing_no=@drawing_no,update_by=@user_id,update_date=getdate()
            WHERE id=@id And ver=@ver";            

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            //string strSerial_no;
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@id", txtID.Text);
                    myCommand.Parameters.AddWithValue("@ver", lueVer.EditValue);
                    if (mState == "NEW")
                    {
                        myCommand.CommandText = sql_new;
                        string ls_sql_f = string.Format(@"Select '1' From dbo.jo_mould_button where id='{0}' and ver='{1}'", txtID.Text,lueVer.EditValue);
                        if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql_f) != "")
                        {
                            MessageBox.Show("已存在此模具編號，不可以重復新增！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
                            return;
                        }
                        //strSerial_no = clsTommyTest.GetSeqNo("jo_mould_button", "serial_no");
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;                       
                        //strSerial_no = txtID.Text;
                    }                    
                    myCommand.Parameters.AddWithValue("@con_date", clsApp.Return_String_Date(dtcon_date.Text));
                    myCommand.Parameters.AddWithValue("@application_date", clsApp.Return_String_Date(dtapplication_date.Text));
                    myCommand.Parameters.AddWithValue("@require_finish_date", clsApp.Return_String_Date(dtrequire_finish_date.Text));
                    myCommand.Parameters.AddWithValue("@mould_id", txtmould_id.Text);
                    myCommand.Parameters.AddWithValue("@mould_location", txtmould_location.Text);
                    myCommand.Parameters.AddWithValue("@lister_by", txtlister_by.Text);
                    myCommand.Parameters.AddWithValue("@mo_id", txtmo_id.Text);
                    myCommand.Parameters.AddWithValue("@goods_id", txtgoods_id.Text);
                    if (chksample_yes.Checked)
                        myCommand.Parameters.AddWithValue("@sample_yes", true);
                    else
                        myCommand.Parameters.AddWithValue("@sample_yes", false);
                    if (chksample_no.Checked)
                        myCommand.Parameters.AddWithValue("@sample_no", true);
                    else
                        myCommand.Parameters.AddWithValue("@sample_no", false);
                    if (chkmd_new.Checked)
                        myCommand.Parameters.AddWithValue("@md_new", true);
                    else
                        myCommand.Parameters.AddWithValue("@md_new", false);
                    if (chkmd_reproduced.Checked)
                        myCommand.Parameters.AddWithValue("@md_reproduced", true);
                    else
                        myCommand.Parameters.AddWithValue("@md_reproduced", false);
                    myCommand.Parameters.AddWithValue("@universal_machine_receive", dtuniversal_machine_receive.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_receive_sign", txtuniversal_machine_receive_sign.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_md_receive", dtuniversal_machine_md_receive.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_md_receive_sign", txtuniversal_machine_md_receive_sign.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_test", dtuniversal_machine_test.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_test_sign", txtuniversal_machine_test_sign.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_confirm", dtuniversal_machine_confirm.Text);
                    myCommand.Parameters.AddWithValue("@universal_machine_confirm_sign", txtuniversal_machine_confirm_sign.Text);

                    myCommand.Parameters.AddWithValue("@eye_machine_receive", dteye_machine_receive.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_receive_sign", txteye_machine_receive_sign.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_md_receive", dteye_machine_md_receive.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_md_receive_sign", txteye_machine_md_receive_sign.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_test", dteye_machine_test.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_test_sign", txteye_machine_test_sign.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_confirm", dteye_machine_confirm.Text);
                    myCommand.Parameters.AddWithValue("@eye_machine_confirm_sign", txteye_machine_confirm_sign.Text);

                    myCommand.Parameters.AddWithValue("@mould_require", memmould_require.Text);
                    myCommand.Parameters.AddWithValue("@mould_instructions", memmould_instructions.Text);                    
                    myCommand.Parameters.AddWithValue("@mould_qty", txtmould_qty.Text);
                    myCommand.Parameters.AddWithValue("@drawing_no", txtdrawing_no.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);

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
                    myCon.Dispose();
                    myTrans.Dispose();
                }
            }
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);
            dgvDetails.DataSource = dtDetail;
            dgvDetails.Enabled = true;

            if (save_flag)
            {
                ReSet_Datagrid_Value();
                //新增狀態下定位到新增的行
                //dtDetail.AcceptChanges();               
                if (mState == "NEW")
                {
                    int cur_row_index = dgvDetails.RowCount - 1;
                    if (cur_row_index >= 0)
                    {
                        dgvDetails.CurrentCell = dgvDetails.Rows[cur_row_index].Cells[2]; //设置当前单元格
                        dgvDetails.Rows[cur_row_index].Selected = true; //選中整行
                    }
                }
                mState = "";                
                //MessageBox.Show("數據保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBoxTimeout((IntPtr)0, "數據保存成功!", "提示信息", 0, 0, 1000); //提示窗體1秒后自動關閉   
                clsUtility.myMessageBox("數據保存成功!", "提示信息");                
            }
            else
            {                
               MessageBox.Show("數據保存失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);                
            }
        }

        /// <summary>
        /// 新增時判斷主鍵是否已存在
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            bool result = false;
            string ls_sql = string.Format(@"select '1' from dbo.jo_mould_button Where id='{0}' And ver='{1}'", txtID.Text,lueVer.Text);
            if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql) == "")
                result = true;
            else
            {
                MessageBox.Show(string.Format("已存在畫稿編號:[{0}][{1}],不可以重復錄入!", txtID.Text, lueVer.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }

        private void Delete()
        {
            if (dgvDetails.RowCount == 0 && string.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //string ls_id_delete = txtID.Text;
                string ls_mould_id = txtmould_id.Text;
                const string sql_del = "DELETE FROM dbo.jo_mould_button WHERE id=@id And ver=@ver";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text);
                        myCommand.Parameters.AddWithValue("@ver", lueVer.EditValue.ToString());
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        //gridView1.DeleteRow(gridView1.FocusedRowHandle);
                        if (dgvDetails.CurrentRow.Index >= 0)
                        {
                            dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        }
                        MessageBox.Show("當前記錄刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //移走表格中已刪除的記錄
                //应该采用倒序循环刪除,因为正序删除时索引会发生变化
                for (int i = dgvFind.Rows.Count - 1; i >= 0; i--)
                {
                    //if (dgvFind.Rows[i].Cells["id1"].Value.ToString() == ls_id_delete)
                    if (dgvFind.Rows[i].Cells["mould_id1"].Value.ToString() == ls_mould_id)
                    {
                        dtDetail.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void Edit()
        {
            if (txtID.Text == "")
            {
                return;
            }
            tabControl1.SelectTab(0);
            mState = "EDIT";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtUpdate_by.Text = DBUtility._user_id;
            txtUpdate_date.Text = DateTime.Now.Date.ToString();
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;
            lueVer.Properties.ReadOnly = true;
            lueVer.BackColor = Color.White;
            txtmould_id.Focus();
            dgvDetails.Enabled = false;
        }

        private void frmMould_Process_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();          
           objToolbar = null;
           clsApp = null;           
           mList = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtmould_id.Focus();
            Edit();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {           
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);           
            dgvDetails.Enabled = true;
            mState = "";
            txtID.Properties.ReadOnly = true;

            if (!string.IsNullOrEmpty(mID) && dgvDetails.RowCount > 0)
            {
                dgvDetails.CurrentCell = dgvDetails.Rows[row_reset].Cells[2]; //设置当前单元格
                dgvDetails.Rows[row_reset].Selected = true; //選中整行
            }            
        }    

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                MessageBox.Show("請首先保存數據,然后方可以進行此查詢操作!");
                return;
            }
            Find_Data();
        }

        private void Find_Data()
        {
            dtDetail.Clear();           
            string sql = string.Format(
                @"SELECT A.*,B.name as goods_name,dbo.fn_get_picture_name_of_artwork('0000',Substring(A.goods_id,5,7),'OUT') AS picture_name 
                 From dbo.jo_mould_button A with(nolock),{0}it_goods B with(nolock) 
                 Where A.goods_id COLLATE Chinese_PRC_CI_AS = B.id", DBUtility.remote_db);
            if (txtid1.Text == "" && txtid2.Text == "" && dtcon_date1.Text == "" && dtcon_date2.Text == "" && txtmould_id1.Text == "" && txtmould_id.Text=="")
                sql =string.Format(
                @"SELECT A.*,B.name as goods_name,dbo.fn_get_picture_name_of_artwork('0000',Substring(A.goods_id,5,7),'OUT') AS picture_name 
                From dbo.jo_mould_button A with(nolock),{0}it_goods B with(nolock) 
                Where A.goods_id COLLATE Chinese_PRC_CI_AS = B.id", DBUtility.remote_db);
            else
            {                
                if (txtid1.Text != "")
                {
                    sql = sql + string.Format(" and a.id>='{0}'", txtid1.Text);
                }
                if (txtid2.Text != "")
                {
                    sql = sql + string.Format(" and a.id<='{0}'", txtid2.Text);
                }
                if (txtmould_id1.Text != "")
                {
                    sql = sql + string.Format(" and a.mould_id>='{0}'", txtmould_id1.Text);
                }
                if (txtmould_id2.Text != "")
                {
                    sql = sql + string.Format(" and a.mould_id<='{0}'", txtmould_id2.Text);
                }
                if (dtcon_date1.Text != "")
                {
                    sql = sql + string.Format(" and a.con_date>='{0}'", clsApp.Return_String_Date(dtcon_date1.Text));
                }
                if (dtcon_date2.Text != "")
                {
                    sql = sql + string.Format(" and a.con_date<='{0}'", clsApp.Return_String_Date(dtcon_date2.Text));
                }
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            dgvDetails.DataSource = dtDetail;
            dgvFind.DataSource = dtDetail;
            if (dtDetail.Rows.Count == 0)
            {
                MessageBox.Show("無滿足查找條件的數據!","提示信息");
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
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Brown,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                row_reset = dgvDetails.CurrentCell.RowIndex;
                dgvrow = dgvDetails.CurrentRow;
                Set_head(dgvrow);
            }
        }

        private void Set_head(DataGridViewRow pdr)
        {
            mID = pdr.Cells["id"].Value.ToString();
            txtID.Text = mID;
            GetVersion();
            lueVer.EditValue = pdr.Cells["ver"].Value.ToString();
            dtcon_date.EditValue = clsApp.Return_String_Date(pdr.Cells["con_date"].Value.ToString()); 
            txtmould_id.Text = pdr.Cells["mould_id"].Value.ToString();
            txtmould_location.Text = pdr.Cells["mould_location"].Value.ToString();  
            dtapplication_date.EditValue = clsApp.Return_String_Date(pdr.Cells["application_date"].Value.ToString());
            dtrequire_finish_date.EditValue = clsApp.Return_String_Date(pdr.Cells["require_finish_date"].Value.ToString());
            txtlister_by.Text = pdr.Cells["lister_by"].Value.ToString();
            txtmo_id.Text = pdr.Cells["mo_id"].Value.ToString();
            txtgoods_id.Text = pdr.Cells["goods_id"].Value.ToString();
            txtgoods_name.Text = pdr.Cells["goods_name"].Value.ToString();
            if(pdr.Cells["sample_yes"].Value.ToString()=="True")
                chksample_yes.Checked = true;
            else
                chksample_yes.Checked = false;
            if (pdr.Cells["sample_no"].Value.ToString() == "True")
                chksample_no.Checked = true;
            else
                chksample_no.Checked = false;
            if (pdr.Cells["md_new"].Value.ToString() == "True")
                chkmd_new.Checked = true;
            else
                chkmd_new.Checked = false;
            if (pdr.Cells["md_reproduced"].Value.ToString() == "True")
                chkmd_reproduced.Checked = true;
            else
                chkmd_reproduced.Checked = false;
            dtuniversal_machine_receive.EditValue =pdr.Cells["universal_machine_receive"].Value.ToString();
            txtuniversal_machine_receive_sign.Text = pdr.Cells["universal_machine_receive_sign"].Value.ToString();
            dtuniversal_machine_md_receive.EditValue = pdr.Cells["universal_machine_md_receive"].Value.ToString();
            txtuniversal_machine_md_receive_sign.Text = pdr.Cells["universal_machine_md_receive_sign"].Value.ToString();
            dtuniversal_machine_test.EditValue = pdr.Cells["universal_machine_test"].Value.ToString();
            txtuniversal_machine_test_sign.Text = pdr.Cells["universal_machine_test_sign"].Value.ToString();
            dtuniversal_machine_confirm.EditValue = pdr.Cells["universal_machine_confirm"].Value.ToString();
            txtuniversal_machine_confirm_sign.Text = pdr.Cells["universal_machine_confirm_sign"].Value.ToString();

            dteye_machine_receive.EditValue = pdr.Cells["eye_machine_receive"].Value.ToString();
            txteye_machine_receive_sign.Text = pdr.Cells["eye_machine_receive_sign"].Value.ToString();
            dteye_machine_md_receive.EditValue = pdr.Cells["eye_machine_md_receive"].Value.ToString();
            txteye_machine_md_receive_sign.Text = pdr.Cells["eye_machine_md_receive_sign"].Value.ToString();
            dteye_machine_test.EditValue = pdr.Cells["eye_machine_test"].Value.ToString();
            txteye_machine_test_sign.Text = pdr.Cells["eye_machine_test_sign"].Value.ToString();
            dteye_machine_confirm.EditValue = pdr.Cells["eye_machine_confirm"].Value.ToString();
            txteye_machine_confirm_sign.Text = pdr.Cells["eye_machine_confirm_sign"].Value.ToString();

            
            memmould_instructions.Text = pdr.Cells["mould_instructions"].Value.ToString();
            memmould_require.Text = pdr.Cells["mould_require"].Value.ToString();
            txtuniversal_machine_receive_sign.Text = pdr.Cells["universal_machine_receive_sign"].Value.ToString();
            txtmould_qty.Text = pdr.Cells["mould_qty"].Value.ToString();
            txtlister_by.Text = pdr.Cells["lister_by"].Value.ToString();            
            txtCreate_by.Text = pdr.Cells["create_by"].Value.ToString();
            if (!string.IsNullOrEmpty(pdr.Cells["create_date"].Value.ToString()))
            {
                txtCreate_date.Text = pdr.Cells["create_date"].Value.ToString();
            }
            txtUpdate_by.Text = pdr.Cells["update_by"].Value.ToString();
            if (!string.IsNullOrEmpty(pdr.Cells["update_date"].Value.ToString()))
            {
                txtUpdate_date.Text = pdr.Cells["update_date"].Value.ToString();
            }
            
            string strArtwork = pdr.Cells["picture_name"].Value.ToString();
            if (!string.IsNullOrEmpty(strArtwork))
            {
                 if (File.Exists(strArtwork))
                    picArtWork.Image = Image.FromFile(strArtwork);
                 else
                    picArtWork.Image = null;
            }
            else
                picArtWork.Image = null;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtid2.Text = txtid1.Text;
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtcon_date2.EditValue = dtcon_date1.EditValue;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount ==0)
            {
                MessageBox.Show("沒有要列印的數據！","提示信息");
                return;
            }

            if (chkPrintAll.Checked == false)
            {
                string ls_sql = string.Format(
                @"SELECT A.*,B.name as goods_name,dbo.fn_get_picture_name_of_artwork('0000',Substring(A.goods_id,5,7),'OUT') AS picture_name 
                From dbo.jo_mould_button A with(nolock),{0}it_goods B with(nolock) 
                Where A.goods_id COLLATE Chinese_PRC_CI_AS = B.id and A.id='{1}' and A.ver='{2}'", DBUtility.remote_db, txtID.Text,lueVer.Text);
                DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
                using (xrMould_Process rpt = new xrMould_Process() { DataSource = dt })
                {
                    rpt.CreateDocument();
                    rpt.PrintingSystem.ShowMarginsWarning = false;
                    rpt.ShowPreviewDialog();
                }
                return;
            }
            
            using (xrMould_Process rpt = new xrMould_Process() { DataSource = dtDetail })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
            }
        }     
 

        private void dgvFind_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }
            tabControl1.SelectedIndex = 0;
        }

        #region ReSet_Datagrid_Value()
        /// <summary>
        /// 新增或編號時更新Datagridview的值
        /// 不必從服務端重新下載
        /// </summary>
        private void ReSet_Datagrid_Value()
        {
            if (mState == "NEW" || mState == "EDIT")
            {
                //取得當前新增或修改的行
                dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select id,create_by,create_date,update_by,update_date From dbo.jo_mould_button WHERE id='{0}'", txtID.Text ));
                if (mState == "NEW")
                {
                
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["id"] = txtID.Text ;
                    row["ver"] = lueVer.EditValue.ToString();
                    row["con_date"] = dtcon_date.Text;
                    if (!string.IsNullOrEmpty(dtrequire_finish_date.Text))
                    {
                        row["require_finish_date"] = clsApp.Return_String_Date(dtrequire_finish_date.Text);
                    }
                    row["goods_id"] = txtgoods_id.Text;
                    row["mould_id"] = txtmould_id.Text;
                    row["mould_location"] = txtmould_location.Text;
                    if (!string.IsNullOrEmpty(dtapplication_date.Text))
                    {
                        row["application_date"] = clsApp.Return_String_Date(dtapplication_date.Text);
                    }
                    row["sample_yes"] = chksample_yes.Checked ? true : false;
                    row["sample_no"] = chksample_no.Checked ? true : false;
                    row["md_new"] = chkmd_new.Checked ? true : false;
                    row["md_reproduced"] = chkmd_reproduced.Checked ? true : false;
                    row["lister_by"] = txtlister_by.Text;
                    row["mo_id"] = txtmo_id.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_receive.Text))
                    {
                        row["universal_machine_receive"] = DateTime.Parse(dtuniversal_machine_receive.Text);
                    }
                    row["universal_machine_receive_sign"] = txtuniversal_machine_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_md_receive.Text))
                    {
                        row["universal_machine_md_receive"] = DateTime.Parse(dtuniversal_machine_md_receive.Text);
                    }
                    row["universal_machine_md_receive_sign"] = txtuniversal_machine_md_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_test.Text))
                    {
                        row["universal_machine_test"] = DateTime.Parse(dtuniversal_machine_test.Text);
                    }
                    row["universal_machine_test_sign"] = txtuniversal_machine_test_sign.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_confirm.Text))
                    {
                        row["universal_machine_confirm"] = DateTime.Parse(dtuniversal_machine_confirm.Text);
                    }
                    row["universal_machine_test_sign"] = txtuniversal_machine_confirm_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_receive.Text))
                    {
                        row["eye_machine_receive"] = DateTime.Parse(dteye_machine_receive.Text);
                    }
                    row["eye_machine_receive_sign"] = txteye_machine_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_md_receive.Text))
                    {
                        row["eye_machine_md_receive"] = DateTime.Parse(dteye_machine_md_receive.Text);
                    }
                    row["eye_machine_md_receive_sign"] = txteye_machine_md_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_test.Text))
                    {
                        row["eye_machine_test"] = DateTime.Parse(dteye_machine_test.Text);
                    }
                    row["eye_machine_test_sign"] = txteye_machine_test_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_confirm.Text))
                    {
                        row["eye_machine_confirm"] = DateTime.Parse(dteye_machine_confirm.Text);
                    }
                    row["eye_machine_test_sign"] = txteye_machine_confirm_sign.Text;
                    row["mould_instructions"] = memmould_instructions.Text;
                    row["mould_require"] = memmould_require.Text;
                    row["drawing_no"] = txtdrawing_no.Text;
                    row["mould_qty"] = txtmould_qty.Text==""?0:Int32.Parse(txtmould_qty.Text);
                    row["create_by"] = dtReSet.Rows[0]["create_by"].ToString();
                    row["create_date"] = dtReSet.Rows[0]["create_date"].ToString();
                    dtDetail.Rows.Add(row);
                }
                else
                {                   
                    dtDetail.Rows[row_reset]["id"] = txtID.Text;
                    dtDetail.Rows[row_reset]["ver"] = lueVer.EditValue.ToString();
                    dtDetail.Rows[row_reset]["con_date"] = dtcon_date.Text;
                    if (!string.IsNullOrEmpty(dtrequire_finish_date.Text))
                    {
                        dtDetail.Rows[row_reset]["require_finish_date"] = dtrequire_finish_date.Text;
                    }
                    dtDetail.Rows[row_reset]["goods_id"] = txtgoods_id.Text;
                    dtDetail.Rows[row_reset]["mould_id"] = txtmould_id.Text;
                    dtDetail.Rows[row_reset]["mould_location"] = txtmould_location.Text;
                    if (!string.IsNullOrEmpty(dtapplication_date.Text))
                    {
                        dtDetail.Rows[row_reset]["application_date"] = dtapplication_date.Text;
                    }
                    dtDetail.Rows[row_reset]["sample_yes"] = chksample_yes.Checked ? true : false;
                    dtDetail.Rows[row_reset]["sample_no"] = chksample_no.Checked ? true : false;
                    dtDetail.Rows[row_reset]["md_new"] = chkmd_new.Checked ? true : false;
                    dtDetail.Rows[row_reset]["md_reproduced"] = chkmd_reproduced.Checked ? true : false;
                    dtDetail.Rows[row_reset]["lister_by"] = txtlister_by.Text;
                    dtDetail.Rows[row_reset]["mo_id"] = txtmo_id.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_receive.Text))
                    {
                        dtDetail.Rows[row_reset]["universal_machine_receive"] = DateTime.Parse(dtuniversal_machine_receive.Text);
                    }
                    //dtDetail.Rows[row_reset]["universal_machine_receive_sgin"] = txtuniversal_machine_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_md_receive.Text))
                    {
                        dtDetail.Rows[row_reset]["universal_machine_md_receive"] = DateTime.Parse(dtuniversal_machine_md_receive.Text);
                    }
                    dtDetail.Rows[row_reset]["universal_machine_md_receive_sign"] = txtuniversal_machine_md_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_test.Text))
                    {
                        dtDetail.Rows[row_reset]["universal_machine_test"] = DateTime.Parse(dtuniversal_machine_test.Text);
                    }
                    dtDetail.Rows[row_reset]["universal_machine_test_sign"] = txtuniversal_machine_test_sign.Text;
                    if (!string.IsNullOrEmpty(dtuniversal_machine_confirm.Text))
                    {
                        dtDetail.Rows[row_reset]["universal_machine_confirm"] = DateTime.Parse(dtuniversal_machine_confirm.Text);
                    }
                    dtDetail.Rows[row_reset]["universal_machine_confirm_sign"] = txtuniversal_machine_confirm_sign.Text;
                    
                    if (!string.IsNullOrEmpty(dteye_machine_receive.Text))
                    {
                        dtDetail.Rows[row_reset]["eye_machine_receive"] = DateTime.Parse(dteye_machine_receive.Text);
                    }
                    dtDetail.Rows[row_reset]["eye_machine_receive_sign"] = txteye_machine_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_md_receive.Text))
                    {
                        dtDetail.Rows[row_reset]["eye_machine_md_receive"] = DateTime.Parse(dteye_machine_md_receive.Text);
                    }
                    dtDetail.Rows[row_reset]["eye_machine_md_receive_sign"] = txteye_machine_md_receive_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_test.Text))
                    {
                        dtDetail.Rows[row_reset]["eye_machine_test"] = DateTime.Parse(dteye_machine_test.Text);
                    }
                    dtDetail.Rows[row_reset]["eye_machine_test_sign"] = txteye_machine_test_sign.Text;
                    if (!string.IsNullOrEmpty(dteye_machine_confirm.Text))
                    {
                        dtDetail.Rows[row_reset]["eye_machine_confirm"] = DateTime.Parse(dteye_machine_confirm.Text);
                    }
                    dtDetail.Rows[row_reset]["eye_machine_confirm_sign"] = txteye_machine_confirm_sign.Text;
                    dtDetail.Rows[row_reset]["mould_instructions"] = memmould_instructions.Text;
                    dtDetail.Rows[row_reset]["mould_require"] = memmould_require.Text;
                    dtDetail.Rows[row_reset]["drawing_no"] = txtdrawing_no.Text;
                    dtDetail.Rows[row_reset]["mould_qty"] = txtmould_qty.Text == "" ? 0 : Int32.Parse(txtmould_qty.Text);
                    dtDetail.Rows[row_reset]["update_by"] = dtReSet.Rows[0]["update_by"].ToString();
                    dtDetail.Rows[row_reset]["update_date"] = dtReSet.Rows[0]["update_date"].ToString();
                }
                dtDetail.AcceptChanges();
                dgvDetails.DataSource = dtDetail;//
                dgvDetails.Refresh();//
            }
        }
        #endregion

        private void txtID_Leave(object sender, EventArgs e)
        {
            //Valid_Draw_No();
            if (mState == "NEW" && txtID.Text != "")
            {
                GetVersion();
            }                
        }

        private void Valid_Draw_No()
        {
            if (mState == "NEW" && txtID.Text !="" && lueVer.Text !="")
            {
                string ls_sql =
                string.Format(
                @"Select Top 1 A.id,Convert(varchar(10),A.update_date,120) AS application_date,B.mo_id,B.goods_id,
                dbo.fn_get_mould_mo(B.id,B.ver) AS str_mo,ISNULL(C.draw_remark,'') As mould_request,D.name As goods_name 
                FROM {0}so_mould_notice_mostly A with(nolock)
                INNER JOIN {0}so_mould_notice_goods B with(nolock) ON A.within_code=B.within_code and A.id=B.id and A.ver=B.ver and B.sequence_id ='0001h'
                INNER JOIN {0}so_draw_master C with(nolock) ON A.within_code=C.within_code and A.mould_no=C.id and A.draw_ver=C.ver
                INNER JOIN {0}it_goods D with(nolock) ON B.within_code=D.within_code and B.goods_id=D.id 
                WHERE A.mould_no='{1}' And A.draw_ver='{2}'
                ORDER BY A.bill_date DESC", DBUtility.remote_db, txtID.Text,lueVer.EditValue.ToString());
                DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
                if (dt.Rows.Count > 0)
                {
                    txtmould_id.Text = dt.Rows[0]["id"].ToString();
                    txtgoods_id.Text = dt.Rows[0]["goods_id"].ToString();
                    txtgoods_name.Text = dt.Rows[0]["goods_name"].ToString();
                    dtapplication_date.EditValue = dt.Rows[0]["application_date"].ToString();
                    if (dt.Rows[0]["mould_request"].ToString() != "")
                        memmould_require.Text = string.Format("{0}\r\n{1}", dt.Rows[0]["mould_request"], dt.Rows[0]["str_mo"]);
                    else
                        memmould_require.Text = dt.Rows[0]["str_mo"].ToString();
                }
                else
                {
                    txtmould_id.Text = "";
                    txtgoods_id.Text = "";
                    txtgoods_name.Text = "";
                    dtapplication_date.EditValue = "";
                    memmould_require.Text = "";
                    MessageBox.Show("沒有做模通知書或者畫稿編碼不存在！請返回檢查！", "提示信息");
                    txtID.Focus();
                }
            }
        }

        private void GetVersion()
        {
            if (txtID.Text != "")
            {
                string strSql = string.Format(@"Select draw_ver as id From {0}so_mould_notice_mostly Where mould_no='{1}'", DBUtility.remote_db, txtID.Text);
                DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
                lueVer.Properties.DataSource = dt;
                lueVer.Properties.ValueMember = "id";
                lueVer.Properties.DisplayMember = "id";
            }
        }

        private void txtgoods_id_Leave(object sender, EventArgs e)
        {
            if (mState != "" )
            {
                if (txtgoods_id.Text != "")
                {
                    string ls_sql = string.Format(@"Select name FROM dbo.geo_it_goods Where id='{0}'", txtgoods_id.Text);
                    string result=clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql);
                    if (result != "")
                        txtgoods_name.Text = result;
                    else
                    {
                        txtgoods_name.Text = "";
                        MessageBox.Show("貨品編碼不存在！請返回檢查！", "提示信息");
                        txtgoods_id.Focus();
                    }
                }
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel2.Controls) > 0)
                clsUtility.myMessageBox("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            //判段某個按鈕是否已被點擊
            //以下代碼為當保存按鈕被點擊時前進行數據的有效性檢查
            if (btnSave.Selected)
            {
                Valid_Draw_No();
            }
        }

        private void lueVer_Leave(object sender, EventArgs e)
        {
            if (mState == "NEW")
            {
                Valid_Draw_No();
            }
        }
    }
}
