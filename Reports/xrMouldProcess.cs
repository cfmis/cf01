using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrMouldProcess : DevExpress.XtraReports.UI.XtraReport
    {
        string user_id = string.Empty;
        public xrMouldProcess(string user)
        {
            InitializeComponent();
            user_id = user;
        }

        private void xrMouldProcess_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組            
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });

            // lblr
            //ange_date.Text = String.Format("入單日期范圍：{0} ~ {1}", m_date_from, m_date_to);
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strFile = GetCurrentColumnValue("picture_name").ToString();
            if (!string.IsNullOrEmpty(strFile))
            {
                if (System.IO.File.Exists(strFile))
                {
                    BindImage(strFile);
                }
                else
                {
                    xrPictureBox1.ImageUrl = null;
                }
            }
            else
            {
                xrPictureBox1.ImageUrl = null;
            }
        }

        void BindImage(string pFile)
        {
            xrPictureBox1.ImageUrl = pFile;
        }

        private void txtUser_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtUser.Text = user_id;
        }

        private void xrLabel33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal plan_qty = decimal.Parse(GetCurrentColumnValue("total_mould_qty").ToString());
            if (plan_qty > 0)
                xrLabel33.Text = string.Format("{0:###,###}", plan_qty);
            else
                xrLabel33.Text = "0";
        }     

        private void txtreceipted_date_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strDate = GetCurrentColumnValue("receipted_date").ToString();
            ConvertDateFormat(txtreceipted_date, strDate);      
        }

        private void chk_is_ban1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string str_is_ban = GetCurrentColumnValue("is_ban").ToString();
            chk_is_ban1.Checked = (str_is_ban == "1") ? true : false;
        }

        private void chk_is_ban2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string str_is_ban = GetCurrentColumnValue("is_ban").ToString();
            chk_is_ban2.Checked = (str_is_ban == "0") ? true : false;
        }

        private void chk_is_annex1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string str_is_annex = GetCurrentColumnValue("is_annex").ToString();
            chk_is_annex1.Checked = (str_is_annex == "1") ? true : false;
        }

        private void chk_is_annex2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string str_is_annex = GetCurrentColumnValue("is_annex").ToString();
            chk_is_annex2.Checked = (str_is_annex == "0") ? true : false;
        }

        private void txtplanfinishdate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strDate = GetCurrentColumnValue("planfinishdate").ToString();
            ConvertDateFormat(txtplanfinishdate, strDate);            
        }

        private void txtrequire_date_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strDate = GetCurrentColumnValue("require_date").ToString();
            ConvertDateFormat(txtrequire_date, strDate);
        }

        private void txtarrive_draw_date_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string strDate = GetCurrentColumnValue("arrive_draw_date").ToString();
            ConvertDateFormat(txtarrive_draw_date, strDate);
        }

        private void ConvertDateFormat(XRLabel obj, string strDate)
        {
            if (!string.IsNullOrEmpty(strDate))
            {
                obj.Text = DateTime.Parse(strDate).Date.ToString("yyyy/MM/dd");
            }
            else
            {
                obj.Text = "";
            }
        }

        private void chkControl_type1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string str_control_type = GetCurrentColumnValue("control_type").ToString();
            chkControl_type1.Checked = (str_control_type == "1") ? true : false;
        }

        private void chkControl_type2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string str_control_type = GetCurrentColumnValue("control_type").ToString();
            chkControl_type2.Checked = (str_control_type == "0") ? true : false;
        }
    }
}
