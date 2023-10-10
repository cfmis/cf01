using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.Forms;
using cf01.CLS;
using System.IO;

namespace cf01.ReportForm
{
    public partial class frmLoadStoreDetails : Form
    {
        clsCommonUse commUse = new clsCommonUse();
        public frmLoadStoreDetails()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (chkLoadLocGroup.Checked == false)
            {
                if (txtLocNo.Text == "" && txtPrdMoFrom.Text == "" && txtPrdItemFrom.Text == "" && txtLotNoFrom.Text == "")
                {
                    MessageBox.Show("沒有輸入查詢條件!");
                    return;
                }
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            loadData(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void loadData()
        {
            string userId = DBUtility._user_id;
            int rptType = 0;
            if (chkLoadLocGroup.Checked == true)
                rptType = 1;
            DataTable dt1 = commUse.getDataProcedure("usp_LoadStoreDetails",
                new object[] { rptType,userId,txtLocNo.Text.Trim(),txtPrdMoFrom.Text.Trim(),txtPrdMoTo.Text.Trim(),txtPrdItemFrom.Text.Trim(),txtPrdItemTo.Text.Trim()
                ,txtLotNoFrom.Text.Trim(),txtLotNoTo.Text.Trim()});
            dgvDetails.DataSource = dt1;
            if (dgvDetails.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        /// <summary>
        /// 匯出Excel
        /// </summary>
        private void dgvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();

                //如果匯出到Excel中文變亂碼，可以嘗試改一下這個編碼方式
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));//utf-8

                //Response.Charset = "utf-8";
                //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); 
                string str = " ";

                str += "貨倉編號";
                str += "\t" + "物料編號";
                str += "\t" + "物料描述";
                str += "\t" + "制單編號";
                str += "\t" + "批號";
                str += "\t" + "庫存數量";
                str += "\t" + "庫存重量";
                str += "\t" + "入倉日期";
                sw.WriteLine(str);

                //写内容
                string col_value;
                bool IsWrite = false;  //是否寫入

                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = "";
                    DataGridViewRow dgr = dgvDetails.Rows[rowNo];
                    tempstr += "=\"" + dgr.Cells["colLocNo"].Value.ToString() + "\"";
                    tempstr += "\t" + dgr.Cells["colPrdItem"].Value.ToString();
                    tempstr += "\t" + dgr.Cells["colPrdItemCdesc"].Value.ToString();
                    tempstr += "\t" + dgr.Cells["colPrdMo"].Value.ToString();
                    tempstr += "\t" + "=\"" + dgr.Cells["colLotNo"].Value.ToString() + "\"";
                    tempstr += "\t" + dgr.Cells["colStQty"].Value.ToString();
                    tempstr += "\t" + dgr.Cells["colStWeg"].Value.ToString();
                    tempstr += "\t" + "=\"" + dgr.Cells["colStDat"].Value.ToString() + "\"";
                    sw.WriteLine(tempstr);
                }
                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void btnExpToExcel_Click(object sender, EventArgs e)
        {
            dgvExportExcel();
        }

        private void txtPrdMoFrom_Leave(object sender, EventArgs e)
        {
            txtPrdMoTo.Text = txtPrdMoFrom.Text;
        }

        private void txtLotNoFrom_Leave(object sender, EventArgs e)
        {
            txtLotNoTo.Text = txtLotNoFrom.Text;
        }

        private void txtPrdItemFrom_Leave(object sender, EventArgs e)
        {
            txtPrdItemTo.Text = txtPrdItemFrom.Text;
        }
    }
}
