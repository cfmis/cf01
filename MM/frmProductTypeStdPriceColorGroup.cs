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
    public partial class frmProductTypeStdPriceColorGroup : Form
    {
        public frmProductTypeStdPriceColorGroup()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private string Save()
        {
            

            string result = "";
            if (txtColorID.Text.Trim() == "")
            {
                MessageBox.Show("顏色代號不能為空!");
                return result;
            }
            mdlColorGroup mdlCG = new mdlColorGroup();
            mdlCG.GroupID = txtGroupID.Text;
            mdlCG.ColorID = txtColorID.Text;
            mdlCG.Rate = txtRate.Text != "" ? Convert.ToDecimal(txtRate.Text) : 0;
            result = clsMmProductTypeStdPrice.SaveColorGroup(mdlCG);
            if (result != "")
            {
                txtGroupID.Text = result;
                LoadColorGroup();
                SelectRecord(dgvColorGroup.Rows.Count - 1);
            }
            else
                MessageBox.Show("儲存顏色組別失敗!");
            return result;
        }
        private void LoadColorGroup()
        {
            DataTable dtColorGroup = clsMmProductTypeStdPrice.LoadColorGroup("", txtColorIDFind.Text);
            dgvColorGroup.DataSource = dtColorGroup;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadColorGroup();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string result = "";
            mdlColorGroup mdlCG = new mdlColorGroup();
            mdlCG.GroupID = txtGroupID.Text;
            mdlCG.ColorID = txtColorID.Text;
            result = clsMmProductTypeStdPrice.DeleteColorGroup(mdlCG);
            if (result == "")
            {
                LoadColorGroup();
            }
            else
                MessageBox.Show("刪除顏色組別失敗!");
        }

        private void txtColorID_Leave(object sender, EventArgs e)
        {
            DataTable dtColor = clsMmProductTypeStdPrice.GetColor(txtColorID.Text);
            if (dtColor.Rows.Count > 0)
                txtColorName.Text = dtColor.Rows[0]["ColorName"].ToString().Trim();
            else
                txtColorName.Text = "";
        }

        private void dgvColorGroup_SelectionChanged(object sender, EventArgs e)
        {
            SelectRecord(dgvColorGroup.CurrentRow.Index);
        }
        private void SelectRecord(int row)
        {
            if (dgvColorGroup.Rows.Count > 0)
            {
                DataGridViewRow dr = dgvColorGroup.Rows[row];
                txtGroupID.Text = dr.Cells["colGroupID"].Value.ToString();
                txtColorID.Text = dr.Cells["colColorID"].Value.ToString();
                txtColorName.Text = dr.Cells["colColorName"].Value.ToString();
                txtRate.Text = dr.Cells["colRate"].Value.ToString();
            }
            else
            {
                txtGroupID.Text = "";
                txtColorID.Text = "";
                txtColorName.Text = "";
                txtRate.Text = "";
            }
        }
        private void txtGroupIDFind_Leave(object sender, EventArgs e)
        {
            LoadColorGroup();
        }

        private void dgvColorGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvColorGroup.Rows.Count > 0)
            {
                frmProductTypeStdPrice.searchColorGroup = dgvColorGroup.Rows[dgvColorGroup.CurrentRow.Index].Cells["colGroupID"].Value.ToString();
                this.Close();
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            txtGroupID.Text = "";
            txtRate.Text = "";
            btnAddColor_Click(sender, e);
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            txtColorID.Text = "";
            txtColorName.Text = "";
            txtColorID.Focus();
        }
    }
}
