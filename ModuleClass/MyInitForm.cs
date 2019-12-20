using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace cf01.ModuleClass
{
    class MyInitForm
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dt_toobar = new DataTable();
        private string con_str = System.Configuration.ConfigurationManager.AppSettings["conn_string_dgsql1"];

        public MyInitForm()
        {
        }

        public void SetForm(string formName, Control.ControlCollection cts, string formName_id)
        {
            //表單控件翻譯
            string language = DBUtility._language; //獲取默認的語             
            string sqlstr = "select * from v_dict_group where formname = '" + formName_id + " ' " + " AND language_id= '" + language + " ' ";
            try
            {
                ds = CLS.clsPublicOfCF01.ExcuteSqlReturnDataSet(sqlstr, "");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


            //表單工具欄按鈕權限
            DBUtility._user_id = "admin";//登錄的用戶id  調試單獨運行此表單請啟用此行，項目運行請注銷些行   
            sqlstr = "select * from dbo.tb_sy_user_popedom Where usr_no='" + DBUtility._user_id + "'" + " And window_id='" + formName + "'";

            try
            {
                dt = CLS.clsPublicOfCF01.GetDataTable(sqlstr);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


            if (dt.Rows.Count > 0)
            {
                GetToolbarGrant(dt); //取得工具欄按鈕的操作權限
                setValue(cts); //取得窗體控件翻譯 
            }
            else
            {
                MessageBox.Show("請首先設置窗體工具欄按鈕對應的權限表！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ds = null;
            dt = null;
            dt_toobar = null;

        }


        /// <summary>
        /// 取得工具欄按鈕權限臨時表
        /// </summary>
        public void GetToolbarGrant(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                int location = 0;
                string strtmp = "";
                string strLeft = "";
                string column_name = "";
                string field_Name = "";
                string field_state = "";
                DataRow[] dr = dt.Select();
                DataColumn dc = null;
                dc = dt_toobar.Columns.Add("id", Type.GetType("System.String"));
                dc = dt_toobar.Columns.Add("state", Type.GetType("System.Boolean"));

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    column_name = dt.Columns[i].ToString();
                    location = column_name.IndexOf("_");
                    strtmp = column_name.Substring(location + 1, 2);

                    if (strtmp == "ID" && column_name.Length <= 6)
                    {
                        strLeft = column_name.Substring(0, location);
                        field_Name = strLeft + "_" + "ID";
                        field_state = strLeft + "_" + "STATE";
                        if (dr[0][field_Name].ToString() != "")
                        {
                            DataRow newRow;
                            newRow = dt_toobar.NewRow();
                            newRow["id"] = dr[0][field_Name].ToString();
                            newRow["state"] = dr[0][field_state];
                            dt_toobar.Rows.Add(newRow);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 表單控件翻譯及工具欄按鈕權限
        /// </summary>
        /// <param name="objectname">控件集</param>
        /// <param name="cts">表單控件對象</param>
        public void setValue(Control.ControlCollection cts)
        {
            foreach (Control ct in cts)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip":
                        ToolStrip ts = (ToolStrip)ct;
                        string objName;
                        for (int i = 0; i < ts.Items.Count; i++)
                        {
                            objName = ts.Items[i].Name.ToUpper();
                            if (objName.Substring(0, 3) == "BTN")
                            {
                                objName = objName.Trim();
                                GetTitle(objName, ts.Items[i]); //取得工具欄按鈕翻譯

                                DataRow[] dr = dt_toobar.Select("id = '" + objName + "'");
                                if (dr.Length > 0)
                                {
                                    ts.Items[i].Enabled = (Boolean)dr[0][1]; //設置工具欄按鈕可否操作
                                }
                            }
                        }
                        break;
                    case "ComboBox": //下拉表框
                        ComboBox cb = (ComboBox)ct;
                        GetTitle(cb.Name.Trim(), cb);
                        break;
                    case "CheckBox": //復選框
                        CheckBox ck = (CheckBox)ct;
                        GetTitle(ck.Name.Trim(), ck);
                        break;
                    case "Label":  //文本標簽
                        Label lab = (Label)ct;
                        GetTitle(lab.Name.Trim(), lab);
                        break;
                    case "Button":  //Button按鈕
                        Button btn = (Button)ct;
                        GetTitle(btn.Name.Trim(), btn);

                        //表單BUTTON控件的權限
                        DataRow[] rw = dt_toobar.Select("id = '" + btn.Name.Trim() + "'");
                        if (rw.Length > 0)
                        {
                            ct.Enabled = (Boolean)rw[0][1]; //設置按鈕可否操作
                        }
                        //
                        break;
                    default:
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    setValue(ct.Controls);
                }
            }
        }


        /// <summary>
        /// 工具欄按鈕控件翻譯
        /// </summary>
        /// <param name="objectname">控件名稱</param>
        /// <param name="ctc">ToolStripButton控件對象</param>
        public void GetTitle(string objectname, ToolStripItem ctc)  //ToolStrip控件
        {
            DataRow[] dr = ds.Tables[0].Select("col_code='" + objectname + "'");
            if (dr.Length > 0)
            {
                ctc.Text = dr[0]["show_name"].ToString().Trim();
            }
        }
        /// <summary>
        /// 普通的控件的翻譯
        /// </summary>
        /// <param name="objectname">控件名稱</param>
        /// <param name="ctc">普通控件對象</param>
        public void GetTitle(string objectname, Control ctc)
        {
            DataRow[] dr = ds.Tables[0].Select("col_code='" + objectname + "'");
            if (dr.Length > 0)
            {
                ctc.Text = dr[0]["show_name"].ToString().Trim();
            }
        }


    }

}
