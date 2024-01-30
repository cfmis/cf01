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
    public partial class frmCountGoodsCostFindGoods : Form
    {
        public static decimal prdWeg = 0;
        public static decimal useWeg = 0;
        public static decimal wasteWeg = 0;
        public frmCountGoodsCostFindGoods()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtProcesslId.Text == "" && txtProcessName.Text == "")
                return;
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            DataTable dtPrd=QueryProductCost(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            
            if (dtPrd.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private DataTable QueryProductCost()
        {
            DataTable dtPrd = new DataTable();
            if(tabControl1.SelectedIndex==0)
            {
                int showExistWeg = 0;
                if (chkShowExistWeg.Checked == true)
                    showExistWeg = 1;
                dtPrd = clsCountGoodsCost.QueryProductData(txtProcesslId.Text.Trim(), txtProcessName.Text.Trim(), showExistWeg);
                dgvDetails1.DataSource = dtPrd;
            }else
            {
                dtPrd = clsCountGoodsCost.QueryGoodsQtyConvert(txtProcesslId.Text.Trim(), txtProcessName.Text.Trim());
                dgvMatDetails.DataSource = dtPrd;
            }
            
            return dtPrd;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetails1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCountGoodsCost.getID = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colProductID"].Value.ToString().Trim();
            prdWeg = clsValidRule.ConvertStrToDecimal(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colPrdWeg"].Value.ToString());
            wasteWeg = clsValidRule.ConvertStrToDecimal(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colWasteWeg"].Value.ToString());
            useWeg = clsValidRule.ConvertStrToDecimal(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colUseWeg"].Value.ToString());
            this.Close();
        }

        private void dgvMatDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCountGoodsCost.getID = dgvMatDetails.Rows[dgvMatDetails.CurrentRow.Index].Cells["colMatID"].Value.ToString().Trim();
            decimal rate=clsValidRule.ConvertStrToDecimal(dgvMatDetails.Rows[dgvMatDetails.CurrentRow.Index].Cells["colKgQty"].Value.ToString());
            prdWeg = rate > 0 ? Math.Round((1 / rate) * 1000, 2) : 0;
            wasteWeg = 0;
            useWeg = 0;
            this.Close();
        }
    }
}
