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

namespace cf01.ST
{
    public partial class frmDeliveryDetail : Form
    {
        private int BarCodeMinLength = 10;
        private DataTable dtTranDetails = new DataTable();
        private DataTable dtTranDetailsPart = new DataTable();
        private clsDataTableTextBoxBinder binder;

        public frmDeliveryDetail()
        {
            InitializeComponent();

            // 订阅事件
            clsGlobalScanner.BarcodeScanned += OnBarcodeScanned;

            // 窗体激活时，设置为当前接收窗体
            this.Activated += (s, e) => clsGlobalScanner.SetActiveForm(this);

            // 窗体失去焦点时，清除（可选）
            this.Deactivate += (s, e) =>
            {
                // 如果希望失去焦点就不再接收，取消下面注释
                clsGlobalScanner.ClearActiveForm();
            };

        }

        private void OnBarcodeScanned(string barcode)
        {
            // 只有当这个窗体是 ActiveForm 时才会进来
            //MessageBox.Show($"【Form1】收到扫码：{barcode}");
            doBarCode(barcode);
            txttran_qty.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            clsGlobalScanner.BarcodeScanned -= OnBarcodeScanned;

            // 如果当前是自己，清除
            if (clsGlobalScanner.ActiveForm == this)
                clsGlobalScanner.ClearActiveForm();

            base.OnFormClosing(e);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        TextBox tb = this.ActiveControl as TextBox;
        //        if (tb != null && tb.Tag != null && tb.Tag.ToString() == "EnterAction")
        //        {
        //            // 在这里执行你自己的事件逻辑
        //            //DoSpecialAction(tb);
        //            if (txtBarCode.Text.Trim().Length > BarCodeMinLength)
        //                doBarCode(txtBarCode.Text.Trim());
        //            txtBarCode.Text = "";
        //            txttran_qty.Focus();
        //            return true; // 已处理
        //        }
        //        else if (tb.Tag != null && tb.Tag.ToString() == "BarcodeInput")// 特殊情况：扫码枪输入框
        //        {
        //            doBarCode(tb.Text.Trim()); // 扫码逻辑
        //            return true;
        //        }
        //        else
        //        {
        //            // 默认行为：跳到下一个控件
        //            this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //            return true;
        //        }
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void HandleEnterKey(TextBox tb, KeyEventArgs e, Action customAction = null)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (customAction != null)
                {
                    // 如果传入了自定义事件，就执行它
                    customAction();
                }
                else
                {
                    // 默认行为：跳到下一个控件
                    this.SelectNextControl(tb, true, true, true, true);
                }
            }
        }


        private void DoSpecialAction(TextBox tb)
        {
            MessageBox.Show($"执行事件：{tb.Name} 的内容是 {tb.Text}");
        }



