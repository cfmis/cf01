using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace cf01.ReportForm
{
    public partial class frmDeliveryPrepare : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtReport0 = new DataTable();
        DataTable dtReport1 = new DataTable();
        public frmDeliveryPrepare()
        {
            clsApp.Initialize_find_value(this.Name, this.Controls);
            InitializeComponent();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            //// 測試用
            //int index = 0;
            //string fileName = "test04_01_001.xls";
            //string str6 = @"D:\Workspace\DMS\CF2025.Web.Admin\Document\Files\public\TEST6\test04_018\test04_01_001.xls";
            //index = str6.IndexOf(@"public\");
            //string currentPath = str6.Substring(index); //currentPath="public\TEST6\test04_018\test04_01_001.xls"                   
            //index = currentPath.LastIndexOf(fileName);
            //currentPath = currentPath.Substring(0, index - 1);//currentPath="public\TEST6\test04_018"

            //int index_start = str5.IndexOf(@"\public");
            //string currentPath = str5.Substring(index_start, str5.Length - index_start);
            //string currentPath = str5.Substring(index_start);
            //string fileName = "test04_01_001.xls";
            //index_start = currentPath.LastIndexOf(fileName);
            //string currentPath1 = currentPath.Substring(0, index_start -1);

            //string currentPath = "public\\TEST6\\123";
            //string fileName = "123";
            //int index_start = currentPath.LastIndexOf(fileName);
            //string strParentPath = "\\" + currentPath.Substring(0, index_start-1);
            //return;


            if (txtDat1.Text == "" && txtDat2.Text == "" && txtSalesGroup.Text == "" )
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDat1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@mo_group",txtSalesGroup.Text),
                new SqlParameter("@order_date",txtDat1.Text),
                new SqlParameter("@order_date_end",txtDat2.Text)
            };
            int result = 0;          
            if (radioGroup1.SelectedIndex == 0)
            {
                dtReport0 = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_delivery_prepare", paras);
                SetStripe(dtReport0);
                dgvDetails0.DataSource = dtReport0;
                result = dtReport0.Rows.Count;
            }
            else
            {
                dtReport1 = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_delivery_prepare_prev_dept", paras);
                SetStripe(dtReport1);
                dgvDetails1.DataSource = dtReport1;
                result = dtReport1.Rows.Count;
            } 
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });            
           
            if (result == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SetStripe(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string prev_mo = dt.Rows[0]["mo_id"].ToString();  
            int cur_stripe = int.Parse(dt.Rows[0]["stripe"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    //從第二行開始
                    if(dt.Rows[i]["mo_id"].ToString() == prev_mo)
                    {
                        dt.Rows[i]["stripe"] = cur_stripe;
                    }
                    else
                    {
                        //不同頁數開始
                        cur_stripe = cur_stripe == 0 ? 1 : 0;
                        dt.Rows[i]["stripe"] = cur_stripe;                        
                    }
                }
                prev_mo = dt.Rows[i]["mo_id"].ToString();
                cur_stripe = int.Parse(dt.Rows[i]["stripe"].ToString());
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                dgvDetails0.Visible = true;
                dgvDetails1.Visible = false;
            }
            else
            {
                dgvDetails0.Visible = false;
                dgvDetails1.Visible = true;
            }
        }

        private void frmDeliveryPrepare_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0, 10);
                txtDat1.EditValue = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd").Substring(0, 10);
            }
            //禁止列排序            
            //for (int i = 0; i < dgvDetails0.Columns.Count; i++)
            //{
            //    dgvDetails0.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            for (int i = 0; i < dgvDetails1.Columns.Count; i++)
            {
                dgvDetails1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            ExpToExcel oxls = new ExpToExcel();
            DataGridView dgv;
            int result = 0;
            if (radioGroup1.SelectedIndex == 0)
            {
                result = dgvDetails0.Rows.Count;
                dgv = dgvDetails0;
            }
            else
            {
                result = dgvDetails1.Rows.Count;
                dgv = dgvDetails1;
            }
            if (result == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
            oxls.ExportToExcel_Fast(dgv);
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void dgvDetails0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvDetails0.Rows[e.RowIndex].Cells["stripe"].Value.ToString() == "1")
            {               
                dgvDetails0.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void dgvDetails1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvDetails1.Rows[e.RowIndex].Cells["stripe1"].Value.ToString() == "1")
            {
                dgvDetails1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void dgvDetails0_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            
            if (dgvDetails0.Columns[e.ColumnIndex].Name == "flag_select")
            {
                txtSalesGroup.Focus();
                string result = "";
                DataGridViewRow row = dgvDetails0.Rows[e.RowIndex];
                result = row.Cells["flag_select"].Value.ToString();
                if (bool.Parse(row.Cells["flag_select"].Value.ToString()) == true)
                {
                    if (!string.IsNullOrEmpty(row.Cells["mo_id1"].Value.ToString()))
                    {
                        MessageBox.Show("頁數"+ row.Cells["mo_id1"].Value.ToString()+"已開有回港單.");
                        row.Cells["flag_select"].Value = false;//賦值
                    }
                }
                //dtReport0.AcceptChanges();
                // result = dgvDetails0.Rows[e.RowIndex].Cells["flag_select"].Value.ToString();
                //     result = dtReport0.Rows[e.RowIndex]["flag_select"].ToString();
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DataRow[] ary_drs = dtReport0.Select("flag_select=true");
        //    textEdit1.Text = ary_drs.Length.ToString();
        //}
    }
}
