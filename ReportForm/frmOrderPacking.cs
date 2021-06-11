using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmOrderPacking : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtblPacking = new DataTable();
        DataTable dtDept = new DataTable();
        public frmOrderPacking()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
            chkSelect.Checked = false;
        }

        private void frmOderPacking1_Load(object sender, EventArgs e)
        {
            dtDept = clsBaseData.Get_Department();
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            txtLocation.Properties.DataSource = dtDept;
            txtLocation.Properties.ValueMember = "id";
            txtLocation.Properties.DisplayMember = "cdesc";


            //if (string.IsNullOrEmpty(txtCheck_date1.Text))
            //{
            //    txtCheck_date1.EditValue = System.DateTime.Now;
            //}
            //if (string.IsNullOrEmpty(txtCheck_date2.Text))
            //{
            //    txtCheck_date2.EditValue = System.DateTime.Now.ToString("s");                
            //}
        }


        private void BTNFIND_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            findData();

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtblPacking.Rows.Count > 0)
            {
                gridControl1.DataSource = dtblPacking;
            }
            else
            {
                gridControl1.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gridControl1.Refresh();
        }

        private void findData()
        {
            string strID1 = txtGoods_id1.Text;
            string strID2 = txtGoods_id2.Text;
            if (strID1 == "" && strID2 == "" && txtLocation.Text == "" && txtMo_id1.Text == "" && txtMo_id2.Text == "" && txtCheck_date1.Text == "" && txtCheck_date2.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter("@location_id", txtLocation.EditValue),
                 new SqlParameter("@check_date_s", txtCheck_date1.Text),
                 new SqlParameter("@check_date_e", txtCheck_date2.Text),
                 new SqlParameter("@mo_id_s", txtMo_id1.Text),
                 new SqlParameter("@mo_id_e", txtMo_id2.Text),
                 new SqlParameter("@goods_id_s",strID1),
                 new SqlParameter("@goods_id_e",strID2)
            };
            dtblPacking = clsPublicOfCF01.ExecuteProcedureReturnTable("p_rpt_order_picking", paras);
            //dtblPacking.Columns.Add("flag_select", System.Type.GetType("System.Boolean")); 

        }



        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            txtMo_id2.Focus();
            //當前部門工序卡           
            if (dtblPacking.Rows.Count == 0)
            {
                MessageBox.Show("請先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //gridView1.CloseEditor();
            DataTable dtblReport = new DataTable();
            dtblReport = dtblPacking.Clone();
            DataRow[] drw = dtblPacking.Select(string.Format("flag_select={0}", true));
            if(drw.Length>0)
            {
                //添加選中的記錄至臨時表中
                foreach (DataRow dr in drw)
                {
                    dtblReport.ImportRow(dr);                                      
                }                
            }
            else
            {
                MessageBox.Show("請首先選取要列印工序卡的頁數資料!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (xrOrderPacking xr = new xrOrderPacking() { DataSource = dtblReport })
            {
                xr.CreateDocument();
                xr.PrintingSystem.ShowMarginsWarning = false;
                xr.ShowPreviewDialog();
            }

           
           
            
        }

        private void clFlag_select_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDelivery.Checked)
            {
                gridView1.CloseEditor();//將當前行所有更改立即定入綁定的數據源
                string strID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "mo_id").ToString();
                string value_select = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString();
                bool flag;
                if (value_select == "True")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                for (int i = 0; i < dtblPacking.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, "mo_id") == strID)
                    {
                        gridView1.SetRowCellValue(i, "flag_select", flag);
                    }
                }
                gridView1.CloseEditor();
            }
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void txtGoods_id1_Leave(object sender, EventArgs e)
        {
            txtGoods_id2.Text = txtGoods_id1.Text;
        }

        private void txtCheck_date1_Leave(object sender, EventArgs e)
        {
            txtCheck_date2.EditValue = txtCheck_date1.EditValue;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (dtblPacking.Rows.Count > 0)
            {
                Boolean blSetValue = true;
                if (chkSelect.Checked)
                {
                    blSetValue = true;//Select All                    
                }
                else
                {
                    blSetValue = false;
                }
                for (int i = 0; i < dtblPacking.Rows.Count; i++)
                {
                    gridView1.SetRowCellValue(i, "flag_select", blSetValue);
                }

            }
        }
    }
    
}
