using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using DevExpress.XtraEditors;

namespace cf01.Forms
{
    public partial class frmBomFind : Form
    {
        public static string str_language = "0";
        private string _bom_id = "";
        //readonly clsCommonUse commUse = new clsCommonUse();
   

        public frmBomFind()
        {
            InitializeComponent();
            str_language = DBUtility._language;
            NextControl oNext = new NextControl(this, "1");
            oNext.EnterToTab();

            string strImgPath = AppDomain.CurrentDomain.BaseDirectory;
            string strFileImag = strImgPath + "Images\\exit.png";
            if (System.IO.File.Exists(strFileImag))
            {
                BTNEXIT.Image = Bitmap.FromFile(strFileImag);
            }
            strFileImag = "";
            strFileImag = strImgPath + "Images\\find.ico";
            if (System.IO.File.Exists(strFileImag))
            {
                BTNFIND.Image = Bitmap.FromFile(strFileImag);
            }
            strFileImag = "";
            strFileImag = strImgPath + "Images\\p_ok.png";
            if (System.IO.File.Exists(strFileImag))
            {
                BTNOK.Image = Bitmap.FromFile(strFileImag);
            }

            DataTable dtDept = clsPublicOfCF01.GetDataTable(@"SELECT dep_id,(dep_id +'[' + dep_cdesc+']') AS dep_cdesc FROM dbo.bs_dep with(nolock) WHERE dep_group='DG'");
            DataRow dr1 = dtDept.NewRow(); //插一空行
            dr1["dep_id"] = "";
            dtDept.Rows.InsertAt(dr1, 0);            
            txtDetp_id1.Properties.DataSource = dtDept;            
            txtDetp_id1.Properties.ValueMember = "dep_id";
            txtDetp_id1.Properties.DisplayMember = "dep_cdesc";
            txtDetp_id2.Properties.DataSource = dtDept;
            txtDetp_id2.Properties.ValueMember = "dep_id";
            txtDetp_id2.Properties.DisplayMember = "dep_cdesc";        

        }

