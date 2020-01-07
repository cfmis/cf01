using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using cf01.CLS;
using cf01.Reports;

namespace cf01.ReportForm
{
    public partial class frmDeliveryCost : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtDelivery = new DataTable();
        DataTable dtDept = new DataTable();
        public string strUserid = DBUtility._user_id;

        public frmDeliveryCost()
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
                clsApp.SetToolBarEnable(this.Name, this.Controls);
                clsApp.Initialize_find_value(this.Name, panel1.Controls);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void frmDeliveryCost_Load(object sender, EventArgs e)
        {

            dtDept = clsBaseData.Get_Department();
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            txtOut_detp1.Properties.DataSource = dtDept;
            txtOut_detp1.Properties.ValueMember = "id";
            txtOut_detp1.Properties.DisplayMember = "cdesc";

            txtOut_detp2.Properties.DataSource = dtDept;
            txtOut_detp2.Properties.ValueMember = "id";
            txtOut_detp2.Properties.DisplayMember = "cdesc";

            txtIn_detp1.Properties.DataSource = dtDept;
            txtIn_detp1.Properties.ValueMember = "id";
            txtIn_detp1.Properties.DisplayMember = "cdesc";

            txtIn_detp2.Properties.DataSource = dtDept;
            txtIn_detp2.Properties.ValueMember = "id";
            txtIn_detp2.Properties.DisplayMember = "cdesc";
            

            //if (string.IsNullOrEmpty(dtDat1.Text))
            //    dtDat1.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            //if (string.IsNullOrEmpty(dtDat2.Text))
            //    dtDat2.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd");
            
        }

        private void frmDeliveryCost_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtDelivery.Dispose();
            dtDept.Dispose();            
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            string strDate = dtDat1.Text;
            if (string.IsNullOrEmpty(strDate))
            {
                return;
            }
            if (CheckDate(sender))
            {
                dtDat2.EditValue = dtDat1.EditValue;
            }
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
            string strID1 = txtID1.Text;
            string strID2 = txtID2.Text;            
           
            string out_dept1= "";
            if (string.IsNullOrEmpty(txtOut_detp1.EditValue.ToString()))
            {                
                out_dept1 = "";
            }
            else
            {
                out_dept1 = txtOut_detp1.EditValue.ToString();
            }
            string out_dept2 = "";
            if (string.IsNullOrEmpty(txtOut_detp2.EditValue.ToString()))
            {
                out_dept2 = "";
            }
            else
            {
                out_dept2 = txtOut_detp2.EditValue.ToString();
            }
            string in_dept1 = "";
            if (string.IsNullOrEmpty(txtIn_detp1.EditValue.ToString()))
            {
                in_dept1 = "";
            }
            else
            {
                in_dept1 = txtIn_detp1.EditValue.ToString();
            }
            string in_dept2 = "";
            if (string.IsNullOrEmpty(txtIn_detp2.EditValue.ToString()))
            {
                in_dept2 = "";
            }
            else
            {
                in_dept2 = txtIn_detp2.EditValue.ToString();
            }
            if (strID1 == "" && strID2 == "" && dtDat1.Text == "" && dtDat2.Text == ""
                && out_dept1 == "" && out_dept2 == "" && in_dept1 == "" && in_dept2 == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
            {
                    new SqlParameter("@id_s",strID1),
                    new SqlParameter("@id_e",strID2),
                    new SqlParameter("@date_s", dtDat1.Text),
                    new SqlParameter("@date_e", dtDat2.Text),
                    new SqlParameter("@out_dept_s", out_dept1),                    
                    new SqlParameter("@out_dept_e", out_dept2),
                    new SqlParameter("@in_dept_s", in_dept1),
                    new SqlParameter("@in_dept_e", in_dept2)                    
            };
            dtDelivery = clsPublicOfCF01.ExecuteProcedureReturnTable("z_rpt_delivery_cost", paras);

            if (dtDelivery.Rows.Count > 0)
            {                
                gridControl1.DataSource = dtDelivery;
            }
            else
            {                
                gridControl1.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.gridView1.BestFitColumns();            
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

        private void txtOut_detp1_Click(object sender, EventArgs e)
        {
            txtOut_detp1.SelectAll();
        }

        private void txtOut_detp2_Click(object sender, EventArgs e)
        {
            txtOut_detp2.SelectAll();
        }

        private void txtIn_detp1_Click(object sender, EventArgs e)
        {
            txtIn_detp1.SelectAll();
        }

        private void txtIn_detp2_Click(object sender, EventArgs e)
        {
            txtIn_detp2.SelectAll();
        }

        private void txtOut_detp1_Leave(object sender, EventArgs e)
        {          
            txtOut_detp2.EditValue = txtOut_detp1.EditValue;
        }

        private void txtIn_detp1_Leave(object sender, EventArgs e)
        {            
            txtIn_detp2.EditValue = txtIn_detp1.EditValue;
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {           
            txtID2.Text = txtID1.Text;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog() { 
                Title = "Export To Excel", 
                Filter = "Excel files (*.xls)|*.xls" 
            };
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                gridControl1.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully saved.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
