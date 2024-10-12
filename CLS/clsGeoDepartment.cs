using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace cf01.CLS
{
    public class clsGeoDepartment
    {
        public static DataTable getDepartment()
        {
            string ls_sql = string.Format(@"Select id,name as cdesc From {0}cd_department
                            Where LEN(id) between 3 and 4 and state='0' order by id", DBUtility.remote_db);
            DataTable dt = clsPublicOfCF01.GetDataTable(ls_sql);
            return dt;
        }
    }
}
