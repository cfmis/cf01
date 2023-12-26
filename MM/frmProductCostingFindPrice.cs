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
            if (modality=="2" || modality == "ML" || itemPart == "ML" || itemPart=="PL")//採購件
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
            }
            else if (xtcFind.SelectedTabPageIndex == 1)
            {
                lblMaterialId.Text = "物料/顏色編號:";
                lblMaterialName.Text = "物料/顏色描述:";
                lblDepId.Text = "部門編號:";
            }
            else if (xtcFind.SelectedTabPageIndex == 2)
            {
                lblMaterialId.Text = "顏色編號:";
                lblMaterialName.Text = "顏色描述:";
                lblDepId.Text = "顏色類別:";
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtDepId.Text.Trim() == "" && txtMaterialId.Text.Trim() == "" && txtMaterialName.Text.Trim() == "")
            {
                MessageBox.Show("請輸入查詢內容!");
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            bool result=selectFind(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if(result==false)
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
            DataTable dtMaterialPrice = clsProductCosting.findMaterialPrice("FIND",txtMaterialId.Text.Trim(),txtMaterialName.Text.Trim());
            dgvDetails1.DataSource = dtMaterialPrice;
            if (dgvDetails1.Rows.Count == 0)
                result = false;
            return result;
                
        }
        private bool findPlatePrice()
        {
            bool result = true;
            dtPlatePrice = clsProductCosting.findPlatePrice("",txtDepId.Text.Trim(),txtMaterialId.Text.Trim(), txtMaterialName.Text.Trim());
            dgvDetails2.DataSource = dtPlatePrice;
            if (dgvDetails2.Rows.Count == 0)
                result = false;
            return result;
        }
        private bool findPlateStdPrice()
        {
            bool result = true;
            dtPlateStdPrice = clsCountGoodsCost.FindPlateStdPrice("", txtDepId.Text.Trim(), txtMaterialId.Text.Trim(), txtMaterialName.Text.Trim());
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
        private void SetReturnValue(DataGridView dgv,DataTable dt)
        {
            float searchPrice = 0;
            float searchPriceWeg = 0;
            int rowIndex = dgv.CurrentRow.Index;
            DataRow dr = dt.Rows[rowIndex];
            searchPrice = clsValidRule.ConvertStrToSingle(dr["QtyPriceHKD"].ToString());
            searchPriceWeg = clsValidRule.ConvertStrToSingle(dr["WegPriceHKD"].ToString());
            getProductId = dr["goods_id"].ToString();
            getProductName = dr["do_color"].ToString();
            string qtyUnit = dr["p_unit"].ToString().Trim();
            string wegUnit = dr["sec_p_unit"].ToString().Trim();
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
            getDepId = dr["department_id"].ToString();// dgv.Rows[rowIndex].Cells["colPrdDep"].Value.ToString();
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
    }
}
