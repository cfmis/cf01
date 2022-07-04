using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cf01.MDL;
using System.IO;
using System.Threading;


namespace cf01.CLS
{
    public class clsDgdDeliverGoods
    {
        private static string within_code = DBUtility.within_code;
        private static string userid = DBUtility._user_id;
        private static string remote_db = DBUtility.remote_db;
        private static clsPublicOfGEO clsConnGeo = new clsPublicOfGEO();
        public static bool checkExistId(string id,int ver)
        {
            bool result = false;
            string strSql = String.Format("Select id From so_invoice_mostly Where within_code='{0}' AND id='{1}' AND ver='{2}'", within_code, id, ver);
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static string AddSoInvoiceHead(soinvoice_head objModel)
        {
            string id = "";
            int Result = 0;
            string strSql = "";
            try
            {
                id = objModel.id;
                if (id == "")
                {
                    id = getIdNo("so_invoice_mostly",objModel.sales_group, 8);
                }                
                if (checkExistId(id, objModel.ver) == false)
                {
                    strSql = @"insert into so_invoice_mostly (within_code, id,ver,separate,ship_date,it_customer,seller_id,m_id,bill_type_no
                                ,phone,fax,email,linkman,l_phone,exchange_rate,po_no,issues_wh,merchandiser,merchandiser_phone,shipping_methods,create_by,create_date,address_id)
                                Values(@within_code, @id,@ver,@separate,@ship_date,@it_customer,@seller_id,@m_id,@bill_type_no
                                ,@phone,@fax,@email,@linkman,@l_phone,@exchange_rate,@po_no,@issues_wh,@merchandiser,@merchandiser_phone,@shipping_methods,@create_by,@create_date,@address_id)";

                }
                else
                {
                    strSql = @"Update so_invoice_mostly Set separate=@separate,ship_date=@ship_date,it_customer=@it_customer,update_by=@update_by,update_date=@update_date
                                ,seller_id=@seller_id,m_id=@m_id,bill_type_no=@bill_type_no,phone=@phone,fax=@fax,email=@email,linkman=@linkman,l_phone=@l_phone,exchange_rate=@exchange_rate
                                ,po_no=@po_no,issues_wh=@issues_wh,merchandiser=@merchandiser,merchandiser_phone=@merchandiser_phone,shipping_methods=@shipping_methods,address_id=@address_id
                            Where within_code=@within_code And id=@id And ver=@ver";

                }
                //};
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",id),
                    new SqlParameter("@ver",objModel.ver),
                    new SqlParameter("@separate",objModel.separate),
                    new SqlParameter("@ship_date",objModel.ship_date),
                    new SqlParameter("@it_customer",objModel.it_customer),
                    new SqlParameter("@update_by",userid),
                    new SqlParameter("@update_date",DateTime.Now),
                    new SqlParameter("@seller_id",objModel.seller_id),
                    new SqlParameter("@m_id",objModel.m_id),
                    new SqlParameter("@bill_type_no",objModel.bill_type_no),
                    new SqlParameter("@phone",objModel.phone),
                    new SqlParameter("@fax",objModel.fax),
                    new SqlParameter("@email",objModel.email),
                    new SqlParameter("@linkman",objModel.linkman),
                    new SqlParameter("@l_phone",objModel.l_phone),
                    new SqlParameter("@exchange_rate",objModel.exchange_rate),
                    new SqlParameter("@po_no",objModel.po_no),
                    new SqlParameter("@issues_wh",objModel.issues_wh),
                    new SqlParameter("@create_by",userid),
                    new SqlParameter("@create_date",DateTime.Now),
                    new SqlParameter("@merchandiser",objModel.merchandiser),
                    new SqlParameter("@merchandiser_phone",objModel.merchandiser_phone),
                    new SqlParameter("@shipping_methods",objModel.shipping_methods),
                    new SqlParameter("@address_id",objModel.address_id)
                    };
                Result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Result <= 0)
                id = "";
            return id;
        }
        private static string getIdNo(string tb_name,string sales_group,int seq_len)
        {
            string seq = "";
            string strSql = String.Format("Select Max(id) AS max_seq From {0} Where within_code='{1}' AND id LIKE '{2}-%'", tb_name, within_code, sales_group);
            DataTable tbGenNo = clsPublicOfCF01.GetDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
            {
                if (seq_len == 8)
                    seq = "00000001";
                else
                    if (seq_len == 5)
                        seq = "00000001";
            }
            else
                if (tbGenNo.Rows[0]["max_seq"].ToString().Trim().Length >= (seq_len + 2))
                    seq = (Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(2, seq_len)) + 1).ToString().PadLeft(seq_len, '0');
                else
                    seq = "00000001";
            seq = sales_group+"-" + seq;
            return seq;
        }
        public static string AddSoInvoiceDetails(soinvoice_details objModel)
        {
            string Result = "";
            string strSql = "";
            string sequence_id = objModel.sequence_id;
            if (sequence_id == "")
                sequence_id = getSeq("so_invoice_details", objModel.id, 4);
            if (checkExistIdDetails(objModel.id, objModel.ver, sequence_id) == false)
            {
                strSql = @"insert into so_invoice_details (within_code, id,ver,sequence_id,mo_id,goods_id,goods_name,u_invoice_qty,goods_unit,u_invoice_qty_pcs,sec_qty,sec_unit,location_id,carton_code
                                ,shipment_suit,remark,package_num,box_no,order_id,so_ver,so_sequence_id,table_head,customer_goods,customer_color_id,contract_cid,is_print,state)
                                Values(@within_code, @id,@ver,@sequence_id,@mo_id,@goods_id,@goods_name,@u_invoice_qty,@goods_unit,@u_invoice_qty_pcs,@sec_qty,@sec_unit,@location_id,@carton_code
                                ,@shipment_suit,@remark,@package_num,@box_no,@order_id,@so_ver,@so_sequence_id,@table_head,@customer_goods,@customer_color_id,@contract_cid,@is_print,@state)";
            }
            else
            {
                strSql = @"Update so_invoice_details Set mo_id=@mo_id,goods_id=@goods_id,goods_name=@goods_name,u_invoice_qty=@u_invoice_qty
                                ,goods_unit=@goods_unit,u_invoice_qty_pcs=@u_invoice_qty_pcs,sec_qty=@sec_qty
                                ,sec_unit=@sec_unit,location_id=@location_id,carton_code=@carton_code,shipment_suit=@shipment_suit,remark=@remark,package_num=@package_num
                                ,box_no=@box_no,order_id=@order_id,so_ver=@so_ver,so_sequence_id=@so_sequence_id,table_head=@table_head
                                ,customer_goods=@customer_goods,customer_color_id=@customer_color_id,contract_cid=@contract_cid,is_print=@is_print
                            Where within_code=@within_code And id=@id And ver=@ver And sequence_id=@sequence_id";

            }
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",objModel.id),
                    new SqlParameter("@ver",objModel.ver),
                    new SqlParameter("@sequence_id",sequence_id),
                    new SqlParameter("@mo_id",objModel.mo_id),
                    new SqlParameter("@goods_id",objModel.goods_id),
                    new SqlParameter("@goods_name",objModel.goods_name),
                    new SqlParameter("@u_invoice_qty",objModel.u_invoice_qty),
                    new SqlParameter("@u_invoice_qty_pcs",objModel.u_invoice_qty_pcs),
                    new SqlParameter("@goods_unit",objModel.goods_unit),
                    new SqlParameter("@sec_qty",objModel.sec_qty),
                    new SqlParameter("@sec_unit",objModel.sec_unit),
                    new SqlParameter("@location_id",objModel.location_id),
                    new SqlParameter("@carton_code",objModel.carton_code),
                    new SqlParameter("@shipment_suit",objModel.shipment_suit),
                    new SqlParameter("@remark",objModel.remark),
                    new SqlParameter("@package_num",objModel.package_num),
                    new SqlParameter("@box_no",objModel.box_no),
                    new SqlParameter("@order_id",objModel.order_id),
                    new SqlParameter("@so_ver",objModel.so_ver),
                    new SqlParameter("@so_sequence_id",objModel.so_sequence_id),
                    new SqlParameter("@table_head",objModel.table_head),
                    new SqlParameter("@customer_goods",objModel.customer_goods),
                    new SqlParameter("@customer_color_id",objModel.customer_color_id),
                    new SqlParameter("@contract_cid",objModel.contract_cid),
                    new SqlParameter("@is_print",objModel.is_print),
                    new SqlParameter("@state",objModel.state)
                    };
            if (clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false) > 0)
                Result = sequence_id;
            else
                Result = "";

            return Result;
        }
        private static string getSeq(string tb_name, string id, int seq_len)
        {
            string seq = "";
            string strSql = String.Format("Select Max(sequence_id) AS max_seq From {0} Where within_code='{1}' AND id='{2}'", tb_name, within_code, id);
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
        public static bool checkExistIdDetails(string id, int ver,string seq)
        {
            bool result = false;
            string strSql = "";
            strSql = String.Format("Select id From so_invoice_details Where within_code='{0}' AND id='{1}' AND ver='{2}' AND sequence_id='{3}'", within_code, id, ver, seq);
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool checkExistIdDetailsReturnTable(string id, int ver, string seq)
        {
            bool result = true;
            string strSql = "";
            strSql = String.Format("Select id,state From so_invoice_details Where within_code='{0}' AND id='{1}' AND ver='{2}' AND sequence_id='{3}'", within_code, id, ver, seq);
            DataTable dtIdSeq = clsPublicOfCF01.GetDataTable(strSql);
            if (dtIdSeq.Rows.Count > 0)
            {
                if (dtIdSeq.Rows[0]["state"].ToString().Trim() == "1")
                {
                    result = false;
                }   
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static DataTable checkExistIdDetailsByMo(string id,string seq,string mo_id, string goods_id)
        {
            string strSql = "";
            strSql = "Select Sum(u_invoice_qty_pcs) As u_invoice_qty_pcs,Sum(sec_qty) As sec_qty" +
                " From so_invoice_details Where within_code='" + within_code + "' AND mo_id='" + mo_id + "' AND goods_id='" + goods_id + "'" +
                " And Not (id='" + id + "' AND sequence_id='" + seq + "')";
            DataTable dtIdSeq = clsPublicOfCF01.GetDataTable(strSql);
            return dtIdSeq;
        }
        //在儲存或刪除記錄時，檢查制單編號是否存在，并提示
        public static DataTable checkExistIdDetailsByMoSaveDelete(string id,string mo_id)
        {
            string strSql = "";
            strSql = "Select id,sequence_id" +
                " From so_invoice_details Where within_code='" + within_code + "'";
            if (id != "")
                strSql += " AND id='" + id + "'";
            if (mo_id != "")
                strSql += " AND mo_id='" + mo_id + "'";
            DataTable dtIdSeq = clsPublicOfCF01.GetDataTable(strSql);
            return dtIdSeq;
        }
        public static DataTable getIt_Customer(string cust)
        {
            DataTable dtCust = new DataTable();
            string strSql = "";
            strSql = "Select a.id,a.name,a.seller_id_1,a.money_id,b.s_address,b.phone,b.fax,b.email,a.fake_s_address " +
                " From it_customer a "+
                " Left Join it_shipment_address b On a.within_code=b.within_code And a.id=b.id"+
                " Where a.within_code='" + within_code + "' AND a.id='" + cust + "'";
            dtCust = clsConnGeo.GetDataTable(strSql);
            return dtCust;
        }
        public static DataTable getSalesUser()
        {
            DataTable dtSalesUser = new DataTable();
            string strSql = "";
            strSql = "Select id,name From cd_personnel Where within_code='" + within_code + "' And state='" + "0" + "' And sales_group Is Not Null";
            strSql += " ORDER BY id";
            dtSalesUser = clsConnGeo.GetDataTable(strSql);
            return dtSalesUser;
        }
        public static DataTable getCurr()
        {
            DataTable dtCurr = new DataTable();
            string strSql = "";
            strSql = "Select id,name From cd_money Where within_code='" + within_code + "'" ;
            strSql += " ORDER BY id";
            dtCurr = clsConnGeo.GetDataTable(strSql);
            dtCurr.Rows.Add();
            return dtCurr;
        }
        public static DataTable getUnit()
        {
            DataTable dtUnit = new DataTable();
            string strSql = "";
            strSql = "Select id,name From cd_units Where within_code='" + within_code + "'" + " AND kind='05'";
            strSql += " ORDER BY id";
            dtUnit = clsConnGeo.GetDataTable(strSql);
            return dtUnit;
        }
        public static DataTable getBill_type_no()
        {
            DataTable dtShipMent = new DataTable();
            string strSql = "";
            strSql = "Select id,name From cd_shipment Where within_code='" + within_code + "'";
            strSql += " ORDER BY id";
            dtShipMent = clsConnGeo.GetDataTable(strSql);
            return dtShipMent;
        }
        public static DataTable getLocNo(string sales_group)
        {
            DataTable dtLocNo = new DataTable();
            string strSql = "";
            strSql = "Select location_id,name From cd_carton_code Where within_code='" + within_code + "' And location_id=id ";
            if (sales_group == "L")
                strSql += " And location_id>'Y' And location_id<='YZZ'";
            else
                strSql += " And location_id>'D00' And location_id<='DZZ'";
            strSql += " ORDER BY id";
            dtLocNo = clsConnGeo.GetDataTable(strSql);
            return dtLocNo;
        }
        public static DataTable getCurrRate(string code)
        {
            DataTable dtCurrRate = new DataTable();
            string strSql = "";
            strSql = "Select exchange_rate From cd_exchange_rate Where within_code='" + within_code + "' And id='" + code + "' And state='0' ";
            strSql += " ORDER BY id";
            dtCurrRate = clsConnGeo.GetDataTable(strSql);
            return dtCurrRate;
        }
        public static DataTable loadSoInvoiceHead(string id)
        {
            DataTable dtSo = new DataTable();
            string strSql = "";
            strSql = "Select * From so_invoice_mostly Where within_code='" + within_code + "' And id='" + id + "'";
            strSql += " ORDER BY id";
            dtSo = clsPublicOfCF01.GetDataTable(strSql);
            return dtSo;
        }
        public static DataTable loadSoInvoiceDetails(string id)
        {
            DataTable dtSo = new DataTable();
            string strSql = "";
            strSql = "Select a.sequence_id,a.mo_id,a.goods_id,a.goods_name,Convert(INT,a.u_invoice_qty) As u_invoice_qty,Convert(INT,a.u_invoice_qty_pcs) As u_invoice_qty_pcs" +
                ",a.goods_unit,Convert(Decimal(18,2),a.sec_qty) As sec_qty,a.sec_unit" +
                ",a.location_id,a.customer_goods,a.customer_color_id,a.order_id,a.so_ver,a.so_sequence_id,a.table_head,a.customer_goods,a.customer_color_id,a.contract_cid" +
                ",Convert(INT,a.package_num) As package_num,a.box_no,a.remark,a.is_print,a.shipment_suit" +
                " From so_invoice_details a Where a.within_code='" + within_code + "' And a.id='" + id + "'";
            strSql += " ORDER BY a.id,a.sequence_id desc";
            dtSo = clsPublicOfCF01.GetDataTable(strSql);
            return dtSo;
        }
        public static DataTable getMoStore(string loc,string mo_id,string sales_group,string goods_id)
        {
            string strSql = "";
            if (sales_group == "C")
                strSql = "Select a.mo_id,a.goods_id,b.name As goods_name,Convert(INT,a.qty) As qty,a.sec_qty " +
                    " From st_details_lot a with(nolock) " +
                    " Left Join it_goods b with(nolock) On a.within_code=b.within_code And a.goods_id=b.id" +
                    " Where a.within_code='" + within_code + "' And a.location_id='" + loc + "'";
            else
                strSql = "Select a.mo_id,a.goods_id,b.name As goods_name,Convert(INT,a.order_qty) As qty,0 AS sec_qty " +
                " From so_order_details a with(nolock) " +
                " Left Join it_goods b with(nolock) On a.within_code=b.within_code And a.goods_id=b.id" +
                " Where a.within_code='" + within_code + "'";
            if (mo_id != "")
                strSql += " And a.mo_id='" + mo_id + "'";
            if (goods_id != "")
                strSql += " And a.goods_id='" + goods_id + "'";
            if (sales_group == "C")
                strSql += " And a.qty>0 ";
            else
                strSql += " And a.order_qty>0";
            strSql += " ORDER BY a.goods_id";
            DataTable dtStore = clsConnGeo.GetDataTable(strSql);
            return dtStore;
        }
        public static DataTable getMoStoreByItem(string loc, string mo_id,string goods_id)
        {
            string strSql = "";
            strSql = "Select Sum(a.qty) As qty,Sum(a.sec_qty) As sec_qty " +
                " From st_details_lot a with(nolock)" +
                " Where a.within_code='" + within_code + "' And a.mo_id='" + mo_id + "' And a.location_id='" + loc + "' And a.goods_id='" + goods_id + "' And a.qty>0 ";
            DataTable dtStore = clsConnGeo.GetDataTable(strSql);
            return dtStore;
        }
        public static DataTable getMoOc(string mo_id)
        {
            DataTable dtMoOc = new DataTable();
            string strSql = "";
            strSql = "Select a.id,a.contract_id,b.customer_goods,b.customer_color_id,b.table_head,b.goods_id,Convert(INT,b.order_qty) As order_qty,b.goods_unit,b.add_remark" +
                ",b.sequence_id,b.ver" +
                " From so_order_manage a with(nolock) " +
                " Inner Join so_order_details b with(nolock) On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver" +
                " Where a.within_code='" + within_code + "' And b.mo_id='" + mo_id + "'";
            dtMoOc = clsConnGeo.GetDataTable(strSql);
            return dtMoOc;
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

        public static int deleteDetails(string id, int ver, string seq)
        {
            int result = 0;
            string strSql = "";
            strSql = @"Delete From so_invoice_details Where within_code=@within_code And id=@id And ver=@ver And sequence_id=@sequence_id";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",id),
                    new SqlParameter("@ver",ver),
                    new SqlParameter("@sequence_id",seq)
                    };
            result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return result;
        }
        //刪除主表的記錄
        public static int deleteHhead(string id, int ver)
        {
            int result = 0;
            string strSql = "";
            strSql = @"Delete From so_invoice_mostly Where within_code=@within_code And id=@id And ver=@ver";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",id),
                    new SqlParameter("@ver",ver)
                    };
            result = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            return result;
        }
        public static string AddSoInvoiceHeadToGeo(soinvoice_head_geo objModel)
        {
            string id = "";
            int Result = 0;
            string strSql = "";
            try
            {
                id = objModel.id;
                if (id == "")
                {
                    string id_type = "D" + objModel.bill_type_no.Trim();//DS17800002
                    id_type += objModel.ship_date.ToString("yyyy/MM/dd").Substring(2, 2);//DS17
                    string id_month = objModel.ship_date.ToString("yyyy/MM/dd").Substring(5,2);
                    if (string.Compare(id_month, "10") < 0)
                        id_month = id_month.Substring(1, 1);
                    else
                        if (id_month == "10")
                            id_month = "A";
                        else
                            if (id_month == "11")
                                id_month = "B";
                            else
                                if (id_month == "12")
                                    id_month = "C";
                    id_type += id_month;
                    id = getIdNoGeo("so_invoice_mostly",id_type, 5);
                }
                if (checkExistIdGeo(id, objModel.ver) == false)
                {
                    strSql = @"insert into so_invoice_mostly (within_code, id,ver,separate,ship_date,it_customer,seller_id,m_id,bill_type_no
                                ,phone,fax,email,linkman,l_phone,exchange_rate,m_rate,po_no,issues_wh,create_by,create_date,flag
                                ,name,address,p_id,pc_id,cd_disc,disc_rate,disc_amt,disc_spare,other_fare,goods_sum,tax_sum
                                ,total_sum,ncr_amount,ncrb_amount,update_count,area,as_id,merchandiser,merchandiser_phone
                                ,finally_buyer,bill_address,confirm_status,packinglistno,mo_group,servername,fake_bill_address,fake_address
                                ,voucher_id,fake_name)
                                Values(@within_code, @id,@ver,@separate,@ship_date,@it_customer,@seller_id,@m_id,@bill_type_no
                                ,@phone,@fax,@email,@linkman,@l_phone,@exchange_rate,@m_rate,@po_no,@issues_wh,@create_by,@create_date,@flag
                                ,@name,@address,@p_id,@pc_id,@cd_disc,@disc_rate,@disc_amt,@disc_spare,@other_fare,@goods_sum,@tax_sum
                                ,@total_sum,@ncr_amount,@ncrb_amount,@update_count,@area,@as_id,@merchandiser,@merchandiser_phone
                                ,@finally_buyer,@bill_address,@confirm_status,@packinglistno,@mo_group,@servername,@fake_bill_address,@fake_address
                                ,@voucher_id,@fake_name)";

                
                }
                else
                {
                    strSql = @"Update so_invoice_mostly Set separate=@separate,ship_date=@ship_date,it_customer=@it_customer,update_by=@update_by,update_date=@update_date
                                ,seller_id=@seller_id,m_id=@m_id,bill_type_no=@bill_type_no,phone=@phone,fax=@fax,email=@email,linkman=@linkman,l_phone=@l_phone
                                ,exchange_rate=@exchange_rate,m_rate=@m_rate,po_no=@po_no,issues_wh=@issues_wh,flag=@flag
                                ,name=@name,address=@address,p_id=@p_id,pc_id=@pc_id,cd_disc=@cd_disc,disc_rate=@disc_rate,disc_amt=@disc_amt
                                ,disc_spare=@disc_spare,other_fare=@other_fare,goods_sum=@goods_sum,tax_sum=@tax_sum
                                ,total_sum=@total_sum,ncr_amount=@ncr_amount,ncrb_amount=@ncrb_amount,update_count=@update_count,area=@area,as_id=@as_id
                                ,merchandiser=@merchandiser,merchandiser_phone=@merchandiser_phone
                                ,finally_buyer=@finally_buyer,bill_address=@bill_address,confirm_status=@confirm_status,packinglistno=@packinglistno
                                ,mo_group=@mo_group,servername=@servername,fake_bill_address=@fake_bill_address,fake_address=@fake_address
                                ,voucher_id=@voucher_id,fake_name=@fake_name
                            Where within_code=@within_code And id=@id And ver=@ver";

                }
                //};
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@within_code",within_code),
                    new SqlParameter("@id",id),
                    new SqlParameter("@ver",objModel.ver),
                    new SqlParameter("@separate",objModel.separate),
                    new SqlParameter("@ship_date",objModel.ship_date),
                    new SqlParameter("@it_customer",objModel.it_customer),
                    new SqlParameter("@update_by",userid),
                    new SqlParameter("@update_date",DateTime.Now),
                    new SqlParameter("@seller_id",objModel.seller_id),
                    new SqlParameter("@m_id",objModel.m_id),
                    new SqlParameter("@bill_type_no",objModel.bill_type_no),
                    new SqlParameter("@phone",objModel.phone),
                    new SqlParameter("@fax",objModel.fax),
                    new SqlParameter("@email",objModel.email),
                    new SqlParameter("@linkman",objModel.linkman),
                    new SqlParameter("@l_phone",objModel.l_phone),
                    new SqlParameter("@exchange_rate",objModel.exchange_rate),
                    new SqlParameter("@m_rate",objModel.m_rate),
                    new SqlParameter("@po_no",objModel.po_no),
                    new SqlParameter("@issues_wh",objModel.issues_wh),
                    new SqlParameter("@create_by",userid),
                    new SqlParameter("@create_date",DateTime.Now),
                    new SqlParameter("@flag",objModel.flag),
                    new SqlParameter("@name",objModel.name),
                    new SqlParameter("@address",objModel.address),
                    new SqlParameter("@p_id",objModel.p_id),
                    new SqlParameter("@pc_id",objModel.pc_id),
                    new SqlParameter("@cd_disc",objModel.cd_disc),
                    new SqlParameter("@disc_rate",objModel.disc_rate),
                    new SqlParameter("@disc_amt",objModel.disc_amt),
                    new SqlParameter("@disc_spare",objModel.disc_spare),
                    new SqlParameter("@other_fare",objModel.other_fare),
                    new SqlParameter("@goods_sum",objModel.goods_sum),
                    new SqlParameter("@tax_sum",objModel.tax_sum),
                    new SqlParameter("@total_sum",objModel.total_sum),
                    new SqlParameter("@ncr_amount",objModel.ncr_amount),
                    new SqlParameter("@ncrb_amount",objModel.ncrb_amount),
                    new SqlParameter("@update_count",objModel.update_count),
                    new SqlParameter("@area",objModel.area),
                    new SqlParameter("@as_id",objModel.as_id),
                    new SqlParameter("@merchandiser",objModel.merchandiser),
                    new SqlParameter("@merchandiser_phone",objModel.merchandiser_phone),
                    new SqlParameter("@finally_buyer",objModel.finally_buyer),
                    new SqlParameter("@bill_address",objModel.bill_address),
                    new SqlParameter("@confirm_status",objModel.confirm_status),
                    new SqlParameter("@packinglistno",objModel.packinglistno),
                    new SqlParameter("@mo_group",objModel.mo_group),
                    new SqlParameter("@servername",objModel.servername),
                    new SqlParameter("@fake_bill_address",objModel.fake_bill_address),
                    new SqlParameter("@fake_address",objModel.fake_address),
                    new SqlParameter("@voucher_id",objModel.voucher_id),
                    new SqlParameter("@fake_name",objModel.fake_name)
                    };
                Result = clsConnGeo.ExecuteNonQuery(strSql, paras, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }
        public static bool checkExistIdGeo(string id, int ver)
        {
            bool result = false;
            string strSql = String.Format("Select id From so_invoice_mostly with(nolock) Where within_code='{0}' AND id='{1}' AND ver='{2}'", within_code, id, ver);
            if (clsConnGeo.GetDataTable(strSql).Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        private static string getIdNoGeo(string tb_name,string id_type, int seq_len)
        {
            string seq = "";
            string strSql = String.Format("Select Max(id) AS max_seq From {0} Where within_code='{1}' And id>='{2}' And id<='{2}ZZZZZ'", tb_name, within_code, id_type);
            DataTable tbGenNo = clsConnGeo.GetDataTable(strSql);
            if (tbGenNo.Rows[0]["max_seq"].ToString() == "")
            {
                seq = "00001";
            }
            else
                if (tbGenNo.Rows[0]["max_seq"].ToString().Trim().Length >= (seq_len + 5))
                    seq = (Convert.ToInt32(tbGenNo.Rows[0]["max_seq"].ToString().Substring(5, seq_len)) + 1).ToString().PadLeft(seq_len, '0');
                else
                    seq = "00001";
            seq = id_type + seq;//DS17800002
            return seq;
        }
        public static DataTable loadSoInvoiceHeadGeo(string id,int ver)
        {
            DataTable dtSo = new DataTable();
            string strSql = "";
            strSql = String.Format("Select * From so_invoice_mostly with(nolock) Where within_code='{0}' And id='{1}' And ver='{2}' ORDER BY id", within_code, id, ver);            
            dtSo = clsConnGeo.GetDataTable(strSql);
            return dtSo;
        }

        //提取沒有過賬的送貨單
        public static DataTable loadDgdDetails(string ocno,string id,string mo_id,int ntype)
        {
            DataTable dtSo = new DataTable();
            string strID; 
            if (ntype == 0)
            {
                strID = " NOT Like 'L-%'";//C組東莞D
            }
            else
            {
                strID = " Like 'L-%'";//L組發票格式
            }

            string strSql = "";
            strSql = String.Format(
               @"Select Convert(int,SUBSTRING(sequence_id,1,4)) as seq,a.id,Convert(Varchar(20),b.ship_date,111) AS ship_date,a.sequence_id,a.mo_id,a.goods_id,a.goods_name,
                Convert(INT,a.u_invoice_qty) As u_invoice_qty,Convert(INT,a.u_invoice_qty_pcs) As u_invoice_qty_pcs,a.goods_unit,
                Convert(Decimal(18,2),a.sec_qty) As sec_qty,a.sec_unit,a.location_id,a.customer_goods,a.customer_color_id,a.order_id,
                a.so_ver,a.so_sequence_id,a.table_head,a.customer_goods,a.customer_color_id,a.contract_cid,Convert(INT,a.package_num) As package_num,
                a.box_no,a.remark,a.is_print,a.shipment_suit 
                From so_invoice_details a Inner Join so_invoice_mostly b On a.within_code=b.within_code And a.id=b.id 
                Where a.within_code='{0}' And a.id {1} And a.state='0'", within_code, strID);
            if (ocno != "")
                strSql += String.Format(" And a.order_id='{0}'", ocno);
            if(id!="")
                strSql += String.Format(" And a.id='{0}'", id);
            if (mo_id != "")
                strSql += String.Format(" And a.mo_id='{0}'", mo_id);
            strSql += " ORDER BY a.order_id,a.so_sequence_id";
            dtSo = clsPublicOfCF01.GetDataTable(strSql);
            dtSo.Columns.Add("is_select", System.Type.GetType("System.Boolean"));
            return dtSo;
        }


        //查看OC的送貨單
        public static DataTable loadOcDgdDetails(string ocno)
        {
            DataTable dtSo = new DataTable();
            string strSql = "";
            strSql = String.Format(
                @"Select a.id,c.sequence_id,c.mo_id,c.goods_id,d.name As goods_name,Convert(INT,c.order_qty) As order_qty,
                   c.goods_unit As order_goods_unit,Convert(INT,a.u_invoice_qty) As u_invoice_qty,Convert(INT,a.u_invoice_qty_pcs) As u_invoice_qty_pcs,
                   a.goods_unit,Convert(Decimal(18,2),a.sec_qty) As sec_qty,a.sec_unit,a.location_id,a.customer_goods,a.customer_color_id,a.order_id,
                   a.so_ver,a.so_sequence_id,a.table_head,a.customer_goods,a.customer_color_id,a.contract_cid,Convert(INT,a.package_num) As package_num,
                   a.box_no,a.remark,a.is_print,a.shipment_suit,a.state 
                 From {0}so_order_details c with(nolock) 
                      Left Join {0}it_goods d with(nolock) On c.within_code=d.within_code And c.goods_id=d.id 
                      Left Join so_invoice_details a with(nolock) On c.within_code=a.within_code COLLATE Chinese_PRC_CI_AS And 
                           c.id =a.order_id COLLATE Chinese_PRC_CI_AS And c.sequence_id =a.so_sequence_id COLLATE Chinese_PRC_CI_AS 
                Where c.within_code='{1}'", remote_db, within_code);
            if (ocno != "")
                strSql += String.Format(" And c.id='{0}'", ocno);
            strSql += " ORDER BY a.mo_id";
            dtSo = clsPublicOfCF01.GetDataTable(strSql);
            return dtSo;
        }

        public static DataTable findIdDetails(string id1, string id2, string date1, string date2,string mo_id1,string mo_id2,string ocno,string pono)
        {
            string strSql = "";
            strSql = "Select a.id,Convert(Varchar(20),a.ship_date,111) As ship_date,b.sequence_id,b.mo_id,b.goods_id,Convert(INT,b.u_invoice_qty) As u_invoice_qty"+
                ",b.goods_unit,Convert(Decimal(18,2),b.sec_qty) As sec_qty,b.box_no,b.order_id,contract_cid as pono" +
                " From so_invoice_mostly a " +
                " Inner Join so_invoice_details b On a.within_code=b.within_code And a.id=b.id";
            strSql += String.Format(" Where a.within_code='{0}'", within_code);
            if (id1 != "" && id2 != "")
                strSql += String.Format(" And a.id>='{0}' And a.id<='{1}'", id1, id2);
            if (date1 != "" && date2 != "")
                strSql += String.Format(" And a.ship_date>='{0}' And a.ship_date<'{1}'", date1, date2);
            if (mo_id1 != "" && mo_id2 != "")
                strSql += String.Format(" And b.mo_id>='{0}' And b.mo_id<='{1}'", mo_id1, mo_id2);
            if(ocno!="")
                strSql += String.Format(" And b.order_id like '%{0}%'", ocno);
            if (pono != "")
                strSql += String.Format(" And b.contract_cid like '%{0}%'", pono);
            DataTable dtIdDetails = clsPublicOfCF01.GetDataTable(strSql);
            return dtIdDetails;
        }

        //查看當前OCNO,貨品,頁數是否曾經開有發票
        public static string Get_Invoice_No(string mo_id, string goods_id, string oc_no)
        {
            string result;
            string strSql = string.Format(
            @"Select A.id From so_invoice_mostly A with(nolock),so_invoice_details B with(nolock)
            Where A.within_code=B.within_code and A.id=B.id and A.ver=B.ver and A.state not in ('2','V') 
            AND B.mo_id='{0}' and B.goods_id='{1}' and B.order_id='{2}'", mo_id, goods_id, oc_no);
            result = clsConnGeo.ExecuteSqlReturnObject(strSql);
            return result;
        }

        //列印送貨單資料
        public static DataTable Get_Report_Data(string id,int rpt_type)
        {
            string sql =string.Format(
               @"SELECT A.id ,convert(varchar(10),A.ship_date,111) as ship_date,A.it_customer,C.name as customer_name,B.mo_id,Isnull(B.contract_cid,'') as contract_cid,B.table_head,
                 B.goods_name,Convert(int,B.u_invoice_qty) as u_invoice_qty,B.goods_unit,convert(Decimal(12,2),B.sec_qty) as sec_qty,convert(int,isnull(B.package_num,0)) as package_num,
                 isnull(B.box_no,'') as box_no,B.remark
                FROM so_invoice_mostly A with(nolock)
                INNER JOIN so_invoice_details B with(nolock) ON A.within_code=B.within_code and A.id=B.id and A.ver=B.ver 
                LEFT JOIN {0}it_customer C with(nolock) ON A.within_code=B.within_code and A.it_customer collate Chinese_PRC_CI_AS =C.id
                WHERE A.within_code='0000' and A.id='{1}'", remote_db,id);
            if (rpt_type==0)
                sql += " ORDER BY A.id,B.box_no,B.package_num,B.mo_id";
            else
                sql += " ORDER BY A.id,B.contract_cid,B.mo_id";

            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            return dt;           
        }

        //匯出EXCEL資料
        public static DataTable Get_Report_Data(string id1,string id2,string mo_id1,string mo_id2,string date1,string date2,int rpt_type, string sales_group)
        {            
            string sql = string.Format(
               @"SELECT A.id ,convert(varchar(10),A.ship_date,111) as ship_date,A.it_customer,C.name as customer_name,B.mo_id,Isnull(B.contract_cid,'') as contract_cid,B.table_head,
                 B.goods_name,Convert(int,B.u_invoice_qty) as u_invoice_qty,B.goods_unit,convert(Decimal(12,2),B.sec_qty) as sec_qty,convert(int,isnull(B.package_num,0)) as package_num,
                 isnull(B.box_no,'') as box_no,B.remark
                FROM so_invoice_mostly A with(nolock)
                INNER JOIN so_invoice_details B with(nolock) ON A.within_code=B.within_code and A.id=B.id and A.ver=B.ver 
                LEFT JOIN {0}it_customer C with(nolock) ON A.within_code=B.within_code and A.it_customer collate Chinese_PRC_CI_AS =C.id
                WHERE A.within_code='0000' AND A.id like '{1}-%'", remote_db, sales_group);
            if (id1 != "")
                sql += String.Format(" and A.id>='{0}'", id1);
            if (id2 != "")
                sql += String.Format(" and A.id<='{0}'", id2);
            if (mo_id1 != "")
                sql += String.Format(" and B.mo_id>='{0}'", mo_id1);
            if (mo_id2 != "")
                sql += String.Format(" and B.mo_id<='{0}'", mo_id2);
            if (date1 != "")
                sql += String.Format(" and A.ship_date>='{0}'", date1);
            if (date2 != "")
                sql += String.Format(" and A.ship_date<='{0}'", date2);
            if (rpt_type == 0)
                sql += " ORDER BY A.id,B.box_no,B.package_num,B.mo_id";
            else
                sql += " ORDER BY A.id,B.contract_cid,B.mo_id";
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            return dt;           
        }

        //獲取發票資料
        public static DataTable Get_Invoice_Data(string id1, string id2, string mo_id1, string mo_id2, string date1, string date2)
        {
            SqlParameter[] paras = new SqlParameter[]{
               new SqlParameter("@id1",id1),
               new SqlParameter("@id2",id2),
                new SqlParameter("@mo_id1",mo_id1),
               new SqlParameter("@mo_id2",mo_id2),
                new SqlParameter("@date1",date1),
               new SqlParameter("@date2",date2)
            };

            DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_custom_invoice", paras);
            return dt;
        }

        //獲取裝箱單數據
        public static DataTable Get_Packing_Data(string id1, string id2, string mo_id1, string mo_id2, string date1, string date2)
        {
            SqlParameter[] paras = new SqlParameter[]{
               new SqlParameter("@id1",id1),
               new SqlParameter("@id2",id2),
               new SqlParameter("@mo_id1",mo_id1),
               new SqlParameter("@mo_id2",mo_id2),
               new SqlParameter("@date1",date1),
               new SqlParameter("@date2",date2)
            };

            DataTable dt = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_packing_list", paras);
            return dt;
        }

        public static string getUserGroup(string user_id)
        {
            string result = "";
            string strSql = String.Format("Select isnull(user_group,'') as user_group From tb_sy_user Where uname='{0}'", user_id);
            DataTable dtUser=clsPublicOfCF01.GetDataTable(strSql);
            if (dtUser.Rows.Count > 0)
            {
                result = dtUser.Rows[0]["user_group"].ToString();
            }
            return result;
        }


        /// <summary>
        /// 匯出L組發票格式
        /// </summary>
        /// <param name="dt"></param>
        public static void Export_to_Invoice(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {                
                SaveFileDialog saveDialog = new SaveFileDialog();
                //saveDialog.DefaultExt = "";
                saveDialog.Title = "保存EXECL文件";
                saveDialog.Filter = "EXECL文件|*.xls";
                saveDialog.FilterIndex = 1;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    int FormatNum;//保存excel文件的格式
                    string Version;//excel版本號

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
                        return;
                    }
                    Version = xlApp.Version;//獲取當前使用excel版本號
                    if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                    {
                        FormatNum = -4143;
                    }
                    else //you use excel 2007 or later
                    {
                        FormatNum = 56;
                    }
                    
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
                    
                    //第一行为报表名称
                    worksheet.Cells[1, 1] = "COMMERCIAL INVOICE"; //標題地址
                    worksheet.Range["A1:I1"].Merge(0);//合并单元格
                    worksheet.Rows[1].Font.Size = 11;
                    worksheet.Rows[1].Font.Bold = true;//粗體
                    worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].RowHeight = 30;
                    //第二行
                    worksheet.Cells[2, 1] = dt.Rows[0]["company_cf"].ToString();   //CF
                    worksheet.Cells[2, 4] = dt.Rows[0]["invoice_date"].ToString(); //發票日期
                    worksheet.Range["A2:C2"].Merge(0);//合并单元格
                    worksheet.Range["D2:I2"].Merge(0);
                    worksheet.Rows[2].Font.Size = 10;                    
                    worksheet.Rows[2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[2].RowHeight = 52;
                    //第三行
                    worksheet.Cells[3, 1] = dt.Rows[0]["bill_to"].ToString();   //BILL_TO
                    worksheet.Cells[3, 4] = dt.Rows[0]["ship_to"].ToString(); //ship_to
                    worksheet.Range["A3:C3"].Merge(0);//合并单元格
                    worksheet.Range["D3:I3"].Merge(0);
                    worksheet.Rows[3].Font.Size = 10;
                    worksheet.Rows[3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[3].RowHeight = 80;
                    //第四、五行
                    worksheet.Cells[4, 1] = dt.Rows[0]["notify"].ToString();   //notify
                    worksheet.Cells[5, 1] = dt.Rows[0]["departure_date"].ToString();   //departure_date
                    worksheet.Cells[4, 4] = dt.Rows[0]["bank_info"].ToString(); //bank_info
                    worksheet.Range["A4:C4"].Merge(0);//合并单元格
                    worksheet.Range["A5:C5"].Merge(0);//合并单元格
                    worksheet.Range["D4:I5"].Merge(0);
                    worksheet.Rows[4].Font.Size = 10;
                    worksheet.Rows[5].Font.Size = 10;
                    worksheet.Rows[4].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    //worksheet.Rows[4].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;//*****
                    worksheet.Rows[5].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[4].RowHeight = 45;
                    worksheet.Rows[5].RowHeight = 30;
                    //第六、七行
                    worksheet.Cells[6, 1] = dt.Rows[0]["make_from_info"].ToString();   //make_from_info
                    worksheet.Cells[7, 1] = dt.Rows[0]["send_to_info"].ToString();   //send_to_info
                    worksheet.Cells[6, 4] = dt.Rows[0]["treams_info"].ToString(); //treams_info
                    worksheet.Range["A6:C6"].Merge(0);//合并单元格
                    worksheet.Range["A7:C7"].Merge(0);//合并单元格
                    worksheet.Range["D6:I7"].Merge(0);
                    worksheet.Rows[6].Font.Size = 10;
                    worksheet.Rows[7].Font.Size = 10;
                    worksheet.Rows[6].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[7].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[6].RowHeight = 25;
                    worksheet.Rows[7].RowHeight = 31;
                    
                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();

                    //寫入欄位標題                   
                    worksheet.Cells[8, 1] = "ORDER NO.";
                    worksheet.Cells[8, 2] = "PO/ITEM";
                    worksheet.Cells[8, 3] = "GOODS DESERIPTION";
                    worksheet.Cells[8, 4] = "SIZE";
                    worksheet.Cells[8, 5] = "COLOR";
                    worksheet.Cells[8, 6] = "QTY";
                    worksheet.Cells[8, 7] = "PRICE (USD)";
                    worksheet.Cells[8, 8] = "AMOUNT (USD)";
                    worksheet.Cells[8, 9] = "REMARK";
                    worksheet.Rows[8].RowHeight = 23;
                    worksheet.Rows[8].Font.Size = 9;
                    worksheet.Rows[8].Font.Bold = true;
                    worksheet.Rows[8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    //標題自動換行
                    Microsoft.Office.Interop.Excel.Range Range1 = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("F8", "G8");
                    Range1.WrapText = true;
                    //寫入數值                    
                    const int rs = 9;
                    int cur_row=0;
                    int qty = 0;
                    decimal total_amt = 0;
                    for (int r = 0; r < dt.Rows.Count; r++)//行
                    {
                        cur_row = rs + r;
                        worksheet.Cells[cur_row, 1] = "'" + dt.Rows[r]["invoice_remark"];
                        worksheet.Cells[cur_row, 2] = "'" + dt.Rows[r]["poitem"];
                        worksheet.Cells[cur_row, 3] = "'" + dt.Rows[r]["customer_goods"];
                        worksheet.Cells[cur_row, 4] = dt.Rows[r]["customer_size"].ToString();
                        worksheet.Cells[cur_row, 5] = dt.Rows[r]["customer_color_id"].ToString();
                        worksheet.Cells[cur_row, 6] = dt.Rows[r]["order_qty"].ToString();
                        worksheet.Cells[cur_row, 7] = dt.Rows[r]["unit_price_pcs"].ToString();
                        worksheet.Cells[cur_row, 8] = dt.Rows[r]["total_sum"].ToString();
                        worksheet.Cells[cur_row, 10] = dt.Rows[r]["mo_id"].ToString();                        
                        worksheet.Rows[cur_row].Font.Size = 10;
                        worksheet.Cells[cur_row, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Cells[cur_row, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Cells[cur_row, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Cells[cur_row, 7].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Cells[cur_row, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        qty += int.Parse(dt.Rows[r]["order_qty"].ToString());
                        total_amt += decimal.Parse(dt.Rows[r]["total_sum"].ToString());
                        System.Windows.Forms.Application.DoEvents();
                    }
                    //設置列寬度
                    worksheet.Columns[1].ColumnWidth = 13;
                    worksheet.Columns[2].ColumnWidth = 13;
                    worksheet.Columns[3].ColumnWidth = 27;
                    worksheet.Columns[4].ColumnWidth = 12;
                    worksheet.Columns[5].ColumnWidth = 12;
                    worksheet.Columns[6].ColumnWidth = 10;//數量
                    worksheet.Columns[7].ColumnWidth = 8;//單價
                    worksheet.Columns[8].ColumnWidth = 11;//金額
                    worksheet.Columns[9].ColumnWidth = 15;//備註
                    
                    //最后一行匯總
                    cur_row = cur_row + 1;
                    worksheet.Cells[cur_row, 1] = "TOTAL";
                    worksheet.Cells[cur_row, 6] = qty;
                    worksheet.Cells[cur_row, 8] = total_amt;
                    worksheet.Cells[cur_row , 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells[cur_row, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    string strRang = string.Format("A{0}:E{0}", cur_row );
                    worksheet.Range[strRang].Merge(0);//合并单元格
                    worksheet.Rows[cur_row].Font.Size = 10;
                    worksheet.Rows[cur_row].Font.Bold = true ;
                    
                    //获取Excel多个单元格区域
                    string rang = string.Format("I{0}", cur_row);//右下角座標
                    Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A1", rang);
                    //单元格边框线类型(线型,虚线型)
                    excelRange.Borders.LineStyle = 1;
                    excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                    wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            //workbook.SaveCopyAs(saveFileName);
                            workbook.SaveAs(FileName, FormatNum);
                            //fileSaved = true;  
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;  
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁                   
                    MessageBox.Show("匯出EXCEL成功!","系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 匯出L組裝箱單
        /// </summary>
        /// <param name="dt"></param>
        public static void Export_to_PackingList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                //saveDialog.DefaultExt = "";
                saveDialog.Title = "保存EXECL文件";
                saveDialog.Filter = "EXECL文件|*.xls";
                saveDialog.FilterIndex = 1;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    int FormatNum;//保存excel文件的格式
                    string Version;//excel版本號

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
                        return;
                    }
                    Version = xlApp.Version;//獲取當前使用excel版本號
                    if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                    {
                        FormatNum = -4143;
                    }
                    else //you use excel 2007 or later
                    {
                        FormatNum = 56;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
                    //第一行
                    worksheet.Range["A1:M1"].Merge(0);//合并单元格
                    //第二行
                    worksheet.Range["A2:M2"].Merge(0);//合并单元格
                    //第三行为报表名称
                    worksheet.Cells[3, 1] = dt.Rows[0]["ship_to"].ToString(); //標題地址
                    worksheet.Range["A3:M3"].Merge(0);//合并单元格
                    worksheet.Rows[3].Font.Name = "Times New Roman";
                    worksheet.Rows[3].Font.Size = 10;
                    worksheet.Rows[3].Font.Bold = true;//粗體
                    worksheet.Rows[3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[3].RowHeight = 80;
                    //第四行
                    worksheet.Cells[4, 1] = "ATTN:";
                    worksheet.Range["A4:M4"].Merge(0);//合并单元格
                    worksheet.Rows[4].Font.Size = 10;
                    worksheet.Rows[4].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Rows[4].RowHeight = 18;
                    //第五行
                    worksheet.Cells[5, 1] = "PACKING LIST";   //packing list                  
                    worksheet.Range["A5:M5"].Merge(0);//合并单元格    
                    worksheet.Rows[5].Font.Name = "Times New Roman";
                    worksheet.Rows[5].Font.Size = 16;
                    worksheet.Rows[5].Font.Bold = true;//粗體
                    worksheet.Rows[5].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[5].RowHeight = 30;
                    //第六行
                    worksheet.Cells[6, 8] = dt.Rows[0]["invoice_date"].ToString(); 
                    worksheet.Range["H6:I6"].Merge(0);//合并单元格   
                    worksheet.Rows[6].Font.Name = "Times New Roman";
                    worksheet.Rows[6].Font.Size = 9;                    
                    worksheet.Rows[6].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;                    
                    worksheet.Rows[6].RowHeight = 15;
                    //七行寫入欄位標題 
                    worksheet.Cells[7, 1] = "CTN";   
                    worksheet.Cells[7, 2] = "OR-NO";
                    worksheet.Cells[7, 3] = "ITEM";
                    worksheet.Cells[7, 4] = "SIZE";
                    worksheet.Cells[7, 5] = "COLOR";
                    worksheet.Cells[7, 6] = "QTY";
                    worksheet.Cells[7, 7] = "PRICE (USD)";
                    worksheet.Cells[7, 8] = "AMOUNT (USD)";
                    worksheet.Cells[7, 9] = "WEIGHT (KG)";
                    worksheet.Cells[7, 10] = "BOX SIZE (CM))";
                    worksheet.Cells[7, 11] = "CBM (Cu.METERS)";
                    worksheet.Cells[7, 12] = "REMARK";
                    worksheet.Cells[7, 13] = "Hardware ID";
                    worksheet.Rows[7].Font.Size = 10;
                    worksheet.Rows[7].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;                    
                    worksheet.Rows[7].RowHeight = 35;
                    //標題自動換行
                    Microsoft.Office.Interop.Excel.Range Range1 = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("G7", "K7");
                    Range1.WrapText = true;

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();
                   
                    //寫入數值                    
                    const int rs = 8;
                    int cur_row = 0;                    
                    decimal total_amt = 0;
                    for (int r = 0; r < dt.Rows.Count; r++)//行
                    {
                        cur_row = rs + r;
                        worksheet.Cells[cur_row, 2] = "'" + dt.Rows[r]["invoice_remark"];
                        worksheet.Cells[cur_row, 3] = "'" + dt.Rows[r]["customer_goods"];
                        worksheet.Cells[cur_row, 4] = dt.Rows[r]["customer_size"].ToString();
                        worksheet.Cells[cur_row, 5] = dt.Rows[r]["customer_color_id"].ToString();
                        worksheet.Cells[cur_row, 6] = dt.Rows[r]["order_qty"].ToString();
                        worksheet.Cells[cur_row, 7] = dt.Rows[r]["unit_price_pcs"].ToString();
                        worksheet.Cells[cur_row, 8] = dt.Rows[r]["total_sum"].ToString();
                        worksheet.Cells[cur_row, 9] = dt.Rows[r]["tal_gw"].ToString();
                        worksheet.Cells[cur_row, 10] = dt.Rows[r]["packing_size"].ToString();
                        worksheet.Cells[cur_row, 12] = dt.Rows[r]["id"].ToString();
                        worksheet.Cells[cur_row, 14] = dt.Rows[r]["mo_id"].ToString();
                        worksheet.Rows[cur_row].Font.Size = 10;
                        worksheet.Rows[cur_row].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Cells[cur_row, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        worksheet.Cells[cur_row, 5].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; 
                        worksheet.Cells[cur_row, 6].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        worksheet.Cells[cur_row, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        worksheet.Rows[cur_row].RowHeight = 18;                       
                        
                        total_amt += decimal.Parse(dt.Rows[r]["total_sum"].ToString());
                        System.Windows.Forms.Application.DoEvents();
                    }
                    //設置列寬度
                    worksheet.Columns[1].ColumnWidth = 6;
                    worksheet.Columns[2].ColumnWidth = 10;
                    worksheet.Columns[3].ColumnWidth = 22;
                    worksheet.Columns[4].ColumnWidth = 7;
                    worksheet.Columns[5].ColumnWidth = 8;
                    worksheet.Columns[6].ColumnWidth = 8;
                    worksheet.Columns[7].ColumnWidth = 8;//單價
                    worksheet.Columns[8].ColumnWidth = 9;//金額
                    worksheet.Columns[9].ColumnWidth = 7;//重量
                    worksheet.Columns[10].ColumnWidth = 10;//box
                    worksheet.Columns[11].ColumnWidth = 12;
                    worksheet.Columns[12].ColumnWidth = 12;
                    worksheet.Columns[13].ColumnWidth = 11;
                    worksheet.Columns[14].ColumnWidth = 10;

                    //最后一行匯總
                    cur_row = cur_row + 1;
                    worksheet.Cells[cur_row, 8] = total_amt;
                    worksheet.Cells[cur_row, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;                                      
                    worksheet.Rows[cur_row].Font.Size = 10;
                    worksheet.Rows[cur_row].Font.Bold = true;

                    //Borders.LineStyle 单元格边框线
                    //Microsoft.Office.Interop.Excel.Range excelRange = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[4, 6]);                    
                    string strRang = string.Format("M{0}", cur_row);
                    //获取Excel多个单元格区域
                    Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A7", strRang);
                    //单元格边框线类型(线型,虚线型)
                    excelRange.Borders.LineStyle = 1;
                    excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            //workbook.SaveCopyAs(saveFileName);
                            workbook.SaveAs(FileName, FormatNum);
                            //fileSaved = true;  
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;  
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁                   
                    MessageBox.Show("匯出Packing List成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static DataTable Get_Address()
        {
            string strSql = "";
            strSql = "Select id,cdesc From so_address_mostly order by id";
            DataTable dtAddres = clsPublicOfCF01.GetDataTable(strSql);
            return dtAddres;
        }



    }
}
