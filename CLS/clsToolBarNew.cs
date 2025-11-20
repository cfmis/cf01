using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace cf01.CLS
{
    public class clsToolBarNew
    {
        DataTable dtblRight = new DataTable();       
        ToolStrip tlstrip;
        string form_name;       
        public clsToolBarNew(string formName, ToolStrip tsp)
        {
            form_name = formName;
            tlstrip = tsp;            
        }

        public void SetToolBar()
        {
            //表單工具欄按鈕權限,按鈕需是以下列表中存在，否則無法控制權限 
            //BTNDEL_BATCH,BTNDELETE,BTNEDIT,BTNEXCEL,BTNFIND,BTNIMPORT,BTNINVOICE,BTNITEMADD,BTNITEMDEL,BTNNEW,
            //BTNNEWCOPY,BTNNEWVER,BTNPRINT,BTNPRINTA4,BTNPRINTA41,BTNQUOTATION,BTNSAVE,BTNSAVEPRINT,BTNSAVESET,BTNUPDATE
            string buttonName = string.Empty;
            string str = string.Format(@"Select id,state From dbo.v_user_popedom Where usr_no='{0}' And window_id='{1}'", DBUtility._user_id, form_name);
            dtblRight = clsPublicOfCF01.GetDataTable(str);
            if (dtblRight.Rows.Count == 0)
            {
                for (int i = 0; i < tlstrip.Items.Count; i++)
                {
                    tlstrip.Items[i].Enabled = false; //如沒有設置權限全禁用
                }
                return;
            }
            
            //檢查工作欄按鈕權限字串20171213改為從數據庫表中查找                        
            str = clsPublicOfCF01.ExecuteSqlReturnObject(@"SELECT stuff((Select ','+ltrim(button_id) From  tb_sy_toolbar FOR XML path('')),1,1,'')");
            DataRow[] drowArray = null;
            for (int i = 0; i < tlstrip.Items.Count; i++)
            {
                buttonName = tlstrip.Items[i].Name.ToUpper();
                if (buttonName.Substring(0, 3) == "BTN")
                {
                    if (tlstrip.Items[i].Enabled) //當按鈕可用狀態時再次檢查對應權限，重新校正
                    {
                        buttonName = buttonName.Trim();
                        drowArray = dtblRight.Select(string.Format("id = '{0}'", buttonName));
                        if (drowArray.Length > 0)
                        {
                            if (str.Contains(buttonName))
                            {
                                tlstrip.Items[i].Enabled = (bool)drowArray[0][1]; //設置工具欄按鈕可否操作
                            }
                        }
                        else
                            tlstrip.Items[i].Enabled = false;
                    }
                }
            }            
        }
        
    }
}
