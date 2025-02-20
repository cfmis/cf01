//*******************************
//**C組阿華,L組李華都在用
//******************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Threading;

namespace cf01.Forms
{
    public partial class frmDgdDeliverGoods : Form
    {
        private bool change_flag = false;
        private bool append_mode = false;
        private readonly string within_code = DBUtility.within_code;
        private DataTable dtDetails = new DataTable();
        private DataTable dtMoStore = new DataTable();
        private DataTable dtExcel = new DataTable();
        clsPublicOfGEO clsGEO = new clsPublicOfGEO();
        public static string query_id;
        public static string query_seq;
        private int id_ver = 0;
        private readonly string user_id = DBUtility._user_id; 
      
        public frmDgdDeliverGoods()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtShip_date_EditValueChanged(object sender, EventArgs e)
        {
            change_flag = true;
        }

        private void luAddress_id_EditValueChanged(object sender, EventArgs e)
        {
            change_flag = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (change_flag == false)
            {
                MessageBox.Show("沒有要修改的記錄!", "提示信息");
                return;
            }

            if (xtbControl1.SelectedTabPageIndex == 0)
                saveHead();
            else
            {
                if (txtSequence_id.Text.Trim() != "")
                {
                    if (clsDgdDeliverGoods.checkExistIdDetailsReturnTable(txtId.Text.Trim(), id_ver, txtSequence_id.Text.Trim()) == false)
                    {
                        MessageBox.Show("這筆記錄已生成東莞D送貨單或發票，不能再更改!","提示信息");
                        return;
                    }
                }
                saveDetails();
            }
        }
        private void saveHead()
        {            
            if (!validHead())
                return;
            soinvoice_head objModel = new soinvoice_head() { 
                id = txtId.Text.Trim(), 
                ver = id_ver, 
                separate = txtSeparate.Text, 
                ship_date = Convert.ToDateTime(txtShip_date.Text), 
                it_customer = txtIt_Customer.Text.Trim(), 
                seller_id = (lueSeller_id.EditValue != null ? lueSeller_id.EditValue.ToString() : ""), 
                m_id = (lueM_id.EditValue != null ? lueM_id.EditValue.ToString() : ""),
                bill_type_no = (lueBill_type_no.EditValue != null ? lueBill_type_no.EditValue.ToString() : ""), 
                phone = txtPhone.Text.Trim(), 
                fax = txtFax.Text.Trim(), 
                email = txtEmail.Text.Trim(), 
                linkman = txtLinkman.Text.Trim(), 
                l_phone = txtL_phone.Text.Trim(),
                exchange_rate = (txtExchange_rate.Text != "" ? Convert.ToSingle(txtExchange_rate.Text) : 0), 
                po_no = txtPo_no.Text.Trim(), 
                issues_wh = txtIssues_wh.Text.Trim(), 
                merchandiser = (lueMerchandiser.EditValue != null ? lueMerchandiser.EditValue.ToString() : ""), 
                merchandiser_phone = txtMerchandiser_phone.Text.Trim(), 
                shipping_methods = txtShipping_methods.Text.Trim(), 
                sales_group = txtSales_Group.Text.Trim().ToUpper() 
            };
            if (objModel.sales_group == "L")
                objModel.address_id = lueAddress_id.EditValue.ToString() != "" ? lueAddress_id.EditValue.ToString() : "Y01";//L組如不輸入，默認是越南一廠
            else
                objModel.address_id = "";
            if (string.IsNullOrEmpty(objModel.sales_group))
            {
                MessageBox.Show("組別不可以為空，請首先給用戶分配一所屬組別編號！", "提示信息");
                return;
            }
            string result = clsDgdDeliverGoods.AddSoInvoiceHead(objModel);
            if (result != "")
            {
                txtId.Text = result;
                append_mode = false;
            }
            loadSoInvoiceHead();
        }
        private void saveDetails()
        {
            if (!validDetails())
                return;
            string old_sequence_id = txtSequence_id.Text.Trim();
            int old_record = dgvDetails.FocusedRowHandle;
            soinvoice_details objModel = new soinvoice_details();
            objModel.id = txtId.Text.Trim();
            objModel.ver = id_ver;
            objModel.sequence_id = txtSequence_id.Text.Trim();
            objModel.mo_id = txtMo_id.Text.Trim();
            objModel.goods_id = txtGoods_id.Text.Trim();
            objModel.goods_name = txtGoods_name.Text.Trim();
            objModel.u_invoice_qty = Convert.ToDecimal(txtU_invoice_qty.Text);
            objModel.u_invoice_qty_pcs = Convert.ToDecimal(txtQty_pcs.Text);
            objModel.goods_unit = lueGoods_unit.EditValue.ToString();
            objModel.sec_qty = Convert.ToDecimal(txtSec_qty.Text);
            objModel.sec_unit = "KG";
            objModel.location_id = lueLocation_id.EditValue.ToString();
            objModel.carton_code = objModel.location_id;
            if (chkShipment_suit.Checked == false)
                objModel.shipment_suit = "0";
            else
                objModel.shipment_suit = "1";
            objModel.remark = txtRemark.Text.Trim();
            objModel.package_num = (txtPackage_num.Text != "" ? Convert.ToInt32(txtPackage_num.Text) : 0);
            objModel.box_no = txtBox_no.Text.Trim();
            objModel.order_id = txtOrder_id.Text.Trim();
            objModel.so_ver = Convert.ToInt32(txtOc_Ver.Text);
            objModel.so_sequence_id = txtOrder_Seq.Text.Trim();
            objModel.table_head = txtTable_head.Text.Trim();
            objModel.contract_cid = txtContract_cid.Text.Trim();
            objModel.customer_goods = txtCustomer_goods.Text.Trim();
            objModel.customer_color_id = txtCustomer_color_id.Text.Trim();
            objModel.spec = txtSpec.Text.Trim();
            objModel.is_print = "Y";
            objModel.state = "0";
            if (chkIs_print.Checked == false)
                objModel.is_print = "N";
            string result = clsDgdDeliverGoods.AddSoInvoiceDetails(objModel);
            if (result != "")
            {
                loadSoInvoiceDetails();
                if (old_sequence_id == "")
                {
                    cleanTextBoxDetails();
                    txtMo_id.Focus();
                }
                else
                    fillDetailsControls(old_record);

               // Record_Location();//當前記錄定位到最后一行
            }
        }
        private bool validHead()
        {
            //bool result = true;
            //if (txtId.Text.Trim() == "")
            //{
            //    MessageBox.Show("單據編號不能為空!");
            //    return false;
            //}
            if (clsValidRule.CheckDateFormat(txtShip_date.Text) == false)
            {
                MessageBox.Show("送貨單日期格式不正確!");
                txtShip_date.Focus();
                return false;
            }
            if (txtSales_Group.Text.Trim() == "")
            {
                MessageBox.Show("組別不能為空!");
                txtSales_Group.Focus();
                return false;
            }
            if (txtIt_Customer.Text == "")
            {
                MessageBox.Show("客戶資料不能為空!");
                txtIt_Customer.Focus();
                return false;
            }
            return true;
        }
        private bool validDetails()
        {
            if (!clsDgdDeliverGoods.checkExistId(txtId.Text.Trim(), 0))
            {
                MessageBox.Show("單據編號不存在!");
                return false;
            }
            if (txtMo_id.Text.Trim() == "")
            {
                MessageBox.Show("制單編號不能為空!");
                txtMo_id.Focus();
                return false;
            }
            if (lueGoods_id.EditValue ==null || lueGoods_id.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("產品編號不能為空!");
                lueGoods_id.Focus();
                return false;
            }
            if (!clsValidRule.IsNumeric(txtU_invoice_qty.Text) || txtU_invoice_qty.Text == "0" || txtU_invoice_qty.Text == "")
            {
                MessageBox.Show("發貨數量格式不正確!");
                txtU_invoice_qty.Focus();
                return false;
            }
            if (!clsValidRule.IsNumeric(txtSec_qty.Text) || txtSec_qty.Text == "")
            {
                MessageBox.Show("發貨重量格式不正確!");
                txtSec_qty.Focus();
                return false;
            }
            if (txtSales_Group.Text.Trim() == "C" && txtSec_qty.Text == "0")
            {
                MessageBox.Show("發貨重量不能為0!");
                txtSec_qty.Focus();
                return false;
            }
            if (txtSequence_id.Text.Trim() != "")
            {
                if (clsDgdDeliverGoods.checkExistIdDetailsReturnTable(txtId.Text.Trim(), id_ver, txtSequence_id.Text.Trim()) == false)
                {
                    MessageBox.Show("這筆記錄已生成送貨單，不能再修改!");
                    return false;
                }
            }
            DataTable dtIdSeq = new DataTable();
            if (txtSales_Group.Text.Trim() == "C")
            {
                DataTable dtMoStore = clsDgdDeliverGoods.getMoStoreByItem(lueLocation_id.EditValue.ToString(), txtMo_id.Text, txtGoods_id.Text);
                if (dtMoStore.Rows.Count == 0)
                {
                    MessageBox.Show("庫存記錄不存在!");
                    return false;
                }
                else
                {
                    //-------------------------------------------------------
                    //代碼有問題，因分批走貨有問題增加以下取訂單數的判斷
                    //如果數量不超訂單數時不進行判斷
                    string sql = string.Format("select dbo.fn_z_Get_pcs_qty(order_qty,goods_unit) AS order_qty From dbo.so_order_details with(nolock) Where within_code='0000' and mo_id='{0}'", txtMo_id.Text);                    
                    DataTable dtOrder = clsGEO.GetDataTable(sql);
                    Int32 order_qty= Int32.Parse(dtOrder.Rows[0]["order_qty"].ToString());
                    //-------------------------------------------------------
                    float old_qty = 0;//, old_weg = 0;
                    dtIdSeq = clsDgdDeliverGoods.checkExistIdDetailsByMo(txtId.Text.Trim(), txtSequence_id.Text.Trim(), txtMo_id.Text, txtGoods_id.Text);
                    old_qty = (dtIdSeq.Rows[0]["u_invoice_qty_pcs"].ToString() != "" ? Convert.ToSingle(dtIdSeq.Rows[0]["u_invoice_qty_pcs"]) : 0);
                    //old_weg = (dtIdSeq.Rows[0]["sec_qty"].ToString() != "" ? Convert.ToSingle(dtIdSeq.Rows[0]["sec_qty"]) : 0);
                    if (old_qty + Convert.ToSingle(txtQty_pcs.Text) > Convert.ToSingle(dtMoStore.Rows[0]["qty"]))
                    {
                        //----2018-11-09 add by allen
                        //當總數量不大訂單數時忽略后的判斷
                        if (old_qty + Convert.ToSingle(txtQty_pcs.Text) <= order_qty)                  
                            return true;                       
                        else
                        {
                            DialogResult result;
                            result=MessageBox.Show("發貨數量已超訂單數量!是否繼續？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)                            
                                return true;                            
                            else                     
                                return false;                        
                        }                        
                        //以下注銷的為舊代碼 注銷于 2018-11-09 Allen Leung
                        //MessageBox.Show("發貨數量已大於倉存數量!");
                        //return false;
                    } 
                    //----new code add by allen_leung in 2018-11-09
                    //只需判斷當前重量是否大于庫存重量即可，因前面已有數量是否大于訂單數的判斷
                    if (Convert.ToSingle(txtSec_qty.Text) > Convert.ToSingle(dtMoStore.Rows[0]["sec_qty"]))
                    {
                        MessageBox.Show("當前發貨重量已大於倉存重量!", "提示信息");
                        return false;
                    } 
                    //----new code
                    //以下代碼為舊代碼,注銷于2018-11-09 by Allen Leung
                    //else
                    //{                        
                        //if (old_weg + Convert.ToSingle(txtSec_qty.Text) > Convert.ToSingle(dtMoStore.Rows[0]["sec_qty"]))
                        //{
                        //    MessageBox.Show("發貨重量已大於倉存重量!");
                        //    return false;
                        //}
                    //}
                    return true;
                }
            }
            else
            {
                if (txtSequence_id.Text.Trim() == "")
                {
                    dtIdSeq = clsDgdDeliverGoods.checkExistIdDetailsByMoSaveDelete("", txtMo_id.Text.Trim());
                    if (dtIdSeq.Rows.Count > 0)
                    {
                        string qstring = MessageBox.Show(string.Format("該制單已存在發貨單號:{0}序號:{1}", dtIdSeq.Rows[0]["id"], dtIdSeq.Rows[0]["sequence_id"]), "提示信息", MessageBoxButtons.YesNo).ToString();
                        if (qstring == "No")
                        {
                            return false;
                        }                        
                    }
                }
            }
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            append_mode = true;
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                txtId.Text = "";
                cleanTextBoxHead();
                txtShip_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
                if (txtSales_Group.Text == "L")
                {
                    txtIt_Customer.Text = "DO-S0487";
                    txtSeparate.Text = "";
                    txtIssues_wh.Text = "";
                }
                else
                {
                    txtIt_Customer.Text = "DL-C0117";
                    txtSeparate.Text = "1";
                    txtIssues_wh.Text = "D";
                }
                getCust(txtIt_Customer.Text);
            }
            else
            {
                if (change_flag == true)
                {
                    MessageBox.Show("存在修改的記錄，請先保存!");
                    return;
                }
                txtMo_id.Focus();
            }
            //addDetailsValue();
            cleanTextBoxDetails();
        }
        

