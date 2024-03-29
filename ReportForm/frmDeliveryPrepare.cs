﻿using System;
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
using System.Data.SqlClient;
using cf01.MDL;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmDeliveryPrepare : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtReport0 = new DataTable();
        DataTable dtReport1 = new DataTable();
        public frmDeliveryPrepare()
        {
            clsApp.Initialize_find_value(this.Name, this.Controls);
            InitializeComponent();
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
            txtSearchMo.Focus();
            if (txtDat1.Text == "" && txtDat2.Text == "" && txtSalesGroup.Text == "" && txtMo_id1.Text=="" && txtMo_id2.Text =="" &&
                txtBrand_id1.Text == "" && txtBrand_id2.Text == "" && txtCreateBy.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDat1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            string is_include_vat = chkIs_not_include_vat.Checked ? "Y" : "";            

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@mo_group",txtSalesGroup.Text),
                new SqlParameter("@order_date",txtDat1.Text),
                new SqlParameter("@order_date_end",txtDat2.Text),
                new SqlParameter("@mo_id1",txtMo_id1.Text),
                new SqlParameter("@mo_id2",txtMo_id2.Text),
                new SqlParameter("@brand_id1",txtBrand_id1.Text),
                new SqlParameter("@brand_id2",txtBrand_id2.Text),
                new SqlParameter("@create_by",txtCreateBy.Text),
                new SqlParameter("@is_include_vat",is_include_vat)
            };
            int result = 0;          
            if (radioGroup1.SelectedIndex == 0)
            {
                dtReport0 = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_delivery_prepare", paras);
                SetStripe(dtReport0);
                dgvDetails0.DataSource = dtReport0;
                result = dtReport0.Rows.Count;
            }
            else
            {
                dtReport1 = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_delivery_prepare_prev_dept", paras);
                SetStripe(dtReport1);
                dgvDetails1.DataSource = dtReport1;
                result = dtReport1.Rows.Count;
            } 
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
           
            if (result == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetStripe(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string prev_mo = dt.Rows[0]["mo_id"].ToString();  
            int cur_stripe = int.Parse(dt.Rows[0]["stripe"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    //從第二行開始
                    if(dt.Rows[i]["mo_id"].ToString() == prev_mo)
                    {
                        dt.Rows[i]["stripe"] = cur_stripe;
                    }
                    else
                    {
                        //不同頁數開始
                        cur_stripe = cur_stripe == 0 ? 1 : 0;
                        dt.Rows[i]["stripe"] = cur_stripe;                        
                    }
                }
                prev_mo = dt.Rows[i]["mo_id"].ToString();
                cur_stripe = int.Parse(dt.Rows[i]["stripe"].ToString());
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                dgvDetails0.Visible = true;
                dgvDetails1.Visible = false;
            }
            else
            {
                dgvDetails0.Visible = false;
                dgvDetails1.Visible = true;
            }
        }

        private void frmDeliveryPrepare_Load(object sender, EventArgs e)
        {
            string str = string.Format("SELECT ISNULL(user_group,'') AS user_group FROM tb_sy_user Where Uname='{0}'", DBUtility._user_id);
            str = clsPublicOfCF01.ExecuteSqlReturnObject(str);
            if(str!="" && str.Length == 1)
            {
                txtSalesGroup.Text = str;
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).Date.ToString("yyyy/MM/dd");
                txtDat1.EditValue = DateTime.Now.AddDays(-30).Date.ToString("yyyy/MM/dd");
            }
            //禁止列排序            
            //for (int i = 0; i < dgvDetails0.Columns.Count; i++)
            //{
            //    dgvDetails0.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            for (int i = 0; i < dgvDetails1.Columns.Count; i++)
            {
                dgvDetails1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            ExpToExcel oxls = new ExpToExcel();
            DataGridView dgv;
            int result = 0;
            if (radioGroup1.SelectedIndex == 0)
            {
                result = dgvDetails0.Rows.Count;
                dgv = dgvDetails0;
            }
            else
            {
                result = dgvDetails1.Rows.Count;
                dgv = dgvDetails1;
            }
            if (result == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
            oxls.ExportToExcel_Fast(dgv);
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void dgvDetails0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvDetails0.Rows[e.RowIndex].Cells["stripe"].Value.ToString() == "1")
            {               
                dgvDetails0.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
           
            if (dgvDetails0.Rows[e.RowIndex].Cells["mo_id2"].Value.ToString() != "")
            {
                dgvDetails0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;               
            }
            
        }

        private void dgvDetails1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvDetails1.Rows[e.RowIndex].Cells["stripe1"].Value.ToString() == "1")
            {
                dgvDetails1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void dgvDetails0_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex<0)
            {
                return;
            }
            
            if (dgvDetails0.Columns[e.ColumnIndex].Name == "flag_select")
            {
                txtSalesGroup.Focus();              
                DataGridViewRow row = dgvDetails0.Rows[e.RowIndex];
                //string result = row.Cells["flag_select"].Value.ToString();
                string mo_id = row.Cells["moid"].Value.ToString();
                if (bool.Parse(row.Cells["flag_select"].Value.ToString()) == true)
                {
                    if (!string.IsNullOrEmpty(row.Cells["mo_id1"].Value.ToString()))
                    {
                        MessageBox.Show("頁數"+ row.Cells["mo_id1"].Value.ToString()+"已開有回港單.");
                        row.Cells["flag_select"].Value = false;//賦值
                        return;
                    }
                    for(int i=0;i< dgvDetails0.RowCount; i++)
                    {
                        row = dgvDetails0.Rows[i];
                        if (row.Cells["moid"].Value.ToString() == mo_id && row.Cells["flag_select"].Value.ToString()=="False")
                        {
                            row.Cells["flag_select"].Value = true;//賦值
                        }
                    }
                }
                else
                {                   
                    for (int i = 0; i < dgvDetails0.RowCount; i++)
                    {
                        row = dgvDetails0.Rows[i];
                        if (row.Cells["moid"].Value.ToString() == mo_id && row.Cells["flag_select"].Value.ToString() == "True")
                        {
                            row.Cells["flag_select"].Value = false;//賦值
                        }
                    }
                }                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvDetails0.RowCount==0)
            {
                MessageBox.Show("數據為空,請點擊【包裝部貨已齊全】,并查詢數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //獲取第一個頁數的組別
            bool is_select = false;
            string group_no = "", mo_id = "";
            DataGridViewRow row = null;
            for (int i = 0; i < dgvDetails0.RowCount; i++)
            {
                row = dgvDetails0.Rows[i];               
                if (row.Cells["flag_select"].Value.ToString() == "True")
                {
                    mo_id = row.Cells["moid"].Value.ToString();
                    group_no = mo_id.Substring(2, 1);
                    is_select = true;
                    break;
                }
            }
            if(is_select==false)
            {
                MessageBox.Show("請首先勾選中要添加到追貨紙的頁數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool new_id = false;
            string id = "", id_prex = string.Format("Z-{0}%", group_no);
            
            //當天當前用戶沒有開追貨紙,在沒有添加至用戶指定的哪一張追貨紙的情況下,自動生成當前第一個頁數的組別的最大單號
            string str_max_by_group = string.Format(
            @"Select Top 1 Max(id) As id From {0}st_delivery_prepare Where id like '{1}' and within_code='0000' and state<>'2'",
            DBUtility.remote_db, id_prex);

            //當前用戶當天是否已開有追貨紙           
            //當天當前用戶是否有開追貨紙,有就默認帶出此張追貨單號
            string str_curr_day = string.Format(
            @"Select Top 1 id From {0}st_delivery_prepare Where within_code='0000' And CAST(create_date AS DATE)=CONVERT(varchar(10),GETDATE(),120) And create_by='{1}' And state<>'2'",
            DBUtility.remote_db, DBUtility._user_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(str_curr_day);           
            if (dt.Rows.Count == 0)
            {
                //找出當前組別歷史最大單號,序列號再加1   
                str_max_by_group = string.Format(@"Select bill_code as id From {0}sys_bill_max_separate Where within_code='0000' And bill_id='{1}' And year_month='{2}' And bill_text2='{3}'",
                    DBUtility.remote_db, "DP01", "", group_no);
                dt = clsPublicOfCF01.GetDataTable(str_max_by_group);
                id_prex = string.Format("Z-{0}", group_no);
                //if (!string.IsNullOrEmpty(dt.Rows[0]["id"].ToString())) //OLD CODE 2023/10/18
                if(dt.Rows.Count>0)
                {
                    //Z-E000002796                    
                    id = dt.Rows[0]["id"].ToString();
                    id = id_prex + (int.Parse(id.Substring(3)) + 1).ToString().PadLeft(9, '0');
                }
                else
                {
                    //當前組別單號為第一張                
                    id = id_prex + "000000001";
                }
                new_id = true;//單號是新增的
            }
            else
            {
                //當前用戶當前有開單
                id = dt.Rows[0]["id"].ToString();
                new_id = false;//單號是已保存有的
            }
            st_delivery_prepare delivery_h = new st_delivery_prepare() { 
                id = id, 
                group_no = group_no, 
                transfers_state = "0", 
                transfer_date = DateTime.Now.Date.ToString("yyyy-MM-dd"), 
                create_by = DBUtility._user_id, 
                update_by = DBUtility._user_id,
                state = "0" 
            };
            delivery_h.row_status = new_id ? "ADD" : "EDIT";
           
            List<st_delivery_prepare_detail> lst = new List<st_delivery_prepare_detail>();
            //只添加面件
            DataRow[] ary_drs = dtReport0.Select("flag_select=true and primary_key=true");           
            if (ary_drs.Length > 0)
            {                                
                foreach (DataRow dr in ary_drs)
                {
                    st_delivery_prepare_detail delivery_d = new st_delivery_prepare_detail();                    
                    delivery_d.id = id;
                    delivery_d.sequence_id = "";
                    delivery_d.mo_id = dr["mo_id"].ToString();
                    delivery_d.goods_id = dr["goods_id"].ToString();
                    delivery_d.goods_name = dr["goods_name"].ToString();
                    decimal qty = decimal.Parse(dr["order_qty"].ToString());
                    delivery_d.plan_qty = decimal.Parse(dr["order_qty"].ToString());
                    delivery_d.move_qty = decimal.Parse(dr["packing_qty"].ToString());
                    delivery_d.base_unit = "PCS";
                    delivery_d.state = "0";
                    delivery_d.up_deptment = dr["up_deptment"].ToString();
                    lst.Add(delivery_d);                    
                }               
                ary_drs = null;

                //打開保存窗口
                using (frmDeliveryPrepareAdd ofrm = new frmDeliveryPrepareAdd(delivery_h, lst))
                {
                    ofrm.ShowDialog();
                    txtId.Text = ofrm.id;
                                       
                    if(ofrm.id != "")
                    {
                        //移除保存追貨紙成功的頁數
                        DataRow[] drws = dtReport0.Select("flag_select=true");
                        DataRow drw;
                        for (int i = 0; i < drws.Length; i++)
                        {
                            drw = drws[i];
                            dtReport0.Rows.Remove(drw);
                        }
                    }
                }
            } 

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (frmDeliveryPrepareList frm = new frmDeliveryPrepareList())
            {
                //重新指定已存在單據號
                frm.ShowDialog();
                if (frm.return_id != "")
                {
                    //已保存的ID
                    txtId.Text = frm.return_id;
                }
            }
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (this.txtId.Text == "")
            {
                MessageBox.Show("請首先指定一個追貨單號!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = clsDeliveryPrepare.GetPrintData(this.txtId.Text,this.chkSortByMo.Checked);
            using (xrDeliveryPrepare xr = new xrDeliveryPrepare(DBUtility._user_id) { DataSource = dt })
            {
                xr.CreateDocument();
                xr.PrintingSystem.ShowMarginsWarning = false;
                xr.ShowPreviewDialog();
            }            
        }

        private void dgvDetails0_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvDetails0.Columns[e.ColumnIndex].Name == "packing_qty1")
                {
                    DataGridViewRow row = dgvDetails0.Rows[e.RowIndex];
                    string is_all_complete = row.Cells["is_all_complete"].Value.ToString();
                    string mo_id1 = row.Cells["mo_id1"].Value.ToString();
                    if (is_all_complete == "1" && mo_id1=="")
                    {
                        row.Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        if(is_all_complete == "0" && mo_id1 == "")
                        {
                            row.Cells[e.ColumnIndex].Style.BackColor = Color.LightSalmon;
                        }
                    }
                }                
            }
           
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void txtSearchMo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtSearchMo.Text.Trim() == "")
                {
                    return;
                }
                string mo_id = txtSearchMo.Text.Trim();
                string column_mo_id = string.Empty;
                DataGridView dgv;
                if (radioGroup1.SelectedIndex == 0)
                {
                    dgv = dgvDetails0;
                    column_mo_id = "moid";
                }
                else
                {
                    dgv = dgvDetails1;
                    column_mo_id = "mo_id";
                }
                if (dgv.Rows.Count == 0)
                {
                    return;
                }                             
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[column_mo_id].Value.ToString() == mo_id)
                    {
                        dgv.CurrentCell = dgv.Rows[i].Cells[2]; //设置当前单元格
                        dgv.Rows[i].Selected = true; //選中整行                        
                        break;
                    }
                }

            }
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.Text = txtBrand_id1.Text;
        }
    }
}
