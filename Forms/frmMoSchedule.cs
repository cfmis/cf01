using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using System.IO;
using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using cf01.ReportForm;
using DevExpress.XtraGrid.Views.Base;


namespace cf01.Forms
{
    public partial class frmMoSchedule : Form
    {
        private string user_id = DBUtility._user_id;
        public static string sendDate = "";
        public static string sendDep = "";
        public static string sendMachine = "";
        public static string sendMo = "";
        private DataTable dtMoSchedule = new DataTable();
        private DataRow cutRow;
        private int pasteRowIndex;
        private string start_prd_time = "";
        private string work_in1 = "", work_out1 = "";
        private string work_in2 = "", work_out2 = "";
        private string work_in3 = "", work_out3 = "";
        private string break_in3 = "", break_out3 = "";
        private string break_in4 = "", break_out4 = "";
        private double noon_break = 0, afternoon_break = 0, evening_break = 0;
        public frmMoSchedule()
        {
            InitializeComponent();
        }
        private void frmMoSchedule_Load(object sender, EventArgs e)
        {
            InitControlers();
        }
        private void InitControlers()
        {
            DataTable dtPrd_dept = clsBaseData.loadPrdDep();
            cmbFindDep.DataSource = dtPrd_dept;
            cmbFindDep.DisplayMember = "dep_cdesc";
            cmbFindDep.ValueMember = "dep_id";
            SetCombox();

        }
        private void SetCombox()
        {


            lueGvStatus.DataSource = clsBaseData.loadDocFlag("mo_schedule");
            lueGvStatus.ValueMember = "flag_id";
            lueGvStatus.DisplayMember = "flag_cdesc";

            lueGvUrgentFlag.DataSource = clsBaseData.loadDocFlag("mo_urgent_status");
            lueGvUrgentFlag.ValueMember = "flag_id";
            lueGvUrgentFlag.DisplayMember = "flag_cdesc";
            cmbMoStatus.DataSource = clsBaseData.loadDocFlag("mo_schedule");
            cmbMoStatus.ValueMember = "flag_id";
            cmbMoStatus.DisplayMember = "flag_cdesc";
            cmbMoStatus.SelectedValue = "01";
            cmbSetStatus.DataSource = clsBaseData.loadDocFlag("mo_schedule");
            cmbSetStatus.ValueMember = "flag_id";
            cmbSetStatus.DisplayMember = "flag_cdesc";
            //////模具類型
            lueModuleType.DataSource = clsBaseData.loadDocFlag("schedule_module_type");
            lueModuleType.ValueMember = "flag_id";
            lueModuleType.DisplayMember = "flag_cdesc";
            
        }


        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            //if (dgvMoSchedule.SelectedRows.Count > 0)
            //{
            //    pasteRowIndex = dgvMoSchedule.SelectedRows[0].Index;
            //    cutRow = dtMoSchedule.NewRow();
            //    cutRow.ItemArray = dtMoSchedule.Rows[pasteRowIndex].ItemArray;

            //    //// 从 DataTable 移除选中行
            //    //dtMoSchedule.Rows.RemoveAt(pasteRowIndex);

            //}


            int selectedIndex = gvSchedule.FocusedRowHandle;
            if (selectedIndex >= 0)
            {
                cutRow = dtMoSchedule.NewRow();
                cutRow.ItemArray = dtMoSchedule.Rows[selectedIndex].ItemArray;
                pasteRowIndex = selectedIndex;
                //dtMoSchedule.Rows.RemoveAt(selectedIndex); // 从 DataTable 移除
            }


        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            //if (cutRow != null)
            //{
            //    //dtArrange.Rows.RemoveAt(pasteRowIndex); // 从绑定的 DataTable 中移除

            //    // 获取目标插入位置的行索引
            //    var clientPoint = dgvMoSchedule.PointToClient(Cursor.Position);
            //    var hitTest = dgvMoSchedule.HitTest(clientPoint.X, clientPoint.Y);

            //    if (hitTest.RowIndex >= 0)
            //    {
            //        dtMoSchedule.Rows.RemoveAt(pasteRowIndex); // 从绑定的 DataTable 中移除
            //        // 插入到目标行的前面
            //        int targetIndex = hitTest.RowIndex - 1;
            //        dtMoSchedule.Rows.InsertAt(cutRow, targetIndex); // 插入到目标位置
            //        ReSort();//重新排序
            //        InsertImageLine(targetIndex);//重新插入圖片
            //        cutRow = null; // 清空剪切的行
            //    }
            //    else
            //    {
            //        MessageBox.Show("无法粘贴到该位置！");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("没有剪切的行可以粘贴！");
            //}


