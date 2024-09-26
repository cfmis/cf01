using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.IO;
using cf01.Reports;
using cf01.Forms;
using cf01.CLS;
using System.Threading;
using System.Reflection;
using cf01.MDL;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmOrderForJx : Form
    {
        private CheckBox CheckBox1 = new CheckBox();

        clsCommonUse com = new clsCommonUse();

        public frmOrderForJx()
        {
            InitializeComponent();

            //2016-03-04加入以下代碼
            NextControl oFocus = new NextControl(this, "1");
            oFocus.EnterToTab();
        }

        private void frmOrderForJx_Load(object sender, EventArgs e)
        {
            //新的初始化界面
            clsControlInfoHelper forminit = new clsControlInfoHelper(this.Name, this.Controls);
            forminit.GenerateContorl();
            dgvMoInfo.AutoGenerateColumns = false;

            txtDat1.Text = DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00";

            AddCheckBox();
            InitQueryValue();
        }

        /// <summary>
        ///添加全選框 
        /// </summary>
        private void AddCheckBox()
        {
            CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
            CheckBox1.Visible = false;
            CheckBox1.Text = "全選";
            this.splitContainer1.Panel2.Controls.Add(CheckBox1);
        }

        private void CheckBox1_CheckedChanged(object send, System.EventArgs e)
        {
            for (int i = 0; i <= dgvMoInfo.RowCount - 1; i++)
            {
                if ((bool)dgvMoInfo.Rows[i].Cells["CheckBox"].EditedFormattedValue)
                {
                    dgvMoInfo.Rows[i].Cells["CheckBox"].Value = false;
                }
                else
                {
                    dgvMoInfo.Rows[i].Cells["CheckBox"].Value = true;
                }
            }
        }

        //        private void BindDataGridView(string strWhere)
        //        {
        //            string strSql = null;

        //            strSql = @" Select a.wp_id, a.mo_id AS prd_mo, a.mo_date, a.goods_id AS prd_item ,a.goods_name
        //                               , a.prod_qty, a.rmk,a.prod_qty AS per_prod_qty,1 AS page_copy, a.cr_usr as crusr
        //                               , a.chk_dat AS check_date,a.order_qty,a.ver,a.t_dat AS t_complete_date,a.next_wp_id
        //                               , a.next_wp_name,a.color_desc,a.do_color,a.am_usr, CONVERT(varchar(50),a.cr_tim,20) AS crtim 
        //                               ,d.vendor_id
        //                        FROM mo_for_jx a 
        //                        INNER Join dgerp2.cferp.dbo.jo_bill_goods_details d with(nolock) ON a.within_code COLLATE Chinese_PRC_CI_AS = d.within_code
        //                        AND  a.id COLLATE Chinese_PRC_CI_AS = d.id AND  a.ver = d.ver AND a.sequence_id COLLATE Chinese_PRC_CI_AS =d.sequence_id
        //                        " + strWhere;    /* Left Join geo_it_goods b ON a.goods_id=b.id */

        //            try
        //            {
        //                DataTable dtTemp = com.GetDataSet(strSql, "TB_mo").Tables["TB_mo"];
        //                FilterData(dtTemp);
        //                BindImagePath();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "软件提示");

        //            }
        //        }

        /// <summary>
        /// 篩選是否打印的記錄
        /// </summary>
        /// <param name="dtTemp"></param>
        private void FilterData(DataTable dtTemp)
        {
            DataTable dtHadPrint = dtTemp.Copy();
            DataTable dtNoPrint = dtTemp.Copy();
            dtHadPrint.Rows.Clear();
            dtNoPrint.Rows.Clear();
            DataTable dtMoStatePrint = clsMoStatePrint.GetMoStatePrintForTrans("", "");
            if (dtTemp.Rows.Count > 0 && dtMoStatePrint.Rows.Count > 0)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    bool IsRepeat = false;
                    for (int j = 0; j < dtMoStatePrint.Rows.Count; j++)
                    {
                        if (dtTemp.Rows[i]["wp_id"].ToString() == dtMoStatePrint.Rows[j]["wp_id"].ToString() &&
                            dtTemp.Rows[i]["prd_mo"].ToString() == dtMoStatePrint.Rows[j]["mo_id"].ToString() &&
                            dtTemp.Rows[i]["prd_item"].ToString() == dtMoStatePrint.Rows[j]["goods_id"].ToString() &&
                            dtTemp.Rows[i]["next_wp_id"].ToString() == dtMoStatePrint.Rows[j]["next_wp_id"].ToString())
                        {
                            dtHadPrint.Rows.Add(dtTemp.Rows[i].ItemArray);
                            IsRepeat = true;
                        }
                        else
                        {
                            if (j == dtMoStatePrint.Rows.Count - 1 && IsRepeat == false)
                            {
                                dtNoPrint.Rows.Add(dtTemp.Rows[i].ItemArray);
                            }
                        }
                    }
                }
            }

            if (chkIsPrint.Checked == true)  //顯示是否已打印數據
            {
                this.dgvMoInfo.DataSource = dtHadPrint;
            }
            else
            {
                this.dgvMoInfo.DataSource = dtNoPrint;
            }
        }

        private void BindImagePath()
        {
            if (dgvMoInfo.RowCount > 0)
            {
                for (int i = 0; i < dgvMoInfo.RowCount; i++)
                {
                    System.Data.DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(dgvMoInfo.Rows[i].Cells["goods_id"].Value.ToString());

                    if (dtArt.Rows[0]["picture_name"].ToString() != "")
                    {
                        dgvMoInfo.Rows[i].Cells["Art_image"].Value = DBUtility.imagePath + dtArt.Rows[0]["picture_name"].ToString();
                    }
                }
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolFind_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            find_data(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

        }

        private void find_data()
        {
            string Date1, Date2;
            string fdep="", tdep="";           
            if (textDep1.Text == "J01")
                fdep = "302";
            else
                if (textDep1.Text == "J03")
                    fdep = "102";
            if (textDep2.Text == "J01")
                tdep = "302";
            else
                if (textDep2.Text == "J03")
                    tdep = "102";

            if (txtDat1.Text.Replace(" ", "") != "//::")
            {
                if (clsValidRule.CheckDateTimeFormat(txtDat1.Text) == false)
                {
                    MessageBox.Show("日期格式不正確","提示信息");
                    txtDat1.Focus();
                    return;
                }
                else
                {
                    Date1 = txtDat1.Text;
                }
            }
            else
            {
                Date1 = "";
            }

            if (txtDat2.Text.Replace(" ", "") != "//::")
            {
                if (clsValidRule.CheckDateTimeFormat(txtDat2.Text) == false)
                {
                    MessageBox.Show("日期格式不正確", "提示信息");
                    txtDat2.Focus();
                    return;
                }
                else
                {
                    Date2 = txtDat2.Text;
                }
            }
            else
            {
                Date2 = "";
            }

            DataTable dtmoData = clsMo_for_jx.GetMoDataForJX(fdep, tdep, Date1, Date2, textMo1.Text, textMo2.Text);
            dgvMoInfo.DataSource = dtmoData;
        }

        private void textMo1_Leave(object sender, EventArgs e)
        {
            textMo2.Text = textMo1.Text;
        }

        private void textDep1_Leave(object sender, EventArgs e)
        {
            textDep2.Text = textDep1.Text;
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dgvMoInfo.Rows.Count > 0)
            {
                textDep1.Focus();
                show_workcard(); //数据处理
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string strFileName = ExpToExcel.GetFileName(dgvMoInfo);
            if (strFileName == "" || strFileName == null)
            {
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            ExportToExcelByCell(strFileName);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void toolSaveQueryValue_Click(object sender, EventArgs e)
        {
            List<mdlQueryValue> lsQV = new List<mdlQueryValue>();
            clsUtility.GetValue(this.panel1.Controls, lsQV, this.Name);

            if (lsQV.Count > 0)
            {
                int Result = clsQueryValue.AddOrUpdateQueryValue(lsQV);
                if (Result > 0)
                {
                    MessageBox.Show("查詢條件已保存。");
                }
            }
        }

        private void toolSavePrintOrder_Click(object sender, EventArgs e)
        {
            List<mdlMoStatePrint> lsModel = new List<mdlMoStatePrint>();
            for (int i = 0; i < dgvMoInfo.RowCount; i++)
            {
                if ((bool)dgvMoInfo.Rows[i].Cells["CheckBox"].EditedFormattedValue)
                {
                    mdlMoStatePrint objModel = new mdlMoStatePrint();
                    objModel.crtim = DateTime.Now;
                    objModel.crusr = DBUtility._user_id;
                    objModel.print_status = "P";
                    objModel.goods_id = dgvMoInfo.Rows[i].Cells["goods_id"].Value.ToString();
                    objModel.mo_id = dgvMoInfo.Rows[i].Cells["mo_id"].Value.ToString();
                    objModel.next_wp_id = dgvMoInfo.Rows[i].Cells["next_wp_id"].Value.ToString();
                    objModel.ver = clsUtility.FormatNullableInt32(dgvMoInfo.Rows[i].Cells["ver"].Value);
                    objModel.wp_id = dgvMoInfo.Rows[i].Cells["wp_id"].Value.ToString();
                    lsModel.Add(objModel);
                }
            }

            if (lsModel.Count > 0)
            {
                int Result = clsMoStatePrint.AddMoStatePrint(lsModel);
                if (Result > 0)
                {
                    MessageBox.Show("保存成功!");
                }
                else
                {
                    MessageBox.Show("保存失敗!");
                }
            }
        }

        /// <summary>
        ///獲取打印工序卡的數據 
        /// </summary>
        private void show_workcard()
        {
            String dep, mo, item, Request_date, Remark;

            Thread t = new Thread(delegate(){
                frmProgress wForm = new frmProgress();
                wForm.TopMost = true;
                wForm.ShowDialog();
            });
            t.Start();

            DataTable dtNewWork = new DataTable();
            dtNewWork.Columns.Add("wp_id", typeof(string));
            dtNewWork.Columns.Add("mo_id", typeof(string));
            dtNewWork.Columns.Add("goods_id", typeof(string));
            dtNewWork.Columns.Add("goods_name", typeof(string));
            dtNewWork.Columns.Add("prod_qty", typeof(string));
            dtNewWork.Columns.Add("goods_unit", typeof(string));
            dtNewWork.Columns.Add("within_code", typeof(string));
            dtNewWork.Columns.Add("id", typeof(string));
            dtNewWork.Columns.Add("ver", typeof(string));
            dtNewWork.Columns.Add("sequence_id", typeof(string));
            dtNewWork.Columns.Add("blueprint_id", typeof(string));
            dtNewWork.Columns.Add("production_remark", typeof(string));
            dtNewWork.Columns.Add("remark", typeof(string));
            dtNewWork.Columns.Add("next_wp_id", typeof(string));
            dtNewWork.Columns.Add("predept_rechange_qty", typeof(decimal));
            dtNewWork.Columns.Add("order_qty", typeof(string));
            dtNewWork.Columns.Add("order_unit", typeof(string));
            dtNewWork.Columns.Add("color", typeof(string));
            dtNewWork.Columns.Add("base_qty", typeof(int));
            dtNewWork.Columns.Add("unit_code", typeof(string));
            dtNewWork.Columns.Add("base_rate", typeof(int));
            dtNewWork.Columns.Add("basic_unit", typeof(string));
            dtNewWork.Columns.Add("art_id", typeof(string));
            dtNewWork.Columns.Add("picture_name", typeof(string));
            dtNewWork.Columns.Add("color_name", typeof(string));
            dtNewWork.Columns.Add("do_color", typeof(string));
            dtNewWork.Columns.Add("order_qty_pcs", typeof(string));
            dtNewWork.Columns.Add("next_dep_name", typeof(string));
            dtNewWork.Columns.Add("customer_id", typeof(string));
            dtNewWork.Columns.Add("brand_id", typeof(string));
            dtNewWork.Columns.Add("get_color_sample", typeof(string));
            dtNewWork.Columns.Add("do_color1", typeof(string));
            dtNewWork.Columns.Add("page_num", typeof(int));
            dtNewWork.Columns.Add("per_qty", typeof(string));
            dtNewWork.Columns.Add("t_complete_date", typeof(string));
            dtNewWork.Columns.Add("total_page", typeof(int));
            dtNewWork.Columns.Add("get_color_sample_name", typeof(string));
            dtNewWork.Columns.Add("vendor_id", typeof(string));
            dtNewWork.Columns.Add("c_sec_qty_ok", typeof(int));
            dtNewWork.Columns.Add("depRemark", typeof(string));
            dtNewWork.Columns.Add("request_date", typeof(string));
            dtNewWork.Columns.Add("position_id", typeof(string));
            dtNewWork.Columns.Add("report_name", typeof(string));
            dtNewWork.Columns.Add("crtime", typeof(string));
            dtNewWork.Columns.Add("mould_no", typeof(string));
            dtNewWork.Columns.Add("BarCode", typeof(string));
            dtNewWork.Columns.Add("goods_position", typeof(string));
            dtNewWork.Columns.Add("pe_qty", typeof(string));
            dtNewWork.Columns.Add("step", typeof(string));
            dtNewWork.Columns.Add("do_color_next_dep", typeof(string));
            dtNewWork.Columns.Add("plate_remark", typeof(string));

            DataRow dr = null;
            string order_unit;
            int order_qty, order_qty_pcs;
            for (int j = 0; j < dgvMoInfo.RowCount; j++)
            {
                if ((bool)dgvMoInfo.Rows[j].Cells["CheckBox"].EditedFormattedValue)
                {
                    Remark = dgvMoInfo.Rows[j].Cells["rmk"].Value.ToString();
                    Request_date = dgvMoInfo.Rows[j].Cells["t_complete_date"].Value.ToString();
                    dep = dgvMoInfo.Rows[j].Cells["wp_id"].Value.ToString();
                    mo = dgvMoInfo.Rows[j].Cells["mo_id"].Value.ToString();
                    item = dgvMoInfo.Rows[j].Cells["goods_id"].Value.ToString();
                    if (dep != "" && mo != "" && item != "")
                    {
                        DataTable dt_wk = clsMo_for_jx.GetGoods_DetailsById(dep, mo, item);
                        DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(item);
                        DataTable dtPosition = clsMo_for_jx.GetPosition(item);
                        DataTable dtQty = clsMo_for_jx.GetOrderQty(mo);//獲取訂單數量
                        DataTable dtPs = clsMo_for_jx.GetPeQtyAndStep(item);
                        DataTable dtColor = clsMo_for_jx.GetColorInfo(dep, mo, item);
                        DataTable dtPlate_Remark = clsMo_for_jx.Get_Plate_Remark(mo);
                        //當前貨品的下部門顏色做法
                        string do_color_next_dep = clsMo_for_jx.Get_do_color_next_dep(mo,item,dep);
                        
                        order_unit = "";
                        order_qty = 0;
                        order_qty_pcs = 0;
                        if (dtQty.Rows.Count > 0)
                        {
                            order_unit = dtQty.Rows[0]["goods_unit"].ToString();
                            order_qty = Convert.ToInt32(dtQty.Rows[0]["order_qty"]);
                            order_qty_pcs = Convert.ToInt32(dtQty.Rows[0]["order_qty_pcs"]);
                        }
                        if (dt_wk.Rows.Count > 0)
                        {
                            int Per_qty = Convert.ToInt32(dgvMoInfo.Rows[j].Cells["per_prod_qty"].Value);  //每次生產數量
                            int Total_qty = Convert.ToInt32(dgvMoInfo.Rows[j].Cells["prod_qty"].Value);    //生產總量
                            int NumPage = 0;     //報表頁數
                            if (Total_qty > 0 && Per_qty > 0)
                            {
                                if (Total_qty % Per_qty > 0)
                                {
                                    NumPage = (Total_qty / Per_qty) + 1;
                                }
                                else
                                {
                                    NumPage = (Total_qty / Per_qty);
                                }
                            }
                            else
                            {
                                NumPage = 1;
                            }

                            for (int i = 1; i <= NumPage; i++)
                            {
                                dr = dtNewWork.NewRow();

                                dr["wp_id"] = dt_wk.Rows[0]["wp_id"].ToString();
                                dr["mo_id"] = dt_wk.Rows[0]["mo_id"].ToString();
                                dr["goods_id"] = dt_wk.Rows[0]["goods_id"].ToString();
                                dr["goods_name"] = dt_wk.Rows[0]["name"].ToString();
                                dr["prod_qty"] = clsUtility.NumberConvert(dt_wk.Rows[0]["prod_qty"]);
                                dr["goods_unit"] = dt_wk.Rows[0]["goods_unit"].ToString();
                                dr["within_code"] = dt_wk.Rows[0]["within_code"].ToString();
                                dr["id"] = dt_wk.Rows[0]["id"].ToString();
                                dr["ver"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["ver"]);
                                dr["sequence_id"] = dt_wk.Rows[0]["sequence_id"].ToString();
                                dr["blueprint_id"] = dt_wk.Rows[0]["blueprint_id"].ToString();
                                dr["production_remark"] = dt_wk.Rows[0]["production_remark"].ToString();
                                dr["remark"] = dt_wk.Rows[0]["remark"].ToString();
                                dr["next_wp_id"] = dt_wk.Rows[0]["next_wp_id"].ToString();
                                dr["predept_rechange_qty"] = clsUtility.FormatNullableDecimal(dt_wk.Rows[0]["predept_rechange_qty"]);
                                dr["order_qty"] = clsUtility.NumberConvert(order_qty);
                                dr["order_unit"] = order_unit;
                                dr["color"] = dt_wk.Rows[0]["color"].ToString();
                                dr["base_qty"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["base_qty"]);
                                dr["unit_code"] = dt_wk.Rows[0]["unit_code"].ToString();
                                dr["base_rate"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["base_rate"]);
                                dr["basic_unit"] = dt_wk.Rows[0]["basic_unit"].ToString();
                                dr["order_qty_pcs"] = clsUtility.NumberConvert(order_qty_pcs);

                                string next_dep_id = dgvMoInfo.Rows[j].Cells["next_wp_id"].Value.ToString().Trim();
                                dr["next_dep_name"] = clsPrdTransfer.GetDept_name(next_dep_id);

                                dr["customer_id"] = dt_wk.Rows[0]["customer_id"].ToString();
                                dr["brand_id"] = dt_wk.Rows[0]["brand_id"].ToString();
                                dr["get_color_sample"] = dt_wk.Rows[0]["get_color_sample"].ToString();
                                dr["do_color1"] = dt_wk.Rows[0]["get_color_sample"];
                                dr["page_num"] = i;
                                dr["total_page"] = NumPage;
                                dr["c_sec_qty_ok"] = clsUtility.FormatNullableInt32(dt_wk.Rows[0]["c_sec_qty_ok"]);
                                dr["get_color_sample_name"] = dt_wk.Rows[0]["get_color_sample_name"];
                                dr["vendor_id"] = dt_wk.Rows[0]["vendor_id"];
                                dr["depRemark"] = Remark;
                                dr["request_date"] = Request_date;
                                dr["crtime"] = clsUtility.FormatNullableDateTime(dgvMoInfo.Rows[j].Cells["cr_tim"].Value);
                                if (dtPlate_Remark.Rows.Count > 0)
                                {
                                    dr["plate_remark"] = dtPlate_Remark.Rows[0]["plate_remark"];
                                }

                                if (dtArt.Rows.Count > 0)
                                {
                                    dr["art_id"] = dtArt.Rows[0]["art_id"].ToString();
                                    dr["picture_name"] = dtArt.Rows[0]["picture_name"].ToString();
                                }

                                if (dtColor.Rows.Count > 0)
                                {
                                    dr["color_name"] = dtColor.Rows[0]["color_name"].ToString();
                                    dr["do_color"] = dtColor.Rows[0]["do_color"].ToString();
                                }

                                if (dtPosition.Rows.Count > 0)
                                {
                                    dr["position_id"] = clsUtility.FormatNullableString(dtPosition.Rows[0]["id"]);
                                    dr["mould_no"] = clsUtility.FormatNullableString(dtPosition.Rows[0]["mould_no"]);
                                }

                                if (dep == "302")
                                {
                                    dr["report_name"] = "生產單";
                                }
                                else
                                {
                                    dr["report_name"] = "工序卡";
                                }

                                if (dt_wk.Rows[0]["t_complete_date"].ToString() != "" && dt_wk.Rows[0]["t_complete_date"].ToString() != null)
                                {
                                    dr["t_complete_date"] = Convert.ToDateTime(dt_wk.Rows[0]["t_complete_date"]).ToString("yyyy/MM/dd");
                                }

                                if (i == NumPage && Per_qty != 0)
                                {
                                    if (Total_qty % Per_qty > 0)
                                    {
                                        dr["per_qty"] = clsUtility.NumberConvert(Total_qty % Per_qty);
                                    }
                                    else
                                    {
                                        dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                                    }
                                }
                                else
                                {
                                    dr["per_qty"] = clsUtility.NumberConvert(Per_qty);
                                }

                                if (dtPs.Rows.Count > 0)
                                {
                                    dr["pe_qty"] = dtPs.Rows[0]["pe_qty"].ToString();
                                    dr["step"] = dtPs.Rows[0]["step"].ToString();
                                }
                                //條碼Barcode
                                dr["BarCode"] = clsMo_for_jx.ReturnBarCode(dt_wk.Rows[0]["mo_id"] + "0" + dt_wk.Rows[0]["ver"] + dt_wk.Rows[0]["sequence_id"].ToString().Substring(2, 2));
                                //貨倉位置
                                dr["goods_position"] = clsMo_for_jx.ReturnGoodsPosition(dt_wk.Rows[0]["goods_id"].ToString(), dt_wk.Rows[0]["next_wp_id"].ToString());
                                dr["do_color_next_dep"] = do_color_next_dep;
                                dtNewWork.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("頁數：{0},負責部門：{1}的單據生產計劃已更改，無須列印工序卡", mo, dep));
                        }
                    }
                }
            }
            t.Abort();
            if (dtNewWork.Rows.Count > 0)
            {
                //xtaWork_jx xr = new xtaWork_jx();舊報表注釋于2016-03-04
                //xr.DataSource = dtNewWork;
                //xr.ShowPreviewDialog();

                if (textDep1.Text == "J01")
                {
                    xtaWork_jx xr = new xtaWork_jx() { DataSource = dtNewWork };
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreview();
                }
                else
                {
                    xtaWorkjx xr = new xtaWorkjx() { DataSource = dtNewWork };
                    xr.CreateDocument();
                    xr.PrintingSystem.ShowMarginsWarning = false;
                    xr.ShowPreview();
                }
            }
        }

        /// <summary>
        /// 逐個單元格填充Excel
        /// </summary>
        private void ExportToExcelByCell(string FileName)
        {
            int rowscount = dgvMoInfo.Rows.Count;
            int colscount = dgvMoInfo.Columns.Count;
            //创建空EXCEL对象
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objSheet = null;
            Microsoft.Office.Interop.Excel.Range rg = null;

            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.Worksheets[1];//强制类型转换
                //设置EXCEL不可见(后台运行)   
                objExcel.Visible = false;

                int displayColumnsCount = 1;  // Excel 起始列

                //向Excel中写入表格的標題   
                for (int i = 1; i <= colscount - 1; i++)
                {
                    objSheet.Cells[1, displayColumnsCount] = dgvMoInfo.Columns[i].HeaderText.Trim();
                    displayColumnsCount++;
                }

                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= rowscount - 1; row++)
                {
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (col > 0)
                        {
                            if (col == 18)
                            {
                                string RangeName = "R" + (row + 2);  //圖片顯示欄
                                string PicturePath = clsUtility.FormatNullableString(dgvMoInfo.Rows[row].Cells[col].Value);//圖片路徑
                                if (PicturePath != "" && File.Exists(PicturePath))
                                {
                                    rg = (Microsoft.Office.Interop.Excel.Range)objSheet.get_Range(RangeName, Missing.Value);//图片在單元格中的坐标
                                    float PicLeft, PicTop; //图片在單元格中的停靠位置（单位：points）
                                    PicLeft = Convert.ToSingle(rg.Left + 0.5);
                                    PicTop = Convert.ToSingle(rg.Top + 0.5);
                                    float PicWidth, PicHeight;//圖片在單元格中的寬、高（单位：points）
                                    PicWidth = 60;
                                    PicHeight = 60;
                                    objSheet.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse,
                                        Microsoft.Office.Core.MsoTriState.msoTrue, PicLeft, PicTop, PicWidth, PicHeight);
                                }
                            }
                            else
                            {
                                if (col == 3 || col == 10 || col == 11 || col == 17)
                                    objSheet.Cells[row + 2, displayColumnsCount] = "=\"" + clsUtility.FormatNullableString(dgvMoInfo.Rows[row].Cells[col].Value) + "\"";
                                else
                                    objSheet.Cells[row + 2, displayColumnsCount] = clsUtility.FormatNullableString(dgvMoInfo.Rows[row].Cells[col].Value);
                            }
                            displayColumnsCount++;
                        }
                    }
                    ((Microsoft.Office.Interop.Excel.Range)objSheet.Rows[row + 2, System.Type.Missing]).RowHeight = 60; //行高
                    System.Windows.Forms.Application.DoEvents();
                }

                objSheet.Columns.EntireColumn.AutoFit();//列宽自适应
                //保存文件   
                objWorkbook.SaveAs(FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //关闭Excel应用   
            if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
            if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
            if (objExcel != null) objExcel.Quit();
            //清空工作表
            objSheet = null;
            //清空工作薄
            objWorkbook = null;
            objExcel = null;

            //强行杀死最近打开的excel进程
            ExpToExcel.KillProcess("EXCEL");

            MessageBox.Show(FileName + "\n\n导出成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 用工作流導出Excel
        /// </summary>
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

                for (int i = 0; i < dgvMoInfo.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += dgvMoInfo.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                        str += "\t";
                    }
                }
                sw.WriteLine(str);
                //写内容
                string col_value;
                for (int rowNo = 0; rowNo < dgvMoInfo.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvMoInfo.ColumnCount; columnNo++)
                    {
                        if (columnNo > 0)
                        {
                            col_value = clsUtility.FormatNullableString(dgvMoInfo.Rows[rowNo].Cells[columnNo].Value);
                            if (columnNo == 3 || columnNo == 10 || columnNo == 11 || columnNo == 16)
                                tempstr += "=\"" + col_value + "\"";
                            else
                                tempstr += col_value;
                            tempstr += "\t";
                        }
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        /// <summary>
        /// 加載 User上次查詢條件 
        /// </summary>
        private void InitQueryValue()
        {
            DataTable dtvalue = clsQueryValue.GetQueryValue(this.Name, DBUtility._user_id);
            if (dtvalue.Rows.Count > 0)
            {
                for (int i = 0; i < dtvalue.Rows.Count; i++)
                {
                    string strObj_id = dtvalue.Rows[i]["obj_id"].ToString();
                    string strOjb_Value = dtvalue.Rows[i]["obj_value"].ToString();

                    if (textDep1.Name == strObj_id)
                    {
                        textDep1.Text = strOjb_Value;
                    }
                    if (textDep2.Name == strObj_id)
                    {
                        textDep2.Text = strOjb_Value;
                    }

                    if (textMo1.Name == strObj_id)
                    {
                        textMo1.Text = strOjb_Value;
                    }
                    if (textMo2.Name == strObj_id)
                    {
                        textMo2.Text = strOjb_Value;
                    }
                    if (txtDat2.Name == strObj_id)
                    {
                        txtDat1.Text = strOjb_Value;
                        txtDat2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    }
                }
            }
        }

        private void dgvMoInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dgvMoInfo.RowHeadersWidth - 4,
               e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvMoInfo.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvMoInfo.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvMoInfo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 & e.ColumnIndex == 0)
            {
                Point p = dgvMoInfo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                p.Offset(dgvMoInfo.Left, dgvMoInfo.Top);
                CheckBox1.Location = p;
                CheckBox1.Size = dgvMoInfo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
                CheckBox1.Visible = true;
                CheckBox1.BringToFront();
            }
        }


    }
}
