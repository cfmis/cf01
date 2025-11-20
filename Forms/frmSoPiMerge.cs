using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using cf01.Reports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmSoPiMerge : Form
    {
        clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        BindingSource bds1 = new BindingSource();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        System.Data.DataTable dtDetail = new System.Data.DataTable();
        System.Data.DataTable dtTemp = new System.Data.DataTable();       
        string pID = "";    //臨時的主鍵值
        string editState = ""; //新增或編號的狀態     
        clsToolBarNew objToolbar;  


        public frmSoPiMerge()
        {
            InitializeComponent();
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();

            FindAll();
        }

        private void frmSoPiMerge_Load(object sender, EventArgs e)
        { 
            DataTable dtCustomer = clsCustComplain.GetCustomerData();
            lueItCustomer.Properties.DataSource = dtCustomer;
            lueItCustomer.Properties.ValueMember = "id";
            lueItCustomer.Properties.DisplayMember = "id";
            SetDataBindings();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();           
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
           Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            bds1.CancelEdit();
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            this.SetObjReadOnly();
            dgvDetails.Enabled = true;
            editState = "";           
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            FindAll();
        }      

        private void SetDataBindings()
        {
            lueItCustomer.DataBindings.Add("EditValue", bds1, "it_customer");
            txtOrderDate.DataBindings.Add("EditValue", bds1, "order_date");
            txtId.DataBindings.Add("Text", bds1, "id");
            txtSeqId.DataBindings.Add("Text", bds1, "seq_id");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtkeyId.DataBindings.Add("Text", bds1, "key_id");
            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");
        }

        private void AddNew()  //新增
        {
            SetResetID();
            editState = "NEW";
            bds1.AddNew();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            SetObjValue.ClearObjValue(pnlHead.Controls, "1");           
            dgvDetails.Enabled = false;
            txtOrderDate.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);            
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);
            txtSeqId.Text = "1";
            txtkeyId.Properties.ReadOnly = true;
            txtkeyId.BackColor = System.Drawing.Color.White;
            lueItCustomer.Properties.ReadOnly = false;
            //lueItCustomer.BackColor = System.Drawing.Color.White;
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)           
            {
                return;
            }
            SetResetID();
            dtTemp = dtDetail.Copy();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);          
            dgvDetails.Enabled = false;//禁止修改
            editState = "EDIT";
            this.SetObjReadOnly();
        }

        private void SetObjReadOnly()
        {
            lueItCustomer.Properties.ReadOnly = true;
            lueItCustomer.BackColor = System.Drawing.Color.White;
            txtkeyId.Properties.ReadOnly = true;
            txtkeyId.BackColor = System.Drawing.Color.White;
        }

        //取消還原到原始記錄位置,要用到pID進行定位
        private void SetResetID()
        {
            if (dgvDetails.Rows.Count > 0)            
            {
                pID = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["key_id"].Value.ToString();
            }
        }
        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;           
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNPRINT.Enabled = _flag;                     
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            if(objToolbar !=null)
            {
                objToolbar.SetToolBar();
            }            
        }
               
        private bool Save_Before_Valid() //保存前檢查
        {
            if (lueItCustomer.Text == "" || txtSeqId.Text == "" || txtId.Text=="" ||txtOrderDate.Text=="")
            {
                MessageBox.Show("客戶編號,日期,OC NO,序號不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Save()
        {
            txtRemark.Focus();
            if (!Save_Before_Valid())
            {
                return;
            }
            bds1.EndEdit();//結束修改,立即與綁定數據源一致
            bool save_flag = false;
            string sql_i =
            @"INSERT INTO so_order_pi_merge(it_customer,order_date,id,seq_id,remark,create_date,create_by)
            VALUES(@it_customer,@order_date,@id,@seq_id,@remark,getdate(),@user_id)";
            string sql_u =
            @"UPDATE so_order_pi_merge 
            SET it_customer=@it_customer,order_date=@order_date,id=@id,seq_id=@seq_id,remark=@remark,
            update_date=getdate(),update_by=@user_id
            WHERE key_id=@key_id ";
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);//dgsql2
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    string orderDate = "";
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i].RowState == DataRowState.Modified || dtDetail.Rows[i].RowState == DataRowState.Added)
                        {
                            myCommand.Parameters.Clear();
                            if (dtDetail.Rows[i].RowState == DataRowState.Added)
                            {
                                myCommand.CommandText = sql_i;                                
                            }
                            else
                            {                               
                                myCommand.CommandText = sql_u;
                                myCommand.Parameters.AddWithValue("@key_id", txtkeyId.EditValue);
                            }
                            myCommand.Parameters.AddWithValue("@it_customer", lueItCustomer.Text);
                            orderDate = DateTime.Parse(dtDetail.Rows[i]["order_date"].ToString()).Date.ToString("yyyy-MM-dd");
                            myCommand.Parameters.AddWithValue("@order_date", orderDate);
                            myCommand.Parameters.AddWithValue("@id", dtDetail.Rows[i]["id"].ToString().Trim());
                            myCommand.Parameters.AddWithValue("@seq_id", dtDetail.Rows[i]["seq_id"].ToString());                           
                            myCommand.Parameters.AddWithValue("@remark", dtDetail.Rows[i]["remark"].ToString());                           
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                    dtDetail.AcceptChanges(); //清除新增或修改的狀態                    
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }
            }
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            this.SetObjReadOnly();
            dgvDetails.Enabled = true;
            this.editState = "";
            if (save_flag)
            {
                clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
                ClearFind();
                FindAll();
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void ClearFind()
        {
            txtItCustomer1.Text = "";
            txtOrderDate1.EditValue = "";
            txtId1.Text = "";
        }
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }        

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && string.IsNullOrEmpty(txtSeqId.Text))
            {
                return;
            }
            int index = dgvDetails.CurrentRow.Index;
            string sql_u = string.Format( @"Delete From so_order_pi_merge WHERE key_id={0}",txtkeyId.EditValue);
            string rtn = clsPublicOfCF01.ExecuteSqlUpdate(sql_u);            
            if (rtn == "")
            {
                dtDetail.Rows.RemoveAt(index);
                bds1.DataSource = dtDetail;
                dtDetail.AcceptChanges();               
                MessageBox.Show("數據刪除成功!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FindAll()
        {
            string sql = @"Select * From so_order_pi_merge Where key_id>0 ";
            if(txtItCustomer1.Text.Trim() != "")
            {
                sql += string.Format(" AND it_customer='{0}'", txtItCustomer1.Text.Trim());
            }
            if (txtOrderDate1.Text != "")
            {
                sql += string.Format(" AND order_date='{0}'",DateTime.Parse(txtOrderDate1.EditValue.ToString()).Date.ToString("yyyy-MM-dd"));
            }
            if (txtId1.Text.Trim() != "")
            {
                sql += string.Format(" AND id='{0}'", txtId1.Text.Trim());
            }
            sql += " Order By order_date Desc,it_customer,seq_id,id";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;
        }
              
        private void txtId_Leave(object sender, EventArgs e)
        {
            if (editState != "")
            {
                string id = txtId.Text.Trim();
                if (id == "")
                {
                    return;
                }
                string sql = $"Select it_customer From {DBUtility.remote_db}so_order_manage Where within_code = '0000' and id = '{id}' and state Not IN('2', 'V')";
                DataTable dt = clsPublicOfCF01.GetDataTable(sql);
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show($"OC編號{txtId.Text}不存在!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtId.Text = "";
                }
                else
                {
                    if (lueItCustomer.Text =="")
                    {
                        lueItCustomer.EditValue = dt.Rows[0]["it_customer"].ToString();
                    }                    
                }
            }
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                return;
            }
            string itCustomer = lueItCustomer.EditValue.ToString();
            string orderDate = DateTime.Parse(txtOrderDate.EditValue.ToString()).Date.ToString("yyyy-MM-dd");
            string seqId = txtSeqId.Text;
            string sql =string.Format(
            @"SELECT (a.it_customer+a.order_date+seq_id) AS p_key,
            v.company_english_name,v.company_name,v.company_e_address,v.company_address,v.company_phone,v.company_fax,
            v.ver,v.english_customer_name,v.l_phone,v.id,v.contract_cid,v.linkman,v.fax,
            CONVERT(varchar(10),v.order_date,111) AS order_date,CONVERT(varchar(10),v.incept_order_date,111) AS incept_order_date,
            v.money_id,v.mo_id,goods_id,v.goods_name,v.english_goods_name,v.it_customer,CONVERT(varchar(10),v.arrive_date,111) AS arrive_date,
            v.order_qty,v.unit_price,v.total_sum,v.delivery_mode,v.english_delivery_mode,v.english_packing_mode,
            v.packing_mode,v.create_by,v.seller_id,Isnull(v.agent,'') AS agent,Isnull(v.brand_id,'') AS brand_id,
            v.goods_unit,v.sort,v.p_unit,v.customer_color_id,v.add_remark,v.customer_goods,v.table_head,v.ship_mark,
            v.seller_name,v.merchandiser,v.merchandiser_phone,v.merchandiser_email,v.accounts,v.bank_name,v.english_bank_name,v.swift_code,
            v.currency_sign,v.picture,Convert(varchar(10),v.factory_ship_out_date,111) AS factory_ship_out_date,v.season,
            v.remark,v.stamp1,v.stamp2,v.sequence_id,v.sequence_sort,Isnull(v.goods_sort,'') AS goods_sort,
            Isnull(v.qc_remark,'') AS qc_remark,v.control_terms,v.disc_rate,v.add_info,v.s_address,v.disc_rate_h,v.disc_amt,
            v.goods_sum,v.disc_spare,v.other_fare,v.brand_id
            FROM dbo.so_order_pi_merge a,DGERP2.CFERP.dbo.v_rpt_so v
            WHERE a.id=v.id COLLATE Chinese_PRC_CI_AS And a.it_customer='{0}' And a.order_date='{1}' And a.seq_id='{2}'
            ORDER BY a.it_customer,a.order_date,a.seq_id,a.id,v.sequence_id", itCustomer, orderDate, seqId);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(sql);
            //DataTable dtGoodsSum = new DataTable();
            //dtGoodsSum.Columns.Add("id", typeof(string));
            //dtGoodsSum.Columns.Add("goods_sum", typeof(decimal));
            //dtGoodsSum.Columns.Add("other_fare", typeof(decimal));
            //for (int i = 0; i < dtReport.Rows.Count; i++)
            //{
            //    DataRow dr = dtGoodsSum.NewRow();
            //    dr["id"] = dtReport.Rows[i]["id"].ToString();
            //    dr["goods_sum"] = decimal.Parse(dtReport.Rows[i]["goods_sum"].ToString());
            //    dr["other_fare"] = decimal.Parse(dtReport.Rows[i]["other_fare"].ToString());
            //    dtGoodsSum.Rows.Add(dr);
            //}
            ////去掉重復
            //dtGoodsSum = dtGoodsSum.AsEnumerable().Distinct(DataRowComparer.Default).CopyToDataTable();
            //decimal goodsSum = 0, otherFare = 0;
            //for (int i = 0; i < dtGoodsSum.Rows.Count; i++)
            //{
            //    goodsSum += decimal.Parse(dtGoodsSum.Rows[i]["goods_sum"].ToString());
            //    otherFare += decimal.Parse(dtGoodsSum.Rows[i]["other_fare"].ToString());
            //}
            decimal totalSum = 0, totalDiscAmt = 0;
            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                totalSum += decimal.Parse(dtReport.Rows[i]["total_sum"].ToString());
                totalDiscAmt += decimal.Parse(dtReport.Rows[i]["disc_amt"].ToString());
            }

            using (xrSoEnglish rpt = new xrSoEnglish(totalSum, totalDiscAmt) { DataSource = dtReport })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
            }
        }
    }
}
