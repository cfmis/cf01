using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace cf01.Forms
{
    public partial class frmBrand : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public string mEdit_Node_Sate = ""; 

        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示     
        DataTable dtBrand = new DataTable();
        DataTable dtBrand_group = new DataTable();
        DataTable dtBrand_office = new DataTable();
        DataTable dtGroupDel = new DataTable();
        DataTable dtOfficeDel = new DataTable();
        DataTable dtCountry = new DataTable();
        DataTable dtParentBrand = new DataTable();
        DataTable dtGroup = new DataTable();
        DataTable dtArea = new DataTable();
        DataTable dtContact = new DataTable();
        DataTable dtOffice = new DataTable();
        DataTable dtTree_Data = new DataTable();

        public frmBrand()
        {
            InitializeComponent();

            try
            {
                clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                control.GenerateContorl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            dtCountry = clsPublicOfCF01.GetDataTable("SELECT id,cdesc,edesc FROM bs_country with(nolock)");
            DataRow dr1 = dtCountry.NewRow(); //插一空行
            dr1["id"] = "";
            dtCountry.Rows.InsertAt(dr1, 0);
            txtOrigin.Properties.DataSource = dtCountry;
            txtOrigin.Properties.ValueMember = "id";
            txtOrigin.Properties.DisplayMember = "id";

            dtParentBrand = clsPublicOfCF01.GetDataTable("SELECT id,cdesc,edesc FROM bs_brand with(nolock)");
            DataRow dr2 = dtParentBrand.NewRow(); //插一空行
            dr2["id"] = "";
            dtParentBrand.Rows.InsertAt(dr2, 0);
            txtParent_id.Properties.DataSource = dtParentBrand;
            txtParent_id.Properties.ValueMember = "id";
            txtParent_id.Properties.DisplayMember = "id";

            dtBrand_group = clsPublicOfCF01.GetDataTable("SELECT * FROM bs_brand_group WHERE 1=0");
            dtBrand_office = clsPublicOfCF01.GetDataTable("SELECT * FROM bs_brand_office WHERE 1=0");
            gridControl1.DataSource = dtBrand_group;
            gridControl2.DataSource = dtBrand_office;
            //臨時項目刪除表結構
            dtGroupDel = dtBrand_group.Clone();
            dtOfficeDel = dtBrand_office.Clone();
            //組別
            dtGroup = clsPublicOfCF01.GetDataTable("SELECT grp_code,grp_cdesc FROM dbo.bs_group WITH(nolock)");
            DataRow dr3 = dtGroup.NewRow(); //插一空行
            dr3["grp_code"] = "";
            dtGroup.Rows.InsertAt(dr3, 0);
            colGroup_id.DataSource = dtGroup;
            colGroup_id.ValueMember = "grp_code";
            colGroup_id.DisplayMember = "grp_cdesc";
            //區域
            dtArea = clsPublicOfCF01.GetDataTable("SELECT id,cdesc,edesc FROM dbo.bs_area WITH(nolock)");
            DataRow dr4 = dtArea.NewRow(); //插一空行
            dr4["id"] = "";
            dtArea.Rows.InsertAt(dr4, 0);
            colArea_id.DataSource = dtArea;
            colArea_id.ValueMember = "id";
            colArea_id.DisplayMember = "cdesc";
            //寫字樓
            dtOffice = clsPublicOfCF01.GetDataTable("SELECT id,cdesc FROM dbo.bs_office WITH(nolock)");
            DataRow dr5 = dtOffice.NewRow(); //插一空行
            dr5["id"] = "";
            dtOffice.Rows.InsertAt(dr5, 0);
            colOffice_id.DataSource = dtOffice;
            colOffice_id.ValueMember = "id";
            colOffice_id.DisplayMember = "cdesc";
            //聯系人
            // dtContact = DBUtility.GetDataTable("SELECT sale_code,sale_cdesc,sale_desc,sale_group FROM dbo.bs_sale WITH(nolock) ORDER BY sale_group,sale_code");
            dtContact = clsPublicOfCF01.GetDataTable("SELECT sale_code,(sale_group+' '+sale_cdesc) AS sale_cdesc FROM dbo.bs_sale WITH(nolock) ORDER BY sale_group,sale_code");
            DataRow dr6 = dtContact.NewRow(); //插一空行
            dr6["sale_code"] = "";
            dtContact.Rows.InsertAt(dr6, 0);
            colContact.DataSource = dtContact;
            colContact.ValueMember = "sale_code";
            colContact.DisplayMember = "sale_cdesc";

            SetTreeView();
        }

        private void frmBrand_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtBrand.Dispose();
            dtBrand_group.Dispose();
            dtBrand_office.Dispose();
            dtGroupDel.Dispose();
            dtOfficeDel.Dispose();
            dtCountry.Dispose();
            dtParentBrand.Dispose();
            dtGroup.Dispose();
            dtArea.Dispose();
            dtContact.Dispose();
            dtOffice.Dispose();
            dtTree_Data.Dispose();
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

        // ===============以下爲自定義方法=======================
        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            btnItemAdd1.Enabled = !_flag;
            btnItemAdd2.Enabled = !_flag;
            btnItemDel1.Enabled = !_flag;
            btnItemDel2.Enabled = !_flag;

            gridView2.OptionsBehavior.Editable = !_flag;
            gridView1.OptionsBehavior.Editable = !_flag;
        }

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;
            string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM dbo.bs_brand WHERE id='{0}'", doc);
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

        private bool Save_Before_Valid() //保存前檢查
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                if (str_language == "2")
                {
                    msgCustom = "Brand No.cannot be empty.";
                }
                else
                {
                    msgCustom = "牌子編號不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strsql = String.Format(@"SELECT A.*,B.cdesc as country_name FROM dbo.bs_brand A with(nolock) 
                                                LEFT JOIN bs_country B with(nolock) ON A.origin=B.id WHERE A.id='{0}'", temp_id);
                dtBrand = clsPublicOfCF01.GetDataTable(strsql);
                if (dtBrand.Rows.Count == 0)
                {
                    if (str_language == "2")
                    {
                        msgCustom = "The Brand No. of the data does not exist.";
                    }
                    else
                    {
                        msgCustom = "牌子編號資料不存在！";
                    }
                    MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                else
                {
                    string strsql1 = String.Format("SELECT * FROM dbo.bs_brand_group with(nolock) WHERE id='{0}'", temp_id);
                    dtBrand_group = clsPublicOfCF01.GetDataTable(strsql1);
                    strsql1 = String.Format("SELECT * FROM dbo.bs_brand_office with(nolock) WHERE id='{0}'", temp_id);
                    dtBrand_office = clsPublicOfCF01.GetDataTable(strsql1);
                    gridControl1.DataSource = dtBrand_group;
                    gridControl2.DataSource = dtBrand_office;

                    mID = txtID.Text;//保存臨時的ID號
                }
                Set_Master_Data(dtBrand);
            }
        }

        private void Set_Master_Data(DataTable dtName)
        {
            txtID.Text = dtName.Rows[0]["id"].ToString();
            txtEdesc.Text = dtName.Rows[0]["edesc"].ToString();
            txtCdesc.Text = dtName.Rows[0]["cdesc"].ToString();
            txtOrigin.EditValue = dtName.Rows[0]["origin"].ToString();
            txtCountry_name.Text = dtName.Rows[0]["country_name"].ToString();
            txtParent_id.EditValue = dtName.Rows[0]["parent_id"].ToString();
            txtDivision.Text = dtName.Rows[0]["division"].ToString();

            if (dtName.Rows[0]["is_print_logo"].ToString() == "frue")
            {
                chkIs_print_logo.Checked = false;
            }
            else
            {
                chkIs_print_logo.Checked = true;
            }
            txtDesigner.Text = dtName.Rows[0]["designer"].ToString();
            txtFollower.Text = dtName.Rows[0]["follower"].ToString();
            txtBrand_applicant.Text = dtName.Rows[0]["brand_applicant"].ToString();
            txtJeanette_involved.Text = dtName.Rows[0]["jeanette_involved"].ToString();
            txtRemark.Text = dtName.Rows[0]["remark"].ToString();
            txtCrusr.Text = dtName.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dtName.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dtName.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dtName.Rows[0]["amtim"].ToString();
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void Edit()  //編號
        {
            if (dtBrand.Rows.Count == 0)
            {
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            mState = "EDIT";
            mID = txtID.Text;

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            SetObjValue.ClearObjValue(this.Controls, "2");

            dtGroupDel.Clear();
            dtOfficeDel.Clear();
            dtBrand_group.Clear();
            gridControl1.DataSource = dtBrand_group;
            dtBrand_office.Clear();
            gridControl2.DataSource = dtBrand_office;

            mState = "";
            mEdit_Node_Sate = "";
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID);
            }
        }

        private void Save()  //保存新增或修改的資料
        {
            btnItemAdd1.Focus();
            btnItemAdd2.Focus();
            if (!Save_Before_Valid())
            {
                return;
            }

            if (!string.IsNullOrEmpty(txtParent_id.EditValue.ToString()))
            {
                if (txtParent_id.EditValue.ToString() == txtID.Text)
                {
                    MessageBox.Show("當前節點(牌子編號)與上級節點不可以相同!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    return;
                }
                if (IsExists_Loop(txtParent_id.EditValue.ToString(), txtID.Text))
                {
                    return; //檢查節點是否存在循環，如是則不允許保存。
                }                
            }

            if (!Check_Details_Valid(gridView1, 1))//檢查明細資料的有效性
            {
                return;
            }
            if (!Check_Details_Valid(gridView2, 2))
            {
                return;
            }
            bool save_flag = false;
            bool PrintLogo;

            #region 新增和編號
            //新增
            if (mState == "NEW")
            {
                if (Valid_Doc())
                {
                    return;
                }
                const string sql_new =
                @"INSERT INTO dbo.bs_brand(id,cdesc,edesc,origin,parent_id,remark,is_print_logo,division,jeanette_involved,brand_applicant,follower,designer,crusr,crtim) 
                VALUES(@id,@cdesc,@edesc,@origin,@parent_id,@remark,@is_print_logo,@division,@jeanette_involved,@brand_applicant,@follower,@designer,@crusr,getdate())";
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
                        myCommand.Parameters.AddWithValue("@origin", txtOrigin.EditValue);
                        myCommand.Parameters.AddWithValue("@parent_id", txtParent_id.EditValue);
                        if (chkIs_print_logo.Checked)
                            PrintLogo = true;
                        else
                            PrintLogo = false;
                        myCommand.Parameters.AddWithValue("@is_print_logo", PrintLogo);
                        myCommand.Parameters.AddWithValue("@division", txtDivision.Text.Trim());
                        myCommand.Parameters.AddWithValue("@jeanette_involved", txtJeanette_involved.Text.Trim());
                        myCommand.Parameters.AddWithValue("@brand_applicant", txtBrand_applicant.Text.Trim());
                        myCommand.Parameters.AddWithValue("@follower", txtFollower.Text.Trim());
                        myCommand.Parameters.AddWithValue("@designer", txtDesigner.Text.Trim());
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();

                        //保存明細1
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_brand_group(id,seq_id,group_id,area_id,contact,remark) 
                                    VALUES(@id,@seq_id,@group_id,@area_id,@contact,@remark)";
                            string strSeq_id = "";
                            for (int i = 0; i < dtBrand_group.Rows.Count; i++)
                            {
                                myCommand.CommandText = sql_item_i;
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("id", txtID.Text.Trim());
                                strSeq_id = Get_Details_Seq(txtID.Text.Trim(), "1"); //新增狀態重新取最大序號;
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@group_id", dtBrand_group.Rows[i]["group_id"].ToString());
                                myCommand.Parameters.AddWithValue("@area_id", dtBrand_group.Rows[i]["area_id"].ToString());
                                myCommand.Parameters.AddWithValue("@contact", dtBrand_group.Rows[i]["contact"].ToString());
                                myCommand.Parameters.AddWithValue("@remark", dtBrand_group.Rows[i]["remark"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }

                        //保存明細2
                        if (gridView2.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_brand_office(id,seq_id,office_id,remark) VALUES(@id,@seq_id,@office_id,@remark)";
                            string strSeq_id = "";
                            for (int i = 0; i < dtBrand_office.Rows.Count; i++)
                            {
                                myCommand.CommandText = sql_item_i;
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("id", txtID.Text.Trim());
                                strSeq_id = Get_Details_Seq(txtID.Text.Trim(), "2"); //新增狀態重新取最大序號;
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@office_id", dtBrand_office.Rows[i]["office_id"].ToString());
                                myCommand.Parameters.AddWithValue("@remark", dtBrand_office.Rows[i]["remark"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }

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

            //編輯
            if (mState == "EDIT")
            {
                string rowStatus = "";
                string strSeq_id = "";
                const string sql_update =
                    @"UPDATE dbo.bs_brand SET edesc=@edesc,cdesc=@cdesc,origin=@origin,parent_id=@parent_id,is_print_logo=@is_print_logo,
                    division=@division,jeanette_involved=@jeanette_involved,brand_applicant=@brand_applicant,follower=@follower,designer=@designer,
                    remark=@remark,amusr=@amusr,amtim=getdate() WHERE id=@id";
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
                        myCommand.Parameters.AddWithValue("@origin", txtOrigin.EditValue);
                        myCommand.Parameters.AddWithValue("@parent_id", txtParent_id.EditValue);
                        if (chkIs_print_logo.Checked)
                            PrintLogo = true;
                        else
                            PrintLogo = false;
                        myCommand.Parameters.AddWithValue("@is_print_logo", PrintLogo);
                        myCommand.Parameters.AddWithValue("@division", txtDivision.Text.Trim());
                        myCommand.Parameters.AddWithValue("@jeanette_involved", txtJeanette_involved.Text.Trim());
                        myCommand.Parameters.AddWithValue("@brand_applicant", txtBrand_applicant.Text.Trim());
                        myCommand.Parameters.AddWithValue("@follower", txtFollower.Text.Trim());
                        myCommand.Parameters.AddWithValue("@designer", txtDesigner.Text.Trim());
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());
                        myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();

                        //明細資料1有刪除
                        const string sql_item_d1 = @"DELETE FROM dbo.bs_brand_group WHERE id=@id AND seq_id=@seq_id";
                        for (int i = 0; i < dtGroupDel.Rows.Count; i++)
                        {

                            myCommand.CommandText = sql_item_d1;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@seq_id", dtGroupDel.Rows[i]["seq_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                        //明細資料2有刪除
                        const string sql_item_d2 = @"DELETE FROM dbo.bs_brand_office WHERE id=@id AND seq_id=@seq_id";
                        for (int i = 0; i < dtOfficeDel.Rows.Count; i++)
                        {
                            myCommand.CommandText = sql_item_d2;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@seq_id", dtOfficeDel.Rows[i]["seq_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }

                        //保存明細資料1
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_brand_group(id,seq_id,group_id,area_id,contact,remark) 
                                    VALUES(@id,@seq_id,@group_id,@area_id,@contact,@remark)";
                            const string sql_item_u =
                                @"UPDATE bs_brand_group SET group_id=@group_id,area_id=@area_id,contact=@contact,remark=@remark
                                  WHERE id=@id AND seq_id=@seq_id";
                            for (int i = 0; i < dtBrand_group.Rows.Count; i++)
                            {
                                rowStatus = dtBrand_group.Rows[i].RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                    {
                                        myCommand.CommandText = sql_item_i;
                                        strSeq_id = Get_Details_Seq(txtID.Text.Trim(), "1"); //新增狀態重新取最大序號
                                    }
                                    if (rowStatus == "Modified")
                                    {
                                        myCommand.CommandText = sql_item_u;
                                        strSeq_id = dtBrand_group.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                    }
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                    myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                    myCommand.Parameters.AddWithValue("@group_id", dtBrand_group.Rows[i]["group_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@area_id", dtBrand_group.Rows[i]["area_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@contact", dtBrand_group.Rows[i]["contact"].ToString());
                                    myCommand.Parameters.AddWithValue("@remark", dtBrand_group.Rows[i]["remark"].ToString());
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        //保存明細資料2
                        if (gridView2.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO bs_brand_office(id,seq_id,office_id,remark) VALUES(@id,@seq_id,@office_id,@remark)";
                            const string sql_item_u =
                                @"UPDATE bs_brand_office SET office_id=@office_id,remark=@remark WHERE id=@id AND seq_id=@seq_id";
                            for (int i = 0; i < dtBrand_office.Rows.Count; i++)
                            {
                                rowStatus = dtBrand_office.Rows[i].RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                    {
                                        myCommand.CommandText = sql_item_i;
                                        strSeq_id = Get_Details_Seq(txtID.Text.Trim(), "2"); //新增狀態重新取最大序號
                                    }
                                    if (rowStatus == "Modified")
                                    {
                                        myCommand.CommandText = sql_item_u;
                                        strSeq_id = dtBrand_office.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                    }
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                    myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                    myCommand.Parameters.AddWithValue("@office_id", dtBrand_office.Rows[i]["office_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@remark", dtBrand_office.Rows[i]["remark"].ToString());
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                        }

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
            #endregion

            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            mState = "";
            dtGroupDel.Clear();
            dtOfficeDel.Clear();
            if (save_flag)
            {
                if (!string.IsNullOrEmpty(mEdit_Node_Sate))
                {
                    SetTreeView(); 
                }
               
                Find_doc(txtID.Text);
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            mEdit_Node_Sate = "";
        }

        private void Delete() //刪除當前行
        {
            if (dtBrand.Rows.Count == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }

            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM dbo.bs_season WHERE id=@id";
                const string sql_del_group = "DELETE FROM dbo.bs_brand_group WHERE id=@id";
                const string sql_del_office = "DELETE FROM dbo.bs_brand_office WHERE id=@id";
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

                        myCommand.CommandText = sql_del_group;
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = sql_del_office;
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交                        
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

        private void Find() //查詢出所有數據
        {
            //dgvDetails.Focus();
            //DataTable dt = DBUtility.GetDataTable("SELECT id ,cdesc,edesc,remark as rmk,crusr,crtim,amusr,amtim FROM dbo.bs_season");
            //dgvDetails.DataSource = dt;
        }

        private void Print() //通用的打印方法
        {
            //
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

        private void btnItemAdd1_Click(object sender, EventArgs e)
        {
            AddNew_Item(gridView1, 1);
        }

        private void btnItemDel1_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = gridView1.FocusedRowHandle;
                string strSeq = gridView1.GetRowCellDisplayText(curRow, "seq_id");
                //將當前行刪除幷加到臨時表中
                DataRow newRow = dtGroupDel.NewRow();
                newRow["id"] = txtID.Text;
                newRow["seq_id"] = strSeq;
                newRow["group_id"] = gridView1.GetRowCellDisplayText(curRow, "group_id");
                newRow["contact"] = gridView1.GetRowCellDisplayText(curRow, "contact");
                newRow["remark"] = gridView1.GetRowCellDisplayText(curRow, "remark"); ;
                dtGroupDel.Rows.Add(newRow);
                gridView1.DeleteRow(curRow);//移走當前行                
            }
        }

        private void btnItemAdd2_Click(object sender, EventArgs e)
        {
            AddNew_Item(gridView2, 2);
        }

        private void btnItemDel2_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = gridView2.FocusedRowHandle;
                string strSeq = gridView2.GetRowCellDisplayText(curRow, "seq_id");
                //將當前行刪除幷加到臨時表中
                DataRow newRow = dtOfficeDel.NewRow();
                newRow["id"] = txtID.Text;
                newRow["seq_id"] = strSeq;
                newRow["office_id"] = gridView2.GetRowCellDisplayText(curRow, "office_id");
                newRow["remark"] = gridView2.GetRowCellDisplayText(curRow, "remark"); ;
                dtOfficeDel.Rows.Add(newRow);
                gridView2.DeleteRow(curRow);//移走當前行
            }
        }

        private void AddNew_Item(GridView _View, int _i)
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
            {
                if (!Check_Details_Valid(_View, _i))
                {
                    return;
                }
                string cln = "";
                if (_i == 1)
                {
                    cln = "group_id";
                }
                else
                {
                    cln = "office_id";
                }
                int row_seq = _View.RowCount + 1;
                _View.AddNewRow();//新增                    
                _View.SetRowCellValue(_View.FocusedRowHandle, "seq_id", row_seq.ToString("000"));

                ColumnView oView = (ColumnView)_View;//初始單元格焦點
                oView.FocusedColumn = oView.Columns[cln];
                oView.Focus();
            }
            else
            {
                MessageBox.Show("主檔資料不可爲空", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControl1.SelectedTab = tabControl1.TabPages[0];
                txtID.Focus();
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView2.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = gridView2.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        /// <summary>
        /// //檢查明細資料的有效性
        /// </summary>
        /// <param name="_View"></param>
        /// <param name="_i"></param>
        /// <returns></returns>
        private bool Check_Details_Valid(GridView _View, int _i)
        {
            bool _flag = true;
            if (_View.RowCount > 0)
            {
                int curRow = 0;
                for (int i = 0; i < _View.RowCount; i++)
                {
                    curRow = _View.GetRowHandle(i);
                    string cln = "";
                    if (_i == 1)
                    {
                        cln = "group_id";
                        msgCustom = "組別不可以爲空.";
                    }
                    else
                    {
                        cln = "office_id";
                        msgCustom = "寫字樓不可以爲空.";
                    }
                    if (String.IsNullOrEmpty(_View.GetRowCellDisplayText(curRow, cln)))
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[_i];
                        _flag = false;
                        MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ColumnView oView = (ColumnView)_View;//初始單元格焦點
                        oView.FocusedColumn = oView.Columns[cln];
                        oView.Focus();
                        break;
                    }
                }
            }
            return _flag;
        }

        /// <summary>
        /// //取明細的序號
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static string Get_Details_Seq(string _id, string _type)
        {
            DataTable dtMaxseq = new DataTable();
            if (_type == "1")
            {
                dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.bs_brand_group with(nolock) WHERE id='{0}'", _id));
            }
            else
            {
                dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.bs_brand_office with(nolock) WHERE id='{0}'", _id));
            }
            string strSeq;
            if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
            {
                strSeq = "001";
            }
            else
            {
                strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000");
            }
            dtMaxseq.Dispose();
            return strSeq;
        }

        private void txtOrigin_EditValueChanged(object sender, EventArgs e)
        {
            if (txtOrigin.EditValue.ToString() != "")
            {
                txtCountry_name.Text = txtOrigin.GetColumnValue("cdesc").ToString();
            }
        }
        private void SetTreeView()
        {
            TreeView1.Nodes.Clear();
            TreeNode TopNode = new TreeNode() { Text = "牌子資料", Tag = "" };
            TreeView1.Nodes.Add(TopNode);

            const string strSql = @"SELECT id,cdesc,isnull(parent_id,'') as parent_id FROM dbo.bs_brand ORDER BY id";
            dtTree_Data = clsPublicOfCF01.GetDataTable(strSql);
            DataRow[] drArr = dtTree_Data.Select(string.Format("parent_id='{0}'", ""));
            TreeNode node_brand;
            foreach (DataRow dr in drArr)
            {
                node_brand = new TreeNode();
                node_brand.Text = String.Format("[{0}] {1}", dr["id"], dr["cdesc"]);
                node_brand.Tag = dr["id"].ToString();//保存牌子編號                       
                TopNode.Nodes.Add(node_brand); //將所有節點加到最頂層節點下
                //tvwBrand.Nodes.Add(node_brand);
                AddChildNode(node_brand, node_brand.Tag.ToString());//递归调用                
            }
            //tvwBrand.ExpandAll();
            TopNode.Expand();
            TreeView1.SelectedNode = TreeView1.Nodes[0].Nodes[0];
        }

        /// <summary>
        /// 递归调用,添加子節點
        /// </summary>
        /// <param name="tsi"></param>
        public void AddChildNode(TreeNode subNode, string _brand)
        {
            DataRow[] drArr = dtTree_Data.Select(String.Format("parent_id='{0}'", _brand));//查下層子牌子            
            if (drArr.Length == 0)
            {
                subNode.ImageIndex = subNode.SelectedImageIndex = 1;
                return;
            }
            TreeNode subNode1;
            foreach (DataRow dr in drArr)
            {
                subNode1 = new TreeNode();//实例化一个子節點
                subNode1.Text = String.Format("[{0}]{1}", dr["id"], dr["cdesc"]);
                subNode1.Tag = dr["id"].ToString(); //保存表單名
                subNode.Nodes.Add(subNode1);
                AddChildNode(subNode1, dr["id"].ToString());//递归调用
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (mState == "")
            {
                string strBrand_id = e.Node.Tag.ToString().Trim();
                if (!string.IsNullOrEmpty(strBrand_id))
                {
                    txtID.Text = strBrand_id;
                    Find_doc(strBrand_id);
                }
            }
        }
       
        private bool IsExists_Loop(string _Parent_Node,string _id) // 是否存在死循環
        {
            SqlParameter[] paras = new SqlParameter[] {new SqlParameter("@Pid",_Parent_Node),
                                                       new SqlParameter("@Sub_id",_id)
                                                      };
            DataTable dtBom = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_brand_isloop", paras);
            
            int records = dtBom.Rows.Count;
            if (records == 0)
            {
                return false;
            }
            else
            {
                //從第一條記錄中取當前子節點
                string id = dtBom.Rows[0]["id"].ToString();
                //從最後一條記錄中取父節點
                string parent_id = dtBom.Rows[records - 1]["parent_id"].ToString();
                if (parent_id != id)
                {
                    return false;
                }
                else
                {
                    msgCustom = String.Format("設置的上級節點有問題,將出現無限循環!\n\n 因已存在節點【{0}】-->子節點【{1}】.", dtBom.Rows[records - 1]["parent_id"], dtBom.Rows[records - 1]["id"]);
                    MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    return true ;
                }
            }
        }

        private void txtParent_id_Leave(object sender, EventArgs e)
        {
            if (dtBrand.Rows[0]["id"].ToString() != txtParent_id.EditValue.ToString())
            {
                mEdit_Node_Sate = "1";
            }            
            //if (txtParent_id.EditValue.ToString() != "")
            //{
            //    mEdit_Node_Sate = "1";
            //}
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
