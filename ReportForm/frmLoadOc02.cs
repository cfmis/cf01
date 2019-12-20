using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.Forms;
using cf01.CLS;
using System.Threading;

namespace cf01.ReportForm
{
	public partial class frmLoadOc02 : Form
	{
		ExpToExcel ExportExcel = new ExpToExcel();

		string lang_id = DBUtility._language;
		string user_id = DBUtility._user_id;
		
		clsCommonUse commUse = new clsCommonUse();

		public frmLoadOc02()
		{
			InitializeComponent();
		}

		private void cmdExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdFind_Click(object sender, EventArgs e)
		{
			string dat1 = "", dat2 = "";
			if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
			{
				if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
				{
					MessageBox.Show("訂單日期不正確!");
					this.dateEdit1.Focus();
					return;
				}
				else
				{
					dat1 = this.dateEdit1.Text.ToString();
					dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
				}
			}

			//顯示查詢進度圖片
			frmProgress wForm = new frmProgress();
			new Thread((ThreadStart)delegate
			{
				wForm.TopMost = true;
				wForm.ShowDialog();
			}).Start();


			DataTable dt = commUse.getDataProcedure("z_load_oc02",
				new object[] { lang_id,user_id,textBox1.Text, textBox2.Text, dat1, 
					dat2,textBox3.Text, textBox4.Text,textBox5.Text, textBox6.Text});
			dgvDetails.DataSource = dt;
			//結束查詢進度圖片
			wForm.Invoke((EventHandler)delegate { wForm.Close(); });

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (dt.Rows[i]["custname"].ToString() == "Sub-Total" || dt.Rows[i]["custname"].ToString() == "Sum-Total")
				{
					dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
				}
			}
			dgvDetails.Refresh();
		}
		private void frmLoadOc02_Load(object sender, EventArgs e)
		{
			this.Text = "Oorder Search By Brand";
			//BuilLabel("frmloadoc02_label", DBUtility._language);

			MyInitForm forminit = new MyInitForm();
			forminit.SetForm(this.Name, this.Controls, "frmloadoc02_label");
			
			//綁定表格
			commUse.BuilDataGridView(dgvDetails, "frmloadoc02_grid1", lang_id);
			//BindDataGridView();
			dateEdit1.Text  = System.DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");
			dateEdit2.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
		}

		private void cmdExp_Click(object sender, EventArgs e)
		{
			frmProgress wForm = new frmProgress();
			new Thread((ThreadStart)delegate
			{
				wForm.TopMost = true;
				wForm.ShowDialog();
			}).Start();

			//**********************
			ExportExcel.SaveToExcel(dgvDetails, null);
			//**********************
			wForm.Invoke((EventHandler)delegate { wForm.Close(); });

		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			textBox2.Text = textBox1.Text;
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			textBox4.Text = textBox3.Text;
		}

		private void textBox5_Leave(object sender, EventArgs e)
		{
			textBox6.Text = textBox5.Text;
		}
		private void btnFindBrand_Click(object sender, EventArgs e)
		{
			ReportForm.frmFindDataBase frmBrand = new ReportForm.frmFindDataBase(btnFindBrand.Name);
			//ReportForm.frmLoadBrand frmBrand = new ReportForm.frmLoadBrand();
			frmBrand.Owner = this;
			frmBrand.ShowDialog();
			textBox1.Text = DBUtility.get_query_id;
			textBox2.Text = DBUtility.get_query_id;
		}

		private void btnFindCustomer_Click(object sender, EventArgs e)
		{
			//ReportForm.frmLoadCust frmCust = new ReportForm.frmLoadCust();
			ReportForm.frmFindDataBase frmCust = new ReportForm.frmFindDataBase(btnFindCustomer.Name);
			frmCust.Owner = this;
			frmCust.ShowDialog();
			textBox3.Text = DBUtility.get_query_id;
			textBox4.Text = DBUtility.get_query_id;
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";

			textBox1.Focus();
		}

		private void dateEdit1_Leave(object sender, EventArgs e)
		{
			dateEdit2.Text = dateEdit1.Text;
		}



	}
}
