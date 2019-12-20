using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using System.IO;
using System.Threading;
using cf01.ModuleClass;

namespace cf01.ReportForm
{
    public partial class frmShowSt : Form
    {
        private DataTable dtSt = new DataTable();
        private DataTable dt_artwork = new DataTable();        
        public frmShowSt()
        {
            InitializeComponent();
            NextControl oFocus = new NextControl(this, "1");
            oFocus.EnterToTab();
        }

        private void frmShowSt_Load(object sender, EventArgs e)
        {
            txtDept1.Text = "805";
            txtDept2.Text = "805";
            //BindDataGridView("1");
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {            
            this.txtDept2.Focus();
            if (txtDept1.Text == "" && txtDept2.Text == "")
            {
                MessageBox.Show("部門不可以空!", "系統信息", MessageBoxButtons.OK);
                return;
            }
            string date1, date2,goods_id,material, product_type,art,size,clr;
            material = txtMt.Text;            
            material = material.PadRight(2,'_');                
            product_type = txtPro.Text;
            //product_type = product_type.Replace(" ", "_");
            product_type = product_type.PadRight(2, '_');//右邊填充
            art = txtArtwork.Text;            
            art = art.PadRight(7, '_');
            size = txtSize.Text;           
            size = size.PadRight(3, '_');
            clr = txtColor.Text;            
            clr = clr.PadRight(4, '_');
            goods_id = material + product_type + art + size + clr;
            if (goods_id == "__________________")
                goods_id = "";   
            string sqlStr = "";
            sqlStr = "Select a.location_id As loc_id,a.mo_id,a.goods_id,b.name As goods_name,a.lot_no,convert(int,a.qty) As qty,convert(decimal(20,2),a.sec_qty) As sec_qty" +
                ",a.update_date As in_date,dbo.Fn_get_picture_name('0000',a.goods_id ,'in') as picture_name,dbo.Fn_z_get_wh_location(a.goods_id,a.location_id) as carton_code " +
                " From dbo.st_details_lot a with(nolock)" +
                " Left Outer Join dbo.it_goods b with(nolock) On a.within_code=b.within_code And a.goods_id=b.id";
            sqlStr += " Where a.within_code = '0000'";

            if (txtDept1.Text != "")
                sqlStr += " And a.location_id >= " + "'" + txtDept1.Text + "'";
            if (txtDept2.Text != "")
                sqlStr += " And a.location_id <= " + "'" + txtDept2.Text + "'";                     
            if (txtMo_id1.Text != "")
                sqlStr += " And a.mo_id >= " + "'" + txtMo_id1.Text + "'";
            if (txtMo_id2.Text != "")
                sqlStr += " And a.mo_id <= " + "'" + txtMo_id2.Text + "'";
            if (goods_id != "")
            {
                sqlStr += " And a.goods_id Like " + "'" + goods_id + "'";
            }           
            if (txtLot_no1.Text != "")
                sqlStr += " And a.lot_no >= " + "'" + txtLot_no1.Text + "'";
            if (txtLot_no2.Text != "")
                sqlStr += " And a.lot_no <= " + "'" + txtLot_no2.Text + "'";
            if (txtIn_date1.Text != "")
            {
                date1 =Convert.ToDateTime(txtIn_date1.Text).ToString("yyyy/MM/dd");
                sqlStr += " And a.update_date >= " + "'" + date1 + "'";
            }
            if (txtIn_date2.Text != "")
            {
                date2 = txtIn_date2.DateTime.AddDays(1).ToString("yyyy/MM/dd");
                sqlStr += " And a.update_date < " + "'" + date2 + "'";
            }
            if (txtColor.Text == "")
            {
                if (radioGroup1.SelectedIndex == 1)//電鍍
                    sqlStr += @" And a.goods_id NOT LIKE '%NEP0'";
                if (radioGroup1.SelectedIndex == 2)//克胚
                    sqlStr += @" And a.goods_id LIKE '%NEP0'";
            }
            sqlStr += " And a.sec_qty > 0  Order by a.location_id,a.goods_id,a.update_date";

            clsPublicOfGEO objgeo = new clsPublicOfGEO();

            //=============================================================
            cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
            new Thread((ThreadStart)delegate{
                wForm.TopMost = true;
                wForm.ShowDialog();}).Start();
            //----------------------------------
            dtSt = objgeo.GetDataTable(sqlStr);
            dgvDetails.DataSource = dtSt;
            this.gridView1.RowHeight = 25;
            gridControl1.DataSource = dtSt;
            if (gridView1.RowCount > 0)
            {
                txtRecords.Text = dtSt.Rows.Count.ToString();
                string strImage_path;
                for (int i = 0; i < dtSt.Rows.Count; i++)
                {
                    strImage_path = dtSt.Rows[i]["picture_name"].ToString();
                    if (!File.Exists(strImage_path))
                    {
                        dtSt.Rows[i]["picture_name"] = "";
                    }
                }               
            }
            //----------------------------------
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            //=============================================================
            
            if (gridView1.RowCount == 0)
            {
                txtRecords.Text = "";
                MessageBox.Show("沒有找到符合條件的記錄", "系統信息", MessageBoxButtons.OK);
                return;
            }
        }

        

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.Text = txtDept1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void txtLot_no1_Leave(object sender, EventArgs e)
        {
            txtLot_no2.Text = txtLot_no1.Text;
        }

        private void BindDataGridView(string dvgType)
        {
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add("loc_id", "倉庫號");
            dgvDetails.Columns["loc_id"].DataPropertyName = "loc_id";
            dgvDetails.Columns.Add("mo_id", "制單編號");
            dgvDetails.Columns["mo_id"].DataPropertyName = "mo_id";
            dgvDetails.Columns.Add("goods_id", "物料編號");
            dgvDetails.Columns["goods_id"].DataPropertyName = "goods_id";
            dgvDetails.Columns.Add("goods_name", "物料描述");
            dgvDetails.Columns["goods_name"].DataPropertyName = "goods_name";
            dgvDetails.Columns["goods_name"].Width = 240;
            dgvDetails.Columns.Add("lot_no", "批號");
            dgvDetails.Columns["lot_no"].DataPropertyName = "lot_no";
            dgvDetails.Columns.Add("qty", "倉存數量");
            dgvDetails.Columns["qty"].DataPropertyName = "qty";
            dgvDetails.Columns.Add("weg", "倉存重量");
            dgvDetails.Columns["weg"].DataPropertyName = "weg";
            dgvDetails.Columns.Add("in_dat", "入倉日期");
            dgvDetails.Columns["in_dat"].DataPropertyName = "in_dat";

        }

        private void txtIn_date1_Leave(object sender, EventArgs e)
        {
            txtIn_date2.EditValue = txtIn_date1.EditValue;
        }

        private void btnArtWork_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DialogResult result;
                if (gridView1.RowCount >= 1500)
                {
                    result = MessageBox.Show("數據太多有可能匯出不成功!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Export To Excel";
                saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
                result = saveFileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    dt_artwork = dtSt;
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = dt_artwork.Rows.Count;

                    //添加圖樣字段
                    if (!dt_artwork.Columns.Contains("artwork"))
                    {
                        dt_artwork.Columns.Add("artwork", System.Type.GetType("System.Byte[]"));
                    }
                    string strImage_path = "";
                    this.gridView1.RowHeight = 65;
                    for (int i = 0; i < dt_artwork.Rows.Count; i++)
                    {
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        strImage_path = dt_artwork.Rows[i]["picture_name"].ToString();
                        if (strImage_path != "")
                            dt_artwork.Rows[i]["artwork"] = getImageByte(strImage_path);
                        else
                            dt_artwork.Rows[i]["artwork"] = null;
                    }
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;

                    gridControl1.DataSource = dt_artwork;
                    gridControl1.ExportToXls(saveFileDialog.FileName);
                    MessageBox.Show("匯出Excel成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
            }
        }


        //返回圖片字節流byte[]
        private byte[] getImageByte(string imagePath)
        {
            //FileStream files = new FileStream(imagePath, FileMode.Open);
            //设置文件共享方式为读写
            FileStream files = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] imgByte = new byte[files.Length];
            files.Read(imgByte, 0, imgByte.Length);
            files.Close();
            return imgByte;
        }

        private void btnExcel1_Click(object sender, EventArgs e)
        {
            ExpToExcel expxls = new ExpToExcel();                  
            expxls.ExportExcel(dgvDetails);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //以下代碼放在form Load中
            //this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //this.reportViewer1.LocalReport.EnableExternalImages = true;
            //this.reportViewer1.RefreshReport();

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dtSt));
            this.reportViewer1.RefreshReport();
        }

        private void txtGoods_id_Leave(object sender, EventArgs e)
        {
            if (txtGoods_id.Text != "")
            {
                string goods_id = txtGoods_id.Text;
                if (goods_id.Length == 18)
                {
                    txtMt.Text = goods_id.Substring(0, 2);
                    txtPro.Text = goods_id.Substring(2, 2);
                    txtArtwork.Text = goods_id.Substring(4, 7);
                    txtSize.Text = goods_id.Substring(11, 3);
                    txtColor.Text = goods_id.Substring(14, 4);
                }
            }
        }    


    }
}
