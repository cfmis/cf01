using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cf01.CLS
{
	public class clsPlateFee
	{
		public static int AddPlate_Fee(List<mdlmt_plate_fee> lsPlateFee)
		{
			int Result = -1;
			try
			{
				string strSQL = "";
				for (int i = 0; i < lsPlateFee.Count; i++)
				{
					strSQL += string.Format("INSERT INTO mt_plate_fee(mt_item, valid_date, mt_fee, mt_unit, mt_curr) VALUES('{0}', '{1}', {2}, '{3}', '{4}')", lsPlateFee[i].mt_item, lsPlateFee[i].valid_date, lsPlateFee[i].mt_fee, lsPlateFee[i].mt_unit, lsPlateFee[i].mt_curr);
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



		/// <summary>
		/// 電鍍單收貨單價設定
		/// </summary>
		/// <param name="lsModel"></param>
		/// <returns></returns>
		public static int AddPlatePrice(List<rece_goods_plate> lsModel)
		{
			int Result = -1;
			try
			{
				string strSQL = "";

				for (int i = 0; i < lsModel.Count; i++)
				{
					strSQL += string.Format(@" INSERT into rece_goods_plate(vendor_id, rec_id, ir_date, sequence_id, mo_id, goods_id, 
																			vendor_invoice_no, t_ir_qty, price, ir_unit, sec_qty, sec_price,
																			sec_unit, p_unit, min_consume_amount, package_num,do_color,total_amt)
																	  VALUES('{0}', '{1}','{2}', '{3}', '{4}', '{5}', 
																			 '{6}', {7}, {8}, '{9}', {10}, {11},
																			 '{12}', '{13}', {14}, {15}, '{16}', {17}) ",
											 lsModel[i].vendor_id, lsModel[i].rec_id, lsModel[i].ir_date, lsModel[i].sequence_id, lsModel[i].mo_id, lsModel[i].goods_id,
											 lsModel[i].vendor_invoice_no, lsModel[i].t_ir_qty, lsModel[i].price, lsModel[i].ir_unit, lsModel[i].sec_qty, lsModel[i].sec_price,
											 lsModel[i].sec_unit, lsModel[i].p_unit, lsModel[i].min_consume_amount, lsModel[i].package_num, lsModel[i].do_color, lsModel[i].total_amt);


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

	}
}
