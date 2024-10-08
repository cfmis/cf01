﻿//*********************************
//**船務在用，將李華的單轉成發票格式
//然后在GEO中批準就可以，減少發票錄入
//*********************************

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
using cf01.MDL;


namespace cf01.Forms
{
	public partial class frmDeliveryBillToInvoice : Form
	{
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
		public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態
		public static string str_language = "0";
		public bool save_flag;
        public string strArea = "";
        private bool flag_remove;

		DataTable dtMostly = new DataTable();
		DataTable dtDetails = new DataTable();
        DataTable dtFare = new DataTable();
		DataTable dtTempDel = new DataTable();
        DataTable dtRate = new DataTable();
        DataTable dtFind_Date = new DataTable();
        DataTable dt_st_qty = new DataTable();
        DataTable dtqty = new DataTable();

        private List<soinvoice_details_geo> lsModel = new List<soinvoice_details_geo>();

		public frmDeliveryBillToInvoice()
		{
			InitializeComponent();

            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

			str_language = DBUtility._language;
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();
		}

		private void frmDeliveryBillToInvoice_Load(object sender, EventArgs e)
		{			
			//customer
            clsDeliveryBill.SetCustomer(lkeIt_customer);
            clsDeliveryBill.SetCustomer(lkeFinally_buyer);            
			//出貨位置
            clsDeliveryBill.SetWH(lkeIssues_wh);           
			//貨幣
            clsDeliveryBill.SetCNY(lkeM_id);
			//稅種
            clsDeliveryBill.SetTax(lkeTax_ticket);
            //附款方法
            clsDeliveryBill.SetPayment(lkeP_id);
            //附款條件
            clsDeliveryBill.SetPayment_Condition(lkePc_id);            
            //組別資料
            DataTable dtSales_Group=clsSales_group.Get_sales_group();
            lkeMo_group.Properties.DataSource = dtSales_Group;
            lkeMo_group.Properties.ValueMember = "id";
            lkeMo_group.Properties.DisplayMember = "id";
            //區域
            clsDeliveryBill.SetZone(lkeArea);
            //跟單
            clsDeliveryBill.SetMerchandiser(lkeMerchandiser);
            //營業員
            clsDeliveryBill.SetMerchandiser(lkeSeller_id);
            //單據種類
            clsDeliveryBill.SetInvoice_Type(lkeBill_type_no);
            //裝運單方式
            clsDeliveryBill.SetShipping(lkeSm_id);
            //裝運港口     
            clsDeliveryBill.SetPort(lkeLoading_port);
            //目的港口    
            clsDeliveryBill.SetPort(lkeAp_id);
            //換船港口
            clsDeliveryBill.SetPort(lkeTranship_port);
            //銀行賬號 
            clsDeliveryBill.SetBank(lkeAccounts);
            //運輸途徑
            clsDeliveryBill.SetTransport(lkeTransport_style);
            //數量單位
            DataTable dtUnit = clsConErp.GetDataTable(@"SELECT unit_code AS id,'' as cdesc From it_coding where within_code='0000' and id='*' and basic_unit='PCS'");
            clSend_qty_unit.DataSource = dtUnit;
            clSend_qty_unit.ValueMember = "id";
            clSend_qty_unit.DisplayMember = "id";
            //單價單位
            clPrice_unit.DataSource = dtUnit;
            clPrice_unit.ValueMember = "id";
            clPrice_unit.DisplayMember = "id";

            //附加費
            DataTable dtAC = clsConErp.GetDataTable(@"SELECT id,name as cdesc FROM cd_tack_fare WHERE within_code='0000' and use_sell='1' and state not in ('2','V')");
            clAc.DataSource = dtAC;
            clAc.ValueMember = "id";
            clAc.DisplayMember = "id";
            //倉位
            DataTable dtWH = clsConErp.GetDataTable(@"SELECT id,id+' ' +name as cdesc FROM cd_productline WHERE within_code='0000' AND storehouse_group='HK' AND type ='01' AND state not in('V','2')");            
            clLocation_id.DataSource = dtWH;
            clLocation_id.ValueMember = "id";
            clLocation_id.DisplayMember = "cdesc";         
                        
            //來源
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
            lkeSeparate.Properties.DataSource = dtSeparate;
            lkeSeparate.Properties.ValueMember = "id";
            lkeSeparate.Properties.DisplayMember = "cdesc";

            //狀態
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
            lkeSate.Properties.DataSource = dtSate;
            lkeSate.Properties.ValueMember = "id";
            lkeSate.Properties.DisplayMember = "cdesc";


			//生成明細表,附加費表結構
            dtDetails = clsConErp.GetDataTable("Select Cast(Isnull(shipment_suit,'0') as  bit) AS shipment_suit,Cast(Isnull(is_free,'0') as  bit) AS is_free,*,space(12) as delivery_id,sequence_id as seq From dbo.so_invoice_details Where 1=0");
            dtFare = clsConErp.GetDataTable("Select fare_id,name,CAST(qty as int) as qty,Price,fare_sum,mo_id,remark,id,ver,sequence_id,CAST('0' AS bit) AS is_free,'0' as sum_kind,' ' as repeat_flag From so_other_fare Where 1=0");
			gridControl1.DataSource = dtDetails;
            gridControl2.DataSource = dtFare;

			//臨時項目刪除表結構
			dtTempDel = dtDetails.Clone();

            ////gridview1條件分類下拉列表框
            //dtType_condition = clsPublicOfCF01.GetDataTable("Select id,cdesc From dbo.bs_test_item_mostly");
            //clType_conditon.DataSource = dtType_condition;
            //clType_conditon.ValueMember = "id";
            //clType_conditon.DisplayMember = "cdesc";
            //clType_conditon.ShowHeader = false;

            dtRate = clsConErp.GetDataTable(@"SELECT unit_code,cast(rate as int) as rate From it_coding with(nolock) Where within_code ='0000' and id='*' and basic_unit ='PCS'");

            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                dgvDetails.Columns[i].AppearanceHeader.TextOptions.HAlignment=DevExpress.Utils.HorzAlignment.Center;
            }

