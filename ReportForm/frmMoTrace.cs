using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.Forms;
using cf01.CLS;
using System.Threading;

namespace cf01.ReportForm
{
    public partial class frmMoTrace : Form
    {
        public frmMoTrace()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            LoadMoData(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadMoData()
        {
            string mo_id = txtMo.Text.Trim();
            //提取OC
            DataTable dtOc = clsMoTrace.GetMoOc(mo_id);
            if (dtOc.Rows.Count > 0)
                txtOcQty.Text = dtOc.Rows[0]["order_qty_pcs"].ToString();
            else
                txtOcQty.Text = "";
            //提取生產計劃
            DataTable dtPlan = clsMoTrace.GetMoPlan(mo_id);
            dgvPlan.DataSource = dtPlan;
            //外發數據

            
        }

        private void frmMoTrace_Load(object sender, EventArgs e)
        {
            dgvPlan.AutoGenerateColumns = false;
            dgvOp.AutoGenerateColumns = false;
            dgvTr.AutoGenerateColumns = false;
        }

        private void dgvPlan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlan.CurrentRow == null)
                return;
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            LoadTraceData(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void LoadTraceData()
        {
            DataGridViewRow dgr = dgvPlan.Rows[dgvPlan.CurrentRow.Index];
            string mo_id = txtMo.Text.Trim();
            string dep_id = dgr.Cells["colWp_id"].Value.ToString();
            string next_wp_id = dgr.Cells["colNext_wp_id"].Value.ToString();//txtWf_Goods_id
            string goods_id= dgr.Cells["colGoods_id"].Value.ToString();//
            txtWf_Wip.Text = dep_id;
            txtTr_Wip.Text = dep_id;
            txtWf_Goods_id.Text = goods_id;
            txtNextWip.Text = next_wp_id;
            LoadOpData(mo_id, dep_id,goods_id);
            LoadTrData(mo_id, dep_id, goods_id);
            LoadNextTrData(mo_id, next_wp_id, goods_id);
        }
        private void LoadOpData(string mo_id,string dep_id,string goods_id)
        {
            DataTable dtOp = clsMoTrace.GetMoOp(mo_id, dep_id, goods_id);
            dgvOp.DataSource = dtOp;
        }
        private void LoadTrData(string mo_id, string dep_id, string goods_id)
        {
            DataTable dtTr = clsMoTrace.GetMoTr(mo_id, dep_id, goods_id);
            dgvTr.DataSource = dtTr;
        }
        private void LoadNextTrData(string mo_id, string dep_id, string goods_id)
        {
            DataTable dtNextTr = clsMoTrace.GetMoTr(mo_id, dep_id, goods_id);
            dgvNextTr.DataSource = dtNextTr;
        }
        private void btnSetPlanVisible_Click(object sender, EventArgs e)
        {
            //
            SetPanelVisible("00");
        }
        private void btnSetWfVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("01");
        }
        private void btnSetTrVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("02");
        }
        private void btnSetNextTrVisible_Click(object sender, EventArgs e)
        {
            SetPanelVisible("03");
        }
        /// <summary>
        /// ///顯示各個項目
        /// </summary>
        /// <param name="processType"></param>
        private void SetPanelVisible(string processType)
        {
            switch (processType)
            {
                case "00"://外發
                    if (btnSetPlanVisible.Text == "折疊<<")
                    {
                        dgvPlan.Visible = false;
                        btnSetPlanVisible.Text = "展開>>";
                    }
                    else
                    {
                        dgvPlan.Visible = true;
                        btnSetPlanVisible.Text = "折疊<<";
                    }
                    break;
                case "01"://外發
                    if (btnSetWfVisible.Text == "折疊<<")
                    {
                        dgvOp.Visible = false;
                        btnSetWfVisible.Text = "展開>>";
                    }
                    else
                    {
                        dgvOp.Visible = true;
                        btnSetWfVisible.Text = "折疊<<";
                    }
                    break;
                case "02"://本部門移交
                    if (btnSetTrVisible.Text == "折疊<<")
                    {
                        dgvTr.Visible = false;
                        btnSetTrVisible.Text = "展開>>";
                    }
                    else
                    {
                        dgvTr.Visible = true;
                        btnSetTrVisible.Text = "折疊<<";
                    }
                    break;
                case "03"://下部門移交
                    if (btnSetNextTrVisible.Text == "折疊<<")
                    {
                        dgvNextTr.Visible = false;
                        btnSetNextTrVisible.Text = "展開>>";
                    }
                    else
                    {
                        dgvNextTr.Visible = true;
                        btnSetNextTrVisible.Text = "折疊<<";
                    }
                    break;
                default:
                    break;
            }

        }

        
    }
}
