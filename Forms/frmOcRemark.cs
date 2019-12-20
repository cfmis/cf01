/*
 * Create by :   Allen Leung 
 * Create Date : 2018-11-13
 * remark:
 * HK E組 Shipping Mark
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
using System.Runtime.InteropServices;

namespace cf01.Forms
{
    public partial class frmOcRemark : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public DataTable dtReSet = new DataTable();             
        public string mState = ""; 
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();
        public static List<mdlOcRemark> mList = new List<mdlOcRemark>();

        //提示信息窗口自動關閉聲明
        //需引入using System.Runtime.InteropServices;
        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeout(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);

        public frmOcRemark()
        {
            InitializeComponent();
            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();
        }       
        private void frmTommyTest_Load(object sender, EventArgs e)
        {
            const string sql = @"SELECT * From oc_packing_remark with(nolock) where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            
            dgvDetails.DataSource = dtDetail;

            dtDat1.EditValue = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd").Substring(0, 10);
            dtDat2.EditValue = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 10);
           
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
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            //新增時設置初始值
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();
            txtform_date.Text = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            txtserial_no.Text = clsTommyTest.GetSeqNo("oc_packing_remark", "serial_no");
           

            txtserial_no.Properties.ReadOnly = true;
            txtserial_no.BackColor = Color.White;

            dgvDetails.Enabled = false;
            txtoc_no.Focus();
        }

        private void Save()
        {
            txtserial_no.Focus();
            if (txtserial_no.Text == "" && txtform_date.Text == "")
            {
                MessageBox.Show("Serial No.、日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtform_date.Focus();
                return;
            }
            //bds1.EndEdit();
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO oc_packing_remark(serial_no,form_date,oc_no,mo_list,cust_no,shipping_remark,job_no,po_no,article_no,create_by,create_date) 
            VALUES(@serial_no,@form_date,@oc_no,@mo_list,@cust_no,@shipping_remark,@job_no,@po_no,@article_no,@user_id,getdate())";

            const string sql_update =
            @"Update oc_packing_remark 
            SET form_date=@form_date,oc_no=@oc_no,mo_list=@mo_list,cust_no=@cust_no,shipping_remark=@shipping_remark,job_no=@job_no,
                po_no=@po_no,article_no=@article_no,update_by=@user_id,update_date=getdate()
            WHERE serial_no=@serial_no";

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
                        strSerial_no = clsTommyTest.GetSeqNo("oc_packing_remark", "serial_no");
                        myCommand.Parameters.AddWithValue("@serial_no", strSerial_no);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@serial_no", txtserial_no.Text);
                        strSerial_no = txtserial_no.Text;
                    }                    
                    myCommand.Parameters.AddWithValue("@form_date", clsApp.Return_String_Date(txtform_date.Text));
                    myCommand.Parameters.AddWithValue("@oc_no", txtoc_no.Text);
                    myCommand.Parameters.AddWithValue("@mo_list", memmo_list.Text);
                    myCommand.Parameters.AddWithValue("@cust_no", txtcust_no.Text);
                    myCommand.Parameters.AddWithValue("@shipping_remark", memshipping_remark.Text);
                    myCommand.Parameters.AddWithValue("@job_no", txtjob_no.Text);
                    myCommand.Parameters.AddWithValue("@po_no", txtpo_no.Text);
                    myCommand.Parameters.AddWithValue("@article_no", memarticle_no.Text);
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
            dgvDetails.Enabled = true;

            if (save_flag)
            {
                ReSet_Datagrid_Value();
                //新增狀態下定位到新增的行
                if (mState == "NEW")
                {
                    int cur_row_index = dgvDetails.RowCount - 1;
                    dgvDetails.CurrentCell = dgvDetails.Rows[cur_row_index].Cells[2]; //设置当前单元格
                    dgvDetails.Rows[cur_row_index].Selected = true; //選中整行
                }
                mState = "";                
                //MessageBox.Show("數據保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBoxTimeout((IntPtr)0, "數據保存成功!", "提示信息", 0, 0, 1000); //提示窗體1秒后自動關閉    
                
            }
            else
            {                
               MessageBox.Show("數據保存失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);                
            }
        }

        private void Delete()
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtserial_no.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM dbo.oc_packing_remark WHERE serial_no=@serial_no";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@serial_no", txtserial_no.Text);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
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
            }
        }

        private void Edit()
        {
            if (txtserial_no.Text == "")
            {
                return;
            }
            tabControl1.SelectTab(0);
            mState = "EDIT";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtUpdate_by.Text = DBUtility._user_id;
            txtUpdate_date.Text = DateTime.Now.Date.ToString();
            txtserial_no.Properties.ReadOnly = true;
            txtserial_no.BackColor = Color.White;
        }

        private void frmOcRemark_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();          
           objToolbar = null;
           clsApp = null;
           mList.Clear();
           mList = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {           
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "1");
            mState = "";
            txtserial_no.Properties.ReadOnly = true;
            dgvDetails.Enabled = true;
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
            string sql = @"SELECT * From oc_packing_remark with(nolock) Where 1=1 ";
            if (txtserial_no1.Text == "" && txtserial_no2.Text == "" && dtDat1.Text == "" && dtDat2.Text == "")
                sql = @"SELECT * From oc_packing_remark with(nolock)";
            else
            {                
                if (txtserial_no1.Text != "")
                {
                    sql = sql + string.Format(" and serial_no>='{0}'", txtserial_no1.Text);
                }
                if (txtserial_no2.Text != "")
                {
                    sql = sql + string.Format(" and serial_no<='{0}'", txtserial_no2.Text);
                }
                if (txtoc_no1.Text != "")
                {
                    sql = sql + string.Format(" and oc_no>='{0}'", txtoc_no1.Text);
                }
                if (txtoc_no2.Text != "")
                {
                    sql = sql + string.Format(" and oc_no<='{0}'", txtoc_no2.Text);
                }
                if (dtDat1.Text != "")
                {
                    sql = sql + string.Format(" and form_date>='{0}'", clsApp.Return_String_Date(dtDat1.Text));
                }
                if (dtDat2.Text != "")
                {
                    sql = sql + string.Format(" and form_date<='{0}'", clsApp.Return_String_Date(dtDat2.Text));
                }
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            //bds1.DataSource = dtDetail;
            dgvDetails.DataSource = dtDetail;
            dgvFind.DataSource = dtDetail;
        }

        /// <summary>
        /// 新增或編號時更新Datagridview的值
        /// 不必從服務端重新下載
        /// </summary>
        private void ReSet_Datagrid_Value()
        {
            string strSerial_no = txtserial_no.Text;
            if (mState == "NEW" || mState == "EDIT")
            {
                //取得當前新增或修改的行
                dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select serial_no,create_by,create_date,update_by,update_date From dbo.oc_packing_remark with(nolock) WHERE serial_no='{0}'", strSerial_no));
                if (mState == "NEW")
                {
                    //dgvDetails.AllowUserToAddRows = true;                    
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["serial_no"] = txtserial_no.Text ;
                    row["form_date"] = clsApp.Return_String_Date(txtform_date.Text);
                    row["oc_no"] = txtoc_no.Text;
                    row["mo_list"] = memmo_list.Text;
                    row["cust_no"] = txtcust_no.Text;
                    row["shipping_remark"] = memshipping_remark.Text;
                    row["job_no"] = txtjob_no.Text;
                    row["po_no"] = txtpo_no.Text;
                    row["article_no"] = memarticle_no.Text;
                   
                    row["create_by"] = txtCreate_by.Text;
                    if (!string.IsNullOrEmpty(txtCreate_date.Text))
                    {
                        row["create_date"] = DateTime.Parse(txtCreate_date.Text);
                    }
                    row["update_by"] = txtUpdate_by.Text;
                    if (!string.IsNullOrEmpty(txtUpdate_date.Text))
                    {
                        row["update_date"] = DateTime.Parse(txtUpdate_date.Text);
                    }                    
                    dtDetail.Rows.Add(row);
                }
                else
                {        
                    dtDetail.Rows[row_reset]["serial_no"] = txtserial_no.Text;
                    dtDetail.Rows[row_reset]["form_date"] = clsApp.Return_String_Date(txtform_date.Text);
                    dtDetail.Rows[row_reset]["oc_no"] = txtoc_no.Text;
                    dtDetail.Rows[row_reset]["mo_list"] = memmo_list.Text;
                    dtDetail.Rows[row_reset]["cust_no"] = txtcust_no.Text;
                    dtDetail.Rows[row_reset]["shipping_remark"] = memshipping_remark.Text;
                    dtDetail.Rows[row_reset]["job_no"] = txtjob_no.Text;
                    dtDetail.Rows[row_reset]["po_no"] = txtpo_no.Text;
                    dtDetail.Rows[row_reset]["article_no"] = memarticle_no.Text;                    
                                 
                    dtDetail.Rows[row_reset]["create_by"] = txtCreate_by.Text;
                    dtDetail.Rows[row_reset]["create_date"] = txtCreate_date.Text;
                    dtDetail.Rows[row_reset]["update_by"] = txtUpdate_by.Text;
                    dtDetail.Rows[row_reset]["update_date"] = txtUpdate_date.Text;                    
                }
                dtDetail.AcceptChanges();
                dgvDetails.DataSource = dtDetail;
                dgvDetails.Refresh();
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
            mID = pdr.Cells["serial_no"].Value.ToString();
            txtserial_no.Text = pdr.Cells["serial_no"].Value.ToString();
            txtform_date.EditValue = Convert.ToDateTime(pdr.Cells["form_date"].Value.ToString()).ToString("yyyy-MM-dd");
            txtoc_no.Text = pdr.Cells["oc_no"].Value.ToString();
            memmo_list.Text = pdr.Cells["mo_list"].Value.ToString();
            txtcust_no.Text = pdr.Cells["cust_no"].Value.ToString();
            memshipping_remark.Text = pdr.Cells["shipping_remark"].Value.ToString();
            txtjob_no.Text = pdr.Cells["job_no"].Value.ToString();
            txtpo_no.Text = pdr.Cells["po_no"].Value.ToString();
            memarticle_no.Text = pdr.Cells["article_no"].Value.ToString();            
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

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtserial_no2.Text = txtserial_no1.Text;
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDat2.Text = dtDat1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount ==0)
            {
                MessageBox.Show("沒有要列印的數據！","提示信息");
                return;
            }
            string strsql = string.Format(@"Select * FROM dbo.oc_packing_remark WHERE serial_no='{0}'",txtserial_no.Text);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(strsql);
            using (xrShippingRemark rpt = new xrShippingRemark() { DataSource = dtReport })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
            }
        }     

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                AddNew();
                Set_head(dgvrow);
                txtform_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                txtserial_no.Text = clsTommyTest.GetSeqNo("oc_packing_remark", "serial_no");
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtoc_no_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtoc_no.Text != "" && mState != "")
            {
                using (frmOcFindMo ofrmFind = new frmOcFindMo(txtoc_no.Text))
                {
                    ofrmFind.ShowDialog();
                    if (mList.Count > 0)
                    {
                        string strmo = "", articleno = "";
                        foreach (mdlOcRemark stu in mList)
                        {
                            strmo += stu.mo_id + ", ";
                            if (stu.articleno != "")
                            {
                                articleno += stu.articleno + "\r";
                            }
                            txtpo_no.Text = stu.po_no;
                        }
                        memmo_list.Text = strmo;
                        memarticle_no.Text = articleno;
                    }
                }
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
    }
}
