using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ReportForm;
using cf01.CLS;
using cf01.Reports;
using cf01.Forms;
using System.Threading;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmPackChanged : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataSet dsPackChange = new DataSet();
        DataTable dtDetails = new DataTable();
        DataTable dtFullCheck = new DataTable();
        DataTable dtMO = new DataTable();
        DataTable dtItems = new DataTable();
        string strMo, strSeq, id_type, strGoods_id;

        public frmPackChanged()
        {
            InitializeComponent();
            TatableInit();
        }

        private void frmPackChanged_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            cmbReport.Text = "包裝轉交單";
        }

        private void TatableInit()
        {
            dtDetails.Columns.Add("pkey", typeof(string));
            dtDetails.Columns.Add("goods_id", typeof(string));
            dtDetails.Columns.Add("name", typeof(string));
            dtDetails.Columns.Add("order_qty", typeof(Int32));
            dtDetails.Columns.Add("department", typeof(string));

            dtFullCheck.Columns.Add("id", typeof(string));
            dtFullCheck.Columns.Add("mo_id", typeof(string));
            dtFullCheck.Columns.Add("w_mo_id", typeof(string));
            dtFullCheck.Columns.Add("contract_cid", typeof(string));
            dtFullCheck.Columns.Add("table_head", typeof(string));
            dtFullCheck.Columns.Add("customer_name_eng", typeof(string));
            dtFullCheck.Columns.Add("customer_goods", typeof(string));
            dtFullCheck.Columns.Add("customer_color_id", typeof(string));
            dtFullCheck.Columns.Add("brand_desc", typeof(string));
            dtFullCheck.Columns.Add("order_qty1", typeof(Int32));
            dtFullCheck.Columns.Add("goods_unit", typeof(string));
            dtFullCheck.Columns.Add("f_goods_id", typeof(string));
            dtFullCheck.Columns.Add("f_goods_name", typeof(string));
            dtFullCheck.Columns.Add("qc_result", typeof(string));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {            
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (string.IsNullOrEmpty(txtBarCode.Text))
                    {
                        return;
                    }
                    string str = txtBarCode.Text;                  
                    string is_by_mo,str1, str2, strId;                    
                    id_type = "";
                    strMo = "";
                    str1 = str.Substring(0, 2); //移交單號DT,LT開頭
                    str2 = str.Substring(0,3);
                    bool isbymo = chkByMo.Checked;
                    if (chkByCard.Checked)//如果是按工序卡掃描，則當作按頁數逐個掃描看待，重設isbymo的值
                    {
                        isbymo = true;
                    }
                    //======================================
                    if (!isbymo)
                    {
                        //按整張單據掃描
                        is_by_mo = "N";
                        if (str1 == "DT" || str1 == "LT" || str2 == "DAA")
                        {
                            //T:移交單;D:倉庫發料
                            id_type = (str1 == "T") ? "T" : "D";
                            str = txtBarCode.Text;
                            txtID.Text = str.Substring(0, str.Length - 4);
                            txtBarCode.Text = "";
                            txtMO.Text = "";
                            cmbItems.Items.Clear();
                            cmbItems.Text = "";
                        }
                        else
                        {
                            if (txtBarCode.Text.Trim().Length == 13)
                            {
                                //start 2024/11/19 allen
                                //工序卡的條碼
                                chkByCard.Checked = true;
                                chkIsDisplayKey.Checked = false;
                                is_by_mo = "Y";
                                txtID.Text = "";
                                id_type = "";  //沒有移交單或倉庫發料
                                //從生產計劃中找頁數資料
                                strMo = str.Substring(0, 9);
                                strSeq = string.Format("00{0}h", str.Substring(11, 2));
                                string strSql_f1 = string.Format(
                                @"SELECT A.mo_id,B.goods_id
                                FROM jo_bill_mostly A with(nolock) 
	                            INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code =B.within_code AND A.id=B.id AND A.ver=B.ver
                                WHERE A.within_code='0000' AND A.mo_id='{0}' AND A.state<>'2' AND B.sequence_id='{1}'", strMo, strSeq);                                
                                dtMO = clsConErp.GetDataTable(strSql_f1);
                                if (dtMO.Rows.Count == 0)
                                {
                                    dgvDetails.DataSource = null;
                                    txtBarCode.Text = "";
                                    return;
                                }
                                strMo = dtMO.Rows[0]["mo_id"].ToString();
                                strGoods_id = dtMO.Rows[0]["goods_id"].ToString();
                                //訂單中找Sales BOM
                                string strSql_f3 = string.Format(
                                @"SELECT C.goods_id,C.primary_key 
                                FROM so_order_manage A with(nolock) 
	                            INNER JOIN so_order_details B with(nolock) ON A.within_code=B.within_code And A.id=B.id And A.ver=B.ver
	                            INNER JOIN so_order_bom C with(nolock) 
	                                ON B.within_code=C.within_code And B.id=C.id And B.ver =C.ver And B.sequence_id =C.upper_sequence 
                                WHERE A.within_code='0000' And A.state Not IN('2','V') And B.mo_id='{0}' ORDER BY C.primary_key DESC,C.goods_id", strMo);
                                dtItems = clsConErp.GetDataTable(strSql_f3);
                                Fill_Combox(dtItems);
                                if (!chkIsDisplayKey.Checked)
                                {
                                    cmbItems.Text = strGoods_id; //如果不默認顯示主件為False,則顯示條碼中對應的貨品
                                }
                                //--end 2024/11/19
                            }
                            else
                            {
                                MessageBox.Show("單據編號不正確！請返回檢查");
                                return;
                            }                                                      
                        }
                    }
                    else
                    {
                        //按頁數掃描
                        is_by_mo = "Y";
                        str = txtBarCode.Text;
                        txtID.Text = "";
                        if (!chkByCard.Checked) //非工序卡,即按移交單或轉發料單上的頁數逐行掃描
                        {                           
                            strId = str.Substring(0, str.Length - 4);
                            strSeq = str.Substring(str.Length - 4, 4) + "h";
                            txtMO.Text = "";
                            //移交單中找頁數資料
                            string strSql_f1 = string.Format(
                            @"SELECT B.mo_id,B.goods_id
                            FROM jo_materiel_con_mostly A with(nolock) 
	                            INNER JOIN jo_materiel_con_details B with(nolock) ON A.within_code =B.within_code AND A.id=B.id
                            WHERE A.within_code='0000' AND A.id='{0}' AND A.state<>'2' AND B.sequence_id='{1}'", strId, strSeq);
                            //倉庫發料單中找頁數資料
                            string strSql_f2 = string.Format(
                            @"SELECT B.mo_id,B.goods_id
                            FROM st_inventory_mostly A with(nolock) 
	                            INNER JOIN st_i_subordination B with(nolock) ON A.within_code =B.within_code AND A.id=B.id
                            WHERE A.within_code='0000' AND A.id='{0}' AND A.state<>'2' AND B.sequence_id='{1}'", strId, strSeq);
                           
                            if ((str1 == "DT"|| str1=="LT") && str.Substring(0, 2) != "TW")
                            {
                                //移交單
                                id_type = "T";  //移交單
                                dtMO = clsConErp.GetDataTable(strSql_f1);
                            }
                            else
                            {
                                if (str2 == "DAA")
                                {
                                    //倉庫發料
                                    id_type = "D";
                                    dtMO = clsConErp.GetDataTable(strSql_f2);
                                }
                                else
                                {
                                    MessageBox.Show("單據編號不正確,請返回檢查!");
                                    txtBarCode.Text = "";
                                    txtBarCode.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //按工序卡上的條碼掃描
                            //從生產計劃中找頁數資料
                            id_type = "";  //沒有移交單或倉庫發料
                            strMo = str.Substring(0, 9);
                            strSeq = string.Format("00{0}h", str.Substring(11, 2));
                            string strSql_f1 = string.Format(
                            @"SELECT A.mo_id,B.goods_id
                            FROM jo_bill_mostly A with(nolock) 
	                            INNER JOIN jo_bill_goods_details B with(nolock) ON A.within_code =B.within_code AND A.id=B.id AND A.ver=B.ver
                            WHERE A.within_code='0000' AND A.mo_id='{0}' AND A.state<>'2' AND B.sequence_id='{1}'", strMo, strSeq);                            
                            dtMO = clsConErp.GetDataTable(strSql_f1);
                        }
                        if (dtMO.Rows.Count == 0)
                        {
                            dgvDetails.DataSource = null;
                            txtBarCode.Text = "";
                            return;
                        }
                        strMo = dtMO.Rows[0]["mo_id"].ToString();
                        strGoods_id = dtMO.Rows[0]["goods_id"].ToString();
                        //訂單中找Sales BOM
                        string strSql_f3 =
                        string.Format(
                        @"SELECT C.goods_id,C.primary_key 
                        FROM so_order_manage A with(nolock) 
	                    INNER JOIN so_order_details B with(nolock) ON A.within_code=B.within_code And A.id=B.id And A.ver =B.ver
	                    INNER JOIN so_order_bom C with(nolock) 
	                        ON B.within_code=C.within_code and B.id=C.id And B.ver =C.ver And B.sequence_id =C.upper_sequence 
                        WHERE A.within_code='0000' And A.state Not In('2','V') And B.mo_id='{0}' ORDER BY C.primary_key DESC,C.goods_id", strMo);
                        dtItems = clsConErp.GetDataTable(strSql_f3);
                        Fill_Combox(dtItems);
                        if (!chkIsDisplayKey.Checked)
                        {
                            cmbItems.Text = strGoods_id; //如果不默認顯示主件為False,則顯示條碼中對應的貨品
                        }
                    }
                    //=====================================

                    txtMO.Text = strMo;
                    chkmo_print_by_set.Checked = false;

                    if (is_by_mo == "N")
                    {
                        frmProgress wForm = new frmProgress();
                        new Thread((ThreadStart)delegate
                        {
                            wForm.TopMost = true;
                            wForm.ShowDialog();
                        }).Start();
                        Load_Data(is_by_mo, "",id_type, txtID.Text, txtMO.Text, cmbItems.Text);
                        wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                    }
                    else
                    {
                        Load_Data(is_by_mo, "", id_type, txtID.Text, txtMO.Text, cmbItems.Text);
                    }
                    txtBarCode.Text = "";
                    if (dsPackChange.Tables[0].Rows.Count > 0)
                    {
                        if (chkAutoPrint.Checked)
                        {
                            Print("P");
                        }
                    }
                    else
                    {
                        txtBarCode.Text = "";
                        txtMO.Text = "";
                        txtID.Text = "";
                        cmbItems.Items.Clear();                                            
                        return;
                    }
                    txtBarCode.Focus();
                    break;
            }
        }

        private void Load_Data(string pIs_by_mo,string pPrint_Set, string pId_type, string pID, string pMO, string pGoods_id)
        {
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@is_by_mo", pIs_by_mo),
                new SqlParameter("@is_set_print", pPrint_Set),
                new SqlParameter("@id_type", pId_type),
                new SqlParameter("@id", pID),
                new SqlParameter("@mo_id",pMO),
                new SqlParameter("@goods_id", pGoods_id),
            };
            dsPackChange = clsConErp.ExecuteProcedureReturnDataSet("z_rpt_pack_changed", paras, null);
            dsPackChange.Tables[0].TableName = "pack_h";//master table            
            dsPackChange.Tables[1].TableName = "pack_d";//details table     
            dsPackChange.Tables[2].TableName = "temp_list";
            
            //處理Sales BOM,建立與主表的關聯
            dtDetails.Clear();
            string strMo_id, strKey;
            for (int i = 0; i < dsPackChange.Tables["pack_h"].Rows.Count; i++)
            {
                strMo_id = dsPackChange.Tables["pack_h"].Rows[i]["mo_id"].ToString();
                strKey = dsPackChange.Tables["pack_h"].Rows[i]["pkey"].ToString();
                DataRow[] drs = dsPackChange.Tables["pack_d"].Select(string.Format("mo_id='{0}'", strMo_id));                
                foreach (DataRow dr in drs)
                {
                    DataRow rs = dtDetails.NewRow();
                    rs["pkey"] = strKey;
                    rs["goods_id"] = dr["goods_id"].ToString();
                    rs["name"] = dr["name"].ToString();
                    rs["order_qty"] = dr["order_qty"];
                    rs["department"] = dr["department"].ToString();
                    dtDetails.Rows.Add(rs);
                }
            }
            //dgvDetails.DataSource = dsPackChange.Tables["pack_h"];
            dgvDetails.DataSource = dsPackChange.Tables["temp_list"];
            txtBarCode.Focus();
        }

        
        private void Fill_Combox(DataTable dt)
        {
            cmbItems.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbItems.Items.Add(dt.Rows[i]["goods_id"].ToString());
                }
                cmbItems.Text = dt.Rows[0]["goods_id"].ToString(); //顯示主件
            }            
        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {           
            txtBarCode.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print("P");
            txtBarCode.Focus();
        }

        private void btnPrintView_Click(object sender, EventArgs e)
        {           
            Print("V");
            txtBarCode.Focus();
        }

        private void Print(string print_type)
        {            
            if (dgvDetails.RowCount > 0)
            {                
                //xrPackChanged oRepot = new xrPackChanged() { DataSource = dsPackChange.Tables[0]};
                if (cmbReport.Text == "包裝轉交單")
                {
                    dtFullCheck.Clear();
                    string flagReport = "";
                    for (int i = 0; i < dsPackChange.Tables["pack_h"].Rows.Count; i++)
                    {
                        flagReport = dsPackChange.Tables["pack_h"].Rows[i]["flag_report"].ToString();
                        if (flagReport == "1")
                        {
                            DataRow rs = dtFullCheck.NewRow();
                            rs["id"] = dsPackChange.Tables["pack_h"].Rows[i]["id"].ToString();
                            rs["mo_id"] = dsPackChange.Tables["pack_h"].Rows[i]["mo_id"].ToString();
                            rs["w_mo_id"] = dsPackChange.Tables["pack_h"].Rows[i]["w_mo_id"].ToString();
                            rs["contract_cid"] = dsPackChange.Tables["pack_h"].Rows[i]["contract_cid"].ToString();
                            rs["table_head"] = dsPackChange.Tables["pack_h"].Rows[i]["table_head"].ToString();
                            rs["customer_name_eng"] = dsPackChange.Tables["pack_h"].Rows[i]["customer_name_eng"].ToString();
                            rs["customer_goods"] = dsPackChange.Tables["pack_h"].Rows[i]["customer_goods"].ToString();
                            rs["customer_color_id"] = dsPackChange.Tables["pack_h"].Rows[i]["customer_color_id"].ToString();
                            rs["brand_desc"] = dsPackChange.Tables["pack_h"].Rows[i]["brand_desc"].ToString();
                            rs["order_qty1"] = Int32.Parse(dsPackChange.Tables["pack_h"].Rows[i]["order_qty1"].ToString());
                            rs["goods_unit"] = dsPackChange.Tables["pack_h"].Rows[i]["goods_unit"].ToString();
                            rs["f_goods_id"] = dsPackChange.Tables["pack_h"].Rows[i]["f_goods_id"].ToString();
                            rs["f_goods_name"] = dsPackChange.Tables["pack_h"].Rows[i]["f_goods_name"].ToString();
                            rs["qc_result"] = dsPackChange.Tables["pack_h"].Rows[i]["qc_result"].ToString() == "True" ? "OK" : "NOT OK";
                            dtFullCheck.Rows.Add(rs);
                        }
                    }
                    using (xrPackChanged mMyReport = new xrPackChanged(dsPackChange, dtDetails))
                    {                        
                        PrintCustom(mMyReport, print_type);
                    }
                    //列印全檢標簽
                    if (dtFullCheck.Rows.Count > 0)
                    {
                        using (xrFullCheck mMyReport = new xrFullCheck() { DataSource = dtFullCheck })
                        {
                            PrintCustom(mMyReport, print_type);
                        }
                    }
                }
                if (cmbReport.Text == "客人標簽")
                {                    
                    using (xrPackChanged_Cust mMyReport = new xrPackChanged_Cust(){DataSource = dsPackChange.Tables[0]})
                    {
                        PrintCustom(mMyReport, print_type);                        
                    }
                }
                if (cmbReport.Text == "成品標識卡")
                {                  
                    using (xrPackChanged_st mMyReport = new xrPackChanged_st() { DataSource = dsPackChange.Tables[0] })
                    {
                        PrintCustom(mMyReport, print_type);                        
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有要列印的數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintCustom(DevExpress.XtraReports.UI.XtraReport oReport,string print_type)
        {
            oReport.CreateDocument();
            oReport.PrintingSystem.ShowMarginsWarning = false;
            if (print_type == "P")
            {
                oReport.Print();
            }
            else
            {
                oReport.ShowPreviewDialog();
            }
        }

        private void chkAutoPrint_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void chkByMo_Click(object sender, EventArgs e)
        {
            chkmo_print_by_set.Checked = false;
            chkByCard.Checked = false;
            txtBarCode.Focus();
        }

        private void chkmo_print_by_set_Click(object sender, EventArgs e)
        {
            chkByMo.Checked = false;
            chkByCard.Checked = false;
            txtBarCode.Focus();
        }

        private void chByCard_Click(object sender, EventArgs e)
        {
            chkByMo.Checked = false;
            chkmo_print_by_set.Checked = false;
            txtBarCode.Focus();
        }

        private void chkIsDisplayKey_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

    
        private void txtID_Leave(object sender, EventArgs e)
        {
            if(txtID.Text!="")
            {               
                string str = txtID.Text;
                string str1, str2, id_type;
                str1 = str.Substring(0, 2);//移交單:DT,LT
                str2 = str.Substring(0, 3);
                id_type = "";
                txtBarCode.Text = "";
                txtMO.Text = "";
                cmbItems.Items.Clear();
                cmbItems.Text = "";
                if (str1 == "DT" || str1 == "LT" || str2 == "DAA")
                {
                    //T:移交單;D:倉庫發料 
                    id_type = (str1 == "DT") ? "T" : "D";                                       
                }
                else
                {
                    MessageBox.Show("單據編號不正確(只限于正常的移交單,倉庫發料)！請返回檢查","提示信息");
                    txtID.Text = "";
                    txtBarCode.Focus();
                    return;
                }

                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();
                Load_Data("N", "", id_type, txtID.Text, txtMO.Text, cmbItems.Text);
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                txtBarCode.Focus();
            }
        }

        private void txtMO_Leave(object sender, EventArgs e)
        {
            if (txtMO.Text != "")
            {
                txtBarCode.Text = "";
                txtID.Text = "";
                cmbItems.Items.Clear();
                string strsql = string.Format(
                @"SELECT C.goods_id,C.primary_key 
                FROM so_order_manage A with(nolock) 
	                INNER JOIN so_order_details B with(nolock) ON A.within_code=B.within_code and A.id=B.id AND A.ver =B.ver
	                INNER JOIN so_order_bom C with(nolock) ON B.within_code=C.within_code and B.id=C.id AND B.ver=C.ver AND B.sequence_id=C.upper_sequence 
                WHERE B.within_code='0000' AND B.mo_id='{0}' AND A.state not in ('2','V') ORDER BY C.primary_key DESC,C.goods_id", txtMO.Text);
                DataTable dtItems = new DataTable();
                dtItems = clsConErp.GetDataTable(strsql);
                if (dtItems.Rows.Count == 0)
                {
                    return;
                }
                Fill_Combox(dtItems);

                string print_by_set = "Y";
                chkmo_print_by_set.Checked = true;

                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();
                Load_Data("Y", print_by_set, "", txtID.Text, txtMO.Text, cmbItems.Text);
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });                

                //2017-08-18一個頁數默認只列印一張客人標識卡加入此代碼默認面件
                if (cmbReport.SelectedIndex == 1)
                {                    
                    Select_goods_item();
                    chkIsDisplayKey.Checked = true;
                }
                //------------

                if (dsPackChange.Tables[0].Rows.Count > 0)
                {
                    if (chkAutoPrint.Checked)
                    {
                        Print("P");
                    }
                }
                txtBarCode.Focus();
            }
        }

        private void cmbItems_Leave(object sender, EventArgs e)
        {
            Select_goods_item();
        }

        private void Select_goods_item()
        {
            chkmo_print_by_set.Checked = false;
            if (txtMO.Text != "" && cmbItems.Text != "")
            {
                Load_Data("Y", "", "", txtID.Text, txtMO.Text, cmbItems.Text);
                if (dsPackChange.Tables[0].Rows.Count > 0)
                {
                    if (chkAutoPrint.Checked)
                    {
                        //Print("P");
                    }
                }
            }
            txtBarCode.Focus();
        }

        private void frmPackChanged_Activated(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void txtMO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回車跳到下一控件                
            if (e.KeyChar == 13 || (txtMO.TextLength - txtMO.SelectionLength) == txtMO.MaxLength - 1)
            {               
                SendKeys.Send("{TAB}");
                //等同于frm.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //等同于(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");               
            }
        }

        private void frmPackChanged_FormClosed(object sender, FormClosedEventArgs e)
        {
            dsPackChange.Dispose();
            dtDetails.Dispose();
        }       

        private void dgvDetails_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        
       
    }
}
