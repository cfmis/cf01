using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using DevExpress.XtraEditors;


namespace cf01.Forms
{
	public partial class frmTestFind : Form
	{       
		public static string str_language = "0";  
		public string test_public_path="";
		DataTable dtTestStd = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();

		public frmTestFind()
		{
			InitializeComponent();
			str_language = DBUtility._language;
            clsApp.Initialize_find_value(this.Name, panel1.Controls);
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();            
		}

		private void frmTestFind_Load(object sender, EventArgs e)
		{
			//牌子類別
			clsTestProductPlan.SetBrandType(txtBrand_category1);
			clsTestProductPlan.SetBrandType(txtBrand_category2);
			//顏色
			clsTestProductPlan.SetColorType(txtColor_category1);
			clsTestProductPlan.SetColorType(txtColor_category2);
			//材質
			clsTestProductPlan.SetMatType(txtDatum1);
			clsTestProductPlan.SetMatType(txtDatum2);
			//產品類型
			clsTestProductPlan.SetProductType(txtProducts_type1);
			clsTestProductPlan.SetProductType(txtProducts_type2);
			//設置測試項目編號
			clsTestProductPlan.SetTest_item(txtTest_item_no);
			//取測試報告公共路徑
			test_public_path = clsTestProductPlan.Get_Test_Public_Path();  
            //組別
            DataTable dtSales_Group = clsSales_group.Get_sales_group();
            txtSales_group.Properties.DataSource = dtSales_Group;
            txtSales_group.Properties.ValueMember = "id";
            txtSales_group.Properties.DisplayMember = "cdesc";
		}

		private void BTNEXIT_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtBrand_category1_Leave(object sender, EventArgs e)
		{
			txtBrand_category2.EditValue = txtBrand_category1.EditValue;
			if (txtBrand_category1.Text != "")
			{
				LoadData();
			}
		}

		private void txtColor_category1_Leave(object sender, EventArgs e)
		{
			txtColor_category2.EditValue = txtColor_category1.EditValue;
			if (txtColor_category1.Text != "")
			{
				LoadData();  
			}
		}

		private void txtDatum1_Leave(object sender, EventArgs e)
		{
			txtDatum2.EditValue = txtDatum1.EditValue;
			if (txtDatum1.Text != "")
			{
				LoadData();  
			}
		}

		private void txtProducts_type1_Leave(object sender, EventArgs e)
		{
			txtProducts_type2.EditValue = txtProducts_type1.EditValue;
            //if (txtProducts_type1.Text != "")
            //{
            //    LoadData();
            //}
		}

		private void txtID1_Leave(object sender, EventArgs e)
		{
			txtID2.Text = txtID1.Text;
            //if (txtID1.Text != "")
            //{
            //    LoadData();
            //}
		}

		private static bool CheckDate(object obj)
		{           
			string strdate = ((DateEdit)obj).Text;
			bool Flag = clsValidRule.CheckDateFormat(strdate);
			if (!Flag)
			{
				string strMsg;
				if (str_language == "2")
					strMsg = "Data Fromat is Error.";
				else
					strMsg = "輸入的日期有誤！";
				MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				((DateEdit)obj).Focus();
				((DateEdit)obj).SelectAll();
			}
			return Flag;
		}

		private void txtCreate_date1_Leave(object sender, EventArgs e)
		{           
			string strDate = txtCreate_date1.Text;
			if (string.IsNullOrEmpty(strDate))
			{
				return;
			}

			if (CheckDate(sender))
			{
				txtCreate_date2.EditValue = txtCreate_date1.EditValue;
				LoadData();
			}
		}

		private void txtCreate_date2_Leave(object sender, EventArgs e)
		{
			string strDate = txtCreate_date2.Text;
			if (!string.IsNullOrEmpty(strDate))
			{
				if(CheckDate(sender))                
					LoadData();
			}
		}

		private void BTNFIND_Click(object sender, EventArgs e)
		{
			txtRemark.Focus();
			LoadData();
		}

		private void LoadData()
		{
			string strDat1 = txtCreate_date1.Text;
			string strDat2 = txtCreate_date2.Text;            
			if (strDat1!="" && strDat2!="")
			{
				if (strDat1 == strDat2)
				{
					strDat2 = txtCreate_date2.DateTime.AddDays(1).ToString();
					strDat2 = strDat2.Substring(0, 10);
				}                
			}            
		   
			SqlParameter[] paras = new SqlParameter[]
			{
					new SqlParameter("@brand_category1", txtBrand_category1.EditValue),
					new SqlParameter("@brand_category2", txtBrand_category2.EditValue),
					new SqlParameter("@color_category1", txtColor_category1.EditValue),
					new SqlParameter("@color_category2", txtColor_category2.EditValue),
					new SqlParameter("@datum1", txtDatum1.EditValue),
					new SqlParameter("@datum2", txtDatum2.EditValue),
					new SqlParameter("@products_type1", txtProducts_type1.EditValue),
					new SqlParameter("@products_type2", txtProducts_type2.EditValue),
					new SqlParameter("@id1", txtID1.Text),
					new SqlParameter("@id2", txtID2.Text),                    
					new SqlParameter("@pattern_id", txtPattern_id.Text),
					new SqlParameter("@customer_goods", txtCustomer_goods.Text),
					new SqlParameter("@customer_color_id", txtCustomer_color_id.Text),
					new SqlParameter("@remark", txtRemark.Text),
					new SqlParameter("@create_date1", strDat1),
					new SqlParameter("@create_date2", strDat2),                   
					new SqlParameter("@test_item_no", txtTest_item_no.EditValue),
					new SqlParameter("@test_item_name", txtTest_item_name.Text),
					new SqlParameter("@test_item_name_en", txtTest_item_name_en.Text),
					new SqlParameter("@test_report_no", txtTest_report_no.Text),
					new SqlParameter("@effect", txtEffect.Text),
					new SqlParameter("@ref_mo", txtRef_mo.Text),
                    new SqlParameter("@sales_group", txtSales_group.EditValue),
					new SqlParameter("@size", txtSize.Text),
                    new SqlParameter("@cf_color", txtCf_color.Text)
			};
			dtTestStd = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_test_standard_search", paras);
			dgvDetails.DataSource = dtTestStd;
			if (dgvDetails.Rows.Count == 0)
			{
				frmTestStandard.ID_Search = "";
			}
		}

