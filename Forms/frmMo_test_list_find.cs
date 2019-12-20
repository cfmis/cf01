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
using cf01.ModuleClass;

namespace cf01.Forms
{
    public partial class frmMo_test_list_find : Form
    {
        DataTable dtTestStd = new DataTable();
        DataTable dtTest_list = new DataTable(); 
        public frmMo_test_list_find()
        {
            InitializeComponent();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
            dtTestStd.Dispose();
            dtTest_list.Dispose();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtSize.Focus();
            LoadData();
        }

        private void LoadData()
        {           
            SqlParameter[] paras = new SqlParameter[]
			{
					new SqlParameter("@mo_id_s", txtMo_id1.Text),
					new SqlParameter("@mo_id_e", txtMo_id2.Text),
					new SqlParameter("@brand_s", txtBrand_id1.Text),
					new SqlParameter("@brand_e", txtBrand_id2.Text),
					new SqlParameter("@mould_id_s", txtMould_id1.Text),
					new SqlParameter("@mould_id_e", txtMould_id2.Text),
					new SqlParameter("@cust_item_id", txtCust_item_id.Text),
					new SqlParameter("@cust_color", txtCust_color.Text),
					new SqlParameter("@artwork", txtArtwork.Text),
					new SqlParameter("@size", txtSize.Text),
                    new SqlParameter("@report_type", "1")	
			};
            dtTestStd = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_mo_test_list", paras);
            dgvDetails.DataSource = dtTestStd;
            if (dgvDetails.Rows.Count == 0)
            {
                frmMo_test_list.ID_Search = "";                
                dtTest_list.Clear();               
            }
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            SetObjValue.ClearObjValue(this.Controls, "1");
            dtTestStd.Clear();
            dtTest_list.Clear();
        }

        private void frmMo_test_list_find_Load(object sender, EventArgs e)
        {
            //改变标题的高度;  
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDetails.ColumnHeadersHeight = 25;  
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                frmMo_test_list.ID_Search = dgvDetails.CurrentRow.Cells["mo_id"].Value.ToString();               
                string strSql = string.Format(
                            @"SELECT A.dept_test +' '+ B.name collate Chinese_PRC_CI_AS AS dept_test,
                            A.result_test,A.date_test,A.dept_next+' '+ C.name collate Chinese_PRC_CI_AS AS dept_next,
                            A.date_dept_next,A.receipt_by,A.receipt_date,A.remark as rmk
                            FROM dbo.bs_mo_test_list_details A with(nolock)	
	                            LEFT JOIN dgerp2.cferp.dbo.cd_department B 
		                            ON A.dept_test=B.id collate Chinese_PRC_CI_AS 
	                            LEFT JOIN dgerp2.cferp.dbo.cd_department C 
		                            ON A.dept_next=C.id collate Chinese_PRC_CI_AS 
                            WHERE A.mo_id='{0}' AND A.ver={1}", frmMo_test_list.ID_Search, dgvDetails.CurrentRow.Cells["ver"].Value);
                dtTest_list = clsPublicOfCF01.GetDataTable(strSql);
                dgvList.DataSource = dtTest_list;
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                SqlParameter[] paras = new SqlParameter[]
			    {
					    new SqlParameter("@mo_id_s", txtMo_id1.Text),
					    new SqlParameter("@mo_id_e", txtMo_id2.Text),
					    new SqlParameter("@brand_s", txtBrand_id1.Text),
					    new SqlParameter("@brand_e", txtBrand_id2.Text),
					    new SqlParameter("@mould_id_s", txtMould_id1.Text),
					    new SqlParameter("@mould_id_e", txtMould_id2.Text),
					    new SqlParameter("@cust_item_id", txtCust_item_id.Text),
					    new SqlParameter("@cust_color", txtCust_color.Text),
					    new SqlParameter("@artwork", txtArtwork.Text),
					    new SqlParameter("@size", txtSize.Text),
                        new SqlParameter("@report_type", "2")
			    };
                DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_mo_test_list", paras);

                dgvExcel.DataSource = dt;
                ExpToExcel.DataGridViewToExcel(dgvExcel);                
            }
            else
            {
                MessageBox.Show("沒有可匯出到Excel的數據。");
            }
           
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.Text = txtBrand_id1.Text;
        }

        private void txtMould_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }

     
    }
}
