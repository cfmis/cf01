using cf01.CLS;
using cf01.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private delegate void SetPos(int ipos, string vinfo);//代理

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
                dgv1.DataSource = dt;
                MessageBox.Show("EXCEL匯入成功", "提示信息", MessageBoxButtons.OK);               
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
                    ExcelToDatable(FileName, 1);           
                    flagInport = true;
                }
                catch (SqlException E)
                {
                    flagInport = false;
                    throw new Exception(E.Message);
                }
            }
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

            lblProcessInfo.Text = "正在導入EXCEL文件...";
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            int row_precessing = 0;
            int row_total = xSheet.UsedRange.Rows.Count;//總行數
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
                    //A欄：送貨日期,B欄：送貨單號,C欄：委外單號; D欄：頁數+序號;E欄：貨品編號,F欄：貨品名稱,G欄：顏色,H欄：數量;I欄：重量;J欄：单价; K欄：金額; L欄：備註,M欄：報價單號,N欄：單價單位備註
                    rng = xSheet.Cells[ii, "K"]; //金額
                    if (rng.get_Value() > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["amt"] = rng.get_Value(); //金額  K
                        dr["doc_id"] = docId;
                        rng = xSheet.Cells[ii,"A"]; //送貨日期 A                        
                        dr["issue_date"] = rng.get_Value(); 
                        rng = xSheet.Cells[ii, "B"]; //送貨單號 B                    
                        dr["delivery_id"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "C"]; //委外單號
                        dr["id"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "D"]; //頁數,序號
                        moId = rng.get_Value();
                        moId = moId.Trim();
                        seqId = "00" + moId.Substring(moId.Length - 2) + "h";
                        moId = moId.Substring(0, 9);
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
                        rng = xSheet.Cells[ii, "K"]; //金額
                        dr["amt"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "L"]; //"備註
                        dr["remark"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "M"]; //"報價單號
                        dr["quotation_id"] = rng.get_Value();
                        rng = xSheet.Cells[ii, "N"]; //"單價單位備註
                        dr["other_unit"] = rng.get_Value();
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
            lblProcessInfo.Text = "";            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }            

            //儲存原始對賬數據            
            lblProcessInfo.Text = "正在儲存原始對賬數據...";
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = dt.Rows.Count;
            string sqlUpdate = "", sqlFind = "", userId = "", id, sequenceId, issueDate = "", keyId = "";
            userId = DBUtility._user_id;
            bool flagSave = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                progressBar1.Value += progressBar1.Step;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;
                }
                id = dt.Rows[i]["id"].ToString();
                sequenceId = dt.Rows[i]["sequence_id"].ToString();
                keyId = dt.Rows[i]["key_id"].ToString();
                issueDate = dt.Rows[i]["issue_date"].ToString();
                issueDate = !string.IsNullOrEmpty(issueDate) ? DateTime.Parse(issueDate).Date.ToString("yyyy/MM/dd") : "";
                sqlFind = string.Format(@"SELECT '1' FROM op_outpro_out_account WHERE id='{0}' And sequence_id='{1}' And key_id='{2}'", id, sequenceId,keyId);
                if (clsPublicOfCF01.ExecuteSqlReturnObject(sqlFind) == "")
                {
                    sqlUpdate = string.Format(
                    @"Insert Into op_outpro_out_account
                    (doc_id,issue_date,delivery_id,id,sequence_id,mo_id,goods_id,goods_name,color,qty,sec_qty,price,amt,remark,quotation_id,confirm_flag,update_by,update_date,other_unit,key_id)
                    Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},'{13}','{14}','0','{15}',getdate(),'{16}','{17}')",
                    dt.Rows[i]["doc_id"].ToString(), issueDate, dt.Rows[i]["delivery_id"].ToString(), id, sequenceId, dt.Rows[i]["mo_id"].ToString(),
                    dt.Rows[i]["goods_id"].ToString(), dt.Rows[i]["goods_name"].ToString(), dt.Rows[i]["color"].ToString(), decimal.Parse(dt.Rows[i]["qty"].ToString()),
                    decimal.Parse(dt.Rows[i]["sec_qty"].ToString()), decimal.Parse(dt.Rows[i]["price"].ToString()), decimal.Parse(dt.Rows[i]["amt"].ToString()),
                    dt.Rows[i]["remark"].ToString(), dt.Rows[i]["quotation_id"].ToString(), userId, dt.Rows[i]["other_unit"].ToString(),dt.Rows[i]["key_id"].ToString());
                }
                else
                {
                    sqlUpdate = string.Format(
                    @"Update op_outpro_out_account 
                    SET doc_id='{2}',issue_date='{3}',delivery_id='{4}',mo_id='{5}',goods_id='{6}',goods_name='{7}',color='{8}',qty={9},sec_qty={10},price={11},amt={12},
                    remark='{13}',quotation_id='{14}',confirm_flag='0',update_by='{15}',update_date=getdate(),other_unit='{16}',key_id='{17}'
                    WHERE id='{0}' And sequence_id='{1}'", id, sequenceId,
                    dt.Rows[i]["doc_id"].ToString(), issueDate, dt.Rows[i]["delivery_id"].ToString(),dt.Rows[i]["mo_id"].ToString(),
                    dt.Rows[i]["goods_id"].ToString(), dt.Rows[i]["goods_name"].ToString(), dt.Rows[i]["color"].ToString(), decimal.Parse(dt.Rows[i]["qty"].ToString()),
                    decimal.Parse(dt.Rows[i]["sec_qty"].ToString()), decimal.Parse(dt.Rows[i]["price"].ToString()), decimal.Parse(dt.Rows[i]["amt"].ToString()),
                    dt.Rows[i]["remark"].ToString(), dt.Rows[i]["quotation_id"].ToString(), userId, dt.Rows[i]["other_unit"].ToString(), dt.Rows[i]["key_id"].ToString());
                }
                if(clsPublicOfCF01.ExecuteSqlUpdate(sqlUpdate) != "")
                {
                    flagSave = false;
                    break;
                }
            } //--end for
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            lblProcessInfo.Text = "";

            if (!flagSave)
            {
                return;
            }

            //對導入的EXCEL資料整理、加工分類，以便更新到外發加工單
            string sql_u = "", tempRemark = "", tempOtherUnit = "", tempId = "", tempSeq = "",tmp_update_remark="";
            decimal amt = 0, qty = 0, sec_qty = 0, price = 0, tempAmt = 0, priceUpdate = 0;
            DataTable dtUpdate = new DataTable();
            dtUpdate = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtUpdate.NewRow();
                dr["id"] = dt.Rows[i]["id"].ToString();
                dr["sequence_id"] = dt.Rows[i]["sequence_id"].ToString();
                dtUpdate.Rows.Add(dr);
            }
            //去掉重復以便與外發加工單相一致
            dtUpdate = dtUpdate.AsEnumerable().Distinct(DataRowComparer.Default).CopyToDataTable();

            //更前的臨時表
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tempId = dt.Rows[i]["id"].ToString();               
                tempSeq = dt.Rows[i]["sequence_id"].ToString();                
                tempRemark = string.IsNullOrEmpty(dt.Rows[i]["remark"].ToString()) ? "" : dt.Rows[i]["remark"].ToString().Trim(); //L欄有兩種情況：1最低消費，樣辦費
                tempOtherUnit = string.IsNullOrEmpty(dt.Rows[i]["other_unit"].ToString()) ? "" : dt.Rows[i]["other_unit"].ToString().Trim(); //N欄，即同時有兩種單價情況需在N欄單價的單位
                amt = decimal.Parse(dt.Rows[i]["amt"].ToString());
                qty = decimal.Parse(dt.Rows[i]["qty"].ToString());
                sec_qty = decimal.Parse(dt.Rows[i]["sec_qty"].ToString());
                price = decimal.Parse(dt.Rows[i]["price"].ToString());                
                if (tempRemark == "")
                {
                    //更新重量單價
                    if (amt == sec_qty * price)
                    {
                        for (int j = 0; j < dtUpdate.Rows.Count; j++)
                        {
                            if(dtUpdate.Rows[j]["id"].ToString() == tempId && dtUpdate.Rows[j]["sequence_id"].ToString() == tempSeq)
                            {
                                tmp_update_remark = string.IsNullOrEmpty(dtUpdate.Rows[j]["remark"].ToString()) ? "" : dtUpdate.Rows[j]["remark"].ToString();
                                priceUpdate = string.IsNullOrEmpty(dtUpdate.Rows[j]["price"].ToString()) ? 0 : decimal.Parse(dtUpdate.Rows[j]["price"].ToString());
                                if (priceUpdate == 0)
                                {
                                    dtUpdate.Rows[j]["price"] = price;
                                }
                                else
                                {
                                    if (tempOtherUnit == "")
                                    {
                                        dtUpdate.Rows[j]["price"] = priceUpdate + price; //同一頁數同一序號有兩行,有兩種的單價,單價單位相同,則兩個單價相加
                                        dtUpdate.Rows[j]["other_unit"] = "";
                                    }
                                    else
                                    {
                                        dtUpdate.Rows[j]["other_price"] = price; //同一頁數同一序號有兩行,且有兩種單價,單價單位不相同,另一行不同的需在N欄注明單價單位
                                        dtUpdate.Rows[j]["other_unit"] = tempOtherUnit;
                                    }
                                }                                
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
                    if (amt == qty * price)
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
                                    if (tempOtherUnit == "")
                                    {
                                        dtUpdate.Rows[j]["price"] = priceUpdate + price; //同一頁數同一序號有兩行,有兩種的單價,單價單位相同,則兩個單價相加
                                        dtUpdate.Rows[j]["other_unit"] = "";
                                    }
                                    else
                                    {
                                        dtUpdate.Rows[j]["other_price"] = price; //同一頁數同一序號有兩行,且有兩種單價,單價單位不相同,另一行不同的需在N欄注明單價單位
                                        dtUpdate.Rows[j]["other_unit"] = tempOtherUnit;
                                    }                                    
                                }                             
                                dtUpdate.Rows[j]["amt"] = 0;
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
                if (tempRemark != "" )
                {
                    if ("1,2".Contains(tempRemark))
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
                        }
                    }
                    else
                    {                        
                        continue;
                    }
                } //--end of if(tempRemark !="")
            } //--end for dt


            //**更新到GEO外發加工單
            SqlConnection sqlconn = new SqlConnection(DBUtility.conn_str_dgerp2);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand("", sqlconn);            
            lblProcessInfo.Text = "正在更新外發加工單中的單價及金額...";
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = dtUpdate.Rows.Count;
            string remark = "", remark_org = "", otherUnit = "", sql_f = "", result = "";
            decimal outSecQty = 0, outQty = 0, otherPrice = 0, amtOther = 0, amtProdQty = 0, amtWeg = 0;
            int rate = 0;
            DataTable dtWeg = new DataTable();
            for (int i = 0; i < dtUpdate.Rows.Count; i++)
            {
                progressBar1.Value += progressBar1.Step;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;
                }
                remark_org = string.IsNullOrEmpty(dtUpdate.Rows[i]["remark"].ToString()) ? "" : dtUpdate.Rows[i]["remark"].ToString().Trim();
                otherUnit = string.IsNullOrEmpty(dtUpdate.Rows[i]["other_unit"].ToString()) ? "" : dtUpdate.Rows[i]["other_unit"].ToString().Trim();
                if (remark_org == "")
                {
                    continue; //返回繼續循環
                }
                int index = remark_org.IndexOf(';');
                remark = remark_org.Substring(0, index);
                amt = decimal.Parse(dtUpdate.Rows[i]["amt"].ToString());
                price = decimal.Parse(dtUpdate.Rows[i]["price"].ToString());
                sql_u = "";
                tempId = dtUpdate.Rows[i]["id"].ToString();
                if(otherUnit == "GRS")
                {
                    otherUnit = "GRS";
                }
                tempSeq = dtUpdate.Rows[i]["sequence_id"].ToString();                    
                switch (remark)
                {
                    case "重量單價": //更新重量單價
                        sql_f = string.Format(@"Select sec_qty From {0}op_outpro_out_displace WHERE within_code='0000' And id='{1}' And sequence_id='{2}'", DBUtility.remote_db, tempId, tempSeq);
                        result = clsPublicOfCF01.ExecuteSqlReturnObject(sql_f);
                        outSecQty = (result != "") ? decimal.Parse(result) : 0; //外發加工單的重量
                        if (otherUnit == "")
                        {
                            //正常的更新重量單價
                            amt = price * outSecQty;
                            sql_u = string.Format(
                            @" UPDATE op_outpro_out_displace Set sec_price={2},total_prices={3},process_request='{4}'
                            WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                            tempId, tempSeq, price, amt, remark_org);
                        }
                        else
                        {
                            //N欄中備註的其它單價（KG重量單位)
                            otherPrice = decimal.Parse(dtUpdate.Rows[i]["other_price"].ToString());
                            amtOther = outSecQty * otherPrice;
                            //--Start 計算原始外發加工單的數量金額
                            sql_f = string.Format(@"Select prod_qty,price,p_unit From {0}op_outpro_out_displace WHERE within_code='0000' And id='{1}' And sequence_id='{2}'", DBUtility.remote_db, tempId, tempSeq);
                            dtWeg = clsPublicOfCF01.GetDataTable(sql_f);
                            string p_unit = dtWeg.Rows[0]["p_unit"].ToString();
                            rate = GetQtyRate(p_unit); //單價匯率
                            outQty = decimal.Parse(dtWeg.Rows[0]["prod_qty"].ToString()); //實際的外發數量  
                            price = decimal.Parse(dtWeg.Rows[0]["price"].ToString());
                            amtProdQty = Math.Round((outQty / rate) * price, 2);
                            //---end
                            amt = amtProdQty + amtOther;
                            sql_u = string.Format(
                            @"UPDATE op_outpro_out_displace Set sec_price={2},sec_p_unit='{3}',total_prices={4},process_request='{5}'
                            WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                            tempId, tempSeq, otherPrice, "KG", amt, remark_org);
                        }
                        break;
                    case "數量單價": //更新數量單價
                        sql_f = string.Format(@"Select prod_qty From {0}op_outpro_out_displace WHERE within_code='0000' And id='{1}' And sequence_id='{2}'", DBUtility.remote_db, tempId, tempSeq);
                        result = clsPublicOfCF01.ExecuteSqlReturnObject(sql_f);
                        outQty = (result != "") ? decimal.Parse(result) : 0; //外發加工單的數量                       
                        if (otherUnit == "")
                        {
                            amt = price * outQty;
                            sql_u = string.Format(
                            @"UPDATE op_outpro_out_displace Set price={2},total_prices={3},process_request='{4}'
                            WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                            tempId, tempSeq, price, amt, remark_org);
                        }
                        else
                        {
                            //N欄中備註的其它單價(GRS,PCS等數量單位)
                            otherPrice = decimal.Parse(dtUpdate.Rows[i]["other_price"].ToString());
                            otherUnit = ConverQtyUnit(otherUnit); //轉成GEO中標準的單位
                            rate = GetQtyRate(otherUnit); //單價匯率
                            amtOther = Math.Round((outQty / rate) * otherPrice, 2);
                            //--Start 計算原始外發加工單重量金額
                            sql_f = string.Format(@"Select sec_qty,sec_price From {0}op_outpro_out_displace WHERE within_code='0000' And id='{1}' And sequence_id='{2}'", DBUtility.remote_db, tempId, tempSeq);
                            dtWeg = clsPublicOfCF01.GetDataTable(sql_f);
                            outSecQty = decimal.Parse(dtWeg.Rows[0]["sec_qty"].ToString());
                            decimal sec_price = string.IsNullOrEmpty(dtWeg.Rows[0]["sec_price"].ToString()) ? 0 : decimal.Parse(dtWeg.Rows[0]["sec_price"].ToString());
                            amtWeg = outSecQty * sec_price;
                            //--end
                            amt = amtOther + amtWeg;
                            sql_u = string.Format(
                            @"UPDATE op_outpro_out_displace Set price={2},p_unit='{3}',total_prices={4},process_request='{5}'
                            WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                            tempId, tempSeq, otherPrice, otherUnit, amt, remark_org);
                        }                        
                        break;
                    case "最低消費":
                        //只需更新加工單中的一行即可，直接更新最新低消費，EXCEL對賬單只需一行即可
                        sql_u = string.Format(
                        @"UPDATE op_outpro_out_displace Set mould_fee={2},total_prices={2},process_request='{3}'
                        WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                        tempId, tempSeq,amt, remark_org);
                        break;
                    case "樣板费":
                        sql_u = string.Format(
                        @"UPDATE op_outpro_out_displace Set former_free={2},total_prices={2},process_request='{3}'
                        WHERE within_code='0000' And id='{0}' And sequence_id='{1}'",
                        tempId, tempSeq, amt, remark_org);
                        break;
                }               
                if(sql_u !="")
                {
                    cmd.CommandText = sql_u;
                    cmd.ExecuteNonQuery();
                }
            } // -- end for
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            lblProcessInfo.Text = "";
            
            cmd.Dispose();
            sqlconn.Close();
            sqlconn.Dispose();
            if (sql_u != "")
            {
                MessageBox.Show("更新單價金額到外發加工單成功！", "提示信息", MessageBoxButtons.OK);
            }
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
                case "GRS":
                case "Grs":
                    result = "GRS";
                    break;
                case "DZ":
                case "Dz":
                    result = "DZ";
                    break;
                case "PCS":
                case "Pcs":
                case "pcs":
                    result = "PCS";
                    break;
                case "SET":
                case "Set":
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
       

    }
    
}
