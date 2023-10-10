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

namespace cf01.ReportForm
{
    public partial class frmDeliveryPrepareAdd : Form
    {
        st_delivery_prepare delivery_h = new st_delivery_prepare();
        List<st_delivery_prepare_detail> lstDetails = new List<st_delivery_prepare_detail>();
        public string id = string.Empty;
        public frmDeliveryPrepareAdd(st_delivery_prepare lst_h, List<st_delivery_prepare_detail> lst_d)
        {
            InitializeComponent();
            delivery_h = lst_h;
            lstDetails = lst_d;
        }

        private void frmDeliveryPrepareAdd_Load(object sender, EventArgs e)
        {
            txtId.Text = (delivery_h.row_status == "EDIT") ? delivery_h.id : "";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {           
            int result = clsDeliveryPrepare.Save(delivery_h, lstDetails);
            if (result >= 0)
            {
                this.id = delivery_h.id;//暫存保存成功的單據號
                MessageBox.Show("保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.id = "";
            this.Close();
        }

        private void txtId_Properties_Click(object sender, EventArgs e)
        {
            using (frmDeliveryPrepareList frm = new frmDeliveryPrepareList())
            {
                //重新指定已存在單據號
                frm.ShowDialog();
                if (frm.return_id != "")
                {
                    //添加到指定的追貨紙
                    txtId.Text = frm.return_id;
                    delivery_h.id = txtId.Text;
                    delivery_h.row_status = "EDIT";

                    //明細ID也要更改
                    List<st_delivery_prepare_detail> lstTemp = new List<st_delivery_prepare_detail>();
                    foreach (st_delivery_prepare_detail dr in lstDetails)
                    {
                        st_delivery_prepare_detail item = new st_delivery_prepare_detail();
                        item.id = txtId.Text;
                        item.sequence_id = dr.sequence_id;
                        item.mo_id = dr.mo_id;
                        item.goods_id = dr.goods_id;
                        item.goods_name = dr.goods_name;
                        item.plan_qty = dr.plan_qty;
                        item.move_qty = dr.move_qty;
                        item.base_unit = dr.base_unit;
                        item.state = dr.state;
                        item.up_deptment = dr.up_deptment;
                        lstTemp.Add(dr);
                    }
                    lstDetails.Clear();
                    lstDetails = lstTemp;

                }
            }
        }

    }
       
}
