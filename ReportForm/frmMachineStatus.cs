using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Reflection;
using cf01.MDL;
using cf01.CLS;//反射

namespace cf01.ReportForm
{
    public partial class frmMachineStatus : Form
    {
        DataTable dtPrd_dept = new DataTable();
        DataTable dtWork_type = new DataTable();
      public static List<product_records> lsPms = new List<product_records>();

        private int TotalPages = 0;  //總頁數
        private const int PageSize = 48; //每頁顯示條數
        private int PageIndex = 1;    //當前頁數


        public frmMachineStatus()
        {
            InitializeComponent();

            GetAllComboxData();
        }

        //獲取生產部門、工作類型
        private void GetAllComboxData()
        {
            try
            {
                dtPrd_dept = clsProductionSchedule.GetAllPrd_dept();
                dtWork_type = clsProductionSchedule.GetWorkType();
                //增加查詢所有的工作狀態
                DataRow dr = dtWork_type.NewRow();
                dr["work_type_id"] = "0";
                dr["work_type_desc"] = "全部";
                dtWork_type.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitComBoxs()
        {
            //初始化生產部門
            cmbDept.DataSource = dtPrd_dept;
            cmbDept.DisplayMember = "int9loc";
            cmbDept.ValueMember = "int9loc";
            cmbDept.Text = "102";

            //初始化工作狀態
            cmbWorktype.DataSource = dtWork_type;
            cmbWorktype.DisplayMember = "work_type_desc";
            cmbWorktype.ValueMember = "work_type_id";

        }

        private void frmMachineStatus_Load(object sender, EventArgs e)
        {
            InitComBoxs();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if (cmbDept.Text == "")
            {
                MessageBox.Show("請選擇部門。");
                return;
            }
            if (cmbWorktype.Text == "")
            {
                MessageBox.Show("請選擇工作狀態。");
                return;
            }

            lsPms = clsProductionSchedule.GetPrdMachineStatus(cmbDept.SelectedValue.ToString(), cmbWorktype.SelectedValue.ToString(), PageSize);

            if (lsPms.Count > 0)
            {
                //計算總頁數
                if ((lsPms.Count % PageSize) == 0)
                {
                    TotalPages = lsPms.Count / PageSize;
                }
                else
                {
                    TotalPages = (lsPms.Count / PageSize) + 1;
                }

                PageIndex = 1;
                AutoGenerateControl();

                btnNext.Enabled = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //todo:上一頁
            PageIndex = PageIndex - 1;
            AutoGenerateControl();
            if (PageIndex == 1)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //todo:下一頁
            btnPrevious.Enabled = true;
            PageIndex = PageIndex + 1;
            AutoGenerateControl();
            if (PageIndex == TotalPages)
            {
                btnNext.Enabled = false;
                return;
            }
        }

        /// <summary>
        /// 動態創建PictureBox、label
        /// </summary>
        private void AutoGenerateControl()
        {
            this.panel1.Controls.Clear();
            Point picboxPoint = new System.Drawing.Point(10, 0);
            Point lblPoint = new System.Drawing.Point(10, 73);
            int index = 0;

            for (int i = 0; i < lsPms.Count; i++)
            {
                if (lsPms[i].pageIndex == PageIndex)
                {
                    StringBuilder myString = new StringBuilder("");
                    myString.Append(lsPms[i].prd_machine.Trim());
                    myString.Append(String.Format("\n{0}", lsPms[i].machine_desc.Trim()));

                    PictureBox picbox = new PictureBox();
                    picbox.Size = new System.Drawing.Size(66, 70);
                    picbox.Tag = lsPms[i].prd_id;
                    picbox.Location = CalculatePosition(picboxPoint, index);
                    picbox.Click += new EventHandler(picBox_Click);
                    string strDesc = "";
                    if (lsPms[i].prd_start_time != "" && lsPms[i].prd_end_time == "")   //未完成
                    {
                        if (lsPms[i].prd_work_type == "A01")
                        {
                            strDesc = "校模中...";
                            picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\jiaomo.gif");
                        }
                        if (lsPms[i].prd_work_type == "A02")
                        {
                            strDesc = "生產中...";
                            picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\produce.gif");
                        }
                        if (lsPms[i].prd_work_type == "A04")
                        {
                            strDesc = "維修中...";
                            // picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\fix.gif");
                        }

                        myString.Append(String.Format("\n{0}", strDesc));
                    }

                    if (lsPms[i].prd_start_time != "" && lsPms[i].prd_end_time != "") //完成
                    {
                        if (lsPms[i].prd_work_type == "A01")
                        {
                            strDesc = "校模完成...";
                            picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\Fjiaomo.png");
                        }
                        if (lsPms[i].prd_work_type == "A02")
                        {
                            strDesc = "生產完成...";
                            picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\Fproduce.png");
                        }
                        if (lsPms[i].prd_work_type == "A04")
                        {
                            strDesc = "維修完成...";
                            // picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\standby.gif");
                        }
                        myString.Append(String.Format("\n{0}", strDesc));
                    }

                    if (lsPms[i].prd_id == 0)  //待機中
                    {
                        strDesc = "待機中...";
                        picbox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\standby.gif");
                        myString.Append(String.Format("\n{0}", strDesc));
                    }

                    myString.Append(String.Format("\n{0}", lsPms[i].prd_mo.Trim()));

                    Label lblDesc = new Label();
                    lblDesc.TextAlign = ContentAlignment.TopLeft;
                    lblDesc.Text = myString.ToString();
                    lblDesc.Size = new System.Drawing.Size(89, 48);
                    lblDesc.Location = CalculatePosition(lblPoint, index);

                    this.panel1.Controls.Add(picbox);
                    this.panel1.Controls.Add(lblDesc);

                    index++;
                }
            }
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            string prd_id = (sender as PictureBox).Tag.ToString();
            if (prd_id != "0")
            {
                frmMachineStatusDetail frmMSD = new frmMachineStatusDetail(prd_id);
                frmMSD.ShowDialog();
            }
        }

        private Point CalculatePosition(Point pBasePoint, int pIndex)
        {
            return new Point(pBasePoint.X + 120 * (pIndex % 12), pBasePoint.Y + 150 * (pIndex / 12));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assembly asb = Assembly.GetExecutingAssembly();//得到当前的程序集
            Label f = (Label)asb.CreateInstance("label1");//利用反射，根据数据库中的字段值创建窗体对象
            f.Text = "OK";
        }


    }
}
