using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using System.Data.Common;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraGrid.Views.Base;


namespace cf01.Forms
{
    public partial class frmQuotationVer : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        string m_language = DBUtility._language;//保存當前登彔的語言
        public static System.Data.DataTable dtDetail = new System.Data.DataTable();
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        //private DataGridViewRow dgvrow = new DataGridViewRow();


        public frmQuotationVer(System.Data.DataTable pdt)
        {
            InitializeComponent();
            dtDetail = pdt;
            gridControl1.DataSource = dtDetail;

            try
            {
                //舊的菜單按鈕的權限及翻譯
                //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                //control.GenerateContorl();
                //控件翻譯
                clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
                obj_ctl.Translate();
                //設置菜單按鈕的權限
                clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
                clsAppPublic.RetSetImage(toolStrip1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            //dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
        }
   
        private void frmQuotationver_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dtUnit = new System.Data.DataTable();
            dtUnit = clsPublicOfCF01.GetDataTable(@"SELECT '' AS id Union SELECT unit_id as id FROM dbo.bs_unit Where unit_id<>'000'");
            txtPrice_unit.Properties.DataSource = dtUnit;
            txtPrice_unit.Properties.ValueMember = "id";
            txtPrice_unit.Properties.DisplayMember = "id";

            txtMoq_unit.Properties.DataSource = dtUnit;
            txtMoq_unit.Properties.ValueMember = "id";
            txtMoq_unit.Properties.DisplayMember = "id";

            txtMwq_unit.Properties.DataSource = dtUnit;
            txtMwq_unit.Properties.ValueMember = "id";
            txtMwq_unit.Properties.DisplayMember = "id";

            txtMd_charge_unit.Properties.DataSource = dtUnit;
            txtMd_charge_unit.Properties.ValueMember = "id";
            txtMd_charge_unit.Properties.DisplayMember = "id";

            System.Data.DataTable dtMoney = clsPublicOfGEO.GetDataTable(@"SELECT '' as id,'' as cdesc Union SELECT id,name as cdesc FROM dbo.cd_money");
            txtMd_charge_cny.Properties.DataSource = dtMoney;
            txtMd_charge_cny.Properties.ValueMember = "id";
            txtMd_charge_cny.Properties.DisplayMember = "id";

            System.Data.DataTable dtUnit_moq = new System.Data.DataTable();
            dtUnit_moq.Columns.Add("id", typeof(String));
            dtUnit_moq.Rows.Add(new object[] { "" });
            dtUnit_moq.Rows.Add(new object[] { "Days" });
            dtUnit_moq.Rows.Add(new object[] { "Weeks" });
            dtUnit_moq.Rows.Add(new object[] { "Months" });
            txtLead_time_unit.Properties.DataSource = dtUnit_moq;
            txtLead_time_unit.Properties.ValueMember = "id";
            txtLead_time_unit.Properties.DisplayMember = "id";

            string strSql = @"Select typ_code AS id,typ_code+' ('+typ_cdesc+')' AS cdesc From bs_type Where typ_group='3'";
            System.Data.DataTable dtSales_Group = new System.Data.DataTable();
            dtSales_Group = clsPublicOfCF01.GetDataTable(strSql);
            txtSales_group.Properties.DataSource = dtSales_Group;
            txtSales_group.Properties.ValueMember = "id";
            txtSales_group.Properties.DisplayMember = "cdesc";

            strSql = @"Select id,name as cdesc From cd_brand Order by id";
            System.Data.DataTable dtBrand = new System.Data.DataTable();
            dtBrand = clsPublicOfGEO.GetDataTable(strSql);
            txtBrand.Properties.DataSource = dtBrand;
            txtBrand.Properties.ValueMember = "id";
            txtBrand.Properties.DisplayMember = "id";

            strSql = @"Select id,name as cdesc From cd_season Order by id";
            System.Data.DataTable dtSeason = new System.Data.DataTable();
            dtSeason = clsPublicOfGEO.GetDataTable(strSql);
            txtSeason.Properties.DataSource = dtSeason;
            txtSeason.Properties.ValueMember = "id";
            txtSeason.Properties.DisplayMember = "cdesc";
        }


        private void txtNumber_enter_Leave(object sender, EventArgs e)
        {
            //Get_Cust_Formula();// get price Formaula
        }

        private void txtPrice_unit_Click(object sender, EventArgs e)
        {
            txtPrice_unit.SelectAll();
        }

        private void txtSales_group_Properties_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }     

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            //frmQuotationFind ofrmFind = new frmQuotationFind(dtDetail,"Ver");
            frmQuotationFind ofrmFind = new frmQuotationFind();
            ofrmFind.ShowDialog();
            int curent_row = ofrmFind.Current_row;//返回行號     
            ofrmFind.Dispose();
            gridControl1.DataSource = dtDetail;
            if (dtDetail.Rows.Count > 0 && curent_row > 0)
            {
                //定行到當前行 注意指定的當前列不可以隱藏
                //dgvDetails.Rows[curent_row].Cells[1].Selected = true;
                gridView1.SelectRow(curent_row);
               // dgvDetails.CurrentCell = this.dgvDetails.Rows[curent_row].Cells[1]; //设置当前单元格
                //dgvDetails.Rows[curent_row].Selected = true; //選中整行
                //this.dgvDetails.CurrentCell = dgvDetails[1, curent_row]; //设置当前单元格
                //dgvDetails.BeginEdit(true);
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            //Excel();
        }

