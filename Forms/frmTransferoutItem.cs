using cf01.CLS;
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
    public partial class frmTransferoutItem : Form
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtFind = new DataTable();
        public string goodsId = "";
        public string goodsName = "";
        private string moId = "";  
        private Point clickPoint;
        private bool selected_flag = false;

        public frmTransferoutItem(string mo_id, Point p)
        {
            InitializeComponent();
            moId = mo_id;            
            clickPoint = p;
        }

        private void frmTransferoutItem_Load(object sender, EventArgs e)
        {           
            this.Location = new Point(clickPoint.X-180, clickPoint.Y+5);//定義窗體起始位置
            string sql_f= string.Format(
            @"SELECT b.goods_id,c.name As goods_name
            FROM so_order_details a with(nolock),so_order_bom b with(nolock),it_goods c
            WHERE a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And a.sequence_id=b.upper_sequence And
             b.within_code=c.within_code And b.goods_id=c.id And a.within_code='0000' And a.mo_id='{0}' And 
             a.state Not In('2','V') ORDER BY b.primary_key Desc,b.goods_id", moId);
            dtFind = clsConErp.GetDataTable(sql_f);
            dgv1.DataSource = dtFind;
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            //int rowIndex = dgv1.CurrentRow.Index;
            int rowIndex = dgv1.CurrentCell.RowIndex;
            if (rowIndex < 0)
            {
                goodsId = "";
                goodsName = "";
                return;
            }
            goodsId = dgv1.Rows[rowIndex].Cells["goods_id"].Value.ToString();
            goodsName = dgv1.Rows[rowIndex].Cells["goods_name"].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            goodsId = "";
            goodsName = "";
            selected_flag = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dgv1.Rows.Count>0)
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                if (rowIndex < 0)
                {
                    goodsId = "";
                    goodsName = "";
                    selected_flag = false;
                    return;
                }
                if(rowIndex >= 0)
                {
                    goodsId = dgv1.Rows[rowIndex].Cells["goods_id"].Value.ToString();
                    goodsName = dgv1.Rows[rowIndex].Cells["goods_name"].Value.ToString();
                    selected_flag = true;
                }                
                this.Close();
            }
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0)
            {
                return;
            }
            goodsId = dgv1.Rows[e.RowIndex].Cells["goods_id"].Value.ToString();
            goodsName = dgv1.Rows[e.RowIndex].Cells["goods_name"].Value.ToString();
            selected_flag = true;
            this.Close();
        }

        private void frmTransferoutItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!selected_flag)
            {
                //相當選中貨品但沒有點確認，或直接點退出按鈕，或者直接點窗體頂部工具欄的關閉按鈕
                goodsId = "";
                goodsName = "";
            }
        }
    }
}
