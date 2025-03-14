using cf01.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace cf01.ReportForm
{
    public partial class frmSop : Form
    {
        DataTable dtFind = new DataTable();
        DataTable dtExcel = new DataTable();
        ExpToExcel objExcel = new ExpToExcel();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public frmSop()
        {
            InitializeComponent();
        }

        private void frmSop_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT convert(bit,0) as flag_select,sop1no,sop1dat,sop1style,sop1cname FROM sop01 Where 1=0 ";
            dtFind = clsConErp.GetDataTable(sql);
            dgvDetails.DataSource = dtFind;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string sql = 
            @"SELECT convert(bit,0) as flag_select,sop1no,sop1dat,RTRIM(ISNULL(sop1style,'')) AS sop1style,
            RTRIM(sop1cname) AS sop1cname FROM sop01 Where 1>0 ";
            if(dtDat1.EditValue.ToString()!="")
            {
                string dat1 = DateTime.Parse(dtDat1.EditValue.ToString()).Date.ToString("yyyy/MM/dd");
                sql += " and sop1dat>='" + dat1 + "'";
            }
            if (dtDat2.EditValue.ToString() != "")
            {
                string dat2 = DateTime.Parse(dtDat2.EditValue.ToString()).Date.ToString("yyyy/MM/dd");
                sql += " and sop1dat<='" + dat2 + "'";
            }
            if (txtId1.Text != "")
            {                
                sql += " and sop1no>='" + txtId1.Text + "'";
            }
            if (txtId2.Text != "")
            {
                sql += " and sop1no<='" + txtId2.Text + "'";
            }
            if (txtStyle1.Text != "")
            {
                sql += " and sop1style>='" + txtStyle1.Text + "'";
            }
            if (txtStyle2.Text != "")
            {
                sql += " and sop1style<='" + txtStyle2.Text + "'";
            }
            sql += " ORDER BY sop1dat,sop1no";
            dtFind = clsConErp.GetDataTable(sql);
            dgvDetails.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的數據！！", "提示信息");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkSelect_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                chkSelect.Checked = false;
                return;
            }            
            for(int i=0;i<dtFind.Rows.Count;i++)
            {
                if (chkSelect.Checked)
                {
                    dtFind.Rows[i]["flag_select"] = true;
                }
                else
                {
                    dtFind.Rows[i]["flag_select"] = false;
                }                
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("請先查找出數據！！", "提示信息");
                return;
            }            
            DataRow[] drs = null;
            bool blFlag = false;          
            for (int i = 0; i < dtFind.Rows.Count; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {
                    blFlag = true;
                    break;
                }
            }
            if (!blFlag)
            {
                MessageBox.Show("請首先勾選出要匯出EXCEL的記錄！", "提示信息");
                return;                
            }
            drs = dtFind.Select("flag_select=true");
            dtExcel.Clear();
            dtExcel = dtFind.Clone();
            dtExcel.Columns.Remove("flag_select"); //移除某列
            //start導入前一次打勾的查詢結果
            if (drs != null)
            {
                if (drs.Length > 0)
                {
                    string str = "";                   
                    for (int i = 0; i < dtFind.Rows.Count; i++)
                    {
                        if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                        {
                            DataRow drw = dtExcel.NewRow();                           
                            drw["sop1no"] = dtFind.Rows[i]["sop1no"].ToString();
                            drw["sop1dat"] = "'"+ dtFind.Rows[i]["sop1dat"].ToString();
                            str = dtFind.Rows[i]["sop1style"].ToString();
                            drw["sop1style"] = str.All(char.IsDigit)?"'"+ str:str; //判斷款號是否是全是數字，如果是，前面加多一單引號                        
                            drw["sop1cname"] = dtFind.Rows[i]["sop1cname"].ToString();
                            dtExcel.Rows.Add(drw);
                        }
                    }
                    DataRow[] drs_del;
                    foreach (DataRow row in drs)
                    {
                        drs_del = dtFind.Select(string.Format("sop1no='{0}'", row["sop1no"]));
                        foreach (DataRow row_del in drs_del)
                        {
                            dtFind.Rows.Remove(row_del);//先移走已存在的行
                        }
                    }
                    drs_del = null;
                    dtFind.Select();
                    drs = null;
                    dgvExcel.DataSource = dtExcel;
                }
                //ExpToExcel.DataGridViewToExcel(dgvExcel);
                objExcel.ExportExcel(dgvExcel);                
            }
            //--end            
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDat2.EditValue = dtDat1.EditValue;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        private void txtStyle1_Leave(object sender, EventArgs e)
        {
            txtStyle2.Text = txtStyle1.Text;
        }
    }
}