            if (cutRow != null)
            {
                dtMoSchedule.Rows.RemoveAt(pasteRowIndex); // 从绑定的 DataTable 中移除
                int targetIndex = gvSchedule.FocusedRowHandle;
                if (targetIndex >= 0)
                {
                    dtMoSchedule.Rows.InsertAt(cutRow, targetIndex); // 插入到目标位置
                    ReSetSecheduleID();//重新生成排序號
                    if (targetIndex == 0)
                        dtMoSchedule.Rows[targetIndex]["start_time"] = System.DateTime.Now.ToString("yyyy/MM/dd") + " " + start_prd_time;
                    else
                        dtMoSchedule.Rows[targetIndex]["start_time"] = dtMoSchedule.Rows[targetIndex - 1]["end_time"];
                    CountScheduleTime(targetIndex);//重新生成排期日期
                    cutRow = null; // 清空剪切行记录
                }
                else
                {
                    MessageBox.Show("请先选择一个目标行！");
                }
            }
            else
            {
                MessageBox.Show("没有剪切的行可以粘贴！");
            }




        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtPrdMachine.Focus();
            FindData();
        }

        private void FindData()
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            LoadData();
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void LoadData()
        {
            int sch_by_machine = 0;
            dtMoSchedule= LoadData1(sch_by_machine);
            gcSchedule.DataSource = dtMoSchedule;
            if (chkScheduleByMachine.Checked == true)
            {
                sch_by_machine = 1;
                gcWaitSchedule.DataSource = LoadData1(sch_by_machine);
            }
            CountNeedPrdDays();
            // 注册 CustomColumnDisplayText 事件
            //gvSchedule.CustomColumnDisplayText += gvSchedule_CustomColumnDisplayText;
        }
        private DataTable LoadData1(int sch_by_machine)
        {
            string prd_dep = cmbFindDep.SelectedValue.ToString();
            string prd_group = cmbDepGroup.SelectedValue != null ? cmbDepGroup.SelectedValue.ToString() : "";
            string mo_status = cmbMoStatus.SelectedValue != null ? cmbMoStatus.SelectedValue.ToString() : "";
            prd_group = prd_group == "00" ? "" : prd_group;
            string prd_machine = txtPrdMachine.Text.Trim();
            DataTable dtSch = clsMoSchedule.LoadMoSchedule(prd_dep, prd_group, prd_machine, sch_by_machine, mo_status, user_id);
            return dtSch;
        }
        /// /// 統計排期數量、未完成數量、制單需要的時間
        private void CountNeedPrdDays()
        {

            if (dtMoSchedule.Rows.Count > 0)
            {
                object schedule_qty = dtMoSchedule.Compute("SUM(schedule_qty)", "");
                object not_cp_qty = dtMoSchedule.Compute("SUM(not_cp_qty)", "not_cp_qty > 0");
                object req_tot_time = dtMoSchedule.Compute("SUM(req_tot_time)", "");
                txtScheduleQty.Text = Convert.ToDecimal(schedule_qty).ToString("#,##0");
                txtNotCpQty.Text = Convert.ToDecimal(not_cp_qty).ToString("#,##0");
                txtReqTotTime.Text = Convert.ToDecimal(req_tot_time).ToString("#,##0.00");
                decimal day_work_time = 24 - (decimal)(noon_break + afternoon_break + evening_break);
                if (day_work_time != 0)
                    txtNeedPrdDays.Text = Math.Round((clsValidRule.ConvertStrToDecimal(txtReqTotTime.Text) / day_work_time),2).ToString();
                else
                    txtNeedPrdDays.Text = "";
            }
            else
            {
                txtScheduleQty.Text = "0";
                txtNotCpQty.Text = "0";
                txtReqTotTime.Text = "0";
                txtNeedPrdDays.Text = "0";
            }
        }
        private void ReSetSecheduleID()
        {
            //for (int i=0;i<dgvMoSchedule.Rows.Count;i++)
            //{
            //    dgvMoSchedule.Rows[i].Cells["colScheduleSeq"].Value = i + 1;
            //    dgvMoSchedule.Rows[i].Cells["colUpdateFlag"].Value = "1";
            //}

            //// 获取记录值
            //for (int rowIndex = 0; rowIndex < gvSchedule.RowCount; rowIndex++)
            //{
            //    gvSchedule.SetRowCellValue(rowIndex, gvSchedule.Columns["gclScheduleSeq"], rowIndex + 1);
            //    //for (int colIndex = 0; colIndex < gvSchedule.Columns.Count; colIndex++)
            //    //{
            //    //    //var cellValue = gvSchedule.GetRowCellValue(rowIndex, gvSchedule.Columns[colIndex]);
            //    //    //Console.WriteLine($"行 {rowIndex + 1}, 列 {gvSchedule.Columns[colIndex].FieldName}, 值: {cellValue}");

            //    //}
            //}
            int scheduleSeq = 1;
            foreach (DataRow row in dtMoSchedule.Rows)
            {
                row["schedule_seq"] = scheduleSeq.ToString("D3").PadLeft(3, '0');
                row["update_flag"] = "1";
                scheduleSeq++;
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMachine_status_Click(object sender, EventArgs e)
        {
            frmMachineStatus1 frmMS = new frmMachineStatus1();
            frmMS.strPrd_dep = cmbFindDep.SelectedValue.ToString();
            //if(frm_Main.isRunMain ==true)
            //    frmMS.MdiParent = frm_Main.ActiveForm;
            frmMS.WindowState = FormWindowState.Maximized;
            //frmMS.Show();
            frmMS.ShowDialog();
        }

        private void cmbFindDep_Leave(object sender, EventArgs e)
        {
            
            GetScheduleBase();
            //////部門組別
            luePrdGroup.DataSource = clsBaseData.loadDocFlag("GROUP_" + cmbFindDep.SelectedValue.ToString().Trim());
            luePrdGroup.ValueMember = "flag_id";
            luePrdGroup.DisplayMember = "flag_cdesc";

            cmbDepGroup.DataSource = clsBaseData.loadDocFlag("GROUP_" + cmbFindDep.SelectedValue.ToString().Trim());
            cmbDepGroup.ValueMember = "flag_id";
            cmbDepGroup.DisplayMember = "flag_cdesc";
        }
        private void GetScheduleBase()
        {
            DataTable dtScheduleBase = clsMoSchedule.LoadScheduleBase(cmbFindDep.SelectedValue.ToString());
            if (dtScheduleBase.Rows.Count > 0)
            {
                DataRow dr = dtScheduleBase.Rows[0];
                start_prd_time = dr["start_prd_time"].ToString();
                work_in1 = dr["work_in1"].ToString();
                work_out1 = dr["work_out1"].ToString();
                work_in2 = dr["work_in2"].ToString();
                work_out2 = dr["work_out2"].ToString();
                work_in3 = dr["work_in3"].ToString();
                work_out3 = dr["work_out3"].ToString();
                break_in3 = dr["break_in3"].ToString();
                break_out3 = dr["break_out3"].ToString();
                break_in4 = dr["break_in4"].ToString();
                break_out4 = dr["break_out4"].ToString();
                noon_break = clsValidRule.ConvertStrToDouble(dr["noon_break"].ToString());
                afternoon_break = clsValidRule.ConvertStrToDouble(dr["afternoon_break"].ToString());
                evening_break = clsValidRule.ConvertStrToDouble(dr["evening_break"].ToString());
            }
            else
            {
                start_prd_time = "";
                noon_break = 0;
                afternoon_break = 0;
                evening_break = 0;
            }
        }
        private void gvSchedule_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ////////自動生成序號
            //if (e.Column.VisibleIndex == 1000) // 检查是否是序列号列
            //{
            //    e.DisplayText = (e.ListSourceRowIndex + 1).ToString(); // 显示行号，从1开始
            //}

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSchedule();
        }

        private void SaveSchedule()
        {
            string result = "";
            List<mdlMoSchedule> lsMo = new List<mdlMoSchedule>();
            for (int i = 0; i < dtMoSchedule.Rows.Count; i++)
            {
                DataRow dr = dtMoSchedule.Rows[i];
                if (dr["update_flag"].ToString().Trim() == "1")
                {
                    mdlMoSchedule objMo = new mdlMoSchedule();
                    objMo.schedule_id = dr["schedule_id"].ToString();
                    objMo.prd_dep = dr["prd_dep"].ToString();
                    objMo.prd_group = dr["prd_group"].ToString();
                    objMo.schedule_date = dr["schedule_date"].ToString();
                    objMo.schedule_seq = dr["schedule_seq"].ToString();
                    objMo.prd_mo = dr["prd_mo"].ToString();
                    objMo.prd_item = dr["prd_item"].ToString();
                    objMo.order_date = dr["order_date"].ToString();
                    objMo.order_qty = clsValidRule.ConvertStrToInt(dr["order_qty"].ToString());
                    objMo.pl_qty = clsValidRule.ConvertStrToInt(dr["pl_qty"].ToString());
                    objMo.schedule_qty = clsValidRule.ConvertStrToInt(dr["schedule_qty"].ToString());
                    objMo.need_mon_num = clsValidRule.ConvertStrToInt(dr["need_mon_num"].ToString());
                    objMo.cp_qty = clsValidRule.ConvertStrToInt(dr["cp_qty"].ToString());
                    objMo.pmc_rq_date = dr["pmc_rq_date"].ToString();
                    objMo.pmc_rp_date = dr["pmc_rp_date"].ToString();
                    objMo.dep_rp_date = dr["dep_rp_date"].ToString();
                    objMo.prd_machine = dr["prd_machine"].ToString();
                    objMo.machine_std_run_num = clsValidRule.ConvertStrToInt(dr["machine_std_run_num"].ToString());
                    objMo.machine_std_line_num = clsValidRule.ConvertStrToInt(dr["machine_std_line_num"].ToString());
                    objMo.machine_std_qty = clsValidRule.ConvertStrToInt(dr["machine_std_qty"].ToString());
                    objMo.prd_worker = dr["prd_worker"].ToString();
                    objMo.req_module_time = clsValidRule.ConvertStrToDecimal(dr["req_module_time"].ToString());
                    objMo.req_prd_time = clsValidRule.ConvertStrToDecimal(dr["req_prd_time"].ToString());
                    objMo.req_tot_time = clsValidRule.ConvertStrToDecimal(dr["req_tot_time"].ToString());
                    objMo.start_time = dr["start_time"].ToString();
                    objMo.end_time = dr["end_time"].ToString();
                    objMo.urgent_flag = dr["urgent_flag"].ToString();
                    objMo.status = dr["status"].ToString();
                    objMo.module_type = dr["module_type"].ToString();
                    lsMo.Add(objMo);
                }
            }
            if (lsMo.Count > 0)
            {
                result = clsMoSchedule.SaveMoSchedule(lsMo);
                if (result == "")
                    MessageBox.Show("更新排期表成功!");
            }
        }

        private void btnScheduleMachine_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            sendDep = cmbFindDep.SelectedValue.ToString().Trim();
            DataRow row = gvSchedule.GetFocusedDataRow();
            sendMachine = row["prd_machine"].ToString().Trim();
            frmMachineStdQty frm = new frmMachineStdQty();
            frm.ShowDialog();
            if (frmMachineStdQty.prd_machine != "")
            {
                row["prd_machine"] = frmMachineStdQty.prd_machine;
                row["machine_std_run_num"] = frmMachineStdQty.machine_std_run_num;
                row["machine_std_line_num"] = frmMachineStdQty.machine_std_line_num;
                row["machine_std_qty"] = frmMachineStdQty.machine_std_qty;
                CountPrdQty();
                CountScheduleTime(gvSchedule.FocusedRowHandle);
                CountNeedPrdDays();
                //////返回後設置焦點，不然數據不會更新
                ColumnView newview = (ColumnView)gcSchedule.FocusedView;
                newview.FocusedColumn = newview.Columns["ProcessName"];//定位焦点网格的位置
                                                                       //int FocuseRow_Handle = newview.FocusedRowHandle;//获取新焦点行的FocuseRowHandle
            }
            frm.Dispose();
        }
        /// <summary>
        /// 計算需要生產數量及時間
        /// </summary>
        private void CountPrdQty()
        {
            DataRow row = gvSchedule.GetFocusedDataRow();
            decimal std_run_qty = clsValidRule.ConvertStrToDecimal(row["machine_std_run_num"].ToString());
            decimal line_num = clsValidRule.ConvertStrToDecimal(row["machine_std_line_num"].ToString());
            decimal std_qty= std_run_qty * line_num;
            if (std_qty != 0)
            {
                decimal schedule_qty = clsValidRule.ConvertStrToDecimal(row["schedule_qty"].ToString());
                decimal req_prd_time = 0;
                row["machine_std_qty"] = std_qty;
                row["need_mon_num"] = (int)(schedule_qty / line_num) + 1;
                req_prd_time = Math.Round(schedule_qty / std_qty, 2);
                row["req_prd_time"] = req_prd_time;
                row["req_tot_time"] = clsValidRule.ConvertStrToDecimal(row["req_module_time"].ToString()) + req_prd_time;
                
            }
        }

