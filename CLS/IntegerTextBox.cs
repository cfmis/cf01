using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class IntegerTextBox : TextBox
{
    public bool AllowNegative { get; set; } = false;
    public bool AllowZero { get; set; } = true;

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
}
