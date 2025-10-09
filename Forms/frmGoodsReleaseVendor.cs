using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using DevExpress.XtraEditors;

namespace cf01.Forms
{
	public partial class frmGoodsReleaseVendor : Form
	{
        private clsAppPublic clsAppPublic = new clsAppPublic();
		public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態	
		public bool save_flag;       
	
		DataTable dtSub = new DataTable();
		DataTable dtTempDel = new DataTable();

		public frmGoodsReleaseVendor()
		{
			InitializeComponent();                
		}

        private void frmGoodsReleaseVendor_FormClosed()
        {
            clsAppPublic = null;
            dtSub.Dispose();
            dtTempDel.Dispose();
        }

		private void frmGoodsReleaseVendor_Load(object sender, EventArgs e)
		{			
            Load_Data();          
			//臨時項目刪除表結構
			dtTempDel = dtSub.Clone();

            //設置Status下拉框數據源            
            DataTable dtVendor = new DataTable();
            dtVendor = clsPublicOfCF01.GetDataTable(string.Format("Select id,name From {0}it_vendor WHERE type='OP' and state<>'2' ORDER BY id", DBUtility.remote_db));            
            clVendor.DataSource = dtVendor;
            clVendor.ValueMember = "id";
            clVendor.DisplayMember = "id";
            Load_Data();
            mState = "EDIT";
		}


        private void Load_Data()
        {
            string strSql = @"SELECT vendor_id,vendor_name FROM dbo.bs_release_vendor order by vendor_id";
            dtSub = clsPublicOfCF01.GetDataTable(strSql);
            gridControl1.DataSource = dtSub;
        }

		private void BTNEXIT_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BTNNEW_Click(object sender, EventArgs e)
		{
			AddNew_Item();
		}

        private void BTNDELTE_Click(object sender, EventArgs e)
		{
			if (gridView1.RowCount == 0)
			{
				return;
			}
			DialogResult result = MessageBox.Show("是否要刪除當前行?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int curRow = gridView1.FocusedRowHandle;
				//將當前行刪除幷加到臨時表中
				DataRow newRow = dtTempDel.NewRow();
				newRow["vendor_id"] = gridView1.GetRowCellDisplayText(curRow, "vendor_id");                
				dtTempDel.Rows.Add(newRow);
				gridView1.DeleteRow(curRow);//移走當前行
                Save();
			}
		}


		private void Set_Grid_Status(bool _flag) // 表格可編號否
		{
			//false--不可編輯;true--可以編輯
			gridView1.OptionsBehavior.Editable = _flag;
			//gridView2.OptionsBehavior.Editable = _flag;
		}	

		private void AddNew_Item()
		{			
			if (Check_Details_Valid())
			{
				return;
			}
			//Set_Grid_Status(true);               
			gridView1.AddNewRow();//新增				
			ColumnView view = (ColumnView)gridView1;//初始單元格焦點
			view.FocusedColumn = view.Columns["vendor_id"];
			view.Focus();
		}

		private bool Check_Details_Valid() //檢查明細資料的有效性
		{
			//測試項目必須有輸入
			bool _flag = false;
			if (gridView1.RowCount > 0)
			{
                txtTemp_code.Focus();
				//因toolStrip控件焦點問題
				//設置焦點行某單元格獲得焦點，加此代碼目的使輸入的值生效，附止取到的值爲空
				// ColumnView view = (ColumnView)gridView1 ;
				// view.FocusedColumn = view.Columns["test_item_id"];                
                string strVendor = "";
				int curRow = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					curRow = gridView1.GetRowHandle(i);
                    strVendor = gridView1.GetRowCellDisplayText(curRow, "vendor_id");
                    if (string.IsNullOrEmpty(strVendor))
					{
						_flag = true;
						MessageBox.Show("供應商不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)gridView1;
						view1.FocusedColumn = view1.Columns["vendor_id"]; //設置單元格焦點                        
						break;
					}
				}
			}
			return _flag;
		}

		private void Save()  //保存
        { 					
			if (Check_Details_Valid())//檢查明細資料的有效性
			{
				return;
			}
			save_flag = false;
            bool valid_flag = true;
			#region 保存編輯
			if (mState == "EDIT")
			{
				string rowStatus = "";				
                string sql_item_i = "INSERT INTO dbo.bs_release_vendor(vendor_id,vendor_name) VALUES(@vendor_id,@vendor_name)";
                string sql_item_u = "UPDATE dbo.bs_release_vendor SET vendor_name=@vendor_name WHERE vendor_id=@vendor_id";
		
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						//刪除明細資料
						for (int i = 0; i < dtTempDel.Rows.Count; i++)
						{                            
                            string sql_item_d = @"DELETE FROM dbo.bs_release_vendor WHERE vendor_id=@vendor_id";
							myCommand.CommandText = sql_item_d;
							myCommand.Parameters.Clear();							
							myCommand.Parameters.AddWithValue("@vendor_id", dtTempDel.Rows[i]["vendor_id"].ToString());						
							myCommand.ExecuteNonQuery();
						}
                        //保存明細資料 
                        string vendor_id = "";
						if (gridView1.RowCount > 0)
						{
							for (int i = 0; i < dtSub.Rows.Count; i++)
							{
								rowStatus = dtSub.Rows[i].RowState.ToString();
								if (rowStatus == "Added" || rowStatus == "Modified")
								{
                                    myCommand.Parameters.Clear();                                
                                    myCommand.Parameters.AddWithValue("@vendor_id", dtSub.Rows[i]["vendor_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@vendor_name", dtSub.Rows[i]["vendor_name"].ToString());
                                    
                                    if (rowStatus == "Added")
									{
                                        vendor_id = dtSub.Rows[i]["vendor_id"].ToString();
                                        if (Valid_Doc(vendor_id))
                                        {
                                            valid_flag = false;
                                            break;
                                        }
										myCommand.CommandText = sql_item_i;	
									}
									if (rowStatus == "Modified")
									{
										myCommand.CommandText = sql_item_u;										
									}                                   
									myCommand.ExecuteNonQuery();
								}
							}
						}
                        if (valid_flag)
                        {
                            myTrans.Commit(); //數據提交
                            save_flag = true;
                        }						
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
			}
			#endregion
			if (save_flag)
			{
                dtSub.AcceptChanges();//需加此語句，刷新dtSub的新增個修改的狀態
                MessageBox.Show("數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
                MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
        
		private bool Valid_Doc(string id) //主建是否已存在
		{
			bool flag;			
            string strSql = string.Format("Select '1' FROM dbo.bs_release_vendor WHERE vendor_id='{0}'", id);
			DataTable dt = clsPublicOfCF01.GetDataTable(strSql);            
			if (dt.Rows.Count > 0)
			{
                MessageBox.Show($"供應商編號【{id}】已存在!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
			}
			else
			{
				flag = false;
			}
			dt.Dispose();
			return flag;
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

	
        private void BTNSAVE_Click(object sender, EventArgs e)
        {           
            gridView1.CloseEditor();
            Save();
        }        
      
        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Load_Data();
            dtTempDel.Clear();
        }

        private void clVendor_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit objItem = (LookUpEdit)sender;
            string strid = objItem.Text;
            int indexSelect = clVendor.GetDataSourceRowIndex("id", strid);
            string vendorName = clVendor.GetDataSourceValue("name", indexSelect).ToString();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "vendor_name", vendorName);
        }
    }
}
