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
using DevExpress.XtraGrid.Columns;

namespace cf01.Forms
{
    public partial class frmMoSchedule : Form
    {
        private string user_id = DBUtility._user_id;
        public static string sendDate = "";
        public static string sendDep = "";
        public static string sendMachine = "";
        public static string send_prd_mo = "";
        public static string send_prd_item = "";
        private DataTable dtMoSchedule = new DataTable();
        //private DataRow cutRow;
        //private int pasteRowIndex;
        private int[] selectedRowHandles;
        //private List<DataRow> copiedRows = new List<DataRow>(); // 用于保存复制的数据行
        private List<object[]> copiedRows = new List<object[]>();
        private string start_prd_time = "";
        private string work_in1 = "", work_out1 = "";
        private string work_in2 = "", work_out2 = "";
        private string work_in3 = "", work_out3 = "";
        private string break_in3 = "", break_out3 = "";
        private string break_in4 = "", break_out4 = "";
        private double noon_break = 0, afternoon_break = 0, evening_break = 0;
        private string need_cal_time = "0";//是否排時間
        public frmMoSchedule()
        {
            InitializeComponent();
        }
        private void frmMoSchedule_Load(object sender, EventArgs e)
        {
            txtDep.Focus();
            SetCombox();
        }
        private void SetCombox()
        {

            //////表格中的制單狀態標識
            lueGvStatus.DataSource = clsBaseData.loadDocFlag("mo_schedule");
            lueGvStatus.ValueMember = "flag_id";
            lueGvStatus.DisplayMember = "flag_cdesc";
            //////批量設定中的制單狀態標識
            cmbSetStatus.DataSource = clsBaseData.loadDocFlag("mo_schedule");
            cmbSetStatus.ValueMember = "flag_id";
            cmbSetStatus.DisplayMember = "flag_cdesc";
            //////查詢條件中的制單狀態標識
            cmbMoStatus.DataSource = clsBaseData.loadDocFlag("mo_schedule");
            cmbMoStatus.ValueMember = "flag_id";
            cmbMoStatus.DisplayMember = "flag_cdesc";
            //cmbMoStatus.SelectedValue = "01";
            //////查詢條件中的完成數狀態標識
            cmbCpStatus.DataSource = clsBaseData.loadDocFlag("CP_STATE");
            cmbCpStatus.ValueMember = "flag_id";
            cmbCpStatus.DisplayMember = "flag_cdesc";
            cmbCpStatus.SelectedValue = "0";
            //////表格中的急單狀態標識
            lueGvUrgentFlag.DataSource = clsBaseData.loadDocFlag("mo_urgent_status");
            lueGvUrgentFlag.ValueMember = "flag_id";
            lueGvUrgentFlag.DisplayMember = "flag_cdesc";
            //////批量設定中的急單狀態標識
            lueSetUrgentMo.Properties.DataSource = clsBaseData.loadDocFlag("mo_urgent_status");
            lueSetUrgentMo.Properties.ValueMember = "flag_id";
            lueSetUrgentMo.Properties.DisplayMember = "flag_cdesc";

            //////模具類型
            lueModuleType.DataSource = clsBaseData.loadDocFlag("schedule_module_type");
            lueModuleType.ValueMember = "flag_id";
            lueModuleType.DisplayMember = "flag_cdesc";
            
        }


