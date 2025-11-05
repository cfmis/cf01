using System;
using System.IO;
using cf01.ModuleClass;

namespace cf01.Reports
{
    public partial class xtaWorkPlate : DevExpress.XtraReports.UI.XtraReport
    {
        public xtaWorkPlate()
        {
            InitializeComponent();
        }

        void BindImage()
        {           
            string art_path = GetCurrentColumnValue("picture_name").ToString();
            if (File.Exists(art_path))
            {
                xrPictureBox1.ImageUrl = art_path;
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }
        }

        void CountReturn()
        {
            int counts =int.Parse(GetCurrentColumnValue("count_return").ToString());
            txtCountReturn.Visible = (counts == 0) ? false : true;            
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindImage();           
        }

        private void txtIs_sample_TextChanged(object sender, EventArgs e)
        {
            pnl_is_sample.Visible = (txtIs_sample.Text == "1") ? false : true;            
        }

        private void txtCountReturn_TextChanged(object sender, EventArgs e)
        {
            CountReturn();
        }
    }
}
