using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace cf01.Reports
{
    public partial class xrMould_Process : DevExpress.XtraReports.UI.XtraReport
    {
        public xrMould_Process()
        {
            InitializeComponent();
        }

        private void xrMould_Process_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //分組
            //GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending), new GroupField("no", XRColumnSortOrder.Ascending) });
            GroupHeader1.GroupFields.AddRange(new GroupField[] { new GroupField("id", XRColumnSortOrder.Ascending) });           
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

        private static string GetDateTimeString(string strDateTime)
        {
            string ls_dt = Convert.ToDateTime(strDateTime).ToString("yyyy/MM/dd HH:ss");
            return ls_dt;
        }
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("sample_yes").ToString() == "True")
                chksample_yes.Checked = true;
            else
                chksample_yes.Checked = false;
            if (GetCurrentColumnValue("sample_no").ToString() == "True")
                chksample_no.Checked = true;
            else
                chksample_no.Checked = false;
            if (GetCurrentColumnValue("md_new").ToString() == "True")
                chkmd_new.Checked = true;
            else
                chkmd_new.Checked = false;
            if (GetCurrentColumnValue("md_reproduced").ToString() == "True")
                chkmd_reproduced.Checked = true;
            else
                chkmd_reproduced.Checked = false;
            
            
            //萬能機
            string ls_datetime = GetCurrentColumnValue("universal_machine_receive").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_wn_dept.Text = ls_datetime.Substring(5, 2);
                txtdd_wn_dept.Text = ls_datetime.Substring(8, 2);
                txthh_wn_dept.Text = ls_datetime.Substring(11, 2);
                txtmin_wn_dept.Text = ls_datetime.Substring(14, 2);
            }
            ls_datetime = GetCurrentColumnValue("universal_machine_md_receive").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_wn_md.Text = ls_datetime.Substring(5, 2);
                txtdd_wn_md.Text = ls_datetime.Substring(8, 2);
                txthh_wn_md.Text = ls_datetime.Substring(11, 2);
                txtmin_wn_md.Text = ls_datetime.Substring(14, 2);
            }
            ls_datetime = GetCurrentColumnValue("universal_machine_test").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_wn_test.Text = ls_datetime.Substring(5, 2);
                txtdd_wn_test.Text = ls_datetime.Substring(8, 2);
                txthh_wn_test.Text = ls_datetime.Substring(11, 2);
                txtmin_wn_test.Text = ls_datetime.Substring(14, 2);
            }
            ls_datetime = GetCurrentColumnValue("universal_machine_confirm").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_wn_confirm.Text = ls_datetime.Substring(5, 2);
                txtdd_wn_confirm.Text = ls_datetime.Substring(8, 2);
                txthh_wn_confirm.Text = ls_datetime.Substring(11, 2);
                txtmin_wn_confirm.Text = ls_datetime.Substring(14, 2);
            }
            //雞眼
            ls_datetime = GetCurrentColumnValue("eye_machine_receive").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_eye_dept.Text = ls_datetime.Substring(5, 2);
                txtdd_eye_dept.Text = ls_datetime.Substring(8, 2);
                txthh_eye_dept.Text = ls_datetime.Substring(11, 2);
                txtmin_eye_dept.Text = ls_datetime.Substring(14, 2);
            }
            ls_datetime = GetCurrentColumnValue("eye_machine_md_receive").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_eye_md.Text = ls_datetime.Substring(5, 2);
                txtdd_eye_md.Text = ls_datetime.Substring(8, 2);
                txthh_eye_md.Text = ls_datetime.Substring(11, 2);
                txtmin_eye_md.Text = ls_datetime.Substring(14, 2);
            }
            ls_datetime = GetCurrentColumnValue("eye_machine_test").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_eye_test.Text = ls_datetime.Substring(5, 2);
                txtdd_eye_test.Text = ls_datetime.Substring(8, 2);
                txthh_eye_test.Text = ls_datetime.Substring(11, 2);
                txtmin_eye_test.Text = ls_datetime.Substring(14, 2);
            }
            ls_datetime = GetCurrentColumnValue("eye_machine_confirm").ToString();
            if (ls_datetime != "")
            {
                ls_datetime = GetDateTimeString(ls_datetime);
                txtmm_eye_confirm.Text = ls_datetime.Substring(5, 2);
                txtdd_eye_confirm.Text = ls_datetime.Substring(8, 2);
                txthh_eye_confirm.Text = ls_datetime.Substring(11, 2);
                txtmin_eye_confirm.Text = ls_datetime.Substring(14, 2);
            }
        }

    }
}
