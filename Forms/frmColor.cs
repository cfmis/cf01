using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Data.SqlClient;


namespace cf01.Forms
{
    public partial class frmColor : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        MsgInfo myMsg = new MsgInfo();
        DataTable dtWorking, dtGroup, dtPlate, dtColor;
        

        public frmColor()
        {
            InitializeComponent();
            str_language = DBUtility._language;
            try
            {
                clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                control.GenerateContorl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
        }

        private void frmColor_Load(object sender, EventArgs e)
        {
            string sql_working, sql_group,sql_plate_effect,sql_color_effect;            
            if (str_language == "2")
            {
                sql_working = @"SELECT wk_code as id,wk_desc as [desc] FROM dbo.bs_working WhERE wk_kind='C'";
                sql_group = @"SELECT grp_code as id,grp_desc as [desc] FROM dbo.bs_group";
                sql_plate_effect = @"SELECT ple_code as id,ple_desc as [desc] FROM dbo.bs_plate_effect";
                sql_color_effect = @"SELECT clr_code,clr_desc as [desc] FROM dbo.bs_color_effect";
            }
            else
            {
                sql_working = @"SELECT wk_code as id,wk_cdesc as [desc] FROM dbo.bs_working WhERE wk_kind='C'";
                sql_group = @"SELECT grp_code as id,grp_cdesc as [desc] FROM dbo.bs_group";
                sql_plate_effect = @"SELECT ple_code as id,ple_cdesc as [desc] FROM dbo.bs_plate_effect";
                sql_color_effect = @"SELECT clr_code as id,clr_cdesc as [desc] FROM dbo.bs_color_effect";
            }

            //工序代碼  
            dtWorking = clsPublicOfCF01.GetDataTable(sql_working);
            DataRow row1 = dtWorking.NewRow();//插一空行
            dtWorking.Rows.Add(row1);
            dtWorking.DefaultView.Sort = "id ASC";//排序
            dtWorking = dtWorking.DefaultView.ToTable();//排序後重新賦值
            txtClr_wk_code.Properties.DataSource = dtWorking;
            txtClr_wk_code.Properties.ValueMember = "id";
            txtClr_wk_code.Properties.DisplayMember = "id";         


            //組別 
            dtGroup = clsPublicOfCF01.GetDataTable(sql_group);
            DataRow row2 = dtGroup.NewRow();
            dtGroup.Rows.Add(row2);
            dtGroup.DefaultView.Sort = "id ASC";
            dtGroup = dtGroup.DefaultView.ToTable();
            txtClr_group.Properties.DataSource = dtGroup;
            txtClr_group.Properties.ValueMember = "id";
            txtClr_group.Properties.DisplayMember = "id";

            //電鍍效果
            dtPlate = clsPublicOfCF01.GetDataTable(sql_plate_effect);
            DataRow row3 = dtPlate.NewRow();
            dtPlate.Rows.Add(row3);
            dtPlate.DefaultView.Sort = "id ASC";
            dtPlate = dtPlate.DefaultView.ToTable();
            txtClr_ple_code.Properties.DataSource = dtPlate;
            txtClr_ple_code.Properties.ValueMember = "id";
            txtClr_ple_code.Properties.DisplayMember = "id";

            //做色效果
            dtColor = clsPublicOfCF01.GetDataTable(sql_color_effect);
            DataRow row4 = dtColor.NewRow();
            dtColor.Rows.Add(row4);
            dtColor.DefaultView.Sort = "id ASC";
            dtColor = dtColor.DefaultView.ToTable();
            txtClr_clrcode.Properties.DataSource = dtColor;
            txtClr_clrcode.Properties.ValueMember = "id";
            txtClr_clrcode.Properties.DisplayMember = "id";
        }

        private void frmColor_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtWorking.Dispose();
            dtGroup.Dispose();
            dtPlate.Dispose();
            dtColor.Dispose();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
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
            Cancel();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            Excel();
        }

