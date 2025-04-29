//*************************************************
//**此畫面C組阿華使用，將手寫單轉換成VAT送貨單格式
//*************************************************
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
using DevExpress.XtraReports.UI;
using cf01.Reports;

namespace cf01.Forms
{
	public partial class frmDeliveryBillVat : Form
	{
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態
		public static string str_language = "0";		
		public bool save_flag;
        public string strArea = "";
        string flag_pdf = "";
        private bool flag_remove;

		DataTable dtMostly = new DataTable();
		DataTable dtDetails = new DataTable();        
		DataTable dtTempDel = new DataTable();        
        DataTable dtFind_Date = new DataTable();

        private List<soinvoice_details_geo> lsModel = new List<soinvoice_details_geo>();

		public frmDeliveryBillVat()
		{
			InitializeComponent();

            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

			str_language = DBUtility._language;
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();
		}

		private void frmDeliveryBillVat_Load(object sender, EventArgs e)
		{			
			//customer*
            clsDeliveryBill.SetCustomer(it_customer);
            //類型*           
            DataTable dtType = new DataTable();
            dtType.Columns.Add("id", System.Type.GetType("System.String"));
            dtType.Columns.Add("cdesc", System.Type.GetType("System.String"));
            dtType.NewRow();
            DataRow rows = dtType.NewRow();
            rows["id"] = "VDI";
            rows["cdesc"] = "東莞送貨單";
            dtType.Rows.Add(rows);
            rows = dtType.NewRow();
            rows["id"] = "VDJ";
            rows["cdesc"] = "JX送貨單";
            dtType.Rows.Add(rows);
            type.Properties.DataSource = dtType;
            type.Properties.ValueMember = "id";
            type.Properties.DisplayMember = "cdesc";
            //組別資料*
            DataTable dtSales_Group = clsSales_group.Get_sales_group();
            group_number.Properties.DataSource = dtSales_Group;
            group_number.Properties.ValueMember = "id";
            group_number.Properties.DisplayMember = "id";
            //目的港口*
            clsDeliveryBill.SetPort(ap_id);
            //裝運單方式*
            clsDeliveryBill.SetShipping(sm_id);
            //銷售員*
            clsDeliveryBill.SetMerchandiser(cd_seller);   
          
            //數量單位
            DataTable dtUnit = clsConErp.GetDataTable(@"SELECT unit_code AS id,'' as cdesc From it_coding where within_code='0000' and id='*' and basic_unit='PCS'");
            clSendQtyUnit.DataSource = dtUnit;
            clSendQtyUnit.ValueMember = "id";
            clSendQtyUnit.DisplayMember = "id";
            ////單價單位
            //clPrice_unit.DataSource = dtUnit;
            //clPrice_unit.ValueMember = "id";
            //clPrice_unit.DisplayMember = "id";
            //倉位
            DataTable dtWH = clsConErp.GetDataTable(@"SELECT id,id+' ' +name as cdesc FROM cd_productline WHERE within_code='0000' AND storehouse_group='DG' AND type ='01' AND state not in('V','2')");
            clLocationId.DataSource = dtWH;
            clLocationId.ValueMember = "id";
            clLocationId.DisplayMember = "cdesc";  
            
            //*出貨來源
            DataTable dtSeparate = new DataTable();         
            dtSeparate.Columns.Add("id", System.Type.GetType("System.String"));
            dtSeparate.Columns.Add("cdesc", System.Type.GetType("System.String"));
            dtSeparate.NewRow();
            DataRow row = dtSeparate.NewRow();
            row["id"] = "1";
            row["cdesc"] = "1.手動輸入";
            dtSeparate.Rows.Add(row);
            row = dtSeparate.NewRow();
            row["id"] = "2";
            row["cdesc"] = "2.銷售訂單";
            dtSeparate.Rows.Add(row);
            separate_issues.Properties.DataSource = dtSeparate;
            separate_issues.Properties.ValueMember = "id";
            separate_issues.Properties.DisplayMember = "cdesc";

            //*狀態
            DataTable dtSate = new DataTable();
            dtSate.Columns.Add("id", System.Type.GetType("System.String"));
            dtSate.Columns.Add("cdesc", System.Type.GetType("System.String"));
            dtSate.NewRow();
            row = dtSate.NewRow();
            row["id"] = "0";
            row["cdesc"] = "未批準";
            dtSate.Rows.Add(row);
            row = dtSate.NewRow();
            row["id"] = "1";
            row["cdesc"] = "已批準";
            dtSate.Rows.Add(row);
            row = dtSate.NewRow();
            row["id"] = "2";
            row["cdesc"] = "註銷";
            dtSate.Rows.Add(row);
            row = dtSate.NewRow();
            row["id"] = "7";
            row["cdesc"] = "送貨完成";
            dtSate.Rows.Add(row);
            row = dtSate.NewRow();
            row["id"] = "H";
            row["cdesc"] = "已開票";           
            dtSate.Rows.Add(row);
            state.Properties.DataSource = dtSate;
            state.Properties.ValueMember = "id";
            state.Properties.DisplayMember = "cdesc";

			//生成明細表
            dtDetails = clsConErp.GetDataTable(@"Select Cast(Isnull(shipment_suit,'0') as bit) AS shipment_suit,*,space(12) as delivery_id,sequence_id as seq From dbo.so_issues_details Where 1=0");         
			gridControl1.DataSource = dtDetails;
			//臨時項目刪除表結構
			dtTempDel = dtDetails.Clone();
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            txtDat1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtDat2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtCust_id1.Text = "DD-G0245";
            txtCust_id2.Text = "DD-G0245";
            cmbReport.SelectedIndex = 0;
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
			AddNewItem();
		}

		private void BTNITEMDEL_Click(object sender, EventArgs e)
		{
			if (gridView1.RowCount == 0)
			{
				return;
			}
			DialogResult result = MessageBox.Show("是否刪除當前明細資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int curRow = gridView1.FocusedRowHandle;
				//將當前行刪除幷加到臨時表中
				DataRow newRow = dtTempDel.NewRow();
				newRow["id"] = id.Text;				
                newRow["sequence_id"] = gridView1.GetRowCellDisplayText(curRow, "sequence_id");
                newRow["mo_id"] = gridView1.GetRowCellDisplayText(curRow, "mo_id");
                newRow["goods_id"] = gridView1.GetRowCellDisplayText(curRow, "goods_id");
                newRow["order_id"] = gridView1.GetRowCellDisplayText(curRow, "order_id");
                newRow["so_ver"] = gridView1.GetRowCellDisplayText(curRow, "so_ver");
                newRow["so_sequence_id"] = gridView1.GetRowCellDisplayText(curRow, "so_sequence_id");
				dtTempDel.Rows.Add(newRow);
				gridView1.DeleteRow(curRow);//移走當前行
			}
		}

