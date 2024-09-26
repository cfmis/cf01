using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.CLS;
using System.IO;
using System.Threading;
using cf01.Forms;

namespace cf01.ReportForm
{
    public partial class frmMachineStatus1 : Form
    {
        clsCommonUse com = new clsCommonUse();
        string pad_db = DBUtility.pad_db;
        DataTable dt_machine = new DataTable();
        int page_no = 40;
        int step_id = 0;
        int start_rec_id;
        string imagePath = AppDomain.CurrentDomain.BaseDirectory;
        public string strPrd_dep = "";
        public frmMachineStatus1()
        {
            InitializeComponent();
            
            
        }
        private void initControlBox()
        {
            dgvDetails.AutoGenerateColumns = false;
            cmbDep.Items.Add("302-合金部碑機");
            cmbDep.Items.Add("102-鈕部萬能機");
            cmbDep.Items.Add("102-鈕部雞眼");
            cmbDep.Items.Add("105-鈕部林口");
            cmbDep.Items.Add("202-扣部開料");
            cmbDep.Items.Add("203-扣部裝嵌");
        }

        private void LoadMachineStatus()
        {
            //string strSql = null;
            //strSql = "SELECT dep,machine_id,machine_desc";
            //strSql += " FROM "+pad_db+"machine_tb Where dep >='' " + strWhere;
            //strSql += " ORDER BY machine_id ";
            //try
            //{
            //    dt_machine = db.GetDataSet(strSql, "tb_machine").Tables["tb_machine"];
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "软件提示");
            //    throw ex;
            //}

