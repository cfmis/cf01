﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cf01.CLS
{
    public class clsBaseData
    {
        private static clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        private static string remote_db = DBUtility.remote_db;
        private static string within_code = DBUtility.within_code;
        private static string pad_db = DBUtility.pad_db;
        /// <summary>
        /// 各車間資料
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Department()
        {
            string sql = @"SELECT id,id+'['+name+']' AS cdesc FROM cd_productline WHERE within_code='0000' and type<>'07' AND state='0' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 外發加工供應商
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Plate_Vendor()
        {
            string sql = @"SELECT id,id + '[' + name + ']' as cdesc FROM it_vendor WHERE within_code='0000' and isnull(Abbrev_id,'')<> '' AND state ='1' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }

        public static DataTable loadDep()
        {
            string strSql = "Select a.dep_id,a.dep_cdesc" +
                " From bs_dep a" +
                " Order By a.dep_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //生產部門
        public static DataTable loadPrdDep()
        {
            string strSql = "Select a.dep_id,rtrim(a.dep_id)+'-'+rtrim(a.dep_cdesc) AS dep_cdesc,dep_group" +
                " From bs_dep a" +
                " Where is_prd='1'" +
                " Order By a.dep_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        //

        public static DataTable loadDocFlag(string doc_type)
        {
            string strSql = "Select flag_id,flag_desc,flag_cdesc" +
                " From bs_flag_desc" +
                " Where doc_type='" + doc_type + "'" +
                " Order By flag_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            DataRow dr = dt.NewRow();
            dr["flag_id"] = "";
            dr["flag_cdesc"] = "";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        //////制單排期中用到的組別
        public static DataTable loadScheduleDepGroup(string prd_dep)
        {
            string strSql = "Select grp_code,grp_cdesc" +
                " From bs_group" +
                " Where mo_group='" + prd_dep + "'" +
                " Order By grp_code";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            DataRow dr = dt.NewRow();
            dr["grp_code"] = "";
            dr["grp_cdesc"] = "";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        public static DataTable LoadSpecDep(string fromDep,string toDep)
        {
            string strSql = "Select a.dep_id,a.dep_cdesc" +
                " From bs_dep a" +
                " Where a.dep_id>='' ";
            if (fromDep != "" && toDep != "")
                strSql += " And a.dep_id>='" + fromDep + "' And a.dep_id<='" + toDep + "'";
            strSql += " Order By a.dep_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }
        /// <summary>
        /// 部門資料
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Dept()
        {
            string sql = @"SELECT id,id+'['+name+']' AS cdesc FROM cd_department WHERE within_code='0000' AND state='0' ORDER BY id";
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 附加費資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFareInfo()
        {
            string sql = @"SELECT id,id+'['+name+']' AS cdesc FROM cd_tack_fare WHERE within_code='0000' AND use_sell = '1' AND state='0' ORDER BY id";            
            DataTable dt = clsPublicOfGEO.GetDataTable(sql);
            return dt;
        }
        /// <summary>
        /// ///提取產品生產工序及單價
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadProductProcess(string dep_id,string processID,string processName)
        {
            string strSql = "Select dept_id,rtrim(a.process_id) As process_id,rtrim(a.process_name) As process_name" +
                ",a.cost_price,a.cost_price AS PriceHKD" +
                ",a.product_qty,a.cost_unit,rtrim(a.remark) AS remark" +
                " From jo_dept_product_cost a " +
                " Where a.dept_id='" + dep_id + "'";
            if (processID != "")
                strSql += " And a.process_id Like'%" + processID + "%'";
            if (processName != "")
                strSql += " And a.process_name Like'%" + processName + "%'";
            strSql += " And a.quo_flag='Y' ";
            strSql += " Order By a.process_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);

            decimal exchangeRate = GetMidRate("RMB");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                dt.Rows[i]["PriceHKD"] = Math.Round(clsValidRule.ConvertStrToDecimal(dt.Rows[i]["cost_price"].ToString()) * exchangeRate, 4);
            }
            return dt;
        }
        /// <summary>
        /// ///貨幣轉換率
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public static decimal GetMidRate(string Mid)
        {
            string strSql = "Select exchange_rate From " + remote_db + "cd_exchange_rate " +
                " Where within_code='" + within_code + "' And id='" + Mid + "' And state='0'";
            decimal exchangeRate = 0;
            DataTable dtExchangeRate = clsPublicOfGEO.GetDataTable(strSql);
            if (dtExchangeRate.Rows.Count > 0)
                exchangeRate = clsValidRule.ConvertStrToDecimal(dtExchangeRate.Rows[0]["exchange_rate"].ToString());
            return exchangeRate;
        }
        //////提取單位轉換率
        public static float GetUnitRate(string unit_id)
        {
            float unitRate = 0;
            string strSql = "Select rate" +
                " From bs_unit_exchange a" +
                " Where a.unit_id='" + unit_id + "' And a.base_unit='PCS'";
            DataTable dtUnitRate = clsPublicOfCF01.GetDataTable(strSql);
            if (dtUnitRate.Rows.Count > 0)
                unitRate = Convert.ToSingle(dtUnitRate.Rows[0]["rate"]);
            return unitRate;
        }
        /// <summary>
        /// ///提取原料種類、包裝物料及單價
        /// </summary>
        /// <param name="prdDep"></param>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public static DataTable LoadProcessType(string prdDep, string processID)
        {
            string strSql = @" SELECT rtrim(process_id) As process_id,rtrim(process_name) As process_name" +
                ",cost_price,cost_price As PriceHKD,product_qty,use_weg,waste_rate" +
                " FROM jo_dept_product_cost " +
                " Where dept_id>='' ";
            if (prdDep != "")
            {
                strSql += " And dept_id='" + prdDep + "' ";
            }
            if (processID != "")
            {
                strSql += " And process_id='" + processID + "' ";
            }

            DataTable dtType = clsPublicOfCF01.GetDataTable(strSql);
            if (prdDep == "PK_FEE")//如果是包裝費用，轉換成港幣
            {
                decimal exchangeRate = GetMidRate("RMB");
                for (int i = 0; i < dtType.Rows.Count; i++)
                {
                    dtType.Rows[i]["PriceHKD"] = Math.Round(clsValidRule.ConvertStrToDecimal(dtType.Rows[i]["cost_price"].ToString()) * exchangeRate, 4);
                }
            }
            return dtType;
        }

        public static string UpdateProcessType(string prdDep, string processID, decimal use_weg)
        {
            string result = "";
            string strSql = @" SELECT rtrim(process_id) As process_id,rtrim(process_name) As process_name" +
                ",cost_price,cost_price As PriceHKD,product_qty,use_weg,waste_rate" +
                " FROM jo_dept_product_cost " +
                " Where dept_id='" + prdDep + "' And process_id='" + processID + "'";

            DataTable dtType = clsPublicOfCF01.GetDataTable(strSql);
            string strUpd = "";
            if (dtType.Rows.Count > 0)//如果是包裝費用，轉換成港幣
                strUpd = @" Update jo_dept_product_cost Set use_weg='{2}' " +
                    " Where dept_id='{0}' And process_id='{1}'";
            else
                strUpd = @" Insert Into jo_dept_product_cost (dept_id,process_id,use_weg )" +
                    " Values ( '{0}','{1}','{2}' ) ";
            strSql = string.Format(strUpd, prdDep, processID, use_weg);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static string DeleteProcessType(string prdDep, string processID)
        {
            string result = "";
            string strSql = "";
            strSql = @" Delete From jo_dept_product_cost Where dept_id='" + prdDep + "' And process_id='" + processID + "'";
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        //////提取制單組別
        public static DataTable LoadMoGroup(string moGroup)
        {
            string strSql = "Select group_id,group_desc" +
                " From bs_mo_group" +
                " Where group_id >'0'";
            if (moGroup != "")
                strSql += " And group_id='" + moGroup + "'";
            strSql += " Order By group_id";
            DataTable dtMoGroup = clsPublicOfCF01.GetDataTable(strSql);
            DataRow dr = dtMoGroup.NewRow();
            dr["group_id"] = "";
            dr["group_desc"] = "";
            dtMoGroup.Rows.Add(dr);
            dtMoGroup.DefaultView.Sort = "group_id";
            return dtMoGroup;
        }


        //////提取貨幣代號
        public static DataTable LoadCurr(string Curr)
        {
            string strSql = "Select curr_id,curr_cdesc" +
                " From bs_curr" +
                " Where curr_id >'000'";
            if (Curr != "")
                strSql += " And curr_id='" + Curr + "'";
            strSql += " Order By curr_id";
            DataTable dtCurr = clsPublicOfCF01.GetDataTable(strSql);
            return dtCurr;
        }

        public static DataTable GetMat(string mat_code)
        {
            string strSql = "Select id,name From cd_datum " +
                " Where within_code='" + within_code + "' And id='" + mat_code + "'";
            DataTable dtMat = clsPublicOfGEO.GetDataTable(strSql);
            return dtMat;
        }

        public static DataTable GetProductType(string type_code)
        {
            string strSql = "Select id,name From cd_goods_class " +
                " Where within_code='" + within_code + "' And id='" + type_code + "'";
            DataTable dtPrdType = clsPublicOfGEO.GetDataTable(strSql);
            return dtPrdType;
        }

        public static DataTable GetProductType()
        {
            string strSql =@"Select id,name From cd_goods_class Where state<>'2' ORDER BY id";           
            DataTable dtPrdType = clsPublicOfGEO.GetDataTable(strSql);
            return dtPrdType;
        }
       
        public static DataTable GetArtwork(string art_code)
        {
            string strSql = "Select a.id,a.name,ISNULL(a.picture_name_h,'') AS picture_name " +
                " From cd_pattern a Where a.within_code='" + within_code + "' And a.id='" + art_code + "'";
            DataTable dtArtwork = clsPublicOfGEO.GetDataTable(strSql);
            return dtArtwork;
        }
        public static DataTable GetSize(string size_id)
        {
            string strSql = "Select id,name From cd_size a " +
                " Where within_code='" + within_code + "' And id='" + size_id + "'";
            DataTable dtArtwork = clsPublicOfGEO.GetDataTable(strSql);
            return dtArtwork;
        }
        public static DataTable GetSize()
        {
            string strSql =string.Format(@"Select id,name From cd_size a Where within_code='{0}' and state<>'2' order by id",within_code);
            DataTable dtSize = clsPublicOfGEO.GetDataTable(strSql);
            return dtSize;
        }
        public static DataTable GetColor(string color_id)
        {
            string strSql = "Select id,name,do_color From cd_color a " +
                " Where within_code='" + within_code + "' And id='" + color_id + "'";
            DataTable dtArtwork = clsPublicOfGEO.GetDataTable(strSql);
            return dtArtwork;
        }

        public static DataTable GetMouldType()
        {
            string strSql =string.Format(
                @"Select '' as id,'' as name Union Select id,name From cd_mo_type Where within_code='{0}' and mo_type='P' and state<>'2' order by id",within_code);
            DataTable dtMould = clsPublicOfGEO.GetDataTable(strSql);
            return dtMould;
        }
        //
        public static void NAR(object o)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o) > 0) ;
            }
            catch { }
            finally
            {
                o = null;
            }
        }

        public static DataTable LoadMachineStd(string dep)
        {
            if (dep == "122" || dep == "124" || dep == "125" || dep == "322")
                pad_db = DBUtility.pad_db_jx;
            string strSql = "Select rtrim(machine_id) AS machine_id,machine_rate,machine_mul" +
                " From "+pad_db +"machine_std "+
                " Where dep='" + dep + "'" +
                " Order By machine_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

    }
}
