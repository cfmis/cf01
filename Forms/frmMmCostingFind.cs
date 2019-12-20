using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MM;

namespace cf01.Forms
{
    public partial class frmMmCostingFind : Form
    {
        public frmMmCostingFind()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dtMmCosting=clsMmCosting.findMmCosting(txtId.Text.Trim(), txtPrd_mo.Text.Trim());
            dgvCosting.DataSource = dtMmCosting;
        }

        private void frmMmCostingFind_Load(object sender, EventArgs e)
        {
            dgvCosting.AutoGenerateColumns = false;
        }

        private void dgvCosting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMmCosting.sent_id = dgvCosting.Rows[dgvCosting.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
            this.Close();
        }


    }
}
