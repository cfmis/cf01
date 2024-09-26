using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmStTransferToHk_Find : Form
    {
        private clsStTransferToHk clsTransfer = new clsStTransferToHk();
        public frmStTransferToHk_Find()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void returnValue()
        {
            frmStTransferToHk.query_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "id").ToString();
            frmStTransferToHk.query_seq = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id").ToString();
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string dat1 = "", dat2 = "";
            if (mtbDate1.Text.Trim() != "/  /" || mtbDate2.Text.Trim() != "/  /")
            {
                if (clsValidRule.CheckDateIsEmpty(mtbDate1.Text) == false || clsValidRule.CheckDateIsEmpty(mtbDate2.Text) == false)
                {
                    if (clsValidRule.CheckDateFormat(mtbDate1.Text) == false || clsValidRule.CheckDateFormat(mtbDate2.Text) == false)
                    {
                        MessageBox.Show("回港日期格式不正確!");
                        mtbDate1.Focus();
                        return;
                    }
                }
                dat1 = mtbDate1.Text.Trim();
                dat2 = Convert.ToDateTime(mtbDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            }
            string state = "";
            if (rdState.SelectedIndex == 0)
                state = "0";
            else
                if (rdState.SelectedIndex == 1)
                    state = "1";
            DataTable dtId = clsTransfer.findTranDoc(txtId1.Text.Trim(), txtId2.Text.Trim(), dat1, dat2, txtMo_id1.Text.Trim(), txtMo_id2.Text.Trim(), state);
            gcDetails.DataSource = dtId;
        }

        private void mtbDate1_Leave(object sender, EventArgs e)
        {
            mtbDate2.Text = mtbDate1.Text;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            returnValue();
        }

        private void frmStTransferToHk_Find_Load(object sender, EventArgs e)
        {
            rdState.SelectedIndex = 2;
            mtbDate1.Text = frmStTransferToHk.query_date;
            mtbDate2.Text = mtbDate1.Text;
        }
    }
}
