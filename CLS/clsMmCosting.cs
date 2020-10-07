using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsMmCosting
    {
        private static string userid = DBUtility._user_id.ToUpper();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        public static string updateMmCosting(mdlMmCosting mdlCosting, List<mdlPlatePrice> mdlPlatePrices, List<mdlDepCharges> mdlDepCharges)
        {
            string result = "";
            string strSql = "";
            if (!checkExistId(mdlCosting.ID))
                strSql += string.Format(@"INSERT INTO mm_costing (ID,Cdesc,Prd_mo,MmCosting,MatWeg,MatWegG,MatPrice,MatPriceG,MatAmt
                    ,MatLossRate,MatLossAmt,PlatePrice,PlateLossRate
                    ,PlatePriceIncLoss,PlatePriceIncLossG,MatPlatePrice,DepCharges,FactoryChargesRate,ProfitMarginRate,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'
                        ,'{19}',GETDATE())"
                    , mdlCosting.ID, mdlCosting.Cdesc, mdlCosting.Prd_mo, mdlCosting.MmCosting, mdlCosting.MatWeg, mdlCosting.MatWegG, mdlCosting.MatPrice
                    , mdlCosting.MatPriceG, mdlCosting.MatAmt, mdlCosting.MatLossRate, mdlCosting.MatLossAmt, mdlCosting.PlatePrice, mdlCosting.PlateLossRate
                    , mdlCosting.PlatePriceIncLoss, mdlCosting.PlatePriceIncLossG, mdlCosting.MatPlatePrice, mdlCosting.DepCharges, mdlCosting.FactoryChargesRate
                    , mdlCosting.ProfitMarginRate, userid);
            else
                strSql += string.Format(@"UPDATE mm_costing SET Cdesc='{0}',Prd_mo='{1}',MmCosting='{2}',MatWeg='{3}',MatWegG='{4}',MatPrice='{5}',MatPriceG='{6}'
                    ,MatAmt='{7}',MatLossRate='{8}',MatLossAmt='{9}',PlatePrice='{10}',PlateLossRate='{11}',PlatePriceIncLoss='{12}',PlatePriceIncLossG='{13}'
                    ,MatPlatePrice='{14}',DepCharges='{15}',FactoryChargesRate='{16}',ProfitMarginRate='{17}',amusr='{18}',amtim=GETDATE()
                    WHERE id='{19}'"
                    , mdlCosting.Cdesc, mdlCosting.Prd_mo, mdlCosting.MmCosting, mdlCosting.MatWeg, mdlCosting.MatWegG, mdlCosting.MatPrice
                    , mdlCosting.MatPriceG, mdlCosting.MatAmt, mdlCosting.MatLossRate, mdlCosting.MatLossAmt, mdlCosting.PlatePrice, mdlCosting.PlateLossRate
                    , mdlCosting.PlatePriceIncLoss, mdlCosting.PlatePriceIncLossG, mdlCosting.MatPlatePrice, mdlCosting.DepCharges, mdlCosting.FactoryChargesRate
                    , mdlCosting.ProfitMarginRate, userid, mdlCosting.ID);

            //更新外發加工費用
            for (int i = 0; i < mdlPlatePrices.Count; i++)
            {
                if (!checkPlatePriceId(mdlPlatePrices[i].id, mdlPlatePrices[i].clr))
                    strSql += string.Format(@"INSERT INTO mm_costing_plate (id,clr,clr_cdesc,do_color,plateprice,remark,crusr,crtim)
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())"
                        , mdlPlatePrices[i].id, mdlPlatePrices[i].clr, mdlPlatePrices[i].clr_cdesc, mdlPlatePrices[i].do_color
                        , mdlPlatePrices[i].plateprice, mdlPlatePrices[i].remark, userid);
                else
                    strSql += string.Format(@"UPDATE mm_costing_plate SET clr_cdesc='{0}',do_color='{1}',plateprice='{2}',remark='{3}',amusr='{4}',amtim=GETDATE()
                        WHERE id='{5}' And clr='{6}'"
                        , mdlPlatePrices[i].clr_cdesc, mdlPlatePrices[i].do_color, mdlPlatePrices[i].plateprice, mdlPlatePrices[i].remark, userid
                        , mdlPlatePrices[i].id, mdlPlatePrices[i].clr);
            }
            //更新部門加工費用
            for (int i = 0; i < mdlDepCharges.Count; i++)
            {
                if (!checkDepChargesId(mdlDepCharges[i].id, mdlDepCharges[i].dep_id))
                    strSql += string.Format(@"INSERT INTO mm_costing_dep (id,dep_id,dep_charges,crusr,crtim)
                        VALUES ('{0}','{1}','{2}','{3}',GETDATE())"
                        , mdlDepCharges[i].id, mdlDepCharges[i].dep_id, mdlDepCharges[i].dep_charges, userid);
                else
                    strSql += string.Format(@"UPDATE mm_costing_dep SET dep_charges='{0}',amusr='{1}',amtim=GETDATE()
                        WHERE id='{2}' And dep_id='{3}'"
                        , mdlDepCharges[i].dep_charges, userid, mdlDepCharges[i].id, mdlDepCharges[i].dep_id);
            }
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static bool checkExistId(string id)
        {
            string strSql = "Select id From mm_costing Where id='" + id + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows.Count > 0)
                return true;
            return false;
        }
        public static bool checkPlatePriceId(string id,string clr)
        {
            string strSql = "Select id From mm_costing_plate Where id='" + id + "' And clr='" + clr + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows.Count > 0)
                return true;
            return false;
        }
        public static bool checkDepChargesId(string id, string dep_id)
        {
            string strSql = "Select id From mm_costing_dep Where id='" + id + "' And dep_id='" + dep_id + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows.Count > 0)
                return true;
            return false;
        }
        //提取OC資料
        public static DataTable getMoFromOc(string mo_id)
        {
            string strSql = "Select a.mo_id,a.goods_id,b.name As goods_cname" +
                " From " + remote_db + "so_order_details a" +
                " Left Join " + remote_db + "it_goods b On a.within_code=b.within_code And a.goods_id=b.id" +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "'";
            DataTable dtMoOc = clsPublicOfCF01.GetDataTable(strSql);
            return dtMoOc;
        }
        //提取外發加工資料op_outpro_out_mostly
        public static DataTable getMoOutProcess(string dep,string mo_id,string goods_id)
        {
            string strSql = "Select a.id,Convert(Varchar(20),a.issue_date,111) As issue_date,a.vendor_id,a.vendor" +
                ",b.sequence_id,b.mo_id,b.goods_id,b.prod_qty,b.sec_qty,Convert(Decimal(18,4),b.price) As price,Convert(Decimal(18,4),b.sec_price) As sec_price"+
                ",c.name As goods_cname,d.name As clr_cdesc,c.do_color,b.mould_fee,b.remark" +
                " From " + remote_db + "op_outpro_out_mostly a" +
                " Inner Join " + remote_db + "op_outpro_out_displace b On a.within_code=b.within_code And a.id=b.id" +
                " Inner Join " + remote_db + "it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                " Inner Join " + remote_db + "cd_color d On c.within_code=d.within_code And c.color=d.id" +
                " WHERE a.within_code='" + within_code + "' AND a.department_id='" + dep + "' AND b.mo_id='" + mo_id + "' AND b.goods_id='" + goods_id + "'" +
                " Order By a.issue_date Desc";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //電鍍加工費明細
        public static DataTable getCostPlateCharges(string id)
        {
            string strSql = "Select a.id,a.clr,a.clr_cdesc,a.do_color,a.remark,a.plateprice" +
                " From mm_costing_plate a" +
                " Where a.id='" + id + "'" +
                " Order By a.clr";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //部門加工費明細
        public static DataTable getCostDepCharges(string id)
        {
            string strSql = "Select a.id,a.dep_id,b.dep_cdesc,a.dep_charges" +
                " From mm_costing_dep a" +
                " Left Join bs_dep b On a.dep_id=b.dep_id" +
                " Where a.id='" + id + "'" +
                " Order By a.dep_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        public static DataTable getSpecPlate()
        {
            string strSql = "Select a.id,a.cdesc,a.plateprice" +
                " From mm_costing_plate_spec a" +
                " Order By a.id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //提取制單生產流程
        public static DataTable getWip(string mo_id)
        {
            string strSql = "Select a.id,a.mo_id" +
                ",b.sequence_id,b.goods_id,c.name As goods_cname,b.prod_qty,b.wp_id As dep_charges" +
                ",Convert(Int,b.c_qty_ok) As qty_ok,Convert(Decimal(18,2),b.c_sec_qty_ok) As weg_ok,b.wp_id,d.name As wp_cdesc,b.next_wp_id,e.name As next_wp_cdesc" +
                ",f.dep_charges As dep_std_charges" +
                " From " + remote_db + "jo_bill_mostly a" +
                " Inner Join " + remote_db + "jo_bill_goods_details b On a.within_code=b.within_code And a.id=b.id" +
                " Inner Join " + remote_db + "it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                " Inner Join " + remote_db + "cd_department d On b.within_code=d.within_code And b.wp_id=d.id" +
                " Inner Join " + remote_db + "cd_department e On b.within_code=d.within_code And b.next_wp_id=e.id" +
                " Left Join mm_costing_dep_charges f On c.base_class=f.id  COLLATE Chinese_PRC_CI_AS And b.wp_id=f.dep_id  COLLATE Chinese_PRC_CI_AS" +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "'" +
                " Order By b.sequence_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["dep_charges"] = "";
            }
            return dt;
        }
        //提取制單生產流程
        public static DataTable getMmData(string id)
        {
            string strSql = "Select a.id,a.name As goods_cname" +
                " From " + remote_db + "it_goods a" +
                " Where a.within_code='" + within_code + "' And a.id='" + id + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        public static DataTable findMmCosting(string id,string prd_mo)
        {
            string strSql = "Select a.*,b.name As goods_cname" +
                " From mm_costing a" +
                " Left join geo_it_goods b On a.id=b.id" +
                " Where a.id>=''";
            if (id != "")
                strSql += " And a.id Like'" + "%" + id + "%'";
            if (prd_mo != "")
                strSql += " And a.prd_mo Like'" + "%" + prd_mo + "%'";
            strSql += " Order By a.id";
            DataTable dtMmCosting = clsPublicOfCF01.GetDataTable(strSql);
            return dtMmCosting;
        }
        public static DataTable findOrderCosting(int type,string dat1,string dat2,string item1,string item2,string mo1,string mo2)
        {
            string strSql = "usp_CountOrderCosting";
            SqlParameter[] parameters = {new SqlParameter("@type", type)
                        ,new SqlParameter("@dat1", dat1)
                        ,new SqlParameter("@dat2", dat2)
                        ,new SqlParameter("@item1", item1)
                        ,new SqlParameter("@item2", item2)
                        ,new SqlParameter("@mo1", mo1)
                        ,new SqlParameter("@mo2", mo2)
                        };


            DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, parameters);
            return dt;
        }
        public static DataTable getBomPid(string pid)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,b.name AS goods_name " +
                " FROM " + remote_db + "it_bom_mostly a " +
                " LEFT JOIN " + remote_db + "it_goods b ON a.within_code=b.within_code  AND a.goods_id=b.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        public static DataTable getBomCid(string pid)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS d_goods_id,c.name AS goods_name,d.dept_id" +
                " FROM " + remote_db + "it_bom_mostly a" +
                " INNER JOIN " + remote_db + "it_bom b ON a.within_code=b.within_code AND a.id=b.id" +
                " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " LEFT JOIN " + remote_db + "it_bom_mostly d ON b.within_code=d.within_code AND b.goods_id=d.goods_id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'" +
                " Order By b.log_no";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        //從OC中獲取配件，當作BOM
        public static DataTable getBomFromOc(string mo_id, string pid)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,b.name AS goods_name " +
                " FROM " + remote_db + "so_order_details a " +
                " LEFT JOIN " + remote_db + "it_goods b ON a.within_code=b.within_code  AND a.goods_id=b.id" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "' AND a.goods_id='" + pid + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //從Wip中獲取配件，當作BOM
        public static DataTable getBomCidFromWip(string mo_id,string pid)
        {
            string strSql = "";
            strSql = " SELECT MAX(a.id) AS id,b.goods_id,MAX(a.id) AS d_id,c.materiel_id AS d_goods_id,d.name AS d_goods_name,MAX(b.wp_id) AS dept_id" +
                " FROM " + remote_db + "jo_bill_mostly a" +
                " INNER JOIN " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " INNER JOIN " + remote_db + "jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence" +
                " LEFT JOIN " + remote_db + "it_goods d ON c.within_code=d.within_code  AND c.materiel_id=d.id" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "' AND b.goods_id='" + pid + "'" +
                " Group By b.goods_id,c.materiel_id,d.name";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //從Wip中獲取生產部門
        public static DataTable getBomItemDepFromWip(string mo_id, string goods_id)
        {
            string strSql = "";
            strSql = " SELECT b.wp_id AS dept_id" +
                " FROM " + remote_db + "jo_bill_mostly a" +
                " INNER JOIN " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "' AND b.goods_id='" + goods_id + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        public static DataTable getBomDep(string id)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,c.name AS goods_cname,a.dept_id" +
                " FROM " + remote_db + "it_bom_mostly a" +
                " LEFT JOIN " + remote_db + "it_goods c ON a.within_code=c.within_code  AND a.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + id + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //從生產流程中提取
        public static DataTable getMatWeg(string mo_id,string dep_id,string goods_id)
        {
            string strSql = "Select a.id,a.mo_id,b.c_qty_ok,b.c_sec_qty_ok,Round(b.c_sec_qty_ok/b.c_qty_ok,4) AS weg_kg,Round((b.c_sec_qty_ok/b.c_qty_ok)*1000,4) AS weg_g" +
                " From " + remote_db + "jo_bill_mostly a" +
                " Inner Join " + remote_db + "jo_bill_goods_details b On a.within_code=b.within_code And a.id=b.id" +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "' And b.wp_id='" + dep_id + "' And b.goods_id='" + goods_id + "' And b.c_qty_ok>0" +
                " Order By b.sequence_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        //獲取Wip流程
        public static DataTable getWipRec(string mo_id)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.mo_id,b.sequence_id,b.goods_id,c.name AS goods_cname,b.flag,c.do_color,b.wp_id,b.next_wp_id,d.name As wp_cdesc,e.name As next_wp_cdesc" +
                ",Convert(INT,b.s_qty) AS s_qty,Convert(INT,b.prod_qty) AS prod_qty"+
                ",Convert(INT,b.obligate_qty) AS obligate_qty,Convert(INT,b.c_qty_ok) AS c_qty_ok,Convert(Decimal(18,2),b.c_sec_qty_ok) AS c_sec_qty_ok" +
                ",Convert(Decimal(18,4),Round(b.c_sec_qty_ok/b.c_qty_ok,4)) AS weg_kg,Convert(Decimal(18,4),Round((b.c_sec_qty_ok/b.c_qty_ok)*1000,4)) AS weg_g" +
                ",Convert(Decimal(18,4),b.prod_qty) AS mat_price_g,Convert(Decimal(18,4),b.prod_qty) AS mat_amt" +
                ",Convert(Decimal(18,4),b.prod_qty) AS plate_weg_g" +
                ",Convert(Decimal(18,4),b.prod_qty) AS plate_qty_price,Convert(Decimal(18,4),b.prod_qty) AS plate_weg_price_g"+
                ",Convert(Decimal(18,4),b.prod_qty) AS plate_qty_amt,Convert(Decimal(18,4),b.prod_qty) AS plate_weg_amt_g" +
                ",Convert(Decimal(18,4),b.prod_qty) AS dep_charges,Convert(Decimal(18,4),b.prod_qty) AS plate_charges_g" +
                ",Convert(Decimal(18,4),b.prod_qty) AS mm_costing" +
                " FROM " + remote_db + "jo_bill_mostly a" +
                " INNER JOIN " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " Inner Join " + remote_db + "cd_department d On b.within_code=d.within_code And b.wp_id=d.id" +
                " Inner Join " + remote_db + "cd_department e On b.within_code=d.within_code And b.next_wp_id=e.id" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "'" +
                " Order By b.flag";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                dr["mat_price_g"] = 0;
                dr["mat_amt"] = 0;
                dr["dep_charges"] = 0;
                dr["plate_weg_g"] = 0;
                dr["plate_qty_price"] = 0;
                dr["plate_weg_price_g"] = 0;
                dr["plate_qty_amt"] = 0;
                dr["plate_weg_amt_g"] = 0;
                dr["plate_charges_g"] = 0;
                dr["mm_costing"] = 0;
                if (dr["wp_id"].ToString() == "501")
                {
                    DataTable dtPlate = getPlateCharges(dr["wp_id"].ToString(), dr["mo_id"].ToString(), dr["goods_id"].ToString());
                    if (dtPlate.Rows.Count > 0)
                    {
                        dr["plate_weg_g"] = dtPlate.Rows[0]["plate_weg_g"];
                        dr["plate_qty_price"] = dtPlate.Rows[0]["plate_qty_price"];
                        dr["plate_weg_price_g"] = dtPlate.Rows[0]["plate_weg_price_g"];
                        dr["plate_qty_amt"] = dtPlate.Rows[0]["plate_qty_amt"];
                        dr["plate_weg_amt_g"] = dtPlate.Rows[0]["plate_weg_amt_g"];
                        dr["plate_charges_g"] = dtPlate.Rows[0]["plate_charges_g"];
                    }
                }
            }
            return dt;
        }

        //獲取Wip流程
        public static DataTable getWipRecPart(string id,string seq)
        {
            string strSql = "";
            strSql = " SELECT a.id,b.materiel_id,c.name AS goods_cname,Convert(INT,b.fl_qty) AS fl_qty,Convert(INT,b.i_qty) AS i_qty" +
                ",Convert(Decimal(18,2),b.sec_qty) AS sec_qty" +
                " FROM " + remote_db + "jo_bill_goods_details a" +
                " INNER JOIN " + remote_db + "jo_bill_materiel_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver AND a.sequence_id=b.upper_sequence" +
                " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.materiel_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.id='" + id + "' AND a.sequence_id='" + seq + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        public static DataTable getPlateCharges(string dep,string mo_id, string goods_id)
        {
            string strSql = "";
            strSql = " SELECT a.department_id,b.mo_id,b.goods_id,b.prod_qty,b.sec_qty,b.price,b.p_unit,b.sec_price" +
                ",Convert(Decimal(18,4),(b.sec_qty/b.prod_qty)*1000) AS plate_weg_g" +
                ",Convert(Decimal(18,4),b.price/c.rate) AS plate_qty_price,Convert(Decimal(18,4),b.sec_price/1000) AS plate_weg_price_g"+
                ",Convert(Decimal(18,4),b.price/c.rate) AS plate_qty_amt,Convert(Decimal(18,4),((b.sec_qty/b.prod_qty)*1000)*(b.sec_price/1000)) AS plate_weg_amt_g" +
                ",Convert(Decimal(18,4),(b.price/c.rate)+(((b.sec_qty/b.prod_qty)*1000)*(b.sec_price/1000))) AS plate_charges_g" +
                " FROM " + remote_db + "op_outpro_out_mostly a" +
                " INNER JOIN " + remote_db + "op_outpro_out_displace b ON a.within_code=b.within_code AND a.id=b.id" +
                " INNER JOIN " + remote_db + "it_coding c ON b.within_code=c.within_code AND b.p_unit=c.unit_code" +
                " WHERE a.within_code='" + within_code + "' AND a.department_id='" + dep + "' AND b.mo_id='" + mo_id + "' AND b.goods_id='" + goods_id + "'" +
                " AND c.id='*'" +
                " ORDER BY a.issue_date DESC";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
    }
}
