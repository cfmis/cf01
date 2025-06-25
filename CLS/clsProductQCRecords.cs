using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace cf01.CLS
{
	public class clsProductQCRecords
	{
		/// <summary>
		/// 添加工序產品QC報告
		/// </summary>
		/// <returns></returns>
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
		public static int AddProductQCRecords(product_qc_records prd_records)
		{
			int Result = 0;
			try
			{
				string strSQL = "";
				strSQL = @"INSERT INTO dbo.product_qc_records(id, dep_no, prd_date,qc_date, mo_no,seq_id,mo_source,
																mat_item, mat_color, lot_qty, facade_actual_qty, size_actual_qty, 
																actual_size, mat_logo, oth_desc, no_pass_qty, qc_no_ok,
																qc_ok,do_result,crusr,crtim,seq_no,do_sample)
														  VALUES(@id, @dep_no, @prd_date,@qc_date, @mo_no,@seq_id,@mo_source,
																@mat_item, @mat_color, @lot_qty, @facade_actual_qty, @size_actual_qty, 
																@actual_size, @mat_logo, @oth_desc, @no_pass_qty, @qc_no_ok,
																@qc_ok, @do_result,@crusr,@crtim,@seq_no,@do_sample) ";

				SqlParameter[] paras = new SqlParameter[]{
					   new SqlParameter("@id",prd_records.id),
					   new SqlParameter("@dep_no",prd_records.dep_no),
					   new SqlParameter("@prd_date",prd_records.prd_date),
					   new SqlParameter("@qc_date",prd_records.qc_date),
					   new SqlParameter("@mo_no",prd_records.mo_no),
                       new SqlParameter("@seq_id",prd_records.seq_id),
                       new SqlParameter("@mo_source",prd_records.mo_source),
					   new SqlParameter("@mat_item",prd_records.mat_item),
					   new SqlParameter("@mat_color",prd_records.mat_color),
					   new SqlParameter("@lot_qty",prd_records.lot_qty),
					   new SqlParameter("@facade_actual_qty",prd_records.facade_actual_qty),
					   new SqlParameter("@size_actual_qty",prd_records.size_actual_qty),
					   new SqlParameter("@actual_size",prd_records.actual_size),
					   new SqlParameter("@mat_logo",prd_records.mat_logo),
					   new SqlParameter("@oth_desc",prd_records.oth_desc),
					   new SqlParameter("@no_pass_qty",prd_records.no_pass_qty),
					   new SqlParameter("@qc_no_ok",prd_records.qc_no_ok),
					   new SqlParameter("@qc_ok",prd_records.qc_ok),
					   new SqlParameter("@do_result",prd_records.do_result),
					   new SqlParameter("@crusr",prd_records.crusr),
					   new SqlParameter("@crtim",prd_records.crtim),
					   new SqlParameter("@seq_no",prd_records.seq_no),
                       new SqlParameter("@do_sample",prd_records.do_sample)
					};
                //同時更新
                //strSQL += @" UPDATE product_records SET qc_flag='Y' WHERE prd_id=" + prd_records.id + "";

				Result = clsPublicOfPad.ExecuteNonQuery(strSQL, paras, false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Result;
		}

		/// <summary>
		/// 更新已QC 的產品報告
		/// </summary>
		/// <param name="lsEntity"></param>
		/// <param name="ServerConn"></param>
		/// <returns></returns>
		public static int UpdateProductQCRecords(product_qc_records prd_records)
		{
			int Result = 0;
			try
			{
				string strSQL = "";
				strSQL = @" UPDATE dbo.product_qc_records 
								SET qc_date=@qc_date ,mat_color=@mat_color ,facade_actual_qty=@facade_actual_qty ,size_actual_qty=@size_actual_qty ,actual_size=@actual_size
									,seq_id=@seq_id,mat_logo=@mat_logo ,no_pass_qty=@no_pass_qty ,oth_desc=@oth_desc ,do_result=@do_result ,amusr=@amusr
									,amtim=@amtim ,qc_no_ok=@qc_no_ok ,qc_ok=@qc_ok,do_sample=@do_sample,mo_source=@mo_source
							  WHERE id=@id and seq_no=@seq_no ";

				SqlParameter[] paras = new SqlParameter[]{
					   new SqlParameter("@qc_date",prd_records.qc_date),
					   new SqlParameter("@mat_color",prd_records.mat_color),
					   new SqlParameter("@facade_actual_qty",prd_records.facade_actual_qty),
					   new SqlParameter("@size_actual_qty",prd_records.size_actual_qty),
					   new SqlParameter("@actual_size",prd_records.actual_size),
                       new SqlParameter("@seq_id",prd_records.seq_id),
					   new SqlParameter("@mat_logo",prd_records.mat_logo),
					   new SqlParameter("@oth_desc",prd_records.oth_desc),
					   new SqlParameter("@no_pass_qty",prd_records.no_pass_qty),
					   new SqlParameter("@qc_no_ok",prd_records.qc_no_ok),
					   new SqlParameter("@qc_ok",prd_records.qc_ok),
                       new SqlParameter("@do_sample",prd_records.do_sample),
					   new SqlParameter("@do_result",prd_records.do_result),
					   new SqlParameter("@amusr",prd_records.amusr),
					   new SqlParameter("@amtim",prd_records.amtim),
					   new SqlParameter("@id",prd_records.id),
					   new SqlParameter("@seq_no",prd_records.seq_no),
                       new SqlParameter("@mo_source",prd_records.mo_source)
					};


				Result = clsPublicOfPad.ExecuteNonQuery(strSQL, paras, false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Result;
		}
        //刪除記錄
        public static int DeleteProductQCRecords(int prd_id,string seq_no)
        {
            int Result = 0;
            try
            {
                string strSql2 = @" DELETE FROM product_qc_records WHERE id = '" + prd_id + "' AND seq_no= '" + seq_no+"'";

                Result = clsPublicOfPad.ExecuteNonQuery(strSql2, null, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
		/// <summary>
		/// 獲取字樣
		/// </summary>
		/// <param name="pId"></param>
		/// <returns></returns>
        /// 獲取圖樣代號
		public static DataTable GetMat_Logo(string pId)
		{
			DataTable dtArt = new DataTable();
			try
			{
				DataTable dtMat_Logo = new DataTable();
                string strSql = $"SELECT a.id,a.name,Isnull(a.picture_name_h,'') as picture_name FROM cd_pattern a WHERE a.within_code='0000' And a.id='{pId}'";
                dtArt = clsConErp.GetDataTable(strSql);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

            return dtArt;
		}
        //獲取顏色
        public static DataTable GetMat_Color(string pId)
        {
            DataTable dtmo_data = new DataTable();
            try
            {
                string strSql = "SELECT id , name,do_color FROM  cd_color WHERE within_code='0000' AND id='" + pId + "'";
                dtmo_data = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtmo_data;
        }
		/// <summary>
		///獲取實際尺寸
		/// </summary>
		/// <param name="pId"></param>
		/// <returns></returns>
		public static String GetSize(string pId)
		{
			string strSizeName = "";
			try
			{
				DataTable dtSize = new DataTable();
                string strSql = "SELECT id , name FROM  cd_size  WHERE within_code='0000' AND id='" + pId + "'";
				dtSize = clsConErp.GetDataTable(strSql);
				if (dtSize.Rows.Count > 0)
				{
					strSizeName = dtSize.Rows[0]["name"].ToString();
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			return strSizeName;
		}
        //獲取物料描述
        public static String GetMatDesc(string pId)
        {
            string strMatName = "";
            try
            {
                DataTable dtSize = new DataTable();
                string strSql = "SELECT id , name FROM  it_goods  WHERE within_code='0000' AND id='" + pId + "'";
                dtSize = clsConErp.GetDataTable(strSql);
                if (dtSize.Rows.Count > 0)
                {
                    strMatName = dtSize.Rows[0]["name"].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return strMatName;
        }
        //獲取最大序號
        public static String GetMaxSeq(string dep_no,string qc_dat,string mo_source)
        {
            string seq_id = "";
            try
            {
                DataTable dtSize = new DataTable();
                string strSql = "SELECT Max(seq_id) AS seq_id FROM  product_qc_records "+
                    "WHERE dep_no='" + dep_no + "' AND qc_date='" + qc_dat + "' AND mo_source='" + mo_source + "'";
                dtSize = clsPublicOfPad.GetDataTable(strSql);
                if (dtSize.Rows.Count > 0)
                {
                    if (dtSize.Rows[0]["seq_id"].ToString() != "")
                    {
                        seq_id = (Convert.ToInt32(dtSize.Rows[0]["seq_id"].ToString())+1).ToString();
                        seq_id = seq_id.PadLeft(3, '0');
                    }
                    else
                        seq_id = "001";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return seq_id;
        }

        //獲取制單資料
        public static DataTable GetMoData(string mo_id, string prd_dept, string item,int mosource)
        {
            DataTable dtmo_data = new DataTable();
            try
            {
                string strSql = @" SELECT DISTINCT b.goods_id,c.name as name,b.prod_qty,b.next_wp_id,d.materiel_id AS mat_item,e.name AS mat_item_desc,b.sequence_id,b.ver
                                   from jo_bill_mostly a 
                                   INNER join jo_bill_goods_details b on a.within_code=b.within_code and a.id=b.id 
                                   INNER JOIN it_goods c on b.within_code=c.within_code and b.goods_id=c.id 
                                   INNER JOIN jo_bill_materiel_details d ON b.within_code=d.within_code and b.id=d.id and b.ver=d.ver and b.sequence_id=d.upper_sequence
                                   INNER JOIN it_goods e ON d.within_code=e.within_code and d.materiel_id=e.id
                                   WHERE a.within_code='0000'  And a.mo_id = '" + mo_id+"'";
                if (mosource == 1)
                    strSql += " And b.next_wp_id = '" + prd_dept + "' ";//如果是來料
                else
                    strSql += " And b.wp_id = '" + prd_dept + "' ";//如果是出貨
                if (item != "")
                {
                    strSql += " And b.goods_id ='" + item + "'";
                }

                dtmo_data = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtmo_data;
        }

	}
}
