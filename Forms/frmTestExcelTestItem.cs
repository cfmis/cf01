using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using System.Drawing;

namespace cf01.Forms
{
    public partial class frmTestExcelTestItem : Form
    {
        DataTable dtTest_item;
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public List<mdlTestItem> mdlTest = new List<mdlTestItem>();

        public frmTestExcelTestItem()
        {
            InitializeComponent();
        }

        private void frmTestExcelTestItem_Load(object sender, EventArgs e)
        {
            const string strSql = @"SELECT convert(bit,0) as select_flag,test_item_id as id,test_item_name as cdesc,english_name as edesc FROM dbo.cd_qc_test_item order by test_item_type desc,test_item_id";
            dtTest_item = clsConErp.GetDataTable(strSql);
            dgvTestitem.DataSource = dtTest_item;
        }

        private void frmTestExcelTestItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConErp = null;
            dtTest_item.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool select_flag = false;
            dtTest_item.AcceptChanges();
            for (int i = 0; i < dgvTestitem.RowCount; i++)
            {                
                if (dtTest_item.Rows[i]["select_flag"].ToString() == "True")
                {
                    select_flag = true;
                    break;
                }
            }

            if (!select_flag)
            {
                MessageBox.Show("請選擇要添加的測試項目!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            mdlTest.Clear();
            for (int i = 0; i < dgvTestitem.RowCount; i++)
            {
                if (dtTest_item.Rows[i]["select_flag"].ToString() == "True")
                {
                    mdlTestItem test_item = new mdlTestItem()
                    {
                        id = dtTest_item.Rows[i]["id"].ToString(),
                        cdesc = dtTest_item.Rows[i]["cdesc"].ToString(),
                        edesc = dtTest_item.Rows[i]["edesc"].ToString()
                    };
                    mdlTest.Add(test_item);                   
                }
            }
            this.Close();
        }

        private void dgvTestitem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvTestitem.Rows.Count > 0)
            {
                if (dgvTestitem.Rows[e.RowIndex].Cells["select_flag"].Value.ToString() == "False")
                    dgvTestitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dgvTestitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PowderBlue;// Color.FromArgb(0xCC, 0xFF, 0xCC);
            }
        }
    }
}

     

