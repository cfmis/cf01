using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmGoodsPricePlate : Form
    {
        public string prd_item{get;set;}
        public string prd_name { get; set; }
        public string prd_dep { get; set; }
        public string prd_vend { get; set; }
        public frmGoodsPricePlate()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGoodsPricePlate_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            txtPrd_item.Text = prd_item;
            txtPrd_name.Text = prd_name;
            txtPrd_dep.Text = prd_dep;
            txtPrd_vend.Text = prd_vend;
            loadData();
        }
        private void loadData()
        {
            int show_details = 0;//顯示明細表記錄  1--匯總表記錄

            int show_price = 0;
            string date1 = "";
            string date2 = "";
            string vend_id = "";

            string doc_id1 = "";
            string doc_id2 = "";
            string mo1 = "";
            string mo2 = "";
            string dep = txtPrd_dep.Text.Trim();
            string prd_item = txtPrd_item.Text.Trim();

            string sqlstr = "pu_DeliverSetPrice_find";
            SqlParameter[] parameters = {new SqlParameter("@show_details", show_details),new SqlParameter("@show_price", show_price)
                                            ,new SqlParameter("@dep", dep),new SqlParameter("@vend_id", vend_id),new SqlParameter("@prd_item", prd_item)
                                            , new SqlParameter("@doc_id1", doc_id1), new SqlParameter("@doc_id2", doc_id2)
                                        ,new SqlParameter("@date1", date1),new SqlParameter("@date2", date2)};
            DataTable tbPu = clsPublicOfCF01.ExecuteProcedureReturnTable(sqlstr, parameters);
            dgvDetails.DataSource = tbPu;
        }

        private void btnWeg_Click(object sender, EventArgs e)
        {
            getValue(1);
        }
        

        private void btnQty_Click(object sender, EventArgs e)
        {
            getValue(2);
        }

        private void getValue(int type)
        {
            if (dgvDetails.Rows.Count == 0)
                return;
            int row = dgvDetails.CurrentCell.RowIndex;
            if (type == 1)
            {
                frmGoodsPriceCount.get_plate_type = "weg";
                frmGoodsPriceCount.get_plate_price = dgvDetails.Rows[row].Cells["colSec_price"].Value.ToString();
            }
            else
            {
                frmGoodsPriceCount.get_plate_type = "qty";
                frmGoodsPriceCount.get_plate_price = dgvDetails.Rows[row].Cells["colPrice"].Value.ToString();
            }
            this.Close();
        }
    }
}
