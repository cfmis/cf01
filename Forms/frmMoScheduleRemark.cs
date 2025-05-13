using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ReportForm;
using cf01.CLS;
using System.Data.OleDb;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace cf01.Forms
{
    public partial class frmMoScheduleRemark : Form
    {
        private clsCommonUse commUse = new clsCommonUse();
        public frmMoScheduleRemark()
        {
            InitializeComponent();
        }

        private void frmMoScheduleRemark_Load(object sender, EventArgs e)
        {
            txtDep.Text = frmPlanWithPrintCard.sendDep;
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }
        /// <summary>
        /// 更新制單狀態
        /// </summary>
        private void ImportExcel1()
        {
            string FileName = "";
            this.openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            //"Excel文件(*.xls)|*.xls|所有檔案(*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)//獲取Excel文件
                FileName = this.openFileDialog1.FileName;
            else
                return;

            string strCode = null;

            //將Excel文件匯入到Datatable

            System.Data.DataTable dtFromExcel = new System.Data.DataTable(); //c.GetDataFromExcel(FileName, false, 1);
            //dgvDetails.DataSource = dtFromExcel;
            string mo_id, mo_req_status;
            string usr = DBUtility._user_id;
            DateTime tim = DateTime.Now;
            bool upd_status = true;
            int RowCount = dtFromExcel.Rows.Count;//行数
            for (int i = 1; i < RowCount; i++)
            {
                mo_id = dtFromExcel.Rows[i][0].ToString().Trim();
                mo_req_status = dtFromExcel.Rows[i][1].ToString().Trim();
                if (mo_id.Length > 10)
                    mo_id = mo_id.Substring(0, 9);
                if (mo_req_status.Length > 80)
                    mo_req_status = mo_req_status.Substring(0, 79);
                //添加
                strCode = "select mo_id from mo_status where mo_id = '" + mo_id + "'";
                try
                {
                    System.Data.DataTable dtRows = clsPublicOfCF01.GetDataTable(strCode);
                    if (dtRows.Rows.Count <= 0)
                    {
                        strCode = "INSERT INTO mo_status(mo_id,mo_req_status,cr_usr,cr_tim) ";
                        strCode += "VALUES(@mo_id,@mo_req_status,@usr,@tim)";

                        this.ParametersAddValue(mo_id, mo_req_status, usr, tim);
                        if (commUse.ExecDataBySql(strCode) > 0)
                        {
                            //MessageBox.Show("儲存成功！", "系統信息");
                        }
                        else
                        {
                            upd_status = false;
                            break;
                        }
                    }
                    else
                    {
                        //更新数据库
                        try
                        {
                            strCode = "UPDATE mo_status SET mo_req_status = @mo_req_status,am_usr=@usr,am_tim=@tim ";
                            strCode += " WHERE mo_id = @mo_id";
                            this.ParametersAddValue(mo_id, mo_req_status, usr, tim);
                            if (commUse.ExecDataBySql(strCode) > 0)
                            {
                                //MessageBox.Show("儲存成功！", "系統信息");
                            }
                            else
                            {
                                upd_status = false;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            upd_status = false;
                            MessageBox.Show(ex.Message, "系統信息");
                        }
                    }
                }
                catch (Exception ex)
                {
                    upd_status = false;
                    MessageBox.Show(ex.Message, "系統信息");
                }
            }
            if (upd_status == true)
                MessageBox.Show("更新制單狀態成功！", "系統信息");
            else
                MessageBox.Show("更新制單狀態失敗！", "系統信息");
        }
        private void ParametersAddValue(string mo_id, string mo_req_status, string usr, DateTime tim)
        {
            commUse.Cmd.Parameters.Clear();
            commUse.Cmd.Parameters.AddWithValue("@mo_id", mo_id);
            commUse.Cmd.Parameters.AddWithValue("@mo_req_status", mo_req_status);
            commUse.Cmd.Parameters.AddWithValue("@usr", usr);
            commUse.Cmd.Parameters.AddWithValue("@tim", tim);
        }



        private string ImportExcel()
        {
            string prd_dep = txtDep.Text;
            string result = "";

            string fileName = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel files(*.xls)|*.xls";
            openFile.FilterIndex = 0;
            openFile.RestoreDirectory = true;
            openFile.Title = "导入Excel文件到";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }

            //        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            //        Workbook workbook = excelApp.Workbooks.Open(fileName);
            //        Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            //        string cellValue = (string)(worksheet.Cells[1, 1] as Range).Value;
            //        MessageBox.Show("第一单元格的值: " + cellValue);
            //        Microsoft.Office.Interop.Excel.Range lastCell = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
            //Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
            //Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
            //false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            //        int lastRow = lastCell.Row;
            //        MessageBox.Show("最后一行行号: " + lastRow);

            //        workbook.Close(false);
            //        excelApp.Quit();

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(fileName);
            Worksheet worksheet = (Worksheet)workbook.Sheets[1];


            Microsoft.Office.Interop.Excel.Range lastCell = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
    Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
    Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
    false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            int lastColumn = lastCell.Column;


            // 查找表头为“制单编号”的列worksheet.UsedRange.Columns.Count
            int colMo = -1,colMo1=-1, colMo2 = -1, colRemark = -1, colDate = -1, colGroup = -1;
            for (int i = 1; i <= lastColumn; i++)
            {
                var dd = (worksheet.Cells[1, i] as Range).Value.ToString();
                if ((worksheet.Cells[1, i] as Range).Value.ToString() == "制單編號")
                {
                    colMo = i;
                }else
                if ((worksheet.Cells[1, i] as Range).Value.ToString() == "制單編號1")
                {
                    colMo1 = i;
                }
                else
                if ((worksheet.Cells[1, i] as Range).Value.ToString() == "制單編號2")
                {
                    colMo2 = i;
                }
                else
                if ((worksheet.Cells[1, i] as Range).Value.ToString() == "備註")
                {
                    colRemark = i;
                }
                else
                if ((worksheet.Cells[1, i] as Range).Value.ToString() == "組別")
                {
                    colGroup = i;
                }
                else
                if ((worksheet.Cells[1, i] as Range).Value.ToString() == "日期")
                {
                    colDate = i;
                }
            }
            if (colMo == -1 && colMo1 == -1 && colMo2 == -1 && colRemark == -1 && colDate == -1 && colGroup == -1)
            {
                result = "未找到表头为“制单编号”的列！";
                return result;
            }
            // 读取该列的值
            for (int row = 2; row <= worksheet.UsedRange.Rows.Count; row++)
            {
                string prd_mo, prd_group = "", prd_mo1 = "", prd_mo2 = "", remark = "", prd_date = "";
                prd_mo = (worksheet.Cells[row, colMo] as Range).Value?.ToString();
                prd_mo1 = (worksheet.Cells[row, colMo1] as Range).Value?.ToString();
                prd_mo2 = (worksheet.Cells[row, colMo2] as Range).Value?.ToString();
                remark = (worksheet.Cells[row, colRemark] as Range).Value?.ToString();
                prd_date = (worksheet.Cells[row, colDate] as Range).Value?.ToString();
                prd_group = (worksheet.Cells[row, colGroup] as Range).Value?.ToString();
            }

            workbook.Close(false);
            excelApp.Quit();



            return result;


            OleDbConnection conn = new OleDbConnection();

            string strConn = string.Empty;

            string sheetName = string.Empty;
            try
            {
                // Excel 2003 版本连接字符串
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1;'";
                conn = new OleDbConnection(strConn);
                conn.Open();
            }
            catch
            {
                try
                {
                    // Excel 2007 以上版本连接字符串
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    conn = new OleDbConnection(strConn);
                    conn.Open();
                }
                catch (Exception ex)
                {
                    result = "不是有效的Excel文件!";
                }
            }
            if (result != "")
            {
                //关闭连接，释放资源
                conn.Close();
                conn.Dispose();
                return result;
            }

            //获取所有的 sheet 表
            System.Data.DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

            bool findSheetFlag = false;
            for (int i = 0; i < dtSheetName.Rows.Count; i++)//這個是獲取Excel所有的Sheet
            //for (int i = 0; i < 1; i++)//只獲取Excel第1個Sheet
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.TableName = "table0";// + i.ToString();
                sheetName = dtSheetName.Rows[i]["TABLE_NAME"].ToString();
                //有些Excel是隱藏了很多個臨時表的，只將實際的導入
                //如果sheet的名字為數字開頭的如：105或105abc等，則sheetName則為：'105$'，則要將符號'去掉後再判斷
                if (sheetName.Substring(sheetName.Length - 1, 1) == "$"
                    || (sheetName.Substring(0, 1) == "'" && sheetName.Substring(sheetName.Length - 1, 1) == "'" && sheetName.Substring(sheetName.Length - 2, 1) == "$"))
                {
                    findSheetFlag = true;
                    try
                    {
                        OleDbDataAdapter oleda = new OleDbDataAdapter("select * from [" + sheetName + "]", conn);
                        oleda.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                        break;
                    }
                    result = "";// DtOperator(dt, prd_dep);
                }

            }
            //ds.Tables.Add(dt);
            //关闭连接，释放资源
            conn.Close();
            conn.Dispose();
            if (findSheetFlag == false)
                result = "沒有符合的工作表，請檢查工作表名稱是否正確!";
            if (result == "")
                result = "匯入排期表成功!";
            return result;
        }


        private string DtOperator(System.Data.DataTable dt, string prd_dep)
        {
            string result_str = "";
            //string strSql = "", strSql_f = "";
            int excel_row = 1;
            //string[] proSub = Request.Form.GetValues("selDep");
            //prd_dep = proSub[selDep.SelectedIndex];

            string prd_mo, prd_group = "", prd_mo1 = "", prd_mo2 = "", remark = "", prd_date = "";
            string prd_mo_h = "", prd_group_h = "", prd_mo1_h = "", prd_mo2_h = "", remark_h = "", prd_date_h = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string colName = dt.Columns[j].ColumnName;
                prd_mo_h = (colName == "制單編號" || colName == "頁數" ? colName : prd_mo_h);
                prd_group_h = (colName == "組別" ? colName : prd_group_h);
                prd_mo1_h = (colName == "制單編號1" ? colName : prd_mo1_h);
                prd_mo2_h = (colName == "制單編號2" ? colName : prd_mo2_h);
                remark_h = (colName == "備註" ? colName : remark_h);
                prd_date_h = (colName == "日期" ? colName : prd_date_h);

            }
            string user_id = DBUtility._user_id;
            //strSql += string.Format(@" SET XACT_ABORT  ON ");
            //strSql += string.Format(@" BEGIN TRANSACTION ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //strSql = "";
                excel_row = excel_row + 1;
                DataRow dr = dt.Rows[i];
                //if (i == 97)
                //{
                //    int aa = 1;
                //}
                prd_mo = (prd_mo_h == "" ? "" : dr[prd_mo_h].ToString().Trim());
                if (prd_mo != "")
                {

                    try
                    {
                        prd_group = (prd_group_h == "" ? "" : dr[prd_group_h].ToString());
                        prd_mo1 = (prd_mo1_h == "" ? "" : dr[prd_mo1_h].ToString());
                        prd_mo2 = (prd_mo2_h == "" ? "" : dr[prd_mo2_h].ToString());
                        remark = (remark_h == "" ? "" : dr[remark_h].ToString());
                        prd_date = (prd_date_h == "" ? "" : dr[prd_date_h].ToString());
                    }
                    catch (Exception ex)
                    {
                        result_str = "行: " + excel_row.ToString() + " 制單編號: " + prd_mo + "格式不正確!" + ex.Message;
                        return result_str;
                    }

                    string dtt = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    string strSql = "", strSql_f = "";
                    strSql_f = "Select prd_mo From mo_schedule_remark Where prd_dep='" + prd_dep + "' And prd_mo='" + prd_mo + "'";
                    System.Data.DataTable dtRemark = clsPublicOfCF01.GetDataTable(strSql_f);
                    if (dtRemark.Rows.Count == 0)
                    {

                        strSql += string.Format(@"INSERT INTO dgcf_pad.dbo.product_arrange (arrange_id,now_date,prd_dep,prd_mo,prd_item
                            ,mo_urgent,urgent_cdesc,arrange_machine,arrange_date,arrange_seq,order_qty
                            ,cust_o_date,req_f_date,req_qty,cpl_qty,arrange_qty,prd_cpl_qty,dep_rep_date,rec_status,prd_status,req_hk_date
                            ,dep_group,pre_prd_dep_date,pre_prd_dep_qty,to_dep_desc, line_num, req_num, req_time, install_moudle
                            , vendor_desc, mo_urgent1, period_flag,crusr,crtim)
                            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}'
                                ,'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}'
                                ,GETDATE())"
                            , prd_mo, prd_group = "", prd_mo1 = "", prd_mo2 = "", remark = "", prd_date = "", user_id);
                    }
                    else
                    {

                        strSql += string.Format(@"Update dgcf_pad.dbo.product_arrange Set mo_urgent='{0}',arrange_machine='{1}',arrange_date='{2}',arrange_seq='{3}'
                            ,order_qty='{4}',cust_o_date='{5}',req_f_date='{6}',req_qty='{7}',cpl_qty='{8}',arrange_qty='{9}',prd_cpl_qty='{10}'
                            ,dep_rep_date='{11}',rec_status='{12}',prd_status='{13}',req_hk_date='{14}',dep_group='{15}',now_date='{16}'
                            ,pre_prd_dep_date='{17}',pre_prd_dep_qty='{18}',amusr='{19}',to_dep_desc='{20}', line_num='{21}'
                            , req_num='{22}', req_time='{23}', install_moudle='{24}'
                            , vendor_desc='{25}', mo_urgent1='{26}', period_flag='{27}',urgent_cdesc='{28}'
                            ,amtim=GETDATE() Where arrange_id='{29}'"
                            , prd_mo, prd_group = "", prd_mo1 = "", prd_mo2 = "", remark = "", prd_date = "", user_id);
                    }
                    result_str = clsPublicOfCF01.ExecuteSqlUpdate(strSql);//更新明細記錄
                    if (result_str != "")
                    {
                        result_str += "行: " + excel_row.ToString() + " 制單編號: " + prd_mo + "格式不正確!";
                        break;
                    }
                }
            }

            return result_str;
        }


    }
}
