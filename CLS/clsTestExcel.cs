using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cf01.CLS
{
    public class clsTestExcel
    {
        /// <summary>
        /// 查找測試報告，如存在就打開
        /// </summary>
        /// <param name="cust_code"></param>
        /// <param name="cust_color"></param>
        /// <returns>返回測試報告路徑</returns>
        public static void Open_Test_Report(string cust_code, string cust_color)
        {
            if (!string.IsNullOrEmpty(cust_code))
            {
                string ls_sql = string.Format(
                @"Select Top 1 Isnull(test_report_path,'') as test_report_path 
                From dbo.bs_test_excel with(nolock) 
                Where trim_code='{0}' and finish_name='{1}'", cust_code, cust_color);                
                string strFile = clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql); 
                if (!string.IsNullOrEmpty(strFile))
                {
                   DataTable dtPath_List = clsTestProductPlan.Get_Test_Report_Path();
                   clsTestProductPlan.Open_Test_Report(strFile, dtPath_List,"OPEN");                                
                }
            }
        }
    }
}
