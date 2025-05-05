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
    public partial class frmTransferoutAdj : Form
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtAdj = new DataTable();
        public bool flag_adj = false;

        public frmTransferoutAdj(DataTable dt)
        {
            InitializeComponent();            
            dtAdj = dt;
        }

        private void frmTransferoutAdj_Load(object sender, EventArgs e)
        {            
            dgv1.DataSource = dtAdj;
        }   

        private void btnExit_Click(object sender, EventArgs e)
        {
            flag_adj = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dgv1.Rows.Count>0)
            {
                if (MessageBox.Show("確認對以下庫存不足(601倉)的貨品進行庫存調整？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                st_adjustment_mostly headData = new st_adjustment_mostly(); 
                headData.id = clsTransferout.GetMaxIDStock("ST02", 4);
                headData.department_id = "601";
                headData.date = DateTime.Now.Date.ToString("yyyy/MM/dd");
                headData.mode = "1";
                headData.state = "0";
                headData.transfers_state = "0";
                headData.update_count = "1";
                headData.create_by = DBUtility._user_id;
                headData.servername = "hkserver.cferp.dbo";
                headData.adjust_reason = "01";
                headData.head_status = "NEW";
                List<st_a_subordination> lstDetailData1 = new List<st_a_subordination>();
                for (int i = 0; i < dtAdj.Rows.Count; i++)
                {
                    st_a_subordination lstMd = new st_a_subordination();
                    lstMd.id = headData.id;
                    lstMd.sequence_id = dtAdj.Rows[i]["sequence_id"].ToString();
                    lstMd.mo_id = dtAdj.Rows[i]["mo_id"].ToString();
                    lstMd.goods_id = dtAdj.Rows[i]["goods_id"].ToString();
                    lstMd.goods_name = "";                  
                    lstMd.color = "";
                    lstMd.location = "601";
                    lstMd.carton_code = "601";
                    lstMd.unit = "PCS";
                    lstMd.qty = decimal.Parse(dtAdj.Rows[i]["adj_qty"].ToString());
                    lstMd.sec_qty = decimal.Parse(dtAdj.Rows[i]["adj_sec_qty"].ToString());
                    lstMd.lot_no = dtAdj.Rows[i]["lot_no"].ToString();
                    lstMd.ib_amount = 0;
                    lstMd.ib_weight = 0;                    
                    lstMd.price = 0;
                    lstMd.transfers_state = "0";
                    lstMd.sec_unit = "KG";
                    lstMd.remark = "";
                    lstMd.row_status = "NEW";
                    lstDetailData1.Add(lstMd);
                }
                string result = "";
                //保存庫存調整數據以及批準
                result = clsTransferout.SaveAdjData(headData, lstDetailData1, DBUtility._user_id);
                if (result.Substring(0,2) == "00")
                {
                    //批準庫存調整數據及批準成功
                    MessageBox.Show("自動庫存調整及批準成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag_adj = true;
                }
                else
                {
                    MessageBox.Show("自動庫存調整及批準失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag_adj = false;
                }
                this.Close();
            }
        }

        

    }
}
