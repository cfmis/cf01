using cf01.CLS;
using cf01.Reports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmMouldProcess : Form
    {
        clsPublicOfGEO clsGeo = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtReport = new DataTable();
       
        public frmMouldProcess()
        {
            InitializeComponent();
            try
            {               
                clsApp.Initialize_find_value(this.Name, panel1.Controls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if(txtid1.Text.Trim()=="" && txtid2.Text.Trim()==""&& 
                txtmd1.Text.Trim()=="" && txtmd2.Text.Trim()==""&&
                txtmould_no1.Text.Trim()=="" && txtmould_no2.Text.Trim()==""&&
                txtbill_date1.Text=="" && txtbill_date2.Text == "" )
            {
                MessageBox.Show("查詢條件不可為空!", "提示信息");
                return;
            }
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id1",txtid1.Text),
                new SqlParameter("@id2",txtid2.Text),
                new SqlParameter("@mould_notice_id1",txtmd1.Text),//做模通知書
                new SqlParameter("@mould_notice_id2",txtmd2.Text),
                new SqlParameter("@mould_no1",txtmould_no1.Text),//畫稿編號
                new SqlParameter("@mould_no2",txtmould_no2.Text),
                new SqlParameter("@bill_date1",txtbill_date1.EditValue.ToString()),
                new SqlParameter("@bill_date2",txtbill_date2.EditValue.ToString())
            };
            dtReport = clsGeo.ExecuteProcedureReturnTable("z_rpt_mould_precess", paras);
            dgv1.DataSource = dtReport;
            if (dtReport.Rows.Count > 0)
            {
                dgv1.DataSource = dtReport;
                for (int i = 0; i < dgv1.ColumnCount; i++)
                {
                    dgv1.Columns[i].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                pic_artwork.Image = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
            //dtReport.DefaultView.Sort = "id,sequence_id ASC";
            //dtReport = dtReport.DefaultView.ToTable();            


        }

        private void txtid1_Leave(object sender, EventArgs e)
        {
            txtid2.Text = txtid1.Text;
        }

        private void txtmd1_Leave(object sender, EventArgs e)
        {
            txtmd2.Text = txtmd1.Text;
        }

        private void txtmould_no1_Leave(object sender, EventArgs e)
        {
            txtmould_no2.Text = txtmould_no1.Text;
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出需匯出之數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xrMouldProcess xr = new xrMouldProcess(DBUtility._user_id) { DataSource = dtReport };
            xr.CreateDocument();
            xr.PrintingSystem.ShowMarginsWarning = false;
            xr.ShowPreview();
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                return;
            }
            if (dgv1.RowCount > 0)
            {
               int row_index = dgv1.CurrentCell.RowIndex;//當前焦點所在行
                if (row_index < 0)
                {
                    return;
                }
                string strArtwork = dtReport.Rows[row_index]["picture_name"].ToString();                
                if (!string.IsNullOrEmpty(strArtwork))
                    pic_artwork.Image = File.Exists(strArtwork) ? Image.FromFile(strArtwork) : null;
                else
                    pic_artwork.Image = null;
            }
            
        }

        private void txtbill_date1_Leave(object sender, EventArgs e)
        {
            txtbill_date2.EditValue = txtbill_date1.EditValue;
        }
    }
}
