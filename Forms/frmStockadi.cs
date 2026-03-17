using cf01.CLS;
using DevExpress.XtraEditors;
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
    public partial class frmStockadi : Form
    {
        DataTable dtDetails = new DataTable();
        DataTable dtTmp = new DataTable();
        DataTable dtMaxId = new DataTable();
        string remote_db = DBUtility.remote_db;
        string strDatetime = clsUtility.GetCurrentDateTime(); //2026-03-09 15:50:02
        bool editMode = false;
        List<string> lstWh = new List<string>();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        clsAppPublic clsApp = new clsAppPublic();
        clsToolBarNew objToolbar ;

        public frmStockadi()
        {
            InitializeComponent();
        }

        private void frmStockadi_Load(object sender, EventArgs e)
        {
            cbeIiLocation.Properties.Items.Clear();
            string strsql = string.Format(
            @"Select a.id,a.issues_date,a.it_customer,a.type,a.group_number,a.cd_seller,b.mo_id,
            b.goods_id,b.goods_name,b.obligate_mo_id,Convert(Int,Isnull(b.issues_qty,0)) As issues_qty,
            Round(Convert(float,Isnull(b.sec_qty,0)),2) As sec_qty,b.ii_location,b.lot_no,
            Convert(Int,Isnull(b.sample_qty,0)) As sample_qty,Convert(bit,0) As remain_flag,
            Round(Convert(float,Isnull(b.remain_qty,0)),2) As remain_qty,a.state
            From {0}so_issues_mostly a, {0}so_issues_details b
            Where a.id=b.id And a.within_code=b.within_code And a.type='ADI' And 1=0 ", DBUtility.remote_db); 
            dtDetails = clsPublicOfCF01.GetDataTable(strsql);
            gridControl1.DataSource = dtDetails;
            SetColumnReadOnly(true);
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                //已是新增狀態
                MessageBox.Show("已是編輯狀態，請直接在掃描區掃描!", "提示信息", MessageBoxButtons.OK);
                return;
            }
            ClearA();
            this.AddNew();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                if (gridView1.RowCount>0)
                {
                    int rowIndex = gridView1.FocusedRowHandle;
                    if (rowIndex >= 0)
                    {
                        string id = "", moId = "", goodsId = "", locationId = "", lotNo = "", issuesQty = "0";
                        id = gridView1.GetRowCellValue(rowIndex, "id").ToString();
                        moId = gridView1.GetRowCellValue(rowIndex, "mo_id").ToString();
                        goodsId = gridView1.GetRowCellValue(rowIndex, "goods_id").ToString();
                        locationId = gridView1.GetRowCellValue(rowIndex, "ii_location").ToString();
                        lotNo = gridView1.GetRowCellValue(rowIndex, "lot_no").ToString();
                        issuesQty = gridView1.GetRowCellValue(rowIndex, "issues_qty").ToString();
                        for (int i = gridView1.RowCount - 1; i >= 0; i--)
                        {
                            if (gridView1.GetRowCellValue(i, "id").ToString() == id &&
                                gridView1.GetRowCellValue(i, "mo_id").ToString() == moId &&
                                gridView1.GetRowCellValue(i, "goods_id").ToString() == goodsId &&
                                gridView1.GetRowCellValue(i, "ii_location").ToString() == locationId &&
                                gridView1.GetRowCellValue(i, "lot_no").ToString() == lotNo &&
                                gridView1.GetRowCellValue(i, "issues_qty").ToString() == issuesQty)
                            {
                                gridView1.DeleteRow(i);//移走當前行
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("非編輯狀態，當前操作無效!", "提示信息", MessageBoxButtons.OK);
                return;
            }
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            //
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (dtDetails.Rows.Count > 0)
            {
                if (Save())
                {
                    //儲存成功接著執行批準
                    bool result = Approve(txtId.Text);
                    if (result)
                    {
                        //成功則修正客戶的狀態，以避免重復保存
                        int curRow = 0;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            curRow = gridView1.GetRowHandle(i);
                            gridView1.SetRowCellValue(curRow, "state", "1");
                        }
                        txtState.Text = "1";
                        gridView1.CloseEditor();
                        SetColumnReadOnly(true);
                        MessageBox.Show("數據保存（批準）成功!", "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("數據批準失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void ClearA()
        {
            //新單全部清空
            txtId.Text = "";
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            txtIssues_qty.Text = "";
            txtSec_qty.Text = "";
            txtMo_id.Text = "";
            txtLot_no.Text = "";
            txtSample_qty.Text = "";
            chkRemain_flag.Checked = false;
            txtRemain_qty.Text = "";
            cbeIiLocation.Properties.Items.Clear();
            cbeIiLocation.EditValue = "";
            txtTotalStockQty.Text = "";
            txtState.Text = "";
            dtDetails.Clear();
        }

        private void ClearB()
        {
            //不清除ID,不清空gridView
            txtGoods_id.Text = "";
            txtGoods_name.Text = "";
            txtIssues_qty.Text = "";
            txtSec_qty.Text = "";
            txtMo_id.Text = "";
            txtLot_no.Text = "";
            txtSample_qty.Text = "";
            chkRemain_flag.Checked = false;
            txtRemain_qty.Text = "";
            txtTotalStockQty.Text = "";
        }

        private void txtGoods_id_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtId.Text == "")
                    {
                        //自動建立新單
                        //ClearA();
                        this.AddNew();
                    }
                    else
                    {
                        //檢查此ID是否已是批準狀態
                        string strsql = string.Format(
                        @"Select a.state From dbo.so_issues_mostly a Where a.id='{0}' And a.within_code='0000' And a.type='ADI'", txtId.Text);
                        string strState = clsErp.ExecuteSqlReturnObject(strsql);
                        if (strState == "1")
                        {
                            MessageBox.Show($"單號【{txtId.Text}】已是批準狀態，當前操作無效!"+ "\n\r\n\r"+"請首先點【新增】按鈕建立一張新單據，然后再掃描！", "提示信息", MessageBoxButtons.OK);
                            SetObjectFocus(txtGoods_id);
                            return;
                        }
                    }
                    if (txtGoods_id.Text.Trim().Length < 18)
                    {
                        ClearB();
                        SetObjectFocus(txtGoods_id);
                        return;
                    }                    
                    cbeIiLocation.Properties.Items.Clear();
                    string sql = string.Format(
                    @"Select a.location_id,a.mo_id,a.goods_id,b.name as goods_name,Convert(int,a.qty) as qty,a.sec_qty,a.lot_no                    
                    From {0}st_details_lot a Inner Join {0}it_goods b ON a.within_code=b.within_code And a.goods_id=b.id
                    Where a.within_code='0000' And a.goods_id='{1}' And a.location_id=a.carton_code And a.carton_code<>'ZZZ' 
                    And location_id>='805' And location_id<='818' And a.qty>0 And a.sec_qty>0 
                    Order by a.update_date",
                    remote_db, txtGoods_id.Text.Trim());
                    dtTmp = clsPublicOfCF01.GetDataTable(sql);
                    lstWh.Clear();                    
                    if (dtTmp.Rows.Count > 0)
                    {
                        txtMo_id.Text = dtTmp.Rows[0]["mo_id"].ToString();
                        txtGoods_name.Text = dtTmp.Rows[0]["goods_name"].ToString();
                        txtSample_qty.Text = "0";
                        txtIssues_qty.Text = "0";
                        txtSec_qty.Text = "0.00";
                        txtLot_no.Text = "";
                        chkRemain_flag.Checked = false;
                        txtRemain_qty.Text = "0";                       
                        if (dtTmp.Rows.Count == 1)
                        {
                            cbeIiLocation.Properties.Items.Add(dtTmp.Rows[0]["location_id"].ToString());
                            txtTotalStockQty.Text = dtTmp.Rows[0]["qty"].ToString();
                        }
                        else
                        {
                            int total_stock_qty = 0;
                            for (int i = 0; i < dtTmp.Rows.Count; i++)
                            {
                                lstWh.Add(dtTmp.Rows[i]["location_id"].ToString());
                                total_stock_qty += int.Parse(dtTmp.Rows[i]["qty"].ToString());
                            }
                            txtTotalStockQty.Text = total_stock_qty.ToString();//統計總庫存數
                            //倉位去重
                            var uniqueList1 = lstWh.Distinct().ToList();
                            foreach (var item in uniqueList1)
                            {
                                cbeIiLocation.Properties.Items.Add(item);
                            }
                        }
                        cbeIiLocation.EditValue = dtTmp.Rows[0]["location_id"].ToString();
                        SetObjectFocus(txtSample_qty);//模擬鼠標點需事件，使控件獲得焦點
                    }
                    else
                    {
                        MessageBox.Show($"當前貨品編號【{txtGoods_id.Text.Trim()}】并無庫存,無法提辦！", "提示信息", MessageBoxButtons.OK);
                        ClearB();
                        SetObjectFocus(txtGoods_id);//模擬鼠標點需事件，使控件獲得焦點
                    }                    
                    break;
            }
        }

        private void SetObjectFocus(TextEdit obj)
        {
            //獲得TextEdit對卻的屏幕坐标
            //模擬鼠標點需事件,使控件獲得焦點
            Point p = obj.PointToScreen(new Point(10, 10));
            MouseSimulator.SimulateClick(p.X, p.Y);
        }      

        private void AddNew()
        {
            SetButtonSatus(false);
            SetColumnReadOnly(false);
            editMode = true;
            string within_code = "0000";
            string bill_code = "", bill_id = "SA02", strSql = "";    
            string yymm = strDatetime.Substring(2, 2) + strDatetime.Substring(5, 2); //"2603";
            string sql = string.Format(
            @"SELECT CONVERT(INT,SUBSTRING(bill_code,8,6)) as bill_code From {0}sys_bill_max_separate
            Where within_code='0000' AND bill_id='SA02' And year_month='{1}' And bill_text1='ADI'", remote_db, yymm);
            dtMaxId = clsPublicOfCF01.GetDataTable(sql);
            if (dtMaxId.Rows.Count > 0)
            {
                bill_code = "ADI" + yymm + (int.Parse(dtMaxId.Rows[0]["bill_code"].ToString()) + 1).ToString().PadLeft(6, '0');
                strSql = string.Format(
                @"Update sys_bill_max_separate with(ROWLOCK) SET bill_code='{0}'
                WHERE within_code='{1}' AND bill_id='{2}' AND year_month='{3}' AND bill_text1='ADI'",
               bill_code, within_code, bill_id, yymm);
            }
            else
            {
                //新年度第一張單
                bill_code = "ADI" + yymm + "000001";                
                strSql = string.Format(
                @"INSERT INTO sys_bill_max_separate (within_code,bill_id,year_month,bill_code,bill_text1,bill_text2,bill_text3,bill_text4,bill_text5)
                VALUES('{0}', '{1}', '{2}', '{3}', 'ADI', '', '', '', '')",
                within_code, bill_id, yymm, bill_code);
            }
            int result = clsErp.ExecuteSqlUpdate(strSql);
            if (result > 0)
            {
                txtId.Text = bill_code;
                txtState.Text = "0";
            }
        }

        private void txtSample_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if(txtSample_qty.Text =="0" || txtSample_qty.Text == "")
                {
                    return;
                }
                if (txtTotalStockQty.Text == "0" || txtTotalStockQty.Text == "")
                {
                    return;
                }
                int tmp_sample_qty = int.Parse(txtSample_qty.Text.Replace(",", ""));
                int tmp_total_stock_qty = int.Parse(txtTotalStockQty.Text.Replace(",", ""));
                if (tmp_sample_qty > 0 && tmp_total_stock_qty > 0)
                {
                    if (tmp_sample_qty <= tmp_total_stock_qty)
                    {
                        SetItems();
                        ClearB();
                        SetObjectFocus(txtGoods_id);//設置txtGoods_id焦點
                    }
                    else
                    {
                        MessageBox.Show("提倉數量不可大于總庫存數量！","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SetObjectFocus(txtSample_qty);//設置txtGoods_id焦點
                    }
                }
                
            }
        }

        private void SetItems()
        {
            if (editMode && dtTmp.Rows.Count > 0)
            {
                string sample_qty = txtSample_qty.Text; //暫存ample_qty
                //已存在的先刪除，再重新添加進來
                DelItems(); //當貨品編號庫存只有一條對應記錄時DelItems()會清除txtSample_qty.Text的值，所以執行DelItems()前先暫存txtSample_qty.Text的值;
                txtSample_qty.Text = sample_qty; //還原暫存ample_qty
                AddItems();
            }
        }

        private void AddItems()
        {
            int sampleQty = 0, issuesQty = 0, cnt = 0, total_sample_qty = 0, tmp_qty = 0, current_qty = 0;
            bool remainFlag = false;
            sampleQty = string.IsNullOrEmpty(txtSample_qty.Text) ? 0 : int.Parse(txtSample_qty.Text.Replace(",",""));
            issuesQty = int.Parse(dtTmp.Rows[0]["qty"].ToString());
            cnt = dtTmp.Rows.Count;
            if (sampleQty > 0)
            {
                DataRow dr = null;
                if (cnt == 1)
                {
                    if (sampleQty <= issuesQty)
                    {
                        txtIssues_qty.Text = dtTmp.Rows[0]["qty"].ToString();
                        txtSec_qty.Text = dtTmp.Rows[0]["sec_qty"].ToString();
                        dr = dtDetails.NewRow();
                        dr["id"] = txtId.Text;
                        dr["mo_id"] = dtTmp.Rows[0]["mo_id"].ToString(); 
                        dr["goods_id"] = dtTmp.Rows[0]["goods_id"].ToString();
                        dr["goods_name"] = dtTmp.Rows[0]["goods_name"].ToString();
                        dr["ii_location"] = cbeIiLocation.Text;
                        dr["sample_qty"] = sampleQty;
                        dr["issues_qty"] = sampleQty;
                        dr["sec_qty"] = RetrunWeight(sampleQty, decimal.Parse(dtTmp.Rows[0]["sec_qty"].ToString()), int.Parse(dtTmp.Rows[0]["qty"].ToString()));
                        dr["lot_no"] = dtTmp.Rows[0]["lot_no"].ToString();
                        remainFlag = chkRemain_flag.Checked ? true : false;
                        dr["remain_flag"] = remainFlag;
                        dr["remain_qty"] = string.IsNullOrEmpty(txtRemain_qty.Text) ? 0 : int.Parse(txtRemain_qty.Text.Replace(",", ""));
                        dr["state"] = txtState.Text;
                        dtDetails.Rows.Add(dr);
                    }
                }
                else
                {
                    if (sampleQty <= issuesQty)
                    {
                        //第一筆就夠扣除
                        dr = dtDetails.NewRow();
                        dr["id"] = txtId.Text;
                        dr["mo_id"] = dtTmp.Rows[0]["mo_id"].ToString();
                        dr["goods_id"] = dtTmp.Rows[0]["goods_id"].ToString();
                        dr["goods_name"] = dtTmp.Rows[0]["goods_name"].ToString(); 
                        dr["ii_location"] = cbeIiLocation.Text;
                        dr["sample_qty"] = sampleQty;
                        dr["issues_qty"] = sampleQty;
                        dr["sec_qty"] = RetrunWeight(sampleQty, decimal.Parse(dtTmp.Rows[0]["sec_qty"].ToString()), int.Parse(dtTmp.Rows[0]["qty"].ToString()));
                        dr["lot_no"] = dtTmp.Rows[0]["lot_no"].ToString();
                        remainFlag = chkRemain_flag.Checked ? true : false;
                        dr["remain_flag"] = remainFlag;
                        dr["remain_qty"] = string.IsNullOrEmpty(txtRemain_qty.Text) ? 0 : int.Parse(txtRemain_qty.Text.Replace(",", ""));
                        dr["state"] = txtState.Text;
                        dtDetails.Rows.Add(dr);
                        return;
                    }
                    else
                    {
                        //至少從兩筆以上記錄中扣除
                        total_sample_qty = 0;
                        tmp_qty = sampleQty; //tmp_qty:臨時的提倉數量
                        current_qty = 0;
                        for (int i = 0; i < dtTmp.Rows.Count; i++)
                        {
                            current_qty = int.Parse(dtTmp.Rows[i]["qty"].ToString());
                            if (tmp_qty > current_qty)
                            {
                                total_sample_qty += current_qty; //累計扣減的數量
                                dr = dtDetails.NewRow();
                                dr["id"] = txtId.Text;
                                dr["mo_id"] = dtTmp.Rows[i]["mo_id"].ToString();
                                dr["goods_id"] = dtTmp.Rows[i]["goods_id"].ToString();
                                dr["goods_name"] = dtTmp.Rows[i]["goods_name"].ToString();
                                dr["ii_location"] = cbeIiLocation.Text;
                                dr["sample_qty"] = sampleQty;
                                dr["issues_qty"] = current_qty;
                                dr["sec_qty"] = RetrunWeight(current_qty, decimal.Parse(dtTmp.Rows[i]["sec_qty"].ToString()), int.Parse(dtTmp.Rows[i]["qty"].ToString()));
                                dr["lot_no"] = dtTmp.Rows[i]["lot_no"].ToString();
                                remainFlag = chkRemain_flag.Checked ? true : false;
                                dr["remain_flag"] = remainFlag;
                                dr["remain_qty"] = string.IsNullOrEmpty(txtRemain_qty.Text) ? 0 : int.Parse(txtRemain_qty.Text.Replace(",", ""));
                                dr["state"] = txtState.Text;
                                dtDetails.Rows.Add(dr);
                                tmp_qty = sampleQty - total_sample_qty; //還剩余需要扣除的數量
                            }
                            else
                            {
                                if (tmp_qty > 0)
                                {
                                    //tmp_qty（還需扣除數）小計當前記錄倉存數
                                    current_qty = int.Parse(dtTmp.Rows[i]["qty"].ToString());
                                    if (tmp_qty > current_qty)
                                    {
                                        total_sample_qty += current_qty; //total_sample_qty為累計已分批扣減的數量
                                        dr = dtDetails.NewRow();
                                        dr["id"] = txtId.Text;
                                        dr["mo_id"] = dtTmp.Rows[i]["mo_id"].ToString();
                                        dr["goods_id"] = dtTmp.Rows[i]["goods_id"].ToString();
                                        dr["goods_name"] = dtTmp.Rows[i]["goods_name"].ToString();
                                        dr["ii_location"] = cbeIiLocation.Text;
                                        dr["sample_qty"] = sampleQty;
                                        dr["issues_qty"] = current_qty;
                                        dr["sec_qty"] = RetrunWeight(current_qty, decimal.Parse(dtTmp.Rows[i]["sec_qty"].ToString()), int.Parse(dtTmp.Rows[i]["qty"].ToString()));
                                        dr["lot_no"] = dtTmp.Rows[i]["lot_no"].ToString();
                                        remainFlag = chkRemain_flag.Checked ? true : false;
                                        dr["remain_flag"] = remainFlag;
                                        dr["remain_qty"] = string.IsNullOrEmpty(txtRemain_qty.Text) ? 0 : int.Parse(txtRemain_qty.Text.Replace(",", ""));
                                        dr["state"] = txtState.Text;
                                        dtDetails.Rows.Add(dr);
                                        tmp_qty = sampleQty - total_sample_qty; //tmp_qty為未結束還需繼續要扣除的數量
                                    }
                                    else
                                    {
                                        total_sample_qty += tmp_qty; //total_sample_qty為累計已分批扣減的數量
                                        dr = dtDetails.NewRow();
                                        dr["id"] = txtId.Text;
                                        dr["mo_id"] = dtTmp.Rows[i]["mo_id"].ToString();
                                        dr["goods_id"] = dtTmp.Rows[i]["goods_id"].ToString(); ;
                                        dr["goods_name"] = dtTmp.Rows[i]["goods_name"].ToString(); ;
                                        dr["ii_location"] = cbeIiLocation.Text;
                                        dr["sample_qty"] = sampleQty;
                                        dr["issues_qty"] = tmp_qty;
                                        dr["sec_qty"] = RetrunWeight(tmp_qty, decimal.Parse(dtTmp.Rows[i]["sec_qty"].ToString()), int.Parse(dtTmp.Rows[i]["qty"].ToString()));                                            
                                        dr["lot_no"] = dtTmp.Rows[i]["lot_no"].ToString();
                                        remainFlag = chkRemain_flag.Checked ? true : false;
                                        dr["remain_flag"] = remainFlag;
                                        dr["remain_qty"] = string.IsNullOrEmpty(txtRemain_qty.Text) ? 0 : int.Parse(txtRemain_qty.Text.Replace(",", ""));
                                        dr["state"] = txtState.Text;
                                        dtDetails.Rows.Add(dr);
                                        tmp_qty = sampleQty - total_sample_qty; //還剩余需要扣除的數量
                                    }
                                }
                                else
                                {
                                    //扣除完成則退出循環
                                    break;
                                }
                            }
                        }
                    }
                }
                dtTmp.Clear();                
                txtGoods_id.Text = "";
            }
        }

        private void DelItems()
        {
            if(txtId.Text != "" && txtGoods_id.Text !="" && cbeIiLocation.Text != "")
            {
                string id = "", goodsId = "", locationId = "";
                id = txtId.Text;
                goodsId = txtGoods_id.Text.Trim();
                locationId = cbeIiLocation.Text;
                //采用倒序循环刪除,因为正序删除时索引会发生变化
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.GetRowCellValue(i, "goods_id").ToString() == goodsId && gridView1.GetRowCellValue(i, "ii_location").ToString() == locationId)
                    {
                        gridView1.DeleteRow(i);//移走當前行
                    }
                }
            }
        }

        private decimal RetrunWeight(int curent_qty,decimal sec_qty,int qty)
        {
            decimal weight = Math.Round((curent_qty * sec_qty) / qty, 2);
            return weight;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            if (i >= 0)
            {
                txtId.Text = gridView1.GetRowCellValue(i, "id").ToString();
                txtMo_id.Text = gridView1.GetRowCellValue(i, "mo_id").ToString();
                txtSample_qty.Text = gridView1.GetRowCellValue(i, "sample_qty").ToString();
                txtIssues_qty.Text = gridView1.GetRowCellValue(i, "issues_qty").ToString();             
                txtSec_qty.Text = gridView1.GetRowCellValue(i, "sec_qty").ToString(); 
                txtLot_no.Text = gridView1.GetRowCellValue(i, "lot_no").ToString();
                string reminFlag = "";
                reminFlag = gridView1.GetRowCellValue(i, "remain_flag").ToString();
                chkRemain_flag.Checked = (reminFlag == "" || reminFlag == "False") ? false : true;                
                txtRemain_qty.Text = gridView1.GetRowCellValue(i, "remain_qty").ToString();
                txtState.Text = gridView1.GetRowCellValue(i, "state").ToString();
            }
            else
            {
                //txtId.Text = "";
                txtMo_id.Text = "";
                txtSample_qty.Text = "0";
                txtIssues_qty.Text = "0";
                txtSec_qty.Text = "0.00";
                txtLot_no.Text = "";
                chkRemain_flag.Checked = false ;
                txtRemain_qty.Text = "0";
                txtState.Text = "0";
            }
            txtGoods_id.Text = "";
        }


        private void colRemainQty_MouseUp(object sender, MouseEventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }

        private void SetButtonSatus(bool _flag) 
        {
            //設置工具欄
            BTNNEW.Enabled = _flag;           
            BTNDELETE.Enabled = !_flag;
            BTNSAVE.Enabled = !_flag;
            BTNFIND.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            //BTNEDIT.Enabled = _flag;
            //BTNAPPROVE.Enabled = _flag;            
            if (objToolbar != null)
            {
                objToolbar.SetToolBar();
            }
        }

        private void SetColumnReadOnly(bool _flag)
        {
            this.remain_flag.OptionsColumn.ReadOnly = _flag;
            this.remain_qty.OptionsColumn.ReadOnly = _flag;
        }

        private bool Save()
        {
            bool saveFlag = false;
            string within_code = "0000", strIssuesDate = string.Empty;
            if (editMode)
            {
                SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);//dgerp2
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        //保存主檔
                        string sql_i =
                        @"INSERT INTO so_issues_mostly(within_code,id,issues_date,separate_issues,it_customer,name,type,group_number,update_count,transfers_state,servername,create_by,create_date) 
                        VALUES(@within_code,@id,@issues_date,@separate_issues,@it_customer,@name,@type,@group_numbe,@update_count,@transfers_state,@servername,@user_id,getdate())";
                        myCommand.CommandText = sql_i;                        
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", within_code);
                        myCommand.Parameters.AddWithValue("@id", txtId.Text);
                        strIssuesDate = clsUtility.GetCurrentDateTime();
                        myCommand.Parameters.AddWithValue("@issues_date", clsApp.Return_String_Date(strIssuesDate.Substring(0,10)));
                        myCommand.Parameters.AddWithValue("@separate_issues", "1");
                        myCommand.Parameters.AddWithValue("@it_customer", "CF_FAI");
                        myCommand.Parameters.AddWithValue("@name", "CF_FAI");
                        myCommand.Parameters.AddWithValue("@type", "ADI");
                        myCommand.Parameters.AddWithValue("@group_numbe", "0");
                        myCommand.Parameters.AddWithValue("@update_count", "1");
                        myCommand.Parameters.AddWithValue("@transfers_state", "0");
                        myCommand.Parameters.AddWithValue("@servername", "hkserver.cferp.dbo");
                        myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                        myCommand.ExecuteNonQuery();                        
                        //保存明細
                        int curRow;
                        string rowStatus = string.Empty;
                        if (gridView1.RowCount > 0)
                        {
                            string sql_item_i =
                            @"INSERT INTO dbo.so_issues_details
                            (within_code,id,sequence_id,order_id,so_sequence_id,goods_id,customer_goods, goods_name,issues_unit,unit_rate,issues_qty,check_qty,eligible_qty,
                            unqualified_qty,invoice_qty,use_invoice,order_issues_qty,return_qty,exchange_rate,ii_location,carton_code,transfers_state,s_address,present_qty,
                            fact_qty,sec_qty,sec_unit,lot_no,mo_id,shipment_suit,piece_num,state,obligate_mo_id,package_no,sample_qty,remain_qty,remain_flag) VALUES
                            (@within_code,@id,@sequence_id,@order_id,@so_sequence_id,@goods_id,@customer_goods,@goods_name,@issues_unit,@unit_rate,
                            @issues_qty,@check_qty,@eligible_qty,@unqualified_qty,@invoice_qty,@use_invoice,@order_issues_qty,@return_qty,@exchange_rate,@ii_location,@carton_code,
                            @transfers_state,@s_address, @present_qty, @fact_qty, @sec_qty,@sec_unit,@lot_no,@mo_id,@shipment_suit, @piece_num, @state,@obligate_mo_id,@package_no,
                            @sample_qty,@remain_qty,@remain_flag)";                            
                            gridView1.CloseEditor();
                            string remainFlag = string.Empty, seq_id = string.Empty;
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                seq_id = (i + 1).ToString().PadLeft(4, '0') + "h";                                
                                curRow = gridView1.GetRowHandle(i);
                                gridView1.SetRowCellValue(curRow, "sequence_id", seq_id);
                                //dgvDetails.AddNewRow();//新增必須初始貨當前單元格焦點
                                //否則rowStatus取不到狀態值
                                rowStatus = gridView1.GetDataRow(curRow).RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    myCommand.CommandText = sql_item_i;
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@within_code", within_code);
                                    myCommand.Parameters.AddWithValue("@id", txtId.Text);
                                    myCommand.Parameters.AddWithValue("@sequence_id", seq_id);
                                    myCommand.Parameters.AddWithValue("@order_id", "");
                                    myCommand.Parameters.AddWithValue("@so_sequence_id", "");
                                    myCommand.Parameters.AddWithValue("@goods_id", gridView1.GetRowCellValue(curRow, "goods_id").ToString());
                                    myCommand.Parameters.AddWithValue("@customer_goods", "");
                                    myCommand.Parameters.AddWithValue("@goods_name", gridView1.GetRowCellValue(curRow, "goods_name").ToString());
                                    myCommand.Parameters.AddWithValue("@issues_unit", "PCS");
                                    myCommand.Parameters.AddWithValue("@unit_rate", 1);
                                    myCommand.Parameters.AddWithValue("@issues_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "issues_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@check_qty", 0);
                                    myCommand.Parameters.AddWithValue("@eligible_qty", 0);
                                    myCommand.Parameters.AddWithValue("@unqualified_qty", 0);
                                    myCommand.Parameters.AddWithValue("@invoice_qty", 0);
                                    myCommand.Parameters.AddWithValue("@use_invoice", 0);
                                    myCommand.Parameters.AddWithValue("@order_issues_qty", 0);
                                    myCommand.Parameters.AddWithValue("@return_qty", 0);
                                    myCommand.Parameters.AddWithValue("@exchange_rate", 1);
                                    myCommand.Parameters.AddWithValue("@ii_location", gridView1.GetRowCellValue(curRow, "ii_location").ToString());
                                    myCommand.Parameters.AddWithValue("@carton_code", gridView1.GetRowCellValue(curRow, "ii_location").ToString());
                                    myCommand.Parameters.AddWithValue("@transfers_state", "0");
                                    myCommand.Parameters.AddWithValue("@s_address", "P");
                                    myCommand.Parameters.AddWithValue("@present_qty", 0);
                                    myCommand.Parameters.AddWithValue("@fact_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "issues_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "sec_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@sec_unit", "KG");
                                    myCommand.Parameters.AddWithValue("@lot_no", gridView1.GetRowCellValue(curRow, "lot_no").ToString());
                                    myCommand.Parameters.AddWithValue("@mo_id", gridView1.GetRowCellValue(curRow, "mo_id").ToString());
                                    myCommand.Parameters.AddWithValue("@shipment_suit", "0");
                                    myCommand.Parameters.AddWithValue("@piece_num", 0);
                                    myCommand.Parameters.AddWithValue("@state", "0");
                                    myCommand.Parameters.AddWithValue("@obligate_mo_id", gridView1.GetRowCellValue(curRow, "mo_id").ToString());
                                    myCommand.Parameters.AddWithValue("@package_no", "");
                                    myCommand.Parameters.AddWithValue("@sample_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "sample_qty").ToString()));
                                    myCommand.Parameters.AddWithValue("@remain_qty", clsApp.Return_Float_Value(gridView1.GetRowCellValue(curRow, "remain_qty").ToString()));
                                    //myCommand.Parameters.AddWithValue("@expiry_date", clsApp.Return_String_Date(gridView1.GetRowCellValue(curRow, "expiry_date").ToString()));
                                    if (gridView1.GetRowCellValue(curRow, "remain_flag").ToString() == "False")
                                        remainFlag = "0";
                                    else
                                        remainFlag = "1";
                                    myCommand.Parameters.AddWithValue("@remain_flag", remainFlag);
                                    myCommand.ExecuteNonQuery();
                                } // -- if (rowStatus==)
                            } // -- end for()
                        } // -- if(gridView1.RowCount > 0)
                        //myTrans.Rollback(); //數據回滾
                        myTrans.Commit(); //數據提交
                        saveFlag = true;
                    }  // -- end try
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        saveFlag = false;
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                    }
                } //-- end using (SqlCommand myCommand =)
                editMode = false;
                SetButtonSatus(true);
            } // -- end if (editMode)
            return saveFlag;
        } // -- end save

        private bool Approve(string id)
        {
            bool result = false;
            //start 202600314不用考虑套件出货.出货界面中输入什么货品就扣减什么货品的库存
            string gs_commany = "0000", ls_id = "", ldt_check_date = "", ls_error = "", strResult = "";
            ls_id = id;
            ldt_check_date = clsUtility.GetCurrentDateTime();
            string sql_u = string.Format(
            @"Insert Into st_business_record(within_code,id,sequence_id,goods_id,goods_name,unit,base_unit,rate,price,currency,action_time,
                    action_id,ii_qty,ii_location_id,ii_code,remark,customer_id,check_date,
                    ib_qty,qty,sec_qty,sec_unit,lot_no, mo_id,
                    dept_id, bill_type, so_id, so_sequence_id, servername)
            Select A.within_code,A.id,A.sequence_id,A.goods_id,A.goods_name,A.issues_unit,A.basic_unit,A.unit_rate,A.price,A.cd_money,'{2}' as action_time,
					'11' as action_id,A.issues_qty,A.ii_location,A.carton_code,A.remark,B.it_customer,'{3}',
					dbo.FN_CHANGE_UNITBYCV(A.within_code, A.goods_id, A.issues_unit, 1, '', '', '*'),
					round(dbo.FN_CHANGE_UNITBYCV(A.within_code, A.goods_id, A.issues_unit, A.issues_qty, '', '', '/'), 4),
					A.sec_qty,A.sec_unit,A.lot_no,A.mo_id,
					B.department_id,B.type,A.order_id,A.so_sequence_id,B.servername
            From    so_issues_details A ,so_issues_mostly B 
            Where   A.id=B.id And A.within_code=B.within_code And B.id ='{0}' And B.within_code='{1}'", 
                    ls_id,gs_commany, ldt_check_date.Substring(0,10), ldt_check_date);
            int rtn = clsErp.ExecuteSqlUpdate(sql_u);
            if(rtn >=0)
            {
                //扣除库存
                PubFunDAL pubFun = new PubFunDAL();
                strResult = pubFun.of_update_st_details("I", "11", ls_id, "*", ldt_check_date, ls_error);
                if (strResult.Substring(0, 2) == "00")
                {
                    //更新库存成功,則更新主表批準狀態
                    sql_u = string.Format(@"Update so_issues_mostly Set state='1',check_by='{2}',check_date='{3}' WHERE id='{0}' And within_code='{1}'", 
                    ls_id, gs_commany,DBUtility._user_id, ldt_check_date);
                    clsErp.ExecuteSqlUpdate(sql_u);
                    result = true;
                }
                else
                {
                    //扣除库存失敗,則刪除交易記錄
                    string ls_action_id = "11";
                    sql_u = string.Format(@"Delete FROM st_business_record WHERE within_code='{0}' and action_id='{1}' And id='{2}'", gs_commany, ls_action_id, ls_id);
                    clsErp.ExecuteSqlUpdate(sql_u);
                    result = false;
                    MessageBox.Show($"編號【{txtId.Text.Trim()}】批準失敗！"+ "\n\r\n\r" + "失敗原因：" +"\n\r"+ strResult, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            return result;
        }

       
    }
}
