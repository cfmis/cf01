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

namespace cf01.Forms
{
    public partial class frmQuotation_Formula : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        public int row_reset = 0;
        private System.Data.DataTable dtDetail = new System.Data.DataTable();
        private System.Data.DataTable dtBatchUpdate = new System.Data.DataTable();
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        private DataGridViewRow dgvrow = new DataGridViewRow();       
        public string init_brand_id;
        public string call_is_flag="";//從報價單基本資料中開啟此表單時，沒有對的公式，提示提前出現的問題      
        

        public frmQuotation_Formula()
        {            
            InitializeComponent();            
            try
            {
                //舊的菜單按鈕的權限及翻譯
                //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                //control.GenerateContorl();
                ////控件翻譯
                //clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
                //obj_ctl.Translate();               
                //設置菜單按鈕的權限
                //clsApp.SetToolBarEnable(this.Name, this.Controls);
                clsToolBar obj = new clsToolBar(this.Name, this.Controls);
                obj.SetToolBar();

                //clsApp.RetSetImage(toolStrip1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            //dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
        }

        //自定義屬性
        private bool isUpdated { get; set; }

        private void frmQuotation_Formula_Load(object sender, EventArgs e)
        {           
            clsQuotation.Set_Brand_id(txtBrand_id);           
            clsQuotation.Set_Brand_id(txtBrand_id1);
            clsQuotation.Set_Brand_id(txtBrand_id2);
            if (!string.IsNullOrEmpty(init_brand_id))
            {
                txtBrand_id1.EditValue = init_brand_id;
                txtBrand_id2.EditValue = init_brand_id;
                Find_Data();
                tabControl1.SelectTab(0);
            }
            else
            {
                string sql =
                @"SELECT A.brand_id,space(255) as brand_name,A.usd1,A.usd2,A.rmb1,A.rmb2,A.hkd1,A.hkd2,A.remark,A.bp_hkd_ex,A.discount,A.crusr,A.crtim,A.amusr,A.amtim,A.usd3,A.id
                FROM dbo.quotation_formula A with(nolock)                                      
                WHERE 1=0 ";
                dtDetail = clsPublicOfCF01.GetDataTable(sql);
                bds1.DataSource = dtDetail;
                dgvDetails.DataSource = bds1;
            }

            //數據綁定
            txtBrand_id.DataBindings.Add("EditValue", bds1, "brand_id");
            txtUsd1.DataBindings.Add("Text", bds1, "usd1");
            txtUsd2.DataBindings.Add("Text", bds1, "usd2");
            txtUsd3.DataBindings.Add("Text", bds1, "usd3");
            txtRmb1.DataBindings.Add("Text", bds1, "rmb1");
            txtRmb2.DataBindings.Add("Text", bds1, "rmb2");
            txtHkd1.DataBindings.Add("Text", bds1, "hkd1");
            txtHkd2.DataBindings.Add("Text", bds1, "hkd2");
            chkBp_hkd_ex.DataBindings.Add("Checked", bds1, "bp_hkd_ex");
            txtDiscount.DataBindings.Add("Text", bds1, "discount");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtCrusr.DataBindings.Add("Text", bds1, "crusr");
            txtCrtim.DataBindings.Add("Text", bds1, "crtim");
            txtAmusr.DataBindings.Add("Text", bds1, "amusr");
            txtAmtim.DataBindings.Add("Text", bds1, "amtim");
            txtID.DataBindings.Add("Text", bds1, "id");

            //tabPage2.Parent = null;
            cmbRmb.SelectedIndex = 0;
            Find_Data();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
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
            Cancel();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            Excel();
        }


        // ===============以下爲自定義方法=======================

        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;
            BTNEXCEL.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            //clsApp.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            if (string.IsNullOrEmpty(txtBrand_id.Text) || string.IsNullOrEmpty(txtUsd1.Text) || string.IsNullOrEmpty(txtUsd2.Text))                
            {               
                MessageBox.Show("注意：USD$參數不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (mState == "NEW")
                {
                    string strsql = String.Format(@"SELECT '1' FROM dbo.quotation_formula with(nolock) WHERE brand_id='{0}'",txtBrand_id.EditValue);
                    System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(string.Format("注意:\n\r牌子編號[{0}]\n\r\n\r已存在,不可以再重復錄入!",txtBrand_id.EditValue), 
                            "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;
            }
        }


        //private void Set_Row_Position(string _brand_id) //定位到當前行 
        //{
        //    Find();
        //    for (int i = 0; i < dgvDetails.RowCount; i++)
        //    {
        //        if (_brand_id == dgvDetails.Rows[i].Cells["brand_id"].Value.ToString() )
        //        {
        //            dgvDetails.Rows[i].Selected = true;
        //            dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["brand_id"]; //設置光標定位到當前選中的行
        //            break;
        //        }
        //    }
        //}

        private void AddNew()  //新增
        {
            tabControl1.SelectTab(0);
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            SetObjValue.ClearObjValue(panel1.Controls, "1");
            dgvDetails.Enabled = false;
            txtBrand_id.Focus();
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            tabControl1.SelectTab(0);
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);

            txtBrand_id.Properties.ReadOnly = true;
            txtBrand_id.BackColor = System.Drawing.Color.White;

            dgvDetails.Enabled = true ;
            dgvDetails.ReadOnly = false ;
            dgvDetails.Columns["brand_id"].ReadOnly =true ;
            dgvDetails.Columns["brand_name"].ReadOnly = true;
            mState = "EDIT";            
            
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            txtBrand_id.Properties.ReadOnly = false;
            //txtBrand_id.Enabled = false;
            dgvDetails.Enabled = true;
            mState = "";
            
            //SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            if (!String.IsNullOrEmpty(mID) && dgvDetails.RowCount > 0)
            {
                //Find_doc(mID);
                dgvDetails.CurrentCell = this.dgvDetails.Rows[row_reset].Cells[2]; //设置当前单元格
                dgvDetails.Rows[row_reset].Selected = true; //選中整行
            }      
            else
                SetObjValue.ClearObjValue(panel1.Controls, "1");
            Find_Data();
        }

        private void Save()  //保存新增或修改的資料
        {
            txtUsd1.Focus();
            if (!Save_Before_Valid())
            {
                return;
            }
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO quotation_formula(brand_id,usd1,usd2,rmb1,rmb2,hkd1,hkd2,remark,bp_hkd_ex,crusr,crtim,usd3,discount)
            VALUES(@brand_id,@usd1,@usd2,@rmb1,@rmb2,@hkd1,@hkd2,@remark,@bp_hkd_ex,@user_id,getdate(),@usd3,@discount)";
            const string sql_update =
            @"UPDATE quotation_formula 
            SET usd1=@usd1,usd2=@usd2,rmb1=@rmb1,rmb2=@rmb2,hkd1=@hkd1,hkd2=@hkd2,remark=@remark,bp_hkd_ex=@bp_hkd_ex,amusr=@user_id,amtim=Getdate(),
            usd3=@usd3,discount=@discount
            WHERE id=@id";
            bool isCheck;
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {                    
                    if (mState == "NEW")
                    {
                        myCommand.Parameters.Clear();
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.AddWithValue("@brand_id", txtBrand_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@usd1", clsApp.Return_Float_Value(txtUsd1.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@usd2", clsApp.Return_Float_Value(txtUsd2.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@rmb1", clsApp.Return_Float_Value(txtRmb1.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@rmb2", clsApp.Return_Float_Value(txtRmb2.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@hkd1", clsApp.Return_Float_Value(txtHkd1.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@hkd2", clsApp.Return_Float_Value(txtHkd2.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@usd3", clsApp.Return_Float_Value(txtUsd3.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@discount", clsApp.Return_Float_Value(txtDiscount.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);                       
                        if (chkBp_hkd_ex.Checked)
                            isCheck = true;
                        else
                            isCheck = false;
                        myCommand.Parameters.AddWithValue("@bp_hkd_ex", isCheck);
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        //=====為刷新更改狀態而加入此代碼===============
                        int cur_row = dgvDetails.CurrentCell.RowIndex;//當前焦點行
                        dtDetail.Rows.Add();
                        dgvDetails.CurrentCell = dgvDetails.Rows[0].Cells["brand_id"];
                        dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.RowCount-1].Cells["brand_id"];
                        dtDetail.Rows.RemoveAt(dgvDetails.RowCount - 1);
                        //恢復定位到當前行
                        //dgvDetails.Rows[cur_row].Selected=true;
                        dgvDetails.CurrentCell = dgvDetails.Rows[cur_row].Cells["brand_id"]; 
                        //============================================
                        myCommand.CommandText = sql_update;
                        for (int i = 0; i < dgvDetails.RowCount; i++)
                        {
                            if (dtDetail.Rows[i].RowState == DataRowState.Modified)
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@id", dgvDetails.Rows[i].Cells["id"].Value);
                                myCommand.Parameters.AddWithValue("@usd1", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["usd1"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@usd2", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["usd2"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@rmb1", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["rmb1"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@rmb2", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["rmb2"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@hkd1", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["hkd1"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@hkd2", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["hkd2"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@usd3", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["usd3"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@discount", clsApp.Return_Float_Value(dgvDetails.Rows[i].Cells["discount"].Value.ToString()));
                                myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);                                
                                if (dgvDetails.Rows[i].Cells["bp_hkd_ex"].Value.ToString() == "True")
                                    isCheck = true;
                                else
                                    isCheck = false;
                                myCommand.Parameters.AddWithValue("@bp_hkd_ex", isCheck);
                                myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                myCommand.ExecuteNonQuery();
                                save_flag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
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
                    myTrans.Dispose();
                }
            }
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            dgvDetails.Enabled = true;
                   

            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtDetail.AcceptChanges();
                mState = "";
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }            
        }

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtBrand_id.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM dbo.quotation_formula WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", Int32.Parse(txtID.Text));
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }
            }
        }

        private void Print() //通用的打印方法
        {
           // tabControl1.SelectTab(1);
            if (dgvDetails.RowCount > 0)
            {
                clsGeneralDataConvert.GridView_To_Print(dgvDetails);
            }
        }

        private void Excel() //匯出EXCEL
        {
            //tabControl1.SelectTab(1);            
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        //===========以下爲控件中的方法================     

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                row_reset = dgvDetails.CurrentCell.RowIndex;
                dgvrow = dgvDetails.CurrentRow;
                //Set_head(dgvrow);
            }
        }

        private void Set_head(DataGridViewRow pdr)
        {
            txtID.Text = pdr.Cells["id"].Value.ToString();  
            txtBrand_id.EditValue = pdr.Cells["brand_id"].Value.ToString();
            txtUsd1.Text = pdr.Cells["usd1"].Value.ToString();
            txtUsd2.Text = pdr.Cells["usd2"].Value.ToString();
            txtRmb1.Text = pdr.Cells["rmb1"].Value.ToString();
            txtRmb2.Text = pdr.Cells["rmb2"].Value.ToString();
            txtHkd1.Text = pdr.Cells["hkd1"].Value.ToString();
            txtHkd2.Text = pdr.Cells["hkd2"].Value.ToString();
            txtRemark.Text = pdr.Cells["remark"].Value.ToString();           
            txtCrusr.Text = pdr.Cells["crusr"].Value.ToString();
            txtCrtim.Text = pdr.Cells["crtim"].Value.ToString();
            txtAmusr.Text = pdr.Cells["amusr"].Value.ToString();
            txtAmtim.Text = pdr.Cells["amtim"].Value.ToString();
            txtUsd3.Text = pdr.Cells["usd3"].Value.ToString();
            txtDiscount.Text = pdr.Cells["discount"].Value.ToString();
            string strCheck = pdr.Cells["bp_hkd_ex"].Value.ToString();
            if (string.IsNullOrEmpty(strCheck) || strCheck == "False")
            {
                chkBp_hkd_ex.Checked = false;
            }
            else
            {
                chkBp_hkd_ex.Checked = true;
            }            
            mID = pdr.Cells["id"].Value.ToString();
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
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    
        private void txtUsd1_Click(object sender, EventArgs e)
        {            
            //txtUsd1.SelectAll();
            Set_Focus(txtUsd1);
        }

        private void txtUsd2_Click(object sender, EventArgs e)
        {
            //txtUsd2.SelectAll();
            Set_Focus(txtUsd2);
        }

        private void txtRmb1_Click(object sender, EventArgs e)
        {
            //txtRmb1.SelectAll();
            Set_Focus(txtRmb1);
        }

        private void txtRmb2_Click(object sender, EventArgs e)
        {
            //txtRmb2.SelectAll();
            Set_Focus(txtRmb2);
        }

        private void txtHkd1_Click(object sender, EventArgs e)
        {
            //txtHkd1.SelectAll();
            Set_Focus(txtHkd1);
        }

        private void txtHkd2_Click(object sender, EventArgs e)
        {
            //txtHkd2.SelectAll();
            Set_Focus(txtHkd2);
        }

        private void Set_Focus(DevExpress.XtraEditors.TextEdit obj)
        {
            if (obj.Text == "0.000")
            {
                obj.Select(1, 0);
            }
        }

        private void txtBrand_id_Click(object sender, EventArgs e)
        {
            txtBrand_id.SelectAll();
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                AddNew();
                Set_head(dgvrow);
                txtID.EditValue = "";
                txtBrand_id.Enabled = true;
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }     

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strRemoeDB = DBUtility.remote_db;
                string strsql = String.Format(
                @"SELECT A.*,S1.brand_name
                FROM dbo.quotation_formula A with(nolock) 
                Left JOIN (Select '*' as id,'所有的牌子' as brand_name UNION SELECT id,name as brand_name from {0}cd_brand with(nolock) Where within_code='0000' AND state<>'2') S1
	                ON A.brand_id=S1.id COLLATE Chinese_Taiwan_Stroke_CI_AS                
                WHERE A.id='{2}'", strRemoeDB, strRemoeDB, temp_id);
                //Chinese_PRC_CI_AS 
                System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                dgvDetails.DataSource = dt;
                if (dt.Rows.Count == 0)
                {                    
                    MessageBox.Show("資料不存在!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                }
                Set_head(dgvDetails.CurrentRow);
            }
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.EditValue= txtBrand_id1.EditValue;
        }     

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BTNSAVE.Enabled)
            {
                Cancel();
            }
            Find_Data();
        }
        private void Find_Data()
        {
            //if (txtBrand_id1.Text == "" && txtBrand_id2.Text == "")
            //{
            //    MessageBox.Show("注意：查詢條件不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@brand_id1",txtBrand_id1.EditValue),
                new SqlParameter("@brand_id2",txtBrand_id2.EditValue)
            };
            dtDetail = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_formula_find", paras);           
            
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;           
            if (dtDetail.Rows.Count == 0 && call_is_flag =="")
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetails2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails2.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails2.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails2.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void txtBrand_id1_Click(object sender, EventArgs e)
        {
            //txtBrand_id1.SelectAll();
        }

        private void txtBrand_id2_Click(object sender, EventArgs e)
        {
            //txtBrand_id2.SelectAll();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
           // tabPage2.Parent = tabControl1;
           // tabControl1.SelectTab(1);
        }

        private void txtUsd3_Click(object sender, EventArgs e)
        {
            //txtHkd2.SelectAll();
            Set_Focus(txtUsd3);
        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {           
            Set_Focus(txtDiscount);
        }

        private void dgvDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //if (dgvDetails.Rows.Count > 0)
            //{               
            //    if (dtDetail.Rows[e.RowIndex].RowState == DataRowState.Modified)
            //        dgvDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0xCC, 0xFF, 0xCC);
            //    else
            //        dgvDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                
            //}
        }

        private void btnBatchFind_Click(object sender, EventArgs e)
        {
            Find_Data_Batch();
        }

        private void Find_Data_Batch()
        {
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@brand_id1",txtBrand_id1.EditValue),
                new SqlParameter("@brand_id2",txtBrand_id2.EditValue),
                new SqlParameter("@rmb_is_more_than_zero",chkRmb.Checked?"1":"")
            };
            dtBatchUpdate = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_formula_find_batch", paras);
            if (dtBatchUpdate.Rows.Count <= 0)
            {
                MessageBox.Show("無滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.isUpdated = false;
            dgvDetails2.DataSource = dtBatchUpdate;
        }

        private void chkSelectAll_MouseUp(object sender, MouseEventArgs e)
        {
            bool isSelectAll;
            if (chkSelectAll.Checked)
            {
                isSelectAll = true;
            }
            else
            {
                isSelectAll = false;
            }
            for (int i = 0; i < dtBatchUpdate.Rows.Count; i++)
            {
                dtBatchUpdate.Rows[i]["flag_select"] = isSelectAll;
            }
            dgvDetails2.DataSource = dtBatchUpdate;
        }

        private void btnBatchEdit_Click(object sender, EventArgs e)
        {            
            if (!clsQuotation.Check_Formula_Batch_Update(DBUtility._user_id))
            {
                MessageBox.Show("當前用戶無此操作權限！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (dgvDetails2.RowCount == 0)
            {
                return;
            }
            bool isSelect = false;
            for (int i = 0; i < dtBatchUpdate.Rows.Count; i++)
            {
                if (dtBatchUpdate.Rows[i]["flag_select"].ToString() == "True")
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                MessageBox.Show("請選擇要批量更改的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(cmbRmb.Text =="" || txtNumber.Text =="" || clsApp.Return_Float_Value(txtNumber.Text)<=0 )
            {
                MessageBox.Show("參數或統一更新值輸入不正確!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbRmb.Focus();
                return;
            }
            for (int i = 0; i < dtBatchUpdate.Rows.Count; i++)
            {
                if (dtBatchUpdate.Rows[i]["flag_select"].ToString() == "True")
                {
                    if (clsApp.Return_Float_Value(dtBatchUpdate.Rows[i]["rmb1"].ToString()) > 0 && clsApp.Return_Float_Value(dtBatchUpdate.Rows[i]["rmb2"].ToString()) > 0)
                    {
                        if (cmbRmb.Text == "RMB參數1")
                        {
                            dtBatchUpdate.Rows[i]["rmb1"] = clsApp.Return_Float_Value(txtNumber.Text);
                        }
                        if (cmbRmb.Text == "RMB參數2")
                        {
                            dtBatchUpdate.Rows[i]["rmb2"] = clsApp.Return_Float_Value(txtNumber.Text);
                        }
                        dtBatchUpdate.Rows[i]["flag_updated"] = true;
                        this.isUpdated = true;
                    }
                }                
            }            
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            if (!clsQuotation.Check_Formula_Batch_Update(DBUtility._user_id))
            {
                MessageBox.Show("當前用戶無此操作權限！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (dgvDetails2.RowCount == 0)
            {
                return;
            }
            if (!this.isUpdated)
            {
                MessageBox.Show("數據尚未進行任何更改，請返回進批量修改！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool isSelect = false;
            for (int i = 0; i < dtBatchUpdate.Rows.Count; i++)
            {
                if (dtBatchUpdate.Rows[i]["flag_select"].ToString() == "True")
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                MessageBox.Show("請選擇要批量更改的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
            if (MessageBox.Show("確認要進行當前操作?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                const string sql_update = @"UPDATE dbo.quotation_formula SET rmb1=@rmb1,rmb2=@rmb2,amusr=@user_id,amtim=Getdate() WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();

                bool save_flag = false;
                try
                {
                    using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                    {
                        for (int i = 0; i < dtBatchUpdate.Rows.Count; i++)
                        {
                            if (dtBatchUpdate.Rows[i]["flag_select"].ToString() == "True" && dtBatchUpdate.Rows[i]["flag_updated"].ToString() == "True")
                            {
                                if (clsApp.Return_Float_Value(dtBatchUpdate.Rows[i]["rmb1"].ToString()) > 0 && clsApp.Return_Float_Value(dtBatchUpdate.Rows[i]["rmb2"].ToString()) > 0)
                                {                                   
                                    myCommand.CommandText = sql_update;
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", dtBatchUpdate.Rows[i]["id"].ToString());
                                    myCommand.Parameters.AddWithValue("@rmb1", clsApp.Return_Float_Value(dtBatchUpdate.Rows[i]["rmb1"].ToString()));
                                    myCommand.Parameters.AddWithValue("@rmb2", clsApp.Return_Float_Value(dtBatchUpdate.Rows[i]["rmb2"].ToString()));
                                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                    myCommand.ExecuteNonQuery();
                                    save_flag = true;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    myTrans.Commit(); //數據提交
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
                    myTrans.Dispose();
                }                

                if (save_flag)
                {                    
                    Find_Data_Batch();
                    MessageBox.Show("批量更新成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    //刷新Page1數據編輯畫面
                    if (BTNSAVE.Enabled)
                    {
                        Cancel();
                    }
                    Find_Data();
                }
                else
                {
                    MessageBox.Show("批量更新失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void dgvDetails2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvDetails2.Rows.Count > 0)
            {
                if (dtBatchUpdate.Rows[e.RowIndex]["flag_updated"].ToString() == "True")
                {
                    dgvDetails2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0xCC, 0xFF, 0xCC);
                }
            }
        }

       
      

          
     
        
    }
}
