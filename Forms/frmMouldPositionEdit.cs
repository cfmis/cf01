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
    public partial class frmMouldPositionEdit : Form
    {
        string id;
        string dept_id;
        string mould_no;
        public string new_id="";
        public frmMouldPositionEdit(string strId,string strDept_id,string strMould_no)
        {
            InitializeComponent();
            id = strId;
            dept_id = strDept_id;
            mould_no = strMould_no;
            txtId.Text = strId;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            new_id = "";
            if (txtId.Text == "")
            {
                return;
            }
            string result = clsMouldPosition.UpdatePosition(id, dept_id, mould_no, txtId.Text.Trim());           
            if (result == "")
            {
                new_id = txtId.Text.Trim();
                this.Close();
            }
        }
    }
}
