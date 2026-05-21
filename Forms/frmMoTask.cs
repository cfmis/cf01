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
    public partial class frmMoTask : Form
    {
        private clsShowProductionPlan clsPlan = new clsShowProductionPlan();
        public frmMoTask()
        {
            InitializeComponent();
        }

        private void frmMoTask_Load(object sender, EventArgs e)
        {
            txtMoID.Text = frmShowPlan.sent_mo_id;
            txtGoods_id.Text = frmShowPlan.sent_goods_id;
            txtGoods_Cname.Text = frmShowPlan.sent_goods_cname;
            txtWp_id.Text = frmShowPlan.sent_wp_id;
            txtNext_wp_id.Text = frmShowPlan.sent_next_wp_id;
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            //jo_mo_task_msc
            string jo_id = "";
            string result = clsPlan.SaveTask(jo_id, txtMoID.Text, txtGoods_id.Text
                , txtWp_id.Text, txtNext_wp_id.Text, datTask_date.Text, txtRemark.Text);
            if (result == "")
            {
                MessageBox.Show("儲存成功!");
                frmShowPlan.sent_mo_id = "";
                LoadData();
            }
            else
                MessageBox.Show(result);
        }
        private void LoadData()
        {
            DataTable dtTask=clsPlan.LoadTaskData();
            gcDetails.DataSource = dtTask;
        }

        private void gvDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            if (frmShowPlan.sent_mo_id == "")
            {
                if (gvDetails.RowCount > 0)
                {
                    DataRow Row = gvDetails.GetFocusedDataRow();
                    txtMoID.Text = gvDetails.GetFocusedRowCellValue("mo_id").ToString();
                    txtGoods_Cname.Text = gvDetails.GetFocusedRowCellValue("goods_cname").ToString();
                    txtWp_id.Text = gvDetails.GetFocusedRowCellValue("wp_id").ToString();
                    txtGoods_id.Text = gvDetails.GetFocusedRowCellValue("goods_id").ToString();
                    txtNext_wp_id.Text = gvDetails.GetFocusedRowCellValue("next_wp_id").ToString();
                    datTask_date.Text = gvDetails.GetFocusedRowCellValue("task_date").ToString();
                    txtRemark.Text = gvDetails.GetFocusedRowCellValue("remark").ToString();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmShowPlan.sent_mo_id = "";
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvDetails.RowCount > 0)
            {
                DataRow Row = gvDetails.GetFocusedDataRow();
                int id = Convert.ToInt32(gvDetails.GetFocusedRowCellValue("id").ToString());
                string result = clsPlan.DeleteTask(id);
                if (result == "")
                {
                    MessageBox.Show("取消提醒成功!");
                    frmShowPlan.sent_mo_id = "";
                    LoadData();
                }
                else
                    MessageBox.Show(result);
            }
        }
    }
}
