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


namespace cf01.Forms
{
    public partial class frmStTransferToHk : Form
    {
        
        private string edit_type = "Y";//控制當控件中當值發生變化時的操作
        private string _userid = DBUtility._user_id;
        private string within_code = DBUtility.within_code;
        private clsStTransferToHk clsTransfer = new clsStTransferToHk();
        private bool edit_mode = false;
        private int details_type = 0;//0--主表;1--明細表
        private bool goods_set_flag = true;
        public static string query_id = "";
        public static string query_seq = "";
        public static string query_date = "";
        public frmStTransferToHk()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStTransferToHk_Load(object sender, EventArgs e)
        {
            initControls();
        }
        private void initControls()
        {
            txtTransfer_Date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            //組別
            DataTable dtGroup = clsTransfer.getTypeNo("3");
            lueGroup_No.Properties.DataSource = dtGroup;
            lueGroup_No.Properties.ValueMember = "id";
            lueGroup_No.Properties.DisplayMember = "name";
            //組別
            DataTable dtTypeNo = clsTransfer.getTypeNo("4");
            lueTypeNo.Properties.DataSource = dtTypeNo;
            lueTypeNo.Properties.ValueMember = "id";
            lueTypeNo.Properties.DisplayMember = "name";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cleanTextBoxHead();
            edit_mode = true;
            details_type = 0;
            txtId.Text = "";
            btnUndo.Enabled = true;
        }

