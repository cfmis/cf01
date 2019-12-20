using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.MDL;
using DevExpress.XtraGrid.Views.Grid;


namespace cf01.Forms
{
    public partial class frmDgdInvoice : Form
    {
        private bool change_flag = false;
        private bool append_mode = false;
        private string within_code = DBUtility.within_code;
        private DataTable dtDetails = new DataTable();
        private DataTable dtMoStore = new DataTable();
        private int id_ver = 0;
        public frmDgdInvoice()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtShip_date_EditValueChanged(object sender, EventArgs e)
        {
            change_flag = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

                saveHead();

                //saveDetails();
        }
        private void saveHead()
        {
            if (change_flag == false)
                return;
            if (!validHead())
                return;
            soinvoice_head_geo objModel = new soinvoice_head_geo();
            objModel.id = txtId.Text.Trim();
            objModel.ver = id_ver;
            objModel.separate = txtSeparate.Text;
            objModel.ship_date = Convert.ToDateTime(txtShip_date.Text);
            objModel.it_customer = txtIt_Customer.Text.Trim();
            objModel.seller_id = lueSeller_id.EditValue.ToString();
            objModel.m_id = lueM_id.EditValue.ToString();
            objModel.bill_type_no = lueBill_type_no.EditValue.ToString();
            objModel.phone = txtPhone.Text.Trim();
            objModel.fax = txtFax.Text.Trim();
            objModel.email = txtEmail.Text.Trim();
            objModel.linkman = txtLinkman.Text.Trim();
            objModel.l_phone = txtL_phone.Text.Trim();
            objModel.exchange_rate = (txtExchange_rate.Text != "" ? Convert.ToSingle(txtExchange_rate.Text) : 0);
            objModel.m_rate = objModel.exchange_rate;
            objModel.po_no = txtPo_no.Text.Trim();
            objModel.issues_wh = txtIssues_wh.Text.Trim();
            objModel.fake_bill_address = txtFake_address.Text.Trim();
            objModel.fake_address = objModel.fake_bill_address;
            objModel.address = txtCust_name.Text.Trim() + " " + txtFake_address.Text.Trim() + " " + "ATTN:" + txtLinkman.Text.Trim();
            objModel.flag = "1";
            objModel.name = txtCust_name.Text.Trim();
            objModel.p_id = "09";
            objModel.pc_id = "FOB HK IN HKD";
            objModel.cd_disc = "1";
            objModel.disc_rate = (txtDisc_rate.Text != "" ? Convert.ToSingle(txtDisc_rate.Text) : 0);
            objModel.disc_amt = (txtDisc_amt.Text != "" ? Convert.ToSingle(txtDisc_amt.Text) : 0);
            objModel.disc_spare = (txtDisc_spare.Text != "" ? Convert.ToSingle(txtDisc_spare.Text) : 0);
            objModel.other_fare = (txtOther_fare.Text != "" ? Convert.ToSingle(txtOther_fare.Text) : 0);
            objModel.goods_sum = (txtGoods_sum.Text != "" ? Convert.ToSingle(txtGoods_sum.Text) : 0);
            objModel.tax_sum = 0;
            objModel.total_sum = (txtTotal_sum.Text != "" ? Convert.ToSingle(txtTotal_sum.Text) : 0);
            objModel.ncr_amount = 0;
            objModel.ncrb_amount = 0;
            objModel.update_count = "1";
            objModel.area = "L";
            objModel.as_id = "001";
            objModel.merchandiser = lueMerchandiser.EditValue.ToString().Trim();
            objModel.merchandiser_phone = txtMerchandiser_phone.Text.Trim();
            objModel.finally_buyer = objModel.it_customer;
            objModel.bill_address = objModel.address;
            objModel.confirm_status = "0";
            objModel.packinglistno = "";
            objModel.mo_group = "C";
            objModel.servername = "hkserver.cferp.dbo";
            objModel.voucher_id = "";
            objModel.fake_name = "";
            txtId.Text = clsDgdDeliverGoods.AddSoInvoiceHeadToGeo(objModel);
            loadSoInvoiceHead();
        }
        private void saveDetails()
        {
            if (!validDetails())
                return;
            soinvoice_details objModel = new soinvoice_details();
            objModel.id = txtId.Text.Trim();
            objModel.ver = id_ver;
 
        }
        private bool validHead()
        {
            //bool result = true;
            //if (txtId.Text.Trim() == "")
            //{
            //    MessageBox.Show("單據編號不能為空!");
            //    return false;
            //}
            if (clsValidRule.CheckDateFormat(this.txtShip_date.Text) == false)
            {
                MessageBox.Show("送貨單日期格式不正確!");
                this.txtShip_date.Focus();
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

            return true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            append_mode = true;
            cleanTextBoxHead();
            txtShip_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtIt_Customer.Text = "DL-C0117";
            txtSeparate.Text = "1";
            txtIssues_wh.Text = "D";
            getCust(txtIt_Customer.Text);

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
                txtCust_name.Text = dtRow["name"].ToString();
                txtPhone.Text = dtRow["phone"].ToString();
                txtFax.Text = dtRow["fax"].ToString();
                txtEmail.Text = dtRow["email"].ToString();
                txtLinkman.Text = "朱生";
                txtL_phone.Text = dtRow["phone"].ToString();
                txtExchange_rate.Text = "";
                txtFake_address.Text = dtRow["fake_s_address"].ToString().Trim() + " " + "TEL:" + txtL_phone.Text.Trim()
                    + " " + "FAX:" + txtFax.Text.Trim() + " " + "EMAIL:" + txtEmail.Text.Trim();
                setCurrRate(lueM_id.EditValue.ToString());
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
                txtCust_name.Text = "";
                txtFake_address.Text = "";
            }
        }

