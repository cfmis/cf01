/*
 * Create Date:2026-04-23
 * Create by Allen Leung
 * 程序備註：收發貨記錄
 * 內部工序發給外廠加工
 * transfer_flag：0--發貨;1--收貨
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
    public partial class frmProductTransfer : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        DataSet dtsOutIn = new DataSet();
        DataTable dtDetails = new DataTable();
        clsToolBarNew objToolbar;


        public frmProductTransfer()
        {
            InitializeComponent();
            //權限
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();
            clsApp.Initialize_find_value(this.Name, this.panel1.Controls);
        }

        private void frmProductTransfer_Load(object sender, EventArgs e)
        {
            DataTable dtDept = clsBaseData.Get_Department();
            DataRow drow = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(drow, 0);
            txtWip_id.Properties.DataSource = dtDept;
            txtWip_id.Properties.ValueMember = "id";
            txtWip_id.Properties.DisplayMember = "cdesc";

            string strSql = 
            @"SELECT '' AS id,'' AS cdesc Union SELECT work_group,group_desc
            FROM dgcf_pad.dbo.work_group
            WHERE work_group Like 'W%'";
            DataTable dtWork = clsPublicOfPad.GetDataTable(strSql);            
            lueWork_sort.Properties.DataSource = dtWork;
            lueWork_sort.Properties.ValueMember = "id";
            lueWork_sort.Properties.DisplayMember = "cdesc";
            cmbTransfer_flag.SelectedIndex = 2;
            radioGroup1.SelectedIndex = 0;
            gridControl1.MainView = gridView2;
            gridView1.Columns["select_flag"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns["transfer_date"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns["prd_mo"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {    
            string wipId = string.IsNullOrEmpty(txtWip_id.EditValue.ToString()) ? "" : txtWip_id.EditValue.ToString();
            string prdItem = string.IsNullOrEmpty(txtPrd_item.Text) ? "" : txtPrd_item.Text;
            string moId1 = txtPrd_mo1.Text, moId2 = txtPrd_mo2.Text;
            string crTim1 = string.IsNullOrEmpty(txtCrtim1.Text) ? "": txtCrtim1.EditValue.ToString();                
            string crTim2 = string.IsNullOrEmpty(txtCrtim2.Text) ? "" : txtCrtim2.EditValue.ToString();
            string salesGroup = txtGroup.Text;
            string transferFlagIndex = cmbTransfer_flag.SelectedIndex.ToString();
            string workGroup = lueWork_sort.EditValue.ToString();
            crTim1 = string.IsNullOrEmpty(crTim1) ? "": DateTime.Parse(crTim1).ToString("yyyy/MM/dd HH:mm") ;
            crTim2 = string.IsNullOrEmpty(crTim2) ? "": DateTime.Parse(crTim2).ToString("yyyy/MM/dd HH:mm") ;

            if (wipId == "" && prdItem == "" && moId1 == "" && moId2 == "" && crTim1 == "" && crTim2 == "" 
                && salesGroup == "" && workGroup == "" && transferFlagIndex == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (transferFlagIndex == "2" || transferFlagIndex=="-1")
            {
                transferFlagIndex = ""; //代表全部
            }
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@wipId", wipId),
                new SqlParameter("@prdItem",prdItem),
                new SqlParameter("@moId1", moId1),
                new SqlParameter("@moId2", moId2),
                new SqlParameter("@crTim1", crTim1),
                new SqlParameter("@crTim2", crTim2),
                new SqlParameter("@salesGroup", salesGroup),
                new SqlParameter("@transferFlagIndex", transferFlagIndex),
                new SqlParameter("@workGroup", workGroup)
            };
            //開始顯示進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //**********
            dtsOutIn = clsPublicOfPad.ExecuteProcedureReturnDataSet("usp_product_transfer_summary", paras,"");
            //**********
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            //結束顯示進度

            if (radioGroup1.SelectedIndex == 0)
            {
                gridControl1.MainView = gridView2;//切換致匯總視圖
                dtDetails = dtsOutIn.Tables[1];
            }
            else
            {
                gridControl1.MainView = gridView1;//切換致明細視圖
                dtDetails = dtsOutIn.Tables[0];
            }            
            gridControl1.DataSource = dtDetails;
        }

        private void txtCrtim1_Leave(object sender, EventArgs e)
        {
            if (txtCrtim1.Text != "")
            {
                txtCrtim2.EditValue = txtCrtim1.EditValue;
            }
        }

        private void txtPrd_mo1_Leave(object sender, EventArgs e)
        {
            if (txtPrd_mo1.Text != "")
            {
                txtPrd_mo2.Text = txtPrd_mo1.Text;
            }
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
            if (dtsOutIn.Tables.Count == 0)
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

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            gridView1.CloseEditor();
            bool flagSelect = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "select_flag").ToString() == "True" && gridView1.GetRowCellValue(i, "flag_desc").ToString()== "發貨")
                {
                    flagSelect = true;
                    break;
                }
            }
            if (flagSelect == false)
            {
                MessageBox.Show("請至少選中一條發貨記錄！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string flag_desc = "";
            string sql_i = "", prd_dep = "", prd_mo = "", prd_item = "", wip_id = "", to_dep = "", transfer_date = "", transfer_flag = "", Crusr = DBUtility._user_id, work_sort = "";
            int pack_num = 0;
            decimal transfer_qty = 0, transfer_weg = 0;            
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                sql_i = "";
                flag_desc = gridView1.GetRowCellValue(i, "flag_desc").ToString();
                if (gridView1.GetRowCellValue(i, "select_flag").ToString() == "True" && flag_desc== "發貨")
                {
                    transfer_qty = decimal.Parse(gridView1.GetRowCellValue(i, "transfer_qty").ToString());
                    if (transfer_qty > 0)
                    {
                        prd_dep = gridView1.GetRowCellValue(i, "wip_id").ToString();
                        prd_mo = gridView1.GetRowCellValue(i, "prd_mo").ToString();
                        prd_item = gridView1.GetRowCellValue(i, "prd_item").ToString();
                        wip_id = gridView1.GetRowCellValue(i, "wip_id").ToString();
                        to_dep = gridView1.GetRowCellValue(i, "to_dep").ToString();
                        transfer_date = gridView1.GetRowCellValue(i, "manual_date").ToString();
                        if (!string.IsNullOrEmpty(transfer_date))
                        {
                            transfer_date = DateTime.Parse(transfer_date).Date.ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            transfer_date = DateTime.Now.Date.ToString("yyyy/MM/dd");
                        }
                        transfer_weg = decimal.Parse(gridView1.GetRowCellValue(i, "transfer_weg").ToString());
                        work_sort = gridView1.GetRowCellValue(i, "work_sort").ToString();//工序類型
                        transfer_flag = "1";//收貨
                        pack_num = 0;
                        sql_i = string.Format(
                        @" Insert Into product_transfer_jx_details(Prd_dep,Prd_mo,Prd_item,wip_id,to_dep,Transfer_date,Transfer_qty,Transfer_weg,Transfer_flag,pack_num,Crusr,Crtim,work_sort)
                        VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}',{9},'{10}',GETDATE(),'{11}')",
                        prd_dep, prd_mo, prd_item, wip_id, to_dep, transfer_date, transfer_qty, transfer_weg, transfer_flag, pack_num, Crusr, work_sort);
                        sb.Append(sql_i);
                    }
                }
            }
            sql_i = sb.ToString().Trim();
            if (sql_i.Length > 0)
            {
                int result = clsPublicOfPad.ExecuteSqlUpdate(sql_i);
                if (result > 0)
                {
                    MessageBox.Show("手動添加收貨記錄成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除打勾標識
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, "select_flag").ToString() == "True")
                        {
                            gridView1.SetRowCellValue(i, "select_flag", false);
                        }
                    }
                    gridView1.CloseEditor();
                }
                else
                {
                    MessageBox.Show($"手動添加收貨記錄失敗！\n\r{result}", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } //SAVE

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtsOutIn.Tables.Count == 0)
            {
                return;
            }
            if (radioGroup1.SelectedIndex==0)
            {
                dtDetails = dtsOutIn.Tables[1];//匯總
                gridControl1.MainView = gridView2;
            }
            else
            {
                dtDetails = dtsOutIn.Tables[0];//明細
                gridControl1.MainView = gridView1;
            }
            gridControl1.DataSource = dtDetails;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            ////string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            ////if (rowStatus == "Added" || rowStatus == "Modified")
            ////外發加工單沒有設置單價相關信息是設當前行背景顏色為紅色
            string selectFlag = gridView1.GetRowCellValue(e.RowHandle, "select_flag").ToString();
            if (selectFlag == "True")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LightYellow;// Color.YellowGreen;
            }
        }
    }
}
