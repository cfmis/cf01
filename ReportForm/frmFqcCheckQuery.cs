using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Threading;

namespace cf01.ReportForm
{
    public partial class frmFqcCheckQuery : Form
    {

        clsPublicOfGEO clsgeo = new clsPublicOfGEO();
        private clsAppPublic clsApp = new clsAppPublic();
        DataTable dtqc = new DataTable();

        public frmFqcCheckQuery()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.panel1.Controls); 
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {

        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, this.panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void frmFqcCheckQuery_Load(object sender, EventArgs e)
        {
            string strsql =
                @"SELECT test_item_id as id,test_item_id+' ('+test_item_name+')' as cdesc,case test_item_type when 'INSIDE' THEN '內部測試' ELSE '外測測試' END as test_type 
                FROM cd_qc_test_item 
                order by test_item_type,test_item_id";            
            DataTable dt= clsgeo.GetDataTable(strsql);
            DataRow row1 = dt.NewRow();//插一空行
            dt.Rows.Add(row1);
            dt.DefaultView.Sort = "id ASC";//排序

            lkeTest_item1.Properties.DataSource = dt;
            lkeTest_item1.Properties.ValueMember = "id";
            lkeTest_item1.Properties.DisplayMember = "cdesc";

            lkeTest_item2.Properties.DataSource = dt;
            lkeTest_item2.Properties.ValueMember = "id";
            lkeTest_item2.Properties.DisplayMember = "cdesc";

        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (txtMt.Text == "" && txtPro.Text == "" && txtArtwork.Text == "" && txtSize.Text == "" && txtColor.Text == "" &
                txtOc1.Text == "" && txtOc2.Text == "" && txtIt_customer1.Text == "" && txtIt_customer2.Text == "" &&
                txtMo_id1.Text == "" && txtMo_id2.Text == "" && txtOder_date1.Text == "" && txtOder_date2.Text == "" &&
                txtQc_date1.Text == "" && txtQc_date2.Text == "" && lkeTest_item1.EditValue.ToString() == "" && lkeTest_item2.EditValue.ToString() == "")
            {
                MessageBox.Show("查找條件不可以為空!", "系統信息");
                return;
            }         
            
            string goods_id, material, product_type, art, size, clr;
            material = txtMt.Text;
            material = material.PadRight(2, '_');
            product_type = txtPro.Text;           
            product_type = product_type.PadRight(2, '_');//右邊填充
            art = txtArtwork.Text;
            art = art.PadRight(7, '_');
            size = txtSize.Text;
            size = size.PadRight(3, '_');
            clr = txtColor.Text;
            clr = clr.PadRight(4, '_');
            goods_id = material + product_type + art + size + clr;
            if (goods_id == "__________________")
                goods_id = "";   
            
            
            string sql =
                @"SELECT A.id,A.ver,CONVERT(varchar(10),A.order_date,120) as order_date,A.it_customer,A.name as customer_name,B.mo_id,B.brand_id,
                C.goods_id,C1.name AS goods_name,D.id as qc_id,CONVERT(varchar(10),D.qc_date,120) as qc_date,D.goods_id as goods_id_qc,D1.name as goods_id_qc_name,
                CASE E.test_item_type WHEN 'INSIDE' THEN '內測' ELSE '外測' END as test_item_type,convert(smallint,substring(E.sequence_id,1,4)) as qc_seq_id,
                E.test_result,E.test_value,E.remark as test_item_remark,F.test_item_name,F.test_requirement,'0' as category
                FROM so_order_manage A with(nolock)
                INNER JOIN so_order_details B with(nolock) ON A.within_code=B.within_code and A.id=B.id and A.ver=B.ver 
                INNER JOIN so_order_bom C with(nolock) ON B.within_code=C.within_code and B.id=C.id and B.ver=C.ver and B.sequence_id=C.upper_sequence AND C.primary_key='1'
                INNER JOIN it_goods C1 with(nolock) ON C.within_code=C1.within_code and C.goods_id=C1.id
                INNER JOIN jo_fqc_mostly D with(nolock) ON B.within_code=D.within_code and B.mo_id=D.mo_id and  D.check_type='OQC'
                INNER JOIN it_goods D1 with(nolock) ON D.within_code=D1.within_code and D.goods_id=D1.id
                INNER JOIN jo_fqc_qc E with(nolock) ON D.within_code=E.within_code and D.id=E.id  
                LEFT JOIN cd_qc_test_item F ON E.within_code=F.within_code and E.test_item_type=F.test_item_type and E.test_item_id=F.test_item_id
                WHERE A.within_code='0000' ";
            
            if (txtOc1.Text != "")
                sql += " and A.id>='" + txtOc1.Text + "'";
            if (txtOc2.Text != "")
                sql += " and A.id<='" + txtOc2.Text + "'";
            if (txtIt_customer1.Text != "")
                sql += " and A.it_customer>='" + txtIt_customer1.Text + "'";
            if (txtIt_customer2.Text != "")
                sql += " and A.it_customer<='" + txtIt_customer2.Text + "'";
            if (txtOder_date1.Text != "")
                sql += " and A.order_date>='" + txtOder_date1.Text + "'";
            if (txtOder_date2.Text != "")
                sql += " and A.order_date<='" + txtOder_date2.Text + "'";
            sql += " and A.state NOT IN('2','V') ";
            if (txtMo_id1.Text != "")
                sql += " and B.mo_id>='" + txtMo_id1.Text + "'";
            if (txtMo_id2.Text != "")
                sql += " and B.mo_id<='" + txtMo_id2.Text + "'";
            if (goods_id != "")
            {
                sql += " and C.goods_id LIKE '%"+goods_id +"%'";
            }
            if (txtQc_date1.Text != "")
                sql += " and D.qc_date>='" + txtQc_date1.Text + "'";
            if (txtQc_date2.Text != "")
                sql += " and D.qc_date<='" + txtQc_date2.Text + "'";
            if (lkeTest_item1.EditValue.ToString() != "")
                sql += " and E.test_item_id>='" + lkeTest_item1.EditValue.ToString() + "'";
            if (lkeTest_item2.EditValue.ToString() != "")
                sql += " and E.test_item_id<='" + lkeTest_item2.EditValue.ToString() + "'";

            sql += " order by A.order_date,A.id,B.mo_id,D.qc_date,D.id,E.sequence_id";

            //=============================================================
            cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            //----------------------------------
            dtqc = clsgeo.GetDataTable(sql);
            if (dtqc.Rows.Count > 0)
            {                
                string temp_oc_no, temp_mo_id, temp_goods_id_oc,temp_category, temp_qc_id, temp_goods_id_qc;
                temp_oc_no = dtqc.Rows[0]["id"].ToString();
                temp_mo_id = dtqc.Rows[0]["mo_id"].ToString();
                temp_goods_id_oc = dtqc.Rows[0]["goods_id"].ToString();
                temp_category = dtqc.Rows[0]["category"].ToString();

                temp_qc_id = dtqc.Rows[0]["qc_id"].ToString();
                temp_goods_id_qc = dtqc.Rows[0]["goods_id_qc"].ToString();
                for (int i = 1; i < dtqc.Rows.Count; i++)
                {
                    if (dtqc.Rows[i]["id"].ToString() == temp_oc_no && 
                        dtqc.Rows[i]["mo_id"].ToString() == temp_mo_id && 
                        dtqc.Rows[i]["goods_id"].ToString() == temp_goods_id_oc) 
                    {
                        dtqc.Rows[i]["id"] = "";
                        dtqc.Rows[i]["ver"] = DBNull.Value;
                        dtqc.Rows[i]["order_date"] = "";
                        dtqc.Rows[i]["it_customer"] = "";
                        dtqc.Rows[i]["customer_name"] = "";
                        dtqc.Rows[i]["mo_id"] = "";
                        dtqc.Rows[i]["brand_id"] = "";
                        dtqc.Rows[i]["goods_id"] = "";
                        dtqc.Rows[i]["goods_name"] = "";
                        dtqc.Rows[i]["category"] = temp_category;
                    }
                    else
                    {
                        temp_oc_no = dtqc.Rows[i]["id"].ToString();
                        temp_mo_id = dtqc.Rows[i]["mo_id"].ToString();
                        temp_goods_id_oc = dtqc.Rows[i]["goods_id"].ToString();
                        if (temp_category == "0")
                            dtqc.Rows[i]["category"] = "1";//以便每個頁數用顏色區分
                        else
                            dtqc.Rows[i]["category"] = "0";
                        temp_category = dtqc.Rows[i]["category"].ToString();
                    }

                    if (dtqc.Rows[i]["qc_id"].ToString() == temp_qc_id && dtqc.Rows[i]["goods_id_qc"].ToString() == temp_goods_id_qc)
                    {
                        dtqc.Rows[i]["qc_id"] = "";
                        dtqc.Rows[i]["qc_date"] = "";
                        dtqc.Rows[i]["goods_id_qc"] = "";
                        dtqc.Rows[i]["goods_id_qc_name"] = "";
                    }
                    else
                    {
                        temp_qc_id=dtqc.Rows[i]["qc_id"].ToString();
                        temp_goods_id_qc = dtqc.Rows[i]["goods_id_qc"].ToString();
                    }
                }
            }
            dgvDetails.DataSource = dtqc;

            //----------------------------------
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            //=============================================================
            

            if (dtqc.Rows.Count == 0)
            {
                txtMo_id1.Text = "";
                MessageBox.Show("沒有找到符合條件的記錄", "系統信息", MessageBoxButtons.OK);
                return;
            }


        }

        private void txtGoods_id_Leave(object sender, EventArgs e)
        {
            if (txtGoods_id.Text != "")
            {
                string goods_id = txtGoods_id.Text;
                if (goods_id.Length == 18)
                {
                    txtMt.Text = goods_id.Substring(0, 2);
                    txtPro.Text = goods_id.Substring(2, 2);
                    txtArtwork.Text = goods_id.Substring(4, 7);
                    txtSize.Text = goods_id.Substring(11, 3);
                    txtColor.Text = goods_id.Substring(14, 4);
                }
            }
        }

        private void frmFqcCheckQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsgeo = null;
            dtqc = null;
            clsApp = null;
        }

