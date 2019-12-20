using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleForm;
using cf01.ModuleClass;
using System.Threading;
using System.IO;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmOcPrdStatus : cf01.ModuleForm.BaseFormMaster
    {
       
        clsCommonUse commUse = new clsCommonUse();
        string lang_id = DBUtility._language;
        string user_id = DBUtility._user_id;

        private clsUtility.enumOperationType Operation;

        public frmOcPrdStatus()
        {
            InitializeComponent();

            clsPublic objPublic = new clsPublic("frmOcPrdStatus", this.Controls);
            objPublic.GenerateData();
        }

        private void btnFindBrand_Click(object sender, EventArgs e)
        {
            frmFindDataBase frmBrand = new frmFindDataBase(btnFindBrand.Name);
            frmBrand.Owner = this;
            frmBrand.ShowDialog();
            textBox1.Text = DBUtility.get_query_id;
            textBox2.Text = DBUtility.get_query_id;
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            frmFindDataBase frmCust = new frmFindDataBase(btnFindCustomer.Name);
            frmCust.Owner = this;
            frmCust.ShowDialog();
            textBox3.Text = DBUtility.get_query_id;
            textBox4.Text = DBUtility.get_query_id;
        }

        private void frmOcPrdStatus_Load(object sender, EventArgs e)
        {
            this.dateEdit1.EditValue = DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
            this.dateEdit2.EditValue = DateTime.Now.ToString("yyyy/MM/dd");
            string strsql;
            strsql = "Select * from v_dict_group where formname=" + "'" + "Mo_Group" + "'" +
                    " AND language_id =" + "'" + lang_id + "'" + " Order By tb_col_sort";
            commUse.BindComboBox(cmbMoGroup, "formname", "show_name", strsql, "v_dict_group");
            strsql = "Select * from v_dict_group where formname=" + "'" + "order_complete_status" + "'" +
                    " AND language_id =" + "'" + lang_id + "'";
            commUse.BindComboBox(cmbCpl, "formname", "show_name", strsql, "v_dict_group");
        }

        public override void Find()
        {
            int f_type, mo_group_select;
            string dat1 = "", dat2 = "";
            if (cmbCpl.SelectedIndex > 3)
            {
                MessageBox.Show("訂單狀態選項未定義!");
                return;
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false || clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
            {
                if (clsValidRule.CheckDateFormat(this.dateEdit1.Text) == false || clsValidRule.CheckDateFormat(this.dateEdit2.Text) == false)
                {
                    MessageBox.Show("訂單日期不正確!");
                    this.dateEdit1.Focus();
                    return;
                }
            }
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit1.Text) == false)
                dat1 = this.dateEdit1.Text.ToString();// Convert.ToDateTime(this.dateEdit1.EditValue).ToString("yyyy/mm/dd");
            if (clsValidRule.CheckDateIsEmpty(this.dateEdit2.Text) == false)
                dat2 = Convert.ToDateTime(this.dateEdit2.Text).AddDays(1).ToString("yyyy/MM/dd");
            mo_group_select = cmbMoGroup.SelectedIndex;
            string mo_group;
            mo_group = "ALL";
            f_type = cmbCpl.SelectedIndex;
            //if (cmbCpl.SelectedIndex == -1 || cmbCpl.SelectedItem.ToString() == "")
            //    f_type = 1;
            //else
            //    f_type = cmbCpl.SelectedIndex + 1;
            if (mo_group_select == -1 || cmbMoGroup.SelectedItem.ToString() == "" || mo_group_select == 0)
                mo_group = "ALL";
            else
                if (mo_group_select <= 27)
                    mo_group = Convert.ToChar(64 + mo_group_select).ToString();//dtbOrderFrom.Text.ToString(), dtbOrderTo.Value.AddDays(1).ToShortDateString()
                else
                    if (mo_group_select == 28)//PDD
                        mo_group = "PDD";
           
            DataTable dt = commUse.getDataProcedure("pr_oc_prd_status",
                new object[] { f_type,lang_id,mo_group,textBox1.Text, textBox2.Text, dat1,dat2
                    ,textBox3.Text, textBox4.Text,textBox5.Text,textBox6.Text,textBox11.Text,textBox12.Text
                    ,textBox9.Text,textBox10.Text});
            dgvDetails.DataSource = dt;
        }
        public override void Excel()
        {
            this.DvExportExcel();
        }
        private void DvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                for (int i = 0; i < dgvDetails.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容
                string col_value;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                    {

                        if (columnNo > 0)
                        {
                            tempstr += "\t";
                        }
                        if (columnNo != 7)
                            col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        else
                            col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value + "\"";
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        public override void Cancel()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox1.Focus();

            Operation = clsUtility.enumOperationType.Cancel;
            clsUtility.EnableToolStripButton(toolStrip1, Operation);
        }

        private void dateEdit1_Leave(object sender, EventArgs e)
        {
            dateEdit2.Text = dateEdit1.Text;
        }


    }
}
