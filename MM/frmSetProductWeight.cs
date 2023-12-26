using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraReports.UI;
using cf01.MDL;

namespace cf01.MM
{
    public partial class frmSetProductWeight : Form
    {
        public static string getProductId = "";
        public frmSetProductWeight()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSetProductWeight_Load(object sender, EventArgs e)
        {
            dgvProductWeight.AutoGenerateColumns = false;
            rdgIsSetCosting.SelectedIndex = 2;
            txtProductId.Text = getProductId;
            if (txtProductId.Text != "")
            {
                findData(); 
            }
            //txtDateFrom.Text = System.DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
            //txtDateTo.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }
        private void findData()
        {
            txtProductId.Focus();
            chkSelectAll.Checked = false;
            if (rdgIsSetCosting.SelectedIndex != 0)
            {
                if (txtProductId.Text.Trim() == ""
                    )
                {
                    MessageBox.Show("請輸入查詢條件!");
                    return;
                }
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            findProcess(); //数据处理

            //genBomTree(pid);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void findProcess()
        {
            int isSetFlag = rdgIsSetCosting.SelectedIndex;
            DataTable dtProductWeight= clsProductCosting.findProductWeight(isSetFlag, chkShowF0.Checked
                , txtProductId.Text.Trim(),chkNoShowDmItem.Checked
                );
            dgvProductWeight.DataSource = dtProductWeight;
            if (dgvProductWeight.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄");
        }

        private void printData(DataTable dt)
        {
            xrProductCostingFind oRepot = new xrProductCostingFind() { DataSource = dt};
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }


        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            txtProductId.Focus();
            bool chkFlag = chkSelectAll.Checked;
            for (int i = 0; i < dgvProductWeight.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductWeight.Rows[i];
                dgr.Cells["colSelectFlag"].Value = chkFlag;
            }
        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            if (!validData())
                return;
            saveData();
        }
        private bool validData()
        {
            bool selectFlag = false;
            for (int i = 0; i < dgvProductWeight.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductWeight.Rows[i];
                if ((bool)dgr.Cells["colSelectFlag"].Value == true)
                {
                    selectFlag = true;
                    break;
                }
            }
            if (selectFlag == false)
                MessageBox.Show("沒有選定需儲存的記錄!");
            return selectFlag;
        }
        private void saveData()
        {
            string result = "";
            List<mdlProductWeight> lsModel = new List<mdlProductWeight>();
            for (int i = 0; i < dgvProductWeight.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductWeight.Rows[i];
                if ((bool)dgr.Cells["colSelectFlag"].Value == true)
                {
                    mdlProductWeight objModel = new mdlProductWeight();
                    objModel.prdItem = dgr.Cells["colProductId"].Value.ToString().Trim();
                    objModel.matItem = dgr.Cells["colMaterialId"].Value != null ? dgr.Cells["colMaterialId"].Value.ToString().Trim() : "*";
                    if (objModel.matItem == "")
                        objModel.matItem = "*";
                    objModel.depId = dgr.Cells["colDepId"].Value != null ? dgr.Cells["colDepId"].Value.ToString().Trim() : "*";
                    if (objModel.depId == "")
                        objModel.depId = "*";
                    objModel.pcsWeg = Convert.ToDecimal(txtProductWeight.Text);
                    objModel.prdKgQtyRate = Math.Round(1 / (objModel.pcsWeg / 1000), 0);
                    objModel.crUser = DBUtility._user_id;
                    objModel.crTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    lsModel.Add(objModel);
                }
            }
            result = clsProductCosting.updateProductWeight(lsModel);
            if (result == "")
                MessageBox.Show("儲存物料重量成功!");
            else
                MessageBox.Show("儲存物料重量失敗!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!validData())
                return;
            deleteData();
        }
        private void deleteData()
        {
            string result = "";
            List<mdlProductWeight> lsModel = new List<mdlProductWeight>();
            for (int i = 0; i < dgvProductWeight.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductWeight.Rows[i];
                if ((bool)dgr.Cells["colSelectFlag"].Value == true)
                {
                    mdlProductWeight objModel = new mdlProductWeight();
                    objModel.prdItem = dgr.Cells["colProductId"].Value.ToString().Trim();
                    objModel.matItem = dgr.Cells["colMaterialId"].Value != null ? dgr.Cells["colMaterialId"].Value.ToString().Trim() : "*";
                    objModel.depId = dgr.Cells["colDepId"].Value != null ? dgr.Cells["colDepId"].Value.ToString().Trim() : "*";
                    lsModel.Add(objModel);
                }
            }
            result = clsProductCosting.deleteProductWeight(lsModel);
            if (result == "")
                MessageBox.Show("刪除物料重量成功!");
            else
                MessageBox.Show("刪除物料重量失敗!");
        }
    }
}
