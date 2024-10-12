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
    public partial class frmSetOcUnusual : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtOcUnusual = new DataTable();
        DataTable dtExit_mo = new DataTable();
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public frmSetOcUnusual()
        {
            InitializeComponent();
            NextControl oNext = new NextControl(this, "1");
            oNext.EnterToTab();           
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            string strMo_id = txtMo_id.Text;
            if (string.IsNullOrEmpty(strMo_id))
            {
                this.Tag = "";
                return;
            }
            if (strMo_id.Length != 9)
            {
                MessageBox.Show("無效的頁數!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Tag = "";
                return;
            }

            string sqlExit_mo = string.Format(@"SELECT '1'
                                FROM so_order_manage A with(nolock),so_order_details B with(nolock)
                                WHERE A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver AND A.within_code='0000' AND A.state NOT IN ('2','V')
                                AND B.mo_id='{0}'", strMo_id);
            dtExit_mo = clsConErp.GetDataTable(sqlExit_mo);
            if (dtExit_mo.Rows.Count == 0)
            {
                MessageBox.Show("該頁數不存在!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
                this.Tag = "";
                return;
            }
            else
                this.Tag = "Y";
           
            Boolean flag_invoice=false ;
            //是否已開發票
            string strInv_dg = string.Format(@"Select top 1 A.id 
                From so_invoice_mostly A WITH (NOLOCK),
                so_invoice_details B WITH (NOLOCK)	
                WHERE A.within_code=B.within_code AND A.id=B.id And A.ver=B.ver AND A.within_code='0000'
                AND (A.flag='0' or (A.flag='1' AND IsNull(A.confirm_status,'0')='1')) 
                AND A.state not in ('2','V') AND B.mo_id ='{0}'",txtMo_id.Text);
//            string strInv_hk = string.Format(@"Select top 1 A.id 
//                From hkserver.cferp.dbo.so_invoice_mostly A WITH (NOLOCK),
//                hkserver.cferp.dbo.so_invoice_details B WITH (NOLOCK)	
//                WHERE A.within_code=B.within_code AND A.id=B.id And A.ver=B.ver AND A.within_code='0000'
//                AND (A.flag='0' or (A.flag='1' AND IsNull(A.confirm_status,'0')='1')) 
//                AND A.state not in ('2','V') AND B.mo_id ='{0}'", txtMo_id.Text);
           DataTable dtDgInvoice=clsConErp.GetDataTable(strInv_dg);
           if (dtDgInvoice.Rows.Count > 0)
               flag_invoice = true;
           else
           {
               //dtDgInvoice = clsConErp.GetDataTable(strInv_hk);
               //if (dtDgInvoice.Rows.Count > 0)
               //    flag_invoice = true;
               //else
               flag_invoice = false;
           }

           if (!flag_invoice)
           {
               MessageBox.Show("請直接在ERP中新版本修改!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
               return;
           }

           string strsql = string.Format(@"SELECT B.mo_id,C.production_remark,abnormal
                FROM so_order_manage A with(nolock)
                INNER JOIN so_order_details B with(nolock)
	                ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver
                INNER JOIN so_order_special_info C with(nolock)
	                ON B.within_code=C.within_code AND B.id=C.id AND B.ver=C.ver AND B.sequence_id=C.upper_sequence
                WHERE A.within_code='{0}' AND A.state<>'2' AND B.mo_id='{1}'", "0000", txtMo_id.Text);
           
           dtOcUnusual = clsConErp.GetDataTable(strsql);
           if (dtOcUnusual.Rows.Count > 0)
           {
               richTextBox1.Text = dtOcUnusual.Rows[0]["production_remark"].ToString();
               if (dtOcUnusual.Rows[0]["abnormal"].ToString() == "1")
               {
                   chkAbnormal.Checked = true;
               }
               else
               {
                   chkAbnormal.Checked = false;                   
               }
           }
           else
           {
               MessageBox.Show("該頁數不存在!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);   
               cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
           }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string strMo_id=txtMo_id.Text ;
            if (string.IsNullOrEmpty(strMo_id))
            {
                MessageBox.Show("頁數不可爲空!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.Tag.ToString()=="")
            {         
                MessageBox.Show("無效頁數,不可保存!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string temp_abnormal="0";
            if (chkAbnormal.Checked)
                temp_abnormal = "1";
            else
                temp_abnormal = "0";
            string production_rmk = richTextBox1.Text.Trim();                
            string Sql_u1=string.Format(@"Update so_order_details set abnormal='{0}' Where within_code='0000' AND mo_id='{1}'",temp_abnormal,strMo_id);
            string Sql_u2=string.Format(@"UPDATE B SET B.production_remark='{0}'
                                          FROM so_order_details A with(nolock),so_order_special_info B with(nolock)
                                          WHERE A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver AND 
                                          A.sequence_id=B.upper_sequence AND A.mo_id='{1}'", production_rmk, strMo_id);
            Boolean save_flag = false;
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.CommandText = Sql_u1;                    
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = Sql_u2;
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
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
