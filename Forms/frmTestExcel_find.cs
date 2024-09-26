using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using cf01.CLS;


namespace cf01.Forms
{
    public partial class frmTestExcel_find : Form
    {
        public static string str_language = "0";
        public string test_public_path = "";
        DataTable dtExcel = new DataTable();
        private int months ;

        public frmTestExcel_find()
        {
            InitializeComponent();
            str_language = DBUtility._language;
            //NextControl oNext = new NextControl(this, "2");
            //oNext.EnterToTab();  
        }

        private void frmTestExcel_find_Load(object sender, EventArgs e)
        {
            //測試項目
            clsTestProductPlan.SetTest_item(txtTest_item_no);            
            //顏色
            clsTestProductPlan.SetColorType(txtColor_category);           
            //原材料
            clsTestProductPlan.SetMatType(txtDatum);            
            //產品類型
            clsTestProductPlan.SetProductType(txtProducts_type);
            //取測試報告公共路徑 
            test_public_path = clsTestProductPlan.Get_Test_Public_Path();           

            txtDatum.EditValue = frmTestStandard.ststrMat_id;
            txtColor_category.EditValue = frmTestStandard.ststrColor_type;
            txtTest_item_no.EditValue = frmTestStandard.ststrTest_Item;
            txtCustomer_color_id.Text = frmTestStandard.ststrCustomer_color_id;
            txtSales_group.Text = frmTestStandard.strGroup;
            txtSize.Text = frmTestStandard.strSize;
            txtCf_color.Text = frmTestStandard.strCf_color;
            txtTrim_Code.Text = frmTestStandard.strCustomer_goods;
            //txtPattern_id.Text = frmTestStandard.ststrPattern_id ;
        }

        private void frmTestExcel_find_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            SetObjValue.ClearObjValue(Controls, "1");
            dtExcel.Clear();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtRemark.Focus();
            if (txtTest_item_no.Text != "")
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("測試項目不可爲空格!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadData()
        {
            months = Convert.ToInt16(numUpDown1.Value);
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@datum", txtDatum.EditValue),
	            new SqlParameter("@color_category", txtColor_category.EditValue),
                new SqlParameter("@test_item_id", txtTest_item_no.EditValue),
                new SqlParameter("@customer_color_id", txtCustomer_color_id.Text),
                new SqlParameter("@pattern_id", txtPattern_id.Text),
                new SqlParameter("@trim_code", txtTrim_Code.Text),
                new SqlParameter("@trim_color_code", txtTrim_Color_Code.Text),
                new SqlParameter("@products_type", txtProducts_type.EditValue),
                new SqlParameter("@test_report_no", txtTest_report_no.Text),
                new SqlParameter("@expiry_date", txtExpiry_date.Text),
                new SqlParameter("@ref_mo", txtRef_mo.Text),
                new SqlParameter("@remark", txtRemark.Text),
                new SqlParameter("@sales_group", txtSales_group.Text),
                new SqlParameter("@size", txtSize.Text),
                new SqlParameter("@cf_color", txtCf_color.Text),
                new SqlParameter("@doc_type", txtDoc_type.Text)                                               
			};
            dtExcel = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_test_excel_search", paras);
            dtExcel.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));            
            gridControl1.DataSource = dtExcel;
            if (dtExcel.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }


        private void BTNOK_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                txtRemark.Focus();
                DataRow[] dr = dtExcel.Select("flag_select=true");
                if (dr.Length > 1)
                {
                    MessageBox.Show("註意：一次只可以選取一行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (dr.Length == 1)
                {
                    frmTestStandard.ststrTest_Report_No = dr[0]["test_report_no"].ToString().Trim();
                    frmTestStandard.ststrEffect = dr[0]["expiry_date"].ToString().Trim();
                    frmTestStandard.ststrTrim_color_code = dr[0]["trim_color_code"].ToString().Trim(); //送測編號
                    frmTestStandard.ststrRef_mo = dr[0]["ref_mo"].ToString().Trim(); //參考頁數
                    frmTestStandard.ststrTest_Reprot_Path = dr[0]["test_report_path"].ToString().Trim();                    
                    frmTestStandard.stbolFlag_Return = true;//設置反回是否更新的標記
                }
                else
                {
                    frmTestStandard.ststrTest_Report_No = "";
                    frmTestStandard.ststrTrim_color_code = "";
                    frmTestStandard.ststrRef_mo = "";
                    frmTestStandard.stbolFlag_Return = false;
                    MessageBox.Show("請首先選取一行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Close();
            }          
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2) // 判断是否是用鼠标双击    
            {                
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo ghi = gridView1.CalcHitInfo(new Point(e.X, e.Y));
                if (ghi.InRow)  // 判断光标是否在行内    
                {
                    if (ghi.Column.Name == "test_report_no")
                    {
                        //打開PDF檔
                        string strFile = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "test_report_path");
                        if (!string.IsNullOrEmpty(strFile))
                        {
                            strFile = test_public_path + strFile.Trim();
                            clsTestProductPlan.Open_test_pdf(strFile);
                        }
                    }
                }                
            }
        }

        private void txtDatum_Click(object sender, EventArgs e)
        {
            txtDatum.SelectAll();
        }

        private void txtColor_category_Click(object sender, EventArgs e)
        {
            txtColor_category.SelectAll();
        }

        private void txtTest_item_no_Click(object sender, EventArgs e)
        {
            txtTest_item_no.SelectAll();
        }

        private void txtProducts_type_Click(object sender, EventArgs e)
        {
            txtProducts_type.SelectAll();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }

            if (e.Column.FieldName == "expiry_date")
            {
                //int cell_value = Convert.ToInt16(e.CellValue);
                int cell_value = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, "expirys"));
                if (cell_value < 0)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (cell_value == months && cell_value>0)
                {
                    e.Appearance.ForeColor = Color.Blue;
                }                
            }
          
        }

        private void frmTestExcel_find_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtExcel.Dispose();
        }

     

     

     

     
    }
}
