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
    public partial class frmTransferoutLot : Form
    {
        static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtFind = new DataTable();
        string locationId = "";
        string goodsId = "";
        string moId = "";
        public string lotNo = "";
        Point clickPoint;
        bool flagSelected = false;

        public frmTransferoutLot(string location_id, string goods_id, string mo_id, Point p)
        {
            InitializeComponent();
            locationId = location_id;
            goodsId = goods_id;
            moId = mo_id;            
            clickPoint = p;
        }

        private void frmTransferoutLot_Load(object sender, EventArgs e)
        {           
            this.Location = new Point(clickPoint.X-140, clickPoint.Y+5);//定義窗體起始位置
            dtFind = clsTransferout.GetStockLotNo(locationId, goodsId, moId);
            dgv1.DataSource = dtFind;
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {           
            int rowIndex = dgv1.CurrentCell.RowIndex;
            if (rowIndex < 0)
            {
                lotNo = "";
                return;
            }
            lotNo = dgv1.Rows[rowIndex].Cells["lot_no"].Value.ToString();           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            lotNo = "";           
            flagSelected = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dgv1.Rows.Count>0)
            {
                int rowIndex = dgv1.CurrentCell.RowIndex;
                if (rowIndex < 0)
                {
                    lotNo = "";                    
                    flagSelected = false;
                    return;
                }
                if(rowIndex >= 0)
                {
                    lotNo = dgv1.Rows[rowIndex].Cells["lot_no"].Value.ToString();                   
                    flagSelected = true;
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
            lotNo = dgv1.Rows[e.RowIndex].Cells["lot_no"].Value.ToString();           
            flagSelected = true;
            this.Close();
        }

        private void frmTransferoutLot_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!flagSelected)
            {
                //相當選中貨品但沒有點確認，或直接點退出按鈕，或者直接點窗體頂部工具欄的關閉按鈕
                lotNo = "";               
            }
        }
    }
}
