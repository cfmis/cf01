using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmInm01f : Form
    {
        private DataTable dt = new DataTable();

        public frmInm01f()
        {
            InitializeComponent();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string strSql = "select a.id As inm1item,a.english_name As inm1desc,a.name As inm1cdesc,a.unit_code As inm1unit,c.picture_path,b.picture_name" +
                " From it_goods a " +
                " Left Outer Join dbo.cd_pattern_details b On a.within_code=b.within_code And a.blueprint_id=b.id" +
                " Inner Join cd_company c On a.within_code=c.within_code" +
                " where a.id >= ''";
            if (textBox1.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,1,2) >= " + "'" + textBox1.Text.ToString() + "'";
            }
            if (textBox2.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,1,2) <= " + "'" + textBox2.Text.ToString() + "'";
            }
            if (textBox3.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,3,2) >= " + "'" + textBox3.Text.ToString() + "'";
            }
            if (textBox4.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,3,2) <= " + "'" + textBox4.Text.ToString() + "'";
            }
            if (textBox5.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,5,7) >= " + "'" + textBox5.Text.ToString() + "'";
            }
            if (textBox6.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,5,7) <= " + "'" + textBox6.Text.ToString() + "'";
            }
            if (textBox7.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,12,3) >= " + "'" + textBox7.Text.ToString() + "'";
            }
            if (textBox8.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,12,3) <= " + "'" + textBox8.Text.ToString() + "'";
            }
            if (textBox9.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,15,4) >= " + "'" + textBox9.Text.ToString() + "'";
            }
            if (textBox10.Text.ToString() != "")
            {
                strSql = strSql + " and substring(a.id,15,4) <= " + "'" + textBox10.Text.ToString() + "'";
            }
            /*
            LoadCfData objUnit = new LoadCfData(this.dgvDetails);
            objUnit.UpdateDataGrid(strSql);
            */
            string _connString = System.Configuration.ConfigurationManager.AppSettings["conn_string_dgerp2"];
            SqlConnection con = new SqlConnection(_connString);
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "inm01f");
            dt = ds.Tables["inm01f"];
            con.Close();
            //DataView dView = new DataView(ds.Tables["ivm01"]);
            //dView.Sort = "id";
            //BindDataGridView("1");
            dgvDetails.DataSource = ds.Tables["inm01f"];
            //dt = ds.Tables["ivm01"].Copy();
            if (dgvDetails.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄", "系統信息", MessageBoxButtons.OK);
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            ExpToExcel expxls = new ExpToExcel();
            expxls.DvExportToExcel(dgvDetails);
        }

        private void BTNPREVIEW_Click(object sender, EventArgs e)
        {
            Reports.crtInm01f r = new Reports.crtInm01f();
            r.SetDataSource(dt);
            frmPrint p = new frmPrint();
            p.crystalReportViewer1.ReportSource = r;
            p.ShowDialog();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
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


    }
}
