using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using cf01.Reports;
using cf01.CLS;
using cf01.MDL;

namespace cf01.Forms
{
    public partial class frmPuVendConfGoods : Form
    {
        private string user_id = DBUtility._user_id;
        public frmPuVendConfGoods()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            databind();
        }
        private void databind()
        {
            string strSql = "";
            string date1 = mktAct_out_date1.Text;
            string date2 = mktAct_out_date2.Text;
            string rec_state = cmbRec_state.SelectedValue.ToString();
            //只顯示CF已發貨的記錄：rec_state='01'
            strSql = "Select a.doc_id,a.doc_date,b.seq,b.prd_mo,b.prd_item,c.name AS item_cdesc,b.out_qty,b.out_weg,b.act_out_date,b.out_pack" +
                ",b.vend_act_rec_qty,b.vend_act_rec_weg,b.vend_act_rec_pack,b.vend_act_rec_date,b.rec_state" +
                ",d.flag_desc,b.req_f_date,b.do_color,b.remark,b.plate_remark,a.vend_id,b.req_return_hk,b.arrange_flag,b.order_date,b.production_remark" +
                " From pu_deliver_head a" +
                " Inner Join pu_deliver_details b ON a.comp_type=b.comp_type And a.doc_id=b.doc_id" +
                " left join geo_it_goods c on b.prd_item=c.id COLLATE  Chinese_Taiwan_Stroke_CI_AS" +
                " Left Join bs_flag_desc d ON b.rec_state=d.flag_id" +
                " Where a.comp_type='DG'AND d.doc_type='OP' AND b.rec_type='01' ";
            if (cmbRec_state.SelectedIndex > 0)
                strSql += " AND b.rec_state ='" + rec_state + "'";
            if (date1 != "" && date2 != "")
            {
                date2 = Convert.ToDateTime(date2).AddDays(1).ToString("yyyy/MM/dd");
                strSql += " AND b.act_out_date >= '" + date1 + "' AND b.act_out_date < '" + date2 + "'";
            }
            if (cmbVend_id.SelectedIndex > 0)
            {
                strSql += " AND a.vend_id='" + cmbVend_id.SelectedValue + "'";
            }
            if (txtDoc_id1.Text.Trim() != "" && txtDoc_id2.Text.Trim() != "")
            {
                strSql += " AND a.doc_id >= '" + txtDoc_id1.Text.Trim() + "' AND a.doc_id <= '" + txtDoc_id2.Text.Trim() + "'";
            }
            if (txtPrd_mo1.Text.Trim() != "" && txtPrd_mo2.Text.Trim() != "")
            {
                strSql += " AND b.prd_mo >= '" + txtPrd_mo1.Text.Trim() + "' AND b.prd_mo <= '" + txtPrd_mo2.Text.Trim() + "'";
            }
            if (rdbNoArrange.Checked == true)//只顯示未排期的記錄
                strSql += " AND b.arrange_flag=''";
            if (rdbIsArrange.Checked == true)//只顯示已排期的記錄
                strSql += " AND b.arrange_flag='Y'";
            strSql += " Order by a.vend_id,a.doc_id,a.doc_date";


            DataTable tbDetails = clsPublicOfCF01.GetDataTable(strSql);
            if (cmbRec_state.SelectedIndex != 2)//如果是提取未錄入單據的，就要設置默認值
                SetTbDefaultValue(tbDetails);
            dgvDetails.DataSource = tbDetails;



        }

        private void SetTbDefaultValue(DataTable tbPu)
        {
            for (int i = 0; i < tbPu.Rows.Count; i++)
            {
                tbPu.Rows[i]["vend_act_rec_weg"] = tbPu.Rows[i]["out_weg"].ToString();
                tbPu.Rows[i]["vend_act_rec_qty"] = tbPu.Rows[i]["out_qty"].ToString();
                tbPu.Rows[i]["vend_act_rec_pack"] = tbPu.Rows[i]["out_pack"].ToString();
                //tbPu.Rows[i]["vend_act_rec_date"] = System.DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void frmPu_VendConfGoods_Load(object sender, EventArgs e)
        {
            

            InitControler();
        }

        private void mktAct_out_date1_Leave(object sender, EventArgs e)
        {
            mktAct_out_date2.Text = mktAct_out_date1.Text;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                Boolean blSetValue = true;
                if (chkSelectAll.Checked)
                {
                    blSetValue = true;//Select All                    
                }
                else
                {
                    blSetValue = false;
                }
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    dgvDetails.Rows[i].Cells["colChkRec"].Value = blSetValue;
                }

            }
        }


