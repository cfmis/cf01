/*
 * Create by :   Allen Leung
 * Create Date : 2019-05-10
 * remark:
 * 扣部——新模廢料查詢表
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
    public partial class frmBkWaste : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        DataTable dtReSet = new DataTable();
        public string mState = ""; 
        clsToolBarNew objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        public clsPublicOfGEO clsErp = new clsPublicOfGEO();
        private DataGridViewRow dgvrow = new DataGridViewRow();
        

        public frmBkWaste()
        {
            InitializeComponent();
            dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmBkWaste_Load(object sender, EventArgs e)
        {
            //生成表結構
            const string ls_sql = @"SELECT * From dbo.jo_buckle_waste where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(ls_sql);

            Find_Data();
            if (dgvDetails.Rows.Count >= 2)
            {
                dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.Rows.Count - 1].Cells[0];
                dgvDetails.BeginEdit(true);
                dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true; //選中整行
            }
        }

        private void SetButtonSatus(bool _flag)
        {
            btnNew.Enabled = _flag;
            btnEdit.Enabled = _flag;
            btnDelete.Enabled = _flag;
            BTNNEWCOPY.Enabled = _flag;
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
            txtID.Text = clsPur.getSerialNo("jo_buckle_waste");           
            dtcon_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();
            //dtcon_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            txtmould_no.Focus();
        }

        private void Save()
        {
            txtID.Focus();
            if (txtartwork.Text == "" || dtcon_date.Text == "")
            {
                MessageBox.Show("圖樣代碼,入單日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (txtartwork.Text == "")
                {
                    txtartwork.Focus();
                    return;
                }
                if (dtcon_date.Text == "")
                    dtcon_date.Focus();                
                return;
            }
            
            //新增時判斷主鍵是否已存在
            //if (mState == "NEW")
            //{
            //    if (!Valid_Date())
            //    {
            //        return;
            //    }
            //}

            //bds1.EndEdit();
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO jo_buckle_waste(id,con_date,no_id,mould_no,mould_ver,mo_id_list,goods_id,goods_name,artwork,mat_desc,mould_test_time,
                dept_202_diecast_mac,dept_202_diecast_auto,dept_202_buckle,dept_203_assy,dept_203_diecast_hand,dept_206_diecast_mac,
                wt_base,wt_base_waste,wt_base_real,rate_by_kgs,waste,qty_by_kgs,qty_process1,qty_process2,qty_process3,qty_process4,qty_process5,
                qty_order,wt_use,line_no_desc,remark,state,create_by,create_date)
             VALUES(@id,@con_date,@no_id,@mould_no,@mould_ver,@mo_id_list,@goods_id,@goods_name,@artwork,@mat_desc,@mould_test_time,
                @dept_202_diecast_mac,@dept_202_diecast_auto,@dept_202_buckle,@dept_203_assy,@dept_203_diecast_hand,@dept_206_diecast_mac,
                @wt_base,@wt_base_waste,@wt_base_real,@rate_by_kgs,@waste,@qty_by_kgs,@qty_process1,@qty_process2,@qty_process3,@qty_process4,@qty_process5,
                @qty_order,@wt_use,@line_no_desc,@remark,0,@user_id,getdate())";
            const string sql_update =
            @"Update jo_buckle_waste 
                SET con_date=@con_date,no_id=@no_id,mould_no=@mould_no,mould_ver=@mould_ver,mo_id_list=@mo_id_list,goods_id=@goods_id,goods_name=@goods_name,
                    artwork=@artwork,mat_desc=@mat_desc,mould_test_time=@mould_test_time,dept_202_diecast_mac=@dept_202_diecast_mac,dept_202_diecast_auto=@dept_202_diecast_auto,
                    dept_202_buckle=@dept_202_buckle,dept_203_assy=@dept_203_assy,dept_203_diecast_hand=@dept_203_diecast_hand,dept_206_diecast_mac=@dept_206_diecast_mac,
                    wt_base=@wt_base,wt_base_waste=@wt_base_waste,wt_base_real=@wt_base_real,rate_by_kgs=@rate_by_kgs,waste=@waste,qty_by_kgs=@qty_by_kgs,qty_process1=@qty_process1,
                    qty_process2=@qty_process2,qty_process3=@qty_process3,qty_process4=@qty_process4,qty_process5=@qty_process5,qty_order=@qty_order,wt_use=@wt_use,line_no_desc=@line_no_desc,
                    remark=@remark,update_by=@user_id,update_date=getdate()
            WHERE id=@id"; 

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            string strSerial_no;
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();                    
                    if (mState == "NEW")
                    {
                        myCommand.CommandText = sql_new;                       
                        strSerial_no = clsPur.getSerialNo("jo_buckle_waste");
                        txtID.Text = strSerial_no;   
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text);
                    myCommand.Parameters.AddWithValue("@con_date", clsApp.Return_String_Date(dtcon_date.Text));
                    myCommand.Parameters.AddWithValue("@no_id", txtno_id.Text);
                    myCommand.Parameters.AddWithValue("@mould_no", txtmould_no.Text);
                    myCommand.Parameters.AddWithValue("@mould_ver", txtmould_ver.Text);
                    myCommand.Parameters.AddWithValue("@mo_id_list", txtmo_id_list.Text);
                    myCommand.Parameters.AddWithValue("@artwork", txtartwork.Text);
                    myCommand.Parameters.AddWithValue("@goods_id", cmbgoods_id.Text);
                    myCommand.Parameters.AddWithValue("@goods_name", txtgoods_name.Text);
                    myCommand.Parameters.AddWithValue("@mat_desc", txtmat_desc.Text);
                    myCommand.Parameters.AddWithValue("@mould_test_time", txtmould_test_time.Text);
                    myCommand.Parameters.AddWithValue("@dept_202_diecast_mac", Chkdept_202_diecast_mac.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dept_202_diecast_auto", Chkdept_202_diecast_auto.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dept_202_buckle", Chkdept_202_buckle.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dept_203_assy", Chkdept_203_assy.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dept_203_diecast_hand", Chkdept_203_diecast_hand.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dept_206_diecast_mac", Chkdept_206_diecast_mac.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@wt_base", clsApp.Return_Float_Value(txtwt_base.Text));
                    myCommand.Parameters.AddWithValue("@wt_base_waste", clsApp.Return_Float_Value(txtwt_base_waste.Text));
                    myCommand.Parameters.AddWithValue("@wt_base_real", clsApp.Return_Float_Value(txtwt_base_real.Text));
                    myCommand.Parameters.AddWithValue("@rate_by_kgs", txtrate_by_kgs.Text == "" ? 0 : clsApp.Return_Float_Value(txtrate_by_kgs.Text));
                    myCommand.Parameters.AddWithValue("@waste", clsApp.Return_Float_Value(txtwaste.Text));
                    myCommand.Parameters.AddWithValue("@qty_by_kgs", txtqty_by_kgs.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_by_kgs.Text));
                    myCommand.Parameters.AddWithValue("@qty_order", txtqty_order.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_order.Text));
                    myCommand.Parameters.AddWithValue("@wt_use", clsApp.Return_Float_Value(txtwt_use.Text));
                    myCommand.Parameters.AddWithValue("@qty_process1", txtqty_process1.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_process1.Text));
                    myCommand.Parameters.AddWithValue("@qty_process2", txtqty_process2.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_process2.Text));
                    myCommand.Parameters.AddWithValue("@qty_process3", txtqty_process3.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_process3.Text));
                    myCommand.Parameters.AddWithValue("@qty_process4", txtqty_process4.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_process4.Text));
                    myCommand.Parameters.AddWithValue("@qty_process5", txtqty_process5.Text == "" ? 0 : clsApp.Return_Float_Value(txtqty_process5.Text));
                    myCommand.Parameters.AddWithValue("@line_no_desc", txtline_no_desc.Text);
                    myCommand.Parameters.AddWithValue("@remark", txtremark.Text);                    
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
                clsUtility.myMessageBox("數據保存成功!", "提示信息");                
            }
            else
            {                
               MessageBox.Show("數據保存失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);                
            }
        }

        ///// <summary>
        ///// 新增時判斷主鍵是否已存在
        ///// </summary>
        ///// <returns></returns>
        //private bool Valid_Date()
        //{
        //    bool result=false ;
        //    string ls_sql = string.Format(@"Select '1' From dbo.jo_buckle_waste Where id='{0}'", txtID.Text);
        //    if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql) == "")
        //        result = true ;
        //    else
        //        result = false;
        //    return result;
        //}

        private void Delete()
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string ls_delete_id = txtID.Text;
                const string sql_del = "DELETE FROM dbo.jo_buckle_waste WHERE id=@id";
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
                    if (dgvFind.Rows[i].Cells["id1"].Value.ToString() == ls_delete_id)
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
            txtID.Focus();
            dgvDetails.Enabled = false;
        }

        private void frmBkWaste_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();               
           objToolbar = null;
           clsApp = null;
           clsErp = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtremark.Focus();
            Edit();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {           
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);           
            dgvDetails.Enabled = true;
            mState = "";
            txtID.Properties.ReadOnly = true;

            if (!String.IsNullOrEmpty(mID) && dgvDetails.RowCount > 0)
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
            string sql = @"SELECT *,dbo.fn_get_picture_name_of_artwork('0000',artwork,'OUT') as picture_name FROM dbo.jo_buckle_waste With(nolock) WHERE id>'' ";
            if (txtartwork1.Text == "" && dtcon_date1.Text == "" && dtcon_date2.Text == "" && txtmo_id1.Text=="" && txtmo_id2.Text=="")
                sql = @"SELECT *,dbo.fn_get_picture_name_of_artwork('0000',artwork,'OUT') as picture_name FROM dbo.jo_buckle_waste With(nolock) ORDER BY id";
            else
            {                
                if (txtartwork1.Text != "")
                {
                    sql = sql + string.Format(" and artwork like '%{0}%'", txtartwork1.Text);
                }               
                if (dtcon_date1.Text != "")
                {
                    sql = sql + string.Format(" and con_date>='{0}'", clsApp.Return_String_Date(dtcon_date1.Text));
                }
                if (dtcon_date2.Text != "")
                {
                    sql = sql + string.Format(" and con_date<='{0}'", clsApp.Return_String_Date(dtcon_date2.Text));
                }
                if (txtmo_id1.Text != "")
                {
                    sql = sql + string.Format(" and mo_id_list >='{0}'", txtmo_id1.Text);
                }
                if (txtmo_id2.Text != "")
                {
                    sql = sql + string.Format(" and mo_id_list <='{0}'", txtmo_id2.Text);
                }
                if (txtmould_id1.Text != "")
                {
                    sql = sql + string.Format(" and mould_id like '%{0}%'", txtmould_id1.Text);
                }
                sql = sql + " order by id";
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            dgvDetails.DataSource = dtDetail;
            dgvFind.DataSource = dtDetail;
            if (dtDetail.Rows.Count == 0)
            {
                //MessageBox.Show("無滿足查找條件的數據!","提示信息");
                clsUtility.myMessageBox("無滿足查找條件的數據!", "提示信息");
            }
        }

        //private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    //產生行號
        //    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
        //        e.RowBounds.Location.Y,
        //        dgvDetails.RowHeadersWidth - 4,
        //        e.RowBounds.Height);

        //    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
        //        dgvDetails.RowHeadersDefaultCellStyle.Font,
        //        rectangle,
        //        dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Brown,
        //        TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        //}

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
            dtcon_date.EditValue = clsApp.Return_String_Date(pdr.Cells["con_date"].Value.ToString());
            txtno_id.Text = pdr.Cells["no_id"].Value.ToString();
            txtmould_no.Text = pdr.Cells["mould_no"].Value.ToString();
            txtmould_ver.Text = pdr.Cells["mould_ver"].Value.ToString();
            txtmo_id_list.Text = pdr.Cells["mo_id_list"].Value.ToString();
            txtartwork.Text = pdr.Cells["artwork"].Value.ToString();
            cmbgoods_id.Text = pdr.Cells["goods_id"].Value.ToString();
            txtgoods_name.Text = pdr.Cells["goods_name"].Value.ToString();
            txtmat_desc.Text = pdr.Cells["mat_desc"].Value.ToString();
            txtmould_test_time.Text = pdr.Cells["mould_test_time"].Value.ToString();
            Chkdept_202_diecast_mac.Checked = pdr.Cells["mould_test_time"].Value.ToString() == "True" ? true : false;
            Chkdept_202_diecast_auto.Checked = pdr.Cells["dept_202_diecast_auto"].Value.ToString() == "True" ? true : false;
            Chkdept_202_buckle.Checked = pdr.Cells["dept_202_buckle"].Value.ToString() == "True" ? true : false;
            Chkdept_203_assy.Checked = pdr.Cells["dept_203_assy"].Value.ToString() == "True" ? true : false;
            Chkdept_203_diecast_hand.Checked = pdr.Cells["dept_203_diecast_hand"].Value.ToString() == "True" ? true : false;
            Chkdept_206_diecast_mac.Checked = pdr.Cells["dept_206_diecast_mac"].Value.ToString() == "True" ? true : false;
            txtwt_base.Text = pdr.Cells["wt_base"].Value.ToString();
            txtwt_base_waste.Text = pdr.Cells["wt_base_waste"].Value.ToString();
            txtwt_base_real.Text = pdr.Cells["wt_base_real"].Value.ToString();
            txtrate_by_kgs.Text = pdr.Cells["rate_by_kgs"].Value.ToString();
            txtwaste.Text = pdr.Cells["waste"].Value.ToString();
            txtqty_by_kgs.Text = pdr.Cells["qty_by_kgs"].Value.ToString();
            txtqty_order.Text = pdr.Cells["qty_order"].Value.ToString();
            txtwt_use.Text = pdr.Cells["wt_use"].Value.ToString();
            txtqty_process1.Text = pdr.Cells["qty_process1"].Value.ToString();
            txtqty_process2.Text = pdr.Cells["qty_process2"].Value.ToString();
            txtqty_process3.Text = pdr.Cells["qty_process3"].Value.ToString();
            txtqty_process4.Text = pdr.Cells["qty_process4"].Value.ToString();
            txtqty_process5.Text = pdr.Cells["qty_process5"].Value.ToString();
            txtline_no_desc.Text = pdr.Cells["line_no_desc"].Value.ToString();            
            txtremark.Text = pdr.Cells["remark"].Value.ToString();

            if (!string.IsNullOrEmpty(pdr.Cells["create_date"].Value.ToString()))
            {
                txtCreate_date.Text = pdr.Cells["create_date"].Value.ToString();
            }
            txtUpdate_by.Text = pdr.Cells["update_by"].Value.ToString();
            if (!string.IsNullOrEmpty(pdr.Cells["update_date"].Value.ToString()))
            {
                txtUpdate_date.Text = pdr.Cells["update_date"].Value.ToString();
            }
           
            Set_Art_Work(pdr.Cells["picture_name"].Value.ToString());

        }      

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtcon_date2.EditValue = dtcon_date1.EditValue;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("沒有要列印的數據！", "提示信息");
                return;
            }
            using (xrPurDelivery rpt = new xrPurDelivery(dtcon_date1.Text, dtcon_date2.Text) { DataSource = dtDetail })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
            }
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
                string ls_sql =string.Format(@"Select id,create_by,create_date,update_by,update_date From dbo.jo_buckle_waste with(nolock) WHERE id='{0}'",txtID.Text);
                dtReSet = clsPublicOfCF01.GetDataTable(ls_sql);
                if (mState == "NEW")
                {
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["id"] = txtID.Text;
                    row["con_date"] = dtcon_date.Text;
                    row["no_id"] = txtno_id.Text;
                    row["mould_no"] = txtmould_no.Text;
                    row["mould_ver"] = txtmould_ver.Text;
                    row["mo_id_list"] = txtmo_id_list.Text;
                    row["artwork"] = txtartwork.Text;
                    row["goods_id"] = cmbgoods_id.Text;
                    row["goods_name"] = txtgoods_name.Text;
                    row["mat_desc"] = txtmat_desc.Text;
                    row["mould_test_time"] = txtmould_test_time.Text;
                    row["dept_202_diecast_mac"] = Chkdept_202_diecast_mac.Checked;
                    row["dept_202_diecast_auto"] = Chkdept_202_diecast_auto.Checked;
                    row["dept_202_buckle"] = Chkdept_202_buckle.Checked;
                    row["dept_203_assy"] = Chkdept_203_assy.Checked;
                    row["dept_203_diecast_hand"] = Chkdept_203_diecast_hand.Checked;
                    row["dept_206_diecast_mac"] = Chkdept_206_diecast_mac.Checked;
                    row["wt_base"] =clsApp.Return_Float_Value(txtwt_base.Text);
                    row["wt_base_waste"] = clsApp.Return_Float_Value(txtwt_base_waste.Text);
                    row["wt_base_real"] = clsApp.Return_Float_Value(txtwt_base_real.Text);
                    row["rate_by_kgs"] = clsApp.Return_Float_Value(txtrate_by_kgs.Text);
                    row["waste"] = clsApp.Return_Float_Value(txtwaste.Text);
                    row["qty_by_kgs"] = clsApp.Return_Float_Value(txtqty_by_kgs.Text);
                    row["qty_order"] = clsApp.Return_Float_Value(txtqty_order.Text);
                    row["wt_use"] = clsApp.Return_Float_Value(txtwt_use.Text);
                    row["qty_process1"] = clsApp.Return_Float_Value(txtqty_process1.Text);
                    row["qty_process2"] = clsApp.Return_Float_Value(txtqty_process2.Text);
                    row["qty_process3"] = clsApp.Return_Float_Value(txtqty_process3.Text);
                    row["qty_process4"] = clsApp.Return_Float_Value(txtqty_process4.Text);
                    row["qty_process5"] = clsApp.Return_Float_Value(txtqty_process5.Text);
                    row["line_no_desc"] = txtline_no_desc.Text;                   
                    row["remark"] = txtremark.Text;
                    row["create_by"] = DBUtility._user_id;
                    row["create_date"] = dtReSet.Rows[0]["create_date"].ToString();
                    dtDetail.Rows.Add(row);
                }
                else
                {  
                    dtDetail.Rows[row_reset]["id"] = txtID.Text;
                    dtDetail.Rows[row_reset]["con_date"] = dtcon_date.Text;
                    dtDetail.Rows[row_reset]["no_id"] = txtno_id.Text;
                    dtDetail.Rows[row_reset]["mould_no"] = txtmould_no.Text;
                    dtDetail.Rows[row_reset]["mould_ver"] = txtmould_ver.Text;
                    dtDetail.Rows[row_reset]["mo_id_list"] = txtmo_id_list.Text;
                    dtDetail.Rows[row_reset]["artwork"] = txtartwork.Text;
                    dtDetail.Rows[row_reset]["goods_id"] = cmbgoods_id.Text;
                    dtDetail.Rows[row_reset]["goods_name"] = txtgoods_name.Text;
                    dtDetail.Rows[row_reset]["mat_desc"] = txtmat_desc.Text;
                    dtDetail.Rows[row_reset]["mould_test_time"] = txtmould_test_time.Text;
                    dtDetail.Rows[row_reset]["dept_202_diecast_mac"] = Chkdept_202_diecast_mac.Checked;
                    dtDetail.Rows[row_reset]["dept_202_diecast_auto"] = Chkdept_202_diecast_auto.Checked;
                    dtDetail.Rows[row_reset]["dept_202_buckle"] = Chkdept_202_buckle.Checked;
                    dtDetail.Rows[row_reset]["dept_203_assy"] = Chkdept_203_assy.Checked;
                    dtDetail.Rows[row_reset]["dept_203_diecast_hand"] = Chkdept_203_diecast_hand.Checked;
                    dtDetail.Rows[row_reset]["dept_206_diecast_mac"] = Chkdept_206_diecast_mac.Checked;
                    dtDetail.Rows[row_reset]["wt_base"] = clsApp.Return_Float_Value(txtwt_base.Text);
                    dtDetail.Rows[row_reset]["wt_base_waste"] = clsApp.Return_Float_Value(txtwt_base_waste.Text);
                    dtDetail.Rows[row_reset]["wt_base_real"] = clsApp.Return_Float_Value(txtwt_base_real.Text);
                    dtDetail.Rows[row_reset]["rate_by_kgs"] = clsApp.Return_Float_Value(txtrate_by_kgs.Text);
                    dtDetail.Rows[row_reset]["waste"] = clsApp.Return_Float_Value(txtwaste.Text);
                    dtDetail.Rows[row_reset]["qty_by_kgs"] = clsApp.Return_Float_Value(txtqty_by_kgs.Text);
                    dtDetail.Rows[row_reset]["qty_order"] = clsApp.Return_Float_Value(txtqty_order.Text);
                    dtDetail.Rows[row_reset]["wt_use"] = clsApp.Return_Float_Value(txtwt_use.Text);
                    dtDetail.Rows[row_reset]["qty_process1"] = clsApp.Return_Float_Value(txtqty_process1.Text);
                    dtDetail.Rows[row_reset]["qty_process2"] = clsApp.Return_Float_Value(txtqty_process2.Text);
                    dtDetail.Rows[row_reset]["qty_process3"] = clsApp.Return_Float_Value(txtqty_process3.Text);
                    dtDetail.Rows[row_reset]["qty_process4"] = clsApp.Return_Float_Value(txtqty_process4.Text);
                    dtDetail.Rows[row_reset]["qty_process5"] = clsApp.Return_Float_Value(txtqty_process5.Text);
                    dtDetail.Rows[row_reset]["line_no_desc"] = txtline_no_desc.Text;                    
                    dtDetail.Rows[row_reset]["remark"] = txtremark.Text;
                    dtDetail.Rows[row_reset]["update_by"] = DBUtility._user_id;
                    dtDetail.Rows[row_reset]["update_date"] = dtReSet.Rows[0]["update_date"].ToString();
                }
                dtDetail.AcceptChanges();
                dgvDetails.DataSource = dtDetail;
                dgvDetails.Refresh();
            }
        }
        #endregion

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel2.Controls) > 0)
                clsUtility.myMessageBox("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            ////判段某個按鈕是否已被點擊
            ////以下代碼為當保存按鈕被點擊時前進行數據的有效性檢查
            //if (btnSave.Selected)
            //{
            //    //Valid_Draw_No();
            //}
            Valid_goods_id();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (mState != "")
            {
                return;
            }
            if (dgvFind.RowCount == 0)
            {
                MessageBox.Show("沒有要匯出的數據！", "提示信息");
                return;
            }
            ExpToExcel obj = new ExpToExcel();
            obj.ExportExcel(dgvFind);
            obj = null;
        }

        private void txtdelivery_no1_Leave(object sender, EventArgs e)
        {
            txtmo_id2.Text = txtmo_id1.Text;
        }
   
        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                tabControl1.SelectTab(0);
                Int32 cur_row = dgvDetails.CurrentCell.RowIndex;
                AddNew();               
                Set_head(cur_row);
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //復制新增用到此方法
        private void Set_head(int pRow)
        {            
            dtcon_date.EditValue = DateTime.Parse(dtDetail.Rows[pRow]["con_date"].ToString()).Date.ToString("yyyy-MM-dd");
            txtmould_no.Text = dtDetail.Rows[pRow]["ould_no"].ToString();
            txtno_id.Text = dtDetail.Rows[pRow]["no_id"].ToString();
            txtmould_ver.Text = dtDetail.Rows[pRow]["ould_ver"].ToString();
            txtmo_id_list.Text = dtDetail.Rows[pRow]["mo_id_list"].ToString();
            txtartwork.Text = dtDetail.Rows[pRow]["artwork"].ToString();
            cmbgoods_id.Text = dtDetail.Rows[pRow]["goods_id"].ToString();
            txtgoods_name.Text = dtDetail.Rows[pRow]["goods_name"].ToString();
            txtmat_desc.Text = dtDetail.Rows[pRow]["mat_desc"].ToString();
            txtmould_test_time.Text = dtDetail.Rows[pRow]["mould_test_time"].ToString();
            Chkdept_202_diecast_mac.Checked = dtDetail.Rows[pRow]["mould_test_time"].ToString() == "True" ? true : false;
            Chkdept_202_diecast_auto.Checked = dtDetail.Rows[pRow]["dept_202_diecast_auto"].ToString() == "True" ? true : false;
            Chkdept_202_buckle.Checked = dtDetail.Rows[pRow]["dept_202_buckle"].ToString() == "True" ? true : false;
            Chkdept_203_assy.Checked = dtDetail.Rows[pRow]["dept_203_assy"].ToString() == "True" ? true : false;
            Chkdept_203_diecast_hand.Checked = dtDetail.Rows[pRow]["dept_203_diecast_hand"].ToString() == "True" ? true : false;
            Chkdept_206_diecast_mac.Checked = dtDetail.Rows[pRow]["dept_206_diecast_mac"].ToString() == "True" ? true : false;
            txtwt_base.Text = dtDetail.Rows[pRow]["wt_base"].ToString();
            txtwt_base_waste.Text = dtDetail.Rows[pRow]["wt_base_waste"].ToString();
            txtwt_base_real.Text = dtDetail.Rows[pRow]["wt_base_real"].ToString();
            txtrate_by_kgs.Text = dtDetail.Rows[pRow]["rate_by_kgs"].ToString();
            txtwaste.Text = dtDetail.Rows[pRow]["waste"].ToString();
            txtqty_by_kgs.Text = dtDetail.Rows[pRow]["qty_by_kgs"].ToString();
            txtqty_order.Text = dtDetail.Rows[pRow]["qty_order"].ToString();
            txtwt_use.Text = dtDetail.Rows[pRow]["wt_use"].ToString();
            txtqty_process1.Text = dtDetail.Rows[pRow]["qty_process1"].ToString();
            txtqty_process2.Text = dtDetail.Rows[pRow]["qty_process2"].ToString();
            txtqty_process3.Text = dtDetail.Rows[pRow]["qty_process3"].ToString();
            txtqty_process4.Text = dtDetail.Rows[pRow]["qty_process4"].ToString();
            txtqty_process5.Text = dtDetail.Rows[pRow]["qty_process5"].ToString();
            txtline_no_desc.Text = dtDetail.Rows[pRow]["line_no_desc"].ToString();            
            txtremark.Text = dtDetail.Rows[pRow]["remark"].ToString();

        }

        private void BTNIMPORT_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "Execl files (*.xls)|*.xls", FilterIndex = 0, RestoreDirectory = true, Title = "導入EXCEL文件路徑", FileName = null };
            openFileDialog1.ShowDialog();
            string strFile_Excel = openFileDialog1.FileName;
            Refresh();
            if (string.IsNullOrEmpty(strFile_Excel))
            {
                return;
            }
            if (!File.Exists(strFile_Excel))
            {
                MessageBox.Show("指定的EXCEL文件不存在，請返回檢查!","提示信息");
                return;
            }

            if (clsBkWork.Process_Excel(strFile_Excel, progressBar1))
            {
                Find_Data();
                MessageBox.Show("導入EXCEL文件成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("導入EXCEL文件失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void Set_Art_Work(string picture_name)
        {
            if (!string.IsNullOrEmpty(picture_name))
            {
                if (File.Exists(picture_name))
                {
                    pictureBox1.Image = Image.FromFile(picture_name);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void txtmould_no_Leave(object sender, EventArgs e)
        {
            if(mState!="" && txtmould_no.Text!="")
            {
                string strsql=string.Format(
                @"SELECT A.mould_no,A.ver,dbo.fn_getMould_mo_list(A.id) as mo_list  
                FROM so_mould_notice_mostly A with(nolock)
                WHERE A.within_code='0000' and A.mould_no ='{0}' and A.state not in ('2','V')",txtmould_no.Text);
                DataTable dtMo_list = clsErp.GetDataTable(strsql);
                if (dtMo_list.Rows.Count > 0)
                {
                    string strmo_id = dtMo_list.Rows[0]["mo_list"].ToString();
                    if (!string.IsNullOrEmpty(strmo_id))
                    {
                        txtmo_id_list.Text = strmo_id;
                        txtmould_ver.Text = dtMo_list.Rows[0]["ver"].ToString();
                        if (strmo_id.Length > 9)
                        {   
                            //做模通知書有多個頁數時取第一個頁數
                            strmo_id = strmo_id.Substring(0, strmo_id.IndexOf("/"));//取第一個頁數
                        }

                        //查找生產計劃中本部門的生產流程
                        strsql = string.Format(@"Select goods_id FROM {0}so_mould_notice_goods WHERE mo_id='{1}'", DBUtility.remote_db, strmo_id);
                        DataTable dtGoods =clsPublicOfCF01.GetDataTable(strsql);
                        if (dtGoods.Rows.Count > 0)
                        {
                            SqlParameter[] spars = new SqlParameter[]{
                                new SqlParameter("@goods_id",dtGoods.Rows[0]["goods_id"].ToString())
                            };
                            DataTable dtBom = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_get_buckle_bom", spars);                           

                            // 将组合框绑定到数据表  
                            cmbgoods_id.DataSource = dtBom;
                            cmbgoods_id.DisplayMember = "goods_id";
                            cmbgoods_id.ValueMember = "goods_id";  

                            //***********
                            // 启用组合框的自我绘制功能
                            cmbgoods_id.DrawMode = DrawMode.OwnerDrawFixed;
                            // 通过处理DrawItem事件来绘制每一项.  
                            cmbgoods_id.DrawItem += delegate(object cmb, DrawItemEventArgs args)
                            {
                                // 绘制默认背景
                                args.DrawBackground();

                                // 组合框已经绑定到数据表,
                                // 所以每一项均为DataRowView对象.
                                DataRowView drv = (DataRowView)this.cmbgoods_id.Items[args.Index];

                                // 获取每一项中对应列的值.  
                                string id = drv["goods_id"].ToString();
                                string name = drv["goods_name"].ToString();

                                // 获取第一列的边界
                                //int width = args.Bounds.Width ;
                                Rectangle r1 = args.Bounds;
                                r1.Width /= 2;     //因共有兩列除以2，所以每列的寬度是一樣                               
                                r1.Width = r1.Width - 60;//豎線左移

                                // 在第一列上绘制文本
                                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                                {
                                    args.Graphics.DrawString(id, args.Font, sb, r1);
                                }

                                // 绘制线来分隔列
                                using (Pen p = new Pen(Color.Black))
                                {
                                    args.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom);
                                }

                                // 获取第二列的边界  
                                Rectangle r2 = args.Bounds;
                                //r2.X = args.Bounds.Width / 2 
                                r2.X = args.Bounds.Width / 2 - 60;//第二列文本左移
                                r2.Width /= 2;                               

                                // 在第二列上绘制文本  
                                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                                {
                                    args.Graphics.DrawString(name, args.Font, sb, r2);
                                }
                            }; 
                            //***********


                        }
                    }
                }
            }
        }

        private void cmbgoods_id_TextChanged(object sender, EventArgs e)
        {
            if (mState != "" && cmbgoods_id.Text != "")
            {
                int iIndex = cmbgoods_id.SelectedIndex;
                if (iIndex >= 0)
                {
                    DataRowView drv = (DataRowView)cmbgoods_id.Items[iIndex];
                    // 获取每一项中对应列的值.  
                    txtartwork.Text = drv["goods_id"].ToString().Substring(4, 7);
                    txtgoods_name.Text = drv["goods_name"].ToString();
                    string strsql = string.Format(@"SELECT dbo.fn_get_picture_name_of_artwork('0000','{0}','OUT') as picture_name", txtartwork.Text);
                    Set_Art_Work(clsPublicOfCF01.ExecuteSqlReturnObject(strsql));                    
                }
            }
        }

        private void Calcu_wt_base_real()
        {
            txtwt_base_real.Text = (clsApp.Return_Float_Value(txtwt_base.Text) + clsApp.Return_Float_Value(txtwt_base_waste.Text)).ToString();
            Calcu_qty_by_kgs();
        }

        private void Calcu_rate_by_kgs()
        {
            if (clsApp.Return_Float_Value(txtwt_base.Text) > 0)
            {
                txtrate_by_kgs.Text = Math.Floor(1000 / clsApp.Return_Float_Value(txtwt_base.Text)).ToString();
            }
        }

        private void Calcu_qty_by_kgs()
        {
            if (clsApp.Return_Float_Value(txtwt_base_real.Text) > 0)
            {
                //舍棄小數,只保留小數
                txtqty_by_kgs.Text = Math.Floor(1000 / clsApp.Return_Float_Value(txtwt_base_real.Text)).ToString();
            }
        }

        private void Calcu_mat_use()
        {
            if (txtqty_order.Text != "" && txtqty_by_kgs.Text !="")
            {
                if (clsApp.Return_Float_Value(txtqty_order.Text) > 0 && clsApp.Return_Float_Value(txtqty_by_kgs.Text) > 0)
                {
                    txtwt_use.Text = Math.Round(clsApp.Return_Float_Value(txtqty_order.Text) / clsApp.Return_Float_Value(txtqty_by_kgs.Text), 2).ToString();
                }
            }
        }

        private void txtwt_base_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 &&mState!="")
            {
                Calcu_wt_base_real();
                Calcu_rate_by_kgs();
            }
        }

        private void txtwt_base_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                Calcu_wt_base_real();
                Calcu_rate_by_kgs();

            }
        }

        private void txtwt_base_waste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && mState != "")
            {
                Calcu_wt_base_real();
            }
        }

        private void txtwt_base_waste_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                Calcu_wt_base_real();
            }
        }

        private void txtqty_order_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && mState != "")
            {
                Calcu_mat_use();
            }
        }

        private void txtqty_order_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                Calcu_mat_use();
            }
        }

        private void cmbgoods_id_Leave(object sender, EventArgs e)
        {
            Valid_goods_id();
        }

        void Valid_goods_id()
        {
            if (mState != "")
            {
                if (cmbgoods_id.Text != "")
                {
                    if (cmbgoods_id.Text.Trim().Length < 18)
                    {
                        MessageBox.Show("物料編號錯誤!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbgoods_id.Focus();
                        return;
                    }
                    string sql = string.Format(@"Select name FROM it_goods with(nolock) WHERE within_code='0000' and id='{0}'", cmbgoods_id.Text);
                    string strGoods_name=clsErp.ExecuteSqlReturnObject(sql);
                    if (strGoods_name != "")
                    {
                        txtgoods_name.Text = strGoods_name;
                    }
                    else
                    {
                        MessageBox.Show("物料編號不存!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtgoods_name.Text = "";
                        cmbgoods_id.Focus();
                    }
                }
            }
        }

        private void cmbgoods_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtwt_base_Click(object sender, EventArgs e)
        {
            txtwt_base.SelectAll();
        }

        private void txtwt_base_waste_Click(object sender, EventArgs e)
        {
            txtwt_base_waste.SelectAll();
        }

        private void txtwaste_Click(object sender, EventArgs e)
        {
            txtwaste.SelectAll();
        }

      
    }
}