		private void txtEffect_Leave(object sender, EventArgs e)
		{
			string strDate = txtEffect.Text;
			if (!string.IsNullOrEmpty(strDate))
			{
				if (CheckDate(sender))
				{
					LoadData();
				}
			}
		}           

		private void txtTest_item_no_Click(object sender, EventArgs e)
		{
			txtTest_item_no.SelectAll();
		}

		private void txtPattern_id_Leave(object sender, EventArgs e)
		{
			if (txtPattern_id.Text != "")
			{
				LoadData();
			}
		}

		private void txtCustomer_goods_Leave(object sender, EventArgs e)
		{
			if (txtCustomer_goods.Text != "")
			{
				LoadData();
			}
		}

		private void txtCustomer_color_id_Leave(object sender, EventArgs e)
		{
			if (txtCustomer_color_id.Text != "")
			{
				LoadData();
			}
		}

		private void txtRemark_Leave(object sender, EventArgs e)
		{
			if (txtRemark.Text != "")
			{
				LoadData();
			}
		}

		private void txtTest_item_no_Leave(object sender, EventArgs e)
		{
			if (txtTest_item_no.Text != "")
			{
				LoadData();
			}
		}

		private void txtTest_item_name_Leave(object sender, EventArgs e)
		{
			if (txtTest_item_name.Text != "")
			{
				LoadData();
			}
		}

		private void txtTest_report_no_Leave(object sender, EventArgs e)
		{
			if (txtTest_report_no.Text != "")
			{
				LoadData();
			}
		}

		private void txtRef_mo_Leave(object sender, EventArgs e)
		{
			if (txtRef_mo.Text != "")
			{
				LoadData();
			}
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
            SetObjValue.ClearObjValue(panel1.Controls, "1");
			dtTestStd.Clear();
		}

		private void BTNPRINT_Click(object sender, EventArgs e)
		{
			Print();
		}

		private void Print() //通用的打印方法
		{
			if (dgvDetails.RowCount > 0)
			{
				PrintDGV.Print_DataGridView(dgvDetails);
			}
		}

		private void txtBrand_category1_Click(object sender, EventArgs e)
		{
			txtBrand_category1.SelectAll();
		}

		private void txtBrand_category2_Click(object sender, EventArgs e)
		{
			txtBrand_category2.SelectAll();
		}

		private void txtColor_category1_Click(object sender, EventArgs e)
		{
			txtColor_category1.SelectAll();
		}

		private void txtColor_category2_Click(object sender, EventArgs e)
		{
			txtColor_category2.SelectAll();
		}

		private void txtDatum1_Click(object sender, EventArgs e)
		{
			txtDatum1.SelectAll();
		}

		private void txtDatum2_Click(object sender, EventArgs e)
		{
			txtDatum2.SelectAll();
		}

		private void txtProducts_type1_Click(object sender, EventArgs e)
		{
			txtProducts_type1.SelectAll();
		}

		private void txtProducts_type2_Click(object sender, EventArgs e)
		{
			txtProducts_type2.SelectAll();
		}     

		private void BTNEXCEL_Click(object sender, EventArgs e)
		{
			Excel();
		}

		private void Excel()
		{
			if (dgvDetails.RowCount > 0)
			{
				ExpToExcel.DataGridViewToExcel(dgvDetails);
			}
		}
			

		private void dgvDetails_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvDetails.Rows.Count > 0)
			{
				frmTestStandard.ID_Search = dgvDetails.CurrentRow.Cells["customer_test_id"].Value.ToString();
			}
		}

		private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{          
			if (e.ColumnIndex != 12)
			{
				Close();
			}

            //雙擊打開測試報告編號PDF文檔
			if (e.ColumnIndex == 12)
			{
				string strFile = dgvDetails.CurrentRow.Cells["test_report_path"].Value.ToString();
				if (!string.IsNullOrEmpty(strFile))
				{
					strFile = test_public_path + strFile;
					clsTestProductPlan.Open_test_pdf(strFile);
				}
			}
		}

		private void txtTest_item_name_en_Leave(object sender, EventArgs e)
		{
			if (txtTest_item_name_en.Text != "")
			{
				LoadData();
			}
		}

        private void btn_noreport_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
					new SqlParameter("@within_code", "0000")
			};
            dtTestStd = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_test_standard_search_no_report", paras);
            dgvDetails.DataSource = dtTestStd;
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合條件的記錄!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTestStandard.ID_Search = "";
            }
        }

        private void txtSales_group_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
        }

        private void frmTestFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtTestStd.Dispose();
            clsApp = null;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value("frmTestFind", panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
   
	}
}
