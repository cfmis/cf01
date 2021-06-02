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
            if(rdbSummary.Checked==true)
            {
                dgvDetails.Visible = false;
                dgvSummary.Visible = true;
            }
            else
            {
                dgvDetails.Visible = true;
                dgvSummary.Visible = false;
            }
        }
        private void findData()
        {
            string strSql = "";
            int rpt_type = 1;
            if (rdbDetails1.Checked == true)
                rpt_type = 0;
            strSql += " Select a.prd_id,a.prd_dep,a.prd_pdate,a.prd_date,a.prd_mo,a.prd_item,a.prd_qty,a.prd_weg,a.prd_machine" +
                ",a.prd_work_type,b.work_type_desc,substring(a.prd_worker, 6, 5) AS prd_worker, a.prd_class" +
                ",a.Work_code,a.Difficulty_level,a.Speed_lever,a.Job_type,c.job_desc,a.Start_run,a.End_run,a.Prd_Run_qty" +
                ",a.prd_group,a.prd_start_time,a.prd_end_time,a.prd_normal_time,a.prd_ot_time,a.line_num,a.hour_run_num,a.hour_std_qty" +
                ",a.crusr,CONVERT(varchar(100), a.crtim, 120) AS crtim, a.amusr,CONVERT(varchar(100), a.amtim, 120) AS amtim" +
                ", e.hrm1name AS prd_worker_name";
            strSql += " INTO #tb_prd00 ";
            
            if(rdbJX.Checked==true)//JX
                strSql += " From lnsql1.dgcf_pad.dbo.product_records a " +
                    " Left Join lnsql1.dgcf_pad.dbo.work_type b on a.prd_work_type = b.work_type_id " +
                    " Left Join lnsql1.dgcf_pad.dbo.job_type c ON a.job_type = c.job_type AND a.prd_dep = c.dep " +
                    " Left Join lnfs1.hr_db.dbo.hrm01 e ON a.prd_worker COLLATE Chinese_Taiwan_Stroke_CI_AS = e.hrm1wid ";
            else//DG
                strSql += " From product_records a " +
                        " Left Join work_type b on a.prd_work_type = b.work_type_id " +
                        " Left Join job_type c ON a.job_type = c.job_type AND a.prd_dep = c.dep " +
                        " Left Join dgsql1.dghr.dbo.hrm01 e ON a.prd_worker COLLATE Chinese_Taiwan_Stroke_CI_AS = e.hrm1wid ";
            strSql += " WHERE a.prd_dep>''";
            if (clsValidRule.CheckDateIsEmpty(this.detDate1.Text) == false)
                strSql += " and a.prd_date >= '" + this.detDate1.Text.ToString() + "'";
            if (clsValidRule.CheckDateIsEmpty(this.detDate2.Text) == false)
                strSql += " and a.prd_date <= '" + this.detDate2.Text.ToString() + "'";
            if (txtFdep.Text.Trim() != "" && txtTdep.Text.Trim() != "")
                strSql += " and a.prd_dep >= '" + txtFdep.Text.Trim() + "'" + " and a.prd_dep <= '" + txtTdep.Text.Trim() + "'";
            if (textMo1.Text.Trim() != "" && textMo2.Text.Trim() != "")
                strSql += " and a.prd_mo >= '" + textMo1.Text.Trim() + "'" + " and a.prd_mo <= '" + textMo2.Text.Trim() + "'";
            if (txtMac1.Text.Trim() != "" && txtMac1.Text.Trim() != "")
                strSql += " and a.prd_machine >= '" + txtMac1.Text.Trim() + "'" + " and a.prd_machine <= '" + txtMac2.Text.Trim() + "'";
            if (txtWorkType1.Text.Trim() != "" && txtWorkType2.Text.Trim() != "")
                strSql += " and a.prd_work_type >= '" + txtWorkType1.Text.Trim() + "'" + " and a.prd_work_type <= '" + txtWorkType2.Text.Trim() + "'";
            if (txtGroup1.Text.Trim() != "" && txtGroup2.Text.Trim() != "")
                strSql += " and a.prd_group >= '" + txtGroup1.Text.Trim() + "'" + " and a.prd_group <= '" + txtGroup2.Text.Trim() + "'";
            if (rdbIsComp.Checked == true)
                strSql += " and a.prd_start_time <> '" + "" + "'" + " and a.prd_end_time <> '" + "" + "'";
            if (rdbNoComp.Checked == true)
                strSql += " and (a.prd_start_time = '" + "" + "'" + " or a.prd_end_time = '" + "" + "')";
            if (rpt_type == 0)
                strSql += " Select * From #tb_prd00 Order By prd_dep,prd_mo,prd_work_type,prd_date";
            else
            {
                strSql += " UPDATE #tb_prd00 SET prd_work_type=job_type,work_type_desc=job_desc WHERE prd_dep='J07' ";
                strSql += " SELECT prd_dep,prd_date,prd_work_type,work_type_desc,Convert(Decimal(18,2),SUM(prd_qty)) AS prd_qty"+
                    ", Convert(Decimal(18,2),SUM(prd_weg)) AS prd_weg" +
                    ", Convert(Decimal(18,2),SUM(prd_run_qty)) AS prd_run_qty" +
                    ", Convert(Decimal(18,2),SUM(prd_normal_time)) AS prd_normal_time"+
                    ", Convert(Decimal(18,2),SUM(prd_ot_time)) AS prd_ot_time"+
                    ", Convert(Decimal(18,2),SUM(prd_normal_time + prd_ot_time)) AS prd_time" +
                    " INTO #tb_prd01 " +
                    " FROM #tb_prd00 " +
                    " GROUP BY prd_dep, prd_date, prd_work_type, work_type_desc ";
                strSql += " INSERT INTO #tb_prd01 (prd_dep,prd_date,prd_work_type,work_type_desc,prd_qty,prd_weg,prd_run_qty,prd_normal_time,prd_ot_time,prd_time) " +
                        " SELECT prd_dep, prd_date, '小計' AS prd_work_type, '' AS work_type_desc, SUM(prd_qty) AS prd_qty, SUM(prd_weg) AS prd_weg " +
                        ", SUM(prd_run_qty) AS prd_run_qty" +
                        ", SUM(prd_normal_time) AS prd_normal_time, SUM(prd_ot_time) AS prd_ot_time, SUM(prd_time) AS prd_time" +
                    " FROM #tb_prd01 " +
                    " GROUP BY prd_dep, prd_date";
                strSql += " SELECT * FROM #tb_prd01 ORDER BY prd_dep,prd_date,prd_work_type";
                strSql += " DROP TABLE #tb_prd01";
            }
            strSql += " DROP TABLE #tb_prd00 ";
            clsPublicOfPad clsConErp = new clsPublicOfPad();
            dtPrd = clsConErp.GetDataTableWithSqlString(strSql);
            if (rdbDetails1.Checked == true)
                dgvDetails.DataSource = dtPrd;
            else
                dgvSummary.DataSource = dtPrd;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            txtTdep.Text = txtFdep.Text;
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
                
                if (rdbDetails1.Checked == true)//明細表
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
                    //写标题
                    for (int i = 0; i < dgvSummary.ColumnCount; i++)
                    {
                        str += dgvSummary.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                        str += "\t";
                    }
                    sw.WriteLine(str);
                    //写内容
                    string col_value;
                    for (int rowNo = 0; rowNo < dgvSummary.RowCount; rowNo++)
                    {
                        string tempstr = " ";
                        for (int columnNo = 0; columnNo < dgvSummary.ColumnCount; columnNo++)
                        {
                            col_value = clsUtility.FormatNullableString(dgvSummary.Rows[rowNo].Cells[columnNo].Value);
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
            if (rdbNoComp.Checked == true)
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
