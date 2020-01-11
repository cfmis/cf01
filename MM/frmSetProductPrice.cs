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
    public partial class frmSetProductPrice : Form
    {
        public static string getProductId = "";
        public frmSetProductPrice()
        {
            InitializeComponent();
        }
        private void frmSetProductPrice_Load(object sender, EventArgs e)
        {
            dgvProductPrice.AutoGenerateColumns = false;
            rdgIsSetCosting.SelectedIndex = 2;
            cmbPriceUnit.SelectedIndex = 0;
            txtMatFrom.Focus();
            txtProductId.Text = getProductId;
            if (txtProductId.Text != "")
            {
                findData();
            }
            //txtDateFrom.Text = System.DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
            //txtDateTo.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (txtMatFrom.Text.Trim() == ""
                    && txtPrdTypeFrom.Text.Trim() == ""
                    && txtArtFrom.Text.Trim() == ""
                    && txtSizeFrom.Text.Trim() == ""
                    && txtClrFrom.Text.Trim() == ""
                    && txtProductId.Text.Trim() == ""
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
            DataTable dtProductPrice = clsProductCosting.findProductPrice(isSetFlag, chkShowF0.Checked
                , txtMatFrom.Text.Trim(), txtMatTo.Text.Trim(), txtPrdTypeFrom.Text.Trim(), txtPrdTypeTo.Text.Trim()
                , txtArtFrom.Text.Trim(), txtArtTo.Text.Trim(), txtSizeFrom.Text.Trim(), txtSizeTo.Text.Trim()
                , txtClrFrom.Text.Trim(), txtClrTo.Text.Trim(), txtProductId.Text.Trim()
                );
            dgvProductPrice.DataSource = dtProductPrice;
            if (dgvProductPrice.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄");
        }
        
        private void txtMatFrom_Leave(object sender, EventArgs e)
        {
            txtMatTo.Text = txtMatFrom.Text;
        }

        private void txtPrdTypeFrom_Leave(object sender, EventArgs e)
        {
            txtPrdTypeTo.Text = txtPrdTypeFrom.Text;
        }

        private void txtSizeFrom_Leave(object sender, EventArgs e)
        {
            txtSizeTo.Text = txtSizeFrom.Text;
        }

        private void txtClrFrom_Leave(object sender, EventArgs e)
        {
            txtClrTo.Text = txtClrFrom.Text;
        }

        private void txtArtFrom_Leave(object sender, EventArgs e)
        {
            txtArtTo.Text = txtArtFrom.Text;
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
            for (int i = 0; i < dgvProductPrice.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductPrice.Rows[i];
                dgr.Cells["colSetPrice"].Value = chkFlag;
            }
        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            txtClrTo.Focus();
            if (!validData())
                return;
            saveData();
        }
        private bool validData()
        {
            //if(cmbPriceUnit.Text.Trim()=="")
            //{
            //    MessageBox.Show("單價單位不能為空!");
            //    return false;
            //}
            bool selectFlag = false;
            for (int i = 0; i < dgvProductPrice.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductPrice.Rows[i];
                if ((bool)dgr.Cells["colSetPrice"].Value == true)
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
            List<mdlProductPrice> lsModel = new List<mdlProductPrice>();
            for (int i = 0; i < dgvProductPrice.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgvProductPrice.Rows[i];
                if ((bool)dgr.Cells["colSetPrice"].Value == true)
                {
                    mdlProductPrice objModel = new mdlProductPrice();
                    objModel.productId = dgr.Cells["colProductId"].Value.ToString();
                    objModel.productPrice = txtProductPrice.Text != "" ? Convert.ToDecimal(txtProductPrice.Text) : 0;
                    objModel.productPriceQty = txtProductPriceQty.Text != "" ? Convert.ToDecimal(txtProductPriceQty.Text) : 0;
                    objModel.priceUnit = cmbPriceUnit.Text.Trim();
                    objModel.createUser = DBUtility._user_id;
                    objModel.createTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    objModel.amendUser = DBUtility._user_id;
                    objModel.amendTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    lsModel.Add(objModel);
                }
            }
            result = clsProductCosting.updateProductPrice(lsModel);
            if (result == "")
                MessageBox.Show("儲存物料單價成功!");
            else
                MessageBox.Show("儲存物料單價失敗!");
        }

        private void btnOldRec_Click(object sender, EventArgs e)
        {
            string productId = "";
            if (dgvProductPrice.Rows.Count > 0)
                productId= dgvProductPrice.Rows[dgvProductPrice.CurrentRow.Index].Cells["colProductId"].Value.ToString();
            frmProductCostingFindPrice.getProductId = productId;
            frmProductCostingFindPrice frm = new frmProductCostingFindPrice();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
