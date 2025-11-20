/*
 * Create by :   Allen Leung
 * Create Date : 2019-04-18
 * remark:
 * 電鍍報價  暫時取消
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
    public partial class frmQuotationPlate : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public string mState = "";
        public DataTable dtDetail = new DataTable();
        DataTable dtReSet = new DataTable();         
        DataTable dtVendor = new DataTable();
        DataGridViewRow dgvrow = new DataGridViewRow();       
        clsAppPublic clsApp = new clsAppPublic();
        clsToolBarNew objToolbar;


        public frmQuotationPlate()
        {
            InitializeComponent();
            dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmQuotationPlate_Load(object sender, EventArgs e)
        {
            //生成表結構
            string ls_sql = @"SELECT *,substring(convert(varchar(10),con_date,120),1,7) as date_ym From dbo.quotation_plate where 1=0 ";
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
            txtID.Text = clsPur.getSerialNo("quotation_plate");
            luePrice_unit.EditValue = "PCS";
            lueMid.EditValue = "RMB";
            dtquotation_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();           
            txtID.Focus();
        }

        private void Save()
        {
            txtID.Focus();
            if (txtPrice.Text == "" || luePrice_unit.Text == "" || dtquotation_date.Text == ""|| txtPlate_process.Text==""|| lueMid.Text=="")
            {
                MessageBox.Show("單價,單價單位,入單日期,電鍍工藝或者幣種不可为空,請返回檢查!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtPrice.Text == "")
                {
                    txtPrice.Focus();
                    return;
                }
                if (luePrice_unit.Text == "")
                {
                    luePrice_unit.Focus();
                    return;
                }
                if (dtquotation_date.Text == "")
                {
                    dtquotation_date.Focus();
                    return;
                }
                if (txtPlate_process.Text == "")
                {
                    txtPlate_process.Focus();
                    return;
                }
                if (lueMid.Text == "")
                {
                    lueMid.Focus();
                    return;
                }
            }
            
            bool save_flag = false;
            string sql_insert =
            @"INSERT INTO quotation_plate(id,vendor_id,vendor_name,quotation_date,quotation_id,mo_id,artwork_id,prod_id,prod_desc,mat,size,
            cf_color_id,cf_color,vendor_color,price_remark,price,price_polish,prod_type,plate_type,plate_process,price_unit,m_id,create_by,create_date)
            VALUES(@id,@vendor_id,@vendor_name,@quotation_date,@quotation_id,@mo_id,@artwork_id,@prod_id,@prod_desc,@mat,@size,@cf_color_id,@cf_color,
            @vendor_color,@price_remark,@price,@price_polish,@prod_type,@plate_type,@plate_process,@price_unit,@m_id,@user_id,getdate())";

            string sql_update =
            @"Update quotation_plate
            SET vendor_id=@vendor_id,vendor_name=@vendor_name,quotation_date=@quotation_date,quotation_id=@quotation_id,mo_id=@mo_id,artwork_id=@artwork_id,
            prod_id=@prod_id,prod_desc=@prod_desc,=@mat,size=@size,cf_color_id=@cf_color_id,cf_color=@cf_color,vendor_color=@vendor_color,price_remark=@price_remark,
            price=@price,price_polish=@price_polish,prod_type=@prod_type,plate_type=@plate_type,plate_process=@plate_process,price_unit=@price_unit,m_id=@m_id,
            update_by=@user_id,update_date=getdate()
            WHERE id=@id";            

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            string strSerialNo;
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();                    
                    if (mState == "NEW")
                    {
                        myCommand.CommandText = sql_insert;                        
                        strSerialNo = clsPur.getSerialNo("quotation_plate");
                        txtID.Text = strSerialNo;   
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@id", txtID.Text);
                    myCommand.Parameters.AddWithValue("@quotation_date", clsApp.Return_String_Date(dtquotation_date.Text));
                    myCommand.Parameters.AddWithValue("@vendor_id", lueVendor_id.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@vendor_name", txtVendor_name.Text);
                    myCommand.Parameters.AddWithValue("@quotation_id", txtQuotation_id.Text);
                    myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text);
                    myCommand.Parameters.AddWithValue("@artwork_id", txtArtwork_id.Text);
                    myCommand.Parameters.AddWithValue("@prod_id", txtProd_id.Text);
                    myCommand.Parameters.AddWithValue("@prod_desc", txtProd_desc.Text);
                    myCommand.Parameters.AddWithValue("@size", txtSize.Text);
                    myCommand.Parameters.AddWithValue("@cf_color_id", lueCf_color_id.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@cf_color", txtCf_color.Text);
                    myCommand.Parameters.AddWithValue("@vendor_color", txtVendor_color.Text);
                    myCommand.Parameters.AddWithValue("@price_remark", txtPrice_remark.Text);
                    myCommand.Parameters.AddWithValue("@plate_type", txtPlate_type.Text);
                    myCommand.Parameters.AddWithValue("@plate_process", txtPlate_process.Text);                   
                    myCommand.Parameters.AddWithValue("@prod_type", cmbProd_type.Text);
                    myCommand.Parameters.AddWithValue("@price", clsApp.Return_Float_Value(txtPrice.Text));
                    myCommand.Parameters.AddWithValue("@price_polish", clsApp.Return_Float_Value(txtPrice_polish.Text));
                    myCommand.Parameters.AddWithValue("@price_unit", luePrice_unit.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@m_id", lueMid.EditValue.ToString());                                   
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
            if (dgvDetails.RowCount == 0 && string.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string ls_delete_id = txtID.Text;
                const string sql_del = "DELETE FROM dbo.quotation_plate WHERE id=@id";
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

        private void frmQuotationPlate_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtVendor.Dispose();          
           objToolbar = null;
           clsApp = null;           
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtPrice_remark.Focus();
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
            /*
            dtDetail.Clear();
            string sql =
            @"SELECT id,CONVERT(varchar(10),con_date,120) AS con_date,factory_id,amount,sign_by,CONVERT(varchar(10),sign_date,120) AS sign_date,
            po_no,delivery_no,invoice_no,remark,create_by,create_date,update_by,update_date,Substring(convert(varchar(10),con_date,120),1,7) as date_ym
            FROM dbo.quotation_plate With(nolock) Where id>'' ";
            if (txtpo_no1.Text == "" && dtcon_date1.Text == "" && dtcon_date2.Text == "" && dtsign_date1.Text == "" && dtsign_date2.Text == "" && cmbfactory_id1.Text == "")
            {
                sql = @"SELECT id,CONVERT(varchar(10),con_date,120) AS con_date,factory_id,amount,sign_by,CONVERT(varchar(10),sign_date,120) AS sign_date,
                po_no,delivery_no,invoice_no,remark,create_by,create_date,update_by,update_date,Substring(convert(varchar(10),con_date,120),1,7) as date_ym
                FROM dbo.quotation_plate With(nolock) order by id";
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
            */
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
            dtquotation_date.EditValue = clsApp.Return_String_Date(pdr.Cells["quotation_date"].Value.ToString());            
            lueVendor_id.EditValue = pdr.Cells["vendor_id"].Value.ToString();
            txtQuotation_id.Text = pdr.Cells["quotation_id"].Value.ToString();
            txtMo_id.Text = pdr.Cells["mo_id"].Value.ToString();
            txtArtwork_id.Text = pdr.Cells["artwork_id"].Value.ToString();
            txtProd_id.Text = pdr.Cells["prod_id"].Value.ToString();
            txtProd_desc.Text = pdr.Cells["prod_desc"].Value.ToString();
            lueMat_id.EditValue = pdr.Cells["mat_id"].Value.ToString();
            txtMat.Text = pdr.Cells["mat"].Value.ToString();
            txtSize.Text = pdr.Cells["size"].Value.ToString();           
            lueCf_color_id.EditValue = pdr.Cells["cf_color_id"].Value.ToString();
            cmbProd_type.Text = pdr.Cells["prod_type"].Value.ToString();
            txtPlate_type.Text = pdr.Cells["plate_type"].Value.ToString();
            txtPrice.Text = pdr.Cells["price"].Value.ToString();
            txtMo_id.Text = pdr.Cells["mo_id"].Value.ToString();
            txtPrice_polish.Text = pdr.Cells["price_polish"].Value.ToString();
            txtPrice.Text = pdr.Cells["price"].Value.ToString();
            luePrice_unit.EditValue = pdr.Cells["price_unit"].ToString();
            lueMid.EditValue = pdr.Cells["m_id"].Value.ToString();
            txtPlate_process.Text = pdr.Cells["plate_process"].Value.ToString();
            txtPrice_remark.Text = pdr.Cells["price_remark"].Value.ToString();
            txtVendor_color.Text = pdr.Cells["vendor_color"].Value.ToString();
            txtCf_color.Text = pdr.Cells["cf_color"].Value.ToString();


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
            /*
            if (mState == "NEW" || mState == "EDIT")
            {
                //取得當前新增或修改的行
                //dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select id,create_by,create_date,update_by,update_date From dbo.quotation_plate WHERE vendor_name='{0}'", txtgoods_name.Text ));
                string ls_sql =string.Format(@"Select id,create_by,create_date,update_by,update_date From dbo.quotation_plate with(nolock) WHERE id='{0}'",txtID.Text);
                dtReSet = clsPublicOfCF01.GetDataTable(ls_sql);
                if (mState == "NEW")
                {
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["id"] = txtID.Text; 
                    row["con_date"] = dtquotation_date.Text;                    
                    row["factory_id"] = cmbProd_type.Text;
                    row["amount"] = clsApp.Return_Float_Value(txtPrice.Text);
                    row["sign_by"] = txtsign_by.Text;
                    row["sign_date"] = dtsign_date.Text;
                    row["po_no"] = txtpo_no.Text;
                    row["delivery_no"] = txtdelivery_no.Text;
                    row["invoice_no"] = txtinvoice_no.Text;
                    row["remark"] = txtremark.Text;
                    row["create_by"] = DBUtility._user_id;
                    row["create_date"] = dtReSet.Rows[0]["create_date"].ToString();
                    row["date_ym"] = dtquotation_date.Text.Substring(0, 7);
                    dtDetail.Rows.Add(row);
                }
                else
                {                    
                    dtDetail.Rows[row_reset]["id"] = txtID.Text;
                    dtDetail.Rows[row_reset]["con_date"] = dtquotation_date.Text;                    
                    dtDetail.Rows[row_reset]["factory_id"] = cmbProd_type.Text;
                    dtDetail.Rows[row_reset]["amount"] =clsApp.Return_Float_Value(txtPrice.Text);
                    dtDetail.Rows[row_reset]["sign_by"] = txtsign_by.Text;
                    dtDetail.Rows[row_reset]["sign_date"] = dtsign_date.Text;
                    dtDetail.Rows[row_reset]["po_no"] = txtpo_no.Text;
                    dtDetail.Rows[row_reset]["delivery_no"] = txtdelivery_no.Text;
                    dtDetail.Rows[row_reset]["invoice_no"] = txtinvoice_no.Text;
                    dtDetail.Rows[row_reset]["remark"] = txtremark.Text;
                    dtDetail.Rows[row_reset]["update_by"] = DBUtility._user_id;
                    dtDetail.Rows[row_reset]["update_date"] = dtReSet.Rows[0]["update_date"].ToString();
                    dtDetail.Rows[row_reset]["date_ym"] = dtquotation_date.Text.Substring(0, 7);
                }
                dtDetail.AcceptChanges();
                dgvDetails.DataSource = dtDetail;
                dgvDetails.Refresh();
            }
            */
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

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                tabControl1.SelectTab(0);
                int row_index = dgvDetails.CurrentCell.RowIndex;
                AddNew();               
                SetHead(row_index);
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //復制新增用到此方法
        private void SetHead(int row_index)
        {
            dtquotation_date.EditValue = DateTime.Parse(dtDetail.Rows[row_index]["quotation_date"].ToString()).Date.ToString("yyyy-MM-dd");
            lueVendor_id.EditValue = dtDetail.Rows[row_index]["vendor_id"].ToString();
            txtQuotation_id.Text = dtDetail.Rows[row_index]["quotation_id"].ToString();
            txtMo_id.Text = dtDetail.Rows[row_index]["mo_id"].ToString();
            txtArtwork_id.Text = dtDetail.Rows[row_index]["artwork_id"].ToString();
            txtProd_id.Text = dtDetail.Rows[row_index]["prod_id"].ToString();
            txtProd_desc.Text = dtDetail.Rows[row_index]["prod_desc"].ToString();
            lueMat_id.EditValue= dtDetail.Rows[row_index]["mat_id"].ToString();
            txtMat.Text = dtDetail.Rows[row_index]["mat"].ToString();
            txtSize.Text= dtDetail.Rows[row_index]["size"].ToString();            
            lueCf_color_id.EditValue = dtDetail.Rows[row_index]["cf_color_id"].ToString();
            cmbProd_type.Text = dtDetail.Rows[row_index]["prod_type"].ToString();
            txtPlate_type.Text = dtDetail.Rows[row_index]["plate_type"].ToString();
            txtPrice.Text = dtDetail.Rows[row_index]["price"].ToString();
            txtMo_id.Text = dtDetail.Rows[row_index]["mo_id"].ToString();
            txtPrice_polish.Text = dtDetail.Rows[row_index]["price_polish"].ToString();
            txtPrice.Text = dtDetail.Rows[row_index]["price"].ToString();
            luePrice_unit.EditValue= dtDetail.Rows[row_index]["price_unit"].ToString();
            lueMid.EditValue = dtDetail.Rows[row_index]["m_id"].ToString();
            txtPlate_process.Text = dtDetail.Rows[row_index]["plate_process"].ToString();
            txtPrice_remark.Text = dtDetail.Rows[row_index]["price_remark"].ToString();
            txtVendor_color.Text = dtDetail.Rows[row_index]["vendor_color"].ToString();
            txtCf_color.Text = dtDetail.Rows[row_index]["cf_color"].ToString();
        }      

        private void cmbProd_type_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCf_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtVendor_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrice_remark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
