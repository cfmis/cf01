using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmQuotation_Batch : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private DataTable dt = new DataTable();
        public int Current_row;
        public frmQuotation_Batch()
        {
            InitializeComponent();
            //設置菜單按鈕的權限
            //clsApp.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            clsApp.Initialize_find_value(this.Name, groupBox2.Controls);           
            NextControl oFocus = new NextControl(this,"1");
            oFocus.EnterToTab();            
        }

        private void frmQuotation_Batch_Load(object sender, EventArgs e)
        {           
            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }
            }
            clsQuotation.IsDisplayRemark_PDD(this.dgvDetails, remark_pdd);
            txtValid_date.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            chkBrand.Checked = true;
            chkMat.Checked = true;
            chkHidenCancel.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtMaterial.Focus();
            bool select_flag = false;
            DataRow[] drs = null;
            if (dgvDetails.RowCount > 0)
            {
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    if (dt.Rows[i]["flag_select"].ToString() == "True")
                    {
                        select_flag = true;
                        break;
                    }
                }
                if (select_flag)
                {
                    drs = dt.Select("flag_select=true");
                }
            }

            string strDat1 = txtDate1.Text;
            string strDat2 = txtDate2.Text;  
            if (strDat1 == "    /  /")
            {
                strDat1 = "";
            }
            if (strDat2 == "    /  /")
            {
                strDat2 = "";
            }
            
            SqlParameter[] paras = new SqlParameter[] 
            { 
                new SqlParameter("@user_id",DBUtility._user_id),
                new SqlParameter("@sales_group",txtSales_group.Text),
                new SqlParameter("@brand",txtBrand.Text),
                new SqlParameter("@material",txtMaterial.Text),
                new SqlParameter("@cust_code",txtCust_code.Text),
                new SqlParameter("@cust_color",txtCust_color.Text),
                new SqlParameter("@cf_code",txtCf_code.Text),
                new SqlParameter("@cf_color",txtCf_color.Text),
                new SqlParameter("@season",txtSeason.Text),
                new SqlParameter("@temp_code",txtTemp_code.Text),
                new SqlParameter("@size",txtSize.Text),
                new SqlParameter("@dat1",strDat1), 
                new SqlParameter("@dat2",strDat2),
                new SqlParameter("@mo_id",txtMo_id.Text),
                new SqlParameter("@sub_mo_id",txtSub.Text),
                new SqlParameter("@plm_code",txtPlm_code.Text),
                new SqlParameter("@product_desc",txtProductDesc.Text),
                new SqlParameter("@reason_edit",txtReason.Text),
                new SqlParameter("@remark",""),
                new SqlParameter("@other_remark",""),
                new SqlParameter("@remark_for_pdd",""),
                new SqlParameter("@crtim_s",""),
                new SqlParameter("@crtim_e",""),
                new SqlParameter("@include_mat",chkMat.Checked?"1":""),
                new SqlParameter("@include_brand",chkBrand.Checked?"1":""),
                new SqlParameter("@is_hiden_cancel_data",chkHidenCancel.Checked?"1":"0"),
                new SqlParameter("@account_code",txtAccount_Code.Text),
            };
            dt=clsPublicOfCF01.ExecuteProcedureReturnTable("usp_qoutation_find",paras);           
            //dt.Columns.Add("temp_ver", System.Type.GetType("System.String"));

            //------------ 
            //導入前一次打勾的記錄
            if (drs != null)
            {
                if (drs.Length > 0)
                {
                    DataRow[] drs_del;
                    foreach (DataRow row in drs)
                    {
                        drs_del = dt.Select(string.Format("id={0}", row["id"]));
                        foreach (DataRow row_del in drs_del)
                        {
                            dt.Rows.Remove(row_del);//先移走已存在的行
                        }
                    }
                    //將打勾的添加進新查詢的結果中                   
                    foreach (DataRow dr in drs)
                    {
                        dt.ImportRow(dr);
                    }
                }
            }
            //------------

            //處理排序
            //this.dgvDetails.Sort(this.dgvDetails.Columns["flag_select"], ListSortDirection.Descending);  
            DataView dv = dt.DefaultView;
            dv.Sort = "flag_select DESC";  //按Flag_select列 排序            
            dt = dv.ToTable();

            this.dgvDetails.DataSource = dt;            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查詢條件的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                this.dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout); ;
            }
        }

        private void dgvDetails_DoubleClick(object sender, EventArgs e)
        {
            Current_row = this.dgvDetails.CurrentRow.Index;
            this.Close();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, groupBox2.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
           else
              MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
         
        }

        private void frmQuotation_Batch_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.dgvDetails.RowCount > 0)
            {
                Current_row = this.dgvDetails.CurrentRow.Index;
            }
            else
                Current_row = 0;
            
            dt.Dispose();
        }

        private void txtBP_Click(object sender, EventArgs e)
        {
            txtBP.SelectAll();
        }

        private void cmbSelect_EditValueChanged(object sender, EventArgs e)
        {            
            if (cmbSelect.SelectedIndex== 0)
            {
                radGrp1.Visible = true;
            }
            else
            {
                radGrp1.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!BTNSAVE.Enabled)
            {
                MessageBox.Show("當前用戶沒有此操作權限!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            float bp_batch = clsApp.Return_Float_Value(txtBP.EditValue.ToString());
            if (bp_batch <= 0)
            {
                MessageBox.Show("請輸入批量更新值!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBP.Focus();
                return;
            }
            if (cmbSelect.SelectedIndex ==-1)
            {
                MessageBox.Show("請選擇批量更新選項!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbSelect.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtValid_date.EditValue.ToString()))
            {
                MessageBox.Show("請輸入有效報價單建立日期!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValid_date.Focus();
                return;
            }

            DataRow[] dr_select = dt.Select("flag_select=true");
            if (dr_select.Length == 0)
            {
                MessageBox.Show("請先選擇要做批量的記錄!", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult result = MessageBox.Show("確定要進行此操作?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            } 
            bool save_flag = false;
            string id,temp_code,ver, new_ver, strSelect, remark,remark_pdd,valid_date,brand_id,price_unit;            
            int result_u;
            float bp,disc_rate,temp_disc_rate;
            const string sql_update =
            @"UPDATE quotation SET date=@valid_date, number_enter=@number_enter,price_usd=@price_usd,price_hkd=@price_hkd,price_rmb=@price_rmb,hkd_ex_fty=@hkd_ex_fty,
                    usd_ex_fty=@usd_ex_fty,discount=@discount,disc_price_usd=@disc_price_usd,disc_price_hkd=@disc_price_hkd,disc_price_rmb=@disc_price_rmb,disc_hkd_ex_fty=@disc_hkd_ex_fty
                    ,valid_date=CONVERT(varchar(10),DATEADD(DAY,30,@valid_date),120),
                    remark=CASE LEN(@remark) WHEN 0 THEN remark ELSE @remark END,
                    remark_pdd=CASE LEN(@remark_pdd) WHEN 0 THEN remark_pdd ELSE @remark_pdd END,amusr=@user_id,amtim=Getdate()
            WHERE id=@id";
            //valid_date=CASE LEN(@valid_date) WHEN 0 THEN null ELSE @valid_date END
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSelect = dt.Rows[i]["flag_select"].ToString();
                if (strSelect == "True")
                {
                    id = dt.Rows[i]["id"].ToString();
                    temp_code = dt.Rows[i]["temp_code"].ToString();                    
                    ver = dt.Rows[i]["ver"].ToString();                    
                    new_ver =clsQuotation.Return_New_Version(ver);
                    brand_id = dt.Rows[i]["brand"].ToString();
                    price_unit= dt.Rows[i]["price_unit"].ToString();
                    bp = clsApp.Return_Float_Value(dt.Rows[i]["number_enter"].ToString());            
                    valid_date = clsApp.Return_String_Date(txtValid_date.Text);
                    remark = txtRemark.Text.Trim();
                    remark_pdd = txtPddRemark.Text.Trim();

                    if (cmbSelect.SelectedIndex == 0) //下拉框選擇的是按百分比增減
                    {
                        //BP按百份比增加或減少,根據牌子對應的公式各種單價自動調整
                        if (radGrp1.SelectedIndex == 0)
                            bp = bp * (1 + bp_batch / 100);
                        else //按百份比增加-
                            bp = bp * (1 - bp_batch / 100);
                    }
                    else
                        bp = bp_batch;
                   
                    //計算折前單價
                   mdlFormula_Result objResult = new mdlFormula_Result();
                   objResult = clsQuotation.Get_Cust_Formula(brand_id, dt.Rows[i]["formula_id"].ToString(), bp.ToString(), dt.Rows[i]["price_unit"].ToString());//設置單價
                   
                   //計算折扣后單價                   
                   mdlFormula_Result objDiscount = new mdlFormula_Result();
                   disc_rate = clsApp.Return_Float_Value(dt.Rows[i]["discount"].ToString());
                   //disc_rate如大于0，則用原定價表中的折扣率,否則利用公式中設置的折扣率
                   if (disc_rate > 0)
                   {
                       objDiscount = clsQuotation.Get_Cust_Formula_Disc(brand_id, disc_rate.ToString(), objResult, price_unit);
                       temp_disc_rate = disc_rate;
                   }
                   else
                   {                       
                       objDiscount = clsQuotation.Get_Cust_Formula_Disc(brand_id, objResult.discount.ToString(), objResult, price_unit);
                       temp_disc_rate = objResult.discount;
                   }
                   
                   if (chkNewVersion.Checked) //是否產生新版本?
                   {                        
                        SqlParameter[] paras = new SqlParameter[]
                        {
                            new SqlParameter("@user_id", DBUtility._user_id),
                            new SqlParameter("@temp_code", temp_code),
                            new SqlParameter("@ver",ver),
                            new SqlParameter("@new_ver",new_ver),
                            new SqlParameter("@number_enter",bp),  
                            new SqlParameter("@price_usd",objResult.price_usd),
                            new SqlParameter("@price_hkd", objResult.price_hkd),
                            new SqlParameter("@price_rmb", objResult.price_rmb),
                            new SqlParameter("@hkd_ex_fty", objResult.hkd_ex_fty),
                            new SqlParameter("@usd_ex_fty", objResult.usd_ex_fty),

                            new SqlParameter("@discount", temp_disc_rate),
                            new SqlParameter("@disc_price_usd", objDiscount.disc_price_usd),
                            new SqlParameter("@disc_price_hkd", objDiscount.disc_price_hkd),
                            new SqlParameter("@disc_price_rmb", objDiscount.disc_price_rmb),
                            new SqlParameter("@disc_hkd_ex_fty", objDiscount.disc_hkd_ex_fty),

                            new SqlParameter("@remark", remark),
                            new SqlParameter("@remark_pdd", remark_pdd),
                            new SqlParameter("@valid_date",valid_date)
                        };
                        
                        result_u = clsPublicOfCF01.ExecuteNonQuery("usp_quotation_new_ver_batch", paras, true);
                        if (result_u > 0)
                        {
                            //去掉打勾標識,幷更新版本,刷新當前表格數據
                            dt.Rows[i]["flag_select"] = false;//??去掉打勾標識                        
                            dt.Rows[i]["ver"] = new_ver;
                            dt.Rows[i]["number_enter"] = bp;
                            dt.Rows[i]["price_usd"] = objResult.price_usd;
                            dt.Rows[i]["price_hkd"] = objResult.price_hkd;
                            dt.Rows[i]["price_rmb"] = objResult.price_rmb;
                            dt.Rows[i]["hkd_ex_fty"] = objResult.hkd_ex_fty;
                            dt.Rows[i]["usd_ex_fty"] = objResult.usd_ex_fty;

                            dt.Rows[i]["discount"] = temp_disc_rate;
                            dt.Rows[i]["disc_price_usd"] = objDiscount.disc_price_usd;
                            dt.Rows[i]["disc_price_hkd"] = objDiscount.disc_price_hkd;
                            dt.Rows[i]["disc_price_rmb"] = objDiscount.disc_price_rmb;
                            dt.Rows[i]["disc_hkd_ex_fty"] = objDiscount.disc_hkd_ex_fty;

                            dt.Rows[i]["remark"] = remark;
                            dt.Rows[i]["remark_pdd"] = remark_pdd;
                            dt.Rows[i]["valid_date"] = valid_date ;
                            save_flag = true;
                        }
                        else
                        {
                            save_flag = false;
                            break;
                        }
                    }
                    else//直接更新
                    {                           
                        SqlParameter[] paras = new SqlParameter[]
                        {
                            new SqlParameter("@user_id", DBUtility._user_id),
                            new SqlParameter("@id", id),                            
                            new SqlParameter("@number_enter",bp),  
                            new SqlParameter("@price_usd", objResult.price_usd),
                            new SqlParameter("@price_hkd", objResult.price_hkd),
                            new SqlParameter("@price_rmb", objResult.price_rmb),
                            new SqlParameter("@hkd_ex_fty", objResult.hkd_ex_fty),
                            new SqlParameter("@usd_ex_fty", objResult.usd_ex_fty),

                            new SqlParameter("@discount", temp_disc_rate),
                            new SqlParameter("@disc_price_usd", objResult.disc_price_usd),
                            new SqlParameter("@disc_price_hkd", objResult.disc_price_hkd),
                            new SqlParameter("@disc_price_rmb", objResult.disc_price_rmb),
                            new SqlParameter("@disc_hkd_ex_fty", objResult.disc_hkd_ex_fty),

                            new SqlParameter("@remark", remark),
                            new SqlParameter("@remark_pdd", remark_pdd),
                            new SqlParameter("@valid_date",valid_date)
                        };
                        
                        result_u = clsPublicOfCF01.ExecuteNonQuery(sql_update, paras, false);
                        if (result_u > 0)
                        {
                            //去掉打勾標識,幷更新版本
                            dt.Rows[i]["flag_select"] = false;//??去掉打勾標識
                            dt.Rows[i]["number_enter"] = bp;
                            dt.Rows[i]["price_usd"] = objResult.price_usd;
                            dt.Rows[i]["price_hkd"] = objResult.price_hkd;
                            dt.Rows[i]["price_rmb"] = objResult.price_rmb;
                            dt.Rows[i]["hkd_ex_fty"] = objResult.hkd_ex_fty;
                            dt.Rows[i]["usd_ex_fty"] = objResult.usd_ex_fty;

                            dt.Rows[i]["discount"] = temp_disc_rate;
                            dt.Rows[i]["disc_price_usd"] = objResult.disc_price_usd;
                            dt.Rows[i]["disc_price_hkd"] = objResult.disc_price_hkd;
                            dt.Rows[i]["disc_price_rmb"] = objResult.disc_price_rmb;
                            dt.Rows[i]["disc_hkd_ex_fty"] = objResult.disc_hkd_ex_fty;

                            dt.Rows[i]["remark"] = remark;
                            dt.Rows[i]["remark_pdd"] = remark_pdd;
                            dt.Rows[i]["valid_date"] = valid_date ;
                            save_flag = true;
                        }
                        else
                        {
                            save_flag = false;
                            break;
                        }
                    }
                }                        
            }
            if (save_flag)
            {
                MessageBox.Show("批量更新成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkSelectAll.Checked = false;
            }
            else
            {
                MessageBox.Show("批量更新失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }             
        }


        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {                     
            if (this.dgvDetails.Columns[e.ColumnIndex].Name == "ver")
            {  
                using (frmQuotation_Price_List ofrm = new frmQuotation_Price_List(dgvDetails.Rows[e.RowIndex].Cells["id"].Value.ToString(),true ))
                {
                    ofrm.ShowDialog();                   
                }   
            }     
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                if (chkSelectAll.Checked)
                {
                    Select_All(true);
                }
                else
                {
                    Select_All(false);
                }
            }
        }

        private void Select_All(bool _flag)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["flag_select"] = _flag;
                }
            }
        }

        private void txtSales_group_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);//小寫轉大寫
        }
    }
}
