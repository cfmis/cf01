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
using System.IO;

namespace cf01.MM
{
    public partial class frmCountGoodsCostFind : Form
    {
        frmProcessBarWindows processBarWindows;
        int progressBar_Cnt2 = 0;
        int Coun = 100;
        int pausCnt = 20;

        public frmCountGoodsCostFind()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            progressBar_Cnt2 = 0;
            processBarWindows = new frmProcessBarWindows(0, Coun, "正在儲存配件數據，請稍候。。。");

            ShowProcessBar();

            //**********************
            DataTable dtPrd = QueryProductCost(); //数据处理
            dgvGoodsCostHead.DataSource = dtPrd;
            HideProcessBar();
            if (dgvGoodsCostHead.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private DataTable QueryProductCost()
        {
            string moGroup = lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString() : "";
            DataTable dtPrd = clsCountGoodsCost.QueryProductCost(txtProcesslId.Text.Trim(), txtProcessName.Text.Trim()
                , txtID.Text,txtCustColor.Text,moGroup);
            LoadProductCostPrt(-999);
            return dtPrd;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProductCostPrt(int upperSN)
        {
            DataTable dtPart = clsCountGoodsCost.LoadProductCostPart(upperSN, "");
            gcGoodsCostDetails.DataSource = dtPart;
        }


        private void btnAddCost_Click(object sender, EventArgs e)
        {
            //if (frmCountGoodsCost.newMode != 1)
            //{
            //    MessageBox.Show("非新增狀態下不能選擇複製！");
            //    return;
            //}
            //if(frmCountGoodsCost.dtGoodsPartDetails.Rows.Count==0)
            //{
            //    frmCountGoodsCost.dtGoodsPartDetails = clsCountGoodsCost.LoadProductCostPart(-999, "");
            //}
            bool selectFlag = false;
            //////配件表中，如果最後一行為小計(Seq=="ZZ")，則先移除這行
            DataTable dtGoodsPartDetails = frmCountGoodsCost.dtGoodsPartDetails;
            if(dtGoodsPartDetails.Rows.Count>0)
            {
                int LastRows = dtGoodsPartDetails.Rows.Count - 1;
                if(dtGoodsPartDetails.Rows[LastRows]["Seq"].ToString()=="ZZ")
                {
                    dtGoodsPartDetails.Rows.RemoveAt(LastRows);
                }
            }
            
            for (int i=0;i<gvGoodsCostDetails.DataRowCount-1;i++)
            {
                DataRow Row = gvGoodsCostDetails.GetDataRow(i);
                if (Row["SelectFlag"].ToString()==""?false:Convert.ToBoolean(Row["SelectFlag"].ToString())==true)
                {
                    DataRow dr =dtGoodsPartDetails.NewRow();
                    dr["SN"] = Row["SN"];
                    dr["Seq"] = clsCountGoodsCost.GenSeqNo(dtGoodsPartDetails);
                    dr["ProductID"] = Row["ProductID"].ToString();
                    dr["ProductName"] = Row["ProductName"].ToString();
                    dr["ArtWork"] = Row["ArtWork"].ToString();
                    dr["ArtWorkName"] = Row["ArtWorkName"].ToString();
                    dr["ProductType"] = Row["ProductType"].ToString();
                    dr["ProductTypeName"] = Row["ProductTypeName"].ToString();
                    dr["FrontPart"] = Row["FrontPart"].ToString();
                    dr["ProductSize"] = Row["ProductSize"].ToString();
                    dr["ProductSizeName"] = Row["ProductSizeName"].ToString();
                    dr["ProductColor"] = Row["ProductColor"].ToString();
                    dr["ProductColorName"] = Row["ProductColorName"].ToString();
                    dr["MatWeg"] = clsValidRule.ConvertStrToDecimal(Row["MatWeg"].ToString());
                    dr["MatUse"] = clsValidRule.ConvertStrToDecimal(Row["MatUse"].ToString());
                    dr["MatCost"] = clsValidRule.ConvertStrToDecimal(Row["MatCost"].ToString());
                    dr["ProcessCostTotal"] = clsValidRule.ConvertStrToDecimal(Row["ProcessCostTotal"].ToString());
                    dr["ProcessProfitRate"] = clsValidRule.ConvertStrToDecimal(Row["ProcessProfitRate"].ToString());
                    dr["ProcessProfit"] = clsValidRule.ConvertStrToDecimal(Row["ProcessProfit"].ToString());
                    dr["PlateCost"] = clsValidRule.ConvertStrToDecimal(Row["PlateCost"].ToString());
                    dr["PackCost"] = clsValidRule.ConvertStrToDecimal(Row["PackCost"].ToString());
                    dr["CostPcs"] = clsValidRule.ConvertStrToDecimal(Row["CostPcs"].ToString());
                    dr["CostGrs"] = clsValidRule.ConvertStrToDecimal(Row["CostGrs"].ToString());
                    dr["CostK"] = clsValidRule.ConvertStrToDecimal(Row["CostK"].ToString());
                    dr["FactoryFee"] = clsValidRule.ConvertStrToDecimal(Row["FactoryFee"].ToString());
                    dr["FactoryCostPcs"] = clsValidRule.ConvertStrToDecimal(Row["FactoryCostPcs"].ToString());
                    dr["FactoryCostGrs"] = clsValidRule.ConvertStrToDecimal(Row["FactoryCostGrs"].ToString());
                    dr["FactoryCostK"] = clsValidRule.ConvertStrToDecimal(Row["FactoryCostK"].ToString());
                    dr["Remark"] = Row["Remark"].ToString();
                    frmCountGoodsCost.dtGoodsPartDetails.Rows.Add(dr);
                    selectFlag = true;
                }
            }
            if (!selectFlag)
            {
                MessageBox.Show("沒有待複製的記錄!");
                return;
            }
            frmCountGoodsCost.copyMode = 1;//改為複製模式
            this.Close();
        }


        private void gvGoodsCostHead_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                
            }
        }