        private void InitControler()
        {
            string strSql = "select flag_id,flag_desc from bs_flag_desc Where doc_type='OP' AND jx_state_flag='Y' order by flag_id ";
            DataTable tbState = clsPublicOfCF01.GetDataTable(strSql);

            cmbRec_state.DataSource = tbState;
            cmbRec_state.DisplayMember = "flag_desc";
            cmbRec_state.ValueMember = "flag_id";
            cmbRec_state.SelectedIndex = 1;

            strSql = "Select vend_id From bs_vendor_info";
            DataTable tbVend_id = clsPublicOfCF01.GetDataTable(strSql);
            cmbVend_id.DataSource = tbVend_id;
            cmbVend_id.DisplayMember = "vend_id";
            cmbVend_id.ValueMember = "vend_id";

            dgvDetails.AutoGenerateColumns = false;
            mktAct_out_date1.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            mktAct_out_date2.Text = mktAct_out_date1.Text;
            mktVend_act_rec_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtPrd_dep.Text = "J07";
            mtkArrange_date.Text = mktVend_act_rec_date.Text;
        }


        private void SaveProcess(int save_type)
        {



            if (save_type == 1 && cmbRec_state.SelectedIndex != 1)
            {
                MessageBox.Show("只能對送貨途中的貨品進行收貨!");
                return;
            }
            if (save_type == 2 && cmbRec_state.SelectedIndex != 2)
            {
                MessageBox.Show("只能對已收貨的貨品進行取消!");
                return;
            }
            if (ValidData() != "")
                return;
            StringBuilder query = new StringBuilder();
            bool is_save = false;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if ((bool)dgvDetails.Rows[i].Cells["colChkRec"].EditedFormattedValue)
                {
                    if(save_type==2 && dgvDetails.Rows[i].Cells["colArrange_flag"].Value.ToString().Trim() == "Y")
                    {
                        MessageBox.Show("存在一筆已排期的記錄，不能取消收貨!");
                        is_save = false;
                        break;
                    }
                    is_save = true;//設置為儲存狀態
                    string doc_id = dgvDetails.Rows[i].Cells[10].Value.ToString();
                    string seq = dgvDetails.Rows[i].Cells[11].Value.ToString();
                    string rec_state = "02";//設定為供應商已收貨狀態
                    int vend_act_rec_qty = Convert.ToInt32(dgvDetails.Rows[i].Cells[4].Value);
                    double vend_act_rec_weg = Convert.ToDouble(dgvDetails.Rows[i].Cells[5].Value);
                    int vend_act_rec_pack = Convert.ToInt32(dgvDetails.Rows[i].Cells[6].Value);
                    string vend_act_rec_date = mktVend_act_rec_date.Text;// dgvDetails.Rows[i].Cells[7].Value.ToString();
                    if (save_type == 2)
                    {
                        rec_state = "01";//設置為在送貨途中
                        vend_act_rec_qty = 0 - vend_act_rec_qty;
                        vend_act_rec_weg = 0 - vend_act_rec_weg;
                        vend_act_rec_pack = 0 - vend_act_rec_pack;
                        vend_act_rec_date = "";
                    }
                    query.Append("UPDATE [pu_deliver_details] SET [vend_act_rec_qty]=[vend_act_rec_qty]+")
                        .Append(vend_act_rec_qty)
                        .Append(",[vend_act_rec_weg]=[vend_act_rec_weg]+")
                        .Append(vend_act_rec_weg)
                        .Append(",[vend_act_rec_pack]=[vend_act_rec_pack]+")
                        .Append(vend_act_rec_pack)
                        .Append(",[vend_act_rec_date]=")
                        .Append("'" + vend_act_rec_date + "'")
                        .Append(",[rec_state]=")
                        .Append("'" + rec_state + "'")
                        .Append(",[vend_amusr]=")
                        .Append("'" + user_id + "'")
                        .Append(",[vend_amtim]=")
                        .Append("GETDATE()")
                        .Append(" WHERE [doc_id]='")
                        .Append(doc_id)
                        .Append("' AND [seq]='")
                        .Append(seq)
                        .Append("';\n");
                }
            }
            if (is_save == true)
            {
                if (clsPublicOfCF01.ExecuteSqlUpdateQuery(query) == true)
                {
                    chkSelectAll.Checked = false;
                    //Response.Write("<script>alert('儲存成功!');<" + "/" + "script>");
                    MessageBox.Show("儲存成功!");
                }

                else
                    MessageBox.Show("儲存失敗!");

            }
            databind();
        }

        private string ValidData()
        {

            string result = "";
            for (int i = 0; i < dgvDetails.Rows.Count; i++)//
            {
                string ci = (i + 1).ToString();
                if ((bool)dgvDetails.Rows[i].Cells["colChkRec"].EditedFormattedValue)
                {
                    if (dgvDetails.Rows[i].Cells[4].Value.ToString() == "")
                    {
                        result = "第" + ci + "行的收貨重量不能為空!";
                        break;
                    }
                    if (!clsValidRule.IsNumeric(dgvDetails.Rows[i].Cells[4].Value.ToString()))
                    {
                        result = "第" + ci + "行的收貨重量不正確!";
                        break;
                    }
                    if (dgvDetails.Rows[i].Cells[5].Value.ToString() == "")
                    {
                        result = "第" + ci + "行的收貨數量不能為空!";
                        break;
                    }
                    if (!clsValidRule.IsNumeric(dgvDetails.Rows[i].Cells[5].Value.ToString()))
                    {
                        result = "第" + ci + "行的收貨數量不正確!";
                        break;
                    }
                    if (dgvDetails.Rows[i].Cells[6].Value.ToString() == "")
                    {
                        result = "第" + ci + "行的收貨包數不能為空!";
                        break;
                    }
                    if (!clsValidRule.IsNumeric(dgvDetails.Rows[i].Cells[6].Value.ToString()))
                    {
                        result = "第" + ci + "行的收貨包數不正確!";
                        break;
                    }
                }
            }
            if (result != "")
                MessageBox.Show(result);


            return result;
        }

        private void btnExpToExcel_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                //**********************
                DvExportExcel(); //数据处理
                //**********************
            }
        }

        private void DvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                for (int i = 0; i < dgvDetails.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvDetails.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容
                string col_value;
                for (int rowNo = 0; rowNo < dgvDetails.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvDetails.ColumnCount; columnNo++)
                    {

                        if (columnNo > 0)
                        {
                            tempstr += "\t";
                        }
                        col_value = "";
                        if (dgvDetails.Rows[rowNo].Cells[columnNo].Value != null)
                        {
                            if (columnNo == 7 || columnNo == 8 || columnNo == 13 || columnNo == 17)
                                col_value = "=\"" + dgvDetails.Rows[rowNo].Cells[columnNo].Value + "\"";//日期轉換為字符
                            else
                                col_value = dgvDetails.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        }
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            if (!clsValidRule.CheckDateFormat(mktVend_act_rec_date.Text))
            {
                MessageBox.Show("收貨日期不正確！");
                return;
            }
            SaveProcess(1);
        }

        private void btnUnConf_Click(object sender, EventArgs e)
        {
            SaveProcess(2);
        }


        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
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



        private void btnArrange_Click(object sender, EventArgs e)
        {
            if (cmbRec_state.SelectedIndex != 2)
            {
                MessageBox.Show("只能對已收貨的記錄進行排期！");
                cmbRec_state.Focus();
                return;
            }
            if (!clsValidRule.CheckDateFormat(mtkArrange_date.Text))
            {
                MessageBox.Show("排期日期不正確！");
                return;
            }
            List<product_arrange> listDetail = new List<product_arrange>();
            
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                
                if ((bool)dgvDetails.Rows[i].Cells["colChkRec"].EditedFormattedValue
                    && dgvDetails.Rows[i].Cells["colArrange_flag"].Value.ToString().Trim() == "")
                {
                    product_arrange objModel = new product_arrange();
                    objModel.prd_dep = txtPrd_dep.Text;
                    objModel.prd_mo = dgvDetails.Rows[i].Cells["colPrd_mo"].Value.ToString();
                    objModel.prd_item = dgvDetails.Rows[i].Cells["colPrd_item"].Value.ToString();
                    objModel.wf_doc_id = dgvDetails.Rows[i].Cells["colDoc_id"].Value.ToString();
                    objModel.wf_seq = dgvDetails.Rows[i].Cells["colSeq"].Value.ToString();
                    objModel.prd_seq = "";
                    objModel.prd_ver = 0;
                    objModel.to_dep = "";
                    objModel.arrange_date = mtkArrange_date.Text;
                    objModel.arrange_machine = "";
                    objModel.arrange_qty = (dgvDetails.Rows[i].Cells["colVend_act_rec_qty"].Value.ToString() != "" ? Convert.ToInt32(dgvDetails.Rows[i].Cells["colVend_act_rec_qty"].Value.ToString()) : 0);
                    objModel.rec_status = "0";//這個是正常標識，如果排程取消的，則為1
                    objModel.mo_urgent = "00";//急單狀態默認為未定
                    objModel.prd_status = "00";//完成狀態默認為待安排
                    objModel.cust_o_date = dgvDetails.Rows[i].Cells["colOrder_date"].Value.ToString();
                    objModel.req_f_date = dgvDetails.Rows[i].Cells["colReq_f_date"].Value.ToString();

                    objModel.estimated_date = "";//預計完成日期
                    objModel.estimated_time = "";//預計完成時間
                    objModel.estimated_start_date = "";//預計開始日期
                    objModel.estimated_start_time = "";//預計開始時間;
                    objModel.req_time = 0;//完成所需小時
                    objModel.crusr = user_id;
                    listDetail.Add(objModel);
                }
            }
            if (listDetail.Count > 0)
            {
                int Result = clsProductionSchedule.InsertPrdocutionArrange(listDetail);

                if (Result > 0)
                {
                    MessageBox.Show("排期儲存成功!");
                }
                else
                    MessageBox.Show("排期儲存失敗!"); ;

            }
            else
            {
                MessageBox.Show("沒有要儲存的記錄!");
                return;
            }
            databind();
        }
    }
}
