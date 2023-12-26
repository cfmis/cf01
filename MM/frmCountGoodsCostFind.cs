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
            QueryProductCost(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void QueryProductCost()
        {
            DataTable dtPrd = clsCountGoodsCost.QueryProductCost(txtProcesslId.Text.Trim(), txtProcessName.Text.Trim(), txtID.Text);
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
            frmCountGoodsCost.getID = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colID"].Value.ToString().Trim();
            this.Close();
        }
    }
}
