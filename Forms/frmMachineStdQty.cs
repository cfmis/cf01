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
    public partial class frmMachineStdQty : Form
    {
        public static string prd_machine="";
        public static decimal machine_std_run_num = 0;
        public static decimal machine_std_line_num = 0;
        public static decimal machine_std_qty = 0;
        private DataTable dtPrd_dept;
        string strWhere = "";
        string lang_id = DBUtility._language;
        string user_id = DBUtility._user_id;

        clsCommonUse commUse = new clsCommonUse();
        public frmMachineStdQty()
        {
            InitializeComponent();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void count_std_qty()
        {
            if (txtLineNo.Text != "" && txtRunNo.Text != "")
                txtStdQty.Text = (Convert.ToInt32(txtLineNo.Text) * Convert.ToInt32(txtRunNo.Text)).ToString();
        }

        private void txtLineNo_Leave(object sender, EventArgs e)
        {
            count_std_qty();
        }

        private void txtRunNo_Leave(object sender, EventArgs e)
        {
            count_std_qty();
        }
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;
            strSql = "SELECT a.dep,a.machine_id,a.machine_mul,a.machine_rate,a.machine_std_qty";
            strSql += " FROM bs_machine_std a " + strWhere;
            strSql += " ORDER BY a.dep,a.machine_id";
            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "machine_std").Tables["machine_std"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系統信息");
                throw ex;
            }
            if (dgvDetails.RowCount > 0)
            {
                FillControls();
            }
        }
        

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                FillControls();
            }
        }
        private void FillControls()
        {
            int rowIndex = dgvDetails.CurrentRow.Index;
            this.cmbFindDep.SelectedValue = dgvDetails.Rows[rowIndex].Cells["colDep"].Value.ToString();
            this.txtMachine.Text = dgvDetails.Rows[rowIndex].Cells["colPrdMachine"].Value.ToString();
            this.txtLineNo.Text = dgvDetails.Rows[rowIndex].Cells["colLineNo"].Value.ToString();
            this.txtRunNo.Text = dgvDetails.Rows[rowIndex].Cells["colRunQty"].Value.ToString();
            this.txtStdQty.Text = dgvDetails.Rows[rowIndex].Cells["colStdQty"].Value.ToString();
        }
        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtDepGroup.Focus();
            string strCode = "";
            if (chk_data() == false)
                return;
            try
            {
                strCode = "UPDATE bs_machine_std SET machine_mul=@machine_mul,machine_rate=@machine_rate,machine_std_qty=@machine_std_qty ";
                strCode += " WHERE dep = @dep AND machine_id=@machine_id ";

                ParametersAddValue();

                if (commUse.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("儲存成功！", "系統信息");
                    strWhere = " WHERE a.dep = " + "'" + cmbFindDep.SelectedValue.ToString().Trim() + "'" + " and a.machine_id = " + "'" + txtMachine.Text.Trim() + "'";
                    this.BindDataGridView(strWhere);
                }
                else
                {
                    MessageBox.Show("儲存失敗！", "系統信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系統信息");
                throw ex;
            }
        }
        private void ParametersAddValue()
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@dep", cmbFindDep.SelectedValue.ToString().Trim());
            commUse.Cmd.Parameters.AddWithValue("@machine_id", txtMachine.Text.Trim());
            commUse.Cmd.Parameters.AddWithValue("@machine_mul", Convert.ToInt32(txtLineNo.Text));
            commUse.Cmd.Parameters.AddWithValue("@machine_rate", Convert.ToInt32(txtRunNo.Text));
            commUse.Cmd.Parameters.AddWithValue("@machine_std_qty", Convert.ToInt32(txtStdQty.Text));
        }
        private bool chk_data()
        {
            bool chk_flag=true;
            if (txtLineNo.Text == "")
            {
                chk_flag = false;
                MessageBox.Show("行數無效！", "系統信息");
                txtLineNo.Focus();
            }
            if (txtRunNo.Text == "")
            {
                chk_flag = false;
                MessageBox.Show("轉數無效！", "系統信息");
                txtRunNo.Focus();
            }
            if (txtStdQty.Text == "")
            {
                chk_flag = false;
                MessageBox.Show("每小時標準數量無效！", "系統信息");
                txtStdQty.Focus();
            }
            return chk_flag;
        }

        private void frmMachineStdQty_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            InitControlers();
            if (frmMoSchedule.sendDep != "")
            {
                cmbFindDep.SelectedValue = frmMoSchedule.sendDep;
                txtMachine.Text = frmMoSchedule.sendMachine;
                GetDepGroup();
                FindData();
            }
        }
        private void InitControlers()
        {
            dtPrd_dept = clsBaseData.loadPrdDep();
            cmbFindDep.DataSource = dtPrd_dept;
            cmbFindDep.DisplayMember = "dep_cdesc";
            cmbFindDep.ValueMember = "dep_id";

        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            txtDepGroup.Focus();
            FindData();
        }
        private void FindData()
        {
            strWhere = " WHERE a.dep like '%" + cmbFindDep.SelectedValue.ToString().Trim() + "%'"
                + " and a.machine_id like '%" + txtMachine.Text.Trim() + "%'";
            this.BindDataGridView(strWhere);
        }
        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvDetails.CurrentRow.Index;
            prd_machine= dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colPrdMachine"].Value.ToString();
            machine_std_run_num = clsValidRule.ConvertStrToDecimal(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colRunQty"].Value.ToString());
            machine_std_line_num = clsValidRule.ConvertStrToDecimal(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colLineNo"].Value.ToString());
            machine_std_qty = clsValidRule.ConvertStrToDecimal(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["colStdQty"].Value.ToString());
            
            this.Close();
        }

        private void cmbFindDep_Leave(object sender, EventArgs e)
        {
            GetDepGroup();
        }
        private void GetDepGroup()
        {
            DataRow[] drDep = dtPrd_dept.Select("dep_id='" + cmbFindDep.SelectedValue.ToString().Trim() + "'");
            txtDepGroup.Text = drDep[0]["dep_group"].ToString().Trim();
        }
    }
}
