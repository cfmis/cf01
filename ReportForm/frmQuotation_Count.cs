using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;

namespace cf01.ReportForm
{
    public partial class frmQuotation_Count : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private string strFind_condition = "";
        public frmQuotation_Count()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(Name, panel1.Controls);
        }

     

        private void frmQuotation_Count_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrtim1.Text))
            {
                txtCrtim1.EditValue = DateTime.Now;
            }
            if (string.IsNullOrEmpty(txtCrtim2.Text))
            {
                txtCrtim2.EditValue = DateTime.Now;
            }
            txtCrtim1.Focus();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            txtCrtim1.Text = "";
            txtCrtim2.Text = "";
            txtCrusr1.Text = "";
            txtCrusr2.Text = "";
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            txtCrtim1.Focus();
            
            if (txtCrtim1.Text == "" && txtCrtim2.Text == "" && txtCrusr1.Text == "" && txtCrusr2.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCrtim1.Focus();
                return;
            }
            
            string rtp_type,strDataSource;
            if (rdo1.Checked)
            {
                rtp_type = "1";
                strDataSource = rdo1.Text;                
            }
            else
            {
                rtp_type = "2";
                strDataSource = rdo2.Text;                
            }
            strFind_condition = String.Format("建檔日期From: {0} To: {1}\n\r建檔人From: {2} To: {3}\n\r數據來源:{4}", txtCrtim1.Text, txtCrtim2.Text, txtCrusr1.Text, txtCrusr2.Text , strDataSource);

            SqlParameter[] paras = new SqlParameter[]
            {                   
                
                new SqlParameter("@rpt_type",rtp_type ),
                new SqlParameter("@Crtim1", DateTime.Parse(txtCrtim1.EditValue.ToString()).Date.ToString("yyyy/MM/dd")),
                new SqlParameter("@Crtim2", DateTime.Parse(txtCrtim2.EditValue.ToString()).Date.ToString("yyyy/MM/dd")),
                new SqlParameter("@Crusr1", txtCrusr1.Text),
                new SqlParameter("@Crusr2",  txtCrusr2.Text)
            };
           
            DataSet dts = clsPublicOfCF01.ExecuteProcedureReturnDataSet("usp_rpt_quotation_count", paras, null);
            dgvDetails1.DataSource = dts.Tables[0];//按日期
            dgvDetails2.DataSource = dts.Tables[1];//按建檔人
            dgvDetails3.DataSource = dts.Tables[2];//按年月份
            dgvDetails4.DataSource = dts.Tables[3];//明細資料           
            if (dts.Tables[0].Rows.Count > 0)
            {
                //禁止列排序
                for (int i = 0; i < dgvDetails1.Columns.Count; i++)
                {
                    dgvDetails1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                //禁止列排序
                for (int i = 0; i < dgvDetails2.Columns.Count; i++)
                {
                    dgvDetails2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                //禁止列排序
                for (int i = 0; i < dgvDetails3.Columns.Count; i++)
                {
                    dgvDetails3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                dts.Tables[0].Clear();
                dts.Tables[1].Clear();
                dts.Tables[2].Clear();
                dts.Tables[3].Clear();
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, panel1.Controls) > 0)
            {
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            }
            else
            {
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCrtim1_Leave(object sender, EventArgs e)
        {
            txtCrtim2.EditValue = txtCrtim1.EditValue;
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void Print() //通用的打印方法
        {
            string strTitle;
            if (dgvDetails1.RowCount > 0)
            {
                if (rdo_by_ym.Checked)//按月份匯總
                {
                    strTitle = String.Format("按月份匯總\n\r{0}", strFind_condition);
                    PrintDGV.Print_DataGridView(dgvDetails3,strTitle);
                }
                if (rdo_by_date.Checked)//按日期匯總
                {
                    strTitle = String.Format("按日期匯總\n\r{0}", strFind_condition);
                    PrintDGV.Print_DataGridView(dgvDetails1, strTitle);
                }
                if (rdo_by_crusr.Checked)//按建檔人匯總
                {
                    strTitle = String.Format("按建檔人匯總\n\r{0}", strFind_condition);
                    PrintDGV.Print_DataGridView(dgvDetails2,strTitle);
                }                
                if (rdo_by_details.Checked)//明細
                {                    
                    MessageBox.Show("請使用匯出EXCEL功能!", "提示信息");
                    return;                    
                }
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails1.Rows.Count == 0)
            {
                MessageBox.Show("請首先查詢出要列印的數據!", "提示信息");
                return;
            }
            Excel();
        }

        private void Excel() //匯出EXCEL
        {
            ExpToExcel oxls = new ExpToExcel();
            if (rdo_by_date.Checked)
            {
                oxls.ExportExcel(dgvDetails1);
            }
            if (rdo_by_crusr.Checked)
            {
                oxls.ExportExcel(dgvDetails2);
            }
            if (rdo_by_ym.Checked)
            {
                oxls.ExportExcel(dgvDetails3);
            }
            if (rdo_by_details.Checked)
            {
                oxls.ExportExcel(dgvDetails4);
            }
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1.Checked)
            {
                rdo2.Checked = false;
            }
            else
            {
                rdo2.Checked = true;
            }
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo2.Checked)
            {
                rdo1.Checked = false;
            }
            else
            {
                rdo1.Checked = true;
            }
        }

        private void rdo_by_date_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_by_date.Checked)
            {
                rdo_by_crusr.Checked = false;
                rdo_by_details.Checked = false;
            }            
        }

        private void rdo_by_crusr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_by_crusr.Checked)
            {
                rdo_by_date.Checked = false;
                rdo_by_details.Checked = false;
            }
        }

        private void rdo_by_details_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_by_details.Checked)
            {
                rdo_by_crusr.Checked = false;
                rdo_by_date.Checked = false;                
            }
        }

        private void txtCrusr1_Leave(object sender, EventArgs e)
        {
            txtCrusr2.Text = txtCrusr1.Text;
        }

    }
}
