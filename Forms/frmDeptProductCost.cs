/*
 * Create by :   Allen Leung
 * Create Date : 2019-05-17
 * remark:
 * 部門工序成本錄入
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
    public partial class frmDeptProductCost : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        DataTable dtDetail = new DataTable();
        DataTable dtReSet = new DataTable();
        public string mState = ""; 
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();
        DataTable dtWork = new DataTable();
        DataTable dtWork_Filter = new DataTable();
        

        public frmDeptProductCost()
        {
            InitializeComponent();
            //dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmDeptProductCost_Load(object sender, EventArgs e)
        {
            string strsql =string.Format(
            @"SELECT * FROM (SELECT id,id+'['+name+']' as name FROM {0}cd_department WHERE LEN(id)=3 and id<='822' and state <>'2'
            Union SELECT id,id+'['+name+']' as name FROM {0}cd_department WHERE LEN(id)=3 and id>'J00' and id<='JZZ' and id<>'J08' and state <>'2') S
            ORDER BY S.id", DBUtility.remote_db);
            DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            lkedept_id.Properties.DataSource = dt;
            lkedept_id.Properties.DisplayMember = "name";
            lkedept_id.Properties.ValueMember = "id";

            //工種
            strsql = string.Format(@"select dept_id,id,name from {0}cd_type_work Where state<>'2' order by dept_id,id", DBUtility.remote_db);
            dtWork = clsPublicOfCF01.GetDataTable(strsql);
            //lkeprocess_id.Properties.DataSource = dtWork;
            //lkeprocess_id.Properties.DisplayMember = "name";
            //lkeprocess_id.Properties.ValueMember = "id";

            //成本單位
            strsql = @"select unit_code from jo_dept_cost_unit order by id";
            DataTable dtPriceUnit = clsPublicOfCF01.GetDataTable(strsql);
            for (int i = 0; i < dtPriceUnit.Rows.Count; i++)
            {
                cmbcost_unit.Items.Add(dtPriceUnit.Rows[i]["unit_code"].ToString());
            }

            //生成表結構
            const string ls_sql = @"SELECT * From dbo.jo_dept_product_cost where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(ls_sql);
            dgvDetails.DataSource = dtDetail;
            //Find_Data();
            //if (dgvDetails.Rows.Count >= 2)
            //{
            //    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.Rows.Count - 1].Cells[0];
            //    dgvDetails.BeginEdit(true);
            //    dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true; //選中整行
            //}
        }

        private void SetButtonSatus(bool _flag)
        {
            btnNew.Enabled = _flag;
            btnEdit.Enabled = _flag;
            btnDelete.Enabled = _flag;            
            btnPrint.Enabled = _flag;
            BTNNEWCOPY.Enabled = _flag;
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

        ///// <summary>
        ///// 設置某單元格獲得焦點
        ///// </summary>
        ///// <param name="view"></param>
        ///// <param name="rowHandle"></param>
        ///// <param name="columnName"></param>
        //private static void SetFocuse(DevExpress.XtraGrid.Views.Grid.GridView dev_view, Int32 rowHandle, string columnName)
        //{
        //    dev_view.Focus();
        //    dev_view.FocusedRowHandle = rowHandle;
        //    dev_view.FocusedColumn = dev_view.Columns[columnName];
        //    dev_view.ShowEditor();
        //}

        private void AddNew()
        {
            tabControl1.SelectTab(0);
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            dgvDetails.Enabled = false; //表格可以編輯

            lkedept_id.Enabled = true;             
            
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();
            //dtcon_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            lkedept_id.Focus();
        }

        private void Save()
        {
            lkedept_id.Focus();
            if (lkedept_id.Text == "")
            {
                MessageBox.Show("部門不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lkedept_id.Focus();
                return;
            }
            if (cmbprocess_id.Text == "")
            {
                MessageBox.Show("工序不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbprocess_id.Focus();
                return;
            }
            if (txtproduct_qty.Text == "")
            {
                MessageBox.Show("數量不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtproduct_qty.Focus();
                return;
            }
            if (txtcost_price.Text == "")
            {
                MessageBox.Show("成本不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcost_price.Focus();
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
            @"INSERT INTO jo_dept_product_cost(dept_id,process_id,process_name,product_qty,cost_price,cost_unit,remark,create_by,create_date)
             VALUES(@dept_id,@process_id,@process_name,@product_qty,@cost_price,@cost_unit,@remark,@user_id,getdate())";

            const string sql_update =
            @"Update jo_dept_product_cost 
                SET process_name=@process_name,product_qty=@product_qty,cost_price=@cost_price,cost_unit=@cost_unit,remark=@remark,update_by=@user_id,update_date = getdate()
            WHERE dept_id=@dept_id and process_id=@process_id"; 

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
                        myCommand.CommandText = sql_new;
                        string ls_sql_f = string.Format(@"Select '1' From dbo.jo_dept_product_cost where dept_id='{0}' and process_id='{1}'", lkedept_id.EditValue, cmbprocess_id.Text);
                        if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql_f) != "")
                        {
                            MessageBox.Show("部門對應工種或類型已存在，不可以重復新增！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        //myCommand.Parameters.AddWithValue("@process_name", txtprocess_name.Text);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                    }
                    myCommand.Parameters.AddWithValue("@dept_id", lkedept_id.EditValue);
                    myCommand.Parameters.AddWithValue("@process_id", cmbprocess_id.Text);
                    myCommand.Parameters.AddWithValue("@process_name", txtprocess_name.Text);
                    myCommand.Parameters.AddWithValue("@product_qty",clsApp.Return_Float_Value(txtproduct_qty.Text));
                    myCommand.Parameters.AddWithValue("@cost_price", clsApp.Return_Float_Value(txtcost_price.Text));
                    myCommand.Parameters.AddWithValue("@cost_unit", cmbcost_unit.Text);   
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
                lkedept_id.Properties.ReadOnly = false;
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
            bool result = false;
            string ls_sql = string.Format(@"Select '1' From dbo.jo_dept_product_cost Where dept_id='{0}' and process_id='{1}'", lkedept_id.EditValue, cmbprocess_id.Text);
            if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql) == "")
                result = true;
            else
                result = false;
            return result;
        }

        private void Delete()
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(lkedept_id.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string ls_delete_id = lkedept_id.EditValue.ToString();
                string ls_process_id = cmbprocess_id.Text;
                const string sql_del = "DELETE FROM dbo.jo_dept_product_cost WHERE dept_id=@dept_id and process_id=@process_id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@dept_id", lkedept_id.EditValue);
                        myCommand.Parameters.AddWithValue("@process_id", cmbprocess_id.Text);
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
                    if (dgvFind.Rows[i].Cells["dept_id1"].Value.ToString() == ls_delete_id && dgvFind.Rows[i].Cells["process_id1"].Value.ToString() == ls_process_id)
                    {
                        dtDetail.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void Edit()
        {
            if (lkedept_id.Text == "" && cmbprocess_id.Text == "")
            {
                return;
            }
            tabControl1.SelectTab(0);
            mState = "EDIT";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtUpdate_by.Text = DBUtility._user_id;
            txtUpdate_date.Text = DateTime.Now.Date.ToString();
            
            lkedept_id.Properties.ReadOnly = true;
            lkedept_id.BackColor = Color.White;

            cmbprocess_id.Enabled = false ;
            cmbprocess_id.BackColor = Color.White;

            //lkeprocess_id.Properties.ReadOnly = true;
            //lkeprocess_id.BackColor = Color.White;
            
            lkedept_id.Focus();
            dgvDetails.Enabled = false;
        }

        private void frmDeptProductCost_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();
           dtWork.Dispose();
           dtWork_Filter.Dispose();
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
            lkedept_id.Properties.ReadOnly = false ;           

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
            @"SELECT dept_id,process_id,process_name,product_qty,cost_price,cost_unit,remark,create_by,create_date,update_by,update_date
            FROM dbo.jo_dept_product_cost With(nolock) Where dept_id>'' ";
            if (txtdept_id1.Text == "" && txtprocess_id1.Text == "" && txtprocess_id2.Text == "")
                sql = @"SELECT dept_id,process_id,process_name,product_qty,cost_price,cost_unit,remark,create_by,create_date,update_by,update_date
                      FROM dbo.jo_dept_product_cost With(nolock) order by dept_id,process_id";
            else
            {                
                if (txtdept_id1.Text != "")
                {
                    sql = sql + string.Format(" and dept_id= '{0}'", txtdept_id1.Text);
                }               
                if (txtprocess_id1.Text != "")
                {
                    sql = sql + string.Format(" and process_id>= '{0}'", txtprocess_id1.Text);
                }
                if (txtprocess_id2.Text != "")
                {
                    sql = sql + string.Format(" and process_id <='{0}'", txtprocess_id2.Text);
                }
                sql = sql + " order by dept_id,process_id";
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
            mID = pdr.Cells["dept_id"].Value.ToString();
            lkedept_id.EditValue = mID;
            cmbprocess_id.Text = pdr.Cells["process_id"].Value.ToString();
            txtprocess_name.Text = pdr.Cells["process_name"].Value.ToString();
            txtproduct_qty.Text = pdr.Cells["product_qty"].Value.ToString();
            txtcost_price.Text = pdr.Cells["cost_price"].Value.ToString();
            cmbcost_unit.Text = pdr.Cells["cost_unit"].Value.ToString();
            txtremark.Text = pdr.Cells["remark"].Value.ToString();
            txtCreate_by.Text = pdr.Cells["create_by"].Value.ToString();

            cmbprocess_id.Text = pdr.Cells["process_id"].Value.ToString();

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

     
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (dgvDetails.RowCount == 0)
            //{
            //    MessageBox.Show("沒有要列印的數據！", "提示信息");
            //    return;
            //}
            //using (xrPurDelivery rpt = new xrPurDelivery(dtcon_date1.Text, dtcon_date2.Text) { DataSource = dtDetail })
            //{
            //    rpt.CreateDocument();
            //    rpt.PrintingSystem.ShowMarginsWarning = false;
            //    rpt.ShowPreviewDialog();
            //}
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
                string ls_sql = string.Format(@"Select dept_id,create_by,create_date,update_by,update_date From dbo.jo_dept_product_cost with(nolock) WHERE dept_id='{0}' and process_id='{1}'", lkedept_id.EditValue,cmbprocess_id.Text);
                dtReSet = clsPublicOfCF01.GetDataTable(ls_sql);
                if (mState == "NEW")
                {
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["dept_id"] = lkedept_id.EditValue;
                    row["process_id"] = cmbprocess_id.Text;
                    row["process_name"] = txtprocess_name.Text;
                    row["product_qty"] = txtproduct_qty.Text;
                    row["cost_price"] = txtcost_price.Text;
                    row["cost_unit"] = cmbcost_unit.Text;
                    row["remark"] = txtremark.Text;
                    row["create_by"] = DBUtility._user_id;
                    row["create_date"] = dtReSet.Rows[0]["create_date"].ToString();
                    dtDetail.Rows.Add(row);
                }
                else
                {                    
                    dtDetail.Rows[row_reset]["dept_id"] = lkedept_id.EditValue;
                    dtDetail.Rows[row_reset]["process_id"] = cmbprocess_id.Text;
                    dtDetail.Rows[row_reset]["process_name"] = txtprocess_name.Text;
                    dtDetail.Rows[row_reset]["product_qty"] = txtproduct_qty.Text;
                    dtDetail.Rows[row_reset]["cost_price"] = txtcost_price.Text;
                    dtDetail.Rows[row_reset]["cost_unit"] = cmbcost_unit.Text; 
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
            //判段某個按鈕是否已被點擊
            //以下代碼為當保存按鈕被點擊時前進行數據的有效性檢查
            //if (btnEdit.Selected || btnDelete.Selected || btnSave.Selected)
            //{
            //    if (mState != "")
            //    {
            //        if(DBUtility._user_id=="admin")
            //        {
            //            return;
            //        }
            //        //Valid_Date();
            //    }
            //}            
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            //if (mState != "")
            //{
            //    return;
            //}
            //if (dgvFind.RowCount == 0)
            //{
            //    MessageBox.Show("沒有要匯出的數據！", "提示信息");
            //    return;
            //}
            //ExpToExcel obj = new ExpToExcel();
            //obj.ExportExcel(dgvFind);
            //obj = null;
        }

        private void txtdelivery_no1_Leave(object sender, EventArgs e)
        {
            txtprocess_id2.Text = txtprocess_id1.Text;
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                tabControl1.SelectTab(0);
                int cur_row = dgvDetails.CurrentCell.RowIndex;
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
            lkedept_id.EditValue = dtDetail.Rows[pRow]["dept_id"].ToString();
            //cmbprocess_id.Text = dtDetail.Rows[pRow]["process_id"].ToString();
            //txtprocess_name.Text = dtDetail.Rows[pRow]["process_name"].ToString();
            cmbprocess_id.Text = "";
            txtprocess_name.Text ="";
            txtproduct_qty.Text = dtDetail.Rows[pRow]["product_qty"].ToString();
            txtcost_price.Text = dtDetail.Rows[pRow]["cost_price"].ToString();
            cmbcost_unit.Text = dtDetail.Rows[pRow]["cost_unit"].ToString();
            txtremark.Text = dtDetail.Rows[pRow]["remark"].ToString();
            lkedept_id.Focus();
        }     

        private void dgvFind_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }
            tabControl1.SelectedIndex = 0;
        }

        private void lkedept_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                DataRow[] drs = dtWork.Select(string.Format("dept_id='{0}'", lkedept_id.EditValue));
                dtWork_Filter = dtWork.Clone();
                foreach (DataRow dr in drs)
                {
                    dtWork_Filter.ImportRow(dr);
                }
                Set_Drop_List(dtWork_Filter);
                //schLke1.Properties.DataSource = dt;
                //schLke1.Properties.DisplayMember = "name";
                //schLke1.Properties.ValueMember = "id";

                //lkeprocess_id.Properties.DataSource = dtWork;
                //lkeprocess_id.Properties.DisplayMember = "name";
                //lkeprocess_id.Properties.ValueMember = "id";
            }
        }

        void Set_Drop_List(DataTable dt)
        {            
            // 将组合框绑定到数据表  
            cmbprocess_id.DataSource = dt;
            cmbprocess_id.DisplayMember = "id";
            cmbprocess_id.ValueMember = "id";

            //***********
            // 启用组合框的自我绘制功能
            cmbprocess_id.DrawMode = DrawMode.OwnerDrawFixed;
            // 通过处理DrawItem事件来绘制每一项.  
            cmbprocess_id.DrawItem += delegate(object cmb, DrawItemEventArgs args)
            {
                // 绘制默认背景
                args.DrawBackground();

                // 组合框已经绑定到数据表,
                // 所以每一项均为DataRowView对象.
                DataRowView drv = (DataRowView)this.cmbprocess_id.Items[args.Index];

                // 获取每一项中对应列的值.  
                string id = drv["id"].ToString();
                string name = drv["name"].ToString();

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
            if (dt.Rows.Count == 0)
            {
                cmbprocess_id.Text = "";
                txtprocess_name.Text = "";               
            }
        }

        private void cmbprocess_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            int li_index = cmbprocess_id.SelectedIndex;
            if (li_index < 0)
            {
                return;
            }

            DataRowView drv = (DataRowView)this.cmbprocess_id.Items[li_index];
            // 获取每一项中对应列的值.              
            string name = drv["name"].ToString();
            txtprocess_name.Text = name;
        }

        private void cmbprocess_id_Leave(object sender, EventArgs e)
        {
            //if (mState != "" && dtWork_Filter.Rows.Count>0 && cmbprocess_id.Text !="" )
            //{
            //    DataRow[] drs = dtWork_Filter.Select(string.Format("id='{0}'", cmbprocess_id.Text));
            //    if (drs.Length > 0)
            //    {
            //        foreach (DataRow dr in drs)
            //        {
            //            txtprocess_name.Text = dr["name"].ToString();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("注意：此工種（或類型)代號并不存在！", "提示信息");
            //        cmbprocess_id.Text = "";
            //        txtprocess_name.Text = "";
            //        cmbprocess_id.Focus();
            //    }
            //}
        }

        private void cmbprocess_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);//將輸入小寫轉大寫

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbcost_unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtcost_price_Click(object sender, EventArgs e)
        {
            if (txtcost_price.Text == "0.000")
            {
                txtcost_price.Select(1, 0);
            }
        }


      
    }
}
