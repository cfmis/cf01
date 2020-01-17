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
    public partial class frmTestInvoiceEditInv : Form
    {
        public string m_invoice_id_edit = "";
        public frmTestInvoiceEditInv(string invoice_id_org)
        {
            InitializeComponent();
            txtinvoice_id_org.Text = invoice_id_org;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            m_invoice_id_edit = "";
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtinvoice_id_org.Text !="" && txtinvoice_id_target.Text !="")
            {
                m_invoice_id_edit = txtinvoice_id_target.Text;
            }
            else
                m_invoice_id_edit = "";
            this.Close();
        }
    }
}
