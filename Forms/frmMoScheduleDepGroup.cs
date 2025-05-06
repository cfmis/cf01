using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmMoScheduleDepGroup : Form
    {
        public static string prd_group = "";
        public frmMoScheduleDepGroup()
        {
            InitializeComponent();
        }

        private void frmMoScheduleDepGroup_Load(object sender, EventArgs e)
        {
            InitData();
            FindData();
        }
        private void InitData()
        {
            txtPrdMo.Text = frmMoSchedule.send_prd_mo;
            txtPrdItem.Text = frmMoSchedule.send_prd_item;
            lueDepGroup.Properties.DataSource = clsBaseData.loadScheduleDepGroup(frmMoSchedule.sendDep);
            lueDepGroup.Properties.ValueMember = "grp_code";
            lueDepGroup.Properties.DisplayMember = "grp_cdesc";
        }
        private void FindData()
        {
            DataTable dtMo = clsMoSchedule.GetWipData(frmMoSchedule.sendDep, txtPrdMo.Text.Trim(), txtPrdItem.Text.Trim());
            dgvDetails.DataSource = dtMo;
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            prd_group = lueDepGroup.EditValue != null ? lueDepGroup.EditValue.ToString().Trim() : "";
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
