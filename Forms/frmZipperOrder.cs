using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using cf01.CLS;
using cf01.MDL;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmZipperOrder : Form
    {
        private string userid = DBUtility._user_id;
        private bool append_mode = false;
        private bool edit_mode = false;
        private int edit_flag = 0;
        private DataTable dtDgvDetails = new DataTable();
        public static string query_id = "";
        public static string query_seq = "";
        public frmZipperOrder()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            edit_flag = 1;
            setBtnEnable();
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                cleanTextControlsHead();
                setEnableTextControlsHead();
                //用戶組別
                DataTable dtUserGroup = clsZipperOrder.getUserGroup();
                if (dtUserGroup.Rows.Count > 0)
                    lueMoGroup.EditValue = dtUserGroup.Rows[0]["mo_group"].ToString();
            }
            else
            {
                cleanTextControlsDetails();
                setEnableTextControlsDetails();
            }
        }
        private void setBtnEnable()
        {
            if (edit_flag == 1)//新增
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDel.Enabled = false;
                btnUndo.Enabled = true;
                append_mode = true;
                edit_mode = true;
            }
            if (edit_flag == 2)//修改
            {
                append_mode = false;
                edit_mode = true;
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDel.Enabled = false;
                btnUndo.Enabled = true;
            }
            if (edit_flag == 4)//取消
            {
                append_mode = false;
                edit_mode = false;
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDel.Enabled = true;
                btnUndo.Enabled = false;
            }
            if (edit_flag == 5)
            {
                append_mode = false;
                edit_mode = false;
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDel.Enabled = true;
                btnUndo.Enabled = false;
            }
        }
        private void cleanTextControlsHead()
        {
            txtId.Text = "";
            txtIt_customer.Text = "";
            txtOrder_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtCust_name.Text = "";
            txtCust_po.Text = "";
            lueMoGroup.EditValue = "";
        }

        private void setEnableTextControlsHead()
        {
            bool active_mode = !edit_mode;

            txtId.Properties.ReadOnly = !append_mode;
            lueMoGroup.Properties.ReadOnly = !append_mode;
            txtIt_customer.Properties.ReadOnly = active_mode;
            txtOrder_date.Properties.ReadOnly = active_mode;
            txtCust_po.Properties.ReadOnly = active_mode;

        }
        private void cleanTextControlsDetails()
        {
            txtSequence_id.Text = "";
            txtMo_id.Text = "";
            txtOrder_qty.Text = "";
            txtPrd_seq.Text = "";
            chkNoMagTest.Checked = true;
        }
        private void setEnableTextControlsDetails()
        {
            bool active_mode = !edit_mode;

            txtMo_id.Properties.ReadOnly = active_mode;
            lueMat_type.Properties.ReadOnly = active_mode;
            txtSpec_oth.Properties.ReadOnly = active_mode;
            lueSpec_id.Properties.ReadOnly = active_mode;
            txtGoods_id.Properties.ReadOnly = active_mode;
            txtOrder_qty.Properties.ReadOnly = active_mode;

            lueGoods_unit.Properties.ReadOnly = active_mode;
            txtCust_goods_style.Properties.ReadOnly = active_mode;
            txtColor_C.Properties.ReadOnly = active_mode;
            txtColor_Y.Properties.ReadOnly = active_mode;
            txtColor_oth.Properties.ReadOnly = active_mode;
            lueManu_craft_group.Properties.ReadOnly = active_mode;
            lueManu_craft_id.Properties.ReadOnly = active_mode;
            txtManu_craft_cdesc.Properties.ReadOnly = active_mode;
            txtManu_craft_oth.Properties.ReadOnly = active_mode;
            luePrd_process_id1.Properties.ReadOnly = active_mode;
            txtPrd_process_cdesc1.Properties.ReadOnly = active_mode;
            txtPrd_process_oth1.Properties.ReadOnly = active_mode;
            txtPrd_process_color1.Properties.ReadOnly = active_mode;
            luePrd_process_id.Properties.ReadOnly = active_mode;
            txtPrd_process_cdesc.Properties.ReadOnly = active_mode;
            txtPrd_process_oth.Properties.ReadOnly = active_mode;
            txtPrd_process_color.Properties.ReadOnly = active_mode;
            lueZipper_head.Properties.ReadOnly = active_mode;
            txtZipper_head_oth.Properties.ReadOnly = active_mode;
            lueNaked_select.Properties.ReadOnly = active_mode;
            txtNaked_cdesc.Properties.ReadOnly = active_mode;
            lueZipper_tooth.Properties.ReadOnly = active_mode;
            lueZipper_color.Properties.ReadOnly = active_mode;
            txtZipper_color_oth.Properties.ReadOnly = active_mode;
            txtPull_card_no.Properties.ReadOnly = active_mode;
            luePull_card_color_id.Properties.ReadOnly = active_mode;
            txtPull_card_color.Properties.ReadOnly = active_mode;
            lueTest_std.Properties.ReadOnly = active_mode;
            txtTest_std_cdesc.Properties.ReadOnly = active_mode;
            luePrd_use.Properties.ReadOnly = active_mode;
            txtPrd_use_oth.Properties.ReadOnly = active_mode;
            txtCloth_type.Properties.ReadOnly = active_mode;
            txtSize.Properties.ReadOnly = active_mode;
            lueSize_unit.Properties.ReadOnly = active_mode;
            txtSize_cm.Properties.ReadOnly = active_mode;
            txtSize_inc.Properties.ReadOnly = active_mode;
            lueSize_diff.Properties.ReadOnly = active_mode;
            txtSize_diff_oth.Properties.ReadOnly = active_mode;
            luePack_type.Properties.ReadOnly = active_mode;
            txtPack_type_oth.Properties.ReadOnly = active_mode;
            lueWash_type.Properties.ReadOnly = active_mode;
            txtWash_type_oth.Properties.ReadOnly = active_mode;
            txtRemark1.Properties.ReadOnly = active_mode;
            txtRemark2.Properties.ReadOnly = active_mode;
        }
        private void txtId_Leave(object sender, EventArgs e)
        {
            //if (append_mode == true)
            //{
            //    DataTable dtOc = clsZipperOrder.loadOcOrder(txtId.Text.Trim());
            //    if (dtOc.Rows.Count > 0)
            //    {
            //        DataRow row = dtOc.Rows[0];
            //        txtIt_customer.Text = row["it_customer"].ToString();
            //        txtOrder_date.Text = row["order_date"].ToString();
            //        txtCust_name.Text = row["cust_name"].ToString();
            //        txtCust_po.Text = row["contract_id"].ToString();
            //    }
            //    else
            //    {
            //        txtIt_customer.Text = "";
            //        txtOrder_date.Text = "";
            //        txtCust_name.Text = "";
            //        txtCust_po.Text = "";
            //    }
            //}
            if (edit_mode == false)
                loadId();
        }
        private void loadId()
        {
            DataTable dtSo = clsZipperOrder.loadId(txtId.Text.Trim());
            if (dtSo.Rows.Count > 0)
            {
                DataRow row = dtSo.Rows[0];
                txtOrder_date.Text = row["order_date"].ToString();
                txtIt_customer.Text = row["it_customer"].ToString();
                txtOrder_date.Text = row["order_date"].ToString();
                txtCust_name.Text = row["cust_name"].ToString();
                txtCust_po.Text = row["cust_po"].ToString();
                lueMoGroup.EditValue = row["mo_group"].ToString();
                txtCrusr.Text = row["crusr"].ToString();
                txtCrtim.Text = row["crtim"].ToString();
            }
            else
            {
                txtOrder_date.Text = "";
                txtIt_customer.Text = "";
                txtOrder_date.Text = "";
                txtCust_name.Text = "";
                txtCust_po.Text = "";
                lueMoGroup.EditValue = "";
                txtCrusr.Text = "";
                txtCrtim.Text = "";
            }
        }
        private void loadIdDetails()
        {
            dtDgvDetails = clsZipperOrder.loadIdDetails(txtId.Text.Trim());
            gcDetails.DataSource = dtDgvDetails;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit_mode == false)
            {
                MessageBox.Show("非編輯狀態!");
                return;
            }
            if (xtbControl1.SelectedTabPageIndex == 0)
                saveHead();
            else
                saveDetails();
        }
        private void saveHead()
        {
            if (!validHead())
                return;
            so_zipper_order_head objModel = new so_zipper_order_head();
            objModel.id = txtId.Text.Trim();
            objModel.order_date = Convert.ToDateTime(txtOrder_date.Text);
            objModel.it_customer = txtIt_customer.Text.Trim();
            objModel.cust_po = txtCust_po.Text.Trim();
            objModel.mo_group = (lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString() : "");
            objModel.crusr = userid;
            objModel.crtim = System.DateTime.Now;
            string result = clsZipperOrder.addSo_zipper_order_head(append_mode,objModel);
            if (result !="")
            {
                txtId.Text = result;//返回單據編號
                edit_flag = 5;
                setBtnEnable();
                setEnableTextControlsHead();
                loadId();
            }
        }
        private bool validHead()
        {
            if (edit_flag==2 && txtId.Text.Trim() == "")
            {
                MessageBox.Show("單據編號不能為空!");
                txtId.Focus();
                return false;
            }
            if (lueMoGroup.EditValue==null || lueMoGroup.EditValue.ToString().Trim()=="")
            {
                MessageBox.Show("組別不能為空!");
                lueMoGroup.Focus();
                return false;
            }
            if (clsValidRule.CheckDateFormat(this.txtOrder_date.Text) == false)
            {
                MessageBox.Show("訂單日期格式不正確!");
                this.txtOrder_date.Focus();
                return false;
            }
            if (clsZipperOrder.checkExistId(txtId.Text.Trim()) == true)
            {
                if (append_mode == true)
                {
                    MessageBox.Show("記錄已存在，不能新增!");
                    return false;
                }
            }
            else
            {
                if (append_mode == false && edit_mode == true)
                {
                    MessageBox.Show("記錄不存在，儲存無效!");
                    return false;
                }
            }
            return true;
        }
        private void saveDetails()
        {
            if (!validDetails())
                return;
            so_zipper_order_details objModel = new so_zipper_order_details();
            objModel.id = txtId.Text.Trim();
            objModel.sequence_id = txtSequence_id.Text.Trim();
            objModel.prd_seq = txtPrd_seq.Text.Trim();
            objModel.mo_group = lueMoGroup.EditValue.ToString().Trim();
            objModel.mo_id = txtMo_id.Text.Trim();
            objModel.goods_id = txtGoods_id.Text.Trim();
            objModel.order_qty = (txtOrder_qty.Text.Trim() != "" ? Convert.ToDecimal(txtOrder_qty.Text) : 0);
            objModel.sample_qty = (txtSample_qty.Text.Trim() != "" ? Convert.ToDecimal(txtSample_qty.Text) : 0);
            objModel.goods_unit = (lueGoods_unit.EditValue != null ? lueGoods_unit.EditValue.ToString() : "");
            objModel.mat_type = (lueMat_type.EditValue != null ? lueMat_type.EditValue.ToString() : "");
            objModel.spec_id = (lueSpec_id.EditValue != null ? lueSpec_id.EditValue.ToString() : "");
            objModel.spec_oth = txtSpec_oth.Text.Trim();
            objModel.cust_goods_style = txtCust_goods_style.Text.Trim();
            objModel.color_c = txtColor_C.Text.Trim();
            objModel.color_y = txtColor_Y.Text.Trim();
            objModel.color_oth = txtColor_oth.Text.Trim();
            objModel.manu_craft_group = (lueManu_craft_group.EditValue != null ? lueManu_craft_group.EditValue.ToString() : "");
            objModel.manu_craft_id = (lueManu_craft_id.EditValue != null ? lueManu_craft_id.EditValue.ToString() : "");
            objModel.manu_craft_cdesc = txtManu_craft_cdesc.Text.Trim();
            objModel.manu_craft_oth = txtManu_craft_oth.Text.Trim();
            
            objModel.prd_process_id = (luePrd_process_id.EditValue != null ? luePrd_process_id.EditValue.ToString() : "");
            objModel.prd_process_cdesc = txtPrd_process_cdesc.Text.Trim();
            objModel.prd_process_oth = txtPrd_process_oth.Text.Trim();
            objModel.prd_process_color = txtPrd_process_color.Text.Trim();
            objModel.prd_process_id1 = (luePrd_process_id1.EditValue != null ? luePrd_process_id1.EditValue.ToString() : "");
            objModel.prd_process_cdesc1 = txtPrd_process_cdesc1.Text.Trim();
            objModel.prd_process_oth1 = txtPrd_process_oth1.Text.Trim();
            objModel.prd_process_color1 = txtPrd_process_color1.Text.Trim();
            objModel.zipper_head = (lueZipper_head.EditValue != null ? lueZipper_head.EditValue.ToString() : "");
            objModel.zipper_head_oth = txtZipper_head_oth.Text.Trim();
            if (objModel.mat_type == "ME")
            {
                objModel.naked_select = (lueNaked_select.EditValue != null ? lueNaked_select.EditValue.ToString() : "");
                objModel.naked_cdesc = txtNaked_cdesc.Text.Trim();
                objModel.zipper_tooth = (lueZipper_tooth.EditValue != null ? lueZipper_tooth.EditValue.ToString() : "");
                objModel.zipper_color = (lueZipper_color.EditValue != null ? lueZipper_color.EditValue.ToString() : "");
                objModel.zipper_color_oth = txtZipper_color_oth.Text.Trim();
            }
            else
            {
                objModel.naked_select = "";
                objModel.naked_cdesc = "";
                objModel.zipper_tooth = "";
                objModel.zipper_color = "";
                objModel.zipper_color_oth = "";
            }
            objModel.pull_card_no = txtPull_card_no.Text.Trim();
            objModel.pull_card_color_id = (luePull_card_color_id.EditValue != null ? luePull_card_color_id.EditValue.ToString() : "");
            objModel.pull_card_color = txtPull_card_color.Text.Trim();
            objModel.test_std = (lueTest_std.EditValue != null ? lueTest_std.EditValue.ToString() : "");
            objModel.test_std_cdesc = txtTest_std_cdesc.Text.Trim();
            objModel.prd_use = (luePrd_use.EditValue != null ? luePrd_use.EditValue.ToString() : "");
            objModel.prd_use_oth = txtPrd_use_oth.Text.Trim();
            objModel.cloth_type = txtCloth_type.Text.Trim();
            objModel.size = txtSize.Text.Trim();
            objModel.size_unit = (lueSize_unit.EditValue != null ? lueSize_unit.EditValue.ToString() : "");
            objModel.size_cm = txtSize_cm.Text.Trim();
            objModel.size_inc = txtSize_inc.Text.Trim();
            objModel.size_diff = (lueSize_diff.EditValue != null ? lueSize_diff.EditValue.ToString() : "");
            objModel.size_diff_oth = txtSize_diff_oth.Text.Trim();
            objModel.pack_type = (luePack_type.EditValue != null ? luePack_type.EditValue.ToString() : "");
            objModel.pack_type_oth = txtPack_type_oth.Text.Trim();
            objModel.wash_type = (lueWash_type.EditValue != null ? lueWash_type.EditValue.ToString() : "");
            objModel.wash_type_oth = txtWash_type_oth.Text.Trim();
            objModel.remark1 = txtRemark1.Text.Trim();
            objModel.remark2 = txtRemark2.Text.Trim();
            objModel.no_mag_test = "1";
            if (chkNoMagTest.Checked == false)
                objModel.no_mag_test = "0";
            objModel.crusr = userid;
            objModel.crtim = System.DateTime.Now;
            string result = clsZipperOrder.addSo_zipper_order_details(append_mode, objModel);
            if (result != "")
            {
                int curr_row = 0;
                if (edit_flag==1)
                {
                    if (dgvDetails.RowCount > 0)
                        curr_row = dgvDetails.RowCount;//新增時，儲存後定位到最後一行
                }
                else
                {
                    curr_row = dgvDetails.FocusedRowHandle;//修改時，儲存後定位到當前行
                }
                loadIdDetails();
                fillDetailsControls(dtDgvDetails, curr_row);
                if (edit_flag == 1)//如果是新增狀態，則繼續新增
                    cleanTextControlsDetails();
            }
        }
        private bool validDetails()
        {
            if (clsZipperOrder.checkExistId(txtId.Text.Trim()) == false)
            {
                MessageBox.Show("單據編號不存在，不能儲存!");
                return false;
            }
            if (edit_flag==2 && txtSequence_id.Text.Trim() == "")
            {
                MessageBox.Show("序號不能為空!");
                return false;
            }
            if (txtMo_id.Text.Trim() == "")
            {
                MessageBox.Show("制單編號不能為空!");
                txtMo_id.Focus();
                return false;
            }
            if (clsZipperOrder.loadOcData(txtMo_id.Text.Trim()).Rows.Count==0)
            {
                MessageBox.Show("該制單編號在OC中不存在，不能儲存!");
                return false;
            }
            if (lueMat_type.EditValue == null || lueMat_type.EditValue.ToString()=="")
            {
                MessageBox.Show("質地不能為空!");
                lueMat_type.Focus();
                return false;
            }
            if (lueMat_type.EditValue == null || lueMat_type.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("質地不能為空!");
                lueMat_type.Focus();
                return false;
            }
            if ((lueSpec_id.EditValue != null ? lueSpec_id.EditValue.ToString() : "") =="" && txtSpec_oth.Text.Trim()=="")
            {
                MessageBox.Show("規格不能為空!");
                txtSpec_oth.Focus();
                return false;
            }
            if (txtColor_Y.Text.Trim() == "")
            {
                MessageBox.Show("Y卡顏色編號不能為空!");
                txtColor_Y.Focus();
                return false;
            }
            if ((lueManu_craft_group.EditValue != null ? lueManu_craft_group.EditValue.ToString() : "") == ""
                || (lueManu_craft_id.EditValue != null ? lueManu_craft_id.EditValue.ToString() : "") == ""
                || txtManu_craft_cdesc.Text.Trim() == "")
            {
                MessageBox.Show("製作工藝不能為空!");
                lueManu_craft_group.Focus();
                return false;
            }
            if ((lueZipper_head.EditValue != null ? lueZipper_head.EditValue.ToString() : "") == "" && txtZipper_head_oth.Text.Trim() == "")
            {
                MessageBox.Show("拉頭不能為空!");
                lueZipper_head.Focus();
                return false;
            }
            if (txtPull_card_no.Text.Trim() == "")
            {
                MessageBox.Show("拉片編號不能為空!");
                txtPull_card_no.Focus();
                return false;
            }
            if (txtPull_card_color.Text.Trim() == "")
            {
                MessageBox.Show("拉頭+拉片顏色不能為空!");
                txtPull_card_color.Focus();
                return false;
            }
            if ((lueMat_type.EditValue != null ? lueMat_type.EditValue.ToString():"") == "ME")
            {
                if (txtNaked_cdesc.Text.Trim() == "")
                {
                    MessageBox.Show("光身選擇不能為空!");
                    txtNaked_cdesc.Focus();
                    return false;
                }
                if (lueZipper_tooth.EditValue == null || lueZipper_tooth.EditValue.ToString().Trim() == "")
                {
                    MessageBox.Show("鏈牙款式不能為空!");
                    lueZipper_tooth.Focus();
                    return false;
                }
                if (txtZipper_color_oth.Text.Trim() == "")
                {
                    MessageBox.Show("鏈齒顏色不能為空!");
                    txtZipper_color_oth.Focus();
                    return false;
                }
            }
            if (lueTest_std.EditValue == null || lueTest_std.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("測試標準不能為空!");
                lueTest_std.Focus();
                return false;
            }

            if (txtSize.Text.Trim() == "")
            {
                MessageBox.Show("尺寸不能為空!");
                txtSize.Focus();
                return false;
            }
            if (lueSize_unit.EditValue == null || lueSize_unit.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("尺寸單位不能為空!");
                lueSize_unit.Focus();
                return false;
            }
            if (lueWash_type.EditValue == null || lueWash_type.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("洗水要求不能為空!");
                lueWash_type.Focus();
                return false;
            }
            return true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit_flag = 2;
            setBtnEnable();
            if (xtbControl1.SelectedTabPageIndex == 0)
                setEnableTextControlsHead();
            else
                setEnableTextControlsDetails();
        }

        private void txtIt_customer_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true && txtIt_customer.Text.Trim()!="")
            {
                DataTable dtCust = clsZipperOrder.getIt_Customer(txtIt_customer.Text.Trim());
                if (dtCust.Rows.Count > 0)
                {
                    txtCust_name.Text = dtCust.Rows[0]["name"].ToString();
                }
                else
                {
                    MessageBox.Show("客戶編號不存在!");
                    txtCust_name.Text = "";
                }
            }
        }

        private void frmZipperOrder_Load(object sender, EventArgs e)
        {
            initControls();
        }
        private void initControls()
        {
            setEnableTextControlsHead();
            setEnableTextControlsDetails();
            txtId.Properties.ReadOnly = false;

            //規格
            DataTable dtSpec = clsZipperOrder.getManu_craft("SP");
            lueSpec_id.Properties.DataSource = dtSpec;
            lueSpec_id.Properties.ValueMember = "id";
            lueSpec_id.Properties.DisplayMember = "cdesc";
            //質地
            DataTable dtMatType = clsZipperOrder.getMat_type();
            lueMat_type.Properties.DataSource = dtMatType;
            lueMat_type.Properties.ValueMember = "mat_code";
            lueMat_type.Properties.DisplayMember = "mat_cdesc";
            //制作工藝
            DataTable dtManu_craft = clsZipperOrder.getManu_craft("CR");
            lueManu_craft_group.Properties.DataSource = dtManu_craft;
            lueManu_craft_group.Properties.ValueMember = "id";
            lueManu_craft_group.Properties.DisplayMember = "cdesc";
            loadManu_craft_details("");
            ////制作工序
            //DataTable dtPrd_process = clsZipperOrder.getManu_craft("PR");
            //luePrd_process_group.Properties.DataSource = dtPrd_process;
            //luePrd_process_group.Properties.ValueMember = "id";
            //luePrd_process_group.Properties.DisplayMember = "cdesc";
            //loadPrd_process_details("");


            //制作工序-上止
            DataTable dtPrd_process_up = clsZipperOrder.getManu_craft_details("UP");
            luePrd_process_id.Properties.DataSource = dtPrd_process_up;
            luePrd_process_id.Properties.ValueMember = "id";
            luePrd_process_id.Properties.DisplayMember = "cdesc";

            //制作工序-下止
            DataTable dtPrd_process_dp = clsZipperOrder.getManu_craft_details("DP");
            luePrd_process_id1.Properties.DataSource = dtPrd_process_dp;
            luePrd_process_id1.Properties.ValueMember = "id";
            luePrd_process_id1.Properties.DisplayMember = "cdesc";


            //拉頭
            DataTable dtZipperHead = clsZipperOrder.getManu_craft("ZH");
            lueZipper_head.Properties.DataSource = dtZipperHead;
            lueZipper_head.Properties.ValueMember = "id";
            lueZipper_head.Properties.DisplayMember = "cdesc";
            //測試標準
            DataTable dtTestStd = clsZipperOrder.getManu_craft("TS");
            lueTest_std.Properties.DataSource = dtTestStd;
            lueTest_std.Properties.ValueMember = "id";
            lueTest_std.Properties.DisplayMember = "cdesc";
            //應用
            DataTable dtPrd_use = clsZipperOrder.getManu_craft("UU");
            luePrd_use.Properties.DataSource = dtPrd_use;
            luePrd_use.Properties.ValueMember = "id";
            luePrd_use.Properties.DisplayMember = "cdesc";
            //單位
            DataTable dtUnit = clsZipperOrder.getUnit();
            lueGoods_unit.Properties.DataSource = dtUnit;
            lueGoods_unit.Properties.ValueMember = "id";
            lueGoods_unit.Properties.DisplayMember = "name";
            //公差
            DataTable dtSize_diff = clsZipperOrder.getManu_craft("SZ");
            lueSize_diff.Properties.DataSource = dtSize_diff;
            lueSize_diff.Properties.ValueMember = "id";
            lueSize_diff.Properties.DisplayMember = "cdesc";
            //包裝要求
            DataTable dtPack = clsZipperOrder.getManu_craft("PK");
            luePack_type.Properties.DataSource = dtPack;
            luePack_type.Properties.ValueMember = "id";
            luePack_type.Properties.DisplayMember = "cdesc";
            //洗水要求
            DataTable dtWash = clsZipperOrder.getManu_craft("WH");
            lueWash_type.Properties.DataSource = dtWash;
            lueWash_type.Properties.ValueMember = "id";
            lueWash_type.Properties.DisplayMember = "cdesc";
            //光身選擇
            DataTable dtNaked = clsZipperOrder.getManu_craft("NK");
            lueNaked_select.Properties.DataSource = dtNaked;
            lueNaked_select.Properties.ValueMember = "id";
            lueNaked_select.Properties.DisplayMember = "cdesc";
            //鏈牙款式
            DataTable dtTooth = clsZipperOrder.getManu_craft("ZT");
            lueZipper_tooth.Properties.DataSource = dtTooth;
            lueZipper_tooth.Properties.ValueMember = "id";
            lueZipper_tooth.Properties.DisplayMember = "cdesc";
            //鏈齒顏色
            DataTable dtZipper_color = clsZipperOrder.getZipper_color("ZP");
            lueZipper_color.Properties.DataSource = dtZipper_color;
            lueZipper_color.Properties.ValueMember = "clr_code";
            lueZipper_color.Properties.DisplayMember = "clr_cdesc";

            luePull_card_color_id.Properties.DataSource = dtZipper_color;
            luePull_card_color_id.Properties.ValueMember = "clr_code";
            luePull_card_color_id.Properties.DisplayMember = "clr_cdesc";

            //組別
            DataTable dtGroup = clsZipperOrder.getGroup();
            lueMoGroup.Properties.DataSource = dtGroup;
            lueMoGroup.Properties.ValueMember = "mo_group";
            lueMoGroup.Properties.DisplayMember = "mo_group";

            //尺寸單位
            DataTable dtSize_unit = clsZipperOrder.getSize_unit();
            lueSize_unit.Properties.DataSource = dtSize_unit;
            lueSize_unit.Properties.ValueMember = "unit_id";
            lueSize_unit.Properties.DisplayMember = "unit_cdesc";
            
        }
        private void loadManu_craft_details(string craft_group)
        {
            //制作工藝
            DataTable dtManu_craft_details = clsZipperOrder.getManu_craft_details(craft_group);
            lueManu_craft_id.Properties.DataSource = dtManu_craft_details;
            lueManu_craft_id.Properties.ValueMember = "id";
            lueManu_craft_id.Properties.DisplayMember = "cdesc";
        }

        private void loadPrd_process_details(string craft_group)
        {
            //制作工序
            DataTable dtPrd_process_details = clsZipperOrder.getManu_craft_details(craft_group);
            luePrd_process_id.Properties.DataSource = dtPrd_process_details;
            luePrd_process_id.Properties.ValueMember = "id";
            luePrd_process_id.Properties.DisplayMember = "cdesc";
        }


        private void lueTestStd_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && lueTest_std.EditValue != null)
            {
                txtTest_std_cdesc.Text = lueTest_std.Text;
            }
        }

        private void luePrd_use_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && luePrd_use.EditValue != null)
            {
                txtPrd_use_oth.Text = luePrd_use.Text;
            }
        }

        private void xtbControl1_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                btnNew.Text = "新單";
                loadId();
            }
            else
            {
                btnNew.Text = "新記錄";
                loadIdDetails();
            }
        }

        private void dgvDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (edit_flag != 1)
            {
                fillDetailsControls(dtDgvDetails, dgvDetails.FocusedRowHandle);
                loadMoInfo();//提取訂單資料
            }
        }
        private void fillDetailsControls(DataTable dt,int i)
        {
            DataRow row = dt.Rows[i];
            if (edit_flag != 1)//如果是新增狀態，就不填充
            {
                txtSequence_id.Text = row["sequence_id"].ToString();
                txtMo_id.Text = row["mo_id"].ToString();
                txtOrder_qty.Text = row["order_qty"].ToString();
                txtSample_qty.Text = row["sample_qty"].ToString();
                lueGoods_unit.EditValue = row["goods_unit"].ToString();
                txtPrd_seq.Text = row["prd_seq"].ToString().Trim();
            }
            txtGoods_id.Text = row["goods_id"].ToString();
            lueMat_type.EditValue = row["mat_type"].ToString();
            setPalMeVisible();
            lueSpec_id.EditValue = row["spec_id"].ToString();
            txtSpec_oth.Text = row["spec_oth"].ToString();
            txtCust_goods_style.Text = row["cust_goods_style"].ToString();
            txtColor_C.Text = row["color_C"].ToString();
            txtColor_Y.Text = row["color_Y"].ToString();
            txtColor_oth.Text = row["color_oth"].ToString();
            lueManu_craft_group.EditValue = row["manu_craft_group"].ToString();
            loadManu_craft_id();
            lueManu_craft_id.EditValue = row["manu_craft_id"].ToString();
            txtManu_craft_cdesc.Text = row["manu_craft_cdesc"].ToString();
            txtManu_craft_oth.Text = row["manu_craft_oth"].ToString();

            luePrd_process_id.EditValue = row["prd_process_id"].ToString();
            txtPrd_process_cdesc.Text = row["prd_process_cdesc"].ToString();
            txtPrd_process_oth.Text = row["prd_process_oth"].ToString();
            txtPrd_process_color.Text = row["prd_process_color"].ToString();
            luePrd_process_id1.EditValue = row["prd_process_id1"].ToString();
            txtPrd_process_cdesc1.Text = row["prd_process_cdesc1"].ToString();
            txtPrd_process_oth1.Text = row["prd_process_oth1"].ToString();
            txtPrd_process_color1.Text = row["prd_process_color1"].ToString();
            lueZipper_head.EditValue = row["zipper_head"].ToString();
            txtZipper_head_oth.Text = row["zipper_head_oth"].ToString();
            lueNaked_select.EditValue = row["naked_select"].ToString();
            txtNaked_cdesc.Text = row["naked_cdesc"].ToString();
            lueZipper_tooth.EditValue = row["zipper_tooth"].ToString();
            lueZipper_color.EditValue = row["zipper_color"].ToString();
            txtZipper_color_oth.Text = row["zipper_color_oth"].ToString();
            txtPull_card_no.Text = row["pull_card_no"].ToString();
            luePull_card_color_id.EditValue = row["pull_card_color_id"].ToString();
            txtPull_card_color.Text = row["pull_card_color"].ToString();
            lueTest_std.EditValue = row["test_std"].ToString();
            txtTest_std_cdesc.Text = row["test_std_cdesc"].ToString();
            luePrd_use.EditValue = row["prd_use"].ToString();
            txtPrd_use_oth.Text = row["prd_use_oth"].ToString();
            txtCloth_type.Text = row["cloth_type"].ToString();
            txtSize.Text = row["size"].ToString();
            lueSize_unit.EditValue = row["size_unit"].ToString();
            txtSize_cm.Text = row["size_cm"].ToString();
            txtSize_inc.Text = row["size_inc"].ToString();
            lueSize_diff.EditValue = row["size_diff"].ToString();
            txtSize_diff_oth.Text = row["size_diff_oth"].ToString();
            luePack_type.EditValue = row["pack_type"].ToString();
            txtPack_type_oth.Text = row["pack_type_oth"].ToString();
            lueWash_type.EditValue = row["wash_type"].ToString();
            txtWash_type_oth.Text = row["wash_type_oth"].ToString();
            txtRemark1.Text = row["remark1"].ToString();
            txtRemark2.Text = row["remark2"].ToString();
            if (row["no_mag_test"].ToString() == "1")
                chkNoMagTest.Checked = true;
            else
                chkNoMagTest.Checked = false;
        }

        private void lueManu_craft_group_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true)
                loadManu_craft_id();
        }
        private void loadManu_craft_id()
        {
            if (lueManu_craft_group.EditValue != null)
            {
                loadManu_craft_details(lueManu_craft_group.EditValue.ToString());
                txtManu_craft_cdesc.Text = "";
            }
        }
        private void lueManu_craft_id_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && lueManu_craft_id.EditValue != null)
            {
                txtManu_craft_cdesc.Text += lueManu_craft_id.Text.Trim() + ";";
                if (lueManu_craft_id.EditValue.ToString().Trim() == "OTH")
                {
                    txtManu_craft_cdesc.Text = "";
                    txtManu_craft_cdesc.Focus();
                }
            }
        }


        private void luePrd_process_id_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && luePrd_process_id.EditValue != null)
            {
                txtPrd_process_cdesc.Text += luePrd_process_id.Text.Trim() + ";";
                if (luePrd_process_id.EditValue.ToString().Trim() == "OTH")
                {
                    txtPrd_process_cdesc.Text = "";
                    txtPrd_process_cdesc.Focus();
                }
            }
        }
        private void setPalMeVisible()
        {
            //if (lueMat_type.EditValue != null && lueMat_type.EditValue.ToString() == "ME")
            //    palMe.Visible = true;
            //else
            //    palMe.Visible = false;
        }

        private void lueMat_type_EditValueChanged(object sender, EventArgs e)
        {
            setPalMeVisible();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (edit_mode == true)
            {
                DialogResult dr = MessageBox.Show("放棄編輯？", "对话框标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                    btnUndo_Click(sender, e);
                else
                    return;
            }
            frmZipperOrder.query_id = txtId.Text;
            frmZipperOrder_Find frmZipperOrder_Find = new frmZipperOrder_Find();
            frmZipperOrder_Find.ShowDialog();
            frmZipperOrder_Find.Dispose();
            if (frmZipperOrder.query_id != "")
            {
                if (xtbControl1.SelectedTabPageIndex == 1)
                {
                    if (edit_mode == true)//如果是編輯狀態，將查找到的結果複製過來
                    {
                        DataTable dt = clsZipperOrder.loadIdSeqDetails(frmZipperOrder.query_id, frmZipperOrder.query_seq);
                        fillDetailsControls(dt, 0);
                    }
                    else
                    {
                        txtId.Text = frmZipperOrder.query_id;
                        loadIdDetails();

                    }
                }
                else
                {
                    if (edit_mode == false)
                    {
                        txtId.Text = frmZipperOrder.query_id;
                        loadId();
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            edit_flag = 4;
            setBtnEnable();
            if (xtbControl1.SelectedTabPageIndex == 1)
            {
                setEnableTextControlsDetails();
                loadIdDetails();
            }
            else
            {
                setEnableTextControlsHead();
                loadId();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 1)
            {
                if (clsZipperOrder.checkPrd_seqInOc(txtPrd_seq.Text.Trim()) == true)
                {
                    MessageBox.Show("此記錄已生成OC資料,不能刪除!");
                    return;
                }

                clsZipperOrder.deleteIdDetails(txtId.Text.Trim(), txtSequence_id.Text.Trim());
                loadIdDetails();
            }
            else
            {
                MessageBox.Show("主表記錄不能刪除!");
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printReport(2);
        }
        private void printReport(int print_type)
        {
            string id = txtId.Text.Trim();
            if (id == "")
                id = "ZZZZZZZZZZZZ";
            int find_mo_flag = 1;////從訂單中查找備註等資料
            DataTable dtReport = clsZipperOrder.findIdDetails(find_mo_flag, id, "", "", "", "", "", "", "");
            xrZipperOrderId oRepot = new xrZipperOrderId() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            if (print_type == 2)
                oRepot.ShowPreview();
            else
                oRepot.PrintDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            expToExcel();
        }
        private void expToExcel()
        {
            string id = txtId.Text.Trim();
            if (id == "")
                id = "ZZZZZZZZZZZZ";
            int find_mo_flag = 1;////從訂單中查找備註等資料
            DataTable dtExcel = clsZipperOrder.findIdDetails(find_mo_flag, id, "", "", "", "", "", "", "");

            //clsZipperOrder.expToExcel(dtExcel);
            clsZipperOrder.saveToExcel(dtExcel);


        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            frmZipperOrder.query_id = txtId.Text.Trim();
            frmZipperOrderToPr frmZipperOrderToPr = new frmZipperOrderToPr();
            frmZipperOrderToPr.ShowDialog();
            frmZipperOrderToPr.Dispose();
        }

        private void lueNaked_select_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && lueNaked_select.EditValue != null)
            {
                txtNaked_cdesc.Text += lueNaked_select.Text.Trim() + ";";

            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true && txtMo_id.Text.Trim() != "")
            {
                loadMoInfo();
            }
        }
        //提取制單資料
        private void loadMoInfo()
        {
            DataTable dtOc = clsZipperOrder.loadOcData(txtMo_id.Text.Trim());
            if (dtOc.Rows.Count > 0)
            {
                txtOrder_qty.Text = dtOc.Rows[0]["order_qty"].ToString();
                lueGoods_unit.EditValue = dtOc.Rows[0]["goods_unit"].ToString();
                txtGoods_id.Text = dtOc.Rows[0]["goods_id"].ToString();
                txtPrd_remark.Text = dtOc.Rows[0]["production_remark"].ToString();
            }
            else
            {
                txtOrder_qty.Text = "";
                lueGoods_unit.EditValue = "";
                txtGoods_id.Text = "";
                txtPrd_remark.Text = "";
            }
        }
        private void btnUpdateMo_Click(object sender, EventArgs e)
        {
            if (clsZipperOrder.checkExistId(txtId.Text.Trim()) == false)
            {
                MessageBox.Show("單據編號不存在,不能更新!");
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //**********************
            int result = updateMoFromOc(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (result > 0)
                MessageBox.Show("更新制單編號成功!");
            else
                MessageBox.Show("更新制單編號失敗!");
            loadIdDetails();
        }
        private int updateMoFromOc()
        {
            int result = 0;
            string strSql = "";
            string dat1 = "", dat2 = "";
            strSql = "usp_UpdateZipperFromOc";
            SqlParameter[] parameters = {new SqlParameter("@id1", txtId.Text.Trim())
                        ,new SqlParameter("@id2", txtId.Text.Trim())
                        ,new SqlParameter("@dat1", dat1)
                        ,new SqlParameter("@dat2", dat2)
                        };
            result = clsPublicOfCF01.ExecuteNonQuery(strSql, parameters, true);
            return result;
        }

        private void luePull_card_color_id_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && luePull_card_color_id.EditValue != null)
            {
                txtPull_card_color.Text += luePull_card_color_id.Text.Trim() + ";";

            }
        }

        private void lueZipper_color_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && lueZipper_color.EditValue != null)
            {
                txtZipper_color_oth.Text += lueZipper_color.Text.Trim() + ";";

            }
        }

        private void luePrd_process_id1_EditValueChanged(object sender, EventArgs e)
        {
            if (edit_mode == true && luePrd_process_id1.EditValue != null)
            {
                txtPrd_process_cdesc1.Text += luePrd_process_id1.Text.Trim() + ";";
                if (luePrd_process_id1.EditValue.ToString().Trim() == "OTH")
                {
                    txtPrd_process_cdesc1.Text = "";
                    txtPrd_process_cdesc1.Focus();
                }
            }
        }

        private void btnShowTest_Click(object sender, EventArgs e)
        {
            frmZipperOrder.query_id = txtMo_id.Text;
            frmZipperOrder_Test frmZipperOrder_Test = new frmZipperOrder_Test();
            frmZipperOrder_Test.ShowDialog();
            frmZipperOrder_Test.Dispose();
        }


    }
}
