using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Reports;
using cf01.MDL;
using System.Threading;
using System.IO;
using cf01.Forms;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmPrintTransfer_105 : Form
    {
        private clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        private DataTable dtDataForPrint = new DataTable();
        private DataTable dtParts = new DataTable();
        //將已選中的記錄加到臨時表中，此表沒有重覆
        private DataTable dtPrint = new DataTable();
        private DataTable dtDept = new DataTable();

        public frmPrintTransfer_105()
        {
            InitializeComponent();

            dtPrint.Columns.Add("wp_id", typeof(String));
            dtPrint.Columns.Add("mo_id", typeof(String));
            dtPrint.Columns.Add("goods_id", typeof(String));
            dtPrint.Columns.Add("next_wp_id", typeof(String));
        }

        private void frmPrintTransfer_105_Load(object sender, EventArgs e)
        {
            BindDept();
            txtCon_date1.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd 00:00:00");
            txtCon_date2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            dgvTransfer.AutoGenerateColumns = false;
            
            InitQueryValue();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {           
            QueryData();
        }


        private void btnArrangeProduction_Click(object sender, EventArgs e)
        {
            if (dgvTransfer.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;  //光標等待
                int Result = GenerateDataForProduction();
                Cursor = Cursors.Default;
                if (Result > 0)
                {
                    MessageBox.Show("已成功添加到安排生產計劃！");
                }
                else
                {
                    MessageBox.Show("安排生產計劃失敗！");
                }
            }
            else { MessageBox.Show("沒有要安排的記錄！"); }
        }

        private void btnSaveQueryValue_Click(object sender, EventArgs e)
        {
            List<mdlQueryValue> lsQV = new List<mdlQueryValue>();
            clsUtility.GetValue(panel1.Controls, lsQV, Name);

            if (lsQV.Count > 0)
            {
                int Result = clsQueryValue.AddOrUpdateQueryValue(lsQV);
                if (Result > 0)
                {
                    MessageBox.Show("查詢條件已保存！");
                }
                else
                {
                    MessageBox.Show("查詢條件保存失敗！");
                }
            }
        }

        private void btnSaveHadPrint_Click(object sender, EventArgs e)
        {
            //dtPrint此表爲已處理掉重覆的記錄              
            dtPrint.Clear();
            string strFilter = "";
            string wp_id = "";
            string mo_id = "";
            string mat_id = "";
            string next_wp_id = "";
            for (int i = 0; i < dgvTransfer.Rows.Count; i++)
            {
                if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)
                {
                    wp_id = dgvTransfer.Rows[i].Cells["colOut_dept"].Value.ToString();
                    mo_id = dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString();
                    mat_id = dgvTransfer.Rows[i].Cells["colGoods_id"].Value.ToString();
                    next_wp_id = dgvTransfer.Rows[i].Cells["colIn_dept"].Value.ToString();
                    strFilter = string.Format("next_wp_id='{0}' and wp_id='{1}' and mo_id='{2}' and goods_id='{3}'",next_wp_id,wp_id, mo_id,mat_id );
                    DataRow[] dr = dtPrint.Select(strFilter);
                    if (dr.Length == 0)//是否已存在記錄
                    {
                        dtPrint.Rows.Add(new object[] { wp_id, mo_id, mat_id, next_wp_id });
                    }
                }
            }  
            
            List<mdlMoStatePrint> lsModel = new List<mdlMoStatePrint>();            
            for (int i = 0; i < dtPrint.Rows.Count; i++)
            {            
                mdlMoStatePrint objModel = new mdlMoStatePrint();
                objModel.crtim = DateTime.Now;
                objModel.crusr = DBUtility._user_id;
                objModel.print_status = "P";
                objModel.goods_id = dtPrint.Rows[i]["goods_id"].ToString();
                objModel.mo_id = dtPrint.Rows[i]["mo_id"].ToString();
                objModel.next_wp_id = dtPrint.Rows[i]["next_wp_id"].ToString();
                objModel.ver = clsUtility.FormatNullableInt32(null);
                objModel.wp_id = dtPrint.Rows[i]["wp_id"].ToString();
                lsModel.Add(objModel);  
            }

            if (lsModel.Count > 0)
            {
                int Result = clsMoStatePrint.AddMoStatePrint(lsModel);
                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                }
                else
                {
                    MessageBox.Show("保存失敗!");
                }
            }
        }

        /// <summary>
        /// 查詢數據
        /// </summary>
        private void QueryData()
        {
            txtMo2.Focus();
            string strCon_date_from = "";
            string strCon_date_to = "";
                 
            if (txtCon_date1.Text != "" && txtCon_date2.Text!= "")
            {                
                if (clsValidRule.CheckDateTimeFormat(txtCon_date1.Text) == false || 
                    clsValidRule.CheckDateTimeFormat(txtCon_date2.Text) == false)
                {
                    MessageBox.Show("收貨日期不正確!");                    
                    txtCon_date1.Focus();
                    return;
                }
                else
                {                   
                    strCon_date_from = txtCon_date1.Text;
                    strCon_date_to = txtCon_date2.Text;
                }
            }
            
            Cursor = Cursors.WaitCursor;  //光標指為等待狀態
            DataTable dtTransfer = GetTransferInfo(txtIn_dept.Text.Trim(), txtOut_dept.Text.Trim(),
                                                                    strCon_date_from, strCon_date_to, radioGroup1.SelectedIndex,
                                                                    txtMo1.Text.Trim(),txtMo2.Text.Trim());
            Cursor = Cursors.Default; //恢復光標指為正常狀態

            if (dtTransfer.Rows.Count > 0)
            {
                if (chkPositive.Checked == true || chkMinus.Checked == true)  //正數
                {
                    DataTable dtException = dtTransfer.Copy();
                    dtException.Rows.Clear();

                    for (int i = 0; i < dtTransfer.Rows.Count; i++)
                    {
                        double Con_qty = Convert.ToDouble(dtTransfer.Rows[i]["con_qty"].ToString());
                        double Sec_weg = Convert.ToDouble(dtTransfer.Rows[i]["sec_qty"].ToString());
                        double Actual_qty = Convert.ToDouble(dtTransfer.Rows[i]["actual_qty"].ToString());
                        double Actual_weg = Convert.ToDouble(dtTransfer.Rows[i]["actual_weg"].ToString());
                        if (chkPositive.Checked == true)
                        {
                            if (Actual_qty - Con_qty > 0 || Actual_weg - Sec_weg >0)
                            {
                                dtException.Rows.Add(dtTransfer.Rows[i].ItemArray);
                            }
                        }
                        if (chkMinus.Checked == true)
                        {
                            if (Actual_qty - Con_qty < 0 || Actual_weg - Sec_weg < 0)
                            {
                                dtException.Rows.Add(dtTransfer.Rows[i].ItemArray);
                            }
                        }
                    }

                    dgvTransfer.DataSource = dtException;
                    dgvTransfer.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else
                {
                    dgvTransfer.DataSource = dtTransfer;
                    for (int i = 0; i < dtTransfer.Rows.Count; i++)
                    {
                        string Con_qty = dtTransfer.Rows[i]["con_qty"].ToString();
                        string Sec_weg = dtTransfer.Rows[i]["sec_qty"].ToString();
                        string Package_num = dtTransfer.Rows[i]["package_num"].ToString();
                        string Actual_qty = dtTransfer.Rows[i]["actual_qty"].ToString();
                        string Actual_weg = dtTransfer.Rows[i]["actual_weg"].ToString();
                        string Actual_pack = dtTransfer.Rows[i]["actual_pack"].ToString();
                        if (Con_qty != Actual_qty || Sec_weg != Actual_weg || Package_num != Actual_pack)
                        {
                            dgvTransfer.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                        else
                        {
                            dgvTransfer.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
                dgvTransfer.Refresh();
            }
            else
            {
                dgvTransfer.DataSource = dtTransfer;
                MessageBox.Show("沒有找到符合條件的記錄!");
            }
        }

        /// <summary>
        /// 安排生產
        /// </summary>
        private int GenerateDataForProduction()
        {
            int Result = 0;
            string OldMo_id = "";
            List<product_records> lsPrdRecords = new List<product_records>();
            for (int i = 0; i < dgvTransfer.Rows.Count; i++)
            {
                if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)
                {
                    string mo_id = dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString();
                    string wp_id = dgvTransfer.Rows[i].Cells["colIn_dept"].Value.ToString();
                    string mater_id = dgvTransfer.Rows[i].Cells["colGoods_id"].Value.ToString();

                    if (mo_id != OldMo_id)   //判斷當前頁數和下個頁數是否相同
                    {
                        DataTable dtMo_date = clsPrdTransfer.GetMo_dataById(mo_id, wp_id, mater_id);//從生產流程中提取生產記錄
                        if (dtMo_date.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtMo_date.Rows.Count; j++)
                            {
                                product_records objModel = new product_records();
                                objModel.prd_id = clsPublicOfPad.GenNo("frmProductionSchedule");//自動產生序列號
                                objModel.prd_mo = mo_id;
                                objModel.prd_dep = wp_id;
                                objModel.prd_date = DateTime.Now.ToString("yyyy/MM/dd");
                                objModel.prd_pdate = DateTime.Now.ToString("yyyy/MM/dd");
                                objModel.prd_item = dtMo_date.Rows[j]["goods_id"].ToString();
                                objModel.prd_qty = Convert.ToInt32(dtMo_date.Rows[j]["prod_qty"]);
                                objModel.prd_work_type = "生產";
                                objModel.crtim = DateTime.Now;
                                objModel.crusr = DBUtility._user_id;
                                lsPrdRecords.Add(objModel);
                            }
                        }
                        OldMo_id = mo_id;
                    }
                }
            }

            if (lsPrdRecords.Count > 0)
            {
                Result = clsPrdTransfer.AddProductionRecords(lsPrdRecords);
            }
            else
            {
                MessageBox.Show("沒有選擇要安排的記錄!");
            }

            return Result;
        }

        /// <summary>
        /// 生成打印數據
        /// </summary>
        private void GenerateDataForPrint()
        {
            //dtPrint此表爲已處理掉重覆的記錄              
            dtPrint.Clear();
            string strFilter = "";
            string wp_id = "";
            string mo_id = "";
            string mat_id = "";
            const string next_wp_id = "";           
            for (int i = 0; i < dgvTransfer.Rows.Count; i++)
            {
                if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)
                {
                    wp_id = dgvTransfer.Rows[i].Cells["colIn_dept"].Value.ToString();
                    mo_id = dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString();
                    mat_id = dgvTransfer.Rows[i].Cells["colGoods_id"].Value.ToString();
                    strFilter = string.Format("wp_id='{0}' and mo_id='{1}' and goods_id='{2}'",wp_id,mo_id,mat_id);                   
                    DataRow[] dr = dtPrint.Select(strFilter);
                    if (dr.Length == 0)//是否已存在記錄
                    {
                        dtPrint.Rows.Add(new object[] { wp_id, mo_id, mat_id, next_wp_id });
                    }
                }
            }

            dtDataForPrint.Rows.Clear();
            dtParts.Rows.Clear();           
            string isPrintQc = "";
            DataTable dtTempData = new DataTable();
            DataTable dtTempParts = new DataTable();            
            for (int i = 0; i < dtPrint.Rows.Count; i++)
            {            
                wp_id = dtPrint.Rows[i]["wp_id"].ToString();
                mo_id = dtPrint.Rows[i]["mo_id"].ToString();
                mat_id = dtPrint.Rows[i]["goods_id"].ToString();
                if(chkNoQc.Checked)
                    isPrintQc="1";//不顯示QC
                else
                    isPrintQc="0";
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@mo_id",mo_id),
                    new SqlParameter("@wp_id",wp_id),
                    new SqlParameter("@materiel_id",mat_id),
                    new SqlParameter("@isPrintQc",isPrintQc)
                };
                DataSet dsTempData = clsPublicOfGEO.ExecuteProcedureReturnDataSet("z_rpt_prdtranser", paras, null);
                
                dtTempData = dsTempData.Tables[0];//主表
                if (dtTempData.Rows.Count > 0)
                {
                    if (dtDataForPrint.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtTempData.Rows.Count; j++)
                        {
                            //一個頁數有可能一次收多個批次的貨
                            //所以有必要多作個判斷，以防重入重覆的記錄
                            strFilter = string.Format("wp_id='{0}' and mo_id='{1}' and goods_id='{2}'",
                                dtTempData.Rows[j]["wp_id"], dtTempData.Rows[j]["mo_id"], dtTempData.Rows[j]["goods_id"]);                            
                            DataRow[] dr = dtDataForPrint.Select(strFilter);
                            if (dr.Length == 0)//是否已存記錄
                            {
                                dtDataForPrint.ImportRow(dtTempData.Rows[j]);
                            }
                        }
                    }
                    else
                    {
                        dtDataForPrint = dtTempData;
                    }
                    //添加配件
                    dtTempParts = dsTempData.Tables[1];                         
                    if (dtParts.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtTempParts.Rows.Count; j++)
                        {
                            strFilter = string.Format(@"wp_id='{0}' and mo_id='{1}' and goods_id='{2}' and part_goods_id='{3}'",
                            dtTempParts.Rows[j]["wp_id"], dtTempParts.Rows[j]["mo_id"], dtTempParts.Rows[j]["goods_id"], dtTempParts.Rows[j]["part_goods_id"]);
                            DataRow[] dr = dtParts.Select(strFilter);
                            if (dr.Length == 0)//是否已存記錄
                            {
                                dtParts.ImportRow(dtTempParts.Rows[j]);
                            }
                        }
                    }
                    else
                    {
                        dtParts = dtTempParts;
                    }
                }  
            }
        }


        private void dgvTransfer_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
             e.RowBounds.Location.Y,
             dgvTransfer.RowHeadersWidth - 4,
             e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvTransfer.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvTransfer.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 綁定收貨部門、發貨部門
        /// </summary>
        private void BindDept()
        {
            //DataTable dtDept = clsBs_Dep.GetAllDepartment();
            dtDept = clsBaseData.Get_Department();
            if (dtDept.Rows.Count > 0)
            {                
                for(int i=0;i<dtDept.Rows.Count;i++)
                {
                    txtIn_dept.Items.Add(dtDept.Rows[i]["id"].ToString());
                    txtOut_dept.Items.Add(dtDept.Rows[i]["id"].ToString());
                }                
            }           
        }

        /// <summary>
        /// 加載 User上次查詢條件 
        /// </summary>
        private void InitQueryValue()
        {
            DataTable dtvalue = clsQueryValue.GetQueryValue(Name, DBUtility._user_id);
            if (dtvalue.Rows.Count > 0)
            {
                for (int i = 0; i < dtvalue.Rows.Count; i++)
                {
                    string strObj_id = dtvalue.Rows[i]["obj_id"].ToString();
                    string strOjb_Value = dtvalue.Rows[i]["obj_value"].ToString();
                    
                    if (txtIn_dept.Name == strObj_id)
                    {
                        txtIn_dept.SelectedIndex = Convert.ToInt32(strOjb_Value);                        
                    }
                    if (txtOut_dept.Name == strObj_id)
                    {
                        txtOut_dept.SelectedIndex = Convert.ToInt32(strOjb_Value);                       
                    }
                    if (txtCon_date1.Name == strObj_id)
                    {                        
                        txtCon_date1.Text = strOjb_Value;
                    }
                    if (txtCon_date2.Name == strObj_id)
                    {                       
                        txtCon_date2.Text = strOjb_Value;
                    }                   

                    if (radioGroup1.Name == strObj_id)
                    {
                        radioGroup1.SelectedIndex = Convert.ToInt32(strOjb_Value);                    
                    }
                }
            }
        }

        private void txtMo1_Leave(object sender, EventArgs e)
        {
            txtMo2.Text = txtMo1.Text;
        }

        private void chkSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTransfer.RowCount; i++)
            {
                if (chkSelect.Checked==true)
                {                   
                    dgvTransfer.Rows[i].Cells["checkbox"].Value = true;
                }
                else
                    dgvTransfer.Rows[i].Cells["checkbox"].Value = false;
            }
        }

        private void btnPrintPrdCard_Click(object sender, EventArgs e)
        {
            //以下為舊的列印方法
            if (dgvTransfer.Rows.Count > 0)
            {
                bool isSelect = false;
                for (int i = 0; i < dgvTransfer.Rows.Count; i++)
                {                    
                    if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)
                    {
                        isSelect = true;
                        break;
                    }
                }
                if (isSelect == false)
                {
                    MessageBox.Show("沒有選擇打印的記錄!","提示信息");
                    return;
                }
                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();
                GenerateDataForPrint();

                wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                if (dtDataForPrint.Rows.Count > 0)
                {
                    xrPrdTransfer xrPT = new xrPrdTransfer(dtDataForPrint, dtParts);
                    xrPT.ShowPreviewDialog();
                }
            }
            else
            {
                MessageBox.Show("請查詢數據后，再打印報表.");
            }
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                str += "頁數";
                str += "\t" + "貨品編碼";
                str += "\t" + "批號";
                str += "\t" + "單位";
                str += "\t" + "倉庫";
                str += "\t" + "重量單位";
                str += "\t" + "數量";
                str += "\t" + "重量";
                sw.WriteLine(str);
                double qty, aqty;
                double weg, aweg;
                for (int i = 0; i < dgvTransfer.Rows.Count; i++)
                {
                    string tempstr = "";
                    if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)//被選取的記錄才匯出
                    {
                        qty = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colCon_qty"].Value);
                        aqty = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colActual_qty"].Value);
                        weg = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colSec_qty"].Value);
                        aweg = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colActual_weg"].Value);
                        tempstr += dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString().Trim();//頁數;
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colGoods_id"].Value.ToString().Trim();//貨品編碼;
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["Collot_no"].Value.ToString().Trim() + "\"";//批號;
                        tempstr += "\t" + "PCS";//單位;
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colIn_dept"].Value.ToString().Trim() + "\"";//倉庫;
                        tempstr += "\t" + "KG";//重量單位;
                        tempstr += "\t" + (aqty - qty).ToString();//數量
                        tempstr += "\t" + (aweg - weg).ToString();//重量
                        sw.WriteLine(tempstr);
                    }
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void chkPositive_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        private void chkMinus_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        private void btnSaveAdj_Click(object sender, EventArgs e)
        {
            updateAdjFlag();//儲存調整標識
        }
        //儲存調整標識
        private void updateAdjFlag()
        {
            List<mdlAdjFlag> lsModel = new List<mdlAdjFlag>();
            for (int i = 0; i < dgvTransfer.Rows.Count; i++)
            {
                if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)//被選取的記錄才儲存
                {
                    mdlAdjFlag objModel = new mdlAdjFlag();
                    objModel.doc_id = dgvTransfer.Rows[i].Cells["colTrans_id"].Value.ToString();
                    objModel.doc_seq = dgvTransfer.Rows[i].Cells["colSequence_id"].Value.ToString();
                    objModel.adj_flag = "Y";
                    lsModel.Add(objModel);
                }
            }
            if (lsModel.Count > 0)
            {
                int Result = clsMoStatePrint.updateAdjFlag(lsModel);
                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                }
                else
                {
                    MessageBox.Show("保存失敗!");
                }
            }
        }

        private void chkIsAdj_Click(object sender, EventArgs e)
        {
            QueryData();
        }        

        private void btnExpTran_Click(object sender, EventArgs e)
        {
            ExpToExcel(1);
        }
        //匯出到Excel
        private void ExpToExcel(int ep_type)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                if (ep_type == 1)//普通格式
                {
                    str += "制單編號";
                    str += "\t" + "物料編號";
                    str += "\t" + "物料描述";
                    str += "\t" + "移交單號";
                    str += "\t" + "移交單日期";
                    str += "\t" + "單據數量";
                    str += "\t" + "實收數量";
                    str += "\t" + "單據重量";
                    str += "\t" + "實收重量";
                    str += "\t" + "簽收時間";
                    str += "\t" + "批號";
                    str += "\t" + "序號";
                    str += "\t" + "發貨部門";
                    str += "\t" + "收貨部門";
                }
                else
                {
                    str += "制單編號";
                    str += "\t" + "物料描述";
                    str += "\t" + "實收數量";
                    str += "\t" + "實收重量";
                    str += "\t" + "差數數量";
                    str += "\t" + "差數重量";
                    str += "\t" + "簽收時間";
                }
                sw.WriteLine(str);
                for (int i = 0; i < dgvTransfer.Rows.Count; i++)
                {
                    string tempstr = "";
                    double qty, aqty;
                    double weg, aweg;
                    //if ((bool)dgvTransfer.Rows[i].Cells["checkbox"].EditedFormattedValue)//被選取的記錄才匯出
                    //{
                    qty = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colCon_qty"].Value);
                    aqty = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colActual_qty"].Value);
                    weg = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colSec_qty"].Value);
                    aweg = Convert.ToDouble(dgvTransfer.Rows[i].Cells["colActual_weg"].Value);
                    if (ep_type == 1)
                    {
                        tempstr += dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString().Trim();//制單編號
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colGoods_id"].Value.ToString().Trim();//貨品編碼
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["coliGoods_name"].Value.ToString().Trim();//物料描述
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colTrans_id"].Value.ToString().Trim();//移交單號
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colCon_date"].Value.ToString().Trim() + "\"";//移交單日期
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colCon_qty"].Value.ToString().Trim();//單據數量
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colActual_qty"].Value.ToString().Trim();//實收數量
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colSec_qty"].Value.ToString().Trim();//單據重量
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colActual_weg"].Value.ToString().Trim();//實收重量
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colImput_time"].Value.ToString().Trim() + "\"";//簽收時間
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["Collot_no"].Value.ToString().Trim() + "\"";//批號;
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colSequence_id"].Value.ToString().Trim() + "\"";//序號
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colOut_dept"].Value.ToString().Trim() + "\"";//發貨部門
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colIn_dept"].Value.ToString().Trim() + "\"";//收貨部門
                    }
                    else
                    {
                        tempstr += dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString().Trim();//制單編號
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["coliGoods_name"].Value.ToString().Trim();//物料描述
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colActual_qty"].Value.ToString().Trim();//實收數量
                        tempstr += "\t" + dgvTransfer.Rows[i].Cells["colActual_weg"].Value.ToString().Trim();//實收重量
                        tempstr += "\t";
                        tempstr += "\t";
                        tempstr += "\t" + "=\"" + dgvTransfer.Rows[i].Cells["colImput_time"].Value.ToString().Trim() + "\"";//簽收時間
                    }
                    sw.WriteLine(tempstr);
                    //}
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void btnExpBuckle_Click(object sender, EventArgs e)
        {
            ExpToExcel(2);//匯出到Excel(扣部格式)
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        private void txtIn_dept_SelectedIndexChanged(object sender, EventArgs e)
        {           
            txtIn_Dept_Name.Text = dtDept.Rows[txtIn_dept.SelectedIndex]["cdesc"].ToString();
        }

        private void txtOut_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOut_Dept_Name.Text = dtDept.Rows[txtOut_dept.SelectedIndex]["cdesc"].ToString();
        }

        private void txtIn_dept_Leave(object sender, EventArgs e)
        {
            Set_Dept_Name(txtIn_dept, txtIn_Dept_Name);            
        }

        private void txtOut_dept_Leave(object sender, EventArgs e)
        {
            Set_Dept_Name(txtOut_dept, txtOut_Dept_Name);
        }

        private void Set_Dept_Name(ComboBox objComboBox,TextBox objTextBox)
        {
            if (objComboBox.Text != "")
            {
                for (int i = 0; i < dtDept.Rows.Count; i++)
                {
                    if (dtDept.Rows[i]["id"].ToString() == objComboBox.Text)
                    {
                        objTextBox.Text = dtDept.Rows[i]["cdesc"].ToString();
                        objComboBox.SelectedIndex = i;
                        break;
                    }
                    else
                    {                       
                        objTextBox.Text = "";
                    }
                }
            }
            else
                objTextBox.Text = "";
        }



        public static DataTable GetTransferInfo(string pIn_dept, string pOut_dept,
                        string pCon_date_from, string pCon_date_to, int Select_Index,
                        string mo1, string mo2)
        {
            DataTable dtTransfer = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder(
                                  @"SELECT Distinct a.mo_id ,a.id ,a.sequence_id ,a.goods_id ,a.lot_no
                                        ,a.con_qty,a.sec_qty ,a.package_num ,0 as actual_qty ,0 as actual_weg
                                        ,0 as actual_pack ,Convert(varchar(10),b.con_date,111) as con_date ,b.out_dept ,b.in_dept ,c.name as goods_name
                                        ,Convert(varchar(20),b.create_date,20) as crtim,'' as imput_flag,Convert(varchar(20),a.sign_date,20) as imput_time,'' as adj_flag
                                  FROM dgerp2.cferp.dbo.jo_materiel_con_details as a WITH(NOLOCK)
                                  INNER JOIN dgerp2.cferp.dbo.jo_materiel_con_mostly b WITH(NOLOCK) on a.within_code=b.within_code and a.id=b.id
                                  LEFT JOIN dgsql2.dgcf_db.dbo.geo_it_goods c WITH(NOLOCK) on a.goods_id=c.id  COLLATE Chinese_Taiwan_Stroke_CI_AS 
                                  LEFT JOIN dgerp2.cferp.dbo.jo_bill_mostly d WITH(NOLOCK) on a.within_code=d.within_code AND a.mo_id=d.mo_id
                                  WHERE b.within_code='0000' ");

                if (pIn_dept != "")
                {
                    sb.Append(String.Format(" AND b.in_dept='{0}' ", pIn_dept));
                }
                if (pOut_dept != "")
                {
                    sb.Append(String.Format(" AND b.out_dept='{0}' ", pOut_dept));
                }
                if (pCon_date_from != "" && pCon_date_to != "")
                {
                    sb.Append(String.Format(" AND b.create_date>='{0}' and b.create_date<='{1}'", pCon_date_from, pCon_date_to));
                }
                if (mo1 != "" && mo2 != "")
                {
                    sb.Append(String.Format(" AND a.mo_id>='{0}' and a.mo_id<='{1}'", mo1, mo2));
                }
               

                DataTable dtTemp = clsPublicOfPad.GetDataTable(sb.ToString());//根據條件查出PAD生成移交數據
                DataTable dtHadPrint = dtTemp.Copy();
                DataTable dtNoPrint = dtTemp.Copy();
                dtHadPrint.Rows.Clear();
                dtNoPrint.Rows.Clear();
                DataTable dtMoStatePrint = clsMoStatePrint.GetMoStatePrintForTrans(pOut_dept, pIn_dept);//查出已列印的歷史數據
                if (dtTemp.Rows.Count > 0 && dtMoStatePrint.Rows.Count > 0)
                {
                    DataRow[] drs;
                    string strFilter;
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        strFilter = string.Format(@"wp_id='{0}' and mo_id='{1}' and goods_id='{2}' and next_wp_id='{3}'",
                            dtTemp.Rows[i]["out_dept"], dtTemp.Rows[i]["mo_id"],
                            dtTemp.Rows[i]["goods_id"], dtTemp.Rows[i]["in_dept"]);
                        drs = dtMoStatePrint.Select(strFilter);
                        if (drs.Length > 0)
                        {
                            dtHadPrint.Rows.Add(dtTemp.Rows[i].ItemArray); //查找出已列印的數據添加到表dtHadPrint中
                        }
                        else
                        {
                            dtNoPrint.Rows.Add(dtTemp.Rows[i].ItemArray);  //未曾列印過的數據
                        }
                    }
                }

                switch (Select_Index)
                {
                    case 0:
                        dtTransfer = dtNoPrint; //未列印的記錄
                        break;
                    case 1:
                        dtTransfer = dtHadPrint; //已列印的記錄
                        break;
                    case 2:
                        dtTransfer = dtTemp;    //全部的記錄(即包括未列印、已列印)
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtTransfer;
        }
    }
}
