//*************************************************
//**測試發票 用于記錄送出去做測試的收費情況
//Create by: Allen Leung 2018-11-27
//*************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using cf01.MDL;
using System.IO;
using System.Threading;
using DevExpress.XtraReports.UI;
using cf01.Reports;

namespace cf01.Forms
{
    public partial class frmTestInvoice : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mInv = "";
        public string m_invoice_id_old = "";//修改發票主鍵
        public string mState = ""; //新增或編輯的狀態
        public static string str_language = "0";
        public bool save_flag;
        public string strgroup = "";        

        DataTable dtMostly = new DataTable();
        DataTable dtDetails = new DataTable();
        DataTable dtTempDel = new DataTable();
        DataTable dtFind_Date = new DataTable();

        private clsAppPublic clsApp = new clsAppPublic();
        public List<mdlTestInvoiceData> lsModel = new List<mdlTestInvoiceData>();


        public frmTestInvoice()
        {
            InitializeComponent();

            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            str_language = DBUtility._language;
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
        }

        private void frmTestInvoice_Load(object sender, EventArgs e)
        {
            //生成明細表,附加費表結構
            dtDetails = clsPublicOfCF01.GetDataTable("Select * From dbo.bs_test_invoice_details Where 1=0");
            gridControl1.DataSource = dtDetails;
            strgroup = clsDgdDeliverGoods.getUserGroup(DBUtility._user_id);
            
            //臨時項目刪除表結構
            dtTempDel = dtDetails.Clone();

            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                dgvDetails.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            dtCreate_date1.EditValue = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd").Substring(0, 10);
            dtCreate_date2.EditValue = DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 10);
            //原材料
            DataTable dtMat = clsPublicOfCF01.GetDataTable(@"SELECT id,id +' ('+ name+')' as cdesc FROM dbo.bs_test_mat_type");
            DataRow dr0 = dtMat.NewRow(); //插一空行        
            dtMat.Rows.InsertAt(dr0, 0);
            clMat_id.DataSource = dtMat;
            clMat_id.ValueMember = "id";
            clMat_id.DisplayMember = "cdesc";

