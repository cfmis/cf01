using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ModuleClass;
using cf01.CLS;


namespace cf01.Forms
{
    public partial class frmSoGarmentFactory : Form
    {
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        DataTable dtDetail = new DataTable();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示     
        //clsToolBar objToolbar;

        public frmSoGarmentFactory()
        {
            InitializeComponent();
            //clsTranslate obj_ctl = new clsTranslate( this.Controls, DBUtility._language);
            //obj_ctl.Translate();

            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);
        }

        private void frmSoGarmentFactory_Load(object sender, EventArgs e)
        {  
            //LoadDate();
            DataTable dtCustomer = new DataTable();
            string sql = "Select id,name From it_customer Where state<>'2' order by id";
            dtCustomer = clsErp.GetDataTable(sql);
            lueItcustomer.Properties.DataSource = dtCustomer;
            lueItcustomer.Properties.ValueMember = "id";
            lueItcustomer.Properties.DisplayMember = "id";
            DataTable dtFactory = new DataTable();
            sql = @"Select id,name,trading_company_id,trading_company_name 
                From v_garment_factory Order By trading_company_id,id";
            dtFactory = clsErp.GetDataTable(sql);
            lueGarmentFactory.Properties.DataSource = dtFactory;
            lueGarmentFactory.Properties.ValueMember = "id";
            lueGarmentFactory.Properties.DisplayMember = "id";

            clFactory.DataSource = dtFactory;
            clFactory.ValueMember = "id";
            clFactory.DisplayMember = "id";
            txtOrder_date1.EditValue = DateTime.Now.Date.AddDays(-7).ToString("yyyy/MM/dd");
            txtOrder_date2.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
        }

        private bool CheckFindcondition()
        {
            string str = txtOc1.Text.Trim();
            str += txtOc2.Text.Trim();
            str += txtOrder_date1.EditValue.ToString();
            str += txtOrder_date2.EditValue.ToString();
            str += lueItcustomer.EditValue.ToString();
            str += txtSeller_id.Text.Trim();
            str += txtMerchandiser.Text.Trim();
            str += txtCreate_by.Text.Trim();
            str += txtCreate_date1.EditValue.ToString();
            str += txtCreate_date2.EditValue.ToString();
            str += lueGarmentFactory.EditValue.ToString();
            if (str == "")
            {
                return false;
            }
            return true;
        }

        private void LoadDate()
        {
            dtDetail.Clear();
            string sql =
            @"SELECT id,order_date,it_customer,name as customer_name,agent,seller_id,merchandiser,garment_factory,
            season,Create_by,create_date,state,ver
            FROM so_order_manage with(nolock)
            WHERE within_code='0000' ";
            if(txtOc1.Text.Trim() != "")
            {
                sql += string.Format(" And id>='{0}'", txtOc1.Text.Trim()) ;
            }
            if (txtOc2.Text.Trim() != "")
            {
                sql += string.Format(" And id<='{0}'", txtOc2.Text.Trim());
            }
            if (txtOrder_date1.Text != "")
            {
                sql += string.Format(" And order_date>='{0}'", txtOrder_date1.Text);
            }
            if (txtOrder_date2.Text != "")
            {
                sql += string.Format(" And order_date<='{0}'", txtOrder_date2.Text);
            }
            if (lueItcustomer.EditValue.ToString() != "")
            {
                sql += string.Format(" And it_customer ='{0}'", lueItcustomer.EditValue.ToString());
            }
            if(txtSeller_id.Text.Trim() != "")
            {
                sql += string.Format(" And seller_id ='{0}'", txtSeller_id.Text.Trim());
            }
            if (txtMerchandiser.Text.Trim() != "")
            {
                sql += string.Format(" And merchandiser ='{0}'", txtMerchandiser.Text.Trim());
            }
            if (txtCreate_by.Text.Trim() != "")
            {
                sql += string.Format(" And create_by ='{0}'", txtCreate_by.Text.Trim());
            }
            if (txtCreate_date1.EditValue.ToString() != "")
            {
                sql += string.Format(" And create_date>='{0}'", txtCreate_date1.EditValue.ToString());
            }
            if (txtCreate_date2.EditValue.ToString() != "")
            {
                sql += string.Format(" And create_date<='{0}'", txtCreate_date2.EditValue.ToString());
            }
            if(lueGarmentFactory.EditValue.ToString() != "")
            {
                sql += string.Format(" And garment_factory ='{0}'", lueGarmentFactory.EditValue.ToString());
            }
            dtDetail = clsErp.GetDataTable(sql);
            gridControl1.DataSource = dtDetail;           
        }      

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("明細資料不可為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool flagSave = false;
            gridView1.CloseEditor();
            //更新主表
            string sql_update = @"UPDATE dbo.so_order_manage SET garment_factory=@garment_factory WHERE within_code='0000' And id=@id And ver=@ver";
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    //保存明細資料
                    string rowStatus;
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        rowStatus = dtDetail.Rows[i].RowState.ToString();
                        if (rowStatus == "Modified")
                        {
                            myCommand.Parameters.Clear();
                            myCommand.CommandText = sql_update;
                            myCommand.Parameters.AddWithValue("@id", dtDetail.Rows[i]["id"].ToString());
                            myCommand.Parameters.AddWithValue("@ver", dtDetail.Rows[i]["ver"].ToString());
                            myCommand.Parameters.AddWithValue("@garment_factory", dtDetail.Rows[i]["garment_factory"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                    }                    
                    myTrans.Commit(); //數據提交
                    flagSave = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    flagSave = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }           
            if (flagSave)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void frmSoGarmentFactory_FormClosed(object sender, FormClosedEventArgs e)
        {
                        
        }      

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (CheckFindcondition())
            {
                LoadDate();
            }
            else
            {
                MessageBox.Show("查詢條件不可為空 !", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }
       
        private void luestate_EditValueChanged(object sender, EventArgs e)
        {
            if (lueItcustomer.EditValue.ToString() == "2")
            {
                this.lueItcustomer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            }
            else
                this.lueItcustomer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            
        }

        private void txtOc1_Leave(object sender, EventArgs e)
        {
            txtOc2.Text = txtOc1.Text;
        }

        private void txtOrder_date1_Leave(object sender, EventArgs e)
        {
            txtOrder_date2.EditValue = txtOrder_date1.EditValue;
        }

        private void txtCreate_date1_Leave(object sender, EventArgs e)
        {
            txtCreate_date2.EditValue = txtCreate_date1.EditValue;
        }

     
        

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (dtDetail.Rows.Count == 0)
            //{
            //    return;
            //}
            //int curRow = gridView1.FocusedRowHandle;
            //if (curRow < 0)
            //{
            //    return;
            //}
            //string trading_id = gridView1.GetRowCellDisplayText(curRow, "it_customer");
            //string sql = string.Format(
            //@"Select id,name,trading_company_id,trading_company_name 
            //  From v_garment_factory
            //  WHERE trading_company_id='{0}' 
            //  Order By trading_company_id,id", trading_id);
            //dtFactory1 = clsErp.GetDataTable(sql);
            //clFactory.DataSource = dtFactory1;
            //clFactory.ValueMember = "id";
            //clFactory.DisplayMember = "id";
            
        }


    }
}
