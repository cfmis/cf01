﻿using System;
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtGroupID.Text = "";
            txtSizeID.Text = "";
            txtSizeName.Text = "";
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
            mdlSG.GroupID = txtGroupID.Text;
            mdlSG.SizeID = txtSizeID.Text;
            result = clsMmProductTypeStdPrice.SaveSizeGroup(mdlSG);
            if (result != "")
            {
                txtGroupID.Text = result;
                LoadSizeGroup();
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
            DataTable dtSizeGroup = clsMmProductTypeStdPrice.LoadSizeGroup(txtGroupID.Text);
            dgvSizeGroup.DataSource = dtSizeGroup;
        }
        private void txtSizeID_Leave(object sender, EventArgs e)
        {
            DataTable dtSize = clsMmProductTypeStdPrice.GetSize(txtSizeID.Text);
            if (dtSize.Rows.Count > 0)
                txtSizeName.Text = dtSize.Rows[0]["SizeName"].ToString().Trim();
            else
                txtSizeName.Text = "";
        }

        private void txtGroupID_Leave(object sender, EventArgs e)
        {
            LoadSizeGroup();
        }

        private void dgvSizeGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSizeGroup.Rows.Count > 0)
            {
                DataGridViewRow dr = dgvSizeGroup.Rows[dgvSizeGroup.CurrentRow.Index];
                txtGroupID.Text = dr.Cells["colGroupID"].Value.ToString();
                txtSizeID.Text = dr.Cells["colSizeID"].Value.ToString();
                txtSizeName.Text = dr.Cells["colSizeName"].Value.ToString();
            }
            else
            {
                txtGroupID.Text = "";
                txtSizeID.Text = "";
                txtSizeName.Text = "";
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
    }
}