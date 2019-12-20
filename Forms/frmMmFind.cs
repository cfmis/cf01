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
    public partial class frmMmFind : Form
    {
        public static string str_language = "0";
        private string mm_select = "";
        string goods_type;
        public frmMmFind(string _type)
        {            
            InitializeComponent();
            //bs_mat_master中的字段modality用于區分物料的類型:
            //0 自制
            //1 委外
            //2 採購
            //3 成品(F0...)
            //參數_type = "0",允許選擇自制(0),委外(1)的貨品
            //參數_type = "1",允許選擇自制(0),委外(1),採購(2)的貨品
            goods_type = _type;
            if (_type == "1")
            {
                chkPur.Enabled = true;
                chkPur.Visible = true;
            }
            else
            {
                chkPur.Enabled = false;
                chkPur.Visible = false;
            }

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
        }

        private void frmMmFind_Load(object sender, EventArgs e)
        {
            DataTable dtDept = clsPublicOfCF01.GetDataTable(@"SELECT dep_id,(dep_id +'[' + dep_cdesc+']') AS dep_cdesc FROM dbo.bs_dep with(nolock) WHERE dep_group='DG'");
            DataRow dr1 = dtDept.NewRow(); //插一空行
            dr1["dep_id"] = "";
            dtDept.Rows.InsertAt(dr1, 0);
            txtDetp_id.Properties.DataSource = dtDept;
            txtDetp_id.Properties.ValueMember = "dep_id";
            txtDetp_id.Properties.DisplayMember = "dep_cdesc";
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (txtDetp_id.Text == "" && txtPrd_item1.Text =="" && txtPrd_item2.Text =="" && txtMat_code.Text == "" &&
                 txtPrd_code.Text == "" && txtArt_code.Text == "" && txtSize_code.Text == "" && txtClr_code.Text == "" 
                 && txtGoods_name.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            StringBuilder sb = new StringBuilder(
            @"SELECT A.prd_item,A.item_cdesc,A.item_unit,A.prd_dep,B.dep_cdesc,C.clr_cdesc,C.clr_make,
              CASE WHEN A.modality='0' THEN '自制'
                   WHEN A.modality='1' THEN '委外'
                   WHEN A.modality='2' THEN '採購'
                   WHEN A.modality='3' THEN '成品'
              END AS modality
              FROM dbo.bs_mat_master A with(nolock) 
              LEFT JOIN dbo.bs_dep B with(nolock) ON A.prd_dep = B.dep_id
              LEFT JOIN dbo.bs_color C with(nolock) ON A.clr_code = C.clr_code
              WHERE 1>0 ");
            if (txtPrd_item1.Text != "")
            {                
                sb.Append(String.Format(" AND A.prd_item >= '{0}'", txtPrd_item1.Text));
            }
            if (txtPrd_item2.Text != "")
            {                
                sb.Append(String.Format(" AND A.prd_item <= '{0}'", txtPrd_item2.Text));
            }
            
            if (txtMat_code.Text != "")
            {
                sb.Append(String.Format(" AND A.mat_code ='{0}'", txtMat_code.Text));
            }
            if (txtPrd_code.Text != "")
            {
                sb.Append(String.Format(" AND A.prd_code ='{0}'", txtPrd_code.Text));
            }
            if (txtArt_code.Text != "")
            {
                sb.Append(String.Format(" AND A.art_code ='{0}'", txtArt_code.Text));
            }
            if (txtSize_code.Text != "")
            {
                sb.Append(String.Format(" AND A.size_code ='{0}'", txtSize_code.Text));
            }
            if (txtClr_code.Text != "")
            {
                sb.Append(String.Format(" AND A.clr_code ='{0}'", txtClr_code.Text));
            }
            if (txtGoods_name.Text != "")
            {                
                sb.Append(String.Format(" AND A.item_cdesc LIKE '%{0}%'", txtGoods_name.Text));
            }
            if (txtDetp_id.Text != "")
            {
                sb.Append(String.Format(" AND A.prd_dep = '{0}'", txtDetp_id.EditValue));
            }
            if (goods_type == "0")
            {
                sb.Append(" AND A.modality < '2'"); //採購和成品除外[即只可選自制(0),委外(1)的貨品]
            }
            if (goods_type == "1")
            {
                if (chkPur.Enabled && chkPur.Checked)
                {
                    sb.Append(" AND A.modality = '2'"); //採購(2)
                }
                else
                {
                    sb.Append(" AND A.modality < '3'"); //成品除外[即只可選自制(0),委外(1),採購(2)的貨品]
                }
            }

            DataTable dtMmFind = clsPublicOfCF01.GetDataTable(sb.ToString());
            dgvMmFind.DataSource = dtMmFind;
            if (dgvMmFind.RowCount == 0)
            {
                MessageBox.Show("沒有滿足條件的資料!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTNOK_Click(object sender, EventArgs e)
        {
            if (dgvMmFind.RowCount == 0)
            {
                frmBom._MM = "";
            }
            else
            {
                if (mm_select == "")
                {
                    MessageBox.Show("請選擇要查找的貨品編號.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmBom._MM = mm_select;
            }
            Close();
        }

        private void dgvMmFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMmFind.RowCount > 0)
            {
                mm_select = dgvMmFind.CurrentRow.Cells["prd_item"].Value.ToString();
            }    
        }

        private void txtPrd_item1_Leave(object sender, EventArgs e)
        {
            txtPrd_item2.Text = txtPrd_item1.Text;
        }

        private void txtDetp_id_Click(object sender, EventArgs e)
        {
            txtDetp_id.SelectAll();
        }
    }
}
