using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace cf01.CLS
{
    public class clsSales_group
    {
        public static DataTable Get_sales_group()
        {
            string strSql = @"Select typ_code AS id,typ_code+' ('+typ_cdesc+')' AS cdesc From bs_type Where typ_group='3'";
            DataTable dtGroup = clsPublicOfCF01.GetDataTable(strSql);
            return dtGroup;
        }

    }
}
