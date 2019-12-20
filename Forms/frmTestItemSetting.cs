using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmTestItemSetting : Form
    {
        private clsUtility.enumOperationType OperationType;

        private DataTable dtItemId = null;

        private DataTable dtTestItemDetails = null;
        public frmTestItemSetting()
        {
            InitializeComponent();
        }

        private void frmTestItemSetting_Load(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Load;
            ControlState();

            clsTestProductPlan.SetTestType(lueTestType);
            BindLueItemId();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Add;
            ControlState();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvItemDetails.RowCount > 0)
            {
                OperationType = clsUtility.enumOperationType.Update;
                ControlState();
            }
            else
            {
                MessageBox.Show("沒有測試項目可編輯。");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TestItemIdIsNull())
            {
                mdlTestItemMostly objMostly = new mdlTestItemMostly();
                objMostly.type = lueTestType.EditValue.ToString();
                objMostly.id = lueItemType.EditValue.ToString();
                objMostly.cdesc = lueItemType.Text;
                objMostly.edesc = "";
                objMostly.remark = MtxtRemark.Text;
                objMostly.isExsit = lblIsExsit.Text;

                for (int i = 0; i < gvItemDetails.RowCount; i++)
                {
                    mdlTestItemDetails objDetails = new mdlTestItemDetails();
                    objDetails.id = lueItemType.EditValue.ToString();
                    objDetails.test_item_id = gvItemDetails.GetRowCellDisplayText(i, "test_item_id");
                    objDetails.test_item_cdesc = gvItemDetails.GetRowCellDisplayText(i, "test_item_cdesc");
                    objDetails.remark = gvItemDetails.GetRowCellDisplayText(i, "remark");
                    objDetails.isExsit = gvItemDetails.GetRowCellDisplayText(i, "isExsit");
                    objDetails.seq_id = gvItemDetails.GetRowCellDisplayText(i, "seq_id");
                    objMostly.lsDetails.Add(objDetails);
                }

                int Result = 0;
                switch (OperationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsTestProductPlan.AddTestItemSetting(objMostly);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsTestProductPlan.UpdateTestItemSetting(objMostly);
                        }
                        break;
                }

                if (Result > 0)
                {
                    OperationType = clsUtility.enumOperationType.Save;
                    ControlState();
                }
                else
                {
                    MessageBox.Show("保存出錯！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Cancel;
            ControlState();
        }

        /// <summary>
        ///測試類型 A/B/C/D 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lueTestType_EditValueChanged(object sender, EventArgs e)
        {
            BindLueItemType(lueTestType.EditValue.ToString());
        }

        /// <summary>
        ///項目類型：產品類別、牌子類別、顏色類別、材質 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lueItemType_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtMostly = clsTestProductPlan.GetTestItemMostly(lueItemType.EditValue.ToString());
            if (dtMostly.Rows.Count > 0)
            {
                MtxtRemark.Text = dtMostly.Rows[0]["remark"].ToString();
                lblIsExsit.Text = dtMostly.Rows[0]["isExsit"].ToString();
            }
            else
            {
                MtxtRemark.Text = "";
                lblIsExsit.Text = "";
            }

            DataTable dtDataDeatils = clsTestProductPlan.GetTestItemDetails(lueItemType.EditValue.ToString());
            dtTestItemDetails = dtDataDeatils.Copy();
            gridControl1.DataSource = dtDataDeatils;
            gridControl1.Refresh();

            if (dtDataDeatils.Rows.Count > 0)
            {
                if (OperationType == clsUtility.enumOperationType.Add)
                {
                    btnDelItem.Enabled = true;
                }
            }
        }

        /// <summary>
        ///項目增加 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (lueTestType.EditValue.ToString() == "")
            {
                MessageBox.Show("請選擇測試類型。");
                lueTestType.Focus();
                return;
            }
            if (lueItemType.EditValue.ToString() == "")
            {
                MessageBox.Show("請選擇項目類型。");
                lueItemType.Focus();
                return;
            }

            if (gvItemDetails.RowCount > 0)
            {
                int MaxSeq_id = Convert.ToInt32(gvItemDetails.GetRowCellDisplayText(gvItemDetails.FocusedRowHandle, "seq_id"));

                gvItemDetails.AddNewRow();
                gvItemDetails.SetRowCellValue(gvItemDetails.FocusedRowHandle, "seq_id", (MaxSeq_id + 1).ToString("000"));
            }
            else
            {
                gvItemDetails.AddNewRow();
                gvItemDetails.SetRowCellValue(gvItemDetails.FocusedRowHandle, "seq_id", "001");
            }

            btnDelItem.Enabled = true;
        }

        /// <summary>
        /// 項目刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelItem_Click(object sender, EventArgs e)
        {
            if (dtTestItemDetails.Rows.Count > 0)
            {
                string ItemTypeId = lueItemType.EditValue.ToString();
                string TestItemId = gvItemDetails.GetRowCellDisplayText(gvItemDetails.FocusedRowHandle, "test_item_id");

                bool IsDelInDataBase = false;  // 是否從數據庫刪除數據
                for (int i = 0; i < dtTestItemDetails.Rows.Count; i++)
                {
                    if (dtTestItemDetails.Rows[i]["id"].ToString() == ItemTypeId
                        && dtTestItemDetails.Rows[i]["test_item_id"].ToString() == TestItemId)
                    {
                        IsDelInDataBase = true;
                        break;
                    }
                }

                if (IsDelInDataBase)
                {
                    int Result = clsTestProductPlan.DeleteTestItemDetails(ItemTypeId, TestItemId);

                    if (Result > 0)
                    {
                        gvItemDetails.DeleteRow(gvItemDetails.FocusedRowHandle);
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗！");
                    }
                }
                else
                {
                    gvItemDetails.DeleteRow(gvItemDetails.FocusedRowHandle);
                }
            }
            else
            {
                gvItemDetails.DeleteRow(gvItemDetails.FocusedRowHandle);
            }
        }

        /// <summary>
        /// 測試項目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lueItemId_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            if (lue.EditValue.ToString() != "")
            {
                bool isRepeat = true;
                for (int i = 0; i < gvItemDetails.RowCount; i++)
                {
                    if (i != gvItemDetails.FocusedRowHandle)
                    {
                        if (lue.EditValue.ToString() == gvItemDetails.GetRowCellDisplayText(i, "test_item_id"))
                        {
                            MessageBox.Show("已存在測試項目：" + lue.EditValue.ToString());
                            lue.EditValue = "";
                            isRepeat = false;
                            break;
                        }
                    }
                }

                if (isRepeat)
                {
                    int indexSelect = lueItemId.GetDataSourceRowIndex("test_item_id", lue.Text);
                    string stredesc = lueItemId.GetDataSourceValue("test_item_edesc", indexSelect).ToString();
                    string strcdesc = lueItemId.GetDataSourceValue("test_item_cdesc", indexSelect).ToString();

                    gvItemDetails.SetRowCellValue(gvItemDetails.FocusedRowHandle, "test_item_cdesc", strcdesc);
                    gvItemDetails.SetRowCellValue(gvItemDetails.FocusedRowHandle, "test_item_edesc", stredesc);
                }
            }
            else
            {
                gvItemDetails.SetRowCellValue(gvItemDetails.FocusedRowHandle, "test_item_cdesc", "");
                gvItemDetails.SetRowCellValue(gvItemDetails.FocusedRowHandle, "test_item_edesc", "");
            }
        }

        /// <summary>
        /// 綁定項目類型
        /// </summary>
        /// <param name="TestType"></param>
        private void BindLueItemType(string TestType)
        {
            switch (TestType)
            {
                case "A":
                    {
                        clsTestProductPlan.SetProductType(lueItemType);
                    }
                    break;
                case "B":
                    {
                        clsTestProductPlan.SetBrandType(lueItemType);
                    }
                    break;
                case "C":
                    {
                        clsTestProductPlan.SetColorType(lueItemType);
                    }
                    break;
                case "D":
                    {
                        clsTestProductPlan.SetMatType(lueItemType);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 綁定測試項目
        /// </summary>
        /// <param name="objLookUpEdit"></param>
        private void BindLueItemId()
        {
            dtItemId = clsTestProductPlan.GetTestItemForLue();
            DataRow dr0 = dtItemId.NewRow(); //插一空行        
            dtItemId.Rows.InsertAt(dr0, 0);

            lueItemId.DataSource = dtItemId;
            lueItemId.ValueMember = "test_item_id";
            lueItemId.DisplayMember = "test_item_id";
        }

        /// <summary>
        ///判斷測試項目是否為Null 
        /// </summary>
        /// <returns></returns>
        private bool TestItemIdIsNull()
        {
            btnAddItem.Focus();
            if (gvItemDetails.RowCount == 0)
            {
                MessageBox.Show("沒有可保存測試項目。");
                return false;
            }

            for (int i = 0; i < gvItemDetails.RowCount; i++)
            {
                if (gvItemDetails.GetRowCellDisplayText(i, "test_item_id").ToString() == "")
                {
                    MessageBox.Show("測試項目不能為空。");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 控件狀態
        /// </summary>
        private void ControlState()
        {
            switch (OperationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnAddItem.Enabled = true;
                        if (gvItemDetails.RowCount > 0)
                        {
                            btnDelItem.Enabled = true;
                        }

                        lueTestType.Enabled = true;
                        lueItemType.Enabled = true;
                        MtxtRemark.Enabled = true;

                        gvItemDetails.OptionsBehavior.Editable = true;
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        btnAddItem.Enabled = true;
                        btnDelItem.Enabled = true;

                        lueTestType.Enabled = false;
                        lueItemType.Enabled = false;
                        MtxtRemark.Enabled = true;

                        gvItemDetails.OptionsBehavior.Editable = true;
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnAddItem.Enabled = false;
                        btnDelItem.Enabled = false;

                        lueTestType.Enabled = true;
                        lueItemType.Enabled = true;
                        MtxtRemark.Enabled = false;

                        lueTestType.EditValue = "";
                        lueItemType.EditValue = "";
                        MtxtRemark.Text = "";

                        gvItemDetails.OptionsBehavior.Editable = false;
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnAddItem.Enabled = false;
                        btnDelItem.Enabled = false;

                        lueTestType.Enabled = true;
                        lueItemType.Enabled = true;
                        MtxtRemark.Enabled = false;

                        gvItemDetails.OptionsBehavior.Editable = false;
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnAddItem.Enabled = false;
                        btnDelItem.Enabled = false;

                        lueTestType.Enabled = true;
                        lueItemType.Enabled = true;
                        MtxtRemark.Enabled = false;

                        lueTestType.EditValue = "";
                        lueItemType.EditValue = "";

                        gvItemDetails.OptionsBehavior.Editable = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchItemMostly fSIM = new frmSearchItemMostly();
            if (fSIM.ShowDialog() == DialogResult.Yes)
            {
                lueTestType.EditValue = fSIM.Type;
                lueItemType.EditValue = fSIM.ItemTypeId;
            }
        }


    }
}