        private void txtIt_Customer_Leave(object sender, EventArgs e)
        {
            getCust(txtIt_Customer.Text);
        }
        private void getCust(string cust)
        {
            DataTable dtCust = clsDgdDeliverGoods.getIt_Customer(cust);
            if (dtCust.Rows.Count > 0)
            {
                DataRow dtRow = dtCust.Rows[0];
                lueSeller_id.EditValue = dtRow["seller_id_1"].ToString();
                lueM_id.EditValue = dtRow["money_id"].ToString();
                lueBill_type_no.EditValue = "L";
                txtPhone.Text = dtRow["phone"].ToString();
                txtFax.Text = dtRow["fax"].ToString();
                txtEmail.Text = dtRow["email"].ToString();
                txtL_phone.Text = dtRow["phone"].ToString();
                txtExchange_rate.Text = "";
                setCurrRate(lueM_id.EditValue.ToString());
                if (txtSales_Group.Text == "L")
                    txtLinkman.Text = "";
                else
                    txtLinkman.Text = "朱生";                
            }
            else
            {
                lueSeller_id.EditValue = "";
                lueM_id.EditValue = "";
                lueBill_type_no.EditValue = "";
                txtPhone.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                txtLinkman.Text = "";
                txtL_phone.Text = "";
                txtExchange_rate.Text = "0";                
            }
        }

