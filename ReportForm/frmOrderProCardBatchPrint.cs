using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmOrderProCardBatchPrint : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtReport = new DataTable();
        DataTable dtDetails = new DataTable();
        DataTable dtExcel = new DataTable();

        private DataTable dtReportMostly = new DataTable();
        private DataTable dtReportParts = new DataTable();
        //將已選中的記錄加到臨時表中，此表沒有重覆
        private DataTable dtPrint = new DataTable();
        private DataTable dtDept = new DataTable();

        public frmOrderProCardBatchPrint()
        {
            InitializeComponent();

            dtPrint.Columns.Add("wp_id", typeof(string));
            dtPrint.Columns.Add("mo_id", typeof(string));
            dtPrint.Columns.Add("goods_id", typeof(string));
            //dtPrint.Columns.Add("next_wp_id", typeof(string));
            dtPrint.Columns.Add("per_qty", typeof(int));

            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);
            clsApp.Initialize_find_value(this.Name, panel1.Controls);
        }

        private void frmOrderProCardBatchPrint_Load(object sender, EventArgs e)
        {
            cmbFormat.SelectedIndex = 1;
            DataTable dtDept = clsBaseData.Get_Department();
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            txtOut_detp1.Properties.DataSource = dtDept;
            txtOut_detp1.Properties.ValueMember = "id";
            txtOut_detp1.Properties.DisplayMember = "cdesc";
            chkNoQc.Checked = true;
        }

        private void frmOrderProCardBatchPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;
            clsConErp = null;
            dtReport.Dispose();
            dtDetails.Dispose();
            dtExcel.Dispose();
        }


        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOut_detp1.EditValue.ToString()))
            {
                MessageBox.Show("部門不可為空!", "提示信息");
                txtOut_detp1.Focus();
                return;
            }
            //當頁數不為空時,不用檢查日期是否為空
            if(txtmo_id1.Text.Trim() == "")
            {
                if (txtCon_date1.Text == "")
                {
                    MessageBox.Show("批準日期不可為空!", "提示信息");
                    txtCon_date1.Focus();
                    return;
                }
                if (txtCon_date2.Text == "")
                {
                    MessageBox.Show("批準日期不可為空!", "提示信息");
                    txtCon_date2.Focus();
                    return;
                }
            }
            string strDate1 = "", strDate2 = "";
            if (txtCon_date1.Text != "")
            {
                strDate1 = DateTime.Parse(txtCon_date1.EditValue.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
            }
            if (txtCon_date2.Text != "")
            {
                strDate2 = DateTime.Parse(txtCon_date2.EditValue.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
            }

            SqlParameter[] paras = new SqlParameter[]
            {
                    //yyyy/MM/dd HH:mm:ss
                    new SqlParameter("@check_date1",strDate1),
                    new SqlParameter("@check_date2", strDate2),
                    new SqlParameter("@dept", txtOut_detp1.EditValue.ToString()),
                    new SqlParameter("@mo_id", txtmo_id1.Text),
                    new SqlParameter("@format", cmbFormat.SelectedIndex.ToString())   
            };

            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            dtDetails = clsConErp.ExecuteProcedureReturnTable("z_rpt_work_card_batch", paras);

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtDetails.Rows.Count > 0)
            {
                gridControl1.DataSource = dtDetails;
            }
            else
            {
                gridControl1.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //this.gridView1.BestFitColumns();     
        }

        private void PrintSelect(bool ls_pirnt_select)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            for (int i = 0; i < dtDetails.Rows.Count; i++)
            {
                dtDetails.Rows[i]["print_select"] = ls_pirnt_select;
            }
        }

        private void SetPrintFlag(bool ls_pirnt_flag)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            for (int i = 0; i < dtDetails.Rows.Count; i++)
            {
                //已有設置過的不再更新列印標識
                if (dtDetails.Rows[i]["old_print_flag"].ToString() == "False")
                {
                    dtDetails.Rows[i]["print_flag"] = ls_pirnt_flag;
                }
            }
        }


        private void chkPrintSelect_MouseUp(object sender, MouseEventArgs e)
        {
            PrintSelect(chkPrintSelect.Checked);
        }

        private void chkPrintFlag_MouseUp(object sender, MouseEventArgs e)
        {
            SetPrintFlag(chkPrintFlag.Checked);
        }

        private void colPrintFlag_MouseUp(object sender, MouseEventArgs e)
        {
            int cur_row = gridView1.FocusedRowHandle;
            if (gridView1.GetRowCellValue(cur_row, "old_print_flag").ToString() == "True")
            {
                //禁止修改
                gridView1.SetRowCellValue(cur_row, "print_flag", true);
            }
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            gridView1.CloseEditor();//使更改有效
            bool lb_is_select = false;
            int li_cur_row = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                li_cur_row = gridView1.FocusedRowHandle;
                if (gridView1.GetRowCellValue(li_cur_row, "print_select").ToString() == "True")
                {
                    lb_is_select = true;
                    break;
                }
            }
            if (!lb_is_select)
            {
                MessageBox.Show("請選擇需要列印的頁數資料!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridView1.Focus();
                return;
            }
            dtReport.Clear();
            dtReport = dtDetails.Clone();
            dtReport.Columns.Add("report_name", typeof(string));
            int li_total_page;

            DataRow drs;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "print_select").ToString() == "True")
                {                    
                    li_total_page = int.Parse(dtDetails.Rows[i]["total_page"].ToString());                    
                    drs = gridView1.GetDataRow(i);
                    for (int j = 1; j <= li_total_page; j++)
                    {
                        drs["page_num"] = j;
                        dtReport.Rows.Add(drs.ItemArray);
                    }                    
                }
            }

            for (int i = 0; i < dtReport.Rows.Count; i++)
            {               
                dtReport.Rows[i]["report_name"] = "工序卡" + "(" + dtReport.Rows[i]["wp_id"] + ")"; 
            }

            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("無需要列印之數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!chkPaperA4.Checked)
            {
                using (xtaWork_No_BarCode xr = new xtaWork_No_BarCode() { DataSource = dtReport })
                {
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreviewDialog();                    
                }
            }
            else
            {   
                using (xtaWork_No_BarCodeA4 xr = new xtaWork_No_BarCodeA4() { DataSource = dtReport })
                {
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreviewDialog();
                    //if (operationType == clsUtility.enumOperationType.PreView)
                    //    xr.ShowPreviewDialog();//判斷是預覽 Or 打印                            
                    //else
                    //    xr.Print();
                }
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string ver = gridView1.GetRowCellDisplayText(e.RowHandle,"ver");
            string print_flag = gridView1.GetRowCellValue(e.RowHandle, "print_flag").ToString();
            string old_print_flag = gridView1.GetRowCellValue(e.RowHandle, "old_print_flag").ToString();
            string goods_id = gridView1.GetRowCellValue(e.RowHandle, "goods_id").ToString();
            string old_goods_id = gridView1.GetRowCellValue(e.RowHandle, "old_goods_id").ToString();
            string prod_qty = gridView1.GetRowCellValue(e.RowHandle, "prod_qty").ToString();
            string old_prod_qty = gridView1.GetRowCellValue(e.RowHandle, "old_prod_qty").ToString();
            
            if (old_print_flag == "False")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
                //e.Appearance.BackColor = Color.LightBlue;
            }

            //if (old_print_flag == "True" && (goods_id != old_goods_id ||prod_qty != old_prod_qty))
            if (print_flag=="True" && old_print_flag == "True" )
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.MistyRose;//.Salmon;
            }

            //生產計劃有變更
            if (old_print_flag == "True" && (goods_id != old_goods_id ||prod_qty != old_prod_qty))            
            {
                e.Appearance.ForeColor = Color.Blue;
                //e.Appearance.BackColor = Color.LightBlue;//.Salmon;
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            gridView1.CloseEditor();//使更改有效
            bool lb_print_flag = false;
            int li_cur_row = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                li_cur_row = gridView1.FocusedRowHandle;
                if (gridView1.GetRowCellValue(li_cur_row, "print_flag").ToString() == "True" && gridView1.GetRowCellValue(li_cur_row, "old_print_flag").ToString() == "False")
                {
                    lb_print_flag = true;
                    break;
                }
            }
            if (!lb_print_flag)
            {
                MessageBox.Show("請選擇需要設置列印標識的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridView1.Focus();
                return;
            }
           
            string ls_sql_f,ls_sql_i="",ls_sql_u="",ls_id, ls_mo_id, ls_mo_ver, ls_goods_id, ls_sequence_id;
            int li_count=0,li_prod_qty=0;
            bool lb_save_flag=false ;
            ls_sql_i = @"Insert Into rpt_dept_production_plan_report_print(within_code,id,sequence_id,print_flag,mo_id,old_jo_ver,old_prod_qty,old_goods_id,create_date,create_by)
		                 Values(@within_code,@id,@sequence_id,@print_flag,@mo_id,@ver,@prod_qty,@goods_id,GetDate(),@user_id)";
            ls_sql_u = @"Update rpt_dept_production_plan_report_print SET print_flag=@print_flag,mo_id=@mo_id,old_jo_ver=@ver,old_prod_qty=@prod_qty,
                            old_goods_id=@goods_id,update_date=getdate(),update_by=@user_id
                            Where within_code=@within_code and id=@id and sequence_id=@sequence_id";
            string ls_user_id = DBUtility._user_id;
            for (int i = 0; i < gridView1.RowCount; i++)
            {

                if (gridView1.GetRowCellValue(i, "print_flag").ToString() == "True" && gridView1.GetRowCellValue(i, "old_print_flag").ToString() == "False")
                {
                    ls_id = gridView1.GetRowCellValue(i, "id").ToString();
                    ls_sequence_id = gridView1.GetRowCellValue(i, "sequence_id").ToString();                    
                    ls_mo_id = gridView1.GetRowCellValue(i, "mo_id").ToString();
                    ls_mo_ver = gridView1.GetRowCellValue(i, "ver").ToString();
                    ls_goods_id = gridView1.GetRowCellValue(i, "goods_id").ToString();
                    li_prod_qty = Int32.Parse(gridView1.GetRowCellValue(i, "prod_qty").ToString());
                    SqlParameter[] spars = new SqlParameter[]{
                            new SqlParameter("@within_code","0000"),
                            new SqlParameter("@id",ls_id),
                            new SqlParameter("@sequence_id",ls_sequence_id),
                            new SqlParameter("@print_flag","1"),
                            new SqlParameter("@mo_id",ls_mo_id),
                            new SqlParameter("@ver",ls_mo_ver),
                            new SqlParameter("@prod_qty",li_prod_qty),
                            new SqlParameter("@goods_id",ls_goods_id),
                            new SqlParameter("@user_id",ls_user_id)
                    };
                    li_count = 0;
                    ls_sql_f = string.Format(@"Select '1' FROM dbo.rpt_dept_production_plan_report_print Where within_code='0' And id='{0}' And sequence_id='{1}'", ls_id, ls_sequence_id);
                    if (clsConErp.ExecuteSqlReturnObject(ls_sql_f) == "")
                    {
                        li_count = clsConErp.ExecuteNonQuery(ls_sql_i, spars, false);
                        gridView1.SetRowCellValue(i, "old_print_flag", true);
                        gridView1.SetRowCellValue(i, "old_jo_ver", ls_mo_ver);
                        gridView1.SetRowCellValue(i, "old_goods_id", ls_goods_id);
                        gridView1.SetRowCellValue(i, "old_prod_qty", li_prod_qty);
                    }
                    else
                    {
                        li_count = clsConErp.ExecuteNonQuery(ls_sql_u, spars, false);
                    }
                    if (li_count > 0)
                    {
                        lb_save_flag=true ;
                    }
                    else
                    {
                        MessageBox.Show("更新出錯!", "提示信息");
                        lb_save_flag = false;
                        break;
                    }                   
                }
            }

            if (lb_save_flag)
            {
                MessageBox.Show("設置列印標識成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            gridView1.CloseEditor();//使更改有效
            bool lb_is_select = false;
            int li_cur_row = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                li_cur_row = gridView1.FocusedRowHandle;
                if (gridView1.GetRowCellValue(li_cur_row, "print_select").ToString() == "True")
                {
                    lb_is_select = true;
                    break;
                }
            }
            if (!lb_is_select)
            {
                MessageBox.Show("請選擇需要匯出的頁數資料!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridView1.Focus();
                return;
            }
            dtExcel.Clear();
            dtExcel = dtDetails.Clone();           
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "print_select").ToString() == "True")
                {                    
                   DataRow drs= gridView1.GetDataRow(i);
                   dtExcel.Rows.Add(drs.ItemArray);                                 
                }
            }
            dgvExcel.AutoGenerateColumns = false;
            dgvExcel.DataSource = dtExcel;
            ExpToExcel objExcel = new ExpToExcel();
            objExcel.ExportToExcel_Fast(dgvExcel);       
              
            //MessageBox.Show("匯出完成！", "提示信息"); 

            //SaveFileDialog saveFileDialog = new SaveFileDialog() { Title = "Export To Excel", Filter = "Excel files (*.xls)|*.xls" };
            //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            //if (dialogResult == DialogResult.OK)
            //{
            //    gridControl1.ExportToXls(saveFileDialog.FileName);
            //    MessageBox.Show("設置列印標識成功！", "提示信息");                
            //}
        }

        private void BTNPRODCARD_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();//使更改有效
            if (gridView1.RowCount>0)
            {
                bool isSelect = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "print_select").ToString() == "True")
                    {
                        isSelect = true;
                        break;
                    }
                }
                if (isSelect == false)
                {
                    MessageBox.Show("沒有選擇打印的記錄!", "提示信息");
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

                if (dtReportMostly.Rows.Count > 0)
                {
                    xrPrdTransfer xrPT = new xrPrdTransfer(dtReportMostly, dtReportParts);
                    xrPT.ShowPreviewDialog();
                }
                else
                {
                    MessageBox.Show("沒有生產單明細數據！");
                }
            }
            else
            {
                MessageBox.Show("沒有需要列印的數據！");
            }
        }

        /// <summary>
        /// 生成打印數據
        /// </summary>
        private void GenerateDataForPrint()
        {
            //dtPrint此表目的是去掉重覆的記錄，以此表循環逐條取出生產單的相關數據
            dtPrint.Clear();
            string strFilter = "";
            string wp_id = "";
            string mo_id = "";
            string mat_id = "";
            //string next_wp_id = "";
            int per_qty=0;
            string perqty = "";
            for (int i = 0; i <gridView1.RowCount ; i++)
            {
                if (gridView1.GetRowCellValue(i,"print_select").ToString()=="True")
                {
                    wp_id = gridView1.GetRowCellValue(i, "wp_id").ToString();//dgvTransfer.Rows[i].Cells["colIn_dept"].Value.ToString();
                    mo_id = gridView1.GetRowCellValue(i, "mo_id").ToString();// dgvTransfer.Rows[i].Cells["colMo_id"].Value.ToString();
                    mat_id = gridView1.GetRowCellValue(i, "goods_id").ToString(); //dgvTransfer.Rows[i].Cells["colGoods_id"].Value.ToString();
                    perqty = gridView1.GetRowCellValue(i, "per_qty").ToString();
                    per_qty = string.IsNullOrEmpty(perqty) ? 0 : int.Parse(perqty);
                    strFilter = string.Format("wp_id='{0}' and mo_id='{1}' and goods_id='{2}'", wp_id, mo_id, mat_id);
                    DataRow[] dr = dtPrint.Select(strFilter);
                    if (dr.Length == 0)//是否已存在記錄
                    {
                        dtPrint.Rows.Add(new object[] { wp_id, mo_id, mat_id, per_qty });
                    }
                }
            }

            dtReportMostly.Rows.Clear();
            dtReportParts.Rows.Clear();
            string isPrintQc = "";
            if (chkNoQc.Checked)
                isPrintQc = "1";//不顯示QC
            else
                isPrintQc = "0";
            DataTable dtTempMostly = new DataTable();
            DataTable dtTempParts = new DataTable();
            for (int i = 0; i < dtPrint.Rows.Count; i++)
            {
                wp_id = dtPrint.Rows[i]["wp_id"].ToString();
                mo_id = dtPrint.Rows[i]["mo_id"].ToString();
                mat_id = dtPrint.Rows[i]["goods_id"].ToString();
                per_qty = int.Parse(dtPrint.Rows[i]["per_qty"].ToString());

                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@mo_id",mo_id),
                    new SqlParameter("@wp_id",wp_id),
                    new SqlParameter("@materiel_id",mat_id),
                    new SqlParameter("@per_qty",per_qty),
                    new SqlParameter("@isPrintQc",isPrintQc),
                    new SqlParameter("@type","2") //@type="2"從部門生產計劃單中列印生產單
                };

                DataSet dsTempData = clsConErp.ExecuteProcedureReturnDataSet("z_rpt_prdtranser", paras, null);
                
                //分別將數據插入主表及從表
                dtTempMostly = dsTempData.Tables[0];//主表
                if (dtTempMostly.Rows.Count > 0)
                {
                    if (dtReportMostly.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtTempMostly.Rows.Count; j++)
                        {
                            //一個頁數有可能一次收多個批次的貨
                            //所以有必要多作個判斷，以防重入重覆的記錄
                            strFilter = string.Format("wp_id='{0}' and mo_id='{1}' and goods_id='{2}'", dtTempMostly.Rows[j]["wp_id"], dtTempMostly.Rows[j]["mo_id"], dtTempMostly.Rows[j]["goods_id"]);
                            //檢查是否已存在記錄
                            DataRow[] dr = dtReportMostly.Select(strFilter);
                            if (dr.Length == 0)
                            {
                                dtReportMostly.ImportRow(dtTempMostly.Rows[j]);
                            }
                        }
                    }
                    else
                    {
                        dtReportMostly = dtTempMostly;
                    }
                    //添加配件
                    dtTempParts = dsTempData.Tables[1];
                    if (dtReportParts.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtTempParts.Rows.Count; j++)
                        {
                            strFilter = string.Format(@"wp_id='{0}' and mo_id='{1}' and goods_id='{2}' and part_goods_id='{3}'",
                            dtTempParts.Rows[j]["wp_id"], dtTempParts.Rows[j]["mo_id"], dtTempParts.Rows[j]["goods_id"], dtTempParts.Rows[j]["part_goods_id"]);
                            //檢查是否已存在記錄
                            DataRow[] dr = dtReportParts.Select(strFilter);
                            if (dr.Length == 0)
                            {
                                dtReportParts.ImportRow(dtTempParts.Rows[j]);
                            }
                        }
                    }
                    else
                    {
                        dtReportParts = dtTempParts;
                    }
                }
            }
        }

        private void colPrintSelect_MouseUp(object sender, MouseEventArgs e)
        {
            gridView1.CloseEditor();//使更改有效
            int cur_row = gridView1.FocusedRowHandle;            
            if (gridView1.GetRowCellValue(cur_row, "print_select").ToString() == "True")
            {
                string ls_prod_date = clsUtility.GetCurrentDateTime();
                ls_prod_date = DateTime.Parse(ls_prod_date).Date.ToString("yyyy/MM/dd");                
                gridView1.SetRowCellValue(cur_row, "prod_date", ls_prod_date);
            }
        }
      
    }        
}
