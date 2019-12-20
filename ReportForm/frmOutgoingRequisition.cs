using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace cf01.ReportForm
{
    public partial class frmOutgoingRequisition : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        public DataTable dtOutRequest = new DataTable();

        public frmOutgoingRequisition()
        {
            InitializeComponent();
        }

        private void frmOutgoingRequisition_Load(object sender, EventArgs e)
        {
            this.dgvDetials.AutoGenerateColumns = false;
            rdbRequest.Checked = true;
            txtDate2.Text = DateTime.Now.ToString("yyyy/MM/dd 00:00:00");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtDept.Text == "")
            {
                MessageBox.Show("請輸入部門");
                return;
            }

            if (clsValidRule.CheckDateIsEmpty(this.txtDate1.Text) == true)
            {
                MessageBox.Show("日期格式不正確");
                txtDate1.Focus();
                return;
            }

            if (clsValidRule.CheckDateIsEmpty(this.txtDate2.Text) == true)
            {
                MessageBox.Show("日期格式不正確");
                txtDate2.Focus();
                return;
            }

            GetOutRequest(txtDept.Text, txtDate1.Text, txtDate2.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateWeb("https://www.v2ex.com/?tab=apple");
        }

        private void GetOutRequest(string Dept, string Date1, string Date2)
        {
            //SELECT A.mo_id,A.bill_date,B.order_qty,B.prod_qty+isnull(B.obligate_qty,0) AS prod_qty,B.goods_id
            //      ,G.name as goods_name,B.wp_id,B.vendor_id
            //FROM jo_bill_mostly A With(nolock) 
            //inner join jo_bill_goods_details B with(nolock)ON A.within_code =B.within_code AND A.id =B.id AND A.ver=B.ver
            //INNER JOIN op_outpro_goods_details BB ON A.within_code=BB.within_code AND A.mo_id=BB.mo_id AND B.goods_id=BB.goods_id
            //LEFT JOIN op_outpro_mostly AA ON BB.within_code=AA.within_code AND BB.id=AA.id
            //LEFT JOIN it_goods G ON B.within_code=G.within_code AND B.goods_id=G.id

            //WHERE A.within_code ='0000' AND A.state NOT IN ('2','V') AND B.next_wp_id <>'702' AND (B.prod_qty + isnull(B.obligate_qty,0))>0    
            //     AND B.wp_id ='501' AND A.bill_date >= '2015/04/20 00:00:00' AND A.bill_date<='2015/05/02 00:00:00' 
            //     AND AA.state<>'1'


            string strSql = @"SELECT A.mo_id,A.bill_date,B.order_qty,B.prod_qty+isnull(B.obligate_qty,0) AS prod_qty,B.goods_id
                                    ,G.name as goods_name,B.wp_id,B.vendor_id
                            FROM jo_bill_mostly A With(nolock) 
                            inner join jo_bill_goods_details B with(nolock)ON A.within_code =B.within_code AND A.id =B.id AND A.ver=B.ver
                            INNER JOIN op_outpro_goods_details BB ON A.within_code=BB.within_code AND A.mo_id=BB.mo_id AND B.goods_id=BB.goods_id
                            LEFT JOIN op_outpro_mostly AA ON BB.within_code=AA.within_code AND BB.id=AA.id
                            LEFT JOIN it_goods G ON B.within_code=G.within_code AND B.goods_id=G.id
                            WHERE A.within_code ='0000' AND A.state NOT IN ('2','V') AND next_wp_id <>'702' AND (B.prod_qty + isnull(B.obligate_qty,0))>0    
                                    AND B.wp_id ='" + Dept + "' AND A.bill_date >= '" + Date1 + "' AND A.bill_date<='" + Date2 + "' ";
            if (rdbNotRequest.Checked == true)
                strSql += " AND AA.state='1'";
            if (rdbRequest.Checked == true)
                strSql += " AND AA.state<>'1'";
            //strSql += " SELECT '1' FROM op_outpro_mostly AA with(nolock) " +
            //          " INNER JOIN op_outpro_goods_details BB ON AA.within_code=BB.within_code AND AA.id=BB.id " +
            //          " WHERE AA.within_code ='0000' AND AA.state ='1' AND BB.mo_id =A.mo_id AND BB.goods_id =BB.goods_id ) ";

            dtOutRequest = clsConErp.GetDataTable(strSql);

            if (dtOutRequest.Rows.Count > 0)
            {
                dgvDetials.DataSource = dtOutRequest;
                dgvDetials.Refresh();
            }
        }

        private void txtDept_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.txtDate1.Focus();
                    break;
            }
        }

        public string CreateWeb(string url)
        {

            StringBuilder sb = new StringBuilder();
            //抓取网页
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            //读取文件流
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")); //reader.ReadToEnd() 表示取得网页的源码
            //FileStream fs = new FileStream("~/baidu.html", FileMode.OpenOrCreate);
            string strhtml = reader.ReadToEnd();
            //正则匹配网站的图片标签
            string Rxg = @"<img\b[^<]*(?:(?!<\/img>)*)";
            //匹配出图片标签的集合
            MatchCollection mc = Regex.Matches(strhtml, Rxg);
            for (int i = 0; i < mc.Count; i++)
            {
                sb.Append(mc[i]);

            }
            //返回图片标签HTML输出
            return sb.ToString();
        }

    }
}