        private void frmDgdDeliverGoods_Load(object sender, EventArgs e)
        {
            initControls();
        }
        private void initControls()
        {
            //用戶組別
            txtSales_Group.Text = clsDgdDeliverGoods.getUserGroup(user_id);
            DataTable dtSaleUser = clsDgdDeliverGoods.getSalesUser();
            lueMerchandiser.Properties.DataSource = dtSaleUser;
            lueMerchandiser.Properties.ValueMember = "id";
            lueMerchandiser.Properties.DisplayMember = "name";
            lueSeller_id.Properties.DataSource = dtSaleUser;
            lueSeller_id.Properties.ValueMember = "id";
            lueSeller_id.Properties.DisplayMember = "name";
            DataTable dtCurr = clsDgdDeliverGoods.getCurr();
            lueM_id.Properties.DataSource = dtCurr;
            lueM_id.Properties.ValueMember = "id";
            lueM_id.Properties.DisplayMember = "name";
            DataTable dtBill_type_no = clsDgdDeliverGoods.getBill_type_no();
            lueBill_type_no.Properties.DataSource = dtBill_type_no;
            lueBill_type_no.Properties.ValueMember = "id";
            lueBill_type_no.Properties.DisplayMember = "name";
            //單位
            DataTable dtUnit = clsDgdDeliverGoods.getUnit();
            lueGoods_unit.Properties.DataSource = dtUnit;
            lueGoods_unit.Properties.ValueMember = "id";
            lueGoods_unit.Properties.DisplayMember = "name";
            //倉庫號
            string sales_group = txtSales_Group.Text.Trim().ToUpper();
            DataTable dtLoc = clsDgdDeliverGoods.getLocNo(sales_group);
            lueLocation_id.Properties.DataSource = dtLoc;
            lueLocation_id.Properties.ValueMember = "location_id";
            lueLocation_id.Properties.DisplayMember = "name";
            if (txtSales_Group.Text == "L")
                lblId.Text = "單據編號:";
            DataTable dtAddress = clsDgdDeliverGoods.Get_Address();
            lueAddress_id.Properties.DataSource = dtAddress;
            lueAddress_id.Properties.ValueMember = "id";
            lueAddress_id.Properties.DisplayMember = "cdesc";

            
        }
        private void cleanTextBoxHead()
        {
            lueMerchandiser.EditValue = "";
            txtMerchandiser_phone.Text = "";
            lueSeller_id.EditValue = "";
            lueM_id.EditValue = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtLinkman.Text = "";
            txtL_phone.Text = "";
            txtSeparate.Text = "";
            txtIssues_wh.Text = "";
            txtExchange_rate.Text = "";
            txtShip_date.Text = "";
            txtIt_Customer.Text = "";
            lueBill_type_no.EditValue = "";
            txtPo_no.Text = "";
            txtShipping_methods.Text = "";
        }
        private void setCurrRate(string curr)
        {
            DataTable dtCurrRate = clsDgdDeliverGoods.getCurrRate(curr);
            if (dtCurrRate.Rows.Count > 0)
                txtExchange_rate.Text = dtCurrRate.Rows[0]["exchange_rate"].ToString();
            else
                txtExchange_rate.Text = "0";
        }

