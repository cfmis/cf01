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
using DevExpress.XtraEditors;


namespace cf01.Forms
{
	public partial class frmTestStandard : Form
	{
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
		public string mID = "";    //臨時的主鍵值
		public static string ID_Search = "";
		public string mState = ""; //新增或編輯的狀態
		public static string str_language = "0";
		public string msgCustom;
		public bool mAdded_isModify ; //數據的修改狀態
		public bool save_flag;
		public string strArea = "";
		readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
		public string test_public_path = "";

        //初始化查詢窗體
        public static string ststrMat_id = "";
        public static string ststrColor_type = "";
        public static string ststrCustomer_color_id = "";
        public static string ststrTest_Item = "";
        public static string ststrPattern_id = "";
        public static string strGroup="";
        public static string strSize="";
        public static string strCf_color="";
        public static string strCustomer_goods="";        


        //返回值
        public static string ststrTest_Report_No = "";  //報告編號
        public static string ststrTest_Reprot_Path = "";//報告路徑
        public static string ststrEffect = "";    //有效日期
        public static string ststrTrim_color_code = "";  //送測編號
        public static string ststrRef_mo = "";  //參考頁數
        public static Boolean stbolFlag_Return = false;

		DataTable dtStandard_mostly = new DataTable();
		DataTable dtStandard_details = new DataTable();
		DataTable dtTempDel = new DataTable();
		DataTable dtTestItem = new DataTable();
		DataTable dtType_condition = new DataTable();
        private DataTable dtReport_Path_List = new DataTable();


		public frmTestStandard()
		{
			InitializeComponent();

			//clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
			//control.GenerateContorl();

            //clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();


			str_language = DBUtility._language;
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();
		}

        private void frmTestStandard_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConErp = null;
            dtStandard_mostly = null;
            dtStandard_details = null;
            dtTempDel = null;
            dtTestItem = null;
            dtType_condition = null;
            dtReport_Path_List.Dispose();
        }  

