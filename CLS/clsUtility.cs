using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsUtility
    {
        /// <summary>
        /// 操作類型枚舉
        /// </summary>
        public enum enumOperationType
        {
            Add = 0,
            Update = 1,
            Find = 2,
            Delete = 3,
            Cancel = 4,
            Save = 5,
            FindBrand = 6,
            FindCustomer = 7,
            Load = 8,
            Print = 9,
            ExportToExcel = 10,
            PreView = 11
        }

        /// <summary>
        /// 通過遍歷獲取用戶的查詢條件
        /// </summary>
        /// <param name="cts"></param>
        /// <param name="lsQV"></param>
        public static void GetValue(Control.ControlCollection cts, List<mdlQueryValue> lsQV, string strFrmName)
        {
            foreach (Control ct in cts)
            {
                mdlQueryValue objQueryValue = new mdlQueryValue();
                objQueryValue.formname = strFrmName;
                objQueryValue.login_user = DBUtility._user_id;
                objQueryValue.amtim = DateTime.Now;
                objQueryValue.amusr = DBUtility._user_id;
                objQueryValue.crusr = DBUtility._user_id;
                objQueryValue.crtim = DateTime.Now;

                switch (ct.GetType().Name)
                {
                    case "TextBox":
                        {
                            System.Windows.Forms.TextBox txtObject = (System.Windows.Forms.TextBox)ct;
                            objQueryValue.obj_id = txtObject.Name;
                            objQueryValue.obj_value = txtObject.Text.Trim();
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "LookUpEdit":
                        {
                            DevExpress.XtraEditors.LookUpEdit txtObject = (DevExpress.XtraEditors.LookUpEdit)ct;
                            objQueryValue.obj_id = txtObject.Name;
                            objQueryValue.obj_value = txtObject.ItemIndex.ToString();
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "DateEdit":
                        {
                            DevExpress.XtraEditors.DateEdit txtObject = (DevExpress.XtraEditors.DateEdit)ct;
                            objQueryValue.obj_id = txtObject.Name;
                            objQueryValue.obj_value = txtObject.Text;
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "TextEdit":
                        {
                            DevExpress.XtraEditors.TextEdit txtObject = (DevExpress.XtraEditors.TextEdit)ct;
                            objQueryValue.obj_id = txtObject.Name;
                            objQueryValue.obj_value = txtObject.Text;
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "MaskedTextBox":
                        {
                            MaskedTextBox mtb = (MaskedTextBox)ct;
                            objQueryValue.obj_id = mtb.Name;
                            objQueryValue.obj_value = mtb.Text.Trim();
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "ComboBox":
                        {
                            ComboBox cbb = (ComboBox)ct;
                            objQueryValue.obj_id = cbb.Name;
                            objQueryValue.obj_value = cbb.SelectedIndex.ToString();
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "CheckBox":
                        {
                            System.Windows.Forms.CheckBox ckb = (System.Windows.Forms.CheckBox)ct;
                            objQueryValue.obj_id = ckb.Name;
                            objQueryValue.obj_value = ckb.Checked.ToString();
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "RadioButton":
                        {
                            RadioButton rdb = (RadioButton)ct;
                            objQueryValue.obj_id = rdb.Name;
                            objQueryValue.obj_value = rdb.Checked.ToString();
                            lsQV.Add(objQueryValue);
                        }
                        break;
                    case "RadioGroup":
                        {
                            DevExpress.XtraEditors.RadioGroup rdb = (DevExpress.XtraEditors.RadioGroup)ct;
                            objQueryValue.obj_id = rdb.Name;
                            objQueryValue.obj_value = rdb.SelectedIndex.ToString();
                            lsQV.Add(objQueryValue);
                            break;
                        }
                    default:
                        break;
                }

                if (ct.HasChildren)
                {
                    GetValue(ct.Controls, lsQV, strFrmName);
                }
            }
        }

        /// <summary>
        /// 根據不同操作控制按鈕的狀態是否可用
        /// </summary>
        /// <param name="toolstrip"></param>
        /// <param name="OperationType"></param>
        public static void EnableToolStripButton(ToolStrip toolstrip, enumOperationType OperationType)
        {
            foreach (var ct in toolstrip.Items)
            {
                if (ct.GetType() == typeof(ToolStripButton))
                {
                    ToolStripButton tsbtn = (ToolStripButton)ct;

                    switch (OperationType)
                    {
                        case enumOperationType.Add:
                            {
                                if (tsbtn.Name != "BTNCANCEL" && tsbtn.Name != "BTNSAVE" && tsbtn.Name != "BTNEXIT")
                                {
                                    tsbtn.Enabled = false;
                                }
                                else
                                {
                                    tsbtn.Enabled = true;
                                }
                            }
                            break;
                        case enumOperationType.Update:
                            {
                                if (tsbtn.Name != "BTNCANCEL" && tsbtn.Name != "BTNSAVE" && tsbtn.Name != "BTNEXIT")
                                {
                                    tsbtn.Enabled = false;
                                }
                                else
                                {
                                    tsbtn.Enabled = true;
                                }
                            }
                            break;
                        case enumOperationType.Cancel:
                            {
                                if (tsbtn.Name != "BTNCANCEL" && tsbtn.Name != "BTNSAVE")
                                {
                                    tsbtn.Enabled = true;
                                }
                                else
                                {
                                    tsbtn.Enabled = false;
                                }
                            }
                            break;
                        case enumOperationType.Save:
                            {
                                if (tsbtn.Name != "BTNSAVE" && tsbtn.Name != "BTNCANCEL")
                                {
                                    tsbtn.Enabled = true;
                                }
                                else
                                {
                                    tsbtn.Enabled = false;
                                }
                            }
                            break;
                        case enumOperationType.Load:
                            {
                                if (tsbtn.Name != "BTNSAVE" && tsbtn.Name != "BTNCANCEL")
                                {
                                    tsbtn.Enabled = true;
                                }
                                else
                                {
                                    tsbtn.Enabled = false;
                                }
                            }
                            break;
                        default:
                            break;
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

        public string TrimEndDecimal(decimal pValue)
        {
            return TrimEndDecimal(pValue.ToString());
        }

        public string TrimEndDecimal(string pValue)
        {
            if (pValue.IndexOf('.') > 0)
            {
                return pValue.TrimEnd('0').TrimEnd('.');
            }
            else
            {
                return pValue;
            }
        }

        public DateTime FormatDate1(string pDate)
        {
            DateTime dtmDate = Convert.ToDateTime(pDate);
            return dtmDate;
        }

        public string FormatDate(DateTime pDate)
        {
            string strReturn = "";
            strReturn = pDate.Year.ToString() + "-" +
                        pDate.Month.ToString().PadLeft(2, '0') + "-" +
                        pDate.Day.ToString().PadLeft(2, '0');
            return strReturn;
        }

        /// <summary>
        /// 計算時間段的時間差
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        private string DateCha(DateTime DateTime1, DateTime DateTime2)
        {
            string str = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            str = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return str;
        }

        /// <summary>
        /// 对于可能出现DBNull的字段转换成String时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static string FormatNullableString(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return "";
            }
            else
            {
                return pInput.ToString();
            }
        }

        /// <summary>
        /// 对于可能出现DBNull的字段转换成bool时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static bool FormatNullableBool(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(pInput);
            }
        }

        /// <summary>
        /// 对于可能出现DBNull的字段转换成Float时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static float FormatNullableFloat(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(pInput);
            }
        }

        /// <summary>
        /// 对于可能出现DBNull的字段转换成Int时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static Int32 FormatNullableInt32(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(pInput);
            }
        }


        /// <summary>
        /// 对于可能出现DBNull的字段转换成decimal时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static decimal FormatNullableDecimal(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(pInput);
            }
        }

        /// <summary>
        /// 对于可能出现DBNull的字段转换成double时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static Double FormatNullableDouble(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(pInput);
            }
        }


        /// <summary>
        /// 对于可能出现DBNull的字段转换成DateTime时调用。
        /// </summary>
        /// <param name="pInput"></param>
        /// <returns></returns>
        public static DateTime FormatNullableDateTime(object pInput)
        {
            if (pInput == DBNull.Value || pInput == null)
            {
                return Convert.ToDateTime("1900/01/01");
            }
            else
            {
                return Convert.ToDateTime(pInput);
            }
        }

        /// <summary>
        /// 將數字轉換成千分位
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static string NumberConvert(object objValue)
        {
            string strResult = Convert.ToInt32(objValue).ToString();
            if (strResult.Length > 3)
            {
                return strResult = Convert.ToInt32(objValue).ToString("0,000");
            }
            else
            {
                return strResult;
            }
        }


        /// <summary>
        /// 此方法用于确认用户输入的不是恶意信息
        /// </summary>
        /// <param name="pText">用户输入信息</param>
        /// <param name="pMaxLength">输入的最大长度</param>
        /// <returns>处理后的输入信息</returns>
        public string InputText(string pText, int pMaxLength)
        {
            pText = pText.Trim();
            if (string.IsNullOrEmpty(pText))
            {
                return string.Empty;
            }
            if (pText.Length > pMaxLength)
            {
                pText = pText.Substring(0, pMaxLength);
            }
            // 2个或以上的空格
            pText = Regex.Replace(pText, "[\\s]{2,}", " ");
            //pText = Regex.Replace(pText, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br> html换行符
            //pText = Regex.Replace(pText, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;   html空格符
            //pText = Regex.Replace(pText, "<(.|\\n)*?>", string.Empty);	// 任何其他的标签
            //pText = pText.Replace("'", "''");// 单引号
            return pText;
        }

        public string OutputText(object pValue, string pOriginalValue)
        {
            if (pValue == DBNull.Value)
            {
                return pOriginalValue;
            }
            else
            {
                return pValue.ToString().Trim();
            }
        }

        public int OutputText(object pValue, int OriginalValue)
        {
            if (pValue == DBNull.Value)
            {
                return OriginalValue;
            }
            else
            {
                return Convert.ToInt32(pValue);
            }
        }

        public decimal OutputText(object pValue, decimal OriginalValue)
        {
            if (pValue == DBNull.Value)
            {
                return OriginalValue;
            }
            else
            {
                return Convert.ToDecimal(pValue);
            }
        }

        public DateTime OutputText(object pValue, DateTime OriginalValue)
        {
            if (pValue == DBNull.Value)
            {
                return OriginalValue;
            }
            else
            {
                return Convert.ToDateTime(pValue);
            }
        }

        public bool OutputText(object pValue, bool OriginalValue)
        {
            if (pValue == DBNull.Value)
            {
                return OriginalValue;
            }
            else
            {
                return Convert.ToBoolean(pValue);
            }
        }

        /// <summary>
        /// 将文件流转为Base64字符串，以便保存至数据库中
        /// </summary>
        /// <param name="pFilePath"></param>
        /// <returns></returns>
        //public static Common.mdlResultBase ConvertFileStreamToBase64String(Stream pFileStream)
        //{
        //    Common.mdlResultBase objResult = new Common.mdlResultBase();
        //    byte[] aryData;
        //    try
        //    {
        //        aryData = new Byte[pFileStream.Length];
        //        long intReadCount = pFileStream.Read(aryData, 0, (int)pFileStream.Length);
        //        string strFileContentBase64;
        //        strFileContentBase64 = System.Convert.ToBase64String(aryData, 0, aryData.Length);
        //        objResult.Result = true;
        //        objResult.Message = strFileContentBase64;
        //    }
        //    catch (Exception ex)
        //    {
        //        objResult.Result = false;
        //        objResult.Message = ex.Message;
        //    }
        //    return objResult;
        //}

        
        //**2018-12-05
        /// <summary>
        /// MessageBox 提示窗體1秒后自動關閉
        /// </summary>
        /// <param name="msgInfo"> 提示信息</param>
        /// <param name="msgTitle">提示Title</param>        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int MessageBoxTimeout(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);
        public static void myMessageBox(string msgInfo,string msgTitle)
        {
           MessageBoxTimeout((IntPtr)0, msgInfo, msgTitle, 0, 0, 1000); //提示窗體1秒后自動關閉   
        }

        /// <summary>
        /// 取服務器日期
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDateTime()
        {            
            string str_datetime = clsPublicOfCF01.ExecuteSqlReturnObject("Select convert(varchar(20),getdate(),120)");            
            return str_datetime;
        }

        public static void setDataGridViewSeq(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

    }
}
