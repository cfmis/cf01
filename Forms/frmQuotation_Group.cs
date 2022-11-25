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
using DevExpress.XtraEditors.Repository;


namespace cf01.Forms
{
	public partial class frmQuotation_Group : Form
	{		
		string editState = ""; //新增或編輯的狀態	
		bool saveFlag;
        string group = "";
        	
		DataTable dtGroup = new DataTable();
		DataTable dtTempDel = new DataTable();

		public frmQuotation_Group(string temp_code,string _group)
		{
			InitializeComponent();
            txtTemp_code.Text = temp_code;
            //clsAppPublic.SetToolBarEnable("frmQuotation", this.Controls);
            clsToolBar obj = new clsToolBar("frmQuotation", this.Controls);
            obj.SetToolBar();
            group = _group;
		}

		private void frmQuotation_Group_Load(object sender, EventArgs e)
		{
			//生成gridview1明細表結構
            Load_Data();
            
			//臨時項目刪除表結構
			dtTempDel = dtGroup.Clone();            

            string strSql = @"Select typ_code AS id,typ_code+' ('+typ_cdesc+')' AS cdesc From bs_type Where typ_group='3'";
            System.Data.DataTable dtSales_Group = new System.Data.DataTable();
            dtSales_Group = clsPublicOfCF01.GetDataTable(strSql);
            clLkpGroup.DataSource = dtSales_Group;
            clLkpGroup.ValueMember = "id";
            clLkpGroup.DisplayMember = "id";

            editState = "EDIT";			
		}

        private void Load_Data()
        {
            string strSql = string.Format(@"SELECT temp_code,seq_id,group_id,remark,crusr,crtim,amusr,amtim
                            FROM dbo.quotation_group WHERE temp_code='{0}'", txtTemp_code.Text);
            dtGroup = clsPublicOfCF01.GetDataTable(strSql);
            gridControl1.DataSource = dtGroup;
        }

		private void BTNEXIT_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BTNNEW_Click(object sender, EventArgs e)
		{
			AddNew_Item();
		}

        private void BTNDELTE_Click(object sender, EventArgs e)
		{
			if (gridView1.RowCount == 1)
			{
                MessageBox.Show("注意：已是最后一條記錄,不可以刪除.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                newRow["group_id"] = gridView1.GetRowCellDisplayText(curRow, "group_id");
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
				//Set_Grid_Status(true);
                string strSeq_id = (this.gridView1.RowCount + 1).ToString("000");
				gridView1.AddNewRow();//新增
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq_id", strSeq_id);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "temp_code", txtTemp_code.Text);
				ColumnView view = (ColumnView)gridView1;//初始單元格焦點
				view.FocusedColumn = view.Columns["group_id"];
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
				int curRow = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					curRow = gridView1.GetRowHandle(i);
					if (string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "group_id")))
					{
						_flag = true;
						MessageBox.Show("組別資料不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ColumnView view1 = (ColumnView)gridView1;
                        view1.FocusedColumn = view1.Columns["group_id"]; //設置單元格焦點                        
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
			saveFlag = false;
			#region 保存編輯
			if (editState == "EDIT")
			{
				string rowStatus = "";
				string strSeq_id = "";
                const string sql_item_i =
                    @"INSERT INTO dbo.quotation_group(temp_code,seq_id,group_id,remark,crusr,crtim)
					VALUES(@temp_code,@seq_id,@group_id,@remark,@user_id,getdate())";
                const string sql_item_u =
                    @"UPDATE dbo.quotation_group 
					SET group_id=@group_id,remark=@remark,amusr=@user_id,amtim=getdate()                        
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
                            const string sql_item_d = @"DELETE FROM dbo.quotation_group WHERE temp_code=@temp_code AND seq_id=@seq_id AND group_id=@group_id";
							myCommand.CommandText = sql_item_d;
							myCommand.Parameters.Clear();
							myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text.Trim());
							myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());
                            myCommand.Parameters.AddWithValue("@group_id", dtTempDel.Rows[i]["group_id"].ToString());
							myCommand.ExecuteNonQuery();
						}
						//保存明細資料                       
						if (gridView1.RowCount > 0)
						{
							for (int i = 0; i < dtGroup.Rows.Count; i++)
							{
								rowStatus = dtGroup.Rows[i].RowState.ToString();
								if (rowStatus == "Added" || rowStatus == "Modified")
								{
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@temp_code", txtTemp_code.Text);
                                    myCommand.Parameters.AddWithValue("@group_id", dtGroup.Rows[i]["group_id"].ToString());                                    
                                    myCommand.Parameters.AddWithValue("@remark", dtGroup.Rows[i]["remark"].ToString());
                                    if (rowStatus == "Added")
									{
										myCommand.CommandText = sql_item_i;
										//strSeq_id = Get_Details_Seq(txtTemp_code.Text); //新增狀態重新取最大序號   
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
										strSeq_id = dtGroup.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
									}
                                    myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
									myCommand.ExecuteNonQuery();
								}
							}
						}
						myTrans.Commit(); //數據提交
						saveFlag = true;
					}
					catch (Exception E)
					{
						myTrans.Rollback(); //數據回滾
						saveFlag = false;
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
			if (saveFlag)
			{
                dtGroup.AcceptChanges();//需加此語句，刷新dtGroup的新增個修改的狀態
                MessageBox.Show("數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtTempDel.Clear();
			}
			else
			{
                MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private bool Save_Before_Valid() //保存前檢查主檔資料有效性
		{
            bool blResult = true;
            string strGroup = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                strGroup = strGroup + gridView1.GetRowCellValue(i, "group_id").ToString();
            }
            if (!strGroup.Contains(group))
            {
                MessageBox.Show("當前表格中的組別至少要有一個與主表中的組別保持一致才可以!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                blResult = false;
            }            

            if (IsRepeat())
            {
                blResult = false;
            }    
       
            return blResult;
		}


        private bool IsRepeat() //組別不允許有重覆
        {
            if (gridView1.RowCount < 2)
            {
                return false;
            }
            bool result = false;
            string strGroup = "";
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                strGroup = gridView1.GetRowCellDisplayText(i, "group_id");
                for (int j = i + 1; j <= gridView1.RowCount - 1; j++)
                {
                    if (strGroup == gridView1.GetRowCellDisplayText(j, "group_id"))
                    {
                        MessageBox.Show("組別不可以有重覆!\n\n" + string.Format("【{0}】", strGroup),
                                                  "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

		private bool Valid_Doc(string temp_doc,string seq_id) //主建是否已存在
		{
			bool flag;			
            string strSql = string.Format("Select '1' FROM dbo.quotation_group WHERE temp_code='{0}' and seq_id='{1}'", temp_doc,seq_id);
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

            dtMaxseq = clsPublicOfCF01.GetDataTable(string.Format("SELECT MAX(seq_id) as seq_id FROM dbo.quotation_group with(nolock) WHERE temp_code ='{0}'", _id));
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

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("請輸入所屬組別資料!","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtTemp_code.Focus();
            gridView1.CloseEditor();
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Load_Data();
            dtTempDel.Clear();
        }     
        


	}
}
