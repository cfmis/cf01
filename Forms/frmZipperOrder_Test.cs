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
    public partial class frmZipperOrder_Test : Form
    {
        public frmZipperOrder_Test()
        {
            InitializeComponent();
        }

        private void frmZipperOrder_Test_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            loadTest();
        }
        private void loadTest()
        {
            DataTable dt = clsZipperOrder.loadMoTest(frmZipperOrder.query_id);
            dgvDetails.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
