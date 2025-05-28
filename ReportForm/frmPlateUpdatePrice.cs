using cf01.CLS;
using cf01.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace cf01.ReportForm
{
    public partial class frmPlateUpdatePrice : Form
    {
        bool flagInport;
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtUpdate = new System.Data.DataTable();

        public frmPlateUpdatePrice()
        {
            InitializeComponent();
        }

        private void frmPlateUpdatePrice_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("doc_id", typeof(string));
            dt.Columns.Add("issue_date", typeof(string));
            dt.Columns.Add("delivery_id", typeof(string));
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("sequence_id", typeof(string));
            dt.Columns.Add("mo_id", typeof(string));
            dt.Columns.Add("goods_id", typeof(string));
            dt.Columns.Add("goods_name", typeof(string));
            dt.Columns.Add("color", typeof(string));
            dt.Columns.Add("qty", typeof(decimal));
            dt.Columns.Add("sec_qty", typeof(decimal));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("p_unit", typeof(string));
            dt.Columns.Add("amt", typeof(decimal));
            dt.Columns.Add("remark", typeof(string));
            dt.Columns.Add("quotation_id", typeof(string));
            dt.Columns.Add("other_unit", typeof(string));
            dt.Columns.Add("other_price", typeof(decimal));
            dt.Columns.Add("confirm_flag", typeof(string));
            dt.Columns.Add("update_by", typeof(string));
            dt.Columns.Add("key_id", typeof(string));
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            flagInport = false;
            LoadExcel();
            if (flagInport)  //導入EXCEL成功
            {
                //檢查資料的完整性
                DataRow[] drs = dt.Select("remark='' and p_unit=''");
                if (drs.Length > 0)
                {
                    string msg = $"EXCEL資料中的【{drs[0]["id"]}】頁數【{drs[0]["mo_id"]}】中的單價單位不可為空，請返回檢查！";
                    MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ;
                }
                dt.Select();
                //保存匯入的EXCEL數據                
                SaveExcelData();
                if (!flagInport)
                {
                    MessageBox.Show("保存匯入的EXCEL數據失敗！", "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                dgv1.DataSource = dt;
                MessageBox.Show("EXCEL匯入成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

        private void LoadExcel()
        {           
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "excel|*.xls;*.xlsx", FilterIndex = 0, RestoreDirectory = true, Title = "導入匯總文件路徑", FileName = null };            
            openFileDialog1.ShowDialog();           
            string FileName = openFileDialog1.FileName;
            Refresh();
            if (FileName != "")
            {
                //導入EXCEL頁數
                try
                {
                    // ExcelToDatable(FileName, 1); //old code                 
                    //dt = clsPublic.ImputExcelToTable(FileName);
                    if (ExcelToDatable2(FileName))
                        flagInport = true;
                    else
                        flagInport = false;
                }
                catch (SqlException E)
                {
                    flagInport = false;
                    throw new Exception(E.Message);
                }
            }
        }
       

        private bool ExcelToDatable2(string fileName)
        {           
            if (fileName == "")
            {                
                return false;
            }
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(fileName);
            Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            Microsoft.Office.Interop.Excel.Range lastCellRow = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
                Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
                false, System.Reflection.Missing.Value, System.Reflection.Missing.Value
            );
            Microsoft.Office.Interop.Excel.Range lastCellCol = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
                Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
                false, System.Reflection.Missing.Value, System.Reflection.Missing.Value
            );
            int lastRow = lastCellRow.Row;
            int lastColumn = lastCellCol.Column;//共14列                 
            int colIssueDate = -1, colDeliveryId = -1, colId = -1, colMoId = -1, colGoodsId = -1, colGoodsName = -1, colColor = -1, colQty = -1, colSecQty = -1;
            int colPrice = -1, colPunit = -1, colAmt = -1, colRemark = -1, colQuotationId = -1;
            string errStr = "", colTitle = "";
            errStr = "送貨日期|送貨單號|外發單號|頁數|產品編碼|產品名稱及規格|產品顏色|數量|重量|單價|單價單位|金額|備註|報價單號";
            for (int i = 1; i <= lastColumn; i++)
            {
                colTitle = (worksheet.Cells[1, i] as Range).Value.ToString().Trim();
                switch (colTitle)
                {
                    case "送貨日期":
                        colIssueDate = i;
                        break;
                    case "送貨單號":
                        colDeliveryId = i;
                        break;
                    case "外發單號":
                        colId = i;
                        break;
                    case "頁數":
                        colMoId = i;
                        break;
                    case "產品編碼":
                        colGoodsId = i;
                        break;
                    case "產品名稱及規格":
                        colGoodsName = i;
                        break;
                    case "產品顏色":
                        colColor = i;
                        break;
                    case "數量":
                        colQty = i;
                        break;
                    case "重量":
                        colSecQty = i;
                        break;
                    case "單價":
                        colPrice = i;
                        break;
                    case "單價單位":
                        colPunit = i;
                        break;
                    case "金額":
                        colAmt = i;
                        break;
                    case "備註":
                        colRemark = i;
                        break;
                    case "報價單號":
                        colQuotationId = i;
                        break;
                }
            }
            if (colIssueDate == -1 || colDeliveryId == -1 || colId == -1 || colMoId == -1 || colGoodsId == -1 || colGoodsName == -1 || colColor == -1 || 
                colQty == -1 || colSecQty == -1  || colPrice == -1 || colPunit == -1 || colAmt == -1 || colRemark == -1 || colQuotationId == -1)
            {
                MessageBox.Show($"未找到匹配為:{errStr}的列!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            Graphics g = progressBar1.CreateGraphics();
            System.Drawing.Font mf = new System.Drawing.Font("Arial", 9);
            Brush mb = System.Drawing.Brushes.White;
            System.Drawing.Point mp = new System.Drawing.Point(10, 0);
            
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;           
            
            int row_total = lastRow;//總行數           
            progressBar1.Maximum = row_total;
            string issue_date = "", delivery_id = "", id = "", mo_id = "", goods_id = "", goods_name = "", color = "", p_unit = "", remark = "", quotation_id = "";
            decimal amt = 0, qty = 0, sec_qty = 0, price = 0;
            string docId = clsQuotationSample.GetSerialNo();
            string moId = "", seqId = "", userId = "";
            userId = DBUtility._user_id;
            dt.Clear();
            // 读取该列的值worksheet.UsedRange.Rows.Count
            for (int row = 2; row <= lastRow; row++)
            {
                progressBar1.Value += progressBar1.Step;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;
                }              
                g.DrawString("正在導入EXCEL文件...", mf, mb, mp);
                //System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();

                amt = decimal.Parse((worksheet.Cells[row, colAmt] as Range).Value?.ToString().Trim());//金額
                if (amt > 0)
                {
                    DataRow dr = dt.NewRow();                    
                    dr["amt"] = Math.Round(amt, 2);
                    dr["doc_id"] = docId;
                    issue_date = (worksheet.Cells[row, colIssueDate] as Range).Value?.ToString().Trim();
                    issue_date = issue_date != null ? issue_date : "";  //送貨日期                
                    dr["issue_date"] = (issue_date != "") ? DateTime.Parse(issue_date).Date.ToString("yyyy/MM/dd") : "";                    
                    delivery_id = (worksheet.Cells[row, colDeliveryId] as Range).Value?.ToString().Trim();
                    delivery_id = delivery_id != null ? delivery_id : "";
                    dr["delivery_id"] = delivery_id; //送貨單號
                    id = (worksheet.Cells[row, colId] as Range).Value?.ToString().Trim();
                    id = id != null ? id : "";
                    dr["id"] = id;//委外單號
                    mo_id = (worksheet.Cells[row, colMoId] as Range).Value?.ToString().Trim();
                    moId = mo_id != null ? mo_id : "";//頁數,序號                   
                    seqId = (moId.Length >= 12) ? "00" + moId.Substring(10, 2) + "h" : "ZZ";
                    dr["sequence_id"] = seqId;
                    dr["mo_id"] = moId;                   
                    goods_id = (worksheet.Cells[row, colGoodsId] as Range).Value?.ToString().Trim();
                    goods_id = goods_id != null ? goods_id : "";
                    dr["goods_id"] = goods_id; //貨品編號
                    goods_name = (worksheet.Cells[row, colGoodsName] as Range).Value?.ToString().Trim();
                    goods_name = goods_name != null ? goods_name : "";
                    dr["goods_name"] = goods_name; //貨品名稱
                    color = (worksheet.Cells[row, colColor] as Range).Value?.ToString().Trim();
                    color = color != null ? color : "";
                    dr["color"] = color; //顏色
                    qty = decimal.Parse((worksheet.Cells[row, colQty] as Range).Value?.ToString());
                    dr["qty"] = qty;//數量
                    sec_qty = decimal.Parse((worksheet.Cells[row, colSecQty] as Range).Value?.ToString());
                    dr["sec_qty"] = sec_qty;//重量
                    price = decimal.Parse((worksheet.Cells[row, colPrice] as Range).Value?.ToString());
                    dr["price"] = price;//單價
                    p_unit = (worksheet.Cells[row, colPunit] as Range).Value?.ToString().Trim();
                    p_unit = p_unit != null ? p_unit : "";                    
                    dr["p_unit"] = p_unit; //單價單位                     
                    remark = (worksheet.Cells[row, colRemark] as Range).Value?.ToString().Trim();
                    remark = remark != null ? remark : "";
                    dr["remark"] = remark; //"備註
                    quotation_id = (worksheet.Cells[row, colQuotationId] as Range).Value?.ToString().Trim();
                    quotation_id = quotation_id != null ? quotation_id : "";
                    dr["quotation_id"] = quotation_id;//報價單號                    
                    dr["key_id"] = row.ToString();//序號
                    dr["confirm_flag"] = "0";
                    dr["update_by"] = userId;
                    dt.Rows.Add(dr);
                } // --end if(amt>0)
            } //--end for
            workbook.Close(false);
            excelApp.Quit();

            progressBar1.Enabled = false;
            progressBar1.Visible = false;            

            dtUpdate.Clear();
            dtUpdate = dt.Clone();
            dtUpdate.Columns.Add("sec_price", typeof(decimal));
            dtUpdate.Columns.Add("p_sec_unit", typeof(string));                
            return true;           
        }



        private void ExcelToDatable(string excelFiles, int sheetId)
        {
            //將導入的EXCEL轉成Datatble
            
            //创建Application对象             
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();//{ Visible = true };                  
            Microsoft.Office.Interop.Excel.Workbook xBook = xApp.Workbooks._Open(excelFiles,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value
            , Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet xSheet = (Microsoft.Office.Interop.Excel.Worksheet)xBook.Sheets[sheetId];
            
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            string p_unit = "";
            int row_precessing = 0;
            int row_total = xSheet.UsedRange.Rows.Count;//總行數
            decimal amt = 0;
            progressBar1.Maximum = row_total;
           
            Microsoft.Office.Interop.Excel.Range rng;
            try
            {
                string docId = clsQuotationSample.GetSerialNo();
                string moId = "", seqId = "", userId = "";             
                userId = DBUtility._user_id;
                dt.Clear();
                for (int ii = 2; ii <= row_total; ii++)
                {
                    row_precessing = ii;//記錄更在更新的行
                    progressBar1.Value += progressBar1.Step;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Enabled = false;
                        progressBar1.Visible = false;
                    }                   
                    //A欄:送貨日期,B欄:送貨單號,C欄:委外單號;D欄:頁數+序號;E欄:貨品編號,F欄:貨品名稱,G欄:顏色,H欄:數量;I欄:重量;J欄:单价;K欄:單價單位;L欄:金額;M欄:備註;N欄:報價單號,O:序號
                    rng = xSheet.Cells[ii, "L"]; //金額
                    if (rng.get_Value() > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["amt"] = rng.get_Value(); //金額  L
                        dr["amt"] = Math.Round(decimal.Parse(dr["amt"].ToString()), 2);
                        dr["doc_id"] = docId;
                        rng = xSheet.Cells[ii,"A"]; //送貨日期 A                        
                        dr["issue_date"] = rng.get_Value();
                        dr["issue_date"] = DateTime.Parse(dr["issue_date"].ToString()).Date.ToString("yyyy/MM/dd");
                        rng = xSheet.Cells[ii, "B"]; //送貨單號 B                    
                        dr["delivery_id"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "C"]; //委外單號
                        dr["id"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "D"]; //頁數,序號
                        moId = rng.get_Value();
                        moId = moId.Trim();
                        if (moId.Length >= 12)
                        {
                            //GBE050852-01/ SBE030525-02
                            seqId = "00" + moId.Substring(10,2) + "h";
                            //moId = moId.Substring(0, 9);
                        }
                        else
                        {
                            seqId = "ZZ" ;
                        }
                        dr["sequence_id"] = seqId;
                        dr["mo_id"] = moId;
                        rng = xSheet.Cells[ii, "E"]; //貨品編號
                        dr["goods_id"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "F"]; //貨品名稱
                        dr["goods_name"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "G"]; //顏色
                        dr["color"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "H"]; //數量
                        dr["qty"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "I"]; //重量
                        dr["sec_qty"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "J"]; //单价
                        dr["price"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "K"]; //單價單位
                        p_unit = rng.get_Value();
                        p_unit = string.IsNullOrEmpty(p_unit) ? "" : p_unit.ToString();
                        dr["p_unit"] = p_unit;                        
                        rng = xSheet.Cells[ii, "M"]; //"備註
                        dr["remark"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "N"]; //"報價單號
                        dr["quotation_id"] = rng.get_Value();
                        //rng = xSheet.Cells[ii, "O"]; //"單價單位備註
                        //dr["other_unit"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "O"]; //序號
                        dr["key_id"] = rng.get_Value();
                        dr["confirm_flag"] = "0";
                        dr["update_by"] = userId;                        
                        dt.Rows.Add(dr);
                    }
                }
                xApp.Application.DisplayAlerts = false; //禁止彈出是否保存對話框
                xSheet = null;
                xBook = null;
                xApp.Quit(); //这一句是非常重要的，否则Excel对象不能从内存中退出 
                xApp = null;              
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                if (xApp != null)
                {
                    xApp.Quit();
                    xBook = null;
                    xSheet = null;
                    xBook.Close();
                    GC.Collect();
                }
            }
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            

            dtUpdate.Clear();
            dtUpdate = dt.Clone();
            dtUpdate.Columns.Add("sec_price", typeof(decimal));
            dtUpdate.Columns.Add("p_sec_unit", typeof(string));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            //更新前處理到一臨時表
            BeforeUpdate();
            //更新到GEO
            UpdateToGEO();
        }  //--end of button click
    
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ConverQtyUnit(string unit)
        {
            string result = "";
            switch (unit)
            {
                case "G":
                    result = "GRS";
                    break;
                case "GRS":
                    result = "GRS";
                    break;
                case "Grs":
                    result = "GRS";
                    break;
                case "DZ":
                    result = "DZ";
                    break;
                case "Dz":
                    result = "DZ";
                    break;
                case "PCS":
                    result = "PCS";
                    break;
                case "Pcs":
                    result = "PCS";
                    break;
                case "pcs":
                    result = "PCS";
                    break;
                case "SET":
                    result = "SET";
                    break;
                case "Set":
                    result = "SET";
                    break;
                case "set":
                    result = "SET";
                    break;                
            }
            return result;
        }

        private int GetQtyRate(string unit)
        {
            int rate = 0;
            switch (unit)
            {                
                case "GRS":
                    rate = 144;
                    break;
                case "DZ":
                    rate = 12;
                    break;
                case "PCS":
                    rate = 1;
                    break;
                case "SET":               
                    rate = 1;
                    break;
                case "H":
                    rate = 100;
                    break;
                case "K":
                    rate = 1000;
                    break;
            }
            return rate;
        }

        private void SaveExcelData()
        {
            //儲存原始對賬數據
            Graphics g = progressBar1.CreateGraphics();
            System.Drawing.Font mf = new System.Drawing.Font("Arial", 9);//宋体
            Brush mb = System.Drawing.Brushes.White;
            System.Drawing.Point mp = new System.Drawing.Point(10, 0);
            
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = dt.Rows.Count;
            string sqlUpdate = "", sqlFind = "", userId = "", id, sequenceId, issueDate = "", keyId = "", result = "";
            userId = DBUtility._user_id;           
            System.Data.DataTable dtFind = new System.Data.DataTable();

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    cmd.CommandTimeout = 1800;//連接30分鐘
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        g.DrawString("正在儲存原始對賬數據...", mf, mb, mp);
                        //System.Threading.Thread.Sleep(10);
                        System.Windows.Forms.Application.DoEvents();

                        id = dt.Rows[i]["id"].ToString();
                        sequenceId = dt.Rows[i]["sequence_id"].ToString();
                        keyId = dt.Rows[i]["key_id"].ToString();
                        issueDate = dt.Rows[i]["issue_date"].ToString();
                        issueDate = !string.IsNullOrEmpty(issueDate) ? DateTime.Parse(issueDate).Date.ToString("yyyy/MM/dd") : "";
                        sqlFind = string.Format(@"SELECT '1' FROM op_outpro_out_account WHERE id='{0}' And sequence_id='{1}' And key_id='{2}'", id, sequenceId, keyId);
                        dtFind = clsPublicOfCF01.GetDataTable(sqlFind);
                        result = (dtFind.Rows.Count > 0 && dtFind.Rows[0][0].ToString() != "") ? "1" : "";
                        if (result == "")
                        {
                            sqlUpdate = string.Format(
                            @"Insert Into op_outpro_out_account
                            (doc_id,issue_date,delivery_id,id,sequence_id,mo_id,goods_id,goods_name,color,qty,sec_qty,price,amt,remark,quotation_id,confirm_flag,update_by,update_date,p_unit,key_id)
                            Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},'{13}','{14}','0','{15}',getdate(),'{16}','{17}')",
                            dt.Rows[i]["doc_id"].ToString(), issueDate, dt.Rows[i]["delivery_id"].ToString(), id, sequenceId, dt.Rows[i]["mo_id"].ToString(),
                            dt.Rows[i]["goods_id"].ToString(), dt.Rows[i]["goods_name"].ToString(), dt.Rows[i]["color"].ToString(), decimal.Parse(dt.Rows[i]["qty"].ToString()),
                            decimal.Parse(dt.Rows[i]["sec_qty"].ToString()), decimal.Parse(dt.Rows[i]["price"].ToString()), decimal.Parse(dt.Rows[i]["amt"].ToString()),
                            dt.Rows[i]["remark"].ToString(), dt.Rows[i]["quotation_id"].ToString(), userId, dt.Rows[i]["p_unit"].ToString(), dt.Rows[i]["key_id"].ToString());
                        }
                        else
                        {
                            sqlUpdate = string.Format(
                            @"Update op_outpro_out_account 
                            SET doc_id='{3}',issue_date='{4}',delivery_id='{5}',mo_id='{6}',goods_id='{7}',goods_name='{8}',color='{9}',qty={10},sec_qty={11},price={12},amt={13},
                            remark='{14}',quotation_id='{15}',confirm_flag='0',update_by='{16}',update_date=getdate(),p_unit='{17}'
                            WHERE id ='{0}' And sequence_id ='{1}' And key_id ='{2}'", id, sequenceId, keyId,
                            dt.Rows[i]["doc_id"].ToString(), issueDate, dt.Rows[i]["delivery_id"].ToString(), dt.Rows[i]["mo_id"].ToString(),
                            dt.Rows[i]["goods_id"].ToString(), dt.Rows[i]["goods_name"].ToString(), dt.Rows[i]["color"].ToString(), decimal.Parse(dt.Rows[i]["qty"].ToString()),
                            decimal.Parse(dt.Rows[i]["sec_qty"].ToString()), decimal.Parse(dt.Rows[i]["price"].ToString()), decimal.Parse(dt.Rows[i]["amt"].ToString()),
                            dt.Rows[i]["remark"].ToString(), dt.Rows[i]["quotation_id"].ToString(), userId, dt.Rows[i]["p_unit"].ToString());
                        }
                        cmd.CommandText = sqlUpdate;
                        cmd.ExecuteNonQuery();
                    } //--end for                   
                }
                myTrans.Commit(); //數據提交               
                flagInport = true;
            }
            catch (Exception E)
            {
                myTrans.Rollback(); //數據回滾               
                flagInport = false;
                throw new Exception(E.Message);
            }
            finally
            {
                myCon.Close();
                myTrans.Dispose();
            }
            progressBar1.Enabled = false;
            progressBar1.Visible = false;                  
        }



        private void BeforeUpdate()
        {
            //對導入的EXCEL資料整理、加工分類，以便更新到外發加工單
            string tempRemark = "", tempPriceUnit = "", tempId = "", tempSeq = "", tmp_update_remark = "";
            decimal amt = 0, qty = 0, sec_qty = 0, price = 0, tempAmt = 0, priceUpdate = 0;                    
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtUpdate.NewRow();
                dr["id"] = dt.Rows[i]["id"].ToString();
                dr["sequence_id"] = dt.Rows[i]["sequence_id"].ToString();
                dr["price"] = 0;
                dr["sec_price"] = 0;
                dr["price"] = 0;
                dr["p_unit"] = "";
                dr["p_sec_unit"] = "";
                dtUpdate.Rows.Add(dr);
            }
            //去掉重復以便與外發加工單相一致
            dtUpdate = dtUpdate.AsEnumerable().Distinct(DataRowComparer.Default).CopyToDataTable();

            //更前的臨時表
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tempId = dt.Rows[i]["id"].ToString();
                tempSeq = dt.Rows[i]["sequence_id"].ToString();
                if (tempSeq == "ZZ")
                {
                    continue;
                }
                //備註不為空時有兩種情況：1最低消費，樣辦費
                tempRemark = string.IsNullOrEmpty(dt.Rows[i]["remark"].ToString()) ? "" : dt.Rows[i]["remark"].ToString().Trim(); 
                tempPriceUnit = string.IsNullOrEmpty(dt.Rows[i]["p_unit"].ToString()) ? "" : dt.Rows[i]["p_unit"].ToString().Trim();               
                qty = decimal.Parse(dt.Rows[i]["qty"].ToString());
                sec_qty = decimal.Parse(dt.Rows[i]["sec_qty"].ToString());
                price = decimal.Parse(dt.Rows[i]["price"].ToString());
                amt = decimal.Parse(dt.Rows[i]["amt"].ToString());
                if (tempRemark == "")
                {
                    //更新重量單價
                    //if (amt == sec_qty * price)
                    if (tempPriceUnit =="KG") 
                    {
                        for (int j = 0; j < dtUpdate.Rows.Count; j++)
                        {
                            if (dtUpdate.Rows[j]["id"].ToString() == tempId && dtUpdate.Rows[j]["sequence_id"].ToString() == tempSeq)
                            {
                                tmp_update_remark = string.IsNullOrEmpty(dtUpdate.Rows[j]["remark"].ToString()) ? "" : dtUpdate.Rows[j]["remark"].ToString();
                                priceUpdate = string.IsNullOrEmpty(dtUpdate.Rows[j]["sec_price"].ToString()) ? 0 : decimal.Parse(dtUpdate.Rows[j]["sec_price"].ToString());
                                if (priceUpdate == 0)
                                {
                                    dtUpdate.Rows[j]["sec_price"] = price; //更新重量單價                                    
                                }
                                else
                                {
                                    dtUpdate.Rows[j]["sec_price"] = priceUpdate + price; //同一頁數同一序號有兩行,有兩種的單價,單價單位相同,則兩個單價相加,即有不同工序                                    
                                }
                                dtUpdate.Rows[j]["p_sec_unit"] = "KG";
                                dtUpdate.Rows[j]["amt"] = 0;
                                if (tmp_update_remark == "")
                                {
                                    tmp_update_remark = "重量單價;";
                                }
                                else
                                {
                                    if (tmp_update_remark != "重量單價;")
                                    {
                                        tmp_update_remark = "重量單價;" + tmp_update_remark; //有兩種不同的單價單位
                                    }
                                }
                                dtUpdate.Rows[j]["remark"] = tmp_update_remark;
                                break;
                            }
                        }
                    }
                    //更新數量單價
                    //if (amt == qty * price)
                    if (tempPriceUnit != "KG")
                    {
                        for (int j = 0; j < dtUpdate.Rows.Count; j++)
                        {
                            if (dtUpdate.Rows[j]["id"].ToString() == tempId && dtUpdate.Rows[j]["sequence_id"].ToString() == tempSeq)
                            {
                                tmp_update_remark = string.IsNullOrEmpty(dtUpdate.Rows[j]["remark"].ToString()) ? "" : dtUpdate.Rows[j]["remark"].ToString();
                                priceUpdate = string.IsNullOrEmpty(dtUpdate.Rows[j]["price"].ToString()) ? 0 : decimal.Parse(dtUpdate.Rows[j]["price"].ToString());
                                if (priceUpdate == 0)
                                {
                                    dtUpdate.Rows[j]["price"] = price;
                                }
                                else
                                {
                                    dtUpdate.Rows[j]["price"] = priceUpdate + price;  //累加單價（相同單價單位累加，確保EXCEL中統一轉換成相同單位）
                                }
                                dtUpdate.Rows[j]["amt"] = 0;
                                dtUpdate.Rows[j]["p_unit"] = ConverQtyUnit(tempPriceUnit); //轉為標準的數量單位
                                if (tmp_update_remark == "")
                                {
                                    tmp_update_remark = "數量單價;";
                                }
                                else
                                {
                                    if (tmp_update_remark != "數量單價;")
                                    {
                                        tmp_update_remark = "數量單價;" + tmp_update_remark; //有兩種不同的單價單位
                                    }
                                }
                                dtUpdate.Rows[j]["remark"] = tmp_update_remark;
                                break;
                            }
                        }
                    }
                } //--end of if(tempRemark =="")

                //最低消費/样板费
                if (tempRemark != "")
                {
                    if ("1,2,3".Contains(tempRemark))
                    {
                        switch (tempRemark)
                        {
                            case "1"://最低消費
                                //只需更新加工單中的一行即可，直接更新最新低消費，EXCEL對賬單只需一行即可
                                for (int j = 0; j < dtUpdate.Rows.Count; j++)
                                {
                                    if (dtUpdate.Rows[j]["id"].ToString() == tempId && dtUpdate.Rows[j]["sequence_id"].ToString() == tempSeq)
                                    {
                                        tempAmt = string.IsNullOrEmpty(dtUpdate.Rows[j]["amt"].ToString()) ? 0 : decimal.Parse(dtUpdate.Rows[j]["amt"].ToString());
                                        dtUpdate.Rows[j]["price"] = 0;
                                        dtUpdate.Rows[j]["amt"] = tempAmt + amt;
                                        dtUpdate.Rows[j]["remark"] = "最低消費;";
                                        break;
                                    }
                                }
                                break;
                            case "2"://样板费
                                //同頁數同序號拆分成兩行，可能有兩道工序：工序1噴油，工序2上力架，兩道工序分別收錢，板费要加總，EXCEL對賬單要分開兩行
                                for (int j = 0; j < dtUpdate.Rows.Count; j++)
                                {
                                    if (dtUpdate.Rows[j]["id"].ToString() == tempId && dtUpdate.Rows[j]["sequence_id"].ToString() == tempSeq)
                                    {
                                        tempAmt = string.IsNullOrEmpty(dtUpdate.Rows[j]["amt"].ToString()) ? 0 : decimal.Parse(dtUpdate.Rows[j]["amt"].ToString());
                                        dtUpdate.Rows[j]["price"] = 0;
                                        dtUpdate.Rows[j]["amt"] = tempAmt + amt;
                                        dtUpdate.Rows[j]["remark"] = "樣板费;";
                                        break;
                                    }
                                }
                                break;
                            case "3"://直接計入總金額
                                for (int j = 0; j < dtUpdate.Rows.Count; j++)
                                {
                                    if (dtUpdate.Rows[j]["id"].ToString() == tempId && dtUpdate.Rows[j]["sequence_id"].ToString() == tempSeq)
                                    {                                        
                                        tempAmt = string.IsNullOrEmpty(dtUpdate.Rows[j]["amt"].ToString()) ? 0 : decimal.Parse(dtUpdate.Rows[j]["amt"].ToString());                                        
                                        dtUpdate.Rows[j]["amt"] = tempAmt + amt;
                                        string remark = dtUpdate.Rows[j]["remark"].ToString();
                                        remark = string.IsNullOrEmpty(remark) ? "" : remark.Trim();
                                        if (remark != "計入總金額;")
                                        {
                                            remark = remark + "計入總金額;";
                                        }
                                        dtUpdate.Rows[j]["remark"] = remark;
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                } //--end of if(tempRemark !="")
            } //--end for dt           
        }


        private void UpdateToGEO()
        {
            string tempId="", tempSeq="", userId = "", remark = "", remark_org = "", sql_f = "", sql_u = "",p_unit="";
            string temp_p_unit, temp_p_sec_unit,goodsUnit="";
            decimal outSecQty = 0, outQty = 0, org_price = 0, org_sec_price = 0, amtProdQty = 0, amtWeg = 0, price = 0, sec_price = 0, amt = 0;           
            int rate = 0, index = 0;
            userId = DBUtility._user_id;
            System.Data.DataTable dtOut = new System.Data.DataTable();

            //**更新到GEO外發加工單
            bool flagSave = false;
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            //SqlTransaction myTrans = myCon.BeginTransaction();
            try
            {
                //using (SqlCommand myCmd = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                using (SqlCommand myCmd = new SqlCommand() { Connection = myCon })
                {
                    //逐行自動提交
                    myCmd.CommandTimeout = 1800;//連接30分鐘                    
                    Graphics g = progressBar1.CreateGraphics();
                    System.Drawing.Font mf = new System.Drawing.Font("Arial", 9);
                    Brush mb = System.Drawing.Brushes.White;
                    System.Drawing.Point mp = new System.Drawing.Point(10, 0);

                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;
                    progressBar1.Maximum = dtUpdate.Rows.Count;
                    for (int i = 0; i < dtUpdate.Rows.Count; i++)
                    {
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }
                        g.DrawString("更新GEO中的單價及金額...", mf, mb, mp);
                        //System.Threading.Thread.Sleep(10);
                        System.Windows.Forms.Application.DoEvents();

                        remark_org = string.IsNullOrEmpty(dtUpdate.Rows[i]["remark"].ToString()) ? "" : dtUpdate.Rows[i]["remark"].ToString().Trim();
                        temp_p_unit = string.IsNullOrEmpty(dtUpdate.Rows[i]["p_unit"].ToString()) ? "" : dtUpdate.Rows[i]["p_unit"].ToString().Trim();
                        temp_p_sec_unit = string.IsNullOrEmpty(dtUpdate.Rows[i]["p_sec_unit"].ToString()) ? "" : dtUpdate.Rows[i]["p_sec_unit"].ToString().Trim();
                        if (remark_org == "")
                        {
                            continue; //返回繼續循環
                        }
                        tempId = dtUpdate.Rows[i]["id"].ToString();
                        tempSeq = dtUpdate.Rows[i]["sequence_id"].ToString();
                        price = decimal.Parse(dtUpdate.Rows[i]["price"].ToString());
                        sec_price = decimal.Parse(dtUpdate.Rows[i]["sec_price"].ToString());
                        amt = decimal.Parse(dtUpdate.Rows[i]["amt"].ToString());                       
                        sql_u = "";
                        index = remark_org.IndexOf(';');
                        remark = remark_org.Substring(0, index);
                        sql_f = string.Format(
                        @"Select prod_qty,sec_qty,goods_unit,p_unit,price,sec_price,total_prices From {0}op_outpro_out_displace 
                        WHERE within_code='0000' And id='{1}' And sequence_id='{2}'", DBUtility.remote_db, tempId, tempSeq);
                        dtOut = clsPublicOfCF01.GetDataTable(sql_f);
                        if (dtOut.Rows.Count == 0)
                        {
                            continue; //返回繼續循環
                        }
                        switch (remark)
                        {
                            //數量單價;重量單價 先后次序沒關系，都會跳至此條件
                            case "重量單價": //更新重量單價
                            case "數量單價": //更新數量單價
                                if (sec_price > 0 && price > 0)
                                {
                                    //數量金額
                                    //--start 已有外發加工單的數量轉成PCS
                                    goodsUnit = dtOut.Rows[0]["goods_unit"].ToString();
                                    rate = GetQtyRate(goodsUnit); //數量匯率
                                    outQty = decimal.Parse(dtOut.Rows[0]["prod_qty"].ToString()); //實際的外發數量     
                                    outQty = outQty * rate; //轉換成PCS
                                    //-- end

                                    //--目前要更新的數量單價匯率
                                    rate = GetQtyRate(temp_p_unit); //GRS=144 當前更新前的單價單位
                                    outQty = Math.Round(outQty / rate, 5);  //轉換成與數量單價相同的單位
                                    amtProdQty = Math.Round(outQty * price, 2);

                                    //重量金額
                                    outSecQty = decimal.Parse(dtOut.Rows[0]["sec_qty"].ToString());//實際的外發重量  
                                    amtWeg = outSecQty * sec_price;
                                    //總的金額
                                    amt = amtProdQty + amtWeg;
                                    sql_u = string.Format(
                                    @"UPDATE op_outpro_out_displace Set price={2},p_unit='{3}',sec_price={4},sec_p_unit='{5}',total_prices={6},price_remark='{7}'
                                     WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                                    tempId, tempSeq, price, temp_p_unit, sec_price, "KG", amt, remark_org);
                                }
                                if (sec_price > 0 && price == 0) //當前需要更新重量單價
                                {
                                    org_price = string.IsNullOrEmpty(dtOut.Rows[0]["price"].ToString()) ? 0 : decimal.Parse(dtOut.Rows[0]["price"].ToString());
                                    if (org_price > 0)//原外發加工單存在有數量單價
                                    {
                                        //數量金額
                                        //--start 已有外發加工單的數量轉成PCS                                    
                                        goodsUnit = dtOut.Rows[0]["goods_unit"].ToString();
                                        rate = GetQtyRate(goodsUnit); //數量匯率
                                        outQty = decimal.Parse(dtOut.Rows[0]["prod_qty"].ToString()); //實際的外發數量     
                                        outQty = outQty * rate; //統一轉換成PCS
                                                                //-- end
                                        p_unit = dtOut.Rows[0]["p_unit"].ToString();
                                        rate = GetQtyRate(p_unit); //GRS=144
                                        outQty = Math.Round(outQty / rate, 5);
                                        amtProdQty = outQty * org_price;
                                    }
                                    else
                                        amtProdQty = 0;
                                    //重量金額
                                    outSecQty = decimal.Parse(dtOut.Rows[0]["sec_qty"].ToString());//實際的外發重量  
                                    amtWeg = outSecQty * sec_price;
                                    amt = amtProdQty + amtWeg;
                                    sql_u = string.Format(
                                    @"UPDATE op_outpro_out_displace Set sec_price={2},sec_p_unit='{3}',total_prices={4},price_remark='{5}'
                                    WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                                    tempId, tempSeq, sec_price, "KG", amt, remark_org);
                                }
                                if (sec_price == 0 && price > 0) //當前需要更新數量單價
                                {
                                    org_sec_price = string.IsNullOrEmpty(dtOut.Rows[0]["sec_price"].ToString()) ? 0 : decimal.Parse(dtOut.Rows[0]["sec_price"].ToString());
                                    if (org_sec_price > 0) //原外發加工單存在有重量單價
                                    {
                                        //原重量金額                                                    
                                        outSecQty = decimal.Parse(dtOut.Rows[0]["sec_qty"].ToString()); //實際的外發重量    
                                        amtWeg = outSecQty * org_sec_price;
                                    }
                                    else
                                        amtWeg = 0;
                                    //數量金額                                
                                    //--start 已有外發加工單的數量轉成PCS                                    
                                    goodsUnit = dtOut.Rows[0]["goods_unit"].ToString();
                                    rate = GetQtyRate(goodsUnit); //數量匯率
                                    outQty = decimal.Parse(dtOut.Rows[0]["prod_qty"].ToString()); //實際的外發數量     
                                    outQty = outQty * rate; //統一轉換成PCS
                                    //-- end
                                    rate = GetQtyRate(temp_p_unit); //當前需更新的數量單價匯率
                                    outQty = Math.Round(outQty / rate, 5);
                                    amtProdQty = outQty * price;
                                    amt = amtProdQty + amtWeg;
                                    sql_u = string.Format(
                                    @"UPDATE op_outpro_out_displace Set price={2},p_unit='{3}',total_prices={4},price_remark='{5}'
                                     WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                                    tempId, tempSeq, price, temp_p_unit, amt, remark_org);
                                }
                                break;
                            case "最低消費":
                                //只需更新加工單中的一行即可，直接更新最新低消費，EXCEL對賬單只需一行即可
                                sql_u = string.Format(
                                @"UPDATE op_outpro_out_displace Set mould_fee={2},total_prices={2},price_remark='{3}'
                                WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                                tempId, tempSeq, amt, remark_org);
                                break;
                            case "樣板费":
                                sql_u = string.Format(
                                @"UPDATE op_outpro_out_displace Set former_free={2},total_prices={2},price_remark='{3}'
                                 WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                                tempId, tempSeq, amt, remark_org);
                                break;
                        }
                        if (sql_u != "")
                        {
                            myCmd.CommandText = sql_u;
                            myCmd.ExecuteNonQuery();
                        }
                        if (remark_org.Contains("計入總金額")) 
                        {
                            //計入總金額,EXCEL對賬單中需排在數量單價或重量單價之后
                            decimal otherAmt = decimal.Parse(dtUpdate.Rows[i]["amt"].ToString());
                            amt = otherAmt + amt;
                            sql_u = string.Format(
                            @"UPDATE op_outpro_out_displace Set total_prices={2},price_remark='{3}'
                            WHERE within_code='0000' And id='{0}' And sequence_id='{1}'", tempId, tempSeq, amt, remark_org);
                            myCmd.CommandText = sql_u;
                            myCmd.ExecuteNonQuery();
                        }
                    } //--end for
                }
                //myTrans.Commit(); //數據提交
                flagSave = true;
            }
            catch (Exception E)
            {
                //myTrans.Rollback(); //數據回滾
                flagSave = false;
                throw new Exception(E.Message);
            }
            finally
            {
                myCon.Close();
               // myTrans.Dispose();
            }
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            myCon.Close();
            myCon.Dispose();            
            if (sql_u != "")
            {
                MessageBox.Show("更新單價金額到外發加工單成功！", "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            if (!flagSave)
            {
                MessageBox.Show("保存數據失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }
    }
    
}
