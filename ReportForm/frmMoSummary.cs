using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cf01.CLS;
using cf01.Forms;
using System.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;

namespace cf01.ReportForm
{
    public partial class frmMoSummary : Form
    {
        DataTable dtOc = new DataTable();
        public frmMoSummary()
        {
            InitializeComponent();
        }

        

        private void frmMoSummary_Load(object sender, EventArgs e)
        {
            SetCombox();
        }

        private void SetCombox()
        {
            //////組別
            cmbMoGroup.DataSource = clsBaseData.LoadMoGroup("");
            cmbMoGroup.ValueMember = "group_id";
            cmbMoGroup.DisplayMember = "group_desc";

            //////完成狀態
            cmbIsComplete.DataSource = clsBaseData.loadDocFlag("CP", "Y");
            cmbIsComplete.ValueMember = "flag_id";
            cmbIsComplete.DisplayMember = "flag_cdesc";
        }

        

        private void cmdFind_Click(object sender, EventArgs e)
        {
            txtMo.Focus();
            if(txtDateFrom.Text==""&&txtDateTo.Text=="" && txtMo.Text=="")
            {
                MessageBox.Show("查詢不能為空!");
                txtDateFrom.Focus();
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            FindData();
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void FindData()
        {
            string moGroup = "";
            string dateFrom = "", dateTo = "";
            string productMoFrom = "", createBy = "";
            string isAPart = "0";
            string isComplete = "01";
            productMoFrom = txtMo.Text;
            moGroup = cmbMoGroup.SelectedValue.ToString().Trim();
            dateFrom = txtDateFrom.Text.Trim();
            dateTo = txtDateTo.Text.Trim();
            createBy = txtCreateBy.Text;
            if (chkShowAPart.Checked == true)
                isAPart = "1";
            if (cmbIsComplete.SelectedValue==null || cmbIsComplete.SelectedValue.ToString().Trim() == "00")
                isComplete = "01";
            else
                isComplete = cmbIsComplete.SelectedValue.ToString().Trim();
            SqlParameter[] parameters = {
                new SqlParameter("@cp_state", isComplete)
                ,new SqlParameter("@check_crdat1", dateFrom), new SqlParameter("@check_crdat2", dateTo)
                ,new SqlParameter("@mo_group", moGroup)
                ,new SqlParameter("@mo_id", productMoFrom)
                ,new SqlParameter("@create_by", createBy)
                ,new SqlParameter("@goods_part", isAPart)

            };
            dtOc = clsPublicOfCF01.ExecuteProcedureReturnTable("dgerp2.cferp.dbo.z_load_mo_summary", parameters);
            gcOc.DataSource = dtOc;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportToExce_Click(object sender, EventArgs e)
        {
            if(dtOc.Rows.Count==0)
            {
                MessageBox.Show("沒有匯出的記錄!");
                return;
            }
            ExpToExcel();
        }
        private void ExpToExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            string fileName = "頁數匯總";
            saveFile.FileName = fileName;
            saveFile.Filter = "Excel files(*.xlsx)|*.xlsx";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFile.FileName;
            }
            if (fileName == "")
                return;

            using (var package = new ExcelPackage())
            {

                string sheet_name = "Sheet1";


                var wSheet = package.Workbook.Worksheets.Add(sheet_name);
                wSheet.PrinterSettings.PaperSize = ePaperSize.A4; // 设置纸张为 A4
                wSheet.PrinterSettings.Orientation = eOrientation.Portrait; // 设置页面纵向
                                                                            // worksheet.PrinterSettings.Orientation = eOrientation.Landscape; // 设置页面横向
                wSheet.PrinterSettings.TopMargin = (decimal)(0.17 / 2.54);    // 上边距，0.17 厘米
                wSheet.PrinterSettings.BottomMargin = (decimal)(0.17 / 2.54); // 下边距，0.17 厘米
                wSheet.PrinterSettings.LeftMargin = (decimal)(0.17 / 2.54);   // 左边距，0.17 厘米
                wSheet.PrinterSettings.RightMargin = (decimal)(0.17 / 2.54);  // 右边距，0.17 厘米
                int excelRow = 1;
                wSheet.Cells[excelRow, 1].Value = "新增期";
                wSheet.Cells[excelRow, 2].Value = "組別";
                wSheet.Cells[excelRow, 3].Value = "未完成頁數";
                wSheet.Cells[excelRow, 4].Value = "計劃回港期";
                wSheet.Cells[excelRow, 5].Value = "客人落單期";
                wSheet.Cells[excelRow, 6].Value = "要求完成期";
                wSheet.Cells[excelRow, 7].Value = "牌子編號";

                wSheet.Cells[excelRow, 8].Value = "客戶編號";
                wSheet.Cells[excelRow, 9].Value = "開單人";
                wSheet.Cells[excelRow, 10].Value = "急/特急狀態";
                wSheet.Cells[excelRow, 11].Value = "有否採購";
                wSheet.Cells[excelRow, 12].Value = "制單備註/備註";
                wSheet.Cells[excelRow, 13].Value = "當前部門";
                wSheet.Cells[excelRow, 14].Value = "經過部門";

                wSheet.Cells[excelRow, 15].Value = "配件編號";
                wSheet.Cells[excelRow, 16].Value = "主件";
                wSheet.Cells[excelRow, 17].Value = "物料編號";
                wSheet.Cells[excelRow, 18].Value = "物料描述";
                wSheet.Cells[excelRow, 19].Value = "下部門";
                wSheet.Cells[excelRow, 20].Value = "洋行代號";
                wSheet.Cells[excelRow, 21].Value = "訂單數量";

                wSheet.Cells[excelRow, 22].Value = "數量單位";
                wSheet.Cells[excelRow, 23].Value = "已回港日期";
                wSheet.Cells[excelRow, 24].Value = "已回港數量(PCS)";
                wSheet.Cells[excelRow, 25].Value = "OC編號";
                wSheet.Cells[excelRow, 26].Value = "客人產品編號";
                wSheet.Cells[excelRow, 27].Value = "客人顏色編號";

                wSheet.Cells[excelRow, 28].Value = "倉(採購)直接發貨";
                wSheet.Cells[excelRow, 29].Value = "顏色編號";
                wSheet.Cells[excelRow, 30].Value = "顏色做法";
                wSheet.Cells[excelRow, 31].Value = "過期天數";
                wSheet.Cells[excelRow, 32].Value = "當前部門";
                wSheet.Row(excelRow).Height = 20; // 设置第 1 行的高度为 20 点
                excelRow++;
                for (int i = 0; i < dtOc.Rows.Count; i++)
                {
                    DataRow dr = dtOc.Rows[i];
                    // 设置 A1 单元格为文本格式
                    var cell = wSheet.Cells[excelRow, 1];
                    cell.Style.Numberformat.Format = "@";
                    //cell.Value = "00123"; // 前导零不会被去掉"\'" + 
                    cell.Value = dr["check_date"].ToString();
                    wSheet.Cells[excelRow, 2].Value = dr["mo_group"].ToString();
                    wSheet.Cells[excelRow, 3].Value = dr["mo_id"].ToString();
                    cell = wSheet.Cells[excelRow, 4];
                    cell.Style.Numberformat.Format = "@";
                    cell.Value = dr["hk_req_date"].ToString();
                    cell = wSheet.Cells[excelRow, 5];
                    cell.Style.Numberformat.Format = "@";
                    cell.Value = dr["order_date"].ToString();
                    cell = wSheet.Cells[excelRow, 6];
                    cell.Style.Numberformat.Format = "@";
                    cell.Value = dr["cs_req_date"].ToString();
                    wSheet.Cells[excelRow, 7].Value = dr["brand_id"].ToString();
                    wSheet.Cells[excelRow, 8].Value = dr["cust_code"].ToString();
                    wSheet.Cells[excelRow, 9].Value = dr["create_by"].ToString();
                    wSheet.Cells[excelRow, 10].Value = "";
                    wSheet.Cells[excelRow, 11].Value = "";// dr["urgent"].ToString();
                    wSheet.Cells[excelRow, 12].Value = dr["remark"].ToString().Trim() + "\r\n" + dr["production_remark"].ToString().Trim();
                    wSheet.Cells[excelRow, 13].Value = dr["curr_dep"].ToString();
                    wSheet.Cells[excelRow, 14].Value = dr["pass_dep"].ToString();
                    wSheet.Cells[excelRow, 15].Value = dr["goods_part"].ToString();
                    wSheet.Cells[excelRow, 16].Value = dr["a_part"].ToString();
                    wSheet.Cells[excelRow, 17].Value = dr["goods_id"].ToString();
                    wSheet.Cells[excelRow, 18].Value = dr["goods_name"].ToString();
                    cell = wSheet.Cells[excelRow, 19];
                    cell.Style.Numberformat.Format = "@";
                    cell.Value = dr["curr_next_dep"].ToString();
                    wSheet.Cells[excelRow, 20].Value = dr["agent"].ToString();
                    wSheet.Cells[excelRow, 21].Value = dr["order_qty"].ToString();
                    wSheet.Cells[excelRow, 22].Value = dr["goods_unit"].ToString();
                    wSheet.Cells[excelRow, 23].Value = dr["act_to_hk_date"].ToString();
                    wSheet.Cells[excelRow, 24].Value = dr["act_to_hk_qty_pcs"].ToString();
                    wSheet.Cells[excelRow, 25].Value = dr["id"].ToString();
                    wSheet.Cells[excelRow, 26].Value = dr["customer_goods"].ToString();
                    wSheet.Cells[excelRow, 27].Value = dr["customer_color_id"].ToString();
                    wSheet.Cells[excelRow, 28].Value = "";
                    wSheet.Cells[excelRow, 29].Value = dr["color_name"].ToString();
                    wSheet.Cells[excelRow, 30].Value = dr["do_color"].ToString();
                    int period_day = dr["period_day"].ToString() != "" ? Convert.ToInt32(dr["period_day"].ToString()) : 0;
                    wSheet.Cells[excelRow, 31].Value = period_day;
                    wSheet.Cells[excelRow, 32].Value = dr["curr_dep_cdesc"].ToString();
                    wSheet.Row(excelRow).Height = 20; // 设置第 1 行的高度为 20 点
                    int maxCol = 32;
                    if (period_day > 0)
                    {
                        // 设置整行背景为红色
                        for (int col = 1; col <= maxCol; col++)
                        {
                            wSheet.Cells[excelRow, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            wSheet.Cells[excelRow, col].Style.Fill.BackgroundColor.SetColor(Color.Red);
                        }
                    }
                    excelRow++;
                }
                excelRow--;
                wSheet.Column(1).Width = 10;
                wSheet.Column(2).Width = 6;
                wSheet.Column(3).Width = 10;
                wSheet.Column(4).Width = 10;
                wSheet.Column(5).Width = 10;
                wSheet.Column(6).Width = 16;
                wSheet.Column(7).Width = 12;
                wSheet.Column(8).Width = 12;
                wSheet.Column(9).Width = 8;
                wSheet.Column(10).Width = 10;
                wSheet.Column(11).Width = 8;
                wSheet.Column(12).Width = 20;
                wSheet.Column(13).Width = 20;
                wSheet.Column(14).Width = 30;
                wSheet.Column(15).Width = 20;
                wSheet.Column(16).Width = 6;
                wSheet.Column(17).Width = 20;
                wSheet.Column(18).Width = 28;
                wSheet.Column(19).Width = 20;
                wSheet.Column(20).Width = 8;
                wSheet.Column(21).Width = 10;
                wSheet.Column(22).Width = 6;
                wSheet.Column(23).Width = 10;
                wSheet.Column(24).Width = 10;
                wSheet.Column(25).Width = 12;
                wSheet.Column(26).Width = 18;
                wSheet.Column(27).Width = 16;
                wSheet.Column(28).Width = 8;
                wSheet.Column(29).Width = 18;
                wSheet.Column(30).Width = 18;
                wSheet.Column(31).Width = 8;
                wSheet.Column(32).Width = 18;

                // 设置动态范围
                string colStr = $"E1:E{excelRow}"; // 动态计算行数
                wSheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
                colStr = $"F1:F{excelRow}"; // 动态计算行数
                wSheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
                colStr = $"G1:G{excelRow}"; // 动态计算行数
                wSheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式
                colStr = $"H1:H{excelRow}"; // 动态计算行数
                wSheet.Cells[colStr].Style.Numberformat.Format = "#,##0"; // 千分位整数格式

                // 动态确定表格范围
                //string tableRange = $"A1:R{worksheet.Dimension.End.Row}"; // 表格范围
                string tableRange = $"A1:{ExcelAddress.GetAddress(wSheet.Dimension.End.Row, wSheet.Dimension.End.Column)}";
                var tableCells = wSheet.Cells[tableRange];

                // 为整个表格添加边框
                tableCells.Style.Border.BorderAround(ExcelBorderStyle.Thick); // 表格外边框设置为粗线
                tableCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;    // 表格顶部边框
                tableCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; // 表格底部边框
                tableCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;   // 表格左边边框
                tableCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;  // 表格右边边框
                tableCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // 垂直居中
                // 设置整个表格的字体大小
                tableCells.Style.Font.Size = 10; // 设置字体大小为10
                tableCells.Style.Font.Name = "新細明體";
                // 冻结窗口
                wSheet.View.FreezePanes(2, 1); // 从第4行、第4列开始滚动，冻结第一行
                // 设置打印标题行（固定第 1~2 行为标题）
                wSheet.PrinterSettings.RepeatRows = wSheet.Cells["1:1"]; // 固定标题为第1~2行
                // 获取第3行的有效列范围
                int lastCol = wSheet.Dimension.End.Column;
                // 设置第1行为自动筛选行
                wSheet.Cells[1, 1, 1, lastCol].AutoFilter = true;


                // 设置整个表格内容自动换行
                tableCells.Style.WrapText = true;

                // 保存 Excel 文件
                FileInfo file = new FileInfo(fileName);
                package.SaveAs(file);
                MessageBox.Show("Excel 文件导出成功！");
            }

        }
    }
}
