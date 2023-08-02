using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using cf01.CLS;
using cf01.Forms;

namespace cf01.MM
{
    public partial class frmProductProcessCost : Form
    {
        public frmProductProcessCost()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!findVaildData())
                return;
            findData();
        }
        private void findData()
        {
            txtPrd_dep.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //**********************
            findDataProcess(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (dgvDetails.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private bool findVaildData()
        {

            if (rdgSource.SelectedIndex != 1)
            {
                if (txtPrd_dep.Text.Trim() == "")
                {
                    MessageBox.Show("部門不能為空!");
                    txtPrd_dep.Focus();
                    return false;
                }
                if (txtPlanDateFrom.EditValue == null || txtPlanDateFrom.EditValue.ToString() == "")
                {
                    MessageBox.Show("計劃單日期為空!");
                    txtPlanDateFrom.Focus();
                    return false;
                }
                if (txtPlanDateTo.EditValue == null || txtPlanDateTo.EditValue.ToString() == "")
                {
                    MessageBox.Show("計劃單日期為空!");
                    txtPlanDateTo.Focus();
                    return false;
                }
            }
            else
            {
                if (txtPrd_item.Text == "" && txtPrd_item_cdesc.Text == "")
                {
                    MessageBox.Show("物料編號查詢條件太少!");
                    txtPrd_item.Focus();
                    return false;
                }
            }
            return true;
        }
        private void findDataProcess()
        {
            string Prd_dep = txtPrd_dep.Text;
            string prd_item = txtPrd_item.Text;
            string Machine_from = txtMachineFrom.Text;
            string Machine_to = txtMachineTo.Text;
            if (Machine_to != "")
                Machine_to = Machine_to + "ZZZ";
            int Source_type = rdgSource.SelectedIndex;
            int Is_set = rdgIs_set.SelectedIndex;
            string Plan_date_from=txtPlanDateFrom.Text;
            string Plan_date_to=txtPlanDateTo.Text;
            string strSql = "usp_ProductProcessCost";
            SqlParameter[] parameters = {new SqlParameter("@source_type", Source_type)
                        ,new SqlParameter("@is_set", Is_set)
                        ,new SqlParameter("@Prd_dep", Prd_dep)
                        ,new SqlParameter("@prd_item", prd_item)
                        ,new SqlParameter("@Prd_item_cdesc", txtPrd_item_cdesc.Text.Trim())
                        ,new SqlParameter("@plan_date_from", Plan_date_from)
                        ,new SqlParameter("@plan_date_to", Plan_date_to)
                        ,new SqlParameter("@machine_from", Machine_from)
                        ,new SqlParameter("@machine_to", Machine_to)
                        ,new SqlParameter("@job_type_from", txtJobTypeFrom.Text)
                        ,new SqlParameter("@job_type_to", txtJobTypeTo.Text)
                        };


            DataTable dtCost = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, parameters);
            dtCost.Columns.Add("chk_flag", typeof(bool));
            for (int i = 0; i < dtCost.Rows.Count; i++)
            {
                dtCost.Rows[i]["chk_flag"] = false;
            }
            dgvDetails.DataSource = dtCost;
            loadJob_type();
        }

        private void frmProductProcessCost_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            if (frmProductCosting.searchProductId.Length>=18)
            {
                txtPrd_dep.Text = frmProductCosting.searchDepId;
                string productId = frmProductCosting.searchProductId;
                txtPrd_item.Text = productId;
            }
            rdgSource.SelectedIndex = 2;
            rdgIs_set.SelectedIndex = 2;
        }
        private void loadJob_type()
        {
            string strSql = "";
            strSql = "Select Process_id,Process_name,Product_qty,Cost_price" +
                " From jo_dept_product_cost Where Dept_id='" + txtPrd_dep.Text + "'";
            DataTable dtJob_type = clsPublicOfCF01.GetDataTable(strSql);
            lueJob_type.Properties.DataSource = dtJob_type;
            lueJob_type.Properties.ValueMember = "Process_id";
            lueJob_type.Properties.DisplayMember = "Process_name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dgvDetails.Rows.Count==0)
            {
                MessageBox.Show("空的記錄表!");
                return;
            }
            if (txtPrd_dep.Text.ToString() == "")
            {
                MessageBox.Show("部門不能為空!");
                lueJob_type.Focus();
                return;
            }
            bool select_flag = false;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                DataGridViewRow crItem = dgvDetails.Rows[i];
                if ((bool)crItem.Cells["colSelect"].Value == true)
                {
                    select_flag = true;
                    break;
                }
            }
            if (select_flag == false)
            {
                MessageBox.Show("沒有設定的記錄!");
                return;
            }
            int SetType = rdgSetType.SelectedIndex;
            if (SetType == 1)//使用已生產的工種或機器作為公式
            {
                DialogResult dr;
                dr = MessageBox.Show("你選擇以已生產的工種來套用公式，確認是否繼續？", "系統信息", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                    return;
            }
            else
            {
                if (lueJob_type.EditValue == null || lueJob_type.EditValue.ToString() == "")
                {
                    MessageBox.Show("公式代號不能為空!");
                    lueJob_type.Focus();
                    return;
                }
            }
            txtPrd_dep.Focus();
            bool upd_flag = true;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                DataGridViewRow crItem = dgvDetails.Rows[i];
                if ((bool)crItem.Cells["colSelect"].Value == true)
                {
                    string Prd_item = crItem.Cells["colPrd_item"].Value.ToString();
                    string Job_type = "";
                    if (SetType == 1)//使用已生產的工種或機器作為公式
                    {
                        if (txtPrd_dep.Text == "105")
                            Job_type = crItem.Cells["colJob_type"].Value.ToString();
                        else if (txtPrd_dep.Text == "102" || txtPrd_dep.Text == "302")
                            if (crItem.Cells["colPrd_machine"].Value.ToString().Length > 3)
                                Job_type = crItem.Cells["colPrd_machine"].Value.ToString().Substring(0, 3);
                    }
                    if (SetType == 0 || (SetType == 1 && Job_type != ""))
                    {
                        if (updateProductProcessCost(SetType, Prd_item, Job_type) != "")
                        {
                            upd_flag = false;
                            break;
                        }
                    }
                }
            }
            if (upd_flag == true)
                MessageBox.Show("儲存物料成本代號成功!");
            else
                MessageBox.Show("儲存物料成本代號失敗!");
            chkSelect.Checked = false;
            findData();
        }

        private string updateProductProcessCost(int SetType,string Prd_item,string Job_type)
        {
            string Prd_dep = txtPrd_dep.Text;
            string Process_id = "";
            if (SetType == 1)//使用已生產的工種或機器作為公式
                Process_id = Job_type;
            else
                Process_id = lueJob_type.EditValue.ToString();
            string Crusr = "";
            string Crtim = System.DateTime.Now.ToString("yyyy/MM/dd hh:ss:mm");
            string strSql = "";
            strSql = "Select Prd_item From bs_product_process_cost Where Prd_dep='" + Prd_dep + "' And Prd_item='" + Prd_item + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                strSql = "Insert Into bs_product_process_cost (Prd_item,Prd_dep,Process_id,Crusr,Crtim) Values (" + "'" + Prd_item + "','" + Prd_dep + "','" + Process_id + "','"
                    + Crusr + "','" + Crtim + "')";
            else
                strSql = "Update bs_product_process_cost Set Process_id='" + Process_id + "',Crusr='" + Crusr + "',Crtim='" + Crtim + "' Where Prd_item='" + Prd_item + "' And Prd_dep='" + Prd_dep + "'";
            string result=clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            bool chkFlag = chkSelect.Checked;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                DataGridViewRow crItem = dgvDetails.Rows[i];
                crItem.Cells["colSelect"].Value = chkFlag;
            }
        }

        private void txtMachineFrom_Leave(object sender, EventArgs e)
        {
            txtMachineTo.Text = txtMachineFrom.Text;
        }



        private void txtPlanDateFrom_Leave(object sender, EventArgs e)
        {
            txtPlanDateTo.Text = txtPlanDateFrom.Text;
        }



        private void txtJobTypeFrom_Leave(object sender, EventArgs e)
        {
            txtJobTypeTo.Text = txtJobTypeFrom.Text;
        }

        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (frmProductCosting.searchProductId != "")
            {
                DataGridViewRow dgr = dgvDetails.Rows[dgvDetails.CurrentRow.Index];
                if (dgr.Cells["colCost_price"].Value.ToString() != "" && dgr.Cells["colProduct_qty"].Value.ToString() != "")
                {
                    frmProductCosting.searchPrice = Math.Round(
                        Convert.ToDecimal(dgr.Cells["colCost_price"].Value) / Convert.ToDecimal(dgr.Cells["colProduct_qty"].Value)
                        ,4);
                    frmProductCosting.sentDepPrice.depPrice = Math.Round(
                        Convert.ToDecimal(dgr.Cells["colCost_price"].Value) / Convert.ToDecimal(dgr.Cells["colProduct_qty"].Value)
                        , 4);
                    frmProductCosting.sentDepPrice.depStdPrice = Convert.ToDecimal(dgr.Cells["colCost_price"].Value);
                    frmProductCosting.sentDepPrice.depStdQty = Convert.ToDecimal(dgr.Cells["colProduct_qty"].Value);
                }
                this.Close();
            }
        }

    }
}
