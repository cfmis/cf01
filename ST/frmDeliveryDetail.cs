using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;

namespace cf01.ST
{
    public partial class frmDeliveryDetail : Form
    {
        public frmDeliveryDetail()
        {
            InitializeComponent();
        }

        private void frmDeliveryDetail_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            //int fixedCount = 6; // 要固定的列数
            //for (int i = 0; i < fixedCount; i++)
            //{
            //    dgvDetails.Columns[i].Frozen = true;
            //}
            txtTransferDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            DataTable dtMoGroup = clsBaseData.LoadMoGroupAll("");
            cmbMoGroup.DataSource = dtMoGroup;
            cmbMoGroup.DisplayMember = "group_id";
            cmbMoGroup.ValueMember = "group_id";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                SaveMostly();

        }
        private void SaveMostly()
        {
            if (!ValidMostlyData())
                return;
            mdlDeliveryHead objMostly = new mdlDeliveryHead();
            objMostly.ID = txtDocId.Text;
            objMostly.transfer_date = txtTransferDate.Text;
            objMostly.id_type = cmbIdType.Text.Trim();
            objMostly.mo_group = cmbMoGroup.Text.Trim();
            objMostly.state = "0";
            string ID = clsDeliveryDetail.SaveMostly(objMostly);
            txtDocId.Text = ID;
        }
        private bool ValidMostlyData()
        {
            bool valid_flag = true;
            if (txtTransferDate.Text.Trim() == "/  /")
            {
                MessageBox.Show("轉出單日期不能為空!");
                txtTransferDate.Focus();
                valid_flag = false;
            }
            else if (cmbIdType.Text.Trim() == "")
            {
                MessageBox.Show("單據類型不能為空!");
                cmbIdType.Focus();
                valid_flag = false;
            }
            else if (cmbMoGroup.Text.Trim() == "")
            {
                MessageBox.Show("組別編號不能為空!");
                cmbMoGroup.Focus();
                valid_flag = false;
            }
            return valid_flag;
        }
        private void LoadMostlyData()
        {

        }
    }
}
