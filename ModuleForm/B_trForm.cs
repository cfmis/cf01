using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ModuleForm
{
    public partial class B_trForm : Form
    {
        public B_trForm()
        {
            InitializeComponent();
        }

        private void btmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
