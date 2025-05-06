//*************************************************
//**此畫面C組阿華使用，將手寫單轉換成東莞D的送貨單格式
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
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;


namespace cf01.Forms
{
	public partial class frmTransferout : Form
	{
        clsPublicOfGEO clsConErp = new clsPublicOfGEO();
		string mID = "";    //臨時的主鍵值
		string mState = ""; //新增或編輯的狀態
		string language = "0";
		bool save_flag;        
        string current_date = "";
        string temp_mo_id = ""; //暫存更改前的值
        string temp_suit = ""; //暫存更改前的值
        string temp_goods_id = ""; //暫存更改前的值
        decimal temp_transfer_amount = 0;


        DataTable dtMostly = new DataTable();
		DataTable dtDetails = new DataTable();
        DataTable dtPart = new DataTable();
		DataTable dtTempDel1 = new DataTable();
        DataTable dtTempDel2 = new DataTable();
        DataTable dtFindDate = new DataTable();
        DataTable dtStockAdj = new DataTable();
        BindingSource bds1 = new BindingSource();
        BindingSource bds2 = new BindingSource();
        DataSet dtsTrans = new DataSet();

        private List<soinvoice_details_geo> lsModel = new List<soinvoice_details_geo>();

		public frmTransferout()
		{
			InitializeComponent();

            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

			language = DBUtility._language;
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();
		}

		private void frmTransferout_Load(object sender, EventArgs e)
		{
            //數量單位
            DataTable dtUnit = clsConErp.GetDataTable(@"SELECT unit_code AS id,'' as cdesc,Cast(rate as int) as rate From it_coding where within_code='0000' and id='*' and basic_unit='PCS'");
            clQtyUnit.DataSource = dtUnit;
            clQtyUnit.ValueMember = "id";
            clQtyUnit.DisplayMember = "id";

            //**********************
            //狀態
            DataTable dtDept = new DataTable();
            DataRow row = dtDept.NewRow();
            dtDept.Columns.Add("id", typeof(string));
            dtDept.Columns.Add("cdesc", typeof(string));
            row["id"] = "";
            row["cdesc"] = "";
            dtDept.Rows.Add(row);
            row = dtDept.NewRow();
            row["id"] = "601";
            row["cdesc"] = "包裝部(東莞)";
            dtDept.Rows.Add(row);
            lkeDepartment_id.Properties.DataSource = dtDept;
            lkeDepartment_id.Properties.ValueMember = "id";
            lkeDepartment_id.Properties.DisplayMember = "cdesc";

            //單據種類
            DataTable dtBillType = clsConErp.GetDataTable(@"SELECT id,id+'('+name+')' as cdesc FROM cd_mo_type WHERE mo_type='4' And state='0' Order By id");            
            lkeBill_type_no.Properties.DataSource = dtBillType;
            lkeBill_type_no.Properties.ValueMember = "id";
            lkeBill_type_no.Properties.DisplayMember = "cdesc";

            lkebill_type_no1.Properties.DataSource = dtBillType;
            lkebill_type_no1.Properties.ValueMember = "id";
            lkebill_type_no1.Properties.DisplayMember = "cdesc";

            //組別
            DataTable dtGroup = clsConErp.GetDataTable(@"SELECT id,name as cdesc FROM cd_mo_type WHERE mo_type='3' And state='0' Order By id");
            lkeGroupNo.Properties.DataSource = dtGroup;
            lkeGroupNo.Properties.ValueMember = "id";
            lkeGroupNo.Properties.DisplayMember = "cdesc";            

            //狀態
            DataTable dtSate = new DataTable();
            row = dtSate.NewRow();
            dtSate.Columns.Add("id", typeof(string));
            dtSate.Columns.Add("cdesc", typeof(string));
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
            lkeSate.Properties.DataSource = dtSate;
            lkeSate.Properties.ValueMember = "id";
            lkeSate.Properties.DisplayMember = "cdesc";

            //倉位
            DataTable dtWH = clsConErp.GetDataTable(
            @"SELECT id,name As cdesc FROM cd_productline 
            WHERE within_code='0000' AND storehouse_group='DG' AND type='07' or (type='01' and id='601') and state<>'2'
            ORDER BY type DESC,id");
            clLocation_id.DataSource = dtWH;
            clLocation_id.ValueMember = "id";
            clLocation_id.DisplayMember = "id";

            clLocation_id2.DataSource = dtWH;
            clLocation_id2.ValueMember = "id";
            clLocation_id2.DisplayMember = "cdesc";

            current_date = clsConErp.ExecuteSqlReturnObject("Select Convert(nvarchar(10),getdate(),120) as date");
            //***********************

            //生成明細表1,2結構ExcuteSqlReturnDataSet
            FindDoc("");
            //臨時項目刪除表結構
            dtTempDel1 = dtsTrans.Tables[1].Clone();
            dtTempDel2 = dtsTrans.Tables[2].Clone();   

            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                dgvDetails.Columns[i].AppearanceHeader.TextOptions.HAlignment=DevExpress.Utils.HorzAlignment.Center;
            }

            txtDat1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtDat2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

            dtStockAdj.Columns.Add("sequence_id", typeof(string));
            dtStockAdj.Columns.Add("location_id", typeof(string));
            dtStockAdj.Columns.Add("mo_id", typeof(string));
            dtStockAdj.Columns.Add("goods_id", typeof(string));
            dtStockAdj.Columns.Add("adj_qty", typeof(decimal));
            dtStockAdj.Columns.Add("adj_sec_qty", typeof(decimal));
            dtStockAdj.Columns.Add("lot_no", typeof(string));
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
			if (dgvDetails.RowCount == 0)
			{
				return;
			}
			DialogResult result = MessageBox.Show("是否要刪除當前明細資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int curRow = dgvDetails.FocusedRowHandle;
                string mo_id = dgvDetails.GetRowCellDisplayText(curRow, "mo_id");
                string goods_id = dgvDetails.GetRowCellDisplayText(curRow, "goods_id");                

                if (mo_id != "" && goods_id != "")
                {
                    string id_key = dgvDetails.GetRowCellDisplayText(curRow, "idkey");
                    DataRow[] drws = dtsTrans.Tables["dtD2"].Select($"idkey={id_key}");
                    foreach(DataRow dr in drws)
                    {
                        DataRow newRow2 = dtTempDel2.NewRow();                       
                        newRow2["id"] = txtID.Text;
                        newRow2["upper_sequence"] = dgvPart.GetRowCellDisplayText(curRow, "upper_sequence");
                        newRow2["sequence_id"] = dgvPart.GetRowCellDisplayText(curRow, "sequence_id");
                        dtTempDel2.Rows.Add(newRow2);
                    }
                    for (int i = dtsTrans.Tables["dtD2"].Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtsTrans.Tables["dtD2"].Rows[i]["idkey"].ToString() == id_key)
                        {
                            dtsTrans.Tables["dtD2"].Rows[i].Delete();
                        }
                    }
                    //將當前行刪除幷加到臨時表中  
                    DataRow newRow1 = dtTempDel1.NewRow();
                    newRow1["id"] = txtID.Text;
                    newRow1["sequence_id"] = dgvDetails.GetRowCellDisplayText(curRow, "sequence_id");
                    newRow1["mo_id"] = dgvDetails.GetRowCellDisplayText(curRow, "mo_id");
                    newRow1["goods_id"] = dgvDetails.GetRowCellDisplayText(curRow, "goods_id");
                    dtTempDel1.Rows.Add(newRow1);
                }
				dgvDetails.DeleteRow(curRow);//移走當前行
            }
		}

