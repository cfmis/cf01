using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsMo_for_jx
    {
        /// <summary>
        /// 工序卡(frmOrderProCard)中獲取生產計劃資料
        /// </summary>
        /// <param name="wp_id"></param>
        /// <param name="mo_id"></param>
        /// <param name="goods_id"></param>
        /// <returns></returns>
        private readonly static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private readonly static string within_code = DBUtility.within_code;
        private readonly static string remote_db = DBUtility.remote_db;
        public static DataTable GetGoods_DetailsById(string wp_id, string mo_id, string goods_id)
        {
            string strSql = "";
            strSql=String.Format(
                @"SELECT b.wp_id, a.mo_id, b.goods_id, c.name, b.prod_qty, b.within_code" +
                  ",b.OBLIGATE_QTY, a.bill_date,b.t_complete_date,b.next_wp_id,d.name AS next_wp_name" +
                  ",a.check_date, b.goods_unit, a.customer_id, e.brand_id, e.get_color_sample" +
                  ",e.goods_unit AS order_unit, f.production_remark, f.nickle_free, f.plumbum_free, a.remark" +
                  ",convert(int,g.base_qty) as base_qty, g.unit_code, convert(int,g.rate) AS base_rate, g.basic_unit, b.vendor_id" +
                  ",CONVERT(Decimal(10), b.c_sec_qty_ok) as c_sec_qty_ok, dp.name as get_color_sample_name, a.id, a.ver" +
                  ",b.sequence_id, c.blueprint_id, CONVERT(Decimal(10),b.predept_rechange_qty) AS predept_rechange_qty, c.color" +
                  ",b.flevel,c.color as color_id,h.do_color, h.name as color_name" +
                " FROM  " + remote_db + "jo_bill_mostly a with(nolock)" +
                " INNER JOIN " + remote_db + "jo_bill_goods_details b with(nolock) ON a.within_code = b.within_code AND  a.id = b.id AND  a.ver = b.ver " +
                " INNER JOIN " + remote_db + "it_goods c with(nolock) ON b.within_code = c.within_code AND  b.goods_id = c.id" +
                " INNER JOIN " + remote_db + "cd_department d ON b.within_code=d.within_code And b.next_wp_id=d.id" +
                " LEFT JOIN " + remote_db + "so_order_details e with(nolock) ON a.within_code=e.within_code AND a.mo_id=e.mo_id AND a.so_sequence_id=e.sequence_id" +
                " LEFT JOIN " + remote_db + "so_order_special_info f with(nolock) ON e.within_code=f.within_code AND e.id=f.id AND e.ver=f.ver AND e.sequence_id=f.upper_sequence " +
                " LEFT JOIN " + remote_db + "it_coding g with(nolock) On b.within_code=g.within_code AND b.goods_id=g.id" +
                " LEFT JOIN " + remote_db + "cd_department dp ON e.within_code=dp.within_code and e.get_color_sample=dp.id" +
                " LEFT JOIN "+remote_db+"cd_color h ON c.within_code=h.within_code AND c.color=h.id"+
                " WHERE a.within_code='{0}' and b.wp_id ='{1}' and  a.mo_id ='{2}'", "0000", wp_id, mo_id);
            //"," + remote_db + "Fn_z_get_wh_location(b.goods_id,b.next_wp_id) as wh_location
            if (goods_id != "")
                strSql += String.Format(" AND b.goods_id='{0}' ", goods_id);
            DataTable dtGoods = clsPublicOfCF01.GetDataTable(strSql);
            if(dtGoods.Rows.Count>0)
            {
                dtGoods.Columns.Add("wh_location", typeof(string));
                for (int i=0;i<dtGoods.Rows.Count;i++)
                {
                    string goods_id1 = dtGoods.Rows[i]["goods_id"].ToString();
                    string next_wp_id = dtGoods.Rows[i]["next_wp_id"].ToString();
                    strSql = "Select dbo.Fn_z_get_wh_location(" + "'" + goods_id1 + "'" + ",'" + next_wp_id + "') as wh_location";
                    DataTable dt = clsConErp.GetDataTable(strSql);
                    //        SqlParameter[] paras = new SqlParameter[] {
                    //   new SqlParameter("@goods_id",goods_id1),
                    //   new SqlParameter("@dept_id",next_wp_id)
                    //};
                    //        DataTable dt = clsConErp.ExecuteProcedureReturnTable("Fn_z_get_wh_location", paras);
                    if (dt.Rows.Count > 0)
                        dtGoods.Rows[i]["wh_location"] = dt.Rows[0]["wh_location"].ToString();
                }
            }
            return dtGoods;
        }
        
        /// <summary>
        /// 取補單頁數正單的生產備註
        /// </summary>
        /// <param name="mo_id"></param>
        /// <returns></returns>
        public static string Get_Repair_Mo_Product_Remark(string mo_id)
        {
            string ls_remark="", ls_repair_mo_id;            
            string strSql = string.Format("SELECT repair_mo_id FROM jo_production_repair_mostly with(nolock) WHERE mo_id='{0}'", mo_id);
            ls_repair_mo_id = clsConErp.ExecuteSqlReturnObject(strSql);
            strSql = string.Format(
                @"SELECT REPLACE(replace(replace(B.production_remark,CHAR(10),''),CHAR(13),''),' ','') as production_remark
                FROM so_order_details A with(nolock),so_order_special_info B with(nolock) 
                WHERE A.within_code=B.within_code and A.id=B.id and A.ver=B.ver and A.sequence_id=B.upper_sequence And A.mo_id='{0}'", ls_repair_mo_id);
            ls_remark = clsConErp.ExecuteSqlReturnObject(strSql);
            return ls_remark;
        }

        /// <summary>
        /// 獲取顏色編號、名稱、顏色做法
        /// </summary>
        /// <param name="wp_id"></param>
        /// <param name="mo_id"></param>
        /// <param name="goods_id"></param>
        /// <returns></returns>
        public static DataTable GetColorInfo(string wp_id, string mo_id, string goods_id)
        {
            DataTable dtColorInfo = new DataTable();
            string strSql = @"SELECT A.mo_id, C.materiel_id,C.goods_id, G.do_color, D.name as color_name,G.color as color_id"+
                              " FROM jo_bill_mostly A with(nolock)"+
                              " INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code = B.within_code AND A.id = B.id AND A.ver = B.ver "+
                              " INNER JOIN jo_bill_materiel_details C with(nolock) ON B.within_code = C.within_code AND B.id = C.id AND B.ver = C.ver AND B.sequence_id = C.upper_sequence "+
                              " INNER JOIN it_goods G with(nolock) ON C.within_code = G.within_code AND C.goods_id = G.id "+
                              " INNER JOIN cd_color D with(nolock) ON G.within_code = D.within_code AND G.color = D.id"+
                              " WHERE A.within_code = '0000'";
            if (mo_id != "" && wp_id != "" && goods_id != "")
            {
                strSql += String.Format(" AND A.mo_id = '{0}'", mo_id);
                strSql += String.Format(" AND B.wp_id = '{0}'", wp_id);
                strSql += String.Format(" AND B.goods_id='{0}'", goods_id);
                //"AND C.materiel_id = ''"
            }
            dtColorInfo = clsConErp.GetDataTable(strSql);
            return dtColorInfo;
        }


        /// <summary>
        /// 從OC中獲取訂單數量
        /// </summary>
        /// <param name="mo_id"></param>
        /// <returns></returns>
        public static DataTable GetOrderQty(string mo_id)
        {
            DataTable dtQty = new DataTable();

                string strSQL = String.Format(@"SELECT a.order_qty,convert(int,a.order_qty*b.rate) as order_qty_pcs,a.goods_unit,a.plate_remark" +
                                                " FROM so_order_details a with(nolock) "+
                                                " LEFT OUTER JOIN it_coding b with(nolock) On a.within_code=b.within_code AND a.goods_unit=b.unit_code"+
                                                " WHERE  a.within_code = '0000' AND  a.mo_id ='{0}' and b.id='*'", mo_id);

                dtQty = clsConErp.GetDataTable(strSQL);
            return dtQty;
        }

        /// <summary>
        /// 從OC中獲取電鍍備註
        /// </summary>
        /// <param name="mo_id"></param>
        /// <returns></returns>
        public static DataTable Get_Plate_Remark(string mo_id)
        {
            DataTable dtPlate_Remark = new DataTable();
            try
            {
                string strSQL = String.Format(@"SELECT plate_remark"+
                    " FROM so_order_details with(nolock) WHERE within_code = '0000' AND mo_id ='{0}'", mo_id);
                dtPlate_Remark = clsConErp.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPlate_Remark;
        }

        /// <summary>
        /// 從OC中獲取訂單數量(Bom 用量)
        /// </summary>
        /// <param name="mo_id"></param>
        /// <returns></returns>
        public static DataTable GetOrderQtyBasedOnBom(string mo_id, string goods_id)
        {
            DataTable dtQty = new DataTable();
            try
            {
                string strSQL = String.Format(
                  @" SELECT a.order_qty*b.dosage as order_qty,convert(int,a.order_qty*c.rate*b.dosage) as order_qty_pcs,a.goods_unit
                    FROM dbo.so_order_details a with(nolock)
                    LEFT JOIN so_order_bom b with(nolock) on a.within_code=b.within_code AND a.id =b.id AND a.sequence_id =b.upper_sequence
                    LEFT JOIN dbo.it_coding c with(nolock) On a.within_code=c.within_code AND a.goods_unit=c.unit_code
                    WHERE a.within_code = '0000' AND  a.mo_id = '{0}' and c.id='*' AND b.goods_id ='{1}'", mo_id, goods_id);
                dtQty = clsConErp.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtQty;
        }

        /// <summary>
        ///工序卡(frmOrderProCard)中獲取物料編號、圖樣的資料
        /// </summary>
        /// <param name="goods_item"></param>
        /// <returns></returns>
        public static DataTable GetGoods_ArtWork(string goods_item)
        {
            DataTable dtArt = new DataTable();
            try
            {
                string strSQL = String.Format(
                     @"SELECT TOP 1 b.sequence_id AS art_id,b.picture_name"+
                      " FROM it_goods a with(nolock)"+
                      " LEFT JOIN cd_pattern_details b ON a.within_code=b.within_code AND a.blueprint_id=b.id"+
                      " WHERE a.within_code='0000' and a.id = '{0}'", goods_item);
                //string strSQL = String.Format(@"Select dbo.Fn_get_picture_name('0000','{0}','OUT') AS picture_name", goods_item);
                dtArt = clsConErp.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtArt;
        }

        /// <summary>
        /// 根據產品類型、圖樣代號，尺寸獲取模具存放位置
        /// </summary>
        /// <param name="prd_item">根據傳入的產品編號截取以上條件</param>
        /// <returns>String</returns>
        public static DataTable GetPosition(string prd_item)
        {
            DataTable dtPosition = new DataTable();
                if (prd_item != "" || prd_item != null)
                {
                    string products_type = prd_item.Substring(2, 2);
                    string pattern_id = prd_item.Substring(4, 7);
                    string measurement = prd_item.Substring(11, 3);

                    string strSQL = String.Format(
                      @"SELECT id,mould_no FROM cd_mould_position "+
                       " WHERE products_type='{0}' AND pattern_id='{1}' AND measurement='{2}'", 
                       products_type, pattern_id, measurement);

                    dtPosition = clsConErp.GetDataTable(strSQL);
                }
            return dtPosition;
        }

        //獲取電鍍顏色
        public static DataTable GetColor(string mo_id, string goods_id, string next_wp_id)
        {
            DataTable dtColor = new DataTable();
            try
            {
                string strSQL = String.Format(
                    @"SELECT a.mo_id, c.sequence_id,c.materiel_id, b.goods_id,e.name AS color_desc, d.do_color, b.next_wp_id,b.wp_id
                    From jo_bill_mostly a with(nolock)
                    Inner Join jo_bill_goods_details b with(nolock) on a.within_code=b.within_code and a.id=b.id and a.ver=b.ver
                    Inner Join jo_bill_materiel_details c with(nolock) on b.within_code=c.within_code AND b.id=c.id AND b.ver=c.ver AND b.sequence_id=c.upper_sequence
                    Inner Join it_goods d with(nolock) on b.within_code=d.within_code and b.goods_id=d.id
                    Left Join cd_color e on d.within_code=e.within_code and d.color=e.id
                    Where a.within_code='0000' and a.mo_id='{0}' and c.materiel_id='{1}' and b.wp_id='{2}'", mo_id, goods_id, next_wp_id);

                dtColor = clsConErp.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtColor;
        }


        /// <summary>
        /// 工序卡(frmOrderProCard)中獲取物料編號、圖樣的資料
        /// </summary>
        /// <param name="goods_item"></param>
        /// <returns></returns>
        public static DataTable GetGoods_Size(string size_id)
        {
            DataTable dtSize = new DataTable();
            try
            {
                string strSQL = String.Format(@"SELECT a.name AS size_name FROM dbo.cd_size a WHERE a.within_code='0000' and a.id='{0}'", size_id);

                dtSize = clsConErp.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtSize;
        }


        /// <summary>
        /// 單位轉換
        /// </summary>
        /// <param name="basic_unit"></param>
        /// <param name="UnitValue"></param>
        /// <returns></returns>

        public static double UnitConversionRate(string basic_unit, double UnitValue)
        {
            double resultValue = 0;
            DataTable dtUnitRate = new DataTable();
            try
            {
                string strSQL = String.Format(@"SELECT rate FROM dbo.it_coding a WHERE a.within_code='0000' and a.id='*' and a.unit_code='{0}'", basic_unit);
                dtUnitRate = clsConErp.GetDataTable(strSQL);
                if (dtUnitRate.Rows.Count > 0)
                {
                    resultValue = UnitValue * Convert.ToDouble(dtUnitRate.Rows[0]["rate"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return resultValue;
        }

        public static DataTable CheckIsLock(string wp_id, string mo_id, string goods_id)
        {
            DataTable dtLockInfo = new DataTable();
            try
            {
                string strSQL = String.Format(
                @"SELECT apr_usr,apr_tim FROM mo_for_jx 
                  WHERE mo_id='{0}' AND wp_id='{1}' AND goods_id='{2}'", mo_id, wp_id, goods_id);
                strSQL += " AND apr_usr IS NOT NULL AND apr_tim IS NOT NULL ";

                dtLockInfo = clsPublicOfCF01.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtLockInfo;
        }


        public static int AddMo_for_jx(Mo_for_jx pModel)
        {
            int Result = -1;

            string strIsExsit = clsPublicOfCF01.ExecuteSqlReturnObject(
                string.Format(@"SELECT mo_id FROM mo_for_jx WHERE mo_id='{0}' AND wp_id='{1}' AND goods_id='{2}'", pModel.mo_id, pModel.wp_id, pModel.goods_id));
            if (strIsExsit == "")
            {
                const string strSQL = 
                 @"INSERT INTO mo_for_jx( mo_date, mo_id, wp_id, goods_id ,goods_name, prod_qty, rmk, cr_usr, cr_tim,order_qty,chk_dat,t_dat,next_wp_id,next_wp_name,ver,color_desc,do_color,id,sequence_id,within_code)
                   VALUES(@mo_date, @mo_id, @wp_id, @goods_id ,@goods_name, @prod_qty, @rmk, @cr_usr, @cr_tim,@order_qty,@chk_dat,@t_dat,@next_wp_id,@next_wp_name,@ver,@color_desc,@do_color,@id,@sequence_id,@within_code)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mo_date",pModel.mo_date),
                    new SqlParameter("@mo_id",pModel.mo_id),
                    new SqlParameter("@wp_id",pModel.wp_id),
                    new SqlParameter("@goods_id",pModel.goods_id),
                    new SqlParameter("@goods_name",pModel.goods_name),
                    new SqlParameter("@prod_qty",pModel.prod_qty),
                    new SqlParameter("@rmk",pModel.rmk),
                    new SqlParameter("@cr_usr",pModel.cr_usr),
                    new SqlParameter("@cr_tim",pModel.cr_tim),
                    new SqlParameter("@order_qty",pModel.order_qty),
                    new SqlParameter("@chk_dat",pModel.check_date),
                    new SqlParameter("@t_dat",pModel.t_complete_date),
                    new SqlParameter("@next_wp_id",pModel.next_wp_id),
                    new SqlParameter("@next_wp_name",pModel.next_wp_name),
                    new SqlParameter("@ver",pModel.ver),
                    new SqlParameter("@color_desc",pModel.color_desc),
                    new SqlParameter("@do_color",pModel.do_color),
                    new SqlParameter("@id",pModel.id),
                    new SqlParameter("@sequence_id",pModel.sequence_id),
                    new SqlParameter("@within_code",pModel.within_code)
                 };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);
            }
            else
            {
                MessageBox.Show("該條數據已存在，請重新輸入信息。");
            }

            return Result;
        }

        public static int DelMo_for_jxLock(string wp_id, string mo_id, string goods_id)
        {
            int Result = -1;
            const string strSQL = @"DELETE FROM mo_for_jx WHERE mo_id=@mo_id AND wp_id=@wp_id AND goods_id=@goods_id ";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@mo_id",mo_id),
                new SqlParameter("@wp_id",wp_id),
                new SqlParameter("@goods_id",goods_id)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);
            return Result;
        }

        public static int UpdateMo_for_jxLock(Mo_for_jx pModel)
        {
            int Result = -1;
            string strSQL = "";
            SqlParameter[] paras = null;
            if (pModel.apr_usr != null && pModel.apr_tim != null)
            {
                strSQL += @"UPDATE mo_for_jx SET apr_usr=@apr_usr, apr_tim=@apr_tim WHERE mo_id=@mo_id AND wp_id=@wp_id AND goods_id=@goods_id";
                paras = new SqlParameter[] { 
                    new SqlParameter("@apr_usr",pModel.apr_usr),
                    new SqlParameter("@apr_tim",pModel.apr_tim),
                    new SqlParameter("@mo_id",pModel.mo_id),
                    new SqlParameter("@wp_id",pModel.wp_id),
                    new SqlParameter("@goods_id",pModel.goods_id)
                };
            }
            else
            {
                strSQL += @"UPDATE mo_for_jx SET apr_usr=NULL, apr_tim=NULL WHERE mo_id=@mo_id AND wp_id=@wp_id AND goods_id=@goods_id";
                paras = new SqlParameter[] { 
                    new SqlParameter("@mo_id",pModel.mo_id),
                    new SqlParameter("@wp_id",pModel.wp_id),
                    new SqlParameter("@goods_id",pModel.goods_id)
                };
            }

            Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);

            return Result;
        }

        public static int UpdateMo_for_jx(Mo_for_jx pModel)
        {
            int Result = -1;

            const string strSQL = @"UPDATE mo_for_jx SET prod_qty=@prod_qty ,am_usr=@am_usr, am_tim=@am_tim,rmk=@rmk,order_qty=@order_qty
                                    ,t_dat=@t_dat,chk_dat=@chk_dat,next_wp_id=@next_wp_id,next_wp_name=@next_wp_name,color_desc=@color_desc,do_color=@do_color
                                    WHERE  mo_id=@mo_id AND wp_id=@wp_id AND goods_id=@goods_id";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@prod_qty",pModel.prod_qty),
                new SqlParameter("@am_usr",pModel.am_usr),
                new SqlParameter("@am_tim",pModel.am_tim),
                new SqlParameter("@mo_id",pModel.mo_id),
                new SqlParameter("@wp_id",pModel.wp_id),
                new SqlParameter("@rmk",pModel.rmk),
                new SqlParameter("@goods_id",pModel.goods_id),
                new SqlParameter("@order_qty",pModel.order_qty),
                new SqlParameter("@t_dat",pModel.t_complete_date),
                new SqlParameter("@chk_dat",pModel.check_date),
                new SqlParameter("@next_wp_id",pModel.next_wp_id),
                new SqlParameter("@next_wp_name",pModel.next_wp_name),
                new SqlParameter("@color_desc",pModel.color_desc),
                new SqlParameter("@do_color",pModel.do_color)
            };
            Result = clsPublicOfCF01.ExecuteNonQuery(strSQL, paras, false);

            return Result;
        }

        public static DataTable GetMo_for_jx(string pMo_id, string pWp_id, string pGoods_id)
        {
            DataTable dtMo_for_jx = new DataTable();

            string strSQL = @"SELECT mo_date, mo_id, wp_id, goods_id ,goods_name, prod_qty, rmk, cr_usr,chk_dat,order_qty,t_dat,next_wp_id,next_wp_name,cr_tim, am_usr, am_tim FROM mo_for_jx ";

            if (pMo_id != "")
            {
                strSQL += String.Format(" WHERE mo_id ='{0}'", pMo_id);
                if (pWp_id != "")
                {
                    strSQL += String.Format(" AND wp_id ='{0}' ", pWp_id);
                }
                if (pGoods_id != "")
                {
                    strSQL += String.Format(" AND goods_id ='{0}' ", pGoods_id);
                }
            }
            else
            {
                if (pWp_id != "")
                {
                    strSQL += String.Format(" WHERE wp_id ='{0}' ", pWp_id);

                    if (pGoods_id != "")
                    {
                        strSQL += String.Format(" AND goods_id ='{0}' ", pGoods_id);
                    }
                }
                else
                {
                    if (pGoods_id != "")
                    {
                        strSQL += String.Format(" WHERE goods_id ='{0}' ", pGoods_id);
                    }
                }
            }

            dtMo_for_jx = clsPublicOfCF01.GetDataTable(strSQL);

            return dtMo_for_jx;
        }

        /// <summary>
        /// 根據傳入字符串返回條碼值
        /// </summary>
        /// <param name="pBarCodeSource"></param>
        /// <returns></returns>
        public static string ReturnBarCode(string pBarCodeSource)
        {
            string BarCode = "";
            //try
            //{
            //    DataTable dtBarCode = new DataTable();
            //    using (SqlConnection conn = new SqlConnection(DBUtility.conn_str_dgerp2))
            //    {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        const string strSQL = @"select dbo.StrToCode128B(rtrim(@ItemCode)) AS item_barcode ";
            //        cmd.Parameters.Add(new SqlParameter("@ItemCode", pBarCodeSource));
            //        cmd.CommandText = strSQL;
            //        cmd.Connection = conn;
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        da.Fill(dtBarCode);
            //    }

            //    if (dtBarCode.Rows.Count > 0)
            //    {
            //        BarCode = dtBarCode.Rows[0]["item_barcode"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //const string strSQL = @"select dbo.StrToCode128B(rtrim(@ItemCode)) AS item_barcode ";
            string strSql = "Select dbo.StrToCode128B(" + "'" + pBarCodeSource + "') as item_barcode";
            //SqlParameter[] paras = new SqlParameter[] {
            //    new SqlParameter("@Str", pBarCodeSource)
            //};
            //DataTable dt = clsConErp.ExecuteProcedureReturnTable("StrToCode128B", paras);
            DataTable dt = clsConErp.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
                BarCode = dt.Rows[0]["item_barcode"].ToString();
            return BarCode;
        }

        /// <summary>
        /// 查詢貨倉位置
        /// </summary>
        /// <param name="goods_id"></param>
        /// <param name="next_wp_id"></param>
        /// <returns></returns>
        public static string ReturnGoodsPosition(string pGoods_id, string pNext_wp_id)
        {
            string strGoodsPosition = "";
            try
            {
                DataTable dtCartonCode = new DataTable();

                string strSQL = String.Format(@"SELECT carton_code "+
                    " FROM it_goods_location with(nolock) WHERE within_code='{2}' and id='{0}' and location_id='{1}'", pGoods_id, pNext_wp_id,within_code);
                dtCartonCode = clsConErp.GetDataTable(strSQL);

                if (dtCartonCode.Rows.Count > 0)
                {
                    if (dtCartonCode.Rows.Count > 1)
                    {
                        for (int i = 0; i < dtCartonCode.Rows.Count; i++)
                        {
                            strGoodsPosition += dtCartonCode.Rows[i]["carton_code"] + ";";
                        }
                    }
                    else
                    {
                        strGoodsPosition = dtCartonCode.Rows[0]["carton_code"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return strGoodsPosition;
        }

        /// <summary>
        /// 獲取江西制單資料
        /// </summary>
        /// <param name="dept1"></param>
        /// <param name="dept2"></param>
        /// <param name="crtim1"></param>
        /// <param name="crtim2"></param>
        /// <param name="mo_id1"></param>
        /// <param name="mo_id2"></param>
        /// <returns></returns>
        public static DataTable GetMoDataForJX(string dept1, string dept2, string crtim1, string crtim2, string mo_id1, string mo_id2)
        {
            DataTable dtMoData = new DataTable();            
            SqlParameter[] paras = new SqlParameter[] {
               new SqlParameter("@Dept1",dept1),
               new SqlParameter("@Dept2",dept2),
               new SqlParameter("@Cr_tim1",crtim1),
               new SqlParameter("@Cr_tim2",crtim2),
               new SqlParameter("@Mo_id1",mo_id1),
               new SqlParameter("@Mo_id2",mo_id2)
            };

            dtMoData = clsPublicOfCF01.ExecuteProcedureReturnTable("GetMoForJX_NEW", paras);

            return dtMoData;
        }

        /// <summary>
        ///獲取啤數、工序 
        /// </summary>
        /// <param name="pGoods_id"></param>
        /// <returns></returns>
        public static DataTable GetPeQtyAndStep(string pGoods_id)
        {
            DataTable dtPs = new DataTable();
            try
            {
                string strSql = String.Format(
                      @"SELECT a.id,b.dosage,b.unit_code,b.base_qty,'' as pe_qty,'' as step" +
                        " FROM it_bom_mostly a with(nolock)" +
                        " LEFT JOIN it_bom b with(nolock) ON a.within_code=b.within_code and a.id=b.id AND a.exp_id=b.exp_id" +
                        " WHERE a.within_code='{0}' AND a.goods_id='{1}'", within_code, pGoods_id);
                dtPs = clsConErp.GetDataTable(strSql);

                if (dtPs.Rows.Count > 0)
                {
                    dtPs.Rows[0]["pe_qty"] = 
                        String.Format("{0}{1}/{2}PCS", Convert.ToDouble(dtPs.Rows[0]["dosage"]), dtPs.Rows[0]["unit_code"], dtPs.Rows[0]["base_qty"]);

                    //根據上面查詢的bom id ,獲取工序

                    DataTable dtstep = new DataTable();
                    strSql = String.Format(@"SELECT A.process_id+B.Proc_Name as step FROM aps_it_bom_details A
                                            LEFT JOIN Process B ON A.within_code=B.within_code AND A.process_id=B.Proc_Code
                                            WHERE bom_id='{0}'", dtPs.Rows[0]["id"]);
                    dtstep = clsConErp.GetDataTable(strSql);

                    if (dtstep.Rows.Count > 0)
                    {
                        string strStep = "";
                        for (int i = 0; i < dtstep.Rows.Count; i++)
                        {
                            strStep += dtstep.Rows[i]["step"] + " ";
                        }

                        dtPs.Rows[0]["step"] = strStep;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPs;
        }

        /// <summary>
        ///獲取合金部啤貨的下層物料資料
        /// </summary>       
        /// <param name="pMo_id"></param>
        /// <param name="pGoods_id"></param>
        /// <param name="pDept"></param>
        /// <returns></returns>
        public static DataTable GetNextGoods_Id(string pMo_id, string pGoods_id, string pDept)
        {
            DataTable dtPs = new DataTable();

            string strSql = string.Format(
                            @"SELECT B.goods_id,B.sup_bom_no,B.wp_id,B.next_wp_id,C.name AS goods_name,D.name AS dept_name
                                FROM jo_bill_mostly A with(nolock)
	                            INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver
	                            INNER JOIN it_goods C with(nolock) ON B.within_code=C.within_code AND B.sup_bom_no=C.id 
	                            LEFT JOIN cd_department D with(nolock) ON B.within_code=D.within_code AND B.next_wp_id=D.id
                                WHERE A.within_code='0000' AND A.mo_id='{0}' AND B.goods_id='{1}' AND B.wp_id='{2}' AND B.next_wp_id NOT IN('702','722')",
                            pMo_id, pGoods_id, pDept);

            /*string strSql = string.Format(
                            @"SELECT B.goods_id,
                             CASE WHEN ISNULL(B.sup_bom_no,'')<>'' THEN B.sup_bom_no ELSE dbo.fn_z_get_sup_bom_no('{2}','{0}','{1}') END AS sup_bom_no
                            ,B.wp_id,B.next_wp_id,C.name AS goods_name,D.name AS dept_name
                            FROM jo_bill_mostly A with(nolock)
                            INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver
                            INNER JOIN it_goods C with(nolock) ON B.within_code=C.within_code 
                            AND CASE WHEN ISNULL(B.sup_bom_no,'')<>'' THEN B.sup_bom_no ELSE dbo.fn_z_get_sup_bom_no('{2}','{0}','{1}') END = C.id
                            LEFT JOIN cd_department D with(nolock) ON B.within_code=D.within_code AND B.next_wp_id=D.id
                            WHERE A.within_code='0000' AND A.mo_id='{0}' AND B.goods_id='{1}' AND B.wp_id='{2}' AND B.next_wp_id<>'702'",
                            pMo_id, pGoods_id, pDept);
                            */
            dtPs = clsConErp.GetDataTable(strSql);
            if (dtPs.Rows.Count == 0)
            {
                //手動加的流程此字段sup_bom_no為空則執行此查找
                strSql = string.Format(
                            @"SELECT B.goods_id,S2.sup_bom_no,B.wp_id,B.next_wp_id,C.name AS goods_name,D.name AS dept_name
                            FROM jo_bill_mostly A with(nolock)
                            INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver
                            INNER JOIN 
                                (SELECT jo.within_code,jo.id,jo.ver,jo.goods_id as sup_bom_no
                                FROM jo_bill_goods_details jo with(nolock) 
                                INNER JOIN (SELECT TOP 1 cc.within_code,cc.id,cc.ver,cc.upper_sequence
			                                  FROM jo_bill_mostly aa with(nolock)
			                                  INNER JOIN jo_bill_goods_details bb with(nolock) ON aa.within_code=bb.within_code AND aa.id=bb.id AND aa.ver=bb.ver
			                                  INNER JOIN jo_bill_materiel_details cc with(nolock) ON bb.within_code=cc.within_code AND bb.id=cc.id and bb.ver=cc.ver and cc.materiel_id = '{1}'
			                                  WHERE aa.within_code='0000' AND aa.mo_id='{0}' AND bb.goods_id='{1}' AND bb.wp_id='{2}' AND bb.next_wp_id NOT IN('702','722')
		                                   ) S1 ON jo.within_code=S1.within_code AND jo.id=S1.id AND jo.ver=S1.ver AND jo.sequence_id=S1.upper_sequence
                                ) S2 ON B.within_code=S2.within_code AND B.id =S2.id AND B.ver =S2.ver 
                            INNER JOIN it_goods C with(nolock) ON S2.within_code=C.within_code AND S2.sup_bom_no=C.id
                            LEFT JOIN cd_department D with(nolock) ON B.within_code=D.within_code AND B.next_wp_id=D.id
                            WHERE A.within_code='0000' AND A.mo_id='{0}' AND B.goods_id='{1}' AND B.wp_id='{2}' AND B.next_wp_id NOT IN('702','722')",
                            pMo_id, pGoods_id, pDept);
                dtPs = clsConErp.GetDataTable(strSql);
            }

            return dtPs;
        }

        /// <summary>
        ///是否存在設置對照料表
        /// </summary>       
        /// <param name="pDept"></param>
        /// <param name="pMat_Goods_id"></param>
        /// <param name="pGoods_id"></param>
        /// <returns></returns>
        public static DataTable GetSet_Process_Data(string pDept, string pMat_Goods_id, string pGoods_id)
        {
            DataTable dtPs = new DataTable();
            try
            {
                string strSql = string.Format(@"Select remark From bs_process_goods with(nolock) Where prd_dep='{0}' and mat_item='{1}' and prd_item='{2}'", pDept, pMat_Goods_id, pGoods_id);
                dtPs = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPs;
        }


        /// <summary>
        /// 獵取工序數據
        /// </summary>
        /// <param name="pDept"></param>
        /// <returns></returns>
        public static DataTable Get_Process_Data(string pDept)
        {
            DataTable dtPs = new DataTable();
            try
            {
                string strSql = string.Format(@"SELECT id,cdesc,goods_size,process_color,artwork_shape FROM bs_process_group_head with(nolock) WHERE prd_dep='{0}'", pDept);
                dtPs = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtPs;
        }

        /// <summary>
        /// 根據產品類型、尺寸、顏色過慮出工序作爲下拉表框的數據源
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pGoods_id"></param>
        /// <returns></returns>
        public static DataTable Get_Process_Data(string pDept, string pGoods_id)
        {
            DataTable dtProcess_Data = new DataTable();
            const string strProc = @"usp_find_process_code";
            SqlParameter[] paras = new SqlParameter[] {
               new SqlParameter("@dept",pDept),
               new SqlParameter("@goods_id",pGoods_id)               
            };

            dtProcess_Data = clsPublicOfCF01.ExecuteProcedureReturnTable(strProc, paras);

            return dtProcess_Data;
        }

        /// <summary>
        /// 從視圖中取工序列表
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pProcess_Group_id"></param>
        /// <returns></returns>
        public static DataTable Get_Process_List(string pDept, string pProcess_Group_id)
        {
            DataTable dtProcess = new DataTable();
            try
            {
                string strSql = string.Format(
                      @"SELECT process_id,cdesc,rotate_speed,grind_ratio,grind_stone,polished_beads,grind_time
                      FROM dbo.v_process_details WHERE prd_dep='{0}' AND id='{1}'", pDept, pProcess_Group_id);
                dtProcess = clsPublicOfCF01.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtProcess;
        }

        /// <summary>
        /// 保存工序資料
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pMat_Goods_id"></param>
        /// <param name="pGoods_id"></param>
        /// <param name="pGroup_id"></param>
        public static void Save_Process_Data(string pDept, string pMat_Goods_id, string pGoods_id, string pGroup_id)
        {
            const string sql_i = @"Insert bs_process_goods (prd_dep,mat_item,prd_item,process_group_id,crusr,crtim) 
                           Values(@prd_dep,@mat_item,@prd_item,@process_group_id,@crusr,GETDATE())";
            string sql_f = string.Format(@"Select process_group_id From bs_process_goods WHERE prd_dep='{0}' AND mat_item='{1}' AND prd_item='{2}'",
                                        pDept, pMat_Goods_id, pGoods_id);
            DataTable dtFind = clsPublicOfCF01.GetDataTable(sql_f);
            if (dtFind.Rows.Count == 0)
            {
                Boolean save_flag = false;
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@prd_dep", pDept);
                        myCommand.Parameters.AddWithValue("@mat_item", pMat_Goods_id);
                        myCommand.Parameters.AddWithValue("@prd_item", pGoods_id);
                        myCommand.Parameters.AddWithValue("@process_group_id", pGroup_id);
                        myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        save_flag = true;
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        save_flag = false;
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                        myCon.Dispose();
                        myTrans.Dispose();
                    }
                    if (save_flag)
                        MessageBox.Show("數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string str_old_process_group_id = dtFind.Rows[0]["process_group_id"].ToString();
                DialogResult result = MessageBox.Show(String.Format("註意：已存在一個設置值：\n\n{0}\n\n是否要新值【{1}】覆蓋舊值？", str_old_process_group_id, pGroup_id), "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {                   
                    SqlParameter[] paras = new SqlParameter[] {
                        new SqlParameter("@new_process_group_id",pGroup_id),
                        new SqlParameter("@prd_dep",pDept),
                        new SqlParameter("@mat_item",pMat_Goods_id),
                        new SqlParameter("@prd_item",pGoods_id),
                        new SqlParameter("@old_process_group_id",str_old_process_group_id),
                    };
                    int Result = clsPublicOfCF01.ExecuteNonQuery(@"Update bs_process_goods SET process_group_id=@new_process_group_id 
                            WHERE prd_dep=@prd_dep AND mat_item=@mat_item AND prd_item=@prd_item AND process_group_id=@old_process_group_id", paras, false);
                    if (Result > 0)
                        MessageBox.Show("數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 查找下部門貨品對應的工序組別
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pMO_id"></param>
        /// <param name="pMat_item"></param>
        /// <returns></returns>
        public static string Get_netx_dept_Item(string pDept, string pMO_id, string pMat_item)
        {
            string strResult = "";
            string strSql = string.Format(
                  @"SELECT B.sup_bom_no FROM jo_bill_mostly A with(nolock)
                   INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver                                                
                   WHERE A.mo_id='{0}' AND A.state NOT IN ('2','0') AND B.goods_id='{1}' AND B.wp_id='{2}' AND B.next_wp_id NOT IN('702','722')",
                                                 pMO_id, pMat_item, pDept);
            DataTable dtProcess = clsConErp.GetDataTable(strSql);
            if (dtProcess.Rows.Count > 0)
            {
                string strPrd_item = dtProcess.Rows[0]["sup_bom_no"].ToString();
                strResult = Get_Process_string(pDept, pMat_item, strPrd_item);
            }
            return strResult;
        }

        /// <summary>
        /// 查找工序組別代號
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pMat_item"></param>
        /// <param name="pPrd_item"></param>
        /// <returns></returns>
        public static string Get_Process_string(string pDept, string pMat_item, string pPrd_item)
        {
            string strResult = "";
            string strSql = string.Format("SELECT process_group_id FROM bs_process_goods with(nolock) WHERE prd_dep='{0}' and mat_item='{1}' and prd_item='{2}'", pDept, pMat_item, pPrd_item);
            strResult = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            return strResult;
        }


        /// <summary>
        /// AA
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pMat_item"></param>
        /// <param name="pPrd_item"></param>
        /// <returns></returns>
        public static DataTable Get_Process_AA()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable("SELECT id FROM dbo.bs_process_group_type with(nolock) ORDER BY seq_id");
            return dt;
        }

        /// <summary>
        /// BB
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pMat_item"></param>
        /// <param name="pPrd_item"></param>
        /// <returns></returns>
        public static DataTable Get_Process_BB()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable("SELECT size_id as id,size_min,size_max FROM bs_process_type_size");
            return dt;
        }

        /// <summary>
        /// CC
        /// </summary>
        /// <param name="pDept"></param>
        /// <param name="pMat_item"></param>
        /// <param name="pPrd_item"></param>
        /// <returns></returns>
        public static DataTable Get_Process_CC()
        {
            DataTable dt = clsPublicOfCF01.GetDataTable("SELECT distinct grind_id AS id FROM bs_process_type_color ORDER BY grind_id");
            return dt;
        }

        public static DataTable Get_process_group_id(string pDep, string pProcess_group_id)
        {
            string strSql =
                string.Format(@"SELECT cdesc,goods_size,process_color,artwork_shape
                            FROM bs_process_group_head
                            WHERE prd_dep='{0}' AND id='{1}'", pDep, pProcess_group_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            return dt;
        }

        /// <summary>
        /// 在生產流程中查找當前貨品的父層貨品編碼
        /// </summary>
        /// <param name="pMo"></param>
        /// <param name="pGoods_id"></param>
        /// <param name="pDep"></param>
        /// <returns></returns>
        public static string Get_do_color_next_dep(string pMo,string pGoods_id,string pDep)
        {
            string strSql = String.Format("SELECT dbo.fn_up_level_goods('{0}','{1}','{2}') as goods_id", pMo, pGoods_id, pDep);

            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            string strGoods_id = dt.Rows[0]["goods_id"].ToString();
            string strdo_color = "";
            if (!string.IsNullOrEmpty(strGoods_id))
            {
                strSql = String.Format(
                    @"SELECT B.do_color From dgerp2.cferp.dbo.it_goods A with(nolock) 
                        INNER JOIN dgerp2.cferp.dbo.cd_color B with(nolock) 
                            ON A.within_code=B.within_code AND A.color=B.id
                      Where A.within_code='0000' AND A.id='{0}'", strGoods_id);
                DataTable dtDo_color = new DataTable();
                dtDo_color = clsPublicOfCF01.GetDataTable(strSql);
                strdo_color = dtDo_color.Rows[0]["do_color"].ToString();
            }
            else
                strdo_color = "";
            return strdo_color;
        }

        /// <summary>
        /// 交下部門貨品相關相關信息，返回值包括貨品編號，移交下部門，顏色做法，外發供應商
        /// </summary>
        /// <param name="pMo"></param>
        /// <param name="pGoods_id"></param>
        /// <param name="pflevel"></param>
        /// <returns></returns>
        public static DataTable Get_Next_Department_Flow(string pMo, string pGoods_id, int pflevel)
        {
//          //2019-07-15 取消  pflevel A.flevel={2} 部分手加的流程引起異常
//            string strSql = string.Format(
//                       @"SELECT A.goods_id,A.next_wp_id,A.vendor_id,B.name as next_goods_name,B.do_color,C.name as next_dep_name
//                        FROM 
//                        (select Top 1 A1.within_code,A1.id,A1.ver,ISNULL(B1.materiel_id,'') AS goods_id ,B1.upper_sequence
//                        from jo_bill_mostly A1 with(nolock),jo_bill_materiel_details B1 with(nolock)
//                        where A1.within_code=B1.within_code AND A1.id=B1.id and A1.ver=B1.ver and A1.mo_id ='{0}' and B1.materiel_id='{1}'
//                        ) S
//                        INNER JOIN jo_bill_goods_details A with(nolock) 
//	                        ON S.within_code=A.within_code AND S.id=A.id AND S.ver=A.ver AND S.upper_sequence=A.sequence_id AND A.wp_id<>'702' AND A.flevel={2}
//                        INNER JOIN it_goods B with(nolock) ON A.within_code=A.within_code and A.goods_id=B.id
//                        INNER JOIN cd_department C with(nolock) ON A.within_code=A.within_code AND A.next_wp_id=C.id
//                        ", pMo, pGoods_id, pflevel);
            string strSql = string.Format(
                       @"SELECT A.goods_id,A.next_wp_id,A.vendor_id,B.name as next_goods_name,B.do_color,C.name as next_dep_name
                        FROM 
                        (select Top 1 A1.within_code,A1.id,A1.ver,ISNULL(B1.materiel_id,'') AS goods_id ,B1.upper_sequence
                        from jo_bill_mostly A1 with(nolock),jo_bill_materiel_details B1 with(nolock)
                        where A1.within_code=B1.within_code AND A1.id=B1.id and A1.ver=B1.ver and A1.mo_id ='{0}' and B1.materiel_id='{1}'
                        ) S
                        INNER JOIN jo_bill_goods_details A with(nolock) 
	                        ON S.within_code=A.within_code AND S.id=A.id AND S.ver=A.ver AND S.upper_sequence=A.sequence_id AND A.wp_id NOT IN('702','722')
                        INNER JOIN it_goods B with(nolock) ON A.within_code=A.within_code and A.goods_id=B.id
                        INNER JOIN cd_department C with(nolock) ON A.within_code=A.within_code AND A.next_wp_id=C.id ", pMo, pGoods_id);

            DataTable dtProcess = clsConErp.GetDataTable(strSql);
            return dtProcess;
        }
        public static DataTable getNextDepItem(string mo_id,string wp_id,string goods_id)
        {
            string strSql = "";
            strSql += " Select aa.wp_id,aa.goods_id,aa.next_wp_id,dd.name AS next_dep_name,bb.goods_id AS next_goods_id,mm.name AS next_goods_name" +
                    ",mm.do_color AS next_do_color,aa.vendor_id AS next_vendor_id ";
            strSql += " FROM (";
            strSql += "SELECT a.within_code,a.id,a.ver,a.mo_id,b.sequence_id,b.wp_id,b.next_wp_id,b.goods_id,b.vendor_id " +
                    " FROM jo_bill_mostly a " +
                    " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                    " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "' AND b.wp_id='" + wp_id + "' AND b.goods_id='" + goods_id + "'";
            strSql += " ) aa ";
            strSql += " INNER JOIN jo_bill_goods_details bb ON aa.within_code=bb.within_code AND aa.id=bb.id AND aa.ver=bb.ver AND aa.next_wp_id=bb.wp_id" +
                    " INNER JOIN jo_bill_materiel_details cc ON bb.within_code=cc.within_code AND bb.id=cc.id AND bb.ver=cc.ver AND bb.sequence_id=cc.upper_sequence AND aa.goods_id=cc.materiel_id" +
                    " INNER JOIN it_goods mm ON bb.within_code=mm.within_code AND bb.goods_id=mm.id"+
                    " LEFT JOIN cd_department dd ON bb.within_code=dd.within_code AND bb.next_wp_id=dd.id";

            DataTable dt = clsConErp.GetDataTable(strSql);
            return dt;
        }
        //test
    }
}
