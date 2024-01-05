/*
 * Create by :   Allen Leung
 * Create Date : 2019-04-26
 * remark:
 * 提取訂單資料 --L組梁德武
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using cf01.CLS;
using cf01.Forms;
using System.Threading;
//using cf01.Reports;

namespace cf01.ReportForm
{
    public partial class frmGetOcData : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();        
        DataTable dtDelivery = new DataTable();        
        
        public frmGetOcData()
        {
            InitializeComponent();
            try
            {
                //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                //control.GenerateContorl();
               // clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
               // obj_ctl.Translate();
               // clsApp.RetSetImage(toolStrip1);//因翻譯部分代碼的影響，當前菜單按鈕圖片及文本樣式異常.
                
                //設置菜單按鈕的權限
                //clsApp.SetToolBarEnable(this.Name, this.Controls);
                clsApp.Initialize_find_value(this.Name, panel1.Controls);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void frmGetOcData_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(dtDat1.Text))
            //    dtDat1.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            //if (string.IsNullOrEmpty(dtDat2.Text))
            //    dtDat2.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            //客戶編號
            DataTable dtCustomer = clsCustComplain.GetCustomerData();
            lueCust1.Properties.DataSource = dtCustomer;
            lueCust1.Properties.ValueMember = "id";
            lueCust1.Properties.DisplayMember = "id";

            lueCust2.Properties.DataSource = dtCustomer;
            lueCust2.Properties.ValueMember = "id";
            lueCust2.Properties.DisplayMember = "id";

        }

        private void frmGetOcData_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtDelivery.Dispose();            
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDat2.EditValue = dtDat1.EditValue;
            //string strDate = dtDat1.Text;
            //if (string.IsNullOrEmpty(strDate))
            //{
            //    return;
            //}
            //if (CheckDate(sender))
            //{
            //    dtDat2.EditValue = dtDat1.EditValue;
            //}
        }

        private void dtDat2_Leave(object sender, EventArgs e)
        {
            string strDate = dtDat2.Text;
            if (!string.IsNullOrEmpty(strDate))
            {
                CheckDate(sender);
            }
        }

        private static bool CheckDate(object obj)
        {
            string strdate = ((DateEdit)obj).Text;
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                MessageBox.Show("輸入的日期有誤!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
            return Flag;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {  
            string strBrandId1 = txtBrand_id1.Text;
            string strBrandId2 = txtBrand_id2.Text;
            string strCust1 = lueCust1.EditValue.ToString();
            string strCust2 = lueCust2.EditValue.ToString();
            string strOrderDate1 = "";
            string strOrderDate2 = "";
            if (!string.IsNullOrEmpty(dtDat1.Text))
            {
                strOrderDate1 = DateTime.Parse(dtDat1.EditValue.ToString()).Date.ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(dtDat2.Text))
            {
                strOrderDate2 = DateTime.Parse(dtDat2.EditValue.ToString()).Date.ToString("yyyy-MM-dd");
            }

            
            if (strBrandId1 == "" && strBrandId2 == "" && strOrderDate1 == "" && strOrderDate2 == "" && strCust1=="" && strCust2=="")
            {
                MessageBox.Show("查詢條件不可全為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@order_date_s", strOrderDate1),
                new SqlParameter("@order_date_e", strOrderDate2),
                new SqlParameter("@brand_id_s",strBrandId1),
                new SqlParameter("@brand_id_e",strBrandId2),
                new SqlParameter("@it_customer_s",strCust1),
                new SqlParameter("@it_customer_e",strCust2)
            };
            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //************************
            dtDelivery = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_rpt_oc_data", paras);
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });


            if (dtDelivery.Rows.Count > 0)
            {                
                gridControl1.DataSource = dtDelivery;
            }
            else
            {                
                gridControl1.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gridView1.BestFitColumns();            
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
          //Print();
        }

        //private void Print()
        //{
        //    if (dtDelivery.Rows.Count ==0)
        //    {
        //        MessageBox.Show("請先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    xrDelivery_details_A4 oRepot = new xrDelivery_details_A4() { DataSource = dtDelivery };
        //    oRepot.CreateDocument();
        //    oRepot.PrintingSystem.ShowMarginsWarning = false;
        //    oRepot.ShowPreview();
        //}

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }
   
        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {           
            txtBrand_id2.Text = txtBrand_id1.Text;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("請首先查詢出需匯出之數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            SaveFileDialog saveFileDialog = new SaveFileDialog() { 
                Title = "Export To Excel", 
                Filter = "Excel files (*.xls)|*.xls" 
            };
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                gridControl1.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("匯出EXCEL成功！", "提示信息");
            }
        }

        private void lueCust1_Leave(object sender, EventArgs e)
        {
            lueCust2.EditValue = lueCust1.EditValue;
        }
    }
}
