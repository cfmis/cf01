using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.MDL;
using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraGrid.Views.Base;

namespace cf01.MM
{
    public partial class frmCountGoodsCost : Form
    {
        private DataTable dtGoodsPartDetails = new DataTable();
        private DataTable dtPurPrice = new DataTable();
        private DataTable dtMat = new DataTable();
        private DataTable dtProcess = new DataTable();
        private DataTable dtPlate = new DataTable();
        private DataTable dtPack = new DataTable();
        private DataTable dtFactory = new DataTable();
        private int newMode = 0;
        private int newPartMode = 0;
        private float baseQtyRate = 1000;
        public static string getID = "";
        public static float searchPrice = 0;
        public static float searchPriceWeg = 0;
        public static string searchPriceQtyUnit = "";
        public static string searchPriceWegUnit = "";
        public frmCountGoodsCost()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtID.ReadOnly = true;
            newMode = 1;
            LoadDataHead("ZZZZZZ");
            LoadGoodsPartToGrid(999999999);
            txtTestQty.Text = "";
            ShowProductCost();
            //////默認新增配件
            LoadProductCostPart("ZZZ");
            CleanProductCostPart();
            //////清空配件中的記錄
            FillGoodsPart();
            LoadGoodsDetails();
            SumTotalCost();
        }
        private void LoadDataHead(string ID)
        {
            if (ID == "")
                return;
            txtID.ReadOnly = false;
            DataTable dtProductCost = clsCountGoodsCost.LoadProductCostHead(ID);
            if (dtProductCost.Rows.Count > 0)
            {
                DataRow dr = dtProductCost.Rows[0];
                txtProductId.Text = dr["ProductID"].ToString();
                txtProductName.Text= dr["ProductName"].ToString();
                txtArtWork.Text = dr["ArtWork"].ToString();
                txtArtWorkName.Text = dr["ArtWorkName"].ToString();
                txtProductType.Text = dr["ProductType"].ToString();
                txtProductTypeName.Text = dr["ProductTypeName"].ToString();
                txtSize.Text = dr["ProductSize"].ToString();
                txtSizeName.Text = dr["ProductSizeName"].ToString();
                txtColor.Text = dr["ProductColor"].ToString();
                txtColorName.Text = dr["ProductColorName"].ToString();
                txtRemark.Text = dr["Remark"].ToString();
                txtCreateUser.Text = dr["CreateUser"].ToString();
                txtCreateTime.Text = dr["CreateTime"].ToString();
                txtAmendUser.Text = dr["AmendUser"].ToString();
                txtAmendTime.Text = dr["AmendTime"].ToString();
                txtSN.Text = dr["SN"].ToString();
                txtVer.Text = dr["Ver"].ToString();
            }
            else
            {
                txtProductId.Text = "";
                txtProductName.Text = "";
                txtArtWork.Text = "";
                txtArtWorkName.Text = "";
                txtProductType.Text = "";
                txtProductTypeName.Text = "";
                txtSize.Text = "";
                txtSizeName.Text = "";
                txtColor.Text = "";
                txtColorName.Text = "";
                txtCreateUser.Text = "";
                txtCreateTime.Text = "";
                txtAmendUser.Text = "";
                txtAmendTime.Text = "";
                txtSN.Text = "";
                txtVer.Text = "0";
                txtRemark.Text = "";
            }
            //LoadPrdSizeGroup();
            //LoadColorGroup(0);
            //LoadColorDetails();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtc1.SelectedTabPage == xtp1)
            {
                //if (newMode == 0)
                //{
                //    MessageBox.Show("主表為非編輯狀態，請點擊新增!");
                //    return;
                //}
                SaveProductCostHead();
                SavePorductPart();//儲存配件列表
                SavePurPrice();//儲存意向報價表
                LoadData();
                MessageBox.Show("主表記錄儲存成功!");
            }else
            {
                SaveProductPartDetails();
            }
        }
        /// <summary>
        /// ///點擊儲存時，儲存第二個Tab中的所有項目
        /// </summary>
        private void SaveProductPartDetails()
        {
            if (txtSN.Text.Trim() == "")
                SaveProductCostHead();
            SavePorductCostPart();
            SaveProductCostMat();//保存原料
            SaveGoodsCostProcess(dtProcess, "01");//保存部門加工費
            SaveGoodsCostProcess(dtPlate, "02");//保存外發加工費
            SaveGoodsCostProcess(dtPack, "03");//保存包裝費用
            SaveGoodsCostProcess(dtFactory, "04");//保存工廠皮費用
            newPartMode = 0;
            LoadGoodsDetails();//刷新、提取各種費用詳細
            MessageBox.Show("配件記錄儲存成功!");
        }
        private void SaveProductCostHead()
        {
            //if (txtProductType.Text.Trim() == "" && txtArtWork.Text.Trim() == "")
            //{
            //    MessageBox.Show("沒有儲存的記錄!");
            //    return;
            //}
            mdlCountGoodsCost mdlGoods = new mdlCountGoodsCost();
            mdlGoods.ID = txtID.Text.Trim();
            mdlGoods.Ver = txtVer.Text == "" ? 0 : Convert.ToInt32(txtVer.Text);
            mdlGoods.ProductID = txtProductId.Text;
            mdlGoods.ProductName = txtProductName.Text;
            mdlGoods.ArtWork = txtArtWork.Text;
            mdlGoods.ArtWorkName = txtArtWorkName.Text;
            mdlGoods.ProductType = txtProductType.Text;
            mdlGoods.ProductTypeName = txtProductTypeName.Text;
            mdlGoods.ProductColor = txtColor.Text;
            mdlGoods.ProductColorName = txtColorName.Text;
            mdlGoods.ProductSize = txtSize.Text;
            mdlGoods.ProductSizeName = txtSizeName.Text;
            mdlGoods.Remark = txtRemark.Text;
            string result = clsCountGoodsCost.Save(mdlGoods);
            txtID.Text = result;
            txtID.ReadOnly = false;
            newMode = 0;
            LoadDataHead(txtID.Text.Trim());
        }

        /// <summary>
        /// ///主表中儲存配件記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void SavePorductPart()
        {
            if(txtSN.Text.Trim()=="")
            {
                MessageBox.Show("主表記錄編號不存在，儲存無效!");
                return;
            }
            List<mdlCountGoodsCostPart> lsCountGoodsCostPart = new List<mdlCountGoodsCostPart>();
            for (int i = 0; i < dtGoodsPartDetails.Rows.Count; i++)
            {
                DataRow dr = dtGoodsPartDetails.Rows[i];
                mdlCountGoodsCostPart mdlGoodsPpart = new mdlCountGoodsCostPart();
                mdlGoodsPpart.UpperSN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
                mdlGoodsPpart.Seq = "";
                mdlGoodsPpart.ProductID = dr["ProductID"].ToString();
                mdlGoodsPpart.ProductName = dr["ProductName"].ToString();
                mdlGoodsPpart.FrontPart= dr["FrontPart"].ToString();
                //mdlGoodsPpart.ArtWork = txtArtWorkPart.Text;
                //mdlGoodsPpart.ArtWorkName = txtArtWorkNamePart.Text;
                //mdlGoodsPpart.ProductType = txtProductTypePart.Text;
                //mdlGoodsPpart.ProductTypeName = txtProductTypeNamePart.Text;
                //mdlGoodsPpart.ProductColor = txtColorPart.Text;
                //mdlGoodsPpart.ProductColorName = txtColorNamePart.Text;
                //mdlGoodsPpart.ProductSize = txtSizePart.Text;
                //mdlGoodsPpart.ProductSizeName = txtSizeNamePart.Text;
                //mdlGoodsPpart.MatWeg = clsValidRule.ConvertStrToSingle(txtMatWegTotal.Text);
                //mdlGoodsPpart.MatUse = clsValidRule.ConvertStrToSingle(txtMatUseTotal.Text);
                //mdlGoodsPpart.MatCost = clsValidRule.ConvertStrToSingle(txtMatCostTotal.Text);
                //mdlGoodsPpart.ProcessCostTotal = clsValidRule.ConvertStrToSingle(txtProcessCostTotal.Text);
                mdlGoodsPpart.ProcessProfitRate = 30;// clsValidRule.ConvertStrToSingle(txtProcessProfitRate.Text);
                //mdlGoodsPpart.ProcessProfit = clsValidRule.ConvertStrToSingle(txtProcessProfit.Text);
                //mdlGoodsPpart.PlateCost = clsValidRule.ConvertStrToSingle(txtPlateCostTotal.Text);
                //mdlGoodsPpart.PackCost = clsValidRule.ConvertStrToSingle(txtPackCostTotal.Text);
                //mdlGoodsPpart.CostPcs = clsValidRule.ConvertStrToSingle(txtCostPcs.Text);
                //mdlGoodsPpart.CostGrs = clsValidRule.ConvertStrToSingle(txtCostGrs.Text);
                //mdlGoodsPpart.CostK = clsValidRule.ConvertStrToSingle(txtCostK.Text);
                //mdlGoodsPpart.FactoryFee = clsValidRule.ConvertStrToSingle(txtFactoryCostTotal.Text);
                //mdlGoodsPpart.FactoryCostPcs = clsValidRule.ConvertStrToSingle(txtFactoryCostPcs.Text);
                //mdlGoodsPpart.FactoryCostGrs = clsValidRule.ConvertStrToSingle(txtFactoryCostGrs.Text);
                //mdlGoodsPpart.FactoryCostK = clsValidRule.ConvertStrToSingle(txtFactoryCostK.Text);
                //mdlGoodsPpart.Remark = "";
                lsCountGoodsCostPart.Add(mdlGoodsPpart);
            }
            string result = "";
            if (lsCountGoodsCostPart.Count > 0)
                result = clsCountGoodsCost.SaveGoodsPartBatch(lsCountGoodsCostPart);
            //txtSeqPart.Text = result;

            //LoadProductCostPart(result);
        }
        private void frmCountGoodsCost_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            txtProfitRate.Text = "30";//////加工費利潤率
            //gcMatDetails.DataSource = dtMat;
            //gcGoodsProcess.DataSource = dtProcess;

