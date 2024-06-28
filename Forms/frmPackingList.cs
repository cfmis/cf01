using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RUI.PC;
using cf01.Forms;
using cf01.CLS;
using cf01.MDL;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{

    public partial class frmPackingList : Form
    {
        //private string edit_type = "Y";//控制當控件中當值發生變化時的操作
        private string _userid = DBUtility._user_id;
        private string within_code = DBUtility.within_code;
        private clsPackingList clsPackingList = new clsPackingList();
        private clsStTransferToHk clsTransfer = new clsStTransferToHk();
        private bool edit_mode = false;
        private bool new_rec_flag = false;
        private int details_type = 0;//0--主表;1--明細表
        private bool goods_set_flag = true;
        public static string query_id = "";
        public static string query_seq = "";
        public static string query_date = "";
        private DataTable dtGoods_id = new DataTable();
        public frmPackingList()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void initControls()
        {
            txtPacking_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtSailing_date.Text = txtPacking_date.Text;
            //數量單位
            DataTable dtQtyUnit = clsPackingList.getUnit("05");
            cmbUnit_code.DataSource = dtQtyUnit;
            cmbUnit_code.DisplayMember = "name";
            cmbUnit_code.ValueMember = "id";

            //重量單位
            DataTable dtWegUnit = clsPackingList.getUnit("03");
            lueSec_unit.Properties.DataSource = dtWegUnit;
            lueSec_unit.Properties.ValueMember = "id";
            lueSec_unit.Properties.DisplayMember = "name";
            //類型
            DataTable dtGroup = clsTransfer.getTypeNo("E");
            lueType.Properties.DataSource = dtGroup;
            lueType.Properties.ValueMember = "id";
            lueType.Properties.DisplayMember = "name";
            //來源
            DataTable dtTypeNo = clsTransfer.getTypeNo("SOURCE99");
            lueOrigin_id.Properties.DataSource = dtTypeNo;
            lueOrigin_id.Properties.ValueMember = "id";
            lueOrigin_id.Properties.DisplayMember = "name";
            //紙箱尺寸
            DataTable dtBoxSize = clsPackingList.getBoxSize();
            lueCarton_size.Properties.DataSource = dtBoxSize;
            lueCarton_size.Properties.ValueMember = "id";
            lueCarton_size.Properties.DisplayMember = "name";
            
            rdbAftSave.SelectedIndex = 2;

            setShowInfo();

            loadPackListHeadByDate();
            
        }

        private void frmPackingList_Load(object sender, EventArgs e)
        {
            initControls();
            txtBarCode.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cleanTextBoxHead();
            edit_mode = true;
            new_rec_flag = false;
            details_type = 0;
            txtId.Text = "";
            btnUndo.Enabled = true;
            txtMo_id.Text = "";
            setNewValue();
        }
        private void cleanTextBoxHead()
        {
            txtPacking_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtSailing_date.Text = txtPacking_date.Text;
            lueType.EditValue = "PA";
            lueOrigin_id.EditValue = "3";
            txtCustomer_id.Text = "";
            txtLinkman.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtShipping_tool.Text = "";
            txtCreate_By.Text = "";
            txtCreate_Date.Text = "";
            txtUpdate_By.Text = "";
            txtUpdate_Date.Text = "";
            txtState.Text = "";
            txtRemark.Text = "";
            //gcDetails.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                //if (edit_mode == false)
                //{
                //    MessageBox.Show("沒有建立新單!");
                //    return;
                //}
                string ret_value = "";
                PackListHead objModelHead = new PackListHead();
                PackListDetails objModelDetails = new PackListDetails();
                if (new_rec_flag == false)
                    objModelHead=getValueHead();
                if (!checkNewDetails())
                    return;
                objModelDetails = getValueDetails();
                ret_value = clsPackingList.updateData(new_rec_flag, objModelHead, objModelDetails);
                //result = "DPA0000125255";
                if (ret_value != "")
                {
                    edit_mode = false;
                    if (new_rec_flag == false)
                        txtId.Text = ret_value;
                    else
                        txtSeq.Text = ret_value;
                    if (new_rec_flag == false && chkAftSavePrint.Checked == true)//新單儲存後列印
                        printReport(1, ret_value);
                    
                    loadId();
                    loadPackListDetails();
                    if (new_rec_flag == false)//儲存後，若是新單的，則重新獲取當日的單號
                        loadPackListHeadByDate();
                    if (rdbAftSave.SelectedIndex == 0)
                        btnNew_Click(sender, e);
                    else
                        if (rdbAftSave.SelectedIndex == 1)
                            btnNewRec_Click(sender, e);
                        else
                        {
                            
                            MessageBox.Show("記錄儲存成功!");
                            
                            //loadPackListDetails();
                        }

                }

            }
            //else
            //    if (xtbControl1.SelectedTabPageIndex == 1)
            //        addNewDetails();
            //    else
            //        MessageBox.Show("沒有儲存的工作區!");
        }

        private PackListHead getValueHead()
        {
            PackListHead objModel = new PackListHead();
            if (checkNewDoc())
            {

                objModel.packing_date = txtPacking_date.Text;//"2000/01/01";
                objModel.sailing_date = txtSailing_date.Text;
                objModel.type = lueType.EditValue.ToString();
                objModel.origin_id = lueOrigin_id.EditValue.ToString();
                objModel.customer_id = txtCustomer_id.Text;
                objModel.customer = txtCustomer.Text.Trim();
                objModel.linkman = txtLinkman.Text;
                objModel.phone = txtPhone.Text;
                objModel.fax = txtFax.Text;
                objModel.shipping_tool = txtShipping_tool.Text;
                objModel.remark = txtRemark.Text;
            }
            return objModel;
        }
        private PackListDetails getValueDetails()
        {
            PackListDetails objModel = new PackListDetails();
            objModel.id = txtId.Text;
            objModel.sequence_id = txtSeq.Text.Trim();
            objModel.mo_id = txtMo_id.Text;
            objModel.goods_id = lueGoods_id.EditValue.ToString();

            objModel.shipment_suit = "1";
            if (chkSet.Checked == false)
                objModel.shipment_suit = "0";
            objModel.box_no = txtBox_no.Text;
            objModel.po_no = txtPo_no.Text;
            objModel.goods_name = txtGoods_name.Text;
            objModel.goods_ename = txtGoods_ename.Text;
            objModel.order_id = txtOrder_id.Text;
            objModel.ref_id = txtRef_id.Text;
            objModel.pcs_qty = (txtPcs_qty.Text != "" ? Convert.ToDecimal(txtPcs_qty.Text) : 0);
            objModel.unit_code = cmbUnit_code.SelectedValue.ToString().ToUpper();
            objModel.pbox_qty = (txtPbox_qty.Text != "" ? Convert.ToDecimal(txtPbox_qty.Text) : 0);
            objModel.symbol = txtSymbol.Text;
            objModel.sec_unit = lueSec_unit.EditValue.ToString();
            objModel.box_qty = (txtBox_qty.Text != "" ? Convert.ToInt32(txtBox_qty.Text) : 0);
            objModel.cube_ctn = (txtCube_ctn.Text != "" ? Convert.ToDecimal(txtCube_ctn.Text) : 0);
            objModel.nw_each = (txtNw_each.Text != "" ? Convert.ToDecimal(txtNw_each.Text) : 0);
            objModel.gw_each = (txtGw_each.Text != "" ? Convert.ToDecimal(txtGw_each.Text) : 0);
            objModel.total_cube = (txtTotal_cube.Text != "" ? Convert.ToDecimal(txtTotal_cube.Text) : 0);
            objModel.tal_nw = (txtTal_nw.Text != "" ? Convert.ToDecimal(txtTal_nw.Text) : 0);
            objModel.tal_gw = (txtTal_gw.Text != "" ? Convert.ToDecimal(txtTal_gw.Text) : 0);
            objModel.remark = txtRemark.Text;
            objModel.tr_id = txtTr_id.Text;
            objModel.tr_id_seq = txtTr_id_seq.Text;
            objModel.tr_id_weg = (txtTr_id_weg.Text != "" ? Convert.ToDecimal(txtTr_id_weg.Text) : 0);
            objModel.carton_size = (lueCarton_size.EditValue != null ? lueCarton_size.EditValue.ToString() : "");
            return objModel;
        }


        private bool checkNewDoc()
        {
            if (!clsValidRule.CheckDateFormat(txtPacking_date.Text.Trim()))
            {
                MessageBox.Show("裝箱日期不正確!");
                txtPacking_date.Focus();
                return false;
            }
            if (lueType.EditValue == null || lueType.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("單據類型不能為空!");
                lueType.Focus();
                return false;
            }
            if (lueOrigin_id.EditValue == null || lueOrigin_id.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("來源不能為空!");
                lueOrigin_id.Focus();
                return false;
            }
            if (txtCustomer_id.Text.Trim() == "")
            {
                MessageBox.Show("客戶編號不能為空!");
                txtCustomer_id.Focus();
                return false;
            }
            return true;
        }

        private bool checkNewDetails()
        {
            if (new_rec_flag == true || txtSeq.Text.Trim() != "")
            {
                if (!checkIdState())//當是新增記錄時，檢查單據的狀態
                    return false;
            }
            if (txtMo_id.Text.Trim() == "")
            {
                MessageBox.Show("制單編號不能為空!");
                txtMo_id.Focus();
                return false;
            }
            //DataTable dtCust = clsPackingList.findOcData(txtMo_id.Text.Trim());
            //if (dtCust.Rows.Count > 0)
            //{
            //    if (string.Compare(dtCust.Rows[0]["it_customer"].ToString(),txtCustomer_id.Text.Trim())!=0)
            //    {
            //        MessageBox.Show("該制單的客戶与單據的客戶不匹配: " + dtCust.Rows[0]["it_customer"].ToString());
            //        txtMo_id.Focus();
            //        return false;
            //    }
            //}
            if (txtPcs_qty.Text != "" && !clsValidRule.IsIntNumeric(txtPcs_qty.Text))
            {
                MessageBox.Show("數量格式不正確!");
                txtPcs_qty.Focus();
                return false;
            }
            if (txtPbox_qty.Text != "" && !clsValidRule.IsIntNumeric(txtPbox_qty.Text))
            {
                MessageBox.Show("數量/箱格式不正確!");
                txtPbox_qty.Focus();
                return false;
            }
            if (txtBox_qty.Text != "" && !clsValidRule.IsIntNumeric(txtBox_qty.Text))
            {
                MessageBox.Show("箱數格式不正確!");
                txtBox_qty.Focus();
                return false;
            }
            if (txtCube_ctn.Text != "" && !clsValidRule.IsNumeric(txtCube_ctn.Text))
            {
                MessageBox.Show("體積/箱格式不正確!");
                txtCube_ctn.Focus();
                return false;
            }
            if (txtNw_each.Text != "" && !clsValidRule.IsNumeric(txtNw_each.Text))
            {
                MessageBox.Show("凈重/箱格式不正確!");
                txtNw_each.Focus();
                return false;
            }
            if (txtGw_each.Text != "" && !clsValidRule.IsNumeric(txtGw_each.Text))
            {
                MessageBox.Show("毛重/箱格式不正確!");
                txtGw_each.Focus();
                return false;
            }
            if (txtTotal_cube.Text != "" && !clsValidRule.IsNumeric(txtTotal_cube.Text))
            {
                MessageBox.Show("總體積格式不正確!");
                txtTotal_cube.Focus();
                return false;
            }
            if (txtTal_nw.Text != "" && !clsValidRule.IsNumeric(txtTal_nw.Text))
            {
                MessageBox.Show("總凈重格式不正確!");
                txtTal_nw.Focus();
                return false;
            }
            if (txtTal_gw.Text != "" && !clsValidRule.IsNumeric(txtTal_gw.Text))
            {
                MessageBox.Show("總毛重格式不正確!");
                txtTal_gw.Focus();
                return false;
            }

            return true;
        }

        private void txtMo_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true)
            {
                addNewRec();
            }
        }

        private void addNewRec()
        {
            cleanTextDetails();
            getGoodsFromOc();
            findOcData();
            
        }
        private void cleanTextDetails()
        {
            chkSet.Checked = true;
            goods_set_flag = true;
            txtSeq.Text="";
            
            lueGoods_id.EditValue="";
            chkSet.Checked =true;
            txtBox_no.Text="";
            txtBox_qty.Text = "";
            txtPo_no.Text="";
            txtGoods_name.Text="";
            txtGoods_ename.Text="";
            txtColor.Text = "";
            txtOrder_id.Text="";
            txtRef_id.Text="";
            txtPcs_qty.Text ="";
            cmbUnit_code.SelectedValue="";
            txtPbox_qty.Text ="";
            txtSymbol.Text = "@";
            lueSec_unit.EditValue="KG";
            txtCube_ctn.Text ="";
            txtNw_each.Text="";
            txtGw_each.Text ="";
            txtTotal_cube.Text ="";
            txtTal_nw.Text ="";
            txtTal_gw.Text = "";
            txtRemark_d.Text = "";
            txtTr_id.Text = "";
            txtTr_id_seq.Text = "";
            txtTr_id_weg.Text = "";
            lueCarton_size.EditValue = "";
        }

        //從OC中獲取產品編號
        private void getGoodsFromOc()
        {
            string s_type = "2";
            if (lueOrigin_id.EditValue != null)
                s_type = lueOrigin_id.EditValue.ToString();
            if (s_type == "2")
                dtGoods_id = clsTransfer.findGoodsFromOc(txtMo_id.Text.Trim(), "", goods_set_flag);
            else
                if (s_type == "3")
                    dtGoods_id = clsPackingList.loadTranDetailsByMo(txtMo_id.Text.Trim(), goods_set_flag);
            lueGoods_id.Properties.DataSource = dtGoods_id;
            lueGoods_id.Properties.ValueMember = "goods_id";
            lueGoods_id.Properties.DisplayMember = "goods_id";
            if (dtGoods_id.Rows.Count > 0)
            {
                lueGoods_id.ItemIndex = 0;
                if (edit_mode == true)
                {
                    fillTextBoxDetails(0);
                    
                    findGoodsData();
                }
            }
        }
        private void fillTextBoxDetails(int i)
        {
            DataRow dr = dtGoods_id.Rows[i];
            txtPcs_qty.Text = dr["order_qty_o"].ToString();
            cmbUnit_code.SelectedValue = dr["goods_unit"].ToString();
            if (lueOrigin_id.EditValue.ToString() == "3")
            {
                txtTr_id.Text = dr["id"].ToString();
                txtTr_id_seq.Text = dr["sequence_id"].ToString();
                txtTr_id_weg.Text = dr["sec_qty"].ToString();
                bool has_mo = false;
                if (gvDetails.RowCount > 0)
                {
                    if (string.Compare(txtMo_id.Text, gvDetails.GetDataRow(gvDetails.RowCount - 1)["mo_id"].ToString().Trim()) == 0)
                    {
                        has_mo = true;
                    }
                }

                if (has_mo == false)
                {

                    
                    txtBox_qty.Text = dr["package_num"].ToString();
                    if (txtBox_qty.Text.Trim() == "" || txtBox_qty.Text == "0")
                        txtBox_qty.Text = "1";
                    txtNw_each.Text = dr["nwt"].ToString();
                    txtGw_each.Text = dr["gross_wt"].ToString();
                    

                }
                else
                {
                    int order_qty = Convert.ToInt32(dr["order_qty_o"]);
                    int pk_qty = Convert.ToInt32(gvDetails.GetDataRow(gvDetails.RowCount - 1)["pcs_qty"]);
                    if (order_qty > pk_qty)
                    {
                        txtPcs_qty.Text = (order_qty - pk_qty).ToString();
                        txtBox_qty.Text = "1";
                    }
                }
                countGwt();
                countNwt();
            }
            countBoxQty();
        }
        private void findOcData()
        {
            DataTable dtCust = clsPackingList.findOcData(txtMo_id.Text.Trim());
            if (dtCust.Rows.Count > 0)
            {
                DataRow dr = dtCust.Rows[0];

                txtPo_no.Text = dr["contract_id"].ToString();
                txtOrder_id.Text = dr["id"].ToString();
                if (new_rec_flag == false)//只有在新單時，才更新表頭，新增記錄時不再更新
                {
                    txtCustomer_id.Text = dr["it_customer"].ToString();
                    findCustData();
                }
            }
        }

        private void findCustData()
        {
            DataTable dtCust = clsPackingList.findCustData(txtCustomer_id.Text.Trim());
            if (dtCust.Rows.Count > 0)
            {
                txtCustomer.Text = dtCust.Rows[0]["cust_cname"].ToString();
                txtPhone.Text = dtCust.Rows[0]["phone"].ToString();
                txtFax.Text = dtCust.Rows[0]["fax"].ToString();
                txtLinkman.Text = dtCust.Rows[0]["linkman"].ToString();
            }
        }
        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtBarCode.Text.Trim().Length < 9)
                        return;
                    string mo_id = txtBarCode.Text.Trim().Substring(0, 9).ToUpper();
                    txtBarCode.Text = "";
                    if (edit_mode == true)
                    {
                        txtMo_id.Text = mo_id;
                        addNewRec();
                        txtPcs_qty.Focus();
                        txtPcs_qty.SelectAll();
                        
                    }
                    else
                    {
                        //當不是新增狀態掃描時，先查找是否有該制單的記錄，若有則帶出，沒有則轉到新增狀態
                        txtBarCode.Focus();
                        string id = clsPackingList.loadDetailsByMo(mo_id);
                        if (id == "")
                        {
                            //edit_mode = true;
                            //new_rec_flag = false;
                            //if (!setNewValue())
                            //    return;
                            btnNew_Click(sender, e);
                            txtMo_id.Text = mo_id;
                            addNewRec();

                            txtPcs_qty.Focus();
                            txtPcs_qty.SelectAll();
                        }
                        else
                        {
                            txtId.Text = id;

                            //cleanTextBoxHead();
                            cleanTextDetails();
                            //gcTranDetails.DataSource = null;
                            loadId();
                            loadPackListDetails();
                        }
                    }
                    break;
            }
        }

        private void chkSet_Click(object sender, EventArgs e)
        {
            if (edit_mode == true)
            {
                if (chkSet.Checked == true)
                    goods_set_flag = false;
                else
                    goods_set_flag = true;
                getGoodsFromOc();
            }
        }

        private void txtCustomer_id_Leave(object sender, EventArgs e)
        {
            if (txtCustomer_id.Text.Trim() != "")
                findCustData();
        }

        private void lueGoods_id_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true)
            {
                fillTextBoxDetails(lueGoods_id.ItemIndex);
                findGoodsData();
            }
        }
        private void findGoodsData()
        {
            if (lueGoods_id.EditValue != null && lueGoods_id.EditValue.ToString() != "")
            {
                DataTable dt = clsPackingList.findGoodsData(lueGoods_id.EditValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    txtGoods_name.Text = dr["goods_name"].ToString();
                    txtGoods_ename.Text = dr["goods_ename"].ToString();
                    txtColor.Text = dr["color_name"].ToString();
                }
                
            }
        }

        private void btnNewRec_Click(object sender, EventArgs e)
        {
            new_rec_flag = true;
            setNewValue();
        }
        private bool setNewValue()
        {
            if (new_rec_flag == true)
            {
                if (!checkIdState())
                {
                    if (xtbControl1.SelectedTabPageIndex == 1)
                        txtBarCode.Focus();
                    new_rec_flag = false;
                    edit_mode = false;
                    return false;
                }

                details_type = 1;
                edit_mode = true;
                btnUndo.Enabled = true;
                
                txtMo_id.Text = "";
            }
            txtBarCode.Focus();
            cleanTextDetails();
            setShowInfo();
            return true;
        }

        private bool checkIdState()
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show("單據編號不能為空!");
                txtId.Focus();
                return false;
            }
            DataTable dtId = clsPackingList.checkIdState(txtId.Text, "", "", "");
            if (dtId.Rows.Count == 0)
            {
                MessageBox.Show("單據編號不存在!");
                txtId.Focus();
                return false;
            }
            else
            {
                if (dtId.Rows[0]["state"].ToString().Trim() == "1")
                {
                    MessageBox.Show("單據編號已批準,不能再操作!");
                    txtId.Focus();
                    return false;
                }
            }
            return true;
        }
        private void setShowInfo()
        {
            if (edit_mode == true)
            {
                lblShowInfo.Text = "編輯狀態";
                lblShowInfo.ForeColor = Color.FromArgb(0xFF, 0x33, 0x00);
            }
            else
            {
                lblShowInfo.Text = "瀏覽狀態";
                lblShowInfo.ForeColor = Color.Blue;
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (edit_mode == false)
            {
                cleanTextDetails();
                loadId();
                loadPackListDetails();
            }
        }
        private void loadId()
        {
            if (edit_mode == false)
            {
                if (txtId.Text.Trim() != "")
                {
                    DataTable dtId = clsPackingList.loadIdMostly(txtId.Text.Trim(), "");

                    if (dtId.Rows.Count > 0)
                    {
                        DataRow dr = dtId.Rows[0];
                        txtPacking_date.Text = (dr["packing_date"].ToString() != "" ? Convert.ToDateTime(dr["packing_date"].ToString()).ToString("yyyy/MM/dd") : "");
                        txtSailing_date.Text = (dr["sailing_date"].ToString() != "" ? Convert.ToDateTime(dr["sailing_date"].ToString()).ToString("yyyy/MM/dd") : "");
                        lueType.EditValue = dr["type"].ToString();
                        lueOrigin_id.EditValue = dr["origin_id"].ToString();
                        txtCustomer_id.Text = dr["customer_id"].ToString();
                        txtCustomer.Text = dr["customer"].ToString();
                        txtLinkman.Text = dr["linkman"].ToString();
                        txtPhone.Text = dr["phone"].ToString();
                        txtFax.Text = dr["fax"].ToString();
                        txtShipping_tool.Text = dr["shipping_tool"].ToString();
                        txtRemark.Text = dr["remark"].ToString();
                        txtCreate_By.Text = dr["create_by"].ToString();
                        txtCreate_Date.Text = (dr["create_date"].ToString() != "" ? Convert.ToDateTime(dr["create_date"].ToString()).ToString("yyyy/MM/dd hh:mm:ss") : "");
                        txtUpdate_By.Text = dr["update_by"].ToString();
                        txtUpdate_Date.Text = (dr["update_date"].ToString() != "" ? Convert.ToDateTime(dr["update_date"].ToString()).ToString("yyyy/MM/dd hh:mm:ss") : "");
                        txtState.Text = dr["state"].ToString();
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            edit_mode = false;
            btnUndo.Enabled = false;
            cleanTextBoxHead();
            cleanTextDetails();
            setShowInfo();
        }
        private void loadPackListHeadByDate()
        {
            DataTable dtId = clsPackingList.loadIdMostly("", txtPacking_date.Text.Trim());
            dtId.Columns.Add("check", System.Type.GetType("System.Boolean"));
            gcHead.DataSource = dtId;
        }
        private void loadPackListDetails()
        {
            //if (edit_mode == false)
            //{
                if (txtId.Text.Trim() != "")
                {
                    DataTable dtId = clsPackingList.loadPackListDetails(txtId.Text.Trim());
                    gcDetails.DataSource = dtId;
                    if (dtId.Rows.Count > 0)
                        fillTextControlsDetails(dtId.Rows.Count - 1);
                }
            //}
        }

        private void gvHead_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            fillTextControls(gvHead.FocusedRowHandle);
        }
        private void fillTextControls(int rowIndex)
        {
            //gcDetailsPart.DataSource = dtId;
            txtId.Text = gvHead.GetDataRow(rowIndex)["id"].ToString().Trim();
            lueType.EditValue = gvHead.GetDataRow(rowIndex)["type"].ToString().Trim();
            txtPacking_date.Text = gvHead.GetDataRow(rowIndex)["packing_date"].ToString().Trim();
            lueOrigin_id.EditValue = gvHead.GetDataRow(rowIndex)["origin_id"].ToString().Trim();
            txtSailing_date.Text = gvHead.GetDataRow(rowIndex)["sailing_date"].ToString().Trim();
            txtCustomer_id.Text = gvHead.GetDataRow(rowIndex)["customer_id"].ToString().Trim();
            txtCustomer.Text = gvHead.GetDataRow(rowIndex)["customer"].ToString().Trim();
            txtLinkman.Text = gvHead.GetDataRow(rowIndex)["linkman"].ToString().Trim();
            txtPhone.Text = gvHead.GetDataRow(rowIndex)["phone"].ToString().Trim();
            txtFax.Text = gvHead.GetDataRow(rowIndex)["fax"].ToString().Trim();
            txtRemark.Text = gvHead.GetDataRow(rowIndex)["remark"].ToString().Trim();
            txtState.Text = gvHead.GetDataRow(rowIndex)["state"].ToString().Trim();
            txtCreate_By.Text = gvHead.GetDataRow(rowIndex)["create_by"].ToString().Trim();
            txtCreate_Date.Text = gvHead.GetDataRow(rowIndex)["create_date"].ToString().Trim();
            txtUpdate_By.Text = gvHead.GetDataRow(rowIndex)["update_by"].ToString().Trim();
            txtUpdate_Date.Text = gvHead.GetDataRow(rowIndex)["update_date"].ToString().Trim();
            loadPackListDetails();
            //fillTextControlsDetails(0);
            edit_mode = false;
            btnUndo.Enabled = false;
            setShowInfo();
            txtBarCode.Focus();
        }

        private void gvDetails_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            fillTextControlsDetails(gvDetails.FocusedRowHandle);
        }

        private void fillTextControlsDetails(int rowIndex)
        {
             //gcDetailsPart.DataSource = dtId;
            txtMo_id.Text = gvDetails.GetDataRow(rowIndex)["mo_id"].ToString().Trim();
            getGoodsFromOc();
            lueGoods_id.EditValue = gvDetails.GetDataRow(rowIndex)["item_no"].ToString().Trim();
            txtSeq.Text = gvDetails.GetDataRow(rowIndex)["sequence_id"].ToString().Trim();
            txtBox_no.Text = gvDetails.GetDataRow(rowIndex)["box_no"].ToString().Trim();
            txtPo_no.Text = gvDetails.GetDataRow(rowIndex)["po_no"].ToString().Trim();
            txtGoods_name.Text=gvDetails.GetDataRow(rowIndex)["descript"].ToString().Trim();
            txtGoods_ename.Text = gvDetails.GetDataRow(rowIndex)["english_goods_name"].ToString().Trim();
            txtColor.Text = gvDetails.GetDataRow(rowIndex)["color_name"].ToString().Trim();
            txtOrder_id.Text=gvDetails.GetDataRow(rowIndex)["order_id"].ToString().Trim();
            txtRef_id.Text=gvDetails.GetDataRow(rowIndex)["ref_id"].ToString().Trim();
            txtPcs_qty.Text=(gvDetails.GetDataRow(rowIndex)["pcs_qty"].ToString().Trim()!="0"?gvDetails.GetDataRow(rowIndex)["pcs_qty"].ToString().Trim():"");
            cmbUnit_code.SelectedValue=gvDetails.GetDataRow(rowIndex)["unit_code"].ToString().Trim();
            txtPbox_qty.Text = (gvDetails.GetDataRow(rowIndex)["pbox_qty"].ToString().Trim() != "0" ? gvDetails.GetDataRow(rowIndex)["pbox_qty"].ToString().Trim() : "");
            txtBox_qty.Text = (gvDetails.GetDataRow(rowIndex)["box_qty"].ToString().Trim() != "0" ? gvDetails.GetDataRow(rowIndex)["box_qty"].ToString().Trim() : "");
            txtSymbol.Text = gvDetails.GetDataRow(rowIndex)["symbol"].ToString().Trim();
            lueSec_unit.EditValue=gvDetails.GetDataRow(rowIndex)["sec_unit"].ToString().Trim();
            txtCube_ctn.Text = (gvDetails.GetDataRow(rowIndex)["cube_ctn"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["cube_ctn"].ToString().Trim() : "");
            txtNw_each.Text = (gvDetails.GetDataRow(rowIndex)["nw_each"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["nw_each"].ToString().Trim() : "");
            txtGw_each.Text = (gvDetails.GetDataRow(rowIndex)["gw_each"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["gw_each"].ToString().Trim() : "");
            txtTotal_cube.Text = (gvDetails.GetDataRow(rowIndex)["total_cube"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["total_cube"].ToString().Trim() : "");
            txtTal_nw.Text = (gvDetails.GetDataRow(rowIndex)["tal_nw"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["tal_nw"].ToString().Trim() : "");
            txtTal_gw.Text = (gvDetails.GetDataRow(rowIndex)["tal_gw"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["tal_gw"].ToString().Trim() : "");
            txtRemark_d.Text = gvDetails.GetDataRow(rowIndex)["remark"].ToString().Trim();
            txtTr_id.Text = gvDetails.GetDataRow(rowIndex)["tr_id"].ToString().Trim();
            txtTr_id_seq.Text = gvDetails.GetDataRow(rowIndex)["tr_sequence_id"].ToString().Trim();
            txtTr_id_weg.Text = (gvDetails.GetDataRow(rowIndex)["sec_qty"].ToString().Trim() != "0.00" ? gvDetails.GetDataRow(rowIndex)["sec_qty"].ToString().Trim() : "");
            lueCarton_size.EditValue = gvDetails.GetDataRow(rowIndex)["carton_size"].ToString().Trim();
            if (gvDetails.GetDataRow(rowIndex)["shipment_suit"].ToString().Trim() == "0")
                chkSet.Checked = false;
            else
                chkSet.Checked = true;
            edit_mode = false;
            btnUndo.Enabled = false;
            setShowInfo();
            txtBarCode.Focus();
        }

        private void btnDelRec_Click(object sender, EventArgs e)
        {
            delRec(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delRec(1);
        }

        private void delRec(int type)
        {
            if (!checkIdState())
            {
                if (xtbControl1.SelectedTabPageIndex == 1)
                    txtBarCode.Focus();
                return;
            }
            if (type==1)
            {
                if (gvDetails.RowCount > 0)
                {
                    MessageBox.Show("明細表存在記錄,不能刪除單據!");
                    return;
                }
                if (txtId.Text.Trim() == "")
                {
                    MessageBox.Show("沒有選擇要刪除的記錄");
                    return;
                }
                DialogResult result = MessageBox.Show("確定刪除記錄?", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (clsPackingList.deleteHead(txtId.Text.Trim()) > 0)
                    {
                        cleanTextBoxHead();
                        loadPackListDetails();
                        loadPackListHeadByDate();
                    }

                }
            }
            else
            {
                if (txtId.Text.Trim() == "" || txtSeq.Text.Trim() == "")
                {
                    MessageBox.Show("沒有選擇要刪除的記錄");
                    return;
                }
                DialogResult result = MessageBox.Show("確定刪除記錄?", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (clsPackingList.deleteDetails(txtId.Text.Trim(), txtSeq.Text.Trim()) > 0)
                    {
                        cleanTextDetails();
                        loadPackListDetails();

                        if (gvDetails.RowCount > 0)
                        {
                            gvDetails.FocusedRowHandle = 0;
                            fillTextControlsDetails(0);
                        }
                    }

                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            printReport(1, txtId.Text.Trim());
        }

        

        private void txtBox_qty_Leave(object sender, EventArgs e)
        {
            countNwt();
            countGwt();
            countBoxQty();
        }
        private void countNwt()
        {
            if (clsValidRule.IsIntNumeric(txtBox_qty.Text) && clsValidRule.IsNumeric(txtNw_each.Text))
                txtTal_nw.Text = Math.Round(Convert.ToDecimal(txtBox_qty.Text) * Convert.ToDecimal(txtNw_each.Text), 2).ToString();
        }
        private void countGwt()
        {
            if (clsValidRule.IsIntNumeric(txtBox_qty.Text) && clsValidRule.IsNumeric(txtGw_each.Text))
                txtTal_gw.Text = Math.Round(Convert.ToDecimal(txtBox_qty.Text) * Convert.ToDecimal(txtGw_each.Text), 2).ToString();
        }
        private void countBoxQty()
        {
            if (clsValidRule.IsIntNumeric(txtBox_qty.Text) && clsValidRule.IsNumeric(txtPcs_qty.Text))
                txtPbox_qty.Text = Math.Round(Convert.ToDecimal(txtPcs_qty.Text) / Convert.ToDecimal(txtBox_qty.Text), 0).ToString();
        }
        private void txtNw_each_Leave(object sender, EventArgs e)
        {
            countNwt();
        }

        private void txtGw_each_Leave(object sender, EventArgs e)
        {
            countGwt();
        }

        private void txtPcs_qty_Leave(object sender, EventArgs e)
        {
            countBoxQty();
        }

        private void chkPrint_Click(object sender, EventArgs e)
        {
            bool chk_flag = true;
            if (chkPrint.Checked == false)
                chk_flag = true;
            else
                chk_flag = false;
            for (int RowIndex = 0; RowIndex < gvHead.RowCount; RowIndex++)
            {
                gvHead.GetDataRow(RowIndex)["check"] = chk_flag;
            }
        }

        private void btnBatchPrint_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            bool print_flag = false;
            for (int RowIndex = 0; RowIndex < gvHead.RowCount; RowIndex++)
            {
                if (gvHead.GetDataRow(RowIndex)["check"].ToString() == "True")
                {
                    print_flag = true;
                    break;
                }
            }
            if (print_flag == false)
            {
                MessageBox.Show("沒有選擇列印的記錄!");
                return;
            }
            for (int RowIndex = 0; RowIndex < gvHead.RowCount; RowIndex++)
            {
                if (gvHead.GetDataRow(RowIndex)["check"].ToString() == "True")
                {
                    printReport(1, gvHead.GetDataRow(RowIndex)["id"].ToString().Trim());
                }
            }
        }

        private void printReport(int print_type, string id)
        {
            DataTable dtReport = clsPackingList.loadPackListPrint(id);
            xrPackingList oRepot = new xrPackingList() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            if (print_type == 2)
                oRepot.ShowPreview();
            else
                oRepot.Print();//.PrintDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            loadPackListHeadByDate();
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            string dat1 = "", dat2 = "";
            if (clsValidRule.CheckDateFormat(txtDate1.Text.Trim()) && clsValidRule.CheckDateFormat(txtDate2.Text.Trim()))
            {
                dat1 = txtDate1.Text;
                dat2 = Convert.ToDateTime(txtDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            }
            DataTable dtId = clsPackingList.checkIdState(txtPid1.Text.Trim(), txtPid2.Text.Trim(), dat1, dat2);
            if (dtId.Rows.Count==0)
            {
                MessageBox.Show("沒有找到要列印的記錄!");
                return;
            }
            for (int i = 0; i < dtId.Rows.Count; i++)
            {
                printReport(1, dtId.Rows[i]["id"].ToString());
            }
        }

        private void xtbControl1_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 1)
            {
                txtPid1.Text = txtId.Text;
                txtPid2.Text = txtId.Text;
                txtDate1.Text = txtPacking_date.Text;
                txtDate2.Text = txtDate1.Text;
            }
        }

        private void txtPid1_Leave(object sender, EventArgs e)
        {
            txtPid2.Text = txtPid1.Text;
        }

        private void txtDate1_EditValueChanged(object sender, EventArgs e)
        {
            txtDate2.Text = txtDate1.Text;
        }


    }
}
