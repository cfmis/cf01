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

namespace cf01.Forms
{
    public partial class frmProductionArrange : Form
    {
        private DataTable dtMo_item = new DataTable();
        private DataTable dtPA = new DataTable();
        private DataTable dtPrd_dept = new DataTable();
        private DataTable dtMachine_std = new DataTable();
        private DataTable dtSortFields = new DataTable();
        private DataTable dtSortFrom = new DataTable();
        private DataTable dtSortTo = new DataTable();
        private clsUtility.enumOperationType OperationType;

        private string strArrange_id = "";
        private string _userid = DBUtility._user_id;
        private string strSort="";
        private int insert_mode = 1;//更新模式:0-修改;1-插入;2-取消;3-刪除
        private string find_mode = "Y";//查找狀態
        public static string sent_arrange_id = "";
        public static string sent_prd_dep = "";
        public frmProductionArrange()
        {
            InitializeComponent();
        }

        private void frmProductionArrange_Load(object sender, EventArgs e)
        {
            txtNow_date.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            mktFindDate.Text = txtNow_date.Text;
            OperationType = clsUtility.enumOperationType.Load;
            //ControlState();

            //tabControl1.SelectedTab = tabPage2;
            dgvPA.AutoGenerateColumns = false;
            //dgvImputExcel.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;//所有表頭的顏色
            //dgvImputExcel.Columns[0].DefaultCellStyle.ForeColor = Color.Red;//設置欄的顏色
            //dgvImputExcel.Columns[0].DefaultHeaderCellType= "TEST";
            dgvImputExcel.EnableHeadersVisualStyles = false;
            //dgvImputExcel.Columns[0].HeaderCell.Style.BackColor = Color.Blue;
            dgvImputExcel.Columns[0].HeaderCell.Style.ForeColor = Color.Blue;
            dgvImputExcel.Columns[1].HeaderCell.Style.ForeColor = Color.Blue;
            dgvImputExcel.Columns[2].HeaderCell.Style.ForeColor = Color.Blue;
            dgvImputExcel.Columns[3].HeaderCell.Style.ForeColor = Color.Blue;
            dgvImputExcel.Columns[4].HeaderCell.Style.ForeColor = Color.Blue;
            dgvImputExcel.AutoGenerateColumns = false;
            masktxtPrd_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            InitControlers();
            BindSortFields();
            SetUserControlEnabled();
            strSort = "";//清空排序條件
        }
        //設置用戶權限可用
        private void SetUserControlEnabled()
        {
            DataTable dtUserRole = clsGetAuthority.GetUserRole();
            if (dtUserRole.Rows.Count == 0 || dtUserRole.Rows[0]["Rid"].ToString().Trim() == "11")
            {
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnDel.Enabled = false;
                btnImputExcel.Enabled = false;
                btnSaveExcel.Enabled = false;
                btnEdit.Enabled = false;
                tabControl1.SelectedTab = tabDetail;
                tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.ItemSize = new Size(0, 1);
            }
        }
        private void BindSortFields()
        {

            string fields_code = "";
            string alias = "";
            dtSortFrom.Columns.Add("sort_fields", typeof(string));
            dtSortFrom.Columns.Add("sort_select_code", typeof(string));
            dtSortFrom.Columns.Add("sort_s", typeof(string));
            DataRow dr = null;
            for (int i = 0; i < dgvPA.ColumnCount; i++)
            {
                dr = dtSortFrom.NewRow();
                dr["sort_fields"] = dgvPA.Columns[i].HeaderText.ToString().Trim();
                fields_code=dgvPA.Columns[i].DataPropertyName.ToString().Trim();
                if (fields_code != "")
                {
                    if (fields_code == "prd_start_time" || fields_code == "prd_end_time" || fields_code == "prd_req_time" || fields_code == "prd_qty")
                        alias = "b.";
                    else
                        if (fields_code == "goods_name")
                            alias = "c.";
                        else
                            if (fields_code == "art_image")
                                alias = "d.";
                            else
                                if (fields_code == "urgent_desc")
                                    alias = "e.";
                                else
                                    alias = "a.";
                    dr["sort_select_code"] = alias + fields_code;
                }
                dr["sort_s"] = "升序";
                dtSortFrom.Rows.Add(dr);
            }
            dgvSortFrom.DataSource = dtSortFrom;
            dtSortTo=dtSortFrom.Copy();
            dtSortTo.Rows.Clear();
            dgvSortTo.DataSource = dtSortTo;
            addSortTo(4);//默認加入按急單排序
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            timFind.Enabled = false;
            this.Close();
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtmo_id.Text == "")
            {
                MessageBox.Show("制單編號不能為空，請輸入制單編號。");
                txtmo_id.Focus();
                return;
            }
            if (cmbGoods_id.Text == "")
            {
                MessageBox.Show("產品編號不能為空，請輸入制單編號。");
                cmbGoods_id.Focus();
                return;
            }
            //if (txtMachine.Text == "")
            //{
            //    MessageBox.Show("機器不能為空，請輸入機器。");
            //    txtMachine.Focus();
            //    return;
            //}

            product_arrange objModel = new product_arrange();
            insert_mode = 0;
            objModel.prd_dep = cmbProductDept.SelectedValue.ToString();
            objModel.prd_mo = txtmo_id.Text.Trim();
            objModel.prd_item = cmbGoods_id.Text.ToString();
            objModel.prd_seq = txtPrd_seq.Text.Trim();
            objModel.prd_ver = (txtPrd_ver.Text != "" ? Convert.ToInt32(txtPrd_ver.Text) : 0);
            objModel.to_dep = txtToDep.Text.Trim();
            objModel.arrange_id = (strArrange_id != "" ? Convert.ToInt32(strArrange_id) : 0);
            objModel.arrange_date = masktxtPrd_date.Text;
            objModel.arrange_machine = (cmbMachine.SelectedValue!=null?cmbMachine.SelectedValue.ToString():"");
            objModel.arrange_qty = (txtPrd_qty.Text != "" ? Convert.ToInt32(txtPrd_qty.Text) : 0);
            objModel.rec_status = "0";
            objModel.prd_worker = txtProductNo.Text;
            objModel.mo_urgent = (cmbMoUrgent.SelectedValue != null ? cmbMoUrgent.SelectedValue.ToString() : "00");
            objModel.prd_status = (cmbPrd_status.SelectedValue != null ? cmbPrd_status.SelectedValue.ToString() : "00");
            objModel.cust_o_date = txtCust_o_date.Text.Trim();
            objModel.req_f_date = txtReq_f_date.Text.Trim();
            //如果單號ID為空，則說明是新增的，要重新獲取單號
            if (strArrange_id == "")
            {
                objModel.arrange_id = clsProductionSchedule.GetMaxArrange_id() + 1;
                strArrange_id = objModel.arrange_id.ToString();
                txtArrange_id.Text = strArrange_id;
                insert_mode = 1;
            }
            if (txtArrange_seq.Text == "")
            {
                int MaxArrange_seq = clsProductionSchedule.GetMaxArrange_seq(cmbProductDept.SelectedValue.ToString(), cmbMachine.SelectedValue.ToString());
                objModel.arrange_seq = MaxArrange_seq + 1;
            }
            else
            {
                objModel.arrange_seq = Convert.ToInt32(txtArrange_seq.Text);
            }
            objModel.estimated_date = msktxtEstimate_date.Text;
            objModel.estimated_time = (msktxtEstimate_time.Text != "00:00" ? msktxtEstimate_time.Text : "");
            objModel.estimated_start_date = msktxtEstimate_start_date.Text;
            objModel.estimated_start_time = (msktxtEstimate_start_time.Text != "00:00" ? msktxtEstimate_start_time.Text : "");
            objModel.req_time = (txtRequest_time.Text != "" ? Convert.ToSingle(txtRequest_time.Text) : 0);
            objModel.crusr = _userid;
            int Result = clsProductionSchedule.AddOrUpdatePrdocutionArrange(objModel, insert_mode);

            if (Result > 0)
            {
                //if (OperationType == clsUtility.enumOperationType.Update)
                //{
                //    GetPrdocutArrange(cmbProductDept.Text, txtmo_id.Text.Trim(), txtMachine.Text.Trim());
                //    SelectionIndex(objModel.arrange_id.ToString());

                //    tabControl1.SelectedTab = tabPage2;
                //}

                //OperationType = clsUtility.enumOperationType.Save;
                //ControlState();


                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失敗！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            if (strArrange_id == "")
            {
                MessageBox.Show("沒有要取消的排程!");
                return;
            }
            insert_mode = 2;//取消排程
            product_arrange objModel = new product_arrange();
            objModel.arrange_id = Convert.ToInt32(strArrange_id);
            objModel.rec_status = "1";
            int Result = clsProductionSchedule.AddOrUpdatePrdocutionArrange(objModel, insert_mode);

            if (Result > 0)
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失敗！");
            }
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

