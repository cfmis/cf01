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
            for (int i=0;i<gvGoodsCostDetails.DataRowCount;i++)
            {
                DataRow Row = gvGoodsCostDetails.GetDataRow(i);
                if (Row["SelectFlag"].ToString()==""?false:Convert.ToBoolean(Row["SelectFlag"].ToString())==true)
                {
                    DataRow dr =frmCountGoodsCost.dtGoodsPartDetails.NewRow();
                    dr["SN"] = Row["SN"];
                    dr["Seq"] = clsCountGoodsCost.GenSeqNo(frmCountGoodsCost.dtGoodsPartDetails);
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
    }
}
