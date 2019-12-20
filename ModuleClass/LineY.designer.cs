using System.Drawing;
namespace cf01.ModuleClass
{
    partial class LineY
    {
       

        #region Component Designer generated code

        ///
        /// 设计器支持所需的方法 - 不要使用代码编辑器
        /// 修改此方法的内容。
        /// 
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LineY
            // 
            this.Name = "LineY";
            this.Size = new System.Drawing.Size(23, 24);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LineY_Paint);
            this.Resize += new System.EventHandler(this.LineY_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private void LineY_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(this.lineColor);
            myPen.Width = this.lineWidth * 2;
            this.Width = this.LineWidth;
            g.DrawLine(myPen, 0, 0, 0, e.ClipRectangle.Bottom);
        }

        private void LineY_Resize(object sender, System.EventArgs e)
        {
            this.Width = this.lineWidth;
        } 

    
    }
}
