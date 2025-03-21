﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class xrShippingMark1 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrShippingMark1()
        {
            InitializeComponent();
        }

        void BindImage()
        {
            xrPictureBox1.ImageUrl = GetCurrentColumnValue("picture_name").ToString();           
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();
        }

    }
}
