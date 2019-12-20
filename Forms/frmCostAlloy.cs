using System;
using System.Collections.Generic;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Data;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmCostAlloy : cf01.ModuleForm.BaseFormMaster
    {
        private clsUtility.enumOperationType m_OperationType;
        private DataTable dtblDetail = new DataTable();
        private string m_ID = "";    //臨時的主鍵值 
        private int m_row_reset ;
        
        public frmCostAlloy()
        {
            InitializeComponent();
            clsControlInfoHelper cls = new clsControlInfoHelper("frmCostAlloy",this.Controls);
            cls.GenerateContorl();
        }

        private void frmCostAlloy_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtblDetail.Dispose();            
        }

        private void frmCostAlloy_Load(object sender, EventArgs e)
        {
            foreach (var ct in toolStrip1.Items)
            {
                if (ct.GetType() == typeof(ToolStripButton))
                {
                    ToolStripButton tsbtn = (ToolStripButton)ct;
                    if(tsbtn.Name == "BTNCANCEL" || tsbtn.Name == "BTNSAVE")
                    {
                        tsbtn.Enabled = false;
                    }                  
                }
            }
            DataTable dt = clsPublicOfCF01.GetDataTable(@"SELECT id,name FROM dgerp2.cferp.dbo.cd_department WHERE wh_dept='0' ORDER BY id");
            txtDept_id.Properties.DataSource = dt;
            txtDept_id.Properties.ValueMember = "id";
            txtDept_id.Properties.DisplayMember = "id";

            dtblDetail = clsPublicOfCF01.GetDataTable(@"SELECT * FROM dbo.pp_cost_mould WHERE 1=0");
            bds1.DataSource = dtblDetail;
            dgvDetails.DataSource = bds1;

            //數據綁定
            txtDept_id.DataBindings.Add("EditValue", bds1, "dept_id");
            cmbCompany.DataBindings.Add("EditValue", bds1, "company");
            txtId.DataBindings.Add("Text", bds1, "id");
            txtCost_pcs.DataBindings.Add("Text", bds1, "cost_pcs");
            txtCost_process.DataBindings.Add("Text", bds1, "cost_process");
            txtRemark.DataBindings.Add("Text", bds1, "remark");

            txtCreate_by.DataBindings.Add("Text", bds1, "create_by");
            txtCreate_date.DataBindings.Add("Text", bds1, "create_date");
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");

            txtCost.DataBindings.Add("Text", bds1, "cost");         
            txtCost_qty.DataBindings.Add("Text", bds1, "cost_qty");
            if (txtDept_id1.EditValue == "" && txtDept_id2.EditValue == "")
            {
                txtDept_id1.EditValue = "302";
                txtDept_id2.EditValue = "302";
            }
        }

        public override void New()
        {
            m_OperationType = clsUtility.enumOperationType.Add;
            toolStrip1.Tag = "1"; 
            bds1.AddNew();
            clsUtility.EnableToolStripButton(toolStrip1, m_OperationType); //設置按鈕的可用狀態            
            m_ID = "";
           
            SetObjValue.SetEditBackColor(pnlInput.Controls, true);
            SetObjValue.ClearObjValue(pnlInput.Controls, "1");

            cmbCompany.Properties.ReadOnly = false ;
            cmbCompany.Enabled = true;
            txtId.Properties.ReadOnly = false;

            cmbCompany.EditValue = "DG";
            txtCost_process.Text = "0.010";
            dgvDetails.Enabled = false;//新增時只能用上半部來輸入
            txtId.Focus();
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
            cmbCompany.Properties.ReadOnly = true;
            cmbCompany.BackColor = System.Drawing.Color.White; 
            txtId.Properties.ReadOnly = true;
            txtId.BackColor = System.Drawing.Color.White;
            txtDept_id.Properties.ReadOnly = true;
            txtDept_id.BackColor = System.Drawing.Color.White;    

            
            //表格可編輯,但主鍵除外
            dgvDetails.Enabled = true;
            dgvDetails.ReadOnly = false;
            dgvDetails.Columns["company"].ReadOnly = true;  
            dgvDetails.Columns["id"].ReadOnly = true;
            dgvDetails.Columns["dept_id"].ReadOnly = true;     

            m_ID = txtId.Text;                 
        }

        public override void Save()
        {
            txtRemark.Focus();
            if (ValidateInput())
            {                
                mdlCostAlloy mdlCost = new mdlCostAlloy()
                {
                    dept_id = txtDept_id.EditValue.ToString(),
                    company=cmbCompany.EditValue.ToString(),
                    id = txtId.Text.Trim() ,// int.Parse(txtId.Text),
                    cost_pcs = string.IsNullOrEmpty(txtCost_pcs.Text) ? 0.00f : float.Parse(txtCost_pcs.Text),
                    cost_process = string.IsNullOrEmpty(txtCost_process.Text) ? 0.00f : float.Parse(txtCost_process.Text),
                    cost = string.IsNullOrEmpty(txtCost.Text) ? 0.00f : float.Parse(txtCost.Text),
                    cost_qty =string.IsNullOrEmpty(txtCost_qty.Text)?0: int.Parse(txtCost_qty.Text),
                    remark = txtRemark.Text                    
                };
                bds1.EndEdit();//輸入立即生效
                bool isSave = clsCostAlloy.Save(toolStrip1.Tag.ToString(), mdlCost, dgvDetails, dtblDetail);
                if (isSave)
                {
                    m_OperationType = clsUtility.enumOperationType.Save;
                    clsUtility.EnableToolStripButton(toolStrip1, m_OperationType);
                }                
                SetObjValue.SetEditBackColor(pnlInput.Controls, false);
                txtId.Properties.ReadOnly = true;
                dgvDetails.Enabled = true;

                if (isSave)
                {
                    m_OperationType = clsUtility.enumOperationType.Save;
                    clsUtility.EnableToolStripButton(toolStrip1, m_OperationType);
                    MessageBox.Show("數據保存成功!", "提示信息");
                    dtblDetail.AcceptChanges();                    
                }
                else
                {
                    MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    if (clsCostAlloy.Delete(txtDept_id.EditValue.ToString(),cmbCompany.EditValue.ToString(),int.Parse(txtId.Text)))
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
            dtblDetail.RejectChanges();//取消所做的更改
            bds1.CancelEdit();
            bds1.DataSource = dtblDetail;
            SetObjValue.SetEditBackColor(pnlInput.Controls, false);
            toolStrip1.Tag = "";
            m_OperationType = clsUtility.enumOperationType.Cancel;
            cmbCompany.Properties.ReadOnly = false; 
            txtId.Properties.ReadOnly = true;
            txtDept_id.Properties.ReadOnly = false; 
            clsUtility.EnableToolStripButton(toolStrip1, m_OperationType);
            dgvDetails.Enabled = true;

            if (!String.IsNullOrEmpty(m_ID) && dgvDetails.RowCount > 0)
            {
                //Find_doc(mID);
                dgvDetails.CurrentCell = dgvDetails.Rows[m_row_reset].Cells[1]; //设置当前单元格
                dgvDetails.Rows[m_row_reset].Selected = true; //選中整行
            }
            else
            {
                SetObjValue.ClearObjValue(pnlInput.Controls, "1");
            }
            //Find_Data();
        }

        public bool ValidateInput()
        {
            if (txtDept_id.EditValue.ToString() == "")
            {
                MessageBox.Show("請輸入部門資料!", "提示信息");
                txtDept_id.Focus();
                return false;
            }
            if (cmbCompany.Text == "")
            {
                MessageBox.Show("請輸入生產廠區!", "提示信息");
                cmbCompany.Focus();
                return false;
            }
            if (txtId.Text == "")
            {
                MessageBox.Show("請輸入類型（排位數）!","提示信息");
                txtId.Focus();
                return false;                 
            }

            float fltCost = 0.000f;
            if (!string.IsNullOrEmpty(txtCost_pcs.Text))
            {
                fltCost = float.Parse(txtCost_pcs.Text);
                if (fltCost <= 0)
                {
                    MessageBox.Show("注意：每粒單價必須是大于0！", "提示信息");
                    txtCost_pcs.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("注意：每粒單價必須是大于0！", "提示信息");
                txtCost_pcs.Focus();
                return false;
            }

            //if (!string.IsNullOrEmpty(txtCost_process.Text))
            //{
            //    fltCost = float.Parse(txtCost_process.Text);
            //    if (fltCost <= 0)
            //    {
            //        MessageBox.Show("注意：后工序必須是大于0！", "提示信息");
            //        txtCost_process.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("注意：后工序必須是大于0！", "提示信息");
            //    txtCost_process.Focus();
            //    return false;
            //}

            if (m_OperationType == clsUtility.enumOperationType.Add)
            {
                if (clsCostAlloy.Check_Is_Exists(txtDept_id.EditValue.ToString(), cmbCompany.EditValue.ToString(), txtId.Text))
                {
                    MessageBox.Show(string.Format("注意：部門，生產位置，類型（排位數）已經存重復【{0}】【{1}】【{2}】的資料！", txtDept_id.EditValue, cmbCompany.EditValue, txtId.Text), "提示信息");
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
            if (txtDept_id1.Text == "")
            {
                MessageBox.Show("部門必須輸入！","提示信息");
                return;
            }
            string strSql,strDept_id1, strCompany;           
            strDept_id1 = txtDept_id1.EditValue.ToString();
            strCompany = cmbCompany1.Text ;

            strSql = string.Format(@"Select * From dbo.pp_cost_mould Where dept_id>='{0}'", txtDept_id1.EditValue); 
            if (txtDept_id2.Text != "" )
            {
                strSql += string.Format(@" and dept_id<='{0}'",txtDept_id2.EditValue);
            }
            if (!string.IsNullOrEmpty(strCompany))
            {
                strSql += string.Format(@" and company='{0}'", strCompany);
            }
            if (txtId1.Text != "")
            {
                strSql += string.Format(@" and id>='{0}'", txtId1.Text);
            }
            if (txtId2.Text != "")
            {
                strSql += string.Format(@" and id<='{0}'", txtId2.Text);
            }                   
            strSql += " Order By dept_id,company,id";

            dtblDetail = clsPublicOfCF01.GetDataTable(strSql);
            bds1.DataSource = dtblDetail;
            dgvDetails.DataSource = bds1;
           
            if (dtblDetail.Rows.Count == 0 )
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息");
            }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }
        
        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                m_row_reset = dgvDetails.CurrentCell.RowIndex;
                m_ID = txtId.Text;//保存臨時的ID號                
                //m_dgvrow = dgvDetails.CurrentRow;// object m_dgvrow is used to newcopy
                //Set_head(dgvrow);
            }
            else
            {
                m_ID = "";               
            }
        }

        public override void Print()
        {
            PrintDGV.Print_DataGridView(dgvDetails,"合金部排位資料設置");//OC匯總表
        }

        private void Set_Cost_Per_Pcs()
        {
            if (m_OperationType == clsUtility.enumOperationType.Add || m_OperationType == clsUtility.enumOperationType.Update)
            {
                float fltCost, fltCost_qty;
                fltCost = string.IsNullOrEmpty(txtCost.Text) ? 0.00f : float.Parse(txtCost.Text);
                fltCost_qty = string.IsNullOrEmpty(txtCost_qty.Text) ? 0 : float.Parse(txtCost_qty.Text);
                if (fltCost == 0 && fltCost_qty == 0)
                {
                    return;
                }

                if (fltCost_qty == 0)
                {
                    txtCost_pcs.Text = "";
                }
                else
                {
                    txtCost_pcs.Text = Math.Round(fltCost / fltCost_qty, 3).ToString();
                }
            }
        }

        private void txtCost_Leave(object sender, EventArgs e)
        { 
            Set_Cost_Per_Pcs();
        }

        private void txtCost_qty_Leave(object sender, EventArgs e)
        {
            Set_Cost_Per_Pcs();
        }

        private static void Set_Number_Focus(DevExpress.XtraEditors.TextEdit objTextEdit)
        {
            if (objTextEdit.Text == "0.000")
            {
                objTextEdit.Select(1, 0);
            }
        }

        private void txtCost_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtCost);  
        }

        private void txtCost_pcs_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtCost_pcs);
        }

        private void txtDept_id1_Leave(object sender, EventArgs e)
        {
            txtDept_id2.Text = txtDept_id1.Text;
        }
    }
}
