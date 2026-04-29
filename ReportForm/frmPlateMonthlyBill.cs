/*
 * Create Date:2026-04-27
 * Create by Allen Leung
 * 程序備註：外發收發月結單
*/

using cf01.CLS;
using cf01.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmPlateMonthlyBill : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        DataSet dtsData = new DataSet();
        DataTable dtDetails = new DataTable();
        DataTable dtVendor = new DataTable();

        public frmPlateMonthlyBill()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.panel1.Controls);
        }

        private void frmPlateMonthlyBill_Load(object sender, EventArgs e)
        {
            string strSql =string.Format(
            @"SELECT '' AS id,'' AS cdesc Union SELECT id,name FROM {0}it_vendor WHERE ISNULL(Abbrev_id,'')<>'' ORDER BY id",DBUtility.remote_db);
            DataTable dtVendor = clsPublicOfPad.GetDataTable(strSql);
            txtVend_id1.Properties.DataSource = dtVendor;
            txtVend_id1.Properties.ValueMember = "id";
            txtVend_id1.Properties.DisplayMember = "id";
            txtVend_id2.Properties.DataSource = dtVendor;
            txtVend_id2.Properties.ValueMember = "id";
            txtVend_id2.Properties.DisplayMember = "id";    
            
            if(txtIr_date1.Text =="" && txtIr_date2.Text == "")
            {
                string strDate= DateTime.Now.Date.ToString("yyyy/MM/dd");
                strDate = strDate.Substring(0, 8) + "01";
                txtIr_date1.EditValue = strDate;
                txtIr_date2.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            }

        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {    
            string vend_id1 = string.IsNullOrEmpty(txtVend_id1.EditValue.ToString()) ? "" : txtVend_id1.EditValue.ToString();
            string vend_id2 = string.IsNullOrEmpty(txtVend_id2.EditValue.ToString()) ? "" : txtVend_id2.EditValue.ToString();          
            string ir_date1 = txtIr_date1.EditValue.ToString(), ir_date2 = txtIr_date2.EditValue.ToString();
            ir_date1 = string.IsNullOrEmpty(ir_date1) ? "": DateTime.Parse(ir_date1).ToString("yyyy/MM/dd") ;
            ir_date2 = string.IsNullOrEmpty(ir_date2) ? "": DateTime.Parse(ir_date2).ToString("yyyy/MM/dd") ;
            if (vend_id1 == "" && vend_id2 == "" && ir_date1 == "" && ir_date2 == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((ir_date1 == "" && ir_date2 != "") || (ir_date1 != "" && ir_date2 == ""))
            {
                MessageBox.Show("請意,請輸入完整的起止日期!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@vendor_s", vend_id1),
                new SqlParameter("@vendor_e",vend_id2),
                new SqlParameter("@ir_date_s", ir_date1),
                new SqlParameter("@ir_date_e", ir_date2)
            };
            //顯示進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //***
            dtsData = clsErp.ExecuteProcedureReturnDataSet("z_rpt_plate_monthly_bill", paras, "");
            //***
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });


            dtDetails = dtsData.Tables[0];
            gridControl1.DataSource = dtDetails;
            dtVendor = dtsData.Tables[1];
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.panel1.Controls, "1");
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dtDetails.Rows.Count == 0)
            {
                return;
            }
            ExpToExcel clsXls = new ExpToExcel();
            clsXls.DevGridControlToExcel(gridControl1);
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtIr_date1_Leave(object sender, EventArgs e)
        {
            if (txtIr_date1.Text != "")
            {
                txtIr_date2.EditValue = txtIr_date1.EditValue;
            }
        }

        private void txtVend_id1_Leave(object sender, EventArgs e)
        {
            if(txtVend_id1.Text != "")
            {
                txtVend_id2.EditValue = txtVend_id1.EditValue;
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (gridView1.GetDataRow(e.RowHandle) == null)
            //{
            //    return;
            //}
            ////string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            ////if (rowStatus == "Added" || rowStatus == "Modified")
            ////外發加工單沒有設置單價相關信息是設當前行背景顏色為紅色
            //string amtReceivable = gridView1.GetRowCellValue(e.RowHandle, "amt_receivable").ToString();
            //if (amtReceivable == "0.000000")
            //{
            //    e.Appearance.ForeColor = Color.OrangeRed;
            //    e.Appearance.BackColor = Color.OrangeRed;
            //}
        }

        private void BTNEXCEL2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DataTable dtTemp = dtDetails.Copy();
                clsPlateDelivery.ToExcelMonthlyBill(dtTemp, dtVendor, txtIr_date2.EditValue.ToString());
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //顯示行號
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
