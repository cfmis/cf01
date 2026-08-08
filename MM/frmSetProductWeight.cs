using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraReports.UI;
using cf01.MDL;

namespace cf01.MM
{
    public partial class frmSetProductWeight : Form
    {
        public static string getProductId = "";
        public frmSetProductWeight()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSetProductWeight_Load(object sender, EventArgs e)
        {
            InitData();
            dgvDetails.AutoGenerateColumns = false;
        }

        private void InitData()
        {
            dgvDetails.AutoGenerateColumns = false;
            DataTable dtDep = clsBaseData.loadDep();
            lueDep.Properties.DataSource = dtDep;
            lueDep.Properties.ValueMember = "dep_id";
            lueDep.Properties.DisplayMember = "dep_cdesc";

            lueFindDep.Properties.DataSource = dtDep;
            lueFindDep.Properties.ValueMember = "dep_id";
            lueFindDep.Properties.DisplayMember = "dep_cdesc";
        }

        private void FindData()
        {
            string prd_dep = lueFindDep.EditValue.ToString();
            string prd_item = txtFindItem.Text;
            string strSql = "";
            strSql = "Select a.prd_item,mm.name As goods_cname,mm.do_color" +
                ",a.kg_qty_rate,a.prd_kg_qty_rate,a.pcs_weg,a.mat_item,mm1.name As mat_cdesc" +
                ",Rtrim(a.dep_id) AS dep_id,b.dep_cdesc AS DepName,a.CrUsr,Convert(Varchar(20),a.crtim,120) AS CrTim" +
                ",a.prd_weg,a.waste_weg,a.use_weg" +
                " From bs_product_qty_rate a" +
                " Left join geo_it_goods mm On a.prd_item=mm.id" +
                " Left join geo_it_goods mm1 On a.mat_item=mm1.id" +
                " Left join bs_dep b On a.dep_id=b.dep_id" +
                " Where a.prd_item>=''";
            if (prd_dep == "" && prd_item == "")
            {
                string now_date = System.DateTime.Now.ToString("yyyy/MM/dd");
                strSql += " And a.crtim>='" + now_date + "'";
            }
            if (prd_dep != "")
                strSql += " And a.dep_id='" + prd_dep + "'";
            if (prd_item != "")
                strSql += " And a.prd_item Like '%" + prd_item + "%'";
            strSql += " Order By a.dep_id,a.prd_item";
            DataTable dtDepGoods = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dtDepGoods;
            if (dtDepGoods.Rows.Count == 0)
                MessageBox.Show("沒有找到記錄!");
        }



        

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtFindItem.Focus();
            Save();
        }

        private void Save()
        {
            if (!ValidData())
                return;
            string prd_dep = lueDep.EditValue != null ? lueDep.EditValue.ToString().Trim() : "";
            string prd_item = txtPrdItem.Text;
            string mat_item = txtMatItem.Text;
            decimal prd_weg = txtPrdWeg.Text != "" ? Convert.ToDecimal(txtPrdWeg.Text) : 0;
            decimal waste_weg = txtWasteWeg.Text != "" ? Convert.ToDecimal(txtWasteWeg.Text) : 0;
            decimal use_weg = txtUseWeg.Text != "" ? Convert.ToDecimal(txtUseWeg.Text) : 0;
            decimal kg_qty_rate = txtKgQtyRate.Text != "" ? Convert.ToDecimal(txtKgQtyRate.Text) : 0;
            decimal pcs_weg = txtPcsWeg.Text != "" ? Convert.ToDecimal(txtPcsWeg.Text) : 0;
            string user_id = DBUtility._user_id;
            string now_date = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string strSql = "", strSql1 = "";
            if (!GetGoods(prd_item))
            {
                strSql1 = @" Insert Into bs_product_qty_rate (prd_item,mat_item,dep_id,prd_weg,waste_weg,use_weg" +
                    ",kg_qty_rate,prd_kg_qty_rate,pcs_weg,crusr,crtim )" +
                    " Values ( " +
                    "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'" +
                    ")";
            }

            else
            {
                strSql1 = @" Update bs_product_qty_rate Set " +
                    "mat_item='{1}',dep_id='{2}',prd_weg='{3}',waste_weg='{4}',use_weg='{5}',kg_qty_rate='{6}'" +
                    ",prd_kg_qty_rate='{7}',pcs_weg='{8}',crusr='{9}',crtim='{10}' " +
                    " Where prd_item='{0}'";
            }
            strSql += string.Format(strSql1
                , prd_item,mat_item, prd_dep, prd_weg, waste_weg, use_weg
                , kg_qty_rate, kg_qty_rate, pcs_weg, user_id, now_date
                );
            string result = "";
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
            {
                FindData();
                MessageBox.Show("儲存成功!");
            }
            else
            {
                MessageBox.Show("儲存失敗!");
            }
        }
        private bool ValidData()
        {
            return true;
        }
        private bool GetGoods(string prd_item)
        {
            bool flag = false;
            string strSql = " Select prd_item From bs_product_qty_rate Where prd_item='" + prd_item + "'";
            DataTable dtGoods = clsPublicOfCF01.GetDataTable(strSql);
            if (dtGoods.Rows.Count > 0)
                flag = true;
            return flag;
        }

