using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.MDL;
using System.Data;

namespace cf01.CLS
{
    public class clsArtWork
    {
        /// <summary>
        /// 新增圖樣代號
        /// </summary>
        /// <param name="objArtWork"></param>
        /// <returns></returns>
        public static int AddArtWork(mdlArtWork objArtWork)
        {
            int Result = 0;
            try
            {
                string IsExist = clsPublicOfCF01.ExecuteSqlReturnObject(string.Format("SELECT art_code FROM bs_artwork WHERE art_code='{0}' ", objArtWork.art_code));

                if (IsExist == "")
                {
                    string strSql = @"INSERT INTO bs_artwork(art_code, art_desc, art_cdesc, art_group, art_brand
                                                           , art_customer, art_creater, art_image, art_tech_documents, crusr, crtim)
                                                      VALUES(@art_code, @art_desc, @art_cdesc, @art_group, @art_brand
                                                           , @art_customer, @art_creater, @art_image, @art_tech_documents, @crusr, GETDATE()) ";
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@art_code",objArtWork.art_code),
                       new SqlParameter("@art_desc",objArtWork.art_desc),
                       new SqlParameter("@art_cdesc",objArtWork.art_cdesc),
                       new SqlParameter("@art_group",objArtWork.art_group),
                       new SqlParameter("@art_brand",objArtWork.art_brand),
                       new SqlParameter("@art_customer",objArtWork.art_customer),
                       new SqlParameter("@art_creater",objArtWork.art_creater),
                       new SqlParameter("@art_image",objArtWork.art_image),
                       new SqlParameter("@art_tech_documents",objArtWork.art_tech_documents),
                       new SqlParameter("@crusr",objArtWork.crusr)
                    };
                    Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                }
                else
                {
                    MessageBox.Show("此圖樣代號已存在，請輸入新的代號。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 刪除圖樣代號
        /// </summary>
        /// <param name="objArtWork"></param>
        /// <returns></returns>
        public static int UpdateArtWork(mdlArtWork objArtWork)
        {
            int Result = 0;
            try
            {
                string strSql = @" UPDATE bs_artwork SET art_desc=@art_desc, art_cdesc=@art_cdesc, art_group=@art_group, art_brand=@art_brand, art_customer=@art_customer
                                                       , art_creater=@art_creater, art_image=@art_image, art_tech_documents=@art_tech_documents, amusr=@amusr, amtim=GETDATE()
                                   WHERE art_code=@art_code ";
                SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter("@art_code",objArtWork.art_code),
                   new SqlParameter("@art_desc",objArtWork.art_desc),
                   new SqlParameter("@art_cdesc",objArtWork.art_cdesc),
                   new SqlParameter("@art_group",objArtWork.art_group),
                   new SqlParameter("@art_brand",objArtWork.art_brand),
                   new SqlParameter("@art_customer",objArtWork.art_customer),
                   new SqlParameter("@art_creater",objArtWork.art_creater),
                   new SqlParameter("@art_image",objArtWork.art_image),
                   new SqlParameter("@art_tech_documents",objArtWork.art_tech_documents),
                   new SqlParameter("@amusr",objArtWork.amusr)
                };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 刪除圖樣代號
        /// </summary>
        /// <param name="pArtCode"></param>
        /// <returns></returns>
        public static int DeleteArtWork(string pArtCode)
        {
            int Result = 0;
            try
            {
                string strSql = @" DELETE FROM bs_artwork WHERE art_code=@art_code";
                SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter("@art_code",pArtCode)
                };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }

        /// <summary>
        /// 根據條件查詢圖樣代號信息
        /// </summary>
        /// <param name="pArtCode"></param>
        /// <returns></returns>
        public static DataTable GetArtWork(string pArtCode, string pArt_en_desc, string pArt_chs_desc)
        {
            DataTable dtArtWork = new DataTable();
            try
            {
                string strSql = @"SELECT art_code as art, art_desc, art_cdesc, art_group as own_groups, art_brand as brand, art_customer, art_creater, art_image, art_tech_documents, crusr, crtim, amusr, amtim 
                                  FROM bs_artwork ";
                if (pArtCode != "")
                {
                    strSql += " WHERE art_code='" + pArtCode + "'";

                    if (pArt_en_desc != "")
                    {
                        strSql += " AND art_desc LIKE '%" + pArt_en_desc + "%' ";
                    }

                    if (pArt_chs_desc != "")
                    {
                        strSql += " AND art_cdesc LIKE '%" + pArt_chs_desc + "%' ";
                    }
                }
                else
                {
                    if (pArt_en_desc != "")
                    {
                        strSql += " WHERE art_desc LIKE '%" + pArt_en_desc + "%' ";

                        if (pArt_chs_desc != "")
                        {
                            strSql += " AND art_cdesc LIKE '%" + pArt_chs_desc + "%' ";
                        }
                    }

                    if (pArt_chs_desc != "")
                    {
                        strSql += " WHERE art_cdesc LIKE '%" + pArt_chs_desc + "%' ";
                    }
                }

                dtArtWork = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtArtWork;
        }

    }
}
