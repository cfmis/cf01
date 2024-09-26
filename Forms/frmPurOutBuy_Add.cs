using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmPurOutBuy_Add : Form
    {
        string m_po_id="";
        DataTable dtPo = new DataTable();
        public List<mdlPur> m_pur_list = new List<mdlPur>();
        public frmPurOutBuy_Add(string po_id)
        {
            InitializeComponent();
            m_po_id = po_id;
            txtPo_id.Text = po_id;
        }

        private void frmPurOutBuy_Add_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void chkSelectAll_MouseUp(object sender, MouseEventArgs e)
        {
            bool lb_flag;
            if (chkSelectAll.Checked)
            {
                lb_flag = true;                
            }
            else
            {
                lb_flag = false;
            }
            for (int i = 0; i < dgvPo.Rows.Count; i++)
            {
                dgvPo.Rows[i].Cells["flag_select"].Value = lb_flag;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurOutBuy_Add_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtPo.Dispose();
        }
    
        private void btnOk_Click(object sender, EventArgs e)
        {
            bool lb_flag_select = false;
            for (int i = 0; i < dgvPo.Rows.Count; i++)
            {
                if (dgvPo.Rows[i].Cells["flag_select"].Value.ToString() == "True")
                {
                    lb_flag_select = true;
                    break;
                }
            }
            if (!lb_flag_select)
            {
                MessageBox.Show("請首先選擇要添加的項目!", "提示信息");
                return;
            }
            string ls_qty="";
            for (int i = 0; i < dgvPo.Rows.Count; i++)
            {
                if (dgvPo.Rows[i].Cells["flag_select"].Value.ToString() == "True")
                {
                    if (int.Parse(dtPo.Rows[i]["ap_qty"].ToString()) > 0)
                    {
                        ls_qty = dtPo.Rows[i]["ap_qty"] + dtPo.Rows[i]["goods_unit"].ToString();
                    }
                    if (float.Parse(dtPo.Rows[i]["sec_qty"].ToString()) > 0)
                    {
                        ls_qty = String.Format("{0};{1} {2}", ls_qty, dtPo.Rows[i]["sec_qty"], dtPo.Rows[i]["sec_unit"]);
                    }
                    mdlPur lst_pur = new mdlPur()
                    {
                        con_date = dtPo.Rows[i]["con_date"].ToString(),
                        dept_id = dtPo.Rows[i]["dept_id"].ToString(),
                        factory_id = "DG",
                        po_id = dtPo.Rows[i]["id"].ToString(),
                        goods_name = dtPo.Rows[i]["goods_name"].ToString().Trim(),
                        qty_desc = ls_qty,
                        vendor_name = "",
                        remark = dtPo.Rows[i]["remark"].ToString().Trim()
                    };                    
                    m_pur_list.Add(lst_pur);
                }
            }
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtPo_id.Text == "")
            {
                MessageBox.Show("請指定申請單編號","提示信息");
                txtPo_id.Focus();
                return;
            }
            Load_Data();
            if (dtPo.Rows.Count == 0)
            {
                MessageBox.Show("無符合查找條件的數據", "提示信息");
                return;
            }
        }

        private void Load_Data()
        {
            string ls_sql = string.Format(
            @"SELECT Convert(bit,0) as flag_select, A.id,convert(varchar(10),A.ap_date,120) as con_date,A.department_id as dept_id,B.goods_name,
            CAST(B.ap_qty AS INT) AS ap_qty,B.goods_unit,ROUND(CAST(ISNULL(B.sec_qty,0) AS float),2) AS sec_qty,B.sec_unit,B.remark,
            CASE Isnull(B.goods_origin_id,'')
            WHEN '01' THEN '東莞'
            WHEN '02' THEN '香港'
            ELSE '' END AS origin_id
            FROM dgerp2.cferp.dbo.po_application_buy A with(nolock),
                 dgerp2.cferp.dbo.po_ap_details B with(nolock)
            WHERE A.within_code=B.within_code and A.id=B.id AND A.id='{0}' AND A.state='1' order by A.id,B.sequence_id", txtPo_id.Text);
            dtPo = clsPublicOfCF01.GetDataTable(ls_sql);
            dgvPo.DataSource = dtPo;
        }




     
    }
}
