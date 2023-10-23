using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using cf01.MDL;

namespace cf01.CLS
{   

    public class clsDeliveryPrepare
    {
        //public clsPublicOfGEO clsDgerp2 = new clsPublicOfGEO();
        private string within_code = DBUtility.within_code;
        private string userid = DBUtility._user_id;

        public static DataTable GetIdList(st_delivery_find lst)
        {
            string strSql =string.Format(
            @"Select A.id,A.group_no,Convert(varchar(10),A.transfer_date,120) As transfer_date,B.mo_id 
            FROM {0}st_delivery_prepare A With(nolock), {0}st_delivery_prepare_detail B With(nolock)
            Where A.within_code=B.within_code And A.id=B.id ", DBUtility.remote_db);
            if (lst.id1 != "")
            {
                strSql += string.Format(" And A.id>='{0}'", lst.id1);
            }
            if (lst.id2 != "")
            {
                strSql += string.Format(" And A.id<='{0}'", lst.id2);
            }
            if (lst.group_no != "")
            {
                strSql += string.Format(" And A.group_no='{0}'", lst.group_no);
            }
            if (lst.transfer_date1 != "")
            {
                strSql += string.Format(" And A.transfer_date>='{0}'", lst.transfer_date1);
            }
            if (lst.transfer_date2 != "")
            {
                strSql += string.Format(" And A.transfer_date<='{0}'", lst.transfer_date2);
            }
            if (lst.create_by1 != "")
            {
                strSql += string.Format(" And A.create_by>='{0}'", lst.create_by1);
            }
            if (lst.create_by2 != "")
            {
                strSql += string.Format(" And A.create_by<='{0}'", lst.create_by2);
            }
            if (lst.id1 == "" && lst.id2 =="" && lst.group_no =="" && lst.transfer_date1 == "" && lst.transfer_date2 == ""
                &&lst.create_by1 == "" && lst.create_by2 == "" && lst.mo_id1 == "" && lst.mo_id2 == "")
            {
                strSql += string.Format(" And A.create_by='{0}'", DBUtility._user_id);
            }
            if (lst.mo_id1 != "")
            {
                strSql += string.Format(" And B.mo_id>='{0}'", lst.mo_id1);
            }
            if (lst.mo_id2 != "")
            {
                strSql += string.Format(" And B.mo_id<='{0}'", lst.mo_id2);
            }
            strSql += " Order by A.create_date Desc";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        public static string GetCurrentUserMaxId()
        {
            string result = "";
            string strSql = string.Format(
                @"Select top 1 A.id
                FROM {0}st_delivery_prepare A With(nolock),{0}st_delivery_prepare_detail B With(nolock)
                Where A.within_code=B.within_code And A.id=B.id And A.create_by='{1}'
                Order by A.create_date Desc", DBUtility.remote_db,DBUtility._user_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["id"].ToString();
            }
            return result;
        }

        public static int Save(st_delivery_prepare delivery_h, List<st_delivery_prepare_detail> lstDetails)
        {           
            string sql_update_h ="", sql_insert_d = "", seq_id = "";
            int iSeqId = 0, result = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(@" SET XACT_ABORT ON ");
            sb.Append(@" BEGIN TRANSACTION ");            
            if (delivery_h.row_status == "EDIT")
            {
                //在原有追貨紙上添加
                //查找最原有的最大序號
                string strSql = string.Format(
                @"Select Max(sequence_id) As sequence_id FROM {0}st_delivery_prepare_detail Where within_code='0000' and id='{1}'",DBUtility.remote_db, delivery_h.id);
                DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
                string seq_max_id = dt.Rows[0]["sequence_id"].ToString();               
                iSeqId = int.Parse(seq_max_id.Substring(0, 4)); //當前最大序號
                sql_update_h = string.Format(
                @" Update st_delivery_prepare SET update_by='{0}',update_date=GETDATE() WHERE id='{1}' And within_code='0000'",DBUtility._user_id, delivery_h.id);
                sb.Append(sql_update_h);
            }
            else
            {                
                //start 更新系統表最大單據號
                string sql_update_bill_code = string.Empty;
                string id = delivery_h.id;
                id = id.Substring(3);
                if (id == "000000001")//第一張單
                {
                    //Z-C000000001                   
                    sql_update_bill_code = string.Format(
                    @" Insert Into sys_bill_max_separate(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5)
                       Values('0000','DP01','','{0}','','{1}','','','')", delivery_h.id, delivery_h.group_no);
                }
                else
                {
                    //Z-C000002429
                    sql_update_bill_code = string.Format(
                    @" Update sys_bill_max_separate SET bill_code='{0}' Where within_code='0000' And bill_id='DP01' And year_month='' And bill_text2='{1}'",
                     delivery_h.id, delivery_h.group_no);
                }                 
                sb.Append(sql_update_bill_code);
                //end 更新系統表最大單據號

                //添加新的追貨紙
                sql_update_h = string.Format(
                   @" Insert into st_delivery_prepare (within_code,id,transfer_date,handler,state,transfers_state,update_count,group_no,create_by,create_date) 
                   Values('0000','{0}','{1}','{2}','0','0','1','{3}','{4}',getdate())",
                   delivery_h.id, delivery_h.transfer_date,DBUtility._user_id, delivery_h.group_no, DBUtility._user_id);
                sb.Append(sql_update_h);
            }
           
            int i = 0;
            foreach (st_delivery_prepare_detail dr in lstDetails)
            {
                i += 1;
                if (delivery_h.row_status == "EDIT")
                {
                    seq_id = (iSeqId + i).ToString().PadLeft(4,'0') + "h";
                }
                else
                {
                    seq_id = i.ToString().PadLeft(4,'0') + "h";
                }
                sql_insert_d = string.Format(
                @" Insert Into st_delivery_prepare_detail(within_code,id,sequence_id,goods_id,goods_name,plan_qty,move_qty,base_unit,mo_id,up_deptment,state) 
                   Values ('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}','{9}','0')", 
                "0000", dr.id, seq_id, dr.goods_id, dr.goods_name, dr.plan_qty, dr.move_qty, dr.base_unit, dr.mo_id, dr.up_deptment, dr.state);
                sb.Append(sql_insert_d);                
            }
                                         
            sb.Append(@" COMMIT TRANSACTION ");            
            clsPublicOfGEO clsConErp = new clsPublicOfGEO();
            result= clsConErp.ExecuteSqlUpdate(sb.ToString());
            sb.Clear();
            return result;
        }

        public static DataTable GetPrintData(string id,bool is_sort_by_mo)
        {
            string str_sort_by = "";
            if (is_sort_by_mo)
                str_sort_by = " b.mo_id";
            else
                str_sort_by = " b.sequence_id";
            string sql = string.Format(
            @"SELECT ROW_NUMBER() OVER(ORDER BY {2}) AS no, a.id,a.group_no,a.linkman,Isnull(a.department_id,'') AS ext_no,
            CASE WHEN a.transfer_date IS NULL Then '' ELSE CONVERT(varchar(10),a.transfer_date ,120) End AS transfer_date,b.mo_id,b.goods_id,b.goods_name,
            Cast(b.plan_qty as int) as plan_qty ,CAST(b.move_qty AS int) as move_qty,Cast(ISNULL(b.hk_qty,0) as int) AS hk_qty,
            b.base_unit,b.up_deptment,c.name as dept_name,CONVERT(VARCHAR(10),a.create_date,120) AS create_date,
            dbo.fn_get_picture_name_of_artwork('0000',substring(b.goods_id,5,7),'out') As picture_name
            From {0}st_delivery_prepare a 
	             INNER JOIN {0}st_delivery_prepare_detail b on a.within_code=b.within_code AND a.id=b.id
	             INNER JOIN {0}cd_department c on b.within_code=c.within_code AND b.up_deptment=c.id 
            WHERE a.id='{1}' AND a.within_code='0000' ORDER BY {2}", DBUtility.remote_db, id, str_sort_by);
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);            
            return dt;
        }
    }
}
