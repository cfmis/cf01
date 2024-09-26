﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmProcess : Form
    {
        /// <summary>   
    /// 后台线程   
    /// </summary>   
    private BackgroundWorker bkWorker = new BackgroundWorker();  
  
    /// <summary>   
    /// 步进值   
    /// </summary>   
    private int percentValue = 0; 
        
        public frmProcess()
        {
            InitializeComponent();

            bkWorker.WorkerReportsProgress = true;
            bkWorker.WorkerSupportsCancellation = true;
            bkWorker.DoWork += new DoWorkEventHandler(DoWork);
            bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            percentValue = 10;
            this.progressBar1.Maximum = 1000;
            // 执行后台操作   
            bkWorker.RunWorkerAsync();
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            // 事件处理，指定处理函数   
            e.Result = ProcessProgress(bkWorker, e);
        }
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label1.Text = "处理完毕!";
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
                    bkWorker.ReportProgress(i);

                    // 等待，用于UI刷新界面，很重要   
                    System.Threading.Thread.Sleep(1);
                }
            }

            return -1;
        }
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            // bkWorker.ReportProgress 会调用到这里，此处可以进行自定义报告方式   
            this.progressBar1.Value = e.ProgressPercentage;
            int percent = (int)(e.ProgressPercentage / percentValue);
            this.label1.Text = "处理进度:" + Convert.ToString(percent) + "%";
        }
    }
}