            //產品類別            
            DataTable dtProduct_type = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc FROM dbo.bs_test_product_type");
            clPoduct_type_id.DataSource = dtProduct_type;
            clPoduct_type_id.ValueMember = "id";
            clPoduct_type_id.DisplayMember = "cdesc";
            //測試項目
            DataTable dtTestItem = clsPublicOfCF01.GetDataTable(
            @"SELECT test_item_id as id,test_item_id+'('+test_item_name+')' as cdesc FROM dgerp2.cferp.dbo.cd_qc_test_item order by id");
            clTestitem.DataSource = dtTestItem;
            clTestitem.ValueMember = "id";
            clTestitem.DisplayMember = "cdesc";
            //顏色類別
            DataTable dtColor = clsPublicOfCF01.GetDataTable(@"SELECT id,id +' ('+ cdesc+')' AS cdesc,edesc FROM dbo.bs_test_color_category");
            clColor_id.DataSource = dtColor;
            clColor_id.ValueMember = "id";
            clColor_id.DisplayMember = "cdesc";
            //貨幣
            DataTable dtCurrency = clsPublicOfCF01.GetDataTable(@"SELECT distinct id FROM dgerp2.cferp.dbo.cd_exchange_rate ");
            lkeamount_unit.Properties.DataSource = dtCurrency;
            lkeamount_unit.Properties.ValueMember = "id";
            lkeamount_unit.Properties.DisplayMember = "id";
            //查詢條件中的組別
            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                    txtSales_group1.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }
            }
            radioGroup1.SelectedIndex = 2;
            radioGroup2.SelectedIndex = 1;
            Add_Data();
        }

        private void Add_Data()
        {
            if (lsModel.Count > 0)//有數據傳遞(測試EXCEL錄入界面調用發票錄入窗口)
            {
                //查出同一張測試報告的全部數據
                string str_test_report_no = "";
                foreach (mdlTestInvoiceData omdl in lsModel)
                {
                    str_test_report_no = omdl.test_report_no; //提取其中一個測試報告即可.
                    break;
                }
                //Find_doc(str_test_report_no);
                string strsql = String.Format(@"SELECT top 1 * FROM bs_test_invoice_mostly WITH(nolock) WHERE id ='{0}'", str_test_report_no);
                dtMostly = clsPublicOfCF01.GetDataTable(strsql);
                if (dtMostly.Rows.Count > 0)
                {
                    Set_Master_Data(dtMostly);
                    //根據主表取得對應的發票號再取得對應的明細資料
                    dtDetails.Clear();
                    string invoice_no = dtMostly.Rows[0]["invoice_id"].ToString();
                    strsql = String.Format(
                        @"Select *,space(5) as seq From bs_test_invoice_details with(nolock) 
                        Where id='{0}' and invoice_id='{1}'", str_test_report_no, invoice_no);
                    dtDetails = clsPublicOfCF01.GetDataTable(strsql);
                    gridControl1.DataSource = dtDetails;
                }
                else
                {
                    SetObjValue.ClearObjValue(panel1.Controls, "2");//清空全部數據                   
                }
                 
                if (dgvDetails.RowCount > 0)//已保存有發票資料
                {
                    DataTable dt = dtDetails;
                    foreach (mdlTestInvoiceData omdl in lsModel)
                    {
                        DataRow[] dtrw = dt.Select(string.Format("sales_group='{0}' and mat_id='{1}' and product_type_id='{2}' and color_id='{3}' and trim_code='{4}' and test_item_id='{5}' and cust_color='{6}'",
                                      omdl.sales_group, omdl.mat_id, omdl.product_type_id, omdl.color_id, omdl.trim_code, omdl.test_item_id, omdl.cust_color));
                        if (dtrw.Length > 0)
                        {
                            continue;//已存在的記錄不需再加進去
                        }
                        else
                        {
                            if (mState == "")
                            {
                                Edit();
                            }
                            if (mState == "EDIT")
                            {
                                AddNew_Item();
                                Insert_New_Record(omdl);
                            }
                        }
                    }
                }
                else //未有發票資料 自動生成表頭及明細資料
                {
                    AddNew();
                    txtID.Text = str_test_report_no;                   
                    foreach (mdlTestInvoiceData omdl in lsModel)
                    {
                        AddNew_Item();
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", str_test_report_no);
                        Insert_New_Record(omdl);
                    }
                }
            }
        }

        private void Insert_New_Record(mdlTestInvoiceData objmdl)
        {
            if (txtSales_group.Text == "" && mState == "NEW")
            {
                txtSales_group.Text = objmdl.sales_group;//自動生成單據時更新主檔組別
            }
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sales_group", objmdl.sales_group);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mat_id", objmdl.mat_id);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "product_type_id", objmdl.product_type_id);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "color_id", objmdl.color_id);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "trim_code", objmdl.trim_code);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "cust_color", objmdl.cust_color);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "test_item_id", objmdl.test_item_id);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "expiry_date", objmdl.expiry_date);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_mo", objmdl.ref_mo);
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_pass", true);
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

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();//刪除主檔資料
        }

        private void BTNITEMADD_Click(object sender, EventArgs e)
        {
            AddNew_Item();
        }

        private void BTNITEMDEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show("是否刪除當前明細資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = dgvDetails.FocusedRowHandle;
                //將當前行刪除幷加到臨時表中
                DataRow newRow = dtTempDel.NewRow();
                newRow["id"] = txtID.Text;
                newRow["invoice_id"] = dgvDetails.GetRowCellDisplayText(curRow, "invoice_id");
                newRow["sequence_id"] = dgvDetails.GetRowCellDisplayText(curRow, "sequence_id");
                newRow["test_item_id"] = dgvDetails.GetRowCellDisplayText(curRow, "test_item_id");
                dtTempDel.Rows.Add(newRow);
                dgvDetails.DeleteRow(curRow);//移走當前行
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtremark.Focus();//Toolscript焦點問題
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dtFind_Date.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("invoice_date", typeof(string));
            dtReport.Columns.Add("invoice_id", typeof(string));            
            dtReport.Columns.Add("seq", typeof(Int32));
            dtReport.Columns.Add("sales_group", typeof(string));
            dtReport.Columns.Add("confirm_ac", typeof(bool));
            for (int i=0;i< dtFind_Date.Rows.Count; i++)
            {
                DataRow drw = dtReport.Rows.Add();
                drw["invoice_date"] = dtFind_Date.Rows[i]["invoice_date"].ToString();
                drw["invoice_id"] = dtFind_Date.Rows[i]["invoice_id"].ToString();
                drw["seq"] = i+1;
                drw["sales_group"] = dtFind_Date.Rows[i]["sales_group"].ToString();
                drw["confirm_ac"] = dtFind_Date.Rows[i]["confirm_ac"];                
            }
            using (xrTestInvoice rpt = new xrTestInvoice() { DataSource = dtReport })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
            }
        }        

        private void AddNew()  //新增
        {
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            Set_Grid_Status(true);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            SetObjValue.ClearObjValue(panel1.Controls, "1");

            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);

            dtreport_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            dtinvoice_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtamount.Text = "0.00";
            lkeamount_unit.EditValue = "HKD";
            dtDetails.Clear();
            gridControl1.DataSource = dtDetails;
        }

        private void Edit()  //編輯
        {
            if (txtID.Text == "")
            {
                return;
            }
            //if (!string.IsNullOrEmpty(txtconfirm_pdd_by.Text))
            if (!string.IsNullOrEmpty(txtconfirm_ac_by.Text)) //2021/06/09取消PDD確認,故改為判斷AC是否確認.
            {
                MessageBox.Show("AC 已確認，當前操作無效!");
                return;
            }
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;
            txtinvoice_id.Properties.ReadOnly = true;
            txtinvoice_id.BackColor = Color.White;
        }

        private void SetButtonSatus(bool _flag) //設置工具欄
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            //BTNFIND.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            BTNITEMADD.Enabled = !_flag;
            BTNITEMADDCOPY.Enabled = !_flag;
            BTNITEMDEL.Enabled = !_flag;
            BTNCONFIRM_PDD.Enabled = _flag;
            BTNCONFIRM_AC.Enabled = _flag;
            dgvFind.Enabled = _flag;

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private void Set_Grid_Status(bool _flag) // 表格可編號否
        {
            //false--不可編輯;true--可以編輯
            dgvDetails.OptionsBehavior.Editable = _flag;
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            //if (!string.IsNullOrEmpty(txtconfirm_pdd_by.Text))
            if (!string.IsNullOrEmpty(txtconfirm_ac_by.Text)) //2021/06/09取消PDD確認,故改為判斷AC是否確認.
            {
                MessageBox.Show("AC 已確認，當前操作無效!");
                return;
            }
            DialogResult result = MessageBox.Show("此操作將刪除主表及明細中的資料,請謹慎操作!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = @"DELETE FROM bs_test_invoice_mostly WHERE id=@id and invoice_id=@invoice_id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@invoice_id", txtinvoice_id.Text.Trim());
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit(); //數據提交                        
                        MessageBox.Show("數據刪除成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(panel1.Controls, "1");
                        dtDetails.Clear();
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

        /// <summary>
        /// 添加明細表新行
        /// </summary>
        private void AddNew_Item()
        {
            //if (!String.IsNullOrEmpty(txtID.Text.Trim()) && !String.IsNullOrEmpty(txtinvoice_id.Text.Trim())) // 有內容
            if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
                {
                if (Check_Details_Valid())
                {
                    return;
                }
                Set_Grid_Status(true);
                dgvDetails.AddNewRow();//新增
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "invoice_id",txtinvoice_id.Text.Trim());
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount).ToString("000"));
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_pass", false);

                ColumnView view = (ColumnView)dgvDetails;//初始單元格焦點
                view.FocusedColumn = view.Columns["test_item_id"];
                view.Focus();
            }
            else
            {
                MessageBox.Show("主檔編號不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
            }
        }

        private bool Check_Details_Valid() //檢查明細資料的有效性
        {
            //測試項目必須有輸入
            bool _flag = false;
            if (dgvDetails.RowCount > 0)
            {
                txtremark.Focus();
                //因toolStrip控件焦點問題
                //設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，防止取到的值爲空
                // ColumnView view = (ColumnView)gridView1 ;
                // view.FocusedColumn = view.Columns["test_item_id"];    
                int curRow = 0;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    curRow = dgvDetails.GetRowHandle(i);
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "test_item_id")) ||
                        String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "mat_id")) ||
                        String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "sales_group")))
                    {
                        _flag = true;
                        MessageBox.Show("組別，原材料，測試項目不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)dgvDetails;
                        view1.FocusedColumn = view1.Columns["test_item_id"]; //設置單元格焦點
                        break;
                    }
                }
            }
            return _flag;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "2");
            Set_Grid_Status(false);

            dtTempDel.Clear();
            dtDetails.Clear();
            gridControl1.DataSource = dtDetails;                     
           
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID,mInv);
            }
            mState = "";            
            m_invoice_id_old = "";
        }

        private void Find_doc(string id,string invoice_id) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(id))
            {
                string sql_h = String.Format(@"SELECT * FROM bs_test_invoice_mostly WITH(nolock) WHERE id ='{0}' and invoice_id='{1}'", id,invoice_id);
                string sql_details = String.Format(@"Select *,space(5) as seq From bs_test_invoice_details with(nolock) Where id='{0}' and invoice_id='{1}'", id, invoice_id);
                dtDetails = clsPublicOfCF01.GetDataTable(sql_details);

                dtMostly = clsPublicOfCF01.GetDataTable(sql_h);
                if (dtMostly.Rows.Count > 0)
                    Set_Master_Data(dtMostly);
                else
                {
                    SetObjValue.ClearObjValue(panel1.Controls, "2");
                    return;
                }
                dtDetails.Clear();
                dtDetails = clsPublicOfCF01.GetDataTable(sql_details);
                gridControl1.DataSource = dtDetails;

                mID = txtID.Text;//保存臨時的ID號    
                mInv = txtinvoice_id.Text;           
            }
        }

        private void Save()  //保存
        {
            if (!Save_Before_Valid())
            {
                return;
            }
            if (float.Parse(txtamount.Text) == 0)
            {
                MessageBox.Show("發票金額不可為空!", "提示信息");
                txtamount.Focus();
                return;
            }
            if (lkeamount_unit.Text == "")
            {
                MessageBox.Show("貨幣單位不可為空!", "提示信息");
                lkeamount_unit.Focus();
                return;
            }
            if (txtSales_group.Text == "")
            {
                MessageBox.Show("組別不可為空!", "提示信息");
                txtSales_group.Focus();
                return;
            }
            if (Check_Details_Valid())//檢查明細資料的有效性
            {
                return;
            }
            
            save_flag = false;
            #region  保存新增或編輯
            if (mState == "NEW" || mState == "EDIT")
            {
                if (mState == "NEW")
                {
                    string strSql = String.Format("Select '1' FROM dbo.bs_test_invoice_mostly WHERE id='{0}' and invoice_id='{0}'", txtID.Text.Trim(), txtinvoice_id.Text);
                    if (clsPublicOfCF01.ExecuteSqlReturnObject(strSql) != "")
                    {
                        MessageBox.Show(string.Format("注意:測試報告編號,發票編號【{0}/{1}】已存在!", txtID.Text, txtinvoice_id.Text), "提示信息");
                        return;
                    }
                }
                const string sql_i =
                @"INSERT INTO dbo.bs_test_invoice_mostly(id,report_date,brand,invoice_id,invoice_date,amount,amount_unit,chemical_test,physical_test,own_reference,remark,create_by,create_date,sales_group)
                 VALUES(@id,@report_date,@brand,@invoice_id,@invoice_date,@amount,@amount_unit,@chemical_test,@physical_test,@own_reference,@remark,@user_id,getdate(),@sales_group)";
                string sql_u = "";
                if (m_invoice_id_old == "")
                {
                    //正常的修改
                    sql_u =
                    @"Update bs_test_invoice_mostly 
                    SET report_date=@report_date,brand=@brand,invoice_date=@invoice_date,amount=@amount,amount_unit=@amount_unit,chemical_test=@chemical_test,physical_test=@physical_test,
                    own_reference=@own_reference,remark=@remark,update_by=@user_id,update_date=getdate(),sales_group=@sales_group
                    WHERE id=@id and invoice_id=@invoice_id";
                }
                else
                {
                    //修改了主鍵發票編號
                    sql_u =
                    @"Update bs_test_invoice_mostly 
                    SET invoice_id=@invoice_id,report_date=@report_date,brand=@brand,invoice_date=@invoice_date,amount=@amount,amount_unit=@amount_unit,chemical_test=@chemical_test,physical_test=@physical_test,
                    own_reference=@own_reference,remark=@remark,update_by=@user_id,update_date=getdate(),sales_group=@sales_group
                    WHERE id=@id and invoice_id='"+ m_invoice_id_old+"'";
                }

                SqlConnection myCon = new SqlConnection(DBUtility.connectionString); //connect to dgsql2
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        if (mState == "NEW")
                        {
                            myCommand.CommandText = sql_i;
                            //****2020-02-25
                            //因主鍵后期改成報告編號+發票編號,從Testexcel畫面第一次生成INVOICE時發票字段是空白,項目新增時主鍵為空會有問題,故做以下處理                            
                            int cur_row;
                            for (int i = 0; i < dgvDetails.RowCount; i++)
                            {
                                cur_row = dgvDetails.GetRowHandle(i);
                                dgvDetails.SetRowCellValue(cur_row, "invoice_id", txtinvoice_id.Text.Trim());
                            }
                        }
                        else
                        {
                            myCommand.CommandText = sql_u;
                        }
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@report_date", clsApp.Return_String_Date(dtreport_date.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@brand", txtbrand.Text);
                        myCommand.Parameters.AddWithValue("@invoice_id", txtinvoice_id.Text);
                        myCommand.Parameters.AddWithValue("@invoice_date", clsApp.Return_String_Date(dtinvoice_date.EditValue.ToString()));
                        myCommand.Parameters.AddWithValue("@amount", decimal.Parse(txtamount.Text));
                        myCommand.Parameters.AddWithValue("@amount_unit", lkeamount_unit.EditValue);
                        myCommand.Parameters.AddWithValue("@chemical_test", clsApp.Return_Float_Value(txtchemical_test.Text));
                        myCommand.Parameters.AddWithValue("@physical_test", clsApp.Return_Float_Value(txtphysical_test.Text));
                        myCommand.Parameters.AddWithValue("@own_reference", txtown_reference.Text);
                        myCommand.Parameters.AddWithValue("@remark", txtremark.Text);
                        myCommand.Parameters.AddWithValue("@sales_group", txtSales_group.Text);                        
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                        //處理【項目刪除】刪除明細資料
                        string sql_item_d;
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            //刪除明細
                            sql_item_d = @"DELETE FROM dbo.bs_test_invoice_details WHERE id=@id and invoice_id=@invoice_id and sequence_id=@sequence_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@invoice_id", dtTempDel.Rows[i]["invoice_id"].ToString());                           
                            myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                        //保存明細
                        int curRow;
                        string rowStatus;
                        if (dgvDetails.RowCount > 0)
                        {                            
                            const string sql_item_i =
                                 @"INSERT INTO dbo.bs_test_invoice_details
                                (id,invoice_id,sequence_id,sales_group,mat_id,color_id,product_type_id,cust_color,trim_code,test_item_id,expiry_date,ref_mo,is_pass) VALUES
                                (@id,@invoice_id,@sequence_id,@sales_group,@mat_id,@color_id,@product_type_id,@cust_color,@trim_code,@test_item_id,CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END,@ref_mo,@is_pass)";
                            string sql_item_u = "";
                            if (m_invoice_id_old == "")
                            {
                                //正常的修改
                                sql_item_u =
                                    @"Update dbo.bs_test_invoice_details 
                                    SET sales_group=@sales_group,mat_id=@mat_id,color_id=@color_id,product_type_id=@product_type_id,cust_color=@cust_color,trim_code=@trim_code,test_item_id=@test_item_id,
                                    expiry_date=CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END,ref_mo=@ref_mo,is_pass=@is_pass
                                    Where id=@id And invoice_id=@invoice_id And sequence_id=@sequence_id";
                            }
                            else
                            {
                                //修改了主鍵發票編號
                                sql_item_u =
                                    @"Update dbo.bs_test_invoice_details 
                                    SET invoice_id=@invoice_id,sales_group=@sales_group,mat_id=@mat_id,color_id=@color_id,product_type_id=@product_type_id,cust_color=@cust_color,trim_code=@trim_code,test_item_id=@test_item_id,
                                    expiry_date=CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END,ref_mo=@ref_mo,is_pass=@is_pass
                                    Where id=@id And invoice_id='" + m_invoice_id_old + "'" + " And sequence_id=@sequence_id";
                            }
                            dgvDetails.CloseEditor();
                            for (int i = 0; i < dgvDetails.RowCount; i++)
                            {
                                curRow = dgvDetails.GetRowHandle(i);
                                //dgvDetails.AddNewRow();//新增必須初始貨當前單元格焦點
                                //否則rowStatus取不到狀態值
                                rowStatus = dgvDetails.GetDataRow(curRow).RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                        myCommand.CommandText = sql_item_i;
                                    else
                                        myCommand.CommandText = sql_item_u;
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                    myCommand.Parameters.AddWithValue("@invoice_id",txtinvoice_id.Text.Trim());
                                    myCommand.Parameters.AddWithValue("@sequence_id", dgvDetails.GetRowCellValue(curRow, "sequence_id").ToString());
                                    myCommand.Parameters.AddWithValue("@sales_group", dgvDetails.GetRowCellValue(curRow, "sales_group").ToString());
                                    myCommand.Parameters.AddWithValue("@mat_id", dgvDetails.GetRowCellValue(curRow, "mat_id").ToString());
                                    myCommand.Parameters.AddWithValue("@color_id", dgvDetails.GetRowCellValue(curRow, "color_id").ToString());
                                    myCommand.Parameters.AddWithValue("@product_type_id", dgvDetails.GetRowCellValue(curRow, "product_type_id").ToString());
                                    myCommand.Parameters.AddWithValue("@cust_color", dgvDetails.GetRowCellValue(curRow, "cust_color").ToString());
                                    myCommand.Parameters.AddWithValue("@trim_code", dgvDetails.GetRowCellValue(curRow, "trim_code").ToString());
                                    myCommand.Parameters.AddWithValue("@test_item_id", dgvDetails.GetRowCellValue(curRow, "test_item_id").ToString());
                                    myCommand.Parameters.AddWithValue("@expiry_date", clsApp.Return_String_Date(dgvDetails.GetRowCellValue(curRow, "expiry_date").ToString()));
                                    myCommand.Parameters.AddWithValue("@ref_mo", dgvDetails.GetRowCellValue(curRow, "ref_mo").ToString());
                                    bool bl_is_pass;
                                    if (dgvDetails.GetRowCellValue(curRow, "is_pass").ToString() == "True")
                                        bl_is_pass = true;
                                    else
                                        bl_is_pass = false;
                                    myCommand.Parameters.AddWithValue("@is_pass", bl_is_pass);
                                    myCommand.ExecuteNonQuery();
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
                    }
                }
            }
            #endregion

            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            Set_Grid_Status(false);
            mState = "";           
            m_invoice_id_old = "";
            dtTempDel.Clear();
            if (save_flag)
            {
                Find_doc(txtID.Text,txtinvoice_id.Text);
                clsUtility.myMessageBox("當前數據保存成功!", "提示信息");
            }
            else
            {
                MessageBox.Show("當前數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (txtID.Text == "" || dtreport_date.Text == "" || txtinvoice_id.Text == "" || dtinvoice_date.Text == "")
            {
                MessageBox.Show("報告編號、報告日期、發票編號或者發票日期不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        public static string Get_Details_Seq(string id,string invoice_id) //取明細最大序號
        {
            DataTable dtMaxseq = new DataTable();
            dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(sequence_id) as seq_id FROM bs_test_invoice_details with(nolock) WHERE id ='{0} and invoice_id='{1}'", id, invoice_id));

            string strSeq;
            if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
            {
                strSeq = "001";
            }
            else
            {
                strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = strSeq.Substring(0, 4);
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000");
            }
            dtMaxseq.Dispose();
            return strSeq;
        }

        private void Set_Master_Data(DataTable dt) //綁定主檔資料
        {
            txtID.Text = dt.Rows[0]["id"].ToString();
            txtinvoice_id.Text = dt.Rows[0]["invoice_id"].ToString();
            if (string.IsNullOrEmpty(dt.Rows[0]["report_date"].ToString()))
                dtreport_date.EditValue = "";
            else
                dtreport_date.EditValue = Convert.ToDateTime(dt.Rows[0]["report_date"].ToString()).ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(dt.Rows[0]["invoice_date"].ToString()))
                dtinvoice_date.EditValue = "";
            else
                dtinvoice_date.EditValue = Convert.ToDateTime(dt.Rows[0]["invoice_date"].ToString()).ToString("yyyy-MM-dd");
            txtamount.Text = dt.Rows[0]["amount"].ToString();
            lkeamount_unit.EditValue = dt.Rows[0]["amount_unit"].ToString();
            txtchemical_test.Text = dt.Rows[0]["chemical_test"].ToString();
            txtphysical_test.Text = dt.Rows[0]["physical_test"].ToString();
            txtbrand.Text = dt.Rows[0]["brand"].ToString();
            txtown_reference.Text = dt.Rows[0]["own_reference"].ToString();
            txtremark.Text = dt.Rows[0]["remark"].ToString();

            txtCreate_by.Text = dt.Rows[0]["create_by"].ToString();
            txtCreate_date.Text = dt.Rows[0]["create_date"].ToString();
            txtupdate_by.Text = dt.Rows[0]["update_by"].ToString();
            txtupdate_date.Text = dt.Rows[0]["update_date"].ToString();

            txtconfirm_pdd_by.Text = dt.Rows[0]["confirm_pdd_by"].ToString();
            txtconfirm_pdd_date.Text = dt.Rows[0]["confirm_pdd_date"].ToString();
            txtconfirm_ac_by.Text = dt.Rows[0]["confirm_ac_by"].ToString();
            txtconfirm_ac_date.Text = dt.Rows[0]["confirm_ac_date"].ToString();
            txtSales_group.Text = dt.Rows[0]["sales_group"].ToString();            
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text)&& !String.IsNullOrEmpty(txtinvoice_id.Text))
            {
                if (mState == "") //流覽模式
                {
                    Find_doc(txtID.Text, txtinvoice_id.Text);
                }
            }
        }

        private void frmTestInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.GC.Collect();
            lsModel = null;
            clsApp = null;
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtTempDel.Dispose();
            dtFind_Date.Dispose();
        }

        private void dgvDetails_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (dgvDetails.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = dgvDetails.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void dgvDetails_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mState != "")
                return;
            Find_Date();
        }

        private void Find_Date()
        {
            if (BTNCANCEL.Enabled)
            {
                Cancel();
            }
            SqlParameter[] spars = new SqlParameter[]{
                new SqlParameter("@id1",txtId1.Text),
                new SqlParameter("@id2",txtId2.Text),
                new SqlParameter("@report_date1",dtreport_date1.Text),
                new SqlParameter("@report_date2",dtreport_date2.Text),
                new SqlParameter("@invoice_id1",txtinvoice_id1.Text),
                new SqlParameter("@invoice_id2",txtinvoice_id2.Text),
                new SqlParameter("@invoice_date1",dtinvoice_date1.Text),
                new SqlParameter("@invoice_date2",dtinvoice_date2.Text),
                new SqlParameter("@create_date1",dtCreate_date1.Text),
                new SqlParameter("@create_date2",dtCreate_date2.Text),
                new SqlParameter("@brand",txtbrand1.Text),
                new SqlParameter("@sales_group",txtSales_group1.Text),
                new SqlParameter("@confirm_by",radioGroup1.SelectedIndex),
                new SqlParameter("@pdd_or_ac",radioGroup2.SelectedIndex),
                new SqlParameter("@pdd_confirm_date1",dtPdd1.Text),
                new SqlParameter("@pdd_confirm_date2",dtPdd2.Text)
            };            
            DataSet dts = clsPublicOfCF01.ExecuteProcedureReturnDataSet("usp_rpt_test_invoice", spars, null);
            dtFind_Date = dts.Tables[0];
            dgvFind.DataSource = dtFind_Date;
            if (dtFind_Date.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvTotal.DataSource = dts.Tables[1];
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.RowCount > 0)
            {
                string id_inv = txtID.Text + txtinvoice_id.Text;
                string cur_id_inv = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString() + dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["invoice_id1"].Value.ToString();
                if (id_inv != cur_id_inv)
                {                   
                    Find_doc(dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString(), dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["invoice_id1"].Value.ToString());
                }
            }
        }

        private void dtreport_date1_Leave(object sender, EventArgs e)
        {
            dtreport_date2.EditValue = dtreport_date1.EditValue;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtinvoice_id1_Leave(object sender, EventArgs e)
        {
            txtinvoice_id2.Text = txtinvoice_id1.Text;
        }

        private void dtinvoice_date1_Leave(object sender, EventArgs e)
        {
            dtinvoice_date2.EditValue = dtinvoice_date1.EditValue;
        }

        private void dtCreate_date1_Leave(object sender, EventArgs e)
        {
            dtCreate_date2.EditValue = dtCreate_date1.EditValue;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (dgvFind.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出數據!", "提示信息");
                return;
            }
            ExportExcel(dgvFind);
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (dgvFind.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出數據!", "提示信息");
                return;
            }
            ExpToExcel oxls = new ExpToExcel();
            oxls.ExportExcel(dgvTotal);
            oxls = null;
        }

        private void BTNITEMADDCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                int i = dgvDetails.FocusedRowHandle;
                mdlTestInvoiceData omdl = new mdlTestInvoiceData()
                {
                    sales_group = dgvDetails.GetRowCellValue(i, "sales_group").ToString(),
                    mat_id = dgvDetails.GetRowCellValue(i, "mat_id").ToString(),
                    color_id = dgvDetails.GetRowCellValue(i, "color_id").ToString(),
                    product_type_id = dgvDetails.GetRowCellValue(i, "product_type_id").ToString(),
                    cust_color = dgvDetails.GetRowCellValue(i, "cust_color").ToString(),
                    trim_code = dgvDetails.GetRowCellValue(i, "trim_code").ToString(),                    
                    ref_mo = dgvDetails.GetRowCellValue(i, "ref_mo").ToString()
                };
                AddNew_Item();
                i = dgvDetails.FocusedRowHandle;//新增后的當前行
                dgvDetails.SetRowCellValue(i, "sales_group", omdl.sales_group);
                dgvDetails.SetRowCellValue(i, "mat_id", omdl.mat_id);
                dgvDetails.SetRowCellValue(i, "color_id", omdl.color_id);
                dgvDetails.SetRowCellValue(i, "product_type_id", omdl.product_type_id);
                dgvDetails.SetRowCellValue(i, "cust_color", omdl.cust_color);
                dgvDetails.SetRowCellValue(i, "trim_code", omdl.trim_code);                          
                dgvDetails.SetRowCellValue(i, "ref_mo", omdl.ref_mo);
            }
        }

        private bool Is_Selected(string ptype)
        {
            bool select_flag = false;
            for (int i = 0; i < dtFind_Date.Rows.Count; i++)
            {
                if (ptype == "PDD")
                {                    
                    if (dtFind_Date.Rows[i]["confirm_pdd"].ToString() == "True")
                    {
                        select_flag = true;
                        break;
                    }
                }
                else
                {                  
                    if (dtFind_Date.Rows[i]["confirm_ac"].ToString() == "True")
                    {
                        select_flag = true;
                        break;
                    }
                }
            }
            if (!select_flag)
            {
                MessageBox.Show("請首先選擇需要確認的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return select_flag;
        }

        private void BTNCONFIRM_PDD_Click(object sender, EventArgs e)
        {
            //Update_Confirm("PDD"); //2021/06/09 CANCEL
        }

        private void BTNCONFIRM_AC_Click(object sender, EventArgs e)
        {
            Update_Confirm("AC");
        }

        private void Update_Confirm(string confirm_type)
        {
            if (dgvFind.Rows.Count > 0)
            {
                txtremark.Focus();
                if (!Is_Selected(confirm_type))
                {
                    return;
                }
                bool flag_confirm = false;
                try
                {
                    string ls_sql = "";
                    dtFind_Date.AcceptChanges();
                    for (int i = 0; i < dtFind_Date.Rows.Count; i++)
                    {
                        if (confirm_type == "PDD")
                        {
                            string ss = dtFind_Date.Rows[i]["confirm_pdd_date"].ToString();
                            if (dtFind_Date.Rows[i]["confirm_pdd"].ToString() == "True" && dtFind_Date.Rows[i]["confirm_pdd_date"].ToString() == "")
                            {
                                ls_sql = string.Format(
                                    @"Update dbo.bs_test_invoice_mostly SET confirm_pdd=1,confirm_pdd_by='{0}',confirm_pdd_date=getdate() 
                                    Where id='{1}' and invoice_id='{2}'", DBUtility._user_id, dtFind_Date.Rows[i]["id"].ToString(), dtFind_Date.Rows[i]["invoice_id"].ToString());
                                clsPublicOfCF01.ExecuteSqlUpdate(ls_sql);
                            }
                        }
                        else
                        {
                            if (dtFind_Date.Rows[i]["confirm_ac"].ToString() == "True" && dtFind_Date.Rows[i]["confirm_ac_date"].ToString() == "")
                            {
                                ls_sql = string.Format(
                                    @"Update dbo.bs_test_invoice_mostly SET confirm_ac=1,confirm_ac_by='{0}',confirm_ac_date=getdate() 
                                      Where id='{1}' and invoice_id='{2}'", DBUtility._user_id, dtFind_Date.Rows[i]["id"].ToString(), dtFind_Date.Rows[i]["invoice_id"].ToString());
                                clsPublicOfCF01.ExecuteSqlUpdate(ls_sql);
                            }
                        }
                    }
                    flag_confirm = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("[{0}] 確認失敗：{1}", confirm_type, ex), "提示信息");
                    flag_confirm = false;
                    return;
                }
                if (flag_confirm)
                {
                    MessageBox.Show(String.Format("[{0}] 確認成功！", confirm_type), "提示信息");
                }
            }
        }        

        private void dgvDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private static void ExportExcel(DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Title = "保存EXECL文件";
                saveDialog.Filter = "EXECL文件|*.xls";
                saveDialog.FilterIndex = 1;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    int FormatNum;//保存excel文件的格式
                    string Version;//excel版本號

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("無法倉建Excel對象,可能當前操作系統上未安裝有Excel");
                        return;
                    }
                    Version = xlApp.Version;//獲取當前使用excel版本號
                    if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                    {
                        FormatNum = -4143;
                    }
                    else //you use excel 2007 or later
                    {
                        FormatNum = 56;
                    }

                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();

                    //寫入標題  
                    const string ls_colum_remove = "PDD Confirm,AC Confirm";
                    int li_cls_index = 0;
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        if (ls_colum_remove.Contains(myDGV.Columns[i].HeaderText))
                        {
                            continue;
                        }
                        li_cls_index += 1;
                        worksheet.Cells[1, li_cls_index] = myDGV.Columns[i].HeaderText;

                    }
                    //寫入數值                    
                    for (int r = 0; r < myDGV.Rows.Count; r++)
                    {
                        li_cls_index = 0;
                        for (int i = 0; i < myDGV.ColumnCount; i++)
                        {
                            if (ls_colum_remove.Contains(myDGV.Columns[i].HeaderText))
                            {
                                continue;
                            }
                            li_cls_index += 1;
                            worksheet.Cells[r + 2, li_cls_index] = myDGV.Rows[r].Cells[i].Value;
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  

                    wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            //workbook.SaveCopyAs(saveFileName);
                            workbook.SaveAs(FileName, FormatNum);
                            //fileSaved = true;  
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;  
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁
                    clsUtility.myMessageBox("匯出EXCEL成功!", "提示信息");
                }
            }
            else
            {
                MessageBox.Show("無要匯出EXCEL之數據!", "提示信息", MessageBoxButtons.OK);
            }
        }

        private static void Set_Number_Focus(DevExpress.XtraEditors.TextEdit objTextEdit)
        {
            if (objTextEdit.Text == "0.00")
            {
                objTextEdit.Select(1, 0);
            }
        }

        private void txtchemical_test_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtchemical_test);
        }

        private void txtphysical_test_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtphysical_test);
        }

        private void txtchemical_test_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mState != "" && e.KeyChar == 13)
            {
                Amount_Calcu();
            }
        }

        private void txtphysical_test_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mState != "" && e.KeyChar == 13)
            {
                Amount_Calcu();
            }
        }

        private void Amount_Calcu()
        {
            float lf_chemical_test = 0.00f;
            float lf_physical_test = 0.00f;
            if (txtchemical_test.Text == "")
            {
                lf_chemical_test = 0;
            }
            else
            {
                lf_chemical_test = float.Parse(txtchemical_test.Text);
            }
            if (txtphysical_test.Text == "")
            {
                lf_physical_test = 0;
            }
            else
            {
                lf_physical_test = float.Parse(txtphysical_test.Text);
            }
            txtamount.Text = (lf_chemical_test + lf_physical_test).ToString();
        }

        private void txtchemical_test_Leave(object sender, EventArgs e)
        {
            if (mState != "" )
            {
                Amount_Calcu();
            }
        }

        private void txtphysical_test_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                Amount_Calcu();
            }
        }

        private void txtSales_group_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void dtPdd1_Leave(object sender, EventArgs e)
        {
            dtPdd2.EditValue = dtPdd1.EditValue;
        }

        private void chkSelectAllPDD_MouseUp(object sender, MouseEventArgs e)
        {
            if (!BTNCONFIRM_PDD.Enabled)
            {
                if (chkSelectAllPDD.Checked)
                {
                    chkSelectAllPDD.Checked = false;
                    return;
                }
            }

            if (mState == "" && dgvFind.Rows.Count > 0)
            {
                //PDD 全選/反選
                if (BTNCONFIRM_PDD.Enabled)
                {
                    if (chkSelectAllPDD.Checked)
                    {
                        for (int i = 0; i < dtFind_Date.Rows.Count; i++)
                        {
                            dtFind_Date.Rows[i]["confirm_pdd"] = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtFind_Date.Rows.Count; i++)
                        {
                            dtFind_Date.Rows[i]["confirm_pdd"] = false;
                        }
                    }
                }
                else
                {
                    if (chkSelectAllPDD.Checked)
                    {
                        chkSelectAllPDD.Checked = false;
                    }
                }
            }
        }

       
        private void chkSelectAllAC_MouseUp(object sender, MouseEventArgs e)
        {           
            if (!BTNCONFIRM_AC.Enabled)
            {
                if (chkSelectAllAC.Checked)
                {
                    chkSelectAllAC.Checked = false;
                    return;
                }
            }

            if (mState == "" && dgvFind.Rows.Count > 0)
            {               
                //AC 全選/反選
                if (BTNCONFIRM_AC.Enabled)
                {
                    if (chkSelectAllAC.Checked)
                    {
                        for (int i = 0; i < dtFind_Date.Rows.Count; i++)
                        {
                            dtFind_Date.Rows[i]["confirm_ac"] = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtFind_Date.Rows.Count; i++)
                        {
                            dtFind_Date.Rows[i]["confirm_ac"] = false;
                        }
                    }
                }                
            }
        }

        /// <summary>
        /// 同一張測試報告有多張發票時復制該測試報告出來更改,只是發票編號,金額不同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultInvoice_Click(object sender, EventArgs e)
        {
            if (mState == "")
            {
                DialogResult result = MessageBox.Show("確認要進行當前操作?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string test_report_no = txtID.Text;
                    if (!string.IsNullOrEmpty(test_report_no))
                    {
                        string ls_sql = string.Format(
                        @"Select A.id,A.report_date,A.brand,A.amount_unit,A.sales_group,A.remark,
                        B.sales_group as sales_group_d,B.mat_id,B.color_id,B.product_type_id,B.cust_color,B.trim_code,B.test_item_id,B.ref_mo,B.expiry_date
                        From dbo.bs_test_invoice_mostly A,dbo.bs_test_invoice_details B
                        Where A.id=B.id and A.invoice_id=B.invoice_id and A.id='{0}' and A.invoice_id='{1}' Order by B.sequence_id", test_report_no, txtinvoice_id.Text);
                        DataTable dt = new DataTable();
                        dt = clsPublicOfCF01.GetDataTable(ls_sql);
                        if (dt.Rows.Count > 0)
                        {
                            AddNew();
                            txtID.Text = test_report_no;
                            Set_Grid_Status(true);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    if (txtSales_group.Text == "")
                                    {
                                        txtSales_group.Text = dt.Rows[i]["sales_group_d"].ToString();
                                    }
                                    txtID.Text = dt.Rows[i]["id"].ToString();
                                    txtbrand.Text = dt.Rows[i]["brand"].ToString();
                                    dtreport_date.EditValue = dt.Rows[i]["report_date"].ToString();
                                    lkeamount_unit.EditValue = dt.Rows[i]["amount_unit"].ToString();
                                    txtremark.Text = dt.Rows[i]["remark"].ToString();
                                }
                                dgvDetails.AddNewRow();//新增
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "invoice_id", txtinvoice_id.Text.Trim());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount).ToString("000"));
                                
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sales_group", dt.Rows[i]["sales_group_d"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mat_id", dt.Rows[i]["mat_id"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "product_type_id", dt.Rows[i]["product_type_id"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "color_id", dt.Rows[i]["color_id"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "trim_code", dt.Rows[i]["trim_code"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "cust_color", dt.Rows[i]["cust_color"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "test_item_id", dt.Rows[i]["test_item_id"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "expiry_date", dt.Rows[i]["expiry_date"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ref_mo", dt.Rows[i]["ref_mo"].ToString());
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_pass", true);
                            }
                            ColumnView view = (ColumnView)dgvDetails;//初始單元格焦點
                            view.FocusedColumn = view.Columns["test_item_id"];
                            view.Focus();                            
                        }
                        else
                        {
                            MessageBox.Show("請首先查找出同一張測試報告編號有多張發票的資料!", "提示信息");
                            txtID.Focus();
                        }
                    }                    
                }
            }
            else
            {
                MessageBox.Show("編輯模式下禁用此功能!","提示信息");
            }
        }

        private void txtinvoice_id_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mState == "EDIT" && txtinvoice_id.Text != "")
            {
                m_invoice_id_old = txtinvoice_id.Text;//修改前的發票編號
                using (frmTestInvoiceEditInv ofrmInvEdit = new frmTestInvoiceEditInv(txtinvoice_id.Text))
                {
                    ofrmInvEdit.m_invoice_id_edit = txtinvoice_id.Text;
                    ofrmInvEdit.ShowDialog();
                    if (ofrmInvEdit.m_invoice_id_edit != "")
                    {
                        if (ofrmInvEdit.m_invoice_id_edit != txtinvoice_id.Text)
                        {
                            txtinvoice_id.Text = ofrmInvEdit.m_invoice_id_edit;
                            for (int i = 0; i < dgvDetails.RowCount; i++)
                            {
                                dgvDetails.SetRowCellValue(i, "invoice_id", txtinvoice_id.Text);
                            }                           
                        }
                        ColumnView view = (ColumnView)dgvDetails;//初始單元格焦點
                        view.FocusedColumn = view.Columns["test_item_id"];
                        view.Focus();
                    }
                    //ofrmInvEdit.Dispose();
                }
            }            
        }
    }
}
