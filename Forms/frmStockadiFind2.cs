using cf01.CLS;
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
    public partial class frmStockadiFind2 : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        DataTable dtFind = new DataTable();
        public string temp_id = "";


        public frmStockadiFind2()
        {
            InitializeComponent();
            clsApp.Initialize_find_value("frmStockadiFind2", panel1.Controls);
        }

        private void frmStockadiFind2_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            txtLocationId.Text = "";
            txtMo_id.Text = "";
            txtGoods_id.Text = "";
            
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件
            if (clsApp.set_find_Value("frmStockadiFind2", panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
