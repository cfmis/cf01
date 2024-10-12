using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleForm;
using cf01.ModuleClass;
using Microsoft.VisualBasic;
using cf01.CLS;
using cf01.MDL;

namespace cf01.ReportForm
{
    public partial class frmOutgoingColorPlateSetting : BaseFormMaster
    {
        private clsUtility.enumOperationType Operation;

        public frmOutgoingColorPlateSetting()
        {
            InitializeComponent();

            clsPublic objPublic = new clsPublic("frmOutgoingColorPlateSetting", this.Controls);
            objPublic.GenerateData();
        }

        private void frmOutgoingColorPlateSetting_Load(object sender, EventArgs e)
        {
            Operation = clsUtility.enumOperationType.Load;
            ControlStatus(Operation);
            clsUtility.EnableToolStripButton(toolStrip1, Operation);

            //設置供應商顯示多列
            MultipleColumnComboBox multiCmbox = new MultipleColumnComboBox();
            //multiCmbox.DesignComboBoxColummn(cmboxVendor, "id", "name");
            BindVendor();
            clsPublic.GenerateGoodsUnit(null, cmboxUnit);   //綁定單位

            lueVendor.EditValue = "";
        }

        //綁定供應商
        private void BindVendor()
        {
            DataTable dtVendor = clsVendor.GetVendorInfo();
            //cmboxVendor.DataSource = dtVendor;
            //cmboxVendor.DisplayMember = "id";
            //cmboxVendor.ValueMember = "name";
            lueVendor.Properties.DataSource = dtVendor;
            lueVendor.Properties.ValueMember = "id";
            lueVendor.Properties.DisplayMember = "name";

            //lookUpEdit1.Properties.DataSource = dtVendor;
            //lookUpEdit1.Properties.ValueMember = "id";
            //lookUpEdit1.Properties.DisplayMember = "id";


            this.comboBoxEdit1.Properties.NullText = "请选择...";

            for (int i = 0; i < dtVendor.Rows.Count; i++)
            {
                comboBoxEdit1.Properties.Items.Add(dtVendor.Rows[i]["id"].ToString());
            }
        }


        public override void New()
        {
            Operation = clsUtility.enumOperationType.Add;
            ControlStatus(Operation);

            clsUtility.EnableToolStripButton(toolStrip1, Operation);
        }

        public override void Edit()
        {
            if (dgvColorPlate.RowCount > 0)
            {
                Operation = clsUtility.enumOperationType.Update;
                ControlStatus(Operation);
                clsUtility.EnableToolStripButton(toolStrip1, Operation);
            }
            else
            {
                MessageBox.Show("請查詢數據后，再點擊編輯按鈕。");
                return;
            }
        }

