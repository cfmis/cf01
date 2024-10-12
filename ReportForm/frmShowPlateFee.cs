using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;


namespace cf01.ReportForm
{
    public partial class frmShowPlateFee : cf01.ModuleForm.BaseFormMaster
    {
        DataTable dt1;
        public frmShowPlateFee()
        {
            InitializeComponent();
            clsPublic objPublic = new clsPublic(this.Name, this.Controls);
            objPublic.GenerateData();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void mkbDate1_Leave(object sender, EventArgs e)
        {
            mkbDate2.Text = mkbDate1.Text;
        }
        public override void Find()
        {
            string dat1, dat2;
            if (mkbDate1.Text == "    /  /")
                dat1 = "";
            else
                if (mkbDate1.Text.Length != 10)
                    return;
                else
                    dat1 = mkbDate1.Text;
            if (mkbDate2.Text == "    /  /")
                dat2 = "";
            else
                if (mkbDate2.Text.Length != 10)
                    return;
                else
                    dat2 = mkbDate1.Text;
            clsCommonUse c = new clsCommonUse();
            dt1 = c.getDataProcedure("zsp_show_plate_fee",
                new object[] {  dat1, dat2 });
            dgvDetails.DataSource = dt1;
        }
    }
}
