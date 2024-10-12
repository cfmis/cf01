using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmDgdDeliverGoods_Find : Form
    {
        public frmDgdDeliverGoods_Find()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }

        private void findData()
        {
            
            string dat1,dat2 ;
            if (dtDate1.Text != "")
                dat1 = Convert.ToDateTime(dtDate1.Text).ToString("yyyy/MM/dd");
            else
                dat1 = "";
            if (dtDate2.Text != "")
                dat2 = Convert.ToDateTime(dtDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            else
                dat2 = "";
            DataTable dtIdDetails = clsDgdDeliverGoods.findIdDetails(txtId1.Text, txtId2.Text, dat1, dat2, txtMo_id1.Text, txtMo_id2.Text,txtOcno.Text,txtPono.Text);
            gcDetails.DataSource = dtIdDetails;
            if (dtIdDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查找條件的數據!", "提示信息");
            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
                return;
            returnValue();
        }
        private void returnValue()
        {
            frmDgdDeliverGoods.query_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "id").ToString();
            frmDgdDeliverGoods.query_seq = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id").ToString();
            Close();
        }

        private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = dgvDetails.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    returnValue();
                }
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id2.Text;
        }    

    

        private void dtDate1_Leave(object sender, EventArgs e)
        {
            dtDate2.EditValue = dtDate1.EditValue;
        }
    }
}
