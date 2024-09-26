using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using cf01.CLS;
using DevExpress.XtraEditors;
using cf01.ModuleClass;
using cf01.ReportForm;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{ 
    public partial class frmArtRequest : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mVer = "0";
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        public bool mData_status = false ; //數據的修改狀態
        public bool save_flag;
        public string temp_comp="DG";

        //frmArtEdit 成功生成版本時設置此值
        public static string _max_ver = ""; 

        //frmArtRequestFind 【確認】按鈕後賦值
        public static string _Requ_id = "";
        public static string _ver = "";
     
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        DataTable dtArt_request = new DataTable();
        DataTable dtGrop = new DataTable();
        DataTable dtSales = new DataTable();
        DataTable dtCustomer = new DataTable();
        DataTable dtSeason = new DataTable();
        DataTable dtBrand = new DataTable();
        DataTable dtMember = new DataTable();
        DataTable dtArt_request_details = new DataTable();
        DataTable dtColor = new DataTable();
        DataTable dtTempDel = new DataTable();
        public static DataTable dtArt_request_change;


        public frmArtRequest()
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
            //dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            //dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
        }

        private void frmArtRequest_Load(object sender, EventArgs e)
        {
            //跟單組別  
            dtGrop = clsPublicOfCF01.GetDataTable("SELECT grp_code AS id FROM dbo.bs_group");
            DataRow dr = dtGrop.NewRow(); //插一空行
            dr["id"] = "";
            dtGrop.Rows.InsertAt(dr, 0);
            txtGroup_id.Properties.DataSource = dtGrop;
            txtGroup_id.Properties.ValueMember = "id";
            txtGroup_id.Properties.DisplayMember = "id";
            //營業員代碼
            dtSales = clsPublicOfCF01.GetDataTable("SELECT sale_code,sale_cdesc,sale_short_name as abbrev FROM dbo.bs_sale WHERE sale_short_name<>'' and sale_state<>'2'");
            txtSale_id.Properties.DataSource = dtSales;
            txtSale_id.Properties.ValueMember = "sale_code";
            txtSale_id.Properties.DisplayMember = "sale_cdesc";
            //客戶編號
            dtCustomer = clsPublicOfCF01.GetDataTable("SELECT custcode,custlcname,custlname FROM dbo.bs_customer");
            txtCustcode.Properties.DataSource = dtCustomer;
            txtCustcode.Properties.ValueMember = "custcode";
            txtCustcode.Properties.DisplayMember = "custcode";
            //季度編號
            dtSeason = clsPublicOfCF01.GetDataTable("SELECT id,cdesc FROM dbo.bs_season");
            DataRow dr1 = dtSeason.NewRow(); //插一空行
            dr1["id"] = "";
            dtSeason.Rows.InsertAt(dr1, 0);
            txtSeason_id.Properties.DataSource = dtSeason;
            txtSeason_id.Properties.ValueMember = "id";
            txtSeason_id.Properties.DisplayMember = "cdesc";
            //牌子編號
            dtBrand = clsPublicOfCF01.GetDataTable("SELECT id,cdesc FROM dbo.bs_brand");
            DataRow dr2 = dtBrand.NewRow(); //插一空行
            dr2["id"] = "";
            dtBrand.Rows.InsertAt(dr2, 0);
            txtBrandcode.Properties.DataSource = dtBrand;
            txtBrandcode.Properties.ValueMember = "id";
            txtBrandcode.Properties.DisplayMember = "id";
            //完成交給
            dtMember = clsPublicOfCF01.GetDataTable("SELECT sale_code,sale_cdesc FROM dbo.bs_sale WHERE sale_state<>'2'");
            txtDeliver_member.Properties.DataSource = dtMember;
            txtDeliver_member.Properties.ValueMember = "sale_code";
            txtDeliver_member.Properties.DisplayMember = "sale_cdesc";
            //生成gridview1表結構
            dtArt_request_details = clsPublicOfCF01.GetDataTable("Select * from dbo.se_art_request_details where 1=0");
            gridControl1.DataSource = dtArt_request_details;
            //臨時項目刪除表結構
            dtTempDel = dtArt_request_details.Clone();
            //圖樣更改表結構
            dtArt_request_change = clsPublicOfCF01.GetDataTable("Select * From dbo.se_art_request_change Where 1=0");
            gridControl2.DataSource = dtArt_request_change;
            //gridview1顏色的下拉列表框
            //dtColor = DBUtility.GetDataTable("Select clr_code,clr_cdesc,clr_desc,clr_make FROM dbo.bs_color");
            //repositoryItemLookUpEdit1.DataSource = dtColor;
            //repositoryItemLookUpEdit1.ValueMember = "clr_code";
            //repositoryItemLookUpEdit1.DisplayMember = "clr_code";
            //repositoryItemLookUpEdit1.ShowHeader = false;
            //repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        private void frmArtRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtArt_request.Dispose();
            dtGrop.Dispose();
            dtSales.Dispose();
            dtCustomer.Dispose();
            dtSeason.Dispose();
            dtBrand.Dispose();
            dtMember.Dispose();
            dtColor.Dispose();
            dtArt_request_details.Dispose();
            dtTempDel.Dispose();
            dtArt_request_change.Dispose();
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

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNITEMADD_Click(object sender, EventArgs e)
        {
            AddNew_Item();
        }

        private void BTNITEMDEL_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount==0)
            {
                return;
            }            
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);            
            if (result == DialogResult.Yes)
            {
                int curRow = gridView1.FocusedRowHandle;
                string strSeq = gridView1.GetRowCellDisplayText(curRow, "seq_id");
                //將當前行刪除幷加到臨時表中
                DataRow newRow = dtTempDel.NewRow();
                newRow["company_code"] = temp_comp;
                newRow["art_requ_id"] = txtID.Text;
                newRow["ver"] = txtVer.Text;
                newRow["seq_id"] = strSeq;
                dtTempDel.Rows.Add(newRow);
                gridView1.DeleteRow(curRow);//移走當前行                
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNAPPROVE_Click(object sender, EventArgs e)
        {
            if (txtState.Text == "未批準")
            {
                Approve("0");                
            }
            else
            {
                Approve("1");
            }
        }

        private void BTNCHANGE_Click(object sender, EventArgs e)
        {
            Open_New_Version();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            //傳一個DataTable類型的參數到報表中
            xrlArtRequest mMyRepot = new xrlArtRequest(dtArt_request) { DataSource = dtArt_request };
            mMyRepot.ShowPreview();
        }

        private void txtRequ_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtHk_deliver_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtExpect_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtDg_rece_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtDeliver_draw_room_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtDraw_rece_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtCust_approve_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtHk_requ_finish_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtHk_requ_return_hk_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtDeliver_hk_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtDraw_finish_dat_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

        private void txtReply_create_mold_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }


        //===============以下爲自定義方法======================
        private static void CheckDate(object obj)
        {
            string strdate= ((DateEdit)obj).Text;
            if (String.IsNullOrEmpty(strdate))
            {
                return;
            }

            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Data Fromat is Error.";
                else
                    strMsg = "輸入的日期有誤！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.ClearObjValue(this.Controls, "1");
            txtSale_id.Enabled = true;
            txtVer.Text = "0";
            DataRow dr = dtArt_request.NewRow(); //插一空行
            dtArt_request.Rows.InsertAt(dr, 0);

            dtArt_request_details.Clear();
            gridControl1.DataSource = dtArt_request_details;            
        }

        private void Edit()  //編輯
        {
            if (txtSale_id.EditValue.ToString() == "")
            {
                return;
            }
            if (txtState.Text == "已批準")
            {
                MessageBox.Show("已批準狀態,不可以編輯!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";            

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
            txtSale_id.Enabled = false;
            txtSale_id.BackColor = System.Drawing.Color.White;
        }

        private void Save()  //保存
        {
             if (!Save_Before_Valid())
             {
                return;
             }
             if (Check_Details_Valid())//檢查明細資料的有效性
             {
                 return;
             }            
             save_flag = false;             
             
             #region  保存新增
             if (mState == "NEW")
             {
                 if (Valid_Doc())
                 {
                     return;
                 }
                 const string sql_i =
                     @"INSERT INTO se_art_request(company_code,art_requ_id,ver,art_cdesc,requ_dat,cust_prd_name,brandcode,group_id,season_id,sale_id,
                        contact_tel,contact,requ_3d_drawing,custcode,need_reply,expect_dat,deliver_member,requ_rmk1,requ_rmk2,
                        ref_drawing,hk_deliver_dat,prd_mo,dg_rece_dat,deliver_draw_room,draw_rece_dat,draw_finish_dat,deliver_hk_dat,
                        reply_create_mold,hk_requ_finish_dat,hk_requ_return_hk,cust_approve_dat,art_code,prepare_member,prepare_dat,
                        crusr,crtim,state) values
                       (@company_code,@art_requ_id,@ver,@art_cdesc,@requ_dat,@cust_prd_name,@brandcode,@group_id,@season_id,@sale_id,
                        @contact_tel,@contact,@requ_3d_drawing,@custcode,@need_reply,@expect_dat,@deliver_member,@requ_rmk1,@requ_rmk2,
                        @ref_drawing,@hk_deliver_dat,@prd_mo,@dg_rece_dat,@deliver_draw_room,@draw_rece_dat,@draw_finish_dat,@deliver_hk_dat,
                        @reply_create_mold,@hk_requ_finish_dat,@hk_requ_return_hk,@cust_approve_dat,@art_code,@prepare_member,@prepare_dat,
                        @crusr,getdate(),@state)";                 
                GetMouldNo(txtAbbrev.Text);
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();               
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                        myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@ver", "0");
                        myCommand.Parameters.AddWithValue("@art_cdesc", txtArt_cdesc.Text.Trim());
                        myCommand.Parameters.AddWithValue("@requ_dat", txtRequ_dat.Text);
                        myCommand.Parameters.AddWithValue("@cust_prd_name", txtCust_prd_name.Text.Trim());
                        myCommand.Parameters.AddWithValue("@brandcode", txtBrandcode.EditValue);
                        myCommand.Parameters.AddWithValue("@group_id", txtGroup_id.EditValue);
                        myCommand.Parameters.AddWithValue("@season_id", txtSeason_id.EditValue);
                        myCommand.Parameters.AddWithValue("@sale_id", txtSale_id.EditValue);

                        myCommand.Parameters.AddWithValue("@contact_tel", txtContact_tel.Text.Trim());
                        myCommand.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                        myCommand.Parameters.AddWithValue("@requ_3d_drawing", chkRequ_3d_drawing.Checked);
                        myCommand.Parameters.AddWithValue("@custcode", txtCustcode.EditValue);
                        myCommand.Parameters.AddWithValue("@need_reply", chkNeed_reply.Checked);
                        myCommand.Parameters.AddWithValue("@expect_dat", txtExpect_dat.Text);
                        myCommand.Parameters.AddWithValue("@deliver_member", txtDeliver_member.EditValue);
                        myCommand.Parameters.AddWithValue("@requ_rmk1", txtRequ_rmk1.Text);
                        myCommand.Parameters.AddWithValue("@requ_rmk2", txtRequ_rmk2.Text);

                        myCommand.Parameters.AddWithValue("@ref_drawing", txtRef_drawing.Text.Trim());
                        myCommand.Parameters.AddWithValue("@hk_deliver_dat", txtHk_deliver_dat.Text);
                        myCommand.Parameters.AddWithValue("@prd_mo", txtPrd_mo.Text.Trim());
                        myCommand.Parameters.AddWithValue("@dg_rece_dat", txtDg_rece_dat.Text);
                        myCommand.Parameters.AddWithValue("@deliver_draw_room", txtDeliver_draw_room.Text);
                        myCommand.Parameters.AddWithValue("@draw_rece_dat", txtDraw_rece_dat.Text);
                        myCommand.Parameters.AddWithValue("@draw_finish_dat", txtDraw_finish_dat.Text);
                        myCommand.Parameters.AddWithValue("@deliver_hk_dat", txtDeliver_hk_dat.Text);

                        myCommand.Parameters.AddWithValue("@reply_create_mold", txtReply_create_mold.Text);
                        myCommand.Parameters.AddWithValue("@hk_requ_finish_dat", txtHk_requ_finish_dat.Text);
                        myCommand.Parameters.AddWithValue("@hk_requ_return_hk", txtHk_requ_return_hk.Text);
                        myCommand.Parameters.AddWithValue("@cust_approve_dat", txtCust_approve_dat.Text);
                        myCommand.Parameters.AddWithValue("@art_code", txtArt_code.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prepare_member", txtPrepare_member.Text.Trim());
                        myCommand.Parameters.AddWithValue("@prepare_dat", txtPrepare_dat.Text);
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        myCommand.Parameters.AddWithValue("@state", "0");
                        myCommand.ExecuteNonQuery();

                        //保存明細
                        if (gridView1.RowCount > 0)
                        {
                            const string sql_item_i =
                                @"INSERT INTO se_art_request_details(company_code,art_requ_id,ver,seq_id,cust_clr_id,cust_clr_name,clr_code,clr_cdesc,clr_desc,clr_make,remark)
                                VALUES(@company_code,@art_requ_id,@ver,@seq_id,@cust_clr_id,@cust_clr_name,@clr_code,@clr_cdesc,@clr_desc,@clr_make,@remark)";
                            string strSeq_id = "";
                            for (int i = 0; i < dtArt_request_details.Rows.Count; i++)
                            {
                                //curRow = gridView1.GetRowHandle(i);
                                myCommand.CommandText = sql_item_i;
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                                myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());
                                myCommand.Parameters.AddWithValue("@ver", "0");
                                //myCommand.Parameters.AddWithValue("@seq_id", gridView1.GetRowCellDisplayText(curRow, "seq_id")); 
                                strSeq_id = Get_Details_Seq(temp_comp,txtID.Text.Trim(),"0","1"); //新增狀態重新取最大序號;
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@cust_clr_id", dtArt_request_details.Rows[i]["cust_clr_id"].ToString());
                                myCommand.Parameters.AddWithValue("@cust_clr_name", dtArt_request_details.Rows[i]["cust_clr_name"].ToString());
                                myCommand.Parameters.AddWithValue("@clr_code", dtArt_request_details.Rows[i]["clr_code"].ToString());
                                myCommand.Parameters.AddWithValue("@clr_cdesc", dtArt_request_details.Rows[i]["clr_cdesc"].ToString());
                                myCommand.Parameters.AddWithValue("@clr_desc", dtArt_request_details.Rows[i]["clr_desc"].ToString());
                                myCommand.Parameters.AddWithValue("@clr_make", dtArt_request_details.Rows[i]["clr_make"].ToString());
                                myCommand.Parameters.AddWithValue("@remark", dtArt_request_details.Rows[i]["remark"].ToString());
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
             #endregion

             #region 保存編輯
             if (mState == "EDIT")
             {
                 string rowStatus = "";
                 string strSeq_id="";
                 const string sql_update = @"UPDATE se_art_request
                     SET ver=@ver,art_cdesc=@art_cdesc,requ_dat=@requ_dat,cust_prd_name=@cust_prd_name,brandcode=@brandcode,group_id=@group_id,season_id=@season_id,
                     contact_tel=@contact_tel,contact=@contact,requ_3d_drawing=@requ_3d_drawing,custcode=@custcode,need_reply=@need_reply,expect_dat=@expect_dat,
                     deliver_member=@deliver_member,requ_rmk1=@requ_rmk1,requ_rmk2=@requ_rmk2,ref_drawing=@ref_drawing,hk_deliver_dat=@hk_deliver_dat,prd_mo=@prd_mo,
                     dg_rece_dat=@dg_rece_dat,deliver_draw_room=@deliver_draw_room,draw_rece_dat=@draw_rece_dat,draw_finish_dat=@draw_finish_dat,deliver_hk_dat=@deliver_hk_dat,
                     reply_create_mold=@reply_create_mold,hk_requ_finish_dat=@hk_requ_finish_dat,hk_requ_return_hk=@hk_requ_return_hk,cust_approve_dat=@cust_approve_dat,                    
                     art_code=@art_code,prepare_member=@prepare_member,prepare_dat=@prepare_dat,amusr=@amusr,amtim=getdate() 
                     WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver";
                 
                 SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                 myCon.Open();
                 SqlTransaction myTrans = myCon.BeginTransaction();
                 using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                 {
                     try
                     {
                         myCommand.CommandText = sql_update;
                         myCommand.Parameters.Clear();
                         myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                         myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());  
                         myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                         myCommand.Parameters.AddWithValue("@art_cdesc", txtArt_cdesc.Text.Trim());
                         myCommand.Parameters.AddWithValue("@requ_dat", txtRequ_dat.Text);
                         myCommand.Parameters.AddWithValue("@cust_prd_name", txtCust_prd_name.Text.Trim());
                         myCommand.Parameters.AddWithValue("@brandcode", txtBrandcode.EditValue);
                         myCommand.Parameters.AddWithValue("@group_id", txtGroup_id.EditValue);
                         myCommand.Parameters.AddWithValue("@season_id", txtSeason_id.EditValue);
                         myCommand.Parameters.AddWithValue("@sale_id", txtSale_id.EditValue);
                        
                         myCommand.Parameters.AddWithValue("@contact_tel", txtContact_tel.Text.Trim());
                         myCommand.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                         myCommand.Parameters.AddWithValue("@requ_3d_drawing", chkRequ_3d_drawing.Checked);
                         myCommand.Parameters.AddWithValue("@custcode", txtCustcode.EditValue);
                         myCommand.Parameters.AddWithValue("@need_reply", chkNeed_reply.Checked);
                         myCommand.Parameters.AddWithValue("@expect_dat", txtExpect_dat.Text);
                         myCommand.Parameters.AddWithValue("@deliver_member", txtDeliver_member.EditValue);
                         myCommand.Parameters.AddWithValue("@requ_rmk1", txtRequ_rmk1.Text);
                         myCommand.Parameters.AddWithValue("@requ_rmk2", txtRequ_rmk2.Text);

                         myCommand.Parameters.AddWithValue("@ref_drawing", txtRef_drawing.Text.Trim());
                         myCommand.Parameters.AddWithValue("@hk_deliver_dat", txtHk_deliver_dat.Text);
                         myCommand.Parameters.AddWithValue("@prd_mo", txtPrd_mo.Text.Trim());
                         myCommand.Parameters.AddWithValue("@dg_rece_dat", txtDg_rece_dat.Text);
                         myCommand.Parameters.AddWithValue("@deliver_draw_room", txtDeliver_draw_room.Text);
                         myCommand.Parameters.AddWithValue("@draw_rece_dat", txtDraw_rece_dat.Text);
                         myCommand.Parameters.AddWithValue("@draw_finish_dat", txtDraw_finish_dat.Text);
                         myCommand.Parameters.AddWithValue("@deliver_hk_dat", txtDeliver_hk_dat.Text);

                         myCommand.Parameters.AddWithValue("@reply_create_mold", txtReply_create_mold.Text);
                         myCommand.Parameters.AddWithValue("@hk_requ_finish_dat", txtHk_requ_finish_dat.Text);
                         myCommand.Parameters.AddWithValue("@hk_requ_return_hk", txtHk_requ_return_hk.Text);
                         myCommand.Parameters.AddWithValue("@cust_approve_dat", txtCust_approve_dat.Text);
                         myCommand.Parameters.AddWithValue("@art_code", txtArt_code.Text.Trim());
                         myCommand.Parameters.AddWithValue("@prepare_member", txtPrepare_member.Text.Trim());
                         myCommand.Parameters.AddWithValue("@prepare_dat", txtPrepare_dat.Text);
                         myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);
                         myCommand.ExecuteNonQuery();

                         //刪除明細資料
                         for (int i = 0; i < dtTempDel.Rows.Count; i++)
                         {
                             const string sql_item_d = @"DELETE FROM dbo.se_art_request_details WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver AND seq_id=@seq_id";
                             myCommand.CommandText = sql_item_d;
                             myCommand.Parameters.Clear();
                             myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                             myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());
                             myCommand.Parameters.AddWithValue("@ver", txtVer.Text.Trim());
                             myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());
                             myCommand.ExecuteNonQuery();
                         }

                         //保存明細資料
                         if (gridView1.RowCount > 0)
                         {
                             const string sql_item_i =
                                 @"INSERT INTO se_art_request_details(company_code,art_requ_id,ver,seq_id,cust_clr_id,cust_clr_name,clr_code,clr_cdesc,clr_desc,clr_make,remark)
                                VALUES(@company_code,@art_requ_id,@ver,@seq_id,@cust_clr_id,@cust_clr_name,@clr_code,@clr_cdesc,@clr_desc,@clr_make,@remark)";
                             const string sql_item_u =
                                 @"UPDATE se_art_request_details SET cust_clr_id=@cust_clr_id,cust_clr_name=@cust_clr_name,clr_code=@clr_code,clr_cdesc=@clr_cdesc,clr_desc=@clr_desc,
                                 clr_make=@clr_make,remark=@remark WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver AND seq_id=@seq_id";                             
                             for (int i = 0; i < dtArt_request_details.Rows.Count; i++)
                             {
                                 rowStatus = dtArt_request_details.Rows[i].RowState.ToString();                                 
                                 if (rowStatus == "Added" || rowStatus == "Modified")
                                 {
                                     if (rowStatus == "Added")
                                     {
                                         myCommand.CommandText = sql_item_i;
                                         strSeq_id = Get_Details_Seq(temp_comp,txtID.Text.Trim(), txtVer.Text,"1"); //新增狀態重新取最大序號
                                     }
                                     if (rowStatus == "Modified")
                                     {
                                         myCommand.CommandText = sql_item_u;
                                         strSeq_id = dtArt_request_details.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                     }                                    
                                     myCommand.Parameters.Clear();                                     
                                     myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                                     myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());
                                     myCommand.Parameters.AddWithValue("@ver", txtVer.Text.Trim());
                                     myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                     myCommand.Parameters.AddWithValue("@cust_clr_id", dtArt_request_details.Rows[i]["cust_clr_id"].ToString());
                                     myCommand.Parameters.AddWithValue("@cust_clr_name", dtArt_request_details.Rows[i]["cust_clr_name"].ToString());
                                     myCommand.Parameters.AddWithValue("@clr_code", dtArt_request_details.Rows[i]["clr_code"].ToString());
                                     myCommand.Parameters.AddWithValue("@clr_cdesc", dtArt_request_details.Rows[i]["clr_cdesc"].ToString());
                                     myCommand.Parameters.AddWithValue("@clr_desc", dtArt_request_details.Rows[i]["clr_desc"].ToString());
                                     myCommand.Parameters.AddWithValue("@clr_make", dtArt_request_details.Rows[i]["clr_make"].ToString());
                                     myCommand.Parameters.AddWithValue("@remark", dtArt_request_details.Rows[i]["remark"].ToString());
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
            Set_Grid_Status(false);
            mState = "";
            txtSale_id.Enabled = false ;
            dtTempDel.Clear();
            if (save_flag)
            {
                Find_doc(txtID.Text,txtVer.Text);               
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        } 

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            SetObjValue.ClearObjValue(this.Controls, "2");
            Set_Grid_Status(false);

            dtTempDel.Clear();
            dtArt_request_details.Clear();
            gridControl1.DataSource = dtArt_request_details;

            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID,mVer);
            }
        }        

        private void SetButtonSatus(bool _flag) //設置工具欄
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;            
            BTNCHANGE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNAPPROVE.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            BTNITEMADD.Enabled = !_flag;
            BTNITEMDEL.Enabled = !_flag;

            btnFindCustomer.Enabled = !_flag;
            btnFindBrand.Enabled = !_flag;
            btnOpenFile.Enabled = !_flag;
            btnSelectVer.Enabled = _flag;
        }

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;
            string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM dbo.se_art_request WHERE custcode='{0}'", doc);
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

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (txtID.Text == "" || txtRequ_dat.Text == "" || txtSale_id.Text == "" || txtCustcode.Text == "")
            {
                if (str_language == "2")
                {
                    msgCustom = "Data cannot be empty.";
                }
                else
                {
                    msgCustom = "畫稿編號、日期、營業員資料或客戶編號資料不可爲空！";
                }
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GetMouldNo(string _Abbrev) //取最大畫稿編號
        {
            DataTable dtYM = new DataTable();
            dtYM = clsPublicOfCF01.GetDataTable("SELECT substring(CONVERT(varchar(10),GETDATE(),112),3,4) as ym");
            string strMD = String.Format("{0}-{1}-", _Abbrev, dtYM.Rows[0]["ym"]);
            string strSeq;
            string strMaxSeq;
            DataTable dtMD = new DataTable();
            dtMD = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(art_requ_id) as id FROM dbo.se_art_request WHERE company_code='{0}' AND art_requ_id LIKE '{1}%'", temp_comp, strMD));
            if (String.IsNullOrEmpty(dtMD.Rows[0]["id"].ToString()))
            {
                strSeq = "001";
            }
            else
            {
                strMaxSeq = dtMD.Rows[0]["id"].ToString();
                strSeq = strMaxSeq.Substring(strMaxSeq.Length - 3);
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000");
            }
            strMaxSeq = strMD + strSeq;
            txtID.Text = strMaxSeq;
        }

        public static string Get_Details_Seq(string _comp,string _id, string _ver,string _type) //取明細的序號
        {            
            DataTable dtMaxseq = new DataTable();
            if (_type == "1")
            {
                dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.se_art_request_details with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver='{2}'", _comp, _id, _ver));
            }
            else
            {
                dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.se_art_request_change with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver='{2}'", _comp, _id, _ver));
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

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                //已批準的最大版本號
                string sql_f1 = String.Format(
                            @"SELECT A.*,B.custlname,B.custlcname,C.cdesc as brand_cdesc,ISNULL(D.art_image,'') as art_image,E.sale_cdesc,F.cdesc AS season_cdesc
                            FROM dbo.se_art_request A with(nolock) 
                            INNER JOIN dbo.bs_customer B with(nolock) ON A.custcode=B.custcode
                            LEFT JOIN dbo.bs_brand C with(nolock) ON A.brandcode=C.id 
                            LEFT JOIN dbo.bs_artwork D with(nolock) ON A.art_code=D.art_code
                            LEFT JOIN dbo.bs_sale E with(nolock) ON A.deliver_member =E.sale_code
                            LEFT JOIN dbo.bs_season F with(nolock) ON A.season_id=F.id 
                            WHERE A.company_code='{0}' AND A.art_requ_id='{1}' AND A.ver =
                                (select MAX(ver) from se_art_request where company_code=A.company_code and art_requ_id=A.art_requ_id and state='1')"
                            , temp_comp, temp_id);
                //已批準的最大版本號找不到,再找未批準最大版本號
                string sql_f2 = String.Format(
                        @"SELECT A.*,B.custlname,B.custlcname,C.cdesc as brand_cdesc,ISNULL(D.art_image,'') as art_image,E.sale_cdesc,F.cdesc AS season_cdesc
                            FROM dbo.se_art_request A with(nolock) 
                            INNER JOIN dbo.bs_customer B with(nolock) ON A.custcode=B.custcode
                            LEFT JOIN dbo.bs_brand C with(nolock) ON A.brandcode=C.id 
                            LEFT JOIN dbo.bs_artwork D with(nolock) ON A.art_code=D.art_code
                            LEFT JOIN dbo.bs_sale E with(nolock) ON A.deliver_member =E.sale_code
                            LEFT JOIN dbo.bs_season F with(nolock) ON A.season_id=F.id 
                        WHERE A.company_code='{0}' AND A.art_requ_id='{1}' AND A.ver =
                        (select MAX(ver) from se_art_request where company_code=A.company_code and art_requ_id=A.art_requ_id)"
                        , temp_comp, temp_id);
                dtArt_request = clsPublicOfCF01.GetDataTable(sql_f1);
                if (dtArt_request.Rows.Count == 0)
                {
                    dtArt_request = clsPublicOfCF01.GetDataTable(sql_f2);
                }
                
                if (dtArt_request.Rows.Count == 0)
                {
                    if (str_language == "2")
                    {
                        msgCustom = "The Art Code of the data does not exist.";
                    }
                    else
                    {
                        msgCustom = "畫稿編號資料不存在！";
                    }
                    MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                    mVer = dtArt_request.Rows[0]["ver"].ToString(); //保存臨時的版本號
                }
                Set_Master_Data(dtArt_request);
                string details_f1 = String.Format(
                    @"SELECT * FROM dbo.se_art_request_details with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver='{2}'"
                    , temp_comp, temp_id, mVer);
                dtArt_request_details.Clear();
                dtArt_request_details = clsPublicOfCF01.GetDataTable(details_f1);
                gridControl1.DataSource = dtArt_request_details;
                string details_f2 = String.Format(
                    @"SELECT * FROM dbo.se_art_request_change with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver='{2}'"
                    , temp_comp, temp_id, mVer);
                dtArt_request_change.Clear();
                dtArt_request_change = clsPublicOfCF01.GetDataTable(details_f2);
                gridControl2.DataSource = dtArt_request_change;
            }
        }

        private void Find_doc(string temp_id, string temp_ver) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {      
                string sql_f1 = String.Format(
                        @"SELECT A.*,B.custlname,B.custlcname,C.cdesc as brand_cdesc,ISNULL(D.art_image,'') as art_image,E.sale_cdesc,F.cdesc AS season_cdesc
                            FROM dbo.se_art_request A with(nolock) 
                            INNER JOIN dbo.bs_customer B with(nolock) ON A.custcode=B.custcode
                            LEFT JOIN dbo.bs_brand C with(nolock) ON A.brandcode=C.id 
                            LEFT JOIN dbo.bs_artwork D with(nolock) ON A.art_code=D.art_code
                            LEFT JOIN dbo.bs_sale E with(nolock) ON A.deliver_member =E.sale_code
                            LEFT JOIN dbo.bs_season F with(nolock) ON A.season_id=F.id  
                        WHERE A.company_code='{0}' AND A.custcode=B.custcode AND A.art_requ_id='{1}' AND A.ver ='{2}'"
                        , temp_comp, temp_id, temp_ver);
                string details_f1 = String.Format(
                        @"SELECT * FROM dbo.se_art_request_details with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver='{2}'"
                        , temp_comp, temp_id, temp_ver);
                string details_f2 = String.Format(
                        @"SELECT * FROM dbo.se_art_request_change with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver='{2}'"
                        , temp_comp, temp_id, temp_ver);
                dtArt_request = clsPublicOfCF01.GetDataTable(sql_f1);             
                Set_Master_Data(dtArt_request);                
                dtArt_request_details.Clear();
                dtArt_request_details = clsPublicOfCF01.GetDataTable(details_f1);
                gridControl1.DataSource = dtArt_request_details;
                dtArt_request_change.Clear();
                dtArt_request_change = clsPublicOfCF01.GetDataTable(details_f2);
                gridControl2.DataSource = dtArt_request_change;

                mID = txtID.Text;//保存臨時的ID號
                mVer = temp_ver;                
            }
        }

        private void Set_Master_Data(DataTable dt) //綁定主檔資料
        {            
            txtID.Text = dt.Rows[0]["art_requ_id"].ToString();
            txtVer.Text = dt.Rows[0]["ver"].ToString();
            txtArt_cdesc.Text = dt.Rows[0]["art_cdesc"].ToString();            
            string strDate = dt.Rows[0]["requ_dat"].ToString();
            strDate = strDate.Substring(0, 10);
            txtRequ_dat.Text = strDate;
            txtSale_id.EditValue = dt.Rows[0]["sale_id"].ToString();            
            txtGroup_id.EditValue = dt.Rows[0]["group_id"].ToString(); 
            txtState.Text = dt.Rows[0]["state"].ToString();
            txtCustcode.EditValue = dt.Rows[0]["custcode"].ToString();
            txtCust_prd_name.Text =dt.Rows[0]["cust_prd_name"].ToString();
            txtContact_tel.Text = dt.Rows[0]["contact_tel"].ToString();
            txtContact.Text = dt.Rows[0]["contact"].ToString();
            txtBrandcode.EditValue = dt.Rows[0]["brandcode"].ToString();
            txtSeason_id.EditValue = dt.Rows[0]["season_id"].ToString();
            txtDeliver_member.EditValue = dt.Rows[0]["deliver_member"].ToString();
            txtPrd_mo.Text = dt.Rows[0]["prd_mo"].ToString();            
            if (dt.Rows[0]["requ_3d_drawing"].ToString() == "True")
            {
                chkRequ_3d_drawing.Checked = true;
            }
            else 
            {
                chkRequ_3d_drawing.Checked = false ;
            }
            if (dt.Rows[0]["need_reply"].ToString() == "True")
            {
                chkNeed_reply.Checked = true;
            }
            else 
            {
                chkNeed_reply.Checked = false;
            }
            txtExpect_dat.EditValue = dt.Rows[0]["expect_dat"].ToString();
            txtArt_code.Text = dt.Rows[0]["art_code"].ToString();
            txtHk_deliver_dat.EditValue = dt.Rows[0]["hk_deliver_dat"].ToString();
            txtDg_rece_dat.EditValue = dt.Rows[0]["dg_rece_dat"].ToString();
            txtDeliver_draw_room.EditValue = dt.Rows[0]["deliver_draw_room"].ToString();
            txtDraw_rece_dat.EditValue = dt.Rows[0]["draw_rece_dat"].ToString();
            txtDraw_finish_dat.EditValue = dt.Rows[0]["draw_finish_dat"].ToString();              
            txtCust_approve_dat.EditValue = dt.Rows[0]["cust_approve_dat"].ToString();
            txtHk_requ_finish_dat.EditValue = dt.Rows[0]["hk_requ_finish_dat"].ToString();
            txtHk_requ_return_hk.EditValue = dt.Rows[0]["hk_requ_return_hk"].ToString();
            txtDeliver_hk_dat.EditValue = dt.Rows[0]["deliver_hk_dat"].ToString();
            txtReply_create_mold.EditValue = dt.Rows[0]["reply_create_mold"].ToString();
            txtRequ_rmk1.Text = dt.Rows[0]["requ_rmk1"].ToString();
            txtRequ_rmk2.Text = dt.Rows[0]["requ_rmk2"].ToString();
            txtRef_drawing.Text = dt.Rows[0]["ref_drawing"].ToString();
            txtPrepare_member.Text = dt.Rows[0]["Prepare_member"].ToString();
            txtPrepare_dat.EditValue = dt.Rows[0]["prepare_dat"].ToString();
            txtCheck_by.Text = dt.Rows[0]["check_by"].ToString();
            txtCheck_dat.EditValue = dt.Rows[0]["check_dat"].ToString();
            txtCrusr.Text = dt.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[0]["Amusr"].ToString();
            txtAmtim.Text = dt.Rows[0]["Amtim"].ToString();
            if (dt.Rows[0]["state"].ToString() == "1")
            {
                txtState.Text = "已批準";
                BTNAPPROVE.Text = "反批準(&C)";
            }
            else
            {
                txtState.Text = "未批準";
                BTNAPPROVE.Text = "批準(&C)";
            }
            //取圖樣
            string art_file = dt.Rows[0]["art_image"].ToString().Trim();
            if (File.Exists(art_file))
            {
                picArt_code.Image = Image.FromFile(art_file);
            }
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtSale_id.Text))
            {
                return;
            }

            if (txtState.Text == "已批準")
            {
                MessageBox.Show("已批準狀態,不可以刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //====================================================================
            //等做模通知書完成后增加檢查做模通知書這邊如已有資料，則不可以刪除畫稿
            //====================================================================
            
            //DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = MessageBox.Show("此操作刪除當前版本畫稿編號的全部資料,請謹慎操作!", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = @"DELETE FROM dbo.se_art_request WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver ";
                const string sql_del_details = @"DELETE FROM dbo.se_art_request_details WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver ";
                const string sql_del_change = @"DELETE FROM dbo.se_art_request_change WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver ";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {                       
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();                      
                        myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                        myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = sql_del_details; //刪除明細                       
                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = sql_del_change; //刪除明細                       
                        myCommand.ExecuteNonQuery();

                        
                        myTrans.Commit(); //數據提交                        
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(this.Controls, "1");
                        dtArt_request_details.Clear();
                        dtArt_request_change.Clear();
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

        private void AddNew_Item()
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim()) && !String.IsNullOrEmpty(txtSale_id.Text)) // 有內容
            {
                if (Check_Details_Valid())
                {
                    return;
                }
                Set_Grid_Status(true);                
                gridView1.AddNewRow();//新增
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq_id", (gridView1.RowCount + 1).ToString("000"));
                
                ColumnView view = (ColumnView)gridView1;//初始單元格焦點
                view.FocusedColumn = view.Columns["cust_clr_id"];
                view.Focus();
            }
        }

        private bool Check_Details_Valid() //檢查明細資料的有效性
        {            
            //客戶顏色名稱與CF顏色名稱要輸入
            bool _flag = false;            
            if (gridView1.RowCount > 0)
            {
                txtArt_cdesc.Focus();
                //因toolStrip控件焦點問題
                //設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，附止取到的值爲空
                // ColumnView view = (ColumnView)gridView1 ;
                // view.FocusedColumn = view.Columns["cust_clr_id"];                
                int curRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    curRow = gridView1.GetRowHandle(i);
                    if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "cust_clr_name")) &&
                        String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "clr_cdesc")))
                    {
                        _flag = true;
                        MessageBox.Show("客戶顏色名稱和CF顏色名稱不可以同時爲空.", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)gridView1;
                        view1.FocusedColumn = view1.Columns["cust_clr_name"]; //設置單元格焦點                        
                        break;
                    }                              
                }
            }
            return _flag;
        }
        
        private void Set_Grid_Status(bool _flag) // 表格可編號否
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag; 
            //gridView2.OptionsBehavior.Editable = _flag;                       
        }

        private void Approve(string _flag) // 批準或反批準
        {            
            save_flag = false;
            string sql_u;
            if (_flag=="0") //批準
            {
                //同一畫稿編號有多個版本時，只允許其中的一個版本可以批準
                string sql_f = String.Format("SELECT ver FROM se_art_request WITH(NOLOCK) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver<>'{2}' AND state='1'", temp_comp, txtID.Text, txtVer.Text);
                sql_u = @"Update se_art_request set state='1',check_by=@check_by,check_dat=getdate() WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver";
                DataTable dtApprove = clsPublicOfCF01.GetDataTable(sql_f);
                if (dtApprove.Rows.Count > 0)
                {
                    string msg = String.Format("版本【{0}】已經批準,{1}同一畫稿編號不可以同時批準兩個以上的版本！", dtApprove.Rows[0]["ver"], "\n" + "\n");
                    MessageBox.Show(msg, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return ;
                }                
            }
            else //反批準
            {
                sql_u = @"Update se_art_request set state='0',check_by=NULL,check_dat=NULL WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver";
            }
            
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.CommandText = sql_u;
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@company_code", temp_comp);
                    myCommand.Parameters.AddWithValue("@art_requ_id", txtID.Text.Trim());
                    myCommand.Parameters.AddWithValue("@ver", txtVer.Text);
                    myCommand.Parameters.AddWithValue("@check_by", DBUtility._user_id);
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit(); //數據提交
                    string strMsg;
                    if (_flag == "0")
                    {
                        strMsg = "批準成功！";
                        txtState.Text = "已批準";
                        BTNAPPROVE.Text = "反批準(&C)";
                    }
                    else
                    {
                        strMsg = "反批準成功！";
                        txtState.Text = "未批準";
                        BTNAPPROVE.Text = "批準(&C)";
                    }
                    Find_doc(mID, mVer);
                    MessageBox.Show(strMsg, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Open_New_Version() //打開圖樣更改產生新版本的窗口
        {
            if (mState == "")
            {
                frmArtEdit._comp = temp_comp;
                frmArtEdit._id = txtID.Text;
                frmArtEdit._ver = mVer;
                frmArtEdit frm = new frmArtEdit();
                frm.ShowDialog();
                frm.Dispose();
                if (_max_ver != "")
                {
                    string max_version = _max_ver;
                    _max_ver = "";
                    Find_doc(mID, max_version);                    
                    DataRow newRow = dtArt_request_change.NewRow();
                    newRow["company_code"] = temp_comp;
                    newRow["art_requ_id"] = mID;
                    newRow["ver"] = max_version;                    
                    newRow["seq_id"] = (gridView2.RowCount + 1).ToString("000");
                    newRow["provide_original"] = "有";
                    dtArt_request_change.Rows.Add(newRow);
                    Open_New_Version();
                }                
            }
            gridView2.Focus();
        }

        private void Open_form_find(string _pId)
        {
            if (mState == "")
            {
                //因打開frmArtRequestFind窗體有兩個地方
                //frmArtRequestFind中的析構函數負責接收; 
                frmArtRequestFind frm = new frmArtRequestFind(_pId);
                frm.ShowDialog();
                frm.Dispose();

                //變量：_Requ_id,_ver在打開的窗體frmArtRequestFind中確認後設置
                if (!String.IsNullOrEmpty(_Requ_id) && !String.IsNullOrEmpty(_ver))
                {
                    Find_doc(_Requ_id, _ver);
                }
            }
        }


        //表單控件中的事件
        private void txtID_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                if (mState == "") //流覽模式
                {
                    Find_doc(txtID.Text);
                }
            }
        }

        private void btnFindBrand_Click(object sender, EventArgs e) //從牌子編號旁的按鈕查出牌子資料
        {
            frmFindDataBase frmBrand = new frmFindDataBase(btnFindBrand.Name);
            frmBrand.Owner = this;
            frmBrand.ShowDialog();

            txtBrandcode.EditValue = DBUtility.get_query_id;
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)  //從客戶編號旁的按鈕查出客戶編號資料
        {
            frmFindDataBase frmCust = new frmFindDataBase(btnFindCustomer.Name);
            frmCust.Owner = this;
            frmCust.ShowDialog();
            txtCustcode.EditValue = DBUtility.get_query_id;
        }

        private void btnOpenFile_Click(object sender, EventArgs e) //查找鍊接文件路徑
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files (*.PDF)|*.PDF";
            openFile.RestoreDirectory = true;
            openFile.Title = "鍊接的文件";
            openFile.ShowDialog();
            txtRef_drawing.Text = openFile.FileName;
        }

        private void txtRef_drawing_DoubleClick(object sender, EventArgs e)//雙擊打開PDF檔
        {
            string strFile = txtRef_drawing.Text;
            if (!string.IsNullOrEmpty(strFile) && File.Exists(@strFile))
            {
                System.Diagnostics.Process.Start(strFile);
            }
        }

        private void txtSale_id_EditValueChanged(object sender, EventArgs e)//依據營業員產生模俱編號資料
        {
            if (txtSale_id.EditValue.ToString() != "")
            {
                txtAbbrev.Text = txtSale_id.GetColumnValue("abbrev").ToString();
            }
        }

        private void txtSale_id_Leave(object sender, EventArgs e)
        {
            GetMouldNo(txtAbbrev.Text);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            Open_New_Version();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Open_form_find("");
        }

        private void btnSelectVer_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(mID))
            {
                Open_form_find(mID);
            }
        }

        private void gv1_clr_code_Leave(object sender, EventArgs e) //查找顏色資料
        {
            string strclr = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "clr_code");
            if (!String.IsNullOrEmpty(strclr))
            {
                string strSql = String.Format("Select clr_code,clr_cdesc,clr_desc,clr_make FROM dbo.bs_color WHERE clr_code='{0}'", strclr);
                DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "clr_cdesc", dt.Rows[0]["clr_cdesc"].ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "clr_desc", dt.Rows[0]["clr_desc"].ToString());
                }
                else
                {
                    MessageBox.Show("CF顏色編號資料不存在." + String.Format("【{0}】", strclr), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "clr_code", null);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "clr_cdesc", null);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "clr_desc", null);
                }
                dt.Dispose();
            }
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) //設置被編輯和當前行的背景色
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
            //if (e.RowHandle == gridView1.FocusedRowHandle)
            //{
            //    e.Appearance.ForeColor = Color.White;
            //    e.Appearance.BackColor = Color.RoyalBlue;// Color.PeachPuff;
            //}
        }

    }
}
