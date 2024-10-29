using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace cf01.CLS
{
    public class ExpToExcel
    {
        private static string strFileName;

        public static string GetFileName(DataGridView _dgv)
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默認文件后缀
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默認路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return null;
            //返回文件路径   
            strFileName = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (strFileName.Trim() == " ") return null;
            //定义表格内数据的行数和列数   
            int rowscount = _dgv.Rows.Count;
            int colscount = _dgv.Columns.Count;
            //行数必须大于0   
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            //列数必须大于0   
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            //行数不可以大于65536   
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            //列数不可以大于255   
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它   
            FileInfo file = new FileInfo(strFileName);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
            return strFileName;
        }

        public void SaveToExcel(DataGridView _dgv, BackgroundWorker _worker)
        {
            string strFileName = ExpToExcel.GetFileName(_dgv);

            if (strFileName == "" || strFileName == null)
            {
                return;
            }

            int rowscount = _dgv.Rows.Count;
            int colscount = _dgv.Columns.Count;
            int intValue = 0;
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

                //向Excel中写入表格的表头   
                int displayColumnsCount = 1;
                for (int i = 0; i <= _dgv.ColumnCount - 1; i++)
                {
                    if (_dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = _dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }

                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= _dgv.RowCount - 1; row++)
                {
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (_dgv.Columns[col].Visible == true)
                        {
                            if (col == 4 || col == 5)//_dgv.Columns[col].HeaderText == "size" || _dgv.Columns[col].HeaderText == "size_desc"
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = "'" + _dgv.Rows[row].Cells[col].Value.ToString().Trim();
                            }
                            else
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = _dgv.Rows[row].Cells[col].Value.ToString().Trim();
                            }

                            if (_dgv.Rows[row].Cells[col].Value.ToString() == "Sub-Total" || _dgv.Rows[row].Cells[col].Value.ToString() == "Sum-Total")
                            {
                                rg = (Microsoft.Office.Interop.Excel.Range)
                                    objSheet.Range[objSheet.Cells[row + 2, 1], objSheet.Cells[row + 2, colscount]];
                                rg.Font.Bold = true;
                                rg.Font.Size = 15;
                                rg.Interior.ColorIndex = 35;
                                rg.Interior.Pattern = -4105;
                            }

                            displayColumnsCount++;
                        }
                    }
                    intValue++;

                    string strMessage = ((100 * intValue) / rowscount).ToString() + "%";
                    Thread.Sleep(100);
                    _worker.ReportProgress(((100 * intValue) / rowscount), strMessage); //注意：这里向子窗体返回两个信息值，一个用于进度条，一个用于label的。
                    System.Windows.Forms.Application.DoEvents();
                }

                //objSheet.Columns.EntireColumn.AutoFit();//列宽自适应
                //保存文件   
                objWorkbook.SaveAs(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
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
            KillProcess("EXCEL");

            MessageBox.Show(strFileName + "\n\n导出成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region 关闭Excel进程
        /// <summary>
        /// 关闭Excel进程
        /// </summary>
        /// <param name="processName">进程名称</param>
        public static void KillProcess(string processName)
        {
            //获得进程对象，以用来操作
            System.Diagnostics.Process proce = new System.Diagnostics.Process();
            //得到所有打开的进程
            try
            {
                //获得需要杀死的进程名
                foreach (Process thisproc in Process.GetProcessesByName(processName))
                {
                    //立即杀死进程
                    thisproc.Kill();
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        #endregion

        #region 打开导出的Excel文件
        /// <summary>
        /// 打开导出的Excel文件
        /// </summary>
        /// <param name="fileName"></param>
        private void OpenExcel(string fileName)
        {
            System.Diagnostics.ProcessStartInfo info = new ProcessStartInfo();
            //info.WorkingDirectory = System.Windows.Forms.Application.StartupPath;
            //指定要打开的文件的路径
            info.FileName = fileName;
            System.Diagnostics.Process.Start(info);
        }
        #endregion

        public void DataTableToExcel(DataTable dtData)
        {
            //這個是用來將表dataTable進行快速匯出
            string path;
            path = getfilename();
            if (path == "")
                return;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Encoding encoding = Encoding.GetEncoding("big5");
            StreamWriter writer = new StreamWriter(File.Open(path, FileMode.CreateNew), encoding);
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
            grid.DataSource = dtData;// dtData;
            grid.DataBind();
            grid.RenderControl(writer2);

            writer.Close();
        }

        private string getfilename()
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return "";
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
                MessageBox.Show("文件名為空!", "匯出文件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return fileNameString.Trim();
        }

        public void DvExportToExcel(DataGridView _dgv)
        {
            //這個是用來將表格dataGridView進行快速匯出
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出數據到Excel文件";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                for (int i = 0; i < _dgv.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += _dgv.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容

                for (int rowNo = 0; rowNo < _dgv.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < _dgv.ColumnCount; columnNo++)
                    {
                        if (_dgv.Columns[columnNo].Visible == true)
                        {
                            if (columnNo > 0)
                            {
                                tempstr += "\t";
                            }
                            if (_dgv.Rows[rowNo].Cells[columnNo].Value != null)
                            {
                                if (columnNo == 4 || columnNo == 5)
                                {
                                    tempstr += "'" + _dgv.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                                }
                                else
                                {
                                    tempstr += _dgv.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                                }
                            }
                            else
                            {
                                tempstr += "";
                            }
                        }
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("匯出EXCEL成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 将Excel数据绑定到dataGridView
        public void ExcelToDGV()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开(Open)";    //标题

            ofd.ShowHelp = true;

            ofd.Filter = "文本文件（*txt）|*.txt|RTF文件（*.rtf）|*.rtf|excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";

            ofd.FilterIndex = 1;     //格式索引

            ofd.RestoreDirectory = false;

            ofd.InitialDirectory = Directory.GetCurrentDirectory();

            ofd.Multiselect = true;

            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性

            string path = "";
            if (ofd.ShowDialog() == DialogResult.OK)
                path = ofd.FileName;    //完整路径

            DataSet m_ds = new DataSet();
            string strConn = @"Provider = Microsoft.Jet.OLEDB.4.0;Data Source = "
               + path + ";Extended Properties=Excel 8.0";
            string strSheetName = "sheet1"; //默认sheet1
            string strExcel = string.Format("select * from [{0}$]", strSheetName);

            //using (OleDbConnection conn = new OleDbConnection(strConn))
            //{
            //    try
            //    {
            //        conn.Open();
            //        OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
            //        adapter.Fill(m_ds, strSheetName);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
            //this.dataGridView1.DataSource = m_ds.Tables[strSheetName];
            //return m_ds;


            //StreamReader read = File.OpenText(filename);
            //string str;
            //while (str = read.ReadLine() != null)
            //{
            //    //将读出的字符串在richTextBox1中显示  
            //    this.richTextBox1.Text += str;
            //}  
        }
        #endregion


        /// <summary>
        /// 將DataGridView中的內容匯出到Excel
        /// allen_leung 2014-10-09
        /// </summary>
        /// <param name="m_DataView"></param>
        public static void DataGridViewToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL 文件";
            kk.Filter = "EXECL文件(*.xls)|*.xls";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;// +".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show("匯出EXCEL成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //****************2016-03-24********************
        //因之前的匯出EXCEL,打開時老彈出提示格式不正確
        //增加了匯出版本的判斷，新增的匯出方法。
        //*********************************************
        /// <summary>
        /// 參數為DataGridView格式
        /// </summary>
        /// <param name="myDGV"></param>
        public void ExportExcel(DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {
                //bool fileSaved = false; 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Title = "保存EXECL文件";
                saveDialog.Filter = "EXECL文件|*.xls";
                saveDialog.FilterIndex = 1;
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
                        MessageBox.Show("無法創建Excel對象,可能當前操作系統上未安裝有Excel");
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

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();

                    //寫入標題  
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                    }
                    //寫入數值   
                    string test = "";
                    for (int r = 0; r < myDGV.Rows.Count; r++)
                    {
                        for (int i = 0; i < myDGV.ColumnCount; i++)
                        {
                            if (i == 6)
                            {
                                test = myDGV.Rows[r].Cells[i].Value.ToString();
                                test = myDGV.Columns[i].Name.ToString();
                            }
                            worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;                           
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  

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
                    clsUtility.myMessageBox("匯出EXCEL成功!", "提示信息");
                    //MessageBox.Show("匯出EXCEL成功!", "系統提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("無要匯出EXCEL之數據!", "提示信息", MessageBoxButtons.OK);
            }
        }

        public void ExportToExcel_Fast(DataGridView _dgv)
        {
            //這個是用來將表格dataGridView進行快速匯出
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出數據到Excel文件";



            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = "";
                //写标题

                for (int i = 0; i < _dgv.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += _dgv.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容

                for (int rowNo = 0; rowNo < _dgv.RowCount; rowNo++)
                {
                    string tempstr = "";
                    for (int columnNo = 0; columnNo < _dgv.ColumnCount; columnNo++)
                    {
                        if (_dgv.Columns[columnNo].Visible == true)
                        {
                            if (columnNo > 0)
                            {
                                tempstr += "\t";
                            }
                            if (_dgv.Rows[rowNo].Cells[columnNo].Value != null)
                            {
                                tempstr += _dgv.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                            }
                            else
                            {
                                tempstr += "";
                            }
                        }
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("匯出EXCEL成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
