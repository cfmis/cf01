using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace cf01.ReportForm
{
    public partial class frmStock : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataSet dts;
        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            string strSql = @"SELECT id,name FROM cd_productline with(nolock) WHERE within_code ='0000' AND type='01' and state<>'2'";
            DataTable dtDept = clsConErp.GetDataTable(strSql);

            if (dtDept.Rows.Count > 0)
            {
                DataRow dr = null;
                dr = dtDept.NewRow();
                dr["id"] = " ";
                dr["name"] = "";
                dtDept.Rows.InsertAt(dr, 0);

                //收貨部門              
                txtIn_dept1.Properties.DataSource = dtDept;
                txtIn_dept1.Properties.ValueMember = "id";
                txtIn_dept1.Properties.DisplayMember = "id";

                txtIn_dept2.Properties.DataSource = dtDept;
                txtIn_dept2.Properties.ValueMember = "id";
                txtIn_dept2.Properties.DisplayMember = "id";
            }
        }

        public DataTable GetAll_WH()
        {
            DataTable dtDept = new DataTable();
            try
            {
                string strSql = @"SELECT id,name FROM cd_productline with(nolock) WHERE within_code ='0000' AND storehouse_group='DG' AND type='01' and state<>'2'";
                dtDept = clsConErp.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtDept;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (txtIn_dept1.Text == "" || txtIn_dept2.Text == "")
            {
                MessageBox.Show("部門不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIn_dept1.Focus();
                return;
            }

            if (txtDat1.Text == "" || txtDat2.Text == "" )
            {
                MessageBox.Show("日期不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDat1.Focus();
                return;
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();


            SqlParameter[] paras = new SqlParameter[]
            {                   
                    new SqlParameter("@dept1", txtIn_dept1.EditValue),
                    new SqlParameter("@dept2", txtIn_dept2.EditValue),
                    new SqlParameter("@dat1", txtDat1.Text),
                    new SqlParameter("@dat2",  txtDat2.Text),
                    new SqlParameter("@type", !checkBox1.Checked?"1":"2")
            };
           
            dts = clsConErp.ExecuteProcedureReturnDataSet("z_st_in_out", paras,null);
            dgvDetails1.DataSource = dts.Tables[0];
            dgvDetails2.DataSource = dts.Tables[1];
            dgvDetails3.DataSource = dts.Tables[2];

            //if (dts.Tables.Count==3)
            //    dgvDetails2.DataSource = dts.Tables[1];//按交易匯總
            //else
            //    dgvDetails2.DataSource = null;

            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (dts.Tables[0].Rows.Count > 0)
            {
                //禁止列排序
                for (int i = 0; i < this.dgvDetails1.Columns.Count; i++)
                {
                    this.dgvDetails1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                dts.Tables[0].Clear();
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          

        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (this.dgvDetails1.RowCount == 0)
            {
                MessageBox.Show("請先查詢出數據", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false )
            {
                MessageBox.Show("請選擇匯出EXCEL的類型", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExpToExcel obj = new ExpToExcel();
            //尾數入倉
            if (checkBox1.Checked && dts.Tables.Count == 2)
            {
                obj.DataTableToExcel(dts.Tables[1]);
               
                return;
            }

            //匯總表
            if (radioButton1.Checked)
            {               
                obj.ExportExcel(dgvDetails1);
            }
            //安交易動作分數匯總
            if (radioButton2.Checked)
            {                
                //obj.ExportExcel(dgvDetails2);
                obj.ExportExcel(dgvDetails2);
            }

            //收入支出明細
            if (radioButton3.Checked)
            {
                //dataGridView1.DataSource = dts.Tables[2];//收入明細               
                obj.ExportExcel(dgvDetails3);
                //obj.DataTableToExcel(dts.Tables[2]);
            }
            ////支出明細
            //if (radioButton4.Checked)
            //{
            //    if (dts.Tables.Count > 2)
            //    {
            //        //dataGridView1.DataSource = dts.Tables[3];//支出明細                   
            //        //obj.ExportExcel(dataGridView1); 
            //        obj.DataTableToExcel(dts.Tables[2]);
            //    }
            //}
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void txtIn_dept1_Leave(object sender, EventArgs e)
        {
            txtIn_dept2.EditValue = txtIn_dept1.EditValue;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }
    }
}
