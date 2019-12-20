using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.Reports;
using cf01.Forms;
using System.Threading;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmShadingColor : Form
    {
        DataTable dt = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        clsPublicOfGEO clsERP2 = new clsPublicOfGEO();
        public frmShadingColor()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);            
        }

        private void frmShadingColor_Load(object sender, EventArgs e)
        {
            //string sql = @"SELECT id,id+'['+name+']' as cdesc FROM cd_department WHERE within_code='0000' and isnull(location,'')<>'' and state not in ('2','V') order by id";
            //DataTable dtDept = clsERP2.GetDataTable(sql);
            //DataRow dr0 = dtDept.NewRow(); //插一空行
            //dtDept.Rows.InsertAt(dr0, 0);
            //txtDept1.Properties.DataSource = dtDept;
            //txtDept1.Properties.ValueMember = "id";
            //txtDept1.Properties.DisplayMember = "cdesc";

            //txtDept2.Properties.DataSource = dtDept;
            //txtDept2.Properties.ValueMember = "id";
            //txtDept2.Properties.DisplayMember = "cdesc";     
            this.ActiveControl = txtDat2;
            txtDat2.Focus();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            txtDept1.EditValue = "";
            txtDept2.EditValue = "";
            txtDat1.EditValue = "";
            txtDat2.EditValue = "";
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (txtDept1.Text == "" && txtDept2.Text == "" && txtDat1.Text == "" && txtDat2.Text == "")
            {
                MessageBox.Show("查找條件不可為空!", "提示信息");
                return;
            }
            
            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            Find_data();     
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的數據!", "提示信息");
            }
        }

        private void Find_data()
        {           
            string sql =
            @"SELECT A.mo_id,B.goods_id,C.name as goods_name,B.wp_id,D.name as dept_name,B.next_wp_id,E.name as dept_next_name,B.shading_color_person,B.shading_color_time
	        FROM jo_bill_mostly A with(nolock) 
	        INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code and A.id=B.id and A.ver=B.ver 
	        INNER JOIN it_goods C with(nolock) on B.within_code=C.within_code and B.goods_id=C.id 
	        LEFT JOIN cd_department D ON B.within_code=D.within_code and B.wp_id=D.id 
	        LEFT JOIN cd_department E ON B.within_code=E.within_code and B.next_wp_id=E.id 
	        WHERE A.within_code='0000' and B.shading_color_state='1' ";
            if (txtDept1.Text != "")
                sql += " and B.wp_id>='" + txtDept1.EditValue.ToString() + "'";
            if (txtDept2.Text != "")
                sql += " and B.wp_id<='" + txtDept2.EditValue.ToString() + "'";
            if (txtDat1.Text != "")
                sql += " and B.shading_color_time>='" + txtDat1.Text + "'";
            if (txtDat2.Text != "")
                sql += " and B.shading_color_time<='" + txtDat2.Text + "'" + " and B.next_wp_id <>'702'";
            dt = clsERP2.GetDataTable(sql);
            dt.DefaultView.Sort = "shading_color_time";
           
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                string str = "501,502,503,504,505,506,507,508,509,E02,";
                if (str.Contains(dt.Rows[i]["wp_id"].ToString().Trim()))  // || str.Contains(dt.Rows[i]["next_wp_id"].ToString().Trim()))
                    continue;
                else                   
                    dt.Rows.RemoveAt(i);                    
            }           
            dgvDetails.DataSource = dt;
            
            
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {           
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有要列印的數據!", "提示信息");
                return;
            }
            using (xrShadingColor myReport1 = new xrShadingColor() { DataSource = dt })
            {
                myReport1.CreateDocument();
                myReport1.PrintingSystem.ShowMarginsWarning = false;
                myReport1.ShowPreviewDialog();
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有要匯出的數據!", "提示信息");
                return;
            }
            ExpToExcel objXls = new ExpToExcel();
            objXls.ExportExcel(dgvDetails);
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        
    }
}