        // ===============以下爲自定義方法=======================
        private void SetButtonSatus(bool _flag)
        {            
            //BTNFIND.Enabled = _flag;
            //BTNEXCEL.Enabled = _flag;           
            //BTNSAVE.Enabled = !_flag;           
            clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            DataRow[] dr = dtDetail.Select("flag_select=true");
            if (dr.Length == 0)            
            {
                MessageBox.Show("請先選擇出需要做新版本的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return false;
            }
            else
            {
                return true;
            }
        }


        private void Set_Row_Position(string _doc) //定位到當前行 
        {
            Find();
            //for (int i = 0; i < dgvDetails.RowCount; i++)
            //{
            //    if (_doc == dgvDetails.Rows[i].Cells["id"].Value.ToString())
            //    {
            //        dgvDetails.Rows[i].Selected = true;
            //        dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["sales_group"]; //設置光標定位到當前選中的行
            //        break;
            //    }
            //}
        }       

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(this.Controls, false);
            txtID.Properties.ReadOnly = false;
            txtID.Enabled = true;           
        }

        private void Save()  //保存新增或修改的資料
        {
            txtTemp_code.Focus();
            if (dtDetail.Rows.Count==0)
            {
                return;
            }

            gridView1.CloseEditor();
            DataRow[] dr = dtDetail.Select("flag_select=true");
            if (dr.Length == 0)
            {
                MessageBox.Show("請首先選擇出需要做新版本的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("確認是否要生成新的版本?", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            bool save_flag = false;
            string id, ver,new_ver,strSelect;
            float number_enter, price_usd, price_hkd, price_rmb, hkd_ex_fty;            
            
            int result_u = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                strSelect = gridView1.GetRowCellValue(i, "flag_select").ToString();
                if (strSelect == "True")
                {
                    id = gridView1.GetRowCellDisplayText(i, "id");
                    ver = gridView1.GetRowCellDisplayText(i, "ver");
                    gridView1.SetRowCellValue(i, "temp_ver", ver);//保存更新前的版本,以便比较变更字体颜色
                    new_ver = Return_New_Version(gridView1.GetRowCellDisplayText(i, "ver"));
                    number_enter = clsAppPublic.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "number_enter"));
                    price_usd = clsAppPublic.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_usd"));
                    price_hkd = clsAppPublic.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_hkd"));
                    price_rmb = clsAppPublic.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "price_rmb"));
                    hkd_ex_fty = clsAppPublic.Return_Float_Value(gridView1.GetRowCellDisplayText(i, "hkd_ex_fty"));
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@user_id", DBUtility._user_id),
                        new SqlParameter("@id", id),
                        new SqlParameter("@ver",ver),
                        new SqlParameter("@new_ver",new_ver),
                        new SqlParameter("@number_enter",number_enter),                
                        new SqlParameter("@price_usd", price_usd),
                        new SqlParameter("@price_hkd", price_hkd),
                        new SqlParameter("@price_rmb", price_rmb),
                        new SqlParameter("@hkd_ex_fty", hkd_ex_fty)
                    };
                    result_u = clsPublicOfCF01.ExecuteNonQuery("usp_quotation_new_ver", paras, true);
                    if (result_u > 0)
                    {
                        //去掉打勾標識,幷更新版本
                        gridView1.SetRowCellValue(i, "flag_select", false);//??去掉打勾標識                        
                        gridView1.SetRowCellValue(i, "ver", new_ver);
                        save_flag = true ;
                    }
                    else
                    {
                        save_flag = false;
                        break;
                    }
                }
            }

            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private string Return_New_Version(string pOldVer)
        {
            string strVer = (Convert.ToInt16(pOldVer) + 1).ToString();
            return strVer;
        }

        private void Find() //查詢出所有數據
        {
            //dgvDetails.Focus();
            string strSql = "";
            if (mState == "NEW")
            {
                strSql = string.Format(@"SELECT TOP 25 * FROM  dbo.quotation with(nolock) WHERE crusr='{0}' And ISNULL(flag_del,'')='0' Order by crtim DESC", DBUtility._user_id);
            }
            else
            {
                strSql = string.Format(@"SELECT TOP 25 * FROM  dbo.quotation with(nolock) WHERE amusr='{0}' And ISNULL(flag_del,'')='0' Order by amtim DESC", DBUtility._user_id);
            }
            //dtDetail = clsPublicOfCF01.GetDataTable(@"SELECT * FROM  dbo.quotation with(nolock) WHERE ISNULL(flag_del,'')='0'");
            dtDetail = clsPublicOfCF01.GetDataTable(strSql);
            gridControl1.DataSource = dtDetail;
        }


        private void Excel() //匯出EXCEL
        {
            if (gridView1.RowCount > 0)
            {
                //clsGeneralDataConvert.GridView_To_Excel(gridView1);
            }
        }

        //===========以下爲控件中的方法================     

        //private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvDetails.RowCount > 0)
        //    {
        //        dgvrow = dgvDetails.CurrentRow;
        //        Set_head(dgvrow);
        //    }
        //}

        private void Set_head(System.Data.DataTable dt,int pRow)
        {            
            txtID.EditValue = dt.Rows[pRow]["id"].ToString();            
            txtSales_group.EditValue = dt.Rows[pRow]["sales_group"].ToString();
            string strDat = dt.Rows[pRow]["date"].ToString();
            if (!string.IsNullOrEmpty(strDat))
            {
                //strDat = strDat.Substring(0, 10);
                strDat = Convert.ToDateTime(strDat).ToString("yyyy-MM-dd");
            }
            else
            {
                strDat = "";
            }
            txtDate.EditValue = strDat;
            txtTemp_code.Text = dt.Rows[pRow]["temp_code"].ToString();
            txtBrand.EditValue = dt.Rows[pRow]["brand"].ToString();
            txtBrandDesc.Text = dt.Rows[pRow]["brand_desc"].ToString();
            txtSeason.EditValue = dt.Rows[pRow]["season"].ToString();
            txtSeasonDesc.Text = dt.Rows[pRow]["season_desc"].ToString();
            txtDivision.Text = dt.Rows[pRow]["division"].ToString();
            txtContact.Text = dt.Rows[pRow]["contact"].ToString();
            txtMaterial.Text = dt.Rows[pRow]["material"].ToString();
            txtSize.Text = dt.Rows[pRow]["size"].ToString();
            txtProduct_desc.Text = dt.Rows[pRow]["product_desc"].ToString();
            txtRemark.Text = dt.Rows[pRow]["remark"].ToString();
            txtRemark_other.Text = dt.Rows[pRow]["remark_other"].ToString();
            txtCust_code.Text = dt.Rows[pRow]["cust_code"].ToString();
            txtCf_code.Text = dt.Rows[pRow]["cf_code"].ToString(); 
            txtCust_color.Text =dt.Rows[pRow]["cust_color"].ToString();
            txtCf_color.Text =dt.Rows[pRow]["cf_color"].ToString();
            txtNumber_enter.EditValue =dt.Rows[pRow]["number_enter"].ToString();
            txtPrice_usd.EditValue =dt.Rows[pRow]["price_usd"].ToString();
            txtPrice_hkd.EditValue = dt.Rows[pRow]["price_hkd"].ToString();
            txtPrice_rmb.EditValue = dt.Rows[pRow]["price_rmb"].ToString();
            txtPrice_unit.EditValue = dt.Rows[pRow]["price_unit"].ToString();
            txtSalesman.Text =dt.Rows[pRow]["salesman"].ToString();
            txtPrice_unit.EditValue = dt.Rows[pRow]["price_unit"].ToString();
            txtSalesman.Text =dt.Rows[pRow]["salesman"].ToString();
            txtMoq.EditValue = dt.Rows[pRow]["moq"].ToString();
            txtMoq_Desc.Text = dt.Rows[pRow]["moq_desc"].ToString();
            txtMoq_unit.EditValue = dt.Rows[pRow]["moq_unit"].ToString();
            txtMwq.EditValue = dt.Rows[pRow]["mwq"].ToString();
            txtMwq_unit.EditValue = dt.Rows[pRow]["mwq_unit"].ToString();
            txtLead_time_min.EditValue = dt.Rows[pRow]["lead_time_min"].ToString();
            txtLead_time_max.EditValue = dt.Rows[pRow]["lead_time_max"].ToString();
            txtLead_time_unit.EditValue = dt.Rows[pRow]["lead_time_unit"].ToString();
            txtMd_charge.EditValue = dt.Rows[pRow]["md_charge"].ToString();
            txtMd_charge_cny.EditValue = dt.Rows[pRow]["md_charge_cny"].ToString();
            txtMd_charge_unit.EditValue = dt.Rows[pRow]["md_charge_unit"].ToString();
            txtDie_mould_usd.EditValue = dt.Rows[pRow]["die_mould_usd"].ToString();
            txtAccount_code.Text =dt.Rows[pRow]["account_code"].ToString();
            txtValid_date.EditValue =dt.Rows[pRow]["valid_date"].ToString();
            txtKkd_ex_fty.EditValue = dt.Rows[pRow]["hkd_ex_fty"].ToString();
            txtDate_req.Text =dt.Rows[pRow]["date_req"].ToString();
            txtAw.Text =dt.Rows[pRow]["aw"].ToString();
            txtSub_1.Text =dt.Rows[pRow]["sub_1"].ToString();
            txtSub_2.Text =dt.Rows[pRow]["sub_2"].ToString();
            txtSub_3.Text =dt.Rows[pRow]["sub_3"].ToString();
            txtSub_4.Text =dt.Rows[pRow]["sub_4"].ToString();
            txtSub_5.Text =dt.Rows[pRow]["sub_5"].ToString();
            txtSub_6.Text =dt.Rows[pRow]["sub_6"].ToString();
            txtSub_7.Text =dt.Rows[pRow]["sub_7"].ToString();
            txtStatus.Text =dt.Rows[pRow]["status"].ToString();
            txtSample_request.Text =dt.Rows[pRow]["sample_request"].ToString();
            txtNeedle_test.Text =dt.Rows[pRow]["needle_test"].ToString();
            txtVersion.Text =dt.Rows[pRow]["ver"].ToString();
            string strCancel =dt.Rows[pRow]["status_cancel"].ToString();
            if (strCancel == "True")
            {
                chkStatus_cancel.Checked = true;
            }
            else
            {
                chkStatus_cancel.Checked = false;
            }
            txtCrusr.Text = dt.Rows[pRow]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[pRow]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[pRow]["amusr"].ToString();
            txtAmtim.Text = dt.Rows[pRow]["amtim"].ToString();
            txtComment.Text = dt.Rows[pRow]["comment"].ToString();
            if (txtCf_code.Text != "")
            {
                if (txtCf_code.Text.Length >= 7)
                {
                    string strArtwork = txtCf_code.Text.Substring(0, 7);
                    string strSql = string.Format(
                    @"SELECT C.picture_path+'\'+ISNULL(B.picture_name,'') AS picture_name
                    FROM cd_pattern A with(nolock) 
	                INNER JOIN (select within_code,id,max(picture_name) as picture_name 
				                from cd_pattern_details with(nolock) group by within_code,id) B ON A.within_code=B.within_code AND A.id=B.id,
                    cd_company C
                    WHERE A.within_code='0000' AND A.state<>'2' AND A.id='{0}'", strArtwork);
                   
                    System.Data.DataTable dt1 = clsPublicOfGEO.GetDataTable(strSql);
                    if (dt1.Rows.Count > 0)
                    {
                        strArtwork = dt1.Rows[0]["picture_name"].ToString();
                        if (!string.IsNullOrEmpty(strArtwork))
                        {
                            if (File.Exists(strArtwork))
                                pic_artwork.Image = Image.FromFile(strArtwork);
                            else
                                pic_artwork.Image = null;
                        }
                        else
                            pic_artwork.Image = null;
                    }
                    else
                         pic_artwork.Image = null;
                }
                else
                    pic_artwork.Image = null;
            }

        }

        #region Get_Cust_Formula() for Price Formula
        private void Get_Cust_Formula()
        {            
            int cur_row = gridView1.FocusedRowHandle;
            string strNumber_enter = gridView1.GetRowCellDisplayText(cur_row,"number_enter").ToString();
            //USD公式：(入機數 X 1.15）/7.72 保留兩們小數點
            //RMB 17%VAT 公式：入機數*1.17*0.82
            float number_input;
            if (!string.IsNullOrEmpty(strNumber_enter))
            {
                number_input = float.Parse(strNumber_enter);
            }
            else
            {
                number_input = 0.00f;
            }
            if (number_input > 0)
            {
                //txtPrice_usd.EditValue = Math.Round((number_input * 1.15) / 7.72, 2);//USD公式：(入機數 X 1.15）/7.72 保留兩們小數點
                gridView1.SetRowCellValue(cur_row,"price_usd", Math.Round((number_input * 1.15) / 7.72, 2));//USD公式：(入機數 X 1.15）/7.72 保留兩們小數點
                gridView1.SetRowCellValue(cur_row,"price_rmb", Math.Round(number_input * 1.17 * 0.82, 2)); //RMB 17%VAT 公式：入機數*1.17*0.82
            }
            else
            {
                gridView1.SetRowCellValue(cur_row, "price_usd", 0);
                gridView1.SetRowCellValue(cur_row, "price_rmb", 0);                
            }

            //HKD公式：USD$欄*7.8
            if (!string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(cur_row,"price_usd").ToString()))
            {
                number_input = float.Parse(gridView1.GetRowCellDisplayText(cur_row,"price_usd").ToString());
            }
            else
            {
                number_input = 0.00f;
            }

            if (number_input > 0)
            {
                gridView1.SetRowCellValue(cur_row,"price_hkd",Math.Round(number_input * 7.8, 2));
                //txtPrice_hkd.EditValue = Math.Round(number_input * 7.8, 2);
            }
            else
            {
                txtPrice_hkd.EditValue = 0;
            }

            //HKD EX-FTY 公式：HKD$ *0.9
            //if (!string.IsNullOrEmpty(txtPrice_hkd.Text))
            if (!string.IsNullOrEmpty( gridView1.GetRowCellDisplayText(cur_row,"price_hkd").ToString()) )
            {
                //number_input = float.Parse(txtPrice_hkd.Text);
                number_input = float.Parse(gridView1.GetRowCellDisplayText(cur_row,"price_hkd").ToString());
            }
            else
            {
                number_input = 0.00f;
            }

            if (number_input > 0)
            {
                //txtKkd_ex_fty.EditValue = Math.Round(number_input * 0.9, 2);
                gridView1.SetRowCellValue(cur_row, "hkd_ex_fty", Math.Round(number_input * 0.9, 2));
            }
            else
            {
                gridView1.SetRowCellValue(cur_row, "hkd_ex_fty",0);
            }
        }
        #endregion

        private void txtNumber_enter_Click(object sender, EventArgs e)
        {
            txtNumber_enter.Select(0, 0); //光标定位
        }

        private void txtSales_group_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
        }             

        private void chkConvert_CheckedChanged(object sender, EventArgs e)
        {
            string strLang = "";
            if (m_language == "0")
                strLang = "2";//英文
            else
                strLang = "0";//繁體
            m_language = strLang;
            clsTranslate oCtl = new clsTranslate("frmQuotation", this.Controls, strLang);
            oCtl.Translate();
            clsAppPublic.RetSetImage(toolStrip1);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int cur_row = gridView1.FocusedRowHandle;
            Set_head(dtDetail, cur_row);
        }

        private void cl_number_enter_EditValueChanged(object sender, EventArgs e)
        {
            //string strSelect = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString();
            //if (strSelect == "True")
            //{
            //    Get_Cust_Formula();
            //}
            //Get_Cust_Formula();
        }

        private void cl_number_enter_Leave(object sender, EventArgs e)
        {
            Get_Cust_Formula();            
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            //string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            string strVer = gridView1.GetRowCellDisplayText(e.RowHandle, "ver").ToString();
            string strTemp_ver = gridView1.GetRowCellDisplayText(e.RowHandle, "temp_ver").ToString();            
            if ((strVer != strTemp_ver) && !string.IsNullOrEmpty(strTemp_ver))
            {
                e.Appearance.ForeColor = Color.Blue;
                e.Appearance.BackColor = Color.LemonChiffon;
            }            
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView1.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            ////双击功能 
            ////首先需要将gridview1.OptionsBehavior.Editable设为false,
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    if (hInfo.InRow)  // 判断光标是否在行内    
            //    {
            //        if (hInfo.Column.Name == "ver")
            //        {
            //            string strID = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "id");
            //            frmQuotation_Price_List ofrm = new frmQuotation_Price_List(strID);
            //            ofrm.ShowDialog();
            //            ofrm.Dispose();
            //        }
            //    }
            //}          
        }     

        private void txtVersion_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVersion.Text))
            {
                frmQuotation_Price_List ofrm = new frmQuotation_Price_List(txtID.Text);
                ofrm.ShowDialog();
                ofrm.Dispose();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {          
            if (gridView1.RowCount > 0)
            {
                string strID = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "id");
                frmQuotation_Price_List ofrm = new frmQuotation_Price_List(strID);
                ofrm.ShowDialog();
                ofrm.Dispose();  
            }
        }

    }
    
}
