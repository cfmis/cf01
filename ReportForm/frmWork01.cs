using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using Microsoft.Reporting.WinForms;
using BarcodeLib;
using System.IO;

namespace cf01.ReportForm
{
    public partial class frmWork01 : Form
    {
        public frmWork01()
        {
            InitializeComponent();
        }
        DataTable dt1,pdt;
        string strReportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
        string fileName;
        
        private void txtDep_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).SelectionLength > 0) return;  //  有选中的字符
            if (((TextBox)sender).Text.Length >= ((TextBox)sender).MaxLength)
            {
                SelectNextControl((Control)sender, true, true, true, true);

                ((TextBox)sender).SelectAll();
            }

        }

        private void txtMo_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).SelectionLength > 0) return;  //  有选中的字符
            if (((TextBox)sender).Text.Length >= ((TextBox)sender).MaxLength)
            {
                SelectNextControl((Control)sender, true, true, true, true);

                ((TextBox)sender).SelectAll();
            }
        }

        private void txtMo_Leave(object sender, EventArgs e)
        {
            if (txtMo.Text != "" && txtDep.Text != "")
            {
                clsCommonUse c = new clsCommonUse();
                dt1 = c.getDataProcedure("z_work01",
                    new object[] { txtDep.Text,txtMo.Text });
                dgvDetails.DataSource = dt1;
            }
            /*
            decimal i;
            i = 0;
            int j;
            j=(int)i;
            */
        }
        private void BindDataGridView()
        {
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add("wp_id", "負責部門");
            dgvDetails.Columns["wp_id"].DataPropertyName = "wp_id";
            dgvDetails.Columns["wp_id"].Width = 60;
            dgvDetails.Columns.Add("mo_id", "制單編號");
            dgvDetails.Columns["mo_id"].DataPropertyName = "mo_id";
            dgvDetails.Columns["mo_id"].Width = 80;
            dgvDetails.Columns.Add("sequence_id", "序號");
            dgvDetails.Columns["sequence_id"].DataPropertyName = "sequence_id";
            dgvDetails.Columns["sequence_id"].Width = 60;
            dgvDetails.Columns.Add("goods_id", "物料編號");
            dgvDetails.Columns["goods_id"].DataPropertyName = "goods_id";
            dgvDetails.Columns["goods_id"].Width = 180;
            dgvDetails.Columns.Add("goods_name", "物料描述");
            dgvDetails.Columns["goods_name"].DataPropertyName = "goods_name";
            dgvDetails.Columns["goods_name"].Width = 240;
            dgvDetails.Columns.Add("prod_qty", "生產數量");
            dgvDetails.Columns["prod_qty"].DataPropertyName = "prod_qty";
            dgvDetails.Columns["prod_qty"].Width = 80;
            dgvDetails.Columns.Add("goods_unit", "數量單位");
            dgvDetails.Columns["goods_unit"].DataPropertyName = "goods_unit";
            dgvDetails.Columns["goods_unit"].Width = 60;
        }

        private void frmWork01_Load(object sender, EventArgs e)
        {
            
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            fileName = strReportPath + @"\Reports\" + "rdlWork01.rdlc";
            this.reportViewer1.LocalReport.ReportPath = fileName;

            //向報表傳遞多個參數

            List<ReportParameter> parameterList = new List<ReportParameter>();
            parameterList.Add(new ReportParameter("content", "AAA"));
            parameterList.Add(new ReportParameter("rptName", "BBB"));
            this.reportViewer1.LocalReport.SetParameters(parameterList);

            //显示报表
            this.reportViewer1.RefreshReport();
            
            BindDataGridView();
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            /*
            Reports.crtWork01 r = new Reports.crtWork01();
            //r.SetDataSource(ds.Tables["st01"]);
            r.SetDataSource(dt1);
            frmPrint p = new frmPrint();
            p.crystalReportViewer1.ReportSource = r;
            p.ShowDialog();
             */
            
            Reports.crtWork01 r = new Reports.crtWork01();
            r.SetDataSource(dt1);
            r.SetDataSource(dt1);
            this.crystalReportViewer1.ReportSource = r;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //v1 = dgvDetails.Rows[RowIndex].Cells[0].Value.ToString();
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有找到符合條件的記錄", "系統信息", MessageBoxButtons.OK);
                return;
            }
            int a = dgvDetails.CurrentRow.Index;
            string str = dgvDetails.Rows[a].Cells["sequence_id"].Value.ToString();
            this.GetNewDataTable(dt1,str);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", pdt));
            //向報表傳遞單個參數
            ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            //显示报表
            this.reportViewer1.RefreshReport();



             
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Visible = false;
            this.crystalReportViewer1.Visible = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Visible = true;
            this.crystalReportViewer1.Visible = false;
        }

        public void GetNewDataTable(DataTable dt, string condition)
        {

            //DataTable newdt = new DataTable();
            /*
            try
            {
                pdt = dt.Clone();
                DataRow[] dr = dt.Select(condition);
                for (int i = 0; i < dr.Length; i++)
                {
                    pdt.ImportRow((DataRow)dr[i]);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            */

            pdt = dt.Clone();
            DataRow drq = pdt.NewRow();
            drq.ItemArray = dt.Rows[dgvDetails.CurrentRow.Index].ItemArray;//这是加入的是第一行
            pdt.Rows.Add(drq);
            

            /*
            pdt = dt.Clone();
            pdt.Rows.Clear();
            pdt.ImportRow(dt.Rows[dgvDetails.CurrentRow.Index]);//这是加入的是第一行
            */
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.tabControl1.TabIndex==0)
                fileName = strReportPath + @"\Reports\" + "rdlWork01.rdlc";
            else
                fileName = strReportPath + @"\Reports\" + "rd3.rdlc";
            this.reportViewer1.LocalReport.ReportPath =fileName;
            this.reportViewer1.RefreshReport();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.TabIndex == 0)
                fileName = strReportPath + @"\Reports\" + "rdlWork01.rdlc";
            else
                fileName = strReportPath + @"\Reports\" + "rd3.rdlc";
            this.reportViewer1.LocalReport.ReportPath = fileName;
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("c:\\3\\1.pdf");
            //string filename = FileInfo.DirectoryName;// openFileDialog1.FileName;
            //string path1 = System.IO.Path.GetDirectoryName(openFileDialog1.FileName) + @"\";
            //string fileExtension = DirectoryInfo.GetFiles();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开";
            ofd.Filter="PDF|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }

            //textBox2.Text = fileExtension;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("c:\\3\\1.pdf");
            System.Diagnostics.Process.Start(textBox2.Text);
        }
    }
}