        // ===============以下爲自定義義方法=======================

        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
        }      

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;
            string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM bs_color WHERE clr_code='{0}'", doc);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + String.Format("【{0}】", doc), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strsql =
                    @"SELECT A.clr_code as id,A.clr_oldcode as old_clr_code,A.clr_cdesc as cdesc,A.clr_desc as edesc,A.clr_wk_code as wk_code,A.clr_group AS Sales_Group,A.clr_make as do_color,
                    A.clr_ple_code AS ple_code,A.clr_clrcode AS clr_code,A.clr_rmk as rmk,A.crusr,A.crtim,A.amusr,A.amtim,B.wk_cdesc as wk_desc,C.grp_cdesc AS group_desc,D.ple_cdesc as ple_desc,E.clr_cdesc as clr_effect_desc
                    FROM dbo.bs_color A with(nolock),
                        dbo.bs_working B with(nolock),
                        dbo.bs_group C with(nolock),
                        dbo.bs_plate_effect D with(nolock),
                        dbo.bs_color_effect E with(nolock) 
                    WHERE A.clr_wk_code *=B.wk_code AND A.clr_group *=C.grp_code AND A.clr_ple_code *= D.ple_code
                        AND A.clr_clrcode *= E.clr_code AND A.clr_code='";

                strsql += temp_id + "'";
                DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                dgvDetails.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    if (str_language == "2")
                    {
                        msgCustom = "The Code of the data does not exist.";
                    }
                    else
                    {
                        msgCustom = "編號資料不存在！";
                    }
                    MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                }
                Set_Master_Data(dt);
            }
        }     

        private void Find() //查詢出所有數據
        {
            dgvDetails.Focus();
            const string strSql =
                    @"SELECT A.clr_code as id,A.clr_oldcode as old_clr_code,A.clr_cdesc as cdesc,A.clr_desc as edesc,A.clr_wk_code as wk_code,A.clr_group AS Sales_Group,A.clr_make as do_color,
                    A.clr_ple_code AS ple_code,A.clr_clrcode AS clr_code,A.clr_rmk as rmk,A.crusr,A.crtim,A.amusr,A.amtim,B.wk_cdesc as wk_desc,C.grp_cdesc as group_desc,D.ple_cdesc as ple_desc,E.clr_cdesc as clr_effect_desc 
                    FROM dbo.bs_color A with(nolock),
                        dbo.bs_working B with(nolock),
                        dbo.bs_group C with(nolock),
                        dbo.bs_plate_effect D with(nolock),
                        dbo.bs_color_effect E with(nolock) 
                    WHERE A.clr_wk_code *=B.wk_code AND A.clr_group *=C.grp_code AND A.clr_ple_code *= D.ple_code
                        AND A.clr_clrcode *= E.clr_code ";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dt;
            mID = "";
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            if (txtID.Text == "" || txtCdesc.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Code or Description Data cannot be empty.";
                }
                else
                {
                    msgCustom = "編號或描述資料不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.Text = dtName.Rows[0]["id"].ToString();
            txtEdesc.Text = dtName.Rows[0]["edesc"].ToString();
            txtCdesc.Text = dtName.Rows[0]["cdesc"].ToString();

            txtClr_oldcode.Text = dtName.Rows[0]["old_clr_code"].ToString();
            txtClr_wk_code.EditValue = dtName.Rows[0]["wk_code"].ToString();
            txtClr_group.EditValue = dtName.Rows[0]["sales_group"].ToString();
            txtClr_make.Text = dtName.Rows[0]["do_color"].ToString();
            txtClr_ple_code.EditValue = dtName.Rows[0]["ple_code"].ToString();
            txtClr_clrcode.EditValue = dtName.Rows[0]["clr_code"].ToString();

            txtRemark.Text = dtName.Rows[0]["rmk"].ToString();
            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dtName.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dtName.Rows[0]["amtim"].ToString();

            txtWk_desc.Text = dtName.Rows[0]["wk_desc"].ToString();
            txtGrp_desc.Text = dtName.Rows[0]["group_desc"].ToString();
            txtPle_desc.Text = dtName.Rows[0]["ple_desc"].ToString();
            xtClr_desc.Text = dtName.Rows[0]["clr_effect_desc"].ToString();
            
        }

        private void Set_Row_Position(string _doc) //定位到當前行 
        {
            Find();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (_doc == dgvDetails.Rows[i].Cells["id"].Value.ToString())
                {                    
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["id"]; //設置光標定位到當前選中的行
                    dgvDetails.Rows[i].Selected = true;
                    break;
                }
            }
        }     

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();   
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls,true);                                
            SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
        }

        private void Cancel() //取消
        {
            mState = "";
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);            
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID);
            }
        }     

        private void Save()  //保存新增或修改的資料
        {
            if (!Save_Before_Valid())
            {
                return;
            }

            bool save_flag = false;

            if (mState == "NEW")
            {
                if (Valid_Doc())
                    return;

                const string sql_new =@"INSERT INTO bs_color(clr_code,clr_oldcode,clr_desc,clr_cdesc,clr_wk_code,clr_group,clr_make,clr_ple_code,clr_clrcode,clr_rmk,crusr,crtim)"+
                                    " VALUES(@id,@clr_oldcode,@edesc,@cdesc,@clr_wk_code,@clr_group,@clr_make,@clr_ple_code,@clr_clrcode,@remark,@crusr,GETDATE())";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@clr_oldcode", txtClr_oldcode.Text.Trim());
                        myCommand.Parameters.AddWithValue("@clr_wk_code", txtClr_wk_code.EditValue);
                        myCommand.Parameters.AddWithValue("@clr_group", txtClr_group.EditValue);
                        myCommand.Parameters.AddWithValue("@clr_make", txtClr_make.Text.Trim());
                        myCommand.Parameters.AddWithValue("@clr_ple_code", txtClr_ple_code.EditValue);
                        myCommand.Parameters.AddWithValue("@clr_clrcode", txtClr_clrcode.EditValue);
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        
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
            }

            if (mState == "EDIT")
            {
                const string sql_update = "UPDATE bs_color SET clr_oldcode=@clr_oldcode,clr_cdesc=@cdesc,clr_desc=@edesc,clr_wk_code=@clr_wk_code,clr_group=@clr_group,"+
                            "clr_make=@clr_make,clr_ple_code=@clr_ple_code,clr_clrcode=@clr_clrcode,clr_rmk=@remark,amusr=@amusr,amtim=GETDATE() WHERE clr_code=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@edesc", txtEdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@cdesc", txtCdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@clr_oldcode", txtClr_oldcode.Text.Trim());
                        myCommand.Parameters.AddWithValue("@clr_wk_code", txtClr_wk_code.EditValue);
                        myCommand.Parameters.AddWithValue("@clr_group", txtClr_group.EditValue);
                        myCommand.Parameters.AddWithValue("@clr_make", txtClr_make.Text.Trim());
                        myCommand.Parameters.AddWithValue("@clr_ple_code", txtClr_ple_code.EditValue);
                        myCommand.Parameters.AddWithValue("@clr_clrcode", txtClr_clrcode.EditValue);  
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());
                        myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);
                        
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
            }

            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            mState = "";

            Set_Row_Position(txtID.Text.Trim());
            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
     
        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM bs_color WHERE clr_code=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                        myCon.Dispose();
                        myTrans.Dispose();
                    }
                }

            }
        }
     
        private void Print() //通用的列印方法
        {
            if (dgvDetails.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvDetails);
            }
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(dgvDetails);
            }
        }


        //===========以下爲控件中的方法================

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                if (mState == "")
                {
                    Find_doc(txtID.Text);
                }
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtID.Text = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
                txtCdesc.Text = dgvDetails.CurrentRow.Cells["cdesc"].Value.ToString();
                txtEdesc.Text = dgvDetails.CurrentRow.Cells["edesc"].Value.ToString();

                txtClr_oldcode.Text = dgvDetails.CurrentRow.Cells["old_clr_code"].Value.ToString();
                txtClr_wk_code.EditValue = dgvDetails.CurrentRow.Cells["wk_code"].Value.ToString();
                txtClr_group.EditValue = dgvDetails.CurrentRow.Cells["sales_group"].Value.ToString();
                txtClr_make.Text = dgvDetails.CurrentRow.Cells["do_color"].Value.ToString();
                txtClr_ple_code.EditValue = dgvDetails.CurrentRow.Cells["ple_code"].Value.ToString();
                txtClr_clrcode.EditValue = dgvDetails.CurrentRow.Cells["clr_code"].Value.ToString();

                txtRemark.Text = dgvDetails.CurrentRow.Cells["rmk"].Value.ToString();
                txtCrusr.Text = dgvDetails.CurrentRow.Cells["crusr"].Value.ToString();
                txtCrtim.Text = dgvDetails.CurrentRow.Cells["crtim"].Value.ToString();
                txtAmusr.Text = dgvDetails.CurrentRow.Cells["amusr"].Value.ToString();
                txtAmtim.Text = dgvDetails.CurrentRow.Cells["amtim"].Value.ToString();

                txtWk_desc.Text = dgvDetails.CurrentRow.Cells["wk_desc"].Value.ToString();
                txtGrp_desc.Text = dgvDetails.CurrentRow.Cells["group_desc"].Value.ToString();
                txtPle_desc.Text = dgvDetails.CurrentRow.Cells["ple_desc"].Value.ToString();
                xtClr_desc.Text = dgvDetails.CurrentRow.Cells["clr_effect_desc"].Value.ToString(); 
                
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
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }


        private void txtClr_wk_code_Leave(object sender, EventArgs e)
        {
            DataRow[] dr = dtWorking.Select(String.Format("id='{0}'", txtClr_wk_code.EditValue));
            if (dr.Length > 0)
            {
                txtWk_desc.Text = dr[0]["desc"].ToString().Trim();
            }
            dtWorking.Select();
        }

        private void txtClr_group_Leave(object sender, EventArgs e)
        {
            DataRow[] dr = dtGroup.Select(String.Format("id='{0}'", txtClr_group.EditValue));
            if (dr.Length > 0)
            {
                txtGrp_desc.Text = dr[0]["desc"].ToString().Trim();
            }
            dtGroup.Select();
        }

        private void txtClr_ple_code_Leave(object sender, EventArgs e)
        {
            DataRow[] dr = dtPlate.Select(String.Format("id='{0}'", txtClr_ple_code.EditValue));
            if (dr.Length > 0)
            {
                txtPle_desc.Text = dr[0]["desc"].ToString().Trim();
            }
            dtPlate.Select();
        }

        private void txtClr_clrcode_Leave(object sender, EventArgs e)
        {
            DataRow[] dr = dtColor.Select(String.Format("id='{0}'", txtClr_clrcode.EditValue));
            if (dr.Length > 0)
            {
                xtClr_desc.Text = dr[0]["desc"].ToString().Trim();
            }
            dtColor.Select();
        }

     
     

    }
}
