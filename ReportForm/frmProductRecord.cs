using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using cf01.CLS;
using System.IO;
using cf01.Reports;
using cf01.Forms;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmProductRecord : Form
    {
        private DataTable dtPrd = new DataTable();
        private clsCommonUse commUse = new clsCommonUse();
        private clsAppPublic clsAppPublic = new clsAppPublic();
        public frmProductRecord()
        {
            InitializeComponent();
        }

        private void frmProductRecord_Load(object sender, EventArgs e)
        {
            //clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            //forminit.GenerateContorl();
            dgvDetails.AutoGenerateColumns = false;
            dgvSummary.AutoGenerateColumns = false;
            dgvPrdWorker.AutoGenerateColumns = false;
            dgvPrd.AutoGenerateColumns = false;
            detDate1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            detDate2.Text = detDate1.Text;
            string localIp = clsAppPublic.GetLocalIP();
            if (localIp.Substring(0, 10) == "192.168.18" || localIp.Substring(0, 10) == "192.168.19")
            {
                rdbJX.Checked = true;
                rdbDG.Enabled = false;
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validData()
        {
            if (clsValidRule.CheckDateIsEmpty(this.detDate1.Text) == false || clsValidRule.CheckDateIsEmpty(this.detDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.detDate1.Text) == false || clsValidRule.CheckDateFormat(this.detDate2.Text) == false)
                {
                    MessageBox.Show("生產日期不正確!");
                    this.detDate1.Focus();
                    return false;
                }
            }
            return true;
        }
        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtMac2.Focus();
            if (!validData())
                return;
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            findData();
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

        }
        private void findData()
        {
            clsCommonUse commUse = new clsCommonUse();

            int rpt_type = tc1.SelectedIndex;//報表類型
            string source_type = "DG";
            if (rdbJX.Checked == true) 
                source_type = "JX";
            string date_from = detDate1.Text.ToString();
            string date_to = detDate2.Text.ToString();
            string dep_from = txtFdep.Text.Trim();
            string dep_to = txtTdep.Text.Trim();
            string mo_from = textMo1.Text.Trim();
            string mo_to = textMo2.Text.Trim();
            string mac_from = txtMac1.Text.Trim();
            string mac_to = txtMac2.Text.Trim();
            string work_from = txtWorkType1.Text.Trim();
            string work_to = txtWorkType2.Text.Trim();
            string group_from = txtGroup1.Text.Trim();
            string group_to = txtGroup2.Text.Trim();
            int complete_state = 1;//已完成
            if (rdbNotComp.Checked == true)//未完成
                complete_state = 0;
            else if (rdbAll.Checked == true)//全部
                complete_state = 2;
            
            SqlParameter[] parameters = { new SqlParameter("@rpt_type", rpt_type)
                        ,new SqlParameter("@source_type", source_type)
                        ,new SqlParameter("@date_from", date_from),new SqlParameter("@date_to", date_to)
                        ,new SqlParameter("@dep_from", dep_from),new SqlParameter("@dep_to", dep_to)
                        ,new SqlParameter("@mo_from", mo_from), new SqlParameter("@mo_to", mo_to)
                        , new SqlParameter("@mac_from", mac_from), new SqlParameter("@mac_to", mac_to)
                        , new SqlParameter("@work_from", work_from), new SqlParameter("@work_to", work_to)
                        , new SqlParameter("@group_from", group_from), new SqlParameter("@group_to", group_to)
                        , new SqlParameter("@complete_state", complete_state)
                };
            clsPublicOfPad clsConPad = new clsPublicOfPad();
            //////儲存過程  usp_LoadProductionRecords 在 dgsql2.dgcf_pad  和 lnsql1.dgcf_pad 中都有的，要同時修改兩邊的
            dtPrd = clsConPad.ExecuteProcedureReturnTableConn("usp_LoadProductionRecords", parameters);

            if (rpt_type == 0)
                dgvDetails.DataSource = dtPrd;
            else if (rpt_type == 1)
                dgvSummary.DataSource = dtPrd;
            else if (rpt_type == 2)
                dgvPrdWorker.DataSource = dtPrd;
            else
                dgvPrd.DataSource = dtPrd;

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            txtTdep.Text = txtFdep.Text;
            string fDep = txtFdep.Text;
            if (fDep == "122" || fDep == "124" || fDep == "322"
                || fDep == "J07" || fDep == "104" || fDep == "J01" || fDep == "J03" || fDep == "128" || fDep == "J05" || fDep == "127")
            {
                rdbJX.Checked = true;
                rdbDG.Checked = false;
            }
            else
            {
                rdbDG.Checked = true;
                rdbJX.Checked = false;
            }
                
        }

        private void dateEdit1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textMo1_Leave(object sender, EventArgs e)
        {
            textMo2.Text = textMo1.Text;
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }

        /// <summary>
        /// 用工作流導出Excel
        /// </summary>
        private void DvExportExcel()
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                int rpt_type = tc1.SelectedIndex;//報表類型
                if (rpt_type==0)//明細表
                {
                    //写标题
                    for (int i = 0; i < dgvDetails.ColumnCount; i++)
                    {
                        str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                        str += "\t";
                    }
                    sw.WriteLine(str);
                    //写内容
                    string col_value;
                    for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                    {
                        string tempstr = " ";
                        for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                        {
                            if (dgvDetails.Columns[columnNo].Name == "colPrd_date"
                                || dgvDetails.Columns[columnNo].Name == "colTransfer_time"
                                || dgvDetails.Columns[columnNo].Name == "colPrd_pdate"
                                || dgvDetails.Columns[columnNo].Name == "colCrtim"
                                || dgvDetails.Columns[columnNo].Name == "colAmtim"
                                || dgvDetails.Columns[columnNo].Name == "colSeq")
                                col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value + "\"";
                            else
                                col_value = clsUtility.FormatNullableString(dgvDetails.Rows[rowNo].Cells[columnNo].Value);
                            tempstr += col_value;
                            tempstr += "\t";
                        }
                        sw.WriteLine(tempstr);
                    }
                }else//匯總表
                {
                    DataGridView dgvObj = new DataGridView();
                    if (rpt_type == 1)//按工作類型匯總
                        dgvObj = dgvSummary;
                    else if (rpt_type == 2)//按工號統計
                        dgvObj = dgvPrdWorker;
                    else
                        dgvObj = dgvPrd;
                    //写标题
                    for (int i = 0; i < dgvObj.ColumnCount; i++)
                    {
                        str += dgvObj.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                        str += "\t";
                    }
                    sw.WriteLine(str);
                    //写内容
                    string col_value;
                    for (int rowNo = 0; rowNo < dgvObj.RowCount; rowNo++)
                    {
                        string tempstr = " ";
                        for (int columnNo = 0; columnNo < dgvObj.ColumnCount; columnNo++)
                        {
                            col_value = clsUtility.FormatNullableString(dgvObj.Rows[rowNo].Cells[columnNo].Value);
                            tempstr += col_value;
                            tempstr += "\t";
                        }
                        sw.WriteLine(tempstr);
                    }
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void txtFdep_TextChanged(object sender, EventArgs e)
        {
            txtTdep.Text = txtFdep.Text;
        }

        private void textMo1_TextChanged(object sender, EventArgs e)
        {
            textMo2.Text = textMo1.Text;
        }

        private void txtMac1_TextChanged(object sender, EventArgs e)
        {
            txtMac2.Text = txtMac1.Text;
        }

        private void detDate1_TextChanged(object sender, EventArgs e)
        {
            detDate2.Text = detDate1.Text;
        }

        private void txtWorkType1_TextChanged(object sender, EventArgs e)
        {
            txtWorkType2.Text = txtWorkType1.Text;
        }

        private void txtGroup1_TextChanged(object sender, EventArgs e)
        {
            txtGroup2.Text = txtGroup1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printReport(1);//打印
        }
        private void printReport(int print_type)
        {
            xtaProductRecord xr = new xtaProductRecord(dtPrd);
            xr.DataSource = dtPrd;
            if (print_type==0)    //判斷是預覽 Or 打印
            {
                xr.ShowPreviewDialog();
            }
            else
            {
                xr.Print();
                //xr.ShowDesigner();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            printReport(0);//打印
        }

        private void btnExpSelectGoods_Click(object sender, EventArgs e)
        {
            if (!validData())
                return;



            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();


            //Thread thread = new Thread(new ThreadStart(StartSomeWorkFromUIThread));
            //thread.IsBackground = true;
            //thread.Start();
            DataTable dt = find_data();
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            DtExportExcel(dt);
        }

        private DataTable find_data()
        {

            string dat1 = "", dat2 = "";
            int compl_flag = 3;
            int rpt_type = 0;//明細表
            if (rdbSumByVend.Checked == true)//按供應商統計次品數
                rpt_type = 1;
            if (clsValidRule.CheckDateIsEmpty(this.detDate1.Text) == false)
                dat1 = this.detDate1.Text;
            if (clsValidRule.CheckDateIsEmpty(this.detDate2.Text) == false)
                dat2 = Convert.ToDateTime(this.detDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            if(rdbIsComp.Checked==true)
                compl_flag = 0;
            if (rdbNotComp.Checked == true)
                compl_flag = 1;
            DataTable dt = commUse.getDataProcedure("usp_SelectOutsideGoods",
                new object[] { rpt_type,txtFdep.Text.Trim(), txtTdep.Text.Trim(), dat1, dat2, compl_flag });

            return dt;
            
        }


        /// <summary>
        /// 用工作流導出Excel
        /// </summary>
        private void DtExportExcel(DataTable dt)
        {
            int rpt_type = 0;//明細表
            if (rdbSumByVend.Checked == true)//按供應商統計次品數
                rpt_type = 1;
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
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                if (rpt_type == 0)//明細表
                {
                    str = "制單編號";
                    str += "\t" + "物料編號";
                    str += "\t" + "物料描述";
                    str += "\t" + "開始時間";
                    str += "\t" + "結束時間";
                    str += "\t" + "正常班時間";
                    str += "\t" + "加班時間";
                    str += "\t" + "生產數量";
                    str += "\t" + "生產重量";
                    str += "\t" + "標準編碼";
                    str += "\t" + "標準編碼描述";
                    str += "\t" + "良品數量";
                    str += "\t" + "良品重量";
                    str += "\t" + "不良品數量";
                    str += "\t" + "不良品重量";
                    str += "\t" + "次品描述";
                    str += "\t" + "工號";
                    str += "\t" + "組別";
                    str += "\t" + "工作類型";
                    str += "\t" + "類型描述";
                    str += "\t" + "供應商";
                    str += "\t" + "供應商描述";
                    str += "\t" + "部門";
                    str += "\t" + "生產日期";
                    sw.WriteLine(str);
                    //写内容
                    for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
                    {
                        string tempstr = " ";
                        DataRow dw = dt.Rows[rowNo];
                        tempstr += dw["prd_mo"];
                        tempstr += "\t" + dw["prd_item"];
                        tempstr += "\t" + dw["goods_name"];
                        tempstr += "\t" + dw["prd_start_time"];
                        tempstr += "\t" + dw["prd_end_time"];
                        tempstr += "\t" + dw["prd_normal_time"];
                        tempstr += "\t" + dw["prd_ot_time"];
                        tempstr += "\t" + dw["prd_qty"];
                        tempstr += "\t" + dw["prd_weg"];
                        tempstr += "\t" + dw["work_code"];
                        tempstr += "\t" + dw["job_desc"];
                        tempstr += "\t" + dw["ok_qty"];
                        tempstr += "\t" + dw["ok_weg"];
                        tempstr += "\t" + dw["no_ok_qty"];
                        tempstr += "\t" + dw["no_ok_weg"];
                        tempstr += "\t" + dw["defective_cdesc"];
                        tempstr += "\t" + dw["prd_worker"];
                        tempstr += "\t" + dw["prd_group"];
                        tempstr += "\t" + dw["prd_work_type"];
                        tempstr += "\t" + dw["work_type_desc"];
                        tempstr += "\t" + dw["vend"];
                        tempstr += "\t" + dw["vend_cname"];
                        tempstr += "\t" + dw["prd_dep"];
                        tempstr += "\t" + "=\"" + dw["prd_date"] + "\"";
                        sw.WriteLine(tempstr);
                    }
                }
                else//按供應商統計次品數
                {
                    str = "供應商編號";
                    str += "\t" + "供應商描述";
                    str += "\t" + "次品編號";
                    str += "\t" + "次品描述";
                    str += "\t" + "總單數";
                    str += "\t" + "單數數";
                    str += "\t" + "占總單百分比";
                    sw.WriteLine(str);
                    //写内容
                    for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
                    {
                        string tempstr = " ";
                        DataRow dw = dt.Rows[rowNo];
                        tempstr += dw["vend"];
                        tempstr += "\t" + dw["vend_cname"];
                        tempstr += "\t" + dw["defective_id"];
                        tempstr += "\t" + dw["defective_cdesc"];
                        tempstr += "\t" + dw["rec"];
                        tempstr += "\t" + dw["e_rec"];
                        tempstr += "\t" + dw["rec_per"];
                        sw.WriteLine(tempstr);
                    }
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

    }
}
