using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Threading;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmUpdatePlatePrice : Form
    {
        clsCommonUse commUse = new clsCommonUse();
      
        //string lang_id = PropertyClass.LanguageId;
        string lang_id = DBUtility._language;
        string user_id = DBUtility._user_id;
        private DataTable dtPlatePrice = new DataTable();
        public frmUpdatePlatePrice()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdatePlatePrice_Load(object sender, EventArgs e)
        {
            clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            forminit.GenerateContorl();

            this.BTNSAVE.Enabled = false;  //加載時屏蔽保存按鈕
            this.dateEdit1.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            this.dateEdit2.EditValue = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("訂單日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.ShowDialog();
            }).Start();

            this.find_data(); //数据处理
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            //如果查詢結果不為空，則啟用保存
            if (dtPlatePrice.Rows.Count > 0)
            {
                this.BTNSAVE.Enabled = true;
            }

        }

        private void find_data()
        {
            string dat1 = "", dat2 = "";
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false)
                dat1 = this.dateEdit1.Text.ToString();// Convert.ToDateTime(this.dateEdit1.EditValue).ToString("yyyy/mm/dd");
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
                dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
            //dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");

            dtPlatePrice = commUse.getDataProcedure("zsp_show_plate_doc",
                new object[] { txt_vend_id1.Text, txt_vend_id2.Text, dat1, dat2, textBox5.Text, textBox6.Text 
                            ,textBox7.Text,textBox8.Text,textBox9.Text,textBox10.Text});
            dgvDetails.DataSource = dtPlatePrice;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txt_vend_id1.Focus();
            if (dgvDetails.Rows.Count > 0)
            {
                SavePlatePrice();
            }
        }

        public void SavePlatePrice()
        {
            List<rece_goods_plate> lsModel = new List<rece_goods_plate>();
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["colCheckBox"].EditedFormattedValue)
                {
                    rece_goods_plate objModel = new rece_goods_plate();
                    objModel.vendor_id = dtPlatePrice.Rows[i]["vendor_id"].ToString();
                    objModel.rec_id = dtPlatePrice.Rows[i]["rec_id"].ToString();
                    objModel.ir_date = dtPlatePrice.Rows[i]["ir_date"].ToString();
                    objModel.sequence_id = dtPlatePrice.Rows[i]["sequence_id"].ToString();
                    objModel.mo_id = dtPlatePrice.Rows[i]["mo_id"].ToString();
                    objModel.goods_id = dtPlatePrice.Rows[i]["goods_id"].ToString();
                    objModel.vendor_invoice_no = dtPlatePrice.Rows[i]["vendor_invoice_no"].ToString();
                    objModel.t_ir_qty = clsUtility.FormatNullableInt32(dtPlatePrice.Rows[i]["t_ir_qty"]);
                    objModel.price = clsUtility.FormatNullableInt32(dtPlatePrice.Rows[i]["price"]);
                    objModel.ir_unit = dtPlatePrice.Rows[i]["ir_unit"].ToString();
                    objModel.sec_qty = clsUtility.FormatNullableInt32(dtPlatePrice.Rows[i]["sec_qty"]);
                    objModel.sec_price = clsUtility.FormatNullableInt32(dtPlatePrice.Rows[i]["sec_price"]);
                    objModel.sec_unit = dtPlatePrice.Rows[i]["sec_unit"].ToString();
                    objModel.p_unit = dtPlatePrice.Rows[i]["p_unit"].ToString();
                    objModel.min_consume_amount = clsUtility.FormatNullableInt32(dtPlatePrice.Rows[i]["min_consume_amount"]);
                    objModel.package_num = clsUtility.FormatNullableInt32(dtPlatePrice.Rows[i]["package_num"]);
                    objModel.do_color = dtPlatePrice.Rows[i]["do_color"].ToString();
                    objModel.total_amt = clsUtility.FormatNullableInt32(dgvDetails.Rows[i].Cells["colorg_amt"].Value);
                    lsModel.Add(objModel);
                }
            }

            if (lsModel.Count > 0)
            {
                int Result = clsPlateFee.AddPlatePrice(lsModel);
                if (Result > 0)
                {
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("保存失敗！");
                }
            }
            else
            {
                MessageBox.Show("請選中電鍍單，并設定金額");
            }
        }

    }
}
