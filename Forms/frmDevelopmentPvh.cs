/*
 * Create by :   Allen Leung 
 * Create Date : 2021-12-04
 * remark:
 * HK E組 PVH 牌子辦卡
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
    public partial class frmDevelopmentPvh : Form
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
        string strTip = "編輯狀態雙擊鼠標左鍵清除此欄內容.";       

        public frmDevelopmentPvh()
        {
            InitializeComponent();

            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();

            const string sql = @"SELECT * FROM development_pvh With(nolock) WHERE 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql); 
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;// dtDetail;
        }

        private void frmDevelopmentPvh_Load(object sender, EventArgs e)
        {            
            //Load_Date();           
            //clsDevelopentPvh.SetDropBox(lueDivision, "divisions");
            clsDevelopentPvh.SetDropBox(lueHandling_office, "hand_office");
            clsDevelopentPvh.SetDropBox(lueMaterial_subtype, "material_subtype");
            clsDevelopentPvh.SetDropBox(lueSample_type, "sample_type"); 
            clsDevelopentPvh.SetDropBox(lueRsl_certificate_type, "rsl_compliance");            
            clsDevelopentPvh.SetDropBox(luePrevious_submit_vr, "vr_status");
           

            string strSql = "";
            string strGroup = "V,E";
            if (user_group == "W")
            {
                user_group = "E";
            }
            if (strGroup.Contains(user_group))
                strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' AND sales_group='{1}' ORDER BY sort", "divisions", user_group);
            else            
                strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "divisions");            
            DataTable dtDivision = clsPublicOfCF01.GetDataTable(strSql);
            lueDivision.Properties.DataSource = dtDivision;
            lueDivision.Properties.ValueMember = "id";
            lueDivision.Properties.DisplayMember = "id";
            strSql = string.Format(@"SELECT contents AS id,remark AS name1,remark2 AS name2 FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "compositions");
            DataTable dtComposition = clsPublicOfCF01.GetDataTable(strSql);
            lueRaw_mat1_compostion.Properties.DataSource = dtComposition;
            lueRaw_mat1_compostion.Properties.ValueMember = "id";
            lueRaw_mat1_compostion.Properties.DisplayMember = "id";
            lueRaw_mat2_compostion.Properties.DataSource = dtComposition;
            lueRaw_mat2_compostion.Properties.ValueMember = "id";
            lueRaw_mat2_compostion.Properties.DisplayMember = "id";
            lueRaw_mat3_compostion.Properties.DataSource = dtComposition;
            lueRaw_mat3_compostion.Properties.ValueMember = "id";
            lueRaw_mat3_compostion.Properties.DisplayMember = "id";
            lueRaw_mat4_compostion.Properties.DataSource = dtComposition;
            lueRaw_mat4_compostion.Properties.ValueMember = "id";
            lueRaw_mat4_compostion.Properties.DisplayMember = "id";
            lueRaw_mat5_compostion.Properties.DataSource = dtComposition;
            lueRaw_mat5_compostion.Properties.ValueMember = "id";
            lueRaw_mat5_compostion.Properties.DisplayMember = "id";

            strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "country_name");
            DataTable dtCountry = clsPublicOfCF01.GetDataTable(strSql);
            lueRaw_mat1_l3.Properties.DataSource = dtCountry;
            lueRaw_mat1_l3.Properties.ValueMember = "id";
            lueRaw_mat1_l3.Properties.DisplayMember = "id";
            lueRaw_mat1_l4.Properties.DataSource = dtCountry;
            lueRaw_mat1_l4.Properties.ValueMember = "id";
            lueRaw_mat1_l4.Properties.DisplayMember = "id";
            lueRaw_mat1_l5.Properties.DataSource = dtCountry;
            lueRaw_mat1_l5.Properties.ValueMember = "id";
            lueRaw_mat1_l5.Properties.DisplayMember = "id";

            lueRaw_mat2_l3.Properties.DataSource = dtCountry;
            lueRaw_mat2_l3.Properties.ValueMember = "id";
            lueRaw_mat2_l3.Properties.DisplayMember = "id";
            lueRaw_mat2_l4.Properties.DataSource = dtCountry;
            lueRaw_mat2_l4.Properties.ValueMember = "id";
            lueRaw_mat2_l4.Properties.DisplayMember = "id";
            lueRaw_mat2_l5.Properties.DataSource = dtCountry;
            lueRaw_mat2_l5.Properties.ValueMember = "id";
            lueRaw_mat2_l5.Properties.DisplayMember = "id";

            lueRaw_mat3_l3.Properties.DataSource = dtCountry;
            lueRaw_mat3_l3.Properties.ValueMember = "id";
            lueRaw_mat3_l3.Properties.DisplayMember = "id";
            lueRaw_mat3_l4.Properties.DataSource = dtCountry;
            lueRaw_mat3_l4.Properties.ValueMember = "id";
            lueRaw_mat3_l4.Properties.DisplayMember = "id";
            lueRaw_mat3_l5.Properties.DataSource = dtCountry;
            lueRaw_mat3_l5.Properties.ValueMember = "id";
            lueRaw_mat3_l5.Properties.DisplayMember = "id";

            lueRaw_mat4_l3.Properties.DataSource = dtCountry;
            lueRaw_mat4_l3.Properties.ValueMember = "id";
            lueRaw_mat4_l3.Properties.DisplayMember = "id";
            lueRaw_mat4_l4.Properties.DataSource = dtCountry;
            lueRaw_mat4_l4.Properties.ValueMember = "id";
            lueRaw_mat4_l4.Properties.DisplayMember = "id";
            lueRaw_mat4_l5.Properties.DataSource = dtCountry;
            lueRaw_mat4_l5.Properties.ValueMember = "id";
            lueRaw_mat4_l5.Properties.DisplayMember = "id";

            lueRaw_mat5_l3.Properties.DataSource = dtCountry;
            lueRaw_mat5_l3.Properties.ValueMember = "id";
            lueRaw_mat5_l3.Properties.DisplayMember = "id";
            lueRaw_mat5_l4.Properties.DataSource = dtCountry;
            lueRaw_mat5_l4.Properties.ValueMember = "id";
            lueRaw_mat5_l4.Properties.DisplayMember = "id";
            lueRaw_mat5_l5.Properties.DataSource = dtCountry;
            lueRaw_mat5_l5.Properties.ValueMember = "id";
            lueRaw_mat5_l5.Properties.DisplayMember = "id";

            strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "price_unit");
            DataTable dtPriceUnit = clsPublicOfCF01.GetDataTable(strSql);
            luePrice1_unit.Properties.DataSource = dtPriceUnit;
            luePrice1_unit.Properties.ValueMember = "id";
            luePrice1_unit.Properties.DisplayMember = "id";
            luePrice2_unit.Properties.DataSource = dtPriceUnit;
            luePrice2_unit.Properties.ValueMember = "id";
            luePrice2_unit.Properties.DisplayMember = "id";
            luePrice3_unit.Properties.DataSource = dtPriceUnit;
            luePrice3_unit.Properties.ValueMember = "id";
            luePrice3_unit.Properties.DisplayMember = "id";
            luePrice4_unit.Properties.DataSource = dtPriceUnit;
            luePrice4_unit.Properties.ValueMember = "id";
            luePrice4_unit.Properties.DisplayMember = "id";
            luePrice5_unit.Properties.DataSource = dtPriceUnit;
            luePrice5_unit.Properties.ValueMember = "id";
            luePrice5_unit.Properties.DisplayMember = "id";
            luePrice6_unit.Properties.DataSource = dtPriceUnit;
            luePrice6_unit.Properties.ValueMember = "id";
            luePrice6_unit.Properties.DisplayMember = "id";
            clsDevelopentPvh.SetDropBox(lueCurrency, "currency");

            strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "material_finish"); 
            DataTable dtMatFinish = clsPublicOfCF01.GetDataTable(strSql);
            lueCert1_mat_finish.Properties.DataSource = dtMatFinish;
            lueCert1_mat_finish.Properties.ValueMember = "id";
            lueCert1_mat_finish.Properties.DisplayMember = "id";
            lueCert2_mat_finish.Properties.DataSource = dtMatFinish;
            lueCert2_mat_finish.Properties.ValueMember = "id";
            lueCert2_mat_finish.Properties.DisplayMember = "id";
            lueCert3_mat_finish.Properties.DataSource = dtMatFinish;
            lueCert3_mat_finish.Properties.ValueMember = "id";
            lueCert3_mat_finish.Properties.DisplayMember = "id";
            lueCert4_mat_finish.Properties.DataSource = dtMatFinish;
            lueCert4_mat_finish.Properties.ValueMember = "id";
            lueCert4_mat_finish.Properties.DisplayMember = "id";

            strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "certificate_type");
            DataTable dtCertificate = clsPublicOfCF01.GetDataTable(strSql);
            lueCert1_type.Properties.DataSource = dtCertificate;
            lueCert1_type.Properties.ValueMember = "id";
            lueCert1_type.Properties.DisplayMember = "id";
            lueCert2_type.Properties.DataSource = dtCertificate;
            lueCert2_type.Properties.ValueMember = "id";
            lueCert2_type.Properties.DisplayMember = "id";
            lueCert3_type.Properties.DataSource = dtCertificate;
            lueCert3_type.Properties.ValueMember = "id";
            lueCert3_type.Properties.DisplayMember = "id";
            lueCert4_type.Properties.DataSource = dtCertificate;
            lueCert4_type.Properties.ValueMember = "id";
            lueCert4_type.Properties.DisplayMember = "id";

            strSql = string.Format(@"SELECT contents AS id FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "yes_no");
            DataTable dtYes = clsPublicOfCF01.GetDataTable(strSql);           
            lueMachine_washable.Properties.DataSource = dtYes;
            lueMachine_washable.Properties.ValueMember = "id";
            lueMachine_washable.Properties.DisplayMember = "id";

            lueDry_cleanable.Properties.DataSource = dtYes;
            lueDry_cleanable.Properties.ValueMember = "id";
            lueDry_cleanable.Properties.DisplayMember = "id";

            lueDry_clean_only.Properties.DataSource = dtYes;
            lueDry_clean_only.Properties.ValueMember = "id";
            lueDry_clean_only.Properties.DisplayMember = "id";

            lueDo_not_dry_clean.Properties.DataSource = dtYes;
            lueDo_not_dry_clean.Properties.ValueMember = "id";
            lueDo_not_dry_clean.Properties.DisplayMember = "id";

            lueSuitable_for_tumble_dry.Properties.DataSource = dtYes;
            lueSuitable_for_tumble_dry.Properties.ValueMember = "id";
            lueSuitable_for_tumble_dry.Properties.DisplayMember = "id";

            lueSuitable_for_swimwear.Properties.DataSource = dtYes;
            lueSuitable_for_swimwear.Properties.ValueMember = "id";
            lueSuitable_for_swimwear.Properties.DisplayMember = "id";

            luePasses_metal_detection.Properties.DataSource = dtYes;
            luePasses_metal_detection.Properties.ValueMember = "id";
            luePasses_metal_detection.Properties.DisplayMember = "id";

            lueComplies_with_pvh.Properties.DataSource = dtYes;
            lueComplies_with_pvh.Properties.ValueMember = "id";
            lueComplies_with_pvh.Properties.DisplayMember = "id";

            lueComplies_with_cfr.Properties.DataSource = dtYes;
            lueComplies_with_cfr.Properties.ValueMember = "id";
            lueComplies_with_cfr.Properties.DisplayMember = "id";

            lueObj_fbx.Properties.DataSource = dtYes;
            lueObj_fbx.Properties.ValueMember = "id";
            lueObj_fbx.Properties.DisplayMember = "id";

            lueU3ma.Properties.DataSource = dtYes;
            lueU3ma.Properties.ValueMember = "id";
            lueU3ma.Properties.DisplayMember = "id";

            lueFor_bulk_feference.Properties.DataSource = dtYes;
            lueFor_bulk_feference.Properties.ValueMember = "id";
            lueFor_bulk_feference.Properties.DisplayMember = "id";

            lueFor_quality_approval.Properties.DataSource = dtYes;
            lueFor_quality_approval.Properties.ValueMember = "id";
            lueFor_quality_approval.Properties.DisplayMember = "id";

            lueColor_already_approved.Properties.DataSource = dtYes;
            lueColor_already_approved.Properties.ValueMember = "id";
            lueColor_already_approved.Properties.DisplayMember = "id";

            lueSize_already_approved.Properties.DataSource = dtYes;
            lueSize_already_approved.Properties.ValueMember = "id";
            lueSize_already_approved.Properties.DisplayMember = "id";

            strSql = string.Format(@"SELECT contents AS id,remark AS name FROM development_pvh_type WHERE type='{0}' ORDER BY sort", "z_combox_check");
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            lueCheck.Properties.DataSource = dt;
            lueCheck.Properties.ValueMember = "id";
            lueCheck.Properties.DisplayMember = "name";


            dtDat1.EditValue = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd").Substring(0, 10);
            dtDat2.EditValue = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 10);            

            //數據綁定
            SetDataBindings();

            txtFinish.ToolTip = strTip;
            txtProcess.ToolTip = strTip;
            txtDye_type.ToolTip = strTip;
            txtDye_method.ToolTip = strTip;
        }

        private void SetDataBindings()
        {
            txtSerial_no.DataBindings.Add("Text", bds1, "Serial_no");
            lueDivision.DataBindings.Add("EditValue", bds1, "division");
            lueHandling_office.DataBindings.Add("EditValue", bds1, "handling_office");
            txtDate.DataBindings.Add("EditValue", bds1, "date");
            txtSeason.DataBindings.Add("Text", bds1, "season");
            txtRequested_by.DataBindings.Add("Text", bds1, "requested_by");
            txtPlm_material_code.DataBindings.Add("Text", bds1, "plm_material_code");
            txtSupplier_ref_no.DataBindings.Add("Text", bds1, "supplier_ref_no");
            txtPvh_submit_ref.DataBindings.Add("Text", bds1, "pvh_submit_ref");
            //-------------------------------------------------------
            txtsupplier_name.DataBindings.Add("Text", bds1, "supplier_name");
            txtFactory_name.DataBindings.Add("Text", bds1, "factory_name");
            lueMaterial_subtype.DataBindings.Add("EditValue",bds1, "material_subtype");
            txtColour.DataBindings.Add("Text", bds1, "colour");
            txtSize.DataBindings.Add("Text", bds1, "size");
            txtProcess.DataBindings.Add("EditValue", bds1, "process");
            txtFinish.DataBindings.Add("EditValue", bds1, "finish");
            txtPrevious_submit_ref.DataBindings.Add("Text", bds1, "previous_submit_ref");
            lueSample_type.DataBindings.Add("EditValue", bds1, "sample_type");
            luePrevious_submit_vr.DataBindings.Add("EditValue", bds1, "previous_submit_vr");
            txtWeight.DataBindings.Add("Text", bds1, "weight");
            txtWeight_uom.DataBindings.Add("EditValue", bds1, "weight_uom");
            lueObj_fbx.DataBindings.Add("EditValue", bds1, "obj_fbx");
            lueU3ma.DataBindings.Add("EditValue", bds1, "u3ma");
            //-------------------------------------------------------
            lueRaw_mat1_compostion.DataBindings.Add("EditValue", bds1, "raw_mat1_compostion");
            txtRaw_mat1_percent.DataBindings.Add("Text", bds1, "raw_mat1_percent");
            lueRaw_mat1_l3.DataBindings.Add("EditValue", bds1, "raw_mat1_l3");
            lueRaw_mat1_l4.DataBindings.Add("EditValue", bds1, "raw_mat1_l4");
            lueRaw_mat1_l5.DataBindings.Add("EditValue", bds1, "raw_mat1_l5");
            lueRaw_mat2_compostion.DataBindings.Add("EditValue", bds1, "raw_mat2_compostion");
            txtRaw_mat2_percent.DataBindings.Add("Text", bds1, "raw_mat2_percent");
            lueRaw_mat2_l3.DataBindings.Add("EditValue", bds1, "raw_mat2_l3");
            lueRaw_mat2_l4.DataBindings.Add("EditValue", bds1, "raw_mat2_l4");
            lueRaw_mat2_l5.DataBindings.Add("EditValue", bds1, "raw_mat2_l5");
            lueRaw_mat3_compostion.DataBindings.Add("EditValue", bds1, "raw_mat3_compostion");
            txtRaw_mat3_percent.DataBindings.Add("Text", bds1, "raw_mat3_percent");
            lueRaw_mat3_l3.DataBindings.Add("EditValue", bds1, "raw_mat3_l3");
            lueRaw_mat3_l4.DataBindings.Add("EditValue", bds1, "raw_mat3_l4");
            lueRaw_mat3_l5.DataBindings.Add("EditValue", bds1, "raw_mat3_l5");
            lueRaw_mat4_compostion.DataBindings.Add("EditValue", bds1, "raw_mat4_compostion");
            txtRaw_mat4_percent.DataBindings.Add("Text", bds1, "raw_mat4_percent");
            lueRaw_mat4_l3.DataBindings.Add("EditValue", bds1, "raw_mat4_l3");
            lueRaw_mat4_l4.DataBindings.Add("EditValue", bds1, "raw_mat4_l4");
            lueRaw_mat4_l5.DataBindings.Add("EditValue", bds1, "raw_mat4_l5");
            lueRaw_mat5_compostion.DataBindings.Add("EditValue", bds1, "raw_mat5_compostion");
            txtRaw_mat5_percent.DataBindings.Add("Text", bds1, "raw_mat5_percent");
            lueRaw_mat5_l3.DataBindings.Add("EditValue", bds1, "raw_mat5_l3");
            lueRaw_mat5_l4.DataBindings.Add("EditValue", bds1, "raw_mat5_l4");
            lueRaw_mat5_l5.DataBindings.Add("EditValue", bds1, "raw_mat5_l5");
            //----------------------------------------------------------------
            lueCurrency.DataBindings.Add("EditValue", bds1, "currency");
            luePrice1_unit.DataBindings.Add("EditValue", bds1, "price1_unit");
            txtprice1.DataBindings.Add("Text", bds1, "price1");
            luePrice2_unit.DataBindings.Add("EditValue", bds1, "price2_unit");
            txtprice2.DataBindings.Add("Text", bds1, "price2");
            luePrice3_unit.DataBindings.Add("EditValue", bds1, "price3_unit");
            txtprice3.DataBindings.Add("Text", bds1, "price3");
            luePrice4_unit.DataBindings.Add("EditValue", bds1, "price4_unit");
            txtprice4.DataBindings.Add("Text", bds1, "price4");
            luePrice5_unit.DataBindings.Add("EditValue", bds1, "price5_unit");
            txtprice5.DataBindings.Add("Text", bds1, "price5");
            luePrice6_unit.DataBindings.Add("EditValue", bds1, "price6_unit");
            txtprice6.DataBindings.Add("Text", bds1, "price6");
            txtSurcharge.DataBindings.Add("Text", bds1, "surcharge");
            txtbulk_moq.DataBindings.Add("Text", bds1, "bulk_moq");
            txtmoq_color.DataBindings.Add("Text", bds1, "moq_color");
            txtleadtime_sample.DataBindings.Add("Text", bds1, "leadtime_sample");
            txtleadtime_bulk.DataBindings.Add("Text", bds1, "leadtime_bulk");
            //------------------------------------------------------------------------
            lueCert1_mat_finish.DataBindings.Add("EditValue", bds1, "cert1_mat_finish");
            lueCert1_type.DataBindings.Add("EditValue", bds1, "cert1_type");
            txtCert1_type_other.DataBindings.Add("Text", bds1, "cert1_type_other");
            txtCert1_scope_no.DataBindings.Add("Text", bds1, "cert1_scope_no");
            txtCert1_expiry_date.DataBindings.Add("Text", bds1, "cert1_expiry_date");
            txtCert1_scope_holder.DataBindings.Add("Text", bds1, "cert1_scope_holder");
            lueCert2_mat_finish.DataBindings.Add("EditValue", bds1, "cert2_mat_finish");//--
            lueCert2_type.DataBindings.Add("EditValue", bds1, "cert2_type");
            txtCert2_type_other.DataBindings.Add("Text", bds1, "cert2_type_other");
            txtCert2_scope_no.DataBindings.Add("Text", bds1, "cert2_scope_no");
            txtCert2_expiry_date.DataBindings.Add("Text", bds1, "cert2_expiry_date");
            txtCert2_scope_holder.DataBindings.Add("Text", bds1, "cert2_scope_holder");
            lueCert3_mat_finish.DataBindings.Add("EditValue", bds1, "cert3_mat_finish");//--
            lueCert3_type.DataBindings.Add("EditValue", bds1, "cert3_type");
            txtCert3_type_other.DataBindings.Add("Text", bds1, "cert3_type_other");
            txtCert3_scope_no.DataBindings.Add("Text", bds1, "cert3_scope_no");
            txtCert3_expiry_date.DataBindings.Add("Text", bds1, "cert3_expiry_date");
            txtCert3_scope_holder.DataBindings.Add("Text", bds1, "cert3_scope_holder");
            lueCert4_mat_finish.DataBindings.Add("EditValue", bds1, "cert4_mat_finish");//--
            lueCert4_type.DataBindings.Add("EditValue", bds1, "cert4_type");
            txtCert4_type_other.DataBindings.Add("Text", bds1, "cert4_type_other");
            txtCert4_scope_no.DataBindings.Add("Text", bds1, "cert4_scope_no");
            txtCert4_expiry_date.DataBindings.Add("Text", bds1, "cert4_expiry_date");
            txtCert4_scope_holder.DataBindings.Add("Text", bds1, "cert4_scope_holder");
            //-----------------------------------------------------------------------------------      
            lueRsl_certificate_type.DataBindings.Add("EditValue", bds1, "rsl_certificate_type");
            dtRsl_certificate_expiry_date.DataBindings.Add("EditValue", bds1, "rsl_certificate_expiry_date");
            lueMachine_washable.DataBindings.Add("EditValue", bds1, "machine_washable");
            lueDry_cleanable.DataBindings.Add("EditValue", bds1, "dry_cleanable");
            lueDry_clean_only.DataBindings.Add("EditValue", bds1, "dry_clean_only");
            lueDo_not_dry_clean.DataBindings.Add("EditValue", bds1, "do_not_dry_clean");
            lueSuitable_for_tumble_dry.DataBindings.Add("EditValue", bds1, "suitable_for_tumble_dry");
            lueSuitable_for_swimwear.DataBindings.Add("EditValue", bds1, "suitable_for_swimwear");
            luePasses_metal_detection.DataBindings.Add("EditValue", bds1, "passes_metal_detection");
            lueComplies_with_pvh.DataBindings.Add("EditValue", bds1, "complies_with_pvh");
            lueComplies_with_cfr.DataBindings.Add("EditValue", bds1, "complies_with_cfr");
            txtQuality_callouts.DataBindings.Add("Text", bds1, "quality_callouts");
            //-----------------------------------------------------------------------------------        
            lueFor_bulk_feference.DataBindings.Add("EditValue", bds1, "for_bulk_feference");
            lueFor_quality_approval.DataBindings.Add("EditValue", bds1, "for_quality_approval");
            lueColor_already_approved.DataBindings.Add("EditValue", bds1, "color_already_approved");
            lueSize_already_approved.DataBindings.Add("EditValue", bds1, "size_already_approved");
            txtMo_id1.DataBindings.Add("Text", bds1, "mo_id1");
            txtMo_id2.DataBindings.Add("Text", bds1, "mo_id2");
            txtMo_id3.DataBindings.Add("Text", bds1, "mo_id3");
            //chksubmit1.DataBindings.Add("Checked", bds1, "submit1");
            //chksubmit2.DataBindings.Add("Checked", bds1, "submit2");
            //chksubmit3.DataBindings.Add("Checked", bds1, "submit3");
            //chkurgent_bulk_order.DataBindings.Add("Checked", bds1, "urgent_bulk_order");
            //------------------------------------------------------------------------------------
            //added in 2023/08/23            
            txtDye_type.DataBindings.Add("EditValue", bds1, "dye_type");
            txtDye_method.DataBindings.Add("EditValue", bds1, "dye_method");

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
            txtDate.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            txtSerial_no.Text = clsTommyTest.GetSeqNo("development_pvh","serial_no");
            //txtPvh_submit_ref.Text = clsDevelopentPvh.GetPvhNo(txtSerial_no.Text);2022/04/20 Cancel
            txtsupplier_name.Text = "Ching Fung Apparel Accessories Co.,Ltd";
            txtFactory_name.Text = "Ching Fung Metal Manufactory(Longnan) Co.,Ltd";
            lueCurrency.EditValue = "US$";
            txtSurcharge.Text = "NIL";
            txtleadtime_sample.Text = "16";
            txtleadtime_bulk.Text = "28";
            txtSerial_no.Properties.ReadOnly = true;
            txtSerial_no.BackColor = Color.White;
            txtPvh_submit_ref.Properties.ReadOnly = true;
            txtPvh_submit_ref.BackColor = Color.White;

            //dgvDetails.Enabled = false;
            lueDivision.Focus();    
        }

        private void Save()
        {
            txtSerial_no.Focus();
            if (txtSerial_no.Text == "")
            {
                MessageBox.Show("Serial No不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSerial_no.Focus();
                return;
            }
            if (txtDate.Text == "")
            {
                MessageBox.Show("日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDate.Focus();
                return;
            }
            if (lueDivision.Text == "")
            {
                MessageBox.Show("Division不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lueDivision.Focus();
                return;
            }
            bds1.EndEdit();                    
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO development_pvh(serial_no,division,handling_office,season,date,requested_by,supplier_ref_no,plm_material_code,pvh_submit_ref,supplier_name,
            factory_name,material_subtype,size,colour,finish,process,previous_submit_ref,sample_type,previous_submit_vr,weight,weight_uom,obj_fbx,u3ma,raw_mat1_compostion,
            raw_mat1_percent,raw_mat1_l3,raw_mat1_l4,raw_mat1_l5,raw_mat2_compostion,raw_mat2_percent,raw_mat2_l3,raw_mat2_l4,raw_mat2_l5,raw_mat3_compostion,raw_mat3_percent,
            raw_mat3_l3,raw_mat3_l4,raw_mat3_l5,raw_mat4_compostion,raw_mat4_percent,raw_mat4_l3,raw_mat4_l4,raw_mat4_l5,raw_mat5_compostion,raw_mat5_percent,raw_mat5_l3,
            raw_mat5_l4,raw_mat5_l5,currency,price1,price1_unit,price2,price2_unit,price3,price3_unit,price4,price4_unit,price5,price5_unit,price6,price6_unit,surcharge,bulk_moq,
            moq_color,leadtime_sample,leadtime_bulk,cert1_mat_finish,cert1_type,cert1_type_other,cert1_scope_no,cert1_expiry_date,cert1_scope_holder,cert2_mat_finish,cert2_type,
            cert2_type_other,cert2_scope_no,cert2_expiry_date,cert2_scope_holder,cert3_mat_finish,cert3_type,cert3_type_other,cert3_scope_no,cert3_expiry_date,cert3_scope_holder,
            cert4_mat_finish,cert4_type,cert4_type_other,cert4_scope_no,cert4_expiry_date,cert4_scope_holder,rsl_certificate_type,rsl_certificate_expiry_date,machine_washable,
            dry_cleanable,dry_clean_only,do_not_dry_clean,suitable_for_tumble_dry,suitable_for_swimwear,passes_metal_detection,complies_with_pvh,complies_with_cfr,quality_callouts,
            submit1,submit2,submit3,urgent_bulk_order,for_bulk_feference,for_quality_approval,color_already_approved,size_already_approved,create_by,create_date,mo_id1,mo_id2,mo_id3,
            dye_type,dye_method) 
            VALUES(@serial_no,@division,@handling_office,@season,@date,@requested_by,@supplier_ref_no,@plm_material_code,@pvh_submit_ref,@supplier_name,@factory_name,
            @material_subtype,@size,@colour,@finish,@process,@previous_submit_ref,@sample_type,@previous_submit_vr,@weight,@weight_uom,@obj_fbx,@u3ma,@raw_mat1_compostion,
            @raw_mat1_percent,@raw_mat1_l3,@raw_mat1_l4,@raw_mat1_l5,@raw_mat2_compostion,@raw_mat2_percent,@raw_mat2_l3,@raw_mat2_l4,@raw_mat2_l5,@raw_mat3_compostion,@raw_mat3_percent,
            @raw_mat3_l3,@raw_mat3_l4,@raw_mat3_l5,@raw_mat4_compostion,@raw_mat4_percent,@raw_mat4_l3,@raw_mat4_l4,@raw_mat4_l5,@raw_mat5_compostion,@raw_mat5_percent,@raw_mat5_l3,
            @raw_mat5_l4,@raw_mat5_l5,@currency,@price1,@price1_unit,@price2,@price2_unit,@price3,@price3_unit,@price4,@price4_unit,@price5,@price5_unit,@price6,@price6_unit,@surcharge,@bulk_moq,
            @moq_color,@leadtime_sample,@leadtime_bulk,@cert1_mat_finish,@cert1_type,@cert1_type_other,@cert1_scope_no,@cert1_expiry_date,@cert1_scope_holder,@cert2_mat_finish,@cert2_type,
            @cert2_type_other,@cert2_scope_no,@cert2_expiry_date,@cert2_scope_holder,@cert3_mat_finish,@cert3_type,@cert3_type_other,@cert3_scope_no,@cert3_expiry_date,@cert3_scope_holder,
            @cert4_mat_finish,@cert4_type,@cert4_type_other,@cert4_scope_no,@cert4_expiry_date,@cert4_scope_holder,@rsl_certificate_type,
            CASE LEN(@rsl_certificate_expiry_date) WHEN 0 THEN null ELSE @rsl_certificate_expiry_date END ,@machine_washable,
            @dry_cleanable,@dry_clean_only,@do_not_dry_clean,@suitable_for_tumble_dry,@suitable_for_swimwear,@passes_metal_detection,@complies_with_pvh,@complies_with_cfr,@quality_callouts,
            @submit1,@submit2,@submit3,@urgent_bulk_order,@for_bulk_feference,@for_quality_approval,@color_already_approved,@size_already_approved,@user_id,getdate(),@mo_id1,@mo_id2,@mo_id3,
            @dye_type,@dye_method)";

            const string sql_update =
            @"Update development_pvh 
            SET division=@division,handling_office=@handling_office,season=@season,date=@date,requested_by=@requested_by,supplier_ref_no=@supplier_ref_no,plm_material_code=@plm_material_code,
            pvh_submit_ref=@pvh_submit_ref,supplier_name=@supplier_name,factory_name=@factory_name,material_subtype=@material_subtype,size=@size,colour=@colour,finish=@finish,process=@process,
            previous_submit_ref=@previous_submit_ref,sample_type=@sample_type,previous_submit_vr=@previous_submit_vr,weight=@weight,weight_uom=@weight_uom,obj_fbx=@obj_fbx,u3ma=@u3ma,
            raw_mat1_compostion=@raw_mat1_compostion,raw_mat1_percent=@raw_mat1_percent,raw_mat1_l3=@raw_mat1_l3,raw_mat1_l4=@raw_mat1_l4,raw_mat1_l5=@raw_mat1_l5,raw_mat2_compostion=@raw_mat2_compostion,
            raw_mat2_percent=@raw_mat2_percent,raw_mat2_l3=@raw_mat2_l3,raw_mat2_l4=@raw_mat2_l4,raw_mat2_l5=@raw_mat2_l5,raw_mat3_compostion=@raw_mat3_compostion,raw_mat3_percent=@raw_mat3_percent,
            raw_mat3_l3=@raw_mat3_l3,raw_mat3_l4=@raw_mat3_l4,raw_mat3_l5=@raw_mat3_l5,raw_mat4_compostion=@raw_mat4_compostion,raw_mat4_percent=@raw_mat4_percent,raw_mat4_l3=@raw_mat4_l3,
            raw_mat4_l4=@raw_mat4_l4,raw_mat4_l5=@raw_mat4_l5,raw_mat5_compostion=@raw_mat5_compostion,raw_mat5_percent=@raw_mat5_percent,raw_mat5_l3=@raw_mat5_l3,raw_mat5_l4=@raw_mat5_l4,raw_mat5_l5=@raw_mat5_l5,
            currency=@currency,price1=@price1,price1_unit=@price1_unit,price2=@price2,price2_unit=@price2_unit,price3=@price3,price3_unit=@price3_unit,price4=@price4,price4_unit=@price4_unit,
            price5=@price5,price5_unit=@price5_unit,price6=@price6,price6_unit=@price6_unit,surcharge=@surcharge,bulk_moq=@bulk_moq,moq_color=@moq_color,leadtime_sample=@leadtime_sample,leadtime_bulk=@leadtime_bulk,
            cert1_mat_finish=@cert1_mat_finish,cert1_type=@cert1_type,cert1_type_other=@cert1_type_other,cert1_scope_no=@cert1_scope_no,cert1_expiry_date=@cert1_expiry_date, cert1_scope_holder=@cert1_scope_holder,
            cert2_mat_finish=@cert2_mat_finish,cert2_type=@cert2_type,cert2_type_other=@cert2_type_other,cert2_scope_no=@cert2_scope_no,cert2_expiry_date=@cert2_expiry_date,cert2_scope_holder=@cert2_scope_holder,
            cert3_mat_finish=@cert3_mat_finish,cert3_type=@cert3_type,cert3_type_other=@cert3_type_other,cert3_scope_no=@cert3_scope_no,cert3_expiry_date=@cert3_expiry_date,cert3_scope_holder=@cert3_scope_holder,
            cert4_mat_finish=@cert4_mat_finish,cert4_type=@cert4_type,cert4_type_other=@cert4_type_other,cert4_scope_no=@cert4_scope_no,cert4_expiry_date=@cert4_expiry_date,cert4_scope_holder=@cert4_scope_holder,
            rsl_certificate_type=@rsl_certificate_type,rsl_certificate_expiry_date=CASE LEN(@rsl_certificate_expiry_date) WHEN 0 THEN null ELSE @rsl_certificate_expiry_date END,machine_washable=@machine_washable,
            dry_cleanable=@dry_cleanable,dry_clean_only=@dry_clean_only,do_not_dry_clean=@do_not_dry_clean,suitable_for_tumble_dry=@suitable_for_tumble_dry,suitable_for_swimwear=@suitable_for_swimwear,
            passes_metal_detection=@passes_metal_detection,complies_with_pvh=@complies_with_pvh,complies_with_cfr=@complies_with_cfr,quality_callouts=@quality_callouts,submit1=@submit1,submit2=@submit2,submit3=@submit3,
            urgent_bulk_order=@urgent_bulk_order,for_bulk_feference=@for_bulk_feference,for_quality_approval=@for_quality_approval,color_already_approved=@color_already_approved,size_already_approved=@size_already_approved,
            update_by=@user_id,update_date=getdate(),mo_id1=@mo_id1,mo_id2=@mo_id2,mo_id3=@mo_id3, dye_type=@dye_type,dye_method=@dye_method
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
                        strSerial_no = clsTommyTest.GetSeqNo("development_pvh", "serial_no");
                        //txtPvh_submit_ref.Text = clsDevelopentPvh.GetPvhNo(strSerial_no);
                        if (txtPvh_submit_ref.Text != "")
                        {
                            string sql_f = string.Format("Select pvh_submit_ref From development_pvh where pvh_submit_ref='{0}'", txtPvh_submit_ref.Text);
                            if(clsPublicOfCF01.ExecuteSqlReturnObject(sql_f) != "")
                            {
                                //重新取編號
                                txtPvh_submit_ref.Text = clsDevelopentPvh.GetPvhNo(strSerial_no,lueDivision.Text);
                            }
                        }
                        myCommand.Parameters.AddWithValue("@serial_no", strSerial_no);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@serial_no", txtSerial_no.Text);
                        strSerial_no = txtSerial_no.Text;
                    }
                    myCommand.Parameters.AddWithValue("@division", lueDivision.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@season", txtSeason.Text);
                    myCommand.Parameters.AddWithValue("@date", clsApp.Return_String_Date(txtDate.Text));                   
                    myCommand.Parameters.AddWithValue("@handling_office", lueHandling_office.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@requested_by", txtRequested_by.Text);
                    myCommand.Parameters.AddWithValue("@supplier_ref_no", txtSupplier_ref_no.Text);
                    myCommand.Parameters.AddWithValue("@plm_material_code", txtPlm_material_code.Text);
                    myCommand.Parameters.AddWithValue("@pvh_submit_ref", txtPvh_submit_ref.Text);
                    //-------------------------------------------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@supplier_name", txtsupplier_name.Text);                   
                    myCommand.Parameters.AddWithValue("@factory_name", txtFactory_name.Text);
                    myCommand.Parameters.AddWithValue("@material_subtype", lueMaterial_subtype.EditValue);
                    myCommand.Parameters.AddWithValue("@colour", txtColour.Text);
                    myCommand.Parameters.AddWithValue("@size", txtSize.Text);
                    myCommand.Parameters.AddWithValue("@finish", txtFinish.EditValue);
                    myCommand.Parameters.AddWithValue("@process", txtProcess.EditValue);
                    myCommand.Parameters.AddWithValue("@previous_submit_ref", txtPrevious_submit_ref.Text);
                    myCommand.Parameters.AddWithValue("@sample_type", lueSample_type.EditValue);
                    myCommand.Parameters.AddWithValue("@previous_submit_vr", luePrevious_submit_vr.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@weight", txtWeight.Text);
                    myCommand.Parameters.AddWithValue("@weight_uom", txtWeight_uom.Text);
                    myCommand.Parameters.AddWithValue("@obj_fbx", lueObj_fbx.EditValue);
                    myCommand.Parameters.AddWithValue("@u3ma", lueU3ma.EditValue);
                    //--------------------------------------------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@raw_mat1_compostion", lueRaw_mat1_compostion.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat1_percent", ConvertToInt(txtRaw_mat1_percent.Text));
                    myCommand.Parameters.AddWithValue("@raw_mat1_l3", lueRaw_mat1_l3.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat1_l4", lueRaw_mat1_l4.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat1_l5", lueRaw_mat1_l5.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat2_compostion", lueRaw_mat2_compostion.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat2_percent", ConvertToInt(txtRaw_mat2_percent.Text));
                    myCommand.Parameters.AddWithValue("@raw_mat2_l3", lueRaw_mat2_l3.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat2_l4", lueRaw_mat2_l4.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat2_l5", lueRaw_mat2_l5.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat3_compostion", lueRaw_mat3_compostion.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat3_percent", ConvertToInt(txtRaw_mat3_percent.Text));
                    myCommand.Parameters.AddWithValue("@raw_mat3_l3", lueRaw_mat3_l3.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat3_l4", lueRaw_mat3_l4.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat3_l5", lueRaw_mat3_l5.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat4_compostion", lueRaw_mat4_compostion.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat4_percent", ConvertToInt(txtRaw_mat4_percent.Text));
                    myCommand.Parameters.AddWithValue("@raw_mat4_l3", lueRaw_mat4_l3.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat4_l4", lueRaw_mat4_l4.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat4_l5", lueRaw_mat4_l5.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat5_compostion", lueRaw_mat5_compostion.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat5_percent", ConvertToInt(txtRaw_mat5_percent.Text));
                    myCommand.Parameters.AddWithValue("@raw_mat5_l3", lueRaw_mat5_l3.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat5_l4", lueRaw_mat5_l4.EditValue);
                    myCommand.Parameters.AddWithValue("@raw_mat5_l5", lueRaw_mat5_l5.EditValue);
                    //--------------------------------------------------------------------------------------               
                    myCommand.Parameters.AddWithValue("@currency", lueCurrency.EditValue);
                    myCommand.Parameters.AddWithValue("@price1_unit", luePrice1_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@price1", clsApp.Return_Float_Value_4(txtprice1.Text));
                    myCommand.Parameters.AddWithValue("@price2_unit", luePrice2_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@price2", clsApp.Return_Float_Value_4(txtprice2.Text));
                    myCommand.Parameters.AddWithValue("@price3_unit", luePrice3_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@price3", clsApp.Return_Float_Value_4(txtprice3.Text));
                    myCommand.Parameters.AddWithValue("@price4_unit", luePrice4_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@price4", clsApp.Return_Float_Value_4(txtprice4.Text));
                    myCommand.Parameters.AddWithValue("@price5_unit", luePrice5_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@price5", clsApp.Return_Float_Value_4(txtprice5.Text));
                    myCommand.Parameters.AddWithValue("@price6_unit", luePrice6_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@price6", clsApp.Return_Float_Value_4(txtprice6.Text));
                    myCommand.Parameters.AddWithValue("@surcharge", txtSurcharge.Text);
                    myCommand.Parameters.AddWithValue("@bulk_moq", txtbulk_moq.Text);
                    myCommand.Parameters.AddWithValue("@moq_color", txtmoq_color.Text);
                    myCommand.Parameters.AddWithValue("@leadtime_sample", txtleadtime_sample.Text);
                    myCommand.Parameters.AddWithValue("@leadtime_bulk", txtleadtime_bulk.Text);
                    //---------------------------------------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@cert1_mat_finish", lueCert1_mat_finish.EditValue);
                    myCommand.Parameters.AddWithValue("@cert1_type", lueCert1_type.EditValue);
                    myCommand.Parameters.AddWithValue("@cert1_type_other", txtCert1_type_other.Text);
                    myCommand.Parameters.AddWithValue("@cert1_scope_no", txtCert1_scope_no.Text);
                    myCommand.Parameters.AddWithValue("@cert1_expiry_date", txtCert1_expiry_date.Text);
                    myCommand.Parameters.AddWithValue("@cert1_scope_holder", txtCert1_scope_holder.Text);
                    myCommand.Parameters.AddWithValue("@cert2_mat_finish", lueCert2_mat_finish.EditValue);//--
                    myCommand.Parameters.AddWithValue("@cert2_type", lueCert2_type.EditValue);
                    myCommand.Parameters.AddWithValue("@cert2_type_other", txtCert2_type_other.Text);
                    myCommand.Parameters.AddWithValue("@cert2_scope_no", txtCert2_scope_no.Text);
                    myCommand.Parameters.AddWithValue("@cert2_expiry_date", txtCert2_expiry_date.Text);
                    myCommand.Parameters.AddWithValue("@cert2_scope_holder", txtCert2_scope_holder.Text);
                    myCommand.Parameters.AddWithValue("@cert3_mat_finish", lueCert3_mat_finish.EditValue);//--
                    myCommand.Parameters.AddWithValue("@cert3_type", lueCert3_type.EditValue);
                    myCommand.Parameters.AddWithValue("@cert3_type_other", txtCert3_type_other.Text);
                    myCommand.Parameters.AddWithValue("@cert3_scope_no", txtCert3_scope_no.Text);
                    myCommand.Parameters.AddWithValue("@cert3_expiry_date", txtCert3_expiry_date.Text);
                    myCommand.Parameters.AddWithValue("@cert3_scope_holder", txtCert3_scope_holder.Text);
                    myCommand.Parameters.AddWithValue("@cert4_mat_finish", lueCert4_mat_finish.EditValue);//--
                    myCommand.Parameters.AddWithValue("@cert4_type", lueCert4_type.EditValue);
                    myCommand.Parameters.AddWithValue("@cert4_type_other", txtCert4_type_other.Text);
                    myCommand.Parameters.AddWithValue("@cert4_scope_no", txtCert4_scope_no.Text);
                    myCommand.Parameters.AddWithValue("@cert4_expiry_date", txtCert4_expiry_date.Text);
                    myCommand.Parameters.AddWithValue("@cert4_scope_holder", txtCert4_scope_holder.Text);
                    //-----------------------------------------------------------------------------------                
                    myCommand.Parameters.AddWithValue("@rsl_certificate_type", lueRsl_certificate_type.EditValue);
                    string strDate = dtRsl_certificate_expiry_date.EditValue.ToString();
                    myCommand.Parameters.AddWithValue("@rsl_certificate_expiry_date", clsApp.Return_String_Date(strDate));
                    myCommand.Parameters.AddWithValue("@machine_washable", lueMachine_washable.EditValue);
                    myCommand.Parameters.AddWithValue("@dry_cleanable", lueDry_cleanable.EditValue);
                    myCommand.Parameters.AddWithValue("@dry_clean_only", lueDry_clean_only.EditValue);
                    myCommand.Parameters.AddWithValue("@do_not_dry_clean", lueDo_not_dry_clean.EditValue);
                    myCommand.Parameters.AddWithValue("@suitable_for_tumble_dry", lueSuitable_for_tumble_dry.EditValue);
                    myCommand.Parameters.AddWithValue("@suitable_for_swimwear", lueSuitable_for_swimwear.EditValue);
                    myCommand.Parameters.AddWithValue("@passes_metal_detection", luePasses_metal_detection.EditValue);
                    myCommand.Parameters.AddWithValue("@complies_with_pvh", lueComplies_with_pvh.EditValue);
                    myCommand.Parameters.AddWithValue("@complies_with_cfr", lueComplies_with_cfr.EditValue);
                    myCommand.Parameters.AddWithValue("@quality_callouts", txtQuality_callouts.Text);
                    //-----------------------------------------------------------------------------------                 
                    myCommand.Parameters.AddWithValue("@submit1", chksubmit1.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@submit2", chksubmit2.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@submit3", chksubmit3.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@urgent_bulk_order", chkurgent_bulk_order.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@for_bulk_feference", lueFor_bulk_feference.EditValue);
                    myCommand.Parameters.AddWithValue("@for_quality_approval", lueFor_quality_approval.EditValue);
                    myCommand.Parameters.AddWithValue("@color_already_approved", lueColor_already_approved.EditValue);
                    myCommand.Parameters.AddWithValue("@size_already_approved", lueSize_already_approved.EditValue);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                    myCommand.Parameters.AddWithValue("@mo_id1", txtMo_id1.Text);
                    myCommand.Parameters.AddWithValue("@mo_id2", txtMo_id2.Text);
                    myCommand.Parameters.AddWithValue("@mo_id3", txtMo_id3.Text);
                    //added 2023/08/23-------------------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@dye_type", txtDye_type.EditValue);
                    myCommand.Parameters.AddWithValue("@dye_method", txtDye_method.EditValue);

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
                const string sql_del = "DELETE FROM dbo.development_pvh WHERE serial_no=@serial_no";
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
            txtPvh_submit_ref.Properties.ReadOnly = true;
            txtPvh_submit_ref.BackColor = Color.White;
        }

        private void frmDevelopmentPvh_FormClosed(object sender, FormClosedEventArgs e)
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
            txtPvh_submit_ref.Properties.ReadOnly = true;
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
            dtDetail.Clear();
            string date1 = dtDat1.Text != "" ? clsApp.Return_String_Date(dtDat1.Text) : "";
            string date2 = dtDat2.Text != "" ? clsApp.Return_String_Date(dtDat2.Text) : "";
            dtDetail = clsDevelopentPvh.Find_Data(txtId1.Text, txtId2.Text, txtPvh_submit_ref1.Text, txtPvh_submit_ref2.Text
                , date1, date2 , txtPlm_material_code1.Text, txtMo_id1.Text, txtMo_id2.Text, txtMo_id3.Text);
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
            lueDivision.EditValue = pdr.Cells["division"].Value.ToString();
            txtSeason.EditValue = pdr.Cells["season"].Value.ToString();
            lueHandling_office.EditValue = pdr.Cells["handling_office"].Value.ToString();
            txtRequested_by.Text = pdr.Cells["requested_by"].Value.ToString();
            txtSupplier_ref_no.Text = pdr.Cells["supplier_ref_no"].Value.ToString();
            txtPlm_material_code.Text = pdr.Cells["plm_material_code"].Value.ToString();
            //-------------------------------------------------------------------------------------------
            txtsupplier_name.Text = pdr.Cells["supplier_name"].Value.ToString();
            txtFactory_name.Text = pdr.Cells["factory_name"].Value.ToString();
            lueMaterial_subtype.EditValue = pdr.Cells["material_subtype"].Value.ToString();
            txtColour.Text = pdr.Cells["colour"].Value.ToString();
            txtSize.Text = pdr.Cells["size"].Value.ToString();
            txtProcess.EditValue = pdr.Cells["process"].Value.ToString();
            txtFinish.EditValue = pdr.Cells["finish"].Value.ToString();
            txtPrevious_submit_ref.Text = pdr.Cells["previous_submit_ref"].Value.ToString();
            lueSample_type.EditValue = pdr.Cells["sample_type"].Value.ToString();
            luePrevious_submit_vr.EditValue = pdr.Cells["previous_submit_vr"].Value.ToString();
            txtWeight.Text = pdr.Cells["weight"].Value.ToString();
            txtWeight_uom.EditValue = pdr.Cells["weight_uom"].Value.ToString();
            lueObj_fbx.EditValue = pdr.Cells["obj_fbx"].Value.ToString();
            lueU3ma.EditValue = pdr.Cells["u3ma"].Value.ToString();
            //--------------------------------------------------------------------------------------------
            lueRaw_mat1_compostion.EditValue = pdr.Cells["raw_mat1_compostion"].Value.ToString();
            txtRaw_mat1_percent.Text = pdr.Cells["raw_mat1_percent"].Value.ToString();
            lueRaw_mat1_l3.EditValue = pdr.Cells["raw_mat1_l3"].Value.ToString();
            lueRaw_mat1_l4.EditValue = pdr.Cells["raw_mat1_l4"].Value.ToString();
            lueRaw_mat1_l5.EditValue = pdr.Cells["raw_mat1_l5"].Value.ToString();
            txtRaw_mat2_percent.Text = pdr.Cells["raw_mat2_percent"].Value.ToString();
            lueRaw_mat2_l3.EditValue = pdr.Cells["raw_mat2_l3"].Value.ToString();
            lueRaw_mat2_l4.EditValue = pdr.Cells["raw_mat2_l4"].Value.ToString();
            lueRaw_mat2_l5.EditValue = pdr.Cells["raw_mat2_l5"].Value.ToString();
            txtRaw_mat3_percent.Text = pdr.Cells["raw_mat3_percent"].Value.ToString();
            lueRaw_mat3_l3.EditValue = pdr.Cells["raw_mat3_l3"].Value.ToString();
            lueRaw_mat3_l4.EditValue = pdr.Cells["raw_mat3_l4"].Value.ToString();
            lueRaw_mat3_l5.EditValue = pdr.Cells["raw_mat3_l5"].Value.ToString();
            txtRaw_mat4_percent.Text = pdr.Cells["raw_mat4_percent"].Value.ToString();
            lueRaw_mat4_l3.EditValue = pdr.Cells["raw_mat4_l3"].Value.ToString();
            lueRaw_mat4_l4.EditValue = pdr.Cells["raw_mat4_l4"].Value.ToString();
            lueRaw_mat4_l5.EditValue = pdr.Cells["raw_mat4_l5"].Value.ToString();
            txtRaw_mat5_percent.Text = pdr.Cells["raw_mat5_percent"].Value.ToString();
            lueRaw_mat5_l3.EditValue = pdr.Cells["raw_mat5_l3"].Value.ToString();
            lueRaw_mat5_l4.EditValue = pdr.Cells["raw_mat5_l4"].Value.ToString();
            lueRaw_mat5_l5.EditValue = pdr.Cells["raw_mat5_l5"].Value.ToString();
            //--------------------------------------------------------------------------------------  
            lueCurrency.EditValue = pdr.Cells["currency"].Value.ToString();
            luePrice1_unit.EditValue = pdr.Cells["price1_unit"].Value.ToString();
            txtprice1.Text = pdr.Cells["price1"].Value.ToString();
            luePrice2_unit.EditValue = pdr.Cells["price2_unit"].Value.ToString();
            txtprice2.Text = pdr.Cells["price2"].Value.ToString();
            luePrice3_unit.EditValue = pdr.Cells["price3_unit"].Value.ToString();
            txtprice3.Text = pdr.Cells["price3"].Value.ToString();
            luePrice4_unit.EditValue = pdr.Cells["price4_unit"].Value.ToString();
            txtprice4.Text = pdr.Cells["price4"].Value.ToString();
            luePrice5_unit.EditValue = pdr.Cells["price5_unit"].Value.ToString();
            txtprice5.Text = pdr.Cells["price5"].Value.ToString();
            luePrice6_unit.EditValue = pdr.Cells["price6_unit"].Value.ToString();
            txtprice6.Text = pdr.Cells["price6"].Value.ToString();
            txtSurcharge.Text = pdr.Cells["surcharge"].Value.ToString();
            txtbulk_moq.Text = pdr.Cells["bulk_moq"].Value.ToString();
            txtmoq_color.Text = pdr.Cells["moq_color"].Value.ToString();
            txtleadtime_sample.Text = pdr.Cells["leadtime_sample"].Value.ToString();
            txtleadtime_bulk.Text = pdr.Cells["leadtime_bulk"].Value.ToString();
            //---------------------------------------------------------------------------------------
            lueCert1_mat_finish.EditValue = pdr.Cells["cert1_mat_finish"].Value.ToString();
            lueCert1_type.EditValue = pdr.Cells["cert1_type"].Value.ToString();
            txtCert1_type_other.Text = pdr.Cells["cert1_type_other"].Value.ToString();
            txtCert1_scope_no.Text = pdr.Cells["cert1_scope_no"].Value.ToString();
            txtCert1_expiry_date.Text = pdr.Cells["cert1_expiry_date"].Value.ToString();
            txtCert1_scope_holder.Text = pdr.Cells["cert1_scope_holder"].Value.ToString();
            lueCert2_mat_finish.EditValue = pdr.Cells["cert2_mat_finish"].Value.ToString();
            lueCert2_type.EditValue = pdr.Cells["cert2_type"].Value.ToString();
            txtCert2_type_other.Text = pdr.Cells["cert2_type_other"].Value.ToString();
            txtCert2_scope_no.Text = pdr.Cells["cert2_scope_no"].Value.ToString();
            txtCert2_expiry_date.Text = pdr.Cells["cert2_expiry_date"].Value.ToString();
            txtCert2_scope_holder.Text = pdr.Cells["cert2_scope_holder"].Value.ToString();
            lueCert3_mat_finish.EditValue = pdr.Cells["cert3_mat_finish"].Value.ToString();
            lueCert3_type.EditValue = pdr.Cells["cert3_type"].Value.ToString();
            txtCert3_type_other.Text = pdr.Cells["cert3_type_other"].Value.ToString();
            txtCert3_scope_no.Text = pdr.Cells["cert3_scope_no"].Value.ToString();
            txtCert3_expiry_date.Text = pdr.Cells["cert3_expiry_date"].Value.ToString();
            txtCert3_scope_holder.Text = pdr.Cells["cert3_scope_holder"].Value.ToString();
            lueCert4_mat_finish.EditValue = pdr.Cells["cert4_mat_finish"].Value.ToString();
            lueCert4_type.EditValue = pdr.Cells["cert4_type"].Value.ToString();
            txtCert4_type_other.Text = pdr.Cells["cert4_type_other"].Value.ToString();
            txtCert4_scope_no.Text = pdr.Cells["cert4_scope_no"].Value.ToString();
            txtCert4_expiry_date.Text = pdr.Cells["cert4_expiry_date"].Value.ToString();
            txtCert4_scope_holder.Text = pdr.Cells["cert4_scope_holder"].Value.ToString();
            //-----------------------------------------------------------------------------------
            lueRsl_certificate_type.EditValue = pdr.Cells["rsl_certificate_type"].Value.ToString();
            dtRsl_certificate_expiry_date.EditValue = pdr.Cells["rsl_certificate_expiry_date"].Value.ToString();
            lueMachine_washable.EditValue = pdr.Cells["machine_washable"].Value.ToString();
            lueDry_cleanable.EditValue = pdr.Cells["dry_cleanable"].Value.ToString();
            lueDry_clean_only.EditValue = pdr.Cells["dry_clean_only"].Value.ToString();
            lueDo_not_dry_clean.EditValue = pdr.Cells["do_not_dry_clean"].Value.ToString();
            lueSuitable_for_tumble_dry.EditValue = pdr.Cells["suitable_for_tumble_dry"].Value.ToString();
            lueSuitable_for_swimwear.EditValue = pdr.Cells["suitable_for_swimwear"].Value.ToString();
            luePasses_metal_detection.EditValue = pdr.Cells["passes_metal_detection"].Value.ToString();
            lueComplies_with_pvh.EditValue = pdr.Cells["complies_with_pvh"].Value.ToString();
            lueComplies_with_cfr.EditValue = pdr.Cells["complies_with_cfr"].Value.ToString();
            txtQuality_callouts.Text = pdr.Cells["quality_callouts"].Value.ToString();            
            //-----------------------------------------------------------------------------------
            lueFor_bulk_feference.EditValue = pdr.Cells["for_bulk_feference"].Value.ToString();
            lueFor_quality_approval.EditValue = pdr.Cells["for_quality_approval"].Value.ToString();
            lueColor_already_approved.EditValue = pdr.Cells["color_already_approved"].Value.ToString();
            lueSize_already_approved.EditValue = pdr.Cells["size_already_approved"].Value.ToString();
            //added in 2023/08/23----------------------------------------------------------------
            txtDye_type.EditValue = pdr.Cells["dye_type"].Value.ToString();
            txtDye_method.EditValue = pdr.Cells["dye_method"].Value.ToString();

            SetCheckBoxStatus(pdr);
        }

        private void SetCheckBoxStatus(DataGridViewRow pdr)
        {
            string strCheck = pdr.Cells["submit1"].Value.ToString();
            if (string.IsNullOrEmpty(strCheck) || strCheck == "False")
            {
                chksubmit1.Checked = false;
            }
            else
            {
                chksubmit1.Checked = true;
            }
            strCheck = pdr.Cells["submit2"].Value.ToString();
            if (string.IsNullOrEmpty(strCheck) || strCheck == "False")
            {
                chksubmit2.Checked = false;
            }
            else
            {
                chksubmit2.Checked = true;
            }
            strCheck = pdr.Cells["submit3"].Value.ToString();
            if (string.IsNullOrEmpty(strCheck) || strCheck == "False")
            {
                chksubmit3.Checked = false;
            }
            else
            {
                chksubmit3.Checked = true;
            }
            strCheck = pdr.Cells["urgent_bulk_order"].Value.ToString();
            if (string.IsNullOrEmpty(strCheck) || strCheck == "False")
            {
                chkurgent_bulk_order.Checked = false;
            }
            else
            {
                chkurgent_bulk_order.Checked = true;
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDat2.EditValue = dtDat1.EditValue;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount ==0)
            {
                MessageBox.Show("沒有要列印的數據！","提示信息");
                return;
            }
            string strsql = string.Format(
                @"Select *,Isnull(raw_mat1_percent,0)+Isnull(raw_mat2_percent,0)+Isnull(raw_mat3_percent,0)+Isnull(raw_mat4_percent,0)
                +Isnull(raw_mat5_percent,0) AS percent_total FROM dbo.development_pvh WHERE serial_no='{0}'", txtSerial_no.Text);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(strsql);
            using (xrDevelopmentPvh rpt = new xrDevelopmentPvh() { DataSource = dtReport })
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
                txtDate.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                string max_serial_no = clsTommyTest.GetSeqNo("development_pvh", "serial_no");
                txtSerial_no.Text = max_serial_no;
                //txtPvh_submit_ref.Text = clsDevelopentPvh.GetPvhNo(txtSerial_no.Text);
                txtPvh_submit_ref.Text = "";
                mState = "NEW";
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

        private void chksubmit1_MouseUp(object sender, MouseEventArgs e)
        {
            SetSubmitValue(chksubmit1, "submit1");
        }

        private void chksubmit2_MouseUp(object sender, MouseEventArgs e)
        {
            SetSubmitValue(chksubmit2, "submit2");
        }

        private void chksubmit3_MouseUp(object sender, MouseEventArgs e)
        {
            SetSubmitValue(chksubmit3, "submit3");
        }

        private void chkurgent_bulk_order_MouseUp(object sender, MouseEventArgs e)
        {
            SetSubmitValue(chkurgent_bulk_order, "urgent_bulk_order");
        }

        private void SetSubmitValue(DevExpress.XtraEditors.CheckEdit obj,string SubmitName)
        {
            int current_index = dgvDetails.CurrentRow.Index;
            if (obj.Checked)
            {
                dgvDetails.CurrentRow.Cells[SubmitName].Value = true;
            }
            else
            {
                dgvDetails.CurrentRow.Cells[SubmitName].Value = false;
            }
        }

        private void txtPvh_submit_ref1_Leave(object sender, EventArgs e)
        {
            txtPvh_submit_ref2.Text = txtPvh_submit_ref1.Text;
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

        private void txtMo_id2_Leave(object sender, EventArgs e)
        {
            if (mState != "" && txtMo_id2.Text != "")
            {
                DataTable dtMo = clsDevelopentPvh.GetPvhCustomerInfo(txtMo_id2.Text);
                if (dtMo.Rows.Count > 0)
                {
                    txtPlm_material_code.Text = dtMo.Rows[0]["customer_goods"].ToString();
                    txtSupplier_ref_no.Text = dtMo.Rows[0]["artwork"].ToString();
                    txtColour.Text = dtMo.Rows[0]["customer_color_name"].ToString();
                    txtSize.Text = dtMo.Rows[0]["customer_size"].ToString();
                }
                else
                {
                    txtPlm_material_code.Text = "";
                    txtSupplier_ref_no.Text = "";
                    txtColour.Text = "";
                    txtSize.Text = "";
                }
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

        private void lueRaw_mat1_compostion_EditValueChanged(object sender, EventArgs e)
        {
            clsDevelopentPvh.SetCountry(lueRaw_mat1_compostion, lueRaw_mat1_l3, lueRaw_mat1_l4);           
        }

        private void lueRaw_mat2_compostion_EditValueChanged(object sender, EventArgs e)
        {
            //clsDevelopentPvh.SetCountry(lueRaw_mat2_compostion, lueRaw_mat2_l3);
            clsDevelopentPvh.SetCountry(lueRaw_mat2_compostion, lueRaw_mat2_l3, lueRaw_mat2_l4);
        }

        private void lueRaw_mat3_compostion_EditValueChanged(object sender, EventArgs e)
        {
            //clsDevelopentPvh.SetCountry(lueRaw_mat3_compostion, lueRaw_mat3_l3);
            clsDevelopentPvh.SetCountry(lueRaw_mat3_compostion, lueRaw_mat3_l3, lueRaw_mat3_l4);
        }

        private void txtProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CallContents(txtProcess, "processes");
            //if (mState == "NEW" || mState == "EDIT")
            //{
            //    /*Point screenPoint = Control.MousePosition;//鼠标相对于屏幕左上角的坐标
            //    Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
            //    同理：Point button1Point= button1Point.PointToClient(Control.MousePosition);//鼠标相对于button1左上角的坐标
            //    还有Control.PointToScreen方法，返回的是相对于屏幕的坐标。
            //    */
            //    Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
            //    using (frmPvhProcess ofrm = new frmPvhProcess("processes"))
            //    {
            //        ofrm.StartPosition = FormStartPosition.Manual;
            //        ofrm.Location= new Point(formPoint.X, formPoint.Y);
            //        ofrm.ShowDialog();
            //        if (ofrm.strProcess != "")
            //        {
            //            txtProcess.EditValue = ofrm.strProcess;
            //        }
            //    }
            //}
        }

        private void txtFinish_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CallContents(txtFinish,"finish");
        }
        //
        private void txtDye_type_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CallContents(txtDye_type, "dye_type");
        }

        private void txtDye_method_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CallContents(txtDye_method, "dye_method");
        }

        private void CallContents(DevExpress.XtraEditors.ButtonEdit obj,string field_type)
        {
            if (mState == "NEW" || mState == "EDIT")
            {
                /*Point screenPoint = Control.MousePosition;//鼠标相对于屏幕左上角的坐标
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                同理：Point button1Point= button1Point.PointToClient(Control.MousePosition);//鼠标相对于button1左上角的坐标
                还有Control.PointToScreen方法，返回的是相对于屏幕的坐标。
                */
                Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                using (frmPvhProcess ofrm = new frmPvhProcess(field_type))
                {
                    ofrm.StartPosition = FormStartPosition.Manual;
                    ofrm.Location = new Point(formPoint.X, formPoint.Y);
                    ofrm.ShowDialog();
                    if (ofrm.strProcess != "")
                    {                        
                        obj.EditValue = ofrm.strProcess;
                    }
                }
            }
        }

        private void ClearContents(DevExpress.XtraEditors.ButtonEdit obj)
        {
            if (mState == "NEW" || mState == "EDIT")
            {              
                obj.EditValue = "";
            }
        }

        //
        public int ConvertToInt(string _val)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(_val))
            {
                result = int.Parse(_val);
            }
            return result;
        }

        private void txtPvh_submit_ref_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mState == "NEW" || mState == "EDIT")
            {
                if (mState == "EDIT" && !string.IsNullOrEmpty(txtPvh_submit_ref.Text))
                {
                    MessageBox.Show("註意: 編輯狀態下已存在的編號不可以再繼續生成新的編號!");
                    return;
                }
                if (lueDivision.Text == "")
                {
                    MessageBox.Show("註意: Division不可以為空 !");
                    lueDivision.Focus();
                    return;
                }
                txtPvh_submit_ref.Text = clsDevelopentPvh.GetPvhNo(txtSerial_no.Text,lueDivision.EditValue.ToString());
            }
        }

        private void lueCert1_type_EditValueChanged(object sender, EventArgs e)
        {
            clsDevelopentPvh.SetCertificate(lueCert1_type, txtCert1_scope_no, txtCert1_expiry_date, txtCert1_scope_holder);
        }
        private void lueCert2_type_EditValueChanged(object sender, EventArgs e)
        {
            clsDevelopentPvh.SetCertificate(lueCert2_type, txtCert2_scope_no, txtCert2_expiry_date, txtCert2_scope_holder);
        }
        private void lueCert3_type_EditValueChanged(object sender, EventArgs e)
        {
            clsDevelopentPvh.SetCertificate(lueCert3_type, txtCert3_scope_no, txtCert3_expiry_date, txtCert3_scope_holder);
        }

        private void dgvFind_Sorted(object sender, EventArgs e)
        {
            ResetSortedDataSource();
        }
        private void dgvDetails_Sorted(object sender, EventArgs e)
        {
            ResetSortedDataSource();
        }

        private void txtFinish_DoubleClick(object sender, EventArgs e)
        {
            ClearContents(txtFinish);
        }

        private void txtProcess_DoubleClick(object sender, EventArgs e)
        {
            ClearContents(txtProcess);
        }

        private void txtDye_method_DoubleClick(object sender, EventArgs e)
        {
            ClearContents(txtDye_method);
        }

        private void txtDye_type_DoubleClick(object sender, EventArgs e)
        {
            ClearContents(txtDye_type);
        }

        
        private void ResetSortedDataSource()
        {
            if (dtDetail.Rows.Count > 0)
            {
                dtDetail = dtDetail.DefaultView.ToTable();//排序后重新賦數據源,否則出現新增后保存成功,但實際后臺并沒有保存成功的情況
                bds1.DataSource = dtDetail;
                dgvDetails.DataSource = bds1;
                dgvFind.DataSource = dtDetail;
            }
        }
    }
}