        private void cmbGoods_id_TextChanged(object sender, EventArgs e)
        {
            if (find_mode == "Y")
            {
                ClearPartOfText();

                DataTable dtPA = clsProductionSchedule.GetProductArrange("", cmbProductDept.SelectedValue.ToString(), txtmo_id.Text, cmbGoods_id.Text, "", 2, 2, 0);
                if (dtPA.Rows.Count > 0)
                {
                    cmbGoods_id.Text = dtPA.Rows[0]["prd_item"].ToString();
                    txtToDep.Text = dtPA.Rows[0]["to_dep"].ToString();
                    txtPrd_seq.Text = dtPA.Rows[0]["prd_seq"].ToString();
                    txtPrd_ver.Text = dtPA.Rows[0]["prd_ver"].ToString();
                    cmbMachine.SelectedValue  = dtPA.Rows[0]["arrange_machine"].ToString();
                    txtPrd_qty.Text = dtPA.Rows[0]["arrange_qty"].ToString();
                    masktxtPrd_date.Text = dtPA.Rows[0]["arrange_date"].ToString();
                    txtArrange_seq.Text = dtPA.Rows[0]["arrange_seq"].ToString();
                    msktxtEstimate_date.Text = dtPA.Rows[0]["estimated_date"].ToString();
                    msktxtEstimate_time.Text = dtPA.Rows[0]["estimated_time"].ToString();

                    txtRequest_time.Text = dtPA.Rows[0]["req_time"].ToString();
                    strArrange_id = dtPA.Rows[0]["arrange_id"].ToString();
                    txtArrange_id.Text = strArrange_id;
                    //MessageBox.Show("該條數據已存在，請重新輸入單據。");
                }
                else
                {
                    fill_plan_value();
                }
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //掃描制單編號，物料編號
                    string strbarcode = txtBarCode.Text.Trim().ToUpper();
                    string goods_id = "";
                    if (strbarcode.Length == 30 || strbarcode.Length == 13)
                    {
                        if (strbarcode.Length == 30)
                        {
                            txtToDep.Text = strbarcode.Substring(0, 3);
                            txtmo_id.Text = strbarcode.Substring(3, 9);
                            goods_id = strbarcode.Substring(12, 18);
                        }
                        else  //如果是12位的條形碼，就要通過計劃查找出物料編號、部門等記錄
                        {
                            DataTable dtItem = clsPublicOfPad.BarCodeToItem(strbarcode);
                            if (dtItem.Rows.Count > 0)
                            {
                                txtToDep.Text = dtItem.Rows[0]["next_wp_id"].ToString().Trim();
                                txtmo_id.Text = strbarcode.Substring(0, 9);
                                goods_id = dtItem.Rows[0]["goods_id"].ToString().Trim();
                            }
                        }

                        //getArrangeData(string prd_dep, string mo_id, string machine, string now_date, string worker, int is_machine, string prd_status, int rec_status, int cpl_status)
                        DataTable dtArrange = getArrangeData(cmbProductDept.SelectedValue.ToString(), txtmo_id.Text,goods_id, "", txtNow_date.Text, "", 2, "", 2, 2);

                        if (dtArrange.Rows.Count > 0)
                        {
                            dgvPA.DataSource = dtArrange;
                            FillTextBox(0);
                            if (chkSetWorker.Checked == true)
                            {
                                showWorker();
                            }
                        }
                        else
                        {
                            GetMo_itme(goods_id);
                            cmbGoods_id.Text = goods_id;
                        }
                    }

                    txtBarCode.Text = "";
                    break;
            }
        }

        private void showWorker()
        {
            sent_arrange_id = txtArrange_id.Text;
            sent_prd_dep = cmbProductDept.SelectedValue.ToString();
            frmProductionArrangeWorker frmPrdWorker = new frmProductionArrangeWorker();
            frmPrdWorker.ShowDialog();
            frmPrdWorker.Dispose();
        }


        //排序記錄
        private void initSortRec()
        {
            if (dgvPA.Rows.Count == 0)
                return;
            int j = 1;
            string machine_id = "";
            machine_id = dgvPA.Rows[0].Cells["colArrange_machine"].Value.ToString().Trim();
            dgvPA.Rows[0].Cells["colArrange_seq"].Value = j.ToString();
            for (int i = 1; i < dgvPA.Rows.Count; i++)
            {
                
                if (machine_id==dgvPA.Rows[i].Cells["colArrange_machine"].Value.ToString().Trim())
                {
                    j++;
                }
                else
                {
                    j = 1;
                    machine_id = dgvPA.Rows[i].Cells["colArrange_machine"].Value.ToString().Trim();
                }
                dgvPA.Rows[i].Cells["colArrange_seq"].Value = j.ToString();
            }
        }

        /// <summary>
        /// 改變生產順序優先級
        /// </summary>
        /// <param name="UpOrDown"></param>
        private void ChangeProductionPriority(string UpOrDown)
        {
            string strPa_id = dgvPA.CurrentRow.Cells["colId"].Value.ToString();
            for (int i = 0; i < dtPA.Rows.Count; i++)
            {
                if (strPa_id == dtPA.Rows[i]["arrange_id"].ToString())
                {
                    if (UpOrDown == "Up")
                    {
                        if (dgvPA.CurrentRow.Index == 0)
                        {
                            strPa_id = "";
                            break;
                        }

                        dtPA.Rows[i]["arrange_seq"] = Convert.ToInt32(dtPA.Rows[i]["arrange_seq"]) - 1;
                        dtPA.Rows[i - 1]["arrange_seq"] = Convert.ToInt32(dtPA.Rows[i - 1]["arrange_seq"]) + 1;
                    }

                    if (UpOrDown == "Down")
                    {
                        if (dgvPA.CurrentRow.Index == dgvPA.Rows.Count - 1)
                        {
                            strPa_id = "";
                            break;
                        }

                        dtPA.Rows[i]["arrange_seq"] = Convert.ToInt32(dtPA.Rows[i]["arrange_seq"]) + 1;
                        dtPA.Rows[i + 1]["arrange_seq"] = Convert.ToInt32(dtPA.Rows[i + 1]["arrange_seq"]) - 1;
                    }

                    DataTable dtCopy = dtPA.Copy();
                    DataView dv = dtCopy.DefaultView;
                    dv.Sort = "arrange_seq";
                    dtPA = dv.ToTable();

                    dgvPA.DataSource = dtPA;
                    dgvPA.Rows[0].Selected = false;
                    break;
                }
            }

            SelectionIndex(strPa_id);

            Analyze();
        }

        private void txtToDep_TextChanged(object sender, EventArgs e)
        {
            DataRow[] dr = dtPrd_dept.Select("int9loc='" + txtToDep.Text + "'");

            if (dr.Length > 0)
            {
                txtToDept_name.Text = dr[0]["int9desc"].ToString();
            }
        }

