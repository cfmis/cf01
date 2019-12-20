using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsGetDataForComboBox
    {
        /// <summary>
        /// 獲取所有貨幣
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCurrency()
        {
            DataTable dtCurr = new DataTable();
            try
            {
                const string strSql = @" SELECT curr_id as id,curr_cdesc as cdesc,curr_desc as edesc FROM bs_curr ";
                dtCurr = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtCurr;
        }

        /// <summary>
        /// 獲取所有區域
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArea()
        {
            DataTable dtArea = new DataTable();
            try
            {
                const string strSql = @" SELECT id,cdesc,edesc FROM bs_zone ";
                dtArea = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtArea;
        }

        /// <summary>
        /// 獲取顏色
        /// </summary>
        /// <returns></returns>
        public static DataTable GetColor()
        {
            DataTable dtColor = new DataTable();
            try
            {
                const string strSql = @" SELECT clr_code,clr_desc,clr_cdesc FROM bs_color ";
                dtColor = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtColor;
        }

        /// <summary>
        /// 獲取尺寸
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSzie()
        {
            DataTable dtSzie = new DataTable();
            try
            {
                const string strSql = @" SELECT size_id,size_desc,size_cdesc FROM bs_size ";
                dtSzie = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtSzie;
        }

        /// <summary>
        /// 獲取類型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTypeInfo()
        {
            DataTable dtType = new DataTable();
            try
            {
                const string strSql = @" SELECT typ_code,typ_desc,typ_cdesc FROM bs_type ";
                dtType = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtType;
        }

        /// <summary>
        /// 獲取組別
        /// </summary>
        /// <returns></returns>
        public static DataTable GetGroup()
        {
            DataTable dtType = new DataTable();
            try
            {
                const string strSql = @" SELECT grp_code,grp_desc,grp_cdesc FROM dbo.bs_group ";
                dtType = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtType;
        }

        /// <summary>
        /// 獲取組別
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCodingType()
        {
            DataTable dtType = new DataTable();
            try
            {
                const string strSql = @" SELECT code_type, code_cdesc FROM dbo.bs_coding_type ";
                dtType = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtType;
        }

    }
}
