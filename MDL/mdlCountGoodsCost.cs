using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlCountGoodsStdCost
    {
    }
    public class mdlCountGoodsCostBase
    {
        public string ID { get; set; }
        public int Ver { get; set; }
        public int SN { get; set; }
    }
    public class mdlCountGoodsCostBase1
    {
        public int UpperSN { get; set; }
        public string Seq { get; set; }
        public string NewSeq { get; set; }
        public string CreateUser { get; set; }
        public string CreateTime { get; set; }
        public string AmendUser { get; set; }
        public string AmendTime { get; set; }
    }
    public class mdlCountGoodsCost : mdlCountGoodsCostBase
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string FrontPart { get; set; }
        public string ArtWork { get; set; }
        public string ArtWorkName { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductSize { get; set; }
        public string ProductSizeName { get; set; }
        public string ProductColor { get; set; }
        public string ProductColorName { get; set; }
        public string CustColor { get; set; }
        public string PrdMo { get; set; }
        public string MdNo { get; set; }
        public string MoGroup { get; set; }
        public float FactAddWasteRate { get; set; }
        public float CompProfitRate { get; set; }
        public string Remark { get; set; }
        public string CreateUser { get; set; }
        public string CreateTime { get; set; }
        public string AmendUser { get; set; }
        public string AmendTime { get; set; }
    }
    public class mdlCountGoodsCostPart : mdlCountGoodsCost
    {
        public int UpperSN { get; set; }
        public string Seq { get; set; }
        public string NewSeq { get; set; }
        public float MatWeg { get; set; }
        public float MatUse { get; set; }
        public float MatCost { get; set; }
        public float ProcessCostTotal { get; set; }
        public float ProcessProfitRate { get; set; }
        public float ProcessProfit { get; set; }
        public float PlateCost { get; set; }
        public float PackCost { get; set; }
        public float CostPcs { get; set; }
        public float CostGrs { get; set; }
        public float CostK { get; set; }
        public float FactoryFee { get; set; }
        public float FactoryCostPcs { get; set; }
        public float FactoryCostGrs { get; set; }
        public float FactoryCostK { get; set; }
    }
    public class mdlCountGoodsCostMat: mdlCountGoodsCostBase1
    {
        public string MatCode { get; set; }
        public string MatName { get; set; }
        public float MatWeg { get; set; }
        public float WasteRate { get; set; }
        public float MatWaste { get; set; }
        public float MatUse { get; set; }
        public float MatPrice { get; set; }
        public string MatPriceUnit { get; set; }
        public float MatCost { get; set; }
        public string Curr { get; set; }
    }
    public class mdlCountGoodsCostProcess : mdlCountGoodsCostBase1
    {
        public string PrdDep { get; set; }
        public string ProcessType { get; set; }
        public string ProcessID { get; set; }
        public string ProcessName { get; set; }
        public float ProcessPrice { get; set; }
        public float ProcessBaseQty { get; set; }
        public string ProcessUnit { get; set; }
        public float CostK { get; set; }
        public float ProcessWeg { get; set; }
        public float WegPrice { get; set; }
        public string WegUnit { get; set; }
        public float WegCost { get; set; }
        public float WasteRate { get; set; }
        public float TotalCostK { get; set; }
        public string VendID { get; set; }
        public string VendName { get; set; }
        public string QuoDate { get; set; }
        public string QuoID { get; set; }
        public string PSeq { get; set; }
    }
    public class mdlPurPrice: mdlCountGoodsCostBase1
    {
        public string BrandID { get; set; }
        public float PurPriceRate { get; set; }
        public float PurPricePcs { get; set; }
        public float PurPriceGrs { get; set; }
        public float PurPriceK { get; set; }

    }
}