        public override void Save()
        {
            if (ValidateTextInput())
            {
                int Result = -1;

                mdlColorPlateQuotation objModel = new mdlColorPlateQuotation();
                objModel.color_id = txtColor_id.Text.Trim();
                objModel.color_desc = txtColor_name.Text.Trim();
                objModel.vend_color = txtVendor_color.Text.Trim();
                objModel.vendor_id = lueVendor.Text.ToString();
                objModel.fee = Convert.ToInt32(txtUnitPrice.Text.Trim());
                objModel.unit = cmboxUnit.Text.ToString();
                objModel.quotation_no = txtQuotation_no.Text.Trim();
                objModel.quotation_date = dtpQuotation_date.dateEdit1.Text.ToString();
                objModel.valid_date = dtpValid_date.dateEdit1.Text.ToString();
                try
                {
                    switch (Operation)
                    {
                        case clsUtility.enumOperationType.Add:
                            {
                                Result = clsColorPlateQuotation.AddColorPlateQuotation(objModel);
                                if (Result > 0)
                                {
                                    MessageBox.Show("單據信息添加成功。");
                                }
                            }
                            break;
                        case clsUtility.enumOperationType.Update:
                            {
                                Result = clsColorPlateQuotation.UpdateColorPlateQuotation(objModel);
                                if (Result > 0)
                                {
                                    MessageBox.Show("單據信息修改成功。");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (Result > 0)
                {
                    Operation = clsUtility.enumOperationType.Save;
                    ControlStatus(Operation);
                    GetColorPlateQuotation(this.txtQuotation_no.Text, this.txtColor_id.Text);

                    clsUtility.EnableToolStripButton(toolStrip1, Operation);
                }
            }
        }

        /// <summary>
        ///移除單據信息 
        /// </summary>
        public override void Remove()
        {
            if (dgvColorPlate.RowCount > 0)
            {
                try
                {
                    string strQuotation_no = dgvColorPlate["quotation_no", dgvColorPlate.CurrentRow.Index].Value.ToString();
                    if (MessageBox.Show("請確認是否刪除報價單號為:" + strQuotation_no + "的單據信息？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strColor_id = dgvColorPlate["clr", dgvColorPlate.CurrentRow.Index].Value.ToString();
                        int Result = clsColorPlateQuotation.DeleteColorPlateQuotation(strQuotation_no, strColor_id);

                        if (Result > 0)
                        {
                            MessageBox.Show("數據已刪除。");
                            Operation = clsUtility.enumOperationType.Delete;
                            ControlStatus(Operation);

                            GetColorPlateQuotation(this.txtQuotation_no.Text, this.txtColor_id.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public override void Find()
        {
            Operation = clsUtility.enumOperationType.Find;
            ControlStatus(Operation);

            GetColorPlateQuotation("", "");
        }

        public override void Cancel()
        {
            Operation = clsUtility.enumOperationType.Cancel;
            ControlStatus(Operation);

            clsUtility.EnableToolStripButton(toolStrip1, Operation);
        }

        /// <summary>
        /// 雙擊選取需要編輯的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvColorPlate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvColorPlate.RowCount > 0)
            {
                txtColor_id.Text = dgvColorPlate["clr", dgvColorPlate.CurrentRow.Index].Value.ToString();
                txtColor_name.Text = dgvColorPlate["clr_desc", dgvColorPlate.CurrentRow.Index].Value.ToString();
                txtVendor_color.Text = dgvColorPlate["vendor_color", dgvColorPlate.CurrentRow.Index].Value.ToString();
                txtUnitPrice.Text = dgvColorPlate["unit_price", dgvColorPlate.CurrentRow.Index].Value.ToString();
                cmboxUnit.Text = dgvColorPlate["p_unit", dgvColorPlate.CurrentRow.Index].Value.ToString();
                txtQuotation_no.Text = dgvColorPlate["quotation_no", dgvColorPlate.CurrentRow.Index].Value.ToString();
                dtpQuotation_date.dateEdit1.EditValue = clsUtility.FormatNullableDateTime(dgvColorPlate["quotation_date", dgvColorPlate.CurrentRow.Index].Value);
                dtpValid_date.dateEdit1.EditValue = clsUtility.FormatNullableDateTime(dgvColorPlate["valid_date", dgvColorPlate.CurrentRow.Index].Value);
                //lueVendor.Text   = dgvColorPlate["vendor_id", dgvColorPlate.CurrentRow.Index].Value.ToString();
                //lueVendor.Properties.DataSource = null;
                lueVendor.Properties.NullText = dgvColorPlate["vendor_id", dgvColorPlate.CurrentRow.Index].Value.ToString();
                lookUpEdit1.Properties.DataSource = null;
                lookUpEdit1.Properties.NullText = dgvColorPlate["vendor_id", dgvColorPlate.CurrentRow.Index].Value.ToString();
            }
        }

        /// <summary>
        /// 根據條件查詢單據信息
        /// </summary>
        private void GetColorPlateQuotation(string quotation_no, string color_id)
        {
            try
            {
                DataTable dtColorPlate = clsColorPlateQuotation.GetColorPlateQuotation(quotation_no, color_id);
                if (dtColorPlate.Rows.Count > 0)
                {
                    dgvColorPlate.DataSource = dtColorPlate;
                    dgvColorPlate.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 根據操作類型改變控件狀態
        /// </summary>
        /// <param name="OpertatinType"></param>
        private void ControlStatus(clsUtility.enumOperationType OpertatinType)
        {
            switch (OpertatinType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        txtColor_id.Enabled = true;
                        txtColor_name.Enabled = true;
                        txtVendor_color.Enabled = true;
                        txtQuotation_no.Enabled = true;
                        txtUnitPrice.Enabled = true;
                        lueVendor.Properties.ReadOnly = false;
                        cmboxUnit.Enabled = true;
                        dtpValid_date.Enabled = true;
                        dtpQuotation_date.Enabled = true;

                        txtColor_id.Text = "";
                        txtColor_name.Text = "";
                        txtVendor_color.Text = "";
                        txtQuotation_no.Text = "";
                        txtUnitPrice.Text = "";

                        txtColor_id.Focus();
                    }
                    break;
                case clsUtility.enumOperationType.Delete:
                    {
                        txtColor_id.Text = "";
                        txtColor_name.Text = "";
                        txtVendor_color.Text = "";
                        txtQuotation_no.Text = "";
                        txtUnitPrice.Text = "";

                        txtColor_id.Enabled = false;
                        txtColor_name.Enabled = false;
                        txtVendor_color.Enabled = false;
                        txtQuotation_no.Enabled = false;
                        txtUnitPrice.Enabled = false;
                        lueVendor.Properties.ReadOnly = true;
                        cmboxUnit.Enabled = false;
                        dtpValid_date.Enabled = false;
                        dtpQuotation_date.Enabled = false;
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        txtColor_id.Enabled = false;
                        txtColor_name.Enabled = true;
                        txtVendor_color.Enabled = true;
                        txtQuotation_no.Enabled = false;
                        txtUnitPrice.Enabled = true;
                        lueVendor.Properties.ReadOnly = false;
                        cmboxUnit.Enabled = true;
                        dtpValid_date.Enabled = false;
                        dtpQuotation_date.Enabled = true;
                    }
                    break;
                case clsUtility.enumOperationType.Find:
                    {
                        txtColor_id.Enabled = true;
                        txtQuotation_no.Enabled = true;
                        txtColor_name.Enabled = false;
                        txtVendor_color.Enabled = false;
                        txtUnitPrice.Enabled = false;
                        lueVendor.Properties.ReadOnly = true;
                        cmboxUnit.Enabled = false;
                        dtpQuotation_date.Enabled = false;
                        dtpValid_date.Enabled = false;
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        txtColor_id.Enabled = false;
                        txtColor_name.Enabled = false;
                        txtVendor_color.Enabled = false;
                        txtQuotation_no.Enabled = false;
                        txtUnitPrice.Enabled = false;
                        lueVendor.Properties.ReadOnly = true;
                        cmboxUnit.Enabled = false;
                        dtpQuotation_date.Enabled = false;
                        dtpValid_date.Enabled = false;
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {
                        txtColor_id.Enabled = false;
                        txtColor_name.Enabled = false;
                        txtVendor_color.Enabled = false;
                        txtQuotation_no.Enabled = false;
                        txtUnitPrice.Enabled = false;
                        lueVendor.Properties.ReadOnly = true;
                        cmboxUnit.Enabled = false;
                        dtpQuotation_date.Enabled = false;
                        dtpValid_date.Enabled = false;

                        txtColor_id.Text = "";
                        txtColor_name.Text = "";
                        txtVendor_color.Text = "";
                        txtQuotation_no.Text = "";
                        txtUnitPrice.Text = "";

                        dgvColorPlate.DataSource = null;
                        dgvColorPlate.Refresh();
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        txtColor_id.Enabled = false;
                        txtColor_name.Enabled = false;
                        txtVendor_color.Enabled = false;
                        txtQuotation_no.Enabled = false;
                        txtUnitPrice.Enabled = false;
                        lueVendor.Properties.ReadOnly = true;
                        cmboxUnit.Enabled = false;
                        dtpQuotation_date.Enabled = false;
                        dtpValid_date.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 驗證文本框輸入格式
        /// </summary>
        /// <returns></returns>
        private bool ValidateTextInput()
        {
            if (txtColor_id.Text.Trim() == "")
            {
                MessageBox.Show("請輸入顏色代號。");
                txtColor_id.Focus();
                return false;
            }
            if (txtColor_name.Text.Trim() == "")
            {
                MessageBox.Show("請輸入顏色描述。");
                txtColor_name.Focus();
                return false;
            }
            if (txtVendor_color.Text.Trim() == "")
            {
                MessageBox.Show("請輸入供應商顏色編號。");
                txtVendor_color.Focus();
                return false;
            }
            if (txtQuotation_no.Text.Trim() == "")
            {
                MessageBox.Show("請輸入報價單號。");
                txtQuotation_no.Focus();
                return false;
            }
            if (txtUnitPrice.Text.Trim() == "")
            {
                MessageBox.Show("請輸入單價。");
                txtUnitPrice.Focus();
                return false;
            }
            if (!Information.IsNumeric(txtUnitPrice.Text.Trim()))
            {
                MessageBox.Show("單價只能是數字類型，請輸入正確的格式。");
                txtUnitPrice.Focus();
                txtUnitPrice.SelectAll();
                return false;
            }
            if (clsValidRule.CheckDateFormat(this.dtpQuotation_date.dateEdit1.Text) == false)
            {
                MessageBox.Show("報價單日期不正確!");
                this.dtpQuotation_date.Focus();
                return false;
            }
            if (clsValidRule.CheckDateFormat(this.dtpValid_date.dateEdit1.Text) == false)
            {
                MessageBox.Show("生效日期不正確!");
                this.dtpValid_date.Focus();
                return false;
            }
            return true;
        }





    }
}
