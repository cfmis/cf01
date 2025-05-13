using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Xml;
using System.Threading;
using System.Security.Cryptography;
using cf01.ModuleClass;
using System.IO;


namespace cf01.CLS
{
    public class clsPublic
    {
        public string _strFrmName;
        public Control.ControlCollection _controlCollectin;

        DataTable dtToolStripBtnName = new DataTable();
        DataTable dtToolStripBtnRole = new DataTable();
        DataTable dtControlName = new DataTable();
        private static clsPublicOfGEO clsErp = new clsPublicOfGEO();
        
        public clsPublic(string frmName, Control.ControlCollection controlCollection)
        {
            _strFrmName = frmName;
            _controlCollectin = controlCollection;
        }
      

        /// <summary>
        ///獲取所有Control 的數據 
        /// </summary>
        public void GenerateData()
        {
            try
            {
                dtToolStripBtnName = clsRoleManage.GetToolStripButtonName(DBUtility._language, _strFrmName);
                DataTable dtUserPopedom = clsRoleManage.GetAllUserPopedom(DBUtility._user_id, _strFrmName);
                dtControlName = clsRoleManage.GetFrmControlName(DBUtility._language, _strFrmName);
                GetToolbarGrant(dtUserPopedom);
                if (dtToolStripBtnName.Rows.Count > 0 || dtToolStripBtnRole.Rows.Count > 0 || dtControlName.Rows.Count > 0)
                {
                    setValue(_controlCollectin);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        /// <summary>
        /// 表單控件翻譯及工具欄按鈕權限
        /// </summary>
        /// <param name="objectname">控件集</param>
        /// <param name="cts">表單控件對象</param>
        private void setValue(Control.ControlCollection cts)
        {
            foreach (Control ct in cts)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip":
                        {
                            ToolStrip ts = (ToolStrip)ct;
                            for (int i = 0; i < dtToolStripBtnName.Rows.Count; i++)
                            {
                                ToolStripButton tsBtn = new ToolStripButton();
                                string strImgPath = AppDomain.CurrentDomain.BaseDirectory + dtToolStripBtnName.Rows[i]["img_path"];
                                if (File.Exists(strImgPath))
                                {
                                    tsBtn.Image = Bitmap.FromFile(strImgPath);   //設置ToolStripButton 的Image
                                }
                                tsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                                tsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                tsBtn.Name = dtToolStripBtnName.Rows[i]["col_code"].ToString();
                                tsBtn.Text = dtToolStripBtnName.Rows[i]["show_name"].ToString();
                                tsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                                //設置工具欄按鈕可否操作
                                string strTsName = dtToolStripBtnName.Rows[i]["col_code"].ToString();
                                DataRow[] dr = dtToolStripBtnRole.Select("id = '" + strTsName + "'");
                                if (dr.Length > 0)
                                {
                                    tsBtn.Enabled = (Boolean)dr[0][1];
                                }

                                ts.Items.Add(tsBtn);
                            }
                        }
                        break;
                    case "ComboBox": //下拉表框
                        {
                            ComboBox cb = (ComboBox)ct;
                            //GetTitle(cb.Name.Trim(), cb);
                        }
                        break;
                    case "CheckBox": //復選框
                        {
                            CheckBox ck = (CheckBox)ct;
                        }
                        break;
                    case "Label":  //文本標簽
                        {
                            Label lab = (Label)ct;
                            string strName = _strFrmName + "_label";
                            for (int i = 0; i < dtControlName.Rows.Count; i++)
                            {
                                if (dtControlName.Rows[i]["formname"].ToString() == strName)
                                {
                                    if (lab.Name == dtControlName.Rows[i]["col_code"].ToString())
                                    {
                                        lab.Text = dtControlName.Rows[i]["show_name"].ToString();
                                    }
                                }
                            }
                        }
                        break;
                    case "Button":  //Button按鈕
                        {
                            Button btn = (Button)ct;
                        }
                        break;
                    case "DataGridView": //DataGridView列表
                        {
                            DataGridView dgv = (DataGridView)ct;
                            string strName = dgv.Name;
                            dgv.AutoGenerateColumns = false;
                            dgv.AllowUserToAddRows = false;
                            dgv.RowHeadersVisible = false;
                            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                            for (int i = 0; i < dtControlName.Rows.Count; i++)
                            {
                                int intIndex = dtControlName.Rows[i]["formname"].ToString().Trim().IndexOf('_');
                                int intLength = dtControlName.Rows[i]["formname"].ToString().Trim().Length;
                                if (dtControlName.Rows[i]["formname"].ToString().Trim().Substring(intIndex + 1, intLength - (intIndex + 1)) == strName)
                                {
                                    switch (dtControlName.Rows[i]["columntype"].ToString().Trim())
                                    {
                                        case "DataGridViewTextBoxColumn":
                                            {
                                                dgv.Columns.Add(dtControlName.Rows[i]["col_code"].ToString().Trim(), dtControlName.Rows[i]["show_name"].ToString().Trim());
                                                dgv.Columns[dtControlName.Rows[i]["col_code"].ToString().Trim()].DataPropertyName = dtControlName.Rows[i]["source_field"].ToString().Trim();
                                                dgv.Columns[dtControlName.Rows[i]["col_code"].ToString().Trim()].Width = Convert.ToInt32(dtControlName.Rows[i]["tb_col_width"]);
                                                if (dtControlName.Rows[i]["fl_visible"].ToString().Trim() == "Y")
                                                {
                                                    dgv.Columns[dtControlName.Rows[i]["col_code"].ToString().Trim()].Visible = true;
                                                }
                                                else
                                                {
                                                    dgv.Columns[dtControlName.Rows[i]["col_code"].ToString().Trim()].Visible = false;
                                                }
                                            }
                                            break;
                                        case "DataGridViewMaskedTextBoxColumn":
                                            {
                                                DataGridViewMaskedTextBoxColumn dgvMtxt = new DataGridViewMaskedTextBoxColumn();
                                                dgvMtxt.Name = dtControlName.Rows[i]["col_code"].ToString();
                                                dgvMtxt.HeaderText = dtControlName.Rows[i]["show_name"].ToString();
                                                if (dtControlName.Rows[i]["col_code"].ToString() == "valid_date")
                                                {
                                                    dgvMtxt.Mask = "0000/00/00";
                                                }
                                                dgv.Columns.Add(dgvMtxt);
                                            }
                                            break;
                                        case "DataGridViewComboBoxColumn":
                                            {
                                                DataGridViewComboBoxColumn dgvCmbox = new DataGridViewComboBoxColumn();
                                                dgvCmbox.Name = dtControlName.Rows[i]["col_code"].ToString();
                                                dgvCmbox.HeaderText = dtControlName.Rows[i]["show_name"].ToString();
                                                dgvCmbox.Items.Clear();
                                                if (dtControlName.Rows[i]["col_code"].ToString() == "goods_unit")
                                                {
                                                    GenerateGoodsUnit(dgvCmbox, null);
                                                }

                                                if (dtControlName.Rows[i]["col_code"].ToString() == "m_id")
                                                {
                                                    GenerateCurrency(dgvCmbox, null);
                                                }

                                                dgvCmbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                                                dgvCmbox.DisplayStyleForCurrentCellOnly = true;
                                                dgv.Columns.Add(dgvCmbox);
                                            }
                                            break;
                                        case "DataGridViewCheckBoxColumn":
                                            break;
                                        case "DataGridViewButtonColumn":
                                            break;
                                        case "DataGridViewLinkColumn":
                                            break;
                                        case "DataGridViewImageColumn":
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
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

        //生成數量單位Table
        public static void GenerateGoodsUnit(DataGridViewComboBoxColumn dgvcmbox, ComboBox cmbox)
        {
            DataTable dtGoodsUnit = new DataTable();
            dtGoodsUnit.Columns.Add(new DataColumn("Id", typeof(int)));
            dtGoodsUnit.Columns.Add(new DataColumn("Goods_Unit", typeof(string)));
            DataRow dr = null;
            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 0;
            dr["Goods_Unit"] = "PCS";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 1;
            dr["Goods_Unit"] = "KG";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 2;
            dr["Goods_Unit"] = "GRS";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 3;
            dr["Goods_Unit"] = "SET";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 4;
            dr["Goods_Unit"] = "G";
            dtGoodsUnit.Rows.Add(dr);

            //return dtGoodsUnit;
            if (dgvcmbox == null)
            {
                cmbox.DataSource = dtGoodsUnit;
                cmbox.DisplayMember = "Goods_Unit";
                cmbox.ValueMember = "Id";
            }
            else
            {
                dgvcmbox.DataSource = dtGoodsUnit;
                dgvcmbox.DisplayMember = "Goods_Unit";
                dgvcmbox.ValueMember = "Id";
            }
        }

        //生成貨幣Table
        public static void GenerateCurrency(DataGridViewComboBoxColumn dgvcmbox, ComboBox cmbox)
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add(new DataColumn("Id", typeof(int)));
            dtCurrency.Columns.Add(new DataColumn("Currency", typeof(string)));
            DataRow dr = null;

            dr = dtCurrency.NewRow();
            dr["Id"] = 0;
            dr["Currency"] = "USD";
            dtCurrency.Rows.Add(dr);

            dr = dtCurrency.NewRow();
            dr["Id"] = 1;
            dr["Currency"] = "HKD";
            dtCurrency.Rows.Add(dr);

            dr = dtCurrency.NewRow();
            dr["Id"] = 2;
            dr["Currency"] = "RMB";
            dtCurrency.Rows.Add(dr);

            if (dgvcmbox == null)
            {
                cmbox.DataSource = dtCurrency;
                cmbox.DisplayMember = "Currency";
                cmbox.ValueMember = "Id";
            }
            else
            {
                dgvcmbox.DataSource = dtCurrency;
                dgvcmbox.DisplayMember = "Currency";
                dgvcmbox.ValueMember = "Id";
            }

        }


        /// <summary>
        /// 取得工具欄按鈕權限臨時表
        /// </summary>
        private void GetToolbarGrant(DataTable dt)
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
                dc = dtToolStripBtnRole.Columns.Add("id", Type.GetType("System.String"));
                dc = dtToolStripBtnRole.Columns.Add("state", Type.GetType("System.Boolean"));


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
                            newRow = dtToolStripBtnRole.NewRow();
                            newRow["id"] = dr[0][field_Name].ToString();
                            newRow["state"] = dr[0][field_state];
                            dtToolStripBtnRole.Rows.Add(newRow);
                        }
                    }
                }
            }
        }

        public static bool CheckDate(string strDate)
        {
            if (strDate.Replace(" ", "").Length == 15 || strDate.Replace(" ", "").Length == 10)
            {
                //int intIndex = strDate.Replace(" ", "").IndexOf("/");

                if (strDate.Substring(0, 4).Length > 4 || strDate.Substring(0, 4).Length < 4)
                {
                    return false;
                }

                if (Convert.ToInt32(strDate.Substring(5, 2)) > 12 || Convert.ToInt32(strDate.Substring(5, 2)) == 00)
                {
                    MessageBox.Show("月份應該在1~12之間,請輸入正確的月份。");
                    return false;
                }

                switch (strDate.Substring(5, 2))
                {
                    case "01":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("1月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "02":
                        int intYear = Convert.ToInt32(strDate.Substring(0, 4));
                        if ((intYear % 4 == 0 && intYear % 100 != 0) || intYear % 400 == 0)
                        {
                            if (Convert.ToInt32(strDate.Substring(8, 2)) > 29 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                            {
                                MessageBox.Show("2月份為29天，請輸入正確的天數。");
                                return false;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(strDate.Substring(8, 2)) > 28 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                            {
                                MessageBox.Show("2月份為28天，請輸入正確的天數。");
                                return false;
                            }
                        }
                        break;
                    case "03":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("3月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "04":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 30 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("4月份為30天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "05":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("5月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "06":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 30 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("6月份為30天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "07":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("7月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "08":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("8月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "09":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 30 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("9月份為30天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "10":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("10月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "11":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 30 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("11月份為30天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    case "12":
                        if (Convert.ToInt32(strDate.Substring(8, 2)) > 31 || Convert.ToInt32(strDate.Substring(8, 2)) == 00)
                        {
                            MessageBox.Show("12月份為31天，請輸入正確的天數。");
                            return false;
                        }
                        break;
                    default:
                        break;
                }

                if (strDate.Replace(" ", "").Length == 15)
                {
                    if (Convert.ToInt32(strDate.Substring(11, 2)) > 24 || Convert.ToInt32(strDate.Substring(11, 2)) == 00)
                    {
                        MessageBox.Show("請輸入正確的小時數。");
                        return false;
                    }

                    if (Convert.ToInt32(strDate.Substring(14, 2)) > 59)
                    {
                        MessageBox.Show("請輸入正確的分鐘數。");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("請輸入正確的日期格式 ：'yyyy/MM/dd HH:mm'。");
                return false;
            }
            return true;
        }

        //將EXCEL的記錄導入到table中
        public static DataTable ImputExcelToTable(string filepath)
        {
            DataTable ttb = null;
            if (filepath == "")
            {
                filepath = OpenFile();
            }
            if (filepath == "")
                return null;

            string[] sheets;
            string sheet;
            sheets = GetExcelSheetNames(filepath);
            if (sheets == null)
                return null;
            sheet = sheets[0].Trim();

            string type = filepath.Substring(filepath.LastIndexOf(".") + 1);
            string connStr;
            if (type.Equals("xls", StringComparison.CurrentCultureIgnoreCase))
            {
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + filepath + ";Extended Properties=Excel 8.0";
            }
            else
            {
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                    + filepath +
                    ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
            }
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();


            //string sql = "select * from [Sheet1$]";
            string sql = "select * from " + "[" + sheet + "$]";
            IDataAdapter dadp = new OleDbDataAdapter(sql, conn);
            try
            {

                DataSet ds = new DataSet();
                dadp.Fill(ds);
                ttb = ds.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //return null;
            }
            finally
            {
                // 清理    
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
                if (dadp != null)
                {
                    //dadp.Dispose();
                }
            }   


            return ttb;
        }

        //打開Excel文件
        private static string OpenFile()
        {
            string filepath = "";
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.et;*.xls;*.xlsx)|*.et;*.xls;*.xlsx|all|*.*"; //删选、设定文件显示类型
            open.ShowDialog(); //显示打开文件的窗口
            filepath = open.FileName;
            return filepath;
        }

        //獲取Excel中的工作表名稱
        private static String[] GetExcelSheetNames(string fileName)
        {
            OleDbConnection objConn = null;
            DataTable dt = null;
            try
            {
                string connString = string.Empty;
                string FileType = fileName.Substring(fileName.LastIndexOf("."));
                if (FileType == ".xls")
                    //connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    //   "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + fileName + ";Extended Properties=Excel 8.0";
                else//.xlsx   
                    //    connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";
                    //Extended Properties="Excel 12.0;HDR=YES;IMEX=1"";     
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                            + fileName +
                            ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
                // 创建连接对象    
                objConn = new OleDbConnection(connString);
                // 打开数据库连接    
                objConn.Open();
                // 得到包含数据架构的数据表    
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                // 添加工作表名称到字符串数组    
                foreach (DataRow row in dt.Rows)
                {
                    string strSheetTableName = row["TABLE_NAME"].ToString();
                    //过滤无效SheetName   
                    if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                    {
                        excelSheets[i] = strSheetTableName.Substring(0, strSheetTableName.Length - 1);
                    }
                    i++;
                }
                return excelSheets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                // 清理    
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        //檢查單據號是否已存在
        public static bool CheckIdIsExists(string tableName, string id)
        {
            bool result = false;
            string strSql = string.Format(@"Select id FROM {0} with(nolock) Where within_code='0000' AND id='{1}'", tableName, id);
            DataTable dt = clsErp.ExecuteSqlReturnDataTable(strSql);
            if (dt.Rows.Count > 0)
                result = true;
            else
                result = false;
            return result;
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

        public static string GetSequenceID(int index)
        {
            //返回序號
            string result = "";
            if (index > 0)
                result = index.ToString().PadLeft(4, '0') + "h";
            else
            {
                result = "0001h";
            }
            return result;
        }

        public static string GetDbDateTime(string type)
        {
            string strSql = "";
            if (type == "S")
            {
                strSql = "SELECT CONVERT(varchar(10),GETDATE(),120) as dbdate";
            }
            else
            {
                strSql = "SELECT CONVERT(varchar(19),GETDATE(),120) as dbdate";
            }
            DataTable dt = clsErp.ExecuteSqlReturnDataTable(strSql);
            string result = dt.Rows[0]["dbdate"].ToString();
            return result;
        }

        public static decimal ReturnFloat2(string pValue)
        {
            float fResult;
            fResult = (!string.IsNullOrEmpty(pValue)) ? float.Parse(pValue) : 0.00f;
            fResult = (fResult > 0) ? (float)Math.Round(fResult, 2) : 0.00f;
            return decimal.Parse(fResult.ToString());
        }

        public static decimal ReturnFloat4(string pValue)
        {
            float fResult;
            fResult = (!string.IsNullOrEmpty(pValue)) ? float.Parse(pValue) : 0.0000f;
            fResult = (fResult > 0) ? (float)Math.Round(fResult, 4) : 0.0000f;
            return decimal.Parse(fResult.ToString());
        }

        //create a reportview report and define format,grouping  ://msdn.microsoft.com/zh-cn/library/ms252073(v=vs.90).aspx

        //make report define grouping   ://www.dotblogs.com.tw/bruce655/archive/2012/02/22/69837.aspx
    }
}
