using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using cf01.MDL;

namespace cf01.CLS
{
	public class clsCustomer
	{
		/// <summary>
		/// 新增客戶資料
		/// </summary>
		/// <param name="objModel"></param>
		/// <returns></returns>
		public static int AddCustomer(mdlCustomer objModel)
		{
			int Result = 0;
			try
			{
				string IsExist = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format(" SELECT custcode FROM bs_customer WHERE custcode='{0}' ", objModel.custcode));
				if (IsExist == "")
				{
					string strSql = @" INSERT INTO bs_customer(  custcode, custname, custtype, custcname, custlname, custlcname                                        
															,custarea, custadd1, custadd2, custadd3, custcadd1
															,custcadd2, custcadd3, custctact, custcoun, custtel  
															,custfax, custcurr, custemail, custpterm, custopen 
															,custclose, custrmk, crusr, crtim )
													 VALUES( @custcode, @custname, @custtype, @custcname, @custlname, @custlcname                          
															,@custarea, @custadd1, @custadd2, @custadd3, @custcadd1
															,@custcadd2, @custcadd3, @custctact, @custcoun, @custtel
															,@custfax, @custcurr, @custemail, @custpterm, @custopen
															,@custclose, @custrmk, @crusr, GETDATE()) ";
					SqlParameter[] paras = new SqlParameter[] { 
						new SqlParameter("@custcode",objModel.custcode),
						new SqlParameter("@custname",objModel.custname),
						new SqlParameter("@custtype",objModel.custtype),
						new SqlParameter("@custcname",objModel.custcname),
						new SqlParameter("@custlname",objModel.custlname),
						new SqlParameter("@custlcname",objModel.custlcname),
						new SqlParameter("@custarea",objModel.custarea),
						new SqlParameter("@custadd1",objModel.custadd1),
						new SqlParameter("@custadd2",objModel.custadd2),
						new SqlParameter("@custadd3",objModel.custadd3),
						new SqlParameter("@custcadd1",objModel.custcadd1),
						new SqlParameter("@custcadd2",objModel.custcadd2),
						new SqlParameter("@custcadd3",objModel.custcadd3),
						new SqlParameter("@custctact",objModel.custctact),
						new SqlParameter("@custcoun",objModel.custcoun),
						new SqlParameter("@custtel",objModel.custtel),
						new SqlParameter("@custfax",objModel.custfax),
						new SqlParameter("@custcurr",objModel.custcurr),
						new SqlParameter("@custemail",objModel.custemail),
						new SqlParameter("@custpterm",objModel.custpterm),
						new SqlParameter("@custopen",objModel.custopen),
						new SqlParameter("@custclose",objModel.custclose),
						new SqlParameter("@custrmk",objModel.custrmk),
						new SqlParameter("@crusr",DBUtility._user_id)
				  };

					Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
				}
				else
				{
					MessageBox.Show("客戶編號已存在，請輸入新的編號。");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return Result;
		}

		/// <summary>
		/// 更新客戶資料
		/// </summary>
		/// <param name="objModel"></param>
		/// <returns></returns>
		public static int UpdateCustomer(mdlCustomer objModel)
		{
			int Result = 0;
			try
			{
				string strSql = @" UPDATE bs_customer SET  custname=@custname,   custtype=@custtype,   custcname=@custcname, custlname=@custlname, custlcname=@custlcname
														 , custarea=@custarea,   custadd1=@custadd1,   custadd2=@custadd2,   custadd3=@custadd3,   custcadd1=@custcadd1
														 , custcadd2=@custcadd2, custcadd3=@custcadd3, custctact=@custctact, custcoun=@custcoun,   custtel=@custtel
														 , custfax=@custfax,     custcurr=@custcurr,   custemail=@custemail, custpterm=@custpterm, custopen=@custopen
														 , custclose=@custclose, custrmk=@custrmk,     amusr=@amusr,         amtim=GETDATE()
									WHERE custcode=@custcode ";
				SqlParameter[] paras = new SqlParameter[] { 
					new SqlParameter("@custcode",objModel.custcode),
					new SqlParameter("@custname",objModel.custname),
					new SqlParameter("@custtype",objModel.custtype),
					new SqlParameter("@custcname",objModel.custcname),
					new SqlParameter("@custlname",objModel.custlname),
					new SqlParameter("@custlcname",objModel.custlcname),
					new SqlParameter("@custarea",objModel.custarea),
					new SqlParameter("@custadd1",objModel.custadd1),
					new SqlParameter("@custadd2",objModel.custadd2),
					new SqlParameter("@custadd3",objModel.custadd3),
					new SqlParameter("@custcadd1",objModel.custcadd1),
					new SqlParameter("@custcadd2",objModel.custcadd2),
					new SqlParameter("@custcadd3",objModel.custcadd3),
					new SqlParameter("@custctact",objModel.custctact),
					new SqlParameter("@custcoun",objModel.custcoun),
					new SqlParameter("@custtel",objModel.custtel),
					new SqlParameter("@custfax",objModel.custfax),
					new SqlParameter("@custcurr",objModel.custcurr),
					new SqlParameter("@custemail",objModel.custemail),
					new SqlParameter("@custpterm",objModel.custpterm),
					new SqlParameter("@custopen",objModel.custopen),
					new SqlParameter("@custclose",objModel.custclose),
					new SqlParameter("@custrmk",objModel.custrmk),
					new SqlParameter("@amusr",DBUtility._user_id)
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
		/// 刪除客戶資料
		/// </summary>
		/// <param name="pCust_id"></param>
		/// <returns></returns>
		public static int DeleteCustomer(string pCustcode)
		{
			int Result = 0;
			try
			{
				string strSql = @" DELETE FROM bs_customer WHERE custcode=@ID ";
				SqlParameter[] paras = new SqlParameter[] { 
				  new SqlParameter("@ID",pCustcode)
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
		/// 查詢客戶資料
		/// </summary>
		/// <param name="pCust_id"></param>
		/// <returns></returns>
		public static DataTable GetCustomers(string pCustcode, string pCustname, string pCustcname)
		{
			DataTable dtcust = new DataTable();
			try
			{
				string strSql = @" SELECT   custcode,    custname,  custtype,  custcname, custlname
										  , custlcname, custarea,  custadd1 as address_en,  custadd2,  custadd3
										  , custcadd1 as address_chs,  custcadd2, custcadd3, custctact as contacts, custattn
										  , custcoun as account,   custtel as tel,   custfax as fax,   custcbl,   custcurr as m_id
										  , custemail as email,  custpterm as terms, custflw,   custcltd,  custultd
										  , custopen as opening,   custgtr,   custclose as logout, custrejc,  custdisc
										  , custcres,   custrmk as remark,   crusr,     crtim,     amusr, amtim
									FROM bs_customer ";
				if (pCustcode != "")
				{
					strSql += " WHERE custcode like '%" + pCustcode + "%' ";

					if (pCustname != "")
					{
						strSql += " AND custname like '%" + pCustname + "%' ";
					}

					if (pCustcname != "")
					{
						strSql += " AND custcname like '%" + pCustcname + "%' ";
					}

				}
				else
				{
					if (pCustname != "")
					{
						strSql += " WHERE custname like '%" + pCustname + "%' ";

						if (pCustcname != "")
						{
							strSql += " AND custcname like '%" + pCustcname + "%' ";
						}
					}
					else
					{
						if (pCustcname != "")
						{
							strSql += " WHERE custcname like '%" + pCustcname + "%' ";
						}
					}
				}

				dtcust = clsPublicOfCF01.GetDataTable(strSql);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return dtcust;
		}




	}
}
