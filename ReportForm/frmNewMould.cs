using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using cf01.Forms;
using System.Threading;
using cf01.Reports;
using cf01.ModuleClass;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmNewMould : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private DataTable dtDepartment;
        public static string str_language = "0";
        public frmNewMould()
        {
            InitializeComponent();
            str_language = DBUtility._language;

            clsControlInfoHelper oMutilang = new clsControlInfoHelper(this.Name, this.Controls);
            oMutilang.GenerateContorl();
        }



        private void deCheck_Date1_Leave(object sender, EventArgs e)
        {
            string strdate = deCheck_Date1.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
            if (deCheck_Date2.EditValue == null)
            {
                deCheck_Date2.EditValue = deCheck_Date1.EditValue;
            }
        }

        private void deCheck_Date2_Leave(object sender, EventArgs e)
        {
            string strdate = deCheck_Date2.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
            if (deCheck_Date2.EditValue == null)
            {
                deCheck_Date2.EditValue = deCheck_Date1.EditValue;
            }
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDept1.Text))
            {
                txtDept2.Text = txtDept1.Text;
            }
        }

        private static void CheckDate(object obj, string strdate)
        {
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg = "輸入的日期有誤！";
                if (str_language == "2")
                {
                    strMsg = "Data Fromat is Error.";
                }
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void frmNewMould_Load(object sender, EventArgs e)
        {
            string strsql = "Select id,name from dbo.cd_department Where within_code='0000' and dept_type='M'";
            dtDepartment = clsConErp.GetDataTable(strsql);

            DataRow row = dtDepartment.NewRow();
            dtDepartment.Rows.Add(row);
            dtDepartment.DefaultView.Sort = "id ASC";
            dtDepartment = dtDepartment.DefaultView.ToTable();


            //爲下拉表表框綁定數據          
            txtDept1.Properties.DataSource = dtDepartment;
            txtDept1.Properties.ValueMember = "id";
            txtDept1.Properties.DisplayMember = "id";
            txtDept2.Properties.DataSource = dtDepartment;
            txtDept2.Properties.ValueMember = "id";
            txtDept2.Properties.DisplayMember = "id";

            deCheck_Date2.EditValue = DateTime.Now;
            deCheck_Date1.EditValue = DateTime.Now.AddDays(-6);

            txtDept1.EditValue = "P20";
            txtDept2.EditValue = "P20";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDept1.Text) && String.IsNullOrEmpty(txtDept2.Text) && String.IsNullOrEmpty(deCheck_Date1.Text) && String.IsNullOrEmpty(deCheck_Date2.Text))
            {
                string strMsg = "查詢條件不可爲空";
                if (str_language == "2")
                {
                    strMsg = "The query cannot be empty.";
                }
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //************************
            Load_data(); //数据处理
            //************************

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

        }

        private void Load_data()
        {
            string sql = "SELECT DISTINCT A.id, A.mould_no,A.draw_ver,convert(char(10),A.check_date,120) as check_date,B.dept_id,substring(B.mould_no,5,7) as art_id,C.name,MD.brand_no,(cc.picture_path+'\\'+AT.picture_name) AS picture_name " +
             " FROM (select within_code,id,mould_no,MAX(check_date) as check_date,MAX(ver) as ver,MAX(draw_ver) AS draw_ver from dbo.so_mould_notice_mostly with(nolock) Where state='1' group by within_code,id,mould_no) A " +
             " INNER JOIN dbo.so_mould_notice_details B with(nolock) on A.within_code =B.within_code AND A.id=B.id AND A.ver =B.ver" +
             " INNER JOIN dbo.cd_department C ON B.within_code =C.within_code AND B.dept_id =C.id AND C.dept_type='M' " +
             " INNER JOIN (select within_code,id,max(ver) AS ver,max(brand_no) as brand_no from dbo.so_draw_master with(nolock) where state ='1' group by within_code,id ) MD " +
             "         ON A.within_code =MD.within_code AND A.mould_no =MD.id " +
             " Left outer join (Select id,max(picture_name) as picture_name from dbo.cd_pattern_details with(nolock) " +
             "                 Where within_code='0000' and picture_name is not null AND application_scope ='1' group by id ) AT ON substring(B.mould_no,5,7) =AT.id " +
             " inner join dbo.cd_company cc on A.within_code =cc.within_code " +
             " WHERE A.within_code ='0000' ";



            if (deCheck_Date1.Text != "")
            {
                sql += String.Format(" AND A.check_date>='{0}'", deCheck_Date1.Text.Trim());
            }
            if (deCheck_Date2.Text != "")
            {
                //日期加1
                string dat2 = Convert.ToDateTime(this.deCheck_Date2.Text).AddDays(1).ToString("yyyy/MM/dd");
                sql += String.Format(" AND A.check_date<='{0}'", dat2);
            }
            if (txtDept1.Text != "")
            {
                sql += String.Format(" AND B.dept_id>='{0}'", txtDept1.Text.Trim());
            }
            if (txtDept2.Text != "")
            {
                sql += String.Format(" AND B.dept_id<='{0}'", txtDept2.Text.Trim());
            }
            sql += " ORDER BY B.dept_id,Convert(char(10),A.check_date,120),A.id ";
            DataTable dtMould = clsConErp.GetDataTable(sql);


            //顯示報表
            if (dtMould.Rows.Count == 0)
            {
                string strMsg = "查詢不到符合條件的數據!";
                if (str_language == "2")
                {
                    strMsg = "Query does not meet the requirements of the data.";
                }
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dtMould.DefaultView.Sort = "dept_id,check_date,id";  //排序             
                return;
            }

            //加載報表
            xrNewMould mMyRepot = new xrNewMould() { DataSource = dtMould };
            mMyRepot.ShowPreview();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
