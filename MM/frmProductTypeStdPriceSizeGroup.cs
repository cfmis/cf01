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
    public partial class frmProductTypeStdPriceSizeGroup : Form
    {
        public frmProductTypeStdPriceSizeGroup()
        {
            InitializeComponent();
            dgvSizeGroup.AutoGenerateColumns = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private string Save()
        {
            string result = "";
            if (txtSizeID.Text.Trim() == "")
            {
                MessageBox.Show("尺寸代號不能為空!");
                return result;
            }
            mdlSizeGroup mdlSG = new mdlSizeGroup();
            mdlSG.GroupID = txtGroupID.Text.Trim();
            mdlSG.SizeID = txtSizeID.Text.Trim();
            mdlSG.SizeStyle = txtSizeStyle.Text;
            mdlSG.AddCharge1 = txtAddCharge1.Text.Trim() != "" ? Convert.ToDecimal(txtAddCharge1.Text) : 0;
            mdlSG.AddCharge2 = txtAddCharge2.Text.Trim() != "" ? Convert.ToDecimal(txtAddCharge2.Text) : 0;
            mdlSG.AddCharge3 = txtAddCharge3.Text.Trim() != "" ? Convert.ToDecimal(txtAddCharge3.Text) : 0;
            result = clsMmProductTypeStdPrice.SaveSizeGroup(mdlSG);
            if (result != "")
            {
                txtGroupID.Text = result;
                LoadSizeGroup();
                SelectRecord(dgvSizeGroup.Rows.Count - 1);
            }
            else
                MessageBox.Show("儲存尺寸組別失敗");
            //if (result != "")
            //    MessageBox.Show(result);
            //else
            //    LoadSizeDetails();
            return result;
        }
        private void LoadSizeGroup()
        {
            DataTable dtSizeGroup = clsMmProductTypeStdPrice.LoadSizeDetails("", txtSizeIDFind.Text);
            dgvSizeGroup.DataSource = dtSizeGroup;
        }
        private void txtSizeID_Leave(object sender, EventArgs e)
        {
            DataTable dtSize = clsMmProductTypeStdPrice.GetSize(txtSizeID.Text);
            if (dtSize.Rows.Count > 0)
            {
                txtSizeName.Text = dtSize.Rows[0]["SizeName"].ToString().Trim();
                txtAddCharge1.Text = dtSize.Rows[0]["add_charge1"].ToString().Trim();
                txtAddCharge2.Text = dtSize.Rows[0]["add_charge2"].ToString().Trim();
                txtAddCharge3.Text = dtSize.Rows[0]["add_charge3"].ToString().Trim();
            }
            else
            {
                txtSizeName.Text = "";
                txtAddCharge1.Text = "";
                txtAddCharge2.Text = "";
                txtAddCharge3.Text = "";
            }
        }

        private void dgvSizeGroup_SelectionChanged(object sender, EventArgs e)
        {
            SelectRecord(dgvSizeGroup.CurrentRow.Index);
        }
        private void SelectRecord(int row)
        {
            if (dgvSizeGroup.Rows.Count > 0)
            {
                DataGridViewRow dr = dgvSizeGroup.Rows[dgvSizeGroup.CurrentRow.Index];
                txtGroupID.Text = dr.Cells["colGroupID"].Value.ToString();
                txtSizeID.Text = dr.Cells["colSizeID"].Value.ToString();//
                txtSizeName.Text = dr.Cells["colSizeName"].Value.ToString();
                txtSizeStyle.Text = dr.Cells["colSizeStyle"].Value.ToString();
                txtAddCharge1.Text = dr.Cells["colAddCharge1"].Value.ToString();
                txtAddCharge2.Text = dr.Cells["colAddCharge2"].Value.ToString();
                txtAddCharge3.Text = dr.Cells["colAddCharge3"].Value.ToString();
            }
            else
            {
                txtGroupID.Text = "";
                txtSizeID.Text = "";
                txtSizeName.Text = "";
                txtSizeStyle.Text = "";
                txtAddCharge1.Text = "";
                txtAddCharge2.Text = "";
                txtAddCharge3.Text = "";
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadSizeGroup();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string result = "";
            mdlSizeGroup mdlSG = new mdlSizeGroup();
            mdlSG.GroupID = txtGroupID.Text;
            mdlSG.SizeID = txtSizeID.Text;
            result = clsMmProductTypeStdPrice.DeleteSizeGroup(mdlSG);
            if (result == "")
            {
                LoadSizeGroup();
            }
            else
                MessageBox.Show("儲存尺寸組別失敗");
        }

        private void txtGroupIDFind_Leave(object sender, EventArgs e)
        {
            LoadSizeGroup();
        }

        private void dgvSizeGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSizeGroup.Rows.Count > 0)
            {
                frmProductTypeStdPrice.searchSizeGroup = dgvSizeGroup.Rows[dgvSizeGroup.CurrentRow.Index].Cells["colGroupID"].Value.ToString();
                this.Close();
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            txtGroupID.Text = "";
            btnAddSize_Click(sender, e);
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            txtSizeID.Text = "";
            txtSizeName.Text = "";
            txtAddCharge1.Text = "";
            txtAddCharge2.Text = "";
            txtAddCharge3.Text = "";
            txtSizeID.Focus();
        }
    }
}
