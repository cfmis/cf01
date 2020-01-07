using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;


namespace cf01.Forms
{
	public partial class frmQuotationSub : Form
	{
        private clsAppPublic clsAppPublic = new clsAppPublic();
		public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態	
		public bool save_flag;
        public string test_public_path = "";
	
		DataTable dtSub = new DataTable();
		DataTable dtTempDel = new DataTable();

		public frmQuotationSub(string temp_code)
		{
			InitializeComponent();
            txtTemp_code.Text = temp_code;
            //clsAppPublic.SetToolBarEnable("frmQuotation", this.Controls);
		}

        private void frmQuotationSub_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAppPublic = null;
            dtSub.Dispose();
            dtTempDel.Dispose();
        }

		private void frmQuotationSub_Load(object sender, EventArgs e)
		{			
            Load_Data();
            //需將數據類型轉成布林型,并允許多選,否則將無法選中并多選，切記!       
            foreach (DataColumn col in dtSub.Columns)
            {
                if (col.ColumnName == "approval_status")
                {
                    //修改列类型
                    col.DataType = typeof(bool);
                    break;
                }
            }
			//gridControl1.DataSource = dtSub;
			//臨時項目刪除表結構
			dtTempDel = dtSub.Clone();

            //設置Status下拉框數據源
            
            DataTable dtStatus = new DataTable();
            dtStatus = clsPublicOfCF01.GetDataTable("Select typ_cdesc as id From  bs_type WHERE typ_group='Z' ORDER BY typ_code");
            
            clLkpStatus.DataSource = dtStatus;
            clLkpStatus.ValueMember = "id";
            clLkpStatus.DisplayMember = "id";

            mState = "EDIT";			
		}


