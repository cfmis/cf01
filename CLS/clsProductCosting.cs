using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsProductCosting
    {
        private static string userid = DBUtility._user_id.ToUpper();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();

        public static DataTable getBomPid(string pid)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,b.name AS goods_name " +
                " FROM it_bom_mostly a " +
                " LEFT JOIN it_goods b ON a.within_code=b.within_code  AND a.goods_id=b.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }

        public static DataTable getBomCid(string pid)
        {
            string strSql = "";
            string pid1 = pid + "001";
            string pid2 = pid + "999";
            //strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS d_goods_id,c.name AS d_goods_name" +
            //    " FROM it_bom_mostly a" +
            //    " INNER JOIN it_bom b ON a.within_code=b.within_code AND a.id=b.id AND a.exp_id=b.exp_id" +
            //    " LEFT JOIN it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
            //    " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'" +
            //    " Order By b.log_no";
            strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS d_goods_id,c.name AS d_goods_name" +
                " FROM it_bom_mostly a" +
                " INNER JOIN it_bom b ON a.within_code=b.within_code AND a.id=b.id AND a.exp_id=b.exp_id" +
                " LEFT JOIN it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.id>='" + pid1 + "' AND a.id<='" + pid2 + "'" +
                " Order By b.log_no";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }

        //從OC中獲取配件，當作BOM
        public static DataTable getF0ItemFromOc(string mo_id, string pid)
        {
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,b.name AS goods_name " +
                " FROM so_order_details a " +
                " LEFT JOIN it_goods b ON a.within_code=b.within_code  AND a.goods_id=b.id" +
                " WHERE a.within_code='" + within_code + "'";
            if (mo_id != "")
                strSql += " AND a.mo_id='" + mo_id + "'";
            if (pid != "")
                strSql += " AND a.goods_id='" + pid + "'";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
        //從Wip中獲取配件，當作BOM
        public static DataTable getBomCidFromWip(string mo_id, string pid)
        {
            string strSql = "";
            strSql = " SELECT MAX(a.id) AS id,b.goods_id,MAX(a.id) AS d_id,c.materiel_id AS d_goods_id,d.name AS d_goods_name,MAX(b.wp_id) AS dept_id" +
                " FROM jo_bill_mostly a" +
                " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " INNER JOIN jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence" +
                " LEFT JOIN it_goods d ON c.within_code=d.within_code  AND c.materiel_id=d.id" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "' AND b.goods_id='" + pid + "'" +
                " Group By b.goods_id,c.materiel_id,d.name";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
        //從Wip中獲取生產部門
        public static DataTable getBomItemDepFromWip(string mo_id, string goods_id)
        {
            string strSql = "";
            strSql = " SELECT b.wp_id AS dept_id" +
                " FROM jo_bill_mostly a" +
                " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "' AND b.goods_id='" + goods_id + "'";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
        public static DataTable getProductCosting(string productId,string depId)
        {
            string strSql = "Select a.ProductId,a.DepId,a.ProductMo,a.ProductWeight,a.WasteRate,a.MaterialRequest"+
                ",a.OriginalPrice,a.OriginalPriceUnit,a.MaterialPrice,a.MaterialPriceQty,a.MaterialCost,a.RollUpCost,a.DepPrice,a.DepCost"+
                ",a.DepStdPrice,a.DepStdQty,a.OtherCost1,a.OtherCost2,a.OtherCost3,a.ProductCost,a.ProductCostGrs"+
                ",a.ProductCostK,a.ProductCostDzs,a.CreateUser,Convert(Varchar(20),a.CreateTime,120) AS CreateTime"+
                ",a.AmendUser,Convert(Varchar(20),a.AmendTime,120) AS AmendTime,a.OriginWeight,a.DepTotalCost"+
                ",b.name AS ProductName,b.do_color AS DoColor,c.dep_cdesc AS DepCdesc" +
                " From mm_ProductCosting a" +
                " Left Join geo_it_goods b ON a.ProductId=b.id" +
                " Left Join bs_dep c ON a.DepId=c.dep_id" +
                " Where ProductId='" + productId + "' AND DepId='" + depId + "'";
            DataTable dtCost = clsPublicOfCF01.GetDataTable(strSql);
            return dtCost;
        }
        public static DataTable getWipData(string productMo,bool reCount)
        {
            string strSql = "";
            strSql += " SELECT aa.*" +
                ",bb.ProductId,bb.DepId,bb.ProductMo,bb.ProductWeight,bb.WasteRate,bb.MaterialRequest" +
                ",bb.OriginalPrice,bb.OriginalPriceUnit,bb.MaterialPrice,bb.MaterialPriceQty,bb.MaterialCost,bb.RollUpCost,bb.DepPrice,bb.DepCost" +
                ",bb.DepStdPrice,bb.DepStdQty,bb.OtherCost1,bb.OtherCost2,bb.OtherCost3,bb.ProductCost,bb.ProductCostGrs" +
                ",bb.ProductCostK,bb.ProductCostDzs,bb.CreateUser,Convert(Varchar(20),bb.CreateTime,120) AS CreateTime" +
                ",bb.AmendUser,Convert(Varchar(20),bb.AmendTime,120) AS AmendTime,bb.OriginWeight,bb.DepTotalCost" +
                ",cc.pcs_weg AS ProductWeight" +
                ",dd.ProductPrice,dd.PriceUnit,dd.ProductPriceQty" +
                ",ee.kg_qty_rate AS std_kq_qty_rate,ee.pcs_weg AS std_pcs_weg";
            strSql += " FROM ( ";
            strSql += " SELECT TOP 100000 a.id,a.mo_id,b.sequence_id,b.flag,b.goods_id,c.name AS ProductName,c.modality,c.do_color AS DoColor" +
                ",b.wp_id,d.name AS wp_id_cdesc,b.next_wp_id,e.name AS NextDepCdesc" +
                ",Convert(Varchar(20),a.bill_date,111) AS bill_date,Convert(Int,b.prod_qty) AS prod_qty,Convert(Int,b.c_qty_ok) AS c_qty_ok" +
                ",Convert(Decimal(18,2),b.c_sec_qty_ok) AS c_sec_qty_ok,b.vendor_id" +
                ",CASE b.c_qty_ok WHEN 0 THEN 0 ELSE Convert(Decimal(18,4),(b.c_sec_qty_ok/b.c_qty_ok)*1000) END AS pcs_weg" +
                ",f.seller_id,Substring(a.mo_id,3,1) AS mo_group" +
                ",g.dept_id AS StdProductDep,h.name AS DepCdesc" +
                " FROM " + remote_db + "jo_bill_mostly a" +
                " INNER JOIN " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " LEFT JOIN " + remote_db + "cd_department d ON b.within_code=d.within_code  AND b.wp_id=d.id" +
                " LEFT JOIN " + remote_db + "cd_department e ON b.within_code=e.within_code  AND b.next_wp_id=e.id" +
                " INNER JOIN " + remote_db + "so_order_manage f ON a.within_code=f.within_code AND a.order_no=f.id" +// AND a.so_ver=f.ver
                " LEFT JOIN " + remote_db + "it_bom_mostly g ON b.within_code=g.within_code AND b.goods_id=g.goods_id" +
                " LEFT JOIN " + remote_db + "cd_department h ON g.within_code=h.within_code  AND g.dept_id=h.id" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + productMo + "'" +
                " Order By right ('0000000000'+b.flag,10)";
            strSql += " ) aa";
            strSql += " LEFT JOIN mm_ProductCosting bb ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=bb.ProductId AND aa.StdProductDep COLLATE chinese_taiwan_stroke_CI_AS=bb.DepId";
            strSql += " LEFT JOIN bs_product_qty_rate cc ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=cc.prd_item";
            strSql += " LEFT JOIN mm_ProductPrice dd ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=dd.ProductId";
            strSql += " LEFT JOIN bs_product_qty_rate ee ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=ee.prd_item";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            //獲取外發供應商
            if (reCount == false)//如果是重新計算的，就不再獲取外發供應商，減少緩慢
            {
                string id = dt.Rows[0]["id"].ToString();
                strSql = "Select a.wp_id,a.next_wp_id,a.vendor_id,b.goods_id,b.materiel_id" +
                    " From jo_bill_goods_details a" +
                    " Inner Join jo_bill_materiel_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.goods_id=b.materiel_id" +
                    " Where a.within_code='" + within_code + "' And a.id='" + id + "'";
                DataTable dtMat = clsPublicOfGEO.GetDataTable(strSql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string wp_id = dr["wp_id"].ToString().Trim();
                    if (wp_id.Substring(0, 1) == "5")
                    {
                        string goods_id = dr["goods_id"].ToString().Trim();
                        DataRow[] dr1 = dtMat.Select("goods_id='" + goods_id + "' AND next_wp_id='" + wp_id + "'");
                        if (dr1.Length > 0)
                            dr["vendor_id"] = dr1[0]["vendor_id"].ToString();
                    }
                }
            }
            return dt;
        }

        public static DataTable getChildBomData(string productId)
        {
            string strSql = "";
            string pid1 = productId + "001";
            string pid2 = productId + "999";
            strSql += " SELECT aa.*,bb.ProductCost,cc.pcs_weg AS ProductWeight,dd.ProductPrice,dd.PriceUnit,dd.ProductPriceQty";
            strSql += " FROM ( ";
            strSql += " SELECT TOP 100 a.goods_id AS goods_id_m,b.goods_id,c.name AS goods_cname" +
                " FROM " + remote_db + "it_bom_mostly a" +
                " INNER JOIN " + remote_db + "it_bom b ON a.within_code=b.within_code AND a.id=b.id AND a.exp_id=b.exp_id" +
                " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.id>='" + pid1 + "' AND a.id<='" + pid2 + "'" +
                //" WHERE a.within_code='" + within_code + "' AND a.goods_id='" + productId + "'" +
                " Order By b.log_no";
            strSql += " ) aa";
            strSql += " LEFT JOIN mm_ProductCosting bb ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=bb.ProductId";
            strSql += " LEFT JOIN bs_product_qty_rate cc ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=cc.prd_item";
            strSql += " LEFT JOIN mm_ProductPrice dd ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=dd.ProductId";

            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        //這個是在原制單中獲取完成重量后，若仍然沒有重量的，則重新在計劃中按物料編號查找重量
        //但膠料是不會在流程表中而是在成分表中的，所以先從成分表中查找，若不存在再從流程表中查找；其它物料都是從流程表中查找
        //獲取物料每PCS的重量
        public static decimal getProductWeight(string productMo,string productId,string modality)
        {
            decimal pcsWeg = 0;
            string strSql = "";
            string strSql1 = "";
            DataTable dt = new DataTable();
            strSql1 += " SELECT aa.mo_id,Convert(Decimal(18,4),(aa.c_sec_qty_ok/aa.c_qty_ok)*1000) AS pcs_weg";
            strSql1 += " FROM (";
            strSql1 += " SELECT TOP 10 a.mo_id,b.c_qty_ok,b.c_sec_qty_ok" +
                " FROM jo_bill_mostly a" +
                " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " WHERE b.within_code='" + within_code + "' AND b.goods_id='" + productId + "' AND b.c_qty_ok>0 AND b.c_sec_qty_ok>0";
            strSql1 += " ORDER BY b.c_qty_ok Desc";
            strSql1 += ") aa";
            if (productId.Substring(0,2) == "PL" || modality=="2")//膠料或採購件
            {
                strSql = " SELECT a.mo_id,CASE c.i_qty WHEN 0 THEN 0 ELSE Convert(Decimal(18,4),(c.i_sec_qty/c.i_qty)*1000) END AS pcs_weg" +
                    " FROM jo_bill_mostly a" +
                    " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                    " INNER JOIN jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence" +
                    " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + productMo + "' AND c.materiel_id='" + productId + "' AND c.i_qty>0";
                dt = clsPublicOfGEO.GetDataTable(strSql);//從生產流程物料構成表jo_bill_materiel_details中提取
                if (dt.Rows.Count > 0)
                    pcsWeg = dt.Rows[0]["pcs_weg"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["pcs_weg"]) : 0;
                else
                {
                    dt = clsPublicOfGEO.GetDataTable(strSql1);//從生產流程jo_bill_goods_details中提取
                    if (dt.Rows.Count > 0)
                        pcsWeg = dt.Rows[0]["pcs_weg"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["pcs_weg"]) : 0;
                    else
                    {
                        strSql = " SELECT CASE a.receipt_qty WHEN 0 THEN 0 ELSE Convert(Decimal(18,4),(a.sec_qty/a.receipt_qty)*1000) END AS pcs_weg" +
                            " FROM po_receipt_details a" +
                            " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + productId + "' AND a.receipt_qty>0";
                        dt = clsPublicOfGEO.GetDataTable(strSql);//從採購入庫po_receipt_details中提取
                        if (dt.Rows.Count > 0)
                            pcsWeg = dt.Rows[0]["pcs_weg"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["pcs_weg"]) : 0;
                    }
                }
            }
            else
            {
                dt = clsPublicOfGEO.GetDataTable(strSql1);
                if (dt.Rows.Count > 0)
                    pcsWeg = dt.Rows[0]["pcs_weg"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["pcs_weg"]) : 0;
            }
            return pcsWeg;
        }
        public static string updateProductCosting(List<mdlProductCosting> lsModel)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                if (!checkProductId(lsModel[i].productId,lsModel[i].depId))
                    strSql += string.Format(@" Insert Into mm_ProductCosting (ProductId,ProductMo,ProductWeight,OriginWeight,WasteRate,MaterialRequest,OriginalPrice,MaterialPrice
                        ,MaterialPriceQty,MaterialCost,RollUpCost,DepId,DepPrice,DepCost,DepTotalCost,DepStdPrice,DepStdQty,OtherCost1,OtherCost2,OtherCost3,ProductCost
                        ,ProductCostDzs,ProductCostGrs,ProductCostK,CreateUser,CreateTime)
                        Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'
                        ,'{19}','{20}','{21}','{22}','{23}','{24}','{25}')"
                        , lsModel[i].productId, lsModel[i].productMo, lsModel[i].productWeight, lsModel[i].originWeight, lsModel[i].wasteRate, lsModel[i].materialRequest, lsModel[i].originalPrice
                        , lsModel[i].materialPrice, lsModel[i].materialPriceQty, lsModel[i].materialCost, lsModel[i].rollUpCost, lsModel[i].depId, lsModel[i].depPrice, lsModel[i].depCost, lsModel[i].depTotalCost
                        , lsModel[i].depStdPrice, lsModel[i].depStdQty, lsModel[i].otherCost1, lsModel[i].otherCost2, lsModel[i].otherCost3
                        , lsModel[i].productCost, lsModel[i].productCostDzs, lsModel[i].productCostGrs, lsModel[i].productCostK
                        , lsModel[i].createUser, lsModel[i].createTime);
                else
                    strSql += string.Format(@" Update mm_ProductCosting Set ProductMo='{2}',ProductWeight='{3}',WasteRate='{4}',MaterialRequest='{5}'
                        ,OriginalPrice='{6}',MaterialPrice='{7}',MaterialCost='{8}',RollUpCost='{9}',DepPrice='{10}',DepCost='{11}'
                        ,DepStdPrice='{12}',DepStdQty='{13}',OtherCost1='{14}',OtherCost2='{15}',OtherCost3='{16}'
                        ,ProductCost='{17}',ProductCostDzs='{18}',ProductCostGrs='{19}',ProductCostK='{20}',AmendUser='{21}',AmendTime='{22}',OriginWeight='{23}'
                        ,DepTotalCost='{24}',MaterialPriceQty='{25}'
                        Where ProductId='{0}' AND DepId='{1}'"
                        , lsModel[i].productId, lsModel[i].depId, lsModel[i].productMo, lsModel[i].productWeight, lsModel[i].wasteRate, lsModel[i].materialRequest, lsModel[i].originalPrice
                        , lsModel[i].materialPrice, lsModel[i].materialCost, lsModel[i].rollUpCost, lsModel[i].depPrice, lsModel[i].depCost
                        , lsModel[i].depStdPrice, lsModel[i].depStdQty, lsModel[i].otherCost1, lsModel[i].otherCost2, lsModel[i].otherCost3
                        , lsModel[i].productCost, lsModel[i].productCostDzs, lsModel[i].productCostGrs, lsModel[i].productCostK
                        , lsModel[i].createUser, lsModel[i].createTime, lsModel[i].originWeight, lsModel[i].depTotalCost, lsModel[i].materialPriceQty);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        private static bool checkProductId(string productId,string depId)
        {
            bool result = true;
            string strSql = "Select ProductId From mm_ProductCosting Where ProductId='" + productId + "' AND DepId='" + depId + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = true;
            else
                result = false;
            return result;
        }

        public static string deleteProductCosting(List<mdlProductCosting> lsModel)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                strSql += string.Format(@" Delete From mm_ProductCosting Where ProductId='{0}' AND DepId='{1}'"
                    , lsModel[i].productId, lsModel[i].depId);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        public static DataTable findProductCosting1(string id, string prd_mo,int isSetFlag)
        {
            string strSql = "Select a.ProductId,a.ProductMo,a.ProductCost,b.name As ProductName" +
                " From mm_ProductCosting a" +
                " Left join geo_it_goods b On a.ProductId=b.id" +
                " Where a.ProductId>=''";
            if (id != "")
                strSql += " And a.ProductId Like'" + "%" + id + "%'";
            if (prd_mo != "")
                strSql += " And a.ProductMo Like'" + "%" + prd_mo + "%'";
            strSql += " Order By a.ProductId";
            DataTable dtMmCosting = clsPublicOfCF01.GetDataTable(strSql);
            return dtMmCosting;
        }
        //從Wip中獲取配件，當作BOM
        public static DataTable findProductCosting(int isSetCosting,int sourceItem,bool showF0, string productMo,string productId
            ,string matFrom,string matTo,string prdTypeFrom,string prdTypeTo,string artFrom,string artTo
            ,string sizeFrom,string sizeTo,string clrFrom,string clrTo
            ,string dateFrom,string dateTo,string moGroup,string Sales)
        {
            //isSetCosting: 0--已設定成本；1--未設定成本；2--所有
            //sourceItem: 0--從計劃中查找；1--從物料編號中查找
            string strSql = "";
            string strWhere = "";
            string productId1 = "";
            if (productId != "")
                productId1 = productId;
            else
                productId1 = matFrom + prdTypeFrom + artFrom + sizeFrom + clrFrom;
            if (productId1.Length == 18 || (productId1.Length>2 && productId1.Substring(0,2)=="F0"))
            {
                if (isSetCosting == 0)
                    strWhere += " And a.ProductId='" + productId1 + "'";
                else
                    if (sourceItem == 0)
                        strWhere += " And b.goods_id='" + productId1 + "'";
                    else
                        strWhere += " And mm.id='" + productId1 + "'";
            }
            else
            {
                if (matFrom != "" && matTo != "")
                    strWhere += " And mm.datum >='" + matFrom + "' And mm.datum<='" + matTo + "'";
                if (prdTypeFrom != "" && prdTypeTo != "")
                    strWhere += " And mm.base_class >='" + prdTypeFrom + "' And mm.base_class<='" + prdTypeTo + "'";
                if (artFrom != "" && artTo != "")
                    strWhere += " And mm.blueprint_id >='" + artFrom + "' And mm.blueprint_id<='" + artTo + "'";
                if (sizeFrom != "" && sizeTo != "")
                    strWhere += " And mm.size_id >='" + sizeFrom + "' And mm.size_id<='" + sizeTo + "'";
                if (clrFrom != "" && clrTo != "")
                    strWhere += " And mm.color >='" + clrFrom + "' And mm.color<='" + clrTo + "'";
            }
            
            if (isSetCosting == 0)//已設定成本
            {
                strSql = "Select a.ProductId AS goods_id,a.ProductMo AS mo_id,a.ProductWeight AS pcs_weg,mm.name As goods_cname" +
                ",mm.do_color AS DoColor,a.ProductCost,CASE b.kg_qty_rate WHEN 0 THEN 0 ELSE ROUND((1/b.kg_qty_rate)*1000,4) END AS ProductWeight" +
                ",c.ProductPrice,c.PriceUnit " +
                " From mm_ProductCosting a" +
                " Inner join geo_it_goods mm On a.ProductId=mm.id" +
                " Left Join bs_product_qty_rate b On a.ProductId=b.prd_item" +
                " Left Join mm_ProductPrice c On a.ProductId=c.ProductId" +
                " Where a.ProductId>=''";
                if (productMo != "")
                    strSql += " And a.ProductMo ='" + productMo + "'";
                strSql += strWhere;
                if (showF0 == true)
                    strSql += " And a.ProductId>='F0' And a.ProductId<='F0-ZZZZZZZ-ZZZ'";
                strSql += " Order By a.ProductId";
            }
            else
            {
                if (sourceItem == 0)
                {
                    strSql += " SELECT bbb.* FROM (";
                    strSql += " SELECT aa.mo_id,Convert(Varchar(20),aa.bill_date,111) AS bill_date" +
                        ",aa.goods_id,aa.goods_cname,aa.DoColor,bb.ProductCost" +
                        ",Convert(INT,aa.prod_qty) AS prod_qty,Convert(INT,aa.c_qty_ok) AS c_qty_ok,Convert(Decimal(18,2),aa.c_sec_qty_ok) AS c_sec_qty_ok" +
                        ",CASE aa.c_qty_ok WHEN 0 THEN 0 ELSE Convert(Decimal(18,4),(aa.c_sec_qty_ok/aa.c_qty_ok)*1000) END AS pcs_weg" +
                        ",aa.wp_id,aa.wp_cdesc AS DepCdesc,aa.next_wp_id,aa.next_wp_cdesc AS NextDepCdesc" +
                        ",aa.seller_id,Substring(aa.mo_id,3,1) AS mo_group,CASE cc.kg_qty_rate WHEN 0 THEN 0 ELSE ROUND((1/cc.kg_qty_rate)*1000,4) END AS ProductWeight"+
                        ",dd.ProductPrice,dd.PriceUnit";
                    strSql += " FROM (";
                    strSql += " SELECT TOP 100000 a.mo_id,a.bill_date,b.goods_id,mm.name AS goods_cname,mm.do_color AS DoColor,b.prod_qty"+
                        ",b.c_qty_ok,b.c_sec_qty_ok,b.wp_id,d.name AS wp_cdesc"+
                        ",b.next_wp_id,e.name AS next_wp_cdesc,f.seller_id" +
                        " FROM " + remote_db + "jo_bill_mostly a" +
                        " INNER JOIN " + remote_db + "jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                        " INNER JOIN " + remote_db + "it_goods mm ON b.within_code=mm.within_code  AND b.goods_id=mm.id" +
                        " INNER JOIN " + remote_db + "cd_department d ON b.within_code=d.within_code AND b.wp_id=d.id" +
                        " INNER JOIN " + remote_db + "cd_department e ON b.within_code=e.within_code AND b.next_wp_id=e.id" +
                        " INNER JOIN " + remote_db + "so_order_manage f ON a.within_code=f.within_code AND a.order_no=f.id" +
                        " INNER JOIN " + remote_db + "so_order_manage od ON a.within_code=od.within_code AND a.order_no=od.id" +
                        " WHERE a.within_code='" + within_code + "'";// AND a.so_ver=f.ver
                    if (productMo != "")
                        strSql += " AND a.mo_id='" + productMo + "'";
                    //else
                    //{
                    if (dateFrom != "" && dateTo != "")
                    {
                        string dateTo1 = Convert.ToDateTime(dateTo).AddDays(1).ToString("yyyy/MM/dd");
                        strSql += " And a.bill_date>='" + dateFrom + "' And a.bill_date<'" + dateTo1 + "'";
                        strSql += " And od.order_date>='" + dateFrom + "' And od.order_date<'" + dateTo1 + "'";
                    }
                        if (moGroup != "")
                            strSql += " And Substring(a.mo_id,3,1)='" + moGroup + "'";
                        //strSql += " And f.seller_id='" + moGroup + "'";
                        if (Sales != "")
                            strSql += " And f.seller_id='" + Sales + "'";
                    //}
                    if (showF0 == true)
                        strSql += " And b.goods_id>='F0' And b.goods_id<='F0-ZZZZZZZ-ZZZ'";
                    strSql += strWhere;
                    strSql += " ORDER BY b.goods_id,b.c_qty_ok Desc";
                    strSql += ") aa";
                    strSql += " LEFT JOIN mm_ProductCosting bb ON aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=bb.ProductId AND aa.wp_id COLLATE chinese_taiwan_stroke_CI_AS=bb.DepId ";
                    strSql += " Left Join bs_product_qty_rate cc On aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=cc.prd_item ";
                    strSql += " Left Join mm_ProductPrice dd On aa.goods_id COLLATE chinese_taiwan_stroke_CI_AS=dd.ProductId ";
                    strSql += " ) bbb ";
                    if (isSetCosting == 1)//未設定成本
                        strSql += " WHERE bbb.ProductCost Is Null";
                }
                else
                {
                    strSql += "SELECT aa.* FROM (";
                    strSql += "Select Top 100000 mm.id AS goods_id,a.ProductMo AS mo_id,a.ProductWeight AS pcs_weg,a.ProductCost"+
                        ",mm.name As goods_cname,mm.do_color AS DoColor,CASE b.kg_qty_rate WHEN 0 THEN 0 ELSE ROUND((1/b.kg_qty_rate)*1000,4) END AS ProductWeight"+
                        ",c.ProductPrice,c.PriceUnit" +
                        " From geo_it_goods mm" +
                        " Left join mm_ProductCosting a On mm.id=a.ProductId" +
                        " Left Join bs_product_qty_rate b On mm.id=b.prd_item" +
                        " Left Join mm_ProductPrice c On mm.id=c.ProductId" +
                        " Where mm.id>=''";
                    if (showF0 == true)
                        strSql += " And mm.id>='F0' And mm.id<='F0-ZZZZZZZ-ZZZ'";
                    strSql += strWhere;
                    strSql += " Order By mm.id ";
                    strSql += " ) aa";
                    if(isSetCosting == 1)
                        strSql += " WHERE aa.ProductCost Is Null";
                }
            }
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        //因為有些原料是由大砸料開出來的，所以是直接找不到單價的
        //循環查找出原料的單價，如果當前件找不到單價，則找上一層，直到找到後退出循環
        public static DataTable findMaterialPrice(string sourceType,string materialId,string materialName)
        {
            string matId = materialId;
            string matName = materialName;
            DataTable dtMaterialCost = new DataTable();
            for (int i = 0; i < 3; i++)
            {
                //從採購單中查找單價
                dtMaterialCost = findMaterialPriceProcess(sourceType,matId, matName);
                if (dtMaterialCost.Rows.Count > 0)
                    break;
                else//因為有些原料是已經開料的不是直接購買，如果採購單中不存在，則從開料表中找到該物料的上一層，得出後再從採購單中查找單價
                {
                    string strSql1 = "";
                    strSql1 += "Select Distinct aa.goods_id From (";
                    strSql1 += "Select Top 1000 a.goods_id,c.despose_date,c.create_date " +
                         " From jo_bill_despose_detail a" +
                         " Inner Join jo_bill_despose_materiel_detail b On a.within_code=b.within_code And a.id=b.id And a.sequence_id=b.upper_sequence" +
                         " Inner Join jo_bill_despose c On a.within_code=c.within_code And a.id=c.id" +
                         " Where b.within_code='" + within_code + "' And b.goods_id='" + matId + "'";
                    strSql1 += " Order By c.despose_date Desc,c.create_date Desc";
                    strSql1 += ") aa";
                    //strSql1 += " Group By a.goods_id";
                    DataTable dt = clsPublicOfGEO.GetDataTable(strSql1);
                    if (dt.Rows.Count > 0)
                    {
                        matId = dt.Rows[0]["goods_id"].ToString();
                        matName = "";
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            string matId1=dt.Rows[j]["goods_id"].ToString();
                            dtMaterialCost = findMaterialPriceProcess(sourceType,matId1, matName);
                            if (dtMaterialCost.Rows.Count > 0)
                                break;
                        }
                    }
                    else
                        break;
                    if (dtMaterialCost.Rows.Count > 0)
                        break;
                }
            }
            return dtMaterialCost;
        }


        private static DataTable findMaterialPriceProcess(string sourceType,string materialId, string materialName)
        {
            //sourceType : SET -- 在建立畫面查找；FIND -- 在查找畫面中查找，連接標準單價以便顯示
            string strSql = "";
            string materialName1 = materialName;
            strSql += " SELECT";
            if (sourceType == "SET")
                strSql += " Top 1";
            strSql += " a.id,Convert(Varchar(20),a.order_date,111) AS order_date,Convert(Decimal(18,4),d.exchange_rate) AS exchange_rate,a.m_id" +
                       ",b.goods_id,b.mo_id,c.name AS goods_name,Convert(Decimal(18,0),b.order_qty) AS order_qty,b.unit_code,g.kind " +
                       ",Convert(Decimal(18,2),b.sec_qty) AS sec_qty,b.sec_unit,Convert(Decimal(18,2),b.price) AS price,b.p_unit AS PriceUnit" +
                       ",CASE g.kind WHEN '05' THEN Convert(Decimal(18,2),((b.price*d.exchange_rate)/f.rate)*1000) ELSE Convert(Decimal(18,2),(b.price*d.exchange_rate)) END AS PriceHkd" +
                       ",CASE g.kind WHEN '05' THEN 0 ELSE Convert(Decimal(18,4),(b.price*d.exchange_rate)/1000) END AS price_g" +
                       ",CASE g.kind WHEN '05' THEN Convert(Decimal(18,4),(b.price*d.exchange_rate)/f.rate) ELSE 0 END AS price_pcs" +
                       ",a.department_id,i.name AS DepCdesc,a.id AS receive_id";
            if (sourceType == "FIND")
                strSql += ",h.ProductPrice AS StdProductPrice,h.PriceUnit AS StdPriceUnit,h.ProductPriceQty AS StdProductPriceQty";
            strSql += " FROM " + remote_db + "po_buy_manage a " +
                        " INNER JOIN " + remote_db + "po_buy_details b ON a.within_code=b.within_code AND a.id=b.id" +
                        " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                        " INNER JOIN " + remote_db + "cd_exchange_rate d ON b.within_code=d.within_code AND a.m_id=d.id" +
                        " INNER JOIN " + remote_db + "it_coding f ON b.within_code=f.within_code AND b.p_unit=f.unit_code" +
                        " INNER JOIN " + remote_db + "cd_units g ON b.within_code=g.within_code AND b.p_unit=g.id" +
                        " LEFT JOIN " + remote_db + "cd_department i ON a.within_code=i.within_code  AND a.department_id=i.id";
            if (sourceType == "FIND")
                strSql+=" LEFT JOIN mm_ProductPrice h ON b.goods_id COLLATE chinese_taiwan_stroke_CI_AS=h.ProductId";
            strSql += " WHERE b.within_code='" + within_code + "'";
            if (materialId != "")
            {
                if (materialId.Length == 18)
                {
                    materialName1 = "";
                    strSql += " AND b.goods_id = '" + materialId + "'";
                }
                else
                    strSql += " AND b.goods_id Like '" + "%" + materialId + "%'";
            }
            if (materialName1 != "")
                strSql += " AND c.name Like '" + "%" + materialName1 + "%'";
            strSql += " AND d.state='0' ";
            strSql += " AND f.id='*' ";
            strSql += " Order By b.goods_id,a.order_date Desc,a.create_date Desc";
            DataTable dtPrice = clsPublicOfCF01.GetDataTable(strSql);
            //如果單價是長度單位(米)，因為在採購單時時不輸入重量的，需從收貨單中獲取重量，才可將單價轉化成重量單價
            for (int i=0;i<dtPrice.Rows.Count;i++)
            {
                DataRow dr = dtPrice.Rows[i];
                if(dr["kind"].ToString().Trim()=="01")
                {
                    double weight = 0;
                    DataTable dtWeight = getWeightFromReceive(dr["id"].ToString().Trim(), dr["goods_id"].ToString().Trim());
                    if (dtWeight.Rows.Count > 0)
                        weight = dtWeight.Rows[0]["sec_qty"].ToString() != "" ? Convert.ToDouble(dtWeight.Rows[0]["sec_qty"]) : 0;
                    if(weight>0)
                    {
                        dr["PriceHkd"] = Math.Round((Convert.ToDouble(dr["price"])*Convert.ToDouble(dr["exchange_rate"])) / weight, 2);
                        dr["price_g"] = Math.Round((Convert.ToDouble(dr["price"]) * Convert.ToDouble(dr["exchange_rate"])) / weight / 1000, 4);
                        dr["sec_qty"] = weight;
                        dr["receive_id"] = dtWeight.Rows[0]["id"];
                    }
                }
            }
            //if(dt.Rows.Count>0)
            //{
            //    //獲取自定的單價
            //    dt.Columns.Add("StdProductPrice", typeof(float));
            //    dt.Columns.Add("StdPriceUnit", typeof(string));
            //    for (int i=0;i<dt.Rows.Count;i++)
            //    {
            //        DataTable dt1 = findStdProductPrice(dt.Rows[0]["goods_id"].ToString());
            //        if(dt1.Rows.Count>0)
            //        {
            //            dt.Rows[i]["StdProductPrice"] = dt1.Rows[0]["ProductPrice"];
            //            dt.Rows[i]["StdPriceUnit"] = dt1.Rows[0]["PriceUnit"];
            //        }
            //    }
            //}
            return dtPrice;
        }
        private static DataTable getWeightFromReceive(string po_id,string goods_id)
        {
            string strSql = "Select Top 1 id,sec_qty From po_receipt_details"+
                " Where within_code='" + within_code + "' And po_id='" + po_id + "' And goods_id='" + goods_id + "'";
            DataTable dtWeight = clsPublicOfGEO.GetDataTable(strSql);
            return dtWeight;
        }
        public static DataTable findPlatePrice(string productMo,string depId,string materialId, string materialName)
        {
            string materialName1 = materialName;
            string strSql = " SELECT a.id,Convert(Varchar(20),a.issue_date,111) AS issue_date,a.vendor_id,a.vendor" +
                        ",b.goods_id,b.mo_id,c.name AS goods_name,b.do_color,Convert(Decimal(18,0),b.prod_qty) AS prod_qty,b.goods_unit " +
                        ",Convert(Decimal(18,2),b.sec_qty) AS sec_qty,b.sec_unit,Convert(Decimal(18,2),b.price) AS price,b.p_unit" +
                        ",CASE b.sec_qty WHEN 0 THEN 0 ELSE Convert(Decimal(18,4),(b.sec_qty/b.prod_qty)*1000) END AS pcs_weg" +
                        ",Convert(Decimal(18,2),b.sec_price) AS sec_price,b.sec_p_unit,Convert(Decimal(18,2),b.total_prices) AS total_prices" +
                        ",Convert(Decimal(18,2),b.mould_fee) AS mould_fee,Convert(Decimal(18,2),b.former_free) AS former_free" +
                        ",Convert(Decimal(18,4),b.sec_price*g.exchange_rate) AS price_kg,Convert(Decimal(18,4),(b.sec_price*g.exchange_rate)/1000) AS price_g" +
                        ",Convert(Decimal(18,4),(b.price*g.exchange_rate)/d.rate) AS price_pcs,Convert(Decimal(18,4),g.exchange_rate) AS exchange_rate" +
                        ",f.money_id AS m_id,a.department_id,b.process_request" +
                        ",h.ProductPrice AS StdProductPrice,h.PriceUnit AS StdPriceUnit" +
                        " FROM "+remote_db+"op_outpro_out_mostly a " +
                        " INNER JOIN " + remote_db + "op_outpro_out_displace b ON a.within_code=b.within_code AND a.id=b.id" +
                        " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                        " INNER JOIN " + remote_db + "it_coding d ON b.within_code=d.within_code AND b.p_unit=d.unit_code" +
                        " INNER JOIN " + remote_db + "it_vendor f ON a.within_code=f.within_code AND a.vendor_id=f.id" +
                        " INNER JOIN " + remote_db + "cd_exchange_rate g ON f.within_code=g.within_code AND f.money_id=g.id" +
                        " LEFT JOIN mm_ProductPrice h ON b.goods_id COLLATE chinese_taiwan_stroke_CI_AS=h.ProductId" +
                        " WHERE b.within_code='" + within_code + "'";
            if (depId != "")
                strSql += " AND a.department_id = '" + depId + "'";
            if (productMo != "")
                strSql += " AND b.mo_id='" + productMo + "'";
            if (materialId != "")
            {
                if (materialId.Length == 18)
                {
                    materialName1 = "";
                    strSql += " AND b.goods_id = '" + materialId + "'";
                }
                else
                    strSql += " AND b.goods_id Like '" + "%" + materialId + "%'";
            }
            if (materialName1 != "")
                strSql += " AND c.name Like '" + "%" + materialName1 + "%'";
            strSql += " AND b.total_prices>0 ";
            strSql += " AND d.id='*' ";
            strSql += " AND g.state='0' ";
            
            strSql += " Order By b.goods_id,a.issue_date Desc";
            //DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            //if (dt.Rows.Count > 0)
            //{
            //    //dt.Columns.Add("StdProductPrice", typeof(float));
            //    //dt.Columns.Add("StdPriceUnit", typeof(string));
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = dt.Rows[i];
            //        dr["origin_price_g"] = dr["price_g"];
            //        dr["pcs_cost"] = Math.Round((dr["pcs_weg"].ToString() != "" ? Convert.ToDecimal(dr["pcs_weg"]) : 0)
            //            * (dr["origin_price_g"].ToString() != "" ? Convert.ToDecimal(dr["origin_price_g"]) : 0), 4);
            //        //洗油和掛電的按粒計算
            //        if (depId == "510" || dr["do_color"].ToString().IndexOf("掛電") > 0 || dr["do_color"].ToString().IndexOf("挂電") > 0)
            //        {
            //            dr["price_g"] = dr["price_pcs"];
            //            dr["pcs_cost"] = dr["price_pcs"];
            //        }
            //        ////獲取自定的單價
            //        //DataTable dt1 = findStdProductPrice(dr["goods_id"].ToString());
            //        //if (dt1.Rows.Count > 0)
            //        //{
            //        //    dr["StdProductPrice"] = dt1.Rows[0]["ProductPrice"];
            //        //    dr["StdPriceUnit"] = dt1.Rows[0]["PriceUnit"];
            //        //}
            //    }
            //}
            return dt;
        }
        //獲取部門加工費
        //檢查產品部門加工費中是否存在已設定的加工費，若沒有的，則查找該產品的生產記錄以得出工種類型，再由工種查找該類型的加工費
        public static DataTable getDepPrice(string depId, string productId)
        {
            DataTable dtDepPrice = new DataTable();
            string processId = "";
            string strSql = "";
            strSql = "Select a.process_id,a.line_qty,b.cost_price,b.product_qty,b.line_qty AS base_line_qty,a.prd_machine,a.prd_machine_level,a.job_type " +
                " From bs_product_process_cost a" +
                " Left Join jo_dept_product_cost b On a.Prd_dep=b.dept_id And a.Process_id=b.process_id" +
                " Where a.Prd_item='" + productId + "' And a.Prd_dep='" + depId + "'";
            //當產品沒有標準加工費時，以部門的標準
            dtDepPrice = clsPublicOfCF01.GetDataTable(strSql);
            if (dtDepPrice.Rows.Count == 0)
            {
                processId = "*";
                strSql = "Select a.cost_price,a.product_qty,a.line_qty " +
                    " From jo_dept_product_cost a" +
                    " Where a.dept_id='" + depId + "' And a.process_id='" + processId + "'";
                dtDepPrice = clsPublicOfCF01.GetDataTable(strSql);
            }

            if (depId == "202" || depId == "203")
            {
                int prd_machine_level = 0;
                string prd_machine = "";
                string job_type = "";
                int line_qty = 0;
                if (dtDepPrice.Rows.Count > 0)
                {
                    prd_machine_level = dtDepPrice.Rows[0]["prd_machine_level"].ToString() != "" ? Convert.ToInt32(dtDepPrice.Rows[0]["prd_machine_level"]) : 0;
                    processId = dtDepPrice.Rows[0]["process_id"].ToString().Trim();
                    prd_machine = dtDepPrice.Rows[0]["prd_machine"].ToString().Trim();
                    job_type = dtDepPrice.Rows[0]["job_type"].ToString().Trim();
                    line_qty = dtDepPrice.Rows[0]["line_qty"].ToString() != "" ? Convert.ToInt32(dtDepPrice.Rows[0]["line_qty"]) : 0;
                }
                //202、203標準加工費
                strSql = "SELECT TOP 1 dept_id AS prd_dep,product_type,goods_id AS prd_item,ISNULL(machine_id,'') AS prd_machine,type_work AS job_type,ISNULL(machine2,'') AS machine2" +
                    ",machine_gear AS prd_machine_level,per_stele_qty AS line_qty,machine_seconds AS cost_price,standard_qty AS product_qty" +
                    " FROM " + remote_db + "cd_machine_standard" +
                    " WHERE within_code='" + within_code + "' AND dept_id='" + depId + "'";
                if (depId == "202")
                {
                    //標準是按: 部門 + 機器 + 檔位
                    if (processId == "K-L-W")
                        strSql += " AND machine_id='" + prd_machine + "' AND machine_gear ='" + prd_machine_level + "'";
                    else
                    {
                        //標準是按: 部門 + 機器 + 每碑數
                        if (processId == "K-J-E")
                            strSql += " AND machine_id='" + prd_machine + "' AND per_stele_qty ='" + line_qty + "'";
                        else
                        {
                            //標準是按: 按工種 + 類型 + 圖樣
                            if (processId == "K-M-A" || processId== "K-I-S")
                                strSql += " AND type_work='" + job_type + "' AND product_type ='" + productId.Substring(2, 2) + "' AND goods_id='" + productId.Substring(4, 7) + "'";
                        }
                    }
                }
                else
                {
                    strSql += " AND type_work='" + job_type + "' AND product_type ='" + productId.Substring(2, 2) + "' AND goods_id='" + productId.Substring(4, 7) + "'";
                }
                dtDepPrice = clsPublicOfCF01.GetDataTable(strSql);
            }
            if (dtDepPrice.Rows.Count > 0)
            {
                //合金部是按每碑來計費的，要將每碑轉換為粒數
                //而且當產品沒有每碑數時,用默認設定的每碑數:base_line_qty
                if (depId == "302"||depId=="322")
                {
                    if ((dtDepPrice.Rows[0]["line_qty"].ToString() != "" ? Convert.ToInt32(dtDepPrice.Rows[0]["line_qty"]) : 0) > 0)
                        dtDepPrice.Rows[0]["product_qty"] = Convert.ToInt32(dtDepPrice.Rows[0]["line_qty"]);
                    else
                        dtDepPrice.Rows[0]["product_qty"] = Convert.ToInt32(dtDepPrice.Rows[0]["base_line_qty"]);
                }
            }
            return dtDepPrice;
        }

        public static DataTable getProductDepFromBom(string productId)
        {
            //string strSql = " SELECT a.dept_id,b.name AS DepCdesc,c.do_color AS DoColor,c.modality" +
            //            " FROM it_bom_mostly a " +
            //            " INNER JOIN cd_department b ON a.within_code=b.within_code AND a.dept_id=b.id" +
            //            " LEFT JOIN it_goods c ON a.within_code=c.within_code  AND a.goods_id=c.id" +
            //            " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + productId + "'";
            string strSql = " SELECT b.dept_id,c.name AS DepCdesc,a.do_color AS DoColor,a.modality" +
                        " FROM it_goods a " +
                        " LEFT JOIN it_bom_mostly b ON a.within_code=b.within_code AND a.id=b.goods_id" +
                        " LEFT JOIN cd_department c ON b.within_code=c.within_code  AND b.dept_id=c.id" +
                        " WHERE a.within_code='" + within_code + "' AND a.id='" + productId + "'";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
        public static DataTable getProductDetails(string productId)
        {
            string strSql = " SELECT a.do_color AS DoColor,a.modality" +
                        " FROM it_goods a " +
                        " WHERE a.within_code='" + within_code + "' AND a.id='" + productId + "'";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
        public static decimal getDepWasteRate(string depId)
        {
            decimal wasteRate = 1;
            string strSql = " Select WasteRate From bs_DepWasteRate Where DepId='" + depId + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                wasteRate = dt.Rows[0]["WasteRate"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["WasteRate"]) : 1;
            return wasteRate;
        }

        public static decimal getProductTypeWasteRate(string productId)
        {
            decimal wasteRate = 0;
            string strSql = " Select b.WasteRate"+
                " From geo_it_goods a " +
                " INNER JOIN bs_ProductTypeWasteRate b " +
                " ON a.base_class=b.ProductType" +
                " Where a.id='" + productId + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                wasteRate = dt.Rows[0]["WasteRate"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["WasteRate"]) : 1;
            return wasteRate;
        }

        //
        public static DataTable findProductPrice(int isSetFlag, bool showF0
            , string matFrom, string matTo, string prdTypeFrom, string prdTypeTo, string artFrom, string artTo, string sizeFrom, string sizeTo
            , string clrFrom, string clrTo,string productId
            )
        {
            string strSql = "";
            string strWhere = "";
            string productId1 = productId;
            if (productId1 == "")
            {
                productId1 = matFrom + prdTypeFrom + artFrom + sizeFrom + clrFrom;
                if (productId1.Length == 18)
                {
                    if (isSetFlag == 0)
                        strWhere += " And a.ProductId='" + productId1 + "'";
                    else
                        strWhere += " And mm.id='" + productId1 + "'";
                }
                else
                {
                    if (matFrom != "" && matTo != "")
                        strWhere += " And mm.datum >='" + matFrom + "' And mm.datum<='" + matTo + "'";
                    if (prdTypeFrom != "" && prdTypeTo != "")
                        strWhere += " And mm.base_class >='" + prdTypeFrom + "' And mm.base_class<='" + prdTypeTo + "'";
                    if (artFrom != "" && artTo != "")
                        strWhere += " And mm.blueprint_id >='" + artFrom + "' And mm.blueprint_id<='" + artTo + "'";
                    if (sizeFrom != "" && sizeTo != "")
                        strWhere += " And mm.size_id >='" + sizeFrom + "' And mm.size_id<='" + sizeTo + "'";
                    if (clrFrom != "" && clrTo != "")
                        strWhere += " And mm.color >='" + clrFrom + "' And mm.color<='" + clrTo + "'";
                }
            }
            else
            {
                if (isSetFlag == 0)
                    strWhere += " And a.ProductId Like '%" + productId1 + "%'";
                else
                    strWhere += " And mm.id Like'%" + productId1 + "%'";
            }
            if (isSetFlag == 0)//已設定單價
            {
                strSql = "Select a.ProductId AS goods_id,mm.name As goods_cname,mm.do_color AS DoColor,a.ProductPrice,a.ProductPriceQty,a.PriceUnit" +
                ",a.AmendUser,Convert(Varchar(20),a.AmendTime,120) AS AmendTime" +
                " From mm_ProductPrice a" +
                " Inner join geo_it_goods mm On a.ProductId=mm.id" +
                " Where a.ProductId>=''";

                strSql += strWhere;
                if (showF0 == true)
                    strSql += " And a.ProductId>='F0' And a.ProductId<='F0-ZZZZZZZ-ZZZ'";
                strSql += " Order By a.ProductId";
            }
            else
            {

                strSql += "SELECT aa.* FROM (";
                strSql += "Select Top 100000 mm.id AS goods_id,a.ProductPrice,a.ProductPriceQty,a.PriceUnit,mm.name As goods_cname,mm.do_color AS DoColor" +
                    ",a.AmendUser,Convert(Varchar(20),a.AmendTime,120) AS AmendTime" +
                    " From geo_it_goods mm" +
                    " Left join mm_ProductPrice a On mm.id=a.ProductId" +
                    " Where mm.id>=''";
                if (showF0 == true)
                    strSql += " And mm.id>='F0' And mm.id<='F0-ZZZZZZZ-ZZZ'";
                strSql += strWhere;
                strSql += " Order By mm.id ";
                strSql += " ) aa";
                if (isSetFlag == 1)
                    strSql += " WHERE aa.ProductPrice Is Null";
            }
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("SetFlag", typeof(bool));
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["setFlag"] = false;
            }
            return dt;
        }

        public static string updateProductPrice(List<mdlProductPrice> lsModel)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                if (!checkProductPrice(lsModel[i].productId))
                    strSql += string.Format(@" Insert Into mm_ProductPrice (ProductId,ProductPrice,ProductPriceQty,PriceUnit,CreateUser,CreateTime,AmendUser,AmendTime)
                        Values ('{0}','{1}','{2}','{3}','{4}','{5}','{4}','{5}')"
                        , lsModel[i].productId, lsModel[i].productPrice, lsModel[i].productPriceQty, lsModel[i].priceUnit, lsModel[i].createUser, lsModel[i].createTime);
                else
                    strSql += string.Format(@" Update mm_ProductPrice Set ProductPrice='{1}',PriceUnit='{2}', ProductPriceQty='{3}',AmendUser='{4}',AmendTime='{5}'
                        Where ProductId='{0}'"
                        , lsModel[i].productId, lsModel[i].productPrice, lsModel[i].priceUnit, lsModel[i].productPriceQty
                        , lsModel[i].amendUser, lsModel[i].amendTime);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        private static bool checkProductPrice(string productId)
        {
            bool result = true;
            string strSql = "Select ProductId,ProductPrice From mm_ProductPrice Where ProductId='" + productId + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = true;
            else
                result = false;
            return result;
        }

        public static string deleteProductPrice(List<mdlProductPrice> lsModel)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                strSql += string.Format(@" Delete From mm_ProductPrice
                        Where ProductId='{0}'"
                    , lsModel[i].productId);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static DataTable findStdProductPrice(string productId)
        {
            string strSql = "Select ProductId,ProductPrice,PriceUnit,ProductPriceQty From mm_ProductPrice Where ProductId='" + productId + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        //
        public static DataTable findProductWeight(int isSetFlag, bool showF0
            , string matFrom, string matTo, string prdTypeFrom, string prdTypeTo, string artFrom, string artTo, string sizeFrom, string sizeTo
            , string clrFrom, string clrTo, string productId,bool noShowDmItem
            )
        {
            string strSql = "";
            string strWhere = "";
            string productId1 = productId;
            if (productId1 == "")
            {
                productId1 = matFrom + prdTypeFrom + artFrom + sizeFrom + clrFrom;
                if (productId1.Length == 18)
                {
                    if (isSetFlag == 0)
                        strWhere += " And a.prd_item='" + productId1 + "'";
                    else
                        strWhere += " And mm.id='" + productId1 + "'";
                }
                else
                {
                    if (matFrom != "" && matTo != "")
                        strWhere += " And mm.datum >='" + matFrom + "' And mm.datum<='" + matTo + "'";
                    if (prdTypeFrom != "" && prdTypeTo != "")
                        strWhere += " And mm.base_class >='" + prdTypeFrom + "' And mm.base_class<='" + prdTypeTo + "'";
                    if (artFrom != "" && artTo != "")
                        strWhere += " And mm.blueprint_id >='" + artFrom + "' And mm.blueprint_id<='" + artTo + "'";
                    if (sizeFrom != "" && sizeTo != "")
                        strWhere += " And mm.size_id >='" + sizeFrom + "' And mm.size_id<='" + sizeTo + "'";
                    if (clrFrom != "" && clrTo != "")
                        strWhere += " And mm.color >='" + clrFrom + "' And mm.color<='" + clrTo + "'";
                }
            }
            else
            {
                if (isSetFlag == 0)
                    strWhere += " And a.prd_item Like '%" + productId1 + "%'";
                else
                    strWhere += " And mm.id Like'%" + productId1 + "%'";
            }
            if (noShowDmItem == true)
                strWhere += " And mm.datum<>'DM'";
            if (isSetFlag == 0)//已設定重量
            {
                strSql = "Select a.prd_item AS goods_id,mm.name As goods_cname,mm.do_color AS DoColor" +
                ",a.kg_qty_rate,a.prd_kg_qty_rate,a.pcs_weg,a.mat_item,mm1.name As mat_cdesc" +
                ",a.dep_id AS DepId,b.dep_cdesc AS DepName,a.CrUsr,Convert(Varchar(20),a.crtim,120) AS CrTim"+
                " From bs_product_qty_rate a" +
                " Inner join geo_it_goods mm On a.prd_item=mm.id" +
                " Left join geo_it_goods mm1 On a.mat_item=mm1.id" +
                " Left join bs_dep b On a.dep_id=b.dep_id"+
                " Where a.prd_item>=''";

                strSql += strWhere;
                if (showF0 == true)
                    strSql += " And Substring(a.prd_item,1,2)<>'F0'";
                strSql += " Order By a.prd_item";
            }
            else
            {
                strSql += "SELECT aa.*,bb.name As mat_cdesc,cc.dep_cdesc AS DepName FROM (";
                strSql += "Select Top 100000 mm.id AS goods_id,mm.name As goods_cname,mm.do_color AS DoColor" +
                    ",a.kg_qty_rate,a.prd_kg_qty_rate,a.pcs_weg" +
                    ",a.mat_item,a.dep_id AS DepId,a.CrUsr,Convert(Varchar(20),a.crtim,120) AS CrTim" +
                    " From geo_it_goods mm" +
                    " Left join bs_product_qty_rate a On mm.id=a.prd_item" +
                     " Where mm.id>=''";
                strSql += strWhere;
                if (showF0 == true)
                    strSql += " And Substring(mm.id,1,2)<>'F0'";
                strSql += " Order By mm.id ";
                strSql += " ) aa";
                strSql += " Left Join geo_it_goods bb On aa.mat_item=bb.id";
                strSql += " Left join bs_dep cc On aa.DepId=cc.dep_id";
                if (isSetFlag == 1)
                    strSql += " WHERE aa.kg_qty_rate Is Null";
            }
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("SetFlag", typeof(bool));
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["setFlag"] = false;
            }
            return dt;
        }

        public static string updateProductWeight(List<mdlProductWeight> lsModel)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                if (!checkProductWeight(lsModel[i].prdItem, lsModel[i].matItem, lsModel[i].depId))
                    strSql += string.Format(@" Insert Into bs_product_qty_rate (prd_item,mat_item,dep_id,pcs_weg,prd_kg_qty_rate,crusr,crtim)
                        Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                        , lsModel[i].prdItem, lsModel[i].matItem, lsModel[i].depId, lsModel[i].pcsWeg, lsModel[i].prdKgQtyRate
                        , lsModel[i].crUser, lsModel[i].crTime);
                else
                    strSql += string.Format(@" Update bs_product_qty_rate Set pcs_weg='{0}',prd_kg_qty_rate='{1}',crusr='{2}',crtim='{3}'
                        Where prd_item='{4}'"
                        , lsModel[i].pcsWeg, lsModel[i].prdKgQtyRate, lsModel[i].crUser, lsModel[i].crTime
                        , lsModel[i].prdItem);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static string deleteProductWeight(List<mdlProductWeight> lsModel)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < lsModel.Count; i++)
            {
                    strSql += string.Format(@" Delete From bs_product_qty_rate Where prd_item='{0}'"
                        , lsModel[i].prdItem);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        private static bool checkProductWeight(string prdItem,string matItem,string depId)
        {
            bool result = true;
            string strSql = "Select prd_item,pcs_weg,kg_qty_rate From bs_product_qty_rate Where prd_item='" + prdItem + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = true;
            else
                result = false;
            return result;
        }
        public static decimal findStdProductWeight(string productId, string materialId)
        {
            decimal stdProductWeight = 0;
            string strSql = "Select kg_qty_rate,pcs_weg From bs_product_qty_rate Where prd_item='" + productId + "'";
            //if (materialId != "")
            //    strSql += " And mat_item='" + materialId + "'";
            //if (depId != "")
            //    strSql += " And Substring(dep_id,1,1)='" + depId.Substring(0, 1) + "'";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            //重量由Kg轉換為：G
            if (dt.Rows.Count > 0)
                stdProductWeight = dt.Rows[0]["pcs_weg"].ToString() != "" ? Convert.ToDecimal(dt.Rows[0]["pcs_weg"]) : 0;
            return stdProductWeight;
        }

        public static DataTable getWipMatData(string productMo,string Seq)
        {
            string strSql = " SELECT c.materiel_id,d.name AS goods_cname,Convert(Numeric(18,0),c.fl_qty) AS fl_qty,c.location" +
                    ",Convert(Numeric(18,2),c.sec_qty) AS sec_qty,Convert(Numeric(18,0),c.i_qty) AS i_qty" +
                    " FROM jo_bill_mostly a" +
                    " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                    " INNER JOIN jo_bill_materiel_details c ON b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence" +
                    " INNER JOIN it_goods d ON c.within_code=d.within_code AND c.materiel_id=d.id" +
                    " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + productMo + "' AND b.sequence_id='" + Seq + "'";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
    }
    
}
