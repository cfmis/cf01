using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cf01.MDL
{
    /// <summary>
    /// 查詢條件
    /// </summary>
    public class mdlQueryValue
    {
        public string formname;
        public string obj_id;
        public string login_user;
        public string value_type;
        public string obj_value;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
    }

    /// <summary>
    /// 打印的單據
    /// </summary>
    public class mdlMoStatePrint
    {
        public string wp_id;
        public string mo_id;
        public string goods_id;
        public string next_wp_id;
        public int ver;
        public string print_status;
        public string crusr;
        public DateTime crtim;
        public string amusr;
        public DateTime amtim;
    }
    //儲存調整的記錄
    public class mdlAdjFlag
    {
        public string doc_id;
        public string doc_seq;
        public string adj_flag;
    }

    public class mdlProductArrange
    {
        public string arrangeId;
        public string nowDate;
        public string prdDep;
        public string prdMo;
        public string prdItem;
        public int prdVer;
        public string toDep;
        public string prdSeq;
        public string arrangeSeq;
        public float arrangeQty;
        public string crUsr;
        public DateTime crTim;
        public string amUsr;
        public DateTime amTim;
    }
}
