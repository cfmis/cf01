using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using cf01.CLS;
using cf01.Reports;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmDelivery : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtDelivery = new DataTable();
        DataTable dtDept = new DataTable();
        DataTable dtVendor = new DataTable();
        public string strUserid = DBUtility._user_id;

        public frmDelivery()
        {
            InitializeComponent();
            try
            {
                //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                //control.GenerateContorl();
               // clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
               // obj_ctl.Translate();
               // clsApp.RetSetImage(toolStrip1);//因翻譯部分代碼的影響，當前菜單按鈕圖片及文本樣式異常.
                //設置菜單按鈕的權限
                clsApp.SetToolBarEnable(this.Name, this.Controls);
                clsApp.Initialize_find_value(this.Name, this.Controls);
                chkSelect.Checked = false;
                //BTNPRINT.Text = "標簽機列印(&P)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void frmDelivery_Load(object sender, EventArgs e)
        {
            string strSQL = @"SELECT id,id+'['+name+']' AS cdesc FROM cd_productline WHERE type<>'07' AND state='0' ORDER BY id" ;
            dtDept = clsConErp.GetDataTable(strSQL);
            DataRow dr0 = dtDept.NewRow(); //插一空行        
            dtDept.Rows.InsertAt(dr0, 0);
            txtOut_detp1.Properties.DataSource = dtDept;
            txtOut_detp1.Properties.ValueMember = "id";
            txtOut_detp1.Properties.DisplayMember = "cdesc";

            txtOut_detp2.Properties.DataSource = dtDept;
            txtOut_detp2.Properties.ValueMember = "id";
            txtOut_detp2.Properties.DisplayMember = "cdesc";

            txtIn_detp1.Properties.DataSource = dtDept;
            txtIn_detp1.Properties.ValueMember = "id";
            txtIn_detp1.Properties.DisplayMember = "cdesc";

            txtIn_detp2.Properties.DataSource = dtDept;
            txtIn_detp2.Properties.ValueMember = "id";
            txtIn_detp2.Properties.DisplayMember = "cdesc";

            strSQL = @"SELECT id,id+'['+name+']' as cdesc FROM it_vendor WHERE id='CL-K0036' ORDER BY id";
            dtVendor = clsConErp.GetDataTable(strSQL);
            DataRow dr1 = dtVendor.NewRow(); //插一空行        
            dtVendor.Rows.InsertAt(dr1, 0);

            if (string.IsNullOrEmpty(txtDat1.Text))
            {
                txtDat1.EditValue = DateTime.Now;
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now;
            }
        }

        private void frmDelivery_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtDelivery.Dispose();
            dtDept.Dispose();
            dtVendor.Dispose();
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

        private void txtDat2_Leave(object sender, EventArgs e)
        {
            string strDate = txtDat2.Text;
            if (!string.IsNullOrEmpty(strDate))
            {
                CheckDate(sender);
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

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            txtID2.Focus();
            string strID1 = txtID1.Text;
            string strID2 = txtID2.Text;
            if ((strID1 != "" && strID1.Length>=2) && (strID2 != ""&&strID2.Length>=2))
            {                
                if (strID1.Substring(0, 2) == "DA" && strID2.Substring(0, 2) == "DA")
                {
                    radioGroup1.SelectedIndex = 1;//倉庫轉倉
                }
                else
                {                    
                    //if (strID1.Substring(0, 1) == "P" || strID2.Substring(0, 1) == "P")
                    if (strID1.IndexOf("-") ==4 || strID2.IndexOf("-") ==4)
                    {
                        radioGroup1.SelectedIndex = 2;// 外發JX加工單
                    }
                    else
                    {
                        radioGroup1.SelectedIndex = 0;// 移交單
                    }
                }
            }

            string select_index = radioGroup1.SelectedIndex.ToString();
            string out_dept1= "";
            if (string.IsNullOrEmpty(txtOut_detp1.EditValue.ToString()))
            {                
                out_dept1 = "";
            }
            else
            {
                out_dept1 = txtOut_detp1.EditValue.ToString();
            }
            string out_dept2 = "";
            if (string.IsNullOrEmpty(txtOut_detp2.EditValue.ToString()))
            {
                out_dept2 = "";
            }
            else
            {
                out_dept2 = txtOut_detp2.EditValue.ToString();
            }
            string in_dept1 = "";
            if (string.IsNullOrEmpty(txtIn_detp1.EditValue.ToString()))
            {
                in_dept1 = "";
            }
            else
            {
                in_dept1 = txtIn_detp1.EditValue.ToString();
            }
            string in_dept2 = "";
            if (string.IsNullOrEmpty(txtIn_detp2.EditValue.ToString()))
            {
                in_dept2 = "";
            }
            else
            {
                in_dept2 = txtIn_detp2.EditValue.ToString();
            }

            if (strID1 == "" && strID2 == "" && txtDat1.Text == "" && txtDat2.Text == ""
                && out_dept1 == "" && out_dept2 == "" && in_dept1 == "" && in_dept2 == "")
            {
                MessageBox.Show("查詢條件不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string flag_jx = "";
            string flag_print="";
            if (radioGroup1.SelectedIndex == 2) //JX Data
            {
                if (chkJx.Checked)
                    flag_jx = "1";//不顯示已交江西的數據
                else
                    flag_jx = "";
            }
            else
                flag_jx = "";

            if (chkPrint.Checked) 
                flag_print = "Y";
            else
                flag_print = "";


            SqlParameter[] paras = new SqlParameter[]
            {
                    new SqlParameter("@type", select_index),
                    new SqlParameter("@id_s",strID1),
                    new SqlParameter("@id_e",strID2),
                    new SqlParameter("@date_s", txtDat1.Text),
                    new SqlParameter("@date_e", txtDat2.Text),
                    new SqlParameter("@out_dept_s", out_dept1),                    
                    new SqlParameter("@out_dept_e", out_dept2),
                    new SqlParameter("@in_dept_s", in_dept1),
                    new SqlParameter("@in_dept_e", in_dept2),
                    new SqlParameter("@flag_jx", flag_jx),
                    new SqlParameter("@flag_print", flag_print)
            };
            dtDelivery = clsConErp.ExecuteProcedureReturnTable("z_rpt_delivery_all", paras);
            //客戶端加bool字段或後端返回(bit型)都可以
            dtDelivery.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));

            if (dtDelivery.Rows.Count > 0)
            {                
                gridControl1.DataSource = dtDelivery;
            }
            else
            {                
                gridControl1.DataSource = null;
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
          Print("1");
        }

        private void BTNPRINTA4_Click(object sender, EventArgs e)
        {
            Print("2");
        }

        private void BTNPRINTA41_Click(object sender, EventArgs e)
        {
            Print("3");
        }

        private void Print(string pType)
        {
            txtID2.Focus();
            if (dtDelivery.Rows.Count ==0)
            {
                MessageBox.Show("請先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            //---Modify by 20150717
            gridView1.CloseEditor();
            DataTable dtReport = new DataTable();
            dtReport = dtDelivery.Clone();
            int ii;
            for (int i = 0; i < dtDelivery.Rows.Count; i++)
            {
                if (dtDelivery.Rows[i]["flag_select"].ToString() == "True")
                {
                    DataRow newRow = dtReport.NewRow();
                    newRow["id"] = dtDelivery.Rows[i]["id"].ToString();
                    newRow["con_date"] = dtDelivery.Rows[i]["con_date"].ToString();
                    newRow["out_dept"] = dtDelivery.Rows[i]["out_dept"].ToString();
                    newRow["out_dept_name"] = dtDelivery.Rows[i]["out_dept_name"].ToString();
                    newRow["in_dept"] = dtDelivery.Rows[i]["in_dept"].ToString();
                    newRow["in_dept_name"] = dtDelivery.Rows[i]["in_dept_name"].ToString();
                    newRow["mo_id"] = dtDelivery.Rows[i]["mo_id"].ToString();
                    newRow["goods_id"] = dtDelivery.Rows[i]["goods_id"].ToString();
                    newRow["goods_name"] = dtDelivery.Rows[i]["goods_name"].ToString();
                    newRow["con_qty"] = dtDelivery.Rows[i]["con_qty"];
                    newRow["sec_qty"] = dtDelivery.Rows[i]["sec_qty"];
                    newRow["barcode_id"] = dtDelivery.Rows[i]["barcode_id"].ToString();
                    newRow["sequence_id"] = dtDelivery.Rows[i]["sequence_id"].ToString();
                    newRow["picture_name"] = dtDelivery.Rows[i]["picture_name"].ToString();
                    newRow["do_color"] = dtDelivery.Rows[i]["do_color"].ToString();
                    newRow["package_num"] = dtDelivery.Rows[i]["package_num"].ToString();
                    newRow["goods_mat"] = dtDelivery.Rows[i]["goods_mat"].ToString();
                    newRow["seq_id_flag"] = dtDelivery.Rows[i]["seq_id_flag"].ToString();
                    newRow["rec_flag"] = dtDelivery.Rows[i]["rec_flag"].ToString();
                    newRow["vendor_id"] = dtDelivery.Rows[i]["vendor_id"].ToString();
                    newRow["name_vendor"] = dtDelivery.Rows[i]["name_vendor"].ToString();
                    newRow["name_clr"] = dtDelivery.Rows[i]["name_clr"].ToString();
                    newRow["production_remark"] = dtDelivery.Rows[i]["production_remark"].ToString();
                    newRow["plan_remark"] = dtDelivery.Rows[i]["plan_remark"].ToString();
                    newRow["plate_remark"] = dtDelivery.Rows[i]["plate_remark"].ToString();
                    newRow["plan_complete"] = dtDelivery.Rows[i]["plan_complete"].ToString();
                    newRow["location_list"] = dtDelivery.Rows[i]["location_list"].ToString();
                    newRow["remark"] = dtDelivery.Rows[i]["remark"].ToString();
                    newRow["sent_bef_year"] = dtDelivery.Rows[i]["sent_bef_year"].ToString(); 

                    //處理有幾包就列印幾張 2016-01-15
                    if(dtDelivery.Rows[i]["package_num"].ToString()!="1")
                    {
                        if (pType == "1" || pType == "2") //列印標簽時才進行此處理
                        {
                            ii = Convert.ToInt16(dtDelivery.Rows[i]["package_num"].ToString());//包數
                            newRow["package_num"] = 1;//將包數還設成從1開始.
                            dtReport.Rows.Add(newRow);
                            for (int j = 1; j < ii; j++)
                            {
                                DataRow dr = dtReport.NewRow();
                                dr["id"] = dtDelivery.Rows[i]["id"].ToString();
                                dr["con_date"] = dtDelivery.Rows[i]["con_date"].ToString();
                                dr["out_dept"] = dtDelivery.Rows[i]["out_dept"].ToString();
                                dr["out_dept_name"] = dtDelivery.Rows[i]["out_dept_name"].ToString();
                                dr["in_dept"] = dtDelivery.Rows[i]["in_dept"].ToString();
                                dr["in_dept_name"] = dtDelivery.Rows[i]["in_dept_name"].ToString();
                                dr["mo_id"] = dtDelivery.Rows[i]["mo_id"].ToString();
                                dr["goods_id"] = dtDelivery.Rows[i]["goods_id"].ToString();
                                dr["goods_name"] = dtDelivery.Rows[i]["goods_name"].ToString();
                                dr["con_qty"] = dtDelivery.Rows[i]["con_qty"];
                                dr["sec_qty"] = dtDelivery.Rows[i]["sec_qty"];
                                dr["barcode_id"] = dtDelivery.Rows[i]["barcode_id"].ToString();
                                dr["sequence_id"] = dtDelivery.Rows[i]["sequence_id"].ToString();
                                dr["picture_name"] = dtDelivery.Rows[i]["picture_name"].ToString();
                                dr["do_color"] = dtDelivery.Rows[i]["do_color"].ToString();
                                dr["package_num"] = j + 1;
                                dr["goods_mat"] = dtDelivery.Rows[i]["goods_mat"].ToString();
                                dr["seq_id_flag"] = dtDelivery.Rows[i]["seq_id_flag"].ToString();
                                dr["rec_flag"] = dtDelivery.Rows[i]["rec_flag"].ToString();
                                dr["vendor_id"] = dtDelivery.Rows[i]["vendor_id"].ToString();
                                dr["name_vendor"] = dtDelivery.Rows[i]["name_vendor"].ToString();
                                dr["name_clr"] = dtDelivery.Rows[i]["name_clr"].ToString();
                                dr["production_remark"] = dtDelivery.Rows[i]["production_remark"].ToString();
                                dr["plan_remark"] = dtDelivery.Rows[i]["plan_remark"].ToString();
                                dr["plate_remark"] = dtDelivery.Rows[i]["plate_remark"].ToString();
                                dr["plan_complete"] = dtDelivery.Rows[i]["plan_complete"].ToString();
                                dr["location_list"] = dtDelivery.Rows[i]["location_list"].ToString();
                                dr["remark"] = dtDelivery.Rows[i]["remark"].ToString();
                                dr["sent_bef_year"] = dtDelivery.Rows[i]["sent_bef_year"].ToString();                                
                                dtReport.Rows.Add(dr);
                            }
                        }
                        else
                            dtReport.Rows.Add(newRow);
                    }
                    else
                         dtReport.Rows.Add(newRow);
                }
            }
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("請首先選擇要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
            //-----------
            if (pType=="1")
            {
                //加載報表                
                xrDelivery oRepot = new xrDelivery() { DataSource = dtReport };
                oRepot.CreateDocument();
                oRepot.PrintingSystem.ShowMarginsWarning = false ;                
                oRepot.ShowPreview();
            }

            if (pType == "2")
            {               
                xrDelivery_A4 oRepot = new xrDelivery_A4() { DataSource = dtReport };
                oRepot.CreateDocument();
                oRepot.PrintingSystem.ShowMarginsWarning = false ;                
                oRepot.ShowPreview();
            }

            if (pType == "3")
            {
                xrDelivery_details_A4 oRepot = new xrDelivery_details_A4() { DataSource = dtReport };
                oRepot.CreateDocument();
                oRepot.PrintingSystem.ShowMarginsWarning = false;
                oRepot.ShowPreview();
            }  
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            cf01.ModuleClass.SetObjValue.ClearObjValue(this.Controls, "1");
        }

        private void txtOut_detp1_Click(object sender, EventArgs e)
        {
            txtOut_detp1.SelectAll();
        }

        private void txtOut_detp2_Click(object sender, EventArgs e)
        {
            txtOut_detp2.SelectAll();
        }

        private void txtIn_detp1_Click(object sender, EventArgs e)
        {
            txtIn_detp1.SelectAll();
        }

        private void txtIn_detp2_Click(object sender, EventArgs e)
        {
            txtIn_detp2.SelectAll();
        }

        private void txtOut_detp1_Leave(object sender, EventArgs e)
        {          
            txtOut_detp2.EditValue = txtOut_detp1.EditValue;
        }

        private void txtIn_detp1_Leave(object sender, EventArgs e)
        {            
            txtIn_detp2.EditValue = txtIn_detp1.EditValue;
        }

        private void txtID1_Leave(object sender, EventArgs e)
        {           
            txtID2.Text = txtID1.Text;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 2)
            {
                txtIn_detp1.Properties.DataSource = dtVendor;
                txtIn_detp1.Properties.ValueMember = "id";
                txtIn_detp1.Properties.DisplayMember = "cdesc";

                txtIn_detp2.Properties.DataSource = dtVendor;
                txtIn_detp2.Properties.ValueMember = "id";
                txtIn_detp2.Properties.DisplayMember = "cdesc";
            }
            else
            {
                txtIn_detp1.Properties.DataSource = dtDept;
                txtIn_detp1.Properties.ValueMember = "id";
                txtIn_detp1.Properties.DisplayMember = "cdesc";

                txtIn_detp2.Properties.DataSource = dtDept;
                txtIn_detp2.Properties.ValueMember = "id";
                txtIn_detp2.Properties.DisplayMember = "cdesc";
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                txtID2.Focus();
                DataRow[] dr = dtDelivery.Select("flag_select=true And in_dept='CL-K0036' ");//flag_select
                if (dr.Length == 0)
                {
                    MessageBox.Show("請首先選擇或檢查是否有交到JX的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }               
                Save(dr);                
            }
        }

        private void Save(DataRow[] dr)
        {
            bool save_flag = true;
            const string comp_code = "0000";            
            const string sql_h_i = @"INSERT INTO tr_motojx_head(comp_code,doc_id,doc_date,out_dep,in_dep,crusr,crtim)
                                    VALUES(@comp_code,@doc_id,@doc_date,@out_dep,@in_dep,@crusr,getdate())";            
            const string sql_d_i = @"INSERT INTO tr_motojx_details(comp_code,doc_id,seq_id,prd_mo,prd_item,mat_item,tr_qty,tr_weg,tr_packer,crusr,crtim)
                                    VALUES(@comp_code,@doc_id,@seq_id,@prd_mo,@prd_item,@mat_item,@tr_qty,@tr_weg,@tr_packer,@crusr,getdate())";

            const string sql_d_u = @"UPDATE tr_motojx_details SET prd_mo=@prd_mo,prd_item=@prd_item,mat_item=@mat_item,
                                       tr_qty=@tr_qty,tr_weg=@tr_weg,tr_packer=@tr_packer,amusr=@crusr,amtim=getdate()
                                   Where comp_code=@comp_code AND doc_id=@doc_id AND seq_id=@seq_id";            
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans };

            DataTable dtHead = new DataTable();
            DataTable dtDetails = new DataTable();
            string sql_h_f = "";
            string sql_d_f = "";
            for (int i = 0; i < dr.Length; i++)
            {
                sql_h_f = String.Format(@"Select '1' FROM tr_motojx_head With(nolock) WHERE comp_code='{0}' AND doc_id='{1}'", comp_code, dr[i]["id"]);
                dtHead = clsPublicOfCF01.GetDataTable(sql_h_f);                              
                try
                {
                    //主表
                    if (dtHead.Rows.Count == 0)
                    {
                        SqlParameter[] paras = new SqlParameter[]
                        {
                            new SqlParameter("@comp_code", comp_code),
                            new SqlParameter("@doc_id",dr[i]["id"].ToString()),
                            new SqlParameter("@doc_date", dr[i]["con_date"].ToString()),
                            new SqlParameter("@out_dep", dr[i]["out_dept"].ToString()),
                            new SqlParameter("@in_dep", dr[i]["in_dept"].ToString()),
                            new SqlParameter("@crusr", strUserid)
                        };
                        myCommand.CommandText = sql_h_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddRange(paras);
                        myCommand.ExecuteNonQuery();                        
                    }
                    
                    //明細
                    SqlParameter[] paras_d = new SqlParameter[]
                    {
                        new SqlParameter("@comp_code", comp_code),
                        new SqlParameter("@doc_id",dr[i]["id"].ToString()),
                        new SqlParameter("@seq_id", dr[i]["sequence_id"].ToString()),
                        new SqlParameter("@prd_mo", dr[i]["mo_id"].ToString()),
                        new SqlParameter("@prd_item", dr[i]["goods_id"].ToString()),
                        new SqlParameter("@mat_item", dr[i]["goods_mat"].ToString()),                       
                        new SqlParameter("@tr_qty", dr[i]["con_qty"]),
                        new SqlParameter("@tr_weg", dr[i]["sec_qty"]),
                        new SqlParameter("@tr_packer", dr[i]["package_num"]),                            
                        new SqlParameter("@crusr", strUserid)
                    };
                    sql_d_f = String.Format(@"Select '1' FROM tr_motojx_details With(nolock) WHERE comp_code='{0}' AND doc_id='{1}' AND seq_id='{2}'", comp_code, dr[i]["id"], dr[i]["sequence_id"]);
                    dtDetails = clsPublicOfCF01.GetDataTable(sql_d_f);
                    if (dtDetails.Rows.Count == 0)
                    {                       
                        myCommand.CommandText = sql_d_i;                            
                    }
                    else
                    {                        
                        myCommand.CommandText = sql_d_u;
                    }
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddRange(paras_d);
                    myCommand.ExecuteNonQuery();                    
                    save_flag = true;
                    
                }                    
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }                
                if (!save_flag) 
                    return;
            }
            if (save_flag)
                myTrans.Commit();
            myCon.Close();
            myTrans.Dispose();
            myCommand.Dispose();
            
            if (save_flag)
            {                
                MessageBox.Show("數據保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("數據保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }            
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            
            string seq_id_flag = gridView1.GetRowCellDisplayText(e.RowHandle, "seq_id_flag");
            if (string.IsNullOrEmpty(seq_id_flag))
            {
                seq_id_flag = "";
            }
            string sequence_id = gridView1.GetRowCellDisplayText(e.RowHandle, "sequence_id");            
            if (sequence_id == seq_id_flag)
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.AntiqueWhite;//.LemonChiffon;
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (dtDelivery.Rows.Count > 0)
            {
                Boolean blSetValue = true;
                if (chkSelect.Checked)
                {
                    blSetValue = true;//Select All                    
                }
                else
                {
                    blSetValue = false;                    
                }                
                for (int i = 0; i < dtDelivery.Rows.Count; i++)
                {
                    gridView1.SetRowCellValue(i, "flag_select", blSetValue);
                }
                
            }
        }
            

        private void clFlag_select_CheckedChanged(object sender, EventArgs e)
        {           
            if (chkDelivery.Checked)
            {
                gridView1.CloseEditor();//將當前行所有更改立即定入綁定的數據源 NND折騰一天時間
                string strID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                string value_select = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString();
                bool flag;
                if (value_select == "True")
                {                   
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                for (int i = 0; i < dtDelivery.Rows.Count; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, "id") == strID)
                    {
                        gridView1.SetRowCellValue(i, "flag_select", flag);
                    }
                }
                gridView1.CloseEditor();
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if(clsApp.set_find_Value(this.Name, this.Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BTNSAVEPRINT_Click(object sender, EventArgs e)
        {
            Save_Print_Data();
        }

        private void Save_Print_Data()
        {           
            if (dtDelivery.Rows.Count == 0)
            {
                MessageBox.Show("請先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtReport = new DataTable();
            dtReport = dtDelivery.Clone();
            for (int i = 0; i < dtDelivery.Rows.Count; i++)
            {
                if (dtDelivery.Rows[i]["flag_select"].ToString() == "True")
                {
                    DataRow newRow = dtReport.NewRow();
                    newRow["id"] = dtDelivery.Rows[i]["id"].ToString();                   
                    newRow["sequence_id"] = dtDelivery.Rows[i]["sequence_id"].ToString();                   
                    dtReport.Rows.Add(newRow);
                }
            }
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("沒有要保存的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool flag_save = false;
            string id, seq_no;
            const string sql_i = "Insert Into dbo.jo_z_delivery(within_code,id,sequence_id) values(@within_code,@id,@sequence_id)";
            string sql_f = "", strResult = "";

            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() {Connection = myCon, Transaction = myTrans })
            {
                for (int i = 0; i < dtReport.Rows.Count; i++)
                {                   
                    id = dtDelivery.Rows[i]["id"].ToString();
                    seq_no = dtDelivery.Rows[i]["sequence_id"] + "h";
                    sql_f = string.Format("Select '1' From dbo.jo_z_delivery with(nolock) Where within_code='{0}' and id='{1}' And sequence_id='{2}'","0000",id, seq_no);
                    strResult = clsConErp.ExecuteSqlReturnObject(sql_f);                    
                    if (string.IsNullOrEmpty(strResult))
                    {
                        myCommand.CommandText = sql_i;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@within_code", "0000");
                        myCommand.Parameters.AddWithValue("@id", id);
                        myCommand.Parameters.AddWithValue("@sequence_id", seq_no);
                        myCommand.ExecuteNonQuery();
                    }
                }
                try
                {
                    myTrans.Commit(); //數據提交
                    flag_save = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    flag_save = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }
            }

            if (flag_save)
            {
                MessageBox.Show("保存列印數據成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存列印數據失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlloy_Click(object sender, EventArgs e)
        {
            txtID2.Focus();
            if (dtDelivery.Rows.Count == 0)
            {
                MessageBox.Show("請先查詢出需要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            gridView1.CloseEditor();
            DataTable dt = new DataTable();
            dt = dtDelivery.Clone();
            int record_no=0;
            for (int i = 0; i < dtDelivery.Rows.Count; i++)
            {
                if (dtDelivery.Rows[i]["flag_select"].ToString() == "True")
                {
                    record_no += 1;
                    DataRow newRow = dt.NewRow();          
                    newRow["mo_id"] = dtDelivery.Rows[i]["mo_id"].ToString();
                    newRow["goods_id"] = dtDelivery.Rows[i]["goods_id"].ToString();
                    newRow["goods_name"] = dtDelivery.Rows[i]["goods_name"].ToString();
                    newRow["remark"] = record_no.ToString();
                    dt.Rows.Add(newRow);
                }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("請首先選擇要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xrPrintTranserAlloy obj_rpt = new xrPrintTranserAlloy() { DataSource = dt };
            obj_rpt.ShowPreviewDialog();
        }

        private void txtID2_EditValueChanged(object sender, EventArgs e)
        {

        }
     
    }
}
