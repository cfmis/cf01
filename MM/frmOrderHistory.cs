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

        Int32 Coun = 100;
        Int32 progressBar_Cnt2 = 0;
        Int32 progressBar_all2 = 0;
        progressBar_windows form2;// 显示进度条窗体

        public frmOrderHistory()
        {
            InitializeComponent();
        }

        private void btnReSearch_Click(object sender, EventArgs e)
        {

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
            int i = xtc1.SelectedTabPageIndex;
            if (i == 0)

                dtOc = LoadOcData(); //数据处理
            else
                dtWip = LoadWipData();

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            int rows = 0;
            if (i == 0)
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
            //recNumber = cmbBefRec.SelectedValue.ToString() == "99" ? "" : cmbBefRec.Text.Trim();
            DataTable dtOc = clsOrderHistory.LoadOcData(txtMoID.Text.Trim(), txtDateFrom.Text, txtDateTo.Text
                , moGroup, txtSales.Text, txtGoodsID.Text, txtGoodsName.Text, txtPo.Text, txtMat.Text, txtPrdType.Text
                , txtArt.Text, txtSize.Text, txtClr.Text, txtCustItem.Text, txtCustColor.Text, txtCust.Text
                , txtBrand.Text, txtSeason.Text
                , recNumber);
            //LoadOcDataDetails("ZZZZZZZZZ");//填充各種控件
            return dtOc;
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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            progressBar_Cnt2 = 0;
            progressBar_all2 = 0;
            progressBar_all2 = Coun;
            if (progressBar_all2 > 0)
            {

                form2 = new progressBar_windows(0, progressBar_all2);
                form2.Show(this);//设置父窗体

                LoadOcData();
                //progressBar2_updata();
                for (int i = 0; i < Coun; i++)
                {

                    progressBar2_updata();

                }


            }

        }

        public void progressBar2_updata()
        {
            if (progressBar_all2 > 0)
            {
                progressBar_Cnt2++;
                form2.setPos(progressBar_Cnt2);//设置进度条位置
                if (progressBar_Cnt2 >= progressBar_all2)
                {
                    form2.Close();
                }
            }
        }

    }
}
