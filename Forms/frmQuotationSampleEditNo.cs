using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmQuotationSampleEditNo : Form
    {
        public string strNewSerailNo="";

        public frmQuotationSampleEditNo(string OriginalNo)
        {
            InitializeComponent();           
            txtOriginalNo.Text = OriginalNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(makNewSerialNo.Text.Length<14 || makNewSerialNo.Text == "")
            {
                MessageBox.Show("需指定正確的序列號!", "提信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            bool flag_update = false;
            string sql_f = string.Format(@"Select serial_no From quotation_sample WHERE serial_no='{0}'", makNewSerialNo.Text);
            string sql_u = string.Format(@"Update quotation_sample SET serial_no='{0}' WHERE serial_no='{1}'",makNewSerialNo.Text, txtOriginalNo.Text);
            string result = clsPublicOfCF01.ExecuteSqlReturnObject(sql_f);
            if (result == "")
            {
                result = clsPublicOfCF01.ExecuteSqlUpdate(sql_u);
                MessageBox.Show("更新成功!", "提信息");
                strNewSerailNo = makNewSerialNo.Text;
                flag_update = true;
            }
            else
            {
                MessageBox.Show(string.Format(@"編號{0}已被在使用,請返回重新指定新的值!", makNewSerialNo.Text), "提信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (flag_update)
            {
                this.DialogResult = DialogResult.Yes;//標記查詢到數據并退出
            } 
        }
    }
}