        private void InitControlers()
        {
            dtPrd_dept = clsProductionSchedule.GetAllPrd_dept();
            cmbProductDept.DataSource = dtPrd_dept;
            cmbProductDept.DisplayMember = "int9loc";
            cmbProductDept.ValueMember = "int9loc";

            cmbFindDep.DataSource = dtPrd_dept;
            cmbFindDep.DisplayMember = "int9loc";
            cmbFindDep.ValueMember = "int9loc";

            //提取急單類型
            DataTable dtUrgentGrade = clsProductionSchedule.GetUrgentGrade();
            cmbMoUrgent.DataSource = dtUrgentGrade;
            cmbMoUrgent.DisplayMember = "flag_desc";
            cmbMoUrgent.ValueMember = "flag_id";
            cmbMoUrgent.SelectedIndex = 0;

            //提取生產狀態
            DataTable dtPrdStatus = clsProductionSchedule.GetPrdStatus();
            cmbPrd_status.DataSource = dtPrdStatus;
            cmbPrd_status.DisplayMember = "flag_desc";
            cmbPrd_status.ValueMember = "flag_id";
            cmbPrd_status.SelectedIndex = 0;

            //提取生產狀態(查找用)
            DataTable dtFindStatus = clsProductionSchedule.GetPrdStatus();
            cmbFindStatus.DataSource = dtFindStatus;
            cmbFindStatus.DisplayMember = "flag_desc";
            cmbFindStatus.ValueMember = "flag_id";
            cmbFindStatus.SelectedIndex = 0;

            //獲取部門機器
            BindMachineCombox();
        }
        //獲取部門機器
        private void BindMachineCombox()
        {
            string dep = cmbProductDept.SelectedValue.ToString();
            DataTable dtMachine = clsProductionSchedule.GetMachine(dep);
            
            cmbMachine.DataSource = dtMachine;
            cmbMachine.DisplayMember = "machine_desc";
            cmbMachine.ValueMember = "machine_id";
        }
        //獲取部門機器--查找
        private void BindMachineComboxFind()
        {
            string dep = cmbFindDep.SelectedValue.ToString();
            DataTable dtMachine = clsProductionSchedule.GetMachine(dep);

            cmbFindMachine.DataSource = dtMachine;
            cmbFindMachine.DisplayMember = "machine_desc";
            cmbFindMachine.ValueMember = "machine_id";
        }
        private void GetPrdocutArrange()
        {
            int is_machine = 0;
            int rec_status = 0;
            if (chkIsCancel.Checked == true)
                rec_status = 1;
            string prd_dep = cmbFindDep.SelectedValue.ToString();
            string mo_id = txtMo_id_sq.Text.Trim();
            string machine = "";
            if (cmbFindMachine.Text != "")
                machine = cmbFindMachine.SelectedValue.ToString();
            string now_date = Convert.ToDateTime(mktFindDate.Text).ToString("yyyy/MM/dd");
            string worker = txtFindWorker.Text;
            string prd_status = "";
            string goods_id = "";
            int cpl_status = 1;
            if (cmbFindStatus.Text != "")
                prd_status = cmbFindStatus.SelectedValue.ToString();
            if (rdbNoMachine.Checked == true)//未設定機器
                is_machine = 0;
            else
            {
                if (rdbIsMachine.Checked == true)//已設定機器
                    is_machine = 1;
                else
                {
                    is_machine = 2;//全部
                }
            }
            if (rdbIsComplete.Checked == true)//已完成
                cpl_status = 1;
            else
                if (rdbNoComplete.Checked == true)
                    cpl_status = 0;
            DataTable dtPA = getArrangeData(prd_dep, mo_id, goods_id, machine, now_date, worker, is_machine, prd_status, rec_status, cpl_status);
            dgvPA.DataSource = dtPA;
            //gridControl1.DataSource = dtPA;
            //dtPA.Columns.Add("art", typeof(Image));//
            dgvPA.Refresh();
        }
        private DataTable getArrangeData(string prd_dep, string mo_id,string goods_id, string machine, string now_date, string worker, int is_machine, string prd_status, int rec_status, int cpl_status)
            {
            string strSql = @"SELECT A.arrange_id, A.prd_dep, A.prd_mo, A.prd_item, A.prd_ver
                                , A.to_dep, A.prd_seq, A.arrange_date, A.arrange_seq, A.arrange_qty
                                , A.estimated_date, A.estimated_time,A.estimated_start_date, A.estimated_start_time ,A.req_time
                                , A.arrange_machine, A.crusr, A.crtim, A.amusr, A.amtim 
                                , B.prd_date, B.prd_start_time,B.hour_std_qty,b.prd_end_time,b.prd_qty,a.rec_status,c.name AS goods_name,b.prd_req_time
                                ,a.mo_urgent,d.art_image,e.flag_desc,a.order_date,a.req_f_date,a.prd_worker,a.prd_status,f.flag_desc AS prd_status_desc
                            FROM product_arrange a
                            LEFT JOIN product_records B ON A.prd_id=B.prd_id
                            LEFT JOIN dgcf_db.dbo.geo_it_goods c ON a.prd_item COLLATE Chinese_Taiwan_Stroke_CI_AS =c.id
                            LEFT JOIN dgcf_db.dbo.bs_artwork d ON c.blueprint_id=d.art_code
                            LEFT JOIN dgcf_db.dbo.bs_flag_desc e ON a.mo_urgent COLLATE Chinese_Taiwan_Stroke_CI_AS =e.flag_id
                            LEFT JOIN dgcf_db.dbo.bs_flag_desc f ON a.prd_status COLLATE Chinese_Taiwan_Stroke_CI_AS =f.flag_id
                            WHERE e.doc_type='UG' AND e.flag0='Y' AND f.doc_type='PD' AND f.flag0='Y' ";
            if (prd_dep != "")
            {
                strSql += " AND A.prd_dep='" + prd_dep + "' ";
            }

            if (mo_id != "")
            {
                strSql += " AND A.prd_mo='" + mo_id + "'";
            }
            if (goods_id != "")
            {
                strSql += " AND A.prd_item='" + goods_id + "'";
            }
            if (machine != "")
            {
                strSql += " AND A.arrange_machine='" + machine + "'";
            }
                
            if (now_date != "/  /")
                strSql += " AND a.now_date='" + now_date + "'";
            if (worker != "")
                strSql += "AND a.prd_worker='" + worker + "'";
            if (is_machine == 0)//未設定機器
                strSql += " AND a.arrange_machine='" + "" + "'";
            else
            {
                if (is_machine == 1)//已設定機器
                    strSql += " AND a.arrange_machine <>'" + "" + "'";
            }

            if (cpl_status == 0)//未完成
                strSql += " AND a.prd_status <'90'";
            else
                if (cpl_status == 1)//已完成
                    strSql += " AND a.prd_status >='90'";
            if (prd_status != "")
                strSql += " AND a.prd_status ='" + prd_status + "'";
            if (rec_status == 0)//是否是取消的排程
                strSql += " AND a.rec_status ='" + "0" + "'";
            else
                if (rec_status == 1)
                    strSql += " AND a.rec_status ='" + "1" + "'";

            strSql += " ORDER BY ";
            if (strSort != "")
                strSql += strSort;
            else
                strSql += " a.prd_dep,a.arrange_seq,a.arrange_machine";

            dtPA = clsPublicOfPad.GetDataTable(strSql);

            return dtPA;
            
        }
        //返回图片的字节流byte[] 
        private byte[] getImageByte(string imagePath)
        {

            FileStream files = new FileStream(imagePath, FileMode.Open);

            byte[] imgByte = new byte[files.Length];

            files.Read(imgByte, 0, imgByte.Length);

            files.Close();

            return imgByte;

        }


        //獲取制單編號資料，并綁定物料編號
        private void GetMo_itme(string item)
        {
            cmbGoods_id.Items.Clear();
            string fdep = cmbProductDept.SelectedValue.ToString();
            string tdep = "";
            if (fdep == "J07")
                fdep = "510";
            dtMo_item = clsProductionSchedule.GetMo_dataById(txtmo_id.Text.Trim(), fdep,tdep, item);
            if (dtMo_item.Rows.Count > 0)
            {
                for (int i = 0; i < dtMo_item.Rows.Count; i++)
                {
                    cmbGoods_id.Items.Add(dtMo_item.Rows[i]["goods_id"].ToString().Trim());
                }
            }
        }

        private void fill_plan_value()
        {
            if (dtMo_item.Rows.Count > 0)
            {
                for (int i = 0; i < dtMo_item.Rows.Count; i++)
                {
                    if (cmbGoods_id.Text.ToString().Trim() == dtMo_item.Rows[i]["goods_id"].ToString().Trim())
                    {
                        txtPrd_seq.Text = dtMo_item.Rows[i]["sequence_id"].ToString();
                        txtPrd_ver.Text = dtMo_item.Rows[i]["ver"].ToString();
                        txtgoods_desc.Text = dtMo_item.Rows[i]["name"].ToString();
                        if (dtMo_item.Rows[i]["prod_qty"].ToString() != "" && txtPrd_qty.Text == "")
                            txtPrd_qty.Text = Convert.ToInt32(dtMo_item.Rows[i]["prod_qty"]).ToString();
                        if (txtToDep.Text.Trim() == "")
                            txtToDep.Text = dtMo_item.Rows[i]["next_wp_id"].ToString();
                    }
                }
            }
        }


