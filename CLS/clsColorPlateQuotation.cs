using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsColorPlateQuotation
    {
        public static DataTable GetColorPlateQuotation(string pQuotation_no, string pColor_id)
        {
            DataTable dtColorPlate = new DataTable();

            string strSQL = @"Select color_id, vendor_id, valid_date, color_desc, vend_color, fee, unit, quotation_no, quotation_date  FROM color_plate_quotation ";
            if (pQuotation_no != "")
            {
                strSQL += " WHERE quotation_no ='" + pQuotation_no + "'";

                if (pColor_id != "")
                {
                    strSQL += " AND color_id ='" + pColor_id + "'";
                }
            }
            else
            {
                if (pColor_id != "")
                {
                    strSQL += " WHERE color_id ='" + pColor_id + "'";
                }
            }
            dtColorPlate = clsPublicOfCF01.GetDataTable(strSQL);

            return dtColorPlate;
        }

        public static int DeleteColorPlateQuotation(string pQuotation_no, string pColor_id)
        {
            int Result = -1;

            string strSQL = @" DELETE FROM color_plate_quotation WHERE quotation_no=@quotation_no AND color_id=@color_id ";
            SqlParameter[] paras = new SqlParameter[]{
				new SqlParameter("@quotation_no", pQuotation_no),
				new SqlParameter("@color_id", pColor_id)
			};
            Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);

            return Result;
        }

        public static int AddColorPlateQuotation(mdlColorPlateQuotation pModel)
        {
            int Result = -1;

            string strSQL = @" INSERT INTO color_plate_quotation 
												  (color_id, vendor_id, valid_date, color_desc, vend_color, fee, unit, quotation_no, quotation_date )
											VALUES(@color_id, @vendor_id, @valid_date, @color_desc, @vend_color, @fee, @unit, @quotation_no, @quotation_date )";
            SqlParameter[] paras = new SqlParameter[] {
			    new SqlParameter("@color_id",pModel.color_id),
			    new SqlParameter("@vendor_id",pModel.vendor_id),
				new SqlParameter("@valid_date",pModel.valid_date),
				new SqlParameter("@color_desc",pModel.color_desc),
				new SqlParameter("@vend_color",pModel.vend_color),
				new SqlParameter("@fee",pModel.fee),
				new SqlParameter("@unit",pModel.unit),
				new SqlParameter("@quotation_no",pModel.quotation_no),
				new SqlParameter("@quotation_date",pModel.quotation_date)
		    };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);

            return Result;
        }

        public static int UpdateColorPlateQuotation(mdlColorPlateQuotation pModel)
        {
            int Result = -1;

            string strSQL = @" UPDATE color_plate_quotation  SET color_desc= @color_desc, vend_color=@vend_color, fee=@fee, unit=@unit, quotation_date=@quotation_date
									   WHERE quotation_no=@quotation_no ";
            SqlParameter[] paras = new SqlParameter[] {
				new SqlParameter("@color_desc",pModel.color_desc),
				new SqlParameter("@vend_color",pModel.vend_color),
				new SqlParameter("@fee",pModel.fee),
				new SqlParameter("@unit",pModel.unit),
				new SqlParameter("@quotation_date",pModel.quotation_date),
				new SqlParameter("@quotation_no",pModel.quotation_no)
		   };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);

            return Result;
        }
    }
}