        private void frmBomFind_Load(object sender, EventArgs e)
        {

        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBom_id1_Leave(object sender, EventArgs e)
        {
            txtBom_id2.Text = txtBom_id1.Text;
        }  

        private void txtGoods_id1_Leave(object sender, EventArgs e)
        {
            txtGoods_id2.Text = txtGoods_id1.Text;
        }  

        private void txtCreate_date1_Leave(object sender, EventArgs e)
        {
           clsValidRule.CheckDate(sender);
           txtCreate_date2.EditValue = txtCreate_date1.EditValue;
        }

        private void txtCheck_date1_Leave(object sender, EventArgs e)
        {
            clsValidRule.CheckDate(sender);            
            txtCheck_date2.EditValue = txtCheck_date1.EditValue;            
        }

        private void txtCreate_date2_Leave(object sender, EventArgs e)
        {
            clsValidRule.CheckDate(sender);
        }

        private void txtCheck_date2_Leave(object sender, EventArgs e)
        {
            clsValidRule.CheckDate(sender);
        }

        private void txtDetp_id1_Leave(object sender, EventArgs e)
        {
            txtDetp_id2.EditValue = txtDetp_id1.EditValue;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (txtBom_id1.Text == "" && txtBom_id2.Text == "" && txtGoods_id1.Text == "" && txtGoods_id2.Text == "" &&
                 txtGoods_name.Text == "" && txtDetp_id1.Text == "" && txtDetp_id2.Text == "" && txtCreate_date1.Text == ""
                 && txtCreate_date2.Text == "" && txtCheck_date1.Text == "" && txtCheck_date2.Text == "" )
            {
                MessageBox.Show("查詢條件不可爲空!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //StringBuilder sb = new StringBuilder(
            //@"SELECT A.id,A.goods_id,A.dept_id,A.create_date,A.check_date,B.name,C.name AS dept_name 
            //FROM dgerp2.cferp.dbo.it_bom_mostly A WITH(nolock) 
            //INNER JOIN dgerp2.cferp.dbo.it_goods B WITH(nolock) ON A.within_code =B.within_code AND A.goods_id = B.id 
            //LEFT JOIN dgerp2.cferp.dbo.cd_department C WITH(nolock) ON A.within_code =C.within_code AND A.dept_id = C.id 
            //WHERE A.type='0001'");
           StringBuilder sb = new StringBuilder(
              @"SELECT A.id,A.goods_id,A.dept_id,A.create_date,A.check_date,A.state,B.item_cdesc as name,C.dep_desc AS dept_name 
                FROM dbo.bs_bom_mostly A WITH(nolock) 
                INNER JOIN dbo.bs_mat_master B WITH(nolock) ON A.goods_id = B.prd_item 
                LEFT JOIN dbo.bs_dep C WITH(nolock) ON A.dept_id = C.dep_id 
                WHERE A.type='0001'");
            
            if (txtBom_id1.Text != "")
            {
                sb.Append(String.Format(" AND A.id>='{0}'", txtBom_id1.Text));
            }
            if (txtBom_id2.Text != "")
            {
                sb.Append(String.Format(" AND A.id<='{0}'", txtBom_id2.Text));
            }
            if (txtGoods_id1.Text != "")
            {
                sb.Append(String.Format(" AND A.goods_id>='{0}'", txtGoods_id1.Text));
            }
            if (txtGoods_id2.Text != "")
            {
                sb.Append(String.Format(" AND A.goods_id<='{0}'", txtGoods_id2.Text));
            }
            if (txtGoods_name.Text != "")
            {
                //sb.Append(String.Format(" AND B.name LIKE '%{0}%'", txtGoods_name.Text));
                sb.Append(String.Format(" AND B.item_cdesc LIKE '%{0}%'", txtGoods_name.Text));
            }
            if (txtDetp_id1.Text != "")
            {
                sb.Append(String.Format(" AND A.dept_id>='{0}'", txtDetp_id1.EditValue));
            }
            if (txtDetp_id2.Text != "")
            {
                sb.Append(String.Format(" AND A.dept_id<='{0}'", txtDetp_id2.EditValue));
            }
            if (txtCreate_date1.Text != "")
            {
                sb.Append(String.Format(" AND A.create_date>='{0}'", txtCreate_date1.Text));
            }
            if (txtCreate_date2.Text != "")
            {
                txtCreate_date2.EditValue = txtCreate_date2.DateTime.AddDays(1);
                sb.Append(String.Format(" AND A.create_date<'{0}'", txtCreate_date2.Text));
            }
            if (txtCheck_date1.Text != "")
            {
                sb.Append(String.Format(" AND A.check_date>='{0}'", txtCheck_date1.Text));
            }
            if (txtCheck_date2.Text != "")               
            {
                txtCheck_date2.EditValue = txtCheck_date2.DateTime.AddDays(1);
                sb.Append(String.Format(" AND A.check_date<'{0}'", txtCheck_date2.Text));
            }
            if (cbxState.SelectedIndex == 1)
            {
                sb.Append(String.Format(" AND A.state='{0}'", "0"));
            }
            if (cbxState.SelectedIndex == 2)
            {
                sb.Append(String.Format(" AND A.state='{0}'", "1"));
            }

            DataTable dtBomFind = clsPublicOfCF01.GetDataTable(sb.ToString());
            dgvBomFind.DataSource = dtBomFind;
            if (dgvBomFind.RowCount == 0)
            {
                MessageBox.Show("沒有滿足條件的資料!","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void BTNOK_Click(object sender, EventArgs e)
        {
            if (dgvBomFind.RowCount == 0)
            {
                frmBom._query_bom_id = "";
            }
            else
            {
                if (_bom_id == "")
                {
                    MessageBox.Show("請選擇要查找的BOM.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmBom._query_bom_id = _bom_id;
            }
            Close();
        }

        private void dgvBomFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBomFind.RowCount > 0)
            {
                _bom_id = dgvBomFind.CurrentRow.Cells["id"].Value.ToString();
            }           
        } 

        private void txtDetp_id1_Click(object sender, EventArgs e)
        {
            txtDetp_id1.SelectAll();
        }

        private void txtDetp_id2_Click(object sender, EventArgs e)
        {
            txtDetp_id2.SelectAll();
        }

       
     
    }
}
