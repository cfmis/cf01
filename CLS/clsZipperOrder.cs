using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using cf01.MDL;


namespace cf01.CLS
{
    public class clsZipperOrder
    {
        private static string within_code = DBUtility.within_code;
        private static string userid = DBUtility._user_id;
        private static string remote_db = DBUtility.remote_db;
        private static clsPublicOfGEO clsConnGeo = new clsPublicOfGEO();

        public static DataTable loadOcOrder(string ocno)
        {
            DataTable dtOc = new DataTable();
            string strSql = "";
            strSql = "Select a.id,Convert(Varchar(20),a.order_date,111) As order_date,a.it_customer,b.name As cust_name" +
                " From so_order_manage a" +
                " Left Join it_customer b On a.within_code=b.within_code And a.it_customer=b.id"+
                " Where a.within_code='" + within_code + "' And " + "a.id='" + ocno + "'";
            dtOc = clsConnGeo.GetDataTable(strSql);
            return dtOc;
        }

        public static string addSo_zipper_order_head(bool append_mode,so_zipper_order_head objModel)
        {
            int Result = 0;
            string id = "";
            string strSql = "";
            id=objModel.id;
            try
            {

                if (append_mode == true)
                {
                    if (id == "")
                        id = getId(objModel.mo_group);
                    strSql = @"insert into so_zipper_order_head (within_code, id,order_date,it_customer,cust_po,mo_group,crusr,crtim)
                                Values(@within_code, @id,@order_date,@it_customer,@cust_po,@mo_group,@crusr,@crtim)";
                }
                else
                {
                    strSql = @"Update so_zipper_order_head Set order_date=@order_date,it_customer=@it_customer,cust_po=@cust_po,amusr=@crusr,amtim=@crtim
                            Where within_code=@within_code And id=@id";

                }
                //};
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",id),
                    new SqlParameter("@order_date",objModel.order_date),
                    new SqlParameter("@it_customer",objModel.it_customer),
                    new SqlParameter("@cust_po",objModel.cust_po),
                    new SqlParameter("@mo_group",objModel.mo_group),
                    new SqlParameter("@crusr",objModel.crusr),
                    new SqlParameter("@crtim",objModel.crtim)
                    };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
                if (Result <= 0)
                    id = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }
        public static string addSo_zipper_order_details(bool append_mode,so_zipper_order_details objModel)
        {
            int Result = 0;
            string strSql = "";
            string sequence_id = "";
            string prd_seq = "";
            sequence_id= objModel.sequence_id;
            prd_seq = objModel.prd_seq;
            if (prd_seq == "")
                prd_seq = getPrd_seq("so_zipper_order_details", objModel.mo_group);
            if (checkExistIdDetails(objModel.id, objModel.sequence_id) == false)
            {
                if (sequence_id == "")
                    sequence_id = getSeq("so_zipper_order_details", objModel.id, 4);
                
                strSql = @"insert into so_zipper_order_details
                        (within_code, id,sequence_id,mo_id,goods_id,order_qty,goods_unit,sample_qty,mat_type,prd_seq
                        ,spec_id,spec_oth,color_c,color_y,color_oth,manu_craft_group,manu_craft_id,manu_craft_cdesc,manu_craft_oth
                        ,prd_process_id,prd_process_cdesc,prd_process_oth,prd_process_color,prd_process_id1,prd_process_cdesc1,prd_process_oth1,prd_process_color1
                        ,zipper_head,zipper_head_oth,naked_select,naked_cdesc,zipper_tooth,zipper_color,zipper_color_oth
                        ,pull_card_no,pull_card_color_id,pull_card_color,test_std,test_std_cdesc,prd_use,prd_use_oth,cloth_type,size_cm,size_inc,size_diff,pack_type,size_diff_oth
                        ,size,size_unit,pack_type_oth,wash_type,wash_type_oth,remark1,remark2,cust_goods_style,crusr,crtim,no_mag_test)
                        Values
                        (@within_code,@id,@sequence_id,@mo_id,@goods_id,@order_qty,@goods_unit,@sample_qty,@mat_type,@prd_seq
                        ,@spec_id,@spec_oth,@color_c,@color_y,@color_oth,@manu_craft_group,@manu_craft_id,@manu_craft_cdesc,@manu_craft_oth
                        ,@prd_process_id,@prd_process_cdesc,@prd_process_oth,@prd_process_color,@prd_process_id1,@prd_process_cdesc1,@prd_process_oth1,@prd_process_color1
                        ,@zipper_head,@zipper_head_oth,@naked_select,@naked_cdesc,@zipper_tooth,@zipper_color,@zipper_color_oth
                        ,@pull_card_no,@pull_card_color_id,@pull_card_color,@test_std,@test_std_cdesc,@prd_use,@prd_use_oth,@cloth_type,@size_cm,@size_inc,@size_diff,@pack_type,@size_diff_oth
                        ,@size,@size_unit,@pack_type_oth,@wash_type,@wash_type_oth,@remark1,@remark2,@cust_goods_style,@crusr,@crtim,@no_mag_test)";
            }
            else
            {
                strSql = @"Update so_zipper_order_details Set mo_id=@mo_id,goods_id=@goods_id,order_qty=@order_qty,goods_unit=@goods_unit,sample_qty=@sample_qty,mat_type=@mat_type,prd_seq=@prd_seq
                        ,spec_id=@spec_id,spec_oth=@spec_oth,color_c=@color_c,color_y=@color_y,color_oth=@color_oth,manu_craft_group=@manu_craft_group,manu_craft_id=@manu_craft_id
                        ,manu_craft_oth=@manu_craft_oth,manu_craft_cdesc=@manu_craft_cdesc
                        ,prd_process_id=@prd_process_id,prd_process_cdesc=@prd_process_cdesc,prd_process_oth=@prd_process_oth,prd_process_color=@prd_process_color
                        ,prd_process_id1=@prd_process_id1,prd_process_cdesc1=@prd_process_cdesc1,prd_process_oth1=@prd_process_oth1,prd_process_color1=@prd_process_color1
                        ,zipper_head=@zipper_head,zipper_head_oth=@zipper_head_oth
                        ,naked_select=@naked_select,naked_cdesc=@naked_cdesc,zipper_tooth=@zipper_tooth,zipper_color=@zipper_color,zipper_color_oth=@zipper_color_oth
                        ,pull_card_no=@pull_card_no,pull_card_color_id=@pull_card_color_id,pull_card_color=@pull_card_color,test_std=@test_std,test_std_cdesc=@test_std_cdesc,prd_use=@prd_use
                        ,prd_use_oth=@prd_use_oth,cloth_type=@cloth_type,size_cm=@size_cm,size_inc=@size_inc,size_diff=@size_diff,pack_type=@pack_type,size_diff_oth=@size_diff_oth
                        ,size=@size,size_unit=@size_unit,pack_type_oth=@pack_type_oth,wash_type=@wash_type,wash_type_oth=@wash_type_oth,remark1=@remark1,remark2=@remark2,cust_goods_style=@cust_goods_style
                        ,amusr=@crusr,amtim=@crtim,no_mag_test=@no_mag_test
                        Where within_code=@within_code And id=@id And sequence_id=@sequence_id";
                //
            }
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",objModel.id),
                    new SqlParameter("@sequence_id",sequence_id),
                    new SqlParameter("@mo_id",objModel.mo_id),
                    new SqlParameter("@goods_id",objModel.goods_id),
                    new SqlParameter("@order_qty",objModel.order_qty),
                    new SqlParameter("@sample_qty",objModel.sample_qty),
                    new SqlParameter("@goods_unit",objModel.goods_unit),
                    new SqlParameter("@mat_type",objModel.mat_type),
                    new SqlParameter("@prd_seq",prd_seq),
                    new SqlParameter("@spec_id",objModel.spec_id),
                    new SqlParameter("@spec_oth",objModel.spec_oth),
                    new SqlParameter("@color_c",objModel.color_c),
                    new SqlParameter("@color_y",objModel.color_y),
                    new SqlParameter("@color_oth",objModel.color_oth),
                    new SqlParameter("@manu_craft_group",objModel.manu_craft_group),
                    new SqlParameter("@manu_craft_id",objModel.manu_craft_id),
                    new SqlParameter("@manu_craft_cdesc",objModel.manu_craft_cdesc),
                    new SqlParameter("@manu_craft_oth",objModel.manu_craft_oth),
                    new SqlParameter("@prd_process_id",objModel.prd_process_id),
                    new SqlParameter("@prd_process_cdesc",objModel.prd_process_cdesc),
                    new SqlParameter("@prd_process_oth",objModel.prd_process_oth),
                    new SqlParameter("@prd_process_color",objModel.prd_process_color),
                    new SqlParameter("@prd_process_id1",objModel.prd_process_id1),
                    new SqlParameter("@prd_process_cdesc1",objModel.prd_process_cdesc1),
                    new SqlParameter("@prd_process_oth1",objModel.prd_process_oth1),
                    new SqlParameter("@prd_process_color1",objModel.prd_process_color1),
                    new SqlParameter("@zipper_head",objModel.zipper_head),
                    new SqlParameter("@zipper_head_oth",objModel.zipper_head_oth),
                    new SqlParameter("@naked_select",objModel.naked_select),
                    new SqlParameter("@naked_cdesc",objModel.naked_cdesc),
                    new SqlParameter("@zipper_tooth",objModel.zipper_tooth),
                    new SqlParameter("@zipper_color",objModel.zipper_color),
                    new SqlParameter("@zipper_color_oth",objModel.zipper_color_oth),
                    new SqlParameter("@pull_card_no",objModel.pull_card_no),
                    new SqlParameter("@pull_card_color_id",objModel.pull_card_color_id),
                    new SqlParameter("@pull_card_color",objModel.pull_card_color),
                    new SqlParameter("@test_std",objModel.test_std),
                    new SqlParameter("@test_std_cdesc",objModel.test_std_cdesc),
                    new SqlParameter("@prd_use",objModel.prd_use),
                    new SqlParameter("@prd_use_oth",objModel.prd_use_oth),
                    new SqlParameter("@cloth_type",objModel.cloth_type),
                    new SqlParameter("@size",objModel.size),
                    new SqlParameter("@size_unit",objModel.size_unit),
                    new SqlParameter("@size_cm",objModel.size_cm),
                    new SqlParameter("@size_inc",objModel.size_inc),
                    new SqlParameter("@size_diff",objModel.size_diff),
                    new SqlParameter("@size_diff_oth",objModel.size_diff_oth),
                    new SqlParameter("@pack_type",objModel.pack_type),
                    new SqlParameter("@pack_type_oth",objModel.pack_type_oth),
                    new SqlParameter("@wash_type",objModel.wash_type),
                    new SqlParameter("@wash_type_oth",objModel.wash_type_oth),
                    new SqlParameter("@remark1",objModel.remark1),
                    new SqlParameter("@remark2",objModel.remark2),
                    new SqlParameter("@cust_goods_style",objModel.cust_goods_style),
                    new SqlParameter("@crusr",objModel.crusr),
                    new SqlParameter("@crtim",objModel.crtim),
                    new SqlParameter("@no_mag_test",objModel.no_mag_test)
                    };

            Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);