        private void frmDeliveryDetail_Load(object sender, EventArgs e)
        {
            

            InitData();

        }
        private void InitData()
        {
            //int fixedCount = 6; // 要固定的列数
            //for (int i = 0; i < fixedCount; i++)
            //{
            //    dgvDetails.Columns[i].Frozen = true;
            //}
            txtTransferDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            DataTable dtMoGroup = clsBaseData.LoadMoGroupAll("");
            cmbMoGroup.DataSource = dtMoGroup;
            cmbMoGroup.DisplayMember = "group_id";
            cmbMoGroup.ValueMember = "group_id";

            // 绑定到 DataGridView
            DataSet dsTran = clsDeliveryDetail.LoadGoodsDetails("ZZZZZZZZZ");
            dtTranDetails = dsTran.Tables[0];
            dtTranDetailsPart = dsTran.Tables[1];
            //dtTranDetailsPart = clsDeliveryDetail.LoadGoodsDetailsPart("ZZZZZZZZZ", "ZZZZ");

            gcTranDetails.DataSource = dtTranDetails;
            gcTranDetailsPart.DataSource = dtTranDetailsPart;

            // 建立映射字典（只有一组 TextBox）
            var bindings = new Dictionary<TextBox, string>
            {
                { txtmo_id, "mo_id" },
                { txtgoods_id, "goods_id" },
                {txtgoods_cname,"goods_cname" },
                {txttran_qty,"transfer_amount" },
                {txttran_weg,"sec_qty" },
                { txtunit, "unit" },
                { txtunit1, "sec_unit" },
                {txtnwt,"nwt" },
                {txtgwt,"gross_wt" },
                {txtpack_num,"package_num" },
                {txtbox_num,"position_first" },
                {txtremark,"remark" }
            };

            // 创建绑定器

            binder = new clsDataTableTextBoxBinder(dtTranDetails, gvTranDetails, bindings);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                SaveMostly();

        }
        private void SaveMostly()
        {
            if (!ValidMostlyData())
                return;
            mdlDeliveryHead objMostly = new mdlDeliveryHead();
            objMostly.ID = txtDocId.Text;
            objMostly.transfer_date = txtTransferDate.Text;
            objMostly.id_type = cmbIdType.Text.Trim();
            objMostly.mo_group = cmbMoGroup.Text.Trim();
            objMostly.state = "0";
            string ID = clsDeliveryDetail.SaveMostly(objMostly);
            txtDocId.Text = ID;
        }
        private bool ValidMostlyData()
        {
            bool valid_flag = true;
            if (txtTransferDate.Text.Trim() == "/  /")
            {
                MessageBox.Show("轉出單日期不能為空!");
                txtTransferDate.Focus();
                valid_flag = false;
            }
            else if (cmbIdType.Text.Trim() == "")
            {
                MessageBox.Show("單據類型不能為空!");
                cmbIdType.Focus();
                valid_flag = false;
            }
            else if (cmbMoGroup.Text.Trim() == "")
            {
                MessageBox.Show("組別編號不能為空!");
                cmbMoGroup.Focus();
                valid_flag = false;
            }
            return valid_flag;
        }
        private void txtDocId_Leave(object sender, EventArgs e)
        {
            if (txtDocId.Text.ToString() != "")
            {
                LoadMostlyData();
                LoadGoodsDetails();
            }
        }
        private void LoadMostlyData()
        {
            DataTable dtMostly = clsDeliveryDetail.LoadMostlyData(txtDocId.Text);
            FillMostlyData(dtMostly);
        }
        private void FillMostlyData(DataTable dtMostly)
        {
            if(dtMostly.Rows.Count>0)
            {
                DataRow drMostly = dtMostly.Rows[0];
                txtDocId.Text = drMostly["id"].ToString();
                cmbIdType.Text = drMostly["bill_type_no"].ToString();
                cmbMoGroup.Text = drMostly["group_no"].ToString();
                txtCreateDate.Text = drMostly["create_date"].ToString();
                txtCreateUser.Text = drMostly["create_by"].ToString();
                txtUpdateDate.Text = drMostly["update_date"].ToString();
                txtUpdateUser.Text = drMostly["update_by"].ToString();
                txtCheckDate.Text = drMostly["check_date"].ToString();
                txtCheckUser.Text = drMostly["check_by"].ToString();
                txtState.Text = drMostly["state"].ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text.Trim().Length > BarCodeMinLength)
                    doBarCode(txtBarCode.Text.Trim());
                txtBarCode.Text = "";
            }
        }
        private void doBarCode(string org_barcode)
        {
            //掃描制單編號，物料編號
            //string barcode = "";
            //if (txtBarCode.Text.Trim().Length > 13)
            //    barcode = txtBarCode.Text.Substring(0, 13);
            //else
            //    barcode = txtBarCode.Text.Trim();
            string barcode = org_barcode.Length > 13 ? org_barcode.Substring(0, 13) : org_barcode;
            DataTable dtBarCode = clsPublicOfPad.BarCodeToItem(barcode);
            txtBarCode.Text = "";
            if (dtBarCode.Rows.Count > 0)
            {
                string barcode_type = dtBarCode.Rows[0]["barcode_type"].ToString();
                if (barcode_type == "2")//從生產計劃中提取的條形碼
                {
                    txtgoods_id.Text = dtBarCode.Rows[0]["goods_id"].ToString();
                    txtmo_id.Text = dtBarCode.Rows[0]["mo_id"].ToString();
                    LoadGoodsData();
                }
                else
                {
                    //string doc = dtBarCode.Rows[0]["doc_id"].ToString();
                    //string seq = dtBarCode.Rows[0]["doc_seq"].ToString();
                    //DataTable dtTranMo = clsProductionSelect.GetPrdFromTransfer(barcode_type, doc, seq);
                    //if (dtTranMo.Rows.Count > 0)
                    //{
                    //    goods_id = dtTranMo.Rows[0]["goods_id"].ToString();
                    //    txtmo_id.Text = dtTranMo.Rows[0]["mo_id"].ToString();
                    //}
                }

            }
        }

        private void LoadGoodsData()
        {
            CleanTextPart();
            string mo_id = txtmo_id.Text;
            string goods_id=txtgoods_id.Text;
            DataSet dsOc = clsDeliveryDetail.LoadGoodsData(mo_id, goods_id);
            if (dsOc.Tables[0].Rows.Count > 0)
            {
                DataRow drOc = dsOc.Tables[0].Rows[0];
                txtgoods_cname.Text = drOc["goods_cname"].ToString();
            }
            if (dsOc.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < dsOc.Tables[1].Rows.Count; i++)
                {
                    DataRow drPart = dsOc.Tables[1].Rows[i];
                    DataRow newRow = dtTranDetailsPart.NewRow();
                    newRow["mo_id"] = drPart["mo_id"].ToString();
                    newRow["goods_id"] = drPart["goods_id"].ToString();
                    newRow["goods_cname"] = drPart["goods_cname"].ToString();
                    newRow["con_qty"] = 0;
                    newRow["sec_qty"] = 0;
                    newRow["st_qty"] = drPart["st_qty"];
                    newRow["st_weg"] = drPart["st_weg"];
                    newRow["lot_no"] = drPart["lot_no"];
                    // 把新行加入 DataTable
                    dtTranDetailsPart.Rows.Add(newRow);
                }
            }
            ShowTranDetailsPart(mo_id);

        }
        private void ShowTranDetailsPart(string mo_id)
        {
            DataView dv = new DataView(dtTranDetailsPart);
            dv.RowFilter = "mo_id='" + mo_id + "'";   // 过滤条件
            gcTranDetailsPart.DataSource = dv;
        }
        private void CleanTextPart()
        {
            //txtgoods_id.Text = "";
            txtgoods_cname.Text = "";
            txttran_qty.Text = "";
            txtunit.Text = "";
            txttran_weg.Text = "";
            txtunit1.Text = "";
            txtnwt.Text = "";
            txtgwt.Text = "";
            txtpack_num.Text = "";
            txtbox_num.Text = "";
            txtremark.Text = "";
        }
        private void LoadGoodsDetails()
        {
            string ID = txtDocId.Text.Trim();
            DataSet dsTran=clsDeliveryDetail.LoadGoodsDetails(ID);
            dtTranDetails = dsTran.Tables[0];
            gcTranDetails.DataSource = dtTranDetails;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadGoodsDetails();
        }
        private void FillTranDetails()
        {

        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtTranDetails.NewRow();
            newRow["unit"] = "PCS";
            newRow["sec_unit"] = "KG";
            // 把新行加入 DataTable
            dtTranDetails.Rows.Add(newRow);
            gvTranDetails.FocusedRowHandle = gvTranDetails.RowCount - 1;
            txttran_qty.Focus();

            //binder.AddNewRow(new Dictionary<string, object>
            //{
            //    { "mo_id", "" },
            //    { "goods_id", "" },
            //    { "unit", "" }
            //});
            //// 刷新整个数据源
            //gcTranDetails.RefreshDataSource();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            //binder.DeleteCurrentRow();

            int rowHandle = gvTranDetails.FocusedRowHandle;
            DataRow row = gvTranDetails.GetDataRow(rowHandle);
            dtTranDetails.Rows.Remove(row);

        }

        private void gvTranDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int rowIndex = gvTranDetails.FocusedRowHandle;
            string mo_id = dtTranDetails.Rows[rowIndex]["mo_id"].ToString();
            ShowTranDetailsPart(mo_id);
        }

        private void txttran_qty_Leave(object sender, EventArgs e)
        {
            if (txttran_qty.Text.ToString() == "")
                return;
            int con_qty = Convert.ToInt32(txttran_qty.Text);
            decimal tot_weg = 0;
            string mo_id = txtmo_id.Text.Trim();

            DataRow[] rows = dtTranDetailsPart.Select("mo_id = '" + mo_id + "'");

            foreach (DataRow row in rows)
            {
                row["con_qty"] = con_qty;   // 给 qty 字段赋值
                if ((row["st_qty"].ToString() != "" ? Convert.ToInt32(row["st_qty"]) : 0) > 0 && (row["st_weg"].ToString() != "" ? Convert.ToDecimal(row["st_weg"]) : 0) > 0)
                {
                    decimal sec_qty = Math.Round((Convert.ToDecimal(row["st_weg"]) / Convert.ToInt32(row["st_qty"])) * con_qty, 2);
                    row["sec_qty"] = sec_qty;
                    tot_weg += sec_qty;
                }
                else
                    row["sec_qty"] = 0;


            }
            txttran_weg.Text = tot_weg.ToString();

        }

        private void txttran_qty_KeyDown(object sender, KeyEventArgs e)
        {
            HandleEnterKey((TextBox)sender, e);
        }

        private void txtnwt_KeyDown(object sender, KeyEventArgs e)
        {
            HandleEnterKey((TextBox)sender, e);
        }
    }
}
