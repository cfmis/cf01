using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
	public class clsUser
	{

		/// <summary>
		/// 查找用戶是否存在:非空--存在;空--不存在        
		/// </summary>
		/// <param name="strUserID"></param>
		/// <returns>sqlserver=dgerp2</returns>
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
		public string IsExistUser(string userid)
		{
			string username = "";
			bool flag = true;
			if (userid == "")
			{
				MessageBox.Show("用戶帳號不可為空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				flag = false;
				username = "";
			}

			if (flag) //帳號是否為為空
			{
				string strSql = "Select user_id,user_name From dbo.sys_user Where user_id ='" + userid + "' and typeid ='U'";
				try
				{
					DataTable dtUserInfo = clsConErp.GetDataTable(strSql);

					if (dtUserInfo.Rows.Count > 0)
					{
						string strIsUser = clsPublicOfCF01.ExecuteSqlReturnObject("select Uname from tb_sy_user where Uname='" + userid + "'"); //判斷dgsql2 中是否存在用戶。
						if (strIsUser != "")
						{
							username = dtUserInfo.Rows[0]["user_name"].ToString();
						}
					}
					else
					{
						MessageBox.Show("用戶帳號不正確！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						username = "";
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					username = "";
				}
			}
			else
			{
				username = "";
			}
			userid = username;
			return userid;
		}

		/// <summary>
		/// 登錄    
		/// </summary>
		/// <param name="strUserID">用戶帳號</param>
		/// <param name="strpassword">帳號密碼</param>
		/// <returns>sqlserver=dgerp2</returns>
		public bool GetUserInfo(string userid, string password)
		{
			bool result = false;
			string strSql = "Select user_id,user_name,password From dbo.sys_user Where user_id ='" + userid + "' and typeid ='U'";
			try
			{
				DataTable dtUserInfo = clsConErp.GetDataTable(strSql);

				if (dtUserInfo.Rows.Count > 0)
				{
					if (DBUtility.GeoEncrypt(password) == dtUserInfo.Rows[0]["password"].ToString())
					{
						result = true;
						DataTable dt = clsPublicOfCF01.GetDataTable("select language from dbo.tb_sy_user where uname='" + userid + "'");//2013-08-21更改
						DBUtility._language = dt.Rows[0]["language"].ToString();                                                  //2013-08-21更改
					}
					else
					{
						result = false;
						MessageBox.Show("密碼不正確！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			return result;
		}

		/// <summary>
		///根据用户ID查询用户权限 
		/// </summary>
		/// <param name="UserId"></param>
		/// <param name="UserName"></param>
		/// <returns> sqlserver=dgerp2</returns>
		public DataTable GetUserById(string UserId, string UserName)
		{
			DataTable dt = new DataTable();

			string strSQL = "SELECT user_id AS Uname,user_name AS Uname_desc,password,'' as user_group FROM  sys_user ";
			if (UserId != "")
			{
				strSQL += " WHERE user_id LIKE " + "'%" + UserId + "%'";
			}
			if (UserName != "")
			{
				strSQL += " OR user_id LIKE " + "'%" + UserName + "%'";
			}
			try
			{
				dt = clsConErp.GetDataTable(strSQL);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;
		}

		/// <summary>
		/// 查詢用戶信息
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="UserName"></param>
		/// <returns>dgsql1</returns>
		public DataTable QueryUserInfo(string UserID, string UserName)
		{
			DataTable dt = new DataTable();

			string strSQL = 
            @" SELECT A.Uid,A.Uname,A.Uname_desc,B.Rid,B.Rname,
				(CASE WHEN A.language='0' THEN '繁體中文' 
                WHEN A.language='1' THEN '簡體中文' 
				WHEN A.language='2' THEN 'English' ELSE NULL END) AS Language,user_group 
				FROM dbo.tb_sy_user A left join tb_sy_role B on A.rid = b.rid ";
			if (UserID != "" && UserName != "")
			{
				strSQL += " WHERE A.Uname LIKE " + "'%" + UserID + "%'";
				strSQL += " AND A.Uname_desc LIKE " + "'%" + UserName + "%'";
			}
			if (UserName != "" && UserID == "")
			{
				strSQL += " WHERE A.Uname_desc LIKE " + "'%" + UserName + "%'";
			}
			if (UserName == "" && UserID != "")
			{
				strSQL += " WHERE A.Uname LIKE " + "'%" + UserID + "%'";
			}
			try
			{
				dt = clsPublicOfCF01.GetDataTable(strSQL);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			return dt;

		}

		/// <summary>
		/// 添加新用戶
		/// </summary>
		/// <param name="modelUser"></param>
		/// <returns>dgsql1</returns>
		public int AddUserInfo(mdlUser modelUser)
		{
			int Result = -1;
			try
			{
				string strSQL = @"INSERT INTO tb_sy_user(Uname, Uname_desc, Pwd, Rid, language,user_group) VALUES (@Uname, @Uname_desc, @Pwd, @Rid, @language,@user_group)";

				SqlParameter[] paras = new SqlParameter[] { 
					new SqlParameter("@Uname",modelUser.Uname),
					new SqlParameter("@Uname_desc",modelUser.Uname_Desc),
					new SqlParameter("@Pwd",modelUser.Pwd),
					new SqlParameter("@Rid",modelUser.Role.Rid),
					new SqlParameter("@language",modelUser.Language),
                    new SqlParameter("@user_group",modelUser.user_group)
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
		/// 刪除用戶
		/// </summary>
		/// <param name="uid"></param>
		/// <returns>dgsql1</returns>
		public int DelUserInfo(int uid)
		{
			int Result = -1;
			try
			{
				string strSQL = "DELETE FROM tb_sy_user WHERE Uid=@Uid ";
				SqlParameter[] paras = new SqlParameter[] { 
				   new SqlParameter("@Uid", uid)
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
		/// 編輯用戶
		/// </summary>
		/// <param name="modelUser"></param>
		/// <returns>dgsql1</returns>
		public int UpdateUserInfo(mdlUser modelUser)
		{
			int Result = -1;
			try
			{
                string strSQL = @" UPDATE tb_sy_user SET Rid =@Rid, language=@language,user_group=@user_group WHERE Uid=@Uid AND Uname=@Uname";

				SqlParameter[] paras = new SqlParameter[] { 
					new SqlParameter("@Uid",modelUser.Uid),
					new SqlParameter("@Uname",modelUser.Uname),
					new SqlParameter("@Rid",modelUser.Role.Rid),
					new SqlParameter("@language",modelUser.Language),
                    new SqlParameter("@user_group",modelUser.user_group)
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
		/// 變更用戶語言
		/// </summary>
		/// <param name="pLanguage"></param>
		/// <param name="pUname"></param>
		/// <returns>dgsql1</returns>
		public int UpdateUserLanguage(string pLanguage, string pUname)
		{
			int Result = -1;
			try
			{
				string strSQL = @" Update dbo.tb_sy_user set language =@language  Where uname=@uname ";

				SqlParameter[] paras = new SqlParameter[] { 
					new SqlParameter("@uname",pUname),
					new SqlParameter("@language",pLanguage)
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
		/// 判斷該用戶是否存在
		/// </summary>
		/// <param name="pUname"></param>
		/// <returns>dgsql1</returns>
		public bool IsExistForAdd(string pUname)
		{
			bool IsExist = true;
			try
			{
                string strSql = @"SELECT uname FROM tb_sy_user WHERE Uname='" + pUname + "' ";
				string strUname = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
				if (strUname.Length > 0)
				{
					IsExist = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return IsExist;

		}


	}
}
