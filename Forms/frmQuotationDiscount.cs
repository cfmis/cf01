using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
	public partial class frmQuotationDiscount : Form
	{
        private clsAppPublic clsAppPublic = new clsAppPublic();
		public string mID = "";    //臨時的主鍵值
		public string mState = ""; //新增或編輯的狀態	
		public bool save_flag;
        public string test_public_path = "";
	
		DataTable dtPriceDisc = new DataTable();
		DataTable dtTempDel = new DataTable();
        clsAppPublic clsApp = new clsAppPublic();
        DataGridViewRow dgv_row = new DataGridViewRow();

        public frmQuotationDiscount(string temp_code, DataGridViewRow dgvrow)
		{
			InitializeComponent();
            txtTemp_code.Text = temp_code;
            dgv_row = dgvrow;
            //clsAppPublic.SetToolBarEnable("frmQuotation", this.Controls);
        }

        private void frmQuotationDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAppPublic = null;
            dtPriceDisc.Dispose();
            dtTempDel.Dispose();
        }

		private void frmQuotationDiscount_Load(object sender, EventArgs e)
		{			
            Load_Data();  
			//臨時項目刪除表結構
			dtTempDel = dtPriceDisc.Clone();
            mState = "EDIT";
		}


        private void Load_Data()
        {
            string strSql = string.Format(
            @"SELECT temp_code,seq_id,number_enter,price_usd,price_hkd,price_rmb,price_unit,usd_ex_fty,hkd_ex_fty,
            vnd_bp,price_vnd_usd,price_vnd,price_vnd_grs,price_vnd_pcs,moq_qty,valid_date,remark,crusr,crtim,amusr,amtim
            FROM dbo.quotation_discount WHERE temp_code='{0}' Order by seq_id", txtTemp_code.Text);
            dtPriceDisc = clsPublicOfCF01.GetDataTable(strSql);
            gridControl1.DataSource = dtPriceDisc;
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
			if (!string.IsNullOrEmpty(txtTemp_code.Text)) // 有內容
			{
				if (Check_Details_Valid())
				{
					return;
				}
                string strSeq_id = "";
                int max_seq = getMaxNo();
                strSeq_id = (max_seq > 0) ? (max_seq + 1).ToString("000") : "001";                
                gridView1.AddNewRow();//新增
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq_id", strSeq_id);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "temp_code", txtTemp_code.Text);
               
                float bp = clsApp.Return_Float_Value(dgv_row.Cells["number_enter"].Value.ToString());
                float price_usd = clsApp.Return_Float_Value(dgv_row.Cells["price_usd"].Value.ToString());
                float price_hkd = clsApp.Return_Float_Value(dgv_row.Cells["price_hkd"].Value.ToString());
                float price_rmb = clsApp.Return_Float_Value(dgv_row.Cells["price_rmb"].Value.ToString());
                float usd_ex_fty = clsApp.Return_Float_Value(dgv_row.Cells["usd_ex_fty"].Value.ToString());
                float hkd_ex_fty = clsApp.Return_Float_Value(dgv_row.Cells["hkd_ex_fty"].Value.ToString());
                string price_unit = dgv_row.Cells["price_unit"].Value.ToString();
                string valid_date = dgv_row.Cells["valid_date"].Value.ToString();
                valid_date = string.IsNullOrEmpty(valid_date) ? "" : valid_date;
                float vnd_bp = clsApp.Return_Float_Value(dgv_row.Cells["vnd_bp"].Value.ToString());
                float price_vnd_usd = clsApp.Return_Float_Value(dgv_row.Cells["price_vnd_usd"].Value.ToString());
                float price_vnd = clsApp.Return_Float_Value(dgv_row.Cells["price_vnd"].Value.ToString());
                float price_vnd_grs = clsApp.Return_Float_Value(dgv_row.Cells["price_vnd_grs"].Value.ToString());
                float price_vnd_pcs = clsApp.Return_Float_Value(dgv_row.Cells["price_vnd_pcs"].Value.ToString());
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "number_enter", bp);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_usd", price_usd);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_hkd", price_hkd);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_rmb", price_rmb);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "usd_ex_fty", usd_ex_fty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "hkd_ex_fty", hkd_ex_fty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_unit", price_unit);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "vnd_bp", vnd_bp);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd_usd", price_vnd_usd);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd", price_vnd);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd_grs", price_vnd_grs);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd_pcs", price_vnd_pcs);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "valid_date", valid_date);

                ColumnView view = (ColumnView)gridView1;//初始單元格焦點
				view.FocusedColumn = view.Columns["number_enter"];
				view.Focus();
                gridView1.CloseEditor();
               
            }
			else
			{
				MessageBox.Show("主表Seq No.不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);				
			}
		}
        private int getMaxNo()
        {
            int seq = 0;
            if (gridView1.RowCount > 0)
            {
                gridView1.CloseEditor();
                string[] array;
                List<string> lst = new List<string>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    lst.Add(gridView1.GetRowCellValue(i, "seq_id").ToString());
                }
                array = lst.ToArray();
                seq = int.Parse(array.Max());
            }            
            return seq;
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
                string strBp = "";
				int curRow = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					curRow = gridView1.GetRowHandle(i);
                    strBp = gridView1.GetRowCellDisplayText(curRow, "number_enter");
                    if (string.IsNullOrEmpty(strBp))
					{
						_flag = true;
						MessageBox.Show("BP 不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)gridView1;
						view1.FocusedColumn = view1.Columns["number_enter"]; //設置單元格焦點                        
						break;
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
                string sql_item_i =
                @"INSERT INTO dbo.quotation_discount(temp_code,seq_id,number_enter,price_usd,price_hkd,price_rmb,price_unit,usd_ex_fty,hkd_ex_fty,
                 vnd_bp,price_vnd_usd,price_vnd,price_vnd_grs,price_vnd_pcs,moq_qty,valid_date,remark,crusr,crtim) VALUES
                 (@temp_code,@seq_id,@number_enter,@price_usd,@price_hkd,@price_rmb,@price_unit,@usd_ex_fty,@hkd_ex_fty,@vnd_bp,@price_vnd_usd,
                 @price_vnd,@price_vnd_grs,@price_vnd_pcs,@moq_qty,CASE LEN(@valid_date) WHEN 0 Then null ELSE @valid_date END,@remark,@user_id,getdate())";
                string sql_item_u =
                @"UPDATE dbo.quotation_discount 
				SET number_enter=@number_enter,price_usd=@price_usd,price_hkd=@price_hkd,price_rmb=@price_rmb,price_unit=@price_unit,usd_ex_fty=@usd_ex_fty,
                hkd_ex_fty=@hkd_ex_fty,vnd_bp=@vnd_bp,price_vnd_usd=@price_vnd_usd,price_vnd=@price_vnd,price_vnd_grs=@price_vnd_grs,
                price_vnd_pcs=@price_vnd_pcs,moq_qty=@moq_qty,valid_date=CASE LEN(@valid_date) WHEN 0 Then null ELSE @valid_date END,remark=@remark,amusr=@user_id,amtim=getdate()                        
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
                            const string sql_item_d = @"DELETE FROM dbo.quotation_discount WHERE temp_code=@temp_code AND seq_id=@seq_id";
							myCommand.CommandText = sql_item_d;
							myCommand.Parameters.Clear();
							myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text.Trim());
							myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());							
							myCommand.ExecuteNonQuery();
						}
						//保存明細資料                        
                       
						if (gridView1.RowCount > 0)
						{
							for (int i = 0; i < dtPriceDisc.Rows.Count; i++)
							{
								rowStatus = dtPriceDisc.Rows[i].RowState.ToString();
								if (rowStatus == "Added" || rowStatus == "Modified")
								{
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text); 
                                    myCommand.Parameters.AddWithValue("@number_enter", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["number_enter"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_usd", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_usd"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_hkd", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_hkd"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_rmb", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_rmb"].ToString()));                                    
                                    myCommand.Parameters.AddWithValue("@usd_ex_fty", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["usd_ex_fty"].ToString()));
                                    myCommand.Parameters.AddWithValue("@hkd_ex_fty", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["hkd_ex_fty"].ToString()));
                                    myCommand.Parameters.AddWithValue("@vnd_bp", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["vnd_bp"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_vnd_usd", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_vnd_usd"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_vnd", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_vnd"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_vnd_grs", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_vnd_grs"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_vnd_pcs", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["price_vnd_pcs"].ToString()));
                                    myCommand.Parameters.AddWithValue("@moq_qty", clsApp.Return_Float_Value(dtPriceDisc.Rows[i]["moq_qty"].ToString()));
                                    myCommand.Parameters.AddWithValue("@price_unit", dtPriceDisc.Rows[i]["price_unit"].ToString());
                                    myCommand.Parameters.AddWithValue("@valid_date", clsAppPublic.Return_String_Date(dtPriceDisc.Rows[i]["valid_date"].ToString()));
                                    myCommand.Parameters.AddWithValue("@remark", dtPriceDisc.Rows[i]["remark"].ToString());
                                    if (rowStatus == "Added")
									{
										myCommand.CommandText = sql_item_i;										
                                        strSeq_id = gridView1.GetRowCellValue(i, "seq_id").ToString();
                                        if (Valid_Doc(txtTemp_code.Text, strSeq_id))
                                        {
                                            //如存主鍵已存在重取最大序號
                                            strSeq_id = Get_Details_Seq(txtTemp_code.Text);
                                            gridView1.SetRowCellValue(i, "seq_id", strSeq_id);//重設置表格中的序號
                                        }   
									}
									if (rowStatus == "Modified")
									{
										myCommand.CommandText = sql_item_u;
										strSeq_id = dtPriceDisc.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
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
                dtPriceDisc.AcceptChanges();//需加此語句，刷新dtPriceDisc的新增個修改的狀態
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
            string strSql = string.Format("Select '1' FROM dbo.quotation_discount WHERE temp_code='{0}' and seq_id='{1}'", temp_doc,seq_id);
			DataTable dt = clsPublicOfCF01.GetDataTable(strSql);            
			if (dt.Rows.Count > 0)
			{
                MessageBox.Show("編號已存在：" + string.Format("【{0}】", txtTemp_code.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            dtMaxseq = clsPublicOfCF01.GetDataTable(string.Format("SELECT MAX(seq_id) as seq_id FROM dbo.quotation_discount with(nolock) WHERE temp_code ='{0}'", _id));
			string strSeq;
			if (string.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
			{
				strSeq = "001";
			}
			else
			{
				strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = strSeq.Substring(0, 3);				
                strSeq = (int.Parse(strSeq) + 1).ToString("000");
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

		//private void clBtnTest_report_no_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		//{
		//	OpenFileDialog openFile = new OpenFileDialog();			
  //          openFile.Filter = "E-Mail Files|*.msg;*.PDF";
		//	openFile.RestoreDirectory = true;
		//	openFile.Title = "附件文檔";
		//	openFile.InitialDirectory = test_public_path; //初始路徑      
		//	openFile.ShowDialog();

		//	string strFile = openFile.FileName;
		//	if (strFile != "")
		//	{
		//		string strReport_path = GetConString(strFile, test_public_path);
		//		gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "attn_path", strReport_path);
		//	}
		//}

		//private static string GetConString(string _all_path, string _public_path)
		//{
		//	string str_result = "";
		//	int lenth_all = _all_path.Length;
		//	int lenth_public = _public_path.Length;
		//	str_result = _all_path.Substring(lenth_public, lenth_all - lenth_public);
		//	return str_result;
		//}

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtTemp_code.Focus();
            gridView1.CloseEditor();
            Save();
        }

        //private void clisApproval_CheckedChanged(object sender, EventArgs e)
        //{
        //    gridView1.CloseEditor();   //關鍵語句,重要,否則CheckBox值不會立即更改
        //    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "approval_status").ToString() == "True")
        //    {
        //        string strDate = clsPublicOfCF01.ExecuteSqlReturnObject("SELECT Convert(char(10),getdate(),120)");
        //        strDate = DateTime.Parse(strDate).Date.ToString("yyyy-MM-dd");
        //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_date", strDate);
        //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_by", DBUtility._user_id);
        //    }
        //    else
        //    {
        //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_date", null);
        //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "approval_by", null);
        //    }            
        //} 
        

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Load_Data();
            dtTempDel.Clear();
        }

        private void clBp_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                gridView1.CloseEditor();   //關鍵語句,重要
                string price_unit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "price_unit").ToString();
                if (string.IsNullOrEmpty(price_unit))
                {
                    MessageBox.Show("單價單位不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                           
                string temp_code = txtTemp_code.Text;
                string cur_bp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "number_enter").ToString();
                string seq_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "seq_id").ToString();
                string strSql = string.Format(@"Select number_enter From quotation_discount Where temp_code='{0}' And seq_id='{1}'", temp_code, seq_id);
                DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
                if (dt.Rows.Count > 0)
                {
                    if(decimal.Parse(dt.Rows[0]["number_enter"].ToString()) != decimal.Parse(cur_bp))
                    {
                        CalcuPrice();
                    }
                }
                else
                {
                    CalcuPrice();
                }               
                //CalcuPriceDisc(txtDisc.Text); 
            }            
        }
        private void CalcuPrice()
        {
            string brand = dgv_row.Cells["brand"].Value.ToString();
            string formula = dgv_row.Cells["formula_id"].Value.ToString();
            string bp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "number_enter").ToString();
            string vn_bp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "vnd_bp").ToString(); 
            string price_unit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "price_unit").ToString();
            bool flag_vnd = dgv_row.Cells["flag_vnd"].Value.ToString() == "True" ? true : false;
            mdlFormula_Result objResult = new mdlFormula_Result();
            objResult = clsQuotation.Get_Cust_Formula(brand, formula, bp, price_unit, vn_bp, flag_vnd);           
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_usd", objResult.price_usd);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_rmb", objResult.price_rmb);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_hkd", objResult.price_hkd);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "hkd_ex_fty", objResult.hkd_ex_fty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "usd_ex_fty", objResult.usd_ex_fty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "vnd_bp", objResult.vnd_bp);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd_usd", objResult.price_vnd_usd);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd", objResult.price_vnd);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd_grs", objResult.price_vnd_grs);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_vnd_pcs", objResult.price_vnd_pcs);
         
        }

        private void clBp_Click(object sender, EventArgs e)
        {
           
        }
    }
}
