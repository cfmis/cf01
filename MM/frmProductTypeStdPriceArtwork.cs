using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.MM
{
    public partial class frmProductTypeStdPriceArtwork : Form
    {
        public static int UpperSN = 0;
        public frmProductTypeStdPriceArtwork()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtArtwork.Text=="")
            {
                MessageBox.Show("圖樣代號不能為空!");
                txtArtwork.Focus();
                return;
            }
            string result = "";
            result = clsMmProductTypeStdPrice.SaveArtwork(txtUpperSN.Text,txtArtwork.Text.Trim());
            if (result != "")
                MessageBox.Show(result);
            else
            {
                txtArtwork.Text = "";
                LoadArtwork();
                txtArtwork.Focus();
            }
        }

        private void frmProductTypeStdPriceArtwork_Load(object sender, EventArgs e)
        {
            dgvArtwork.AutoGenerateColumns = false;
            txtUpperSN.Text = UpperSN.ToString();
            LoadArtwork();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadArtwork()
        {
            DataTable dtArtwork = clsMmProductTypeStdPrice.LoadArtwork(txtUpperSN.Text);
            dgvArtwork.DataSource = dtArtwork;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvArtwork.Rows.Count == 0)
                return;
            string result = "";
            string Artwork = dgvArtwork.Rows[dgvArtwork.CurrentRow.Index].Cells["colArtwork"].Value.ToString();
            result = clsMmProductTypeStdPrice.DeleteArtwork(txtUpperSN.Text, Artwork);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                LoadArtwork();
            }
        }

        private void txtArtwork_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                btnAdd_Click(sender, e);
            }
        }
    }
}