            //dt_machine = clsProductionSchedule.GetPrdMachineStatus1(2,txtDep.Text);


        }
        private void ShowMachineStatus(int start_rec_id)
        {
            string machine_id;
            foreach (Control ct in this.splitContainer1.Panel2.Controls)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip":
                        {
                            break;
                        }
                    case "Label":
                        {
                            Label lab = (Label)ct;
                            for (int i = start_rec_id; i < dt_machine.Rows.Count; i++)
                            {
                                machine_id = ((i % page_no) + 1).ToString().Trim();//機器代號
                                if (lab.Name == "lblMachineName" + machine_id)
                                {
                                    lab.Text = dt_machine.Rows[i]["machine_id"].ToString().Trim();//machine_desc
                                    break;
                                }
                                if (lab.Name == "lblMo" + machine_id)
                                {
                                    lab.Text = dt_machine.Rows[i]["prd_mo"].ToString().Trim();
                                    break;
                                }
                                //設置生產狀態
                                if (lab.Name == "lblStatus" + machine_id)
                                {
                                    //正在生產中
                                    if (dt_machine.Rows[i]["prd_start_time"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() == "")
                                    {
                                        if (dt_machine.Rows[i]["prd_work_type"].ToString().Trim() == "A02")
                                            lab.Text = "生產中...";
                                        else
                                        {
                                            if (dt_machine.Rows[i]["prd_work_type"].ToString().Trim() == "A01")
                                                lab.Text = "校模中...";
                                        }
                                        lab.ForeColor = Color.Blue;
                                        break;
                                    }
                                    else
                                    {
                                        if (dt_machine.Rows[i]["prd_id"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_start_time"].ToString().Trim() == "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() == "")
                                        {
                                            lab.Text = "已安排,未開始。";
                                            lab.ForeColor = Color.Fuchsia;
                                            break;
                                        }
                                        else
                                        {
                                            if (dt_machine.Rows[i]["prd_start_time"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() != "")
                                            {
                                                lab.Text = "已完成,待機中。";
                                                lab.ForeColor = Color.Green;
                                                break;
                                            }
                                            else
                                            {
                                                //未安排生產
                                                if (dt_machine.Rows[i]["prd_id"].ToString().Trim() == "")
                                                {
                                                    lab.Text = "未安排。";
                                                    lab.ForeColor = Color.Orange;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "PictureBox":
                        {
                            PictureBox pic = (PictureBox)ct;
                            for (int i = 0; i < dt_machine.Rows.Count; i++)
                            {
                                machine_id = (i + 1).ToString().Trim();//機器代號
                                if (pic.Name == "picIsStart" + machine_id)
                                {
                                    if (dt_machine.Rows[i]["prd_start_time"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() == "")
                                    {
                                        pic.Visible = true;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case "Button":
                        {
                            Button bt = (Button)ct;
                            for (int i = start_rec_id; i < dt_machine.Rows.Count; i++)
                            {
                                machine_id = ((i % page_no) + 1).ToString().Trim();//機器代號
                                //bt.ForeColor = Color.Red;
                                if (bt.Name == "cmdMach" + machine_id)
                                {
                                    bt.Text = "";//dt_machine.Rows[i]["machine_id"].ToString().Trim();
                                    //正在生產中
                                    if (dt_machine.Rows[i]["prd_start_time"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() == "")
                                    {
                                        bt.ForeColor = Color.Blue;
                                        bt.Image = Image.FromFile(imagePath + @"Images\ma_run.gif");
                                        if (dt_machine.Rows[i]["prd_work_type"].ToString().Trim() == "A01")//校模的圖標
                                            bt.Image = Image.FromFile(imagePath + @"Images\ma_run_jm.gif");
                                        break;
                                    }
                                    //已安排生產，未開始
                                    if (dt_machine.Rows[i]["prd_id"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_start_time"].ToString().Trim() == "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() == "")
                                    {
                                        bt.ForeColor = Color.Fuchsia;
                                        bt.Image = Image.FromFile(imagePath + @"Images\ma_fuchsia.jpg");
                                        break;
                                    }
                                    //已完成，待機中
                                    if (dt_machine.Rows[i]["prd_start_time"].ToString().Trim() != "" && dt_machine.Rows[i]["prd_end_time"].ToString().Trim() != "")
                                    {
                                        bt.ForeColor = Color.Green;
                                        bt.Image = Image.FromFile(imagePath + @"Images\ma_green.jpg");
                                        break;
                                    }
                                    //未安排生產
                                    if (dt_machine.Rows[i]["prd_id"].ToString().Trim() == "")
                                    {
                                        bt.ForeColor = Color.Orange;
                                        bt.Image = Image.FromFile(imagePath + @"Images\ma_orange.jpg");//jiaomo3.png
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void ClearMachineStatus()
        {
            foreach (Control ct in this.splitContainer1.Panel2.Controls)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip":
                        {
                            break;
                        }
                    case "Label":
                        {
                            Label lab = (Label)ct;
                            if (lab.Name.Trim().Length > 14 && lab.Name.Substring(0, 14) == "lblMachineName")
                            {
                                lab.Text = "";
                                break;
                            }
                            if (lab.Name.Trim().Length > 5 && lab.Name.Substring(0, 5) == "lblMo")
                            {
                                lab.Text = "";
                                break;
                            }
                            if (lab.Name.Trim().Length > 9 && lab.Name.Substring(0, 9) == "lblStatus")
                            {
                                lab.Text = "";
                                break;
                            }
                            break;
                        }
                    case "PictureBox":
                        {
                            PictureBox pic = (PictureBox)ct;
                            if (pic.Name.Trim().Length > 10 && pic.Name.Substring(0, 10) == "picIsStart")
                            {
                                pic.Visible = true;
                                break;
                            }
                            break;
                        }
                    case "Button":
                        {
                            Button bt = (Button)ct;
                            if (bt.Name.Trim().Length > 7 && bt.Name.Substring(0, 7) == "cmdMach")
                            {
                                bt.Text = "";
                                bt.ForeColor = Color.Black;
                                bt.Image = null;
                                break;
                            }
                            break;
                        }
                }
            }
        }
        private void ShowMachinePrd(string machine_id)
        {
            //for (int i = 0; i < dt_machine.Rows.Count; i++)
            //{
            //    if (machine_id.Trim() == dt_machine.Rows[i]["machine_id"].ToString().Trim())
            //    {
            //        lbldMachineId.Text = machine_id.Trim();
            //        lbldMachineName.Text = dt_machine.Rows[i]["machine_desc"].ToString().Trim();
            //        lbldMachineStatus.Text = "";
            //        lbldWorkType.Text = dt_machine.Rows[i]["work_type_desc"].ToString().Trim();
            //        lbldMo.Text = dt_machine.Rows[i]["prd_mo"].ToString().Trim();
            //        lbldPrdDate.Text = dt_machine.Rows[i]["prd_date"].ToString().Trim();
            //        lbldStartTime.Text = dt_machine.Rows[i]["prd_start_time"].ToString().Trim();
            //        lbldReqTime.Text =  "";
            //        lbldEndTime.Text =dt_machine.Rows[i]["prd_end_time"].ToString().Trim();
            //        lbldPrdQty.Text = dt_machine.Rows[i]["prd_qty"].ToString().Trim();
            //    }
            //}
            //panelShowInf.Visible = true;
            txtMachine_id.Text = "";
            txtMachine_desc.Text = "";
            DataTable bdt = new DataTable();
            bdt = clsProductionSchedule.GetPrdMachineStatus1(2, txtDep.Text.Trim(), txtWorkShop.Text.Trim(), txtWorkShopArea.Text.Trim(), machine_id);
            dgvDetails.DataSource = bdt;

            ////以下是用更新表的方式
            //if (bdt.Rows.Count > 0)
            //{
            //    txtMachine_id.Text = bdt.Rows[0]["prd_machine"].ToString();
            //    txtMachine_desc.Text = bdt.Rows[0]["machine_desc"].ToString();
            //    txthour_std_qty.Text = bdt.Rows[0]["hour_std_qty"].ToString();
            //    count_req_time(bdt);
            //}
            //以下是用更新View的方式
            if (dgvDetails.RowCount > 0)
            {
                txtMachine_id.Text = dgvDetails.Rows[0].Cells["colPrd_machine"].Value.ToString();
                txtMachine_desc.Text = dgvDetails.Rows[0].Cells["colMachine_desc"].Value.ToString();
                txtLine_num.Text = dgvDetails.Rows[0].Cells["colLine_num"].Value.ToString();
                txtHour_run_num.Text = dgvDetails.Rows[0].Cells["colHour_run_num"].Value.ToString();
                txtHour_std_qty.Text = dgvDetails.Rows[0].Cells["colHour_std_qty"].Value.ToString();
                txtHour_std_qty.Text = (Convert.ToInt32(txtHour_run_num.Text) * Convert.ToInt32(txtLine_num.Text)).ToString();
                getArtPicture(0);//獲取ArtWork圖片
                count_req_time();
            }

            panelShowMachineMo.Visible = true;
        }
        //預計完成時間
        private void count_req_time()
        {
            double hour_num = 0;
            //string am_start_time = "08:30";
            //string finish_work_noon1 = "12:30";//,finish_work_noon2="14:00";//中午下班時間 12:30~14:00
            //string finish_work_afternoon1 = "18:00";//, finish_work_afternoon2 = "19:00";//下午下班時間 18:00~19:00
            //string finish_work_time;
            string prd_date;
            string start_time;
            string end_time;
            float hour_std_qty;
            float prd_qty;
            float total_qty=0;
            DateTime new_start_time;
            hour_std_qty = Convert.ToInt32(txtHour_std_qty.Text.ToString());
            prd_date = dgvDetails.Rows[0].Cells["colPrd_date"].Value.ToString(); 
            start_time = dgvDetails.Rows[0].Cells["colPrd_start_time"].Value.ToString();
            if (prd_date == "" || prd_date.Length !=10 || prd_date.IndexOf("/") ==-1)
                prd_date = System.DateTime.Now.ToString("yyyy/MM/dd");//如果沒有開始日期，則從當前日期開始
            if (start_time.Trim() == "")
                start_time = "08:30";//如果沒有開始時間，則從每天開始上班時間開始
            new_start_time = Convert.ToDateTime(prd_date + " " + start_time);
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["colPrd_qty"].Value != null && dgvDetails.Rows[i].Cells["colPrd_qty"].Value.ToString() != "")
                    prd_qty = Convert.ToInt32(dgvDetails.Rows[i].Cells["colPrd_qty"].Value.ToString());
                else
                    prd_qty = 0;
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
                    dgvDetails.Rows[i].Cells["colPrd_req_time"].Value = end_time;
                    //tdt.Rows[i]["prd_about_time"] = hour_num.ToString();
                    dgvDetails.Rows[i].Cells["colPrd_about_time"].Value = hour_num.ToString();
                    new_start_time = Convert.ToDateTime(end_time);
                }
                total_qty = total_qty+prd_qty;
            }
            //統計合共生產數及生產時間
            txtTotalQty.Text = total_qty.ToString();
            txtTotalTime.Text = "";
            if(hour_std_qty != 0)
                txtTotalTime.Text = Math.Round(total_qty / hour_std_qty, 3).ToString();
        }
        private void btnCountTime_Click(object sender, EventArgs e)
        {
            count_req_time();//重新計算預計完成時間
        }
        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getArtPicture(dgvDetails.CurrentCell.RowIndex);
        }
        private void getArtPicture(int rowNo)
        {
            picArtWork.Image = null;
            string picPath = "1";
            DataTable dtArt = clsMo_for_jx.GetGoods_ArtWork(dgvDetails.Rows[rowNo].Cells["colGoods_id"].Value.ToString());
            picPath = dtArt.Rows[0]["picture_name"].ToString();
            if (picPath.Trim() != "")
                if (File.Exists(DBUtility.imagePath + picPath.Trim()))
                    picArtWork.Image = Image.FromFile(DBUtility.imagePath + picPath);
        }
        private void cmdMach1_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName1.Text);
        }


        private void cmdMach2_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName2.Text);
        }

        private void cmdMach3_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName3.Text);
        }

        private void cmdMach4_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName4.Text);
        }

        private void cmdMach5_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName5.Text);
        }

        private void cmdMach6_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName6.Text);
        }

        private void cmdMach7_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName7.Text);
        }

        private void cmdMach8_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName8.Text);
        }

