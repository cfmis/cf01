using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmProductionRepair_Find : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private DataTable dtReport = new DataTable();
        public frmProductionRepair_Find()
        {
            InitializeComponent();
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            clsApp.Initialize_find_value(this.Name, this.panelControl1.Controls);
            radioGroup2.SelectedIndex = 2;           
            chkSelectAll.Checked = false;      
        }

        private void frmProductionRepair_Find_Load(object sender, EventArgs e)
        {
            chkSelectAll.Enabled = BTNACSETTING.Enabled;
            //這兩列是否可編號
            this.is_ac_deduct.OptionsColumn.AllowEdit = BTNACSETTING.Enabled;
            this.ac_bill_id.OptionsColumn.AllowEdit = BTNACSETTING.Enabled;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            clsApp = null;
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void FindData()
        {
            string dat1,dat2 ;
            if (dtDate1.Text != "")
                dat1 = Convert.ToDateTime(dtDate1.Text).ToString("yyyy/MM/dd");
            else
                dat1 = "";
            if (dtDate2.Text != "")
                dat2 = Convert.ToDateTime(dtDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            else
                dat2 = "";
            int li_deduct_amount_state = radioGroup1.SelectedIndex;
            int li_ac_deduct = radioGroup2.SelectedIndex;
            dtReport = clsMoRepair.Find_Data(txtDept1.Text, txtDept2.Text, txtVendor_id1.Text, txtVendor_id2.Text,
                dat1, dat2, txtMo_id1.Text, txtMo_id2.Text, txtId1.Text, txtId2.Text, li_deduct_amount_state, li_ac_deduct);
            gcDetails.DataSource = dtReport;
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查找條件的數據!", "提示信息");
            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            ReturnValue();
        }
       
        private void ReturnValue()
        {
            frmProductionRepair.query_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "id").ToString();
            clsApp = null;
            Close();
        }

        /// <summary>
        /// 雙擊退出
        /// </summary>
        private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        {           
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = dgvDetails.CalcHitInfo(new Point(e.X, e.Y));
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    ////判断光标是否在行范围内  
            //    //if (hInfo.InRow)
            //    //{
            //    //    ReturnValue();
            //    //}           
            //}
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }    

        private void dtDate1_Leave(object sender, EventArgs e)
        {
            dtDate2.EditValue = dtDate1.EditValue;
        }

        private void Vendor_id1_Leave(object sender, EventArgs e)
        {
            txtVendor_id2.Text = txtVendor_id1.Text;
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.Text = txtDept1.Text;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.panelControl1.Controls) > 0)                           
                clsUtility.myMessageBox("當前查詢條件保存成功!", "提示信息");            
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (xrProductionRepair myRpt = new xrProductionRepair(dtDate1.Text, dtDate2.Text) { DataSource = dtReport })
            {
                myRpt.CreateDocument();
                myRpt.PrintingSystem.ShowMarginsWarning = false;
                myRpt.ShowPreviewDialog();
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出需匯出之數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Export To Excel",
                Filter = "Excel files (*.xls)|*.xls"
            };
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                dgvDetails.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("匯出EXCEL成功！", "提示信息");
            }
        }

        private void clIs_ac_deduct_MouseUp(object sender, MouseEventArgs e)
        {
            //if (!m_ac_confirm)
            //{
            //    clIs_ac_deduct.ValueChecked = false;
            //    return;
            //}
        }

        private void chkSelectAll_MouseUp(object sender, MouseEventArgs e)
        {
            if (BTNACSETTING.Enabled)
            {
                if (dgvDetails.RowCount > 0)
                {
                    bool is_select_all;
                    if (chkSelectAll.Checked)
                        is_select_all = true;
                    else
                        is_select_all = false;
                    for (int i = 0; i < dgvDetails.RowCount; i++)
                    {
                        dgvDetails.SetRowCellValue(i, "is_ac_deduct", is_select_all);
                    }
                }
                else
                {
                    if (chkSelectAll.Checked)
                    {
                        chkSelectAll.Checked = false;
                    }
                }

            }
            else
            {
                if (chkSelectAll.Checked)
                {
                    chkSelectAll.Checked = false;
                }
            }
        }

        private void BTNACSETTING_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount>0)
            {
                //bool is_selected = false;                
                //for (int i = 0; i < dgvDetails.RowCount; i++)
                //{
                //    if (dgvDetails.GetRowCellValue(i, "is_ac_deduct").ToString() == "True")
                //    {
                //        is_selected = true;
                //        break;
                //    }
                //}
                //if (!is_selected)
                //{
                //    MessageBox.Show("請首先在財務扣款狀態欄上設置好狀態！");
                //    return;
                //}
                string sql_u = "";
                string rowStatus;
                int li_is_ac_deduct;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {                    
                    rowStatus = dgvDetails.GetDataRow(i).RowState.ToString();
                    if (rowStatus == "Modified")
                    {

                        if (dgvDetails.GetRowCellValue(i, "is_ac_deduct").ToString() == "True")
                        {
                            li_is_ac_deduct = 1;
                        }
                        else
                        {
                            li_is_ac_deduct = 0;
                        }
                        sql_u = string.Format(@"UPDATE dbo.jo_pp_repair_details SET is_ac_deduct={0},ac_bill_id='{1}' WHERE id='{2}' and sequence_id='{3}'",
                               li_is_ac_deduct, dgvDetails.GetRowCellValue(i, "ac_bill_id"), dgvDetails.GetRowCellValue(i, "id"), dgvDetails.GetRowCellValue(i, "sequence_id"));
                        clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                    }

                }
                clsUtility.myMessageBox("更新成功！", "提示信息");
                dgvDetails.CloseEditor();
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (BTNACSETTING.Selected)
            {
                txtId2.Focus();
            }
        }

    
      
    }
}
