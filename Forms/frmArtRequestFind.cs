using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmArtRequestFind : Form
    {
        public string _id = "";
        readonly MsgInfo myMsg = new MsgInfo();
        public frmArtRequestFind(string _pID)
        {
            InitializeComponent();
            _id = _pID;            
        }

        private void frmArtRequestFind_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_id))
            {
                txtArt1.Text = _id;
                txtArt2.Text = _id; 
                Find_Data();
            }
            else
            {
                txtDat1.EditValue = String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-14));
                txtDat2.EditValue = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            }            
        }

        private void txtArt1_Leave(object sender, EventArgs e)
        {
            if (txtArt2.Text == "")
            { 
               txtArt2.Text = txtArt1.Text; 
            }
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            if (txtDat2.Text == "")
            {
                txtDat2.EditValue = txtDat1.EditValue;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find_Data();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                frmArtRequest._Requ_id = dataGridView1.CurrentRow.Cells["art_requ_id"].Value.ToString();
                frmArtRequest._ver = dataGridView1.CurrentRow.Cells["ver"].Value.ToString();
                Close();
            }
        }    

        private void Find_Data()
        {
            if (string.IsNullOrEmpty(txtArt1.Text) && string.IsNullOrEmpty(txtArt2.Text) &&
               string.IsNullOrEmpty(txtDat1.Text) && string.IsNullOrEmpty(txtDat1.Text))
            {
                MessageBox.Show("查詢條件不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string sql_f = @"SELECT A.art_requ_id,A.ver,CASE WHEN state='0' THEN '未批準' ELSE '已批準' END AS state,
                A.requ_dat,A.art_cdesc,A.sale_id,B.sale_cdesc,A.custcode FROM dbo.se_art_request A with(nolock) 
                LEFT JOIN dbo.bs_sale B with(nolock) ON A.sale_id=B.sale_code WHERE company_code='DG'";
            StringBuilder myString = new StringBuilder("");
            myString.Append(sql_f);
            if (!string.IsNullOrEmpty(txtArt1.Text))
            {
                myString.Append(String.Format(" AND A.art_requ_id>='{0}'", txtArt1.Text));
            }
            if (!string.IsNullOrEmpty(txtArt2.Text))
            {
                myString.Append(String.Format(" AND A.art_requ_id<='{0}'", txtArt2.Text));
            }
            if (!string.IsNullOrEmpty(txtDat1.Text))
            {
                myString.Append(String.Format(" AND A.requ_dat>='{0}'", txtDat1.Text));
            }
            if (!string.IsNullOrEmpty(txtDat2.Text))
            {
                myString.Append(String.Format(" AND A.requ_dat<='{0}'", txtDat2.Text));
            }
            myString.Append("ORDER BY A.art_requ_id,A.ver");
            DataTable dtArt_find = clsPublicOfCF01.GetDataTable(myString.ToString());
            dataGridView1.DataSource = dtArt_find;
            if (dtArt_find.Rows.Count == 0)
            {
                MessageBox.Show("找不到符合查詢條件的數據!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

         
     }
 }

