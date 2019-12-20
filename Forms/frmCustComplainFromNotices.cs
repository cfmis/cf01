using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using System.Drawing;
using System.Data.SqlClient;


namespace cf01.Forms
{
    public partial class frmCustComplainFromNotices : Form
    {
        DataTable dtOc_notice=new DataTable();      
        private string str_ref_id = "";
        public List<mdlCustComplain> listComplain = new List<mdlCustComplain>();

        public frmCustComplainFromNotices()
        {
            InitializeComponent();
            NextControl oFocus = new NextControl(this, "1");
            oFocus.EnterToTab();  
        }

        private void frmCustComplainFromNotices_FormClosed(object sender, FormClosedEventArgs e)
        {           
            dtOc_notice.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvNotices.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string refid = dgvNotices.Rows[dgvNotices.CurrentRow.Index].Cells["ref_id"].Value.ToString();
            DataRow[] ary_drs = dtOc_notice.Select(string.Format("ref_id='{0}'", refid));
            listComplain.Clear();  
            string str_date="";
            foreach (DataRow ary_dr in ary_drs)
            {
                str_date = ary_dr["bill_date"].ToString();
                if (!string.IsNullOrEmpty(str_date))             
                    str_date = DateTime.Parse(str_date).Date.ToString("yyyy-MM-dd");                
                else
                    str_date = "";
                mdlCustComplain mdlNotices = new mdlCustComplain() { 
                    ref_id = ary_dr["ref_id"].ToString(),
                    bill_date = str_date, 
                    customer_id = ary_dr["customer_id"].ToString(),
                    seller_id = ary_dr["seller_id"].ToString(), 
                    remark = ary_dr["remark"].ToString(), 
                    new_mo_id = ary_dr["new_mo_id"].ToString(), 
                    mo_id = ary_dr["mo_id"].ToString(), 
                    goods_id = ary_dr["goods_id"].ToString(), 
                    goods_name = ary_dr["goods_name"].ToString(), 
                    order_qty = int.Parse(ary_dr["order_qty"].ToString()), 
                    unit_code = ary_dr["unit_code"].ToString(), 
                    oc_info = ary_dr["oc_info"].ToString() ,
                    bill_create_by = ary_dr["create_by"].ToString(),
                    bill_create_date = DateTime.Parse(ary_dr["create_date"].ToString()).Date.ToString("yyyy-MM-dd")
                };
                listComplain.Add(mdlNotices);
            }
            this.Close();
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void dtDate1_Leave(object sender, EventArgs e)
        {
            dtDate2.EditValue = dtDate1.EditValue;
        }

        private void txtCust1_Leave(object sender, EventArgs e)
        {
            txtCust2.Text = txtCust1.Text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //if (txtMo_id1.Text == "" && txtMo_id2.Text == "" && txtCust1.Text == "" && txtCust2.Text=="" && txtNotice_id.Text == "" 
            //    && dtDate1.Text==""&& dtDate2.Text=="")
            //{
            //    MessageBox.Show("查詢條件不可為空!", "提示信息");
            //    return;
            //}            
            SqlParameter[] paras = new SqlParameter[]{
               new SqlParameter("@id",txtNotice_id.Text),
               new SqlParameter("@customer_id1",txtCust1.Text),
               new SqlParameter("@customer_id2",txtCust2.Text),
               new SqlParameter("@bill_date1",dtDate1.Text),
               new SqlParameter("@bill_date2",dtDate2.Text),
               new SqlParameter("@mo_id1",txtMo_id1.Text),
               new SqlParameter("@mo_id2",txtMo_id2.Text)
            };
            dtOc_notice= clsPublicOfCF01.ExecuteProcedureReturnTable("usp_cust_so_notices_manage", paras);
            dtOc_notice.DefaultView.Sort = "bill_date Desc,ref_id,sequence_id";//排序改為前端
            dgvNotices.DataSource = dtOc_notice;
            if (dtOc_notice.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查詢條件的數據!", "提示信息");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvNotices_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvNotices.Rows.Count > 0)
            {
                if (dgvNotices.Rows[e.RowIndex].Cells["ref_id"].Value.ToString() == str_ref_id)
                    dgvNotices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0xCC, 0xFF, 0xCC);
                else
                    dgvNotices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvNotices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNotices.Rows.Count == 0)
            {
                return ;
            }
            str_ref_id = dgvNotices.Rows[dgvNotices.CurrentRow.Index].Cells["ref_id"].Value.ToString();
            
        }

     

     
    }
}

     

