/*
 * Create by :   Allen Leung 
 * Create Date : 2022-02-23
 * remark:
 * HK E組 PVH FOR US 牌子辦卡
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
using DevExpress.XtraEditors;

namespace cf01.Forms
{
    public partial class frmDevelopmentPvhUs : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();        
        public string mState = "";
        private string user_group = clsDgdDeliverGoods.getUserGroup(DBUtility._user_id);
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();
        public BindingSource bds1 = new BindingSource();

        public frmDevelopmentPvhUs()
        {
            InitializeComponent();

            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();

            const string sql = @"SELECT * From development_us_pvh with(nolock) where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;// dtDetail;
        }

        private void frmDevelopmentPvhUs_Load(object sender, EventArgs e)
        {            
            //Load_Date();  
            string strSql = "";
            strSql = string.Format(@"SELECT contents AS id,remark AS country FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "raw_mat_country");
            DataTable dtMaterialCountry = clsPublicOfCF01.GetDataTable(strSql);
            lueRaw_material_country.Properties.DataSource = dtMaterialCountry;
            lueRaw_material_country.Properties.ValueMember = "id";
            lueRaw_material_country.Properties.DisplayMember = "id";

            //********
            strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "material_content");
            DataTable dtContent = clsPublicOfCF01.GetDataTable(strSql);
            luematerial_content1.Properties.DataSource = dtContent;
            luematerial_content1.Properties.ValueMember = "id";
            luematerial_content1.Properties.DisplayMember = "id";

            luematerial_content2.Properties.DataSource = dtContent;
            luematerial_content2.Properties.ValueMember = "id";
            luematerial_content2.Properties.DisplayMember = "id";

            luematerial_content3.Properties.DataSource = dtContent;
            luematerial_content3.Properties.ValueMember = "id";
            luematerial_content3.Properties.DisplayMember = "id";

            luematerial_content4.Properties.DataSource = dtContent;
            luematerial_content4.Properties.ValueMember = "id";
            luematerial_content4.Properties.DisplayMember = "id";

            strSql = string.Format(@"SELECT remark AS name,contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "z_combox_check_us");
            DataTable dtQuality = clsPublicOfCF01.GetDataTable(strSql);
            lueCheck.Properties.DataSource = dtQuality;
            lueCheck.Properties.ValueMember = "id";
            lueCheck.Properties.DisplayMember = "Name";

            dtDoc_date1.EditValue = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd").Substring(0, 10);
            dtDoc_date2.EditValue = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 10);

            //數據綁定
            SetDataBindings();
        }

        private void SetDataBindings()
        {
            txtSerial_no.DataBindings.Add("Text", bds1, "Serial_no");
            //lueDivision.DataBindings.Add("EditValue", bds1, "division");
            lueRaw_material_country.DataBindings.Add("EditValue", bds1, "raw_material_country");
            txtProduction_country.DataBindings.Add("Text", bds1, "production_country");
            txtreference_number.DataBindings.Add("Text", bds1, "reference_number");
            txtdoc_date.DataBindings.Add("EditValue", bds1, "doc_date");
            txtsupplier_name.DataBindings.Add("Text", bds1, "supplier_name");
            txtFactory_name.DataBindings.Add("Text", bds1, "factory_name");
            //-------------------------------------------------------
            txtPlm_material_code.DataBindings.Add("Text", bds1, "plm_material_code");
            txtSeason.DataBindings.Add("Text", bds1, "season");
            txtRequested_by.DataBindings.Add("Text", bds1, "requested_by");
            dtSample_submis_date.DataBindings.Add("EditValue", bds1, "Sample_submis_date");
            dtDelivery_date.DataBindings.Add("EditValue", bds1, "delivery_date");
            //-------------------------------------------------------            
            txtTrim_flat_price.DataBindings.Add("Text", bds1, "trim_flat_price");
            txttrim_1k.DataBindings.Add("Text", bds1, "trim_1k");
            txttrim_1k_3k.DataBindings.Add("Text", bds1, "trim_1k_3k");
            txttrim_3k_5k.DataBindings.Add("Text", bds1, "trim_3k_5k");
            txtMoq.DataBindings.Add("Text", bds1, "moq");
            txtSurcharge.DataBindings.Add("Text", bds1, "surcharge");
            txtsrs_leadtime.DataBindings.Add("Text", bds1, "srs_leadtime");
            txtbulk_leadtime.DataBindings.Add("Text", bds1, "bulk_leadtime");
            //-------------------------------------------------------
            txtmaterial_per1.DataBindings.Add("Text", bds1, "material_per1");
            luematerial_content1.DataBindings.Add("EditValue", bds1, "material_content1");
            txtmaterial_per2.DataBindings.Add("Text", bds1, "material_per2");
            luematerial_content2.DataBindings.Add("EditValue", bds1, "material_content2");
            txtmaterial_per3.DataBindings.Add("Text", bds1, "material_per3");
            luematerial_content3.DataBindings.Add("EditValue", bds1, "material_content3");
            txtmaterial_per4.DataBindings.Add("Text", bds1, "material_per4");
            luematerial_content4.DataBindings.Add("EditValue", bds1, "material_content4");
            txtmaterial_other.DataBindings.Add("Text", bds1, "material_other");
            txtweight.DataBindings.Add("Text", bds1, "weight");
            txtthcikness.DataBindings.Add("Text", bds1, "thcikness");
            //-------------------------------------------------------
            txtconformity_of_test.DataBindings.Add("Text", bds1, "conformity_of_test");
            //-------------------------------------------------------
            txtbluesign_cert.DataBindings.Add("Text", bds1, "bluesign_cert");
            //-------------------------------------------------------
            txtcertificate_number.DataBindings.Add("Text", bds1, "certificate_number");
            //-------------------------------------------------------
            txtMo_id1.DataBindings.Add("Text", bds1, "mo_id1");
            txtMo_id2.DataBindings.Add("Text", bds1, "mo_id2");
            txtMo_id3.DataBindings.Add("Text", bds1, "mo_id3");
            txtQuality_callouts.DataBindings.Add("Text", bds1, "quality_callouts");
            txtcolor_name.DataBindings.Add("Text", bds1, "color_name");
            txtcolor_code.DataBindings.Add("Text", bds1, "color_code");
            //--------------------------------------------------------
                       
            //chkurgent_bulk_order.DataBindings.Add("Checked", bds1, "urgent_bulk_order");
            
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
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            dgvDetails.Enabled = false;
            //新增時設置初始值            
            txtdoc_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            dtSample_submis_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            txtSerial_no.Text = clsTommyTest.GetSeqNo("development_us_pvh","serial_no");
            txtreference_number.Text = clsDevelopentPvh.GetPvhNoForUs(txtSerial_no.Text);
            txtsupplier_name.Text = "Ching Fung Apparel Accessories Co.,Ltd";
            txtFactory_name.Text = "Ching Fung Metal Manufactory(Longnan) Co.,Ltd";
            
            txtMoq.Text = "NIL";
            txtSurcharge.Text = "NIL";
            chktrim_conform_yes.Checked = true;
            chktrim_comply_yes.Checked = true;
            chkoekotex_class1.Checked = true;
            chksus_grs.Checked = true;
            chktrim_review_yes.Checked = true;
            txtsrs_leadtime.Text = "14-16 Wordking days";
            txtbulk_leadtime.Text = "21-28 Wordking days";
            txtSerial_no.Properties.ReadOnly = true;
            txtSerial_no.BackColor = Color.White;
            txtreference_number.Properties.ReadOnly = true;
            txtreference_number.BackColor = Color.White;

            //dgvDetails.Enabled = false;
            //lueDivision.Focus();    
        }

        private void Save()
        {
            txtSerial_no.Focus();
            if (txtSerial_no.Text == "" && txtdoc_date.Text == "" && dtSample_submis_date.Text=="")
            {
                MessageBox.Show("Serial No.、日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdoc_date.Focus();
                return;
            }
            bds1.EndEdit();                    
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO development_us_pvh(serial_no,doc_date,raw_material_country,production_country,supplier_name,factory_name,plm_material_code,
                    reference_number,season,sample_submis_date,requested_by,delivery_date,division_mens,division_womens,division_boys,division_girls,
                    division_branding,division_swim,division_denim,division_th_accy,division_tommy_jeans,division_specialty,division_adaptive,
                    division_mercedez_benz,trim_flat_price,trim_1k,trim_1k_3k,trim_3k_5k,moq,surcharge,srs_leadtime,bulk_leadtime,material_per1,
                    material_content1,material_per2,material_content2,material_per3,material_content3,material_per4,material_content4,material_other,
                    weight,thcikness,trim_conform_yes,trim_conform_no,conformity_of_test,trim_comply_yes,trim_comply_no,tick_box_oekotex,tick_box_bluesign,
                    tick_box_party_testing,oekotex_class1,oekotex_class2,bluesign_cert,sus_grs,sus_pcs,sus_gots,sus_fsc,sus_lwg,sus_other,certificate_number,
                    sug_machine_wash,sug_hand_wash_only,sug_do_not_dryclean,sug_dryclean_only,sug_swimwear,sug_childrenwear,sug_pass_needle,sug_turn_inside_out,
                    quality_callouts,color_name,color_code,color_archroma,color_pantone,color_csi,color_th_stand,color_supplier,dimen_size_inch,dimen_size_mm,
                    best_can_do,for_approval_yes,for_color_yes,for_bulk_ref_yes,sub_submit1,sub_submit2,sub_urgent,status_approved,status_correct,status_resubmit,
                    status_cancelled,trim_review_yes,trim_review_no,depth_lighter,depth_deeper,chroma_brighter,chroma_duller,hue_yellower,hue_redder,hue_bluer,
                    hue_greener,mo_id1,mo_id2,mo_id3,create_by,create_date) 
            VALUES(@serial_no,@doc_date,@raw_material_country,@production_country,@supplier_name,@factory_name,@plm_material_code,
                    @reference_number,@season,@sample_submis_date,@requested_by,@delivery_date,@division_mens,@division_womens,@division_boys,@division_girls,
                    @division_branding,@division_swim,@division_denim,@division_th_accy,@division_tommy_jeans,@division_specialty,@division_adaptive,
                    @division_mercedez_benz,@trim_flat_price,@trim_1k,@trim_1k_3k,@trim_3k_5k,@moq,@surcharge,@srs_leadtime,@bulk_leadtime,@material_per1,
                    @material_content1,@material_per2,@material_content2,@material_per3,@material_content3,@material_per4,@material_content4,@material_other,
                    @weight,@thcikness,@trim_conform_yes,@trim_conform_no,@conformity_of_test,@trim_comply_yes,@trim_comply_no,@tick_box_oekotex,@tick_box_bluesign,
                    @tick_box_party_testing,@oekotex_class1,@oekotex_class2,@bluesign_cert,@sus_grs,@sus_pcs,@sus_gots,@sus_fsc,@sus_lwg,@sus_other,@certificate_number,
                    @sug_machine_wash,@sug_hand_wash_only,@sug_do_not_dryclean,@sug_dryclean_only,@sug_swimwear,@sug_childrenwear,@sug_pass_needle,@sug_turn_inside_out,
                    @quality_callouts,@color_name,@color_code,@color_archroma,@color_pantone,@color_csi,@color_th_stand,@color_supplier,@dimen_size_inch,@dimen_size_mm,
                    @best_can_do,@for_approval_yes,@for_color_yes,@for_bulk_ref_yes,@sub_submit1,@sub_submit2,@sub_urgent,@status_approved,@status_correct,@status_resubmit,
                    @status_cancelled,@trim_review_yes,@trim_review_no,@depth_lighter,@depth_deeper,@chroma_brighter,@chroma_duller,@hue_yellower,@hue_redder,@hue_bluer,
                    @hue_greener,@mo_id1,@mo_id2,@mo_id3,@user_id,getdate())";
            const string sql_update =
            @"Update development_us_pvh 
            SET doc_date=@doc_date,raw_material_country=@raw_material_country,production_country=@production_country,supplier_name=@supplier_name,factory_name=@factory_name,
                plm_material_code=@plm_material_code,season=@season,sample_submis_date=@sample_submis_date,requested_by=@requested_by,division_mens=@division_mens,
                delivery_date=case when len(@delivery_date)=0 then null else @delivery_date end,division_womens=@division_womens,division_boys=@division_boys,
                division_girls=@division_girls,division_branding=@division_branding,division_swim=@division_swim,division_denim=@division_denim,
                division_th_accy=@division_th_accy,division_tommy_jeans=@division_tommy_jeans,division_specialty=@division_specialty,division_adaptive=@division_adaptive,
                division_mercedez_benz=@division_mercedez_benz,trim_flat_price=@trim_flat_price,trim_1k=@trim_1k,trim_1k_3k=@trim_1k_3k,trim_3k_5k=@trim_3k_5k,moq=@moq,
                surcharge=@surcharge,srs_leadtime=@srs_leadtime,bulk_leadtime=@bulk_leadtime,material_per1=@material_per1,material_content1=@material_content1,
                material_per2=@material_per2,material_content2=@material_content2,material_per3=@material_per3,material_content3=@material_content3,material_per4=@material_per4,
                material_content4=@material_content4,material_other=@material_other,weight=@weight,thcikness=@thcikness,trim_conform_yes=@trim_conform_yes,
                trim_conform_no=@trim_conform_no,conformity_of_test=@conformity_of_test,trim_comply_yes=@trim_comply_yes,trim_comply_no=@trim_comply_no,
                tick_box_oekotex=@tick_box_oekotex,tick_box_bluesign=@tick_box_bluesign,tick_box_party_testing=@tick_box_party_testing,oekotex_class1=@oekotex_class1,
                oekotex_class2=@oekotex_class2,bluesign_cert=@bluesign_cert,sus_grs=@sus_grs,sus_pcs=@sus_pcs,sus_gots=@sus_gots,sus_fsc=@sus_fsc,sus_lwg=@sus_lwg,
                sus_other=@sus_other,certificate_number=@certificate_number,sug_machine_wash=@sug_machine_wash,sug_hand_wash_only=@sug_hand_wash_only,
                sug_do_not_dryclean=@sug_do_not_dryclean,sug_dryclean_only=@sug_dryclean_only,sug_swimwear=@sug_swimwear,sug_childrenwear=@sug_childrenwear,
                sug_pass_needle=@sug_pass_needle,sug_turn_inside_out=@sug_turn_inside_out,quality_callouts=@quality_callouts,color_name=@color_name,color_code=@color_code,
                color_archroma=@color_archroma,color_pantone=@color_pantone,color_csi=@color_csi,color_th_stand=@color_th_stand,color_supplier=@color_supplier,
                dimen_size_inch=@dimen_size_inch,dimen_size_mm=@dimen_size_mm,best_can_do=@best_can_do,for_approval_yes=@for_approval_yes,for_color_yes=@for_color_yes,
                for_bulk_ref_yes=@for_bulk_ref_yes,sub_submit1=@sub_submit1,sub_submit2=@sub_submit2,sub_urgent=@sub_urgent,status_approved=@status_approved,
                status_correct=@status_correct,status_resubmit=@status_resubmit,status_cancelled=@status_cancelled,trim_review_yes=@trim_review_yes,
                trim_review_no=@trim_review_no,depth_lighter=@depth_lighter,depth_deeper=@depth_deeper,chroma_brighter=@chroma_brighter,chroma_duller=@chroma_duller,
                hue_yellower=@hue_yellower,hue_redder=@hue_redder,hue_bluer=@hue_bluer,hue_greener=@hue_greener,mo_id1=@mo_id1,mo_id2=@mo_id2,mo_id3=@mo_id3,
                update_by=@user_id,update_date=getdate()
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
                        strSerial_no = clsTommyTest.GetSeqNo("development_us_pvh", "serial_no");//生成序唯一的列號
                        txtreference_number.Text = clsDevelopentPvh.GetPvhNoForUs(strSerial_no);
                        myCommand.Parameters.AddWithValue("@serial_no", strSerial_no);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@serial_no", txtSerial_no.Text);
                        strSerial_no = txtSerial_no.Text;
                    }
                    myCommand.Parameters.AddWithValue("@raw_material_country", lueRaw_material_country.EditValue);
                    myCommand.Parameters.AddWithValue("@production_country", txtProduction_country.Text);
                    myCommand.Parameters.AddWithValue("@reference_number", txtreference_number.Text);
                    myCommand.Parameters.AddWithValue("@doc_date", clsApp.Return_String_Date(txtdoc_date.Text));
                    myCommand.Parameters.AddWithValue("@supplier_name", txtsupplier_name.Text);
                    myCommand.Parameters.AddWithValue("@factory_name", txtFactory_name.Text);                   
                    myCommand.Parameters.AddWithValue("@plm_material_code", txtPlm_material_code.Text);
                    myCommand.Parameters.AddWithValue("@season", txtSeason.Text);
                    myCommand.Parameters.AddWithValue("@requested_by", txtRequested_by.Text);                   
                    myCommand.Parameters.AddWithValue("@sample_submis_date", clsApp.Return_String_Date(dtSample_submis_date.Text));
                    myCommand.Parameters.AddWithValue("@delivery_date", clsApp.Return_String_Date(dtDelivery_date.Text));
                    myCommand.Parameters.AddWithValue("@division_mens", chkdivision_mens.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_womens", chkdivision_womens.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_boys", chkdivision_boys.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_girls", chkdivision_girls.Checked ? true : false);

                    myCommand.Parameters.AddWithValue("@division_branding", chkdivision_branding.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_swim", chkdivision_swim.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_denim", chkdivision_denim.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_th_accy", chkdivision_th_accy.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_tommy_jeans", chkdivision_tommy_jeans.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_specialty", chkdivision_specialty.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_adaptive", chkdivision_adaptive.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@division_mercedez_benz", chkdivision_mercedez_benz.Checked ? true : false);

                    //
                    myCommand.Parameters.AddWithValue("@trim_flat_price", clsApp.Return_Float_Value_4(txtTrim_flat_price.Text));
                    myCommand.Parameters.AddWithValue("@trim_1k", clsApp.Return_Float_Value_4(txttrim_1k.Text));
                    myCommand.Parameters.AddWithValue("@trim_1k_3k", clsApp.Return_Float_Value_4(txttrim_1k_3k.Text));
                    myCommand.Parameters.AddWithValue("@trim_3k_5k", clsApp.Return_Float_Value_4(txttrim_3k_5k.Text));
                    myCommand.Parameters.AddWithValue("@moq", txtMoq.Text);
                    myCommand.Parameters.AddWithValue("@surcharge", txtSurcharge.Text);
                    myCommand.Parameters.AddWithValue("@srs_leadtime", txtsrs_leadtime.Text);
                    myCommand.Parameters.AddWithValue("@bulk_leadtime", txtbulk_leadtime.Text);
                    myCommand.Parameters.AddWithValue("@material_per1", clsApp.Return_Float_Value(txtmaterial_per1.Text));
                    myCommand.Parameters.AddWithValue("@material_content1", luematerial_content1.EditValue);
                    myCommand.Parameters.AddWithValue("@material_per2", clsApp.Return_Float_Value(txtmaterial_per2.Text));
                    myCommand.Parameters.AddWithValue("@material_content2", luematerial_content2.EditValue);
                    myCommand.Parameters.AddWithValue("@material_per3", clsApp.Return_Float_Value(txtmaterial_per3.Text));
                    myCommand.Parameters.AddWithValue("@material_content3", luematerial_content3.EditValue);
                    myCommand.Parameters.AddWithValue("@material_per4", clsApp.Return_Float_Value(txtmaterial_per4.Text));
                    myCommand.Parameters.AddWithValue("@material_content4", luematerial_content4.EditValue);
                    myCommand.Parameters.AddWithValue("@material_other", txtmaterial_other.Text);
                    myCommand.Parameters.AddWithValue("@weight", txtweight.Text);
                    myCommand.Parameters.AddWithValue("@thcikness", txtthcikness.Text);
                    myCommand.Parameters.AddWithValue("@trim_conform_yes", chktrim_conform_yes.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@trim_conform_no", chktrim_conform_no.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@conformity_of_test", txtconformity_of_test.Text);
                    //
                    myCommand.Parameters.AddWithValue("@trim_comply_yes", chktrim_comply_yes.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@trim_comply_no", chktrim_comply_no.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@tick_box_oekotex", chktick_box_oekotex.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@tick_box_bluesign", chktick_box_bluesign.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@tick_box_party_testing", chktick_box_party_testing.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@oekotex_class1", chkoekotex_class1.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@oekotex_class2", chkoekotex_class2.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@bluesign_cert", txtbluesign_cert.Text);
                    //
                    myCommand.Parameters.AddWithValue("@sus_grs", chksus_grs.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sus_pcs", chksus_pcs.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sus_gots", chksus_gots.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sus_fsc", chksus_fsc.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sus_lwg", chksus_lwg.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sus_other", chksus_other.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@certificate_number", txtcertificate_number.Text);
                    //
                    myCommand.Parameters.AddWithValue("@sug_machine_wash", chksug_machine_wash.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_hand_wash_only", chksug_hand_wash_only.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_do_not_dryclean", chksug_do_not_dryclean.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_dryclean_only", chksug_dryclean_only.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_swimwear", chksug_swimwear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_childrenwear", chksug_childrenwear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_pass_needle", chksug_pass_needle.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sug_turn_inside_out", chksug_turn_inside_out.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@mo_id1", txtMo_id1.Text);
                    myCommand.Parameters.AddWithValue("@mo_id2", txtMo_id2.Text);
                    myCommand.Parameters.AddWithValue("@mo_id3", txtMo_id3.Text);
                    myCommand.Parameters.AddWithValue("@quality_callouts", txtQuality_callouts.Text);
                    //-----------------------------------------------------------------------------------    
                    myCommand.Parameters.AddWithValue("@color_name", txtcolor_name.Text);
                    myCommand.Parameters.AddWithValue("@color_code", txtcolor_code.Text);
                    myCommand.Parameters.AddWithValue("@color_archroma", chkcolor_archroma.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@color_pantone", chkcolor_pantone.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@color_csi", chkcolor_csi.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@color_th_stand", chkcolor_th_stand.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@color_supplier", chkcolor_supplier.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dimen_size_inch", chkdimen_size_inch.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dimen_size_mm", chkdimen_size_mm.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@best_can_do", chkbest_can_do.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@for_approval_yes", chkfor_approval_yes.Checked ? true : false);
                    //
                    myCommand.Parameters.AddWithValue("@for_color_yes", chkfor_color_yes.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@for_bulk_ref_yes", chkfor_bulk_ref_yes.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sub_submit1", chksub_submit1.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sub_submit2", chksub_submit2.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@sub_urgent", chksub_urgent.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@status_approved", chkstatus_approved.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@status_correct", chkstatus_correct.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@status_resubmit", chkstatus_resubmit.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@status_cancelled", chkstatus_cancelled.Checked ? true : false);
                    //-----------------------------------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@trim_review_yes", chktrim_review_yes.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@trim_review_no", chktrim_review_no.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@depth_lighter", chkdepth_lighter.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@depth_deeper", chkdepth_deeper.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@chroma_brighter", chkchroma_brighter.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@chroma_duller", chkchroma_duller.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@hue_yellower", chkhue_yellower.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@hue_redder", chkhue_redder.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@hue_bluer", chkhue_bluer.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@hue_greener", chkhue_greener.Checked ? true : false);                                        
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
                dgvDetails.Enabled = true;
                //新增狀態下定位到新增的行
                if (mState == "NEW")
                {
                    int cur_row_index = dgvDetails.RowCount - 1;
                    dgvDetails.CurrentCell = dgvDetails.Rows[cur_row_index].Cells[2]; //设置当前单元格
                    dgvDetails.Rows[cur_row_index].Selected = true; //選中整行
                }
                mState = "";              
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
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtSerial_no.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM dbo.development_us_pvh WHERE serial_no=@serial_no";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@serial_no", txtSerial_no.Text);
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
            if (txtSerial_no.Text == "")
            {
                return;
            }
            tabControl1.SelectTab(0);
            mState = "EDIT";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            dgvDetails.Enabled = false;
            txtSerial_no.Properties.ReadOnly = true;
            txtSerial_no.BackColor = Color.White;
            txtreference_number.Properties.ReadOnly = true;
            txtreference_number.BackColor = Color.White;
        }

        private void frmDevelopmentPvhUs_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           objToolbar = null;
           clsApp = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            dtDetail.RejectChanges();//取消數據更改
            bds1.CancelEdit();//取消數據綁定
            
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            //SetObjValue.ClearObjValue(panel1.Controls, "1");
            mState = "";
           
            txtSerial_no.Properties.ReadOnly = true;
            txtreference_number.Properties.ReadOnly = true;
            dgvDetails.Enabled = true;
            if (!string.IsNullOrEmpty(mID) && dgvDetails.RowCount > 0)
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
            string sql = @"SELECT * FROM development_us_pvh with(nolock) WHERE 1=1 ";
            if (txtId1.Text != "" || txtId2.Text != "" || dtDoc_date1.Text != "" || dtDoc_date2.Text != "" || txtreference_number1.Text !="" ||txtreference_number2.Text!="")
            {             
                if (txtId1.Text != "")
                {
                    sql = sql + string.Format(" and serial_no>='{0}'", txtId1.Text);
                }
                if (txtId2.Text != "")
                {
                    sql = sql + string.Format(" and serial_no<='{0}'", txtId2.Text);
                }
                if (txtreference_number1.Text != "")
                {
                    sql = sql + string.Format(" and pvh_submit_ref>='{0}'", txtreference_number1.Text);
                }
                if (txtreference_number2.Text != "")
                {
                    sql = sql + string.Format(" and pvh_submit_ref<='{0}'", txtreference_number2.Text);
                }
                if (dtDoc_date1.Text != "")
                {
                    sql = sql + string.Format(" and doc_date>='{0}'", clsApp.Return_String_Date(dtDoc_date1.Text));
                }
                if (dtDoc_date2.Text != "")
                {
                    sql = sql + string.Format(" and doc_date<='{0}'", clsApp.Return_String_Date(dtDoc_date2.Text));
                }
                if (txtMo1.Text != "")
                {
                    sql = sql + string.Format(" and mo_id1='{0}'", txtMo1.Text);
                }
                if (txtMo2.Text != "")
                {
                    sql = sql + string.Format(" and mo_id2='{0}'", txtMo2.Text);
                }
                if (txtMo3.Text != "")
                {
                    sql = sql + string.Format(" and mo_id3='{0}'", txtMo3.Text);
                }
            }           
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;
            dgvFind.DataSource = dtDetail;
            //if(dtDetail.Rows.Count>0)
            //{
            //    tabControl1.SelectTab(0);
            //}
        }
     
        private void txtprice1_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txttrim_1k);
        }

        private void txtprice2_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txttrim_1k_3k);
        }

        private void txtprice3_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txttrim_3k_5k);
        }
        
        private static void Set_Number_Focus(DevExpress.XtraEditors.TextEdit objTextEdit)
        {
            if (objTextEdit.Text == "0.0000")
            {
                objTextEdit.Select(1, 0);
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
            dgvrow = dgvDetails.CurrentRow;
            if(dgvrow!=null)
            {
                row_reset = dgvDetails.CurrentCell.RowIndex;
                SetCheckBoxStatus(dgvrow);
            }            
        }

        private void SetNewCopyData(DataGridViewRow pdr)
        {
            lueRaw_material_country.EditValue = pdr.Cells["raw_material_country"].Value.ToString();
            txtProduction_country.Text = pdr.Cells["production_country"].Value.ToString();
            txtdoc_date.EditValue = pdr.Cells["doc_date"].Value.ToString();
            txtsupplier_name.Text = pdr.Cells["supplier_name"].Value.ToString();
            txtFactory_name.Text = pdr.Cells["factory_name"].Value.ToString();
            txtPlm_material_code.Text = pdr.Cells["plm_material_code"].Value.ToString();
            txtSeason.EditValue = pdr.Cells["season"].Value.ToString();            
            txtRequested_by.Text = pdr.Cells["requested_by"].Value.ToString();
            dtSample_submis_date.EditValue= pdr.Cells["sample_submis_date"].Value.ToString();
            dtDelivery_date.EditValue = pdr.Cells["delivery_date"].Value.ToString();
            //------------------------------------------------------------------------
            txtTrim_flat_price.Text = pdr.Cells["trim_flat_price"].Value.ToString();
            txttrim_1k.Text = pdr.Cells["trim_1k"].Value.ToString();
            txttrim_1k_3k.Text = pdr.Cells["trim_1k_3k"].Value.ToString();
            txttrim_3k_5k.Text = pdr.Cells["trim_3k_5k"].Value.ToString();
            txtMoq.Text = pdr.Cells["moq"].Value.ToString();
            txtSurcharge.Text = pdr.Cells["surcharge"].Value.ToString();
            txtsrs_leadtime.Text = pdr.Cells["srs_leadtime"].Value.ToString();
            txtbulk_leadtime.Text = pdr.Cells["bulk_leadtime"].Value.ToString();

            txtmaterial_per1.Text = pdr.Cells["material_per1"].Value.ToString();
            luematerial_content1.EditValue = pdr.Cells["material_content1"].Value.ToString();
            txtmaterial_per2.Text = pdr.Cells["material_per2"].Value.ToString();
            luematerial_content2.EditValue = pdr.Cells["material_content2"].Value.ToString();
            txtmaterial_per3.Text = pdr.Cells["material_per3"].Value.ToString();
            luematerial_content3.EditValue = pdr.Cells["material_content3"].Value.ToString();
            txtmaterial_per4.Text = pdr.Cells["material_per4"].Value.ToString();
            luematerial_content4.EditValue = pdr.Cells["material_content4"].Value.ToString();
            txtmaterial_other.Text = pdr.Cells["material_other"].Value.ToString();
            txtweight.Text = pdr.Cells["weight"].Value.ToString();
            txtthcikness.Text = pdr.Cells["thcikness"].Value.ToString();
            txtconformity_of_test.Text = pdr.Cells["conformity_of_test"].Value.ToString();
            txtbluesign_cert.Text = pdr.Cells["bluesign_cert"].Value.ToString();
            txtcertificate_number.Text= pdr.Cells["certificate_number"].Value.ToString();
            txtMo_id1.Text = pdr.Cells["mo_id1"].Value.ToString();
            txtMo_id2.Text = pdr.Cells["mo_id2"].Value.ToString();
            txtMo_id3.Text = pdr.Cells["mo_id3"].Value.ToString();
            txtQuality_callouts.Text = pdr.Cells["quality_callouts"].Value.ToString();
            txtcolor_name.Text = pdr.Cells["color_name"].Value.ToString();
            txtcolor_code.Text = pdr.Cells["color_code"].Value.ToString();
            SetCheckBoxStatus(pdr);//設置 CheckBox狀態
        }
        
        private void SetCheckBoxStatus(DataGridViewRow pdr)
        { 
            SetCheckBoxs(chkdivision_mens, pdr.Cells["division_mens"].Value.ToString());
            SetCheckBoxs(chkdivision_womens, pdr.Cells["division_womens"].Value.ToString());
            SetCheckBoxs(chkdivision_boys, pdr.Cells["division_boys"].Value.ToString());
            SetCheckBoxs(chkdivision_girls, pdr.Cells["division_girls"].Value.ToString());
            SetCheckBoxs(chkdivision_branding, pdr.Cells["division_branding"].Value.ToString());
            SetCheckBoxs(chkdivision_swim, pdr.Cells["division_swim"].Value.ToString());
            SetCheckBoxs(chkdivision_denim, pdr.Cells["division_denim"].Value.ToString());
            SetCheckBoxs(chkdivision_th_accy, pdr.Cells["division_th_accy"].Value.ToString());
            SetCheckBoxs(chkdivision_tommy_jeans, pdr.Cells["division_tommy_jeans"].Value.ToString());
            SetCheckBoxs(chkdivision_specialty, pdr.Cells["division_specialty"].Value.ToString());
            SetCheckBoxs(chkdivision_mercedez_benz, pdr.Cells["division_mercedez_benz"].Value.ToString());

            SetCheckBoxs(chktrim_conform_yes, pdr.Cells["trim_conform_yes"].Value.ToString());
            SetCheckBoxs(chktrim_conform_no, pdr.Cells["trim_conform_no"].Value.ToString());
            SetCheckBoxs(chktrim_comply_yes, pdr.Cells["trim_comply_yes"].Value.ToString());
            SetCheckBoxs(chktrim_comply_no, pdr.Cells["trim_comply_no"].Value.ToString());

            SetCheckBoxs(chktick_box_oekotex, pdr.Cells["tick_box_oekotex"].Value.ToString());
            SetCheckBoxs(chktick_box_bluesign, pdr.Cells["tick_box_bluesign"].Value.ToString());
            SetCheckBoxs(chktick_box_party_testing, pdr.Cells["tick_box_party_testing"].Value.ToString());

            SetCheckBoxs(chkoekotex_class1, pdr.Cells["oekotex_class1"].Value.ToString());
            SetCheckBoxs(chkoekotex_class2, pdr.Cells["oekotex_class2"].Value.ToString());

            SetCheckBoxs(chksus_grs, pdr.Cells["sus_grs"].Value.ToString());
            SetCheckBoxs(chksus_pcs, pdr.Cells["sus_pcs"].Value.ToString());
            SetCheckBoxs(chksus_gots, pdr.Cells["sus_gots"].Value.ToString());
            SetCheckBoxs(chksus_fsc, pdr.Cells["sus_fsc"].Value.ToString());
            SetCheckBoxs(chksus_lwg, pdr.Cells["sus_lwg"].Value.ToString());
            SetCheckBoxs(chksus_other, pdr.Cells["sus_other"].Value.ToString());         
            

            SetCheckBoxs(chksug_machine_wash, pdr.Cells["sug_machine_wash"].Value.ToString());
            SetCheckBoxs(chksug_hand_wash_only, pdr.Cells["sug_hand_wash_only"].Value.ToString());
            SetCheckBoxs(chksug_do_not_dryclean, pdr.Cells["sug_do_not_dryclean"].Value.ToString());
            SetCheckBoxs(chksug_dryclean_only, pdr.Cells["sug_dryclean_only"].Value.ToString());
            SetCheckBoxs(chksug_swimwear, pdr.Cells["sug_swimwear"].Value.ToString());
            SetCheckBoxs(chksug_childrenwear, pdr.Cells["sug_childrenwear"].Value.ToString());
            SetCheckBoxs(chksug_pass_needle, pdr.Cells["sug_pass_needle"].Value.ToString());
            SetCheckBoxs(chksug_turn_inside_out, pdr.Cells["sug_turn_inside_out"].Value.ToString());

            SetCheckBoxs(chkcolor_archroma, pdr.Cells["color_archroma"].Value.ToString());
            SetCheckBoxs(chkcolor_pantone, pdr.Cells["color_pantone"].Value.ToString());
            SetCheckBoxs(chkcolor_csi, pdr.Cells["color_csi"].Value.ToString());
            SetCheckBoxs(chkcolor_th_stand, pdr.Cells["color_th_stand"].Value.ToString());
            SetCheckBoxs(chkcolor_supplier, pdr.Cells["color_supplier"].Value.ToString());
            SetCheckBoxs(chkdimen_size_inch, pdr.Cells["dimen_size_inch"].Value.ToString());
            SetCheckBoxs(chkdimen_size_mm, pdr.Cells["dimen_size_mm"].Value.ToString());
            SetCheckBoxs(chkbest_can_do, pdr.Cells["best_can_do"].Value.ToString());
            SetCheckBoxs(chkfor_approval_yes, pdr.Cells["for_approval_yes"].Value.ToString());
            SetCheckBoxs(chkfor_color_yes, pdr.Cells["for_color_yes"].Value.ToString());
            SetCheckBoxs(chkfor_bulk_ref_yes, pdr.Cells["for_bulk_ref_yes"].Value.ToString());

            SetCheckBoxs(chksub_submit1, pdr.Cells["sub_submit1"].Value.ToString());
            SetCheckBoxs(chksub_submit2, pdr.Cells["sub_submit2"].Value.ToString());
            SetCheckBoxs(chksub_submit2, pdr.Cells["sub_urgent"].Value.ToString());
            SetCheckBoxs(chkstatus_approved, pdr.Cells["status_approved"].Value.ToString());
            SetCheckBoxs(chkstatus_correct, pdr.Cells["status_correct"].Value.ToString());
            SetCheckBoxs(chkstatus_resubmit, pdr.Cells["status_resubmit"].Value.ToString());
            SetCheckBoxs(chkstatus_cancelled, pdr.Cells["status_cancelled"].Value.ToString());
            SetCheckBoxs(chktrim_review_yes, pdr.Cells["trim_review_yes"].Value.ToString());
            SetCheckBoxs(chktrim_review_no, pdr.Cells["trim_review_no"].Value.ToString());

            SetCheckBoxs(chkdepth_lighter, pdr.Cells["depth_lighter"].Value.ToString());
            SetCheckBoxs(chkdepth_deeper, pdr.Cells["depth_deeper"].Value.ToString());
            SetCheckBoxs(chkchroma_brighter, pdr.Cells["chroma_brighter"].Value.ToString());
            SetCheckBoxs(chkchroma_duller, pdr.Cells["chroma_duller"].Value.ToString());
            SetCheckBoxs(chkhue_yellower, pdr.Cells["hue_yellower"].Value.ToString());
            SetCheckBoxs(chkhue_redder, pdr.Cells["hue_redder"].Value.ToString());
            SetCheckBoxs(chkhue_bluer, pdr.Cells["hue_bluer"].Value.ToString());
            SetCheckBoxs(chkhue_greener, pdr.Cells["hue_greener"].Value.ToString());
        }
        private void SetCheckBoxs(CheckEdit obj,string strValue)
        {
            obj.Checked = (string.IsNullOrEmpty(strValue) || strValue == "False") ? false : true;
        }
        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDoc_date2.EditValue = dtDoc_date1.EditValue;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount ==0)
            {
                MessageBox.Show("沒有要列印的數據！","提示信息");
                return;
            }
            string strsql = string.Format(@"Select * FROM dbo.development_us_pvh WHERE serial_no='{0}'", txtSerial_no.Text);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(strsql);
            using (xrDevelopmentPvhUs rpt = new xrDevelopmentPvhUs() { DataSource = dtReport })
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
                DataGridViewRow current_row = dgvDetails.CurrentRow;
                AddNew();
                SetNewCopyData(current_row);
                txtdoc_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                string max_serial_no = clsTommyTest.GetSeqNo("development_us_pvh", "serial_no");
                txtSerial_no.Text = max_serial_no;
                txtreference_number.Text = clsDevelopentPvh.GetPvhNoForUs(txtSerial_no.Text);
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }
            tabControl1.SelectedIndex = 0;
            int index = dgvFind.CurrentRow.Index;
            if (index >= 0)
            {
                dgvDetails.ClearSelection();
                dgvDetails.Rows[index].Selected = true;
                dgvDetails.CurrentCell = dgvDetails.Rows[index].Cells[1];
            }
        }

        //private void chksubmit1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    SetSubmitValue(chktrim_review_yes, "submit1");
        //}

        //private void chksubmit2_MouseUp(object sender, MouseEventArgs e)
        //{
        //    SetSubmitValue(chktrim_review_no, "submit2");
        //}

        //private void chksubmit3_MouseUp(object sender, MouseEventArgs e)
        //{
        //    SetSubmitValue(chkchroma_brighter, "submit3");
        //}

        //private void chkurgent_bulk_order_MouseUp(object sender, MouseEventArgs e)
        //{
        //    SetSubmitValue(chkchroma_duller, "urgent_bulk_order");
        //}

        //private void SetSubmitValue(DevExpress.XtraEditors.CheckEdit obj,string SubmitName)
        //{
        //    int current_index = dgvDetails.CurrentRow.Index;
        //    if (obj.Checked)
        //    {
        //        dgvDetails.CurrentRow.Cells[SubmitName].Value = true;
        //    }
        //    else
        //    {
        //        dgvDetails.CurrentRow.Cells[SubmitName].Value = false;
        //    }
        //}

        private void txtreference_number1_Leave(object sender, EventArgs e)
        {
            txtreference_number2.Text = txtreference_number1.Text;
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }            
            int index = dgvFind.CurrentRow.Index;
            if (index >= 0)
            {
                dgvDetails.ClearSelection();
                dgvDetails.Rows[index].Selected = true;
                dgvDetails.CurrentCell = dgvDetails.Rows[index].Cells[1];
            }
        }
        
        private void lueCheck_EditValueChanged(object sender, EventArgs e)
        {
            string strVul = lueCheck.EditValue.ToString();
            if (!string.IsNullOrEmpty(strVul))
            {
                DataTable dt = clsDevelopentPvh.GetProcessTypeInfo(strVul);
                if (dt.Rows.Count > 0)
                {
                    txtQuality_callouts.Text = dt.Rows[0]["contents"].ToString();
                }
            }
        }

        private void lueRaw_material_country_EditValueChanged(object sender, EventArgs e)
        {
            if (lueRaw_material_country.Text != "")
            {
                txtProduction_country.Text = lueRaw_material_country.GetColumnValue("country").ToString();
            }
        }

        private void txtTrim_flat_price_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txttrim_1k);
        }
    }
}