            lueTestUnit.Properties.DataSource = clsBs_Unit.LoadUnit("0");
            lueTestUnit.Properties.ValueMember = "unit_id";
            lueTestUnit.Properties.DisplayMember = "unit_cdesc";
            lueTestUnit.Text = "PCS";

            repositoryItemLookUpEdit2.DataSource = clsBs_Unit.LoadUnit("");
            repositoryItemLookUpEdit2.ValueMember = "unit_id";
            repositoryItemLookUpEdit2.DisplayMember = "unit_cdesc";

            repositoryItemLookUpEdit10.DataSource = clsBs_Unit.LoadUnit("");
            repositoryItemLookUpEdit10.ValueMember = "unit_id";
            repositoryItemLookUpEdit10.DisplayMember = "unit_cdesc";
            //////原料表格中綁定原料
            repositoryItemLookUpEdit23.DataSource = clsBaseData.LoadProcessType("MAT_CODE", "");
            repositoryItemLookUpEdit23.ValueMember = "process_id";
            repositoryItemLookUpEdit23.DisplayMember = "process_name";
            //////加工費的部門
            repositoryItemLookUpEdit11.DataSource = clsBaseData.loadDep();
            repositoryItemLookUpEdit11.ValueMember = "dep_id";
            repositoryItemLookUpEdit11.DisplayMember = "dep_cdesc";
            //////外發加工的部門
            repositoryItemLookUpEdit12.DataSource = clsBaseData.LoadSpecDep("5", "599");
            repositoryItemLookUpEdit12.ValueMember = "dep_id";
            repositoryItemLookUpEdit12.DisplayMember = "dep_cdesc";
            //////外發加工數量單位
            luePlateQtyUnit.DataSource = clsBs_Unit.LoadUnit("0");
            luePlateQtyUnit.ValueMember = "unit_id";
            luePlateQtyUnit.DisplayMember = "unit_cdesc";
            //////外發加工數量單位
            luePlateWegUnit.DataSource = clsBs_Unit.LoadUnit("1");
            luePlateWegUnit.ValueMember = "unit_id";
            luePlateWegUnit.DisplayMember = "unit_cdesc";

