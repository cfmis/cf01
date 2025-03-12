using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace cf01.ModuleClass
{
    public class NextControl
    {
        private Form frm;
        private string obj_type="1";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm">此参數爲表單名</param>
        /// <param name="_objtype">此参數1爲VS本身的控件,2爲DEV第三方控件</param>

        public NextControl(Form frm,string _objtype)
        {
            this.frm = frm;
            obj_type = _objtype;
        }

        /// <summary>
        /// 窗体上所有子控件的回车设成Tab
        /// </summary>
        public void EnterToTab()
        {
            frm.KeyPreview = true;
            frm.KeyPress += new KeyPressEventHandler(frm_KeyPress);
        }
        /// <summary>
        /// 注册窗体的KeyPress事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //obj_type等于"1"時爲.NET本身控件，按回車後處理跳至下個控件
            //obj_type等于"2"時爲DEV控件,因DEV控件本身已有此功能，不必再進行此處理
            if (obj_type == "1")
            {
                //按回車跳到下一控件                
                if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                    //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
                }
            }           

            //輸入的值長度達到最大長度後焦點跳轉到下一控件            
            switch (frm.ActiveControl.GetType().Name)
            {
                case "TextBox":
                    TextBox ts0 = (TextBox)frm.ActiveControl;
                    if ((ts0.TextLength - ts0.SelectionLength) == ts0.MaxLength - 1)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case "TextBoxMaskBox":
                    TextBoxMaskBox ts1 = (TextBoxMaskBox)frm.ActiveControl;
                    if (ts1.TextLength == ts1.MaxLength - 1)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
