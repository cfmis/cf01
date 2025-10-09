using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ModuleClass;
using cf01.CLS;


namespace cf01.Forms
{
    public partial class frmMoComplete : Form
    {
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        DataTable dtDetail = new DataTable();
        public SqlDataAdapter SDA;
        public string mState = "";
        SqlConnection conn;
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示     
       // clsToolBar objToolbar;

        public frmMoComplete()
        {
            InitializeComponent();

            //clsTranslate obj_ctl = new clsTranslate( this.Controls, DBUtility._language);
            //obj_ctl.Translate();

            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);            
        }

        private void frmMoComplete_Load(object sender, EventArgs e)
        {  
            LoadDate();
            //系統狀態           
            DataTable dtState = new DataTable();
            dtState.Columns.Add(new DataColumn("id", typeof(string)));
            dtState.Columns.Add(new DataColumn("name", typeof(string)));
            DataRow dr = dtState.NewRow();
            dr["id"] = "0";
            dr["name"] = "未批準";
            dtState.Rows.Add(dr);
            dr = dtState.NewRow();
            dr["id"] = "2";
            dr["name"] = "已注銷";
            dtState.Rows.Add(dr);                      
            luestate.Properties.DataSource = dtState;
            luestate.Properties.ValueMember = "id";
            luestate.Properties.DisplayMember = "name";

            //數據綁定           
            txtmo_id.DataBindings.Add("Text", bds1, "mo_id");           
            txtremark.DataBindings.Add("Text", bds1, "remark");           
            luestate.DataBindings.Add("EditValue", bds1, "state");
            txtcreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtcreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtupdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtupdate_date.DataBindings.Add("Text", bds1, "Update_date");
        }

      

        private void LoadDate()
        {
            dtDetail.Clear();           
            string sql = @"SELECT * From so_mo_complete with(nolock) ORDER BY create_date DESC";            
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
            //btnFind.Enabled = _flag;

            btnSave.Enabled = !_flag;
            btnUndo.Enabled = !_flag;
            //if (objToolbar != null)
            //{
            //    objToolbar.SetToolBar();
            //}
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {            
            bds1.AddNew();
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            luestate.EditValue = "0";
            txtcreate_by.Text = DBUtility._user_id;
            txtcreate_date.Text = DateTime.Now.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }
            if (mState == "NEW" && txtmo_id.Text != "")
            {                
                if (!CheckMO())
                {
                    txtmo_id.Focus();
                    return;
                }
            }                 
           
            //dgvDetails.CurrentCell.RowIndex;行號
            //Select a Cell Focus
            dgvDetails.CurrentCell = dgvDetails.Rows[0].Cells["mo_id"];
            //Selected a Row 
            dgvDetails.Rows[0].Selected = true;

            bool flag_datavalid = false;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["mo_id"].Value.ToString() == "")
                {
                    flag_datavalid = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["mo_id"];//選中當前空白的行                    
                    break;
                }
            }
            if (flag_datavalid)
            {
                MessageBox.Show("制單編號不可為空 !", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bds1.EndEdit();
                SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                SDA.InsertCommand = SCB.GetInsertCommand();
                SDA.UpdateCommand = SCB.GetUpdateCommand();
                SDA.Update(dtDetail);
                LoadDate();
                clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
                SCB = null;
                SetButtonSatus(true);
                SetObjValue.SetEditBackColor(panel1.Controls, false);
                mState = "";
                txtmo_id.Properties.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }			
            if (MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    luestate.EditValue = "2";
                    bds1.EndEdit();
                    //dgvDetails.Rows.RemoveAt(dgvDetails.CurrentCell.RowIndex);
                    //数据库中进行删除
                    SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                    SDA.UpdateCommand = SCB.GetUpdateCommand();
                    //SDA.DeleteCommand = SCB.GetDeleteCommand();
                    SDA.Update(dtDetail);
                    dgvDetails.Rows.RemoveAt(dgvDetails.CurrentCell.RowIndex);
                    clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
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
            }
        }

        private void frmMoComplete_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail=null ;
           SDA = null;
           conn.Close();
           conn.Dispose();          
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtmo_id.Text == "")
            {
                return;
            }
            mState = "Edit";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtupdate_by.Text = DBUtility._user_id;
            txtupdate_date.Text = DateTime.Now.ToString();
            txtmo_id.Properties.ReadOnly = true;
            txtmo_id.BackColor = Color.White;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            bds1.CancelEdit();
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);           
            mState = "";
            txtmo_id.Properties.ReadOnly = true;
            LoadDate();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void txtmo_id_Leave(object sender, EventArgs e)
        {
            if (mState == "NEW" && txtmo_id.Text !="")
            {
                string sql = string.Format("SELECT '1' FROM so_mo_complete with(nolock) Where mo_id='{0}'", txtmo_id.Text);
                if(clsPublicOfCF01.ExecuteSqlReturnObject(sql) != "")
                {
                    MessageBox.Show($"輸入的制單編號已存在[{ txtmo_id.Text}]!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmo_id.Text = "";
                    return;
                }
                if (!CheckMO())
                {
                    txtmo_id.Focus();
                }
            }
        }

        private bool CheckMO()
        {
            bool result = true;
            if (mState == "NEW" && txtmo_id.Text != "")
            {
                string sql = string.Format("SELECT '1' FROM so_order_details with(nolock) Where within_code='0000' And mo_id='{0}'", txtmo_id.Text);
                if (clsErp.ExecuteSqlReturnObject(sql) == "")
                {
                    MessageBox.Show("輸入的制單編號并不存在,請返回檢查!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);                   
                    result = false;                    
                }
                else
                {                 
                    result = true;
                }
            }
            return result;
        }

        private void luestate_EditValueChanged(object sender, EventArgs e)
        {
            if (luestate.EditValue.ToString() == "2")
            {
                this.luestate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            }
            else
                this.luestate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            
        }
    }
}
