using System;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.Forms;
using System.Threading;
using System.Data;

namespace cf01.ReportForm
{
    public partial class frmOrderFareCharge : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        System.Data.DataTable dtReport = new System.Data.DataTable();
      
        public frmOrderFareCharge()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmOrderFareCharge_Load(object sender, EventArgs e)
        {
            DataTable dtFare = clsBaseData.GetFareInfo();
            DataRow dr0 = dtFare.NewRow(); //插一空行
            dtFare.Rows.InsertAt(dr0, 0);
            lueFare_id.Properties.DataSource = dtFare;
            lueFare_id.Properties.ValueMember = "id";
            lueFare_id.Properties.DisplayMember = "cdesc";

            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd").Substring(0,10); 
            }
            txtDat1.EditValue = txtDat2.Text.Substring(0,4)+"/01/01";
            this.ActiveControl = txtDat2;  
            txtDat2.Focus();

           
        }

        private void frmOrderFareCharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtReport.Dispose();           
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        { 
            if (txtDat1.Text == "" && txtDat2.Text == "" && txtBrand_id1.Text=="" && txtBrand_id2.Text=="" && txtIt_customer.Text=="" && txtSalesGroup.Text=="" && lueFare_id.Text=="" )
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new SqlParameter("@date_s",txtDat1.Text),
                new SqlParameter("@date_e",txtDat2.Text),
                new SqlParameter("@customer_id",txtIt_customer.Text),
                new SqlParameter("@sales_group",txtSalesGroup.Text),
                new SqlParameter("@brand_id_s",txtBrand_id1.Text),
                new SqlParameter("@brand_id_e",txtBrand_id2.Text),
                new SqlParameter("@fare_id",lueFare_id.EditValue.ToString())
            };
            dtReport = clsPublicOfCF01.ExecuteProcedureReturnTable("p_rpt_so_test_charge", paras); 
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            dgvDetails.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }                     
            }
            else
            {
                dtReport.Clear();               
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }      

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }    

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel objXls = new ExpToExcel();
            objXls.ExportExcel(dgvDetails);            
            objXls = null;
        }     

        
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.Text = txtBrand_id1.Text;
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if(dgvDetails.Rows.Count>0)
            {
                txtIt_customer.Focus();                
                string rowStatus = "";
                string flag_select = "";
                string mo_id="", remark = "";
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    rowStatus = dtReport.Rows[i].RowState.ToString();
                    flag_select = dtReport.Rows[i]["is_test_report"].ToString();
                    mo_id = dtReport.Rows[i]["mo_id"].ToString();
                    remark = dtReport.Rows[i]["remark"].ToString();
                    if (rowStatus == "Modified")
                    {
                        if (flag_select == "True")
                        {
                            clsOrderFareCharge.UpdateMo(mo_id, remark, true);
                        }else
                        {
                            clsOrderFareCharge.UpdateMo(mo_id, remark, false);
                        }
                    }
                }
                dtReport.AcceptChanges();//更新完后完原RowState行的修改狀態. 
                MessageBox.Show("數擾更新成功!", "提示信息");
            }
            else
            {
                MessageBox.Show("請首先查詢出數據!","提示信息");
            }
        }

       
    }
}
