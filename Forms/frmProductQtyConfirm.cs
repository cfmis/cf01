using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ModuleClass;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmProductQtyConfirm : Form
    {
       
        public frmProductQtyConfirm()
        {
            InitializeComponent();
        }

        private void frmProductQtyConfirm_Load(object sender, EventArgs e)
        {
            //clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            //forminit.GenerateContorl();


            //dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            //dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性

            this.mktDate1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.mktDate2.Text = DateTime.Now.ToString("yyyy/MM/dd");

            Font a = new Font("GB2312", 14);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            find_data();
        }
        private void find_data()
        {
            string conf_flag, qc_flag;
            string conf_date1, conf_date2;
            string prd_date1, prd_date2;
            conf_flag = "";
            qc_flag = "";
            conf_date1 = "";
            conf_date2 = "";
            prd_date1 = "";
            prd_date2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.mktDate1.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktDate1.Text) == false)
                {
                    MessageBox.Show("日期不正確!");
                    this.mktDate1.Focus();
                    return;
                }
                else
                    prd_date1 = this.mktDate1.Text;
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktDate2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.mktDate2.Text) == false)
                {
                    MessageBox.Show("日期不正確!");
                    this.mktDate2.Focus();
                    return;
                }
                else
                    prd_date2 = this.mktDate2.Text;
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktConfTime1.Text) == false)
            {
                if (clsValidRule.CheckDateTimeFormat(this.mktConfTime1.Text) == false)
                {
                    MessageBox.Show("確認時間不正確!");
                    this.mktConfTime1.Focus();
                    return;
                }
                else
                    conf_date1 = mktConfTime1.Text;
            }
            if (clsValidRule.CheckDateIsEmpty(this.mktConfTime2.Text) == false)
            {
                if (clsValidRule.CheckDateTimeFormat(this.mktConfTime2.Text) == false)
                {
                    MessageBox.Show("確認時間不正確!");
                    this.mktConfTime2.Focus();
                    return;
                }
                else
                    conf_date2 = mktConfTime2.Text;
            }

            if (rdbNoConf.Checked == true)//未確認收貨
                conf_flag="N";
            if (rdbYesConf.Checked == true)//已確認收貨
                conf_flag = "Y";
            if (chkQc.Checked == false)//是否已QC
                qc_flag="Y";
            //this.BindDataGridView(strWhere);

            this.dgvDetails.DataSource = clsProductionSchedule.GetProductQtyConfirm(
                textDep1.Text
                ,prd_date1,prd_date2
                ,textMo1.Text.Trim()
                ,conf_date1,conf_date2
                ,qc_flag, conf_flag
                );
            if (dgvDetails.RowCount > 0)
            {
                FillControls();
            }
        }
        private bool valid_data()
        {
            if (txtReq.Text == "")
            {
                MessageBox.Show("記錄號無效,不能儲存!");
                return false;
            }
            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("磅貨數量格式無效!");
                return false;
            }
            else
                if (Convert.ToInt32(txtQty.Text) <= 0)
                {
                    MessageBox.Show("磅貨數量格式無效!");
                    return false;
                }
            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("磅貨重量格式無效!");
                return false;
            }
            else
                if (Convert.ToSingle(txtQty.Text) <= 0)
                {
                    MessageBox.Show("磅貨重量格式無效!");
                    return false;
                }
            return true;
        }

        private void save_process()
        {
            product_records objModel = new product_records();
            objModel.prd_id = Convert.ToInt32(txtReq.Text);
            objModel.actual_qty = Convert.ToSingle(txtQty.Text);
            objModel.actual_weg = Convert.ToDecimal(txtWeg.Text);
            objModel.actual_pack_num = Convert.ToInt32(txtActualPack.Text);
            objModel.mat_item = txtMatItem.Text.ToString();
            objModel.mat_item_lot = txtMatLot.Text.ToString();
            objModel.mat_item_desc = txtMatDesc.Text.ToString();
            objModel.conf_time = System.DateTime.Now;
            objModel.conf_flag = "Y";
            if (clsProductionSchedule.UpdatePrrdActualQty(objModel) > 0)
            {
                MessageBox.Show("儲存成功！", "系統信息");
                find_data();
            }
            else
            {
                MessageBox.Show("儲存失敗！", "系統信息");
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                FillControls();
            }
        }
        private void FillControls()
        {
            this.txtReq.Text = this.dgvDetails[0, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtPrdMo.Text = this.dgvDetails[3, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtPrdItem.Text = this.dgvDetails[4, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtItemDesc.Text = this.dgvDetails[5, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtQty.Text = this.dgvDetails[6, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtWeg.Text = this.dgvDetails[7, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtMatItem.Text = this.dgvDetails[10, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtMatDesc.Text = this.dgvDetails[14, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtMatLot.Text = this.dgvDetails[11, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtActualPack.Text = this.dgvDetails[12, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
            this.txtToDep.Text = this.dgvDetails[13, this.dgvDetails.CurrentCell.RowIndex].Value.ToString().Trim();
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (valid_data() == false)
                return;
            save_process();
        }

        private void mktDate1_TextChanged(object sender, EventArgs e)
        {
            mktDate2.Text = mktDate1.Text;
        }

        private void mktConfTime1_TextChanged(object sender, EventArgs e)
        {
            mktConfTime2.Text = mktConfTime1.Text;
        }

        private void textMo1_TextChanged(object sender, EventArgs e)
        {
            mktConfTime1.Text = "";
            mktConfTime2.Text = "";
            mktDate1.Text = "";
            mktDate2.Text = "";
            find_data();
        }
    }
}
