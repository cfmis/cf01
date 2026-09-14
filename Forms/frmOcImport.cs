using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using cf01.CLS;
using System.Text.RegularExpressions;

namespace cf01.Forms
{
    public partial class frmOcImport : Form
    {
        public DataTable dtOcImport;
        private object tb;

        public frmOcImport()
        {
            InitializeComponent();
        }

        private void btnImputExcel_Click(object sender, EventArgs e)
        {
            dtOcImport.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel 文件|*.xlsx;*.xls";
            ofd.Title = "选择 Excel 文件";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                ImportExcelToDataTable(filePath);
                if (dtOcImport != null)
                {
                    dgvDetails.DataSource = dtOcImport; // 显示到 DataGridView
                }
                else
                {
                    MessageBox.Show("Excel 文件中没有工作表！");
                }
            }
        }

        private void ImportExcelToDataTable(string filePath)
        {
            //DataTable dt = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                string sheetName = "";
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    Console.WriteLine(sheet.Index + " - " + sheet.Name);
                    sheetName = sheet.Name;
                    break;
                }

                // 检查是否有工作表
                if (package.Workbook.Worksheets.Count == 0)
                {
                    return ; // 没有工作表，返回 null
                }

                // 获取第一个工作表
                ExcelWorksheet ws = package.Workbook.Worksheets[sheetName];
                int colCount = ws.Dimension.End.Column;
                int rowCount = ws.Dimension.End.Row;
                int rowTittle = 1000, startRow = 0, qtyCol = 0;
                string colName = "";
                string qtyVal = "";
                // 添加列（第一行作为表头）
                //for (int col = 1; col <= colCount; col++)
                //{
                //     colText=ws.Cells[1, col].Text.Trim();


                //    //dt.Columns.Add(ws.Cells[1, col].Text);
                //}

