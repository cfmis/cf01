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

namespace cf01.Forms
{
    public partial class frmStockQuery : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        public frmStockQuery()
        {           
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmStockQuery_Load(object sender, EventArgs e)
        {
            string strSQL =
              @"SELECT id,id+'['+name+']' as cdesc FROM cd_productline 
                WHERE type<>'07' AND state='0' 
                ORDER BY id";
            DataTable dtDept = clsConErp.GetDataTable(strSQL);
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            txtDept.Properties.DataSource = dtDept;
            txtDept.Properties.ValueMember = "id";
            txtDept.Properties.DisplayMember = "id";
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
            txtDept.Focus();
            string strDept = txtDept.EditValue.ToString();
            string strGoods_id = txtGoods_id1.Text.Trim();

            if (strDept == "" && strGoods_id == "")
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            StringBuilder sb = new StringBuilder(
                @"Select A.location_id,D.name as dept_name,A.goods_id,B.name as goods_name,C.name,C.do_color,A.qty,A.sec_qty,A.in_date
	            From st_details A With(nolock)
		            INNER JOIN it_goods B With(nolock) ON A.within_code=B.within_code AND A.goods_id=B.id
		            INNER JOIN cd_color C With(nolock) ON B.within_code=C.within_code AND B.color=C.id
		            INNER JOIN cd_department D With(nolock) ON A.within_code=D.within_code AND A.location_id=D.id		
	            Where A.within_code='0000' ");
            if (!string.IsNullOrEmpty(strDept))
            {
                sb.Append(string.Format(" AND A.location_id='{0}'", strDept));
            }
            sb.Append(string.Format(" AND A.location_id<>'{0}'", "702"));
            sb.Append(" AND A.carton_code<>'ZZZ'");

            if (!string.IsNullOrEmpty(strGoods_id))
            {
                if(strGoods_id.Trim().Length==18)
                    sb.Append(string.Format(" AND A.goods_id='{0}'", strGoods_id));
                else
                    sb.Append(string.Format(" AND A.goods_id LIKE '%{0}%'", strGoods_id));
            }            
            sb.Append("AND A.qty>0");            
            DataTable dtStock = clsConErp.GetDataTable(sb.ToString());
            if (dtStock.Rows.Count > 0)
                dgvStock.DataSource = dtStock;
            else
            {
                dgvStock.DataSource = null;
                dgvStock_lot.DataSource = null;
                dgvStock_use_mrp.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;         
            //SqlParameter[] paras = new SqlParameter[]
            //{
            //        new SqlParameter("@location_id", strDept),
            //        new SqlParameter("@goods_id_s",strGoods_id1),
            //        new SqlParameter("@goods_id_e",strGoods_id2)
            //};
            //DataSet dsStock = new DataSet();
            //dsStock = clsConErp.ExecuteProcedureReturnDataSet("z_rpt_stock_query", paras, "");

            //if (dsStock.Tables[0].Rows.Count > 0)
            //{
            //    //给数据集建立主外键关系  
            //    dsStock.Tables[0].TableName = "dtStock";
            //    dsStock.Tables[1].TableName = "dtStock_lot";
            //    dsStock.Tables[2].TableName = "dtStock_mrp";
            //    DataColumn parentColumn_1 = dsStock.Tables[0].Columns["id_key"];
            //    DataColumn parentColumn_2 = dsStock.Tables[1].Columns["id_key1"];
            //    DataColumn childColumn_1 = dsStock.Tables[1].Columns["id_key_lot"];
            //    DataColumn childColumn_2 = dsStock.Tables[2].Columns["id_key1_mrp"];
            //    DataRelation R1 = new DataRelation("R1", parentColumn_1, childColumn_1);
            //    DataRelation R2 = new DataRelation("R2", parentColumn_2, childColumn_2);


            //    dsStock.Relations.Add(R1);
            //    dsStock.Relations.Add(R2);

            //    BindingSource bs_stock = new BindingSource();
            //    BindingSource bs_stock_sub = new BindingSource();
            //    bs_stock.DataSource = dsStock;
            //    bs_stock.DataMember = "dtStock";
            //    bs_stock_sub.DataSource = bs_stock;
            //    bs_stock_sub.DataMember = "R1";

            //    //
            //    BindingSource bs_stock_lot = new BindingSource();  // 创建绑定源
            //    BindingSource bs_stock_mrp = new BindingSource();

            //    bs_stock_lot.DataSource = dsStock;
            //    bs_stock_lot.DataMember = "dtStock_lot";  // 绑定到数据源——主表
            //    bs_stock_mrp.DataSource = bs_stock_lot;
            //    bs_stock_mrp.DataMember = "R2";


                

            //    //顯示
            //    dgvStock.DataSource = bs_stock;//dsStock.Tables[0];
            //    dgvStock_lot.DataSource = bs_stock_lot;//dsStock.Tables[1];
            //    dgvStock_use_mrp.DataSource = bs_stock_mrp;// dsStock.Tables[2];
            //}
            //else
            //{
            //    dgvStock.DataSource = null;
            //    dgvStock_lot.DataSource = null;
            //    dgvStock_use_mrp.DataSource = null;                
            //    MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}    
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
            string location_id = dgvStock.Rows[Current_row].Cells["location_id"].Value.ToString();
            string goods_id = dgvStock.Rows[Current_row].Cells["goods_id"].Value.ToString();

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@location_id", location_id),
                new SqlParameter("@goods_id",goods_id)                    
            };
            DataTable dtStock_lot = new DataTable();
            dtStock_lot = clsConErp.ExecuteProcedureReturnTable("z_rpt_stock_query", paras);
            dgvStock_lot.DataSource = dtStock_lot;
        }

        private void dgvStock_lot_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStock_lot.CurrentRow == null)//點擊的不是表格內的有效行,如表頭
            {
                return;
            }
            int Current_row = dgvStock_lot.CurrentRow.Index;
            string strLocation_id = dgvStock_lot.Rows[Current_row].Cells["location_id_lot"].Value.ToString();
            string strMo_id = dgvStock_lot.Rows[Current_row].Cells["mo_id"].Value.ToString();
            string strGoods_id = dgvStock_lot.Rows[Current_row].Cells["goods_id_lot"].Value.ToString();
            string strLot_no = dgvStock_lot.Rows[Current_row].Cells["lot_no"].Value.ToString();

