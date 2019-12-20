using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;

namespace cf01.ReportForm
{
    public partial class frmMoStockQuery : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtStock_lot = new DataTable();
        public frmMoStockQuery()
        {           
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmMoStockQuery_Load(object sender, EventArgs e)
        {
            string strSQL = @"SELECT id FROM cd_productline WHERE type<>'07' AND state='0' ORDER BY id";
            DataTable dtDept = clsConErp.GetDataTable(strSQL);
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            for (int i = 0; i < dtDept.Rows.Count; i++)
            {
                cboDept.Items.Add(dtDept.Rows[i]["id"].ToString());
            }

            chkOK.Checked = false;
            chkNo.Checked = false;
            chkAll.Checked = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            chkAll.Checked = true;
            cboDept.Focus();
            string strDept = cboDept.Text;            
            string strGoods_id = txtGoods_id.Text;
            if (strGoods_id == "")
            {
                MessageBox.Show("貨品編碼不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strsql=@"Select A.location_id,D.name as dept_name,A.goods_id,B.name as goods_name,C.name,C.do_color,A.qty,A.sec_qty,A.in_date
	            From st_details A With(nolock)
		            INNER JOIN it_goods B With(nolock) ON A.within_code=B.within_code AND A.goods_id=B.id
		            INNER JOIN cd_color C With(nolock) ON B.within_code=C.within_code AND B.color=C.id
		            INNER JOIN cd_department D With(nolock) ON A.within_code=D.within_code AND A.location_id=D.id		
	            Where A.within_code='0000' ";
            if (!string.IsNullOrEmpty(strDept))
            {              
                strsql += string.Format(" AND A.location_id='{0}'", strDept);
            }            
            strsql += string.Format(" AND A.location_id<>'{0}'", "702");           
            strsql += " AND A.carton_code<>'ZZZ'";
            if (!string.IsNullOrEmpty(strGoods_id))
            {
                if(strGoods_id.Trim().Length==18)                    
                    strsql += string.Format(" AND A.goods_id='{0}'", strGoods_id);
                else                    
                     strsql += string.Format(" AND A.goods_id LIKE '%{0}%'", strGoods_id);
            }            
            strsql += "AND A.qty>0 ";           

            DataTable dtStock = clsConErp.GetDataTable(strsql);
            dgvStock.DataSource = dtStock;
            if (dtStock.Rows.Count== 0)
            {
                dtStock.Clear();
                dtStock_lot.Clear();             
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {          
            if (dgvStock.CurrentRow == null)//點擊的不是表格內的有效行,如表頭
            {
                return;
            }           
            int Current_row = dgvStock.CurrentRow.Index;
            string goods_id = dgvStock.Rows[Current_row].Cells["goods_id"].Value.ToString();
            if (dtStock_lot.Rows.Count == 0)
            {
                Get_Plan_Date(goods_id);
            }
            else
            {
                if (goods_id != dtStock_lot.Rows[0]["goods_id"].ToString())
                {
                    Get_Plan_Date(goods_id);
                }
            }           
        }

        private void Get_Plan_Date(string pGoods_id)
        {
            string strSql = string.Format(
            @"SELECT A.mo_id,B.goods_id,C.name as goods_name,(B.prod_qty+ISNULL(B.obligate_qty,0)) as prod_qty,B.order_qty,B.c_qty_ok,B.c_sec_qty_ok,B.wp_id,B.next_wp_id ,
            B.f_complete_date
            FROM jo_bill_mostly A with(nolock),jo_bill_goods_details B with(nolock),it_goods C with(nolock)
            WHERE A.within_code=B.within_code and A.id=B.id AND A.ver=B.ver AND B.within_code=C.within_code AND B.goods_id=C.id 
            AND A.within_code ='0000' and B.goods_id ='{0}' and (B.prod_qty+ISNULL(B.obligate_qty,0))>0", pGoods_id);
            dtStock_lot = clsConErp.GetDataTable(strSql);
            dgvStock_lot.DataSource = dtStock_lot;
        }

        private void chkOK_Click(object sender, EventArgs e)
        {
            if (chkOK.Checked)
            {
                if (dtStock_lot.Rows.Count == 0)
                    return;
                string goods_id = dgvStock.Rows[0].Cells["goods_id"].Value.ToString();
                string strSql = string.Format(
                @"SELECT A.mo_id,B.goods_id,C.name as goods_name,(B.prod_qty+ISNULL(B.obligate_qty,0)) as prod_qty,B.order_qty,B.c_qty_ok,B.c_sec_qty_ok,B.wp_id,B.next_wp_id ,
                B.f_complete_date
                FROM jo_bill_mostly A with(nolock),jo_bill_goods_details B with(nolock),it_goods C with(nolock)
                WHERE A.within_code=B.within_code and A.id=B.id AND A.ver=B.ver AND B.within_code=C.within_code AND B.goods_id=C.id 
                AND A.within_code ='0000' and B.goods_id ='{0}' and (B.prod_qty+ISNULL(B.obligate_qty,0))>0 and (B.prod_qty+ISNULL(B.obligate_qty,0))=B.c_qty_ok ", goods_id);
                dtStock_lot = clsConErp.GetDataTable(strSql);
                dgvStock_lot.DataSource = dtStock_lot;

                chkNo.Checked = false;
                chkAll.Checked = false;
            }
        }

        private void chkNo_Click(object sender, EventArgs e)
        {
            if (chkNo.Checked)
            {
                if (dtStock_lot.Rows.Count == 0)
                    return;
                string goods_id = dgvStock.Rows[0].Cells["goods_id"].Value.ToString();
                string strSql = string.Format(
                @"SELECT A.mo_id,B.goods_id,C.name as goods_name,(B.prod_qty+ISNULL(B.obligate_qty,0)) as prod_qty,B.order_qty,B.c_qty_ok,B.c_sec_qty_ok,B.wp_id,B.next_wp_id ,
                B.f_complete_date
                FROM jo_bill_mostly A with(nolock),jo_bill_goods_details B with(nolock),it_goods C with(nolock)
                WHERE A.within_code=B.within_code and A.id=B.id AND A.ver=B.ver AND B.within_code=C.within_code AND B.goods_id=C.id 
                AND A.within_code ='0000' and B.goods_id ='{0}' and (B.prod_qty+ISNULL(B.obligate_qty,0))>0 and (B.prod_qty+ISNULL(B.obligate_qty,0))>B.c_qty_ok ", goods_id);
                dtStock_lot = clsConErp.GetDataTable(strSql);
                dgvStock_lot.DataSource = dtStock_lot;

                chkOK.Checked = false;
                chkAll.Checked = false;
            }
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                if (dtStock_lot.Rows.Count == 0)
                    return;
                string goods_id = dgvStock.Rows[0].Cells["goods_id"].Value.ToString();
                Get_Plan_Date(goods_id);
                chkOK.Checked = false;
                chkNo.Checked = false;
            }
        }
    
        
     
    }
}
