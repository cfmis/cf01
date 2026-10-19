using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.CLS
{
    /// <summary>
    /// 全局扫码枪过滤器（支持指定窗体接收）
    /// 已修复：第一个字符丢失、不影响普通输入框
    /// </summary>
    public static class clsGlobalScanner
    {
        private static ScannerMessageFilter filter;
        private static bool isInstalled = false;

        /// <summary>
        /// 当前允许接收扫码的窗体
        /// </summary>
        public static Form ActiveForm { get; private set; }

        /// <summary>
        /// 扫码成功事件
        /// </summary>
        public static event Action<string> BarcodeScanned;

        /// <summary>
        /// 安装全局过滤器（在 Program.cs 调用一次）
        /// </summary>
        public static void Install()
        {
            if (isInstalled) return;

            filter = new ScannerMessageFilter();
            Application.AddMessageFilter(filter);
            isInstalled = true;
        }

        /// <summary>
        /// 卸载过滤器
        /// </summary>
        public static void Uninstall()
        {
            if (!isInstalled) return;

            Application.RemoveMessageFilter(filter);
            filter = null;
            isInstalled = false;
            ActiveForm = null;
        }

        /// <summary>
        /// 设置当前允许接收扫码的窗体
        /// </summary>
        public static void SetActiveForm(Form form)
        {
            ActiveForm = form;
        }

        /// <summary>
        /// 清除当前接收窗体
        /// </summary>
        public static void ClearActiveForm()
        {
            ActiveForm = null;
        }

        /// <summary>
        /// 内部触发事件
        /// </summary>
        internal static void RaiseBarcodeScanned(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return;
            if (ActiveForm == null) return;

            if (ActiveForm.InvokeRequired)
            {
                ActiveForm.BeginInvoke(new Action(() =>
                {
                    BarcodeScanned?.Invoke(barcode);
                }));
            }
            else
            {
                BarcodeScanned?.Invoke(barcode);
            }
        }

        #region 消息过滤器

        private class ScannerMessageFilter : IMessageFilter
        {
            private readonly StringBuilder buffer = new StringBuilder();
            private DateTime lastTime = DateTime.MinValue;

            private const int WM_CHAR = 0x0102;

            // 阈值可根据实际扫描枪调整
            private const int ClearInterval = 120;   // 超过这个时间认为是新的一次输入
            private const int ScannerInterval = 90;  // 小于这个时间认为是扫描枪

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg != WM_CHAR) return false;

                char keyChar = (char)m.WParam;
                DateTime now = DateTime.Now;

                // ========== 回车：扫描结束 ==========
                if (keyChar == '\r' || keyChar == '\n')
                {
                    if (buffer.Length >= 3)   // 太短的忽略，防止误触
                    {
                        string barcode = buffer.ToString().Trim();
                        buffer.Clear();
                        clsGlobalScanner.RaiseBarcodeScanned(barcode);
                    }
                    else
                    {
                        buffer.Clear();
                    }
                    return true; // 拦截回车
                }

                // ========== 普通字符 ==========
                double interval = (now - lastTime).TotalMilliseconds;
                lastTime = now;

                // 间隔太大，清空缓冲，开始新的一次输入
                if (interval > ClearInterval)
                {
                    buffer.Clear();
                }

                // 先把字符加入缓冲（保证第一个字符不丢）
                if (!char.IsControl(keyChar))
                {
                    buffer.Append(keyChar);
                }

                // 只有当已经有内容，并且按键很快时，才拦截（扫描枪）
                if (buffer.Length >= 1 && interval < ScannerInterval)
                {
                    return true;   // 拦截扫描枪输入的字符，不显示到输入框
                }

                // 手动输入 或 第一个字符：不拦截
                return false;
            }
        }

        #endregion
    }
}
