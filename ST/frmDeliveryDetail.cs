using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;

namespace cf01.ST
{
    public partial class frmDeliveryDetail : Form
    {
        private int BarCodeMinLength = 10;
        public frmDeliveryDetail()
        {
            InitializeComponent();
        }

        private void frmDeliveryDetail_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            //int fixedCount = 6; // 要固定的列数
            //for (int i = 0; i < fixedCount; i++)
            //{
            //    dgvDetails.Columns[i].Frozen = true;
            //}
            txtTransferDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            DataTable dtMoGroup = clsBaseData.LoadMoGroupAll("");
            cmbMoGroup.DataSource = dtMoGroup;
            cmbMoGroup.DisplayMember = "group_id";
            cmbMoGroup.ValueMember = "group_id";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                SaveMostly();

        }
        private void SaveMostly()
        {
            if (!ValidMostlyData())
                return;
            mdlDeliveryHead objMostly = new mdlDeliveryHead();
            objMostly.ID = txtDocId.Text;
            objMostly.transfer_date = txtTransferDate.Text;
            objMostly.id_type = cmbIdType.Text.Trim();
            objMostly.mo_group = cmbMoGroup.Text.Trim();
            objMostly.state = "0";
            string ID = clsDeliveryDetail.SaveMostly(objMostly);
            txtDocId.Text = ID;
        }
        private bool ValidMostlyData()
        {
            bool valid_flag = true;
            if (txtTransferDate.Text.Trim() == "/  /")
            {
                MessageBox.Show("轉出單日期不能為空!");
                txtTransferDate.Focus();
                valid_flag = false;
            }
            else if (cmbIdType.Text.Trim() == "")
            {
                MessageBox.Show("單據類型不能為空!");
                cmbIdType.Focus();
                valid_flag = false;
            }
            else if (cmbMoGroup.Text.Trim() == "")
            {
                MessageBox.Show("組別編號不能為空!");
                cmbMoGroup.Focus();
                valid_flag = false;
            }
            return valid_flag;
        }
        private void txtDocId_Leave(object sender, EventArgs e)
        {
            if (txtDocId.Text.ToString() != "")
                LoadMostlyData();
        }
        private void LoadMostlyData()
        {
            DataTable dtMostly = clsDeliveryDetail.LoadMostlyData(txtDocId.Text);
            FillMostlyData(dtMostly);
        }
        private void FillMostlyData(DataTable dtMostly)
        {
            if(dtMostly.Rows.Count>0)
            {
                DataRow drMostly = dtMostly.Rows[0];
                txtDocId.Text = drMostly["id"].ToString();
                cmbIdType.Text = drMostly["bill_type_no"].ToString();
                cmbMoGroup.Text = drMostly["group_no"].ToString();
                txtCreateDate.Text = drMostly["create_date"].ToString();
                txtCreateUser.Text = drMostly["create_by"].ToString();
                txtUpdateDate.Text = drMostly["update_date"].ToString();
                txtUpdateUser.Text = drMostly["update_by"].ToString();
                txtCheckDate.Text = drMostly["check_date"].ToString();
                txtCheckUser.Text = drMostly["check_by"].ToString();
                txtState.Text = drMostly["state"].ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text.Trim().Length > BarCodeMinLength)
                    doBarCode();
                txtBarCode.Text = "";
            }
        }
        private void doBarCode()
        {
            //掃描制單編號，物料編號
            string barcode = "";
            if (txtBarCode.Text.Trim().Length > 13)
                barcode = txtBarCode.Text.Substring(0, 13);
            else
                barcode = txtBarCode.Text.Trim();
            DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(barcode);
            txtBarCode.Text = "";
            if (dtBarCode.Rows.Count > 0)
            {
                string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                string goods_id = "";
                if (barcode_type == "2")//從生產計劃中提取的條形碼
                {
                    txtgoods_id.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                    txtmo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                    LoadGoodsData();
                }
                else
                {
                    //string doc = dtBarCode.Rows[0]["doc_id"].ToString();
                    //string seq = dtBarCode.Rows[0]["doc_seq"].ToString();
                    //DataTable dtTranMo = clsProductionSelect.GetPrdFromTransfer(barcode_type, doc, seq);
                    //if (dtTranMo.Rows.Count > 0)
                    //{
                    //    goods_id = dtTranMo.Rows[0]["goods_id"].ToString();
                    //    txtmo_id.Text = dtTranMo.Rows[0]["mo_id"].ToString();
                    //}
                }

            }
        }

        private void LoadGoodsData()
        {
            string mo_id = txtmo_id.Text;
            string goods_id=txtgoods_id.Text;
            DataTable dtOc = clsDeliveryDetail.LoadGoodsData(mo_id, goods_id);
            if(dtOc.Rows.Count>0)
            {
                DataRow drOc = dtOc.Rows[0];
                txtgoods_cname.Text = drOc["goods_cname"].ToString();
            }
        }
    }
}
