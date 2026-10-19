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
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            clsGlobalScanner.BarcodeScanned -= OnBarcodeScanned;

            // 如果当前是自己，清除
            if (clsGlobalScanner.ActiveForm == this)
                clsGlobalScanner.ClearActiveForm();

            base.OnFormClosing(e);
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
            gcTranDetails.DataSource = dtTranDetails;


            // 建立映射字典（只有一组 TextBox）
            var bindings = new Dictionary<TextBox, string>
            {
                { txtmo_id, "mo_id" },
                { txtgoods_id, "goods_id" },
                { txtunit, "unit" }
            };

            // 创建绑定器

            binder = new clsDataTableTextBoxBinder(dtTranDetails, gvTranDetails, bindings);


            //            // 绑定 GridView 行切换事件
            //            gvTranDetails.FocusedRowChanged += (s, e) =>
            //            {
            //                if (e.FocusedRowHandle >= 0)
            //                {
            //                    DataRow row = gvTranDetails.GetDataRow(e.FocusedRowHandle);
            //                    foreach (var kvp in bindings)
            //                    {
            //                        TextBox tb = kvp.Key;
            //                        string columnName = kvp.Value;
            //                        tb.Text = row[columnName]?.ToString();
            //                    }
            //                }
            //            };

            //            // TextBox → DataTable 更新
            //            foreach (var kvp in bindings)
            //            {
            //                TextBox tb = kvp.Key;
            //                string columnName = kvp.Value;

            //                tb.TextChanged += (s, e) =>
            //                {
            //                    int rowHandle = gvTranDetails.FocusedRowHandle;
            //                    if (rowHandle >= 0)
            //                    {
            //                        DataRow row = gvTranDetails.GetDataRow(rowHandle);
            //                        row[columnName] = tb.Text;
            //                    }
            //                };
            //            }


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
                string goods_id = "";
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
            DataTable dtOc = clsDeliveryDetail.LoadGoodsData(mo_id, goods_id);
            if (dtOc.Rows.Count > 0)
            {
                DataRow drOc = dtOc.Rows[0];
                txtgoods_cname.Text = drOc["goods_cname"].ToString();
            }

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
        }
        private void LoadGoodsDetails()
        {
            string ID = txtDocId.Text.Trim();
            dtTranDetails = clsDeliveryDetail.LoadGoodsDetails(ID);
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
            // 把新行加入 DataTable
            dtTranDetails.Rows.Add(newRow);
            //// 建立映射字典
            //var bindings = new Dictionary<TextBox, string>
            //{
            //    { txtmo_id, "mo_id" },
            //    { txtgoods_id, "goods_id" },
            //    { txttran_qty, "transfer_amount" }
            //};
            //int bindRow = dtTranDetails.Rows.Count - 1;
            //// 双向绑定
            //BindTextBoxesTwoWay(dtTranDetails, bindRow, bindings);
            //{ "BirthDate", DateTime.Now.ToString("yyyy/MM/dd") }
            //    binder.AddNewRow(new Dictionary<string, object>
            //{
            //    { "mo_id", "" },
            //    { "goods_id", "" },
            //    { "unit", "" }
            //});
            //// 定位到新行
            gvTranDetails.FocusedRowHandle = gvTranDetails.RowCount - 1;

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            //binder.DeleteCurrentRow();

            int rowHandle = gvTranDetails.FocusedRowHandle;
            DataRow row = gvTranDetails.GetDataRow(rowHandle);
            dtTranDetails.Rows.Remove(row);

            ///// <summary>
            ///// 将一组 TextBox 双向绑定到 DataTable 的当前选中行
            ///// </summary>
            ///// <param name="dt">目标 DataTable</param>
            ///// <param name="bindings">TextBox 与字段名的映射字典</param>
            ///// <param name="dgv">可选的 DataGridView，用于行选择</param>
            //public void BindTextBoxesToDataTableRow(DataTable dt, Dictionary<TextBox, string> bindings, DataGridView dgv = null)
            //{
            //    // 当 DataGridView 行选择变化时，刷新 TextBox 内容
            //    if (dgv != null)
            //    {
            //        dgv.SelectionChanged += (s, e) =>
            //        {
            //            if (dgv.CurrentRow != null)
            //            {
            //                int rowIndex = dgv.CurrentRow.Index;
            //                foreach (var kvp in bindings)
            //                {
            //                    TextBox tb = kvp.Key;
            //                    string columnName = kvp.Value;
            //                    tb.Text = dt.Rows[rowIndex][columnName]?.ToString();
            //                }
            //            }
            //        };
            //    }

            //    // TextBox → DataTable
            //    foreach (var kvp in bindings)
            //    {
            //        TextBox tb = kvp.Key;
            //        string columnName = kvp.Value;

            //        tb.TextChanged += (s, e) =>
            //        {
            //            int rowIndex = 0;
            //            if (dgv != null && dgv.CurrentRow != null)
            //                rowIndex = dgv.CurrentRow.Index;

            //            if (rowIndex >= 0 && rowIndex < dt.Rows.Count)
            //            {
            //                dt.Rows[rowIndex][columnName] = tb.Text;
            //            }
            //        };
            //    }
            //}

        }
    }
}