        private void frmDgdDeliverGoods_Load(object sender, EventArgs e)
        {
            initControls();
        }
        private void initControls()
        {
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

        }
        private void cleanTextBoxHead()
        {
            lueMerchandiser.EditValue = "";
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
            txtCust_name.Text = "";
            lueBill_type_no.EditValue = "";
            txtPo_no.Text = "";
            txtFake_address.Text = "";
            txtMerchandiser_phone.Text = "";
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
            setCurrRate(lueM_id.EditValue.ToString());
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
            DataTable dtSo = clsDgdDeliverGoods.loadSoInvoiceHeadGeo(txtId.Text.Trim(), id_ver);
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
                txtCust_name.Text = row["name"].ToString();
                lueBill_type_no.EditValue = row["bill_type_no"].ToString();
                txtPo_no.Text = row["po_no"].ToString();
                txtFake_address.Text = row["fake_address"].ToString();
                txtDisc_rate.Text = row["disc_rate"].ToString();
                txtDisc_amt.Text = row["disc_amt"].ToString();
                txtDisc_spare.Text = row["disc_spare"].ToString();
                txtOther_fare.Text = row["other_fare"].ToString();
                txtGoods_sum.Text = row["goods_sum"].ToString();
                txtTotal_sum.Text = row["total_sum"].ToString();
                change_flag = false;
            }
        }
        private void loadSoInvoiceDetails()
        {
            dtDetails=clsDgdDeliverGoods.loadSoInvoiceDetails(txtId.Text.Trim());
            gridControl1.DataSource=dtDetails;
            change_flag = false;

        }

        private void dgvDetails_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.dgvDetails.FocusedColumn.FieldName == "mo_id")
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

        private void countWeg()
        {
            
                
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

                deleteHead();

                deleteDetails();
        }
        private void deleteHead()
        {
        }
        private void deleteDetails()
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dtIdFind = clsDgdDeliverGoods.loadDgdDetails(txtFindOc_no.Text.Trim(), txtFindId.Text.Trim(), txtFindMo_id.Text.Trim(),0);
            gcIdDetails.DataSource = dtIdFind;
        }

        private void dgvIdDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            loadOcDgdDetails(dgvIdDetails.FocusedRowHandle);
        }
        private void loadOcDgdDetails(int row)
        {
            string ocno = dgvIdDetails.GetRowCellValue(row, "order_id").ToString();
            DataTable dtOc = clsDgdDeliverGoods.loadOcDgdDetails(ocno);
            gcOcDgdDetails.DataSource = dtOc;
        }

        private void btnImput_Click(object sender, EventArgs e)
        {
            insertToGeo();
        }
        private void insertToGeo()
        {
            List<soinvoice_details_geo> lsModel = new List<soinvoice_details_geo>();

            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    soinvoice_details_geo objModel = new soinvoice_details_geo();
                    objModel.mo_id = dgvIdDetails.GetDataRow(i)["mo_id"].ToString().Trim();
                    lsModel.Add(objModel);
                }
            }
        }
    }
}
