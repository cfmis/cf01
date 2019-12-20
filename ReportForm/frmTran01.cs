using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
	public partial class frmTran01 : Form
	{
		clsCommonUse commUse = new clsCommonUse();

		public frmTran01()
		{
			InitializeComponent();
		}

		private void frmTran01_Load(object sender, EventArgs e)
		{
			cmbType1.Items.Add("01-正常轉倉");
			cmbType1.Items.Add("02-尾數轉倉");
			cmbType1.Items.Add("03-轉倉回東莞存放");
			cmbType1.Items.Add("04-客退貨入倉");
			cmbType1.Items.Add("05-轉倉回港存放");
			cmbType1.Items.Add("06-內部轉倉");
			cmbType1.Items.Add("07-內部退倉");
			cmbType1.Items.Add("08-內部提倉單");
			cmbType1.Items.Add("09-車間退料");
			cmbType1.Items.Add("10-庫存調整");
			cmbType1.Items.Add("11-部門移交單");
			BindDataGridView("01");
		}

		private void BTNEXIT_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BTNFIND_Click(object sender, EventArgs e)
		{

			string _type = "";
			string dat1 = "", dat2 = "", chkdat1 = "", chkdat2 = "";
			if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
			{
				if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
				{
					MessageBox.Show("單據日期不正確!");
					this.dateEdit1.Focus();
					return;
				}
				else
				{
					dat1 = this.dateEdit1.Text.ToString();
					dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
				}
			}
			if (clsValidRule.CheckDateIsEmpty(this.dateEdit3.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit4.Text) == false)
			{
				if (clsValidRule.CheckDateFormat(this.dateEdit3.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit4.Text) == false)
				{
					MessageBox.Show("批準日期不正確!");
					this.dateEdit3.Focus();
					return;
				}
				else
				{
					chkdat1 = this.dateEdit3.Text.ToString();
					chkdat2 = Convert.ToDateTime(this.dateEdit4.Text).AddDays(1).ToString("yyyy/MM/dd");
				}
			}
			if (cmbType1.SelectedIndex == -1 || cmbType1.SelectedItem.ToString() == "")
				_type = "01";
			else
				if (cmbType1.SelectedIndex < 9)
					_type = '0' + (cmbType1.SelectedIndex + 1).ToString();
				else
					_type = (cmbType1.SelectedIndex + 1).ToString();

			DataTable dt1 = commUse.getDataProcedure("z_tran01",
				new object[] { _type,textBox1.Text, textBox2.Text, dat1, dat2
				, chkdat1, chkdat2,textBox3.Text, textBox4.Text
				,textBox5.Text, textBox6.Text});
			BindDataGridView(_type);
			dgvDetails.DataSource = dt1;
		}

		private void BTNEXCEL_Click(object sender, EventArgs e)
		{
			ExpToExcel expxls = new ExpToExcel();
			expxls.DvExportToExcel(dgvDetails);
		}

		private void BindDataGridView(string dgvType)
		{
			dgvDetails.Columns.Clear();

			dgvDetails.Columns.Add("id", "單據編號");
			dgvDetails.Columns["id"].DataPropertyName = "id";
			dgvDetails.Columns["id"].Width = 100;
			dgvDetails.Columns.Add("doc_date", "單據日期");
			dgvDetails.Columns["doc_date"].DataPropertyName = "doc_date";
			dgvDetails.Columns.Add("no_type", "單據類型");
			dgvDetails.Columns["no_type"].DataPropertyName = "no_type";
			dgvDetails.Columns["no_type"].Width = 40;
			dgvDetails.Columns.Add("seq", "序號");
			dgvDetails.Columns["seq"].DataPropertyName = "seq";
			dgvDetails.Columns["seq"].Width = 50;
			dgvDetails.Columns.Add("mo", "制單編號");
			dgvDetails.Columns["mo"].DataPropertyName = "mo";
			dgvDetails.Columns.Add("goods_id", "物料編號");
			dgvDetails.Columns["goods_id"].DataPropertyName = "goods_id";
			dgvDetails.Columns["goods_id"].Width = 140;
			dgvDetails.Columns.Add("goods_name", "物料描述");
			dgvDetails.Columns["goods_name"].DataPropertyName = "goods_name";
			dgvDetails.Columns["goods_name"].Width = 240;
			dgvDetails.Columns.Add("qty", "數量");
			dgvDetails.Columns["qty"].DataPropertyName = "qty";
			dgvDetails.Columns.Add("weg", "重量");
			dgvDetails.Columns["weg"].DataPropertyName = "weg";
			dgvDetails.Columns.Add("lot_no", "批號");
			dgvDetails.Columns["lot_no"].DataPropertyName = "lot_no";
			dgvDetails.Columns.Add("floc", "轉出倉");
			dgvDetails.Columns["floc"].DataPropertyName = "floc";
			dgvDetails.Columns["floc"].Width = 60;
			dgvDetails.Columns.Add("tloc", "轉入倉");
			dgvDetails.Columns["tloc"].DataPropertyName = "tloc";
			dgvDetails.Columns["tloc"].Width = 60;
			dgvDetails.Columns.Add("chk_date", "批準日期");
			dgvDetails.Columns["chk_date"].DataPropertyName = "chk_date";
			dgvDetails.Columns.Add("doc_state", "單據狀態");
			dgvDetails.Columns["doc_state"].DataPropertyName = "doc_state";
			dgvDetails.Columns["doc_state"].Width = 40;
			dgvDetails.RowHeadersWidth = 20;
			dgvDetails.ColumnHeadersHeight = 26;
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

		private void dateEdit1_Leave(object sender, EventArgs e)
		{
			dateEdit2.Text = dateEdit1.Text;
		}

		private void dateEdit4_Leave(object sender, EventArgs e)
		{
			dateEdit4.Text = dateEdit3.Text;
		}


	}
}
