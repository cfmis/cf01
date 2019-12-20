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
using cf01.CLS;
namespace cf01.ReportForm
{
    public partial class frmFindDataBase : BaseFormMaster
    {
        clsCommonUse commUse = new clsCommonUse();

        public string _OperationType;
        public frmFindDataBase(string OperationType)
        {
            InitializeComponent();
            _OperationType = OperationType;

            clsPublic objPublic = new clsPublic(this.Name, this.Controls);
            objPublic.GenerateData();
        }

        private void frmFindDataBase_Load(object sender, EventArgs e)
        {
            DBUtility.get_query_id = "";
            InitControlsData();
        }

        private void InitControlsData()
        {
            switch (_OperationType)
            {
                case "btnFindBrand":
                    {
                        BindCmbBrand();

                        dgvCustomer.Visible = false;
                        dgvBrand.Visible = true;
                        dgvBrand.Location = new Point(4, 71);
                        dgvBrand.Size = new Size(610, 310);
                    }
                    break;
                case "btnFindCustomer":
                    {
                        BindCmbCustomer();

                        dgvBrand.Visible = false;
                        dgvCustomer.Visible = true;
                        dgvCustomer.Location = new Point(4, 71);
                        dgvCustomer.Size = new Size(610, 310);
                    }
                    break;
                default:
                    break;
            }
        }

        private void BindCmbBrand()
        {
            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "operator_word" + "'" +
                                " AND language_id =" + "'" + DBUtility._language + "'";
            commUse.BindComboBox(cmbOpe, "formname", "show_name", strsql, "v_dict_group");

            strsql = "Select * from v_dict_group where formname=" + "'" + "frmLoadBrand_grid1" + "'" +
                    " AND language_id =" + "'" + DBUtility._language + "'";
            commUse.BindComboBox(cmbFieldList, "formname", "show_name", strsql, "v_dict_group");
        }

        private void BindCmbCustomer()
        {
            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "operator_word" + "'" +
                    " AND language_id =" + "'" + DBUtility._language + "'";
            commUse.BindComboBox(cmbOpe, "formname", "show_name", strsql, "v_dict_group");

            strsql = "Select * from v_dict_group where formname=" + "'" + "frmLoadCust_grid1" + "'" +
                    " AND language_id =" + "'" + DBUtility._language + "'";
            commUse.BindComboBox(cmbFieldList, "formname", "show_name", strsql, "v_dict_group");
        }

        public override void Find()
        {
            switch (_OperationType)
            {
                case "btnFindBrand":
                    BinddvgBrand();
                    break;
                case "btnFindCustomer":
                    BinddgvCustomer();
                    break;
                default:
                    break;
            }
        }

        private void BinddvgBrand()
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;
            string tb_field = "formname";
            string keyWord;
            keyWord = txtKeyWord.Text.Trim();
            int f_type;
            f_type = cmbFieldList.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    tb_field = " a.name ";
                    break;
                case 2:
                    tb_field = " a.english_name ";
                    break;
                case 3:
                    tb_field = " a.id ";
                    break;
            }
            f_type = cmbOpe.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    strWhere = " WHERE " + tb_field + " like " + "'%" + keyWord + "%'";
                    break;
                case 2:
                    strWhere = " WHERE " + tb_field + " = " + "'%" + keyWord + "%'";
                    break;
                default:
                    break;
            }

            string strSql = null;
            strSql = "SELECT a.id,a.english_name,a.name";
            strSql += " FROM " + DBUtility.remote_db + "cd_brand a " + strWhere;

            try
            {
                dgvBrand.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "cd_brand").Tables["cd_brand"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void BinddgvCustomer()
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;
            string tb_field = "formname";
            string keyWord;
            keyWord = txtKeyWord.Text.Trim();
            int f_type;
            f_type = cmbFieldList.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    tb_field = " a.id ";
                    break;
                case 2:
                    tb_field = " a.english_name ";
                    break;
                case 3:
                    tb_field = " a.name ";
                    break;
            }
            f_type = cmbOpe.SelectedIndex + 1;
            switch (f_type)
            {
                case 1:
                    strWhere = " WHERE " + tb_field + " like " + "'%" + keyWord + "%'";
                    break;
                case 2:
                    strWhere = " WHERE " + tb_field + " = " + "'%" + keyWord + "%'";
                    break;
                default:
                    break;
            }

            string strSql = null;

            strSql = "SELECT a.id,a.english_name,a.name";
            strSql += " FROM " + DBUtility.remote_db + "it_customer a " + strWhere;

            try
            {
                dgvCustomer.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "it_customer").Tables["it_customer"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void dgvBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBrand.RowCount > 0)
            {
                string strId = dgvBrand["colBrandId", dgvBrand.CurrentCell.RowIndex].Value.ToString();
                DBUtility.get_query_id = strId;

                this.Close();
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.RowCount > 0)
            {
                string strId = dgvCustomer["colit_customer", dgvCustomer.CurrentCell.RowIndex].Value.ToString();
                DBUtility.get_query_id = strId;
                this.Close();
            }
        }
    }
}
