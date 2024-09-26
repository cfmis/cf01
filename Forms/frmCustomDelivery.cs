using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using DevExpress.XtraEditors;
using System.IO;
using cf01.MDL;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
	public partial class frmCustomDelivery : Form
	{
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
		public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態
		public static string str_language = "0";		
		public bool save_flag;       

		DataTable dtMostly = new DataTable();
		DataTable dtDetails = new DataTable();       
		DataTable dtTempDel = new DataTable();       
        DataTable dtFind_Date = new DataTable();

        private List<custom_delivry_details> lsModel = new List<custom_delivry_details>();

		public frmCustomDelivery()
		{
			InitializeComponent();

            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

			str_language = DBUtility._language;
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();
		}

		private void frmCustomDelivery_Load(object sender, EventArgs e)
		{			
			//customer
            clsDeliveryBill.SetCustomer(lkeIt_customer);                 
			
            //數量單位
            DataTable dtUnit = clsConErp.GetDataTable(@"SELECT unit_code AS id,'' as cdesc From it_coding where within_code='0000' and id='*' and basic_unit='PCS'");
            clSend_qty_unit.DataSource = dtUnit;
            clSend_qty_unit.ValueMember = "id";
            clSend_qty_unit.DisplayMember = "id";

			//生成明細表,附加費表結構
            dtDetails = clsPublicOfCF01.GetDataTable("Select * From dbo.custom_delivery_details Where 1=0");           
			gridControl1.DataSource = dtDetails;            

			//臨時項目刪除表結構
			dtTempDel = dtDetails.Clone();
 
            //欄位表頭居中
            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                dgvDetails.Columns[i].AppearanceHeader.TextOptions.HAlignment=DevExpress.Utils.HorzAlignment.Center;
            }
            txtDat1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtDat2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
           
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
                newRow["sequence_id"] = dgvDetails.GetRowCellDisplayText(curRow, "sequence_id");
                newRow["mo_id"] = dgvDetails.GetRowCellDisplayText(curRow, "mo_id");
                newRow["goods_id"] = dgvDetails.GetRowCellDisplayText(curRow, "goods_id");                
				dtTempDel.Rows.Add(newRow);
				dgvDetails.DeleteRow(curRow);//移走當前行
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

		private void BTNPRINT_Click(object sender, EventArgs e)
		{
            Print();
		}

		private void BTNFIND_Click(object sender, EventArgs e)
		{
            tabControl1.SelectTab(2);//跳至第三頁
		}

		private void AddNew()  //新增
		{
			mState = "NEW";
			txtID.Focus();
			SetButtonSatus(false);
            Set_Grid_Status(true);
			SetObjValue.SetEditBackColor(this.tabPage1.Controls, true);
            SetObjValue.ClearObjValue(this.tabPage1.Controls, "1");            
            
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);

            lkeIt_customer.EditValue = "";
            txtCustomer_name.Text = "";
            txtCustomer_address.Text = "";
            txtS_address.Text = "";
            txtPost_info.Text = "";
            txtContact_info.Text = "";
            txtRemark.Text = "";     
            //GetID_No();
            dtIssues_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");           

			dtDetails.Clear();
			gridControl1.DataSource = dtDetails;
            tabControl1.SelectTab(0);//跳至第一頁
            
		}

		private void Edit()  //編輯
		{
			if (txtID.Text == "")
			{
				return;
			}           
			SetButtonSatus(false);			
			//SetObjValue.SetEditBackColor(this.Controls, true);
            SetObjValue.SetEditBackColor(this.tabPage1.Controls, true);
			Set_Grid_Status(true);
			mState = "EDIT";

			txtID.Properties.ReadOnly = true;
			txtID.BackColor = System.Drawing.Color.White;			
			
            lkeIt_customer.Enabled = false;
            lkeIt_customer.BackColor = System.Drawing.Color.White;
            tabControl1.SelectTab(0);//跳至第一頁
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
            			
			DialogResult result = MessageBox.Show("此操作將刪除主表及明細中的資料,請謹慎操作!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{				
                const string sql_del = @"Update dbo.custom_delivery_mostly Set state='2' WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);//改回直接操作GEO
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_del;//刪除主檔
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
						myCommand.ExecuteNonQuery();

						myTrans.Commit(); //數據提交                        
						MessageBox.Show("數據刪除成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						SetObjValue.ClearObjValue(this.tabPage1.Controls, "1");
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
			if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
			{
				if (Check_Details_Valid())
				{
					return;
				}
				Set_Grid_Status(true);
				dgvDetails.AddNewRow();//新增
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);               
				dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount + 1).ToString("0000")+"h");
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_unit", "KG");               

				ColumnView view = (ColumnView)dgvDetails;//初始單元格焦點
				view.FocusedColumn = view.Columns["mo_id"];
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
				txtRemark.Focus();
				//因toolStrip控件焦點問題
				//設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，防止取到的值爲空
				// ColumnView view = (ColumnView)gridView1 ;
				// view.FocusedColumn = view.Columns["test_item_id"];    
				int curRow = 0;
				for (int i = 0; i < dgvDetails.RowCount; i++)
				{
					curRow = dgvDetails.GetRowHandle(i);
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "mo_id")) || String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "goods_id")))
					{
						_flag = true;
						MessageBox.Show("頁數或貨品編碼不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)dgvDetails;
						view1.FocusedColumn = view1.Columns["mo_id"]; //設置單元格焦點                        
						break;
					}                  
				}
			}
			return _flag;
		}

		private void Cancel() //取消
		{
			SetButtonSatus(true);
			//SetObjValue.SetEditBackColor(this.Controls, false);
            SetObjValue.SetEditBackColor(this.tabPage1.Controls, false);
            SetObjValue.ClearObjValue(this.tabPage1.Controls, "2");
			Set_Grid_Status(false);

			dtTempDel.Clear();
			dtDetails.Clear();
			gridControl1.DataSource = dtDetails;
           
			mState = "";			
			if (!String.IsNullOrEmpty(mID))
			{
				Find_doc(mID);
			}
		}

		private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
		{
			if (!String.IsNullOrEmpty(temp_id))
			{
                string sql_h = String.Format(@"SELECT * FROM dbo.custom_delivery_mostly WITH(nolock) Where id ='{0}' AND state ='0'", temp_id);
                dtMostly = clsPublicOfCF01.GetDataTable(sql_h);
                string sql_details = String.Format(@"Select * From dbo.custom_delivery_details with(nolock) Where id='{0}'", temp_id);                
                dtDetails = clsPublicOfCF01.GetDataTable(sql_details);        
                if (dtMostly.Rows.Count > 0)
                    Set_Master_Data(dtMostly);
				else
				{
					SetObjValue.ClearObjValue(this.Controls, "2");
					return;
				}
				//dtDetails.Clear();
                //dtDetails = clsConErp.GetDataTable(sql_details);
				gridControl1.DataSource = dtDetails;               

				mID = txtID.Text;//保存臨時的ID號               
			}
		}

		private void Save()  //保存
		{
			if (!Save_Before_Valid())
			{
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
                    string strSql = "Select '1' FROM dbo.custom_delivery_mostly WHERE id='" + txtID.Text.Trim() + "'";
                    if (clsPublicOfCF01.ExecuteSqlReturnObject(strSql) != "")
                    {
                        MessageBox.Show(string.Format("此送貨單編號[{0}]已存在!",txtID.Text));
                        return;
                        //GetID_No();//如已存在編號則重取最大單據編號
                    }            
                }
                string sql_i =
                @"INSERT INTO dbo.custom_delivery_mostly
                (id,issues_date,it_customer,customer_name,customer_address,s_address,contact_info,post_info,remark,state,create_by,create_date) VALUES
				(@id,@issues_date,@it_customer,@customer_name,@customer_address,@s_address,@contact_info,@post_info,@remark,'0',@user_id,getdate())";
                string sql_u =
                @"Update custom_delivery_mostly SET issues_date=CASE LEN(@issues_date) WHEN 0 THEN null ELSE @issues_date END,it_customer=@it_customer,
                customer_name=@customer_name,customer_address=@customer_address,s_address=@s_address,contact_info=@contact_info,post_info=@post_info,
                remark=@remark,update_by=@user_id,update_date=getdate() WHERE id=@id ";               
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString); //改爲CF01
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
                        if (mState == "NEW")                                                    
                            myCommand.CommandText = sql_i;          
                        else
                            myCommand.CommandText = sql_u;
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());                 
                        myCommand.Parameters.AddWithValue("@issues_date", dtIssues_date.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@it_customer", lkeIt_customer.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@customer_name", txtCustomer_name.Text);
                        myCommand.Parameters.AddWithValue("@contact_info", txtContact_info.Text);
                        myCommand.Parameters.AddWithValue("@customer_address", txtCustomer_address.Text);
                        myCommand.Parameters.AddWithValue("@s_address", txtS_address.Text);
                        myCommand.Parameters.AddWithValue("@post_info", txtPost_info.Text);
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);                                       
						myCommand.ExecuteNonQuery();                 

                        //處理【項目刪除】刪除明細資料
                        string sql_item_d;
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            //刪除明細
                            sql_item_d =@"DELETE FROM dbo.custom_delivery_details WHERE id=@id and sequence_id=@sequence_id and mo_id=@mo_id and goods_id=@goods_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());                           
                            myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());
                            myCommand.Parameters.AddWithValue("@mo_id", dtTempDel.Rows[i]["mo_id"].ToString());
                            myCommand.Parameters.AddWithValue("@goods_id", dtTempDel.Rows[i]["goods_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                        
                        //保存明細
                        int curRow;
                        string rowStatus;
						if (dgvDetails.RowCount > 0)
						{							
                            string sql_item_i =
                                @"INSERT INTO dbo.custom_delivery_details
                                (id,sequence_id,mo_id,goods_id,goods_name,table_head,customer_goods,customer_color_id,customer_size,issues_qty,issues_unit,sec_qty,sec_unit,remark,order_id) VALUES
                                (@id,@sequence_id,@mo_id,@goods_id,@goods_name,@table_head,@customer_goods,@customer_color_id,@customer_size,@issues_qty,@issues_unit,@sec_qty,@sec_unit,@remark,@order_id)";
                            string sql_item_u =
                                @"Update dbo.custom_delivery_details SET mo_id=@mo_id,goods_id=@goods_id,goods_name=@goods_name,table_head=@table_head,customer_goods=@customer_goods,
                                customer_color_id=@customer_color_id,customer_size=@customer_size,issues_qty=@issues_qty,issues_unit=@issues_unit,sec_qty=@sec_qty,sec_unit=@sec_unit,remark=@remark,order_id=@order_id
                                Where id=@id and sequence_id=@sequence_id";
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
                                    myCommand.Parameters.AddWithValue("@sequence_id", dgvDetails.GetRowCellValue(curRow, "sequence_id").ToString());
                                    myCommand.Parameters.AddWithValue("@mo_id", dgvDetails.GetRowCellValue(curRow, "mo_id").ToString());
                                    myCommand.Parameters.AddWithValue("@goods_id", dgvDetails.GetRowCellValue(curRow, "goods_id").ToString());
                                    myCommand.Parameters.AddWithValue("@goods_name", dgvDetails.GetRowCellValue(curRow, "goods_name").ToString());                              
                                    myCommand.Parameters.AddWithValue("@table_head", dgvDetails.GetRowCellValue(curRow, "table_head").ToString());
                                    myCommand.Parameters.AddWithValue("@customer_goods", dgvDetails.GetRowCellValue(curRow, "customer_goods").ToString());
                                    myCommand.Parameters.AddWithValue("@customer_color_id", dgvDetails.GetRowCellValue(curRow, "customer_color_id").ToString());
                                    myCommand.Parameters.AddWithValue("@customer_size", dgvDetails.GetRowCellValue(curRow, "customer_size").ToString());
                                    myCommand.Parameters.AddWithValue("@issues_qty", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "issues_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@issues_unit", dgvDetails.GetRowCellValue(curRow, "issues_unit").ToString());
                                    myCommand.Parameters.AddWithValue("@sec_qty", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "sec_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_unit", dgvDetails.GetRowCellValue(curRow, "sec_unit").ToString());
                                    myCommand.Parameters.AddWithValue("@remark", dgvDetails.GetRowCellValue(curRow, "remark").ToString());
                                    myCommand.Parameters.AddWithValue("@order_id", dgvDetails.GetRowCellValue(curRow, "order_id").ToString());
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
			SetObjValue.SetEditBackColor(this.tabPage1.Controls, false);
			Set_Grid_Status(false);
			mState = "";			
			dtTempDel.Clear();

           
			if (save_flag)
			{
				Find_doc(txtID.Text);                
				MessageBox.Show("當前數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
                MessageBox.Show("當前數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private bool Save_Before_Valid() //保存前檢查主檔資料有效性
		{
            if (txtID.Text == "" || dtIssues_date.Text == "" || lkeIt_customer.Text =="")
            {	
				MessageBox.Show("送貨單編號、送貨單日期、客戶編碼資料不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else			
				return true;
		}

		private bool Valid_Doc() //主建是否已存在
		{
			bool flag;
			string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM dbo.custom_delivery_mostly WHERE id='{0}' and state='0'", doc);			
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
			if (dt.Rows.Count > 0)
			{
				MessageBox.Show("當前送貨單編號已存在" + String.Format("【{0}】.", doc), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				flag = true;
			}
			else			
				flag = false;			
			dt.Dispose();
			return flag;
		}

		public static string Get_Details_Seq(string _id) //取明細最大序號
		{
			DataTable dtMaxseq = new DataTable();
            dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(sequence_id) as seq_id FROM dbo.custom_delivery_details with(nolock) WHERE id ='{0}'", _id));

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

		private void Set_Master_Data(DataTable dt) //綁定主檔資料
		{
			txtID.Text = dt.Rows[0]["id"].ToString();

            if (string.IsNullOrEmpty(dt.Rows[0]["issues_date"].ToString()))
                dtIssues_date.EditValue = "";
            else
                dtIssues_date.EditValue = Convert.ToDateTime(dt.Rows[0]["issues_date"].ToString()).ToString("yyyy-MM-dd");
            lkeIt_customer.EditValue = dt.Rows[0]["it_customer"].ToString();
            txtCustomer_name.Text = dt.Rows[0]["customer_name"].ToString();
            txtContact_info.Text = dt.Rows[0]["contact_info"].ToString();
            txtCustomer_address.Text = dt.Rows[0]["customer_address"].ToString();
            txtS_address.Text = dt.Rows[0]["s_address"].ToString();
            txtRemark.Text =dt.Rows[0]["remark"].ToString();
            txtPost_info.Text = dt.Rows[0]["post_info"].ToString();
			txtCreate_by.Text = dt.Rows[0]["create_by"].ToString();
			txtCreate_date.Text = dt.Rows[0]["create_date"].ToString();
			txtupdate_by.Text = dt.Rows[0]["update_by"].ToString();
			txtupdate_date.Text = dt.Rows[0]["update_date"].ToString();
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
   
        private void frmCustomDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.GC.Collect();
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


        private void lkeIt_customer_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                if (lkeIt_customer.EditValue.ToString() != "")
                    txtCustomer_name.Text = lkeIt_customer.GetColumnValue("cdesc").ToString();
                else
                    txtCustomer_name.Text = "";
            }
        }

       
        /// <summary>
        /// 取單據序號
        /// </summary>
        private void GetID_No()
        {
//            if (mState != "")
//            {
//                string strWareHouse = lkeIssues_wh.EditValue.ToString();
//                string strBill_type = lkeBill_type_no.EditValue.ToString();
//                if (strWareHouse == "D" && strBill_type != "")
//                {
//                    string sql = 
//                    @"Select substring(cast(year(GETDATE()) as CHAR),3,2)+
//                    CASE month(GETDATE()) 
//                    WHEN 10 THEN 'A' 
//                    WHEN 11 THEN 'B'
//                    WHEN 12 THEN 'C' 
//                    ELSE CAST(month(GETDATE()) as CHAR) END as ym";
//                    string str_ym= clsConErp.ExecuteSqlReturnObject(sql).Trim();

//                    sql =string.Format(
//                    @"Select CAST(substring(bill_code,6,5) as int)+1 as bill_code From sys_bill_max_separate with(nolock)
//                    Where within_code='0000' and bill_id ='SI01' and year_month ='{0}' AND bill_text1 ='{1}' AND bill_text2 ='{2}'", str_ym, strWareHouse, strBill_type);
//                    DataTable dt = clsConErp.GetDataTable(sql);
//                    if (dt.Rows.Count > 0)
//                    {
//                        string bill_code = (Convert.ToInt32(dt.Rows[0]["bill_code"].ToString())).ToString("00000") ;
//                        txtID.Text = strWareHouse + strBill_type + str_ym.Trim() + (int.Parse(dt.Rows[0]["bill_code"].ToString())).ToString("00000");
//                    }
//                    else
//                    {
//                        txtID.Text = strWareHouse + strBill_type + str_ym.Trim() + "00001";
//                    }
//                }
//                else
//                    txtID.Text = "";
//            } 
        }
           
     
        private void clMo_id_Leave(object sender, EventArgs e)
        {
           // Add_Cust_info();
        }

        /// <summary>
        /// 當明細資料為第一條記錄時，添加主檔資料
        /// </summary>
        private void Add_Cust_info(string order_id)
        {
            if (mState != "")
            {
                if (dgvDetails.RowCount == 1)
                {
                    //string order_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "order_id").ToString();
                    if (string.IsNullOrEmpty(order_id))
                    {
                        return;
                    }
                    string sql = string.Format(
                    @"SELECT A.it_customer,A.name as customer_name,A.customer_address,A.s_address,isnull(A.linkman,'') +'/'+ isnull(A.l_phone,'') AS contact_info                     
                    FROM so_order_manage A with(nolock)
                    WHERE A.within_code='0000' and id='{0}' and A.state not in ('2','V')", order_id);//LOC170713029
                    DataTable dt= clsConErp.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {                        
                        lkeIt_customer.EditValue = dt.Rows[0]["it_customer"].ToString();
                        txtCustomer_name.Text = dt.Rows[0]["customer_name"].ToString();
                        txtContact_info.Text = dt.Rows[0]["contact_info"].ToString();
                        txtCustomer_address.Text = dt.Rows[0]["customer_address"].ToString();
                        txtS_address.Text = dt.Rows[0]["s_address"].ToString();
                    }
                }
            }
        }

       
        //東莞D送貨單查詢 ==============BEGIN==============
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
                tabControl1.SelectTab(1);
            }
            if (txtDat1.Text == "" && txtDat2.Text == "" &&txtCust_id1.Text=="" &&txtCust_id2.Text=="" &&txtDgid1.Text=="" &&txtDgid2.Text=="" &&txtMo_id1.Text =="" &&txtMo_id2.Text=="")
            {
                MessageBox.Show("查詢條件不可以為空!", "提示信息");
                return;
            }
            string sql =
            @"Select A.id,convert(nvarchar(10),issues_date,111) as issues_date,A.it_customer,A.customer_name ,B.sequence_id,B.mo_id,B.goods_id,B.goods_name,B.issues_qty,B.issues_unit
            FROM custom_delivery_mostly A with(nolock),custom_delivery_details B with(nolock)
            WHERE A.id=B.id ";
            if (txtDgid1.Text != "")
                sql += string.Format(" AND A.id>='{0}'", txtDgid1.Text);
            if (txtDgid2.Text != "")
                sql += string.Format(" AND A.id<='{0}'", txtDgid2.Text);
            if (txtDat1.Text != "")
                sql += string.Format(" AND A.issues_date>='{0}'", txtDat1.Text);
            if (txtDat2.Text != "")
                sql += string.Format(" AND A.issues_date<='{0}'", txtDat2.Text);
            if (txtCust_id1.Text != "")
                sql += string.Format(" AND A.it_customer>='{0}'", txtCust_id1.Text);
            if (txtCust_id2.Text != "")
                sql += string.Format(" AND A.it_customer<='{0}'", txtCust_id2.Text);   
            sql+=" and A.state='0'" ;
            if (txtMo_id1.Text != "")
                sql += string.Format(" AND B.mo_id>='{0}'", txtMo_id1.Text);
            if (txtMo_id2.Text != "")
                sql += string.Format(" AND B.mo_id<='{0}'", txtMo_id2.Text);
           
            sql += " ORDER BY A.id,B.sequence_id";
            dtFind_Date = clsPublicOfCF01.GetDataTable(sql);
            dgvFind.DataSource = dtFind_Date;
            if (dtFind_Date.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.RowCount > 0)
            {                
                if (txtID.Text != dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString())
                {
                    txtID.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString();
                    //txtVer.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["ver1"].Value.ToString();
                    Find_doc(txtID.Text);
                }
            }
        }

        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strName = dgvFind.Columns[e.ColumnIndex].Name;
            if (strName == "id1")
            {                
                tabControl1.SelectTab(0);
            }
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void txtCust_id1_Leave(object sender, EventArgs e)
        {
            txtCust_id2.Text = txtCust_id1.Text;
        }

        private void txtDgid1_Leave(object sender, EventArgs e)
        {
            txtCust_id2.Text = txtCust_id1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id2.Text;
        }
       
        //東莞D送貨單查詢 ==============END==============


        //手寫單頁面代碼 =============BEGIN =============
        private void btnQuery_Click(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(txtFindId.Text) && string.IsNullOrEmpty(txtFindMo_id.Text))
            {
                MessageBox.Show("請輸入查詢條件!");
                return;
            }
            DataTable dtIdFind = clsCustomDelivery.Get_Vat_DeliveryBill(txtFindId.Text.Trim(), txtFindMo_id.Text.Trim());
            gcIdDetails.DataSource = dtIdFind;
        }
        private void btnImput_Click(object sender, EventArgs e)
        {
            Add_Items();
        }

        //過帳
        private void Add_Items()
        {
            if (dgvIdDetails.RowCount == 0)
                return;
            if (!clsDeliveryBill.Check_Add_Popedom("frmCustomDelivery"))
            {
                MessageBox.Show("當前用戶沒有此操作權限!", "提示信息");
                return;
            }

            bool flag_select = false;
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    flag_select = true;
                    break;
                }
            }
            if (!flag_select)
            {
                MessageBox.Show("請至少要選取一筆VAT送貨單的記錄!", "提示信息");
                return;
            }

            if (MessageBox.Show("確認要進行此添加操作?", "提示信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {               
                return;
            }

            lsModel.Clear();
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    custom_delivry_details objModel = new custom_delivry_details();
                    objModel.id = dgvIdDetails.GetDataRow(i)["id"].ToString();
                    objModel.issues_date = dgvIdDetails.GetDataRow(i)["issues_date"].ToString();
                    objModel.mo_id = dgvIdDetails.GetDataRow(i)["mo_id"].ToString();
                    objModel.goods_id = dgvIdDetails.GetDataRow(i)["goods_id"].ToString();
                    objModel.goods_name = dgvIdDetails.GetDataRow(i)["goods_name"].ToString().Trim();
                    objModel.issues_qty = int.Parse(dgvIdDetails.GetDataRow(i)["issues_qty"].ToString());//送貨數量                    
                    objModel.issues_unit = dgvIdDetails.GetDataRow(i)["issues_unit"].ToString();
                    objModel.sec_qty = float.Parse(dgvIdDetails.GetDataRow(i)["sec_qty"].ToString());//重量
                    objModel.sec_unit = dgvIdDetails.GetDataRow(i)["sec_unit"].ToString();//重量單位
                    objModel.remark = "";//dgvIdDetails.GetDataRow(i)["remark"].ToString();
                    objModel.order_id = dgvIdDetails.GetDataRow(i)["order_id"].ToString();
                    lsModel.Add(objModel);
                }
            }            

            tabControl1.SelectTab(0);//跳至第一頁
            if (mState == "NEW" || mState == "EDIT")//已點擊新增或編號
            {
                Add_Delivery_Data();               
                //Save();
            }
            else
            {
                //瀏覽狀態先摸擬點擊新增或編號再加入新數據
                if (dgvDetails.RowCount > 0)
                    Edit();
                else
                    AddNew();                
                Add_Delivery_Data();               
                //Save();
            }
            lsModel.Clear();
            //移除選中的行
            for (int i = dgvIdDetails.RowCount - 1; i >= 0; i--)            
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    dgvIdDetails.DeleteRow(i);//移走當前行                    
                    // dtReport.Rows.RemoveAt(i);
                }
            }            
        }   

        //將選中的記錄插入
        private void Add_Delivery_Data()
        {
            if (lsModel.Count > 0)
            {
                string strsql;
                DataTable dtOther = new DataTable();
                DataTable dtMo = new DataTable();
                dgvDetails.OptionsBehavior.Editable = true;//可編輯               
                ColumnView view;
                foreach (custom_delivry_details objModel in lsModel)
                {
                    dgvDetails.AddNewRow();//新增
                    view = (ColumnView)dgvDetails;//初始單元格焦點
                    view.FocusedColumn = view.Columns["mo_id"];
                    view.Focus();
                    if (dgvDetails.RowCount == 1)
                    {
                        Add_Cust_info(objModel.order_id);
                        txtID.Text = objModel.id;
                        dtIssues_date.EditValue = objModel.issues_date;
                    }
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);                    
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount + 1).ToString("0000") + "h");//序號
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", objModel.mo_id);//頁數
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", objModel.goods_id);//貨品編碼
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", objModel.goods_name);//貨品名稱
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "issues_qty", objModel.issues_qty);//送貨數量
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "issues_unit", objModel.issues_unit);//數量單位
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_qty", objModel.sec_qty);//重量
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_unit", objModel.sec_unit);//重量單位
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "remark", objModel.remark);//備註

                    //取OC客戶貨品，款號，顏色等資料
                    strsql = string.Format(
                    @"Select B.table_head,B.customer_goods,B.customer_color_id,B.customer_size
                    From so_order_manage A with(nolock),so_order_details B with(nolock)
                    WHERE A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver AND A.state NOT IN('2','V') AND A.id='{0}' and B.mo_id='{1}'",
                    objModel.order_id, objModel.mo_id);
                    dtMo = clsConErp.ExecuteSqlReturnDataTable(strsql);
                    if (dtMo.Rows.Count > 0)
                    {
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "table_head", dtMo.Rows[0]["table_head"].ToString());//款號
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "customer_goods", dtMo.Rows[0]["customer_goods"].ToString());//客產品編號
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "customer_color_id", dtMo.Rows[0]["customer_color_id"].ToString());//客產品顏色
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "customer_size", dtMo.Rows[0]["customer_size"].ToString());//客人Size
                    }
                }
            }
        }         
        //手寫單頁面代碼 =============END=============

        private void Print()
        {
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("沒有要列印的數據!","提示信息");
                return;
            }
            string strSql =
            @"Select A.id,A.issues_date,A.it_customer,A.customer_name,A.customer_address,A.s_address,A.contact_info,A.post_info,A.remark,
            B.sequence_id,B.mo_id,B.goods_id,B.goods_name,B.table_head,B.customer_goods,B.customer_color_id,B.customer_size,B.issues_qty,B.issues_unit,B.remark
            From dbo.custom_delivery_mostly A with(nolock),dbo.custom_delivery_details B with(nolock)
            WHERE A.id=B.id ";
            strSql += " And A.id='" + txtID.Text + "'"+ " Order by A.id,B.sequence_id";
            DataTable dtReprot = clsPublicOfCF01.GetDataTable(strSql);
            using (xrCustomDelivery myReport1 = new xrCustomDelivery() { DataSource = dtReprot })
            {
                myReport1.CreateDocument();
                myReport1.PrintingSystem.ShowMarginsWarning = false;
                myReport1.ShowPreviewDialog();
            }
        }


	}
}
