using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using RUI.PC;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmMatMaster : Form
    {
        private clsUtility.enumOperationType operationType;
        private DataTable dtMatMaster = new DataTable();

        public frmMatMaster()
        {
            InitializeComponent();

            clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            control.GenerateContorl();
        }

        private void frmMatMaster_Load(object sender, EventArgs e)
        {
            operationType = clsUtility.enumOperationType.Load;

            BindCmboxArt();
            BindCmboxColor();
            BindCmboxDept();
            BindCmboxMat_Type();
            BindCmboxPrd();
            BindCmboxSize();
            BindCmboxUnit();

            TextBoxEnableTrueOrFalse(false);
            BTNSAVE.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();

        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Find(txtprd_itemQ.Text.Trim(), txtprd_en_descQ.Text.Trim(), txtprd_chs_descQ.Text.Trim());
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (operationType == clsUtility.enumOperationType.Add || operationType == clsUtility.enumOperationType.Update)
            {
                return;   //如果是在新增或編輯狀態，不執行以下操作
            }

            if (dgvDetails.RowCount > 0)
            {
                if (e.RowIndex == -1)
                    return;
                dtMatMaster.Rows[e.RowIndex][""].ToString();
                txtprd_item.Text = dtMatMaster.Rows[e.RowIndex]["prd_item"].ToString();
                txtprd_chs_desc.Text = dtMatMaster.Rows[e.RowIndex]["mat_cdesc"].ToString();
                txtprd_en_desc.Text = dtMatMaster.Rows[e.RowIndex]["mat_desc"].ToString();
                lueDept.EditValue = dtMatMaster.Rows[e.RowIndex]["dept_id"].ToString().Trim();
                lueArtWork.EditValue = dtMatMaster.Rows[e.RowIndex]["art"].ToString().Trim();
                cmboxBase_unit.Text = dtMatMaster.Rows[e.RowIndex]["base_unit"].ToString();
                lueColor_code.EditValue = dtMatMaster.Rows[e.RowIndex]["color_code"].ToString().Trim();
                lueMat_code.EditValue = dtMatMaster.Rows[e.RowIndex]["mat_code"].ToString().Trim();
                luePrd_code.EditValue = dtMatMaster.Rows[e.RowIndex]["prd_code"].ToString().Trim();
                lueSize_code.EditValue = dtMatMaster.Rows[e.RowIndex]["size_id"].ToString().Trim();
                cmboxUnit_w.Text = dtMatMaster.Rows[e.RowIndex]["mt_unit1"].ToString();
                txtcreate_date.Text = dtMatMaster.Rows[e.RowIndex]["bill_date"].ToString();
                txtitem_costq.Text = dtMatMaster.Rows[e.RowIndex]["qty_cost"].ToString();
                txtitem_costw.Text = dtMatMaster.Rows[e.RowIndex]["weg_cost"].ToString();
                txtitem_hgcode.Text = dtMatMaster.Rows[e.RowIndex]["customs_number"].ToString();
                lueItem_hgtype.EditValue = dtMatMaster.Rows[e.RowIndex]["encode_type"].ToString();
                txtitem_hscode.Text = dtMatMaster.Rows[e.RowIndex]["customs_code"].ToString();
                txtitem_img.Text = dtMatMaster.Rows[e.RowIndex]["art_image"].ToString();
                txtitem_part.Text = dtMatMaster.Rows[e.RowIndex]["Match_type"].ToString();
                txtitem_type.Text = dtMatMaster.Rows[e.RowIndex]["item_type"].ToString();
                txtitem_waste.Text = dtMatMaster.Rows[e.RowIndex]["waste"].ToString();
                txtqty_weg_rate.Text = dtMatMaster.Rows[e.RowIndex]["qty_weg_rate"].ToString();
                txtremark.Text = dtMatMaster.Rows[e.RowIndex]["remark"].ToString();
                txtstock_maxq.Text = dtMatMaster.Rows[e.RowIndex]["stork_maxq"].ToString();
                txtstock_maxw.Text = dtMatMaster.Rows[e.RowIndex]["stork_maxw"].ToString();
                txtstock_minq.Text = dtMatMaster.Rows[e.RowIndex]["stork_minq"].ToString();
                txtstock_minw.Text = dtMatMaster.Rows[e.RowIndex]["stork_minw"].ToString();
                switch (dtMatMaster.Rows[e.RowIndex]["modality"].ToString())
                {
                    case "0":
                        rdbself.Checked = true;
                        break;
                    case "1":
                        rdbOutsourcing.Checked = true;
                        break;
                    case "2":
                        rdbPurchase.Checked = true;
                        break;
                    case "3":
                        rdbEndproduct.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddNew()
        {
            operationType = clsUtility.enumOperationType.Add;
            ClearTextBox();
            TextBoxEnableTrueOrFalse(true);

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
        }

        private void Edit()
        {
            operationType = clsUtility.enumOperationType.Update;
            TextBoxEnableTrueOrFalse(true);

            BTNNEW.Enabled = false;
            BTNEDIT.Enabled = false;
            BTNSAVE.Enabled = true;
            BTNDELETE.Enabled = false;
        }

        /// <summary>
        /// 保存新增、編輯的物料代碼
        /// </summary>
        private void Save()
        {
            if (ValidateText())
            {
                int Result = 0;

                mdlMatMaster objMatMaster = new mdlMatMaster();
                objMatMaster.prd_item = (lueMat_code.EditValue.ToString() + luePrd_code.EditValue.ToString() + lueArtWork.EditValue.ToString()
                                          + lueSize_code.EditValue.ToString() + lueColor_code.EditValue.ToString()).Trim();
                objMatMaster.prd_code = luePrd_code.EditValue.ToString().Trim();
                objMatMaster.prd_dep = lueDept.EditValue.ToString().Trim();
                objMatMaster.item_desc = txtprd_en_desc.Text.Trim();
                objMatMaster.item_cdesc = txtprd_chs_desc.Text.Trim();
                objMatMaster.item_cost = clsUtility.FormatNullableFloat(txtitem_costq.Text.Trim());
                objMatMaster.item_cost1 = clsUtility.FormatNullableFloat(txtitem_costw.Text.Trim());
                objMatMaster.item_hgcode = txtitem_hgcode.Text.Trim();
                objMatMaster.item_hgtype = lueItem_hgtype.EditValue.ToString();
                objMatMaster.item_hscode = txtitem_hscode.Text.Trim();
                objMatMaster.item_img = txtitem_img.Text.Trim();
                objMatMaster.item_part = txtitem_part.Text.Trim();
                objMatMaster.item_rmk = txtremark.Text.Trim();
                objMatMaster.item_type = txtitem_type.Text.Trim();
                objMatMaster.item_unit = cmboxBase_unit.SelectedValue.ToString();
                objMatMaster.item_unit1 = cmboxUnit_w.SelectedValue.ToString();
                objMatMaster.item_waste = clsUtility.FormatNullableFloat(txtitem_waste.Text.Trim());
                objMatMaster.art_code = lueArtWork.EditValue.ToString().Trim();
                objMatMaster.clr_code = lueColor_code.EditValue.ToString().Trim();
                objMatMaster.crdat = DateTime.Now.ToString("yyyy/mm/dd"); //txtcreate_date.Text.Trim();
                objMatMaster.mat_code = lueMat_code.EditValue.ToString().Trim();
                objMatMaster.size_code = lueSize_code.EditValue.ToString().Trim();
                objMatMaster.stork_minq = clsUtility.FormatNullableFloat(txtstock_minq.Text.Trim());
                objMatMaster.stork_maxq = clsUtility.FormatNullableFloat(txtstock_maxq.Text.Trim());
                objMatMaster.stork_minw = clsUtility.FormatNullableFloat(txtstock_minw.Text.Trim());
                objMatMaster.stork_maxw = clsUtility.FormatNullableFloat(txtstock_maxw.Text.Trim());
                objMatMaster.qty_weg_rate = clsUtility.FormatNullableFloat(txtqty_weg_rate.Text.Trim());
                if (rdbself.Checked == true)
                {
                    objMatMaster.modality = "0";
                }
                if (rdbOutsourcing.Checked == true)
                {
                    objMatMaster.modality = "1";
                }
                if (rdbPurchase.Checked == true)
                {
                    objMatMaster.modality = "2";
                }
                if (rdbEndproduct.Checked == true)
                {
                    objMatMaster.modality = "3";
                }

                objMatMaster.crusr = DBUtility._user_id;
                objMatMaster.amusr = DBUtility._user_id;

                switch (operationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            Result = clsMatMaster.AddMatMaster(objMatMaster);
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            Result = clsMatMaster.UpdateMatMaster(objMatMaster);
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                    operationType = clsUtility.enumOperationType.Save;
                    Find(objMatMaster.prd_item, "", "");

                    TextBoxEnableTrueOrFalse(false);

                    BTNNEW.Enabled = true;
                    BTNEDIT.Enabled = true;
                    BTNSAVE.Enabled = false;
                    BTNDELETE.Enabled = true;
                }
                else
                {
                    MessageBox.Show("保存失敗!");
                }
            }
        }

        /// <summary>
        /// 刪除物料代碼
        /// </summary>
        private void Delete()
        {
            if (dgvDetails.RowCount > 0)
            {
                if (MessageBox.Show("確認刪除該條數據？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strPrd_item = dgvDetails.CurrentRow.Cells["colprd_item"].Value.ToString();
                    int Result = clsMatMaster.DeleteMatMaster(strPrd_item);
                    if (Result > 0)
                    {
                        MessageBox.Show("刪除成功!");
                        operationType = clsUtility.enumOperationType.Delete;
                        ClearTextBox();
                        Find("", "", "");
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗!");
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可進行刪除的數據。");
            }
        }

        private void Find(string pPrd_item, string pPrd_en_desc, string pPrd_chs_desc)
        {
            dtMatMaster = clsMatMaster.GetMatMaster(pPrd_item, pPrd_en_desc, pPrd_chs_desc);
            dgvDetails.DataSource = dtMatMaster;
            dgvDetails.Refresh();
        }

        private void Cancel()
        {
            operationType = clsUtility.enumOperationType.Cancel;

            BTNNEW.Enabled = true;
            BTNEDIT.Enabled = true;
            BTNSAVE.Enabled = false;
            BTNDELETE.Enabled = true;

            ClearTextBox();
            TextBoxEnableTrueOrFalse(false);
        }

        /// <summary>
        /// 綁定所屬部門
        /// </summary>
        private void BindCmboxDept()
        {
            lueDept.Properties.DataSource = clsBs_Dep.GetDepartments("");
            lueDept.Properties.DisplayMember = "dep_id";
            lueDept.Properties.ValueMember = "dep_id";
        }

        /// <summary>
        /// 綁定物料種類
        /// </summary>
        private void BindCmboxMat_Type()
        {
            lueMat_code.Properties.DataSource = clsMaterialType.GetMaterialType("");
            lueMat_code.Properties.DisplayMember = "mat_code";
            lueMat_code.Properties.ValueMember = "mat_code";
        }

        /// <summary>
        /// 綁定產品種類
        /// </summary>
        private void BindCmboxPrd()
        {
            luePrd_code.Properties.DataSource = clsProductType.GetProductType("");
            luePrd_code.Properties.DisplayMember = "prd_code";
            luePrd_code.Properties.ValueMember = "prd_code";
        }

        /// <summary>
        /// 綁定圖樣代號
        /// </summary>
        private void BindCmboxArt()
        {
            lueArtWork.Properties.DataSource = clsArtWork.GetArtWork("", "", "");
            lueArtWork.Properties.DisplayMember = "art";
            lueArtWork.Properties.ValueMember = "art";
        }

        /// <summary>
        /// 綁定尺寸代號
        /// </summary>
        private void BindCmboxSize()
        {
            lueSize_code.Properties.DataSource = clsGetDataForComboBox.GetSzie();
            lueSize_code.Properties.DisplayMember = "size_id";
            lueSize_code.Properties.ValueMember = "size_id";
        }

        /// <summary>
        /// 綁定顏色代號
        /// </summary>
        private void BindCmboxColor()
        {
            lueColor_code.Properties.DataSource = clsGetDataForComboBox.GetColor();
            lueColor_code.Properties.DisplayMember = "clr_code";
            lueColor_code.Properties.ValueMember = "clr_code";
        }

        /// <summary>
        /// 綁定編碼類型
        /// </summary>
        private void BindCodingType()
        {
            lueItem_hgtype.Properties.DataSource = clsGetDataForComboBox.GetCodingType();
            lueItem_hgtype.Properties.DisplayMember = "code_type";
            lueItem_hgtype.Properties.ValueMember = "code_type";
        }


        /// <summary>
        /// 綁定基本單位、重量單位
        /// </summary>
        private void BindCmboxUnit()
        {
            DataTable dtUnit = clsBs_Unit.GetUnitsData("");

            cmboxUnit_w.DataSource = dtUnit;
            cmboxUnit_w.DisplayMember = "unit_id";
            cmboxUnit_w.ValueMember = "unit_id";

            cmboxBase_unit.DataSource = dtUnit;
            cmboxBase_unit.DisplayMember = "unit_id";
            cmboxBase_unit.ValueMember = "unit_id";

        }

        /// <summary>
        /// 設置文本框是否可用
        /// </summary>
        /// <param name="flag"></param>
        private void TextBoxEnableTrueOrFalse(bool flag)
        {
            if (operationType == clsUtility.enumOperationType.Update)
            {
                lueArtWork.Enabled = false;
                lueColor_code.Enabled = false;
                lueMat_code.Enabled = false;
                luePrd_code.Enabled = false;
                lueSize_code.Enabled = false;
                lueItem_hgtype.Enabled = false;
            }
            else
            {
                lueArtWork.Enabled = flag;
                lueColor_code.Enabled = flag;
                lueMat_code.Enabled = flag;
                luePrd_code.Enabled = flag;
                lueSize_code.Enabled = flag;
                lueItem_hgtype.Enabled = flag;
            }

            txtprd_item.Enabled = false;
            txtprd_chs_desc.Enabled = flag;
            txtprd_en_desc.Enabled = flag;
            lueDept.Enabled = flag;
            cmboxBase_unit.Enabled = flag;
            cmboxUnit_w.Enabled = flag;
            txtcreate_date.Enabled = false;
            txtitem_costq.Enabled = flag;
            txtitem_costw.Enabled = flag;
            txtitem_hgcode.Enabled = flag;
            txtitem_hscode.Enabled = flag;
            txtitem_img.Enabled = flag;
            txtitem_part.Enabled = flag;
            txtitem_type.Enabled = flag;
            txtitem_waste.Enabled = flag;
            txtqty_weg_rate.Enabled = flag;
            txtremark.Enabled = flag;
            txtstock_maxq.Enabled = flag;
            txtstock_maxw.Enabled = flag;
            txtstock_minq.Enabled = flag;
            txtstock_minw.Enabled = flag;
        }

        /// <summary>
        /// 清空文本框內容
        /// </summary>
        private void ClearTextBox()
        {
            txtprd_item.Text = "";
            txtprd_chs_desc.Text = "";
            txtprd_en_desc.Text = "";
            lueDept.EditValue = "";
            lueArtWork.EditValue = "";
            cmboxBase_unit.Text = "";
            lueColor_code.EditValue = "";
            lueMat_code.EditValue = "";
            luePrd_code.EditValue = "";
            lueSize_code.EditValue = "";
            lueItem_hgtype.EditValue = "";
            cmboxUnit_w.Text = "";
            txtcreate_date.Text = "";
            txtitem_costq.Text = "";
            txtitem_costw.Text = "";
            txtitem_hgcode.Text = "";
            txtitem_hscode.Text = "";
            txtitem_img.Text = "";
            txtitem_part.Text = "";
            txtitem_type.Text = "";
            txtitem_waste.Text = "";
            txtqty_weg_rate.Text = "";
            txtremark.Text = "";
            txtstock_maxq.Text = "";
            txtstock_maxw.Text = "";
            txtstock_minq.Text = "";
            txtstock_minw.Text = "";
        }

        private bool ValidateText()
        {
            if (lueMat_code.Text.Trim() == "")
            {
                MessageBox.Show("物料種類不能為空，請選擇物料種類。");
                lueMat_code.Focus();
                return false;
            }

            if (luePrd_code.Text.Trim() == "")
            {
                MessageBox.Show("產品種類不能為空，請選擇產品種類。");
                luePrd_code.Focus();
                return false;
            }

            if (lueArtWork.Text.Trim() == "")
            {
                MessageBox.Show("圖樣代號不能為空，請選擇圖樣代號。");
                lueArtWork.Focus();
                return false;
            }

            if (lueSize_code.Text.Trim() == "")
            {
                MessageBox.Show("尺寸代號不能為空，請選擇尺寸代號。");
                lueSize_code.Focus();
                return false;
            }

            if (lueColor_code.Text.Trim() == "")
            {
                MessageBox.Show("顏色代號不能為空，請選擇顏色代號。");
                lueColor_code.Focus();
                return false;
            }

            if (txtitem_costq.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtitem_costq.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("數量成本只能是數字類型，請重新輸入。");
                    txtitem_costq.Focus();
                    txtitem_costq.SelectAll();
                    return false;
                }
            }

            if (txtitem_costw.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtitem_costw.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("重量成本只能是數字類型，請重新輸入。");
                    txtitem_costw.Focus();
                    txtitem_costw.SelectAll();
                    return false;
                }
            }

            if (txtqty_weg_rate.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtqty_weg_rate.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("重量對應個數只能是數字類型，請重新輸入。");
                    txtqty_weg_rate.Focus();
                    txtqty_weg_rate.SelectAll();
                    return false;
                }
            }

            if (txtitem_waste.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtitem_waste.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("廢料只能是數字類型，請重新輸入。");
                    txtitem_waste.Focus();
                    txtitem_waste.SelectAll();
                    return false;
                }
            }

            if (txtstock_maxq.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtstock_maxq.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("最高存數量只能是數字類型，請重新輸入。");
                    txtstock_maxq.Focus();
                    txtstock_maxq.SelectAll();
                    return false;
                }
            }

            if (txtstock_minq.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtstock_minq.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("最低存數量只能是數字類型，請重新輸入。");
                    txtstock_minq.Focus();
                    txtstock_minq.SelectAll();
                    return false;
                }
            }

            if (txtstock_maxw.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtstock_maxw.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("最高存重量只能是數字類型，請重新輸入。");
                    txtstock_maxw.Focus();
                    txtstock_maxw.SelectAll();
                    return false;
                }
            }

            if (txtstock_minw.Text.Trim() != "")
            {
                if (!Verify.StringValidating(txtstock_minw.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
                {
                    MessageBox.Show("最低存重量只能是數字類型，請重新輸入。");
                    txtstock_minw.Focus();
                    txtstock_minw.SelectAll();
                    return false;
                }
            }

            if (rdbself.Checked == false && rdbOutsourcing.Checked == false && rdbPurchase.Checked == false && rdbEndproduct.Checked == false)
            {
                MessageBox.Show("請選擇管制類型。");
                return false;
            }

            return true;
        }


    }
}
