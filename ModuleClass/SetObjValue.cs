using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace cf01.ModuleClass
{
    public class SetObjValue
    {
        public SetObjValue()
        {
        }

        /// <summary>
        /// 新增時清除  1.清空全部;2.清空主檔
        /// </summary>
        /// <param name="cts"></param>
        /// <param name="_type"></param>
        public static void ClearObjValue(Control.ControlCollection cts, string _type)
        {
            //try
            //{                
            //新增時清除  2.清空全部;1.清空主檔
            foreach (Control ct in cts)
            {
                if (ct.Tag == null)
                {
                    ct.Tag = "";
                }
                switch (ct.GetType().Name)
                {
                    case "TextBox":
                        TextBox ts0 = (TextBox)ct;
                        if (ts0.Tag.ToString() == "N")
                        {
                            ts0.Text = "0"; //數值的預設爲0,不然插入數據庫出會出錯
                        }
                        else
                        {
                            ts0.Text = "";
                        }
                        break;
                    case "TextEdit":
                        TextEdit ts1 = (TextEdit)ct;
                        if (ts1.Tag.ToString() == "N")
                        {
                            ts1.Text = "0"; //數值的預設爲0,不然插入數據庫出會出錯
                        }
                        else
                        {
                            ts1.Text = "";
                        }
                        break;
                    case "CheckEdit":
                        CheckEdit ts2 = (CheckEdit)ct;
                        ts2.Checked = false;
                        break;
                    case "DataGridView":
                        if (_type == "2") //2.清空全部;1.清空主檔
                        {
                            DataGridView ts3 = (DataGridView)ct;
                            ts3.DataSource = null;
                        }
                        break;
                    case "GridControl":
                        if (_type == "2") //2.清空全部;1.清空主檔
                        {
                            GridControl ts4 = (GridControl)ct;
                            ts4.DataSource = null;
                        }
                        break;
                    case "MemoEdit":
                        MemoEdit ts5 = (MemoEdit)ct;
                        ts5.Text = "";
                        break;
                    case "LookUpEdit":
                        LookUpEdit ts6 = (LookUpEdit)ct;
                        ts6.EditValue = "";
                        break;
                    case "DateEdit":
                        DateEdit ts7 = (DateEdit)ct;
                        ts7.EditValue = "";
                        break;
                    case "PictureBox":
                        PictureBox ts8 = (PictureBox)ct;
                        ts8.Image = null;
                        break;
                    case "ButtonEdit":
                        ButtonEdit ts9 = (ButtonEdit)ct;
                        ts9.Text = "";
                        break;
                    case "RichTextBox":
                        RichTextBox ts10 = (RichTextBox)ct;
                        ts10.Text = "";
                        break;                    
                    case "MaskedTextBox":
                        MaskedTextBox ts11 = (MaskedTextBox)ct;
                        ts11.Text = "";
                        break;
                    case "ComboBox":
                        System.Windows.Forms.ComboBox ts12 = (System.Windows.Forms.ComboBox)ct;
                        ts12.Text = "";
                        break;
                    case "ComboBoxEdit":
                        ComboBoxEdit ts13 = (ComboBoxEdit)ct;
                        ts13.Text = "";
                        break;
                    case "SearchLookUpEdit":
                        SearchLookUpEdit ts14 = (SearchLookUpEdit)ct;
                        ts14.Text = "";
                        break;
                    default:
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    ClearObjValue(ct.Controls, _type);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        /// <summary>
        /// SetEditBackColor 編輯時設置編輯對象背景色
        /// </summary>
        /// <param name="cts"></param>
        /// <param name="_flag"></param>
        public static void SetEditBackColor(Control.ControlCollection cts, bool _flag)
        {
            foreach (Control ct in cts)
            {
                if (ct.Tag == null)
                {
                    ct.Tag = "";
                }
                switch (ct.GetType().Name)
                {
                    case "TextBox":
                        TextBox ts0 = (TextBox)ct;
                        if (_flag)
                        {
                            ts0.BackColor = System.Drawing.Color.LemonChiffon;
                            if (ts0.Tag.ToString() == "2") //非主鍵設爲可編輯狀態
                            {
                                ts0.ReadOnly = false;
                            }
                            if (ts0.Enabled == false) //設置建檔人，修改人文本框的背景顏色
                            {
                                ts0.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            ts0.BackColor = System.Drawing.Color.White;//.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                            if (ts0.Tag.ToString() == "2") //非主鍵設爲不可編輯狀態
                            {
                                ts0.ReadOnly = true;
                            }
                            if (ts0.Tag.ToString() == "1") //主鍵設爲可編輯狀態
                            {
                                ts0.ReadOnly = false;
                            }
                        }
                        break;
                    case "TextEdit":
                        TextEdit ts1 = (TextEdit)ct;
                        if (_flag)
                        {
                            ts1.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            if (ts1.Tag.ToString() == "2") //非主鍵設爲可編輯狀態
                            {
                                ts1.Properties.ReadOnly = false;
                            }
                            if (ts1.Enabled == false) //設置建檔人，修改人文本框的背景顏色
                            {
                                ts1.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            ts1.Properties.Appearance.BackColor = System.Drawing.Color.White;//.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                            if (ts1.Tag.ToString() == "2") //非主鍵設爲不可編輯狀態
                            {
                                ts1.Properties.ReadOnly = true;
                            }
                            if (ts1.Tag.ToString() == "1") //主鍵設爲可編輯狀態
                            {
                                ts1.Properties.ReadOnly = false;
                            }
                        }
                        break;
                    case "ButtonEdit":
                        ButtonEdit ts7 = (ButtonEdit)ct;
                        if (_flag)
                        {
                            ts7.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            if (ts7.Tag.ToString() == "2") //非主鍵設爲可編輯狀態
                            {
                                ts7.Properties.ReadOnly = false;
                            }
                            if (ts7.Enabled == false) //設置建檔人，修改人文本框的背景顏色
                            {
                                ts7.BackColor = System.Drawing.Color.White;
                            }
                        }
                        else
                        {
                            ts7.Properties.Appearance.BackColor = System.Drawing.Color.White;//.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                            if (ts7.Tag.ToString() == "2") //非主鍵設爲不可編輯狀態
                            {
                                ts7.Properties.ReadOnly = true;
                            }
                            if (ts7.Tag.ToString() == "1") //主鍵設爲可編輯狀態
                            {
                                ts7.Properties.ReadOnly = false;
                            }
                        }
                        break;
                    case "CheckEdit":
                        CheckEdit ts2 = (CheckEdit)ct;
                        if (_flag)
                        {
                            ts2.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            ts2.Enabled = true;
                        }
                        else
                        {
                            ts2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
                            ts2.Enabled = false;
                        }
                        break;
                    case "MemoEdit":
                        MemoEdit ts3 = (MemoEdit)ct;
                        if (_flag)
                        {
                            ts3.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            ts3.Properties.ReadOnly = false;
                        }
                        else
                        {
                            ts3.Properties.Appearance.BackColor = System.Drawing.Color.White;
                            ts3.Properties.ReadOnly = true;
                        }
                        break;
                    case "LookUpEdit":
                        LookUpEdit ts4 = (LookUpEdit)ct;
                        if (_flag)
                        {
                            ts4.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            ts4.Enabled = true;
                        }
                        else
                        {
                            ts4.Properties.Appearance.BackColor = System.Drawing.Color.White;
                            ts4.Enabled = false;
                        }
                        break;
                    case "DateEdit":
                        DateEdit ts5 = (DateEdit)ct;
                        if (_flag)
                        {
                            ts5.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            ts5.Enabled = true;
                        }
                        else
                        {
                            ts5.Properties.Appearance.BackColor = System.Drawing.Color.White;
                            ts5.Enabled = false;
                        }
                        break;
                    case "RichTextBox":
                        RichTextBox ts6 = (RichTextBox)ct;
                        if (_flag)
                        {
                            ts6.BackColor = System.Drawing.Color.LemonChiffon;
                            ts6.ReadOnly = false;
                        }
                        else
                        {
                            ts6.BackColor = System.Drawing.Color.White;
                            ts6.ReadOnly = true;
                        }
                        break;
                    case "MaskedTextBox":
                        MaskedTextBox ts8 = (MaskedTextBox)ct;
                        if (_flag)
                        {
                            ts8.BackColor = System.Drawing.Color.LemonChiffon;
                            ts8.ReadOnly = false;
                        }
                        else
                        {
                            ts8.BackColor = System.Drawing.Color.White;
                            ts8.ReadOnly = true;
                        }
                        break;
                    case "ComboBox":
                        System.Windows.Forms.ComboBox ts9 = (System.Windows.Forms.ComboBox)ct;
                        if (_flag)
                        {
                            ts9.BackColor = System.Drawing.Color.LemonChiffon;
                            ts9.Enabled = true ;
                        }
                        else
                        {
                            ts9.BackColor = System.Drawing.Color.White;
                            ts9.Enabled = false ;
                        }
                        break;
                    case "ComboBoxEdit":
                        ComboBoxEdit ts10 = (ComboBoxEdit)ct;
                        if (_flag)
                        {                            
                            ts10.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            ts10.Enabled = true;
                        }
                        else
                        {
                            ts10.Properties.Appearance.BackColor = System.Drawing.Color.White;                            
                            ts10.Enabled = false;
                        }
                        break;
                    case "SearchLookUpEdit":
                        SearchLookUpEdit ts11 = (SearchLookUpEdit)ct;
                        if (_flag)
                        {
                            ts11.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                            ts11.Enabled = true;
                        }
                        else
                        {
                            ts11.Properties.Appearance.BackColor = System.Drawing.Color.White;
                            ts11.Enabled = false;
                        }
                        break;

                    default:
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    SetEditBackColor(ct.Controls, _flag);
                }
            }
        }
    }
}
