using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmShippingMark : Form
    {
        DataTable dtDate = new DataTable();
        clsPublicOfGEO clsGEO = new clsPublicOfGEO();
        DataTable dtReport = new DataTable();

        public frmShippingMark()
        {
            InitializeComponent();
            dtReport.Columns.Add(new DataColumn("mo_id", typeof(string)));
            dtReport.Columns.Add(new DataColumn("goods_name", typeof(string)));
            dtReport.Columns.Add(new DataColumn("color", typeof(string)));
            dtReport.Columns.Add(new DataColumn("customer_name", typeof(string)));
            dtReport.Columns.Add(new DataColumn("linkman", typeof(string)));
            dtReport.Columns.Add(new DataColumn("contract_cid", typeof(string)));
            dtReport.Columns.Add(new DataColumn("customer_goods", typeof(string)));
            dtReport.Columns.Add(new DataColumn("customer_color_id", typeof(string)));
            dtReport.Columns.Add(new DataColumn("remark", typeof(string)));
            dtReport.Columns.Add(new DataColumn("picture_name", typeof(string)));
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text != "")
            {
                Load_Data();
            }
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_Data()
        {
            if (txtMo_id.Text == "")
            {
                return;
            }
            string sql =string.Format(
                @"Select A.linkman,B.mo_id,B.contract_cid,B.customer_goods,B.customer_color_id,C.goods_id,C.primary_key,D.name as goods_name,D.color,
                (CASE WHEN E.nickle_free='1' THEN '無叻;' ELSE '' END +
                CASE WHEN E.plumbum_free='1' THEN '無鉛;' ELSE '' END +
                CASE WHEN E.full_inspection_free='1' THEN '全檢;' ELSE '' END +
                CASE WHEN E.keep_ban_free='1' THEN '跟辦;' ELSE '' END +
                CASE WHEN isnull(D.goods_sort,'')='OK' THEN '過驗針機;' ELSE '' END ) AS remark,
                F.name as customer_name,dbo.Fn_get_picture_name(B.within_code,C.goods_id,'OUT') as picture_name
                from so_order_manage A with(nolock)
                INNER JOIN so_order_details B with(nolock) on A.within_code=B.within_code and A.id=B.id and A.ver=B.ver 
                INNER JOIN so_order_bom C with(nolock) on B.within_code=C.within_code and B.id=C.id and B.ver=C.ver AND B.sequence_id =C.upper_sequence
                INNER JOIN it_goods D with(nolock) ON C.within_code=D.within_code and C.goods_id =D.id
                INNER JOIN so_order_special_info E ON B.within_code=E.within_code and B.id=E.id and B.ver=E.ver AND B.sequence_id=E.upper_sequence 
                INNER JOIN it_customer F ON A.within_code=F.within_code and A.it_customer=F.id 
                WHERE A.within_code='0000' and A.state not in ('2','V') and B.mo_id='{0}'
                ORDER BY C.primary_key DESC",txtMo_id.Text );
            dtDate = clsGEO.GetDataTable(sql);
            if (dtDate.Rows.Count > 0)
            {
                cmbGoods_id.Items.Clear();
                for (int i = 0; i < dtDate.Rows.Count; i++)
                {
                    cmbGoods_id.Items.Add(dtDate.Rows[i]["goods_id"].ToString());
                }
                cmbGoods_id.Text = dtDate.Rows[0]["goods_id"].ToString();
                txtMo_id1.Text = dtDate.Rows[0]["mo_id"].ToString();
                txtGoods_name.Text = dtDate.Rows[0]["goods_name"].ToString();
                txtColor.Text = dtDate.Rows[0]["color"].ToString();
                txtCustomer_name.Text = dtDate.Rows[0]["customer_name"].ToString();
                txtLinkman.Text = dtDate.Rows[0]["linkman"].ToString();
                txtContract_cid.Text = dtDate.Rows[0]["contract_cid"].ToString();
                txtcustomer_goods.Text = dtDate.Rows[0]["customer_goods"].ToString();
                txtcustomer_color_id.Text = dtDate.Rows[0]["customer_color_id"].ToString();
                txtRemark.Text = dtDate.Rows[0]["remark"].ToString();
                txtPictrue_name.Text = dtDate.Rows[0]["picture_name"].ToString();

                pictureBox1.Image = null;
                if (txtPictrue_name.Text.Trim() != "")
                {
                    if (File.Exists(txtPictrue_name.Text.Trim()))
                        pictureBox1.Image = Image.FromFile(txtPictrue_name.Text.Trim());
                }
            }
            else
            {
                txtMo_id1.Text = "";
                txtGoods_name.Text = "";
                txtColor.Text = "";
                txtCustomer_name.Text = "";
                txtLinkman.Text = "";
                txtContract_cid.Text = "";
                txtcustomer_goods.Text = "";
                txtcustomer_color_id.Text = "";
                txtRemark.Text = "";
                txtPictrue_name.Text = "";
                pictureBox1.Image = null;
            }
        }

        private void cmbGoods_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbGoods_id.SelectedIndex;
            txtGoods_name.Text = dtDate.Rows[i]["goods_name"].ToString();
            txtPictrue_name.Text = dtDate.Rows[i]["picture_name"].ToString();
            pictureBox1.Image = null;
            if (txtPictrue_name.Text.Trim() != "")
            {
                if (File.Exists(txtPictrue_name.Text.Trim()))
                    pictureBox1.Image = Image.FromFile(txtPictrue_name.Text.Trim());
            }
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print("P");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Print("V");
        }

        private void Print(string pType)
        {
            if (txtMo_id1.Text == "")
            {
                MessageBox.Show("當前數據為空,不可以列印!", "提示信息");
                return;
            }
            dtReport.Clear();
            DataRow dr = dtReport.NewRow();
            dr["mo_id"] = txtMo_id1.Text;
            dr["goods_name"] = txtGoods_name.Text;
            dr["color"] = txtColor.Text;
            dr["customer_name"] = txtCustomer_name.Text;
            dr["linkman"] = txtLinkman.Text;
            dr["contract_cid"] = txtContract_cid.Text;
            dr["customer_goods"] = txtcustomer_goods.Text;
            dr["customer_color_id"] = txtcustomer_color_id.Text;
            dr["remark"] = txtRemark.Text;
            dr["picture_name"] = txtPictrue_name.Text;
            dtReport.Rows.Add(dr);
            using (xrShippingMark oRepot = new xrShippingMark() { DataSource = dtReport })
            {
                oRepot.CreateDocument();
                oRepot.PrintingSystem.ShowMarginsWarning = false;
                if (pType == "P")
                    oRepot.Print();
                else
                    oRepot.ShowPreviewDialog();
            }
        }

       

        private void txtMo_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");  //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
        }

        private void frmShippingMark_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtDate = null;
            dtReport = null;
            clsGEO = null; 
        }

     

        
    }
}
