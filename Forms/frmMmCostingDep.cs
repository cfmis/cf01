using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmMmCostingDep : Form
    {
        public frmMmCostingDep()
        {
            InitializeComponent();
        }

        private void frmMmCostingDep_Load(object sender, EventArgs e)
        {
            dgvDepCharges.AutoGenerateColumns = false;
            dgvWip.AutoGenerateColumns = false;
            initData();
        }
        private void initData()
        {
            frmMmCosting.dtDepCharges = clsMmCosting.getCostDepCharges(frmMmCosting.sent_id);
            dgvDepCharges.DataSource = frmMmCosting.dtDepCharges;
            DataTable dtWip = clsMmCosting.getWip(frmMmCosting.sent_prd_mo);
            dgvWip.DataSource = dtWip;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvWip.Rows.Count == 0)
                return;
            int rows = dgvWip.CurrentCell.RowIndex;
            DataGridViewRow CurrentRow = dgvWip.Rows[rows];
            DataRow dr = frmMmCosting.dtDepCharges.NewRow();
            dr["dep_id"] = CurrentRow.Cells["colWp_id"].Value.ToString();
            dr["dep_cdesc"] = CurrentRow.Cells["colWp_cdesc"].Value.ToString();
            dr["dep_charges"] = CurrentRow.Cells["colDep_chareges"].Value.ToString() != "" ? CurrentRow.Cells["colDep_chareges"].Value.ToString() : "0.00";
            frmMmCosting.dtDepCharges.Rows.Add(dr);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepCharges.Rows.Count == 0)
                return;
            int rows = dgvDepCharges.CurrentCell.RowIndex;
            frmMmCosting.dtDepCharges.Rows.RemoveAt(rows);
        }
    }
}