                // 添加数据行
                for (int row = 1; row <= rowCount; row++)
                {
                    DataRow newRow = dtOcImport.NewRow();
                    for (int col = 1; col <= colCount; col++)
                    {
                        colName = ws.Cells[row, col].Text.Trim();
                        //newRow[col - 1] = ws.Cells[row, col].Text;
                        if (colName == "QTY")
                        {
                            qtyCol = col;
                            rowTittle = row;
                            startRow = rowTittle + 1;
                        }
                        if (row > rowTittle)
                        {
                            colName = ws.Cells[rowTittle, col].Text.Trim();
                            qtyVal = ws.Cells[row, qtyCol].Text.Trim();
                            string colVal = ws.Cells[row, col].Text.Trim();
                            string fName = "";
                            if (qtyVal != "")
                            {
                                fName= SetFieldName(colName);
                                
                                if (fName != "")
                                {
                                    if (fName == "unit_price" || fName == "qty" || fName == "amt")
                                        newRow[fName] = Convert.ToDecimal(colVal);
                                    else
                                        newRow[fName] = colVal;
                                    if(fName== "item_name")//從產品描述中獲取客人產品尺寸
                                    {
                                        //string input = "MK(CF) S/SNAP 10mm-HIDDE";
                                        string goods_name = colVal.ToLower();
                                        Match m = Regex.Match(goods_name, @"\d+mm");
                                        if (m.Success)
                                        {
                                            newRow["size_name"] = m.Value; // 输出 10mm
                                        }
                                    }
                                    newRow["cust_code"] = txtCust.Text;
                                    newRow["mo_type"] = txtMoType.Text;
                                    newRow["mo_dep"] = cmbMoDep.SelectedValue != null ? cmbMoDep.SelectedValue.ToString() : "";
                                    newRow["mo_group"] = txtMoGroup.Text;
                                    newRow["season_id"] = cmbSeason.SelectedValue != null ? cmbSeason.SelectedValue.ToString() : "";
                                    newRow["brand_id"] = txtBrand.Text;
                                    newRow["oc_type"]= cmbOcType.SelectedValue != null ? cmbOcType.SelectedValue.ToString() : "E";
                                    newRow["order_date"] = txtOrderDate.Text;
                                }
                                    
                            }
                            
                        }
                    }
                    if (qtyVal != "")
                        dtOcImport.Rows.Add(newRow);
                }
            }

            //return dt;
        }

        private string SetFieldName(string colName)
        {
            string fName = "";
            if (colName == "SEASON")
                fName = "season";
            else if (colName == "M/S")
                fName = "m_s";
            else if (colName == "BUYER")
                fName = "buyer";
            else if (colName == "ORDER")
                fName = "cs_order";
            else if (colName == "ITEM CODE")
                fName = "item_code";
            else if (colName == "ITEM NAME")
                fName = "item_name";
            else if (colName == "COLOR")
                fName = "color";
            else if (colName == "CANCEL")
                fName = "cancel";
            else if (colName == "UNIT\nPRICE")
                fName = "unit_price";
            else if (colName == "CURR")
                fName = "curr";
            else if (colName == "QTY")
                fName = "qty";
            else if (colName == "UNIT")
                fName = "unit";
            else if (colName == "AMT")
                fName = "amt";
            else if (colName == "PRODUCT")
                fName = "product_date";
            else if (colName == "PO")
                fName = "po";
            else if (colName == "PO\nBatch")
                fName = "po_batch";
            else if (colName == "PO Date")
                fName = "po_date";
            else if (colName == "SHIP TO")
                fName = "ship_to";
            else if (colName == "DELIVERY")
                fName = "delivery";
            else if (colName == "Color Confirm")
                fName = "color_confirm";
            else if (colName == "RM NO")
                fName = "rm_no";
            else if (colName == "Revise Date")
                fName = "revise_date";
            else if (colName == "REMARKS")
                fName = "remarks";
            else if (colName == "SEASON1")
                fName = "season1";
            else if (colName == "DIVISION")
                fName = "division";
            else if (colName == "ORDER\nPURPOSE")
                fName = "order_purpose";
            return fName;
        }

        private void frmOcImput_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            InitData();
            GetOcData();

            // 让 "Code" 和 "Name" 列单击即可编辑，其他列只读
            string[] filed_group = new string[] {
                "colCustCode", "colBrand", "colMoType", "colMoDep", "colMoGroup","colHkReqDate","colOrderDate" };
            EnableSingleClickEditByColumnName(dgvDetails, filed_group);

            ForceUpperCaseByColumnName(dgvDetails, filed_group);

            // 数据绑定完成后调用
            ForceDateFormatByColumnName(dgvDetails, new string[] { "colOrderDate", "colHkReqDate" });

        }
        private void InitData()
        {
            int fixedCount = 6; // 要固定的列数
            for (int i = 0; i < fixedCount; i++)
            {
                dgvDetails.Columns[i].Frozen = true;
            }
            DataTable dtSeason = clsBaseData.LoadSeason();
            cmbSeason.DataSource = dtSeason;
            cmbSeason.DisplayMember = "id";
            cmbSeason.ValueMember = "id";

            DataTable dtMoGroup = clsBaseData.LoadMoGroup("");
            cmbMoDep.DataSource = dtMoGroup;
            cmbMoDep.DisplayMember = "group_id";
            cmbMoDep.ValueMember = "group_id";

            DataTable dtOcType = clsBaseData.GetOcType();
            cmbOcType.DataSource = dtOcType;
            cmbOcType.DisplayMember = "id";
            cmbOcType.ValueMember = "id";

            txtMoType.Text = "G";
            cmbMoDep.SelectedValue = "B";
            txtMoGroup.Text = clsBaseData.GetUserGroup();
            if (txtMoGroup.Text == "")
                txtMoGroup.Text = "L";
            if (txtMoGroup.Text == "L")
            {
                txtCust.Text = "DO-S0487";
                txtBrand.Text = "MICH-05";
            }
            txtOrderDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            cmbOcType.SelectedValue = "E";

        }
        private void GetOcData()
        {
            dtOcImport = clsOcImport.GetOcData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if(dtOcImport.Rows.Count==0)
            {
                MessageBox.Show("沒有要儲存的記錄!");
                return;
            }
            string Rresult=clsOcImport.Save(dtOcImport);
        }

        /// <summary>
        /// 设置 DataGridView 指定列单击即进入编辑状态（按列名）
        /// </summary>
        /// <param name="dgv">目标 DataGridView</param>
        /// <param name="editableColumnNames">允许单击编辑的列名数组</param>
        public void EnableSingleClickEditByColumnName(DataGridView dgv, string[] editableColumnNames)
        {
            dgv.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string colName = dgv.Columns[e.ColumnIndex].Name;
                    if (editableColumnNames.Contains(colName))
                    {
                        dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgv.BeginEdit(true); // 单击即进入编辑
                    }
                }
            };

            // 设置其他列为只读
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (!editableColumnNames.Contains(col.Name))
                {
                    col.ReadOnly = true;
                }
            }
        }


        /// <summary>
        /// 强制指定列输入为大写（按列名）
        /// </summary>
        /// <param name="dgv">目标 DataGridView</param>
        /// <param name="columnNames">需要强制大写的列名数组</param>
        public void ForceUpperCaseByColumnName(DataGridView dgv, string[] columnNames)
        {
            dgv.EditingControlShowing += (s, e) =>
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    string colName = dgv.CurrentCell.OwningColumn.Name;
                    if (columnNames.Contains(colName))
                    {
                        tb.CharacterCasing = CharacterCasing.Upper; // 输入时自动转大写
                    }
                    else
                    {
                        tb.CharacterCasing = CharacterCasing.Normal; // 其他列保持正常
                    }
                }
            };
        }


        /// <summary>
        /// 强制指定列输入为 yyyy/MM/dd 格式（按列名）
        /// </summary>
        /// <param name="dgv">目标 DataGridView</param>
        /// <param name="columnNames">需要强制日期格式的列名数组</param>
        public void ForceDateFormatByColumnName(DataGridView dgv, string[] columnNames)
        {
            dgv.CellEndEdit += (s, e) =>
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string colName = dgv.Columns[e.ColumnIndex].Name;

                if (columnNames.Contains(colName) && cell.Value != null)
                {
                    DateTime dt;
                    if (DateTime.TryParse(cell.Value.ToString(), out dt))
                    {
                        cell.Value = dt.ToString("yyyy/MM/dd"); // 转换为指定格式
                    }
                    else
                    {
                        // 如果输入不是有效日期，可以清空或提示
                        cell.Value = null;
                    }
                }
            };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
