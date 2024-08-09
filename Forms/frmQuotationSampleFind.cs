using cf01.CLS;
using cf01.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmQuotationSampleFind : Form
    {
        public DataTable dtFind = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        mdlQuotationSample mdl= new mdlQuotationSample();
        public frmQuotationSampleFind()
        {
            InitializeComponent();
            //mdl = md;
            clsApp.Initialize_find_value("frmQuotationSampleFind", pnlFindData.Controls);
            //InitFindData(mdl);
        }

        private void frmQuotationSampleFind_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件            
            if (clsApp.set_find_Value("frmQuotationSampleFind", pnlFindData.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtInput_date1.EditValue = "";
            dtInput_date2.EditValue = "";
            txtSeason.Text = "";
            txtPlm_code.Text = "";
            txtCf_code.Text = "";
            txtMaterial.Text = "";
            txtSize.Text = "";
            txtMacys_color_code.Text = "";
            txtMo_id.Text = "";
            txtCf_color_code.Text = "";
            txtCreate_by.Text = "";
            dtCreate_date1.EditValue = "";
            dtCreate_date2.EditValue = "";
        }

        private void btnSearchByParam_Click(object sender, EventArgs e)
        {
            btnSearchByParam.Focus();
            FindData();
            if (dtFind.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.Yes;//標記查詢到數據并退出
            }
            else
            {
                MessageBox.Show("未查詢到數據，請重新輸入條件查詢數據!", "提示信息");
            }
        }
        private void FindData()
        {
            mdl.input_date = dtInput_date1.EditValue.ToString();
            mdl.input_date2 = dtInput_date2.EditValue.ToString();
            mdl.season = txtSeason.Text;
            mdl.plm_code = txtPlm_code.Text;
            mdl.cf_code = txtCf_code.Text;
            mdl.material = txtMaterial.Text;
            mdl.size = txtSize.Text;
            mdl.macys_color_code = txtMacys_color_code.Text;
            mdl.mo_id = txtMo_id.Text;
            mdl.cf_color_code = txtCf_color_code.Text;
            mdl.create_by = txtCreate_by.Text;
            mdl.create_date = dtCreate_date1.EditValue.ToString();
            mdl.create_date2 = dtCreate_date2.EditValue.ToString();
            mdl.brand_desc = txtBrand_desc.Text;
            mdl.flag_ck = chkFlag_ck.Checked ? 1 : 0;
            dtFind = clsQuotationSample.FindDataByMdl(mdl);
        }
        private void InitFindData(mdlQuotationSample mdl)
        {
            dtInput_date1.EditValue = mdl.input_date;
            dtInput_date2.EditValue = mdl.input_date;
            txtSeason.Text = mdl.season;
            txtPlm_code.Text = mdl.plm_code;
            txtCf_code.Text = mdl.cf_code;
            txtMaterial.Text =mdl.material;
            txtSize.Text = mdl.size;
            txtMacys_color_code.Text = mdl.macys_color_code;
            txtMo_id.Text = mdl.mo_id;
            txtCf_color_code.Text = mdl.cf_color_code;
            txtCreate_by.Text = "";
            dtCreate_date1.EditValue = "";
            dtCreate_date2.EditValue = "";
        }

    }
}
