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
    public partial class frmTest_item_set_find : Form
    {
        public static string str_language = "0";
        public string test_public_path = "";
        DataTable dtTest = new DataTable();   
        public frmTest_item_set_find()
        {
            InitializeComponent();
            str_language = DBUtility._language;
           // NextControl oNext = new NextControl(this, "2");
           // oNext.EnterToTab();  
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTest_item_set_find_Load(object sender, EventArgs e)
        {
            //設置測試項目編號
            clsTestProductPlan.SetTest_item(txtTest_item1);
            clsTestProductPlan.SetTest_item(txtTest_item2);

            DataTable dtTest_item = clsPublicOfCF01.GetDataTable(@"Select distinct id,cdesc FROM dbo.bs_test_item_mostly");                 
            DataRow dr0 = dtTest_item.NewRow(); //插一空行        
            dtTest_item.Rows.InsertAt(dr0, 0);           
            txtID1.Properties.DataSource = dtTest_item;
            txtID1.Properties.ValueMember = "id";
            txtID1.Properties.DisplayMember = "cdesc";

            txtID2.Properties.DataSource = dtTest_item;
            txtID2.Properties.ValueMember = "id";
            txtID2.Properties.DisplayMember = "cdesc";
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {
            txtID2.EditValue = txtID1.EditValue;
        }

        private void txtTest_item1_Leave(object sender, EventArgs e)
        {
            txtTest_item2.EditValue = txtTest_item1.EditValue;
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            SetObjValue.ClearObjValue(this.Controls, "1");
            dtTest.Clear();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtID2.Focus();
            LoadData();
        }

        private void LoadData()
        {           
            //if (strID1== "" && strID2=="" && strTest1=="" && strTest2=="")
            //{
            //    MessageBox.Show("查詢條件不可以爲空!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            StringBuilder sb = new StringBuilder(
             @"SELECT A.id,A.prod_type,A.cdesc,A.edesc,A.type+Isnull(C.cdesc,'') AS type,B.test_item_id,B.test_item_cdesc,B.test_item_edesc,D.cdesc AS prod_cdesc 
               FROM dbo.bs_test_item_mostly A,dbo.bs_test_item_details B,dbo.bs_test_type C,dbo.bs_test_product_type D
               WHERE A.id =B.id AND A.prod_type=B.prod_type AND A.state ='0' AND A.type*=C.id AND A.prod_type*=D.id ");
            if (txtID1.Text != "")
            {
                sb.Append(String.Format(" AND A.id>='{0}'", txtID1.EditValue));
            }
            if (txtID2.Text != "")
            {
                sb.Append(String.Format(" AND A.id<='{0}'", txtID2.EditValue));
            }
            if (txtTest_item1.Text != "")
            {
                sb.Append(String.Format(" AND B.test_item_id>='{0}'", txtTest_item1.EditValue));
            }
            if (txtTest_item2.Text != "")
            {
                sb.Append(String.Format(" AND B.test_item_id<='{0}'", txtTest_item2.EditValue));
            }
            sb.Append(" ORDER BY A.type,A.id,A.prod_type,B.seq_id");
            dtTest = clsPublicOfCF01.GetDataTable(sb.ToString());
            dgvDetails.DataSource = dtTest;
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("沒有滿足條件的資料!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTest_item_set.ID_Search = "";
            }
            
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void Print() //通用的打印方法
        {
            if (dgvDetails.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvDetails);
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            Excel();
        }

        private void Excel()
        {
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(dgvDetails);
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                frmTest_item_set.ID_Search = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
                frmTest_item_set.Prod_type_Search = dgvDetails.CurrentRow.Cells["prod_type"].Value.ToString();
            }
        }

        private void dgvDetails_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTest_item1_Click(object sender, EventArgs e)
        {
            txtTest_item1.SelectAll();
        }

        private void txtTest_item2_Click(object sender, EventArgs e)
        {
            txtTest_item2.SelectAll();
        }

        private void txtID1_Click(object sender, EventArgs e)
        {
            txtID1.SelectAll();
        }

        private void txtID2_Click(object sender, EventArgs e)
        {
            txtID2.SelectAll();
        }
    }
}