            //////包裝物料費用
            repositoryItemLookUpEdit24.DataSource = clsBaseData.LoadProcessType("PK_FEE", "");
            repositoryItemLookUpEdit24.ValueMember = "process_id";
            repositoryItemLookUpEdit24.DisplayMember = "process_name";
        }

        private void CountTestCost()
        {
            float unitRate = 0;
            unitRate = clsBaseData.GetUnitRate(lueTestUnit.Text.Trim());
            float Qty = clsValidRule.ConvertStrToSingle(txtTestQty.Text);
            float profitRate = clsValidRule.ConvertStrToSingle(txtProfitRate.Text) / 100;
            txtSalePricePcs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProductCostPcs.Text) * (1 + profitRate), 4).ToString();
            txtSalePriceGrs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProductCostGrs.Text) * (1 + profitRate), 2).ToString();
            txtSalePriceK.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProductCostK.Text) * (1 + profitRate), 2).ToString();
            double baseAmt = Math.Round((Qty * unitRate) * clsValidRule.ConvertStrToSingle(txtProductCostPcs.Text), 2);
            txtProfitAmt.Text=Math.Round(baseAmt * (1 + profitRate), 2).ToString();
            //float purRate = clsValidRule.ConvertStrToSingle(txtPurRate.Text) / 100;
            //txtPurPricePcs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtSalePricePcs.Text) * (1 + purRate), 4).ToString();
            //txtPurPriceGrs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtSalePriceGrs.Text) * (1 + purRate), 4).ToString();
            //txtPurPriceK.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtSalePriceK.Text) * (1 + purRate), 4).ToString();
            //txtPurAmt.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProfitAmt.Text) * (1 + purRate), 2).ToString();
        }
        private void LoadData()
        {
            string ID = txtID.Text.Trim() != "" ? txtID.Text.Trim() : "ZZZZZZZZZ";
            LoadDataHead(ID);
            int SN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : -999;
            LoadGoodsPartToGrid(SN);
            LoadPurPriceDetails(SN);
            ShowProductCost();
        }
        private void txtID_Leave(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadGoodsPartToGrid(int SN)
        {
            //int SN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : 0;
            dtGoodsPartDetails = clsCountGoodsCost.LoadProductCostPart(SN, "");
            gcGoodsPartDetails.DataSource = dtGoodsPartDetails;
        }

        /// <summary>
        /// ///提取意向報價
        /// 如果不存在的默認添加10行空記錄
        /// 點擊查詢時執行
        /// </summary>
        /// <param name="SN"></param>
        private void LoadPurPriceDetails(int SN)
        {
            //////提取外發加工費
            dtPurPrice = clsCountGoodsCost.LoadPurPriceDetails(SN);
            gcPurPriceDetails.DataSource = dtPurPrice;
            if (dtPurPrice.Rows.Count == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    DataRow Row = dtPurPrice.Rows.Add();
                }
            }
        }
        /// <summary>
        /// ///顯示整套產品的成本
        /// </summary>
        private void ShowProductCost()
        {
            float costPCS = 0;
            float costGRS = 0;
            float costK = 0;
            for (int i = 0; i < dtGoodsPartDetails.Rows.Count; i++)
            {
                DataRow dr = dtGoodsPartDetails.Rows[i];
                costPCS += clsValidRule.ConvertStrToSingle(dr["FactoryCostPcs"].ToString());
                costGRS += clsValidRule.ConvertStrToSingle(dr["FactoryCostGrs"].ToString());
                costK += clsValidRule.ConvertStrToSingle(dr["FactoryCostK"].ToString());
            }
            txtProductCostPcs.Text = costPCS.ToString();
            txtProductCostGrs.Text = costGRS.ToString();
            txtProductCostK.Text = costK.ToString();
            CountTestCost();
        }
        /// <summary>
        /// ///點擊新增配件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            LoadProductCostPart("ZZZ");
            CleanProductCostPart();
            SumTotalCost();
        }
        private void CleanProductCostPart()
        {
            for(int i=0;i<dtMat.Rows.Count;i++)
            {
                dtMat.Rows[i]["Seq"] = "";
            }
            for (int i = 0; i < dtProcess.Rows.Count; i++)
            {
                dtProcess.Rows[i]["Seq"] = "";
            }
            for (int i = 0; i < dtPlate.Rows.Count; i++)
            {
                dtPlate.Rows[i]["Seq"] = "";
            }
            for (int i = 0; i < dtPack.Rows.Count; i++)
            {
                dtPack.Rows[i]["Seq"] = "";
            }
            for (int i = 0; i < dtFactory.Rows.Count; i++)
            {
                dtFactory.Rows[i]["Seq"] = "";
            }
            txtMatWegTotal.Text = "0";
            txtMatUseTotal.Text = "0";
            txtMatCostTotal.Text = "0";
            txtProcessCostTotal.Text = "0";
            txtProcessProfitRate.Text = "0";
            txtProcessProfit.Text = "0";
            txtPlateCostTotal.Text = "0";
            txtPackCostTotal.Text = "0";
            txtCostPcs.Text = "0";
            txtCostGrs.Text = "0";
            txtCostK.Text = "0";
            txtFactoryCostTotal.Text = "0";
            txtFactoryCostPcs.Text = "0";
            txtFactoryCostGrs.Text = "0";
            txtFactoryCostK.Text = "0";
        }
        private void LoadProductCostPart(string seq)
        {
            if (txtID.Text == "")
                return;
            int SN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : -999;
            DataTable dtGoodsPart = clsCountGoodsCost.LoadProductCostPart(SN, seq);
            if (dtGoodsPart.Rows.Count > 0)
            {
                DataRow dr = dtGoodsPart.Rows[0];
                txtProductIdPart.Text = dr["ProductID"].ToString();
                txtProductNamePart.Text = dr["ProductName"].ToString();
                txtArtWorkPart.Text = dr["ArtWork"].ToString();
                txtArtWorkNamePart.Text = dr["ArtWorkName"].ToString();
                txtProductTypePart.Text = dr["ProductType"].ToString();
                txtProductTypeNamePart.Text = dr["ProductTypeName"].ToString();
                txtSizePart.Text = dr["ProductSize"].ToString();
                txtSizeNamePart.Text = dr["ProductSizeName"].ToString();
                txtColorPart.Text = dr["ProductColor"].ToString();
                txtColorNamePart.Text = dr["ProductColorName"].ToString();
                txtCostPcs.Text = dr["CostPcs"].ToString();
                txtCostGrs.Text = dr["CostGrs"].ToString();
                txtCostK.Text = dr["CostK"].ToString();
                txtSNPart.Text = dr["SN"].ToString();
                txtSeqPart.Text = dr["Seq"].ToString();
            }
            else
            {
                txtProductIdPart.Text = "";
                txtProductNamePart.Text = "";
                txtArtWorkPart.Text = "";
                txtArtWorkNamePart.Text = "";
                txtProductTypePart.Text = "";
                txtProductTypeNamePart.Text = "";
                txtSizePart.Text = "";
                txtSizeNamePart.Text = "";
                txtColorPart.Text = "";
                txtColorNamePart.Text = "";
                txtSNPart.Text = "";
                txtSeqPart.Text = "";
            }
            txtFrontPart.Text = "";
            //LoadPrdSizeGroup();
            //LoadColorGroup(0);
            //LoadColorDetails();

        }

        //private void gvMatDetails_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        //{
        //    DataRow Row = gvMatDetails.GetFocusedDataRow();
        //    string val = gvMatDetails.GetFocusedRowCellValue("MatCode").ToString();
        //    val = Row["MatCode"].ToString();
        //    if (e.Column.FieldName == "MatCost" && e.IsGetData) e.Value = val;
        //    //getTotalValue(e.ListSourceRowIndex);
        //}

        private void btnAddMat_Click(object sender, EventArgs e)
        {
            //gvMatDetails.AddNewRow();
            ////string Seq = "";
            ////Seq = GenSeqNo(dtGoodsPart, "colSizeGroupSeq");
            //DataRow Row = gvMatDetails.GetFocusedDataRow();
            ////Row["Seq"] = Seq;
            //Row["MatPriceUnit"] = "KG";
            DataRow dr = dtMat.NewRow();
            dr["MatPriceUnit"] = "KG";
            dtMat.Rows.Add(dr);
        }
        /// ///添加原料時，選擇不同原料顯示對應的資料
        private void gvMatDetails_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            int rowIndex = gvMatDetails.FocusedRowHandle;
            if (fname== "MatCode")
            {
                DataRow dr = dtMat.Rows[rowIndex];
                string matCode = dr["MatCode"].ToString().Trim();
                DataTable dtMatType = clsBaseData.LoadProcessType("MAT_CODE", matCode);
                if(dtMatType.Rows.Count>0)
                {
                    DataRow drMatType = dtMatType.Rows[0];
                    dr["MatName"] = drMatType["process_name"].ToString().Trim();
                    double matWeg = Math.Round(clsValidRule.ConvertStrToSingle(drMatType["use_weg"].ToString()), 2);
                    float wasteRate = clsValidRule.ConvertStrToSingle(drMatType["waste_rate"].ToString());
                    dr["MatWeg"] = matWeg;
                    dr["WasteRate"] = wasteRate;
                    double useWeg= Math.Round(matWeg / (1 - (wasteRate / 100)), 4);
                    dr["MatWaste"] = useWeg - matWeg;
                    dr["MatUse"] = useWeg;
                    dr["MatPrice"] = Math.Round(clsValidRule.ConvertStrToSingle(drMatType["cost_price"].ToString()), 2);
                    CountMatCost();
                }
            }
            if (fname == "MatWeg" || fname == "WasteRate")
            {
                DataRow dr = dtMat.Rows[rowIndex];
                double matWeg = Math.Round(clsValidRule.ConvertStrToSingle(dr["MatWeg"].ToString()), 2);
                float wasteRate = clsValidRule.ConvertStrToSingle(dr["WasteRate"].ToString());
                double useWeg = Math.Round(matWeg / (1 - (wasteRate / 100)), 4);
                dr["MatWaste"] = useWeg - matWeg;
                dr["MatUse"] = matWeg + useWeg;
                CountMatCost();
            }
            if (fname == "MatWaste" || fname == "MatUse" || fname == "MatPrice")
            {
                CountMatCost();
            }

        }
        private void CountMatCost()
        {
            //DataRow Row = gvMatDetails.GetFocusedDataRow();
            int rowIndex = gvMatDetails.FocusedRowHandle;
            if (dtMat.Rows.Count > 0)
            {
                DataRow Row = dtMat.Rows[rowIndex];
                //string val = gvMatDetails.GetFocusedRowCellValue("MatCode").ToString();
                float MatWeg = clsValidRule.ConvertStrToSingle(Row["MatWeg"].ToString());
                float MatWaste = clsValidRule.ConvertStrToSingle(Row["MatWaste"].ToString());
                float MatPrice = clsValidRule.ConvertStrToSingle(Row["MatPrice"].ToString());
                Row["MatUse"] = Math.Round(MatWeg + MatWaste, 4);
                float MatUse = clsValidRule.ConvertStrToSingle(Row["MatUse"].ToString());
                Row["MatCost"] = Math.Round(MatUse * MatPrice, 4);
            }
            SumMatCost();
            //////因為外發加工費是根據重量來計算的，當重量改變時，加工費也要重新計算
            CountPlateCost();
            SumTotalCost();
            //////值已改變，重新計算皮費
            CountFactoryCost();

        }
        private void repositoryItemButtonEdit8_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmProductCostingFindPrice.getProductId = "";// txtProductId.Text;
            frmProductCostingFindPrice.getProductName = "";// txtProductName.Text;
            frmProductCostingFindPrice.getDepId = "";
            frmProductCostingFindPrice.modality = "ML";
            searchPrice = 0;
            frmProductCostingFindPrice frm = new frmProductCostingFindPrice();
            frm.ShowDialog();
            if (searchPrice != 0)
            {
                DataRow Row = gvMatDetails.GetFocusedDataRow();
                Row["MatCode"] = frmProductCostingFindPrice.getProductId;
                Row["MatName"] = frmProductCostingFindPrice.getProductName;
                Row["MatPrice"] = Math.Round(searchPrice, 2);
                CountMatCost();
            }

            frm.Dispose();
        }

        private void repositoryItemButtonEdit9_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow Row = gvMatDetails.GetFocusedDataRow();
            frmProductCostingFindPrice.getProductId = Row["MatCode"].ToString();// txtProductId.Text;
            frmProductCostingFindPrice.getProductName = "";// txtProductName.Text;
            frmProductCostingFindPrice.getDepId = "";
            frmProductCostingFindPrice.modality = "ML";
            searchPrice = 0;
            frmProductCostingFindPrice frm = new frmProductCostingFindPrice();
            frm.ShowDialog();
            if (searchPrice != 0)
            {
                Row["MatPrice"] = Math.Round(searchPrice, 2);
                CountMatCost();
            }

            frm.Dispose();
        }
        private void SumMatCost()
        {
            double totMatWeg = 0;
            double totMatUse = 0;
            double totMatCost = 0;
            for (int i = 0; i < dtMat.Rows.Count; i++)
            {
                totMatWeg += Math.Round(clsValidRule.ConvertStrToSingle(dtMat.Rows[i]["MatWeg"].ToString()), 4);
                totMatUse += Math.Round(clsValidRule.ConvertStrToSingle(dtMat.Rows[i]["MatUse"].ToString()), 4);
                totMatCost += Math.Round(clsValidRule.ConvertStrToSingle(dtMat.Rows[i]["MatCost"].ToString()), 2);
            }
            txtMatWegTotal.Text = totMatWeg.ToString();
            txtMatUseTotal.Text = totMatUse.ToString();
            txtMatCostTotal.Text = totMatCost.ToString();
        }

        private void txtProductIdPart_Leave(object sender, EventArgs e)
        {
            //////新增配件狀態下才自動帶出產品資料
            if (txtProductIdPart.Text.Trim() != "" && newPartMode == 1)
                GetProductDataPart();
        }
        /// <summary>
        /// ///獲取產品編號資料
        /// </summary>
        private void GetProductDataPart()
        {
            DataTable dtPrd = clsCountGoodsCost.GetProductDataPart(txtProductIdPart.Text.Trim());
            if (dtPrd.Rows.Count > 0)
            {
                DataRow drPrd = dtPrd.Rows[0];
                txtProductNamePart.Text = drPrd["name"].ToString();
                txtArtWorkPart.Text = drPrd["blueprint_id"].ToString();
                txtArtWorkNamePart.Text = drPrd["art_cdesc"].ToString();
                txtArtWorkPart.Text = drPrd["blueprint_id"].ToString();
                txtProductTypePart.Text= drPrd["base_class"].ToString();
                txtProductTypeNamePart.Text = drPrd["prd_cdesc"].ToString();
                txtSizePart.Text= drPrd["size_id"].ToString();
                txtSizeNamePart.Text = drPrd["size_cdesc"].ToString();
                txtColorPart.Text = drPrd["color"].ToString();
                txtColorNamePart.Text = drPrd["clr_cdesc"].ToString();
                if (drPrd["mat_item"].ToString() != "")
                {
                    DataRow drMat = dtMat.Rows[0];
                    drMat["MatCode"] = drPrd["mat_item"].ToString();
                    drMat["MatName"] = drPrd["mat_name"].ToString();
                    drMat["MatWeg"] = drPrd["prd_weg"].ToString();
                    drMat["MatWaste"] = drPrd["waste_weg"].ToString();
                    drMat["MatUse"] = drPrd["use_weg"].ToString();
                    CountMatCost();
                }
            }
            
        }
        /// <summary>
        /// ///切換Tab時加載數據
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtc1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtc1.SelectedTabPage == xtp2)
            {
                if (newMode == 1)
                {
                    MessageBox.Show("主表記錄未儲存,請先儲存主表記錄!");
                    xtc1.SelectedTabPage = xtp1;
                    GetGoodsF0();
                    return;
                }
                FillGoodsPart();
                LoadGoodsDetails();
            }
            else
                LoadData();
        }
        /// <summary>
        /// ///提取各種費用詳細
        /// </summary>
        private void LoadGoodsDetails()
        {
            int UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : -999;
            //////提取原料
            dtMat = clsCountGoodsCost.LoadProductCostMat(UpperSN);
            gcMatDetails.DataSource = dtMat;
            if (dtMat.Rows.Count == 0)
            {
                //gvMatDetails.AddNewRow();
                //DataRow Row = gvMatDetails.GetFocusedDataRow();
                //Row["MatPriceUnit"] = "KG";
                ////dtMat.Rows[0]["MatPriceUnit"] = "KG";
                DataRow dr = dtMat.NewRow();
                dr["MatPriceUnit"] = "KG";
                dtMat.Rows.Add(dr);
            }
            //////提取部門工序加工費
            dtProcess = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "01");
            gcGoodsProcess.DataSource = dtProcess;
            if (dtProcess.Rows.Count == 0)
            {
                //gvGoodsProcess.AddNewRow();
                //DataRow Row = gvGoodsProcess.GetFocusedDataRow();
                //Row["ProcessUnit"] = "PCS";
                ////dtMat.Rows[0]["MatPriceUnit"] = "KG";
                for (int i = 0; i <= 10; i++)
                {
                    DataRow dr = dtProcess.NewRow();
                    dr["ProcessUnit"] = "PCS";
                    dtProcess.Rows.Add(dr);
                }
            }
            //////提取外發加工費
            dtPlate = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "02");
            gcGoodsPlate.DataSource = dtPlate;
            if (dtPlate.Rows.Count == 0)
            {
                //gvGoodsPlate.AddNewRow();
                //DataRow Row = gvGoodsPlate.GetFocusedDataRow();
                //Row["PrdDep"] = "501";
                //Row["ProcessUnit"] = "PCS";
                //Row["WegUnit"] = "KG";
                //Row["WasteRate"] = "1.1";
                ////dtMat.Rows[0]["MatPriceUnit"] = "KG";
                DataRow Row = dtPlate.NewRow();
                Row["PrdDep"] = "501";
                Row["ProcessUnit"] = "PCS";
                Row["WegUnit"] = "KG";
                Row["WasteRate"] = "1.1";
                dtPlate.Rows.Add(Row);
            }
            //////提取包裝費用
            dtPack = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "03");
            gcGoodsPack.DataSource = dtPack;
            if (dtPack.Rows.Count == 0)
            {
                //gvGoodsPack.AddNewRow();
                //DataRow Row = gvGoodsPack.GetFocusedDataRow();
                //Row["PrdDep"] = "601";
                DataRow Row = dtPack.NewRow();
                Row["PrdDep"] = "601";
                dtPack.Rows.Add(Row);
            }
            //////提取工廠皮費
            dtFactory = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "04");
            gcGoodsFactory.DataSource = dtFactory;
            if (dtFactory.Rows.Count == 0)
            {
                dtFactory.Rows.Add();

                ///// ///默認添加電鍍損耗
                //DataTable dtPlateWasteRate = clsBaseData.LoadProductProcess("FT_FEE", "PL001", "");
                //if (dtPlateWasteRate.Rows.Count > 0)
                //{
                //    DataRow drPlateWasteRate = dtPlateWasteRate.Rows[0];
                //    DataRow dr = dtFactory.NewRow();
                //    dr["ProcessID"] = drPlateWasteRate["process_id"].ToString().Trim();
                //    dr["ProcessName"] = drPlateWasteRate["process_name"].ToString().Trim();
                //    dr["ProcessBaseQty"] = drPlateWasteRate["product_qty"];
                //    dtFactory.Rows.Add(dr);
                //}
                //else
                //{
                //    dtFactory.Rows.Add();
                //}
            }
        }

        private void FillGoodsPart()
        {
            if (gvGoodsPartDetails.RowCount > 0)
            {
                DataRow Row = gvGoodsPartDetails.GetFocusedDataRow();
                //DataRow Row = dtGoodsPartDetails.Rows[0];
                txtProductIdPart.Text = Row["ProductID"].ToString();
                txtProductNamePart.Text = Row["ProductName"].ToString();
                txtArtWorkPart.Text = Row["ArtWork"].ToString();
                txtArtWorkNamePart.Text = Row["ArtWorkName"].ToString();
                txtProductTypePart.Text = Row["ProductType"].ToString();
                txtProductTypeNamePart.Text = Row["ProductTypeName"].ToString();
                txtFrontPart.Text = Row["FrontPart"].ToString();
                txtSizePart.Text = Row["ProductSize"].ToString();
                txtSizeNamePart.Text = Row["ProductSizeName"].ToString();
                txtColorPart.Text = Row["ProductColor"].ToString();
                txtColorNamePart.Text = Row["ProductColorName"].ToString();
                txtMatWegTotal.Text = Row["MatWeg"].ToString();
                txtMatUseTotal.Text = Row["MatUse"].ToString();
                txtMatCostTotal.Text = Row["MatCost"].ToString();
                txtProcessCostTotal.Text = Row["ProcessCostTotal"].ToString();
                txtProcessProfitRate.Text = Row["ProcessProfitRate"].ToString() != "0" ? Row["ProcessProfitRate"].ToString() : "0";
                txtProcessProfit.Text = Row["ProcessProfit"].ToString();
                txtPlateCostTotal.Text = Row["PlateCost"].ToString();
                txtPackCostTotal.Text = Row["PackCost"].ToString();
                txtCostPcs.Text = Row["CostPcs"].ToString();
                txtCostGrs.Text = Row["CostGrs"].ToString();
                txtCostK.Text = Row["CostK"].ToString();
                txtFactoryCostTotal.Text = Row["FactoryFee"].ToString();
                txtFactoryCostPcs.Text = Row["FactoryCostPcs"].ToString();
                txtFactoryCostGrs.Text = Row["FactoryCostGrs"].ToString();
                txtFactoryCostK.Text = Row["FactoryCostK"].ToString();
                txtSNPart.Text = Row["SN"].ToString();
                txtSeqPart.Text = Row["Seq"].ToString();
            }
            else
            {
                txtProductIdPart.Text = "";
                txtProductNamePart.Text = "";
                txtArtWorkPart.Text = "";
                txtArtWorkNamePart.Text = "";
                txtProductTypePart.Text = "";
                txtProductTypeNamePart.Text = "";
                txtSizePart.Text = "";
                txtSizeNamePart.Text = "";
                txtColorPart.Text = "";
                txtColorNamePart.Text = "";
                txtMatUseTotal.Text = "";
                txtMatCostTotal.Text = "";
                txtProcessCostTotal.Text = "";
                txtProcessProfitRate.Text = "0";
                txtProcessProfit.Text = "";
                txtPlateCostTotal.Text = "";
                txtPackCostTotal.Text = "";
                txtCostPcs.Text = "";
                txtCostGrs.Text = "";
                txtCostK.Text = "";
                txtFactoryCostTotal.Text = "";
                txtFactoryCostPcs.Text = "";
                txtFactoryCostGrs.Text = "";
                txtFactoryCostK.Text = "";
                txtSNPart.Text = "";
                txtSeqPart.Text = "";
            }
        }

        /// <summary>
        /// ///儲存配件
        /// </summary>
        private void SavePorductCostPart()
        {
            if(txtSN.Text.Trim()=="")
            {
                MessageBox.Show("主表記錄編號不存在,儲存無效!");
                return;
            }
            mdlCountGoodsCostPart mdlGoodsPpart = new mdlCountGoodsCostPart();
            mdlGoodsPpart.UpperSN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
            mdlGoodsPpart.Seq = txtSeqPart.Text.Trim();
            mdlGoodsPpart.ProductID = txtProductIdPart.Text;
            mdlGoodsPpart.ProductName = txtProductNamePart.Text;
            mdlGoodsPpart.FrontPart = txtFrontPart.Text.ToString().Trim();
            mdlGoodsPpart.ArtWork = txtArtWorkPart.Text;
            mdlGoodsPpart.ArtWorkName = txtArtWorkNamePart.Text;
            mdlGoodsPpart.ProductType = txtProductTypePart.Text;
            mdlGoodsPpart.ProductTypeName = txtProductTypeNamePart.Text;
            mdlGoodsPpart.ProductColor = txtColorPart.Text;
            mdlGoodsPpart.ProductColorName = txtColorNamePart.Text;
            mdlGoodsPpart.ProductSize = txtSizePart.Text;
            mdlGoodsPpart.ProductSizeName = txtSizeNamePart.Text;
            mdlGoodsPpart.MatWeg = clsValidRule.ConvertStrToSingle(txtMatWegTotal.Text);
            mdlGoodsPpart.MatUse = clsValidRule.ConvertStrToSingle(txtMatUseTotal.Text);
            mdlGoodsPpart.MatCost = clsValidRule.ConvertStrToSingle(txtMatCostTotal.Text);
            mdlGoodsPpart.ProcessCostTotal = clsValidRule.ConvertStrToSingle(txtProcessCostTotal.Text);
            mdlGoodsPpart.ProcessProfitRate = clsValidRule.ConvertStrToSingle(txtProcessProfitRate.Text);
            mdlGoodsPpart.ProcessProfit = clsValidRule.ConvertStrToSingle(txtProcessProfit.Text);
            mdlGoodsPpart.PlateCost = clsValidRule.ConvertStrToSingle(txtPlateCostTotal.Text);
            mdlGoodsPpart.PackCost = clsValidRule.ConvertStrToSingle(txtPackCostTotal.Text);
            mdlGoodsPpart.CostPcs = clsValidRule.ConvertStrToSingle(txtCostPcs.Text);
            mdlGoodsPpart.CostGrs = clsValidRule.ConvertStrToSingle(txtCostGrs.Text);
            mdlGoodsPpart.CostK = clsValidRule.ConvertStrToSingle(txtCostK.Text);
            mdlGoodsPpart.FactoryFee = clsValidRule.ConvertStrToSingle(txtFactoryCostTotal.Text);
            mdlGoodsPpart.FactoryCostPcs = clsValidRule.ConvertStrToSingle(txtFactoryCostPcs.Text);
            mdlGoodsPpart.FactoryCostGrs = clsValidRule.ConvertStrToSingle(txtFactoryCostGrs.Text);
            mdlGoodsPpart.FactoryCostK = clsValidRule.ConvertStrToSingle(txtFactoryCostK.Text);
            mdlGoodsPpart.Remark = "";
            string result = clsCountGoodsCost.SaveGoodsPart(mdlGoodsPpart);
            txtSeqPart.Text = result;

            LoadProductCostPart(result);
        }
        /// <summary>
        /// ///儲存原料
        /// </summary>
        private void SaveProductCostMat()
        {
            if(txtSNPart.Text.Trim()=="")
            {
                MessageBox.Show("配件的記錄序號不存在,儲存無效!");
                return;
            }
            string result = "";
            List <mdlCountGoodsCostMat> lsGoodsMat = new List<mdlCountGoodsCostMat>();
            for (int i=0;i< dtMat.Rows.Count;i++)
            {
                DataRow dr = dtMat.Rows[i];
                string seq= dr["Seq"].ToString().Trim();
                float matCost = clsValidRule.ConvertStrToSingle(dr["MatCost"].ToString());
                if (seq == "" && matCost == 0)
                { }
                else
                {
                    mdlCountGoodsCostMat mdlGoodsMat = new mdlCountGoodsCostMat();
                    mdlGoodsMat.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                    mdlGoodsMat.Seq = dr["Seq"].ToString();
                    mdlGoodsMat.MatCode = dr["MatCode"].ToString();
                    mdlGoodsMat.MatName = dr["MatName"].ToString();
                    mdlGoodsMat.MatWeg = clsValidRule.ConvertStrToSingle(dr["MatWeg"].ToString());
                    mdlGoodsMat.WasteRate = clsValidRule.ConvertStrToSingle(dr["WasteRate"].ToString());
                    mdlGoodsMat.MatWaste = clsValidRule.ConvertStrToSingle(dr["MatWaste"].ToString());
                    mdlGoodsMat.MatUse = clsValidRule.ConvertStrToSingle(dr["MatUse"].ToString());
                    mdlGoodsMat.MatPrice = clsValidRule.ConvertStrToSingle(dr["MatPrice"].ToString());
                    mdlGoodsMat.MatPriceUnit = dr["MatPriceUnit"].ToString();
                    mdlGoodsMat.MatCost = matCost;
                    lsGoodsMat.Add(mdlGoodsMat);
                }
            }
            if (lsGoodsMat.Count > 0)
                result = clsCountGoodsCost.SaveGoodsCostMat(lsGoodsMat);
        }

        /// <summary>
        /// ///儲存工序
        /// </summary>
        private void SaveGoodsCostProcess(DataTable dtSave,string processType)
        {
            if(txtSNPart.Text.Trim()=="")
            {
                MessageBox.Show("產品主表記錄編號不存在，儲存無效!");
                return;
            }
            string result = "";
            List<mdlCountGoodsCostProcess> lsGoodsProcess = new List<mdlCountGoodsCostProcess>();
            for (int i = 0; i < dtSave.Rows.Count; i++)
            {
                DataRow dr = dtSave.Rows[i];
                mdlCountGoodsCostProcess mdlGoodsProcess = new mdlCountGoodsCostProcess();
                string seq = dr["Seq"].ToString().Trim();
                float costK= clsValidRule.ConvertStrToSingle(dr["CostK"].ToString());
                float totalCostK = clsValidRule.ConvertStrToSingle(dr["TotalCostK"].ToString());
                if (seq == "" && costK == 0 && totalCostK == 0)
                { }
                else
                {
                    mdlGoodsProcess.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                    mdlGoodsProcess.Seq = seq;
                    mdlGoodsProcess.ProcessType = processType;
                    mdlGoodsProcess.PrdDep = dr["PrdDep"].ToString();
                    mdlGoodsProcess.ProcessID = dr["ProcessID"].ToString();
                    mdlGoodsProcess.ProcessName = dr["ProcessName"].ToString();
                    mdlGoodsProcess.ProcessPrice = clsValidRule.ConvertStrToSingle(dr["ProcessPrice"].ToString());
                    mdlGoodsProcess.ProcessBaseQty = clsValidRule.ConvertStrToSingle(dr["ProcessBaseQty"].ToString());
                    mdlGoodsProcess.ProcessUnit = dr["ProcessUnit"].ToString();
                    mdlGoodsProcess.CostK = costK;
                    mdlGoodsProcess.TotalCostK = totalCostK;
                    if (processType == "01" || processType == "03" || processType == "04")//部門加工費
                    {
                        mdlGoodsProcess.WegPrice = 0;
                        mdlGoodsProcess.WegUnit = "";
                        mdlGoodsProcess.WegCost = 0;
                        mdlGoodsProcess.WasteRate = 0;
                    }
                    else if (processType == "02")//部門加工費
                    {
                        mdlGoodsProcess.WegPrice = clsValidRule.ConvertStrToSingle(dr["WegPrice"].ToString());
                        mdlGoodsProcess.WegUnit = dr["WegUnit"].ToString();
                        mdlGoodsProcess.WegCost = clsValidRule.ConvertStrToSingle(dr["WegCost"].ToString());
                        mdlGoodsProcess.WasteRate = clsValidRule.ConvertStrToSingle(dr["WasteRate"].ToString());
                        mdlGoodsProcess.VendID = dr["VendID"].ToString();
                        mdlGoodsProcess.VendName = dr["VendName"].ToString();
                    }
                    lsGoodsProcess.Add(mdlGoodsProcess);
                }
            }
            if (lsGoodsProcess.Count > 0)
                result = clsCountGoodsCost.SaveGoodsCostProcess(lsGoodsProcess);
        }

        /// <summary>
        /// ///計算部門加工費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoodsProcess_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            DataRow Row = gvGoodsProcess.GetFocusedDataRow();
            if (fname == "ProcessID")//fname == "PrdDep" || 
            {
                DataTable dtProcessBase = clsBaseData.LoadProductProcess(Row["PrdDep"].ToString(), Row["ProcessID"].ToString(), "");
                if (dtProcessBase.Rows.Count > 0)
                {
                    DataRow dr = dtProcessBase.Rows[0];
                    Row["ProcessName"] = dr["process_name"].ToString();
                    Row["ProcessPrice"] = dr["cost_price"];
                    Row["ProcessBaseQty"] = dr["product_qty"];
                }
                else
                {
                    Row["ProcessName"] = "";
                    Row["ProcessPrice"] = "";
                    Row["ProcessBaseQty"] = "";
                    Row["CostK"] = "";
                }
                CountProcessCost();
            }
            if (fname == "ProcessPrice" || fname == "ProcessBaseQty")//fname == "ProcessID" || 
            {
                CountProcessCost();
                
            }

        }
        private void CountProcessCost()
        {
            DataRow Row = gvGoodsProcess.GetFocusedDataRow();
            if (Row != null)
            {
                float processPrice = clsValidRule.ConvertStrToSingle(Row["ProcessPrice"].ToString());
                float processBaseQty = clsValidRule.ConvertStrToSingle(Row["ProcessBaseQty"].ToString());
                Row["CostK"] = processBaseQty != 0 ? Math.Round((processPrice / processBaseQty) * baseQtyRate, 2) : 0;
            }
            SumProcessCost();
            SumTotalCost();
            //////值已改變，重新計算皮費
            CountFactoryCost();
        }
        private void SumProcessCost()
        {
            float totProcessCost = 0;
            for (int i=0;i<dtProcess.Rows.Count;i++)
            {
                totProcessCost += clsValidRule.ConvertStrToSingle(dtProcess.Rows[i]["CostK"].ToString());
            }
            txtProcessCostTotal.Text = Math.Round(totProcessCost, 2).ToString();
            float ProcessProfitRate= clsValidRule.ConvertStrToSingle(txtProcessProfitRate.Text);
            txtProcessProfit.Text = Math.Round((totProcessCost * (ProcessProfitRate / 100)), 2).ToString();
        }
        /// <summary>
        /// ///查找及填入部門加工費用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow Row = gvGoodsProcess.GetFocusedDataRow();
            frmCountGoodsCostFindProcess.getProcessId = Row["ProcessID"].ToString();// txtProductId.Text;
            frmCountGoodsCostFindProcess.getProcessName = "";// txtProductName.Text;
            frmCountGoodsCostFindProcess.getDepId = Row["PrdDep"].ToString();
            frmCountGoodsCostFindProcess.modality = "PROCESS";
            searchPrice = 0;
            frmCountGoodsCostFindProcess frm = new frmCountGoodsCostFindProcess();
            frm.ShowDialog();
            if (searchPrice != 0 || searchPriceWeg != 0)
            {
                Row["PrdDep"] = frmCountGoodsCostFindProcess.getDepId.Trim();
                Row["ProcessID"] = frmCountGoodsCostFindProcess.getProcessId.Trim();
                Row["ProcessName"] = frmCountGoodsCostFindProcess.getProcessName.Trim();
                Row["ProcessPrice"] = Math.Round(searchPrice, 4);
                Row["ProcessBaseQty"] = frmCountGoodsCostFindProcess.getBaseQty;
                Row["ProcessUnit"] = frmCountGoodsCostFindProcess.getPriceUnit;
                CountProcessCost();
            }

            frm.Dispose();
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            //gvGoodsProcess.AddNewRow();
            //DataRow Row = gvGoodsProcess.GetFocusedDataRow();
            //Row["ProcessUnit"] = "PCS";

            DataRow dr = dtProcess.NewRow();
            dr["ProcessUnit"] = "KG";
            dtProcess.Rows.Add(dr);
        }

        private void btnAddPlate_Click(object sender, EventArgs e)
        {
            //gvGoodsPlate.AddNewRow();
            //DataRow Row = gvGoodsPlate.GetFocusedDataRow();
            DataRow Row = dtPlate.NewRow();
            Row["PrdDep"] = "501";
            Row["ProcessUnit"] = "PCS";
            Row["WegUnit"] = "KG";
            Row["WasteRate"] = "1";
            dtPlate.Rows.Add(Row);
        }

        /// <summary>
        /// ///計算電鍍費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoodsPlate_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            DataRow Row = gvGoodsPlate.GetFocusedDataRow();
            if (fname == "ProcessID" || fname == "ProcessName")
            {

            }
            if (fname == "ProcessPrice" || fname == "ProcessUnit" || fname == "WegPrice" || fname == "WegUnit" || fname == "WasteRate")
            {
                CountPlateCost();
            }
        }

        private void CountPlateCost()
        {
            DataRow Row = gvGoodsPlate.GetFocusedDataRow();
            //DataRow Row = dtPlate.Rows[gvGoodsPlate.FocusedRowHandle];
            if (Row != null)
            {
                float unitRate = clsBaseData.GetUnitRate(Row["ProcessUnit"].ToString());
                float processPrice = clsValidRule.ConvertStrToSingle(Row["ProcessPrice"].ToString());
                float wasteRate = clsValidRule.ConvertStrToSingle(Row["WasteRate"].ToString());
                float wegPrice = clsValidRule.ConvertStrToSingle(Row["WegPrice"].ToString());
                float matWeg = clsValidRule.ConvertStrToSingle(txtMatWegTotal.Text.ToString());
                Row["CostK"] = unitRate != 0 ? Math.Round((processPrice / unitRate) * baseQtyRate * wasteRate, 2) : 0;
                Row["WegCost"] = Math.Round((wegPrice * matWeg * wasteRate), 2);
                Row["TotalCostK"] = Math.Round(clsValidRule.ConvertStrToSingle(Row["CostK"].ToString()) + clsValidRule.ConvertStrToSingle(Row["WegCost"].ToString()), 2);
            }
            SumPlateCost();
            SumTotalCost();
            //////值已改變，重新計算皮費
            CountFactoryCost();
        }
        private void SumPlateCost()
        {
            //dataGridViewX2.Rows[e.RowIndex].Cells["id"].Value.ToString();
            float totalCostK = 0;
            for (int i = 0; i < dtPlate.Rows.Count; i++)
            {
                totalCostK += clsValidRule.ConvertStrToSingle(dtPlate.Rows[i]["TotalCostK"].ToString());
            }
            txtPlateCostTotal.Text = totalCostK.ToString();
        }

        /// <summary>
        /// ///查找外發加工費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow Row = gvGoodsPlate.GetFocusedDataRow();
            frmProductCostingFindPrice.getProductId = "";// Row["ProcessID"].ToString();// txtProductId.Text;
            frmProductCostingFindPrice.getProductName = Row["ProcessName"].ToString(); ;// txtProductName.Text;
            frmProductCostingFindPrice.getDepId = "";// Row["PrdDep"].ToString();
            frmProductCostingFindPrice.modality = "PLATE";
            searchPrice = 0;
            frmProductCostingFindPrice frm = new frmProductCostingFindPrice();
            frm.ShowDialog();
            if (searchPrice != 0 || searchPriceWeg != 0)
            {
                Row["PrdDep"] = frmProductCostingFindPrice.getDepId;
                Row["ProcessID"] = frmProductCostingFindPrice.getProductId;
                Row["ProcessName"] = frmProductCostingFindPrice.getProductName;
                Row["ProcessPrice"] = Math.Round(searchPrice, 2);
                Row["ProcessUnit"] = searchPriceQtyUnit;
                Row["WegPrice"] = Math.Round(searchPriceWeg, 2);
                Row["WegUnit"] = searchPriceWegUnit;
                CountPlateCost();
            }

            frm.Dispose();
        }
        /// <summary>
        /// ///計算包裝費用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoodsPack_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            DataRow Row = gvGoodsPack.GetFocusedDataRow();
            int rowIndex = gvGoodsPack.FocusedRowHandle;
            if (fname == "ProcessID")
            {
                DataRow dr = dtPack.Rows[rowIndex];
                string processID = dr["ProcessID"].ToString().Trim();
                DataTable dtProcessType = clsBaseData.LoadProcessType("PK_FEE", processID);
                if (dtProcessType.Rows.Count > 0)
                {
                    DataRow drProcessType = dtProcessType.Rows[0];
                    dr["ProcessName"] = drProcessType["process_name"].ToString().Trim();
                    dr["ProcessPrice"] = Math.Round(clsValidRule.ConvertStrToSingle(drProcessType["PriceHKD"].ToString()), 2);
                    dr["ProcessBaseQty"]= clsValidRule.ConvertStrToSingle(drProcessType["product_qty"].ToString());
                    CountPackCost();
                }
            }
            if (fname == "ProcessPrice" || fname == "ProcessBaseQty")
            {
                CountPackCost();
            }
        }
        private void CountPackCost()
        {
            DataRow Row = gvGoodsPack.GetFocusedDataRow();
            if (Row != null)
            {
                float processPrice = clsValidRule.ConvertStrToSingle(Row["ProcessPrice"].ToString());
                float ProcessBaseQty = clsValidRule.ConvertStrToSingle(Row["ProcessBaseQty"].ToString());
                Row["CostK"] = ProcessBaseQty != 0 ? Math.Round((processPrice / ProcessBaseQty) * baseQtyRate, 2) : 0;
            }
            SumPackCost();
            SumTotalCost();
            //////值已改變，重新計算皮費
            CountFactoryCost();
        }
        private void SumPackCost()
        {
            //dataGridViewX2.Rows[e.RowIndex].Cells["id"].Value.ToString();
            float totalCostK = 0;
            for (int i = 0; i < dtPack.Rows.Count; i++)
            {
                totalCostK += clsValidRule.ConvertStrToSingle(dtPack.Rows[i]["CostK"].ToString());
            }
            txtPackCostTotal.Text = totalCostK.ToString();
        }

        private void btnAddPack_Click(object sender, EventArgs e)
        {
            //gvGoodsPack.AddNewRow();
            //DataRow Row = gvGoodsPack.GetFocusedDataRow();
            DataRow Row = dtPack.NewRow();
            Row["PrdDep"] = "601";
            dtPack.Rows.Add(Row);
        }

        private void btnSetMatVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("00");
        }

        private void btnSetProcessVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("01");
        }

        private void btnSetPlateVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("02");
        }

        private void btnSetPackVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("03");
        }
        private void btnSetFactoryVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("04");
        }
        private void btnSetProfitVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("05");
        }

        private void btnSetPurPriceVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("06");
        }
        /// <summary>
        /// ///顯示各個項目
        /// </summary>
        /// <param name="processType"></param>
        private void SetPanelVisible(string processType)
        {
            switch (processType)
            {
                case "00"://原料
                    if (btnSetMatVisible.Text == "折疊<<")
                    {
                        plcMat.Visible = false;
                        btnSetMatVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcMat.Visible = true;
                        btnSetMatVisible.Text = "折疊<<";
                    }
                    break;
                case "01"://加工費
                    if (btnSetProcessVisible.Text == "折疊<<")
                    {
                        plcProcess.Visible = false;
                        btnSetProcessVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcProcess.Visible = true;
                        btnSetProcessVisible.Text = "折疊<<";
                    }
                    break;
                case "02"://電鍍費
                    if (btnSetPlateVisible.Text == "折疊<<")
                    {
                        plcPlate.Visible = false;
                        btnSetPlateVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcPlate.Visible = true;
                        btnSetPlateVisible.Text = "折疊<<";
                    }
                    break;
                case "03"://包裝費
                    if (btnSetPackVisible.Text == "折疊<<")
                    {
                        plcPack.Visible = false;
                        btnSetPackVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcPack.Visible = true;
                        btnSetPackVisible.Text = "折疊<<";
                    }
                    break;
                case "04"://工廠皮費
                    if (btnSetFactoryVisible.Text == "折疊<<")
                    {
                        plcFactory.Visible = false;
                        btnSetFactoryVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcFactory.Visible = true;
                        btnSetFactoryVisible.Text = "折疊<<";
                    }
                    break;
                case "05"://利潤試算
                    if (btnSetProfitVisible.Text == "折疊<<")
                    {
                        plcProfit.Visible = false;
                        btnSetProfitVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcProfit.Visible = true;
                        btnSetProfitVisible.Text = "折疊<<";
                    }
                    break;
                case "06"://報價意向
                    if (btnSetPurPriceVisible.Text == "折疊<<")
                    {
                        plcPurPrice.Visible = false;
                        btnSetPurPriceVisible.Text = "展開>>";
                    }
                    else
                    {
                        plcPurPrice.Visible = true;
                        btnSetPurPriceVisible.Text = "折疊<<";
                    }
                    break;
                default:
                    break;
            }
            
        }


        private void btnAddFactory_Click(object sender, EventArgs e)
        {
            //gvGoodsFactory.AddNewRow();
            //DataRow Row = gvGoodsFactory.GetFocusedDataRow();
            dtFactory.Rows.Add();
        }
        /// <summary>
        /// ///計算工廠皮費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoodsFactory_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            DataRow Row = gvGoodsFactory.GetFocusedDataRow();
            if (fname == "ProcessID" || fname == "ProcessName")
            {

            }
            if (fname == "ProcessPrice" || fname == "ProcessBaseQty")
            {
                CountFactoryCost();
            }
        }
        private void CountFactoryCost()
        {
            DataRow Row = gvGoodsFactory.GetFocusedDataRow();
            if (Row != null)
            {
                float costK = clsValidRule.ConvertStrToSingle(txtCostK.Text);
                float ProcessBaseQty = clsValidRule.ConvertStrToSingle(Row["ProcessBaseQty"].ToString());
                Row["CostK"] = ProcessBaseQty != 0 ? Math.Round(costK * (ProcessBaseQty / 100), 2) : 0;
            }
            SumFactoryCost();
            SumTotalCost();
        }
        private void SumFactoryCost()
        {
            //dataGridViewX2.Rows[e.RowIndex].Cells["id"].Value.ToString();
            float totalCostK = 0;
            for (int i = 0; i < dtFactory.Rows.Count; i++)
            {
                totalCostK += clsValidRule.ConvertStrToSingle(dtFactory.Rows[i]["CostK"].ToString());
            }
            txtFactoryCostTotal.Text = totalCostK.ToString();
        }
        private void SumTotalCost()
        {
            float matCostK = clsValidRule.ConvertStrToSingle(txtMatCostTotal.Text);
            float processPprofitCostK = clsValidRule.ConvertStrToSingle(txtProcessProfit.Text);
            float processCostTotal= clsValidRule.ConvertStrToSingle(txtProcessCostTotal.Text); 
            float plateCostK = clsValidRule.ConvertStrToSingle(txtPlateCostTotal.Text);
            float packCostK = clsValidRule.ConvertStrToSingle(txtPackCostTotal.Text);
            //////產品基本成本
            float goodsTotalCostK = matCostK + processCostTotal + plateCostK + packCostK;
            txtCostK.Text = goodsTotalCostK.ToString();
            txtCostPcs.Text = Math.Round(goodsTotalCostK / baseQtyRate, 4).ToString();
            txtCostGrs.Text = Math.Round((goodsTotalCostK / baseQtyRate) * 144, 2).ToString();

            //////工廠合計成本  =  產品基本成本 + 加工費利潤 + 電鍍損耗及其它費用
            float processProfit = clsValidRule.ConvertStrToSingle(txtProcessProfit.Text.ToString());
            float factoryCostK = clsValidRule.ConvertStrToSingle(txtFactoryCostTotal.Text);
            float factoryTotalCostK = goodsTotalCostK + processProfit + factoryCostK;
            txtFactoryCostK.Text = factoryTotalCostK.ToString();
            txtFactoryCostPcs.Text = Math.Round((factoryTotalCostK / baseQtyRate), 4).ToString();
            txtFactoryCostGrs.Text = Math.Round((factoryTotalCostK / baseQtyRate) * 144, 2).ToString();
        }
        /// <summary>
        /// 刪除表格中的部門加工費記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit12_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtProcess, "01", gvGoodsProcess.FocusedRowHandle);//刪除部門加工費
            SumProcessCost();
            SumTotalCost();
            SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
        }

        private void DeleteGoodsCostProcess(DataTable dt, string processType,int rowIndex)
        {
            if(txtSNPart.Text.Trim()=="")
            {
                MessageBox.Show("配件記錄編號不存在,刪除無效!");
                return;
            }
            //DataRow dr = dt.Rows[0];
            //if (dr["Seq"].ToString().Trim() == "")
            //{
            //    dt.Rows.Remove(dr);
            //}
            //else
            //{
            //    mdlCountGoodsCostProcess mdlGoodsProcess = new mdlCountGoodsCostProcess();
            //    mdlGoodsProcess.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
            //    mdlGoodsProcess.Seq = dr["Seq"].ToString();
            //    mdlGoodsProcess.ProcessType = processType;
            //}
            //dgvWorker.CurrentRow.Index

            //DataRow Row = gvGoodsProcess.GetFocusedDataRow();
            DataRow Row = dt.Rows[rowIndex];
            if (Row["Seq"].ToString().Trim() != "")
            {
                mdlCountGoodsCostProcess mdlGoodsProcess = new mdlCountGoodsCostProcess();
                mdlGoodsProcess.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                mdlGoodsProcess.Seq = Row["Seq"].ToString();
                mdlGoodsProcess.ProcessType = processType;
                string result = clsCountGoodsCost.DeleteGoodsCostProcess(mdlGoodsProcess);
            }
            dt.Rows.Remove(Row);
            //gvGoodsProcess.DeleteSelectedRows();
        }
        /// <summary>
        /// ///刪除原料表格中的明細記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit13_Click(object sender, EventArgs e)
        {
            if (txtSNPart.Text.Trim() == "")
            {
                MessageBox.Show("配件記錄不存在,刪除無效!");
                return;
            }
            int rowIndex = gvMatDetails.FocusedRowHandle;
            DataRow Row = dtMat.Rows[rowIndex];
            if (Row["Seq"].ToString().Trim() != "")
            {
                int UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                string Seq = Row["Seq"].ToString();
                string result = clsCountGoodsCost.DeleteGoodsCostMat(UpperSN,Seq);
            }
            dtMat.Rows.Remove(Row);
            SumMatCost();
            SumTotalCost();//刪除後重新計算總成本
            SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
        }
        /// <summary>
        /// ///刪除外發加工費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit14_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtPlate, "02", gvGoodsPlate.FocusedRowHandle);//刪除外發加工費
            SumPlateCost();
            SumTotalCost();
            SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
        }

        private void repositoryItemButtonEdit15_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtPack, "03", gvGoodsPack.FocusedRowHandle);//刪除包裝費
            SumPackCost();
            SumTotalCost();
            SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
        }

        private void repositoryItemButtonEdit16_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtFactory, "04", gvGoodsFactory.FocusedRowHandle);//刪除包裝費
            SumFactoryCost();
            SumTotalCost();
            SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
        }
        /// <summary>
        /// ///查找并填入包裝費用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow Row = gvGoodsPack.GetFocusedDataRow();
            frmCountGoodsCostFindProcess.getProcessId = Row["ProcessID"].ToString();// txtProductId.Text;
            frmCountGoodsCostFindProcess.getProcessName = "";// txtProductName.Text;
            frmCountGoodsCostFindProcess.getDepId = Row["PrdDep"].ToString();
            frmCountGoodsCostFindProcess.modality = "PK_FEE";
            searchPrice = 0;
            frmCountGoodsCostFindProcess frm = new frmCountGoodsCostFindProcess();
            frm.ShowDialog();
            if (searchPrice != 0)
            {
                Row["PrdDep"] = frmCountGoodsCostFindProcess.getDepId.Trim();
                Row["ProcessID"] = frmCountGoodsCostFindProcess.getProcessId.Trim();
                Row["ProcessName"] = frmCountGoodsCostFindProcess.getProcessName.Trim();
                Row["ProcessPrice"] = Math.Round(searchPrice, 4);
                Row["ProcessBaseQty"] = frmCountGoodsCostFindProcess.getBaseQty;
                CountPackCost();
            }

            frm.Dispose();
        }
        /// <summary>
        /// ///查找并填入工廠皮費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit6_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow Row = gvGoodsFactory.GetFocusedDataRow();
            frmCountGoodsCostFindProcess.getProcessId = Row["ProcessID"].ToString();// txtProductId.Text;
            frmCountGoodsCostFindProcess.getProcessName = Row["ProcessName"].ToString();// txtProductName.Text;
            frmCountGoodsCostFindProcess.modality = "FT_FEE";
            searchPrice = 0;
            frmCountGoodsCostFindProcess frm = new frmCountGoodsCostFindProcess();
            frm.ShowDialog();
            if (frmCountGoodsCostFindProcess.getBaseQty != 0)
            {
                Row["ProcessID"] = frmCountGoodsCostFindProcess.getProcessId.Trim();
                Row["ProcessName"] = frmCountGoodsCostFindProcess.getProcessName.Trim();
                Row["ProcessBaseQty"] = frmCountGoodsCostFindProcess.getBaseQty;
                CountFactoryCost();
            }

            frm.Dispose();
        }

        private void txtProductId_Leave(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
                return;
            if (newMode == 1)
                GetGoodsF0();
        }
        private void GetGoodsF0()
        {
            string productID = txtProductId.Text.Trim();
            DataTable dtPrd = clsCountGoodsCost.GetProductDataPart(productID);
            if (dtPrd.Rows.Count > 0)
            {
                DataRow drPrd = dtPrd.Rows[0];
                txtProductName.Text = drPrd["name"].ToString();
                txtArtWork.Text = drPrd["blueprint_id"].ToString();
                txtArtWorkName.Text = drPrd["art_cdesc"].ToString();
                txtArtWork.Text = drPrd["blueprint_id"].ToString();
                txtProductType.Text = drPrd["base_class"].ToString();
                txtProductTypeName.Text = drPrd["prd_cdesc"].ToString();
                txtSize.Text = drPrd["size_id"].ToString();
                txtSizeName.Text = drPrd["size_cdesc"].ToString();
                txtColor.Text = drPrd["color"].ToString();
                txtColorName.Text = drPrd["clr_cdesc"].ToString();
            }
            else
            {
                txtProductName.Text = "";
                txtArtWork.Text = "";
                txtArtWorkName.Text = "";
                txtArtWork.Text = "";
                txtProductType.Text = "";
                txtProductTypeName.Text = "";
                txtSize.Text = "";
                txtSizeName.Text = "";
                txtColor.Text = "";
                txtColorName.Text = "";
            }
            dtGoodsPartDetails = clsCountGoodsCost.getBomCid(productID);
            gcGoodsPartDetails.DataSource = dtGoodsPartDetails;
        }

        private void txtTestQty_TextChanged(object sender, EventArgs e)
        {
            CountTestCost();
        }

        private void lueTestUnit_EditValueChanged(object sender, EventArgs e)
        {
            CountTestCost();
        }
        private void txtProfitRate_EditValueChanged(object sender, EventArgs e)
        {
            CountTestCost();
        }
        private void txtPurRate_EditValueChanged(object sender, EventArgs e)
        {
            CountTestCost();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            frmCountGoodsCostFind frm = new frmCountGoodsCostFind();
            frm.ShowDialog();
            if (getID != "")
            {
                txtID.Text = getID;
                LoadData();
            }

            frm.Dispose();
            if (xtc1.SelectedTabPage == xtp2)
            {
                FillGoodsPart();
                LoadGoodsDetails();
            }
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            frmCountGoodsCostFindGoods frm = new frmCountGoodsCostFindGoods();
            frm.ShowDialog();
            if (getID != "" && newMode == 1)
            {
                txtProductId.Text = getID;
                GetGoodsF0();
            }

            frm.Dispose();
        }

        private void btnFindProductPart_Click(object sender, EventArgs e)
        {
            frmCountGoodsCostFindGoods frm = new frmCountGoodsCostFindGoods();
            frm.ShowDialog();
            if (getID != "")
            {
                txtProductIdPart.Text = getID;
                GetProductDataPart();
            }

            frm.Dispose();
        }

        private void txtPlateWasteRate_EditValueChanged(object sender, EventArgs e)
        {
            SumTotalCost();
        }
        /// <summary>
        /// ///改變工廠利潤率，重新統計合計成本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProcessProfitRate_Leave(object sender, EventArgs e)
        {
            SumProcessCost();
            SumTotalCost();
        }

        /// <summary>
        /// ///儲存工序
        /// </summary>
        private void SavePurPrice()
        {
            if (txtSN.Text.Trim() == "")
            {
                MessageBox.Show("產品主表記錄編號不存在，儲存無效!");
                return;
            }
            string result = "";
            List<mdlPurPrice> lsPurPrice = new List<mdlPurPrice>();
            for (int i = 0; i < dtPurPrice.Rows.Count; i++)
            {
                DataRow dr = dtPurPrice.Rows[i];
                mdlPurPrice objPurPrice = new mdlPurPrice();
                string seq = dr["Seq"].ToString().Trim();
                string brandID= dr["BrandID"].ToString().Trim();
                float purPriceRate = clsValidRule.ConvertStrToSingle(dr["PurPriceRate"].ToString());
                float purPricePcs = clsValidRule.ConvertStrToSingle(dr["PurPricePcs"].ToString());
                float purPriceGrs = clsValidRule.ConvertStrToSingle(dr["PurPriceGrs"].ToString());
                float purPriceK = clsValidRule.ConvertStrToSingle(dr["PurPriceK"].ToString());
                if (seq == "" && brandID=="" && purPriceRate==0 && purPricePcs == 0 && purPriceGrs == 0 && purPriceK == 0)
                { }
                else
                {
                    objPurPrice.UpperSN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : 0;
                    objPurPrice.Seq = seq;
                    objPurPrice.BrandID = brandID;
                    objPurPrice.PurPriceRate = purPriceRate;
                    objPurPrice.PurPricePcs = purPricePcs;
                    objPurPrice.PurPriceGrs = purPriceGrs;
                    objPurPrice.PurPriceK = purPriceK;

                    lsPurPrice.Add(objPurPrice);
                }
            }
            if (lsPurPrice.Count > 0)
                result = clsCountGoodsCost.SavePurPrice(lsPurPrice);
            int SN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : -999;
            LoadPurPriceDetails(SN);
        }

        private void btnSavePur_Click(object sender, EventArgs e)
        {
            SavePurPrice();
        }

        private void btnAddPur_Click(object sender, EventArgs e)
        {
            dtPurPrice.Rows.Add();
        }

        private void repositoryItemButtonEdit21_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.Trim() == "")
            {
                MessageBox.Show("產品主表記錄編號不存在,刪除無效!");
                return;
            }
            int rowIndex = gvPurPriceDetails.FocusedRowHandle;
            DataRow Row = dtPurPrice.Rows[rowIndex];
            if (Row["Seq"].ToString().Trim() != "")
            {
                int SN= txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : 0;
                string result = clsCountGoodsCost.DeletePurPrice(SN, Row["Seq"].ToString().Trim());
            }
            dtPurPrice.Rows.Remove(Row);
            //gvGoodsProcess.DeleteSelectedRows();
        }
        /// <summary>
        /// ///意向報價表格內容改變後執行的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPurPriceDetails_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            if (fname == "PurPriceRate")
            {
                int rowIndex = gvPurPriceDetails.FocusedRowHandle;
                DataRow dr = dtPurPrice.Rows[rowIndex];
                float pricePcs = clsValidRule.ConvertStrToSingle(txtSalePricePcs.Text.Trim());
                float priceGrs = clsValidRule.ConvertStrToSingle(txtSalePriceGrs.Text.Trim());
                float priceK = clsValidRule.ConvertStrToSingle(txtSalePriceK.Text.Trim());
                float purPriceRate = clsValidRule.ConvertStrToSingle(dr["PurPriceRate"].ToString()) / 100;
                dr["PurPricePcs"] = Math.Round(pricePcs * (1 + purPriceRate), 4);
                dr["PurPriceGrs"] = Math.Round(priceGrs * (1 + purPriceRate), 2);
                dr["PurPriceK"] = Math.Round(priceK * (1 + purPriceRate), 2);
            }
        }
        /// <summary>
        /// ///注銷所有報價記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.Trim() == "")
            {
                MessageBox.Show("產品主表記錄編號不存在,刪除無效!");
                return;
            }
            int SN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : 0;
            string result = clsCountGoodsCost.Delete(SN);
            if (result == "")
                MessageBox.Show("刪除主表記錄成功!");
            txtID.Text = "";
            LoadData();
           
        }
        /// <summary>
        /// 點擊刪除配件時，刪除配件的記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.Trim() == "")
            {
                MessageBox.Show("產品主表記錄編號不存在,刪除無效!");
                return;
            }

            DataRow Row = gvGoodsPartDetails.GetFocusedDataRow();
            int SN = Row["SN"].ToString() != "" ? Convert.ToInt32(Row["SN"].ToString()) : 0;
            if (SN == 0)
            {
                MessageBox.Show("配件的記錄編號不存在,刪除無效!");
                return;
            }
            
            string result = clsCountGoodsCost.DeleteItem(SN);
            if (result == "")
                MessageBox.Show("刪除配件記錄成功!");
            LoadData();
        }
    }
}
