using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsMmCalculatePrice
    {
        private static string userid = DBUtility._user_id.ToUpper();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        public static string updateMmCalculatePrice(int upd_flag, mdlMmCalculatePriceHead mdlHead, List<mdlMmCalculatePriceDetails> mdlDetails)
        {
            string result = "";
            string strSql = "";
            string id=mdlHead.id;
            int ver = mdlHead.ver;
            if (upd_flag == 2)//如果是新版本的，則獲取最大版本號
            {
                ver = getIdVer("Max",id);
            }
            if (!checkExistId(id, ver))//新增
            {
                if (upd_flag == 0)
                {
                    string dat = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    ver = 0;
                    id = "P-" + dat.Substring(0, 4) + dat.Substring(5, 2) + dat.Substring(8, 2) + dat.Substring(11, 2) + dat.Substring(14, 2) + dat.Substring(17, 2);
                }
                strSql = string.Format(@"INSERT INTO mm_calculate_price_head (id,ver,cdesc,offer_price,price_bp,qtno,total_a,total_a1,total_b,total_c1,total_c2,total_c3,total_c4,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',GETDATE())"
                        , id, ver, mdlHead.cdesc, mdlHead.offer_price, mdlHead.price_bp, mdlHead.qtno, mdlHead.total_a, mdlHead.total_a1, mdlHead.total_b, mdlHead.total_c1, mdlHead.total_c2
                        , mdlHead.total_c3, mdlHead.total_c4, userid);
            }
            else
            {
                if (upd_flag == 3)//如果是刪除操作且為最後一筆記錄，則同時刪除主表的記錄
                    strSql += string.Format(@"Delete From mm_calculate_price_head Where id='{0}' And ver='{1}'", id, ver);
                else//不然就更新主表的結果
                    strSql = string.Format(@"UPDATE mm_calculate_price_head SET cdesc='{0}',offer_price='{1}',price_bp='{2}',qtno='{3}',total_a='{4}',total_a1='{5}',total_b='{6}',total_c1='{7}'
                    ,total_c2='{8}',total_c3='{9}',total_c4='{10}',amusr='{11}',amtim=GETDATE()
                    WHERE id='{12}' And ver='{13}'"
                        , mdlHead.cdesc, mdlHead.offer_price, mdlHead.price_bp, mdlHead.qtno, mdlHead.total_a, mdlHead.total_a1, mdlHead.total_b, mdlHead.total_c1, mdlHead.total_c2, mdlHead.total_c3
                        , mdlHead.total_c4, userid, id, ver);
            }
            if (upd_flag == 0 || upd_flag == 2)//新增、修改、新版本
            {
                int max_seq = getMaxSeq(id, ver);
                int seq_add = 1;
                for (int i = 0; i < mdlDetails.Count; i++)
                {
                    string seq = mdlDetails[i].seq;
                    if (seq == "")
                    {
                        seq = (max_seq + seq_add).ToString().PadLeft(3, '0');
                        seq_add = seq_add + 1;
                    }
                    if (!checkExistIdSeq(id, ver, seq))//新增
                        strSql += string.Format(@"INSERT INTO mm_calculate_price_details (id,ver,seq,cdesc,mo_id,mat_type,prd_type,art,size,clr,formula_id,number_a,rate_a,number_b,result_a,result_a1,number_c,number_d,rate_d
                    ,number_e,result_b,number_f,number_g,result_c1,result_c2,result_c3,result_c4,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'
                        ,'{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}',GETDATE())"
                            , id, ver, seq, mdlDetails[i].cdesc, mdlDetails[i].mo_id, mdlDetails[i].mat_type, mdlDetails[i].prd_type, mdlDetails[i].art, mdlDetails[i].size, mdlDetails[i].clr, mdlDetails[i].formula_id
                            , mdlDetails[i].number_a, mdlDetails[i].rate_a, mdlDetails[i].number_b, mdlDetails[i].result_a, mdlDetails[i].result_a1, mdlDetails[i].number_c, mdlDetails[i].number_d, mdlDetails[i].rate_d
                            , mdlDetails[i].number_e, mdlDetails[i].result_b, mdlDetails[i].number_f, mdlDetails[i].number_g, mdlDetails[i].result_c1, mdlDetails[i].result_c2, mdlDetails[i].result_c3
                            , mdlDetails[i].result_c4, userid);
                    else
                        strSql += string.Format(@"UPDATE mm_calculate_price_details SET cdesc='{0}',number_a='{1}',rate_a='{2}',number_b='{3}',result_a='{4}',result_a1='{5}',number_c='{6}'
                    ,number_d='{7}',rate_d='{8}',number_e='{9}',result_b='{10}',number_f='{11}',number_g='{12}',result_c1='{13}',result_c2='{14}',result_c3='{15}'
                    ,result_c4='{16}',amusr='{17}',amtim=GETDATE(),mat_type='{18}',prd_type='{19}',art='{20}',size='{21}',clr='{22}',mo_id='{23}',formula_id='{24}'
                    WHERE id='{25}' And ver='{26}' And seq='{27}'"
                            , mdlDetails[i].cdesc, mdlDetails[i].number_a, mdlDetails[i].rate_a, mdlDetails[i].number_b, mdlDetails[i].result_a, mdlDetails[i].result_a1, mdlDetails[i].number_c, mdlDetails[i].number_d
                            , mdlDetails[i].rate_d, mdlDetails[i].number_e, mdlDetails[i].result_b, mdlDetails[i].number_f, mdlDetails[i].number_g
                            , mdlDetails[i].result_c1, mdlDetails[i].result_c2, mdlDetails[i].result_c3, mdlDetails[i].result_c4, userid, mdlDetails[i].mat_type, mdlDetails[i].prd_type
                            , mdlDetails[i].art, mdlDetails[i].size, mdlDetails[i].clr, mdlDetails[i].mo_id, mdlDetails[i].formula_id, id, ver, seq);
                }
            }
            else//刪除
                strSql += string.Format(@"Delete From mm_calculate_price_details Where id='{0}' And ver='{1}' And seq='{2}'", id, mdlDetails[0].ver, mdlDetails[0].seq);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = id;
            else
                result = "";

            return result;
        }
        public static string updateMmCalculatePriceDetails(int upd_flag, mdlMmCalculatePriceDetails mdlDetails)
        {
            string result = "";
            string strSql = "";

            
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);


            return result;
        }
        public static bool checkExistId(string id,int ver)
        {
            string strSql = " Select id From mm_calculate_price_head Where id='" + id + "' And ver='" + ver + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows.Count > 0)
                return true;
            return false;
        }
        //獲取最大版本號
        public static int getIdVer(string type,string id)
        {
            int ver = 0;
            string strSql = " Select Max(ver) As ver From mm_calculate_price_head Where id='" + id + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            ver=dtId.Rows[0]["ver"].ToString() != "" ? Convert.ToInt32(dtId.Rows[0]["ver"].ToString()) : 0;
            if (type == "Max")
                ver = ver + 1;
            return ver;
        }
        //獲取單號所有版本號
        public static DataTable loadIdVer(string id)
        {
            string strSql = " Select ver From mm_calculate_price_head Where id='" + id + "'";
            DataTable dtVer = clsPublicOfCF01.GetDataTable(strSql);
            return dtVer;
        }
        public static bool checkExistIdSeq(string id,int ver,string seq)
        {
            string strSql = " Select id From mm_calculate_price_details Where id='" + id + "' And ver='" + ver + "' And seq='" + seq + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows.Count > 0)
                return true;
            return false;
        }
        private static int getMaxSeq(string id,int ver)
        {
            int max_seq = 0;
            string strSql = " Select Max(seq) AS max_seq From mm_calculate_price_details Where id='" + id + "' And ver='" + ver + "'";
            DataTable dtSeq = clsPublicOfCF01.GetDataTable(strSql);
            if (dtSeq.Rows[0]["max_seq"].ToString() != "")
                max_seq = Convert.ToInt32(dtSeq.Rows[0]["max_seq"].ToString());
            return max_seq;
        }

        //提取計价公式
        public static DataTable getGoodsPriceFormula(string fid)
        {
            string strSql;
            strSql = "Select * from mm_goods_price_formula where id>=''";
            if (fid != "")
                strSql += " and  id='" + fid + "'";
            DataTable dtFormula = clsPublicOfCF01.GetDataTable(strSql);
            return dtFormula;
        }
        //按單號提取主表記錄
        public static DataTable loadHeadById(string id,int ver)
        {
            string strSql = "Select * from mm_calculate_price_head Where id='" + id + "' And ver='" + ver + "'";
            strSql += " order by id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //按單號提取明細表記錄
        public static DataTable loadDetailsById(string id,int ver)
        {
            string strSql = "Select *,' ' As status,Convert(Varchar(20),crtim,120) As crtim_long,Convert(Varchar(20),amtim,120) As amtim_long" +
                " from mm_calculate_price_details Where id='" + id + "' And ver='" + ver + "'";
            strSql += " order by id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        //查找制單編號生產流程
        public static DataTable findWipMo(string mo_id)
        {
            string strSql = "Select a.mo_id,b.sequence_id,b.goods_id,c.name As goods_cname,b.wp_id,d.name As wp_cdesc,b.next_wp_id,e.name As next_wp_cdesc"
                + ",Convert(numeric(18, 2),(b.c_sec_qty_ok/b.c_qty_ok)*1000) As k_weg_t,Convert(numeric(18, 2),(b.c_sec_qty_ok/b.c_qty_ok)*1000) As k_weg,Convert(Int,b.c_qty_ok) As ok_qty,Convert(numeric(18, 2),b.c_sec_qty_ok) As ok_weg"
                + " From " + remote_db + "jo_bill_mostly a"
                + " Inner Join " + remote_db + "jo_bill_goods_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver"
                + " Inner Join " + remote_db + "it_goods c On b.within_code=c.within_code And b.goods_id=c.id"
                + " Inner Join " + remote_db + "cd_department d On b.within_code=d.within_code And b.wp_id=d.id"
                + " Inner Join " + remote_db + "cd_department e On b.within_code=e.within_code And b.next_wp_id=e.id"
                + " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "'";
            strSql += " order by b.sequence_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            dt.Columns.Add("chk_flag", typeof(bool));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["chk_flag"] = false;
            }
            return dt;
        }
        //從報價單中根據單號提取產品資料
        public static DataTable loadQtNo(string id)
        {
            string strSql = "Select material,cf_code,size,cf_color,mo_id,number_enter From quotation Where temp_code='" + id + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //報價單號獲取編號
        public static String getIdByQuotationId(string qtno)
        {
            string result = "";
            string strSql = "Select id from mm_calculate_price_head Where qtno='" + qtno + "'";
             DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
             if (dt.Rows.Count > 0)
                 result = dt.Rows[0]["id"].ToString();
            return result;
        }
        public static DataTable findMmCalculatePrice(string id,string mo_id,string mat_type,string prd_type,string art,string size,string fid,string crusr,string crtim_from,string crtim_to
            ,string cdesc_d,string cdesc)
        {

            string strSql = " Select a.cdesc As cdesc_h,b.*,Convert(Varchar(20),b.crtim,120) As crtim_long,Convert(Varchar(20),b.amtim,120) As amtim_long" +
                " From mm_calculate_price_head a " +
                " Inner Join mm_calculate_price_details b On a.id=b.id And a.ver=b.ver" +
                " Where b.id>=''";
            if (id != "")
                strSql += " And a.id Like " + "'%" + id.Trim() + "%'";
            if (mo_id != "")
                strSql += " And b.mo_id Like " + "'%" + mo_id.Trim() + "%'";
            if (mat_type != "")
                strSql += " And b.mat_type Like " + "'%" + mat_type.Trim() + "%'";
            if (prd_type != "")
                strSql += " And b.prd_type Like " + "'%" + prd_type.Trim() + "%'";
            if (art!= "")
                strSql += " And b.art Like " + "'%" + art.Trim() + "%'";
            if (size != "")
                strSql += " And b.size Like " + "'%" + size.Trim() + "%'";
            if (fid != "")
                strSql += " And b.formula_id Like " + "'%" + fid.Trim() + "%'";
            if (crusr != "")
                strSql += " And b.crusr Like " + "'%" + crusr.Trim() + "%'";
            if (crtim_from != "" && crtim_to != "")
                strSql += " And b.crtim Between " + "'" + crtim_from.Trim() + "' And '" + crtim_to.Trim() + "'";
            if (cdesc_d!= "")
                strSql += " And b.cdesc Like " + "'%" + cdesc_d.Trim() + "%'";
            if (cdesc != "")
                strSql += " And a.cdesc Like " + "'%" + cdesc + "%'";
            strSql += " Order By a.id,a.ver Desc";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            return dtId;
        }
    }
}
