using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    public class mdlMmProductTypeStdPrice
    {
    }
    public class mdlProductTypePriceBase
    {
        public string ID { get; set; }
        public int Ver { get; set; }
    }
    public class mdlProductTypePrice: mdlProductTypePriceBase
    {
        public string ArtWork { get; set; }
        public string ProductType { get; set; }
        public string CreateUser { get; set; }
        public string CreateTime { get; set; }
        public string AmendUser { get; set; }
        public string AmendTime { get; set; }
    }
    public class mdlProductTypePriceSize
    {
        public int UpperSN { get; set; }
        public string Seq { get; set; }
        public string SizeID { get; set; }
        public string SizeName { get; set; }
    }
    public class mdlProductTypePriceColorGroup
    {
        public int UpperSN { get; set; }
        public string Seq { get; set; }
        public string ColorGroup { get; set; }
        public string ValueDesc { get; set; }
        public decimal Price { get; set; }
        public string Curr { get; set; }
    }
    public class mdlProductTypePriceColorDetails
    {
        public int UpperSN { get; set; }
        public string Seq { get; set; }
        public string ColorID { get; set; }
        public string ColorName { get; set; }
    }
}
