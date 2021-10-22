using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmTestExcel_Search : Form
    {
        public DataTable dtTe = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        public frmTestExcel_Search()
        {
            InitializeComponent();
            clsApp.Initialize_find_value("frmTestExcel", SearchPanel.Controls);
            txtSales_group.Text = "";
        }

        private void btnSearchByParam_Click(object sender, EventArgs e)
        {
            btnSearchByParam.Focus();
            //if (txtSales_group.Text == "")
            //{
            //    MessageBox.Show("請輸入組別資料!", "提示信息");
            //    txtSales_group.Focus();
            //    return;
            //}
            GetTestExcel();
            if (dtTe.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.Yes;//標記查詢到數據并退出
            }
            else
            {
                MessageBox.Show("未查詢到數據，請重新輸入條件查詢數據!","提示信息");
            }
        }

        private void GetTestExcel()
        {
            MDL.mdlTestExcel objTe = new MDL.mdlTestExcel();
            if (lueColor_sq.Text != "")
            {
                objTe.color_id = lueColor_sq.EditValue.ToString();
            }
            if (lueMat_sq.Text != "")
            {
                objTe.mat_id = lueMat_sq.EditValue.ToString();
            }
            if (lueProductType_sq.Text != "")
            {
                objTe.poduct_type_id = lueProductType_sq.EditValue.ToString();
            }
            if (lueTestItem_sq.Text != "")
            {
                objTe.test_item_id = lueTestItem_sq.EditValue.ToString();
            }
            if (deExpriy.Text != "")            
            {                
                objTe.expiry_date = deExpriy.Text.Replace('/', '-');
            }
            objTe.finish_name = txtFinish_name.Text;
            objTe.pattern_id = txtPattern_id_sq.Text;
            objTe.test_report_no = txtTest_report_no.Text;
            objTe.trim_code = txtTrim_code.Text;
            objTe.trim_color_code = txtTrim_color_code.Text;
            objTe.ref_mo = txtRef_mo.Text.Trim();
            objTe.size = txtSize.Text;
            objTe.cf_color = txtCf_color.Text;
            objTe.sales_group = txtSales_group.Text;
            objTe.doc_type = txtDoc_type.Text;
            objTe.crusr = txtcrusr.Text;
            objTe.test_dept = lueDept_dept.Text;
            objTe.invoice_id = txtInvoice_id.Text;
            if (!string.IsNullOrEmpty(dtCreate_date1.Text))
            {
                objTe.crtim = DateTime.Parse(dtCreate_date1.Text);
            }
            if (!string.IsNullOrEmpty(dtCreate_date2.Text))
            {
                objTe.amtim = DateTime.Parse(dtCreate_date2.Text);
            }

            dtTe = clsTestProductPlan.GetTestExcel(objTe);
        }

        private void frmSearchTestExcel_Load(object sender, EventArgs e)
        {
            /*查詢條件綁定*/
            clsTestProductPlan.SetMatType(lueMat_sq);
            clsTestProductPlan.SetProductType(lueProductType_sq);
            clsTestProductPlan.SetTest_item(lueTestItem_sq);
            clsTestProductPlan.SetColorType(lueColor_sq);
            clsTestProductPlan.SetTestDept(lueDept_dept);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lueColor_sq.EditValue = "";
            lueMat_sq.EditValue = "";
            lueProductType_sq.EditValue = "";
            lueTestItem_sq.EditValue = "";
            deExpriy.EditValue = "";
            txtFinish_name.Text = "";
            txtPattern_id_sq.Text = "";
            txtTest_report_no.Text = "";
            txtTrim_code.Text = "";
            txtTrim_color_code.Text = "";
            txtSales_group.Text = "";
            txtSize.Text = "";
            txtCf_color.Text = "";
            txtDoc_type.Text = "";           
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件
            txtSales_group.Text = "";
            if (clsApp.set_find_Value("frmTestExcel", SearchPanel.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void frmTestExcel_Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;            
        }

        private void dtCreate_date1_Leave(object sender, EventArgs e)
        {
            dtCreate_date2.EditValue = dtCreate_date1.EditValue;
        }
    }
}
