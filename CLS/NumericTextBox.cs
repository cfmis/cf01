using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class NumericTextBox : TextBox
{
    public bool AllowNegative { get; set; } = false;
    public bool AllowDecimal { get; set; } = true;

    /// <summary>
    /// 是否启用默认“回车跳下一个”行为
    /// </summary>
    public bool EnableEnterAsTab { get; set; } = true;

    /// <summary>
    /// 当按下回车时触发的自定义事件（可选）
    /// </summary>
    public event EventHandler EnterKeyPressed;

    private string GetPattern()
    {
        if (AllowNegative && AllowDecimal)
            return @"^-?(0|[1-9]\d*)(\.\d*)?$";   // 允许 0 或非零开头，支持小数
        else if (AllowNegative && !AllowDecimal)
            return @"^-?(0|[1-9]\d*)$";           // 允许 0 或非零开头，不支持小数
        else if (!AllowNegative && AllowDecimal)
            return @"^(0|[1-9]\d*)(\.\d*)?$";     // 正数，允许小数
        else
            return @"^(0|[1-9]\d*)$";             // 正整数
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);

        if (!string.IsNullOrEmpty(this.Text))
        {
            string pattern = GetPattern();

            if (!Regex.IsMatch(this.Text, pattern))
            {
                string filtered = Regex.Replace(this.Text, @"[^0-9.-]", "");

                // 保证只允许一个小数点
                if (AllowDecimal)
                {
                    int firstDot = filtered.IndexOf('.');
                    if (firstDot >= 0)
                    {
                        int secondDot = filtered.IndexOf('.', firstDot + 1);
                        if (secondDot > 0)
                            filtered = filtered.Remove(secondDot, 1);
                    }
                }
                else
                {
                    filtered = filtered.Replace(".", "");
                }

                // 保证负号只允许在开头
                if (AllowNegative)
                {
                    int minusIndex = filtered.IndexOf('-');
                    if (minusIndex > 0)
                        filtered = filtered.Replace("-", "");
                }
                else
                {
                    filtered = filtered.Replace("-", "");
                }

                // 去掉非法的前导零（允许 "0" 或 "0."）
                if (filtered.Length > 1 && filtered.StartsWith("0") && !filtered.StartsWith("0."))
                {
                    filtered = filtered.TrimStart('0');
                    if (string.IsNullOrEmpty(filtered))
                        filtered = "0";
                }

                this.Text = filtered;
                this.SelectionStart = this.Text.Length;
            }
        }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;

            if (EnterKeyPressed != null)
            {
                // 如果用户绑定了事件，就执行事件
                EnterKeyPressed(this, EventArgs.Empty);
            }
            else if (EnableEnterAsTab)
            {
                // 默认行为：跳到下一个控件
                this.Parent.SelectNextControl(this, true, true, true, true);
            }
        }
    }
}
