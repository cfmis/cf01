using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmMo_test_list_ver : Form
    {
        public string _id = "";
        public string _Requ_id="";
        public string _ver="";
        readonly MsgInfo myMsg = new MsgInfo();
        public frmMo_test_list_ver(string _pID)
        {
            InitializeComponent();
            _id = _pID;            
        }

        private void frmMo_test_list_ver_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_id))
            {
                txtMo_id1.Text = _id;
                txtMo_id2.Text = _id; 
                Find_Data();
            }                      
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            if (txtMo_id2.Text == "")
            { 
               txtMo_id2.Text = txtMo_id1.Text; 
            }
        }     

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find_Data();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                _Requ_id = dataGridView1.CurrentRow.Cells["mo_id"].Value.ToString();
                _ver = dataGridView1.CurrentRow.Cells["ver"].Value.ToString();
                Close();
            }
        }    

        private void Find_Data()
        {
            if (string.IsNullOrEmpty(txtMo_id1.Text) && string.IsNullOrEmpty(txtMo_id2.Text))               
            {
                MessageBox.Show("查詢條件不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string sql_f = @"SELECT A.mo_id,A.ver,result FROM dbo.bs_mo_test_list_head A with(nolock) WHERE 1>0 ";
            StringBuilder myString = new StringBuilder("");
            myString.Append(sql_f);
            if (!string.IsNullOrEmpty(txtMo_id1.Text))
            {
                myString.Append(String.Format(" AND A.mo_id>='{0}'", txtMo_id1.Text));
            }
            if (!string.IsNullOrEmpty(txtMo_id2.Text))
            {
                myString.Append(String.Format(" AND A.mo_id<='{0}'", txtMo_id2.Text));
            }            
            myString.Append("ORDER BY A.mo_id,A.ver");
            DataTable dtFind = clsPublicOfCF01.GetDataTable(myString.ToString());
            dataGridView1.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("找不到符合查詢條件的數據!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

         
     }
 }

