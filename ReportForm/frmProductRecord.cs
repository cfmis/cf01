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
        //string strConn = System.Configuration.ConfigurationManager.AppSettings["conn_db_for_wm"]; // dgpc-602
        //String strConn = "server=192.168.3.10;uid=sa;pwd=268709;database=dgcf_pad;Connect Timeout=30";
        private string remote_db = DBUtility.remote_db;
        private string hr_db_server = DBUtility.hr_db_server;
        private DataTable dtPrd = new DataTable();
        private clsCommonUse commUse = new clsCommonUse();
        public frmProductRecord()
        {
            InitializeComponent();
        }

        private void frmProductRecord_Load(object sender, EventArgs e)
        {
            clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            forminit.GenerateContorl();
            detDate1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            detDate2.Text = detDate1.Text;
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
            //SqlConnection m_Conn = null;
            string strSql = "";
            strSql = "Select a.prd_dep,a.prd_pdate,a.prd_date,a.prd_mo,a.prd_item,c.name AS goods_name,a.prd_qty,a.prd_weg,a.prd_machine,b.work_type_desc,substring(a.prd_worker,6,5) AS prd_worker,a.prd_class" +
                ",Work_code,Difficulty_level,Speed_lever,Job_type,Start_run,End_run,Prd_Run_qty,Sample_no,Sample_weg,a.ok_qty,a.ok_weg,a.no_ok_qty,a.no_ok_weg" +
                ",prd_group,prd_start_time,prd_end_time,prd_normal_time,prd_ot_time,line_num,hour_run_num,hour_std_qty,transfer_flag,CONVERT(varchar(100),transfer_time, 120) AS transfer_time" +
                ",crusr,CONVERT(varchar(100),crtim, 120) AS crtim,amusr,CONVERT(varchar(100),amtim, 120) AS amtim,d.id,d.sequence_id,e.hrm1name AS prd_worker_name" +
                " from product_records a" +
                " Left Outer Join work_type b on a.prd_work_type=b.work_type_id " +
                " Left Outer Join dgcf_db.dbo.geo_it_goods c on a.prd_item COLLATE Chinese_Taiwan_Stroke_CI_AS = c.id" +
                " Left Outer Join " + remote_db +"jo_data_upkeep_details d ON a.prd_id=d.prd_id"+
                " Left Outer Join " + hr_db_server + "hrm01 e ON a.prd_worker COLLATE Chinese_Taiwan_Stroke_CI_AS = e.hrm1wid" +
                " where a. prd_dep >= '' ";
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
            if(rdbIsComp.Checked==true)
                strSql += " and a.prd_start_time <> '" + "" + "'" + " and a.prd_end_time <> '" + "" + "'";
            if (rdbNoComp.Checked == true)
                strSql += " and (a.prd_start_time = '" + "" + "'" + " or a.prd_end_time = '" + "" + "')";
            if (chkIsProd.Checked == false)
                strSql += " and a.prd_work_type <> '" + "A03" + "'";
            else
                strSql += " and a.prd_work_type = '" + "A03" + "'";
            dtPrd = clsPublicOfPad.GetDataTable(strSql);

            //try
            //{
            //    m_Conn = new SqlConnection(strConn);
            //    //m_Cmd = new SqlCommand();
            //    //m_Cmd.Connection = m_Conn;
            //}
            //catch (Exception er)
            //{
            //    throw er;
            //}
            //DataSet ds = null;

            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter(strSql, m_Conn);
            //    ds = new DataSet();
            //    sda.Fill(dtPrd);
            //}
            //catch (Exception er)
            //{
            //    throw er;
            //}



            dtPrd.Columns.Add("prd_qty_std", typeof(string));
            dtPrd.Columns.Add("prd_qty_std_def", typeof(string));
            //for (int i = 0; i < dtPrd.Rows.Count; i++)
            //{
                
            //}
            foreach (DataRow rows in dtPrd.Rows) //开始循环赋值
            {
                //DataRow row = dtPrd.NewRow(); //创建一个行
                rows["prd_qty_std"] = Math.Round(
                    ((rows["prd_normal_time"].ToString()!=""?Convert.ToSingle(rows["prd_normal_time"].ToString()):0)
                    + (rows["prd_ot_time"].ToString()!=""?Convert.ToSingle(rows["prd_ot_time"].ToString()):0))
                    * (rows["hour_std_qty"].ToString()!=""?Convert.ToSingle(rows["hour_std_qty"].ToString()):0)
                    ,0).ToString();  //从总的Datatable中读取行数据赋值给新的Datatable
                rows["prd_qty_std_def"] = ((rows["prd_qty"].ToString()!=""?Convert.ToSingle(rows["prd_qty"]):0) - (rows["prd_qty_std"].ToString()!=""?Convert.ToSingle(rows["prd_qty_std"]):0)).ToString();
                //dtPrd.Rows.Add(row);//添加次行
            }

            dtPrd.DefaultView.Sort = "id";
            dgvDetails.DataSource = dtPrd;
            //m_Conn.Close();
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
