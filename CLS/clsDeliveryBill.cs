using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Data;

namespace cf01.CLS
{
    public class clsDeliveryBill
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        //設置客戶編號
        public static void SetCustomer(LookUpEdit objLookUpEdit)
        {
            DataTable dtCustomer = clsConErp.GetDataTable(@"SELECT id,name AS cdesc FROM dbo.it_customer Where within_code='0000' And customer_group='1' and state not in ('2','V')");
            SetTypeDropValue(dtCustomer, objLookUpEdit);
            objLookUpEdit.Properties.ValueMember = "id";
            objLookUpEdit.Properties.DisplayMember = "id";
        }
        //出貨倉庫
        public static void SetWH(LookUpEdit objLookUpEdit)
        {
            DataTable dtWH = clsConErp.GetDataTable(@"SELECT id,name AS cdesc FROM cd_mo_type WHERE within_code ='0000' and mo_type='7'");
            SetTypeDropValue(dtWH, objLookUpEdit);
        }
        //貨幣
        public static void SetCNY(LookUpEdit objLookUpEdit)
        {
            //DataTable dtCNY = clsConErp.GetDataTable(@"SELECT id,id+' ['+name+']' AS cdesc FROM cd_money WHERE within_code ='0000' and state not in('2','V')");
            DataTable dtCNY = clsConErp.GetDataTable(
            @"SELECT A.id,A.name as cdesc,A.exchange_rate as m_rate FROM cd_exchange_rate A 
		     INNER JOIN (SELECT id, MAX(days) AS days FROM cd_exchange_rate Where within_code='0000' and state not in('2','V') GROUP BY id) AS B ON A.id = B.id AND A.days=B.days
             WHERE A.within_code ='0000' and A.state not in('2','V')");
             SetTypeDropValue(dtCNY, objLookUpEdit);
        }

        //稅種
        public static void SetTax(LookUpEdit objLookUpEdit)
        {
            DataTable dtTax = clsConErp.GetDataTable(@"SELECT id,name AS cdesc,isnull(cess,0) as cess FROM cd_cess_kind WHERE within_code ='0000' and state not in('2','V')");
            SetTypeDropValue(dtTax, objLookUpEdit);
        }
        
        //附款方法       
        public static void SetPayment(LookUpEdit objLookUpEdit)
        {
            DataTable dtPayment = clsConErp.GetDataTable(@"SELECT id,id+' ['+name+']' AS cdesc FROM cd_payment WHERE within_code ='0000' and state not in('2','V')");
            SetTypeDropValue(dtPayment, objLookUpEdit);
        }

        //附款條件       
        public static void SetPayment_Condition(LookUpEdit objLookUpEdit)
        {
            DataTable dtPayment_Condition = clsConErp.GetDataTable(@"SELECT id,id+' ['+name+']' AS cdesc FROM cd_payment_condition WHERE within_code ='0000' and state not in('2','V')");
            SetTypeDropValue(dtPayment_Condition, objLookUpEdit);
        }
        //港口資料       
        public static void SetPort(LookUpEdit objLookUpEdit)
        {
            DataTable dtPort = clsConErp.GetDataTable(@"SELECT id,id+' ['+name+']' AS cdesc FROM cd_port WHERE within_code ='0000' and state not in('2','V') order by id");
            SetTypeDropValue(dtPort, objLookUpEdit);     
        }
        //區域
        public static void SetZone(LookUpEdit objLookUpEdit)
        {
            DataTable dtZone = clsConErp.GetDataTable(@"SELECT id,name AS cdesc FROM cd_zone WHERE within_code ='0000' and state not in('2','V') order by id");
            SetTypeDropValue(dtZone, objLookUpEdit);
        }
        //跟單
        public static void SetMerchandiser(LookUpEdit objLookUpEdit)
        {
            DataTable dtMerchandiser = clsConErp.GetDataTable(
            @"Select id,id+'['+name+']' as cdesc From cd_personnel Where within_code='0000' and ISNULL(sales_group,'')<>'' order by id");
            SetTypeDropValue(dtMerchandiser, objLookUpEdit);         
        }
        //單據種類
        public static void SetInvoice_Type(LookUpEdit objLookUpEdit)
        {
            DataTable dtInv = clsConErp.GetDataTable(
            @"Select id,id +'['+name+']' as cdesc From cd_shipment Where within_code='0000' order by id");
            SetTypeDropValue(dtInv, objLookUpEdit);            
        }
        //裝運單方式
        public static void SetShipping(LookUpEdit objLookUpEdit)
        {
            DataTable dtShipping = clsConErp.GetDataTable(@"SELECT id,name AS cdesc FROM cd_shipping_mode WHERE within_code ='0000' and state not in('2','V')");
            SetTypeDropValue(dtShipping, objLookUpEdit);
            objLookUpEdit.Properties.ValueMember = "id";
            objLookUpEdit.Properties.DisplayMember = "id";
        }
        //銀行賬號        
        public static void SetBank(LookUpEdit objLookUpEdit)
        {
            DataTable dtBank = clsConErp.GetDataTable(@"SELECT bank AS id,accounts as cdesc FROM cd_company_accounts WHERE within_code='0000' and state not in('2','V')");
            SetTypeDropValue(dtBank, objLookUpEdit);
            objLookUpEdit.Properties.ValueMember = "cdesc";
            objLookUpEdit.Properties.DisplayMember = "cdesc";
        }
        //運輸途徑
        public static void SetTransport(LookUpEdit objLookUpEdit)
        {
            DataTable dtTransport = clsConErp.GetDataTable(@"SELECT id,id +' ['+name+']' as cdesc FROM cd_mo_type WHERE within_code='0000' and mo_type='B' and state not in('2','V')");
            SetTypeDropValue(dtTransport, objLookUpEdit);            
        }        
        ////數量單位
        //public static void SetUnit(LookUpEdit objLookUpEdit)
        //{
        //    DataTable dtTransport = clsConErp.GetDataTable(@"SELECT id,name as cdesc FROM cd_units WHERE within_code='0000' and kind='05' and state not in ('2','V')");
        //    SetTypeDropValue(dtTransport, objLookUpEdit);
        //    objLookUpEdit.Properties.ValueMember = "id";
        //    objLookUpEdit.Properties.DisplayMember = "id";
        //} 
        //倉位
        public static void SetLocation(LookUpEdit objLookUpEdit)
        {
            DataTable dtTransport = clsConErp.GetDataTable(@"SELECT id,id+' ' +name as cdesc FROM cd_productline WHERE within_code='0000' AND storehouse_group='DG' AND type ='01' AND state not in('V','2')");
            SetTypeDropValue(dtTransport, objLookUpEdit);  
        }    
   
        public static void SetTypeDropValue(DataTable Pdtbl, LookUpEdit PLookUpEdit)
        {
            DataRow dr0 = Pdtbl.NewRow(); //插一空行        
            Pdtbl.Rows.InsertAt(dr0, 0);           
            PLookUpEdit.Properties.DataSource = Pdtbl;
            PLookUpEdit.Properties.ValueMember = "id";
            PLookUpEdit.Properties.DisplayMember = "cdesc";
        }

        public static bool Check_Add_Popedom(string window_id)
        {
            bool flag=false;
            string strsql = string.Format(@"Select C2_STATE FROM tb_sy_user_popedom WHERE usr_no='{0}' and Window_id='{1}' and C2_ID='BTNNEW'", DBUtility._user_id,window_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
            if (dt.Rows.Count == 0)
            {              
                flag = false;
            }
            if (dt.Rows[0]["C2_STATE"].ToString() == "True")
                flag = true; 
            else
                flag = false;
            return flag;
        }

        //For vat
        public static DataTable GetVatReportDataById(string id)
        {
            string strsql =string.Format(
            @"Select a.within_code,	a.id,a.name,a.issues_date As oi_date,isnull(a.packinglistno,'') As packinglistno,
	        a.state,b.mo_id,b.contract_cid,b.goods_name,Convert(int,b.issues_qty) As issues_qty,cd_units.name as goods_unit,ROUND(Convert(float,b.sec_qty),2) AS sec_qty,
	        Convert(int,isnull(b.piece_num,0)) As package_num,isnull(b.package_no,'') As box_no,c.add_remark as remark,Isnull(c.table_head,'') As table_head,
	        isnull(b.customer_goods,'') As customer_goods
            From so_issues_mostly a with(nolock)
            Inner Join so_issues_details b with(nolock) On a.within_code = b.within_code  And a.id = b.id 
            Inner join so_order_details c with(nolock) on b.within_code=c.within_code and b.mo_id=c.mo_id
            Left Outer Join it_goods On b.within_code = it_goods.within_code And b.goods_id = it_goods.id			
            Left Outer Join cd_units On b.within_code = cd_units.within_code And b.issues_unit = cd_units.id
            WHERE a.within_code='0000' And a.id='{0}' And a.state NOT IN('2','V')", id);
            DataTable dt = clsConErp.GetDataTable(strsql);
            return dt;
        }

        public static DataTable GetVatReportDataByBoxNo(string box_no)
        {
            string strsql = string.Format(
            @"Select a.within_code,a.id,a.name,Convert(varchar(10),a.issues_date,111) As oi_date,isnull(a.packinglistno,'') As packinglistno,
	        a.state,b.mo_id,b.contract_cid,b.goods_name,Convert(int,b.issues_qty) As issues_qty,cd_units.name As goods_unit,
            ROUND(Convert(float,b.sec_qty),2) AS sec_qty,Convert(int,isnull(b.piece_num,0)) As package_num,
	        isnull(b.package_no,'') As box_no,c.add_remark as remark,Isnull(c.table_head,'') As table_head
            From so_issues_mostly a with(nolock) 
            Inner Join so_issues_details b with(nolock) On a.within_code = b.within_code  And a.id = b.id  
            Inner join so_order_details c on b.within_code=c.within_code and b.mo_id=c.mo_id
            Left Outer Join it_goods On b.within_code = it_goods.within_code And b.goods_id = it_goods.id			
            Left Outer Join cd_units On b.within_code = cd_units.within_code And b.issues_unit = cd_units.id
            WHERE a.within_code='0000' And a.packinglistno='{0}' And a.state NOT IN('2','V')
            ORDER BY a.packinglistno,b.package_no,a.id,b.sequence_id", box_no);
            DataTable dt = clsConErp.GetDataTable(strsql);
            return dt;
        }
      
    }
}
