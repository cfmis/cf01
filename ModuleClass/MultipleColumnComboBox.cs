using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace cf01.ModuleClass
{
   public class MultipleColumnComboBox
    {
        /// <summary>
        ///设置ComboBox 显示多列 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        public void DesignComboBoxColummn(ComboBox cb, string Id, string Name)
        {
            cb.DrawMode = DrawMode.OwnerDrawFixed;
            // Handle the DrawItem event to draw the items.
            cb.DrawItem += delegate(object cmb, DrawItemEventArgs args)
            {
                // Draw the default background
                args.DrawBackground();


                // The ComboBox is bound to a DataTable,
                // so the items are DataRowView objects.
                DataRowView drv = (DataRowView)cb.Items[args.Index];

                // Retrieve the value of each column.
                string id = drv[Id].ToString();
                string name = drv[Name].ToString();

                // Get the bounds for the first column
                Rectangle r1 = args.Bounds;
                r1.Width /= 2;

                // Draw the text on the first column
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(id, args.Font, sb, r1);
                }

                // Draw a line to isolate the columns 
                using (Pen p = new Pen(Color.Black))
                {
                    args.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom);
                }

                // Get the bounds for the second column
                Rectangle r2 = args.Bounds;
                r2.X = args.Bounds.Width / 2;
                r2.Width /= 2;

                // Draw the text on the second column
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(name, args.Font, sb, r2);
                }

            };
        }
    }
}
