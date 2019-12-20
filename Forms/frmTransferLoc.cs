using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.IO;
using System.Threading;
using DevExpress.XtraEditors;
using cf01.Forms;
using cf01.Reports;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmTransferLoc : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private clsTransferLoc clsTransferLoc = new clsTransferLoc();
        private string within_code = DBUtility.within_code;
        private string _userid = DBUtility._user_id;
        public frmTransferLoc()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnConf.Enabled = true;
            btnDel.Enabled = false;
            findData(1);//未轉倉記錄
        }
        private void findData(int sl_type)
        {
            string strSql = "";
            if (sl_type == 1)//未轉倉記錄
            {
                strSql = "Select a.id,Convert(Varchar(20),a.con_date,111) As con_date,a.out_dept,a.in_dept" +
                    ",b.sequence_id,b.mo_id,b.goods_id,c.name As goods_name,b.lot_no,Convert(INT,b.con_qty) As con_qty,Convert(numeric(18,2),b.sec_qty) As sec_qty" +
                    ",d.qty st_qty,d.sec_qty As st_weg" +
                    " From jo_materiel_con_mostly a" +
                    " Inner Join jo_materiel_con_details b On a.within_code=b.within_code And a.id=b.id" +
                    " Inner Join st_details_lot d On a.within_code=d.within_code And a.in_dept=d.location_id And a.in_dept=d.carton_code And b.goods_id=d.goods_id And b.lot_no=d.lot_no And b.mo_id=d.mo_id" +
                    " Left Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                    " Where a.within_code='" + within_code + "'";
                if (clsValidRule.CheckDateFormat(this.mktDat1.Text) && clsValidRule.CheckDateFormat(this.mktDat2.Text))
                {
                    strSql += " And a.con_date>='" + mktDat1.Text + "' And a.con_date<'" + Convert.ToDateTime(mktDat2.Text).AddDays(1).ToString("yyyy/MM/dd") + "'";
                }
                if (txtId1.Text != "" && txtId2.Text != "")
                    strSql += " And a.id>='" + txtId1.Text + "' And a.id<='" + txtId2.Text + "'";
                if (txtTdep.Text != "")
                    strSql += " And a.in_dept='" + txtTdep.Text + "'";
                if (txtFdep.Text != "")
                    strSql += " And a.out_dept='" + txtFdep.Text + "'";
                if(txtMo_id.Text.Trim()!="")
                    strSql += " And b.mo_id='" + txtMo_id.Text + "'";
                if (txtGoods_id.Text.Trim() != "")
                    strSql += " And b.goods_id='" + txtGoods_id.Text + "'";
            }
            else if (sl_type == 2)////已轉倉記錄
            {
                strSql = "Select a.id,Convert(Varchar(20),a.inventory_date,111) As con_date,b.inventory_issuance As out_dept,b.inventory_receipt As in_dept" +
                ",b.sequence_id,b.mo_id,b.goods_id,c.name As goods_name,b.ii_lot_no As lot_no,Convert(INT,b.i_amount) As con_qty,Convert(numeric(18,2),b.i_weight) As sec_qty" +
                ",d.qty As st_qty,d.sec_qty As st_weg" +
                " From st_inventory_mostly a" +
                " Inner Join st_i_subordination b On a.within_code=b.within_code And a.id=b.id" +
                " Left Join st_details_lot d On b.within_code=d.within_code And b.inventory_issuance=d.location_id And b.inventory_issuance=d.carton_code And b.goods_id=d.goods_id And b.ii_lot_no=d.lot_no And b.mo_id=d.mo_id" +
                " Left Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                " Where a.within_code='" + within_code + "'";
                //if (clsValidRule.CheckDateFormat(mktTdat.Text))
                //{
                //    strSql += " And a.inventory_date>='" + mktTdat.Text + "' And a.inventory_date<'" + Convert.ToDateTime(mktTdat.Text).AddDays(1).ToString("yyyy/MM/dd") + "'";
                //}
                if (txtTid.Text != "")
                    strSql += " And a.id='" + txtTid.Text + "'";
            }
            else if (sl_type == 3)////已轉倉記錄
            {
            }
            strSql += " Order By a.id,b.sequence_id";
            DataTable dtStoreList = clsConErp.GetDataTable(strSql);
            DataTable dtDetails;
            dtDetails = dtStoreList.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据；
            DataRow[] rows;
            if (sl_type == 1)//如果是轉倉，則要過濾庫存為0的記錄
                rows = dtStoreList.Select("st_qty<>0 and st_weg<>0"); 
            else
                rows = dtStoreList.Select(); 
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
            {
                dtDetails.Rows.Add(row.ItemArray);

            }


            dgvDetails.DataSource = dtDetails;
            dgvDetails.Refresh();
            chkSelectAll.Checked = false;
        }

        private void frmTransferLoc_Load(object sender, EventArgs e)
        {
            mktDat1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            mktDat2.Text = mktDat1.Text;
            mktTdat.Text = mktDat1.Text;

            DataTable dtLoc = new DataTable();
            string strSql = @" select * from int09 where int9loc>='Y' and int9loc<'YZZZ' ";
            dtLoc = clsPublicOfPad.GetDataTable(strSql);
            dtLoc.Rows.Add();
            dtLoc.DefaultView.Sort = "int9loc";

            cmbTloc.DataSource = dtLoc;
            cmbTloc.DisplayMember = "int9loc";
            cmbTloc.ValueMember = "int9loc";
            cmbTloc.SelectedValue = "Y2F";
            txtTdep.Text = "805";
            //txtTid.Text = "DAB00010003";
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            SelectAllRecord();
        }
        private void SelectAllRecord()
        {
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                dgvDetails.Rows[i].Cells["colChk"].Value = chkSelectAll.Checked;
            }
        }
        private void btnGenDoc_Click(object sender, EventArgs e)
        {
            addNewDoc();
        }

        private void addNewDoc()
        {
            if (!checkNewDoc())
                return;
            mdlTransferLoc objModel = new mdlTransferLoc();
            objModel.con_date = mktTdat.Text;//"2000/01/01";
            objModel.crusr = _userid;
            txtTid.Text = clsTransferLoc.AddNewDoc(objModel);
            if (txtTid.Text != "")
                MessageBox.Show("建立新單成功!");
            else
                MessageBox.Show("建立新單失敗!");
        }
        private bool checkNewDoc()
        {
            bool result = true;
            if (!clsValidRule.CheckDateFormat(mktTdat.Text.Trim()))
            {
                MessageBox.Show("轉倉日期不正確!");
                return false;
            }

            return result;
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            txtTid.Focus();

            //frmProgress wForm = new frmProgress();
            //new Thread((ThreadStart)delegate
            //{
            //    wForm.TopMost = true;
            //    wForm.ShowDialog();
            //}).Start();

            addStoreDetails();
            //wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            
        }
        private void addStoreDetails()
        {
            if (!checkNewDoc())
                return;
            if (!checkStoreDetails(1))
                return;
            string result = "";
            List<mdlTransferLoc> listDetail = new List<mdlTransferLoc>();

            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["colChk"].Value!=null && (bool)dgvDetails.Rows[i].Cells["colChk"].Value == true)
                {
                    mdlTransferLoc objModel = new mdlTransferLoc();
                    objModel.id = txtTid.Text;
                    objModel.mo_id = dgvDetails.Rows[i].Cells["colMo_id"].Value.ToString();
                    objModel.goods_id = dgvDetails.Rows[i].Cells["colGoods_id"].Value.ToString();
                    objModel.obligate_mo_id = objModel.mo_id;
                    objModel.qty = Convert.ToSingle(dgvDetails.Rows[i].Cells["colSt_qty"].Value.ToString());
                    objModel.weg = Convert.ToSingle(dgvDetails.Rows[i].Cells["colSt_weg"].Value.ToString());
                    objModel.lot_no = dgvDetails.Rows[i].Cells["colLot_no"].Value.ToString();
                    objModel.loc = dgvDetails.Rows[i].Cells["colTdep"].Value.ToString();
                    objModel.so_no = dgvDetails.Rows[i].Cells["colId"].Value.ToString();
                    objModel.so_sequence_id = dgvDetails.Rows[i].Cells["colSeq"].Value.ToString();
                    objModel.t_dep = cmbTloc.SelectedValue.ToString();
                    objModel.crusr = _userid;

                listDetail.Add(objModel);
                }
            }
            if (listDetail.Count == 0)
            {
                MessageBox.Show("沒有選取轉倉記錄!");
                return;
            }
            result = clsTransferLoc.AddStoreRec(listDetail);



            if (result != "")
            {
                findData(2);
                if (chkAutoSave.Checked == false)//如果是條碼錄入的，則不用顯示以下提示，以提高錄入速度
                    MessageBox.Show("生成轉倉記錄成功!");
                chkSelectAll.Checked = false;
                btnConf.Enabled = false;
                btnDel.Enabled = true;
            }
            else
                MessageBox.Show("生成轉倉記錄失敗!");
        }

        private bool checkStoreDetails(int sl_type)
        {
            bool result = true;
            DataTable dtId = clsTransferLoc.checkDocStatus(txtTid.Text);
            if (dtId.Rows.Count == 0)
            {
                MessageBox.Show("單據編號不存在!");
                return false;
            }
            else
            {
                if (dtId.Rows[0]["state"].ToString() != "0")
                {
                    MessageBox.Show("單據編號已批準，不能再進行輸入!");
                    return false;
                }
            }
            if (sl_type == 2)//如果是刪除記錄，不執行以下
                return result;
            if (txtTid.Text == "")
            {
                MessageBox.Show("轉倉單號不能為空!");
                return false;
            }
            if (cmbTloc.SelectedValue == null || cmbTloc.SelectedValue.ToString() == "")
            {
                MessageBox.Show("轉入倉不能為空,請重新輸入!");
                return false;
            }
            
            
            
            
            
            return result;
        }

        private void btnFind1_Click(object sender, EventArgs e)
        {
            btnConf.Enabled = false;
            btnDel.Enabled = true;
            findData(2);//已轉倉記錄
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtTid.Focus();
            delStoreDetails();
        }

        private void delStoreDetails()
        {
            if (!checkStoreDetails(2))
                return;
            int result = 0;
            string strSql="";
            string id = "";
            string seq = "";
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["colChk"].Value != null && (bool)dgvDetails.Rows[i].Cells["colChk"].Value == true)
                {
                    id = dgvDetails.Rows[i].Cells["colId"].Value.ToString();
                    seq = dgvDetails.Rows[i].Cells["colSeq"].Value.ToString();
                    strSql += string.Format(@"Delete From st_i_subordination Where within_code='{0}' And id='{1}' And sequence_id='{2}'"
                    , within_code, id, seq);
                }
            }

            if (strSql != "")
            {
                result = clsConErp.ExecuteSqlUpdate(strSql);
                if (result == 0)
                    MessageBox.Show("刪除記錄失敗!");
                else
                {
                    findData(2);
                    MessageBox.Show("刪除記錄成功!");
                    btnConf.Enabled = false;
                    btnDel.Enabled = false;
                }
            }
            else
                MessageBox.Show("沒有選取刪除的記錄!");
        }

        private void mktDat1_Leave(object sender, EventArgs e)
        {
            mktDat2.Text = mktDat1.Text;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    string strbarcode = txtBarCode.Text.Trim().ToUpper();
                    if (strbarcode.Length == 13)//如果是12位的條形碼，就要通過計劃查找出物料編號、部門等記錄
                    {
                        DataTable dtItem = clsPublicOfPad.BarCodeToItem(strbarcode);
                        if (dtItem.Rows.Count > 0)
                        {
                            txtFdep.Text = dtItem.Rows[0]["wp_id"].ToString().Trim();
                            txtTdep.Text = dtItem.Rows[0]["next_wp_id"].ToString().Trim();
                            txtMo_id.Text = strbarcode.Substring(0, 9);
                            txtGoods_id.Text = dtItem.Rows[0]["goods_id"].ToString().Trim();
                            mktDat1.Text = "";
                            mktDat2.Text = "";
                            btnConf.Enabled = true;
                            btnDel.Enabled = false;
                            findData(1);//未轉倉記錄
                            if (chkAutoSave.Checked == true)//掃描後自動儲存記錄
                            {
                                chkSelectAll.Checked = true;
                                SelectAllRecord();
                                addStoreDetails();
                                txtBarCode.Focus();
                            }
                        }
                    }
                    txtBarCode.Text = "";
                    break;
            }
        }
    }
}
