using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using cf01.Reports;
using cf01.ModuleClass;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
	public partial class frmPi_Custom : Form
	{       
        clsPublicOfGEO clsGeo = new clsPublicOfGEO();
        public clsAppPublic clspub = new clsAppPublic();
        private clsAppPublic clsApp = new clsAppPublic();
        
		public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態
		public string str_date = "";//服務器日期	
		public bool save_flag;    
        

		DataTable dtMostly = new DataTable();
		DataTable dtDetails = new DataTable();       
		DataTable dtTempDel = new DataTable();       
        DataTable dtFind_Date = new DataTable();
        public bool check_mo { get; set; }

		public frmPi_Custom()
		{
			InitializeComponent();
            clsApp.Initialize_find_value(this.Name, tabControl1.TabPages[1].Controls);
            check_mo = true;
            //權限
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();

            //str_language = DBUtility._language;
            //NextControl oNext = new NextControl(this, "2");
            //oNext.EnterToTab();
		}

        private void frmPi_Custom_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtMostly.Dispose();
            dtDetails.Dispose();
            dtTempDel.Dispose();
            dtFind_Date.Dispose();
            clsGeo = null;
            clspub = null;
            clsApp = null;

            //System.GC.Collect();
        }

        private void frmPi_Custom_Load(object sender, EventArgs e)
        {
            str_date = clsPublicOfCF01.ExecuteSqlReturnObject("Select convert(varchar(10),getdate(),120)");
            const string sql_h = @"SELECT * From so_pi_custom_mostly where 1=0 ";
            dtMostly = clsPublicOfCF01.GetDataTable(sql_h);
            bds1.DataSource = dtMostly;
            //數據綁定主档
            txtID.DataBindings.Add("Text", bds1, "id");
            dtdate.DataBindings.Add("EditValue", bds1, "pi_date");
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtupdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtupdate_date.DataBindings.Add("Text", bds1, "update_date");
            txtstate.DataBindings.Add("Text", bds1, "state");

            const string sql_d = @"Select * from so_pi_custom_details where 1=0";
            dtDetails = clsPublicOfCF01.GetDataTable(sql_d);
            bds2.DataSource = dtDetails;
            gridControl1.DataSource = bds2;

            //數據綁定明细
            //txtMo_id.DataBindings.Add("Text", bds2, "mo_id");
            //txtOcno.DataBindings.Add("Text", bds2, "oc_no");
            //txtRmk.DataBindings.Add("Text", bds2, "remark");

            //臨時項目刪除表結構
            dtTempDel = dtDetails.Clone();

            //欄位表頭居中
            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                dgvDetails.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            if (string.IsNullOrEmpty(txtDat1.EditValue.ToString()))
            {
                txtDat1.EditValue = DateTime.Parse(str_date).Date.ToString("yyyy-MM-dd");
                txtDat2.EditValue = DateTime.Parse(str_date).Date.ToString("yyyy-MM-dd");
            }

            splitContainer1.Panel1Collapsed = true;
            chkPI_Original.Checked = false;
        }	

		private void BTNEXIT_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BTNNEW_Click(object sender, EventArgs e)
		{
			AddNew();
            AddNew_Item();           
            dgvDetails.DeleteRow(dgvDetails.FocusedRowHandle);//移走自動項目新增加的空行 
            txtMo_id.BackColor = Color.Plum; 

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
			DialogResult result = MessageBox.Show("是否確認要刪除当前明細資料?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int curRow = dgvDetails.FocusedRowHandle;
				//將當前行刪除幷加到臨時表中
				DataRow newRow = dtTempDel.NewRow();
				newRow["mo_id"] = txtMo_id.Text;
                newRow["id"] = txtID.Text;
                newRow["sequence_id"] =  dgvDetails.GetRowCellDisplayText(curRow, "sequence_id");
                dtTempDel.Rows.Add(newRow);
				dgvDetails.DeleteRow(curRow);//移走當前行     
                check_mo = true;
			}
		}

		private void BTNSAVE_Click(object sender, EventArgs e)
		{
            txtRemark.Focus();//Toolscript焦點問題
            if (!check_mo)
            {
                return;
            }
            Save();
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void BTNPRINT_Click(object sender, EventArgs e)
		{
            if (!chkPI_Original.Checked)
                Print();
            else
                Print2();
		}

		private void AddNew()  //新增
		{
			mState = "NEW";
            bds1.AddNew();
			txtID.Focus();
			SetButtonSatus(false);
            Set_Grid_Status(true);

            SetObjValue.SetEditBackColor(panel1.Controls, true);
            SetObjValue.ClearObjValue(panel1.Controls, "1");            

            //DataRow dr = dtMostly.NewRow(); //插一空行
            //dtMostly.Rows.InsertAt(dr, 0);
            
            txtRemark.Text = "";
            txtstate.Text = "0";
              
            GetID_No();
            dtdate.EditValue = DateTime.Parse(str_date).Date.ToString("yyyy-MM-dd");            

			dtDetails.Clear();
			gridControl1.DataSource = bds2;
            tabControl1.SelectTab(0);//跳至第一頁 
            
		}

		private void Edit()  //編輯
		{
			if (txtID.Text == "")
			{
				return;
			}            
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
			Set_Grid_Status(true);
            splitContainer1.Panel1Collapsed = false;
			mState = "EDIT";

			txtID.Properties.ReadOnly = true;
			txtID.BackColor = Color.White;           
            txtMo_id.BackColor = Color.Plum;          
           
            tabControl1.SelectTab(0);//跳至第一頁
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
		
			DialogResult result = MessageBox.Show("此操作将刪除主表及明细中的资料,请谨慎操作!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
                string sql_del = string.Format(@"Update dbo.so_pi_custom_mostly Set state='2',update_by='{0}',update_date=getdate() WHERE id=@id", DBUtility._user_id);
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);//直接操作DGSQL2
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
						MessageBox.Show("数據刪隊成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						SetObjValue.ClearObjValue(tabPage1.Controls, "1");
						dtDetails.Clear();
                        check_mo = true;
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
                //if (Save_Details_Before_Valid())
                //{
                //    return;
                //}
				Set_Grid_Status(true);
                SetObjValue.SetEditBackColor(tabPage1.Controls, true);
                bds2.AddNew();
                //dgvDetails.AddNewRow();//新增
                dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "id", txtID.Text);               
				dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "sequence_id", (dgvDetails.RowCount).ToString("000"));                           

				ColumnView view = (ColumnView)dgvDetails;//初始單元格焦點
				view.FocusedColumn = view.Columns["mo_id"];
				view.Focus();
                txtMo_id.Focus();       
                splitContainer1.Panel1Collapsed = false;
			}
			else
			{
				MessageBox.Show("單據編號不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
			}
		}

		private bool Save_Details_Before_Valid() //檢查明細資料的有效性
		{
			//測試項目必須有輸入
			bool _flag = false;
            if (dgvDetails.RowCount > 0)
            {
                //txtRemark.Focus();
                //因toolStrip控件焦點問題
                //設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，防止取到的值爲空
                ColumnView view = (ColumnView)dgvDetails;
                view.FocusedColumn = view.Columns["mo_id"];
                int curRow = 0;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    curRow = dgvDetails.GetRowHandle(i);
                    if (String.IsNullOrEmpty(dgvDetails.GetRowCellDisplayText(curRow, "mo_id")))
                    {
                        _flag = true;
                        MessageBox.Show("頁數不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)dgvDetails;
                        view1.FocusedColumn = view1.Columns["mo_id"]; //設置單元格焦點                        
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("明細資料不可為空!", "提示信息");
                _flag = true;
            }
			return _flag;
		}

        private bool IsRepeat() //頁數不允許有重覆
        {
            if (dgvDetails.RowCount < 2)
            {
                return false;
            }
            bool result = false;
            string strmo_id = "";
            for (int i = 0; i < dgvDetails.RowCount - 1; i++)
            {
                strmo_id = dgvDetails.GetRowCellDisplayText(i, "mo_id");
                for (int j = i + 1; j <= dgvDetails.RowCount - 1; j++)
                {
                    if (strmo_id == dgvDetails.GetRowCellDisplayText(j, "mo_id"))
                    {
                        MessageBox.Show("頁數不可以有重覆!\n\n" + string.Format("【{0}】", strmo_id),
                                                 "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

		private void Cancel() //取消
		{
            bds1.CancelEdit();
            bds2.CancelEdit();
            SetButtonSatus(true);
			//SetObjValue.SetEditBackColor(this.Controls, false);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "2");
			Set_Grid_Status(false);
            check_mo = true;
            splitContainer1.Panel1Collapsed = true;

			//dtTempDel.Clear();
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
                string sql_h = String.Format(@"SELECT * FROM dbo.so_pi_custom_mostly WITH(nolock) Where id ='{0}' AND state <>'2'", temp_id);
                dtMostly =clsPublicOfCF01.GetDataTable(sql_h);
                string sql_d = String.Format(@"Select * From dbo.so_pi_custom_details with(nolock) Where id='{0}'", temp_id);
                dtDetails = clsPublicOfCF01.GetDataTable(sql_d);
                if (dtMostly.Rows.Count > 0)
                {
                    bds1.DataSource = dtMostly;
                    dtdate.EditValue = clspub.Return_String_Date(dtdate.EditValue.ToString());
                }
                else
                {
                    //清空数据
                    dtDetails.Clear();
                    bds2.DataSource = dtDetails;
                    SetObjValue.ClearObjValue(tabPage1.Controls, "2");
                    return;
                }
				dtDetails.Clear();
                dtDetails = clsPublicOfCF01.GetDataTable(sql_d);                             
                bds2.DataSource = dtDetails;
                gridControl1.DataSource = bds2;
                //设置时间格式
                //dtdate.EditValue = clspub.Return_String_Date(dtdate.EditValue.ToString());                
				mID = txtID.Text;//保存臨時的ID號                  
			}
		}

		private void Save()  //保存
		{
            txtMo_id.Focus();
            bds1.EndEdit();
            bds2.EndEdit();          

            if (!Save_Head_Before_Valid())//檢查主檔資料的有效性
			{
				return;
			}
            //if (!check_mo)
            //{
            //    return;
            //}
            if (Save_Details_Before_Valid())//檢查明细資料的有效性
			{
				return;
			}
            if (IsRepeat()) //檢查明細是否有重覆頁數
            {
                return;
            }

			save_flag = false;           
           
			#region  保存新增或編輯
            if (mState == "NEW" || mState == "EDIT")
			{
                if (mState == "NEW")
                {
                    string strSql = String.Format("Select '1' FROM dbo.so_pi_custom_mostly WHERE id='{0}'", txtID.Text.Trim());
                    if (clsPublicOfCF01.ExecuteSqlReturnObject(strSql) != "")
                    {
                        MessageBox.Show(string.Format("此單據號[{0}]已存在!", txtID.Text));
                        return;
                        //GetID_No();//如已存在編號則重取最大單據編號
                    }            
                }
                const string sql_i = 
                @"INSERT INTO dbo.so_pi_custom_mostly
                (id,pi_date,remark,state,create_by,create_date) VALUES (@id,@pi_date,@remark,@state,@user_id,getdate())";
                const string sql_u = 
                @"Update so_pi_custom_mostly SET pi_date=@pi_date,remark=@remark,update_by=@user_id,update_date=getdate() WHERE id=@id ";   
                
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString); //dgsql2 dgcf_db
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
                        myCommand.Parameters.AddWithValue("@pi_date", clspub.Return_String_Date(dtdate.EditValue.ToString()));
                        
                        myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                        myCommand.Parameters.AddWithValue("@state", "0");                       
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);                                       
						myCommand.ExecuteNonQuery();                 

                        //處理【項目刪除】刪除明細資料
                        string sql_item_d;
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            //刪除明細
                            sql_item_d = @"DELETE FROM dbo.so_pi_custom_details WHERE id=@id and sequence_id=@sequence_id";
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString()); 
                            myCommand.ExecuteNonQuery();
                        }
                        
                        //保存明細
                        int curRow;
                        string rowStatus;
						if (dgvDetails.RowCount > 0)
						{							
                            const string sql_item_i =
                                @"INSERT INTO dbo.so_pi_custom_details (id,sequence_id,mo_id,oc_no,remark) VALUES (@id,@sequence_id,@mo_id,@oc_no,@remark)";
                            const string sql_item_u =
                                @"Update dbo.so_pi_custom_details SET mo_id=@mo_id,oc_no=@oc_no,remark=@remark Where id=@id and sequence_id=@sequence_id";                            
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
                                    myCommand.Parameters.AddWithValue("@oc_no", dgvDetails.GetRowCellValue(curRow, "oc_no").ToString());
                                    myCommand.Parameters.AddWithValue("@remark", dgvDetails.GetRowCellValue(curRow, "remark").ToString());
                                    myCommand.ExecuteNonQuery();
                                }
							}
						}

                        check_mo = true;
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
            check_mo = true;
			SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
			Set_Grid_Status(false);
            splitContainer1.Panel1Collapsed = true;
			mState = "";			
			dtTempDel.Clear();
           
			if (save_flag)
			{
				Find_doc(txtID.Text);                
				MessageBox.Show("當前数據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
                MessageBox.Show("當前数據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}        

		private bool Save_Head_Before_Valid() //保存前檢查主檔資料有效性
		{
            if (txtID.Text == "" || dtdate.Text == "" )
            {	
				MessageBox.Show("單據號、日期不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else			
				return true;
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
       
        /// <summary>
        /// 取單據序號
        /// </summary>
        private void GetID_No()
        {
            if (mState != "")
            {
                string strYearmonth = str_date.Replace("-", "").Substring(0,6);
                string strBill_type = "PI" + strYearmonth;
                string sql = string.Format(@"Select CAST(Substring(max(id),9,5) as int) + 1 as bill_code 
                                   From so_pi_custom_mostly with(nolock) WHERE id like '{0}%'",strBill_type);
                DataTable dt = clsPublicOfCF01.GetDataTable(sql);
                if (!string.IsNullOrEmpty(dt.Rows[0]["bill_code"].ToString()))
                {                        
                    txtID.Text = strBill_type + (int.Parse(dt.Rows[0]["bill_code"].ToString())).ToString("00000");
                }
                else
                {
                    txtID.Text = strBill_type + "00001";
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
            if (txtDat1.Text == "" && txtDat2.Text == "" &&txtOcno1.Text=="" &&txtOcno2.Text=="" &&txtMo_id1.Text =="" &&txtMo_id2.Text=="")
            {
                MessageBox.Show("查詢條件不可以為空!", "提示信息");
                return;
            }
            string sql =
            @"Select A.id,Convert(varchar(10),pi_date,120) as pi_date,B.sequence_id,B.mo_id,B.oc_no
            FROM so_pi_custom_mostly A with(nolock),so_pi_custom_details B with(nolock) WHERE A.id=B.id ";
            if (txtId1.Text != "")
                sql += string.Format(" AND A.id>='{0}'", txtId1.Text);
            if (txtId2.Text != "")
                sql += string.Format(" AND A.id<='{0}'", txtId2.Text);
            if (txtDat1.Text != "")
                sql += string.Format(" AND A.pi_date>='{0}'", txtDat1.Text);
            if (txtDat2.Text != "")
                sql += string.Format(" AND A.pi_date<='{0}'", txtDat2.Text);
            sql += " and A.state<>'2'";
            if (txtMo_id1.Text != "")
                sql += string.Format(" AND B.mo_id>='{0}'", txtMo_id1.Text);
            if (txtMo_id2.Text != "")
                sql += string.Format(" AND B.mo_id<='{0}'", txtMo_id2.Text);
            if (txtOcno1.Text != "")
                sql += string.Format(" AND B.oc_no>='{0}'", txtOcno1.Text);
            if (txtOcno2.Text != "")
                sql += string.Format(" AND B.oc_no<='{0}'", txtOcno2.Text);                       
            sql += " ORDER BY A.id,B.sequence_id";
            dtFind_Date = clsPublicOfCF01.GetDataTable(sql);
            dgvFind.DataSource = dtFind_Date;
            if (dtFind_Date.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的数據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.RowCount > 0)
            {                
                if (txtID.Text != dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id"].Value.ToString())
                {
                    txtID.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                    //txtVer.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["ver1"].Value.ToString();
                    Find_doc(txtID.Text);
                }
            }
        }

        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strName = dgvFind.Columns[e.ColumnIndex].Name;
            if (strName == "id")
            {                
                tabControl1.SelectTab(0);
            }
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }     

        private void txtOcno1_Leave(object sender, EventArgs e)
        {
            txtOcno2.Text = txtOcno1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id2.Text;
        }       

        private void Print()
        {
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("沒有要列印的數據!", "提示信息");
                return;
            }
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",txtID.Text)
            };

            DataTable dtReprot = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_custom_pi", paras);
            if (dtReprot.Rows.Count > 0)
            {
                using (xrPi_Custom myReport1 = new xrPi_Custom() { DataSource = dtReprot })
                {
                    myReport1.CreateDocument();
                    myReport1.PrintingSystem.ShowMarginsWarning = false;
                    myReport1.ShowPreviewDialog();
                }
            }
            else
                MessageBox.Show("沒有要列印的數據(頁數可能已被注銷)!", "提示信息"); 
        }

        private void Print2()
        {
            if (txtOcno1.Text == "" || txtOcno2.Text == "")
            {
                MessageBox.Show("OC No.不可以為空!", "提示信息");
                txtOcno1.Focus();
                return;
            };

            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@oc_no1",txtOcno1.Text),
              new SqlParameter("@oc_no2",txtOcno2.Text)
            };

            DataTable dtReprot = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_custom_pi_Original", paras);
            if (dtReprot.Rows.Count > 0)
            {
                using (xrPi_Custom myReport1 = new xrPi_Custom() { DataSource = dtReprot })
                {
                    myReport1.CreateDocument();
                    myReport1.PrintingSystem.ShowMarginsWarning = false;
                    myReport1.ShowPreviewDialog();
                }
            }
            else
                MessageBox.Show("沒有要列印的數據[根據OC No.列印PI]!", "提示信息");
        }

        //private void Set_PanelCollapsed()
        //{
        //    if (splitContainer1.Panel1Collapsed == false)
        //        splitContainer1.Panel1Collapsed = true;
        //    else
        //        splitContainer1.Panel1Collapsed = false; 
        //}    

        private void Get_MO_Info(string mo_id)
        {
            if (mState != "" && mo_id != "")
            {
                string sql = string.Format("Select id FROM so_order_details Where within_code='0000' and mo_id='{0}' and state<>'2'", mo_id);
                string strOcno = clsGeo.ExecuteSqlReturnObject(sql);
                if (!string.IsNullOrEmpty(strOcno))
                {
                    AddNew_Item();
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", mo_id);
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "oc_no", strOcno);
                    check_mo = true;

                    //txtOcno.Text = strOcno;
                    //check_mo = true;                    
                }
                else
                {
                    MessageBox.Show("無效的頁數!", "提示信息");
                    //ColumnView view1 = (ColumnView)dgvDetails;
                    //view1.FocusedColumn = view1.Columns["mo_id"]; //設置單元格焦點 
                    //view1.SelectAll();
                    check_mo = false;
                    txtMo_id.Focus();
                }
            }
        }

        private void btnSaveSet_Click(object sender, EventArgs e)
        {
            //if (clsAppPublic.set_find_Value(this.Name, tabControl1.TabPages[1].Controls))
            if (clsApp.set_find_Value(this.Name, tabControl1.TabPages[1].Controls) > 0)
                MessageBox.Show("查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }     

        private void txtMo_id_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtMo_id.Text == "")
                        return;
                    Get_MO_Info(txtMo_id.Text);
                    txtMo_id.Text = "";
                    break;
            }
        }

        private void clMo_id_Leave(object sender, EventArgs e)
        {
            dgvDetails.CloseEditor();
            string mo_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id").ToString();
            if (mState != "" && mo_id != "")
            {
                string sql = string.Format("Select id FROM so_order_details Where within_code='0000' and mo_id='{0}' and state<>'2'", mo_id);
                string strOcno = clsGeo.ExecuteSqlReturnObject(sql);
                if (!string.IsNullOrEmpty(strOcno))
                {
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "oc_no", strOcno);
                    check_mo = true;
                }
                else
                {
                    MessageBox.Show("無效的頁數!", "提示信息");                   
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "mo_id", "");
                    dgvDetails.SetRowCellValue(dgvDetails.FocusedRowHandle, "oc_no", "");
                        
                    check_mo = false;
                }
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }


	}
}