		private void BTNSAVE_Click(object sender, EventArgs e)
		{
			remarks.Focus();//Toolscript焦點問題
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

        private void Print()
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("沒有需要列印的數據!", "提示信息");
                return;
            }
            DataTable dtRpt = new DataTable();
            string index = cmbReport.SelectedIndex.ToString();
            if (index != "-1")
            {
                if (index == "0")
                {
                    dtRpt = clsDeliveryBill.GetVatReportDataById(id.Text);
                    xrDgDelivery rpt = new xrDgDelivery() { DataSource = dtRpt };
                    ReportPrint(rpt);
                }
                if (index == "1")
                {
                    //按箱號
                    string boxno = packinglistno.Text;
                    if (string.IsNullOrEmpty(boxno))
                    {
                        MessageBox.Show("注意：主表的箱號為空，沒有需要列印的報表!", "提示信息");
                        return;
                    }
                    dtRpt = clsDeliveryBill.GetVatReportDataByBoxNo(packinglistno.Text);
                    xrDgDelivery2 rpt = new xrDgDelivery2() { DataSource = dtRpt };
                    ReportPrint(rpt);
                }
            }
            else
            {
                MessageBox.Show("注意：請選擇需要列印的報表格式!", "提示信息");
            }
        }

        private void ReportPrint(XtraReport rpt)
        {
            rpt.CreateDocument();
            rpt.PrintingSystem.ShowMarginsWarning = false;
            if (flag_pdf == "")
            {
                rpt.ShowPreviewDialog();
            }
            else
            {
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    Title = "保存EXECL文件",
                    Filter = "PDF文件|*.PDF",
                    FilterIndex = 1
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    rpt.ExportToPdf(FileName);
                    flag_pdf = "";
                    MessageBox.Show("匯出PDF成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BTNFIND_Click(object sender, EventArgs e)
		{
            tabControl1.SelectTab(2);//跳至第三頁
		}

		private void AddNew()  //新增
		{
			mState = "NEW";
			id.Focus();
			SetButtonSatus(false);
            Set_Grid_Status(true);
            SetObjValue.SetEditBackColor(this.tabPage1.Controls, true);
			SetObjValue.ClearObjValue(this.tabPage1.Controls, "1");            
            state.Enabled = false ;
            state.BackColor = System.Drawing.Color.White;
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);
            separate_issues.EditValue = "1";            
            type.EditValue = "VDJ";
            state.EditValue = "0";
            GetID_No();
            issues_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");           
            total_package_num.Text = "0";
			dtDetails.Clear();
			gridControl1.DataSource = dtDetails;          
		}

		private void Edit()  //編輯
		{
			if (id.Text == "")
			{
				return;
			}
            if (state.EditValue.ToString() != "0")
            {
                MessageBox.Show("注意：已批準的單據不可以再編輯!", "提示信息");
                return;
            }
			SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.tabPage1.Controls, true);
			Set_Grid_Status(true);
			mState = "EDIT";

			id.Properties.ReadOnly = true;
			id.BackColor = System.Drawing.Color.White;
			type.Enabled = false;
            type.BackColor = System.Drawing.Color.White;
            separate_issues.Enabled = false;
            separate_issues.BackColor = System.Drawing.Color.White;
            state.Enabled = false;
            state.BackColor = System.Drawing.Color.White;			
            it_customer.Enabled = false;
            it_customer.BackColor = System.Drawing.Color.White;
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
            BTNTOPDF.Enabled = _flag;

            //btnShipping.Enabled = !_flag;
            //btnTearm.Enabled = !_flag;

            //btnShipping.Enabled = !_flag;
            //btnTearm.Enabled = !_flag;


            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
		}

		private void Set_Grid_Status(bool _flag) // 表格可編號否
		{
			//false--不可編輯;true--可以編輯
			gridView1.OptionsBehavior.Editable = _flag;			                 
		}

		private void Delete() //刪除當前行
		{
			if (string.IsNullOrEmpty(id.Text))
			{
				return;
			}
            if (state.EditValue.ToString() != "0")
            {
                return;
            }			
			DialogResult result = MessageBox.Show("此操作將刪除主表及明細中的資料,請謹慎操作!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{				
                const string sql_del = @"DELETED FROM dbo.so_issues_mostly WHERE within_code='0000' AND id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);//改回直接操作GEO
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_del;//刪除主檔
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@id", id.Text.Trim());
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
		private void AddNewItem()
		{
			if (!String.IsNullOrEmpty(id.Text.Trim())) // 有內容
			{
				if (Check_Details_Valid())
				{
					return;
				}
				Set_Grid_Status(true);
				gridView1.AddNewRow();//新增
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id", id.Text);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ver", txtVer.Text);
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sequence_id", (gridView1.RowCount + 1).ToString("0000")+"h");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "issues_unit", "SET");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sec_unit", "KG");
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "is_free", false);

				ColumnView view = (ColumnView)gridView1;//初始單元格焦點
				view.FocusedColumn = view.Columns["mo_id"];
				view.Focus();                
			}
			else
			{
				MessageBox.Show("主檔編號不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id.Focus();
			}
		}


		private bool Check_Details_Valid() //檢查明細資料的有效性
		{
			//測試項目必須有輸入
			bool _flag = false;
			if (gridView1.RowCount > 0)
			{
                remarks.Focus();
				//因toolStrip控件焦點問題
				//設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，防止取到的值爲空
				// ColumnView view = (ColumnView)gridView1 ;
				// view.FocusedColumn = view.Columns["test_item_id"];    
				int curRow = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					curRow = gridView1.GetRowHandle(i);
                    if (string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "mo_id")) || string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "goods_id")))
					{
						_flag = true;
						MessageBox.Show("頁數或貨品編碼不可以爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)gridView1;
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
            SetObjValue.SetEditBackColor(tabPage1.Controls, false);
            SetObjValue.ClearObjValue(tabPage1.Controls, "2");
			Set_Grid_Status(false);
			dtTempDel.Clear();
			dtDetails.Clear();
			gridControl1.DataSource = dtDetails;           

			mState = "";			
			if (!string.IsNullOrEmpty(mID))
			{
				Find_doc(mID);
			}
		}

		private void Find_doc(string temp_id) //主檔非新增的情況下，保存或取消時重新查出資料
		{
			if (!String.IsNullOrEmpty(temp_id))
			{               
                string sql_h = String.Format(
                        @"SELECT * FROM dbo.so_issues_mostly WITH(nolock) 
						WHERE within_code='0000' AND id ='{0}' AND state not in ('2','V')", temp_id);
                string sql_details = string.Format(
                        @"Select Cast(Isnull(shipment_suit,'0') as  bit) AS shipment_suit,*,space(12) as delivery_id,space(5) as seq 
                        From dbo.so_issues_details with(nolock) Where within_code='0000' And id='{0}'", temp_id);               
                dtDetails = clsConErp.GetDataTable(sql_details); 
                dtMostly = clsConErp.GetDataTable(sql_h);
                if (dtMostly.Rows.Count > 0)
                    Set_Master_Data(dtMostly);
				else
				{
					SetObjValue.ClearObjValue(this.Controls, "2");
					return;
				}
				dtDetails.Clear();
                dtDetails = clsConErp.GetDataTable(sql_details);
				gridControl1.DataSource = dtDetails;
				mID = id.Text;//保存臨時的ID號               
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
                string user_id = DBUtility._user_id;
                if (mState == "NEW")
                {
                    string strSql = string.Format("Select '1' FROM dbo.so_issues_mostly WHERE within_code='0000' and id='{0}'", id.Text.Trim());
                    if (clsConErp.ExecuteSqlReturnObject(strSql) != "")
                    {
                        GetID_No();//如已存在編號則重取最大單據編號
                    }                   
                } 
                string sql_i =
                @"INSERT INTO dbo.so_issues_mostly
                (within_code,id,issues_date,issues_type,it_customer,name,address,phone,fax,linkman,l_phone,ap_id,sm_id,port_id,separate_issues,
                update_count,transfers_state,remark,state,department_id,marks,cd_seller,group_number,receiptor,type,servername,
                fake_name,fake_address,packinglistno,box_no,total_package_num,package_unit,create_by,create_date) VALUES
				('0000',@id,@issues_date,@issues_type,@it_customer,@name,@address,@phone,@fax,@linkman,@l_phone,@ap_id,@sm_id,@port_id,@separate_issues,
                @update_count,@transfers_state,@remark,@state,@department_id,@marks,@cd_seller,@group_number,@receiptor,@type,@servername,@fake_name,
                @fake_address,@packinglistno,@box_no,@total_package_num,@package_unit,@user_id,getdate())";
                string sql_u =
                @"Update so_issues_mostly WITH(ROWLOCK)
                SET issues_date=@issues_date,issues_type=@issues_type,it_customer=@it_customer,name=@name,address=@address,phone=@phone,fax=@fax,linkman=@linkman,
                l_phone=@l_phone,ap_id=@ap_id,sm_id=@sm_id,port_id=@port_id,separate_issues=@separate_issues,update_count=@update_count,transfers_state=@transfers_state,
                remark=@remark,state=@state,department_id=@department_id,marks=@marks,cd_seller=@cd_seller,group_number=@group_number,receiptor=@receiptor,type=@type,
                servername=@servername,fake_name=@fake_name,fake_address=@fake_address,packinglistno=@packinglistno,box_no=@box_no,total_package_num=@total_package_num,
                package_unit=@package_unit,update_by=@user_id,update_date=getdate()
                WHERE within_code='0000' And id=@id";

                string sql_bill_code_i =
                @"Insert Into sys_bill_max_separate(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5)
                Values('0000','SA02',@year_month,@bill_code,@bill_text1,'','','','')";
                string sql_bill_code_u =
                @"UPDATE sys_bill_max_separate SET bill_code=@bill_code WHERE within_code='0000' AND bill_id='SA02' AND year_month=@year_month AND bill_text1=@bill_text1";
                
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2); //改爲GEO
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
                        myCommand.Parameters.AddWithValue("@id", id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@issues_type", "0");
                        myCommand.Parameters.AddWithValue("@issues_date", issues_date.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@it_customer", it_customer.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@name", name.Text);
                        myCommand.Parameters.AddWithValue("@address", address.Text);
                        myCommand.Parameters.AddWithValue("@phone", l_phone.Text);
                        myCommand.Parameters.AddWithValue("@fax", fax.Text);
                        myCommand.Parameters.AddWithValue("@linkman", linkman.Text);
                        myCommand.Parameters.AddWithValue("@l_phone", l_phone.Text);
                        myCommand.Parameters.AddWithValue("@ap_id", ap_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@sm_id", sm_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@port_id", port_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@separate_issues", separate_issues.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@update_count", "1");
                        myCommand.Parameters.AddWithValue("@transfers_state", "0");
                        myCommand.Parameters.AddWithValue("@state", "0");
                        myCommand.Parameters.AddWithValue("@remark", remarks.Text);
                        myCommand.Parameters.AddWithValue("@department_id", department_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@marks", marks.Text);
                        myCommand.Parameters.AddWithValue("@cd_seller", cd_seller.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@group_number", group_number.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@receiptor", receiptor.Text);
                        myCommand.Parameters.AddWithValue("@type", type.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@servername", "hkserver.cferp.dbo");
                        myCommand.Parameters.AddWithValue("@fake_name", name.Text);
                        myCommand.Parameters.AddWithValue("@fake_address", address.Text);
                        myCommand.Parameters.AddWithValue("@packinglistno", packinglistno.Text);
                        myCommand.Parameters.AddWithValue("@box_no", box_no.Text);
                        myCommand.Parameters.AddWithValue("@total_package_num", total_package_num.Text);
                        myCommand.Parameters.AddWithValue("@package_unit", package_unit.Text);                        
                        myCommand.Parameters.AddWithValue("@user_id", user_id);                                           
						myCommand.ExecuteNonQuery();

                        //更新最大單據編號
                        if (mState == "NEW")
                        {                            
                            string sql_bill_f,strID, yymm, bill_type;
                            strID = id.Text.Trim();//VDJ2409000091
                            yymm = strID.Substring(3, 4); //2409                            
                            bill_type = strID.Substring(0, 3);
                            sql_bill_f = string.Format(
                            @"Select '1' FROM sys_bill_max_separate WHERE within_code='0000' and bill_id='SA02' AND year_month='{0}' AND bill_text1='{1}'", yymm, bill_type);
                            if (clsConErp.ExecuteSqlReturnObject(sql_bill_f) != "")
                                myCommand.CommandText = sql_bill_code_u;
                            else                            
                                myCommand.CommandText = sql_bill_code_i;                            
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@year_month", yymm);
                            myCommand.Parameters.AddWithValue("@bill_code", strID);
                            myCommand.Parameters.AddWithValue("@bill_text1", bill_type);
                            myCommand.ExecuteNonQuery();
                        }

                        //處理【項目刪除】刪除明細資料
                        string sql_item_d, sql_update_flag; 
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            //刪除明細
                            sql_item_d = @"DELETE FROM dbo.so_issues_details WHERE within_code='0000' AND id=@id and sequence_id=@sequence_id and mo_id=@mo_id and goods_id=@goods_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", id.Text.Trim());                            
                            myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());
                            myCommand.Parameters.AddWithValue("@mo_id", dtTempDel.Rows[i]["mo_id"].ToString());
                            myCommand.Parameters.AddWithValue("@goods_id", dtTempDel.Rows[i]["goods_id"].ToString());
                            myCommand.ExecuteNonQuery();                            
                            //還原手寫單標識
                            sql_update_flag = string.Format( 
                            @"UPDATE so_invoice_details SET state='0' WHERE within_code='0000' AND mo_id='{0}' AND goods_id='{1}' AND order_id='{2}' and so_ver='{3}' and so_sequence_id='{4}'", 
                            dtTempDel.Rows[i]["mo_id"].ToString(),dtTempDel.Rows[i]["goods_id"].ToString(),dtTempDel.Rows[i]["order_id"].ToString(),
                            dtTempDel.Rows[i]["so_ver"].ToString(), dtTempDel.Rows[i]["so_sequence_id"].ToString());
                            clsPublicOfCF01.ExecuteSqlUpdate(sql_update_flag);
                        }
                                                
                        //保存明細
                        int curRow;
                        string rowStatus="";
						if (gridView1.RowCount > 0)
						{                           
                            string sql_item_i =
                            @"INSERT INTO dbo.so_issues_details
                            (within_code,id,sequence_id,order_id,so_sequence_id,so_ver,goods_id,customer_goods,goods_name,issues_unit,basic_unit,unit_rate, 
                            issues_qty,check_qty,eligible_qty,unqualified_qty,invoice_qty,use_invoice,order_issues_qty,return_qty,exchange_rate,
                            inner_carton,nwt,gross_wt,ii_location,carton_code,deliver_date,transfers_state,remark,contract_cid,present_qty,fact_qty,sec_qty,
                            sec_unit,lot_no,mo_id,shipment_suit,piece_num,state,obligate_mo_id,package_no,pcs_ctn,cube_ctn,cbm_size,cuft_size,acus_id) VALUES
                            ('0000',@id,@sequence_id,@order_id,@so_sequence_id,@so_ver,@goods_id,@customer_goods,@goods_name,@issues_unit,@basic_unit,@unit_rate, 
                            @issues_qty,@check_qty,@eligible_qty,@unqualified_qty,@invoice_qty,@use_invoice,@order_issues_qty,@return_qty,@exchange_rate,
                            @inner_carton,@nwt,@gross_wt,@ii_location,@carton_code,Case When LEN(@deliver_date)=0 Then null Else @deliver_date End,
                            @transfers_state,@remark,@contract_cid,@present_qty,@fact_qty,@sec_qty,
                            @sec_unit,@lot_no,@mo_id,@shipment_suit,@piece_num,@state,@obligate_mo_id,@package_no,@pcs_ctn,@cube_ctn,@cbm_size,@cuft_size,@acus_id)";
                            string sql_item_u =
                            @"Update dbo.so_issues_details 
                            SET order_id=@order_id,so_sequence_id=@so_sequence_id,so_ver=Case When Len(@so_sequence_id)=0 Then null Else @so_ver End,
                            goods_id=@goods_id,customer_goods=@customer_goods,goods_name=@goods_name,
                            issues_unit=@issues_unit,basic_unit=@basic_unit,unit_rate=@unit_rate,issues_qty=@issues_qty,check_qty=@check_qty,eligible_qty=@eligible_qty,
                            unqualified_qty=@unqualified_qty,invoice_qty=@invoice_qty,use_invoice=@use_invoice,order_issues_qty=@order_issues_qty,return_qty=@return_qty,
                            exchange_rate=@exchange_rate,inner_carton=@inner_carton,nwt=@nwt,gross_wt=@gross_wt,ii_location=@ii_location,
                            carton_code=@carton_code,deliver_date=Case When LEN(@deliver_date)=0 Then null Else @deliver_date End,transfers_state=@transfers_state,
                            remark=@remark,contract_cid=@contract_cid,present_qty=@present_qty,fact_qty=@fact_qty,sec_qty=@sec_qty,sec_unit=@sec_unit,lot_no=@lot_no,
                            mo_id=@mo_id,shipment_suit=@shipment_suit,piece_num=@piece_num,state=@state,obligate_mo_id=@obligate_mo_id,package_no=@package_no,
                            pcs_ctn=@pcs_ctn,cube_ctn=@cube_ctn,cbm_size=@cbm_size,cuft_size=@cuft_size,acus_id=@acus_id
                            Where within_code='0000' And id=@id And sequence_id=@sequence_id";
                            decimal decQty = decimal.Parse("0.00");
                            int so_ver = 0;
                            string strDeliverDate = "", strSosequenceId="";
                            for (int i = 0; i < gridView1.RowCount; i++)
							{
                                curRow = gridView1.GetRowHandle(i);
                                //gridView1.AddNewRow();//新增必須初始貨當前單元格焦點
                                //否則rowStatus取不到狀態值
                                rowStatus = gridView1.GetDataRow(curRow).RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                        myCommand.CommandText = sql_item_i;
                                    else
                                        myCommand.CommandText = sql_item_u;
                                    myCommand.Parameters.Clear();                                    
                                    myCommand.Parameters.AddWithValue("@id", id.Text.Trim());//*                                 
                                    myCommand.Parameters.AddWithValue("@sequence_id", gridView1.GetRowCellValue(curRow, "sequence_id").ToString());//*
                                    myCommand.Parameters.AddWithValue("@order_id", gridView1.GetRowCellValue(curRow, "order_id").ToString());//*  
                                    strSosequenceId = gridView1.GetRowCellValue(curRow, "so_sequence_id").ToString();
                                    strSosequenceId = string.IsNullOrEmpty(strSosequenceId) ? "" : strSosequenceId;
                                    myCommand.Parameters.AddWithValue("@so_sequence_id", strSosequenceId);//*
                                    if (string.IsNullOrEmpty(gridView1.GetRowCellValue(curRow, "so_ver").ToString()))
                                        so_ver = 0;
                                    else
                                        so_ver = int.Parse(gridView1.GetRowCellValue(curRow, "so_ver").ToString());
                                    myCommand.Parameters.AddWithValue("@so_ver", so_ver);//*                                   
                                    myCommand.Parameters.AddWithValue("@goods_id", gridView1.GetRowCellValue(curRow, "goods_id").ToString());//*
                                    myCommand.Parameters.AddWithValue("@goods_name", gridView1.GetRowCellValue(curRow, "goods_name").ToString());//*
                                    myCommand.Parameters.AddWithValue("@customer_goods", gridView1.GetRowCellValue(curRow, "customer_goods").ToString());//*
                                    myCommand.Parameters.AddWithValue("@issues_unit", gridView1.GetRowCellValue(curRow, "issues_unit").ToString());//*
                                    myCommand.Parameters.AddWithValue("@basic_unit", "SET");
                                    myCommand.Parameters.AddWithValue("@unit_rate", 1);
                                    myCommand.Parameters.AddWithValue("@issues_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "issues_qty").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@check_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@eligible_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@unqualified_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@invoice_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@use_invoice", 0);
                                    myCommand.Parameters.AddWithValue("@order_issues_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@return_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@exchange_rate", 1);
                                    myCommand.Parameters.AddWithValue("@inner_carton", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "inner_carton").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@nwt", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "nwt").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@gross_wt", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "gross_wt").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@ii_location", gridView1.GetRowCellValue(curRow, "ii_location").ToString());//*
                                    myCommand.Parameters.AddWithValue("@carton_code", gridView1.GetRowCellValue(curRow, "ii_location").ToString());//*
                                    strDeliverDate = gridView1.GetRowCellValue(curRow, "deliver_date").ToString();
                                    strDeliverDate = string.IsNullOrEmpty(strDeliverDate) ? "" : strDeliverDate;
                                    myCommand.Parameters.AddWithValue("@deliver_date", strDeliverDate);//*
                                    myCommand.Parameters.AddWithValue("@transfers_state", "0");
                                    myCommand.Parameters.AddWithValue("@remark", gridView1.GetRowCellValue(curRow, "remark").ToString());//*
                                    myCommand.Parameters.AddWithValue("@contract_cid", gridView1.GetRowCellValue(curRow, "contract_cid").ToString());//*
                                    myCommand.Parameters.AddWithValue("@present_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@fact_qty", decQty);
                                    myCommand.Parameters.AddWithValue("@sec_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "sec_qty").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@sec_unit", gridView1.GetRowCellValue(curRow, "sec_unit").ToString());//*
                                    myCommand.Parameters.AddWithValue("@lot_no", gridView1.GetRowCellValue(curRow, "lot_no").ToString());//*
                                    myCommand.Parameters.AddWithValue("@mo_id", gridView1.GetRowCellValue(curRow, "mo_id").ToString());//*                                   
                                    if (gridView1.GetRowCellValue(curRow, "shipment_suit").ToString() == "True")
                                        myCommand.Parameters.AddWithValue("@shipment_suit", "1");//*
                                    else
                                        myCommand.Parameters.AddWithValue("@shipment_suit", "0");
                                    myCommand.Parameters.AddWithValue("@piece_num", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "piece_num").ToString()));//* 
                                    myCommand.Parameters.AddWithValue("@package_no", gridView1.GetRowCellValue(curRow, "package_no").ToString());//*
                                    myCommand.Parameters.AddWithValue("@state", "0");
                                    myCommand.Parameters.AddWithValue("@obligate_mo_id", gridView1.GetRowCellValue(curRow, "mo_id").ToString());//*
                                    myCommand.Parameters.AddWithValue("@pcs_ctn", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "pcs_ctn").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@cube_ctn", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "cube_ctn").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@cbm_size", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "cbm_size").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@cuft_size", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "cuft_size").ToString()));//*
                                    myCommand.Parameters.AddWithValue("@acus_id", gridView1.GetRowCellValue(curRow, "ACUS_ID").ToString());//*

                                    myCommand.ExecuteNonQuery();
                                }
							}//--end of for 
                        } //--end of if (gridView1.RowCount > 0)

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
            SetObjValue.SetEditBackColor(tabPage1.Controls, false);
			Set_Grid_Status(false);
			mState = "";			
			dtTempDel.Clear();

            //更新過帳標識
            if (save_flag)
            {
                int cur_row;
                string sql_u, delivery_id, seq;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    cur_row = gridView1.GetRowHandle(i);
                    if (gridView1.GetRowCellValue(cur_row, "delivery_id").ToString() != "")
                    {
                        delivery_id = gridView1.GetRowCellValue(cur_row, "delivery_id").ToString();
                        seq = gridView1.GetRowCellValue(cur_row, "seq").ToString();
                        sql_u = string.Format("Update so_invoice_details Set state='1' Where within_code='0000' And id='{0}' And sequence_id='{1}'", delivery_id, seq);
                        clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                    }
                }
            }
			if (save_flag)
			{
				Find_doc(id.Text);                
				MessageBox.Show("當前數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
                MessageBox.Show("當前數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private bool Save_Before_Valid() //保存前檢查主檔資料有效性
		{
            if (id.Text == "" || issues_date.Text == "" || separate_issues.EditValue.ToString() == ""|| it_customer.EditValue.ToString() == "" 
                || type.EditValue.ToString() == "" || group_number.EditValue.ToString() =="" || cd_seller.EditValue.ToString() == ""  )
            {	
				MessageBox.Show("編號、出貨單日期、出貨來源、客戶編號、類型、組別、銷售員不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else			
				return true;
		}

		//private bool Valid_Doc() //主建是否已存在
		//{
		//	bool flag;
		//	string doc = id.Text.Trim();
        //          string strSql = String.Format("Select '1' FROM dbo.so_issues_mostly WHERE within_code='0000' and id='{0}'", doc);			
        //          DataTable dt = clsConErp.GetDataTable(strSql);
		//	if (dt.Rows.Count > 0)
		//	{
		//		MessageBox.Show("當前發票編號已存在" + String.Format("【{0}】.", doc), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		//		flag = true;
		//	}
		//	else			
		//		flag = false;			
		//	dt.Dispose();
		//	return flag;
		//}

		public static string Get_Details_Seq(string _id) //取明細最大序號
		{
			DataTable dtMaxseq = new DataTable();
            dtMaxseq = clsConErp.GetDataTable(String.Format("SELECT MAX(sequence_id) as seq_id FROM dbo.so_invoice_details with(nolock) WHERE within_code='0000' AND id ='{0}'", _id));

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
			id.Text = dt.Rows[0]["id"].ToString();            
            if (string.IsNullOrEmpty(dt.Rows[0]["issues_date"].ToString()))
                issues_date.EditValue = "";
            else
                issues_date.EditValue = Convert.ToDateTime(dt.Rows[0]["issues_date"].ToString()).ToString("yyyy-MM-dd");
            separate_issues.EditValue = dt.Rows[0]["separate_issues"].ToString();
            state.EditValue = dt.Rows[0]["state"].ToString();
            it_customer.EditValue = dt.Rows[0]["it_customer"].ToString();
            type.EditValue = dt.Rows[0]["type"].ToString();
            group_number.EditValue = dt.Rows[0]["group_number"].ToString();
            transport_id.Text = dt.Rows[0]["transport_id"].ToString();
            name.Text = dt.Rows[0]["name"].ToString();
            address.Text = dt.Rows[0]["address"].ToString();//??
            fax.Text = dt.Rows[0]["fax"].ToString();
            chauffeur.Text = dt.Rows[0]["chauffeur"].ToString();
            receiptor.Text = dt.Rows[0]["receiptor"].ToString();
            package_num.Text = dt.Rows[0]["package_num"].ToString();
            linkman.Text = dt.Rows[0]["linkman"].ToString();
            l_phone.Text = dt.Rows[0]["l_phone"].ToString();
            ap_id.EditValue = dt.Rows[0]["ap_id"].ToString();
            sm_id.EditValue = dt.Rows[0]["sm_id"].ToString();
            department_id.EditValue = dt.Rows[0]["department_id"].ToString();
            cd_seller.EditValue = dt.Rows[0]["cd_seller"].ToString();
            total_package_num.Text = dt.Rows[0]["total_package_num"].ToString();
            package_unit.Text = dt.Rows[0]["package_unit"].ToString();
            issues_by.Text = dt.Rows[0]["issues_by"].ToString();
            port_id.EditValue = dt.Rows[0]["port_id"].ToString();
            packinglistno.Text = dt.Rows[0]["packinglistno"].ToString();
            box_no.Text = dt.Rows[0]["box_no"].ToString();
            marks.Text = dt.Rows[0]["marks"].ToString();
            remarks.Text = dt.Rows[0]["marks"].ToString();

            check_by.Text = dt.Rows[0]["check_by"].ToString();
            check_date.Text = dt.Rows[0]["check_date"].ToString();           
            create_by.Text = dt.Rows[0]["create_by"].ToString();
            create_date.Text = dt.Rows[0]["create_date"].ToString();
            update_by.Text = dt.Rows[0]["update_by"].ToString();
            update_date.Text = dt.Rows[0]["update_date"].ToString();            
		}

		private void id_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(id.Text))
			{
				if (mState == "") //流覽模式
				{
					Find_doc(id.Text);
				}
			}
		}
   
        private void frmDeliveryBillVat_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.GC.Collect();
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void clAc_EditValueChanged(object sender, EventArgs e)
        {
            //2024/09/21 cancel
            //LookUpEdit objItem = (LookUpEdit)sender;           
            //string strAc_id = objItem.EditValue.ToString();
            //int indexSelect = clAc.GetDataSourceRowIndex("id", strAc_id);
            //string strcdesc = clAc.GetDataSourceValue("cdesc", indexSelect).ToString();            
            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "name", strcdesc);
        }
      
        private void type_Leave(object sender, EventArgs e)
        {
            GetID_No();
        }

        /// <summary>
        /// 取單據序號
        /// </summary>
        private void GetID_No()
        {
            if (mState != "")
            {              
                string billType = type.EditValue.ToString();//VDI,VDJ
                if (billType != "")
                {
                    string sql = @"Select SUBSTRING(CONVERT(varchar(20),GETDATE(),111),3,2)+SUBSTRING(CONVERT(varchar(20),GETDATE(),111),6,2) AS yy_mm";
                    string strYm = clsConErp.ExecuteSqlReturnObject(sql).Trim();//2409 
                    sql = string.Format(
                    @"SELECT CAST(substring(bill_code,8,6) as int)+1 As bill_code FROM sys_bill_max_separate 
                    WHERE within_code='0000' AND bill_id='SA02' And year_month='{0}' AND bill_text1='{1}'", strYm, billType);
                    DataTable dt = clsConErp.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {                        
                        id.Text = billType + strYm.Trim() + (int.Parse(dt.Rows[0]["bill_code"].ToString())).ToString("000000"); //--VDJ2409000090
                    }
                    else
                    {
                        id.Text = String.Format("{0}{1}000001", billType, strYm.Trim());
                    }
                }
                else
                    id.Text = "";
            } 
        }
       
        /// <summary>
        /// 當明細資料為第一條記錄時，添加主檔資料
        /// </summary>
        private void Add_Cust_info()
        {
            if (mState != "")
            {
                if (gridView1.RowCount == 1)
                {
                    string order_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "order_id").ToString();
                    if (string.IsNullOrEmpty(order_id))
                    {
                        return;
                    }
                    string sql = string.Format(
                    @"SELECT A.it_customer,A.area, A.name as cust_name,A.customer_address,A.s_address,A.linkman,A.l_phone,A.fax,A.email,
                      A.contract_id as po_no,A.merchandiser,A.merchandiser_phone,A.merchandiser_email,A.seller_id,A.m_id,A.m_rate,
                      A.p_id,A.pc_id,A.disc_rate
                    FROM so_order_manage A with(nolock)
                    WHERE A.within_code='0000' and id='{0}' and A.state not in ('2','V')", order_id);//LOC170713029
                    DataTable dt= clsConErp.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        state.EditValue = "0";                       
                        //string mo_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "mo_id").ToString();
                        //出貨來源
                        separate_issues.EditValue = "1";
                        issues_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
                        it_customer.EditValue = dt.Rows[0]["it_customer"].ToString();
                        type.EditValue = "VDJ";//類型
                        group_number.EditValue = "V";
                        linkman.Text = dt.Rows[0]["linkman"].ToString();
                        l_phone.Text = dt.Rows[0]["l_phone"].ToString();
                        fax.Text = dt.Rows[0]["fax"].ToString();
                        cd_seller.EditValue = dt.Rows[0]["seller_id"].ToString();
                        name.Text = dt.Rows[0]["cust_name"].ToString();   //**  
                        address.Text = dt.Rows[0]["s_address"].ToString();                                                
                        GetID_No();
                    }
                }
            }
        }
      
        //東莞VAT送貨單查詢 ==============BEGIN==============
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
            if (txtDat1.Text == "" && txtDat2.Text == ""&&txtCust_id1.Text==""&&txtCust_id2.Text==""&&txtDgid1.Text==""
                &&txtDgid2.Text==""&&txtMo_id1.Text ==""&&txtMo_id2.Text==""&& txtOcNo1.Text ==""&&txtOcNo2.Text=="")
            {
                MessageBox.Show("查詢條件不可以為空!", "提示信息");
                return;
            }
            string sql =
            @"Select A.id,convert(nvarchar(10),issues_date,111) as issues_date,A.it_customer,A.name,B.sequence_id,B.mo_id,B.goods_id,B.goods_name, B.issues_qty,B.issues_unit,B.order_id
            FROM so_issues_mostly A with(nolock),so_issues_details B with(nolock)
            WHERE A.within_code=B.within_code and A.id=B.id and A.within_code='0000' and A.state<>'2' and a.type in('VDI','VDJ')  ";
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
            if (txtMo_id1.Text != "")
                sql += string.Format(" AND B.mo_id>='{0}'", txtMo_id1.Text);
            if (txtMo_id2.Text != "")
                sql += string.Format(" AND B.mo_id<='{0}'", txtMo_id2.Text);
            if (txtOcNo1.Text != "")
                sql += string.Format(" AND B.order_id>='{0}'", txtOcNo1.Text);
            if (txtOcNo2.Text != "")
                sql += string.Format(" AND B.order_id<='{0}'", txtOcNo2.Text);
            sql += " ORDER BY A.id,B.sequence_id";
            dtFind_Date = clsConErp.GetDataTable(sql);
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
                if (id.Text != dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString())
                {
                    id.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString();
                    //txtVer.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["ver1"].Value.ToString();
                    Find_doc(id.Text);
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
            txtDgid2.Text = txtDgid1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id2.Text;
        }

        private void txtOcNo1_Leave(object sender, EventArgs e)
        {
            txtOcNo2.Text = txtOcNo1.Text;
        }
        //東莞D送貨單查詢 ==============END==============


        //手寫單頁面代碼 DGSQL2 =============BEGIN =============
        private void btnQuery_Click(object sender, EventArgs e)
        {            
            string strID = " NOT Like 'L-%'";//C組VAT
            string strSql = string.Format(
            @"SELECT Convert(bit,0) as is_select,Convert(int,SUBSTRING(sequence_id,1,4)) As seq,a.id,Convert(Varchar(20),b.ship_date,111) AS ship_date,
            a.sequence_id,a.mo_id,a.goods_id,a.goods_name,Convert(INT,a.u_invoice_qty) As u_invoice_qty,Convert(INT,a.u_invoice_qty_pcs) As u_invoice_qty_pcs,
            a.goods_unit,Convert(Decimal(18,2),a.sec_qty) As sec_qty,a.sec_unit,a.location_id,a.customer_goods,a.customer_color_id,a.order_id,
            a.so_ver,a.so_sequence_id,a.table_head,a.contract_cid,Convert(INT,a.package_num) As package_num,
            a.box_no,a.remark,a.is_print,a.shipment_suit
            FROM so_invoice_details a with(nolock)
            INNER JOIN so_invoice_mostly b with(nolock) ON a.within_code=b.within_code And a.id=b.id AND a.ver=b.ver
            INNER JOIN so_invoice_mostly_vat c ON b.it_customer=c.it_customer
            WHERE a.within_code='{0}' And a.id {1} And a.state='0'", "0000", strID);
            if (txtFindOc_no.Text != "")
                strSql += string.Format(" And a.order_id='{0}'", txtFindOc_no.Text);
            if (txtFindId.Text != "")
                strSql += string.Format(" And a.id='{0}'", txtFindId.Text);
            if (txtFindMo_id.Text != "")
                strSql += string.Format(" And a.mo_id='{0}'", txtFindMo_id.Text);
            strSql += " ORDER BY a.order_id,a.so_sequence_id";
            DataTable dtIdFind = clsPublicOfCF01.GetDataTable(strSql);            
            gcIdDetails.DataSource = dtIdFind;
            if (dtIdFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的記錄!", "提示信息");
            }
        }
        private void btnImput_Click(object sender, EventArgs e)
        {
           insertToGeo();
        }

        //過帳
        private void insertToGeo()
        {
            if (dgvIdDetails.RowCount == 0)
                return;
            if (!clsDeliveryBill.Check_Add_Popedom("frmDeliveryBillVat"))
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
                MessageBox.Show("請至少要選取一筆手寫單貨單的記錄!", "提示信息");
                return;
            }
            if (MessageBox.Show("確認要進行當前過帳的操作?", "提示信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {               
                return;
            }
            string sql_f = "",lot_no="",strMoId=""; 
            lsModel.Clear();
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    soinvoice_details_geo objModel = new soinvoice_details_geo();
                    objModel.ship_date = dgvIdDetails.GetDataRow(i)["ship_date"].ToString();
                    objModel.id = dgvIdDetails.GetDataRow(i)["id"].ToString().Trim();
                    objModel.mo_id = dgvIdDetails.GetDataRow(i)["mo_id"].ToString().Trim();
                    sql_f = string.Format(
                    @"Select B.mo_id FROM so_issues_mostly A,so_issues_details B 
                    WHERE A.within_code=B.within_code and A.id=B.id and A.type IN('VDI','VDJ') and a.state<>'2' And B.within_code='{0}' And B.mo_id='{1}'", "0000",objModel.mo_id);
                    strMoId = clsConErp.ExecuteSqlReturnObject(sql_f);
                    if (strMoId != "")
                    {
                        //已開過VAT送貨單
                        break;
                    }
                    objModel.goods_id = dgvIdDetails.GetDataRow(i)["goods_id"].ToString().Trim();
                    objModel.goods_name = dgvIdDetails.GetDataRow(i)["goods_name"].ToString().Trim();
                    objModel.sequence_id = dgvIdDetails.GetDataRow(i)["sequence_id"].ToString().Trim();
                    objModel.u_invoice_qty = int.Parse(dgvIdDetails.GetDataRow(i)["u_invoice_qty"].ToString());//送貨數量
                    objModel.goods_unit = dgvIdDetails.GetDataRow(i)["goods_unit"].ToString().Trim();
                    objModel.sec_qty = float.Parse(dgvIdDetails.GetDataRow(i)["sec_qty"].ToString());//重量
                    objModel.sec_unit = dgvIdDetails.GetDataRow(i)["sec_unit"].ToString().Trim();//重量單位
                    objModel.order_id = dgvIdDetails.GetDataRow(i)["order_id"].ToString().Trim();//OC No
                    objModel.location_id = dgvIdDetails.GetDataRow(i)["location_id"].ToString().Trim();
                    objModel.customer_goods = dgvIdDetails.GetDataRow(i)["customer_goods"].ToString();
                    objModel.customer_color_id = dgvIdDetails.GetDataRow(i)["customer_color_id"].ToString();
                    objModel.so_ver = int.Parse(dgvIdDetails.GetDataRow(i)["so_ver"].ToString());//??原始表為int
                    objModel.so_sequence_id = dgvIdDetails.GetDataRow(i)["so_sequence_id"].ToString();
                    objModel.table_head = dgvIdDetails.GetDataRow(i)["table_head"].ToString();//款號
                    objModel.contract_cid = dgvIdDetails.GetDataRow(i)["contract_cid"].ToString();//PO/NO
                    objModel.package_num = int.Parse(dgvIdDetails.GetDataRow(i)["package_num"].ToString());//包數
                    objModel.box_no = dgvIdDetails.GetDataRow(i)["box_no"].ToString();//箱號
                    objModel.remark = dgvIdDetails.GetDataRow(i)["remark"].ToString();
                    objModel.is_print = dgvIdDetails.GetDataRow(i)["is_print"].ToString() == "N" ? "N" : "Y";
                    if (dgvIdDetails.GetDataRow(i)["shipment_suit"].ToString() == "1" || dgvIdDetails.GetDataRow(i)["shipment_suit"].ToString() == "Y")
                        objModel.shipment_suit = "1";
                    else
                        objModel.shipment_suit = "0";                    
                    sql_f =string.Format(
                    @"Select lot_no From st_details_lot Where within_code='0000' and location_id='{0}' and carton_code='{0}' 
                    and goods_id='{1}' and mo_id='{2}' and qty>0 ",objModel.location_id, objModel.goods_id, objModel.mo_id);
                    lot_no = clsConErp.ExecuteSqlReturnObject(sql_f);
                    objModel.lot_no = lot_no;
                    lsModel.Add(objModel);
                }
            }
            if (strMoId != "")
            {
                MessageBox.Show(string.Format("注意，頁數：「{0}」已開過VAT送貨單!" + "\n\r\n\r 請返回檢查！", strMoId), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tabControl1.SelectTab(0);//跳至第一頁
            if (mState == "NEW" || mState == "EDIT")//已點擊新增或編號
            {
                Add_Delivery_Data();              
            }
            else
            {
                //瀏覽狀態先摸擬點擊新增或編號再加入新數據
                if (gridView1.RowCount > 0)
                    Edit();
                else               
                    AddNew();                
                Add_Delivery_Data();
            }
            lsModel.Clear();
            //移除選中的行
            flag_remove = false;//避免移除走已添加到明細的記錄時觸發loadOcDgdDetails引起的錯語
            for (int i = dgvIdDetails.RowCount - 1; i >= 0; i--)            
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    flag_remove = true;
                    dgvIdDetails.DeleteRow(i);//移走當前行                      
                    // dtReport.Rows.RemoveAt(i);
                }
            }
            flag_remove = false;
        }   

        //將選中的記錄插入東莞D中
        private void Add_Delivery_Data()
        {
            if (lsModel.Count > 0)
            {
                bool shipment_suit;              
                DataTable dtOther = new DataTable();
                DataTable dtMo = new DataTable();
                gridView1.OptionsBehavior.Editable = true;//可編輯               
                ColumnView view;
                foreach (soinvoice_details_geo objModel in lsModel)
                {
                    gridView1.AddNewRow();//新增
                    view = (ColumnView)gridView1;//初始單元格焦點
                    view.FocusedColumn = view.Columns["mo_id"];
                    view.Focus();

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "order_id", objModel.order_id);//OC No
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "mo_id", objModel.mo_id);
                    if (gridView1.RowCount == 1)
                    {
                        Add_Cust_info();//設置主表   
                    }                    
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id", id.Text);     
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sequence_id", (gridView1.RowCount + 1).ToString("0000") + "h");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "goods_id", objModel.goods_id);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "goods_name", objModel.goods_name);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "contract_cid", objModel.contract_cid);//PO/NO
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "customer_goods", objModel.customer_goods);//客戶產品編號
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "issues_qty", objModel.u_invoice_qty);//出貨數量
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "issues_unit", objModel.goods_unit);//出貨單位
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sec_qty", objModel.sec_qty);//重量
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sec_unit", objModel.sec_unit);//重量單位
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "piece_num", objModel.package_num);//包數 原始表為整數
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "package_no", objModel.box_no);//箱號
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ii_location", objModel.location_id);//倉庫
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "deliver_date", objModel.box_no);//送貨日期
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "order_id", objModel.order_id); //OC NO.
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "apprise_id", "");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "invoice_id", "");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "remark", objModel.remark);//備註
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "delivery_id", objModel.id);//手寫送貨單號
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq", objModel.sequence_id);//手寫送貨單號序號  
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "lot_no", objModel.lot_no); //批號
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "obligate_mo_id", objModel.mo_id);
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "exchange_rate", objModel);
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "is_free", false);
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "customer_color_id", objModel.customer_color_id);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "so_ver", objModel.so_ver);//??原始表為int
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "so_sequence_id", objModel.so_sequence_id);
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "table_head", objModel.table_head);//款號
                    if (objModel.shipment_suit == "1")
                        shipment_suit = true;
                    else
                        shipment_suit = false;
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "shipment_suit", shipment_suit);//套件              
                }
            }
        }

        private void clSelect_EditValueChanged(object sender, EventArgs e)
        {
            dgvIdDetails.CloseEditor();
            int i = dgvIdDetails.FocusedRowHandle;
            if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
            {
                DialogResult result;
                string strInvNo = clsDgdDeliverGoods.Get_Invoice_No(
                    dgvIdDetails.GetDataRow(i)["mo_id"].ToString(),
                    dgvIdDetails.GetDataRow(i)["goods_id"].ToString(),
                    dgvIdDetails.GetDataRow(i)["order_id"].ToString());
                if (mState == "NEW")
                {                    
                    if (strInvNo != "")
                    {
                        result = MessageBox.Show(string.Format("已開過發票：「{0}」" + "\n\r\n\r 當前頁數是否確定要開在另一張新的發票中?", strInvNo), "提示信息",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            dgvIdDetails.SetRowCellValue(i, "is_select", false);
                        }
                    }
                }
                else //EDIT
                {
                    if (strInvNo != "")
                    {
                        if (strInvNo != id.Text)
                        {
                            result = MessageBox.Show(string.Format("已開過發票：「{0}」" + "\n\r\n\r 是否確定將當前頁數添加到另一張新的發票「{1}」中?", strInvNo,id.Text ), "提示信息",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.No)
                            {
                                dgvIdDetails.SetRowCellValue(i, "is_select", false);
                            }
                        }
                    }
                }
            }
        }

        private void dgvIdDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (!flag_remove)
            {
                loadOcDgdDetails(dgvIdDetails.FocusedRowHandle);
            }               
        }

        private void loadOcDgdDetails(int row)
        {
            string ocno = dgvIdDetails.GetRowCellValue(row, "order_id").ToString();
            DataTable dtOc = clsDgdDeliverGoods.loadOcDgdDetails(ocno);
            gcOcDgdDetails.DataSource = dtOc;
        }

        private void packinglistno_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mState == "NEW")
            {
                if (string.IsNullOrEmpty(group_number.EditValue.ToString()))
                {
                    MessageBox.Show("請首先選定負責組別資料!");
                    return;
                }
                string strSalesGroup, strGenNo;
                strSalesGroup = group_number.EditValue.ToString();

                string sql = string.Format(
                @"Select Cast(substring(bill_code,3,8) as int) as bill_code From sys_bill_max with(nolock)
                Where within_code='0000' and bill_id ='SO09' and  bill_text1 ='{0}' ", strSalesGroup);
                DataTable dt = new DataTable();
                dt = clsConErp.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    strGenNo = string.Format("{0}-{1}", strSalesGroup, (int.Parse(dt.Rows[0]["bill_code"].ToString()) + 1).ToString("00000000"));//strSalesGroup + "-" + (int.Parse(dt.Rows[0]["bill_code"].ToString())+1).ToString("00000000");
                    sql = string.Format("Update sys_bill_max Set bill_code='{0}' Where within_code='0000' and bill_id ='SO09' and bill_text1 ='{1}'", strGenNo, strSalesGroup);
                }
                else
                {
                    strGenNo = String.Format("{0}-00000001", strSalesGroup);
                    sql = string.Format("Insert Into sys_bill_max(within_code,bill_id,bill_code,bill_text1) values('0000','SO09','{0}','{1}')", strGenNo, strSalesGroup);
                }
                try
                {
                    clsConErp.ExecuteSqlUpdate(sql);
                    packinglistno.EditValue = strGenNo;
                }
                catch (Exception ex)
                {
                    packinglistno.EditValue = "";
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void it_customer_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                if (it_customer.EditValue.ToString() != "")
                {
                    DataTable dtCustomer = clsConErp.GetDataTable(
                    string.Format(@"Select top 1 a.id,a.name,b.s_address,b.linkman,b.phone,b.fax From it_customer a, it_shipment_address b
                    Where a.within_code=b.within_code and a.id=b.id and a.within_code='0000' and a.id='DD-G0245' and state not in ('2','V')", it_customer.Text));
                    if (dtCustomer.Rows.Count > 0)
                    {
                        name.Text = dtCustomer.Rows[0]["name"].ToString();
                        address.Text = dtCustomer.Rows[0]["s_address"].ToString();
                        linkman.Text = dtCustomer.Rows[0]["linkman"].ToString();
                        l_phone.Text = dtCustomer.Rows[0]["phone"].ToString();
                        fax.Text = dtCustomer.Rows[0]["fax"].ToString();
                    }
                    else
                    {
                        name.Text = "";
                        address.Text = "";
                        linkman.Text = "";
                        l_phone.Text = "";
                        fax.Text = "";
                    }
                }
                else
                {
                    name.Text = "";
                    address.Text = "";
                    linkman.Text = "";
                    l_phone.Text = "";
                    fax.Text = "";
                }
            }
        }

        private void CLMoid_Leave(object sender, EventArgs e)
        {
            Add_Cust_info();
        }

        private void BTNTOPDF_Click(object sender, EventArgs e)
        {
            flag_pdf = "PDF";
            this.Print();
        }





        //手寫單頁面代碼 =============END=============


    }
}
