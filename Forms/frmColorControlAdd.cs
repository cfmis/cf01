using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmColorControlAdd : Form
    {
        public int addIndex=0;
        public int curIndex=0;
        public string insertType = "";
        public frmColorControlAdd(int index)
        {
            InitializeComponent();
            radBottom.Checked = true;
            curIndex = index;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            insertType = "";
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (radBottom.Checked)
            {
                insertType = "Bottom";
            }                
            //if (radBefore.Checked)
            //{
            //    insertType = "Before";
            //    //addIndex = curIndex > 0 ? curIndex - 1 : 0;
            //    addIndex = curIndex;
            //}               
            if (radBehind.Checked)
            {
                insertType = "Behind";
                addIndex = curIndex == 0 ? 1 : curIndex + 1;
            }
            this.Close();
        }

        private void frmColorControlAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("test");
        }
    }
}
