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
            QueryProductCost(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void QueryProductCost()
        {
            int showExistWeg = 0;
            if (chkShowExistWeg.Checked == true)
                showExistWeg = 1;
            DataTable dtPrd = clsCountGoodsCost.QueryProductData(txtProcesslId.Text.Trim(), txtProcessName.Text.Trim(),showExistWeg);
            dgvDetails1.DataSource = dtPrd;
            if (dgvDetails1.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetails1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCountGoodsCost.getID = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colProductID"].Value.ToString().Trim();
            this.Close();
        }
    }
}
