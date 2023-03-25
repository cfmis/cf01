using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using cf01.MDL;
using System.Threading;
using cf01.Forms;

namespace cf01.CLS
{
    public class clsTestProductPlan
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        #region 材料類別

        public static int AddMatType(string pMat_id, string pMat_cdesc, string pMat_edesc, string pSeq_id, string pRemark)
        {
            int Result = 0;

            string strSql = @"INSERT INTO bs_test_mat_type(id, name, name_english, seq_id, remark)VALUES(@id, @name, @name_english, @seq_id, @remark)";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@id",pMat_id),
              new SqlParameter("@name",pMat_cdesc),
              new SqlParameter("@name_english",pMat_edesc),
              new SqlParameter("@seq_id",pSeq_id),
              new SqlParameter("@remark",pRemark)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }

        public static int DeleteMatType(string pMat_id)
        {
            int Result = 0;

            string strSql = @"DELETE FROM bs_test_mat_type WHERE id=@id ";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@id",pMat_id)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }


        public static int UpdateMatType(string pMat_id, string pMat_name, string pMat_edesc, string pSeq_id, string pRemark)
        {
            int Result = 0;

            string strSql = @"UPDATE bs_test_mat_type SET name=@name, name_english=@name_english, seq_id=@seq_id, remark=@remark WHERE id=@id ";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@id",pMat_id),
              new SqlParameter("@name",pMat_name),
               new SqlParameter("@name_english",pMat_edesc),
              new SqlParameter("@seq_id",pSeq_id),
              new SqlParameter("@remark",pRemark)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }

        public static DataTable GetMatTypeData(string pMat_id, string pMat_name)
        {
            DataTable dtMatType = new DataTable();

            string strSql = @"SELECT * FROM bs_test_mat_type";
            if (pMat_id != "" && pMat_name != "")
            {
                strSql += " WHERE id='" + pMat_id + "' AND name='" + pMat_name + "'";
            }
            else
            {
                if (pMat_id != "")
                {
                    strSql += " WHERE id='" + pMat_id + "'";
                }
                else
                {
                    if (pMat_name != "")
                    {
                        strSql += " WHERE name LIKE '%" + pMat_id + "%'";
                    }
                }
            }
            dtMatType = clsPublicOfCF01.GetDataTable(strSql);

            return dtMatType;
        }

        #endregion

        #region 客戶產品類型
        public static int AddCustProduct(string pCustProd_id, string pCustProd_cdesc, string pCustProd_edesc)
        {
            int Result = 0;

            string strSql = @"INSERT INTO bs_test_cust_product(id, cdesc, edesc, cruser, crtim)VALUES(@id, @cdesc, @edesc, @cruser, @crtim)";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@id",pCustProd_id),
              new SqlParameter("@cdesc",pCustProd_cdesc),
              new SqlParameter("@edesc",pCustProd_edesc),
              new SqlParameter("@cruser",DBUtility._user_id),
              new SqlParameter("@crtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }

        public static int UpdateCustProduct(string pCustProd_id, string pCustProd_cdesc, string pCustProd_edesc)
        {
            int Result = 0;

            string strSql = @"UPDATE bs_test_cust_product SET cdesc=@cdesc, edesc=@edesc, amusr=@amusr, amtim=@amtim WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@id",pCustProd_id),
              new SqlParameter("@cdesc",pCustProd_cdesc),
              new SqlParameter("@edesc",pCustProd_edesc),
              new SqlParameter("@amusr",DBUtility._user_id),
              new SqlParameter("@amtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }

        public static int DeleteCustProduct(string pCustProd_id)
        {
            int Result = 0;

            string strSql = @"DELETE FROM bs_test_cust_product WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@id",pCustProd_id),
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return Result;
        }

        public static DataTable GetCustProduct(string pCustProd_id, string pCustProd_cdesc)
        {
            string strSql = @"SELECT * FROM bs_test_cust_product";
            if (pCustProd_id != "")
            {
                strSql += " WHERE id='" + pCustProd_id + "'";
                if (pCustProd_cdesc != "")
                {
                    strSql += " AND cdesc='" + pCustProd_cdesc + "'";
                }
            }
            else
            {
                if (pCustProd_cdesc != "")
                {
                    strSql += " WHERE cdesc LIKE '%" + pCustProd_cdesc + "%'";
                }
            }
            DataTable dtCustProduct = clsPublicOfCF01.GetDataTable(strSql);

            return dtCustProduct;
        }

        #endregion

        #region 顏色類別
        public static int AddColorCategory(string pClrCgy_id, string pClrCgy_cdesc, string pClrCgy_edesc)
        {
            int Result = 0;
            string strSql = @"INSERT INTO bs_test_color_category(id, cdesc, edesc, cruser, crtim)VALUES(@id, @cdesc, @edesc, @cruser, @crtim)";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",pClrCgy_id),
              new SqlParameter("@cdesc",pClrCgy_cdesc),
              new SqlParameter("@edesc",pClrCgy_edesc),
              new SqlParameter("@cruser",DBUtility._user_id),
              new SqlParameter("@crtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static int DeleteColorCategory(string pClrCgy_id)
        {
            int Result = 0;
            string strSql = @"DELETE FROM bs_test_color_category WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",pClrCgy_id),
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static int UpdateColorCategory(string pClrCgy_id, string pClrCgy_cdesc, string pClrCgy_edesc)
        {
            int Result = 0;
            string strSql = @"UPDATE bs_test_color_category SET cdesc=@cdesc, edesc=@edesc, amusr=@amusr, amtim=@amtim WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",pClrCgy_id),
              new SqlParameter("@cdesc",pClrCgy_cdesc),
              new SqlParameter("@edesc",pClrCgy_edesc),
              new SqlParameter("@amusr",DBUtility._user_id),
              new SqlParameter("@amtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static DataTable GetColorCategory(string pClrCgy_id, string pClrCgy_cdesc)
        {
            string strSql = @"SELECT * FROM bs_test_color_category";
            if (pClrCgy_id != "")
            {
                strSql += " WHERE id='" + pClrCgy_id + "'";
                if (pClrCgy_cdesc != "")
                {
                    strSql += " AND cdesc='" + pClrCgy_cdesc + "'";
                }
            }
            else
            {
                if (pClrCgy_cdesc != "")
                {
                    strSql += " WHERE cdesc LIKE '%" + pClrCgy_cdesc + "%'";
                }
            }
            DataTable dtCC = clsPublicOfCF01.GetDataTable(strSql);
            return dtCC;
        }

        public static int GetMaxCCId()
        {
            int maxId = 0;
            string strSql = @"SELECT MAX(id) FROM bs_test_color_category";
            string strId = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            if (strId != "")
            {
                maxId = Convert.ToInt32(strId);
            }
            return maxId;
        }

        #endregion

        #region 測試項目
        public static int AddTestItem(string pItem_id, string pItem_cdesc, string pItem_edesc, string pRemark)
        {
            int Result = 0;
            string strSql = @"INSERT INTO bs_test_item(id, cdesc, edesc, remark, crusr, crtim)VALUES(@id, @cdesc, @edesc, @remark, @crusr, @crtim)";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",pItem_id),
              new SqlParameter("@cdesc",pItem_cdesc),
              new SqlParameter("@edesc",pItem_edesc),
              new SqlParameter("@remark",pRemark),
              new SqlParameter("@crusr",DBUtility._user_id),
              new SqlParameter("@crtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static int DeleteTestItem(string pItem_id)
        {
            int Result = 0;
            string strSql = @"DELETE FROM bs_test_item WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",pItem_id),
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static int UpdateTestItem(string pItem_id, string pItem_cdesc, string pItem_edesc, string pRemark)
        {
            int Result = 0;
            string strSql = @"UPDATE bs_test_item SET cdesc=@cdesc, edesc=@edesc, remark=@remark, amusr=@amusr, amtim=@amtim WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",pItem_id),
              new SqlParameter("@cdesc",pItem_cdesc),
              new SqlParameter("@edesc",pItem_edesc),
              new SqlParameter("@remark",pRemark),
              new SqlParameter("@amusr",DBUtility._user_id),
              new SqlParameter("@amtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static DataTable GetTestItem(string pItem_id, string pItem_cdesc)
        {
            string strSql = "SELECT * FROM bs_test_item";
            if (pItem_id != "")
            {
                strSql += " WHERE id='" + pItem_id + "'";
                if (pItem_cdesc != "")
                {
                    strSql += " AND cdesc='" + pItem_cdesc + "'";
                }
            }
            else
            {
                if (pItem_cdesc != "")
                {
                    strSql += " WHERE cdesc LIKE '%" + pItem_cdesc + "%'";
                }
            }
            DataTable dtTestItem = clsPublicOfCF01.GetDataTable(strSql);

            return dtTestItem;
        }

        public static int GetMaxItemId()
        {
            int MaxId = 0;
            string strSql = "SELECT MAX(id) FROM bs_test_item";

            string strId = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);

            if (strId != "")
            {
                MaxId = Convert.ToInt32(strId);
            }
            return MaxId;
        }

        /// <summary>
        /// 取GEO 的測試項目
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTestItemForLue()
        {
            DataTable dtTestItem = new DataTable();
            try
            {
                string strSql = @"SELECT test_item_id,test_item_id+'('+test_item_name+')' as test_item_cdesc,english_name as test_item_edesc FROM cd_qc_test_item ";

                dtTestItem = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtTestItem;
        }

        #endregion

        #region 產品類型
        public static int AddProductType(string PT_id, string PT_cdesc, string PT_edesc, string PT_remark)
        {
            int Result = 0;
            string strSql = @"INSERT INTO bs_test_product_type(id, edesc, cdesc, remark, crusr, crtim)VALUES(@id, @edesc, @cdesc, @remark, @crusr, @crtim)";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",PT_id),
              new SqlParameter("@cdesc",PT_cdesc),
              new SqlParameter("@edesc",PT_edesc),
              new SqlParameter("@remark",PT_remark),
              new SqlParameter("@crusr",DBUtility._user_id),
              new SqlParameter("@crtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static int DeleteProductType(string PT_id)
        {
            int Result = 0;
            string strSql = @"DELETE FROM bs_test_product_type WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",PT_id),
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static int UpdateProductType(string PT_id, string PT_cdesc, string PT_edesc, string PT_remark)
        {
            int Result = 0;
            string strSql = @"UPDATE bs_test_product_type SET edesc=@edesc, cdesc=@cdesc, remark=@remark, amusr=@amusr, amtim=@amtim  WHERE id=@id";
            SqlParameter[] paras = new SqlParameter[]{
              new SqlParameter("@id",PT_id),
              new SqlParameter("@cdesc",PT_cdesc),
              new SqlParameter("@edesc",PT_edesc),
              new SqlParameter("@remark",PT_remark),
              new SqlParameter("@amusr",DBUtility._user_id),
              new SqlParameter("@amtim",DateTime.Now)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static DataTable GetProductType(string PT_id, string PT_cdesc)
        {
            string strSql = @"SELECT * FROM bs_test_product_type ";
            if (PT_id != "")
            {
                strSql += " WHERE id='" + PT_id + "'";
                if (PT_cdesc != "")
                {
                    strSql += " AND cdesc='" + PT_cdesc + "'";
                }
            }
            else
            {
                if (PT_cdesc != "")
                {
                    strSql += " WHERE cdesc LIKE '%" + PT_cdesc + "%'";
                }
            }

            DataTable dtProductType = clsPublicOfCF01.GetDataTable(strSql);
            return dtProductType;
        }

        public static int GetMaxProductTypeId()
        {
            int MaxId = 0;
            string strSql = "SELECT MAX(id) FROM bs_test_product_type";

            string strId = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);

            if (strId != "")
            {
                MaxId = Convert.ToInt32(strId);
            }
            return MaxId;
        }

        #endregion

        #region 測試項目設置

        public static int AddTestItemSetting(MDL.mdlTestItemMostly objMostly)
        {
            int Result = 0;
            string strSql = "";
            if (objMostly.isExsit != "Y")
            {
                strSql += string.Format(@"INSERT INTO bs_test_item_mostly(id, type, cdesc, edesc, remark, crusr, crtim)
                                          VALUES('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE())"
                                                , objMostly.id, objMostly.type, objMostly.cdesc, objMostly.edesc, objMostly.remark, DBUtility._user_id);
            }

            for (int i = 0; i < objMostly.lsDetails.Count; i++)
            {
                if (objMostly.lsDetails[i].isExsit == "Y")
                {
                    strSql += string.Format(@"UPDATE bs_test_item_details SET test_item_id='{0}', test_item_cdesc='{1}', remark='{2}',amusr='{3}',amtim=GETDATE() 
                                              WHERE id='{4}' AND seq_id='{5}'"
                                              , objMostly.lsDetails[i].test_item_id, objMostly.lsDetails[i].test_item_cdesc, objMostly.lsDetails[i].remark
                                              , DBUtility._user_id, objMostly.lsDetails[i].id, objMostly.lsDetails[i].seq_id);
                }
                else
                {
                    strSql += string.Format(@"INSERT INTO bs_test_item_details(id, seq_id, test_item_id, test_item_cdesc, remark, crusr, crtim)
                                              VALUES('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE()) "
                                                     , objMostly.lsDetails[i].id, objMostly.lsDetails[i].seq_id, objMostly.lsDetails[i].test_item_id
                                                     , objMostly.lsDetails[i].test_item_cdesc, objMostly.lsDetails[i].remark, DBUtility._user_id);
                }
            }
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, null, false);
            return Result;
        }

        public static int UpdateTestItemSetting(MDL.mdlTestItemMostly objMostly)
        {
            int Result = 0;
            string strSql = "";
            if (objMostly.isExsit == "Y")
            {
                strSql += string.Format(@"UPDATE bs_test_item_mostly SET remark='{0}',amusr='{1}',amtim=GETDATE() WHERE id='{2}'"
                                                , objMostly.remark, DBUtility._user_id, objMostly.id);
            }

            for (int i = 0; i < objMostly.lsDetails.Count; i++)
            {
                if (objMostly.lsDetails[i].isExsit == "Y")
                {
                    strSql += string.Format(@"UPDATE bs_test_item_details SET test_item_id='{0}', test_item_cdesc='{1}', remark='{2}',amusr='{3}',amtim=GETDATE() 
                                              WHERE id='{4}' AND seq_id='{5}'"
                                              , objMostly.lsDetails[i].test_item_id, objMostly.lsDetails[i].test_item_cdesc, objMostly.lsDetails[i].remark
                                              , DBUtility._user_id, objMostly.lsDetails[i].id, objMostly.lsDetails[i].seq_id);
                }
                else
                {
                    strSql += string.Format(@"INSERT INTO bs_test_item_details(id, seq_id, test_item_id, test_item_cdesc, remark, crusr, crtim)
                                              VALUES('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE()) "
                                                      , objMostly.lsDetails[i].id, objMostly.lsDetails[i].seq_id, objMostly.lsDetails[i].test_item_id
                                                      , objMostly.lsDetails[i].test_item_cdesc, objMostly.lsDetails[i].remark, DBUtility._user_id);
                }

            }
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, null, false);
            return Result;
        }

        public static int DeleteTestItemDetails(string pItemType_id, string pTestItem_id)
        {
            int Result = 0;
            string strSql = @"DELETE FROM bs_test_item_details WHERE id=@id AND test_item_id=@test_item_id ";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@id",pItemType_id),
               new SqlParameter("@test_item_id",pTestItem_id)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return Result;
        }

        public static DataTable GetTestItemMostly(string pId)
        {
            string strSql = @"SELECT id, type, cdesc, edesc, remark, crusr, crtim, amusr, amtim,'' as isExsit FROM bs_test_item_mostly WHERE id='" + pId + "'";
            DataTable dtMostly = clsPublicOfCF01.GetDataTable(strSql);
            if (dtMostly.Rows.Count > 0)
            {
                for (int i = 0; i < dtMostly.Rows.Count; i++)
                {
                    dtMostly.Rows[i]["isExsit"] = "Y";
                }
            }

            return dtMostly;
        }

        public static DataTable GetAllTestItemMostly()
        {
            string strSql = @"SELECT id, type, cdesc, edesc, remark, crusr, crtim, amusr, amtim,'' as isExsit FROM bs_test_item_mostly ";
            DataTable dtMostly = clsPublicOfCF01.GetDataTable(strSql);

            return dtMostly;
        }


        public static DataTable GetTestItemDetails(string pId)
        {
            string strSql = @"SELECT id,seq_id,test_item_id,test_item_cdesc,''as test_item_edesc,remark,'' as isExsit FROM bs_test_item_details WHERE id='" + pId + "'";
            DataTable dtDetails = clsPublicOfCF01.GetDataTable(strSql);
            if (dtDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    dtDetails.Rows[i]["isExsit"] = "Y";
                }
            }

            return dtDetails;
        }


        #endregion

        #region 測試excel
        public static int AddTestExcel(mdlTestExcel objTe)
        {
            int Result = 0;
            //註意DATETIME字段傳遞NULL值的處理
            string strSql = @"INSERT INTO bs_test_excel
            (mat_id,seq_id,color_id,finish_name,poduct_type_id,trim_color_code,trim_code,test_item_id,test_report_no,test_report_path,pattern_id,
            remark, ref_mo,crusr, crtim, size,cf_color,sales_group,doc_type,expiry_date)
            VALUES(@mat_id,@seq_id, @color_id, @finish_name, @poduct_type_id,@trim_color_code, @trim_code, @test_item_id, @test_report_no, @test_report_path,@pattern_id,
            @remark, @ref_mo,@crusr,GETDATE(),@size,@cf_color,@sales_group,@doc_type,CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END)";
            
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@mat_id",objTe.mat_id),
               new SqlParameter("@seq_id",objTe.seq_id),
               new SqlParameter("@color_id",objTe.color_id),
               new SqlParameter("@finish_name",objTe.finish_name),
               new SqlParameter("@poduct_type_id",objTe.poduct_type_id),
               new SqlParameter("@trim_color_code",objTe.trim_color_code),
               new SqlParameter("@trim_code",objTe.trim_code),
               new SqlParameter("@test_item_id",objTe.test_item_id),
               new SqlParameter("@test_report_no",objTe.test_report_no),
               new SqlParameter("@test_report_path",objTe.test_report_path),
               new SqlParameter("@expiry_date",objTe.expiry_date),
               new SqlParameter("@pattern_id",objTe.pattern_id),
               new SqlParameter("@remark",objTe.remark),
               new SqlParameter("@ref_mo",objTe.ref_mo),
               new SqlParameter("@crusr",DBUtility._user_id),
               new SqlParameter("@size",objTe.size),
               new SqlParameter("@cf_color",objTe.cf_color),
               new SqlParameter("@sales_group",objTe.sales_group),
               new SqlParameter("@doc_type",objTe.doc_type)               
            };

            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            if (Result > 0)
            {
                if (objTe.test_report_no != "" && objTe.ref_mo != "")
                {
                    int UpResult = UpdateCustProdcutTestStand(objTe.test_item_id, objTe.test_report_no, objTe.test_report_path, objTe.expiry_date, objTe.ref_mo);
                }
            }
            return Result;
        }

        public static int DeleteTestExcel(string pSeq_id, string pMat_id)
        {
            int Result = 0;
            //string sql_del = String.Format(@"DELETE FROM bs_test_excel WHERE mat_id='{0}' and seq_id='{1}'", pMat_id, pSeq_id);
            //Result = clsPublicOfCF01.ExecuteNonQuery(sql_del, null, false);
            //return Result;
            string sql_u = String.Format(@"Update bs_test_excel set amusr='{0}',amtim=getdate() WHERE mat_id='{1}' and seq_id='{2}'", DBUtility._user_id, pMat_id, pSeq_id);
            string sql_i = String.Format(@"Insert bs_test_excel_del Select * From bs_test_excel WHERE mat_id='{0}' and seq_id='{1}'", pMat_id, pSeq_id);
            string sql_del = String.Format(@"DELETE FROM bs_test_excel WHERE mat_id='{0}' and seq_id='{1}'", pMat_id, pSeq_id);
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString); //改爲cf01
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.CommandText = sql_u;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = sql_i;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = sql_del;
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit(); //數據提交
                    Result = 1;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    Result = 0;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }
            }
            return Result;
        }

        public static int UpdateTestExcel(mdlTestExcel objTe)
        {
            int Result = 0;           
            string strSql = @"UPDATE bs_test_excel SET color_id=@color_id, finish_name=@finish_name, poduct_type_id=@poduct_type_id ,trim_color_code=@trim_color_code,
                                     trim_code=@trim_code,test_item_id=@test_item_id, test_report_no=@test_report_no,test_report_path=@test_report_path,
                                     pattern_id=@pattern_id, remark=@remark,ref_mo=@ref_mo, amusr=@amusr, amtim=getdate(),
                                     size=@size,cf_color=@cf_color,sales_group=@sales_group,doc_type=@doc_type,
                                     [expiry_date]=CASE LEN(@expiry_date) WHEN 0 THEN null ELSE @expiry_date END
                              WHERE mat_id=@mat_id AND seq_id=@seq_id";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@mat_id",objTe.mat_id),
               new SqlParameter("@seq_id",objTe.seq_id),
               new SqlParameter("@color_id",objTe.color_id),
               new SqlParameter("@finish_name",objTe.finish_name),
               new SqlParameter("@poduct_type_id",objTe.poduct_type_id),
               new SqlParameter("@trim_color_code",objTe.trim_color_code),
               new SqlParameter("@trim_code",objTe.trim_code),
               new SqlParameter("@test_item_id",objTe.test_item_id),
               new SqlParameter("@test_report_no",objTe.test_report_no),
               new SqlParameter("@test_report_path",objTe.test_report_path),
               new SqlParameter("@expiry_date",objTe.expiry_date),
               new SqlParameter("@pattern_id",objTe.pattern_id),
               new SqlParameter("@remark",objTe.remark),
               new SqlParameter("@ref_mo",objTe.ref_mo),
               new SqlParameter("@amusr",DBUtility._user_id),
               new SqlParameter("@size",objTe.size),
               new SqlParameter("@cf_color",objTe.cf_color),
               new SqlParameter("@sales_group",objTe.sales_group),
               new SqlParameter("@doc_type",objTe.doc_type)            
            };

            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            if (Result > 0)
            {
                if (objTe.test_report_no != "" && objTe.ref_mo != "")
                {
                    int UpResult = UpdateCustProdcutTestStand(objTe.test_item_id, objTe.test_report_no, objTe.test_report_path, objTe.expiry_date, objTe.ref_mo);
                }
            }

            return Result;
        }

        public static DataTable GetTestExcelById(string pSeq_id, string pMat_id)
        {
            DataTable dtTe = new DataTable();
            string strSql = @"SELECT a.mat_id, a.seq_id, a.color_id, a.finish_name, a.poduct_type_id
                                    ,a.trim_color_code, a.trim_code, a.pattern_id, a.test_item_id, a.test_report_no
                                    ,a.expiry_date, a.remark, a.ref_mo, a.crusr, a.crtim, a.amusr, a.amtim ,a.test_report_path
                                    ,a.mat_id+'('+b.name+')' as mat_cdesc,a.color_id+'('+c.cdesc+')'as color_cdesc,a.poduct_type_id+'('+ d.cdesc+')' as prod_type_cdesc,'' as Test_item_cdesc
                                    ,a.size,a.cf_color,a.sales_group,a.doc_type
                                    ,CONVERT(date,GETDATE(),120) as valid_date                                    
                            FROM bs_test_excel a
                            LEFT JOIN bs_test_mat_type b ON a.mat_id=b.id
                            LEFT JOIN bs_test_color_category c ON a.color_id=c.id
                            LEFT JOIN bs_test_product_type d ON a.poduct_type_id=d.id 
                            WHERE 1>0 ";
            if (pSeq_id != "")
            {
                strSql += " AND a.seq_id='" + pSeq_id + "'";
            }
            if (pMat_id != "")
            {
                strSql += " AND a.mat_id='" + pMat_id + "'";
            }

            strSql += " ORDER BY a.seq_id";
            dtTe = clsPublicOfCF01.GetDataTable(strSql);

            if (dtTe.Rows.Count > 0)
            {
                DataTable dtTestItem = GetTestItemForLue();

                for (int i = 0; i < dtTe.Rows.Count; i++)
                {
                    DataRow[] dr = dtTestItem.Select("test_item_id='" + dtTe.Rows[i]["test_item_id"].ToString() + "'");
                    if (dr.Length > 0)
                    {
                        dtTe.Rows[i]["Test_item_cdesc"] = dr[0]["test_item_cdesc"].ToString();
                    }
                }
            }

            return dtTe;
        }

        public static DataTable GetTestExcel(mdlTestExcel objTe)
        {
            DataTable dtTe = new DataTable();
            StringBuilder sb = new StringBuilder(
                            @"SELECT a.mat_id, a.seq_id, a.color_id, a.finish_name, a.poduct_type_id
                                    ,a.trim_color_code, a.trim_code, a.pattern_id, a.test_item_id, a.test_report_no
                                    ,a.expiry_date, a.remark,a.ref_mo, a.crusr, a.crtim, a.amusr, a.amtim, a.test_report_path 
                                    ,a.mat_id+'('+b.name+')' as mat_cdesc,a.color_id+'('+c.cdesc+')'as color_cdesc
                                    ,a.poduct_type_id+'('+ d.cdesc+')' as prod_type_cdesc,'' as test_item_cdesc
                                    ,a.size,a.cf_color,a.sales_group,a.doc_type,CONVERT(date,GETDATE(),120) as valid_date
                                    ,a.test_report_no as report_no,a.test_dept,a.invoice_id                            
                            FROM bs_test_excel a
                            LEFT JOIN bs_test_mat_type b ON a.mat_id=b.id
                            LEFT JOIN bs_test_color_category c ON a.color_id=c.id
                            LEFT JOIN bs_test_product_type d ON a.poduct_type_id=d.id
                            Where 1>0 ");
            if (objTe.mat_id != "" && objTe.mat_id != null)
            {
                sb.Append(string.Format(" AND a.mat_id='{0}'", objTe.mat_id));
            }

            if (objTe.poduct_type_id != "" && objTe.poduct_type_id != null)
            {
                sb.Append(string.Format(" AND a.poduct_type_id='{0}'", objTe.poduct_type_id));
            }

            if (objTe.test_item_id != "" && objTe.test_item_id != null)
            {
                sb.Append(string.Format(" AND a.test_item_id='{0}'", objTe.test_item_id));
            }

            if (objTe.color_id != "" && objTe.color_id != null)
            {
                sb.Append(string.Format(" AND a.color_id='{0}'", objTe.color_id));
            }
            if (objTe.pattern_id != "")
            {
                sb.Append(string.Format(" AND a.pattern_id LIKE '%{0}%'", objTe.pattern_id));
            }
            if (objTe.finish_name != "")
            {
                sb.Append(string.Format(" AND a.finish_name Like '%{0}%'", objTe.finish_name));
            }
            if (objTe.trim_color_code != "")
            {
                sb.Append(string.Format(" AND a.trim_color_code Like '%{0}%'", objTe.trim_color_code));
            }
            if (objTe.trim_code != "")
            {
                sb.Append(string.Format(" AND a.trim_code Like '%{0}%'", objTe.trim_code));
            }
            if (objTe.test_report_no != "")
            {                
                sb.Append(string.Format(" AND a.test_report_no Like '%{0}%'", objTe.test_report_no));
            }

            if (!string.IsNullOrEmpty(objTe.expiry_date))
            {
                sb.Append(string.Format(" AND a.expiry_date='{0}'", objTe.expiry_date));
            }
            if (objTe.ref_mo != "")
            {                
                sb.Append(string.Format(" AND a.ref_mo='{0}'", objTe.ref_mo));
            }
            if (objTe.size != "")
            {
                sb.Append(string.Format(" AND a.size Like '%{0}%'", objTe.size));
            }
            if (objTe.cf_color != "")
            {
                sb.Append(string.Format(" AND a.cf_color Like '%{0}%'", objTe.cf_color));
            }
            if (objTe.sales_group != "")
            {
                sb.Append(string.Format(" AND a.sales_group Like '%{0}%'", objTe.sales_group));
            }
            if (objTe.doc_type != "")
            {
                sb.Append(string.Format(" AND a.doc_type Like '%{0}%'", objTe.doc_type));
            }
            if (objTe.test_dept != "")
            {
                sb.Append(string.Format(" AND a.test_dept='{0}'", objTe.test_dept));
            }
            if(objTe.is_display_expiry_date !="")
            {
                sb.Append(" AND (a.expiry_date>CONVERT(date,GETDATE(),120) OR a.expiry_date IS NULL)");
            }
            if (objTe.crusr != "")
            {
                sb.Append(string.Format(" AND a.crusr='{0}'", objTe.crusr));
            }
            if (objTe.invoice_id != "")
            {
                sb.Append(string.Format(" AND a.invoice_id='{0}'", objTe.invoice_id));
            }
            //空日期的判斷 DateTime數據類型空時0001-01-01
            if (DateTime.Parse(objTe.crtim.ToString()).Date.ToString("yyyy-MM-dd")!="0001-01-01")
            {
                sb.Append(string.Format(" AND a.crtim>='{0}'", objTe.crtim.ToString("yyyy-MM-dd")));
            }
            if (DateTime.Parse(objTe.amtim.ToString()).Date.ToString("yyyy-MM-dd") != "0001-01-01")
            {     
                sb.Append(string.Format(" AND a.crtim<'{0}'", DateTime.Parse(objTe.amtim.ToString("yyyy-MM-dd")).Date.AddDays(1).ToString("yyyy-MM-dd")));
            }
            sb.Append(" ORDER BY a.test_report_no,a.mat_id,a.seq_id");

            dtTe = clsPublicOfCF01.GetDataTable(sb.ToString());

            if (dtTe.Rows.Count > 0)
            {
                DataTable dtTestItem = GetTestItemForLue();
                for (int i = 0; i < dtTe.Rows.Count; i++)
                {
                    DataRow[] dr = dtTestItem.Select(string.Format("test_item_id='{0}'", dtTe.Rows[i]["test_item_id"]));
                    if (dr.Length > 0)
                    {
                        dtTe.Rows[i]["Test_item_cdesc"] = dr[0]["test_item_cdesc"].ToString();
                    }
                }
            }
            return dtTe;
        }

        public static int GetMaxSeqForTe(string pMat_id)
        {
            int MaxSeq_id = 0;
            string strSql = String.Format(@"SELECT MAX(seq_id) FROM bs_test_excel WHERE mat_id='{0}'", pMat_id);
            string strResult = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            if (strResult != "")
            {
                MaxSeq_id = Convert.ToInt32(strResult);
            }
            return MaxSeq_id;
        }

        /// <summary>
        /// 編輯更新GEO 客人產品測試標準表（cd_customer_test_details）
        /// 如果TEST EXCEL中新增或編輯時，對應頁數、對應測試項目中的測試報告或有效期發生變化時
        /// 執行此功能進檢查幷更新
        /// </summary>
        /// <param name="TestItem_id"></param>
        /// <param name="Test_Report_no"></param>
        /// <param name="Expiry_date"></param>
        /// <param name="Ref_no"></param>
        /// <returns></returns>
        public static int UpdateCustProdcutTestStand(string TestItem_id, string Test_Report_no,string Test_report_path,string Expiry_date, string Ref_mo)
        {
            int Result = 0;

            if (IsUpdate(TestItem_id, Test_Report_no, Expiry_date, Ref_mo))
            {
                string strSql = "";
                SqlParameter[] paras = null;
                if (string.IsNullOrEmpty(Expiry_date))
                {
                    strSql = @"UPDATE cd_customer_test_details SET test_report_no=@test_report_no,test_report_path=@test_report_path 
                               WHERE test_item_id=@test_item_id AND ref_mo=@ref_mo";
                    paras = new SqlParameter[] { 
                       new SqlParameter("@test_report_no",Test_Report_no),
                       new SqlParameter("@test_report_path",Test_report_path),
                       new SqlParameter("@test_item_id",TestItem_id),
                       new SqlParameter("@ref_mo",Ref_mo)
                    };
                }
                else
                {
                    strSql = @"UPDATE cd_customer_test_details SET test_report_no=@test_report_no,test_report_path=@test_report_path,effect=@effect 
                               WHERE test_item_id=@test_item_id AND ref_mo=@ref_mo";
                    paras = new SqlParameter[] { 
                       new SqlParameter("@test_report_no",Test_Report_no),
                       new SqlParameter("@test_report_path",Test_report_path),
                       new SqlParameter("@effect",Expiry_date),
                       new SqlParameter("@test_item_id",TestItem_id),
                       new SqlParameter("@ref_mo",Ref_mo)
                    };
                }

                Result = clsConErp.ExecuteNonQuery(strSql, paras, false);
            }
            return Result;
        }

        public static bool IsUpdate(string TestItem_id, string Test_Report_no, string Expiry_date, string Ref_mo)
        {
            bool IsDo = false;
            string strSql = String.Format(@"SELECT test_report_no ,effect FROM cd_customer_test_details 
                                            WHERE test_item_id='{0}' AND ref_mo='{1}'", TestItem_id, Ref_mo);
            DataTable dtCustProdTestStd = clsConErp.GetDataTable(strSql);

            if (dtCustProdTestStd.Rows.Count > 0)
            {
                string strEffect = (dtCustProdTestStd.Rows[0]["effect"]).ToString();
                string strTest_report_no = dtCustProdTestStd.Rows[0]["test_report_no"].ToString();
                if (!string.IsNullOrEmpty(strEffect) && !string.IsNullOrEmpty(strTest_report_no))
                {
                    strEffect = Convert.ToDateTime(strEffect).ToString("yyyy-MM-dd");
                    if (strTest_report_no != Test_Report_no || strEffect != Expiry_date)
                    {
                        IsDo = true;
                    }
                }
                else
                {
                    IsDo = true;
                }
            }
            return IsDo;
        }


        #endregion


        #region 初始化各類別的下拉列表框
        //設置牌子類別
        public static void SetBrandType(LookUpEdit objLookUpEdit)
        {
            DataTable dtCust_Brand_type = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' '+cdesc AS cdesc,edesc FROM dbo.bs_test_cust_product");
            SetTypeDropValue(dtCust_Brand_type, objLookUpEdit);
        }

        //設置顏色類別
        public static void SetColorType(LookUpEdit objLookUpEdit)
        {
            DataTable dtColor = clsPublicOfCF01.GetDataTable(@"SELECT id,id +' ('+ cdesc+')' AS cdesc,edesc FROM dbo.bs_test_color_category");
            SetTypeDropValue(dtColor, objLookUpEdit);
        }
        //測試機構
        public static void SetTestDept(LookUpEdit objLookUpEdit)
        {
            DataTable dtColor = clsPublicOfCF01.GetDataTable(@"SELECT typ_cdesc as id,typ_cdesc as cdesc FROM dbo.bs_type where typ_group='ZD' ORDER BY typ_code");
            SetTypeDropValue(dtColor, objLookUpEdit);
        }
        //設置原材料類別
        public static void SetMatType(LookUpEdit objLookUpEdit)
        {
            DataTable dtMat = clsPublicOfCF01.GetDataTable(@"SELECT id,id +' ('+ name+')' as cdesc,isnull(name_english,'') as edesc FROM dbo.bs_test_mat_type");
            SetTypeDropValue(dtMat, objLookUpEdit);
        }
        //設置PVH,VFA類別
        public static void SetPvhType(LookUpEdit objLookUpEdit,string pStr)
        {
            DataTable dtMat = clsPublicOfCF01.GetDataTable(string.Format(@"SELECT cdesc AS id,cdesc,edesc FROM dbo.bs_test_type WHERE id='{0}'",pStr));
            SetTypeDropValue(dtMat, objLookUpEdit);
        }        
        //設置產品類別
        public static void SetProductType(LookUpEdit objLookUpEdit)
        {
            DataTable dtProduct_type = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc,isnull(edesc,'') as edesc FROM dbo.bs_test_product_type");
            SetTypeDropValue(dtProduct_type, objLookUpEdit);
        }

        /// <summary>
        /// 綁定測試類型
        /// </summary>
        /// <param name="objLookUpEdit"></param>
        public static void SetTestType(LookUpEdit objLookUpEdit)
        {
            DataTable dtType = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc,edesc FROM bs_test_type ");
            SetTypeDropValue(dtType, objLookUpEdit);
        }

        /// <summary>
        /// 綁定測試項目--dgsql2
        /// </summary>
        /// <param name="objLookUpEdit"></param>
        public static void SetTestItem(LookUpEdit objLookUpEdit)
        {
            DataTable dtType = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc,edesc FROM dbo.bs_test_item");
            SetTypeDropValue(dtType, objLookUpEdit);
        }

        /// <summary>
        /// 設置分類
        /// </summary>
        /// <param name="objLookUpEdit"></param>
        public static void SetType(LookUpEdit objLookUpEdit)
        {
            DataTable dtTest_type = clsPublicOfCF01.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc,isnull(edesc,'') as edesc FROM dbo.bs_test_type");
            SetTypeDropValue(dtTest_type, objLookUpEdit);
        }

        /// <summary>
        /// 設置測試項目編號--dgerp2
        /// </summary>
        /// <param name="objLookUpEdit"></param>        
        public static void SetTest_item(LookUpEdit objLookUpEdit)
        {
            DataTable dtTest_item = new DataTable();
            //DataTable dtTest_item =DBUtility.GetDataTable(@"SELECT id,id+' ('+cdesc+')' AS cdesc,edesc FROM dbo.bs_test_item");           
            try
            {
                string strSql = @"SELECT test_item_id as id,test_item_id+'('+test_item_name+')' as cdesc,english_name as edesc FROM dbo.cd_qc_test_item";

                dtTest_item = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetTypeDropValue(dtTest_item, objLookUpEdit);
        }

        public static void SetTypeDropValue(DataTable Pdtbl, LookUpEdit PLookUpEdit)
        {
            DataRow dr0 = Pdtbl.NewRow(); //插一空行        
            Pdtbl.Rows.InsertAt(dr0, 0);
            // LookUpEdit objType = (LookUpEdit)PLookUpEdit;
            PLookUpEdit.Properties.DataSource = Pdtbl;
            PLookUpEdit.Properties.ValueMember = "id";
            PLookUpEdit.Properties.DisplayMember = "cdesc";
        }
        #endregion

        /// <summary>
        /// 取測試報告公共目彔路徑
        /// </summary>
        /// <returns></returns>
        public static string Get_Test_Public_Path()
        {
            string user_id_group = "";
            //string strSql = string.Format("Select RIGHT(rname,1) as sales_group From v_user_sales_group Where uname='{0}'", DBUtility._user_id);
            //user_id_group = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            //if (user_id_group == "W")
            //{
            //    user_id_group = "E";
            //}            
            ////Regex regChina = new Regex("^[^-\xFF]");//是中文
            ////Regex regNum = new Regex("^[0-9]");//數字
            //System.Text.RegularExpressions.Regex regLetter = new System.Text.RegularExpressions.Regex("^[a-zA-Z]+"); //否为字母组成
            //if (!regLetter.IsMatch(user_id_group))
            //{
            //    user_id_group = "";
            //}  
            string strSql = string.Format("select isnull(user_group,'') as user_group from dbo.tb_sy_user Where uname='{0}'", DBUtility._user_id);
            user_id_group = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            if (user_id_group == "W")
            {
                user_id_group = "E";
            }
            //======================================
            //目前有V組與E組，大家存放的位置不同，所以必須增加組別進行區分
            string public_path = "";
            DataTable dtPath = clsPublicOfCF01.GetDataTable(String.Format("SELECT test_report_path FROM dbo.bs_company WHERE id ='{0}'", user_id_group));
            if (dtPath.Rows.Count > 0)
            {
                public_path = dtPath.Rows[0]["test_report_path"].ToString();
                if (public_path == null)
                    public_path = "";
            }
            else
                public_path = "";
            return public_path;

        }

        /// <summary>
        /// 返回路徑列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Test_Report_Path()
        {
            DataTable dtPath = clsPublicOfCF01.GetDataTable("SELECT test_report_path FROM dbo.bs_company");
            return dtPath;
        }


        /// <summary>
        /// 打開測試報告PDF文件
        /// </summary>
        /// <param name="strFile"></param>
        public static void Open_test_pdf(string strFile)
        {
            if (!string.IsNullOrEmpty(strFile))
            {
                if (System.IO.File.Exists(@strFile))
                {
                    System.Diagnostics.Process.Start(strFile);
                }
            }

        }


        public static bool Open_Test_Report(string strFile,DataTable dtPathList,string oprType)
        {
            bool Result = false;
            //打開測試報告          
            if (!string.IsNullOrEmpty(strFile))
            {
                bool isExists = false;
                string strFullPath="" ;
                for (int i = 0; i < dtPathList.Rows.Count; i++)
                {                    
                    strFullPath = dtPathList.Rows[i][0] + strFile.Trim();                    
                    if (System.IO.File.Exists(@strFullPath))
                    {
                        isExists = true;
                        break;
                    }
                }

                if (isExists)
                {
                    //frmProgress wForm = new frmProgress();
                    //new Thread((ThreadStart)delegate
                    //{
                    //    wForm.TopMost = true;
                    //    wForm.ShowDialog();
                    //}).Start();
                    if (oprType == "OPEN")
                    {
                        Result = true;
                        //************************
                        System.Diagnostics.Process.Start(strFullPath);
                        //************************
                        //wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                    }
                    else
                    {
                        System.Collections.Specialized.StringCollection strcoll = new System.Collections.Specialized.StringCollection(); //收集路径

                        strcoll.Add(strFullPath);

                        //strcoll.Add(dirPath);

                        Clipboard.SetFileDropList(strcoll);//将要复制的文件货文件夹路径放入剪切板
                        Result = true;
                    }
                }
                else
                {
                    MessageBox.Show("原始檔案不存在!", "提示信息");
                }
            }
            return Result;
        }

        public static DataTable Get_test_expriy(int pMonths,string pSalesGroup)
        {
           SqlParameter[] paras = new SqlParameter[]{ 
               new SqlParameter("@months",pMonths),
               new SqlParameter("@group",pSalesGroup)
           };
           DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_test_report_expire", paras);
           return dt;
        }

        public static int Is_Exists_Invoice(string report_no)
        {
            int result=0 ;
            string sql_f = String.Format(@"SELECT '1' FROM bs_test_invoice_details WHERE id='{0}'", report_no);
            if (clsPublicOfCF01.ExecuteSqlReturnObject(sql_f) == "")
                result = 0;
            else
                result = 1;
            return result;
        }



    }
}
