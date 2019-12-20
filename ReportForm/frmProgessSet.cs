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
    public partial class frmProgessSet : Form
    {
        private BackgroundWorker bkWorker = new BackgroundWorker();
        private frmProgessShow notifyForm = new frmProgessShow();
        public frmProgessSet()
        {
            InitializeComponent();

            // 使用BackgroundWorker时不能在工作线程中访问UI线程部分，   
            // 即你不能在BackgroundWorker的事件和方法中操作UI，否则会抛跨线程操作无效的异常   
            // 添加下列语句可以避免异常。   
            CheckForIllegalCrossThreadCalls = false;

            bkWorker.WorkerReportsProgress = true;
            bkWorker.WorkerSupportsCancellation = true;
            bkWorker.DoWork += new DoWorkEventHandler(DoWork);
            bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        }
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            // 事件处理，指定处理函数   
            e.Result = ProcessProgress(bkWorker, e);
        }
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            // bkWorker.ReportProgress 会调用到这里，此处可以进行自定义报告方式   
            notifyForm.SetNotifyInfo(e.ProgressPercentage, "处理进度:" + Convert.ToString(e.ProgressPercentage) + "%");

            for (int i = 1; i <= 10; i++)
            {
                label1.Text = i.ToString();
            }
        }
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            notifyForm.Close();
            MessageBox.Show("处理完毕!");
        }
        private int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (bkWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    // 状态报告   
                    bkWorker.ReportProgress(i / 10);

                    // 等待，用于UI刷新界面，很重要   
                    System.Threading.Thread.Sleep(1);
                }
            }

            return -1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            notifyForm.StartPosition = FormStartPosition.CenterParent;

            bkWorker.RunWorkerAsync();
            notifyForm.ShowDialog();
        }
    }
}
