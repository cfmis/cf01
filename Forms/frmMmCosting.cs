using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmMmCosting : Form
    {
        public static string sent_id;
        public static string sent_prd_mo;
        public static string sent_dep_id;
        public static string sent_goods_id;
        public static DataTable dtPlateCharges;
        public static DataTable dtDepCharges;
        private DataTable dtMmCostingPart;
        private DataTable dtBomGrid=new DataTable();
        public frmMmCosting()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void countMmCosting()
        {
            txtMatWegG.Text = ((txtMatWeg.Text!=""?Convert.ToDecimal(txtMatWeg.Text) / 1000:0)).ToString();//銅料重量/1000
            //每G銅料價錢
            txtMatPriceG.Text = Math.Round((txtMatPrice.Text != "" ? Convert.ToDecimal(txtMatPrice.Text) : 0) / 1000,4).ToString();
            //每G銅料重量 *  每G銅料價錢
            txtMatAmt.Text = Math.Round((txtMatWegG.Text != "" ? Convert.ToDecimal(txtMatWegG.Text) : 0) * Convert.ToDecimal(txtMatPriceG.Text),4).ToString();
            //銅料損耗價錢
            txtMatLossAmt.Text = Math.Round((txtMatAmt.Text != "" ? Convert.ToDecimal(txtMatAmt.Text) : 0)
                * (((txtMatLossRate.Text != "" ? Convert.ToDecimal(txtMatLossRate.Text) : 0)) / 100)
                , 4).ToString();
            //電鍍價錢(含損耗)
            txtPlatePriceIncLoss.Text = Math.Round((txtPlatePrice_Weg.Text != "" ? Convert.ToDecimal(txtPlatePrice_Weg.Text) : 0)
                * (txtPlateLossRate.Text != "" ? Convert.ToDecimal(txtPlateLossRate.Text) : 0), 4).ToString();
            //電鍍價錢(含損耗)每G
            txtPlatePriceIncLossG.Text = Math.Round(((txtPlatePrice_Weg.Text != "" ? Convert.ToDecimal(txtPlatePrice_Weg.Text) : 0)
                * (txtPlateLossRate.Text != "" ? Convert.ToDecimal(txtPlateLossRate.Text) : 0)) / 1000, 4).ToString();
            //銅料每克的電鍍價錢 = 每克銅料 *  每克電鍍價錢
            txtMatPlatePrice.Text = Math.Round((txtMatWegG.Text != "" ? Convert.ToDecimal(txtMatWegG.Text) : 0)
                * (txtPlatePriceIncLossG.Text != "" ? Convert.ToDecimal(txtPlatePriceIncLossG.Text) : 0), 4).ToString();

            txtMmCosting.Text = Math.Round((
                (txtMatAmt.Text != "" ? Convert.ToDecimal(txtMatAmt.Text) : 0)
                + (txtMatLossAmt.Text != "" ? Convert.ToDecimal(txtMatLossAmt.Text) : 0)
                + (txtPlatePriceIncLossG.Text != "" ? Convert.ToDecimal(txtPlatePriceIncLossG.Text) : 0)
                + (txtDepCharges.Text != "" ? Convert.ToDecimal(txtDepCharges.Text) : 0)
                )
                * (txtFactoryChargesRate.Text != "" ? (1 + Convert.ToDecimal(txtFactoryChargesRate.Text)/100) : 0)
                * (txtProfitMarginRate.Text != "" ? (1 + Convert.ToDecimal(txtProfitMarginRate.Text) / 100) : 0)
                , 4).ToString();
        }

        private void frmMmCosting_Load(object sender, EventArgs e)
        {
            dgvWip.AutoGenerateColumns = false;
            cleanTextBox();
            cleanTextBoxPart();
            initMmCostingPart();
        }
        private void initMmCostingPart()
        {
            //將BOM填入到表中
            dtBomGrid.Columns.Add("level_flag", typeof(string)); //数据类型为 文本
            dtBomGrid.Columns.Add("bom_level", typeof(string)); //数据类型为 文本
            dtBomGrid.Columns.Add("goods_id", typeof(string)); //数据类型为 文本
            dtBomGrid.Columns.Add("goods_name", typeof(string)); //数据类型为 文本
 

            dtMmCostingPart = clsMmCosting.findMmCosting("ZZZZZZZZZ", "");

            
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mdlMmCosting mdlCost = new mdlMmCosting();
            mdlCost.ID = txtId.Text;
            mdlCost.Cdesc = txtCdesc.Text;
            mdlCost.Prd_mo = txtPrd_mo.Text;
            mdlCost.MmCosting = txtMmCosting.Text != "" ? Convert.ToDecimal(txtMmCosting.Text) : 0;
            mdlCost.MatWeg = txtMatWeg.Text != "" ? Convert.ToDecimal(txtMatWeg.Text) : 0;
            mdlCost.MatWegG = txtMatWegG.Text != "" ? Convert.ToDecimal(txtMatWegG.Text) : 0;
            mdlCost.MatPrice = txtMatPrice.Text != "" ? Convert.ToDecimal(txtMatPrice.Text) : 0;
            mdlCost.MatPriceG = txtMatPriceG.Text != "" ? Convert.ToDecimal(txtMatPriceG.Text) : 0;
            mdlCost.MatAmt = txtMatAmt.Text != "" ? Convert.ToDecimal(txtMatAmt.Text) : 0;
            mdlCost.MatLossRate = txtMatLossRate.Text != "" ? Convert.ToDecimal(txtMatLossRate.Text) : 0;
            mdlCost.MatLossAmt = txtMatLossAmt.Text != "" ? Convert.ToDecimal(txtMatLossAmt.Text) : 0;
            mdlCost.PlatePrice = txtPlatePrice_Weg.Text != "" ? Convert.ToDecimal(txtPlatePrice_Weg.Text) : 0;
            mdlCost.PlateLossRate = txtPlateLossRate.Text != "" ? Convert.ToDecimal(txtPlateLossRate.Text) : 0;
            mdlCost.PlatePriceIncLoss = txtPlatePriceIncLoss.Text != "" ? Convert.ToDecimal(txtPlatePriceIncLoss.Text) : 0;
            mdlCost.PlatePriceIncLossG = txtPlatePriceIncLossG.Text != "" ? Convert.ToDecimal(txtPlatePriceIncLossG.Text) : 0;
            mdlCost.MatPlatePrice = txtMatPlatePrice.Text != "" ? Convert.ToDecimal(txtMatPlatePrice.Text) : 0;
            mdlCost.DepCharges = txtDepCharges.Text != "" ? Convert.ToDecimal(txtDepCharges.Text) : 0;
            mdlCost.FactoryChargesRate = txtFactoryChargesRate.Text != "" ? Convert.ToDecimal(txtFactoryChargesRate.Text) : 0;
            mdlCost.ProfitMarginRate = txtProfitMarginRate.Text != "" ? Convert.ToDecimal(txtProfitMarginRate.Text) : 0;
            //外發加工費用
            List<mdlPlatePrice> mdlPlatePrices = new List<mdlPlatePrice>();
            //for (int i = 0; i < dtPlateCharges.Rows.Count; i++)
            //{
            //    mdlPlatePrice mdlPlatePrice = new mdlPlatePrice();
            //    DataRow dr = dtPlateCharges.Rows[i];
            //    mdlPlatePrice.id = txtId.Text;
            //    mdlPlatePrice.clr = dr["clr"].ToString();
            //    mdlPlatePrice.clr_cdesc = dr["clr_cdesc"].ToString();
            //    mdlPlatePrice.do_color = dr["do_color"].ToString();
            //    mdlPlatePrice.plateprice = dr["plateprice"].ToString() != "" ? Convert.ToDecimal(dr["plateprice"].ToString()) : 0;
            //    mdlPlatePrice.remark = dr["remark"].ToString();
            //    mdlPlatePrices.Add(mdlPlatePrice);
            //}
            //部門加工費
            List<mdlDepCharges> mdlDepCharges = new List<mdlDepCharges>();
            //for (int i = 0; i < dtDepCharges.Rows.Count; i++)
            //{
            //    mdlDepCharges mdlDepCharge = new mdlDepCharges();
            //    DataRow dr = dtDepCharges.Rows[i];
            //    mdlDepCharge.id = txtId.Text;
            //    mdlDepCharge.dep_id = dr["dep_id"].ToString();
            //    mdlDepCharge.dep_charges = dr["dep_charges"].ToString() != "" ? Convert.ToDecimal(dr["dep_charges"].ToString()) : 0;
            //    mdlDepCharges.Add(mdlDepCharge);
            //}
            string result = clsMmCosting.updateMmCosting(mdlCost, mdlPlatePrices, mdlDepCharges);
            if (result != "")
                MessageBox.Show("儲存記錄失敗!");
            else
            {

            }
        }

        private void btnShowMo_Click(object sender, EventArgs e)
        {
            DataTable dtMoOc = clsMmCosting.getMoFromOc(txtPrd_mo.Text);
            if (dtMoOc.Rows.Count > 0)
            {
                txtId.Text = dtMoOc.Rows[0]["goods_id"].ToString();
                txtCdesc.Text = dtMoOc.Rows[0]["goods_cname"].ToString();
            }
            showItemTree();

        }
        private void showItemTree()
        {
            ////刪除表所有行
            //int count = dtMmCostingPart.Rows.Count;
            //for (int i = count - 1; i >= 0; i--)
            //{
            //    dtMmCostingPart.Rows.RemoveAt(i);
            //}

            showBomTree();
            showWip();
            //dgvMmCostingPart.DataSource = dtMmCostingPart;
        }
        private void showWip()
        {
            DataTable dtWip = clsMmCosting.getWipRec(txtPrd_mo.Text.Trim());
            for (int i = 0; i < dtWip.Rows.Count; i++)
            {
                if (dtWip.Rows[i]["wp_id"].ToString().Trim() == "102"
                    || dtWip.Rows[i]["wp_id"].ToString().Trim() == "104"
                    || dtWip.Rows[i]["wp_id"].ToString().Trim() == "106"
                    || dtWip.Rows[i]["wp_id"].ToString().Trim() == "202"
                    || dtWip.Rows[i]["wp_id"].ToString().Trim() == "302"
                    || string.Compare(dtWip.Rows[i]["wp_id"].ToString().Trim(), "800") > 0)
                {
                }
                else
                {
                    dtWip.Rows[i]["weg_kg"] = 0;
                    dtWip.Rows[i]["weg_g"] = 0;
                }
            }
            dgvWip.DataSource = dtWip;
        }
        
        private void btnShowPlate_Click(object sender, EventArgs e)
        {
            sent_id = txtId.Text;
            sent_prd_mo = txtPrd_mo.Text;
            sent_dep_id = txtDep_part.Text;
            sent_goods_id = txtId_part.Text;
            frmMmCostingPlate frmMmCostingPlate = new frmMmCostingPlate();
            frmMmCostingPlate.ShowDialog();
            decimal PlatePrice = 0;
            for (int i = 0; i < dtPlateCharges.Rows.Count; i++)
            {
                PlatePrice += dtPlateCharges.Rows[i]["plateprice"].ToString() != "" ? Convert.ToDecimal(dtPlateCharges.Rows[i]["plateprice"]) : 0;
            }
            txtPlatePrice_Weg_part.Text = PlatePrice.ToString();
            countMmCosting();
            frmMmCostingPlate.Dispose();
        }

        private void btnShowDep_Click(object sender, EventArgs e)
        {
            sent_id = txtId.Text;
            sent_prd_mo = txtPrd_mo.Text;
            frmMmCostingDep frmMmCostingDep = new frmMmCostingDep();
            frmMmCostingDep.ShowDialog();
            decimal DepCharges = 0;
            for (int i = 0; i < dtDepCharges.Rows.Count; i++)
            {
                DepCharges += dtDepCharges.Rows[i]["dep_charges"].ToString() != "" ? Convert.ToDecimal(dtDepCharges.Rows[i]["dep_charges"]) : 0;
            }
            txtDepCharges_part.Text = DepCharges.ToString();
            countMmCosting();
            frmMmCostingDep.Dispose();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            sent_id = txtId.Text;
            frmMmCostingFind frmMmCostingFind = new frmMmCostingFind();
            frmMmCostingFind.ShowDialog();
            if (sent_id != "")
            {
                DataTable dtFindMmCosting = clsMmCosting.findMmCosting(sent_id, "");
                txtId.Text = sent_id;
                fillTextBoxF0(dtFindMmCosting);
                showItemTree();
             }
            frmMmCostingFind.Dispose();
        }
        private void fillTextBoxF0(DataTable dt)
        {
            //cleanTextBox();
            if (dt.Rows.Count == 0)
            {
                return;
            }
            DataRow dr = dt.Rows[0];
            if (dr["id"].ToString().Substring(0, 2) == "F0")
            {
                txtPrd_mo.Text = dr["prd_mo"].ToString();
                txtMmCosting.Text = dr["mmcosting"].ToString();
                txtMatWeg.Text = dr["matweg"].ToString();
                txtMatWegG.Text = dr["matwegg"].ToString();
                txtMatPrice.Text = dr["matprice"].ToString();
                txtMatPriceG.Text = dr["matpriceg"].ToString();
                txtMatAmt.Text = dr["matamt"].ToString();
                txtMatLossRate.Text = dr["matlossrate"].ToString();
                txtMatLossAmt.Text = dr["matlossamt"].ToString();
                txtFactoryChargesRate.Text = dr["factorychargesrate"].ToString();
                txtProfitMarginRate.Text = dr["profitmarginrate"].ToString();
                txtPlatePrice_Weg.Text = dr["plateprice"].ToString();
                txtPlateLossRate.Text = dr["platelossrate"].ToString();
                txtPlatePriceIncLoss.Text = dr["platepriceincloss"].ToString();
                txtPlatePriceIncLossG.Text = dr["platepriceinclossg"].ToString();
                txtMatPlatePrice.Text = dr["matplateprice"].ToString();
                txtDepCharges.Text = dr["depcharges"].ToString();
                
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() != "")
            {
                DataTable dt = clsMmCosting.getMmData(txtId.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    txtCdesc.Text = dt.Rows[0]["goods_cname"].ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleanTextBox();
            cleanTextBoxPart();
        }
        private void cleanTextBox()
        {
            txtId.Text = "";
            txtCdesc.Text = "";
            txtPrd_mo.Text = "";
            txtMmCosting.Text = "";
            txtMatWeg.Text = "";
            txtMatWegG.Text = "";
            txtMatPrice.Text = "";
            txtMatPriceG.Text = "";
            txtMatAmt.Text = "";
            txtMatLossRate.Text = "";
            txtMatLossAmt.Text = "";
            txtPlatePrice_Weg.Text = "";
            txtPlatePriceIncLoss.Text = "";
            txtPlatePriceIncLossG.Text = "";
            txtMatPlatePrice.Text = "";
            txtDepCharges.Text = "";


            txtPlateLossRate.Text = "1.1";
            txtFactoryChargesRate.Text = "40";
            txtProfitMarginRate.Text = "10";
        }
        private void cleanTextBoxPart()
        {

            txtCdesc_part.Text = "";
            txtMmCosting_part.Text = "";
            txtMatWeg_part.Text = "";
            txtMatWegG_part.Text = "";
            txtMatPrice_part.Text = "";
            txtMatPriceG_part.Text = "";
            txtMatAmt_part.Text = "";
            txtMatLossRate_part.Text = "";
            txtMatLossAmt_part.Text = "";
            txtPlatePrice_Weg_part.Text = "";
            txtPlatePriceIncLoss_part.Text = "";
            txtPlatePriceIncLossG_part.Text = "";
            txtMatPlatePrice_part.Text = "";
            txtDepCharges_part.Text = "";
            txtPlateLossRate_part.Text = "1.1";
            txtPlate_Qty_part.Text = "1";
            //txtFactoryChargesRate_part.Text = "40";
            //txtProfitMarginRate_part.Text = "10";
        }


        private void showBomTree()
        {
            string pid = txtId.Text.Trim();


            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            //InitMenu(pid); //数据处理

            InitMenuFromOc(pid);//從OC中提取BOM
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });



        }

        protected void InitMenu(string pid)
        {
            MenuTree.Nodes.Clear();

            //添加主菜单
            TreeNode TopNode;
            //獲取首層F0
            DataTable dtBom_h = clsMmCosting.getBomPid(pid);
            if (dtBom_h.Rows.Count > 0)
            {
                string id = dtBom_h.Rows[0]["id"].ToString();
                string goods_id = dtBom_h.Rows[0]["goods_id"].ToString();
                string goods_name = dtBom_h.Rows[0]["goods_name"].ToString();
                TopNode = new TreeNode();
                TopNode.Text = goods_id + "[" + goods_name + "]";
                TopNode.Tag = id;//goods_id ;//保存表單名
                TopNode.ImageIndex = 2;
                MenuTree.Nodes.Add(TopNode);
                //AddRoutingBom(TopNode, goods_id);//添加Routing
                //addMmCostPart(goods_id);
                AddChildNode(TopNode, goods_id);//递归调用
                MenuTree.ExpandAll();//展開
                //TopNode.ImageIndex = TopNode.SelectedImageIndex = 2;                        
            }

        }


        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void AddChildNode(TreeNode subNode, string pid)
        {
            //DataRow[] drArr = dt.Select(String.Format("Pid={0} and Uname='{1}'", pid, userName));//查出这个菜单的所有的子菜单            
            //if (drArr.Length == 0)
            //{
            //    subNode.ImageIndex = subNode.SelectedImageIndex = 1;
            //}

            //strSql = " SELECT id,goods_id FROM it_bom_mostly WHERE within_code='" + within_code + "' AND goods_id='" + pid + "'";
            //DataTable dtBom_h = clsConErp.GetDataTable(strSql);

            //string id = dtBom_h.Rows[0]["id"].ToString();

            //strSql = " SELECT id,goods_id FROM it_bom WHERE within_code='" + within_code + "' AND id='" + id + "'";

            TreeNode subNode1;
            DataTable dtBom_d = clsMmCosting.getBomCid(pid);
            if (dtBom_d.Rows.Count == 0)
            {
                subNode.ImageIndex = 3;
            }
            else
            {
                for (int i = 0; i < dtBom_d.Rows.Count; i++)
                {
                    //DataRow[] drArr = dtBom_d.Select("id>='' ");
                    ////if (drArr.Length == 0)
                    ////{
                    ////    subNode.ImageIndex = subNode.SelectedImageIndex = 1;
                    ////}


                    //foreach (DataRow dr in drArr)
                    //{
                    string ppid = dtBom_d.Rows[i]["d_goods_id"].ToString();
                    string d_id = dtBom_d.Rows[i]["d_id"].ToString();
                    string goods_name = dtBom_d.Rows[i]["goods_name"].ToString();
                    string dept_id = dtBom_d.Rows[i]["dept_id"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "[" + goods_name + "]";//实例化一个菜单项
                    subNode1.Tag = d_id;//保存表單名
                    subNode1.ImageIndex = 2;
                    subNode.Nodes.Add(subNode1);

                    //AddRoutingBom(subNode1, ppid);//添加Routing
                    addMmCostPart(ppid, goods_name, dept_id);
                    //break;
                    AddChildNode(subNode1, ppid);//递归调用的方法                     
                    //InitMenu(ppid);
                    //}
                }
            }
        }

        protected void InitMenuFromOc(string pid)
        {
            MenuTree.Nodes.Clear();
            string mo_id = txtPrd_mo.Text.Trim();
            
            //添加主菜单
            TreeNode TopNode;
            //獲取首層F0
            DataTable dtBom_h = clsMmCosting.getBomFromOc(mo_id, pid);
            if (dtBom_h.Rows.Count > 0)
            {
                string id = dtBom_h.Rows[0]["id"].ToString();
                string goods_id = dtBom_h.Rows[0]["goods_id"].ToString();
                string goods_name = dtBom_h.Rows[0]["goods_name"].ToString();
                TopNode = new TreeNode();
                TopNode.Text = goods_id + "[" + goods_name + "]";
                TopNode.Tag = goods_id ;//id;//保存表單名
                TopNode.ImageIndex = 2;
                MenuTree.Nodes.Add(TopNode);
                //addBomToTable(goods_id, goods_name);
                ////AddRoutingBom(TopNode, goods_id);//添加Routing
                ////addMmCostPart(goods_id);
                AddChildNodeFromWip(TopNode,mo_id, goods_id);//递归调用
                MenuTree.ExpandAll();//展開
                //TopNode.ImageIndex = TopNode.SelectedImageIndex = 2;                        
            }

        }
        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void AddChildNodeFromWip(TreeNode subNode, string mo_id, string pid)
        {

            TreeNode subNode1;
            DataTable dtBom_d = clsMmCosting.getBomCidFromWip(mo_id, pid);
            if (dtBom_d.Rows.Count == 0)
            {
                subNode.ImageIndex = 3;
            }
            else
            {
                for (int i = 0; i < dtBom_d.Rows.Count; i++)
                {
                    string ppid = dtBom_d.Rows[i]["d_goods_id"].ToString();
                    string d_id = dtBom_d.Rows[i]["d_id"].ToString();
                    string goods_name = dtBom_d.Rows[i]["d_goods_name"].ToString();
                    string dept_id = "";
                    //獲取配件的生產部門
                    DataTable dtDep = clsMmCosting.getBomItemDepFromWip(mo_id, ppid);
                    if (dtDep.Rows.Count > 0)
                        dept_id = dtDep.Rows[0]["dept_id"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "[" + goods_name + "]";//实例化一个菜单项
                    subNode1.Tag = ppid;// d_id;//保存表單名
                    subNode1.ImageIndex = 2;
                    subNode.Nodes.Add(subNode1);
                    //MenuTree.Nodes.Add(subNode1);
                    //addBomToTable(ppid, goods_name);
                    //AddRoutingBom(subNode1, ppid);//添加Routing
                    //addMmCostPart(ppid, goods_name, dept_id);
                    //break;
                    AddChildNodeFromWip(subNode1, mo_id, ppid);//递归调用的方法
                    //InitMenu(ppid);
                    //}
                }
            }
        }

        private void addMmCostPart(string goods_id, string goods_name, string dept_id)
        {
            DataTable dt = clsMmCosting.findMmCosting(goods_id, "");
            DataRow dr = dtMmCostingPart.NewRow();
            dr["id"] = goods_id;
            if (dt.Rows.Count > 0)
            {
                dr["cdesc"] = dt.Rows[0]["goods_cname"];
                dr["dep_id"] = dt.Rows[0]["dep_id"];
                dr["MatWeg"] = dt.Rows[0]["MatWeg"];
                dr["MatWegG"] = dt.Rows[0]["MatWegG"];
                dr["MatPrice"] = dt.Rows[0]["MatPrice"];
                dr["MatPriceG"] = dt.Rows[0]["MatPriceG"];
                dr["MatAmt"] = dt.Rows[0]["MatAmt"];
                dr["MatLossRate"] = dt.Rows[0]["MatLossRate"];
                dr["MatLossAmt"] = dt.Rows[0]["MatLossAmt"];
                dr["PlatePrice"] = dt.Rows[0]["PlatePrice"];
                dr["PlateLossRate"] = dt.Rows[0]["PlateLossRate"];
                dr["PlatePriceIncLoss"] = dt.Rows[0]["PlatePriceIncLoss"];
                dr["PlatePriceIncLossG"] = dt.Rows[0]["PlatePriceIncLossG"];
                dr["MatPlatePrice"] = dt.Rows[0]["MatPlatePrice"];
                dr["depcharges"] = dt.Rows[0]["depcharges"];
                dr["FactoryChargesRate"] = dt.Rows[0]["FactoryChargesRate"];
                dr["ProfitMarginRate"] = dt.Rows[0]["ProfitMarginRate"];
            }
            else
            {
                dr["cdesc"] = goods_name;
                dr["dep_id"] = dept_id;
                //提取原料重量
                if (goods_id.Substring(14, 4) == "NEP0")//(dept_id == "102" || dept_id == "202" || dept_id == "302")
                {
                    DataTable dtWip = clsMmCosting.getMatWeg(txtPrd_mo.Text.Trim(), dept_id, goods_id);
                    if (dtWip.Rows.Count > 0)
                    {
                        dr["MatWeg"] = dtWip.Rows[0]["weg_kg"];
                        dr["MatWegG"] = dtWip.Rows[0]["weg_g"];
                    }
                }
            }
            dtMmCostingPart.Rows.Add(dr);
        }
        private void MenuTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string id = e.Node.Text.ToString();

            int len = id.IndexOf("[");
            if (len == 0)
                return;
            id = id.Substring(0, len);
            showTreeItem(id);
            if (id.Substring(0, 2) == "F0")
            {
                DataTable dtMmF0Costing = clsMmCosting.findMmCosting(id, "");
                fillTextBoxF0(dtMmF0Costing);
            }
            else//如果點擊配件編號，則在表格中尋找，并定位到該記錄，以及給配件文本框賦值
            {
                for (int i = 0; i < dgvMmCostingPart.Rows.Count; i++)
                {
                    if (id == dgvMmCostingPart.Rows[i].Cells["colId_part"].Value.ToString())
                    {
                        setSelectRec(i);
                        fillTextBoxtPart(i);
                        break;
                    }
                }
            }
        }
        private void showTreeItem(string id)
        {
            DataTable dt = clsMmCosting.getBomDep(id);
            if (dt.Rows.Count > 0)
            {
                if (id.Substring(0, 2) == "F0")
                {
                    txtId.Text = id;
                    txtCdesc.Text = dt.Rows[0]["goods_cname"].ToString();
                }
                else
                {
                    txtId_part.Text = id;
                    txtCdesc_part.Text = dt.Rows[0]["goods_cname"].ToString();
                    txtDep_part.Text = dt.Rows[0]["dept_id"].ToString();
                }
            }
        }


        private void setSelectRec(int row)
        {
            //移到最後新增的那筆記錄，以便進行編輯
            dgvWip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//设置为整行被选中
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
            DataGridViewRow CurrentRow = dgvWip.Rows[row];
            CurrentRow.Cells["colSeq_W"].Selected = true;
            dgvWip.CurrentCell = CurrentRow.Cells["colSeq_W"];//定位到最後的那筆記錄

        }

        private void txtMatWeg_Leave(object sender, EventArgs e)
        {
            countMmCosting();
        }

        private void dgvMmCostingPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillTextBoxtPart(dgvMmCostingPart.CurrentCell.RowIndex);
        }
        private void fillTextBoxtPart(int row)
        {
            if (dgvMmCostingPart.Rows.Count == 0)
                return;
            DataGridViewRow cr = dgvMmCostingPart.Rows[row];
            txtId_part.Text = cr.Cells["colId_part"].Value.ToString();
            txtCdesc_part.Text = cr.Cells["colCdesc_part"].Value.ToString();
            txtMatWeg_part.Text = cr.Cells["colMatWeg_part"].Value.ToString();
            txtMatWegG_part.Text = cr.Cells["colMatWegG_part"].Value.ToString();
            txtMatPrice_part.Text = cr.Cells["colMatPrice_part"].Value.ToString();
            txtMatPriceG_part.Text = cr.Cells["colMatPriceG_part"].Value.ToString();
            txtMatAmt_part.Text = cr.Cells["colMatAmt"].Value.ToString();
            txtMatLossRate_part.Text = cr.Cells["colMatLossRate_part"].Value.ToString();
            txtMatLossAmt_part.Text = cr.Cells["colMatLossAmt_part"].Value.ToString();
            txtPlatePrice_Weg_part.Text = cr.Cells["colPlate_price_part"].Value.ToString();
            txtPlateLossRate_part.Text = cr.Cells["colPlateLossRate_part"].Value.ToString() != "" ? cr.Cells["colPlateLossRate_part"].Value.ToString() : "1.1";
            txtPlatePriceIncLoss_part.Text = cr.Cells["colPlatePriceIncLoss_part"].Value.ToString();
            txtPlatePriceIncLossG_part.Text = cr.Cells["colPlatePriceIncLossG_part"].Value.ToString();
            txtMatPlatePrice_part.Text = cr.Cells["colMatPlatePrice_part"].Value.ToString();
            txtDep_part.Text = cr.Cells["colDep_part"].Value.ToString();
            txtDepCharges_part.Text = cr.Cells["colDep_charges_part"].Value.ToString();
        }

        private void txtDepCharges_part_Leave(object sender, EventArgs e)
        {
            countPartAmt();
            setAndFileeTextBox("txtDepCharges_part");
        }


        private void txtMatPrice_part_Leave(object sender, EventArgs e)
        {
            countMmCostingPart();
            setAndFileeTextBox("txtMatPrice_part");
        }
        private void txtMatPlatePrice_part_Leave(object sender, EventArgs e)
        {
            countMmCostingPart();
            setAndFileeTextBox("txtMatPlatePrice_part");
        }

        private void countMmCostingPart()
        {
            //txtMatWegG_part.Text = ((txtMatWeg_part.Text != "" ? Convert.ToDecimal(txtMatWeg_part.Text) / 1000 : 0)).ToString();//銅料重量/1000
            ////每G銅料價錢
            //txtMatPriceG_part.Text = Math.Round((txtMatPrice_part.Text != "" ? Convert.ToDecimal(txtMatPrice_part.Text) : 0) / 1000, 4).ToString();
            ////每G銅料重量 *  每G銅料價錢
            //txtMatAmt_part.Text = Math.Round((txtMatWegG_part.Text != "" ? Convert.ToDecimal(txtMatWegG_part.Text) : 0) * Convert.ToDecimal(txtMatPriceG_part.Text), 4).ToString();
            ////銅料損耗價錢
            //txtMatLossAmt_part.Text = Math.Round((txtMatAmt_part.Text != "" ? Convert.ToDecimal(txtMatAmt_part.Text) : 0)
            //    * (((txtMatLossRate_part.Text != "" ? Convert.ToDecimal(txtMatLossRate_part.Text) : 0)) / 100)
            //    , 4).ToString();
            ////電鍍價錢(含損耗)
            //txtPlatePriceIncLoss_part.Text = Math.Round((txtPlatePrice_Weg_part.Text != "" ? Convert.ToDecimal(txtPlatePrice_Weg_part.Text) : 0)
            //    * (txtPlateLossRate_part.Text != "" ? Convert.ToDecimal(txtPlateLossRate_part.Text) : 0), 4).ToString();
            ////電鍍價錢(含損耗)每G
            //txtPlatePriceIncLossG_part.Text = Math.Round(((txtPlatePrice_Weg_part.Text != "" ? Convert.ToDecimal(txtPlatePrice_Weg_part.Text) : 0)
            //    * (txtPlateLossRate_part.Text != "" ? Convert.ToDecimal(txtPlateLossRate_part.Text) : 0)) / 1000, 4).ToString();
            ////銅料每克的電鍍價錢 = 每克銅料 *  每克電鍍價錢
            //txtMatPlatePrice_part.Text = Math.Round((txtMatWegG_part.Text != "" ? Convert.ToDecimal(txtMatWegG_part.Text) : 0)
            //    * (txtPlatePriceIncLossG_part.Text != "" ? Convert.ToDecimal(txtPlatePriceIncLossG_part.Text) : 0), 4).ToString();

            //txtMmCosting_part.Text = Math.Round((
            //    (txtMatAmt_part.Text != "" ? Convert.ToDecimal(txtMatAmt_part.Text) : 0)
            //    + (txtMatLossAmt_part.Text != "" ? Convert.ToDecimal(txtMatLossAmt_part.Text) : 0)
            //    + (txtPlatePriceIncLossG_part.Text != "" ? Convert.ToDecimal(txtPlatePriceIncLossG_part.Text) : 0)
            //    + (txtDepCharges_part.Text != "" ? Convert.ToDecimal(txtDepCharges_part.Text) : 0)
            //    )
            //    * (txtFactoryChargesRate.Text != "" ? (1 + Convert.ToDecimal(txtFactoryChargesRate.Text) / 100) : 0)
            //    * (txtProfitMarginRate.Text != "" ? (1 + Convert.ToDecimal(txtProfitMarginRate.Text) / 100) : 0)
            //    , 4).ToString();
        }

        //顯示WIP流程中的構成
        private void showWipD()
        {
            //dgvWipPart.DataSource = null;
            if (dgvWip.Rows.Count == 0)
                return;
            DataGridViewRow cr = dgvWip.Rows[dgvWip.CurrentCell.RowIndex];
            string seq = cr.Cells["colSeq_W"].Value.ToString();
            DataTable dtWip = clsMmCosting.getWipRecPart(cr.Cells["colId_W"].Value.ToString(), cr.Cells["colSequence_id_W"].Value.ToString());
            dgvWipPart.DataSource = dtWip;
        }

        private void dgvWip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //showWipD();
        }

        private void dgvWip_SelectionChanged(object sender, EventArgs e)
        {
            showWipD();
            fillTextBoxtPartFromWip(dgvWip.CurrentCell.RowIndex);
        }


        private void fillTextBoxtPartFromWip(int row)
        {
            cleanTextBoxPart();
            if (dgvWip.Rows.Count == 0)
                return;
            DataGridViewRow cr = dgvWip.Rows[row];
            txtId_part.Text = cr.Cells["colGoods_id_W"].Value.ToString();
            txtCdesc_part.Text = cr.Cells["colGoods_cname_W"].Value.ToString();
            txtMatWeg_part.Text = cr.Cells["colWeg_kg_W"].Value.ToString();
            txtMatWegG_part.Text = cr.Cells["colWeg_g_W"].Value.ToString();
            txtMatPrice_part.Text = "";// cr.Cells["colMatPrice_part"].Value.ToString();
            txtMatPriceG_part.Text = "";// cr.Cells["colMatPriceG_part"].Value.ToString();
            txtMatAmt_part.Text = "";// cr.Cells["colMatAmt"].Value.ToString();
            txtMatLossRate_part.Text = "";// cr.Cells["colMatLossRate_part"].Value.ToString();
            txtMatLossAmt_part.Text = "";// cr.Cells["colMatLossAmt_part"].Value.ToString();
            txtPlate_Weg_part.Text = cr.Cells["colPlate_weg_g"].Value.ToString();//電鍍重量
            txtPlatePrice_Weg_part.Text = cr.Cells["colPlate_weg_price_g"].Value.ToString();//電鍍重量單價
            txtPlateAmt_Weg_part.Text = cr.Cells["colPlate_weg_amt_g"].Value.ToString();//電鍍重量費用
            txtPlatePrice_Qty_part.Text = cr.Cells["colPlate_qty_price"].Value.ToString();//電鍍數量單價
            txtPlateAmt_Qty_part.Text = cr.Cells["colPlate_qty_amt"].Value.ToString();//電鍍數量費用
            txtPlateAmt_part.Text = cr.Cells["colPlate_charges_W"].Value.ToString();//電鍍總費用
            txtPlateLossRate_part.Text = "1.1";// cr.Cells["colPlateLossRate_part"].Value.ToString() != "" ? cr.Cells["colPlateLossRate_part"].Value.ToString() : "1.1";
            txtPlatePriceIncLoss_part.Text = "";
            txtPlatePriceIncLossG_part.Text = Math.Round((txtPlateAmt_part.Text != "" ? Convert.ToDecimal(txtPlateAmt_part.Text) : 0) * Convert.ToDecimal(txtPlateLossRate_part.Text), 4).ToString();
            txtMatPlatePrice_part.Text = "";// cr.Cells["colMatPlatePrice_part"].Value.ToString();
            txtDep_part.Text = cr.Cells["colWp_id_W"].Value.ToString();
            txtDepCharges_part.Text = cr.Cells["colDep_charges_W"].Value.ToString();
        }

        private void txtMatWeg_part_Leave(object sender, EventArgs e)
        {
            //countMmCostingPart();

        }
        private void txtMatWegG_part_Leave(object sender, EventArgs e)
        {
            countMatAmtPart();
            setAndFileeTextBox("txtMatWegG_part");
        }
        private void txtMatPriceG_part_Leave(object sender, EventArgs e)
        {
            //countMmCostingPart();
            countMatAmtPart();
            setAndFileeTextBox("txtMatPriceG_part");

        }


        private void countMatAmtPart()
        {
            txtMatAmt_part.Text = Math.Round((txtMatWegG_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatWegG_part.Text) : 0)
                * (txtMatPriceG_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatPriceG_part.Text) : 0), 4).ToString();
            countPartAmt();
            setAndFileeTextBox("txtMatAmt_part");
        }

        private void txtMatAmt_part_Leave(object sender, EventArgs e)
        {
            //countMmCostingPart();
            setAndFileeTextBox("txtMatAmt_part");
        }




        private void txtPlate_Weg_part_Leave(object sender, EventArgs e)
        {
            countPlateWegAmtPart();
            setAndFileeTextBox("txtPlate_Weg_part");

        }
        private void txtPlatePrice_Weg_part_Leave(object sender, EventArgs e)
        {
            countPlateWegAmtPart();
            setAndFileeTextBox("txtPlatePrice_Weg_part");
        }

        private void countPlateWegAmtPart()
        {
            txtPlateAmt_Weg_part.Text = Math.Round((txtPlate_Weg_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlate_Weg_part.Text) : 0)
                * (txtPlatePrice_Weg_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlatePrice_Weg_part.Text) : 0), 4).ToString();
            countPlateAmtPart();
            countPartAmt();
            setAndFileeTextBox("txtPlateAmt_Weg_part");
        }

        private void txtPlateAmt_Weg_part_Leave(object sender, EventArgs e)
        {
            countPartAmt();
            setAndFileeTextBox("txtPlateAmt_Weg_part");
        }
        private void txtPlatePrice_Qty_part_Leave(object sender, EventArgs e)
        {
            txtPlateAmt_Qty_part.Text = txtPlatePrice_Qty_part.Text;
            countPlateAmtPart();
            setAndFileeTextBox("txtPlatePrice_Qty_part");
            setAndFileeTextBox("txtPlateAmt_Qty_part");
        }

        private void txtPlateAmt_Qty_part_Leave(object sender, EventArgs e)
        {
            countPlateAmtPart();
            setAndFileeTextBox("txtPlateAmt_Qty_part");

        }
        private void countPlateAmtPart()
        {
            txtPlateAmt_part.Text = Math.Round((txtPlateAmt_Weg_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt_Weg_part.Text) : 0)
                + (txtPlateAmt_Qty_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt_Qty_part.Text) : 0), 4).ToString();
            countPartAmt();
            setAndFileeTextBox("txtPlateAmt_part");
        }

        private void txtPlateAmt_part_Leave(object sender, EventArgs e)
        {
            countPartAmt();
            setAndFileeTextBox("txtPlateAmt_part");
        }

        private void txtMmCosting_part_Leave(object sender, EventArgs e)
        {
            setAndFileeTextBox("txtMmCosting_part");
        }

        private void countPartAmt()
        {
            txtMmCosting_part.Text = Math.Round((txtMatAmt_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatAmt_part.Text) : 0)
                + (txtPlateAmt_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt_part.Text) : 0)
                + (txtDepCharges_part.Text.Trim() != "" ? Convert.ToDecimal(txtDepCharges_part.Text) : 0), 4).ToString();
            setAndFileeTextBox("txtMmCosting_part");
        }
        private void countF0Amt()
        {
            txtMmCosting.Text = Math.Round((txtMatAmt.Text.Trim() != "" ? Convert.ToDecimal(txtMatAmt.Text) : 0)
                + (txtPlateAmt.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt.Text) : 0)
                + (txtDepCharges.Text.Trim() != "" ? Convert.ToDecimal(txtDepCharges.Text) : 0), 4).ToString();
        }

        private void setAndFileeTextBox(string obj)
        {
            //if (dgvMmCostingPart.Rows.Count == 0)
            //    return;
            //int row = dgvMmCostingPart.CurrentCell.RowIndex;
            //DataGridViewRow CurrentRow = dgvMmCostingPart.Rows[row];
            //if (obj == "txtDepCharges_part")
            //    CurrentRow.Cells["colDep_charges_part"].Value = txtDepCharges_part.Text.Trim() != "" ? Convert.ToDecimal(txtDepCharges_part.Text) : 0;
            //else if (obj == "txtMatWeg_part")
            //    CurrentRow.Cells["colMatWeg_part"].Value = txtMatWeg_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatWeg_part.Text) : 0;
            //else if (obj == "txtMatPrice_part")
            //    CurrentRow.Cells["colMatPrice_part"].Value = txtMatWeg_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatWeg_part.Text) : 0;
            //else if (obj == "txtPlatePrice_part")
            //    CurrentRow.Cells["colMatPrice_part"].Value = txtPlatePrice_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlatePrice_part.Text) : 0;
            //else if (obj == "txtMatPlatePrice_part")
            //    CurrentRow.Cells["colMatPlatePrice_part"].Value = txtMatPlatePrice_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatPlatePrice_part.Text) : 0;
            //Decimal tot_fee = 0;
            //for (int i = 0; i < dgvMmCostingPart.Rows.Count; i++)
            //{
            //    if (obj == "txtDepCharges_part")
            //        tot_fee += dgvMmCostingPart.Rows[i].Cells["colDep_charges_part"].Value.ToString() != "" ? Convert.ToDecimal(dgvMmCostingPart.Rows[i].Cells["colDep_charges_part"].Value.ToString()) : 0;
            //    else if (obj == "txtMatWeg_part")
            //        tot_fee += dgvMmCostingPart.Rows[i].Cells["colMatWeg_part"].Value.ToString() != "" ? Convert.ToDecimal(dgvMmCostingPart.Rows[i].Cells["colMatWeg_part"].Value.ToString()) : 0;
            //    else if (obj == "txtMatPrice_part")
            //        tot_fee += dgvMmCostingPart.Rows[i].Cells["colMatPrice_part"].Value.ToString() != "" ? Convert.ToDecimal(dgvMmCostingPart.Rows[i].Cells["colMatPrice_part"].Value.ToString()) : 0;
            //    else if (obj == "txtPlatePrice_part")
            //        tot_fee += dgvMmCostingPart.Rows[i].Cells["colPlate_price_part"].Value.ToString() != "" ? Convert.ToDecimal(dgvMmCostingPart.Rows[i].Cells["colPlate_price_part"].Value.ToString()) : 0;
            //    else if (obj == "txtMatPlatePrice_part")
            //        tot_fee += dgvMmCostingPart.Rows[i].Cells["colMatPlatePrice_part"].Value.ToString() != "" ? Convert.ToDecimal(dgvMmCostingPart.Rows[i].Cells["colMatPlatePrice_part"].Value.ToString()) : 0;
            //}
            //if (obj == "txtDepCharges_part")
            //    txtDepCharges.Text = tot_fee.ToString();
            //else if (obj == "txtMatWeg_part")
            //    txtMatWeg.Text = tot_fee.ToString();
            //else if (obj == "txtMatPrice_part")
            //    txtMatPrice.Text = tot_fee.ToString();
            //else if (obj == "txtPlatePrice_part")
            //    txtPlatePrice.Text = tot_fee.ToString();
            //else if (obj == "txtMatPlatePrice_part")
            //    txtMatPlatePrice.Text = tot_fee.ToString();
            //setSelectRec(row);//定位到新增的記錄


            if (dgvWip.Rows.Count == 0)
                return;
            int row = dgvWip.CurrentCell.RowIndex;
            DataGridViewRow CurrentRow = dgvWip.Rows[row];
            if (obj == "txtDepCharges_part")//部門加工費
                CurrentRow.Cells["colDep_charges_W"].Value = txtDepCharges_part.Text.Trim() != "" ? Convert.ToDecimal(txtDepCharges_part.Text) : 0;
            else if (obj == "txtMatWegG_part")//銅料重量(g)
                CurrentRow.Cells["colWeg_g_W"].Value = txtMatWegG_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatWegG_part.Text) : 0;
            else if (obj == "txtMatPriceG_part")//銅料單價(g)
                CurrentRow.Cells["colMatPriceG_part_W"].Value = txtMatPriceG_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatPriceG_part.Text) : 0;
            else if (obj == "txtMatAmt_part")//銅料價錢(g)
                CurrentRow.Cells["colMatAmt_W"].Value = txtMatAmt_part.Text.Trim() != "" ? Convert.ToDecimal(txtMatAmt_part.Text) : 0;
            else if (obj == "txtPlate_Weg_part")//電鍍銅料重量
                CurrentRow.Cells["colPlate_weg_g"].Value = txtPlate_Weg_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlate_Weg_part.Text) : 0;
            else if (obj == "txtPlatePrice_Weg_part")//電鍍銅料重量單價
                CurrentRow.Cells["colPlate_weg_price_g"].Value = txtPlatePrice_Weg_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlatePrice_Weg_part.Text) : 0;
            else if (obj == "txtPlateAmt_Weg_part")//電鍍銅料重量價錢
                CurrentRow.Cells["colPlate_weg_amt_g"].Value = txtPlateAmt_Weg_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt_Weg_part.Text) : 0;
            else if (obj == "txtPlatePrice_Qty_part")//電鍍銅料數量單價
                CurrentRow.Cells["colPlate_qty_price"].Value = txtPlatePrice_Qty_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlatePrice_Qty_part.Text) : 0;
            else if (obj == "txtPlateAmt_Qty_part")//電鍍銅料數量價錢
                CurrentRow.Cells["colPlate_qty_amt"].Value = txtPlateAmt_Qty_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt_Qty_part.Text) : 0;
            else if (obj == "txtPlateAmt_part")//電鍍數量 + 重量 價錢
                CurrentRow.Cells["colPlate_charges_W"].Value = txtPlateAmt_part.Text.Trim() != "" ? Convert.ToDecimal(txtPlateAmt_part.Text) : 0;
            else if (obj == "txtMmCosting_part")//配件價錢
                CurrentRow.Cells["colMmCosting_W"].Value = txtMmCosting_part.Text.Trim() != "" ? Convert.ToDecimal(txtMmCosting_part.Text) : 0;
            Decimal tot_fee = 0;
            for (int i = 0; i < dgvWip.Rows.Count; i++)
            {
                DataGridViewRow cr = dgvWip.Rows[i];
                if (obj == "txtDepCharges_part")
                    tot_fee += cr.Cells["colDep_charges_W"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colDep_charges_W"].Value.ToString()) : 0;
                else if (obj == "txtMatWegG_part")//銅料重量(g)
                    tot_fee += cr.Cells["colWeg_g_W"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colWeg_g_W"].Value.ToString()) : 0;
                else if (obj == "txtMatPriceG_part")//銅料單價(g)
                    tot_fee += cr.Cells["colMatPriceG_part_W"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colMatPriceG_part_W"].Value.ToString()) : 0;
                else if (obj == "txtMatAmt_part")//銅料價錢(g)
                    tot_fee += cr.Cells["colMatAmt_W"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colMatAmt_W"].Value.ToString()) : 0;
                else if (obj == "txtPlate_Weg_part")//電鍍銅料重量
                    tot_fee += cr.Cells["colPlate_weg_g"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colPlate_weg_g"].Value.ToString()) : 0;
                else if (obj == "txtPlatePrice_Weg_part")//電鍍銅料重量單價
                    tot_fee += cr.Cells["colPlate_weg_price_g"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colPlate_weg_price_g"].Value.ToString()) : 0;
                else if (obj == "txtPlateAmt_Weg_part")//電鍍銅料重量價錢
                    tot_fee += cr.Cells["colPlate_weg_amt_g"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colPlate_weg_amt_g"].Value.ToString()) : 0;
                else if (obj == "txtPlatePrice_Qty_part")//電鍍銅料數量單價
                    tot_fee += cr.Cells["colPlate_qty_price"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colPlate_qty_price"].Value.ToString()) : 0;
                else if (obj == "txtPlateAmt_Qty_part")//電鍍銅料數量價錢
                    tot_fee += cr.Cells["colPlate_qty_amt"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colPlate_qty_amt"].Value.ToString()) : 0;
                else if (obj == "txtPlateAmt_part")//電鍍數量 + 重量 價錢
                    tot_fee += cr.Cells["colPlate_charges_W"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colPlate_charges_W"].Value.ToString()) : 0;
                else if (obj == "txtMmCosting_part")//配件價錢
                    tot_fee += cr.Cells["colMmCosting_W"].Value.ToString() != "" ? Convert.ToDecimal(cr.Cells["colMmCosting_W"].Value.ToString()) : 0;
            }
            if (obj == "txtDepCharges_part")
                txtDepCharges.Text = tot_fee.ToString();
            else if (obj == "txtMatWegG_part")//銅料重量(g)
                txtMatWegG.Text = tot_fee.ToString();
            else if (obj == "txtMatPriceG_part")//銅料單價(g)
                txtMatPriceG.Text = tot_fee.ToString();
            else if (obj == "txtMatAmt_part")//銅料價錢(g)
                txtMatAmt.Text = tot_fee.ToString();
            else if (obj == "txtPlate_Weg_part")//電鍍銅料重量
                txtPlate_Weg_g.Text = tot_fee.ToString();
            else if (obj == "txtPlatePrice_Weg_part")//電鍍銅料重量單價
                txtPlatePrice_Weg.Text = tot_fee.ToString();
            else if (obj == "txtPlateAmt_Weg_part")//電鍍銅料重量價錢
                txtPlateAmt_Weg.Text = tot_fee.ToString();
            else if (obj == "txtPlatePrice_Qty_part")//電鍍銅料數量單價
                txtPlatePrice_Qty.Text = tot_fee.ToString();
            else if (obj == "txtPlateAmt_Qty_part")//電鍍銅料數量價錢
                txtlblPlateAmt_Qty.Text = tot_fee.ToString();
            else if (obj == "txtPlateAmt_part")//電鍍數量 + 重量 價錢
                txtPlateAmt.Text = tot_fee.ToString();
            else if (obj == "txtMmCosting_part")//F0價錢
                txtMmCosting.Text = tot_fee.ToString();
            countF0Amt();//統計F0的價錢

            setSelectRec(row);//定位到新增的記錄


        }

        private void PrintTreeViewNode(TreeNodeCollection node)
        {
            foreach (TreeNode n in node)
            {
                MessageBox.Show(n.Text + ",");
                //PrintTreeViewNode(n.ChildNodes);
            }
        }

        private void btnShowTree_Click(object sender, EventArgs e)
        {

            #region 递归
            //1.获取TreeView的所有根节点
            foreach (TreeNode tn in MenuTree.Nodes)
            {
                DiGui(tn);
            }
            #endregion

        }

        private void DiGui(TreeNode tn)
        {
            //1.将当前节点显示到lable上
            string bom_level = "";
            string level_flag = "";
            string goods_name = "";
            string tnText="";
            if (tn.Parent != null)
            {
                level_flag = tn.Parent.Level.ToString();
            }
            else
            {
                level_flag = "--";
                
            }
            bom_level = tn.Level.ToString();
            tnText = tn.Text.Trim();
            goods_name = tnText.Substring(tnText.IndexOf("[") + 1, (tnText.Length - (tnText.IndexOf("[") + 1) - 1));
            addBomToTable(level_flag, bom_level, tn.Tag.ToString(), goods_name);
            foreach (TreeNode tnSub in tn.Nodes)
            {
                DiGui(tnSub);
            }
        }

        private void addBomToTable(string level_flag,string bom_level,string goods_id, string goods_name)
        {
            DataRow dr2 = dtBomGrid.NewRow();
            dr2["level_flag"] = level_flag; //通过索引赋值
            dr2["bom_level"] = bom_level; //通过索引赋值
            dr2["goods_id"] = goods_id; //通过索引赋值
            dr2["goods_name"] = goods_name;
            dtBomGrid.Rows.Add(dr2);
        }
    }
}
