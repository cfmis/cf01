using System;
using System.Collections.Generic;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Data;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmQuotationMoq : cf01.ModuleForm.BaseFormMaster
    {
        private clsUtility.enumOperationType m_OperationType;
        private DataTable dtblDetail;
        private string m_ID = "";    //臨時的主鍵值
        private string m_unit = "";
        private int m_row_reset ;
        
        public frmQuotationMoq()
        {
            InitializeComponent();
            clsControlInfoHelper cls = new clsControlInfoHelper("frmQuotationMoq",this.Controls);
            cls.GenerateContorl();
        }

        private void frmQuotationMoq_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtblDetail.Dispose();            
        }

        private void frmQuotationMoq_Load(object sender, EventArgs e)
        {
            clsQuotation.Set_Brand_id(lueBrand_id);
            clsQuotation.Set_Unit(lueMoq_unit);
           
            dtblDetail = clsPublicOfCF01.GetDataTable(@"SELECT * FROM dbo.quotation_moq WHERE 1=0");
            bds1.DataSource = dtblDetail;
            dgvDetails.DataSource = bds1;

            //數據綁定
            lueBrand_id.DataBindings.Add("EditValue", bds1, "brand_id");
            lueMoq_unit.DataBindings.Add("EditValue", bds1, "moq_unit");
            txtMoq.DataBindings.Add("Text", bds1, "moq");
            
            txtRemark.DataBindings.Add("Text", bds1, "remark");
            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");            
        }

        public override void New()
        {
            m_OperationType = clsUtility.enumOperationType.Add;
            toolStrip1.Tag = "1";
            string strBrand = m_ID;
            bds1.AddNew();            
            clsUtility.EnableToolStripButton(toolStrip1, m_OperationType); //設置按鈕的可用狀態            
            m_ID = "";
            m_unit = "";         
           
            SetObjValue.SetEditBackColor(pnlInput.Controls, true);
            SetObjValue.ClearObjValue(pnlInput.Controls, "1");
            if (strBrand != "")
            {
                lueBrand_id.EditValue = strBrand;//新增時復制上一條記錄的牌子
            }
            dgvDetails.Enabled = false;//新增時只能用上半部來輸入
            lueBrand_id.Focus();
        }

        public override void Edit()
        {            
            if (dgvDetails.RowCount == 0)
            {
                return;
            }      
            m_OperationType = clsUtility.enumOperationType.Update;
            toolStrip1.Tag = "2";           
            clsUtility.EnableToolStripButton(toolStrip1, m_OperationType);
            SetObjValue.SetEditBackColor(pnlInput.Controls, true);

            //編輯時上半部及表格都可以錄入,但主鍵除外
            lueBrand_id.Properties.ReadOnly = true;
            lueBrand_id.BackColor = System.Drawing.Color.White;
            lueMoq_unit.Properties.ReadOnly = true;
            lueMoq_unit.BackColor = System.Drawing.Color.White;
            
            //表格可編號,但主鍵除外
            dgvDetails.Enabled = true;
            dgvDetails.ReadOnly = false;
            dgvDetails.Columns["brand_id"].ReadOnly = true;
            dgvDetails.Columns["moq_unit"].ReadOnly = true;

            m_ID = lueBrand_id.EditValue.ToString();
            m_unit = lueMoq_unit.EditValue.ToString();           
        }

        public override void Save()
        {
            txtRemark.Focus();
            if (ValidateInput())
            {
                mdlQuotationMoq mdlMoq = new mdlQuotationMoq() { 
                    brand_id = lueBrand_id.EditValue.ToString(), 
                    moq_unit = lueMoq_unit.EditValue.ToString(), 
                    moq = string.IsNullOrEmpty(txtMoq.Text) ? 0 : int.Parse(txtMoq.Text), 
                    remark = txtRemark.Text 
                };
                bds1.EndEdit();//輸入立即生效
                bool isSave = clsQuotationMoq.Save(toolStrip1.Tag.ToString(), mdlMoq, dgvDetails, dtblDetail);
                if (isSave)
                {
                    m_OperationType = clsUtility.enumOperationType.Save;
                    clsUtility.EnableToolStripButton(toolStrip1, m_OperationType);
                }                
                SetObjValue.SetEditBackColor(pnlInput.Controls, false);
                dgvDetails.Enabled = true;

                if (isSave)
                {
                    m_OperationType = clsUtility.enumOperationType.Save;
                    clsUtility.EnableToolStripButton(toolStrip1, m_OperationType);
                    MessageBox.Show("保存成功!", "提示信息");
                    dtblDetail.AcceptChanges();                    
                }
                else
                {
                    MessageBox.Show("保存失敗!","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        public override void Remove()
        {
            //刪除            
            if (dgvDetails.Rows.Count > 0)
            {
                if (MessageBox.Show("確認刪除該條數據？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsQuotationMoq.Delete(lueBrand_id.EditValue.ToString(), lueMoq_unit.EditValue.ToString()))
                    {                       
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show("刪除當前記錄成功！", "提示信息");
                    }
                    else
                    {
                        MessageBox.Show("刪除當前記錄失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    }
                }
            }           
        }

        public override void Cancel()
        {
            bds1.CancelEdit();
            SetObjValue.SetEditBackColor(pnlInput.Controls, false);
            toolStrip1.Tag = "";
            m_OperationType = clsUtility.enumOperationType.Cancel;           
            lueBrand_id.Properties.ReadOnly = false;
            lueMoq_unit.Properties.ReadOnly = false;
            clsUtility.EnableToolStripButton(toolStrip1, m_OperationType); 
            dgvDetails.Enabled = true;            
            
            if (!String.IsNullOrEmpty(m_ID) && !String.IsNullOrEmpty(m_unit) && dgvDetails.RowCount > 0)
            {
                //Find_doc(mID);
                dgvDetails.CurrentCell = dgvDetails.Rows[m_row_reset].Cells[1]; //设置当前单元格
                dgvDetails.Rows[m_row_reset].Selected = true; //選中整行
            }
            else
                SetObjValue.ClearObjValue(pnlInput.Controls, "1");
            //Find_Data();
        }

        public bool ValidateInput()
        {            
            if (lueBrand_id.Text == "")
            {
                MessageBox.Show("請輸入牌子編號!","提示信息");
                lueBrand_id.Focus();
                return false;                 
            }
            if (lueMoq_unit.Text == "")
            {
                MessageBox.Show("單位資料不可為空!", "提示信息");
                lueMoq_unit.Focus();
                return false;                
            }
            if (txtMoq.Text == "")
            {
                MessageBox.Show("請輸入MOQ數量!","提示信息");
                txtMoq.Focus();
                return false;               
            }
            if (!string.IsNullOrEmpty(txtMoq.Text))
            {
                int intMoq = int.Parse(txtMoq.Text);
                if (intMoq <= 0)
                {
                    MessageBox.Show("注意：Moq數量必須是大于0！", "提示信息");
                    txtMoq.Focus();
                    return false;                    
                }
            }
            if (m_OperationType == clsUtility.enumOperationType.Add)
            {
                if (clsQuotationMoq.Check_Is_Exists(lueBrand_id.EditValue.ToString(), lueMoq_unit.EditValue.ToString()))
                {
                    MessageBox.Show(string.Format("注意：已經存在牌子編號【{0}】和MOQ單位【{1}】的資料！不可以再重復輸入！", lueBrand_id.EditValue, lueMoq_unit.EditValue), "提示信息");
                    return false;
                }
            }
            return true;           
        }     

        public override void Find()
        {
            //base.Find();
            Find_Data();
        }

        private void Find_Data()
        {           
            string strSql, strBrandBegin, strBrandEnd;
            strBrandBegin = txtBrandBegin.Text;
            strBrandEnd = txtBrandEnd.Text;
            if (strBrandBegin != "" && strBrandEnd != "")
            {
                strSql = @"Select * From quotation_moq Where brand_id>'' ";
                if (strBrandBegin != "")
                {
                    strSql += string.Format(" And brand_id>='{0}'", txtBrandBegin.Text);
                }
                if (strBrandEnd != "")
                {
                    strSql += string.Format(" And brand_id<='{0}'", txtBrandEnd.Text);
                }
            }
            else
            {
                strSql = @"Select * From quotation_moq ";
            }
            strSql += " Order By brand_id,moq_unit";
            dtblDetail = clsPublicOfCF01.GetDataTable(strSql);
            bds1.DataSource = dtblDetail;
            dgvDetails.DataSource = bds1;
           
            if (dtblDetail.Rows.Count == 0 )
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息");
            }
        }

        private void txtBrandBegin_Leave(object sender, EventArgs e)
        {
            txtBrandEnd.Text = txtBrandBegin.Text;
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                m_row_reset = dgvDetails.CurrentCell.RowIndex;
                m_ID = lueBrand_id.EditValue.ToString();//保存臨時的ID號
                m_unit = lueMoq_unit.EditValue.ToString();
                //m_dgvrow = dgvDetails.CurrentRow;// object m_dgvrow is used to newcopy
                //Set_head(dgvrow);
            }
            else
            {
                m_ID = "";
                m_unit = "";
            }
        }

        public override void Print()
        {
            PrintDGV.Print_DataGridView(dgvDetails,"MOQ 設置報表");//OC匯總表
        }

        private void txtBrandBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }        

    }
}
