using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace cf01.CLS
{
    public class clsToolBar
    {
        DataTable dtblRight = new DataTable();
        Control.ControlCollection objControls;
        string form_name;       
        public clsToolBar(string pFormName, Control.ControlCollection cts)
        {
            form_name = pFormName;
            objControls = cts;            
        }

        public void SetToolBar()
        {
            //表單工具欄按鈕權限 
            //BTNDEL_BATCH,BTNDELETE,BTNEDIT,BTNEXCEL,BTNFIND,BTNIMPORT,BTNINVOICE,BTNITEMADD,BTNITEMDEL,BTNNEW,
            //BTNNEWCOPY,BTNNEWVER,BTNPRINT,BTNPRINTA4,BTNPRINTA41,BTNQUOTATION,BTNSAVE,BTNSAVEPRINT,BTNSAVESET
            string sqlstr = string.Format(@"Select id,state From dbo.v_user_popedom Where usr_no='{0}' And window_id='{1}'", DBUtility._user_id, form_name);           
            dtblRight = clsPublicOfCF01.GetDataTable(sqlstr);
            setValue(objControls);

            //2017-10-20取消此舊代碼
            // 取得工具欄按鈕權限加到臨時表
            //DBUtility._user_id = "TEST_123";//登錄的用戶id  調試單獨運行此表單請啟用此行，項目運行請注銷些行   
            //string sqlstr = string.Format(@"Select * From dbo.tb_sy_user_popedom Where usr_no='{0}' And window_id='{1}'", DBUtility._user_id, form_name);
            //DataTable dt = clsPublicOfCF01.GetDataTable(sqlstr);
            //if (dt.Rows.Count > 0)
            //{
            //    int location = 0;
            //    string strtmp = "";
            //    string strLeft = "";
            //    string column_name = "";
            //    string field_Name = "";
            //    string field_state = "";
            //    DataRow[] dr = dt.Select();
            //    if (!dtblRight.Columns.Contains("id"))//結構是否建立
            //    {
            //        dtblRight.Columns.Add("id", Type.GetType("System.String"));
            //        dtblRight.Columns.Add("state", Type.GetType("System.Boolean"));
            //    }
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        column_name = dt.Columns[i].ToString();
            //        location = column_name.IndexOf("_");
            //        strtmp = column_name.Substring(location + 1, 2);

            //        if (strtmp == "ID" && column_name.Length <= 6)
            //        {
            //            strLeft = column_name.Substring(0, location);
            //            field_Name = String.Format("{0}_ID", strLeft);
            //            field_state = String.Format("{0}_STATE", strLeft);
            //            if (dr[0][field_Name].ToString() != "")
            //            {
            //                DataRow newRow = dtblRight.NewRow();
            //                newRow["id"] = dr[0][field_Name].ToString();
            //                newRow["state"] = dr[0][field_state];
            //                dtblRight.Rows.Add(newRow);
            //            }
            //        }
            //    }
            //}            
            //setValue(objControls);
        }


        /// <summary>
        /// 表單控件翻譯及工具欄按鈕權限
        /// </summary>
        /// <param name="objectname">控件集</param> 
        /// <param name="strControl">需要控制按鈕名字串</param>   
        private void setValue(Control.ControlCollection objcts)//, string strControl)
        {
            bool flag = false;//退出循環標志
            foreach (Control ct in objcts)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip":
                        ToolStrip ts = (ToolStrip)ct;
                        if (dtblRight.Rows.Count == 0)
                        {
                            for (int i = 0; i < ts.Items.Count; i++)
                            {
                                ts.Items[i].Enabled = false; //如沒有設置權限全禁用
                            }
                            return;
                        }
                        string objName;
                        //檢查工作欄按鈕權限字串20171213改為從數據庫表中查找                        
                        string strCtls = clsPublicOfCF01.ExecuteSqlReturnObject(@"SELECT stuff((Select ','+ltrim(button_id) From  tb_sy_toolbar FOR XML path('')),1,1,'')");
                        flag = true;
                        for (int i = 0; i < ts.Items.Count; i++)
                        {
                            objName = ts.Items[i].Name.ToUpper();
                            if (objName.Substring(0, 3) == "BTN")
                            {
                                if (ts.Items[i].Enabled) //當按鈕可用狀態時再次檢查對應權限，重新校正
                                {
                                    objName = objName.Trim();
                                    DataRow[] dr = dtblRight.Select(String.Format("id = '{0}'", objName));
                                    if (dr.Length > 0)
                                    {
                                        if (strCtls.Contains(objName))
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


    }
}
