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
    public partial class frmQuotation_Batch_Update : Form
    {
        private DataTable dt = new DataTable();
        private DataTable dtUpdate = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        public int Current_row;
        public frmQuotation_Batch_Update()
        {
            InitializeComponent();
            //設置菜單按鈕的權限            
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            clsApp.Initialize_find_value(this.Name, groupBox2.Controls);
            NextControl oFocus = new NextControl(this, "1");
            oFocus.EnterToTab();            
        }

        private void frmQuotation_Batch_Update_Load(object sender, EventArgs e)
        {           
            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }
            }

            //dtUpdate = clsPublicOfCF01.GetDataTable(@"SELECT column_name,column_desc,field_name,field_type FROM quotation_excel WHERE is_modify='Y' order by seq");
            dtUpdate = clsPublicOfCF01.GetDataTable(
                @"Select S.column_desc,S.column_name,S.field_name,S.field_type 
                FROM (SELECT column_name,column_desc,field_name,field_type,seq FROM quotation_excel WHERE is_modify='Y' 
                Union Select 'Price Level','價格水平','reason_edit','C',98
                Union Select 'LabTest Prod.Type','LabTest產品大類','labtest_prod_type','C',99) S
                ORDER BY S.seq");
            txtUpdate.Properties.DataSource = dtUpdate;
            txtUpdate.Properties.ValueMember = "column_name";
            txtUpdate.Properties.DisplayMember = "column_name";

            txtDate.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            chkHidenCancel.Checked = true;
            //dtpCrtim1.Format = DateTimePickerFormat.Custom;
            //dtpCrtim1.CustomFormat = "yyyy-MM-dd HH:mm";

            //表格PDD Remark是否可見
            clsQuotation.IsDisplayRemark_PDD(this.dgvDetails, remark_pdd);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void btnFind_Click(object sender, EventArgs e)
        {
            string strDat1 = txtDate1.Text;
            string strDat2 = txtDate2.Text;
            string crtim1, crtim2;
            if (strDat1 == "    /  /")
            {
                strDat1 = "";
            }
            if (strDat2 == "    /  /")
            {
                strDat2 = "";
            }

            if (clsValidRule.CheckDateIsEmpty(this.mkCrtim1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mkCrtim1.Text) == false)
            {
                if (clsValidRule.CheckDateTimeFormat(this.mkCrtim1.Text) == false || clsValidRule.CheckDateTimeFormat(this.mkCrtim2.Text) == false)
                {
                    MessageBox.Show("批準日期格式不正確!");
                    this.mkCrtim1.Focus();
                    return;
                }
            }

            if (clsValidRule.CheckDateIsEmpty(this.mkCrtim1.Text))
                @crtim1 = "";
            else
                crtim1 = mkCrtim1.Text;
            if (clsValidRule.CheckDateIsEmpty(this.mkCrtim2.Text))
                @crtim2 = "";
            else
                crtim2 = mkCrtim2.Text;
            
            SqlParameter[] paras = new SqlParameter[] {
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
                new SqlParameter("@crusr",txtCrusr.Text),
                new SqlParameter("@crtim1",crtim1),
                new SqlParameter("@crtim2",crtim2),
                new SqlParameter("@product_desc",txtProductDesc.Text),               
                new SqlParameter("@reason_edit",txtReason.Text),
                new SqlParameter("@remark",txtRmk.Text),
                new SqlParameter("@other_remark",txtRmk_other.Text),
                new SqlParameter("@remark_for_pdd",txtRmk_pdd.Text),
                new SqlParameter("@is_hiden_cancel_data",chkHidenCancel.Checked?"1":"0"),
                new SqlParameter("@is_vnd",chkVnd.Checked?"1":"0")

            };
            dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_find_batch_update", paras);
            //dt.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("temp_ver", System.Type.GetType("System.String"));
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

        private void frmQuotation_Batch_Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.dgvDetails.RowCount > 0)
            {
                Current_row = this.dgvDetails.CurrentRow.Index;
            }
            else
                Current_row = 0;
            
            dt.Dispose();
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
            DataRow[] dr = dt.Select("flag_select=true");
            if (dr.Length == 0)
            {
                MessageBox.Show("請選擇要批量更改的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dr.Length > 500)
            {
                MessageBox.Show("注意：一次最多可以批量更改500條記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return;
            }

            if (txtUpdate.Text == "")
            {
                MessageBox.Show("請選擇將要更新的欄位!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUpdate.Focus();
                return;
            }
            if (txtFieldName.Text == "" && txtFieldType.Text =="")
            {
                MessageBox.Show("更新欄位的設置不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUpdate.Focus();
                return;
            }
            string strDataType="C,D,N";
            if (!strDataType.Contains(txtFieldType.Text))
            {
                MessageBox.Show("更新欄位的設置不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUpdate.Focus();
                return;
            }
            float fFld_Value = 0.000f;          
            string strFld_Value="";
            switch (txtFieldType.Text)
            {
                case "C":
                    strFld_Value = txtChar.Text;
                    break;
                case "D":
                    strFld_Value = clsApp.Return_String_Date(txtDate.Text);
                    break;
                case "N":
                    fFld_Value = clsApp.Return_Float_Value(txtNumber.Text);
                    break;  
            }
            
            if (txtFieldType.Text == "C" || txtFieldType.Text == "D")
            {
                if (strFld_Value == "" || strFld_Value == "    /  /  ")
                {
                    MessageBox.Show("統一更改值不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (txtFieldType.Text == "C")
                        txtChar.Focus();
                    if (txtFieldType.Text == "D")
                        txtDate.Focus();
                    return;
                }
            }
            if (txtFieldType.Text == "N")
            {
                if (fFld_Value == 0)
                {
                    MessageBox.Show("統一更改值不可為0", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumber.Focus();
                    return;
                }
            }

            string strsql;
            strsql = @"Update dbo.quotation Set @FieldNname=@Field_Value,amusr=@user_id,amtim=getdate() Where id=@id";
            DialogResult result = MessageBox.Show("確定要進行批量更改?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                bool isSelect = false;
                try
                {
                    using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["flag_select"].ToString() == "True")
                            {
                                if (txtFieldType.Text == "C" || txtFieldType.Text == "D")
                                {
                                    strsql = string.Format(@"Update dbo.quotation Set {0}='{1}',amusr='{2}',amtim=getdate() Where id={3}", txtFieldName.Text, strFld_Value, DBUtility._user_id,dt.Rows[i]["id"].ToString());
                                    dt.Rows[i][txtFieldName.Text] = strFld_Value;
                                }
                                else
                                {
                                    strsql = string.Format(@"Update dbo.quotation Set {0}={1},amusr='{2}',amtim=getdate() Where id={3}", txtFieldName.Text, fFld_Value, DBUtility._user_id, dt.Rows[i]["id"].ToString());
                                    dt.Rows[i][txtFieldName.Text] = fFld_Value.ToString();
                                }
                                myCommand.CommandText = strsql;
                                myCommand.Parameters.Clear();                                
                                myCommand.ExecuteNonQuery();
                                isSelect = true ;
                            }
                        }
                        myTrans.Commit(); //數據提交
                    }
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    isSelect = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }
                if (isSelect)
                    MessageBox.Show("數據批量更改成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("數據批量更改失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {                     
            if (this.dgvDetails.Columns[e.ColumnIndex].Name == "ver")
            {  
                using (frmQuotation_Price_List ofrm = new frmQuotation_Price_List(dgvDetails.Rows[e.RowIndex].Cells["id"].Value.ToString(),true))
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

        private void txtUpdate_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUpdate.Text))
            {
                txtFieldName.Text = "";
                txtFieldType.Text = "";
                return;
            }
            txtFieldName.Text = txtUpdate.GetColumnValue("field_name").ToString();
            txtFieldType.Text = txtUpdate.GetColumnValue("field_type").ToString();

            switch (txtFieldType.Text)
            {
                case "C":
                    txtChar.Enabled = true;
                    txtChar.Visible = true;
                    txtDate.Enabled = false;
                    txtDate.Visible = false;
                    txtNumber.Enabled = false;
                    txtNumber.Visible = false;
                    if (txtUpdate.EditValue.ToString() == "Status")                    
                        txtChar.Text = "CANCELLED";                    
                    else
                        txtChar.Text = "";
                    break;
                case "D":
                    txtChar.Enabled = false;
                    txtChar.Visible = false;
                    txtDate.Enabled = true;
                    txtDate.Visible = true;                   
                    txtNumber.Enabled = false;
                    txtNumber.Visible = false;
                    break;
                case "N":
                    txtChar.Enabled = false;
                    txtChar.Visible = false;
                    txtDate.Enabled = false;
                    txtDate.Visible = false;
                    txtNumber.Enabled = true;
                    txtNumber.Visible = true;
                    break;
            }
        }

        private void txtNumber_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text == "0.000")
            {
                txtNumber.Select(1, 0);
            }
        }

        private void mkCrtim1_Leave(object sender, EventArgs e)
        {
            mkCrtim2.Text = mkCrtim1.Text;
        }
   
    }
}
