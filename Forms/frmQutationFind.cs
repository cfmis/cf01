using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmQutationFind : Form
    {
        private DataTable dt = new DataTable();
        public int Current_row;
        public frmQutationFind(DataTable pdt)
        {
            InitializeComponent();            
            dgvDetails.DataSource = pdt;
            NextControl oFocus = new NextControl(this,"1");
            oFocus.EnterToTab();   
        }

        private void frmQutationFind_Load(object sender, EventArgs e)
        {
            DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'");
            for (int i = 0; i < dtSales_Group.Rows.Count; i++)
            {
                txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void btnFind_Click(object sender, EventArgs e)
        {
            string strDat1 = txtDate1.Text;
            string strDat2 = txtDate2.Text;  
            if (strDat1 == "    /  /")
            {
                strDat1 = "";
            }
            if (strDat2 == "    /  /")
            {
                strDat2 = "";
            }
            SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@user_id",DBUtility._user_id),
                       new SqlParameter("@sales_group",txtSales_group.Text),
                       new SqlParameter("@brand",txtBrand.Text),
                       new SqlParameter("@material",txtMaterial.Text),
                       new SqlParameter("@cust_code",txtCust_code.Text),
                       new SqlParameter("@cust_color",txtCust_color.Text),
                       new SqlParameter("@cf_code",txtCf_code.Text),
                       new SqlParameter("@cf_color",txtCf_color.Text),
                       new SqlParameter("@season",txtSeason.Text),
                       new SqlParameter("@temp_code",txtTemp_code.Text),
                       new SqlParameter("@size",txtSize.Text),
                       new SqlParameter("@dat1",strDat1), 
                       new SqlParameter("@dat2",strDat2)
                    };
            dt=clsPublicOfCF01.ExecuteProcedureReturnTable("usp_qoutation_fing",paras);
            dgvDetails.DataSource = dt;
            frmQuotation.dtDetail = dt;
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            Current_row = dgvDetails.CurrentRow.Index;
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}