        private void btnNewSchedule_Click(object sender, EventArgs e)
        {
            //
            //frmMoScheduleBase
            sendDep = cmbFindDep.SelectedValue.ToString().Trim();
            frmPlanWithPrintCard frmMS = new frmPlanWithPrintCard();
            //frmMS.strPrd_dep = cmbFindDep.SelectedValue.ToString();
            //if(frm_Main.isRunMain ==true)
            //    frmMS.MdiParent = frm_Main.ActiveForm;
            frmMS.WindowState = FormWindowState.Maximized;
            //frmMS.Show();
            frmMS.ShowDialog();
            FindData();
        }

        private void chkScheduleByMachine_CheckedChanged(object sender, EventArgs e)
        {
            txtPrdMachine.Focus();
            //if (txtPrdMachine.Text == "")
            //{
            //    MessageBox.Show("沒有選擇排期的機器!");
            //    //chkScheduleByMachine.Checked = false;
            //    return;
            //}
            bool setVisible= chkScheduleByMachine.Checked;
            palShowNotMachine.Visible = setVisible;
            btnAddToMachine.Visible = setVisible;
            //txtPrdMachine.Text = setVisible ? txtPrdMachine.Text : "";
            if (chkScheduleByMachine.Checked == false)
            {
                txtPrdMachine.Text = "";
            }
            else
            {
                if (gvSchedule.RowCount > 0)
                {
                    DataRow row = gvSchedule.GetFocusedDataRow();
                    txtPrdMachine.Text = row["prd_machine"].ToString().Trim();
                }
            }
            FindData();
        }

