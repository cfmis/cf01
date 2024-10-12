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
    public partial class frmPrintSO : Form
    {
        DataTable dtSO = new DataTable();
        DataSet ds = new DataSet();
        private DataRow foundRow;

        public frmPrintSO()
        {
            InitializeComponent();
        }

        private void FindDataTableRow()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("someText", typeof(string));
            dt2.Columns.Add("id2", typeof(int));
            dt2.Columns.Add("someOtherText", typeof(string));

            DataRow dr;
            for (int i = 0; i < 13; i++)
            {
                dr = dt1.NewRow();
                dr["id"] = i;
                dr["someText"] = "text with number" + i.ToString();
                dt1.Rows.Add(dr);
            }
            dr = dt1.NewRow();
            dr["id"] = 14;
            dr["someText"] = "johnnyCheung";
            dt1.Rows.Add(dr);

            for (int j = 101; j < 113; j++)
            {
                dr = dt2.NewRow();
                dr["id2"] = j;
                dr["someOtherText"] = "other text with number" + j.ToString();
                dt2.Rows.Add(dr);
            }
            dr = dt2.NewRow();
            dr["id2"] = 114;
            dr["someOtherText"] = "johnnyCheung";
            dt2.Rows.Add(dr);

            ds.Tables.AddRange(new DataTable[] { dt1, dt2 });

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                string strText = null;
                foreach (DataRow row in ds.Tables[i].Rows)
                {
                    string a = row[0].ToString();
                    string b = row[1].ToString();
                    strText = a + "." + b + Environment.NewLine;

                }
            }
            ds.Tables[0].DefaultView.Sort = "id";
            DataColumn[] dcpk = new DataColumn[1];
            dcpk[0] = ds.Tables[0].Columns["someText"];
            ds.Tables[0].PrimaryKey = dcpk;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            object s = txtBrandId.Text.Trim();
            foundRow = ds.Tables[0].Rows.Find(s);

            if (foundRow != null)
            {
                MessageBox.Show(foundRow[0].ToString() + "," + foundRow[1].ToString());
            }
            else
            {
                MessageBox.Show("");
            }
            
            DataRow[] rowFound;
            rowFound = ds.Tables[0].Select("someText like 'johnny%'");
            if (rowFound != null)
            {
                MessageBox.Show(rowFound[0].ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
				dtSO = null;// DBUtility.GetSoOrderTatol(dtpStartDate.Value, dtpEndDate.Value, txtBrandId.Text.Trim(), "1");
                if (dtSO.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtSO;

                }
                else
                {
                    MessageBox.Show("沒有找到符合條件的記錄", "系統信息", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