        private void lueM_id_Leave(object sender, EventArgs e)
        {
            setCurrRate((lueM_id.EditValue != null ? lueM_id.EditValue.ToString() : ""));
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (append_mode == false)
            {
                cleanTextBoxHead();
                loadSoInvoiceHead();
                //loadSoInvoiceDetails();
            }
        }
        private void loadSoInvoiceHead()
        {
            DataTable dtSo = clsDgdDeliverGoods.loadSoInvoiceHead(txtId.Text.Trim());
            if (dtSo.Rows.Count > 0)
            {
                DataRow row = dtSo.Rows[0];
                lueMerchandiser.EditValue = row["merchandiser"].ToString();
                txtMerchandiser_phone.Text = row["merchandiser_phone"].ToString();
                lueSeller_id.EditValue = row["seller_id"].ToString();
                lueM_id.EditValue = row["m_id"].ToString();
                txtPhone.Text = row["phone"].ToString();
                txtFax.Text = row["fax"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtLinkman.Text = row["linkman"].ToString();
                txtL_phone.Text = row["l_phone"].ToString();
                txtSeparate.Text = row["separate"].ToString();
                txtIssues_wh.Text = row["issues_wh"].ToString();
                txtExchange_rate.Text = row["exchange_rate"].ToString();
                txtShip_date.Text = Convert.ToDateTime(row["ship_date"].ToString()).ToString("yyyy/MM/dd");
                txtIt_Customer.Text = row["it_Customer"].ToString();
                lueBill_type_no.EditValue = row["bill_type_no"].ToString();
                txtPo_no.Text = row["po_no"].ToString();
                txtShipping_methods.Text = row["shipping_methods"].ToString();
                lueAddress_id.EditValue = row["address_id"].ToString();
                change_flag = false;
            }
        }
        private void loadSoInvoiceDetails()
        {
            dtDetails=clsDgdDeliverGoods.loadSoInvoiceDetails(txtId.Text.Trim());
            gridControl1.DataSource = dtDetails;
            if (dtDetails.Rows.Count > 0)
            {
                change_flag = false;
                fillDetailsControls(0);
            }
            else
            {
                change_flag = true;
            }
        }
        private void cleanTextBoxDetails()
        {
            txtSequence_id.Text = "";
            txtMo_id.Text = "";
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            lueGoods_id.EditValue = "";
            lueAddress_id.EditValue = "";
            txtU_invoice_qty.Text = "";
            txtQty_pcs.Text = "";
            lueGoods_unit.EditValue = "";
            txtOrder_id.Text = "";
            txtCustomer_goods.Text = "";
            txtCustomer_color_id.Text = "";
            txtContract_cid.Text = "";
            txtRemark.Text = "";
            txtTable_head.Text = "";
            txtSec_qty.Text = "";
            txtPackage_num.Text = "";
            txtBox_no.Text = "";
            txtOrder_Seq.Text = "";
            txtOc_Ver.Text = "";
            txtSpec.Text = "";
            lueLocation_id.EditValue = "";
            chkIs_print.Checked = false;
            chkShipment_suit.Checked = false;
            txtGoods_id.Visible = false;
            lueGoods_id.Visible = true;
            lueGoods_id.Properties.DataSource = null;
            if (xtbControl1.SelectedTabPageIndex == 1)//明細表新增後設置默認值
            {
                if (txtSales_Group.Text == "L")
                    lueLocation_id.EditValue = "Y10";
                else
                {                   
                    if(!string.IsNullOrEmpty(txtIt_Customer.Text))
                    {
                        string strCust = txtIt_Customer.EditValue.ToString();
                        if (strCust.Substring(0, 2) == "DL")
                        {
                            lueLocation_id.EditValue = "D03";
                        }
                        if (strCust.Substring(0, 2) == "DD")
                        {
                            lueLocation_id.EditValue = "JX1";
                        }                        
                    }
                    else 
                        lueLocation_id.EditValue = "";
                }                    
                chkIs_print.Checked = true;
            }
        }
        private void addDetailsValue()
        {
            dtDetails.Rows.Add();
            DataRow row = dtDetails.Rows[dtDetails.Rows.Count - 1];
            row["sequence_id"] = "0" + dtDetails.Rows.Count.ToString();
            row["mo_id"] = txtMo_id.Text;
            row["goods_id"] = "ABC";
            cleanTextBoxDetails();
        }
        private void dgvDetails_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (dgvDetails.FocusedColumn.FieldName == "mo_id")
            {
                //this.dgvDetails.Columns["colGoods_id"] = "abc";
                //string a1 = e.Value.ToString();
                //this.dgvDetails.FocusedColumn.FieldName[""] = "aaa";
                //dgvDetails.Columns["colSeq"] = "sdfa";
                //string ab = this.dgvDetails.Columns["colGoods_id"].ToString();
                //string a2;
                //string regName = this.dgvDetails.GetRowCellValue(e.RowHandle, "reg_name").ToString().Trim();
                //int row = dgvDetails.SelectRows;

                //this.dgvDetails.SetRowCellValue(1, dgvDetails.Columns["colGoods_id"], "adc");

                //GridView view = sender as GridView;
                //view.SetRowCellValue(1, view.Columns["colGoods_id"], "aad");


                //dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", txtMo_id.Text);
            }
            
            
        }

