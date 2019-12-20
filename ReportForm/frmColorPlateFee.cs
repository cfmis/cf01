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
    public partial class frmColorPlateFee : Form
    {
        clsCommonUse com = new clsCommonUse();
        public frmColorPlateFee()
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

            strSql = "Select * ";
            strSql += "  FROM color_plate_quotation ";

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
