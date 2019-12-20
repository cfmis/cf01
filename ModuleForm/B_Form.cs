using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace cf01.ModuleForm
{
    public partial class B_Form : Form
    {
        public B_Form()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btmPrint_Click(object sender, EventArgs e)
        {

        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        
    }
}
