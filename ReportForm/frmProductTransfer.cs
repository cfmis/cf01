/*
 * Create Date:2026-04-23
 * Create by Allen Leung
 * 程序備註：收發貨記錄
 * 內部工序發給外廠加工
 * transfer_flag：0--發貨;1--收貨
*/



using cf01.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmProductTransfer : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        DataSet dtsOutIn = new DataSet();
        DataTable dtDetails = new DataTable();

        public frmProductTransfer()
        {
            InitializeComponent();
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
            if (!chkSumarry.Checked)
            {
                chkSumarry.Checked = true;
            }
            gridControl1.MainView = gridView2;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {    
            string wipId = string.IsNullOrEmpty(txtWip_id.EditValue.ToString()) ? "" : txtWip_id.EditValue.ToString();
            string prdItem = string.IsNullOrEmpty(txtPrd_item.Text) ? "" : txtPrd_item.Text;
            string moId1 = txtPrd_mo1.Text, moId2 = txtPrd_mo2.Text;
            string crTim1 = txtCrtim1.EditValue.ToString(), crTim2 = txtCrtim2.EditValue.ToString();           
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
            dtsOutIn = clsPublicOfPad.ExecuteProcedureReturnDataSet("usp_product_transfer_summary", paras,"");
            chkSumarry.Checked = true;
            gridControl1.MainView = gridView2;//切換致匯總視圖
            dtDetails = dtsOutIn.Tables[1];
            gridControl1.DataSource = dtDetails;
        }

        private void chkSumarry_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtsOutIn.Tables.Count == 0)
            {
                return;
            }
            if (chkSumarry.Checked)
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
    }
}