        private void frmCountGoodsCostFind_Load(object sender, EventArgs e)
        {
            dgvGoodsCostHead.AutoGenerateColumns = false;
            lueMoGroup.Properties.DataSource = clsBaseData.LoadMoGroup("");
            lueMoGroup.Properties.ValueMember = "group_id";
            lueMoGroup.Properties.DisplayMember = "group_desc";
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
        private void dgvGoodsCostHead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCountGoodsCost.getID = dgvGoodsCostHead.Rows[dgvGoodsCostHead.CurrentRow.Index].Cells["colID"].Value.ToString().Trim();
            this.Close();
        }

        private void dgvGoodsCostHead_SelectionChanged(object sender, EventArgs e)
        {
            int upperSN = Convert.ToInt32(dgvGoodsCostHead.Rows[dgvGoodsCostHead.CurrentRow.Index].Cells["colSN"].Value.ToString().Trim());
            LoadProductCostPrt(upperSN);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            txtProcesslId.Focus();
            FolderBrowserDialog saveFile = new FolderBrowserDialog();
            saveFile.Description = "請選擇文件路徑";
            DialogResult result = saveFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            { return; }
            string folderPath = saveFile.SelectedPath.Trim();

            DataTable dtProfit = clsBaseData.LoadProcessType("CP_PROFIT", "");
            txtCompProfitRate.Text = dtProfit.Rows[0]["product_qty"].ToString();//////公司利潤率

            progressBar_Cnt2 = 0;
            processBarWindows = new frmProcessBarWindows(0, Coun, "正在匯出記錄，請稍候。。。");

            ShowProcessBar();
            
            var flag = dgvGoodsCostHead.Rows[0].Cells["colSelectFlag"].Value.ToString();
            for (int i=0;i< dgvGoodsCostHead.Rows.Count;i++)
            {
                if (dgvGoodsCostHead.Rows[i].Cells["colSelectFlag"].Value.ToString()!="" && (bool)dgvGoodsCostHead.Rows[i].Cells["colSelectFlag"].Value == true)
                {
                    string id = dgvGoodsCostHead.Rows[i].Cells["colID"].Value.ToString();
                    ExpToExcel(id, folderPath);
                    
                }
            }
            HideProcessBar();
        }
        private void LoadData(string ID,string folderPath)
        {
            string fileName = folderPath + "\\" + ID + ".xls";// saveFile.FileName;
            DataTable dtProductCost = clsCountGoodsCost.LoadProductCostHead(ID);
            int SN = dtProductCost.Rows[0]["SN"].ToString() != "" ? Convert.ToInt32(dtProductCost.Rows[0]["SN"].ToString()) : -999;
            DataTable dtGoodsPartDetails = clsCountGoodsCost.LoadProductCostPart(SN, "");
        }

