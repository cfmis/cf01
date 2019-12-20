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
using System.IO;
using System.Threading;
using DevExpress.XtraEditors;
using cf01.Forms;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmTakeMoSample : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private string within_code = DBUtility.within_code;
        private DataTable dtDetails = new DataTable();
        public frmTakeMoSample()
        {
            InitializeComponent();
        }

        private void frmTakeMoSample_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            mktDat1.Text = System.DateTime.Now.ToString("yyyy/MM/dd") + "00:00";
            mktDat2.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:ss");

            DataTable dtLoc = new DataTable();
            string strSql = @" select * from int09 where int9loc>='8' and int9loc<'9' ";
            dtLoc = clsPublicOfPad.GetDataTable(strSql);
            dtLoc.Rows.Add();
            dtLoc.DefaultView.Sort="int9loc";

            cmbLoc.DataSource = dtLoc;
            cmbLoc.DisplayMember = "int9loc";
            cmbLoc.ValueMember = "int9loc";

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //查找記錄
        private void startFindData()
        {
            if (clsValidRule.CheckDateIsEmpty(this.mktDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mktDat2.Text) == false)
            {
                if (clsValidRule.CheckDateTimeFormat(this.mktDat1.Text) == false || clsValidRule.CheckDateTimeFormat(this.mktDat2.Text) == false)
                {
                    MessageBox.Show("批準日期格式不正確!");
                    this.mktDat1.Focus();
                    return;
                }
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            
            //findData();

            loadDetail(1);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            startFindData();
            
        }

        private DataTable loadDetail(int rows)
        {
            //string id = dgvHead.Rows[rows].Cells["colHid"].Value.ToString();
            string strSql = "";
            //strSql = "Select aa.id,Convert(varchar(20),aa.issues_date,111) AS issues_date,aa.group_number,aa.remark,aa.create_by" +
            //    ",Convert(varchar(20),aa.check_date,111) AS check_date,aa.check_by" +
            //    ",a.sequence_id,a.mo_id,a.goods_id,b.name As goods_name,Convert(INT,a.issues_qty) As issues_qty" +
            //    ",a.issues_unit,Convert(numeric(18,2),a.sec_qty) As sec_qty,a.sec_unit,a.ii_location,a.obligate_mo_id,Convert(INT,c.rate) As rate " +
            //    ",dbo.Fn_z_get_wh_location(a.goods_id,a.ii_location) As carton_code" +
            //    ",Convert(INT,a.issues_qty) As act_qty,Convert(numeric(18,2),a.sec_qty) As act_weg,a.qc_result" +
            //    ",d.name As size_name,e.name As color_name" +
            //    ",f.contract_cid,f.customer_goods,f.customer_color_id" +
            //    " From so_issues_mostly aa " +
            //    " Inner Join so_issues_details a On aa.within_code=a.within_code And aa.id=a.id" +
            //    " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id" +
            //    " Left Join it_coding c On a.within_code=c.within_code And a.goods_id=c.id" +
            //    " Left Join cd_size d On b.within_code=d.within_code And b.size_id=d.id" +
            //    " Left Join cd_color e On b.within_code=e.within_code And b.color=e.id" +
            //    " Left Join so_order_details f On a.within_code=f.within_code And a.mo_id=f.mo_id" +
            //    " Where a.within_code='" + within_code + "' And aa.type='ADN' ";


            strSql = "Select aa.id,Convert(varchar(20),aa.issues_date,111) AS issues_date,aa.group_number,aa.remark,aa.create_by" +
                ",Convert(varchar(20),aa.check_date,111) AS check_date,aa.check_by" +
                ",a.sequence_id,a.mo_id,a.goods_id,b.name As goods_name,Convert(INT,a.issues_qty) As issues_qty" +
                ",a.issues_unit,Convert(numeric(18,2),a.sec_qty) As sec_qty,a.sec_unit,a.ii_location,a.obligate_mo_id " +
                ",dbo.Fn_z_get_wh_location(a.goods_id,a.ii_location) As carton_code" +
                ",Convert(INT,a.issues_qty) As act_qty,Convert(numeric(18,2),a.sec_qty) As act_weg,a.qc_result" +
                ",d.name As size_name,e.name As color_name" +
                ",f.contract_cid,f.customer_goods,f.customer_color_id" +
                " From so_issues_mostly aa " +
                " Inner Join so_issues_details a On aa.within_code=a.within_code And aa.id=a.id" +
                " Left Join it_goods b On a.within_code=b.within_code And a.goods_id=b.id" +
                " Left Join cd_size d On b.within_code=d.within_code And b.size_id=d.id" +
                " Left Join cd_color e On b.within_code=e.within_code And b.color=e.id" +
                " Left Join so_order_details f On a.within_code=f.within_code And a.mo_id=f.mo_id" +
                " Where a.within_code='" + within_code + "' And aa.type='ADN' ";

            if (cmbLoc.SelectedIndex >0)
                strSql += " And a.ii_location='" + cmbLoc.SelectedValue + "'";
            if (clsValidRule.CheckDateTimeFormat(this.mktDat1.Text) && clsValidRule.CheckDateTimeFormat(this.mktDat2.Text))
            {
                strSql += " And aa.update_date>='" + mktDat1.Text + "' And aa.update_date<='" + mktDat2.Text + "'";
            }
            if (txtId1.Text != "" && txtId2.Text != "")
                strSql += " And aa.id>='" + txtId1.Text + "' And aa.id<='" + txtId2.Text + "'";
            if (txtGroup.Text != "")
                strSql += " And aa.group_number='" + txtGroup.Text.Trim() + "'";
            if (chkIsPrint.Checked == false)
                strSql += " And a.qc_result is null";
            strSql += " Order By aa.id,a.ii_location,a.goods_id,a.sequence_id";
            dtDetails = clsConErp.GetDataTable(strSql);
            //for (int i = 0; i < dtDetails.Rows.Count; i++)
            //{
            //    if (dtDetails.Rows[i]["issues_qty"].ToString() != "" && dtDetails.Rows[i]["rate"].ToString() != "")
            //    {
            //        if (Convert.ToInt32(dtDetails.Rows[i]["rate"]) != 0)
            //        {
            //            dtDetails.Rows[i]["act_weg"] = Math.Round(Convert.ToSingle(dtDetails.Rows[i]["issues_qty"]) / Convert.ToSingle(dtDetails.Rows[i]["rate"]), 1);
            //        }
            //    }
            //    if (dtDetails.Rows[i]["act_weg"] != null || Convert.ToSingle(dtDetails.Rows[i]["act_weg"]) == 0)
            //        dtDetails.Rows[i]["act_weg"] = 0.01;
                
            //}

            dgvDetails.DataSource = dtDetails;
            dgvDetails.Refresh();
            if (chkAutoRefresh.Checked == false)
            {
                chkSelectAll.Checked = true;
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                    dgvDetails.Rows[i].Cells["colDchk"].Value = true;
            }
            return dtDetails;
        }


        private void mktDat1_Leave(object sender, EventArgs e)
        {
            //mktDat2.Text = mktDat1.Text;
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
        }

        

        private DataTable setPrint()
        {
            DataTable dtSample = new DataTable();//提取明細表記錄
            dtSample = dtDetails.Clone();
            dtSample.Columns.Add("picture_name", typeof(string));
            dtSample.Columns.Add("BarCode", typeof(string));
            //if (rpt_type == 2)//如果是列印標識卡
            //{
            //    dtSample.Columns.Add("contract_cid", typeof(string));
            //    dtSample.Columns.Add("customer_goods", typeof(string));
            //    dtSample.Columns.Add("customer_color_id", typeof(string));
            //}
            int j = 0;
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["colDchk"].Value != null && (bool)dgvDetails.Rows[i].Cells["colDchk"].Value == true)
                {
                    ////暫時取消不要替換手動輸入的數量
                    //for (int j = 0; j < dgvDetails.Rows.Count; j++)
                    //{
                    //    if (dtSample.Rows[i]["sequence_id"].ToString() == dgvDetails.Rows[j].Cells["colDseq"].Value.ToString())
                    //    {
                    //        dtSample.Rows[i]["act_qty"] = (dgvDetails.Rows[j].Cells["colDaqty"].Value.ToString() != "" ? Convert.ToInt32(dgvDetails.Rows[j].Cells["colDaqty"].Value) : 0);
                    //        string weg;
                    //        //weg = dgvDetails.Rows[j].Cells["colDaweg"].Value.ToString();
                    //        //if (dgvDetails.Rows[j].Cells["colDaweg"].Value != null)
                    //        dtSample.Rows[i]["act_weg"] = (dgvDetails.Rows[j].Cells["colDaweg"].Value.ToString() != "" ? Math.Round(Convert.ToSingle(dgvDetails.Rows[j].Cells["colDaweg"].Value), 2) : 0);
                    //        break;
                    //    }
                    //}
                    DataRow row = dtDetails.Rows[i];
                    dtSample.ImportRow(row);
                    j = dtSample.Rows.Count - 1;
                    dtSample.Rows[j]["sequence_id"] = dtSample.Rows[j]["sequence_id"].ToString().Substring(2, 2);
                    DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(dtSample.Rows[j]["goods_id"].ToString());
                    dtSample.Rows[j]["picture_name"] = dtArt.Rows[0]["picture_name"].ToString();
                    dtSample.Rows[j]["BarCode"] = clsMo_for_jx.ReturnBarCode(dtSample.Rows[j]["id"].ToString().Substring(3, 10) + dtSample.Rows[j]["sequence_id"].ToString());
                }
            }
            return dtSample;
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            startFindData();
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked == true)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            txtGroup.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            printReport(1);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            
        }
        private void btnPreView_Click(object sender, EventArgs e)
        {
            txtGroup.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            printReport(2);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {

            txtGroup.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            printLabel(1);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void btnViewLabel_Click(object sender, EventArgs e)
        {
            txtGroup.Focus();
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            printLabel(2);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        
        
        
        private void printReport(int print_type)
        {
            DataTable dtSample = setPrint();
            xrTakeMoSample_A4 oRepot = new xrTakeMoSample_A4() { DataSource = dtSample };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            if (print_type == 2)
                oRepot.ShowPreview();
            else
                oRepot.PrintDialog();
        }

        private void printLabel(int print_type)
        {
            DataTable dtSample = setPrint();
            xrTakeMoSample_Card oRepot = new xrTakeMoSample_Card() { DataSource = dtSample };
            oRepot.CreateDocument();
            oRepot.PrintingSystem.ShowMarginsWarning = false;
            if (print_type == 2)
                oRepot.ShowPreview();
            else
                oRepot.PrintDialog();//.Print();
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                dgvDetails.Rows[i].Cells["colDchk"].Value = chkSelectAll.Checked;
            }
        }

        private void btnSetPrint_Click(object sender, EventArgs e)
        {
            txtGroup.Focus();
            int result = 0;
            string strSql = "";
            string p_flag = "Y";
            string id = "";
            string seq = "";
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["colDchk"].Value != null && (bool)dgvDetails.Rows[i].Cells["colDchk"].Value == true)
                {
                    id = dgvDetails.Rows[i].Cells["colDid"].Value.ToString();
                    seq = dgvDetails.Rows[i].Cells["colDseq"].Value.ToString();
                    strSql += string.Format(@"UPDATE so_issues_details Set qc_result='{0}' Where within_code='{1}' And id='{2}' And sequence_id='{3}'"
                        , p_flag, within_code, id, seq);
                }

            }
            if (strSql != "")
                result = clsConErp.ExecuteSqlUpdate(strSql);
            if (result > 0)
            {
                startFindData();
                chkSelectAll.Checked = false;
                MessageBox.Show("列印設置成功!");
            }
            else
                MessageBox.Show("列印設置失敗!");
        }

        private void txtId1_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtId1.Text == "")
            {
                if (mktDat1.Text.Replace(" ", "") != "//")
                {
                    txtId1.Text = "ADN" + mktDat1.Text.Substring(2, 2) + mktDat1.Text.Substring(5, 2);
                    txtId1.SelectionStart = 7;
                }
                else
                {
                    txtId1.Text = "ADN";
                    txtId1.SelectionStart = 3;
                }
            }
        }

        private void mktDat2_MouseDown(object sender, MouseEventArgs e)
        {
            mktDat2.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:ss");
        }


    }
}
