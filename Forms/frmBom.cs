using cf01.CLS;
using cf01.ModuleClass;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace cf01.Forms
{
	public partial class frmBom : Form
	{
		public string mID = "";    //臨時的主鍵值
		public string mVer = "0";
		public string mState = ""; //新增或編號的狀態        
		public static string str_language = "0";
		public string msgCustom;     
		public bool save_flag;
		public string temp_comp = "0000";
		public static string _max_ver = "";        
		public static string _ver = "";
		public static string _query_bom_id = "";
		public static string _MM = "";
		TreeNode preNode = null;
		DataTable dtTree_Data = new DataTable();
		DataTable dtMM = new DataTable();
		DataTable dtBOMDetail = new DataTable();
		DataTable dtUnit = new DataTable();
		DataTable dtTempDel = new DataTable();
		public static DataTable dtExistsBom = new DataTable();
		readonly clsCommonUse commUse = new clsCommonUse();
		readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
		string strFileImag = "";
		readonly string strImgPath = AppDomain.CurrentDomain.BaseDirectory;

		public frmBom()
		{
			InitializeComponent();
			NextControl oNext = new NextControl(this, "2");
			oNext.EnterToTab();
		}

		private void frmBom_Load(object sender, EventArgs e)
		{            
			//TreeView1.HideSelection = false ;             
			TreeNode TopNode = new TreeNode() { Text = "物料清單", Tag = "" };
			TreeView1.Nodes.Add(TopNode);

			DataTable dtDept = clsPublicOfCF01.GetDataTable(@"SELECT dep_id,(dep_id +'[' + dep_cdesc+']') AS dep_cdesc FROM dbo.bs_dep with(nolock) WHERE dep_group='DG'");
			DataRow dr1 = dtDept.NewRow(); //插一空行
			dr1["dep_id"] = "";
			dtDept.Rows.InsertAt(dr1, 0);
			txtDetp_id.Properties.DataSource = dtDept;
			txtDetp_id.Properties.ValueMember = "dep_id";
			txtDetp_id.Properties.DisplayMember = "dep_cdesc";            

			//生成BOM明細結構            
			const string sql_bom = @"SELECT A.id,A.exp_id,A.sequence_id,A.log_no,A.goods_id,goods_bom,A.unit_code,A.dosage,A.base_qty,A.remark,B.item_cdesc AS name
			FROM dbo.bs_bom A With(nolock) 
			INNER JOIN dbo.bs_mat_master B With(nolock) ON A.goods_id = B.prd_item 	
			WHERE 1=0";
			dtBOMDetail = clsPublicOfCF01.GetDataTable(sql_bom);
			gridControl1.DataSource = dtBOMDetail;

			//生成臨時項目刪除表結構
			dtTempDel = dtBOMDetail.Clone();

			//gridview1單位下拉列表框
			dtUnit = clsPublicOfCF01.GetDataTable("Select unit_id,unit_cdesc From dbo.bs_unit ");
			col_unit_code.DataSource = dtUnit;
			col_unit_code.ValueMember = "unit_id";
			col_unit_code.DisplayMember = "unit_id";
			col_unit_code.ShowHeader = false;
			col_unit_code.TextEditStyle = TextEditStyles.Standard;

		}

		private void frmBom_FormClosed(object sender, FormClosedEventArgs e)
		{
			dtBOMDetail.Dispose();
			dtExistsBom.Dispose();
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

		private void BTNITEMADD_Click(object sender, EventArgs e)
		{
			AddNew_Item();
		}

		private void BTNITEMDEL_Click(object sender, EventArgs e)
		{
			Del_Item();
		}
	  
		private void BTNDELETE_Click(object sender, EventArgs e)
		{
			if (BTNSAVE.Enabled || txtID.Text == "")
			{
				return;
			}
			string bom_id = txtID.Text;
			string sql_d1 = @"UPDATE dbo.bs_bom_mostly set within_code =@within_code WHERE within_code ='0000' AND id  =@bom_id";
			string sql_d2 = @"UPDATE dbo.bs_bom set within_code =@within_code WHERE within_code ='0000' AND id = @bom_id";
			if (txtState.Text == "已批準")
			{
				MessageBox.Show("已批準狀態,不可以刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string sql_exists_bom = String.Format("SELECT id,goods_id FROM dbo.bs_bom WHERE within_code='{0}' and goods_bom ='{1}'",temp_comp,bom_id);
			dtExistsBom = clsPublicOfCF01.GetDataTable(sql_exists_bom);
			if (dtExistsBom.Rows.Count > 0)
			{
				MessageBox.Show("存在其它BOM已引用此BOM資料,不可以刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				frmBomDeleteCheck frm = new frmBomDeleteCheck();
				frm.ShowDialog();                
				frm.Dispose();
				return;
			}
			DialogResult result = MessageBox.Show("確認要刪除此BOM資料,請謹慎操作!", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_d1;//刪除主檔
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@within_code", "ZZZZ");
						myCommand.Parameters.AddWithValue("@bom_id", bom_id);                        
						myCommand.ExecuteNonQuery();
						myCommand.CommandText = sql_d2; //刪除明細                       
						myCommand.ExecuteNonQuery();
						myTrans.Commit(); //數據提交                        
						MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);                                            
					}
					catch (Exception E)
					{
						myTrans.Rollback(); //數據回滾
						throw new Exception(E.Message);
					}
					finally
					{
						myCon.Close();
                        myCon.Dispose();
                        myTrans.Dispose();
					}
				}
			}
		}

		private void BTNSAVE_Click(object sender, EventArgs e)
		{
			txtRemark.Focus();//Toolscript焦點問題
			Save();
		}

		private void BTNCANCEL_Click(object sender, EventArgs e)
		{
			SetButtonSatus(true);
			SetObjValue.SetEditBackColor(Controls, false);
			SetObjValue.ClearObjValue(Controls, "2");
			Set_Grid_Status(false);            
			mState = "";
			if (!String.IsNullOrEmpty(mID))
			{
				Find_doc(mID);
			}
		}

		private void BTNAPPROVE_Click(object sender, EventArgs e)  //批準與反審批
		{           
			if (BTNAPPROVE.Tag.ToString() == "0")
			{
			   ApproveState("1", txtID.Text); //批準                
			}
			else           
			{
			   ApproveState("0", txtID.Text);//反批準
			}
		}

		private void BTNFIND_Click(object sender, EventArgs e)
		{
			frmBomFind frmBomFind = new frmBomFind();
			frmBomFind.ShowDialog();
			if (frmBom._query_bom_id != "")
			{
				bool flag = true;
				foreach (TreeNode treeNode in TreeView1.TopNode.Nodes)
				{
					if (treeNode.Tag.ToString() == frmBom._query_bom_id)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					SetTreeView(frmBom._query_bom_id);
					TreeView1.SelectedNode = TreeView1.Nodes[0].LastNode;
				}
			}
			frmBom._query_bom_id = "";
			frmBomFind.Dispose();
		}

		private void txtGoods_id_Leave(object sender, EventArgs e)
		{
			if (!txtGoods_id.Properties.ReadOnly)
			{
				if (txtGoods_id.Text != "" && txtID.Text != "")
				{
					string text = txtID.Text.Trim();
					txtGoods_id.Text = text.Substring(0, 18);
				}
				if (txtGoods_id.Text != "" && txtID.Text == "")
				{
					GetMM(txtGoods_id.Text);
				}
			}
		}

		private void txtGoods_id_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (!txtGoods_id.Properties.ReadOnly)
			{
				if (!(txtID.Text != ""))
				{
					frmMmFind frmMmFind = new frmMmFind("0");//顯示非採購件、非成品
					frmMmFind.ShowDialog();
					if (_MM != "")
					{
						GetMM(_MM);
					}
					_MM = "";
					frmMmFind.Dispose();
				}
			}
		}

		private void col_goods_id_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if (gridView1.OptionsBehavior.Editable)
			{
				frmMmFind frmMmFind = new frmMmFind("1"); //自制、委外、採購
				frmMmFind.ShowDialog();
				if (frmBom._MM != "")
				{
					if (!Is_Valid_Goods(frmBom._MM))
					{
						return;
					}
					CheckMM(frmBom._MM);
				}
				frmBom._MM = "";
				frmMmFind.Dispose();
			}
		}

		private void col_goods_id_Leave(object sender, EventArgs e)
		{
			if (gridView1.OptionsBehavior.Editable)
			{
				string strGoods_id = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "goods_id");
				if (strGoods_id != "")
				{
					if (Is_Valid_Goods(strGoods_id))
					{
						CheckMM(strGoods_id);
					}
				}
			}
		}

		private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			//設置當前選中節點失去焦點後的顏色
			if (preNode != null)
			{
				preNode.ForeColor = System.Drawing.Color.Black;
			}
			e.Node.ForeColor = System.Drawing.Color.Maroon;
			preNode = e.Node;
			TreeView1.TopNode.ForeColor = System.Drawing.Color.Black;
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (mState == "")
			{
				string bom_id = e.Node.Tag.ToString().Trim();
				if (!string.IsNullOrEmpty(bom_id))
				{
					txtID.Text = bom_id;
					Find_doc(bom_id);
				}
			}
		}

		//===============以下爲自定義方法======================  
		private void Edit()
		{
			if (!(txtID.Text == ""))
			{
				if (BTNAPPROVE.Tag.ToString() == "1")
				{
					MessageBox.Show("已批準狀態,不可以編輯!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					SetButtonSatus(false);
					SetObjValue.SetEditBackColor(base.Controls, true);
					Set_Grid_Status(true);
					mState = "EDIT";
					txtID.Properties.ReadOnly = true;
					txtID.BackColor = System.Drawing.Color.White;
				}
			}
		}

		private void AddNew_Item()
		{
			if (Valid_Data_H())
			{
				Set_Grid_Status(true);
				gridView1.AddNewRow();
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "exp_id", txtExp_id.Text);
				gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sequence_id", "*");                
				Set_gridView_Focus();
			}
		}

		private void Del_Item()
		{
			if (gridView1.RowCount != 0)
			{
				DialogResult dialogResult = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					int row = gridView1.FocusedRowHandle;
					DataRow dr = dtTempDel.NewRow();
					dr["id"] = txtID.Text;
					dr["exp_id"] = gridView1.GetRowCellDisplayText(row, "exp_id");
					dr["sequence_id"] = gridView1.GetRowCellDisplayText(row, "sequence_id");
					dr["log_no"] = gridView1.GetRowCellDisplayText(row, "log_no");
					dr["goods_id"] = gridView1.GetRowCellDisplayText(row, "goods_id");
					dtTempDel.Rows.Add(dr);
					gridView1.DeleteRow(row);
				}
			}
		}

		private void GetMM(string _Prd_item)
		{
			SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@prd_item", _Prd_item)
			};
			dtMM = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_bom_query_mm", paras);
			if (dtMM.Rows.Count > 0)
			{
				if (CheckBomCurrentVer(_Prd_item))
				{
					DialogResult Result = MessageBox.Show("此貨品BOM已經存在,是否要做新版本的BOM ?", "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (Result == DialogResult.Yes)
					{
						//檢查是否有做BOM新版本的權限                       
						DataTable dtNewVer = clsPublicOfCF01.GetDataTable(string.Format(@"SELECT '1' FROM dbo.user_func WHERE userid='{0}' AND func='{1}'", DBUtility._user_id, "BOMVER"));
						if (dtNewVer.Rows.Count > 0)
						{
							using (frmPass frm = new frmPass())
							{
								if (frm.ShowDialog() == DialogResult.OK)
								{
									string strVer = (Convert.ToInt32(_ver) + 1).ToString("000");
									txtID.Text = _Prd_item + strVer;
									txtExp_id.Text = strVer;
									Set_New_Data_H(_Prd_item);
									dtBOMDetail.Clear();                               
								}
								else
								{
								   return;
								}
							}
						}
						else
						{
							MessageBox.Show("你沒有做BOM新版本的權限!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}                    
				}
				else
				{
					txtID.Text = _Prd_item + "001";
					txtExp_id.Text = "001";                    
					Set_New_Data_H(_Prd_item);                    
				}                
			}
			else
			{
				MessageBox.Show("此貨品編號不存在!", myMsg.msgTitle,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				txtGoods_id.Focus();
				SetEmpty();
			}
		}

		private void Set_New_Data_H(string _goods_id) //新增時設置主表資料
		{
			txtGoods_id.Text = _goods_id;
			txtName.Text = dtMM.Rows[0]["name"].ToString();
			txtDo_color.Text = dtMM.Rows[0]["do_color"].ToString();
			txtUnit_code.Text = dtMM.Rows[0]["unit_code"].ToString();
			txtDetp_id.EditValue = dtMM.Rows[0]["dept_id"].ToString();
			txtPlate_effect.Text = dtMM.Rows[0]["plate_effect"].ToString();
			txtColor_effect.Text = dtMM.Rows[0]["color_effect"].ToString();
			SetBomApproveSate("0");
			string image_path = dtMM.Rows[0]["item_img"].ToString().Trim();
			if (File.Exists(image_path))
			{
				picArt_code.Image = Image.FromFile(image_path);
			}
		}

		private static bool CheckBomCurrentVer(string goods_id) //檢查BOM的版本
		{
			DataTable dtBomVer = clsPublicOfCF01.GetDataTable(string.Format(@"SELECT id,MAX(exp_id) AS ver 
																		FROM dbo.bs_bom_mostly 
																		WHERE within_code='{0}' AND goods_id='{1}' 
																		GROUP BY id", "0000", goods_id));            
			bool result = false;
			if (dtBomVer.Rows.Count == 0)
			{
				_ver = "";                
			}
			else
			{
				if (dtBomVer.Rows[0]["id"].ToString() != "")
				{
					result = true;
					_ver = dtBomVer.Rows[0]["ver"].ToString();
				}
				else
				{                    
					_ver = "";
				}               
			}
			return result;
		} 

		private void AddNew() //新增
		{
			mState = "NEW";
			txtGoods_id.Focus();
			SetButtonSatus(false);
			SetObjValue.SetEditBackColor(Controls, true);
			SetObjValue.ClearObjValue(Controls, "2");//1 清空主檔，2全部            
			txtExp_id.Text = "001";
			//DataRow dr = dtArt_request.NewRow(); //插一空行
			//dtArt_request.Rows.InsertAt(dr, 0);
			dtBOMDetail.Clear();
			gridControl1.DataSource = dtBOMDetail;
		}

		private void SetButtonSatus(bool _flag) //設置工具欄
		{
			BTNNEW.Enabled = _flag;
			BTNEDIT.Enabled = _flag;
			BTNPRINT.Enabled = _flag;
			BTNDELETE.Enabled = _flag;
			BTNFIND.Enabled = _flag;
			BTNAPPROVE.Enabled = _flag;
			BTNSAVE.Enabled = !_flag;
			BTNCANCEL.Enabled = !_flag;
			BTNITEMADD.Enabled = !_flag;
			BTNITEMDEL.Enabled = !_flag;
			BTNCOPY.Enabled = !_flag;            
		}

		private void Set_Grid_Status(bool _flag) //表格可編號否
		{
			//false--不可編輯;true--可以編輯
			gridView1.OptionsBehavior.Editable = _flag;
		}

		private void SetTreeView(string parent_id) //設置樹形控件
		{
			TreeView1.BeginUpdate();
			SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@within_code", temp_comp),
				new SqlParameter("@Pid", parent_id)
			};
			dtTree_Data = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_bom_structure", paras);
			TreeNode treeNode;
			foreach (DataRow dataRow in dtTree_Data.Select(string.Format("parent_id='{0}'", "")))
			{                
				treeNode = new TreeNode();
				treeNode.Text = string.Format("{0} [{1}]", dataRow["goods_id"], dataRow["name"]);
				treeNode.Tag = dataRow["id"].ToString();
				TreeView1.TopNode.Nodes.Add(treeNode);
				AddChildNode(treeNode, treeNode.Tag.ToString());
			}
			TreeView1.ExpandAll();
			TreeView1.EndUpdate();
		}

		public void AddChildNode(TreeNode subNode, string sub_id)
		{
			DataRow[] dataRowArray = dtTree_Data.Select(string.Format("parent_id >'' AND parent_id='{0}'", sub_id));
			if (dataRowArray.Length == 0)
			{
				subNode.ImageIndex = subNode.SelectedImageIndex = 1;
			}
			else
			{
				TreeNode Node;
				foreach (DataRow dataRow in dataRowArray)
				{                   
					Node = new TreeNode();
					Node.Text = string.Format("{0}{1}", dataRow["goods_id"], "");
					Node.Tag = (object)dataRow["id"].ToString();
					subNode.Nodes.Add(Node);
					AddChildNode(Node, dataRow["id"].ToString()); //遞規調用
				}
			}
		}

		private void CheckMM(string _good_id) //檢查添加的下層物料的有效性
		{
			int curr_row = gridView1.FocusedRowHandle;
			string sql_mm = string.Format(@"SELECT A.prd_item AS goods_id,A.item_cdesc AS name,A.item_unit AS unit_code,A.modality
											   FROM dbo.bs_mat_master A With(nolock) where prd_item ='{0}'", _good_id);
			dtMM = clsPublicOfCF01.GetDataTable(sql_mm);
			if (dtMM.Rows.Count > 0)
			{
				gridView1.SetRowCellValue(curr_row, "goods_id", dtMM.Rows[0]["goods_id"].ToString());
				gridView1.SetRowCellValue(curr_row, "name", dtMM.Rows[0]["name"].ToString());
				gridView1.SetRowCellValue(curr_row, "unit_code", dtMM.Rows[0]["unit_code"].ToString());
				if (dtMM.Rows[0]["modality"].ToString() != "2") //非採購件
				{
					string sql_bom_ver = string.Format(@"SELECT MAX(id) AS goods_bom
														FROM dbo.bs_bom_mostly With(nolock) 
														WHERE goods_id ='{0}' GROUP BY goods_id",
														_good_id);
					DataTable dataTable = new DataTable();
					dataTable = clsPublicOfCF01.GetDataTable(sql_bom_ver);
					if (dataTable.Rows.Count > 0)
					{
						string text = dtMM.Rows[0]["goods_id"].ToString();
						if (text.Substring(0, 2) != "ML") //非原材料帶出下層BOM ID
						{
							gridView1.SetRowCellValue(curr_row, "goods_bom", dataTable.Rows[0]["goods_bom"].ToString());
						}
						else
						{
							gridView1.SetRowCellValue(curr_row, "goods_bom", null); //原材(ML開頭)料沒有下層BOM                            
						}
					}
					else
					{
						gridView1.SetRowCellValue(curr_row, "goods_bom", null); //未建立下層BOM
						MessageBox.Show("注意:此貨品編號還沒有BOM!\n\n" + string.Format("【{0}】", _good_id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					gridView1.SetRowCellValue(curr_row, "goods_bom", null);//採購件
				}

				if (!string.IsNullOrEmpty(gridView1.GetRowCellValue(curr_row, "goods_bom").ToString()))
				{
					//檢查子層物料是否存在無限循環
					if (Check_Bom_Loop(txtID.Text, gridView1.GetRowCellValue(curr_row, "goods_bom").ToString())) 
					{
						gridView1.SetRowCellValue(curr_row, "goods_id", null);
						gridView1.SetRowCellValue(curr_row, "name", null);
						gridView1.SetRowCellValue(curr_row, "unit_code", null);
						gridView1.SetRowCellValue(curr_row, "goods_bom", null);
						Set_gridView_Focus();
					}
				}
			}
			else
			{
				MessageBox.Show("此貨品編號不存在!\n\n" + string.Format("【{0}】", _good_id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				gridView1.SetRowCellValue(curr_row, "goods_id", null);
				gridView1.SetRowCellValue(curr_row, "name", null);
				gridView1.SetRowCellValue(curr_row, "unit_code", null);
				gridView1.SetRowCellValue(curr_row, "goods_bom", null);
				Set_gridView_Focus();
			}
		}

		private void Set_gridView_Focus()  //項目新增時設置表格當前焦點
		{
			ColumnView columnView = gridView1;
			columnView.FocusedColumn = columnView.Columns["goods_id"];
			columnView.Focus();            
		} 

		private bool Check_Bom_Loop(string prent_id, string sub_id) //檢查父、子層結構上是否有死循環
		{
			SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@within_code", temp_comp),
				new SqlParameter("@parent_id", prent_id),
				new SqlParameter("@sub_id", sub_id)
			};
			using (DataTable dtBomLoop = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_bom_loop", paras))
			{
				bool result = false;
				if (dtBomLoop.Rows.Count > 0)
				{
					MessageBox.Show("此貨品編號存在死循環,請返回檢查!\n\n" + string.Format("【{0}】", sub_id.Substring(0, 18)), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					result = true;
				}
				return result;
			}
		}     
	 
		private void Save()//保存新增,編輯或刪除的資料
		{            
			if(!Valid_Data_H())
			{
				return;
			}
			if (!Valid_Data_D())//檢查明細資料的有效性
			{
				return;
			}

			if (IsRepeat()) //檢查明細是否有重覆物料
			{
				return;
			}            
			save_flag = false;
			#region  保存新增
			if (mState == "NEW")
			{
				if (Valid_Doc(txtID.Text,txtExp_id.Text)) //檢查主鍵是否存在
				{
					return;
				}
				string bom_ver = txtExp_id.Text;
				const string sql_i =
					@"INSERT dbo.bs_bom_mostly(within_code,id,exp_id,goods_id,type,dept_id,gen_bom_id,unit_code,remark,state,create_by,create_date) 
					  VALUES(@within_code,@id,@exp_id,@goods_id,@type,@dept_id,@gen_bom_id,@unit_code,@remark,@state,@create_by,getdate())";
				
				SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_i;
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@within_code", temp_comp);
						myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
						myCommand.Parameters.AddWithValue("@exp_id", bom_ver); //版本
						myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.Text);
						myCommand.Parameters.AddWithValue("@type", "0001"); //非F0
						myCommand.Parameters.AddWithValue("@dept_id", txtDetp_id.EditValue);
						myCommand.Parameters.AddWithValue("@gen_bom_id", txtGen_bom_id.Text);
						myCommand.Parameters.AddWithValue("@unit_code", txtUnit_code.Text);
						myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
						myCommand.Parameters.AddWithValue("@state", "0");
						myCommand.Parameters.AddWithValue("@create_by", DBUtility._user_id);                       
						myCommand.ExecuteNonQuery();

						//保存明細
						if (gridView1.RowCount > 0)
						{
							const string sql_item_i =
								@"INSERT INTO dbo.bs_bom(within_code,id,exp_id,sequence_id,log_no,goods_id,goods_type,unit_code,dosage,base_qty,remark,goods_bom)
								VALUES(@within_code,@id,@exp_id,@sequence_id,@log_no,@goods_id,@goods_type,@dosage,@base_qty,@unit_code,@goods_bom,@remark)";
							string strSeq_id = "";
							for (int i = 0; i < dtBOMDetail.Rows.Count; i++)
							{                                
								myCommand.CommandText = sql_item_i;
								myCommand.Parameters.Clear();
								myCommand.Parameters.AddWithValue("@within_code", temp_comp);
								myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
								myCommand.Parameters.AddWithValue("@exp_id", bom_ver);
								myCommand.Parameters.AddWithValue("@sequence_id", "*");
								strSeq_id = Get_Details_Seq(temp_comp, txtID.Text.Trim(), bom_ver); //新增狀態重新取最大序號;
								myCommand.Parameters.AddWithValue("@log_no", strSeq_id);
								myCommand.Parameters.AddWithValue("@goods_id", dtBOMDetail.Rows[i]["goods_id"].ToString());
								myCommand.Parameters.AddWithValue("@goods_type", "0001");
								myCommand.Parameters.AddWithValue("@dosage", dtBOMDetail.Rows[i]["dosage"]);
								myCommand.Parameters.AddWithValue("@base_qty", dtBOMDetail.Rows[i]["base_qty"]);
								myCommand.Parameters.AddWithValue("@unit_code", dtBOMDetail.Rows[i]["unit_code"].ToString());
								myCommand.Parameters.AddWithValue("@goods_bom", dtBOMDetail.Rows[i]["goods_bom"].ToString());
								myCommand.Parameters.AddWithValue("@remark", dtBOMDetail.Rows[i]["remark"].ToString());
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
                        myCon.Dispose();
                        myTrans.Dispose();
					}
				}
			}
			#endregion

			#region 保存編輯
			if (mState == "EDIT")
			{
				string rowStatus = "";
				string strSeq_id = "";
				string bom_ver = txtExp_id.Text;
				const string sql_update = 
					@"UPDATE dbo.bs_bom_mostly 
					  SET exp_id=@exp_id,goods_id=@goods_id,type=@type,dept_id=@dept_id,gen_bom_id=@gen_bom_id,unit_code=@unit_code,
						  remark=@remark,state=@state,update_by=@update_by,update_date=getdate() 
					  WHERE within_code=@within_code AND id=@id AND exp_id=@exp_id";
				SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
				myCon.Open();
				SqlTransaction myTrans = myCon.BeginTransaction();
				using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
				{
					try
					{
						myCommand.CommandText = sql_update;
						myCommand.Parameters.Clear();
						myCommand.Parameters.AddWithValue("@within_code", temp_comp);
						myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
						myCommand.Parameters.AddWithValue("@exp_id", txtExp_id.Text);
						myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.Text.Trim());
						myCommand.Parameters.AddWithValue("@type", "0001");
						myCommand.Parameters.AddWithValue("@dept_id", txtDetp_id.EditValue);
						myCommand.Parameters.AddWithValue("@gen_bom_id", txtGen_bom_id.Text);
						myCommand.Parameters.AddWithValue("@unit_code", txtUnit_code.Text);
						myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
						myCommand.Parameters.AddWithValue("@update_by", DBUtility._user_id);
						myCommand.Parameters.AddWithValue("@state", "0");                        
						myCommand.ExecuteNonQuery();

						//刪除明細資料
						const string sql_item_d =
							   @"DELETE FROM dbo.bs_bom 
								  WHERE within_code=@within_code AND id=@id AND exp_id=@bom_ver AND sequence_id=@sequence_id AND log_no=@log_no AND goods_id=@goods_id";
						for (int i = 0; i < dtTempDel.Rows.Count; i++)
						{                           
							myCommand.CommandText = sql_item_d;
							myCommand.Parameters.Clear();
							myCommand.Parameters.AddWithValue("@within_code", temp_comp);
							myCommand.Parameters.AddWithValue("@id", dtTempDel.Rows[i]["id"].ToString());
							myCommand.Parameters.AddWithValue("@bom_ver", dtTempDel.Rows[i]["exp_id"].ToString());
							myCommand.Parameters.AddWithValue("@sequence_id", dtTempDel.Rows[i]["sequence_id"].ToString());
							myCommand.Parameters.AddWithValue("@log_no", dtTempDel.Rows[i]["log_no"].ToString());
							myCommand.Parameters.AddWithValue("@goods_id", dtTempDel.Rows[i]["goods_id"].ToString());
							myCommand.ExecuteNonQuery();
						}

						//保存明細資料
						if (gridView1.RowCount > 0)
						{
							const string sql_item_i =                                
								@"INSERT INTO dbo.bs_bom(within_code,id,exp_id,sequence_id,log_no,goods_id,goods_type,dosage,base_qty,unit_code,goods_bom,remark)
									  VALUES(@within_code,@id,@exp_id,@sequence_id,@log_no,@goods_id,@goods_type,@dosage,@base_qty,@unit_code,@goods_bom,@remark)";
							const string sql_item_u =
								@"UPDATE dbo.bs_bom SET goods_id=@goods_id,goods_type=@goods_type,unit_code=@unit_code,dosage=@dosage,base_qty=@base_qty,
									  goods_bom=@goods_bom,remark=@remark 
								  WHERE within_code=@within_code AND id=@id AND exp_id=@exp_id AND sequence_id=@sequence_id AND log_no=@log_no";
							for (int i = 0; i < dtBOMDetail.Rows.Count; i++)
							{
								rowStatus = dtBOMDetail.Rows[i].RowState.ToString();
								if (rowStatus == "Added" || rowStatus == "Modified")
								{
									if (rowStatus == "Added")
									{
										myCommand.CommandText = sql_item_i;
										strSeq_id = Get_Details_Seq(temp_comp,txtID.Text.Trim(),bom_ver); //新增狀態重新取最大序號
									}
									if (rowStatus == "Modified")
									{
										myCommand.CommandText = sql_item_u;
										strSeq_id = dtBOMDetail.Rows[i]["log_no"].ToString();//編輯狀態原序號保持不變
									}
									myCommand.Parameters.Clear();
									myCommand.Parameters.AddWithValue("@within_code", temp_comp);
									myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
									myCommand.Parameters.AddWithValue("@exp_id", bom_ver);
									myCommand.Parameters.AddWithValue("@sequence_id", "*");
									myCommand.Parameters.AddWithValue("@log_no", strSeq_id);
									myCommand.Parameters.AddWithValue("@goods_id", dtBOMDetail.Rows[i]["goods_id"].ToString());
									myCommand.Parameters.AddWithValue("@goods_type", "0001");
									myCommand.Parameters.AddWithValue("@unit_code", dtBOMDetail.Rows[i]["unit_code"].ToString());                                    
									myCommand.Parameters.AddWithValue("@dosage", dtBOMDetail.Rows[i]["dosage"]);
									myCommand.Parameters.AddWithValue("@base_qty", dtBOMDetail.Rows[i]["base_qty"]);
									myCommand.Parameters.AddWithValue("@goods_bom", dtBOMDetail.Rows[i]["goods_bom"].ToString());
									myCommand.Parameters.AddWithValue("@remark", dtBOMDetail.Rows[i]["remark"].ToString());
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
                        myCon.Dispose();
                        myTrans.Dispose();
					}
				}
			}
			#endregion

			SetButtonSatus(true);
			SetObjValue.SetEditBackColor(this.Controls, false);
			Set_Grid_Status(false);
			mState = "";           
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

		private void Find_doc(string strBom_id)
		{
			DataSet dataSet = commUse.getDataSet("usp_bom_query", new object[]
			{
				temp_comp,
				strBom_id
			});
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				txtID.Text = dataSet.Tables[0].Rows[0]["id"].ToString();
				txtExp_id.Text = dataSet.Tables[0].Rows[0]["exp_id"].ToString();
				txtGoods_id.Text = dataSet.Tables[0].Rows[0]["goods_id"].ToString();
				txtName.Text = dataSet.Tables[0].Rows[0]["name"].ToString();
				txtDo_color.Text = dataSet.Tables[0].Rows[0]["do_color"].ToString();
				txtUnit_code.Text = dataSet.Tables[0].Rows[0]["unit_code"].ToString();
				txtDetp_id.EditValue = dataSet.Tables[0].Rows[0]["dept_id"].ToString();
				txtGen_bom_id.Text = dataSet.Tables[0].Rows[0]["gen_bom_id"].ToString();
				txtPlate_effect.Text = dataSet.Tables[0].Rows[0]["plate_effect"].ToString();
				txtColor_effect.Text = dataSet.Tables[0].Rows[0]["color_effect"].ToString();
				txtRemark.Text = dataSet.Tables[0].Rows[0]["remark"].ToString();
				txtCrusr.Text = dataSet.Tables[0].Rows[0]["create_by"].ToString();
				txtCrtim.Text = dataSet.Tables[0].Rows[0]["create_date"].ToString();
				txtAmusr.Text = dataSet.Tables[0].Rows[0]["update_by"].ToString();
				txtAmtim.Text = dataSet.Tables[0].Rows[0]["update_date"].ToString();
				txtCheck_by.Text = dataSet.Tables[0].Rows[0]["check_by"].ToString();
				txtCheck_dat.Text = dataSet.Tables[0].Rows[0]["check_date"].ToString();
				SetBomApproveSate(dataSet.Tables[0].Rows[0]["state"].ToString());
				string image_path = dataSet.Tables[0].Rows[0]["item_img"].ToString().Trim();
				if (File.Exists(image_path))
				{
					picArt_code.Image = Image.FromFile(image_path);
				}
				dtBOMDetail = dataSet.Tables[1];
				gridControl1.DataSource = dtBOMDetail;
				mID = strBom_id;
				mVer = txtExp_id.Text;
			}
			else
			{
				SetEmpty();
			}
		}

		private void ApproveState(string _state, string _bom_id) //批準或反批準
		{
			if (BTNSAVE.Enabled || !(txtID.Text != ""))
			{
				return;
			}
			string str1 = @"Update dbo.bs_bom_mostly Set state=@state,check_by=@user_id,check_date=getdate() 
							Where within_code=@within_code And id=@bom_id";
			string str2 = @"Update dbo.bs_bom_mostly Set state=@state,check_by=NULL,check_date=NULL,update_by=@user_id,update_date=getdate() 
						  Where within_code=@within_code And id=@bom_id";

			SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@state", _state),
				new SqlParameter("@user_id", DBUtility._user_id),
				new SqlParameter("@within_code", temp_comp),
				new SqlParameter("@bom_id", _bom_id),
			};
			string strSql;
			if (_state == "0")
			{
				strSql = str2;                
			}
			else
			{
				strSql = str1;                
			}
			int num = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
			if (num > 0)
			{
				SetBomApproveSate(_state);
			}
		} 

		private void SetBomApproveSate(string _state)
		{
			strFileImag = "";
			if (_state == "1")
			{
				txtState.Text = "已批準";
				BTNAPPROVE.Text = "反批準(&Y)";
				BTNAPPROVE.Tag = "1";
				strFileImag = strImgPath + "Images\\p_unok.png";
				if (File.Exists(strFileImag))
				{
					BTNAPPROVE.Image = Image.FromFile(strFileImag);
				}
			}
			else
			{
				txtState.Text = "未批準";
				BTNAPPROVE.Text = "批準(&Y)";
				BTNAPPROVE.Tag = "0";
				strFileImag = strImgPath + "Images\\p_ok.png";
				if (File.Exists(strFileImag))
				{
					BTNAPPROVE.Image = Image.FromFile(strFileImag);
				}
			}
		}

		private void SetEmpty()
		{
			txtID.Text = "";
			txtExp_id.Text = "";
			txtGoods_id.Text = "";
			txtName.Text = "";
			txtDo_color.Text = "";
			txtUnit_code.Text = "";
			txtDetp_id.EditValue = "";
			txtGen_bom_id.Text = "";
			txtPlate_effect.Text = "";
			txtColor_effect.Text = "";
			txtRemark.Text = "";
			txtCrusr.Text = "";
			txtCrtim.Text = "";
			txtAmusr.Text = "";
			txtAmtim.Text = "";
			txtCheck_by.Text = "";
			txtCheck_dat.Text = "";
			txtState.Text = "";
			picArt_code.Image = null;
			dtBOMDetail.Clear();
			mID = "";
			mVer = "";
		}

		private bool Valid_Doc(string _bom_id,string _bom_ver) //主建是否已存在
		{
			bool flag;           
			string strSql = String.Format("Select '1' FROM dbo.bs_bom_mostly WHERE within_code='{0}' And id='{1}' And exp_id='{2}'", temp_comp, _bom_id, _bom_ver);
			DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
			if (dt.Rows.Count > 0)
			{
				MessageBox.Show(myMsg.msgIsExists + String.Format("【{0}】", _bom_id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				flag = true;
			}
			else
			{
				flag = false;
			}
			dt.Dispose();
			return flag;
		}

		private bool Valid_Data_H() //保存前檢查主表的合法性
		{
			bool result = true;
			if (txtID.Text == "")
			{
				MessageBox.Show("貨品編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtGoods_id.Focus();
				result = false;
			}
			if (txtDetp_id.Text == "")
			{
				MessageBox.Show("部門編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtDetp_id.Focus();
				result = false;
			}
			return result;
		}

		private bool Valid_Data_D() //保存前檢查明細資料的合法性
		{
			bool result = true;
			if (gridView1.RowCount > 0)
			{
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					int rowHandle = gridView1.GetRowHandle(i);
					string rowno = (rowHandle + 1).ToString();
					string strDosage = gridView1.GetRowCellDisplayText(rowHandle, "dosage");
					string strBase_qty = gridView1.GetRowCellDisplayText(rowHandle, "base_qty");
					if (string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(rowHandle, "goods_id")) ||
											strDosage == "0.000" || strBase_qty == "0" || 
											string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(rowHandle, "unit_code")))
					{
						result = false;
						MessageBox.Show("貨品編號、用量、基數或單位不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						ColumnView columnView = gridView1;
						columnView.FocusedColumn = columnView.Columns["dosage"];
						break;
					}
					string strGoods_id = gridView1.GetRowCellDisplayText(rowHandle, "goods_id");
					if (!Is_Valid_Goods(strGoods_id))
					{
						result = false;
						break;
					}
					if (!string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(rowHandle, "goods_bom")))
					{
						string strGoods_bom = gridView1.GetRowCellDisplayText(rowHandle, "goods_bom");
						if (strGoods_bom.Length != 21)
						{
							MessageBox.Show(string.Format("無效的子層BOM ID,長度有問題(21位),請返回檢查!\n\n No.{0}  [{1}]", rowno, strGoods_bom), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							result = false;
							break;
						}
						if (txtID.Text == strGoods_bom)
						{
							MessageBox.Show(string.Format("發現死循環,請返回檢查!\n\n No.{0}  [{1}]", rowno, strGoods_bom), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							result = false;
							break;
						}
						if (strGoods_id != strGoods_bom.Substring(0, 18))
						{
							MessageBox.Show(string.Format("子層BOM ID與貨品編號不相符,請返回檢查!\n\n No.{0}  [{1}]", rowno, strGoods_bom), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							result = false;
							break;
						}
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		private bool IsRepeat() //明細資料不允許有重覆
		{
			if (gridView1.RowCount < 2)
			{               
				return false ;
			}
			bool result = false;
			string strGoods_id = "";            
			for (int i = 0; i < gridView1.RowCount - 1; i++)
			{
				strGoods_id = gridView1.GetRowCellDisplayText(i, "goods_id");                    
				for (int j = i + 1; j <= gridView1.RowCount - 1; j++)
				{                    
					if (strGoods_id == gridView1.GetRowCellDisplayText(j, "goods_id"))
					{
						MessageBox.Show("子層物料不允許有重覆!\n\n" + string.Format("【{0}】", strGoods_id), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                       
						result = true;
						break;
					}
				}
			}
			return result;
		}

		private bool Is_Valid_Goods(string _goods) //父層,子層不可以是相同物料
		{
			bool flag = true;
			if (txtGoods_id.Text == _goods)
			{
				MessageBox.Show("父層、子層不可以存在相同的貨品!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				flag = false;
			}
			return flag;
		}
		
		private static string Get_Details_Seq(string _comp, string _id, string _ver) //取明細的序號
		{
			DataTable dtMaxseq = new DataTable();
			dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format(@"SELECT MAX(log_no) as log_no 
															  FROM dbo.bs_bom with(nolock) 
															  WHERE within_code='{0}' AND id='{1}' AND exp_id='{2}'", _comp, _id, _ver));
			string strSeq; 
			if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["log_no"].ToString()))
			{
				strSeq = "0001";
			}
			else
			{
				strSeq = dtMaxseq.Rows[0]["log_no"].ToString();
				strSeq = strSeq.Substring(0, 4);
				strSeq = (Convert.ToInt32(strSeq) + 1).ToString("0000");
			}
			dtMaxseq.Dispose();
			return strSeq;
		}

		private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) //明細資料編輯時背景色 
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

		private void col_dosage_Click(object sender, EventArgs e)
		{
			ColumnView clv = gridView1;
			clv.FocusedColumn = clv.Columns["dosage"];
			clv.SelectAll();
			clv.Focus(); 
		}

		private void col_base_qty_Click(object sender, EventArgs e)
		{
			ColumnView clv = gridView1;
			clv.FocusedColumn = clv.Columns["base_qty"];
			clv.SelectAll();
			clv.Focus();
		}

	}
}
