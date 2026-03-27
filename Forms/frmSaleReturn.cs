using cf01.CLS;
using cf01.ModuleClass;
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
    public partial class frmSaleReturn : Form
    {
        clsAppPublic clsApp = new clsAppPublic();

        public frmSaleReturn()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, grpBox1.Controls);
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
        }

        private void frmSaleReturn_Load(object sender, EventArgs e)
        {
            //
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            //
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value("frmSaleReturn", grpBox1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