        private void txtOc1_Leave(object sender, EventArgs e)
        {
            txtOc2.Text = txtOc1.Text;
        }

        private void txtIt_customer1_Leave(object sender, EventArgs e)
        {
            txtIt_customer2.Text = txtIt_customer1.Text;
        }

        private void txtMo_id1_Leave(object sender, EventArgs e)
        {
            txtMo_id2.Text = txtMo_id1.Text;
        }

        private void txtOder_date1_Leave(object sender, EventArgs e)
        {
            txtOder_date2.Text = txtOder_date1.Text;
        }

        private void txtQc_date1_Leave(object sender, EventArgs e)
        {
            txtQc_date2.Text = txtQc_date1.Text;
        }

        private void lkeTest_item1_Leave(object sender, EventArgs e)
        {
            lkeTest_item2.EditValue = lkeTest_item1.EditValue;
        }

        private void dgvDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                if (dgvDetails.Rows[e.RowIndex].Cells["category"].Value.ToString() == "0")
                    dgvDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dgvDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSteelBlue;//.FromArgb(0xCC, 0xFF, 0xCC);
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("沒有要匯出的數據!", "提示信息");
                return;
            }
            ExpToExcel objXls = new ExpToExcel();
            objXls.ExportExcel(dgvDetails);
            objXls = null;
        }
    }
}