        /// <summary>
        /// ///匯出報價單到Excel
        /// </summary>
        private void ExpToExcel(string ID, string folderPath)
        {
            string fileName = folderPath + "\\" + ID + ".xls";// saveFile.FileName;
            DataTable dtProductCost = clsCountGoodsCost.LoadProductCostHead(ID);
            int SN = dtProductCost.Rows[0]["SN"].ToString() != "" ? Convert.ToInt32(dtProductCost.Rows[0]["SN"].ToString()) : -999;
            DataTable dtGoodsPartDetails = clsCountGoodsCost.LoadProductCostPart(SN, "");
            DataRow drProductCost = dtProductCost.Rows[0];


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
            rowIndex++;
            wSheet.Cells[rowIndex, 1] = "文件編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, 2]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 3] = drProductCost["ID"].ToString();
            wSheet.Cells[rowIndex, 4] = "產品編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = drProductCost["ProductID"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 8] = "產品描述";
            wSheet.Cells[rowIndex, 9] = drProductCost["ProductName"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 9], wSheet.Cells[rowIndex, 12]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 13] = "產品尺寸";
            wSheet.Cells[rowIndex, 14] = drProductCost["ProductSize"].ToString().Trim() + " " + drProductCost["ProductSizeName"].ToString().Trim();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 14], wSheet.Cells[rowIndex, 15]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 16] = "版本";
            wSheet.Cells[rowIndex, 17] = drProductCost["Ver"].ToString().Trim();
            DataTable dtGoods = clsCountGoodsCost.GetProductDataPart(drProductCost["ProductID"].ToString().Trim());
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
            wSheet.Cells[rowIndex, 3] = drProductCost["ArtWork"].ToString();
            wSheet.Cells[rowIndex, 4] = "圖樣描述";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = drProductCost["ArtWorkName"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 8] = "產品類型";
            wSheet.Cells[rowIndex, 9] = drProductCost["ProductType"].ToString().Trim() + " " + drProductCost["ProductTypeName"].ToString().Trim();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 9], wSheet.Cells[rowIndex, 12]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 13] = "產品顏色";
            wSheet.Cells[rowIndex, 14] = drProductCost["ProductColor"].ToString().Trim() + " " + drProductCost["ProductColorName"].ToString().Trim() + " ( " + drProductCost["DoColor"].ToString().Trim() + " )";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 14], wSheet.Cells[rowIndex, 15]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 16] = "組別";
            wSheet.Cells[rowIndex, 17] = drProductCost["MoGroup"].ToString();
            rowIndex++;
            wSheet.Cells[rowIndex, 1] = "制單編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, 2]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 3] = drProductCost["PrdMo"].ToString();
            wSheet.Cells[rowIndex, 4] = "新模編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = drProductCost["MdNo"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 8] = "客戶顏色編號";
            wSheet.Cells[rowIndex, 9] = drProductCost["CustColor"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 9], wSheet.Cells[rowIndex, 12]];
            excelRange.MergeCells = true;//合併單元格
            wSheet.Cells[rowIndex, 13] = "備註";
            wSheet.Cells[rowIndex, 14] = drProductCost["Remark"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 14], wSheet.Cells[rowIndex, 18]];
            excelRange.MergeCells = true;//合併單元格
            rowIndex++;
            wSheet.Cells[rowIndex, 1] = "客戶編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 1], wSheet.Cells[rowIndex, 2]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 3] = drProductCost["CustCode"].ToString();
            wSheet.Cells[rowIndex, 4] = "牌子編號";
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 4], wSheet.Cells[rowIndex, 5]];
            excelRange.MergeCells = true;//合併單元格
            excelRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //水平居中
            wSheet.Cells[rowIndex, 6] = drProductCost["Brand"].ToString();
            excelRange = wSheet.Range[wSheet.Cells[rowIndex, 6], wSheet.Cells[rowIndex, 7]];
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
            for (int i = 0; i < dtGoodsPartDetails.Rows.Count; i++)
            {
                DataRow dr = dtGoodsPartDetails.Rows[i];
                if (dr["Seq"].ToString().Trim() != "ZZ")//最後一行為合計，不用複製
                {
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

                    multRate = clsValidRule.ConvertStrToDecimal(dr["MultRate"].ToString());
                    factoryAmtPcs += clsValidRule.ConvertStrToDecimal(dr["FactoryCostPcs"].ToString()) * multRate;
                    factoryAmtGrs += clsValidRule.ConvertStrToDecimal(dr["FactoryCostGrs"].ToString()) * multRate;
                    factoryAmtK += clsValidRule.ConvertStrToDecimal(dr["FactoryCostK"].ToString()) * multRate;
                    rowIndex++;
                }
            }
            wSheet.Cells[rowIndex, 3] = "產品合計成本(累加:配件成本 * 用量倍數)"; 
            wSheet.Cells[rowIndex, 5] = factoryAmtPcs;
            wSheet.Cells[rowIndex, 6] = factoryAmtGrs;
            wSheet.Cells[rowIndex, 7] = factoryAmtK;
            rowIndex++;
            wSheet.Cells[rowIndex, 3] = "工廠附加損耗率(%)";
            wSheet.Cells[rowIndex, 5] = drProductCost["FactAddWasteRate"].ToString();
            float FactAddWasteRate = clsValidRule.ConvertStrToSingle(drProductCost["FactAddWasteRate"].ToString()) / 100;
            rowIndex++;
            wSheet.Cells[rowIndex, 3] = "工廠總成本 PCS/GRS/K";
            string FactoryPricePcs = Math.Round(clsValidRule.ConvertStrToSingle(factoryAmtPcs.ToString()) * (1 + FactAddWasteRate), 4).ToString();
            string FactoryPriceGrs = Math.Round(clsValidRule.ConvertStrToSingle(factoryAmtGrs.ToString()) * (1 + FactAddWasteRate), 4).ToString();
            string FactoryPriceK = Math.Round(clsValidRule.ConvertStrToSingle(factoryAmtK.ToString()) * (1 + FactAddWasteRate), 2).ToString();
            wSheet.Cells[rowIndex, 5] = FactoryPricePcs;// txtFactoryPricePcs.Text;
            wSheet.Cells[rowIndex, 6] = FactoryPriceGrs;//txtFactoryPriceGrs.Text;
            wSheet.Cells[rowIndex, 7] = FactoryPriceK;//txtFactoryPriceK.Text;
            rowIndex++;
            float SaleRate = clsValidRule.ConvertStrToSingle(txtCompProfitRate.Text) / 100;
            wSheet.Cells[rowIndex, 3] = "含利潤價錢 PCS/GRS/K";
            wSheet.Cells[rowIndex, 5] = Math.Round(clsValidRule.ConvertStrToSingle(FactoryPricePcs) * (1 + SaleRate),4).ToString();//txtSalePricePcs.Text;
            wSheet.Cells[rowIndex, 6] = Math.Round(clsValidRule.ConvertStrToSingle(FactoryPriceGrs) * (1 + SaleRate),2).ToString();//txtSalePriceGrs.Text;
            wSheet.Cells[rowIndex, 7] = Math.Round(clsValidRule.ConvertStrToSingle(FactoryPriceK) * (1 + SaleRate),2).ToString();//txtSalePriceK.Text;

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

    }
}
