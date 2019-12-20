/*
 * Create by :   Allen Leung
 * Create Date : 2019-04-18
 * remark:
 * 採購部——現金流
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
    public partial class frmPurCashFlow : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        DataTable dtReSet = new DataTable();         
        DataTable dtVendor = new DataTable();
        public string mState = ""; 
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();
        

        public frmPurCashFlow()
        {
            InitializeComponent();
            dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmPurCashFlow_Load(object sender, EventArgs e)
        {
            //生成表結構
            const string ls_sql = @"SELECT *,substring(convert(varchar(10),con_date,120),1,7) as date_ym From dbo.jo_pur_cash_flow where 1=0 ";
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
            txtID.Text = clsPur.getSerialNo("jo_pur_cash_flow");
            cmbfactory_id.Text = "DG";
            dtcon_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();
            //dtcon_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            txtID.Focus();
        }

        private void Save()
        {
            txtID.Focus();
            if (txtamount.Text == "" || cmbfactory_id.Text == "" || dtcon_date.Text == "")
            {
                MessageBox.Show("金額,入單日期,工廠不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtamount.Text == "")
                {
                    txtamount.Focus();
                    return;
                }
                if (cmbfactory_id.Text == "")
                {
                    cmbfactory_id.Focus();
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
            @"INSERT INTO jo_pur_cash_flow(id,con_date,factory_id,amount,sign_by,sign_date,po_no,delivery_no,invoice_no,remark,create_by,create_date)
             VALUES(@id,@con_date,@factory_id,@amount,@sign_by,CASE LEN(@sign_date) WHEN 0 THEN null ELSE @sign_date END,
             @po_no,@delivery_no,@invoice_no,@remark,@user_id,getdate())";

            const string sql_update =
            @"Update jo_pur_cash_flow 
                SET con_date=@con_date,factory_id=@factory_id,amount=@amount,sign_by=@sign_by,sign_date=CASE LEN(@sign_date) WHEN 0 THEN null ELSE @sign_date END,
                 po_no=@po_no,delivery_no=@delivery_no,invoice_no=@invoice_no,remark=@remark,update_by=@user_id,update_date=getdate()
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
                        strSerial_no = clsPur.getSerialNo("jo_pur_cash_flow");
                        txtID.Text = strSerial_no;   
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text);
                    myCommand.Parameters.AddWithValue("@con_date", clsApp.Return_String_Date(dtcon_date.Text)); 
                    myCommand.Parameters.AddWithValue("@factory_id", cmbfactory_id.Text);
                    myCommand.Parameters.AddWithValue("@amount", clsApp.Return_Float_Value(txtamount.Text));
                    myCommand.Parameters.AddWithValue("@sign_by", txtsign_by.Text);                   
                    myCommand.Parameters.AddWithValue("@sign_date", clsApp.Return_String_Date(dtsign_date.Text));
                    myCommand.Parameters.AddWithValue("@po_no", txtpo_no.Text);
                    myCommand.Parameters.AddWithValue("@delivery_no", txtdelivery_no.Text);
                    myCommand.Parameters.AddWithValue("@invoice_no", txtinvoice_no.Text);  
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
        //    string ls_sql = string.Format(@"Select '1' From dbo.jo_pur_cash_flow Where id='{0}'", txtID.Text);
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
                const string sql_del = "DELETE FROM dbo.jo_pur_cash_flow WHERE id=@id";
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

        private void frmPurCashFlow_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtVendor.Dispose();          
           objToolbar = null;
           clsApp = null;           
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
            string sql =
            @"SELECT id,CONVERT(varchar(10),con_date,120) AS con_date,factory_id,amount,sign_by,CONVERT(varchar(10),sign_date,120) AS sign_date,
            po_no,delivery_no,invoice_no,remark,create_by,create_date,update_by,update_date,Substring(convert(varchar(10),con_date,120),1,7) as date_ym
            FROM dbo.jo_pur_cash_flow With(nolock) Where id>'' ";
            if (txtpo_no1.Text == "" && dtcon_date1.Text == "" && dtcon_date2.Text == "" && dtsign_date1.Text == "" && dtsign_date2.Text == "" && cmbfactory_id1.Text == "")
            {
                sql = @"SELECT id,CONVERT(varchar(10),con_date,120) AS con_date,factory_id,amount,sign_by,CONVERT(varchar(10),sign_date,120) AS sign_date,
                po_no,delivery_no,invoice_no,remark,create_by,create_date,update_by,update_date,Substring(convert(varchar(10),con_date,120),1,7) as date_ym
                FROM dbo.jo_pur_cash_flow With(nolock) order by id";
            }
            else
            {
                if (txtpo_no1.Text != "")
                {
                    sql = sql + string.Format(" and po_no like '%{0}%'", txtpo_no1.Text);
                }
                if (dtcon_date1.Text != "")
                {
                    sql = sql + string.Format(" and con_date>='{0}'", clsApp.Return_String_Date(dtcon_date1.Text));
                }
                if (dtcon_date2.Text != "")
                {
                    sql = sql + string.Format(" and con_date<='{0}'", clsApp.Return_String_Date(dtcon_date2.Text));
                }
                if (dtsign_date1.Text != "")
                {
                    sql = sql + string.Format(" and sign_date >='{0}'", dtsign_date1.Text);
                }
                if (dtsign_date2.Text != "")
                {
                    sql = sql + string.Format(" and sign_date <='{0}'", dtsign_date2.Text);
                }
                if (cmbfactory_id1.Text != "")
                {
                    sql = sql + string.Format(" and factory_id ='{0}'", cmbfactory_id1.Text);
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
            cmbfactory_id.Text = pdr.Cells["factory_id"].Value.ToString();
            txtamount.Text = pdr.Cells["amount"].Value.ToString();           
            txtsign_by.Text = pdr.Cells["sign_by"].Value.ToString();
            dtsign_date.EditValue = clsApp.Return_String_Date(pdr.Cells["sign_date"].Value.ToString());
            txtpo_no.Text = pdr.Cells["po_no"].Value.ToString();
            txtdelivery_no.Text = pdr.Cells["delivery_no"].Value.ToString();
            txtinvoice_no.Text = pdr.Cells["invoice_no"].Value.ToString();
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
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("沒有要列印的數據！", "提示信息");
                return;
            }
            using (xrPurCashFlow rpt = new xrPurCashFlow(dtcon_date1.Text, dtcon_date2.Text ) { DataSource = dtDetail })
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
                //dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select id,create_by,create_date,update_by,update_date From dbo.jo_pur_cash_flow WHERE vendor_name='{0}'", txtgoods_name.Text ));
                string ls_sql =string.Format(@"Select id,create_by,create_date,update_by,update_date From dbo.jo_pur_cash_flow with(nolock) WHERE id='{0}'",txtID.Text);
                dtReSet = clsPublicOfCF01.GetDataTable(ls_sql);
                if (mState == "NEW")
                {
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["id"] = txtID.Text; 
                    row["con_date"] = dtcon_date.Text;                    
                    row["factory_id"] = cmbfactory_id.Text;
                    row["amount"] = clsApp.Return_Float_Value(txtamount.Text);
                    row["sign_by"] = txtsign_by.Text;
                    row["sign_date"] = dtsign_date.Text;
                    row["po_no"] = txtpo_no.Text;
                    row["delivery_no"] = txtdelivery_no.Text;
                    row["invoice_no"] = txtinvoice_no.Text;
                    row["remark"] = txtremark.Text;
                    row["create_by"] = DBUtility._user_id;
                    row["create_date"] = dtReSet.Rows[0]["create_date"].ToString();
                    row["date_ym"] = dtcon_date.Text.Substring(0, 7);
                    dtDetail.Rows.Add(row);
                }
                else
                {                    
                    dtDetail.Rows[row_reset]["id"] = txtID.Text;
                    dtDetail.Rows[row_reset]["con_date"] = dtcon_date.Text;                    
                    dtDetail.Rows[row_reset]["factory_id"] = cmbfactory_id.Text;
                    dtDetail.Rows[row_reset]["amount"] =clsApp.Return_Float_Value(txtamount.Text);
                    dtDetail.Rows[row_reset]["sign_by"] = txtsign_by.Text;
                    dtDetail.Rows[row_reset]["sign_date"] = dtsign_date.Text;
                    dtDetail.Rows[row_reset]["po_no"] = txtpo_no.Text;
                    dtDetail.Rows[row_reset]["delivery_no"] = txtdelivery_no.Text;
                    dtDetail.Rows[row_reset]["invoice_no"] = txtinvoice_no.Text;
                    dtDetail.Rows[row_reset]["remark"] = txtremark.Text;
                    dtDetail.Rows[row_reset]["update_by"] = DBUtility._user_id;
                    dtDetail.Rows[row_reset]["update_date"] = dtReSet.Rows[0]["update_date"].ToString();
                    dtDetail.Rows[row_reset]["date_ym"] = dtcon_date.Text.Substring(0, 7);
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

        private void cmbfactory_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");                
            }
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
            dtcon_date.Text = DateTime.Parse(dtDetail.Rows[pRow]["con_date"].ToString()).Date.ToString("yyyy-MM-dd");            
            cmbfactory_id.Text = dtDetail.Rows[pRow]["factory_id"].ToString();
            txtamount.Text = dtDetail.Rows[pRow]["amount"].ToString();
            txtsign_by.Text = dtDetail.Rows[pRow]["sign_by"].ToString();
            dtsign_date.EditValue = DateTime.Parse(dtDetail.Rows[pRow]["sign_date"].ToString()).Date.ToString("yyyy-MM-dd");  
            txtpo_no.Text = dtDetail.Rows[pRow]["po_no"].ToString();
            txtdelivery_no.Text = dtDetail.Rows[pRow]["delivery_no"].ToString();
            txtinvoice_no.Text = dtDetail.Rows[pRow]["invoice_no"].ToString();
            txtremark.Text = dtDetail.Rows[pRow]["remark"].ToString();
        }

        private void dtsign_date1_Leave(object sender, EventArgs e)
        {
            dtsign_date2.EditValue = dtsign_date1.EditValue;
        }

      
    }
}
