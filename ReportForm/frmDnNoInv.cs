using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.BaseForm
{
    public partial class frmSt01 : Form
    {

        public frmSt01()
        {
            InitializeComponent();
        }
        private DataTable dt;
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }
        private void btmFind_Click(object sender, EventArgs e)
        {
            string dat1 = "", dat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("訂單日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false)
                dat1 = this.dateEdit1.Text.ToString();// Convert.ToDateTime(this.dateEdit1.EditValue).ToString("yyyy/mm/dd");
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
                dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
            clsCommonUse c = new clsCommonUse();
            dt = c.getDataProcedure("z_load_st01",
                new object[] {textBox1.Text, textBox2.Text,  textBox3.Text
                ,textBox4.Text,dat1,dat2,textBox5.Text,textBox6.Text
                ,textBox7.Text,textBox8.Text,textBox9.Text,textBox10.Text});
            dgvDetails.DataSource = dt;

        }

        private void btmPreview_Click(object sender, EventArgs e)
        {
            Reports.crtSt01 r = new Reports.crtSt01();
            //r.SetDataSource(ds.Tables["st01"]);
            r.SetDataSource(dt);
            frmPrint p = new frmPrint();
            p.crystalReportViewer1.ReportSource = r;
            p.ShowDialog();
        }

        private void btmExcel_Click(object sender, EventArgs e)
        {
            ExpToExcel expxls = new ExpToExcel();
            expxls.DvExportToExcel(dgvDetails);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox4.Text = textBox3.Text;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox8.Text = textBox7.Text;
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox10.Text = textBox9.Text;
        }

        private void btmPrint_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_Leave(object sender, EventArgs e)
        {
            dateEdit2.Text = dateEdit1.Text;
        }
    }
}
