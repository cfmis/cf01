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
    public partial class frmZipperOrder_Find : Form
    {
        private string userid = DBUtility._user_id;
        private DataTable dtDgvDetails = new DataTable();
        public frmZipperOrder_Find()
        {
            InitializeComponent();
        }

        private void frmZipperOrder_Find_Load(object sender, EventArgs e)
        {
            //frmZipperOrder.query_id = "";
            //frmZipperOrder.query_seq = "";
            initControls();
        }
        private void initControls()
        {
            //組別
            DataTable dtGroup = clsZipperOrder.getGroup();
            lueMoGroup.Properties.DataSource = dtGroup;
            lueMoGroup.Properties.ValueMember = "mo_group";
            lueMoGroup.Properties.DisplayMember = "mo_group";

            //用戶組別
            DataTable dtUserGroup = clsZipperOrder.getUserGroup();
            if (dtUserGroup.Rows.Count > 0)
                lueMoGroup.EditValue = dtUserGroup.Rows[0]["mo_group"].ToString();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {

            if (clsValidRule.CheckDateIsEmpty(mtbOrder_date1.Text) == false || clsValidRule.CheckDateIsEmpty(mtbOrder_date2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(mtbOrder_date1.Text) == false || clsValidRule.CheckDateFormat(mtbOrder_date2.Text) == false)
                {
                    MessageBox.Show("訂單日期格式不正確!");
                    mtbOrder_date1.Focus();
                    return;
                }
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            findData(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            
        }
        private void findData()
        {
            string dat1 = "", dat2 = "";
            if (mtbOrder_date1.Text.Trim() != "/  /")
                dat1 = mtbOrder_date1.Text;
            if (mtbOrder_date2.Text.Trim() != "/  /")
                dat2 = Convert.ToDateTime(mtbOrder_date2.Text).AddDays(1).ToString("yyyy/MM/dd");
            string mo_group = (lueMoGroup.EditValue != "" ? lueMoGroup.EditValue.ToString() : "");
            int find_mo_flag = 0;//不從訂單中查找備註等資料
            dtDgvDetails = clsZipperOrder.findIdDetails(find_mo_flag,txtId.Text.Trim(), dat1, dat2, txtIt_customer.Text.Trim()
                                    , txtMo_id.Text.Trim(), txtGoods_id.Text.Trim(), txtCust_po.Text.Trim(), mo_group);
            gcDetails.DataSource = dtDgvDetails;
        }

        private void dgvDetails_DoubleClick(object sender, EventArgs e)
        {
            //returnValue();
        }
        private void returnValue()
        {
            frmZipperOrder.query_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "id").ToString();
            frmZipperOrder.query_seq = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id").ToString();
            this.Close();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            //clsZipperOrder.expToExcel(dtDgvDetails);
            clsZipperOrder.saveToExcel(dtDgvDetails);
        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                int i = dgvDetails.FocusedRowHandle;
                frmZipperOrder.query_id = (dgvDetails.GetDataRow(i)["id"].ToString() != "" ? dgvDetails.GetDataRow(i)["id"].ToString().Trim() : "");
            }
            else
                frmZipperOrder.query_id = "";
            frmZipperOrderToPr frmZipperOrderToPr = new frmZipperOrderToPr();
            frmZipperOrderToPr.ShowDialog();
            frmZipperOrderToPr.Dispose();
        }

        private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = dgvDetails.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    returnValue();
                }
            }  
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            returnValue();
            
        }

        private void saveDetails()
        {
            txtId.Focus();
            if (!validDetails())
                return;
            DataTable dtIdDetails = new DataTable();
            string id = "", sequence_id = "";
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    id = dgvDetails.GetDataRow(i)["id"].ToString();
                    sequence_id = dgvDetails.GetDataRow(i)["sequence_id"].ToString();
                    dtIdDetails = clsZipperOrder.loadIdSeqDetails(id, sequence_id);
                    if (dtIdDetails.Rows.Count > 0)
                    {
                        DataRow row = dtIdDetails.Rows[0];
                        so_zipper_order_details objModel = new so_zipper_order_details();
                        objModel.id = frmZipperOrder.query_id;
                        objModel.sequence_id = "";
                        objModel.prd_seq = "";
                        objModel.mo_group = frmZipperOrder.query_id.Substring(0, 1);
                        objModel.mo_id = row["mo_id"].ToString();
                        objModel.goods_id = row["goods_id"].ToString();
                        objModel.order_qty = 0;
                        objModel.sample_qty = 0;
                        objModel.goods_unit = (row["goods_unit"].ToString() != "" ? row["goods_unit"].ToString() : "");
                        objModel.mat_type = (row["mat_type"].ToString() != "" ? row["mat_type"].ToString() : "");
                        objModel.spec_id = (row["spec_id"].ToString() != "" ? row["spec_id"].ToString() : "");
                        objModel.spec_oth = row["spec_oth"].ToString();
                        objModel.cust_goods_style = row["cust_goods_style"].ToString();
                        objModel.color_c = row["color_c"].ToString();
                        objModel.color_y = row["color_y"].ToString();
                        objModel.color_oth = row["color_oth"].ToString();
                        objModel.manu_craft_group = (row["manu_craft_group"].ToString() != "" ? row["manu_craft_group"].ToString() : "");
                        objModel.manu_craft_id = (row["manu_craft_id"].ToString() != "" ? row["manu_craft_id"].ToString() : "");
                        objModel.manu_craft_cdesc = row["manu_craft_cdesc"].ToString();
                        objModel.manu_craft_oth = row["manu_craft_oth"].ToString();
                        objModel.prd_process_id = (row["prd_process_id"].ToString() != "" ? row["prd_process_id"].ToString() : "");
                        objModel.prd_process_cdesc = row["prd_process_cdesc"].ToString();
                        objModel.prd_process_oth = row["prd_process_oth"].ToString();
                        objModel.prd_process_color = row["prd_process_color"].ToString();
                        objModel.prd_process_id1 = (row["prd_process_id1"].ToString() != "" ? row["prd_process_id1"].ToString() : "");
                        objModel.prd_process_cdesc1 = row["prd_process_cdesc1"].ToString();
                        objModel.prd_process_oth1 = row["prd_process_oth1"].ToString();
                        objModel.prd_process_color1 = row["prd_process_color1"].ToString();
                        objModel.zipper_head = (row["zipper_head"].ToString() != "" ? row["zipper_head"].ToString() : "");
                        objModel.zipper_head_oth = row["zipper_head_oth"].ToString();
                        if (objModel.mat_type == "ME")
                        {
                            objModel.naked_select = (row["naked_select"].ToString() != "" ? row["naked_select"].ToString() : "");
                            objModel.naked_cdesc = (row["naked_cdesc"].ToString() != "" ? row["naked_cdesc"].ToString() : "");
                            objModel.zipper_tooth = (row["zipper_tooth"].ToString() != "" ? row["zipper_tooth"].ToString() : "");
                            objModel.zipper_color = (row["zipper_color"].ToString() != "" ? row["zipper_color"].ToString() : "");
                            objModel.zipper_color_oth = row["zipper_color_oth"].ToString();
                        }
                        else
                        {
                            objModel.naked_select = "";
                            objModel.naked_cdesc = "";
                            objModel.zipper_tooth = "";
                            objModel.zipper_color = "";
                            objModel.zipper_color_oth = "";
                        }
                        objModel.pull_card_no = row["pull_card_no"].ToString();
                        objModel.pull_card_color_id = row["pull_card_color_id"].ToString();
                        objModel.pull_card_color = row["pull_card_color"].ToString();
                        objModel.test_std = (row["test_std"].ToString() != "" ? row["test_std"].ToString() : "");
                        objModel.test_std_cdesc = row["test_std_cdesc"].ToString();
                        objModel.prd_use = (row["prd_use"].ToString() != "" ? row["prd_use"].ToString() : "");
                        objModel.prd_use_oth = row["prd_use_oth"].ToString();
                        objModel.cloth_type = row["cloth_type"].ToString();
                        objModel.size = row["size"].ToString();
                        objModel.size_unit = row["size_unit"].ToString();
                        objModel.size_cm = row["size_cm"].ToString();
                        objModel.size_inc = row["size_inc"].ToString();
                        objModel.size_diff = (row["size_diff"].ToString() != "" ? row["size_diff"].ToString() : "");
                        objModel.size_diff_oth = row["size_diff_oth"].ToString();
                        objModel.pack_type = (row["pack_type"].ToString() != "" ? row["pack_type"].ToString() : "");
                        objModel.pack_type_oth = row["pack_type_oth"].ToString();
                        objModel.wash_type = (row["wash_type"].ToString() != "" ? row["wash_type"].ToString() : "");
                        objModel.wash_type_oth = row["wash_type_oth"].ToString();
                        objModel.remark1 = row["remark1"].ToString();
                        objModel.remark2 = row["remark2"].ToString();
                        objModel.crusr = userid;
                        objModel.crtim = System.DateTime.Now;
                        string result = clsZipperOrder.addSo_zipper_order_details(true, objModel);
                        if (result != "")
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
        private bool validDetails()
        {
            bool result = false;
            if (clsZipperOrder.checkExistId(frmZipperOrder.query_id) == false)
            {
                MessageBox.Show("單據編號不存在，不能儲存!");
                return false;
            }
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            saveDetails();
        }
    }
}
