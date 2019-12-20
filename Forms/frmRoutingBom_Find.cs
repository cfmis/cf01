using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmRoutingBom_Find : Form
    {

        private string within_code = DBUtility.within_code;

        private string remote_db = DBUtility.remote_db;
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private bool routing_from_template;
        public frmRoutingBom_Find()
        {
            InitializeComponent();
        }


        private bool findGoodsFromOc()
        {
            bool result = true;

            string strSql = "";
            if (chkPrdType.Checked == false)
            {
                string prd_item = txtPrd_item.Text;
                string dat1 = "", dat2 = "";
                if (mktDat1.Text.Trim() != "/  /")
                    dat1 = mktDat1.Text;
                if (mktDat2.Text.Trim() != "/  /")
                    dat2 = Convert.ToDateTime(mktDat2.Text).AddDays(1).ToString("yyyy/MM/dd");

                strSql = "Select b.goods_id,MAX(c.name) AS goods_name,MAX(c.base_class) AS prd_type,MAX(d.name) AS prd_type_name" +
                    " FROM so_order_manage a " +
                    " INNER JOIN so_order_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver " +
                    " LEFT JOIN it_goods c ON b.within_code=c.within_code AND b.goods_id=c.id " +
                    " LEFT JOIN cd_goods_class d ON c.within_code=d.within_code AND c.base_class=d.id " +
                    "";
                strSql += " Where a.within_code='" + within_code + "'";
                if (dat1 != "" && dat2 != "")
                    strSql += " AND a.create_date>='" + dat1 + "' AND a.create_date<'" + dat2 + "'";
                if (prd_item != "")
                    strSql += " AND b.goods_id='" + prd_item + "'";
                strSql += " Group By b.goods_id";
            }
            else
            {
                strSql = "Select id AS prd_type,name AS prd_type_name" +
                    " FROM cd_goods_class ";
                strSql += " Order By id";
            }
            DataTable dtBom_h = clsConErp.GetDataTable(strSql);
            dgvDetails.DataSource = dtBom_h;
            if (dgvDetails.Rows.Count > 0)
            {
                //if (dgvDetails.Rows.Count == 1)
                //{
                //    showBomTree(0);
                //}
            }
            else
            {
                result = false;

            }

            return result;
        }

        private DataTable LoadRoutingBom(string goods_id)
        {
            string strSql = "";
            strSql = "Select a.goods_id,a.routing_id,b.cdesc AS routing_cdesc,a.prd_sort" +
                " From bs_routing_bom a " +
                " Left Join bs_routing b On a.routing_id=b.id " +
                " Where goods_id='" + goods_id + "'" +
                " Order By a.prd_sort";
            DataTable dtRoutingBom = clsPublicOfCF01.GetDataTable(strSql);
            return dtRoutingBom;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            if (clsValidRule.CheckDateIsEmpty(this.mktDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mktDat2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktDat1.Text) == false || clsValidRule.CheckDateFormat(this.mktDat2.Text) == false)
                {
                    MessageBox.Show("訂單日期格式不正確!");
                    this.mktDat1.Focus();
                    return;
                }
            }

            findData();
        }
        private void findData()
        {

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            bool result;
            //**********************
            result = findGoodsFromOc(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (result == false)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGoodsPriceCount_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            mktDat1.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            mktDat2.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            frmRoutingBom.query_goods_id = "";
            frmRoutingBom.query_prd_type = "";
            frmRoutingBom.query_prd_type_cdesc = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fillValue();
            this.Close();
        }

        private void dgvDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fillValue();
            this.Close();
        }
        private void fillValue()
        {
            if (dgvDetails.Rows.Count > 0)
            {
                if (chkPrdType.Checked == false)
                    frmRoutingBom.query_goods_id = dgvDetails.CurrentRow.Cells["colPrd_item"].Value.ToString();
                else
                {
                    frmRoutingBom.query_prd_type = dgvDetails.CurrentRow.Cells["colPrd_Type"].Value.ToString();
                    frmRoutingBom.query_prd_type_cdesc = dgvDetails.CurrentRow.Cells["colPrd_Type_Cdesc"].Value.ToString();
                }
            }
        }
    }
}
