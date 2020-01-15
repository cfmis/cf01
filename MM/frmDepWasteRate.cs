using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.MDL;
using cf01.CLS;

namespace cf01.MM
{
    public partial class frmDepWasteRate : Form
    {
        public frmDepWasteRate()
        {
            InitializeComponent();
        }

        private void frmDepWasteRate_Load(object sender, EventArgs e)
        {
            initData();
        }
        private void initData()
        {
            lueDepId.Properties.ValueMember = "dep_id"; //相当于Editvalue
            lueDepId.Properties.DisplayMember = "dep_cdesc"; //相当于Text
            lueDepId.Properties.DataSource = clsBaseData.loadDep();
            binddDepWasteRate();
            binddProductTypeWasteRate();
        }
        private void binddDepWasteRate()
        {
            dgvDetails.DataSource = clsDepWasteRate.loadDepWasteRate();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            fillTextBox(dgvDetails.CurrentRow.Index);
        }
        private void fillTextBox(int row)
        {
            DataGridViewRow dgr = dgvDetails.Rows[row];
            lueDepId.EditValue = dgr.Cells["colDepId"].Value.ToString();
            txtWasteRate.Text = dgr.Cells["colWasteRate"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                save();
            else
                saveProductTypeWasteRate();
        }
        private void save()
        {
            string result = "";
            decimal wasteRate=txtWasteRate.Text!=""?Convert.ToDecimal(txtWasteRate.Text):0;
            result = clsDepWasteRate.updateDepWasteRate(lueDepId.EditValue.ToString(), wasteRate);
            if (result == "")
            {
                MessageBox.Show("儲存記錄成功!");
                binddDepWasteRate();
            }
            else
                MessageBox.Show("儲存記錄失敗!");
        }
        private void saveProductTypeWasteRate()
        {
            if(clsDepWasteRate.checkProductType(txtProductType.Text.Trim()).Rows.Count==0)
            {
                MessageBox.Show("產品類型不存在,不能儲存!");
                return;
            }
            string result = "";
            decimal wasteRate = txtRate.Text != "" ? Convert.ToDecimal(txtRate.Text) : 0;
            result = clsDepWasteRate.updateProductTypeWasteRate(txtProductType.Text.Trim(), wasteRate);
            if (result == "")
            {
                MessageBox.Show("儲存記錄成功!");
                binddProductTypeWasteRate();
            }
            else
                MessageBox.Show("儲存記錄失敗!");
        }
        private void binddProductTypeWasteRate()
        {
            dgvDetails1.DataSource = clsDepWasteRate.loadProductTypeWasteRate();
        }

        private void txtProductType_Leave(object sender, EventArgs e)
        {
            DataTable dtProductType = clsDepWasteRate.checkProductType(txtProductType.Text.Trim());
            if (dtProductType.Rows.Count > 0)
                txtProductTypeName.Text = dtProductType.Rows[0]["prd_cdesc"].ToString();
            else
                txtProductTypeName.Text = "";
        }

        private void dgvDetails1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dgvDetails1.Rows[dgvDetails1.CurrentRow.Index];
            txtProductType.Text = dgr.Cells["colProductType"].Value.ToString();
            txtProductTypeName.Text = dgr.Cells["colProductTypeName"].Value.ToString();
            txtRate.Text= dgr.Cells["colRate"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                delete();
            else
                deleteProductTypeWasteRate();
        }
        private void delete()
        {
            string result = "";
            result = clsDepWasteRate.deleteDepWasteRate(lueDepId.EditValue.ToString());
            if (result == "")
            {
                MessageBox.Show("刪除記錄成功!");
                binddDepWasteRate();
            }
            else
                MessageBox.Show("刪除記錄失敗!");
        }
        private void deleteProductTypeWasteRate()
        {
            string result = "";
            result = clsDepWasteRate.deleteProductTypeWasteRate(txtProductType.Text.Trim());
            if (result == "")
            {
                MessageBox.Show("刪除記錄成功!");
                binddProductTypeWasteRate();
            }
            else
                MessageBox.Show("刪除記錄失敗!");
        }
    }
}