        private void cleanTextBoxHead()
        {
            txtTransfer_Date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            lueTypeNo.Text = "";
            lueGroup_No.Text = "";
            txtCreate_By.Text = "";
            txtCreate_Date.Text = "";
            txtUpdate_By.Text = "";
            txtUpdate_Date.Text = "";
            txtState.Text = "";
            txtRemark.Text = "";
        }
        private bool checkNewDoc()
        {
            bool result = true;
            if (!clsValidRule.CheckDateFormat(txtTransfer_Date.Text.Trim()))
            {
                MessageBox.Show("發貨日期不正確!");
                txtTransfer_Date.Focus();
                return false;
            }
            if (lueTypeNo.EditValue==null || lueTypeNo.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("單據類型不能為空!");
                lueTypeNo.Focus();
                return false;
            }
            if (lueGroup_No.EditValue==null || lueGroup_No.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("組別不能為空!");
                lueGroup_No.Focus();
                return false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                if (edit_mode == false)
                {
                    MessageBox.Show("沒有建立新單!");
                    return;
                }
                addNewDocHead();
            }
            else
                if (xtbControl1.SelectedTabPageIndex == 1)
                    addNewDetails();
                else
                    MessageBox.Show("沒有儲存的工作區!");
        }
        private void addNewDocHead()
        {
            if (!checkNewDoc())
                return;
            StTransferHead objModel = new StTransferHead();
            objModel.transfer_date = txtTransfer_Date.Text;//"2000/01/01";
            objModel.bill_type_no = lueTypeNo.EditValue.ToString();
            objModel.group_no = lueGroup_No.EditValue.ToString();
            objModel.remark = txtRemark.Text;
            txtId.Text = clsTransfer.addNewDoc(objModel);
            if (txtId.Text != "")
            {
                MessageBox.Show("建 立 新 單 成 功!");
                edit_mode = false;
                loadId();
            }
            else
            {
                MessageBox.Show("建 立 新 單 失 敗!");
            }
        }
        private void btnNewRec_Click(object sender, EventArgs e)
        {
            setNewValue();
            
        }
        private bool setNewValue()
        {
            if (!checkIdState())
            {
                if (xtbControl1.SelectedTabPageIndex == 1)
                    txtBarCode.Focus();
                return false;
            }
            details_type = 1;
            edit_mode = true;
            btnUndo.Enabled = true;
            txtBarCode.Focus();
            txtMo_id.Text = "";
            cleanTextDetails();
            setShowInfo();
            return true;
        }
        private void cleanTextDetails()
        {
            chkSet.Checked = true;
            goods_set_flag = true;
            txtSeq.Text = "";
            lueGoods_id.EditValue = "";
            txtTransfer_amount.Text = "";
            txtSec_qty.Text = "";
            txtNwt.Text = "";
            txtGross_wt.Text = "";
            txtPackage_num.Text = "";
            txtPosition_first.Text = "";
            txtInventory_qty.Text = "";
            txtInventory_sec_qty.Text = "";
            txtUnit.Text = "";
            txtLocation_id.Text = "";
            txtRemark_d.Text = "";
            gcDetails.DataSource = null;
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
            setLocNo();
            getGoodsFromOc();
        }
        //根據單據類型，設置不同的收貨部門
        private void setLocNo()
        {
            txtLocation_id.Text = "801";
            string type_no = lueTypeNo.EditValue.ToString();
            if (goods_set_flag == true)
            {
                if (string.Compare(type_no, "DN") == 0 || string.Compare(type_no, "SN") == 0)
                    txtLocation_id.Text = "801";
                else
                    if (string.Compare(type_no, "LN") == 0)
                        txtLocation_id.Text = "D00";
                    else
                        if (string.Compare(type_no, "JN") == 0)
                            txtLocation_id.Text = "JX0";
                        else
                            if (string.Compare(type_no, "VN") == 0)
                                txtLocation_id.Text = "T00";
            }
            else
                txtLocation_id.Text = "601";
        }
        //從OC中獲取產品編號
        private void getGoodsFromOc()
        {

            DataTable dtGoods_id = clsTransfer.findGoodsFromOc(txtMo_id.Text.Trim(), "", goods_set_flag);
            lueGoods_id.Properties.DataSource = dtGoods_id;
            lueGoods_id.Properties.ValueMember = "goods_id";
            lueGoods_id.Properties.DisplayMember = "goods_id";//goods_name
            if (dtGoods_id.Rows.Count > 0)
            {
                lueGoods_id.ItemIndex = 0;
                if (edit_mode == true)
                {
                    fillTextBoxDetails(dtGoods_id);
                    findGoodsStFromRecLoc();
                }
            }
        }
        private void fillTextBoxDetails(DataTable dt)
        {
            txtTransfer_amount.Text = dt.Rows[0]["order_qty"].ToString();
            getGoodsPart();
        }
        private void getGoodsPart()
        {
            if (goods_set_flag == true)
            {
                decimal input_qty = (txtTransfer_amount.Text.Trim() != "" ? Convert.ToDecimal(txtTransfer_amount.Text) : 0);
                decimal count_qty = 0;
                decimal count_weg = 0;
                decimal count_weg_sum = 0;
                string goods_id = "";
                DataTable dtGoodsSt = clsTransfer.findGoodsStByOc("601", txtMo_id.Text.Trim(), goods_id);
                decimal st_qty = 0, st_weg = 0;
                for (int i = 0; i < dtGoodsSt.Rows.Count; i++)
                {
                    st_qty = Convert.ToDecimal(dtGoodsSt.Rows[i]["st_qty"]);
                    st_weg = Convert.ToDecimal(dtGoodsSt.Rows[i]["st_weg"]);
                    count_qty = Math.Round(input_qty * Convert.ToDecimal(dtGoodsSt.Rows[i]["dosage"]), 0);
                    double weg1 = Convert.ToDouble(dtGoodsSt.Rows[i]["st_weg"]);
                    float weg2 = Convert.ToSingle(dtGoodsSt.Rows[i]["st_weg"]);
                    decimal d1 = 0;
                    if (st_qty != 0)
                    {
                        if (count_qty == st_qty)
                            count_weg = st_weg;
                        else
                        {
                            d1 = ((st_weg / st_qty) * count_qty) * 100;
                            d1 = (int)d1;
                            count_weg = d1 / 100;
                        }
                    }
                    else
                        count_weg = 0;
                    dtGoodsSt.Rows[i]["count_qty"] = count_qty;
                    dtGoodsSt.Rows[i]["count_weg"] = count_weg;
                    count_weg_sum += count_weg;
                }
                txtSec_qty.Text = count_weg_sum.ToString();
                txtNwt.Text = txtSec_qty.Text;
                gcDetails.DataSource = dtGoodsSt;
            }
            else
                gcDetails.DataSource = null;

        }
        //從收貨倉中獲取制單的庫存，用來計算存倉數
        private void findGoodsStFromRecLoc()
        {
            string goods_id=lueGoods_id.EditValue.ToString();
            DataTable dtGoodsSt = clsTransfer.findGoodsSt(txtLocation_id.Text.Trim(), txtMo_id.Text.Trim(), goods_id);
            if (dtGoodsSt.Rows.Count > 0)
            {
                txtInventory_qty.Text = dtGoodsSt.Rows[0]["st_qty"].ToString();
                txtInventory_sec_qty.Text = dtGoodsSt.Rows[0]["st_weg"].ToString();
            }
            else
            {
                txtInventory_qty.Text = "0";
                txtInventory_sec_qty.Text = "0";
            }
        }

