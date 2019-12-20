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
    public partial class frmProductionArrangeWorker : Form
    {
        private string user_id = DBUtility._user_id;
        private string prd_dep = frmProductionArrange.sent_prd_dep;
        public frmProductionArrangeWorker()
        {
            InitializeComponent();
        }

        private void frmProductionArrangeWorker_Load(object sender, EventArgs e)
        {
            txtArrange_id.Text = frmProductionArrange.sent_arrange_id;
            InitControlers();
            loadWorker_id();
            txtWorker_id.Focus();
        }

        private void InitControlers()
        {
            DataTable dtWork_type = clsProductionSchedule.GetWorkType();
            cmbWork_type_id.DataSource = dtWork_type;
            cmbWork_type_id.DisplayMember = "work_type_desc";
            cmbWork_type_id.ValueMember = "work_type_id";
        }
        private void loadWorker_id()
        {
            string arrange_id = txtArrange_id.Text.Trim();
            string strSql = "Select b.worker_id,c.hrm1name,b.work_type_id,d.work_type_desc" +
                        " From dgcf_pad.dbo.product_arrange a" +
                        " Inner Join dgcf_pad.dbo.product_arrange_worker b On a.arrange_id=b.arrange_id" +
                        " Left Join dgsql1.dghr.dbo.hrm01 c On b.worker_id COLLATE chinese_taiwan_stroke_CI_AS=c.hrm1wid" +
                        " Left Join dgcf_pad.dbo.work_type d On b.work_type_id=d.work_type_id " +
                        " Where a.arrange_id='" + arrange_id + "'";
            DataTable dtArrange = clsPublicOfPad.GetDataTable(strSql);
            dgvDetails.DataSource = dtArrange;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string worker_id = txtWorker_id.Text.Trim().PadLeft(10, '0');
            if(findWorker(worker_id)==false)
            {
                MessageBox.Show("工號輸入不正確!");
                return;
            }
            string crtim = System.DateTime.Now.ToString("yyyy/MM/dd HH:SS");
            
            string arrange_id = txtArrange_id.Text.Trim();
            string work_type_id = cmbWork_type_id.SelectedValue.ToString().Trim();
            if (chkWorker(arrange_id, worker_id, work_type_id) == 0)
            {
                string strSql = "Insert Into dgcf_pad.dbo.product_arrange_worker (arrange_id,worker_id,work_type_id,crusr)" +
                    " Values (" + "'" + arrange_id + "','" + worker_id + "','" + work_type_id + "','" + user_id + "')";// + "','" + crtim,crtim
                int result = clsPublicOfPad.ExecuteSqlUpdate(strSql);
                if (result > 0)
                {
                    //MessageBox.Show("添加工號成功!");
                    txtWorker_id.Text = "";
                    loadWorker_id();
                }
                else
                    MessageBox.Show("添加工號失敗!");
            }
            txtWorker_id.Focus();
        }
        private bool findWorker(string worker_id)
        {
            string strSql = "Select hrm1wid From dgsql1.dghr.dbo.hrm01 a" +
                " Inner Join dgsql1.dghr.dbo.hrc04 b On a.hrm1stat2=b.hrc4class" +
                " Where a.hrm1wid='" + worker_id + "' And b.wip_dep='" + prd_dep + "' And a.hrm1state='1' ";
            if (clsPublicOfPad.GetDataTable(strSql).Rows.Count == 0)
                return false;
            return true;
        }
        private void deleteWorker(int row)
        {
            string arrange_id = txtArrange_id.Text.Trim();
            string worker_id = dgvDetails.Rows[row].Cells["colWorker_id"].Value.ToString();
            string work_type_id = dgvDetails.Rows[row].Cells["colWork_type_id"].Value.ToString();
            string strSql = "Delete From dgcf_pad.dbo.product_arrange_worker Where arrange_id='" + arrange_id + "' And worker_id='" + worker_id + "' And work_type_id='" + work_type_id + "'";
            int result = clsPublicOfPad.ExecuteSqlUpdate(strSql);
            if (result > 0)
                //MessageBox.Show("刪除工號成功!");
                loadWorker_id();
            else
                MessageBox.Show("刪除工號失敗!");
            txtWorker_id.Focus();
        }

        private int chkWorker(string arrange_id, string worker_id, string work_type_id)
        {
            string strSql = " Select worker_id From dgcf_pad.dbo.product_arrange_worker Where arrange_id='" + arrange_id + "' And worker_id='" + worker_id + "' And work_type_id='" + work_type_id + "'";
            return clsPublicOfPad.GetDataTable(strSql).Rows.Count;
        }

        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Columns[e.ColumnIndex].Name == "colBtnDel")
            {
                deleteWorker(e.RowIndex);
                //MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 被点击了");
            }
        }
    }
}
