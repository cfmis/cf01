﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.CLS;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.MM
{
    public partial class frmProductCostingFind : Form
    {
        public static string searchProductMo;
        private DataTable dtWipData = new DataTable();
        private DataTable dtProductCosting = new DataTable();
        private DataTable dtBomData = new DataTable();
        public frmProductCostingFind()
        {
            InitializeComponent();
        }
        private void frmMmCostingFind_Load(object sender, EventArgs e)
        {
            dgvCosting.AutoGenerateColumns = false;
            dgvWipData.AutoGenerateColumns = false;
            dgvBomData.AutoGenerateColumns = false;
            rdgIsSetCosting.SelectedIndex = 2;
            //txtDateFrom.Text = System.DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
            //txtDateTo.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtProductMo.Text = searchProductMo;
            cmbBefRec.DataSource = clsProductCosting.getRecNumber();
            cmbBefRec.DisplayMember = "flag_desc";
            cmbBefRec.ValueMember = "flag_id";
            txtProductMo.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            frmProductCosting.searchProductId = ""; 
            frmProductCosting.searchProductName = "";
            frmProductCosting.searchProductMo = "";
            //this.Visible = false;
            //this.Close();
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtProductMo.Focus();
            if (rdgIsSetCosting.SelectedIndex != 0)
            {
                if (txtMatFrom.Text.Trim() == ""
                    && txtPrdTypeFrom.Text.Trim() == ""
                    && txtArtFrom.Text.Trim() == ""
                    && txtSizeFrom.Text.Trim() == ""
                    && txtClrFrom.Text.Trim() == ""
                    && txtProductMo.Text.Trim() == ""
                    && txtDateFrom.Text.Trim()==""
                    && txtDateTo.Text.Trim()=="" )
                {
                    MessageBox.Show("請輸入查詢條件!");
                    return;
                }
            }
            txtShowProductId.Text = "";
            txtShowProductName.Text = "";
            int isSetFlag = rdgIsSetCosting.SelectedIndex;
            int sourceType = rdgSource.SelectedIndex;
            bool showF0 = chkShowF0.Checked;
            string productId = ""; 
            findProcess(isSetFlag, sourceType, showF0, txtProductMo.Text.Trim(),productId, txtMatFrom.Text.Trim(), txtMatTo.Text.Trim()
               , txtPrdTypeFrom.Text.Trim(), txtPrdTypeTo.Text.Trim(), txtArtFrom.Text.Trim(), txtArtTo.Text.Trim()
               , txtSizeFrom.Text.Trim(), txtSizeTo.Text.Trim(), txtClrFrom.Text.Trim(), txtClrTo.Text.Trim()
               , txtDateFrom.Text.Trim(), txtDateTo.Text.Trim()
               , txtMoGroup.Text.Trim(), txtSales.Text.Trim()
               );

        }
        private void btnReSearch_Click(object sender, EventArgs e)
        {
            if (dgvCosting.Rows.Count == 0)
                return;
            string productId = dgvCosting.Rows[dgvCosting.CurrentRow.Index].Cells["colProductId"].Value.ToString();
            int isSetFlag = rdgIsSetCosting.SelectedIndex;
            int sourceType = rdgSource.SelectedIndex;
            bool showF0 = false;// chkShowF0.Checked;
            string productMo = "";
            string matFrom = "", matTo = "";
            string prdTypeFrom = "", prdTypeTo = "";
            string artFrom = "", artTo = "";
            string sizeFrom = "", sizeTo = "";
            string clrFrom = "", clrTo = "";
            string dateFrom = "", dateTo = "";
            string moGroup = "", salesId = "";
            findProcess(isSetFlag, sourceType, showF0, productMo, productId, matFrom, matTo
               , prdTypeFrom, prdTypeTo, artFrom, artTo
               , sizeFrom, sizeTo, clrFrom, clrTo
               , dateFrom, dateTo
               , moGroup, salesId
               );
        }

        private void findProcess(int isSetFlag,int sourceType,bool showF0,string moId,string productId,string matFrom,string matTo
            ,string prdTypeFrom,string prdTypeTo,string artFrom,string artTo
            ,string sizeFrom,string sizeTo,string clrFrom,string clrTo,string dateFrom
            ,string dateTo,string moGroup,string salesId)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            //findProcess(); //数据处理
            string RecNumber = "";
            RecNumber = cmbBefRec.SelectedValue.ToString() == "99" ? "100000" : cmbBefRec.Text.Trim();
            dtProductCosting = clsProductCosting.findProductCosting(RecNumber,isSetFlag, sourceType, showF0, moId,productId
                , matFrom, matTo, prdTypeFrom, prdTypeTo
                , artFrom, artTo, sizeFrom,sizeTo
                , clrFrom,clrTo, dateFrom,dateTo, moGroup,salesId
                );
            dgvCosting.DataSource = dtProductCosting;
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (dgvCosting.Rows.Count == 0)
                MessageBox.Show("沒有找到符合條件的記錄");
            else
            {
                for (int i = 0; i < dgvCosting.Rows.Count; i++)
                {
                    dgvCosting.Rows[i].Cells["colSetCosting"].Value = "...";
                }
            }


            ////genBomTree(pid);
            ////**********************
            //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        //private void findProcess()
        //{
        //    int isSetFlag = rdgIsSetCosting.SelectedIndex;
        //    dtProductCosting = clsProductCosting.findProductCosting(isSetFlag, rdgSource.SelectedIndex, chkShowF0.Checked, txtProductMo.Text.Trim()
        //        ,txtMatFrom.Text.Trim(),txtMatTo.Text.Trim(),txtPrdTypeFrom.Text.Trim(),txtPrdTypeTo.Text.Trim()
        //        ,txtArtFrom.Text.Trim(),txtArtTo.Text.Trim(),txtSizeFrom.Text.Trim(),txtSizeTo.Text.Trim()
        //        ,txtClrFrom.Text.Trim(),txtClrTo.Text.Trim(),txtDateFrom.Text.Trim(),txtDateTo.Text.Trim()
        //        ,txtMoGroup.Text.Trim(),txtSales.Text.Trim()
        //        );
        //    dgvCosting.DataSource = dtProductCosting;
        //    if (dgvCosting.Rows.Count == 0)
        //        MessageBox.Show("沒有找到符合條件的記錄");
        //    else
        //    {
        //        for (int i = 0; i < dgvCosting.Rows.Count; i++)
        //        {
        //            dgvCosting.Rows[i].Cells["colSetCosting"].Value = "...";
        //        }
        //    }
        //}
        
        private void txtMatFrom_Leave(object sender, EventArgs e)
        {
            txtMatTo.Text = txtMatFrom.Text;
        }

        private void txtPrdTypeFrom_Leave(object sender, EventArgs e)
        {
            txtPrdTypeTo.Text = txtPrdTypeFrom.Text;
        }

        private void txtSizeFrom_Leave(object sender, EventArgs e)
        {
            txtSizeTo.Text = txtSizeFrom.Text;
        }

        private void txtClrFrom_Leave(object sender, EventArgs e)
        {
            txtClrTo.Text = txtClrFrom.Text;
        }

        private void txtArtFrom_Leave(object sender, EventArgs e)
        {
            txtArtTo.Text = txtArtFrom.Text;
        }

        private void txtDateFrom_Leave(object sender, EventArgs e)
        {
            txtDateTo.Text = txtDateFrom.Text;
        }

        private void dgvCosting_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCosting.CurrentRow == null)
                return;
            DataGridViewRow dr = dgvCosting.Rows[dgvCosting.CurrentRow.Index]; //.CurrentCell.RowIndex
            txtShowProductId.Text = dr.Cells["colProductId"].Value.ToString();
            txtShowProductName.Text = dr.Cells["colProductName"].Value.ToString();

            //loadProductWip();
        }
        private void btnWipData_Click(object sender, EventArgs e)
        {
            loadProductWip();
        }
        private void loadProductWip()
        {
            if (dgvCosting.Rows.Count == 0)
                return;
            DataGridViewRow dr = dgvCosting.Rows[dgvCosting.CurrentRow.Index];
            if (xtraTabControl1.SelectedTabPageIndex==0)
            {
                string productMo = dr.Cells["colProductMo"].Value == null ? "" : dr.Cells["colProductMo"].Value.ToString();
                dtWipData = clsProductCosting.getWipData(productMo, true);
                dgvWipData.DataSource = dtWipData;
                for (int i = 0; i < dgvWipData.Rows.Count; i++)
                {
                    dgvWipData.Rows[i].Cells["colWipSetCosting"].Value = "...";
                }
            }
            else
            {
                dtBomData = clsProductCosting.getChildBomData(txtShowProductId.Text.Trim());
                dgvBomData.DataSource = dtBomData;
                for (int i = 0; i < dgvBomData.Rows.Count; i++)
                {
                    dgvBomData.Rows[i].Cells["colBomSetCosting"].Value = "...";
                }
            }
        }
        private void dgvWipData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWipData.Columns[e.ColumnIndex].Name == "colWipSetCosting")
            {
                DataGridViewRow dgr = dgvWipData.Rows[dgvWipData.CurrentCell.RowIndex];
                frmProductCosting.searchProductId = dgr.Cells["colWipGoodsId"].Value.ToString();
                frmProductCosting.searchProductName = dgr.Cells["colWipGoodsCname"].Value.ToString();
                frmProductCosting.searchProductMo = dgr.Cells["colWipProductMo"].Value.ToString();
                this.Hide();
            }
        }

        private void dgvCosting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCosting.Columns[e.ColumnIndex].Name == "colSetCosting")
            {
                DataGridViewRow dgr = dgvCosting.Rows[dgvCosting.CurrentCell.RowIndex];
                string productMo=dgr.Cells["colProductMo"].Value.ToString();
                frmProductCosting.searchProductMo = productMo;
                DataTable dt = clsProductCosting.getF0ItemFromOc(productMo, "");
                if (dt.Rows.Count > 0)
                {
                    frmProductCosting.searchProductId = dt.Rows[0]["goods_id"].ToString();
                    frmProductCosting.searchProductName = dt.Rows[0]["goods_name"].ToString();
                }
                else
                {
                    frmProductCosting.searchProductId = dgr.Cells["colProductId"].Value.ToString();
                    frmProductCosting.searchProductName = dgr.Cells["colProductName"].Value.ToString();
                }

                //this.Close();
                //this.Visible = false;
                this.Hide();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printData(dtProductCosting);
        }
        private void printData(DataTable dt)
        {
            xrProductCostingFind oRepot = new xrProductCostingFind() { DataSource = dt};
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void btnPrintWipData_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                printData(dtWipData);
            else
                printData(dtBomData);
        }

        private void btnSetProductPrice_Click(object sender, EventArgs e)
        {
            setProductPrice(1);
        }

        private void btnSetProductWeight_Click(object sender, EventArgs e)
        {
            setProductWeight(1);
        }
        private void btnSetProductWeight1_Click(object sender, EventArgs e)
        {
            setProductWeight(2);
        }
        private void setProductWeight(int selectType)
        {
            string productId = "";
            if (selectType == 1)
            {
                if (dgvCosting.Rows.Count > 0)
                    productId = dgvCosting.Rows[dgvCosting.CurrentRow.Index].Cells["colProductId"].Value.ToString();
            }
            else
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    if (dgvWipData.Rows.Count > 0)
                        productId = dgvWipData.Rows[dgvWipData.CurrentRow.Index].Cells["colWipGoodsId"].Value.ToString();
                }else
                {
                    if (dgvBomData.Rows.Count > 0)
                        productId = dgvBomData.Rows[dgvBomData.CurrentRow.Index].Cells["colBomGoodsId"].Value.ToString();
                }
            }
            frmSetProductWeight.getProductId = productId;
            frmSetProductWeight frm = new frmSetProductWeight();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnSetProductPrice1_Click(object sender, EventArgs e)
        {
            setProductPrice(2);
        }
        private void setProductPrice(int selectType)
        {
            frmSetProductPrice.getProductId = "";
            if (selectType == 1)
            {
                if (dgvCosting.Rows.Count > 0)
                    frmSetProductPrice.getProductId = dgvCosting.Rows[dgvCosting.CurrentRow.Index].Cells["colProductId"].Value.ToString();
            }
            else
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    if (dgvWipData.Rows.Count > 0)
                        frmSetProductPrice.getProductId = dgvWipData.Rows[dgvWipData.CurrentRow.Index].Cells["colWipGoodsId"].Value.ToString();
                }
                else
                {
                    if (dgvBomData.Rows.Count > 0)
                        frmSetProductPrice.getProductId = dgvBomData.Rows[dgvBomData.CurrentRow.Index].Cells["colBomGoodsId"].Value.ToString();
                }
            }
            frmSetProductPrice frm = new frmSetProductPrice();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            loadProductWip();
        }

        private void dgvCosting_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsUtility.setDataGridViewSeq(dgvCosting, e);
        }

        private void dgvWipData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsUtility.setDataGridViewSeq(dgvWipData, e);
        }

        private void dgvWipData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWipData.CurrentRow == null)
                return;
            DataGridViewRow dr = dgvWipData.Rows[dgvWipData.CurrentRow.Index]; //.CurrentCell.RowIndex
            string productMo = dr.Cells["colWipProductMo"].Value == null ? "" : dr.Cells["colWipProductMo"].Value.ToString();
            string Seq= dr.Cells["colSequence_id"].Value.ToString();
            DataTable dtMatData = clsProductCosting.getWipMatData(productMo,Seq);
            dgvMatData.DataSource = dtMatData;
        }

        private void dgvMatData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsUtility.setDataGridViewSeq(dgvMatData, e);
        }
    }
}
