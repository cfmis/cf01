﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace cf01.Forms
{
    public partial class frmQuotationFind : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        DataTable dtFind = new DataTable();
        DataTable dtPriceDisc = new DataTable();
        public DataTable dtReturn = new DataTable();        
        public int returnRowIndex = 0; 
        public string flagCall = "";
        public bool flagReturn = false;

        public frmQuotationFind()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(this.Name, this.Controls);            
            NextControl oFocus = new NextControl(this,"1");
            oFocus.EnterToTab();

            //以下代碼2022/11/21號從frmQutationFind_Load方法搬至此            
            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }
            }           
            //初始化列
            InitColumn();

            //PDD Remark是否可見。
            if (dgvDetails.Columns["remark_pdd"].Visible)
            {
                clsQuotation.IsDisplayRemark_PDD(dgvDetails, remark_pdd);
            }
            //成本價是否可見。
            if (dgvDetails.Columns["cost_price"].Visible)
            {
                clsQuotation.IsDisplayRemark_PDD(dgvDetails, cost_price);
            }
            chkSelect.Checked = false;
            chkHidenCancel.Checked = true;

            DataTable dtStatus = new DataTable();
            dtStatus = clsPublicOfCF01.GetDataTable("Select typ_cdesc as id From bs_type WHERE typ_group='Z' ORDER BY typ_code");
            for (int i = 0; i < dtStatus.Rows.Count; i++)
            {
                txtStatus.Items.Add(dtStatus.Rows[i]["id"].ToString());
            }
            dtStatus.Dispose();

           
        }

        private void frmQutationFind_Load(object sender, EventArgs e)
        {            
            if (flagCall == "")
            {
                chkReturn.Checked = false;
                chkReturn.Visible = false;
                btnReturn.Visible = false;
            }
            else
            {
                chkReturn.Visible = true;
                btnReturn.Visible = true;
            }
           
            flagReturn = false;
            //Select_All(false);//初始化時如表格有記錄,則取消全部打勾2022/11/18 canel
            //2022/11/23
            dtFind.Clear();
            dtReturn.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {                        
            if(flagCall == "Quotation")
            {
                //ReturnToParent();
                flagReturn = false;
                this.Hide();               
            }
            else
            {
                this.Close();
            }           
        }      

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtMaterial.Focus();
            bool blFlag = false;
            DataRow[] drs = null;
            if (dgvDetails.RowCount > 0)
            {             
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                    {
                        blFlag = true;
                        break;
                    }
                }
                if (blFlag)
                {
                    drs = dtFind.Select("flag_select=true");
                }
            } 
            
            string strDat1, strDat2, strCrtim1, strCrtim2;           
            strDat1 = !string.IsNullOrEmpty(txtDate1.Text) ? DateTime.Parse(txtDate1.EditValue.ToString()).Date.ToString("yyyy/MM/dd") : "";
            strDat2 = !string.IsNullOrEmpty(txtDate2.Text) ? DateTime.Parse(txtDate2.EditValue.ToString()).Date.ToString("yyyy/MM/dd") : "";
            strDat2 = !string.IsNullOrEmpty(strDat2) ? DateTime.Parse(strDat2).Date.ToString("yyyy/MM/dd") : "";           
            strCrtim1 = !string.IsNullOrEmpty(txtCrtim1.Text) ? DateTime.Parse(txtCrtim1.EditValue.ToString()).Date.ToString("yyyy/MM/dd") : "";
            strCrtim2 = !string.IsNullOrEmpty(txtCrtim2.Text) ? DateTime.Parse(txtCrtim2.EditValue.ToString()).Date.ToString("yyyy/MM/dd") : "";
            
            SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@user_id",DBUtility._user_id),
                       new SqlParameter("@sales_group",txtSales_group.Text),
                       new SqlParameter("@brand",txtBrand.Text),
                       new SqlParameter("@material",txtMaterial.Text),
                       new SqlParameter("@cust_code",txtCust_code.Text),
                       new SqlParameter("@cust_color",txtCust_color.Text),
                       new SqlParameter("@cf_code",txtCf_code.Text),
                       new SqlParameter("@cf_color",txtCf_color.Text),
                       new SqlParameter("@season",txtSeason.Text),
                       new SqlParameter("@temp_code",txtTemp_code.Text),
                       new SqlParameter("@size",txtSize.Text),
                       new SqlParameter("@dat1",strDat1), 
                       new SqlParameter("@dat2",strDat2),
                       new SqlParameter("@mo_id",txtMo_id.Text),
                       new SqlParameter("@sub_mo_id",txtSub.Text),
                       new SqlParameter("@plm_code",txtPlm_code.Text),
                       new SqlParameter("@product_desc",txtProductDesc.Text),
                       new SqlParameter("@reason_edit",txtReason.Text),
                       new SqlParameter("@remark",txtRmk.Text),
                       new SqlParameter("@other_remark",txtRmk_other.Text),
                       new SqlParameter("@remark_for_pdd",txtRmk_pdd.Text),  
                       new SqlParameter("@crtim_s",strCrtim1),
                       new SqlParameter("@crtim_e",strCrtim2),
                       new SqlParameter("@include_mat","1"),
                       new SqlParameter("@include_brand","1"),
                       new SqlParameter("@is_hiden_cancel_data",chkHidenCancel.Checked?"1":"0"),
                       new SqlParameter("@account_code",txtAccount_Code.Text),
                       new SqlParameter("@is_vnd",chkVnd.Checked?"1":"0")
            };

            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //************************           
            dtFind = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_find", paras); //数据处理
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            
            //dt.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));
            //dt.Columns.Add("temp_ver", System.Type.GetType("System.String"));
            
            //------------ 
            //導入前一次打勾的記錄
            if (drs!=null)
            {
                if (drs.Length > 0)
                {
                    DataRow[] drs_del;
                    foreach (DataRow row in drs)
                    {                        
                        drs_del = dtFind.Select(string.Format("id={0}", row["id"]));
                        foreach (DataRow row_del in drs_del)
                        {
                            dtFind.Rows.Remove(row_del);//先移走已存在的行
                        }
                    }
                    drs_del = null;
                    dtFind.Select();
                    //將打勾的添加進新查詢的結果中                   
                    foreach (DataRow dr in drs)
                    {
                        dtFind.ImportRow(dr);
                    }
                    drs = null;
                }
            }
            //------------

            //處理排序
            //this.dgvDetails.Sort(this.dgvDetails.Columns["flag_select"], ListSortDirection.Descending);  
            DataView dvw = dtFind.DefaultView;
            dvw.Sort = "flag_select DESC";  //按Flag_select列 排序
            dtFind = dvw.ToTable();
            dgvDetails.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                lblOf.Text = "";
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblOf.Text = dgvDetails.Rows.Count.ToString();
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDetails.CurrentRow==null)
            {
                return;
            }
            if (dgvDetails.RowCount > 0)
            {
                returnRowIndex = dgvDetails.CurrentRow.Index;
                lblOf.Text = (returnRowIndex + 1).ToString() + " of " + dgvDetails.RowCount.ToString();

                string temp_code = dgvDetails.CurrentRow.Cells["temp_code"].Value.ToString();
                dtPriceDisc = clsQuotation.GetPriceDiscount(temp_code);
                dgvPriceDisc.DataSource = dtPriceDisc;
                
            }
            else
            {
                returnRowIndex = 0;               
            }
               
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            //clsQuotation.SetGridViewHighLight(dgvDetails, e);//自定義焦點行高亮背景色

            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {
                if (grd.Rows[e.RowIndex].Cells["pending"].Value.ToString() == "")
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                }
                else
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkMagenta;
                    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                }
                //備註字段不顯示刪除線
                //grd.Rows[e.RowIndex].Cells["remark"].Style.ForeColor = Color.Black;
                //grd.Rows[e.RowIndex].Cells["remark"].Style.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular); 
            }
            if (grd.Rows[e.RowIndex].Cells["special_price"].Value.ToString() == "True")
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }            
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
           if(clsApp.set_find_Value(this.Name, this.Controls)>0) 
              MessageBox.Show("當前查詢條件保存成功!", "提示信息");
           else
              MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void frmQuotationFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flagCall == "Quotation")
            {
                //ReturnToParent();
                this.Hide();
            }
        }
        private void ReturnToParent()
        {
            flagReturn = true;
            dtReturn.Clear();
            if (dgvDetails.RowCount==0)
            {
                returnRowIndex = 0;
                return;
            }            
            //處理當窗口關閉時返回給父窗本的數據
            txtMaterial.Focus();
            //returnRowIndex = dgvDetails.CurrentRow.Index; //記錄當前行2022/11/23
            int old_row_no = dgvDetails.CurrentRow.Index; //記錄當前行
            if (dgvDetails.SortOrder.ToString() != "None")
            {
                //如某欄位有排序,則需重新賦值,否會引起數據次序錯亂;
                dtFind = dtFind.DefaultView.ToTable();
                dgvDetails.DataSource = dtFind;
                //dgvDetails數據源改變,焦點行已自動改變,需將更改前的當前行號重新賦值
                returnRowIndex = old_row_no;
            }            
            if (chkReturn.Checked)
            {
                //處理是否只返回有打勾的
                DataRow[] ary_drs = dtFind.Select("flag_select=true");
                //恢復原過濾前的數據
                dtFind.Select();
                //dt.Clear();此處不可以加此行，否則ary_drs的值此起異常
                if (ary_drs.Length > 0)
                {
                    //有選中則只返回選中的記錄
                    dtReturn = dtFind.Clone();                    
                    //將打勾的添加進新查詢的結果中                 
                    foreach (DataRow dr in ary_drs)
                    {                       
                        dtReturn.ImportRow(dr);
                    }                  
                    returnRowIndex = 0; //定位到第一行
                    ary_drs = null;
                }
                else
                {                  
                    //無選擇記錄則返回全部                    
                    dtReturn = dtFind.Copy();
                }                    
            }
            else
            {
                //返回全部記錄
                dtReturn = dtFind.Copy();
            }            
            this.Hide();
        }
        private void BTNCOLUMN_Click(object sender, EventArgs e)
        {
            //自定義顯示列
            using (frmCustomeGrid ofrmFind = new frmCustomeGrid("frmQuotationFind",dgvDetails,"VS"))
            {
                ofrmFind.ShowDialog();               
            }           
        }


        /// <summary>
        /// 初始化列
        /// </summary>
        private void InitColumn()
        {
            string strCol_id, strVisible;
            int column_width, column_sort;
            string strSql = string.Format(
            @"Select user_id,window_id,obj_id,col_id,col_caption,obj_type,col_width,sort_id,isvisible
            FROM dbo.sy_custome_grid WHERE user_id='{0}' and window_id='{1}' Order by sort_id", DBUtility._user_id, this.Name);
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strCol_id=dt.Rows[i]["col_id"].ToString();
                    column_width = int.Parse(dt.Rows[i]["col_width"].ToString());
                    column_sort = int.Parse(dt.Rows[i]["sort_id"].ToString());
                    strVisible = dt.Rows[i]["isvisible"].ToString();
                    for (int j = 0; j < dgvDetails.ColumnCount; j++)
                    {
                        if (dgvDetails.Columns[j].Name == strCol_id)
                        {
                            dgvDetails.Columns[j].Width = column_width;                         
                            //设定 DataGridView 的 AllowUserToOrderColumns 为 True 的时候， 用户可以自由调整列的顺序。
                            dgvDetails.Columns[j].DisplayIndex = column_sort; //顯示順序
                            if (strVisible == "False")
                            {
                                dgvDetails.Columns[j].Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked)
            {
                Select_All(true);
            }
            else
            {
                Select_All(false);
            }      
        }

        private void Select_All(bool _flag)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtFind.Rows.Count; i++)
                {
                    dtFind.Rows[i]["flag_select"] = _flag;
                }
                dgvDetails.DataSource = dtFind;
            }
        }       

        private void btnExcel_d_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {                
                clsQuotation.Export_To_Excel(dgvDetails);
            }
            else
            {
                MessageBox.Show("沒有可匯出到Excel的數據。");
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            txtRmk.Focus();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            txtMaterial.Focus();
            string strDat1, strDat2, ls_crtim1, ls_crtim2, approved;
            if (txtStatus.Text == "")
            {
                MessageBox.Show("请选择SUB MO Approved 状态不可为空！", "提示信息");
                txtStatus.Focus();
                return;
            }
            bool select_flag = false;
            DataRow[] drs = null;
            if (dgvDetails.RowCount > 0)
            {
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                    {
                        select_flag = true;
                        break;
                    }
                }
                if (select_flag)
                {
                    drs = dtFind.Select("flag_select=true");
                }
            }
           
            strDat1 = txtDate1.Text;
            strDat2 = txtDate2.Text;
            ls_crtim1 = txtCrtim1.Text;
            ls_crtim2 = txtCrtim2.Text;
            if (strDat1 == "    /  /")
            {
                strDat1 = "";
            }
            if (strDat2 == "    /  /")
            {
                strDat2 = "";
            }
            if (ls_crtim1 == "    /  /")
            {
                ls_crtim1 = "";
            }
            if (ls_crtim2 == "    /  /")
            {
                ls_crtim2 = "";
            }
            approved = txtStatus.Text;
            SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@user_id",DBUtility._user_id),
                       new SqlParameter("@sales_group",txtSales_group.Text),
                       new SqlParameter("@brand",txtBrand.Text),
                       new SqlParameter("@material",txtMaterial.Text),
                       new SqlParameter("@cust_code",txtCust_code.Text),
                       new SqlParameter("@cust_color",txtCust_color.Text),
                       new SqlParameter("@cf_code",txtCf_code.Text),
                       new SqlParameter("@cf_color",txtCf_color.Text),
                       new SqlParameter("@season",txtSeason.Text),
                       new SqlParameter("@temp_code",txtTemp_code.Text),
                       new SqlParameter("@size",txtSize.Text),
                       new SqlParameter("@dat1",strDat1), 
                       new SqlParameter("@dat2",strDat2),
                       new SqlParameter("@mo_id",txtMo_id.Text),
                       new SqlParameter("@sub_mo_id",txtSub.Text),
                       new SqlParameter("@plm_code",txtPlm_code.Text),
                       new SqlParameter("@product_desc",txtProductDesc.Text),
                       new SqlParameter("@reason_edit",txtReason.Text),
                       new SqlParameter("@remark",txtRmk.Text),
                       new SqlParameter("@other_remark",txtRmk_other.Text),
                       new SqlParameter("@remark_for_pdd",txtRmk_pdd.Text),  
                       new SqlParameter("@crtim_s",ls_crtim1),
                       new SqlParameter("@crtim_e",ls_crtim2)                       
            };

            //是示查詢進度
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //************************
            dtFind = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_find_mo_approve", paras); //数据处理
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            //dt.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));
            //dt.Columns.Add("temp_ver", System.Type.GetType("System.String"));

            //------------ 
            //導入前一次打勾的記錄
            if (drs != null)
            {
                if (drs.Length > 0)
                {
                    DataRow[] drs_del;
                    foreach (DataRow row in drs)
                    {
                        drs_del = dtFind.Select(string.Format("id={0}", row["id"]));
                        foreach (DataRow row_del in drs_del)
                        {
                            dtFind.Rows.Remove(row_del);//先移走已存在的行
                        }
                    }
                    //將打勾的添加進新查詢的結果中                   
                    foreach (DataRow dr in drs)
                    {
                        dtFind.ImportRow(dr);
                    }
                }
            }
            //------------


            //處理排序
            //this.dgvDetails.Sort(this.dgvDetails.Columns["flag_select"], ListSortDirection.Descending);  
            DataView dv = dtFind.DefaultView;
            dv.Sort = "flag_select DESC";  //按Flag_select列 排序            
            dtFind = dv.ToTable();
            
            //只保留有做Approve Status标识的
            for (int i = dtFind.Rows.Count-1; i >=0; i--)
            {
                if (dtFind.Rows[i]["SUB_2"].ToString() != txtStatus.Text || dtFind.Rows[i]["status"].ToString()=="CANCELLED")
                {
                    dtFind.Rows.RemoveAt(i);
                }
            }
            dgvDetails.DataSource = dtFind;
            if (dtFind.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnExcelArt_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                //bool fileSaved = false; 
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    /*saveDialog.DefaultExt = "";*/
                    Title = "保存EXECL文件",
                    Filter = "EXECL文件|*.xls",
                    FilterIndex = 1
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = saveDialog.FileName;
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    int FormatNum;//保存excel文件的格式
                    string Version;//excel版本號

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
                        return;
                    }
                    Version = xlApp.Version;//獲取當前使用excel版本號
                    if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
                    {
                        FormatNum = -4143;
                    }
                    else //you use excel 2007 or later
                    {
                        FormatNum = 56;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                    //第一行寫入欄位標題
                    worksheet.Cells[1, 1] = "Brand";
                    worksheet.Cells[1, 2] = "Image";
                    worksheet.Cells[1, 3] = "Sub MO";
                    worksheet.Cells[1, 4] = "Approve Status";
                    worksheet.Cells[1, 5] = "Season";
                    worksheet.Cells[1, 6] = "Divison";
                    worksheet.Cells[1, 7] = "Contact";
                    worksheet.Cells[1, 8] = "Material";
                    worksheet.Cells[1, 9] = "Size";
                    worksheet.Cells[1, 10] = "Desc";
                    worksheet.Cells[1, 11] = "Customer Code";
                    worksheet.Cells[1, 12] = "CF Code";
                    worksheet.Cells[1, 13] = "Customer Colour";
                    worksheet.Cells[1, 14] = "CF Colour";
                    worksheet.Cells[1, 15] = "FOB USD$";
                    worksheet.Cells[1, 16] = "Unit";
                    worksheet.Cells[1, 17] = "Salesman";
                    worksheet.Cells[1, 18] = "MOQ";
                    worksheet.Cells[1, 19] = "MOQ Unit";
                    worksheet.Cells[1, 20] = "MWQ";
                    worksheet.Cells[1, 21] = "Lead Time(Min)";
                    worksheet.Cells[1, 22] = "Lead Time(Max)";
                    worksheet.Cells[1, 23] = "Lead Time Unit";
                    worksheet.Cells[1, 24] = "Mould Engraving Charge";
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體
                    worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].RowHeight = 30; 

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();
                   
                    //寫入數值
                    string rang = "";
                    string pictrue_path = "";
                    string strSql = "";
                    int cur_row;
                    DataTable dt = new DataTable();

                    for (int r = 0; r < dgvDetails.RowCount; r++)//行循环
                    {
                        cur_row = r + 2;
                        //圖片路徑,有CF圖樣以CF圖樣為準，沒有就以客戶圖樣為準
                        if (!string.IsNullOrEmpty(dgvDetails.Rows[r].Cells["cf_code"].Value.ToString()))
                        {
                            strSql = string.Format(
                            @"Select TOP 1 Isnull(picture_name_h,'') as picture_name From {0}cd_pattern with(nolock)
                            Where within_code='0000' And id='{1}'", DBUtility.remote_db, dgvDetails.Rows[r].Cells["cf_code"].Value);
                            dt = clsPublicOfCF01.GetDataTable(strSql);
                            if (dt.Rows.Count > 0)
                            {
                                pictrue_path = @"\\192.168.3.12\cf_artwork\Artwork\" + dt.Rows[0]["picture_name"];
                            }
                            else
                            {
                                pictrue_path = "";
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(dgvDetails.Rows[r].Cells["cust_artwork"].Value.ToString()))
                            {
                                pictrue_path = "";
                            }
                            else
                            {
                                pictrue_path = dgvDetails.Rows[r].Cells["cust_artwork"].Value.ToString();
                            }
                        }
                        worksheet.Columns[2].ColumnWidth = 13;//圖樣

                        worksheet.Cells[cur_row, 1] = dgvDetails.Rows[r].Cells["brand"].Value.ToString();// 第一列
                        rang = "B" + (cur_row);
                        if (File.Exists(pictrue_path))
                        {
                            worksheet.Rows[cur_row].RowHeight = 70;
                            clsQuotation.InsertPicture(rang, worksheet, pictrue_path);//插入圖片
                        }
                        worksheet.Cells[cur_row, 3] = dgvDetails.Rows[r].Cells["Sub_1"].Value.ToString();// 第三列
                        worksheet.Cells[cur_row, 4] = dgvDetails.Rows[r].Cells["Sub_2"].Value.ToString();
                        worksheet.Cells[cur_row, 5] = dgvDetails.Rows[r].Cells["season"].Value.ToString();
                        worksheet.Cells[cur_row, 6] = dgvDetails.Rows[r].Cells["division"].Value.ToString();
                        worksheet.Cells[cur_row, 7] = dgvDetails.Rows[r].Cells["contact"].Value.ToString();
                        worksheet.Cells[cur_row, 8] = dgvDetails.Rows[r].Cells["material"].Value.ToString();
                        worksheet.Cells[cur_row, 9] = dgvDetails.Rows[r].Cells["size"].Value.ToString();
                        worksheet.Cells[cur_row, 10] = dgvDetails.Rows[r].Cells["product_desc"].Value.ToString();
                        worksheet.Cells[cur_row, 11] = dgvDetails.Rows[r].Cells["cust_code"].Value.ToString();
                        worksheet.Cells[cur_row, 12] = dgvDetails.Rows[r].Cells["cf_code"].Value.ToString();
                        worksheet.Cells[cur_row, 13] = dgvDetails.Rows[r].Cells["cust_color"].Value.ToString();
                        worksheet.Cells[cur_row, 14] = dgvDetails.Rows[r].Cells["cf_color"].Value.ToString();
                        worksheet.Cells[cur_row, 15] = dgvDetails.Rows[r].Cells["usd_ex_fty"].Value.ToString();
                        worksheet.Cells[cur_row, 16] = dgvDetails.Rows[r].Cells["price_unit"].Value.ToString();
                        worksheet.Cells[cur_row, 17] = dgvDetails.Rows[r].Cells["salesman"].Value.ToString();
                        worksheet.Cells[cur_row, 18] = dgvDetails.Rows[r].Cells["moq"].Value.ToString();
                        worksheet.Cells[cur_row, 19] = dgvDetails.Rows[r].Cells["moq_unit"].Value.ToString();
                        worksheet.Cells[cur_row, 20] = dgvDetails.Rows[r].Cells["mwq"].Value.ToString();
                        worksheet.Cells[cur_row, 21] = dgvDetails.Rows[r].Cells["lead_time_min"].Value.ToString();
                        worksheet.Cells[cur_row, 22] = dgvDetails.Rows[r].Cells["lead_time_max"].Value.ToString();
                        worksheet.Cells[cur_row, 23] = dgvDetails.Rows[r].Cells["lead_time_unit"].Value.ToString();
                        worksheet.Cells[cur_row, 24] = dgvDetails.Rows[r].Cells["md_charge"].Value.ToString();                     
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应 
                    worksheet.Columns[2].ColumnWidth = 13;//圖樣
                   
                    worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                    if (FileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            //workbook.SaveCopyAs(saveFileName);
                            workbook.SaveAs(FileName, FormatNum);
                            //fileSaved = true;  
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;  
                            MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
                        }
                    }
                    xlApp.Quit();
                    GC.Collect();//强行销毁
                    // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                    MessageBox.Show("匯出EXCEL成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }           
            
        }

        private void btnTestReport_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            int li_currentRow = dgvDetails.CurrentRow.Index;
            if (li_currentRow < 0)
            {
                return;
            }
            string ls_cust_code = dtFind.Rows[li_currentRow]["cust_code"].ToString();// dgvDetails.Rows[li_currentRow].Cells["cust_code"].Value.ToString();
            string ls_cust_color = dtFind.Rows[li_currentRow]["cust_color"].ToString();// dgvDetails.Rows[li_currentRow].Cells["cust_color"].Value.ToString();

            if (!string.IsNullOrEmpty(ls_cust_code))
            {
                clsTestExcel.Open_Test_Report(ls_cust_code, ls_cust_color);
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                return;
            }

            int li_currentRow = dgvDetails.CurrentRow.Index;
            if (li_currentRow >= 0)
            {
                string ls_cust_code = dtFind.Rows[li_currentRow]["cust_code"].ToString();
                string ls_cust_color = dtFind.Rows[li_currentRow]["cust_color"].ToString();
                string ls_sql = string.Format(
                @"Select Top 1 Isnull(test_report_path,'') as test_report_path 
                From dbo.bs_test_excel with(nolock) 
                Where trim_code='{0}' and finish_name='{1}'", ls_cust_code, ls_cust_color);
                lblTestReportPath.Text = clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql);
            }         
        }

        private void txtSales_group_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);//小寫轉大寫
        }

        private void txtDate1_Leave(object sender, EventArgs e)
        {
            if (txtDate1.Text != "")
            {
                txtDate2.EditValue = txtDate1.EditValue;
            }
        }

        private void txtCrtim1_Leave(object sender, EventArgs e)
        {
            if (txtCrtim1.Text != "")
            {
                txtCrtim2.EditValue = txtCrtim1.EditValue;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (flagCall == "Quotation")
            {
                ReturnToParent();
            }
        }
       
        private void dgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flagCall == "Quotation")
            {
                ReturnToParent();
            }
            else
            {
                this.Close();
            }
        }

        private void dgvPriceDisc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsQuotation.SetGridViewHighLight(dgvPriceDisc, e);
        }
    }
}
