using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using cf01.Reports;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmAlloyQuotation: Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO objGEO = new clsPublicOfGEO();
        private DataTable dtCostAlloy = new DataTable();
        //private DataTable dtTempDel = new DataTable();
        private DataTable dtFind = new DataTable();

        public frmAlloyQuotation()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(Name, panel1.Controls);           
        }

        private void frmAlloyQuotation_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsApp = null;
            objGEO = null;
            dtCostAlloy.Dispose();
            //dtTempDel.Dispose();
            dtFind.Dispose();
        }

        private void frmAlloyQuotation_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCheckdate1.Text))
            {
                txtCheckdate1.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (string.IsNullOrEmpty(txtCheckdate2.Text))
            {
                txtCheckdate2.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (string.IsNullOrEmpty(txtDept.Text))
            {
                txtDept.Text = "302";
            }            
            if (string.IsNullOrEmpty(cboReportFormat.Text))
            {
                cboReportFormat.Text = "格式B(不包括已做完全確認)";
            }
            this.ActiveControl = txtCheckdate2;  //設置獲得點的控件必須與txtPassword.Focus()一起使用否則不起作用
            txtCheckdate2.Focus();
            dteDate1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            dteDate2.EditValue = dteDate1.EditValue;
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            txtCheckdate1.Text = "";
            txtCheckdate2.Text = "";
            txtDept.Text = "";           
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        { 
            tbcCost.SelectedIndex =0;
        
            txtDept.Focus();
            if (txtCheckdate1.Text == "" && txtCheckdate2.Text == "" && txtDept.Text == "" && txtDept.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCheckdate1.Focus();
                return;
            }
            int intIndex = cboReportFormat.SelectedIndex;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@check_date1", txtCheckdate1.Text ),
                new SqlParameter("@check_date2", txtCheckdate2.Text),
                new SqlParameter("@dept", txtDept.Text),
                new SqlParameter("@format", intIndex)
            };

            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //************************ 
            dtCostAlloy.Clear();
            dtCostAlloy = objGEO.ExecuteProcedureReturnTable("z_cost_alloy", paras);//数据处理
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            chkSelectAll.Checked = false;
            //dtTempDel = dtCostAlloy.Clone();
            gridControl1.DataSource = dtCostAlloy;
            if (dtCostAlloy.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息");               
                gridControl1.DataSource = dtCostAlloy;                
            }                 
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
            {
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            }
            else
            {
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCheckdate1_Leave(object sender, EventArgs e)
        {
            txtCheckdate2.EditValue = txtCheckdate1.EditValue;
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {            
            Print();
        }

        private void Print()
        {
            tbcCost.SelectedIndex = 1;
            if (dtFind.Rows.Count > 0)
            {
                using (xrAlloyQuotation myReport1 = new xrAlloyQuotation() { DataSource = dtFind })
                {
                    myReport1.CreateDocument();
                    myReport1.PrintingSystem.ShowMarginsWarning = false;
                    myReport1.ShowPreviewDialog();
                }
            }
            else
            {
                MessageBox.Show("確認要生成報價!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }        
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DialogResult result = MessageBox.Show("確認要生成報價？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                txtDept.Focus();
                gridView1.CloseEditor();
                bool isSelect = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "select_flag").ToString() == "True")
                    {
                        isSelect = true;
                        break;
                    }
                }
                if (!isSelect)
                {
                    MessageBox.Show("請首先選擇要生成報價單的記錄!", "提示信息");
                    return;
                }

                isSelect = true;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "select_flag").ToString() == "True" && gridView1.GetRowCellDisplayText(i, "qty_per_set") == "0")
                    {
                        isSelect = false;
                        break;
                    }
                }
                
                if (!isSelect)
                {
                    MessageBox.Show("請輸入排位數!", "提示信息");
                    return;
                }

                bool isSave = clsCostAlloy.Save_Quotation(gridView1);
                if (isSave)
                {
                    //移走表格中已成功生成報價價單的記錄，避免重復做
                    //采用倒序循环刪除,因为正序删除时索引会发生变化
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        if (gridView1.GetRowCellValue(i,"select_flag").ToString() == "True" && gridView1.GetRowCellValue(i,"id").ToString() == "0")
                        {
                            gridView1.DeleteRow(i);//移走當前行
                        }
                    }
                    MessageBox.Show("生成報價單數據成功!", "提示信息");
                }
                else
                {
                    MessageBox.Show("生成報價單數據失敗!", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                //dtTempDel.Clear();
            }
            else
            {
                MessageBox.Show("沒有要保存的數據!", "提示信息");
            }

        }
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            //string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            //if (rowStatus == "Added" || rowStatus == "Modified")
            //曾報過價的行背景顏色
            string strId = gridView1.GetRowCellValue(e.RowHandle, "id").ToString();
            if (strId !="0")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.SkyBlue;
            }
            //更改排位后的字體顏色
            if(gridView1.GetRowCellValue(e.RowHandle, "qty_per_set").ToString() != gridView1.GetRowCellValue(e.RowHandle, "qty_per_set_original").ToString())
            {
                e.Appearance.ForeColor = Color.Brown;//.BlueViolet;//.Maroon;
            }
            else
            {
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                bool isSelect;
                if (chkSelectAll.Checked)
                {
                    isSelect = true;
                }
                else
                {
                    isSelect = false;
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, "select_flag", isSelect);
                }
            }
            else
            {
                chkSelectAll.Checked = false;
            }
        }

        private void clQty_Leave(object sender, EventArgs e)
        {
            gridView1.CloseEditor();//此行很重要,輸入值立即有較
            int intRow=gridView1.FocusedRowHandle;
            if (int.Parse(gridView1.GetRowCellValue(intRow, "qty_per_set").ToString()) == 0)
            {
                return;
            }
            //已有報價的資料禁止再次更改排位數
            if (int.Parse(gridView1.GetRowCellValue(intRow, "id").ToString()) > 0)
            {
                gridView1.SetRowCellValue(intRow, "qty_per_set", gridView1.GetRowCellDisplayText(intRow, "qty_per_set_original"));
                    //int.Parse(gridView1.GetRowCellValue(intRow, "qty_per_set_original").ToString()));     
                MessageBox.Show("此行已生成過報價單,當前更改無效！", "提示信息");
                return;
            }
            Cost_Calc(gridView1, intRow);
        }

        private void clCompany_Leave(object sender, EventArgs e)
        {             
            //已有報價的資料禁止再次更改公司欄位
            int cur_row = gridView1.FocusedRowHandle;
            if (int.Parse(gridView1.GetRowCellValue(cur_row, "id").ToString()) > 0)
            {
                MessageBox.Show("此行已生成過報價單,當前更改無效！", "提示信息");
                return;
            }
            gridView1.CloseEditor();
            Cost_Calc(gridView1, cur_row);
        }

        private void Cost_Calc(DevExpress.XtraGrid.Views.Grid.GridView gdvCost, int cur_row)
        {
            int intQty_per_set, intProd_qty;
            float fltCost_per_pcs,fltCost_total;
            intQty_per_set = int.Parse(gdvCost.GetRowCellValue(cur_row, "qty_per_set").ToString());
            intProd_qty = int.Parse(gdvCost.GetRowCellValue(cur_row, "prod_qty").ToString());
            string strCompany = gdvCost.GetRowCellValue(cur_row, "company").ToString();
            //fltCost_per_pcs = clsApp.Return_Float_Value(gridView1.GetRowCellValue(cur_row, "cost_per_pcs").ToString());
            string strSql = string.Format(@"select cost_pcs+cost_process as cost_per_pcs from dbo.pp_cost_mould where dept_id='302' and company='{0}' and id='{1}'", strCompany, intQty_per_set);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                fltCost_per_pcs = clsApp.Return_Float_Value(dt.Rows[0]["cost_per_pcs"].ToString());
                fltCost_total = intProd_qty * fltCost_per_pcs;
                gdvCost.SetRowCellValue(cur_row, "cost_per_pcs", fltCost_per_pcs);
                gdvCost.SetRowCellValue(cur_row, "cost_total", fltCost_total);
            }
            else
            {
                gdvCost.SetRowCellValue(cur_row, "qty_per_set", 0);
                gdvCost.SetRowCellValue(cur_row, "cost_total", 0);
                MessageBox.Show("注意：尚未有對應的排位數！","提示信息");
                return;
            }            
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }          

            int intId;
            int curRow = gridView1.FocusedRowHandle;
            intId = int.Parse(gridView1.GetRowCellValue(curRow, "id").ToString());
            if (intId == 0)
            {
                MessageBox.Show("尚未生成報價單記錄無需刪除當前記錄！", "提示信息");
                return;
            }

            //if (gridView1.GetRowCellDisplayText(curRow, "state_approve") == "已審批")
            //{
            //    MessageBox.Show("已審批,不可以再刪除！", "提示信息");
            //    return;
            //}

            DialogResult result = MessageBox.Show("確定刪除當前記錄？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (clsCostAlloy.Delete_Quotation(intId))
                {
                    MessageBox.Show("刪除當前記錄成功！", "提示信息");
                }
                else
                {
                    MessageBox.Show("刪除當前記錄失敗！", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                ////將當前行刪除幷加到臨時表中
                //DataRow dr = dtTempDel.NewRow();
                //dr["id"] = intId;// gridView1.GetRowCellDisplayText(curRow, "id");//主鍵                
                ////dr["mo_id"] = gridView1.GetRowCellDisplayText(curRow, "mo_id");
                ////dr["goods_id"] = gridView1.GetRowCellDisplayText(curRow, "goods_id");
                //dtTempDel.Rows.Add(dr);
                //gridView1.DeleteRow(curRow);//移走當前行
            }
        }

        private void dteDate1_Leave(object sender, EventArgs e)
        {
            dteDate2.EditValue = dteDate1.EditValue;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dteDate1.Text == "" || dteDate2.Text == "")
            {
                MessageBox.Show("日期不可以為空！", "提示信息");
                return;
            }
            string strDate1, strDate2;
            strDate1 = Convert.ToDateTime(dteDate1.Text).Date.ToString("yyyy-MM-dd");
            strDate2 = Convert.ToDateTime(dteDate2.Text).Date.ToString("yyyy-MM-dd");
            dtFind = clsCostAlloy.GetQuotationData(strDate1, strDate2, cmbCompany1.Text);
            gridControl2.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的數據！", "提示信息");
                return;
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            tbcCost.SelectedIndex = 1;
            if (gridView2.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog() { Title = "导出Excel", Filter = "Excel文件(*.xls)|*.xls" };
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {                   
                    gridControl2.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("請首先查出報價數據！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                set_art_work(gridView1, gridView1.FocusedRowHandle, pic_artwork1);
            }
        }
    

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.RowCount > 0)
            {
                set_art_work(gridView2, gridView2.FocusedRowHandle,pic_artwork2);
            }           
        }

        private static void set_art_work(DevExpress.XtraGrid.Views.Grid.GridView objGrv, int intRowHandle,PictureBox objPic)
        {
            if (objGrv.RowCount > 0)
            {
                string strArtwork = objGrv.GetRowCellValue(intRowHandle, "picture_name").ToString();
                if (!string.IsNullOrEmpty(strArtwork))
                {
                    if (File.Exists(strArtwork))
                    {
                        objPic.Image = Image.FromFile(strArtwork);
                    }
                    else
                    {
                        objPic.Image = null;
                    }
                }
                else
                {
                    objPic.Image = null;
                }
            }
            else
            {
                objPic.Image = null;
            }
        }

        private void clCompany2_Leave(object sender, EventArgs e)
        {
            gridView2.CloseEditor();
            Cost_Calc(gridView2,gridView2.FocusedRowHandle);
        }

        private void clQty2_Leave(object sender, EventArgs e)
        {
            gridView2.CloseEditor();//輸入值立即有較 
            Cost_Calc(gridView2, gridView2.FocusedRowHandle);
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView2.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            //string rowStatus = gridView2.GetDataRow(e.RowHandle).RowState.ToString();
            if (gridView2.GetRowCellValue(e.RowHandle, "company").ToString() != gridView2.GetRowCellValue(e.RowHandle, "org_company").ToString() ||
                gridView2.GetRowCellValue(e.RowHandle, "qty_per_set").ToString() != gridView2.GetRowCellValue(e.RowHandle, "org_qty_per_set").ToString())
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void btnSaveQuo_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled)
            {
                MessageBox.Show("當前用戶沒有此更改權限！", "提示信息");
                return;
            }
            if (gridView2.RowCount > 0)
            {
                DialogResult result = MessageBox.Show("確認要修改報價單？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                if (clsCostAlloy.Modify_Quotation(gridView2))
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, "company").ToString() != gridView2.GetRowCellValue(i, "org_company").ToString() ||
                           gridView2.GetRowCellValue(i, "qty_per_set").ToString() != gridView2.GetRowCellValue(i, "org_qty_per_set").ToString())
                        {
                            gridView2.SetRowCellValue(i, "org_company", gridView2.GetRowCellValue(i, "company").ToString());
                            gridView2.SetRowCellValue(i, "org_qty_per_set", gridView2.GetRowCellValue(i, "qty_per_set").ToString());
                        }
                    }
                    MessageBox.Show("報價單數據更新成功！", "提示信息");
                }
                else
                {
                    MessageBox.Show("報價單數據更新失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
