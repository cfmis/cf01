using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmOcFindMo : Form
    {
        DataTable dtFind = new DataTable();
        public frmOcFindMo(string oc_no)
        {
            InitializeComponent();
            txtoc_no.Text = oc_no;
        }

        private void frmOcFindMo_Load(object sender, EventArgs e)
        {
            string strsql = string.Format(
            @"Select convert(bit,0) as flag_select,A.contract_id,B.mo_id,REPLACE(REPLACE(ISNULL(add_remark,''),char(10),''),char(13),'') as oc_remark 
            From dgerp2.cferp.dbo.so_order_manage A  with(nolock),dgerp2.cferp.dbo.so_order_details B with(nolock)
            Where A.within_code=B.within_code AND A.id=B.id and A.ver=B.ver AND A.within_code='0000' AND A.id='{0}' AND B.state <>'2' order by B.sequence_id", txtoc_no.Text);
            dtFind = clsPublicOfCF01.GetDataTable(strsql);
            dgvMoList.DataSource = dtFind;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvMoList.Rows.Count == 0)
            {
                return;
            }
            bool select_flag = false;
            for (int i = 0; i < dgvMoList.RowCount; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {
                    select_flag = true;
                    break;
                }
            }
            if (!select_flag)
            {
                MessageBox.Show("請選擇要添加的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmShippingRemark.mList.Clear();           
            for (int i = 0; i < dgvMoList.RowCount; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {
                    mdlOcRemark objModel = new mdlOcRemark()
                    {
                        mo_id = dtFind.Rows[i]["mo_id"].ToString(),
                        articleno = dtFind.Rows[i]["oc_remark"].ToString(),
                        po_no = dtFind.Rows[i]["contract_id"].ToString()
                    };
                    frmShippingRemark.mList.Add(objModel);
                }
            }
            Close();
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOcFindMo_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtFind.Dispose();
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
            if (dgvMoList.Rows.Count > 0)
            {
                for (int i = 0; i < dtFind.Rows.Count; i++)
                {
                    dtFind.Rows[i]["flag_select"] = _flag;
                }
            }
        }
    }
}
