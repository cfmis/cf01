﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace cf01.Forms
{
    public partial class frmProcessBarWindows : Form
    {
        public frmProcessBarWindows(int _Minimum, int _Maximum,string _Msg)
        {
            InitializeComponent();
            progressBar1.Maximum = _Maximum;//设置范围最大值
            progressBar1.Value = progressBar1.Minimum = _Minimum;//设置范围最小值
            StartPosition = FormStartPosition.CenterScreen;
            Text = _Msg;
        }

        public void setPos(int value)//设置进度条当前进度值
        {
            if (value <= progressBar1.Maximum)//如果值有效
            {
                progressBar1.Value = value;//设置进度值
                
                label1.Text = (value * 100 / progressBar1.Maximum).ToString() + "%";//显示百分比
            }
            Application.DoEvents();//重点，必须加上，否则父子窗体都假死
        }

        private void progressBar_windows_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;//回复父窗体为可用
        }

        private void progressBar_windows_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;//设置父窗体不可用

        }

    }
}
