using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
//using System.IO;
using cf01.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmIqcOp : Form
    {

        public frmIqcOp()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPanl_Click(object sender, EventArgs e)
        {
            if (btnShowPanl.Text == "顯示條件")
            {
                btnShowPanl.Text = "隱藏條件";
                panel2.Visible = true;
            }
            else
            {
                btnShowPanl.Text = "顯示條件";
                panel2.Visible = false;
            }
        }

        private void frmIqcOp_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            mskDat1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            mskDat2.Text = mskDat1.Text;
            txtDept.Text = "501";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
            FindData();
        }

        private void FindData()
        {
            if (mskDat1.Text.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(mskDat1.Text))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat1.Focus();
                    return;
                }
            }

            if (mskDat2.Text.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(mskDat2.Text))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat2.Focus();
                    return;
                }
            }

            if (mskDat1.Text.Trim() == "" && mskDat2.Text.Trim() == "" && txtFindMo1.Text == "" && txtFindMo2.Text == "")
            {
                MessageBox.Show("查詢條件不可為空，請輸入查詢條件!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDat1.Focus();
                return;
            }
            string txt1 = "";
            if (rdbNoCheck.Checked == true)
                txt1 = rdbNoCheck.Text;
            if (rdbIsCheck.Checked == true)
                txt1 = rdbIsCheck.Text;
            lblShowInfo.Text = mskDat1.Text + " 日  " + txt1;
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            LoadData();
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void LoadData()
        {
            string dat1 = "";
            string dat2 = "";
            int is_qc = 0;//未檢
            string mo1 = "", mo2 = "";
            string item1 = "", item2 = "";
            dat1 = mskDat1.Text;
            dat2 = mskDat2.Text;
            mo1 = txtFindMo1.Text;
            mo2 = txtFindMo2.Text;
            item1 = "";
            item2 = "";
            if (dat1.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(dat1))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat1.Focus();
                    return;
                }
            }
            else
                dat1 = "";

            if (dat2.Trim() != "/  /")
            {
                if (!clsValidRule.CheckDateFormat(dat2))
                {
                    MessageBox.Show("日期格有誤，請返回檢查!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskDat2.Focus();
                    return;
                }
                dat2 = Convert.ToDateTime(dat2).AddDays(1).ToString("yyyy/MM/dd");
            }
            else
                dat2 = "";


            if (rdbNoCheck.Checked == true)
                is_qc = 0;
            if (rdbIsCheck.Checked == true)
                is_qc = 1;
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@is_qc", is_qc),
                new SqlParameter("@dep", txtDept.Text),
                new SqlParameter("@dat1", dat1),
                new SqlParameter("@dat2", dat2),
                new SqlParameter("@mo1", mo1),
                new SqlParameter("@mo2", mo2),
                new SqlParameter("@item1", item1),
                new SqlParameter("@item2", item2)
                };
            DataTable dtReport = clsPublicOfPad.ExecuteProcedure("usp_iqc", paras);


            dgvDetails.DataSource = dtReport;
            txtShowRec.Text = dtReport.Rows.Count.ToString();
            if (dtReport.Rows.Count == 0)
                //ShowQcRec(0);
                //else
                //MessageBox.Show("沒有符合條件的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Operation_info("沒有符合條件的數據!");
            else
                setGridColor();

        }

        private void setGridColor()
        {
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if ((i+1)%2==0)
                {
                    dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void timRefresh_Tick(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void btnEnableTime_Click(object sender, EventArgs e)
        {
            //if (btnEnableTime.Text == "開啟自動刷新")
            //{
            //    btnEnableTime.Text = "關閉自動刷新";
            //    timRefresh.Enabled = true;
            //    btnEnableTime.BackColor = Color.DarkTurquoise;
                
            //}
            //else
            //{
            //    btnEnableTime.Text = "開啟自動刷新";
            //    timRefresh.Enabled = false;
            //    btnEnableTime.BackColor = SystemColors.Control;
            //}


            if (timRefresh.Enabled == false)
            {
                //btnEnableTime.Text = "關閉自動刷新";
                timRefresh.Enabled = true;
                btnEnableTime.BackColor = Color.FromArgb(0x00, 0xFF, 0x66);

            }
            else
            {
                //btnEnableTime.Text = "開啟自動刷新";
                timRefresh.Enabled = false;
                btnEnableTime.BackColor = SystemColors.Control;
            }

        }


        private void Operation_info(string msg)//(string msg, Color fore_clr)
        {
            //lblSaveinfo.Text = msg;
            //lblSaveinfo.ForeColor = fore_clr;
            //lblSaveinfo.Visible = true;
            lblShowMsg.Text = msg;
            Delay(1200); // 延時1.2秒
            lblShowMsg.Text = "";
            //lblSaveinfo.Visible = false;
        }
        private void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        private void nupRefTime_ValueChanged(object sender, EventArgs e)
        {
            if (nupRefTime.Text != "")
                timRefresh.Interval = Convert.ToInt32(nupRefTime.Text) * 1000;
        }

    }
}
