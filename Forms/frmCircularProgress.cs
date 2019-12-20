using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace cf01.Forms
{
    public partial class frmCircularProgress : Form
    {
        public frmCircularProgress()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            progressIndicatorAbout.Start();
            progressIndicatorAbout.CircleColor = Color.LightGreen;
            //progressIndicatorAbout.NumberOfVisibleCircles = 50;
           //progressIndicatorAbout.NumberOfCircles = 0;
            
        }
       
    }
}
