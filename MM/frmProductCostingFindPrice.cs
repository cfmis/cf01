using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Forms;
using System.Threading;

namespace cf01.MM
{
    public partial class frmProductCostingFindPrice : Form
    {
        public static string getDepId = "";
        public static string getProductId = "";
        public static string getProductName = "";
        public static string modality = "";
        DataTable dtPlatePrice = new DataTable();
        DataTable dtPlateStdPrice = new DataTable();

        frmProcessBarWindows processBarWindows;
        int progressBar_Cnt2 = 0;
        int Coun = 100;
        int pausCnt = 20;

        public frmProductCostingFindPrice()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductCostingFindPrice_Load(object sender, EventArgs e)
        {
            dgvDetails1.AutoGenerateColumns = false;
            dgvDetails2.AutoGenerateColumns = false;
            dgvDetails3.AutoGenerateColumns = false;
            txtDepId.Text = getDepId;
            txtMaterialId.Text = getProductId;
            txtMaterialName.Text = getProductName;
            string itemPart = "";
            if (txtMaterialId.Text.Trim().Length > 2)
                itemPart = txtMaterialId.Text.Substring(0, 2);
            if (modality == "2" || modality == "ML" || itemPart == "ML" || itemPart == "PL")//採購件
                xtcFind.SelectedTabPageIndex = 0;
            else
            {
                xtcFind.SelectedTabPageIndex = 2;
                //if (txtDepId.Text == "501" || txtDepId.Text == "510")
                //    xtcFind.SelectedTabPageIndex = 1;
            }
            SetTextDesc();
            //selectFind();
            //if (getProductId != "")
            //    btnFind_Click(sender, e);
        }

