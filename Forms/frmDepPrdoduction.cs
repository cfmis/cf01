using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using cf01.ReportForm;
using DevExpress.XtraGrid.Views.Base;

namespace cf01.Forms
{
    public partial class frmDepPrdoduction : Form
    {
        private DataTable dtPrd = new DataTable();
        public frmDepPrdoduction()
        {
            InitializeComponent();
        }

        private void frmDepPrdoduction_Load(object sender, EventArgs e)
        {
            InitControlers();
            if (frmMoSchedule.sendDep != "")
            {
                cmbFindDep.SelectedValue = frmMoSchedule.sendDep;
                
            }
            if (frmMoSchedule.sendDep != "")
            {
                txtPrdMo.Text = frmMoSchedule.send_prd_mo;
                LoadData();
            }
        }
        private void InitControlers()
        {
            DataTable dtPrd_dept = clsBaseData.loadPrdDep();
            cmbFindDep.DataSource = dtPrd_dept;
            cmbFindDep.DisplayMember = "dep_cdesc";
            cmbFindDep.ValueMember = "dep_id";
            //SetCombox();

        }

        private void cmbFindDep_Leave(object sender, EventArgs e)
        {
            cmbDepGroup.DataSource = clsBaseData.loadDocFlag("GROUP_" + cmbFindDep.SelectedValue.ToString().Trim());
            cmbDepGroup.ValueMember = "flag_id";
            cmbDepGroup.DisplayMember = "flag_cdesc";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            cmbDepGroup.Focus();
            LoadData();
        }
        private void LoadData()
        {
            string prd_dep = cmbFindDep.SelectedValue != null ? cmbFindDep.SelectedValue.ToString().Trim() : "";
            string prd_group = cmbDepGroup.SelectedValue != null ? cmbDepGroup.SelectedValue.ToString().Trim() : "";
            string prd_date = txtPrdDate.Text.Trim();
            string prd_mo = txtPrdMo.Text.Trim();
            if (prd_date == "" && prd_mo=="")
            {
                prd_date = System.DateTime.Now.ToString("yyyy/MM/dd");
                txtPrdDate.Text = prd_date;
            }
            dtPrd=clsShowProductionPlan.LoadDepProduction(prd_dep, prd_group, prd_date,prd_mo);
            gcPrd.DataSource = dtPrd;
            CountTotalQty();
        }

        /// /// 統計完成數量、生產時間
        private void CountTotalQty()
        {

            if (dtPrd.Rows.Count > 0)
            {
                object schedule_qty = dtPrd.Compute("SUM(prd_qty)" , "prd_work_type = 'A02'");
                object not_cp_qty = dtPrd.Compute("SUM(prd_qty)", "prd_work_type = 'A03'");
                object req_tot_time = dtPrd.Compute("SUM(prd_time)", "");
                txtPrdQty.Text = clsValidRule.ConvertStrToDecimal(schedule_qty.ToString()).ToString("#,##0");
                txtSelectQty.Text = clsValidRule.ConvertStrToDecimal(not_cp_qty.ToString()).ToString("#,##0");
                txtPrdTime.Text = Math.Round(Convert.ToDecimal(req_tot_time), 2).ToString("#,##0.00");
            }
            else
            {
                txtPrdQty.Text = "0";
                txtSelectQty.Text = "0";
                txtPrdTime.Text = "0";
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
