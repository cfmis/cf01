using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using cf01.ModuleClass;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace cf01.CLS
{
    public class clsAppPublic
    {
        /// <summary>
        /// 檢查制單頁數是否存在
        /// </summary>
        /// <param name="pMO"></param>
        /// <returns></returns>
        //private clsPublicOfGEO clsConErp = new clsPublicOfGEO();


        public float Return_Float_Value(string pValue)
        {
            float fResult;

            if (!string.IsNullOrEmpty(pValue))
            {
                fResult = float.Parse(pValue);
            }
            else
            {
                fResult = 0.000f;
            }

            if (fResult > 0)
            {
                fResult = (float)Math.Round(fResult, 3);
            }
            else
            {
                fResult = 0.000f;
            }
            return fResult;
        }

        public float Return_Float_Value_4(string pValue)
        {
            float fResult;

            if (!string.IsNullOrEmpty(pValue))
            {
                fResult = float.Parse(pValue);
            }
            else
            {
                fResult = 0.0000f;
            }

            if (fResult > 0)
            {
                fResult = (float)Math.Round(fResult, 4);
            }
            else
            {
                fResult = 0.0000f;
            }
            return fResult;
        }

        public string Return_String_Date(string pDate)
        {
            string strDate;
            if (string.IsNullOrEmpty(pDate))
            {
                strDate = "";
            }
            else
            {                
                strDate = DateTime.Parse(pDate).Date.ToString("yyyy-MM-dd");
                //strDate = pDate.Substring(0, 10);
            }
            return strDate;
        }

          private static DataTable dt_toobar = new DataTable();
       
        public void SetToolBarEnable(string pFormName, Control.ControlCollection cts)
        {            
            //表單工具欄按鈕權限           
            //string sqlstr = string.Format(@"Select * From dbo.tb_sy_user_popedom Where usr_no='{0}' And window_id='{1}'", DBUtility._user_id, pFormName);
            string sqlstr = string.Format(@"Select id,state From dbo.v_user_popedom Where usr_no='{0}' And window_id='{1}'", DBUtility._user_id, pFormName);
            dt_toobar = clsPublicOfCF01.GetDataTable(sqlstr);
            setValue(cts);
            
            /*
            // 取得工具欄按鈕權限加到臨時表
            DataTable dt = clsPublicOfCF01.GetDataTable(sqlstr);
            if (dt.Rows.Count > 0)
            {
                int location = 0;
                string strtmp = "";
                string strLeft = "";
                string column_name = "";
                string field_Name = "";
                string field_state = "";
                DataRow[] dr = dt.Select();                
                if (!dt_toobar.Columns.Contains("id"))//結構是否建立
                {
                    dt_toobar.Columns.Add("id", Type.GetType("System.String"));
                    dt_toobar.Columns.Add("state", Type.GetType("System.Boolean"));
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    column_name = dt.Columns[i].ToString();
                    location = column_name.IndexOf("_");
                    strtmp = column_name.Substring(location + 1, 2);

                    if (strtmp == "ID" && column_name.Length <= 6)
                    {
                        strLeft = column_name.Substring(0, location);
                        field_Name = String.Format("{0}_ID", strLeft);
                        field_state = String.Format("{0}_STATE", strLeft);
                        if (dr[0][field_Name].ToString() != "")
                        {
                            DataRow newRow = dt_toobar.NewRow();
                            newRow["id"] = dr[0][field_Name].ToString();
                            newRow["state"] = dr[0][field_state];
                            dt_toobar.Rows.Add(newRow);
                        }
                    }
                }
            }
            setValue(cts);*/
        }

        /// <summary>
        /// 表單工具菜單欄按鈕權限
        /// </summary>
        /// <param name="objectname">控件集</param>         
        public void setValue(Control.ControlCollection cts)
        {
            bool flag = false;//退出循環標志
            foreach (Control ct in cts)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip":
                        ToolStrip ts = (ToolStrip)ct;
                        if (dt_toobar.Rows.Count == 0)
                        {
                            for (int i = 0; i < ts.Items.Count; i++)
                            {
                                ts.Items[i].Enabled = false; //如沒有設置權限全禁用
                            }
                            return;
                        }                        
                        string objName;                        
                        //檢查工作欄按鈕字串于20171213改為從數據庫表中查找                        
                        string strControl = clsPublicOfCF01.ExecuteSqlReturnObject(@"SELECT stuff((Select ','+ltrim(button_id) From  tb_sy_toolbar FOR XML path('')),1,1,'')");
                        flag = true;
                        for (int i = 0; i < ts.Items.Count; i++)
                        {
                            objName = ts.Items[i].Name.ToUpper();
                            if (objName.Substring(0, 3) == "BTN")
                            {
                                if (ts.Items[i].Enabled) //當按鈕可用狀態時再次檢查對應權限，重新校正
                                {
                                    objName = objName.Trim();
                                    DataRow[] dr = dt_toobar.Select(String.Format("id = '{0}'", objName));
                                    if (dr.Length > 0)
                                    {
                                        if (strControl.Contains(objName))
                                        {
                                            ts.Items[i].Enabled = (Boolean)dr[0][1]; //設置工具欄按鈕可否操作
                                        }
                                    }
                                    else
                                        ts.Items[i].Enabled = false;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    if (!flag)
                    {
                        setValue(ct.Controls);
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 保存查詢條件
        /// </summary>
        /// <param name="pWindow_id"></param>
        /// <param name="cts"></param>
        public int set_find_Value(string pWindow_id, Control.ControlCollection cts)
        {
            string sql_i = @"INSERT INTO sy_find_set(window_id,user_id,object_id,object_value) values(@window_id,@user_id,@object_id,@object_value)";
            string sql_u = @"Update sy_find_set SET object_value=@object_value WHERE window_id=@window_id AND user_id=@user_id AND object_id=@object_id";
            string sql_f = "";
            string strResult = "";
            string object_id, object_value;
            int result = 0;
            foreach (Control ct in cts)
            {
                switch (ct.GetType().Name)
                {
                    case "DataGridView": //DataGridView列表                    
                        continue;
                    case "TextEdit":
                        TextEdit ts1 = (TextEdit)ct;
                        object_id = ts1.Name;
                        object_value = ts1.Text;
                        break;
                    case "TextBox":
                        TextBox ts2 = (TextBox)ct;
                        object_id = ts2.Name;
                        object_value = ts2.Text;
                        break;
                    case "DateEdit":
                        DateEdit ts3 = (DateEdit)ct;
                        object_id = ts3.Name;
                        if (ts3.EditValue == null)
                            object_value = "";
                        else
                            object_value = ts3.EditValue.ToString();
                        break;
                    case "LookUpEdit":
                        LookUpEdit ts4 = (LookUpEdit)ct;
                        object_id = ts4.Name;
                        object_value = ts4.EditValue.ToString();
                        break;
                    case "ComboBox":
                        System.Windows.Forms.ComboBox ts5 = (System.Windows.Forms.ComboBox)ct;
                        object_id = ts5.Name;
                        object_value = ts5.Text;
                        break;
                    case "CheckEdit":
                        CheckEdit ts6 = (CheckEdit)ct;
                        object_id = ts6.Name;
                        object_value = ts6.Checked.ToString();
                        break;
                    case "CheckBox":
                        CheckBox ts7 = (CheckBox)ct;
                        object_id = ts7.Name;
                        object_value = ts7.Checked.ToString();
                        break;
                    case "DateTimePicker":
                        DateTimePicker ts8 = (DateTimePicker)ct;
                        object_id = ts8.Name;
                        object_value = ts8.Text;
                        break;
                    case "RadioGroup":
                        RadioGroup ts9 = (RadioGroup)ct;
                        object_id = ts9.Name;
                        object_value = ts9.SelectedIndex.ToString();
                        break;
                    default:
                        object_id = "";
                        object_value = "";
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    set_find_Value(pWindow_id, ct.Controls);
                }
                if (!string.IsNullOrEmpty(object_id))
                {
                    SqlParameter[] paras = new SqlParameter[]
                    {                    
                        new SqlParameter("@window_id", pWindow_id),
                        new SqlParameter("@user_id", DBUtility._user_id),
                        new SqlParameter("@object_id",object_id),
                        new SqlParameter("@object_value", object_value) 
                    };
                    sql_f = string.Format("Select '1' From sy_find_set Where window_id='{0}' AND user_id='{1}' AND object_id='{2}'", pWindow_id, DBUtility._user_id, object_id);
                    strResult = clsPublicOfCF01.ExecuteSqlReturnObject(sql_f);                    
                    try
                    {
                        if (string.IsNullOrEmpty(strResult))
                        {
                            result=clsPublicOfCF01.ExecuteNonQuery(sql_i, paras, false);
                        }
                        else
                        {
                            result=clsPublicOfCF01.ExecuteNonQuery(sql_u, paras, false);
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                        result = 0;
                        break;
                    }
                    
                }
            }
            return result;            
        }

        /// <summary>
        /// 初始化查詢條件
        /// </summary>
        /// <param name="pWindow_id"></param>
        /// <param name="cts"></param>
        public void Initialize_find_value(string pWindow_id, Control.ControlCollection cts)
        {
            string sql_f = string.Format("Select * From sy_find_set Where window_id='{0}' AND user_id='{1}'", pWindow_id, DBUtility._user_id);
            DataTable dt = new DataTable();
            dt = clsPublicOfCF01.GetDataTable(sql_f);
            string object_id;
            foreach (Control ct in cts)
            {
                switch (ct.GetType().Name)
                {
                    case "DataGridView": //DataGridView列表                    
                        continue;
                    case "TextEdit":
                        TextEdit ts1 = (TextEdit)ct;
                        object_id = ts1.Name;
                        ts1.Text = Return_object_value(dt, object_id);
                        break;
                    case "TextBox":
                        TextBox ts2 = (TextBox)ct;
                        object_id = ts2.Name;
                        ts2.Text = Return_object_value(dt, object_id);
                        break;
                    case "DateEdit":
                        DateEdit ts3 = (DateEdit)ct;
                        object_id = ts3.Name;
                        ts3.Text = Return_object_value(dt, object_id);                        
                        break;
                    case "LookUpEdit":
                        LookUpEdit ts4 = (LookUpEdit)ct;
                        object_id = ts4.Name;
                        ts4.EditValue = Return_object_value(dt, object_id);
                        break;
                    case "ComboBox":
                        System.Windows.Forms.ComboBox ts5 = (System.Windows.Forms.ComboBox)ct;
                        object_id = ts5.Name;
                        ts5.Text = Return_object_value(dt, object_id);
                        break;
                    case "CheckEdit":
                        CheckEdit ts6 = (CheckEdit)ct;
                        object_id = ts6.Name;
                        if (Return_object_value(dt, object_id) == "False" || Return_object_value(dt, object_id) == "")
                            ts6.Checked = false;
                        else
                            ts6.Checked = true;
                        break;
                    case "CheckBox":
                        CheckBox ts7 = (CheckBox)ct;
                        object_id = ts7.Name;
                        if (Return_object_value(dt, object_id) == "False" || Return_object_value(dt, object_id) == "")
                            ts7.Checked = false;
                        else
                            ts7.Checked = true;
                        break;
                    case "DateTimePicker":
                        DateTimePicker ts8 = (DateTimePicker)ct;
                        object_id = ts8.Name;
                        ts8.Text = Return_object_value(dt, object_id);
                        break;
                    case "RadioGroup":
                        RadioGroup ts9 = (RadioGroup)ct;
                        object_id = ts9.Name;
                        if ((Return_object_value(dt, object_id) == ""))
                        {
                            ts9.SelectedIndex = 0;
                        }
                        else
                        {
                            ts9.SelectedIndex = Convert.ToInt16(Return_object_value(dt, object_id));
                        }
                        break;
                    default:
                        object_id = "";
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    //set_find_Value(pWindow_id, ct.Controls);
                    Initialize_find_value(pWindow_id, ct.Controls);
                }
            }
        }

        private string Return_object_value(DataTable dt, string pObject_id)
        {
            string result = "";
            DataRow[] dr = dt.Select(String.Format("object_id='{0}'", pObject_id));
            if (dr.Length > 0)
                result = dr[0]["object_value"].ToString();
            else
                result = "";
            return result;
        }

        public void RetSetImage(ToolStrip ts)
        {
            //因翻譯部分代碼的影響，當前菜單按鈕圖片及文本樣式異常.
            //所以重新執行以下代碼
            for (int i = 0; i < ts.Items.Count; i++)
            {
                ts.Items[i].ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }
        //获取本地IP
        public string GetLocalIP()
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
