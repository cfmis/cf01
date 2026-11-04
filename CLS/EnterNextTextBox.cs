using System;
using System.Windows.Forms;

public class EnterNextTextBox : TextBox
{
    /// <summary>
    /// 是否启用默认“回车跳下一个”行为
    /// </summary>
    public bool EnableEnterAsTab { get; set; } = true;

    /// <summary>
    /// 是否自动转大写，默认 true
    /// </summary>
    public bool AutoUpperCase { get; set; } = true;

    /// <summary>
    /// 当按下回车时触发的自定义事件（可选）
    /// </summary>
    public event EventHandler EnterKeyPressed;

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

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);

        if (AutoUpperCase && !string.IsNullOrEmpty(this.Text))
        {
            int selStart = this.SelectionStart;
            this.Text = this.Text.ToUpper();
            this.SelectionStart = selStart; // 保持光标位置
        }
    }
}
