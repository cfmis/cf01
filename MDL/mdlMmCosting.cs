using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlMmCosting
    {
        public string ID;
        public string Cdesc;
        public string Prd_mo;
        public decimal MmCosting;
        public decimal MatWeg;
        public decimal MatWegG;
        public decimal MatPrice;
        public decimal MatPriceG;
        public decimal MatAmt;
        public decimal MatLossRate;
        public decimal MatLossAmt;
        public decimal PlatePrice;
        public decimal PlateLossRate;
        public decimal PlatePriceIncLoss;
        public decimal PlatePriceIncLossG;
        public decimal MatPlatePrice;
        public decimal DepCharges;
        public decimal FactoryChargesRate;
        public decimal ProfitMarginRate;
    }
    public class mdlPlatePrice
    {
        public string id;
        public string clr;
        public string clr_cdesc;
        public string do_color;
        public decimal plateprice;
        public string remark;
    }
    public class mdlDepCharges
    {
        public string id;
        public string dep_id;
        public decimal dep_charges;
    }
}
