/*
 * Create by :   Allen Leung 
 * Create Date : 2018-11-06
 * remark:
 * HK E組 TOMMY 牌子客戶測試報告別記錄
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
    public partial class frmDevelopmentTommy : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public DataTable dtReSet = new DataTable();
        public DataTable dtMO = new DataTable();        
        public string mState = "";
        private string mPvh_no = "";
        private string mPvh_no_type_id_2 = "";
        private string mPvh_no_type_id_3 = "";
        private string mPvh_no_type_id_ck = "";
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();

       
        public frmDevelopmentTommy()
        {
            InitializeComponent();

            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();            
              
        }

        private void frmDevelopmentTommy_Load(object sender, EventArgs e)
        {
            //Load_Date();
            const string sql = @"SELECT *,0 as pvh_no From development_tommy with(nolock) where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);           
            dgvDetails.DataSource = dtDetail;

            clsQuotation.Set_Unit(lkep_unit1);
            clsQuotation.Set_Unit(lkep_unit2);
            clsQuotation.Set_Unit(lkep_unit3);
            clsQuotation.Set_Unit(lkep_unit4);
            clsQuotation.Set_Unit(lkep_unit5);
            DataTable dtMoney = clsPublicOfCF01.GetDataTable(@"SELECT '' as id,'' as cdesc Union SELECT id,name as cdesc FROM dgerp2.cferp.dbo.cd_money WHERE state='0'");
            lkem_id1.Properties.DataSource = dtMoney;
            lkem_id1.Properties.ValueMember = "id";
            lkem_id1.Properties.DisplayMember = "id";

            lkem_id2.Properties.DataSource = dtMoney;
            lkem_id2.Properties.ValueMember = "id";
            lkem_id2.Properties.DisplayMember = "id";

            lkem_id3.Properties.DataSource = dtMoney;
            lkem_id3.Properties.ValueMember = "id";
            lkem_id3.Properties.DisplayMember = "id";

            lkem_id4.Properties.DataSource = dtMoney;
            lkem_id4.Properties.ValueMember = "id";
            lkem_id4.Properties.DisplayMember = "id";

            lkem_id5.Properties.DataSource = dtMoney;
            lkem_id5.Properties.ValueMember = "id";
            lkem_id5.Properties.DisplayMember = "id";

            const string strSql = @"Select '' as id,'' as cdesc Union Select id,name as cdesc From dgerp2.cferp.dbo.cd_season where state='0' Order by id";
            DataTable dtSeason = new DataTable();
            dtSeason = clsPublicOfCF01.GetDataTable(strSql);
            txtseason.Properties.DataSource = dtSeason;
            txtseason.Properties.ValueMember = "id";
            txtseason.Properties.DisplayMember = "cdesc";
          
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
            dtdate.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            txtserial_no.Text = clsTommyTest.GetSeqNo("development_tommy","serial_no");
            txtsupplier_name.Text = "CHING FUNG / CHING FUNG METAL MANUFACTORY (LONGNAM)CO.,LTD";
            txtcountry.Text = "MADE IN CHINA";
            txtmoq_usa.Text = "NA";
            txtmoq_eur.Text = "NA";
            txtleadtime_sample.Text = "14 Days";
            txtsurcharge_usa.Text = "NA";
            txtsurcharge_eur.Text = "NA";
            txtleadtime_bulk.Text = "28 Days";
            txttrim_must_tommy.Text = "YES";
            txtoekotex.Text = "OEKO-TEX STANDARD 100 # HKS 18549 TESTEX";
            txttemp_pvh_no.Text = "";

            txtserial_no.Properties.ReadOnly = true;
            txtserial_no.BackColor = Color.White;

            dgvDetails.Enabled = false;
            txtseason.Focus();    
        }

        private void Save()
        {
            txtserial_no.Focus();
            if (txtserial_no.Text == "" && dtdate.Text == "")
            {
                MessageBox.Show("Serial No.、日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtdate.Focus();
                return;
            }
            //bds1.EndEdit();
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            bool lb_flag_green = false ;
            bool lb_flag_purple = false;
            const string sql_new =
            @"INSERT INTO development_tommy(serial_no,season,date,trim_code,requests_by,delivery,pvh_jv_ref,supplier_name,material,size,country,color,artwork_limit,
            tiered_qty1,price_size1,m_id1,price1,p_unit1,tiered_qty2,price_size2,m_id2,price2,p_unit2,tiered_qty3,price_size3,m_id3,price3,p_unit3,tiered_qty4,price_size4,m_id4,price4,p_unit4,tiered_qty5,price_size5,m_id5,price5,p_unit5,
            moq_usa,surcharge_usa,moq_eur,surcharge_eur,leadtime_sample,leadtime_bulk,trim_must_tommy,oekotex,suggested_care,fabric_limitations,machine_washable,drycleanable,dryclean_only,do_not_dryclean,can_tumble_drying,
            use_for_swimwear,use_for_childrenswear,cannot_pass_needle,quality_callouts,used_on_sms_eur,latest_submit_ref,best_vendor_do,bulk_reference,color_approved_size,
            quality_approval,size_approved_color,submit1,submit2,submit3,urgent,cs_mens,cs_womens,cs_boys,cs_girls,thm,thd,branding,th_spw_msw,th_spw_wsw,th_col_msw,th_col_wsw,
            th_kids,th_swim,th_underwear,th_acc_ftw,th_tailored,tommy_jeans,th_sport,mo_id1,mo_id2,mo_id3,color1,color2,color3,size1,size2,size3,create_by,create_date, normal_plate,hang_plate,spray,spray_rubber,rubber_button,is_ck,flag_green,flag_purple,division_desc,division) 
            VALUES(@serial_no,@season,@date,@trim_code,@requests_by,@delivery,@pvh_jv_ref,@supplier_name,@material,@size,@country,@color,@artwork_limit,
            @tiered_qty1,@price_size1,@m_id1,@price1,@p_unit1,@tiered_qty2,@price_size2,@m_id2,@price2,@p_unit2,@tiered_qty3,@price_size3,@m_id3,@price3,@p_unit3,@tiered_qty4,@price_size4,@m_id4,@price4,@p_unit4,@tiered_qty5,@price_size5,@m_id5,@price5,@p_unit5,
            @moq_usa,@surcharge_usa,@moq_eur,@surcharge_eur,@leadtime_sample,@leadtime_bulk,@trim_must_tommy,@oekotex,@suggested_care,@fabric_limitations,@machine_washable,@drycleanable,@dryclean_only,@do_not_dryclean,@can_tumble_drying,
            @use_for_swimwear,@use_for_childrenswear,@cannot_pass_needle,@quality_callouts,@used_on_sms_eur,@latest_submit_ref,@best_vendor_do,@bulk_reference,@color_approved_size,
            @quality_approval,@size_approved_color,@submit1,@submit2,@submit3,@urgent,@cs_mens,@cs_womens,@cs_boys,@cs_girls,@thm,@thd,@branding,@th_spw_msw,@th_spw_wsw,@th_col_msw,@th_col_wsw,
            @th_kids,@th_swim,@th_underwear,@th_acc_ftw,@th_tailored,@tommy_jeans,@th_sport,@mo_id1,@mo_id2,@mo_id3,@color1,@color2,@color3,@size1,@size2,@size3,@user_id,getdate(),@normal_plate,@hang_plate,@spray,@spray_rubber,@rubber_button,@is_ck,@flag_green,@flag_purple,@division_desc,@division)";

            const string sql_update =
            @"Update development_tommy 
            SET season=@season,date=@date,trim_code=@trim_code,requests_by=@requests_by,delivery=@delivery,pvh_jv_ref=@pvh_jv_ref,supplier_name=@supplier_name,material=@material,size=@size,country=@country,color=@color,artwork_limit=@artwork_limit,
            tiered_qty1=@tiered_qty1,price_size1=@price_size1,m_id1=@m_id1,price1=@price1,p_unit1=@p_unit1,tiered_qty2=@tiered_qty2,price_size2=@price_size2,m_id2=@m_id2,price2=@price2,p_unit2=@p_unit2,tiered_qty3=@tiered_qty3,price_size3=@price_size3,m_id3=@m_id3,price3=@price3,p_unit3=@p_unit3,
            tiered_qty4=@tiered_qty4,price_size4=@price_size4,m_id4=@m_id4,price4=@price4,p_unit4=@p_unit4,tiered_qty5=@tiered_qty5,price_size5=@price_size5,m_id5=@m_id5,price5=@price5,p_unit5=@p_unit5,
            moq_usa=@moq_usa,surcharge_usa=@surcharge_usa,moq_eur=@moq_eur,surcharge_eur=@surcharge_eur,leadtime_sample=@leadtime_sample,leadtime_bulk=@leadtime_bulk,trim_must_tommy=@trim_must_tommy,oekotex=@oekotex,suggested_care=@suggested_care,fabric_limitations=@fabric_limitations,machine_washable=@machine_washable,drycleanable=@drycleanable,dryclean_only=@dryclean_only,do_not_dryclean=@do_not_dryclean,
            can_tumble_drying=@can_tumble_drying,use_for_swimwear=@use_for_swimwear,use_for_childrenswear=@use_for_childrenswear,cannot_pass_needle=@cannot_pass_needle,quality_callouts=@quality_callouts,used_on_sms_eur=@used_on_sms_eur,latest_submit_ref=@latest_submit_ref,best_vendor_do=@best_vendor_do,bulk_reference=@bulk_reference,color_approved_size=@color_approved_size,
            quality_approval=@quality_approval,size_approved_color=@size_approved_color,submit1=@submit1,submit2=@submit2,submit3=@submit3,urgent=@urgent,cs_mens=@cs_mens,cs_womens=@cs_womens,cs_boys=@cs_boys,cs_girls=@cs_girls,thm=@thm,thd=@thd,branding=@branding,th_spw_msw=@th_spw_msw,th_spw_wsw=@th_spw_wsw,th_col_msw=@th_col_msw,th_col_wsw=@th_col_wsw,
            th_kids=@th_kids,th_swim=@th_swim,th_underwear=@th_underwear,th_acc_ftw=@th_acc_ftw,th_tailored=@th_tailored,tommy_jeans=@tommy_jeans,th_sport=@th_sport,mo_id1=@mo_id1,mo_id2=@mo_id2,mo_id3=@mo_id3,color1=@color1,color2=@color2,color3=@color3,size1=@size1,size2=@size2,size3=@size3,update_by=@user_id,update_date=getdate(),
            normal_plate=@normal_plate,hang_plate=@hang_plate,spray=@spray,spray_rubber=@spray_rubber,rubber_button=@rubber_button,is_ck=@is_ck,flag_green=@flag_green,flag_purple=@flag_purple,division_desc=@division_desc,division=@division
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
                        strSerial_no = clsTommyTest.GetSeqNo("development_tommy", "serial_no");
                        myCommand.Parameters.AddWithValue("@serial_no", strSerial_no);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@serial_no", txtserial_no.Text);
                        strSerial_no = txtserial_no.Text;
                    }
                    myCommand.Parameters.AddWithValue("@season", txtseason.EditValue);
                    myCommand.Parameters.AddWithValue("@date", clsApp.Return_String_Date(dtdate.Text));
                    myCommand.Parameters.AddWithValue("@trim_code", txttrim_code.Text);
                    myCommand.Parameters.AddWithValue("@requests_by", txtrequests_by.Text);
                    myCommand.Parameters.AddWithValue("@delivery", txtdelivery.Text);
                    myCommand.Parameters.AddWithValue("@pvh_jv_ref", txtpvh_jv_ref.Text);
                    myCommand.Parameters.AddWithValue("@supplier_name", txtsupplier_name.Text);
                    myCommand.Parameters.AddWithValue("@material", txtmaterial.Text);
                    myCommand.Parameters.AddWithValue("@size", txtsize.Text);
                    myCommand.Parameters.AddWithValue("@country", txtcountry.Text);
                    myCommand.Parameters.AddWithValue("@color", txtcolor.Text);
                    myCommand.Parameters.AddWithValue("@artwork_limit", txtartwork_limit.Text);
                    //----------------------------------------------------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@tiered_qty1", clsTommyTest.Get_int(txttiered_qty1.Text));
                    myCommand.Parameters.AddWithValue("@price_size1", txtprice_size1.Text);
                    myCommand.Parameters.AddWithValue("@m_id1", lkem_id1.EditValue);
                    myCommand.Parameters.AddWithValue("@price1", clsApp.Return_Float_Value_4(txtprice1.Text));
                    myCommand.Parameters.AddWithValue("@p_unit1", lkep_unit1.EditValue);

                    myCommand.Parameters.AddWithValue("@tiered_qty2", clsTommyTest.Get_int(txttiered_qty2.Text));
                    myCommand.Parameters.AddWithValue("@price_size2", txtprice_size2.Text);
                    myCommand.Parameters.AddWithValue("@m_id2", lkem_id2.EditValue);
                    myCommand.Parameters.AddWithValue("@price2", clsApp.Return_Float_Value_4(txtprice2.Text));
                    myCommand.Parameters.AddWithValue("@p_unit2", lkep_unit2.EditValue);
                    myCommand.Parameters.AddWithValue("@tiered_qty3", clsTommyTest.Get_int(txttiered_qty3.Text));
                    myCommand.Parameters.AddWithValue("@price_size3", txtprice_size3.Text);
                    myCommand.Parameters.AddWithValue("@m_id3", lkem_id3.EditValue);
                    myCommand.Parameters.AddWithValue("@price3", clsApp.Return_Float_Value_4(txtprice3.Text));
                    myCommand.Parameters.AddWithValue("@p_unit3", lkep_unit3.EditValue);
                    myCommand.Parameters.AddWithValue("@tiered_qty4", clsTommyTest.Get_int(txttiered_qty4.Text));
                    myCommand.Parameters.AddWithValue("@price_size4", txtprice_size4.Text);
                    myCommand.Parameters.AddWithValue("@m_id4", lkem_id4.EditValue);
                    myCommand.Parameters.AddWithValue("@price4", clsApp.Return_Float_Value_4(txtprice4.Text));
                    myCommand.Parameters.AddWithValue("@p_unit4", lkep_unit4.EditValue);
                    myCommand.Parameters.AddWithValue("@tiered_qty5", clsTommyTest.Get_int(txttiered_qty5.Text));
                    myCommand.Parameters.AddWithValue("@price_size5", txtprice_size5.Text);
                    myCommand.Parameters.AddWithValue("@m_id5", lkem_id5.EditValue);
                    myCommand.Parameters.AddWithValue("@price5", clsApp.Return_Float_Value_4(txtprice5.Text));
                    myCommand.Parameters.AddWithValue("@p_unit5", lkep_unit5.EditValue);
                    myCommand.Parameters.AddWithValue("@moq_usa", txtmoq_usa.Text);
                    myCommand.Parameters.AddWithValue("@surcharge_usa", txtsurcharge_usa.Text);
                    myCommand.Parameters.AddWithValue("@moq_eur", txtmoq_eur.Text);
                    myCommand.Parameters.AddWithValue("@surcharge_eur", txtsurcharge_eur.Text);
                    myCommand.Parameters.AddWithValue("@leadtime_sample", txtleadtime_sample.Text);
                    myCommand.Parameters.AddWithValue("@leadtime_bulk", txtleadtime_bulk.Text);
                    //-----------------------------------------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@trim_must_tommy", txttrim_must_tommy.Text);
                    myCommand.Parameters.AddWithValue("@oekotex", txtoekotex.Text);
                    myCommand.Parameters.AddWithValue("@suggested_care", txtsuggested_care.Text);
                    myCommand.Parameters.AddWithValue("@fabric_limitations", txtfabric_limitations.Text);
                    //---------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@machine_washable", chkmachine_washable.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@drycleanable", chkdrycleanable.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dryclean_only", chkdryclean_only.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@do_not_dryclean", chkdo_not_dryclean.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@can_tumble_drying", chkcan_tumble_drying.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@use_for_swimwear", chkuse_for_swimwear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@use_for_childrenswear", chkuse_for_childrenswear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cannot_pass_needle", chkcannot_pass_needle.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@quality_callouts", memquality_callouts.Text);
                    //-----------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@used_on_sms_eur", txtused_on_sms_eur.Text);
                    myCommand.Parameters.AddWithValue("@latest_submit_ref", txtlatest_submit_ref.Text);
                    myCommand.Parameters.AddWithValue("@best_vendor_do", txtbest_vendor_do.Text);
                    myCommand.Parameters.AddWithValue("@bulk_reference", txtbulk_reference.Text);
                    myCommand.Parameters.AddWithValue("@color_approved_size", txtcolor_approved_size.Text);
                    myCommand.Parameters.AddWithValue("@quality_approval", txtquality_approval.Text);
                    myCommand.Parameters.AddWithValue("@size_approved_color", txtsize_approved_color.Text);
                    //-----------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@submit1", chksubmit1.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@submit2", chksubmit2.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@submit3", chksubmit3.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@urgent", chkurgent.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_mens", chkcs_mens.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_womens", chkcs_womens.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_boys", chkcs_boys.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_girls", chkcs_girls.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@thm", chkthm.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@thd", chkthd.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@branding", chkbranding.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_spw_msw", chkth_spw_msw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_spw_wsw", chkth_spw_wsw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_col_msw", chkth_col_msw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_col_wsw", chkth_col_wsw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_kids", chkth_kids.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_swim", chkth_swim.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_underwear", chkth_underwear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_acc_ftw", chkth_acc_ftw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_tailored", chkth_tailored.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@tommy_jeans", chktommy_jeans.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_sport", chkth_sport.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@mo_id1", txtmo_id1.Text);
                    myCommand.Parameters.AddWithValue("@mo_id2", txtmo_id2.Text);
                    myCommand.Parameters.AddWithValue("@mo_id3", txtmo_id3.Text);
                    myCommand.Parameters.AddWithValue("@color1", txtcolor1.Text);
                    myCommand.Parameters.AddWithValue("@color2", txtcolor2.Text);
                    myCommand.Parameters.AddWithValue("@color3", txtcolor3.Text);
                    myCommand.Parameters.AddWithValue("@size1", txtsize1.Text);
                    myCommand.Parameters.AddWithValue("@size2", txtsize2.Text);
                    myCommand.Parameters.AddWithValue("@size3", txtsize3.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);                   
                    myCommand.Parameters.AddWithValue("@normal_plate", Chknormal_plate.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@hang_plate", Chkhang_plate.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@spray", Chkspray.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@spray_rubber", Chkspray_rubber.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@rubber_button", Chkrubber_button.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@is_ck", chkCK.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_desc", txtdivision_desc.Text);
                    myCommand.Parameters.AddWithValue("@division", chkDivision.Checked ? true : false);
                    //綠色選項
                    if (chkth_spw_msw.Checked || chkth_spw_wsw.Checked || chkth_col_msw.Checked || chkth_col_wsw.Checked || chkth_kids.Checked || chkth_tailored.Checked || chktommy_jeans.Checked||chkDivision.Checked ||chkth_acc_ftw.Checked)
                    {
                        lb_flag_green = true;
                    }
                    if (!chkth_spw_msw.Checked && !chkth_spw_wsw.Checked && !chkth_col_msw.Checked && !chkth_col_wsw.Checked && !chkth_kids.Checked && !chkth_tailored.Checked && !chktommy_jeans.Checked && !chkDivision.Checked && !chkth_acc_ftw.Checked)
                    {
                        lb_flag_green = false;
                    }
                    //紫色選項
                    if (chkth_swim.Checked || chkth_underwear.Checked || chkth_sport.Checked)
                    {
                        lb_flag_purple = true;
                    }
                    if (!chkth_swim.Checked && !chkth_underwear.Checked && !chkth_sport.Checked)
                    {
                        lb_flag_purple = false;
                    }
                    myCommand.Parameters.AddWithValue("@flag_green", lb_flag_green);
                    myCommand.Parameters.AddWithValue("@flag_purple", lb_flag_purple );
                    
                    

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

                mPvh_no = "";
                mPvh_no_type_id_2 = "";
                mPvh_no_type_id_3 = "";
                mPvh_no_type_id_ck = "";
                txttemp_pvh_no.Text = "";

                //MessageBoxTimeout((IntPtr )0,"數據保存成功!","提示信息",0,0,1000); //提示窗體1秒后自動關閉    
                clsUtility.myMessageBox("數據保存成功!", "提示信息");
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
                const string sql_del = "DELETE FROM dbo.development_tommy WHERE serial_no=@serial_no";
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

        private void frmDevelopmentTommy_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();
           dtMO.Dispose();
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
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "1");
            mState = "";

            mPvh_no = "";
            mPvh_no_type_id_2 = "";
            mPvh_no_type_id_3 = "";
            mPvh_no_type_id_ck = "";
            txttemp_pvh_no.Text = "";

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
            string sql = @"SELECT *,0 as pvh_no From development_tommy with(nolock) Where 1=1 ";
            if (txtId1.Text == "" && txtId2.Text == "" && dtDat1.Text == "" && dtDat2.Text == "")
                sql = @"SELECT * From development_tommy with(nolock) where 1=1 ";
            else
            {                
                if (txtId1.Text != "")
                {
                    sql = sql + string.Format(" and serial_no>='{0}'", txtId1.Text);
                }
                if (txtId2.Text != "")
                {
                    sql = sql + string.Format(" and serial_no<='{0}'", txtId2.Text);
                }
                if (dtDat1.Text != "")
                {
                    sql = sql + string.Format(" and date>='{0}'", clsApp.Return_String_Date(dtDat1.Text));
                }
                if (dtDat2.Text != "")
                {
                    sql = sql + string.Format(" and date<='{0}'", clsApp.Return_String_Date(dtDat2.Text));
                }
            }
            if (radioGroup1.SelectedIndex > 0)
            {
                if (radioGroup1.SelectedIndex == 1)
                {
                    sql = sql + " and flag_green=1";
                }
                else
                {
                    sql = sql + " and flag_purple=1";
                }
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            //bds1.DataSource = dtDetail;
            dgvDetails.DataSource = dtDetail;
            dgvFind.DataSource = dtDetail;
        }
     
        private void txtprice1_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice1); 
        }

        private void txtprice2_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice2); 
        }

        private void txtprice3_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice3); 
        }

        private void txtprice4_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice4); 
        }

        private void txtprice5_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice5); 
        }

        private static void Set_Number_Focus(DevExpress.XtraEditors.TextEdit objTextEdit)
        {
            if (objTextEdit.Text == "0.0000")
            {
                objTextEdit.Select(1, 0);
            }
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
                dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select serial_no,create_by,create_date,update_by,update_date From dbo.development_tommy with(nolock) WHERE serial_no='{0}'", strSerial_no));
                if (mState == "NEW")
                {
                    //dgvDetails.AllowUserToAddRows = true;                    
                    DataRow row = dtDetail.NewRow();//插一空行                   
                    //--------------------------------------------------------------
                    row["serial_no"]=txtserial_no.Text ;
                    row["season"] = txtseason.EditValue;
                    row["date"] = clsApp.Return_String_Date(dtdate.Text);
                    row["trim_code"] = txttrim_code.Text;
                    row["requests_by"] = txtrequests_by.Text;
                    row["delivery"] = txtdelivery.Text;
                    row["pvh_jv_ref"] = txtpvh_jv_ref.Text;
                    row["supplier_name"] = txtsupplier_name.Text ;
                    row["material"] = txtmaterial.Text;
                    row["size"] = txtsize.Text;
                    row["country"] = txtcountry.Text;
                    row["color"] = txtcolor.Text;
                    row["artwork_limit"] = txtartwork_limit.Text;
                    //===============================================================
                    row["tiered_qty1"] = clsTommyTest.Get_int(txttiered_qty1.Text);
                    row["price_size1"] = txtprice_size1.Text;
                    row["m_id1"] = lkem_id1.EditValue;
                    row["price1"] = clsApp.Return_Float_Value_4(txtprice1.Text);
                    row["p_unit1"] = lkep_unit1.EditValue;
                    //
                    row["tiered_qty2"] = clsTommyTest.Get_int(txttiered_qty2.Text);
                    row["price_size2"] = txtprice_size2.Text;
                    row["m_id2"] = lkem_id2.EditValue;
                    row["price2"] = clsApp.Return_Float_Value_4(txtprice2.Text);
                    row["p_unit2"] = lkep_unit2.EditValue;
                    //
                    row["tiered_qty3"] = clsTommyTest.Get_int(txttiered_qty3.Text);
                    row["price_size3"] = txtprice_size3.Text;
                    row["m_id3"] = lkem_id3.EditValue;
                    row["price3"] = clsApp.Return_Float_Value_4(txtprice3.Text);
                    row["p_unit3"] = lkep_unit3.EditValue;
                    //
                    row["tiered_qty4"] = clsTommyTest.Get_int(txttiered_qty4.Text);
                    row["price_size4"] = txtprice_size4.Text;
                    row["m_id4"] = lkem_id4.EditValue;
                    row["price4"] = clsApp.Return_Float_Value_4(txtprice4.Text);
                    row["p_unit4"] = lkep_unit4.EditValue;
                    //
                    row["tiered_qty5"] = clsTommyTest.Get_int(txttiered_qty5.Text);
                    row["price_size5"] = txtprice_size5.Text;
                    row["m_id5"] = lkem_id5.EditValue;
                    row["price5"] = clsApp.Return_Float_Value_4(txtprice5.Text);
                    row["p_unit5"] = lkep_unit5.EditValue;
                    //
                    row["moq_usa"] = txtmoq_usa.Text;
                    row["surcharge_usa"] = txtsurcharge_usa.Text;
                    row["moq_eur"] = txtmoq_eur.Text;
                    row["surcharge_eur"] = txtsurcharge_eur.Text;
                    row["leadtime_sample"] = txtleadtime_sample.Text;
                    row["leadtime_bulk"] = txtleadtime_bulk.Text;
                    //=================================================================
                    row["trim_must_tommy"] = txttrim_must_tommy.Text;
                    row["oekotex"] = txtoekotex.Text;
                    row["suggested_care"] = txtsuggested_care.Text;
                    row["fabric_limitations"] = txtfabric_limitations.Text;
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
                    //=================================================================
                    row["machine_washable"] = chkmachine_washable.Checked ? true : false;
                    row["drycleanable"] = chkdrycleanable.Checked ? true : false;
                    row["dryclean_only"] = chkdryclean_only.Checked ? true : false;
                    row["do_not_dryclean"] = chkdo_not_dryclean.Checked ? true : false;
                    row["can_tumble_drying"] = chkcan_tumble_drying.Checked ? true : false;
                    row["use_for_swimwear"] = chkuse_for_swimwear.Checked ? true : false;
                    row["use_for_childrenswear"] = chkuse_for_childrenswear.Checked ? true : false;
                    row["cannot_pass_needle"] = chkcannot_pass_needle.Checked ? true : false;
                    row["quality_callouts"] = memquality_callouts.Text;                    
                    //=================================================================
                    row["used_on_sms_eur"] = txtused_on_sms_eur.Text;
                    row["latest_submit_ref"] = txtlatest_submit_ref.Text;
                    row["best_vendor_do"] = txtbest_vendor_do.Text;
                    row["bulk_reference"] = txtbulk_reference.Text;
                    row["color_approved_size"] = txtcolor_approved_size.Text;
                    row["quality_approval"] = txtquality_approval.Text;
                    row["size_approved_color"] = txtsize_approved_color.Text;
                    //=================================================================
                    row["submit1"] = chksubmit1.Checked ? true : false;
                    row["submit2"] = chksubmit2.Checked ? true : false;
                    row["submit3"] = chksubmit3.Checked ? true : false;
                    row["urgent"] = chkurgent.Checked ? true : false;
                    row["cs_mens"] = chkcs_mens.Checked ? true : false;
                    row["cs_womens"] = chkcs_womens.Checked ? true : false;
                    row["cs_boys"] = chkcs_boys.Checked ? true : false;
                    row["cs_girls"] = chkcs_girls.Checked ? true : false;
                    row["thm"] = chkthm.Checked ? true : false;
                    row["thd"] = chkthd.Checked ? true : false;
                    row["branding"] = chkbranding.Checked ? true : false;
                    row["th_spw_msw"] = chkth_spw_msw.Checked ? true : false;
                    row["th_spw_wsw"] = chkth_spw_wsw.Checked ? true : false;
                    row["th_col_msw"] = chkth_col_msw.Checked ? true : false;
                    row["th_col_wsw"] = chkth_col_wsw.Checked ? true : false;
                    row["th_kids"] = chkth_kids.Checked ? true : false;
                    row["th_swim"] = chkth_swim.Checked ? true : false;
                    row["th_underwear"] = chkth_underwear.Checked ? true : false;
                    row["th_acc_ftw"] = chkth_acc_ftw.Checked ? true : false;
                    row["th_tailored"] = chkth_tailored.Checked ? true : false;
                    row["tommy_jeans"] = chktommy_jeans.Checked ? true : false;
                    row["th_sport"] = chkth_sport.Checked ? true : false;
                    row["mo_id1"] = txtmo_id1.Text;
                    row["mo_id2"] = txtmo_id2.Text;
                    row["mo_id3"] = txtmo_id3.Text;
                    row["color1"] = txtcolor1.Text;
                    row["color2"] = txtcolor2.Text;
                    row["color3"] = txtcolor3.Text;
                    row["size1"] = txtsize1.Text;
                    row["size2"] = txtsize2.Text;
                    row["size3"] = txtsize3.Text;
                    row["pvh_no"] = txttemp_pvh_no.Text == "" ? 0 : Int32.Parse(txttemp_pvh_no.Text);

                    row["normal_plate"] = Chknormal_plate.Checked ? true : false;
                    row["hang_plate"] = Chkhang_plate.Checked ? true : false;
                    row["spray"] = Chkspray.Checked ? true : false;
                    row["spray_rubber"] = Chkspray_rubber.Checked ? true : false;
                    row["rubber_button"] = Chkrubber_button.Checked ? true : false;
                    row["is_ck"] = chkCK.Checked ? true : false;
                    row["division_desc"] = txtdivision_desc.Text;
                    row["division"] = chkDivision.Checked ? true : false;
                    dtDetail.Rows.Add(row);
                }
                else
                {                                      
                    //--------------------------------------------------------------
                    dtDetail.Rows[row_reset]["serial_no"] = txtserial_no.Text;
                    dtDetail.Rows[row_reset]["season"] = txtseason.EditValue;
                    dtDetail.Rows[row_reset]["date"] = clsApp.Return_String_Date(dtdate.Text);
                    dtDetail.Rows[row_reset]["trim_code"] = txttrim_code.Text;
                    dtDetail.Rows[row_reset]["requests_by"] = txtrequests_by.Text;
                    dtDetail.Rows[row_reset]["delivery"] = txtdelivery.Text;
                    dtDetail.Rows[row_reset]["pvh_jv_ref"] = txtpvh_jv_ref.Text;
                    dtDetail.Rows[row_reset]["supplier_name"] = txtsupplier_name.Text;
                    dtDetail.Rows[row_reset]["material"] = txtmaterial.Text;
                    dtDetail.Rows[row_reset]["size"] = txtsize.Text;
                    dtDetail.Rows[row_reset]["country"] = txtcountry.Text;
                    dtDetail.Rows[row_reset]["color"] = txtcolor.Text;
                    dtDetail.Rows[row_reset]["artwork_limit"] = txtartwork_limit.Text;
                    //===============================================================
                    dtDetail.Rows[row_reset]["tiered_qty1"] = clsTommyTest.Get_int(txttiered_qty1.Text);
                    dtDetail.Rows[row_reset]["price_size1"] = txtprice_size1.Text;
                    dtDetail.Rows[row_reset]["m_id1"] = lkem_id1.EditValue;
                    dtDetail.Rows[row_reset]["price1"] = clsApp.Return_Float_Value_4(txtprice1.Text);
                    dtDetail.Rows[row_reset]["p_unit1"] = lkep_unit1.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty2"] = clsTommyTest.Get_int(txttiered_qty2.Text);
                    dtDetail.Rows[row_reset]["price_size2"] = txtprice_size2.Text;
                    dtDetail.Rows[row_reset]["m_id2"] = lkem_id2.EditValue;
                    dtDetail.Rows[row_reset]["price2"] = clsApp.Return_Float_Value_4(txtprice2.Text);
                    dtDetail.Rows[row_reset]["p_unit2"] = lkep_unit2.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty3"] = clsTommyTest.Get_int(txttiered_qty3.Text);
                    dtDetail.Rows[row_reset]["price_size3"] = txtprice_size3.Text;
                    dtDetail.Rows[row_reset]["m_id3"] = lkem_id3.EditValue;
                    dtDetail.Rows[row_reset]["price3"] = clsApp.Return_Float_Value_4(txtprice3.Text);
                    dtDetail.Rows[row_reset]["p_unit3"] = lkep_unit3.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty4"] = clsTommyTest.Get_int(txttiered_qty4.Text);
                    dtDetail.Rows[row_reset]["price_size4"] = txtprice_size4.Text;
                    dtDetail.Rows[row_reset]["m_id4"] = lkem_id4.EditValue;
                    dtDetail.Rows[row_reset]["price4"] = clsApp.Return_Float_Value_4(txtprice4.Text);
                    dtDetail.Rows[row_reset]["p_unit4"] = lkep_unit4.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty5"] = clsTommyTest.Get_int(txttiered_qty5.Text);
                    dtDetail.Rows[row_reset]["price_size5"] = txtprice_size5.Text;
                    dtDetail.Rows[row_reset]["m_id5"] = lkem_id5.EditValue;
                    dtDetail.Rows[row_reset]["price5"] = clsApp.Return_Float_Value_4(txtprice5.Text);
                    dtDetail.Rows[row_reset]["p_unit5"] = lkep_unit5.EditValue;
                    //
                    dtDetail.Rows[row_reset]["moq_usa"] = txtmoq_usa.Text;
                    dtDetail.Rows[row_reset]["surcharge_usa"] = txtsurcharge_usa.Text;
                    dtDetail.Rows[row_reset]["moq_eur"] = txtmoq_eur.Text;
                    dtDetail.Rows[row_reset]["surcharge_eur"] = txtsurcharge_eur.Text;
                    dtDetail.Rows[row_reset]["leadtime_sample"] = txtleadtime_sample.Text;
                    dtDetail.Rows[row_reset]["leadtime_bulk"] = txtleadtime_bulk.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["trim_must_tommy"] = txttrim_must_tommy.Text;
                    dtDetail.Rows[row_reset]["oekotex"] = txtoekotex.Text;
                    dtDetail.Rows[row_reset]["suggested_care"] = txtsuggested_care.Text;
                    dtDetail.Rows[row_reset]["fabric_limitations"] = txtfabric_limitations.Text;
                    dtDetail.Rows[row_reset]["create_by"] = txtCreate_by.Text;
                    dtDetail.Rows[row_reset]["create_date"] = txtCreate_date.Text;
                    dtDetail.Rows[row_reset]["update_by"] = txtUpdate_by.Text;
                    dtDetail.Rows[row_reset]["update_date"] = txtUpdate_date.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["machine_washable"] = chkmachine_washable.Checked ? true : false;
                    dtDetail.Rows[row_reset]["drycleanable"] = chkdrycleanable.Checked ? true : false;
                    dtDetail.Rows[row_reset]["dryclean_only"] = chkdryclean_only.Checked ? true : false;
                    dtDetail.Rows[row_reset]["do_not_dryclean"] = chkdo_not_dryclean.Checked ? true : false;
                    dtDetail.Rows[row_reset]["can_tumble_drying"] = chkcan_tumble_drying.Checked ? true : false;                    
                    dtDetail.Rows[row_reset]["use_for_swimwear"] = chkuse_for_swimwear.Checked ? true : false;
                    dtDetail.Rows[row_reset]["use_for_childrenswear"] = chkuse_for_childrenswear.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cannot_pass_needle"] = chkcannot_pass_needle.Checked ? true : false;
                    dtDetail.Rows[row_reset]["quality_callouts"] = memquality_callouts.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["used_on_sms_eur"] = txtused_on_sms_eur.Text;
                    dtDetail.Rows[row_reset]["latest_submit_ref"] = txtlatest_submit_ref.Text;
                    dtDetail.Rows[row_reset]["best_vendor_do"] = txtbest_vendor_do.Text;
                    dtDetail.Rows[row_reset]["bulk_reference"] = txtbulk_reference.Text;
                    dtDetail.Rows[row_reset]["color_approved_size"] = txtcolor_approved_size.Text;
                    dtDetail.Rows[row_reset]["quality_approval"] = txtquality_approval.Text;
                    dtDetail.Rows[row_reset]["size_approved_color"] = txtsize_approved_color.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["submit1"] = chksubmit1.Checked ? true : false;
                    dtDetail.Rows[row_reset]["submit2"] = chksubmit2.Checked ? true : false;
                    dtDetail.Rows[row_reset]["submit3"] = chksubmit3.Checked ? true : false;
                    dtDetail.Rows[row_reset]["urgent"] = chkurgent.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_mens"] = chkcs_mens.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_womens"] = chkcs_womens.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_boys"] = chkcs_boys.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_girls"] = chkcs_girls.Checked ? true : false;
                    dtDetail.Rows[row_reset]["thm"] = chkthm.Checked ? true : false;
                    dtDetail.Rows[row_reset]["thd"] = chkthd.Checked ? true : false;
                    dtDetail.Rows[row_reset]["branding"] = chkbranding.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_spw_msw"] = chkth_spw_msw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_spw_wsw"] = chkth_spw_wsw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_col_msw"] = chkth_col_msw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_col_wsw"] = chkth_col_wsw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_kids"] = chkth_kids.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_swim"] = chkth_swim.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_underwear"] = chkth_underwear.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_acc_ftw"] = chkth_acc_ftw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_tailored"] = chkth_tailored.Checked ? true : false;
                    dtDetail.Rows[row_reset]["tommy_jeans"] = chktommy_jeans.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_sport"] = chkth_sport.Checked ? true : false;
                    dtDetail.Rows[row_reset]["mo_id1"] = txtmo_id1.Text;
                    dtDetail.Rows[row_reset]["mo_id2"] = txtmo_id2.Text;
                    dtDetail.Rows[row_reset]["mo_id3"] = txtmo_id3.Text;
                    dtDetail.Rows[row_reset]["color1"] = txtcolor1.Text;
                    dtDetail.Rows[row_reset]["color2"] = txtcolor2.Text;
                    dtDetail.Rows[row_reset]["color3"] = txtcolor3.Text;
                    dtDetail.Rows[row_reset]["size1"] = txtsize1.Text;
                    dtDetail.Rows[row_reset]["size2"] = txtsize2.Text;
                    dtDetail.Rows[row_reset]["size3"] = txtsize3.Text;
                    dtDetail.Rows[row_reset]["pvh_no"] = txttemp_pvh_no.Text==""?0:Int32.Parse(txttemp_pvh_no.Text);

                    dtDetail.Rows[row_reset]["normal_plate"] = Chknormal_plate.Checked ? true : false;
                    dtDetail.Rows[row_reset]["hang_plate"] = Chkhang_plate.Checked ? true : false;
                    dtDetail.Rows[row_reset]["spray"] = Chkspray.Checked ? true : false;
                    dtDetail.Rows[row_reset]["spray_rubber"] = Chkspray_rubber.Checked ? true : false;
                    dtDetail.Rows[row_reset]["rubber_button"] = Chkrubber_button.Checked ? true : false;
                    dtDetail.Rows[row_reset]["is_ck"] = chkCK.Checked ? true : false;
                    dtDetail.Rows[row_reset]["division_desc"] = txtdivision_desc.Text;
                    dtDetail.Rows[row_reset]["division"] = chkDivision.Checked ? true : false;
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
            dtdate.EditValue = Convert.ToDateTime(pdr.Cells["date"].Value.ToString()).ToString("yyyy-MM-dd");
            txtseason.EditValue = pdr.Cells["season"].Value.ToString();
            txttrim_code.Text = pdr.Cells["trim_code"].Value.ToString();
            txtrequests_by.Text = pdr.Cells["requests_by"].Value.ToString();
            txtdelivery.Text = pdr.Cells["delivery"].Value.ToString();
            txtpvh_jv_ref.Text = pdr.Cells["pvh_jv_ref"].Value.ToString();
            txttemp_pvh_no.Text = pdr.Cells["pvh_no"].Value.ToString();//隱藏的臨時編號
            txtsupplier_name.Text = pdr.Cells["supplier_name"].Value.ToString();
            txtmaterial.Text = pdr.Cells["material"].Value.ToString();
            txtsize.Text = pdr.Cells["size"].Value.ToString();
            txtcountry.Text = pdr.Cells["country"].Value.ToString();
            txtcolor.Text = pdr.Cells["color"].Value.ToString();
            txtartwork_limit.Text = pdr.Cells["artwork_limit"].Value.ToString();            
            //===============================================================
            txttiered_qty1.Text = pdr.Cells["tiered_qty1"].Value.ToString();
            txtprice_size1.Text = pdr.Cells["price_size1"].Value.ToString();
            lkem_id1.EditValue = pdr.Cells["m_id1"].Value.ToString();
            txtprice1.Text = pdr.Cells["price1"].Value.ToString();
            lkep_unit1.EditValue = pdr.Cells["p_unit1"].Value.ToString();            
            //
            txttiered_qty2.Text = pdr.Cells["tiered_qty2"].Value.ToString();
            txtprice_size2.Text = pdr.Cells["price_size2"].Value.ToString();
            lkem_id2.EditValue = pdr.Cells["m_id2"].Value.ToString();
            txtprice2.Text = pdr.Cells["price2"].Value.ToString();
            lkep_unit2.EditValue = pdr.Cells["p_unit2"].Value.ToString();            
            //
            txttiered_qty3.Text = pdr.Cells["tiered_qty3"].Value.ToString();
            txtprice_size3.Text = pdr.Cells["price_size3"].Value.ToString();
            lkem_id3.EditValue = pdr.Cells["m_id3"].Value.ToString();
            txtprice3.Text = pdr.Cells["price3"].Value.ToString();
            lkep_unit3.EditValue = pdr.Cells["p_unit3"].Value.ToString();  
            //
            txttiered_qty4.Text = pdr.Cells["tiered_qty4"].Value.ToString();
            txtprice_size4.Text = pdr.Cells["price_size4"].Value.ToString();
            lkem_id4.EditValue = pdr.Cells["m_id4"].Value.ToString();
            txtprice4.Text = pdr.Cells["price4"].Value.ToString();
            lkep_unit4.EditValue = pdr.Cells["p_unit4"].Value.ToString();  
            //
            txttiered_qty5.Text = pdr.Cells["tiered_qty5"].Value.ToString();
            txtprice_size5.Text = pdr.Cells["price_size5"].Value.ToString();
            lkem_id5.EditValue = pdr.Cells["m_id5"].Value.ToString();
            txtprice5.Text = pdr.Cells["price5"].Value.ToString();
            lkep_unit5.EditValue = pdr.Cells["p_unit5"].Value.ToString();  
            //
            txtmoq_usa.Text = pdr.Cells["moq_usa"].Value.ToString();
            txtsurcharge_usa.Text = pdr.Cells["surcharge_usa"].Value.ToString();
            txtmoq_eur.Text = pdr.Cells["moq_eur"].Value.ToString();
            txtsurcharge_eur.Text = pdr.Cells["surcharge_eur"].Value.ToString();
            txtleadtime_sample.Text = pdr.Cells["leadtime_sample"].Value.ToString();
            txtleadtime_bulk.Text = pdr.Cells["leadtime_bulk"].Value.ToString();            
            //=================================================================
            txttrim_must_tommy.Text = pdr.Cells["trim_must_tommy"].Value.ToString();
            txtoekotex.Text= pdr.Cells["oekotex"].Value.ToString();
            txtsuggested_care.Text = pdr.Cells["suggested_care"].Value.ToString();
            txtfabric_limitations.Text = pdr.Cells["fabric_limitations"].Value.ToString();
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
            //=================================================================
            chkmachine_washable.Checked = pdr.Cells["machine_washable"].Value.ToString() == "True" ? true : false;
            chkdrycleanable.Checked = pdr.Cells["drycleanable"].Value.ToString() == "True" ? true : false;
            chkdryclean_only.Checked = pdr.Cells["dryclean_only"].Value.ToString() == "True" ? true : false;
            chkdo_not_dryclean.Checked = pdr.Cells["do_not_dryclean"].Value.ToString() == "True" ? true : false;
            chkcan_tumble_drying.Checked = pdr.Cells["can_tumble_drying"].Value.ToString() == "True" ? true : false;            
            chkuse_for_swimwear.Checked = pdr.Cells["use_for_swimwear"].Value.ToString() == "True" ? true : false;
            chkuse_for_childrenswear.Checked = pdr.Cells["use_for_childrenswear"].Value.ToString() == "True" ? true : false;
            chkcannot_pass_needle.Checked = pdr.Cells["cannot_pass_needle"].Value.ToString() == "True" ? true : false;
            memquality_callouts.Text = pdr.Cells["quality_callouts"].Value.ToString() ;            
            //=================================================================
            txtused_on_sms_eur.Text = pdr.Cells["used_on_sms_eur"].Value.ToString();
            txtlatest_submit_ref.Text = pdr.Cells["latest_submit_ref"].Value.ToString();
            txtbest_vendor_do.Text = pdr.Cells["best_vendor_do"].Value.ToString();
            txtbulk_reference.Text = pdr.Cells["bulk_reference"].Value.ToString();
            txtcolor_approved_size.Text = pdr.Cells["color_approved_size"].Value.ToString();
            txtquality_approval.Text = pdr.Cells["quality_approval"].Value.ToString();
            txtsize_approved_color.Text = pdr.Cells["size_approved_color"].Value.ToString();            
            //=================================================================
            chksubmit1.Checked = pdr.Cells["submit1"].Value.ToString() == "True" ? true : false;
            chksubmit2.Checked = pdr.Cells["submit2"].Value.ToString() == "True" ? true : false;
            chksubmit3.Checked = pdr.Cells["submit3"].Value.ToString() == "True" ? true : false;
            chkurgent.Checked = pdr.Cells["urgent"].Value.ToString() == "True" ? true : false;
            chkcs_mens.Checked = pdr.Cells["cs_mens"].Value.ToString() == "True" ? true : false;
            chkcs_womens.Checked = pdr.Cells["cs_womens"].Value.ToString() == "True" ? true : false;
            chkcs_boys.Checked = pdr.Cells["cs_boys"].Value.ToString() == "True" ? true : false;
            chkcs_girls.Checked = pdr.Cells["cs_girls"].Value.ToString() == "True" ? true : false;
            chkthm.Checked = pdr.Cells["thm"].Value.ToString() == "True" ? true : false;
            chkthd.Checked = pdr.Cells["thd"].Value.ToString() == "True" ? true : false;
            chkbranding.Checked = pdr.Cells["branding"].Value.ToString() == "True" ? true : false;
            chkth_spw_msw.Checked = pdr.Cells["th_spw_msw"].Value.ToString() == "True" ? true : false;
            chkth_spw_wsw.Checked = pdr.Cells["th_spw_wsw"].Value.ToString() == "True" ? true : false;
            chkth_col_msw.Checked = pdr.Cells["th_col_msw"].Value.ToString() == "True" ? true : false;
            chkth_col_wsw.Checked = pdr.Cells["th_col_wsw"].Value.ToString() == "True" ? true : false;
            chkth_kids.Checked = pdr.Cells["th_kids"].Value.ToString() == "True" ? true : false;
            chkth_swim.Checked = pdr.Cells["th_swim"].Value.ToString() == "True" ? true : false;
            chkth_underwear.Checked = pdr.Cells["th_underwear"].Value.ToString() == "True" ? true : false;
            chkth_acc_ftw.Checked = pdr.Cells["th_acc_ftw"].Value.ToString() == "True" ? true : false;
            chkth_tailored.Checked = pdr.Cells["th_tailored"].Value.ToString() == "True" ? true : false;
            chktommy_jeans.Checked = pdr.Cells["tommy_jeans"].Value.ToString() == "True" ? true : false;
            chkth_sport.Checked = pdr.Cells["th_sport"].Value.ToString() == "True" ? true : false;
            txtmo_id1.Text = pdr.Cells["mo_id1"].Value.ToString();
            txtmo_id2.Text = pdr.Cells["mo_id2"].Value.ToString();
            txtmo_id3.Text = pdr.Cells["mo_id3"].Value.ToString();
            txtcolor1.Text = pdr.Cells["color1"].Value.ToString();
            txtcolor2.Text = pdr.Cells["color2"].Value.ToString();
            txtcolor3.Text = pdr.Cells["color3"].Value.ToString();
            txtsize1.Text = pdr.Cells["size1"].Value.ToString();
            txtsize2.Text = pdr.Cells["size2"].Value.ToString();
            txtsize3.Text = pdr.Cells["size3"].Value.ToString();

            Chknormal_plate.Checked= pdr.Cells["normal_plate"].Value.ToString()=="True" ? true : false;
            Chkhang_plate.Checked = pdr.Cells["hang_plate"].Value.ToString()=="True" ? true : false;
            Chkspray.Checked = pdr.Cells["spray"].Value.ToString()=="True" ? true : false;
            Chkspray_rubber.Checked =pdr.Cells["spray_rubber"].Value.ToString()=="True" ? true : false;
            Chkrubber_button.Checked = pdr.Cells["rubber_button"].Value.ToString() == "True" ? true : false;
            chkCK.Checked = pdr.Cells["is_ck"].Value.ToString() == "True" ? true : false;
            txtdivision_desc.Text = pdr.Cells["division_desc"].Value.ToString();
            chkDivision.Checked = pdr.Cells["division"].Value.ToString() == "True" ? true : false;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
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
            string strsql = string.Format(@"Select * FROM dbo.development_tommy WHERE serial_no='{0}'",txtserial_no.Text);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(strsql);
            if (radGrp1.SelectedIndex == 0)
            {
                using (xrTommyTest1 rpt = new xrTommyTest1() { DataSource = dtReport })
                {
                    rpt.CreateDocument();
                    rpt.PrintingSystem.ShowMarginsWarning = false;
                    rpt.ShowPreviewDialog();
                }
            }
            else
            {
                using (xrTommyTest2 rpt = new xrTommyTest2() { DataSource = dtReport })
                {
                    rpt.CreateDocument();
                    rpt.PrintingSystem.ShowMarginsWarning = false;
                    rpt.ShowPreviewDialog();
                }
            }
        }

        private void txttrim_code_Leave(object sender, EventArgs e)
        {
            if (mState != "" && !string.IsNullOrEmpty(txttrim_code.Text))
            {
                string strsql = string.Format(
                @"SELECT TOP 1 ISNULL(A.season,'') AS season,A.m_id,B.customer_goods,B.mo_id,
                ROUND(CONVERT(float,B.unit_price),3) AS unit_price,B.goods_unit
                FROM dgerp2.cferp.dbo.so_order_manage A with(nolock),dgerp2.cferp.dbo.so_order_details B with(nolock)
                WHERE A.within_code=B.within_code AND A.id=B.id and A.ver=B.ver AND A.within_code='0000' and A.state NOT IN ('2','V') AND
                B.customer_goods LIKE '%{0}%' 
                ORDER BY A.order_date DESC", txttrim_code.Text );
                dtMO = clsPublicOfCF01.GetDataTable(strsql);
                if (dtMO.Rows.Count > 0)
                {
                    txtseason.EditValue = dtMO.Rows[0]["season"].ToString();
                    txtmo_id1.Text = dtMO.Rows[0]["mo_id"].ToString();
                    lkem_id1.EditValue = dtMO.Rows[0]["m_id"].ToString();
                    txtprice1.Text = dtMO.Rows[0]["unit_price"].ToString();
                    lkep_unit1.EditValue = dtMO.Rows[0]["goods_unit"].ToString();
                }
            }
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            mPvh_no = "";
            mPvh_no_type_id_2 = "";
            mPvh_no_type_id_3 = "";
            mPvh_no_type_id_ck = "";
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                AddNew();
                Set_head(dgvrow);
                dtdate.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                string max_serial_no = clsTommyTest.GetSeqNo("development_tommy", "serial_no");
                txtserial_no.Text = max_serial_no;
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtmo_id1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmo_id1.Text) && mState != "")
            {
                if (!Get_Cust_color(txtmo_id1.Text, "A"))
                {
                    MessageBox.Show(string.Format("當前頁數【{0}】不正確！", txtmo_id1.Text), "提示信息");
                    txtmo_id1.Focus();
                    txtmo_id1.SelectAll();
                }
            }
        }

        private void txtmo_id2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmo_id2.Text) && mState != "")
            {
                if (!Get_Cust_color(txtmo_id2.Text, "B"))
                {
                    MessageBox.Show(string.Format("當前頁數【{0}】不正確！", txtmo_id2.Text), "提示信息");
                    txtmo_id2.Focus();
                    txtmo_id2.SelectAll();
                }
                else
                {                   
                    string str = string.Format(
                    @"SELECT A.customer_goods,A.customer_size,A.customer_color_id,B.english_name as goods_name
                      From {0}so_order_details A with(nolock) 
                           INNER JOIN {0}it_goods B with(nolock) ON A.within_code=B.within_code and A.goods_id=B.id
                      WHERE A.within_code='0000' and A.mo_id='{1}'", DBUtility.remote_db, txtmo_id2.Text);
                    DataTable dtMo = clsPublicOfCF01.GetDataTable(str);
                    txttrim_code.Text = dtMo.Rows[0]["customer_goods"].ToString();
                    txtsize.Text = dtMo.Rows[0]["customer_size"].ToString();
                    txtcolor.Text = dtMo.Rows[0]["customer_color_id"].ToString();
                    str=dtMo.Rows[0]["goods_name"].ToString();
                    str = str.Replace(";", ",");
                    str = str.Substring(0, str.IndexOf(","));
                    txtmaterial.Text = str;
                }
            }
            
        }

        private void txtmo_id3_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmo_id3.Text) && mState != "")
            {
                if (!Get_Cust_color(txtmo_id3.Text, "C"))
                {
                    MessageBox.Show(string.Format("當前頁數【{0}】不正確！", txtmo_id3.Text), "提示信息");
                    txtmo_id3.Focus();
                    txtmo_id3.SelectAll();
                }
            }
        }

        private  bool Get_Cust_color(string strMo_id,string strObject)
        {
            bool blResult = true;
            string sql = string.Format(
                @"SELECT ISNULL(customer_color_id,'') AS customer_color_id,ISNULL(customer_size,'') AS customer_size 
                From dgerp2.cferp.dbo.so_order_details with(nolock) WHERE mo_id='{0}'", strMo_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["customer_color_id"].ToString()))
                {
                    switch (strObject)
                    {
                        case "A":
                            txtcolor1.Text = dt.Rows[0]["customer_color_id"].ToString();                            
                            break;
                        case "B":
                            txtcolor2.Text = dt.Rows[0]["customer_color_id"].ToString();                            
                            break;
                        case "C":
                            txtcolor3.Text = dt.Rows[0]["customer_color_id"].ToString();                            
                            break;
                        default:
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["customer_size"].ToString()))
                {
                    switch (strObject)
                    {
                        case "A":
                            txtsize1.Text = dt.Rows[0]["customer_size"].ToString();
                            break;
                        case "B":
                            txtsize2.Text = dt.Rows[0]["customer_size"].ToString();
                            break;
                        case "C":
                            txtsize3.Text = dt.Rows[0]["customer_size"].ToString();
                            break;
                        default :
                            break;
                    }
                }
                blResult = true;
            }
            else
            {               
                blResult = false ;                
            }
            return blResult;
        }

        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }
            tabControl1.SelectedIndex = 0;
        }

        private void BTNREFNO_Click(object sender, EventArgs e)
        {
            Export_to_Excel();
        }

        private void Export_to_Excel()
        {
            if (dgvFind.RowCount > 0)
            {                
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    /*saveDialog.DefaultExt = "";*/
                    Title = "保存EXECL文件",
                    Filter = "EXECL文件|*.xls",
                    FilterIndex = 1
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    int FormatNum;//保存excel文件的格式
                    string Version;//excel版本號

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
                        return;
                    }
                    Version = xlApp.Version;//獲取當前使用excel版本號
                    if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                    {
                        FormatNum = -4143;
                    }
                    else //you use excel 2007 or later
                    {
                        FormatNum = 56;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
                   
                    DataTable dtHead = new DataTable();
                    string title = clsPublicOfCF01.ExecuteSqlReturnObject("Select title from development_setting where id=1");
                    
                    //第一行为报表名称
                    worksheet.Cells[1, 1] = title; //標題地址                    
                    worksheet.Range["A1:L1"].Merge(0);//合并单元格
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體
                    worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[1].RowHeight = 156;
                    
                    //寫入欄位標題   
                    worksheet.Rows[2].RowHeight = 15;
                    worksheet.Rows[3].RowHeight = 48;
                    worksheet.Cells[2, 1] = "REF NO";                    
                    worksheet.Cells[2, 6] = "SUPPLIER";
                    worksheet.Cells[2, 7] = "INITIAL";
                    worksheet.Cells[2, 8] = "SEASON";
                    worksheet.Cells[2, 9] = "TH#";
                    worksheet.Cells[2, 10] = "COLOR";
                    worksheet.Cells[2, 11] = "SIZE";                   
                    worksheet.Cells[2, 12] = "DESIGNER";
                    worksheet.Cells[3, 1] = "OFFICE";
                    worksheet.Cells[3, 2] = "DIVISION";
                    worksheet.Cells[3, 3] = "SUPPLIER CODE";
                    worksheet.Cells[3, 4] = "#";
                    worksheet.Cells[3, 5] = "YEAR";
                    worksheet.Rows[2].Font.Bold = true;//粗體
                    worksheet.Rows[3].Font.Bold = true;//粗體
                    worksheet.Rows[2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Range["A2:E2"].Merge(0);//合并单元格
                    worksheet.Range["A3:A3"].Merge(0);
                    worksheet.Range["B3:B3"].Merge(0);
                    worksheet.Range["C3:C3"].Merge(0);
                    worksheet.Range["D3:D3"].Merge(0);
                    worksheet.Range["E3:E3"].Merge(0);
                    worksheet.Range["F2:F3"].Merge(0);
                    worksheet.Range["G2:G3"].Merge(0);
                    worksheet.Range["H2:H3"].Merge(0);
                    worksheet.Range["I2:I3"].Merge(0);
                    worksheet.Range["J2:J3"].Merge(0);
                    worksheet.Range["K2:K3"].Merge(0);
                    worksheet.Range["L2:L3"].Merge(0);
                    
                    //寫入數值 
                    int i=0,cur_row=0;
                    string str_value = "", str_divison1 = "", str_divison2 = "", str_searial_no = ""; ;
                    for (int r = 0; r < dgvFind.RowCount; r++)//行
                    {
                        i = i + 1;
                        cur_row = r + 4;//當前行
                        worksheet.Rows[cur_row].Font.Size = 10;
                        str_value = dgvFind.Rows[r].Cells["pvh_jv_ref"].Value.ToString();
                        if (!string.IsNullOrEmpty(str_value) && str_value.Substring(0, 1) == "H") //PVH NO 以H開頭的才處理
                        {                            
                            worksheet.Cells[cur_row, 1] = str_value.Substring(0, 1);
                            worksheet.Cells[cur_row, 5] = "/" + str_value.Substring(str_value.Length - 2, 2);
                            str_searial_no = str_value.Substring(4, 4);//序號

                            //CS_MENS
                            str_value = dgvFind.Rows[r].Cells["cs_mens"].Value.ToString();
                            if (str_value == "True")
                            {
                                str_divison1 = "M";
                                str_divison2 = "JL";
                            }
                            //THM
                            str_value = dgvFind.Rows[r].Cells["thm"].Value.ToString();
                            if (str_value == "True")
                            {
                                str_divison1 = "M";
                                str_divison2 = "JL";
                            }
                            //cs_womens
                            str_value = dgvFind.Rows[r].Cells["cs_womens"].Value.ToString();
                            if (str_value == "True")
                            {
                                str_divison1 = "W";
                                str_divison2 = "AM";
                            }
                            //cs_boys
                            str_value = dgvFind.Rows[r].Cells["cs_boys"].Value.ToString();
                            if (str_value == "True")
                            {
                                str_divison1 = "C";
                                str_divison2 = "MW";
                            }
                            //cs_girls
                            str_value = dgvFind.Rows[r].Cells["cs_girls"].Value.ToString();
                            if (str_value == "True")
                            {
                                str_divison1 = "C";
                                str_divison2 = "MW";
                            }
                            worksheet.Cells[cur_row, 2] = str_divison1;
                            worksheet.Cells[cur_row, 7] = str_divison2;
                            worksheet.Cells[cur_row, 3] = "CF";
                            //worksheet.Cells[cur_row, 4] = "'" + i.ToString().PadLeft(4, '0');//序號
                            worksheet.Cells[cur_row, 4] = "'" + str_searial_no; //序號
                
                        }                        
                                            
                        worksheet.Cells[cur_row, 6] = dgvFind.Rows[r].Cells["supplier_name"].Value.ToString();
                        worksheet.Cells[cur_row, 8] = dgvFind.Rows[r].Cells["season"].Value.ToString();
                        worksheet.Cells[cur_row, 9] = dgvFind.Rows[r].Cells["trim_code"].Value.ToString();
                        worksheet.Cells[cur_row, 10] = dgvFind.Rows[r].Cells["color"].Value.ToString();
                        worksheet.Cells[cur_row, 11] = dgvFind.Rows[r].Cells["size"].Value.ToString();
                        worksheet.Cells[cur_row, 12] = dgvFind.Rows[r].Cells["requests_by"].Value.ToString();

                        if (dgvFind.Rows[r].Cells["th_swim"].Value.ToString() == "True" ||
                           dgvFind.Rows[r].Cells["th_underwear"].Value.ToString() == "True" ||
                           dgvFind.Rows[r].Cells["th_sport"].Value.ToString() == "True")
                        {
                            //當選TH SWIM時負責人顯示BP
                            if (dgvFind.Rows[r].Cells["th_swim"].Value.ToString() == "True")
                            {
                                worksheet.Cells[cur_row, 7] = "BP";
                            }
                            //當選TOMMY SPORT TH UNDERWEAR時負責人顯示VY
                            if (dgvFind.Rows[r].Cells["th_underwear"].Value.ToString() == "True" || dgvFind.Rows[r].Cells["th_sport"].Value.ToString() == "True")
                            {
                                worksheet.Cells[cur_row, 7] = "VY";
                            }

                            if (!string.IsNullOrEmpty(str_value))
                            {
                                worksheet.Cells[3, 13] = "Submit Date";
                                worksheet.Cells[cur_row, 13] = DateTime.Parse(dgvFind.Rows[r].Cells["date"].Value.ToString()).Date.ToString("yyyy/MM/dd");//Submit Date
                                worksheet.Cells[3, 14] = "BRAND";
                                worksheet.Cells[cur_row, 14] = str_value.Substring(0, 2);//BRAND
                                worksheet.Cells[cur_row, 2] = str_value.Substring(2, 1);//DIVISION
                                worksheet.Cells[cur_row, 6] = str_value.Substring(3, 2);//SUPPLIER CODE
                                worksheet.Cells[cur_row, 4] = str_value.Substring(6, 4);//流水號
                                worksheet.Cells[cur_row, 5] = str_value.Substring(10, 3);//YEAR;
                            }

                        }


                        for (int x = 1; x <= 12; x++)
                        {
                            worksheet.Cells[cur_row, x].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }
                        
                    }
                    System.Windows.Forms.Application.DoEvents();
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应                   
                   
                    //获取Excel多个单元格区域
                    string rang = string.Format("L{0}", i+3);//右下角座標
                    Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", rang);
                    //单元格边框线类型(线型,虚线型)
                    excelRange.Borders.LineStyle = 1;
                    excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    
                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            //workbook.SaveCopyAs(saveFileName);
                            workbook.SaveAs(FileName, FormatNum);
                            //fileSaved = true;  
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;  
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁
                    // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                    MessageBox.Show("匯出EXCEL成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 綠色選項TOMMY格式
        /// </summary>
        private void Export_Excel_Tommy()
        {
            if (dgvFind.RowCount > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    /*saveDialog.DefaultExt = "";*/
                    Title = "保存EXECL文件",
                    Filter = "EXECL文件|*.xls",
                    FilterIndex = 1
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    int FormatNum;//保存excel文件的格式
                    string Version;//excel版本號

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
                        return;
                    }
                    Version = xlApp.Version;//獲取當前使用excel版本號
                    if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                    {
                        FormatNum = -4143;
                    }
                    else //you use excel 2007 or later
                    {
                        FormatNum = 56;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                    DataTable dtHead = new DataTable();
                    string title = clsPublicOfCF01.ExecuteSqlReturnObject("Select title from development_setting where id=1");

                    //第一行为报表名称
                    worksheet.Cells[1, 1] = title; //標題地址                    
                    worksheet.Range["A1:G1"].Merge(0);//合并单元格
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體
                    worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[1].RowHeight = 156;

                    //寫入欄位標題   
                    worksheet.Rows[2].RowHeight = 15;                   
                    worksheet.Cells[2, 1] = "Supplier";
                    worksheet.Cells[2, 2] = "Sample Sent HK Hubs Date";
                    worksheet.Cells[2, 3] = "Ref No";
                    worksheet.Cells[2, 4] = "Year";
                    worksheet.Cells[2, 5] = "PLM Code(Size&Color),Used/Not Used On SMS,With/Without Loose Sample";
                    worksheet.Cells[2, 6] = "Remark(Season/Divison/AMS Requested By)";
                    worksheet.Cells[2, 7] = "HK Hubs";                    
                    worksheet.Rows[2].Font.Bold = true;//粗體                   
                    worksheet.Rows[2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;                  

                    //寫入數值 
                    int i = 0, cur_row = 0;
                    string str_value = "", str_divison1 = "", str_divison2 = "", str_searial_no = ""; ;
                    for (int r = 0; r < dgvFind.RowCount; r++)//行
                    {
                        i = i + 1;
                        cur_row = r + 3;//當前行
                        worksheet.Rows[cur_row].Font.Size = 10;
                        worksheet.Cells[cur_row, 1] = dgvFind.Rows[r].Cells["supplier_name"].Value.ToString();
                        str_value = dgvFind.Rows[r].Cells["pvh_jv_ref"].Value.ToString();
                        if (!string.IsNullOrEmpty(str_value))
                        {
                            worksheet.Cells[cur_row, 3] = str_value.Substring(0, str_value.Length - 3);//序號
                            worksheet.Cells[cur_row, 4] = str_value.Substring(str_value.Length - 3, 3);//年度
                        }
                        worksheet.Cells[cur_row, 2] = DateTime.Parse(dgvFind.Rows[r].Cells["date"].Value.ToString()).Date.ToString("yyyy/MM/dd");
                        worksheet.Cells[cur_row, 5] = txttrim_code.Text+" ("+txtsize.Text +"/"+txtcolor.Text + ") " ;
                        if (dgvFind.Rows[r].Cells["th_spw_wsw"].Value.ToString() == "True" || dgvFind.Rows[r].Cells["th_col_wsw"].Value.ToString() == "True" ||
                            dgvFind.Rows[r].Cells["th_kids"].Value.ToString() == "True")
                        {
                            worksheet.Cells[cur_row, 5] = txttrim_code.Text + " (" + txtcolor.Text + "/" + txtsize.Text + ") " + " 5pcs loose sample";
                        }
                        string str = dgvFind.Rows[r].Cells["season"].Value.ToString();
                        if (chkth_spw_msw.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Kammy";//HK Hubs
                            str += " " + chkth_spw_msw.Text;
                        }
                        if (chkth_spw_wsw.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Asta";
                            str += " " + chkth_spw_wsw.Text;
                        }
                        if (chkth_col_msw.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Kammy";//HK Hubs
                            str += " " + chkth_col_msw.Text;
                        }
                        if (chkth_col_wsw.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Asta";
                            str += " " + chkth_col_wsw.Text;
                        }
                        if (chkth_kids.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Asta";
                            str += " " + chkth_kids.Text;
                        }
                        if (chkth_tailored.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Kammy";
                            str += " " + chkth_tailored.Text;
                        }
                        if (chktommy_jeans.Checked)
                        {
                            worksheet.Cells[cur_row, 7] = "Kammy";
                            str += " " + chktommy_jeans.Text;
                        }
                        str += " -- " + txtrequests_by.Text;
                        worksheet.Cells[cur_row, 6] = str;

                        for (int x = 1; x <= 7; x++)
                        {
                            worksheet.Cells[cur_row, x].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        }

                    }
                    System.Windows.Forms.Application.DoEvents();
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应                   

                    //获取Excel多个单元格区域
                    string rang = string.Format("G{0}", i + 3);//右下角座標
                    Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", rang);
                    //单元格边框线类型(线型,虚线型)
                    excelRange.Borders.LineStyle = 1;
                    excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            //workbook.SaveCopyAs(saveFileName);
                            workbook.SaveAs(FileName, FormatNum);
                            //fileSaved = true;  
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;  
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁
                    // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                    MessageBox.Show("匯出EXCEL成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtpvh_jv_ref_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (chkth_spw_msw.Checked || chkth_spw_wsw.Checked || chkth_col_msw.Checked || chkth_col_wsw.Checked || chkth_kids.Checked || chkth_swim.Checked
                || chkth_underwear.Checked || chkth_tailored.Checked || chktommy_jeans.Checked || chkth_sport.Checked || chkDivision.Checked || chkth_acc_ftw.Checked)
            {
                //**如果選中綠色或紫色
                if (chkth_swim.Checked || chkth_underwear.Checked || chkth_sport.Checked)
                {
                    //選中紫色
                    string ls_option_purple = "";
                    if (chkth_swim.Checked)
                    {
                        ls_option_purple = "S";
                    }
                    if (chkth_underwear.Checked)
                    {
                        ls_option_purple = "U";
                    }
                    if (chkth_sport.Checked)
                    {
                        ls_option_purple = "P";
                    }
                    
                    string str_replace = "";
                    if (chkCK.Checked)
                    {                        
                        if (mState == "NEW" )
                        {
                            if (mPvh_no_type_id_ck == "")
                                Get_CK_SearialNo("3", chkCK.Checked, ls_option_purple);
                            else
                            {
                                str_replace = mPvh_no_type_id_ck.Substring(2, 1);
                                txtpvh_jv_ref.Text = mPvh_no_type_id_ck.Replace(str_replace, ls_option_purple);
                            }
                        }
                    }
                    else
                    {                        
                        if (mState == "NEW" )
                        {
                            if (mPvh_no_type_id_3 == "")
                                Get_CK_SearialNo("3", chkCK.Checked, ls_option_purple);
                            else
                            {
                                str_replace = mPvh_no_type_id_3.Substring(2, 1);
                                txtpvh_jv_ref.Text = mPvh_no_type_id_3.Replace(str_replace, ls_option_purple);
                            }
                        }
                    }
                                    
                }
                else
                {
                    //選中綠色
                    Get_PVH_No();
                }
            }
            else
            {
                Get_New_PVH_No();
            }
        }

        private void Get_New_PVH_No()
        {
            if (mState == "NEW")
            {
                //防止多次GEN新的序號
                if (txttemp_pvh_no.Text == "0" || txttemp_pvh_no.Text == "")
                {
                    //首次點擊產生序號的按鈕
                    Get_Pvh_SearialNo();
                    if (mPvh_no != "") //產生序號是否成功
                    {
                        GenSearialNo(); //顯示序號字串
                    }
                }
                else
                {
                    //序號已加過1，重復點擊按鈕或改變Devison，重新產生序號
                    GenSearialNo();
                }
            }
        }

        private void Get_PVH_No()
        {
            if (mState == "NEW")
            {
                //防止多次GEN新的序號
                if (mPvh_no_type_id_2 == "") //產生序號是否成功
                {
                    Get_Pvh_SearialNo("2");
                    txtpvh_jv_ref.Text = mPvh_no_type_id_2;
                }
            }
        }

        private string Get_Pvh_SearialNo()
        {
            string ls_result = "";
            int li_searial_no;
            string ls_year = "/" + clsPublicOfCF01.ExecuteSqlReturnObject("select Substring(convert(varchar(5),DATEPART(YEAR,getdate())),3,2) as yy");
            DataTable dt = clsPublicOfCF01.GetDataTable(string.Format(@"select comp,searial_no from development_setting with(nolock) where type_id='{0}' and years='{1}'","1",ls_year));
            if (dt.Rows.Count > 0 && dt.Rows[0]["searial_no"].ToString() != "")
            {
                li_searial_no = int.Parse(dt.Rows[0]["searial_no"].ToString()) + 1;
                ls_result = dt.Rows[0]["comp"] + li_searial_no.ToString("0000") + ls_year;
                try
                {
                    string sql_u = string.Format(@"Update development_setting set searial_no={0} WHERE  type_id='{1}' and years='{2}'", li_searial_no,"1", ls_year);
                    clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                    txttemp_pvh_no.Text = li_searial_no.ToString();
                    mPvh_no = ls_result;
                }
                catch (Exception ex)
                {
                    mPvh_no = "";
                    txttemp_pvh_no.Text = "";
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                ls_result = "";
                string ls_sql_i = string.Format(@"Insert into development_setting(type_id,comp,searial_no,years,months) values('1','CF',1,'{0}','')",ls_year);
                clsPublicOfCF01.ExecuteSqlUpdate(ls_sql_i);
                //MessageBox.Show("請設置當前對應年度的PVH序列號參數!", "系統提示");
                ls_result = "CF" + "0001" + ls_year;
            }
            return ls_result;
        }

        private string Get_Pvh_SearialNo(string type_id)
        {
            //年度加月份跳序列號
            string ls_result = "";
            int li_searial_no;
            string ls_year = "/" + clsPublicOfCF01.ExecuteSqlReturnObject("Select Substring(convert(varchar(5),DATEPART(YEAR,getdate())),3,2) as yy");
            string ls_month =clsPublicOfCF01.ExecuteSqlReturnObject(@"Select SUBSTRING(CONVERT(varchar(10), GETDATE(),112),5,2) as mm");
            DataTable dt = clsPublicOfCF01.GetDataTable(
            string.Format(@"Select comp,searial_no,months From development_setting with(nolock) Where type_id='{0}' and years='{1}' and months='{2}'", type_id, ls_year,ls_month));
            if (dt.Rows.Count > 0 && dt.Rows[0]["searial_no"].ToString() != "")
            {
                li_searial_no = int.Parse(dt.Rows[0]["searial_no"].ToString()) + 1;             
                ls_result = string.Format("{0}-{1}{2}{3}", dt.Rows[0]["comp"], ls_month, li_searial_no.ToString("000"), ls_year) ;
                try
                {
                    string sql_u = string.Format(@"Update development_setting set searial_no={0} WHERE  type_id='{1}' and years='{2}' and months='{3}'", li_searial_no, "2", ls_year,ls_month);
                    clsPublicOfCF01.ExecuteSqlUpdate(sql_u);                    
                    mPvh_no_type_id_2 = ls_result;
                }
                catch (Exception ex)
                {
                    mPvh_no_type_id_2 = "";                  
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                ls_result = "";
                li_searial_no = 1;
                string sql_i =string.Format(@"Insert into development_setting(type_id,comp,searial_no,years,months) values('{0}','{1}',{2},'{3}','{4}')","2","CF",li_searial_no,ls_year,ls_month);
                clsPublicOfCF01.ExecuteSqlUpdate(sql_i);               
                ls_result = string.Format("{0}-{1}{2}{3}", "CF", ls_month, li_searial_no.ToString("000"), ls_year);                       
                mPvh_no_type_id_2 = ls_result;
                
            }
            return ls_result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type_id"> 此值為3</param>
        /// <param name="is_ck">是否勾選了CK這個選項</param>
        /// <param name="select_value">TH SWIM(S),TH SPORT(P),TH UNDERWEAR(U)</param>
        /// <returns>返回的序列號</returns>
        private string Get_CK_SearialNo(string type_id,bool is_ck,string select_value)
        {
            //按年度跳序列號
            //type_id="3"
            string ls_result = "";
            int li_searial_no;           
            string ls_comp = "";
            if (is_ck)
            {
                ls_comp = "CK";
            }
            else
            {
                ls_comp = "TH";
            }            
            string ls_year = "/" + clsPublicOfCF01.ExecuteSqlReturnObject("Select Substring(Convert(varchar(5),DATEPART(YEAR,getdate())),3,2) as yy");           
            DataTable dt = clsPublicOfCF01.GetDataTable(
            string.Format(@"Select comp,searial_no,months From development_setting with(nolock) Where type_id='{0}' and comp='{1}' and years='{2}'", type_id, ls_comp, ls_year));
            if (dt.Rows.Count > 0 && dt.Rows[0]["searial_no"].ToString() != "")
            {
                li_searial_no = int.Parse(dt.Rows[0]["searial_no"].ToString()) + 1;
                ls_result = string.Format("{0}{1}CF-{2}{3}", ls_comp, select_value, li_searial_no.ToString("0000"), ls_year);
                try
                {
                    string sql_u = string.Format(@"Update development_setting SET searial_no={0} WHERE type_id='{1}' and comp='{2}' and years='{3}'", li_searial_no, type_id, ls_comp, ls_year);
                    clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                    if (is_ck)
                        mPvh_no_type_id_ck = ls_result;
                    else
                        mPvh_no_type_id_3 = ls_result;
                }
                catch (Exception ex)
                {
                    if (is_ck)
                        mPvh_no_type_id_ck = "";
                    else
                        mPvh_no_type_id_3 = "";
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                ls_result = "";
                li_searial_no = 1;
                string sql_i = string.Format(@"Insert Into development_setting(type_id,comp,searial_no,years,months) values('{0}','{1}',{2},'{3}','{4}')", type_id, ls_comp, li_searial_no, ls_year, "");
                clsPublicOfCF01.ExecuteSqlUpdate(sql_i);
                ls_result = string.Format("{0}{1}CF-{2}{3}", ls_comp, select_value, li_searial_no.ToString("0000"), ls_year);
                if (is_ck)
                    mPvh_no_type_id_ck = ls_result;
                else
                    mPvh_no_type_id_3 = ls_result;
            }
            txtpvh_jv_ref.Text = ls_result;

            return ls_result;
        }

        private void GenSearialNo()
        {            
            string ls_devison = " ";
            if (chkcs_mens.Checked || chkthm.Checked)
            {
                ls_devison = "M";
            }
            if (chkthm.Checked)
            {
                ls_devison = "M";
            }            
            if (chkcs_womens.Checked)
            {
                ls_devison = "W";
            }
            if (chkcs_boys.Checked)
            {
                ls_devison = "C";
            }
            if (chkcs_girls.Checked)
            {
                ls_devison = "C";
            }
            if (chkth_acc_ftw.Checked)
            {
                ls_devison = "A";
            }
            txtpvh_jv_ref.Text = String.Format("H{0}{1}", ls_devison, mPvh_no);
        }

        private void chkcs_mens_MouseUp(object sender, MouseEventArgs e)
        {
            //if(chkcs_mens.CheckState.ToString()=="Checked")
            if (txttemp_pvh_no.Text != "")
            {
                Get_New_PVH_No();
            }
        }

        private void chkcs_womens_MouseUp(object sender, MouseEventArgs e)
        {
            if (txttemp_pvh_no.Text != "")
            {
                Get_New_PVH_No();
            }
        }

        private void chkcs_boys_MouseUp(object sender, MouseEventArgs e)
        {
            if (txttemp_pvh_no.Text != "")
            {
                Get_New_PVH_No();
            }
        }

        private void chkcs_girls_MouseUp(object sender, MouseEventArgs e)
        {
            if (txttemp_pvh_no.Text != "")
            {
                Get_New_PVH_No();
            }
        }

        private void chkthm_MouseUp(object sender, MouseEventArgs e)
        {
            if (txttemp_pvh_no.Text != "")
            {
                Get_New_PVH_No();
            }
        }    
  

        private void Chknormal_plate_MouseUp(object sender, MouseEventArgs e)
        {
            if (Chknormal_plate.Checked)
            {
                Chkhang_plate.Checked = false;
                Chkspray.Checked = false;
                Chkspray_rubber.Checked = false;
                Chkrubber_button.Checked = false;
                
                
                chkmachine_washable.Checked = true;
                chkdrycleanable.Checked = true;
                txtsuggested_care.Text = "Normal wash";
            }
            else
                txtsuggested_care.Text = "";
        }

        private void Chkhang_plate_MouseUp(object sender, MouseEventArgs e)
        {
            if (Chkhang_plate.Checked)
            {
                Chknormal_plate.Checked = false;
                Chkspray.Checked = false;
                Chkspray_rubber.Checked = false;
                Chkrubber_button.Checked = false;

                chkmachine_washable.Checked = true;
                chkdrycleanable.Checked = true;
                string str = "1.Normal wash" + "\r\n" + "2.High Shine Finsh trims should be turn inside out to wash, but if the button placement is at bottom hem,cuff opening,waistband(close to opening end) etc which" +
                       " cannot protect the button after turn inside out leading the exposure during laundry,we suggest to put the garment IN MESH BAG during machine wash.";
                txtsuggested_care.Text = str;
            }
            else
            {
                chkmachine_washable.Checked = false;
                chkdrycleanable.Checked = false;
                txtsuggested_care.Text = "";
            }
        }

        private void Chkspray_MouseUp(object sender, MouseEventArgs e)
        {
            if (Chkspray.Checked)
            {
                Chknormal_plate.Checked = false;
                Chkhang_plate.Checked = false;
                Chkspray_rubber.Checked = false;
                Chkrubber_button.Checked = false;

                chkmachine_washable.Checked = true;
                chkdrycleanable.Checked = true;
                string str = "1.Used on similar color fabric.Normal wash with similar color clothes " + "\r\n" +
                "2.Enamel trims should be turn inside out to wash,but if the button placement is at bottom hem,cuff opening,waistband(close to opening end) etc which cannot protect " +
                "the button after turn inside out leading the exposure during laundry,we suggest to put the garment IN MESH BAG during machine wash.";
                txtsuggested_care.Text = str;
            }
            else
            {
                chkmachine_washable.Checked = false;
                chkdrycleanable.Checked = false;
                txtsuggested_care.Text = "";
            }
        }

        private void Chkspray_rubber_MouseUp(object sender, MouseEventArgs e)
        {
            if (Chkspray_rubber.Checked)
            {
                Chknormal_plate.Checked = false;
                Chkhang_plate.Checked = false;
                Chkspray.Checked = false;
                Chkrubber_button.Checked = false;
                
                chkmachine_washable.Checked = true;
                chkdo_not_dryclean.Checked = true;
                string str = "1.Used on similar color fabric.Normal wash with similar color clothes " + "\r\n" +
                "2.Rubberized Enamel trims should be turn inside out to wash,but if the button placement is at bottom hem,cuff opening,waistband(close to opening end) etc which cannot protect " +
                "the button after turn inside out leading the exposure during laundry,we suggest to put the garment IN MESH BAG during machine wash.";
                txtsuggested_care.Text = str;
                str = "Rubberized enamel will be soiled or stained easily,and cannot be repaired. Customer must be careful and take good care of all rubberized enamel items during" + "\r\n" +
                 "production-environment and toolds must be tidy and clean. Proper packaging is required. Customer have to take his/her won responsibility if handle inappropriate.";
                memquality_callouts.Text = str;
            }
            else
            {
                chkmachine_washable.Checked = false;
                chkdo_not_dryclean.Checked = false;
                txtsuggested_care.Text = "";
                memquality_callouts.Text = "";
            }
        }

        private void Chkrubber_button_MouseUp(object sender, MouseEventArgs e)
        {
            if (Chkrubber_button.Checked)
            {
                Chknormal_plate.Checked = false;
                Chkhang_plate.Checked = false;
                Chkspray.Checked = false;
                Chkspray_rubber.Checked = false;

                chkmachine_washable.Checked = true;
                chkdo_not_dryclean.Checked = true;
                string str = "1.Used on similar color fabric.Normal wash with similar color clothes " + "\r\n" +
                "2.Trims should be turn inside out to wash,but if the button placement is at bottom hem,cuff opening,waistband(close to opening end) etc which cannot protect " +
                "the button after turn inside out leading the exposure during laundry,we suggest to put the garment IN MESH BAG during machine wash.";
                txtsuggested_care.Text = str;
            }
            else
            {
                chkmachine_washable.Checked = false;
                chkdo_not_dryclean.Checked = false;
                txtsuggested_care.Text = "";                
            }
        }

        private void Set_Quality_Callouts()
        {            
            memquality_callouts.Text = "Rubberized enamel will be soiled or stained easily, and cannot be repaired.  Customer must be careful and take good care of all rubberized enamel items during production – environment and toolds must be tidy and clean.  Proper packaging is required.  Customer have to take his/her won responsibility if handle inappropriate.";             
        }

        private void chkmachine_washable_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkmachine_washable.Checked)
            {
                Set_Quality_Callouts();
            }
        }

        private void chkdo_not_dryclean_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkdo_not_dryclean.Checked)
            {
                Set_Quality_Callouts();
            }
        }

        private void btnTommy_Click(object sender, EventArgs e)
        {
            Export_Excel_Tommy();
        }

     
    }
}
