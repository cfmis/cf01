using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmSearchItemMostly : Form
    {
        public string ItemTypeId = "";
        public string Type = "";

        public frmSearchItemMostly()
        {
            InitializeComponent();
        }

        private void frmSearchItemMostly_Load(object sender, EventArgs e)
        {
            GetAllItemMostly();
        }

        private void GetAllItemMostly()
        {
            dgvItemMostly.ReadOnly = true;
            dgvItemMostly.AutoGenerateColumns = false;
            dgvItemMostly.DataSource = CLS.clsTestProductPlan.GetAllTestItemMostly();
            dgvItemMostly.Refresh();
        }

        private void dgvItemMostly_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItemMostly.Rows.Count > 0)
            {
                ItemTypeId = dgvItemMostly.CurrentRow.Cells["colId"].Value.ToString();
                Type = dgvItemMostly.CurrentRow.Cells["colType"].Value.ToString();

                this.DialogResult = DialogResult.Yes;
            }
        }


    }
}
