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
    public partial class frmQcTestReport_Add_List1 : Form
    {
        string m_type="";
        DataTable dtItem = new DataTable();
        public List<string> m_item_list =new List<string>();
        public frmQcTestReport_Add_List1(string ptype)
        {
            InitializeComponent();
            m_type = ptype;
        }

        private void frmQcTestReport_Add_List1_Load(object sender, EventArgs e)
        {           
            if (m_type == "1")
            {
                dtItem = clsQcTestReport.GetProduct_Item_Select();
            }
            else
            {
                dtItem = clsQcTestReport.GetTest_Item_Select();
            }
            dgvItem.DataSource = dtItem;
        }

        private void chkSelectAll_MouseUp(object sender, MouseEventArgs e)
        {
            bool lb_flag;
            if (chkSelectAll.Checked)
            {
                lb_flag = true;                
            }
            else
            {
                lb_flag = false;
            }
            for (int i = 0; i < dgvItem.Rows.Count; i++)
            {
                dgvItem.Rows[i].Cells["flag_select"].Value = lb_flag;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQcTestReport_Add_List1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtItem.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool lb_flag_select = false;
            for (int i = 0; i < dgvItem.Rows.Count; i++)
            {
                if (dgvItem.Rows[i].Cells["flag_select"].Value.ToString() == "True")
                {
                    lb_flag_select = true;
                    break;
                }
            }
            if (!lb_flag_select)
            {
                MessageBox.Show("請首先選擇要添加的項目!", "提示信息");
                return;
            }

            for (int i = 0; i < dgvItem.Rows.Count; i++)
            {
                if (dgvItem.Rows[i].Cells["flag_select"].Value.ToString() == "True")
                {
                    m_item_list.Add(dgvItem.Rows[i].Cells["item_no"].Value.ToString());
                }
            }
            this.Close();
        }

     
    }
}
