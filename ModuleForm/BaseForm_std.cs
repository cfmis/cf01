using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace cf01.ModuleForm
{
    public partial class BaseForm_std : Form
    {
        public BaseForm_std()
        {
            InitializeComponent();            
        }

        public virtual void Append()
        {
            MessageBox.Show("TEST");
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Append();
        }   

    }
}
