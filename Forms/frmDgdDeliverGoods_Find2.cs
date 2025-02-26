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
    public partial class frmDgdDeliverGoods_Find2 : Form
    {
        DataTable dtFind = new DataTable();
        public List<packing_mo_records> lstMo = new List<packing_mo_records>();


        public frmDgdDeliverGoods_Find2()
        {
            InitializeComponent();
        }


        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                Select_All(true);
            }
            else
            {
                Select_All(false);
            }
        }

        private void Select_All(bool _flag)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtFind.Rows.Count; i++)
                {
                    dtFind.Rows[i]["flag_select"] = _flag;
                }
            }
        }

        private void frmDgdDeliverGoods_Find2_Load(object sender, EventArgs e)
        {
            string strSql =
            @"Select CONVERT(bit,0) as flag_select,mo_id,qty,weg,box_no,prd_id,upd_flag 
            From packing_mo_records Where isnull(upd_flag,'0')='0' ORDER BY box_no,prd_id";
            dtFind = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dgvDetails.DataSource = dtFind;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            lstMo.Clear();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                return;
            }

            lstMo.Clear();
            bool select_flag = false;
            DataRow[] aryRows = dtFind.Select("flag_select=true");
            dtFind.Select();
            if (aryRows.Length > 0)
            {
                select_flag = true;
            }
            if (!select_flag)
            {
                MessageBox.Show("請選擇要匯入的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i=0;i< aryRows.Length;i++)
            {
                packing_mo_records mdl = new packing_mo_records();
                mdl.prd_id = int.Parse(aryRows[i]["prd_id"].ToString());
                mdl.mo_id = aryRows[i]["mo_id"].ToString();
                mdl.qty = decimal.Parse(aryRows[i]["qty"].ToString());
                mdl.weg = decimal.Parse(aryRows[i]["weg"].ToString());
                mdl.box_no = aryRows[i]["box_no"].ToString();
                lstMo.Add(mdl);
            }
            this.Close();
        }
    }
}
