using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;

namespace cf01.Forms
{
    public partial class frmPlanCancel : Form
    {
        clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        DataTable dtOcUnusual = new DataTable();
        DataTable dtMo = new DataTable();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public frmPlanCancel()
        {
            InitializeComponent();           
            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (!CheckMo())
            {
                txtMo_id.Focus();
            }            
        }

        private bool CheckMo()
        {
            string moId = txtMo_id.Text;
            if (string.IsNullOrEmpty(moId))
            {
                return false;
            }
            if (moId.Length != 9)
            {
                MessageBox.Show("無效的頁數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string sql = string.Format(
            @"SELECT A.state,A.remark,B.plate_remark,C.production_remark 
            FROM jo_bill_mostly A with(nolock),so_order_details B with(nolock),so_order_special_info C with(nolock)
            WHERE A.within_code=B.within_code And A.mo_id=B.mo_id And B.within_code=C.within_code And B.id=C.id And B.ver=C.ver And B.sequence_id=C.upper_sequence And
                  A.within_code='0000' And A.mo_id='{0}' And A.state NOT IN ('2','V')", moId);
            dtMo = clsConErp.GetDataTable(sql);
            if (dtMo.Rows.Count == 0)
            {
                luestate.EditValue = "0";
                txtProduction_remark.Text = "";
                txtPlate_remark.Text = "";               
                txtRemark.Text = "";
                MessageBox.Show("該頁數不存在!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return false;
            }
            else
            {
                luestate.EditValue = dtMo.Rows[0]["state"].ToString();
                txtProduction_remark.Text = dtMo.Rows[0]["production_remark"].ToString();
                txtPlate_remark.Text = dtMo.Rows[0]["plate_remark"].ToString();               
                txtRemark.Text = dtMo.Rows[0]["remark"].ToString();
                return true;
            }
        }

        private void frmPlanCancel_Load(object sender, EventArgs e)
        {
            clsPublic.SetDropBoxForState(luestate, "3");
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (!CheckMo())
            {
                return;
            }
            if (MessageBox.Show("確認要注銷當前頁數？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string sql_u = string.Format(@"Update jo_bill_mostly SET state='2',update_by='{1}',update_date=getdate() Where within_code='0000' AND mo_id='{0}'", txtMo_id.Text, DBUtility._user_id);
            bool save_flag = false;
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.CommandText = sql_u;
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                }
            }
            if (save_flag)
            {
                luestate.EditValue = "2";
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
