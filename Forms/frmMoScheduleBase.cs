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
            cmbFindDep.SelectedValue = frmMoSchedule.sendDep;
            if(cmbFindDep.SelectedValue.ToString().Trim()!="")
            {
                LoadData();
            }
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
                txtWorkIn1.Text = dr["work_in1"].ToString();
                txtWorkOut1.Text = dr["work_out1"].ToString();
                txtWorkIn2.Text = dr["work_in2"].ToString();
                txtWorkOut2.Text = dr["work_out2"].ToString();
                txtWorkIn3.Text = dr["work_in3"].ToString();
                txtWorkOut3.Text = dr["work_out3"].ToString();
                txtBreakIn3.Text = dr["break_in3"].ToString();
                txtBreakOut3.Text = dr["break_out3"].ToString();
                txtBreakIn4.Text = dr["break_in4"].ToString();
                txtBreakOut4.Text = dr["break_out4"].ToString();
            }
            else
            {
                txtStartPrdTime.Text = "";
                txtNoonBreak.Text = "";
                txtAfternoonBreak.Text = "";
                txtEveningBreak.Text = "";
                txtWorkIn1.Text = "";
                txtWorkOut1.Text = "";
                txtWorkIn2.Text = "";
                txtWorkOut2.Text = "";
                txtWorkIn3.Text = "";
                txtWorkOut3.Text = "";
                txtBreakIn3.Text = "";
                txtBreakOut3.Text = "";
                txtBreakIn4.Text = "";
                txtBreakOut4.Text = "";
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
            objBase.work_in1 = txtWorkIn1.Text;
            objBase.work_out1 = txtWorkOut1.Text;
            objBase.work_in2 = txtWorkIn2.Text;
            objBase.work_out2 = txtWorkOut2.Text;
            objBase.work_in3 = txtWorkIn3.Text;
            objBase.work_out3 = txtWorkOut3.Text;
            objBase.break_in3 = txtBreakIn3.Text;
            objBase.break_out3 = txtBreakOut3.Text;
            objBase.break_in4 = txtBreakIn4.Text;
            objBase.break_out4 = txtBreakOut4.Text;
            result = clsMoSchedule.SaveScheduleBase(objBase);
            if (result == "")
                MessageBox.Show("更新記錄成功!");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }
    }
}
