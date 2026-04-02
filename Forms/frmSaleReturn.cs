using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmSaleReturn : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        clsToolBarNew objToolbar;
        DataTable dtFind = new DataTable();
        DataTable dtReturn = new DataTable();
        string strDatetime = clsUtility.GetCurrentDateTime(); //2026-03-09 15:50:02        
        string within_code = "0000";
        string strConn = DBUtility.conn_str_hkerp1; //默認在HKERP服務器上插入數據（so_return_mostly，so_return_details）
        string strIP = clsSaleReturn.GetLocalIP();
                

        public frmSaleReturn()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, grpBox1.Controls);
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();

            if (strIP.Length >= 11)
            {
                if (strIP.Substring(0, 11) == "192.168.168")
                {
                    strConn = DBUtility.conn_str_hkerp1; //strConn 強制在HKERP服務器上插入數據（so_return_mostly，so_return_details）
                }
            }
        }

        private void frmSaleReturn_Load(object sender, EventArgs e)
        {
            dtFind = clsSaleReturn.GetDataInit(); 
            gridControl1.DataSource = dtFind;

            if (txtIssues_date1.Text == "" && txtIssues_date2.Text == "")
            {
                txtIssues_date2.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                txtIssues_date1.EditValue = DateTime.Now.Date.AddDays(-14).ToString("yyyy-MM-dd");
            }
            
            dtReturn.Columns.Add("doc_id", typeof(string));
            dgvDoc.DataSource = dtReturn;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if(txtID1.Text =="" && txtID2.Text =="" && txtIssues_date1.Text==""&& txtIssues_date2.Text =="" && txtIt_customer.Text == "" && txtSales_group.Text == "")
            {
                MessageBox.Show("請輸入查找條件!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            dtFind = clsSaleReturn.GetDataFind(txtID1.Text, txtID2.Text, txtIssues_date1.Text, txtIssues_date2.Text, txtIt_customer.Text, txtSales_group.Text);            
            gridControl1.DataSource = dtFind;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value("frmSaleReturn", grpBox1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {
            txtID2.Text = txtID1.Text;
        }

        private void txtIssues_date1_Leave(object sender, EventArgs e)
        {
            txtIssues_date2.Text = txtIssues_date1.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("請首先查找出相關數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool flagSelect = false;            
            gridView1.CloseEditor();
            DataRow[] aryRows = dtFind.Select("flag_select=true"); //取所有被選中的數據
            dtFind.Select();
            if (aryRows.Length > 0)
            {
                flagSelect = true;
            }
            if (!flagSelect)
            {
                MessageBox.Show("注意！至少要選中一筆記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int len = aryRows.Length;
            //處理重復
            List<mdlLocationCust> lstWhCust = new List<mdlLocationCust>(len);
            for (int i = 0; i < aryRows.Length; i++)
            {
                mdlLocationCust mdlWhCust = new mdlLocationCust() {
                    location_id = aryRows[i]["location_id"].ToString(),
                    it_customer = aryRows[i]["it_customer"].ToString()
                };               
                lstWhCust.Add(mdlWhCust);
            }            
            //lstWhCust = lstWhCust.Distinct().ToList();//去掉重復 符合只有一個字段的情況           
            var lstMDL = lstWhCust.GroupBy(d => new { d.location_id, d.it_customer })
                        .Select(d => d.FirstOrDefault())
                        .ToList();            
            string strYYMM = strDatetime.Substring(2, 2) + strDatetime.Substring(5, 2);
            string sql_h_i = string.Empty, sql_d_i = string.Empty, sql_u = string.Empty;
            string doc_id = string.Empty, return_date = string.Empty, separate_return = "1", it_customer = string.Empty, name = string.Empty, department_id = "H08";
            string seller_id = string.Empty, type = "02", no_split_stock = "1", state = "0", transfers_state = "0", create_by = string.Empty, update_by = string.Empty;
            string location_id = string.Empty, carton_code = string.Empty, lot_no = string.Empty, basic_unit = "PCS", unit = "PCS", unit_code = "PCS";
            string shipment_suit = "1", sec_unit = "KG", sequence_id = string.Empty, goods_id = string.Empty, goods_name = string.Empty, mo_id = string.Empty ;
            string deliver = "0", credit_id = string.Empty, credit_seq_id = string.Empty,strError = string.Empty,locationId = string.Empty, itCustomer = string.Empty, selectFlag = string.Empty;            
            int update_count = 1, rate = 1, return_qty = 0, invoice_qty = 0;
            decimal sec_qty = 0;
            StringBuilder sb = new StringBuilder();
            create_by = DBUtility._user_id;
            update_by = create_by;
            bool flagLoop = true, flagOpration = true;//生成單據過程是否成功的標識           
            dtReturn.Clear();

            //設置進度條屬性
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = lstMDL.Count;
            //***************

            foreach (mdlLocationCust lst in lstMDL)
            {
                if (flagLoop == false)
                {
                    flagOpration = false;
                    break; //異常直接退出生成單據
                }
                //************
                //顯示進度條
                progressBar1.Value += progressBar1.Step;                
                //*************
                
                dtFind.Select();
                //生成分類好的單據數據（倉庫+客戶編號），預同一個倉庫、同一個客戶的記錄放在同一張單據中
                aryRows = dtFind.Select(string.Format("location_id='{0}' and it_customer='{1}' and flag_select=true", lst.location_id, lst.it_customer));                
                sb.Clear();
                strError = "";
                for (int i = 0; i < aryRows.Length; i++)
                {
                    if (i == 0)
                    {
                        //主檔
                        doc_id = clsSaleReturn.GetMaxID(strYYMM);//從HKERP1服務器取最大單據編號
                        if (doc_id == "-1")
                        {
                            //取最大編號失敗
                            flagLoop = false;
                            flagOpration = false;
                            strError = "取最大單據編號失敗";
                            break;
                        }
                        return_date = strDatetime.Substring(0, 10); //aryRows[0]["return_date"].ToString();
                        it_customer = aryRows[0]["it_customer"].ToString();
                        name = aryRows[0]["name"].ToString();
                        seller_id = aryRows[0]["cd_seller"].ToString();
                        location_id = aryRows[0]["location_id"].ToString();
                        carton_code = location_id;                        
                        sql_h_i = string.Format(
                        @" Insert Into so_return_mostly(within_code,id,return_date,separate_return,it_customer,name,department_id,seller_id,type,
                        no_split_stock,create_by,create_date,update_by,update_date,state,update_count,transfers_state,location_id,carton_code) VALUES
                        ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',getdate(),'{11}',getdate(),'{12}',{13},'{14}','{15}','{16}')",
                        within_code,doc_id,return_date,separate_return,it_customer,name,department_id,seller_id,type,
                        no_split_stock,create_by,update_by,state,update_count,transfers_state,location_id,carton_code);
                        sb.Append(sql_h_i);
                        //記錄銷貨退回單號
                        DataRow drw = dtReturn.NewRow();
                        drw["doc_id"] = doc_id;
                        dtReturn.Rows.Add(drw);
                    }
                    //明細
                    location_id = aryRows[i]["location_id"].ToString();
                    lot_no = clsSaleReturn.GetDeptLotNo(location_id, location_id); //有可能存DGERP2, HKERP1服務器上取批號數據
                    sequence_id = (i+1).ToString().PadLeft(4,'0')+"d";
                    goods_id = aryRows[i]["goods_id"].ToString();
                    goods_name = aryRows[i]["goods_name"].ToString();
                    return_qty = int.Parse(aryRows[i]["invoice_qty"].ToString());
                    sec_qty = decimal.Parse(aryRows[i]["sec_qty"].ToString());
                    mo_id = aryRows[i]["mo_id"].ToString();
                    sql_d_i = string.Format(
                    @" INSERT INTO so_return_details (within_code,id,sequence_id,goods_id,goods_name,basic_unit,unit,unit_code,rate,return_qty,
                    deliver,invoice_qty,location_id,carton_code,transfers_state,lot_no,sec_unit,sec_qty,mo_id,shipment_suit,return_date) Values 
                    ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},'{12}','{13}','{14}','{15}','{16}',{17},'{18}','{19}','{20}')",
                    within_code,doc_id, sequence_id, goods_id,goods_name, basic_unit, unit,unit_code,rate,return_qty,deliver,invoice_qty,location_id, location_id,
                    transfers_state,lot_no, sec_unit, sec_qty, mo_id, shipment_suit, return_date);
                    sb.Append(sql_d_i);
                    //對Credit Note已完成生成銷貨退回數據，則更新標識，以免重復做
                    credit_id = aryRows[i]["id"].ToString();
                    credit_seq_id = aryRows[i]["sequence_id"].ToString();
                    sql_u = string.Format(
                    @" UPDATE so_debeitcredit_note_details with (rowlock) Set flag_convert='1' Where id='{0}' And within_code='{1}' And sequence_id='{2}'",
                    credit_id, within_code, credit_seq_id);
                    sb.Append(sql_u);
                } //--end of for for 循環結束，表示已生成一張銷貨退回數據

                //--start在HKERP1中生成銷貨退回數據(一個for結束代表一張銷貨退回數據)                
                //SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);//dgerp2
                SqlConnection myCon = new SqlConnection(strConn);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        //主檔明細一起保存
                        myCommand.CommandText = sb.ToString();
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit();
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        flagOpration = false;
                        strError = E.Message;
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }

                if (flagOpration == false)
                {                   
                    break; //提交異常直接退出生成單據
                }

                //start Remove row 已成功轉銷貨退回的CreditNote數據移除 Remove Convert Successfully Record
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    selectFlag = gridView1.GetRowCellValue(i, "flag_select").ToString();
                    locationId = gridView1.GetRowCellValue(i, "location_id").ToString();
                    itCustomer = gridView1.GetRowCellValue(i, "it_customer").ToString();
                    if (selectFlag == "True" && locationId == lst.location_id && itCustomer == lst.it_customer)
                    {
                        gridView1.DeleteRow(i);
                    }
                }
                //--end Remove row
                

                //************
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;
                }
                //************
            } //--end of foreach

            dgvDoc.DataSource = dtReturn;
            if (flagOpration)
            {               
                MessageBox.Show("批量生成銷貨退回數據成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"批量生成銷貨退回數據失敗!({strError})", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dtFind.Rows.Count == 0)
            {
                if (chkSelectAll.Checked)
                {
                    chkSelectAll.Checked = false;
                }
            }
        }

        private void checkBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                chkSelectAll.Checked = false;
                return;
            }
            bool flagSelectAll = chkSelectAll.Checked ? true : false;
            for (int i=0;i< dtFind.Rows.Count; i++)
            {
                dtFind.Rows[i]["flag_select"] = flagSelectAll;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvDoc.Rows.Count > 0)
            {
                ExpToExcel xls = new ExpToExcel();
                //xls.ExportExcel(dgvDoc);host主機不安裝有OFFICE時會報錯
                xls.DataTableToExcel(dtReturn);//host主機不安裝有OFFICE時不會報錯
            }            
        }
    }
}
