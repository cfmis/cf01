using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.ReportForm
{
	public partial class frmPlate01 : Form
	{
		public frmPlate01()
		{
			InitializeComponent();
		}

		DataTable dt;
		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.Close();

		}

		private void frmPlate01_Load(object sender, EventArgs e)
		{
			// TODO: 這行程式碼會將資料載入 'sqlDataSet.dsfrmPlate01' 資料表。您可以視需要進行移動或移除。
			//this.dsfrmPlate01TableAdapter.Fill(this.sqlDataSet.dsfrmPlate01);
			this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
			this.reportViewer1.LocalReport.EnableExternalImages = true;
			this.reportViewer1.RefreshReport();
		}

		private void cmdFind_Click(object sender, EventArgs e)
		{
			clsCommonUse c = new clsCommonUse();
			string _type;
			_type = "1";
			if (checkBox1.Checked == true)
				_type = "2";
			if (checkBox2.Checked == true)
				_type = "3";
			dt = c.getDataProcedure("z_plate01",
				new object[] { _type,txtVend1.Text,txtVend2.Text, datPlan1.Text.ToString(), datPlan2.Value.AddDays(1).ToShortDateString()
					,txtId1.Text});
			//dt = c.getDataProcedure("z_plan01", new object[] { "501", "2013/12/10", "2013/07/01", "2013/12/10", "2013/10/01", "2013/12/10", "" });
			this.reportViewer1.LocalReport.DataSources.Clear();
			this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
			//显示报表
			this.reportViewer1.RefreshReport();
		}

		private void txtVend1_Leave(object sender, EventArgs e)
		{
			txtVend2.Text = txtVend1.Text;
		}

		private void checkBox1_Click(object sender, EventArgs e)
		{
			checkBox2.Checked = false;
			this.reportViewer1.LocalReport.ReportPath = "C:\\Projects\\cf01\\cf01\\Reports\\rdlPlate01.rdlc";
			this.reportViewer1.RefreshReport();
		}

		private void checkBox2_Click(object sender, EventArgs e)
		{
			checkBox1.Checked = false;
			this.reportViewer1.LocalReport.ReportPath = "C:\\Projects\\cf01\\cf01\\Reports\\rdlPlate02.rdlc";
			this.reportViewer1.RefreshReport();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
		{
			if (e.Cancel == true)
			{
				string strMessage = e.DeviceInfo;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//PrintDocument printDoc = new PrintDocument();

			//clsPrint print = new clsPrint();
			//// print.PrintStream(this.reportViewer1.LocalReport, printDoc.PrinterSettings.PrinterName);
		}


	}
}
