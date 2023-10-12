using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.Reports;
using DevExpress.XtraReports.UI;
using cf01.Forms;
using System.Threading;

namespace cf01.ReportForm
{
    public partial class frmCustLable : Form
    {
        DataTable dtReport = new DataTable();
        clsPublicOfGEO clsgeo = new clsPublicOfGEO();
        public frmCustLable()
        {
            InitializeComponent();
        }

        private void frmCustLable_Load(object sender, EventArgs e)
        {
            txtDept.Text = "106";
            cmbFormat.SelectedIndex = 1;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtDept.Text == "")
            {
                MessageBox.Show("查詢條件：部門或批準日期不可以為空");
                return;
            }
            string strSql =
                @"SELECT CONVERT(bit,0) as flag_select,A.mo_id,B.goods_id,C.goods_name,Convert(int,B.prod_qty) as prod_qty,Convert(int,B.c_qty_ok) as c_qty_ok,
                1 AS total_page,C.color_name as color2,C.size_id,D.name ,E.customer_goods,E.customer_goods_name,E.customer_color_id,E.contract_cid,E.table_head, 
                A.check_date, C.goods_name_eng,C.color_name_eng,D.english_name as customer_name_eng,
                ISNULL(D.analysis_codes_1,'') AS analysis_codes_1,
                dbo.Fn_get_picture_name('0000',B.goods_id,'1') AS picture_name,ISNULL(G.is_company_logo,'') AS is_company_logo,H.packing_remark8 AS print_eng_text,
                H.packing_remark as remark1,'' as barcode,dbo.fn_z_convert_sat_sun(GETDATE()) as print_date
                FROM jo_bill_mostly A with(nolock)
                INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code and A.id=B.id and A.ver=B.ver 
                INNER JOIN (Select a1.within_code,a1.id as goods_id,a1.name as goods_name,a1.english_name as goods_name_eng,a2.name as color_name,
                             a2.english_name as color_name_eng ,a3.name as size_id
			                FROM it_goods a1 left join cd_color a2 on a1.within_code=a2.within_code and a1.color=a2.id  
			                left join cd_size a3 on a1.within_code=a3.within_code and a1.size_id=a3.id
                            ) C ON B.within_code=C.within_code and B.goods_id=C.goods_id 
                INNER JOIN it_customer D with(nolock) ON A.within_code=D.within_code AND A.customer_id=D.id 
                INNER JOIN so_order_details E with(nolock) ON A.within_code=E.within_code and A.mo_id=E.mo_id 
                INNER JOIN so_order_bom F with(nolock) ON E.within_code=F.within_code and E.id=F.id and E.ver=F.ver and E.sequence_id=F.upper_sequence                  
                LEFT JOIN cd_brand G with (nolock) ON E.within_code = G.within_code AND E.brand_id = G.id 
                INNER JOIN so_order_special_info H with (nolock) ON E.within_code = H.within_code AND E.id = H.id AND E.ver = H.ver AND E.sequence_id = H.upper_sequence
                WHERE A.within_code='0000'";
            if(txtMo_id1.Text!="")
               strSql += string.Format(" and A.mo_id >='{0}'",txtMo_id1.Text);
            if(txtMo_id2.Text!="")
               strSql += string.Format(" and A.mo_id <='{0}'",txtMo_id2.Text);
            if(txtCheck_date1.Text!="")
               strSql += string.Format(" and A.check_date >='{0}'",txtCheck_date1.Text);
            if(txtCheck_date2.Text!="")
               strSql += string.Format(" and A.check_date <='{0}'",txtCheck_date2.Text);
            if(txtDept.Text!="")
               strSql += string.Format(" and B.wp_id ='{0}'",txtDept.Text);
            strSql += " and B.next_wp_id='601' and B.goods_id=F.goods_id and B.goods_id not like 'F0%' and F.primary_key ='1'";

            if (cmbFormat.SelectedIndex == 1)
            {
                 strSql += " and isnull(B.prod_qty,0) > isnull(B.c_qty_ok,0)";//未完成
            }

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            dtReport = clsgeo.GetDataTable(strSql);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            dgvDetails.DataSource = dtReport;
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("沒有符合查找條件的數據!");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                MessageBox.Show("請先查找出數據!");
                return;
            }

            DataTable dt = new DataTable();
            DataRow[] ary_drs = dtReport.Select("flag_select=true");
            if (ary_drs.Length > 0)
            {               
                dt = dtReport.Clone();
                int total_page = 1;
                foreach (DataRow dr in ary_drs)
                {
                    if(string.IsNullOrEmpty(dr["total_page"].ToString()))
                    {
                        dr["total_page"] = 1;
                    }
                    total_page = int.Parse(dr["total_page"].ToString());
                    if(total_page<=0)
                    {
                        MessageBox.Show("注意,列印份數不可為0!");
                        break;
                    }
                    for (int i=1;i<=int.Parse(dr["total_page"].ToString());i++)
                    {
                        dt.ImportRow(dr);
                    }                    
                }
            }
            else
            {
                MessageBox.Show("請首先選擇要列印的數據!");
                return;
            }

            xrPackChanged_CustA4 oRepot = new xrPackChanged_CustA4() { DataSource = dt };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            oRepot.ShowPreview();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtCheck_date1_Leave(object sender, EventArgs e)
        {
            txtCheck_date2.EditValue = txtCheck_date1.EditValue;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void Select_All(bool _flag)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    dtReport.Rows[i]["flag_select"] = _flag;
                }
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked)
            {
                Select_All(true);
            }
            else
            {
                Select_All(false);
            }    
        }
    }
}
