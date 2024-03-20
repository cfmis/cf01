using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmTestExcel : Form
    {
        private clsAppPublic clsAppPublic = new clsAppPublic();
        private clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        private string strSeq_id = "";
        private string test_public_path = "";
        
        private clsUtility.enumOperationType OperationType;       
        public DataTable dtTe = new DataTable();
        private DataTable dtReport_Path_List = new DataTable();
        private string flag_new_copy = "";        

        private List<mdlTestInvoiceData> lstModel = new List<mdlTestInvoiceData>(); 

        public frmTestExcel()
        {
            InitializeComponent();            
            //clsControlInfoHelper formInit = new clsControlInfoHelper(this.Name, this.Controls);
            //formInit.GenerateContorl();
            //控件翻譯
            //clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
            //obj_ctl.Translate();

            //clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name,this.Controls);
            obj.SetToolBar();

            NextControl oNext = new NextControl(this, "1");
            //oNext.EnterToTab();
        }

        private void frmTestExcel_Load(object sender, EventArgs e)
        {            
            DataTable dtSales_Group = clsSales_group.Get_sales_group();
            txtSales_group.Properties.DataSource = dtSales_Group;
            txtSales_group.Properties.ValueMember = "id";
            txtSales_group.Properties.DisplayMember = "cdesc";

            //表格中的原材料
            DataTable dtMat = clsPublicOfCF01.GetDataTable(@"SELECT id,id +' ('+ name+')' as cdesc FROM dbo.bs_test_mat_type");
            DataRow dr0 = dtMat.NewRow(); //插一空行        
            dtMat.Rows.InsertAt(dr0, 0);
            clMat_id.DataSource = dtMat;
            clMat_id.ValueMember = "id";
            clMat_id.DisplayMember = "cdesc";

            //表格中的產品類別            
            DataTable dtProduct_type = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc FROM dbo.bs_test_product_type");
            clPoduct_type_id.DataSource = dtProduct_type;
            clPoduct_type_id.ValueMember = "id";
            clPoduct_type_id.DisplayMember = "cdesc";
            //表格中的測試項目
            DataTable dtTestItem = clsPublicOfCF01.GetDataTable(
            @"SELECT test_item_id as id,test_item_id+'('+test_item_name+')' as cdesc FROM dgerp2.cferp.dbo.cd_qc_test_item order by id");
            clTestitem.DataSource = dtTestItem;
            clTestitem.ValueMember = "id";
            clTestitem.DisplayMember = "cdesc";
            //表格中的顏色類別
            DataTable dtColor = clsPublicOfCF01.GetDataTable(@"SELECT id,id +' ('+ cdesc+')' AS cdesc,edesc FROM dbo.bs_test_color_category");
            clColor_id.DataSource = dtColor;
            clColor_id.ValueMember = "id";
            clColor_id.DisplayMember = "cdesc";
            //表格中的組別
            clSales_group.DataSource = dtSales_Group;
            clSales_group.ValueMember = "id";
            clSales_group.DisplayMember = "cdesc";
            //測試機構
            clsTestProductPlan.SetTestDept(lueTest_dept);
            
            OperationType = clsUtility.enumOperationType.Load;
            ControlState();            
          
            //取用戶據屬組別最后一位組別(即最后一位字母)
            //查找用戶組別所屬的資料
            //string strSql = string.Format("Select RIGHT(rname,1) as sales_group From v_user_sales_group Where uname='{0}'",DBUtility._user_id ); 
            string strSql = string.Format("Select isnull(user_group,'') as user_group from dbo.tb_sy_user Where uname='{0}'", DBUtility._user_id);
            txtGroup.Text = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            if (txtGroup.Text == "W")
            {
                txtGroup.Text = "E";
            }
            
            //string strGroup = txtGroup.Text;
            ////Regex regChina = new Regex("^[^-\xFF]");//是中文
            ////Regex regNum = new Regex("^[0-9]");//數字
            //Regex regLetter = new Regex("^[a-zA-Z]+"); //否为字母组成
            //if (!regLetter.IsMatch(strGroup))
            //{               
            //    txtGroup.Text = "";
            //}
                     
            //設置測試報告文檔存放的起止路徑
            //點擊文本編輯框按鈕時，設置測試報告路徑的初始文件夾位置
            //用戶要設所屬的用戶組別
            test_public_path = clsTestProductPlan.Get_Test_Public_Path();
            //返回最基礎的測試報告路徑前綴，以免路徑顯示太長
            dtReport_Path_List = clsTestProductPlan.Get_Test_Report_Path();

            //btnSearch.PerformClick();//2023/03/24暫停查詢快到期的數據

            //初始化表結構,因取消 btnSearch.PerformClick()會出錯.
            strSql = 
            @"SELECT a.mat_id, a.seq_id, a.color_id, a.finish_name, a.poduct_type_id
				,a.trim_color_code, a.trim_code, a.pattern_id, a.test_item_id, a.test_report_no
				,CONVERT(date,a.expiry_date,120) as [expiry_date], a.remark,a.ref_mo, a.crusr, a.crtim, a.amusr, a.amtim, a.test_report_path 
				,a.mat_id+'('+b.name+')' as mat_cdesc,a.color_id+'('+c.cdesc+')' as color_cdesc
				,a.poduct_type_id+'('+ d.cdesc+')' as prod_type_cdesc,'' as test_item_cdesc
				,a.size,a.cf_color,a.sales_group,a.doc_type,
				CONVERT(date,GETDATE(),120) as valid_date,a.test_report_no as report_no,a.test_dept,a.invoice_id
	        FROM bs_test_excel a
			        LEFT JOIN bs_test_mat_type b ON a.mat_id=b.id
			        LEFT JOIN bs_test_color_category c ON a.color_id=c.id
			        LEFT JOIN bs_test_product_type d ON a.poduct_type_id=d.id
	        WHERE 1=0 ";
            dtTe = clsPublicOfCF01.GetDataTable(strSql);
            bds1.DataSource = dtTe;
            gridControl1.DataSource = bds1;

            InitCombBox();
            //設置控件與bds1對象數據綁定
            Set_Data_Binding();           
            toolTip1.SetToolTip(btnTestItem, "從選取的測試項目中一次性生成多筆測試報告數據!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Add;
            ControlState();
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            //dgvDetails.OptionsBehavior.Editable = false;
            txtInvoice_id.Properties.ReadOnly = true;
            txtInvoice_id.BackColor = Color.White;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (strSeq_id != "")
            {
                OperationType = clsUtility.enumOperationType.Update;
                ControlState();
                SetObjValue.SetEditBackColor(panel1.Controls, true);
                lueMat.Enabled = false;
                txtInvoice_id.Properties.ReadOnly = true;
                txtInvoice_id.BackColor = Color.White;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            return;
            
            #region 舊的保存代碼
            /*
             * 以下為舊的代碼 2019-01-05 取消
            if (lueMat.Text == "")
            {
                MessageBox.Show("原材料不能為空!");
                lueMat.Focus();
                return;
            }

            if (lueTestItem.Text == "")
            {
                MessageBox.Show("測試項目不可為空!");
                lueTestItem.Focus();
                return;
            }

            if (deExpriy.Text == "" && txtTestReportNo.Text != "")
            {
                MessageBox.Show("已有測試報告編號時，有效日期不可爲空!");
                deExpriy.Focus();
                return;
            }

            if (txtSales_group.Text == "")
            {
                MessageBox.Show("組別不可爲空!");
                txtSales_group.Focus();
                return;
            }

            int Result = 0;
            mdlTestExcel objTe = new mdlTestExcel() { 
                mat_id = lueMat.EditValue.ToString() 
            };
            if (strSeq_id == "")
            {
                int MaxSeq_id = clsTestProductPlan.GetMaxSeqForTe(lueMat.EditValue.ToString());
                objTe.seq_id = (MaxSeq_id + 1).ToString("000000");
            }
            else
            {
                objTe.seq_id = strSeq_id;
            }
            objTe.pattern_id = txtPattern_id.Text.Trim();
            objTe.poduct_type_id = lueProductType.EditValue.ToString();
            objTe.test_item_id = lueTestItem.EditValue.ToString();
            objTe.color_id = lueColor.EditValue.ToString();
            if (string.IsNullOrEmpty(deExpriy.Text))
            {
                objTe.expiry_date = "";
            }
            else
            {
                string TempDate = deExpriy.Text;               
                objTe.expiry_date = TempDate.Replace('/', '-');
            }
            objTe.finish_name = txtFinish_name.Text.Trim();
            objTe.trim_color_code = txtTrim_color_code.Text.Trim();//送測編號
            objTe.trim_code = txtTrim_code.Text.Trim();
            objTe.test_report_no = txtTestReportNo.Text.Trim();
            objTe.remark = txtRemark.Text.Trim();
            objTe.ref_mo = txtRef_mo.Text;
            objTe.test_report_path = btnEditTest_report_Path.Text.Trim();//文檔路徑
            objTe.size = txtSize.Text;
            objTe.cf_color = txtCf_color.Text;
            objTe.sales_group = txtSales_group.EditValue.ToString() ;
            objTe.doc_type = txtDoc_type.Text;                      

            switch (OperationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        Result = clsTestProductPlan.AddTestExcel(objTe);
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        Result = clsTestProductPlan.UpdateTestExcel(objTe);
                        objTe.seq_id = "";
                        dgvTestExcel.DataSource = bds1;
                        dgvTestExcel.Refresh();
                    }
                    break;
            }

            if (Result > 0)
            {
                //GetTestExcel(objTe.seq_id, objTe.mat_id);//改為數據綁定后不再需要此行代碼
                OperationType = clsUtility.enumOperationType.Save;
                ControlState();
                SetObjValue.SetEditBackColor(panel1.Controls, false);                
                //當前服務器時間
                string valid_date = clsPublicOfCF01.ExecuteSqlReturnObject("Select convert(varchar(10),getdate(),120)");                
                if (objTe.seq_id != "")
                {
                    //新增時重新綁定數據并設置序號
                    Binding_Edit_Data(dgvTestExcel.CurrentRow.Index, valid_date);
                    dgvTestExcel.Rows[dgvTestExcel.CurrentRow.Index].Cells["colSeq_id"].Value = objTe.seq_id;
                }
                flag_new_copy = "";
                dgvTestExcel.Enabled = true;
                MessageBox.Show("數據保存成功！", "提示信息");
            }
            else
            {
                MessageBox.Show("保存出錯！","提示信息");
            }
            */
            #endregion
        
        }


        #region Save() 新的保存方法
        //2019-01-05取消原來的保存方法 Allen_Leung
        //新的代碼可以新增或修改多筆數據，只需一次保存
        private void Save()
        {
            bool data_valid_flag=true ;
            string rowStatus = "";
            string strnew_report_no, strreport_no;
            bds1.EndEdit();
            dgvDetails.CloseEditor();
            for (Int32 i = 0; i < dgvDetails.RowCount; i++)
            {
                 rowStatus = dgvDetails.GetDataRow(i).RowState.ToString();
                 if (rowStatus == "Added" || rowStatus == "Modified")
                 {
                     if (dgvDetails.GetRowCellValue(i,"mat_id").ToString() == "")
                     {
                         MessageBox.Show("原材料不能為空!");
                         data_valid_flag = false;
                         break;         
                     }
                     if (dgvDetails.GetRowCellValue(i, "test_item_id").ToString() == "")
                     {
                         MessageBox.Show("測試項目不可為空!");
                         data_valid_flag = false;
                         break;     
                     }
                     if (dgvDetails.GetRowCellValue(i, "test_report_no").ToString() != "" && string.IsNullOrEmpty(dgvDetails.GetRowCellValue(i, "expiry_date").ToString()))
                     {
                         MessageBox.Show("因為已有測試報告編號，所以有效日期不可以設置爲空!");
                         data_valid_flag = false;
                         break;     
                     }
                     if (dgvDetails.GetRowCellValue(i, "sales_group").ToString() == "")
                     {
                         MessageBox.Show("組別不可爲空!");
                         data_valid_flag = false;
                         break;     
                     }
                    if (dgvDetails.GetRowCellValue(i, "test_dept").ToString() == "")
                    {
                        MessageBox.Show("公正行(測試機構)不可爲空!");
                        data_valid_flag = false;
                        break;
                    }
                }
            }

            if (!data_valid_flag)
            {
                return;
            }

            //註意DATETIME字段傳遞NULL值的處理                            
            const string sql_i =
            @"INSERT INTO bs_test_excel
            (mat_id,seq_id,color_id,finish_name,poduct_type_id,trim_color_code,trim_code,test_item_id,test_report_no,test_report_path,pattern_id,
            remark, ref_mo,crusr, crtim, size,cf_color,sales_group,doc_type,[expiry_date],test_dept)
            VALUES(@mat_id,@seq_id, @color_id, @finish_name, @poduct_type_id,@trim_color_code, @trim_code, @test_item_id, @test_report_no, @test_report_path,@pattern_id,
            @remark, @ref_mo,@user_id,GETDATE(),@size,@cf_color,@sales_group,@doc_type,CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END,@test_dept)";

            const string sql_u =
            @"UPDATE bs_test_excel SET color_id=@color_id, finish_name=@finish_name, poduct_type_id=@poduct_type_id ,trim_color_code=@trim_color_code,
            trim_code=@trim_code,test_item_id=@test_item_id, test_report_no=@test_report_no,test_report_path=@test_report_path,
            pattern_id=@pattern_id, remark=@remark,ref_mo=@ref_mo, amusr=@user_id, amtim=getdate(),
            size=@size,cf_color=@cf_color,sales_group=@sales_group,doc_type=@doc_type,
            [expiry_date]=CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END,test_dept=@test_dept
            WHERE mat_id=@mat_id AND seq_id=@seq_id";

            string str_date="";
            int li_maxseq_id = 0,li_serial_no = 0;
            bool flag_save = true, flag_addoredit = false;

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString); //connect to dgsql2
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            SqlCommand myCommand = new SqlCommand() { 
                Connection = myCon, 
                Transaction = myTrans 
            };
            try
            {
                for (Int32 i = 0; i < dgvDetails.RowCount; i++)
                {
                    rowStatus = dgvDetails.GetDataRow(i).RowState.ToString();
                    if (rowStatus == "Added" || rowStatus == "Modified")
                    {
                        flag_addoredit = true;                                                   
                        myCommand.Parameters.Clear();
                        if (dgvDetails.GetDataRow(i).RowState.ToString() == "Added")
                        {
                            li_serial_no += 1;//序號加1
                            myCommand.CommandText = sql_i;
                            //新增狀態重新取最大序號
                            if (li_maxseq_id == 0)
                            {
                                li_maxseq_id = clsTestProductPlan.GetMaxSeqForTe(dgvDetails.GetRowCellValue(i, "mat_id").ToString());
                            }
                            strSeq_id = (li_maxseq_id + li_serial_no).ToString("000000");
                            dgvDetails.SetRowCellValue(i, "seq_id", strSeq_id);
                            dgvDetails.SetRowCellValue(i, "report_no", txtTestReportNo.Text);
                        }
                        else
                        {
                            myCommand.CommandText = sql_u;
                            strSeq_id = dgvDetails.GetRowCellValue(i, "seq_id").ToString(); //編輯狀態原序號保持不變                                    
                        }
                        myCommand.Parameters.AddWithValue("@mat_id", dgvDetails.GetRowCellValue(i, "mat_id").ToString());
                        myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                        myCommand.Parameters.AddWithValue("@color_id", dgvDetails.GetRowCellValue(i, "color_id").ToString());
                        myCommand.Parameters.AddWithValue("@finish_name", dgvDetails.GetRowCellValue(i, "finish_name").ToString());
                        myCommand.Parameters.AddWithValue("@poduct_type_id", dgvDetails.GetRowCellValue(i, "poduct_type_id").ToString());
                        myCommand.Parameters.AddWithValue("@trim_color_code", dgvDetails.GetRowCellValue(i, "trim_color_code").ToString());
                        myCommand.Parameters.AddWithValue("@trim_code", dgvDetails.GetRowCellValue(i, "trim_code").ToString());
                        myCommand.Parameters.AddWithValue("@test_item_id", dgvDetails.GetRowCellValue(i, "test_item_id").ToString());
                        myCommand.Parameters.AddWithValue("@test_report_no", dgvDetails.GetRowCellValue(i, "test_report_no").ToString());
                        myCommand.Parameters.AddWithValue("@test_report_path", dgvDetails.GetRowCellValue(i, "test_report_path").ToString());
                        str_date = dgvDetails.GetRowCellValue(i, "expiry_date").ToString();
                        if (string.IsNullOrEmpty(str_date))
                            str_date = "";
                        else
                        {
                            if (str_date != "0001-01-01")
                                str_date = clsAppPublic.Return_String_Date(str_date);
                            else
                                str_date = "";
                        }
                        myCommand.Parameters.AddWithValue("@expiry_date", str_date);
                        myCommand.Parameters.AddWithValue("@pattern_id", dgvDetails.GetRowCellValue(i, "pattern_id").ToString());
                        myCommand.Parameters.AddWithValue("@remark", dgvDetails.GetRowCellValue(i, "remark").ToString());
                        myCommand.Parameters.AddWithValue("@ref_mo", dgvDetails.GetRowCellValue(i, "ref_mo").ToString());
                        myCommand.Parameters.AddWithValue("@size", dgvDetails.GetRowCellValue(i, "size").ToString());
                        myCommand.Parameters.AddWithValue("@cf_color", dgvDetails.GetRowCellValue(i, "cf_color").ToString());
                        myCommand.Parameters.AddWithValue("@sales_group", dgvDetails.GetRowCellValue(i, "sales_group").ToString());
                        myCommand.Parameters.AddWithValue("@doc_type", dgvDetails.GetRowCellValue(i, "doc_type").ToString());
                        myCommand.Parameters.AddWithValue("@test_dept", dgvDetails.GetRowCellValue(i, "test_dept").ToString());
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();

                        //如更改測試報告編號則同步更新發票中的對應的測試報告（已存在的）
                        if (rowStatus == "Modified")
                        {
                            strnew_report_no = dgvDetails.GetRowCellValue(i, "test_report_no").ToString();
                            strreport_no = dgvDetails.GetRowCellValue(i, "report_no").ToString();
                            if (!string.IsNullOrEmpty(strreport_no) && !string.IsNullOrEmpty(strnew_report_no))
                            {
                                if (strnew_report_no != strreport_no)
                                {
                                    const string strsql_invoice_h = @"Update dbo.bs_test_invoice_mostly set id=@new_report_no,update_by=@user_id,update_date=getdate() Where id=@report_no";
                                    const string strsql_invoice_d = @"Update dbo.bs_test_invoice_details set id=@new_report_no Where id=@report_no";
                                    myCommand.Parameters.Clear();
                                    myCommand.CommandText = strsql_invoice_h;
                                    myCommand.Parameters.AddWithValue("@new_report_no", strnew_report_no);
                                    myCommand.Parameters.AddWithValue("@report_no", strreport_no);
                                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                    myCommand.ExecuteNonQuery();
                                    myCommand.Parameters.Clear();
                                    myCommand.CommandText = strsql_invoice_d;
                                    myCommand.Parameters.AddWithValue("@new_report_no", strnew_report_no);
                                    myCommand.Parameters.AddWithValue("@report_no", strreport_no);
                                    myCommand.ExecuteNonQuery();
                                }
                                dgvDetails.SetRowCellValue(i, "report_no", strnew_report_no); //編輻狀態下也要更新此臨時值
                            }
                        }
                    }
                }
                //有新增或修改才提交事務
                if (flag_addoredit)
                {
                    myTrans.Commit(); //數據提交
                    flag_save = true;
                }                
            }
            catch (Exception E)
            {
                myTrans.Rollback(); //數據回滾
                flag_save = false;
                throw new Exception(E.Message);
            }
            finally
            {
                myCon.Close();
                myCommand.Dispose();
                myTrans.Dispose();
            }

            if (flag_save)
            {
                dtTe.AcceptChanges();
                OperationType = clsUtility.enumOperationType.Save;
                ControlState();
                SetObjValue.SetEditBackColor(panel1.Controls, false);
                flag_new_copy = "";
                //dgvTestExcel.Enabled = true;
                clsUtility.myMessageBox("數據保存成功！", "提示信息");
            }
            else
            {
                MessageBox.Show("保存出錯！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                string ls_report_no = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "test_report_no").ToString();
                if (!string.IsNullOrEmpty(ls_report_no))
                {
                    if (clsTestProductPlan.Is_Exists_Invoice(ls_report_no) == 1)
                    {
                        MessageBox.Show(String.Format("已存在測試報告:[{0}] 的發票!不可以刪除!", ls_report_no), "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                
                if (MessageBox.Show("確認要刪除該條數據嗎？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Result = clsTestProductPlan.DeleteTestExcel(dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle,"seq_id").ToString(), lueMat.EditValue.ToString());
                    if (Result > 0)
                    {
                        //GetTestExcel("", "");
                        bds1.RemoveAt(dgvDetails.FocusedRowHandle);
                        gridControl1.DataSource = bds1;
                        //dgvTestExcel.Rows.RemoveAt(dgvTestExcel.CurrentRow.Index);
                        //OperationType = clsUtility.enumOperationType.Delete;
                        //ControlState();
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗！");
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可刪除的數據。");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmTestExcel_Search frmSts = new frmTestExcel_Search();
            if (frmSts.ShowDialog() == DialogResult.Yes)
            {
                dtTe = frmSts.dtTe;
                dtTe.AcceptChanges();//恢復正常的Rowstate狀態,否則按編輯按鈕時表格背景色會亂
                bds1.DataSource = dtTe;               
                gridControl1.DataSource = bds1;  
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {                
                //ExpToExcel xls = new ExpToExcel();
                //DataGridView dgv = new DataGridView() { DataSource = dtTe }; 
                //xls.ExportExcel(dgv);
                SaveFileDialog saveFileDialog = new SaveFileDialog() {
                    Title = "Export To Excel", 
                    Filter = "Excel files (*.xls)|*.xls" 
                };
                DialogResult dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    gridControl1.ExportToXls(saveFileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("匯出EXCEL成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("沒有可匯出Excel的數據。");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Cancel;
            ControlState();
            SetObjValue.SetEditBackColor(panel1.Controls, false);           
            flag_new_copy = "";
            dtTe.RejectChanges();//取消數據更改
            bds1.CancelEdit();//取消數據綁定
        }

        //private void GetTestExcel(string pSeq_id, string pMat_id)
        //{
        //    dtTe = clsTestProductPlan.GetTestExcelById(pSeq_id, pMat_id);
        //    //dgvTestExcel.DataSource = dtTe;
        //    //dgvTestExcel.Refresh();
        //}

        /// <summary>
        /// 初始化材料、產品類型、測試項目、顏色
        /// </summary>
        private void InitCombBox()
        {
            clsTestProductPlan.SetMatType(lueMat);
            clsTestProductPlan.SetProductType(lueProductType);
            clsTestProductPlan.SetTest_item(lueTestItem);
            clsTestProductPlan.SetColorType(lueColor);
        }

        #region ControlState() 設置控件狀態
        /// <summary>
        /// 控件狀態控制
        /// </summary>
        private void ControlState()
        {
            switch (OperationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnFind.Enabled = false;
                        btnExcel.Enabled = false;
                        BTNNEWCOPY.Enabled = false;
                        BTNINVOICE.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        pnlSearch.Enabled = false;
                        btnTestItem.Enabled = true;
                        btnGetmoinfo.Enabled = true;

                        lueMat.Enabled = true;
                        lueProductType.Enabled = true;
                        lueTestItem.Enabled = true;
                        lueColor.Enabled = true;
                        deExpriy.Enabled = true;
                        txtFinish_name.Enabled = true;
                        txtTrim_color_code.Enabled = true;
                        txtTrim_code.Enabled = true;
                        btnEditTest_report_Path.Properties.ReadOnly = false;
                        txtRemark.Enabled = true;
                        txtPattern_id.Enabled = true;
                        txtRef_mo.Enabled = true;
                        txtTestReportNo.Enabled = true;

                        dgvDetails.OptionsBehavior.Editable = true;	//表格可以編輯                       
                        bds1.AddNew();                        

                        txtTestReportNo.Text = "";
                        deExpriy.EditValue = "";
                        txtFinish_name.Text = "";
                        txtTrim_color_code.Text = "";
                        txtTrim_code.Text = "";
                        btnEditTest_report_Path.Text = "";
                        txtRemark.Text = "";
                        txtPattern_id.Text = "";
                        txtRef_mo.Text = "";
                        lueMat.EditValue = "";
                        lueProductType.EditValue = "";
                        lueTestItem.EditValue = "";
                        lueColor.EditValue = "";

                        txtSize.Text = "";
                        txtCf_color.Text = "";
                        txtSales_group.EditValue = "";
                        txtDoc_type.Text = "";
                        txtCrusr.Text = "";
                        txtCrtim.Text = "";
                        txtAmusr.Text = "";
                        txtAmtim.Text = "";
                        strSeq_id = "";                        
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnFind.Enabled = false;
                        btnExcel.Enabled = false;
                        BTNNEWCOPY.Enabled = false;
                        BTNINVOICE.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        pnlSearch.Enabled = false;
                        btnTestItem.Enabled = false;
                        btnGetmoinfo.Enabled = true;
                        dgvDetails.OptionsBehavior.Editable = true;

                        lueMat.Enabled = false;
                        lueProductType.Enabled = true;
                        lueTestItem.Enabled = true;
                        lueColor.Enabled = true;
                        deExpriy.Enabled = true;
                        txtFinish_name.Enabled = true;
                        txtTrim_color_code.Enabled = true;
                        txtTrim_code.Enabled = true;
                        btnEditTest_report_Path.Properties.ReadOnly = false;
                        txtRemark.Enabled = true;
                        txtPattern_id.Enabled = true;
                        txtRef_mo.Enabled = true;
                        txtTestReportNo.Enabled = true;
                    }
                    break;
                case clsUtility.enumOperationType.Delete:
                    {
                        deExpriy.EditValue = DateTime.Now;
                        txtFinish_name.Text = "";
                        txtTrim_color_code.Text = "";
                        txtTrim_code.Text = "";
                        btnEditTest_report_Path.Text = "";
                        txtRemark.Text = "";
                        txtPattern_id.Text = "";
                        txtRef_mo.Text = "";
                        lueMat.EditValue = "";
                        lueProductType.EditValue = "";
                        lueTestItem.EditValue = "";
                        lueColor.EditValue = "";
                        txtTestReportNo.Text = "";
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {                       
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnFind.Enabled = true;
                        btnExcel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        pnlSearch.Enabled = true;
                        BTNNEWCOPY.Enabled = true;
                        btnTestItem.Enabled = false;
                        btnGetmoinfo.Enabled = false;
                        BTNINVOICE.Enabled = true;
                        dgvDetails.OptionsBehavior.Editable = false;

                        lueMat.Enabled = false;
                        lueProductType.Enabled = false;
                        lueTestItem.Enabled = false;
                        lueColor.Enabled = false;
                        deExpriy.Enabled = false;
                        txtFinish_name.Enabled = false;
                        txtTrim_color_code.Enabled = false;
                        txtTrim_code.Enabled = false;
                        btnEditTest_report_Path.Properties.ReadOnly = true;
                        txtRemark.Enabled = false;
                        txtPattern_id.Enabled = false;
                        txtRef_mo.Enabled = false;
                        txtTestReportNo.Enabled = false;


                        if (flag_new_copy == "")//復制新增時不清空
                        {
                            txtTestReportNo.Text = "";
                            deExpriy.EditValue = "";
                            txtFinish_name.Text = "";
                            txtTrim_color_code.Text = "";
                            txtTrim_code.Text = "";
                            btnEditTest_report_Path.Text = "";
                            txtRemark.Text = "";
                            txtPattern_id.Text = "";
                            txtRef_mo.Text = "";
                            lueMat.EditValue = "";
                            lueProductType.EditValue = "";
                            lueTestItem.EditValue = "";
                            lueColor.EditValue = "";

                            txtSize.Text = "";
                            txtCf_color.Text = "";
                            txtSales_group.EditValue = "";
                            txtDoc_type.Text = "";
                            txtCrusr.Text = "";
                            txtCrtim.Text = "";
                            txtAmusr.Text = "";
                            txtAmtim.Text = "";
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnFind.Enabled = true;
                        btnExcel.Enabled = true;
                        BTNNEWCOPY.Enabled = true;
                        BTNINVOICE.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        pnlSearch.Enabled = true;
                        btnTestItem.Enabled = false;
                        btnGetmoinfo.Enabled = false;

                        dgvDetails.OptionsBehavior.Editable = false;	//表格禁止編輯  
                        lueMat.Enabled = false;
                        lueProductType.Enabled = false;
                        lueTestItem.Enabled = false;
                        lueColor.Enabled = false;
                        deExpriy.Enabled = false;
                        txtFinish_name.Enabled = false;
                        txtTrim_color_code.Enabled = false;
                        txtTrim_code.Enabled = false;
                        btnEditTest_report_Path.Properties.ReadOnly = true;
                        txtRemark.Enabled = false;
                        txtPattern_id.Enabled = false;
                        txtRef_mo.Enabled = false;
                        txtTestReportNo.Enabled = false;

                        dgvDetails.OptionsBehavior.Editable = false;
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        //btnNew.Enabled = true;
                        //btnEdit.Enabled = true;
                        //btnDelete.Enabled = true;
                        //btnFind.Enabled = true;
                        //btnExcel.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        lueMat.Enabled = false;
                        lueProductType.Enabled = false;
                        lueTestItem.Enabled = false;
                        lueColor.Enabled = false;
                        deExpriy.Enabled = false;
                        txtFinish_name.Enabled = false;
                        txtTrim_color_code.Enabled = false;
                        txtTrim_code.Enabled = false;
                        btnEditTest_report_Path.Properties.ReadOnly = true;
                        txtRemark.Enabled = false;
                        txtPattern_id.Enabled = false;
                        txtRef_mo.Enabled = false;
                        txtTestReportNo.Enabled = false;

                        //dgvTestExcel.AutoGenerateColumns = false;
                    }
                    break;
                default:
                    break;
            }

            clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
        }
        #endregion

        private void btnEditTest_report_Path_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {                
                OpenFileDialog openFile = new OpenFileDialog() { 
                    Filter = "Files Path|*.msg;*.PDF", 
                    /*openFile.Filter = "PDF Files |*.PDF";*/
                    RestoreDirectory = true, 
                    Title = "鍊接的測試報告相關文檔", 
                    InitialDirectory = test_public_path 
                    /*初始測試報告路徑*/ 
                };
                openFile.ShowDialog();
                string strFile = openFile.FileName;
                if (strFile != "")
                {
                    string strReport_path = GetConString(strFile, test_public_path);
                    btnEditTest_report_Path.Text = strReport_path;
                }
            }
        }

        private string GetConString(string _all_path, string _public_path)
        {
            string str_result = "";
            int lenth_all = _all_path.Length;
            int lenth_public = _public_path.Length;
            str_result = _all_path.Substring(lenth_public, lenth_all - lenth_public);
            return str_result;
        }

        private void btnEditTest_report_Path_Properties_DoubleClick(object sender, EventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {
                return;
            }
            //非編輯狀態下打開PDF檔
            string strFile = btnEditTest_report_Path.Text;
            if (!string.IsNullOrEmpty(strFile))
            {
                clsTestProductPlan.Open_Test_Report(strFile, dtReport_Path_List,"OPEN");
                //strFile = test_public_path + strFile.Trim();
                //clsTestProductPlan.Open_test_pdf(strFile);               
            }
        }     

        private void txtPattern_id_Leave(object sender, EventArgs e)
        {
            //檢查7位ArtCode的有效性
            string strArtCode = txtPattern_id.Text;
            if (string.IsNullOrEmpty(strArtCode))
                return;

            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {
                string strSql = String.Format(@"SELECT '1' FROM dbo.cd_pattern with(nolock) WHERE within_code='0000' and id='{0}'", strArtCode);
                try
                {
                    DataTable dt = new DataTable();
                    dt = clsPublicOfGEO.GetDataTable(strSql);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("圖樣編號不正確,請返回檢查!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPattern_id.Focus();
                        txtPattern_id.SelectAll();
                    }
                    dt.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtRef_mo_Leave(object sender, EventArgs e)
        {
            //檢查頁數的有效性
            string strRef_mo = txtRef_mo.Text;
            if (string.IsNullOrEmpty(strRef_mo))
                return;

            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {
                string strSql = string.Format(@"SELECT '1' FROM dbo.so_order_manage A with(nolock),dbo.so_order_details B with(nolock)                
                                WHERE A.within_code=B.within_code AND A.id=B.id AND A.within_code='0000' AND B.mo_id='{0}' AND  A.state not in ('2') ", strRef_mo);
                try
                {
                    DataTable dt = new DataTable();
                    dt = clsPublicOfGEO.GetDataTable(strSql);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("頁數不正確,請返回檢查!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRef_mo.Focus();
                        txtRef_mo.SelectAll();
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEditTest_report_Path_Leave(object sender, EventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {
                string strPath = btnEditTest_report_Path.Text;
                if (!string.IsNullOrEmpty(strPath))
                {
                    if (strPath.Length < 10)
                    {
                        MessageBox.Show("測試報告編號長度不可以小于10位英文字符長度,請返回檢查!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnEditTest_report_Path.Focus();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int months = Convert.ToInt16(numUpDown1.Value);
            if (months > 0)
            {               
                dtTe = clsTestProductPlan.Get_test_expriy(months, txtGroup.Text);
                bds1.DataSource = dtTe;
                gridControl1.DataSource = bds1;
            }
            else
            {
                MessageBox.Show("查詢月數不可是0.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numUpDown1.Focus();
            }
        }

        private void txtSales_group_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
        }

        private void lueMat_Click(object sender, EventArgs e)
        {
            lueMat.SelectAll();
        }

        private void lueProductType_Click(object sender, EventArgs e)
        {
            lueProductType.SelectAll();
        }

        private void lueTestItem_Click(object sender, EventArgs e)
        {
            lueTestItem.SelectAll();
        }

        private void lueColor_Click(object sender, EventArgs e)
        {
            lueColor.SelectAll();
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                strSeq_id = "";
                flag_new_copy = "BTNNEWCOPY";//點需復制新增的標識                             
                Int32 cur_row = dgvDetails.FocusedRowHandle;
                SetObjValue.SetEditBackColor(panel1.Controls, true);
                OperationType = clsUtility.enumOperationType.Add;
                ControlState();
                Set_head(cur_row);
                SetFocuse(dgvDetails, dgvDetails.RowCount - 2, "seq_id");//定位到新增行的前一行并定位焦點單元格
                SetFocuse(dgvDetails, dgvDetails.RowCount - 1, "seq_id"); //重定位到新增行并定位焦點單元格                
                //Binding_Edit_Data(cur_row, str_valid_date);
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!","系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //解決保存后表沒有顯示最新的數據問題
        //正常的Binding控件不需此特殊方法進行處理
        private void Binding_Edit_Data(Int32 cur_row, string valid_date)
        {
            dgvDetails.SetRowCellValue(cur_row,mat_id,lueMat.EditValue);
            dgvDetails.SetRowCellValue(cur_row, "color_id", lueColor.EditValue);
            dgvDetails.SetRowCellValue(cur_row, "finish_name", txtFinish_name.Text);
            dgvDetails.SetRowCellValue(cur_row, "poduct_type_id", lueProductType.EditValue);
            dgvDetails.SetRowCellValue(cur_row, "pattern_id", txtPattern_id.Text);
            dgvDetails.SetRowCellValue(cur_row, "trim_color_code", txtTrim_color_code.Text);
            dgvDetails.SetRowCellValue(cur_row, "trim_code", txtTrim_code.Text);
            dgvDetails.SetRowCellValue(cur_row, "test_item_id", lueTestItem.EditValue);
            dgvDetails.SetRowCellValue(cur_row, "test_report_no",txtTestReportNo.Text);
            dgvDetails.SetRowCellValue(cur_row, "testRepostnopath", btnEditTest_report_Path.Text);
            dgvDetails.SetRowCellValue(cur_row, "expiry_date", deExpriy.Text);
            dgvDetails.SetRowCellValue(cur_row, "ref_mo", txtRef_mo.Text);
            dgvDetails.SetRowCellValue(cur_row, "remark", txtRemark.Text);
            dgvDetails.SetRowCellValue(cur_row, "size", txtSize.Text);
            dgvDetails.SetRowCellValue(cur_row, "cf_color", txtCf_color.Text);
            dgvDetails.SetRowCellValue(cur_row, "sales_group", txtSales_group.EditValue);
            dgvDetails.SetRowCellValue(cur_row, "doc_type", txtDoc_type.Text);
            dgvDetails.SetRowCellValue(cur_row, "valid_date", valid_date);
            dgvDetails.SetRowCellValue(cur_row, "test_dept", lueTest_dept.EditValue);
        }

        private void Set_head(int  pRow)
        {
            //復制新增用到此方法
            lueMat.EditValue = dtTe.Rows[pRow]["mat_id"].ToString();
            lueProductType.EditValue = dtTe.Rows[pRow]["poduct_type_id"].ToString();
            lueTestItem.EditValue = dtTe.Rows[pRow]["test_item_id"].ToString();
            lueColor.EditValue = dtTe.Rows[pRow]["color_id"].ToString();
            txtPattern_id.Text = dtTe.Rows[pRow]["pattern_id"].ToString();
            txtSize.Text = dtTe.Rows[pRow]["size"].ToString();
            txtSales_group.EditValue = dtTe.Rows[pRow]["sales_group"].ToString();
            txtTrim_code.Text = dtTe.Rows[pRow]["trim_code"].ToString();
            txtRef_mo.Text = dtTe.Rows[pRow]["ref_mo"].ToString();
            txtTestReportNo.Text = dtTe.Rows[pRow]["test_report_no"].ToString();
            btnEditTest_report_Path.Text = dtTe.Rows[pRow]["test_report_Path"].ToString();
            txtRemark.Text = dtTe.Rows[pRow]["remark"].ToString();
            txtCf_color.Text = dtTe.Rows[pRow]["cf_color"].ToString();
            txtDoc_type.Text = dtTe.Rows[pRow]["doc_type"].ToString();
            txtFinish_name.Text = dtTe.Rows[pRow]["finish_name"].ToString();
            txtTrim_color_code.Text = dtTe.Rows[pRow]["trim_color_code"].ToString();
            lueTest_dept.EditValue = dtTe.Rows[pRow]["test_dept"].ToString();
            string strDat = dtTe.Rows[pRow]["expiry_date"].ToString();
            if (!string.IsNullOrEmpty(strDat))
            {                
                strDat = Convert.ToDateTime(strDat).ToString("yyyy-MM-dd");
                if (strDat == "0001-01-01")
                {
                    strDat = "";
                }
            }
            else
            {
                strDat = "";
            }
            deExpriy.EditValue = strDat;
            txtCrusr.Text = DBUtility._user_id;// dtTe.Rows[pRow]["crusr"].ToString();
            txtCrtim.Text = dtTe.Rows[pRow]["crtim"].ToString();
            txtAmusr.Text = dtTe.Rows[pRow]["amusr"].ToString();
            txtAmtim.Text = dtTe.Rows[pRow]["amtim"].ToString();
            txtInvoice_id.Text = dtTe.Rows[pRow]["invoice_id"].ToString();
        }

        private void SetButtonSatus(bool _flag)
        {
            btnNew.Enabled = _flag;
            btnEdit.Enabled = _flag;           
            btnDelete.Enabled = _flag;
            btnFind.Enabled = _flag;
            btnExcel.Enabled = _flag;
            BTNNEWCOPY.Enabled = _flag;           
            btnSave.Enabled = !_flag;
            btnCancel.Enabled = !_flag;           
            
            clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
        }

//        //雙擊打開測試報告
//        private void dgvTestExcel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
//            {
//                return;
//            }
//            if (dgvDetails.RowCount == 0)
//            {
//                return;
//            }
//            //if (dgvTestExcel.Columns[e.ColumnIndex].Name == "colTestRepostNoPath")
//            //{                 
//            //    string strFile = dgvTestExcel.Rows[e.RowIndex].Cells["colTestRepostNoPath"].Value.ToString();
//            //    //打開PDF檔               
//            //    if (!string.IsNullOrEmpty(strFile))
//            //    {
//            //        clsTestProductPlan.Open_Test_Report(strFile, dtReport_Path_List);
//            //        //strFile = test_public_path + strFile.Trim();
//            //        //clsTestProductPlan.Open_test_pdf(strFile);
//            //    }                
//            //}

//            //打開發票界面            
//            string test_report_no = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle,"test_report_no").ToString(); 
//            if (!string.IsNullOrEmpty(test_report_no))
//            {
//                string strsql = string.Format(
//                @"select test_report_no,sales_group,mat_id,color_id,poduct_type_id as product_type_id,finish_name as cust_color,trim_code,test_item_id,[expiry_date],ref_mo 
//                from bs_test_excel where test_report_no ='{0}'", test_report_no);
//                DataTable dt = new DataTable();
//                dt = clsPublicOfCF01.GetDataTable(strsql);
//                lstModel.Clear();
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    mdlTestInvoiceData oMdl = new mdlTestInvoiceData()
//                    {
//                        test_report_no = dt.Rows[i]["test_report_no"].ToString(),
//                        sales_group = dt.Rows[i]["sales_group"].ToString(),
//                        mat_id = dt.Rows[i]["mat_id"].ToString(),
//                        color_id = dt.Rows[i]["color_id"].ToString(),
//                        product_type_id = dt.Rows[i]["product_type_id"].ToString(),
//                        cust_color = dt.Rows[i]["cust_color"].ToString(),
//                        trim_code = dt.Rows[i]["trim_code"].ToString(),
//                        test_item_id = dt.Rows[i]["test_item_id"].ToString(),
//                        expiry_date = clsAppPublic.Return_String_Date(dt.Rows[i]["expiry_date"].ToString()),
//                        ref_mo = dt.Rows[i]["ref_mo"].ToString()
//                    };
//                    lstModel.Add(oMdl);
//                }
//                if (lstModel.Count > 0)
//                {
//                    using (frmTestInvoice ofrmInv = new frmTestInvoice())
//                    {
//                        ofrmInv.lsModel = lstModel;
//                        ofrmInv.ShowDialog();
//                    }
//                }
//            }
            
//        }

        private void Set_Data_Binding()
        {
            //對象數據綁定
            lueMat.DataBindings.Add("EditValue", bds1, "mat_id");
            lueProductType.DataBindings.Add("EditValue", bds1, "poduct_type_id");
            lueTestItem.DataBindings.Add("EditValue", bds1, "test_item_id");
            lueColor.DataBindings.Add("EditValue", bds1, "color_id");
            txtPattern_id.DataBindings.Add("Text", bds1, "pattern_id");
            txtSize.DataBindings.Add("Text", bds1, "size");
            txtSales_group.DataBindings.Add("EditValue", bds1, "sales_group");
            txtTrim_code.DataBindings.Add("Text", bds1, "trim_code");
            txtFinish_name.DataBindings.Add("Text", bds1, "finish_name");
            txtTrim_color_code.DataBindings.Add("Text", bds1, "trim_color_code");
            txtTestReportNo.DataBindings.Add("Text", bds1, "test_report_no");
            deExpriy.DataBindings.Add("EditValue", bds1, "expiry_date");//
            btnEditTest_report_Path.DataBindings.Add("Text", bds1, "test_report_path");//            
            txtCf_color.DataBindings.Add("Text", bds1, "cf_color");
            txtDoc_type.DataBindings.Add("Text", bds1, "doc_type");
            lueTest_dept.DataBindings.Add("EditValue", bds1, "test_dept");
            txtRef_mo.DataBindings.Add("Text", bds1, "ref_mo");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtCrusr.DataBindings.Add("Text", bds1, "crusr");
            txtCrtim.DataBindings.Add("Text", bds1, "crtim");
            txtAmusr.DataBindings.Add("Text", bds1, "amusr");
            txtAmtim.DataBindings.Add("Text", bds1, "amtim");
            txtInvoice_id.DataBindings.Add("Text", bds1, "invoice_id");
        }   

        private void frmTestExcel_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAppPublic = null;
            clsPublicOfGEO = null;
            dtTe.Dispose();
            dtReport_Path_List.Dispose();
            lstModel = null;
        }

        private void txtPattern_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtTrim_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtRef_mo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtTestReportNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtFinish_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtTrim_color_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {            
            Set_focus(e);
        }

        private void txtCf_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private void txtDoc_type_KeyPress(object sender, KeyPressEventArgs e)
        {
            Set_focus(e);
        }

        private static void Set_focus( KeyPressEventArgs e)
        {            
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        //從選擇的測試項目中生成多筆數據
        private void btnTestItem_Click(object sender, EventArgs e)
        {
            if (OperationType != clsUtility.enumOperationType.Add)
            {
                MessageBox.Show("新增模式下方可使用此功能！", "提示信息");
                return;
            }
            if (dgvDetails.RowCount >= 2)
            {               
                //定位到新增行的前一條記錄，并定位焦點單元格，否則更新異常
                SetFocuse(dgvDetails, dgvDetails.RowCount - 2, "seq_id");//定位焦點單元格
            }            
            //記錄新增的行號
            Int32 new_row = dgvDetails.RowCount - 1;            

            SetFocuse(dgvDetails, new_row, "seq_id");//重新定位到新增的行，并使單元格獲得焦點

            if (lueMat.Text == "")
            {
                MessageBox.Show("原材料必須先輸入！", "提示信息");
                lueMat.Focus();
                return;
            }
            if (lueProductType.Text == "")
            {
                MessageBox.Show("產品類型必須先輸入！", "提示信息");
                lueProductType.Focus();
                return;
            }
            if (lueColor.Text == "")
            {
                MessageBox.Show("顏色類別必須先輸入！", "提示信息");
                lueColor.Focus();
                return;
            }
            if (txtSales_group.Text == "")
            {
                MessageBox.Show("組別必須先輸入！", "提示信息");
                txtSales_group.Focus();
                return;
            }
            if (txtTrim_code.Text == "")
            {
                MessageBox.Show("客產品編號必須先輸入！", "提示信息");
                txtTrim_code.Focus();
                return;
            }
            if (txtFinish_name.Text == "")
            {
                MessageBox.Show("客顏色編號必須先輸入！", "提示信息");
                txtFinish_name.Focus();
                return;
            }
            if (txtRef_mo.Text == "")
            {
                MessageBox.Show("參考頁數必須先輸入！", "提示信息");
                txtRef_mo.Focus();
                return;
            }
            if (txtTrim_color_code.Text == "")
            {
                MessageBox.Show("送測編號必須先輸入！", "提示信息");
                txtTrim_color_code.Focus();
                return;
            }

            //循環加入多條新測試項目                           
            using (frmTestExcelTestItem frmTest = new frmTestExcelTestItem())
            {
                frmTest.ShowDialog();
                if (frmTest.mdlTest.Count > 0)
                {
                    int temp_last_index_no = dgvDetails.RowCount - 2;//記錄新增前最后一行記錄的行號
                    //記錄公共錄入的部分
                    mdlTestExcel objMdl = new mdlTestExcel();
                    objMdl.mat_id = lueMat.EditValue.ToString();
                    objMdl.pattern_id = txtPattern_id.Text.Trim();
                    objMdl.poduct_type_id = lueProductType.EditValue.ToString();
                    objMdl.test_item_id = lueTestItem.EditValue.ToString();
                    objMdl.color_id = lueColor.EditValue.ToString();
                    if (string.IsNullOrEmpty(deExpriy.Text))
                    {
                        objMdl.expiry_date = "";
                    }
                    else
                    {
                        string TempDate = deExpriy.Text;
                        objMdl.expiry_date = TempDate.Replace('/', '-');
                    }
                    objMdl.finish_name = txtFinish_name.Text.Trim();//客人顏色編號
                    objMdl.trim_color_code = txtTrim_color_code.Text.Trim();//送測編號
                    objMdl.trim_code = txtTrim_code.Text.Trim();
                    objMdl.test_report_no = txtTestReportNo.Text.Trim();
                    objMdl.remark = txtRemark.Text.Trim();
                    objMdl.ref_mo = txtRef_mo.Text;
                    objMdl.test_report_path = btnEditTest_report_Path.Text.Trim();//文檔路徑
                    objMdl.size = txtSize.Text;
                    objMdl.cf_color = txtCf_color.Text;
                    objMdl.sales_group = txtSales_group.EditValue.ToString();
                    objMdl.doc_type = txtDoc_type.Text;
                    objMdl.test_dept = lueTest_dept.EditValue.ToString();
                    
                    int i = 0;
                    Int32 cur_row_index = 0;
                    foreach (mdlTestItem cur_row_testitem in frmTest.mdlTest)
                    {
                        i += 1;
                        objMdl.test_item_id = cur_row_testitem.id;
                        if (i == 1)
                        {
                            cur_row_index = new_row;
                        }
                        else
                        {
                            bds1.AddNew();
                            cur_row_index = dgvDetails.FocusedRowHandle;                                
                        }
                        Add_Select_TestIitem(cur_row_index, objMdl);
                    }
                    dgvDetails.CloseEditor();
                    if (temp_last_index_no >= 0)
                    {
                        SetFocuse(dgvDetails, temp_last_index_no, "seq_id"); //重定位記錄新增前最后一行記錄的行號之上，使新添加進來的記錄有效
                    }
                    SetFocuse(dgvDetails, new_row, "seq_id");//重定位到第一筆新增行                    
                }
            }
        }

      private void Add_Select_TestIitem(int cur_row, mdlTestExcel objMd)
      {
          dgvDetails.SetRowCellValue(cur_row, "mat_id", objMd.mat_id);
          //dgvDetails.SetRowCellValue(cur_row_index, "seq_id", objMdl.seq_id);
          dgvDetails.SetRowCellValue(cur_row, "color_id", objMd.color_id);
          dgvDetails.SetRowCellValue(cur_row, "finish_name", objMd.finish_name);
          dgvDetails.SetRowCellValue(cur_row, "poduct_type_id", objMd.poduct_type_id);
          dgvDetails.SetRowCellValue(cur_row, "trim_color_code", objMd.trim_color_code);
          dgvDetails.SetRowCellValue(cur_row, "trim_code", objMd.trim_code);
          dgvDetails.SetRowCellValue(cur_row, "pattern_id", objMd.pattern_id);
          dgvDetails.SetRowCellValue(cur_row, "test_item_id", objMd.test_item_id);          
          dgvDetails.SetRowCellValue(cur_row, "test_report_no", objMd.test_report_no);
          if (string.IsNullOrEmpty(objMd.expiry_date))
              dgvDetails.SetRowCellValue(cur_row, "expiry_date", DBNull.Value);
          else
              dgvDetails.SetRowCellValue(cur_row, "expiry_date", objMd.expiry_date);
          dgvDetails.SetRowCellValue(cur_row, "remark", objMd.remark);
          dgvDetails.SetRowCellValue(cur_row, "ref_mo", objMd.ref_mo);
          dgvDetails.SetRowCellValue(cur_row, "test_report_path", objMd.test_report_path);
          dgvDetails.SetRowCellValue(cur_row, "size", objMd.size);
          dgvDetails.SetRowCellValue(cur_row, "cf_color", objMd.cf_color);
          dgvDetails.SetRowCellValue(cur_row, "sales_group", objMd.sales_group);
          dgvDetails.SetRowCellValue(cur_row, "doc_type", objMd.doc_type);
          dgvDetails.SetRowCellValue(cur_row, "crusr", DBUtility._user_id);
          dgvDetails.SetRowCellValue(cur_row, "crtim", DateTime.Now.Date.ToShortDateString());
          dgvDetails.SetRowCellValue(cur_row, "valid_date", DateTime.Now.Date.ToString("yyyy-MM-dd"));//.ToShortDateString());
          dgvDetails.SetRowCellValue(cur_row, "test_dept", objMd.test_dept);
        }

        private void dgvDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {
                return;
            }
            if (dgvDetails.RowCount > 0)//
            {
                int i = dgvDetails.FocusedRowHandle;
                if (i >= 0)
                    strSeq_id = dtTe.Rows[i]["seq_id"].ToString();// dgvDetails.GetRowCellValue(i, "seq_id").ToString();                
                else
                    strSeq_id = "";
            }
        }

        private void dgvDetails_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                {
                    string rowStatus = dgvDetails.GetDataRow(e.RowHandle).RowState.ToString();
                    if (rowStatus == "Added" || rowStatus == "Modified")
                    {
                        e.Appearance.ForeColor = Color.Black;
                        e.Appearance.BackColor = Color.LemonChiffon;
                    }                   
                }
                else
                {
                    if (!string.IsNullOrEmpty(dgvDetails.GetRowCellValue(e.RowHandle, "expiry_date").ToString()) && !string.IsNullOrEmpty(dgvDetails.GetRowCellValue(e.RowHandle, "valid_date").ToString()))
                    {
                        if (Convert.ToDateTime(dgvDetails.GetRowCellValue(e.RowHandle, "valid_date").ToString()) > Convert.ToDateTime(dgvDetails.GetRowCellValue(e.RowHandle, "expiry_date").ToString()))
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }                        
                    }
                }
            }
        }


        ////DEV gridview 雙擊打開事件
        //private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        //{            
        //    if (OperationType == clsUtility.enumOperationType.Add)
        //    {
        //        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = dgvDetails.CalcHitInfo(new Point(e.X, e.Y));
        //        if (hInfo.InRow)
        //        {
        //            SetFocuse(dgvDetails, dgvDetails.RowCount-1, "seq_id");
        //        }
        //        //是否雙擊
        //        //if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //        //{
        //        //    //判断光标是否在行范围内  
        //        //    if (hInfo.InRow)
        //        //    {
        //        //        //取得选定行信息  
        //        //        string nodeName = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "test_report_no").ToString();
        //        //        MessageBox.Show(nodeName, "");
        //        //    }
        //        //}
        //    }
        //}

        private void BTNINVOICE_Click(object sender, EventArgs e)
        {
            SetInvoice();
        }

        private void SetInvoice()
        {
            if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
            {
                return;
            }
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            string test_report_no = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "test_report_no").ToString();
            if (!string.IsNullOrEmpty(test_report_no))
            {
                SqlParameter[] spars = new SqlParameter[]{new SqlParameter("@test_report_no",test_report_no)};
                DataTable dt = new DataTable();
                dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_test_report_invoice", spars);
                lstModel.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mdlTestInvoiceData oMdl = new mdlTestInvoiceData()
                    {
                        test_report_no = dt.Rows[i]["test_report_no"].ToString(),
                        sales_group = dt.Rows[i]["sales_group"].ToString(),
                        mat_id = dt.Rows[i]["mat_id"].ToString(),
                        color_id = dt.Rows[i]["color_id"].ToString(),
                        product_type_id = dt.Rows[i]["product_type_id"].ToString(),
                        cust_color = dt.Rows[i]["cust_color"].ToString(),
                        trim_code = dt.Rows[i]["trim_code"].ToString(),
                        test_item_id = dt.Rows[i]["test_item_id"].ToString(),
                        expiry_date = clsAppPublic.Return_String_Date(dt.Rows[i]["expiry_date"].ToString()),
                        ref_mo = dt.Rows[i]["ref_mo"].ToString(),
                        test_dept = dt.Rows[i]["test_dept"].ToString()
                    };
                    lstModel.Add(oMdl);
                }
                if (lstModel.Count > 0)
                {
                    using (frmTestInvoice ofrmInv = new frmTestInvoice())
                    {
                        ofrmInv.lsModel = lstModel;
                        ofrmInv.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// 設置某單元格獲得焦點
        /// </summary>
        /// <param name="view"></param>
        /// <param name="rowHandle"></param>
        /// <param name="columnName"></param>
        private void SetFocuse(DevExpress.XtraGrid.Views.Grid.GridView dev_view, Int32 rowHandle, string columnName)
        {
            dev_view.Focus();
            dev_view.FocusedRowHandle = rowHandle;
            dev_view.FocusedColumn = dev_view.Columns[columnName];
            dev_view.ShowEditor();
        }

        private void btnGetmoinfo_Click(object sender, EventArgs e)
        {
            if (txtRef_mo.Text != "")
            {
                if (OperationType == clsUtility.enumOperationType.Add || OperationType == clsUtility.enumOperationType.Update)
                {
                    string sql = string.Format(
                    @"Select substring(goods_id,4,7) as artworkcode,Isnull(customer_goods,'') as customer_goods,Isnull(customer_color_id,'') as customer_color 
                      From so_order_details Where within_code='0000' and mo_id='{0}'", txtRef_mo.Text);
                    DataTable dtmoinfo = clsPublicOfGEO.GetDataTable(sql);
                    if (dtmoinfo.Rows.Count > 0)
                    {
                        txtPattern_id.Text = dtmoinfo.Rows[0]["artworkcode"].ToString();
                        txtTrim_code.Text = dtmoinfo.Rows[0]["customer_goods"].ToString();
                        txtFinish_name.Text = dtmoinfo.Rows[0]["customer_color"].ToString();
                    }
                }
            }
        }

        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            string strFile = btnEditTest_report_Path.Text;
            bool Result=clsTestProductPlan.Open_Test_Report(strFile, dtReport_Path_List, "COPY");
            if (Result == true)
                MessageBox.Show("文件已複製到粘貼簿!","系統信息");
            //string filePath = btnEditTest_report_Path.Text;// @"c:\vue01\index.html";

            //string dirPath = @"c:\vue01";

            //System.Collections.Specialized.StringCollection strcoll = new System.Collections.Specialized.StringCollection(); //收集路径

            //strcoll.Add(filePath);

            ////strcoll.Add(dirPath);

            //Clipboard.SetFileDropList(strcoll);//将要复制的文件货文件夹路径放入剪切板
        }
    }
}
