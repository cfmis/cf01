﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrOut_process_out_s3 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrOut_process_out_s3()
        {
            InitializeComponent();            
            lblPack_num.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty.DataBindings.Add("Text", DataSource, "sec_qty");

            lblPackag_num_total.DataBindings.Add("Text", DataSource, "package_num");//小計欄位需這樣綁定
            lblProd_qty_total.DataBindings.Add("Text", DataSource, "prod_qty");
            lblSec_qty_total.DataBindings.Add("Text", DataSource, "sec_qty");
        }

        void BindImage(string pFile)
        {
            xrPictureBox1.ImageUrl = pFile;
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //string strFile = GetCurrentColumnValue("picture_name").ToString();
            //if (!string.IsNullOrEmpty(strFile))
            //{
            //    if (System.IO.File.Exists(strFile))
            //    {
            //        BindImage(strFile);
            //    }
            //    else
            //    {                   
            //        xrPictureBox1.ImageUrl = null ;
            //    }
            //}
            //else
            //{
            //    xrPictureBox1.ImageUrl = null ;
            //}
           
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //多于一個字段分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });
            //GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("vendor_id", XRColumnSortOrder.Ascending), new GroupField("issue_date", XRColumnSortOrder.Ascending) });
        }             


    }
}
