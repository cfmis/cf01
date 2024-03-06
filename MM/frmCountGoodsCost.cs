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
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace cf01.MM
{
    public partial class frmCountGoodsCost : Form
    {
        public static DataTable dtGoodsPartDetails = new DataTable();
        private DataTable dtPurPrice = new DataTable();
        private DataTable dtMat = new DataTable();
        private DataTable dtProcess = new DataTable();
        private DataTable dtPlate = new DataTable();
        private DataTable dtPack = new DataTable();
        private DataTable dtFactory = new DataTable();
        private frmCountGoodsCostFind frmCountGoodsCostFind;
        private frmOrderHistory frmOrderHistory;
        frmCountGoodsCostFindGoods frmCountGoodsCostFindGoods;
        private mdlCountGoodsCostBase mdlCopyID = new mdlCountGoodsCostBase();
        public static int newMode = 0;
        private int newPartMode = 0;
        public static int copyMode = 0;
        private float baseQtyRate = 1000;
        public static string getID = "";
        public static float searchPrice = 0;
        public static float searchPriceWeg = 0;
        public static string searchPriceQtyUnit = "";
        public static string searchPriceWegUnit = "";
        public static string getVendID = "";
        public static string getVendName = ""; 
        public static string getQuoDate = "";
        public static string getQuoID = "";
        string factAddWasteRate = "";
        string compProfitRate = "";
        frmProcessBarWindows processBarWindows;
        int progressBar_Cnt2 = 0;
        int Coun = 100;
        int pausCnt = 20;

        public frmCountGoodsCost()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (CheckDeletePartStatus())
                return;
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CheckDeletePartStatus())
                return;
            txtID.Text = "";
            txtID.ReadOnly = true;
            LoadDataHead("ZZZZZZ");
            LoadGoodsPartToGrid(999999999);
            LoadPurPriceDetails(-999);
            txtTestQty.Text = "";
            txtFactAddWasteRate.Text = factAddWasteRate;//////工廠利潤率
            txtCompProfitRate.Text = compProfitRate;//////工廠利潤率
            ShowProductCost();
            //////默認新增配件
            LoadProductCostPart("ZZZ");
            CleanProductCostPart();
            //////清空配件中的記錄
            FillGoodsPart();
            LoadGoodsDetails();
            SumTotalCost();
            newPartMode = 0;
            newMode = 1;
        }
        private bool CheckDeletePartStatus()
        {
            bool result = false;
            if (newPartMode == 2)
            {
                MessageBox.Show("你已做過刪除項目，請重新儲存以確保數據的一致！");
                result = true;
            }
            return result;
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
                txtCustColor.Text = dr["CustColor"].ToString();
                txtPrdMo.Text = dr["PrdMo"].ToString();
                txtMdNo.Text = dr["MdNo"].ToString();
                lueMoGroup.EditValue = dr["MoGroup"].ToString() != "" ? dr["MoGroup"].ToString() : "";
                txtFactAddWasteRate.Text = dr["FactAddWasteRate"].ToString();
                txtCompProfitRate.Text = dr["CompProfitRate"].ToString();
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
                txtCustColor.Text = "";
                txtPrdMo.Text = "";
                txtMdNo.Text = "";
                lueMoGroup.EditValue = "";
                txtFactAddWasteRate.Text = factAddWasteRate;
                txtCompProfitRate.Text = compProfitRate;
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
        /// <summary>
        /// ///儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (xtc1.SelectedTabPage == xtp1)
            {
                //if (newMode == 0)
                //{
                //    MessageBox.Show("主表為非編輯狀態，請點擊新增!");
                //    return;
                //}
                txtProductName.Focus();
                SaveProductCostHead();
                
            }else
            {
                txtProductNamePart.Focus();
                SaveProductPartDetails();
            }
        }
        /// <summary>
        /// ///點擊儲存時，儲存第二個Tab中的所有項目
        /// </summary>
        private void SaveProductPartDetails()
        {
            progressBar_Cnt2 = 0;
            processBarWindows = new frmProcessBarWindows(0, Coun, "正在儲存配件數據，請稍候。。。");

            ShowProcessBar();

            if (txtSN.Text.Trim() == "")
                SaveProductCostHead();
            SavePorductCostPart();
            SaveProductCostMat(dtMat);//保存原料
            SaveGoodsCostProcess(dtProcess, "01");//保存部門加工費
            SaveGoodsCostProcess(dtPlate, "02");//保存外發加工費
            SaveGoodsCostProcess(dtPack, "03");//保存包裝費用
            SaveGoodsCostProcess(dtFactory, "04");//保存工廠皮費用
            newPartMode = 0;
            LoadGoodsDetails();//刷新、提取各種費用詳細
            //MessageBox.Show("配件記錄儲存成功!");

            HideProcessBar();
        }
        private void SaveProductCostHead()
        {
            ////// newMode=4  複製模式     newMode=1   新增模式
            mdlCountGoodsCost mdlGoods = new mdlCountGoodsCost();

            if (newMode != 4)//如果不是複製的
            {
                mdlGoods.ID = txtID.Text.Trim();
                mdlGoods.Ver = txtVer.Text == "" ? 0 : Convert.ToInt32(txtVer.Text);
            }
            else
            {
                mdlGoods.ID = mdlCopyID.ID;
                mdlGoods.Ver = mdlCopyID.Ver;
            }
            mdlGoods.ProductID = txtProductId.Text;
            mdlGoods.ProductName = txtProductName.Text;
            mdlGoods.ArtWork = txtArtWork.Text;
            mdlGoods.ArtWorkName = txtArtWorkName.Text;
            mdlGoods.ProductType = txtProductType.Text;
            mdlGoods.ProductTypeName = txtProductTypeName.Text;
            mdlGoods.ProductColor = txtColor.Text;
            mdlGoods.ProductColorName = txtColorName.Text;
            mdlGoods.CustColor = txtCustColor.Text;
            mdlGoods.ProductSize = txtSize.Text;
            mdlGoods.ProductSizeName = txtSizeName.Text;
            mdlGoods.PrdMo = txtPrdMo.Text.Trim();
            mdlGoods.MdNo = txtMdNo.Text.Trim();
            mdlGoods.MoGroup = lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString().Trim() : "";
            mdlGoods.FactAddWasteRate = clsValidRule.ConvertStrToSingle(txtFactAddWasteRate.Text);
            mdlGoods.CompProfitRate = clsValidRule.ConvertStrToSingle(txtCompProfitRate.Text);
            mdlGoods.Remark = txtRemark.Text.Trim();
            string result = clsCountGoodsCost.Save(mdlGoods);
            if (newMode != 4)//如果是複製的，就不用執行以下
            {
                txtID.Text = result;
                txtID.ReadOnly = false;
                LoadDataHead(txtID.Text);//儲存後要執行這個以產生SN
                //新增狀態、複製配件狀態，如果有配件的，就儲存
                SavePorductPart();
                //if (newMode == 1 || newMode == 5)
                //else if ()//儲存複製的配件
                //    DoCopy();
                SavePurPrice();//儲存意向報價表
                newMode = 0;
                //MessageBox.Show("主表記錄儲存成功!");
                LoadData();
            }
            
            //LoadDataHead(txtID.Text.Trim());
            
        }

        private void frmCountGoodsCost_Load(object sender, EventArgs e)
        {
            InitData();
            
        }
        private void InitData()
        {
            //初始化配件表，以便在查詢畫面中，做複製的時候，有表的結構可以儲存值
            LoadGoodsPartToGrid(-999);
            newMode = 1;
            
            BindData();
        }
        private void BindData()
        {
            //gcMatDetails.DataSource = dtMat;
            //gcGoodsProcess.DataSource = dtProcess;
            //////主表中顯示利潤率
            DataTable dtProfit = clsBaseData.LoadProcessType("CP_PROFIT", "");
            factAddWasteRate = dtProfit.Rows[0]["use_weg"].ToString();
            compProfitRate = dtProfit.Rows[0]["product_qty"].ToString();
            txtFactAddWasteRate.Text = factAddWasteRate;//工廠附加損耗率
            txtCompProfitRate.Text = compProfitRate;//////公司利潤率
            //////組別
            //////外發加工的部門
            lueMoGroup.Properties.DataSource = clsBaseData.LoadMoGroup("");
            lueMoGroup.Properties.ValueMember = "group_id";
            lueMoGroup.Properties.DisplayMember = "group_desc";
            //////單位
            lueTestUnit.Properties.DataSource = clsBs_Unit.LoadUnit("0");
            lueTestUnit.Properties.ValueMember = "unit_id";
            lueTestUnit.Properties.DisplayMember = "unit_cdesc";
            lueTestUnit.EditValue = "PCS";

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
            //////原料表格中綁定貨幣代號
            repositoryItemLookUpEdit30.DataSource = clsBaseData.LoadCurr("");
            repositoryItemLookUpEdit30.ValueMember = "curr_id";
            repositoryItemLookUpEdit30.DisplayMember = "curr_cdesc";
            repositoryItemLookUpEdit30.ImmediatePopup = true;
            repositoryItemLookUpEdit30.SearchMode = SearchMode.OnlyInPopup;
            //////表格中的加工費的部門
            repositoryItemLookUpEdit11.DataSource = clsBaseData.loadDep();
            repositoryItemLookUpEdit11.ValueMember = "dep_id";
            repositoryItemLookUpEdit11.DisplayMember = "dep_cdesc";
            repositoryItemLookUpEdit11.ImmediatePopup = true;
            repositoryItemLookUpEdit11.SearchMode = SearchMode.OnlyInPopup;
            //repositoryItemLookUpEdit11.PopupFilterMode = PopupFilterMode.Contains;
            //repositoryItemLookUpEdit11.TextEditStyle = TextEditStyles.Standard;

            //repositoryItemLookUpEdit11.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
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
            
            //////工廠總成本
            float factAddRate= clsValidRule.ConvertStrToSingle(txtFactAddWasteRate.Text) / 100;
            txtFactoryPricePcs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProductCostPcs.Text) * (1 + factAddRate), 4).ToString();
            txtFactoryPriceGrs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProductCostGrs.Text) * (1 + factAddRate), 4).ToString();
            txtFactoryPriceK.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtProductCostK.Text) * (1 + factAddRate), 2).ToString();
            //////公司利潤
            float profitRate = clsValidRule.ConvertStrToSingle(txtCompProfitRate.Text) / 100;
            txtSalePricePcs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtFactoryPricePcs.Text) * (1 + profitRate), 4).ToString();
            txtSalePriceGrs.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtFactoryPriceGrs.Text) * (1 + profitRate), 2).ToString();
            txtSalePriceK.Text = Math.Round(clsValidRule.ConvertStrToSingle(txtFactoryPriceK.Text) * (1 + profitRate), 2).ToString();
            //////試算表
            float unitRate = 0;
            float Qty = clsValidRule.ConvertStrToSingle(txtTestQty.Text);
            unitRate = clsBaseData.GetUnitRate(lueTestUnit.EditValue != null ? lueTestUnit.EditValue.ToString().Trim() : "");
            float qtyPcs = Qty * unitRate;
            //////成本金額
            txtFactoryAmt.Text= Math.Round(qtyPcs * clsValidRule.ConvertStrToSingle(txtFactoryPricePcs.Text), 4).ToString();
            //////公司含利潤金額
            txtProfitAmt.Text = Math.Round(qtyPcs * clsValidRule.ConvertStrToSingle(txtSalePricePcs.Text), 4).ToString();
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
        /// 如果不存在的默認添加5行空記錄
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
                for (int i = 0; i < 5; i++)
                {
                    DataRow Row = dtPurPrice.NewRow();
                    Row["Seq"] = GenSeqNo(gvPurPriceDetails, "Seq");
                    dtPurPrice.Rows.Add(Row);
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
            float multRate = 0;
            for (int i = 0; i < dtGoodsPartDetails.Rows.Count; i++)
            {
                DataRow dr = dtGoodsPartDetails.Rows[i];
                multRate= clsValidRule.ConvertStrToSingle(dr["MultRate"].ToString());
                costPCS += clsValidRule.ConvertStrToSingle(dr["FactoryCostPcs"].ToString()) * multRate;
                costGRS += clsValidRule.ConvertStrToSingle(dr["FactoryCostGrs"].ToString()) * multRate;
                costK += clsValidRule.ConvertStrToSingle(dr["FactoryCostK"].ToString()) * multRate;
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
            if (newPartMode == 1)
            {
                var dls = MessageBox.Show("當前記錄未儲存,需要儲存嗎?", "系統信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dls == DialogResult.Yes)
                    btnSave_Click(sender, e);
                else if (dls == DialogResult.Cancel)
                    return;
            }
            if (CheckDeletePartStatus())
                return;
            CleanProductCostPart();
            LoadProductCostPart("ZZZ");
            LoadGoodsDetails();
            
            SumTotalCost();
        }
        private void CleanProductCostPart()
        {
            //for(int i=0;i<dtMat.Rows.Count;i++)
            //{
            //    dtMat.Rows[i]["Seq"] = "";
            //}
            //for (int i = 0; i < dtProcess.Rows.Count; i++)
            //{
            //    dtProcess.Rows[i]["Seq"] = "";
            //}
            //for (int i = 0; i < dtPlate.Rows.Count; i++)
            //{
            //    dtPlate.Rows[i]["Seq"] = "";
            //}
            //for (int i = 0; i < dtPack.Rows.Count; i++)
            //{
            //    dtPack.Rows[i]["Seq"] = "";
            //}
            //for (int i = 0; i < dtFactory.Rows.Count; i++)
            //{
            //    dtFactory.Rows[i]["Seq"] = "";
            //}
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
            newPartMode = 1;
            txtMultRate.Text = "1";
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
                txtMultRate.Text = dr["MultRate"].ToString();
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
                txtMultRate.Text = "1";
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
            dr["Curr"] = "HKD";
            string Seq = GenSeqNo(gvMatDetails, "Seq");
            dr["Seq"] = Seq;
            dtMat.Rows.Add(dr);

            //////加一筆對應的外發
            DataRow Row = dtPlate.NewRow();
            Row["Seq"] = GenSeqNo(gvGoodsPlate, "Seq");
            Row["PrdDep"] = "501";
            Row["ProcessUnit"] = "PCS";
            Row["WegUnit"] = "KG";
            Row["WasteRate"] = "1.1";
            Row["PSeq"] = Seq;
            dtPlate.Rows.Add(Row);

        }
        private string GenSeqNo(GridView gv,string fName)
        {
            string Seq = "";
            string MaxSeq = "000";
            for (int i = 0; i < gv.DataRowCount; i++)
            {
                Seq = gv.GetDataRow(i)[fName].ToString().Trim();
                MaxSeq = string.Compare(MaxSeq, Seq) >= 0 ? MaxSeq : Seq;
            }
            int MaxSeqInt = Convert.ToInt32(MaxSeq);
            Seq = (MaxSeqInt + 1).ToString().PadLeft(3, '0');
            return Seq;
        }
        /// ///添加原料時，選擇不同原料顯示對應的資料
        private void gvMatDetails_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string fname = e.Column.FieldName.ToString();
            int rowIndex = gvMatDetails.FocusedRowHandle;
            double matWeg = 0;
            float wasteRate = 0;
            double matWaste = 0;
            double matUse = 0;
            DataRow dr = dtMat.Rows[rowIndex];
            string matType = "";
            string matCode = dr["MatCode"].ToString().Trim();
            if (matCode.Length > 1)
                matType = matCode.Substring(0, 1);
            if (fname== "MatCode")
            {
                
                DataTable dtMatType = clsBaseData.LoadProcessType("MAT_CODE", matCode);
                if(dtMatType.Rows.Count>0)
                {
                    DataRow drMatType = dtMatType.Rows[0];
                    dr["MatName"] = drMatType["process_name"].ToString().Trim();
                    wasteRate = clsValidRule.ConvertStrToSingle(drMatType["waste_rate"].ToString());
                    dr["WasteRate"] = wasteRate;
                    matWeg = Math.Round(clsValidRule.ConvertStrToSingle(drMatType["use_weg"].ToString()), 2);
                    dr["MatWeg"] = matWeg;
                    dr["MatPrice"] = Math.Round(clsValidRule.ConvertStrToSingle(drMatType["cost_price"].ToString()), 2);
                    dr["Curr"] = "HKD";
                    if (matType == "M")//如果是原料，自動計算原料用料
                    {
                        matUse = Math.Round(matWeg / (1 - (wasteRate / 100)), 4);
                        dr["MatWaste"] = matUse - matWeg;
                        dr["MatUse"] = matUse;
                        dr["MatPriceUnit"] = "KG";
                        
                    }else//matType=="Q" 如果是成品或半成品，按數量計算的，就不計算重量用料了
                    {
                        dr["MatWaste"] = 0;
                        dr["MatUse"] = matWeg;
                        dr["MatPriceUnit"] = "PCS";
                    }
                    CountMatCost();
                }
            }
            if (fname == "MatWeg" || fname == "WasteRate")
            {
                matWeg = Math.Round(clsValidRule.ConvertStrToSingle(dr["MatWeg"].ToString()), 2);
                wasteRate = clsValidRule.ConvertStrToSingle(dr["WasteRate"].ToString());
                if (matType == "M")//如果是原料，自動計算原料用料
                {
                    matUse = Math.Round(matWeg / (1 - (wasteRate / 100)), 4);
                    matWaste = matUse - matWeg;
                    dr["MatWaste"] = matWaste;
                    dr["MatUse"] = matUse;
                }
                else//matType=="Q" 如果是成品或半成品，按數量計算的，就不計算重量用料了
                {
                    dr["MatUse"] = matWeg;
                }
                CountMatCost();
            }
            if (fname == "MatWaste" || fname == "MatUse" || fname == "MatPrice" || fname== "MatPriceUnit" || fname == "Curr")
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
                decimal matWeg = clsValidRule.ConvertStrToDecimal(Row["MatWeg"].ToString());
                decimal matWaste = clsValidRule.ConvertStrToDecimal(Row["MatWaste"].ToString());
                decimal matPrice = clsValidRule.ConvertStrToDecimal(Row["MatPrice"].ToString());
                string matPriceUnit = Row["MatPriceUnit"].ToString();
                decimal matUse = Math.Round(matWeg + matWaste, 4);
                string Curr = Row["Curr"].ToString();
                decimal currRate = 1;
                decimal unitRate = 1;
                decimal matCost = 0;
                if (Curr != "HKD")
                    currRate = clsBaseData.GetMidRate(Curr);
                if (matPriceUnit != "KG" && matPriceUnit != "PCS")
                    unitRate = (decimal)clsBaseData.GetUnitRate(matPriceUnit);
                
                Row["MatUse"] = matUse;
                if (matPriceUnit == "KG")
                    matCost = Math.Round(matUse * matPrice * currRate, 4);
                else
                {
                    decimal wasteRate = clsValidRule.ConvertStrToDecimal(Row["WasteRate"].ToString()) / 100;
                    decimal baseQtyRate1 = (decimal)baseQtyRate;
                    matCost = Math.Round((matPrice / unitRate) * baseQtyRate1 * currRate * (1 + wasteRate), 4);
                }
                Row["MatCost"] = matCost;
                string Seq = Row["Seq"].ToString().Trim();
                FillPlateWeg(Seq, matWeg);
            }
            SumMatCost();
            //////因為外發加工費是根據重量來計算的，當重量改變時，加工費也要重新計算
            CountPlateCost();
            SumTotalCost();
            //////值已改變，重新計算皮費
            CountFactoryCost();

        }
        /// <summary>
        /// ///輸入原料重量時，自動填入到外發加工中
        /// </summary>
        /// <param name="Seq"></param>
        /// <param name="matWeg"></param>
        private void FillPlateWeg(string Seq, decimal matWeg)
        {
            for (int i=0;i<gvGoodsPlate.DataRowCount;i++)
            {
                var Row = gvGoodsPlate.GetDataRow(i);
                if (Row["PSeq"].ToString().Trim() == Seq)
                {
                    Row["ProcessWeg"] = matWeg;
                    break;
                }
            }
            CountPlateCost();
        }
        /// <summary>
        /// ///原料表格中，點擊查詢時轉到物料用料表，并帶入用料、損耗、廢料數值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit22_Click(object sender, EventArgs e)
        {
            getID = "";
            if (frmCountGoodsCostFindGoods == null)
            {
                frmCountGoodsCostFindGoods = new frmCountGoodsCostFindGoods();
            }
            frmCountGoodsCostFindGoods.ShowDialog();
            if (getID != "")
            {
                DataRow Row = gvMatDetails.GetFocusedDataRow();
                decimal matUse = 0;
                decimal matWeg = 0;
                decimal wasteRate = 0;
                decimal matWaste = 0;
                decimal defaultWasteRate = clsValidRule.ConvertStrToDecimal(Row["WasteRate"].ToString());
                string matCode = Row["MatCode"].ToString().Trim();
                DataTable dtMatType = clsBaseData.LoadProcessType("MAT_CODE", matCode);
                if (dtMatType.Rows.Count > 0)
                {
                    defaultWasteRate= clsValidRule.ConvertStrToDecimal(dtMatType.Rows[0]["waste_rate"].ToString());
                }
                matWeg = frmCountGoodsCostFindGoods.prdWeg;
                decimal newWasteRate = frmCountGoodsCostFindGoods.useWeg != 0 ? Math.Round((frmCountGoodsCostFindGoods.wasteWeg / frmCountGoodsCostFindGoods.useWeg) * 100, 2) : 0;
                //////如果損耗比默認的小的，取默認的
                wasteRate = newWasteRate < defaultWasteRate ? defaultWasteRate : newWasteRate;
                matUse = Math.Round(matWeg / (1 - (wasteRate / 100)), 4);
                matWaste = matUse - matWeg;
                Row["MatWeg"] = matWeg;
                Row["WasteRate"] = wasteRate;
                Row["MatWaste"] = matWaste;
                Row["MatUse"] = matUse;
                //////返回後設置焦點，不然數據不會更新
                ColumnView newview = (ColumnView)gcMatDetails.FocusedView;
                newview.FocusedColumn = newview.Columns["MatWeg"];//定位焦点网格的位置
                //int FocuseRow_Handle = newview.FocusedRowHandle;//获取新焦点行的FocuseRowHandle
                CountMatCost();
            }
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
            if (txtProductIdPart.Text.Trim() != "")
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
                txtProductTypePart.Text = drPrd["base_class"].ToString();
                txtProductTypeNamePart.Text = drPrd["prd_cdesc"].ToString();
                txtSizePart.Text = drPrd["size_id"].ToString();
                txtSizeNamePart.Text = drPrd["size_cdesc"].ToString();
                txtColorPart.Text = drPrd["color"].ToString();
                txtColorNamePart.Text = drPrd["clr_cdesc"].ToString();
                ////在新增狀態時，填入原料
                //if (newPartMode == 1 && drPrd["mat_item"].ToString() != "")
                //{
                //    DataRow drMat = dtMat.Rows[0];
                //    drMat["MatCode"] = drPrd["mat_item"].ToString();
                //    drMat["MatName"] = drPrd["mat_name"].ToString();
                //    drMat["MatWeg"] = drPrd["prd_weg"].ToString();
                //    drMat["MatWaste"] = drPrd["waste_weg"].ToString();
                //    drMat["MatUse"] = drPrd["use_weg"].ToString();
                //    CountMatCost();
                //}
            }
            else
            {
                txtProductNamePart.Text = "";
                txtArtWorkPart.Text = "";
                txtArtWorkNamePart.Text = "";
                txtArtWorkPart.Text = "";
                txtProductTypePart.Text = "";
                txtProductTypeNamePart.Text = "";
                txtSizePart.Text = "";
                txtSizeNamePart.Text = "";
                txtColorPart.Text = "";
                txtColorNamePart.Text = "";
                txtFrontPart.Text = "";
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
            
            //////提取部門工序加工費
            dtProcess = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "01");
            gcGoodsProcess.DataSource = dtProcess;
            
            //////提取外發加工費
            dtPlate = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "02");
            gcGoodsPlate.DataSource = dtPlate;
            
            //////提取包裝費用
            dtPack = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "03");
            gcGoodsPack.DataSource = dtPack;
            
            //////提取工廠皮費
            dtFactory = clsCountGoodsCost.LoadProductCostProcess(UpperSN, "04");
            gcGoodsFactory.DataSource = dtFactory;

            //////默認添加空記錄
            if (newPartMode == 1 || gvGoodsPartDetails.DataRowCount == 0)
            {
                string matSeq = "";
                if (dtMat.Rows.Count == 0)
                {
                    //gvMatDetails.AddNewRow();
                    //DataRow Row = gvMatDetails.GetFocusedDataRow();
                    //Row["MatPriceUnit"] = "KG";
                    ////dtMat.Rows[0]["MatPriceUnit"] = "KG";
                    DataRow dr = dtMat.NewRow();
                    dr["MatPriceUnit"] = "KG";
                    matSeq = GenSeqNo(gvMatDetails, "Seq");
                    dr["Seq"] = matSeq;
                    dtMat.Rows.Add(dr);
                }
                if (dtProcess.Rows.Count == 0)
                {
                    //gvGoodsProcess.AddNewRow();
                    //DataRow Row = gvGoodsProcess.GetFocusedDataRow();
                    //Row["ProcessUnit"] = "PCS";
                    ////dtMat.Rows[0]["MatPriceUnit"] = "KG";
                    for (int i = 0; i < 10; i++)
                    {
                        DataRow dr = dtProcess.NewRow();
                        dr["Seq"] = GenSeqNo(gvGoodsProcess, "Seq");
                        dr["ProcessUnit"] = "PCS";
                        dtProcess.Rows.Add(dr);
                    }
                }
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
                    Row["Seq"] = GenSeqNo(gvGoodsPlate, "Seq");
                    Row["PrdDep"] = "501";
                    Row["ProcessUnit"] = "PCS";
                    Row["WegUnit"] = "KG";
                    Row["WasteRate"] = "1.1";
                    Row["PSeq"] = matSeq;
                    dtPlate.Rows.Add(Row);
                }
                if (dtPack.Rows.Count == 0)
                {
                    //gvGoodsPack.AddNewRow();
                    //DataRow Row = gvGoodsPack.GetFocusedDataRow();
                    //Row["PrdDep"] = "601";
                    DataRow Row = dtPack.NewRow();
                    Row["Seq"] = GenSeqNo(gvGoodsPack, "Seq");
                    Row["PrdDep"] = "601";
                    dtPack.Rows.Add(Row);
                }
                if (dtFactory.Rows.Count == 0)
                {
                    DataRow Row = dtFactory.NewRow();
                    Row["Seq"] = GenSeqNo(gvGoodsFactory, "Seq");
                    Row["ProcessID"] = "QC01";
                    Row["ProcessBaseQty"] = 2;
                    Row["ProcessName"] = "測試費用";
                    dtFactory.Rows.Add(Row);
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
                txtMultRate.Text = Row["MultRate"].ToString();
            }
            else
            {
                CleanProductCostPartText();
            }
        }

        private void CleanProductCostPartText()
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
            txtMatWegTotal.Text = "";
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
            txtMultRate.Text = "1";
            newPartMode = 1;//默認為新增狀態
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
            mdlGoodsPpart.MultRate = txtMultRate.Text == "" ? 1 : Convert.ToInt32(txtMultRate.Text);
            mdlGoodsPpart.Remark = "";
            string result = clsCountGoodsCost.SaveGoodsPart(mdlGoodsPpart);
            txtSeqPart.Text = result;

            LoadProductCostPart(result);
        }
        /// <summary>
        /// ///儲存原料
        /// </summary>
        private void SaveProductCostMat(DataTable dtSave)
        {
            if (newMode == 1 || newPartMode == 1)
            {
                if (txtSNPart.Text.Trim() == "")
                {
                    MessageBox.Show("配件的記錄序號不存在,儲存無效!");
                    return;
                }
            }
            string result = "";
            List <mdlCountGoodsCostMat> lsGoodsMat = new List<mdlCountGoodsCostMat>();
            for (int i=0;i< dtSave.Rows.Count;i++)
            {
                DataRow dr = dtSave.Rows[i];
                string seq= dr["Seq"].ToString().Trim();
                float matCost = clsValidRule.ConvertStrToSingle(dr["MatCost"].ToString());
                if (seq == "" && matCost == 0)
                { }
                else
                {
                    mdlCountGoodsCostMat mdlGoodsMat = new mdlCountGoodsCostMat();
                    //if (newMode == 4 || newMode == 5)//如果不是複製的
                    //    mdlGoodsMat.UpperSN = mdlCopyID.SN;
                    //else
                    mdlGoodsMat.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                    mdlGoodsMat.Seq = dr["Seq"].ToString();
                    mdlGoodsMat.NewSeq = dr["NewSeq"].ToString();
                    mdlGoodsMat.MatCode = dr["MatCode"].ToString();
                    mdlGoodsMat.MatName = dr["MatName"].ToString();
                    mdlGoodsMat.MatWeg = clsValidRule.ConvertStrToSingle(dr["MatWeg"].ToString());
                    mdlGoodsMat.WasteRate = clsValidRule.ConvertStrToSingle(dr["WasteRate"].ToString());
                    mdlGoodsMat.MatWaste = clsValidRule.ConvertStrToSingle(dr["MatWaste"].ToString());
                    mdlGoodsMat.MatUse = clsValidRule.ConvertStrToSingle(dr["MatUse"].ToString());
                    mdlGoodsMat.MatPrice = clsValidRule.ConvertStrToSingle(dr["MatPrice"].ToString());
                    mdlGoodsMat.MatPriceUnit = dr["MatPriceUnit"].ToString();
                    mdlGoodsMat.Curr = dr["Curr"].ToString();
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
            if (newMode == 1 || newPartMode == 1)
            {
                if (txtSNPart.Text.Trim() == "")
                {
                    MessageBox.Show("產品主表記錄編號不存在，儲存無效!");
                    return;
                }
            }
            string result = "";
            List<mdlCountGoodsCostProcess> lsGoodsProcess = new List<mdlCountGoodsCostProcess>();
            for (int i = 0; i < dtSave.Rows.Count; i++)
            {
                DataRow dr = dtSave.Rows[i];
                mdlCountGoodsCostProcess mdlGoodsProcess = new mdlCountGoodsCostProcess();
                string Seq = dr["Seq"].ToString().Trim();
                string newSeq = dr["NewSeq"].ToString().Trim();
                float costK= clsValidRule.ConvertStrToSingle(dr["CostK"].ToString());
                float totalCostK = clsValidRule.ConvertStrToSingle(dr["TotalCostK"].ToString());
                if (newSeq == "" && costK == 0 && totalCostK == 0)
                { }
                else
                {
                    //if (newMode == 4 || newMode == 5)//如果是複製
                    //    mdlGoodsProcess.UpperSN = mdlCopyID.SN;
                    //else
                    mdlGoodsProcess.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                    mdlGoodsProcess.Seq = dr["Seq"].ToString().Trim();
                    mdlGoodsProcess.PSeq = dr["PSeq"].ToString().Trim();
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
                    else if (processType == "02")//外發加工費
                    {
                        mdlGoodsProcess.WegPrice = clsValidRule.ConvertStrToSingle(dr["WegPrice"].ToString());
                        mdlGoodsProcess.ProcessWeg = clsValidRule.ConvertStrToSingle(dr["ProcessWeg"].ToString());
                        mdlGoodsProcess.WegUnit = dr["WegUnit"].ToString();
                        mdlGoodsProcess.WegCost = clsValidRule.ConvertStrToSingle(dr["WegCost"].ToString());
                        mdlGoodsProcess.WasteRate = clsValidRule.ConvertStrToSingle(dr["WasteRate"].ToString());
                        mdlGoodsProcess.VendID = dr["VendID"].ToString();
                        mdlGoodsProcess.VendName = dr["VendName"].ToString();
                        mdlGoodsProcess.QuoDate= dr["QuoDate"].ToString();
                        mdlGoodsProcess.QuoID = dr["QuoID"].ToString();
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
            if (fname == "PrdDep" || fname == "ProcessID")//
            {
                DataTable dtProcessBase = clsBaseData.LoadProductProcess(Row["PrdDep"].ToString(), Row["ProcessID"].ToString(), "");
                if (dtProcessBase.Rows.Count > 0)
                {
                    DataRow dr = dtProcessBase.Rows[0];
                    Row["ProcessID"] = dr["process_id"].ToString();
                    Row["ProcessName"] = dr["process_name"].ToString();
                    Row["ProcessPrice"] = dr["PriceHKD"];
                    Row["ProcessBaseQty"] = dr["product_qty"];
                }
                else
                {
                    Row["ProcessID"] = "";
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
            frmCountGoodsCostFindProcess.getProcessId = "";// Row["ProcessID"].ToString();// txtProductId.Text;
            frmCountGoodsCostFindProcess.getProcessName = "";// txtProductName.Text;
            frmCountGoodsCostFindProcess.getDepId = Row["PrdDep"].ToString();
            frmCountGoodsCostFindProcess.modality = "PROCESS";
            searchPrice = 0;
            searchPriceWeg = 0;
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
                //////返回後設置焦點，不然數據不會更新
                ColumnView newview = (ColumnView)gcGoodsProcess.FocusedView;
                newview.FocusedColumn = newview.Columns["ProcessName"];//定位焦点网格的位置
                //int FocuseRow_Handle = newview.FocusedRowHandle;//获取新焦点行的FocuseRowHandle
            }

            frm.Dispose();
            
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            //gvGoodsProcess.AddNewRow();
            //DataRow Row = gvGoodsProcess.GetFocusedDataRow();
            //Row["ProcessUnit"] = "PCS";

            DataRow dr = dtProcess.NewRow();
            dr["Seq"] = GenSeqNo(gvGoodsProcess, "Seq");
            dr["ProcessUnit"] = "PCS";
            dtProcess.Rows.Add(dr);
        }

        private void btnAddPlate_Click(object sender, EventArgs e)
        {
            if(gvMatDetails.GetFocusedDataRow()==null)
            {
                MessageBox.Show("這個是由原料產生的，請新增一筆原料記錄!");
                return;
            }
            //gvGoodsPlate.AddNewRow();
            //DataRow Row = gvGoodsPlate.GetFocusedDataRow();
            DataRow Row = dtPlate.NewRow();
            Row["Seq"] = GenSeqNo(gvGoodsPlate, "Seq");
            Row["PrdDep"] = "501";
            Row["ProcessUnit"] = "PCS";
            Row["WegUnit"] = "KG";
            Row["WasteRate"] = "1.1";
            Row["PSeq"] = gvMatDetails.GetFocusedDataRow()["Seq"].ToString();
            Row["ProcessWeg"] = gvMatDetails.GetFocusedDataRow()["MatWeg"].ToString();
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
            //DataRow Row = gvGoodsPlate.GetFocusedDataRow();
            if (fname == "ProcessID" || fname == "ProcessName" || fname == "ProcessWeg" || fname == "ProcessPrice" || fname == "ProcessUnit" || fname == "WegPrice" || fname == "WegUnit" || fname == "WasteRate")
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
                float matWeg = clsValidRule.ConvertStrToSingle(Row["ProcessWeg"].ToString());
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
                //Row["PrdDep"] = frmProductCostingFindPrice.getDepId;
                Row["ProcessID"] = frmProductCostingFindPrice.getProductId;
                Row["ProcessName"] = frmProductCostingFindPrice.getProductName;
                Row["ProcessPrice"] = Math.Round(searchPrice, 4);
                Row["ProcessUnit"] = searchPriceQtyUnit;
                Row["WegPrice"] = Math.Round(searchPriceWeg, 4);
                Row["WegUnit"] = searchPriceWegUnit;
                Row["VendID"] = getVendID;
                Row["VendName"] = getVendName;
                Row["QuoDate"] = getQuoDate;
                Row["QuoID"] = getQuoID;
                CountPlateCost();
                //////返回後設置焦點，不然數據不會更新
                ColumnView newview = (ColumnView)gcGoodsPlate.FocusedView;
                newview.FocusedColumn = newview.Columns["ProcessName"];//定位焦点网格的位置
                //int FocuseRow_Handle = newview.FocusedRowHandle;//获取新焦点行的FocuseRowHandle
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
            Row["Seq"] = GenSeqNo(gvGoodsPack, "Seq");
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
            DataRow Row = dtFactory.NewRow();
            Row["Seq"] = GenSeqNo(gvGoodsFactory, "Seq");
            dtFactory.Rows.Add(Row);
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
        /// ///刪除原料表格中的明細記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit13_Click(object sender, EventArgs e)
        {
            //if (txtSNPart.Text.Trim() == "")
            //{
            //    MessageBox.Show("配件記錄不存在,刪除無效!");
            //    return;
            //}
            int rowIndex = gvMatDetails.FocusedRowHandle;
            DataRow Row = dtMat.Rows[rowIndex];
            string Seq = Row["Seq"].ToString().Trim();
            string newSeq = Row["NewSeq"].ToString().Trim();
            if (newSeq != "")
            {
                int UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                string result = clsCountGoodsCost.DeleteGoodsCostMat(UpperSN,Seq);
            }
            dtMat.Rows.Remove(Row);
            SumMatCost();
            SumTotalCost();//刪除後重新計算總成本
            newPartMode = 2;
            //if (newSeq != "")
            //{
            //    SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
            //}
        }

        /// <summary>
        /// 刪除表格中的部門加工費記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit12_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtProcess, "01", gvGoodsProcess.FocusedRowHandle);//刪除部門加工費
        }
        /// <summary>
        /// ///刪除外發加工費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit14_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtPlate, "02", gvGoodsPlate.FocusedRowHandle);//刪除外發加工費
        }

        private void repositoryItemButtonEdit15_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtPack, "03", gvGoodsPack.FocusedRowHandle);//刪除包裝費
        }

        private void repositoryItemButtonEdit16_Click(object sender, EventArgs e)
        {
            DeleteGoodsCostProcess(dtFactory, "04", gvGoodsFactory.FocusedRowHandle);//刪除工廠皮費
        }

        private void DeleteGoodsCostProcess(DataTable dt, string processType, int rowIndex)
        {
            //if(txtSNPart.Text.Trim()=="")
            //{
            //    MessageBox.Show("配件記錄編號不存在,刪除無效!");
            //    return;
            //}
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
            string Seq = Row["Seq"].ToString().Trim();
            string newSeq = Row["NewSeq"].ToString().Trim();
            if (newSeq != "")
            {
                mdlCountGoodsCostProcess mdlGoodsProcess = new mdlCountGoodsCostProcess();
                mdlGoodsProcess.UpperSN = txtSNPart.Text.Trim() != "" ? Convert.ToInt32(txtSNPart.Text) : 0;
                mdlGoodsProcess.Seq = Seq;
                mdlGoodsProcess.ProcessType = processType;
                string result = clsCountGoodsCost.DeleteGoodsCostProcess(mdlGoodsProcess);
            }
            dt.Rows.Remove(Row);
            SumMatCost();
            SumProcessCost();
            SumPlateCost();
            SumPackCost();
            SumFactoryCost();
            SumTotalCost();
            newPartMode = 2;
            //if (newSeq != "")
            //{
            //    SaveProductPartDetails();//刪除後重新儲存第二個Tap中的所有內容
            //}
            //gvGoodsProcess.DeleteSelectedRows();
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
            frmCountGoodsCostFindProcess.getProcessId = "";// Row["ProcessID"].ToString();// txtProductId.Text;
            frmCountGoodsCostFindProcess.getProcessName = "";// Row["ProcessName"].ToString();// txtProductName.Text;
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
                //////返回後設置焦點，不然數據不會更新
                ColumnView newview = (ColumnView)gcGoodsFactory.FocusedView;
                newview.FocusedColumn = newview.Columns["ProcessName"];//定位焦点网格的位置
                //int FocuseRow_Handle = newview.FocusedRowHandle;//获取新焦点行的FocuseRowHandle
            }

            frm.Dispose();
        }

        private void txtProductId_Leave(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
                return;
            //if (newMode == 1)
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
            if (newMode == 1)
            {
                LoadGoodsPartToGrid(-999);
                if (productID.Length > 2 && productID.Substring(0, 2) == "F0")
                {
                    DataTable dtGoodsBom = clsCountGoodsCost.getBomCid(productID);
                    for (int i=0;i<dtGoodsBom.Rows.Count;i++)
                    {
                        DataRow dr = dtGoodsBom.Rows[i];
                        DataRow Row = dtGoodsPartDetails.NewRow();
                        Row["Seq"] = GenSeqNo(gvGoodsPartDetails, "Seq");
                        Row["ProductID"] = dr["ProductID"];
                        Row["ProductName"] = dr["ProductName"];
                        Row["FrontPart"] = dr["FrontPart"];
                        dtGoodsPartDetails.Rows.Add(Row);
                    }
                }
            }
        }

        private void txtTestQty_TextChanged(object sender, EventArgs e)
        {
            CountTestCost();
        }

        private void lueTestUnit_EditValueChanged(object sender, EventArgs e)
        {
            CountTestCost();
        }
        private void txtFactAddWasteRate_EditValueChanged(object sender, EventArgs e)
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
            if (CheckDeletePartStatus())
                return;
            if (copyMode == 1)
            {
                if (MessageBox.Show("存在已複製而未儲存的記錄！需要儲存嗎？", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    return;
                else
                {
                    LoadData();
                    copyMode = 0;
                }
            }

            getID = "";
            newMode = 0;
            newPartMode = 0;
            if (frmCountGoodsCostFind == null)
            {
                frmCountGoodsCostFind = new frmCountGoodsCostFind();
            }

            frmCountGoodsCostFind.ShowDialog();
            //如果是查詢模式
            if (copyMode == 0)
            {
                if (getID != "")
                {
                    txtID.Text = getID;
                    LoadData();
                }

                if (xtc1.SelectedTabPage == xtp2)
                {
                    FillGoodsPart();
                    LoadGoodsDetails();
                }
            }
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            getID = "";
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
            getID = "";
            if (frmCountGoodsCostFindGoods == null)
            {
                frmCountGoodsCostFindGoods = new frmCountGoodsCostFindGoods();
            }
            frmCountGoodsCostFindGoods.ShowDialog();
            if (getID != "")
            {
                txtProductIdPart.Text = getID;
                GetProductDataPart();
            }
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
                if (brandID=="" && purPriceRate==0 && purPricePcs == 0 && purPriceGrs == 0 && purPriceK == 0)
                { }
                else
                {
                    if (newMode != 4)//如果不是複製模式
                    {
                        objPurPrice.UpperSN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : 0;
                        
                    }
                    else//如果是複製模式
                    {
                        objPurPrice.UpperSN = mdlCopyID.SN;
                    }
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
            if (newMode != 4)//如果不是複製模式
            {
                int SN = txtSN.Text.Trim() != "" ? Convert.ToInt32(txtSN.Text) : -999;
                LoadPurPriceDetails(SN);
            }
        }

        private void btnSavePur_Click(object sender, EventArgs e)
        {
            SavePurPrice();
        }

        private void btnAddPur_Click(object sender, EventArgs e)
        {
            DataRow Row = dtPurPrice.NewRow();
            Row["Seq"] = GenSeqNo(gvPurPriceDetails, "Seq");
            dtPurPrice.Rows.Add(Row);
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
            var dls = MessageBox.Show("確認注銷此單嗎?", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dls == DialogResult.No)
                return;
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
            if (CheckDeletePartStatus())
                return;
            if (txtSN.Text.Trim() == "")
            {
                MessageBox.Show("產品主表記錄編號不存在,刪除無效!");
                return;
            }

            DataRow Row = gvGoodsPartDetails.GetFocusedDataRow();
            if(Row==null)
            {
                MessageBox.Show("配件的記錄編號不存在,刪除無效!");
                return;
            }
            var dls = MessageBox.Show("確認刪除此配件嗎?", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dls == DialogResult.No)
                return;

            int SN = Row["SN"].ToString() != "" ? Convert.ToInt32(Row["SN"].ToString()) : 0;
            if (SN == 0)
            {
                MessageBox.Show("配件的記錄編號不存在,刪除無效!");
                return;
            }
            
            string result = clsCountGoodsCost.DeleteItem(SN);
            if (result == "")
            {
                MessageBox.Show("刪除配件記錄成功!");
                if (xtc1.SelectedTabPage == xtp2)
                {
                    //FillGoodsPart();
                    CleanProductCostPartText();
                    LoadGoodsDetails();
                }
                else
                    LoadData();
            }
            else
                MessageBox.Show(result);
        }
        /// <summary>
        /// ////複製新單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
                return;
            if (CheckDeletePartStatus())
                return;
            var dls = MessageBox.Show("確認將當前記錄複製成新單嗎?", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dls == DialogResult.No)
                return;
            newMode = 4;
            string newID = clsCountGoodsCost.GenID();
            mdlCopyID.ID = newID;
            mdlCopyID.Ver = 0;
            //string newID = "QT00000054";
            //mdlCopyID.ID = newID;
            //mdlCopyID.Ver = 0;
            SaveProductCostHead();//執行這個為了獲取SN
            DataTable dtSN = clsCountGoodsCost.CheckID(newID);
            mdlCopyID.SN = Convert.ToInt32(dtSN.Rows[0]["SN"]);
            SavePurPrice();//儲存意向報價表
            SavePorductPart();
            txtID.Text = newID;
            LoadData();
            MessageBox.Show("已複製成功!");
        }
        /// <summary>
        /// ///主表中儲存配件記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void SavePorductPart()
        {

            progressBar_Cnt2 = 0;
            processBarWindows = new frmProcessBarWindows(0, Coun, "正在儲存數據，請稍候。。。");

            ShowProcessBar();

            DoCopy(); //数据处理

            HideProcessBar();

        }
        private void DoCopy()
        {
            if (newMode != 4)//如果是項目複製，獲取主記錄的SN，以便作為配件表的UpperSN
            {
                mdlCopyID.SN = Convert.ToInt32(txtSN.Text.Trim());
            }
            //儲存配件表
            DataTable dtGoodsPartCopy = SaveCopyPorductCostPart();
            for (int i = 0; i < dtGoodsPartCopy.Rows.Count; i++)
            {
                int oldSN = Convert.ToInt32(dtGoodsPartCopy.Rows[i]["OldSN"]);
                //mdlCopyID.SN = Convert.ToInt32(dtGoodsPartCopy.Rows[i]["NewSN"]);
                //在儲存的時候要用到新的UpperSN的，所以要預先設定這個值
                txtSNPart.Text = dtGoodsPartCopy.Rows[i]["NewSN"].ToString();
                DataTable dtMatCopy = clsCountGoodsCost.LoadProductCostMat(oldSN);
                SaveProductCostMat(dtMatCopy);//複製原料
                DataTable dtProcessCopy = clsCountGoodsCost.LoadProductCostProcess(oldSN, "01");
                SaveGoodsCostProcess(dtProcessCopy, "01");//複製部門加工費
                DataTable dtPlateCopy = clsCountGoodsCost.LoadProductCostProcess(oldSN, "02");
                SaveGoodsCostProcess(dtPlateCopy, "02");//複製外發加工費
                DataTable dtPackCopy = clsCountGoodsCost.LoadProductCostProcess(oldSN, "03");
                SaveGoodsCostProcess(dtPackCopy, "03");//複製包裝費用
                DataTable dtFactoryCopy = clsCountGoodsCost.LoadProductCostProcess(oldSN, "04");
                SaveGoodsCostProcess(dtFactoryCopy, "04");//複製工廠皮費用
            }
        }
        /// <summary>
        /// ///儲存複製的配件
        /// </summary>
        private DataTable SaveCopyPorductCostPart()
        {
            //////用於記錄複製的
            DataTable dtGoodsPartCopy = new DataTable();
            dtGoodsPartCopy.Columns.Add("OldSN", typeof(int));
            dtGoodsPartCopy.Columns.Add("NewSN", typeof(int));
            for (int i=0;i< gvGoodsPartDetails.DataRowCount;i++)
            {
                DataRow Row = gvGoodsPartDetails.GetDataRow(i);
                //如果是整單複製的，因為NewSeq 是不為空的，以下也要執行
                //如果是單獨複製配件的，則NewSeq 是為空的，所以也執行
                if (Row["NewSeq"].ToString().Trim() == "" || newMode==4)
                {
                    mdlCountGoodsCostPart mdlGoodsPpart = new mdlCountGoodsCostPart();
                    mdlGoodsPpart = FillGoodsPartValue(Row);
                    mdlGoodsPpart.UpperSN = mdlCopyID.SN;

                    string result = clsCountGoodsCost.SaveGoodsPart(mdlGoodsPpart);
                    DataTable dtPartCopy = clsCountGoodsCost.LoadProductCostPart(mdlGoodsPpart.UpperSN, mdlGoodsPpart.Seq);
                    DataRow dr = dtGoodsPartCopy.NewRow();
                    dr["OldSN"] = Row["SN"];
                    dr["NewSN"] = dtPartCopy.Rows[0]["SN"];
                    dtGoodsPartCopy.Rows.Add(dr);
                }
            }
            return dtGoodsPartCopy;
        }
        private mdlCountGoodsCostPart FillGoodsPartValue(DataRow Row)
        {
            mdlCountGoodsCostPart mdlGoodsPpart = new mdlCountGoodsCostPart();
            mdlGoodsPpart.Seq = Row["Seq"].ToString();
            mdlGoodsPpart.ProductID = Row["ProductID"].ToString();
            mdlGoodsPpart.ProductName = Row["ProductName"].ToString();
            mdlGoodsPpart.ArtWork = Row["ArtWork"].ToString();
            mdlGoodsPpart.ArtWorkName = Row["ArtWorkName"].ToString();
            mdlGoodsPpart.ProductType = Row["ProductType"].ToString();
            mdlGoodsPpart.ProductTypeName = Row["ProductTypeName"].ToString();
            mdlGoodsPpart.FrontPart = Row["FrontPart"].ToString();
            mdlGoodsPpart.ProductSize = Row["ProductSize"].ToString();
            mdlGoodsPpart.ProductSizeName = Row["ProductSizeName"].ToString();
            mdlGoodsPpart.ProductColor = Row["ProductColor"].ToString();
            mdlGoodsPpart.ProductColorName = Row["ProductColorName"].ToString();
            mdlGoodsPpart.MatWeg = clsValidRule.ConvertStrToSingle(Row["MatWeg"].ToString());
            mdlGoodsPpart.MatUse = clsValidRule.ConvertStrToSingle(Row["MatUse"].ToString());
            mdlGoodsPpart.MatCost = clsValidRule.ConvertStrToSingle(Row["MatCost"].ToString());
            mdlGoodsPpart.ProcessCostTotal = clsValidRule.ConvertStrToSingle(Row["ProcessCostTotal"].ToString());
            mdlGoodsPpart.ProcessProfitRate = clsValidRule.ConvertStrToSingle(Row["ProcessProfitRate"].ToString());
            mdlGoodsPpart.ProcessProfit = clsValidRule.ConvertStrToSingle(Row["ProcessProfit"].ToString());
            mdlGoodsPpart.PlateCost = clsValidRule.ConvertStrToSingle(Row["PlateCost"].ToString());
            mdlGoodsPpart.PackCost = clsValidRule.ConvertStrToSingle(Row["PackCost"].ToString());
            mdlGoodsPpart.CostPcs = clsValidRule.ConvertStrToSingle(Row["CostPcs"].ToString());
            mdlGoodsPpart.CostGrs = clsValidRule.ConvertStrToSingle(Row["CostGrs"].ToString());
            mdlGoodsPpart.CostK = clsValidRule.ConvertStrToSingle(Row["CostK"].ToString());
            mdlGoodsPpart.FactoryFee = clsValidRule.ConvertStrToSingle(Row["FactoryFee"].ToString());
            mdlGoodsPpart.FactoryCostPcs = clsValidRule.ConvertStrToSingle(Row["FactoryCostPcs"].ToString());
            mdlGoodsPpart.FactoryCostGrs = clsValidRule.ConvertStrToSingle(Row["FactoryCostGrs"].ToString());
            mdlGoodsPpart.FactoryCostK = clsValidRule.ConvertStrToSingle(Row["FactoryCostK"].ToString());
            mdlGoodsPpart.Remark = Row["Remark"].ToString();
            return mdlGoodsPpart;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (CheckDeletePartStatus())
                return;
            LoadData();
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("沒有要匯出的記錄!");
                return;
            }
            FolderBrowserDialog saveFile = new FolderBrowserDialog();
            saveFile.Description = "請選擇文件路徑";
            DialogResult result = saveFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            { return; }

            //saveFile.Filter = "Excel files(*.xls)|*.xls";
            //saveFile.FilterIndex = 0;
            //saveFile.RestoreDirectory = true;
            ////saveFile.CreatePrompt = true;
            //saveFile.Title = "导出Excel文件到";
            string folderPath = saveFile.SelectedPath.Trim();

            string fileName = folderPath + "\\" + txtID.Text.ToString().Trim() + ".xls";// saveFile.FileName;
            progressBar_Cnt2 = 0;
            processBarWindows = new frmProcessBarWindows(0, Coun, "正在匯出數據，請稍候。。。");

            ShowProcessBar();
            ExpToExcel(fileName);
            HideProcessBar();
        }

        /// <summary>
        /// ///匯出報價單到Excel
        /// </summary>
        private void ExpToExcel(string fileName)
        {
            
            //SaveFileDialog saveFile = new SaveFileDialog();
            //OpenFileDialog saveFile = new OpenFileDialog();
            
             // 创建Excel应用程序对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            var ev = excel.Version;
            Microsoft.Office.Interop.Excel.Range excelRange;
            //excel.Visible = true;       //激活Excel
            Microsoft.Office.Interop.Excel.Workbook wBook = excel.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)wBook.ActiveSheet;
            int rowIndex = 1;
            int totalColumns = 18;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, totalColumns]];
            wSheet.Cells[rowIndex, 1] = "產品計價";
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            excelRange.Font.Size = 16;
            excelRange.Font.Bold = true;
            rowIndex ++;
            wSheet.Cells[rowIndex, 1] = "文件編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, 2]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 3] = txtID.Text;
            wSheet.Cells[rowIndex, 4] = "產品編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = txtProductId.Text;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 8] = "產品描述";
            wSheet.Cells[rowIndex, 9] = txtProductName.Text;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 9], wSheet.Cells[rowIndex, 12]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 13] = "產品尺寸";
            wSheet.Cells[rowIndex, 14] = txtSize.Text.ToString().Trim() + " " + txtSizeName.Text.ToString().Trim();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 14], wSheet.Cells[rowIndex, 15]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 16] = "版本";
            wSheet.Cells[rowIndex, 17] = txtVer.Text.ToString().Trim();
            DataTable dtGoods = clsCountGoodsCost.GetProductDataPart(txtProductId.Text.Trim());
            if (dtGoods.Rows.Count > 0)
            {
                string picPath = DBUtility.imagePath;// context.Server.MapPath("~/") + "images\\";
                string picName = dtGoods.Rows[0]["art_image"].ToString().Trim(); //"pencil.png";
                if (picName != "")
                {
                    //picName = picName.Replace("\\", "/");
                    picName = picPath + picName;
                    if (File.Exists(picName))
                    {
                        excelRange = wSheet.Range[wSheet.Cells[rowIndex, 18], wSheet.Cells[rowIndex, totalColumns]];
                        excelRange.Select();
                        float PicLeft, PicTop;
                        PicLeft = Convert.ToSingle(excelRange.Left + 2);
                        PicTop = Convert.ToSingle(excelRange.Top + 2);
                        wSheet.Shapes.AddPicture(picName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft, PicTop, 50, 50);
                        excelRange = wSheet.Range[wSheet.Cells[rowIndex, 18], wSheet.Cells[rowIndex + 1, 18]];
                        excelRange.MergeCells = true;//合併單元格

                    }

                    //wSheet.Cells[excelRow, 28] = file_d;
                }
            }
            rowIndex++;
            wSheet.Cells[rowIndex, 1] = "圖樣代號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, 2]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 3] = txtArtWork.Text;
            wSheet.Cells[rowIndex, 4] = "圖樣描述";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = txtArtWorkName.Text;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 8] = "產品類型";
            wSheet.Cells[rowIndex, 9] = txtProductType.ToString().Trim() + " " + txtProductTypeName.Text.ToString().Trim();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 9], wSheet.Cells[rowIndex, 12]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 13]= "產品顏色";
            wSheet.Cells[rowIndex, 14]= txtColor.Text.ToString().Trim() + " " + txtColorName.Text.ToString().Trim();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 14], wSheet.Cells[rowIndex, 15]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 16]= "組別";
            wSheet.Cells[rowIndex, 17] = lueMoGroup.EditValue != null ? lueMoGroup.EditValue : "";
            rowIndex++;
            wSheet.Cells[rowIndex, 1] = "制單編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, 2]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 3] = txtPrdMo.Text;
            wSheet.Cells[rowIndex, 4] = "新模編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = txtMdNo.Text;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 8] = "客戶顏色編號";
            wSheet.Cells[rowIndex, 9] = txtCustColor;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 9], wSheet.Cells[rowIndex, 12]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 13]= "備註";
            wSheet.Cells[rowIndex, 14]= txtRemark;
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 14], wSheet.Cells[rowIndex, 17]];
            excelRange.MergeCells = true;//合併單元格
            //顯示表格
            rowIndex++;
            wSheet.Cells[rowIndex, 1] = "序號";
            wSheet.Cells[rowIndex, 2] = "配件編號";
            wSheet.Cells[rowIndex, 3] = "配件描述";
            wSheet.Cells[rowIndex, 4] = "用量倍數";
            wSheet.Cells[rowIndex, 5] = "工廠合計成本/PCS";
            wSheet.Cells[rowIndex, 6] = "工廠合計成本/GRS";
            wSheet.Cells[rowIndex, 7] = "工廠合計成本/K";
            wSheet.Cells[rowIndex, 8] = "重量(Kg)/K";
            wSheet.Cells[rowIndex, 9] = "原料用料(Kg)/K";
            wSheet.Cells[rowIndex, 10] = "原料成本";
            wSheet.Cells[rowIndex, 11] = "部門加工費";
            wSheet.Cells[rowIndex, 12] = "外發加工成本";
            wSheet.Cells[rowIndex, 13] = "包裝物料費用";
            wSheet.Cells[rowIndex, 14] = "產品成本/PCS";
            wSheet.Cells[rowIndex, 15] = "產品成本/GRS";
            wSheet.Cells[rowIndex, 16] = "產品成本/K";
            wSheet.Cells[rowIndex, 17] = "其它成本";
            wSheet.Cells[rowIndex, 18] = "主件";

            rowIndex++;
            decimal factoryAmtPcs = 0, factoryAmtGrs = 0, factoryAmtK = 0;
            decimal multRate = 0;
            for (int i = 0; i < gvGoodsPartDetails.DataRowCount; i++)
            {
                DataRow dr = gvGoodsPartDetails.GetDataRow(i);
                wSheet.Cells[rowIndex, 1] = dr["Seq"].ToString();
                wSheet.Cells[rowIndex, 2] = dr["ProductID"].ToString();
                wSheet.Cells[rowIndex, 3] = dr["ProductName"].ToString();
                wSheet.Cells[rowIndex, 4] = dr["MultRate"].ToString();
                wSheet.Cells[rowIndex, 5] = dr["FactoryCostPcs"].ToString();
                wSheet.Cells[rowIndex, 6] = dr["FactoryCostGrs"].ToString();
                wSheet.Cells[rowIndex, 7] = dr["FactoryCostK"].ToString();
                wSheet.Cells[rowIndex, 8] = dr["MatWeg"].ToString();
                wSheet.Cells[rowIndex, 9] = dr["MatUse"].ToString();
                wSheet.Cells[rowIndex, 10] = dr["MatCost"].ToString();
                wSheet.Cells[rowIndex, 11] = dr["ProcessCostTotal"].ToString();
                wSheet.Cells[rowIndex, 12] = dr["PlateCost"].ToString();
                wSheet.Cells[rowIndex, 13] = dr["PackCost"].ToString();
                wSheet.Cells[rowIndex, 14] = dr["CostPcs"].ToString();
                wSheet.Cells[rowIndex, 15] = dr["CostGrs"].ToString();
                wSheet.Cells[rowIndex, 16] = dr["CostK"].ToString();
                wSheet.Cells[rowIndex, 17] = dr["FactoryFee"].ToString();
                wSheet.Cells[rowIndex, 18] = dr["FrontPart"].ToString();

                multRate= clsValidRule.ConvertStrToDecimal(dr["MultRate"].ToString());
                factoryAmtPcs += clsValidRule.ConvertStrToDecimal(dr["FactoryCostPcs"].ToString()) * multRate;
                factoryAmtGrs += clsValidRule.ConvertStrToDecimal(dr["FactoryCostGrs"].ToString()) * multRate;
                factoryAmtK += clsValidRule.ConvertStrToDecimal(dr["FactoryCostK"].ToString()) * multRate;
                rowIndex++;
            }
            wSheet.Cells[rowIndex, 3] = "產品合計成本(累加:配件成本 * 用量倍數)";
            wSheet.Cells[rowIndex, 5] = factoryAmtPcs;
            wSheet.Cells[rowIndex, 6] = factoryAmtGrs;
            wSheet.Cells[rowIndex, 7] = factoryAmtK;
            rowIndex++;
            wSheet.Cells[rowIndex, 3] = "工廠附加損耗率(%)";
            wSheet.Cells[rowIndex, 5] = txtFactAddWasteRate.Text;
            rowIndex++;
            wSheet.Cells[rowIndex, 3] = "工廠總成本 PCS/GRS/K";
            wSheet.Cells[rowIndex, 5] = txtFactoryPricePcs.Text;
            wSheet.Cells[rowIndex, 6] = txtFactoryPriceGrs.Text;
            wSheet.Cells[rowIndex, 7] = txtFactoryPriceK.Text;
            rowIndex++;
            wSheet.Cells[rowIndex, 3] = "含利潤價錢 PCS/GRS/K";
            wSheet.Cells[rowIndex, 5] = txtSalePricePcs.Text;
            wSheet.Cells[rowIndex, 6] = txtSalePriceGrs.Text;
            wSheet.Cells[rowIndex, 7] = txtSalePriceK.Text;

            wSheet.Columns[1].ColumnWidth = 3.75;
            wSheet.Columns[2].ColumnWidth = 13.75;
            wSheet.Columns[3].ColumnWidth = 24.38;
            wSheet.Columns[4].ColumnWidth = 3.63;
            wSheet.Columns[5].ColumnWidth = 7.38;
            wSheet.Columns[6].ColumnWidth = 8.25;
            wSheet.Columns[7].ColumnWidth = 8.5;
            wSheet.Columns[8].ColumnWidth = 10.13;
            wSheet.Columns[9].ColumnWidth = 8.38;
            wSheet.Columns[10].ColumnWidth = 8.38;
            wSheet.Columns[11].ColumnWidth = 8.38;
            wSheet.Columns[12].ColumnWidth = 6.63;
            wSheet.Columns[13].ColumnWidth = 7.38;
            wSheet.Columns[14].ColumnWidth = 7.25;
            wSheet.Columns[15].ColumnWidth = 7.38;
            wSheet.Columns[16].ColumnWidth = 5.25;
            wSheet.Columns[17].ColumnWidth = 6.25;

            wSheet.PageSetup.Zoom = 85;
            wSheet.Cells.Font.Size = 10;
            wSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;//纸张大小.XIPaperSize.xIPaperA3;//.xIPaperB4;//纸张大小
            wSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;//横向:纸张方向:豎向；XlPageOrientation.xlPortrait;
            wSheet.PageSetup.TopMargin = 12.5;
            wSheet.PageSetup.BottomMargin = 20;
            wSheet.PageSetup.LeftMargin = 12.5;
            wSheet.PageSetup.RightMargin = 12.5;
            
            excelRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[rowIndex, totalColumns]];
            excelRange.RowHeight = 30;
            //设置文本自動換行
            excelRange.WrapText = true;
            //设置边框
            excelRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            object m_objOpt = System.Reflection.Missing.Value;
            wBook.SaveAs(fileName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            wBook.Close();
            wBook = null;
            clsBaseData.NAR(wBook);
            excel.Quit();
            excel = null;
            clsBaseData.NAR(excel);
            GC.Collect();
            //MessageBox.Show("已匯出到Excel文件!");
        }
        
        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            if (CheckDeletePartStatus())
                return;

            //frmOrderHistory frm = new frmOrderHistory();
            //frm.ShowDialog();
            //frm.Dispose();

            if (frmOrderHistory == null)
            {
                frmOrderHistory = new frmOrderHistory();
            }

            frmOrderHistory.ShowDialog();

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

        private void txtSizePart_Leave(object sender, EventArgs e)
        {
            txtSizeNamePart.Text = "";
            if (txtSizePart.Text.Trim() != "")
            {
                DataTable dtSize = clsBaseData.GetSize(txtSizePart.Text.Trim());
                if(dtSize.Rows.Count>0)
                {
                    txtSizeNamePart.Text = dtSize.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtProductTypePart_Leave(object sender, EventArgs e)
        {
            txtProductTypeNamePart.Text = "";
            if (txtProductTypePart.Text.Trim() != "")
            {
                DataTable dtPrdType = clsBaseData.GetProductType(txtProductTypePart.Text.Trim());
                if (dtPrdType.Rows.Count > 0)
                {
                    txtProductTypeNamePart.Text = dtPrdType.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtArtWorkPart_Leave(object sender, EventArgs e)
        {
            txtArtWorkNamePart.Text = "";
            if (txtArtWorkPart.Text.Trim() != "")
            {
                DataTable dtArtwork = clsBaseData.GetArtwork(txtArtWorkPart.Text.Trim());
                if (dtArtwork.Rows.Count > 0)
                {
                    txtArtWorkNamePart.Text = dtArtwork.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtColorPart_Leave(object sender, EventArgs e)
        {
            txtColorNamePart.Text = "";
            if (txtColorPart.Text.Trim() != "")
            {
                DataTable dtColor = clsBaseData.GetColor(txtColorPart.Text.Trim());
                if (dtColor.Rows.Count > 0)
                {
                    txtColorNamePart.Text = dtColor.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtSize_Leave(object sender, EventArgs e)
        {
            txtSizeName.Text = "";
            if (txtSize.Text.Trim() != "")
            {
                DataTable dtSize = clsBaseData.GetSize(txtSize.Text.Trim());
                if (dtSize.Rows.Count > 0)
                {
                    txtSizeName.Text = dtSize.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtArtWork_Leave(object sender, EventArgs e)
        {
            txtArtWorkName.Text = "";
            if (txtArtWork.Text.Trim() != "")
            {
                DataTable dtArtwork = clsBaseData.GetArtwork(txtArtWork.Text.Trim());
                if (dtArtwork.Rows.Count > 0)
                {
                    txtArtWorkName.Text = dtArtwork.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtProductType_Leave(object sender, EventArgs e)
        {
            txtProductTypeName.Text = "";
            if (txtProductType.Text.Trim() != "")
            {
                DataTable dtPrdType = clsBaseData.GetProductType(txtProductType.Text.Trim());
                if (dtPrdType.Rows.Count > 0)
                {
                    txtProductTypeName.Text = dtPrdType.Rows[0]["name"].ToString().Trim();
                }
            }
        }

        private void txtColor_Properties_Leave(object sender, EventArgs e)
        {
            txtColorName.Text = "";
            if (txtColor.Text.Trim() != "")
            {
                DataTable dtColor = clsBaseData.GetColor(txtColor.Text.Trim());
                if (dtColor.Rows.Count > 0)
                {
                    txtColorName.Text = dtColor.Rows[0]["name"].ToString().Trim();
                }
            }
        }
    }
}
