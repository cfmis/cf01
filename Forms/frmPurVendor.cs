/*
 * Create by :   Allen Leung
 * Create Date : 2019-04-09
 * remark:
 * 採購部——供應商
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


namespace cf01.Forms
{
    public partial class frmPurVendor : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public DataTable dtReSet = new DataTable();             
        public string mState = ""; 
        public static List<mdlOcRemark> mList = new List<mdlOcRemark>();
        clsAppPublic clsApp = new clsAppPublic();
        DataGridViewRow dgvrow = new DataGridViewRow();       
        clsToolBarNew objToolbar;

        public frmPurVendor()
        {
            InitializeComponent();
            dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmPurVendor_Load(object sender, EventArgs e)
        {
            //生成表結構
            const string ls_sql = @"SELECT * From dbo.jo_pur_vendor where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(ls_sql);
            Find_Data();
            //if (dtcon_date1.Text == "")
            //{
            //    dtcon_date1.EditValue = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd").Substring(0, 10);
            //}
            //if (dtcon_date2.Text == "")
            //{
            //    dtcon_date2.EditValue = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 10);
            //}
        }

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
            txtcontact.Text = DBUtility._user_id;

            txtID.Focus();
        }

        private void Save()
        {
            txtID.Focus();
            if (txtvendor_name.Text == "" || dtcon_date.Text == "")
            {
                MessageBox.Show("供應商名稱、入單日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtcon_date.Focus();
                return;
            }
            
            //新增時判斷主鍵是否已存在
            if (mState == "NEW")
            {
                if (!Valid_Date())
                {
                    return;
                }
            }
            //bds1.EndEdit();
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO jo_pur_vendor(con_date,vendor_name,contact,tel_mobile,tel,fax,email,vendor_address,month_days,vendor_type,is_invoice,invoice_type,is_partner,remark,create_by,create_date)
             VALUES(CASE LEN(@con_date) WHEN 0 THEN null ELSE @con_date END,@vendor_name,@contact,@tel_mobile,@tel,@fax,@email,@vendor_address,@month_days,@vendor_type,@is_invoice,@invoice_type,@is_partner,@remark,@user_id,getdate())";

            const string sql_update =
            @"Update jo_pur_vendor 
                SET con_date= CASE LEN(@con_date) WHEN 0 THEN null ELSE @con_date END,
                vendor_name=@vendor_name,contact=@contact,tel_mobile=@tel_mobile,tel=@tel,fax=@fax,email=@email,
                vendor_address=@vendor_address,month_days=@month_days,vendor_type=@vendor_type,is_invoice=@is_invoice,
                invoice_type=@invoice_type,is_partner=@is_partner,remark=@remark,update_by=@user_id,update_date=getdate()
            WHERE id=@id";            

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            //string strSerial_no;
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
                        string ls_sql_f = string.Format(@"Select '1' From dbo.jo_pur_vendor where vendor_name='{0}'", txtvendor_name.Text);
                        if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql_f) != "")
                        {
                            MessageBox.Show("已存在此供應商編號，不可以重復新增！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
                            return;
                        }
                        //strSerial_no = clsTommyTest.GetSeqNo("jo_pur_vendor", "serial_no");
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.Parameters.AddWithValue("@id", txtID.Text);
                        myCommand.CommandText = sql_update;                       
                        //strSerial_no = txtID.Text;
                    }                    
                    myCommand.Parameters.AddWithValue("@con_date", clsApp.Return_String_Date(dtcon_date.Text));
                    myCommand.Parameters.AddWithValue("@vendor_name", txtvendor_name.Text);
                    myCommand.Parameters.AddWithValue("@contact", txtcontact.Text);
                    myCommand.Parameters.AddWithValue("@tel_mobile", txttel_mobile.Text);
                    myCommand.Parameters.AddWithValue("@fax", txtfax.Text);
                    myCommand.Parameters.AddWithValue("@tel", txttel.Text);
                    myCommand.Parameters.AddWithValue("@email", txtemail.Text);
                    myCommand.Parameters.AddWithValue("@vendor_address", txtvendor_address.Text);
                    myCommand.Parameters.AddWithValue("@month_days", txtmonth_days.Text);
                    myCommand.Parameters.AddWithValue("@vendor_type", txtvendor_type.Text);
                    myCommand.Parameters.AddWithValue("@invoice_type", txtinvoice_type.Text);
                    if (chkis_invoice.Checked)
                        myCommand.Parameters.AddWithValue("@is_invoice", true);
                    else
                        myCommand.Parameters.AddWithValue("@is_invoice", false);
                    if (chkis_partner.Checked)
                        myCommand.Parameters.AddWithValue("@is_partner", true);
                    else
                        myCommand.Parameters.AddWithValue("@is_partner", false);
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
        private bool Valid_Date()
        {
            bool result=false ;
            string ls_sql = string.Format(@"Select '1' From dbo.jo_pur_vendor Where vendor_name='{0}'", txtvendor_name.Text);
            if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql) == "")
                result = true ;
            else
                result = false;
            return result;
        }

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
                const string sql_del = "DELETE FROM dbo.jo_pur_vendor WHERE id=@id";
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
            txtvendor_name.Focus();
            dgvDetails.Enabled = false;
        }

        private void frmPurVendor_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();          
           objToolbar = null;
           clsApp = null;           
           mList = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtvendor_name.Focus();
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
            string sql = @"SELECT a.* From dbo.jo_pur_vendor a with(nolock) Where a.id>0 ";
            if (txtvendor_name1.Text == ""  && dtcon_date1.Text == "" && dtcon_date2.Text == "" )
                sql = @"SELECT a.* From dbo.jo_pur_vendor a with(nolock)";
            else
            {                
                if (txtvendor_name1.Text != "")
                {
                    sql = sql + string.Format(" and a.vendor_name like '%{0}%'", txtvendor_name1.Text);
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
            txtvendor_name.Text = pdr.Cells["vendor_name"].Value.ToString();
            txtcontact.Text = pdr.Cells["contact"].Value.ToString();            
            txttel_mobile.Text = pdr.Cells["tel_mobile"].Value.ToString();
            txttel.Text = pdr.Cells["tel"].Value.ToString();
            txtfax.Text = pdr.Cells["fax"].Value.ToString();
            txtemail.Text = pdr.Cells["email"].Value.ToString();            
            txtvendor_address.Text = pdr.Cells["vendor_address"].Value.ToString();
            txtmonth_days.Text = pdr.Cells["month_days"].Value.ToString();
            txtvendor_type.Text = pdr.Cells["vendor_type"].Value.ToString();
            if (pdr.Cells["is_invoice"].Value.ToString() == "True")
                chkis_invoice.Checked = true;
            else
                chkis_invoice.Checked = false;
            txtinvoice_type.Text = pdr.Cells["invoice_type"].Value.ToString();
            if (pdr.Cells["is_partner"].Value.ToString() == "True")
                chkis_partner.Checked = true;
            else
                chkis_partner.Checked = false;
            txtremark.Text = pdr.Cells["remark"].Value.ToString();
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
        }      

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtcon_date2.EditValue = dtcon_date1.EditValue;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
//            if (dgvDetails.RowCount ==0)
//            {
//                MessageBox.Show("沒有要列印的數據！","提示信息");
//                return;
//            }
           
//            string ls_sql = string.Format(
//                @"SELECT A.*,B.name as goods_name,dbo.fn_get_picture_name_of_artwork('0000',Substring(A.goods_id,5,7),'OUT') AS picture_name 
//            From dbo.jo_pur_vendor A with(nolock),{0}it_goods B with(nolock) 
//            Where A.goods_id COLLATE Chinese_PRC_CI_AS = B.id and A.id='{1}'", DBUtility.remote_db, txtID.Text);
//            DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
//            using (xrMould_Process rpt = new xrMould_Process() { DataSource = dt })
//            {
//                rpt.CreateDocument();
//                rpt.PrintingSystem.ShowMarginsWarning = false;
//                rpt.ShowPreviewDialog();
//            }
               
            
//            using (xrMould_Process rpt = new xrMould_Process() { DataSource = dtDetail })
//            {
//                rpt.CreateDocument();
//                rpt.PrintingSystem.ShowMarginsWarning = false;
//                rpt.ShowPreviewDialog();
//            }
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
                dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select id,create_by,create_date,update_by,update_date From dbo.jo_pur_vendor WHERE vendor_name='{0}'", txtvendor_name.Text ));
                if (mState == "NEW")
                {                   
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["id"] = dtReSet.Rows[0]["id"].ToString(); 
                    row["con_date"] = dtcon_date.Text;
                    row["vendor_name"] = txtvendor_name.Text;
                    row["contact"] = txtcontact.Text;
                    row["tel_mobile"] = txttel_mobile.Text;
                    row["tel"] = txttel.Text;
                    row["fax"] = txtfax.Text;
                    row["email"] = txtemail.Text;
                    row["vendor_address"] = txtvendor_address.Text;
                    row["month_days"] = txtmonth_days.Text;
                    row["vendor_type"] = txtvendor_type.Text;
                    row["is_invoice"] = chkis_invoice.Checked ? true : false;
                    row["invoice_type"] = txtinvoice_type.Text;
                    row["is_partner"] = chkis_partner.Checked ? true : false;
                    row["remark"] = txtremark.Text;                    
                    row["create_by"] = dtReSet.Rows[0]["create_by"].ToString();
                    row["create_date"] = dtReSet.Rows[0]["create_date"].ToString();
                    dtDetail.Rows.Add(row);
                }
                else
                {                   
                    dtDetail.Rows[row_reset]["id"] = txtID.Text;
                    dtDetail.Rows[row_reset]["con_date"] = dtcon_date.Text;
                    dtDetail.Rows[row_reset]["vendor_name"] = txtvendor_name.Text;
                    dtDetail.Rows[row_reset]["contact"] = txtcontact.Text;
                    dtDetail.Rows[row_reset]["tel_mobile"] = txttel_mobile.Text;
                    dtDetail.Rows[row_reset]["tel"] = txttel.Text;
                    dtDetail.Rows[row_reset]["fax"] = txtfax.Text;
                    dtDetail.Rows[row_reset]["email"] = txtemail.Text;
                    dtDetail.Rows[row_reset]["vendor_address"] = txtvendor_address.Text;
                    dtDetail.Rows[row_reset]["month_days"] = txtmonth_days.Text;
                    dtDetail.Rows[row_reset]["vendor_type"] = txtvendor_type.Text;
                    dtDetail.Rows[row_reset]["is_invoice"] = chkis_invoice.Checked ? true : false;
                    dtDetail.Rows[row_reset]["invoice_type"] = txtinvoice_type.Text;
                    dtDetail.Rows[row_reset]["is_partner"] = chkis_partner.Checked ? true : false;
                    dtDetail.Rows[row_reset]["remark"] = txtremark.Text;
                    dtDetail.Rows[row_reset]["update_by"] = dtReSet.Rows[0]["update_by"].ToString();
                    dtDetail.Rows[row_reset]["update_date"] = dtReSet.Rows[0]["update_date"].ToString();
                }
                dtDetail.AcceptChanges();
                dgvDetails.DataSource = dtDetail;//
                dgvDetails.Refresh();//
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
            //判段某個按鈕是否已被點擊
            //以下代碼為當保存按鈕被點擊時前進行數據的有效性檢查
            if (btnSave.Selected)
            {
                //Valid_Draw_No();
            }
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
    }
}
