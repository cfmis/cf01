using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using System.Text;

namespace cf01.Forms
{
    public partial class frmUserGroup : Form
    {          
    
        DataTable dtUser_group = new DataTable();     
        private DataTable dtBrand = new DataTable();
        public string strUserid = "";
        private clsAppPublic clsApp = new clsAppPublic();
        public frmUserGroup()
        {
            InitializeComponent();
            //設置菜單按鈕的權限
            clsApp.SetToolBarEnable(this.Name, this.Controls);       

            //str_language = DBUtility._language;
            //try
            //{
            //    clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            //    control.GenerateContorl();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            //dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性

        }

        private void frmUser_Group_Load(object sender, EventArgs e)
        {
            //初始化表格
            string strSql = @"SELECT usrid,grpid,usrrst,brand_all,usrusr as crusr,usrtim as crtim,usrhrst 
                            FROM dbo.sy_user_group WHERE 1=0";
            dtUser_group = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dtUser_group;
            strSql = @"Select grpid,brand_id,remark,userid,remark as brand_name From dbo.sy_user_group_brand WHERE 1=0";
            dtBrand = clsPublicOfCF01.GetDataTable(strSql);
            dgvBrand.DataSource = dtBrand;

            DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'");
            txtGroup.Properties.DataSource = dtSales_Group;
            txtGroup.Properties.ValueMember = "id";
            txtGroup.Properties.DisplayMember = "id";


            if (strUserid.Length > 0)
            {
                txtUser_id.Text = strUserid;
                Find();
            }
        }

        private void frmUser_Group_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvDetails.Dispose();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            using (frmQuotation_Set_Grant ofrm = new frmQuotation_Set_Grant())
            {
                ofrm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Find();
        }
        
        // ===============以下爲自定義方法======================= 
    
        public void Find() //查詢
        {
            StringBuilder myString = new StringBuilder(@"SELECT usrid,grpid,usrrst,brand_all,usrusr as crusr,usrtim as crtim,usrhrst 
                            FROM dbo.sy_user_group with(nolock) WHERE 1>0 ");
            if (!string.IsNullOrEmpty(txtUser_id.Text))
            {
                myString.Append(string.Format(" AND usrid='{0}'", txtUser_id.Text));
            }
            if (!string.IsNullOrEmpty(txtGroup.Text))
            {
                myString.Append(string.Format(" AND grpid='{0}'",txtGroup.EditValue));
            }
            myString.Append(@" AND ISNULL(usrhrst,'')='Y'");            
            dgvDetails.Focus();
            dtUser_group = clsPublicOfCF01.GetDataTable(myString.ToString());
            dgvDetails.DataSource = dtUser_group;
        }



        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dtBrand.Clear();
                if (dgvDetails.CurrentRow.Cells["brand_all"].Value.ToString() != "*")
                {
                    string strUserid = dgvDetails.CurrentRow.Cells["usrid"].Value.ToString();
                    string strGroup = dgvDetails.CurrentRow.Cells["grpid"].Value.ToString();
                    string strSql = string.Format(
                    @"Select A.grpid,A.brand_id,A.remark,A.userid,B.name as brand_name
                    FROM dbo.sy_user_group_brand A with(nolock) 
                    LEFT OUTER JOIN {0}cd_brand B with(nolock) 
	                    ON B.within_code='0000' and A.brand_id=B.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                    WHERE userid='{1}' and grpid='{2}'",DBUtility.remote_db,strUserid, strGroup);
                    dtBrand = clsPublicOfCF01.GetDataTable(strSql);
                    dgvBrand.DataSource = dtBrand;
                }                
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }           
     
    }
}
