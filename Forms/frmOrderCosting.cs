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
    public partial class frmOrderCosting : Form
    {
        public frmOrderCosting()
        {
            InitializeComponent();
        }

        private void txtDate_from_Leave(object sender, EventArgs e)
        {
            txtDate_to.Text = txtDate_from.Text;
        }

        private void txtMo_from_Leave(object sender, EventArgs e)
        {
            txtMo_to.Text = txtMo_from.Text;
        }

        private void txtItem_from_Leave(object sender, EventArgs e)
        {
            txtItem_to.Text = txtItem_from.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderCosting_Load(object sender, EventArgs e)
        {
            dgvOrderCosting.AutoGenerateColumns = false;
            txtDate_from.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtDate_to.Text = txtDate_from.Text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int type = 3;
            if (rdbIsCosting.Checked == true)
                type = 1;
            else if (rdbNoCosting.Checked == true)
                type = 0;
            DataTable dtOrderCosting = clsMmCosting.findOrderCosting(type, txtDate_from.Text, txtDate_to.Text, txtItem_from.Text
                , txtItem_to.Text, txtMo_from.Text, txtMo_to.Text);
            dgvOrderCosting.DataSource = dtOrderCosting;
        }
    }
}