        private void cutMenuItem_Click(object sender, EventArgs e)
        {

            //int selectedIndex = gvSchedule.FocusedRowHandle;
            //if (selectedIndex >= 0)
            //{
            //    cutRow = dtMoSchedule.NewRow();
            //    cutRow.ItemArray = dtMoSchedule.Rows[selectedIndex].ItemArray;
            //    pasteRowIndex = selectedIndex;
            //    //dtMoSchedule.Rows.RemoveAt(selectedIndex); // 从 DataTable 移除
            //}
            //return;
            // 获取选中的行索引
            selectedRowHandles = gvSchedule.GetSelectedRows();
            if (selectedRowHandles.Length == 0)
            {
                MessageBox.Show("请先选中要复制的行！");
                return;
            }

            // 保存选中行数据到缓存
            copiedRows.Clear();
            //foreach (var rowHandle in selectedRowHandles)
            //{
            //    var row = gvSchedule.GetDataRow(rowHandle);
            //    copiedRows.Add(row);
            //}

            foreach (var rowHandle in selectedRowHandles)
            {
                var row = gvSchedule.GetDataRow(rowHandle);
                copiedRows.Add(row.ItemArray); // 保存行的所有数据
            }


            //// 从数据源移除选中行
            //foreach (var row in copiedRows)
            //{
            //    dtMoSchedule.Rows.Remove(row);
            //}



            //MessageBox.Show($"{copiedRows.Count} 行已复制！");


        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            //if (cutRow != null)
            //{
            //    dtMoSchedule.Rows.RemoveAt(pasteRowIndex); // 从绑定的 DataTable 中移除
            //    int targetIndex = gvSchedule.FocusedRowHandle;
            //    if (targetIndex >= 0)
            //    {
            //        dtMoSchedule.Rows.InsertAt(cutRow, targetIndex); // 插入到目标位置
            //        ReSetSecheduleID();//重新生成排序號
            //        if (targetIndex == 0)
            //            dtMoSchedule.Rows[targetIndex]["start_time"] = System.DateTime.Now.ToString("yyyy/MM/dd") + " " + start_prd_time;
            //        else
            //            dtMoSchedule.Rows[targetIndex]["start_time"] = dtMoSchedule.Rows[targetIndex - 1]["end_time"];
            //        CountScheduleTime(targetIndex);//重新生成排期日期
            //        cutRow = null; // 清空剪切行记录
            //    }
            //    else
            //    {
            //        MessageBox.Show("请先选择一个目标行！");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("没有剪切的行可以粘贴！");
            //}
            //return;

            if (copiedRows.Count == 0)
            {
                MessageBox.Show("没有复制的行可以粘贴！");
                return;
            }
            int targetRowHandle = gvSchedule.FocusedRowHandle;
            int orgRowIndex = targetRowHandle;
            //// 获取右键点击目标位置的行索引
            //var clientPoint = gvSchedule.GridControl.PointToClient(Cursor.Position);
            //var hitInfo = gvSchedule.CalcHitInfo(clientPoint);
            //int targetRowHandle = hitInfo.RowHandle;

            if (targetRowHandle < 0)
            {
                MessageBox.Show("请右键点击有效的目标行！");
                return;
            }
            ////// 从数据源移除选中行
            //foreach (var rowIndex in selectedRowHandles)
            //{
            //    dtMoSchedule.Rows.RemoveAt(rowIndex);
            //}

            //// 从数据源移除选中行
            //foreach (var rowHandle in selectedRowHandles)
            //{
            //    dtMoSchedule.Rows.Remove(gvSchedule.GetDataRow(rowHandle));
            //}

            // 將原記錄移除
            foreach (var itemArray in copiedRows)
            {
                string id = "";
                if (txtDep.Text.Trim() == "102")
                    id = itemArray[1].ToString();
                else
                    id = itemArray[0].ToString();
                // 查找产品编号为 "P001" 的记录
                var foundRows = dtMoSchedule.Select("schedule_id = '" + id + "'");
                if(foundRows.Length==0)
                {
                    MessageBox.Show("沒有選中記錄!單號:" + id.Trim());
                    break;
                }
                DataRow dr = foundRows[0];
                int rowIndex = dtMoSchedule.Rows.IndexOf(dr); // 获取行索引号
                dtMoSchedule.Rows.Remove(gvSchedule.GetDataRow(rowIndex));
            }

            // 在目标位置插入复制的行
            foreach (var itemArray in copiedRows)
            {
                var newRow = dtMoSchedule.NewRow();
                newRow.ItemArray = itemArray;// row.ItemArray; // 复制行数据
                dtMoSchedule.Rows.InsertAt(newRow, targetRowHandle);
                targetRowHandle++;
            }
            copiedRows.Clear();
            ReSetSecheduleID();//重新生成排序號
            if (orgRowIndex == 0)
                dtMoSchedule.Rows[orgRowIndex]["start_time"] = System.DateTime.Now.ToString("yyyy/MM/dd") + " " + start_prd_time;
            else
                dtMoSchedule.Rows[orgRowIndex]["start_time"] = dtMoSchedule.Rows[orgRowIndex - 1]["end_time"];
            CountScheduleTime(orgRowIndex);//重新生成排期日期
            //MessageBox.Show("粘贴成功！");
            gvSchedule.FocusedRowHandle = targetRowHandle - 1; // 聚焦到最后插入的行
            

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            lueDepGroup.Focus();
            if (ChkUpdateStatus())
            {
                if (MessageBox.Show("存在未儲存的記錄，確定刷新嗎？", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
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
            LoadData(0);
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void LoadData(int rpt_type)
        {
            int sch_by_machine = 0;
            dtMoSchedule= LoadData1(rpt_type,sch_by_machine);
            gcSchedule.DataSource = dtMoSchedule;
            gvSchedule.ActiveFilter.Clear();
            if (chkScheduleByMachine.Checked == true)
            {
                sch_by_machine = 1;
                gcWaitSchedule.DataSource = LoadData1(rpt_type,sch_by_machine);
            }
            CountNeedPrdDays();
            // 注册 CustomColumnDisplayText 事件
            //gvSchedule.CustomColumnDisplayText += gvSchedule_CustomColumnDisplayText;
        }
        private DataTable LoadData1(int rpt_type,int sch_by_machine)
        {
            string prd_dep = txtDep.Text.Trim();
            string prd_group = lueDepGroup.EditValue != null ? lueDepGroup.EditValue.ToString() : "";
            string mo_status = cmbMoStatus.SelectedValue != null ? cmbMoStatus.SelectedValue.ToString() : "";
            string cp_status = cmbCpStatus.SelectedValue != null ? cmbCpStatus.SelectedValue.ToString().Trim() : "0";
            prd_group = prd_group == "00" ? "" : prd_group;
            string prd_machine = txtPrdMachine.Text.Trim();
            DataTable dtSch = clsMoSchedule.LoadMoSchedule(rpt_type,prd_dep, prd_group, prd_machine, sch_by_machine, mo_status, user_id, cp_status);
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
                txtScheduleQty.Text = clsValidRule.ConvertStrToDecimal(schedule_qty.ToString()).ToString("#,##0");
                txtNotCpQty.Text = clsValidRule.ConvertStrToDecimal(not_cp_qty.ToString()).ToString("#,##0");
                txtReqTotTime.Text = clsValidRule.ConvertStrToDecimal(req_tot_time.ToString()).ToString("#,##0.00");
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
                //if (scheduleSeq == 20)//只產生到20的次序，再多次序沒有意義
                //    break;
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            lueDepGroup.Focus();
            if(ChkUpdateStatus())
            {
                if (MessageBox.Show("存在未儲存的記錄，確定退出嗎？", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void btnMachine_status_Click(object sender, EventArgs e)
        {
            frmMachineStatus1 frmMS = new frmMachineStatus1();
            frmMS.strPrd_dep = txtDep.Text.Trim();
            //if(frm_Main.isRunMain ==true)
            //    frmMS.MdiParent = frm_Main.ActiveForm;
            frmMS.WindowState = FormWindowState.Maximized;
            //frmMS.Show();
            frmMS.ShowDialog();
        }

        private void GetScheduleBase()
        {
            DataTable dtScheduleBase = clsMoSchedule.LoadScheduleBase(txtDep.Text.Trim());
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
                need_cal_time = dr["need_cal_time"].ToString().Trim();
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
            lueDepGroup.Focus();
            SaveSchedule();
        }

        private void SaveSchedule()
        {
            string result = "";
            //System.Data.DataTable dtSave = dtMoSchedule.Copy();
            //System.Data.DataTable dtNewSave = new System.Data.DataTable();
            //DataView dv = dtSave.DefaultView;
            //dv.RowFilter = "update_flag = " + "'" + "1" + "'";
            //dtNewSave = dv.ToTable();
            // 使用 Select 方法过滤记录，例如年龄大于 28
            DataRow[] drMo = dtMoSchedule.Select("update_flag = " + "1");
            if(drMo.Length==0)
            {
                MessageBox.Show("沒有儲存的記錄!");
                return;
            }
            //prgSave.Visible = true;
            prgStatus.Minimum = 0;
            prgStatus.Maximum = drMo.Length;
            prgStatus.Value = 0;

            List<mdlMoSchedule> lsMo = new List<mdlMoSchedule>();
            for (int i = 0; i < drMo.Length; i++)
            {
                //DataRow dr = dtMoSchedule.Rows[i];
                prgStatus.Value = i;
                mdlMoSchedule objMo = new mdlMoSchedule();
                objMo.wip_id = drMo[i]["wip_id"].ToString().Trim();
                objMo.wip_seq = drMo[i]["wip_seq"].ToString().Trim();
                objMo.wip_ver = clsValidRule.ConvertStrToInt(drMo[i]["wip_ver"].ToString().Trim());
                objMo.schedule_id = drMo[i]["schedule_id"].ToString().Trim();
                objMo.prd_dep = drMo[i]["prd_dep"].ToString().Trim();
                objMo.prd_group = drMo[i]["prd_group"].ToString().Trim();
                objMo.schedule_date = drMo[i]["schedule_date"].ToString().Trim();
                objMo.now_date = drMo[i]["now_date"].ToString().Trim();
                objMo.schedule_seq = drMo[i]["schedule_seq"].ToString().Trim();
                objMo.prd_mo = drMo[i]["prd_mo"].ToString().Trim();
                objMo.prd_item = drMo[i]["prd_item"].ToString().Trim();
                objMo.order_date = drMo[i]["order_date"].ToString().Trim();
                objMo.order_qty = clsValidRule.ConvertStrToInt(drMo[i]["order_qty"].ToString());
                objMo.pl_qty = clsValidRule.ConvertStrToInt(drMo[i]["pl_qty"].ToString());
                objMo.schedule_qty = clsValidRule.ConvertStrToInt(drMo[i]["schedule_qty"].ToString());
                objMo.need_mon_num = clsValidRule.ConvertStrToInt(drMo[i]["need_mon_num"].ToString());
                objMo.cp_qty = clsValidRule.ConvertStrToInt(drMo[i]["cp_qty"].ToString());
                objMo.pmc_rq_date = drMo[i]["pmc_rq_date"].ToString().Trim();
                objMo.pmc_rp_date = drMo[i]["pmc_rp_date"].ToString().Trim();
                objMo.dep_rp_date = drMo[i]["dep_rp_date"].ToString().Trim();
                objMo.prd_machine = drMo[i]["prd_machine"].ToString().Trim();
                objMo.machine_std_run_num = clsValidRule.ConvertStrToInt(drMo[i]["machine_std_run_num"].ToString());
                objMo.machine_std_line_num = clsValidRule.ConvertStrToInt(drMo[i]["machine_std_line_num"].ToString());
                objMo.machine_std_qty = clsValidRule.ConvertStrToInt(drMo[i]["machine_std_qty"].ToString());
                objMo.prd_worker = drMo[i]["prd_worker"].ToString();
                objMo.req_module_time = clsValidRule.ConvertStrToDecimal(drMo[i]["req_module_time"].ToString());
                objMo.req_prd_time = clsValidRule.ConvertStrToDecimal(drMo[i]["req_prd_time"].ToString());
                objMo.req_tot_time = clsValidRule.ConvertStrToDecimal(drMo[i]["req_tot_time"].ToString());
                objMo.start_time = drMo[i]["start_time"].ToString().Trim();
                objMo.end_time = drMo[i]["end_time"].ToString().Trim();
                objMo.urgent_flag = drMo[i]["urgent_flag"].ToString().Trim();
                objMo.status = drMo[i]["status"].ToString().Trim();
                objMo.module_type = drMo[i]["module_type"].ToString().Trim();
                objMo.mo_remark = drMo[i]["mo_remark"].ToString().Trim();
                objMo.dep_remark = drMo[i]["dep_remark"].ToString().Trim();
                objMo.module_no = drMo[i]["module_no"].ToString().Trim();
                objMo.module_install = drMo[i]["module_install"].ToString().Trim();
                objMo.next_wp_id = drMo[i]["next_wp_id"].ToString().Trim();
                objMo.pre_tr_qty = clsValidRule.ConvertStrToInt(drMo[i]["pre_tr_qty"].ToString());
                objMo.pre_tr_date = drMo[i]["pre_tr_date"].ToString().Trim();
                objMo.pre_tr_flag = drMo[i]["pre_tr_flag"].ToString().Trim();
                lsMo.Add(objMo);
            }
            if (lsMo.Count > 0)
            {
                result = clsMoSchedule.SaveMoSchedule(lsMo);
                if (result == "")
                {
                    prgStatus.Value = 0;
                    //prgSave.Visible = false;
                    MessageBox.Show("更新排期表成功!");
                    FindData();
                }
            }
        }

        private void btnScheduleMachine_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            sendDep = txtDep.Text.Trim();
            DataRow row = gvSchedule.GetFocusedDataRow();
            sendMachine = row["prd_machine"].ToString().Trim();
            frmMachineStdQty frm = new frmMachineStdQty();
            frm.ShowDialog();
            if (frmMachineStdQty.prd_machine != "")
            {
                int rowIndex = gvSchedule.FocusedRowHandle;
                row["prd_machine"] = frmMachineStdQty.prd_machine;
                row["machine_std_run_num"] = frmMachineStdQty.machine_std_run_num;
                row["machine_std_line_num"] = frmMachineStdQty.machine_std_line_num;
                row["machine_std_qty"] = frmMachineStdQty.machine_std_qty;
                row["update_flag"] = "1";
                CountPrdQty(rowIndex);
                CountScheduleTime(rowIndex);
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
        private void CountPrdQty(int rowIndex)
        {
            DataRow row = dtMoSchedule.Rows[rowIndex];// gvSchedule.GetFocusedDataRow();
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
            lueDepGroup.Focus();
            if (ChkUpdateStatus())
            {
                if (MessageBox.Show("存在未儲存的記錄，確定新增排期嗎？", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            //
            //frmMoScheduleBase
            sendDep = txtDep.Text.Trim();
            frmPlanWithPrintCard frmMS = new frmPlanWithPrintCard();
            //frmMS.strPrd_dep = txtDep.Text.Trim();
            //if(frm_Main.isRunMain ==true)
            //    frmMS.MdiParent = frm_Main.ActiveForm;
            frmMS.WindowState = FormWindowState.Maximized;
            //frmMS.Show();
            frmMS.ShowDialog();
            FindData();
        }

        private void chkScheduleByMachine_CheckedChanged(object sender, EventArgs e)
        {
            lueDepGroup.Focus();
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

            decimal total = 0;
            decimal value = 0; // 先定义变量
            foreach (var cell in gvSchedule.GetSelectedCells())
            {
                ////decimal value;
                //if (cell != null && decimal.TryParse(cell.ToString(), out value)) // 这里检查 `cell`
                //{
                //    total += value;
                //}

                object cellValue = gvSchedule.GetRowCellValue(cell.RowHandle, cell.Column);
                if (cellValue != null && cellValue != DBNull.Value && decimal.TryParse(cellValue.ToString(), out value))
                //if (cellValue != null && decimal.TryParse(cellValue.ToString(), out value)) // 这里检查 `cell`
                {
                    total += value;
                }
            }
            lblTotal.Text = $"选中单元格的总和: {total.ToString("#,##0")}";

        }

        private void btnAddToMachine_Click(object sender, EventArgs e)
        {
            ScheduleMachine();
        }

        private void btnSetParas_Click(object sender, EventArgs e)
        {
            sendDep = txtDep.Text.Trim();
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
            SetMoOperations(1);
            
        }
        private void btnSetMachine_Click(object sender, EventArgs e)
        {
            SetMoOperations(2);
        }
        private void btnSetUrgentMo_Click(object sender, EventArgs e)
        {
            SetMoOperations(3);
        }
        //設定制單的各種狀態
        private void SetMoOperations(int opera_type)
        {
            List<mdlMoSchedule> lsMo = new List<mdlMoSchedule>();
            // 获取选中的行索引
            int[] selectedRows = gvSchedule.GetSelectedRows();

            if (selectedRows.Length == 0)
            {
                MessageBox.Show("没有选中任何行！");
                return;
            }
            foreach (int rowIndex in selectedRows)
            {
                mdlMoSchedule objModel = new mdlMoSchedule();
                //注意！不能用這個索引值作為DataTable中的索引值，因為如果DataView過濾後這個值就不準確的了
                DataRow drGv = gvSchedule.GetDataRow(rowIndex);
                int rowIndex1 = dtMoSchedule.Rows.IndexOf(drGv);//記錄對應在DataTable中的索引

                DataRow dr = dtMoSchedule.Rows[rowIndex1];
                objModel.schedule_id = dr["schedule_id"].ToString().Trim();
                objModel.update_flag = "1";
                if (opera_type == 1)//設定制單狀態
                {
                    objModel.status = cmbSetStatus.SelectedValue.ToString().Trim();
                    if (objModel.status == "02")
                    {
                        objModel.prd_dep = dr["prd_dep"].ToString().Trim();
                        objModel.prd_mo = dr["prd_mo"].ToString().Trim();
                        objModel.prd_item = dr["prd_item"].ToString().Trim();
                        objModel.next_wp_id = dr["next_wp_id"].ToString().Trim();
                    }
                }
                else if (opera_type == 2)//設定制單機器
                {
                    string dep = dr["prd_dep"].ToString().Trim();
                    string machine_id = luePrdMachine.EditValue.ToString().Trim();
                    string machine_std_run_num = "", machine_std_line_num = "", machine_std_qty = "";
                    DataTable dtMachine = clsMoSchedule.GetMachineStdQty(dep, machine_id);
                    if (dtMachine.Rows.Count > 0)
                    {
                        DataRow drMachine = dtMachine.Rows[0];
                        machine_std_run_num = drMachine["machine_rate"].ToString();
                        machine_std_line_num = drMachine["machine_mul"].ToString();
                        machine_std_qty = drMachine["machine_std_qty"].ToString();

                    }
                    dr["prd_machine"] = machine_id;
                    dr["machine_std_run_num"] = machine_std_run_num;
                    dr["machine_std_line_num"] = machine_std_line_num;
                    dr["machine_std_qty"] = machine_std_qty;
                    dr["update_flag"] = "1";
                    CountPrdQty(rowIndex1);
                }
                else if (opera_type == 3)//設定急單狀態
                {
                    objModel.urgent_flag = lueSetUrgentMo.EditValue.ToString().Trim();
                }
                lsMo.Add(objModel);

            }

            string result = clsMoSchedule.SaveSetMoStatus(opera_type, lsMo);
            if (result == "")
                FindData();
            else
                MessageBox.Show("更新排期表失敗！");

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
                send_prd_mo = row["prd_mo"].ToString().Trim();
            }
            sendDep = txtDep.Text.Trim();
            frmDepPrdoduction frmSP = new frmDepPrdoduction();

            //if (frm_Main.isRunMain == true)
            //    frmSP.MdiParent = frm_Main.ActiveForm;//this;
            frmSP.WindowState = FormWindowState.Maximized;
            frmSP.Show();
        }

        private void btnExpToExcel_Click(object sender, EventArgs e)
        {
            lueDepGroup.Focus();
            ExpToExcel(1);
        }
        private void btnExcelByMachine_Click(object sender, EventArgs e)
        {
            lueDepGroup.Focus();
            ExpToExcel(2);
        }
        private void ExpToExcel(int rpt_type)
        {
            if (ChkUpdateStatus())
            {
                if (MessageBox.Show("存在未儲存的記錄，確定匯出到Excel嗎？", "系統信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            string prd_dep = txtDep.Text.Trim();
            SaveFileDialog saveFile = new SaveFileDialog();
            string fileName = prd_dep + "部門排期表";
            if (rpt_type == 99)
                fileName = prd_dep + "部門排期統計表";
            if (rpt_type == 2)
                fileName += "按機器";
            saveFile.FileName = fileName;

            saveFile.Filter = "Excel files(*.xlsx)|*.xlsx";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";

            string result = "";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFile.FileName;
            }
            if (fileName == "")
                return;
            //frmProgress wForm = new frmProgress();
            //new Thread((ThreadStart)delegate
            //{
            //    wForm.TopMost = true;
            //    wForm.ShowDialog();
            //}).Start();
            //Thread.Sleep(1000);
            DataTable dtExcel = new DataTable();
            if (rpt_type != 99)
            {
                if (chkOver3Days.Checked == false)
                    dtExcel = dtMoSchedule.Copy();
                else
                {
                    // 使用 LINQ 过滤记录，例如过滤年龄大于 28 的记录
                    string overDays = System.DateTime.Now.AddDays((0 - clsValidRule.ConvertStrToInt(txtOver3Days.Text))).ToString("yyyy/MM/dd");
                    var filteredRows = dtMoSchedule.AsEnumerable().Where(row => string.Compare(row.Field<string>("schedule_date"), overDays) < 0);

                    // 将过滤后的记录存储到新 DataTable 中
                    dtExcel = filteredRows.Any() ? filteredRows.CopyToDataTable() : dtMoSchedule.Clone(); // 如果没有结果则创建空表
                }

                ////**********************
                ////result = clsMoScheduleUse.DataToExcel(prd_dep, fileName, dtMoSchedule, rpt_type);
                result = clsMoScheduleUse.ExpToExcelEPP(prd_dep, fileName, dtExcel, rpt_type, prgStatus);
                ////**********************
                //wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            }
            else
            {
                dtExcel = LoadData1(1, 0);
                result = clsMoScheduleUse.ExpToExcelSum(prd_dep, fileName, dtExcel, rpt_type, prgStatus);
            }
            if (result != "")
                MessageBox.Show(result);
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
            //////注意：不能用這兩句來獲取當前記錄，因為如果過濾後，表格的序號就回變了，導致序號不准確了。
            //int rowIndex = gvSchedule.FocusedRowHandle;
            //DataRow dr = dtMoSchedule.Rows[rowIndex];
            //////可用以下兩句來獲取：
            DataRow dr = gvSchedule.GetDataRow(gvSchedule.FocusedRowHandle);
            int rowIndex = dtMoSchedule.Rows.IndexOf(dr);//記錄對應在DataTable中的索引
            //DataRow dr = gvSchedule.GetDataRow(e.RowHandle);

            //gvSchedule.SetRowCellValue(e.RowHandle, "gclUpdateFlag", "1");
            dr["update_flag"] = "1";
            //if (e.Column.FieldName == "pmc_rp_date")
            //{
            //    //gvSchedule.SetRowCellValue(e.RowHandle, e.Column, Convert.ToDateTime(e.Value.ToString()).ToString("yyyy/MM/dd"));
            //    dr["pmc_rp_date"] = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy/MM/dd");
            //}


            //////暫時取消以下
            if (e.Column.FieldName == "prd_machine")
            {
                GetMachineStdQty();
            }
            //////自動計算生產時間
            if (e.Column.FieldName == "start_time" || e.Column.FieldName == "req_module_time" || e.Column.FieldName == "req_prd_time")
            {
                CountScheduleTime(rowIndex);
                CountNeedPrdDays();
            }
            //////自動計算生產數量及生產時間
            if (e.Column.FieldName == "schedule_qty" || e.Column.FieldName == "prd_machine" || e.Column.FieldName == "machine_std_run_num"
                || e.Column.FieldName == "machine_std_line_num" || e.Column.FieldName == "machine_std_qty")
            {
                CountPrdQty(rowIndex);
                CountScheduleTime(rowIndex);//重新計算生產時間
                CountNeedPrdDays();
            }



        }

        private void gvSchedule_MouseUp(object sender, MouseEventArgs e)
        {
            //var hitInfo = gvSchedule.CalcHitInfo(e.Location);
            //if (hitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column)
            //{
            //    // 获取点击的列
            //    var column = hitInfo.Column;
            //    if (column != null)
            //    {
            //        // 遍历行并选择该列的数据
            //        for (int rowIndex = 0; rowIndex < gvSchedule.RowCount; rowIndex++)
            //        {
            //            gvSchedule.SelectCell(rowIndex, column);
            //        }

            //        //MessageBox.Show($"列 '{column.FieldName}' 已选中！");
            //    }

            //}

        }

        private void gvSchedule_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = gvSchedule.CalcHitInfo(e.Location);

            // 检查是否点击了目标列
            if (hitInfo.InRowCell)
            {
                if (hitInfo.Column.FieldName == "prd_group" || hitInfo.Column.FieldName == "urgent_flag" || hitInfo.Column.FieldName == "status")
                {
                    gvSchedule.FocusedColumn = hitInfo.Column;
                    gvSchedule.FocusedRowHandle = hitInfo.RowHandle;
                    gvSchedule.ShowEditor(); // 单击触发编辑器
                }
            }
        }

        private void btnPrdItemFind_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            DataRow row = gvSchedule.GetFocusedDataRow();
            sendDep = row["prd_dep"].ToString().Trim();
            send_prd_mo = row["prd_mo"].ToString().Trim();
            send_prd_item=row["prd_item"].ToString().Trim();
            frmMoScheduleDepGroup frm = new frmMoScheduleDepGroup();
            frm.ShowDialog();
            if (frmMoScheduleDepGroup.prd_group != "")
            {
                int rowIndex = gvSchedule.FocusedRowHandle;
                row["prd_group"] = frmMoScheduleDepGroup.prd_group;
                row["update_flag"] = "1";
                //////返回後設置焦點，不然數據不會更新
                ColumnView newview = (ColumnView)gcSchedule.FocusedView;
                newview.FocusedColumn = newview.Columns["ProcessName"];//定位焦点网格的位置
                //int FocuseRow_Handle = newview.FocusedRowHandle;//获取新焦点行的FocuseRowHandle
            }
            frm.Dispose();
        }

        private void txtDep_Leave(object sender, EventArgs e)
        {
            GetScheduleBase();
            string prd_dep = txtDep.Text.Trim();
            //////部門組別
            luePrdGroup.DataSource = clsBaseData.loadScheduleDepGroup(prd_dep);
            luePrdGroup.ValueMember = "grp_code";
            luePrdGroup.DisplayMember = "grp_code";

            lueDepGroup.Properties.DataSource = clsBaseData.loadScheduleDepGroup(prd_dep);
            lueDepGroup.Properties.ValueMember = "grp_code";
            lueDepGroup.Properties.DisplayMember = "grp_cdesc";
            // 部門機器
            luePrdMachine.Properties.DataSource = clsBaseData.LoadMachineStd(prd_dep);
            luePrdMachine.Properties.ValueMember = "machine_id";  // 绑定值字段
            luePrdMachine.Properties.DisplayMember = "machine_id";  // 绑定显示字段,machine_rate,machine_mul
            if (prd_dep == "105")
            {
                gvSchedule.Columns["remark_105"].Visible = true;  // 显示列
                gvSchedule.Columns["remark_105"].VisibleIndex = 6;  // 设置为第一列
                gvSchedule.Columns["pass_days"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gvSchedule.Columns["prd_group"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gvSchedule.Columns["urgent_flag"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            else
            {
                gvSchedule.Columns["remark_105"].Visible = false;  // 隱藏列
                gvSchedule.Columns["pass_days"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                gvSchedule.Columns["prd_group"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                gvSchedule.Columns["urgent_flag"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            }
            //foreach (GridColumn col in gvSchedule.Columns)
            //{
            //    var col1 = col;
            //    col.Visible = col.FieldName != "備註105"; // 隐藏某些列

            //}

            //foreach (GridColumn col in gvSchedule.Columns)
            //{
            //    if (col.FieldName == "remark_105")
            //    {
            //        if (prd_dep == "105")
            //            col.Visible = true;
            //        else
            //            col.Visible = false;
            //    }
            //}


            //gvSchedule.PopulateColumns(); // 重新生成列
        }

        private void btnExpSum_Click(object sender, EventArgs e)
        {
            ExpToExcel(99);
        }

        private void gvSchedule_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // 获取该行的数据
            object cellValue = gvSchedule.GetRowCellValue(e.RowHandle, "status");

            // 判断值是否为 "Y"，如果是则设置为红色
            if (cellValue != null && cellValue.ToString() == "04")
            {
                e.Appearance.BackColor = Color.Red;  // 设置背景色
                e.Appearance.ForeColor = Color.White; // 设置字体颜色（可选）
            }


        }

        //////計算預生產開始、結束時間
        private void CountScheduleTime(int currRow)
        {
            if (need_cal_time == "0")//0--不用排到時間；1--安排到時間
                return;
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
                dr["update_flag"] = "1";
                start_date_time = dr["end_time"].ToString();
                //}
            }
        }
        //////調整開始時間，當開始時間在休息區間時，調整到對應的上班時間
        private string AdjStartTime(string start_date_time)
        {
            string start_date= start_date_time.Substring(0, 10);
            string start_time = start_date_time.Substring(11, 5);
            if (string.Compare(start_time, work_out1) > 0 && string.Compare(start_time, work_in2) < 0)
                start_time = work_in2;
            else if (string.Compare(start_time, work_out2) > 0 && string.Compare(start_time, work_in3) < 0)
                start_time = work_in3;
            else if (string.Compare(start_time, work_out3) > 0 && string.Compare(start_time, break_out3) < 0)
            {
                start_date = Convert.ToDateTime(start_date_time).AddDays(1).ToString("yyyy/MM/dd HH:mm").Substring(0, 10);
                start_time = start_prd_time;
            }
            else if (string.Compare(start_time, break_in4) > 0 && string.Compare(start_time, break_out4) < 0)
            {
                start_date = Convert.ToDateTime(start_date_time).AddDays(1).ToString("yyyy/MM/dd HH:mm").Substring(0, 10);
                start_time = start_prd_time;
            }
            //else
            //    start_time = "08:30";
            return start_date + " " + start_time;
        }
        //調整結束時間，當計算的結束時間在休息區間時，調整到正常的工作時段
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

        private void GetMachineStdQty()
        {
            int rowIndex = gvSchedule.FocusedRowHandle;
            DataRow dr = dtMoSchedule.Rows[rowIndex];
            dr["update_flag"] = "1";
            DataTable dtMachine=clsMoSchedule.GetMachineStdQty(dr["prd_dep"].ToString().Trim(), dr["prd_machine"].ToString().Trim());
            if(dtMachine.Rows.Count>0)
            {
                DataRow drMachine = dtMachine.Rows[0];
                dr["machine_std_run_num"] = drMachine["machine_rate"].ToString();
                dr["machine_std_line_num"] = drMachine["machine_mul"].ToString();
                dr["machine_std_qty"] = drMachine["machine_std_qty"].ToString();
                CountPrdQty(rowIndex);
            }
            
        }
        private bool ChkUpdateStatus()
        {
            bool update_status = false;
            for(int i=0;i<dtMoSchedule.Rows.Count;i++)
            {
                if (dtMoSchedule.Rows[i]["update_flag"].ToString().Trim() == "1")
                {
                    update_status = true;
                    break;
                }
                    
            }
            return update_status;
        }


    }
}
