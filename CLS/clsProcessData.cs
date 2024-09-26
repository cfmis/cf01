using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace cf01.CLS
{
    //合金部工序數據
    class clsProcessData
    {
        //frmProcess_Type_Size
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public static DataTable Get_dept()            
        {           
           //DataTable dtDept = clsPublicOfCF01.GetDataTable(@"SELECT dep_id,(dep_id +'[' + dep_cdesc+']') AS dep_cdesc FROM dbo.bs_dep with(nolock) WHERE dep_group='DG'");
           string strsql = @"SELECT id as dep_id ,(id +'[' + name+']') AS dep_cdesc from dbo.cd_department where len(id)=3 and state=0 order by id";
           DataTable dtDept = clsConErp.GetDataTable(strsql);
           DataRow dr1 = dtDept.NewRow(); //插一空行
          // dr1["dep_id"] = "";
           dtDept.Rows.InsertAt(dr1, 0);
           return dtDept ;
        }

        public static DataTable GetProcess_Group_ID()
        {
            string strSql = @"SELECT id,(cdesc+' | '+goods_size+' | '+process_color+' | '+artwork_shape) AS cdesc FROM bs_process_group_head with(nolock)";
            DataTable dtProcess = clsPublicOfCF01.GetDataTable(strSql);
            return dtProcess;
        }

        public static DataTable Find_Doc(string pDept, string pID)
        {
            string strsql =
                string.Format(@"SELECT prd_dep,id,cdesc,rotate_speed,grind_ratio,grind_stone,
                                    polished_beads,grind_time,crusr,crtim,amusr,amtim
                                 FROM dbo.bs_process with(nolock) WHERE prd_dep ='{0}' AND id='{1}'", pDept, pID);
            DataTable dtDoc = clsPublicOfCF01.GetDataTable(strsql);
            return dtDoc;
        }

        public static DataTable Find_Doc()
        {
            string strsql = @"SELECT prd_dep,id,cdesc,rotate_speed,grind_ratio,grind_stone,
                              polished_beads,grind_time,crusr,crtim,amusr,amtim 
                             FROM dbo.bs_process with(nolock)";
            DataTable dtDoc = clsPublicOfCF01.GetDataTable(strsql);
            return dtDoc;
        }

        /// <summary>
        /// 檢查貨品編號是否存在
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public static Boolean IsExists_Item(string pItem)
        {
            Boolean _flag = false ;
            string strSql =string.Format("SELECT '1' FROM dgerp2.cferp.dbo.it_goods WHERE within_code='0000' and id='{0}' and type='0001'",pItem);
            DataTable dtItem = clsConErp.GetDataTable(strSql);
            if (dtItem.Rows.Count > 0)
            {
                _flag = true;
            }
            else
            {
                _flag = false;
            }
            return _flag;
        }

        public static DataTable Get_Process_Details(string pDept,string pProcess_group_id)
        {
            string strSql = string.Format("SELECT * FROM v_process_details WHERE prd_dep='{0}' and id='{1}'", pDept, pProcess_group_id);
            DataTable dtProcess = clsPublicOfCF01.GetDataTable(strSql);
            return dtProcess;
        }
    }
}