        private void btnSavePriority_Click(object sender, EventArgs e)
        {
            
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

        private void btnMakeOrderStatus_Click(object sender, EventArgs e)
        {
            frmShowPlan frmSP = new frmShowPlan();
            if (dgvPA.Rows.Count > 0)
            {
                if (dgvPA.CurrentRow.Index >= 0)
                {
                    frmSP.strMo_id = dgvPA.CurrentRow.Cells["colPrd_mo"].Value.ToString();
                    //frmSP.ShowDialog();
                }
            }
            if (frm_Main.isRunMain == true)
                frmSP.MdiParent = frm_Main.ActiveForm;//this;
            frmSP.WindowState = FormWindowState.Maximized;
            frmSP.Show();

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 調整生產書序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArrange_seq_Click(object sender, EventArgs e)
        {
            if (dgvPA.Rows.Count == 0)
            {
                MessageBox.Show("沒有記錄，不能計算時間!");
                return;
            }
            if (txttSeqTo.Text.Trim() == "")
            {
                MessageBox.Show("序號無效!");
                txttSeqTo.Focus();
                return;
            }
            int InputSeq = Convert.ToInt32(txttSeqTo.Text.Trim());//需要移動到的位置
            if (InputSeq < 0 || InputSeq > dtPA.Rows.Count)
            {
                MessageBox.Show("記錄超出範圍!");
                return;
            }
            int SelectRow = (dgvPA.CurrentRow.Index);//選中行的位置
            if (string.Compare(dgvPA.Rows[InputSeq-1].Cells["colArrange_machine"].Value.ToString().Trim(), dgvPA.Rows[SelectRow].Cells["colArrange_machine"].Value.ToString().Trim()) != 0)
            {
                MessageBox.Show("不同機器之間不能進行排序!");
                return;
            }
            //檢查是否存在不同機器
            if (chkDiffrentMac() == false)
                return;

            if (InputSeq <= SelectRow)//如果當前記錄是往前移
            {
                for (int i = 0; i < dtPA.Rows.Count; i++)
                {
                    if (i == SelectRow)
                    {
                        dtPA.Rows[i]["Arrange_seq"] = InputSeq.ToString();
                    }
                    else
                    {
                        if (i + 1 >= InputSeq && i < SelectRow)
                            dtPA.Rows[i]["Arrange_seq"] = (Convert.ToInt32(dtPA.Rows[i]["Arrange_seq"].ToString()) + 1).ToString();
                    }
                }
            }
            else//如果當前記錄是往後移
            {
                for (int i = 0; i < dtPA.Rows.Count; i++)
                {
                    if (i == SelectRow)
                    {
                        dtPA.Rows[i]["Arrange_seq"] = InputSeq.ToString();
                    }
                    else
                    {
                        if (i > SelectRow && i < InputSeq)
                        {
                            dtPA.Rows[i]["Arrange_seq"] = (Convert.ToInt32(dtPA.Rows[i]["Arrange_seq"].ToString()) - 1).ToString();
                        }
                    }
                }
            }
            DataTable dtCopy = dtPA.Copy();
            DataView dv = dtCopy.DefaultView;
            dv.Sort = "prd_dep,arrange_seq";
            dtPA = dv.ToTable();

            dgvPA.DataSource = dtPA;
            dgvPA.Rows[0].Selected = false;
            count_req_time();//計算預計完成時間
            btnSaveArrange.Enabled = true;
            //string strPa_id = dgvPA.CurrentRow.Cells["colId"].Value.ToString();
            //for (int i = 0; i < dtPA.Rows.Count; i++)
            //{
            //    if (strPa_id == dtPA.Rows[i]["arrange_id"].ToString())
            //    {
            //        int Arge_seq = Convert.ToInt32(dtPA.Rows[i]["arrange_seq"].ToString());
            //        if (InputSeq > Arge_seq)
            //        {
            //            for (int j = 1; j <= InputSeq - Arge_seq; j++)
            //            {
            //                dtPA.Rows[i + j]["arrange_seq"] = Convert.ToInt32(dtPA.Rows[i + j]["arrange_seq"]) - 1;
            //            }
            //        }
            //        else
            //        {
            //            for (int k = 1; k <= Arge_seq - InputSeq; k++)
            //            {
            //                dtPA.Rows[i - k]["arrange_seq"] = Convert.ToInt32(dtPA.Rows[i - k]["arrange_seq"]) + 1;
            //            }
            //        }
            //        dtPA.Rows[i]["arrange_seq"] = InputSeq;

            //DataTable dtCopy = dtPA.Copy();
            //DataView dv = dtCopy.DefaultView;
            //dv.Sort = "prd_dep,arrange_seq";
            //dtPA = dv.ToTable();

            //dgvPA.DataSource = dtPA;
            //dgvPA.Rows[0].Selected = false;
            //break;
            //    }
            //}

            //SelectionIndex(strPa_id);

            //Analyze();
            //}
        }
        private bool chkDiffrentMac()
        {
            bool result=true;
            if (dtPA.Rows.Count == 0)
            {
                MessageBox.Show("沒有記錄!");
                result = false;
                return result;
            }
            string machine_id = dtPA.Rows[0]["arrange_machine"].ToString().Trim();
            for (int i = 0; i < dtPA.Rows.Count; i++)
            {
                if (string.Compare(machine_id, dtPA.Rows[i]["arrange_machine"].ToString().Trim()) != 0)
                {
                    MessageBox.Show("不能混合在不同機器之間進行排序!");
                    result = false;
                    break;
                }
            }
            return result;
        }
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            //Analyze();
            if (chkDiffrentMac() == false)
                return;
            if (dgvPA.Rows.Count == 0)
            {
                MessageBox.Show("沒有記錄，不能計算時間!");
                return;
            }
            if (txtHour_std_qty.Text.Trim() == "")
            {
                MessageBox.Show("機器標準為空，不能計算時間!");
                txtHour_std_qty.Focus();
                return;
            }
            count_req_time();
            btnSaveArrange.Enabled = true;
        }
        private void count_req_time()
        {
            double hour_num = 0;
            string prd_date;
            string start_time;
            string end_time;
            float hour_std_qty;
            float prd_qty;
            float total_qty = 0;
            DateTime new_start_time;
            hour_std_qty = Convert.ToInt32(txtHour_std_qty.Text.ToString());
            prd_date = dgvPA.Rows[0].Cells["colArrange_date"].Value.ToString();
            start_time = dgvPA.Rows[0].Cells["colActive_start_time"].Value.ToString();
            if (prd_date == "")
                prd_date = System.DateTime.Now.ToString("yyyy/MM/dd");//如果沒有開始日期，則從當前日期開始
            if (start_time.Trim() == "")
                start_time = "08:30:00";//如果沒有開始時間，則從每天開始上班時間開始
            new_start_time = Convert.ToDateTime(prd_date + " " + start_time);
            for (int i = 0; i < dgvPA.RowCount; i++)
            {
                prd_qty = Convert.ToInt32(dgvPA.Rows[i].Cells["colArrange_qty"].Value.ToString());
                end_time = "";
                if (prd_qty != 0 && hour_std_qty != 0 && start_time != "00:00")
                {
                    hour_num = Math.Round(prd_qty / hour_std_qty, 3);
                    //finish_work_time = Convert.ToDateTime(prd_date + " " + start_time).AddHours(hour_num).ToString("yyyy/MM/dd HH:mm".Substring(11, 5));
                    ////當開始時間是從08:30,完成時間是在12:30~18:00之間的
                    //if (string.Compare(start_time, am_start_time) >= 0
                    //    && string.Compare(start_time, finish_work_noon1) <= 0
                    //    && string.Compare(finish_work_time, finish_work_noon1) > 0)
                    //{
                    //    if (chkcont_work1.Checked == false)
                    //        hour_num = hour_num + 1.5;
                    //}

                    //finish_work_time = Convert.ToDateTime(prd_date + " " + start_time).AddHours(hour_num).ToString("yyyy/MM/dd HH:mm".Substring(11, 5));
                    //if (string.Compare(finish_work_time, finish_work_afternoon1) > 0
                    //    && string.Compare(start_time, finish_work_afternoon1) <= 0)
                    //{
                    //    if (chkcont_work2.Checked == false)
                    //        hour_num = hour_num + 1;
                    //}
                    end_time = new_start_time.AddHours(hour_num).ToString("yyyy/MM/dd HH:ss:dd");
                    dgvPA.Rows[i].Cells["colEstimated_time"].Value = end_time;
                    //tdt.Rows[i]["prd_about_time"] = hour_num.ToString();
                    dgvPA.Rows[i].Cells["colreq_time"].Value = hour_num.ToString();
                    new_start_time = Convert.ToDateTime(end_time);
                }
                total_qty = total_qty + prd_qty;
            }
        }
        private void Analyze()
        {
            if (chkDiffrentMac() == false)
                return;
            int percent_qty_hour = 0;
            int Percent_qty_minute = 0;
            string Req_time = "";
            DateTime Estimated_date = DateTime.Now;

            for (int i = 0; i < dtPA.Rows.Count; i++)
            {

                if ((dtPA.Rows[i]["hour_std_qty"].ToString() != "" || dtPA.Rows[i]["arrange_machine"].ToString() != "")
                    && (dtPA.Rows[i]["hour_std_qty"].ToString() != "0" || dtPA.Rows[i]["arrange_machine"].ToString() != ""))
                {
                    if (!string.IsNullOrEmpty(dtPA.Rows[i]["hour_std_qty"].ToString()) && dtPA.Rows[i]["hour_std_qty"].ToString() != "0")
                    {
                        percent_qty_hour = Convert.ToInt32(dtPA.Rows[i]["hour_std_qty"].ToString());
                        if (percent_qty_hour / 60 == 0)
                        {
                            Percent_qty_minute = 1;
                        }
                        else
                        {
                            Percent_qty_minute = percent_qty_hour / 60;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dtPA.Rows[i]["arrange_machine"].ToString()))
                        {
                            GetMachine_std(dtPA.Rows[i]["prd_dep"].ToString(), dtPA.Rows[i]["arrange_machine"].ToString(), dtPA.Rows[i]["prd_item"].ToString());

                            if (dtMachine_std.Rows.Count > 0)
                            {
                                percent_qty_hour = Convert.ToInt32(dtMachine_std.Rows[0]["machine_std_qty"]);
                                if (percent_qty_hour / 60 == 0)
                                {
                                    Percent_qty_minute = 1;
                                }
                                else
                                {
                                    Percent_qty_minute = percent_qty_hour / 60;
                                }
                            }
                        }
                    }

                    if (Percent_qty_minute > 0)
                    {
                        int Req_time_minute = 0;
                        int Prod_qty = Convert.ToInt32(dtPA.Rows[i]["arrange_qty"]);
                        if (Prod_qty % percent_qty_hour == 0)
                        {
                            Req_time_minute = (Prod_qty / percent_qty_hour) * 60;
                            Req_time = (Req_time_minute / 60).ToString() + "小時";
                        }
                        else
                        {
                            Req_time_minute = Prod_qty / Percent_qty_minute;

                            if (Req_time_minute >= 60)
                            {
                                Req_time = (Req_time_minute / 60).ToString() + "小時";
                                if (Req_time_minute % 60 > 0)
                                {
                                    Req_time += (Req_time_minute % 60).ToString() + "分";
                                }
                            }
                            else
                            {
                                Req_time = Req_time_minute + "分";
                            }
                        }

                        if (i != 0)
                        {
                            if (!string.IsNullOrEmpty(dtPA.Rows[i - 1]["estimated_date"].ToString()) && !string.IsNullOrEmpty(dtPA.Rows[i - 1]["estimated_time"].ToString()))
                            {
                              
                                //判斷是否為同一部門、機器，如果不同則重新計算日期、時間
                                if (dtPA.Rows[i]["prd_dep"].ToString() == dtPA.Rows[i - 1]["prd_dep"].ToString() && dtPA.Rows[i]["arrange_machine"].ToString() == dtPA.Rows[i - 1]["arrange_machine"].ToString())
                                {
                                    string strDate = dtPA.Rows[i - 1]["estimated_date"].ToString() + " " + dtPA.Rows[i - 1]["estimated_time"].ToString();
                                    Estimated_date = Convert.ToDateTime(strDate);
                                    dtPA.Rows[i]["estimated_start_date"] = dtPA.Rows[i - 1]["estimated_date"].ToString();
                                    dtPA.Rows[i]["estimated_start_time"] = dtPA.Rows[i - 1]["estimated_time"].ToString();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(dtPA.Rows[i]["prd_date"].ToString()) && !string.IsNullOrEmpty(dtPA.Rows[i]["prd_start_time"].ToString()))
                                    {
                                        Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["prd_date"].ToString() + " " + dtPA.Rows[i]["prd_start_time"].ToString());
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(dtPA.Rows[i]["prd_date"].ToString()))
                                        {
                                            Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["prd_date"].ToString());
                                        }
                                        else
                                        {
                                            Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["arrange_date"].ToString());
                                        }
                                        Estimated_date = Estimated_date.AddHours(8).AddMinutes(30);
                                    }

                                    dtPA.Rows[i]["estimated_start_date"] = Estimated_date.ToString("yyyy/MM/dd");
                                    dtPA.Rows[i]["estimated_start_time"] = Estimated_date.ToString("HH:mm");
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(dtPA.Rows[i]["prd_date"].ToString()) && !string.IsNullOrEmpty(dtPA.Rows[i]["prd_start_time"].ToString()))
                                {
                                    Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["prd_date"].ToString() + " " + dtPA.Rows[i]["prd_start_time"].ToString());
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(dtPA.Rows[i]["prd_date"].ToString()))
                                    {
                                        Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["prd_date"].ToString());
                                    }
                                    else
                                    {
                                        Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["arrange_date"].ToString());
                                    }
                                    Estimated_date = Estimated_date.AddHours(8).AddMinutes(30);
                                }
                                dtPA.Rows[i]["estimated_start_date"] = Estimated_date.ToString("yyyy/MM/dd");
                                dtPA.Rows[i]["estimated_start_time"] = Estimated_date.ToString("HH:mm");
                            }
                            Estimated_date = Estimated_date.AddMinutes(Req_time_minute);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dtPA.Rows[i]["prd_date"].ToString()) && !string.IsNullOrEmpty(dtPA.Rows[i]["prd_start_time"].ToString()))
                            {
                                Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["prd_date"].ToString() + " " + dtPA.Rows[i]["prd_start_time"].ToString());
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(dtPA.Rows[i]["prd_date"].ToString()))
                                {
                                    Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["prd_date"].ToString());
                                }
                                else
                                {
                                    Estimated_date = Convert.ToDateTime(dtPA.Rows[i]["arrange_date"].ToString());
                                }

                                Estimated_date = Estimated_date.AddHours(8).AddMinutes(30);
                            }
                            dtPA.Rows[i]["estimated_start_date"] = Estimated_date.ToString("yyyy/MM/dd");
                            dtPA.Rows[i]["estimated_start_time"] = Estimated_date.ToString("HH:mm");
                            Estimated_date = Estimated_date.AddMinutes(Req_time_minute);
                        }

                        dtPA.Rows[i]["estimated_date"] = Estimated_date.ToString("yyyy/MM/dd");
                        dtPA.Rows[i]["estimated_time"] = Estimated_date.ToString("HH:mm");
                        dtPA.Rows[i]["req_time"] = Req_time;
                    }
                }
            }
        }

        private void ClearAllText()
        {
            masktxtPrd_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtmo_id.Text = "";
            txtBarCode.Text = "";
            cmbGoods_id.Text = "";
            ClearPartOfText();
        }

        private void ClearPartOfText()
        {
            strArrange_id = "";
            txtgoods_desc.Text = "";
            txtToDep.Text = "";
            txtToDept_name.Text = "";
            txtPrd_seq.Text = "";
            txtPrd_ver.Text = "";
            cmbMachine.SelectedValue = "";
            txtPrd_qty.Text = "";
            txtArrange_seq.Text = "";
            msktxtEstimate_date.Text = "";
            msktxtEstimate_time.Text = "";
            txtRequest_time.Text = "";
            msktxtEstimate_start_date.Text = "";
            msktxtEstimate_start_time.Text = "";
            msktxtActive_start_date.Text = "";
            msktxtActive_start_time.Text = "";
            txtMachine_stand_qty.Text = "";
            txtArrange_id.Text = "";
        }

        private void ControlState()
        {
            switch (OperationType)
            {
                case clsUtility.enumOperationType.Add:
                    {
                        
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        cmbProductDept.Enabled = true;
                        masktxtPrd_date.Enabled = true;
                        txtmo_id.Enabled = true;
                        txtBarCode.Enabled = true;
                        cmbGoods_id.Enabled = true;
                        cmbMachine.Enabled = true;

                        ClearAllText();

                        strArrange_id = "";
                    }
                    break;
                case clsUtility.enumOperationType.Update:
                    {
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                        cmbProductDept.Enabled = false;
                        txtmo_id.Enabled = false;
                        txtBarCode.Enabled = false;
                        cmbGoods_id.Enabled = false;
                        cmbMachine.Enabled = true;
                        masktxtPrd_date.Enabled = true;
                    }
                    break;
                case clsUtility.enumOperationType.Cancel:
                    {
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        cmbProductDept.Enabled = false;
                        masktxtPrd_date.Enabled = false;
                        txtmo_id.Enabled = false;
                        txtBarCode.Enabled = false;
                        cmbGoods_id.Enabled = false;
                        cmbMachine.Enabled = false;

                        ClearAllText();
                        strArrange_id = "";
                    }
                    break;
                case clsUtility.enumOperationType.Save:
                    {
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        cmbProductDept.Enabled = false;
                        masktxtPrd_date.Enabled = false;
                        txtmo_id.Enabled = false;
                        txtBarCode.Enabled = false;
                        cmbGoods_id.Enabled = false;
                        cmbMachine.Enabled = false;

                        ClearAllText();
                    }
                    break;
                case clsUtility.enumOperationType.Load:
                    {
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;

                        cmbProductDept.Enabled = false;
                        masktxtPrd_date.Enabled = false;
                        txtmo_id.Enabled = false;
                        txtBarCode.Enabled = false;
                        cmbGoods_id.Enabled = false;
                        cmbMachine.Enabled = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 獲取機器的各項標準數據
        /// </summary>
        /// <param name="Prd_dep"></param>
        /// <param name="Machine_id"></param>
        private int GetMachine_std(string Prd_dep, string Machine_id, string prd_item)
        {
            int qty_std = 0;
            string strSql = "";
            string dep = Prd_dep;
            string machine_id = Machine_id;
            string size_id = "";
            if (prd_item.Length >= 18)
            {
                size_id = prd_item.Substring(12, 3);
            }
            string machine_id_part = (machine_id.Length >= 3 ? machine_id.Substring(0, 3) : "");
            if (dep == "102" || dep == "104" || dep == "105")
            {
                strSql = @" SELECT machine_id,machine_mul,machine_rate FROM machine_std 
                                 WHERE dep='" + dep + "' AND machine_id ='" + machine_id + "' ";
                strSql = " SELECT machine_id,rows_count AS machine_mul,standard_qty AS machine_rate,(rows_count*standard_qty)as machine_std_qty FROM " + DBUtility.remote_db + "cd_machine_standard " +
                               " WHERE dept_id='" + dep + "' AND machine_id ='" + machine_id + "' " + " AND state='0'";
            }
            else
            {
                if (dep == "302")
                {
                    string prd_code = prd_item;
                    prd_code = (cmbGoods_id.Text.Length >= 18 ? cmbGoods_id.Text.Substring(2, 2) : "");
                    strSql = " SELECT machine_id,machine_mul,machine_rate,machine_std_qty FROM machine_std " +
                             " WHERE dep='" + dep + "' AND machine_id ='" + machine_id
                                + "' AND prd_code ='" + prd_code + "' ";
                }
                else
                {
                    if (dep == "202")
                    {
                        if (machine_id.Length >= 5 && machine_id.Substring(0, 5) != "K-L-W")
                        {
                            strSql = " SELECT machine_id,per_stele_qty AS machine_mul,standard_qty AS machine_rate,(per_stele_qty*standard_qty)as machine_std_qty FROM " + DBUtility.remote_db + "cd_machine_standard " +
                              " WHERE dept_id='" + dep + "' AND machine_id ='" + machine_id + "' " + " AND state='0'";

                        }
                        
                    }
                    else
                    {
                        if (dep == "J07")
                        {
                            //暫時不要加入尺碼來當作標準
                            strSql = @" SELECT machine_id,machine_mul,machine_rate,machine_std_qty FROM machine_std 
                                 WHERE dep='" + dep + "' AND machine_id ='" + machine_id + "'";// +"' AND size_id=' " + size_id + "'";
                        }
                    }
                    //if (dep == "203")
                    //{
                    //    strSql = " SELECT machine_id,rows_count AS machine_mul,standard_qty AS machine_rate FROM " + DBUtility.remote_db + "cd_machine_standard " +
                    //           " WHERE dept_id='" + dep + "' " + " AND type_work='" + txtJob_type.Text.Trim() + "'" + " AND difficulty='" + txtDifficulty_level.Text.Trim() + "'" + " AND state='0'";

                    //}
                    //else
                    //{
                    //    if (cmbProductDept.Text == "105" && cmbGroup.Text == "BC01" && machine_id_part != "NTR")//林口手碑組的標準
                    //    {
                    //        strSql = " SELECT type_work AS machine_id,rows_count AS machine_mul,standard_qty AS machine_rate FROM " + DBUtility.remote_db + "cd_machine_standard " +
                    //           " WHERE dept_id='" + dep + "' AND type_work ='" + txtJob_type.Text.Trim() + "' " + " AND state='0'";
                    //    }
                    //}
                }
            }
            try
            {
                if (strSql != "")
                {
                    dtMachine_std = clsPublicOfPad.GetDataTable(strSql);

                    if (dtMachine_std.Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(dtMachine_std.Rows[0]["machine_std_qty"].ToString()))
                        {
                            if (!string.IsNullOrEmpty(dtMachine_std.Rows[0]["machine_rate"].ToString()))
                            {
                                dtMachine_std.Rows[0]["machine_std_qty"] = dtMachine_std.Rows[0]["machine_rate"];
                            }
                        }
                        qty_std = Convert.ToInt32(dtMachine_std.Rows[0]["machine_std_qty"]);
                    }
                    else
                        qty_std = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return qty_std;
        }

        /// <summary>
        /// 根據主鍵ID,選中指定行
        /// </summary>
        /// <param name="strPa_id"></param>
        private void SelectionIndex(string strPa_id)
        {
            if (strPa_id != "")
            {
                for (int i = 0; i < dgvPA.RowCount; i++)
                {
                    if (strPa_id == dgvPA.Rows[i].Cells["colId"].Value.ToString())
                    {
                        dgvPA.Rows[i].Selected = true;
                        dgvPA.CurrentCell = dgvPA.Rows[i].Cells[1];
                        dgvPA.Rows[i].Cells["colArrange_seq"].Style.SelectionForeColor = Color.Red;
                        break;
                    }
                }
            }
        }

        private void dgvPA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBox(e.RowIndex);
            if (chkSetWorker.Checked == true)
            {
                showWorker();
            }
        }
        private void FillTextBox(int i)
        {
            if (dgvPA.Rows.Count > 0)
            {
                ClearAllText();
                find_mode = "N";
                strArrange_id = dgvPA.Rows[i].Cells["colId"].Value.ToString();
                txtArrange_id.Text = strArrange_id;
                cmbProductDept.Text = dgvPA.Rows[i].Cells["colPrd_dep"].Value.ToString();
                masktxtPrd_date.Text = dgvPA.Rows[i].Cells["colArrange_date"].Value.ToString();
                txtmo_id.Text = dgvPA.Rows[i].Cells["colPrd_mo"].Value.ToString();
                cmbGoods_id.Text = dgvPA.Rows[i].Cells["colPrd_item"].Value.ToString();
                txtToDep.Text = dgvPA.Rows[i].Cells["colToDept"].Value.ToString();
                txtPrd_seq.Text = dgvPA.Rows[i].Cells["colPrd_seq"].Value.ToString();
                txtPrd_ver.Text = dgvPA.Rows[i].Cells["colPrd_ver"].Value.ToString();
                cmbMachine.SelectedValue = dgvPA.Rows[i].Cells["colArrange_machine"].Value.ToString();
                txtMachine_stand_qty.Text = dgvPA.Rows[i].Cells["colMachine_stand_qty"].Value.ToString();
                txtPrd_qty.Text = dgvPA.Rows[i].Cells["colArrange_qty"].Value.ToString();
                txtArrange_seq.Text = dgvPA.Rows[i].Cells["colArrange_seq"].Value.ToString();
                msktxtEstimate_date.Text = dgvPA.Rows[i].Cells["colEstimated_date"].Value.ToString();
                msktxtEstimate_time.Text = dgvPA.Rows[i].Cells["colEstimated_time"].Value.ToString();
                txtRequest_time.Text = dgvPA.Rows[i].Cells["colreq_time"].Value.ToString();
                msktxtEstimate_start_date.Text = dgvPA.Rows[i].Cells["colEstimated_start_date"].Value.ToString();
                msktxtEstimate_start_time.Text = dgvPA.Rows[i].Cells["colEstimated_start_time"].Value.ToString();
                msktxtActive_start_date.Text = dgvPA.Rows[i].Cells["colActive_start_date"].Value.ToString();
                msktxtActive_start_time.Text = dgvPA.Rows[i].Cells["colActive_start_time"].Value.ToString();
                cmbMoUrgent.SelectedValue = dgvPA.Rows[i].Cells["colMo_urgent"].Value.ToString();
                cmbPrd_status.SelectedValue = dgvPA.Rows[i].Cells["colPrd_status"].Value.ToString();
                txtCust_o_date.Text = dgvPA.Rows[i].Cells["colCust_o_date"].Value.ToString();
                txtReq_f_date.Text = dgvPA.Rows[i].Cells["colReq_f_date"].Value.ToString();
                txtProductNo.Text = dgvPA.Rows[i].Cells["colProductNo"].Value.ToString();
                txtHour_std_qty.Text = "";
                string machine = (cmbMachine.SelectedValue != null ? cmbMachine.SelectedValue.ToString().Trim() : "");
                //獲取每行的機器標準
                GetMachine_std(cmbProductDept.Text, machine, cmbGoods_id.Text);
                if (dtMachine_std.Rows.Count > 0)
                {
                    if (dtMachine_std.Rows[0]["machine_std_qty"].ToString() != "")
                        txtHour_std_qty.Text = Convert.ToInt32(dtMachine_std.Rows[0]["machine_std_qty"]).ToString();
                    else
                        txtHour_std_qty.Text = "0";
                    txtMachine_stand_qty.Text = txtHour_std_qty.Text;
                }
            }
        }
        private void dgvPA_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
             e.RowBounds.Location.Y,
             dgvPA.RowHeadersWidth - 4,
             e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvPA.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvPA.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            //showImage();
        }

        private void btnSaveArrange_Click(object sender, EventArgs e)
        {
            if (dgvPA.Rows.Count == 0)
            {
                MessageBox.Show("沒有記錄，不能計算時間!");
                return;
            }
            int Result = clsProductionSchedule.SaveChangeArrangeSeq(dtPA);

            if (Result > 0)
            {
                //btnSavePriority.Enabled = false;
                //btnSearch.Enabled = true;
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存出錯！");
            }
        }
        

        private void LoadData()
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            GetPrdocutArrange();
            //initSortRec();//排序記錄//暫時取消系統自動排序2018/01/30
            setCellsColor();
            FillTextBox(0);
            showImage();//顯示artwork圖片
            //show_Image();
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        //設置按機器顯示不同行顏色
        private void setCellsColor()
        {
            if (dgvPA.Rows.Count == 0)
                return;
            string machine;
            Color cl= new Color();
            cl = Color.White;
            machine = dgvPA.Rows[0].Cells["colArrange_machine"].Value.ToString().Trim();
            dgvPA.Rows[0].DefaultCellStyle.BackColor = cl;
            for (int i = 1; i < dgvPA.Rows.Count; i++)
            {
                if (machine == dgvPA.Rows[i].Cells["colArrange_machine"].Value.ToString())
                    dgvPA.Rows[i].DefaultCellStyle.BackColor = cl;
                else
                {
                    if(cl == Color.White)
                        cl = Color.LightBlue;
                    else
                        cl = Color.White;
                    dgvPA.Rows[i].DefaultCellStyle.BackColor = cl;
                    machine = dgvPA.Rows[i].Cells["colArrange_machine"].Value.ToString().Trim();
                }

            }
                
        }
        //顯示artwork圖片
        private void showImage()
        {
            for (int i = 0; i < dgvPA.Rows.Count; i++)
            {
                string imgfile = @"Y:\Artwork\AAAA\A888001.BMP";
                imgfile = DBUtility.imagePath + dgvPA.Rows[i].Cells["colArt_image"].Value.ToString().Trim();
                if (File.Exists(imgfile))//如果存在文件
                {
                    DataGridViewImageColumn dvic = new DataGridViewImageColumn(true);
                    dvic.Image = Image.FromFile(imgfile);
                    dgvPA.Rows[i].Cells["colArtWork"].Value = dvic.Image;
                }
            }
        }
        //顯示DV表格圖片
        private void showImageDV()
        {
        }
        private void btnImputExcel_Click(object sender, EventArgs e)
        {
            
            DataTable tbImputExcel = clsPublic.ImputExcelToTable("");

            dgvImputExcel.DataSource = tbImputExcel;
        }
        

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            if (dgvImputExcel.Rows.Count == 0)
            {
                MessageBox.Show("沒有要儲存的記錄!");
                return;
            }
            for (int i = 0; i < dgvImputExcel.Rows.Count; i++)
            {
                if (dgvImputExcel.Rows[i].Cells["colDep"].Value == null || dgvImputExcel.Rows[i].Cells["colDep"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("存在生產部門為空的記錄!"+(i+1).ToString().Trim());
                    return;
                }
                if (dgvImputExcel.Rows[i].Cells["colMo"].Value == null || dgvImputExcel.Rows[i].Cells["colMo"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("存在制單編號為空的記錄!" + (i + 1).ToString().Trim());
                    return;
                }
                if (dgvImputExcel.Rows[i].Cells["colItem"].Value == null || dgvImputExcel.Rows[i].Cells["colItem"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("存在物料編號為空的記錄!" + (i + 1).ToString().Trim());
                    return;
                }
                if (dgvImputExcel.Rows[i].Cells["colQty"].Value == null || dgvImputExcel.Rows[i].Cells["colQty"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("存在數量為空的記錄!" + (i + 1).ToString().Trim());
                    return;
                }
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            SaveExcel();
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }

        private void SaveExcel()
        {
            int MaxArrange_seq = 0;
            insert_mode = 1;
            int Result = 0;
            DataTable dtPrd=new DataTable();
            for (int i = 0; i < dgvImputExcel.Rows.Count; i++)
            {
                product_arrange objModel = new product_arrange();
                objModel.arrange_id = clsProductionSchedule.GetMaxArrange_id() + 1;//提取序號

                objModel.prd_dep = dgvImputExcel.Rows[i].Cells["colDep"].Value.ToString();
                objModel.prd_mo = dgvImputExcel.Rows[i].Cells["colMo"].Value.ToString();
                objModel.prd_item = dgvImputExcel.Rows[i].Cells["colItem"].Value.ToString();
                objModel.arrange_qty = Convert.ToInt32(dgvImputExcel.Rows[i].Cells["colQty"].Value.ToString());
                if (dgvImputExcel.Rows[i].Cells["colMac"].Value != null)
                    objModel.arrange_machine = dgvImputExcel.Rows[i].Cells["colMac"].Value.ToString();
                else
                    objModel.arrange_machine = "";
                if (dgvImputExcel.Rows[i].Cells["colGroup"].Value != null)
                    objModel.prd_group = dgvImputExcel.Rows[i].Cells["colGroup"].Value.ToString();
                else
                    objModel.prd_group = "";
                if (dgvImputExcel.Rows[i].Cells["colDate"].Value != null)
                    objModel.arrange_date = dgvImputExcel.Rows[i].Cells["colDate"].Value.ToString();
                else
                    objModel.arrange_date = "";
                if (dgvImputExcel.Rows[i].Cells["colVer"].Value != null)
                    objModel.prd_ver = Convert.ToInt32(dgvImputExcel.Rows[i].Cells["colVer"].Value.ToString());
                else
                    objModel.prd_ver = 0;
                if (dgvImputExcel.Rows[i].Cells["colToDep"].Value != null)
                    objModel.to_dep = dgvImputExcel.Rows[i].Cells["colToDep"].Value.ToString();
                else
                    objModel.to_dep = "";
                if (dgvImputExcel.Rows[i].Cells["colPrdSeq"].Value != null)
                    objModel.prd_seq = dgvImputExcel.Rows[i].Cells["colPrdSeq"].Value.ToString();
                else
                    objModel.prd_seq = "";
                if (dgvImputExcel.Rows[i].Cells["colMoUrgent"].Value != null)
                    objModel.mo_urgent = dgvImputExcel.Rows[i].Cells["colMoUrgent"].Value.ToString().Trim();
                else
                    objModel.mo_urgent = "00";
                string mo_urgent1 = objModel.mo_urgent.Trim();
                if (mo_urgent1 == "超特急")
                    mo_urgent1 = "04";
                else
                {
                    if (mo_urgent1 == "特急")
                        mo_urgent1 = "03";
                    else
                    {
                        if (mo_urgent1 == "急" || mo_urgent1 == "急單")
                            mo_urgent1 = "02";
                        else
                            mo_urgent1 = "00";
                    }
                }
                objModel.mo_urgent = mo_urgent1;
                if (dgvImputExcel.Rows[i].Cells["colCustDate"].Value != null)
                    objModel.cust_o_date = dgvImputExcel.Rows[i].Cells["colCustDate"].Value.ToString();
                else
                    objModel.cust_o_date = "";
                if (dgvImputExcel.Rows[i].Cells["colReqDate"].Value != null)
                    objModel.req_f_date = dgvImputExcel.Rows[i].Cells["colReqDate"].Value.ToString();
                else
                    objModel.req_f_date = "";
                objModel.estimated_date = "";
                objModel.estimated_time = "";
                objModel.estimated_start_date = "";
                objModel.estimated_start_time = "";
                objModel.req_time = 0;

                MaxArrange_seq = clsProductionSchedule.GetMaxArrange_seq(objModel.prd_dep, objModel.arrange_machine);//提取排程序號
                objModel.arrange_seq = MaxArrange_seq + 1;
                
                objModel.crusr = _userid;
                objModel.rec_status = "0";
                dtPrd = clsProductionSchedule.CheckProductionArrange(objModel.prd_dep, objModel.prd_mo, objModel.prd_item);
                if (dtPrd.Rows.Count == 0)//如果沒有找到排程記錄，則重新插入
                    Result = clsProductionSchedule.AddOrUpdatePrdocutionArrange(objModel, insert_mode);
                    //Result = 1;
                else
                    Result = 1;
                if (Result == 0)
                    break;

            }
            if (Result > 0)
            {
                MessageBox.Show("保存成功!");
            }
            else
            {
                MessageBox.Show("保存失敗!");
            }
        }

        private void dgvImputExcel_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
             e.RowBounds.Location.Y,
             dgvPA.RowHeadersWidth - 4,
             e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvPA.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvPA.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }


        private void DvExportExcel()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel files(*.xls)|*.xls";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;
            saveFile.CreatePrompt = true;
            saveFile.Title = "导出Excel文件到";
            //DateTime now = DateTime.Now;
            //saveFile.FileName = now.ToShortDateString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFile.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("big5"));
                string str = " ";
                //写标题

                for (int i = 0; i < dgvPA.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvPA.Columns[i].HeaderText.ToString();// dv.Table.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //写内容
                string pre_id, cur_id, col_value;
                for (int rowNo = 0; rowNo < dgvPA.RowCount; rowNo++)
                {
                    string tempstr = " ";
                    for (int columnNo = 0; columnNo < dgvPA.ColumnCount; columnNo++)
                    {

                        if (columnNo > 0)
                        {
                            tempstr += "\t";
                        }
                        if (dgvPA.Rows[rowNo].Cells[columnNo].Value !=null && dgvPA.Rows[rowNo].Cells[columnNo].Value.ToString().Trim() != null)
                            col_value = dgvPA.Rows[rowNo].Cells[columnNo].Value.ToString().Trim();
                        else
                            col_value = "";
                        tempstr += col_value;
                    }
                    sw.WriteLine(tempstr);
                }

                sw.Close();
                myStream.Close();
                MessageBox.Show("已匯出記錄！");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (strArrange_id == "")
            {
                MessageBox.Show("沒有要刪除的排程!");
                return;
            }
            insert_mode = 3;//刪除排程
            product_arrange objModel = new product_arrange();
            objModel.arrange_id = Convert.ToInt32(strArrange_id);
            int Result = clsProductionSchedule.AddOrUpdatePrdocutionArrange(objModel, insert_mode);

            if (Result > 0)
            {
                MessageBox.Show("刪除成功！");
                LoadData();
            }
            else
            {
                MessageBox.Show("刪除失敗！");
            }
        }

        private void dgvPA_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            find_mode = "Y";
        }


        private void dgvPA_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvPA.Columns[e.ColumnIndex].Name.Equals("Image1"))
            //{
            //    //string imgfile = @"Y:\Artwork\AAAA\A888001.BMP";
            //    //imgfile = DBUtility.imagePath + dgvPA.Rows[i].Cells["colArt_image"].Value.ToString().Trim();
            //    string path = DBUtility.imagePath + e.Value.ToString();
            //    path = @"Y:\Artwork\AAAA\A888001.BMP";
            //    e.Value = GetImage(path);
            //}   

        }

        private void btnAddSort_Click(object sender, EventArgs e)
        {
            addSortTo(dgvSortFrom.CurrentCell.RowIndex);
            
        }

        private void btnDelSort_Click(object sender, EventArgs e)
        {
            if (dgvSortTo.Rows.Count > 0)
            {
                DataRow dr = null;
                dr = dtSortFrom.NewRow();
                dr["sort_fields"] = dgvSortTo.CurrentRow.Cells["colSort_To"].Value.ToString();
                dr["sort_select_code"] = dgvSortTo.CurrentRow.Cells["colSortCode_To"].Value.ToString();
                dr["sort_s"] = "升序";
                dtSortFrom.Rows.Add(dr);
                dtSortTo.Rows.RemoveAt(dgvSortTo.CurrentCell.RowIndex);
                addSortFields();
            }
        }
        private void addSortTo(int rowNo)
        {
            if (dgvSortFrom.Rows.Count > 0)
            {
                DataRow dr = null;
                dr = dtSortTo.NewRow();
                dr["sort_fields"] = dgvSortFrom.Rows[rowNo].Cells["colSort_From"].Value.ToString();
                dr["sort_select_code"] = dgvSortFrom.Rows[rowNo].Cells["colSortCode_From"].Value.ToString();
                dr["sort_s"] = "升序";
                dtSortTo.Rows.Add(dr);
                dtSortFrom.Rows.RemoveAt(rowNo);
                addSortFields();
            }
        }
        private void addSortFields()
        {
            txtSort.Text = "";
            for (int i = 0; i < dgvSortTo.Rows.Count; i++)
            {
                if (dgvSortTo.Rows[i].Cells["colSortCode_To"].Value.ToString() != "")
                {
                    if (i!=0)
                    {
                        txtSort.Text += ",";
                    }
                    txtSort.Text += dgvSortTo.Rows[i].Cells["colSortCode_To"].Value.ToString();
                    if (dgvSortTo.Rows[i].Cells["colSortType_To"].Value.ToString() == "升序")
                        txtSort.Text += " ";
                    else
                        txtSort.Text += " Desc ";
                }
            }
            strSort = txtSort.Text.Trim();
        }

        private void btnConfSort_Click(object sender, EventArgs e)
        {
            addSortFields();
            btnFind_Click(sender, e);
            tabControl2.SelectedIndex = 0;
        }



        private void timFind_Tick(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void btnActiveFind_Click(object sender, EventArgs e)
        {
            if (btnActiveFind.Text == "開啟自動查找")
            {
                timFind.Enabled = true;
                btnActiveFind.Text = "關閉自動查找";
            }
            else
            {
                timFind.Enabled = false;
                btnActiveFind.Text = "開啟自動查找";
            }

        }
        //private System.Drawing.Image GetImage(string path)
        //{
        //    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
        //    System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
        //    fs.Close();
        //    return result;
        //}   

        private void show_Image()
        {
            //for (int i = 0; i < dgvPA.Rows.Count; i++)
            //{
            //    string imgfile = @"Y:\Artwork\AAAA\A888001.BMP";
            //    imgfile = DBUtility.imagePath + dgvPA.Rows[i].Cells["colArt_image"].Value.ToString().Trim();

            //    if (File.Exists(imgfile))//如果存在文件
            //    {
            //        Image img = Image.FromFile(imgfile);//
            //       // /dt.Rows.Add(1, DateTime.Now, 1, img, 1);//方法1
            //        DataGridViewImageColumn dvic = new DataGridViewImageColumn(true);
            //        dvic.Image = Image.FromFile(imgfile);
            //        dgvPA.Rows[i].Cells["colArtWork"].Value = dvic.Image;
            //    }
            //}
            for (int i = 0; i < dtPA.Rows.Count; i++)
            {
                string imgfile = "";
                imgfile = DBUtility.imagePath + dtPA.Rows[i]["art_image"].ToString().Trim();

                if (File.Exists(imgfile))//如果存在文件
                {
                    Image img = Image.FromFile(imgfile);//
                    dtPA.Rows[i]["art"] = img;
                }
            }
            dgvPA.Refresh();

        }


        private void cmbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtProductNo_Leave(object sender, EventArgs e)
        {
            if (txtProductNo.Text.Trim() != "")
                txtProductNo.Text = txtProductNo.Text.PadLeft(10, '0');
        }


        private void cmbProductDept_Leave(object sender, EventArgs e)
        {
            ClearAllText();
        }

        private void cmbProductDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //獲取部門機器
            BindMachineCombox();
        }

        private void cmbFindDep_Leave(object sender, EventArgs e)
        {
            BindMachineComboxFind();
            cmbFindMachine.SelectedValue = "";
        }

        private void txtFindWorker_Leave(object sender, EventArgs e)
        {
            if (txtFindWorker.Text.Trim() != "")
                txtFindWorker.Text = txtFindWorker.Text.PadLeft(10, '0');
        }

        private void txtHour_run_num_TextChanged(object sender, EventArgs e)
        {
            CountMachinefStd();
        }
        private void CountMachinefStd()
        {
            int hour_run_num=0;
            int line_num = 1;
            if (txtLine_num.Text != "" && clsValidRule.IsNumeric(txtLine_num.Text))
                line_num = Convert.ToInt32(txtLine_num.Text);
            if (txtHour_run_num.Text != "" && clsValidRule.IsNumeric(txtHour_run_num.Text))
                hour_run_num = Convert.ToInt32(txtHour_run_num.Text);
            txtHour_std_qty.Text = (hour_run_num * line_num).ToString();

        }

        private void txtLine_num_TextChanged(object sender, EventArgs e)
        {
            CountMachinefStd();
        }

        private void cmbFindMachine_Leave(object sender, EventArgs e)
        {
            if (cmbFindMachine.SelectedValue != null)
            {
                int qty_std = GetMachine_std(cmbFindDep.SelectedValue.ToString(), cmbFindMachine.SelectedValue.ToString(), "");
                txtHour_run_num.Text = qty_std.ToString();
                CountMachinefStd();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnExpToExcel_Click(object sender, EventArgs e)
        {
            DvExportExcel();
        }



        private void mcFindDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            mktFindDate.Text = mcFindDate.SelectionEnd.ToString("yyyy/MM/dd");
            LoadData();
        }

        private void cmbMachine_Leave(object sender, EventArgs e)
        {
            string machine = (cmbMachine.SelectedValue != null ? cmbMachine.SelectedValue.ToString() : "");
            int qty_std = GetMachine_std(cmbProductDept.SelectedValue.ToString(), machine, cmbGoods_id.Text);
            txtMachine_stand_qty.Text = qty_std.ToString();
        }


    }
}
