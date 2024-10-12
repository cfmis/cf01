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
    public partial class frmModulePlace : Form
    {
        public frmModulePlace()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void findMoudlePlace()
        {
            clsCommonUse com = new clsCommonUse();
            DataTable dt = com.getDataProcedure("usp_find_module_place",
                new object[] { txtDep.Text, txtModuleId.Text, txtArt.Text, txtModulePlace.Text });
            dgvDetails.DataSource = dt;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findMoudlePlace();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string art_path;
            if (dgvDetails.RowCount > 0)
            {
                art_path = this.dgvDetails[10, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
                picShowArtWork.Image = Image.FromFile(art_path);
                //Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\jiaomo.gif");
            }
        }

        private void frmModulePlace_Load(object sender, EventArgs e)
        {
            Font a = new Font("GB2312", 18);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
        }
    }
}