		private void BTNSAVE_Click(object sender, EventArgs e)
		{
			txtRemark.Focus(); //Toolscript焦點問題
			Save();
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void BTNPRINT_Click(object sender, EventArgs e)
		{
            //
		}

		private void BTNFIND_Click(object sender, EventArgs e)
		{
            tabControl1.SelectTab(1);//跳至第二頁
		}

		private void AddNew()  //新增
		{
			mState = "NEW";
			txtID.Focus();
			SetButtonSatus(false);
            Set_Grid_Status(true);
            SetObjValue.SetEditBackColor(this.tabPage1.Controls, true);
			SetObjValue.ClearObjValue(this.tabPage1.Controls, "1");            
            lkeSate.Enabled = false ;
            lkeSate.BackColor = System.Drawing.Color.White;
            DataRow dr = dtMostly.NewRow(); //插一空行
            dtMostly.Rows.InsertAt(dr, 0);

            dtTransfer_date.EditValue = current_date;
            lkeGroupNo.EditValue = "";
            lkeBill_type_no.EditValue = "";
            lkeSate.EditValue = "0";
            txtCreate_by.Text = DBUtility._user_id;
         
			//dtDetails.Clear();
			//gridControl1.DataSource = dtDetails;
            //dtPart.Clear();
            //gridControl2.DataSource = dtPart;
            tabControl1.SelectTab(0);           
        }

		private void Edit()  //編輯
		{
			if (txtID.Text == "")
			{
				return;
			}
            if (lkeSate.EditValue.ToString() == "1")
            {
                MessageBox.Show("注意：已是批準狀態，當前操作無效!", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
			SetButtonSatus(false);
            SetObjValue.SetEditBackColor(this.tabPage1.Controls, true);
			Set_Grid_Status(true);
			mState = "EDIT";

			txtID.Properties.ReadOnly = true;
			txtID.BackColor = System.Drawing.Color.White;			
            lkeSate.Enabled = false;
            lkeSate.BackColor = System.Drawing.Color.White;
			
            lkeBill_type_no.Enabled = false;
            lkeBill_type_no.BackColor = System.Drawing.Color.White;
            lkeGroupNo.Enabled = false;
            lkeGroupNo.BackColor = System.Drawing.Color.White;
            tabControl1.SelectTab(0);
        }

		private void SetButtonSatus(bool _flag) //設置工具欄
		{
			BTNNEW.Enabled = _flag;
			BTNEDIT.Enabled = _flag;
			BTNPRINT.Enabled = _flag;
			BTNDELETE.Enabled = _flag;
			BTNFIND.Enabled = _flag;
            BTNAPPROVE.Enabled = _flag;
            BTNCHECKST.Enabled = _flag;
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
			dgvPart.OptionsBehavior.Editable = _flag;                       
		}

		private void Delete() //注銷主檔
		{
			if (string.IsNullOrEmpty(txtID.Text))
			{
				return;
			}           
            if (lkeSate.EditValue.ToString() == "1")
            {
                MessageBox.Show("注意：已是批準狀態，當前操作無效!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("確定要注銷此轉出單？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
                if (clsTransferout.DelTransferOut(txtID.Text) >= 0)
                {
                    FindDoc(txtID.Text);
                    MessageBox.Show("注銷成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("注銷失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}

        /// <summary>
        /// 添加明細表新行
        /// </summary>
		private void AddNewItem()
		{
			if (!string.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
			{
                if (!SaveBeforeValidDetail())
                {
                    return;
                }
                Set_Grid_Status(true);
                string seq_id = getMaxSeqId();
                temp_suit = "True";                
                DataRow drw = dtsTrans.Tables["dtD1"].NewRow();
                drw["id"] = txtID.Text;
                drw["sequence_id"] = seq_id;
                drw["unit"] = "PCS";
                drw["sec_unit"] = "KG";
                drw["package_num"] = 0;
                drw["shipment_suit"] = true;
                drw["transfer_amount"] = 0.00;
                drw["sec_qty"] = 0.00;
                drw["nwt"] = 0.00;
                drw["gross_wt"] = 0.00;
                string location_id = this.SetLocation(true);
                drw["location_id"] = location_id;
                drw["carton_code"] = location_id;
                drw["move_location_id"] = location_id;
                drw["move_carton_code"] = location_id;
                drw["idkey"] = txtID.Text + seq_id;
                drw["new_flag"] = "0";
                dtsTrans.Tables["dtD1"].Rows.Add(drw);
                bds1.DataSource = dtsTrans.Tables["dtD1"];
                gridControl1.DataSource = bds1;

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

        private string SetLocation(bool suit)
        {
            string location = "";           
            if(suit)
            {
                string billTypeNo = lkeBill_type_no.EditValue.ToString();
                switch (billTypeNo)
                {
                    case "DN":
                    case "SN":
                        location = "801";
                        break;
                    case "JN":
                        location = "JX0";
                        break;
                    case "LN":
                        location = "D00";
                        break;
                    case "VN":
                        location = "T00";
                        break;
                }
            }
            else
            {
                location = "601";
            }            
            return location;
        }

        private string getMaxSeqId()
        {         
            List<string> seqList = new List<string>(); // 创建一个字符串列表
            for (int i = 0; i < dtsTrans.Tables["dtD1"].Rows.Count; i++)
            {
                seqList.Add(dtsTrans.Tables["dtD1"].Rows[i]["sequence_id"].ToString()); // 添加元素
            }
            string seq_id = "";
            if (seqList.Count > 0)
            {
                seq_id = seqList.Max();
                seq_id = (int.Parse(seq_id.Substring(0, 4)) + 1).ToString("0000") + "h";
            }
            else
            {
                seq_id = "0001h";
            }
            return seq_id;
        }

		private bool SaveBeforeValidDetail() //檢查明細資料的有效性
		{		
			bool flag = true;
           
			if (dgvDetails.RowCount > 0)
			{
				txtRemark.Focus();
                dgvDetails.CloseEditor(); //編輯的值有效
                //因toolStrip控件焦點問題
                //設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，防止取到的值爲空
                int curRow = 0;
                string goodsId = "", moId = "", strF0 = "", sql_f = "", id = "", msg = "";
                decimal qtyOther = 0, orderQty = 0, qty = 0;
                DataTable tbl = new DataTable();
                for (int i = 0; i < dgvDetails.RowCount; i++)
				{
					curRow = dgvDetails.GetRowHandle(i);
                    if (string.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "mo_id")) || string.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "goods_id")))
					{
                        msg = $"第[ {(i + 1).ToString()} ]行，頁數或貨品編碼不可爲空!";
                        MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        flag = false;
                        ColumnView view1 = (ColumnView)dgvDetails;
						view1.FocusedColumn = view1.Columns["mo_id"]; //設置單元格焦點                        
						break;
					}
                    //判断页数对应的F0编号是否在生产计划单中存在,假如销售订单中修改过F0,在相应的生产计划单中会有新旧两个F0
                    moId = dgvDetails.GetRowCellDisplayText(curRow, "mo_id");
                    goodsId = dgvDetails.GetRowCellDisplayText(curRow, "goods_id");
                    qty = decimal.Parse(dgvDetails.GetRowCellValue(curRow, "transfer_amount").ToString());
                    if (goodsId.Substring(0,3) == "F0-") //只判断为F0的货品编号情况
                    {
                        sql_f = string.Format(
                        @"Select B.goods_id
			            From jo_bill_mostly A with(nolock),jo_bill_goods_details B with(nolock)
			            Where A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And
                         A.within_code='{0}' And A.mo_id ='{1}' And B.goods_id='{2}' And
						 A.state Not In('2','V') And LEFT(B.goods_id,3)='F0-'", "0000", moId, goodsId);
                        strF0 = clsConErp.ExecuteSqlReturnObject(sql_f);
                        if (strF0 == "")
                        {
                            msg = $"[ {moId} ]當前頁數對應的F0与銷售訂單中頁數对應的F0不一致!";
                            MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = false;
                            break;
                        }
                    }

                    // 3.检查是否超过订单数量 Into :ldec_qty_other
                    id = dgvDetails.GetRowCellDisplayText(curRow, "id");
                    sql_f = string.Format(
                    @"Select Sum(D.transfer_amount) AS transfer_amount                   
                    From st_transfer_mostly M with(nolock) Inner Join st_transfer_detail D with(nolock) On M.within_code=D.within_code And M.id=D.id
                    Where M.type='0' And M.state Not In('2','V') And D.within_code='{0}' And D.id<>'{1}' And D.mo_id='{2}' And D.goods_id='{3}'",
                    "0000", id, moId, goodsId);
                    tbl = clsConErp.GetDataTable(sql_f);
                    qtyOther = string.IsNullOrEmpty(tbl.Rows[0]["transfer_amount"].ToString()) ? 0 : decimal.Parse(tbl.Rows[0]["transfer_amount"].ToString());
                    if(dgvDetails.GetRowCellValue(curRow, "shipment_suit").ToString()=="True")
                    {
                        sql_f = string.Format(
                        @"Select dbo.FN_CHANGE_UNITBYCV(D.within_code, D.goods_id, D.goods_unit, D.order_qty,'','','/') as order_qty
                        From so_order_manage M with(nolock) Inner Join so_order_details D with(nolock) On M.within_code=D.within_code And M.id=D.id And M.ver=D.ver
                        Where D.within_code='{0}' And D.mo_id='{1}' And D.goods_id='{2}' And M.state Not In('2','V')",
                        "0000", moId, goodsId);
                        tbl = clsConErp.GetDataTable(sql_f);
                        orderQty = (tbl.Rows.Count > 0) ? decimal.Parse(tbl.Rows[0]["order_qty"].ToString()) : 0; 
                    }
                    else
                    {
                        sql_f = string.Format(
                        @"Select dbo.FN_CHANGE_UNITBYCV(D.within_code,D.goods_id,D.goods_unit,D.order_qty,'','','/') as order_qty		               
		                From so_order_manage M with(nolock) Inner Join so_order_details D with(nolock) On M.within_code=D.within_code And M.id=D.id And M.ver=D.ver
						left outer join so_order_bom DD with(nolock) On D.within_code=DD.within_code And D.id=DD.id And D.ver=DD.ver 
						and D.sequence_id = DD.upper_sequence And isnull(DD.primary_key,'') ='1'
		                Where M.state Not In('2','V') And DD.within_code ='{0}'
		                And D.mo_id='{1}' And DD.goods_id='{2}'", "0000",moId,goodsId);
                        tbl = clsConErp.GetDataTable(sql_f);
                        orderQty = (tbl.Rows.Count > 0) ? decimal.Parse(tbl.Rows[0]["order_qty"].ToString()) : 0;
                    }
                    if ((qty + qtyOther) > orderQty)
                    {
                        msg = $"注意：[ {moId} ] 轉出數量已大于訂單數量，是否繼續？";                        
                        if (MessageBox.Show(msg, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            flag = false;
                            break;
                        }
                    }
                } //--for loop
            }
            return flag;
		}

		private void Cancel() //取消
		{
			SetButtonSatus(true);
            SetObjValue.SetEditBackColor(tabPage1.Controls, false);
            SetObjValue.ClearObjValue(tabPage1.Controls, "2");
			Set_Grid_Status(false);
			dtTempDel1.Clear();
            dtTempDel2.Clear();
            dtDetails.Clear();
            dtPart.Clear();

            bds1.CancelEdit();
            bds2.CancelEdit();
            temp_mo_id = "";
            temp_suit = "";
            temp_goods_id = "";
            temp_transfer_amount = 0;
           
            mState = "";
			if (!string.IsNullOrEmpty(mID))
			{
				FindDoc(mID);
			}
            else
            {
                FindDoc("");
            }
		}		

        private void FindDoc(string id)
        {            
            SqlParameter[] paras = {
                new SqlParameter("@id",id) 
            };
            dtsTrans = clsConErp.ExecuteProcedureReturnDataSet("zz_get_transfer_out_data", paras, "");            
            dtsTrans.Tables[0].TableName = "dtMostly";
            dtsTrans.Tables[1].TableName = "dtD1";
            dtsTrans.Tables[2].TableName = "dtD2";
            DataRelation relation = new DataRelation(
            "relation_dtD1_dtD2", //關聯名
            dtsTrans.Tables["dtD1"].Columns["idkey"],
            dtsTrans.Tables["dtD2"].Columns["idkey"]);//false // 若设为false，则禁用外键约束
            dtsTrans.Relations.Add(relation);// 将关系添加到DataSet                       
            bds1.DataSource = dtsTrans;
            bds1.DataMember = "dtD1";
            bds2.DataSource = bds1;
            bds2.DataMember = "relation_dtD1_dtD2";
            gridControl1.DataSource = bds1;
            gridControl2.DataSource = bds2;            
            dtMostly = dtsTrans.Tables["dtMostly"];
            if (dtMostly.Rows.Count > 0)
                Set_Master_Data(dtMostly);
            else
            {
                SetObjValue.ClearObjValue(this.Controls, "2");
                return;
            }
            mID = txtID.Text;//保存臨時的ID號
        }

		private void Save()  //保存
		{
            //檢查主檔資料的完整性
            if (!SaveBeforeValidMaster())
			{
				return;
			}
            //檢查明細資料的有效性         
            if (!SaveBeforeValidDetail())
			{
				return;
			}
			save_flag = false;
            TransferInHead head = new TransferInHead();
            head.id = txtID.Text;
            head.transfer_date = dtTransfer_date.EditValue.ToString();
            head.department_id = lkeDepartment_id.EditValue.ToString();
            head.handler = txtHandler.Text;
            head.remark = txtRemark.Text;
            head.create_by = DBUtility._user_id;
            head.update_by = DBUtility._user_id;
            head.update_count = txtUpdate_count.Text;
            head.state = lkeSate.EditValue.ToString();
            head.bill_type_no = lkeBill_type_no.EditValue.ToString();
            head.group_no = lkeGroupNo.EditValue.ToString();
            head.head_status = mState;           
            string rowStatus = "";
            dgvDetails.CloseEditor();
            dgvPart.CloseEditor();             
            List< TransferInDetails> lstDetailData1 = new List<TransferInDetails>();
            for (int i = 0; i < dtsTrans.Tables["dtD1"].Rows.Count; i++)
            {
                //curRow = dgvDetails.GetRowHandle(i);
                //dgvDetails.AddNewRow();//新增必須初始貨當前單元格焦點
                //否則rowStatus取不到狀態值
                //rowStatus = dgvDetails.GetDataRow(curRow).RowState.ToString();
                rowStatus = dtsTrans.Tables["dtD1"].Rows[i].RowState.ToString();
                if (rowStatus == "Added" || rowStatus == "Modified")
                {
                    TransferInDetails lst1 = new TransferInDetails();
                    lst1.id = head.id;
                    lst1.mo_id = dtsTrans.Tables["dtD1"].Rows[i]["mo_id"].ToString();
                    lst1.sequence_id = dtsTrans.Tables["dtD1"].Rows[i]["sequence_id"].ToString();
                    lst1.goods_id = dtsTrans.Tables["dtD1"].Rows[i]["goods_id"].ToString();
                    lst1.shipment_suit = (dtsTrans.Tables["dtD1"].Rows[i]["shipment_suit"].ToString() == "True") ? true : false;
                    lst1.goods_name = dtsTrans.Tables["dtD1"].Rows[i]["goods_name"].ToString();
                    lst1.unit = dtsTrans.Tables["dtD1"].Rows[i]["unit"].ToString();
                    lst1.transfer_amount = decimal.Parse(dtsTrans.Tables["dtD1"].Rows[i]["transfer_amount"].ToString());
                    lst1.sec_unit = dtsTrans.Tables["dtD1"].Rows[i]["sec_unit"].ToString();
                    lst1.sec_qty = decimal.Parse(dtsTrans.Tables["dtD1"].Rows[i]["sec_qty"].ToString());
                    lst1.package_num = decimal.Parse(dtsTrans.Tables["dtD1"].Rows[i]["package_num"].ToString());
                    lst1.position_first = dtsTrans.Tables["dtD1"].Rows[i]["position_first"].ToString();
                    lst1.nwt = decimal.Parse(dtsTrans.Tables["dtD1"].Rows[i]["nwt"].ToString());
                    lst1.gross_wt = decimal.Parse(dtsTrans.Tables["dtD1"].Rows[i]["gross_wt"].ToString());
                    lst1.location_id = dtsTrans.Tables["dtD1"].Rows[i]["location_id"].ToString();
                    lst1.carton_code = dtsTrans.Tables["dtD1"].Rows[i]["carton_code"].ToString();
                    lst1.lot_no = dtsTrans.Tables["dtD1"].Rows[i]["lot_no"].ToString();
                    lst1.move_location_id = dtsTrans.Tables["dtD1"].Rows[i]["move_location_id"].ToString();
                    lst1.remark = dtsTrans.Tables["dtD1"].Rows[i]["remark"].ToString();
                    lst1.move_location_id = dtsTrans.Tables["dtD1"].Rows[i]["move_location_id"].ToString();
                    lst1.move_carton_code = dtsTrans.Tables["dtD1"].Rows[i]["move_carton_code"].ToString();
                    lst1.row_status = (rowStatus == "Added") ? "NEW" : "EDIT";
                    lstDetailData1.Add(lst1);
                }
            }
            List<TransferDetailPart> lstDetailData2 = new List<TransferDetailPart>();
            for (int i = 0; i < dtsTrans.Tables["dtD2"].Rows.Count; i++)
            {
                rowStatus = dtsTrans.Tables["dtD2"].Rows[i].RowState.ToString();
                if (rowStatus == "Added" || rowStatus == "Modified")
                {
                    TransferDetailPart lst2 = new TransferDetailPart();
                    lst2.id = head.id;
                    lst2.upper_sequence = dtsTrans.Tables["dtD2"].Rows[i]["upper_sequence"].ToString();
                    lst2.sequence_id = dtsTrans.Tables["dtD2"].Rows[i]["sequence_id"].ToString();
                    lst2.mo_id = dtsTrans.Tables["dtD2"].Rows[i]["mo_id"].ToString();
                    lst2.goods_id = dtsTrans.Tables["dtD2"].Rows[i]["goods_id"].ToString();
                    lst2.inventory_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["inventory_qty"].ToString());
                    lst2.inventory_sec_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["inventory_sec_qty"].ToString());
                    lst2.con_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["con_qty"].ToString());
                    lst2.sec_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["sec_qty"].ToString());
                    lst2.sec_unit = dtsTrans.Tables["dtD2"].Rows[i]["sec_unit"].ToString();
                    lst2.location = dtsTrans.Tables["dtD2"].Rows[i]["location"].ToString();
                    lst2.carton_code = dtsTrans.Tables["dtD2"].Rows[i]["carton_code"].ToString();
                    lst2.order_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["order_qty"].ToString());
                    lst2.transfer_amount = 0;
                    lst2.nostorage_qty = 0;
                    lst2.goods_unit = dtsTrans.Tables["dtD2"].Rows[i]["goods_unit"].ToString();
                    lst2.remark = dtsTrans.Tables["dtD2"].Rows[i]["remark"].ToString();
                    lst2.unit_code = dtsTrans.Tables["dtD2"].Rows[i]["unit_code"].ToString();
                    lst2.mrp_id = "";
                    lst2.lot_no = dtsTrans.Tables["dtD2"].Rows[i]["lot_no"].ToString();
                    lst2.obligate_qty = 0;
                    lst2.bom_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["bom_qty"].ToString());
                    lst2.row_status = (rowStatus == "Added") ? "NEW" : "EDIT";
                    lstDetailData2.Add(lst2);
                }
            }
            List<TransferInDetails> lstDelData1 = new List<TransferInDetails>();
            for (int i = 0; i < dtTempDel1.Rows.Count; i++)
            {
                TransferInDetails lstDel1 = new TransferInDetails();
                lstDel1.id = dtTempDel1.Rows[i]["id"].ToString();
                lstDel1.sequence_id = dtTempDel1.Rows[i]["sequence_id"].ToString();
                lstDelData1.Add(lstDel1);
            }
            List<TransferDetailPart> lstDelData2 = new List<TransferDetailPart>();
            for (int i = 0; i < dtTempDel2.Rows.Count; i++)
            {
                TransferDetailPart lstDel2 = new TransferDetailPart();
                lstDel2.id = dtTempDel2.Rows[i]["id"].ToString();
                lstDel2.upper_sequence = dtTempDel2.Rows[i]["upper_sequence"].ToString();
                lstDel2.sequence_id = dtTempDel2.Rows[i]["sequence_id"].ToString();
                lstDelData2.Add(lstDel2);
            }
            int result = 0;
            result = clsTransferout.Save(head, lstDetailData1, lstDetailData2, lstDelData1, lstDelData2, DBUtility._user_id);
            save_flag = (result >= 0) ? true : false; 			
			
            //更新包裝裝箱標簽掃描數據中的標識
            if (save_flag)
            {
                mState = "";
                SetButtonSatus(true);
                SetObjValue.SetEditBackColor(tabPage1.Controls, false);
                Set_Grid_Status(false);
                dtTempDel1.Clear();
                dtTempDel2.Clear();
                int cur_row;
                string sql_u, mo_id="", goods_id="";
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    cur_row = dgvDetails.GetRowHandle(i);
                    if (dgvDetails.GetRowCellValue(cur_row, "mo_id").ToString() != "")
                    {
                        mo_id = dgvDetails.GetRowCellValue(cur_row, "mo_id").ToString();
                        goods_id = dgvDetails.GetRowCellValue(cur_row, "goods_id").ToString();
                        sql_u = string.Format("Update {0}packing_mo_label Set upd_flag='1' Where mo_id='{1}' And goods_id='{2}' And upd_flag='0'",
                        DBUtility.pad_db1,mo_id, goods_id);
                        clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                    }
                }
                FindDoc(txtID.Text);
                MessageBox.Show("當前數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
			else
			{
                MessageBox.Show("當前數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private bool SaveBeforeValidMaster() //保存前檢查主檔資料有效性
		{
            if (lkeBill_type_no.Text == "" || txtID.Text == "" || lkeGroupNo.Text == "" || dtTransfer_date.Text == "")
            {	
				MessageBox.Show("編號、單據種類、組別編號、轉出單日期不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else			
				return true;
		}		

		private void Set_Master_Data(DataTable dt) //綁定主檔資料
		{
			txtID.Text = dt.Rows[0]["id"].ToString();          
            if (string.IsNullOrEmpty(dt.Rows[0]["transfer_date"].ToString()))
                dtTransfer_date.EditValue = "";
            else
                dtTransfer_date.EditValue = Convert.ToDateTime(dt.Rows[0]["transfer_date"].ToString()).ToString("yyyy-MM-dd");
            lkeDepartment_id.EditValue = dt.Rows[0]["Department_id"].ToString();
            lkeBill_type_no.EditValue = dt.Rows[0]["bill_type_no"].ToString();
            lkeGroupNo.EditValue = dt.Rows[0]["group_no"].ToString();            
            txtUpdate_count.Text = dt.Rows[0]["update_count"].ToString();
            txtHandler.Text = dt.Rows[0]["handler"].ToString();
            txtRemark.Text = dt.Rows[0]["remark"].ToString();            
            lkeSate.EditValue = dt.Rows[0]["state"].ToString();           
            txtCheck_date.Text = dt.Rows[0]["check_date"].ToString();
            //txtCheck_date.Text =Convert.ToDateTime(dt.Rows[0]["address"].ToString()).ToString("yyyy-MM-dd");
			txtCreate_by.Text = dt.Rows[0]["create_by"].ToString();
			txtCreate_date.Text = dt.Rows[0]["create_date"].ToString();
			txtupdate_by.Text = dt.Rows[0]["update_by"].ToString();
			txtupdate_date.Text = dt.Rows[0]["update_date"].ToString();
		}

		private void txtID_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtID.Text))
			{
				if (mState == "") //流覽模式
				{
					FindDoc(txtID.Text);
				}
			}
		}
   
        private void frmTransferout_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.GC.Collect();
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
       
        private void lkeBill_type_no_EditValueChanged(object sender, EventArgs e)
        {
            GetMaxID();
        }

        private void lkeGroupNo_EditValueChanged(object sender, EventArgs e)
        {
            GetMaxID();
        }               

        /// <summary>
        /// 取單據序號
        /// </summary>
        private void GetMaxID()
        {
            if (mState != "")
            {
                string billType = "ST04";
                string billTypeNo = lkeBill_type_no.EditValue.ToString();
                string salesGroup= lkeGroupNo.EditValue.ToString();
                txtID.Text = (billTypeNo != "" && salesGroup != "") ? clsTransferout.GetMaxID(billType, billTypeNo, salesGroup, 2) : "";
            }
        }  
        
        private void clMo_id_Leave(object sender, EventArgs e)
        {
            this.CheckMo();
        }
     
        private void CheckMo()
        {
            if (mState != "")
            {
                if (dgvDetails.RowCount >0)
                {
                    dgvDetails.CloseEditor();
                    string mo_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id").ToString();
                    if (mo_id == "")
                    {
                        return;
                    }
                    string suit = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "shipment_suit").ToString();                    
                    if (string.IsNullOrEmpty(mo_id) || mo_id.Length != 9)
                    {
                        return;
                    }
                    string bill_type_no = lkeBill_type_no.EditValue.ToString();
                    string group_no = lkeGroupNo.EditValue.ToString();                    
                    //20130327增加开LN单时，只能是东莞D页数的判断
                    if(clsTransferout.CheckMoIsDgD(bill_type_no, mo_id) != 1)
                    {
                        return;
                    }
                    string mo_group = "";
                    if (bill_type_no == "DN")
                    {
                        mo_group = mo_id.Substring(2, 1);
                    }
                    mo_group = string.IsNullOrEmpty(mo_group) ? "" : mo_group;
                    string msg = "當前組別不允許輸入此類頁數!";
                    bool check_mo = true;
                    switch (mo_group)
                    {
                        case "G":
                        case "L":
                        case "A":
                        case "B":
                            if (mo_group != group_no)
                            {
                                check_mo = false;
                                MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case "C":
                            if (mo_group != "C" && mo_group != "S" && mo_group != "V" && mo_group != "Y")
                            {
                                check_mo = false;
                                MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case "E":
                            if (mo_group != "E" && mo_group != "W")
                            {
                                check_mo = false;
                                MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                               
                            }
                            break;
                    }
                    if (!check_mo)
                    {
                        return;
                    }
                    SetShipmentSuit(mo_id, suit);
                }
            }
        }

        private void SetShipmentSuit(string mo_id,string suit)
        {
            string id = "", goodsId = "", goods_id = "", locationId = "", sequenceId = "", newFlag = "0";
            int ll_rc = dgvDetails.FocusedRowHandle;
            //取當前值，以便與之前對應的臨時變量值作對比
            goodsId = dgvDetails.GetRowCellValue(ll_rc, "goods_id").ToString();
            id = dgvDetails.GetRowCellValue(ll_rc, "id").ToString();
            sequenceId = dgvDetails.GetRowCellValue(ll_rc, "sequence_id").ToString();
            locationId = dgvDetails.GetRowCellValue(ll_rc, "location_id").ToString();  
            //判斷頁數，套件，貨品跟之前對比是否有改動，如有改動，先刪除表格2中頁數對應的數據
            if (mo_id != temp_mo_id || suit != temp_suit || goodsId != temp_goods_id)
            {
                if(mo_id != temp_mo_id && temp_mo_id !="")
                {
                    //如更改頁數則先刪除表格2對應的舊值
                    for (int i = dtsTrans.Tables["dtD2"].Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtsTrans.Tables["dtD2"].Rows[i]["upper_sequence"].ToString() == sequenceId)
                        {
                            dtsTrans.Tables["dtD2"].Rows[i].Delete();
                        }
                    }
                }
                //相同說明未shipment_suit未曾改變                    
                //重新初始化new_flag='0'的狀態，后面的SetShipmentSuit()會依據此狀態值判斷是否要重新設置表格2的置
                dgvDetails.SetRowCellValue(ll_rc, "new_flag", "0");
            }
            newFlag = dgvDetails.GetRowCellValue(ll_rc, "new_flag").ToString();
            if (newFlag == "1")
            {
                return;
            }
            string sql = string.Format(
            @"SELECT b.goods_id From so_order_manage a with(nolock),so_order_details b with(nolock)
            Where a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And b.within_code='0000' And b.mo_id='{0}' 
            And a.state Not In('2','V') And b.state Not In('2','V')", mo_id);
            goods_id = clsConErp.ExecuteSqlReturnObject(sql);
            if (goods_id =="")
            {
                MessageBox.Show("無效的頁數！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvDetails.SetRowCellValue(ll_rc, "mo_id", "");
                dgvDetails.SetRowCellValue(ll_rc, "goods_id", "");
                dgvDetails.SetRowCellValue(ll_rc, "goods_name", "");
                return;
            }
            List<packing_mo> lstMDL = new List<packing_mo>();
            packing_mo mdl = new packing_mo();
            mdl.mo_id = mo_id;
            mdl.goods_id = goods_id;
            lstMDL.Add(mdl);            

            DataSet dtsBatch = clsTransferout.GetPackingBomData(lstMDL);

            string idKey = "", goods_id_f0 = "";
            string boxs = "";
            //批量添加默認全部是套件出货           
            if(dtsBatch.Tables[0].Rows.Count>0)
            {
                //sequenceId = getMaxSeqId();
                if (suit == "True")
                {
                    //套件出货,添加表格1的數據
                    goods_id_f0 = dtsBatch.Tables[0].Rows[0]["goods_id_f0"].ToString();
                    dgvDetails.SetRowCellValue(ll_rc, "goods_id", goods_id_f0);
                    dgvDetails.SetRowCellValue(ll_rc, "idkey", id + sequenceId);
                    if (locationId == "601")
                    {
                        locationId = this.SetLocation(true);//重新設置倉庫編號
                        dgvDetails.SetRowCellValue(ll_rc, "location_id", locationId);  //601 時move_location_id,move_carton_code ？？
                    }                                
                    //檢查頁數貨品是否有重复值
                    if (HasDuplicate())
                    {
                        dgvDetails.SetRowCellValue(ll_rc, "goods_id", "");
                        return;
                    }                    
                    dgvDetails.SetRowCellValue(ll_rc, "package_num", dtsBatch.Tables[0].Rows[0]["package_num"]);
                    dgvDetails.SetRowCellValue(ll_rc, "shipment_suit", true);
                    dgvDetails.SetRowCellValue(ll_rc, "transfer_amount", dtsBatch.Tables[0].Rows[0]["qty"]);//轉倉數量
                    dgvDetails.SetRowCellValue(ll_rc, "nwt", dtsBatch.Tables[0].Rows[0]["weg"]);
                    dgvDetails.SetRowCellValue(ll_rc, "gross_wt", dtsBatch.Tables[0].Rows[0]["weg_gross"]);
                    dgvDetails.SetRowCellValue(ll_rc, "location_id", locationId);
                    dgvDetails.SetRowCellValue(ll_rc, "move_location_id", locationId);
                    dgvDetails.SetRowCellValue(ll_rc, "move_carton_code", locationId);                    
                    dgvDetails.SetRowCellValue(ll_rc, "goods_id", dtsBatch.Tables[0].Rows[0]["goods_id_f0"].ToString());
                    dgvDetails.SetRowCellValue(ll_rc, "goods_name", dtsBatch.Tables[0].Rows[0]["goods_name_f0"].ToString());
                    boxs = dtsBatch.Tables[0].Rows[0]["package_num"].ToString();
                    boxs= (boxs != "0" || boxs != "") ? "箱" : "";
                    dgvDetails.SetRowCellValue(ll_rc, "position_first", boxs);
                    dgvDetails.SetRowCellValue(ll_rc, "sec_qty", dtsBatch.Tables[0].Rows[0]["total_sec_qty"]);
                    //添加表格2的數據
                    DataRow[] drws = dtsBatch.Tables[1].Select($"mo_id='{mo_id}' and goods_id_f0='{goods_id_f0}'");
                    //DataRow[] drws = dtsBatch.Tables[1].Select($"mo_id='{mo_id}'");
                    DataRow drw1;
                    foreach (DataRow dr in drws)
                    {
                        drw1 = dtsTrans.Tables["dtD2"].NewRow();
                        drw1["id"] = id;
                        drw1["upper_sequence"] = sequenceId;
                        idKey = id + sequenceId; //關聯父表的鍵值
                        drw1["idkey"] = idKey;
                        drw1["sequence_id"] = dr["sequence_id"]; //返回表中已生成
                        drw1["mo_id"] = dr["mo_id"];
                        drw1["goods_id"] = dr["goods_id"];
                        drw1["goods_name"] = dr["goods_name"];
                        drw1["inventory_qty"] = dr["inventory_qty"];
                        drw1["inventory_sec_qty"] = dr["inventory_sec_qty"];
                        drw1["con_qty"] = dr["con_qty"]; //后臺已考慮BOM用量
                        drw1["sec_qty"] = dr["sec_qty"];
                        drw1["order_qty"] = dr["order_qty"];
                        drw1["lot_no"] = dr["lot_no"];
                        drw1["obligate_qty"] = dr["obligate_qty"];
                        drw1["sec_unit"] = "KG";
                        drw1["location"] = "601";
                        drw1["goods_unit"] = "SET";
                        drw1["unit_code"] = "PCS";
                        drw1["bom_qty"] = dr["dosage"];
                        dtsTrans.Tables["dtD2"].Rows.Add(drw1);
                    }                   
                }
                else
                {
                    string sql_f = "";
                    dgvDetails.SetRowCellValue(ll_rc, "goods_id", dtsBatch.Tables[0].Rows[0]["goods_id"].ToString());//18位產品編號
                    dgvDetails.SetRowCellValue(ll_rc, "goods_name", dtsBatch.Tables[0].Rows[0]["goods_name"].ToString());
                    dgvDetails.SetRowCellValue(ll_rc, "location_id", "601");
                    dgvDetails.SetRowCellValue(ll_rc, "carton_code", "601");
                    DataTable dtTest = new DataTable();
                    DataRow[] aryDel = dtsTrans.Tables["dtD2"].Select($"upper_sequence='{sequenceId}'");
                    DataRow drDel;
                    foreach (DataRow dr in aryDel)
                    {
                        if (mState == "EDIT")
                        {
                            //修改狀態下由F0套件改成18位編號走貨，需要將資料表st_transfer_detail_part中的舊值刪除
                            sql_f = string.Format(
                            @"SELECT '1' FROM st_transfer_detail_part Where within_code='0000' And id='{0}' And upper_sequence='{1}' And sequence_id='{2}'",
                            dr["id"], dr["upper_sequence"], dr["sequence_id"]);
                            if(clsConErp.ExecuteSqlReturnObject(sql_f) !="")
                            {
                                drDel = dtTempDel2.NewRow();
                                drDel["id"] = dr["id"];
                                drDel["upper_sequence"] = dr["upper_sequence"];
                                drDel["sequence_id"] = dr["sequence_id"];
                                dtTempDel2.Rows.Add(drDel);
                            }
                        }
                        dtsTrans.Tables["dtD2"].Rows.Remove(dr);
                    }
                }
                temp_mo_id = mo_id;
                temp_goods_id = goods_id_f0;
                temp_suit = suit;
                dgvDetails.SetRowCellValue(ll_rc, "new_flag", "1"); //設置新行標識，避免重複觸發添加表格2的數據
                bds2.DataSource = bds1;
                bds2.DataMember = "relation_dtD1_dtD2";
                gridControl2.DataSource = bds2;
            }
        }

        public bool HasDuplicate()
        {
            //檢查頁數貨品是否有重复值组合
            bool dupFlag = false;
            string msg = "", moId = "", goodsId = "";
            List<string> lst = new List<string>();            
            for (int i = 0; i < dtsTrans.Tables["dtD1"].Rows.Count; i++)
            {
                moId = dtsTrans.Tables["dtD1"].Rows[i]["mo_id"].ToString();
                goodsId = dtsTrans.Tables["dtD1"].Rows[i]["goods_id"].ToString();
                lst.Add(moId + " ; " + goodsId);
            }
            if (lst.Count >= 2)
            {
                var duplicates = lst.GroupBy(n => n)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
                foreach (var item in duplicates)
                {
                    msg = $"頁數,貨品存在重復:[{item}]";
                    MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dupFlag = true;
                    break;
                }
            }            
            return dupFlag; 
        }

        //東莞D送貨單查詢 ==============BEGIN==============
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mState != "")
            {
                return;
            }
            FindDate();
        }

        private void FindDate()
        {
            if (BTNCANCEL.Enabled)
            {
                Cancel();
                tabControl1.SelectTab(1);
            }
            if (txtDat1.Text =="" && txtDat2.Text =="" && txtId1.Text =="" && txtId2.Text =="" && lkebill_type_no1.EditValue.ToString() == "" 
                && txtMo_id1.Text == "" && txtMo_id2.Text =="" && txtGroupNo1.Text =="")
            {
                MessageBox.Show("查詢條件不可以為空!", "提示信息");
                return;
            }
            dtFindDate = clsTransferout.FindData(txtId1.Text, txtId2.Text, txtDat1.Text, txtDat2.Text, lkebill_type_no1.EditValue.ToString(), txtGroupNo1.Text, txtMo_id1.Text, txtMo_id2.Text);            
            dgvFind.DataSource = dtFindDate;
            if (dtFindDate.Rows.Count == 0)
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
                    FindDoc(txtID.Text);
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
            
        }
        
        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }
       
        //東莞D送貨單查詢 ==============END==============


        //手寫單頁面代碼 =============BEGIN =============
        private void btnQuery_Click(object sender, EventArgs e)
        {
            
            string dat1 = "", dat2 = "",flagDgd="0";
            flagDgd = (chkDgd.Checked) ? "1" : "0";
            if (dtUpdateTime1.Text != "")
            {
                dat1 = Convert.ToDateTime(dtUpdateTime1.EditValue.ToString()).Date.ToString("yyyy-MM-dd");
            }
            if (dtUpdateTime2.Text !="")
            {
                 dat2 = Convert.ToDateTime(dtUpdateTime2.EditValue.ToString()).Date.AddDays(1).ToString("yyyy-MM-dd");
            }
            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            DataTable dtIdFind = clsTransferout.GetPackingData(txtFindGroupNo.Text.Trim(), txtFindMoId.Text.Trim(), dat1, dat2, flagDgd);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            gcIdDetails.DataSource = dtIdFind;
            if (dtIdFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的記錄!", "提示信息");
            }
            
        }
        private void btnImput_Click(object sender, EventArgs e)
        {
            ImputItems();
        }

        //過帳
        private void ImputItems()
        {
            if (dgvIdDetails.RowCount == 0)
            {
                MessageBox.Show("請首先查找出裝箱資料!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (mState == "" )//已點擊新增或編號
            {
                MessageBox.Show("注意：新增或編號狀態方可以進行此操作!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtID.Text == "")
            {
                MessageBox.Show("注意：主檔單據編號不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!clsDeliveryBill.Check_Add_Popedom("frmTransferout"))
            {
                MessageBox.Show("當前用戶沒有此操作權限!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool flag_select = false;
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["flag_select"].ToString() == "True")
                {
                    flag_select = true;
                    break;
                }
            }
            if (!flag_select)
            {
                MessageBox.Show("請至少要選取一筆手寫單貨單的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("確認要進行當前過帳的操作?", "提示信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }
           
            List<packing_mo> lstMDL = new List<packing_mo>();
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["flag_select"].ToString() == "True")
                {
                    packing_mo mdl = new packing_mo();
                    mdl.mo_id = dgvIdDetails.GetDataRow(i)["mo_id"].ToString().Trim();
                    mdl.goods_id = dgvIdDetails.GetDataRow(i)["goods_id"].ToString().Trim();
                    lstMDL.Add(mdl);
                }
            }
            //去掉重復
            var lstMDL2 = lstMDL.GroupBy(d => new { d.mo_id, d.goods_id })
                        .Select(d => d.FirstOrDefault())
                        .ToList();
            DataSet dtsBatch = clsTransferout.GetPackingBomData(lstMDL2);

            string id = "", sequenceId = "", idKey = "", mo_id, goods_id_f0 = "", goods_id = "",boxs = "";          
            //批量添加默認全部是套件出货
            string location_id = this.SetLocation(true); //取倉號
            Set_Grid_Status(true);
            for (int i=0;i< dtsBatch.Tables[0].Rows.Count;i++)
            {
                sequenceId = getMaxSeqId();
                temp_suit = "True";
                id = txtID.Text;
                DataRow drw = dtsTrans.Tables["dtD1"].NewRow();
                drw["id"] = id;
                drw["sequence_id"] = sequenceId;
                idKey = id + sequenceId;
                drw["idkey"] = idKey;
                drw["unit"] = "PCS";
                drw["sec_unit"] = "KG";
                drw["package_num"] = dtsBatch.Tables[0].Rows[i]["package_num"];
                drw["shipment_suit"] = true;
                drw["transfer_amount"] = dtsBatch.Tables[0].Rows[i]["qty"];//轉倉數量
                drw["nwt"] = dtsBatch.Tables[0].Rows[i]["weg"];
                drw["gross_wt"] = dtsBatch.Tables[0].Rows[i]["weg_gross"];               
                drw["new_flag"] = "1"; //設置新行標識，避免重複觸發添加表格2的數據
                mo_id = dtsBatch.Tables[0].Rows[i]["mo_id"].ToString();
                goods_id_f0 = dtsBatch.Tables[0].Rows[i]["goods_id_f0"].ToString();
                goods_id = goods_id_f0;
                drw["mo_id"] = mo_id;
                drw["goods_id"] = goods_id_f0;                
                if (goods_id_f0.Substring(0,3) != "F0-")
                {
                    temp_suit = "False";
                    drw["shipment_suit"] = false;
                    location_id = "601";
                }
                drw["location_id"] = location_id;
                drw["carton_code"] = location_id;
                drw["move_location_id"] = location_id;
                drw["move_carton_code"] = location_id;
                drw["goods_name"] = dtsBatch.Tables[0].Rows[i]["goods_name_f0"].ToString();
                boxs = dtsBatch.Tables[0].Rows[i]["package_num"].ToString();
                drw["position_first"] = (boxs != "0" || boxs != "") ? "箱" : "";
                drw["sec_qty"] = dtsBatch.Tables[0].Rows[i]["total_sec_qty"];
                drw["remark"] = dtsBatch.Tables[0].Rows[i]["suit_flag"];
                dtsTrans.Tables["dtD1"].Rows.Add(drw);                
                if (goods_id_f0.Substring(0, 3) == "F0-")
                {
                    //DataRow[] drws = dtsBatch.Tables[1].Select($"mo_id='{mo_id}' and goods_id_f0='{goods_id_f0}'");
                    DataRow[] drws = dtsBatch.Tables[1].Select($"mo_id='{mo_id}'");
                    DataRow drw1;
                    foreach (DataRow dr in drws)
                    {
                        drw1 = dtsTrans.Tables["dtD2"].NewRow();
                        drw1["id"] = id;
                        drw1["upper_sequence"] = sequenceId;
                        idKey = id + sequenceId; //關聯父表的鍵值
                        drw1["idkey"] = idKey;
                        drw1["sequence_id"] = dr["sequence_id"]; //返回表中已生成
                        drw1["mo_id"] = dr["mo_id"];
                        drw1["goods_id"] = dr["goods_id"];
                        drw1["goods_name"] = dr["goods_name"];
                        drw1["inventory_qty"] = dr["inventory_qty"];
                        drw1["inventory_sec_qty"] = dr["inventory_sec_qty"];
                        drw1["con_qty"] = dr["con_qty"];
                        drw1["sec_qty"] = dr["sec_qty"];
                        drw1["order_qty"] = dr["order_qty"];
                        drw1["lot_no"] = dr["lot_no"];
                        drw1["obligate_qty"] = dr["obligate_qty"];
                        drw1["sec_unit"] = "KG";
                        drw1["location"] = "601";
                        drw1["goods_unit"] = "SET";
                        drw1["unit_code"] = "PCS";
                        drw1["bom_qty"] = dr["dosage"];
                        dtsTrans.Tables["dtD2"].Rows.Add(drw1);
                    }
                }                
                temp_mo_id = mo_id;
                temp_goods_id = goods_id;                
            }//--end for
            bds1.DataSource = dtsTrans.Tables["dtD1"];
            gridControl1.DataSource = bds1;
            bds2.DataSource = bds1;
            bds2.DataMember = "relation_dtD1_dtD2";
            gridControl2.DataSource = bds2;
            lstMDL.Clear();
            lstMDL2.Clear();
            chkSelectAll.Checked = false;
            //移除批量查詢頁中勾選中的行           
            for (int i = dgvIdDetails.RowCount - 1; i >= 0; i--)            
            {
                if (dgvIdDetails.GetDataRow(i)["flag_select"].ToString() == "True")
                {                    
                    dgvIdDetails.DeleteRow(i);//移走當前行
                }
            }
            tabControl1.SelectTab(0);//跳至第一頁
        }   
        
        private void clSuit_MouseUp(object sender, MouseEventArgs e)
        {
            this.CheckMo();
        }

        private void clGoodsId_EditValueChanged(object sender, EventArgs e)
        {
            this.CheckMo();
        }
    
        private void clbteItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mState != "")
            {
                int rowIndex = dgvDetails.FocusedRowHandle;
                string mo_id = dgvDetails.GetRowCellValue(rowIndex, "mo_id").ToString();
                string suit = dgvDetails.GetRowCellValue(rowIndex, "shipment_suit").ToString();
                if (suit == "True")
                {
                    return;
                }
                if (mo_id == "")
                {
                    MessageBox.Show("請首先指定制單頁數)！", "提示信息", MessageBoxButtons.OK);
                    return;
                }
                if (mo_id.Length != 9)
                {
                    MessageBox.Show("制單頁數長度不正確)！", "提示信息", MessageBoxButtons.OK);
                    return;
                }
                //GetControlScreenPosition(clbteItem);
                //Point formPoint = Control.MousePosition;//鼠标相对于屏幕左上角的坐标
                //Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                Point clickPoint = new Point(MousePosition.X, MousePosition.Y);//當前鼠标的坐标
                using (frmTransferoutItem ofrm = new frmTransferoutItem(mo_id, clickPoint))
                {                   
                    ofrm.ShowDialog();
                    if (ofrm.goodsId != "")
                    {                       
                        dgvDetails.SetRowCellValue(rowIndex, "goods_id", ofrm.goodsId);
                        dgvDetails.SetRowCellValue(rowIndex, "goods_name", ofrm.goodsName);
                    }
                }
            }            
        }

        public void GetControlScreenPosition(Control control)
        {
            Point screenLocation = control.PointToScreen(new Point(0, 0));
            MessageBox.Show($"X: {screenLocation.X}, Y: {screenLocation.Y}");
        }

        private void dgvDetails_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                string transferAmount = "";
                temp_mo_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id").ToString();
                temp_suit = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "shipment_suit").ToString();
                temp_goods_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "goods_id").ToString();
                transferAmount = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "transfer_amount").ToString();
                transferAmount = string.IsNullOrEmpty(transferAmount) ? "0.00" : transferAmount;
                temp_transfer_amount = decimal.Parse(transferAmount);
            }
        }

        private void clQtyCount_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                //如用戶更改表格1的數量，同步更改表格2的數量及重量
                TextEdit te = (TextEdit)sender;
                if (string.IsNullOrEmpty(te.Text))
                {
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "transfer_amount", "0.00");
                }
                decimal transferAmount= decimal.Parse(dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "transfer_amount").ToString());
                if (transferAmount <= 0)
                {
                    return;
                }
                string upperSequence = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id").ToString();
                decimal st_qty=0, st_sec_qty = 0,sec_qty=0, total_sec_qty =0;
                string str_sec_qty = "";
                for (int i = 0; i < dtsTrans.Tables["dtD2"].Rows.Count;  i++)
                {
                    if(dtsTrans.Tables["dtD2"].Rows[i]["upper_sequence"].ToString()== upperSequence)
                    {
                        st_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["inventory_qty"].ToString());
                        if (st_qty == 0)
                        {
                            st_qty = 1;
                        }
                        st_sec_qty = decimal.Parse(dtsTrans.Tables["dtD2"].Rows[i]["inventory_sec_qty"].ToString());
                        str_sec_qty = Math.Round(transferAmount * st_sec_qty / st_qty, 5).ToString();
                        sec_qty = decimal.Parse(str_sec_qty.Substring(0, str_sec_qty.IndexOf('.') + 3));
                        dtsTrans.Tables["dtD2"].Rows[i]["con_qty"] = transferAmount;
                        dtsTrans.Tables["dtD2"].Rows[i]["sec_qty"] = sec_qty;
                        total_sec_qty += sec_qty;
                    }                    
                }
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sec_qty", total_sec_qty);                
            }
        }

        private void dtUpdateTime1_Leave(object sender, EventArgs e)
        {
            if (dtUpdateTime1.Text != "")
            {
                dtUpdateTime2.EditValue = dtUpdateTime1.EditValue;
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void BTNAPPROVE_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            if(lkeSate.EditValue.ToString()=="1")
            {
                MessageBox.Show("已是批準狀態,當前操作無效!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (mState == "" && lkeSate.EditValue.ToString() == "0")
            {
                //批準前檢查庫存
                dtStockAdj.Clear();
                //生成存在庫存差額的數據
                SelectData601(); 
                if (dtStockAdj.Rows.Count > 0)
                {
                    string msg = string.Format(
                    @"表格一中的第【{0}】行,頁數【{1}】,貨品【{2}】庫存不足!\\n\\r 數量差額:{3},重量差額:{4}",
                    dtStockAdj.Rows[0]["sequence_id"].ToString(), dtStockAdj.Rows[0]["mo_id"].ToString(), dtStockAdj.Rows[0]["goods_id"].ToString(),
                    dtStockAdj.Rows[0]["adj_qty"].ToString(), dtStockAdj.Rows[0]["adj_sec_qty"].ToString());
                    MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //檢查庫存通過則執行后面的批準代碼

            }

        }

        private void clSec_qty_Click(object sender, EventArgs e)
        {
            SetWegCursorPosition(sender);
        }

        private void clSecQty_Click(object sender, EventArgs e)
        {
            SetWegCursorPosition(sender);
        }

        private void SetWegCursorPosition(object obj)
        {
            if (mState != "")
            {
                TextEdit ts = (TextEdit)obj;
                if (ts.Text == "0.00")
                {
                    ts.Select(1, 0);
                }
            }
        }

        private void BTNCHECKST_Click(object sender, EventArgs e)
        {
            if (lkeSate.EditValue.ToString() == "1")
            {
                MessageBox.Show("注意：已批準的單據不可以再編輯!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (mState == "" && lkeSate.EditValue.ToString() == "0")
            {
                if(dtsTrans.Tables["dtD1"].Rows.Count==0)
                {
                    return;
                }
                //清除舊的數據
                dtStockAdj.Clear(); 
                //生成存在庫存差額的數據
                SelectData601();
                //庫存調整
                if (dtStockAdj.Rows.Count > 0)
                {
                    using (frmTransferoutAdj ofrm = new frmTransferoutAdj(dtStockAdj))
                    {
                        ofrm.ShowDialog();
                        if (ofrm.flag_adj)
                        {
                            //刷新數據
                            FindDoc(txtID.Text);
                            MessageBox.Show("自動庫存調整成功！", "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                }                
            }
        }

        //生成存在庫存差額的數據
        private void SelectData601()
        {
            //過濾出表格1中601的數據
            DataRow[] aryDrws = dtsTrans.Tables["dtD1"].Select("location_id='601'");
            dtsTrans.Tables["dtD1"].Select();
            if (aryDrws.Length > 0)
            {
                this.GenerateAdjData(aryDrws, "1");
            }
            //過濾出表格2中倉數不足的數據
            aryDrws = null;
            aryDrws = dtsTrans.Tables["dtD2"].Select("location='601' and (con_qty>inventory_qty or sec_qty>inventory_sec_qty)");
            dtsTrans.Tables["dtD2"].Select();
            if (aryDrws.Length > 0)
            {
                this.GenerateAdjData(aryDrws, "2");
            }
        }

        //將存在庫存差額的數據插入臨時表，以便生成自動庫存調整數據
        private void GenerateAdjData(DataRow[] aryDrws,string type)
        {
            //庫存不足
            string sequenceId = "", locationId = "", moId = "", goodsId = "", strLotNo = "";
            decimal stQty = 0, stSecQty = 0, conQty = 0, secQty = 0, adjQty = 0, adjSecQty = 0;
            foreach (var dr in aryDrws)
            {
                sequenceId = (type == "1") ? dr["sequence_id"].ToString() : dr["upper_sequence"].ToString();
                locationId = (type == "1") ? dr["location_id"].ToString() : dr["location"].ToString();
                conQty = (type == "1") ? decimal.Parse(dr["transfer_amount"].ToString()) : decimal.Parse(dr["con_qty"].ToString()); //轉出數量
                secQty = decimal.Parse(dr["sec_qty"].ToString()); //轉出重量
                moId = dr["mo_id"].ToString();
                goodsId = dr["goods_id"].ToString();
                strLotNo = dr["lot_no"].ToString();
                stQty = decimal.Parse(dr["inventory_qty"].ToString()); //實際庫存數量
                stSecQty = decimal.Parse(dr["inventory_sec_qty"].ToString());  //實際庫存重量
               
                if (stQty < conQty || stSecQty < secQty)
                {
                    adjQty = (stQty < conQty) ? (conQty - stQty) : 0;
                    adjSecQty = (stSecQty < secQty) ? (secQty - stSecQty) : 0;
                    DataRow drw = dtStockAdj.NewRow();
                    drw["sequence_id"] = sequenceId;
                    drw["location_id"] = locationId;
                    drw["mo_id"] = moId;
                    drw["goods_id"] = goodsId;
                    drw["lot_no"] = strLotNo;
                    drw["adj_qty"] = adjQty;
                    drw["adj_sec_qty"] = adjSecQty;
                    dtStockAdj.Rows.Add(drw);
                }
            }
            
        }

        private void chkSelectAll_MouseUp(object sender, MouseEventArgs e)
        {
            bool blVale = chkSelectAll.Checked;
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                dgvIdDetails.SetRowCellValue(i, "flag_select", blVale);                
            }
        }



        //手寫單頁面代碼 =============END=============


    }
}
