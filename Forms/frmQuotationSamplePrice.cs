using cf01.CLS;
using cf01.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmQuotationSamplePrice : Form
    {
        public DataTable dtFind = new DataTable();
        public decimal usd_ex_fty = 0; 
        public decimal moq_pcs = 0; 
        private clsAppPublic clsApp = new clsAppPublic();
        mdlQuotationSample mdl= new mdlQuotationSample();

        public frmQuotationSamplePrice(mdlQuotationSample md)
        {
            InitializeComponent();
            mdl = md;
            //clsApp.Initialize_find_value("frmQuotationSamplePrice", pnlFindData.Controls);
            InitFindData(mdl);
        }

        private void frmQuotationSamplePrice_Load(object sender, EventArgs e)
        {
            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }
            }
            for (int i = 0; i < dgvDetails.ColumnCount; i++)
            {
                dgvDetails.Columns[i].SortMode= System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件            
            if (clsApp.set_find_Value("frmQuotationSamplePrice", pnlFindData.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {           
            txtSeason.Text = "";
            txtPlm_code.Text = "";
            txtCf_code.Text = "";
            txtMaterial.Text = "";
            txtSize.Text = "";
            txtMacys_color_code.Text = "";
            txtMo_id.Text = "";
            txtCf_color_code.Text = "";
            txtSales_group.Text = "";          
        }

        private void btnSearchByParam_Click(object sender, EventArgs e)
        {
            btnSearchByParam.Focus();
            FindData();
            dgvDetails.DataSource = dtFind;            
            if (dtFind.Rows.Count == 0)            
            {
                MessageBox.Show("未查詢到數據，請重新輸入條件查詢數據!", "提示信息");
            }
        }
        private void FindData()
        {           
            mdl.season = txtSeason.Text;
            mdl.plm_code = txtPlm_code.Text;
            mdl.cf_code = txtCf_code.Text;
            mdl.material = txtMaterial.Text;
            mdl.size = txtSize.Text;
            mdl.macys_color_code = txtMacys_color_code.Text;
            mdl.mo_id = txtMo_id.Text;
            mdl.cf_color_code = txtCf_color_code.Text;
            mdl.create_by = txtSales_group.Text;          
            dtFind = clsQuotationSample.FindBasePriceByMdl(mdl);
        }
        private void InitFindData(mdlQuotationSample mdl)
        {          
            txtSeason.Text = mdl.season;
            txtPlm_code.Text = mdl.plm_code;
            txtCf_code.Text = mdl.cf_code;
            txtMaterial.Text =mdl.material;
            txtSize.Text = mdl.size;
            txtMacys_color_code.Text = mdl.macys_color_code;
            txtMo_id.Text = mdl.mo_id;
            txtCf_color_code.Text = mdl.cf_color_code;
            txtSales_group.Text = "V";
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                 e.RowBounds.Location.Y,
                 dgvDetails.RowHeadersWidth - 4,
                 e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //當前行背景色,用表格本身原來SelectionMode=FullRowSelect雖可以實現,但無法點取單元格
            //clsQuotation.SetGridViewHighLight(dgvDetails, e);

            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {
                if (grd.Rows[e.RowIndex].Cells["pending"].Value.ToString() == "")
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                }
                else
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkMagenta;//紫色字體
                    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                }
                ////備註字段不顯示刪除線
                //grd.Rows[e.RowIndex].Cells["remark"].Style.ForeColor = Color.Black;
                //grd.Rows[e.RowIndex].Cells["remark"].Style.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular); 
            }
            if (grd.Rows[e.RowIndex].Cells["special_price"].Value.ToString() == "True")
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void txtSales_group_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BTNPRICE_Click(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                return;
            }
            DataRow[] aryRows = dtFind.Select("flag_select=true");
            dtFind.Select();
            if (aryRows.Length == 0)
            {
                MessageBox.Show("請選擇要添加的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (aryRows.Length>1)
            {
                MessageBox.Show("注意一次只允許選取一條記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            float usdExFty = clsApp.Return_Float_Value(aryRows[0]["usd_ex_fty"].ToString());                  
            string unit = aryRows[0]["price_unit"].ToString();
            usd_ex_fty = Math.Round(decimal.Parse((usdExFty / GetUnitRate(unit)).ToString()), 3);            
            float moq = clsApp.Return_Float_Value(aryRows[0]["moq"].ToString());
            unit = aryRows[0]["moq_unit"].ToString();
            moq_pcs = Math.Round(decimal.Parse((moq * GetUnitRate(unit)).ToString()),0);
            this.DialogResult = DialogResult.Yes;//標記有單價更改,并退出當前窗口
        }

        private int GetUnitRate(string unit)
        {
            int rate = 0;
            switch (unit)
            {
                case "SET":
                    rate = 1;
                    break;
                case "PCS":
                    rate = 1;
                    break;
                case "GRS":
                    rate = 144;
                    break;
                case "DZ":
                    rate = 12;
                    break;
                case "K":
                    rate = 1000;
                    break;
                case "H":
                    rate = 100;
                    break;
                default:
                    rate = 1;
                    break;
            }
            return rate;
        }
    }
}
