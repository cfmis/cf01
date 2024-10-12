using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.MDL;
using System.Data;

namespace cf01.CLS
{
    public class clsQuotationMoq
    {
        public static bool Save(string strEditState, mdlQuotationMoq mdlMoq, DataGridView dgrv, DataTable dtblDetail)
        {
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO quotation_moq(brand_id,moq_unit,moq,remark,create_by,create_date)
            VALUES(@brand_id,@moq_unit,@moq,@remark,@user_id,getdate())";
            const string sql_update =
            @"UPDATE quotation_moq SET moq=@moq,remark=@remark,update_by=@user_id,update_date=getdate()
            WHERE brand_id=@brand_id and moq_unit=@moq_unit";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    if (strEditState == "1") 
                    {
                        //新增狀態
                        myCommand.Parameters.Clear();
                        myCommand.CommandText = sql_new;
                        myCommand.Parameters.AddWithValue("@brand_id",mdlMoq.brand_id);
                        myCommand.Parameters.AddWithValue("@moq_unit", mdlMoq.moq_unit);
                        myCommand.Parameters.AddWithValue("@moq", mdlMoq.moq);
                        myCommand.Parameters.AddWithValue("@remark", mdlMoq.remark);
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                    }
                    else
                    {                       
                        //編號狀態
                        int intMoq=0;
                        myCommand.CommandText = sql_update;
                        for (int i = 0; i < dgrv.RowCount; i++)
                        {
                            if (dtblDetail.Rows[i].RowState == DataRowState.Modified)
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@brand_id", dgrv.Rows[i].Cells["brand_id"].Value.ToString());
                                myCommand.Parameters.AddWithValue("@moq_unit", dgrv.Rows[i].Cells["moq_unit"].Value.ToString());
                                if(string.IsNullOrEmpty(dgrv.Rows[i].Cells["moq"].Value.ToString()))
                                {
                                    intMoq=0;
                                }
                                else
                                {
                                    intMoq=int.Parse(dgrv.Rows[i].Cells["moq"].Value.ToString());
                                }
                                myCommand.Parameters.AddWithValue("@moq", intMoq);                                
                                myCommand.Parameters.AddWithValue("@remark", dgrv.Rows[i].Cells["remark"].Value.ToString());                                
                                myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                                myCommand.ExecuteNonQuery();
                                save_flag = true;
                            }
                            else
                            {
                                continue;
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
                    myTrans.Dispose();
                }
                
            }
            return save_flag;
        }

        /// <summary>
        /// delete current record
        /// </summary>
        /// <param name="strBrand"></param>
        /// <param name="strMoq_unit"></param>
        /// <returns></returns>
        public static bool Delete(string strBrand, string strMoq_unit)
        {
            bool isDelete;
            string strDel =string.Format(@"Delete FROM quotation_moq Where brand_id='{0}' and moq_unit='{1}'",strBrand,strMoq_unit);
            if (clsPublicOfCF01.ExecuteSqlUpdate(strDel) == "")
            {
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
            return isDelete;
        }

        /// <summary>
        /// 檢查主鍵是否已經存在
        /// </summary>
        /// <param name="strBrand"></param>
        /// <param name="strMoq_unit"></param>
        /// <returns></returns>
        public static bool Check_Is_Exists(string strBrand, string strMoq_unit)
        {
            bool isExists;
            string strSql = string.Format(@"SELECT '1' FROM quotation_moq Where brand_id='{0}' and moq_unit='{1}'", strBrand, strMoq_unit);
            if (clsPublicOfCF01.ExecuteSqlReturnObject(strSql) != "")
            {
                isExists = true;
            }
            else
            {
                isExists = false;
            }
            return isExists;
        }
    }
}
