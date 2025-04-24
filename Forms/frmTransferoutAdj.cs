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
                //to do ajd生成庫存調整的交易數據
                //axios.post("/Adjustment/Save",{headData,lstDetailData1,lstDelData1,user_id}).then(
                /*
                headData: { id:'',department_id:'',date:'',mode:'1',handler:'',remark:'',state:'0',transfers_state:'0',update_count:'',create_date:'',create_by:'',update_date:'',update_by:'',adjust_reason:'',servername:'',check_by:'',check_date:'',head_status:"" },            
                rowDataEdit: {id:'',sequence_id:'',mo_id:'',goods_id:'',goods_name:'',color:'',location:'',carton_code:'',unit:'PCS',qty:0,ib_amount:0.00,price:0.00,transfers_state:'0',sec_unit:'KG',sec_qty:0.00,ib_weight:0.00,lot_no:'',remark:'',row_status:''},            
               
                */
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
                for (int i = 0; i < dtAdj.Rows.Count; i++)
                {

                }
                
               

                MessageBox.Show("庫存調整成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag_adj = true;
                this.Close();
            }
        }

        

    }
}
