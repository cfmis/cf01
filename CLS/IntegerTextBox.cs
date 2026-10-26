using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class IntegerTextBox : TextBox
{
    public bool AllowNegative { get; set; } = false;
    public bool AllowZero { get; set; } = true;

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
        if (AllowNegative)
        {
            return AllowZero ? @"^-?(0|[1-9]\d*)$" : @"^-?[1-9]\d*$";
        }
        else
        {
            return AllowZero ? @"^(0|[1-9]\d*)$" : @"^[1-9]\d*$";
        }
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);

        if (!string.IsNullOrEmpty(this.Text))
        {
            string pattern = GetPattern();

            if (!Regex.IsMatch(this.Text, pattern))
            {
                string filtered = Regex.Replace(this.Text, @"[^0-9-]", "");

                // 保证负号只能在开头
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

                // 去掉前导零（除非允许单独输入 0）
                if (!AllowZero && filtered == "0")
                {
                    filtered = "";
                }

                if (filtered.Length > 1 && filtered.StartsWith("0"))
                {
                    filtered = filtered.TrimStart('0');
                    if (string.IsNullOrEmpty(filtered))
                        filtered = AllowZero ? "0" : "";
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
