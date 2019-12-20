/*
 * Create Date:2019-01-20
 * Create by Allen Leung
 * 程序備註：
 * 設計窗體劃橫線，
 * 解決VS本身沒劃模線的控件麻煩
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ModuleClass
{
    public partial class LineX : UserControl
    {
        #region 属性定义
        private System.Drawing.Color lineColor;
        private int lineWidth;
        ///
        /// 线的颜色属性
        ///
        public System.Drawing.Color LineColor
        {
            set
            {
                this.lineColor = value;
                System.Windows.Forms.PaintEventArgs ep = new PaintEventArgs(this.CreateGraphics(),this.ClientRectangle);
                this.LineX_Paint(this, ep);
            }
            get { return this.lineColor; }
        }
        ///
        /// 线的粗细
        ///
        public int LineWidth
        {
            set
            {
                this.lineWidth = value;
                System.Windows.Forms.PaintEventArgs ep = new PaintEventArgs(this.CreateGraphics(),this.ClientRectangle);
                this.LineX_Paint(this, ep);
            }
            get { return this.lineWidth; }
        }
        #endregion 
        
        private System.ComponentModel.Container components = null;

        ///
        /// 构造函数初始颜色和线粗细
        /// 
        public LineX()
        {
            InitializeComponent();
            this.lineColor = this.ForeColor;
            this.lineWidth = 1; 
        }


        ///
        /// 清理所有正在使用的资源。
        ///
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        } 

    }
}
