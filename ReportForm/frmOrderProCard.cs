using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using cf01.Reports;
using cf01.MDL;
using cf01.CLS;
using RUI.PC;
using System.IO;
using System.Data.SqlClient;
using cf01.Forms;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmOrderProCard : Form
    {
        private clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        private List<Mo_for_jx> lsModel = new List<Mo_for_jx>();
        private DataTable dtGoodsInfo = new DataTable();
        public static DataTable dtNext_Goods= new DataTable();

        private clsUtility.enumOperationType operationType;
        private string goods_id;
        private int Reserve_Qty;
        public static string strProcess = "";
        private DataSet dsCard_product = new DataSet();

        DataTable dtCard_product = new DataTable();
        DataTable dtReport = new DataTable();
        DataTable dtMould = new DataTable();
        public string table_state="";
        public int mCount;

        

        public frmOrderProCard()
        {
            InitializeComponent();           
            //clsControlInfoHelper control = new clsControlInfoHelper("frmOrderProCard", this.Controls);
            //control.GenerateContorl();
            //btnProcess.Enabled = BTNSAVE.Enabled;//按鈕權限是否可用
        }

        private void frmOrderProCard_Load(object sender, EventArgs e)
        {
            txtPrintCopies.Text = "1";   //默認列印份數為1
            txtDept1.Focus();
            txtgoods_name.Enabled = false;
            txtPro_qty.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Print;
            if (ValidateText())
            {
                print_workcard();
            }
        }

        private void BTNPRINTPREVIEW_Click(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.PreView;
            if (ValidateText())
            {
                print_workcard();
            }
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            txtDept1.Text = "";
            txtMoId.Text = "";
            txtgoods_name.Text = "";
            txtPer_qty.Text = "";
            txtPro_qty.Text = "";
        }

        /// <summary>
        /// 驗證輸入的數量是否為真確格式
        /// </summary>
        /// <returns></returns>
        private bool ValidateText()
        {
            if (txtDept1.Text.Trim() == "")
            {
                MessageBox.Show("請輸入部門。");
                txtDept1.Focus();
                return false;
            }

            if (txtMoId.Text.Trim() == "")
            {
                MessageBox.Show("請輸入制單編號。");
                txtMoId.Focus();
                return false;
            }

            if (!Information.IsNumeric(txtPer_qty.Text.Trim()))
            {
                MessageBox.Show("每次生產數量只能輸入數字格式，請重新輸入。");
                txtPer_qty.Focus();
                txtPer_qty.SelectAll();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 選擇物料編號后，填充數據。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowByItem()
        {
            for (int i = 0; i < lsModel.Count; i++)
            {
                if (lueGoodsId.EditValue.ToString() == lsModel[i].sequence_id)
                {
                    Reserve_Qty = lsModel[i].Reserve_qty;
                    goods_id = lsModel[i].goods_id;
                    txtgoods_name.Text = lsModel[i].goods_name;
                    txtPer_qty.Text = lsModel[i].prod_qty.ToString();
                    txtPro_qty.Text = lsModel[i].prod_qty.ToString();
                    txtNextDep.Text = lsModel[i].next_wp_id;//
                    txtNextDepName.Text = lsModel[i].next_wp_name;
                    txtCompDate.Text = lsModel[i].t_complete_date;
                    txtBaseQty.Text = lsModel[i].base_qty;
                    txtGoodsUnit.Text = lsModel[i].unit_code;
                    txtBaseRate.Text = lsModel[i].base_rate;
                    txtBasicUnit.Text = lsModel[i].basic_unit;
                    txtPreDepQty.Text = lsModel[i].predept_rechange_qty;
                    txtSequenceId.Text = lsModel[i].sequence_id;
                    txtBlueprintId.Text = lsModel[i].blueprint_id;
                    txtUnitCode.Text = lsModel[i].unit_code;
                    txtget_color_sample_name.Text = lsModel[i].get_color_sample_name;
                    txtVender_id.Text = lsModel[i].Vendor_id;
                    txtC_sec_qty_ok.Text = lsModel[i].c_sec_qty_ok.ToString();
                    txtWh_location.Text = lsModel[i].wh_location;
                    bom_flevel.Text = lsModel[i].flevel.ToString();
                    getArtDetails();//獲取圖樣代號資料

                    /****************獲取訂單數量*******************/
                    DataTable dtQty = new DataTable();
                    if (txtDept1.Text == "107" && txtNextDep.Text == "601" || txtDept1.Text == "510" && txtNextDep.Text == "601")
                    {
                        dtQty = clsMo_for_jx.GetOrderQtyBasedOnBom(txtMoId.Text.Trim(), goods_id);//滿足以上條件，訂單數量是基於Bom 用量
                    }
                    else
                    {
                        dtQty = clsMo_for_jx.GetOrderQty(txtMoId.Text.Trim());//獲取訂單數量
                    }

                    if (dtQty.Rows.Count > 0)
                    {
                        txtOrderUnit.Text = dtQty.Rows[0]["goods_unit"].ToString();
                        txtOrderQty.Text = Convert.ToInt32(dtQty.Rows[0]["order_qty"]).ToString();
                        txtOrderPcsQty.Text = Convert.ToInt32(dtQty.Rows[0]["order_qty_pcs"]).ToString();
                    }
                    
                    //******************************
                    //以下代碼新增于2019-07-11
                    //當前部門的貨品交下部生產的之物料，并取下部門生產的物料編號，顏色做法、申請的供應商，再交落下一部
                    //******************************
                    DataTable dt = clsMo_for_jx.Get_Next_Department_Flow(txtMoId.Text, lueGoodsId.Text, int.Parse(bom_flevel.Text)-1);
                    if (dt.Rows.Count > 0)
                    {
                        next_goods_id.Text = dt.Rows[0]["goods_id"].ToString();
                        next_next_wp_id.Text = dt.Rows[0]["next_wp_id"].ToString();
                        next_vendor_id.Text = dt.Rows[0]["vendor_id"].ToString();
                        next_do_color.Text = dt.Rows[0]["do_color"].ToString();
                        next_goods_name.Text = dt.Rows[0]["next_goods_name"].ToString();
                        next_next_dep_name.Text = dt.Rows[0]["next_dep_name"].ToString();
                    }
                    else
                    {
                        next_goods_id.Text = "";
                        next_next_wp_id.Text = "";
                        next_vendor_id.Text = "";
                        next_do_color.Text = "";
                        next_goods_name.Text = "";
                        next_next_dep_name.Text = "";
                    }

                    break;
                }
            }
        }

        private void getArtDetails()
        {
            DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(goods_id);
            DataTable dtColorInfo = clsMo_for_jx.GetColorInfo(txtDept1.Text.Trim(), txtMoId.Text.Trim(), goods_id);
            DataTable dtSize = clsMo_for_jx.GetGoods_Size(goods_id.Substring(11, 3));
            if (dtArt.Rows.Count > 0)
            {
                txtPicPath.Text = dtArt.Rows[0]["picture_name"].ToString();
                txtArtId.Text = dtArt.Rows[0]["art_id"].ToString();
                picArtWork.Image = null;
                if (txtPicPath.Text.Trim() != "")
                {
                    clsPublicOfGEO clsConErp = new clsPublicOfGEO();
                    string imageFileName = clsConErp.getErpImagePath() + txtPicPath.Text.Trim();
                    if (File.Exists(imageFileName))
                    {
                        picArtWork.Image = Image.FromFile(imageFileName);
                    }
                    //if (File.Exists(txtPicPath.Text.Trim()))
                    //{
                    //    picArtWork.Image = Image.FromFile(txtPicPath.Text.Trim());
                    //}
                }
            }

            if (dtColorInfo.Rows.Count > 0)
            {
                txtColorName.Text = dtColorInfo.Rows[0]["color_name"].ToString();
                txtColorDo.Text = dtColorInfo.Rows[0]["do_color"].ToString();
                txtColor.Text = dtColorInfo.Rows[0]["color_id"].ToString();
            }
            if (dtSize.Rows.Count > 0)
            {
                txtSizeName.Text = dtSize.Rows[0]["size_name"].ToString();

            }
        }

        /// <summary>
        /// 根據部門、制單編號查詢單據信息
        /// </summary>
        private void GetGoodsDetails()
        {
            if (txtMoId.Text == "")
            {
                lueGoodsId.Properties.DataSource = null;
                lueGoodsId.Refresh();
                return;
            }
            dtGoodsInfo = clsMo_for_jx.GetGoods_DetailsById(txtDept1.Text, txtMoId.Text, "");
            if (dtGoodsInfo.Rows.Count > 0)
            {

                lsModel.Clear();
                for (int i = 0; i < dtGoodsInfo.Rows.Count; i++)
                {
                    Mo_for_jx objModel = new Mo_for_jx() { 
                        wp_id = dtGoodsInfo.Rows[i]["wp_id"].ToString(), 
                        mo_id = dtGoodsInfo.Rows[i]["mo_id"].ToString(), 
                        goods_id = dtGoodsInfo.Rows[i]["goods_id"].ToString(), 
                        goods_name = dtGoodsInfo.Rows[i]["name"].ToString(), 
                        prod_qty = Convert.ToInt32(dtGoodsInfo.Rows[i]["prod_qty"]), 
                        goods_unit = dtGoodsInfo.Rows[i]["goods_unit"].ToString(), 
                        bill_date = dtGoodsInfo.Rows[i]["bill_date"].ToString(),
                        check_date = dtGoodsInfo.Rows[i]["check_date"].ToString(), 
                        order_qty = string.IsNullOrEmpty(txtOrderQty.Text) ? 0 : Convert.ToInt32(txtOrderQty.Text), 
                        next_wp_id = dtGoodsInfo.Rows[i]["next_wp_id"].ToString(), 
                        next_wp_name = dtGoodsInfo.Rows[i]["next_wp_name"].ToString(), 
                        t_complete_date = dtGoodsInfo.Rows[i]["t_complete_date"].ToString(), 
                        brand_id = dtGoodsInfo.Rows[i]["brand_id"].ToString(), 
                        get_color_sample = dtGoodsInfo.Rows[i]["get_color_sample"].ToString(), 
                        order_unit = txtOrderUnit.Text, 
                        production_remark = dtGoodsInfo.Rows[i]["production_remark"].ToString(), 
                        nickle_free = dtGoodsInfo.Rows[i]["nickle_free"].ToString(), 
                        plumbum_free = dtGoodsInfo.Rows[i]["plumbum_free"].ToString(), 
                        remark = dtGoodsInfo.Rows[i]["remark"].ToString(), 
                        base_qty = dtGoodsInfo.Rows[i]["base_qty"].ToString(), 
                        unit_code = dtGoodsInfo.Rows[i]["unit_code"].ToString(), 
                        base_rate = dtGoodsInfo.Rows[i]["base_rate"].ToString(), 
                        basic_unit = dtGoodsInfo.Rows[i]["basic_unit"].ToString(), 
                        within_code = dtGoodsInfo.Rows[i]["within_code"].ToString(), 
                        ver = dtGoodsInfo.Rows[i]["ver"].ToString(), 
                        id = dtGoodsInfo.Rows[i]["id"].ToString(), 
                        sequence_id = dtGoodsInfo.Rows[i]["sequence_id"].ToString(), 
                        blueprint_id = dtGoodsInfo.Rows[i]["blueprint_id"].ToString(), 
                        color = dtGoodsInfo.Rows[i]["color"].ToString(), 
                        predept_rechange_qty = dtGoodsInfo.Rows[i]["predept_rechange_qty"].ToString(), 
                        Reserve_qty = clsUtility.FormatNullableInt32(dtGoodsInfo.Rows[i]["OBLIGATE_QTY"]), 
                        get_color_sample_name = dtGoodsInfo.Rows[i]["get_color_sample_name"].ToString(), 
                        Vendor_id = dtGoodsInfo.Rows[i]["vendor_id"].ToString(), 
                        c_sec_qty_ok = clsUtility.FormatNullableInt32(dtGoodsInfo.Rows[i]["c_sec_qty_ok"]),
                        wh_location=dtGoodsInfo.Rows[i]["wh_location"].ToString(),
                        flevel = !string.IsNullOrEmpty(dtGoodsInfo.Rows[i]["flevel"].ToString())?int.Parse(dtGoodsInfo.Rows[i]["flevel"].ToString()):0                       
                    };
                    lsModel.Add(objModel);
                }
                BindcmboxGoodsId();
                string str_mo_id = txtMoId.Text;
                if (str_mo_id.Substring(0, 1) != "R")
                    txtPrdRemark.Text = dtGoodsInfo.Rows[0]["production_remark"].ToString();
                else
                    txtPrdRemark.Text = clsMo_for_jx.Get_Repair_Mo_Product_Remark(str_mo_id);
                txtBrandId.Text = dtGoodsInfo.Rows[0]["brand_id"].ToString();
                txtRemark.Text = dtGoodsInfo.Rows[0]["remark"].ToString();
                txtCust.Text = dtGoodsInfo.Rows[0]["customer_id"].ToString();
                txtVer.Text = dtGoodsInfo.Rows[0]["ver"].ToString();
                txtReqSample.Text = dtGoodsInfo.Rows[0]["get_color_sample"].ToString();
                txtId.Text = dtGoodsInfo.Rows[0]["id"].ToString();
                if (dtGoodsInfo.Rows[0]["nickle_free"].ToString() == "1")
                    txtReqTest.Text = "無叻;";
                else
                    txtReqTest.Text = "";
                if (dtGoodsInfo.Rows[0]["plumbum_free"].ToString() == "1")
                    txtReqTest.Text = txtReqTest.Text.Trim() + "無鉛;";
            }
            else
            {
                // lsModel.Clear();
                lueGoodsId.Properties.DataSource = null;
                lueGoodsId.Refresh();
                MessageBox.Show("找不到頁數對應的流程!","提示信息");
            }
        }

        /// <summary>
        /// 綁定物料編號
        /// </summary>
        void BindcmboxGoodsId()
        {
            if (lsModel.Count > 0)
            {
                DataTable dtcmboxSource = new DataTable();

                dtcmboxSource.Columns.Add(new DataColumn("next_wp_id", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("goods_id", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("goods_name", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("sequence_id", typeof(string)));
                DataRow dr = null;
                for (int i = 0; i < lsModel.Count; i++)
                {
                    dr = dtcmboxSource.NewRow();
                    dr["next_wp_id"] = lsModel[i].next_wp_id;
                    dr["goods_id"] = lsModel[i].goods_id;
                    dr["goods_name"] = lsModel[i].goods_name;
                    dr["sequence_id"] = lsModel[i].sequence_id;
                    dtcmboxSource.Rows.Add(dr);
                }
                if (dtcmboxSource.Rows.Count > 0)
                {
                    lueGoodsId.Text = "";
                    lueGoodsId.EditValue = "";
                    lueGoodsId.Properties.DataSource = dtcmboxSource;
                    lueGoodsId.Properties.ValueMember = "sequence_id";
                    lueGoodsId.Properties.DisplayMember = "goods_id";
                }
            }

        }

        /// <summary>
        /// 獲取打印工序卡數據
        /// </summary>
        private void print_workcard()
        {
            if (!ValidateWeight())
                return;
            String dep, mo;
            dep = txtDept1.Text.Trim();
            mo = txtMoId.Text.Trim();
            if (dep != "" && mo != "" && goods_id != "")
            {
                DataTable dtRemark = dtGoodsInfo.Copy();
                if (dtGoodsInfo.Rows.Count > 0)
                {
                    int PrintCopies = Convert.ToInt32(txtPrintCopies.Text.Trim());  //列印份數
                    int Per_qty = Convert.ToInt32(txtPer_qty.Text.Trim());  //每次生產數量
                    if (Per_qty == 0)
                        Per_qty = 1;
                    int Total_qty = Convert.ToInt32(txtPro_qty.Text.Trim());    //生產總量
                    int NumPage = 0;     //報表頁數

                    DataTable dtNewWork = new DataTable();
                    dtNewWork = dtRemark;
                    dtNewWork.Rows.Clear();
                    dtNewWork.Columns.Add("report_name", typeof(string));
                    dtNewWork.Columns.Remove("t_complete_date");
                    dtNewWork.Columns.Remove("base_rate");
                    dtNewWork.Columns.Remove("base_qty");
                    dtNewWork.Columns.Remove("prod_qty");
                    dtNewWork.Columns.Remove("name");
                    dtNewWork.Columns.Add("per_qty", typeof(string));
                    dtNewWork.Columns.Add("page_num", typeof(int));
                    dtNewWork.Columns.Add("total_page", typeof(int));
                    dtNewWork.Columns.Add("t_complete_date", typeof(string));
                    dtNewWork.Columns.Add("base_rate", typeof(int));
                    dtNewWork.Columns.Add("base_qty", typeof(int));
                    dtNewWork.Columns.Add("prod_qty", typeof(string));
                    dtNewWork.Columns.Add("order_qty", typeof(string));
                    dtNewWork.Columns.Add("order_qty_pcs", typeof(string));
                    dtNewWork.Columns.Add("do_color1", typeof(string));
                    dtNewWork.Columns.Add("art_id", typeof(string));
                    dtNewWork.Columns.Add("picture_name", typeof(string));
                    //dtNewWork.Columns.Add("do_color", typeof(string));
                    //dtNewWork.Columns.Add("color_name", typeof(string));
                    dtNewWork.Columns.Add("next_dep_name", typeof(string));
                    dtNewWork.Columns.Add("goods_name", typeof(string));
                    dtNewWork.Columns.Add("net_weight", typeof(string));
                    dtNewWork.Columns.Add("BarCode", typeof(string));

                    dtNewWork.Columns.Add("next_goods_id", typeof(string));
                    dtNewWork.Columns.Add("next_do_color", typeof(string));
                    dtNewWork.Columns.Add("next_next_wp_id", typeof(string));
                    dtNewWork.Columns.Add("next_vendor_id", typeof(string));
                    dtNewWork.Columns.Add("next_goods_name", typeof(string));
                    dtNewWork.Columns.Add("next_next_dep_name", typeof(string));
                    dtNewWork.Columns.Add("prod_date", typeof(string));
                    
                    if (Total_qty > 0)
                    {
                        if (Total_qty % Per_qty > 0)                        
                            NumPage = (Total_qty / Per_qty) + 1;                        
                        else                        
                            NumPage = (Total_qty / Per_qty);                        
                    }
                    else
                    {
                        //if (Reserve_Qty > 0)  //如果生產數量為0，且預留數量大於0，任需要打印工序卡
                        //{
                        NumPage = 1;
                        //}
                    }

                    DataRow dr = null;
                    for (int j = 1; j <= PrintCopies; j++)
                    {
                        for (int i = 1; i <= NumPage; i++)
                        {
                            dr = dtNewWork.NewRow();
                            dr["total_page"] = NumPage;
                            dr["wp_id"] = dep;
                            if (dep == "302" || dep == "322")
                                dr["report_name"] = "生產單" + "(" + dep + ")";
                            else
                                dr["report_name"] = "工序卡" + "(" + dep + ")";
                            dr["mo_id"] = mo;
                            dr["goods_id"] = goods_id;
                            dr["goods_name"] = txtgoods_name.Text.Trim();
                            dr["prod_qty"] = clsUtility.NumberConvert(txtPro_qty.Text);
                            dr["prod_date"] = txtProd_date.Text;
                            dr["per_qty"] = clsUtility.NumberConvert(txtPer_qty.Text);
                            dr["goods_unit"] = txtGoodsUnit.Text.Trim();
                            dr["within_code"] = "0000";
                            dr["id"] = txtId.Text.Trim();
                            dr["ver"] = clsUtility.FormatNullableInt32(txtVer.Text);
                            dr["sequence_id"] = txtSequenceId.Text.Trim();
                            dr["blueprint_id"] = txtBlueprintId.Text.Trim();
                            dr["production_remark"] = txtPrdRemark.Text.Trim();
                            dr["remark"] = txtRemark.Text.Trim();
                            dr["next_wp_id"] = txtNextDep.Text.Trim();
                            if (txtPreDepQty.Text != "")
                                dr["predept_rechange_qty"] = clsUtility.FormatNullableDecimal(txtPreDepQty.Text);
                            if (txtOrderQty.Text != "")
                                dr["order_qty"] = clsUtility.NumberConvert(txtOrderQty.Text);
                            dr["order_unit"] = txtOrderUnit.Text.Trim();
                            dr["color"] = txtColor.Text.Trim();
                            if (txtBaseQty.Text != "")
                                dr["base_qty"] = clsUtility.FormatNullableInt32(txtBaseQty.Text);
                            dr["unit_code"] = txtUnitCode.Text.Trim();
                            if (txtBaseRate.Text != "")
                                dr["base_rate"] = clsUtility.FormatNullableInt32(txtBaseRate.Text);
                            dr["basic_unit"] = txtBasicUnit.Text.Trim();
                            dr["art_id"] = txtArtId.Text.Trim();
                            dr["picture_name"] =txtPicPath.Text.Trim();
                            dr["color_name"] = txtColorName.Text.Trim();
                            dr["do_color"] = txtColorDo.Text.Trim();
                            if (txtOrderPcsQty.Text != "")
                                dr["order_qty_pcs"] = clsUtility.NumberConvert(txtOrderPcsQty.Text);
                            dr["next_dep_name"] = txtNextDepName.Text.Trim();
                            dr["customer_id"] = txtCust.Text.Trim();
                            dr["brand_id"] = txtBrandId.Text.Trim();
                            dr["get_color_sample"] = txtReqSample.Text.Trim();
                            dr["do_color1"] = txtReqSample.Text.Trim();
                            dr["get_color_sample_name"] = txtget_color_sample_name.Text.Trim();
                            dr["vendor_id"] = txtVender_id.Text.Trim();
                            dr["c_sec_qty_ok"] = clsUtility.FormatNullableInt32(txtC_sec_qty_ok.Text);
                            dr["net_weight"] = txtNet_weight.Text.Trim();
                            dr["page_num"] = i;
                            dr["wh_location"] = txtWh_location.Text;

                            if (txtCompDate.Text.Trim() != "" && txtCompDate.Text.Trim() != null)
                            {
                                dr["t_complete_date"] = Convert.ToDateTime(txtCompDate.Text).ToString("yyyy/MM/dd");
                            }

                            if (i == NumPage && Per_qty != 0)
                            {
                                if (Total_qty % Per_qty > 0)
                                {
                                    dr["per_qty"] = clsUtility.NumberConvert(Total_qty % Per_qty);
                                }
                                else
                                {
                                    dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                                }
                            }
                            else
                            {
                                dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                            }
                            //條碼
                            dr["BarCode"] = clsMo_for_jx.ReturnBarCode(String.Format("{0}{1}{2}", txtMoId.Text.Trim(), txtVer.Text.Trim().PadLeft(2,'0'), txtSequenceId.Text.Substring(2, 2)));

                            //下部物料相關信息
                            dr["next_goods_id"]=next_goods_id.Text;
                            dr["next_do_color"] = next_do_color.Text;
                            dr["next_next_wp_id"] = next_next_wp_id.Text;
                            dr["next_vendor_id"] = txtVender_id.Text.Trim(); //next_vendor_id.Text;
                            dr["next_goods_name"] = next_goods_name.Text;
                            dr["next_next_dep_name"] = next_next_dep_name.Text;

                            dtNewWork.Rows.Add(dr);
                        }
                    }

                    if (dtNewWork.Rows.Count > 0)
                    {                        
                        if (!chkPA4.Checked)//工序卡非A4纸
                        {                            
                            using (xtaWork_No_BarCode xr = new xtaWork_No_BarCode() { DataSource = dtNewWork })
                            {
                                xr.CreateDocument();
                                xr.PrintingSystem.ShowMarginsWarning = false;
                                if (operationType == clsUtility.enumOperationType.PreView)
                                    xr.ShowPreviewDialog();//判斷是預覽 Or 打印                            
                                else
                                    xr.Print();
                            }
                        }
                        else
                        {
                            using (xtaWork_No_BarCodeA4 xr = new xtaWork_No_BarCodeA4() { DataSource = dtNewWork })
                            {
                                xr.CreateDocument();
                                xr.PrintingSystem.ShowMarginsWarning = false;
                                if (operationType == clsUtility.enumOperationType.PreView)
                                    xr.ShowPreviewDialog();//判斷是預覽 Or 打印                            
                                else
                                    xr.Print();
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("該數據無需打印工序卡!","提示信息");
                    }

                }
            }
        }

        private bool ValidateWeight()
        {
            if (txtNet_weight.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtNet_weight.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("輸入的淨重格式不正確，請重新輸入！","提示信息");
                    txtNet_weight.Focus();
                    txtNet_weight.SelectAll();
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// 清空
        /// </summary>
        private void ClearForm()
        {
            foreach (Control ct in Controls)
            {
                switch (ct.GetType().Name)
                {
                    case "TextBox":
                        {
                            TextBox txt = (TextBox)ct;
                            if (txt.Name != "txtDept1" && txt.Name != "txtMoId" && txt.Name != "txtPrintCopies")
                            {
                                if (txt.Name.Trim().Length > 2 && txt.Name.Substring(0, 3) == "txt")
                                {
                                    txt.Text = "";
                                }
                            }
                            break;
                        }
                    case "PictureBox":
                        {
                            PictureBox pic = (PictureBox)ct;
                            pic.Image = null;
                            break;
                        }
                    case "ComboBox":
                        {
                            ComboBox comb = (ComboBox)ct;
                            comb.Text = null;
                            break;
                        }
                }
            }
        }

        private void txtMoId_Leave(object sender, EventArgs e)
        {
            ClearForm();
            GetGoodsDetails();
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            ClearForm();
        }   

        private void txtMoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lueGoodsId.Focus();
                lueGoodsId.Text = "";
            }
        }

        private void txtDept1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMoId.Focus();
            }
        }
    
        private void BTNPRINT_PRODUCT_Click(object sender, EventArgs e)
        {
            if ((txtDept1.Text=="106" || txtDept1.Text=="126") && !string.IsNullOrEmpty(txtMoId.Text) && !string.IsNullOrEmpty(lueGoodsId.EditValue.ToString())) 
            {
                SqlParameter[] spars=new SqlParameter[]{
                    new SqlParameter("@mo_id",txtMoId.Text)
                };
                
                DataSet ds = clsPublicOfGEO.ExecuteProcedureReturnDataSet("z_rpt_card_product_dm", spars, null);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //如果OC與計劃的Sales Bom內容不一致將出現列印不出生產單（即主表部分將變成空白，明細有內容）
                    MessageBox.Show("銷售訂單資料與生產計劃資料不相符,無法列印打模部生產單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    xrPrdTransfer_dm xrPT = new xrPrdTransfer_dm(ds.Tables[0], ds.Tables[1]);
                    xrPT.ShowPreviewDialog();
                }
                return;
            }

            const string str_dept = "302,322";
            //if (!txtDept1.Text.Contains("302,322"))
            if(!str_dept.Contains(txtDept1.Text))
            {
                MessageBox.Show("此生產單只為合金部使用!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(table_state) && dtReport.Rows.Count > 0)
            {
                Print(txtDept1.Text);
            }
            else
                MessageBox.Show("請首先添加到列印生產單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void Print(string pType)
        {
                //加載報表
                if (chkPA5.Checked)
                {
                    xrPrd_card_A5 oRepot = new xrPrd_card_A5() { DataSource = dtReport };
                    oRepot.CreateDocument();
                    oRepot.PrintingSystem.ShowMarginsWarning = false;
                    oRepot.ShowPreview();
                }
                else
                {
                    xrPrd_card_A4 oRepot = new xrPrd_card_A4() { DataSource = dtReport };
                    oRepot.CreateDocument();
                    oRepot.PrintingSystem.ShowMarginsWarning = false;
                    oRepot.ShowPreview();
                }              
               
            
        }

        private void lueGoodsId_EditValueChanged(object sender, EventArgs e)
        {
            ShowByItem();

            string strMO = txtMoId.Text;
            string strMat_Goods = lueGoodsId.Text;
            string strDept = txtDept1.Text;
            if (!string.IsNullOrEmpty(strMO) && !string.IsNullOrEmpty(strMat_Goods) && !string.IsNullOrEmpty(strDept))
            {
                if (strDept == "302" || strDept=="322")
                {
                    txtProcess_group_id.Text = clsMo_for_jx.Get_netx_dept_Item(strDept, strMO, strMat_Goods);
                    string sql = string.Format(@"select time_loop,time_spray,counts1,time_die_thimble,counts2,time_mould_begin,time_mould_work,test_mould_by,remark_mould 
                            from dbo.bs_process_mould with(nolock) where dept_id='{0}' and goods_id='{1}'", strDept, strMat_Goods);
                    dtMould = clsPublicOfCF01.GetDataTable(sql);
                    dataGridView1.DataSource = dtMould;
                }
            }
            Set_Process_Data("1");
        }

        private void Set_Process_Data(string pType)
        {
            //2015-07-27號增加此功能*********
            string strMO = txtMoId.Text;
            string strMat_Goods = lueGoodsId.Text;
            string strDept = txtDept1.Text;
            string strGoods_Id = "";
            string strGoods_id_name = "";
            string strNext_wp_id = "";
            string strNext_dept_name = "";
            string strProcess_group_id = txtProcess_group_id.Text;
            if (!string.IsNullOrEmpty(strMO) && !string.IsNullOrEmpty(strMat_Goods) && !string.IsNullOrEmpty(strDept))
            {
                if (strDept == "302" || strDept == "322")
                {
                    dtNext_Goods = clsMo_for_jx.GetNextGoods_Id(strMO, strMat_Goods, strDept);
                    if (dtNext_Goods.Rows.Count == 0)
                    {
                        return;
                    }
                    strGoods_Id = dtNext_Goods.Rows[0]["sup_bom_no"].ToString();
                    strGoods_id_name = dtNext_Goods.Rows[0]["goods_name"].ToString();
                    strNext_wp_id = dtNext_Goods.Rows[0]["next_wp_id"].ToString();
                    strNext_dept_name = dtNext_Goods.Rows[0]["dept_name"].ToString();
                    
                    bool isSave = BTNSAVE.Enabled;//保存權限
                    //是否存在此設置，不存在則打開工序設置窗體
                    using (DataTable dtSet_Process = clsMo_for_jx.GetSet_Process_Data(strDept, strMat_Goods, strGoods_Id))
                    {
                        if (pType == "1")
                        {
                            if (dtSet_Process.Rows.Count > 0)
                            {
                                //不打開窗口
                                return;
                            }
                        }
                    }                   
                    strProcess = "";
                    frmSetProcess frm = new frmSetProcess(strDept, strMat_Goods, txtgoods_name.Text, strGoods_Id, strGoods_id_name, isSave, strNext_wp_id, strNext_dept_name, strProcess_group_id);
                    frm.ShowDialog();
                    frm.Dispose();
                    if (!string.IsNullOrEmpty(strProcess))
                    {
                        txtProcess_group_id.Text = strProcess;
                    }                    
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //設置的工序流程出不來是因為用戶可能手動改了流程導至表jo_bill_goods_details中的
            //bom_id,sup_bom_no為空或對不上
            //bom_id為當前物料的子層BOM 的ID,例如當goods_id等于'AYJLHI88003120NEP0'時，將bom_id的值改為'AYJLHI88003120NEP0001'
            //sup_bom_no為當前物料的父層物料編碼，將sup_bom_no的值改為'AYJLHI880031200W33'

            Set_Process_Data("2");
        }

        private void btnAddtoReport_Click(object sender, EventArgs e)
        {            
            string strMO = txtMoId.Text;
            string strMat_Goods = lueGoodsId.Text;
            string strDept = txtDept1.Text;
            if (strDept == "106")
            {
                MessageBox.Show("106部門請直接點擊【生產單列印】!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(strMO) && !string.IsNullOrEmpty(strMat_Goods) && !string.IsNullOrEmpty(strDept))
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@dept", strDept),
                    new SqlParameter("@mo_id",strMO),
                    new SqlParameter("@mat_item",strMat_Goods)                    
                };
                dtCard_product = clsPublicOfGEO.ExecuteProcedureReturnTable("z_rpt_card_product_test", paras);
                if (string.IsNullOrEmpty(table_state))
                {
                    dtReport = dtCard_product.Clone();//克隆表結構
                    dtReport.Columns.Add("size_name", typeof(string));
                    table_state = "OK";
                }

                if (dtCard_product.Rows.Count > 0)
                {
                    mCount +=  1;
                    txtMo_count.Text = mCount.ToString();
                    for (int i = 0; i < dtCard_product.Rows.Count; i++)
                    {
                        DataRow newRow = dtReport.NewRow();
                        newRow["id"] = mCount.ToString() ;
                        newRow["barcode"] = dtCard_product.Rows[i]["barcode"].ToString();
                        newRow["mo_id"] = dtCard_product.Rows[i]["mo_id"].ToString();
                        newRow["ver"] = dtCard_product.Rows[i]["ver"].ToString();
                        newRow["seq_id"] = dtCard_product.Rows[i]["seq_id"].ToString();
                        newRow["goods_id"] = dtCard_product.Rows[i]["goods_id"].ToString();
                        newRow["goods_name_mat"] = dtCard_product.Rows[i]["goods_name_mat"].ToString();
                        newRow["sup_bom_no"] = dtCard_product.Rows[i]["sup_bom_no"].ToString();
                        newRow["goods_name"] = dtCard_product.Rows[i]["goods_name"].ToString();
                        newRow["order_qty"] = dtCard_product.Rows[i]["order_qty"];
                        newRow["prod_qty"] = dtCard_product.Rows[i]["prod_qty"];
                        newRow["t_complete_date"] = dtCard_product.Rows[i]["t_complete_date"];
                        newRow["wp_id"] = dtCard_product.Rows[i]["wp_id"].ToString();
                        newRow["prd_dept_name"] = dtCard_product.Rows[i]["prd_dept_name"].ToString();
                        newRow["next_wp_id"] = dtCard_product.Rows[i]["next_wp_id"].ToString();
                        newRow["next_wp_name"] = dtCard_product.Rows[i]["next_wp_name"].ToString();
                        newRow["do_color"] = dtCard_product.Rows[i]["do_color"].ToString();
                        newRow["prod_type_name"] = dtCard_product.Rows[i]["prod_type_name"].ToString();
                        newRow["md_no"] = dtCard_product.Rows[i]["md_no"].ToString();
                        newRow["md_position"] = dtCard_product.Rows[i]["md_position"].ToString();
                        newRow["md_no_ver"] = dtCard_product.Rows[i]["md_no_ver"].ToString();
                        newRow["bom_weg"] = dtCard_product.Rows[i]["bom_weg"].ToString();
                        newRow["out_qty"] = dtCard_product.Rows[i]["out_qty"].ToString();
                        newRow["qty_p"] = dtCard_product.Rows[i]["qty_p"];
                        newRow["picture_name"] = dtCard_product.Rows[i]["picture_name"].ToString();
                        newRow["process_group_id"] = dtCard_product.Rows[i]["process_group_id"].ToString();
                        newRow["process_id"] = dtCard_product.Rows[i]["process_id"].ToString();
                        newRow["cdesc"] = dtCard_product.Rows[i]["cdesc"].ToString();
                        newRow["rotate_speed"] = dtCard_product.Rows[i]["rotate_speed"].ToString();
                        newRow["grind_ratio"] = dtCard_product.Rows[i]["grind_ratio"].ToString();
                        newRow["material"] = dtCard_product.Rows[i]["material"].ToString();
                        newRow["grind_time"] = dtCard_product.Rows[i]["grind_time"].ToString();
                        newRow["size_name"] = txtSizeName.Text;
                        newRow["time_loop"] = dtCard_product.Rows[i]["time_loop"].ToString();
                        newRow["time_spray"] = dtCard_product.Rows[i]["time_spray"].ToString();
                        newRow["counts1"] = dtCard_product.Rows[i]["counts1"].ToString();
                        newRow["time_die_thimble"] = dtCard_product.Rows[i]["time_die_thimble"].ToString();
                        newRow["counts2"] = dtCard_product.Rows[i]["counts2"].ToString();
                        newRow["time_mould_begin"] = dtCard_product.Rows[i]["time_mould_begin"].ToString();
                        newRow["time_mould_work"] = dtCard_product.Rows[i]["time_mould_work"].ToString();
                        newRow["test_mould_by"] = dtCard_product.Rows[i]["test_mould_by"].ToString();
                        newRow["remark_mould"] = dtCard_product.Rows[i]["remark_mould"].ToString();
                        newRow["print_date"] = dtCard_product.Rows[i]["print_date"].ToString();
                        dtReport.Rows.Add(newRow);
                    }
                    clsUtility.myMessageBox("添加列印的數據成功!", "提示信息");                   
                    return;
                }
                else
                    MessageBox.Show("找不到要添加列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtReport.Clear();
            mCount = 0;
            txtMo_count.Text = "";
        }

        private void txtPer_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;//經過判斷爲數字可以輸入
            }
        }

        private void txtPrintCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;//經過判斷爲數字可以輸入
            }
        }

        private void txtNet_weight_KeyPress(object sender, KeyPressEventArgs e)
        {            
            int kc = (int)e.KeyChar;
            if ((kc < 48 || kc > 57) && kc != 8 && kc != 46)
                e.Handled = true;
            if (kc == 46)                       //小数点  
            {
                if (txtNet_weight.Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位  
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtNet_weight.Text, out oldf);
                    b2 = float.TryParse(txtNet_weight.Text + e.KeyChar, out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }            
        }

        private void btnInsPrint_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("沒有要列印的記錄!");
                return;
            }
            xrProdInspection oRepot = new xrProdInspection() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void btoMachine_Click(object sender, EventArgs e)
        {
            frmProcess_Mould frm = new frmProcess_Mould() { 
                prddep = txtDept1.Text, 
                goodsid = lueGoodsId.Text 
            };
            frm.ShowDialog();
            frm.Dispose();
        }

        private void frmOrderProCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsPublicOfGEO = null;
            lsModel = null;
            dtGoodsInfo.Dispose();
            dtNext_Goods.Dispose();
            dsCard_product.Dispose();

            dtCard_product.Dispose();
            dtReport.Dispose();
            dtMould.Dispose();

        }

        private void txtPro_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;//經過判斷爲數字可以輸入
            }
        }

       








    }
}
