using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf01.MDL;
using System.Windows.Forms;

namespace cf01.CLS
{
	public class clsVendor
	{
		/// <summary>
		/// 新增供應商資料
		/// </summary>
		/// <param name="objModel"></param>
		/// <returns></returns>
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        public static int AddVendor(mdlVendor objModel)
		{
			int Result = 0;
			try
			{
				string IsExist = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format(" SELECT vendcode FROM bs_vendor WHERE vendcode='{0}' ", objModel.vendcode));

				if (IsExist == "")
				{
					string strSql = @" INSERT INTO bs_vendor( vendcode,   vendtype,  vendname,  vendcname, vendlname
															 ,vendlcname, vendadd1,  vendadd2,  vendadd3,  vendcadd1
															 ,vendcadd2,  vendcadd3, vendctact, vendcoun,  vendtel
															 ,vendfax,    vendcurr,  vendemail, vendpterm, vendopen
															 ,vendclose,  vendrmk,   crusr,     crtim )
												  VALUES( @vendcode,   @vendtype,  @vendname,  @vendcname, @vendlname
														 ,@vendlcname, @vendadd1,  @vendadd2,  @vendadd3,  @vendcadd1
														 ,@vendcadd2,  @vendcadd3, @vendctact, @vendcoun,  @vendtel
														 ,@vendfax,    @vendcurr,  @vendemail, @vendpterm, @vendopen
														 ,@vendclose,  @vendrmk,   @crusr,     GETDATE() ) ";

					SqlParameter[] paras = new SqlParameter[] {
						new SqlParameter("@vendcode",objModel.vendcode),
						new SqlParameter("@vendlcname",objModel.vendlcname),
						new SqlParameter("@vendcadd2",objModel.vendcadd2),
						new SqlParameter("@vendfax",objModel.vendfax),
						new SqlParameter("@vendclose",objModel.vendclose),
						new SqlParameter("@vendtype",objModel.vendtype),
						new SqlParameter("@vendadd1",objModel.vendadd1),
						new SqlParameter("@vendcadd3",objModel.vendcadd3),
						new SqlParameter("@vendcurr",objModel.vendcurr),
						new SqlParameter("@vendrmk",objModel.vendrmk),
						new SqlParameter("@vendname",objModel.vendname),
						new SqlParameter("@vendadd2",objModel.vendadd2),
						new SqlParameter("@vendctact",objModel.vendctact),
						new SqlParameter("@vendemail",objModel.vendemail),
						new SqlParameter("@crusr",DBUtility._user_id),
						new SqlParameter("@vendcname",objModel.vendcname),
						new SqlParameter("@vendadd3",objModel.vendadd3),
						new SqlParameter("@vendcoun",objModel.vendcoun),
						new SqlParameter("@vendpterm",objModel.vendpterm),
						new SqlParameter("@vendlname",objModel.vendlname),
						new SqlParameter("@vendcadd1",objModel.vendcadd1),
						new SqlParameter("@vendtel",objModel.vendtel),
						new SqlParameter("@vendopen",objModel.vendopen)
				   };

					Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
				}
				else
				{
					MessageBox.Show("供應商編號已存在，請輸入新的編號。");
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			return Result;
		}

