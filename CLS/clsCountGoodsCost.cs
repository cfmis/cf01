using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsCountGoodsCost
    {
        private static string userid = DBUtility._user_id.ToUpper();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
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
            strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS ProductID,c.name AS ProductName"+
                " ,CASE WHEN b.primary_key='1' THEN 'Y' ELSE '' END AS FrontPart" +
                " FROM it_bom_mostly a" +
                " INNER JOIN it_bom b ON a.within_code=b.within_code AND a.id=b.id AND a.exp_id=b.exp_id" +
                " LEFT JOIN it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.id>='" + pid1 + "' AND a.id<='" + pid2 + "'" +
                " Order By b.primary_key DESC,b.log_no";
            DataTable dt = clsPublicOfGEO.GetDataTable(strSql);
            return dt;
        }
        public static DataTable LoadProductCostHead(string ID)
        {
            string strSql = "";
            strSql = "Select ID,Ver,ProductID,ProductName,ArtWork,ArtWorkName,ProductType,ProductTypeName" +
                ",ProductSize,ProductSizeName,ProductColor,ProductColorName,DoColor,CustColor" +
                ",PrdMo,MdNo,MoGroup,FactAddWasteRate,CompProfitRate" +
                ",Remark,CreateUser,Convert(Varchar(50),CreateTime,20) AS CreateTime" +
                ",AmendUser,Convert(Varchar(50),AmendTime,20) AS AmendTime,SN" +
                " From mm_product_cost_head " +
                " Where ID='" + ID + "' And Status<>'D' ";
            DataTable dtProductType = clsPublicOfCF01.GetDataTable(strSql);
            return dtProductType;
        }
        /// <summary>
        /// ///點擊查找時，查找記錄
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DataTable QueryProductCost(string productID,string productName,string ID,string CustColor,string MoGroup)
        {
            string strSql = "";
            strSql += " Select aa.* From ( ";
            strSql += " Select "+"'M' As MFlag"+",a.ID,a.Ver,a.ProductID,a.ProductName,a.ArtWork,a.ArtWorkName,a.ProductType,a.ProductTypeName" +
                ",a.ProductSize,a.ProductSizeName,a.ProductColor,a.ProductColorName,a.DoColor" +
                ",a.PrdMo,a.MdNo,a.MoGroup,a.CustColor,a.FactAddWasteRate,a.CompProfitRate" +
                ",1 AS MultRate,a.Remark,a.CreateUser,Convert(Varchar(50),a.CreateTime,20) AS CreateTime" +
                ",a.AmendUser,Convert(Varchar(50),a.AmendTime,20) AS AmendTime,a.SN" +
                " From mm_product_cost_head a" +
                " Where a.Status<>'D'";
            if (productID != "")
                strSql += " And a.ProductID Like '%" + productID + "%'";
            if (productName != "")
                strSql += " And a.productName Like '%" + productName + "%'";
            if (ID != "")
                strSql += " And a.ID Like '%" + ID + "%'";
            if (CustColor != "")
                strSql += " And a.CustColor Like '%" + CustColor + "%'";
            if (MoGroup != "")
                strSql += " And a.MoGroup = '" + MoGroup + "'";
            if (productID!=""|| productName!="")
            {
                strSql += " Union ";
                strSql += " Select " + "' ' As MFlag" + ",a.ID,a.Ver,b.ProductID,b.ProductName,b.ArtWork,b.ArtWorkName,b.ProductType,b.ProductTypeName" +
                ",b.ProductSize,b.ProductSizeName,b.ProductColor,b.ProductColorName,b.DoColor" +
                ",a.PrdMo,a.MdNo,a.MoGroup,a.CustColor,a.FactAddWasteRate,a.CompProfitRate" +
                ",a.MultRate,a.Remark,a.CreateUser,Convert(Varchar(50),a.CreateTime,20) AS CreateTime" +
                ",a.AmendUser,Convert(Varchar(50),a.AmendTime,20) AS AmendTime,a.SN" +
                " From mm_product_cost_head a" +
                " Inner Join mm_product_cost_part b On a.SN=b.UpperSN" +
                " Where a.Status<>'D' And b.Status<>'D' ";
                if (productID != "")
                    strSql += " And b.ProductID Like '%" + productID + "%'";
                if (productName != "")
                    strSql += " And b.productName Like '%" + productName + "%'";
                if (MoGroup != "")
                    strSql += " And a.MoGroup = '" + MoGroup + "'";
            }
            strSql += " ) aa ";
            strSql += " Order By aa.ID Desc,aa.MFlag Desc ";
            DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);
            return dtPrd;
        }
        /// <summary>
        /// ///查找產品編號
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DataTable QueryProductData(string productID, string productName,int showExistWeg)
        {
            string strSql = "";
            strSql = "Select a.ID As ProductID,a.name As ProductName" +
                ",b.prd_weg,b.waste_weg,b.use_weg,b.mat_item,c.name AS mat_name" +
                ",b.dep_id,d.dep_cdesc" +
                " From geo_it_goods a";
            if (showExistWeg == 0)
                strSql += " Left Join bs_product_qty_rate b On a.id=b.prd_item ";
            else//////顯示已設定的產品重量
                strSql += " Inner Join bs_product_qty_rate b On a.id=b.prd_item ";
            strSql += " Left Join geo_it_goods c On b.mat_item=c.id " +
                " Left Join bs_dep d On b.dep_id=d.dep_id" +
                " Where a.ID>=''";
            if (productID != "")
                strSql += " And a.ID Like '%" + productID + "%'";
            if (productName != "")
                strSql += " And a.name Like '%" + productName + "%'";
            DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);
            return dtPrd;
        }

        public static DataTable QueryGoodsQtyConvert(string productID, string productName)
        {
            string strSql = "";
            strSql = "Select a.ID As ProductID,a.name As ProductName" +
                ",Convert(Int,b.rate) AS rate " +
                " From it_goods a "+
                " Left Join it_coding b On a.within_code=b.within_code And a.id=b.id " +
                " Where a.ID>=''";
            if (productID != "")
                strSql += " And a.ID Like '%" + productID + "%'";
            if (productName != "")
                strSql += " And a.name Like '%" + productName + "%'";
            DataTable dtPrd = clsPublicOfGEO.GetDataTable(strSql);
            return dtPrd;
        }
        public static string Save(mdlCountGoodsCost mdlGoods)
        {
            string result = "";
            string ID = mdlGoods.ID;
            string strSql = "", strUpd = "";
            int Ver = mdlGoods.Ver;
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (ID == "")
            {
                ID = GenID();
            }
            if (CheckID(ID).Rows.Count == 0)
            {
                Ver = 0;
                strUpd = @" Insert Into mm_product_cost_head " +
                    " ( ID,Ver,ProductID,ProductName,ArtWork,ArtWorkName,ProductType,ProductTypeName" +
                    ",ProductSize,ProductSizeName,ProductColor,ProductColorName,DoColor,CustColor" +
                    ",PrdMo,MdNo,MoGroup,FactAddWasteRate,CompProfitRate" +
                    ",Remark,CreateUser,CreateTime,AmendUser,AmendTime )" +
                    " Values ( " +
                    " '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'" +
                    ",'{13}','{14}','{15}','{16}','{17}','{18}','{19}'" +
                    ",'{20}',GETDATE(),'{20}',GETDATE() )";
            }
            else
                strUpd = @" Update mm_product_cost_head Set ProductID='{2}',ProductName='{3}',ArtWork='{4}',ArtWorkName='{5}'" +
                    ",ProductType='{6}',ProductTypeName='{7}'" +
                    ",ProductSize='{8}',ProductSizeName='{9}',ProductColor='{10}',ProductColorName='{11}',DoColor='{12}',CustColor='{13}'" +
                    ",PrdMo='{14}',MdNo='{15}',MoGroup='{16}',FactAddWasteRate='{17}',CompProfitRate='{18}'" +
                    ",Remark='{19}',AmendUser='{20}',AmendTime=GETDATE() " +
                    " Where ID='{0}' And Ver='{1}'";
            strSql += string.Format(strUpd
                    , ID, Ver, mdlGoods.ProductID, mdlGoods.ProductName, mdlGoods.ArtWork, mdlGoods.ArtWorkName
                    , mdlGoods.ProductType, mdlGoods.ProductTypeName, mdlGoods.ProductSize, mdlGoods.ProductSizeName
                    , mdlGoods.ProductColor, mdlGoods.ProductColorName, mdlGoods.DoColor, mdlGoods.CustColor
                    , mdlGoods.PrdMo, mdlGoods.MdNo, mdlGoods.MoGroup, mdlGoods.FactAddWasteRate, mdlGoods.CompProfitRate
                    , mdlGoods.Remark, userid);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = ID;
            return result;
        }
        public static string GenID()
        {
            string result = "";
            string strSql = "";
            strSql += " Select Max(ID) AS ID From mm_product_cost_head ";
            DataTable dtID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtID.Rows[0]["ID"].ToString() == "")
                result = "QT" + "00000001";
            else
                result = "QT" + (Convert.ToInt32(dtID.Rows[0]["ID"].ToString().Substring(2, 8)) + 1).ToString().PadLeft(8, '0');
            return result;
        }
        public static DataTable CheckID(string ID)
        {
            string strSql = "";
            strSql += " Select ID,SN From mm_product_cost_head Where ID='" + ID + "'";
            DataTable dtID = clsPublicOfCF01.GetDataTable(strSql);
            return dtID;
        }
        /// ///注銷所有報價記錄
        public static string Delete(int SN)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@" Update mm_product_cost_head Set Status='D',AmendUser='{1}',AmendTime=GETDATE() Where SN='{0}'"
                    , SN, userid);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }

        /// <summary>
        /// ///儲存配件
        /// </summary>
        /// <param name="mdlGoods"></param>
        /// <returns></returns>
        public static string SaveGoodsPart(mdlCountGoodsCostPart mdlGoodsPart)
        {
            string result = "";
            int upperSN = mdlGoodsPart.UpperSN;
            string seq = mdlGoodsPart.Seq;
            string strSql = "", strUpd = "";
            int Ver = mdlGoodsPart.Ver;
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (seq == "")
            {
                seq = GenSeq("mm_product_cost_part", upperSN, "");
            }
            if (!CheckExistSeq("mm_product_cost_part", upperSN, seq, ""))
            {
                Ver = 0;
                strUpd = @" Insert Into mm_product_cost_part " +
                    " ( upperSN,Seq,ProductID,ProductName,ArtWork,ArtWorkName,ProductType,ProductTypeName" +
                    ",ProductSize,ProductSizeName,ProductColor,ProductColorName,DoColor" +
                    ",MatWeg,MatUse,MatCost,ProcessCostTotal,ProcessProfitRate,ProcessProfit" +
                    ",PlateCost,PackCost" +
                    ",CostPcs,CostGrs,CostK" +
                    ",FactoryFee,FactoryCostPcs,FactoryCostGrs,FactoryCostK" +
                    ",FrontPart,MultRate,Remark,CreateUser,CreateTime,AmendUser,AmendTime" +
                    " )" +
                    " Values ( " +
                    " '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'" +
                    ",'{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}'" +
                    ",'{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}'" +
                    ",GETDATE(),'{31}',GETDATE() " +
                    " )";
            }
            else
                strUpd = @" Update mm_product_cost_part Set ProductID='{2}',ProductName='{3}',ArtWork='{4}',ArtWorkName='{5}'" +
                    ",ProductType='{6}',ProductTypeName='{7}'" +
                    ",ProductSize='{8}',ProductSizeName='{9}',ProductColor='{10}',ProductColorName='{11}',DoColor='{12}'" +
                    ",MatWeg='{13}',MatUse='{14}',MatCost='{15}',ProcessCostTotal='{16}',ProcessProfitRate='{17}',ProcessProfit='{18}'" +
                    ",PlateCost='{19}',PackCost='{20}'" +
                    ",CostPcs='{21}',CostGrs='{22}',CostK='{23}'" +
                    ",FactoryFee='{24}',FactoryCostPcs='{25}',FactoryCostGrs='{26}',FactoryCostK='{27}'" +
                    ",FrontPart='{28}',MultRate='{29}',Remark='{30}',AmendUser='{31}',AmendTime=GETDATE() " +
                    " Where upperSN='{0}' And Seq='{1}'";
            strSql += string.Format(strUpd
                    , upperSN, seq, mdlGoodsPart.ProductID, mdlGoodsPart.ProductName, mdlGoodsPart.ArtWork, mdlGoodsPart.ArtWorkName
                    , mdlGoodsPart.ProductType, mdlGoodsPart.ProductTypeName, mdlGoodsPart.ProductSize, mdlGoodsPart.ProductSizeName
                    , mdlGoodsPart.ProductColor, mdlGoodsPart.ProductColorName, mdlGoodsPart.DoColor
                    , mdlGoodsPart.MatWeg, mdlGoodsPart.MatUse, mdlGoodsPart.MatCost, mdlGoodsPart.ProcessCostTotal, mdlGoodsPart.ProcessProfitRate, mdlGoodsPart.ProcessProfit
                    , mdlGoodsPart.PlateCost, mdlGoodsPart.PackCost
                    , mdlGoodsPart.CostPcs, mdlGoodsPart.CostGrs, mdlGoodsPart.CostK
                    , mdlGoodsPart.FactoryFee, mdlGoodsPart.FactoryCostPcs, mdlGoodsPart.FactoryCostGrs, mdlGoodsPart.FactoryCostK
                    , mdlGoodsPart.FrontPart, mdlGoodsPart.MultRate, mdlGoodsPart.Remark, userid);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = seq;
            return result;
        }


        /// <summary>
        /// ///儲存配件---批量
        /// </summary>
        /// <param name="mdlGoods"></param>
        /// <returns></returns>
        public static string SaveGoodsPartBatch(List<mdlCountGoodsCostPart> lsGoodsPart)
        {
            string result = "";
            int upperSN = lsGoodsPart[0].UpperSN;
            string strSql = "", strUpd = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            int stepSeq = 0;
            string maxSeq = GenSeq("mm_product_cost_part", upperSN, "");
            for (int i = 0; i < lsGoodsPart.Count; i++)
            {
                mdlCountGoodsCostPart mdlGoodsPart = lsGoodsPart[i];
                string seq = mdlGoodsPart.Seq;
                if (seq == "")
                {
                    seq = (Convert.ToInt32(maxSeq.Substring(0, 3)) + stepSeq).ToString().PadLeft(3, '0');
                    stepSeq++;
                }
                if (!CheckExistSeq("mm_product_cost_part", upperSN, seq, ""))
                {
                    strUpd = @" Insert Into mm_product_cost_part " +
                        " ( upperSN,Seq,ProductID,ProductName,ArtWork,ArtWorkName,ProductType,ProductTypeName" +
                        ",ProductSize,ProductSizeName,ProductColor,ProductColorName,DoColor" +
                        ",MatWeg,MatUse,MatCost,ProcessCostTotal,ProcessProfitRate,ProcessProfit" +
                        ",PlateCost,PackCost" +
                        ",CostPcs,CostGrs,CostK" +
                        ",FactoryFee,FactoryCostPcs,FactoryCostGrs,FactoryCostK" +
                        ",FrontPart,MultRate,Remark,CreateUser,CreateTime,AmendUser,AmendTime" +
                        " )" +
                        " Values ( " +
                        " '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'" +
                        ",'{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}'" +
                        ",'{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}'" +
                        ",GETDATE(),'{31}',GETDATE() " +
                        " )";
                }
                else
                    strUpd = @" Update mm_product_cost_part Set ProductID='{2}',ProductName='{3}',ArtWork='{4}',ArtWorkName='{5}'" +
                        ",ProductType='{6}',ProductTypeName='{7}'" +
                        ",ProductSize='{8}',ProductSizeName='{9}',ProductColor='{10}',ProductColorName='{11}',DoColor='{12}'" +
                        ",MatWeg='{13}',MatUse='{14}',MatCost='{15}',ProcessCostTotal='{16}',ProcessProfitRate='{17}',ProcessProfit='{18}'" +
                        ",PlateCost='{19}',PackCost='{20}'" +
                        ",CostPcs='{21}',CostGrs='{22}',CostK='{23}'" +
                        ",FactoryFee='{24}',FactoryCostPcs='{25}',FactoryCostGrs='{26}',FactoryCostK='{27}'" +
                        ",FrontPart='{28}',MultRate='{29}',Remark='{30}',AmendUser='{31}',AmendTime=GETDATE() " +
                        " Where upperSN='{0}' And Seq='{1}'";
                strSql += string.Format(strUpd
                        , upperSN, seq, mdlGoodsPart.ProductID, mdlGoodsPart.ProductName, mdlGoodsPart.ArtWork, mdlGoodsPart.ArtWorkName
                        , mdlGoodsPart.ProductType, mdlGoodsPart.ProductTypeName, mdlGoodsPart.ProductSize, mdlGoodsPart.ProductSizeName
                        , mdlGoodsPart.ProductColor, mdlGoodsPart.ProductColorName, mdlGoodsPart.DoColor
                        , mdlGoodsPart.MatWeg, mdlGoodsPart.MatUse, mdlGoodsPart.MatCost, mdlGoodsPart.ProcessCostTotal, mdlGoodsPart.ProcessProfitRate, mdlGoodsPart.ProcessProfit
                        , mdlGoodsPart.PlateCost, mdlGoodsPart.PackCost
                        , mdlGoodsPart.CostPcs, mdlGoodsPart.CostGrs, mdlGoodsPart.CostK
                        , mdlGoodsPart.FactoryFee, mdlGoodsPart.FactoryCostPcs, mdlGoodsPart.FactoryCostGrs, mdlGoodsPart.FactoryCostK
                        , mdlGoodsPart.FrontPart, mdlGoodsPart.MultRate, mdlGoodsPart.Remark, userid);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }


        private static string GenSeq(string tb,int upperSN,string processType)
        {
            string Seq = "";
            string strSql = "Select Max(Seq) AS Seq From " + tb + " Where upperSN='" + upperSN + "'";
            if (processType != "")
                strSql += " And ProcessType='" + processType + "'";
            DataTable dtSeq = clsPublicOfCF01.GetDataTable(strSql);
            if (dtSeq.Rows[0]["Seq"].ToString() == "")
                Seq = "001";
            else
                Seq = (Convert.ToInt32(dtSeq.Rows[0]["Seq"].ToString().Substring(0, 3)) + 1).ToString().PadLeft(3, '0');
            return Seq;
        }

        private static bool CheckExistSeq(string tb,int upperSN, string seq,string processType)
        {
            bool result=false;
            string strSql = "Select Seq From " + tb + " Where upperSN='" + upperSN + "' And Seq='" + seq + "' And Status<>'D' ";
            if (processType != "")
                strSql += " And processType='" + processType + "'";
            DataTable dtSeq = clsPublicOfCF01.GetDataTable(strSql);
            if (dtSeq.Rows.Count > 0)
                result = true;
            return result;
        }
        public static DataTable LoadProductCostPart(int upperSN,string seq)
        {
            string strSql = "";
            strSql = "Select upperSN,Seq,ProductID,ProductName,ArtWork,ArtWorkName,ProductType,ProductTypeName" +
                ",ProductSize,ProductSizeName,ProductColor,ProductColorName,DoColor" +
                ",MatWeg,MatUse,MatCost,ProcessCostTotal,ProcessProfitRate,ProcessProfit" +
                ",PlateCost,PackCost" +
                ",FrontPart,CostPcs,CostGrs,CostK" +
                ",FactoryFee,FactoryCostPcs,FactoryCostGrs,FactoryCostK" +
                ",MultRate,Remark,CreateUser,Convert(Varchar(50),CreateTime,20) AS CreateTime" +
                ",AmendUser,Convert(Varchar(50),AmendTime,20) AS AmendTime,SN,Status,Seq As NewSeq" +
                " From mm_product_cost_part " +
                " Where upperSN='" + upperSN + "' And Status <>'D' ";
            if (seq != "")
                strSql += " And Seq='" + seq + "'";
            strSql += " Order By FrontPart Desc,Seq";
            DataTable dtGoodsPart = clsPublicOfCF01.GetDataTable(strSql);
            dtGoodsPart.Columns.Add("SelectFlag", typeof(bool));
            return dtGoodsPart;
        }
        public static DataTable LoadProductCostMat(int upperSN)
        {
            string strSql = "";
            strSql = "Select upperSN,Seq,MatCode,MatName,MatWeg,WasteRate,MatWaste,MatUse,MatPrice,MatPriceUnit,MatCost,Curr,Seq As NewSeq " +
                " From mm_product_cost_mat " +
                " Where upperSN='" + upperSN + "' And Status <>'D' ";
            //if (Seq != "")
            //    strSql += " And Seq='" + Seq + "'";
            DataTable dtMat = clsPublicOfCF01.GetDataTable(strSql);
            return dtMat;
        }

        /// <summary>
        /// ///儲存原料成本
        /// </summary>
        /// <param name="lsGoodsMat"></param>
        /// <returns></returns>
        public static string SaveGoodsCostMat(List<mdlCountGoodsCostMat> lsGoodsMat)
        {
            string result = "";
            int upperSN = lsGoodsMat[0].UpperSN;
            string strSql = "", strUpd = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            string maxSeq = GenSeq("mm_product_cost_mat", upperSN, "");
            for (int i = 0; i < lsGoodsMat.Count; i++)
            {
                var mdlGoodsMat = lsGoodsMat[i];
                //string newSeq = mdlGoodsMat.NewSeq;
                string seq =mdlGoodsMat.Seq;
                //if (newSeq == "")
                //{
                //    seq = (Convert.ToInt32(maxSeq.Substring(0, 3)) + i).ToString().PadLeft(3, '0');
                //}
                if (!CheckExistSeq("mm_product_cost_mat", upperSN, seq,""))
                {
                    strUpd = @" Insert Into mm_product_cost_mat " +
                        " ( upperSN,Seq,MatCode,MatName,MatWeg,WasteRate,MatWaste,MatUse,MatPrice,MatPriceUnit,MatCost,Curr"+
                        ",CreateUser,CreateTime,AmendUser,AmendTime" +
                        " )" +
                        " Values ( " +
                        " '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'" +
                        ",'{12}',GETDATE(),'{12}',GETDATE() )";
                }
                else
                    strUpd = @" Update mm_product_cost_mat Set MatCode='{2}',MatName='{3}',MatWeg='{4}',WasteRate='{5}',MatWaste='{6}'" +
                        ",MatUse='{7}',MatPrice='{8}'" +
                        ",MatPriceUnit='{9}',MatCost='{10}',Curr='{11}',AmendUser='{12}',AmendTime=GETDATE() " +
                        " Where upperSN='{0}' And Seq='{1}'";
                strSql += string.Format(strUpd
                        , upperSN, seq, mdlGoodsMat.MatCode, mdlGoodsMat.MatName, mdlGoodsMat.MatWeg, mdlGoodsMat.WasteRate, mdlGoodsMat.MatWaste
                        , mdlGoodsMat.MatUse, mdlGoodsMat.MatPrice, mdlGoodsMat.MatPriceUnit, mdlGoodsMat.MatCost, mdlGoodsMat.Curr, userid);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }

        /// <summary>
        /// ///刪除原料成本
        /// </summary>
        /// <param name="UpperSN"></param>
        /// <param name="Seq"></param>
        /// <returns></returns>
        public static string DeleteGoodsCostMat(int UpperSN, string Seq)
        {
            string result = "";
            string strSql = "", strUpd = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strUpd = @" Delete From mm_product_cost_mat Where upperSN='{0}' And Seq='{1}'";
            strSql += string.Format(strUpd
                    , UpperSN, Seq);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }

        /// <summary>
        /// ///提取工序費用、外發費用、包裝費用　等等。。。
        /// </summary>
        /// <param name="upperSN"></param>
        /// <param name="processType"></param>
        /// <returns></returns>
        public static DataTable LoadProductCostProcess(int upperSN,string processType)
        {
            string strSql = "";
            strSql = "Select upperSN,Seq,PrdDep,ProcessID,ProcessName,ProcessPrice,ProcessBaseQty,ProcessUnit,ProcessWeg,CostK " +
                ",WasteRate,WegPrice,WegUnit,WegCost,TotalCostK,VendID,VendName,QuoDate,QuoID,PSeq,Seq As NewSeq" +
                " From mm_product_cost_process " +
                " Where upperSN='" + upperSN + "' And ProcessType='" + processType + "' And Status <>'D' ";
            //if (Seq != "")
            //    strSql += " And Seq='" + Seq + "'";
            DataTable dtProcess = clsPublicOfCF01.GetDataTable(strSql);
            return dtProcess;
        }

        public static string SaveGoodsCostProcess(List<mdlCountGoodsCostProcess> lsGoodsProcess)
        {
            string result = "";
            int upperSN = lsGoodsProcess[0].UpperSN;
            string processType = lsGoodsProcess[0].ProcessType;
            string strSql = "", strUpd = "";
            //int stepSeq = 0;
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            string maxSeq = GenSeq("mm_product_cost_process", upperSN, processType);
            for (int i = 0; i < lsGoodsProcess.Count; i++)
            {
                var mdlGoodsProcess = lsGoodsProcess[i];
                string seq = mdlGoodsProcess.Seq;
                //if (seq == "")
                //{
                //    seq = (Convert.ToInt32(maxSeq.Substring(0, 3)) + stepSeq).ToString().PadLeft(3, '0');
                //    stepSeq++;
                //}
                if (!CheckExistSeq("mm_product_cost_process", upperSN, seq, processType))
                {
                    strUpd = @" Insert Into mm_product_cost_process " +
                        " ( upperSN,Seq,ProcessType,PrdDep,ProcessID,ProcessName,ProcessPrice,ProcessBaseQty,ProcessUnit,CostK" +
                        ",WasteRate,WegPrice,WegUnit,WegCost,TotalCostK" +
                        ",VendID,VendName,QuoDate,QuoID,PSeq,ProcessWeg" +
                        ",CreateUser,CreateTime,AmendUser,AmendTime" +
                        " )" +
                        " Values ( " +
                        " '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'" +
                        ",'{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}',GETDATE(),'{21}',GETDATE()" +
                        " )";
                }
                else
                    strUpd = @" Update mm_product_cost_process Set PrdDep='{3}',ProcessID='{4}',ProcessName='{5}',ProcessPrice='{6}'" +
                        ",ProcessBaseQty='{7}',ProcessUnit='{8}',CostK='{9}'" +
                        ",WasteRate='{10}',WegPrice='{11}',WegUnit='{12}',WegCost='{13}',TotalCostK='{14}'" +
                        ",VendID='{15}',VendName='{16}',QuoDate='{17}',QuoID='{18}',PSeq='{19}',ProcessWeg='{20}'" +
                        ",AmendUser='{21}',AmendTime=GETDATE() " +
                        " Where upperSN='{0}' And Seq='{1}' And ProcessType='{2}'";
                strSql += string.Format(strUpd
                        , upperSN, seq, processType, mdlGoodsProcess.PrdDep, mdlGoodsProcess.ProcessID, mdlGoodsProcess.ProcessName
                        , mdlGoodsProcess.ProcessPrice, mdlGoodsProcess.ProcessBaseQty
                        , mdlGoodsProcess.ProcessUnit, mdlGoodsProcess.CostK
                        , mdlGoodsProcess.WasteRate, mdlGoodsProcess.WegPrice, mdlGoodsProcess.WegUnit, mdlGoodsProcess.WegCost
                        , mdlGoodsProcess.TotalCostK
                        , mdlGoodsProcess.VendID, mdlGoodsProcess.VendName, mdlGoodsProcess.QuoDate, mdlGoodsProcess.QuoID
                        , mdlGoodsProcess.PSeq, mdlGoodsProcess.ProcessWeg
                        , userid);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }
        public static DataTable GetProductDataPart(string productID)
        {
            string strSql = "";
            //strSql = "Select a.id,a.name" +
            //    " ,b.prd_weg,b.waste_weg,b.use_weg,b.mat_item,c.name AS mat_name" +
            //    " ,a.datum,d.mat_cdesc,a.base_class,e.prd_cdesc" +
            //    " ,a.blueprint_id,f.art_cdesc,f.art_image" +
            //    " ,a.size_id,g.size_cdesc,a.color,h.clr_cdesc" +
            //    " From  geo_it_goods a" +
            //    " Left Join bs_product_qty_rate b On a.id=b.prd_item " +
            //    " Left Join geo_it_goods c On b.mat_item=c.id " +
            //    " Left Join bs_mat_type d On a.datum=d.mat_code" +
            //    " Left Join bs_product_type e On a.base_class=e.prd_code" +
            //    " Left Join bs_artwork f On a.blueprint_id=f.art_code" +
            //    " Left Join bs_size g On a.size_id=g.size_id" +
            //    " Left Join bs_color h On a.color=h.clr_code" +
            //    " Where a.id='" + productID + "'";
            //DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);


            strSql = "Select a.id,a.name" +
                " ,a.datum,b.name As mat_cdesc,a.base_class,c.name As prd_cdesc" +
                " ,a.blueprint_id,d.name As art_cdesc,e.picture_name As art_image" +
                " ,a.size_id,f.name As size_cdesc,a.color,g.name As clr_cdesc,a.do_color As DoColor" +
                " From it_goods a " +
                " Left Join cd_datum b On a.within_code=b.within_code And a.datum=b.id" +
                " Left Join cd_goods_class c On a.within_code=c.within_code And a.base_class=c.id" +
                " Left Join cd_pattern d On a.within_code=d.within_code And a.blueprint_id=d.id" +
                " Left Join cd_pattern_details e On d.within_code=e.within_code And d.id=e.id" +
                " Left Join cd_size f On a.within_code=f.within_code And a.size_id=f.id" +
                " Left Join cd_color g On a.within_code=g.within_code And a.color=g.id" +
                " Where a.within_code='" + within_code + "' And a.id='" + productID + "'";
            DataTable dtPrd = clsPublicOfGEO.GetDataTable(strSql);
            return dtPrd;
        }


        public static string DeleteGoodsCostProcess(mdlCountGoodsCostProcess mdlGoodsProcess)
        {
            string result = "";
            int upperSN = mdlGoodsProcess.UpperSN;
            string processType = mdlGoodsProcess.ProcessType;
            string seq = mdlGoodsProcess.Seq;
            string strSql = "", strUpd = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");

            strUpd = @" Delete From mm_product_cost_process Where upperSN='{0}' And Seq='{1}' And ProcessType='{2}'";
            strSql += string.Format(strUpd
                    , upperSN, seq, processType);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }

        /// ///點擊刪除配件時，刪除配件的記錄
        public static string DeleteItem(int SN)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            //////刪除配件表記錄
            strSql += string.Format(@" Update mm_product_cost_part Set Status='D',AmendUser='{1}',AmendTime=GETDATE() Where SN='{0}'"
                    , SN, userid);
            //////刪除原料表記錄
            strSql += string.Format(@" Update mm_product_cost_mat Set Status='D',AmendUser='{1}',AmendTime=GETDATE() Where UpperSN='{0}'"
                    , SN, userid);
            //////刪除各種加工費、外發加工費、包裝材料費等
            strSql += string.Format(@" Update mm_product_cost_process Set Status='D',AmendUser='{1}',AmendTime=GETDATE() Where UpperSN='{0}'"
                    , SN, userid);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }
        public static DataTable FindPlateStdPrice(int recPrice,string vendID,string plateType,string plate_process, string colorName)
        {
            string strSql = "";
            if (recPrice == 1)
            {
                strSql = "Select a.vendor_id,a.vendor_name As vendor,a.cf_color_id,a.cf_color As do_color" +
                    ",Convert(Varchar(20),a.quotation_date,20) As issue_date,a.quotation_id As id" +
                    ",a.price,Convert(decimal(18, 4),a.price*b.exchange_rate) As QtyPriceHKD" +
                    ",0.00 As WegPriceHKD,' ' As sec_p_unit,' ' As department_id" +
                    ",a.prod_type,a.plate_type,a.plate_process,a.price_unit As p_unit,a.m_id" +
                    ",a.price_remark,a.mat,a.prod_desc,a.prod_id,a.size" +
                    " From quotation_plate a" +
                    " Left Join " + remote_db + "cd_exchange_rate b On a.m_id=b.id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " Where b.within_code='" + within_code + "' And b.state='0' ";
                if (vendID != "")
                    strSql += " And a.vendor_id Like '%" + vendID + "%'";
                if (plateType != "")
                    strSql += " And a.plate_type Like '%" + plateType + "%'";
                if (plate_process != "")
                    strSql += " And a.plate_process = '" + plate_process + "'";
                if (colorName != "")
                    strSql += " And a.cf_color Like '%" + colorName + "%'";
                strSql += " Order By a.do_color,a.prod_type,a.plate_type,a.quotation_date Desc";
            }
            else
            {
                strSql = " Select b.pm73vendid As vendor_id,d.logogram As vendor,a.pm71clr As cf_color_id,a.pm71clrdesc As do_color" +
                    ",a.pm71dat As issue_date,b.pm73qtno As id" +
                    ",b.pm73price As price,Convert(decimal(18, 4),b.pm73price*c.exchange_rate) As QtyPriceHKD" +
                    ",0.00 As WegPriceHKD,' ' As sec_p_unit,' ' As department_id" +
                    ",a.pm71type As prod_type,b.pm73pkind As plate_type,b.pm73ptype As plate_process,b.pm73punit As p_unit,b.pm73curr As m_id" +
                    ",b.pm73rmk As price_remark,a.pm71matdesc As mat,a.pm71cdesc As prod_desc,a.pm71item As prod_id,a.pm71sizedesc As size" +
                    " From dgsql1.dg_data.dbo.pum71 a" +
                    " Inner Join dgsql1.dg_data.dbo.pum73 b On a.pm71id=b.pm73id " +
                    " Left Join " + remote_db + "cd_exchange_rate c On b.pm73curr=c.id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " Left Join " + remote_db + "it_vendor d On b.pm73vendid=d.id COLLATE chinese_taiwan_stroke_CI_AS" +
                    " Where c.within_code='" + within_code + "' And c.state='0' ";
                if (vendID != "")
                    strSql += " And b.pm73vendid Like '%" + vendID + "%'";
                if (plateType != "")
                    strSql += " And b.pm73pkind Like '%" + plateType + "%'";
                if (plate_process != "")
                    strSql += " And b.pm73ptype = '" + plate_process + "'";
                if (colorName != "")
                    strSql += " And a.pm71clrdesc Like '%" + colorName + "%'";
                strSql += " Order By a.pm71clrdesc,b.pm73ptype,a.pm71dat Desc";
            }
            DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);


            //for (int i=0;i<dtPrd.Rows.Count;i++)
            //{
            //    DataRow dr = dtPrd.Rows[i];
            //    decimal exchangeRate = 0;
            //    exchangeRate = clsBaseData.GetMidRate(dr["m_id"].ToString());
            //    dr["QtyPriceHKD"] = Math.Round(clsValidRule.ConvertStrToDecimal(dr["price"].ToString()) * exchangeRate, 4);
            //}
            return dtPrd;
        }

        /// <summary>
        /// ///提取意向報價
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static DataTable LoadPurPriceDetails(int SN)
        {
            string strSql = "";
            strSql = "Select upperSN,Seq,BrandID,PurPriceRate,PurPricePcs,PurPriceGrs,PurPriceK" +
                ",CreateUser,Convert(Varchar(50),CreateTime,20) AS CreateTime" +
                ",AmendUser,Convert(Varchar(50),AmendTime,20) AS AmendTime" +
                " From mm_product_cost_pur " +
                " Where upperSN='" + SN + "'";
            DataTable dtPur = clsPublicOfCF01.GetDataTable(strSql);
            return dtPur;
        }

        public static string SavePurPrice(List<mdlPurPrice> lsPurPrice)
        {
            string result = "";
            int upperSN = lsPurPrice[0].UpperSN;
            string strSql = "", strUpd = "";
            int stepSeq = 0;
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            string maxSeq = GenSeq("mm_product_cost_pur", upperSN, "");
            for (int i = 0; i < lsPurPrice.Count; i++)
            {
                var objPurPrice = lsPurPrice[i];
                string seq = objPurPrice.Seq;
                if (seq == "")
                {
                    seq = (Convert.ToInt32(maxSeq.Substring(0, 3)) + stepSeq).ToString().PadLeft(3, '0');
                    stepSeq++;
                }
                if (!CheckExistSeq("mm_product_cost_pur", upperSN, seq, ""))
                {
                    strUpd = @" Insert Into mm_product_cost_pur " +
                        " ( upperSN,Seq,BrandID,PurPriceRate,PurPricePcs,PurPriceGrs,PurPriceK,CreateUser,CreateTime,AmendUser,AmendTime" +
                        " )" +
                        " Values ( " +
                        " '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GETDATE(),'{7}',GETDATE()" +
                        " )";
                }
                else
                    strUpd = @" Update mm_product_cost_pur Set BrandID='{2}',PurPriceRate='{3}',PurPricePcs='{4}',PurPriceGrs='{5}'" +
                        ",PurPriceK='{6}',AmendUser='{7}',AmendTime=GETDATE() " +
                        " Where upperSN='{0}' And Seq='{1}'";
                strSql += string.Format(strUpd
                        , upperSN, seq, objPurPrice.BrandID, objPurPrice.PurPriceRate, objPurPrice.PurPricePcs
                        , objPurPrice.PurPriceGrs, objPurPrice.PurPriceK, userid);
            }
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }

        public static string DeletePurPrice(int UpperSN, string Seq)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@" Delete From mm_product_cost_pur Where upperSN='{0}' And Seq='{1}'"
                    , UpperSN, Seq);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = "";
            return result;
        }
        /// <summary>
        /// ///用於在查詢時，選擇加入到報價單　自動產生序號
        /// </summary>
        /// <param name="dtSeq"></param>
        /// <returns></returns>
        public static string GenSeqNo(DataTable dtSeq)
        {
            string Seq = "";
            string MaxSeq = "000";
            for (int i = 0; i < dtSeq.Rows.Count; i++)
            {
                Seq = dtSeq.Rows[i]["Seq"].ToString().Trim();
                MaxSeq = string.Compare(MaxSeq, Seq) >= 0 ? MaxSeq : Seq;
            }
            int MaxSeqInt = Convert.ToInt32(MaxSeq);
            Seq = (MaxSeqInt + 1).ToString().PadLeft(3, '0');
            return Seq;
        }
    }
}