            return sequence_id;
        }

        private static string getSeq(string tb_name, string id, int seq_len)
        {
            string seq = "";
            string strSql;
            strSql = "Select Max(sequence_id) AS max_seq From " + tb_name + " Where within_code='" + within_code + "' AND id='" + id + "'";
            DataTable tbGenNo = clsPublicOfCF01.GetDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
            {
                if (seq_len == 4)
                    seq = "0001";
                else
                    if (seq_len == 5)
                        seq = "00001";
            }
            else
                seq = (Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(0, seq_len)) + 1).ToString().PadLeft(seq_len, '0');
            seq = seq + "h";
            return seq;
        }
        private static string getPrd_seq(string tb_name, string mo_group)
        {
            string prd_seq = mo_group;
            string prd_seq_max = mo_group + "ZZZZZ";
            string strSql;
            strSql = "Select Max(prd_seq) AS max_seq From " + tb_name + " Where within_code='" + within_code + "' AND prd_seq>='" + prd_seq + "' And prd_seq<='" + prd_seq_max + "'";
            DataTable tbGenNo = clsPublicOfCF01.GetDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
            {
                prd_seq = "00001";
            }
            else
                prd_seq = (Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(1, 5)) + 1).ToString().PadLeft(5, '0');
            prd_seq = mo_group + prd_seq;
            return prd_seq;
        }
        public static bool checkExistIdDetails(string id, string seq)
        {
            bool result = false;
            string strSql = "";
            strSql = "Select id,to_pr_state From so_zipper_order_details Where within_code='" + within_code + "' AND id='" + id + "' AND sequence_id='" + seq + "'";
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool deleteIdDetails(string id, string seq)
        {
            bool result = false;
            string strSql = "";
            strSql = "Delete From so_zipper_order_details Where within_code='" + within_code + "' AND id='" + id + "' AND sequence_id='" + seq + "'";
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool checkExistId(string id)
        {
            bool result = false;
            string strSql = "";
            strSql = "Select id From so_zipper_order_head Where within_code='" + within_code + "' AND id='" + id + "'";
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static string getId(string mo_group)
        {
            string result = "";
            string strSql = "";
            strSql = "Select MAX(id) AS max_id From so_zipper_order_head Where within_code='" + within_code + "' AND id>='" + mo_group + "' And id<='" + mo_group + "ZZZZZZZ" + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            if (dtId.Rows[0]["max_id"].ToString() == "")
                result = "000001";
            else
                result = (Convert.ToInt32(dtId.Rows[0]["max_id"].ToString().Substring(2, 6)) + 1).ToString().PadLeft(6, '0');
            result = mo_group + "-" + result;
            return result;
        }
        public static DataTable loadIdDetails(string id)
        {
            string strSql = "";
            strSql = "Select *,CONVERT(VARCHAR(20),crtim,120) AS crtim_str From so_zipper_order_details Where within_code='" + within_code + "' AND id='" + id + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            return dtId;
        }
        public static DataTable loadIdSeqDetails(string id, string seq)
        {
            string strSql = "";
            strSql = "Select * From so_zipper_order_details Where within_code='" + within_code + "' AND id='" + id + "' AND sequence_id='" + seq + "'";
            DataTable dtIdDetails = clsPublicOfCF01.GetDataTable(strSql);
            return dtIdDetails;
        }
        public static DataTable loadId(string id)
        {
            string strSql = "";
            strSql = "Select a.id,Convert(varchar(20),a.order_date,111) As order_date,a.it_customer,b.name As cust_name,a.cust_po,a.mo_group" +
                ",a.crusr,Convert(varchar(20),a.crtim,120) As crtim" +
                ",a.amusr,Convert(varchar(20),a.amtim,120) As amtim" +
                " From so_zipper_order_head a " +
                " Left Join " + remote_db + "it_customer b On a.within_code=b.within_code COLLATE Chinese_PRC_CI_AS And a.it_customer=b.id COLLATE Chinese_PRC_CI_AS " +
                " Where a.within_code='" + within_code + "' AND a.id='" + id + "'";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);

            return dtId;
        }
        
        public static DataTable getIt_Customer(string cust)
        {
            DataTable dtCust = new DataTable();
            string strSql = "";
            strSql = "Select a.id,a.name,a.seller_id_1,a.money_id,b.s_address,b.phone,b.fax,b.email,a.fake_s_address " +
                " From it_customer a " +
                " Left Join it_shipment_address b On a.within_code=b.within_code And a.id=b.id" +
                " Where a.within_code='" + within_code + "' AND a.id='" + cust + "'";
            dtCust = clsConnGeo.GetDataTable(strSql);
            return dtCust;
        }
        //規格
        public static DataTable getSpec()
        {
            string strSql = "";
            strSql = "Select id,cdesc From bs_prd_spec Order By id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            return dtId;
        }
        //質地
        public static DataTable getMat_type()
        {
            string strSql = "";
            strSql = "Select mat_code,mat_cdesc From bs_mat_type Where mat_group='ZP' Order By mat_code";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            return dtId;
        }
        //製作工藝
        public static DataTable getManu_craft(string id_type)
        {
            string strSql = "";
            strSql = "Select id,cdesc From bs_manufacture_craft Where id_type='" + id_type + "' Order By id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            dtId.Rows.Add();
            dtId.DefaultView.Sort = "id";
            return dtId;
        }
        //獲取每包數量
        public static DataTable getPper_pack(string id,string id_type)
        {
            string strSql = "";
            strSql = "Select id,cdesc,per_pack From bs_manufacture_craft Where id='"+id+"' And id_type='" + id_type + "' Order By id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            return dtId;
        }
        //製作工藝
        public static DataTable getManu_craft_details(string craft_group)
        {
            string strSql = "";
            strSql = "Select id,cdesc From bs_manufacture_craft_details  Where craft_group='" + craft_group + "' Order By id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            dtId.Rows.Add();
            dtId.DefaultView.Sort = "id";
            return dtId;
        }
        public static DataTable getUnitRate(string unit)
        {
            DataTable dtUnitRate = new DataTable();
            string strSql = "";
            strSql = "Select rate " +
                " From it_coding" +
                " Where within_code='" + within_code + "' And unit_code='" + unit + "' And id='*'";
            dtUnitRate = clsConnGeo.GetDataTable(strSql);
            return dtUnitRate;
        }
        public static DataTable getUnit()
        {
            DataTable dtUnit = new DataTable();
            string strSql = "";
            strSql = "Select id,name From cd_units Where within_code='" + within_code + "'";
            strSql += " ORDER BY id";
            dtUnit = clsConnGeo.GetDataTable(strSql);
            return dtUnit;
        }

        //鏈齒顏色
        public static DataTable getZipper_color(string clr_use_type)
        {
            string strSql = "";
            strSql = "Select clr_code,clr_cdesc From bs_color  Where clr_use_type='" + clr_use_type + "' Order By clr_code";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            dtId.Rows.Add();
            dtId.DefaultView.Sort = "clr_code";
            return dtId;
        }
        //組別
        public static DataTable getGroup()
        {
            string strSql = "";
            strSql = "Select mo_group From bs_group Group By mo_group";
            DataTable dtGroup = clsPublicOfCF01.GetDataTable(strSql);
            dtGroup.Rows.Add();
            dtGroup.DefaultView.Sort = "mo_group";
            return dtGroup;
        }
        //尺寸單位
        public static DataTable getSize_unit()
        {
            string strSql = "";
            strSql = "Select unit_id,unit_cdesc From bs_unit Where rst='ZP' ";
            DataTable dtGroup = clsPublicOfCF01.GetDataTable(strSql);
            dtGroup.Rows.Add();
            dtGroup.DefaultView.Sort = "unit_id";
            return dtGroup;
        }
        //用戶組別
        public static DataTable getUserGroup()
        {
            string strSql = "";
            strSql = "Select a.mo_group " +
                " From bs_group a " +
                " Inner Join tb_sy_user b On a.grp_code=b.sales_group" +
                " Where b.uname='" + userid + "'";
            DataTable dtUserGroup = clsPublicOfCF01.GetDataTable(strSql);

            return dtUserGroup;
        }
        public static DataTable findIdDetails1(string id,string dat1,string dat2,string cust,string mo,string item,string po)
        {
            string strSql = "";
            strSql = "Select Convert(Varchar(20),a.order_date,111) As order_date,a.it_customer,a.cust_po" +
                ",b.*" +
                " From so_zipper_order_head a" +
                " Inner Join so_zipper_order_details b On a.within_code=b.within_code And a.id=b.id " +
                " Where a.within_code='" + within_code + "'";
            if (id != "")
                strSql += " And a.id='" + id + "'";
            if (po != "")
                strSql += " And a.cust_po='" + po + "'";
            if (dat1 != "" && dat2 != "")
                strSql += " And a.order_date>='" + dat1 + "' And a.order_date <'" + dat2 + "'";
            if (cust != "")
                strSql += " And a.it_customer='" + cust + "'";
            if (mo != "")
                strSql += " And b.mo_id='" + mo + "'";
            if (item != "")
                strSql += " And b.goods_id='" + item + "'";
            strSql += " Order By a.id,b.sequence_id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            return dtId;
        }

        public static DataTable findIdDetails(int find_mo_flag,string id, string dat1, string dat2, string cust, string mo, string item, string po, string mo_group)
        {
            string strSql = "";
            strSql = "Select a.id,Convert(varchar(20),a.order_date,111) As order_date,a.it_customer,c.name As cust_name,a.cust_po,b.prd_seq" +
                ",a.crusr,Convert(varchar(20),a.crtim,120) As crtim,a.amusr,Convert(varchar(20),a.amtim,120) As amtim" +
                ",b.sequence_id,b.spec_id,b.spec_oth,e.cdesc AS spec_cdesc,b.color_c,b.color_y,b.color_oth" +
                ",b.prd_process_id,b.prd_process_cdesc,b.prd_process_oth,b.prd_process_color,b.prd_process_id1,b.prd_process_cdesc1,b.prd_process_oth1,b.prd_process_color1" +
                ",b.zipper_head,i.cdesc As zipper_head_cdesc,b.zipper_head_oth,b.naked_select,b.naked_cdesc As naked_select_cdesc" +
                ",b.mat_type,d.mat_cdesc,b.zipper_color,b.zipper_color_oth" +
                ",b.manu_craft_group,g.cdesc As manu_craft_group_cdesc,b.manu_craft_id,b.manu_craft_cdesc,b.manu_craft_oth" +
                ",b.pull_card_no,b.pull_card_color_id,b.pull_card_color,b.goods_id,b.mo_id,b.zipper_tooth,k.cdesc As zipper_tooth_cdesc,b.test_std_cdesc,b.test_std_oth" +
                ",b.prd_use,l.cdesc As prd_use_cdesc,b.prd_use_oth,b.cloth_type,b.order_qty,b.goods_unit,b.sample_qty" +
                ",b.size,f.unit_cdesc AS size_unit_cdesc,b.size_cm,b.size_inc,b.size_diff,m.cdesc As size_diff_cdesc,b.size_diff_oth,b.pack_type,n.cdesc As pack_type_cdesc,b.pack_type_oth" +
                ",b.wash_type,o.cdesc As wash_type_cdesc,b.wash_type_oth,b.brand_id,b.remark1,b.remark2,b.cust_goods_style,b.crusr,CONVERT(VARCHAR(20),b.crtim,120) AS crtim" +
                ",dbo.StrToCode128B(b.mo_id) AS mo_id_barcode,b.no_mag_test " +
                " From so_zipper_order_head a " +
                " Inner Join so_zipper_order_details b On a.within_code=b.within_code And a.id=b.id" +
                " Left Join bs_mat_type d On b.mat_type=d.mat_code " +
                " Left Join bs_manufacture_craft e On b.spec_id=e.id" +
                " Left Join bs_unit f On b.size_unit=f.unit_id" +
                " Left Join bs_manufacture_craft g On b.manu_craft_group=g.id" +
                " Left Join bs_manufacture_craft i On b.zipper_head=i.id" +
                " Left Join bs_manufacture_craft k On b.zipper_tooth=k.id" +
                " Left Join bs_manufacture_craft l On b.prd_use=l.id" +
                " Left Join bs_manufacture_craft m On b.size_diff=m.id" +
                " Left Join bs_manufacture_craft n On b.pack_type=n.id" +
                " Left Join bs_manufacture_craft o On b.wash_type=o.id" +
                " Left Join " + remote_db + "it_customer c On a.within_code=c.within_code COLLATE Chinese_PRC_CI_AS And a.it_customer=c.id COLLATE Chinese_PRC_CI_AS " +
                " Where a.within_code='" + within_code + "'";
            if (id != "")
                strSql += " And a.id='" + id + "'";
            if (mo_group != "")
                strSql += " And a.mo_group='" + mo_group + "'";
            if (po != "")
                strSql += " And a.cust_po='" + po + "'";
            if (dat1 != "" && dat2 != "")
                strSql += " And a.order_date>='" + dat1 + "' And a.order_date <'" + dat2 + "'";
            if (cust != "")
                strSql += " And a.it_customer='" + cust + "'";
            if (mo != "")
                strSql += " And b.mo_id='" + mo + "'";
            if (item != "")
                strSql += " And b.goods_id='" + item + "'";
            strSql += " Order By b.mat_type,a.id,b.sequence_id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            dtId.Columns.Add("is_select", System.Type.GetType("System.Boolean"));
            dtId.Columns.Add("no_mag_test_cdesc", typeof(string));
            if (find_mo_flag == 1)//從OC中提取資料
            {
                dtId.Columns.Add("prd_remark", typeof(string));
                dtId.Columns.Add("test_item", typeof(string));
                string mo_id = "";
                for (int i = 0; i < dtId.Rows.Count; i++)
                {
                    mo_id = dtId.Rows[i]["mo_id"].ToString();
                    if (dtId.Rows[i]["no_mag_test"].ToString() == "1")
                        dtId.Rows[i]["no_mag_test_cdesc"] = "無磁過檢針機";
                    else
                        dtId.Rows[i]["no_mag_test_cdesc"] = "";
                    DataTable dtOc = loadOcData(mo_id);
                    if (dtOc.Rows.Count > 0)
                    {
                        dtId.Rows[i]["prd_remark"] = dtOc.Rows[0]["production_remark"].ToString();
                        dtId.Rows[i]["order_qty"] = dtOc.Rows[0]["order_qty"].ToString();
                        dtId.Rows[i]["goods_unit"] = dtOc.Rows[0]["goods_unit"].ToString();
                    }
                    string test_item = "";
                    DataTable dtTest = loadMoTest(mo_id);
                    for (int j = 0; j < dtTest.Rows.Count; j++)
                    {
                        test_item += dtTest.Rows[j]["test_item_type"].ToString() + "--" + dtTest.Rows[j]["test_item_id"].ToString() + " / " + dtTest.Rows[j]["test_item_name"].ToString() + "; ";
                    }
                    dtId.Rows[i]["test_item"] = test_item;
                }
            }
            return dtId;
        }

        public static void expToExcel(DataTable dtExcel)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();

                //frmProgress wForm = new frmProgress();
                //new Thread((ThreadStart)delegate
                //{
                //    wForm.TopMost = true;
                //    wForm.ShowDialog();
                //}).Start();

                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));



                string str = " ";
                //写标题
                str +=  "序號";
                str += "\t" + "質地";
                str += "\t" + "落單日期";
                str += "\t" + "客戶編號";
                str += "\t" + "制單編號";
                str += "\t" + "測試標準";
                str += "\t" + "產品規格";
                str += "\t" + "布帶/鏈齒";
                str += "\t" + "製作工藝";
                str += "\t" + "尺寸";
                str += "\t" + "數量";
                str += "\t" + "樣品";
                str += "\t" + "拉頭顏色";
                str += "\t" + "備註";
                str += "\t" + "產品編號";
                str += "\t" + "客人款號";
                str += "\t" + "客戶描述";
                str += "\t" + "產品序號";
                str += "\t" + "建立人";
                str += "\t" + "建立日期";
                str += "\t" + "單據編號";
                sw.WriteLine(str);
                //写内容

                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    DataRow row = dtExcel.Rows[i];
                    string tempstr = " ";
                    tempstr += (i + 1).ToString();//序號
                    tempstr += "\t" + row["mat_cdesc"].ToString().Trim();//質地
                    tempstr += "\t" + "=\"" + row["order_date"].ToString().Trim() + "\"";//落單日期
                    tempstr += "\t" + row["it_customer"].ToString().Trim();//客戶編號
                    tempstr += "\t" + row["mo_id"].ToString().Trim();//制單編號
                    tempstr += "\t" + (row["test_std_cdesc"].ToString() != "" ? row["test_std_cdesc"].ToString().Trim() : "")
                                    + (row["test_std_oth"].ToString() != "" ? "/" + row["test_std_oth"].ToString().Trim() : "");//測試標準
                    tempstr += "\t" + (row["spec_cdesc"].ToString() != "" ?row["spec_cdesc"].ToString().Trim() : "")
                                    + (row["spec_oth"].ToString() != "" ? "/" + row["spec_oth"].ToString().Trim() : "")
                                    + (row["manu_craft_group_cdesc"].ToString() != "" ? "/" + row["manu_craft_group_cdesc"].ToString().Trim() : "")
                                    + (row["zipper_tooth_cdesc"].ToString() != "" ? "/" + row["zipper_tooth_cdesc"].ToString().Trim() : "");//產品規格
                    tempstr += "\t" + (row["color_c"].ToString() != "" ? "/" + row["color_c"].ToString().Trim() : "")
                                    + (row["color_y"].ToString() != "" ? "/" + row["color_y"].ToString().Trim() : "")
                                    + (row["zipper_color_oth"].ToString() != "" ? "/" + row["zipper_color_oth"].ToString().Trim() : "")
                                    + (row["color_oth"].ToString() != "" ? "/" + row["color_oth"].ToString().Trim() : "");//布帶/鏈齒
                    tempstr += "\t" + (row["manu_craft_cdesc"].ToString() != "" ? row["manu_craft_cdesc"].ToString().Trim() : "")
                                    + (row["manu_craft_oth"].ToString() != "" ? "/" + row["manu_craft_oth"].ToString().Trim() : "")
                                    + (row["prd_process_cdesc"].ToString() != "" ? "/" + row["prd_process_cdesc"].ToString().Trim() : "")
                                    + (row["prd_process_oth"].ToString() != "" ? "/" + row["prd_process_oth"].ToString().Trim() : "")
                                    + (row["prd_process_color"].ToString() != "" ? "/" + row["prd_process_color"].ToString().Trim() : "")
                                    + (row["zipper_head_cdesc"].ToString() != "" ? "/" + row["zipper_head_cdesc"].ToString().Trim() : "")
                                    + (row["zipper_head_oth"].ToString() != "" ? "/" + row["zipper_head_oth"].ToString().Trim() : "")
                                    + (row["naked_select_cdesc"].ToString() != "" ? "/ **光身選擇:" + row["naked_select_cdesc"].ToString().Trim() : "");//製作工藝
                    tempstr += "\t" + (row["size"].ToString() != "" ? row["size"].ToString().Trim()+" / " : "")
                                    + (row["size_unit_cdesc"].ToString() != "" ? row["size_unit_cdesc"].ToString().Trim()+" / " : "")
                                    + (row["size_diff_oth"].ToString() != "" ? row["size_diff_oth"].ToString().Trim() : "");//尺寸
                    //+ (row["size_diff_cdesc"].ToString() != "" ? row["size_diff_cdesc"].ToString().Trim() +" / " : "")
                    tempstr += "\t" + row["order_qty"].ToString().Trim();//數量
                    tempstr += "\t" + row["sample_qty"].ToString().Trim();//樣品
                    tempstr += "\t" + row["pull_card_color"].ToString().Trim();//拉頭顏色
                    tempstr += "\t" + (row["pack_type_cdesc"].ToString() != "" ? row["pack_type_cdesc"].ToString().Trim() : "")
                                    + (row["pack_type_oth"].ToString() != "" ? row["pack_type_oth"].ToString().Trim() : "")
                                    + (row["wash_type_cdesc"].ToString() != "" ? row["wash_type_cdesc"].ToString().Trim() : "")
                                    + (row["wash_type_oth"].ToString() != "" ? row["wash_type_oth"].ToString().Trim() : "");//備註
                    tempstr += "\t" + row["goods_id"].ToString().Trim();//產品編號
                    tempstr += "\t" + row["cust_goods_style"].ToString().Trim();//客人款號
                    tempstr += "\t" + row["cust_name"].ToString().Trim();//客戶描述
                    tempstr += "\t" + row["prd_seq"].ToString().Trim();//產品序號
                    tempstr += "\t" + row["crusr"].ToString().Trim();//建立人
                    tempstr += "\t" + "=\"" + row["crtim"].ToString().Trim() + "\"";//建立日期
                    tempstr += "\t" + row["id"].ToString().Trim();//單據編號
                    
                    sw.WriteLine(tempstr);
                    //
                }

                sw.Close();
                myStream.Close();
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                MessageBox.Show("已匯出記錄！");
            }
        }

        public static void saveToExcel(DataTable dtExcel)
        {

            string strFileName = @"c:\3\l1.xls";
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默認文件后缀
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls";
            //默認路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            //返回文件路径   
            strFileName = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (strFileName.Trim() == "" || strFileName == null)
                return;

            int rowscount = dtExcel.Rows.Count;

            //创建空EXCEL对象 
            //Microsoft.Office.Interop.
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objSheet_m = null;
            Microsoft.Office.Interop.Excel.Worksheet objSheet_n = null;
            Microsoft.Office.Interop.Excel.Range rg_m = null;
            Microsoft.Office.Interop.Excel.Range rg_n = null;
            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objSheet_n = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.Worksheets[1];//强制类型转换
                objSheet_n.Name = "非金屬類";
                objSheet_m = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.Worksheets[2];//强制类型转换
                objSheet_m.Name = "金屬類";
                //设置EXCEL不可见(后台运行)   
                objExcel.Visible = false;
                string seq, mat_cdesc, dat, cust, mo_id, test_std, spec, zipper_color, mach, size, qty, sample_qty
                    , remark, goods_id, cust_name, cust_style, prd_seq, crusr, crtim, id, prd_remark, test_item, no_mag_test_cdesc;
                seq = "序號";
                mat_cdesc = "質地";
                dat = "落單日期";
                cust = "客戶編號";
                mo_id = "制單編號";
                test_std = "測試標準";
                spec = "產品規格";
                zipper_color = "布帶/鏈齒/拉頭顏色";
                mach = "製作工藝";
                size = "尺寸";
                qty = "數量";
                sample_qty = "樣品";
                remark = "備註";
                goods_id = "產品編號";
                cust_style = "客人款號";
                cust_name = "客戶描述";
                prd_seq = "產品序號";
                crusr = "建立人";
                crtim = "建立日期";
                id = "單據編號";
                no_mag_test_cdesc = "測試要求";
                test_item = "測試項目";
                prd_remark = "生產備註";
                //向Excel中写入表格的表头
                objSheet_m.Cells[1, 1] = seq;// "序號";
                objSheet_m.Cells[1, 2] = mat_cdesc;// "質地";
                objSheet_m.Cells[1, 3] = dat;// "落單日期";
                objSheet_m.Cells[1, 4] = cust;// "客戶編號";
                objSheet_m.Cells[1, 5] = mo_id;// "制單編號";
                objSheet_m.Cells[1, 6] = test_std;// "測試標準";
                objSheet_m.Cells[1, 7] = spec;// "產品規格";
                objSheet_m.Cells[1, 8] = zipper_color;// "布帶/鏈齒/拉片顏色";
                objSheet_m.Cells[1, 9] = mach;// "製作工藝";
                objSheet_m.Cells[1, 10] = size;// "尺寸";
                objSheet_m.Cells[1, 11] = qty;// "數量";
                objSheet_m.Cells[1, 12] = sample_qty;// "樣品";
                objSheet_m.Cells[1, 13] = remark;// "備註";
                objSheet_m.Cells[1, 14] = goods_id;// "產品編號";
                objSheet_m.Cells[1, 15] = spec;// "客人款號";
                objSheet_m.Cells[1, 16] = cust_name;// "客戶描述";
                objSheet_m.Cells[1, 17] = prd_seq;// "產品序號";
                objSheet_m.Cells[1, 18] = crusr;// "建立人";
                objSheet_m.Cells[1, 19] = crtim;// "建立日期";
                objSheet_m.Cells[1, 20] = id;// "單據編號";
                objSheet_m.Cells[1, 21] = no_mag_test_cdesc;// "測試要求";
                objSheet_m.Cells[1, 22] = test_item;// "測試項目";
                objSheet_m.Cells[1, 23] = prd_remark;// "生產備註";

                objSheet_n.Cells[1, 1] = seq;// "序號";
                objSheet_n.Cells[1, 2] = mat_cdesc;// "質地";
                objSheet_n.Cells[1, 3] = dat;// "落單日期";
                objSheet_n.Cells[1, 4] = cust;// "客戶編號";
                objSheet_n.Cells[1, 5] = mo_id;// "制單編號";
                objSheet_n.Cells[1, 6] = test_std;// "測試標準";
                objSheet_n.Cells[1, 7] = spec;// "產品規格";
                objSheet_n.Cells[1, 8] = zipper_color;// "布帶/鏈齒/拉片顏色";
                objSheet_n.Cells[1, 9] = mach;// "製作工藝";
                objSheet_n.Cells[1, 10] = size;// "尺寸";
                objSheet_n.Cells[1, 11] = qty;// "數量";
                objSheet_n.Cells[1, 12] = sample_qty;// "樣品";
                objSheet_n.Cells[1, 13] = remark;// "備註";
                objSheet_n.Cells[1, 14] = goods_id;// "產品編號";
                objSheet_n.Cells[1, 15] = spec;// "客人款號";
                objSheet_n.Cells[1, 16] = cust_name;// "客戶描述";
                objSheet_n.Cells[1, 17] = prd_seq;// "產品序號";
                objSheet_n.Cells[1, 18] = crusr;// "建立人";
                objSheet_n.Cells[1, 19] = crtim;// "建立日期";
                objSheet_n.Cells[1, 20] = id;// "單據編號";
                objSheet_n.Cells[1, 21] = no_mag_test_cdesc;// "測試要求";
                objSheet_n.Cells[1, 22] = test_item;// "測試項目";
                objSheet_n.Cells[1, 23] = prd_remark;// "生產備註";

                //向Excel中逐行逐列写入表格中的数据
                int row_m = 2;
                int row_n = 2;
                for (int i = 0; i < rowscount; i++)
                {
                    DataRow rows = dtExcel.Rows[i];
                    mat_cdesc = rows["mat_cdesc"].ToString().Trim();// "質地"
                    dat = "=\"" + rows["order_date"].ToString().Trim() + "\"";// "落單日期";
                    cust = rows["it_customer"].ToString().Trim();// "客戶編號";
                    mo_id = rows["mo_id"].ToString().Trim(); //"制單編號";
                    test_std = (rows["test_std_cdesc"].ToString() != "" ? rows["test_std_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["test_std_oth"].ToString() != "" ?  rows["test_std_oth"].ToString().Trim() : "");// "測試標準";
                    spec = (rows["spec_cdesc"].ToString() != "" ? rows["spec_cdesc"].ToString().Trim() : "")
                                        + (rows["spec_oth"].ToString() != "" ? rows["spec_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["manu_craft_group_cdesc"].ToString() != "" ? rows["manu_craft_group_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["zipper_tooth_cdesc"].ToString() != "" ? rows["zipper_tooth_cdesc"].ToString().Trim() : "");//"產品規格";
                    zipper_color = (rows["color_c"].ToString() != "" ? rows["color_c"].ToString().Trim() + "\n\r" : "")
                                        + (rows["color_y"].ToString() != "" ? rows["color_y"].ToString().Trim() + "\n\r" : "")
                                        + (rows["color_oth"].ToString() != "" ? "/" + rows["color_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["zipper_color_oth"].ToString() != "" ? rows["zipper_color_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["pull_card_color"].ToString() != "" ? rows["pull_card_color"].ToString().Trim() : "");// "布帶/鏈齒/拉片顏色";
                    mach = (rows["manu_craft_cdesc"].ToString() != "" ? rows["manu_craft_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["manu_craft_oth"].ToString() != "" ? rows["manu_craft_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["prd_process_cdesc"].ToString() != "" ? " 上止：" + rows["prd_process_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["prd_process_oth"].ToString() != "" ? rows["prd_process_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["prd_process_color"].ToString() != "" ? rows["prd_process_color"].ToString().Trim() + "\n\r" : "")
                                        + (rows["prd_process_cdesc1"].ToString() != "" ? " 下止：" + rows["prd_process_cdesc1"].ToString().Trim() + "\n\r" : "")
                                        + (rows["prd_process_oth1"].ToString() != "" ? rows["prd_process_oth1"].ToString().Trim() + "\n\r" : "")
                                        + (rows["prd_process_color1"].ToString() != "" ? rows["prd_process_color1"].ToString().Trim() + "\n\r" : "")
                                        + (rows["zipper_head_cdesc"].ToString() != "" ? rows["zipper_head_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["zipper_head_oth"].ToString() != "" ? rows["zipper_head_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["naked_select_cdesc"].ToString() != "" ? "/ **光身選擇:" + rows["naked_select_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["pull_card_no"].ToString() != "" ? rows["pull_card_no"].ToString().Trim() : "");// "製作工藝";
                    size = (rows["size"].ToString() != "" ? rows["size"].ToString().Trim() + "\n\r" : "")
                                        + (rows["size_unit_cdesc"].ToString() != "" ? rows["size_unit_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["size_diff_oth"].ToString() != "" ? rows["size_diff_oth"].ToString().Trim() : "");// "尺寸";
                    qty = rows["order_qty"].ToString().Trim();// "數量";
                    sample_qty = rows["sample_qty"].ToString().Trim();// "樣品";
                    remark = (rows["pack_type_cdesc"].ToString() != "" ? rows["pack_type_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["pack_type_oth"].ToString() != "" ? rows["pack_type_oth"].ToString().Trim() + "\n\r" : "")
                                        + (rows["wash_type_cdesc"].ToString() != "" ? rows["wash_type_cdesc"].ToString().Trim() + "\n\r" : "")
                                        + (rows["wash_type_oth"].ToString() != "" ? rows["wash_type_oth"].ToString().Trim() : "");//備註
                    goods_id = rows["goods_id"].ToString().Trim();// "產品編號";
                    cust_style = rows["cust_goods_style"].ToString().Trim();// "客人款號";
                    cust_name = rows["cust_name"].ToString().Trim();//"客戶描述";
                    prd_seq = rows["prd_seq"].ToString().Trim();// "產品序號";
                    crusr = rows["crusr"].ToString().Trim();// "建立人";
                    crtim = "=\"" + rows["crtim"].ToString().Trim() + "\"";// "建立日期";
                    id = rows["id"].ToString().Trim();// "單據編號";
                    no_mag_test_cdesc = rows["no_mag_test_cdesc"].ToString().Trim();// "測試要求";
                    test_item = rows["test_item"].ToString().Trim();// "測試項";
                    prd_remark = rows["prd_remark"].ToString().Trim();// "生產備註";

                    if (rows["mat_cdesc"].ToString().Trim() != "金屬")
                    {
                        objSheet_n.Cells[row_n, 1] = (row_n - 1).ToString();//序號
                        objSheet_n.Cells[row_n, 2] = mat_cdesc;// "質地"
                        objSheet_n.Cells[row_n, 3] = dat;//落單日期
                        objSheet_n.Cells[row_n, 4] = cust;//客戶編號
                        objSheet_n.Cells[row_n, 5] = mo_id;//制單編號
                        objSheet_n.Cells[row_n, 6] = test_std;//測試標準
                        objSheet_n.Cells[row_n, 7] = spec;//產品規格
                        objSheet_n.Cells[row_n, 8] = zipper_color;//布帶/鏈齒/拉片顏色
                        objSheet_n.Cells[row_n, 9] = mach;//製作工藝
                        objSheet_n.Cells[row_n, 10] = size;//尺寸
                        //+ (rows["size_diff_cdesc"].ToString() != "" ? rows["size_diff_cdesc"].ToString().Trim() +" / " : "")
                        objSheet_n.Cells[row_n, 11] = qty;//數量
                        objSheet_n.Cells[row_n, 12] = sample_qty;//樣品
                        objSheet_n.Cells[row_n, 13] = remark;//備註
                        objSheet_n.Cells[row_n, 14] = goods_id;//產品編號
                        objSheet_n.Cells[row_n, 15] = cust_style;//客人款號
                        objSheet_n.Cells[row_n, 16] = cust_name;//客戶描述
                        objSheet_n.Cells[row_n, 17] = prd_seq;//產品序號
                        objSheet_n.Cells[row_n, 18] = crusr;//建立人
                        objSheet_n.Cells[row_n, 19] = crtim;//建立日期
                        objSheet_n.Cells[row_n, 20] = id;//單據編號
                        objSheet_n.Cells[row_n, 21] = no_mag_test_cdesc;//測試要求
                        objSheet_n.Cells[row_n, 22] = test_item;//測試項目
                        objSheet_n.Cells[row_n, 23] = prd_remark;//生產備註
                        row_n = row_n + 1;
                    }
                    else
                    {
                        objSheet_m.Cells[row_m, 1] = (row_m - 1).ToString();//序號
                        objSheet_m.Cells[row_m, 2] = mat_cdesc;// "質地"
                        objSheet_m.Cells[row_m, 3] = dat;//落單日期
                        objSheet_m.Cells[row_m, 4] = cust;//客戶編號
                        objSheet_m.Cells[row_m, 5] = mo_id;//制單編號
                        objSheet_m.Cells[row_m, 6] = test_std;//測試標準
                        objSheet_m.Cells[row_m, 7] = spec;//產品規格
                        objSheet_m.Cells[row_m, 8] = zipper_color;//布帶/鏈齒/拉片顏色
                        objSheet_m.Cells[row_m, 9] = mach;//製作工藝
                        objSheet_m.Cells[row_m, 10] = size;//尺寸
                        //+ (rows["size_diff_cdesc"].ToString() != "" ? rows["size_diff_cdesc"].ToString().Trim() +" / " : "")
                        objSheet_m.Cells[row_m, 11] = qty;//數量
                        objSheet_m.Cells[row_m, 12] = sample_qty;//樣品
                        objSheet_m.Cells[row_m, 13] = remark;//備註
                        objSheet_m.Cells[row_m, 14] = goods_id;//產品編號
                        objSheet_m.Cells[row_m, 15] = cust_style;//客人款號
                        objSheet_m.Cells[row_m, 16] = cust_name;//客戶描述
                        objSheet_m.Cells[row_m, 17] = prd_seq;//產品序號
                        objSheet_m.Cells[row_m, 18] = crusr;//建立人
                        objSheet_m.Cells[row_m, 19] = crtim;//建立日期
                        objSheet_m.Cells[row_m, 20] = id;//單據編號
                        objSheet_m.Cells[row_m, 21] = no_mag_test_cdesc;//測試要求
                        objSheet_m.Cells[row_m, 22] = test_item;//測試項目
                        objSheet_m.Cells[row_m, 23] = prd_remark;//生產備註
                        row_m = row_m + 1;
                    }
                    System.Windows.Forms.Application.DoEvents();
                    
                }
                //rg_m = objSheet_m.get_Range("A1", "N1");
                //rg_n = objSheet_n.get_Range("A1", "N1");
                //objSheet_m.Columns.EntireColumn.AutoFit();//列宽自适应
                //objSheet_n.Columns.EntireColumn.AutoFit();//列宽自适应
                //rg_m.RowHeight = 40;
                //rg_n.RowHeight = 20;
                //objSheet_m.Cells.Height = 40;
                //起始行
                int top = 1;
                //起始列
                int left = 1;

                rg_m = objSheet_m.get_Range((object)objSheet_m.Cells[top, left], (object)objSheet_m.Cells[ row_m - 1, 23]);
                rg_n = objSheet_n.get_Range((object)objSheet_n.Cells[top, left], (object)objSheet_n.Cells[ row_n - 1, 23]);

                //宽度
                rg_m.Cells.Borders.Weight = 2;
                rg_n.Cells.Borders.Weight = 2;
                //行高
                rg_m.RowHeight = 40;
                rg_n.RowHeight = 40;
                //字体大小
                rg_m.Font.Size = 10;
                rg_n.Font.Size = 10;

                rg_m = null;
                rg_n = null;
                //保存文件   
                //objWorkbook.SaveAs(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                //        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                //        Missing.Value, Missing.Value);
                //儲存Excel為2003格式
                objWorkbook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7, null, null, false, false
                    , Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //关闭Excel应用   
            if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
            if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
            if (objExcel != null) objExcel.Quit();
            //清空工作表
            objSheet_m = null;
            objSheet_n = null;
            //清空工作薄
            objWorkbook = null;
            objExcel = null;

            //强行杀死最近打开的excel进程
            KillProcess("EXCEL");

            MessageBox.Show(strFileName + "\n\n导出成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #region 关闭Excel进程
        /// <summary>
        /// 关闭Excel进程
        /// </summary>
        /// <param name="processName">进程名称</param>
        public static void KillProcess(string processName)
        {
            //获得进程对象，以用来操作
            System.Diagnostics.Process proce = new System.Diagnostics.Process();
            //得到所有打开的进程
            try
            {
                //获得需要杀死的进程名
                foreach (Process thisproc in Process.GetProcessesByName(processName))
                {
                    //立即杀死进程
                    thisproc.Kill();
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        #endregion


        public static DataTable findIdDetailsPr(string id,int to_pr_state)
        {
            string strSql = "";
            strSql = "Select a.id,Convert(varchar(20),a.order_date,111) As order_date,a.it_customer,c.name As cust_name,a.cust_po,b.prd_seq" +
                ",a.crusr,Convert(varchar(20),a.crtim,120) As crtim,a.amusr,Convert(varchar(20),a.amtim,120) As amtim" +
                ",b.sequence_id,b.spec_id,b.spec_oth,e.cdesc AS spec_cdesc,b.color_c,b.color_y,b.color_oth" +
                ",b.prd_process_id,b.prd_process_cdesc,b.prd_process_oth,b.prd_process_color,b.prd_process_id1,b.prd_process_cdesc1,b.prd_process_oth1,b.prd_process_color1" +
                ",b.zipper_head,i.cdesc As zipper_head_cdesc,b.zipper_head_oth,b.naked_select,b.naked_cdesc As naked_select_cdesc" +
                ",b.mat_type,d.mat_cdesc,b.zipper_color,b.zipper_color_oth" +
                ",b.manu_craft_group,g.cdesc As manu_craft_group_cdesc,b.manu_craft_id,b.manu_craft_cdesc,b.manu_craft_oth" +
                ",b.pull_card_no,b.pull_card_color_id,b.pull_card_color,b.goods_id,b.mo_id,b.zipper_tooth,k.cdesc As zipper_tooth_cdesc,b.test_std_cdesc,b.test_std_oth" +
                ",b.prd_use,l.cdesc As prd_use_cdesc,b.prd_use_oth,b.cloth_type,b.order_qty,b.goods_unit,b.sample_qty" +
                ",b.size,f.unit_cdesc AS size_unit_cdesc,b.size_cm,b.size_inc,b.size_diff,m.cdesc As size_diff_cdesc,b.size_diff_oth,b.pack_type,n.cdesc As pack_type_cdesc,b.pack_type_oth" +
                ",b.wash_type,o.cdesc As wash_type_cdesc,b.wash_type_oth,b.brand_id,b.remark1,b.remark2,b.cust_goods_style"+
                ",Case When b.to_pr_state ='0' then '未申購' else '已申購' end As to_pr_state" +
                ",p.mo_id As oc_mo_id,p.goods_id As oc_goods_id,q.name As oc_goods_name,p.order_qty As oc_order_qty,p.goods_unit As oc_goods_unit"+
                " From so_zipper_order_head a " +
                " Inner Join so_zipper_order_details b On a.within_code=b.within_code And a.id=b.id" +
                " Left Join bs_mat_type d On b.mat_type=d.mat_code " +
                " Left Join bs_manufacture_craft e On b.spec_id=e.id" +
                " Left Join bs_unit f On b.size_unit=f.unit_id" +
                " Left Join bs_manufacture_craft g On b.manu_craft_group=g.id" +
                " Left Join bs_manufacture_craft i On b.zipper_head=i.id" +
                " Left Join bs_manufacture_craft k On b.zipper_tooth=k.id" +
                " Left Join bs_manufacture_craft l On b.prd_use=l.id" +
                " Left Join bs_manufacture_craft m On b.size_diff=m.id" +
                " Left Join bs_manufacture_craft n On b.pack_type=n.id" +
                " Left Join bs_manufacture_craft o On b.wash_type=o.id" +
                " Left Join " + remote_db + "it_customer c On a.within_code=c.within_code COLLATE Chinese_PRC_CI_AS And a.it_customer=c.id COLLATE Chinese_PRC_CI_AS " +
                " Left Join " + remote_db + "so_order_details p On b.within_code=p.within_code COLLATE Chinese_PRC_CI_AS And b.prd_seq=p.draw_id COLLATE Chinese_PRC_CI_AS" +
                " Left Join "+remote_db+"it_goods q On p.within_code=q.within_code And p.goods_id=q.id"+
                " Where a.within_code='" + within_code + "'";
            if (id != "")
                strSql += " And a.id='" + id + "'";
            if (to_pr_state == 0)
                strSql += " And b.to_pr_state ='0'";
            else
                if (to_pr_state == 1)
                    strSql += " And b.to_pr_state ='1' ";
            strSql += " Order By b.mat_type,a.id,b.sequence_id";
            DataTable dtId = clsPublicOfCF01.GetDataTable(strSql);
            dtId.Columns.Add("is_select", System.Type.GetType("System.Boolean"));
            return dtId;
        }
        public static DataTable loadOcData(string mo_id)
        {
            string strSql = "";
            strSql = " Select b.goods_id,Convert(INT,b.order_qty) As order_qty,b.goods_unit,c.name As goods_name,d.production_remark" +
                " From so_order_manage a" +
                " Inner Join so_order_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver" +
                " Left Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                " Left Join so_order_special_info d On b.within_code=d.within_code And b.id=d.id And b.ver=d.ver And b.sequence_id=d.upper_sequence"+
                " Where a.within_code='" + within_code + "' And b.mo_id='" + mo_id + "'";
            DataTable dtOc = clsConnGeo.GetDataTable(strSql);
            return dtOc;
        }
        public static bool checkPrd_seqInOc(string prd_seq)
        {
            bool result = false;
            string strSql = "";
            strSql = " Select draw_id From so_order_details Where within_code='" + within_code + "' And draw_id='" + prd_seq + "'";
            DataTable dtOc = clsConnGeo.GetDataTable(strSql);
            if (dtOc.Rows.Count > 0)
                result = true;
            return result;
        }
        public static string insertToGeoPr(int upd_flag,so_zipper_pr_head objModel, List<so_zipper_pr_details> lsPms)
        {
            int result = 0;
            string strSql = "";
            string strSql_u = "";
            string id = "";
            int seq_count = 1;
            int sub_seq_count = 1;
            string sequence_id = "";
            string sub_sequence_id = "";
            string id_seq = "";
            id = objModel.id;
            
            strSql += " BEGIN TRAN ";
            strSql_u += " BEGIN TRAN ";
            if (id == "")
            {
                id_seq = getGeoPrId(objModel.dep);
                id = "D" + id_seq;
                strSql += string.Format(@"UPDATE sys_bill_max_separate SET bill_code='{0}' Where within_code='{1}' And bill_id='{2}' And bill_text2='{3}'"
                        , id_seq, within_code, "PO07", objModel.dep);
                strSql += string.Format(@" INSERT INTO po_application_buy(" +
                         " within_code,id,ap_date,beginning_time,end_time,ap_source,sanction_state,sanction_date,update_count,transfers_state" +
                        ",state,create_date,create_by,update_date,update_by,ap_sum,pg_sum,tax_sum,origin_id,department_id,bill_type_no)" +
                         " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'" +
                        " ,'{15}','{16}','{17}','{18}','{19}','{20}')"
                         , within_code, id, objModel.ap_date, objModel.beginning_time, objModel.end_time, "0", "0", objModel.create_date, "1", "0"
                         , "0", objModel.create_date, objModel.userid, objModel.create_date, objModel.userid, 0, 0, 0, "1", objModel.dep, "1");
            }
            seq_count = getGeoPrMaxSeq("po_ap_details", id) + 1;
            sub_seq_count = getGeoPrMaxSeq("po_ap_schedule", id) + 1;
            for (int i = 0; i < lsPms.Count; i++)
            {
                sequence_id = seq_count.ToString().PadLeft(4, '0') + "h";
                strSql += string.Format(@" INSERT INTO po_ap_details(" +
                 " within_code,id,sequence_id,mrp_id,goods_id,goods_name,goods_unit,ap_qty,price,mrp_qty,qty_on_hand,sanction_qty" +
                 ",buy_qty,sanction_state,transfers_state,remark,ap_sum,disc_amt,cess,price_fare,dst_no,demand_date,sec_unit,mo_id,sec_qty)" +
                 " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'" +
                " ,'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')"
                 , within_code, id, sequence_id, "0", lsPms[i].goods_id, lsPms[i].goods_name, lsPms[i].goods_unit, lsPms[i].ap_qty, 0, 0, 0, 0
                 , 0, "0", "0", lsPms[i].remark, 0, 0, 0, 0, lsPms[i].goods_id, lsPms[i].req_date, lsPms[i].sec_unit, lsPms[i].mo_id, lsPms[i].sec_qty);
                sub_sequence_id = sub_seq_count.ToString().PadLeft(4, '0') + "h";
                strSql += string.Format(@" INSERT INTO po_ap_schedule(" +
                 " within_code,id,upper_sequence,sequence_id,mrp_id,goods_id,goods_unit,ap_qty,mrp_qty,demand_date,sec_unit,mo_id,sec_qty)" +
                 " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')"
                 , within_code, id, sequence_id, sub_sequence_id, "0", lsPms[i].goods_id, lsPms[i].goods_unit, lsPms[i].ap_qty
                 , 0, lsPms[i].req_date, lsPms[i].sec_unit, lsPms[i].mo_id, lsPms[i].sec_qty);
                if (upd_flag == 1)
                    strSql_u += string.Format(@"UPDATE so_zipper_order_details SET to_pr_state='{0}' WHERE within_code='{1}' AND id='{2}' AND sequence_id='{3}' "
                        , "1", within_code, lsPms[i].old_id, lsPms[i].old_sequence_id);

                seq_count += 1;
                sub_seq_count += 1;
            }
            strSql += " COMMIT TRAN ";
            strSql_u += " COMMIT TRAN ";

            result = clsConnGeo.ExecuteSqlUpdate(strSql);
            if (result > 0 && upd_flag==1)
                if (clsPublicOfCF01.ExecuteSqlUpdate(strSql_u) != "")
                    result = 0;
            return id;
        }
        public static bool checkGeoPrId(string id)
        {
            bool result = true;
            string strSql = "";
            strSql = "Select state From po_application_buy Where within_code='" + within_code + "' And id='" + id + "'";
            DataTable dtId = clsConnGeo.GetDataTable(strSql);
            if (dtId.Rows.Count == 0)
            {
                MessageBox.Show("申購單記錄不存在,不能儲存!");
                result = false;
            }
            else
            {
                if (dtId.Rows[0]["state"].ToString() == "1")
                {
                    MessageBox.Show("申購單已批準,不能儲存!");
                    result = false;
                }
            }
            return result;
        }
        private static string getGeoPrId(string dep)
        {
            string result = "";
            string strSql = "";
            
            //strSql = "Select MAX(id) AS max_id From po_application_buy Where within_code='" + within_code + "' AND id>='" + id_type + "' And id<='" + id_type + "ZZZZZZZ" + "'";
            //DataTable dtId = clsConnGeo.GetDataTable(strSql);
            //if (dtId.Rows[0]["max_id"].ToString() == "")
            //    result = "0000001";
            //else
            //    result = (Convert.ToInt32(dtId.Rows[0]["max_id"].ToString().Substring(6, 7)) + 1).ToString().PadLeft(7, '0');
            //result = id_type + result;
            //return result;
            //P951-0000460
            strSql = "Select bill_code From sys_bill_max_separate Where within_code='" + within_code + "' And bill_id='PO07' And bill_text2='" + dep + "'";
            DataTable dtId = clsConnGeo.GetDataTable(strSql);
            if (dtId.Rows.Count==0)
                result = "0000001";
            else
                result = dtId.Rows[0]["bill_code"].ToString().Substring(0, 5)+(Convert.ToInt32(dtId.Rows[0]["bill_code"].ToString().Substring(5, 7)) + 1).ToString().PadLeft(7, '0');
            return result;

        }
        private static int getGeoPrMaxSeq(string tb_name,string id)
        {
            int seq = 0;
            string strSql;
            strSql = "Select Max(sequence_id) AS max_seq From "+tb_name+" Where within_code='" + within_code + "' AND id='" + id + "'";
            DataTable tbGenNo = clsConnGeo.GetDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
            {
                seq = 0;
            }
            else
                seq = Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(0, 4));
            return seq;
        }
        public static DataTable loadGeoPr(string id)
        {
            string strSql = "";
            strSql = " Select a.id,Convert(Varchar(20),a.ap_date,111) As ap_date,Convert(INT,b.ap_qty) As ap_qty,b.sequence_id,b.mo_id,b.goods_id,b.goods_unit,d.name As goods_name" +
                ",Convert(Decimal(18,2),b.sec_qty) As sec_qty,b.sec_unit,a.state,c.sequence_id As sub_sequence_id" +
                " From po_application_buy a" +
                " Inner Join po_ap_details b On a.within_code=b.within_code And a.id=b.id" +
                " Inner Join po_ap_schedule c On b.within_code=c.within_code And b.id=c.id And b.sequence_id=c.upper_sequence" +
                " Left Join it_goods d On b.within_code=d.within_code And b.goods_id=d.id" +
                " Where a.within_code='" + within_code + "' And a.id='" + id + "'";
            strSql += " Order By b.sequence_id Desc";
            DataTable dtPr = clsConnGeo.GetDataTable(strSql);
            return dtPr;
        }
        public static int deleteGeoPrIdDetails(string id,string seq,string sub_seq)
        {
            int result = 0;
            string strSql = "";
            strSql += string.Format(@"Delete From po_ap_details WHERE within_code='{0}' AND id='{1}' AND sequence_id='{2}' "
                        , within_code, id, seq);
            strSql += string.Format(@"Delete From po_ap_schedule WHERE within_code='{0}' AND id='{1}' AND upper_sequence='{2}' AND sequence_id='{3}' "
                        , within_code, id, seq,sub_seq);
            result = clsConnGeo.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static DataTable loadMoTest(string mo_id)
        {
            string strSql = "";
            strSql = " Select b.test_item_type,b.test_item_id,c.test_item_name,b.remark,b.update_by,Convert(Varchar(20),b.update_date,120) AS update_date" +
                " From so_order_details a" +
                " Inner Join so_order_special_qc b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.sequence_id=b.upper_sequence" +
                " Inner Join cd_qc_test_item c On b.within_code=c.within_code And b.test_item_type=c.test_item_type And b.test_item_id=c.test_item_id" +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "'";
            DataTable dtTest = clsConnGeo.GetDataTable(strSql);
            return dtTest;
        }
    }
}
