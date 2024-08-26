using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmZipperOrderToPr : Form
    {
        private string within_code = DBUtility.within_code;
        private string userid = DBUtility._user_id;
        private clsPublicOfGEO clsConnGeo = new clsPublicOfGEO();
        public frmZipperOrderToPr()
        {
            InitializeComponent();
        }

        private void frmZipperOrderToPr_Load(object sender, EventArgs e)
        {
            txtPr_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtReq_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtPr_remark.Text = "訂單用,李烈焰已批";
            txtId.Text = frmZipperOrder.query_id;
            initControls();
            //findData();
        }
        private void initControls()
        {
            //單位
            DataTable dtUnit = clsZipperOrder.getUnit();
            lueGoods_unit.Properties.DataSource = dtUnit;
            lueGoods_unit.Properties.ValueMember = "id";
            lueGoods_unit.Properties.DisplayMember = "name";
        }
        private void findData()
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            loadIdDetails(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void loadIdDetails()
        {
            int to_pr_state = rdgIsPr.SelectedIndex;
            DataTable dtId = clsZipperOrder.findIdDetailsPr(txtId.Text.Trim(),to_pr_state);
            gcDetails.DataSource = dtId;
        }


        private void btnConf_Click(object sender, EventArgs e)
        {
            if (clsValidRule.CheckDateFormat(this.txtPr_date.Text) == false)
            {
                MessageBox.Show("申購單日期格式不正確!");
                this.txtPr_date.Focus();
                return;
            }
            if (clsValidRule.CheckDateFormat(this.txtReq_date.Text) == false)
            {
                MessageBox.Show("要求日期格式不正確!");
                this.txtReq_date.Focus();
                return;
            }
            insertToPr();
        }
        private void insertToPr()
        {
            if (txtId.Text.Trim()!="" && !clsZipperOrder.checkGeoPrId(txtId.Text.Trim()))
                return;
            bool update_flag = false;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetDataRow(i)["is_select"].ToString() == "True" && dgvDetails.GetDataRow(i)["to_pr_state"].ToString().Trim() == "未申購")
                {
                    update_flag = true;
                    break;
                }
            }
            if (update_flag == false)
            {
                MessageBox.Show("沒有選擇要更新的記錄!");
                return;
            }
            string id = txtId.Text.Trim();
            so_zipper_pr_head objModel = new so_zipper_pr_head();
            objModel = setValue();//設置主表記錄

            List<so_zipper_pr_details> lsPms = new List<so_zipper_pr_details>();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    so_zipper_pr_details mdlDetail = new so_zipper_pr_details();

                    mdlDetail.id = id;
                    mdlDetail.mo_id = (dgvDetails.GetDataRow(i)["oc_mo_id"].ToString() != "" ? dgvDetails.GetDataRow(i)["oc_mo_id"].ToString().Trim() : "Z99999999");
                    mdlDetail.goods_id = (dgvDetails.GetDataRow(i)["oc_goods_id"].ToString() != "" ? dgvDetails.GetDataRow(i)["oc_goods_id"].ToString().Trim() : "");
                    mdlDetail.ap_qty = (dgvDetails.GetDataRow(i)["oc_order_qty"].ToString() != "" ? Convert.ToDecimal(dgvDetails.GetDataRow(i)["oc_order_qty"].ToString()) : 0);
                    mdlDetail.goods_unit = (dgvDetails.GetDataRow(i)["oc_goods_unit"].ToString() != "" ? dgvDetails.GetDataRow(i)["oc_goods_unit"].ToString().Trim() : "PCS");
                    mdlDetail.goods_name = (dgvDetails.GetDataRow(i)["oc_goods_name"].ToString() != "" ? dgvDetails.GetDataRow(i)["oc_goods_name"].ToString().Trim() : "");
                    mdlDetail.req_date = txtReq_date.Text.Trim();
                    mdlDetail.remark = txtPr_remark.Text.Trim();
                    mdlDetail.sec_unit = "KG";
                    mdlDetail.old_id = (dgvDetails.GetDataRow(i)["id"].ToString() != "" ? dgvDetails.GetDataRow(i)["id"].ToString().Trim() : "");
                    mdlDetail.old_sequence_id = (dgvDetails.GetDataRow(i)["sequence_id"].ToString() != "" ? dgvDetails.GetDataRow(i)["sequence_id"].ToString().Trim() : "");

                    lsPms.Add(mdlDetail);

                }
            }
            id = clsZipperOrder.insertToGeoPr(1,objModel, lsPms);
            if (id != "")
            {
                txtId.Text = id;
                MessageBox.Show("插入申購單記錄已成功!");
                findData();
            }
            else
                MessageBox.Show("插入申購單記錄失敗!");
        }
        private so_zipper_pr_head setValue()
        {
            string id = txtPr_id.Text.Trim();
            so_zipper_pr_head objModel = new so_zipper_pr_head();
            string now_time = System.DateTime.Now.ToString("yyyy-MM-dd HH:ss").Substring(11, 5);

            objModel.id = id;
            objModel.ap_date = txtPr_date.Text;
            objModel.beginning_time = objModel.ap_date + " " + now_time;
            objModel.end_time = Convert.ToDateTime(objModel.beginning_time).AddDays(7).ToString("yyyy-MM-dd") + " " + now_time;
            objModel.create_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:ss");
            objModel.dep = "J02";
            objModel.userid = userid;
            return objModel;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Trim() != "")
                loadOcData();
        }
        private void loadOcData()
        {
            DataTable dtOc = clsZipperOrder.loadOcData(txtMo_id.Text);
            if (dtOc.Rows.Count > 0)
            {
                DataRow row = dtOc.Rows[0];
                txtGoods_id.Text = row["goods_id"].ToString();
                txtGoods_name.Text = row["goods_name"].ToString();
                txtOrder_qty.Text = row["order_qty"].ToString();
                lueGoods_unit.EditValue = row["goods_unit"].ToString();
            }
            else
            {
                txtGoods_id.Text = "";
                txtGoods_name.Text = "";
                txtOrder_qty.Text = "";
                lueGoods_unit.EditValue = "";
            }
            txtSec_qty.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtPr_id.Text.Trim() != "" && !clsZipperOrder.checkGeoPrId(txtPr_id.Text.Trim()))
                return;
            insertToGeoPrOne();
        }
        private void insertToGeoPrOne()
        {
            if (!validData())
                return;
            string id = "";
            so_zipper_pr_head objModel = new so_zipper_pr_head();
            objModel = setValue();//設置主表記錄
            List<so_zipper_pr_details> lsPms = new List<so_zipper_pr_details>();
            so_zipper_pr_details mdlDetail = new so_zipper_pr_details();

            mdlDetail.id = txtPr_id.Text;
            mdlDetail.mo_id = txtMo_id.Text.Trim();
            mdlDetail.goods_id = txtGoods_id.Text.Trim();
            mdlDetail.ap_qty = (txtOrder_qty.Text.Trim() != "" ? Convert.ToDecimal(txtOrder_qty.Text) : 0);
            mdlDetail.goods_unit = (lueGoods_unit.EditValue.ToString() != "" ? lueGoods_unit.EditValue.ToString() : "PCS");
            mdlDetail.goods_name = txtGoods_name.Text.Trim();
            mdlDetail.req_date = txtReq_date.Text.Trim();
            mdlDetail.remark = txtPr_remark.Text.Trim();
            mdlDetail.sec_qty = (txtSec_qty.Text.Trim() != "" ? Convert.ToDecimal(txtSec_qty.Text) : 0);
            mdlDetail.sec_unit = "KG";

            lsPms.Add(mdlDetail);
            id = clsZipperOrder.insertToGeoPr(2,objModel, lsPms);
            if (id != "")
            {
                txtPr_id.Text = id;
                //MessageBox.Show("插入申購單記錄已成功!");
                loadGeoPr();
                
            }
            else
                MessageBox.Show("插入申購單記錄失敗!");
        }
        private bool validData()
        {
            if (txtOrder_qty.Text != "" && !clsValidRule.IsNumeric(txtOrder_qty.Text))
            {
                MessageBox.Show("申購數量格式不正確!");
                txtOrder_qty.Focus();
                return false;
            }
            if (txtSec_qty.Text != "" && !clsValidRule.IsNumeric(txtSec_qty.Text))
            {
                MessageBox.Show("申購重量格式不正確!");
                txtSec_qty.Focus();
                return false;
            }
            return true;
        }
        private void loadGeoPr()
        {
            DataTable dtPr = clsZipperOrder.loadGeoPr(txtPr_id.Text.Trim());
            gcPrDetails.DataSource= dtPr;
        }

        private void txtPr_id_Leave(object sender, EventArgs e)
        {
            if (txtPr_id.Text.Trim() != "")
                loadGeoPr();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrDetails.RowCount == 0)
            {
                MessageBox.Show("沒有要刪除的記錄!");
            }
            int i = dgvPrDetails.FocusedRowHandle;
            string id = (dgvPrDetails.GetDataRow(i)["id"].ToString() != "" ? dgvPrDetails.GetDataRow(i)["id"].ToString().Trim() : "");
            string sequence_id = (dgvPrDetails.GetDataRow(i)["sequence_id"].ToString() != "" ? dgvPrDetails.GetDataRow(i)["sequence_id"].ToString().Trim() : "");
            string sub_sequence_id = (dgvPrDetails.GetDataRow(i)["sub_sequence_id"].ToString() != "" ? dgvPrDetails.GetDataRow(i)["sub_sequence_id"].ToString().Trim() : "");
            if (clsZipperOrder.deleteGeoPrIdDetails(id, sequence_id, sub_sequence_id) > 0)
                loadGeoPr();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