        private void txtPrdWeg_Leave(object sender, EventArgs e)
        {
            CountUseWeg();
        }
        private void txtWasteWeg_Leave(object sender, EventArgs e)
        {
            CountUseWeg();
        }
        private void CountUseWeg()
        {
            decimal prd_weg = txtPrdWeg.Text != "" ? Convert.ToDecimal(txtPrdWeg.Text) : 0;
            decimal waste_weg = txtWasteWeg.Text != "" ? Convert.ToDecimal(txtWasteWeg.Text) : 0;
            txtUseWeg.Text = (prd_weg + waste_weg).ToString();
            
        }

        private void txtKgQtyRate_Leave(object sender, EventArgs e)
        {
            decimal kg_qty_rate = txtKgQtyRate.Text != "" ? Convert.ToDecimal(txtKgQtyRate.Text) : 0;
            txtPcsWeg.Text = kg_qty_rate != 0 ? Math.Round((1 / kg_qty_rate) * 1000, 4).ToString() : "";
        }

        private void txtPrdItem_Leave(object sender, EventArgs e)
        {
            txtPrdItemCdesc.Text = GetPrdItemCdesc(txtPrdItem.Text);
            
        }
        private void txtMatItem_Leave(object sender, EventArgs e)
        {
            txtMatItemCdesc.Text = GetPrdItemCdesc(txtMatItem.Text);
        }
        private string GetPrdItemCdesc(string prd_item)
        {
            string strSql = " Select name From geo_it_goods Where id='" + prd_item + "'";
            DataTable dtGoods = clsPublicOfCF01.GetDataTable(strSql);
            string goods_cname = "";
            if (dtGoods.Rows.Count > 0)
                goods_cname = dtGoods.Rows[0]["name"].ToString();
            else
                goods_cname = "";
            return goods_cname;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvDetails.CurrentRow;
            if (currentRow != null)
            {
                // 例如获取某一列的值
                lueDep.EditValue = currentRow.Cells["colDepId"].Value.ToString();
                txtPrdItem.Text = currentRow.Cells["colProductId"].Value.ToString();
                txtPrdItemCdesc.Text = currentRow.Cells["colProductName"].Value.ToString();
                txtMatItem.Text = currentRow.Cells["colMaterialId"].Value.ToString();
                txtMatItemCdesc.Text = currentRow.Cells["colMaterialCdesc"].Value.ToString();
                txtPrdWeg.Text = currentRow.Cells["colPrd_weg"].Value.ToString();
                txtKgQtyRate.Text = currentRow.Cells["colKgQtyRate"].Value.ToString();
                txtWasteWeg.Text = currentRow.Cells["colWaste_weg"].Value.ToString();
                txtUseWeg.Text = currentRow.Cells["colUse_weg"].Value.ToString();
                //txtStdQty.Text = currentRow.Cells["colProductWeight"].Value.ToString();
                txtPcsWeg.Text = currentRow.Cells["colPcsG"].Value.ToString();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPrdItem.Text = "";
            txtPrdItemCdesc.Text = "";
            txtMatItem.Text = "";
            txtMatItemCdesc.Text = "1";
            txtPrdWeg.Text = "";
            txtWasteWeg.Text = "";
            txtUseWeg.Text = "";
            txtKgQtyRate.Text = "";
            txtPcsWeg.Text = "";
            txtPrdItem.Focus();
        }
    }
}
