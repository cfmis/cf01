using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;//反射
using cf01.MDL;
using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.MM
{
    public partial class frmProductCosting : Form
    {
        public static string searchProductId = "";
        public static string searchProductMo = "";
        public static string searchProductName = "";
        public static string searchDepId = "";
        public static decimal searchPrice = 0;
        public static decimal searchPricePcs = 0;
        public static mdlDepPrice sentDepPrice = new mdlDepPrice();
        private bool firstLevel;
        private bool firstCount;
        private DataTable dtBomDetails = new DataTable();
        private double hkd_rmb_rate = 1.176;
        private frmProductCostingFind frmProductCostingFind;
        public frmProductCosting()
        {
            InitializeComponent();
        }
        private void frmProductCosting_Load(object sender, EventArgs e)
        {
            dgvBomDetails.AutoGenerateColumns = false;
            dgvWipData.AutoGenerateColumns = false;
            initBomDataTable();
            for (int i = 0; i < this.dgvBomDetails.Columns.Count; i++)
            {
                this.dgvBomDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            searchProductId = "";
            searchProductMo = "";
            searchProductName = "";
            searchDepId = "";
            searchPrice = 0;
            if (frmProductCostingFind != null)
                frmProductCostingFind.Dispose();
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchProductId = txtProductId.Text;
            if (frmProductCostingFind == null)
            {
                frmProductCostingFind = new frmProductCostingFind();
                frmProductCostingFind.searchProductMo = txtProductMo.Text;
                frmProductCostingFind.ShowDialog();
            }
            else
            {
                //frmProductCostingFind.Visible = true;
                frmProductCostingFind.ShowDialog();
            }
            if (searchProductId != "")
            {
                txtProductId.Text = searchProductId;
                txtProductName.Text = searchProductName;
                txtProductMo.Text = searchProductMo;
                firstCount = true;
                showBomTree(searchProductMo, searchProductId, searchProductName);
                firstCount = false;
            }
            //frmProductCostingFind.Dispose();
            chkSelectAll.Checked = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dgvBomDetails.Rows.Count == 0)
                return;
            DataGridViewRow dgr = dgvBomDetails.Rows[0];
            txtProductId.Text = dgr.Cells["colProductId"].Value.ToString();
            txtProductName.Text = dgr.Cells["colProductName"].Value.ToString();
            //txtProductMo.Text = dgr.Cells["colProductMo"].Value.ToString();
            showBomTree(txtProductMo.Text, txtProductId.Text, txtProductName.Text);
            chkSelectAll.Checked = false;
        }
        private void showBomTree(string productMo, string productId, string productName)
        {
            if (txtProductId.Text.Trim() == "")
            {
                MessageBox.Show("沒有產品記錄!");
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            DataTable dtWipData = clsProductCosting.getWipData(productMo);//獲取制單的生產流程
            dgvWipData.DataSource = dtWipData;

            //**********************
            initTreeView(productId, productName); //將BOM以TreeView的形式顯示
            //doBomTreeView();//遍歷TreeView，將Tree的記錄重新插入到dtBomDetails表中
            exeBomTreeView();//遍歷TreeView，將Tree的記錄重新插入到dtBomDetails表中
            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        #region　調用遞歸，將BOM賦值到TreeView中
        protected void initTreeView(string productId, string productName)
        {
            //initBomDataTable();//初始化一個空表:dtBomDetails，將Tree展開的記錄重新填回到這個表中
            tvBom.Nodes.Clear();

            //DataTable dtWipData = clsProductCosting.getWipData(productMo);//獲取制單的生產流程
            //dgvWipData.DataSource = dtWipData;
            //添加主菜单
            TreeNode TopNode;
            //獲取首層F0
            //DataTable dtBom_h = clsProductCosting.getBomPid(pid);
            //if (dtBom_h.Rows.Count > 0)
            //{
            //string id = dtBom_h.Rows[0]["id"].ToString();
            //string goods_id = dtBom_h.Rows[0]["goods_id"].ToString();
            //string goods_name = dtBom_h.Rows[0]["goods_name"].ToString();
            TopNode = new TreeNode();
            TopNode.Text = productId + "[" + productName + "]";
            TopNode.Tag = productId;//goods_id ;//保存表單名
            TopNode.ImageIndex = 2;
            tvBom.Nodes.Add(TopNode);
            addChildNodeBom(TopNode, productId);//递归调用，從Bom表中生成TreeView
            tvBom.ExpandAll();//展開

            //}

        }
        #endregion
        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        #region 递归调用方法，添加菜单的子菜单
        public void addChildNodeBom(TreeNode subNode, string pid)
        {

            TreeNode subNode1;
            DataTable dtBom_d = clsProductCosting.getBomCid(pid);
            if (dtBom_d.Rows.Count == 0)
            {
                subNode.ImageIndex = 3;
            }
            else
            {
                for (int i = 0; i < dtBom_d.Rows.Count; i++)
                {
                    string ppid = dtBom_d.Rows[i]["d_goods_id"].ToString();
                    string goods_name = dtBom_d.Rows[i]["d_goods_name"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "[" + goods_name + "]";//实例化一个菜单项
                    subNode1.Tag = ppid;//保存表單名
                    subNode1.ImageIndex = 2;
                    subNode.Nodes.Add(subNode1);
                    addChildNodeBom(subNode1, ppid);//递归调用的方法                     
                    //InitMenu(ppid);
                    //}
                }
            }

        }
        #endregion
        #region 從生產計劃中生成BOM,暫不用
        protected void genBomTree(string pid)
        {

            initBomDataTable();
            tvBom.Nodes.Clear();
            string productMo = txtProductMo.Text.Trim();
            DataTable dtWipData = clsProductCosting.getWipData(productMo);
            dgvWipData.DataSource = dtWipData;
            //添加主菜单
            TreeNode TopNode;
            //獲取首層F0
            //DataTable dtBom_h = clsProductCosting.getBomFromOc(productMo, pid);
            //if (dtBom_h.Rows.Count > 0)
            //{
            //string goods_id = dtBom_h.Rows[0]["goods_id"].ToString();
            //string goods_name = dtBom_h.Rows[0]["goods_name"].ToString();
            TopNode = new TreeNode();
            TopNode.Text = searchProductId + "[" + searchProductName + "]";
            TopNode.Tag = searchProductId;//id;//保存表單名
            TopNode.ImageIndex = 2;
            tvBom.Nodes.Add(TopNode);
            addChildNode(TopNode, productMo, searchProductId);//递归调用
            tvBom.ExpandAll();//展開
            //doBomTreeView();
            exeBomTreeView();
            //TopNode.ImageIndex = TopNode.SelectedImageIndex = 2;                        
            //}

        }
        #endregion
        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        #region 從生產計劃中生成BOM,暫不用
        public void addChildNode(TreeNode subNode, string mo_id, string pid)
        {

            TreeNode subNode1;
            DataTable dtBom_d = clsProductCosting.getBomCidFromWip(mo_id, pid);
            if (dtBom_d.Rows.Count == 0)
            {
                subNode.ImageIndex = 3;
            }
            else
            {
                for (int i = 0; i < dtBom_d.Rows.Count; i++)
                {
                    string ppid = dtBom_d.Rows[i]["d_goods_id"].ToString();
                    string goods_name = dtBom_d.Rows[i]["d_goods_name"].ToString();
                    //string dept_id = "";
                    ////獲取配件的生產部門
                    //DataTable dtDep = clsProductCosting.getBomItemDepFromWip(mo_id, ppid);
                    //if (dtDep.Rows.Count > 0)
                    //    dept_id = dtDep.Rows[0]["dept_id"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "[" + goods_name + "]";//实例化一个菜单项
                    subNode1.Tag = ppid;// d_id;//保存表單名
                    subNode1.ImageIndex = 2;
                    subNode.Nodes.Add(subNode1);
                    addChildNode(subNode1, mo_id, ppid);//递归调用的方法
                    //InitMenu(ppid);
                    //}
                }
            }

        }
        #endregion

        #region 遍歷TreeView，將Tree的記錄重新插入到dtBomDetails表中---遞歸方法一
        //Bom在Tree中顯示後，再遞歸Tree控件，將所有子件加入到Table中，以表格的形式顯示
        private void doBomTreeView()
        {
            initBomDataTable();//初始化一個空表:dtBomDetails，將Tree展開的記錄重新填回到這個表中
            #region 递归
            //1.获取TreeView的所有根节点
            foreach (TreeNode tn in tvBom.Nodes)
            {
                expandBomTree(tn);
            }
            #endregion
            dgvBomDetails.DataSource = dtBomDetails;
            if (dtBomDetails.Rows.Count > 0)
            {

                for (int i = dtBomDetails.Rows.Count - 1; i >= 0; i--)
                {
                    //重新查找數據後，若該主件是未設定成本的，則自動計算每一件的成本：從最後的記錄開始，倒序重新計算每件的子件累計成本及產品成本，直到頂層
                    //if ((bool)dgvBomDetails.Rows[i].Cells["colIsSetFlag"].Value == false)
                    //countAllItemCost(dgvBomDetails.Rows.Count - 1);
                    countProductCostingRoll(i);
                }
                //并初始化將文本框記錄顯示定位到頂層主件的記錄
                fillControlsValue(0);
            }

        }

        private void expandBomTree(TreeNode tn)
        {

            addBomTreeToTable(tn);// 將每個節點插入到DataTable中
            foreach (TreeNode tnSub in tn.Nodes)
            {
                expandBomTree(tnSub);
            }
        }
        #endregion

        #region 遍歷TreeView，將TreeView的記錄重新插入到dtBomDetails表中---遞歸方法二
        private void exeBomTreeView()
        {
            initBomDataTable();//初始化一個空表:dtBomDetails，將Tree展開的記錄重新填回到這個表中
            diGuiTreeViewNode(tvBom.Nodes);
            dgvBomDetails.DataSource = dtBomDetails;
            if (dtBomDetails.Rows.Count > 0)
            {
                //for (int i = dtBomDetails.Rows.Count - 1; i >= 0; i--)
                //{
                //    countProductWeightRoll(i);
                //}
                countProductWeightRoll(dtBomDetails.Rows.Count);
                for (int i = dtBomDetails.Rows.Count - 1; i >= 0; i--)
                {
                    ////重新查找數據後，若該主件是未設定成本的，則自動計算每一件的成本：
                    ////從最後的記錄開始，倒序重新計算每件的子件累計成本及產品成本，直到頂層
                    //if ((bool)dgvBomDetails.Rows[i].Cells["colIsSetFlag"].Value == false)
                    //countAllItemCost(dgvBomDetails.Rows.Count - 1);
                    //countProductWeightRoll(i);
                    countProductCostingRoll(i);
                }

                //countProductCostingRoll(dtBomDetails.Rows.Count - 1);
                //并初始化將文本框記錄顯示定位到頂層主件的記錄
                fillControlsValue(0);
            }
        }

        private void diGuiTreeViewNode(TreeNodeCollection node)
        {
            foreach (TreeNode n in node)
            {
                addBomTreeToTable(n);// 將每個節點插入到DataTable中
                diGuiTreeViewNode(n.Nodes);
            }
        }
        #endregion

        //將每個子件插入到表格，同時查找若存在單價設定的就顯示，若沒有的，就從生產流程中獲取初始值
        private void addBomTreeToTable(TreeNode tn)
        {
            //1.将当前节点显示到lable上
            string bomLevel = "";
            string parentLevel = "";
            string productId = "";
            string productName = "";
            string tnText = "";
            string materialId = "";
            if (tn.Parent != null)
            {
                parentLevel = tn.Parent.Level.ToString();
            }
            else
            {
                parentLevel = "--";

            }
            if (tn.LastNode != null)//獲取下一層的物料，用于計算本層的重量
            {
                materialId = tn.LastNode.Tag.ToString();
            }
            else
            {
                materialId = "";

            }
            bomLevel = tn.Level.ToString();
            tnText = tn.Text.Trim();
            productId = tn.Tag.ToString();
            productName = tnText.Substring(tnText.IndexOf("[") + 1, (tnText.Length - (tnText.IndexOf("[") + 1) - 1));
            DataRow dr2 = dtBomDetails.NewRow();
            string depId = "";
            if (productId.Substring(0, 2) != "ML")
            {
                DataTable dtDep = clsProductCosting.getProductDepFromBom(productId);
                if (dtDep.Rows.Count > 0)
                {
                    DataRow dr = dtDep.Rows[0];
                    dr2["DepId"] = dr["dept_id"].ToString();
                    dr2["DepCdesc"] = dr["DepCdesc"].ToString();
                    dr2["DoColor"] = dr["DoColor"].ToString();
                }
            }
            else
            {
                dr2["DepId"] = "802";
                dr2["DepCdesc"] = "原料倉";
            }
            depId = dr2["DepId"].ToString();
            DataTable dtCost = clsProductCosting.getProductCosting(productId, depId);
             dr2["ParentLevel"] = parentLevel;
            dr2["BomLevel"] = bomLevel;
            dr2["ProductId"] = productId;
            dr2["ProductName"] = productName;
            dr2["IsSelect"] = false;
            dr2["StdPriceFlag"] = "";
            dr2["StdWeightFlag"] = "";
            if (dtCost.Rows.Count > 0)
            {
                addExistRecordToBomDetails(dr2, dtCost);//將存在的成本記錄加入到BomDetails表中
            }
            else
            {
                doNoExistRecordToBomDetails(dr2, dtCost, productId, materialId);//不存在的成本記錄，從計劃、歷史記錄中查找，并加入到BomDetails表中
            }
            dtBomDetails.Rows.Add(dr2);
        }


        //將存在的成本記錄加入到BomDetails表中
        private void addExistRecordToBomDetails(DataRow dr2, DataTable dtCost)
        {
            DataRow dr = dtCost.Rows[0];
            dr2["IsSetFlag"] = true;
            dr2["ProductMo"] = dr["ProductMo"].ToString();
            dr2["ProductWeight"] = dr["ProductWeight"].ToString() != "" ? dr["ProductWeight"].ToString() : "0";
            dr2["OriginWeight"] = dr["OriginWeight"].ToString() != "" ? dr["OriginWeight"].ToString() : "0";
            dr2["WasteRate"] = dr["WasteRate"].ToString() != "" ? dr["WasteRate"].ToString() : "0";
            dr2["MaterialRequest"] = dr["MaterialRequest"].ToString() != "" ? dr["MaterialRequest"].ToString() : "0";
            dr2["OriginalPrice"] = dr["OriginalPrice"].ToString() != "" ? dr["OriginalPrice"].ToString() : "0";
            dr2["MaterialPrice"] = dr["MaterialPrice"].ToString() != "" ? dr["MaterialPrice"].ToString() : "0";
            dr2["MaterialPriceQty"] = dr["MaterialPriceQty"].ToString() != "" ? dr["MaterialPriceQty"].ToString() : "0";
            dr2["MaterialCost"] = dr["MaterialCost"].ToString() != "" ? dr["MaterialCost"].ToString() : "0";
            dr2["RollUpCost"] = dr["RollUpCost"].ToString() != "" ? dr["RollUpCost"].ToString() : "0";
            dr2["DepId"] = dr["DepId"].ToString() != "" ? dr["DepId"].ToString() : "";
            dr2["DepCdesc"] = dr["DepCdesc"].ToString() != "" ? dr["DepCdesc"].ToString() : "";
            dr2["DepPrice"] = dr["DepPrice"].ToString() != "" ? dr["DepPrice"].ToString() : "";
            dr2["DepStdPrice"] = dr["DepStdPrice"].ToString() != "" ? Convert.ToDecimal(dr["DepStdPrice"]) : 0;
            dr2["DepStdQty"] = dr["DepStdQty"].ToString() != "" ? Convert.ToDecimal(dr["DepStdQty"]) : 0;
            dr2["DepCost"] = dr["DepCost"].ToString();
            dr2["OtherCost1"] = dr["OtherCost1"].ToString() != "" ? dr["OtherCost1"].ToString() : "0";
            dr2["OtherCost2"] = dr["OtherCost2"].ToString() != "" ? dr["OtherCost2"].ToString() : "0";
            dr2["OtherCost3"] = dr["OtherCost3"].ToString() != "" ? dr["OtherCost3"].ToString() : "0";
            dr2["DepTotalCost"] = dr["DepTotalCost"].ToString() != "" ? dr["DepTotalCost"].ToString() : "0";
            dr2["ProductCost"] = dr["ProductCost"].ToString() != "" ? dr["ProductCost"].ToString() : "0";
            dr2["ProductCostGrs"] = dr["ProductCostGrs"].ToString() != "" ? dr["ProductCostGrs"].ToString() : "0";
            dr2["ProductCostK"] = dr["ProductCostK"].ToString() != "" ? dr["ProductCostK"].ToString() : "0";
            dr2["ProductCostDzs"] = dr["ProductCostDzs"].ToString() != "" ? dr["ProductCostDzs"].ToString() : "0";
            dr2["DoColor"] = dr["DoColor"].ToString() != "" ? dr["DoColor"].ToString() : "";
        }

        //不存在的成本記錄，從計劃、歷史記錄中查找，并加入到BomDetails表中
        private void doNoExistRecordToBomDetails(DataRow dr2, DataTable dtCost, string productId, string materialId)
        {
            dr2["IsSetFlag"] = false;
            decimal materialPrice = 0, materialPriceQty = 0;
            decimal wasteRate = 1;
            decimal stdProductWeight = 0;
            decimal stdProductPrice = 0;
            string productMo = txtProductMo.Text.Trim();
            string depId = "", depCdesc = "", doColor = "";
            bool startDep = false;
            string materialId1 = "";
            string matType = productId.Substring(0, 2);
            dr2["OriginWeight"] = 0;
            dr2["ProductWeight"] = 0;
            dr2["MaterialPrice"] = 0;
            dr2["WasteRate"] = 1;
            dr2["DepStdPrice"] = 0;
            dr2["DepStdQty"] = 0;
            depId = dr2["DepId"].ToString();
            depCdesc = dr2["DepCdesc"].ToString();
            doColor = dr2["DoColor"].ToString();
             //提取自定的物料重量
            if (depId == "102" || depId == "104" || depId == "122" || depId == "124" || depId == "202"
                || depId == "302" || depId == "322" || matType == "PL")
            {
                startDep = true;
                materialId1 = materialId;
                //獲取預設的重量
                stdProductWeight = clsProductCosting.findStdProductWeight(depId, productId, materialId1);
                if (stdProductWeight > 0)
                {
                    dr2["StdWeightFlag"] = "Y";
                    dr2["ProductWeight"] = stdProductWeight;
                }
            }
            //如果是原料或採購料，則從採購單中提取原料單價
            if (matType == "ML" || matType == "PL")
            {

                //從自定義中查找單價，若不存在，再從採購單中查找
                DataTable dtPrice = clsProductCosting.findStdProductPrice(productId);//從自定中提取單價
                if (dtPrice.Rows.Count > 0)
                {
                    DataRow drPrice = dtPrice.Rows[0];
                    dr2["StdPriceFlag"] = "Y";
                    stdProductPrice = drPrice["ProductPrice"].ToString() != "" ? Convert.ToDecimal(drPrice["ProductPrice"]) : 0;
                    materialPriceQty = drPrice["ProductPriceQty"].ToString() != "" ? Convert.ToDecimal(drPrice["ProductPriceQty"]) : 0;
                    if (drPrice["PriceUnit"].ToString().Trim() == "KG")
                        materialPrice = Math.Round(stdProductPrice / 1000, 4);
                    else
                        materialPrice = stdProductPrice;
                    dr2["OriginalPrice"] = stdProductPrice;

                }
                else
                {
                    dtPrice = clsProductCosting.findMaterialPrice(productId, "");//從採購單中提取原料單價
                    if (dtPrice.Rows.Count > 0)
                    {
                        DataRow drPrice = dtPrice.Rows[0];
                        materialPrice = drPrice["price_g"].ToString() != "" ? Convert.ToDecimal(drPrice["price_g"].ToString()) : 0;
                        materialPriceQty = drPrice["price_pcs"].ToString() != "" ? Convert.ToDecimal(drPrice["price_pcs"].ToString()) : 0;
                        dr2["OriginalPrice"] = drPrice["PriceHkd"].ToString() != "" ? Convert.ToDecimal(drPrice["PriceHkd"].ToString()) : 0;
                    }
                }
                //如果是採購件，但又不存在預設的重量，就從該制單的流程中提取移交數，再換算成重量
                if (matType == "PL" && stdProductWeight == 0)
                    stdProductWeight = clsProductCosting.getProductWeight(productMo, productId);
                //獲取產品的損耗率
                wasteRate = getWasteRate(productId, depId);
                dr2["ProductWeight"] = stdProductWeight;
                dr2["OriginWeight"] = dr2["ProductWeight"];
                dr2["DepId"] = depId;
                dr2["DepCdesc"] = depCdesc;
                dr2["MaterialPrice"] = materialPrice;
                dr2["MaterialPriceQty"] = materialPriceQty;
                dr2["WasteRate"] = wasteRate;
                ////原料/膠料/噴油/挂電都是按粒計算成本的，所以不用乘以重量 (1-2019/12/14日取消，不用計算，在countProductCostingRoll中計算)
                //dr2["MaterialCost"] = Math.Round(materialPrice * wasteRate, 4);
            }
            else
            {
                //從計劃單中查找匹配的物料編號，并計算物料成本
                for (int i = 0; i < dgvWipData.Rows.Count; i++)
                {
                    if (productId == dgvWipData.Rows[i].Cells["colWipGoodsId"].Value.ToString())
                    {
                        DataGridViewRow dr = dgvWipData.Rows[i];
                        if (depId == "")
                        {
                            depId = dr.Cells["colWipWpId"].Value.ToString();
                            depCdesc = dr.Cells["colWipDepCdesc"].Value.ToString();
                            dr2["DepId"] = depId;
                            dr2["DepCdesc"] = depCdesc;
                            dr2["DoColor"] = dr.Cells["colWipDoColor"].Value.ToString();
                        }
                        dr2["ProductMo"] = dr.Cells["colWipProductMo"].Value.ToString();
                        //設置產品的重量
                        if (startDep == true && stdProductWeight == 0)//1 如果不存在預設的重量，就套用本制單中換算的重量
                        {
                            if ((dr.Cells["colWipPcsWeg"].Value.ToString() != "" ? Convert.ToDecimal(dr.Cells["colWipPcsWeg"].Value) : 0) > 0)
                                dr2["ProductWeight"] = dr.Cells["colWipPcsWeg"].Value;
                            else//2--如果本制單中也不存在換算的重量，則從流程中查找該產品的生產記錄，換算重量
                                dr2["ProductWeight"] = clsProductCosting.getProductWeight(productMo, productId);
                        }

                        wasteRate = getWasteRate(productId, depId);//獲取產品的損耗率
                        dr2["OriginWeight"] = dr2["ProductWeight"];
                        if (depId == "501" || depId == "510")
                        {
                            //從自定義中查找單價，若不存在，再從外發單中查找
                            DataTable dtPrice = clsProductCosting.findStdProductPrice(productId);//從自定中提取單價
                            if (dtPrice.Rows.Count > 0)
                            {
                                DataRow drPrice = dtPrice.Rows[0];
                                dr2["StdPriceFlag"] = "Y";
                                stdProductPrice = drPrice["ProductPrice"].ToString() != "" ? Convert.ToDecimal(drPrice["ProductPrice"]) : 0;
                                materialPriceQty = drPrice["ProductPriceQty"].ToString() != "" ? Convert.ToDecimal(drPrice["ProductPriceQty"]) : 0;
                                if (drPrice["PriceUnit"].ToString().Trim() == "KG")
                                    materialPrice = Math.Round(stdProductPrice / 1000, 4);
                                else
                                    materialPrice = stdProductPrice;
                                dr2["OriginalPrice"] = stdProductPrice;
                            }
                            else
                            {
                                ////默認從之前的外發加工單中提取單價
                                dtPrice = clsProductCosting.findPlatePrice(depId, productId, "");
                                if (dtPrice.Rows.Count > 0)
                                {
                                    DataRow drPrice = dtPrice.Rows[0];
                                    materialPrice = drPrice["price_g"].ToString() != "" ? Convert.ToDecimal(drPrice["price_g"].ToString()) : 0;
                                    materialPriceQty = drPrice["price_pcs"].ToString() != "" ? Convert.ToDecimal(drPrice["price_pcs"].ToString()) : 0;
                                    dr2["OriginalPrice"] = drPrice["sec_price"].ToString() != "" ? Convert.ToDecimal(drPrice["sec_price"].ToString()) : 0;
                                }
                            }
                            dr2["MaterialPrice"] = materialPrice;
                            dr2["MaterialPriceQty"] = materialPriceQty;
                            dr2["WasteRate"] = wasteRate;
                            ////原料/膠料/噴油/挂電都是按粒計算成本的，所以不用乘以重量(2-2019/12/14日取消，不用計算)
                            //if (depId == "510" || (depId == "501" && dr2["DoColor"].ToString().IndexOf("挂電") > 0))
                            //    dr2["MaterialCost"] = Math.Round(wasteRate * materialPrice, 4);
                            //else
                            //    dr2["MaterialCost"] = Math.Round((dr2["ProductWeight"].ToString() != "" ? Convert.ToDecimal(dr2["ProductWeight"]) : 0) * wasteRate * materialPrice, 4);
                        }
                        else
                        {
                            dr2["WasteRate"] = wasteRate;
                            dr2["MaterialRequest"] = Math.Round((dr2["ProductWeight"].ToString() != "" ? Convert.ToDecimal(dr2["ProductWeight"].ToString()) : 0)
                                * wasteRate, 4);
                            //if (productId.Substring(0, 2) == "PL")//如果是膠料，成本就是每PCS的價錢了，所以不用再乘以重量的(3-2019/12/14日取消，不用計算)
                            //    dr2["MaterialCost"] = materialPrice;
                            //else
                            //    dr2["MaterialCost"] = Math.Round((dr2["MaterialRequest"].ToString() != "" ? Convert.ToDecimal(dr2["MaterialRequest"].ToString()) : 0)
                            //* materialPrice, 4);
                        }
                        break;
                    }
                }
            }
            getDepPrice(dr2, productId);//獲取部門的加工費單價


        }

        //獲取部門的加工費單價
        private void getDepPrice(DataRow dr2, string productId)
        {
            decimal depPrice = 0;
            DataTable dtDepPrice = clsProductCosting.getDepPrice(dr2["DepId"].ToString(), productId);// getDepPrice(dr2["DepId"].ToString(), productId);
            if (dtDepPrice.Rows.Count > 0)
            {
                depPrice = Math.Round(((dtDepPrice.Rows[0]["cost_price"].ToString() != "" ? Convert.ToDecimal(dtDepPrice.Rows[0]["cost_price"]) : 0)
                    / (dtDepPrice.Rows[0]["product_qty"].ToString() != "" ? Convert.ToDecimal(dtDepPrice.Rows[0]["product_qty"]) : 1)) * (decimal)hkd_rmb_rate
                    , 4);
                if (dtDepPrice.Rows[0]["cost_price"].ToString() == "")
                    MessageBox.Show(productId + "沒有部門加工單價！");
                else
                {
                    dr2["DepStdPrice"] = dtDepPrice.Rows[0]["cost_price"].ToString();
                    dr2["DepStdQty"] = dtDepPrice.Rows[0]["product_qty"].ToString();
                }
            }
            dr2["DepPrice"] = depPrice;
            dr2["DepCost"] = dr2["DepPrice"];
        }
        //獲取產品損耗率，若產品損耗率不存在，則套用部門的損耗率
        private decimal getWasteRate(string productId, string depId)
        {
            decimal wasteRate = 1;
            wasteRate = clsProductCosting.getProductTypeWasteRate(productId);//產品類型的損耗率
            if (wasteRate == 0)
                wasteRate = clsProductCosting.getDepWasteRate(depId);//部門損耗率
            if (wasteRate == 0)
                wasteRate = 1;
            return wasteRate;
        }
        private void initBomDataTable()
        {
            dtBomDetails = clsProductCosting.getProductCosting("","");
            //將BOM填入到表中
            dtBomDetails.Columns.Add("ParentLevel", typeof(string)); //数据类型为 文本
            dtBomDetails.Columns.Add("BomLevel", typeof(string));
            dtBomDetails.Columns.Add("IsSetFlag", typeof(bool));
            dtBomDetails.Columns.Add("IsSelect", typeof(bool));
            dtBomDetails.Columns.Add("StdPriceFlag", typeof(string));
            dtBomDetails.Columns.Add("StdWeightFlag", typeof(string));
            dgvBomDetails.DataSource = dtBomDetails;
        }


        private void fillControlsValue(int row)
        {
            DataGridViewRow dgr = dgvBomDetails.Rows[row];
            string currentLevel = dgr.Cells["colBomLevel"].Value.ToString();
            txtProductId.Text = dgr.Cells["colProductId"].Value.ToString();
            txtProductName.Text = dgr.Cells["colProductName"].Value.ToString();
            txtDoColor.Text = dgr.Cells["colDoColor"].Value.ToString();
            txtProductWeight.Text = dgr.Cells["colProductWeight"].Value.ToString();
            txtStdWeightFlag.Text = dgr.Cells["colStdWeightFlag"].Value.ToString();
            txtOriginWeight.Text = dgr.Cells["colOriginWeight"].Value.ToString();
            txtWasteRate.Text = dgr.Cells["colWasteRate"].Value.ToString();
            txtMaterialRequest.Text = dgr.Cells["colMaterialRequest"].Value.ToString();
            txtOriginalPrice.Text = dgr.Cells["colOriginalPrice"].Value.ToString();
            txtMaterialPrice.Text = dgr.Cells["colMaterialPrice"].Value.ToString();
            txtMaterialPriceQty.Text = dgr.Cells["colMaterialPriceQty"].Value.ToString();
            txtStdPriceFlag.Text = dgr.Cells["colStdPriceFlag"].Value.ToString();
            txtMaterialCost.Text = dgr.Cells["colMaterialCost"].Value.ToString();
            txtDepId.Text = dgr.Cells["colDepId"].Value.ToString();
            txtDepCdesc.Text = dgr.Cells["colDepCdesc"].Value.ToString();
            txtDepPrice.Text = dgr.Cells["colDepPrice"].Value.ToString();
            txtDepCost.Text = dgr.Cells["colDepCost"].Value.ToString();
            txtOtherCost1.Text = dgr.Cells["colOtherCost1"].Value.ToString();
            txtOtherCost2.Text = dgr.Cells["colOtherCost2"].Value.ToString();
            txtOtherCost3.Text = dgr.Cells["colOtherCost3"].Value.ToString();
            txtProductCost.Text = dgr.Cells["colProductCost"].Value.ToString();
            txtDepTotalCost.Text = dgr.Cells["colDepTotalCost"].Value.ToString();
            txtProductCostGrs.Text = dgr.Cells["colProductCostGrs"].Value.ToString();
            txtProductCostK.Text = dgr.Cells["colProductCostK"].Value.ToString();
            txtProductCostDzs.Text = dgr.Cells["colProductCostDzs"].Value.ToString();
            txtRollUpCost.Text = dgr.Cells["colRollUpCost"].Value.ToString();
            //countRollUpCost(row, currentLevel);
            //判斷下一層是否原料層
            firstLevel = getFirstLevel(currentLevel, row);

            setControlsDesc(txtDepId.Text.Trim(), firstLevel);
            selectdgvWipDataRow(txtProductId.Text);
            printTreeViewNode(tvBom.Nodes, dgvBomDetails.Rows[dgvBomDetails.CurrentRow.Index].Cells["colProductId"].Value.ToString());
        }
        //檢查當層是否最開始的層
        private bool getFirstLevel(string currentLevel, int row)
        {
            bool firstLevelFlag = false;
            int nextRow = row + 1;
            if (nextRow < dgvBomDetails.Rows.Count)
            {
                if (currentLevel == dgvBomDetails.Rows[nextRow].Cells["colParentLevel"].Value.ToString())
                {
                    string matType = dgvBomDetails.Rows[nextRow].Cells["colProductId"].Value.ToString().Substring(0, 2);
                    if (matType == "ML")
                        firstLevelFlag = true;
                    else if (matType == "PL")//如果是PL的，要再判斷下一層以判斷是否是開始物料：TBV030699
                    {
                        string Level1 = dgvBomDetails.Rows[nextRow].Cells["colBomLevel"].Value.ToString();
                        nextRow++;
                        if (nextRow < dgvBomDetails.Rows.Count)
                        {
                            if (Level1 != dgvBomDetails.Rows[nextRow].Cells["colParentLevel"].Value.ToString())
                                firstLevel = true;
                        }
                        else
                            firstLevelFlag = true;
                    }
                }
            }
            return firstLevelFlag;
        }
        ////計算子件成本
        //private void countRollUpCost(int row,string currentLevel)
        //{
        //    decimal rollUpCost = 0;
        //    for (int i = row+1; i < dgvBomDetails.Rows.Count; i++)
        //    {
        //        DataGridViewRow dgr1 = dgvBomDetails.Rows[i];
        //        string nowLevel = dgr1.Cells["colBomLevel"].Value.ToString();
        //        string parentLevel = dgr1.Cells["colParentLevel"].Value.ToString();
        //        if (currentLevel == nowLevel)
        //            break;
        //        else
        //        {
        //            if (currentLevel == parentLevel)
        //                rollUpCost += (dgr1.Cells["colProductCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colProductCost"].Value) : 0);
        //        }
        //    }
        //    txtRollUpCost.Text = rollUpCost.ToString();
        //    DataGridViewRow dgr = dgvBomDetails.Rows[dgvBomDetails.CurrentRow.Index];
        //    dgr.Cells["colRollUpCost"].Value = txtRollUpCost.Text != "" ? Convert.ToDecimal(txtRollUpCost.Text) : 0;
        //}
        private void setControlsDesc(string depId, bool firstLevel)
        {
            bool vFlag = true;
            bool tEnabled = firstLevel;
            if (depId == "501")
            {
                vFlag = false;
                tEnabled = true;
                lblOriginalPrice.Text = "電鍍單價/Kg:";
                lblWasteRate.Text = "電鍍損耗:";
                lblMaterialPrice.Text = "電鍍單價(G):";
                lblMaterialCost.Text = "電鍍成本(G):";
            }
            else if (depId == "510")
            {
                vFlag = false;
                tEnabled = true;
                lblOriginalPrice.Text = "噴油單價/Kg:";
                lblWasteRate.Text = "噴油損耗:";
                lblMaterialPrice.Text = "噴油單價(G):";
                lblMaterialCost.Text = "噴油成本(G):";
            }
            else
            {
                vFlag = true;
                lblOriginalPrice.Text = "原始單價/Kg:";
                lblWasteRate.Text = "原料損耗:";
                lblMaterialPrice.Text = "原料單價(G):";
                lblMaterialCost.Text = "原料成本(G):";
                if (firstLevel == true)
                    tEnabled = true;
                else
                    tEnabled = false;
            }
            lblMaterialRequest.Visible = vFlag;
            txtMaterialRequest.Visible = vFlag;
            //txtOriginalPrice.Enabled = tEnabled;
            //txtMaterialPrice.Enabled = tEnabled;
            //txtMaterialCost.Enabled = tEnabled;
        }
        private void tvBom_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (selectGridView != 3)
            //    return;
            string productId = e.Node.Tag.ToString();
            for (int i = 0; i < dgvBomDetails.Rows.Count; i++)
            {
                if (productId == dgvBomDetails.Rows[i].Cells["colProductId"].Value.ToString())
                {
                    selectDgvBomDetailsRow(i);
                    fillControlsValue(i);
                    break;
                }
            }

        }
        private void selectDgvBomDetailsRow(int row)
        {
            //移到最後新增的那筆記錄，以便進行編輯
            dgvBomDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//设置为整行被选中
            //foreach (DataGridViewRow dgr in dgvDetails.Rows)
            //{
            //    //判断单元格值 
            //    if (dgr.Cells[colIndex].Value == value)
            //    {
            //        //设置当前单元格 
            //        dgvDetails.CurrentCell = dgr.Cells[colIndex];
            //        //设置选中状态 
            //        dgr.Cells[colIndex].Selected = true;
            //    }
            //}
            DataGridViewRow CurrentRow = dgvBomDetails.Rows[row];
            CurrentRow.Cells["colProductId"].Selected = true;
            dgvBomDetails.CurrentCell = CurrentRow.Cells["colProductId"];//定位到最後的那筆記錄

        }
        private void selectdgvWipDataRow(string productId)
        {
            for (int i = 0; i < dgvWipData.Rows.Count; i++)
            {
                if (productId == dgvWipData.Rows[i].Cells["colWipGoodsId"].Value.ToString())
                {
                    //移到最後新增的那筆記錄，以便進行編輯
                    dgvWipData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//设置为整行被选中
                    DataGridViewRow CurrentRow = dgvWipData.Rows[i];
                    CurrentRow.Cells["colWipSeq"].Selected = true;
                    dgvWipData.CurrentCell = CurrentRow.Cells["colWipSeq"];//定位到最後的那筆記錄
                }
            }

        }
        private void countProductCosting()
        {
            decimal rollUpCost = txtRollUpCost.Text != "" ? Convert.ToDecimal(txtRollUpCost.Text) : 0;
            decimal depCost = txtDepCost.Text != "" ? Convert.ToDecimal(txtDepCost.Text) : 0;
            decimal otherCost1 = txtOtherCost1.Text != "" ? Convert.ToDecimal(txtOtherCost1.Text) : 0;
            decimal otherCost2 = txtOtherCost2.Text != "" ? Convert.ToDecimal(txtOtherCost2.Text) : 0;
            decimal otherCost3 = txtOtherCost3.Text != "" ? Convert.ToDecimal(txtOtherCost3.Text) : 0;
            decimal materialCost = txtMaterialCost.Text != "" ? Convert.ToDecimal(txtMaterialCost.Text) : 0;
            decimal productCost = 0;
            productCost = Math.Round(rollUpCost + materialCost + depCost + otherCost1 + otherCost2 + otherCost3, 4);
            txtDepTotalCost.Text = Math.Round(materialCost + depCost + otherCost1 + otherCost2 + otherCost3, 4).ToString();
            txtProductCost.Text = productCost.ToString();
            txtProductCostGrs.Text = Math.Round(productCost * 144, 4).ToString();
            txtProductCostK.Text = Math.Round(productCost * 1000, 4).ToString();
            txtProductCostDzs.Text = Math.Round(productCost * 12, 4).ToString();
        }

        private void txtProductWeight_Leave(object sender, EventArgs e)
        {
            countMaterialCost();
            fillDgvBomDetails();
        }

        private void txtOriginalPrice_Leave(object sender, EventArgs e)
        {
            txtMaterialPrice.Text = (txtOriginalPrice.Text != "" ? Math.Round(Convert.ToDecimal(txtOriginalPrice.Text) / 1000, 4) : 0).ToString();
            countMaterialCost();
            fillDgvBomDetails();
        }
        private void txtMaterialPriceQty_Leave(object sender, EventArgs e)
        {
            countMaterialCost();
            fillDgvBomDetails();
        }
        private void txtDepPrice_Leave(object sender, EventArgs e)
        {
            txtDepCost.Text = (txtDepPrice.Text != "" ? Convert.ToDecimal(txtDepPrice.Text) : 0).ToString();
            countProductCosting();
            fillDgvBomDetails();
        }

        private void txtRollUpCost_Leave(object sender, EventArgs e)
        {
            countProductCosting();
            fillDgvBomDetails();
        }

        private void txtMaterialPrice_Leave(object sender, EventArgs e)
        {
            countMaterialCost();
        }
        private void countMaterialCost()
        {
            decimal wasteRate = txtWasteRate.Text != "" ? Convert.ToDecimal(txtWasteRate.Text) : 0;
            wasteRate = wasteRate == 0 ? 1 : wasteRate;
            decimal materialPrice = txtMaterialPrice.Text != "" ? Convert.ToDecimal(txtMaterialPrice.Text) : 0;
            decimal productWeight = txtProductWeight.Text != "" ? Convert.ToDecimal(txtProductWeight.Text) : 0;
            decimal materialPriceQty = txtMaterialPriceQty.Text != "" ? Convert.ToDecimal(txtMaterialPriceQty.Text) : 0;
            if (firstLevel == true)
            {
                decimal materialRequest = Math.Round(productWeight * wasteRate, 4);
                txtMaterialRequest.Text = materialRequest.ToString();
                txtMaterialCost.Text = Math.Round(materialRequest * materialPrice, 4).ToString();
            }
            else
            {
                //////膠料、噴油、挂電的成本是按粒計算的，所以不用乘以重量
                ////if (txtProductId.Text.Substring(0, 2) == "PL"||txtDepId.Text.Trim() == "510"||(txtDepId.Text.Trim() == "501"&&txtDoColor.Text.IndexOf("挂電")>0))
                ////    txtMaterialCost.Text = Math.Round(wasteRate * materialPrice, 4).ToString();
                ////else
                ////    txtMaterialCost.Text = Math.Round(productWeight * wasteRate * materialPrice, 4).ToString();
                txtMaterialCost.Text = Math.Round((productWeight * wasteRate * materialPrice) + (wasteRate * materialPriceQty), 4).ToString();

            }
            countProductCosting();
        }
        //當文本框的值改變時，同時更新表格的對應值，并自動更新每一件的成本：從當前記錄開始，倒序重新計算每件的子件累計成本及產品成本，直到頂層
        private void fillDgvBomDetails()
        {
            if (dgvBomDetails.Rows.Count == 0)
                return;
            int row = dgvBomDetails.CurrentRow.Index;
            DataGridViewRow dgr = dgvBomDetails.Rows[row];
            dgr.Cells["colRollUpCost"].Value = txtRollUpCost.Text != "" ? Convert.ToDecimal(txtRollUpCost.Text) : 0;
            dgr.Cells["colProductWeight"].Value = txtProductWeight.Text != "" ? Convert.ToDecimal(txtProductWeight.Text) : 0;
            dgr.Cells["colWasteRate"].Value = txtWasteRate.Text != "" ? Convert.ToDecimal(txtWasteRate.Text) : 0;
            dgr.Cells["colMaterialRequest"].Value = txtMaterialRequest.Text != "" ? Convert.ToDecimal(txtMaterialRequest.Text) : 0;
            dgr.Cells["colOriginalPrice"].Value = txtOriginalPrice.Text != "" ? Convert.ToDecimal(txtOriginalPrice.Text) : 0;
            dgr.Cells["colMaterialPrice"].Value = txtMaterialPrice.Text != "" ? Convert.ToDecimal(txtMaterialPrice.Text) : 0;
            dgr.Cells["colMaterialPriceQty"].Value = txtMaterialPriceQty.Text != "" ? Convert.ToDecimal(txtMaterialPriceQty.Text) : 0;
            dgr.Cells["colMaterialCost"].Value = txtMaterialCost.Text != "" ? Convert.ToDecimal(txtMaterialCost.Text) : 0;
            dgr.Cells["colDepPrice"].Value = txtDepPrice.Text != "" ? Convert.ToDecimal(txtDepPrice.Text) : 0;
            dgr.Cells["colDepCost"].Value = txtDepCost.Text != "" ? Convert.ToDecimal(txtDepCost.Text) : 0;
            dgr.Cells["colOtherCost1"].Value = txtOtherCost1.Text != "" ? Convert.ToDecimal(txtOtherCost1.Text) : 0;
            dgr.Cells["colOtherCost2"].Value = txtOtherCost2.Text != "" ? Convert.ToDecimal(txtOtherCost2.Text) : 0;
            dgr.Cells["colOtherCost3"].Value = txtOtherCost3.Text != "" ? Convert.ToDecimal(txtOtherCost3.Text) : 0;
            dgr.Cells["colProductCost"].Value = txtProductCost.Text != "" ? Convert.ToDecimal(txtProductCost.Text) : 0;
            dgr.Cells["colDepTotalCost"].Value = txtDepTotalCost.Text != "" ? Convert.ToDecimal(txtDepTotalCost.Text) : 0;
            dgr.Cells["colProductCostGrs"].Value = txtProductCostGrs.Text != "" ? Convert.ToDecimal(txtProductCostGrs.Text) : 0;
            dgr.Cells["colProductCostK"].Value = txtProductCostK.Text != "" ? Convert.ToDecimal(txtProductCostK.Text) : 0;
            dgr.Cells["colProductCostDzs"].Value = txtProductCostDzs.Text != "" ? Convert.ToDecimal(txtProductCostDzs.Text) : 0;
            countProductCostInGrid(row);
            //可以使用，暫時取消
            //countAllItemCost(row);//自動更新每一件的成本：從當前記錄開始，倒序重新計算每件的子件累計成本及產品成本，直到頂層
            //for (int i = row - 1; i >= 0; i--)
            //{
            //    countProductWeightRoll(i);
            //}
            countProductWeightRoll(row);
            countProductCostingRoll(row);
        }

        private void txtProductCost_Leave(object sender, EventArgs e)
        {
            decimal productCost = txtProductCost.Text != "" ? Convert.ToDecimal(txtProductCost.Text) : 0;
            txtProductCostGrs.Text = Math.Round(productCost * 144, 4).ToString();
            txtProductCostK.Text = Math.Round(productCost * 1000, 4).ToString();
            txtProductCostDzs.Text = Math.Round(productCost * 12, 4).ToString();
            fillDgvBomDetails();
        }

        private void txtProductCostGrs_Leave(object sender, EventArgs e)
        {
            fillDgvBomDetails();
        }

        private void txtProductCostK_Leave(object sender, EventArgs e)
        {
            fillDgvBomDetails();
        }
        private void txtProductCostDzs_Leave(object sender, EventArgs e)
        {
            fillDgvBomDetails();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtDepId.Focus();
            if (!validData())
                return;
            save();
            btnRefresh_Click(sender, e);
        }
        private bool validData()
        {
            bool selectFlag = false;
            for (int i = 0; i < dgvBomDetails.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvBomDetails.Rows[i];
                if ((bool)dgr.Cells["colIsSelect"].Value == true)
                {
                    selectFlag = true;
                    break;
                }
            }
            if (selectFlag == false)
                MessageBox.Show("沒有選定需儲存的記錄!");
            return selectFlag;
        }
        private void save()
        {
            string result = "";
            List<mdlProductCosting> lsModel = new List<mdlProductCosting>();
            for (int i = 0; i < dgvBomDetails.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvBomDetails.Rows[i];
                if ((bool)dgr.Cells["colIsSelect"].Value == true)
                {
                    bool isExist = false;
                    string productId = dgr.Cells["colProductId"].Value.ToString();
                    string depId = dgr.Cells["colDepId"].Value.ToString();
                    //如果物料編號已在列表中，則不再加入，以免重複加入
                    for (int j = 0; j < lsModel.Count; j++)
                    {
                        if (productId == lsModel[j].productId && depId == lsModel[j].depId)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        mdlProductCosting objModel = new mdlProductCosting();
                        objModel.productId = productId;
                        objModel.productMo = txtProductMo.Text.Trim();
                        objModel.rollUpCost = dgr.Cells["colRollUpCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colRollUpCost"].Value) : 0;
                        objModel.productWeight = dgr.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductWeight"].Value) : 0;
                        objModel.originWeight = dgr.Cells["colOriginWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOriginWeight"].Value) : 0;
                        objModel.wasteRate = dgr.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colWasteRate"].Value) : 0;
                        objModel.materialRequest = dgr.Cells["colMaterialRequest"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialRequest"].Value) : 0;
                        objModel.originalPrice = dgr.Cells["colOriginalPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOriginalPrice"].Value) : 0;
                        objModel.materialPrice = dgr.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialPrice"].Value) : 0;
                        objModel.materialPriceQty = dgr.Cells["colMaterialPriceQty"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialPriceQty"].Value) : 0;
                        objModel.materialCost = dgr.Cells["colMaterialCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialCost"].Value) : 0;
                        objModel.depId = dgr.Cells["colDepId"].Value.ToString();
                        objModel.depPrice = dgr.Cells["colDepPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepPrice"].Value) : 0;
                        objModel.depCost = dgr.Cells["colDepCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepCost"].Value) : 0;
                        objModel.depTotalCost = dgr.Cells["colDepTotalCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepTotalCost"].Value) : 0;
                        objModel.depStdPrice = dgr.Cells["colDepStdPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepStdPrice"].Value) : 0;
                        objModel.depStdQty = dgr.Cells["colDepStdQty"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepStdQty"].Value) : 0;
                        objModel.otherCost1 = dgr.Cells["colOtherCost1"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost1"].Value) : 0;
                        objModel.otherCost2 = dgr.Cells["colOtherCost2"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost2"].Value) : 0;
                        objModel.otherCost3 = dgr.Cells["colOtherCost3"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost3"].Value) : 0;
                        objModel.productCost = dgr.Cells["colProductCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCost"].Value) : 0;
                        objModel.productCostGrs = dgr.Cells["colProductCostGrs"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCostGrs"].Value) : 0;
                        objModel.productCostK = dgr.Cells["colProductCostK"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCostK"].Value) : 0;
                        objModel.productCostDzs = dgr.Cells["colProductCostDzs"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCostDzs"].Value) : 0;
                        objModel.createUser = DBUtility._user_id.ToUpper();
                        objModel.createTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        lsModel.Add(objModel);
                    }
                }
            }
            result = clsProductCosting.updateProductCosting(lsModel);
            if (result == "")
            {
                MessageBox.Show("更新產品成本成功!");
                chkSelectAll.Checked = false;
            }
            else
                MessageBox.Show("更新產品成本失敗!");
        }

        //當本層的值改變后，判斷上層是否是原料、膠料、電鍍等，將本層單價帶到上層，并重新計算上層的成本
        //并重新從上層開始，倒序計算所有件的子件成本
        //如果是已設定的，就不再計算
        private void countProductCostingRoll(int currentRow)
        {
            if (currentRow == 0)
                return;
            int parentRow = currentRow - 1;
            //當本層是原料，要將單價帶到上層，并重新計算上層的原料需求及成本
            // 上層---本層
            //   1 --  2 ---parentRow
            //   2 --  3 ---currentRow
            DataGridViewRow dgrParent = dgvBomDetails.Rows[parentRow];
            string currentLevel = dgrParent.Cells["colBomLevel"].Value.ToString();//2
            DataGridViewRow dgrCurrent = dgvBomDetails.Rows[currentRow];
            string parentLevel = dgrCurrent.Cells["colParentLevel"].Value.ToString();//2
            decimal wasteRate = 0;
            string matType = dgrCurrent.Cells["colProductId"].Value.ToString().Substring(0, 2);

            if (matType == "ML")
            {
                if (parentLevel == currentLevel)//判斷本層是否屬於上層的
                {
                    if ((bool)dgrParent.Cells["colIsSetFlag"].Value == false)//如果是已設定的，就不再計算
                    {
                        //上層的單價由本層得來
                        dgrParent.Cells["colOriginalPrice"].Value = dgrCurrent.Cells["colOriginalPrice"].Value;
                        dgrParent.Cells["colMaterialPrice"].Value = dgrCurrent.Cells["colMaterialPrice"].Value;
                        dgrParent.Cells["colMaterialPriceQty"].Value = dgrCurrent.Cells["colMaterialPriceQty"].Value;
                        wasteRate = dgrParent.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colWasteRate"].Value.ToString()) : 0;
                        wasteRate = wasteRate != 0 ? wasteRate : 1;
                        //dgrParent.Cells["colWasteRate"].Value = clsProductCosting.getDepWasteRate(dgrParent.Cells["colDepId"].Value.ToString());
                        dgrParent.Cells["colMaterialRequest"].Value = Math.Round((dgrParent.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colProductWeight"].Value) : 0)
                             * wasteRate
                            , 4);
                        //物料成本 = 重量成本 + 數量成本
                        dgrParent.Cells["colMaterialCost"].Value = Math.Round(
                            ((dgrParent.Cells["colMaterialRequest"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colMaterialRequest"].Value.ToString()) : 0)
                            * (dgrParent.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colMaterialPrice"].Value.ToString()) : 0)
                            )
                            +
                            ((dgrParent.Cells["colMaterialPriceQty"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colMaterialPriceQty"].Value.ToString()) : 0)
                            * wasteRate
                            )
                            , 4);
                        countProductCostInGrid(parentRow);
                    }
                }
            }
            else if (matType == "PL")
            {
                if ((bool)dgrCurrent.Cells["colIsSetFlag"].Value == false)//如果是已設定的，就不再計算
                {

                    wasteRate = dgrCurrent.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgrCurrent.Cells["colWasteRate"].Value.ToString()) : 0;
                    wasteRate = wasteRate != 0 ? wasteRate : 1;
                    //物料成本 = 重量成本 + 數量成本
                    dgrCurrent.Cells["colMaterialCost"].Value = Math.Round(
                        (wasteRate
                        * (dgrCurrent.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgrCurrent.Cells["colProductWeight"].Value.ToString()) : 0)
                        * (dgrCurrent.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgrCurrent.Cells["colMaterialPrice"].Value.ToString()) : 0)
                        )
                        +
                        (wasteRate
                        * (dgrCurrent.Cells["colMaterialPriceQty"].Value.ToString() != "" ? Convert.ToDecimal(dgrCurrent.Cells["colMaterialPriceQty"].Value.ToString()) : 0)
                        )
                        , 4);
                    countProductCostInGrid(currentRow);
                }
            }
            else if (dgrParent.Cells["colDepId"].Value.ToString().Trim() == "501" || dgrParent.Cells["colDepId"].Value.ToString().Trim() == "510")//
            {
                if (parentLevel == currentLevel)
                {
                    if ((bool)dgrParent.Cells["colIsSetFlag"].Value == false)//如果是已設定的，就不再計算
                    {
                        //if (dgrParent.Cells["colStdWeightFlag"].Value.ToString() != "Y")//如果沒有自定的重量，就套用上部門的重量
                        //{
                        //    dgrParent.Cells["colProductWeight"].Value = dgrCurrent.Cells["colProductWeight"].Value;//因為外發的金額是按照NEP計算的，所以要將上層的重量帶入到本層,作為本層的重量
                        //    dgrParent.Cells["colOriginWeight"].Value = dgrParent.Cells["colProductWeight"].Value;
                        //}
                        wasteRate = dgrParent.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colWasteRate"].Value.ToString()) : 0;
                        //物料成本 = 重量成本 + 數量成本
                        dgrParent.Cells["colMaterialCost"].Value = Math.Round(
                        ((dgrParent.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colProductWeight"].Value.ToString()) : 0)
                        * wasteRate
                        * (dgrParent.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colMaterialPrice"].Value.ToString()) : 0)
                        )
                        +
                        (wasteRate
                        * (dgrParent.Cells["colMaterialPriceQty"].Value.ToString() != "" ? Convert.ToDecimal(dgrParent.Cells["colMaterialPriceQty"].Value.ToString()) : 0)
                        )
                        , 4);
                        countProductCostInGrid(parentRow);
                    }
                }
            }


            //從本層的上層開始，重新計算子件累計成本
            for (int i = parentRow; i >= 0; i--)
            {
                DataGridViewRow dgr = dgvBomDetails.Rows[i];
                if ((bool)dgr.Cells["colIsSetFlag"].Value == false)//如果是已設定的，就不再計算
                {
                    int nextRow = i + 1;
                    decimal rollUpCost = 0;
                    string upLevel = dgr.Cells["colBomLevel"].Value.ToString();
                    for (int j = nextRow; j < dgvBomDetails.Rows.Count; j++)
                    {
                        DataGridViewRow dgrRoll = dgvBomDetails.Rows[j];
                        if (upLevel == dgrRoll.Cells["colBomLevel"].Value.ToString())
                            break;
                        if (upLevel == dgrRoll.Cells["colParentLevel"].Value.ToString())
                            if (dgrRoll.Cells["colProductId"].Value.ToString().Substring(0, 2) != "ML")
                                rollUpCost += (dgrRoll.Cells["colProductCost"].Value.ToString() != "" ? Convert.ToDecimal(dgrRoll.Cells["colProductCost"].Value) : 0);
                    }

                    dgr.Cells["colRollUpCost"].Value = rollUpCost.ToString();
                    countProductCostInGrid(i);
                }
            }
        }

        //產品成本=各費用相加
        private void countProductCostInGrid(int row)
        {
            decimal productCost = 0;
            decimal depTotalCost = 0;
            DataGridViewRow dgr = dgvBomDetails.Rows[row];
            depTotalCost = (dgr.Cells["colMaterialCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialCost"].Value) : 0)
                + (dgr.Cells["colDepCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepCost"].Value) : 0)
                + (dgr.Cells["colOtherCost1"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost1"].Value) : 0)
                + (dgr.Cells["colOtherCost2"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost2"].Value) : 0)
                + (dgr.Cells["colOtherCost3"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost3"].Value) : 0);
            productCost = Math.Round(
                (dgr.Cells["colRollUpCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colRollUpCost"].Value) : 0)
                + depTotalCost
                , 4);
            dgr.Cells["colDepTotalCost"].Value = Math.Round(depTotalCost, 4).ToString();
            dgr.Cells["colProductCost"].Value = productCost.ToString();
            dgr.Cells["colProductCostGrs"].Value = Math.Round(productCost * 144, 4).ToString();
            dgr.Cells["colProductCostK"].Value = Math.Round(productCost * 1000, 4).ToString();
            dgr.Cells["colProductCostDzs"].Value = Math.Round(productCost * 12, 4).ToString();
        }

        #region 此段為累計成本,暫不用
        //當值改變時，自動重新計算每件的子件累計成本及產品成本，一直計算到頂層F0，不用人手計算每一層
        //從表格的當前記錄的前一筆記錄開始，倒序計算每件的：子件累計成本=該件對應的下一層的產品成本之和
        //重新累加該件的產品成本
        private void countAllItemCost(int startRow)
        {
            //DataGridViewRow dgrCurrent = dgvBomDetails.Rows[row];
            //string parentSeq = dgrCurrent.Cells["colParentLevel"].Value.ToString();
            for (int i = startRow - 1; i >= 0; i--)
            {
                decimal rollUpCost = 0;
                DataGridViewRow dgr = dgvBomDetails.Rows[i];
                string currentLevel = dgr.Cells["colBomLevel"].Value.ToString();
                rollUpCost = countChildCost(startRow, i, currentLevel);
                dgr.Cells["colRollUpCost"].Value = rollUpCost.ToString();
                countProductCostInGrid(i);
            }

        }
        //計算子件累計成本=該件對應的下一層的產品成本之和
        private decimal countChildCost(int startRow, int row, string currentLevel)
        {
            decimal rollUpCost = 0;
            for (int i = row + 1; i < dgvBomDetails.Rows.Count; i++)
            {
                DataGridViewRow dgr1 = dgvBomDetails.Rows[i];
                string nowLevel = dgr1.Cells["colBomLevel"].Value.ToString();
                string parentLevel = dgr1.Cells["colParentLevel"].Value.ToString();
                if (currentLevel == nowLevel)
                    break;
                else
                {
                    if (currentLevel == parentLevel)
                    {
                        decimal costNoMaterial = 0;
                        //因為上層的產品開料是有損耗的，所以不能直接將本層的原料成本帶給上層，只需將本層的原料單價帶給上層，由上層的原料需求乘以單價，即為上層的原料成本
                        //如果本層是原料，則只將除了“原料單價”的產品成本帶到上層，而單價就單獨帶到上層，乘以上層的原料需求，得出上層的原料成本
                        //并將上一層的單價改為本層的單價，計算出上一層的原料成本
                        costNoMaterial = Math.Round(
                                (dgr1.Cells["colRollUpCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colRollUpCost"].Value) : 0)
                                + (dgr1.Cells["colDepCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colDepCost"].Value) : 0)
                                + (dgr1.Cells["colOtherCost1"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colOtherCost1"].Value) : 0)
                                + (dgr1.Cells["colOtherCost2"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colOtherCost2"].Value) : 0)
                                + (dgr1.Cells["colOtherCost3"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colOtherCost3"].Value) : 0)
                                , 4);
                        //當本層是原料，要將單價帶到上層，并重新計算上層的原料需求及成本
                        if (dgr1.Cells["colProductId"].Value.ToString().Substring(0, 2) == "ML")
                        {
                            if (i == startRow || firstCount == true)
                            {
                                rollUpCost += costNoMaterial;
                                //上層的單價由本層得來
                                dgvBomDetails.Rows[row].Cells["colOriginalPrice"].Value = dgr1.Cells["colOriginalPrice"].Value;
                                dgvBomDetails.Rows[row].Cells["colMaterialPrice"].Value = dgr1.Cells["colMaterialPrice"].Value;
                                //dgvBomDetails.Rows[row].Cells["colWasteRate"].Value = 1.4;
                                dgvBomDetails.Rows[row].Cells["colMaterialRequest"].Value = Math.Round((dgvBomDetails.Rows[row].Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colProductWeight"].Value) : 0)
                                     * Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colWasteRate"].Value)
                                    , 4);
                                dgvBomDetails.Rows[row].Cells["colMaterialCost"].Value = Math.Round(
                                    (dgvBomDetails.Rows[row].Cells["colMaterialRequest"].Value.ToString() != "" ? Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colMaterialRequest"].Value.ToString()) : 0)
                                    * (dgvBomDetails.Rows[row].Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colMaterialPrice"].Value.ToString()) : 0)
                                    , 4);
                            }
                        }
                        else
                        {
                            if (dgr1.Cells["colProductId"].Value.ToString().Substring(0, 2) == "PL")
                            {
                                if (i == startRow || firstCount == true)
                                {
                                    decimal materialCost = 0;
                                    decimal wasteRate = 0;
                                    wasteRate = dgr1.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colWasteRate"].Value.ToString()) : 0;
                                    wasteRate = wasteRate != 0 ? wasteRate : 1;
                                    materialCost = Math.Round(wasteRate
                                        * (dgr1.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colMaterialPrice"].Value.ToString()) : 0)
                                        , 4);
                                    dgr1.Cells["colMaterialCost"].Value = materialCost;
                                    dgr1.Cells["colProductCost"].Value = costNoMaterial + materialCost;
                                    rollUpCost = rollUpCost + costNoMaterial + materialCost;
                                }
                            }
                            else
                            {
                                if (dgvBomDetails.Rows[row].Cells["colDepId"].Value.ToString() == "501" || dgvBomDetails.Rows[row].Cells["colDepId"].Value.ToString() == "510")//
                                {
                                    if (i == startRow || firstCount == true)
                                    {
                                        decimal materialCost = 0;
                                        decimal wasteRate = 0;
                                        dgvBomDetails.Rows[row].Cells["colProductWeight"].Value = dgr1.Cells["colProductWeight"].Value;
                                        wasteRate = dgvBomDetails.Rows[row].Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colWasteRate"].Value.ToString()) : 0;
                                        //if (wasteRate == 0)
                                        //    wasteRate = (decimal)1.1;
                                        materialCost = Math.Round(
                                        (dgvBomDetails.Rows[row].Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colProductWeight"].Value.ToString()) : 0)
                                        * wasteRate
                                        * (dgvBomDetails.Rows[row].Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgvBomDetails.Rows[row].Cells["colMaterialPrice"].Value.ToString()) : 0)
                                        , 4);
                                        dgvBomDetails.Rows[row].Cells["colMaterialCost"].Value = materialCost;
                                        dgvBomDetails.Rows[row].Cells["colProductCost"].Value = costNoMaterial + materialCost;
                                        rollUpCost = rollUpCost + costNoMaterial + materialCost;
                                    }
                                }
                                else
                                    //decimal materialCost=0;
                                    rollUpCost += (dgr1.Cells["colProductCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colProductCost"].Value) : 0);
                                //bool isFirstLevel = getFirstLevel(currentLevel, row);//判斷當層是否最開始
                                //if (isFirstLevel)
                                //    materialCost = Math.Round(
                                //    (dgr1.Cells["colMaterialRequest"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colMaterialRequest"].Value.ToString()) : 0)
                                //    * (dgr1.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colMaterialPrice"].Value.ToString()) : 0)
                                //    , 4);
                                //else
                                //{
                                //    decimal wasteRate = 0;
                                //    wasteRate = dgr1.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colWasteRate"].Value.ToString()) : 0;
                                //    wasteRate = wasteRate != 0 ? wasteRate : 1;
                                //    materialCost = Math.Round(wasteRate
                                //        * (dgr1.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr1.Cells["colMaterialPrice"].Value.ToString()) : 0)
                                //        , 4);
                                //}
                                //rollUpCost = rollUpCost + costNoMaterial + materialCost;
                            }
                        }
                    }
                }
            }
            return rollUpCost;
        }

        #endregion

        //循環計算產品的重量
        private void countProductWeightRoll(int rows)
        {

            //for (int i = row - 1; i >= 0; i--)
            //{
            //    countProductWeightRoll(i);
            //}
            //for (int i = dtBomDetails.Rows.Count - 1; i >= 0; i--)
            //{
            //    countProductWeightRoll(i);
            //}
            //if (rows < dgvBomDetails.Rows.Count)
            //{

            for (int currentRow = rows - 1; currentRow >= 0; currentRow--)
            {
                //if (currentRow == 0)
                //    return;
                //當本層是原料，要將單價帶到上層，并重新計算上層的原料需求及成本
                // 上層---本層
                //   1 --  2 ---parentRow
                //   2 --  3 ---currentRow

                decimal wasteRate = 0;
                decimal rollWeight = 0;
                //從本層的上層開始，重新計算子件累計成本

                DataGridViewRow dgr = dgvBomDetails.Rows[currentRow];
                if (currentRow < dgvBomDetails.Rows.Count - 1)
                {
                    //if ((bool)dgr.Cells["colIsSetFlag"].Value == false)//如果是已設定的，就不再計算
                    //{
                    string upLevel = dgr.Cells["colBomLevel"].Value.ToString();

                    int nextRow = currentRow + 1;

                    for (int j = nextRow; j < dgvBomDetails.Rows.Count; j++)
                    {
                        DataGridViewRow dgrRoll = dgvBomDetails.Rows[j];
                        string jCurrentLevel = dgrRoll.Cells["colBomLevel"].Value.ToString();
                        string jParentLevel = dgrRoll.Cells["colParentLevel"].Value.ToString();
                        string matType = dgrRoll.Cells["colProductId"].Value.ToString().Substring(0, 2);
                        if (string.Compare(upLevel, jParentLevel) > 0)
                            break;
                        if (upLevel == jParentLevel)
                        {
                            if (matType == "ML")
                                rollWeight = dgr.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductWeight"].Value) : 0;
                            else
                                rollWeight += dgrRoll.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgrRoll.Cells["colProductWeight"].Value) : 0;
                        }
                    }

                    dgr.Cells["colProductWeight"].Value = rollWeight;
                    //判斷這層是否是開始層
                    firstLevel = getFirstLevel(upLevel, currentRow);
                    if (firstLevel == true)
                    {
                        wasteRate = dgr.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colWasteRate"].Value) : 0;
                        dgr.Cells["colMaterialRequest"].Value = Math.Round(rollWeight * wasteRate, 4);
                    }
                }
                else
                {
                    dgr.Cells["colMaterialRequest"].Value = Math.Round(
                        (dgr.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductWeight"].Value) : 0)
                        * (dgr.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colWasteRate"].Value) : 0), 4);
                }
            }
        }

        private void btnFindPrdPrice_Click(object sender, EventArgs e)
        {
            frmProductCostingFindPrice.getProductId = txtProductId.Text;
            frmProductCostingFindPrice.getProductName = txtProductName.Text;
            frmProductCostingFindPrice.getDepId = txtDepId.Text;
            searchPrice = 0;
            frmProductCostingFindPrice frm = new frmProductCostingFindPrice();
            frm.ShowDialog();
            if (searchPrice != 0)
            {
                txtOriginalPrice.Text = searchPrice.ToString();
                txtOriginalPrice_Leave(sender, e);
            }
            if (searchPricePcs != 0)
            {
                txtMaterialPriceQty.Text = searchPricePcs.ToString();
                txtMaterialPriceQty_Leave(sender, e);
            }
            frm.Dispose();
        }

        private void btnFindDepCost_Click(object sender, EventArgs e)
        {
            searchProductId = txtProductId.Text;
            searchProductName = txtProductName.Text;
            searchDepId = txtDepId.Text;
            searchPrice = 0;
            frmProductProcessCost frmProductProcessCost = new frmProductProcessCost();
            frmProductProcessCost.ShowDialog();
            if (searchPrice != 0)
            {
                //txtDepPrice.Text = searchPrice.ToString();
                int row = dgvBomDetails.CurrentRow.Index;
                dgvBomDetails.Rows[row].Cells["colDepStdPrice"].Value = sentDepPrice.depStdPrice;
                dgvBomDetails.Rows[row].Cells["colDepStdQty"].Value = sentDepPrice.depStdQty;
                txtDepPrice.Text = sentDepPrice.depPrice.ToString();
                txtDepPrice_Leave(sender, e);
            }
            frmProductProcessCost.Dispose();
        }

        private void dgvBomDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnFindDepCost_Click(sender, e);
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool chkFlag = chkSelectAll.Checked;
            for (int i = 0; i < dgvBomDetails.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvBomDetails.Rows[i];
                dgr.Cells["colIsSelect"].Value = chkFlag;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            xrProductCosting oRepot = new xrProductCosting() { DataSource = dtBomDetails };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void dgvBomDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBomDetails.CurrentRow == null)
                return;
            fillControlsValue(dgvBomDetails.CurrentRow.Index);
        }

        private void btnDepWasteRate_Click(object sender, EventArgs e)
        {
            frmDepWasteRate frmDepWasteRate = new frmDepWasteRate();
            frmDepWasteRate.ShowDialog();
            frmDepWasteRate.Dispose();
        }

        private void btnShowRemark_Click(object sender, EventArgs e)
        {
            if (btnShowRemark.Text == "顯示說明(&I)")
            {
                btnShowRemark.Text = "隱藏說明(&I)";
                panelControl4.Visible = true;
            }
            else
            {
                btnShowRemark.Text = "顯示說明(&I)";
                panelControl4.Visible = false;
            }
        }

        private void btnSetProductPrice_Click(object sender, EventArgs e)
        {
            frmSetProductPrice.getProductId = txtProductId.Text;
            frmSetProductPrice frm = new frmSetProductPrice();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnSetProductWeight_Click(object sender, EventArgs e)
        {
            frmSetProductWeight.getProductId = txtProductId.Text;
            frmSetProductWeight frm = new frmSetProductWeight();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void txtOtherCost3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrderCosting.getProductId = txtProductId.Text;
            frmOrderCosting frm = new frmOrderCosting();
            frm.ShowDialog();
            frm.Dispose();
        }
        #region 遞歸遍歷TreeView，并且判斷節點是否和表格中選中的一樣，如果相等的則將節點標識為選中的狀態
        //如果是高亮的形式顯示，則前面一定要加：tvBom.Focus();
        private void printTreeViewNode(TreeNodeCollection node, string selectStr)
        {
            //tvBom.Focus();
            //string selectStr = "BRCRPREM016095N024";
            foreach (TreeNode n in node)
            {
                //MessageBox.Show(n.Text + ",");
                if (n.Text.Substring(0, 18) == selectStr)
                {
                    n.Checked = true;
                    ////這個是將節點以高亮的形式顯示
                    //tvBom.SelectedNode = n;//.Nodes[1];
                    //tvBom.ExpandAll();
                    //break;
                }
                else
                    n.Checked = false;
                printTreeViewNode(n.Nodes, selectStr);
            }
        }
        #endregion
        private void btnBatchUpdate_Click(object sender, EventArgs e)
        {
            //for (int i = dtBomDetails.Rows.Count - 1; i >= 0; i--)
            //{
            //    ////重新查找數據後，若該主件是未設定成本的，則自動計算每一件的成本：
            //    ////從最後的記錄開始，倒序重新計算每件的子件累計成本及產品成本，直到頂層
            //    //if ((bool)dgvBomDetails.Rows[i].Cells["colIsSetFlag"].Value == false)
            //    //countAllItemCost(dgvBomDetails.Rows.Count - 1);
            //    countProductWeightRoll(i);
            //    //countProductCostingRoll(i);
            //}
            //return;


            //printTreeViewNode(tvBom.Nodes, "BRCRPREM016095N024");
            //return;

            //tvBom.Focus();
            //tvBom.SelectedImageIndex = 2;
            //tvBom.Focus();
            //string selectStr = "BRCRPREM016095N024";
            //for (int i = 0; i < tvBom.Nodes.Count; i++)
            //{
            //    for (int j = 0; j < tvBom.Nodes[i].Nodes.Count; j++)
            //    {
            //        string str = tvBom.Nodes[i].Nodes[j].Text.Substring(0, 18);
            //        if (tvBom.Nodes[i].Nodes[j].Text.Substring(0,18) == selectStr)
            //        {
            //            var node = tvBom.Nodes[i].Nodes[j];
            //            tvBom.SelectedNode = tvBom.Nodes[i].Nodes[j];//选中
            //                                                         //treeView.Nodes[i].Nodes[j].Checked = true;
            //            //tvBom.Nodes[i].Expand();//展开父级
            //            tvBom.ExpandAll();
            //            return;
            //        }
            //    }
            //}
            //return;
            bool showF0 = true;
            DataTable dtProductCosting = clsProductCosting.findProductCosting(1, 0, showF0, "", ""
                , "", "", "", ""
                , "", "", "", ""
                , "", "", "2020/09/10", "2020/09/10", "", ""
                );
            for (int i = 0; i < dtProductCosting.Rows.Count; i++)
            {
                string ProductMo = "", ProductId = "", ProductName = "";
                DataRow drProductCosting = dtProductCosting.Rows[i];

                ProductId = drProductCosting["goods_id"].ToString();
                ProductName = drProductCosting["goods_cname"].ToString();
                ProductMo = drProductCosting["mo_id"].ToString();
                txtProductId.Text = ProductId;
                txtProductName.Text = ProductName;
                txtProductMo.Text = ProductMo;
                firstCount = true;
                showBomTree(ProductMo, ProductId, ProductName);
                save1();
            }
        }


        private void save1()
        {
            string result = "";
            List<mdlProductCosting> lsModel = new List<mdlProductCosting>();
            for (int i = 0; i < dgvBomDetails.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvBomDetails.Rows[i];

                bool isExist = false;
                string productId = dgr.Cells["colProductId"].Value.ToString();
                //如果物料編號已在列表中，則不再加入，以免重複加入
                for (int j = 0; j < lsModel.Count; j++)
                {
                    if (productId == lsModel[j].productId)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    mdlProductCosting objModel = new mdlProductCosting();
                    objModel.productId = productId;
                    objModel.productMo = txtProductMo.Text.Trim();
                    objModel.rollUpCost = dgr.Cells["colRollUpCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colRollUpCost"].Value) : 0;
                    objModel.productWeight = dgr.Cells["colProductWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductWeight"].Value) : 0;
                    objModel.originWeight = dgr.Cells["colOriginWeight"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOriginWeight"].Value) : 0;
                    objModel.wasteRate = dgr.Cells["colWasteRate"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colWasteRate"].Value) : 0;
                    objModel.materialRequest = dgr.Cells["colMaterialRequest"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialRequest"].Value) : 0;
                    objModel.originalPrice = dgr.Cells["colOriginalPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOriginalPrice"].Value) : 0;
                    objModel.materialPrice = dgr.Cells["colMaterialPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialPrice"].Value) : 0;
                    objModel.materialPriceQty = dgr.Cells["colMaterialPriceQty"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialPriceQty"].Value) : 0;
                    objModel.materialCost = dgr.Cells["colMaterialCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colMaterialCost"].Value) : 0;
                    objModel.depId = dgr.Cells["colDepId"].Value.ToString();
                    objModel.depPrice = dgr.Cells["colDepPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepPrice"].Value) : 0;
                    objModel.depCost = dgr.Cells["colDepCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepCost"].Value) : 0;
                    objModel.depTotalCost = dgr.Cells["colDepTotalCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepTotalCost"].Value) : 0;
                    objModel.depStdPrice = dgr.Cells["colDepStdPrice"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepStdPrice"].Value) : 0;
                    objModel.depStdQty = dgr.Cells["colDepStdQty"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colDepStdQty"].Value) : 0;
                    objModel.otherCost1 = dgr.Cells["colOtherCost1"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost1"].Value) : 0;
                    objModel.otherCost2 = dgr.Cells["colOtherCost2"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost2"].Value) : 0;
                    objModel.otherCost3 = dgr.Cells["colOtherCost3"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colOtherCost3"].Value) : 0;
                    objModel.productCost = dgr.Cells["colProductCost"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCost"].Value) : 0;
                    objModel.productCostGrs = dgr.Cells["colProductCostGrs"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCostGrs"].Value) : 0;
                    objModel.productCostK = dgr.Cells["colProductCostK"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCostK"].Value) : 0;
                    objModel.productCostDzs = dgr.Cells["colProductCostDzs"].Value.ToString() != "" ? Convert.ToDecimal(dgr.Cells["colProductCostDzs"].Value) : 0;
                    objModel.createUser = DBUtility._user_id.ToUpper();
                    objModel.createTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    lsModel.Add(objModel);
                }
            }
            result = clsProductCosting.updateProductCosting(lsModel);
            if (result == "")
            {
                //MessageBox.Show("更新產品成本成功!");
                chkSelectAll.Checked = false;
            }
            else
                MessageBox.Show("更新產品成本失敗!");
        }

        private void dgvBomDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsUtility.setDataGridViewSeq(dgvBomDetails, e);
        }

        private void dgvWipData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsUtility.setDataGridViewSeq(dgvWipData, e);
        }

        private void Delete()
        {
            string result = "";
            List<mdlProductCosting> lsModel = new List<mdlProductCosting>();
            for (int i = 0; i < dgvBomDetails.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvBomDetails.Rows[i];
                if ((bool)dgr.Cells["colIsSelect"].Value == true)
                {
                    mdlProductCosting mdj = new mdlProductCosting();
                    mdj.productId = dgr.Cells["colProductId"].Value.ToString();
                    mdj.depId = dgr.Cells["colDepId"].Value.ToString();
                    lsModel.Add(mdj);
                }
            }
            result = clsProductCosting.deleteProductCosting(lsModel);
            if (result == "")
            {
                MessageBox.Show("刪除產品成本成功!");
                chkSelectAll.Checked = false;
            }
            else
                MessageBox.Show("刪除產品成本失敗!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtDepId.Focus();
            Delete();
            btnRefresh_Click(sender, e);
        }
    }
}
