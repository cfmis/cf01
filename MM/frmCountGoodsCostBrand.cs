using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.MDL;
using cf01.CLS;

namespace cf01.MM
{
    public partial class frmCountGoodsCostBrand : Form
    {
        public frmCountGoodsCostBrand()
        {
            InitializeComponent();
        }
        private void LoadBrandRate()
        {
            DataTable dtRate = clsBaseData.LoadProcessType("CP_PROFIT1", "");
            gcGoodsFactoryRate.DataSource = dtRate;
        }

        private void frmCountGoodsCostBrand_Load(object sender, EventArgs e)
        {
            LoadBrandRate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string prdDep = "CP_PROFIT1";
            string processID = txtBrand.Text;
            decimal use_weg = Convert.ToDecimal(txtFactAddWasteRate.Text);
            string result = clsBaseData.UpdateProcessType(prdDep, processID, use_weg);
            if (result == "")
            {
                MessageBox.Show("更新記錄成功!");
                LoadBrandRate();
            }else
                MessageBox.Show("更新記錄失敗!");
        }

        private void gvGoodsFactoryRate_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
        }

        private void gvGoodsFactoryRate_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gvGoodsFactoryRate.RowCount > 0)
            {
                DataRow Row = gvGoodsFactoryRate.GetFocusedDataRow();
                txtBrand.Text = Row["process_id"].ToString();
                txtFactAddWasteRate.Text = Row["use_weg"].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string prdDep = "CP_PROFIT1";
            string processID = txtBrand.Text;
            string result = clsBaseData.DeleteProcessType(prdDep, processID);
            if (result == "")
            {
                MessageBox.Show("刪除記錄成功!");
                LoadBrandRate();
                //txtBrand.Text = "";
                //txtFactAddWasteRate.Text = "";
            }
            else
                MessageBox.Show("刪除記錄失敗!");
        }
    }
}