		/// <summary>
		/// 編輯供應商資料
		/// </summary>
		/// <param name="objModel"></param>
		/// <returns></returns>
		public static int UpdateVendor(mdlVendor objModel)
		{
			int Result = 0;
			try
			{
				string strSql = @" UPDATE bs_vendor SET  vendtype=@vendtype,   vendname=@vendname,   vendcname=@vendcname, vendlname=@vendlname, vendlcname=@vendlcname
														,vendadd1=@vendadd1,   vendadd2=@vendadd2,   vendadd3=@vendadd3,   vendcadd1=@vendcadd1, vendcadd2=@vendcadd2
														,vendcadd3=@vendcadd3, vendctact=@vendctact, vendcoun=@vendcoun,   vendtel=@vendtel,     vendfax=@vendfax
														,vendcurr=@vendcurr,   vendemail=@vendemail, vendpterm=@vendpterm, vendopen=@vendopen,   vendclose=@vendclose 
														,vendrmk=@vendrmk,     amusr=@amusr,         amtim=GETDATE()
								WHERE vendcode=@vendcode ";
				SqlParameter[] paras = new SqlParameter[] {
					new SqlParameter("@vendcode",objModel.vendcode),
					new SqlParameter("@vendlcname",objModel.vendlcname),
					new SqlParameter("@vendcadd2",objModel.vendcadd2),
					new SqlParameter("@vendfax",objModel.vendfax),
					new SqlParameter("@vendclose",objModel.vendclose),
					new SqlParameter("@vendtype",objModel.vendtype),
					new SqlParameter("@vendadd1",objModel.vendadd1),
					new SqlParameter("@vendcadd3",objModel.vendcadd3),
					new SqlParameter("@vendcurr",objModel.vendcurr),
					new SqlParameter("@vendrmk",objModel.vendrmk),
					new SqlParameter("@vendname",objModel.vendname),
					new SqlParameter("@vendadd2",objModel.vendadd2),
					new SqlParameter("@vendctact",objModel.vendctact),
					new SqlParameter("@vendemail",objModel.vendemail),
					new SqlParameter("@amusr",DBUtility._user_id),
					new SqlParameter("@vendcname",objModel.vendcname),
					new SqlParameter("@vendadd3",objModel.vendadd3),
					new SqlParameter("@vendcoun",objModel.vendcoun),
					new SqlParameter("@vendpterm",objModel.vendpterm),
					new SqlParameter("@vendlname",objModel.vendlname),
					new SqlParameter("@vendcadd1",objModel.vendcadd1),
					new SqlParameter("@vendtel",objModel.vendtel),
					new SqlParameter("@vendopen",objModel.vendopen)
				};

				Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			return Result;
		}

		/// <summary>
		/// 刪除供應商
		/// </summary>
		/// <param name="pVendcode"></param>
		/// <returns></returns>
		public static int DeleteVendor(string pVendcode)
		{
			int Result = 0;
			try
			{
				string strSql = @" DELETE FROM bs_vendor WHERE vendcode=@ID ";
				SqlParameter[] paras = new SqlParameter[] {
					new SqlParameter("@ID",pVendcode)
				};

				Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			return Result;
		}

		/// <summary>
		/// 根據條件獲取供應商信息
		/// </summary>
		/// <param name="pVendcode"></param>
		/// <param name="pVendname"></param>
		/// <param name="pVendcname"></param>
		/// <returns></returns>
		public static DataTable GetVendors(string pVendcode, string pVendname, string pVendcname)
		{
			DataTable dtvendor = new DataTable();
			try
			{
				string strSql = @" SELECT     vendcode as vendor_id,   vendtype,  vendname,  vendcname as vendor_name, vendlname
											, vendlcname, vendadd1 as address_en,  vendadd2,  vendadd3,  vendcadd1 as address_chs
											, vendcadd2,  vendcadd3, vendctact as contacts, vendattn,  vendcoun as account
											, vendtel as tel,    vendfax as fax,   vendcbl,   vendcurr as m_id,  vendemail as email
											, vendpterm as terms,  vendflw,   vendcltd,  vendultd,  vendopen as opening
											, vendgtr,    vendclose as logout, vendcres,  vendrejc,  venddisc
											, vendrmk as remark,    vendamd,   vendrst,   crusr,     crtim
											, vendcrst,   vendhrst,  amusr,     amtim
									FROM bs_vendor ";
				if (pVendcode != "")
				{
					strSql += " WHERE vendcode like '%" + pVendcode + "%' ";

					if (pVendname != "")
					{
						strSql += " AND vendname like '%" + pVendname + "%' ";
					}

					if (pVendcname != "")
					{
						strSql += " AND vendcname like '%" + pVendcname + "%' ";
					}

				}
				else
				{
					if (pVendname != "")
					{
						strSql += " WHERE vendname like '%" + pVendname + "%' ";

						if (pVendcname != "")
						{
							strSql += " AND vendcname like '%" + pVendcname + "%' ";
						}
					}
					else
					{
						if (pVendcname != "")
						{
							strSql += " WHERE vendcname like '%" + pVendcname + "%' ";
						}
					}
				}

				dtvendor = clsPublicOfCF01.GetDataTable(strSql);
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			return dtvendor;
		}

		/// <summary>
		/// GEO -dgerp2 的供應商 
		/// </summary>
		/// <returns></returns>
		public static DataTable GetVendorInfo()
		{
			DataTable dtVendor = new DataTable();
			try
			{
				string strSQL = @"SELECT  id ,name FROM it_vendor WHERE  abbrev_id is not null ORDER BY id ";

				dtVendor = clsPublicOfGEO.GetDataTable(strSQL);
			}
			catch (Exception ex)
			{
				dtVendor = null;
				MessageBox.Show(ex.Message);
			}
			return dtVendor;
		}

	}
}
