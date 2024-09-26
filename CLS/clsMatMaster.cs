using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cf01.MDL;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace cf01.CLS
{
    public class clsMatMaster
    {
        /// <summary>
        /// 新增物料
        /// </summary>
        /// <param name="objMatMaster"></param>
        /// <returns></returns>
        public static int AddMatMaster(mdlMatMaster objMatMaster)
        {
            int Result = 0;
            try
            {
                string strSql = @" INSERT INTO bs_mat_master ( prd_item, item_desc, item_cdesc, item_unit, item_unit1
                                                             , stork_minq, stork_maxq, stork_minw, stork_maxw, item_cost
                                                             , item_cost1, item_waste, item_type, item_img, item_rmk
                                                             , item_hscode, item_hgcode, item_hgtype, crdat, prd_dep
                                                             , item_part, mat_code, prd_code, art_code, size_code
                                                             , clr_code, qty_weg_rate, crusr, crtim,modality) 
                                                       VALUES( @prd_item, @item_desc, @item_cdesc, @item_unit, @item_unit1
                                                             , @stork_minq, @stork_maxq, @stork_minw, @stork_maxw, @item_cost
                                                             , @item_cost1, @item_waste, @item_type, @item_img, @item_rmk
                                                             , @item_hscode, @item_hgcode, @item_hgtype, @crdat, @prd_dep
                                                             , @item_part, @mat_code, @prd_code, @art_code, @size_code
                                                             , @clr_code, @qty_weg_rate, @crusr, GETDATE(),@modality) ";
                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@prd_item",objMatMaster.prd_item),
                   new SqlParameter("@item_desc",objMatMaster.item_desc),
                   new SqlParameter("@item_cdesc",objMatMaster.item_cdesc),
                   new SqlParameter("@item_unit",objMatMaster.item_unit),
                   new SqlParameter("@item_unit1",objMatMaster.item_unit1),
                   new SqlParameter("@stork_minq",Math.Round(objMatMaster.stork_minq,2)),
                   new SqlParameter("@stork_maxq",Math.Round(objMatMaster.stork_maxq,2)),
                   new SqlParameter("@stork_minw",Math.Round(objMatMaster.stork_minw,2)),
                   new SqlParameter("@stork_maxw",Math.Round(objMatMaster.stork_maxw,2)),
                   new SqlParameter("@item_cost",Math.Round(objMatMaster.item_cost,2)),
                   new SqlParameter("@item_cost1",Math.Round(objMatMaster.item_cost1,2)),
                   new SqlParameter("@item_waste",Math.Round(objMatMaster.item_waste,2)),
                   new SqlParameter("@item_type",objMatMaster.item_type),
                   new SqlParameter("@item_img",objMatMaster.item_img),
                   new SqlParameter("@item_rmk",objMatMaster.item_rmk),
                   new SqlParameter("@item_hscode",objMatMaster.item_hscode),
                   new SqlParameter("@item_hgcode",objMatMaster.item_hgcode),
                   new SqlParameter("@item_hgtype",objMatMaster.item_hgtype),
                   new SqlParameter("@crdat",objMatMaster.crdat),
                   new SqlParameter("@prd_dep",objMatMaster.prd_dep),
                   new SqlParameter("@item_part",objMatMaster.item_part),
                   new SqlParameter("@mat_code",objMatMaster.mat_code),
                   new SqlParameter("@prd_code",objMatMaster.prd_code),
                   new SqlParameter("@art_code",objMatMaster.art_code),
                   new SqlParameter("@size_code",objMatMaster.size_code),
                   new SqlParameter("@clr_code",objMatMaster.clr_code),
                   new SqlParameter("@qty_weg_rate",Math.Round(objMatMaster.qty_weg_rate,2)),
                   new SqlParameter("@crusr",objMatMaster.crusr),
                   new SqlParameter("@modality",objMatMaster.modality)
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
        /// 編輯物料
        /// </summary>
        /// <param name="objMatMaster"></param>
        /// <returns></returns>
        public static int UpdateMatMaster(mdlMatMaster objMatMaster)
        {
            int Result = 0;
            try
            {
                //, clr_code=@clr_code,  mat_code=@mat_code,  prd_code=@prd_code,   art_code=@art_code,  size_code=@size_code   
                string strSql = @"UPDATE bs_mat_master SET item_desc=@item_desc,    item_cdesc=@item_cdesc,     item_unit=@item_unit,     item_unit1=@item_unit1
                                                         , stork_minq=@stork_minq,  stork_maxq=@stork_maxq,     stork_minw=@stork_minw,   stork_maxw=@stork_maxw, item_cost=@item_cost
                                                         , item_cost1=@item_cost1,  item_waste=@item_waste,     item_type=@item_type,     item_img=@item_img,     item_rmk=@item_rmk
                                                         , item_hscode=@item_hscode,item_hgcode=@item_hgcode,   item_hgtype=@item_hgtype, crdat=@crdat,           prd_dep=@prd_dep
                                                         , item_part=@item_part,    qty_weg_rate=@qty_weg_rate, amusr=@amusr, modality=@modality, amtim=GETDATE()
                                  WHERE prd_item=@prd_item ";

                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@prd_item",objMatMaster.prd_item),
                   new SqlParameter("@item_desc",objMatMaster.item_desc),
                   new SqlParameter("@item_cdesc",objMatMaster.item_cdesc),
                   new SqlParameter("@item_unit",objMatMaster.item_unit),
                   new SqlParameter("@item_unit1",objMatMaster.item_unit1),
                   new SqlParameter("@stork_minq",Math.Round(objMatMaster.stork_minq,2)),
                   new SqlParameter("@stork_maxq",Math.Round(objMatMaster.stork_maxq,2)),
                   new SqlParameter("@stork_minw",Math.Round(objMatMaster.stork_minw,2)),
                   new SqlParameter("@stork_maxw",Math.Round(objMatMaster.stork_maxw,2)),
                   new SqlParameter("@item_cost", Math.Round(objMatMaster.item_cost,2)),
                   new SqlParameter("@item_cost1",Math.Round(objMatMaster.item_cost1,2)),
                   new SqlParameter("@item_waste",Math.Round(objMatMaster.item_waste,2)),
                   new SqlParameter("@item_type",objMatMaster.item_type),
                   new SqlParameter("@item_img",objMatMaster.item_img),
                   new SqlParameter("@item_rmk",objMatMaster.item_rmk),
                   new SqlParameter("@item_hscode",objMatMaster.item_hscode),
                   new SqlParameter("@item_hgcode",objMatMaster.item_hgcode),
                   new SqlParameter("@item_hgtype",objMatMaster.item_hgtype),
                   new SqlParameter("@crdat",objMatMaster.crdat),
                   new SqlParameter("@prd_dep",objMatMaster.prd_dep),
                   new SqlParameter("@item_part",objMatMaster.item_part),
                   ////new SqlParameter("@mat_code",objMatMaster.mat_code),
                   ////new SqlParameter("@prd_code",objMatMaster.prd_code),
                   ////new SqlParameter("@art_code",objMatMaster.art_code),
                   ////new SqlParameter("@size_code",objMatMaster.size_code),
                   //new SqlParameter("@clr_code",objMatMaster.clr_code),
                   new SqlParameter("@qty_weg_rate",Math.Round(objMatMaster.qty_weg_rate,2)),
                   new SqlParameter("@amusr",objMatMaster.amusr),
                   new SqlParameter("@modality",objMatMaster.modality)
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
        /// 刪除物料
        /// </summary>
        /// <param name="pPrd_item"></param>
        /// <returns></returns>
        public static int DeleteMatMaster(string pPrd_item)
        {
            int Result = 0;
            try
            {
                string strSql = @"DELETE FROM bs_mat_master WHERE prd_item=@prd_item ";
                SqlParameter[] paras = new SqlParameter[]{
                   new SqlParameter("@prd_item",pPrd_item)
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
        /// 根據條件獲取物料
        /// </summary>
        /// <param name="pPrd_item"></param>
        /// <param name="pPrd_en_desc"></param>
        /// <param name="pPrd_chs_desc"></param>
        /// <returns></returns>
        public static DataTable GetMatMaster(string pPrd_item, string pPrd_en_desc, string pPrd_chs_desc)
        {
            DataTable dtMaster = new DataTable();
            try
            {
                string strSql = @"SELECT prd_item, item_desc as mat_desc, item_cdesc as mat_cdesc, item_unit as base_unit, item_unit1 as mt_unit1
                                       , stork_minq, stork_maxq, stork_minw, stork_maxw, item_cost as qty_cost
                                       , item_cost1 as weg_cost, item_waste as waste, item_type, item_img as art_image, item_rmk as remark
                                       , item_hscode as customs_code, item_hgcode as customs_number, item_hgtype as encode_type, crdat as bill_date, prd_dep as dept_id
                                       , item_part as Match_type, mat_code, prd_code, art_code as art, size_code as size_id
                                       , clr_code as color_code, qty_weg_rate as qty_weg_rate, crusr, crtim, amusr, amtim ,modality
                                FROM bs_mat_master ";
                if (pPrd_item != "")
                {
                    strSql += "WHERE prd_item= '" + pPrd_item + "' ";
                    if (pPrd_en_desc != "")
                    {
                        strSql += "AND item_desc LIKE'%" + pPrd_en_desc + "%' ";
                    }

                    if (pPrd_chs_desc != "")
                    {
                        strSql += "AND item_cdesc LIKE'%" + pPrd_chs_desc + "%' ";
                    }
                }
                else
                {
                    if (pPrd_en_desc != "")
                    {
                        strSql += "WHERE item_desc LIKE'%" + pPrd_en_desc + "%' ";

                        if (pPrd_chs_desc != "")
                        {
                            strSql += "AND item_cdesc LIKE'%" + pPrd_chs_desc + "%' ";
                        }
                    }
                    else
                    {
                        if (pPrd_chs_desc != "")
                        {
                            strSql += "WHERE item_cdesc LIKE'%" + pPrd_chs_desc + "%' ";
                        }
                    }
                }

                dtMaster = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtMaster;
        }

    }
}
