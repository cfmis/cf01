using cf01.CLS;
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

namespace cf01.Forms
{
    public partial class frmStockadiFind : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        DataTable dtFind = new DataTable();
        public string temp_id = "";


        public frmStockadiFind()
        {
            InitializeComponent();
            clsApp.Initialize_find_value("frmStockadiFind", panel1.Controls);
        }

        private void frmStockadiFind_Load(object sender, EventArgs e)
        {
            string strSql = string.Format(
            @"Select id,Convert(varchar(10),issues_date,120) as issues_date,group_number,create_by,create_date 
            From {0}so_issues_mostly Where 1=0", DBUtility.remote_db);
            dtFind = clsPublicOfCF01.GetDataTable(strSql);
            if(dteIssuesDate1.Text =="" && dteIssuesDate2.Text == "")
            {
                dteIssuesDate2.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                dteIssuesDate1.EditValue = DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd");
            }
            if (txtCreateBy.Text == "" )
            {
                txtCreateBy.Text = DBUtility._user_id;
            }
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件
            if (clsApp.set_find_Value("frmStockadiFind", panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            temp_id = "";
            this.DialogResult = DialogResult.No;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(dteIssuesDate1.Text =="" && dteIssuesDate2.Text =="" &&
                txtId1.Text =="" && txtId2.Text =="" &&
                txtGroup.Text =="" && txtCreateBy.Text =="" &&
                dtCreateDate1.Text =="" && dtCreateDate2.Text ==""
                )
            {
                MessageBox.Show("查詢條件不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter("@issues_datte1", dteIssuesDate1.Text),
                 new SqlParameter("@issues_datte2", dteIssuesDate2.Text),
                 new SqlParameter("@id1", txtId1.Text),
                 new SqlParameter("@id2", txtId2.Text),
                 new SqlParameter("@sales_group", txtGroup.Text),
                 new SqlParameter("@create_by", txtCreateBy.Text),
                 new SqlParameter("@create_date1",dtCreateDate1.Text),
                 new SqlParameter("@create_date2",dtCreateDate2.Text)
            };

            //顯示批準進度動畫
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //************************
            temp_id = "";
            dtFind = clsErp.ExecuteProcedureReturnTable("z_so_issues_data", paras);
            dataGridView1.DataSource = dtFind;
            if (dtFind.Rows.Count > 0)
            {
                if (dtFind.Rows.Count == 1)
                {
                    temp_id = dtFind.Rows[0]["id"].ToString(); ;
                }
            }
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (temp_id == "")
            {
                MessageBox.Show("未查詢到數據，請重新輸入條件查詢數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dteIssuesDate1_Leave(object sender, EventArgs e)
        {
            dteIssuesDate2.EditValue = dteIssuesDate1.EditValue;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void dtCreateDate1_Leave(object sender, EventArgs e)
        {
            dtCreateDate2.EditValue = dtCreateDate1.EditValue;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                temp_id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();                
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(temp_id != "")
            {
                this.DialogResult = DialogResult.Yes;//標記選中ID并退出
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            temp_id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            this.DialogResult = DialogResult.Yes;
        }


    }
}
