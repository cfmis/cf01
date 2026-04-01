using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace cf01.CLS
{
    public class clsSaleReturn
    {
        private static clsPublicOfGEO clsErp = new clsPublicOfGEO();
        //private clsAppPublic clsAppPublic = new clsAppPublic();
        static string localIp = GetLocalIP();
        static string remote_db = DBUtility.remote_db_hk;
        public clsSaleReturn()
        {
            //string localIp = clsAppPublic.GetLocalIP();            
            if (localIp.Length >= 11)
            {
                if (localIp.Substring(0, 11) == "192.168.168")
                {
                    remote_db = "";
                }
            }
        }

        //獲取部門移交單批號
        public static string GetDeptLotNo(string out_dept, string in_dept)
        {
            string result = "";
            string strSql = string.Format(
            @" DECLARE @lot_no nvarchar(20) 
               EXEC usp_create_lot_no '{0}','{1}','{2}',@lot_no OUTPUT 
               SELECT @lot_no AS lot_no",
            "0000", out_dept, out_dept);
            DataTable dt = clsErp.ExecuteSqlReturnDataTable(strSql);
            result = dt.Rows[0]["lot_no"].ToString();
            return result;
        }

        public static string GetMaxID(string year_month)
        {
            //直接獲取或更新DGERP1中的sys_bill_max銷售退回的最大編號
            //string strIp = GetLocalIP();
            if (localIp.Substring(0, 11) == "192.168.168")
            {
                remote_db = "";
            }
            string result = string.Empty, bill_code = string.Empty;
            string strSql = string.Format(@"Select pkey,bill_code From {0}sys_bill_max WHERE within_code='0000' AND bill_id='SR01' AND year_month='{1}'", remote_db,year_month);
            DataTable dtBillMax = clsErp.GetDataTable(strSql);
            if (dtBillMax.Rows.Count > 0)
            {
                bill_code = "SR" + year_month + (int.Parse(dtBillMax.Rows[0]["bill_code"].ToString().Trim().Substring(6, 4)) + 1).ToString().PadLeft(4, '0'); //SR12090017
                int p_key = int.Parse(dtBillMax.Rows[0]["pkey"].ToString());
                strSql = string.Format(@"Update {0}sys_bill_max With(rowlock) SET bill_code='{1}' WHERE pkey={2}", remote_db, bill_code,p_key);
                if (clsErp.ExecuteSqlUpdate(strSql) < 0)
                {
                    result = "-1";
                }
                else
                {
                    result = bill_code;
                }                
            }
            else
            {
                bill_code = "SR" + year_month + "0001";
                strSql = string.Format(
                @"INSERT INTO {0}sys_bill_max(within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5) Values
                ('0000', 'SR01', '{1}', '{2}', '', '', '', '', '')", remote_db, year_month, bill_code);
                if (clsErp.ExecuteSqlUpdate(strSql) < 0)
                {
                    result = "-1";
                }
                else
                {
                    result = bill_code;
                }
            }
            return result;
        }

        public static DataTable GetDataInit()
        {
            string strSql =
            @"SELECT CAST(0 AS bit) AS flag_select,A.id,Convert(varchar(10),A.issues_date,120) as issues_date,A.type,A.it_customer,A.name,
            B.mo_id,B.goods_id,B.goods_name,Substring(A.cd_seller,2,1) As sales_group,B.contract_cid,A.cd_seller,
            CAST(B.invoice_qty AS INT) AS invoice_qty,B.issues_unit,B.sec_qty,B.sec_unit,B.sec_unit AS location_id,
            B.order_id,B.invoice_id,B.sequence_id
            FROM so_debitcredit_note_mostly A ,so_debeitcredit_note_details B 
            WHERE 1=0 ";
            DataTable dtInit = clsErp.GetDataTable(strSql);
            return dtInit;
        }

        public static DataTable GetDataFind(string id1,string id2,string issues_date1, string issues_date2,string it_customer,string sales_group)
        {
            StringBuilder sb = new StringBuilder(
            @"SELECT CAST(0 AS bit) AS flag_select,A.id,Convert(varchar(10),A.issues_date,120) AS issues_date,A.type,A.it_customer,A.name,
            B.mo_id,B.goods_id,B.goods_name,Substring(A.cd_seller,2,1) As sales_group,B.contract_cid,A.cd_seller,
            CAST(dbo.fn_z_Get_pcs_qty(B.invoice_qty,B.issues_unit) AS INT) AS invoice_qty,'PCS' AS issues_unit,
            B.sec_qty,B.sec_unit,C.location_id,B.order_id,B.invoice_id,B.sequence_id
            FROM so_debitcredit_note_mostly A with(nolock) 
            INNER JOIN so_debeitcredit_note_details B with(nolock) ON A.id=B.id And A.within_code=B.within_code
            INNER JOIN so_invoice_details C with(nolock) ON B.within_code=C.within_code And B.invoice_id=C.id And B.i_sequence_id=C.sequence_id
            INNER JOIN so_invoice_mostly D with(nolock) ON D.within_code=C.within_code And D.id=C.id And D.ver=C.ver And A.state NOT IN ('2','0')
            WHERE 1>0 ");

            if (id1 != "")
            {
                sb.Append(" And A.id>='" + id1 + "'");
            }
            if (id2 != "")
            {
                sb.Append(" And A.id<='" + id2 + "'");
            }
            if (id1 != "" && id2 != "")
            {
                sb.Append(string.Format(" And A.within_code = '{0}'", "0000"));
            }
            if (issues_date1 != "")
            {
                sb.Append(" And A.issues_date>='" + issues_date1 + "'");
            }
            if (issues_date2 != "")
            {
                sb.Append(" And A.issues_date<='" + issues_date2 + "'");
            }
            if (it_customer != "")
            {
                sb.Append(" And A.it_customer='" + it_customer + "'");
            }
            if (sales_group != "")
            {
                sb.Append(" And Substring(A.cd_seller,2,1)='" + sales_group + "'");
            }
            sb.Append(" And A.type='CR' AND A.state NOT IN ('2','0') And Isnull(B.flag_convert,'')<>'1'");
            sb.Append(" Order By C.location_id,A.it_customer,A.issues_date,A.id,B.sequence_id");
            DataTable dtFind = clsErp.GetDataTable(sb.ToString());
            return dtFind;
        }

        public static string GetLocalIP()
        {
            string strLocalIP = "";
            //获取本地网卡信息
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                //判断是否为以太网卡
                //Wireless80211         无线网卡    Ppp     宽带连接
                //Ethernet              以太网卡
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //获取以太网卡网络接口信息
                    IPInterfaceProperties ip = adapter.GetIPProperties();
                    //获取单播地址集
                    UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                    foreach (UnicastIPAddressInformation ipadd in ipCollection)
                    {
                        //InterNetwork    IPV4地址      InterNetworkV6        IPV6地址
                        //Max            MAX 位址
                        if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                        //判断是否为ipv4
                        {
                            strLocalIP = ipadd.Address.ToString();//获取ip
                            return strLocalIP;//获取ip

                        }
                    }
                }
            }
            return null;
        }



    }
}
