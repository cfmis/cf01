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
        public static int copyMode = 0;
        public frmCountGoodsCostFind()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            DataTable dtPrd = QueryProductCost(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            gcGoodsCostHead.DataSource = dtPrd;
            if (gvGoodsCostHead.DataRowCount == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private DataTable QueryProductCost()
        {
            string moGroup = lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString() : "";
            DataTable dtPrd = clsCountGoodsCost.QueryProductCost(txtProcesslId.Text.Trim(), txtProcessName.Text.Trim()
                , txtID.Text,txtCustColor.Text,moGroup);
            
            return dtPrd;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gvGoodsCostHead_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow Row = gvGoodsCostHead.GetFocusedDataRow();
            int upperSN = Convert.ToInt32(Row["SN"]);
            DataTable dtPart = clsCountGoodsCost.LoadProductCostPart(upperSN,"");
            gcGoodsCostDetails.DataSource = dtPart;
        }

        private void repositoryItemButtonEdit6_Click(object sender, EventArgs e)
        {
            DataRow Row = gvGoodsCostHead.GetFocusedDataRow();
            frmCountGoodsCost.getID = Row["ID"].ToString();
            this.Hide();
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
                    dr["Seq"] = GenSeqNo(frmCountGoodsCost.dtGoodsPartDetails);
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
            copyMode = 1;//改為複製模式
            this.Hide();
        }
        private string GenSeqNo(DataTable dtSeq)
        {
            string Seq = "";
            string MaxSeq = "000";
            for (int i = 0; i < dtSeq.Rows.Count; i++)
            {
                Seq = dtSeq.Rows[i]["Seq"].ToString().Trim();
                MaxSeq = string.Compare(MaxSeq, Seq) >= 0 ? MaxSeq : Seq;
            }
            int MaxSeqInt = Convert.ToInt32(MaxSeq);
            Seq = (MaxSeqInt + 1).ToString().PadLeft(3, '0');
            return Seq;
        }

        private void gvGoodsCostHead_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                
            }
        }

        private void gvGoodsCostHead_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvGoodsCostHead.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内 
                if (hInfo.InRow)
                {
                    MessageBox.Show(hInfo.RowHandle.ToString());
                }
            }
        }

        private void frmCountGoodsCostFind_Load(object sender, EventArgs e)
        {
            lueMoGroup.Properties.DataSource = clsBaseData.LoadMoGroup("");
            lueMoGroup.Properties.ValueMember = "group_id";
            lueMoGroup.Properties.DisplayMember = "group_desc";
        }


    }
}