        private void lueGoods_id_Leave(object sender, EventArgs e)
        {
            fillTextControlsFromStore();
            //**因阿華下拉框有多條記錄要選時相關內容不跟著變，以下代碼修改于20180424號           
            txtGoods_id.Text = lueGoods_id.EditValue.ToString();
            txtGoods_name.Text = lueGoods_id.GetColumnValue("goods_name").ToString();
            txtU_invoice_qty.Text = lueGoods_id.GetColumnValue("qty").ToString();
            txtSec_qty.Text = lueGoods_id.GetColumnValue("sec_qty").ToString();
            lueGoods_unit.EditValue = "PCS";
            txtQty_pcs.Text = txtU_invoice_qty.Text;
            //**
        }
        private void fillTextControlsFromStore()
        {
            if (lueGoods_id.EditValue != null && lueGoods_id.EditValue.ToString().Trim() != "")
            {
                DataTable dtMoOc = clsDgdDeliverGoods.getMoOc(txtMo_id.Text.Trim());
                if (dtMoOc.Rows.Count > 0)
                {
                    DataRow row = dtMoOc.Rows[0];
                    txtU_invoice_qty.Text = row["order_qty"].ToString();
                    lueGoods_unit.EditValue = row["goods_unit"].ToString();
                    txtOrder_id.Text = row["id"].ToString();
                    txtCustomer_goods.Text = row["customer_goods"].ToString();
                    txtCustomer_color_id.Text = row["customer_color_id"].ToString();
                    txtContract_cid.Text = row["contract_id"].ToString();
                    txtRemark.Text = row["add_remark"].ToString();
                    txtTable_head.Text = row["table_head"].ToString();
                    txtOrder_Seq.Text = row["sequence_id"].ToString();
                    txtOc_Ver.Text = row["ver"].ToString();
                    txtSpec.Text = "";
                    chkIs_print.Checked = true;
                    countWeg();
                }
                else
                {
                    txtGoods_id.Text = "";
                    txtGoods_name.Text = "";
                    txtU_invoice_qty.Text = "";
                    txtQty_pcs.Text = "";
                    lueGoods_unit.EditValue = "";
                    txtOrder_id.Text = "";
                    txtCustomer_goods.Text = "";
                    txtCustomer_color_id.Text = "";
                    txtContract_cid.Text = "";
                    txtRemark.Text = "";
                    txtTable_head.Text = "";
                    txtSec_qty.Text = "";
                    txtOrder_Seq.Text = "";
                    txtOc_Ver.Text = "";
                    txtSpec.Text = "";
                    chkIs_print.Checked = false;
                }
                chkShipment_suit.Checked = (lueGoods_id.EditValue.ToString().Substring(0, 2) == "F0") ? true : false;                
            }
        }
        private void countWeg()
        {
            txtSec_qty.Text = "0.00";
            txtQty_pcs.Text = "0";
            if (txtU_invoice_qty.Text.Trim() != "" && txtGoods_id.Text.Trim() != "" && lueGoods_unit.EditValue != null && lueGoods_unit.EditValue.ToString() !="")
            {
                DataTable dtUnitRate = clsDgdDeliverGoods.getUnitRate(lueGoods_unit.EditValue.ToString());
                float unit_rate = Convert.ToSingle(dtUnitRate.Rows[0]["rate"].ToString());
                float i_qty_pcs = Convert.ToSingle(txtU_invoice_qty.Text) * unit_rate;
                txtQty_pcs.Text = i_qty_pcs.ToString();
                if (txtSales_Group.Text.Trim().ToUpper() == "C")
                {
                    float st_qty_pcs = 0, st_weg_pcs = 0;
                    string goods_id = txtGoods_id.Text.Trim();
                    for (int i = 0; i < dtMoStore.Rows.Count; i++)
                    {
                        DataRow row = dtMoStore.Rows[i];
                        if (goods_id == row["goods_id"].ToString())
                        {
                            txtGoods_id.Text = row["goods_id"].ToString();
                            txtGoods_name.Text = row["goods_name"].ToString();
                            st_qty_pcs = Convert.ToSingle(row["qty"]);
                            st_weg_pcs = Convert.ToSingle(row["sec_qty"]);
                            break;
                        }
                    }
                    if (st_qty_pcs != 0 && st_weg_pcs != 0)
                    {
                        txtSec_qty.Text= (i_qty_pcs == st_qty_pcs)? st_weg_pcs.ToString(): Math.Round(i_qty_pcs * (st_weg_pcs / st_qty_pcs), 2).ToString();                        
                    }
                }
            }
                
        }

        private void txtU_invoice_qty_Leave(object sender, EventArgs e)
        {
            countWeg();
        }

        private void lueGoods_unit_Leave(object sender, EventArgs e)
        {
            countWeg();
        }

        private void dgvDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
            fillDetailsControls(dgvDetails.FocusedRowHandle);
        }
        private void fillDetailsControls(int row)
        {
            cleanTextBoxDetails();
            txtMo_id.Text = dgvDetails.GetRowCellValue(row, "mo_id").ToString();
            txtGoods_id.Text = dgvDetails.GetRowCellValue(row, "goods_id").ToString();
            lueLocation_id.EditValue = dgvDetails.GetRowCellValue(row, "location_id").ToString();
            getMoStore();
            lueGoods_id.EditValue = dgvDetails.GetRowCellValue(row, "goods_id").ToString();
            txtGoods_name.Text = dgvDetails.GetRowCellValue(row, "goods_name").ToString();
            txtSequence_id.Text = dgvDetails.GetRowCellValue(row, "sequence_id").ToString();
            txtU_invoice_qty.Text = dgvDetails.GetRowCellValue(row, "u_invoice_qty").ToString();
            txtQty_pcs.Text = dgvDetails.GetRowCellValue(row, "u_invoice_qty_pcs").ToString();
            lueGoods_unit.EditValue = dgvDetails.GetRowCellValue(row, "goods_unit").ToString();
            txtSec_qty.Text = dgvDetails.GetRowCellValue(row, "sec_qty").ToString();
            txtPackage_num.Text = dgvDetails.GetRowCellValue(row, "package_num").ToString();
            txtBox_no.Text = dgvDetails.GetRowCellValue(row, "box_no").ToString();
            txtCustomer_goods.Text = dgvDetails.GetRowCellValue(row, "customer_goods").ToString();
            txtCustomer_color_id.Text = dgvDetails.GetRowCellValue(row, "customer_color_id").ToString();
            txtContract_cid.Text = dgvDetails.GetRowCellValue(row, "contract_cid").ToString();
            txtTable_head.Text = dgvDetails.GetRowCellValue(row, "table_head").ToString();
            txtOrder_id.Text = dgvDetails.GetRowCellValue(row, "order_id").ToString();
            txtOrder_Seq.Text = dgvDetails.GetRowCellValue(row, "so_sequence_id").ToString();
            txtOc_Ver.Text = dgvDetails.GetRowCellValue(row, "so_ver").ToString();
            txtRemark.Text = dgvDetails.GetRowCellValue(row, "remark").ToString();
            if (dgvDetails.GetRowCellValue(row, "shipment_suit").ToString().Trim() == "1")
                chkShipment_suit.Checked = true;
            else
                chkShipment_suit.Checked = false;
            if (dgvDetails.GetRowCellValue(row, "is_print").ToString().Trim() == "Y")
                chkIs_print.Checked = true;
            else
                chkIs_print.Checked = false;
            lueGoods_id.Visible = false;
            txtGoods_id.Visible = true;
            change_flag = false;
            txtState.Text = dgvDetails.GetRowCellValue(row, "state").ToString();
            //dgvDetails.SetRowCellValue(row, "goods_name", txtMo_id.Text);
        }

