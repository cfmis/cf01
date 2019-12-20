using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using cf01.CLS;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmZipperOrder_PrintCard : Form
    {
        public frmZipperOrder_PrintCard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadData()
        {
            string mo_id = txtMo_id.Text.Trim();
            int find_mo_flag = 0;//從訂單中查找備註等資料
            DataTable dtMo = clsZipperOrder.findIdDetails(find_mo_flag, "", "", "", "", mo_id, "", "", "");
            if (dtMo.Rows.Count > 0)
            {
                DataRow row = dtMo.Rows[0];
                txtPrd_code.Text = "";
                txtPrint_mo.Text = txtMo_id.Text;
                txtSpec.Text = (row["spec_cdesc"].ToString() != "" ? row["spec_cdesc"].ToString().Trim() : "")
                                    + (row["spec_oth"].ToString() != "" ? "/" + row["spec_oth"].ToString().Trim() : "")
                                    + (row["manu_craft_group_cdesc"].ToString() != "" ? "/" + row["manu_craft_group_cdesc"].ToString().Trim() : "")
                                    + (row["zipper_tooth_cdesc"].ToString() != "" ? "/" + row["zipper_tooth_cdesc"].ToString().Trim() : "");//產品規格
                txtColor.Text = (row["color_c"].ToString() != "" ? "/" + row["color_c"].ToString().Trim() : "")
                                    + (row["color_y"].ToString() != "" ? "/" + row["color_y"].ToString().Trim() : "")
                                    + (row["color_oth"].ToString() != "" ? "/" + row["color_oth"].ToString().Trim() : "")
                                    + (row["zipper_color_oth"].ToString() != "" ? "/" + row["zipper_color_oth"].ToString().Trim() : "")
                                    + (row["pull_card_color"].ToString() != "" ? row["pull_card_color"].ToString().Trim() : "")
                                    ;//布帶/鏈齒/拉片顏色
                txtSize.Text = (row["size"].ToString() != "" ? row["size"].ToString().Trim() : "")
                                    + " / " + (row["size_unit_cdesc"].ToString() != "" ? row["size_unit_cdesc"].ToString().Trim() : "");
                //+ (row["size_diff_cdesc"].ToString() != "" ? row["size_diff_cdesc"].ToString().Trim() : "")
                txtQty.Text = row["order_qty"].ToString().Trim();
                lueGoods_unit.EditValue = row["goods_unit"].ToString().Trim();
                luePack_type.EditValue = "";
            }
            else
            {
                txtPrint_mo.Text = "";
                txtPrd_code.Text = "";
                txtSpec.Text = "";
                txtColor.Text = "";
                txtSize.Text = "";
                txtQty.Text = "";
                lueGoods_unit.EditValue = "";
                luePack_type.EditValue = "";
            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text.Trim() != "")
                loadData();
        }
        private void printData(int print_type)
        {
            float unit_rate = 1;
            float qty_pcs = 0;
            float per_pack = 0;
            string unit="";
            unit = (lueGoods_unit.EditValue != "" ? lueGoods_unit.EditValue.ToString() : "");
            DataTable dtUnitRate=clsZipperOrder.getUnitRate(unit);
            if (dtUnitRate.Rows.Count > 0)
                unit_rate = Convert.ToSingle(dtUnitRate.Rows[0]["rate"]);
            qty_pcs = (txtQty.Text.Trim() != "" ? Convert.ToSingle(txtQty.Text) : 0) * unit_rate;
            per_pack = (txtPer_pack.Text != "" ? Convert.ToSingle(txtPer_pack.Text) : qty_pcs);
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("mo_id", System.Type.GetType("System.String"));
            dtPrint.Columns.Add("prd_code", System.Type.GetType("System.String"));
            dtPrint.Columns.Add("spec", System.Type.GetType("System.String"));
            dtPrint.Columns.Add("color", System.Type.GetType("System.String"));
            dtPrint.Columns.Add("size", System.Type.GetType("System.String"));
            dtPrint.Columns.Add("qty", System.Type.GetType("System.String"));
            double pack_no = 0;
            float print_qty = 0;
            pack_no = Math.Ceiling(qty_pcs / per_pack);
            for (int i = 0; i < pack_no; i++)
            {
                if (qty_pcs >= per_pack)
                {
                    print_qty = per_pack;
                    qty_pcs = qty_pcs - per_pack;
                }
                else
                    print_qty = qty_pcs;
                DataRow dr = dtPrint.NewRow();
                dr["mo_id"] = txtPrint_mo.Text.Trim();
                dr["prd_code"] = txtPrd_code.Text.Trim();
                dr["spec"] = txtSpec.Text.Trim();
                dr["color"] = txtColor.Text.Trim();
                dr["size"] = txtSize.Text.Trim();
                dr["qty"] = print_qty.ToString() + " PCS";
                dtPrint.Rows.Add(dr);
            }
            xrZipperOrder_PrintCard oRepot = new xrZipperOrder_PrintCard() { DataSource = dtPrint };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            if (print_type == 2)
                oRepot.ShowPreview();
            else
                oRepot.Print();//.PrintDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printData(1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            printData(2);
        }

        private void frmZipperOrder_PrintCard_Load(object sender, EventArgs e)
        {
            initControls();
        }
        private void initControls()
        {
            //包裝要求
            DataTable dtPack = clsZipperOrder.getManu_craft("PK");
            luePack_type.Properties.DataSource = dtPack;
            luePack_type.Properties.ValueMember = "id";
            luePack_type.Properties.DisplayMember = "cdesc";

            //單位
            DataTable dtUnit = clsZipperOrder.getUnit();
            lueGoods_unit.Properties.DataSource = dtUnit;
            lueGoods_unit.Properties.ValueMember = "id";
            lueGoods_unit.Properties.DisplayMember = "name";
        }

        private void luePack_type_EditValueChanged(object sender, EventArgs e)
        {
            string id=(luePack_type.EditValue!=""?luePack_type.EditValue.ToString():"");
            DataTable dtPack = clsZipperOrder.getPper_pack(id, "PK");
            if (dtPack.Rows.Count > 0)
                txtPer_pack.Text = dtPack.Rows[0]["per_pack"].ToString();
            else
                txtPer_pack.Text = "";
            
        }
    }
}
