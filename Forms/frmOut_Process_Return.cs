using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Reports;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmOut_Process_Return : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        private DataTable dtReturn = new DataTable();
        public frmOut_Process_Return()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, panel1.Controls);
            chkSelect.Checked = false;
        }

        private void frmOut_Process_Return_Load(object sender, EventArgs e)
        {
            DataTable dtVendor = clsBaseData.Get_Plate_Vendor();
            DataRow dr0 = dtVendor.NewRow(); //插一空行        
            dtVendor.Rows.InsertAt(dr0, 0);
            txtVendor_id1.Properties.DataSource = dtVendor;
            txtVendor_id1.Properties.ValueMember = "id";
            txtVendor_id1.Properties.DisplayMember = "id";

            txtVendor_id2.Properties.DataSource = dtVendor;
            txtVendor_id2.Properties.ValueMember = "id";
            txtVendor_id2.Properties.DisplayMember = "id";
            
            txtDat1.EditValue = DateTime.Now;
            txtDat2.EditValue = DateTime.Now;         
        }


        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            SetObjValue.ClearObjValue(panel1.Controls, "1");
            dtReturn.Clear();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtVendor_id2.Focus();
            if (txtDat1.Text == "" && txtDat2.Text == "" && txtID1.Text == "" && txtID2.Text == "" 
                && txtVendor_id1.Text == "" && txtVendor_id2.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoadData();
        }

        private void LoadData()
        {
            string strDat1 = txtDat1.Text;
            string strDat2 = txtDat2.Text;         
            SqlParameter[] paras = new SqlParameter[]
            {
                    new SqlParameter("@dat1", strDat1),
                    new SqlParameter("@dat2", strDat2),
                    new SqlParameter("@id1", txtID1.Text),
                    new SqlParameter("@id2", txtID2.Text),
                    new SqlParameter("@vendor_id1", txtVendor_id1.EditValue),
                    new SqlParameter("@vendor_id2", txtVendor_id2.EditValue)
			};
            dtReturn = clsConErp.ExecuteProcedureReturnTable("z_rpt_out_return", paras);

            if (dtReturn.Rows.Count > 0)
            {
                ////加載報表
                //xrOut_process_out mMyRepot = new xrOut_process_out() { DataSource = dtReturn };
                //mMyRepot.CreateDocument();
                //mMyRepot.PrintingSystem.ShowMarginsWarning = false;
                //mMyRepot.ShowPreview();
                dgvDetails.DataSource = dtReturn;
            }
            else
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }            
            string strName = dgvDetails.Columns[e.ColumnIndex].Name;//當前單無格的列名           
            if (strName == "select_flag")
            {
                bool flag;
                string strid = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
                //string strid = dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells["id"].Value.ToString();
                if ((bool)dgvDetails.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {                    
                    if (dgvDetails.Rows[i].Cells["id"].Value.ToString() == strid)
                    {
                        dgvDetails.Rows[i].Cells["select_flag"].Value = flag;
                    }
                }
            }     
        }

        private void chkSelect_Click(object sender, EventArgs e)
        {           
            //(bool)dgvOperation.Rows[i].Cells[0].EditedFormattedValue == true
            if (chkSelect.Checked)
            {
                //循环dataGridView
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    //设置设置每一行的选择框为选中，第一列为checkbox
                    dgvDetails.Rows[i].Cells[0].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    //设置设置每一行的选择框为选中，第一列为checkbox
                    dgvDetails.Rows[i].Cells[0].Value = false;
                }
            }           
        }

        private void txtVendor_id1_Leave(object sender, EventArgs e)
        {
            txtVendor_id2.EditValue = txtVendor_id1.EditValue;
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {
            txtID2.EditValue = txtID1.EditValue;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if(dgvDetails.RowCount==0)
            {
                return;
            }
            DataTable dtReport = new DataTable();
            dtReport = dtReturn.Clone();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["select_flag"].EditedFormattedValue == true)
                {
                    DataRow newRow = dtReport.NewRow();
                    newRow["id"] = dgvDetails.Rows[i].Cells["id"].Value;//.ToString();
                    newRow["ir_date"] = dgvDetails.Rows[i].Cells["ir_date"].Value;
                    newRow["vendor_id"] = dgvDetails.Rows[i].Cells["vendor_id"].Value;
                    newRow["vendor_name"] = dgvDetails.Rows[i].Cells["vendor_name"].Value;
                    newRow["dept_id"] = dgvDetails.Rows[i].Cells["dept_id"].Value;
                    newRow["department_name"] = dgvDetails.Rows[i].Cells["department_name"].Value;
                    newRow["mo_id"] = dgvDetails.Rows[i].Cells["mo_id"].Value;
                    newRow["goods_id"] = dgvDetails.Rows[i].Cells["goods_id"].Value;
                    newRow["goods_name"] = dgvDetails.Rows[i].Cells["goods_name"].Value;
                    newRow["package_num"] = dgvDetails.Rows[i].Cells["package_num"].Value;
                    newRow["t_ir_qty"] = dgvDetails.Rows[i].Cells["t_ir_qty"].Value;
                    newRow["sec_qty"] = dgvDetails.Rows[i].Cells["sec_qty"].Value;
                    newRow["op_price"] = dgvDetails.Rows[i].Cells["op_price"].Value;
                    newRow["op_color"] = dgvDetails.Rows[i].Cells["op_color"].Value;
                    newRow["delivery_date"] = dgvDetails.Rows[i].Cells["delivery_date"].Value;
                    newRow["remark"] = dgvDetails.Rows[i].Cells["remark"].Value;
                    newRow["color_effect"] = dgvDetails.Rows[i].Cells["color_effect"].Value;                    
                    newRow["picture_name"] = dgvDetails.Rows[i].Cells["picture_name"].Value;
                    dtReport.Rows.Add(newRow);
                }
            }
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先選擇要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xrOut_return oRepot = new xrOut_return() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreviewDialog();
           
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {           
            if(clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.CurrentRow == null)
            {
                return;
            }
            string art_file = dgvDetails.CurrentRow.Cells["picture_name"].Value.ToString();
            if (File.Exists(art_file))
            {
                picArt.Image = Image.FromFile(art_file);
            }
            else
                picArt.Image = null;
        }

        private void frmOut_Process_Return_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConErp =null;
            clsApp = null;
            dtReturn = null;
        }

       


    }
}
