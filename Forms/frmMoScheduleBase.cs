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




namespace cf01.Forms
{
    public partial class frmMoScheduleBase : Form
    {
        public frmMoScheduleBase()
        {
            InitializeComponent();
        }
        private void frmMoScheduleBase_Load(object sender, EventArgs e)
        {
            InitControlers();
        }
        private void InitControlers()
        {
            DataTable dtPrd_dept = clsBaseData.loadPrdDep();
            cmbFindDep.DataSource = dtPrd_dept;
            cmbFindDep.DisplayMember = "dep_cdesc";
            cmbFindDep.ValueMember = "dep_id";
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFindDep_Leave(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataTable dtScheduleBase = clsMoSchedule.LoadScheduleBase(cmbFindDep.SelectedValue.ToString().Trim());
            if(dtScheduleBase.Rows.Count>0)
            {
                DataRow dr = dtScheduleBase.Rows[0];
                txtStartPrdTime.Text = dr["start_prd_time"].ToString();
                txtNoonBreak.Text = dr["noon_break"].ToString();
                txtAfternoonBreak.Text = dr["afternoon_break"].ToString();
                txtEveningBreak.Text = dr["evening_break"].ToString();
            }else
            {
                txtStartPrdTime.Text = "";
                txtNoonBreak.Text = "";
                txtAfternoonBreak.Text = "";
                txtEveningBreak.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            string result = "";
            mdlMoScheduleBase objBase = new mdlMoScheduleBase();
            objBase.prd_dep = cmbFindDep.SelectedValue.ToString().ToString();
            objBase.schedule_date = "2025";
            objBase.start_prd_time = txtStartPrdTime.Text;
            objBase.noon_break = Convert.ToDecimal(txtNoonBreak.Text);
            objBase.afternoon_break = Convert.ToDecimal(txtAfternoonBreak.Text);
            objBase.evening_break = Convert.ToDecimal(txtEveningBreak.Text);
            result = clsMoSchedule.SaveScheduleBase(objBase);
            if (result == "")
                MessageBox.Show("更新記錄成功!");
        }
    }
}
