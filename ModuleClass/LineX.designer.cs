using System.Drawing;
namespace cf01.ModuleClass
{
    partial class LineX
    {
       
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LineX
            // 
            this.Name = "LineX";
            this.Size = new System.Drawing.Size(20, 34);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LineX_Paint);
            this.Resize += new System.EventHandler(this.LineX_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private void LineX_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(this.lineColor);
            myPen.Width = this.lineWidth * 2;
            this.Height = this.LineWidth;
            g.DrawLine(myPen, 0, 0, e.ClipRectangle.Right, 0);
        }

        private void LineX_Resize(object sender, System.EventArgs e)
        {
            this.Height = this.lineWidth;
        } 


    }
}
