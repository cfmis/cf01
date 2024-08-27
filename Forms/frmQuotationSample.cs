using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
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
    public partial class frmQuotationSample : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        BindingSource bds1 = new BindingSource();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        System.Data.DataTable dtDetail = new System.Data.DataTable();
        System.Data.DataTable dtTemp = new System.Data.DataTable();       
        string pID = "";    //臨時的主鍵值
        string editState = ""; //新增或編號的狀態       

        public frmQuotationSample()
        {
            InitializeComponent();
            dtDetail = clsQuotationSample.GetEmptyStrutre();
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;            
        }

        private void frmQuotationSample_Load(object sender, EventArgs e)
        {
            clsQuotation.Set_Unit(txtPrice_unit);//數量單位  
            clsQuotation.SetExcelType(lueExcelType);
            lueExcelType.EditValue = "Trims";
            SetDataBindings();            
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                int index = dgvDetails.CurrentRow.Index;
                frmQuotationSampleAdd frmAdd = new frmQuotationSampleAdd(index);// { flagCall = "Quotation" };
                frmAdd.ShowDialog();

                if (frmAdd.insertType == "")
                {
                    return;
                }
                dtTemp = dtDetail.Copy();//還原之用.
                if (frmAdd.insertType == "Bottom")
                {
                    //相當于新的記錄,直接添加至文件尾                    
                    string before_clr = GetBeforeAddBgColorValue();
                    AddNew();
                    txtBgColor.Text = (before_clr == "0") ? "1" : "0"; 
                }
                else
                {
                    int addIndex = frmAdd.addIndex;
                    DataGridViewRow dgrw = dgvDetails.CurrentRow;
                    DataRow newRow = dtDetail.NewRow();
                    newRow["input_date"] = dgrw.Cells["input_date"].Value.ToString();
                    newRow["serial_no"] = dgrw.Cells["serial_no"].Value.ToString();
                    newRow["seq_id"] = "";// dgrw.Cells["seq_id"].Value.ToString();//**
                    newRow["season"] = dgrw.Cells["season"].Value.ToString();
                    newRow["plm_code"] = dgrw.Cells["plm_code"].Value.ToString();
                    newRow["artwork_path"] = dgrw.Cells["artwork_path"].Value.ToString();
                    newRow["cf_code"] = dgrw.Cells["cf_code"].Value.ToString();
                    newRow["product_desc"] = dgrw.Cells["product_desc"].Value.ToString();
                    newRow["material"] = dgrw.Cells["material"].Value.ToString();
                    newRow["size"] = dgrw.Cells["size"].Value.ToString();
                    newRow["macys_color_code"] = dgrw.Cells["macys_color_code"].Value.ToString();
                    newRow["mo_id"] = dgrw.Cells["mo_id"].Value.ToString();
                    newRow["ready_date"] = dgrw.Cells["ready_date"].Value.ToString();
                    newRow["cf_color_code"] = dgrw.Cells["cf_color_code"].Value.ToString();
                    newRow["ex_fty_usd"] = clsApp.Return_Float_Value(dgrw.Cells["ex_fty_usd"].Value.ToString());
                    newRow["ex_fty_usd_new"] = dgrw.Cells["ex_fty_usd_new"].Value.ToString();
                    newRow["price_unit"] = dgrw.Cells["price_unit"].Value.ToString();
                    newRow["moq_pcs"] = clsApp.Return_Float_Value(dgrw.Cells["moq_pcs"].Value.ToString());
                    newRow["surcharge"] = dgrw.Cells["surcharge"].Value.ToString();
                    newRow["md_charge"] = dgrw.Cells["md_charge"].Value.ToString();
                    newRow["art_approved_by"] = dgrw.Cells["art_approved_by"].Value.ToString();
                    string strDate = dgrw.Cells["submission_date"].Value.ToString();
                    strDate = string.IsNullOrEmpty(strDate) ? string.Empty : DateTime.Parse(strDate).Date.ToString("yyyy-MM-dd");
                    newRow["submission_date"] = strDate;
                    newRow["sample_approved_date"] = dgrw.Cells["sample_approved_date"].Value.ToString();
                    newRow["macy_system"] = dgrw.Cells["macy_system"].Value.ToString();
                    newRow["remark"] = dgrw.Cells["remark"].Value.ToString();
                    newRow["brand_desc"] = dgrw.Cells["brand_desc"].Value.ToString();
                    newRow["bulk_lead_time"] = dgrw.Cells["bulk_lead_time"].Value.ToString();
                    newRow["quality_issue"] = dgrw.Cells["quality_issue"].Value.ToString();
                    newRow["excel_type"] = dgrw.Cells["excel_type"].Value.ToString();
                    newRow["flag_ck"] = (dgrw.Cells["flag_ck"].Value.ToString() == "True") ? true : false;
                    newRow["flag_hidden"] = (dgrw.Cells["flag_hidden"].Value.ToString() == "True") ? true : false;
                    newRow["bgcolor"] = dgrw.Cells["bgcolor"].Value.ToString();
                    newRow["row_flag"] = "Y"; //"Y"為當前添加的新行.
                    //當前行的前方或下方插入新行                    
                    dtDetail.Rows.InsertAt(newRow, addIndex);
                    //重新處理排序
                    int temp_seq_id = 0;
                    string str_temp_seq_id = "";
                    string strSerialNo = dgrw.Cells["serial_no"].Value.ToString();
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i]["serial_no"].ToString() == strSerialNo)
                        {
                            temp_seq_id += 1;
                            str_temp_seq_id = temp_seq_id.ToString("00");
                            if (dtDetail.Rows[i]["seq_id"].ToString() != str_temp_seq_id)
                            {
                                dtDetail.Rows[i]["seq_id"] = str_temp_seq_id;
                            }
                        }
                    }
                    SetCurrentRowFocus();//定位到當前行
                    //--start 設定編輯按鈕
                    SetButtonSatus(false);
                    SetObjValue.SetEditBackColor(pnlHead.Controls, true);
                    dgvDetails.Enabled = false;//禁止修改
                    editState = "NEW";
                    txtSeq_id.Properties.ReadOnly = true;
                    txtSeq_id.BackColor = System.Drawing.Color.White;
                    txtArtwork_path.Properties.ReadOnly = true;
                    txtArtwork_path.BackColor = System.Drawing.Color.White;
                    txtID.Properties.ReadOnly = true;
                    txtID.BackColor = System.Drawing.Color.White;
                    //--end
                }
            }
            else
            {                
                AddNew();
                txtBgColor.Text = "0";
            }
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
           this.Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();           
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            bds1.CancelEdit();
            dtDetail = dtTemp.Copy();
            bds1.DataSource = dtDetail;
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
            Find();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
           clsQuotationSample.ExportToExcel(dgvDetails,"","");
        }

        private void BTNEXCELCK_Click(object sender, EventArgs e)
        {
            clsQuotationSample.ExportToExcel(dgvDetails,"","CK");
        }

        private void SetDataBindings()
        {
            txtID.DataBindings.Add("Text", bds1, "id");
            //txtSerial_no.DataBindings.Add("Text", bds1, "serial_no");
            txtSerialNo.DataBindings.Add("Text", bds1, "serial_no");
            txtInput_date.DataBindings.Add("EditValue", bds1, "input_date");
            txtSeq_id.DataBindings.Add("Text", bds1, "seq_id");
            txtSeason.DataBindings.Add("Text", bds1, "season");
            txtPlm_code.DataBindings.Add("Text", bds1, "plm_code");
            txtArtwork_path.DataBindings.Add("Text", bds1, "artwork_path");
            txtCf_code.DataBindings.Add("Text", bds1, "cf_code");
            txtProduct_desc.DataBindings.Add("Text", bds1, "product_desc");
            txtMaterial.DataBindings.Add("Text", bds1, "material");
            txtSize.DataBindings.Add("Text", bds1, "size");
            txtMacys_color_code.DataBindings.Add("Text", bds1, "macys_color_code");
            txtMo_id.DataBindings.Add("Text", bds1, "mo_id");
            txtReady_date.DataBindings.Add("Text", bds1, "ready_date");
            txtCf_color_code.DataBindings.Add("Text", bds1, "cf_color_code");
            txtEx_fty_usd.DataBindings.Add("Text", bds1, "ex_fty_usd");
            txtPrice_unit.DataBindings.Add("EditValue", bds1, "price_unit");
            txtEx_fty_usd_new.DataBindings.Add("Text", bds1, "ex_fty_usd_new");
            txtMoq_pcs.DataBindings.Add("Text", bds1, "moq_pcs");
            txtSurcharge.DataBindings.Add("Text", bds1, "surcharge");
            txtMd_charge.DataBindings.Add("Text", bds1, "md_charge");
            txtArt_approved_by.DataBindings.Add("Text", bds1, "art_approved_by");
            dtSubmission_date.DataBindings.Add("EditValue", bds1, "submission_date");
            txtSample_approved_date.DataBindings.Add("Text", bds1, "sample_approved_date");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");
            txtRow_flag.DataBindings.Add("Text", bds1, "row_flag");
            txtBgColor.DataBindings.Add("Text", bds1, "bgcolor");
            txtRs.DataBindings.Add("Text", bds1, "rs");
            txtRow_height.DataBindings.Add("Text", bds1, "row_height");
            txtStatus.DataBindings.Add("EditValue", bds1, "status");

            txtBrand_desc.DataBindings.Add("Text", bds1, "brand_desc");
            txtBulk_lead_time.DataBindings.Add("Text", bds1, "bulk_lead_time");
            txtQuality_issue.DataBindings.Add("Text", bds1, "quality_issue");
            txtMacy_system.DataBindings.Add("Text", bds1, "macy_system");
            lueExcelType.DataBindings.Add("EditValue", bds1, "excel_type");
            //復選框的綁定
            //Binding bind = new Binding("Checked", bds1, "flag_ck");
            Binding bind = new Binding("EditValue", bds1, "flag_ck");
            bind.Format += (s, e) =>
            {               
                e.Value = e.Value;
            };
            chkFlagCk.DataBindings.Add(bind);
            Binding bindHidden = new Binding("EditValue", bds1, "flag_hidden");
            bindHidden.Format += (s, e) =>
            {
                e.Value = e.Value;
            };
            chkFlagHidden.DataBindings.Add(bindHidden);
        }

        private void AddNew()  //新增
        {
            SetResetID();
            editState = "NEW";
            bds1.AddNew();           
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            SetObjValue.ClearObjValue(pnlHead.Controls, "1");
            this.SetObjReadOnly();
            dgvDetails.Enabled = false;
            txtInput_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);            
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms").Substring(0, 19);
            txtPrice_unit.EditValue = "PCS";            
            txtSerialNo.Text = clsQuotationSample.GetSerialNo();
            txtSeq_id.Text = "01";
            lueExcelType.EditValue = "Trims";
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
            txtSeq_id.Properties.ReadOnly = true;
            txtSeq_id.BackColor = System.Drawing.Color.White;
            txtArtwork_path.Properties.ReadOnly = true;
            txtArtwork_path.BackColor = System.Drawing.Color.White;
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
            txtSerialNo.Properties.ReadOnly = true;
            txtSerialNo.BackColor = System.Drawing.Color.White;
        }

        //取消還原到原始記錄位置,要用到pID進行定位
        private void SetResetID()
        {
            if (dgvDetails.Rows.Count > 0)            
            {
                pID = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                //pID = gridView1.GetFocusedRowCellValue("id").ToString();

            }
        }
        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;           
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;            
            BTNPRICE.Enabled = _flag;
                     
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }
               
        private bool Save_Before_Valid() //保存前檢查
        {
            if (txtPlm_code.Text == "" || txtCf_code.Text == "" || txtInput_date.Text=="")
            {
                MessageBox.Show("PLM或者CF_CODE不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            @"INSERT INTO quotation_sample(serial_no,input_date,season,plm_code,artwork_path,cf_code,product_desc,material,size,seq_id,macys_color_code,mo_id,
            ready_date,cf_color_code,ex_fty_usd,ex_fty_usd_new,price_unit,moq_pcs,surcharge,md_charge,art_approved_by,submission_date,
            sample_approved_date,remark,macy_system, brand_desc,bulk_lead_time,quality_issue,flag_ck,flag_hidden,create_by,create_date,status,excel_type)
            VALUES(@serial_no,@input_date,@season,@plm_code,@artwork_path,@cf_code,@product_desc,@material,@size,@seq_id,@macys_color_code,@mo_id,
            @ready_date,@cf_color_code,@ex_fty_usd,@ex_fty_usd_new,@price_unit,@moq_pcs,@surcharge,@md_charge,@art_approved_by,
            CASE LEN(@submission_date) WHEN 0 THEN null ELSE @submission_date END ,@sample_approved_date,@remark,@macy_system,@brand_desc,@bulk_lead_time,@quality_issue,
            @flag_ck,@flag_hidden,@user_id,getdate(),@status,@excel_type)";
            string sql_u =
            @"UPDATE quotation_sample 
            SET serial_no=@serial_no,input_date=@input_date,season=@season,plm_code=@plm_code,artwork_path=@artwork_path,cf_code=@cf_code,product_desc=@product_desc,
            material=@material,size=@size,seq_id=@seq_id,macys_color_code=@macys_color_code,mo_id=@mo_id,ready_date=@ready_date,cf_color_code=@cf_color_code,
            ex_fty_usd=@ex_fty_usd,ex_fty_usd_new=@ex_fty_usd_new,price_unit=@price_unit,moq_pcs=@moq_pcs,surcharge=@surcharge,md_charge=@md_charge,
            art_approved_by=@art_approved_by,submission_date=CASE LEN(@submission_date) WHEN 0 THEN null ELSE @submission_date END ,sample_approved_date=@sample_approved_date,
            remark=@remark,macy_system=@macy_system,brand_desc=@brand_desc,bulk_lead_time=@bulk_lead_time,quality_issue=@quality_issue,flag_ck=@flag_ck,flag_hidden=@flag_hidden,
            update_by=@user_id,update_date=getdate(),status=@status,excel_type=@excel_type
            WHERE id=@id";            
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {                   
                    // for (int i = 0; i < dgvDetails.RowCount; i++)
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
                                myCommand.Parameters.AddWithValue("@id", dtDetail.Rows[i]["id"].ToString());//txtID.EditValue
                                myCommand.CommandText = sql_u;                             
                            }
                            myCommand.Parameters.AddWithValue("@serial_no", dtDetail.Rows[i]["serial_no"].ToString());
                            myCommand.Parameters.AddWithValue("@input_date", DateTime.Parse(dtDetail.Rows[i]["input_date"].ToString()).Date.ToString("yyyy/MM/dd"));
                            myCommand.Parameters.AddWithValue("@season", dtDetail.Rows[i]["season"].ToString());
                            myCommand.Parameters.AddWithValue("@plm_code", dtDetail.Rows[i]["plm_code"].ToString());
                            myCommand.Parameters.AddWithValue("@artwork_path", dtDetail.Rows[i]["artwork_path"].ToString());
                            myCommand.Parameters.AddWithValue("@cf_code", dtDetail.Rows[i]["cf_code"].ToString());
                            myCommand.Parameters.AddWithValue("@product_desc", dtDetail.Rows[i]["product_desc"].ToString());
                            myCommand.Parameters.AddWithValue("@material", dtDetail.Rows[i]["material"].ToString());
                            myCommand.Parameters.AddWithValue("@size", dtDetail.Rows[i]["size"].ToString());                            
                            myCommand.Parameters.AddWithValue("@seq_id", dtDetail.Rows[i]["seq_id"].ToString());
                            myCommand.Parameters.AddWithValue("@macys_color_code", dtDetail.Rows[i]["macys_color_code"].ToString());
                            myCommand.Parameters.AddWithValue("@mo_id", dtDetail.Rows[i]["mo_id"].ToString());
                            myCommand.Parameters.AddWithValue("@ready_date", dtDetail.Rows[i]["ready_date"].ToString());
                            myCommand.Parameters.AddWithValue("@cf_color_code", dtDetail.Rows[i]["cf_color_code"].ToString());
                            myCommand.Parameters.AddWithValue("@ex_fty_usd", clsApp.Return_Float_Value(dtDetail.Rows[i]["ex_fty_usd"].ToString()));
                            myCommand.Parameters.AddWithValue("@ex_fty_usd_new", dtDetail.Rows[i]["ex_fty_usd_new"].ToString());
                            myCommand.Parameters.AddWithValue("@price_unit", dtDetail.Rows[i]["price_unit"].ToString());
                            myCommand.Parameters.AddWithValue("@moq_pcs", clsApp.Return_Float_Value(dtDetail.Rows[i]["moq_pcs"].ToString()));
                            myCommand.Parameters.AddWithValue("@surcharge", dtDetail.Rows[i]["surcharge"].ToString());
                            myCommand.Parameters.AddWithValue("@md_charge", dtDetail.Rows[i]["md_charge"].ToString());
                            myCommand.Parameters.AddWithValue("@art_approved_by", dtDetail.Rows[i]["art_approved_by"].ToString());
                            myCommand.Parameters.AddWithValue("@submission_date", clsApp.Return_String_Date(dtDetail.Rows[i]["submission_date"].ToString()));
                            myCommand.Parameters.AddWithValue("@sample_approved_date", dtDetail.Rows[i]["sample_approved_date"].ToString());
                            myCommand.Parameters.AddWithValue("@macy_system", dtDetail.Rows[i]["macy_system"].ToString()); 
                            myCommand.Parameters.AddWithValue("@remark", dtDetail.Rows[i]["remark"].ToString());
                            myCommand.Parameters.AddWithValue("@brand_desc", dtDetail.Rows[i]["brand_desc"].ToString());
                            myCommand.Parameters.AddWithValue("@bulk_lead_time", dtDetail.Rows[i]["bulk_lead_time"].ToString());
                            myCommand.Parameters.AddWithValue("@quality_issue", dtDetail.Rows[i]["quality_issue"].ToString());
                            myCommand.Parameters.AddWithValue("@flag_ck", chkFlagCk.Checked ? true : false);
                            myCommand.Parameters.AddWithValue("@flag_hidden", chkFlagHidden.Checked ? true : false);
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                            myCommand.Parameters.AddWithValue("@status", dtDetail.Rows[i]["status"].ToString());
                            myCommand.Parameters.AddWithValue("@excel_type", dtDetail.Rows[i]["excel_type"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                    SetCurrentRowFocus();//定位到當前行
                    //獲取新增的ID號
                    string sql_f = ""; 
                    DataTable dt = new DataTable();
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i].RowState == DataRowState.Added || dtDetail.Rows[i].RowState == DataRowState.Modified)
                        {
                            sql_f = string.Format(@"Select id,create_by,create_date,update_by,update_date From quotation_sample Where serial_no='{0}' And seq_id='{1}'", 
                                dtDetail.Rows[i]["serial_no"].ToString(), dtDetail.Rows[i]["seq_id"].ToString());
                            dt = clsPublicOfCF01.GetDataTable(sql_f);
                            if (dtDetail.Rows[i].RowState == DataRowState.Added)
                            {
                                dtDetail.Rows[i]["id"] = Int32.Parse(dt.Rows[0]["id"].ToString());
                                dtDetail.Rows[i]["create_by"] = dt.Rows[0]["create_by"].ToString();
                                dtDetail.Rows[i]["create_date"] = DateTime.Parse(dt.Rows[0]["create_date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                dgvDetails.Rows[i].Cells["row_flag"].Value = "";//定位結束要去掉標識,避免下次定位錯誤
                            }
                            else
                            {
                                dtDetail.Rows[i]["update_by"] = dt.Rows[0]["create_by"].ToString();
                                dtDetail.Rows[i]["update_date"] = DateTime.Parse(dt.Rows[0]["create_date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            sql_f = string.Format(@"Select serial_no,COUNT(*) As rs 
                            From quotation_sample Where serial_no= '{0}'
                            GROUP BY serial_no", dtDetail.Rows[i]["serial_no"].ToString());
                        }
                    }
                    sql_f = "Select serial_no,COUNT(*) As rs From quotation_sample GROUP BY serial_no";
                    DataTable dtCounts = clsPublicOfCF01.GetDataTable(sql_f);
                    string serialNo = "";
                    DataRow[] ary_drs;
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        serialNo = dtDetail.Rows[i]["serial_no"].ToString();
                        dtCounts.Select();
                        ary_drs = dtCounts.Select(string.Format("serial_no='{0}'", serialNo));
                        if (ary_drs.Length > 0)
                        {
                            if(dtDetail.Rows[i]["rs"].ToString() != ary_drs[0]["rs"].ToString())
                            {
                                dtDetail.Rows[i]["rs"] = int.Parse(ary_drs[0]["rs"].ToString());
                            }
                        }
                    }
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
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SetCurrentRowFocus()
        {
            //定位到當前行
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["row_flag"].Value.ToString() == "Y")
                {
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells[3]; //设置当前单元格
                    dgvDetails.Rows[i].Selected = true; //選中整行                    
                    break;
                }
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
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);


            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["bgcolor"].Value.ToString() == "1")
            {
                //特別單價亮藍色背景
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))); // Color.Gray;
            }
            else
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }

            //DataGridView grd1 = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {                
                //刪除線
                grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
            //else
            //{
            //    //恢復正常顯示
            //    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            //    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular);
            //}
        }

        private void txtArtwork_path_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string cust_artwork_path = clsQuotation.cust_artwork_path;
            if (editState == "NEW" || editState == "EDIT")
            {
                OpenFileDialog openFile = new OpenFileDialog()
                {
                    Filter = "Files Path|*.BMP;*.JPG",
                    RestoreDirectory = true,
                    Title = "客戶圖樣相關文檔",
                    InitialDirectory = cust_artwork_path /*初始測試報告路徑*/
                };
                openFile.ShowDialog();                
                string strFile = openFile.FileName;
                if (strFile != "")
                {
                    txtArtwork_path.Text = strFile;                   
                }
            }
        }

        private void SetArtwork(string artwork_full_path)
        {
            if (!string.IsNullOrEmpty(artwork_full_path))
            {        
                //pic_artwork.Image = null;
                pic_artwork.Image = File.Exists(artwork_full_path) ? Image.FromFile(artwork_full_path) : null;
            }
            else
                pic_artwork.Image = null;
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                SetArtwork(txtArtwork_path.Text);
            }
        }

        private void txtEx_fty_usd_Click(object sender, EventArgs e)
        {
            if (txtEx_fty_usd.Text == "0.000")
            {
                txtEx_fty_usd.Select(1, 0);
            }
        }

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            int index = dgvDetails.CurrentRow.Index;
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               string id = txtID.Text;
               string seq_id = txtSeq_id.Text;
               string rtn = clsQuotationSample.Delete(Int32.Parse(txtID.Text));              
               if (rtn == "")
               {
                    dtDetail.Rows.RemoveAt(index);
                    bds1.DataSource = dtDetail;
                    dtDetail.AcceptChanges();
                    //更正每組的記錄總行數
                    string sql_f = "Select serial_no,COUNT(*) As rs From quotation_sample GROUP BY serial_no";
                    DataTable dtCounts = clsPublicOfCF01.GetDataTable(sql_f);
                    string serialNo = "";
                    DataRow[] ary_drs;
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        serialNo = dtDetail.Rows[i]["serial_no"].ToString();
                        dtCounts.Select();
                        ary_drs = dtCounts.Select(string.Format("serial_no='{0}'", serialNo));
                        if (ary_drs.Length > 0)
                        {
                            if (dtDetail.Rows[i]["rs"].ToString() != ary_drs[0]["rs"].ToString())
                            {
                                dtDetail.Rows[i]["rs"] = int.Parse(ary_drs[0]["rs"].ToString());
                            }
                        }
                    }                 
                    MessageBox.Show("數據已刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtDetail.AcceptChanges(); //清除新增或修改的狀態  
                }
            }
        }

        private void Find()
        {
            frmQuotationSampleFind frm = new frmQuotationSampleFind();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                dtDetail = frm.dtFind;              
                bds1.DataSource = dtDetail;
                dgvDetails.DataSource = bds1;
            }
        }

        private void SetGridDataBackgroudColor(DataTable dt)
        {
            if (dtDetail.Rows.Count > 0)
            {
                string serial_no = dtDetail.Rows[0]["serial_no"].ToString();
                string bgcolor = dtDetail.Rows[0]["bgcolor"].ToString();
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    if (serial_no != dtDetail.Rows[i]["serial_no"].ToString())//組改變時
                    {
                        if (bgcolor == "0")
                        {
                            dtDetail.Rows[i]["bgcolor"] = "1";
                            bgcolor = "1";
                        }
                        else
                        {
                            dtDetail.Rows[i]["bgcolor"] = "0";
                        }
                    }
                    else
                    {
                        dtDetail.Rows[i]["bgcolor"] = bgcolor;
                    }
                    serial_no = dtDetail.Rows[i]["serial_no"].ToString();
                }
            }
            dtDetail.AcceptChanges();//恢復正常的Rowstate狀態,否則按編輯按鈕時表格背景色會亂
        }

        private string GetBeforeAddBgColorValue()
        {
            string before_add_value = "0";
            if (dgvDetails.Rows.Count > 0)
            {
                int i = dgvDetails.Rows.Count - 1;
                before_add_value = dgvDetails.Rows[i].Cells["bgcolor"].Value.ToString();
            }
            else
            {
                before_add_value = dgvDetails.Rows[0].Cells["bgcolor"].Value.ToString();
            }           
            return before_add_value;
        }

        private void BTNPRICE_Click(object sender, EventArgs e)
        {
            if (dtDetail.Rows.Count == 0)
            {
                return;
            }
            if(editState !="")
            {
                return;
            }
            mdlQuotationSample mdl = new mdlQuotationSample()
            {                
                season = txtSeason.Text,
                plm_code = txtPlm_code.Text,
                cf_code = txtCf_code.Text,
                material = txtMaterial.Text,
                size = txtSize.Text,
                macys_color_code = txtMacys_color_code.Text,
                mo_id = txtMo_id.Text,
                cf_color_code = txtCf_color_code.Text,
                create_by = "",
                create_date = ""
            };
            frmQuotationSamplePrice frm = new frmQuotationSamplePrice(mdl);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                this.Edit();
                txtEx_fty_usd_new.EditValue = frm.usd_ex_fty + " (" + DateTime.Now.Date.ToString("yyyy/MM/dd") + ")";                
                txtMoq_pcs.EditValue = frm.moq_pcs;               
            }
        }

        private void btnOpenExecl1_Click(object sender, EventArgs e)
        {
            clsQuotationSample.ExportToExcel(dgvDetails,"open","");
        }

        private void btnOpenExecl2_Click(object sender, EventArgs e)
        {
            clsQuotationSample.ExportToExcel(dgvDetails, "open","CK");
        }

        private void txtSerialNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (editState == "")
            {
                frmQuotationSampleEditNo frm = new frmQuotationSampleEditNo(txtSerialNo.Text);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    //更新成功
                    string new_serial_no = frm.strNewSerailNo;
                    string org_serial_no = txtSerialNo.Text;
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i]["serial_no"].ToString() == org_serial_no)
                        {
                            dtDetail.Rows[i]["serial_no"] = new_serial_no;
                        }
                    }
                    dtDetail.AcceptChanges();
                    bds1.DataSource = dtDetail;
                    dgvDetails.DataSource = bds1;
                }
            }            
        }
    }
}
