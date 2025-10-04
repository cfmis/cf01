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
    public partial class frmGoodsRelease : Form
    {
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        DataTable dtDetail = new DataTable();
        public SqlDataAdapter SDA;
        public string mState = "";
        SqlConnection conn;
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示     
       // clsToolBar objToolbar;

        public frmGoodsRelease()
        {
            InitializeComponent();

            //clsTranslate obj_ctl = new clsTranslate( this.Controls, DBUtility._language);
            //obj_ctl.Translate();

            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);            
        }

        private void frmGoodsRelease_Load(object sender, EventArgs e)
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

            string sql = "Select vendor_id as id,vendor_name as name From bs_release_vendor order by vendor_id";
            DataTable dtVendor = clsPublicOfCF01.GetDataTable(sql);
            lueVendor_id.Properties.DataSource = dtVendor;
            lueVendor_id.Properties.ValueMember = "id";
            lueVendor_id.Properties.DisplayMember = "id";
            

            //數據綁定           
            txtid.DataBindings.Add("Text", bds1, "id");
            txtDate.DataBindings.Add("EditValue", bds1, "bill_date");
            txtserial_number.DataBindings.Add("Text", bds1, "serial_number");
            lueVendor_id.DataBindings.Add("EditValue", bds1, "vendor_id");
            txtvendor_name.DataBindings.Add("Text", bds1, "vendor_name");            
            cbeReason.DataBindings.Add("EditValue", bds1, "reason");
            txtother_desc.DataBindings.Add("Text", bds1, "other_desc");
            txtgoods_desc.DataBindings.Add("Text", bds1, "goods_desc");
            txtremark.DataBindings.Add("Text", bds1, "remark");
            txtapply_by.DataBindings.Add("Text", bds1, "apply_by");
            txtapproved_by.DataBindings.Add("Text", bds1, "approved_by");
            luestate.DataBindings.Add("EditValue", bds1, "state");
            txtcreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtcreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtupdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtupdate_date.DataBindings.Add("Text", bds1, "Update_date");
        }

      

        private void LoadDate()
        {
            dtDetail.Clear();           
            string sql = @"SELECT * From bs_release with(nolock) Order BY create_date DESC";            
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
            txtDate.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            GenSerialNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }             
           
            //dgvDetails.CurrentCell.RowIndex;行號
            //Select a Cell Focus
            dgvDetails.CurrentCell = dgvDetails.Rows[0].Cells["bill_date"];
            //Selected a Row 
            dgvDetails.Rows[0].Selected = true;

            bool flag_datavalid = false;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                string goods_desc = dgvDetails.Rows[i].Cells["goods_desc"].Value.ToString();
                if (dgvDetails.Rows[i].Cells["bill_date"].Value.ToString() == ""|| dgvDetails.Rows[i].Cells["vendor_id"].Value.ToString()==""||
                    dgvDetails.Rows[i].Cells["goods_desc"].Value.ToString() == "")
                {
                    flag_datavalid = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["bill_date"];//選中當前空白的行                    
                    break;
                }
            }
            if (flag_datavalid)
            {
                MessageBox.Show("【日期，供應商，攜帶物品】不可為空 !", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bds1.EndEdit();
                SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
                SDA.InsertCommand = SCB.GetInsertCommand();
                SDA.UpdateCommand = SCB.GetUpdateCommand();
                SDA.Update(dtDetail);               
                clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
                SCB = null;
                SetButtonSatus(true);
                SetObjValue.SetEditBackColor(panel1.Controls, false);
                mState = "";
                txtid.Properties.ReadOnly = true;
                this.LoadDate();
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

        private void frmGoodsRelease_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail=null ;
           SDA = null;
           conn.Close();
           conn.Dispose();          
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                return;
            }
            mState = "Edit";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtupdate_by.Text = DBUtility._user_id;
            txtupdate_date.Text = DateTime.Now.ToString();
            txtid.Properties.ReadOnly = true;
            txtid.BackColor = Color.White;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            bds1.CancelEdit();
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);           
            mState = "";
            txtid.Properties.ReadOnly = true;
            LoadDate();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadDate();
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

        private void GenSerialNumber()
        {
            if (mState == "NEW" && txtDate.Text != "")
            {
                txtserial_number.Text = DateTime.Now.ToString("yyyyMMddhhmm");
            }
        }

        private void lueVendor_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                if (lueVendor_id.Text != "")
                    txtvendor_name.Text = lueVendor_id.GetColumnValue("name").ToString();
                else
                    txtvendor_name.Text = "";
            }
        }

        private void txtvendor_name_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mState =="")
            {
                using (frmGoodsReleaseVendor ofrm = new frmGoodsReleaseVendor())
                {
                    ofrm.ShowDialog();
                }
            }
        }
    }
}
