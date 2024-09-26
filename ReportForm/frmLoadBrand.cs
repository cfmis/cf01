using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmLoadBrand : Form
    {
        clsCommonUse commUse = new clsCommonUse();
        string lang_id = DBUtility._language;
        string remote_db = DBUtility.remote_db;//遠程數據庫連接

        public frmLoadBrand()
        {
            InitializeComponent();
        }

        private void frmLoadBrand_Load(object sender, EventArgs e)
        {
            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "operator_word" + "'" +
                                " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbOperator, "formname", "show_name", strsql, "v_dict_group");

            strsql = "Select * from v_dict_group where formname=" + "'" + "frmLoadBrand_grid1" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbFieldName, "formname", "show_name", strsql, "v_dict_group");

            commUse.BuilDataGridView(dgvDetails, "frmLoadBrand_grid1", lang_id);
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;
            string tb_field = "formname";
            string keyWord;
            keyWord = txtKeyWord.Text.Trim();
            int f_type;
            f_type = cmbFieldName.SelectedIndex + 1;
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
            f_type = cmbOperator.SelectedIndex + 1;
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

            this.BindDataGridView(strWhere);
        }


        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                string strId = this.dgvDetails["id", this.dgvDetails.CurrentCell.RowIndex].Value.ToString();
                DBUtility.get_query_id = strId;
                //frmLoadOc02.get_brand = strId;
                //frmLoadOc03.get_brand = strId;
            }
        }

        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                this.Close();
            }
        }

        private void cmbFieldList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT a.id,a.english_name,a.name";
            strSql += " FROM " + remote_db + "cd_brand a " + strWhere;

            try
            {
                this.dgvDetails.DataSource = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "cd_brand").Tables["cd_brand"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }
    }
}
