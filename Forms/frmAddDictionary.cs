using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.ModuleForm;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmAddDictionary : BaseFormMaster
    {
        public frmAddDictionary()
        {
            InitializeComponent();

            clsPublic objPublic = new clsPublic(this.Name, this.Controls);
            objPublic.GenerateData();

        }

        private void frmAddDictionary_Load(object sender, EventArgs e)
        {
            //InitTextEnable();
        }
    }
}
