using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmPlateSelect : Form
    {
        DataSet ds = new DataSet();
        DataTable dtReport = new DataTable();
        DataTable dtDept = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        public string strUserid = DBUtility._user_id;

        public frmPlateSelect()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);
        }

        private void frmPlateSelect_Load(object sender, EventArgs e)
        {
            string strSQL =@"SELECT int9loc as id,int9loc+' ['+rtrim(int9desc)+']' as cdesc From int09 ORDER BY int9loc";
            dtDept = clsPublicOfPad.GetDataTable(strSQL);
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            txtOut_detp1.Properties.DataSource = dtDept;
            txtOut_detp1.Properties.ValueMember = "id";
            txtOut_detp1.Properties.DisplayMember = "cdesc";

            if (string.IsNullOrEmpty(txtDat1.Text))
            {
                txtDat1.EditValue = DateTime.Now;
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now;
            }            
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
            txtOut_detp1.Focus();
            string out_dept1 = "";
            if (string.IsNullOrEmpty(txtOut_detp1.Text))
            {
                out_dept1 = "";
            }
            else
            {
                out_dept1 = txtOut_detp1.EditValue.ToString();
            }
                       
            if (txtDat1.Text == "" && txtDat2.Text == "" && out_dept1 == "" )
            {
                MessageBox.Show("查詢條件條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOut_detp1.Focus();
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
            {                   
                    new SqlParameter("@dep1", out_dept1),
                    new SqlParameter("@date1", txtDat1.Text),
                    new SqlParameter("@date2",  txtDat2.Text)
            };
            
            ds = clsPublicOfPad.ExecuteProcedureReturnDataSet("usp_rpt_select", paras, null);
            dtReport.Clear();
            dtReport = ds.Tables[0].Copy();//ds.Tables[0]是匯總表,ds.Tables[1]是明細表
            dgvDetails.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
            {                
                //禁止列排序
                for (int i = 0; i < this.dgvDetails.Columns.Count; i++)
                {
                    this.dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;                    
                }
                dgvDetails2.DataSource = ds.Tables[1];
            }
            else
            {
                dtReport.Clear();          
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          

        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
            //加載報表                
            cf01.Reports.xrPlateSelect oRepot = new cf01.Reports.xrPlateSelect() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOut_detp1_Click(object sender, EventArgs e)
        {
            txtOut_detp1.SelectAll();
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {           
            txtDat2.EditValue = txtDat1.EditValue;
        }
  

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }     
            Excel(dgvDetails);
        }

        private void Print() //通用的打印方法
        {
            if (dgvDetails.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(this.dgvDetails);
            }
        }

        private void Excel(DataGridView pDGV) //匯出EXCEL
        {
            if (pDGV.RowCount > 0)
            {             
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(pDGV);
            }
        }

        private void BTNEXCEL_Details_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Excel(dgvDetails2);
        }
    }
}
