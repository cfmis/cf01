using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmMouldPosition : Form
    {
        clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        BindingSource bds1 = new BindingSource();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        System.Data.DataTable dtDetail = new System.Data.DataTable();
        System.Data.DataTable dtTemp = new System.Data.DataTable();       
        string pID = "";    //臨時的主鍵值
        string editState = ""; //新增或編號的狀態    
        string image_path = DBUtility.imagePath;
        string artwork_path = "";


        public frmMouldPosition()
        {
            InitializeComponent();           
            dtDetail = clsMouldPosition.GetEmptyStrutre();
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;
            //SetDataBindings();
        }

        private void frmMouldPosition_Load(object sender, EventArgs e)
        {           
            DataTable dtDept = clsBaseData.Get_Department();
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            lueDept_id.Properties.DataSource = dtDept;
            lueDept_id.Properties.ValueMember = "id";
            lueDept_id.Properties.DisplayMember = "cdesc";

            DataTable dtProdType = clsBaseData.GetProductType();
            dr0 = dtProdType.NewRow(); //插一空行        
            dtProdType.Rows.InsertAt(dr0, 0);
            lueProducts_type.Properties.DataSource = dtProdType;
            lueProducts_type.Properties.ValueMember = "id";
            lueProducts_type.Properties.DisplayMember = "id";

            lueProducts_type2.Properties.DataSource = dtProdType;
            lueProducts_type2.Properties.ValueMember = "name";
            lueProducts_type2.Properties.DisplayMember = "name";

            DataTable dtSize = clsBaseData.GetSize();
            lueMeasurement.Properties.DataSource = dtSize;
            lueMeasurement.Properties.ValueMember = "id";
            lueMeasurement.Properties.DisplayMember = "id";

            DataTable dtMouldType = clsBaseData.GetMouldType();            
            lueMould_type.Properties.DataSource = dtMouldType;
            lueMould_type.Properties.ValueMember = "id";
            lueMould_type.Properties.DisplayMember = "id";
            SetDataBindings();


        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();           
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
           Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();           
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            bds1.CancelEdit();
            //dtDetail = dtTemp.Copy();
            //bds1.DataSource = dtDetail;
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            this.SetObjReadOnly();
            dgvDetails.Enabled = true;          
            editState = "";           
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }      

        private void SetDataBindings()
        {
            lueDept_id.DataBindings.Add("EditValue", bds1, "dept_id");
            txtDept_name.DataBindings.Add("Text", bds1, "dept_name");//*           
            txtPattern_id.DataBindings.Add("Text", bds1, "pattern_id");
            txtMould_no.DataBindings.Add("Text", bds1, "mould_no");
            lueProducts_type.DataBindings.Add("EditValue", bds1, "products_type");
            lueProducts_type2.DataBindings.Add("EditValue", bds1, "products_type_name");//*
            txtMould_name.DataBindings.Add("Text", bds1, "mould_name");
            lueMeasurement.DataBindings.Add("EditValue", bds1, "measurement");
            txtSize_name.DataBindings.Add("Text", bds1, "size_name");
            txtout_qty.DataBindings.Add("Text", bds1, "out_qty");
            txtId.DataBindings.Add("Text", bds1, "id");
            lueMould_type.DataBindings.Add("EditValue", bds1, "mould_type");
            txtMould_type_name.DataBindings.Add("Text", bds1, "mould_type_name");//*
            txtstate.DataBindings.Add("Text", bds1, "state");
            txtmould_qty.DataBindings.Add("Text", bds1, "mould_qty");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtMaintenance_repair_content.DataBindings.Add("Text", bds1, "maintenance_repair_content");
            dteMould_production_date.DataBindings.Add("EditValue", bds1, "mould_production_date");
            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");
        }

        private void AddNew()  //新增
        {
            SetResetID();
            editState = "NEW";
            bds1.AddNew();           
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            SetObjValue.ClearObjValue(pnlHead.Controls, "1");
            //this.SetObjReadOnly();
            dgvDetails.Enabled = false;
            dteMould_production_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);            
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);
            lueDept_id.EditValue = "102";
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)           
            {
                return;
            }
            SetResetID();
            dtTemp = dtDetail.Copy();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);          
            dgvDetails.Enabled = false;//禁止修改
            editState = "EDIT";
            this.SetObjReadOnly();
        }

        private void SetObjReadOnly()
        {
            lueDept_id.Properties.ReadOnly = true;
            lueDept_id.BackColor = System.Drawing.Color.White;
            txtDept_name.Properties.ReadOnly = true;
            txtDept_name.BackColor = System.Drawing.Color.White;
            txtMould_no.Properties.ReadOnly = true;
            txtMould_no.BackColor = System.Drawing.Color.White;
            txtId.Properties.ReadOnly = true;
            txtId.BackColor = System.Drawing.Color.White;           
        }

        //取消還原到原始記錄位置,要用到pID進行定位
        private void SetResetID()
        {
            if (dgvDetails.Rows.Count > 0)            
            {
                pID = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["id"].Value.ToString();
            }
        }
        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;           
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;            
            btnPosition.Enabled = _flag;
                     
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }
               
        private bool Save_Before_Valid() //保存前檢查
        {
            if (lueDept_id.Text == "" || txtId.Text == "" || txtMould_no.Text=="")
            {
                MessageBox.Show("部門，模具編號或模具擺放位置不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Save()
        {
            txtRemark.Focus();
            if (!Save_Before_Valid())
            {
                return;
            }
            bds1.EndEdit();//結束修改,立即與綁定數據源一致
            bool save_flag = false;
            string sql_i =
            @"INSERT INTO cd_mould_position(within_code,id,dept_id,mould_no,pattern_id,products_type,measurement,out_qty,mould_type,mould_qty,remark,state,transfers_state,create_date,create_by,mould_name,mould_production_date,maintenance_repair_content)
            VALUES(@within_code,@id,@dept_id,@mould_no,@pattern_id,@products_type,@measurement,@out_qty,@mould_type,@mould_qty,@remark,@state,@transfers_state,getdate(),@user_id,@mould_name,
            CASE LEN(@mould_production_date) WHEN 0 THEN null ELSE @mould_production_date END,@maintenance_repair_content)";
            string sql_u =
            @"UPDATE cd_mould_position 
            SET pattern_id=@pattern_id,products_type=@products_type,measurement=@measurement,out_qty=@out_qty,mould_type=@mould_type,mould_qty=@mould_qty,remark=@remark,update_date=getdate(),update_by=@user_id,
            mould_name=@mould_name,mould_production_date =CASE LEN(@mould_production_date) WHEN 0 THEN null ELSE @mould_production_date END, maintenance_repair_content=@maintenance_repair_content 
            WHERE within_code=@within_code And id=@id And dept_id=@dept_id And mould_no=@mould_no";
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    string strDate = "";
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i].RowState == DataRowState.Modified || dtDetail.Rows[i].RowState == DataRowState.Added)
                        {
                            myCommand.Parameters.Clear();
                            if (dtDetail.Rows[i].RowState == DataRowState.Added)
                            {
                                myCommand.CommandText = sql_i;
                                myCommand.Parameters.AddWithValue("@state", "0");
                                myCommand.Parameters.AddWithValue("@transfers_state", "0");
                            }
                            else
                            {                               
                                myCommand.CommandText = sql_u;                             
                            }
                            myCommand.Parameters.AddWithValue("@within_code", "0000");
                            myCommand.Parameters.AddWithValue("@id", dtDetail.Rows[i]["id"].ToString());
                            myCommand.Parameters.AddWithValue("@dept_id", dtDetail.Rows[i]["dept_id"].ToString());
                            myCommand.Parameters.AddWithValue("@mould_no", dtDetail.Rows[i]["mould_no"].ToString());                            
                            myCommand.Parameters.AddWithValue("@pattern_id", dtDetail.Rows[i]["pattern_id"].ToString());
                            myCommand.Parameters.AddWithValue("@products_type", dtDetail.Rows[i]["products_type"].ToString());
                            myCommand.Parameters.AddWithValue("@measurement", dtDetail.Rows[i]["measurement"].ToString());
                            myCommand.Parameters.AddWithValue("@out_qty", dtDetail.Rows[i]["out_qty"].ToString());
                            myCommand.Parameters.AddWithValue("@mould_type", dtDetail.Rows[i]["mould_type"].ToString());
                            myCommand.Parameters.AddWithValue("@mould_qty", dtDetail.Rows[i]["mould_qty"].ToString());
                            myCommand.Parameters.AddWithValue("@remark", dtDetail.Rows[i]["remark"].ToString());
                            myCommand.Parameters.AddWithValue("@mould_name", dtDetail.Rows[i]["mould_name"].ToString());
                            strDate = dtDetail.Rows[i]["mould_production_date"].ToString();
                            strDate = string.IsNullOrEmpty(strDate) ? "" : strDate;
                            strDate = (strDate != "") ? DateTime.Parse(strDate).Date.ToString("yyyy/MM/dd") : "";
                            myCommand.Parameters.AddWithValue("@mould_production_date", strDate);
                            myCommand.Parameters.AddWithValue("@maintenance_repair_content", dtDetail.Rows[i]["maintenance_repair_content"].ToString());
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                    dtDetail.AcceptChanges(); //清除新增或修改的狀態                    
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
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            this.SetObjReadOnly();
            dgvDetails.Enabled = true;
            this.editState = "";
            if (save_flag)
            {
                clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }        

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {            
            if (dgvDetails.RowCount > 0)
            {
                artwork_path = dgvDetails.CurrentRow.Cells["pattern_id"].Value.ToString();
                artwork_path = string.IsNullOrEmpty(artwork_path) ? "" : artwork_path;
                if (artwork_path != "")
                {
                    SetArtwork(artwork_path);
                }
            }
        }

        private void SetArtwork(string artwork_code)
        {
            if (!string.IsNullOrEmpty(artwork_code))
            {
                pic_artwork.Image = null;
                if (artwork_code.Length >= 7)
                {
                    pic_artwork.Image = null;
                    string strArtwork = artwork_code.Substring(0, 7);
                    string strSql = string.Format(
                    @"SELECT Top 1 id,picture_name_h As picture_name FROM cd_pattern
                    Where within_code='0000' AND id='{0}' And ISNULL(picture_name_h,'')<>''", strArtwork);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt = clsConErp.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        strArtwork = image_path + dt.Rows[0]["picture_name"].ToString();
                        if (!string.IsNullOrEmpty(strArtwork))
                            pic_artwork.Image = File.Exists(strArtwork) ? Image.FromFile(strArtwork) : null;
                        else
                            pic_artwork.Image = null;
                    }
                }
            }
        }

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && string.IsNullOrEmpty(txtId.Text))
            {
                return;
            }
            int index = dgvDetails.CurrentRow.Index;
            string id = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
            string dept_id = dgvDetails.CurrentRow.Cells["dept_id"].Value.ToString();
            string mould_no = dgvDetails.CurrentRow.Cells["mould_no"].Value.ToString();
            string rtn = clsMouldPosition.DelData(id,dept_id,mould_no);
            if (rtn == "")
            {
                dtDetail.Rows.RemoveAt(index);
                bds1.DataSource = dtDetail;
                dtDetail.AcceptChanges();               
                MessageBox.Show("數據已刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Find()
        {
            if (txtId1.Text == "" && txtDept_id1.Text == "" && txtMould_no1.Text == "" && txtPattern_id1.Text == "" && txtProducts_type1.Text == "" && txtMeasurement1.Text == "")
            {
                MessageBox.Show("查詢條件不可以為空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtDetail = clsMouldPosition.FindData(txtId1.Text, txtDept_id1.Text, txtMould_no1.Text, txtPattern_id1.Text, txtProducts_type1.Text, txtMeasurement1.Text);
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            if (dtDetail.Rows.Count == 0)
            {
                return;
            }
            if (editState != "")
            {
                return;
            }
            string id = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
            string dept_id = dgvDetails.CurrentRow.Cells["dept_id"].Value.ToString();
            string mould_no = dgvDetails.CurrentRow.Cells["mould_no"].Value.ToString();

            using (frmMouldPositionEdit frm = new frmMouldPositionEdit(id, dept_id, mould_no))
            {
                frm.ShowDialog();
                if (frm.new_id != "")
                {
                    dgvDetails.CurrentRow.Cells["id"].Value = frm.new_id;
                    dtDetail.AcceptChanges();
                }
            }            
        }
             
        private void txtDept_id_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueDept_id.EditValue.ToString() != "")
                    txtDept_name.Text = lueDept_id.GetColumnValue("cdesc").ToString();
                else
                    txtDept_name.Text = "";
            }
        }

        private void lueProducts_type_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueProducts_type.EditValue.ToString() != "")
                    lueProducts_type2.EditValue = lueProducts_type.GetColumnValue("name").ToString();
                else
                    lueProducts_type.Text = "";
            }
        }

        private void lueProducts_type2_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueProducts_type2.EditValue.ToString() != "")
                    lueProducts_type.EditValue = lueProducts_type2.GetColumnValue("id").ToString();
                else
                    lueProducts_type2.Text = "";
            }
        }

        private void lueMeasurement_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueMeasurement.EditValue.ToString() != "")
                    txtSize_name.Text = lueMeasurement.GetColumnValue("name").ToString();
                else
                    txtSize_name.Text = "";
            }
        }

        private void lueMould_type_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueMould_type.EditValue.ToString() != "")
                    txtMould_type_name.Text = lueMould_type.GetColumnValue("name").ToString();
                else
                    txtMould_type_name.Text = "";
            }
        }
    }
}