        private void Load_Data()
        {
            string strSql = string.Format(@"SELECT temp_code,seq_id,sub,pvh_no,status,approval_date,approval_status,approval_by,attn_path,remark,crusr,crtim,amusr,amtim
                            FROM dbo.quotation_sub WHERE temp_code='{0}'", txtTemp_code.Text);
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
				newRow["temp_code"] = txtTemp_code.Text;
				newRow["seq_id"] = gridView1.GetRowCellDisplayText(curRow, "seq_id");
				newRow["sub"] = gridView1.GetRowCellDisplayText(curRow, "sub");
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
			if (!String.IsNullOrEmpty(txtTemp_code.Text)) // 有內容
			{
				if (Check_Details_Valid())
				{
					return;
				}
				//Set_Grid_Status(true);
                string strSeq_id = (gridView1.RowCount + 1).ToString("000");
				gridView1.AddNewRow();//新增
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq_id", strSeq_id);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "temp_code", txtTemp_code.Text);
				ColumnView view = (ColumnView)gridView1;//初始單元格焦點
				view.FocusedColumn = view.Columns["sub"];
				view.Focus();
			}
			else
			{
				MessageBox.Show("主表Seq No.不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);				
			}
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
                string strSql = ""; 
                string strSubmo = "";
				int curRow = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					curRow = gridView1.GetRowHandle(i);
                    strSubmo = gridView1.GetRowCellDisplayText(curRow, "sub");
                    if (String.IsNullOrEmpty(strSubmo))
					{
						_flag = true;
						MessageBox.Show("Sub Items 不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)gridView1;
						view1.FocusedColumn = view1.Columns["sub"]; //設置單元格焦點                        
						break;
					}

                    strSql = String.Format("Select '1' From {0}so_order_details Where within_code='0000' and mo_id='{1}'", DBUtility.remote_db, strSubmo);
                    using (DataTable dt = clsPublicOfCF01.GetDataTable(strSql))
                    {
                        if (dt.Rows.Count == 0)
                        {
                            _flag = true;
                            MessageBox.Show(string.Format("辦單頁數【{0}】不存在!",strSubmo), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ColumnView view1 = (ColumnView)gridView1;
                            view1.FocusedColumn = view1.Columns["sub"]; //設置單元格焦點                        
                            break;
                        }
                    }
				}
			}
			return _flag;
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
			#region 保存編輯
			if (mState == "EDIT")
			{
				string rowStatus = "";
				string strSeq_id = "";
                const string sql_item_i =
                    @"INSERT INTO dbo.quotation_sub(temp_code,seq_id,sub,pvh_no,status,Approval_status,Approval_date,Approval_by,attn_path,remark,crusr,crtim)
					VALUES(@temp_code,@seq_id,@sub,@pvh_no,@status,@Approval_status,CASE LEN(@Approval_date) WHEN 0 Then null ELSE @Approval_date END,@Approval_by,@attn_path,@remark,@user_id,getdate())";
                const string sql_item_u =
                    @"UPDATE dbo.quotation_sub 
					SET sub=@sub,pvh_no=@pvh_no,status=@status,Approval_status=@Approval_status,Approval_date=CASE LEN(@Approval_date) WHEN 0 THEN null ELSE @Approval_date END,
                    approval_by=@Approval_by,attn_path=@attn_path,remark=@remark,amusr=@user_id,amtim=getdate()                        
					WHERE temp_code=@temp_code AND seq_id=@seq_id";
		
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
                            const string sql_item_d =@"DELETE FROM dbo.quotation_sub WHERE temp_code=@temp_code AND seq_id=@seq_id AND sub=@sub";
							myCommand.CommandText = sql_item_d;
							myCommand.Parameters.Clear();
							myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text.Trim());
							myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());
							myCommand.Parameters.AddWithValue("@sub", dtTempDel.Rows[i]["sub"].ToString());
							myCommand.ExecuteNonQuery();
						}
						//保存明細資料                        
                        bool blApproval = false;
						if (gridView1.RowCount > 0)
						{
							for (int i = 0; i < dtSub.Rows.Count; i++)
							{
								rowStatus = dtSub.Rows[i].RowState.ToString();
								if (rowStatus == "Added" || rowStatus == "Modified")
								{
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text);                                   
                                    myCommand.Parameters.AddWithValue("@sub", dtSub.Rows[i]["sub"].ToString());
                                    myCommand.Parameters.AddWithValue("@pvh_no", dtSub.Rows[i]["pvh_no"].ToString());
                                    myCommand.Parameters.AddWithValue("@status", dtSub.Rows[i]["status"].ToString());                                   
                                    myCommand.Parameters.AddWithValue("@approval_date", clsAppPublic.Return_String_Date(dtSub.Rows[i]["approval_date"].ToString()));
                                    if (dtSub.Rows[i]["approval_status"].ToString() == "True")
                                        blApproval = true;
                                    else
                                        blApproval = false;
                                    myCommand.Parameters.AddWithValue("@approval_status", blApproval);
                                    myCommand.Parameters.AddWithValue("@approval_by", dtSub.Rows[i]["approval_by"].ToString());
                                    myCommand.Parameters.AddWithValue("@attn_path", dtSub.Rows[i]["attn_path"].ToString());
                                    myCommand.Parameters.AddWithValue("@remark", dtSub.Rows[i]["remark"].ToString());
                                    if (rowStatus == "Added")
									{
										myCommand.CommandText = sql_item_i;										
                                        strSeq_id = gridView1.GetRowCellValue(i, "seq_id").ToString();
                                        if (Valid_Doc(txtTemp_code.Text, strSeq_id))
                                        {
                                            //如存主鍵已存在重取取最大序號
                                            strSeq_id = Get_Details_Seq(txtTemp_code.Text);
                                            gridView1.SetRowCellValue(i, "seq_id", strSeq_id);//重設置表格中的序號
                                        }   
									}
									if (rowStatus == "Modified")
									{
										myCommand.CommandText = sql_item_u;
										strSeq_id = dtSub.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
									}
                                    myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
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

		private bool Save_Before_Valid() //保存前檢查主檔資料有效性
		{
			if (txtTemp_code.Text == "")
			{
                MessageBox.Show("主檔序號不可爲空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool Valid_Doc(string temp_doc,string seq_id) //主建是否已存在
		{
			bool flag;			
            string strSql = String.Format("Select '1' FROM dbo.quotation_sub WHERE temp_code='{0}' and seq_id='{1}'", temp_doc,seq_id);
			DataTable dt = clsPublicOfCF01.GetDataTable(strSql);            
			if (dt.Rows.Count > 0)
			{
                MessageBox.Show("編號已存在：" + String.Format("【{0}】", txtTemp_code.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.quotation_sub with(nolock) WHERE temp_code ='{0}'", _id));
			string strSeq;
			if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
			{
				strSeq = "001";
			}
			else
			{
				strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = strSeq.Substring(0, 3);				
                strSeq = (Int32.Parse(strSeq) + 1).ToString("000");
			}
			dtMaxseq.Dispose();
			return strSeq;
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

		private void clBtnTest_report_no_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();			
            openFile.Filter = "E-Mail Files|*.msg;*.PDF";
			openFile.RestoreDirectory = true;
			openFile.Title = "附件文檔";
			openFile.InitialDirectory = test_public_path; //初始路徑      
			openFile.ShowDialog();

			string strFile = openFile.FileName;
			if (strFile != "")
			{
				string strReport_path = GetConString(strFile, test_public_path);
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "attn_path", strReport_path);
			}
		}

		private static string GetConString(string _all_path, string _public_path)
		{
			string str_result = "";
			int lenth_all = _all_path.Length;
			int lenth_public = _public_path.Length;
			str_result = _all_path.Substring(lenth_public, lenth_all - lenth_public);
			return str_result;
		}

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtTemp_code.Focus();
            gridView1.CloseEditor();
            Save();
        }

        private void clisApproval_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.CloseEditor();   //關鍵語句,重要,否則CheckBox值不會立即更改
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "approval_status").ToString() == "True")
            {
                string strDate = clsPublicOfCF01.ExecuteSqlReturnObject("SELECT Convert(char(10),getdate(),120)");
                strDate = DateTime.Parse(strDate).Date.ToString("yyyy-MM-dd");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_date", strDate);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_by", DBUtility._user_id);
            }
            else
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_date", null);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_by", null);
            }            
        }

        private void clBtnAttn_path_DoubleClick(object sender, EventArgs e)
        {
            ////打開PDF檔
            //string strFile = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "attn_path");
            //if (!string.IsNullOrEmpty(strFile))
            //{
            //    strFile = test_public_path + strFile.Trim();
            //    clsTestProductPlan.Open_test_pdf(strFile);
            //}
        }

        private void clLkpStatus_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.CloseEditor();   //關鍵語句,重要,否則CheckBox值不會立即更改
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "status").ToString() != "")
            {
                string strDate = clsPublicOfCF01.ExecuteSqlReturnObject("SELECT Convert(char(10),getdate(),120)");
                strDate = DateTime.Parse(strDate).Date.ToString("yyyy-MM-dd");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_date", strDate);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_by", DBUtility._user_id);
            }
            else
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_date", null);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_by", null);
            }            
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Load_Data();
            dtTempDel.Clear();
        }

        private void clSub_Leave(object sender, EventArgs e)
        {
            //
        }

        

     
        


	}
}
