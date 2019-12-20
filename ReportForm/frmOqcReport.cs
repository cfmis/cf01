using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using cf01.Reports;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{      
    public partial class frmOqcReport : Form
    {
        clsCommonUse commUse = new clsCommonUse();

        public frmOqcReport()
        {
            InitializeComponent();
            this.Tag = "";
            gridView2.BestFitColumns(); //列寬自適應
            gridView1.BestFitColumns(); //列寬自適應            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            string mo_id = txtMo_id.Text.Trim();           
            //新增模式
            if (this.Tag.ToString() == "ADD" && !String.IsNullOrEmpty(mo_id))
            {

                DataSet ds = commUse.getDataSet("z_oqc_report", new object[] { "ADD", mo_id });

                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     txtOqcDate.Text = ds.Tables[0].Rows[0]["qc_date"].ToString();
                     txtCustName.Text = String.Format("{0}", ds.Tables[0].Rows[0]["cust_name_e"]) ;
                     txtBrand.Text = ds.Tables[0].Rows[0]["brand_id"].ToString();
                     txtGoodsName.Text = ds.Tables[0].Rows[0]["english_name"].ToString();
                     txtSize.Text = ds.Tables[0].Rows[0]["size_name"].ToString();
                     txtOrder_qty.Text = ds.Tables[0].Rows[0]["order_qty"].ToString()+"PCS";                     
                     txtColor.Text = ds.Tables[0].Rows[0]["color"].ToString();
                     txtCheck_qty.Text = ds.Tables[0].Rows[0]["check_qty"].ToString();
                     txtSample.Text = ds.Tables[0].Rows[0]["sample"].ToString();
                     txtAccept_qty.Text = ds.Tables[0].Rows[0]["accept_qty"].ToString();
                     txtReject_qty.Text = ds.Tables[0].Rows[0]["reject_qty"].ToString();
                 }                 
                 ds.Dispose();
            }

            //瀏覽模式
            if (this.Tag.ToString() == "" && !String.IsNullOrEmpty(mo_id))
            {

                DataSet ds = commUse.getDataSet("z_oqc_report", new object[] { "FIND", mo_id });

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtOqcDate.Text = ds.Tables[0].Rows[0]["qc_date"].ToString();
                    txtCustName.Text = String.Format("{0}", ds.Tables[0].Rows[0]["cust_name_e"]);
                    txtBrand.Text = ds.Tables[0].Rows[0]["brand_id"].ToString();
                    txtGoodsName.Text = ds.Tables[0].Rows[0]["english_name"].ToString();
                    txtSize.Text = ds.Tables[0].Rows[0]["size_name"].ToString();
                    txtOrder_qty.Text = ds.Tables[0].Rows[0]["order_qty"].ToString() + "PCS";
                    txtColor.Text = ds.Tables[0].Rows[0]["color"].ToString();

                    txtCheck_qty.Text = ds.Tables[0].Rows[0]["check_qty"].ToString();
                    txtSample.Text = ds.Tables[0].Rows[0]["sample"].ToString();
                    txtAccept_qty.Text = ds.Tables[0].Rows[0]["accept_qty"].ToString();
                    txtReject_qty.Text = ds.Tables[0].Rows[0]["reject_qty"].ToString();
                    txtUnqualified.Text = ds.Tables[0].Rows[0]["unqualified"].ToString();

                    txtLot_pcs.Text = ds.Tables[0].Rows[0]["lot_pcs"].ToString();
                    txtAC1.Text = ds.Tables[0].Rows[0]["accept_qty_1"].ToString();
                    txtRE1.Text = ds.Tables[0].Rows[0]["reject_qty_1"].ToString();
                    txtUnqulified1.Text = ds.Tables[0].Rows[0]["unqualified_1"].ToString();
                    if (ds.Tables[0].Rows[0]["Sampling"].ToString() == "True")
                    {
                        chkSampling.Checked = true;
                    }
                    else
                    {
                        chkSampling.Checked = false;
                    }
                    if (ds.Tables[0].Rows[0]["all_inspection"].ToString() == "True")
                    {
                        chkAll_inspection.Checked = true;
                    }
                    else
                    {
                        chkAll_inspection.Checked = false;
                    }
                    if (ds.Tables[0].Rows[0]["reinspection"].ToString() == "True")
                    {
                        chkReinspection.Checked = true;
                    }
                    else
                    {
                        chkReinspection.Checked = false;
                    }
                    if (ds.Tables[0].Rows[0]["Qualified"].ToString() == "True")
                    {
                        chkQualified.Checked = true;
                    }
                    else
                    {
                        chkQualified.Checked = false;
                    }
                    if (ds.Tables[0].Rows[0]["unqualified_final"].ToString() == "True")
                    {
                        chkUnqualified.Checked = true;
                    }
                    else
                    {
                        chkUnqualified.Checked = false;
                    }
                    Set_Grid_Status(true);//可編輯                     
                }
                else
                {
                    Set_Grid_Status(false);//不可編輯
                    foreach (Control ct1 in panel1.Controls)
                    {
                        switch (ct1.GetType().Name)
                        {
                            case "TextEdit":
                                TextEdit ts1 = (TextEdit)ct1;
                                //if(ts1.Tag == "N")
                                if(ts1.Tag.ToString() == "N")
                                {
                                    ts1.Text = "0";
                                }
                                else
                                {
                                    ts1.Text = "";
                                }
                                break;
                            case "CheckEdit":
                                CheckEdit ts2 = (CheckEdit)ct1;
                                ts2.Checked = false;
                                break;
                            default:
                                break;
                        }
                    }
                    chkQualified.Checked = false;
                    chkUnqualified.Checked = false;
                }
                gridControl1.DataSource = ds.Tables[1];
                gridControl2.DataSource = ds.Tables[2];
                //ds.Dispose();
            }            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Tag = "ADD";
            SetButtonSatus(false);
            SetTextBoxBackColor(true);
            Clear_Date();
            Set_Grid_Status(false);//不可編輯 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMo_id.Text.Trim()) && !String.IsNullOrEmpty(txtOqcDate.Text.Trim())) // 有內容
            {
                this.Tag = "EDIT";                
                txtMo_id.Properties.ReadOnly = true;
                SetButtonSatus(false);
                SetTextBoxBackColor(true);
                Set_Grid_Status(false);//不可編輯 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMo_id.Text))
            {
                MessageBox.Show("頁數不可爲空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMo_id.Focus();
                return;
            }
            SetButtonSatus(true);
            SetTextBoxBackColor(false);
            Save_Data();
            this.Tag = "";
            Set_Grid_Status(false);//不可編輯 
            txtMo_id.Properties.ReadOnly = false ;
            txtMo_id.Focus();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            SetButtonSatus(true);
            SetTextBoxBackColor(false);
            Clear_Date();
            this.Tag = "";
            Set_Grid_Status(false);//不可編輯  
            txtMo_id.Properties.ReadOnly = false ;            
        }
        private void Set_Grid_Status(bool _flag)
        {
            //false --不可編輯 ，true --可以編輯
            gridView2.OptionsBehavior.Editable = _flag;
            gridView1.OptionsBehavior.Editable = _flag;

            btnAdd1.Enabled = _flag;
            btnDel1.Enabled = _flag;
            btnSave1.Enabled = _flag;

            btnAdd2.Enabled = _flag;
            btnDel2.Enabled = _flag;
            btnSave2.Enabled = _flag;
        }

        private void SetButtonSatus(bool _flag)
        {
            btnAdd.Enabled = _flag ;
            btnEdit.Enabled = _flag;
            btnPrint.Enabled = _flag;
            btnDel.Enabled = _flag;
            btnSave.Enabled = !_flag;
            btnUndo.Enabled = !_flag;

            //btnAdd1.Enabled = !_flag;
            //btnDel1.Enabled = !_flag;

            //btnAdd2.Enabled = !_flag;
            //btnDel2.Enabled = !_flag;
        }

        #region  SetTextBoxBackColor 編輯時設置文本框背景色
        private void SetTextBoxBackColor(bool _falg)
        {
            foreach (Control ct in this.Controls)
            {
                switch (ct.GetType().Name)
                {
                    case "Panel":
                        foreach (Control ct1 in ct.Controls)
                        {
                            switch (ct1.GetType().Name)
                            {
                                case "TextEdit":
                                    TextEdit ts1 = (TextEdit)ct1;
                                    if (!ts1.Properties.ReadOnly)
                                    {
                                        if (_falg)
                                        {
                                            ts1.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                                        }
                                        else
                                        {
                                            ts1.Properties.Appearance.BackColor = System.Drawing.Color.White ;//.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                                        }
                                    }
                                    break;
                                case "CheckEdit":
                                    CheckEdit ts2 = (CheckEdit)ct1;
                                    if (_falg)
                                    {
                                        ts2.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                                    }
                                    else
                                    {
                                        ts2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                   
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Clear_Date() 新增時清除
        private void Clear_Date()
        {
            foreach (Control ct in this.Controls)
            {
                switch (ct.GetType().Name)
                {
                    case "Panel":
                        foreach (Control ct1 in ct.Controls)
                        {
                            switch (ct1.GetType().Name)
                            {
                                case "TextEdit":
                                    TextEdit ts1 = (TextEdit)ct1;
                                    //if (ts1.Tag == "N")  
                                    if (ts1.Tag.ToString() == "N")                                   
                                    {
                                        ts1.Text = "0"; //數值的預設爲0,不然插入數據庫出會出錯
                                    }
                                    else 
                                    {
                                        ts1.Text = "";
                                    }
                                                                       
                                    break;
                                case "CheckEdit":
                                    CheckEdit ts2 = (CheckEdit)ct1;
                                    ts2.Checked = false;
                                    break;
                                case "DataGridView":
                                    DataGridView ts3 = (DataGridView)ct1;
                                    ts3.DataSource = null;
                                    break;
                                case "GridControl":
                                    GridControl ts4 = (GridControl)ct1;
                                    ts4.DataSource = null;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }
        #endregion
    
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMo_id.Text.Trim()) && 
                !String.IsNullOrEmpty(txtOqcDate.Text.Trim()) && 
                String.IsNullOrEmpty(this.Tag.ToString())) // 有內容
            { 
                int row_seq = gridView1.RowCount + 1;               
                //新增
                gridView1.AddNewRow();               
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "seq", row_seq);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "item", "Appearance");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "standard", "There is no multilateral、scratch and unclear Logo.");
            }
        } 
     

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMo_id.Text.Trim()) && 
                !String.IsNullOrEmpty(txtOqcDate.Text.Trim()) && 
                String.IsNullOrEmpty(this.Tag.ToString())) // 有內容
            {                
                int row_seq = gridView2.RowCount + 1;                
                //新增
                gridView2.AddNewRow();
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "seq", row_seq);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "item", "diameter");
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "tool", "Caliper with watch");
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_1", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_2", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_3", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_4", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_5", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_6", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_7", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_8", 0.0);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "m_result_9", 0.0);                

            }
        }

        private static int GetSequence(string tableName, string mo_id)
        {
            //取序號
            string sql_f = String.Format("SELECT MAX(seq) AS seq FROM {0} WHERE within_code='0000' AND mo_id='{1}'", tableName, mo_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(sql_f);
            int row_seq;
            if (dt.Rows.Count == 0)
            {
                row_seq = 0;
            }
            else
            {
                row_seq = Convert.ToInt32(dt.Rows[0]["seq"].ToString()) + 1;
            }
            dt.Dispose();
            return row_seq;
        }
    

        /// <summary>
        /// 保存主檔資料
        /// </summary>
        private void Save_Data()
        {            
                string blSampling, blAllinspection, blReinspection, blQualified, blUnqualified;
                if (chkSampling.Checked)
                {
                    blSampling = "True";
                }
                else
                {
                    blSampling = "False";
                }
                if (chkAll_inspection.Checked)
                {
                    blAllinspection = "True";
                }
                else
                {
                    blAllinspection = "False";
                }
                if (chkReinspection.Checked)
                {
                    blReinspection = "True";
                }
                else
                {
                    blReinspection = "False";
                }
                if (chkQualified.Checked)
                {
                    blQualified = "True";
                }
                else
                {
                    blQualified = "False";
                }
                if (chkUnqualified.Checked)
                {
                    blUnqualified = "True";
                }
                else
                {
                    blUnqualified = "False";
                }

            string _connString = DBUtility.connectionString;
            SqlConnection sqlconn = new SqlConnection(_connString);
            if (this.Tag.ToString() == "ADD")
            {
                string sql_insert = "INSERT INTO dbo.oqc_report_h(within_code,mo_id,qc_date,check_qty,sample,accept_qty,reject_qty,unqualified,lot_pcs,accept_qty_1,reject_qty_1,unqualified_1,sampling,all_inspection,reinspection,qualified,unqualified_final)" +
                    " VALUES (@within_code,@mo_id,@qc_date,@check_qty,@sample,@accept_qty,@reject_qty,@unqualified,@lot_pcs,@accept_qty_1,@reject_qty_1,@unqualified_1,@sampling,@all_inspection,@reinspection,@qualified,@unqualified_final)";
                string sql_f = String.Format("SELECT '1' FROM dbo.oqc_report_h WHERE within_code='0000' AND mo_id='{0}'", txtMo_id.Text);
             
                try
                {
                    sqlconn.Open();
                    SqlCommand cmd_f = new SqlCommand(sql_f, sqlconn);
                    SqlDataReader dr = cmd_f.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        SqlCommand cmd_insert = new SqlCommand(sql_insert, sqlconn);
                        cmd_insert.Parameters.AddWithValue("@within_code", "0000");
                        cmd_insert.Parameters.AddWithValue("@mo_id", txtMo_id.Text.Trim());
                        cmd_insert.Parameters.AddWithValue("@qc_date", txtOqcDate.Text);
                        cmd_insert.Parameters.AddWithValue("@check_qty", txtCheck_qty.Text);
                        cmd_insert.Parameters.AddWithValue("@sample", txtSample.Text);
                        cmd_insert.Parameters.AddWithValue("@accept_qty", txtAccept_qty.Text);
                        cmd_insert.Parameters.AddWithValue("@reject_qty", txtReject_qty.Text);
                        cmd_insert.Parameters.AddWithValue("@unqualified", txtUnqualified.Text);
                        cmd_insert.Parameters.AddWithValue("@lot_pcs", txtLot_pcs.Text);
                        cmd_insert.Parameters.AddWithValue("@accept_qty_1", txtAC1.Text);
                        cmd_insert.Parameters.AddWithValue("@reject_qty_1", txtRE1.Text);
                        cmd_insert.Parameters.AddWithValue("@unqualified_1", txtUnqulified1.Text);
                        cmd_insert.Parameters.AddWithValue("@sampling", blSampling);
                        cmd_insert.Parameters.AddWithValue("@all_inspection", blAllinspection);
                        cmd_insert.Parameters.AddWithValue("@reinspection", blReinspection);
                        cmd_insert.Parameters.AddWithValue("@qualified", blQualified);
                        cmd_insert.Parameters.AddWithValue("@unqualified_final", blUnqualified);
                        cmd_insert.ExecuteNonQuery();
                        MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("此頁數資料已存在，不可重覆彔入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    sqlconn.Close();
                }
            }

            if (this.Tag.ToString() == "EDIT")
            {
                string sql_update = "UPDATE dbo.oqc_report_h SET qc_date=@qc_date, check_qty=@check_qty,sample=@sample,accept_qty=@accept_qty,reject_qty=@reject_qty,unqualified=@unqualified,lot_pcs=@lot_pcs,accept_qty_1=@accept_qty_1,reject_qty_1=@reject_qty_1,"+
                                    "unqualified_1=@unqualified_1,sampling=@sampling,all_inspection=@all_inspection,reinspection=@reinspection,qualified=@qualified,unqualified_final=@unqualified_final WHERE within_code=@within_code AND mo_id=@mo_id"; 
                try
                {
                    sqlconn.Open();
                    SqlCommand myCommand = new SqlCommand(sql_update, sqlconn);
                    myCommand.Parameters.AddWithValue("@within_code", "0000");
                    myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text.Trim());
                    myCommand.Parameters.AddWithValue("@qc_date", txtOqcDate.Text);
                    myCommand.Parameters.AddWithValue("@check_qty", txtCheck_qty.Text);
                    myCommand.Parameters.AddWithValue("@sample", txtSample.Text);
                    myCommand.Parameters.AddWithValue("@accept_qty", txtAccept_qty.Text);
                    myCommand.Parameters.AddWithValue("@reject_qty", txtReject_qty.Text);
                    myCommand.Parameters.AddWithValue("@unqualified", txtUnqualified.Text);
                    myCommand.Parameters.AddWithValue("@lot_pcs", txtLot_pcs.Text);
                    myCommand.Parameters.AddWithValue("@accept_qty_1", txtAC1.Text);
                    myCommand.Parameters.AddWithValue("@reject_qty_1", txtRE1.Text);
                    myCommand.Parameters.AddWithValue("@unqualified_1", txtUnqulified1.Text);
                    myCommand.Parameters.AddWithValue("@sampling", blSampling);
                    myCommand.Parameters.AddWithValue("@all_inspection", blAllinspection);
                    myCommand.Parameters.AddWithValue("@reinspection", blReinspection);
                    myCommand.Parameters.AddWithValue("@qualified", blQualified);
                    myCommand.Parameters.AddWithValue("@unqualified_final", blUnqualified);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    sqlconn.Close();
                }
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要刪除此頁數的全部數據？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)           
            {
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);                
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myCon;
                myCommand.Transaction = myTrans;
                try
                {                    
                    myCommand.CommandText = String.Format("DELETE FROM dbo.oqc_report_h WHERE within_code ='0000' AND mo_id ='{0}'", txtMo_id.Text.Trim());
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = String.Format("DELETE FROM dbo.oqc_report_d_grid1 WHERE within_code ='0000' AND mo_id ='{0}'", txtMo_id.Text.Trim());
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = String.Format("DELETE FROM dbo.oqc_report_d_grid2 WHERE within_code ='0000' AND mo_id ='{0}'", txtMo_id.Text.Trim());
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit();//數據提交
                    Clear_Date();
                    MessageBox.Show("數據刪除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception E)
                {
                    myTrans.Rollback();//數據回滾
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            Delet_Grid_Item(gridView1, "dbo.oqc_report_d_grid1");                  
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            Delet_Grid_Item(gridView2, "dbo.oqc_report_d_grid2"); 
        }

        private void Delet_Grid_Item(GridView _gridview ,string _tablename)
        {
            if (_gridview.RowCount > 0)
            {
                DialogResult result = MessageBox.Show("確定要刪除此行記錄？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    int rowno = _gridview.FocusedRowHandle;
                    if (_gridview.GetDataRow(rowno).RowState.ToString() == "Modified" ||
                        _gridview.GetDataRow(rowno).RowState.ToString() == "Unchanged")  //已存在的記錄方可刪除
                    {
                        int iSeq =Convert.ToInt32(_gridview.GetRowCellValue(rowno, "seq").ToString());
                        SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                        try
                        {
                            myCon.Open();
                            SqlCommand myCommand = new SqlCommand();
                            myCommand.Connection = myCon;
                            string sql_del = String.Format("DELETE FROM {0} WHERE within_code ='{1}' AND mo_id ='{2}' AND seq=@seq", _tablename, "0000", txtMo_id.Text);
                            myCommand.CommandText = sql_del;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@seq", iSeq);
                            myCommand.ExecuteNonQuery();
                            _gridview.DeleteRow(rowno);
                            MessageBox.Show("數據刪除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception E)
                        {
                            throw new Exception(E.Message);
                        }
                        finally
                        {
                            myCon.Close();
                        }
                    }
                    else
                    {
                        _gridview.DeleteRow(rowno);//刪除未保存的
                    }
                }
            }     
        }
        
        private void btnSave1_Click(object sender, EventArgs e)
        {           
            const string sql_insert = "INSERT INTO dbo.oqc_report_d_grid1(within_code,mo_id,seq,item,standard,result,remark) VALUES (@within_code,@mo_id,@seq,@item,@standard,@result,@remark)";
            const string sql_update = "Update dbo.oqc_report_d_grid1 Set item=@item,standard=@standard,result=@result,remark=@remark WHERE within_code=@within_code And mo_id=@mo_id And seq=@seq";
            
            string strmo_id = txtMo_id.Text;            
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans };
            try
            {
                for (int row = 0; row < gridView1.RowCount; row++)
                {
                    string rowStatus = gridView1.GetDataRow(row).RowState.ToString();
                    if (rowStatus == "Added" || rowStatus == "Modified")
                    {
                        if (rowStatus == "Added")
                        {
                            myCommand.CommandText = sql_insert;
                        }
                        else
                        {
                            myCommand.CommandText = sql_update;  
                        }
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", "0000");
                        myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@seq", gridView1.GetRowCellValue(row, "seq").ToString());
                        myCommand.Parameters.AddWithValue("@item", gridView1.GetRowCellValue(row, "item").ToString());
                        myCommand.Parameters.AddWithValue("@standard", gridView1.GetRowCellValue(row, "standard").ToString());
                        myCommand.Parameters.AddWithValue("@result", gridView1.GetRowCellValue(row, "result").ToString());
                        myCommand.Parameters.AddWithValue("@remark", gridView1.GetRowCellValue(row, "remark").ToString());
                        myCommand.ExecuteNonQuery();    
                    }
                                        
                }
                myTrans.Commit();//數據提交
                MessageBox.Show("數據保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                myTrans.Rollback();//數據回滾
                throw new Exception(E.Message);               
            }
            finally
            {
                myCon.Close();
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {            
            string sql_insert = "INSERT INTO dbo.oqc_report_d_grid2(within_code,mo_id,seq,item,tool,m_result_1,m_result_2,m_result_3,m_result_4,m_result_5,m_result_6,m_result_7,m_result_8,m_result_9,qualified,unqualified,remark) "+
                "VALUES (@within_code,@mo_id,@seq,@item,@tool,@m_result_1,@m_result_2,@m_result_3,@m_result_4,@m_result_5,@m_result_6,@m_result_7,@m_result_8,@m_result_9,@qualified,@unqualified,@remark)";
            string sql_update = "Update dbo.oqc_report_d_grid2 Set item = @item,tool = @tool,m_result_1 = @m_result_1,m_result_2 = @m_result_2,m_result_3 = @m_result_3,m_result_4 = @m_result_4,m_result_5 = @m_result_5,"+
                "m_result_6 = @m_result_6,m_result_7 = @m_result_7,m_result_8 = @m_result_8,m_result_9 = @m_result_9,qualified = @qualified,unqualified = @unqualified,remark=@remark WHERE within_code=@within_code And mo_id=@mo_id And seq=@seq";
           
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans };
            try
            {
                for (int row = 0; row < gridView2.RowCount; row++)
                {
                    string rowStatus = gridView2.GetDataRow(row).RowState.ToString();
                    if (rowStatus == "Added" || rowStatus == "Modified")//新增或編輯
                    {
                        if (rowStatus == "Added")
                        {
                            myCommand.CommandText = sql_insert;
                        }
                        else
                        {
                            myCommand.CommandText = sql_update;
                        }
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", "0000");
                        myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text.Trim());
                        myCommand.Parameters.AddWithValue("@seq", gridView2.GetRowCellValue(row, "seq").ToString());
                        myCommand.Parameters.AddWithValue("@item", gridView2.GetRowCellValue(row, "item").ToString());
                        myCommand.Parameters.AddWithValue("@tool", gridView2.GetRowCellValue(row, "tool").ToString());
                        myCommand.Parameters.AddWithValue("@m_result_1", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_1").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_2", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_2").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_3", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_3").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_4", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_4").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_5", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_5").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_6", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_6").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_7", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_7").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_8", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_8").ToString()));
                        myCommand.Parameters.AddWithValue("@m_result_9", Convert.ToDecimal(gridView2.GetRowCellValue(row, "m_result_9").ToString()));                        
                        myCommand.Parameters.AddWithValue("@qualified", gridView2.GetRowCellValue(row, "qualified").ToString());                      
                        myCommand.Parameters.AddWithValue("@unqualified", gridView2.GetRowCellValue(row, "unqualified").ToString());
                        myCommand.Parameters.AddWithValue("@remark", gridView2.GetRowCellValue(row, "remark").ToString());
                        myCommand.ExecuteNonQuery();
                    }                    
                }
                myTrans.Commit();//數據提交
                MessageBox.Show("數據保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                myTrans.Rollback();//數據回滾
                throw new Exception(E.Message);
            }
            finally
            {
                myCon.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMo_id.Text.Trim()) && !String.IsNullOrEmpty(txtOqcDate.Text.Trim()))
            {

                DataSet ds_report = commUse.getDataSet("z_oqc_report", new object[] { "FIND", txtMo_id.Text });
               
                if (ds_report.Tables[0].Rows.Count > 0)
                {
                    //加載報表
                    xrOqcReport MyReport = new xrOqcReport(ds_report);//{ DataSource = ds_report };                    
                    MyReport.ShowPreview();                   
                }
            }
            else
            {
                MessageBox.Show("請先查詢出要列印的數據！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMo_id.Focus();
            }

        }
     
    }
}
