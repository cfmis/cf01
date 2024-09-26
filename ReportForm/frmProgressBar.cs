using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ReportForm
{
	public partial class frmProgressBar : Form
	{
		private BackgroundWorker _backgroundWorker1; //frmProgressBar 窗体事件(进度条窗体)

		public frmProgressBar(BackgroundWorker backgroundWorker1)
		{
			InitializeComponent();
			
			this._backgroundWorker1 = backgroundWorker1;
			this._backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
			this._backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.progressBar1.Value = e.ProgressPercentage;
			this.lblMessage.Text = e.UserState.ToString(); //主窗体传过来的值，通过e.UserState.ToString()来接受
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Close();
		}

	}
}