        private void txtTransfer_amount_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true)
                getGoodsPart();
        }

        private void lueGoods_id_Leave(object sender, EventArgs e)
        {
            if (edit_mode == true)
            {
                if (lueGoods_id.EditValue != null && lueGoods_id.EditValue.ToString() != "")
                {
                    DataTable dtGoods_id = clsTransfer.findGoodsFromOc(txtMo_id.Text.Trim(), lueGoods_id.EditValue.ToString(), goods_set_flag);
                    fillTextBoxDetails(dtGoods_id);
                    findGoodsStFromRecLoc();
                }
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtBarCode.Text.Trim().Length <9)
                        return;
                    string mo_id=txtBarCode.Text.Trim().Substring(0,9).ToUpper();
                    txtBarCode.Text = "";
                    if (edit_mode == true)//新增狀態中掃描制單
                    {
                        txtMo_id.Text = mo_id;
                        addNewRec();

                        txtNwt.Focus();
                        txtNwt.SelectAll();
                    }
                    else
                    {
                        //當不是新增狀態掃描時，先查找是否有該制單的記錄，若有則帶出，沒有則轉到新增狀態
                        txtBarCode.Focus();
                        string id = clsTransfer.loadTranDetailsByMo(mo_id);
                        if (id == "")
                        {
                            if (!setNewValue())
                                return;
                            txtMo_id.Text = mo_id;
                            addNewRec();

                            txtNwt.Focus();
                            txtNwt.SelectAll();
                        }
                        else
                        {
                            txtId.Text = id;

                            //cleanTextBoxHead();
                            cleanTextDetails();
                            gcTranDetails.DataSource = null;
                            loadId();
                            loadTranDetails();
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
                setLocNo();
                getGoodsFromOc();
            }
        }

        private void addNewDetails()
        {
            if (!checkNewDetails())
                return;

            StTransferDetails objModel = new StTransferDetails();
            List<StTransferDetailsPart> listDetail = new List<StTransferDetailsPart>();
            
            objModel.id = txtId.Text;
            objModel.sequence_id = txtSeq.Text.Trim();
            objModel.mo_id = txtMo_id.Text.Trim().ToUpper();
            objModel.goods_id = lueGoods_id.EditValue.ToString().Trim().ToUpper();
            objModel.goods_name = lueGoods_id.GetColumnValue("goods_name").ToString();
            objModel.shipment_suit = "1";
            if (chkSet.Checked == false)
                objModel.shipment_suit = "0";
            objModel.location_id = txtLocation_id.Text.Trim();
            objModel.transfer_amount = (txtTransfer_amount.Text != "" ? Convert.ToDecimal(txtTransfer_amount.Text) : 0);
            objModel.sec_qty = (txtSec_qty.Text != "" ? Convert.ToDecimal(txtSec_qty.Text) : 0);
            objModel.nwt = (txtNwt.Text != "" ? Convert.ToDecimal(txtNwt.Text) : 0);
            objModel.gross_wt = (txtGross_wt.Text != "" ? Convert.ToDecimal(txtGross_wt.Text) : 0);
            objModel.package_num = (txtPackage_num.Text != "" ? Convert.ToDecimal(txtPackage_num.Text) : 0);
            objModel.position_first = txtPosition_first.Text.Trim();
            objModel.inventory_qty = (txtInventory_qty.Text != "" ? Convert.ToDecimal(txtInventory_qty.Text) : 0);
            objModel.inventory_sec_qty = (txtInventory_sec_qty.Text != "" ? Convert.ToDecimal(txtInventory_sec_qty.Text) : 0);
            objModel.remark = txtRemark_d.Text;
            for (int i = 0; i < gvDetails.RowCount; i++)
            {
                StTransferDetailsPart objModelPart = new StTransferDetailsPart();
                objModelPart.sequence_id = gvDetails.GetDataRow(i)["sequence_id"].ToString().Trim();
                objModelPart.goods_id=gvDetails.GetDataRow(i)["goods_id"].ToString().Trim();
                objModelPart.con_qty = Convert.ToDecimal(gvDetails.GetDataRow(i)["count_qty"]);
                objModelPart.sec_qty = Convert.ToDecimal(gvDetails.GetDataRow(i)["count_weg"]);
                objModelPart.inventory_qty = Convert.ToDecimal(gvDetails.GetDataRow(i)["st_qty"]);
                objModelPart.inventory_sec_qty = Convert.ToDecimal(gvDetails.GetDataRow(i)["st_weg"]);
                objModelPart.location = gvDetails.GetDataRow(i)["location_id"].ToString().Trim();
                listDetail.Add(objModelPart);
            }
            txtSeq.Text = clsTransfer.updateTranDetails(objModel, listDetail);
            if (txtSeq.Text != "")
            {
                //MessageBox.Show("儲  存  記  錄 成 功!");

                int oldRowIndex = 0;

                if (edit_mode == true)
                {
                    oldRowIndex = 0;//新增時，儲存後定位第一行
                }
                else
                {
                    oldRowIndex = dgvTranDetails.FocusedRowHandle;//修改時，儲存後定位到當前行
                }
                edit_mode = false;

                loadTranDetails();
                dgvTranDetails.FocusedRowHandle = oldRowIndex;
                if (oldRowIndex == 0)
                    setNewValue();
                else
                    fillTextControls(oldRowIndex);





            }
            else
            {
                MessageBox.Show("儲  存  記  錄 失 敗!");
            }
        }
        private bool checkNewDetails()
        {
            if (!checkIdState())
                return false;
            //MessageBox.Show(lueGroup_No.EditValue.ToString().Trim());
            string group_no = lueGroup_No.EditValue.ToString().Trim();
            string mo_group=txtMo_id.Text.Substring(2, 1);
            string mo_group_p = txtMo_id.Text.Substring(1, 1);
            bool result = true;
            if (lueGroup_No.EditValue != null && group_no != "0")
            {
                if (mo_group != group_no)
                {
                    if (mo_group_p != "P")
                    {
                        if (group_no == "E" || group_no == "W")
                        {
                            if (mo_group != "E" && mo_group != "W")
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        if (string.Compare(mo_group_p, group_no) != 0)
                        {
                            result = false;
                        }
                    }
                }
                if (result == false)
                {
                    MessageBox.Show("此制單不屬於該組別的單據!");
                    txtMo_id.Focus();
                    return false;
                }
            }
            if (txtTransfer_amount.Text=="" || !clsValidRule.IsNumeric(txtTransfer_amount.Text))
            {
                MessageBox.Show("數量格式不正確!");
                txtTransfer_amount.Focus();
                return false;
            }
            if (txtSec_qty.Text == "" || !clsValidRule.IsNumeric(txtSec_qty.Text))
            {
                MessageBox.Show("重量格式不正確!");
                txtSec_qty.Focus();
                return false;
            }
            if (txtNwt.Text == "" || !clsValidRule.IsNumeric(txtNwt.Text))
            {
                MessageBox.Show("凈重格式不正確!");
                txtNwt.Focus();
                return false;
            }
            if (txtGross_wt.Text == "" || !clsValidRule.IsNumeric(txtGross_wt.Text))
            {
                MessageBox.Show("毛重格式不正確!");
                txtGross_wt.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtGross_wt.Text) < Convert.ToDecimal(txtNwt.Text))
            {
                MessageBox.Show("毛重不能小於凈重!");
                txtGross_wt.Focus();
                return false;
            }
            
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
            DataTable dtId = clsTransfer.checkIdState(txtId.Text);
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

        private void txtId_Leave(object sender, EventArgs e)
        {
            //cleanTextBoxHead();
            cleanTextDetails();
            gcTranDetails.DataSource = null;
            loadId();
        }
        private void loadId()
        {
            if (edit_mode == false)
            {
                if (txtId.Text.Trim() != "")
                {
                    DataTable dtId = clsTransfer.loadTranMostly(txtId.Text.Trim());
                    if (dtId.Rows.Count > 0)
                    {
                        DataRow dr = dtId.Rows[0];
                        txtTransfer_Date.Text = (dr["transfer_date"].ToString() != "" ? Convert.ToDateTime(dr["transfer_date"].ToString()).ToString("yyyy/MM/dd") : "");
                        lueTypeNo.EditValue = dr["bill_type_no"].ToString();
                        lueGroup_No.EditValue = dr["group_no"].ToString();
                        txtCreate_By.Text = dr["create_by"].ToString();
                        txtCreate_Date.Text = (dr["create_date"].ToString() != "" ? Convert.ToDateTime(dr["create_date"].ToString()).ToString("yyyy/MM/dd hh:mm:ss") : "");
                        txtUpdate_By.Text = dr["update_by"].ToString();
                        txtUpdate_Date.Text = (dr["update_date"].ToString() != "" ? Convert.ToDateTime(dr["update_date"].ToString()).ToString("yyyy/MM/dd hh:mm:ss") : "");
                        txtState.Text = dr["state"].ToString();
                        txtRemark.Text = dr["remark"].ToString();
                    }
                }
            }
        }
        private void loadTranDetails()
        {
            DataTable dtId = clsTransfer.loadTranDetails(txtId.Text.Trim());
            gcTranDetails.DataSource = dtId;
        }

        private void xtbControl1_Click(object sender, EventArgs e)
        {
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                btnNew.Enabled = true;
                btnNewRec.Enabled = false;

            }
            else
            {
                if (xtbControl1.SelectedTabPageIndex == 1)
                {

                    btnNew.Enabled = false;
                    btnNewRec.Enabled = true;
                    edit_mode = false;
                    txtMo_id.Text = "";
                    cleanTextDetails();
                    loadTranDetails();
                    setShowInfo();
                    txtBarCode.Focus();

                    if (txtState.Text == "0")//如果此單據是未批準的，自動進入新增狀態
                        setNewValue();
                }
            }
        }

        private void dgvTranDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            //fillTextControls(dgvTranDetails.FocusedRowHandle);
            
        }

        private void fillTextControls(int rowIndex)
        {
            DataTable dtId = clsTransfer.loadTranDetailsPart(txtId.Text.Trim(), dgvTranDetails.GetDataRow(rowIndex)["sequence_id"].ToString().Trim());
            //gcDetailsPart.DataSource = dtId;
            txtMo_id.Text = dgvTranDetails.GetDataRow(rowIndex)["mo_id"].ToString().Trim();
            getGoodsFromOc();
            lueGoods_id.EditValue = dgvTranDetails.GetDataRow(rowIndex)["goods_id"].ToString().Trim();
            txtSeq.Text = dgvTranDetails.GetDataRow(rowIndex)["sequence_id"].ToString().Trim();
            txtTransfer_amount.Text = dgvTranDetails.GetDataRow(rowIndex)["transfer_amount"].ToString().Trim();
            txtSec_qty.Text = dgvTranDetails.GetDataRow(rowIndex)["sec_qty"].ToString().Trim();
            txtNwt.Text = dgvTranDetails.GetDataRow(rowIndex)["nwt"].ToString().Trim();
            txtGross_wt.Text = dgvTranDetails.GetDataRow(rowIndex)["gross_wt"].ToString().Trim();
            txtPackage_num.Text = dgvTranDetails.GetDataRow(rowIndex)["package_num"].ToString().Trim();
            txtPosition_first.Text = dgvTranDetails.GetDataRow(rowIndex)["position_first"].ToString().Trim();
            txtInventory_qty.Text = dgvTranDetails.GetDataRow(rowIndex)["inventory_qty"].ToString().Trim();
            txtInventory_sec_qty.Text = dgvTranDetails.GetDataRow(rowIndex)["inventory_sec_qty"].ToString().Trim();
            txtUnit.Text = dgvTranDetails.GetDataRow(rowIndex)["unit"].ToString().Trim();
            txtLocation_id.Text = dgvTranDetails.GetDataRow(rowIndex)["location_id"].ToString().Trim();
            txtRemark_d.Text = dgvTranDetails.GetDataRow(rowIndex)["remark"].ToString().Trim();
            if (dgvTranDetails.GetDataRow(rowIndex)["shipment_suit"].ToString().Trim() == "0")
                chkSet.Checked = false;
            else
                chkSet.Checked = true;
            edit_mode = false;
            btnUndo.Enabled = false;
            setShowInfo();
            gcDetails.DataSource = dtId;
            txtBarCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!checkIdState())
            {
                if (xtbControl1.SelectedTabPageIndex == 1)
                    txtBarCode.Focus();
                return;
            }
            if (xtbControl1.SelectedTabPageIndex == 0)
            {
                if(dgvTranDetails.RowCount>0)
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
                    if (clsTransfer.deleteHead(txtId.Text.Trim()) > 0)
                    {
                        cleanTextBoxHead();
                    }

                }
            }
            else
                if (xtbControl1.SelectedTabPageIndex == 1)
                {
                    if (txtId.Text.Trim() == "" || txtSeq.Text.Trim() == "")
                    {
                        MessageBox.Show("沒有選擇要刪除的記錄");
                        return;
                    }
                    DialogResult result = MessageBox.Show("確定刪除記錄?", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (clsTransfer.deleteDetails(txtId.Text.Trim(), txtSeq.Text.Trim()) > 0)
                        {
                            cleanTextDetails();
                            loadTranDetails();

                            if (dgvTranDetails.RowCount > 0)
                            {
                                dgvTranDetails.FocusedRowHandle = 0;
                                fillTextControls(0);
                            }
                        }

                    }
                }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (edit_mode == true)
            {
                DialogResult dr = MessageBox.Show("放棄編輯？", "对话框标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                    edit_mode = false;
                else
                    return;
            }
            frmStTransferToHk.query_id = txtId.Text;
            frmStTransferToHk.query_date = txtTransfer_Date.Text;
            frmStTransferToHk_Find frmStTransferToHk_Find = new frmStTransferToHk_Find();
            frmStTransferToHk_Find.ShowDialog();
            frmStTransferToHk_Find.Dispose();
            if (frmStTransferToHk.query_id != "")
            {
                if (xtbControl1.SelectedTabPageIndex == 1)
                {

                    txtId.Text = frmStTransferToHk.query_id;
                    cleanTextDetails();
                    gcTranDetails.DataSource = null;
                    loadId();
                    loadTranDetails();

                }
                else
                {
                    txtId.Text = frmStTransferToHk.query_id;
                    loadId();
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            edit_mode = false;
            btnUndo.Enabled = false;
            setShowInfo();
            //btnNew.Enabled = false;
            //btnSave.Enabled = false;
            //btnNewRec.Enabled = false;
        }


        private void txtMo_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void dgvTranDetails_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            fillTextControls(dgvTranDetails.FocusedRowHandle);
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

        private void gvDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvDetails.FocusedColumn.FieldName == "count_weg")
            {
                Decimal weg = 0;
                for (int i = 0; i < gvDetails.RowCount; i++)
                {
                    weg += Convert.ToDecimal(gvDetails.GetDataRow(i)["count_weg"]);
                }
                txtSec_qty.Text = weg.ToString();
            }
        }

        private void gvDetails_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            

        }


        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Enter)　　// 按下的是回车键
        //    {
        //        //return true;

        //        //foreach (Control c in this.Controls)
        //        //{
        //        //    if (c is System.Windows.Forms.TextBox)　　// 当前控件是文本框控件
        //        //    {
        //        //        keyData = Keys.Tab;
        //        //    }
        //        //}
        //        //keyData = Keys.Tab;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if ((ActiveControl is TextBox || ActiveControl is ComboBox) &&
        //        keyData == Keys.Enter)
        //    {
        //        keyData = Keys.Tab;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}

    }
}
