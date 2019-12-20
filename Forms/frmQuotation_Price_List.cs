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
        public frmQuotation_Price_List(string temp_code)
        {
            InitializeComponent();
            string sql = string.Format(
            @"SELECT temp_code,ver,number_enter,price_usd,price_hkd,price_rmb,price_unit,hkd_ex_fty,usd_ex_fty,
            discount,disc_price_usd,disc_price_hkd,disc_price_rmb,disc_hkd_ex_fty,rmb_remark,remark,amusr,amtim 
            FROM dbo.quotation WHERE temp_code='{0}'
            UNION 
            SELECT temp_code,ver,number_enter,price_usd,price_hkd,price_rmb,price_unit,hkd_ex_fty,usd_ex_fty,            
            discount,disc_price_usd,disc_price_hkd,disc_price_rmb,disc_hkd_ex_fty,rmb_remark,remark,amusr,amtim  
            FROM dbo.quotation_history WHERE temp_code='{0}'", temp_code);
            dgvPriceList.DataSource = clsPublicOfCF01.GetDataTable(sql);
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
    }
}
