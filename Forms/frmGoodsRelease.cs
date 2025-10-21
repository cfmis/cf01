using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ModuleClass;
using cf01.CLS;
using cf01.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;

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
        DataTable dtReport = new DataTable();
        
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

            SetDataBindings();

            //初始貨打印報表結構
            dtReport.Columns.Add("bill_date", typeof(string));
            dtReport.Columns.Add("vendor_id", typeof(string));
            dtReport.Columns.Add("serial_number", typeof(string));
            dtReport.Columns.Add("reason", typeof(string));
            dtReport.Columns.Add("goods_desc", typeof(string));
            dtReport.Columns.Add("other_desc", typeof(string));
            dtReport.Columns.Add("approved_by", typeof(string));
            dtReport.Columns.Add("apply_by", typeof(string));
            dtReport.Columns.Add("car_id", typeof(string));
            dtReport.Columns.Add("worker_id", typeof(string));
        }

        private void SetDataBindings()
        {
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
            txtCar_id.DataBindings.Add("Text", bds1, "car_id");
            txtWorker_id.DataBindings.Add("Text", bds1, "worker_id");
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
            btnPrint.Enabled = _flag;
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
            int index = dgvDetails.CurrentCell.RowIndex;
            dgvDetails.Rows[index].Cells["bill_date"].Value = txtDate.EditValue.ToString();
            dgvDetails.Rows[index].Cells["serial_number"].Value = txtserial_number.Text;
            txtDate.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }
            dgvDetails.Refresh();
            //dgvDetails.CurrentCell.RowIndex;行號
            //Select a Cell Focus
            //dgvDetails.CurrentCell = dgvDetails.Rows[0].Cells["bill_date"];
            //Selected a Row 
            dgvDetails.Rows[0].Selected = true;
            string billDate = "", vendorId = "", goodsDesc = "";
            bool flag_datavalid = false;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                billDate = dgvDetails.Rows[i].Cells["bill_date"].Value.ToString();
                vendorId = dgvDetails.Rows[i].Cells["vendor_id"].Value.ToString();
                goodsDesc = dgvDetails.Rows[i].Cells["goods_desc"].Value.ToString();
                if (billDate == ""|| vendorId == ""|| goodsDesc == "")
                {
                    flag_datavalid = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["bill_date"];//選中當前空白的行                    
                    break;
                }
            }
            if (flag_datavalid)
            {
                MessageBox.Show("【日期，供應商或攜帶物品】不可為空 !", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtDate.Enabled = false;
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

            
        private void luestate_EditValueChanged(object sender, EventArgs e)
        {
            if (luestate.EditValue.ToString() == "2")
            {
                this.luestate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            }
            else
                this.luestate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));

            if (mState != "")
            {
                if (dgvDetails.CurrentCell == null)
                {
                    return;
                }
                int index = dgvDetails.CurrentCell.RowIndex;
                dgvDetails.Rows[index].Cells["state"].Value = luestate.EditValue.ToString();
            }

        }

        private void GenSerialNumber()
        {
            if (mState == "NEW" && txtDate.Text != "")
            {
                string strDate = txtDate.EditValue.ToString()+" "+ DateTime.Now.ToString("hh:mm:ss");
                txtserial_number.Text = DateTime.Parse(strDate).ToString("yyyyMMddhhmmss") ;
            }
        }

        private void lueVendor_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                string vendorName = "";
                if (lueVendor_id.EditValue.ToString() != "")
                {
                    vendorName = lueVendor_id.GetColumnValue("name").ToString();
                    txtvendor_name.Text = vendorName;
                }
                else
                    txtvendor_name.Text = "";

                int index = dgvDetails.CurrentCell.RowIndex;
                dgvDetails.Rows[index].Cells["vendor_id"].Value = lueVendor_id.EditValue.ToString();
                dgvDetails.Rows[index].Cells["vendor_name"].Value = vendorName; 
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }
            dtReport.Clear();
            int index = dgvDetails.CurrentCell.RowIndex; //行號
            DataRow dr = dtReport.NewRow();            
            dr["bill_date"] = dgvDetails.Rows[index].Cells["bill_date"].Value.ToString();
            dr["vendor_id"] = dgvDetails.Rows[index].Cells["vendor_id"].Value.ToString();
            dr["serial_number"] = dgvDetails.Rows[index].Cells["serial_number"].Value.ToString();
            dr["reason"] = dgvDetails.Rows[index].Cells["reason"].Value.ToString();
            dr["goods_desc"] = dgvDetails.Rows[index].Cells["goods_desc"].Value.ToString();
            dr["other_desc"] = dgvDetails.Rows[index].Cells["other_desc"].Value.ToString();
            dr["approved_by"] = dgvDetails.Rows[index].Cells["approved_by"].Value.ToString();
            dr["apply_by"] = dgvDetails.Rows[index].Cells["apply_by"].Value.ToString();
            dr["car_id"] = dgvDetails.Rows[index].Cells["car_id"].Value.ToString();
            dr["worker_id"] = dgvDetails.Rows[index].Cells["worker_id"].Value.ToString();
            dtReport.Rows.Add(dr);
            xrGoodsRelease rpt = new xrGoodsRelease() { DataSource = dtReport };
            rpt.CreateDocument();
            rpt.PrintingSystem.ShowMarginsWarning = false;
            rpt.ShowPreviewDialog();
        }

        private void txtvendor_name_Leave(object sender, EventArgs e)
        {
            SetGridValue(txtvendor_name, "vendor_name");            
        }

        private void cbeReason_EditValueChanged(object sender, EventArgs e)
        {
            SetGridValue(cbeReason, "reason");            
        }

        private void txtgoods_desc_EditValueChanged(object sender, EventArgs e)
        {
            SetGridValue(txtgoods_desc, "goods_desc");         
        }

        private void txtremark_EditValueChanged(object sender, EventArgs e)
        {
            SetGridValue(txtremark, "remark");         
        }

        private void txtapply_by_EditValueChanged(object sender, EventArgs e)
        {
            SetGridValue(txtapply_by, "apply_by");           
        }

        private void txtapproved_by_EditValueChanged(object sender, EventArgs e)
        {
            SetGridValue(txtapproved_by, "approved_by");
        }
        private void SetGridValue(TextEdit obj,string fieldName)
        {
            if (mState != "")
            {
                if (dgvDetails.CurrentCell == null)
                {
                    return;
                }
                int index = dgvDetails.CurrentCell.RowIndex;
                dgvDetails.Rows[index].Cells[fieldName].Value = obj.Text;
            }
        }

       
    }
}