            string sql = string.Format(
            @"SELECT A.mo_id as mo_id_mrp,ROUND(CONVERT(float,A.qty),0) as qty_mrp 
            FROM mrp_st_details_lot A with(nolock) 
		    WHERE A.within_code='0000' AND A.location_id='{0}' AND A.obligate_mo_id='{1}' AND A.goods_id='{2}' AND A.lot_no='{3}'", strLocation_id, strMo_id, strGoods_id, strLot_no);
            DataTable dtStock_mrp = clsConErp.GetDataTable(sql);
            dgvStock_use_mrp.DataSource = dtStock_mrp;
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ////int Current_row = dgvStock.CurrentRow.Index;
            //int Current_row = e.RowIndex;
            //if (Current_row == -1) 
            //{
            //   return;//點擊了表頭
            //}
            //string location_id = dgvStock.Rows[Current_row].Cells["location_id"].Value.ToString();
            //string goods_id = dgvStock.Rows[Current_row].Cells["goods_id"].Value.ToString();

            //SqlParameter[] paras = new SqlParameter[]
            //{
            //    new SqlParameter("@location_id", location_id),
            //    new SqlParameter("@goods_id",goods_id)                    
            //};
            //DataTable dtStock_lot = new DataTable();
            //dtStock_lot = clsConErp.ExecuteProcedureReturnTable("z_rpt_stock_query", paras);
            //dgvStock_lot.DataSource = dtStock_lot;
        }

        private void dgvStock_lot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
//            //int Current_row = dgvStock_lot.CurrentRow.Index;
//            int Current_row = e.RowIndex;
//            if (Current_row == -1)
//            {
//                return;//點擊了表頭
//            }
//            string strLocation_id = dgvStock_lot.Rows[Current_row].Cells["location_id_lot"].Value.ToString();
//            string strMo_id = dgvStock_lot.Rows[Current_row].Cells["mo_id"].Value.ToString();
//            string strGoods_id = dgvStock_lot.Rows[Current_row].Cells["goods_id_lot"].Value.ToString();
//            string strLot_no = dgvStock_lot.Rows[Current_row].Cells["lot_no"].Value.ToString();

//            string sql = string.Format(
//            @"SELECT A.mo_id as mo_id_mrp,ROUND(CONVERT(float,A.qty),0) as qty_mrp 
//            FROM mrp_st_details_lot A with(nolock) 
//		    WHERE A.within_code='0000' AND A.location_id='{0}' AND A.obligate_mo_id='{1}' AND A.goods_id='{2}' AND A.lot_no='{3}'", strLocation_id, strMo_id, strGoods_id, strLot_no);
//            DataTable dtStock_mrp = clsConErp.GetDataTable(sql);
//            dgvStock_use_mrp.DataSource = dtStock_mrp;
        }
     
    }
}
