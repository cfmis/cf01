using cf01.CLS;
using cf01.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    
    public partial class frmDeliveryPrepareList : Form
    {
        DataTable dtList = new DataTable();
        public string return_id = string.Empty;
        public frmDeliveryPrepareList()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            st_delivery_find lst = new st_delivery_find();
            lst.id1 = txtId1.Text;
            lst.id2 = txtId2.Text;
            lst.group_no = txtGroup_no.Text;
            lst.transfer_date1 = txtDat1.Text;
            lst.transfer_date2 = txtDat2.Text;
            lst.create_by1 = txtCreate_by1.Text;
            lst.create_by2 = txtCreate_by2.Text;
            lst.mo_id1 = txtMo_id1.Text;
            lst.mo_id2 = txtMo_id2.Text;
            dtList = clsDeliveryPrepare.GetIdList(lst);
            dgv1.DataSource = dtList;
            if (dtList.Rows.Count == 0)
            {
                return_id = "";
                MessageBox.Show("沒有滿足查找條件的數據!");
            }
            DataGridViewRow row = dgv1.Rows[0];
            return_id = row.Cells["id"].Value.ToString();
        }

        private void frmDeliveryPrepareList_Load(object sender, EventArgs e)
        {
            txtCreate_by1.Text = DBUtility._user_id;
            txtCreate_by2.Text = DBUtility._user_id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            return_id = "";
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(return_id =="")
            {
                MessageBox.Show("請選擇中一條當前行!");
                return;
            }
            this.Close();
        } 

        private void dgv1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return_id = "";
                return;
            }
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            return_id = row.Cells["id"].Value.ToString(); 
        }

        private void txtCreate_by1_Leave(object sender, EventArgs e)
        {
            txtCreate_by2.Text = txtCreate_by1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }
    }
}
