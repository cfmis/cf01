using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using cf01.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class F_LoadSt : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public F_LoadSt()
        {
            InitializeComponent();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.ShowDialog();
            }).Start();

            load_data(); //数据处理
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            ExpToExcel expxls = new ExpToExcel();
            expxls.DvExportToExcel(dgvDetails);
        }

        private void load_data()
        {
            string _connString = System.Configuration.ConfigurationManager.AppSettings["conn_string_dgerp2"];
            using (SqlConnection sqlconn = new SqlConnection(_connString))
            {
                string sqlStr = "SELECT c.location_id,c.mo_id,c.goods_id,d.name AS inm1cdesc, c.qty,c.sec_qty, b.prod_qty,b.c_qty_ok,c.lot_no" +
                    " FROM dbo.jo_bill_mostly a INNER JOIN dbo.jo_bill_goods_details b ON a.within_code = b.within_code AND  a.id = b.id AND  a.ver = b.ver" +
                    " INNER JOIN dbo.st_details_lot c ON c.within_code = a.within_code AND  c.mo_id = a.mo_id AND  c.location_id = b.wp_id" +
                    " LEFT OUTER JOIN it_goods d ON c.within_code=d.within_code AND c.goods_id=d.id " +
                    " WHERE c.sec_qty >  0 AND  b.c_qty_ok >= b.prod_qty" + " AND c.location_id = " + "'" + textBox1.Text + "'";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlStr, sqlconn))
                {

                    da.Fill(ds, "st_1");
                    dt = ds.Tables["st_1"];
                    //dt.Columns.Add("flag", typeof(String));
                    //DataRow row;
                    //row["flag"] = "Y";
                    DataView dView = dt.DefaultView;

                    //dt.Rows[0]["flag"] = "Y";

                    dView.Sort = "mo_id";
                    //dView.RowFilter = "inc1unit='PCS' ";

                    dgvDetails.AutoGenerateColumns = true;
                    dgvDetails.DataSource = ds;
                    dgvDetails.DataMember = "st_1";
                    //dgvDetails.DataSource = ds.Tables[0];
                    //DataGridViewRow row = dgvDetails.Rows[1];
                    //row.Cells["flag"].Value = "Y";
                }
            }
        }

       
    }
}
