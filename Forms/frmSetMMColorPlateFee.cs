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
    public partial class frmSetMMColorPlateFee : Form
    {
        clsCommonUse commUse = new clsCommonUse();
        public frmSetMMColorPlateFee()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string strSql = null;

            strSql = "Select a.mm_item,b.* ";
            strSql += "  FROM mm_color_plate_fee a LEFT JOIN color_plate_quotation b ON a.color_id=b.color_id";

            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "TB_mo").Tables["TB_mo"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }
    }
}
