using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using cf01.MDL;
using cf01.ModuleClass;


namespace cf01.CLS
{
    public class clsQueryValue
    {
        /// <summary>
        /// 保存或更新user 查詢條件
        /// </summary>
        /// <param name="lsQueryValue"></param>
        /// <returns></returns>
        public static int AddOrUpdateQueryValue(List<mdlQueryValue> lsQueryValue)
        {
            int Result = 0;
            try
            {
                string strSql = "";
                DataTable dtIsExist = GetQueryValue(lsQueryValue[0].formname, DBUtility._user_id);
                if (dtIsExist.Rows.Count > 0)
                {
                    for (int i = 0; i < lsQueryValue.Count; i++)
                    {
                        strSql += string.Format(@"UPDATE tb_sy_object_value SET obj_value='{0}', amusr='{1}', amtim=GETDATE() 
                                                  WHERE formname='{2}' AND login_user='{3}' AND obj_id='{4}' ",
                                                lsQueryValue[i].obj_value, lsQueryValue[i].amusr,
                                                lsQueryValue[i].formname, lsQueryValue[i].login_user, lsQueryValue[i].obj_id);
                    }
                }
                else
                {
                    for (int i = 0; i < lsQueryValue.Count; i++)
                    {
                        strSql += string.Format(@"INSERT INTO tb_sy_object_value(formname, obj_id, login_user,value_type ,obj_value, crusr, crtim) 
                                                  VALUES('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE()) ",
                                                         lsQueryValue[i].formname, lsQueryValue[i].obj_id, lsQueryValue[i].login_user, lsQueryValue[i].value_type,lsQueryValue[i].obj_value,
                                                         lsQueryValue[i].crusr);
                    }
                }
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, null, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 根據form 名稱和用戶ID，獲取用戶的查詢條件
        /// </summary>
        /// <param name="pformName"></param>
        /// <param name="pUserId"></param>
        /// <returns></returns>
        public static DataTable GetQueryValue(string pFormName, string pUserId)
        {
            DataTable dtValue = new DataTable();
            try
            {
                string strSql = @" SELECT  formname, obj_id, login_user, value_type, obj_value, crusr, crtim, amusr, amtim 
                                   FROM tb_sy_object_value
                                   WHERE formname='" + pFormName + "' AND login_user='" + pUserId + "' ";
                dtValue = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtValue;
        }

    }
}
