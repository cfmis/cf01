using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmRouting : Form
    {
        private string edit_flag = "0";
        private string userid = DBUtility._user_id;
        private bool append_mode=false;
        private bool edit_mode = false;
        private string within_code = DBUtility.within_code;
        private string remote_db = DBUtility.remote_db;
        public frmRouting()
        {
            InitializeComponent();
        }


        private void frmUnitPriceFormula_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            if (frmRoutingBom.query_goods_id != "")
            {
                //dgvDetails.Columns[0].ReadOnly = false;
                dgvDetails.Columns[0].Visible = true;
            }
            initControls();
            setTextBoxEnabled();
            loadData("");
        }
        private void initControls()
        {
            string strSql = " Select dep_id AS 部門編號,dep_cdesc AS 部門描述 From bs_dep Order By dep_id";
            DataTable dtDep = clsPublicOfCF01.GetDataTable(strSql);
            lupDep.Text = "";
            lupDep.EditValue = "";
            lupDep.Properties.DataSource = dtDep;
            lupDep.Properties.ValueMember = "部門描述";
            lupDep.Properties.DisplayMember = "部門編號";

            lupFindDep.Properties.DataSource = dtDep;
            lupFindDep.Properties.ValueMember = "部門描述";
            lupFindDep.Properties.DisplayMember = "部門編號";
            //foreach (DataRow row in dtDep.Rows)
            //{
            //    cbeFindDep.Properties.Items.Add(row["部門編號"]);
            //}


            //cbeFindDep.Properties.D

        }
        private void txtNumber_A_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew();
        }
        private void addNew()
        {
            append_mode = true;
            edit_mode = true;
            cleanTextBox(1);
            setTextBoxEnabled();
            edit_flag = "1";
            txtId.Focus();
            
        }
        private void cleanTextBox(int clean_part)
        {
            txtId.Text = "";
            txtCdesc.Text = "";
            lupDep.Text = "";
            txtRemark.Text = "";
            txtWork_Time.Text = "";
            
        }
        private bool checkValid()
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("工序編碼不能為空!");
                txtId.Focus();
                return false;
            }
            //if (edit_flag == "1")//如果是新增狀態，檢查是否已存在編號
            //{
            //    if (checkExistId() == true)
            //    {
            //        MessageBox.Show("編號已存在,不能新增!");
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (edit_flag == "2")//如果是編輯狀態，檢查是否已存在編號
            //    {
            //        if (checkExistId() == false)
            //        {
            //            MessageBox.Show("沒有要編輯的記錄!");
            //            return false;
            //        }
            //    }
            //}
            return true;
        }
        private bool checkExistId()
        {
            string id = txtId.Text;
            string strSql = " Select id From bs_routing Where id='" + id + "' AND dep='" + lupDep.Text.Trim() + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            //if (edit_mode == false)
            //{
            //    MessageBox.Show("不是編輯狀態!");
            //    return;
            //}
            if (!checkValid())
                return;
            string id, cdesc;
            string dep;
            string strSql;
            string result;
            string remark = txtRemark.Text.Trim();
            id = txtId.Text;
            cdesc = txtCdesc.Text;
            float work_time;
            dep = lupDep.Text.ToString();

            work_time = (txtWork_Time.Text != "" ? Convert.ToSingle(txtWork_Time.Text) : 0);

            if (checkExistId() == false)//新增
                strSql = string.Format(@"INSERT INTO bs_routing (id,cdesc,dep,work_time,remark,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE())"
                        , id, cdesc, dep, work_time, remark, userid);
            else
                strSql = string.Format(@"UPDATE bs_routing SET cdesc='{0}',work_time='{1}',remark='{2}',crusr='{3}',crtim=GETDATE()
                    WHERE dep='{4}' AND id='{5}'"
                    , cdesc, work_time, remark, userid, dep, id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show("儲存記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                loadData(dep);
                setTextBoxEnabled();
            }
        }
        private void loadData(string dep)
        {
            string strSql;
            strSql = "Select * from bs_routing";
            if (dep != "")
                strSql += " Where dep='" + dep + "'";
            strSql += " order by dep,id";
            DataTable dtPrice = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dtPrice;
        }
        private void fillTextBox(int rowNo)
        {
            cleanTextBox(0);//全部清空文本框
            if (dgvDetails.Rows.Count == 0)
                return;
            DataGridViewRow CurrentRow = dgvDetails.Rows[rowNo];
            txtId.Text = CurrentRow.Cells["colId"].Value.ToString();
            txtCdesc.Text = CurrentRow.Cells["colCdesc"].Value.ToString();
            lupDep.Text = CurrentRow.Cells["colDep"].Value.ToString();
            txtWork_Time.Text = CurrentRow.Cells["colWork_Time"].Value.ToString();
            txtRemark.Text = CurrentRow.Cells["colRemark"].Value.ToString();
        }
        private void loadRoutingSource(int rowNo)
        {
            string routing_id = "", dep = ""; ;
            if (dgvDetails.Rows.Count > 0)
            {
                DataGridViewRow CurrentRow = dgvDetails.Rows[rowNo];
                routing_id = CurrentRow.Cells["colId"].Value.ToString();
                dep = CurrentRow.Cells["colDep"].Value.ToString();
            }

            string strSql = " Select a.dep,a.routing_id,b.cdesc,a.source_id,d.resource_name" +
                ",Convert(INT,c.standard_qty) AS standard_qty,Convert(INT,c.rows_count) AS rows_count,Convert(INT,c.hours_stele_qty) AS hours_stele_qty" +
                " From bs_routing_source a" +
                " LEFT JOIN bs_routing b ON a.routing_id=b.id AND a.dep=b.dep " +
                " LEFT JOIN " + remote_db + "cd_machine_standard c ON a.source_id=c.machine_id COLLATE Chinese_PRC_CI_AS AND a.dep=c.dept_id COLLATE Chinese_PRC_CI_AS" +
                " LEFT JOIN " + remote_db + "cd_resource d ON a.dep=d.department_id COLLATE Chinese_PRC_CI_AS AND a.source_id=d.resource_id COLLATE Chinese_PRC_CI_AS" +
                " Where a.routing_id='" + routing_id + "' AND a.dep='" + dep + "'";
            DataTable dtRoutingSource = clsPublicOfCF01.GetDataTable(strSql);
            dgvRoutingSource.DataSource = dtRoutingSource;
        }
        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edit_flag = "0";
            append_mode = false;
            edit_mode = false;
            setTextBoxEnabled();
            int rowNo = dgvDetails.CurrentCell.RowIndex;
            fillTextBox(rowNo);
            loadRoutingSource(rowNo);
            loadResource(dgvDetails.Rows[rowNo].Cells["colDep"].Value.ToString());
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData(lupDep.Text.Trim());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            edit_flag = "2";
            append_mode = false;
            edit_mode = true;
            setTextBoxEnabled();
        }
        private void setTextBoxEnabled()
        {
            txtId.Properties.ReadOnly = !append_mode;
            if (append_mode==true && edit_mode == true)
                txtId.BackColor = Color.White;
            else
                txtId.BackColor = Color.Silver;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            if (checkExistId() == false)
            {
                MessageBox.Show("沒有要刪除的記錄!");
                return;
            }
            string result;
            string strSql;
            strSql = string.Format(@"DELETE bs_routing WHERE id='{0}' AND dep='{1}'", txtId.Text, lupDep.Text);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show("刪除記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                loadData(lupDep.Text.Trim());
                setTextBoxEnabled();
                cleanTextBox(0);//清空全部文本框
            }
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            txtId.Focus();
            //frmRoutingBom.query_routing_id = txtId.Text;
            //this.Close();
            saveRoutingBom();
        }

        private void lupFindDep_EditValueChanged(object sender, EventArgs e)
        {
            lupResource.Properties.DataSource = null;
            loadData(lupFindDep.Text.Trim());
            fillTextBox(0);
            loadRoutingSource(0);
        }
        private void loadResource(string dep)
        {
            string strSql = "Select a.resource_id AS 機器代號,(a.resource_id+'--'+a.resource_name) AS 機器描述" +
                " From "+remote_db+"cd_resource a" +
                " Where a.within_code='" + within_code + "' AND a.department_id='" + dep + "'";
            DataTable dtResource = clsPublicOfCF01.GetDataTable(strSql);
            lupResource.Properties.DataSource = dtResource;
            lupResource.Properties.ValueMember = "機器描述";
            lupResource.Properties.DisplayMember = "機器代號";

            cmbResource.DataSource = dtResource;
            cmbResource.DisplayMember = "機器描述";
            cmbResource.ValueMember = "機器代號";
        }

        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0 || lupResource.Text.Trim()=="")
                return;
            string strSql;
            string routing_id;
            string dep;
            string source_id;
            string result;
            dep = lupDep.Text.ToString();
            int rowNo=dgvDetails.CurrentCell.RowIndex;
            DataGridViewRow CurrentRow = dgvDetails.Rows[rowNo];
            routing_id = CurrentRow.Cells["colId"].Value.ToString();
            dep = CurrentRow.Cells["colDep"].Value.ToString();
            source_id = lupResource.Text;
            strSql = string.Format(@"SELECT routing_id FROM bs_routing_source WHERE routing_id='{0}' AND dep='{1}' AND source_id='{2}'"
                    , routing_id, dep, source_id);
            DataTable dtRoutingSource = clsPublicOfCF01.GetDataTable(strSql);
            if (dtRoutingSource.Rows.Count == 0)
            {
                strSql = string.Format(@"INSERT INTO bs_routing_source (routing_id,dep,source_id,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}',GETDATE())"
                        , routing_id, dep, source_id, userid);

                result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
                if (result != "")
                    MessageBox.Show("儲存記錄失敗!");
                else
                {
                    loadRoutingSource(rowNo);
                }
            }
        }

        private void lupDep_EditValueChanged(object sender, EventArgs e)
        {
            lupResource.Properties.DataSource = null;
        }

        private void cmbResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtCdesc.Text = cmbResource.SelectedValue.ToString();
        }

        private void btnDelMachine_Click(object sender, EventArgs e)
        {
            if (dgvRoutingSource.Rows.Count == 0)
                return;
            string strSql;
            string routing_id;
            string dep;
            string source_id;
            string result;
            dep = lupDep.Text.ToString();
            int rowNo = dgvRoutingSource.CurrentCell.RowIndex;
            DataGridViewRow CurrentRow = dgvRoutingSource.Rows[rowNo];
            routing_id = CurrentRow.Cells["colRouting_id"].Value.ToString();
            dep = CurrentRow.Cells["colDdep"].Value.ToString();
            source_id = CurrentRow.Cells["colSource_id"].Value.ToString();
            strSql = string.Format(@"DELETE FROM bs_routing_source WHERE routing_id='{0}' AND dep='{1}' AND source_id='{2}'"
                    , routing_id, dep, source_id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show("儲存記錄失敗!");
            else
            {
                loadRoutingSource(dgvDetails.CurrentCell.RowIndex);
            }
        }
        private void saveRoutingBom()
        {
            string goods_id, routing_id, dep;
            string crusr = userid;
            string strSql = "", strSql_f = "";
            goods_id = frmRoutingBom.query_goods_id;
            string result;
            int prd_sort = 1;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["colSelect"].Value!=null && (bool)dgvDetails.Rows[i].Cells["colSelect"].Value == true)
                {
                    DataGridViewRow CurrentRow = dgvDetails.Rows[i];
                    
                    routing_id = CurrentRow.Cells["colId"].Value.ToString();
                    dep = CurrentRow.Cells["colDep"].Value.ToString();
                    strSql_f = string.Format(@"Select routing_id From bs_routing_bom Where goods_id='{0}' AND routing_id='{1}'"
                            , goods_id, routing_id);
                    DataTable dtFindRoutingBom = clsPublicOfCF01.GetDataTable(strSql_f);
                    if (dtFindRoutingBom.Rows.Count == 0)//新增
                        strSql += string.Format(@"INSERT INTO bs_routing_bom (goods_id,routing_id,dep,prd_sort,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}',GETDATE())"
                                , goods_id, routing_id, dep, prd_sort, crusr, userid);
                    prd_sort = prd_sort + 1;
                }
                   
            }
            if (strSql != "")
            {
                result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
                if (result != "")
                    MessageBox.Show("儲存記錄失敗!");
                else
                {
                    MessageBox.Show("儲存記錄成功!");
                }
            }
        }
    }
}