        private void gvSchedule_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (chkScheduleByMachine.Checked == true)
            {
                DataRow row = gvSchedule.GetFocusedDataRow();
                txtPrdMachine.Text = row["prd_machine"].ToString().Trim();
            }
        }

        private void btnAddToMachine_Click(object sender, EventArgs e)
        {
            ScheduleMachine();
        }

        private void btnSetParas_Click(object sender, EventArgs e)
        {
            sendDep = cmbFindDep.SelectedValue.ToString().Trim();
            frmMoScheduleBase frmMS = new frmMoScheduleBase();
            frmMS.ShowDialog();
        }

        private void btnShowMore_Click(object sender, EventArgs e)
        {
            if(btnShowMore.Text==">>")
            {
                btnShowMore.Text = "<<";
                palShowMore.Visible = true;
            }
            else
            {
                btnShowMore.Text = ">>";
                palShowMore.Visible = false;
            }
        }

        private void btnSetMoStatus_Click(object sender, EventArgs e)
        {
            ConfMoStatus();
            
        }
        private void ConfMoStatus()
        {
            List<mdlMoSchedule> lsMo = new List<mdlMoSchedule>();
            // 获取选中的行索引
            int[] selectedRows = gvSchedule.GetSelectedRows();

            if (selectedRows.Length > 0)
            {
                foreach (int rowIndex in selectedRows)
                {
                    mdlMoSchedule objModel = new mdlMoSchedule();
                    // 获取每行的值
                    objModel.schedule_id = gvSchedule.GetRowCellValue(rowIndex, "schedule_id").ToString().Trim();
                    objModel.status = cmbSetStatus.SelectedValue.ToString().Trim();
                    lsMo.Add(objModel);
                }
                string result = clsMoSchedule.SaveSetMoStatus(lsMo);
                if (result == "")
                    FindData();
                else
                    MessageBox.Show("更新機器排期失敗！");
            }
            else
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }

        }

        private void chkScheduleByMachine_Click(object sender, EventArgs e)
        {

        }

        private void gvSchedule_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle+1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText =(e.RowHandle+1).ToString();// "G" + 
                }
            }
        }

        private void gvWaitSchedule_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnDepPrd_Click(object sender, EventArgs e)
        {
            
            if (dtMoSchedule.Rows.Count > 0)
            {
                DataRow row = gvSchedule.GetFocusedDataRow();
                sendMo = row["prd_mo"].ToString().Trim();
            }
            sendDep = cmbFindDep.SelectedValue.ToString().Trim();
            frmDepPrdoduction frmSP = new frmDepPrdoduction();

            //if (frm_Main.isRunMain == true)
            //    frmSP.MdiParent = frm_Main.ActiveForm;//this;
            frmSP.WindowState = FormWindowState.Maximized;
            frmSP.Show();
        }

        private void btnExpToExcel_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = cmbFindDep.SelectedValue.ToString().Trim()+"部門排期表";
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            string fileName = "";
            string result = "";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                fileName = saveFile.FileName;
                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();

                //**********************
                result=clsMoScheduleUse.DataToExcel(fileName, dtMoSchedule);
                //**********************
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });

                //MessageBox.Show(result);
                
            }
            
        }

        private void btnGenScheduleSeq_Click(object sender, EventArgs e)
        {
            ReSetSecheduleID();//重新生成排序號
        }

        private void ScheduleMachine()
        {
            List<mdlMoSchedule> lsMo = new List<mdlMoSchedule>();
            // 获取选中的行索引
            int[] selectedRows = gvWaitSchedule.GetSelectedRows();

            if (selectedRows.Length > 0)
            {
                DataRow row = gvSchedule.GetFocusedDataRow();
                string prd_machine = row["prd_machine"].ToString().Trim();
                int scheduleSeq = 9000;
                foreach (int rowIndex in selectedRows)
                {
                    mdlMoSchedule objModel = new mdlMoSchedule();
                    // 获取每行的值
                    objModel.schedule_id = gvWaitSchedule.GetRowCellValue(rowIndex, "schedule_id").ToString().Trim();
                    objModel.schedule_seq = scheduleSeq.ToString("D3").PadLeft(3, '0');
                    objModel.prd_machine = prd_machine;
                    lsMo.Add(objModel);
                    scheduleSeq++;
                }
                string result=clsMoSchedule.SaveScheduleMachine(lsMo);
                if (result == "")
                    FindData();
                else
                    MessageBox.Show("更新機器排期失敗！");
            }
            else
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }

        }

        private void gvSchedule_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = gvSchedule.FocusedRowHandle;
            DataRow dr = dtMoSchedule.Rows[rowIndex];
            //gvSchedule.SetRowCellValue(e.RowHandle, "gclUpdateFlag", "1");
            dr["update_flag"] = "1";
            //if (e.Column.FieldName == "pmc_rp_date")
            //{
            //    //gvSchedule.SetRowCellValue(e.RowHandle, e.Column, Convert.ToDateTime(e.Value.ToString()).ToString("yyyy/MM/dd"));
            //    dr["pmc_rp_date"] = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy/MM/dd");
            //}
            //if (e.Column.FieldName == "dep_rp_date")
            //{
            //    dr["dep_rp_date"] = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy/MM/dd");
            //}
            //////自動計算生產時間
            if (e.Column.FieldName == "start_time" || e.Column.FieldName == "req_module_time" || e.Column.FieldName == "req_prd_time")
            {
                CountScheduleTime(gvSchedule.FocusedRowHandle);
                CountNeedPrdDays();
            }
            //////自動計算生產數量及生產時間
            if (e.Column.FieldName == "schedule_qty" || e.Column.FieldName == "prd_machine" || e.Column.FieldName == "machine_std_run_num"
                || e.Column.FieldName == "machine_std_line_num" || e.Column.FieldName == "machine_std_qty")
            {
                CountPrdQty();
                CountScheduleTime(gvSchedule.FocusedRowHandle);//重新計算生產時間
                CountNeedPrdDays();
            }
        }
        private void CountScheduleTime(int currRow)
        {
            DataRow drCurr = dtMoSchedule.Rows[currRow];
            string start_date_time = "", end_date_time = "";
            string count_date_time = "";
            string start_machine = "";
            double rq_tot_time = 0;
            start_date_time = drCurr["start_time"].ToString();
            start_machine = drCurr["prd_machine"].ToString().Trim();
            if (start_date_time == "")
                start_date_time = System.DateTime.Now.ToString("yyyy/MM/dd") + " " + start_prd_time;
            for (int i = currRow; i < dtMoSchedule.Rows.Count; i++)
            {
                DataRow dr = dtMoSchedule.Rows[i];
                //if (dr["prd_machine"].ToString().Trim() == start_machine)
                //{
                start_date_time = AdjStartTime(start_date_time);
                dr["start_time"] = start_date_time;
                    dr["req_tot_time"] = clsValidRule.ConvertStrToDecimal(dr["req_module_time"].ToString())
                        + clsValidRule.ConvertStrToDecimal(dr["req_prd_time"].ToString());
                    rq_tot_time = clsValidRule.ConvertStrToDouble(dr["req_tot_time"].ToString());
                double dayTime = 24;
                double work_time = dayTime - noon_break - afternoon_break - evening_break;
                double dayRate = (int)(rq_tot_time / work_time);
                double balTime = rq_tot_time - dayRate * work_time;
                    
                    end_date_time = Convert.ToDateTime(start_date_time).AddHours(dayRate*dayTime+balTime).ToString("yyyy-MM-dd HH:mm");
                //count_date_time = AdjStartTime(end_date_time);
                if (rq_tot_time < work_time)//完成時數 < 每日工作時數
                {
                    count_date_time = AdjPrdTime(start_date_time, end_date_time);
                }
                else//完成時數 > 每日工作時數
                {
                    count_date_time = AdjEndTime(end_date_time);//再校正結束時間
                    //count_date_time = AdjEndTime(count_date_time);//再校正結束時間
                }

                dr["end_time"] = count_date_time;
                start_date_time = dr["end_time"].ToString();
                //}
            }
        }
        private string AdjStartTime(string start_date_time)
        {
            string start_date= start_date_time.Substring(0, 10);
            string start_time = start_date_time.Substring(11, 5);
            if (string.Compare(start_time, work_out1) > 0 && string.Compare(start_time, work_in2) < 0)
                start_time = "14:00";
            else if (string.Compare(start_time, work_out2) > 0 && string.Compare(start_time, work_in3) < 0)
                start_time = "19:00";
            else if (string.Compare(start_time, work_out3) > 0 && string.Compare(start_time, break_out3) < 0)
            {
                start_date = Convert.ToDateTime(start_date_time).AddDays(1).ToString("yyyy/MM/dd HH:mm").Substring(0, 10);
                start_time = "08:30";
            }
            else if (string.Compare(start_time, break_in4) > 0 && string.Compare(start_time, break_out4) < 0)
            {
                start_date = Convert.ToDateTime(start_date_time).AddDays(1).ToString("yyyy/MM/dd HH:mm").Substring(0, 10);
                start_time = "08:30";
            }
            //else
            //    start_time = "08:30";
            return start_date + " " + start_time;
        }
        private string AdjPrdTime(string start_date_time,string end_date_time)
        {

            string count_date_time = end_date_time;
            string start_time = start_date_time.Substring(11, 5);
            string end_time = end_date_time.Substring(11, 5);


            ////// 開始、結束都在：08:30 ~ 12:30
            if ((string.Compare(start_time, work_in1) >= 0 && string.Compare(start_time, work_out1) <= 0))
            {
                if ((string.Compare(end_time, work_in1) >= 0 && string.Compare(end_time, work_out1) <= 0))
                    count_date_time = end_date_time;
                ////// 結束在：12:31 ~ 18:00，加：noon_break
                else if ((string.Compare(end_time, work_out1) > 0 && string.Compare(end_time, work_out2) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break).ToString("yyyy-MM-dd HH:mm");
                ////// 結束在：18:01~21:00，加：noon_break+afternoon_break
                else if ((string.Compare(end_time, work_out2) > 0 && string.Compare(end_time, work_out3) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break + afternoon_break).ToString("yyyy-MM-dd HH:mm");
                ////// 結束在：21:01~23:59，加：noon_break+afternoon_break+evening_break
                else if ((string.Compare(end_time, work_out3) > 0 && string.Compare(end_time, break_out3) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break + afternoon_break + evening_break).ToString("yyyy-MM-dd HH:mm");
                ////// 結束在：00:01~08:29，加：noon_break+afternoon_break+evening_break
                else if ((string.Compare(end_time, break_in4) >= 0 && string.Compare(end_time, break_out4) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break + afternoon_break + evening_break).ToString("yyyy-MM-dd HH:mm");
            }////// 開始在：14:00 ~ 18:00
            else if ((string.Compare(start_time, work_in2) >= 0 && string.Compare(start_time, work_out2) <= 0))
            {
                ////// 結束在：14:00 ~ 18:00
                if ((string.Compare(end_time, work_in2) >= 0 && string.Compare(end_time, work_out2) <= 0))
                    count_date_time = end_date_time;
                ////// 結束在：18:01~21:00，加：afternoon_break
                else if ((string.Compare(end_time, work_out2) > 0 && string.Compare(end_time, work_out3) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(afternoon_break).ToString("yyyy-MM-dd HH:mm");
                ////// 結束在：21:01~23:59，加：afternoon_break + evening_break
                else if ((string.Compare(end_time, work_out3) > 0 && string.Compare(end_time, break_out3) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(afternoon_break + evening_break).ToString("yyyy-MM-dd HH:mm");
                ////// 結束在：00:00~08:29，加：afternoon_break + evening_break
                else if ((string.Compare(end_time, break_in4) >= 0 && string.Compare(end_time, break_out4) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(afternoon_break + evening_break).ToString("yyyy-MM-dd HH:mm");
            }////// 開始在：19:00 ~ 21:00
            else if ((string.Compare(start_time, work_in3) >= 0 && string.Compare(start_time, work_out3) <= 0))
            {
                ////// 結束在：19:00 ~ 21:00
                if ((string.Compare(end_time, work_in3) >= 0 && string.Compare(end_time, work_out3) <= 0))
                    count_date_time = end_date_time;
                ////// 結束在：21:01~23:59，加：evening_break
                else if ((string.Compare(end_time, work_out3) > 0 && string.Compare(end_time, break_out3) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(evening_break).ToString("yyyy-MM-dd HH:mm");
                ////// 結束在：00:00~08:29，加：evening_break
                else if ((string.Compare(end_time, break_in4) >= 0 && string.Compare(end_time, break_out4) <= 0))
                    count_date_time = Convert.ToDateTime(end_date_time).AddHours(evening_break).ToString("yyyy-MM-dd HH:mm");
            }
            return count_date_time;
        }

        private string AdjEndTime(string end_date_time)
        {
            string count_date_time = end_date_time;
            string end_time = end_date_time.Substring(11, 5);
            //////結束　跨：12:31~18:00，加：noon_break
            if (string.Compare(end_time, work_out1) >= 0 && string.Compare(end_time, work_out2) <= 0)
                count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break).ToString("yyyy-MM-dd HH:mm");
            else//////結束　跨：18:01~21:00，加：noon_break+afternoon_break
            if (string.Compare(end_time, work_out2) >= 0 && string.Compare(end_time, work_out3) <= 0)
                count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break+afternoon_break).ToString("yyyy-MM-dd HH:mm");
            else//////結束　跨：21:01~23:59，加： noon_break + afternoon_break + evening_break
            if (string.Compare(end_time, break_in3) >= 0 && string.Compare(end_time, break_out3) <= 0)
                count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break + afternoon_break + evening_break).ToString("yyyy-MM-dd HH:mm");
            else//////結束　跨：00:00 ~ 08:29，加：noon_break + afternoon_break + evening_break
            if (string.Compare(end_time, break_in4) >= 0 && string.Compare(end_time, break_out4) <= 0)
                count_date_time = Convert.ToDateTime(end_date_time).AddHours(noon_break + afternoon_break + evening_break).ToString("yyyy-MM-dd HH:mm");
            return count_date_time;
        }
        private void btnMakeOrderStatus_Click(object sender, EventArgs e)
        {
            frmShowPlan frmSP = new frmShowPlan();
            if (dtMoSchedule.Rows.Count > 0)
            {
                DataRow row = gvSchedule.GetFocusedDataRow();
                frmSP.strMo_id = row["prd_mo"].ToString().Trim();
            }
            //if (frm_Main.isRunMain == true)
            //    frmSP.MdiParent = frm_Main.ActiveForm;//this;
            frmSP.WindowState = FormWindowState.Maximized;
            frmSP.Show();
        }


        

    }
}