        private void txtGoods_id_Click(object sender, EventArgs e)
        {
            txtGoods_id.Visible = false;
            lueGoods_id.Visible = true;
            getMoStore();
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Trim() != "")
            {
                getMoStore();
                txtBox_no.Focus();
            }
        }
        private void getMoStore()
        {
            string loc = (lueLocation_id.EditValue != null ? lueLocation_id.EditValue.ToString() : "");
            dtMoStore = clsDgdDeliverGoods.getMoStore(loc, txtMo_id.Text.Trim(),txtSales_Group.Text.Trim().ToUpper(), "");
            lueGoods_id.Properties.DataSource = dtMoStore;
            lueGoods_id.Properties.ValueMember = "goods_id";
            lueGoods_id.Properties.DisplayMember = "goods_id";
            if (dtMoStore.Rows.Count > 0)
            {
                lueGoods_id.EditValue = dtMoStore.Rows[0]["goods_id"].ToString();
                txtGoods_id.Text = dtMoStore.Rows[0]["goods_id"].ToString();
                txtGoods_name.Text = dtMoStore.Rows[0]["goods_name"].ToString();
                fillTextControlsFromStore();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 0)
                deleteHead();
            else
                deleteDetails();
        }
        private void deleteHead()
        {
            using (DataTable dtIdSeq = clsDgdDeliverGoods.checkExistIdDetailsByMoSaveDelete(txtId.Text.Trim(), ""))
            {
                if (dtIdSeq.Rows.Count > 0)
                {
                    MessageBox.Show("明細表中存在記錄,不能刪除主表的記錄");
                    return;
                }
            }
            if (clsDgdDeliverGoods.deleteHhead(txtId.Text.Trim(), id_ver) > 0)
            {
                cleanTextBoxHead();    
            }
        }
        private void deleteDetails()
        {
            if (txtSequence_id.Text.Trim() != "")
            {
                if (clsDgdDeliverGoods.checkExistIdDetailsReturnTable(txtId.Text.Trim(), id_ver, txtSequence_id.Text.Trim()) == false)
                {
                    MessageBox.Show("這筆記錄已生成送貨單，不能再刪除!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("沒有要刪除的記錄!");
                return;
            }
            if (clsDgdDeliverGoods.deleteDetails(txtId.Text.Trim(), id_ver, txtSequence_id.Text.Trim()) > 0)
            {
                cleanTextBoxDetails();
                loadSoInvoiceDetails();
                
            }
        }

        private void xtbControl1_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                btnNew.Text = "新單";
                cleanTextBoxHead();
                loadSoInvoiceHead();
            }
            else
            {
                btnNew.Text = "新記錄";
                cleanTextBoxDetails();
                loadSoInvoiceDetails();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (change_flag == true)
            {
                DialogResult dr = MessageBox.Show("放棄編輯？", "对话框标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                    change_flag = false;
                else
                    return;
            }
            frmDgdDeliverGoods.query_id = txtId.Text;
            frmDgdDeliverGoods_Find frmDgdDeliverGoods_Find = new frmDgdDeliverGoods_Find();
            frmDgdDeliverGoods_Find.ShowDialog();
            frmDgdDeliverGoods_Find.Dispose();
            if (frmDgdDeliverGoods.query_id != "")
            {
                cleanTextBoxHead();
                cleanTextBoxDetails();
                txtId.Text = frmDgdDeliverGoods.query_id;
                loadSoInvoiceHead();
                loadSoInvoiceDetails();
                if (dgvDetails.RowCount > 0)
                {
                    int curr_row=0;
                    for (int i = 0; i < dgvDetails.RowCount; i++)
                    {
                        if (query_seq == dgvDetails.GetRowCellValue(i, "sequence_id").ToString())
                        {
                            curr_row = i;
                            break;
                        }
                    }
                    Record_Location(curr_row);
                }
                
                txtId1.Text = txtId.Text;
                txtId2.Text = txtId.Text;
                txtMo_id1.Text = "";
                txtMo_id2.Text = "";
                mktDate1.Text = "    /  /";
                mktDate2.Text = "    /  /";
                if(txtId1.Text.Substring(0,2)!="L-")
                    radGrp2.SelectedIndex = 0;
                else
                    radGrp2.SelectedIndex = 1;
                btnSearch_Click(null, null);
                xtbControl1.SelectedTabPageIndex = 1;//設第二頁為當前頁
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                DataTable dtReport = clsDgdDeliverGoods.Get_Report_Data(txtId.Text.Trim(), radGrp1.SelectedIndex);
                cf01.Reports.xrDeliveryBill_by_id myRpt1 = new cf01.Reports.xrDeliveryBill_by_id() { DataSource = dtReport };
                myRpt1.CreateDocument();
                myRpt1.PrintingSystem.ShowMarginsWarning = false;
                myRpt1.ShowPreviewDialog();
            }
            else
                MessageBox.Show("沒有要列印的數據!", "提示信息");
        }      

        private void Record_Location(int cur_row)
        {
            if (dgvDetails.RowCount > 0)
            {
                //int cur_row;
                //if (dgvDetails.RowCount == 1)
                //    cur_row = 0;
                //else
                //    cur_row = dgvDetails.RowCount - 1;
                dgvDetails.FocusedRowHandle = cur_row;
                dgvDetails.SelectRow(cur_row);

                ColumnView view = (ColumnView)dgvDetails;//初始單元格焦點
                view.FocusedColumn = view.Columns["mo_id"];
                view.Focus();                
            }
        }

        private void txtMo_id_EditValueChanged(object sender, EventArgs e)
        {
            change_flag = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1,date2;            
            if (mktDate1.Text == "    /  /")
                date1 = "";
            else
                date1 = mktDate1.Text;
            if (mktDate2.Text == "    /  /")
                date2 = "";
            else
                date2 = mktDate2.Text;
            if (txtId1.Text == "" && txtId2.Text == "" && txtMo_id1.Text == "" && txtMo_id2.Text == "" && date1 == "" && date2 == "")
            {
                MessageBox.Show("查找條件不可為空!","提示信息");
                return;
            }
                       
            if (radGrp2.SelectedIndex == 0)
            {
                //查手寫東莞D或者L組入單數據
                Set_Visible(0);
                dtExcel = clsDgdDeliverGoods.Get_Report_Data(txtId1.Text, txtId2.Text, txtMo_id1.Text, txtMo_id2.Text, date1, date2, radGrp1.SelectedIndex,txtGroup.Text);
                dgvExcel.DataSource = dtExcel;
            }
            else
            {
                //查發票
                Set_Visible(1);
                dtExcel = clsDgdDeliverGoods.Get_Invoice_Data(txtId1.Text, txtId2.Text, txtMo_id1.Text, txtMo_id2.Text, date1, date2);
                dgvInvoice.DataSource = dtExcel;
            }
            
            if(dtExcel.Rows.Count==0)
            {
                MessageBox.Show("沒有符合查找條件的數據!", "提示信息");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvExcel.RowCount > 0)
            {
                this.ExportExcel(dgvExcel);
                //ExpToExcel oxls = new ExpToExcel();
                //oxls.ExportExcel(dgvExcel);
            }
            else
                MessageBox.Show("沒有要匯出的數據!", "提示信息");
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void mktDate1_Leave(object sender, EventArgs e)
        {
            mktDate2.Text = mktDate1.Text;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.RowCount > 0 && dgvInvoice.Visible)
            {
                if(txtId1.Text !="")
                   btnSearch_Click(null, null);
                clsDgdDeliverGoods.Export_to_Invoice(dtExcel);                
            }
            else
                MessageBox.Show("請首先查詢出發票數據!", "提示信息");
        }

        private void mktDate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");                
            }
        }

        private void radGrp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radGrp2.SelectedIndex == 0)
                Set_Visible(0);
            else            
                Set_Visible(1);
        } 
  
        private void Set_Visible(int i)
        {
            if (i == 0)
            {
                dgvExcel.Visible = true;
                dgvInvoice.Visible = false;
            }
            else
            {
                dgvExcel.Visible = false ;
                dgvInvoice.Visible = true;
            }
        }

        private void btnPacking_Click(object sender, EventArgs e)
        {
            string date1, date2;
            if (mktDate1.Text == "    /  /")
                date1 = "";
            else
                date1 = mktDate1.Text;
            if (mktDate2.Text == "    /  /")
                date2 = "";
            else
                date2 = mktDate2.Text;
            if (txtId1.Text == "" && txtId2.Text == "" && txtMo_id1.Text == "" && txtMo_id2.Text == "" && date1 == "" && date2 == "")
            {
                MessageBox.Show("查找條件不可為空!", "提示信息");
                return;
            }
            radGrp2.SelectedIndex = 1;
            //查裝箱單數據           
            using (DataTable dtPacking = clsDgdDeliverGoods.Get_Packing_Data(txtId1.Text, txtId2.Text, txtMo_id1.Text, txtMo_id2.Text, date1, date2))
            {
                if (dtPacking.Rows.Count == 0)
                {
                    MessageBox.Show("沒有符合查找條件的數據!", "提示信息");
                    return;
                }
                clsDgdDeliverGoods.Export_to_PackingList(dtPacking);
            }
        }

        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.RowCount > 0)
            {
                int i = dgvInvoice.CurrentRow.Index;
                txtId1.Text = dgvInvoice.Rows[i].Cells["invoice_id"].Value.ToString();
                txtId2.Text = dgvInvoice.Rows[i].Cells["invoice_id"].Value.ToString();
            }
        }

        private void lueGoods_id_EditValueChanged(object sender, EventArgs e)
        {
            change_flag = true;
        }

        /// <summary>
        /// 參數為DataGridView格式
        /// </summary>
        /// <param name="myDGV"></param>
        private void ExportExcel(DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {
                //bool fileSaved = false; 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
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
                        MessageBox.Show("無法創建Excel對象,可能當前操作系統上未安裝有Excel");
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

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();

                    //寫入標題  
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                    }
                    //寫入數值   
                    string tableHead = "";
                    for (int r = 0; r < myDGV.Rows.Count; r++)
                    {
                        for (int i = 0; i < myDGV.ColumnCount; i++)
                        {
                            if (myDGV.Columns[i].Name.ToString()=="table_head")
                            {
                                //處理款號前面是0是轉EXCEL自動消失問題
                                tableHead = myDGV.Rows[r].Cells[i].Value.ToString();
                                if (string.IsNullOrEmpty(tableHead))
                                {
                                    tableHead = " ";
                                }
                                if(tableHead.Substring(0,1)=="0")
                                {
                                    tableHead = "'" + tableHead;
                                }                                 
                                worksheet.Cells[r + 2, i + 1] = tableHead;
                            }
                            else
                            {
                                worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                            }
                           
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  

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
                    clsUtility.myMessageBox("匯出EXCEL成功!", "提示信息");
                    //MessageBox.Show("匯出EXCEL成功!", "系統提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("無要匯出EXCEL之數據!", "提示信息", MessageBoxButtons.OK);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!change_flag)
            {
                MessageBox.Show("非編輯狀態，當前操作無效!", "提示信息", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtId.Text))
            {
                return;
            }
            if (txtId.Text.Substring(0, 1) != "C")
            {
                MessageBox.Show("當前用戶對應組別不是C組，當前操作無效!", "提示信息", MessageBoxButtons.OK);
                return;
            }
            if (lueLocation_id.Text=="")
            {
                MessageBox.Show("倉庫編號不可為空，當前操作無效!", "提示信息", MessageBoxButtons.OK);
                return;
            }
            frmDgdDeliverGoods_Find2 frm = new frmDgdDeliverGoods_Find2();
            frm.ShowDialog();
            if (frm.lstMo.Count > 0)
            {
                int prdId = 0;
                string moId = "";
                decimal qty = 0;
                decimal weg = 0;
                DataTable dtMoOc = new DataTable();
                string result = "";
                int update_flag = 0;
                for (int i=0;i< frm.lstMo.Count; i++)
                {
                    prdId = frm.lstMo[i].prd_id;
                    moId = frm.lstMo[i].mo_id;
                    qty = frm.lstMo[i].qty;
                    weg = frm.lstMo[i].weg;
                    txtMo_id.Text = moId;
                    if (txtMo_id.Text.Trim() != "")
                    {
                        //getMoStore();** 替換為以下代碼
                        string loc = lueLocation_id.EditValue.ToString();
                        dtMoStore = clsDgdDeliverGoods.getMoStore(loc, txtMo_id.Text.Trim(), txtSales_Group.Text.Trim().ToUpper(), "");
                        lueGoods_id.Properties.DataSource = dtMoStore;
                        lueGoods_id.Properties.ValueMember = "goods_id";
                        lueGoods_id.Properties.DisplayMember = "goods_id";
                        if (dtMoStore.Rows.Count > 0)
                        {
                            lueGoods_id.EditValue = dtMoStore.Rows[0]["goods_id"].ToString();
                            txtGoods_id.Text = dtMoStore.Rows[0]["goods_id"].ToString();
                            txtGoods_name.Text = dtMoStore.Rows[0]["goods_name"].ToString();
                            //fillTextControlsFromStore();//** 替換為以下代碼
                            dtMoOc = clsDgdDeliverGoods.getMoOc(txtMo_id.Text.Trim());
                            if (dtMoOc.Rows.Count > 0)
                            {
                                DataRow row = dtMoOc.Rows[0];
                                txtU_invoice_qty.Text = row["order_qty"].ToString();
                                lueGoods_unit.EditValue = row["goods_unit"].ToString();
                                txtOrder_id.Text = row["id"].ToString();
                                txtCustomer_goods.Text = row["customer_goods"].ToString();
                                txtCustomer_color_id.Text = row["customer_color_id"].ToString();
                                txtContract_cid.Text = row["contract_id"].ToString();
                                txtRemark.Text = row["add_remark"].ToString();
                                txtTable_head.Text = row["table_head"].ToString();
                                txtOrder_Seq.Text = row["sequence_id"].ToString();
                                txtOc_Ver.Text = row["ver"].ToString();
                                txtSpec.Text = "";
                                chkIs_print.Checked = true;
                                countWeg();
                            }
                            else
                            {
                                txtGoods_id.Text = "";
                                txtGoods_name.Text = "";
                                txtU_invoice_qty.Text = "";
                                txtQty_pcs.Text = "";
                                txtSec_qty.Text = "";
                                lueGoods_unit.EditValue = "";
                                txtOrder_id.Text = "";
                                txtCustomer_goods.Text = "";
                                txtCustomer_color_id.Text = "";
                                txtContract_cid.Text = "";
                                txtRemark.Text = "";
                                txtTable_head.Text = "";
                                txtOrder_Seq.Text = "";
                                txtOc_Ver.Text = "";
                                txtSpec.Text = "";
                                chkIs_print.Checked = false;
                            }
                            chkShipment_suit.Checked = (lueGoods_id.EditValue.ToString().Substring(0, 2) == "F0") ? true : false;
                            //save ** 替換為以下代碼
                            if (!validDetails())
                            {
                                MessageBox.Show(string.Format(@"當前頁數【{0}】數據有問題，請返回檢查!",moId), "提示信息", MessageBoxButtons.OK);
                                return;
                            }
                            //string old_sequence_id = txtSequence_id.Text.Trim();
                            //int old_record = dgvDetails.FocusedRowHandle;
                            soinvoice_details objModel = new soinvoice_details();
                            objModel.id = txtId.Text.Trim();
                            objModel.ver = id_ver;
                            objModel.sequence_id = "";  //txtSequence_id.Text.Trim();
                            objModel.mo_id = txtMo_id.Text.Trim();
                            objModel.goods_id = txtGoods_id.Text.Trim();
                            objModel.goods_name = txtGoods_name.Text.Trim();
                            objModel.u_invoice_qty = Convert.ToDecimal(txtU_invoice_qty.Text);
                            objModel.u_invoice_qty_pcs = Convert.ToDecimal(txtQty_pcs.Text);
                            objModel.goods_unit = lueGoods_unit.EditValue.ToString();
                            objModel.sec_qty = Convert.ToDecimal(txtSec_qty.Text);
                            objModel.sec_unit = "KG";
                            objModel.location_id = lueLocation_id.EditValue.ToString();
                            objModel.carton_code = objModel.location_id;
                            objModel.shipment_suit = (chkShipment_suit.Checked == false)?"0":"1";                            
                            objModel.remark = txtRemark.Text.Trim();
                            objModel.package_num = (txtPackage_num.Text != "" ? Convert.ToInt32(txtPackage_num.Text) : 0);
                            objModel.box_no = txtBox_no.Text.Trim();
                            objModel.order_id = txtOrder_id.Text.Trim();
                            objModel.so_ver = Convert.ToInt32(txtOc_Ver.Text);
                            objModel.so_sequence_id = txtOrder_Seq.Text.Trim();
                            objModel.table_head = txtTable_head.Text.Trim();
                            objModel.contract_cid = txtContract_cid.Text.Trim();
                            objModel.customer_goods = txtCustomer_goods.Text.Trim();
                            objModel.customer_color_id = txtCustomer_color_id.Text.Trim();
                            objModel.spec = txtSpec.Text.Trim();                            
                            objModel.state = "0";
                            objModel.is_print = (chkIs_print.Checked == false)?"N":"Y";                            
                            result = clsDgdDeliverGoods.AddSoInvoiceDetails(objModel);
                            if (result != "")
                            {
                                //更新成功！
                                update_flag = clsDgdDeliverGoods.UpdatePackingMoRecordState(prdId); //更新包裝部頁數掃描數據中已匯入的狀態                                
                            }
                        } //--end of if (dtMoStore.Rows.Count > 0)
                    } //--end of if (txtMo_id.Text.Trim() != "")
                }//end of for() ...loop
                if (update_flag > 0)
                {
                    change_flag = false;
                    append_mode = false;                                                       
                    clsUtility.myMessageBox("數據導入保存成功！", "提示信息");                    
                    loadSoInvoiceDetails();//重新刷新數據
                }
            } //end of if(frm.lstMo.Count > 0)
            frm.Dispose();
        }
    }
}
