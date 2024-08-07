﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace cf01.ModuleClass
{
    //获取功能类
    class Grant
    {

        public static DataRow[] getGrant(string lang, string name, string pwd)
        {
            DataTable dt = new DataTable();
            string strSQL = String.Format("Select * From view_1 Where lang= '{0}' Order By gid_sort", lang);
            dt = CLS.clsPublicOfCF01.GetDataTable(strSQL);

            //筛选出这个用户所在的角色的所有的权限
            //DataRow[] drArr = dt.Select(string.Format("Uname='{0}' and Pwd='{1}'", name, pwd));
            DataRow[] drArr = dt.Select(string.Format("Uname='{0}'", name));
            return drArr;
        }

        public static DataTable getAllGrant(string lang, string name)
        {
            DataTable dt = new DataTable();
            string strSQL = String.Format("Select * From view_1 Where Uname = '{0}' And lang = '{1}' Order By gid_sort", name, lang);
            dt = CLS.clsPublicOfCF01.GetDataTable(strSQL);
            return dt;
        }
    }
}
