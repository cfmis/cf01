using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmMmCostingPlate : Form
    {
        public frmMmCostingPlate()
        {
            InitializeComponent();
        }

        private void frmMmCostingPlate_Load(object sender, EventArgs e)
        {
            dgvPlatePrice.AutoGenerateColumns = false;
            dgvPlate.AutoGenerateColumns = false;
            initData();
            
        }
        private void initData()
        {
            frmMmCosting.dtPlateCharges = clsMmCosting.getCostPlateCharges(frmMmCosting.sent_id);
            dgvPlatePrice.DataSource = frmMmCosting.dtPlateCharges;
            DataTable dtPlatePrice = clsMmCosting.getMoOutProcess(frmMmCosting.sent_dep_id, frmMmCosting.sent_prd_mo, frmMmCosting.sent_goods_id);
            dgvPlate.DataSource = dtPlatePrice;
            DataTable dtSpecPlate = clsMmCosting.getSpecPlate();
            lueSpecPlate.Properties.DataSource = dtSpecPlate;
            lueSpecPlate.Properties.ValueMember = "id";
            lueSpecPlate.Properties.DisplayMember = "id";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvPlate.Rows.Count == 0)
                return;
            int rows = dgvPlate.CurrentCell.RowIndex;
            DataGridViewRow CurrentRow = dgvPlate.Rows[rows];
            DataRow dr = frmMmCosting.dtPlateCharges.NewRow();
            dr["clr"] = CurrentRow.Cells["colGoods_id_P"].Value.ToString().Substring(14, 4);
            dr["clr_cdesc"] = CurrentRow.Cells["colClr_cdesc_P"].Value.ToString();
            dr["do_color"] = CurrentRow.Cells["colDo_color_P"].Value.ToString();
            dr["plateprice"] = CurrentRow.Cells["colWegPrice_P"].Value;
            dr["remark"] = CurrentRow.Cells["colRemark_P"].Value.ToString();
            frmMmCosting.dtPlateCharges.Rows.Add(dr);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlatePrice.Rows.Count == 0)
                return;
            int rows = dgvPlatePrice.CurrentCell.RowIndex;
            frmMmCosting.dtPlateCharges.Rows.RemoveAt(rows);
        }

        private void lueSpecPlate_EditValueChanged(object sender, EventArgs e)
        {
            //txtSpecPrice.Text = sluSpecPlate.

            if (lueSpecPlate.EditValue != null)
            {
                //取资料行，数据源为DataTable, 资料行是DataRowView对象。 
                object o = lueSpecPlate.Properties.GetDataSourceRowByKeyValue(lueSpecPlate.EditValue);

                if (o is DataRowView)
                {
                    DataRowView rv = o as DataRowView;
                    txtSpecPrice.Text = rv.Row["plateprice"].ToString(); //取单价 
                    txtSpecPlate.Text = rv.Row["cdesc"].ToString();
                }
            }
            else
            {
                txtSpecPrice.Text = "0.00";
                txtSpecPlate.Text = "";
            }
        }

        private void btnSpecAdd_Click(object sender, EventArgs e)
        {
            if (lueSpecPlate.EditValue != null)
            {
                DataRow dr = frmMmCosting.dtPlateCharges.NewRow();
                dr["clr"] = lueSpecPlate.EditValue.ToString();
                dr["clr_cdesc"] = txtSpecPlate.Text.ToString();
                dr["plateprice"] = txtSpecPrice.Text.ToString();
                frmMmCosting.dtPlateCharges.Rows.Add(dr);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
