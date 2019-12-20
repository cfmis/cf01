using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmDefective : Form
    {
        private string _userid = DBUtility._user_id.ToUpper();
        public frmDefective()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbProductDept_Leave(object sender, EventArgs e)
        {
            loadData();
        }


        private void loadData()
        {

            string strSql = "";
            strSql = " SELECT * FROM defective_tb Order By defective_id";
            DataTable dt = clsPublicOfPad.GetDataTable(strSql);
            //if (dtGroupMember.Rows.Count > 0)
            //{
            dgvDetails.DataSource = dt;
            //}
            //else
            //    dgvDetails.DataSource = null;
        }

        private void txtMember_Leave(object sender, EventArgs e)
        {
            if (txtCdesc.Text.Trim() != "")
                txtCdesc.Text = txtCdesc.Text.PadLeft(10, '0');
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtId.Text.Trim().Length!=2)
            {
                MessageBox.Show("編號不能為空或長度不相符!");
                txtId.Focus();
                return;
            }
            if (txtCdesc.Text.Trim() == "")
            {
                MessageBox.Show("描述不能為空!");
                txtCdesc.Focus();
                return;
            }
            string strSql = "";
            strSql = " SELECT defective_id FROM defective_tb WHERE defective_id='" + txtId.Text.Trim() + "'";

            DataTable dt = clsPublicOfPad.GetDataTable(strSql);
            if (dt.Rows.Count == 0)
            {

                strSql = @"Insert Into defective_tb (defective_id,defective_cdesc) Values (@defective_id,@defective_cdesc)";
                SqlParameter[] paras2 = new SqlParameter[] {
                       new SqlParameter("@defective_id",txtId.Text.Trim()),
                       new SqlParameter("@defective_cdesc",txtCdesc.Text.Trim())
                    };
                int ArrangeResult = clsPublicOfPad.ExecuteNonQuery(strSql, paras2, false);
                if (ArrangeResult > 0)
                {
                    MessageBox.Show("儲存記錄成功!");
                    txtCdesc.Focus();
                    loadData();
                    
                }
                else
                    MessageBox.Show("儲存記錄失敗!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = @"Delete From defective_tb Where defective_id=@defective_id";
            SqlParameter[] paras2 = new SqlParameter[] {
                       new SqlParameter("@defective_id",txtId.Text.Trim())
                    };
            int ArrangeResult = clsPublicOfPad.ExecuteNonQuery(strSql, paras2, false);
            if (ArrangeResult > 0)
            {
                MessageBox.Show("刪除記錄成功!");
                loadData();
            }
            else
                MessageBox.Show("刪除記錄失敗!");
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtMember.Text=dgvDetails
            //fillTextBox(dgvDetails.CurrentCell.RowIndex);
            DataGridViewRow CurrentRow = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex];
            txtId.Text = CurrentRow.Cells["colId"].Value.ToString();
            txtCdesc.Text = CurrentRow.Cells["colCdesc"].Value.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCdesc.Text = "";
        }

        private void frmDefective_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
