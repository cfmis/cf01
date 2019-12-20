using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmTrimsSheetFind : Form
    {
        DataTable dtFind = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        public List<mdlQuotation> mList = new List<mdlQuotation>();
        public frmTrimsSheetFind(string oc_no)
        {
            InitializeComponent();
            txttrim_code.Text = oc_no;
        }

        private void frmTrimsSheetFind_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void Load_Data()
        {
            if (txttrim_code.Text == "")
                return;
            string strsql = string.Format(
            @"SELECT a.date, a.cust_code,a.brand,a.brand_desc,a.season,a.season_desc,a.cf_code,a.cust_color,a.cf_color,
            a.product_desc,a.size,a.price_hkd,a.price_usd,a.hkd_ex_fty,a.usd_ex_fty,a.price_unit,
            a.lead_time_max,a.material,Isnull(b.sub,'') as sub
            FROM quotation a with(nolock)
            LEFT JOIN (select S.temp_code,S.sub 
		               from (select temp_code,sub,ROW_NUMBER() OVER(PARTITION BY temp_code order by temp_code,seq_id desc) as row_id from quotation_sub with(nolock)) S
		               where S.row_id=1) b ON a.temp_code =b.temp_code
            WHERE a.cust_code like '%{0}%' order by a.date,a.cust_code", txttrim_code.Text);
            dtFind = clsPublicOfCF01.GetDataTable(strsql);
            dgvMoList.DataSource = dtFind;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvMoList.Rows.Count == 0)
            {
                return;
            }           
            int i=dgvMoList.CurrentCell.RowIndex;
            //frmTrimsSheet.mList.Clear();
            mList.Clear();
            mdlQuotation objModel = new mdlQuotation()
            {
                trim_code = dgvMoList.CurrentRow.Cells["cust_code"].Value.ToString(),
                brand = dgvMoList.CurrentRow.Cells["brand"].Value.ToString(),
                brand_desc = dgvMoList.CurrentRow.Cells["brand_desc"].Value.ToString(),
                season = dgvMoList.CurrentRow.Cells["season"].Value.ToString(),
                season_desc = dgvMoList.CurrentRow.Cells["season_desc"].Value.ToString(),
                cf_code = dgvMoList.CurrentRow.Cells["cf_code"].Value.ToString(),
                cust_color = dgvMoList.CurrentRow.Cells["cust_color"].Value.ToString(),
                cf_color = dgvMoList.CurrentRow.Cells["cf_color"].Value.ToString(),
                product_desc = dgvMoList.CurrentRow.Cells["product_desc"].Value.ToString(),
                size = dgvMoList.CurrentRow.Cells["size"].Value.ToString(),
                price_hkd = clsApp.Return_Float_Value_4(dgvMoList.CurrentRow.Cells["price_hkd"].Value.ToString()),
                price_usd = clsApp.Return_Float_Value_4(dgvMoList.CurrentRow.Cells["price_usd"].Value.ToString()),
                hkd_ex_fty = clsApp.Return_Float_Value_4(dgvMoList.CurrentRow.Cells["hkd_ex_fty"].Value.ToString()),
                usd_ex_fty = clsApp.Return_Float_Value_4(dgvMoList.CurrentRow.Cells["usd_ex_fty"].Value.ToString()),
                price_unit = dgvMoList.CurrentRow.Cells["price_unit"].Value.ToString(),
                lead_time_max = dgvMoList.CurrentRow.Cells["lead_time_max"].Value.ToString(),
                material = dgvMoList.CurrentRow.Cells["material"].Value.ToString(),
                sub = dgvMoList.CurrentRow.Cells["sub"].Value.ToString()
            };
            //frmTrimsSheet.mList.Add(objModel);
            mList.Add(objModel);
            Close();           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTrimsSheetFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtFind.Dispose();
            clsApp = null;
        }
     
    }
}
