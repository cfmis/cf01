/*
 * Create by :   Allen Leung
 * Create Date : 2019-04-16
 * remark:
 * 採購部——送貨單
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
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmPurDelivery : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public SqlDataAdapter SDA;      
        SqlConnection conn;
        public DataTable dtDetail = new DataTable();               
        //DataTable dtVendor = new DataTable();
        public string mState = ""; 
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
             

        public frmPurDelivery()
        {
            InitializeComponent();
            dgvFind.AutoGenerateColumns = false;//禁止自動添加列，只顯示手勸增加的部分
            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();

            clsApp.Initialize_find_value(this.Name, panel2.Controls);
        }
        private void frmPurDelivery_Load(object sender, EventArgs e)
        {
            //生成表結構           
            Load_Date();
            //數據綁定           
            txtID.DataBindings.Add("Text", bds1, "id");
            dtcon_date.DataBindings.Add("EditValue", bds1, "con_date");
            txtvendor_name.DataBindings.Add("Text", bds1, "vendor_name");
            txtdelivery_no.DataBindings.Add("Text", bds1, "delivery_no");
            dtdelivery_date.DataBindings.Add("EditValue", bds1, "delivery_date");
            cmbfactory_id.DataBindings.Add("Text", bds1, "factory_id");
            txtremark.DataBindings.Add("Text", bds1, "remark");     
            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "Update_date");
           
            
            ////供應商
            //dtVendor = clsPublicOfCF01.GetDataTable(@"select vendor_name,vendor_address from jo_pur_vendor order by id");
            //schvendor_name.Properties.DataSource = dtVendor;
            //schvendor_name.Properties.DisplayMember = "vendor_name";
            //schvendor_name.Properties.ValueMember = "vendor_name";
            cmbfactory_id1.Text = "DG";
            Find_Data();
            if (dgvDetails.Rows.Count >= 2)
            {
                dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.Rows.Count - 1].Cells[0];
                dgvDetails.BeginEdit(true);
                dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true; //選中整行
            }
        }

        private void Load_Date()
        {
            dtDetail.Clear();           
            const string sql = @"SELECT * From dbo.jo_pur_delivery Where 1=0 and state='0' ";       
            conn = new SqlConnection(DBUtility.connectionString);
            SDA = new SqlDataAdapter(sql, conn);
            SDA.Fill(dtDetail);
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;           
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

        private void AddNew()
        {
            tabControl1.SelectTab(0);
            bds1.AddNew();
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);                
            dgvDetails.Enabled = false; //表格可以編輯
      
            //新增時設置初始值
            txtID.Text = clsPur.getSerialNo("jo_pur_delivery");
            cmbfactory_id.Text = "DG";
            dtcon_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();           
            txtID.Focus();
        }

        private void Save()
        {
            txtID.Focus();
            if (txtdelivery_no.Text == "" || txtvendor_name.Text == "" || dtcon_date.Text == "")
            {
                MessageBox.Show("送貨單號,供應商,入單日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtdelivery_no.Text == "")
                {
                    txtdelivery_no.Focus();
                    return;
                }
                if (txtvendor_name.Text == "")
                {
                    txtvendor_name.Focus();
                    return;
                }
                if (dtcon_date.Text == "")
                {
                    dtcon_date.Focus();
                    return;
                }
            }
            bool save_flag = false;  
            try
            {
                if (mState == "NEW")
                {
                    dgvDetails.CurrentRow.Cells["state"].Value = "0";                    
                    if(chkFinish_status.Checked)
                        dgvDetails.CurrentRow.Cells["finish_status"].Value = true ;
                    else                      
                        dgvDetails.CurrentRow.Cells["finish_status"].Value = false;                   
                }
                bds1.EndEdit();
                SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                SDA.InsertCommand = SCB.GetInsertCommand();               
                SDA.UpdateCommand = SCB.GetUpdateCommand();
                SDA.Update(dtDetail);
                save_flag = true;
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
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);
            dgvDetails.Columns["finish_status"].ReadOnly = true;
            dgvDetails.DataSource = dtDetail;
            dgvDetails.Enabled = true;

            if (save_flag)
            {               
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
        //    string ls_sql = string.Format(@"Select '1' From dbo.jo_pur_delivery Where id='{0}'", txtID.Text);
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
                try
                {
                    dgvDetails.CurrentRow.Cells["state"].Value = "2";                    
                    bds1.EndEdit();                    
                    //数据库中进行删除
                    SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                    SDA.UpdateCommand = SCB.GetUpdateCommand();
                    SDA.Update(dtDetail);
                    dgvDetails.Rows.RemoveAt(dgvDetails.CurrentCell.RowIndex);
                    MessageBox.Show("當前數據刪除成功!", "提示信息");
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
            dgvDetails.Columns["finish_status"].ReadOnly = false;
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtUpdate_by.Text = DBUtility._user_id;
            txtUpdate_date.Text = DateTime.Now.Date.ToString();
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;
            txtID.Focus();           
        }

        private void frmPurDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           //dtVendor.Dispose();          
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
            dtDetail.RejectChanges();
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            dgvDetails.Columns["finish_status"].ReadOnly = true;
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
            @"SELECT *  FROM dbo.jo_pur_delivery With(nolock) Where 1=1 ";
            if (txtvendor_name1.Text != "" || dtcon_date1.Text != "" || dtcon_date2.Text != "" || txtdelivery_no1.Text != "" || txtdelivery_no2.Text == "" || cmbfactory_id1.Text != "")            
            {                
                if (txtvendor_name1.Text != "")
                {
                    sql += string.Format(" and vendor_name like '%{0}%'", txtvendor_name1.Text);
                }
                if (dtcon_date1.Text != "")
                {
                    sql += string.Format(" and con_date>='{0}'", clsApp.Return_String_Date(dtcon_date1.Text));
                }
                if (dtcon_date2.Text != "")
                {
                    sql += string.Format(" and con_date<='{0}'", clsApp.Return_String_Date(dtcon_date2.Text));
                }
                if (txtdelivery_no1.Text != "")
                {
                    sql += string.Format(" and delivery_no >='{0}'", txtdelivery_no1.Text);
                }
                if (txtdelivery_no2.Text != "")
                {
                    sql += string.Format(" and delivery_no <='{0}'", txtdelivery_no2.Text);
                }
                if (cmbfactory_id1.Text != "")
                {
                    sql = sql + string.Format(" and factory_id ='{0}'", cmbfactory_id1.Text);
                }                
            }            
            if (radioGroup1.SelectedIndex == 0)//未完成
            {
                sql += " and finish_status = 0";
            }
            if (radioGroup1.SelectedIndex == 1)//已完成
            {
                sql += " and finish_status = 1";
            }
            sql += " and state ='0' order by con_date desc";
            DataTable dt = new DataTable();
            conn = new SqlConnection(DBUtility.connectionString);
            SDA = new SqlDataAdapter(sql, conn);
            SDA.Fill(dt);            
            dt.Columns.Add("date_ym", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["date_ym"] = dt.Rows[i]["con_date"].ToString().Substring(0, 7);
            }
            dtDetail = dt;
            bds1.DataSource = dtDetail;            
            dgvDetails.DataSource = bds1;           
            dgvFind.DataSource = bds1;
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

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                row_reset = dgvDetails.CurrentCell.RowIndex;
                if (dgvDetails.CurrentRow.Cells["finish_status"].Value.ToString() == "True")
                {
                    chkFinish_status.Checked = true;
                }
                else
                {
                    chkFinish_status.Checked = false;
                }               
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
            using (xrPurDelivery rpt = new xrPurDelivery(dtcon_date1.Text, dtcon_date2.Text) { DataSource = dtDetail })
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

        private void txtdelivery_no1_Leave(object sender, EventArgs e)
        {
            txtdelivery_no2.Text = txtdelivery_no1.Text;
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
            txtdelivery_no.Text = dtDetail.Rows[pRow]["delivery_no"].ToString();
            dtdelivery_date.Text = dtDetail.Rows[pRow]["delivery_date"].ToString();
            txtvendor_name.Text = dtDetail.Rows[pRow]["vendor_name"].ToString();
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

            if (clsPur.Process_Excel(strFile_Excel,progressBar1))
            {
                Find_Data();
                MessageBox.Show("導入EXCEL文件成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("導入EXCEL文件失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void chkFinish_status_MouseUp(object sender, MouseEventArgs e)
        {
            if (mState == "EDIT")
            {
                if (chkFinish_status.Checked)
                    dgvDetails.CurrentRow.Cells["finish_status"].Value = true;               
                else
                    dgvDetails.CurrentRow.Cells["finish_status"].Value = false;                    
            }
        }

      
    }
}
