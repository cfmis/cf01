using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Forms;
using System.Threading;

namespace cf01.ReportForm
{
    public partial class frmVat : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtReport = new DataTable();
        public frmVat()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmVat_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtId1.Focus();
            string id1 = txtId1.Text;
            string id2 = txtId2.Text;
            if (id1 == "" && id2 == "")
            {
                MessageBox.Show("查詢條件不可為空!", "提示信息");
                return;
            }
            string sql =
            @"SELECT AA.id,
			        BB.mo_id,
                    SO.contract_cid,
                    BB.goods_name,
                    (Isnull(SO.customer_goods,'') + (Case When ('1' = '1') Then (' ' + Isnull(SO.customer_color_id,'') + ' ' + Isnull(SO.linkman,'') + ' ' + ISNULL(SO.table_head,'')) Else '' End)) As customer_goods,
                    BB.issues_qty,
                    cd_units.name as unit_code,
                    BB.sec_qty,
                    C.unit_price as unit_price,
                    CU.name as p_unit,			
			        Case When IsNull(si.issues_id,AA.id)=AA.id  and (c.primary_key='1' Or Left(BB.goods_id,3) ='F0-') Then sd.fare_sum Else null End as fare_sum,
			        IsNull(c.total_sum,0) +
			        +IsNull(Case When IsNull(si.issues_id,AA.id)=AA.id  and (c.primary_key='1' Or Left(BB.goods_id,3) ='F0-')  Then sd.fare_sum Else 0 End,0) as amt,			        
			        SO.id AS pi		
            FROM so_issues_mostly AA with(nolock),so_issues_details BB with(nolock)
            Left Join v_sales_issues_price C On BB.within_code =c.within_code and BB.id =c.id and BB.sequence_id =c.sequence_id
            left join (select M.id,M.within_code,M.m_id,D.mo_id,D.unit_price,D.p_unit,D.contract_cid,D.customer_goods,D.customer_color_id,M.linkman,D.table_head
		               From so_order_manage M
   				            inner join so_order_details D On M.within_code = D.within_code and M.id = D.id And M.ver =D.ver
		               Where M.state Not In('2','V') And D.state Not In('2','V')) SO On BB.within_code = SO.within_code And BB.mo_id = SO.mo_id
            Left Join  (Select M.within_code,D.mo_id,sum(D.fare_sum) as fare_sum From so_order_manage M,so_other_fare D
			            Where M.within_code = D.within_code and M.id = D.id and M.ver =D.ver and M.state Not In('2','V') 
			            Group by M.within_code,D.mo_id ) SD On BB.within_code = SD.within_code And BB.mo_id = SD.mo_id
            Left Join (select a.within_code,b.mo_id,MIN(a.id) as issues_id from	so_issues_mostly a,so_issues_details b
		               where a.within_code =b.within_code and a.id =b.id and a.state not in('2','V') and a.type in('VDI')
		               group by a.within_code,b.mo_id) SI On BB.within_code = SI.within_code And BB.mo_id = SI.mo_id
            left join it_goods on BB.within_code = it_goods.within_code and BB.goods_id = it_goods.id
            left join cd_units on BB.within_code = cd_units.within_code and BB.issues_unit = cd_units.id
            left join cd_units CU on SO.within_code = CU.within_code and SO.p_unit = CU.id
            WHERE AA.within_code = BB.within_code and AA.id = BB.id AND AA.within_code = '0000' ";

            if (id1 != "")
                sql += string.Format(" AND AA.id>='{0}'", id1);
            if (id2 != "")
                sql += string.Format(" AND AA.id<='{0}'", id2);

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            DataTable dtReport = new DataTable();
            dtReport = clsConErp.GetDataTable(sql);
            dgvDetails.DataSource = dtReport;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtReport.Rows.Count == 0)            
            {               
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtId1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
