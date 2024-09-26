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
    public partial class frmBomDeleteCheck : Form
    {
        DataTable dtBOM = new DataTable();
        public frmBomDeleteCheck()
        {
            InitializeComponent();
            dtBOM = frmBom.dtExistsBom;
        }

        private void frmBomDeleteCheck_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtBOM;
        }

        private void frmBomDeleteCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtBOM.Dispose();
        }
    }
}
