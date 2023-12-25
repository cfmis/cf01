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
    public partial class frmCountGoodsCostFindProcess : Form
    {
        public static string getDepId = "";
        public static string getProcessId = "";
        public static string getProcessName = "";
        public static double getBaseQty = 0;
        public static string getPriceUnit = "";
        public static string modality = "";
        public frmCountGoodsCostFindProcess()
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
            findProcessPrice(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void frmCountGoodsCostFindProcess_Load(object sender, EventArgs e)
        {
            dgvDetails1.AutoGenerateColumns = false;
            txtDepId.Text = getDepId;
            txtProcesslId.Text = getProcessId;
            txtProcessName.Text = getProcessName;

            if (getProcessId != "")
                btnFind_Click(sender, e);
            else
            {
                if (getDepId != "")
                    btnFind_Click(sender, e);
            }
        }
        private void findProcessPrice()
        {
            string depID = txtDepId.Text;
            //////如果是查找包裝費或工廠皮費類型
            if (modality == "PK_FEE" || modality == "FT_FEE")
                depID = modality;
            DataTable dtProcessBase = clsBaseData.LoadProductProcess(depID, txtProcesslId.Text,txtProcessName.Text);
            dgvDetails1.DataSource = dtProcessBase;
            if (dgvDetails1.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetails1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            float searchPrice = 0;
            getProcessId = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colProcessID"].Value.ToString().Trim();
            getProcessName = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colProcessName"].Value.ToString().Trim();
            searchPrice = clsValidRule.ConvertStrToSingle(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colPriceHKD"].Value.ToString());
            getBaseQty= clsValidRule.ConvertStrToSingle(dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colBaseQty"].Value.ToString());
            getPriceUnit = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index].Cells["colPriceUnit"].Value.ToString().Trim();
            frmCountGoodsCost.searchPrice = searchPrice;
            this.Close();
        }
    }
}
