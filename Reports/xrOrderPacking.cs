using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using cf01.CLS;
using System.IO;

namespace cf01.Reports
{
    public partial class xrOrderPacking : DevExpress.XtraReports.UI.XtraReport
    {
        public xrOrderPacking()
        {
            InitializeComponent();            
            
        }

        void BindImage()
        {
            // xrPictureBox1.ImageUrl = pFile;
            string art_path = "";
            clsPublicOfGEO clsConErp = new clsPublicOfGEO();
            art_path = clsConErp.getErpImagePath() + GetCurrentColumnValue("picture_name");
            if (File.Exists(art_path))
            {
                xrPictureBox1.ImageUrl = art_path;
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();

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
            //分組
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("mo_id", XRColumnSortOrder.Ascending) });
        }    
              


    }
}
