using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmCustComplain_Find : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        public frmCustComplain_Find()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.panelControl1.Controls); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsApp = null;
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }

        private void findData()
        {
            string dat1,dat2 ;
            if (dtDate1.Text != "")
                dat1 = Convert.ToDateTime(dtDate1.Text).ToString("yyyy/MM/dd");
            else
                dat1 = "";
            if (dtDate2.Text != "")
                dat2 = Convert.ToDateTime(dtDate2.Text).AddDays(1).ToString("yyyy/MM/dd");
            else
                dat2 = "";
            DataTable dtIdDetails = clsCustComplain.findIdDetails(txtId1.Text, txtId2.Text,txtCust1.Text, txtCust2.Text, dat1, dat2, txtMo_id1.Text, txtMo_id2.Text);
            gcDetails.DataSource = dtIdDetails;
            if (dtIdDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查找條件的數據!", "提示信息");
            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            returnValue();
        }
       
        private void returnValue()
        {
            frmCustComplain.query_id = dgvDetails.GetRowCellValue(dgvDetails.FocusedRowHandle, "id").ToString();
            clsApp = null;
            Close();
        }

        /// <summary>
        /// 雙擊退出
        /// </summary>
        private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = dgvDetails.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    returnValue();
                }
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }    

        private void dtDate1_Leave(object sender, EventArgs e)
        {
            dtDate2.EditValue = dtDate1.EditValue;
        }

        private void txtCust1_Leave(object sender, EventArgs e)
        {
            txtCust2.Text = txtCust1.Text;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.panelControl1.Controls) > 0)
            {               
                clsUtility.myMessageBox("當前查詢條件保存成功!", "提示信息");
            }
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
    }
}
