using cf01.CLS;
using cf01.ModuleClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmSaleReturn : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        clsToolBarNew objToolbar;
        DataTable dtFind = new DataTable();
        string strDatetime = clsUtility.GetCurrentDateTime(); //2026-03-09 15:50:02
        string within_code = "0000", groupNumber = "", strBarcode = "";

        public frmSaleReturn()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, grpBox1.Controls);
            NextControl oNext = new NextControl(this, "2");
            oNext.EnterToTab();
            objToolbar = new clsToolBarNew(this.Name, this.toolStrip1);
            objToolbar.SetToolBar();
        }

        private void frmSaleReturn_Load(object sender, EventArgs e)
        {
            string strSql =
            @"SELECT A.id,Convert(varchar(10),A.issues_date,120) as issues_date,A.type,A.it_customer,
            B.mo_id,B.goods_id,B.goods_name,Substring(A.cd_seller,2,1) As sales_group,B.contract_cid,
            CAST(B.invoice_qty AS INT) AS invoice_qty,B.issues_unit,B.sec_qty,B.sec_unit,B.order_id,B.invoice_id
            FROM so_debitcredit_note_mostly A ,so_debeitcredit_note_details B 
            WHERE 1=0 ";
            dtFind = clsErp.GetDataTable(strSql);
            gridControl1.DataSource = dtFind;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            string strSql =
            @"SELECT A.id,Convert(varchar(10),A.issues_date,120) AS issues_date,A.type,A.it_customer,
            B.mo_id,B.goods_id,B.goods_name,Substring(A.cd_seller,2,1) As sales_group,B.contract_cid,
            CAST(B.invoice_qty AS INT) AS invoice_qty,B.issues_unit,B.sec_qty,B.sec_unit,B.order_id,B.invoice_id
            FROM so_debitcredit_note_mostly A with(nolock),so_debeitcredit_note_details B with(nolock)
            WHERE A.id=B.id And A.within_code=B.within_code ";
            if(txtID1.Text != "")
            {
                strSql += " And A.id>='" + txtID1.Text + "'";
            }
            if (txtID2.Text != "")
            {
                strSql += " And A.id<='" + txtID2.Text + "'";
            }
            if (txtID1.Text != "" && txtID2.Text !="")
            {
                strSql += " And A.within_code = '0000'";
            }
            if (txtIssues_date1.Text != "")
            {
                strSql += " And A.issues_date>='" + txtIssues_date1.Text + "'";
            }
            if (txtIssues_date2.Text != "")
            {
                strSql += " And A.issues_date<='" + txtIssues_date2.Text + "'";
            }
            if(txtIt_customer.Text != "")
            {
                strSql += " And A.it_customer='" + txtIt_customer.Text + "'";
            }
            if (txtSales_group.Text != "")
            {
                strSql += " And Substring(A.cd_seller,2,1)='" + txtSales_group.Text + "'";
            }
            strSql += "And A.type='CR' AND A.state NOT IN ('2','0')";
            dtFind = clsErp.GetDataTable(strSql);
            gridControl1.DataSource = dtFind;
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value("frmSaleReturn", grpBox1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