        private void cmdMach9_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName9.Text);
        }

        private void cmdMach10_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName10.Text);
        }

        private void cmdMach11_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName11.Text);
        }

        private void cmdMach12_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName12.Text);
        }

        private void cmdMach13_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName13.Text);
        }

        private void cmdMach14_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName14.Text);
        }

        private void cmdMach15_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName15.Text);
        }

        private void cmdMach16_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName16.Text);
        }

        private void cmdMach17_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName17.Text);
        }

        private void cmdMach18_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName18.Text);
        }

        private void cmdMach19_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName19.Text);
        }

        private void cmdMach20_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName20.Text);
        }

        private void cmdMach21_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName21.Text);
        }

        private void cmdMach22_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName22.Text);
        }

        private void cmdMach23_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName23.Text);
        }

        private void cmdMach24_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName24.Text);
        }

        private void cmdMach25_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName25.Text);
        }

        private void cmdMach26_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName26.Text);
        }

        private void cmdMach27_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName27.Text);
        }

        private void cmdMach28_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName28.Text);
        }

        private void cmdMach29_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName29.Text);
        }

        private void cmdMach30_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName30.Text);
        }

        private void cmdMach31_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName31.Text);
        }

        private void cmdMach32_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName32.Text);
        }

        private void frmMachineStatus1_Load(object sender, EventArgs e)
        {
            dgvArea.AutoGenerateColumns = false;
            initControlBox();
            txtDep.Text = strPrd_dep;
            ClearMachineStatus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelShowMachineMo.Visible = false;
        }

        private void cmdMach33_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName33.Text);
        }

        private void cmdMach34_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName34.Text);
        }

        private void cmdMach35_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName35.Text);
        }

        private void cmdMach36_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName36.Text);
        }

        private void cmdMach37_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName37.Text);
        }

        private void cmdMach38_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName38.Text);
        }

        private void cmdMach39_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName39.Text);
        }

        private void cmdMach40_Click(object sender, EventArgs e)
        {
            ShowMachinePrd(lblMachineName40.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            showPicture(5);
            this.Close();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            step_id = 0;
            start_rec_id = (step_id * page_no);
            ShowMachineStatus(start_rec_id);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            step_id = step_id - 1;
            if (step_id < 0)
                step_id = 0;
            start_rec_id = (step_id * page_no);
            ClearMachineStatus();
            ShowMachineStatus(start_rec_id);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            step_id = step_id + 1;
            start_rec_id = (step_id * page_no);
            if (start_rec_id > dt_machine.Rows.Count)
            {
                step_id = (dt_machine.Rows.Count / page_no);
                start_rec_id = (step_id * page_no);
            }
            ClearMachineStatus();
            ShowMachineStatus(start_rec_id);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            step_id = (dt_machine.Rows.Count / page_no);
            start_rec_id = (step_id * page_no);
            ClearMachineStatus();
            ShowMachineStatus(start_rec_id);
        }

        private void cmbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select_index=cmbDep.SelectedIndex;
            string dep="",workshop="";
            if (select_index == 0)
            {
                dep = "302";
                workshop = "302";
            }
            else
            {
                if (select_index == 1)
                {
                    dep = "102";
                    workshop = "102";
                }
                else
                {
                    if (select_index == 2)
                    {
                        dep = "102";
                        workshop = "103";
                    }
                    else
                    {
                        if (select_index == 3)
                        {
                            dep = "105";
                            workshop = "105";
                        }
                        else
                        {
                            if (select_index == 4)
                            {
                                dep = "202";
                                workshop = "202";
                            }
                            else
                            {
                                if (select_index == 5)
                                {
                                    dep = "203";
                                    workshop = "203";
                                }
                            }
                        }
                    }
                }
            }
            txtDep.Text = dep;
            txtWorkShop.Text = workshop;
            ShowWorkShopArea();//提取車間工作區
        }
        //提取車間工作區
        private void ShowWorkShopArea()
        {
            DataTable dtArea = new DataTable();
            dtArea = clsProductionSchedule.LoadWorkShopArea(txtDep.Text.Trim(),txtWorkShop.Text.Trim());
            dgvArea.DataSource = dtArea;
            if(dgvArea.Rows.Count>0)
                txtWorkShopArea.Text = dgvArea.Rows[0].Cells["colAreaId"].Value.ToString();
            FindData();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FindData();
        }
        //查找記錄
        private void FindData()
        {
            //LoadMachineStatus();
            if (cmbDep.Text == "")
            {
                MessageBox.Show("請輸入部門!");
                return;
            }
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            dt_machine = clsProductionSchedule.GetPrdMachineStatus1(1, txtDep.Text.Trim(), txtWorkShop.Text.Trim(), txtWorkShopArea.Text.Trim(), "");
            ClearMachineStatus();
            ShowMachineStatus(0);
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
        }
        private void btnEnableTime_Click(object sender, EventArgs e)
        {
            if (btnEnableTime.Text == "開啟自動刷新")
            {
                btnEnableTime.Text = "關閉自動刷新";
                timRefresh.Enabled = true;
            }
            else
            {
                btnEnableTime.Text = "開啟自動刷新";
                timRefresh.Enabled = false;
            }
        }

        private void timRefresh_Tick(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            showPicture(4);
        }

        private void timShowPic_Tick(object sender, EventArgs e)
        {
            showPicture(3);
        }

        private void btnShowImage_Click(object sender, EventArgs e)
        {
            if (btnShowImage.Text == "開啟宣傳畫面")
            {
                btnShowImage.Text = "關閉宣傳畫面";
                showPicture(7);
            }
            else
            {
                btnShowImage.Text = "開啟宣傳畫面";
                showPicture(5);
            }
        }

        private void timHidePic_Tick(object sender, EventArgs e)
        {
            showPicture(6);
        }

        private void timCf00_Tick(object sender, EventArgs e)
        {
            
            showPicture(0);
        }

        private void timCf01_Tick(object sender, EventArgs e)
        {
            showPicture(1);
        }

        private void timCf02_Tick(object sender, EventArgs e)
        {
            showPicture(2);
        }
        private void showPicture(int sel)
        {
            if (sel == 0)//顯示第1張
            {
                picShow.Image = Image.FromFile(imagePath + @"Images\broadcast01.jpg");
                timCf00.Enabled = false;
                timCf01.Enabled = true;
                timCf02.Enabled = false;
            }
            else
            {
                if (sel == 1)//顯示第2張
                {
                    picShow.Image = Image.FromFile(imagePath + @"Images\broadcast02.jpg");
                    timCf00.Enabled = false;
                    timCf01.Enabled = false;
                    timCf02.Enabled = true;
                }
                else
                {
                    if (sel == 2)//顯示第3張
                    {
                        picShow.Image = Image.FromFile(imagePath + @"Images\broadcast03.jpg");
                        timCf00.Enabled = true;
                        timCf01.Enabled = false;
                        timCf02.Enabled = false;
                    }
                    else
                    {
                        if (sel == 3)//開始顯示
                        {
                            timHidePic.Enabled = true;
                            splitContainer1.Visible = false;
                            picShow.Visible = true;
                            timCf00.Enabled = true;
                        }
                        else
                        {
                            if (sel == 4)//單擊圖片隱藏
                            {
                                splitContainer1.Visible = true;
                                picShow.Visible = false;
                                timHidePic.Enabled = false;
                                timCf00.Enabled = false;
                                timCf01.Enabled = false;
                                timCf02.Enabled = false;
                            }
                            else
                            {
                                if (sel == 5)//按鈕關閉宣傳畫面
                                {
                                    splitContainer1.Visible = true;
                                    picShow.Visible = false;
                                    timShowPic.Enabled = false;
                                    timHidePic.Enabled = false;
                                    timCf00.Enabled = false;
                                    timCf01.Enabled = false;
                                    timCf02.Enabled = false;
                                }
                                else
                                {
                                    if (sel == 6)//自動隱藏
                                    {
                                        splitContainer1.Visible = true;
                                        picShow.Visible = false;
                                        timHidePic.Enabled = false;
                                        timCf00.Enabled = false;
                                        timCf01.Enabled = false;
                                        timCf02.Enabled = false;
                                        //picShow.Image = Image.FromFile(imagePath + @"Images\cf00.jpg");
                                    }
                                    else
                                    {
                                        if (sel == 7)//按鈕時開始顯示，只顯示一次，相當于初始化
                                        {
                                            picShow.Dock = DockStyle.Fill;
                                            timShowPic.Enabled = true;
                                            splitContainer1.Visible = false;
                                            picShow.Visible = true;
                                            timCf00.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private void dgvArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWorkShopArea.Text = dgvArea.CurrentRow.Cells["colAreaId"].Value.ToString();
            FindData();
        }
        

        
    }
}