		private void frmTestStandard_Load(object sender, EventArgs e)
		{
			//單據前綴
			strArea = clsPublicOfCF01.ExecuteSqlReturnObject("SELECT @@SERVERNAME");
			strArea = strArea.Substring(0, 2);
			if (strArea == "DG")
			{
				strArea = "D";//DG輸入
			}
			else
			{
				strArea = "H"; //HK輸入
			}
			//牌子類別
			clsTestProductPlan.SetBrandType(txtBrand_category);
			//顏色
			clsTestProductPlan.SetColorType(txtColor_category);
			//原材料
			clsTestProductPlan.SetMatType(txtDatum);
			//產品類型
			clsTestProductPlan.SetProductType(txtProducts_type);

			//生成gridview1明細表結構
			//dtStandard_details = clsPublicOfCF01.GetDataTable("Select * from dbo.bs_test_standard_details where 1=0");
            //dtStandard_details = clsConErp.GetDataTable("Select * from dbo.cd_customer_test_details where 1=0");
            const string strSql = @"SELECT B.customer_test_id,B.sequence_id,B.test_item_id,B.test_report_no,B.effect,B.ref_mo,B.remark,B.type_condition,
                            B.trim_color_code,B.test_report_path,C.test_item_name,C.english_name as test_item_name_english 
                            FROM dbo.cd_customer_test_details B,dbo.cd_qc_test_item C WHERE 1=0 ";
            dtStandard_details = clsConErp.GetDataTable(strSql);
			gridControl1.DataSource = dtStandard_details;
			//臨時項目刪除表結構
			dtTempDel = dtStandard_details.Clone();

			//gridview1測試項目下拉列表框
			//dtTestItem = DBUtility.GetDataTable("SELECT id,cdesc,edesc FROM dbo.bs_test_item");
			dtTestItem = clsTestProductPlan.GetTestItemForLue();//取ERP中的測試項目
			clTest_item_id.DataSource = dtTestItem;
			clTest_item_id.ValueMember = "test_item_id";
			clTest_item_id.DisplayMember = "test_item_id";
			clTest_item_id.ShowHeader = false;
			//clTest_item_id.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

			//gridview1條件分類下拉列表框
			dtType_condition = clsPublicOfCF01.GetDataTable("Select id,cdesc From dbo.bs_test_item_mostly");
			clType_conditon.DataSource = dtType_condition;
			clType_conditon.ValueMember = "id";
			clType_conditon.DisplayMember = "cdesc";
			clType_conditon.ShowHeader = false;

			//取測試報告公共路徑            
			test_public_path = clsTestProductPlan.Get_Test_Public_Path();

            //設置組別資料
            DataTable dtSales_Group=clsSales_group.Get_sales_group();
            txtSales_group.Properties.DataSource = dtSales_Group;
            txtSales_group.Properties.ValueMember = "id";
            txtSales_group.Properties.DisplayMember = "cdesc";

            dtReport_Path_List = clsTestProductPlan.Get_Test_Report_Path(); 
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
			if (gridView1.RowCount == 0)
			{
				return;
			}
			DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int curRow = gridView1.FocusedRowHandle;
				//將當前行刪除幷加到臨時表中
				DataRow newRow = dtTempDel.NewRow();
				newRow["test_item_id"] = txtID.Text;
				newRow["sequence_id"] = gridView1.GetRowCellDisplayText(curRow, "sequence_id");
				newRow["test_item_id"] = gridView1.GetRowCellDisplayText(curRow, "test_item_id");
				dtTempDel.Rows.Add(newRow);
				gridView1.DeleteRow(curRow);//移走當前行                
			}
		}

		private void BTNSAVE_Click(object sender, EventArgs e)
		{
			txtRemark.Focus();//Toolscript焦點問題
			Save();
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void BTNFIND_Click(object sender, EventArgs e)
		{
			frmTestFind frmTest = new frmTestFind();
			frmTest.ShowDialog();
			if (frmTestStandard.ID_Search != "")
			{
				Find_doc(frmTestStandard.ID_Search);
			}
			frmTestStandard.ID_Search = "";
			frmTest.Dispose();
		}

		private void AddNew()  //新增
		{
			mState = "NEW";
			txtID.Focus();
			SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
			SetObjValue.ClearObjValue(Controls, "1");
			txtBrand_category.Enabled = true;
			DataRow dr = dtStandard_mostly.NewRow(); //插一空行
			dtStandard_mostly.Rows.InsertAt(dr, 0);

			dtStandard_details.Clear();
			gridControl1.DataSource = dtStandard_details;
		}

        private void Edit()  //編輯
        {
            if (txtID.Text == "")
            {
                return;
            }

            SetButtonSatus(false);
            btnAuto.Enabled = false;
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = Color.White;
            txtBrand_category.Enabled = false;
            txtBrand_category.BackColor = Color.White;
            txtSales_group.Enabled = false;
            txtSales_group.BackColor = Color.White;
        }

		private void SetButtonSatus(bool _flag) //設置工具欄
		{
			BTNNEW.Enabled = _flag;
			BTNEDIT.Enabled = _flag;
			BTNPRINT.Enabled = _flag;
			BTNDELETE.Enabled = _flag;
			BTNFIND.Enabled = _flag;
			BTNSAVE.Enabled = !_flag;
			BTNCANCEL.Enabled = !_flag;
			BTNITEMADD.Enabled = !_flag;
			BTNITEMDEL.Enabled = !_flag;

			btnAuto.Enabled = !_flag;

            //clsAppPublic.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(Name, Controls);
            obj.SetToolBar();
		}

		private void Set_Grid_Status(bool _flag) // 表格可編號否
		{
			//false--不可編輯;true--可以編輯
			gridView1.OptionsBehavior.Editable = _flag;
			//gridView2.OptionsBehavior.Editable = _flag;                       
		}

		private void Delete() //刪除當前行
		{
			if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtBrand_category.Text))
			{
				return;
			}

			//DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			DialogResult result = MessageBox.Show("此操作將刪除主表及明細中的資料,請謹慎操作!", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				//const string sql_del = @"Update dbo.bs_test_standard_mostly SET state='2' WHERE customer_test_id=@customer_test_id";
                const string sql_del = @"Update dbo.cd_customer_test SET state='2' WHERE within_code='0000' AND customer_test_id=@customer_test_id";
                
				//SqlConnection myCon = new SqlConnection(DBUtility.connectionString);//舊的
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);//改回直接操作GEO
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_del;//刪除主檔
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@customer_test_id", txtID.Text.Trim());
						myCommand.ExecuteNonQuery();

						myTrans.Commit(); //數據提交                        
						MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
						SetObjValue.ClearObjValue(Controls, "1");
						dtStandard_details.Clear();
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

		private void AddNew_Item()
		{
			if (!String.IsNullOrEmpty(txtID.Text.Trim()) && !String.IsNullOrEmpty(txtBrand_category.Text)) // 有內容
			{
				if (Check_Details_Valid())
				{
					return;
				}
				Set_Grid_Status(true);
				gridView1.AddNewRow();//新增
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sequence_id", (gridView1.RowCount + 1).ToString("0000")+"h");

				ColumnView view = (ColumnView)gridView1;//初始單元格焦點
				view.FocusedColumn = view.Columns["test_item_id"];
				view.Focus();
			}
			else
			{
				MessageBox.Show("主表的檢驗分類編號,牌子編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrand_category.Focus();
			}
		}

		private bool Check_Details_Valid() //檢查明細資料的有效性
		{
			//測試項目必須有輸入
			bool _flag = false;
			if (gridView1.RowCount > 0)
			{
				txtRemark.Focus();
				//因toolStrip控件焦點問題
				//設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，附止取到的值爲空
				// ColumnView view = (ColumnView)gridView1 ;
				// view.FocusedColumn = view.Columns["test_item_id"];                
				int curRow = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					curRow = gridView1.GetRowHandle(i);
					if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "test_item_id")))
					{
						_flag = true;
						MessageBox.Show("測試項目編號不可以爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)gridView1;
						view1.FocusedColumn = view1.Columns["test_item_id"]; //設置單元格焦點                        
						break;
					}

                    if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "test_report_no")) && 
                        String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "ref_mo")))
                    {
                        MessageBox.Show("測試報告編號和參考頁數不可以同時爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _flag = true;
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
			SetObjValue.ClearObjValue(Controls, "2");
			Set_Grid_Status(false);

			dtTempDel.Clear();
			dtStandard_details.Clear();
			gridControl1.DataSource = dtStandard_details;

			mState = "";
			mAdded_isModify = false;
			if (!String.IsNullOrEmpty(mID))
			{
				Find_doc(mID);
			}
		}

		private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
		{
			if (!String.IsNullOrEmpty(temp_id))
			{
                //string sql_h = String.Format(
                //        @"SELECT * FROM dbo.bs_test_standard_mostly WITH(nolock) 
				//		WHERE customer_test_id ='{0}' AND state='{1}'", temp_id, "0");
                //string sql_d = String.Format(
                //        @"SELECT B.* FROM dbo.bs_test_standard_mostly A with(nolock),dbo.bs_test_standard_details B with(nolock) 
				//		WHERE A.customer_test_id = B.customer_test_id AND A.customer_test_id='{0}' AND state='{1}'", temp_id, "0");
                string sql_h = String.Format(
                        @"SELECT * FROM dbo.cd_customer_test WITH(nolock) 
						WHERE within_code='0000' AND customer_test_id ='{0}' AND state='{1}'", temp_id, "0");
                string sql_d = String.Format(
                        @"SELECT B.customer_test_id,B.sequence_id,B.test_item_id,B.test_report_no,B.effect,B.ref_mo,B.remark,B.type_condition,
                          B.trim_color_code,B.test_report_path,C.test_item_name,C.english_name as test_item_name_english  
                        FROM dbo.cd_customer_test A with(nolock)
                        INNER JOIN dbo.cd_customer_test_details B with(nolock) ON A.within_code=B.within_code AND A.customer_test_id=B.customer_test_id
                        LEFT JOIN dbo.cd_qc_test_item C with(nolock) ON B.within_code=C.within_code AND B.test_item_id=C.test_item_id
						WHERE A.within_code='0000' AND A.customer_test_id='{0}' AND A.state='{1}'", temp_id, "0");

				dtStandard_mostly = clsConErp.GetDataTable(sql_h);
				if (dtStandard_mostly.Rows.Count > 0)
					Set_Master_Data(dtStandard_mostly);
				else
				{
					SetObjValue.ClearObjValue(Controls, "2");
					return;
				}
				dtStandard_details.Clear();
				dtStandard_details = clsConErp.GetDataTable(sql_d);
				gridControl1.DataSource = dtStandard_details;
				mID = txtID.Text;//保存臨時的ID號               
			}
		}

		private void Save()  //保存
		{			
            if (!Save_Before_Valid())
			{
				return;
			}
            if (chkmockup.Checked)
            {
                mAdded_isModify = false;//為不彈出以下的提示而加此提示
            }
			if (mAdded_isModify)
			{
				msgCustom = "牌子類別、顏色類別、原材料或產品類別 已有更改,請重新按【自動獲取測試項目】\n\n因以上數據的改變,對應要做的測試項目是不同的!";
				MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (Check_Details_Valid())//檢查明細資料的有效性
			{
				return;
			}

			if (IsRepeat()) //檢查明細是否有重覆測試項目
			{
				return;
			}

			save_flag = false;

			#region  保存新增
			if (mState == "NEW")
			{
				if (Valid_Doc())
				{
					return;
				}
                //const string sql_i =
                //    @"INSERT INTO dbo.bs_test_standard_mostly(customer_test_id,brand_category,customer_goods,customer_color_id,color_category,
				//		datum,products_type,pattern_id,remark,state,create_by,create_date) values
				//	   (@customer_test_id,@brand_category,@customer_goods,@customer_color_id,@color_category,@datum,@products_type,
				//		@pattern_id,@remark,@state,@crusr,getdate())";
                const string sql_i =
                    @"INSERT INTO dbo.cd_customer_test(within_code,customer_test_id,brand_category,customer_goods,customer_color_id,color_category,
						datum,products_type,pattern_id,remark,state,create_by,create_date,sales_group,size,cf_color) values
					   ('0000',@customer_test_id,@brand_category,@customer_goods,@customer_color_id,@color_category,@datum,@products_type,
						@pattern_id,@remark,@state,@crusr,getdate(),@sales_group,@size,@cf_color)";
				GetDocNo();
				//SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2); //改爲GEO
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_i;
						myCommand.Parameters.Clear();                        
						myCommand.Parameters.AddWithValue("@customer_test_id", txtID.Text.Trim());
						myCommand.Parameters.AddWithValue("@brand_category", txtBrand_category.EditValue);
						myCommand.Parameters.AddWithValue("@customer_goods", txtCustomer_goods.Text.Trim());
						myCommand.Parameters.AddWithValue("@customer_color_id", txtCustomer_color_id.Text.Trim());
						myCommand.Parameters.AddWithValue("@color_category", txtColor_category.EditValue);
						myCommand.Parameters.AddWithValue("@datum", txtDatum.EditValue);
						myCommand.Parameters.AddWithValue("@products_type", txtProducts_type.EditValue);
						myCommand.Parameters.AddWithValue("@pattern_id", txtPattern_id.Text);
						myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
						myCommand.Parameters.AddWithValue("@state", "0");
						myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        myCommand.Parameters.AddWithValue("@sales_group", txtSales_group.EditValue);
                        myCommand.Parameters.AddWithValue("@size", txtSize.Text);
                        myCommand.Parameters.AddWithValue("@cf_color", txtCf_color.Text);                        
						myCommand.ExecuteNonQuery();

						//保存明細
						if (gridView1.RowCount > 0)
						{
							//const string sql_item_i =
							//	@"INSERT INTO dbo.bs_test_standard_details(customer_test_id,sequence_id,test_item_id,test_item_name,test_item_name_english,test_report_no,effect,ref_mo,remark,type_condition)
							//		VALUES(@customer_test_id,@sequence_id,@test_item_id,@test_item_name,@test_item_name_english,@test_report_no,@effect,@ref_mo,@remark,@type_condition)";
                            const string sql_item_i =
                                @"INSERT INTO dbo.cd_customer_test_details(within_code,customer_test_id,sequence_id,test_item_id,test_report_no,effect,ref_mo,remark,type_condition,trim_color_code,test_report_path)
									VALUES('0000',@customer_test_id,@sequence_id,@test_item_id,@test_report_no,@effect,@ref_mo,@remark,@type_condition,@trim_color_code,@test_report_path)";
                            
                            string strSeq_id = "";
							for (int i = 0; i < dtStandard_details.Rows.Count; i++)
							{
								//curRow = gridView1.GetRowHandle(i);
								myCommand.CommandText = sql_item_i;
								myCommand.Parameters.Clear();                                
                                myCommand.Parameters.AddWithValue("@customer_test_id", txtID.Text.Trim());
								strSeq_id = Get_Details_Seq(txtID.Text.Trim()); //新增狀態重取最大序號
								myCommand.Parameters.AddWithValue("@sequence_id", strSeq_id);
								myCommand.Parameters.AddWithValue("@test_item_id", dtStandard_details.Rows[i]["test_item_id"].ToString());
								//myCommand.Parameters.AddWithValue("@test_item_name", dtStandard_details.Rows[i]["test_item_name"].ToString());
								//myCommand.Parameters.AddWithValue("@test_item_name_english", dtStandard_details.Rows[i]["test_item_name_english"].ToString());
								myCommand.Parameters.AddWithValue("@test_report_no", dtStandard_details.Rows[i]["test_report_no"].ToString());
								myCommand.Parameters.AddWithValue("@effect", dtStandard_details.Rows[i]["effect"]);
								myCommand.Parameters.AddWithValue("@ref_mo", dtStandard_details.Rows[i]["ref_mo"].ToString());
								myCommand.Parameters.AddWithValue("@remark", dtStandard_details.Rows[i]["remark"].ToString());
								myCommand.Parameters.AddWithValue("@type_condition", dtStandard_details.Rows[i]["type_condition"].ToString());
                                myCommand.Parameters.AddWithValue("@trim_color_code", dtStandard_details.Rows[i]["trim_color_code"].ToString());
                                myCommand.Parameters.AddWithValue("@test_report_path", dtStandard_details.Rows[i]["test_report_path"].ToString());
                                
								myCommand.ExecuteNonQuery();
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

			#region 保存編輯
			if (mState == "EDIT")
			{
				string rowStatus = "";
				string strSeq_id = "";
				//const string sql_update =
				//	@"UPDATE bs_test_standard_mostly
				//	  SET customer_test_id=@customer_test_id,brand_category=@brand_category,customer_goods=@customer_goods,
				//		  customer_color_id=@customer_color_id,color_category=@color_category,datum=@datum,products_type=@products_type,
				//		  pattern_id=@pattern_id,remark=@remark,update_by=@update_by,update_date=getdate()
				//	  WHERE customer_test_id=@customer_test_id";
                const string sql_update =
                    @"UPDATE dbo.cd_customer_test
					  SET brand_category=@brand_category,customer_goods=@customer_goods,
						  customer_color_id=@customer_color_id,color_category=@color_category,datum=@datum,products_type=@products_type,
						  pattern_id=@pattern_id,remark=@remark,update_by=@update_by,update_date=getdate(),
                          sales_group=@sales_group,size=@size,cf_color=@cf_color
					  WHERE within_code='0000' AND customer_test_id=@customer_test_id";
				//SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_update;
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@customer_test_id", txtID.Text.Trim());
						myCommand.Parameters.AddWithValue("@brand_category", txtBrand_category.EditValue);
						myCommand.Parameters.AddWithValue("@customer_goods", txtCustomer_goods.Text.Trim());
						myCommand.Parameters.AddWithValue("@customer_color_id", txtCustomer_color_id.Text.Trim());
						myCommand.Parameters.AddWithValue("@color_category", txtColor_category.EditValue);
						myCommand.Parameters.AddWithValue("@datum", txtDatum.EditValue);
						myCommand.Parameters.AddWithValue("@products_type", txtProducts_type.EditValue);
						myCommand.Parameters.AddWithValue("@pattern_id", txtPattern_id.Text);
						myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
						myCommand.Parameters.AddWithValue("@update_by", DBUtility._user_id);
                        myCommand.Parameters.AddWithValue("@sales_group", txtSales_group.EditValue);
                        myCommand.Parameters.AddWithValue("@size", txtSize.Text);
                        myCommand.Parameters.AddWithValue("@cf_color", txtCf_color.Text);          
						myCommand.ExecuteNonQuery();

						//刪除明細資料
						for (int i = 0; i < dtTempDel.Rows.Count; i++)
						{
                            //const string sql_item_d = @"DELETE FROM dbo.bs_test_standard_details 
                            //                            WHERE customer_test_id=@customer_test_id AND sequence_id=@sequence_id AND test_item_id=@test_item_id";
                            const string sql_item_d = @"DELETE FROM dbo.cd_customer_test_details 
                                                        WHERE within_code='0000' AND customer_test_id=@customer_test_id AND sequence_id=@sequence_id AND test_item_id=@test_item_id";
							myCommand.CommandText = sql_item_d;
							myCommand.Parameters.Clear();
							myCommand.Parameters.AddWithValue("@customer_test_id", txtID.Text.Trim());
							myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());
							myCommand.Parameters.AddWithValue("@test_item_id", dtTempDel.Rows[i]["test_item_id"].ToString());
							myCommand.ExecuteNonQuery();
						}

						//保存明細資料
						if (gridView1.RowCount > 0)
						{
							//const string sql_item_i =
                            //    @"INSERT INTO bs_test_standard_details(customer_test_id,sequence_id,test_item_id,test_item_name,test_item_name_english,test_report_no,effect,ref_mo,remark,type_condition)
							//		VALUES(@customer_test_id,@sequence_id,@test_item_id,@test_item_name,@test_item_name_english,@test_report_no,@effect,@ref_mo,@remark,@type_condition)";
                            //const string sql_item_u =
                            //    @"UPDATE bs_test_standard_details 
							//		SET customer_test_id=@customer_test_id,sequence_id=@sequence_id,test_item_id=@test_item_id,test_item_name=@test_item_name,
							//			test_item_name_english=@test_item_name_english,test_report_no=@test_report_no,effect=@effect,ref_mo=@ref_mo,remark=@remark,type_condition=@type_condition
							//	  WHERE customer_test_id=@customer_test_id AND sequence_id=@sequence_id ";
                            const string sql_item_i =
                                @"INSERT INTO dbo.cd_customer_test_details(within_code,customer_test_id,sequence_id,test_item_id,test_report_no,effect,ref_mo,remark,type_condition,trim_color_code,test_report_path)
									VALUES('0000',@customer_test_id,@sequence_id,@test_item_id,@test_report_no,@effect,@ref_mo,@remark,@type_condition,@trim_color_code,@test_report_path)";
							const string sql_item_u =
                                @"UPDATE dbo.cd_customer_test_details 
									SET test_item_id=@test_item_id,test_report_no=@test_report_no,effect=@effect,ref_mo=@ref_mo,remark=@remark,type_condition=@type_condition,
                                        trim_color_code=@trim_color_code,test_report_path=@test_report_path 
								  WHERE within_code='0000' AND customer_test_id=@customer_test_id AND sequence_id=@sequence_id ";
							for (int i = 0; i < dtStandard_details.Rows.Count; i++)
							{
								rowStatus = dtStandard_details.Rows[i].RowState.ToString();
								if (rowStatus == "Added" || rowStatus == "Modified")
								{
									if (rowStatus == "Added")
									{
										myCommand.CommandText = sql_item_i;
										strSeq_id = Get_Details_Seq(txtID.Text.Trim()); //新增狀態重新取最大序號
									}
									if (rowStatus == "Modified")
									{
										myCommand.CommandText = sql_item_u;
										strSeq_id = dtStandard_details.Rows[i]["sequence_id"].ToString();//編輯狀態原序號保持不變
									}
									myCommand.Parameters.Clear();
									myCommand.Parameters.AddWithValue("@customer_test_id", txtID.Text.Trim());
									myCommand.Parameters.AddWithValue("@sequence_id", strSeq_id);
									myCommand.Parameters.AddWithValue("@test_item_id", dtStandard_details.Rows[i]["test_item_id"].ToString());
									//myCommand.Parameters.AddWithValue("@test_item_name", dtStandard_details.Rows[i]["test_item_name"].ToString());
									//myCommand.Parameters.AddWithValue("@test_item_name_english", dtStandard_details.Rows[i]["test_item_name_english"].ToString());
									myCommand.Parameters.AddWithValue("@test_report_no", dtStandard_details.Rows[i]["test_report_no"].ToString());
									myCommand.Parameters.AddWithValue("@effect", dtStandard_details.Rows[i]["effect"]);
									myCommand.Parameters.AddWithValue("@ref_mo", dtStandard_details.Rows[i]["ref_mo"].ToString());
									myCommand.Parameters.AddWithValue("@remark", dtStandard_details.Rows[i]["remark"].ToString());
									myCommand.Parameters.AddWithValue("@type_condition", dtStandard_details.Rows[i]["type_condition"].ToString());
                                    myCommand.Parameters.AddWithValue("@trim_color_code", dtStandard_details.Rows[i]["trim_color_code"].ToString());
                                    myCommand.Parameters.AddWithValue("@test_report_path", dtStandard_details.Rows[i]["test_report_path"].ToString());
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
			txtBrand_category.Enabled = false;
            txtSales_group.Enabled = false;
			dtTempDel.Clear();
			if (save_flag)
			{
				Find_doc(txtID.Text);
				MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private bool Save_Before_Valid() //保存前檢查主檔資料有效性
		{
			if (txtSales_group.Text =="" ||txtID.Text == "" || txtBrand_category.Text == "" || txtColor_category.Text == "" || txtDatum.Text == "")
			{
				if (str_language == "2")
				{
					msgCustom = "Data cannot be empty.";
				}
				else
				{
					msgCustom = "檢驗分類編號、牌子類別,顏色類別,原材料不可爲空!";
				}
				MessageBox.Show(msgCustom, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool Valid_Doc() //主建是否已存在
		{
			bool flag;
			string doc = txtID.Text.Trim();
			//string strSql = String.Format("Select '1' FROM dbo.bs_test_standard_mostly WHERE customer_test_id='{0}'", doc);
            string strSql = String.Format("Select '1' FROM dbo.cd_customer_test WHERE within_code='0000' and customer_test_id='{0}'", doc);
			//DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            DataTable dt = clsConErp.GetDataTable(strSql);
			if (dt.Rows.Count > 0)
			{
				MessageBox.Show(myMsg.msgIsExists + String.Format("【{0}】", doc), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				flag = true;
			}
			else
			{
				flag = false;
			}
			dt.Dispose();
			return flag;

		}

		public static string Get_Details_Seq(string _id) //取明細的序號
		{
			DataTable dtMaxseq = new DataTable();

			//dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(sequence_id) as seq_id FROM dbo.bs_test_standard_details with(nolock) WHERE customer_test_id ='{0}'", _id));
            dtMaxseq = clsConErp.GetDataTable(String.Format("SELECT MAX(sequence_id) as seq_id FROM dbo.cd_customer_test_details with(nolock) WHERE within_code='0000' AND customer_test_id ='{0}'", _id));

			string strSeq;
			if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
			{
				strSeq = "0001h";
			}
			else
			{
				strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = strSeq.Substring(0, 4);
				strSeq = (Convert.ToInt32(strSeq) + 1).ToString("0000")+"h";
			}
			dtMaxseq.Dispose();
			return strSeq;
		}

        private void txtSales_group_Click(object sender, EventArgs e)
        {
            txtSales_group.SelectAll();
        }

		private void txtBrand_category_Click(object sender, EventArgs e)
		{
			txtBrand_category.SelectAll();
		}

		private void txtColor_category_Click(object sender, EventArgs e)
		{
			txtColor_category.SelectAll();
		}

		private void txtDatum_Click(object sender, EventArgs e)
		{
			txtDatum.SelectAll();
		}

		private void txtProducts_type_Click(object sender, EventArgs e)
		{
			txtProducts_type.SelectAll();
		}

		private void GetDocNo() //取最大單據編號
		{
            if (string.IsNullOrEmpty(txtSales_group.EditValue.ToString()) || string.IsNullOrEmpty(txtBrand_category.EditValue.ToString()))
            {
                txtID.Text = "";
                return;
            }
            string temp_doc = "";
            string strgroup = txtSales_group.EditValue.ToString();
            string group = "";
            switch (strgroup)
            {
                case "E":
                    group = "E";
                    break;
                case "W":
                    group = "E";
                    break;
                default :
                    group = strgroup;
                    break;
            }
            temp_doc = strArea + group;
            string strDoc = String.Format("{0}{1}-", temp_doc, txtBrand_category.EditValue);
			string strSeq;
			string strMaxSeq;         
			DataTable dtMaxSeq = new DataTable();
			//dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(customer_test_id) as id FROM dbo.bs_test_standard_mostly WHERE customer_test_id LIKE '{0}%'", strDoc));
            dtMaxSeq = clsConErp.GetDataTable(String.Format("SELECT MAX(customer_test_id) as id FROM dbo.cd_customer_test WHERE within_code='0000' AND customer_test_id LIKE '{0}%'", strDoc));
			if (String.IsNullOrEmpty(dtMaxSeq.Rows[0]["id"].ToString()))
			{
				strSeq = "000001";
			}
			else
			{
				strMaxSeq = dtMaxSeq.Rows[0]["id"].ToString();
				strSeq = strMaxSeq.Substring(strMaxSeq.Length - 6);
				strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000000");
			}
			strMaxSeq = strDoc + strSeq;
			txtID.Text = strMaxSeq;
		}

        private void txtSales_group_Leave(object sender, EventArgs e)
        {
            GetDocNo();
        }

		private void txtBrand_category_Leave(object sender, EventArgs e)
		{
            GetDocNo();
		}

		private static void CheckDate(object obj)
		{
			string strdate = ((DateEdit)obj).Text;
			if (String.IsNullOrEmpty(strdate))
			{
				return;
			}

			bool Flag = clsValidRule.CheckDateFormat(strdate);
			if (!Flag)
			{
				string strMsg;
				if (str_language == "2")
					strMsg = "Data Fromat is Error.";
				else
					strMsg = "輸入的日期有誤！";
				MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				((DateEdit)obj).Focus();
				((DateEdit)obj).SelectAll();
			}
		}

		private void clEffect_Leave(object sender, EventArgs e)
		{
			CheckDate(sender);
		}

		private void clTest_item_id_EditValueChanged(object sender, EventArgs e)
		{
			LookUpEdit objItem = (LookUpEdit)sender;
			string strid = objItem.Text;
			int indexSelect = clTest_item_id.GetDataSourceRowIndex("test_item_id", strid);
			string strdesc = clTest_item_id.GetDataSourceValue("test_item_edesc", indexSelect).ToString();
			string strcdesc = clTest_item_id.GetDataSourceValue("test_item_cdesc", indexSelect).ToString();
			gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_item_name", strcdesc);
			gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_item_name_english", strdesc);
		}

		private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			if (gridView1.GetDataRow(e.RowHandle) == null)
			{
				return;
			}
			string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
			if (rowStatus == "Added" || rowStatus == "Modified")
			{
				e.Appearance.ForeColor = Color.Black;
				e.Appearance.BackColor = Color.LemonChiffon;
			}
		}

		private void Set_Master_Data(DataTable dt) //綁定主檔資料
		{
			txtID.Text = dt.Rows[0]["customer_test_id"].ToString();
			txtBrand_category.EditValue = dt.Rows[0]["brand_category"].ToString();
			txtCustomer_goods.Text = dt.Rows[0]["customer_goods"].ToString();
			txtCustomer_color_id.Text = dt.Rows[0]["customer_color_id"].ToString();
			txtColor_category.EditValue = dt.Rows[0]["color_category"].ToString();
			txtDatum.EditValue = dt.Rows[0]["datum"].ToString();
			txtProducts_type.EditValue = dt.Rows[0]["products_type"].ToString();
			txtPattern_id.Text = dt.Rows[0]["pattern_id"].ToString();
			txtRemark.Text = dt.Rows[0]["remark"].ToString();
            txtSales_group.EditValue = dt.Rows[0]["sales_group"].ToString();
            txtSize.Text = dt.Rows[0]["size"].ToString();
            txtCf_color.Text = dt.Rows[0]["cf_color"].ToString();

			txtCrusr.Text = dt.Rows[0]["create_by"].ToString();
			txtCrtim.Text = dt.Rows[0]["create_date"].ToString();
			txtAmusr.Text = dt.Rows[0]["update_by"].ToString();
			txtAmtim.Text = dt.Rows[0]["update_date"].ToString();
		}

		private void txtID_Leave(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(txtID.Text))
			{
				if (mState == "") //流覽模式
				{
					Find_doc(txtID.Text);
				}
			}
		}

		private void txtPattern_id_Leave(object sender, EventArgs e)
		{
			//非新增或編輯時不檢查
			if (string.IsNullOrEmpty(mState))
				return;

			//檢查7位ArtCode的有效性
			string strArtCode = txtPattern_id.Text;
			if (string.IsNullOrEmpty(strArtCode))
				return;

			string strSql = String.Format("SELECT '1' FROM dbo.cd_pattern WHERE within_code='0000' and id='{0}'", strArtCode);
			try
			{
				DataTable dt = new DataTable();
				dt = clsConErp.GetDataTable(strSql);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show("圖樣編號不正確,請返回檢查!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPattern_id.Text = "";
					txtPattern_id.Focus();					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void clRef_mo_Leave(object sender, EventArgs e)
		{
			//非新增或編輯時不檢查
			if (string.IsNullOrEmpty(mState))
				return;

			//單元格焦點發生改變時，輸入的值才有效
			ColumnView view = (ColumnView)gridView1;
			view.FocusedColumn = view.Columns["test_item_name"];
			view.Focus();

			//檢查頁數有效性
			string strRef_mo = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "ref_mo");
			if (string.IsNullOrEmpty(strRef_mo))
				return;

			string strSql = String.Format(@"SELECT '1' FROM dbo.so_order_manage A with(nolock),dbo.so_order_details B with(nolock)
											WHERE A.within_code=B.within_code AND A.id=B.id AND A.state NOT IN ('2','V') 
											AND B.mo_id='{0}' AND B.state NOT IN ('2','V')", strRef_mo);
			try
			{
				DataTable dt = new DataTable();
				dt = clsConErp.GetDataTable(strSql);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(String.Format("參考制單不存在,請返回檢查!\n\n  [{0}]", strRef_mo),
									"System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ref_mo", null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private bool IsRepeat() //測試項目編號不允許有重覆
		{
			if (gridView1.RowCount < 2)
			{
				return false;
			}
			bool result = false;
			string strTest_Item_id = "";
			for (int i = 0; i < gridView1.RowCount - 1; i++)
			{
				strTest_Item_id = gridView1.GetRowCellDisplayText(i, "test_item_id");
				for (int j = i + 1; j <= gridView1.RowCount - 1; j++)
				{
					if (strTest_Item_id == gridView1.GetRowCellDisplayText(j, "test_item_id"))
					{
						MessageBox.Show("測試項目編號不可以有重覆!\n\n" + string.Format("【{0}】", strTest_Item_id),
												  myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						result = true;
						break;
					}
				}
			}
			return result;
		}

		private void btnAuto_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(txtID.Text.Trim()) && !String.IsNullOrEmpty(txtBrand_category.Text)) // 有內容
			{
				Add_Test_Item();
			}
			else
			{
				MessageBox.Show("主表的檢驗分類編號,牌子編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrand_category.Focus();
			}
		}

		private void Add_Test_Item()
		{
			SqlParameter[] paras = new SqlParameter[]
			{
					new SqlParameter("@brand_category", txtBrand_category.EditValue),
					new SqlParameter("@color_category", txtColor_category.EditValue),
					new SqlParameter("@datum", txtDatum.EditValue),
					new SqlParameter("@products_type", txtProducts_type.EditValue),
                    new SqlParameter("@choose", txtChoose.Text.Trim())
			};
			DataTable dtItem_test = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_get_test_item", paras);
			if (dtItem_test.Rows.Count > 0)
			{
				Set_Grid_Status(true);
				if (gridView1.OptionsBehavior.Editable == false)
				{
					Set_Grid_Status(true);
				}
				dtStandard_details.Clear();
				for (int i = 0; i < dtItem_test.Rows.Count; i++)
				{
					gridView1.AddNewRow();//新增
					int curRow = gridView1.FocusedRowHandle;
					gridView1.SetRowCellValue(curRow, "sequence_id", (gridView1.RowCount + 1).ToString("000"));
					gridView1.SetRowCellValue(curRow, "test_item_id", dtItem_test.Rows[i]["test_item_id"].ToString());
					gridView1.SetRowCellValue(curRow, "test_item_name", dtItem_test.Rows[i]["cdesc"].ToString());
					gridView1.SetRowCellValue(curRow, "test_item_name_english", dtItem_test.Rows[i]["edesc"].ToString());
					gridView1.SetRowCellValue(curRow, "type_condition", dtItem_test.Rows[i]["type_condition"].ToString());
				}
				mAdded_isModify = false;
				
				ColumnView view = (ColumnView)gridView1;//初始單元格焦點
				view.FocusedColumn = view.Columns["test_item_id"];
				view.Focus();
			}
		}

		private void clBtnTest_report_no_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
            OpenFileDialog openFile = new OpenFileDialog() { 
                Filter = "PDF Files (*.PDF)|*.PDF", 
                RestoreDirectory = true, 
                Title = "鍊接的測試文檔", 
                InitialDirectory = test_public_path /*初始測試報告路徑      */ 
            };
			openFile.ShowDialog();

			string strFile = openFile.FileName;
			if (strFile != "")
			{
				string strReport_path = GetConString(strFile, test_public_path);
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_report_path", strReport_path);
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

		private void gridView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 2) // 判断是否是用鼠标双击    
			{
				if (mState == "") //瀏覽狀態時執行此代碼
				{
					DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo ghi = gridView1.CalcHitInfo(new Point(e.X, e.Y));
					if (ghi.InRow)  // 判断光标是否在行内    
					{
                        if (ghi.Column.Name == "test_report_no" || ghi.Column.Name == "test_report_path")
						{
							//打開PDF檔
							string strFile = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "test_report_path");
							if (!string.IsNullOrEmpty(strFile))
							{
                                //strFile = test_public_path + strFile.Trim();
                                //clsTestProductPlan.Open_test_pdf(strFile);
                                clsTestProductPlan.Open_Test_Report(strFile, dtReport_Path_List);
							}
						}
					}
				}
			}
		}

		private void btnSeting_Click(object sender, EventArgs e)
		{
			frmTest_item_set frm = new frmTest_item_set();
			frm.ShowDialog();
			frm.Dispose();
		}

		private void Added_isModify()
		{
			if (mState == "NEW")
			{
				mAdded_isModify = true;
			}
		}

		private void txtBrand_category_EditValueChanged(object sender, EventArgs e)
		{
			Added_isModify();
		}

		private void txtColor_category_EditValueChanged(object sender, EventArgs e)
		{
			Added_isModify();
		}

		private void txtDatum_EditValueChanged(object sender, EventArgs e)
		{
			Added_isModify();
		}

		private void txtProducts_type_EditValueChanged(object sender, EventArgs e)
		{
			Added_isModify();
		}

        private void clButFindReport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //設置調用表單將要用到的參數值
            ststrMat_id =txtDatum.EditValue.ToString();
            ststrColor_type = txtColor_category.EditValue.ToString();
            ststrCustomer_color_id = txtCustomer_color_id.Text;           
            ststrTest_Item = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "test_item_id"); ;
            ststrPattern_id =txtPattern_id.Text;
            strGroup = txtSales_group.EditValue.ToString();
            strSize = txtSize.Text;
            strCf_color = txtCf_color.Text;
            strCustomer_goods = txtCustomer_goods.Text;

            if (string.IsNullOrEmpty(ststrTest_Item))
            {
                MessageBox.Show("測試項目不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmTestExcel_find frmExcel = new frmTestExcel_find();
            frmExcel.ShowDialog();
            if (frmTestStandard.stbolFlag_Return)
            {
                string strDate;
                if (!string.IsNullOrEmpty(ststrEffect))
                    strDate = ststrEffect;
                else
                    strDate = null;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_report_no", ststrTest_Report_No);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "effect", strDate);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "trim_color_code", ststrTrim_color_code);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ref_mo", ststrRef_mo);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "test_report_path", ststrTest_Reprot_Path);
            }
            frmTestStandard.stbolFlag_Return = false ;
            frmTestStandard.ststrTest_Report_No="";
            frmExcel.Dispose();
        }

          


	}
}
