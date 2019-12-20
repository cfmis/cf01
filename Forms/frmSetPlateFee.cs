using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Globalization;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmSetPlateFee : cf01.ModuleForm.BaseFormMaster
    {

        private List<mdlmt_plate_fee> lsPlate_Fee = new List<mdlmt_plate_fee>();
        clsCommonUse commUse = new clsCommonUse();
        string lang_id = DBUtility._language;

        public frmSetPlateFee()
        {
            InitializeComponent();
            clsPublic objPublic = new clsPublic(this.Name, this.Controls);
            objPublic.GenerateData();
        }

        private void frmSetPlateFee_Load(object sender, EventArgs e)
        {
            txtqGoods_id.Text = "MLBCBC";
            InitControlEnabled(false);

            //綁定表格
            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "operator_word" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbOperator1, "formname", "show_name", strsql, "v_dict_group");
            commUse.BindComboBox(cmbOperator2, "formname", "show_name", strsql, "v_dict_group");
            commUse.BindComboBox(cmbOperator3, "formname", "show_name", strsql, "v_dict_group");
            strsql = "Select * from v_dict_group where formname=" + "'" + "ShowSetting" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbShowSetting, "formname", "show_name", strsql, "v_dict_group");

            //綁定貨物單位、幣種
            clsPublic.GenerateGoodsUnit(null, cmbGoods_unit);
            clsPublic.GenerateCurrency(null, cmbCurrency);

        }


        private void InitControlEnabled(bool Isavailable)
        {
            if (Isavailable)
            {
                txtMt_fee.Enabled = true;
                txtShowgoods_id.Enabled = false;
                txtShowgoods_name.Enabled = false;
                mkValidDate.Enabled = true;
                cmbCurrency.Enabled = true;
                cmbGoods_unit.Enabled = true;
            }
            else
            {
                txtMt_fee.Enabled = false;
                txtShowgoods_id.Enabled = false;
                txtShowgoods_name.Enabled = false;
                mkValidDate.Enabled = false;
                cmbCurrency.Enabled = false;
                cmbGoods_unit.Enabled = false;
            }
        }

        public override void Find()
        {
            int set_flag, op1, op2, op3;
            set_flag = cmbShowSetting.SelectedIndex + 1;
            op1 = cmbOperator1.SelectedIndex + 1;
            op2 = cmbOperator2.SelectedIndex + 1;
            op3 = cmbOperator3.SelectedIndex + 1;
           
            DataTable dt = commUse.getDataProcedure("zsp_show_plate_setting",
                new object[] { set_flag, op1, txtqGoods_id.Text.ToString(), op2, txtqGoods_name.Text.ToString(), op3, txtqGoods_Ename.Text.ToString() });
            BindGrid(dt);
        }

        private void BindGrid(DataTable dts)
        {
            dgvDetails.Rows.Clear();
            dgvDetails.RowCount = dts.Rows.Count;
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                dgvDetails.Rows[i].Cells["goods_ename"].Value = dts.Rows[i]["mt_desc"].ToString();
                dgvDetails.Rows[i].Cells["goods_id"].Value = dts.Rows[i]["mt_item"].ToString();
                dgvDetails.Rows[i].Cells["goods_name"].Value = dts.Rows[i]["mt_cdesc"].ToString();
                dgvDetails.Rows[i].Cells["mt_fee"].Value = dts.Rows[i]["mt_fee"].ToString();
                dgvDetails.Rows[i].Cells["valid_date"].Value = dts.Rows[i]["valid_date"].ToString();
                switch (dts.Rows[i]["goods_unit"].ToString())
                {
                    case "PCS":
                        dgvDetails.Rows[i].Cells["goods_unit"].Value = 0;
                        break;
                    case "KG":
                        dgvDetails.Rows[i].Cells["goods_unit"].Value = 1;
                        break;
                    case "GRS":
                        dgvDetails.Rows[i].Cells["goods_unit"].Value = 2;
                        break;
                    case "SET":
                        dgvDetails.Rows[i].Cells["goods_unit"].Value = 3;
                        break;
                    case "G":
                        dgvDetails.Rows[i].Cells["goods_unit"].Value = 4;
                        break;
                    default:
                        break;
                }

                switch (dts.Rows[i]["m_id"].ToString())
                {
                    case "USD":
                        dgvDetails.Rows[i].Cells["m_id"].Value = 0;
                        break;
                    case "HKD":
                        dgvDetails.Rows[i].Cells["m_id"].Value = 1;
                        break;
                    case "RMB":
                        dgvDetails.Rows[i].Cells["m_id"].Value = 2;
                        break;
                    default:
                        break;
                }
            }
        }

        public override void Save()
        {
            GetPlate_Fee();
            if (lsPlate_Fee.Count > 0)
            {
                int Result = clsPlateFee.AddPlate_Fee(lsPlate_Fee);
                if (Result > 0)
                {
                    MessageBox.Show("保存成功。");
                }
            }
        }

        private void GetPlate_Fee()
        {
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["colCheckBox"].EditedFormattedValue)
                {
                    if (ValidateGridCell(i))
                    {
                        mdlmt_plate_fee mdlPlate_Fee = new mdlmt_plate_fee();
                        mdlPlate_Fee.mt_item = dgvDetails.Rows[i].Cells["goods_id"].Value.ToString();
                        mdlPlate_Fee.valid_date = dgvDetails.Rows[i].Cells["valid_date"].Value.ToString();
                        mdlPlate_Fee.mt_fee = Convert.ToDecimal(dgvDetails.Rows[i].Cells["mt_fee"].Value);

                        switch (Convert.ToInt32(dgvDetails.Rows[i].Cells["goods_unit"].Value))
                        {
                            case 0:
                                mdlPlate_Fee.mt_unit = "PCS";
                                break;
                            case 1:
                                mdlPlate_Fee.mt_unit = "KG";
                                break;
                            case 2:
                                mdlPlate_Fee.mt_unit = "GRS";
                                break;
                            case 3:
                                mdlPlate_Fee.mt_unit = "SET";
                                break;
                            case 4:
                                mdlPlate_Fee.mt_unit = "G";
                                break;
                            default:
                                break;
                        }

                        switch (Convert.ToInt32(dgvDetails.Rows[i].Cells["m_id"].Value))
                        {
                            case 0:
                                mdlPlate_Fee.mt_curr = "USD";
                                break;
                            case 1:
                                mdlPlate_Fee.mt_curr = "HKD";
                                break;
                            case 2:
                                mdlPlate_Fee.mt_curr = "RMB";
                                break;
                            default:
                                break;
                        }

                        lsPlate_Fee.Add(mdlPlate_Fee);
                    }
                }
            }
        }

        private bool ValidateGridCell(int intIndex)
        {
            if (dgvDetails.Rows[intIndex].Cells["valid_date"].Value.ToString() == "")
            {
                MessageBox.Show("有效日期不能為空，請輸入日期。");
                return false;
            }
            //DateTime dt;
            //if (DateTime.TryParseExact(dgvDetails.Rows[intIndex].Cells["valid_date"].Value.ToString(), "yyyy/MM/dd", null, DateTimeStyles.None, out dt))
            //{
            //    MessageBox.Show("日期格式有誤，請輸入正確的格式‘yyyy/MM/dd’");
            //    return false;
            //}

            if (dgvDetails.Rows[intIndex].Cells["mt_fee"].Value.ToString() == "")
            {
                MessageBox.Show("費用不能為空，請輸入費用金額。");
                return false;
            }

            if (dgvDetails.Rows[intIndex].Cells["goods_unit"].Value.ToString() == "")
            {
                MessageBox.Show("請選擇物料單位類型。");
                return false;
            }

            if (dgvDetails.Rows[intIndex].Cells["m_id"].Value.ToString() == "")
            {
                MessageBox.Show("請選擇貨幣種類。");
                return false;
            }

            return true;
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                txtShowgoods_id.Text = dgvDetails["goods_id", dgvDetails.CurrentCell.RowIndex].Value.ToString();
                txtShowgoods_name.Text = dgvDetails["goods_name", dgvDetails.CurrentCell.RowIndex].Value.ToString();
                mkValidDate.Text = dgvDetails["valid_date", dgvDetails.CurrentCell.RowIndex].Value.ToString();
                txtMt_fee.Text = dgvDetails["mt_fee", dgvDetails.CurrentCell.RowIndex].Value.ToString();

                if (dgvDetails.CurrentCell.ColumnIndex == 0)
                {
                    if ((bool)dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colCheckBox"].EditedFormattedValue)
                    {
                        dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colCheckBox"].Value = 0;
                        InitControlEnabled(false);
                    }
                    else
                    {
                        dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colCheckBox"].Value = 1;
                        InitControlEnabled(true);
                    }
                }
                else
                {
                    if ((bool)dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colCheckBox"].EditedFormattedValue)
                    {
                        InitControlEnabled(true);
                    }
                    else
                    {
                        InitControlEnabled(false);
                    }
                }

            }
        }

        private void mkValidDate_TextChanged(object sender, EventArgs e)
        {
            dgvDetails["valid_date", dgvDetails.CurrentCell.RowIndex].Value = mkValidDate.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dgvDetails["mt_fee", dgvDetails.CurrentCell.RowIndex].Value = txtMt_fee.Text;
        }

        private void cmbGoods_unit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dgvDetails["goods_unit", dgvDetails.CurrentCell.RowIndex].Value = cmbGoods_unit.SelectedValue;
            }
        }

        private void cmbCurrency_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dgvDetails["m_id", dgvDetails.CurrentCell.RowIndex].Value = cmbCurrency.SelectedValue;
            }
        }

    }
}
