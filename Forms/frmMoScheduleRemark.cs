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
using System.Data.SqlClient;

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
            //////部門組別
            lueDepGroup.Properties.DataSource = clsBaseData.loadScheduleDepGroup(txtDep.Text.Trim());
            lueDepGroup.Properties.ValueMember = "grp_code";
            lueDepGroup.Properties.DisplayMember = "grp_code";
            LoadData();
        }
        private void LoadData()
        {
            string strSql = "Select prd_dep,prd_mo,prd_mo1,prd_mo2,prd_date,prd_group,remark" +
                " From mo_schedule_remark Where prd_dep='" + txtDep.Text.Trim() + "'" +
                " Order By update_time ";
            System.Data.DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);
            gcPrd.DataSource = dtPrd;
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }
        /// <summary>
        /// 更新制單狀態
        /// </summary>

        private void ImportExcel()
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
            
            //        MessageBox.Show("最后一行行号: " + lastRow);

            //        workbook.Close(false);
            //        excelApp.Quit();

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(fileName);
            Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            Microsoft.Office.Interop.Excel.Range lastCellRow = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
    Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
    Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
    false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);



            Microsoft.Office.Interop.Excel.Range lastCellCol = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
    Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
    Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
    false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            int lastRow = lastCellRow.Row;
            int lastColumn = lastCellCol.Column;


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
                MessageBox.Show("未找到表头为“制單編號”的列！");
                return;
            }
            prgStatus.Minimum = 0;
            prgStatus.Maximum = lastRow;
            prgStatus.Value = 0;
            // 读取该列的值worksheet.UsedRange.Rows.Count
            for (int row = 2; row <= lastRow; row++)
            {
                prgStatus.Value = row - 1;
                string prd_mo, prd_group = "", prd_mo1 = "", prd_mo2 = "", remark = "", prd_date = "";
                prd_mo = (worksheet.Cells[row, colMo] as Range).Value?.ToString().Trim();
                prd_mo = prd_mo != null ? prd_mo : "";
                prd_mo1 = (worksheet.Cells[row, colMo1] as Range).Value?.ToString().Trim();
                prd_mo1 = prd_mo1 != null ? prd_mo1 : "";
                prd_mo2 = (worksheet.Cells[row, colMo2] as Range).Value?.ToString().Trim();
                prd_mo2 = prd_mo2 != null ? prd_mo2 : "";
                remark = (worksheet.Cells[row, colRemark] as Range).Value?.ToString().Trim();
                remark = remark != null ? remark : "";
                prd_date = (worksheet.Cells[row, colDate] as Range).Value?.ToString().Trim();
                prd_date = clsValidRule.ConvertDateToString(prd_date != null && prd_date != "-2146826246" ? prd_date : "");
                prd_group = (worksheet.Cells[row, colGroup] as Range).Value?.ToString().Trim();
                prd_group = prd_group != null ? prd_group : "";
                if (prd_mo !="")
                    result = Save(prd_dep, prd_mo, prd_group, prd_mo1, prd_mo2, prd_date, remark);
                if (result != "")
                    break;
            }

            workbook.Close(false);
            excelApp.Quit();
            if (result == "")
            {
                MessageBox.Show("匯入數據成功!");
                prgStatus.Value = 0;
                LoadData();
            }
            else
                MessageBox.Show(result);

        }


        private string Save(string prd_dep, string prd_mo, string prd_group, string prd_mo1, string prd_mo2, string prd_date, string remark)
        {
            string result = "";
            string strSql = "";
            SqlParameter[] paras = new SqlParameter[] { };
            string user_id = DBUtility._user_id;
            string now_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (!CheckRecords(prd_dep, prd_mo))
            {
                strSql = @"insert into mo_schedule_remark (prd_dep,prd_mo, prd_group, prd_mo1, prd_mo2, remark, prd_date
                  ,create_user,create_time,update_user,update_time)
                 Values(@prd_dep,@prd_mo, @prd_group, @prd_mo1, @prd_mo2, @remark, @prd_date
                 ,@user_id,@now_time,@user_id,@now_time)";

                paras = new SqlParameter[]{
                        new SqlParameter("@prd_dep",prd_dep),
                        new SqlParameter("@prd_mo",prd_mo),
                        new SqlParameter("@prd_group",prd_group),
                        new SqlParameter("@prd_mo1",prd_mo1),
                        new SqlParameter("@prd_mo2",prd_mo2),
                        new SqlParameter("@remark",remark),
                        new SqlParameter("@prd_date",prd_date),
                        new SqlParameter("@user_id",user_id),
                        new SqlParameter("@now_time",now_time)

                    };
            }
            else
            {
                strSql = @"Update mo_schedule_remark Set prd_group=@prd_group, prd_mo1=@prd_mo1, prd_mo2=@prd_mo2, remark=@remark
                    , prd_date=@prd_date,update_user=@user_id,update_time=@now_time" +
                        " Where prd_dep=@prd_dep And prd_mo=@prd_mo ";
                paras = new SqlParameter[]{
                        new SqlParameter("@prd_dep",prd_dep),
                        new SqlParameter("@prd_mo",prd_mo),
                        new SqlParameter("@prd_group",prd_group),
                        new SqlParameter("@prd_mo1",prd_mo1),
                        new SqlParameter("@prd_mo2",prd_mo2),
                        new SqlParameter("@remark",remark),
                        new SqlParameter("@prd_date",prd_date),
                        new SqlParameter("@user_id",user_id),
                        new SqlParameter("@now_time",now_time)

                    };
            }
            int result_upd = clsPublicOfCF01.ExecuteNonQuery(strSql, paras, false);
            if (result_upd < 0)
                result = "更新記錄失敗!";
            return result;
        }
        private bool CheckRecords(string prd_dep, string prd_mo)
        {
            bool result = false;
            string strSql = " Select prd_mo From mo_schedule_remark Where prd_dep='" + prd_dep + "' And prd_mo='" + prd_mo + "'";
            System.Data.DataTable dtPrd = clsPublicOfCF01.GetDataTable(strSql);
            if (dtPrd.Rows.Count > 0)
                result = true;
            return result;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvPrd_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //int newRowHandle = e.FocusedRowHandle;
            DataRow dr = gvPrd.GetDataRow(gvPrd.FocusedRowHandle);
            txtPrdMo.Text = dr["prd_mo"].ToString();
            txtPrdMo1.Text = dr["prd_mo1"].ToString();
            txtPrdMo2.Text = dr["prd_mo2"].ToString();
            lueDepGroup.EditValue = dr["prd_group"].ToString();
            txtRemark.Text = dr["remark"].ToString();
            txtPrdDate.Text = dr["prd_date"].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtPrdMo.Text = "";
            txtPrdMo1.Text = "";
            txtPrdMo2.Text = "";
            lueDepGroup.EditValue = "";
            txtRemark.Text = "";
            txtPrdDate.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPrdMo.Text.Trim()=="")
            {
                MessageBox.Show("制單編號不能為空!");
                txtPrdMo.Focus();
                return;
            }
            string result = Save(txtDep.EditValue.ToString().Trim(), txtPrdMo.Text.Trim(), lueDepGroup.EditValue.ToString().Trim()
                , txtPrdMo1.Text, txtPrdMo2.Text, txtPrdDate.Text, txtRemark.Text);
            if (result == "")
            {
                MessageBox.Show("匯入數據成功!");
                prgStatus.Value = 0;
                LoadData();
            }
            else
                MessageBox.Show(result);
        }

        private void gvPrd_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();// "G" + 
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = " Delete From mo_schedule_remark Where prd_dep='" + txtDep.Text.Trim() + "' And prd_mo='" + txtPrdMo.Text.Trim() + "'";
            string result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
            {
                MessageBox.Show("刪除記錄成功!");
                LoadData();
            }
            else
                MessageBox.Show(result);
        }
    }
}