        private void SetTextDesc()
        {
            if (xtcFind.SelectedTabPageIndex == 0)
            {
                lblMaterialId.Text = "物料編號:";
                lblMaterialName.Text = "物料描述:";
                lblDepId.Text = "部門編號:";
                txtMaterialId.Visible = true;
                cmbPlateProcess.Visible = false;
                cmbPlateType.Visible = false;
                txtDepId.Visible = true;
            }
            else if (xtcFind.SelectedTabPageIndex == 1)
            {
                lblMaterialId.Text = "物料/顏色編號:";
                lblMaterialName.Text = "物料/顏色描述:";
                lblDepId.Text = "部門編號:";
                txtMaterialId.Visible = true;
                cmbPlateProcess.Visible = false;
                cmbPlateType.Visible = false;
                txtDepId.Visible = true;
            }
            else if (xtcFind.SelectedTabPageIndex == 2)
            {
                lblMaterialId.Text = "電鍍方法:";
                lblMaterialName.Text = "顏色描述:";
                lblDepId.Text = "顏色類別:";
                txtMaterialId.Visible = false;
                cmbPlateProcess.Visible = true;
                cmbPlateType.Visible = true;
                txtDepId.Visible = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //if (txtDepId.Text.Trim() == "" && txtMaterialId.Text.Trim() == "" && txtMaterialName.Text.Trim() == "" && cmbPlateProcess.Text.Trim() == "")
            //{
            //    MessageBox.Show("請輸入查詢內容!");
            //    return;
            //}
            progressBar_Cnt2 = 0;
            processBarWindows = new frmProcessBarWindows(0, Coun, "正在儲存數據，請稍候。。。");

            ShowProcessBar();

            //**********************
            bool result = selectFind(); //数据处理

            HideProcessBar();

            if (result == false)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private bool selectFind()
        {
            bool result = true;
            if (xtcFind.SelectedTabPageIndex == 0)
                findMaterialPrice();
            else if (xtcFind.SelectedTabPageIndex == 1)
                findPlatePrice();
            else if (xtcFind.SelectedTabPageIndex == 2)
                findPlateStdPrice();
            return result;
        }
        private bool findMaterialPrice()
        {
            bool result = true;
            DataTable dtMaterialPrice = clsProductCosting.findMaterialPrice("FIND", txtMaterialId.Text.Trim(), txtMaterialName.Text.Trim());
            dgvDetails1.DataSource = dtMaterialPrice;
            if (dgvDetails1.Rows.Count == 0)
                result = false;
            return result;

        }
        private bool findPlatePrice()
        {
            bool result = true;
            dtPlatePrice = clsProductCosting.findPlatePrice("", txtDepId.Text.Trim(), cmbPlateProcess.Text.Trim(), txtMaterialName.Text.Trim());
            dgvDetails2.DataSource = dtPlatePrice;
            if (dgvDetails2.Rows.Count == 0)
                result = false;
            return result;
        }
        private bool findPlateStdPrice()
        {
            bool result = true;
            string vendor_id = "";
            if (chkJx.Checked == true)
                vendor_id = "CL-K0036";
            int recPrice = 1;
            if (chkRec.Checked == false)
                recPrice = 0;
            dtPlateStdPrice = clsCountGoodsCost.FindPlateStdPrice(recPrice,vendor_id, cmbPlateType.Text.Trim(), cmbPlateProcess.Text.Trim(), txtMaterialName.Text.Trim());
            dgvDetails3.DataSource = dtPlateStdPrice;
            if (dgvDetails3.Rows.Count == 0)
                result = false;
            return result;
        }
        private void dgvDetails1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            float searchPrice = 0;
            if (modality == "ML")
            {
                getProductId = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colGoodsID"].Value.ToString();
                getProductName = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colGoodsName"].Value.ToString();
                searchPrice = clsValidRule.ConvertStrToSingle(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colPriceHKD"].Value.ToString());
                frmCountGoodsCost.searchPrice = searchPrice;
            }
            else
            {
                searchPrice = clsValidRule.ConvertStrToSingle(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colMaterialPriceHkd"].Value.ToString());
                frmProductCosting.searchPrice = Convert.ToDecimal(searchPrice);
            }

            this.Close();
        }

        private void dgvDetails2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modality == "PLATE")
            {
                SetReturnValue(dgvDetails2, dtPlatePrice);
            }
            else
            {
                frmProductCosting.searchPrice = dgvDetails2.Rows[dgvDetails2.CurrentRow.Index].Cells["colPlatePriceKg"].Value.ToString() != ""
                ? Convert.ToDecimal(dgvDetails2.Rows[dgvDetails2.CurrentRow.Index].Cells["colPlatePriceKg"].Value) : 0;
                frmProductCosting.searchPricePcs = dgvDetails2.Rows[dgvDetails2.CurrentRow.Index].Cells["colPricePcs"].Value.ToString() != ""
                    ? Convert.ToDecimal(dgvDetails2.Rows[dgvDetails2.CurrentRow.Index].Cells["colPricePcs"].Value) : 0;
            }
            this.Close();
        }
        private void SetReturnValue(DataGridView dgv, DataTable dt)
        {
            float searchPrice = 0;
            float searchPriceWeg = 0;
            int rowIndex = dgv.CurrentRow.Index;
            //DataRow dr = dt.Rows[rowIndex];//
            DataGridViewRow dgvDr = dgv.Rows[rowIndex];
            searchPrice = clsValidRule.ConvertStrToSingle(dgvDr.Cells["colPlateQtyPriceHKD"].Value.ToString()); //clsValidRule.ConvertStrToSingle(dr["QtyPriceHKD"].ToString());
            searchPriceWeg = clsValidRule.ConvertStrToSingle(dgvDr.Cells["colPlateWegPriceHKD"].Value.ToString());
            getProductId = dgvDr.Cells["colColorId"].Value.ToString();
            getProductName = dgvDr.Cells["colPlateDoColor"].Value.ToString(); //dr["do_color"].ToString();
            string qtyUnit = dgvDr.Cells["colPlateUnitPCS"].Value.ToString();
            string wegUnit = dgvDr.Cells["colPlateUnitKG"].Value.ToString();
            frmCountGoodsCost.getVendID = dgvDr.Cells["colPlateVendId"].Value.ToString();
            frmCountGoodsCost.getVendName = dgvDr.Cells["colPlateVendName"].Value.ToString();
            frmCountGoodsCost.getQuoID = dgvDr.Cells["colPlateQuoId"].Value.ToString();
            frmCountGoodsCost.getQuoDate = dgvDr.Cells["colPlateQuoDate"].Value.ToString();
            //searchPrice = clsValidRule.ConvertStrToSingle(dgv.Rows[rowIndex].Cells["colQtyPriceHKD"].Value.ToString());
            //searchPriceWeg = clsValidRule.ConvertStrToSingle(dgv.Rows[rowIndex].Cells["colWegPriceHKD"].Value.ToString());
            //getProductId = dgv.Rows[rowIndex].Cells["colProductID"].Value.ToString().Substring(14, 4);
            //getProductName = dgv.Rows[rowIndex].Cells["colDoColor"].Value.ToString();
            //string qtyUnit = dgv.Rows[rowIndex].Cells["colQtyUnit"].Value.ToString().Trim();
            //string wegUnit = dgv.Rows[rowIndex].Cells["colWegUnit"].Value.ToString().Trim();
            frmCountGoodsCost.searchPrice = searchPrice;
            frmCountGoodsCost.searchPriceWeg = searchPriceWeg;
            frmCountGoodsCost.searchPriceQtyUnit = qtyUnit;
            frmCountGoodsCost.searchPriceWegUnit = wegUnit;
            getDepId = "";// dr["department_id"].ToString();// dgv.Rows[rowIndex].Cells["colPrdDep"].Value.ToString();
            //////有些是入錯單位的，在數量那裡入了重量單價了，轉換回重量那裡
            if (qtyUnit == "KG" && searchPrice != 0 && searchPriceWeg == 0)
            {
                frmCountGoodsCost.searchPrice = 0;
                frmCountGoodsCost.searchPriceWeg = searchPrice;
                frmCountGoodsCost.searchPriceQtyUnit = "";
                frmCountGoodsCost.searchPriceWegUnit = qtyUnit;
            }
        }
        private void dgvDetails3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetReturnValue(dgvDetails3, dtPlateStdPrice);
            this.Close();
        }

        private void xtcFind_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            SetTextDesc();
        }

        private void dgvDetails3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int rowIndex = dgvDetails3.CurrentRow.Index;
            //MessageBox.Show(rowIndex.ToString());

        }

        private void ShowProcessBar()
        {
            processBarWindows.Show(this);//设置父窗体
            for (int i = 0; i <= pausCnt; i++)
            {
                progressBar_Cnt2++;
                processBarWindows.setPos(progressBar_Cnt2);//设置进度条位置
                Thread.Sleep(10);
            }
        }
        private void HideProcessBar()
        {
            for (int i = pausCnt; i < Coun; i++)
            {

                progressBar_Cnt2++;
                processBarWindows.setPos(progressBar_Cnt2);//设置进度条位置
                if (progressBar_Cnt2 >= Coun)
                {
                    //Thread.Sleep(1000);
                    processBarWindows.Close();

                }
            }
        }

        private void chkJx_Click(object sender, EventArgs e)
        {
            this.chkRec.Checked = false;
        }
    }
}
