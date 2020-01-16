using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlProductCosting
    {
        public string productId;
        public string productMo;
        public decimal originWeight;
        public decimal productWeight;
        public decimal wasteRate;
        public decimal materialRequest;
        public decimal originalPrice;
        public decimal materialPrice;
        public decimal materialPriceQty;
        public decimal materialCost;
        public decimal rollUpCost;
        public string depId;
        public decimal depPrice;
        public decimal depCost;
        public decimal depTotalCost;
        public decimal depStdPrice;
        public decimal depStdQty;
        public decimal otherCost1;
        public decimal otherCost2;
        public decimal otherCost3;
        public decimal productCost;
        public decimal productCostGrs;
        public decimal productCostK;
        public decimal productCostDzs;
        public string createUser;
        public string createTime;
        public string amendUser;
        public string amendTime;
    }
    public class mdlDepPrice
    {
        public decimal depPrice;
        public decimal depStdPrice;
        public decimal depStdQty;
    }
    public class mdlProductPrice
    {
        public string productId;
        public decimal productPrice;
        public decimal productPriceQty;
        public string priceUnit;
        public string createUser;
        public string createTime;
        public string amendUser;
        public string amendTime;
    }

    public class mdlProductWeight
    {
        public string prdItem;
        public decimal prdKgQtyRate;
        public decimal pcsWeg;
        public string matItem;
        public string depId;
        public string crUser;
        public string crTime;

    }
}
