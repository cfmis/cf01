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
    public partial class frmProductTypeStdPriceFind : Form
    {
        public frmProductTypeStdPriceFind()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FindData();
        }
        private void FindData()
        {
            DataTable dtArtWork=clsMmProductTypeStdPrice.FindData(txtArtWork.Text, txtProductType.Text,txtSizeName.Text);
            dgvArtWork.DataSource = dtArtWork;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if(frmProductTypeStdPrice.searchState=="Y")
            {
                if (dgvArtWork.Rows.Count > 0)
                    frmProductTypeStdPrice.searchID = dgvArtWork.Rows[dgvArtWork.CurrentRow.Index].Cells["colID"].Value.ToString();
            }
            this.Close();
        }

        private void dgvArtWork_SelectionChanged(object sender, EventArgs e)
        {
            int SizeSN = 0;
            if (dgvArtWork.Rows.Count > 0)
            {
                if (dgvArtWork.Rows[dgvArtWork.CurrentRow.Index].Cells["colSizeSN"].Value.ToString() != "")
                    SizeSN = Convert.ToInt32(dgvArtWork.Rows[dgvArtWork.CurrentRow.Index].Cells["colSizeSN"].Value);
            }
            DataTable dtColor = clsMmProductTypeStdPrice.FindColor(SizeSN);
            dgvColorDetails.DataSource = dtColor;
            txtPrice.Text = "";
            txtCurr.Text = "";
        }

        private void dgvColorDetails_SelectionChanged(object sender, EventArgs e)
        {

            txtPrice.Text = dgvColorDetails.Rows[dgvColorDetails.CurrentRow.Index].Cells["colPrice"].Value.ToString();
            txtCurr.Text = dgvColorDetails.Rows[dgvColorDetails.CurrentRow.Index].Cells["colCurr"].Value.ToString();
        }
    }
}
