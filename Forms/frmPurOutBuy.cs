/*
 * Create by :   Allen Leung
 * Create Date : 2019-04-12
 * remark:
 * 採購部——外出購物清單
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
    public partial class frmPurOutBuy : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public string mState = ""; 
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        int m_row_no_before_add = 0;//新增時用于記錄當前最大的行號
        public SqlDataAdapter SDA;        
        SqlConnection conn;

        public frmPurOutBuy()
        {
            InitializeComponent();

            //權限
            //objToolbar = new clsToolBar(this.Name, this.Controls);
            //objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmPurOutBuy_Load(object sender, EventArgs e)
        {
            DataTable dtDept = clsGeoDepartment.getDepartment();
            clDept_id.DataSource = dtDept;
            clDept_id.DisplayMember = "id";
            clDept_id.ValueMember = "id";

            dtDetail.Clear();
            const string sql = @"SELECT * From dbo.jo_pur_outbuy where 1=0 ";
            //dtDetail = clsPublicOfPad.GetDataTable(sql);
            conn = new SqlConnection(DBUtility.connectionString);
            SDA = new SqlDataAdapter(sql, conn);
            SDA.Fill(dtDetail);
            
            //生成表結構
            //const string ls_sql = @"SELECT * From dbo.jo_pur_outbuy where 1=0 ";
            //dtDetail = clsPublicOfCF01.GetDataTable(ls_sql);
            bds1.DataSource = dtDetail;
            gridControl1.DataSource = bds1;         

                   
            Find_Data();
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
            m_row_no_before_add = gridView1.RowCount-1;
            mState = "NEW";
            SetButtonSatus(false);
            //SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);

            bds1.AddNew();
            int li_cur_row = gridView1.FocusedRowHandle;
            //gridView1.SetRowCellValue(li_cur_row, "id", clsPur.getSerialNo("jo_pur_outbuy"));
            gridView1.SetRowCellValue(li_cur_row, "factory_id", "DG");
            gridView1.SetRowCellValue(li_cur_row, "con_date", DateTime.Now.Date.ToString("yyyy-MM-dd"));
            gridView1.SetRowCellValue(li_cur_row, "vendor_name", "現金");
            Set_Grid_Status(true);
        }

        private void Save()
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            row_reset = gridView1.FocusedRowHandle;//記錄最新的當前行，方便編輯，保存后重新定位
            if (gridView1.RowCount > 1)
            {
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
            bds1.EndEdit();
            gridView1.CloseEditor();
            bool flag_datavalid = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, "con_date") == "" || gridView1.GetRowCellDisplayText(i, "dept_id") == "" || gridView1.GetRowCellDisplayText(i, "goods_name") == "")
                {
                    flag_datavalid = true;
                    gridView1.FocusedRowHandle = i;//選中當前數據不完整的行
                    break;
                }
            }
            if (flag_datavalid)
            {
                MessageBox.Show("日期、部門或者貨品名稱不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            bool save_flag = false;
            try
            {
                string rowStatus;
                string ls_is_buy="";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    rowStatus = gridView1.GetDataRow(i).RowState.ToString();
                    if (rowStatus == "Added" || rowStatus == "Modified")
                    {
                        if (rowStatus == "Added")
                        {
                            gridView1.SetRowCellValue(i, "create_by", DBUtility._user_id);
                            gridView1.SetRowCellValue(i, "create_date", DateTime.Now.Date.ToString());                           
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "update_by", DBUtility._user_id);
                            gridView1.SetRowCellValue(i, "update_date", DateTime.Now.Date.ToString());
                        }
                        ls_is_buy = gridView1.GetRowCellValue(i, "is_buy").ToString();
                        if (ls_is_buy == "" || ls_is_buy == "False")
                        {
                            gridView1.SetRowCellValue(i, "is_buy", false);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "is_buy", true);
                        }
                    }
                }

                bds1.EndEdit();
                SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                SDA.InsertCommand = SCB.GetInsertCommand();
                SDA.UpdateCommand = SCB.GetUpdateCommand();
                SDA.Update(dtDetail);
                save_flag = true;                
                SCB = null;

                SetButtonSatus(true);
                //SetObjValue.SetEditBackColor(panel1.Controls, false);
                //mState = "";
                Set_Grid_Status(false);
                
            }
            catch (Exception ex)
            {
                save_flag = false ;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (save_flag)
            {
                Find_Data();
                //新增狀態下定位到新增的行
                if (mState == "NEW")
                {
                    //int cur_row_index = dgvDetails.RowCount - 1;
                    //if (cur_row_index >= 0)
                    //{
                    //    dgvDetails.CurrentCell = dgvDetails.Rows[cur_row_index].Cells[2]; //设置当前单元格
                    //    dgvDetails.Rows[cur_row_index].Selected = true; //選中整行
                    //}
                    
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                }
                else
                {
                    gridView1.FocusedRowHandle = row_reset;
                }               
                //dtDetail.AcceptChanges();
                mState = "";
                clsUtility.myMessageBox("數據保存成功!", "提示信息");
            }

        }

        private void Set_Grid_Status(bool _flag) // 表格是否可編輯
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag;
            //gridView2.OptionsBehavior.Editable = _flag;
        }

        ///// <summary>
        ///// 新增時判斷主鍵是否已存在
        ///// </summary>
        ///// <returns></returns>
        //private bool Valid_Date()
        //{
        //    bool result=false ;
        //    string ls_sql = string.Format(@"Select '1' From dbo.jo_pur_outbuy Where id='{0}'", txtID.Text);
        //    if (clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql) == "")
        //        result = true ;
        //    else
        //        result = false;
        //    return result;
        //}

        private void Delete()
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            
            string ls_delete_id="";
            if (MessageBox.Show("确定要刪除当前行？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ls_delete_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    //数据库中进行删除
                    SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                    SDA.DeleteCommand = SCB.GetDeleteCommand();
                    SDA.Update(dtDetail);
                    clsUtility.myMessageBox("數據删除成功!", "提示信息"); 
                    SCB = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                ////移走表格中已刪除的記錄
                ////应该采用倒序循环刪除,因为正序删除时索引会发生变化
                //if (ls_delete_id != "")
                //{
                //    for (int i = dgvFind.Rows.Count - 1; i >= 0; i--)
                //    {
                //        if (dgvFind.Rows[i].Cells["id1"].Value.ToString() == ls_delete_id)
                //        {
                //            dtDetail.Rows.RemoveAt(i);
                //        }
                //    }
                //}
            }
        }

        private void Edit()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {               
                mState = "EDIT";
                SetButtonSatus(false);
                //SetObjValue.SetEditBackColor(panel1.Controls, true);
                Set_Grid_Status(true);
            }
        }

        private void frmPurOutBuy_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();                 
           objToolbar = null;
           clsApp = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {           
            Edit();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {           
            SetButtonSatus(true);
            //SetObjValue.SetEditBackColor(panel1.Controls, false);
            Set_Grid_Status(false);           
            mState = "";
            bds1.CancelEdit();

            if (m_row_no_before_add > 0)
            {
                //需進行此處理，否則新增后再按灰復按鈕數據刷新有問題
                //行將記錄移動一下，使新增狀態下的行號由負數變正數,bds1.CancelEdit方起作用
                gridView1.FocusedRowHandle = m_row_no_before_add;
            }            
            dtDetail.RejectChanges();//取消數據更改      
           
            //if (!String.IsNullOrEmpty(mID) && dgvDetails.RowCount > 0)
            //{
            //    dgvDetails.CurrentCell = dgvDetails.Rows[row_reset].Cells[2]; //设置当前单元格
            //    dgvDetails.Rows[row_reset].Selected = true; //選中整行
            //}            
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
            string sql = @"SELECT * From dbo.jo_pur_outbuy with(nolock) Where id>0 ";
            if (txtvendor_name1.Text == "" && dtcon_date1.Text == "" && dtcon_date2.Text == "" 
                && txtPo_id1.Text =="" &&txtPo_id2.Text=="" && txtDept1.Text =="" && txtDept2.Text =="" && cmbfactory_id1.Text ==""
                && radioGroup1.SelectedIndex == 2)
                sql = @"SELECT * From dbo.jo_pur_outbuy with(nolock) order by id";
            else
            {                
                if (txtvendor_name1.Text != "")
                {
                    sql = sql + string.Format(" and vendor_name like '%{0}%'", txtvendor_name1.Text);
                }               
                if (dtcon_date1.Text != "")
                {
                    sql = sql + string.Format(" and con_date>='{0}'", clsApp.Return_String_Date(dtcon_date1.Text));
                }
                if (dtcon_date2.Text != "")
                {
                    sql = sql + string.Format(" and con_date<='{0}'", clsApp.Return_String_Date(dtcon_date2.Text));
                }
                if (txtPo_id1.Text != "")
                {
                    sql = sql + string.Format(" and po_id >='{0}'", txtPo_id1.Text);
                }
                if (txtPo_id2.Text != "")
                {
                    sql = sql + string.Format(" and po_id <='{0}'", txtPo_id2.Text);
                }
                if (txtDept1.Text != "")
                {
                    sql = sql + string.Format(" and dept_id >='{0}'", txtDept1.Text);
                }
                if (txtDept2.Text != "")
                {
                    sql = sql + string.Format(" and dept_id <='{0}'", txtDept2.Text);
                }
                if (cmbfactory_id1.Text != "")
                {
                    sql = sql + string.Format(" and factory_id ='{0}'", cmbfactory_id1.Text);
                }
                if (radioGroup1.SelectedIndex == 0)//未完成
                {
                    sql = sql + " and is_buy = 0";
                }
                if (radioGroup1.SelectedIndex == 1)//已完成
                {
                    sql = sql + " and is_buy = 1";
                }
                sql = sql + " order by id";
            }

            conn = new SqlConnection(DBUtility.connectionString);
            SDA = new SqlDataAdapter(sql, conn);
            SDA.Fill(dtDetail);
            bds1.DataSource = dtDetail;
            gridControl1.DataSource = bds1;            
                      
            if (dtDetail.Rows.Count == 0)
            {                
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


        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtcon_date2.EditValue = dtcon_date1.EditValue;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("沒有要列印的數據！", "提示信息");
                return;
            }
            DataTable dtReport = dtDetail.Copy();
            DataColumn date_ym = new DataColumn("date_ym", typeof(string)); //添加数据类型为字符形
            dtReport.Columns.Add(date_ym);
            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                //dtReport.Rows[i]["date_ym"] = dtReport.Rows[i]["con_date"].ToString().Substring(0, 7);
                dtReport.Rows[i]["date_ym"] = "";
            }

            using (xrPurOutBuy rpt = new xrPurOutBuy(dtcon_date1.Text, dtcon_date2.Text) { DataSource = dtReport })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
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
            //txtremark.Focus();
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
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("沒有要匯出的數據！", "提示信息");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog() { 
                Title = "Export To Excel", 
                Filter = "Excel files (*.xls)|*.xls" 
            };
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                gridControl1.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("匯出EXCEL成功!", "提示信息");
            }            
        }


        private void txtPo_id1_Leave(object sender, EventArgs e)
        {
            txtPo_id2.Text = txtPo_id1.Text;
        }        

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
               
                int cur_row = gridView1.FocusedRowHandle;
                AddNew();               
                Set_head(cur_row);
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //復制新增用到此方法
        private void Set_head(int cur_row)
        {
            mdlPur lst_pur = new mdlPur() {
                con_date = DateTime.Parse(dtDetail.Rows[cur_row]["con_date"].ToString()).Date.ToString("yyyy-MM-dd"),
                dept_id = dtDetail.Rows[cur_row]["dept_id"].ToString(),
                factory_id = dtDetail.Rows[cur_row]["factory_id"].ToString(),
                po_id = dtDetail.Rows[cur_row]["po_id"].ToString(),
                goods_name = dtDetail.Rows[cur_row]["goods_name"].ToString(),
                qty_desc = dtDetail.Rows[cur_row]["qty_desc"].ToString(),
                vendor_name = dtDetail.Rows[cur_row]["vendor_name"].ToString(),
                remark = dtDetail.Rows[cur_row]["remark"].ToString(),
                is_buy = dtDetail.Rows[cur_row]["is_buy"].ToString() == "True" ? true : false 
            };            
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "con_date", lst_pur.con_date);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "dept_id", lst_pur.dept_id);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "factory_id", lst_pur.factory_id);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "po_id", lst_pur.po_id);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "goods_name", lst_pur.goods_name);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "qty_desc", lst_pur.qty_desc);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "vendor_name", lst_pur.vendor_name);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "remark", lst_pur.remark);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "is_buy", lst_pur.is_buy);

        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.Text = txtDept1.Text;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                row_reset = gridView1.FocusedRowHandle;
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void clbtnPo_id_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //調用GEO申購單資料
            gridView1.CloseEditor();
            if (mState=="NEW" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString() == "")
            {
                using (frmPurOutBuy_Add ofrm = new frmPurOutBuy_Add(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "po_id").ToString()))
                {
                    ofrm.ShowDialog();
                    if (ofrm.m_pur_list.Count > 0)
                    {
                        int i = 0;
                        foreach (mdlPur ls_pur in ofrm.m_pur_list)
                        {
                            if (i > 0)
                            {
                                gridView1.AddNewRow();//新增
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "con_date", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                            }                            
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "po_id", ls_pur.po_id);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "dept_id", ls_pur.dept_id);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "factory_id", "DG");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "goods_name", ls_pur.goods_name);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "qty_desc", ls_pur.qty_desc);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "vendor_name", "現金");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "remark", ls_pur.remark);
                            i += 1;
                        }
                        SetFocuse(gridView1, gridView1.FocusedRowHandle, "goods_name"); //重定位到最后一行,并定位焦點單元格
                    }
                }
            }
        }

      
    }
}