            txtDat1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtDat2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            
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
				newRow["ver"] = dgvDetails.GetRowCellDisplayText(curRow, "ver");
                newRow["sequence_id"] = dgvDetails.GetRowCellDisplayText(curRow, "sequence_id");
                newRow["mo_id"] = dgvDetails.GetRowCellDisplayText(curRow, "mo_id");
                newRow["goods_id"] = dgvDetails.GetRowCellDisplayText(curRow, "goods_id");
                newRow["order_id"] = dgvDetails.GetRowCellDisplayText(curRow, "order_id");
                newRow["so_ver"] = dgvDetails.GetRowCellDisplayText(curRow, "so_ver");
                newRow["so_sequence_id"] = dgvDetails.GetRowCellDisplayText(curRow, "so_sequence_id");
				dtTempDel.Rows.Add(newRow);
				dgvDetails.DeleteRow(curRow);//移走當前行
			}
		}

		private void BTNSAVE_Click(object sender, EventArgs e)
		{
			txtShip_remark2.Focus();//Toolscript焦點問題
			Save();
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
			Cancel();
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
            SetObjValue.SetEditBackColor(tabPage1.Controls, true);
			SetObjValue.ClearObjValue(tabPage1.Controls, "1");            
            lkeSate.Enabled = false ;
            lkeSate.BackColor = Color.White;
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);

            lkeIssues_wh.EditValue = "D";
            lkeSeparate.EditValue = "1";
            lkeM_id.EditValue = "HKD";
            lkeBill_type_no.EditValue = "L";
            lkeSate.EditValue = "0";
            GetID_No();
            dtShip_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtDisc_rate.Text = "0.0000";
            txtDisc_amt.Text = "0.00";
            txtgoods_sum.Text = "0.00";
            txtOther_fare.Text = "0.00";
            txtDisc_spare.Text = "0.00";
            txtTotal_sum.Text = "0.00";
            txtTax_sum.Text = "0.00";
            txtOther_fee.Text = "0.00";
            txtTotal_package_num.Text = "0";
            txtVer.Text = "0";

			dtDetails.Clear();
			gridControl1.DataSource = dtDetails;
            dtFare.Clear();
            gridControl2.DataSource = dtFare;
		}

		private void Edit()  //編輯
		{
			if (txtID.Text == "")
			{
				return;
			}
            if (lkeSate.EditValue.ToString() != "0")
            {
                MessageBox.Show("注意：已批準的單據不可以再編輯!", "提示信息");
                return;
            }
			SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabPage1.Controls, true);
			Set_Grid_Status(true);
			mState = "EDIT";

			txtID.Properties.ReadOnly = true;
			txtID.BackColor = Color.White;
			lkeM_id.Enabled = false;
            lkeM_id.BackColor = Color.White;
            lkeSate.Enabled = false;
            lkeSate.BackColor = Color.White;
			
            lkeIt_customer.Enabled = false;
            lkeIt_customer.BackColor = Color.White;
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

            btnShipping.Enabled = !_flag;
            btnTearm.Enabled = !_flag;

            btnShipping.Enabled = !_flag;
            btnTearm.Enabled = !_flag;


            clsToolBar obj = new clsToolBar(Name, Controls);
            obj.SetToolBar();
		}

		private void Set_Grid_Status(bool _flag) // 表格可編號否
		{
			//false--不可編輯;true--可以編輯
			dgvDetails.OptionsBehavior.Editable = _flag;
			dgvFare.OptionsBehavior.Editable = _flag;                       
		}

		private void Delete() //刪除當前行
		{
			if (String.IsNullOrEmpty(txtID.Text))
			{
				return;
			}
            if (lkeSate.EditValue.ToString() != "0")
            {
                return;
            }
			
			DialogResult result = MessageBox.Show("此操作將刪除主表及明細中的資料,請謹慎操作!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{				
                const string sql_del = @"DELETED FROM dbo.so_invoice_mostly WHERE within_code='0000' AND id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);//改回直接操作GEO
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
                        SetObjValue.ClearObjValue(tabPage1.Controls, "1");
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
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ver", txtVer.Text);
				dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount + 1).ToString("0000")+"h");
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_unit", "KG");
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_free", false);

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
        
        /// <summary>
        /// 添加附加費新行
        /// </summary>
        private void AddNew_other_fare_Item()
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
            {   
                Set_Grid_Status(true);
                dgvFare.AddNewRow();//新增
                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "id", txtID.Text);
                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "ver", txtVer.Text);
                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "sequence_id", (dgvFare.RowCount + 1).ToString("0000") + "h");
                ColumnView view = (ColumnView)dgvFare;//初始單元格焦點
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
				txtShip_remark2.Focus();
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
            SetObjValue.SetEditBackColor(tabPage1.Controls, false);
            SetObjValue.ClearObjValue(tabPage1.Controls, "2");
			Set_Grid_Status(false);

			dtTempDel.Clear();
			dtDetails.Clear();
			gridControl1.DataSource = dtDetails;
            dtFare.Clear();
            gridControl2.DataSource = dtFare;

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
                string sql_h = String.Format(
                        @"SELECT * FROM dbo.so_invoice_mostly WITH(nolock) 
						WHERE within_code='0000' AND id ='{0}' AND state not in ('2','V')", temp_id);
                string sql_details = String.Format(
                        @"Select Cast(Isnull(shipment_suit,'0') as  bit) AS shipment_suit,Cast(Isnull(is_free,'0') as  bit) AS is_free,*,space(12) as delivery_id,space(5) as seq 
                        From dbo.so_invoice_details with(nolock) Where within_code='0000' And id='{0}'", temp_id);
                string sql_fare = String.Format(@"Select Convert(bit,isnull(is_free,'0')) AS is_free,Cast(qty as int) as qty,*,' ' as repeat_flag 
                        From dbo.so_invoice_other_fare with(nolock) Where within_code='0000' And id='{0}'", temp_id);
                dtDetails = clsConErp.GetDataTable(sql_details);
                dtFare = clsConErp.GetDataTable(sql_fare);

                dtMostly = clsConErp.GetDataTable(sql_h);
                if (dtMostly.Rows.Count > 0)
                    Set_Master_Data(dtMostly);
				else
				{
					SetObjValue.ClearObjValue(Controls, "2");
					return;
				}
				dtDetails.Clear();
                dtDetails = clsConErp.GetDataTable(sql_details);
				gridControl1.DataSource = dtDetails;
                dtFare.Clear();
                dtFare = clsConErp.GetDataTable(sql_fare);
                gridControl2.DataSource = dtFare;

				mID = txtID.Text;//保存臨時的ID號               
			}
		}

		private void Save()  //保存
		{
			if (!Save_Before_Valid())
			{
				return;
			}
            if (float.Parse(txtTotal_sum.Text) == 0)
            {
                MessageBox.Show("總金額不可為空!", "提示信息");
                return;
            }
			if (Check_Details_Valid())//檢查明細資料的有效性
			{
				return;
			}
			save_flag = false;     

			#region  保存新增或編輯
            const string sql_bill_code_i =
                  @"Insert Into sys_bill_max_separate(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2) Values('0000','SI01',@year_month,@bill_code,@bill_text1,@bill_text2)";
            const string sql_bill_code_u =
                  @"UPDATE sys_bill_max_separate SET bill_code =@bill_code WHERE within_code='0000' and bill_id='SI01' AND year_month=@year_month AND bill_text1=@bill_text1 AND bill_text2=@bill_text2";

            if (mState == "NEW" || mState == "EDIT")
			{
                if (mState == "NEW")
                {
                    string strSql = String.Format("Select '1' FROM dbo.so_invoice_mostly with(nolock) WHERE within_code='0000' and id='{0}'", txtID.Text.Trim());
                    using (DataTable dtMaxNo = GetDataTable_HK(strSql))
                    {
                        //if (clsConErp.ExecuteSqlReturnObject(strSql) != "") //old Code 取DG INVOICE
                        if (dtMaxNo.Rows.Count > 0)
                        {
                            GetID_No_HK(); //如已存在編號則重新取最大單據編號
                        }
                    }                   
                }                
               const string sql_i = @"INSERT INTO dbo.so_invoice_mostly
                (within_code,id,ver,type,oi_date,it_customer,name,address,phone,fax,linkman,l_phone,p_id,m_id,exchange_rate,m_rate,pc_id,seller_id,cd_disc,
                disc_rate,disc_amt,disc_spare,other_fare,goods_sum,tax_sum,total_sum,ncr_amount,ncrb_amount,transfers_state,state,create_date,create_by,
                remark,separate,cn_sum,dn_sum,area,commission_rate,as_id,ship_date,loading_port,tranship_port,bill_type_no,shop_no,merchandiser,merchandiser_phone,
                po_no,email,ship_remark,ship_remark2,ship_remark3,issues_wh,finally_buyer,bill_address,transport_style,flag,remark2,confirm_status,packinglistno,mo_group,box_no,servername) VALUES
				('0000',@id,@ver,'0',CASE LEN(@oi_date) WHEN 0 THEN null ELSE @oi_date END,@it_customer,@name,@address,@phone,@fax,@linkman,@l_phone,@p_id,@m_id,@exchange_rate,@m_rate,@pc_id,@seller_id,@cd_disc,
                @disc_rate,@disc_amt,@disc_spare,@other_fare,@goods_sum,@tax_sum,@total_sum,@ncr_amount,@ncrb_amount,@transfers_state,@state,getdate(),@create_by,
                @remark,@separate,@cn_sum,@dn_sum,@area,@commission_rate,@as_id,CASE LEN(@ship_date) WHEN 0 THEN null ELSE @ship_date END,@loading_port,@tranship_port,@bill_type_no,@shop_no,@merchandiser,@merchandiser_phone,
                @po_no,@email,@ship_remark,@ship_remark2,@ship_remark3,@issues_wh,@finally_buyer,@bill_address,@transport_style,@flag,@remark2,@confirm_status,@PackingListNo,@mo_group,@box_no,@servername)";

               const string sql_u =
                @"Update so_invoice_mostly SET oi_date=CASE LEN(@oi_date) WHEN 0 THEN null ELSE @oi_date END,it_customer=@it_customer,name=@name,address=@address,phone=@phone,fax=@fax,linkman=@linkman,l_phone=@l_phone,
                p_id=@p_id,m_id=@m_id,exchange_rate=@exchange_rate,m_rate=@m_rate,pc_id=@pc_id,seller_id=@seller_id,cd_disc=@cd_disc,disc_rate=@disc_rate,disc_amt=@disc_amt,disc_spare=@disc_spare,other_fare=@other_fare,
                goods_sum=@goods_sum,tax_sum=@tax_sum,total_sum=@total_sum,ncr_amount=@ncr_amount,ncrb_amount=@ncrb_amount,transfers_state=@transfers_state,state=@state,update_date=getdate(),update_by=@create_by,
                remark=@remark,separate=@separate,cn_sum=@cn_sum,dn_sum=@dn_sum,area=@area,commission_rate=@commission_rate,as_id=@as_id,ship_date=CASE LEN(@ship_date) WHEN 0 THEN null ELSE @ship_date END,
                loading_port=@loading_port,tranship_port=@tranship_port,bill_type_no=@bill_type_no,shop_no=@shop_no,merchandiser=@merchandiser,merchandiser_phone=@merchandiser_phone,po_no=@po_no,email=@email,ship_remark=@ship_remark,
                ship_remark2=@ship_remark2,ship_remark3=@ship_remark3,issues_wh=@issues_wh,finally_buyer=@finally_buyer,bill_address=@bill_address,transport_style=@transport_style,flag=@flag,remark2=@remark2,confirm_status=@confirm_status,
                packingListno=@packingListno,mo_group=@mo_group,Box_no=@box_no,servername=@servername
                WHERE within_code='0000' and id=@id and ver=@ver";

                
                
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
						myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        myCommand.Parameters.AddWithValue("@ver", int.Parse(txtVer.Text));
                        myCommand.Parameters.AddWithValue("@oi_date", dtOi_date.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@it_customer", lkeIt_customer.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@name", txtName.Text);
                        myCommand.Parameters.AddWithValue("@address", txtAddress.Text);
                        myCommand.Parameters.AddWithValue("@bill_address", txtBill_address.Text);
                        myCommand.Parameters.AddWithValue("@phone", txtPhone.Text);
                        myCommand.Parameters.AddWithValue("@fax", txtFax.Text);
                        myCommand.Parameters.AddWithValue("@linkman", txtLinkman.Text);
                        myCommand.Parameters.AddWithValue("@l_phone", txtL_phone.Text);
                        myCommand.Parameters.AddWithValue("@p_id", lkeP_id.EditValue.ToString());                        
                        myCommand.Parameters.AddWithValue("@m_id", lkeM_id.EditValue.ToString());
                        //float s = float.Parse(txtM_rate.Text);
                        //decimal dd = decimal.Parse(txtM_rate.Text);
                        //double ddd = double.Parse(txtM_rate.Text);
                        myCommand.Parameters.AddWithValue("@m_rate", decimal.Parse(txtM_rate.Text));
                        if(lkeM_id.EditValue.ToString()=="HKD")
                            myCommand.Parameters.AddWithValue("@exchange_rate", 4);
                        else
                            if (lkeM_id.EditValue.ToString() == "USD")
                                myCommand.Parameters.AddWithValue("@exchange_rate", 2);
                            else
                                myCommand.Parameters.AddWithValue("@exchange_rate", 0);
                        myCommand.Parameters.AddWithValue("@pc_id", lkePc_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@seller_id", lkeSeller_id.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@cd_disc", 1);
                        myCommand.Parameters.AddWithValue("@disc_rate", decimal.Parse(txtDisc_rate.Text));
                        myCommand.Parameters.AddWithValue("@disc_amt", decimal.Parse(txtDisc_amt.Text));
                        myCommand.Parameters.AddWithValue("@disc_spare", decimal.Parse(txtDisc_spare.Text));
                        myCommand.Parameters.AddWithValue("@other_fare", decimal.Parse(txtOther_fare.Text));
                        myCommand.Parameters.AddWithValue("@total_sum", decimal.Parse(txtTotal_sum.Text));
                        myCommand.Parameters.AddWithValue("@goods_sum", decimal.Parse(txtTotal_sum.Text));
                        myCommand.Parameters.AddWithValue("@tax_sum", decimal.Parse(txtTax_sum.Text));
                        myCommand.Parameters.AddWithValue("@ncr_amount", decimal.Parse(txtTotal_sum.Text));
                        myCommand.Parameters.AddWithValue("@ncrb_amount", 0);
                        myCommand.Parameters.AddWithValue("@transfers_state", "0");
                        myCommand.Parameters.AddWithValue("@state", "0");
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                        myCommand.Parameters.AddWithValue("@separate", "1");
                        myCommand.Parameters.AddWithValue("@cn_sum",0);
                        myCommand.Parameters.AddWithValue("@dn_sum", 0);
                        myCommand.Parameters.AddWithValue("@area", lkeArea.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@commission_rate", 0);
                        myCommand.Parameters.AddWithValue("@as_id", "001");
                        myCommand.Parameters.AddWithValue("@ship_date", dtShip_date.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@loading_port", lkeLoading_port.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@tranship_port", lkeTranship_port.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@bill_type_no", lkeBill_type_no.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@shop_no", txtShop_no.Text);
                        myCommand.Parameters.AddWithValue("@merchandiser", lkeMerchandiser.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@merchandiser_phone", txtMerchandiser_phone.Text);
                        myCommand.Parameters.AddWithValue("@po_no", txtPo_no.Text);
                        myCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                        myCommand.Parameters.AddWithValue("@ship_remark", txtShip_remark.Text);
                        myCommand.Parameters.AddWithValue("@ship_remark2", txtShip_remark2.Text);
                        myCommand.Parameters.AddWithValue("@ship_remark3", txtShip_remark3.Text);
                        myCommand.Parameters.AddWithValue("@issues_wh", lkeIssues_wh.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@finally_buyer", lkeFinally_buyer.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@transport_style", lkeTransport_style.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@flag", "0"); //flag="1" 東莞D標識,0:發票
                        myCommand.Parameters.AddWithValue("@remark2", txtRemark2.Text);
                        myCommand.Parameters.AddWithValue("@confirm_status", "0");
                        myCommand.Parameters.AddWithValue("@packinglistno", btePackinglistno.Text);
                        myCommand.Parameters.AddWithValue("@mo_group", lkeMo_group.EditValue.ToString());
                        myCommand.Parameters.AddWithValue("@box_no", txtBox_no.Text);
                        myCommand.Parameters.AddWithValue("@servername", "hkserver.cferp.dbo");
                        myCommand.Parameters.AddWithValue("@create_by", DBUtility._user_id);                                           
						myCommand.ExecuteNonQuery();
                        
                        //處理【項目刪除】刪除明細資料
                        string sql_item_d, sql_fare_d,sql_update_flag; 
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            //刪除明細
                            sql_item_d =@"DELETE FROM dbo.so_invoice_details WHERE within_code='0000' AND id=@id and ver=@ver and sequence_id=@sequence_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@ver", txtVer.Text.Trim());
                            myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());      
                            myCommand.ExecuteNonQuery();
                            //刪除附加費明細
                            sql_fare_d =@"DELETE FROM dbo.so_invoice_other_fare WHERE within_code='0000' AND id=@id and ver=@ver and mo_id=@mo_id";
                            myCommand.CommandText = sql_fare_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@ver", txtVer.Text.Trim());
                            myCommand.Parameters.AddWithValue("@mo_id", dtTempDel.Rows[i]["mo_id"].ToString());
                            myCommand.ExecuteNonQuery();
                            //還原標識
                            sql_update_flag =string.Format( 
                            @"UPDATE so_invoice_details SET state='0' WHERE within_code='0000' AND mo_id='{0}' AND goods_id='{1}' AND order_id='{2}' and so_ver='{3}' and so_sequence_id='{4}'", 
                             dtTempDel.Rows[i]["mo_id"],dtTempDel.Rows[i]["goods_id"],dtTempDel.Rows[i]["order_id"],
                             dtTempDel.Rows[i]["so_ver"], dtTempDel.Rows[i]["so_sequence_id"]);
                            clsPublicOfCF01.ExecuteSqlUpdate(sql_update_flag);
                        }
                        
                        //保存明細
                        int curRow;
                        string rowStatus;
						if (dgvDetails.RowCount > 0)
						{
                            const string sql_item_i = @"INSERT INTO dbo.so_invoice_details
                                (within_code,id,ver,sequence_id,order_id,so_ver,so_sequence_id,customer_goods,customer_color_id,so_bom_sequence,goods_id,goods_name,goods_unit,invoice_price,price,currency,exchange_rate,m_rate,price_fare,
                                disc_rate,disc_amt,disc_price,u_invoice_qty,p_unit,total_sum,transfers_state,remark,invoice_sum,ncv,location_id,carton_code,contract_cid,under_value_price,
                                sec_qty,sec_unit,mo_id,is_print,shipment_suit,state,dummy_location_id,dummy_carton_code,table_head,is_free,box_no) VALUES
                                ('0000',@id,@ver,@sequence_id,@order_id,@so_ver,@so_sequence_id,@customer_goods,@customer_color_id,@so_bom_sequence,@goods_id,@goods_name,@goods_unit,@invoice_price,@price,@currency,@exchange_rate,@m_rate,@price_fare,
                                @disc_rate,@disc_amt,@disc_price,@u_invoice_qty,@p_unit,@total_sum,@transfers_state,@remark,@invoice_sum,@ncv,@location_id,@carton_code,@contract_cid,@under_value_price,
                                @sec_qty,@sec_unit,@mo_id,@is_print,@shipment_suit,@state,@dummy_location_id,@dummy_carton_code,@table_head,@is_free,@box_no)";
                            const string sql_item_u =
                                @"Update dbo.so_invoice_details SET order_id=@order_id,so_ver=@so_ver,so_sequence_id=@so_sequence_id,customer_goods=@customer_goods,customer_color_id=@customer_color_id,so_bom_sequence=@so_bom_sequence,
                                goods_id=@goods_id,goods_name=@goods_name,goods_unit=@goods_unit,invoice_price=@invoice_price,price=@price,currency=@currency,exchange_rate=@exchange_rate,m_rate=@m_rate,price_fare=@price_fare,
                                disc_rate=@disc_rate,disc_amt=@disc_amt,disc_price=@disc_price,u_invoice_qty=@u_invoice_qty,p_unit=@p_unit,total_sum=@total_sum,transfers_state=@transfers_state,remark=@remark,invoice_sum=@invoice_sum,ncv=@ncv,
                                location_id=@location_id,carton_code=@carton_code,contract_cid=@contract_cid,under_value_price=@under_value_price,sec_qty=@sec_qty,sec_unit=@sec_unit,mo_id=@mo_id,is_print=@is_print,shipment_suit=@shipment_suit,
                                state=@state,dummy_location_id=@dummy_location_id,dummy_carton_code=@dummy_carton_code,table_head=@table_head,is_free=@is_free,box_no=@box_no
                                Where within_code='0000' and id=@id and ver=@ver and sequence_id=@sequence_id";
                            
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
                                    myCommand.Parameters.AddWithValue("@ver", int.Parse(txtVer.Text));
                                    myCommand.Parameters.AddWithValue("@sequence_id", dgvDetails.GetRowCellValue(curRow, "sequence_id").ToString());
                                    myCommand.Parameters.AddWithValue("@order_id", dgvDetails.GetRowCellValue(curRow, "order_id").ToString());
                                    myCommand.Parameters.AddWithValue("@so_ver", int.Parse(dgvDetails.GetRowCellValue(curRow, "so_ver").ToString()));
                                    myCommand.Parameters.AddWithValue("@so_sequence_id", dgvDetails.GetRowCellValue(curRow, "so_sequence_id").ToString());
                                    myCommand.Parameters.AddWithValue("@customer_goods", dgvDetails.GetRowCellValue(curRow, "customer_goods").ToString());
                                    myCommand.Parameters.AddWithValue("@customer_color_id", dgvDetails.GetRowCellValue(curRow, "customer_color_id").ToString());
                                    myCommand.Parameters.AddWithValue("@so_bom_sequence", "");
                                    myCommand.Parameters.AddWithValue("@goods_id", dgvDetails.GetRowCellValue(curRow, "goods_id").ToString());
                                    myCommand.Parameters.AddWithValue("@goods_name", dgvDetails.GetRowCellValue(curRow, "goods_name").ToString());
                                    myCommand.Parameters.AddWithValue("@goods_unit", dgvDetails.GetRowCellValue(curRow, "goods_unit").ToString());
                                    myCommand.Parameters.AddWithValue("@invoice_price", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "invoice_price").ToString()));
                                    myCommand.Parameters.AddWithValue("@price", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "invoice_price").ToString()));
                                    myCommand.Parameters.AddWithValue("@currency", dgvDetails.GetRowCellValue(curRow, "currency").ToString());
                                    myCommand.Parameters.AddWithValue("@exchange_rate", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "exchange_rate").ToString()));
                                    myCommand.Parameters.AddWithValue("@m_rate", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "m_rate").ToString()));
                                    myCommand.Parameters.AddWithValue("@price_fare", 0);
                                    myCommand.Parameters.AddWithValue("@disc_rate", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "disc_rate").ToString()));
                                    myCommand.Parameters.AddWithValue("@disc_amt", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "disc_amt").ToString()));
                                    myCommand.Parameters.AddWithValue("@disc_price", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "disc_price").ToString()));
                                    myCommand.Parameters.AddWithValue("@u_invoice_qty", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "u_invoice_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@p_unit", dgvDetails.GetRowCellValue(curRow, "p_unit").ToString());
                                    myCommand.Parameters.AddWithValue("@total_sum", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "total_sum").ToString()));
                                    myCommand.Parameters.AddWithValue("@transfers_state", "0");
                                    myCommand.Parameters.AddWithValue("@remark", dgvDetails.GetRowCellValue(curRow, "remark").ToString());
                                    myCommand.Parameters.AddWithValue("@invoice_sum", 0);
                                    myCommand.Parameters.AddWithValue("@ncv", "0");
                                    myCommand.Parameters.AddWithValue("@location_id", dgvDetails.GetRowCellValue(curRow, "location_id").ToString());
                                    myCommand.Parameters.AddWithValue("@carton_code", dgvDetails.GetRowCellValue(curRow, "carton_code").ToString());
                                    myCommand.Parameters.AddWithValue("@contract_cid", dgvDetails.GetRowCellValue(curRow, "contract_cid").ToString());
                                    myCommand.Parameters.AddWithValue("@under_value_price", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "invoice_price").ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_qty", decimal.Parse(dgvDetails.GetRowCellValue(curRow, "sec_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_unit", dgvDetails.GetRowCellValue(curRow, "sec_unit").ToString());
                                    myCommand.Parameters.AddWithValue("@mo_id", dgvDetails.GetRowCellValue(curRow, "mo_id").ToString());
                                    myCommand.Parameters.AddWithValue("@is_print", dgvDetails.GetRowCellValue(curRow, "is_print").ToString());
                                    if (dgvDetails.GetRowCellValue(curRow, "shipment_suit").ToString() == "True")
                                        myCommand.Parameters.AddWithValue("@shipment_suit", "1");
                                    else
                                        myCommand.Parameters.AddWithValue("@shipment_suit", "0");
                                    myCommand.Parameters.AddWithValue("@state", "0");
                                    myCommand.Parameters.AddWithValue("@dummy_location_id", "ZZZ");
                                    myCommand.Parameters.AddWithValue("@dummy_carton_code", "ZZZ");
                                    myCommand.Parameters.AddWithValue("@table_head", dgvDetails.GetRowCellValue(curRow, "table_head").ToString());
                                    if (dgvDetails.GetRowCellValue(curRow, "is_free").ToString() == "False")
                                        myCommand.Parameters.AddWithValue("@is_free", "0");
                                    else
                                        myCommand.Parameters.AddWithValue("@is_free", "1");
                                    myCommand.Parameters.AddWithValue("@box_no", dgvDetails.GetRowCellValue(curRow, "box_no").ToString());
                                    myCommand.ExecuteNonQuery();
                                }
							}
						}                       

                        //保存附加費
                        if (dgvFare.RowCount > 0)
                        {
                            const string sql_fare_i = @"INSERT INTO dbo.so_invoice_other_fare(within_code,id,ver,sequence_id,fare_id,name,qty,price,fare_sum,mo_id,is_free,remark,sum_kind) 
                              VALUES('0000',@id,@ver,@sequence_id,@fare_id,@name,@qty,@price,@fare_sum,@mo_id,@is_free,@remark,@sum_kind)";
                            const string sql_fare_u =
                            @"Update dbo.so_invoice_other_fare Set fare_id=@fare_id,name=@name,qty=@qty,price=@price,fare_sum=@fare_sum,mo_id=@mo_id,is_free=@is_free,remark=@remark,sum_kind=@sum_kind
                              Where within_code='0000' and id=@id and ver=@ver and sequence_id=@sequence_id ";                            
                            for (int i = 0; i < dgvFare.RowCount; i++)
                            {
                                curRow = dgvFare.GetRowHandle(i);
                                rowStatus = dgvFare.GetDataRow(curRow).RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    if (rowStatus == "Added")
                                        myCommand.CommandText = sql_fare_i;
                                    else
                                        myCommand.CommandText = sql_fare_u;
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                    myCommand.Parameters.AddWithValue("@ver", int.Parse(txtVer.Text));
                                    myCommand.Parameters.AddWithValue("@sequence_id", dgvFare.GetRowCellValue(curRow, "sequence_id").ToString());
                                    myCommand.Parameters.AddWithValue("@fare_id", dgvFare.GetRowCellValue(curRow, "fare_id").ToString());
                                    myCommand.Parameters.AddWithValue("@name", dgvFare.GetRowCellValue(curRow, "name").ToString());
                                    myCommand.Parameters.AddWithValue("@qty", decimal.Parse(dgvFare.GetRowCellValue(curRow, "qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@price", decimal.Parse(dgvFare.GetRowCellValue(curRow, "Price").ToString()));
                                    myCommand.Parameters.AddWithValue("@fare_sum", decimal.Parse(dgvFare.GetRowCellValue(curRow, "fare_sum").ToString()));
                                    myCommand.Parameters.AddWithValue("@mo_id", dgvFare.GetRowCellValue(curRow, "mo_id").ToString());
                                    if (dgvFare.GetRowCellValue(curRow, "is_free").ToString() == "True")
                                        myCommand.Parameters.AddWithValue("@is_free", "1");
                                    else
                                        myCommand.Parameters.AddWithValue("@is_free", "0");
                                    myCommand.Parameters.AddWithValue("@remark", dgvFare.GetRowCellValue(curRow, "remark").ToString());
                                    myCommand.Parameters.AddWithValue("@sum_kind", "0");
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
            SetObjValue.SetEditBackColor(tabPage1.Controls, false);
			Set_Grid_Status(false);					
			dtTempDel.Clear();

            //更新過帳標識
            if (save_flag)
            {
                //更新HK最大單據編號
                if (mState == "NEW")
                {
                    string sql_bill_f, strID, ym, wh, bill_type;
                    strID = txtID.Text.Trim();
                    ym = strID.Substring(2, 3);
                    wh = strID.Substring(0, 1);
                    bill_type = strID.Substring(1, 1);
                    sql_bill_f = string.Format(@"Select '1' FROM sys_bill_max_separate with(nolock)
                                WHERE within_code='0000' and bill_id='SI01' AND year_month='{0}' AND bill_text1='{1}' AND bill_text2='{2}'", ym, wh, bill_type);
                    //直接判斷更新HK ERP上的最大單據編號
                    using (DataTable dtmaxno = GetDataTable_HK(sql_bill_f))
                    {
                        SqlParameter[] paras = new SqlParameter[] { 
                                    new SqlParameter("@year_month", ym), 
                                    new SqlParameter("@bill_code", strID),
                                    new SqlParameter("@bill_text1", wh), 
                                    new SqlParameter("@bill_text2", bill_type) 
                                };
                        if (dtmaxno.Rows.Count > 0)
                        {
                            Update_HK_Bill_MaxNo(sql_bill_code_u, paras, false);
                        }
                        else
                            Update_HK_Bill_MaxNo(sql_bill_code_i, paras, false);
                    }                    
                }               

                int cur_row;
                string sql_u, delivery_id, seq;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    cur_row = dgvDetails.GetRowHandle(i);
                    if (dgvDetails.GetRowCellValue(cur_row, "delivery_id").ToString() != "")
                    {
                        delivery_id = dgvDetails.GetRowCellValue(cur_row, "delivery_id").ToString();
                        seq = dgvDetails.GetRowCellValue(cur_row, "seq").ToString();
                        sql_u = string.Format("Update so_invoice_details Set state='1' Where within_code='0000' and id='{0}' and sequence_id='{1}'", delivery_id, seq);
                        clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                    }
                }
            }
            mState = "";

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
            if (lkeBill_type_no.Text == "" || txtID.Text == "" || lkeM_id.Text == "" || dtShip_date.Text == "" || lkeSeller_id.Text == "")
            {	
				MessageBox.Show("發票編號、單據種類,貨幣,營業員、送貨單日期等資料不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else			
				return true;
		}

		private bool Valid_Doc() //主建是否已存在
		{
			bool flag;
			string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM dbo.so_invoice_mostly WHERE within_code='0000' and id='{0}'", doc);			
            DataTable dt = clsConErp.GetDataTable(strSql);
			if (dt.Rows.Count > 0)
			{
				MessageBox.Show("當前發票編號已存在" + String.Format("【{0}】.", doc), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


        //private void clTest_item_id_EditValueChanged(object sender, EventArgs e)
        //{
        //    LookUpEdit objItem = (LookUpEdit)sender;
        //    string strid = objItem.Text;
        //    int indexSelect = clTest_item_id.GetDataSourceRowIndex("test_item_id", strid);
        //    string strdesc = clTest_item_id.GetDataSourceValue("test_item_edesc", indexSelect).ToString();
        //    string strcdesc = clTest_item_id.GetDataSourceValue("test_item_cdesc", indexSelect).ToString();
        //    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "test_item_name", strcdesc);
        //    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "test_item_name_english", strdesc);
        //}

		private void Set_Master_Data(DataTable dt) //綁定主檔資料
		{
			txtID.Text = dt.Rows[0]["id"].ToString();
            txtVer.Text = dt.Rows[0]["ver"].ToString();
            if (string.IsNullOrEmpty(dt.Rows[0]["oi_date"].ToString()))
                dtOi_date.EditValue = "";
            else
                dtOi_date.EditValue = Convert.ToDateTime(dt.Rows[0]["oi_date"].ToString()).ToString("yyyy-MM-dd");
            lkeIt_customer.EditValue = dt.Rows[0]["it_customer"].ToString();
            txtName.Text = dt.Rows[0]["name"].ToString();
            txtLinkman.Text = dt.Rows[0]["linkman"].ToString();
            txtL_phone.Text = dt.Rows[0]["l_phone"].ToString();
            lkeIssues_wh.EditValue = dt.Rows[0]["issues_wh"].ToString();
            lkeBill_type_no.EditValue = dt.Rows[0]["bill_type_no"].ToString();
            txtPo_no.Text = dt.Rows[0]["po_no"].ToString();
            txtShipping_methods.Text = dt.Rows[0]["shipping_methods"].ToString();
			lkeM_id.EditValue = dt.Rows[0]["m_id"].ToString();
            txtM_rate.Text = dt.Rows[0]["m_rate"].ToString();            
            txtDisc_rate.Text = Math.Round(decimal.Parse(dt.Rows[0]["disc_rate"].ToString()), 4).ToString();
            //txtDisc_amt.Text = dt.Rows[0]["disc_amt"].ToString();
            txtDisc_amt.Text = Math.Round(decimal.Parse(dt.Rows[0]["disc_amt"].ToString()), 2).ToString();
            lkeTax_ticket.EditValue = dt.Rows[0]["tax_ticket"].ToString();
            //txtCess.Text = dt.Rows[0]["cess"].ToString();
            if (txtCess.Text == "")
                txtCess.Text = "0.00";
            
            //txtTax_sum.Text = dt.Rows[0]["tax_sum"].ToString();
            txtTax_sum.Text = Math.Round(decimal.Parse(dt.Rows[0]["tax_sum"].ToString()), 2).ToString();
            txtTotal_package_num.Text = dt.Rows[0]["total_package_num"].ToString();
            txtPackage_unit.Text = dt.Rows[0]["package_unit"].ToString();
            txtTotal_weight.Text = dt.Rows[0]["total_weight"].ToString();
            txtShip_remark.Text = dt.Rows[0]["ship_remark"].ToString();
            txtShip_remark2.Text = dt.Rows[0]["ship_remark2"].ToString();
            txtShip_remark3.Text = dt.Rows[0]["ship_remark3"].ToString();
            lkeP_id.EditValue = dt.Rows[0]["p_id"].ToString();
            lkePc_id.EditValue = dt.Rows[0]["pc_id"].ToString();
            txtPer.Text = dt.Rows[0]["per"].ToString();
            txtFinal_destination.Text = dt.Rows[0]["final_destination"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["ship_date"].ToString()))
                dtShip_date.EditValue = Convert.ToDateTime(dt.Rows[0]["ship_date"].ToString()).ToString("yyyy-MM-dd");
            else
                dtShip_date.EditValue = "";
            lkeLoading_port.EditValue = dt.Rows[0]["loading_port"].ToString();
            lkeSeparate.EditValue = dt.Rows[0]["separate"].ToString();
            txtShop_no.Text = dt.Rows[0]["shop_no"].ToString();
            txtPhone.Text = dt.Rows[0]["phone"].ToString();
            txtFax.Text = dt.Rows[0]["fax"].ToString();
            lkeArea.EditValue = dt.Rows[0]["area"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            lkeMerchandiser.EditValue = dt.Rows[0]["merchandiser"].ToString();
            txtMerchandiser_phone.Text = dt.Rows[0]["merchandiser_phone"].ToString();
            lkeSeller_id.EditValue = dt.Rows[0]["seller_id"].ToString();
            //txtgoods_sum.Text = dt.Rows[0]["goods_sum"].ToString();
            txtgoods_sum.Text = Math.Round(decimal.Parse(dt.Rows[0]["goods_sum"].ToString()), 2).ToString();
            //txtOther_fare.Text = dt.Rows[0]["other_fare"].ToString();
            txtOther_fare.Text = Math.Round(decimal.Parse(dt.Rows[0]["other_fare"].ToString()), 2).ToString();
            //txtDisc_spare.Text = dt.Rows[0]["disc_spare"].ToString();
            txtDisc_spare.Text = Math.Round(decimal.Parse(dt.Rows[0]["disc_spare"].ToString()), 2).ToString();
            //txtTotal_sum.Text = dt.Rows[0]["total_sum"].ToString();
            txtTotal_sum.Text = Math.Round(decimal.Parse(dt.Rows[0]["total_sum"].ToString()), 2).ToString();
            txtAmount.Text = dt.Rows[0]["amount"].ToString();
            txtOther_fee.Text = dt.Rows[0]["other_fee"].ToString();
            txtRemark2.Text = dt.Rows[0]["remark2"].ToString();
            txtRemark.Text = dt.Rows[0]["remark"].ToString();
            lkeSm_id.EditValue = dt.Rows[0]["sm_id"].ToString();
            lkeAccounts.EditValue = dt.Rows[0]["accounts"].ToString();
            txtIssues_state.Text = dt.Rows[0]["issues_state"].ToString();
            lkeTransport_style.EditValue = dt.Rows[0]["transport_style"].ToString();
            lkeAp_id.EditValue = dt.Rows[0]["ap_id"].ToString();
            lkeTranship_port.EditValue = dt.Rows[0]["tranship_port"].ToString();
            btePackinglistno.Text = dt.Rows[0]["packinglistno"].ToString();
            txtBox_no.Text = dt.Rows[0]["box_no"].ToString();
            txtPayment_date.Text = dt.Rows[0]["payment_date"].ToString();
            lkeSate.EditValue = dt.Rows[0]["state"].ToString();
            txtBill_address.Text = dt.Rows[0]["bill_address"].ToString();
            txtAddress.Text = dt.Rows[0]["address"].ToString();
            txtCheck_date.Text = dt.Rows[0]["check_date"].ToString();
            //txtCheck_date.Text =Convert.ToDateTime(dt.Rows[0]["address"].ToString()).ToString("yyyy-MM-dd");

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
   
        private void frmDeliveryBillToInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtFare.Dispose();
            dtTempDel.Dispose();
            dtRate.Dispose();
            dtFind_Date.Dispose();            
            dt_st_qty.Dispose();
            dtqty.Dispose();

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

        private void clAc_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit objItem = (LookUpEdit)sender;           
            string strAc_id = objItem.EditValue.ToString();
            int indexSelect = clAc.GetDataSourceRowIndex("id", strAc_id);
            string strcdesc = clAc.GetDataSourceValue("cdesc", indexSelect).ToString();            
            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "name", strcdesc);
        }

        /// <summary>
        /// 生成箱號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btePackinglistno_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {            
            if (mState == "NEW")
            {                
                if (string.IsNullOrEmpty(lkeMo_group.EditValue.ToString()))
                {
                    MessageBox.Show("請首先選定負責組別資料!");
                    return;
                }
                string strSales_Group,strGenNo;
                strSales_Group = lkeMo_group.EditValue.ToString();
                
                string sql = string.Format(
                @"Select Cast(substring(bill_code,3,8) as int) as bill_code From sys_bill_max with(nolock)
                Where within_code='0000' and bill_id ='SO09' and  bill_text1 ='{0}' ", strSales_Group);
                DataTable dt=new DataTable();
                dt = clsConErp.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    strGenNo = strSales_Group + "-" + int.Parse(dt.Rows[0]["bill_code"].ToString())+1.ToString("00000000");
                    sql = string.Format("Update sys_bill_max Set bill_code='{0}' Where within_code='0000' and bill_id ='SO09' and bill_text1 ='{1}'", strGenNo, strSales_Group);
                }
                else
                {
                    strGenNo = String.Format("{0}-00000001", strSales_Group);
                    sql = string.Format("Insert Into sys_bill_max(within_code,bill_id,bill_code,bill_text1) values('0000','SO09','{0}','{1}')", strGenNo, strSales_Group);                   
                }
                try
                {
                    clsConErp.ExecuteSqlUpdate(sql);
                    btePackinglistno.EditValue = strGenNo;
                }
                catch (Exception ex)
                {
                    btePackinglistno.EditValue = "";
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lkeTax_ticket_EditValueChanged(object sender, EventArgs e)
        {            
            if (mState != "")
            {
                if (lkeTax_ticket.EditValue.ToString() != "")
                    txtCess.Text = lkeTax_ticket.GetColumnValue("cess").ToString();
                else
                    txtCess.Text = "0.0000";
            }
        }

        private void lkeM_id_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                if (lkeM_id.EditValue.ToString() != "")
                {
                    txtM_rate.Text = lkeM_id.GetColumnValue("m_rate").ToString();
                    txtID.Text = "";
                    lkeBill_type_no.EditValue = "";
                }
                else
                {                    
                    txtM_rate.Text = "0.0000";
                }
            }
        }

        private void lkeIt_customer_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                if (lkeIt_customer.EditValue.ToString() != "")
                {
                    txtName.Text = lkeIt_customer.GetColumnValue("cdesc").ToString();
                    lkeFinally_buyer.EditValue = lkeIt_customer.EditValue;
                }
                else
                {
                    txtName.Text = "";
                    lkeFinally_buyer.EditValue = "";
                }
            }
        }

        private void lkeIssues_wh_Leave(object sender, EventArgs e)
        {            
           GetID_No_HK();
        }

        private void lkeBill_type_no_Leave(object sender, EventArgs e)
        {
            GetID_No_HK();
        }

        /// <summary>
        /// 取單據序號
        /// </summary>
        private void GetID_No()
        {
            if (mState != "")
            {
                string strWareHouse = lkeIssues_wh.EditValue.ToString();
                string strBill_type = lkeBill_type_no.EditValue.ToString();
                if (strWareHouse == "H" && strBill_type != "")
                {
                    string sql = 
                    @"Select substring(cast(year(GETDATE()) as CHAR),3,2)+
                    CASE month(GETDATE()) 
                    WHEN 10 THEN 'A' 
                    WHEN 11 THEN 'B'
                    WHEN 12 THEN 'C' 
                    ELSE CAST(month(GETDATE()) as CHAR) END as ym";
                    string str_ym= clsConErp.ExecuteSqlReturnObject(sql).Trim();

                    sql =string.Format(
                    @"Select CAST(substring(bill_code,6,5) as int)+1 as bill_code From sys_bill_max_separate with(nolock)
                    Where within_code='0000' and bill_id ='SI01' and year_month ='{0}' AND bill_text1 ='{1}' AND bill_text2 ='{2}'", str_ym, strWareHouse, strBill_type);
                    DataTable dt = clsConErp.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        //string bill_code = (Convert.ToInt32(dt.Rows[0]["bill_code"].ToString())).ToString("00000") ;
                        txtID.Text = strWareHouse + strBill_type + str_ym.Trim() + (int.Parse(dt.Rows[0]["bill_code"].ToString())).ToString("00000");
                    }
                    else
                    {
                        txtID.Text = String.Format("{0}{1}{2}00001", strWareHouse, strBill_type, str_ym.Trim());
                    }
                }
                else
                    txtID.Text = "";
            } 
        }

       

        /// <summary>
        /// 計算主檔金額
        /// </summary>
        private void Count_Amount()
        {
            decimal total_amount, goods_amount=0, fare_amount=0, cur_row_amount, disc_rate, disc_amt, disc_spare_amount; 
            
            txtLinkman.Focus();

            dgvDetails.CloseEditor();//此行很重要,輸入值立即有較
            dgvFare.CloseEditor();
            int curRow = 0;
            //貨品金額
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                curRow = dgvDetails.GetRowHandle(i);                
                if (dgvDetails.GetRowCellValue(curRow, "is_free").ToString() == "False") //非免費
                {
                    if (!string.IsNullOrEmpty(dgvDetails.GetRowCellValue(curRow, "total_sum").ToString()))
                        cur_row_amount = decimal.Parse(dgvDetails.GetRowCellValue(curRow, "total_sum").ToString());
                    else                       
                        cur_row_amount = 0;                   
                    goods_amount = decimal.Parse(Math.Round(goods_amount + cur_row_amount, 2).ToString());
                }
            }           
            //附加費            
            for (int i = 0; i < dgvFare.RowCount; i++)
            {
                curRow = dgvFare.GetRowHandle(i);
                if (dgvFare.GetRowCellValue(curRow, "is_free").ToString() == "False") //非免費
                {
                    if (!string.IsNullOrEmpty(dgvFare.GetRowCellValue(curRow, "fare_sum").ToString()))
                        cur_row_amount = decimal.Parse(dgvFare.GetRowCellValue(curRow, "fare_sum").ToString());
                    else                       
                        cur_row_amount = 0;
                    fare_amount =decimal.Parse(Math.Round(fare_amount + cur_row_amount,2).ToString());
                }
            }
            //貨品總金額折扣
            if (string.IsNullOrEmpty(txtDisc_rate.Text))               
                disc_rate = 0;
            else                
                disc_rate = decimal.Parse(txtDisc_rate.Text);           
            disc_amt = decimal.Parse(Math.Round(goods_amount * (disc_rate / 100), 2).ToString());
            disc_spare_amount = decimal.Parse(Math.Round(goods_amount - disc_amt, 2).ToString());//折扣后總額

            //總金額
            total_amount = decimal.Parse(Math.Round(disc_spare_amount + fare_amount,2).ToString());

            txtgoods_sum.Text = goods_amount.ToString();
            txtDisc_spare.Text = disc_spare_amount.ToString();
            txtDisc_amt.Text = disc_amt.ToString();
            txtOther_fare.Text = fare_amount.ToString();
            txtTotal_sum.Text = total_amount.ToString();
        }

        private void clAc_qty_Leave(object sender, EventArgs e)
        {
            Count_Other_Row_Amount();
        }

        private void clAc_price_Leave(object sender, EventArgs e)
        {
            Count_Other_Row_Amount();
        }

        /// <summary>
        /// 計算附加費當前行金額公式
        /// </summary>
        private void Count_Other_Row_Amount()
        {
            if (dgvFare.RowCount > 0)
            {
                dgvFare.CloseEditor();//此行很重要,輸入值立即有較
                int qty;
                int cur_row = dgvFare.FocusedRowHandle;
                if (!string.IsNullOrEmpty(dgvFare.GetRowCellValue(cur_row, "qty").ToString()))
                {                    
                    qty = int.Parse(dgvFare.GetRowCellValue(cur_row, "qty").ToString());
                }
                else
                    qty = 0;
                float price;
                if (!string.IsNullOrEmpty(dgvFare.GetRowCellValue(cur_row, "Price").ToString()))
                    price = float.Parse(dgvFare.GetRowCellValue(cur_row, "Price").ToString());
                else
                    price = 0.00f;
                dgvFare.SetRowCellValue(cur_row, "fare_sum", decimal.Parse(Math.Round(qty * price, 2).ToString()));                
            }
            Count_Amount();
        }

        /// <summary>
        /// 計算明細當前行金額公式
        /// </summary>
        private void Count_Details_Row_Amount()
        {
            dgvDetails.CloseEditor();//此行重要
            int send_qty, cur_row,rate_price_unit;
            float price,total_sum,disc_rate,disc_price,disc_amt,finish_amt;
            cur_row = dgvDetails.FocusedRowHandle;
            string goods_unit,price_unit;
            goods_unit = dgvDetails.GetRowCellValue(cur_row, "goods_unit").ToString();
            price_unit = dgvDetails.GetRowCellValue(cur_row, "p_unit").ToString();

            if (!string.IsNullOrEmpty(dgvDetails.GetRowCellValue(cur_row, "u_invoice_qty").ToString()))            
                send_qty = int.Parse(dgvDetails.GetRowCellValue(cur_row, "u_invoice_qty").ToString());            
            else
                send_qty = 0;

            float send_qty_convert = 0.00f;
            if (send_qty > 0)
            {
                if (goods_unit != price_unit)//送貨數量單位與單價單位不一致時需做轉換
                {
                    rate_price_unit = 1;
                    //單價單位匯率
                    for (int i = 0; i < dtRate.Rows.Count; i++)
                    {
                        if (dtRate.Rows[i]["unit_code"].ToString() == price_unit)
                        {
                            rate_price_unit = int.Parse(dtRate.Rows[i]["rate"].ToString());
                            break;
                        }
                    }
                    //計算出貨數量轉成PCS再轉成與單價單位一致的單位
                    for (int i = 0; i < dtRate.Rows.Count; i++)
                    {
                        if (dtRate.Rows[i]["unit_code"].ToString() == goods_unit)
                        {
                            send_qty_convert = (send_qty * float.Parse(dtRate.Rows[i]["rate"].ToString())) / rate_price_unit;
                            break;
                        }
                    }
                }
                else
                {
                    send_qty_convert = send_qty;
                }

                if (goods_unit == "" || price_unit == "")
                {
                    send_qty_convert = 0;//作此處理以免算出出誤的金額
                }
            }
            
            if (!string.IsNullOrEmpty(dgvDetails.GetRowCellValue(cur_row, "invoice_price").ToString()))
                price = float.Parse(dgvDetails.GetRowCellValue(cur_row, "invoice_price").ToString());
            else
                price = 0.00f;
            //未計算折扣前貨品總金額
            total_sum = float.Parse(Math.Round(send_qty_convert * price, 2).ToString());

            //折后單價=銷售單價*折扣率            
            if (!string.IsNullOrEmpty(dgvDetails.GetRowCellValue(cur_row, "disc_rate").ToString()))
                disc_rate = float.Parse(dgvDetails.GetRowCellValue(cur_row, "disc_rate").ToString());
            else
                disc_rate = 0.00f;
            if (disc_rate == 0)
            {
                disc_price = price;
                disc_amt = 0;
            }
            else
            {                
                disc_price = float.Parse(Math.Round(price * (1 - disc_rate / 100), 3).ToString());
                //折扣額=貨品總金額*折扣率
                disc_amt = float.Parse(Math.Round(total_sum * (disc_rate / 100), 2).ToString()); ;
            }

            //計算折扣后貨品總金額
            finish_amt = float.Parse(Math.Round(disc_price * send_qty_convert, 2).ToString());

            dgvDetails.SetRowCellValue(cur_row, "disc_price", disc_price);
            dgvDetails.SetRowCellValue(cur_row, "disc_amt", disc_amt);
            dgvDetails.SetRowCellValue(cur_row, "total_sum", finish_amt);
            Count_Amount();
        }

        private void clSend_qty_Leave(object sender, EventArgs e)
        {
            Count_Details_Row_Amount();//發貨數量
        }

        private void clSend_qty_unit_Leave(object sender, EventArgs e)
        {
            Count_Details_Row_Amount();//數量單位
        }

        private void clPrice_Leave(object sender, EventArgs e)
        {           
            Count_Details_Row_Amount();//單價           
        }

        private void clPrice_unit_Leave(object sender, EventArgs e)
        {           
            Count_Details_Row_Amount();//單價單位
        }

        private void clDisc_rate_Leave(object sender, EventArgs e)
        {
            Count_Details_Row_Amount();//折扣率
        }

        private void clChk_is_free_CheckedChanged(object sender, EventArgs e)
        {
            Count_Amount();//是否免費
        }
        
        private void clAc_Chk_isFree_CheckedChanged(object sender, EventArgs e)
        {
            Count_Amount();//附加費是否免費
        }

        private void txtDisc_rate_Leave(object sender, EventArgs e)
        {
            //貨品總金額折扣
            float goods_amount,disc_rate, disc_amt;
            if (string.IsNullOrEmpty(txtDisc_rate.Text))
                disc_rate = 0.00f;
            else
                disc_rate = float.Parse(txtDisc_rate.Text);
            if (string.IsNullOrEmpty(txtgoods_sum.Text))
                goods_amount = 0.00f;
            else
                goods_amount = float.Parse(txtgoods_sum.Text); 
            disc_amt = float.Parse(Math.Round(goods_amount * (disc_rate/100), 2).ToString());
            txtDisc_amt.Text = disc_amt.ToString();
            txtTotal_sum.Text = (goods_amount - disc_amt).ToString();//折扣后總額
        }

        private void clMo_id_Leave(object sender, EventArgs e)
        {
            Add_Cust_info();
        }

        /// <summary>
        /// 當明細資料為第一條記錄時，添加主檔資料
        /// </summary>
        private void Add_Cust_info()
        {
            if (mState != "")
            {
                if (dgvDetails.RowCount == 1)
                {
                    string order_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "order_id").ToString();
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
                        lkeSate.EditValue = "0";
                        txtVer.Text = "0";
                        string mo_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id").ToString();
                        //單據類型
                        if (mo_id.Substring(0, 1) == "S")
                            lkeBill_type_no.EditValue = "S";
                        else
                            lkeBill_type_no.EditValue = "U";//L
                        lkeIssues_wh.EditValue = "H";//H出貨倉位
                        GetID_No_HK();

                        lkeIt_customer.EditValue = dt.Rows[0]["it_customer"].ToString();
                        txtName.Text = dt.Rows[0]["cust_name"].ToString();                        
                        txtLinkman.Text = dt.Rows[0]["linkman"].ToString();
                        txtL_phone.Text = dt.Rows[0]["l_phone"].ToString();
                        txtPhone.Text = dt.Rows[0]["l_phone"].ToString();
                        txtFax.Text = dt.Rows[0]["fax"].ToString();
                        lkeArea.EditValue = dt.Rows[0]["area"].ToString();
                        txtEmail.Text = dt.Rows[0]["email"].ToString();
                        txtPo_no.Text = dt.Rows[0]["po_no"].ToString();
                        lkeMerchandiser.EditValue = dt.Rows[0]["merchandiser"].ToString();
                        txtPo_no.Text = dt.Rows[0]["po_no"].ToString();
                        txtMerchandiser_phone.Text = dt.Rows[0]["merchandiser_phone"].ToString();
                        lkeSeller_id.EditValue = dt.Rows[0]["seller_id"].ToString();
                        lkeM_id.EditValue = dt.Rows[0]["m_id"].ToString();
                        txtM_rate.Text = dt.Rows[0]["m_rate"].ToString();
                        txtDisc_rate.Text = dt.Rows[0]["disc_rate"].ToString();
                        lkeP_id.EditValue = dt.Rows[0]["p_id"].ToString();
                        lkePc_id.EditValue = dt.Rows[0]["pc_id"].ToString();
                        lkeFinally_buyer.EditValue = dt.Rows[0]["it_customer"].ToString();

                        txtBill_address.Text =
                            txtName.Text.Trim() + "\r\n" +
                            dt.Rows[0]["customer_address"].ToString().Trim() + "\r\n" +
                            "ATTN:" + txtLinkman.Text.Trim() + "  TEL:" + txtL_phone.Text.Trim() + "\r\n" +
                            "FAX:" + txtFax.Text.Trim() + "  EMAIL:" + txtEmail.Text.Trim();

                        txtAddress.Text = 
                             txtName.Text + "\r\n" +
                             dt.Rows[0]["s_address"].ToString()+ "\r\n" +
                             "ATTN:" + txtLinkman.Text.Trim() + "  TEL:" + txtL_phone.Text.Trim() + "\r\n" +
                             "FAX:" + txtFax.Text.Trim() + "  EMAIL:" + txtEmail.Text.Trim();
                    }
                }
            }
        }

        private void Remove_Repeat() //移除重復的附加費
        {
            if (dgvFare.RowCount < 2)
            {
                return ;
            }
            string strAc_id,strMo_id;
            int curRow,row;
            for (int i = 0; i < dgvFare.RowCount ; i++)
            {
                curRow = dgvFare.GetRowHandle(i);
                strAc_id = dgvFare.GetRowCellValue(curRow, "fare_id").ToString();
                strMo_id = dgvFare.GetRowCellValue(curRow, "mo_id").ToString();
                for (int j = i + 1; j < dgvFare.RowCount ; j++)
                {
                    row = dgvFare.GetRowHandle(j);
                    if (strAc_id == dgvFare.GetRowCellValue(row, "fare_id").ToString() && strMo_id == dgvFare.GetRowCellValue(row, "mo_id").ToString())
                    {
                        dgvFare.SetRowCellValue(row, "repeat_flag", "*");
                    }
                }
            }
           
            for (int i = 0; i < dgvFare.RowCount; i++)
            {
                curRow = dgvFare.GetRowHandle(i);
                if (dgvFare.GetRowCellValue(curRow, "repeat_flag").ToString() == "*")
                {
                    dgvFare.DeleteRow(curRow);//移走當前行                                 
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
            if (txtDat1.Text == "" && txtDat2.Text == ""&&txtCust_id1.Text==""&&txtCust_id2.Text==""&&txtInvoice1.Text==""
                &&txtInvoice2.Text==""&&txtMo_id1.Text ==""&&txtMo_id2.Text==""&& txtOcNo1.Text ==""&&txtOcNo2.Text=="")
            {
                MessageBox.Show("查詢條件不可以為空!", "提示信息");
                return;
            }
            string sql =
            @"Select A.id,convert(nvarchar(10),ship_date,111) as ship_date,A.ver,A.it_customer,A.name ,B.sequence_id,B.mo_id,B.goods_id,B.goods_name,B.u_invoice_qty,B.p_unit,B.order_id
            FROM so_invoice_mostly A with(nolock),so_invoice_details B with(nolock)
            WHERE A.within_code=B.within_code and A.id=B.id and A.ver=B.ver and A.within_code='0000' and A.state='0' ";
            if (txtInvoice1.Text != "")
                sql += string.Format(" AND A.id>='{0}'", txtInvoice1.Text);
            if (txtInvoice2.Text != "")
                sql += string.Format(" AND A.id<='{0}'", txtInvoice2.Text);
            if (txtDat1.Text != "")
                sql += string.Format(" AND A.ship_date>='{0}'", txtDat1.Text);
            if (txtDat2.Text != "")
                sql += string.Format(" AND A.ship_date<='{0}'", txtDat2.Text);
            if (dtOi_date1.Text != "")
                sql += string.Format(" AND A.oi_date>='{0}'", dtOi_date1.Text);
            if (dtOi_date2.Text != "")
                sql += string.Format(" AND A.oi_date<='{0}'", dtOi_date2.Text);
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
                if (txtID.Text != dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString())
                {
                    txtID.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id1"].Value.ToString();
                    txtVer.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["ver1"].Value.ToString();
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

        private void txtOcNo1_Leave(object sender, EventArgs e)
        {
            txtOcNo2.Text = txtOcNo1.Text;
        }
        //東莞D送貨單查詢 ==============END==============


        //手寫單頁面代碼 =============BEGIN =============
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //只處理L組的發票，所以第三個參數是1
            DataTable dtIdFind = clsDgdDeliverGoods.loadDgdDetails(txtFindOc_no.Text.Trim(), txtFindId.Text.Trim(), txtFindMo_id.Text.Trim(),1);
            gcIdDetails.DataSource = dtIdFind;
            if (dtIdFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的記錄!", "提示信息");
            }
        }
        private void btnImput_Click(object sender, EventArgs e)
        {
           InsertToGeo();      
        }

        //過帳
        private void InsertToGeo()
        {
            if (dgvIdDetails.RowCount == 0)
                return;
            if (!clsDeliveryBill.Check_Add_Popedom("frmDeliveryBillToInvoice"))
            {
                MessageBox.Show("當前用戶沒有此操作權限!", "提示信息");
                return;
            }

            dgvIdDetails.CloseEditor();//使打勾起作用

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

            lsModel.Clear();
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    if (!Check_Exists_Invoice(i)) //檢查發票是否存在，如存在再判斷是否加到當前新發票中
                    {
                        soinvoice_details_geo objModel = new soinvoice_details_geo();
                        objModel.ship_date = dgvIdDetails.GetDataRow(i)["ship_date"].ToString();
                        objModel.id = dgvIdDetails.GetDataRow(i)["id"].ToString().Trim();
                        objModel.mo_id = dgvIdDetails.GetDataRow(i)["mo_id"].ToString().Trim();
                        objModel.goods_id = dgvIdDetails.GetDataRow(i)["goods_id"].ToString().Trim();
                        objModel.goods_name = dgvIdDetails.GetDataRow(i)["goods_name"].ToString().Trim();
                        objModel.sequence_id = dgvIdDetails.GetDataRow(i)["sequence_id"].ToString().Trim();
                        objModel.u_invoice_qty = int.Parse(dgvIdDetails.GetDataRow(i)["u_invoice_qty"].ToString());//送貨數量
                        objModel.goods_unit = dgvIdDetails.GetDataRow(i)["goods_unit"].ToString().Trim();
                        objModel.sec_qty = float.Parse(dgvIdDetails.GetDataRow(i)["sec_qty"].ToString());//重量
                        objModel.sec_unit = dgvIdDetails.GetDataRow(i)["sec_unit"].ToString().Trim();//重量單位
                        objModel.order_id = dgvIdDetails.GetDataRow(i)["order_id"].ToString().Trim();//OC No
                        //dgvIdDetails.GetDataRow(i)["location_id"].ToString().Trim();//出貨倉庫
                        if (objModel.mo_id.Substring(0, 1) != "S")
                            objModel.location_id = "Y10";
                        else
                            objModel.location_id = "Y1B";
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
                        lsModel.Add(objModel);
                    }
                }
            }            

            tabControl1.SelectTab(0);//跳至第一頁
            if (mState == "NEW" || mState == "EDIT")//已點擊新增或編號
            {
                Add_Delivery_Data();
                Count_Amount();
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
                Count_Amount();
                //Save();
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

        //將選中的記錄插入ERP發票資料表中
        private void Add_Delivery_Data()
        {
            if (lsModel.Count > 0)
            {
                bool shipment_suit;
                string strsql, sql_fare, sql_f, result;
                decimal sec_qty = 0;
                DataTable dtOther = new DataTable();
                DataTable dtMo = new DataTable();
                dgvDetails.OptionsBehavior.Editable = true;//可編輯
                dgvFare.OptionsBehavior.Editable = true;//可編輯
                ColumnView view;
                foreach (soinvoice_details_geo objModel in lsModel)
                {
                    dgvDetails.AddNewRow();//新增

                    view = (ColumnView)dgvDetails;//初始單元格焦點
                    view.FocusedColumn = view.Columns["mo_id"];
                    view.Focus();

                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "order_id", objModel.order_id);//OC No
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", objModel.mo_id);
                    if (dgvDetails.RowCount == 1)
                    {
                        Add_Cust_info();//添加主表客戶相關信息
                        dtShip_date.EditValue = objModel.ship_date;
                        //btePackinglistno.Text = objModel.id;
                        //lkeMo_group.EditValue = (objModel.mo_id).Substring(2, 1);
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "currency", lkeM_id.EditValue.ToString());
                        if (lkeM_id.EditValue.ToString() == "HKD")
                        {
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "exchange_rate", 4);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "m_rate", 1);
                        }
                        else
                        {
                            if (lkeM_id.EditValue.ToString() == "USD")
                            {
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "exchange_rate", 2);
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "m_rate", 7.8);
                            }
                            else
                            {
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "exchange_rate", 1);
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "m_rate", 0);
                            }
                        }
                    }
                    else
                    {
                        if (lkeM_id.EditValue.ToString() == "HKD")
                        {
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "exchange_rate", 1);
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "m_rate", 0);
                        }
                        else
                        {
                            if (lkeM_id.EditValue.ToString() == "USD")
                            {
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "exchange_rate", 2);
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "m_rate", 7.8);
                            }
                            else
                            {
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "exchange_rate", 1);
                                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "m_rate", 0);
                            }
                        }
                    }
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "ver", txtVer.Text);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount + 1).ToString("0000") + "h");
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_unit", "KG");
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_free", false);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id", objModel.goods_id);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_name", objModel.goods_name);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "u_invoice_qty", objModel.u_invoice_qty);//送貨數量
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "goods_unit", objModel.goods_unit);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_qty", objModel.sec_qty);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_unit", objModel.sec_unit);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "contract_cid", objModel.contract_cid);//PO/NO                    
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "location_id", objModel.location_id);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "customer_goods", objModel.customer_goods);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "customer_color_id", objModel.customer_color_id);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "so_ver", objModel.so_ver);//??原始表為int
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "so_sequence_id", objModel.so_sequence_id);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "table_head", objModel.table_head);//款號
                    if (objModel.shipment_suit == "1")
                        shipment_suit = true;
                    else
                        shipment_suit = false;
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "shipment_suit", shipment_suit);//套件
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "is_print", objModel.is_print);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "package_num", objModel.package_num);//包數 原始表為整數
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "box_no", objModel.box_no);//箱號
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "remark", objModel.remark);//備註
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "delivery_id", objModel.id);//手寫送貨單號
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "seq", objModel.sequence_id);//手寫送貨單號序號  

                    //取OC單價及金額
                    strsql = string.Format(
                    @"Select Convert(int,B.order_qty) as order_qty,B.unit_price,B.p_unit,B.disc_rate,B.disc_amt,B.total_sum
                    From so_order_manage A with(nolock),so_order_details B with(nolock)
                    WHERE A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver AND A.state NOT IN('2','V') AND A.id='{0}' and B.mo_id='{1}'",
                    objModel.order_id, objModel.mo_id);
                    dtMo = clsConErp.ExecuteSqlReturnDataTable(strsql);
                    if (dtMo.Rows.Count > 0)
                    {
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "invoice_price", dtMo.Rows[0]["unit_price"]);//單價
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "p_unit", dtMo.Rows[0]["p_unit"].ToString());//單價單位
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "disc_rate", dtMo.Rows[0]["disc_rate"]);//折扣率
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "disc_amt", dtMo.Rows[0]["disc_amt"]);//折扣額
                        //dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "total_sum", dtMo.Rows[0]["total_sum"]);//總金額
                        //折后單價
                        if (float.Parse(dtMo.Rows[0]["disc_rate"].ToString()) == 0)
                        {
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "disc_price", dtMo.Rows[0]["unit_price"]);
                        }
                        else
                        {
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "disc_price",
                              decimal.Parse(Math.Round(float.Parse(dtMo.Rows[0]["unit_price"].ToString()) * (1 - float.Parse(dtMo.Rows[0]["disc_rate"].ToString()) / 100), 3).ToString()));
                        }

                        //分批走貨時重新計算頁數金額 modify in 2018-06-26 
                        if (int.Parse(objModel.u_invoice_qty.ToString()) == int.Parse(dtMo.Rows[0]["order_qty"].ToString()))
                        {
                            //走貨數量等于訂單數量直接取訂單的金額
                            dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "total_sum", dtMo.Rows[0]["total_sum"]);//計算明細頁數金額
                        }
                        else
                        {
                            //走貨數量不等于訂單數量，所以重新計算出金額
                            Count_Details_Row_Amount();
                        }


                    }

                    //====取重量====
                    sec_qty = get_warehouse_qty(objModel.location_id, objModel.goods_id, objModel.mo_id, int.Parse(objModel.u_invoice_qty.ToString()), objModel.goods_unit);
                    if (sec_qty > 0)
                    {
                        dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_qty", sec_qty);
                    }
                    //==============
                    //添加附加費
                    sql_fare = string.Format(
                    @"Select fare_id,name,cast(qty as int) as qty,price,fare_sum,'0' as is_free,remark,'0' as sum_kind
                    From so_other_fare with(nolock) 
                    Where within_code='0000' and id='{0}' AND mo_id='{1}' and Isnull(fare_sum,0)>0", objModel.order_id, objModel.mo_id);
                    dtOther = clsConErp.ExecuteSqlReturnDataTable(sql_fare);
                    if (dtOther.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtOther.Rows.Count; i++)
                        {
                            //同一頁數、附加費編號只能出現一次,以避免分批走貨收取多次附加費
                            sql_f = string.Format(
                            @"Select '1' From so_invoice_other_fare with(nolock)
                            Where within_code='0000' and fare_id='{0}' AND mo_id='{1}' and Isnull(fare_sum,0)>0", dtOther.Rows[i]["fare_id"], objModel.mo_id);
                            result = clsConErp.ExecuteSqlReturnObject(sql_f);
                            if (result == "")
                            {
                                AddNew_other_fare_Item();
                                view = (ColumnView)dgvFare;//初始單元格焦點
                                view.FocusedColumn = view.Columns["mo_id"];
                                view.Focus();
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "fare_id", dtOther.Rows[i]["fare_id"].ToString());
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "name", dtOther.Rows[i]["name"].ToString());
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "qty", dtOther.Rows[i]["qty"]);
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "Price", dtOther.Rows[i]["price"]);
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "fare_sum", dtOther.Rows[i]["fare_sum"]);
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "mo_id", objModel.mo_id);
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "remark", dtOther.Rows[i]["remark"].ToString());
                                dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "sum_kind", dtOther.Rows[i]["sum_kind"].ToString());
                                if (dtOther.Rows[i]["is_free"].ToString() == "0")
                                    dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "is_free", false);
                                else
                                    dgvFare.SetRowCellValue(dgvFare.FocusedRowHandle, "is_free", true);
                            }
                        }
                        Remove_Repeat();
                    }
                }
            }
        }

        /// <summary>
        /// 取倉庫貨品重量
        /// </summary>
        /// <param name="sLocation_id"></param>
        /// <param name="sGoods_id"></param>
        /// <param name="sMo_id"></param>
        /// <param name="iQty"></param>
        /// <param name="sUnit"></param>
        /// <returns></returns>
        private decimal get_warehouse_qty(string sLocation_id,string sGoods_id,string sMo_id,int iQty,string sUnit)
        {
            decimal return_sec_qty=0;

            string sql_qty = string.Format("Select dbo.fn_z_Get_pcs_qty({0},'{1}') as qty_pcs",iQty,sUnit);
            dtqty = clsConErp.GetDataTable(sql_qty);
            int qty_pcs = int.Parse(dtqty.Rows[0]["qty_pcs"].ToString());
            string sql_sec_qty = string.Format(
              @"Select convert(int,sum(qty)) as qty,sum(sec_qty) as sec_qty
                FROM st_details_lot with(nolock) 
                Where within_code='0000' and location_id='{0}' and carton_code='{0}' and goods_id='{1}' and mo_id='{2}'
                group by location_id,goods_id,mo_id",sLocation_id,sGoods_id,sMo_id);
            dt_st_qty = clsConErp.GetDataTable(sql_sec_qty);
            int st_qty;
            decimal st_sec_qty;
            if (dt_st_qty.Rows.Count > 0)
            {
                st_qty = int.Parse(dt_st_qty.Rows[0]["qty"].ToString());   
                st_sec_qty = decimal.Parse(dt_st_qty.Rows[0]["sec_qty"].ToString());
                if (qty_pcs == st_qty)
                    return_sec_qty = st_sec_qty;
                else
                {
                    return_sec_qty = Math.Round(decimal.Parse(((qty_pcs * st_sec_qty)/st_qty).ToString()),2);
                }
            }
            return return_sec_qty;
        }

        private bool Check_Exists_Invoice(int iRowHandle)
        {
            bool flag = false;
            DialogResult result;
            string strInvNo = clsDgdDeliverGoods.Get_Invoice_No(
                dgvIdDetails.GetDataRow(iRowHandle)["mo_id"].ToString(),
                dgvIdDetails.GetDataRow(iRowHandle)["goods_id"].ToString(),
                dgvIdDetails.GetDataRow(iRowHandle)["order_id"].ToString());
            if (mState == "NEW")
            {
                if (strInvNo != "")
                {
                    result = MessageBox.Show(string.Format("已開過發票：「{0}」" + "\n\r\n\r 當前頁數是否確定要開在另一張新的發票中?", strInvNo), "提示信息",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        dgvIdDetails.SetRowCellValue(iRowHandle, "is_select", false);
                        dgvIdDetails.CloseEditor();
                        flag = true;
                    }
                }
            }
            else //EDIT
            {
                if (strInvNo != "")
                {
                    if (strInvNo != txtID.Text)
                    {
                        result = MessageBox.Show(string.Format("已開過發票：「{0}」" + "\n\r\n\r 是否確定將當前頁數添加到另一張新的發票「{1}」中?", strInvNo, txtID.Text), "提示信息",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            dgvIdDetails.SetRowCellValue(iRowHandle, "is_select", false);
                            dgvIdDetails.CloseEditor();
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        private void dgvIdDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if(!flag_remove)
               loadOcDgdDetails(dgvIdDetails.FocusedRowHandle);
        }

        private void loadOcDgdDetails(int row)
        {
            string ocno = dgvIdDetails.GetRowCellValue(row, "order_id").ToString();
            DataTable dtOc = clsDgdDeliverGoods.loadOcDgdDetails(ocno);
            gcOcDgdDetails.DataSource = dtOc;
        }

        /// <summary>
        /// 更改HK ERP的最大單據編號
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <param name="isProce"></param>
        /// <returns></returns>
        private static int Update_HK_Bill_MaxNo(string strSql,SqlParameter[] paras, bool isProce)
        {
            string strConn_hk = DBUtility.conn_str_hkerp1;
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn_hk))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand() { 
                        Connection = conn, 
                        CommandText = strSql 
                    };
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    if (isProce)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    Result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 取HK發票最大單據序號
        /// </summary>
        private void GetID_No_HK()
        {
            if (mState != "")
            {
                string strWareHouse = lkeIssues_wh.EditValue.ToString();
                string strBill_type = lkeBill_type_no.EditValue.ToString();
                if (strWareHouse == "H" && strBill_type != "")
                {
                    string sql =
                    @"Select substring(cast(year(GETDATE()) as CHAR),3,2)+
                    CASE month(GETDATE()) 
                    WHEN 10 THEN 'A' 
                    WHEN 11 THEN 'B'
                    WHEN 12 THEN 'C' 
                    ELSE CAST(month(GETDATE()) as CHAR) END as ym";
                    string str_ym = clsConErp.ExecuteSqlReturnObject(sql).Trim();

                    sql = string.Format(
                    @"Select CAST(substring(bill_code,6,5) as int)+1 as bill_code From sys_bill_max_separate with(nolock)
                    Where within_code='0000' and bill_id ='SI01' and year_month ='{0}' AND bill_text1 ='{1}' AND bill_text2 ='{2}'", str_ym, strWareHouse, strBill_type);
                    DataTable dt = GetDataTable_HK(sql);
                    if (dt.Rows.Count > 0)
                    {
                        //string bill_code = (Convert.ToInt32(dt.Rows[0]["bill_code"].ToString())).ToString("00000");
                        txtID.Text = strWareHouse + strBill_type + str_ym.Trim() + (int.Parse(dt.Rows[0]["bill_code"].ToString())).ToString("00000");
                    }
                    else
                    {
                        txtID.Text = String.Format("{0}{1}{2}00001", strWareHouse, strBill_type, str_ym.Trim());
                    }
                }
                else
                    txtID.Text = "";
            }
        }

        /// <summary>
        /// 聯接香港服務器
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        private static DataTable GetDataTable_HK(string strSQL)
        {
            string strConn_hk = @"server=192.168.168.15;database =cferp;uid =sa;pwd=268709;";//DBUtility.conn_str_hkerp1;
            DataTable dtData = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn_hk))
                {

                    SqlDataAdapter sda = new SqlDataAdapter(strSQL, conn);
                    sda.Fill(dtData);
                    sda.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtData;
        }

        private void txtInvoice1_Leave(object sender, EventArgs e)
        {
            txtInvoice2.Text = txtInvoice1.Text;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvIdDetails.RowCount > 0)
            {
                for (int i = 0; i < dgvIdDetails.RowCount; i++)
                {
                    dgvIdDetails.SetRowCellValue(i, "is_select", chkSelectAll.Checked);
                }
                dgvIdDetails.CloseEditor();
            }
            else
                chkSelectAll.Checked = false;
        }

        
        
        //手寫單頁面代碼 =============END=============


	}
}
