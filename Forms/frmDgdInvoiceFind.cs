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
using cf01.MDL;
using DevExpress.XtraGrid.Views.Grid;


namespace cf01.Forms
{
    public partial class frmDgdInvoiceFind : Form
    {
     
        private string within_code = DBUtility.within_code;
        private DataTable dtDetails = new DataTable();
        private DataTable dtMoStore = new DataTable();       
        public List<soinvoice_details_geo> lsModel = new List<soinvoice_details_geo>();
        public frmDgdInvoiceFind()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dtIdFind = clsDgdDeliverGoods.loadDgdDetails(txtFindOc_no.Text.Trim(), txtFindId.Text.Trim(), txtFindMo_id.Text.Trim(),0);
            gcIdDetails.DataSource = dtIdFind;
        }

        private void dgvIdDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            loadOcDgdDetails(dgvIdDetails.FocusedRowHandle);
        }
        private void loadOcDgdDetails(int row)
        {
            string ocno = dgvIdDetails.GetRowCellValue(row, "order_id").ToString();
            DataTable dtOc = clsDgdDeliverGoods.loadOcDgdDetails(ocno);
            gcOcDgdDetails.DataSource = dtOc;
        }

        private void btnImput_Click(object sender, EventArgs e)
        {
            insertToGeo();
        }
        private void insertToGeo()
        {
            if (dgvIdDetails.RowCount == 0)
                return;
            bool flag_select = false;
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    flag_select = true;
                    break;
                }
            }
            if (!flag_select)
            {
                MessageBox.Show("請首先選取要生成東莞D送貨單的記錄", "提示信息");
                return;
            }
            lsModel.Clear();
            //List<soinvoice_details_geo> lsModel = new List<soinvoice_details_geo>();
            for (int i = 0; i < dgvIdDetails.RowCount; i++)
            {
                if (dgvIdDetails.GetDataRow(i)["is_select"].ToString() == "True")
                {
                    soinvoice_details_geo objModel = new soinvoice_details_geo();                    
                    objModel.id = dgvIdDetails.GetDataRow(i)["id"].ToString().Trim();
                    objModel.mo_id = dgvIdDetails.GetDataRow(i)["mo_id"].ToString().Trim();
                    objModel.goods_id = dgvIdDetails.GetDataRow(i)["goods_id"].ToString().Trim();
                    objModel.goods_name = dgvIdDetails.GetDataRow(i)["goods_name"].ToString().Trim();
                    objModel.sequence_id = dgvIdDetails.GetDataRow(i)["sequence_id"].ToString().Trim();
                    objModel.u_invoice_qty = int.Parse(dgvIdDetails.GetDataRow(i)["u_invoice_qty"].ToString());//送貨數量
                    objModel.goods_unit = dgvIdDetails.GetDataRow(i)["goods_unit"].ToString().Trim();
                    objModel.sec_qty = float.Parse(dgvIdDetails.GetDataRow(i)["sec_qty"].ToString());//重量
                    objModel.sec_unit = dgvIdDetails.GetDataRow(i)["sec_unit"].ToString().Trim();//重量單位
                    objModel.order_id = dgvIdDetails.GetDataRow(i)["order_id"].ToString().Trim();//OC No
                    objModel.location_id = dgvIdDetails.GetDataRow(i)["location_id"].ToString().Trim();
                    objModel.customer_goods = dgvIdDetails.GetDataRow(i)["customer_goods"].ToString();
                    objModel.customer_color_id = dgvIdDetails.GetDataRow(i)["customer_color_id"].ToString();
                    objModel.so_ver = int.Parse(dgvIdDetails.GetDataRow(i)["so_ver"].ToString());//??原始表為int
                    objModel.so_sequence_id = dgvIdDetails.GetDataRow(i)["so_sequence_id"].ToString();
                    objModel.table_head = dgvIdDetails.GetDataRow(i)["table_head"].ToString();//款號
                    objModel.contract_cid = dgvIdDetails.GetDataRow(i)["contract_cid"].ToString();//PO/NO
                    objModel.package_num = int.Parse(dgvIdDetails.GetDataRow(i)["package_num"].ToString());//包數
                    objModel.box_no = dgvIdDetails.GetDataRow(i)["box_no"].ToString();//箱號
                    objModel.remark = dgvIdDetails.GetDataRow(i)["remark"].ToString();
                    objModel.is_print = dgvIdDetails.GetDataRow(i)["is_print"].ToString()=="Y"?"1":"0";
                    if (dgvIdDetails.GetDataRow(i)["shipment_suit"].ToString() == "1" || dgvIdDetails.GetDataRow(i)["shipment_suit"].ToString() == "Y")
                        objModel.shipment_suit = "1";
                    else
                        objModel.shipment_suit = "0";
                    lsModel.Add(objModel);                    
                }
            }            
        }

    }
}
