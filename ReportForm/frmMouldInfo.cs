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
using System.Threading;
using cf01.Forms;
using cf01.Reports;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmMouldInfo : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public static string str_language = "0";
        DataTable dtReport;
        public frmMouldInfo()
        {
            str_language = DBUtility._language;
            InitializeComponent();
            this.gridView1.IndicatorWidth = 40;
        }

        private void frmMouldInfo_Load(object sender, EventArgs e)
        {
            DataTable dtDept = clsConErp.GetDataTable("SELECT id,name FROM cd_department WHERE within_code ='0000' AND dept_type='M'");
            //爲下拉列表框中加一空行            
            DataRow row1 = dtDept.NewRow();
            dtDept.Rows.Add(row1);
            dtDept.DefaultView.Sort = "id ASC";//排序
            dtDept = dtDept.DefaultView.ToTable();//排序後重新賦值

            txtDept1.Properties.DataSource = dtDept;   //牌子
            txtDept1.Properties.ValueMember = "id";
            txtDept1.Properties.DisplayMember = "id";

            txtDept2.Properties.DataSource = dtDept;   //牌子
            txtDept2.Properties.ValueMember = "id";
            txtDept2.Properties.DisplayMember = "id";

        }

        private void txtDate1_Leave(object sender, EventArgs e)
        {
            string strdate = txtDate1.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
            if (txtDate2.EditValue == null)
            {
                txtDate2.EditValue = txtDate1.EditValue; //只能用EditValue屬性,用Text會產生奇怪的值            
            }
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept1.Text))
            {
                txtDept2.Text = txtDept1.Text;
            }
        }

        private static void CheckDate(object obj, string strdate)
        {
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Data Fromat is Error.";
                else
                    strMsg = "輸入的日期有誤！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDept1.Text) && String.IsNullOrEmpty(txtDept2.Text))
            {
                MessageBox.Show("部門不可爲空！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrEmpty(txtDate1.Text) && String.IsNullOrEmpty(txtDate2.Text))
            {
                MessageBox.Show("日期不可爲空！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            Load_data(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtReport.Rows.Count == 0)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Can not find qualified data.";
                else
                    strMsg = "沒有符合條的數據！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gridControl1.DataSource = dtReport;
            //加載報表
            xrMouldInfo mMyRepot = new xrMouldInfo() { DataSource = dtReport };
            mMyRepot.ShowPreview();


        }
        private void Load_data()
        {
            clsCommonUse c = new clsCommonUse();
            dtReport = c.getDataProcedure("z_mould_info", new object[] { txtDept1.Text, txtDept2.Text, txtDate1.Text, txtDate2.Text });

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Title = "导出Excel", Filter = "Excel文件(*.xls)|*.xls" };
                DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    gridControl1.ExportToXls(saveFileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }


    }
}
