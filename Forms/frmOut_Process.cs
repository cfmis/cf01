using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.Reports;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.ModuleClass;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmOut_Process : Form
    {
       private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
       private DataTable dtPlate = new DataTable();
       private DataTable dtMo_Data = new DataTable();
        public frmOut_Process()
        {
            InitializeComponent();
        }

        private void frmOut_Process_Load(object sender, EventArgs e)
        {
            DataTable dtVendor = clsBaseData.Get_Plate_Vendor();
            DataRow dr0 = dtVendor.NewRow(); //插一空行        
            dtVendor.Rows.InsertAt(dr0, 0);
            txtVendor_id1.Properties.DataSource = dtVendor;
            txtVendor_id1.Properties.ValueMember = "id";
            txtVendor_id1.Properties.DisplayMember = "cdesc";

            txtVendor_id2.Properties.DataSource = dtVendor;
            txtVendor_id2.Properties.ValueMember = "id";
            txtVendor_id2.Properties.DisplayMember = "cdesc";

            txtVendor.Properties.DataSource = dtVendor;
            txtVendor.Properties.ValueMember = "id";
            txtVendor.Properties.DisplayMember = "cdesc";

            txtIssue_date.EditValue = DateTime.Now;
            //txtIssue_date.EditValue = DateTime.Now.AddDays(-1);            
            
        }
     
        //private void BTNFIND_Click(object sender, EventArgs e)
        //{
        //    txtVendor_id2.Focus();
        //    if (txtDat1.Text == "" && txtDat2.Text == "" && txtID1.Text == "" && txtID2.Text == "" && txtVendor_id1.Text == "" && txtVendor_id2.Text == "")
        //    {
        //        MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    LoadData();
        //}

        private void LoadData()
        {
            string strDat1 = txtDat1.Text;
            string strDat2 = txtDat2.Text;
            //if (strDat1 != "" && strDat2 != "")
            //{
            //    if (strDat1 == strDat2)
            //    {                    
            //        strDat2 = txtDat2.DateTime.AddDays(1).ToString();
            //        strDat2 = strDat2.Substring(0, 10);
            //    }
            //}

            SqlParameter[] paras = new SqlParameter[]
            {       
                    new SqlParameter("@within_code", "0000"),
                    new SqlParameter("@order_date", strDat1),
                    new SqlParameter("@order_date_end", strDat2),
                    new SqlParameter("@id", txtID1.Text),
                    new SqlParameter("@id_end", txtID2.Text),
                    new SqlParameter("@vendor_id", txtVendor_id1.EditValue),
                    new SqlParameter("@vendor_id_end", txtVendor_id2.EditValue)
			};
            dtPlate = clsConErp.ExecuteProcedureReturnTable("z_rpt_out_process_out", paras);            
            //--
            if (dtPlate.Rows.Count > 0)
            {
                //最低消費頁數重復的處理
                string temp_mo_id2 = dtPlate.Rows[0]["mo_id2"].ToString();
                //string id = dtPlate.Rows[0]["id"].ToString();
                //string clr= dtPlate.Rows[0]["clr"].ToString();
                //int unite_qty = int.Parse(dtPlate.Rows[0]["unite_qty"].ToString());                
                for (int i = 0; i < dtPlate.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        if (dtPlate.Rows[i]["fl_by"].ToString() == "501")
                        {
                            if (dtPlate.Rows[i]["mo_id2"].ToString() == temp_mo_id2)
                            {
                                temp_mo_id2 = dtPlate.Rows[i]["mo_id2"].ToString();//臨時值
                                dtPlate.Rows[i]["mo_id2"] = "";
                            }
                            else
                            {
                                temp_mo_id2 = dtPlate.Rows[i]["mo_id2"].ToString();
                            }
                        }

                        //處理噴油合并數量一張單據中只顯示一次
                        //if (unite_qty > 0)
                        //{
                        //    if (dtPlate.Rows[i]["id"].ToString() == id &&
                        //        int.Parse(dtPlate.Rows[i]["unite_qty"].ToString()) == unite_qty &&
                        //        dtPlate.Rows[i]["clr"].ToString() == clr
                        //    )
                        //    {
                        //        dtPlate.Rows[i]["unite_qty"] = 0;
                        //    }
                        //}
                        //id = dtPlate.Rows[i]["id"].ToString();
                        //clr = dtPlate.Rows[i]["clr"].ToString();
                        //unite_qty = int.Parse(dtPlate.Rows[i]["unite_qty"].ToString());
                    }
                }

                //共用報表
                DataRow[] drs = dtPlate.Select("id2=''");
                if (drs.Length > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dtPlate.Clone();
                    foreach (DataRow dr in drs)
                    {
                        dt.ImportRow(dr);
                    }
                    //加載報表
                    xrOut_process_out mMyRepot = new xrOut_process_out(chkDisplayPrice.Checked, chkPlateRemark.Checked,chkColorQty.Checked) 
                    { 
                        DataSource = dt 
                    };
                    mMyRepot.CreateDocument();
                    mMyRepot.PrintingSystem.ShowMarginsWarning = false;
                    mMyRepot.ShowPreviewDialog();
                }
                
                drs = dtPlate.Select("id2<>''");
                if (drs.Length > 0)
                {
                    DataTable dtPlate_510 = new DataTable();
                    dtPlate_510 = dtPlate.Clone();
                    foreach (DataRow dr in drs)
                    {
                        dtPlate_510.ImportRow(dr);
                    }
                    xrOut_process_out_510 mMyRepot = new xrOut_process_out_510(chkDisplayPrice.Checked,chkColorQty.Checked) 
                    { 
                        DataSource = dtPlate_510 
                    };
                    mMyRepot.CreateDocument();
                    mMyRepot.PrintingSystem.ShowMarginsWarning = false;
                    mMyRepot.ShowPreviewDialog();                    
                }                
                
            }
            else
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            SetObjValue.ClearObjValue(Controls, "1");
            dtPlate.Clear();
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat1.Text;
            if (string.IsNullOrEmpty(strDate))
            {
                return;
            }

            if (CheckDate(sender))
            {
                txtDat2.EditValue = txtDat1.EditValue;               
            }
        }


        private static bool CheckDate(object obj)
        {
            string strdate = ((DateEdit)obj).Text;
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {              
                MessageBox.Show("輸入的日期有誤!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
            return Flag;
        }

        private void txtDat2_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat2.Text;
            if (!string.IsNullOrEmpty(strDate))
            {
                CheckDate(sender);                 
            }
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {
            txtID2.Text = txtID1.Text;
            if (txtID1.Text.Substring(1, 3) != "510")
            {
                chkColorQty.Checked = false;
            }
            else
            {
                chkColorQty.Checked = true;
            }
        }

        private void txtVendor_id1_Leave(object sender, EventArgs e)
        {
            txtVendor_id2.EditValue  = txtVendor_id1.EditValue;
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            txtVendor_id2.Focus();
            if (txtDat1.Text == "" && txtDat2.Text == "" && txtID1.Text == "" && txtID2.Text == "" && txtVendor_id1.Text == "" && txtVendor_id2.Text == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoadData(); 
        }

        private void btnMo_Find_Click(object sender, EventArgs e)
        {
            string strMo = txtMo_id.Text;
            string strVendor = txtVendor.EditValue.ToString();
            string strIssue_date = txtIssue_date.Text;
            if (string.IsNullOrEmpty(strMo) && string.IsNullOrEmpty(strVendor) && string.IsNullOrEmpty(strIssue_date))
            {
                MessageBox.Show("查詢條件不可爲空!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            StringBuilder strSB = new StringBuilder(
            @"SELECT A.id,A.vendor_id,A.issue_date,SUBSTRING(B.sequence_id,1,4) AS sequence_id,B.mo_id,B.goods_id,
                C.name AS vendor_name,D.name as goods_name,
	            ROUND(CONVERT(float,B.prod_qty),0) AS prod_qty,
	            ROUND(CONVERT(float,B.sec_qty),2) AS sec_qty,
	            E.check_flag,
                CASE WHEN E.check_flag='A' THEN '已點貨' 
                     WHEN E.check_flag='B' THEN '分批點貨'
                     WHEN E.check_flag='C' THEN '暫停'
                     WHEN ISNULL(E.check_flag,'')='' THEN '待點貨' 
                     ELSE '' 
                END AS check_flag_name,dbo.Fn_get_picture_name('0000',B.goods_id,'out') AS picture_name           
            FROM dbo.op_outpro_out_mostly A with(nolock) 
                INNER JOIN dbo.op_outpro_out_displace B with(nolock) ON A.within_code=B.within_code AND A.id=B.id
            LEFT OUTER JOIN DGSQL2.dgcf_pad.dbo.jo_mat_check_out2 E with(nolock)
                    ON B.within_code=E.within_code AND B.id=E.id AND B.sequence_id=E.sequence_id
                LEFT JOIN it_vendor C with(nolock) ON A.within_code = C.within_code AND A.vendor_id = C.id
                LEFT JOIN it_goods D with(nolock) ON B.within_code = D.within_code AND B.goods_id = D.id
            WHERE A.within_code='0000' AND A.state<>'2'");
                
            if (!string.IsNullOrEmpty(strVendor))
            {
                strSB.Append(String.Format(" AND A.vendor_id='{0}'", strVendor));
            }               
            if (!string.IsNullOrEmpty(strIssue_date))
            {
                strSB.Append(String.Format(" AND A.issue_date='{0}'", strIssue_date));
            } 
            if(!string.IsNullOrEmpty(strMo))
            {
                strSB.Append(String.Format(" AND B.mo_id='{0}'", txtMo_id.Text));
            }
            strSB.Append(" ORDER BY A.id,B.sequence_id");
            dtMo_Data = clsConErp.GetDataTable(strSB.ToString());
            dgvDetails.DataSource = dtMo_Data;

        }

        private void dgvDetails_DoubleClick(object sender, EventArgs e)
        {
            if (dtMo_Data.Rows.Count == 0)
            {
                return;
            }

            SetObjValue.ClearObjValue(panel1.Controls, "1");
            dtPlate.Clear();

            txtID1.Text = dgvDetails.CurrentRow.Cells["id"].Value.ToString();
            txtID2.Text = txtID1.Text;
            if (txtID1.Text.Substring(1, 3) != "510")
            {
                chkColorQty.Checked = false;
            }
            else
            {
                chkColorQty.Checked = true;
            }
        }

        private void txtVendor_Click(object sender, EventArgs e)
        {
            txtVendor.SelectAll();
        }

        private void txtVendor_id1_Click(object sender, EventArgs e)
        {
            txtVendor_id1.SelectAll();
        }

        private void txtVendor_id2_Click(object sender, EventArgs e)
        {
            txtVendor_id2.SelectAll();
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.CurrentRow == null)
            {
                return;
            }
            string art_file = dgvDetails.CurrentRow.Cells["picture_name"].Value.ToString();
            if (File.Exists(art_file))
            {
                picArt.Image = Image.FromFile(art_file);
            }
            else
                picArt.Image = null;
        }

        private void frmOut_Process_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConErp = null;
            dtPlate = null;
            dtMo_Data = null;
        }   

     
    }
}
