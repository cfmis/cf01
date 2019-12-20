using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmOcSummary_details : Form
    {
        DataSet ds = new DataSet();
        DataTable dtDetails = new DataTable();
        public frmOcSummary_details(DataSet pDs)
        {
            InitializeComponent();
            ds = pDs;
            dtDetails = ds.Tables[1];
            dgvDetails.DataSource = dtDetails;
        }

        private void rdog1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (rdog1.SelectedIndex == 0)
            {
                dtDetails =ds.Tables[1];
            }
            else
            {
                dtDetails = ds.Tables[2];
            }
            dgvDetails.DataSource = dtDetails;
            //禁止列排序
            for (int i = 0; i < this.dgvDetails.Columns.Count; i++)
            {
                this.dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }            
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dtDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Excel();
        }

        private void Excel() //匯出EXCEL
        {
            if (dgvDetails.RowCount > 0)
            {
                //ExpToExcel.DataGridViewToExcel(dgvDetails);
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
