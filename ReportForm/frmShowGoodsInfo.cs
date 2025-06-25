using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using cf01.Forms;
using System.IO;


namespace cf01.ReportForm
{
    public partial class frmShowGoodsInfo : Form
    {
        private string remote_db = DBUtility.remote_db;
        private string within_code = DBUtility.within_code;
        private string image_path = DBUtility.imagePath;
        private clsPublicOfGEO clsGeo = new clsPublicOfGEO();
        public frmShowGoodsInfo()
        {
            InitializeComponent();
        }
        private void frmShowGoodsInfo_Load(object sender, EventArgs e)
        {
            picArt.SizeMode = PictureBoxSizeMode.StretchImage; // 适应控件大小////
        }

        private void btnFindGoods_Click(object sender, EventArgs e)
        {
            FindData();
        }
        private void FindData()
        {
            picArt.Image = null;
            string strSql = "";
            string goods_id = "";
            string mat = txtMat.Text.Trim();
            string prdType = txtPrdType.Text.Trim();
            string art = txtArt.Text.Trim();
            string size = txtSize.Text.Trim();
            string color = txtColor.Text.Trim();
            goods_id = mat + prdType + art + size + color;

            strSql += "Select a.id As goods_id,a.name As goods_name,b.sequence_id,b.picture_name" +
                " Into #tb_goods01 "+
                " From it_goods a" +
                " Left Join cd_pattern_details b On a.within_code=b.within_code And a.blueprint_id=b.id " +
                " Where a.within_code='" + within_code + "'";
            if(goods_id.Length==18)
            {
                strSql += " And a.id='" + goods_id + "'";
            }
            else
            {
                if (mat != "")
                    strSql += " And Substring(a.id,1,2)='" + mat + "'";
                if (prdType != "")
                    strSql += " And Substring(a.id,3,2)='" + prdType + "'";
                if (art != "")
                {
                    if (art.Length == 7)
                        strSql += " And Substring(a.id,5,7)='" + art + "'";
                    else
                        strSql += " And a.id Like '%" + art + "%'";
                }
                if (size != "")
                    strSql += " And Substring(a.id,12,3)='" + size + "'";
                if (color != "")
                    strSql += " And Substring(a.id,15,4)='" + color + "'";
            }
            strSql += " Select a.* " +
                " From #tb_goods01 a" +
                " Inner Join (Select goods_id,Min(sequence_id) As sequence_id From #tb_goods01 Group By goods_id ) b" +
                " On a.goods_id=b.goods_id And a.sequence_id=b.sequence_id ";
            strSql += " Drop Table #tb_goods01 ";
            DataTable dtGoods = clsGeo.ExecuteSqlReturnDataTable(strSql);
            gcGoods.DataSource = dtGoods;
            if (dtGoods.Rows.Count == 0)
                MessageBox.Show("沒有找到物料編號記錄!");
        }
        private void btnFfindPlan_Click(object sender, EventArgs e)
        {
            FindPlan();
        }
        private void FindPlan()
        {
            string strSql = "";
            string mo_id = txtMo.Text.Trim();
            string goods_id = "";
            //查詢生產流程記錄
            goods_id = txtGoodsId.Text.Trim();
            strSql = "Select a.mo_id,b.sequence_id,b.goods_id,c.name As goods_name,b.wp_id,b.next_wp_id,Convert(Int,b.prod_qty) As prod_qty" +
                ",Convert(Varchar(20),b.t_complete_date,111) As t_complete_date" +
                " ,Convert(Int,b.c_qty_ok) As c_qty_ok,Convert(Varchar(20),b.f_complete_date,120) As f_complete_date" +
                " ,d.sequence_id As art_id,d.picture_name" +
                " Into #tb_wp01 " +
                " From jo_bill_mostly a" +
                " Left Join jo_bill_goods_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver" +
                " Left Join it_goods c On b.within_code=c.within_code And b.goods_id=c.id" +
                " Left Join cd_pattern_details d On c.within_code=d.within_code And c.blueprint_id=d.id " +
                " Where a.within_code='0000' ";

            if (goods_id.Length == 18)
            {
                strSql += " And b.goods_id='" + goods_id + "'";
            }
            else
            {
                strSql += " And b.goods_id Like '%" + goods_id + "%'";
            }
            if (mo_id != "")
                strSql += " And a.mo_id='" + mo_id + "'";
            strSql += " Select a.* " +
                " From #tb_wp01 a" +
                " Inner Join (Select mo_id,sequence_id,Min(art_id) As art_id From #tb_wp01 Group By mo_id,sequence_id ) b" +
                " On a.mo_id=b.mo_id And a.sequence_id=b.sequence_id And a.art_id=b.art_id " +
                " Order By a.mo_id,a.sequence_id";
            strSql += " Drop Table #tb_wp01 ";
            DataTable dtPlan = clsGeo.ExecuteSqlReturnDataTable(strSql);
            gcPlanDetails.DataSource = dtPlan;
            if (dtPlan.Rows.Count == 0)
                MessageBox.Show("沒有找到物料編號的流程記錄!");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvGoods_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow row = gvGoods.GetFocusedDataRow();
            txtGoodsId.Text = row["goods_id"].ToString().Trim();
            string image_name = image_path + row["picture_name"].ToString().Trim();
            ShowArtPpic(row["picture_name"].ToString().Trim());

        }

        private void gvPlanDetails_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow row = gvPlanDetails.GetFocusedDataRow();
            ShowArtPpic(row["picture_name"].ToString().Trim());
        }
        private void ShowArtPpic(string pic_name)
        {
            string image_name = image_path + pic_name.Trim();
            //string path = @"C:\Images\sample.jpg";
            if (File.Exists(image_name))
            {
                picArt.Image = Image.FromFile(image_name);
            }
            else
            {
                picArt.Image = null;
            }
        }
    }
}
