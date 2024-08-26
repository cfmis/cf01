using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmMMQuotation : Form
    {
        private string edit_flag = "0";
        private string userid = DBUtility._user_id;
        private bool append_mode=false;
        private bool edit_mode = false;
        private string remote_db = DBUtility.remote_db;
        public frmMMQuotation()
        {
            InitializeComponent();
        }

        private void initControls()
        {

            string strSql = " Select id,name From " + remote_db + "cd_units Where kind='05' " + " Order By id";
            DataTable dtUnit = clsPublicOfCF01.GetDataTable(strSql);
            lueUnit.Properties.DataSource = dtUnit;
            lueUnit.Properties.ValueMember = "id";
            lueUnit.Properties.DisplayMember = "name";

            strSql = " Select clr_grp,(clr_grp + '--'+cdesc) AS clr_grp_cdesc From mm_color_group Order By clr_grp";
            DataTable dtClrGrp = clsPublicOfCF01.GetDataTable(strSql);
            lueClr_Grp.Properties.DataSource = dtClrGrp;
            lueClr_Grp.Properties.ValueMember = "clr_grp";
            lueClr_Grp.Properties.DisplayMember = "clr_grp_cdesc";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew();
        }
        private void addNew()
        {
            append_mode = true;
            edit_mode = true;
            edit_flag = "1";
            cleanTextBox(1);
            setTextBoxEnabled();
            lueUnit.EditValue = "GRS";
            txtSize_Id.Focus();

        }
        private void cleanTextBox(int clean_part)
        {
            txtSize_Id.Text = "";
            txtEXfty.Text = "";
            txtFOB.Text = "";
            txtVAT.Text = "";
            lueUnit.EditValue = "";
        }
        private bool checkValid()
        {
            if (lueClr_Grp.EditValue==null || lueClr_Grp.EditValue.ToString() == "")
            {
                MessageBox.Show("顏色組別編號不能為空!");
                lueClr_Grp.Focus();
                return false;
            }
            if (txtSize_Id.Text == "")
            {
                MessageBox.Show("尺寸代號不能為空!");
                txtSize_Id.Focus();
                return false;
            }
            if (lueUnit.EditValue == null || lueUnit.EditValue.ToString().Trim() == "")
            {
                MessageBox.Show("單位不能為空!");
                lueUnit.Focus();
                return false;
            }
            if (txtEXfty.Text == "" || !clsValidRule.IsNumeric(txtEXfty.Text))
            {
                MessageBox.Show("EX-fty格式不正確!");
                txtEXfty.Focus();
                return false;
            }
            if (txtFOB.Text == "" || !clsValidRule.IsNumeric(txtFOB.Text))
            {
                MessageBox.Show("FOB格式不正確!");
                txtFOB.Focus();
                return false;
            }
            if (txtVAT.Text == "" || !clsValidRule.IsNumeric(txtVAT.Text))
            {
                MessageBox.Show("VAT格式不正確!");
                txtVAT.Focus();
                return false;
            }
            if (edit_flag == "1")//如果是新增狀態，檢查是否已存在編號
            {
                if (checkExistId() == true)
                {
                    MessageBox.Show("編號已存在,不能新增!");
                    return false;
                }
            }
            else
            {
                if (edit_flag == "2")//如果是編輯狀態，檢查是否已存在編號
                {
                    if (checkExistId() == false)
                    {
                        MessageBox.Show("沒有要編輯的記錄!");
                        return false;
                    }
                }
            }

            return true;
        }
        private bool checkExistId()
        {
            string strSql = " Select clr_grp From mm_stdprice_class Where prd_item='" + txtPrd_item.Text + "' And clr_grp='" + lueClr_Grp.EditValue.ToString() + "' And size_id='" + txtSize_Id.Text + "'";
            DataTable dtQuotation = clsPublicOfCF01.GetDataTable(strSql);
            if (dtQuotation.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (edit_mode == false)
            {
                MessageBox.Show("不是編輯狀態!");
                return;
            }
            if (!checkValid())
                return;
            string strSql = "";
            string result = "";
            string prd_item = txtPrd_item.Text;
            string prd_cdesc = txtPrd_Cdesc.Text;
            string clr_grp = lueClr_Grp.EditValue.ToString();

            string size_id = txtSize_Id.Text;
            string unit = lueUnit.EditValue.ToString();
            decimal ex_fty = Convert.ToDecimal(txtEXfty.Text);
            decimal fob = Convert.ToDecimal(txtFOB.Text);
            decimal vat = Convert.ToDecimal(txtVAT.Text);
            if (edit_flag == "1")//新增
                strSql = string.Format(@"INSERT INTO mm_stdprice_class (prd_item,prd_cdesc,clr_grp,size_id,unit,ex_fty,fob,vat,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE())"
                    , prd_item, prd_cdesc, clr_grp, size_id, unit, ex_fty, fob, vat, userid);
            else
                strSql = string.Format(@"UPDATE mm_stdprice_class SET unit='{0}',ex_fty='{1}',fob='{2}',vat='{3}',crusr='{4}',crtim=GETDATE()
                    WHERE prd_item='{5}' And clr_grp='{6}' And size_id='{7}'"
                    , unit, ex_fty, fob, vat, userid, prd_item, clr_grp, size_id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                loadData();
                setTextBoxEnabled();
                addNew();
            }
        }
        private void loadData()
        {
            string strSql = "";
            string clr_grp = "";
            if (lueClr_Grp.EditValue != null && lueClr_Grp.EditValue.ToString() != "")
                clr_grp = lueClr_Grp.EditValue.ToString();
            strSql = "Select a.*,c.cdesc AS color_group_cdesc,b.size_cdesc" +
                " from mm_stdprice_class a" +
                " Left Join bs_size b ON a.size_id=b.size_id" +
                " Inner Join mm_color_group c On a.clr_grp=c.clr_grp" +
                " Where a.prd_item>=''";
            if (txtPrd_item.Text != "")
                strSql += " And a.prd_item='" + txtPrd_item.Text + "'";
            if (clr_grp != "")
                strSql += " And a.clr_grp='" + clr_grp + "'";
            strSql += " Order By a.prd_item,a.clr_grp,a.size_id";
            DataTable dtQuotation = clsPublicOfCF01.GetDataTable(strSql);
            dgvQuotation.DataSource = dtQuotation;
        }
        private void fillTextBox(int rows)
        {
            edit_flag = "0";
            append_mode = false;
            edit_mode = false;
            setTextBoxEnabled();

            if (dgvQuotation.Rows.Count == 0)
                return;
            cleanTextBox(0);//全部清空文本框
            DataGridViewRow CurrentRow = dgvQuotation.Rows[rows];
            txtPrd_item.Text = CurrentRow.Cells["colPrd_item"].Value.ToString();
            txtPrd_Cdesc.Text = CurrentRow.Cells["colPrd_Cdesc"].Value.ToString();
            lueClr_Grp.EditValue = CurrentRow.Cells["colClr_Grp"].Value.ToString();
            txtSize_Id.Text = CurrentRow.Cells["colSize_Id"].Value.ToString();
            lueUnit.EditValue = CurrentRow.Cells["colUnit"].Value.ToString();
            txtEXfty.Text = CurrentRow.Cells["colEXfty"].Value.ToString();
            txtFOB.Text = CurrentRow.Cells["colFOB"].Value.ToString();
            txtVAT.Text = CurrentRow.Cells["colVAT"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void setTextBoxEnabled()
        {
            txtPrd_item.Properties.ReadOnly = !append_mode;
            lueClr_Grp.Properties.ReadOnly = !append_mode;
            txtSize_Id.Properties.ReadOnly = !append_mode;
            txtEXfty.Properties.ReadOnly = !edit_mode;
            txtFOB.Properties.ReadOnly = !edit_mode;
            txtVAT.Properties.ReadOnly = !edit_mode;
            lueUnit.Properties.ReadOnly = !edit_mode;
            if (append_mode == true && edit_mode == true)
            {
                txtPrd_item.BackColor = Color.White;
                lueClr_Grp.BackColor = Color.White;
                txtSize_Id.BackColor = Color.White;
            }
            else
            {
                txtPrd_item.BackColor = Color.Silver;
                lueClr_Grp.BackColor = Color.Silver;
                txtSize_Id.BackColor = Color.Silver;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            string result = "";
            string clr_grp = lueClr_Grp.EditValue.ToString();
            string strSql = "";
            if (checkExistId() == false)
            {
                MessageBox.Show("沒有要刪除的記錄!");
                return;
            }
            strSql = string.Format(@"DELETE mm_stdprice_class WHERE prd_item='{0}' And clr_grp='{1}' And size_id='{2}'", txtPrd_item.Text, clr_grp, txtSize_Id.Text);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);

            if (result != "")
                MessageBox.Show("刪除記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                loadData();
                setTextBoxEnabled();
                cleanTextBox(0);//清空全部文本框
            }
        }

        private void dgvQuotation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillTextBox(dgvQuotation.CurrentCell.RowIndex);
        }

        private void txtPrd_item_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void frmMMQuotation_Load(object sender, EventArgs e)
        {
            dgvQuotation.AutoGenerateColumns = false;
            initControls();
            setTextBoxEnabled();
            loadData();
        }

        private void btnColorGrp_Click(object sender, EventArgs e)
        {
            frmColorGroup frmColorGroup = new frmColorGroup();
            frmColorGroup.ShowDialog();
            frmColorGroup.Dispose();
            initControls();
        }
    }
}
