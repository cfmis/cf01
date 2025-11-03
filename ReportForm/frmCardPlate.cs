using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using cf01.CLS;
using cf01.Reports;
using cf01.Forms;
using System.Threading;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmCardPlate : Form
    {
        DataTable dtWordCard = new DataTable();
        DataTable dtDept = new DataTable();
        DataTable dtVendor = new DataTable();
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public string strUserid = DBUtility._user_id;

        public frmCardPlate()
        {
            InitializeComponent();
            try
            {               
                clsApp.Initialize_find_value(this.Name, this.Controls);
                chkSelect.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void frmCardPlate_Load(object sender, EventArgs e)
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
             
            dtVendor = clsBaseData.Get_Plate_Vendor();
            DataRow dr1 = dtVendor.NewRow(); //插一空行        
            dtVendor.Rows.InsertAt(dr1, 0);

            txtVendor1.Properties.DataSource = dtVendor;
            txtVendor1.Properties.ValueMember = "id";
            txtVendor1.Properties.DisplayMember = "cdesc";

            txtVendor2.Properties.DataSource = dtVendor;
            txtVendor2.Properties.ValueMember = "id";
            txtVendor2.Properties.DisplayMember = "cdesc";

            if (string.IsNullOrEmpty(txtDat1.Text))
                txtDat1.EditValue = DateTime.Now;
            if (string.IsNullOrEmpty(txtDat2.Text))
                txtDat2.EditValue = DateTime.Now;
        }

        private void frmCardPlate_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtWordCard.Dispose();
            dtDept.Dispose();
            dtVendor.Dispose();
            clsConErp = null;
            clsApp = null;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat1.Text;
            if (string.IsNullOrEmpty(strDate))
            {
                return;
            }
            if (CheckDate(sender))
            {
                txtDat2.EditValue = txtDat1.EditValue;
            }
        }

        private void txtDat2_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat2.Text;
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
            gridView1.CloseEditor();
            txtID2.Focus();
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
            string vendor1 = "";
            if (string.IsNullOrEmpty(txtVendor1.EditValue.ToString()))
            {
                vendor1 = "";
            }
            else
            {
                vendor1 = txtVendor1.EditValue.ToString();
            }
            string vendor2 = "";
            if (string.IsNullOrEmpty(txtVendor2.EditValue.ToString()))
            {
                vendor2 = "";
            }
            else
            {
                vendor2 = txtVendor2.EditValue.ToString();
            }

            if (strID1 == "" && strID2 == "" && txtDat1.Text == "" && txtDat2.Text == ""
                && out_dept1 == "" && out_dept2 == "" && vendor1 == "" && vendor2 == "" && txtMo_id1.Text =="" && txtMo_id2.Text =="")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string is_sample;
            if (chkSample.Checked)
                is_sample = "1";
            else
                is_sample = "";

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();              

            SqlParameter[] paras = new SqlParameter[]{                   
                    new SqlParameter("@id_s",strID1),
                    new SqlParameter("@id_e",strID2),
                    new SqlParameter("@dept_id_s", out_dept1),                    
                    new SqlParameter("@dept_id_e", out_dept2),
                    new SqlParameter("@date_s", txtDat1.Text),
                    new SqlParameter("@date_e", txtDat2.Text),                    
                    new SqlParameter("@vendor_s", vendor1),
                    new SqlParameter("@vendor_e", vendor2),
                    new SqlParameter("@mo_id_s", txtMo_id1.Text),
                    new SqlParameter("@mo_id_e", txtMo_id2.Text),
                    new SqlParameter("@is_sample", is_sample) //"z_rpt_card_510"因跟版無區分電鍍或噴油暫時不改
            };
            dtWordCard = clsConErp.ExecuteProcedureReturnTable("z_rpt_card_510", paras);            
            //客戶端加bool字段或後端返回(bit型)都可以
            dtWordCard.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));
            
            //關掉進程
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dtWordCard.Rows.Count > 0)
            {                
                gridControl1.DataSource = dtWordCard;
            }
            else
            {                
                gridControl1.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
          Print();
        }

        private void Print()
        {
            txtID2.Focus();
            if (dtWordCard.Rows.Count ==0)
            {
                MessageBox.Show("請先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
           
            gridView1.CloseEditor();
            DataTable dtReport = new DataTable();
            dtReport = dtWordCard.Clone();
            int base_rate = 0;
            int ii;            
            for (int i = 0; i < dtWordCard.Rows.Count; i++)
            {
                if (dtWordCard.Rows[i]["flag_select"].ToString() == "True")
                {
                    if (dtWordCard.Rows[i]["wp_id"].ToString() != "510" && dtWordCard.Rows[i]["next_wp_id"].ToString() == "702")
                    {
                        continue;  //非噴油部的交測試工序卡不用列印出來
                    }                    
                    DataRow newRow = dtReport.NewRow();
                    newRow["id"] = dtWordCard.Rows[i]["id"].ToString();
                    newRow["ir_date"] = dtWordCard.Rows[i]["ir_date"].ToString();
                    newRow["vendor_id"] = dtWordCard.Rows[i]["vendor_id"].ToString();
                    newRow["wp_id"] = dtWordCard.Rows[i]["wp_id"].ToString();
                    newRow["mo_id"] = dtWordCard.Rows[i]["mo_id"].ToString();
                    newRow["goods_id"] = dtWordCard.Rows[i]["goods_id"].ToString();
                    newRow["goods_name"] = dtWordCard.Rows[i]["goods_name"].ToString();
                    newRow["product_qty"] = dtWordCard.Rows[i]["product_qty"];
                    newRow["sec_qty"] = dtWordCard.Rows[i]["sec_qty"];
                    newRow["name_color_sample"] = dtWordCard.Rows[i]["name_color_sample"].ToString();
                    newRow["brand_id"] = dtWordCard.Rows[i]["brand_id"].ToString();
                    //newRow["rmk"] = dtWordCard.Rows[i]["rmk"].ToString();
                    newRow["plate_remark"] = dtWordCard.Rows[i]["plate_remark"].ToString();
                    newRow["production_remark"] = dtWordCard.Rows[i]["production_remark"].ToString();
                    newRow["remark"] = dtWordCard.Rows[i]["remark"].ToString();
                    newRow["name_color"] = dtWordCard.Rows[i]["name_color"].ToString();
                    newRow["do_color"] = dtWordCard.Rows[i]["do_color"].ToString();
                    //newRow["rate"] = dtWordCard.Rows[i]["rate"];
                    newRow["mo_barcode"] = dtWordCard.Rows[i]["mo_barcode"].ToString();
                    newRow["next_wp_id"] = dtWordCard.Rows[i]["next_wp_id"].ToString();
                    newRow["name_next_dept"] = dtWordCard.Rows[i]["name_next_dept"].ToString();
                    newRow["plan_qty"] = dtWordCard.Rows[i]["plan_qty"];
                    newRow["order_qty"] = dtWordCard.Rows[i]["order_qty"];
                    newRow["t_complete_date"] = dtWordCard.Rows[i]["t_complete_date"].ToString();
                    newRow["qty_total"] = dtWordCard.Rows[i]["qty_total"];
                    newRow["sec_qty_total"] = dtWordCard.Rows[i]["sec_qty_total"];
                    newRow["prints"] = dtWordCard.Rows[i]["prints"];
                    newRow["picture_name"] = dtWordCard.Rows[i]["picture_name"].ToString();
                    newRow["goods_position"] = dtWordCard.Rows[i]["goods_position"].ToString();
                    newRow["id_barcode"] = dtWordCard.Rows[i]["id_barcode"].ToString();
                    newRow["is_sample"] = dtWordCard.Rows[i]["is_sample"].ToString();
                    newRow["basic_unit"] = dtWordCard.Rows[i]["basic_unit"].ToString();
                    newRow["base_rate"] = dtWordCard.Rows[i]["base_rate"];
                    base_rate = string.IsNullOrEmpty(dtWordCard.Rows[i]["base_rate"].ToString()) ? 0 : clsUtility.FormatNullableInt32(dtWordCard.Rows[i]["base_rate"].ToString());
                    newRow["stantard_qty"] = Math.Round(clsUtility.FormatNullableFloat(dtWordCard.Rows[i]["sec_qty"].ToString()) * base_rate, 0);
                    newRow["qc_test"] = dtWordCard.Rows[i]["qc_test"];
                    newRow["lot_no"] = dtWordCard.Rows[i]["lot_no"];
                    newRow["dept_remark"] = dtWordCard.Rows[i]["dept_remark"];

                    //處理有幾包就列印幾張 2016-01-15
                    if (dtWordCard.Rows[i]["prints"].ToString() !="1")
                    {                       
                        ii = Convert.ToInt32(dtWordCard.Rows[i]["prints"].ToString());//要列印的總張數
                        for (int j = 0; j < ii; j++)
                        {
                            DataRow dr = dtReport.NewRow();                            
                            dr["id"] = dtWordCard.Rows[i]["id"].ToString();
                            dr["ir_date"] = dtWordCard.Rows[i]["ir_date"].ToString();
                            dr["vendor_id"] = dtWordCard.Rows[i]["vendor_id"].ToString();
                            dr["wp_id"] = dtWordCard.Rows[i]["wp_id"].ToString();
                            dr["mo_id"] = dtWordCard.Rows[i]["mo_id"].ToString();
                            dr["goods_id"] = dtWordCard.Rows[i]["goods_id"].ToString();
                            dr["goods_name"] = dtWordCard.Rows[i]["goods_name"].ToString();
                            dr["product_qty"] = dtWordCard.Rows[i]["product_qty"];
                            dr["sec_qty"] = dtWordCard.Rows[i]["sec_qty"];
                            dr["name_color_sample"] = dtWordCard.Rows[i]["name_color_sample"].ToString();
                            dr["brand_id"] = dtWordCard.Rows[i]["brand_id"].ToString();
                            //dr["rmk"] = dtWordCard.Rows[i]["rmk"].ToString();
                            dr["plate_remark"] = dtWordCard.Rows[i]["plate_remark"].ToString();
                            dr["production_remark"] = dtWordCard.Rows[i]["production_remark"].ToString();
                            dr["remark"] = dtWordCard.Rows[i]["remark"].ToString();
                            dr["name_color"] = dtWordCard.Rows[i]["name_color"].ToString();
                            dr["do_color"] = dtWordCard.Rows[i]["do_color"].ToString();
                            //dr["rate"] = dtWordCard.Rows[i]["rate"];
                            dr["mo_barcode"] = dtWordCard.Rows[i]["mo_barcode"].ToString();
                            dr["next_wp_id"] = dtWordCard.Rows[i]["next_wp_id"].ToString();
                            dr["name_next_dept"] = dtWordCard.Rows[i]["name_next_dept"].ToString();
                            dr["plan_qty"] = dtWordCard.Rows[i]["plan_qty"];
                            dr["order_qty"] = dtWordCard.Rows[i]["order_qty"];
                            dr["t_complete_date"] = dtWordCard.Rows[i]["t_complete_date"].ToString();
                            dr["qty_total"] = dtWordCard.Rows[i]["qty_total"];
                            dr["sec_qty_total"] = dtWordCard.Rows[i]["sec_qty_total"];
                            dr["prints"] = j+1; //處理本卡為第幾張
                            dr["picture_name"] = dtWordCard.Rows[i]["picture_name"].ToString();
                            dr["goods_position"] = dtWordCard.Rows[i]["goods_position"].ToString();
                            dr["id_barcode"] = dtWordCard.Rows[i]["id_barcode"].ToString();
                            dr["is_sample"] = dtWordCard.Rows[i]["is_sample"].ToString();
                            dr["basic_unit"] = dtWordCard.Rows[i]["basic_unit"].ToString();
                            dr["base_rate"] = dtWordCard.Rows[i]["base_rate"];
                            base_rate = string.IsNullOrEmpty(dtWordCard.Rows[i]["base_rate"].ToString()) ? 0 : clsUtility.FormatNullableInt32(dtWordCard.Rows[i]["base_rate"].ToString());
                            dr["stantard_qty"] = Math.Round(clsUtility.FormatNullableFloat(dtWordCard.Rows[i]["sec_qty"].ToString()) * base_rate, 0);
                            dr["qc_test"] = dtWordCard.Rows[i]["qc_test"].ToString();
                            dr["lot_no"] = dtWordCard.Rows[i]["lot_no"].ToString();
                            dr["dept_remark"] = dtWordCard.Rows[i]["dept_remark"].ToString();
                            dtReport.Rows.Add(dr);
                        }
                    }
                    else
                         dtReport.Rows.Add(newRow);
                }
            }
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先選擇要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            //處理跟單自己加流程訂單數是0的問題2017-07-06
            string strSql,mo_id,f0_id="",goods_id="";            
            int prod_qty, dosage;
            DataTable dtPlan = new DataTable();
            DataTable dtSales = new DataTable();

            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                if ((dtReport.Rows[i]["order_qty"].ToString() == "0" || dtReport.Rows[i]["order_qty"].ToString() == "1") && dtReport.Rows[i]["next_wp_id"].ToString() == "601")
                {                    
                    mo_id = dtReport.Rows[i]["mo_id"].ToString();
                    goods_id = dtReport.Rows[i]["goods_id"].ToString();
                   
                    //查找F0對應的生產數即訂單數
                    strSql = string.Format(
                     @"SELECT B.goods_id,CONVERT(int,B.prod_qty) as prod_qty From jo_bill_mostly A with(nolock),jo_bill_goods_details B with(nolock)
                     WHERE A.within_code=B.within_code and A.id=B.id and A.ver=B.ver AND A.mo_id='{0}' AND B.goods_id LIKE 'F0-%'",mo_id);
                    dtPlan = clsConErp.GetDataTable(strSql);
                    if (dtPlan.Rows.Count > 0)
                    {
                        f0_id = dtPlan.Rows[0]["goods_id"].ToString();
                        prod_qty = int.Parse(dtPlan.Rows[0]["prod_qty"].ToString());
                    }
                    else
                    {
                        f0_id = "";
                        prod_qty = 0;
                    }
                    //查找SALES BOM對應貨品的用量
                    strSql = string.Format(@"SELECT CONVERT(int,B.dosage) as dosage From it_bom_mostly A with(nolock),it_bom B with(nolock)
                    WHERE A.within_code=B.within_code and A.id=B.id and A.exp_id=B.exp_id AND A.goods_id='{0}' AND B.goods_id ='{1}'", f0_id, goods_id);
                    dtSales = clsConErp.GetDataTable(strSql);
                    if (dtSales.Rows.Count > 0)                 
                        dosage = int.Parse(dtSales.Rows[0]["dosage"].ToString());                    
                    else                    
                        dosage = 0;
                    //總訂單數量=生產數量x用量
                    dtReport.Rows[i]["order_qty"] = prod_qty * dosage;
                }
            }

            //-----------
           
            //加載報表                
            xtaWorkPlate oRepot = new xtaWorkPlate() { DataSource = dtReport };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false ;                
            oRepot.ShowPreviewDialog();
           
        }

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

        private void txtVendor1_Click(object sender, EventArgs e)
        {
            txtVendor1.SelectAll();
        }

        private void txtVendor2_Click(object sender, EventArgs e)
        {
            txtVendor2.SelectAll();
        }

        private void txtOut_detp1_Leave(object sender, EventArgs e)
        {          
            txtOut_detp2.EditValue = txtOut_detp1.EditValue;
        }

        private void txtIn_detp1_Leave(object sender, EventArgs e)
        {            
            txtVendor2.EditValue = txtVendor1.EditValue;
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {           
            txtID2.Text = txtID1.Text;
        }

     
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            
            //string seq_id_flag = gridView1.GetRowCellDisplayText(e.RowHandle, "seq_id_flag");
            //if (string.IsNullOrEmpty(seq_id_flag))
            //{
            //    seq_id_flag = "";
            //}
            string next_dept_id = gridView1.GetRowCellDisplayText(e.RowHandle, "next_wp_id");
            if (next_dept_id == "702")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.AntiqueWhite;//.LemonChiffon;
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (dtWordCard.Rows.Count > 0)
            {
                Boolean blSetValue = true;
                if (chkSelect.Checked)
                {
                    blSetValue = true;//Select All                    
                }
                else
                {
                    blSetValue = false;                    
                }                
                for (int i = 0; i < dtWordCard.Rows.Count; i++)
                {
                    gridView1.SetRowCellValue(i, "flag_select", blSetValue);
                }
                
            }
        }
            

        private void clFlag_select_CheckedChanged(object sender, EventArgs e)
        {           
            if (chkDelivery.Checked)
            {
                gridView1.CloseEditor();//將當前行所有更改立即定入綁定的數據源,折騰一天時間呀
                string strID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                string value_select = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString();
                bool flag;
                if (value_select == "True")
                {                   
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                for (int i = 0; i < dtWordCard.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, "id") == strID)
                    {
                        gridView1.SetRowCellValue(i, "flag_select", flag);
                    }
                }
                gridView1.CloseEditor();
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }   
     
    }
}
