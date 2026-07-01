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

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            pnlQc.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("qc_dept").ToString().Trim()) ? false : true;
            pnlHold.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("flag_hold").ToString().Trim()) ? false : true;
            pnlShadingColor.Visible = string.IsNullOrEmpty(GetCurrentColumnValue("shading_color").ToString().Trim()) ? false : true;

            //2026/07/01 Allen Leung
            string wp_id = GetCurrentColumnValue("wp_id").ToString();
            string next_wp_id = GetCurrentColumnValue("next_wp_id").ToString();
            string wh = "";
            if (next_wp_id.Substring(0, 1) == "8" || wp_id.Substring(0, 1) == "8" )
                wh = next_wp_id.Substring(0, 1) == "8" ? next_wp_id: wp_id ;
            else
                wh = "";
            if (wh == "")
                txtLocation.Text = "貨  架:";
            else
                txtLocation.Text = $"{wh}倉貨架:";

        }
    }
}
