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
    public partial class frmOrderHistory : Form
    {
        private DataTable dtOc = new DataTable();
        private DataTable dtWip = new DataTable();

        //private Int32 Coun = 100;
        //private Int32 progressBar_Cnt2 = 0;
        //private Int32 progressBar_all2 = 0;
        //private frmProcessBarWindows processBarWindows;//= new progressBar_windows(0,100);// 显示进度条窗体
        //Form form2;
        //创建BackgroundWorker的对象
        //BackgroundWorker bw = new BackgroundWorker();
        public frmOrderHistory()
        {
            InitializeComponent();
            //InitializeBackgroundWorker();
        }
        //private void InitializeBackgroundWorker()
        //{
        //    bw = new BackgroundWorker();
        //    bw.WorkerReportsProgress = true;
        //    bw.WorkerSupportsCancellation = true;
        //    bw.DoWork += bw_DoWork;
        //    //bw.ProgressChanged += BgWorker_ProgressChanged;
        //    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        //}


        private void btnFind_Click(object sender, EventArgs e)
        {
            int progressBar_Cnt2 = 0;
            int Coun = 100;
            int slp = xtc1.SelectedTabPageIndex;
            frmProcessBarWindows processBarWindows = new frmProcessBarWindows(0, Coun, "正在查詢數據，請稍候。。。");
            //processBarWindows.Text = "正在查詢數據，請稍候。。。";
            processBarWindows.Show(this);//设置父窗体
            int pausCnt = 20;
            for (int i = 0; i <= pausCnt; i++)
            {
                progressBar_Cnt2++;
                processBarWindows.setPos(progressBar_Cnt2);//设置进度条位置
                Thread.Sleep(100);
            }

            
            if (slp == 0)

                dtOc = LoadOcData(); //数据处理
            else
                dtWip = LoadWipData();

            for (int i = pausCnt; i < Coun; i++)
            {
                progressBar_Cnt2++;
                processBarWindows.setPos(progressBar_Cnt2);//设置进度条位置
                if (progressBar_Cnt2 >= Coun)
                {
                    processBarWindows.Close();
                }
                Thread.Sleep(10);
            }
            int rows = 0;
            if (slp == 0)
            {
                dgvOc.DataSource = dtOc;
                rows = dgvOc.RowCount;
            }
            else
            {
                dgvWip.DataSource = dtWip;
                rows = dgvWip.RowCount;
            }
            if (rows == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");

        }
        private DataTable LoadOcData()
        {
            string moGroup = lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString() : "";
            string recNumber = "";
            recNumber = this.cmbBefRec.SelectedValue.ToString() == "99" ? "" : cmbBefRec.Text.Trim();
            DataTable dtOc1 = clsOrderHistory.LoadOcData(txtMoID.Text.Trim(), txtDateFrom.Text, txtDateTo.Text
                , moGroup, txtSales.Text, txtGoodsID.Text, txtGoodsName.Text, txtPo.Text, txtMat.Text, txtPrdType.Text
                , txtArt.Text, txtSize.Text, txtClr.Text, txtCustItem.Text, txtCustColor.Text, txtCust.Text
                , txtBrand.Text, txtSeason.Text
                , recNumber);
            LoadOcDataDetails("ZZZZZZZZZ");//填充各種控件
            return dtOc1;
        }
        private void LoadOcDataDetails(string mo_id)
        {
            DataTable dtOcDetails = clsOrderHistory.LoadOcDataDetails(mo_id);
            dgvOcDetails.DataSource = dtOcDetails;
        }
        private DataTable LoadWipData()
        {
            string moGroup = lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString() : "";
            string recNumber = "";
            recNumber = cmbBefRec.SelectedValue.ToString() == "99" ? "" : cmbBefRec.Text.Trim();
            DataTable dtWip = clsOrderHistory.LoadWipData(txtMoID.Text.Trim(), txtDateFrom.Text, txtDateTo.Text
                , moGroup, txtSales.Text, txtGoodsID.Text, txtGoodsName.Text, txtPo.Text, txtMat.Text, txtPrdType.Text
                , txtArt.Text, txtSize.Text, txtClr.Text, txtCustItem.Text, txtCustColor.Text, txtCust.Text
                , txtBrand.Text, txtSeason.Text
                , recNumber);
            LoadWipDataDetails("ZZZZZZZZZ");
            LoadWipMatData("ZZZZZZZZZ", "ZZZZ");
            return dtWip;
        }
        private void LoadWipDataDetails(string mo_id)
        {

            DataTable dtWip = clsOrderHistory.LoadWipData(mo_id, "", ""
                , "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
                , "");
            dgvWipDetails.DataSource = dtWip;
        }
        private void frmOrderHistory_Load(object sender, EventArgs e)
        {
            dgvOc.AutoGenerateColumns = false;
            dgvOcDetails.AutoGenerateColumns = false;
            dgvWip.AutoGenerateColumns = false;
            dgvWipDetails.AutoGenerateColumns = false;
            dgvMatData.AutoGenerateColumns = false;
            lueMoGroup.Properties.DataSource = clsBaseData.LoadMoGroup("");
            lueMoGroup.Properties.ValueMember = "group_id";
            lueMoGroup.Properties.DisplayMember = "group_desc";

            cmbBefRec.DataSource = clsProductCosting.getRecNumber();
            cmbBefRec.DisplayMember = "flag_desc";
            cmbBefRec.ValueMember = "flag_id";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvOc.CurrentRow.Index;
            DataGridViewRow Row = dgvOc.Rows[i];
            string mo_id = Row.Cells["colMoID"].Value.ToString();
            LoadOcDataDetails(mo_id);//填充各種控件
        }
        

        private void dgvWip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvWip.CurrentRow.Index;
            DataGridViewRow Row = dgvWip.Rows[i];
            string mo_id = Row.Cells["colWipMoID"].Value.ToString();
            LoadWipDataDetails(mo_id);//填充各種控件
            LoadWipMatData("ZZZZZZZZZ", "ZZZZ");
        }

        private void btnShowCont_Click(object sender, EventArgs e)
        {
            if (btnShowCont.Text == "折疊<<")
            {
                btnShowCont.Text = "顯示>>";
                panelControl4.Visible = false;
            }
            else
            {
                btnShowCont.Text = "折疊<<";
                panelControl4.Visible = true;
            }
        }

        private void dgvWipDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvWipDetails.CurrentRow.Index;
            DataGridViewRow Row = dgvWipDetails.Rows[i];
            string mo_id = Row.Cells["colWipMoIdDetails"].Value.ToString();
            string seq = Row.Cells["colWipSeqDetails"].Value.ToString();
            LoadWipMatData(mo_id, seq);//填充各種控件
        }
        private void LoadWipMatData(string mo_id, string seq)
        {
            DataTable dtWipMat = clsOrderHistory.LoadWipMatData(mo_id, seq);
            dgvMatData.DataSource = dtWipMat;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //////form2 = new progressBar_windows(0, progressBar_all2);
            //////form2.Show(this);//设置父窗体

            //////LoadOcData1();
            //////form2.Close();



            ////BackgroundWorker bw = new BackgroundWorker();
            ////bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            ////bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            ////progressBar_windows progressForm = new progressBar_windows(0, 100);
            ////form2 = new progressBar_windows(0, 100);

            //form2.ControlBox = false;
            //form2.TopMost = true;

            //form2.Show();
            //bw.RunWorkerAsync();

        }

        //public void progressBar2_updata()
        //{
        //    if (progressBar_all2 > 0)
        //    {
        //        progressBar_Cnt2++;
        //        processBarWindows.setPos(progressBar_Cnt2);//设置进度条位置
        //        if (progressBar_Cnt2 >= progressBar_all2)
        //        {
        //            //Thread.Sleep(1000);
        //            processBarWindows.Close();

        //        }
        //    }
        //}

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //KeyValuePair < GridControl, string> params = e.Argument as KeyValuePair<GridControl, string>;
            //ConnectionClass cc = new Connection Class();
            //cc.fillGrid(params.Value, params.Key);
            e.Result=LoadOcData1();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvOc.DataSource = e.Result;
            try
            {
                //processBarWindows.Close(); //
            }
            catch (Exception ex)
            {
                var er = ex.Message;
            }
        }
        //private void LoadOcData1()
        //{
        //    dtOc = LoadOcData1(); //数据处理
        //    dgvOc.DataSource = dtOc;
        //}

        private DataTable LoadOcData1()
        {
            string moGroup = lueMoGroup.EditValue != null ? lueMoGroup.EditValue.ToString() : "";
            string recNumber = "";
            var dt = txtDateFrom.Text;
            recNumber = cmbBefRec.SelectedValue.ToString() == "99" ? "" : cmbBefRec.Text.Trim();
            DataTable dtOc = clsOrderHistory.LoadOcData(txtMoID.Text.Trim(), txtDateFrom.Text, txtDateTo.Text
                , moGroup, txtSales.Text, txtGoodsID.Text, txtGoodsName.Text, txtPo.Text, txtMat.Text, txtPrdType.Text
                , txtArt.Text, txtSize.Text, txtClr.Text, txtCustItem.Text, txtCustColor.Text, txtCust.Text
                , txtBrand.Text, txtSeason.Text
                , recNumber);
            dgvOc.DataSource = dtOc;
            //LoadOcDataDetails("ZZZZZZZZZ");//填充各種控件
            return dtOc;
        }

        private void btnAddCost_Click(object sender, EventArgs e)
        {
            bool selectFlag = false;
            for (int i = 0; i < dgvOcDetails.Rows.Count; i++)
            {
                DataGridViewRow Row = dgvOcDetails.Rows[i];
                if (Row.Cells["colSelectFlagOc"].Value == null ? false : Convert.ToBoolean(Row.Cells["colSelectFlagOc"].Value.ToString()) == true)
                {
                    DataRow dr = frmCountGoodsCost.dtGoodsPartDetails.NewRow();
                    dr["Seq"] = clsCountGoodsCost.GenSeqNo(frmCountGoodsCost.dtGoodsPartDetails);
                    string goods_id= Row.Cells["colGoodsIdOc"].Value.ToString();
                    dr["ProductID"] = goods_id;
                    dr["ProductName"] = Row.Cells["colGoodsNameOc"].Value.ToString();
                    DataTable dtGoods = clsCountGoodsCost.GetProductDataPart(goods_id);
                    if (dtGoods.Rows.Count > 0)
                    {
                        DataRow drGoods = dtGoods.Rows[0];
                        dr["ArtWork"] = drGoods["blueprint_id"].ToString();
                        dr["ArtWorkName"] = drGoods["art_cdesc"].ToString();
                        dr["ProductType"] = drGoods["base_class"].ToString();
                        dr["ProductTypeName"] = drGoods["prd_cdesc"].ToString();
                        //dr["FrontPart"] = drGoods["FrontPart"].ToString();
                        dr["ProductSize"] = drGoods["size_id"].ToString();
                        dr["ProductSizeName"] = drGoods["size_cdesc"].ToString();
                        dr["ProductColor"] = drGoods["color"].ToString();
                        dr["ProductColorName"] = drGoods["clr_cdesc"].ToString();
                    }
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
    }
}
