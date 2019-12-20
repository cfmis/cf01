using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmMachineStatusDetail : Form
    {
        private string prd_id;
        public frmMachineStatusDetail(string prdId)
        {
            InitializeComponent();
            prd_id = prdId;
        }

        private void frmMachineStatusDetail_Load(object sender, EventArgs e)
        {
            clsControlInfoHelper forminit = new clsControlInfoHelper("frmMachineStatusDetail", this.Controls);
            forminit.GenerateContorl();

            FillGridView();
        }

        private void FillGridView()
        {
            dgvDetails.Rows.Clear();
            dgvDetails.RowCount = 1;
            for (int i = 0; i < frmMachineStatus.lsPms.Count; i++)
            {
                if (frmMachineStatus.lsPms[i].prd_id.ToString() == prd_id)
                {
                    dgvDetails.Rows[0].Cells["colEndTime"].Value = frmMachineStatus.lsPms[i].prd_end_time;
                    dgvDetails.Rows[0].Cells["colStartTime"].Value = frmMachineStatus.lsPms[i].prd_start_time;
                    dgvDetails.Rows[0].Cells["colWorkType"].Value = frmMachineStatus.lsPms[i].prd_work_type;
                    dgvDetails.Rows[0].Cells["colMo_Id"].Value = frmMachineStatus.lsPms[i].prd_mo;
                    dgvDetails.Rows[0].Cells["colGoods_Id"].Value = frmMachineStatus.lsPms[i].prd_item;
                    dgvDetails.Rows[0].Cells["colPrd_Id"].Value = frmMachineStatus.lsPms[i].prd_id;
                    dgvDetails.Rows[0].Cells["colPrd_Machine"].Value = frmMachineStatus.lsPms[i].prd_machine;
                    dgvDetails.Rows[0].Cells["prd_date"].Value = frmMachineStatus.lsPms[i].prd_date;
                    dgvDetails.Rows[0].Cells["prd_qty"].Value = frmMachineStatus.lsPms[i].prd_qty;
                    dgvDetails.Rows[0].Cells["prd_weg"].Value = frmMachineStatus.lsPms[i].prd_weg;

                    break;
                }
            }
        }
    }
}
