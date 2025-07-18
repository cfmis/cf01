﻿/*
 * Create Date:2016-03-05
 * Create by Allen Leung
 * 程序備註：
 *  HK PDD 產品定價資料
 * 1、從各組EXCEL報價表中改入數據，導出
 * 2、要新版本功能，可根據查出的數據生成報價單
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using System.Data.Common;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using System.Reflection;
using cf01.MDL;
using System.Threading;
using cf01.MM;
using System.ComponentModel;

namespace cf01.Forms
{
    public partial class frmQuotation : Form
    {
        clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        string pID = "";    //臨時的主鍵值
        string editState = ""; //新增或編號的狀態
        string editStateCopy = "";
        string oldTempCode = "";
        string oldGroup = "";
        string imagePath = "";
        string strLanguage = "0";
        string msgCustom;
        int cur_row_index;
        int rowReset = 0;
        string strTempCode = "";
        string cur_temp_code = "";
        string lange = DBUtility._language;//保存當前登彔的語言
        System.Data.DataTable dtDetail = new System.Data.DataTable();
        public System.Data.DataTable dtReSet = new System.Data.DataTable();
        System.Data.DataTable dtVersion = new System.Data.DataTable();
        System.Data.DataTable dtSubmo = new System.Data.DataTable();
        System.Data.DataTable dtPriceDisc= new System.Data.DataTable();
        System.Data.DataTable dtPermiss = new System.Data.DataTable();
        clsAppPublic clsApp = new clsAppPublic();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        DataGridViewRow dgvrow = new DataGridViewRow();
        public static string sent_quotation = "";
        BindingSource bds1 = new BindingSource();
        bool is_group_pdd { set; get; }
        //bool flag_import;
        string strFileExcel = "";
        frmQuotationFind frmQuotationFind;
        ListSortDirection sortDirection;//排序方式
        string sortColumnName = "";

        public frmQuotation()
        {
            InitializeComponent(); 

            //舊的菜單按鈕的權限及翻譯
            //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            //control.GenerateContorl();
            //控件翻譯
            clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
            obj_ctl.Translate();
            //設置菜單按鈕的權限                          
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();                
            clsApp.RetSetImage(toolStrip1);
            
            dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
          
            dtDetail = clsQuotation.GetQuotationStrutre();//空的表結構
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;// dtDetail;
            dtPermiss = clsQuotation.GetPermissions(DBUtility._user_id);//暫存折扣單價表權限
        }

        private void frmQuotation_Load(object sender, EventArgs e)
        {            
            clsQuotation.Set_Unit(txtPrice_unit);//數量單位            
            clsQuotation.Set_Unit(txtMoq_unit);
            clsQuotation.Set_Unit(txtMwq_unit);
            clsQuotation.Set_Unit(txtMd_charge_unit);

            System.Data.DataTable dtMoney = clsConErp.GetDataTable(@"SELECT '' as id,'' as cdesc Union SELECT id,name as cdesc FROM dbo.cd_money WHERE state='0'");
            txtMd_charge_cny.Properties.DataSource = dtMoney;
            txtMd_charge_cny.Properties.ValueMember = "id";
            txtMd_charge_cny.Properties.DisplayMember = "id";

            txtDie_mould_cny.Properties.DataSource = dtMoney;
            txtDie_mould_cny.Properties.ValueMember = "id";
            txtDie_mould_cny.Properties.DisplayMember = "id";


            System.Data.DataTable dtUnit_moq = new System.Data.DataTable();
            dtUnit_moq.Columns.Add("id", typeof(string));
            dtUnit_moq.Rows.Add(new object[] { "" });
            dtUnit_moq.Rows.Add(new object[] { "Working Days" });
            dtUnit_moq.Rows.Add(new object[] { "Weeks" });
            dtUnit_moq.Rows.Add(new object[] { "Months" });
            txtLead_time_unit.Properties.DataSource = dtUnit_moq;
            txtLead_time_unit.Properties.ValueMember = "id";
            txtLead_time_unit.Properties.DisplayMember = "id";

            string strSql = @"Select typ_code AS id,typ_code+' ('+typ_cdesc+')' AS cdesc From bs_type Where typ_group='3'";
            System.Data.DataTable dtSales_Group = new System.Data.DataTable();
            dtSales_Group = clsPublicOfCF01.GetDataTable(strSql);
            txtSales_group.Properties.DataSource = dtSales_Group;
            txtSales_group.Properties.ValueMember = "id";
            txtSales_group.Properties.DisplayMember = "cdesc";

            clsQuotation.Set_Brand_id(txtBrand);

            //strSql = @"Select '' as id,'' as cdesc union Select id,name as cdesc From cd_season Order by id";
            strSql = @"Select '' as id,'' as cdesc Union Select id,name as cdesc From cd_season where state='0' Order by id";
            System.Data.DataTable dtSeason = new System.Data.DataTable();
            dtSeason = clsConErp.GetDataTable(strSql);
            txtSeason.Properties.DataSource = dtSeason;
            txtSeason.Properties.ValueMember = "id";
            txtSeason.Properties.DisplayMember = "cdesc";

            //POLO CARE
            strSql = @"Select '' as id,'' as cdesc Union SELECT typ_code as id,typ_cdesc as cdesc FROM bs_type WHERE typ_group='AB'";
            System.Data.DataTable dtPoloCare = new System.Data.DataTable();
            dtPoloCare = clsPublicOfCF01.GetDataTable(strSql);
            txtPolo_care.Properties.DataSource = dtPoloCare;
            txtPolo_care.Properties.ValueMember = "id";
            txtPolo_care.Properties.DisplayMember = "cdesc";

            //單價更改原因
            strSql = @"Select '' as id,'' as cdesc Union SELECT typ_code as id,typ_cdesc as cdesc FROM bs_type WHERE typ_group='Z9'";
            System.Data.DataTable dtReason = new System.Data.DataTable();
            dtReason = clsPublicOfCF01.GetDataTable(strSql);
            txtReason_edit.Properties.DataSource = dtReason;
            txtReason_edit.Properties.ValueMember = "id";
            txtReason_edit.Properties.DisplayMember = "cdesc";

            //Labtest 產品類型
            strSql = @"Select '' as id,'' as name Union SELECT id,name FROM quotation_labtest_product order by id";
            System.Data.DataTable dtLabtest = new System.Data.DataTable();
            dtLabtest = clsPublicOfCF01.GetDataTable(strSql);
            lueLabtest.Properties.DataSource = dtLabtest;
            lueLabtest.Properties.ValueMember = "id";
            lueLabtest.Properties.DisplayMember = "name";

            //GEO 物料類型
            strSql = @"Select '' as id,'' as name,'' as english_name Union SELECT id,name,english_name FROM cd_datum WHERE state<>'2' Order By id";
            System.Data.DataTable dtMat = new System.Data.DataTable();
            dtMat = clsConErp.GetDataTable(strSql);
            lueMaterial_type.Properties.DataSource = dtMat;
            lueMaterial_type.Properties.ValueMember = "id";
            lueMaterial_type.Properties.DisplayMember = "id";
            //GEO 產品類型
            strSql = @"SELECT id,name,english_name FROM cd_goods_class  WHERE state<>'2' ORDER BY ID";
            System.Data.DataTable dtProdType = new System.Data.DataTable();
            dtProdType = clsConErp.GetDataTable(strSql);
            lueProduct_type.Properties.DataSource = dtProdType;
            lueProduct_type.Properties.ValueMember = "id";
            lueProduct_type.Properties.DisplayMember = "id";
            //CF顏色ID
            strSql = @"Select id,do_color from cd_color where state='0' order by id";
            System.Data.DataTable dtColor = new System.Data.DataTable();
            dtColor = clsConErp.GetDataTable(strSql);
            lueCf_color_id.Properties.DataSource = dtColor;
            lueCf_color_id.Properties.ValueMember = "id";
            lueCf_color_id.Properties.DisplayMember = "id";

            gridView1.IndicatorWidth = 50;
            tabPage2.Parent = null;

            //顯示PDD備註            
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = clsQuotation.GetUserGroup();
            if (dt.Rows.Count == 0)
            {
                if (DBUtility._user_id.ToUpper() != "ADMIN")
                {
                    pnlRemarkPDD.Visible = false;
                    pnlRemarkPDD_dg.Visible = false;
                    remark_pdd.Visible = false;
                    remark_pdd_dg.Visible = false;
                    gridColumn18.Visible = false;
                    gridColumn19.Visible = false;
                    is_group_pdd = false;
                }
                else
                {
                    pnlRemarkPDD.Visible = true;
                    pnlRemarkPDD_dg.Visible = true;
                    remark_pdd.Visible = true;
                    remark_pdd_dg.Visible = true;
                    gridColumn18.Visible = true;
                    gridColumn19.Visible = true;
                    is_group_pdd = true; //是否可查看歷史單價
                }
            }
            else
            {
                if (dt.Rows[0]["group_id"].ToString() == "HK_PDD")
                {
                    pnlRemarkPDD.Visible = true;
                    remark_pdd.Visible = true;
                    gridColumn18.Visible = true;

                    pnlRemarkPDD_dg.Visible = true;
                    remark_pdd_dg.Visible = true;
                    gridColumn19.Visible = true;
                }
                if (dt.Rows[0]["group_id"].ToString() == "DG_PDD")
                {
                    pnlRemarkPDD_dg.Visible = true;
                    remark_pdd_dg.Visible = true;
                    gridColumn19.Visible = true;
                }
                is_group_pdd = true;//是否可查看歷史單價
            }

            dgvDetails.AutoGenerateColumns = false;
            Init_Column_isEnable();

            //判斷開啟當前程序Host所處的IP地址段
            string ls_ip_address = clsApp.GetLocalIP();
            if (ls_ip_address.Contains("192.168.3."))
            {
                imagePath = @"\\192.168.3.12\cf_artwork";
            }
            if (ls_ip_address.Contains("192.168.168."))
            {
                imagePath = @"\\192.168.168.15\cf_artwork";
            }
            if (ls_ip_address.Contains("192.168.18."))
            {
                imagePath = @"\\192.168.18.24\cf_artwork";                            
            }
            //數據綁定
            SetDataBindings();
            //當PDD備註隱藏時重新調整表格位置以顯示更多內容          
            /*cancel old code 2024/10/28
            if (!is_group_pdd)
            {
                pnlHead.Height = 400;
                this.tabControl1.Location = new System.Drawing.Point(-3, 440);
                Screen screen = Screen.PrimaryScreen;
                int screen_width = screen.Bounds.Width;
                int screen_height = screen.Bounds.Height;
                this.pnlHead.Width = screen_width - 10;
                this.tabControl1.Width = screen_width - 2;
                this.tabControl1.Height = screen_height - (pnlHead.Height + toolStrip1.Height + 115);
            }*/
        }
       
        private void SetDataBindings()
        {
            txtID.DataBindings.Add("Text", bds1, "id");
            txtSales_group.DataBindings.Add("EditValue", bds1, "sales_group");          
            txtDate.DataBindings.Add("EditValue", bds1, "date");            
            txtTemp_code.DataBindings.Add("Text", bds1, "temp_code"); 
            txtBrand.DataBindings.Add("EditValue", bds1, "brand"); 
            txtBrandDesc.DataBindings.Add("Text", bds1, "brand_desc"); 
            txtSeason.DataBindings.Add("EditValue", bds1, "season");
            txtSeasonDesc.DataBindings.Add("Text", bds1, "season_desc"); 
            txtFormula.DataBindings.Add("Text", bds1, "formula_id");  
            txtDivision.DataBindings.Add("Text", bds1, "division");
            txtContact.DataBindings.Add("Text", bds1, "contact");
            txtMaterial.DataBindings.Add("Text", bds1, "material");
            txtSize.DataBindings.Add("Text", bds1, "size"); 
            txtProduct_desc.DataBindings.Add("Text", bds1, "product_desc");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtRemark_other.DataBindings.Add("Text", bds1, "remark_other"); 
            txtCust_code.DataBindings.Add("Text", bds1, "cust_code");
            txtCf_code.DataBindings.Add("Text", bds1, "cf_code");
            txtCust_color.DataBindings.Add("Text", bds1, "cust_color");
            txtCf_color.DataBindings.Add("Text", bds1, "cf_color"); 
            txtNumber_enter.DataBindings.Add("Text", bds1, "number_enter"); 
            txtPrice_usd.DataBindings.Add("Text", bds1, "price_usd");
            txtPrice_hkd.DataBindings.Add("Text", bds1, "price_hkd");
            txtPrice_rmb.DataBindings.Add("Text", bds1, "price_rmb");
            txtPrice_vnd.DataBindings.Add("Text", bds1, "price_vnd");
            txtPrice_unit.DataBindings.Add("EditValue", bds1, "price_unit");
            txtSalesman.DataBindings.Add("Text", bds1, "salesman");
            cmbmoq_below_over.DataBindings.Add("EditValue", bds1, "moq_below_over");
            txtMoq.DataBindings.Add("EditValue", bds1, "moq"); 
            txtMoq_Desc.DataBindings.Add("Text", bds1, "moq_desc");
            txtMoq_unit.DataBindings.Add("EditValue", bds1, "moq_unit");
            txtMwq.DataBindings.Add("EditValue", bds1, "mwq");
            txtMwq_unit.DataBindings.Add("EditValue", bds1, "mwq_unit");

            txtLead_time_min.DataBindings.Add("EditValue", bds1, "lead_time_min");
            txtLead_time_max.DataBindings.Add("EditValue", bds1, "lead_time_max");
            txtLead_time_unit.DataBindings.Add("EditValue", bds1, "lead_time_unit");
            txtMd_charge.DataBindings.Add("EditValue", bds1, "md_charge");
            txtMd_charge_cny.DataBindings.Add("EditValue", bds1, "md_charge_cny"); 
            txtMd_charge_unit.DataBindings.Add("EditValue", bds1, "md_charge_unit");
            txtDie_mould_usd.DataBindings.Add("EditValue", bds1, "die_mould_usd"); 
            txtDie_mould_cny.DataBindings.Add("EditValue", bds1, "die_mould_cny");
            txtAccount_code.DataBindings.Add("Text", bds1, "account_code");           
            txtValid_date.DataBindings.Add("EditValue", bds1, "valid_date");           
            txtHkd_ex_fty.DataBindings.Add("EditValue", bds1, "hkd_ex_fty");
            txtUsd_ex_fty.DataBindings.Add("EditValue", bds1, "usd_ex_fty");
            txtDate_req.DataBindings.Add("Text", bds1, "date_req");
            txtAw.DataBindings.Add("Text", bds1, "aw");
            txtStatus.DataBindings.Add("EditValue", bds1, "status"); //??
            txtSample_request.DataBindings.Add("Text", bds1, "sample_request");
            txtNeedle_test.DataBindings.Add("Text", bds1, "needle_test");
            txtVersion.DataBindings.Add("Text", bds1, "ver");
            txtMo_id.DataBindings.Add("Text", bds1, "mo_id");
            memRemark_pdd.DataBindings.Add("Text", bds1, "remark_pdd");
            
            txtCrusr.DataBindings.Add("Text", bds1, "crusr");
            txtCrtim.DataBindings.Add("Text", bds1, "crtim");
            txtAmusr.DataBindings.Add("Text", bds1, "amusr");
            txtAmtim.DataBindings.Add("Text", bds1, "amtim");
            txtComment.DataBindings.Add("Text", bds1, "comment");
            txtPolo_care.DataBindings.Add("EditValue", bds1, "polo_care");
            txtMoq_for_test.DataBindings.Add("EditValue", bds1, "moq_for_test");
            
            txtPlm_code.DataBindings.Add("Text", bds1, "plm_code");
            txtTrim_color_code.DataBindings.Add("Text", bds1, "trim_color_code"); 
            txtTest_sample_hk.DataBindings.Add("Text", bds1, "test_sample_hk");
            txtSms.DataBindings.Add("Text", bds1, "sms");
            txtSample_card.DataBindings.Add("Text", bds1, "sample_card");
            txtMeeting_recap.DataBindings.Add("Text", bds1, "meeting_recap");
            txtUsd_dap.DataBindings.Add("EditValue", bds1, "usd_dap");
            txtUsd_lab_test_prx.DataBindings.Add("EditValue", bds1, "usd_lab_test_prx");
            txtEx_fty_hkd.DataBindings.Add("EditValue", bds1, "ex_fty_hkd");
            txtEx_fty_usd.DataBindings.Add("EditValue", bds1, "ex_fty_usd");
            
            txtDisc.DataBindings.Add("EditValue", bds1, "discount");
            txtDisc_usd.DataBindings.Add("EditValue", bds1, "disc_price_usd");
            txtDisc_hkd.DataBindings.Add("EditValue", bds1, "disc_price_hkd"); 
            txtDisc_rmb.DataBindings.Add("EditValue", bds1, "disc_price_rmb");
            txtDisc_vnd.DataBindings.Add("EditValue", bds1, "disc_price_vnd");
            txtDisc_hkd_ex_fty.DataBindings.Add("EditValue", bds1, "disc_hkd_ex_fty");
            txtReason_edit.DataBindings.Add("EditValue", bds1, "reason_edit"); 

            txtRmb_remark.DataBindings.Add("Text", bds1, "rmb_remark");
            txtPrice_salesperson.DataBindings.Add("EditValue", bds1, "price_salesperson");
            txtPrice_kind.DataBindings.Add("Text", bds1, "price_kind");
            txtRemark_salesperson.DataBindings.Add("Text", bds1, "remark_salesperson");
            txtCustartwork.DataBindings.Add("Text", bds1, "cust_artwork");
            txtCost_price.DataBindings.Add("EditValue", bds1, "cost_price");           
            lueLabtest.DataBindings.Add("EditValue", bds1, "labtest_prod_type");
            txtTermremark.DataBindings.Add("Text", bds1, "termremark");
            memDgRmkPdd.DataBindings.Add("Text", bds1, "remark_pdd_dg");
            txtPending.DataBindings.Add("Text", bds1, "pending");
            txtRef_temp_code.DataBindings.Add("Text", bds1, "ref_temp_code");//txtRef_temp_code目的是想知道由哪一條記錄復制過來.
            txtFlag_new.DataBindings.Add("Text", bds1, "flag_new");
            //2023/02/04 add
            txtFlag_vnd_date.DataBindings.Add("EditValue", bds1, "flag_vnd_date");
            txtVnd_bp.DataBindings.Add("EditValue", bds1, "vnd_bp");
            txtPrice_vnd_usd.DataBindings.Add("EditValue", bds1, "price_vnd_usd");
            txtPrice_vnd.DataBindings.Add("EditValue", bds1, "price_vnd");
            txtPrice_vnd_grs.DataBindings.Add("EditValue", bds1, "price_vnd_grs");
            txtPrice_vnd_pcs.DataBindings.Add("EditValue", bds1, "price_vnd_pcs");
            lueCf_color_id.DataBindings.Add("EditValue", bds1, "cf_color_id");
            lueMaterial_type.DataBindings.Add("EditValue", bds1, "material_type");
            lueProduct_type.DataBindings.Add("EditValue", bds1, "product_type");
            txtMd_charge_vn.DataBindings.Add("Text", bds1, "md_charge_vn");
            txtDie_mould_usd_vn.DataBindings.Add("Text", bds1, "die_mould_usd_vn");
            //復選框的綁定
            //Binding bind = new Binding("Checked", bds1, "flag_vnd");
            Binding bind = new Binding("EditValue", bds1, "flag_vnd");
            bind.Format += (s, e) =>
            {
                //e.Value = (int)e.Value == 1;
                e.Value = e.Value;
            };
            chkFlag_vnd.DataBindings.Add(bind);
            Binding bind_special = new Binding("EditValue", bds1, "special_price");
            bind_special.Format += (s, e) =>
            {                
                e.Value = e.Value;
            };
            chkSpecialPrice.DataBindings.Add(bind_special);
        }

        private void Init_Column_isEnable()
        {
            dgvDetails.Columns[0].ReadOnly = false;//Flag_select column
            for (int i = 1; i < dgvDetails.ColumnCount; i++)
            {
                dgvDetails.Columns[i].ReadOnly = true;
            }
        }
        
        private void txtNumber_enter_Leave(object sender, EventArgs e)
        {            
            if (editState!= "")
            {
                if (string.IsNullOrEmpty(txtPrice_unit.Text))
                {
                    MessageBox.Show("單價單位不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CalcuPrice();                
                CalcuPriceDisc(txtDisc.Text);
                txtRmb_remark.Text = clsQuotation.Get_Rmb_Remark(txtFormula.Text);
            }
        }

        private void CalcuPrice()
        {
            string brand = txtBrand.Text;
            string formula = txtFormula.Text;
            string bp = txtNumber_enter.EditValue.ToString();
            string vn_bp = txtVnd_bp.Text;
            string price_unit = txtPrice_unit.Text;
            bool flag_vnd = chkFlag_vnd.Checked;
            mdlFormula_Result objResult = new mdlFormula_Result();
            objResult = clsQuotation.Get_Cust_Formula(brand, formula, bp, price_unit,vn_bp,flag_vnd);                
            txtPrice_usd.EditValue = objResult.price_usd;
            txtPrice_rmb.EditValue = objResult.price_rmb;
            txtPrice_hkd.EditValue = objResult.price_hkd;
            txtHkd_ex_fty.EditValue = objResult.hkd_ex_fty;
            txtUsd_ex_fty.EditValue = objResult.usd_ex_fty;
            txtPrice_vnd.EditValue = objResult.price_vnd;

            txtVnd_bp.EditValue = objResult.vnd_bp;
            txtPrice_vnd_usd.EditValue = objResult.price_vnd_usd;
            txtPrice_vnd.EditValue = objResult.price_vnd; //原單單位
            txtPrice_vnd_grs.EditValue = objResult.price_vnd_grs; //GRS
            txtPrice_vnd_pcs.EditValue = objResult.price_vnd_pcs; //PCS

            //如果用戶改了折扣率則以用戶的為主，否則用公式中的折扣率
            if (clsApp.Return_Float_Value(txtDisc.Text) == 0)
            {
                txtDisc.EditValue = objResult.discount;
            }
            //2016.10.28取消
            //txtPrice_usd.EditValue = objResult.price_usd;
            //txtPrice_rmb.EditValue = objResult.price_rmb;
            //if (pUnit == "PCS" || pUnit == "SET")             
            //{
            //    txtPrice_hkd.EditValue = objResult.price_hkd;
            //    txtHkd_ex_fty.EditValue = objResult.hkd_ex_fty;
            //}
            //else
            //{
            //    //txtPrice_hkd.EditValue = objResult.price_hkd;
            //    txtPrice_hkd.EditValue = (int)objResult.price_hkd;
            //    //txtHkd_ex_fty.EditValue = objResult.hkd_ex_fty;
            //    txtHkd_ex_fty.EditValue = (int)objResult.hkd_ex_fty;
            //}
        }

        private void txtPrice_unit_Click(object sender, EventArgs e)
        {
            txtPrice_unit.SelectAll();
        }

        private void txtSales_group_Properties_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
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
            Save("1");
           
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        //因查詢初始dgvDetails時 dgvDetails_SelectionChanged()事件中的代碼重復執行多次,有時嚴重景响畫面响應速度
        //增加flag_row_change字段變量,用來控制待畫面正常加載結束,dgvDetails中的SelectionChanged事件方可以正常响应.
        bool flag_row_change = true;
        private void BTNFIND_Click(object sender, EventArgs e)
        {
            flag_row_change = false;
            int curent_row = 0; //從查詢窗體返回當前焦點所在行
            //***********2022/11/16新加代碼,查詢窗體不用關閉
            if (frmQuotationFind == null)
            {
                frmQuotationFind = new frmQuotationFind() { flagCall = "Quotation" };
            }            
            frmQuotationFind.ShowDialog();
            //--start 2022/11/18
            //確定以查詢數據復蓋主窗體數據
            if (frmQuotationFind.flagReturn)
            {
                //有返回數據
                if (frmQuotationFind.dtReturn.Rows.Count > 0)
                {
                    dtDetail = frmQuotationFind.dtReturn.Copy();
                    //重新綁定數據源
                    bds1.DataSource = dtDetail;
                    dgvDetails.DataSource = bds1;
                    curent_row = frmQuotationFind.returnRowIndex;//返回行號 
                    //if (curent_row > 0)
                    if(dtDetail.Rows.Count>0)
                    {
                        //定位到當前行(注意指定的當前列不可以隱藏的)
                        dgvDetails.CurrentCell = dgvDetails.Rows[curent_row].Cells[2]; //设置当前单元格
                        dgvDetails.Rows[curent_row].Selected = true; //選中整行
                        
                        //刷新submo表,折扣單價表2024/06/11.
                        DataGridViewRow dgrw = dgvDetails.CurrentRow;                        
                        Sethead(dgrw);
                    }
                }
            }
            flag_row_change = true;
            //--end
            //*************
            if (dgvDetails.RowCount > 0 )
                lblOf.Text = dgvDetails.RowCount.ToString();
            else            
                lblOf.Text = "";
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
           txtRemark.Focus();
           //Excel1();
           //DvExportExcel();
           //clsQuotation.Export_To_Excel(dgvDetails);//2018/10/23前的舊代碼
           Export_Excel_Art("1");
        }

        private void BTNEXCEL_ART_Click(object sender, EventArgs e)
        {
            txtRemark.Focus();
            Export_Excel_Art("2");
        }


        // ===============以下爲自定義方法=======================

        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNEXCEL.Enabled = _flag;
            BTNNEWCOPY.Enabled = _flag;           
            BTNIMPORT.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            btnApproved.Enabled = _flag;
            btnGroup.Enabled = _flag;
            BTNNEWVER.Enabled = _flag;
            BTNQUOTATION.Enabled = _flag;
            BTNDEL_BATCH.Enabled = _flag;
            btnPriceDisc.Enabled = _flag;

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            //if (txtSales_group.Text == "" || txtCf_code.Text == "" || string.IsNullOrEmpty(txtDate.Text) || txtTemp_code.Text =="")
            //int i = dgvGroup.Rows.Count;
            if (txtSales_group.Text == "" || txtTemp_code.Text == "" || txtCf_code.Text == "" || string.IsNullOrEmpty(txtDate.Text) || txtPrice_unit.Text=="")
            {
                msgCustom= (strLanguage == "2")? "Sales group&CF Code&Date & Price Unit cannot be empty.": "組別,CF Code,日期,或單價單位不可爲空!";                
                MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }


        //private void Set_Row_Position(string _doc) //定位到當前行 
        //{
        //    Find();
        //    for (int i = 0; i < dgvDetails.RowCount; i++)
        //    {
        //        if (_doc == dgvDetails.Rows[i].Cells["id"].Value.ToString())
        //        {
        //            dgvDetails.Rows[i].Selected = true;
        //            dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["sales_group"]; //設置光標定位到當前選中的行
        //            break;
        //        }
        //    }
        //}

        private void AddNew()  //新增
        {
            SetResetID();
            editState= "NEW"; 
            bds1.AddNew();
            
            txtSales_group.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            SetObjValue.ClearObjValue(pnlHead.Controls, "1");
            chkSelectAll.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            txtTemp_code.Properties.ReadOnly = true;
            txtTemp_code.BackColor = System.Drawing.Color.White;
            txtFormula.Properties.ReadOnly = true;           
            txtFormula.BackColor = System.Drawing.Color.White;
            txtBrandDesc.Properties.ReadOnly = true;
            txtBrandDesc.BackColor = System.Drawing.Color.White;
            tabPage2.Parent = null;
            lblIsCalPrice.Visible = false;
            //txtID.Properties.ReadOnly = false;
            dgvDetails.Enabled = false;
            txtDate.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            txtValid_date.EditValue = DateTime.Now.Date.AddDays(30).ToString("yyyy-MM-dd").Substring(0, 10);
            txtCrusr.Text = DBUtility._user_id;
            txtCrtim.Text= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);
            txtPrice_unit.EditValue = "GRS";
            txtMoq_unit.EditValue = "GRS";
            txtLead_time_unit.EditValue = "Weeks";            
            txtMd_charge_unit.EditValue = "SET";
            txtVersion.Text = "0";
            txtTemp_code.Text = clsQuotation.Get_Quote_SeqNo(); //Get_Quote_SeqNo(txtTemp_code.Text);
            txtTemp_code.Focus();
            dgvGroup.DataSource = null;
            dgvSub.DataSource = null;
            dgvPriceDisc.DataSource = null;
            txtFlag_new.Text = "1";
            //txtSales_group.Focus();
        }
        
        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            SetResetID();

            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            tabPage2.Parent = null;
            dgvDetails.Enabled = false;
            editState= "EDIT";            
            txtTemp_code.Properties.ReadOnly = true;
            txtTemp_code.BackColor = System.Drawing.Color.White;
            txtFormula.Properties.ReadOnly = true;            
            txtFormula.BackColor = System.Drawing.Color.White;
            txtBrandDesc.Properties.ReadOnly = true;
            txtBrandDesc.BackColor = System.Drawing.Color.White;
            chkSelectAll.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            //txtSales_group.Properties.ReadOnly = true;
            //txtSales_group.BackColor = System.Drawing.Color.White;
            //txtID.Properties.ReadOnly = true;
            //txtID.BackColor = System.Drawing.Color.White;
        }

        private void Cancel() //取消
        {
            bds1.CancelEdit();
            SetButtonSatus(true);            
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            chkSelectAll.Enabled = true;
            txtID.Properties.ReadOnly = false;
            txtID.Enabled = true;
            txtSales_group.Properties.ReadOnly = false;
            dgvDetails.Enabled = true;
            Init_Column_isEnable();            

            editState= "";
            editStateCopy = "";
            tabPage2.Parent = null;

            /*
            if (!String.IsNullOrEmpty(pID) && dgvDetails.RowCount>0)
            {
                dgvDetails.Focus();
                dgvDetails.CurrentCell = dgvDetails.Rows[rowReset].Cells[2]; //设置当前单元格
                dgvDetails.Rows[rowReset].Selected = true; //選中整行
            }
             */

            //dgvDetails.FirstDisplayedScrollingRowIndex = 0;
            //如原來有排序則恢復
            if (sortColumnName != "")
            {
                this.dgvDetails.Sort(dgvDetails.Columns[sortColumnName], sortDirection);
            }         
            if(!string.IsNullOrEmpty(pID) && dgvDetails.RowCount > 0)
            {
                int index = 0;
                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    //获取第i行，列名是列名A的单元格的值
                    if (pID == row.Cells["id"].Value.ToString())
                    {
                        index = row.Index;
                        break;
                    }
                }
                dgvDetails.CurrentCell = dgvDetails.Rows[index].Cells[2];//定位当前单元格
                dgvDetails.Rows[index].Selected = true; //選中整行               
            }
                   
        }
        private void SaveSortInfo()
        {
            //保存排序信息
            if(dgvDetails.Rows.Count==0)
            {
                sortColumnName = "";
                return;
            }
            sortColumnName = "";
            if (dgvDetails.SortOrder.ToString() != "None")
            {
                //表格某列有排序 //return value is : Ascending,Descending or None
                sortColumnName = dgvDetails.SortedColumn.Name;//獲取有排序的列的名稱
                string strSort = dgvDetails.SortOrder.ToString();//獲取有排序列的排序方式 Descending
                //DataGridViewColumn SortColumn = dgvDetails.CurrentCell.OwningColumn;//當前列對象
                //ListSortDirection sortDirection;
                if (strSort == "Ascending")
                {
                    sortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    sortDirection = ListSortDirection.Descending;
                }
                //this.dgvDetails.Sort(dgvDetails.Columns[sortColumnName], sortDirection);
                //this.dgvDetails.Sort(dgvDetails.Columns[SortColumn.Index], ListSortDirection.Ascending);
            }
        }

        private void Save(string pType) //保存新增或修改的資料
        {
            txtTemp_code.Focus();
            if (!Save_Before_Valid())
            {
                return;
            }               
            bds1.EndEdit();//結束修改,立即與綁定數據源一致                    
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO quotation(sales_group,temp_code,date,brand,brand_desc,formula_id,season,season_desc,division,contact,material,size,product_desc,
                    cust_code,cf_code,cust_color,cf_color,price_usd,price_hkd,price_rmb,price_unit,salesman,moq_below_over,moq,moq_desc,moq_unit,mwq,mwq_unit,
                    lead_time_min,lead_time_max,lead_time_unit,md_charge,md_charge_cny,md_charge_unit,remark,remark_other,die_mould_usd,die_mould_cny,
                    account_code,valid_date,number_enter,hkd_ex_fty,date_req,aw,status,sample_request,needle_test,ver,crusr,crtim,comment,remark_pdd,mo_id,
                    polo_care,moq_for_test,plm_code,trim_color_code,test_sample_hk,sms,sample_card,meeting_recap,usd_dap,usd_lab_test_prx,ex_fty_hkd,ex_fty_usd,
                    discount,disc_price_usd,disc_price_hkd,disc_price_rmb,disc_hkd_ex_fty, usd_ex_fty,reason_edit,rmb_remark,special_price,cust_artwork,cost_price,
                    labtest_prod_type,termremark,pending,remark_pdd_dg,ref_temp_code,price_vnd,disc_price_vnd, flag_vnd_date,flag_vnd,vnd_bp,price_vnd_usd,
                    price_vnd_grs,price_vnd_pcs,cf_color_id,material_type,product_type,md_charge_vn,die_mould_usd_vn)
            VALUES(@sales_group,@temp_code,CASE LEN(@date) WHEN 0 THEN null ELSE @date END,@brand,@brand_desc,@formula_id,@season,@season_desc,@division,@contact,
                    @material,@size,@product_desc, @cust_code,@cf_code,@cust_color,@cf_color,@price_usd,@price_hkd,@price_rmb,@price_unit,@salesman,@moq_below_over,
                    @moq,@moq_desc,@moq_unit,@mwq,@mwq_unit,@lead_time_min,@lead_time_max,@lead_time_unit,@md_charge,@md_charge_cny,@md_charge_unit,@remark,@remark_other,
                    @die_mould_usd,@die_mould_cny,@account_code,CASE LEN(@valid_date) WHEN 0 THEN null ELSE @valid_date END,@number_enter,@hkd_ex_fty,@date_req,@aw,
                    @status,@sample_request, @needle_test,@ver,@user_id,getdate(),@comment,@remark_pdd,@mo_id,@polo_care,@moq_for_test,@plm_code,@trim_color_code,
                    @test_sample_hk,@sms,@sample_card,@meeting_recap,@usd_dap,@usd_lab_test_prx,@ex_fty_hkd,@ex_fty_usd,@discount,@disc_price_usd,@disc_price_hkd,
                    @disc_price_rmb,@disc_hkd_ex_fty,@usd_ex_fty,@reason_edit,@rmb_remark,@special_price,@cust_artwork,@cost_price,@labtest_prod_type,@termremark,
                    @pending,@remark_pdd_dg,@ref_temp_code,@price_vnd,@disc_price_vnd, CASE LEN(@flag_vnd_date) WHEN 0 THEN null ELSE @flag_vnd_date END,
                    @flag_vnd,@vnd_bp,@price_vnd_usd,@price_vnd_grs,@price_vnd_pcs,@cf_color_id,@material_type,@product_type,@md_charge_vn,@die_mould_usd_vn)";
            const string sql_update =
            @"UPDATE quotation 
            SET sales_group=@sales_group,date=CASE LEN(@date) WHEN 0 THEN null ELSE @date END,brand=@brand,brand_desc=@brand_desc,formula_id=@formula_id,
                season=@season,season_desc=@season_desc,division=@division,contact=@contact,material=@material,size=@size,product_desc=@product_desc,
                cust_code=@cust_code,cf_code=@cf_code,cust_color=@cust_color,cf_color=@cf_color,price_usd=@price_usd,price_hkd=@price_hkd,price_rmb=@price_rmb,
                price_unit=@price_unit,salesman=@salesman,moq_below_over=@moq_below_over,moq=@moq,moq_desc=@moq_desc,moq_unit=@moq_unit,mwq=@mwq,mwq_unit=@mwq_unit,
                lead_time_min=@lead_time_min,lead_time_max=@lead_time_max,lead_time_unit=@lead_time_unit,md_charge=@md_charge,md_charge_cny=@md_charge_cny,
                md_charge_unit=@md_charge_unit,remark=@remark,remark_other=@remark_other,die_mould_usd=@die_mould_usd,die_mould_cny=@die_mould_cny,account_code=@account_code,
                valid_date = CASE LEN(@valid_date) WHEN 0 THEN null ELSE @valid_date END, number_enter=@number_enter,hkd_ex_fty=@hkd_ex_fty, date_req=@date_req,
                aw=@aw,status=@status,sample_request=@sample_request,needle_test=@needle_test,ver=@ver,amusr=@user_id,amtim=Getdate(),comment=@comment,remark_pdd=@remark_pdd,
                mo_id=@mo_id, polo_care=@polo_care,moq_for_test=@moq_for_test, plm_code=@plm_code,trim_color_code=@trim_color_code,test_sample_hk=@test_sample_hk,
                sms=@sms,sample_card=@sample_card,meeting_recap=@meeting_recap,usd_dap=@usd_dap,usd_lab_test_prx=@usd_lab_test_prx,ex_fty_hkd=@ex_fty_hkd,
                ex_fty_usd=@ex_fty_usd,discount=@discount,disc_price_usd=@disc_price_usd,disc_price_hkd=@disc_price_hkd,disc_price_rmb=@disc_price_rmb,
                disc_hkd_ex_fty=@disc_hkd_ex_fty,usd_ex_fty=@usd_ex_fty,reason_edit=@reason_edit,rmb_remark=@rmb_remark,special_price=@special_price,
                cust_artwork=@cust_artwork,cost_price=@cost_price,labtest_prod_type=@labtest_prod_type,termremark=@termremark,pending=@pending,
                remark_pdd_dg=@remark_pdd_dg,ref_temp_code=@ref_temp_code,price_vnd=@price_vnd,disc_price_vnd=@disc_price_vnd,
                flag_vnd_date= CASE LEN(@flag_vnd_date) WHEN 0 THEN null ELSE @flag_vnd_date END, flag_vnd=@flag_vnd,vnd_bp=@vnd_bp,
                price_vnd_usd=@price_vnd_usd,price_vnd_grs=@price_vnd_grs,price_vnd_pcs=@price_vnd_pcs,cf_color_id=@cf_color_id,
                material_type=@material_type,product_type=@product_type,md_charge_vn=@md_charge_vn,die_mould_usd_vn=@die_mould_usd_vn
            WHERE temp_code=@temp_code";

            //組別設置
            string sql_group_i =
                @"INSERT INTO quotation_group(temp_code,seq_id,group_id,crusr,crtim) VALUES(@temp_code,@seq_id,@group_id,@user_id,getdate())";
            string sql_group_u = @"UPDATE quotation_group SET group_id=@group_id,amusr=@user_id,amtim=getdate() WHERE temp_code=@temp_code And group_id=@old_group_id";
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    if (editState== "NEW")
                    {
                        myCommand.CommandText = sql_new;
                        strTempCode = clsQuotation.Get_Quote_SeqNo();//Get_Quote_SeqNo(txtSales_group.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@temp_code", strTempCode);
                        txtTemp_code.Text = strTempCode;                       
                    }
                    else
                    {
                        //editState== "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                        myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text);
                        strTempCode = txtTemp_code.Text;
                    }
                    this.cur_temp_code = txtTemp_code.Text;                   
                    myCommand.Parameters.AddWithValue("@sales_group", txtSales_group.EditValue);                   
                    myCommand.Parameters.AddWithValue("@date",clsApp.Return_String_Date(txtDate.EditValue.ToString()));
                    myCommand.Parameters.AddWithValue("@brand", txtBrand.EditValue);
                    myCommand.Parameters.AddWithValue("@brand_desc", txtBrandDesc.Text);
                    myCommand.Parameters.AddWithValue("@formula_id", txtFormula.Text);              
                    myCommand.Parameters.AddWithValue("@season", txtSeason.EditValue);
                    myCommand.Parameters.AddWithValue("@season_desc", txtSeasonDesc.Text);
                    myCommand.Parameters.AddWithValue("@division", txtDivision.Text);
                    myCommand.Parameters.AddWithValue("@contact", txtContact.Text);
                    myCommand.Parameters.AddWithValue("@material", txtMaterial.Text);
                    myCommand.Parameters.AddWithValue("@size", txtSize.Text);
                    myCommand.Parameters.AddWithValue("@product_desc", txtProduct_desc.Text);
                    myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                    myCommand.Parameters.AddWithValue("@remark_other", txtRemark_other.Text);
                    myCommand.Parameters.AddWithValue("@cust_code", txtCust_code.Text);
                    myCommand.Parameters.AddWithValue("@cf_code", txtCf_code.Text);
                    myCommand.Parameters.AddWithValue("@cust_color", txtCust_color.Text);
                    myCommand.Parameters.AddWithValue("@cf_color", txtCf_color.Text);
                    myCommand.Parameters.AddWithValue("@price_usd", clsApp.Return_Float_Value(txtPrice_usd.Text));
                    myCommand.Parameters.AddWithValue("@price_hkd", clsApp.Return_Float_Value(txtPrice_hkd.Text));
                    myCommand.Parameters.AddWithValue("@price_rmb", clsApp.Return_Float_Value(txtPrice_rmb.Text));
                    myCommand.Parameters.AddWithValue("@price_unit", txtPrice_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@salesman", txtSalesman.Text);
                    myCommand.Parameters.AddWithValue("@moq_below_over", cmbmoq_below_over.Text);
                    myCommand.Parameters.AddWithValue("@moq", clsApp.Return_Float_Value(txtMoq.Text));
                    myCommand.Parameters.AddWithValue("@moq_desc", txtMoq_Desc.Text);
                    myCommand.Parameters.AddWithValue("@moq_unit", txtMoq_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@mwq", clsApp.Return_Float_Value(txtMwq.Text));
                    myCommand.Parameters.AddWithValue("@mwq_unit", txtMwq_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@lead_time_min", clsApp.Return_Float_Value(txtLead_time_min.Text));
                    myCommand.Parameters.AddWithValue("@lead_time_max", clsApp.Return_Float_Value(txtLead_time_max.Text));
                    myCommand.Parameters.AddWithValue("@lead_time_unit", txtLead_time_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@md_charge", clsApp.Return_Float_Value(txtMd_charge.Text));
                    myCommand.Parameters.AddWithValue("@md_charge_cny", txtMd_charge_cny.EditValue);
                    myCommand.Parameters.AddWithValue("@md_charge_unit", txtMd_charge_unit.EditValue);
                    myCommand.Parameters.AddWithValue("@die_mould_usd", clsApp.Return_Float_Value(txtDie_mould_usd.Text));
                    myCommand.Parameters.AddWithValue("@die_mould_cny", txtDie_mould_cny.EditValue);
                    myCommand.Parameters.AddWithValue("@account_code", txtAccount_code.Text);
                    myCommand.Parameters.AddWithValue("@valid_date",clsApp.Return_String_Date(txtValid_date.Text));
                    myCommand.Parameters.AddWithValue("@number_enter", clsApp.Return_Float_Value(txtNumber_enter.Text));
                    myCommand.Parameters.AddWithValue("@hkd_ex_fty", clsApp.Return_Float_Value(txtHkd_ex_fty.Text));
                    myCommand.Parameters.AddWithValue("@date_req", txtDate_req.Text);
                    myCommand.Parameters.AddWithValue("@aw", txtAw.Text);                    
                    myCommand.Parameters.AddWithValue("@status", txtStatus.Text);
                    myCommand.Parameters.AddWithValue("@sample_request", txtSample_request.Text);
                    myCommand.Parameters.AddWithValue("@needle_test", txtNeedle_test.Text);
                    myCommand.Parameters.AddWithValue("@comment", txtComment.Text);
                    myCommand.Parameters.AddWithValue("@remark_pdd", memRemark_pdd.Text);
                    myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text);
                    myCommand.Parameters.AddWithValue("@polo_care", txtPolo_care.EditValue);
                    myCommand.Parameters.AddWithValue("@moq_for_test", clsApp.Return_Float_Value(txtMoq_for_test.Text));
                    myCommand.Parameters.AddWithValue("@plm_code", txtPlm_code.Text);
                    myCommand.Parameters.AddWithValue("@trim_color_code", txtTrim_color_code.Text);                    
                    
                    myCommand.Parameters.AddWithValue("@ver", txtVersion.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                   
                    myCommand.Parameters.AddWithValue("@test_sample_hk", txtTest_sample_hk.Text);
                    myCommand.Parameters.AddWithValue("@sms", txtSms.Text);
                    myCommand.Parameters.AddWithValue("@sample_card", txtSample_card.Text);
                    myCommand.Parameters.AddWithValue("@meeting_recap", txtMeeting_recap.Text);
                    myCommand.Parameters.AddWithValue("@usd_dap", clsApp.Return_Float_Value(txtUsd_dap.Text));
                    myCommand.Parameters.AddWithValue("@usd_lab_test_prx", clsApp.Return_Float_Value(txtUsd_lab_test_prx.Text));
                    myCommand.Parameters.AddWithValue("@ex_fty_hkd", clsApp.Return_Float_Value(txtEx_fty_hkd.Text));
                    myCommand.Parameters.AddWithValue("@ex_fty_usd", clsApp.Return_Float_Value(txtEx_fty_usd.Text));
                    myCommand.Parameters.AddWithValue("@discount", clsApp.Return_Float_Value(txtDisc.Text));
                    myCommand.Parameters.AddWithValue("@disc_price_usd", clsApp.Return_Float_Value(txtDisc_usd.Text));
                    myCommand.Parameters.AddWithValue("@disc_price_hkd", clsApp.Return_Float_Value(txtDisc_hkd.Text));
                    myCommand.Parameters.AddWithValue("@disc_price_rmb", clsApp.Return_Float_Value(txtDisc_rmb.Text));
                    myCommand.Parameters.AddWithValue("@disc_hkd_ex_fty", clsApp.Return_Float_Value(txtDisc_hkd_ex_fty.Text));
                    myCommand.Parameters.AddWithValue("@usd_ex_fty", clsApp.Return_Float_Value(txtUsd_ex_fty.Text));
                   
                    myCommand.Parameters.AddWithValue("@disc_price_vnd", clsApp.Return_Float_Value(txtDisc_vnd.Text));
                    //price_vnd,disc_price_vnd
                    myCommand.Parameters.AddWithValue("@reason_edit", txtReason_edit.EditValue);
                    //txtRmb_remark.Text = clsQuotation.Get_Rmb_Remark(txtFormula.Text);
                    myCommand.Parameters.AddWithValue("@rmb_remark", txtRmb_remark.Text);
                    myCommand.Parameters.AddWithValue("@special_price", chkSpecialPrice.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cust_artwork", txtCustartwork.Text);
                    myCommand.Parameters.AddWithValue("@cost_price", clsApp.Return_Float_Value(txtCost_price.Text));
                    myCommand.Parameters.AddWithValue("@labtest_prod_type", lueLabtest.EditValue.ToString());
                    myCommand.Parameters.AddWithValue("@termremark", txtTermremark.Text);
                    myCommand.Parameters.AddWithValue("@pending", txtPending.Text); 
                    myCommand.Parameters.AddWithValue("@remark_pdd_dg", memDgRmkPdd.Text);
                    myCommand.Parameters.AddWithValue("@ref_temp_code", txtRef_temp_code.Text);
                    //2023/02/04
                    myCommand.Parameters.AddWithValue("@flag_vnd", chkFlag_vnd.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@flag_vnd_date", clsApp.Return_String_Date(txtFlag_vnd_date.EditValue.ToString()));
                    myCommand.Parameters.AddWithValue("@vnd_bp", clsApp.Return_Float_Value(txtVnd_bp.Text));
                    myCommand.Parameters.AddWithValue("@price_vnd_usd", clsApp.Return_Float_Value(txtPrice_vnd_usd.Text));
                    myCommand.Parameters.AddWithValue("@price_vnd", clsApp.Return_Float_Value(txtPrice_vnd.Text));
                    myCommand.Parameters.AddWithValue("@price_vnd_grs", clsApp.Return_Float_Value(txtPrice_vnd_grs.Text));
                    myCommand.Parameters.AddWithValue("@price_vnd_pcs", clsApp.Return_Float_Value(txtPrice_vnd_pcs.Text));
                    myCommand.Parameters.AddWithValue("@cf_color_id", lueCf_color_id.EditValue);
                    myCommand.Parameters.AddWithValue("@material_type", lueMaterial_type.EditValue);
                    myCommand.Parameters.AddWithValue("@product_type", lueProduct_type.EditValue);
                    myCommand.Parameters.AddWithValue("@md_charge_vn", clsApp.Return_Float_Value(txtMd_charge_vn.Text));
                    myCommand.Parameters.AddWithValue("@die_mould_usd_vn", clsApp.Return_Float_Value(txtDie_mould_usd_vn.Text));
                    myCommand.ExecuteNonQuery();
                    
                    //設置組別
                    if (editState== "NEW")
                    {
                        //新增狀態
                        //editStateCopy非空即為復制新增
                        if (editStateCopy == "")
                        {
                            //非復制新增
                            myCommand.Parameters.Clear();
                            myCommand.CommandText = sql_group_i;
                            myCommand.Parameters.AddWithValue("@temp_code", strTempCode);
                            myCommand.Parameters.AddWithValue("@seq_id", "001");
                            myCommand.Parameters.AddWithValue("@group_id", txtSales_group.EditValue);
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.ExecuteNonQuery();
                            txtCrusr.Text = DBUtility._user_id;
                            txtCrtim.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);
                        }
                    }
                    else
                    {
                        //修改狀態
                        //string oldGroup = dgvDetails.Rows[rowReset].Cells["sales_group"].Value.ToString();
                        string curSalesGroup = txtSales_group.EditValue.ToString();
                        if (curSalesGroup != oldGroup)//更改了主表的組別
                        {
                            //如果更改的組別如存在則無需再更改
                            string sql = string.Format(@"Select '1' as result From quotation_group Where temp_code='{0}' And group_id='{1}'", strTempCode, curSalesGroup);
                            System.Data.DataTable dtGroup = clsPublicOfCF01.GetDataTable(sql);
                            if (dtGroup.Rows.Count == 0)
                            {
                                myCommand.Parameters.Clear();
                                myCommand.CommandText = sql_group_u;
                                myCommand.Parameters.AddWithValue("@temp_code", strTempCode);
                                myCommand.Parameters.AddWithValue("@old_group_id", oldGroup);
                                myCommand.Parameters.AddWithValue("@group_id", curSalesGroup);
                                myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                myCommand.ExecuteNonQuery();
                            }                                                     
                        }
                        txtAmusr.Text = DBUtility._user_id;
                        txtAmtim.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);
                    }
                    myTrans.Commit(); //數據提交
                   
                    //復制新增時執行此代碼=========2019-07-23 by Allen
                    if (editStateCopy == "NEWCOPY")
                    {
                        SqlParameter[] pars = new SqlParameter[]
                        {
                            new SqlParameter("@oldTemp_code",oldTempCode),
                            new SqlParameter("@newTemp_code", strTempCode),
                            new SqlParameter("@user_id", DBUtility._user_id),
                            new SqlParameter("@sales_group",txtSales_group.EditValue.ToString())
                        };
                        clsPublicOfCF01.ExecuteNonQuery("usp_newcopy_sales_group", pars, true);
                    }
                    
                    ////復制新增時執行此代碼=========2018-11-30 by Allen
                    //if (dgvSub.RowCount > 0 && editStateCopy == "NEWCOPY")
                    //{
                    //    //復制SUB MO
                    //    SqlParameter[] paras = new SqlParameter[]
                    //    {
                    //        new SqlParameter("@oldTemp_code",oldTempCode),
                    //        new SqlParameter("@newTemp_code", strTempCode),
                    //        new SqlParameter("@user_id", DBUtility._user_id)
                    //    };
                    //    clsPublicOfCF01.ExecuteNonQuery("usp_newcopy_submo", paras, true);
                    //}   
                    ////===========================================
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
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            chkSelectAll.Enabled = true;
            dgvDetails.Enabled = true;
            Init_Column_isEnable();           
            
            //Set_Row_Position(txtID.Text.Trim());           
            tabPage2.Parent = null;
            if (save_flag)
            {       
                //重新按原來的排序方式重新排序
                if(sortColumnName !="")
                {
                    dgvDetails.Sort(dgvDetails.Columns[sortColumnName], sortDirection);
                }
                //定位到當前行
                int row_index = 0;
                //使用foreach重新定位到當前編輯的行.
                string temp_code_no = "";
                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    //获取第i行，列名是列名A的单元格的值
                    temp_code_no = row.Cells["temp_code"].Value.ToString();
                    if(temp_code_no == cur_temp_code)
                    {
                        row_index = row.Index;
                        break;
                    }
                }
                dgvDetails.CurrentCell = dgvDetails.Rows[row_index].Cells[0];
                dgvDetails.Rows[row_index].Selected = true; //選中整行     

                editState= "";
                editStateCopy = "";
                //滾動條滾到表格的最頂端
                //dgvDetails.FirstDisplayedScrollingRowIndex = 0;
                if (pType == "1")
                {
                    //MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
                }
            }
            else
            {
                if (pType == "1")
                {
                    MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
       
        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtSales_group.Text))
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "Update dbo.quotation Set flag_del='1',amusr=@user_id,amtim=getdate() WHERE temp_code=@temp_code";
                //const string sql_del = "Delete FROM dbo.quotation WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text);
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show("數據已刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtDetail.AcceptChanges();
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


        private void Print() //通用的打印方法
        {
            if (dgvDetails.RowCount > 0)
            {
                clsGeneralDataConvert.GridView_To_Print(dgvDetails);
            }
        }

        //===========以下爲控件中的方法================       
        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            //字段变量:flag_row_change控制表格數據加載結束才响应SelectionChanged事件.
            if (dgvDetails.RowCount > 0 && flag_row_change)
            {
                rowReset = dgvDetails.CurrentCell.RowIndex;//當前焦點所在行
                lblOf.Text = (dgvDetails.CurrentCell.RowIndex + 1).ToString() + " of " + dgvDetails.RowCount.ToString();
                dgvrow = dgvDetails.CurrentRow;
                //Sethead(dgvrow);                
                if (dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["special_price"].Value.ToString() == "True")
                {
                    chkSpecialPrice.Checked = true;
                }
                else
                {
                    chkSpecialPrice.Checked = false;
                }
                ////顯示越南單價
                //if (dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["flag_vnd"].Value.ToString() == "True")
                //{
                //    chkFlag_vnd.Checked = true;                    
                //}
                //else
                //{
                //    chkFlag_vnd.Checked = false;
                //}
                pnlFlagVnd.Visible = chkFlag_vnd.Checked;
                //顯示是否存在已計价
                if (clsMmCalculatePrice.getIdByQuotationId(txtTemp_code.Text) != "")
                    lblIsCalPrice.Visible = true;
                else
                    lblIsCalPrice.Visible = false;

                SetArtwork(txtCf_code.Text.Trim());//設置圖欄

                //顯示Sub 列表            
                Display_Sub_List(txtTemp_code.Text);
                if (editStateCopy == "NEWCOPY")
                {
                    dtSubmo.Clear();
                    //dgvSub.DataSource = null;
                    //memRemark_pdd.Text = "";
                }
                //顯示grop 列表
                Display_Group_List(txtTemp_code.Text);               
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
                    @"SELECT id,ISNULL(picture_name_h,'') As picture_name FROM cd_pattern Where within_code='0000' AND id='{0}'", strArtwork);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt = clsConErp.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        strArtwork = imagePath+ @"\Artwork\" + dt.Rows[0]["picture_name"].ToString();
                        if (!string.IsNullOrEmpty(strArtwork))
                            pic_artwork.Image = File.Exists(strArtwork) ? Image.FromFile(strArtwork) : null;
                        else
                            pic_artwork.Image = null;
                    }
                }
            }
        }

        /// <summary>
        /// 更改新版本頁的數據不會動到第一頁的原始數據
        /// gridView1行變化時第一頁的原始數據跟著關聯變化
        /// </summary>
        /// <param name="curRow"></param>
        private void Set_CurrentRow_for_new_version(int curRow)
        {
            if (curRow >= 0)
            {
                dgvDetails.CurrentCell = dgvDetails.Rows[curRow].Cells[2]; //设置当前单元格
                dgvDetails.Rows[curRow].Selected = true; //選中整行
                rowReset = dgvDetails.CurrentCell.RowIndex;
                //dgvrow = dgvDetails.CurrentRow;
                //Sethead(dgvrow);
            }
        }

        #region  Sethead 設置主檔
        private void Sethead(DataGridViewRow pdr)
        {            
            txtID.EditValue = pdr.Cells["id"].Value.ToString();
            txtSales_group.EditValue = pdr.Cells["sales_group"].Value.ToString();
            string strDat = pdr.Cells["date"].Value.ToString();
            strDat = !string.IsNullOrEmpty(strDat) ? Convert.ToDateTime(strDat).ToString("yyyy-MM-dd") : "";            
            txtDate.EditValue = strDat;
            txtTemp_code.Text = pdr.Cells["temp_code"].Value.ToString();
            txtBrand.EditValue = pdr.Cells["brand"].Value.ToString();
            txtBrandDesc.Text = pdr.Cells["brand_desc"].Value.ToString();
            txtSeason.EditValue = pdr.Cells["season"].Value.ToString();
            txtSeasonDesc.Text = pdr.Cells["season_desc"].Value.ToString();
            txtFormula.Text = pdr.Cells["formula_id"].Value.ToString();
            txtDivision.Text = pdr.Cells["division"].Value.ToString();
            txtContact.Text = pdr.Cells["contact"].Value.ToString();
            txtMaterial.Text = pdr.Cells["material"].Value.ToString();
            txtSize.Text = pdr.Cells["size"].Value.ToString();
            txtProduct_desc.Text = pdr.Cells["product_desc"].Value.ToString();
            txtRemark.Text = pdr.Cells["remark"].Value.ToString();
            txtRemark_other.Text = pdr.Cells["remark_other"].Value.ToString();
            txtCust_code.Text = pdr.Cells["cust_code"].Value.ToString();
            txtCf_code.Text = pdr.Cells["cf_code"].Value.ToString();
            txtCust_color.Text = pdr.Cells["cust_color"].Value.ToString();
            txtCf_color.Text = pdr.Cells["cf_color"].Value.ToString();
            txtPrice_unit.EditValue = pdr.Cells["price_unit"].Value;
            // --start 2024/06/12復制新增時清空單價
            if (editStateCopy == "NEWCOPY")
            {                
                //復制新增時需清空以下這兩個備注 
                memRemark_pdd.Text = "";
                memDgRmkPdd.Text = "";
            }
            else
            {
                txtNumber_enter.EditValue = pdr.Cells["number_enter"].Value;
                txtPrice_usd.EditValue = pdr.Cells["price_usd"].Value;
                txtPrice_hkd.EditValue = pdr.Cells["price_hkd"].Value;
                txtPrice_rmb.EditValue = pdr.Cells["price_rmb"].Value;
                txtHkd_ex_fty.EditValue = pdr.Cells["hkd_ex_fty"].Value;
                txtDisc.EditValue = pdr.Cells["discount"].Value;
                txtDisc_usd.EditValue = pdr.Cells["disc_price_usd"].Value;
                txtDisc_hkd.EditValue = pdr.Cells["disc_price_hkd"].Value;
                txtDisc_rmb.EditValue = pdr.Cells["disc_price_rmb"].Value;
                txtDisc_hkd_ex_fty.EditValue = pdr.Cells["disc_hkd_ex_fty"].Value;
                txtUsd_ex_fty.EditValue = pdr.Cells["usd_ex_fty"].Value;

                //VN Price
                txtVnd_bp.EditValue = pdr.Cells["vnd_bp"].Value;
                txtPrice_vnd_usd.EditValue = pdr.Cells["price_vnd_usd"].Value;
                txtPrice_vnd.EditValue = pdr.Cells["price_vnd"].Value;
                txtPrice_vnd_grs.EditValue = pdr.Cells["price_vnd_grs"].Value;
                txtPrice_vnd_pcs.EditValue = pdr.Cells["price_vnd_pcs"].Value;

                memRemark_pdd.Text = pdr.Cells["remark_pdd"].Value.ToString(); 
                memDgRmkPdd.Text = pdr.Cells["remark_pdd_dg"].Value.ToString();      

                txtCrusr.Text = pdr.Cells["crusr"].Value.ToString();
                txtCrtim.Text = pdr.Cells["crtim"].Value.ToString();
                txtAmusr.Text = pdr.Cells["amusr"].Value.ToString();
                txtAmtim.Text = pdr.Cells["amtim"].Value.ToString();
            }
            //-- 
            txtSalesman.Text = pdr.Cells["salesman"].Value.ToString(); 
            cmbmoq_below_over.EditValue= pdr.Cells["moq_below_over"].Value.ToString();
            txtMoq.EditValue = pdr.Cells["moq"].Value;
            txtMoq_Desc.Text = pdr.Cells["moq_desc"].Value.ToString();
            txtMoq_unit.EditValue = pdr.Cells["moq_unit"].Value;
            txtMwq.EditValue = pdr.Cells["mwq"].Value;
            txtMwq_unit.EditValue = pdr.Cells["mwq_unit"].Value;
            txtLead_time_min.EditValue = pdr.Cells["lead_time_min"].Value;
            txtLead_time_max.EditValue = pdr.Cells["lead_time_max"].Value;
            txtLead_time_unit.EditValue = pdr.Cells["lead_time_unit"].Value;
            txtMd_charge.EditValue = pdr.Cells["md_charge"].Value;
            txtMd_charge_cny.EditValue = pdr.Cells["md_charge_cny"].Value;
            txtMd_charge_unit.EditValue = pdr.Cells["md_charge_unit"].Value;
            txtDie_mould_usd.EditValue = pdr.Cells["die_mould_usd"].Value;
            txtDie_mould_cny.EditValue = pdr.Cells["die_mould_cny"].Value;
            txtAccount_code.Text = pdr.Cells["account_code"].Value.ToString();
            strDat = pdr.Cells["valid_date"].Value.ToString();
            strDat = !string.IsNullOrEmpty(strDat)? Convert.ToDateTime(strDat).ToString("yyyy-MM-dd"):"";            
            txtValid_date.EditValue = strDat;            
            
            txtDate_req.Text = pdr.Cells["date_req"].Value.ToString();
            txtAw.Text = pdr.Cells["aw"].Value.ToString();           
            txtStatus.Text = pdr.Cells["status"].Value.ToString();
            txtSample_request.Text = pdr.Cells["sample_request"].Value.ToString();
            txtNeedle_test.Text = pdr.Cells["needle_test"].Value.ToString();
            txtVersion.Text = pdr.Cells["ver"].Value.ToString();
            txtMo_id.Text = pdr.Cells["mo_id"].Value.ToString();                     
            
            txtComment.Text = pdr.Cells["comment"].Value.ToString();
            txtPolo_care.EditValue = pdr.Cells["polo_care"].Value.ToString();
            txtMoq_for_test.EditValue = pdr.Cells["moq_for_test"].Value;

            txtPlm_code.Text = pdr.Cells["plm_code"].Value.ToString();
            txtTrim_color_code.Text = pdr.Cells["trim_color_code"].Value.ToString();
            txtTest_sample_hk.Text = pdr.Cells["test_sample_hk"].Value.ToString();
            txtSms.Text = pdr.Cells["sms"].Value.ToString();
            txtSample_card .Text = pdr.Cells["sample_card"].Value.ToString();
            txtMeeting_recap.Text = pdr.Cells["meeting_recap"].Value.ToString();
            txtUsd_dap.EditValue = pdr.Cells["usd_dap"].Value;
            txtUsd_lab_test_prx.EditValue = pdr.Cells["usd_lab_test_prx"].Value;
            txtEx_fty_hkd.EditValue = pdr.Cells["ex_fty_hkd"].Value;
            txtEx_fty_usd.EditValue = pdr.Cells["ex_fty_usd"].Value;

            txtReason_edit.EditValue = pdr.Cells["reason_edit"].Value.ToString();            
            txtRmb_remark.Text = pdr.Cells["rmb_remark"].Value.ToString();
            txtPrice_salesperson.EditValue = pdr.Cells["price_salesperson"].Value;
            txtPrice_kind.Text = pdr.Cells["price_kind"].Value.ToString();
            txtRemark_salesperson.Text = pdr.Cells["remark_salesperson"].Value.ToString();
            
            //顯示是否存在已計价
            if (clsMmCalculatePrice.getIdByQuotationId(txtTemp_code.Text) != "")
            {
                lblIsCalPrice.Visible = true;
            }
            else
            {
                lblIsCalPrice.Visible = false;
            }                
            if (pdr.Cells["special_price"].Value.ToString() == "True")
            {
                chkSpecialPrice.Checked = true;
            }
            else
            {
                chkSpecialPrice.Checked = false;
            }
            txtCustartwork.Text = pdr.Cells["cust_artwork"].Value.ToString();
            txtCost_price.EditValue = pdr.Cells["cost_price"].Value;
            lueLabtest.EditValue = pdr.Cells["labtest_prod_type"].Value;
            txtTermremark.Text = pdr.Cells["termremark"].Value.ToString();
            txtPending.EditValue = pdr.Cells["pending"].Value.ToString();                  
            txtRef_temp_code.Text = pdr.Cells["temp_code"].Value.ToString();
            lueCf_color_id.EditValue = pdr.Cells["cf_color_id"].Value.ToString();
            lueMaterial_type.EditValue = pdr.Cells["material_type"].Value.ToString();
            lueProduct_type.EditValue = pdr.Cells["product_type"].Value.ToString();

            txtMd_charge_vn.EditValue = pdr.Cells["md_charge_vn"].Value;
            txtDie_mould_usd_vn.EditValue = pdr.Cells["die_mould_usd_vn"].Value;

            if (pdr.Cells["flag_vnd"].Value.ToString() == "True")
            {
                chkFlag_vnd.Checked = true;
                pnlFlagVnd.Visible = true;
            }
            else
            {
                chkFlag_vnd.Checked = false;
                pnlFlagVnd.Visible = false;
            }
            SetArtwork(txtCf_code.Text.Trim());//設置圖欄

            //顯示Sub 列表            
            Display_Sub_List(txtTemp_code.Text);
            if (editStateCopy == "NEWCOPY")
            {
                dtSubmo.Clear();               
                memRemark_pdd.Text = "";
            }
            //顯示grop 列表
            Display_Group_List(txtTemp_code.Text);
        }
        #endregion

        private void Display_Sub_List(string temp_code)
        {
            dtSubmo = clsQuotation.GetSub(temp_code);
            dgvSub.DataSource = dtSubmo;                       
            dtPriceDisc = clsQuotation.GetPriceDiscount(temp_code);
            dgvPriceDisc.DataSource = dtPriceDisc;

        }

        private void Display_Group_List(string temp_code)
        {
            dgvGroup.DataSource = clsPublicOfCF01.GetDataTable(
                string.Format(@"SELECT seq_id,group_id FROM dbo.quotation_group with(nolock) WHERE temp_code='{0}' Order by seq_id", temp_code));

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

            //clsQuotation.SetGridViewHighLight(dgvDetails, e);//自定義焦點行高亮背景色
            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {
                if (grd.Rows[e.RowIndex].Cells["pending"].Value.ToString() == "")
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    //紫色字體
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkMagenta;
                }
                //刪除線
                grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                //備註字段不顯示刪除線
                //grd.Rows[e.RowIndex].Cells["remark"].Style.ForeColor = Color.Black;
                //grd.Rows[e.RowIndex].Cells["remark"].Style.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular); 
            }
            else
            {
                //恢復正常顯示
                grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular);
            }
            
            if (grd.Rows[e.RowIndex].Cells["special_price"].Value.ToString() == "True")
            {
                //特別單價亮藍色背景
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            Color oldBackColor = new Color();
            oldBackColor = grd.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            if (grd.Rows[e.RowIndex].Cells["special_price"].Value.ToString() == "False")
            {
                if(oldBackColor == Color.LightBlue)
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }           
           

            //if (grd.Rows[e.RowIndex].Cells["flag_new"].Value.ToString() != "")
            //{
            //    //新添加記錄背景色
            //    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            //}
            //else
            //{
            //    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //}
           
            
        }


        #region Get_Cust_Formula() for Price Formula
        private void Get_Cust_Formula()
        {
            //USD公式：(入機數 X 1.15)/7.72 保留兩們小數點
            //RMB 17%VAT 公式：入機數*1.17*0.82
            float number_input;
            if (!string.IsNullOrEmpty(txtNumber_enter.Text))
            {
                number_input = float.Parse(txtNumber_enter.Text);
            }
            else
            {
                number_input = 0.00f;
            }
            if (number_input > 0)
            {
                txtPrice_usd.EditValue = Math.Round((number_input * 1.15) / 7.72, 3);//USD公式：(入機數 X 1.15)/7.72 保留3位小數點
                txtPrice_rmb.EditValue = Math.Round(number_input * 1.17 * 0.82, 3); //RMB 17%VAT 公式：入機數*1.17*0.82
            }
            else
            {
                txtPrice_usd.EditValue = 0;
                txtPrice_rmb.EditValue = 0;
            }

            //HKD公式：USD$欄*7.8
            if (!string.IsNullOrEmpty(txtPrice_usd.Text))
            {
                number_input = float.Parse(txtPrice_usd.Text);
            }
            else
            {
                number_input = 0.00f;
            }

            if (number_input > 0)
            {
                txtPrice_hkd.EditValue = Math.Round(number_input * 7.8, 3);
            }
            else
            {
                txtPrice_hkd.EditValue = 0;
            }

            //HKD EX-FTY 公式：HKD$ *0.9
            if (!string.IsNullOrEmpty(txtPrice_hkd.Text))
            {
                number_input = float.Parse(txtPrice_hkd.Text);
            }
            else
            {
                number_input = 0.00f;
            }

            if (number_input > 0)
            {
                txtHkd_ex_fty.EditValue = Math.Round(number_input * 0.9, 3);
            }
            else
            {
                txtHkd_ex_fty.EditValue = 0;
            }
        }

        /// <summary>
        /// 依牌子找到對應的公式，如參數為空，則取默認的值
        /// </summary>
        /// <param name="pBrand_id"></param>
        private void Get_Cust_Formula(string pBrand_id)
        {
            const string strSql_all = @"select brand_id,usd1,usd2,rmb1,rmb2,hkd1,hkd2 from dbo.quotation_formula where brand_id='*'";
            System.Data.DataTable dt = new System.Data.DataTable();            
            if (string.IsNullOrEmpty(pBrand_id))
            {                
                dt = clsPublicOfCF01.GetDataTable(strSql_all);
            }
            else
            {
                string strSql = string.Format(@"select brand_id,usd1,usd2,rmb1,rmb2,hkd1,hkd2 from dbo.quotation_formula where brand_id='{0}'", pBrand_id);
                dt = clsPublicOfCF01.GetDataTable(strSql);
                //牌子非空，且找不到對應參數時重取默認的公共參數
                if (dt.Rows.Count == 0)
                {
                    dt = clsPublicOfCF01.GetDataTable(strSql_all);
                }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("請設置好公式參數!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
            float usd1,usd2,rmb1,rmb2,hkd1,hkd2;            
            usd1 = float.Parse(dt.Rows[0]["usd1"].ToString());
            usd2 = float.Parse(dt.Rows[0]["usd2"].ToString());
            rmb1 = float.Parse(dt.Rows[0]["rmb1"].ToString());
            rmb2 = float.Parse(dt.Rows[0]["rmb2"].ToString());
            hkd1 = float.Parse(dt.Rows[0]["hkd1"].ToString());
            hkd2 = float.Parse(dt.Rows[0]["hkd2"].ToString());
                        

            //USD公式：(入機數 X 1.15)/7.72 保留兩們小數點
            //RMB 17%VAT 公式：入機數*1.17*0.82
            float number_input;
            if (!string.IsNullOrEmpty(txtNumber_enter.Text))
            {
                number_input = float.Parse(txtNumber_enter.Text);
            }
            else
            {
                number_input = 0.00f;
            }
            if (number_input > 0)
            {
                txtPrice_usd.EditValue = Math.Round((number_input * usd1) / usd2, 3);//USD公式：(入機數 X 1.15)/7.72 保留3位小數點
                txtPrice_rmb.EditValue = Math.Round(number_input * rmb1 * rmb2, 3); //RMB 17%VAT 公式：入機數*1.17*0.82
            }
            else
            {
                txtPrice_usd.EditValue = 0;
                txtPrice_rmb.EditValue = 0;
            }
            //HKD公式：USD$欄*7.8
            if (!string.IsNullOrEmpty(txtPrice_usd.Text))
            {
                number_input = float.Parse(txtPrice_usd.Text);
            }
            else
            {
                number_input = 0.00f;
            }

            if (number_input > 0)
            {
                txtPrice_hkd.EditValue = Math.Round(number_input * hkd1, 3);
            }
            else
            {
                txtPrice_hkd.EditValue = 0;
            }
            //HKD EX-FTY 公式：HKD$ *0.9
            if (!string.IsNullOrEmpty(txtPrice_hkd.Text))
            {
                number_input = float.Parse(txtPrice_hkd.Text);
            }
            else
            {
                number_input = 0.00f;
            }

            if (number_input > 0)
            {
                txtHkd_ex_fty.EditValue = Math.Round(number_input * hkd2, 3);
            }
            else
            {
                txtHkd_ex_fty.EditValue = 0;
            }
        }
        #endregion


        private static void Set_Number_Focus(DevExpress.XtraEditors.TextEdit objTextEdit)
        {
            if (objTextEdit.Text == "0.000")
            {
                objTextEdit.Select(1, 0);
            }
        }
        
        private void txtNumber_enter_Click(object sender, EventArgs e)
        {
            //txtNumber_enter.Select(0, 0); //光标定位
            //txtNumber_enter.SelectAll();
            Set_Number_Focus(txtNumber_enter);
        }

        private void txtDisc_Click(object sender, EventArgs e)
        {
            if (txtDisc.Text == "0.0")
            {
                txtDisc.Select(1, 0);
            }
        }

        private void txtPrice_hkd_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtPrice_hkd);
        }

        private void txtPrice_usd_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtPrice_usd);           
        }

        private void txtPrice_rmb_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtPrice_rmb);
        }

        private void txtHkd_ex_fty_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtHkd_ex_fty);
        }

        private void txtUsd_ex_fty_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtUsd_ex_fty);
        } 

        private void txtUsd_dap_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtUsd_dap);
        }

        private void txtUsd_lab_test_prx_Click(object sender, EventArgs e)
        {           
            Set_Number_Focus(txtUsd_lab_test_prx);
        }

        private void txtEx_fty_hkd_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtEx_fty_hkd);
        }

        private void txtEx_fty_usd_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtEx_fty_usd);
        }

        private void txtDisc_usd_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtDisc_usd);
        }

        private void txtDisc_hkd_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtDisc_hkd);
        }

        private void txtDisc_rmb_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtDisc_rmb);
        }

        private void txtDisc_hkd_ex_fty_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtDisc_hkd_ex_fty);
        }

        private void txtCost_price_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtCost_price);
        }

        private void txtSales_group_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
        }

        //取消還原到原始記錄位置,要用到pID進行定位
        private void SetResetID()
        {
            if (dgvDetails.Rows.Count > 0)
            {
                pID = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["id"].Value.ToString();  
                oldGroup = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["sales_group"].Value.ToString();
            }
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            SetResetID();//保存取消還原的ID
            if (dgvDetails.RowCount > 0)
            {                
                dtDetail = dtDetail.DefaultView.ToTable();
                //bds1.DataSource = dtDetail.DefaultView.ToTable();//排序後需重新賦值,否數據會錯亂;
                bds1.DataSource = dtDetail;
                dgvDetails.DataSource = bds1;
                      
                oldTempCode = txtTemp_code.Text;

                //dgvrow = dgvDetails.CurrentRow; //  
                DataGridViewRow dgrw = new DataGridViewRow();
                dgrw = dgvDetails.CurrentRow;
                if (dgrw.Cells["special_price"].Value.ToString() == "True")
                {
                    DialogResult result = MessageBox.Show("當前復制的記錄為特殊單價,是否繼續?", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                AddNew();
                editStateCopy = "NEWCOPY";               
                Sethead(dgrw);
                //--start 2024/06/06
                //因Sethead(dgrw, editState)方法中取出的是復制前的Temp_Code,所以dgvSub,dgvPriceDisc要清空;
                dgvSub.DataSource = null;
                dgvPriceDisc.DataSource = null;
                //--end 2024/06/06
                txtTemp_code.Text = clsQuotation.Get_Quote_SeqNo();//生成最大序列號
                txtDate.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
                txtCrusr.Text = DBUtility._user_id;
                txtCrtim.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);

                txtVersion.Text = "0";
                txtID.EditValue = "";
                tabPage2.Parent = null;
               
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }       

        //private void txtTemp_code_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //if (editState== "NEW" || editState== "EDIT")
        //{
        //    string strsql = @"SELECT pkey,ISNULL(bill_code,'') AS bill_code,bill_text1 FROM sys_bill_max WHERE bill_id='QUA'";
        //    System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
        //    string strMax = "";
        //    string strBill = dt.Rows[0]["bill_text1"].ToString().Trim();
        //    strMax = dt.Rows[0]["bill_code"].ToString();
        //    strMax = strMax.Substring(2, 7);
        //    strMax = strBill + (Convert.ToInt32(strMax) + 1).ToString("0000000");
        //    strsql = @"Update sys_bill_max SET bill_code=@bill_code WHERE pkey=@pkey";
        //    SqlParameter[] para = new SqlParameter[]{
        //        new SqlParameter("@bill_code",strMax),
        //        new SqlParameter("@pkey",dt.Rows[0]["pkey"])
        //    };
        //    clsPublicOfCF01.ExecuteNonQuery(strsql, para, false);
        //    txtTemp_code.Text = strMax;
        //}
        // }

        private void chkConvert_CheckedChanged(object sender, EventArgs e)
        {
            string strLang = "";
            if (lange == "0")
                strLang = "2";//英文
            else
                strLang = "0";//繁體
            lange = strLang;
            clsTranslate oCtl = new clsTranslate(Name, Controls, strLang);
            oCtl.Translate();
            clsApp.RetSetImage(toolStrip1);
        }

        
        private void BTNIMPORT_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "Execl files (*.xls)|*.xls", FilterIndex = 0, RestoreDirectory = true, Title = "導入EXCEL文件路徑", FileName = null };
            openFileDialog1.ShowDialog();
            strFileExcel = openFileDialog1.FileName;
            Refresh();
            if (string.IsNullOrEmpty(strFileExcel))
            {
                return;
            }
            if (!File.Exists(strFileExcel))
            {
                MessageBox.Show("指定的EXCEL文件不存在，請返回檢查!");
                return;
            }
            //2016-06-11新增的導入方法
            //可記錄每行導入狀態            
            if (clsQuotation.Process_Excel(strFileExcel, progressBar1))
            {
                MessageBox.Show("導入EXCEL文件成功!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("導入EXCEL文件失敗!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        /// <summary>
        /// 暫時沒用到2016-08-15
        /// </summary>
        private void Load_Excel()
        {        
            //僅限小等于office2003,之前的版本,栏位名称后面不可以空格
            //導入EXCEL頁數,相當于批量新增
            const String strExcel =@"SELECT * FROM [Sheet1$]";
            try
            {
                Inport_excel(strExcel);
                //flag_import = true;//暫時取消于20160517
            }
            catch (SqlException E)
            {
                //flag_import = false;//暫時取消于20160517
                throw new Exception(E.Message);
            }
        }

        #region Inport_excel 匯入Excel
        /// <summary>
        /// 暫時沒用到2016-08-15
        /// </summary>
        /// <param name="_strExcel"></param>
        private void Inport_excel(string _strExcel)
        {           
            String connStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0;", strFileExcel);
            using (OleDbDataAdapter da = new OleDbDataAdapter(_strExcel, connStr))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);                                
                System.Data.DataTable dtExcel = ds.Tables[0];
           
                SqlConnection sqlconn = new SqlConnection(DBUtility.connectionString);
                sqlconn.Open();
                SqlTransaction myTrans = sqlconn.BeginTransaction();
                const string strSql_i =
               @"Insert into quotation 
                (sales_group,temp_code,[date],brand,brand_desc,season,season_desc,division,contact,material,[size],product_desc,cust_code,cf_code,cust_color,cf_color,price_usd,price_hkd,price_rmb,price_unit,salesman,moq,moq_desc,moq_unit,mwq,mwq_unit,
                lead_time_min,lead_time_max,lead_time_unit,md_charge,md_charge_cny,md_charge_unit,remark,remark_other,die_mould_usd,account_code,valid_date,number_enter,hkd_ex_fty,date_req,aw,
                status,sample_request,needle_test,ver,crusr,crtim,comment)
                VALUES
                (@sales_group,@temp_code,CASE LEN(@date) WHEN 0 THEN null ELSE @date END,@brand,@brand_desc,@season,@season_desc,@division,@contact,@material,@size,@product_desc,@cust_code,@cf_code,@cust_color,@cf_color,@price_usd,@price_hkd,@price_rmb,
                @price_unit,@salesman,@moq,@moq_desc,@moq_unit,@mwq,@mwq_unit,@lead_time_min,@lead_time_max,@lead_time_unit,@md_charge,@md_charge_cny,@md_charge_unit,@remark,@remark_other,@die_mould_usd,@account_code,
                CASE LEN(@valid_date) WHEN 0 THEN null ELSE @valid_date END,@number_enter,@hkd_ex_fty,@date_req,@aw,
                @status,@sample_request,@needle_test,@ver,@user_id,getdate(),@comment)";
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dtExcel.Rows.Count;
                
                SqlCommand myCommand = new SqlCommand() { Connection = sqlconn, Transaction = myTrans };
                myCommand.CommandText = strSql_i;
                try
                {
                    string group;           
                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        group = dtExcel.Rows[i]["Sales Group"].ToString().Trim();
                        if (string.IsNullOrEmpty(group))
                        {
                            group = "0";
                        }                        
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@sales_group", group);
                        //myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text);
                        //myCommand.Parameters.AddWithValue("@temp_code", Get_Quote_SeqNo(group));
                        myCommand.Parameters.AddWithValue("@temp_code", clsQuotation.Get_Quote_SeqNo()); 
                        myCommand.Parameters.AddWithValue("@date", clsApp.Return_String_Date(dtExcel.Rows[i]["Quote Date"].ToString().Trim()));
                        myCommand.Parameters.AddWithValue("@brand", dtExcel.Rows[i]["Brand"].ToString());
                        myCommand.Parameters.AddWithValue("@brand_desc", dtExcel.Rows[i]["Brand Desc"].ToString());
                        myCommand.Parameters.AddWithValue("@season", dtExcel.Rows[i]["Season"].ToString());
                        myCommand.Parameters.AddWithValue("@season_desc", dtExcel.Rows[i]["Season Desc"].ToString());
                        myCommand.Parameters.AddWithValue("@division", dtExcel.Rows[i]["Division"].ToString());
                        myCommand.Parameters.AddWithValue("@contact", dtExcel.Rows[i]["Contact"].ToString());
                        myCommand.Parameters.AddWithValue("@material", dtExcel.Rows[i]["Material"].ToString());
                        myCommand.Parameters.AddWithValue("@size", dtExcel.Rows[i]["Size"].ToString());
                        myCommand.Parameters.AddWithValue("@product_desc", dtExcel.Rows[i]["Product Desc"].ToString());
                        myCommand.Parameters.AddWithValue("@remark", dtExcel.Rows[i]["Remark"].ToString());
                        myCommand.Parameters.AddWithValue("@remark_other", dtExcel.Rows[i]["Other Remark"].ToString());
                        myCommand.Parameters.AddWithValue("@cust_code", dtExcel.Rows[i]["Customer Code"].ToString());
                        myCommand.Parameters.AddWithValue("@cf_code", dtExcel.Rows[i]["CF Code"].ToString());
                        myCommand.Parameters.AddWithValue("@cust_color", dtExcel.Rows[i]["Customer Color"].ToString());
                        myCommand.Parameters.AddWithValue("@cf_color", dtExcel.Rows[i]["CF Color"].ToString());
                        myCommand.Parameters.AddWithValue("@price_usd", clsApp.Return_Float_Value(dtExcel.Rows[i]["USD"].ToString()));
                        myCommand.Parameters.AddWithValue("@price_hkd", clsApp.Return_Float_Value(dtExcel.Rows[i]["HKD"].ToString()));
                        myCommand.Parameters.AddWithValue("@price_rmb", clsApp.Return_Float_Value(dtExcel.Rows[i]["RMB"].ToString()));
                        myCommand.Parameters.AddWithValue("@price_unit", dtExcel.Rows[i]["Price Unit"].ToString());
                        myCommand.Parameters.AddWithValue("@salesman", dtExcel.Rows[i]["Salesman"].ToString());
                        myCommand.Parameters.AddWithValue("@moq", clsApp.Return_Float_Value(dtExcel.Rows[i]["MOQ"].ToString()));
                        myCommand.Parameters.AddWithValue("@moq_desc", dtExcel.Rows[i]["MOQ Desc"].ToString());
                        myCommand.Parameters.AddWithValue("@moq_unit", dtExcel.Rows[i]["MOQ Unit"].ToString());
                        myCommand.Parameters.AddWithValue("@mwq", clsApp.Return_Float_Value(dtExcel.Rows[i]["MWQ"].ToString()));
                        myCommand.Parameters.AddWithValue("@mwq_unit", dtExcel.Rows[i]["MWQ Unit"].ToString());
                        myCommand.Parameters.AddWithValue("@lead_time_min", dtExcel.Rows[i]["Lead Time_Min"].ToString());
                        myCommand.Parameters.AddWithValue("@lead_time_max", dtExcel.Rows[i]["Lead Time_Max"].ToString());
                        myCommand.Parameters.AddWithValue("@lead_time_unit", dtExcel.Rows[i]["Lead Time Unit"].ToString());
                        myCommand.Parameters.AddWithValue("@md_charge", clsApp.Return_Float_Value(dtExcel.Rows[i]["Mould Charge in"].ToString()));
                        myCommand.Parameters.AddWithValue("@md_charge_cny", dtExcel.Rows[i]["Mould Charge CNY"].ToString());
                        myCommand.Parameters.AddWithValue("@md_charge_unit", dtExcel.Rows[i]["Mould Charge Unit"].ToString());
                        myCommand.Parameters.AddWithValue("@die_mould_usd", clsApp.Return_Float_Value(dtExcel.Rows[i]["Die Mould USD"].ToString()));
                        myCommand.Parameters.AddWithValue("@account_code", dtExcel.Rows[i]["Account Code"].ToString());
                        myCommand.Parameters.AddWithValue("@valid_date", clsApp.Return_String_Date(dtExcel.Rows[i]["Valid Date"].ToString()));
                        myCommand.Parameters.AddWithValue("@number_enter", clsApp.Return_Float_Value(dtExcel.Rows[i]["Number Eenter"].ToString()));
                        myCommand.Parameters.AddWithValue("@hkd_ex_fty", clsApp.Return_Float_Value(dtExcel.Rows[i]["HKD EX-FTY"].ToString()));
                        myCommand.Parameters.AddWithValue("@date_req", dtExcel.Rows[i]["Date Req Rcvd"].ToString());
                        myCommand.Parameters.AddWithValue("@aw", dtExcel.Rows[i]["aw"].ToString());                        
                        myCommand.Parameters.AddWithValue("@status", dtExcel.Rows[i]["Status"].ToString());
                        myCommand.Parameters.AddWithValue("@sample_request", dtExcel.Rows[i]["Sample Request"].ToString());
                        myCommand.Parameters.AddWithValue("@needle_test", dtExcel.Rows[i]["Needle Test"].ToString());
                        myCommand.Parameters.AddWithValue("@ver", "0");
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.Parameters.AddWithValue("@comment", dtExcel.Rows[i]["Comment"].ToString());
                               
                        myCommand.ExecuteNonQuery();                   
                    }
                    myTrans.Commit(); //數據提交
                }
                catch (Exception E)
                { 
                    myTrans.Rollback(); //數據回滾
                    throw new Exception(E.Message);
                }
                finally
                {
                    sqlconn.Close();
                    sqlconn.Dispose();
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;
            }  
        }
        #endregion
        private void BTNNEWVER_Click(object sender, EventArgs e)
        {            
            if (dgvDetails.RowCount > 0)
            {
                //舊代碼
                //cur_row_index = dgvDetails.CurrentRow.Index;
                //tabPage2.Parent = tabControl1;
                //tabControl1.SelectTab(1);
                //gridView1.FocusedRowHandle = cur_row_index; //定位當前行     

                //新代碼
                cur_row_index = dgvDetails.CurrentRow.Index;
                tabPage2.Parent = tabControl1;
                tabControl1.SelectTab(1);
                dtVersion.Clear();              
                dtVersion = dtDetail.Copy();
                gridControl1.DataSource = dtVersion;
                gridView1.FocusedRowHandle = cur_row_index; //定位當前行     
 
                BTNSAVE_VER.Enabled = true;
                BTNCLOSE.Enabled = true;
                
            }
        }

        private void txtBrand_Leave(object sender, EventArgs e)
        {
            if (editState!= "")
            {                
                if (txtBrand.EditValue.ToString() != "")
                {
                    txtBrandDesc.Text = txtBrand.GetColumnValue("cdesc").ToString();                    
                }
                else
                {
                    txtBrandDesc.Text = "";
                }
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = clsPublicOfCF01.GetDataTable(string.Format("Select brand_id FROM quotation_formula Where brand_id='{0}'", txtBrand.EditValue));
                if (dt.Rows.Count == 0)
                {
                    txtFormula.Text = "**";//2024/05/22 不輸入公式情況下由*改為**
                }
                else
                {
                    txtFormula.Text = dt.Rows[0]["brand_id"].ToString();
                }
                Set_Moq(txtBrand.EditValue.ToString(), txtPrice_unit.EditValue.ToString());
                //--start allen 2024/05/22 
                if (string.IsNullOrEmpty(txtPrice_unit.Text))
                {
                    return;
                }
                CalcuPrice();               
                CalcuPriceDisc(txtDisc.Text);
                txtRmb_remark.Text = clsQuotation.Get_Rmb_Remark(txtFormula.Text);
                //--end allen 2024/05/22
            }
        }

        //private void txtBrand_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (editState!= "")
        //    {
        //        if (txtBrand.EditValue.ToString() != "")
        //            txtBrandDesc.Text = txtBrand.GetColumnValue("cdesc").ToString();
        //        else
        //            txtBrandDesc.Text = "";
        //        System.Data.DataTable dt = new System.Data.DataTable();
        //        dt = clsPublicOfCF01.GetDataTable(string.Format("Select brand_id FROM quotation_formula Where brand_id='{0}'", txtBrand.EditValue.ToString()));
        //        if (dt.Rows.Count == 0)
        //            txtFormula.Text = "*";
        //        else
        //            txtFormula.Text = dt.Rows[0]["brand_id"].ToString();
        //    }
        //}

        private void txtSeason_Leave(object sender, EventArgs e)
        {
            if (editState!= "")
            {
                if (txtSeason.EditValue.ToString() != "")
                    txtSeasonDesc.Text = txtSeason.GetColumnValue("cdesc").ToString();
                else
                    txtSeasonDesc.Text = "";
            }
        }


        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.CurrentRow == null)
            {
                return;
            }
            if (!is_group_pdd)
            {
                return;
            }            
            if (dgvDetails.Columns[e.ColumnIndex].Name == "ver")
            {
                using (frmQuotation_Price_List ofrm = new frmQuotation_Price_List(dgvDetails.Rows[e.RowIndex].Cells["temp_code"].Value.ToString(),is_group_pdd))
                {
                    ofrm.ShowDialog();
                }
            }     
        }

        private void txtSales_group_Leave(object sender, EventArgs e)
        {
            //if (editState== "NEW" && txtSales_group.Text != "")
            //{
            //    txtTemp_code.Text = Get_Quote_SeqNo();
            //    //txtTemp_code.Text = Get_Quote_SeqNo(txtSales_group.EditValue.ToString());
            //}
        }       

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            ////string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();

            //string strVer = gridView1.GetRowCellDisplayText(e.RowHandle, "ver");
            //string strTemp_ver = gridView1.GetRowCellDisplayText(e.RowHandle, "temp_ver");
            //if ((strVer != strTemp_ver) && !string.IsNullOrEmpty(strTemp_ver))
            //{
            //    e.Appearance.ForeColor = Color.Blue;
            //    e.Appearance.BackColor = Color.LemonChiffon;
            //}
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {       
            Set_CurrentRow_for_new_version(gridView1.FocusedRowHandle);            
        }

     
        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BTNCLOSE_Click(object sender, EventArgs e)
        {
            txtTemp_code.Focus();
            tabPage2.Parent = null;
        }

        private void BTNSAVE_VER_Click(object sender, EventArgs e)
        {
            Save_Ver();
        }

        private void Save_Ver()  //保存新增或修改的資料
        {
            txtTemp_code.Focus();
            if (dtDetail.Rows.Count == 0)
            {
                return;
            }
            gridView1.CloseEditor();          
            bool isSelect=false ;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "flag_select").ToString() == "True")
                {
                    isSelect = true;
                    break;
                }
            }
            if (isSelect == false)
            {
                MessageBox.Show("請首先選擇需要做新版本的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("請確認是否真的要保存當前已更改的數據?\n\r\r當前操作將產生新的版本!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            bool save_flag = false;
            string temp_code, ver, new_ver, strSelect, remark_pdd,remark,flag_vnd,flag_vnd_date;//,strPrice_Unit;
            float number_enter, price_usd, price_hkd, price_rmb, hkd_ex_fty, usd_ex_fty, discount, disc_price_usd, disc_price_hkd, disc_price_rmb, disc_hkd_ex_fty;
            float disc_price_vnd, vnd_bp, price_vnd_usd, price_vnd, price_vnd_grs, price_vnd_pcs;
            int result_u = 0,iDecimal;            
            //string str1 = "PCS,SET,DZ,DZS,PC,Pcs,pcs,Set,set";//小單位        
            //string str2 = "GRS,H,K,THD,GR,Grs"; 

            progressBar2.Value = 0;
            progressBar2.Step = 1;
            progressBar2.Maximum = gridView1.RowCount;

            string date_server = clsPublicOfCF01.ExecuteSqlReturnObject(@"Select convert(char(10),getdate(),120)");//取服務器日期
            string strBrand_id;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                progressBar2.Value += progressBar2.Step;
                strSelect = gridView1.GetRowCellValue(i, "flag_select").ToString();
                if (strSelect == "True")
                {
                    strBrand_id = gridView1.GetRowCellValue(i, "brand").ToString();
                    iDecimal = clsQuotation.Get_Decimal(strBrand_id);//不同牌子小數位
                    temp_code = gridView1.GetRowCellDisplayText(i, "temp_code");
                    ver = gridView1.GetRowCellDisplayText(i, "ver");
                    gridView1.SetRowCellValue(i, "temp_ver", ver);//保存更新前的版本,以便比较变更字体颜色
                    new_ver = Return_New_Version(gridView1.GetRowCellDisplayText(i, "ver"));
                    number_enter = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "number_enter"));
                    price_usd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_usd"));
                    price_hkd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_hkd"));
                    price_rmb = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_rmb"));
                    hkd_ex_fty = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "hkd_ex_fty"));
                    usd_ex_fty = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "usd_ex_fty"));

                    discount = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "discount"));
                    disc_price_vnd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "disc_price_vnd"));

                    flag_vnd = (gridView1.GetRowCellValue(i, "flag_vnd").ToString() == "True") ? "True" : "False";
                    if(string.IsNullOrEmpty(gridView1.GetRowCellValue(i, "flag_vnd_date").ToString()))
                    {
                        flag_vnd_date = "";
                    }
                    else
                    {
                        flag_vnd_date = gridView1.GetRowCellValue(i, "flag_vnd_date").ToString();
                    }                    
                    vnd_bp = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "vnd_bp"));
                    price_vnd_usd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_vnd_usd"));
                    price_vnd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_vnd"));
                    price_vnd_grs = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_vnd_grs"));
                    price_vnd_pcs = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_vnd_pcs"));
                    
                    //2016-12-15 增加以下代碼
                    //用戶不經BP計算,直接改單價,對應折扣單價也要跟著變化,所以加了判斷 
                    //strPrice_Unit = gridView1.GetRowCellDisplayText(i, "price_unit");
                    disc_price_usd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "disc_price_usd"));
                    if (price_usd != disc_price_usd)
                    {
                        if (discount == 0)
                            disc_price_usd = price_usd;
                        else             
                            disc_price_usd = (float)Math.Round(price_usd * (1 - discount / 100), iDecimal); 
                    }
                   
                    disc_price_hkd = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "disc_price_hkd"));
                    if (price_hkd != disc_price_hkd)
                    {
                        if (discount == 0)
                            disc_price_hkd = price_hkd;
                        else
                            disc_price_hkd = (float)Math.Round(price_hkd * (1 - discount / 100), iDecimal);
                    }
                    
                    disc_price_rmb = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "disc_price_rmb"));
                    if (price_rmb != disc_price_rmb)
                    {
                        if (discount == 0)
                            disc_price_rmb = price_rmb;
                        else
                        {                            
                            if (strBrand_id.Contains("CARV-01"))
                                disc_price_rmb = (float)Math.Round(price_rmb * (1 - discount / 100), 1);
                            else
                                disc_price_rmb = (float)Math.Round(price_rmb * (1 - discount / 100), iDecimal);
                        }
                    }
                    
                    disc_hkd_ex_fty = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "disc_hkd_ex_fty"));
                    if (hkd_ex_fty != disc_hkd_ex_fty)
                    {
                        if (discount == 0)
                            disc_hkd_ex_fty = hkd_ex_fty;
                        else
                            disc_hkd_ex_fty = (float)Math.Round(hkd_ex_fty * (1 - discount / 100), iDecimal);
                    }
                    //if (str1.Contains(strPrice_Unit)) //小單位
                    //{
                    //    disc_price_hkd = (float)Math.Round(disc_price_hkd, 1);//1位小數
                    //    disc_hkd_ex_fty = (float)Math.Round(disc_hkd_ex_fty, 1);//1位小數
                    //}
                    //if (str2.Contains(strPrice_Unit)) //大單位
                    //{
                    //    if (disc_price_hkd > 1)
                    //        disc_price_hkd = (float)Math.Round(disc_price_hkd);//四舍五入保留整
                    //    else
                    //        disc_price_hkd = (float)Math.Round(disc_price_hkd, 2);//四舍五入保留2位小數
                    //    if (disc_hkd_ex_fty > 1)
                    //        disc_hkd_ex_fty = (float)Math.Round(disc_hkd_ex_fty); //四舍五入保留整
                    //    else
                    //        disc_hkd_ex_fty = (float)Math.Round(disc_hkd_ex_fty, 2); //四舍五入保留2位小數
                    //}
                    remark_pdd = gridView1.GetRowCellDisplayText(i, "remark_pdd");
                    remark = gridView1.GetRowCellDisplayText(i, "remark");
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@user_id", DBUtility._user_id),
                        new SqlParameter("@temp_code", temp_code),
                        new SqlParameter("@ver",ver),
                        new SqlParameter("@new_ver",new_ver),
                        new SqlParameter("@number_enter",number_enter),  
                        new SqlParameter("@price_usd", price_usd),
                        new SqlParameter("@price_hkd", price_hkd),
                        new SqlParameter("@price_rmb", price_rmb),
                        new SqlParameter("@hkd_ex_fty", hkd_ex_fty),
                        new SqlParameter("@usd_ex_fty", usd_ex_fty),

                        new SqlParameter("@discount", discount),
                        new SqlParameter("@disc_price_usd", disc_price_usd),
                        new SqlParameter("@disc_price_hkd", disc_price_hkd),
                        new SqlParameter("@disc_price_rmb", disc_price_rmb),
                        new SqlParameter("@disc_hkd_ex_fty", disc_hkd_ex_fty),                       

                        new SqlParameter("@remark_pdd", remark_pdd),
                        new SqlParameter("@remark", remark),

                        new SqlParameter("@disc_price_vnd",disc_price_vnd),
                        new SqlParameter("@vnd_bp", vnd_bp),
                        new SqlParameter("@price_vnd_usd", price_vnd_usd),
                        new SqlParameter("@price_vnd", price_vnd),
                        new SqlParameter("@price_vnd_grs", price_vnd_grs),
                        new SqlParameter("@price_vnd_pcs", price_vnd_pcs),
                    };
                    result_u = clsPublicOfCF01.ExecuteNonQuery("usp_quotation_new_ver", paras, true);
                    if (result_u > 0)
                    {
                        //去掉打勾標識,幷更新版本
                        gridView1.SetRowCellValue(i, "flag_select", false);//??去掉打勾標識                        
                        gridView1.SetRowCellValue(i, "ver", new_ver);
                        gridView1.SetRowCellValue(i, "date", date_server);
                        save_flag = true;
                        //新版本成功后回寫至頁面1中
                        dtDetail.Rows[i]["date"] = date_server;
                        dtDetail.Rows[i]["ver"] = new_ver;
                        dtDetail.Rows[i]["number_enter"] = number_enter;
                        dtDetail.Rows[i]["price_usd"] = price_usd;
                        dtDetail.Rows[i]["price_hkd"] = price_hkd;
                        dtDetail.Rows[i]["price_rmb"] = price_rmb;                       
                        dtDetail.Rows[i]["hkd_ex_fty"] = hkd_ex_fty;
                        dtDetail.Rows[i]["usd_ex_fty"] = usd_ex_fty;

                        dtDetail.Rows[i]["discount"] = discount;
                        dtDetail.Rows[i]["disc_price_usd"] = disc_price_usd;
                        dtDetail.Rows[i]["disc_price_hkd"] = disc_price_hkd;
                        dtDetail.Rows[i]["disc_price_rmb"] = disc_price_rmb;
                        dtDetail.Rows[i]["disc_hkd_ex_fty"] = disc_hkd_ex_fty;                        

                        dtDetail.Rows[i]["remark_pdd"] = remark_pdd;
                        dtDetail.Rows[i]["remark"] = remark;

                        dtDetail.Rows[i]["disc_price_vnd"] = disc_price_vnd;
                        dtDetail.Rows[i]["flag_vnd"] = flag_vnd =="True"?true:false;
                        dtDetail.Rows[i]["flag_vnd_date"] = flag_vnd_date;
                        dtDetail.Rows[i]["vnd_bp"] = vnd_bp;
                        dtDetail.Rows[i]["price_vnd_usd"] = price_vnd_usd;
                        dtDetail.Rows[i]["price_vnd"] = price_vnd;
                        dtDetail.Rows[i]["price_vnd_grs"] = price_vnd_grs;
                        dtDetail.Rows[i]["price_vnd_pcs"] = price_vnd_pcs;
                        dtDetail.AcceptChanges();
                    }
                    else
                    {
                        save_flag = false;
                        break;
                    }
                }
            }
            
            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTemp_code.Focus();
                tabPage2.Parent = null;
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            progressBar2.Value = 0;
        }

        private string Return_New_Version(string pOldVer)
        {
            string strVer = (Convert.ToInt16(pOldVer) + 1).ToString();
            return strVer;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString().Trim();
            }
        }

        private void txtMo_id_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (editState!="" && txtMo_id.Text != "")
            {
                if (MessageBox.Show("是否從OC中帶出想關資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSql =string.Format(
                    @"SELECT A.it_customer,A.season,A.linkman,B.brand_id,B.customer_goods,B.customer_color_id,
                    D.name as product_desc,D.blueprint_id AS artwork,E.name AS name_color,F.name AS name_size,
                    G.name AS sales_man,H.english_name AS name_mat_en
                    FROM {0}so_order_manage A with(nolock)
                    INNER JOIN {0}so_order_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver 
                    INNER JOIN {0}so_order_bom C with(nolock)
	                    ON B.within_code=C.within_code AND B.id=C.id AND B.ver=C.ver AND B.sequence_id=C.upper_sequence AND C.primary_key='1'
                    INNER JOIN {0}it_goods D with(nolock) ON C.within_code=D.within_code AND C.goods_id=D.id 
                    INNER JOIN {0}cd_color E with(nolock) ON D.within_code=E.within_code AND D.color=E.id 
                    INNER JOIN {0}cd_size F with(nolock) ON D.within_code=F.within_code AND D.size_id=F.id
                    LEFT JOIN {0}cd_personnel G with(nolock) ON A.within_code=G.within_code AND A.seller_id=G.id
                    INNER JOIN {0}cd_datum H with(nolock) ON D.within_code=H.within_code AND D.datum=H.id 
                    WHERE A.within_code='0000' AND B.mo_id='{1}'",DBUtility.remote_db,txtMo_id.Text);                    
                    System.Data.DataTable dt = new System.Data.DataTable();
                    //dt = clsConErp.GetDataTable(strSql);
                    dt = clsPublicOfCF01.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        txtBrand.EditValue =dt.Rows[0]["brand_id"].ToString();
                        txtSeason.EditValue = dt.Rows[0]["season"].ToString();
                        txtContact.Text = dt.Rows[0]["linkman"].ToString();
                        txtMaterial.Text = dt.Rows[0]["name_mat_en"].ToString();
                        txtSize.Text = dt.Rows[0]["name_size"].ToString();
                        txtProduct_desc.Text = dt.Rows[0]["product_desc"].ToString();
                        txtAccount_code.Text = dt.Rows[0]["it_customer"].ToString();
                        txtCust_code.Text = dt.Rows[0]["customer_goods"].ToString();
                        txtCust_color.Text = dt.Rows[0]["customer_color_id"].ToString();
                        txtCf_code.Text = dt.Rows[0]["artwork"].ToString();
                        txtCf_color.Text = dt.Rows[0]["name_color"].ToString();
                        txtSalesman.Text = dt.Rows[0]["sales_man"].ToString();
                    }
                }
            }
        }
           
        private void cl_ver_DoubleClick(object sender, EventArgs e)
        {
            using (frmQuotation_Price_List ofrm = new frmQuotation_Price_List(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "temp_code").ToString(),is_group_pdd))
            {
                ofrm.ShowDialog();
            }
        }

        private void txtBrandDesc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string strbrand_id = txtBrand.EditValue.ToString();
            if (string.IsNullOrEmpty(strbrand_id))
            {
                strbrand_id = "*";
            }
            using (frmQuotation_Formula ofrm = new frmQuotation_Formula() { init_brand_id = strbrand_id, call_is_flag = "Y" })
            {
                ofrm.ShowDialog();
            }
        }

        private void txtBrand_Click(object sender, EventArgs e)
        {
            txtBrand.SelectAll();
        }

        private void txtSeason_Click(object sender, EventArgs e)
        {
            txtSeason.SelectAll();
        }

        private void txtFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (editState== "NEW" || editState== "EDIT")
            {
                string formula = txtFormula.Text;
                using (frmQuotation_Formula_Set ofrm = new frmQuotation_Formula_Set(formula))
                {
                    ofrm.ShowDialog();
                    if (!string.IsNullOrEmpty(ofrm.brand_Selected))
                    {
                        txtFormula.Text = ofrm.brand_Selected;
                                              
                        if (string.IsNullOrEmpty(txtPrice_unit.Text))
                        {                               
                            return;
                        }
                        CalcuPrice(); //0為正常的單價計算,1為越南單價                
                        CalcuPriceDisc(txtDisc.Text);
                        txtRmb_remark.Text = clsQuotation.Get_Rmb_Remark(txtFormula.Text);    
                    }                    
                }
            }
        }

        private void txtBrandDesc_MouseEnter(object sender, EventArgs e)
        {
            SetTipInfo(txtBrandDesc, "設置牌子對應的計價公式");
        }

        private void txtFormula_MouseEnter(object sender, EventArgs e)
        {            
            SetTipInfo(txtFormula, "更改引用的計價公式");
        }

        private void txtMo_id_MouseEnter(object sender, EventArgs e)
        {
            SetTipInfo(txtMo_id, "根據頁數從OC中獲取相關資料");
        }

        private void txtSeasonDesc_MouseEnter(object sender, EventArgs e)
        {
            SetTipInfo(txtSeasonDesc, "設置季度資料");
        }

        private static void SetTipInfo(Control obj, string strInfo)
        {
            ToolTip p = new ToolTip() { ShowAlways = true };
            p.SetToolTip(obj, strInfo);           
        }

        private void txtSeasonDesc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //using (frmSeason ofrm = new frmSeason())
            //{               
            //    ofrm.ShowDialog();
            //}
        }

        private void btnAddsub_Click(object sender, EventArgs e)
        {
            if ((editState== "" || editState== "EDIT") && txtTemp_code.Text != "")
            {
                using (frmQuotationSub ofrm = new frmQuotationSub(txtTemp_code.Text))
                {
                    ofrm.ShowDialog();
                    Display_Sub_List(txtTemp_code.Text);
                }
            }
        }

        private void dgvSub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvSub.Columns[e.ColumnIndex].Name == "attn_path")
            {
                //打開PDF檔
                string strFile = dgvSub.Rows[e.RowIndex].Cells["attn_path"].Value.ToString();                               
                if (!string.IsNullOrEmpty(strFile))
                {                    
                    clsTestProductPlan.Open_test_pdf(strFile);
                }
            }
        }


        private void cl_number_enter_Leave(object sender, EventArgs e)
        {
            gridView1.CloseEditor();//此行很重要,輸入值立即有較
            BP_Calc(gridView1.FocusedRowHandle);
        }

        private void BP_Calc(int i)
        {            
            string formula_id = gridView1.GetRowCellValue(i, "formula_id").ToString();
            string brand_id = gridView1.GetRowCellValue(i, "brand").ToString();
            string strDisc = gridView1.GetRowCellValue(i, "discount").ToString();
            float bp=0.00f,temp_disc_rate;
            if (gridView1.GetRowCellValue(i, "number_enter").ToString() == "")            
                bp = 0.00f;
            else
                bp = float.Parse(gridView1.GetRowCellValue(i, "number_enter").ToString());
            string strUnit = gridView1.GetRowCellValue(i, "price_unit").ToString();           
            bool flag_vn = gridView1.GetRowCellValue(i, "flag_vnd").ToString() == "True" ? true : false;
            string vnd_bp = gridView1.GetRowCellValue(i, "vnd_bp").ToString();

            mdlFormula_Result objResult = new mdlFormula_Result();
            if (bp > 0)
            {
                objResult = clsQuotation.Get_Cust_Formula(brand_id,formula_id, bp.ToString(), strUnit,vnd_bp, flag_vn);
            }
            else
            {
                objResult.price_usd = 0;
                objResult.price_hkd = 0;
                objResult.price_rmb = 0;
                objResult.price_vnd = 0;
                objResult.hkd_ex_fty = 0;
                objResult.usd_ex_fty = 0;
                //越南單價
                objResult.vnd_bp = 0;
                objResult.price_vnd_usd = 0;
                objResult.price_vnd = 0;
                objResult.price_vnd_grs = 0;
                objResult.price_vnd_pcs = 0;
            }
            gridView1.SetRowCellValue(i, "price_usd", objResult.price_usd);
            gridView1.SetRowCellValue(i, "price_rmb", objResult.price_rmb);
            gridView1.SetRowCellValue(i, "price_hkd", objResult.price_hkd);
            gridView1.SetRowCellValue(i, "price_vnd", objResult.price_vnd);
            gridView1.SetRowCellValue(i, "hkd_ex_fty", objResult.hkd_ex_fty);
            gridView1.SetRowCellValue(i, "usd_ex_fty", objResult.usd_ex_fty);
            //越南單價
            gridView1.SetRowCellValue(i, "vnd_bp", objResult.vnd_bp);
            gridView1.SetRowCellValue(i, "price_vnd_usd", objResult.price_vnd_usd);
            gridView1.SetRowCellValue(i, "price_vnd", objResult.price_vnd);
            gridView1.SetRowCellValue(i, "price_vnd_grs", objResult.price_vnd_grs);
            gridView1.SetRowCellValue(i, "price_vnd_pcs", objResult.price_vnd_pcs);

            //計算折扣單價
            temp_disc_rate = clsApp.Return_Float_Value(strDisc);
            if (temp_disc_rate == 0)//如果當前折扣率是0，則用公式中折扣率
            {
                temp_disc_rate = objResult.discount;
                gridView1.SetRowCellValue(i, "discount", objResult.discount);
            }

            objResult = clsQuotation.Get_Cust_Formula_Disc(brand_id, temp_disc_rate.ToString(), objResult,txtPrice_unit.EditValue.ToString());           
            gridView1.SetRowCellValue(i, "disc_price_usd", objResult.disc_price_usd);
            gridView1.SetRowCellValue(i, "disc_price_rmb", objResult.disc_price_rmb);
            gridView1.SetRowCellValue(i, "disc_price_hkd", objResult.disc_price_hkd);
            gridView1.SetRowCellValue(i, "disc_price_vnd", objResult.disc_price_vnd);
            gridView1.SetRowCellValue(i, "disc_hkd_ex_fty", objResult.disc_hkd_ex_fty);
        }
               
        private void cl_discount_Leave(object sender, EventArgs e)
        {
            //單獨更改折扣率后得新計算折扣單價 
            int i = gridView1.FocusedRowHandle;
            string brand_id = gridView1.GetRowCellValue(i, "brand").ToString();
            string strDisc = gridView1.GetRowCellValue(i, "discount").ToString();
            mdlFormula_Result objDisc = new mdlFormula_Result();
            objDisc.price_usd = float.Parse(gridView1.GetRowCellValue(i, "price_usd").ToString()); ; //clsApp.Return_Float_Value(txtPrice_usd.Text);
            objDisc.price_hkd = float.Parse(gridView1.GetRowCellValue(i, "price_hkd").ToString());
            objDisc.price_rmb = float.Parse(gridView1.GetRowCellValue(i, "price_rmb").ToString());
            objDisc.price_vnd = float.Parse(gridView1.GetRowCellValue(i, "price_vnd").ToString());
            objDisc.hkd_ex_fty = float.Parse(gridView1.GetRowCellValue(i, "hkd_ex_fty").ToString());
            objDisc = clsQuotation.Get_Cust_Formula_Disc(brand_id, strDisc, objDisc, txtPrice_unit.EditValue.ToString());

            gridView1.SetRowCellValue(i, "disc_price_usd", objDisc.disc_price_usd);
            gridView1.SetRowCellValue(i, "disc_price_rmb", objDisc.disc_price_rmb);
            gridView1.SetRowCellValue(i, "disc_price_hkd", objDisc.disc_price_hkd);
            gridView1.SetRowCellValue(i, "disc_price_vnd", objDisc.disc_price_vnd);
            gridView1.SetRowCellValue(i, "disc_hkd_ex_fty", objDisc.disc_hkd_ex_fty);
        }


        private void frmQuotation_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtDetail = null;
            dtReSet = null;
            dtVersion = null;
            dtSubmo = null;
            clsApp = null;
            dgvrow = null;
            clsConErp = null;
            if (frmQuotationFind != null)
            {
                frmQuotationFind.Dispose();
            }
        }

        private void BTNQUOTATION_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }               
            txtTemp_code.Focus();                       
            List<mdlQuotation_Reprot> mList = new List<mdlQuotation_Reprot>();
            bool isSelect = false;
            //mdlQuotation_Reprot objModel = new mdlQuotation_Reprot();
            //System.Data.DataTable dtTempAdd = clsQuotation.GetSortDataTable(dgvDetails);//按用戶的排序先后順序插入表格            
            //return;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["flagSelect"].Value.ToString() == "True")
                {
                    mdlQuotation_Reprot objModel = new mdlQuotation_Reprot()
                    {
                        brand = dgvDetails.Rows[i].Cells["brand"].Value.ToString(),
                        division = dgvDetails.Rows[i].Cells["division"].Value.ToString(),
                        contact = dgvDetails.Rows[i].Cells["contact"].Value.ToString(),
                        material = dgvDetails.Rows[i].Cells["material"].Value.ToString(),
                        size = dgvDetails.Rows[i].Cells["size"].Value.ToString(),
                        product_desc = dgvDetails.Rows[i].Cells["product_desc"].Value.ToString(),
                        cust_code = dgvDetails.Rows[i].Cells["cust_code"].Value.ToString(),
                        cf_code = dgvDetails.Rows[i].Cells["cf_code"].Value.ToString(),
                        cust_color = dgvDetails.Rows[i].Cells["cust_color"].Value.ToString(),
                        cf_color = dgvDetails.Rows[i].Cells["cf_color"].Value.ToString(),
                        price_usd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_usd"].Value.ToString()),
                        price_hkd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_hkd"].Value.ToString()),
                        price_rmb = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_rmb"].Value.ToString()),                       
                        moq = Int32.Parse(dgvDetails.Rows[i].Cells["moq"].Value.ToString()),
                        price_unit = dgvDetails.Rows[i].Cells["price_unit"].Value.ToString(),
                        temp_code = dgvDetails.Rows[i].Cells["temp_code"].Value.ToString(),
                        ver = dgvDetails.Rows[i].Cells["ver"].Value.ToString(),
                        remark = dgvDetails.Rows[i].Cells["remark"].Value.ToString(),
                        moq_desc = dgvDetails.Rows[i].Cells["moq_desc"].Value.ToString(),
                        moq_unit = dgvDetails.Rows[i].Cells["moq_unit"].Value.ToString(),
                        season = dgvDetails.Rows[i].Cells["season"].Value.ToString(),
                        salesman = dgvDetails.Rows[i].Cells["salesman"].Value.ToString(),
                        mwq = Int32.Parse(dgvDetails.Rows[i].Cells["mwq"].Value.ToString()),
                        lead_time_min = Int32.Parse(dgvDetails.Rows[i].Cells["lead_time_min"].Value.ToString()),
                        lead_time_max = Int32.Parse(dgvDetails.Rows[i].Cells["lead_time_max"].Value.ToString()),
                        lead_time_unit = dgvDetails.Rows[i].Cells["lead_time_unit"].Value.ToString(),
                        md_charge = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["md_charge"].Value.ToString()),
                        md_charge_cny = dgvDetails.Rows[i].Cells["md_charge_cny"].Value.ToString(),
                        number_enter = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["number_enter"].Value.ToString()),
                        hkd_ex_fty = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["hkd_ex_fty"].Value.ToString()),
                        usd_ex_fty = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["usd_ex_fty"].Value.ToString()),
                        sales_group = dgvDetails.Rows[i].Cells["sales_group"].Value.ToString(),
                        moq_for_test = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["moq_for_test"].Value.ToString()),                       
                        usd_dap = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["usd_dap"].Value.ToString()),
                        usd_lab_test_prx = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["usd_lab_test_prx"].Value.ToString()),
                        ex_fty_hkd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["ex_fty_hkd"].Value.ToString()),
                        ex_fty_usd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["ex_fty_usd"].Value.ToString()),
                        discount = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["discount"].Value.ToString()),
                        disc_price_usd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["disc_price_usd"].Value.ToString()),
                        disc_price_hkd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["disc_price_hkd"].Value.ToString()),
                        disc_price_rmb = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["disc_price_rmb"].Value.ToString()),
                        disc_price_vnd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["disc_price_vnd"].Value.ToString()),
                        disc_hkd_ex_fty = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["disc_hkd_ex_fty"].Value.ToString()),                        
                        die_mould_usd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["die_mould_usd"].Value.ToString()),
                        die_mould_cny = dgvDetails.Rows[i].Cells["die_mould_cny"].Value.ToString(),
                        rmb_remark = dgvDetails.Rows[i].Cells["rmb_remark"].Value.ToString(),
                        cust_artwork = dgvDetails.Rows[i].Cells["cust_artwork"].Value.ToString(),
                        //2023/02/13加入越南單價                        
                        price_vnd_usd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_vnd_usd"].Value.ToString()),
                        price_vnd = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_vnd"].Value.ToString()),
                        price_vnd_grs = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_vnd_grs"].Value.ToString()),
                        price_vnd_pcs = clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["price_vnd_pcs"].Value.ToString()),
                        //2023/03/01 add
                        cf_color_id= dgvDetails.Rows[i].Cells["cf_color_id"].Value.ToString(),
                        material_type = dgvDetails.Rows[i].Cells["material_type"].Value.ToString(),
                        product_type = dgvDetails.Rows[i].Cells["product_type"].Value.ToString()
                    };
                    mList.Add(objModel);
                    isSelect = true;
                }
            }
            if (isSelect)
            {
                using (frmQuotation_Report ofrm = new frmQuotation_Report())
                {
                    ofrm.mList = mList;
                    ofrm.AddNew();
                    ofrm.ShowDialog();                    
                }
                Select_All(false);
            }
            else
            {
                MessageBox.Show("請首先選中要生成報價單的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {           
            if (editState== "" && txtTemp_code.Text != "")
            {
                using (frmQuotation_Group ofrm = new frmQuotation_Group(txtTemp_code.Text,txtSales_group.EditValue.ToString()))
                {
                    ofrm.ShowDialog();
                    Display_Group_List(txtTemp_code.Text);
                }
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (editState== ""  && txtTemp_code.Text != "")
            {
                using (frmQuotationSub ofrm = new frmQuotationSub(txtTemp_code.Text))
                {
                    ofrm.ShowDialog();
                    dtSubmo = clsQuotation.GetSub(txtTemp_code.Text);
                    dgvSub.DataSource = dtSubmo;
                    //Display_Sub_List(txtTemp_code.Text);
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (editState != "")
                return;

            if (chkSelectAll.Checked)
            {
                Select_All(true);
            }
            else
            {
                Select_All(false);
            }             
        }

        private void Select_All(bool _flag)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    dtDetail.Rows[i]["flag_select"] = _flag;
                }
            }
        }

        private void BTNDEL_BATCH_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            txtTemp_code.Focus();
            DataRow[] drs = dtDetail.Select("flag_select=true");

            if (drs.Length == 0)
            {
                MessageBox.Show("請選擇要刪除的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (drs.Length > 300)
            {
                MessageBox.Show("注意：一次最多可以刪除300條記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "Update dbo.quotation Set flag_del='1',amusr=@user_id,amtim=getdate() WHERE temp_code=@temp_code";                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                bool isSelect = false;
                try
                {
                    using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                    {
                        foreach (DataRow dr in drs)
                        {
                            myCommand.CommandText = sql_del;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@temp_code", dr["temp_code"].ToString());
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.ExecuteNonQuery();
                            dtDetail.Rows.Remove(dr); //移走當前行                           
                            isSelect = true; 
                        }
                        myTrans.Commit(); //數據提交
                    }
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    isSelect = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }
                if(isSelect)
                    MessageBox.Show("數據刪除成功!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("數據刪除失敗!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDisc_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {               
                CalcuPriceDisc(txtDisc.Text);
            }
        }

        private void CalcuPriceDisc(string pDisc)
        {
            mdlFormula_Result objDisc = new mdlFormula_Result();
            objDisc.price_usd = clsApp.Return_Float_Value(txtPrice_usd.Text);
            objDisc.price_hkd = clsApp.Return_Float_Value(txtPrice_hkd.Text);
            objDisc.price_rmb = clsApp.Return_Float_Value(txtPrice_rmb.Text);
            objDisc.hkd_ex_fty = clsApp.Return_Float_Value(txtHkd_ex_fty.Text);
            objDisc.price_vnd = clsApp.Return_Float_Value(txtPrice_vnd.Text);
            objDisc = clsQuotation.Get_Cust_Formula_Disc(txtBrand.EditValue.ToString(), pDisc, objDisc, txtPrice_unit.EditValue.ToString());

            txtDisc_usd.Text = objDisc.disc_price_usd.ToString();
            txtDisc_hkd.Text = objDisc.disc_price_hkd.ToString();
            txtDisc_rmb.Text = objDisc.disc_price_rmb.ToString();
            txtDisc_hkd_ex_fty.Text = objDisc.disc_hkd_ex_fty.ToString();
            txtDisc_vnd.Text = objDisc.disc_price_vnd.ToString();
        }


        private void Excel1() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "保存EXECL文件";
                saveDialog.Filter = "EXECL文件|*.xls";
                saveDialog.FilterIndex = 1;
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
                        FormatNum = -4143;
                    else //you use excel 2007 or later                    
                        FormatNum = 56;
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                    //寫入欄位標題
                    string field_name = "";
                    string strSub_mo = "sub_1,sub_2,sub_3,sub_4,sub_5,sub_6,sub_7";
                    int col = 0;
                    for (int i = 0; i < dgvDetails.Columns.Count; i++)
                    {
                        field_name = dgvDetails.Columns[i].Name;
                        if (dgvDetails.Columns[i].Visible || strSub_mo.Contains(field_name))
                        {
                            col += 1;
                            worksheet.Cells[1, col] = dgvDetails.Columns[i].HeaderText;
                        }
                        else
                            continue;
                    }
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體


                    //寫入數值
                    string strDate;
                    int row = 1;//從第2行起寫入值
                    for (int r = 0; r < dgvDetails.RowCount; r++)//行循環
                    {
                        if (dgvDetails.Rows[r].Cells["flagselect"].Value.ToString() == "True")
                        {
                            row += 1;
                            col = 0;
                            for (int i = 0; i < dgvDetails.Columns.Count; i++) //列循環
                            {
                                field_name = dgvDetails.Columns[i].Name;//取得列名稱
                                if (dgvDetails.Columns[i].Visible || strSub_mo.Contains(field_name))
                                {
                                    col += 1;                                    
                                    if (field_name == "date" || field_name == "valid_date")
                                    {
                                        strDate = dgvDetails.Rows[r].Cells[field_name].Value.ToString();
                                        if (!string.IsNullOrEmpty(strDate))
                                            strDate = DateTime.Parse(strDate).ToString("yyyy/MM/dd");
                                        else
                                            strDate = "";
                                        worksheet.Cells[row, col] = strDate;
                                    }
                                    else
                                        worksheet.Cells[row, col] = dgvDetails.Rows[r].Cells[field_name].Value.ToString();
                                    worksheet.Rows[row].Font.Size = 10;
                                }
                                else
                                    continue;
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                    worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                   // wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            workbook.SaveAs(FileName, FormatNum);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁                    
                    MessageBox.Show("匯出EXCEL成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void RetSet_Discount_Price(DevExpress.XtraEditors.TextEdit objTextEdit)
        {           
            int iDecimal = clsQuotation.Get_Decimal(txtBrand.EditValue.ToString());

            float fDisc,fvalue;
            if (string.IsNullOrEmpty(txtDisc.Text))
                fDisc = 0;
            else
                fDisc = clsApp.Return_Float_Value(txtDisc.Text);        

            fvalue = clsApp.Return_Float_Value(objTextEdit.Text);
            fvalue = (float)Math.Round(fvalue * (1 - fDisc / 100), iDecimal);
            string str = objTextEdit.Name;
            if (str == "txtPrice_usd")
            {
                if (fDisc == 0)
                    txtDisc_usd.EditValue = objTextEdit.EditValue;
                else
                    txtDisc_usd.EditValue = fvalue;
            }
            if (str == "txtPrice_hkd")
            {
                if (fDisc == 0)
                    txtDisc_hkd.EditValue = objTextEdit.EditValue;
                else
                    txtDisc_hkd.EditValue = fvalue;
            }
            if (str == "txtPrice_rmb")
            {
                if (fDisc == 0)
                    txtDisc_rmb.EditValue = objTextEdit.EditValue;
                else
                    txtDisc_rmb.EditValue = fvalue;
            }
            if (str == "txtHkd_ex_fty")
            {
                if (fDisc == 0)
                    txtHkd_ex_fty.EditValue = objTextEdit.EditValue;
                else
                    txtHkd_ex_fty.EditValue = fvalue;
            }
            if (str == "txtPrice_vnd")
            {
                if (fDisc == 0)
                    txtDisc_vnd.EditValue = objTextEdit.EditValue;
                else
                    txtDisc_vnd.EditValue = fvalue;
            }
        }

        private void txtPrice_usd_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                RetSet_Discount_Price(txtPrice_usd);
            }
        }

        private void txtPrice_hkd_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                RetSet_Discount_Price(txtPrice_hkd);
            }
        }

        private void txtPrice_rmb_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                RetSet_Discount_Price(txtPrice_rmb);
            }
        }

        private void txtHkd_ex_fty_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                RetSet_Discount_Price(txtHkd_ex_fty);
            }
        }

        private void txtPrice_vnd_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                RetSet_Discount_Price(txtPrice_vnd);
            }
        }
        private void BTNFORMULA_Click(object sender, EventArgs e)
        {
            if (chkRmb.Checked == false && chkAllPrice.Checked == false)
            {
                MessageBox.Show("請首先選擇需要重新計算的單價類型!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string strcny ;
            if (chkRmb.Checked)
                strcny = chkRmb.Text;
            else
                strcny = chkAllPrice.Text;
            DialogResult result = MessageBox.Show(string.Format("確認是否用最新公式设定值统一更新：\n\r\n\r【{0}】單價?", strcny),"提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            bool isSelect = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "flag_select").ToString() == "True")
                {
                    isSelect = true;
                    break;
                }
            }
            if (isSelect == false)
            {
                MessageBox.Show("請首先選擇需要重新進行單價計算的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strSelect,strFormula,strSql,strBrand_id;           
            float number_enter, price_rmb,disc_price_rmb, discount,p_rmb1,p_rmb2;
            System.Data.DataTable dtFormula;
            
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                 strSelect = gridView1.GetRowCellValue(i, "flag_select").ToString();
                 if (strSelect == "True")
                 {
                     if (chkRmb.Checked) //用新公式重新計算RMB
                     {
                         strFormula = gridView1.GetRowCellDisplayText(i, "formula_id");
                         if (string.IsNullOrEmpty(strFormula))
                             strFormula = "*";
                         strSql = string.Format("Select rmb1,rmb2 From quotation_formula Where brand_id='{0}'", strFormula);
                         dtFormula = clsPublicOfCF01.GetDataTable(strSql);
                         if (dtFormula.Rows.Count == 0) //如果非*的牌子公式查找不到對應公式,重新用*的公式
                         {
                             strFormula = "*";
                             strSql = string.Format("Select rmb1,rmb2 From quotation_formula Where brand_id='{0}'", strFormula);
                             dtFormula = clsPublicOfCF01.GetDataTable(strSql);
                         }
                         p_rmb1 = clsApp.Return_Float_Value(dtFormula.Rows[0]["rmb1"].ToString());
                         p_rmb2 = clsApp.Return_Float_Value(dtFormula.Rows[0]["rmb2"].ToString());
                         discount = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "discount"));
                         number_enter = clsApp.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "number_enter"));
                         price_rmb = (float)Math.Round(number_enter * p_rmb1 * p_rmb2, 2);
                         if (discount > 0)
                         {
                             disc_price_rmb = (float)Math.Round(price_rmb * (1 - discount / 100), 2); ;
                         }
                         else
                             disc_price_rmb = price_rmb;
                         strBrand_id = gridView1.GetRowCellValue(i, "brand").ToString();
                         if (strBrand_id.Contains("CARV-01"))
                         {
                             price_rmb = float.Parse(Math.Round(price_rmb, 1).ToString());
                             disc_price_rmb = float.Parse(Math.Round(disc_price_rmb, 1).ToString());
                         }
                         gridView1.SetRowCellValue(i, "price_rmb", price_rmb);
                         gridView1.SetRowCellValue(i, "disc_price_rmb", disc_price_rmb);
                     }
                     else
                         BP_Calc(i); //用新公式重新計算全部單價
                 }
            }
            gridView1.CloseEditor();
            MessageBox.Show(string.Format("按照公式重新計算[{0}]已完成!,\n\r\n\r請再點擊【保存新版本】按鈕,保存更改后的數據!",strcny), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void chkRmb_Click(object sender, EventArgs e)
        {
            //if (chkRmb.Checked)
                //chkAllPrice.Checked = false;
        }

        private void chkAllPrice_Click(object sender, EventArgs e)
        {
            if (chkAllPrice.Checked)
                chkRmb.Checked = false;
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (BTNSAVE.Selected)
            {
                txtRemark.Focus();
            }            
        }

        private void Set_Moq(string strBrand, string strUnit)
        {
            if (strBrand != "" && strUnit != "")
            {               
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = clsPublicOfCF01.GetDataTable(string.Format("Select moq_unit,moq FROM quotation_moq Where brand_id='{0}' and moq_unit='{1}'", txtBrand.EditValue, txtPrice_unit.EditValue));
                if (dt.Rows.Count > 0)
                {
                    txtMoq.Text = dt.Rows[0]["moq"].ToString();
                    txtMoq_unit.EditValue = dt.Rows[0]["moq_unit"].ToString();
                }
                dt.Dispose();                
            }
        }

        private void txtPrice_unit_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
               Set_Moq(txtBrand.EditValue.ToString(), txtPrice_unit.EditValue.ToString());
            }
        }

        private void textEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {            
            string custArtworkPath = imagePath+"\\quo_photo";// clsQuotation.cust_artwork_path; 
            if (editState == "NEW" || editState == "EDIT")
            {
                OpenFileDialog openFile = new OpenFileDialog() {
                    Filter = "Files Path|*.BMP;*.JPG",
                    RestoreDirectory = true, 
                    Title = "客戶圖樣相關文檔",
                    InitialDirectory = custArtworkPath
                };                
                openFile.ShowDialog();
                string strFile = openFile.FileName;                
                if (strFile != "")
                {                   
                    txtCustartwork.Text = clsQuotation.GetConString(strFile, imagePath);                   
                }               
            }

            //if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            //{
            //    OpenFileDialog openFile = new OpenFileDialog();
            //    openFile.Filter = "Files Path|*.msg;*.PDF";
            //    //openFile.Filter = "PDF Files |*.PDF";
            //    openFile.RestoreDirectory = true;
            //    openFile.Title = "鍊接的測試報告相關文檔";
            //    openFile.InitialDirectory = test_public_path; //初始測試報告路徑      
            //    openFile.ShowDialog();

            //    string strFile = openFile.FileName;
            //    if (strFile != "")
            //    {
            //        string strReport_path = GetConString(strFile, test_public_path);
            //        btnEditTest_report_Path.Text = strReport_path;
            //    }
            //}
        }

   

        private void txtCf_code_Leave(object sender, EventArgs e)
        { 
            if (editState != "" && txtCf_code.Text != "")
            {                
                if (!clsQuotation.Check_Artwork(txtCf_code.Text))
                {
                    MessageBox.Show("CF圖樣代碼不存在！", "提示信息");
                }
            }
        }

        /// <summary>
        /// 參數：strType=1無圖樣;strType=2有圖樣
        /// </summary>
        /// <param name="strType"></param>
        void Export_Excel_Art(string strType)
        {
            if (dgvDetails.RowCount > 0)
            {                
                //判斷是否有選取的行
                bool isSelect = false;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++) //開始行循環
                {
                    if (dgvDetails.Rows[rowNo].Cells["flagSelect"].Value.ToString() == "True")
                    {
                        isSelect = true;
                        break;
                    }
                }
                if (isSelect == false)
                {
                    MessageBox.Show("請選取要匯出EXCEL的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog()
                {                   
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
                    Workbooks workbooks = xlApp.Workbooks;
                    Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Worksheet worksheet = (Worksheet)workbook.Worksheets[1];//取得sheet1  
                   
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體       
                    worksheet.Columns[67].ColumnWidth = 11;

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();
                    
                    //循環列,寫入各欄位標題    
                    int cur_column = 0;
                    for (int i = 2; i < dgvDetails.Columns.Count; i++)
                    {
                        //列是可見的或列名是(隱藏的列seq_id，name_brand)
                        if (dgvDetails.Columns[i].Visible )
                        {
                            cur_column = cur_column + 1;
                            if (dgvDetails.Columns[i].DataPropertyName == "cust_artwork")
                                worksheet.Cells[1, cur_column] = "ArtWork";
                            else
                                worksheet.Cells[1, cur_column] = dgvDetails.Columns[i].HeaderText;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    //worksheet.Rows[3].RowHeight = 23;

                    //寫入數值
                    string field_name, rang = "";
                    string pictrue_path = "";
                    string strSql = "";
                    System.Data.DataTable dt = new System.Data.DataTable();
                    int curRowIndex = 1;//當前行變量
                    cur_column = 0;//當前列變量
                    for (int r = 0; r < dgvDetails.RowCount; r++)//行
                    {
                        if (dgvDetails.Rows[r].Cells["flagSelect"].Value.ToString() == "True")
                        {
                            curRowIndex = curRowIndex + 1;//EXCEL當前行計數變量
                            if (strType == "2")
                            {
                                //圖片路徑,有CF圖樣以CF圖樣為準，沒有就以客戶圖樣為準                            
                                if (!string.IsNullOrEmpty(dgvDetails.Rows[r].Cells["cf_code"].Value.ToString()))
                                {
                                    strSql = string.Format(
                                    @"Select TOP 1 Isnull(picture_name_h,'') as picture_name From {0}cd_pattern with(nolock) 
                                    Where within_code='0000' And id='{1}'", DBUtility.remote_db, dgvDetails.Rows[r].Cells["cf_code"].Value);
                                    dt = clsPublicOfCF01.GetDataTable(strSql);
                                    if (dt.Rows.Count > 0)
                                    {
                                        pictrue_path = @"\\192.168.3.12\cf_artwork\Artwork\" + dt.Rows[0]["picture_name"];
                                    }
                                    else
                                    {
                                        pictrue_path = "";
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(dgvDetails.Rows[r].Cells["cust_artwork"].Value.ToString()))
                                    {
                                        pictrue_path = "";
                                    }
                                    else
                                    {
                                        pictrue_path = dgvDetails.Rows[r].Cells["cust_artwork"].Value.ToString();
                                    }
                                }
                                //worksheet.Columns[11].ColumnWidth = 11;//圖樣
                            }
                            //寫入列的值
                            cur_column = 0;
                            for (int i = 2; i < dgvDetails.Columns.Count; i++) //列
                            {
                                if (dgvDetails.Columns[i].Visible) //只處理可見列
                                {
                                    cur_column = cur_column + 1;//可見列順序計數變量
                                    field_name = dgvDetails.Columns[i].Name;//當前可見列名                                    
                                    if (field_name == "price_unit") //2017/03/15將H轉成100Pcs
                                    {
                                        if (dgvDetails.Rows[r].Cells[field_name].Value.ToString() == "H")
                                        {
                                            worksheet.Cells[curRowIndex, cur_column] = "100PCS";
                                        }
                                    }
                                    if (field_name == "date" || field_name == "valid_date")
                                        if (!string.IsNullOrEmpty(dgvDetails.Rows[r].Cells[field_name].Value.ToString()))//處理空日期出錯的問題
                                            worksheet.Cells[curRowIndex, cur_column] = "'" + System.DateTime.Parse(dgvDetails.Rows[r].Cells[field_name].Value.ToString()).ToString("yyyy/MM/dd");
                                        else
                                            worksheet.Cells[curRowIndex, cur_column] = "";
                                    else
                                        worksheet.Cells[curRowIndex, cur_column] = dgvDetails.Rows[r].Cells[field_name].Value.ToString();
                                    worksheet.Rows[curRowIndex].Font.Size = 10;

                                    if (field_name == "cust_artwork")
                                    {
                                        if (strType == "2")
                                        {
                                            worksheet.Cells[curRowIndex, cur_column] = "";
                                            rang = "BO" + (curRowIndex); //插入圖片的位置
                                            if (File.Exists(pictrue_path))
                                            {
                                                worksheet.Rows[curRowIndex].RowHeight = 70;
                                                clsQuotation.InsertPicture(rang, worksheet, pictrue_path);//插入圖片
                                            }
                                        }
                                        else
                                        {
                                            worksheet.Cells[curRowIndex, cur_column] = "";
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            System.Windows.Forms.Application.DoEvents();
                        }
                        else
                        {
                            continue;
                        }
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                    if (strType == "2")
                    {
                        worksheet.Columns[11].ColumnWidth = 12;
                    }
                    worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    wForm.Invoke((EventHandler)delegate { wForm.Close(); });

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
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BTNCALCULATEPRICE_Click(object sender, EventArgs e)
        {
            sent_quotation = txtTemp_code.Text;
            //bool isExist_flag = false;
            ////檢查是否已打開，若已打開了，則激活即可
            //string childFrmName = "frmMmCalculatePrice";
            //foreach (Form childFrm in frm_Main.pMainWin.MdiChildren)
            //{
            //    if (childFrm.Name == childFrmName)
            //    {
            //        if (childFrm.WindowState == FormWindowState.Minimized)
            //        {
            //            childFrm.WindowState = FormWindowState.Maximized;
            //        }
            //        childFrm.Activate();
            //        isExist_flag = true;
            //        break;
            //    }
            //}
            //if (!isExist_flag)
            //{
                frmMmCalculatePrice frmMmCalculatePrice = new frmMmCalculatePrice();
                frmMmCalculatePrice.ShowDialog();
            //}
        }

        private void btnLabTest_Click(object sender, EventArgs e)
        {
            if (lueLabtest.Text != "" && txtBrand.Text != "")
            {
                using (frmQuotation_LabTest ofrmFind = new frmQuotation_LabTest(txtBrand.EditValue.ToString(), lueLabtest.EditValue.ToString(), txtUsd_ex_fty.Text))
                {
                    ofrmFind.ShowDialog();                    
                }
            }
            else
            {
                MessageBox.Show("牌子編碼或LabTest產品測試大類不可為空！", "提示信息");
                if (lueLabtest.Text == "")
                {
                    lueLabtest.Focus();
                }
            }
        }

        private void txtPrice_rmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (editState == "NEW")
            {
                return;
            }
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }
            int row_index = dgvDetails.CurrentRow.Index;
            if (row_index < 0)
            {
                return;
            }
            if (!is_group_pdd)
            {
                return;
            }
            using (frmQuotation_Price_List ofrm = new frmQuotation_Price_List(dgvDetails.Rows[row_index].Cells["temp_code"].Value.ToString(), is_group_pdd))
            {
                ofrm.ShowDialog();
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (editState != "" && txtDate.Text!="")
            {
                txtValid_date.EditValue = DateTime.Parse(txtDate.Text).Date.AddDays(30).ToString("yyyy-MM-dd").Substring(0, 10); 
            }
        }

        private static bool checkChildFrmExist(string childFrmName)
        {
            bool isExist_flag = false;
            foreach (Form childFrm in frm_Main.pMainWin.MdiChildren)
            {
                if (childFrm.Name == childFrmName)
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Maximized;
                    }
                    childFrm.Activate();
                    isExist_flag = true;
                    break;
                }
            }
            return isExist_flag;
        }

        private void dgvDetails_Sorted(object sender, EventArgs e)
        {
            SaveSortInfo();            
        }

        private void txtPrice_unit_EditValueChanged(object sender, EventArgs e)
        {
            //計算出單價后又重新更改了單價單位,需重新計算單價一遍才行. 2022/11/23,
            if(editState != "")
            {
                if (string.IsNullOrEmpty(txtPrice_unit.Text))
                {
                    return;
                }                            
                CalcuPrice();
                CalcuPriceDisc(txtDisc.Text);
                txtRmb_remark.Text = clsQuotation.Get_Rmb_Remark(txtFormula.Text);
            }            
        }

        private void chkFlag_vnd_MouseUp(object sender, MouseEventArgs e)
        {
            if (editState != "")
            {         
                if (chkFlag_vnd.Checked)
                {
                    txtFlag_vnd_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
                    if (!clsQuotation.CheckPriceUnit(txtPrice_unit.Text))
                    {
                        return;
                    }
                    CalcuPrice(); 
                }
                else
                {
                    txtFlag_vnd_date.EditValue ="";
                    txtVnd_bp.Text = "0";
                    txtPrice_vnd_usd.Text = "0";
                    txtPrice_vnd.Text = "0";
                    txtPrice_vnd_grs.Text = "0";
                    txtPrice_vnd_pcs.Text = "0";
                }
                //pnlFlagVnd.Visible = chkFlag_vnd.Checked;
                pnlFlagVnd.Visible = true;
            }
        }

        private void txtVnd_bp_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (!clsQuotation.CheckPriceUnit(txtPrice_unit.Text))
                {
                    return;
                }
                CalcuPrice(); 
            }
        }

        private void lueMaterial_type_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueMaterial_type.EditValue.ToString() != "")
                {
                    txtMaterial.Text = lueMaterial_type.GetColumnValue("english_name").ToString();
                }
                else
                {
                    txtMaterial.Text = "";
                }                
            }
        }

        private void lueProduct_type_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                if (lueProduct_type.EditValue.ToString() != "")
                {
                    if(lueProduct_type.GetColumnValue("english_name").ToString()=="TACK" || lueProduct_type.GetColumnValue("english_name").ToString()==lueProduct_type.EditValue.ToString())
                    {
                        txtProduct_desc.Text = lueProduct_type.GetColumnValue("name").ToString();
                    }else
                    {
                        txtProduct_desc.Text = lueProduct_type.GetColumnValue("english_name").ToString();
                    }                    
                }
                else
                {
                    txtProduct_desc.Text = "";
                }
            }
        }

        private void txtMd_charge_Leave(object sender, EventArgs e)
        {        
            CalculateMdCharge(txtMd_charge, txtMd_charge_vn);
        }
        private void txtDie_mould_usd_Leave(object sender, EventArgs e)
        {
            CalculateMdCharge(txtDie_mould_usd, txtDie_mould_usd_vn);
        }

        private void CalculateMdCharge(DevExpress.XtraEditors.TextEdit obj1, DevExpress.XtraEditors.TextEdit obj2)
        {
            if (editState != "")
            {
                float md_charge = clsApp.Return_Float_Value(obj1.Text);
                obj2.Text = (md_charge * 1.20).ToString();
            }
        }

        private void btnPriceDisc_Click(object sender, EventArgs e)
        {
            if (editState == "" && txtTemp_code.Text != "")
            {
                if(dgvrow.Index<0)
                {
                    dgvrow = dgvDetails.CurrentRow;
                }
                using (frmQuotationDiscount ofrm = new frmQuotationDiscount(txtTemp_code.Text, dgvrow, dtPermiss))
                {
                    ofrm.ShowDialog();
                    dtPriceDisc = clsQuotation.GetPriceDiscount(txtTemp_code.Text);
                    dgvPriceDisc.DataSource = dtPriceDisc;
                }
            }
        }

        private void dgvDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ////clsQuotation.SetGridViewHighLight(dgvDetails, e);//自定義焦點行高亮背景色
            //DataGridView grd = sender as DataGridView;
            //if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            //{
            //    if (grd.Rows[e.RowIndex].Cells["pending"].Value.ToString() == "")
            //    {
            //        grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        //紫色字體
            //        grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkMagenta;
            //    }
            //    //刪除線
            //    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
            //    //備註字段不顯示刪除線
            //    //grd.Rows[e.RowIndex].Cells["remark"].Style.ForeColor = Color.Black;
            //    //grd.Rows[e.RowIndex].Cells["remark"].Style.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular); 
            //}
            //else
            //{
            //    //恢復正常顯示
            //    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            //    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular);
            //}
            //if (grd.Rows[e.RowIndex].Cells["special_price"].Value.ToString() == "True")
            //{
            //    //特別單價亮藍色背景
            //    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            //}
            //else
            //{
            //    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //}
            //if (grd.Rows[e.RowIndex].Cells["flag_new"].Value.ToString() != "")
            //{
            //    //新添加記錄背景色
            //    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            //}
            //else
            //{
            //    grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //}            
        }      

        private void frmQuotation_SizeChanged(object sender, EventArgs e)
        {           
            SetResize();
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            SetResize();
        }

        private void SetResize()
        {
            //此代碼默認屏幕字體大小為100%顯示沒問題，
            //部分電腦因字體大小調整為125%或更高，引起顯示上的偏差，浪費幾天時間調試，查不清原因（踩坑）
            int height = 415; //不顯示PDD Remark的最小高度
            try
            {               
                height = (!is_group_pdd) ? 415 : 460;
                splitContainer1.SplitterDistance = height;
                pnlHead.Height = height;
            }
            catch
            {
                height = this.Height - 40;
                splitContainer1.Height = height;
                if (height <= 30)
                {
                    return;
                }
                splitContainer1.SplitterDistance = Convert.ToInt32(height / 2);
                pnlHead.Height = Convert.ToInt32(height / 2);               
            }
            this.pnlHead.Width = this.Width;
            tabControl1.Width = splitContainer1.Width;
            tabControl1.Height = splitContainer1.Panel2.Height;
            pnlRemarkPDD_dg.Width = pnlHead.Width - pnlRemarkPDD.Width - 10;
            dgvSub.Width = pnlHead.Width - pnlRemarkPDD.Width - 267 - 10;
            dgvPriceDisc.Width = dgvSub.Width;
        }

    }
    
}
