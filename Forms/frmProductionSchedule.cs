using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RUI.PC;
using cf01.MDL;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmProductionSchedule : Form
    {
        DataTable dtPrd_dept = new DataTable();
        DataTable dtMo_item = new DataTable();
        DataTable dtWork_type = new DataTable();
        DataTable dtMachine_std = new DataTable();
        DataTable dtProductionRecordslist = new DataTable();
        private string edit_type = "Y";//控制當控件中當值發生變化時的操作
        private clsUtility.enumOperationType OperationType;
        private int Result = 0;
        private string _userid = DBUtility._user_id;
        private product_records objModel;
        private int record_id = -1;//未完成記錄的ID，若查找到，則說明未完成，在保存時，執行更新操作

        public frmProductionSchedule()
        {
            InitializeComponent();

            //clsControlInfoHelper controlInfo = new clsControlInfoHelper("frmProductionSchedule", this.Controls);
            //controlInfo.GenerateContorl();

            GetAllComboxData();
        }

        private void frmProductionSchedule_Load(object sender, EventArgs e)
        {
            InitComBoxs();

            //加載時讓條碼框獲得焦點
            txtBarCode.Focus();

            Font a = new Font("GB2312", 10);//GB2312为字体名称，1为字体大小dataGridView1.Font = a;
            dgvDetails.Font = a;

            dgvDetails.AutoGenerateColumns = false;
            if (cmbProductDept.Text == "105")
                cmbWorkType.Text = "生產";

        }

        //獲取生產部門、工作類型
        private void GetAllComboxData()
        {
            try
            {
                dtPrd_dept = clsProductionSchedule.GetAllPrd_dept();
                dtWork_type = clsProductionSchedule.GetWorkType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitComBoxs()
        {
            //初始化生產部門
            cmbProductDept.DataSource = dtPrd_dept;
            cmbProductDept.DisplayMember = "int9loc";
            cmbProductDept.ValueMember = "int9loc";
            if (_userid.Substring(0, 3).ToUpper() == "BUT")
            {
                cmbProductDept.Text = "102";
            }
            else
            {
                if (_userid.Substring(0, 3).ToUpper() == "ALY")
                    cmbProductDept.Text = "302";
                else
                {
                    if (_userid.Substring(0, 3).ToUpper() == "BUK")
                        cmbProductDept.Text = "202";
                    else
                    {
                        if (_userid.Substring(0, 3).ToUpper() == "BLK")
                            cmbProductDept.Text = "105";
                    }
                }
            }
            //初始化工作類型
            cmbWorkType.DataSource = dtWork_type;
            cmbWorkType.DisplayMember = "work_type_desc";
            cmbWorkType.ValueMember = "work_type_id";

            InitComBoxGroup();
            //初始化班次、組別
            cmbOrder_class.Items.Add("白班");
            cmbOrder_class.Items.Add("夜班");
            cmbOrder_class.Text = "白班";




            //mktProdcutDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            dtePrdPdate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }
        private void InitComBoxGroup()
        {
            string strSql = "";
            strSql = " SELECT work_group,group_desc FROM work_group WHERE ( dep='" + cmbProductDept.Text.Trim() + "'" + " AND group_type='" + "2" + "') " + " OR dep='" + "000" + "' ";
            DataTable dtGroup = clsPublicOfPad.GetDataTable(strSql);
            if (dtGroup.Rows.Count > 0)
            {
                cmbGroup.DataSource = dtGroup;
                cmbGroup.DisplayMember = "work_group";
                cmbGroup.ValueMember = "work_group";
            }
            //cmbGroup.Items.Clear();
            //if (cmbProductDept.Text == "102")
            //{
            //    cmbGroup.Items.Add("BA01");
            //    cmbGroup.Text = "BA01";
            //}
            //else
            //{
            //    if (cmbProductDept.Text == "302")
            //    {
            //        cmbGroup.Items.Add("AA01");
            //        cmbGroup.Items.Add("AA02");
            //        cmbGroup.Items.Add("AA03");
            //        cmbGroup.Items.Add("AA04");
            //        cmbGroup.Items.Add("AA05");
            //        cmbGroup.Text = "AA01";
            //    }
            //    else
            //    {
            //        if (cmbProductDept.Text == "104")
            //        {
            //            cmbGroup.Items.Add("BB01");
            //            cmbGroup.Text = "BB01";
            //        }
            //        else
            //        {
            //            if (cmbProductDept.Text == "106")
            //            {
            //                cmbGroup.Items.Add("BB01");
            //                cmbGroup.Text = "BB01";
            //            }
            //            else
            //            {
            //                if (cmbProductDept.Text == "105")
            //                {
            //                    cmbGroup.Items.Add("BC01");
            //                    cmbGroup.Items.Add("BC02");
            //                    cmbGroup.Items.Add("BC03");
            //                    cmbGroup.Items.Add("BC04");
            //                    cmbGroup.Items.Add("BC05");
            //                    //cmbGroup.Text = "BC01";
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void txtmo_id_Leave(object sender, EventArgs e)
        {
            cmbGoods_id.Text = "";
            txtgoods_desc.Text = "";
            if (txtmo_id.Text != "" && cmbProductDept.Text != "")
            {
                GetMo_itme("");
            }
        }

        //獲取制單編號資料，并綁定物料編號
        private void GetMo_itme(string item)
        {
            cmbGoods_id.Items.Clear();
            string fdep = cmbProductDept.SelectedValue.ToString();
            string tdep = "";
            try
            {
                dtMo_item = clsProductionSchedule.GetMo_dataById(txtmo_id.Text.Trim(), fdep,tdep, item);
                if (dtMo_item.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMo_item.Rows.Count; i++)
                    {
                        cmbGoods_id.Items.Add(dtMo_item.Rows[i]["goods_id"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //查詢未完成的記錄，並重新賦值，便於重新輸入完整資料
        private void get_prd_records(int con_type)
        {
            try
            {
                //獲取制單編號資料
                string sql = "";
                sql += " Select a.*,rtrim(b.work_type_desc) as work_type_desc ";
                sql += " From product_records a ";
                sql += " Left outer join work_type b on a.prd_work_type=b.work_type_id ";
                sql += " Where a.prd_dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'";
                if (con_type == 1)//是否查找當日未完成標識
                {
                    sql += " And a.prd_mo = " + "'" + txtmo_id.Text.ToString() + "'";
                    sql += " And a.prd_item = " + "'" + cmbGoods_id.Text.ToString() + "'";
                }
                else
                {
                    if (con_type == 2)//未完成的記錄
                    {
                        sql += " And a.prd_start_time <> " + "'" + "" + "'" + " And a.prd_end_time = " + "'" + "" + "'";
                    }
                    else
                    {
                        if (con_type == 3)//如果是查找當日所有記錄
                            sql += " And a.prd_date = " + "'" + dtePrdPdate.Text + "'";
                        else
                        {
                            if (con_type == 4)//未開始生產的記錄
                            {
                                sql += " And a.prd_start_time = " + "'" + "" + "'" + " And a.prd_end_time = " + "'" + "" + "'";
                            }
                            else
                            {
                                if (con_type == 5)//當天完成的記錄
                                {
                                    sql += " And a.prd_date = " + "'" + dtePrdPdate.Text + "'";
                                    sql += " And a.prd_start_time <> " + "'" + "" + "'" + " And a.prd_end_time <> " + "'" + "" + "'";
                                }
                                else
                                {
                                    if (con_type == 6)//按制單編號查詢未完成的記錄
                                    {
                                        sql += " And a.prd_mo like " + "'%" + txtSearchMo.Text + "%'";
                                        sql += " And a.prd_end_time = " + "'" + "" + "'";
                                    }
                                    else
                                    {
                                        if (con_type == 7)//按制單編號查詢所有記錄
                                        {
                                            sql += " And a.prd_mo like " + "'%" + txtSearchMo.Text + "%'";
                                        }
                                        else
                                        {
                                            if (con_type == 8)//按記錄號查找，並單時使用
                                            {
                                                sql += " And a.prd_id = " + "'" + record_id.ToString() + "'";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (cmbProductDept.SelectedValue.ToString() == "302")//如果是合金部，則不顯示選貨的記錄
                    sql += " And a.prd_work_type <> " + "'" + "A03" + "'";
                sql += " Order By a.prd_pdate desc,a.prd_end_time,a.crtim ";
                dtProductionRecordslist = clsPublicOfPad.GetDataTable(sql);

                //清空並將查找到未完成的記錄填充到各文本框
                //clear_text_box();
                //chk_prd_no_complete();
                //fill_dg_prd();//將查詢到的記錄存入列表
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            //GBW004725
        }

        //默認時，將未完成的記錄填入
        private void chk_prd_no_complete()
        {
            record_id = -1;
            if (dtProductionRecordslist.Rows.Count > 0)
            {
                for (int i = 0; i < dtProductionRecordslist.Rows.Count; i++)
                {
                    if (dtProductionRecordslist.Rows[i]["prd_end_time"].ToString() == "" || dtProductionRecordslist.Rows[i]["prd_end_time"].ToString() == "00:00")
                        fill_exist_record(i);
                }
            }
        }
        //重新填入查找到的記錄
        private void fill_exist_record(int index)
        {
            record_id = Convert.ToInt32(dtProductionRecordslist.Rows[index]["prd_id"].ToString());//更新記錄序號
            mktProdcutDate.Text = dtProductionRecordslist.Rows[index]["prd_date"].ToString();
            dtePrdPdate.Text = dtProductionRecordslist.Rows[index]["prd_pdate"].ToString();
            cmbOrder_class.Text = dtProductionRecordslist.Rows[index]["prd_class"].ToString();
            cmbGroup.Text = dtProductionRecordslist.Rows[index]["prd_group"].ToString();

            txtMachine.Text = dtProductionRecordslist.Rows[index]["prd_machine"].ToString();
            txtProductNo.Text = dtProductionRecordslist.Rows[index]["prd_worker"].ToString();
            cmbWorkType.Text = dtProductionRecordslist.Rows[index]["work_type_desc"].ToString().Trim();
            dtpStart.Value = Convert.ToDateTime("2014/01/01 " + dtProductionRecordslist.Rows[index]["prd_start_time"].ToString());
            dtpEnd.Value = Convert.ToDateTime("2014/01/01 " + dtProductionRecordslist.Rows[index]["prd_end_time"].ToString());
            txtNormal_work.Text = (dtProductionRecordslist.Rows[index]["prd_normal_time"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["prd_normal_time"].ToString() : "");
            txtAdd_work.Text = (dtProductionRecordslist.Rows[index]["prd_ot_time"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["prd_ot_time"].ToString() : "");
            txtRow_qty.Text = (dtProductionRecordslist.Rows[index]["line_num"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["line_num"].ToString() : "");
            txtPer_Convert_qty.Text = (dtProductionRecordslist.Rows[index]["hour_run_num"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["hour_run_num"].ToString() : "");
            txtper_Standrad_qty.Text = (dtProductionRecordslist.Rows[index]["hour_std_qty"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["hour_std_qty"].ToString() : "");
            txtPrd_qty.Text = (dtProductionRecordslist.Rows[index]["prd_qty"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["prd_qty"].ToString() : "");
            txtprd_weg.Text = (dtProductionRecordslist.Rows[index]["prd_weg"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["prd_weg"].ToString() : "");
            txtkgPCS.Text = (dtProductionRecordslist.Rows[index]["kg_pcs"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["kg_pcs"].ToString() : "");
            txtDifficulty_level.Text = dtProductionRecordslist.Rows[index]["difficulty_level"].ToString();
            txtMatItem.Text = dtProductionRecordslist.Rows[index]["mat_item"].ToString();
            txtMatDesc.Text = dtProductionRecordslist.Rows[index]["mat_item_desc"].ToString();
            txtMatLot.Text = dtProductionRecordslist.Rows[index]["mat_item_lot"].ToString();
            dtpReqEnd.Text = dtProductionRecordslist.Rows[index]["prd_req_time"].ToString();
            txtToDep.Text = dtProductionRecordslist.Rows[index]["to_dep"].ToString();
            txtPrd_Run_qty.Text = dtProductionRecordslist.Rows[index]["prd_run_qty"].ToString();
            txtWork_code.Text = dtProductionRecordslist.Rows[index]["work_code"].ToString();
            txtSpeed_lever.Text = dtProductionRecordslist.Rows[index]["speed_lever"].ToString();
            txtPack_num.Text = (dtProductionRecordslist.Rows[index]["pack_num"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["pack_num"].ToString() : "");
            txtStart_run.Text = (dtProductionRecordslist.Rows[index]["start_run"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["start_run"].ToString() : "0");
            txtEnd_run.Text = (dtProductionRecordslist.Rows[index]["end_run"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["end_run"].ToString() : "");
            txtPrd_id_ref.Text = (dtProductionRecordslist.Rows[index]["prd_id_ref"].ToString() != "0" ? dtProductionRecordslist.Rows[index]["prd_id_ref"].ToString() : "");
            setProdDate();//自動設定生產日期為當前日期
            if (cmbProductDept.Text == "105" && cmbGroup.Text == "")
            {
                if (_userid == "BLK01")
                    cmbGroup.Text = "BC01";
                else
                {
                    if (_userid == "BLK02")
                        cmbGroup.Text = "BC02";
                    else
                    {
                        if (_userid == "BLK03")
                            cmbGroup.Text = "BC03";
                        else
                        {
                            if (_userid == "BLK04")
                                cmbGroup.Text = "BC04";
                            else
                            {
                                if (_userid == "BLK05")
                                    cmbGroup.Text = "BC05";
                            }
                        }
                    }
                }
            }
        }
        //自動設定生產日期為當前日期
        private void setProdDate()
        {
            if (dtpStart.Text == "00:00" || dtpEnd.Text == "00:00")//若未有生產日期的，設定為當日生產的
            {
                if (cmbOrder_class.SelectedIndex == 0)//白班
                    mktProdcutDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
                else//夜班
                {
                    string now_time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm").Substring(11, 5);
                    if (string.Compare(now_time, "20:30") >= 0 && string.Compare(now_time, "23:59") <= 0)
                        mktProdcutDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
                    else
                    {
                        if (string.Compare(now_time, "00:00") >= 0 && string.Compare(now_time, "08:30") <= 0)//如果是凌晨的，當前日期減一日
                            mktProdcutDate.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                        else
                        {
                            mktProdcutDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 綁定列表
        /// </summary>
        private void FillGrid()
        {
            if (dtProductionRecordslist.Rows.Count > 0)
            {
                dgvDetails.DataSource = dtProductionRecordslist;
                //dgvDetails.Refresh();
            }
            else
            {
                dgvDetails.DataSource = null;
                dgvDetails.Refresh();
            }
        }
        //ToolStripButton click 事件集合
        private void ToolStripButtonEvents()
        {
            switch (OperationType)
            {
                case clsUtility.enumOperationType.Find:
                    {
                        get_prd_records(3);//查詢當日所有的記錄
                        FillGrid(); //將查詢到的記錄存入列表
                    }
                    break;
                case clsUtility.enumOperationType.Delete:
                    {
                        if (dgvDetails.Rows.Count > 0)
                        {
                            if (MessageBox.Show("確定要刪除嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int prd_id = Convert.ToInt32(dgvDetails["colPrd_Id", dgvDetails.CurrentRow.Index].Value);
                                int re = clsProductionSchedule.DeleteProductionRecords(prd_id);
                                if (re > 0)
                                {
                                    MessageBox.Show("刪除成功!");

                                    get_prd_records(1);//查詢已錄入的記錄
                                    FillGrid(); //將查詢到的記錄存入列表

                                }
                                else
                                {
                                    MessageBox.Show("刪除失敗!");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("沒有要刪除的記錄。");
                        }
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {
                        ClearAllText();
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        AfterSave();  //執行保存后的事件

                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 當保存執行完之後的事件
        /// </summary>
        private void AfterSave()
        {
            if (Result > 0)
            {
                string show_message = "保存成功!";
                try
                {
                    //更新物料每KG對應的數量表
                    if (cmbProductDept.Text.Trim() != "" && cmbGoods_id.Text.Trim() != "" && txtkgPCS.Text.Trim() != "" && cmbWorkType.Text.Trim() == "生產")
                    {
                        int kg_pcs_rate = get_kg_pcs_rate();
                        if (kg_pcs_rate != Convert.ToInt32(txtkgPCS.Text))
                        {
                            int re = clsProductionSchedule.InsertOrUpdateItem_rate(objModel, kg_pcs_rate);
                            if (re > 0)
                            {

                            }
                            else
                                MessageBox.Show("保存物料每KG轉換數量失败!");
                        }
                    }
                    
                    if (cmbWorkType.Text.Trim() == "校模" && dtpEnd.Text != "00:00")//如果是校模儲存後，自動轉入生產狀態
                    {
                        record_id = -1;//重新轉入新增記錄狀態
                        txtProductNo.Text = "";
                        dtpStart.Value = dtpEnd.Value;//生產完成後，將校模完成時間作為生產開始時間DateTime.Now;
                        dtpEnd.Value = Convert.ToDateTime("2014/01/01 " + "00:00");
                        txtNormal_work.Text = "";
                        txtAdd_work.Text = "";
                        cmbWorkType.Text = "生產";
                        chkcont_work1.Checked = false;
                        chkcont_work2.Checked = false;
                        show_message = "保存成功，校模完成，自動轉入生產狀態，可以點擊儲存按鈕以保存記錄!";
                    }

                    get_prd_records(1);//查詢未完成的記錄
                    FillGrid();//將查詢到的記錄存入列表
                    //ClearAllText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show(show_message);
            }
            else
            {
                MessageBox.Show("保存失敗!");
            }
        }

        /// <summary>
        /// 物料編號值改變后觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGoods_id_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
            {
                get_data_details();
                if (cmbProductDept.Text == "302")//若是302部門的
                {
                    //檢查是否有並單，若有則返回。
                    if (DistMo(txtmo_id.Text, cmbGoods_id.Text) == false)
                    {
                        return;
                    }
                    txtRow_qty.Text = "";
                    txtPer_Convert_qty.Text = "";
                    txtper_Standrad_qty.Text = "";
                    if (txtMachine.Text.Trim() != "")
                    {
                        GetMachine_std();//獲取機器的各項標準數據
                        fill_textbox_machine_std();//填充機器各項標準
                    }
                }
            }
        }
        //檢查是否有分單
        private bool DistMo(string prd_mo_sub, string prd_item_sub)
        {
            bool chk_result = false;
            string join_mo, join_date;
            int prd_id,prd_id_ref;
            int upd_result;
            int prd_qty;
            DataTable dtJoin = chkDistMo(1, prd_mo_sub, prd_item_sub);
            if (dtJoin.Rows.Count > 0)//檢查是否有已並單的記錄
            {
                join_mo = dtJoin.Rows[0]["prd_mo"].ToString();
                join_date = dtJoin.Rows[0]["prd_date"].ToString();
                if ((int)MessageBox.Show("曾經並過單生產,是否再建立新單？" + "\n" + "\n" + "制單編號：" + join_mo + " 生產日期：" + join_date, "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == 6)
                    chk_result = true;//如果是“是”，則開新單
                else//不建立新單，用舊單
                    return false;
            }

            dtJoin = chkDistMo(2, prd_mo_sub, prd_item_sub);//檢查之前是否有未完成的相同貨的記錄
            if (dtJoin.Rows.Count > 0)
            {
                join_mo = dtJoin.Rows[0]["prd_mo"].ToString();
                join_date = dtJoin.Rows[0]["prd_date"].ToString();
                prd_id = (int)dtJoin.Rows[0]["prd_id"];
                //prd_id_ref = (int)dtJoin.Rows[0]["prd_id_ref"];
                prd_id_ref = (dtJoin.Rows[0]["prd_id_ref"].ToString() !="" ? Convert.ToInt32(dtJoin.Rows[0]["prd_id_ref"].ToString()):0);
                prd_qty = (txtPrd_qty.Text != "" ? Convert.ToInt32(txtPrd_qty.Text) : 0);
                if ((int)MessageBox.Show("之前有相同未生產完成貨品的記錄,是否並單生產？" + "\n" + "\n" + "制單編號：" + join_mo + " 生產日期：" + join_date, "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 6)
                {
                    string strSQL = "Select prd_id_ref from product_records_dist_mo Where prd_id_ref =" + "'" + prd_id_ref + "'" + " and prd_mo_sub=" + "'" + prd_mo_sub + "'";
                    DataTable dtChkDistMo = clsPublicOfPad.GetDataTable(strSQL);
                    if (dtChkDistMo.Rows.Count == 0)
                    {
                        upd_result = clsProductionSchedule.AddDistMo(prd_id_ref, prd_mo_sub, prd_item_sub, prd_qty, _userid, System.DateTime.Now);
                        if (upd_result>0)
                            upd_result = clsProductionSchedule.SumPrdQty(prd_id, prd_qty, _userid, System.DateTime.Now);
                        if (upd_result > 0)
                            MessageBox.Show("保存並單成功!");
                        else
                            MessageBox.Show("保存並單失敗!");
                        chk_result = false;
                    }
                    else
                    {
                        MessageBox.Show("已存在並單的記錄,不能再並單!");
                        chk_result = false;
                    }
                }else
                    chk_result = true;//不並單生產，獨立開單生產
            }
            else
                chk_result = true;

            return chk_result;
        }
        //檢查是否有已分單的MO
        private DataTable chkDistMo(int chk_type, string prd_mo_sub, string prd_item_sub)
        {
            DataTable dtJoin = new DataTable();
            try
            {
                //獲取分單資料
                string sql = "";
                if (chk_type == 1)//檢查是否有已分單的MO
                {
                    sql = " Select a.prd_id,a.prd_date,a.prd_mo,a.prd_item,a.prd_id_ref,b.prd_mo_sub,b.prd_item_sub,b.prd_qty_sub " +
                        " From product_records a " +
                        " Inner Join product_records_dist_mo b on a.prd_id_ref=b.prd_id_ref " +
                        " Where a.prd_dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'" +
                        " And b.prd_mo_sub = " + "'" + prd_mo_sub + "'" +
                        " And b.prd_item_sub = " + "'" + prd_item_sub + "'";
                }
                else//檢查是否有未完成的MO,若有則提示是否要分單
                {
                    if (chk_type == 2)
                    {
                        sql = " Select a.prd_id,a.prd_date,a.prd_mo,a.prd_item,a.prd_id_ref " +
                        " From product_records a " +
                        " Where a.prd_dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'" +
                        " And a.prd_item=" + "'" + prd_item_sub + "'" +
                        " And a.prd_end_time =" + "'" + "" + "'";
                    }
                    else
                    {
                        if (chk_type == 3 || chk_type == 4)
                        {
                            sql = " Select a.prd_id,a.prd_date,a.prd_mo,a.prd_item,a.prd_qty,a.prd_id_ref,b.prd_mo_sub,b.prd_item_sub,b.prd_qty_sub " +
                        " From product_records a " +
                        " Inner Join product_records_dist_mo b on a.prd_id_ref=b.prd_id_ref " +
                        " Where a.prd_dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'" ;
                            if (chk_type == 3)//按制單編號查詢分單
                            {
                                if (rdbSearch1.Checked == true)
                                    sql += " And a.prd_mo = " + "'" + prd_mo_sub + "'";
                                if (rdbSearch2.Checked == true)
                                    sql += " And b.prd_mo_sub = " + "'" + prd_mo_sub + "'";
                            }
                            else//按記錄號查詢分單
                            {
                                sql += " And a.prd_id_ref = " + "'" + prd_mo_sub + "'";
                            }
                        }
                    }
                }
                sql += " Order By a.prd_date desc,a.prd_end_time,a.crtim";
                dtJoin = clsPublicOfPad.GetDataTable(sql);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            return dtJoin;
        }
        
        //清空所有輸入值
        private void ClearAllText()
        {
            cmbOrder_class.Text = "";
            cmbGroup.Text = "";
            txtmo_id.Text = "";
            cmbGoods_id.Text = "";
            ClearPartOfText();
        }
        // 清空部份值
        private void ClearPartOfText()
        {
            // cmbProductDept.SelectedText = "";
            mktProdcutDate.Text = "";
            dtePrdPdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtgoods_desc.Text = "";
            txtMachine.Text = "";
            txtkgPCS.Text = "";
            txtPrd_qty.Text = "";
            txtprd_weg.Text = "";
            txtProductNo.Text = "";
            cmbWorkType.Text = "";
            dtpStart.Value = Convert.ToDateTime("2014/01/01 " + "00:00");
            dtpEnd.Value = Convert.ToDateTime("2014/01/01 " + "00:00");
            chkcont_work1.Checked = false;
            chkcont_work2.Checked = false;
            txtNormal_work.Text = "";
            txtAdd_work.Text = "";
            txtRow_qty.Text = "";
            txtPer_Convert_qty.Text = "";
            txtper_Standrad_qty.Text = "";
            txtToDep.Text = "";
            txtMatItem.Text = "";
            txtMatDesc.Text = "";
            txtMatLot.Text = "";
            txtPrd_Run_qty.Text = "";
            txtStart_run.Text = "";
            txtEnd_run.Text = "";
            txtTotalQty.Text = "";
            txtPrd_id_ref.Text = "";
            txtDifficulty_level.Text = "";
            mktProdcutDate.Text = "";
        }

        private void fill_plan_value()
        {
            txtgoods_desc.Text = "";
            for (int i = 0; i < dtMo_item.Rows.Count; i++)
            {
                if (cmbGoods_id.Text.ToString().Trim() == dtMo_item.Rows[i]["goods_id"].ToString().Trim())
                {
                    txtgoods_desc.Text = dtMo_item.Rows[i]["name"].ToString();
                    if (dtMo_item.Rows[i]["prod_qty"].ToString() != "" && txtPrd_qty.Text == "")
                        txtPrd_qty.Text = Convert.ToInt32(dtMo_item.Rows[i]["prod_qty"]).ToString();
                    if (txtToDep.Text.Trim() == "")
                        txtToDep.Text = dtMo_item.Rows[i]["next_wp_id"].ToString();
                    if (txtMatItem.Text.Trim() == "")
                        txtMatItem.Text = dtMo_item.Rows[i]["mat_item"].ToString();
                    if (txtMatDesc.Text.Trim() == "")
                        txtMatDesc.Text = dtMo_item.Rows[i]["mat_item_desc"].ToString();
                    if (txtMatLot.Text.Trim() == "")
                        txtMatLot.Text = "HWH";
                    break;
                }
            }
        }

        //輸入格式驗證
        private bool valid_data()
        {
            if (cmbProductDept.Text == "")
            {
                MessageBox.Show("生產部門不能為空,請重新輸入!");
                cmbProductDept.Focus();
                cmbProductDept.SelectAll();
                return false;
            }
            if (cmbOrder_class.Text == "")
            {
                MessageBox.Show("班次不能為空,請重新輸入!");
                cmbOrder_class.Focus();
                cmbOrder_class.SelectAll();
                return false;
            }
            //if (cmbGroup.Text == "")
            //{
            //    MessageBox.Show("組別不能為空,請重新輸入!");
            //    cmbGroup.Focus();
            //    cmbGroup.SelectAll();
            //    return false;
            //}
            if (txtmo_id.Text == "")
            {
                MessageBox.Show("制單編號不能為空,請重新輸入!");
                txtmo_id.Focus();
                txtmo_id.SelectAll();
                return false;
            }
            if (cmbGoods_id.Text == "")
            {
                MessageBox.Show("物料編號不能為空,請重新輸入!");
                cmbGoods_id.Focus();
                cmbGoods_id.SelectAll();
                return false;
            }
            if (txtPrd_qty.Text != "" && !Verify.StringValidating(txtPrd_qty.Text.Trim(), Verify.enumValidatingType.AllNumber))
            {
                MessageBox.Show("生產數量格式有誤,請重新輸入!");
                txtPrd_qty.Focus();
                txtPrd_qty.SelectAll();
                return false;
            }
            if (txtMachine.Text != "")
            {
                if (checkMachine() == false)
                {
                    txtMachine.Focus();
                    return false;
                }
            }
            //如果是完成的，就要做如下控制
            if (dtpStart.Text != "00:00" && dtpEnd.Text != "00:00")
            {
                if (txtMachine.Text == "")
                {
                    MessageBox.Show("生產機器不能為空，請重新輸入!");
                    txtmo_id.Focus();
                    return false;
                }
                if (txtProductNo.Text == "")
                {
                    MessageBox.Show("生產工號不能為空，請重新輸入!");
                    txtProductNo.Focus();
                    return false;
                }
            }


            if (string.Compare(mktProdcutDate.Text, System.DateTime.Now.ToString("yyyy/MM/dd")) > 0)
            {
                MessageBox.Show("生產日期不能大於當天日期，請重新輸入!");
                mktProdcutDate.Focus();
                return false;
            }
            if (txtprd_weg.Text != "" && !Verify.StringValidating(txtprd_weg.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("重量格式有誤,請重新輸入!");
                txtprd_weg.Focus();
                txtprd_weg.SelectAll();
                return false;
            }
            if (cmbWorkType.Text == "")
            {
                MessageBox.Show("工作類型不能為空,請重新輸入!");
                cmbWorkType.Focus();
                cmbWorkType.SelectAll();
                return false;
            }
            if (txtNormal_work.Text != "" && !Verify.StringValidating(txtNormal_work.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("正常班時間格式有誤,請重新輸入!");
                txtNormal_work.Focus();
                txtNormal_work.SelectAll();
                return false;
            }
            if (txtAdd_work.Text != "" && !Verify.StringValidating(txtAdd_work.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("加班時間格式有誤,請重新輸入!");
                txtAdd_work.Focus();
                txtAdd_work.SelectAll();
                return false;
            }
            if (txtRow_qty.Text != "" && !Verify.StringValidating(txtRow_qty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("每行數格式有誤,請重新輸入!");
                txtRow_qty.Focus();
                txtRow_qty.SelectAll();
                return false;
            }
            if (txtPer_Convert_qty.Text != "" && !Verify.StringValidating(txtPer_Convert_qty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("每小時轉數格式有誤,請重新輸入!");
                txtPer_Convert_qty.Focus();
                txtPer_Convert_qty.SelectAll();
                return false;
            }
            if (txtper_Standrad_qty.Text != "" && !Verify.StringValidating(txtper_Standrad_qty.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("每小時生產量格式有誤,請重新輸入!");
                txtper_Standrad_qty.Focus();
                txtper_Standrad_qty.SelectAll();
                return false;
            }
            if (txtkgPCS.Text != "" && !Verify.StringValidating(txtkgPCS.Text.Trim(), Verify.enumValidatingType.PositiveNumber))
            {
                MessageBox.Show("每KG對應數量的格式有誤,請重新輸入!");
                txtkgPCS.Focus();
                txtkgPCS.SelectAll();
                return false;
            }
            return true;
        }

        //獲取機器的各項標準數據
        private void GetMachine_std()
        {

            string strSql = "";
            string prd_code = "";
            prd_code = (cmbGoods_id.Text.Length >= 18 ? cmbGoods_id.Text.Substring(2, 2) : "");
            if (cmbProductDept.Text == "102" || cmbProductDept.Text == "104" || cmbProductDept.Text == "105")
            {
                strSql = " SELECT machine_id,machine_mul,machine_rate FROM machine_std " +
                               " WHERE dep='" + cmbProductDept.SelectedValue.ToString() + "' AND machine_id ='" + txtMachine.Text.Trim() + "' ";
                strSql = " SELECT machine_id,rows_count AS machine_mul,standard_qty AS machine_rate FROM " + DBUtility.remote_db + "cd_machine_standard " +
                               " WHERE dept_id='" + cmbProductDept.SelectedValue.ToString().Trim() + "' AND machine_id ='" + txtMachine.Text.Trim() + "' ";
            }
            else
                if (cmbProductDept.Text == "302")
                    strSql = @" SELECT machine_id,machine_mul,machine_rate,machine_std_qty FROM machine_std 
                               WHERE dep='" + cmbProductDept.SelectedValue.ToString() + "' AND machine_id ='" + txtMachine.Text.Trim()
                                + "' AND prd_code ='" + prd_code + "' ";
            try
            {
                dtMachine_std = clsPublicOfPad.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //檢查機器代碼是否正確
        private bool checkMachine()
        {
            DataTable mac_tb;
            string strSql = @" SELECT machine_id FROM machine_tb
                               WHERE dep='" + cmbProductDept.SelectedValue.ToString() + "' AND machine_id ='" + txtMachine.Text.Trim() + "' ";
            try
            {
                mac_tb = clsPublicOfPad.GetDataTable(strSql);
                if (mac_tb.Rows.Count == 0)
                {
                    MessageBox.Show("機器代碼輸入不正確,請重新輸入!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        //填充機器各項標準
        private void fill_textbox_machine_std()
        {
            if (dtMachine_std.Rows.Count > 0)
            {
                txtRow_qty.Text = (dtMachine_std.Rows[0]["machine_mul"].ToString() !="" ? Convert.ToInt32(dtMachine_std.Rows[0]["machine_mul"]).ToString():"1");
                txtPer_Convert_qty.Text = (dtMachine_std.Rows[0]["machine_rate"].ToString() !="" ? Convert.ToInt32(dtMachine_std.Rows[0]["machine_rate"]).ToString():"0");
                count_hour_std_qty();//計算機器每小時標準生產數
            }
        }

        private void txtMachine_Leave(object sender, EventArgs e)
        {
            txtRow_qty.Text = "";
            txtPer_Convert_qty.Text = "";
            txtper_Standrad_qty.Text = "";
            if (txtMachine.Text.Trim() != "" && cmbProductDept.Text != "")
            {
                GetMachine_std();//獲取機器的各項標準數據
                fill_textbox_machine_std();//填充機器各項標準
            }
        }

        private void cmbProductDept_TextChanged(object sender, EventArgs e)
        {
            ClearAllText();
        }

        /// <summary>
        /// 新的時間計算
        /// </summary>
        private void count_datetime()
        {
            if (dtpStart.Text.ToString() == "00:00" || dtpEnd.Text.ToString() == "00:00")
                return;
            txtNormal_work.Text = "";
            txtAdd_work.Text = "";
            string current_day = "2000/01/01";
            string str_start_time = "";
            string str_end_time = "";
            string ks_time, js_time;
            double sj = 0, normal_time = 0, ot_time = 0;
            //int std_work_hour = 8;
            TimeSpan ts;
            ks_time = dtpStart.Text.ToString();//開始生產時間
            js_time = dtpEnd.Text.ToString();//結束生產時間
            if (cmbOrder_class.SelectedIndex == 0)//白班
            {
                string am_in_time = "08:00";//早上上班
                string am_out_time = "12:59";//早上下班
                string pm_in_time = "14:00";//下午上班
                string pm_out_time = "18:59";//下午下班
                string night_in_time = "19:00";//晚上上班
                double am_ext_time = 1.5, pm_ext_time = 1;//不是連班應扣除時間
                str_start_time = current_day + " " + ks_time + ":00";//開始生產時間   加上日期便於計算
                str_end_time = current_day + " " + js_time + ":00";//結束生產時間
                ts = Convert.ToDateTime(str_end_time) - Convert.ToDateTime(str_start_time); //結束 - 開始 時間
                sj = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                if ((string.Compare(ks_time, am_in_time) >= 0 && string.Compare(ks_time, am_out_time) == -1 && string.Compare(js_time, am_out_time) == -1)//08:30~12:30
                   || (string.Compare(ks_time, pm_in_time) >= 0 && string.Compare(ks_time, pm_out_time) == -1 && string.Compare(js_time, pm_out_time) == -1))//14:00~18:00
                    normal_time = sj;
                else
                {//>=08:30   >=14:00<18:00
                    if (string.Compare(ks_time, am_in_time) >= 0 && string.Compare(ks_time, am_out_time) == -1 && string.Compare(js_time, pm_in_time) >= 0 && string.Compare(js_time, pm_out_time) == -1)
                    {
                        normal_time = sj - am_ext_time;//正常班時間
                        if (chkcont_work1.Checked == true)//中午連班
                            ot_time = am_ext_time;
                    }
                    else
                    {//>=08:30   >=19:00
                        if (string.Compare(ks_time, am_in_time) >= 0 && string.Compare(ks_time, am_out_time) == -1 && string.Compare(js_time, night_in_time) >= 0)
                        {
                            str_end_time = current_day + " " + night_in_time + ":00";//結束生產時間
                            ts = Convert.ToDateTime(str_end_time) - Convert.ToDateTime(str_start_time); //結束 - 開始 時間
                            sj = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                            normal_time = sj - (am_ext_time + pm_ext_time);
                            if (chkcont_work1.Checked == true)//中午連班
                                ot_time = am_ext_time;
                            if (chkcont_work2.Checked == true)//下午連班
                                ot_time = ot_time + pm_ext_time;
                            //加班時間
                            str_start_time = current_day + " " + night_in_time + ":00";//開始生產時間
                            str_end_time = current_day + " " + js_time + ":00";//結束生產時間
                            ts = Convert.ToDateTime(str_end_time) - Convert.ToDateTime(str_start_time); //結束 - 開始 時間
                            sj = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                            ot_time = ot_time + sj;
                        }
                        else
                        {//晚上加班時間//>=19:00   >=19:00
                            if (string.Compare(ks_time, night_in_time) >= 0 && string.Compare(js_time, night_in_time) >= 0)
                                ot_time = sj;
                            else
                            {//中午開始，晚上結束>=14:00    >=19:00
                                if (string.Compare(ks_time, pm_in_time) >= 0 && string.Compare(ks_time, pm_out_time) == -1 && string.Compare(js_time, night_in_time) >= 0)
                                {
                                    str_end_time = current_day + " " + night_in_time + ":00";//結束生產時間
                                    ts = Convert.ToDateTime(str_end_time) - Convert.ToDateTime(str_start_time); //結束 - 開始 時間
                                    sj = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                                    normal_time = sj - pm_ext_time;
                                    if (chkcont_work2.Checked == true)//下午連班
                                        ot_time = pm_ext_time;
                                    //加班時間
                                    str_start_time = current_day + " " + night_in_time + ":00";//開始生產時間
                                    str_end_time = current_day + " " + js_time + ":00";//結束生產時間
                                    ts = Convert.ToDateTime(str_end_time) - Convert.ToDateTime(str_start_time); //結束 - 開始 時間
                                    sj = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                                    ot_time = ot_time + sj;
                                }
                            }
                        }
                    }
                }
            }
            else //夜班
            {
                string night_start_work_time = "19:00";
                string night_end_work_time = "08:30";
                string ot_start_time = "04:30";
                string day_start_time = "00:00";
                string day_end_time = "24:00";
                string next_day = "2000/01/02";
                string secon_data = ":00";
                string act_ot_start_time = "";//加班開始時間
                string act_ot_end_time = "";//加班結束時間
                bool ot_flag = false;//加班標識
                str_start_time = current_day + " " + ks_time + secon_data;
                str_end_time = current_day + " " + js_time + secon_data;
                if (string.Compare(ks_time, night_start_work_time) >= 0 && string.Compare(ks_time, day_end_time) <= 0
                    && string.Compare(js_time, night_start_work_time) >= 0 && string.Compare(js_time, day_end_time) <= 0)
                    str_end_time = current_day + " " + js_time + secon_data;//開始、結束時間在19:00 ~ 24:00之間 正常班時段
                else
                {
                    if (string.Compare(ks_time, night_start_work_time) >= 0 && string.Compare(ks_time, day_end_time) <= 0
                        && string.Compare(js_time, day_start_time) >= 0 && string.Compare(js_time, ot_start_time) <= 0)
                        str_end_time = next_day + " " + js_time + secon_data;//開始時間在19:00 ~ 24:00;結束時間在00:00~04:30之間 正常班時段
                    else
                    {
                        if (string.Compare(ks_time, day_start_time) >= 0 && string.Compare(ks_time, ot_start_time) <= 0
                        && string.Compare(js_time, day_start_time) >= 0 && string.Compare(js_time, ot_start_time) <= 0)
                            str_end_time = current_day + " " + js_time + secon_data;//開始、結束時間在00:00 ~ 04:30之間  正常班時段
                        else
                        {
                            if (string.Compare(ks_time, night_start_work_time) >= 0 && string.Compare(ks_time, day_end_time) <= 0
                                && string.Compare(js_time, ot_start_time) >= 0 && string.Compare(js_time, night_end_work_time) <= 0)
                            //開始時間在19:00 ~ 24:00;結束時間在04:00~08:30之間 正常班時段，有加班
                            {
                                str_end_time = next_day + " " + ot_start_time + secon_data;
                                ot_flag = true;
                                act_ot_start_time = next_day + " " + ot_start_time + secon_data;
                                act_ot_end_time = next_day + " " + js_time + secon_data;
                            }
                            else
                            {
                                if (string.Compare(ks_time, day_start_time) >= 0 && string.Compare(ks_time, ot_start_time) <= 0
                                && string.Compare(js_time, ot_start_time) >= 0 && string.Compare(js_time, night_end_work_time) <= 0)
                                //開始時間在00:00 ~ 04:30;結束時間在04:30~08:30之間 正常班時段，有加班
                                {
                                    str_start_time = next_day + " " + ks_time + secon_data;
                                    str_end_time = next_day + " " + ot_start_time + secon_data;
                                    ot_flag = true;
                                    act_ot_start_time = next_day + " " + ot_start_time + secon_data;
                                    act_ot_end_time = next_day + " " + js_time + secon_data;
                                }
                                else
                                {
                                    if (string.Compare(ks_time, ot_start_time) >= 0 && string.Compare(ks_time, night_end_work_time) <= 0
                                    && string.Compare(js_time, ot_start_time) >= 0 && string.Compare(js_time, night_end_work_time) <= 0)
                                    //開始、結束時間在04:30~08:30之間 沒有正常班，只有加班
                                    {
                                        str_start_time = next_day + " " + ks_time + secon_data;//將正常班開始、結束時間設定成一齊
                                        str_end_time = next_day + " " + ks_time + secon_data;
                                        ot_flag = true;
                                        act_ot_start_time = next_day + " " + ks_time + secon_data;
                                        act_ot_end_time = next_day + " " + js_time + secon_data;
                                    }
                                    else
                                    {
                                        str_end_time = current_day + " " + js_time + secon_data;
                                    }
                                }
                            }
                        }
                    }
                }
                ts = Convert.ToDateTime(str_end_time) - Convert.ToDateTime(str_start_time); //結束 - 開始 時間
                sj = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                normal_time = sj;
                if (ot_flag == true)
                {
                    ts = Convert.ToDateTime(act_ot_end_time) - Convert.ToDateTime(act_ot_start_time); //結束 - 開始 時間
                    ot_time = Convert.ToSingle(ts.TotalHours.ToString());//數值型的時間
                }
                //if (sj <= std_work_hour)
                //    normal_time = sj;
                //else
                //{
                //    normal_time = std_work_hour;
                //    ot_time = sj - std_work_hour;
                //}

            }
            if (normal_time != 0)
                txtNormal_work.Text = Math.Round(normal_time, 3).ToString();
            if (ot_time != 0)
                txtAdd_work.Text = Math.Round(ot_time, 3).ToString();
        }

        private void chkcont_wrok1_Click(object sender, EventArgs e)
        {
            count_req_time();//計算預計完成時間
            count_datetime();
        }

        private void chkcont_work2_Click(object sender, EventArgs e)
        {
            count_req_time();//計算預計完成時間
            count_datetime();
        }

        /// <summary>
        /// DataGridView 的單元格點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string item;
            if (dgvDetails.Rows.Count > 0)
            {
                edit_type = "N";//控件不作為編輯
                fill_exist_record(e.RowIndex);
                txtmo_id.Text = dtProductionRecordslist.Rows[e.RowIndex]["prd_mo"].ToString();
                item = dtProductionRecordslist.Rows[e.RowIndex]["prd_item"].ToString();
                cmbGoods_id.Items.Clear();
                cmbGoods_id.Items.Add(item);
                //GetMo_itme(item);
                cmbGoods_id.Text = item;//物料編號
                txtgoods_desc.Text = GetItemDesc(item);//獲取物料描述
                get_total_prd_qty();//顯示單的總完成數量
            }
        }
        //獲取物料描述
        private string GetItemDesc(string item)
        {
            string desc = "";
            DataTable dtitem = new DataTable();
            try
            {
                dtitem = clsProductionSchedule.GetItemDesc(item);
                if (dtitem.Rows.Count > 0)
                {
                    desc = dtitem.Rows[0]["name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return desc;
        }
        private void get_total_prd_qty()
        {
            DataTable db_show_qty = new DataTable();

            string sql = "";
            sql += " Select sum(prd_qty) as prd_qty From product_records a" +
                " Where a.prd_dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'" +
                " And a.prd_mo = " + "'" + txtmo_id.Text.ToString() + "'" +
                " And a.prd_item = " + "'" + cmbGoods_id.Text.ToString() + "'" +
                " And a.prd_work_type = '" + "A02" + "'" +
                " And a.prd_start_time <> '' " + " And a.prd_end_time <> '' ";
            db_show_qty = clsPublicOfPad.GetDataTable(sql);
            txtTotalQty.Text = db_show_qty.Rows[0]["prd_qty"].ToString();
        }
        //計算每KG對應數量
        private void count_kg_pcs()
        {
            txtprd_weg.Text = "";
            if (txtPrd_qty.Text != "" && txtkgPCS.Text != "" && Convert.ToInt32(txtkgPCS.Text) != 0)
                txtprd_weg.Text = Math.Round(Convert.ToSingle(txtPrd_qty.Text.ToString()) / Convert.ToSingle(txtkgPCS.Text.ToString()), 2).ToString();
        }

        //獲取物料的每公斤對應數量
        private int get_kg_pcs_rate()
        {
            DataTable dtItem_kg_pcs = null;
            int kg_pcs_rate = 0;
            try
            {
                //獲取制單編號資料
                string sql = " select dep,mat_item,rate,cr_date  from item_rate ";
                sql += " Where dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'";
                sql += " And mat_item = " + "'" + cmbGoods_id.Text.ToString() + "'";

                dtItem_kg_pcs = clsPublicOfPad.GetDataTable(sql);
                if (dtItem_kg_pcs.Rows.Count > 0)
                    kg_pcs_rate = Convert.ToInt32(dtItem_kg_pcs.Rows[0]["rate"].ToString());
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            return kg_pcs_rate;
        }
        private void fill_txt_kg_pcs()
        {
            if (txtkgPCS.Text == "" && cmbProductDept.Text != "" && cmbGoods_id.Text != "")
            {
                txtkgPCS.Text = get_kg_pcs_rate().ToString();
                txtkgPCS.Text = (txtkgPCS.Text.ToString() != "0" ? txtkgPCS.Text : "");
            }
        }
        private void txtProductNo_Leave(object sender, EventArgs e)
        {
            if (txtProductNo.Text.Trim() != "")
                txtProductNo.Text = txtProductNo.Text.PadLeft(10, '0');
        }

        private void count_hour_std_qty()
        {
            if (txtRow_qty.Text != "" && txtPer_Convert_qty.Text != "")
            {
                txtper_Standrad_qty.Text = (Convert.ToInt32(txtRow_qty.Text) * Convert.ToInt32(txtPer_Convert_qty.Text)).ToString();
                count_req_time();//預計完成時間
            }
        }

        private void btnCount_time_Click(object sender, EventArgs e)
        {
            double hour_num = 0;
            if (txtPrd_qty.Text != "" && txtper_Standrad_qty.Text != "" && dtpStart.Text != "00:00")
            {
                hour_num = Math.Round(Convert.ToSingle(txtPrd_qty.Text) / Convert.ToSingle(txtper_Standrad_qty.Text), 3);
                dtpEnd.Value = Convert.ToDateTime(mktProdcutDate.Text + " " + dtpStart.Text).AddHours(hour_num);
                count_datetime();
            }
        }
        private void count_req_time()
        {
            double hour_num = 0;
            string am_start_time = "08:30";
            string finish_work_noon1 = "12:30";//,finish_work_noon2="14:00";//中午下班時間 12:30~14:00
            string finish_work_afternoon1 = "18:00";//, finish_work_afternoon2 = "19:00";//下午下班時間 18:00~19:00
            string finish_work_time;
            string prd_date = (mktProdcutDate.Text.Replace(" ", "") == "//" ? System.DateTime.Now.ToString("yyyy/MM/dd") : mktProdcutDate.Text.ToString());
            dtpReqEnd.Text = "";
            if (txtPrd_qty.Text != "" && txtper_Standrad_qty.Text != "" && dtpStart.Text != "00:00")
            {
                hour_num = Math.Round(Convert.ToSingle(txtPrd_qty.Text) / Convert.ToSingle(txtper_Standrad_qty.Text), 3);
                finish_work_time = Convert.ToDateTime(prd_date + " " + dtpStart.Text).AddHours(hour_num).ToString("yyyy/MM/dd HH:mm".Substring(11, 5));
                //當開始時間是從08:30,完成時間是在12:30~18:00之間的
                if (string.Compare(dtpStart.Text, am_start_time) >= 0
                    && string.Compare(dtpStart.Text, finish_work_noon1) <= 0
                    && string.Compare(finish_work_time, finish_work_noon1) > 0)
                {
                    if (chkcont_work1.Checked == false)
                        hour_num = hour_num + 1.5;
                }

                finish_work_time = Convert.ToDateTime(prd_date + " " + dtpStart.Text).AddHours(hour_num).ToString("yyyy/MM/dd HH:mm".Substring(11, 5));
                if (string.Compare(finish_work_time, finish_work_afternoon1) > 0
                    && string.Compare(dtpStart.Text, finish_work_afternoon1) <= 0)
                {
                    if (chkcont_work2.Checked == false)
                        hour_num = hour_num + 1;
                }
                dtpReqEnd.Value = Convert.ToDateTime(prd_date + " " + dtpStart.Text).AddHours(hour_num);
            }
        }
        private void btnCount_qty_Click(object sender, EventArgs e)
        {
            txtPrd_qty.Text = "";
            txtprd_weg.Text = "";
            float normal_time, ot_time;
            int std_qty = (txtper_Standrad_qty.Text != "" ? Convert.ToInt32(txtper_Standrad_qty.Text) : 0);
            normal_time = (txtNormal_work.Text.ToString() != "" ? Convert.ToSingle(txtNormal_work.Text) : 0);
            ot_time = (txtAdd_work.Text.ToString() != "" ? Convert.ToSingle(txtAdd_work.Text) : 0);
            txtPrd_qty.Text = Convert.ToInt32(((normal_time + ot_time) * std_qty)).ToString();
            count_kg_pcs();//計算每KG對應數量
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    string strbarcode = txtBarCode.Text.Trim().ToUpper();
                    string goods_id="";
                    if (strbarcode.Length == 30 || strbarcode.Length == 13)
                    {
                        if (strbarcode.Length == 30)
                        {
                            txtToDep.Text = strbarcode.Substring(0, 3);
                            txtmo_id.Text = strbarcode.Substring(3, 9);
                            goods_id = strbarcode.Substring(12, 18);
                        }
                        else//如果是12位的條形碼，就要通過計劃查找出物料編號、部門等記錄
                        {
                            DataTable dtItem = clsPublicOfPad.BarCodeToItem(strbarcode);
                            if (dtItem.Rows.Count > 0)
                            {
                                txtToDep.Text = dtItem.Rows[0]["next_wp_id"].ToString().Trim();
                                txtmo_id.Text = strbarcode.Substring(0, 9);
                                goods_id = dtItem.Rows[0]["goods_id"].ToString().Trim();
                            }
                        }
                        GetMo_itme(goods_id);
                        cmbGoods_id.Text = goods_id;
                        get_data_details();
                        record_id = -1;
                        btnSave_Click(sender, e);
                    }
                    else if (strbarcode.Substring(0, 2).ToUpper() == "WK")  //掃描生產工號       
                    {
                        txtProductNo.Text = strbarcode.Substring(2, 5);
                        txtProductNo.Text = txtProductNo.Text.PadLeft(10, '0');
                    }
                    else if (strbarcode.Substring(0, 2).ToUpper() == "JQ") //掃描生產機器
                    {
                        txtMachine.Text = strbarcode.Substring(3, 7);
                        GetMachine_std();//獲取機器的各項標準數據
                        fill_textbox_machine_std();//填充機器各項標準
                    }
                    txtBarCode.Text = "";
                    break;
            }
        }


        private void txtgoods_desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtgoods_desc.Text = "";
        }

        private void txtmo_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtmo_id.Text = "";
        }

        private void cmbGoods_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbGoods_id.Text = "";
        }

        private void txtMachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMachine.Text = "";
        }

        private void txtRow_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRow_qty.Text = "";
        }

        private void txtPer_Convert_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPer_Convert_qty.Text = "";
        }

        private void txtper_Standrad_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtper_Standrad_qty.Text = "";
        }

        private void txtProductNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtProductNo.Text = "";
        }

        private void cmbWorkType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbWorkType.Text = "";
        }

        private void txtNormal_work_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNormal_work.Text = "";
        }

        private void txtAdd_work_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAdd_work.Text = "";
        }

        private void txtkgPCS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtkgPCS.Text = "";
        }

        private void txtPrd_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPrd_qty.Text = "";
        }

        private void txtprd_weg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtprd_weg.Text = "";
        }
        private void get_data_details()
        {
            ClearPartOfText(); //清空文本框內容
            fill_plan_value();//首先將計劃單帶出數量、描述
            get_prd_records(1);//查詢已錄入的記錄
            chk_prd_no_complete();//檢查是否有未完成的記錄，默認帶出來
            FillGrid();//將查詢到的記錄存入列表
            fill_txt_kg_pcs();//提取物料每公斤對應數量
            count_kg_pcs();//換算重量
            get_total_prd_qty();//獲取總完成數量
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPrd_qty.Text != "" && txtprd_weg.Text != "" && txtprd_weg.Text != "0")
                txtkgPCS.Text = Convert.ToInt32(Convert.ToSingle(txtPrd_qty.Text) / Convert.ToSingle(txtprd_weg.Text)).ToString();
        }

        private void BTNNOCOMP_Click(object sender, EventArgs e)
        {
            get_prd_records(2);//查詢已錄入的記錄
            FillGrid(); //將查詢到的記錄存入列表
        }

        private void BTNREFRESHMO_Click(object sender, EventArgs e)
        {
            get_prd_records(1);//查詢已錄入的記錄
            FillGrid(); //將查詢到的記錄存入列表
        }

        private void BTNNOSTART_Click(object sender, EventArgs e)
        {
            get_prd_records(4);//未開始的記錄
            FillGrid(); //將查詢到的記錄存入列表
        }

        private void BTNCOMP_Click(object sender, EventArgs e)
        {
            get_prd_records(5);//當天完成的記錄
            FillGrid(); //將查詢到的記錄存入列表
        }
        private void txtSearchMo_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchMo.Text != "")
            {
                if (this.chkIsComplete.Checked == false)
                    get_prd_records(6);//按制單編號查詢未完成的記錄
                else
                    get_prd_records(7);//按制單編號查詢包括已完成的記錄
                FillGrid(); //將查詢到的記錄存入列表
            }
        }
        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails_Leave(object sender, EventArgs e)
        {
            edit_type = "Y";//控件作為編輯
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
            {
                count_datetime();//計算生產時間
                count_alloy_std_hour_qty();
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
                count_datetime();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Delete;
            ToolStripButtonEvents();
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            OperationType = clsUtility.enumOperationType.Find;
            ToolStripButtonEvents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (valid_data())
            {
                objModel = new product_records();
                objModel.prd_dep = cmbProductDept.SelectedValue.ToString();
                objModel.prd_owndep = "";
                objModel.prd_date = (mktProdcutDate.Text.Replace(" ","") == "//" ? "" : mktProdcutDate.Text.ToString());
                objModel.prd_pdate = dtePrdPdate.Text.ToString();
                objModel.prd_mo = txtmo_id.Text.Trim();
                objModel.prd_item = cmbGoods_id.Text.ToString().Trim();
                objModel.prd_qty = (txtPrd_qty.Text != "" ? Convert.ToInt32(txtPrd_qty.Text) : 0);
                objModel.prd_weg = (txtprd_weg.Text != "" ? Convert.ToSingle(txtprd_weg.Text) : 0);
                objModel.prd_machine = txtMachine.Text.Trim();
                objModel.prd_work_type = cmbWorkType.SelectedValue.ToString();
                objModel.prd_worker = txtProductNo.Text.Trim();
                objModel.prd_class = cmbOrder_class.Text.Trim();
                objModel.prd_group = cmbGroup.Text.Trim();
                objModel.prd_start_time = (dtpStart.Text.Trim() != "00:00" ? dtpStart.Text.Trim() : "");
                objModel.prd_end_time = (dtpEnd.Text.Trim() != "00:00" ? dtpEnd.Text.Trim() : "");
                objModel.prd_req_time = (dtpReqEnd.Text.Trim() != "00:00" ? dtpReqEnd.Text.Trim() : "");
                objModel.prd_normal_time = (txtNormal_work.Text != "" ? Convert.ToSingle(txtNormal_work.Text) : 0);
                objModel.prd_ot_time = (txtAdd_work.Text != "" ? Convert.ToSingle(txtAdd_work.Text) : 0);
                objModel.line_num = (txtRow_qty.Text != "" ? Convert.ToInt32(txtRow_qty.Text) : 0);
                objModel.hour_run_num = (txtPer_Convert_qty.Text != "" ? Convert.ToInt32(txtPer_Convert_qty.Text) : 0);
                objModel.hour_std_qty = (txtper_Standrad_qty.Text != "" ? Convert.ToInt32(txtper_Standrad_qty.Text) : 0);
                objModel.kg_pcs = (txtkgPCS.Text != "" ? Convert.ToInt32(txtkgPCS.Text) : 0);
                objModel.mat_item = txtMatItem.Text.Trim();
                objModel.mat_item_lot = txtMatLot.Text.Trim();
                objModel.mat_item_desc = txtMatDesc.Text.Trim();
                objModel.to_dep = txtToDep.Text.Trim();
                objModel.crusr = _userid;
                objModel.crtim = DateTime.Now;
                objModel.amusr = _userid;
                objModel.amtim = DateTime.Now;
                objModel.prd_id = record_id;
                objModel.difficulty_level = txtDifficulty_level.Text.Trim();
                objModel.pack_num = (txtPack_num.Text != "" ? Convert.ToInt32(txtPack_num.Text) : 0);
                objModel.work_code = txtWork_code.Text;
                objModel.prd_run_qty = (txtPrd_Run_qty.Text != "" ? Convert.ToSingle(txtPrd_Run_qty.Text) : 0);
                objModel.speed_lever = (txtSpeed_lever.Text != "" ? Convert.ToInt32(txtSpeed_lever.Text) : 0);
                objModel.start_run = (txtStart_run.Text != "" ? Convert.ToInt32(txtStart_run.Text) : 0);
                objModel.end_run = (txtEnd_run.Text != "" ? Convert.ToInt32(txtEnd_run.Text) : 0);
                objModel.prd_id_ref = (txtPrd_id_ref.Text !="" ? Convert.ToInt32(txtPrd_id_ref.Text):0);
                objModel.work_class = "";
                objModel.actual_qty = 0;
                objModel.actual_weg = 0;
                try
                {
                    if (record_id == -1)
                    {
                        record_id= clsPublicOfPad.GenNo("frmProductionSchedule");//自動產生序列號
                        
                        if (record_id > 0)
                        {
                            objModel.prd_id = record_id;
                            if (txtPrd_id_ref.Text == "")//此單再續的，需要用回舊的記錄號
                            {
                                txtPrd_id_ref.Text = record_id.ToString();
                                objModel.prd_id_ref = record_id;
                            }
                            Result = clsProductionSchedule.AddProductionRecords(objModel);
                        }
                        else
                        {
                            MessageBox.Show("儲存記錄失敗!");
                            return;
                        }
                    }
                    else
                    {
                        Result = clsProductionSchedule.UpdateProductionRecords(objModel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                OperationType = clsUtility.enumOperationType.Save;
                ToolStripButtonEvents();
                txtBarCode.Focus();
            }
        }

        private void txtRow_qty_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
            {
                count_hour_std_qty();//計算標準數量
                if (cmbProductDept.Text == "302")
                    Cout_prd_qty_alloy();//計算實際生產數量(合金部)
            }
        }

        private void txtPer_Convert_qty_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
                count_hour_std_qty();
        }

        private void txtkgPCS_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
                count_kg_pcs();
        }

        private void txtper_Standrad_qty_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y" && cmbProductDept.Text != "302")
            {
                count_req_time();//預計完成時間
            }
        }

        private void txtPrd_qty_Leave(object sender, EventArgs e)
        {
        }
        private void Cout_prd_qty_alloy()
        {
            if (txtRow_qty.Text != "" && txtPrd_Run_qty.Text != "")
            {
                txtPrd_qty.Text = (Convert.ToInt32(txtRow_qty.Text) * Convert.ToInt32(txtPrd_Run_qty.Text)).ToString();
            }
        }

        private void txtPrd_Run_qty_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")//合金部 生產數 = 每碑數 * 實際碑數
                Cout_prd_qty_alloy();
        }

        private void cmbProductDept_Leave(object sender, EventArgs e)
        {
            InitComBoxGroup();//初始化組別
        }

        private void txtStart_run_TextChanged(object sender, EventArgs e)
        {
            count_run_qty();//計算實際碑數  合金部使用
        }
        private void count_run_qty()//計算實際碑數  合金部使用
        {
            if (edit_type == "Y" && cmbProductDept.Text == "302")//當是在編輯狀態且302部門時
            {
                txtPrd_Run_qty.Text = "";
                if (txtEnd_run.Text != "")
                    txtPrd_Run_qty.Text = (Convert.ToInt32(txtEnd_run.Text) - Convert.ToInt32((txtStart_run.Text != "" ? txtStart_run.Text : "0"))).ToString();
            }
        }

        private void txtEnd_run_TextChanged(object sender, EventArgs e)
        {
            count_run_qty();//計算實際碑數  合金部使用
        }
        //此單再續時，將上一次結束的碑數，當做為今次的開始數
        private void get_last_run_qty()
        {
            DataTable db_last_run_qty = new DataTable();
            string sql = "";
            sql += " Select end_run From product_records a" +
                " Where a.prd_dep = " + "'" + cmbProductDept.SelectedValue.ToString() + "'" +
                " And a.prd_mo = " + "'" + txtmo_id.Text.ToString() + "'" +
                " And a.prd_item = " + "'" + cmbGoods_id.Text.ToString() + "'" +
                " And a.prd_work_type = '" + "A02" + "'" +
                " And a.prd_start_time <> '' " + " And a.prd_end_time <> '' " +
                " Order by prd_date Desc,prd_end_time Desc";
            db_last_run_qty = clsPublicOfPad.GetDataTable(sql);
            if (db_last_run_qty.Rows.Count > 0)
                txtStart_run.Text = db_last_run_qty.Rows[0]["end_run"].ToString();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (record_id == -1)
            {
                MessageBox.Show("原單記錄不存在!");
                return;
            }
            txtPrd_id_ref.Text = record_id.ToString();
            record_id = -1;//重新設定為新單狀態
            txtPrd_qty.Text = "";
            txtprd_weg.Text = "";
            dtpStart.Text = "00:00";
            dtpEnd.Text = "00:00";
            dtpReqEnd.Text = "00:00";
            txtNormal_work.Text = "";
            txtAdd_work.Text = "";
            txtStart_run.Text = "";
            txtEnd_run.Text = "";
            txtTotalQty.Text = "";
            setProdDate();//自動設定生產日期為當前日期
            get_last_run_qty();//獲取最後一次的碑數
            get_total_prd_qty();//顯示單的總完成數量
            if (cmbProductDept.Text == "302")//302部門的，要將標準時能清空
                txtper_Standrad_qty.Text = "";
        }

        private void dtpEnd_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtpEnd.Text == "00:00" && dtpStart.Text != "00:00")
                dtpEnd.Value = System.DateTime.Now;
        }

        private void txtMachine_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtMachine.Text == "")
            {
                if (_userid == "BUT01")
                    txtMachine.Text = "NBY-";
                else
                {
                    if (_userid == "BUT02")
                        txtMachine.Text = "NDG-";
                    else
                    {
                        if (_userid == "ALY01")
                            txtMachine.Text = "ABY-";
                    }
                }
                if (cmbProductDept.Text == "104")
                    txtMachine.Text = "NCG-";
            }
        }

        private void dtpStart_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtpStart.Text == "00:00")
                dtpStart.Value = System.DateTime.Now;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":  //記錄編輯
                    {
                        //get_prd_records(8);//查詢已錄入的記錄
                        //FillGrid(); //將查詢到的記錄存入列表
                        break;
                    }
                case "tabPage2":  //記錄查詢
                    {
                        //get_prd_records(8);//查詢已錄入的記錄
                        //FillGrid(); //將查詢到的記錄存入列表
                        break;
                    }
                case "tabPage3":  //並單
                    {
                        if (record_id < 0)
                        {
                            ClearText();
                        }
                        else
                        {
                            BinddgvAndSingle(txtPrd_id_ref.Text);
                        }
                    }
                    break;
                default:
                    break;
            }
        }


        #region 並單(tabPage3)

        /// <summary>
        /// 源數據
        /// </summary>
        private List<product_records_dist_mo> lsTotalModel = new List<product_records_dist_mo>();

        /// <summary>
        /// 新增數據
        /// </summary>
        private List<product_records_dist_mo> lsNewModel = new List<product_records_dist_mo>();

        /// <summary>
        /// 掃描條碼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //掃描制單編號，物料編號
                        string strbarcode = txtBarcode2.Text.Trim().ToUpper();
                        if (strbarcode.Length >= 30)
                        {
                            txtPrd_mo_sub.Text = strbarcode.Substring(3, 9);
                            GetMo_itemForAndSingle(txtPrd_mo_sub.Text.Trim(), cmbProductDept.SelectedValue.ToString(), strbarcode.Substring(12, 18));
                            cmbmat_id.Text = strbarcode.Substring(12, 18);
                            btnSaveOrder_Click(sender,e);//儲存並單
                        }
                        txtBarcode2.Text = "";
                    }
                    break;
                default:
                    break;
            }
        }

        private void txtPrd_mo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPrd_mo_sub.Text = "";
        }

        private void txtPrd_mo_Leave(object sender, EventArgs e)
        {
            cmbmat_id.Text = "";
            txtmat_desc.Text = "";
            txtQuantity.Text = "";
            if (txtPrd_mo_sub.Text != "" && cmbProductDept.Text != "")
            {
                GetMo_itemForAndSingle(txtPrd_mo_sub.Text.Trim(), cmbProductDept.SelectedValue.ToString(), "");
            }
        }

        private void GetMo_itemForAndSingle(string prd_mo, string prd_dept, string prd_item)
        {
            cmbmat_id.Items.Clear();
            string fdep = prd_dept;
            string tdep = "";
            try
            {
                dtMo_item = clsProductionSchedule.GetMo_dataById(prd_mo, fdep,tdep, prd_item);
                if (dtMo_item.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMo_item.Rows.Count; i++)
                    {
                        cmbmat_id.Items.Add(dtMo_item.Rows[i]["goods_id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbmat_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbmat_id.Text = "";
        }

        private void cmbmat_id_TextChanged(object sender, EventArgs e)
        {
            if (dtMo_item.Rows.Count > 0)
            {
                DataRow[] dr = dtMo_item.Select("goods_id='" + cmbmat_id.Text.ToString() + "'");
                if (dr.Length > 0)
                {
                    txtmat_desc.Text = dr[0]["name"].ToString();
                    txtQuantity.Text = clsUtility.FormatNullableInt32(dr[0]["prod_qty"]).ToString();
                }
            }
        }
        /// <summary>
        /// 保存綁定並單數據
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (ValidateTextInput() == false)
                return;
            int upd_result = 0;
            int prd_id,prd_id_ref;
            string prd_mo_sub,prd_item_sub;
            int prd_qty;
            prd_id = Convert.ToInt32(txtPrd_id1.Text);
            prd_id_ref = Convert.ToInt32(txtPrd_id_ref1.Text);
            prd_mo_sub = txtPrd_mo_sub.Text;
            prd_item_sub = cmbmat_id.Text;
            prd_qty = Convert.ToInt32(txtQuantity.Text);
            string strSQL = "Select prd_id_ref from product_records_dist_mo Where prd_id_ref =" + "'" + prd_id_ref + "'" + " and prd_mo_sub=" + "'" + txtPrd_mo_sub.Text + "'";
            DataTable dtChkDistMo = clsPublicOfPad.GetDataTable(strSQL);
            if (dtChkDistMo.Rows.Count == 0)
            {
                upd_result = clsProductionSchedule.AddDistMo(prd_id_ref, prd_mo_sub, prd_item_sub, prd_qty, _userid, System.DateTime.Now);
                if (upd_result > 0)
                    upd_result = clsProductionSchedule.SumPrdQty(prd_id, prd_qty, _userid, System.DateTime.Now);
                if (upd_result > 0)
                {
                    MessageBox.Show("保存並單成功!");
                    BinddgvAndSingle(prd_id_ref.ToString());
                }
                else
                    MessageBox.Show("保存並單失敗!");
            }
            else
            {
                MessageBox.Show("已存在並單的記錄,不能再並單!");
            }
            
        }

        private void dgvAndSingle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            FillDistMo(e.RowIndex);
            record_id = (int)dgvAndSingle.Rows[e.RowIndex].Cells["colSer_qo"].Value;
            get_prd_records(9);//按制單編號查詢未完成的記錄
            FillGrid();
            dgvDetails_CellClick(sender, e);
            
        }
        private void FillDistMo(int i)
        {
            string prd_item_sub = dgvAndSingle.Rows[i].Cells["colPrd_item_sub"].Value.ToString();
            txtPrd_id1.Text = dgvAndSingle.Rows[i].Cells["colSer_qo"].Value.ToString();
            record_id = Convert.ToInt32(txtPrd_id1.Text);
            txtPrd_id_ref.Text = dgvAndSingle.Rows[i].Cells["colPrd_id_ref"].Value.ToString();
            txtPrd_id_ref1.Text = txtPrd_id_ref.Text;
            txtPrd_mo_sub.Text = dgvAndSingle.Rows[i].Cells["colPrd_mo_sub"].Value.ToString();
            cmbmat_id.Items.Clear();
            cmbmat_id.Items.Add(prd_item_sub);
            cmbmat_id.Text = prd_item_sub;
            txtQuantity.Text = clsUtility.FormatNullableString(dgvAndSingle.Rows[i].Cells["colPrd_qty_sub"].Value);
            txtmat_desc.Text = GetItemDesc(prd_item_sub);//獲取物料描述
        }
        /// <summary>
        /// 綁定並單數據
        /// </summary>
        /// <param name="prd_id"></param>
        /// <param name="prd_mo"></param>
        private void BinddgvAndSingle(string prd_id_ref)
        {
            dgvAndSingle.DataSource = chkDistMo(4, prd_id_ref, "");
            if (dgvAndSingle.Rows.Count > 0)
                FillDistMo(0);
        }

        /// <summary>
        /// 驗證輸入值是否正確
        /// </summary>
        /// <returns></returns>
        private bool ValidateTextInput()
        {
            if (txtPrd_id1.Text == "")
            {
                MessageBox.Show("主記錄號為空,不能做分單!");
                return false;
            }
            if (txtPrd_id_ref1.Text == "")
            {
                MessageBox.Show("分記錄號為空,不能做分單!");
                return false;
            }
            if (txtPrd_mo_sub.Text == "")
            {
                MessageBox.Show("制單編號不能為空!");
                return false;
            }
            if (cmbmat_id.Text == "")
            {
                MessageBox.Show("物料編號不能為空!");
                return false;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("數量不能為空!");
                return false;
            }
            if (cmbGoods_id.Text.Trim() != cmbmat_id.Text.Trim())
            {
                MessageBox.Show("記錄編輯頁面的物料編號與並單的物料編號不同。");
                cmbmat_id.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 清空文本值
        /// </summary>
        private void ClearText()
        {
            lsTotalModel.Clear();
            lsNewModel.Clear();
            txtPrd_mo_sub.Text = "";
            cmbmat_id.Items.Clear();
            txtQuantity.Text = "";
            txtmat_desc.Text = "";
        }

        #endregion

        private void btnMo_search_Click(object sender, EventArgs e)
        {
            dgvAndSingle.DataSource = chkDistMo(3, txtMo_search.Text, "");

        }

        private void btnDelDistMo_Click(object sender, EventArgs e)
        {
            if (ValidateTextInput() == false)
                return;
            int upd_result = 0;
            int prd_id, prd_id_ref;
            int prd_qty;
            prd_id = Convert.ToInt32(txtPrd_id1.Text);
            prd_id_ref = Convert.ToInt32(txtPrd_id_ref1.Text);
            prd_qty = 0 - Convert.ToInt32(txtQuantity.Text);
            string strSQL = "Select prd_id_ref from product_records_dist_mo Where prd_id_ref =" + "'" + prd_id_ref + "'" + " and prd_mo_sub=" + "'" + txtPrd_mo_sub.Text + "'";
            DataTable dtChkDistMo = clsPublicOfPad.GetDataTable(strSQL);
            if (dtChkDistMo.Rows.Count > 0)
            {
                upd_result = clsProductionSchedule.DelDistMo(prd_id_ref);
                if (upd_result > 0)
                    upd_result = clsProductionSchedule.SumPrdQty(prd_id, prd_qty, _userid, System.DateTime.Now);
                if (upd_result > 0)
                {
                    MessageBox.Show("刪除記錄成功!");
                    BinddgvAndSingle(prd_id_ref.ToString());
                }
                else
                    MessageBox.Show("刪除記錄失敗!");
            }
            else
            {
                MessageBox.Show("沒有要刪除的記錄!");
            }
        }

        private void rdbSearch1_Click(object sender, EventArgs e)
        {
            btnMo_search_Click(sender, e);
        }

        private void rdbSearch2_Click(object sender, EventArgs e)
        {
            btnMo_search_Click(sender, e);
        }

        private void cmbProductDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductDept.Text == "105")
                cmbWorkType.Text = "生產";
        }

        private void txtMatItem_Leave(object sender, EventArgs e)
        {
            GetMat_Desc();
        }
        private void GetMat_Desc()
        {

            txtMatDesc.Text = "";
            string strSql = "";
            DataTable dtMatDesc = new DataTable();
            strSql = " SELECT name FROM " + DBUtility.remote_db + "it_goods " +
                           " WHERE within_code='" + "0000" + "' AND id ='" + txtMatItem.Text.Trim() + "' ";
            try
            {
                dtMatDesc = clsPublicOfPad.GetDataTable(strSql);
                if (dtMatDesc.Rows.Count > 0)
                    txtMatDesc.Text = dtMatDesc.Rows[0]["name"].ToString().Trim();
                else
                    MessageBox.Show("物料編號不存在!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbOrder_class_Leave(object sender, EventArgs e)
        {
            setProdDate();//自動設定生產日期為當前日期
        }

        private void txtPrd_qty_TextChanged(object sender, EventArgs e)
        {
            if (edit_type == "Y")
            {
                //count_kg_pcs();  ////計算每KG對應數量
                count_prd_weg();//計算出生產重量
            }
        }
        //由生產數量計算出生產重量
        private void count_prd_weg()
        {
            txtprd_weg.Text = "";
            if (txtPrd_qty.Text != "" && txtkgPCS.Text != "")
                txtprd_weg.Text = Math.Round((Convert.ToSingle(txtPrd_qty.Text) / Convert.ToSingle(txtkgPCS.Text)), 2).ToString();
        }

        private void count_alloy_std_hour_qty()//計算合金部的每小時標準碑數
        {
            if (cmbProductDept.Text == "302" && (txtNormal_work.Text != "" || txtAdd_work.Text != ""))
            {
                float normal_work, add_work, Prd_Run_qty;
                normal_work = (txtNormal_work.Text != "" ? Convert.ToSingle(txtNormal_work.Text) : 0);
                add_work = (txtAdd_work.Text != "" ? Convert.ToSingle(txtAdd_work.Text) : 0);
                Prd_Run_qty = (txtPrd_Run_qty.Text != "" ? Convert.ToSingle(txtPrd_Run_qty.Text) : 0);
                if (normal_work + add_work != 0)
                    txtper_Standrad_qty.Text = Math.Round(Prd_Run_qty / (normal_work + add_work), 0).ToString();
            }
        }

        private void dtpStart_Leave(object sender, EventArgs e)
        {
            count_req_time();//預計完成時間
        }

        private void txtPrd_qty_Leave_1(object sender, EventArgs e)
        {
            count_req_time();//預計完成時間
        }
    }
}
