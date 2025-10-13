using cf01.CLS;
using cf01.Forms;
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

namespace cf01.ReportForm
{
    public partial class frmGoodsTrack : Form
    {
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        ExpToExcel objExl = new ExpToExcel();
        DataTable dtPlanBom = new DataTable();
        DataTable dtBusiness = new DataTable();

        public frmGoodsTrack()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(txtMoId.Text.Trim()=="" || txtMoId.Text.Trim()=="")
            {
                MessageBox.Show("查找條件中的頁數不可為空格", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMoId.Focus();
                return;
            }           
            if (lueGoodsId.Text.Trim() == "")
            {
                MessageBox.Show("查找條件中的貨品編碼不可為空格","系統提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                lueGoodsId.Focus();
                return;
            }
            SqlParameter[] paras = new SqlParameter[]
            {
               new SqlParameter("@within_code","0000"),
               new SqlParameter("@mo_id",txtMoId.Text.Trim()),
               new SqlParameter("@Pid",lueGoodsId.Text)
            };

            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //************************                                                     
            DataSet dts = clsErp.ExecuteProcedureReturnDataSet("z_rpt_plan_flow_expand_sorting", paras, "");
            dtPlanBom = dts.Tables[0];
            dtBusiness = dts.Tables[1];
            dgv1.DataSource = dtPlanBom;
            dgv2.DataSource = dtBusiness;
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            HighlightGrid2();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgv2.Rows.Count == 0)
            {
                MessageBox.Show("表格二內容為空,沒有要匯出的數據！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
                return;
            }
            objExl.ExportExcel(dgv2);
        }

        private void txtMoId_Leave(object sender, EventArgs e)
        {
            if (txtMoId.Text != "" && txtMoId.Text.Trim().Length==9)
            {
                string sql = string.Format(
                @"SELECT B.goods_id As item,CAST(B.prod_qty+Isnull(B.obligate_qty,0) As INT) As prod_qty,wp_id,next_wp_id 
                FROM jo_bill_mostly A with(nolock),jo_bill_goods_details B with(nolock)
                WHERE A.within_code=B.within_code And A.id=B.id And A.ver=B.ver And A.within_code='{0}' And A.mo_id='{1}' 
                      And B.next_wp_id<>'{2}' Order by B.sequence_id", "0000", txtMoId.Text.Trim(), "702");
                DataTable dtPlan = clsErp.GetDataTable(sql);
                lueGoodsId.Properties.DataSource = dtPlan;
                lueGoodsId.Properties.ValueMember = "item";
                lueGoodsId.Properties.DisplayMember = "item";
            }
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            HighlightGrid2();
        }

        private void HighlightGrid2()
        {
            if (dgv1.RowCount > 0)
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;//當前焦點所在行
                string currentSeq = dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells["sequence_id"].Value.ToString();
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    if (dgv2.Rows[i].Cells["sorting_id"].Value.ToString() == currentSeq)
                    {
                        dgv2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Highlight;
                        dgv2.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
                        dgv2.CurrentCell = dgv2.Rows[i].Cells["id1"];//選中當前行
                    }
                    else
                    {
                        dgv2.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv2.Rows[i].DefaultCellStyle.ForeColor = Color.Black; // System.Drawing.SystemColors.MenuText;
                    }
                }
            }
        }
    }
}
