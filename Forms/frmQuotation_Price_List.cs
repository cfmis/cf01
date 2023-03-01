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
    public partial class frmQuotation_Price_List : Form
    {

        bool is_isible_pdd = false;
        string temp_ref_temp_code = "";
        public frmQuotation_Price_List(string temp_code,bool is_display_remark_pdd)
        {
            InitializeComponent();
            string sql = string.Format(
            @"SELECT temp_code,ver,number_enter,price_usd,price_hkd,price_rmb,hkd_ex_fty,usd_ex_fty,price_unit,vnd_bp,price_vnd_usd,price_vnd,price_vnd_grs,price_vnd_pcs,
            discount,disc_price_usd,disc_price_hkd,disc_price_rmb,disc_price_vnd,disc_hkd_ex_fty,rmb_remark,remark_pdd,remark,date,crtim,amusr,amtim,ref_temp_code 
            FROM dbo.quotation WHERE temp_code='{0}'
            UNION 
            SELECT temp_code,ver,number_enter,price_usd,price_hkd,price_rmb,hkd_ex_fty,usd_ex_fty,price_unit,vnd_bp,price_vnd_usd,price_vnd,price_vnd_grs,price_vnd_pcs,
            discount,disc_price_usd,disc_price_hkd,disc_price_rmb,disc_price_vnd,disc_hkd_ex_fty,rmb_remark,remark_pdd,remark,date,crtim,amusr,amtim,ref_temp_code 
            FROM dbo.quotation_history WHERE temp_code='{0}'", temp_code);
            dgvPriceList.DataSource = clsPublicOfCF01.GetDataTable(sql);
            is_isible_pdd = is_display_remark_pdd;
        }

        private void dgvPriceList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //最后一行是當前最新的單價
            if (e.RowIndex == dgvPriceList.Rows.Count-1)
            {
                dgvPriceList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;               
            }
            else
                dgvPriceList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void frmQuotation_Price_List_Load(object sender, EventArgs e)
        {          
            dgvPriceList.Columns["remark_pdd"].Visible = is_isible_pdd; 
        }

        private void dgvPriceList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPriceList.RowCount > 0)
            {
                string ref_temp_code = dgvPriceList.CurrentRow.Cells["ref_temp_code"].Value.ToString();               
                if (!string.IsNullOrEmpty(ref_temp_code))
                {
                    if (temp_ref_temp_code != ref_temp_code)//避免重復查詢
                    {
                        string strSql = string.Format(
                            @"SELECT seq_id, sub, pvh_no, status, approval_by, convert(char(10), Approval_date, 120) as Approval_date,Approval_status,attn_path,remark as remark_sub
                         FROM dbo.quotation_sub with(nolock) WHERE temp_code = '{0}' ORDER BY seq_id", ref_temp_code);
                        DataTable dtSubmo = clsPublicOfCF01.GetDataTable(strSql);
                        dgvSub.DataSource = dtSubmo;
                    }
                }
            }
        }
    }
}
