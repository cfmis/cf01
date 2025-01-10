using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsMouldPosition
    {       
        public static DataTable GetEmptyStrutre()
        {           
            DataTable dt = clsPublicOfCF01.GetDataTable(string.Format(
            @"Select a.id,a.dept_id,b.name as dept_name,a.pattern_id,a.mould_no,a.products_type,c.name as products_type_name,
            a.mould_name,a.measurement,d.name as size_name,a.out_qty,a.mould_type,e.name as mould_type_name,a.state,Convert(int,a.mould_qty) as mould_qty,
            a.remark,a.maintenance_repair_content,a.mould_production_date,a.create_by,a.create_date,a.update_by,a.update_date
            From {0}cd_mould_position a 
            INNER JOIN {0}cd_department b on a.within_code=b.within_code and a.dept_id=b.id
            INNER JOIN {0}cd_goods_class c on a.within_code=c.within_code and a.products_type=c.id
            INNER JOIN {0}cd_size d on a.within_code=d.within_code and a.measurement=d.id
            LEFT JOIN {0}cd_mo_type e on a.within_code=e.within_code and a.mould_type=e.id and e.mo_type='P'
            WHERE a.state<>'2'
            ORDER BY a.dept_id,a.mould_no,a.id", DBUtility.remote_db));           
            return dt;
        }

        public static DataTable FindData(string id,string dept_id,string mould_no,string pattern_id, string products_type,string measurement)
        {
            string sql= string.Format(
            @"Select a.id,a.dept_id,b.name as dept_name,a.pattern_id,a.mould_no,a.products_type,c.name as products_type_name,
            a.mould_name,a.measurement,d.name as size_name,a.out_qty,a.mould_type,e.name as mould_type_name,a.state,Convert(int,a.mould_qty) as mould_qty,
            a.remark,a.maintenance_repair_content,a.mould_production_date,a.create_by,a.create_date,a.update_by,a.update_date
            From {0}cd_mould_position a 
            INNER JOIN {0}cd_department b on a.within_code=b.within_code and a.dept_id=b.id
            INNER JOIN {0}cd_goods_class c on a.within_code=c.within_code and a.products_type=c.id
            INNER JOIN {0}cd_size d on a.within_code=d.within_code and a.measurement=d.id
            LEFT JOIN {0}cd_mo_type e on a.within_code=e.within_code and a.mould_type=e.id and e.mo_type='P'
            WHERE a.within_code='{1}'", DBUtility.remote_db,"0000");
            if (id != "")
            {
                sql += string.Format(" And a.id LIKE '%{0}%'", id);
            }
            if (dept_id != "")
            {
                sql += string.Format(" And a.dept_id='{0}'", dept_id);
            }
            if (mould_no != "")
            {
                sql += string.Format(" And a.mould_no LIKE '%{0}%'", mould_no);
            }
            if (pattern_id != "")
            {
                sql += string.Format(" And a.pattern_id LIKE '%{0}%'", pattern_id);
            }
            if (products_type != "")
            {
                sql += string.Format(" And a.products_type='{0}'", products_type);
            }
            if (measurement != "")
            {
                sql += string.Format(" And a.measurement='{0}'", measurement);
            }
            sql += " And a.state<>'2'  ORDER BY a.dept_id,a.mould_no,a.id ";
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            return dt;
        }

        public static string DelData(string id, string dept_id, string mould_no)
        {
            string result = "";
            string sql_u = string.Format(
            @"Update {0}cd_mould_position SET state='2' WHERE within_code='{1}' and id='{2}' and dept_id='{3}' and mould_no='{4}'",
            DBUtility.remote_db, "0000", id, dept_id, mould_no);
            result = clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
            return result;
        }

        public static string UpdatePosition(string id, string dept_id, string mould_no,string new_id)
        {
            string result = "";
            string sql_u = string.Format(
            @"UPDATE {0}cd_mould_position SET id='{5}',update_date=getdate(),update_by='{6}'           
            WHERE within_code='{1}' And id='{2}' And dept_id='{3}' And mould_no='{4}'",DBUtility.remote_db,"0000",id, dept_id, mould_no, new_id, DBUtility._user_id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
            return result;
        }
       

    }
}
