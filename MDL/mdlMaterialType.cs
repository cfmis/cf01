using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    /// <summary>
    /// 物料種類
    /// </summary>
    public class mdlMaterialType
    {
        public string mat_code;
        public string mat_desc;
        public string mat_cdesc;
        public string mat_group;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;

    }

    /// <summary>
    /// 產品種類
    /// </summary>
    public class mdlProductType
    {
        public string prd_code;
        public string prd_desc;
        public string prd_cdesc;
        public string prd_group;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
    }

    /// <summary>
    /// 圖樣代號
    /// </summary>
    public class mdlArtWork
    {
        public string art_code;
        public string art_desc;
        public string art_cdesc;
        public string art_group;
        public string art_brand;
        public string art_customer;
        public string art_creater;
        public string art_image;
        public string art_tech_documents;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;

    }

    /// <summary>
    ///物料代號 
    /// </summary>
    public class mdlMatMaster
    {
        public string prd_item;
        public string item_desc;
        public string item_cdesc;
        public string item_unit;
        public string item_unit1;
        public float stork_minq;
        public float stork_maxq;
        public float stork_minw;
        public float stork_maxw;
        public float item_cost;
        public float item_cost1;
        public float item_waste;
        public string item_type;
        public string item_img;
        public string item_rmk;
        public string item_hscode;
        public string item_hgcode;
        public string item_hgtype;
        public string crdat;
        public string prd_dep;
        public string item_part;
        public string mat_code;
        public string prd_code;
        public string art_code;
        public string size_code;
        public string clr_code;
        public float qty_weg_rate;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
        public string modality;
    }

}
