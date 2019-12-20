using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
	public class clsRoleManage
	{
		#region 获取角色，及Menu 菜单权限操作
		/// <summary>
		///获取所有角色 
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAllRole()
		{
			DataTable dt = new DataTable();
			try
			{
				string strSQL = @"Select Rid, Rname From dbo.tb_sy_role";
				dt = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;
		}

		public static DataTable QueryRoleByRname(string Rname)
		{
			DataTable dtRole = new DataTable();
			try
			{
				string strSQL = @"SELECT * FROM dbo.tb_sy_role WHERE Rname='" + Rname + "'";
				dtRole = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return dtRole;
		}

		public static int GetMaxRid()
		{
			int Rid = 0;
			DataTable dtRole = new DataTable();
			try
			{
				string strSQL = @"select max(Rid) as Rid from tb_sy_role ";
				dtRole = clsPublicOfCF01.GetDataTable(strSQL);

				if (dtRole.Rows.Count > 0)
				{
					Rid = Convert.ToInt32(dtRole.Rows[0]["Rid"]);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Rid;
		}

		public static int AddRole(string Rname)
		{
			int Result = -1;
			try
			{
				int MaxRid = GetMaxRid();
				string strSQL = "insert into tb_sy_role(Rid,Rname) values(@Rid,@Rname)";

				SqlParameter[] paras = new SqlParameter[] {
				  new SqlParameter("@Rname", Rname),
				  new SqlParameter("@Rid", (MaxRid + 1)) 
				 };

				Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Result;
		}

		public static int UpdateRole(Role model)
		{
			int Result = -1;
			try
			{

				string strSQL = "UPDATE tb_sy_role SET Rname=@Rname WHERE Rid=@Rid";

				SqlParameter[] paras = new SqlParameter[] { 
				 new SqlParameter("@Rname", model.Rname),
				 new SqlParameter("@Rid", model.Rid)
				};

				Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Result;
		}

		/// <summary>
		///查询菜单对应的窗体 
		/// </summary>
		/// <param name="Gid"></param>
		/// <returns></returns>
		public static DataTable GetFormById(int Gid)
		{
			DataTable dt = new DataTable();
			try
			{
				string strSQL = @"SELECT Gid,Gdesc FROM tb_sy_grant WHERE lang=0 AND Pid='" + Gid + "'";
				dt = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;
		}

		public static DataTable GetGrantMenuByRid(bool flag, int Rid)
		{
			DataTable dt = new DataTable();
			try
			{
				string strSQL = "";
				if (flag == true)
				{
					strSQL = @"SELECT A.*,B.Rid FROM tb_sy_grant A left join tb_sy_role_grant B
								   on A.Gid=B.Gid and B.Rid=" + Rid + " WHERE   Lang=0 ";
				}
				else
				{
					strSQL = @"SELECT A.Lang,A.Gid,A.Gdesc,A.Pid,A.Fid,B.Rid,C.FuncName FROM tb_sy_grant A 
								  left join tb_sy_role_grant B on A.Gid=B.Gid and B.Rid=" + Rid + " left join tb_sy_func C on A.Fid=C.Fid WHERE  Lang=" + DBUtility._language + " and B.Rid is not null";
				}

				dt = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;
		}

		public static DataTable GetAllUserPopedom(string UserNo, string frmName)
		{
			DataTable dt = new DataTable();
			try
			{
				string strSQL = @"SELECT USR_NO, Window_id, C1_STATE, C1_ID, C1_TEXT
										   , C2_STATE, C2_ID, C2_TEXT, C3_STATE, C3_ID
										   , C3_TEXT, C4_STATE, C4_ID, C4_TEXT, C5_STATE
										   , C5_ID, C5_TEXT, C6_STATE, C6_ID, C6_TEXT
										   , C7_STATE, C7_ID, C7_TEXT, C8_STATE, C8_ID
										   , C8_TEXT, C9_STATE, C9_ID, C9_TEXT, C10_STATE
										   , C10_ID, C10_TEXT, C11_STATE, C11_ID, C11_TEXT
										   , C12_STATE, C12_ID, C12_TEXT, C13_STATE, C13_ID
										   , C13_TEXT, C14_STATE, C14_ID, C14_TEXT, C15_STATE
										   , C15_ID, C15_TEXT, C16_STATE, C16_ID, C16_TEXT
										   , C17_STATE, C17_ID, C17_TEXT, C18_STATE, C18_ID
										   , C18_TEXT, C19_STATE, C19_ID, C19_TEXT, C20_STATE
										   , C20_ID, C20_TEXT, C0_STATE, control_state, curgroup_state
										   , curdepartment_state, curcompany_state
										FROM tb_sy_user_popedom WHERE USR_NO= '" + UserNo + "'AND Window_id='" + frmName + "'";

				dt = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;
		}

		public static DataTable GetToolStripButtonName(string LanguageId, string FormName)
		{
			DataTable dt = new DataTable();
			try
			{
				string strSQL = @"SELECT * FROM v_dict_group WHERE col_code LIKE '%BTN%' AND language_id='" + LanguageId +
								 "' AND formname='" + FormName + "'ORDER BY tb_col_sort";
				dt = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;
		}

		/// <summary>
		/// 獲取表單控件的信息（最新版數據庫）
		/// </summary>
		/// <param name="pformname"></param>
		/// <param name="planguage"></param>
		/// <returns></returns>
		public static DataTable GetAllControlInfo(string pformname, string planguage)
		{
			DataTable dtControlInfo = new DataTable();
			try
			{
				string strSQL = @" SELECT  a.formname, a.obj_type, a.obj_id, RTRIM(c.show_name) AS show_name, a.col_width
												, a.col_sort, a.col_type, a.col_visible,a.obj_name, b.img_path
												, b.col_field, b.img_path, c.language_id,a.col_readonly
										FROM  dbo.tb_sy_form_object AS a 
										INNER JOIN dbo.tb_sy_dictionary_obj AS b ON a.obj_id = b.obj_id 
										INNER JOIN dbo.tb_sy_dictionary_lang AS c ON a.obj_id = c.obj_id
										WHERE a.formname='" + pformname + "' AND  c.language_id='" + planguage + "'";
				strSQL += " ORDER BY a.col_sort ";

				dtControlInfo = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return dtControlInfo;
		}


		/// <summary>
		/// 根据得到的用户和form 查询 tb_sy_user_popedom 是否存在记录,否则插入值
		/// </summary>
		/// <param name="UserNo"></param>
		/// <param name="FuncDesc"></param>
		/// <returns></returns>
		public static DataTable QueryButton(string UserNo, string FuncName)
		{
			DataTable dt = new DataTable();

			SqlParameter[] paras = new SqlParameter[]{
				new SqlParameter("@UserNo", UserNo),
				new SqlParameter("@FuncName", FuncName)
			};
			dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_UserMenuRole", paras);
			return dt;
		}

		public static int AddRoleGrant(string strRid, DataTable dtRoleGrant)
		{
			int Result = -1;
			try
			{
				string strSQL = "delete tb_sy_role_grant where rid = '" + strRid + "'";
				int DelResult = clsPublicOfCF01.ExecuteNonQuery(strSQL, null, false);

				string SQL = "";
				for (int i = 0; i < dtRoleGrant.Rows.Count; i++)
				{

					SQL += string.Format(@"insert into tb_sy_role_grant(Rid,Gid) values ('{0}','{1}')", strRid, dtRoleGrant.Rows[i]["Gid"].ToString());
				}

				if (SQL != "")
				{
					Result = clsPublicOfCF01.ExecuteNonQuery(SQL, null, false);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return Result;
		}

		public static int InsertUserPopedom(List<mdlUserPopedom> lsUp)
		{
			int Result = -1;
			try
			{
				string strSQL = "";
				for (int i = 0; i < lsUp.Count; i++)
				{
                    strSQL += string.Format(
                     @"UPDATE tb_sy_user_popedom 
                      SET C1_STATE='{0}',C2_STATE='{1}',C3_STATE='{2}',C4_STATE='{3}',C5_STATE='{4}',C6_STATE='{5}',C7_STATE='{6}',C8_STATE='{7}',
                          C9_STATE='{8}',C10_STATE='{9}',C11_STATE='{10}',C12_STATE='{11}',  C13_STATE='{12}',C14_STATE='{13}' 
                      WHERE USR_NO='{14}' AND Window_id='{15}';",
                         lsUp[i].C1_State, lsUp[i].C2_State, lsUp[i].C3_State, lsUp[i].C4_State, lsUp[i].C5_State, lsUp[i].C6_State, lsUp[i].C7_State, lsUp[i].C8_State,
                         lsUp[i].C9_State, lsUp[i].C10_State, lsUp[i].C11_State, lsUp[i].C12_State, lsUp[i].C13_State, lsUp[i].C14_State,
                         lsUp[i].Usr_No, lsUp[i].Window_Id);
				}
				if (strSQL != "")
				{
					Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, null, false);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Result;
		}


		public static DataTable GetFrmControlName(string LanguageId, string frmName)
		{
			DataTable dts = new DataTable();
			try
			{
				string strSQL = @"SELECT a.formname,b.col_code,a.tb_col_width,a.tb_col_sort,a.fl_visible
											 ,b.col_name,b.language_id,b.fieldname,b.show_name,b.remark
											 ,a.source_field,a.columntype
									FROM tb_sy_dict_group a
									LEFT JOIN tb_sy_dictionary b ON a.dict_col_code=b.col_code 
									WHERE b.language_id='" + LanguageId + "' AND a.formname like'%" + frmName + "%'";
				strSQL += " ORDER BY a.tb_col_sort,b.language_id";

				dts = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dts;
		}

		#endregion
	}
}
