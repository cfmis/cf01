/*
 * Create Date:2016-05-05
 * Create by Allen Leung
 * 程序備註：
 * 1、從產品定價中查找頁面中查找出符合條件的記錄生成報給客戶的報價單
 * 2、也可從產品定價資料錄入中選中所需記錄，點【生成報價單】跳至此畫面生成報價單
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using cf01.CLS;
using DevExpress.XtraEditors;
using System.IO;
using cf01.Reports;
using cf01.MDL;
using System.Xml;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using DevExpress.XtraReports.UI;

namespace cf01.Forms
{
    public partial class frmQuotation_Report : Form
    {
        public string mID = "";    //臨時的主鍵值id
        public string mVersion = "";//臨時的主鍵值version
        private string mDel_ID = "";
        public string temp_state = "";
        public string mState = ""; //新增或編輯的狀態
        public static string str_language = "0";
        public string msgCustom;
        public string mImagePath = "";
        public bool save_flag;
        public string strArea = "";
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtQuotation_mostly = new DataTable();
        DataTable dtQuotation_details = new DataTable();
        DataTable dtTempDel = new DataTable();
        DataTable dtTerm1 = new DataTable();
        DataTable dtAddress1 = new DataTable();
        DataTable dtFind = new DataTable();
        DataTable dtReport = new DataTable();        
        public static DataSet dsCopy = new DataSet();
        public List<mdlQuotation_Reprot> mList = new List<mdlQuotation_Reprot>();

        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeout(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);


        public frmQuotation_Report()
        {
            InitializeComponent();
            //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
            //control.GenerateContorl();
            //clsApp.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
            

            clsApp.Initialize_find_value(this.Name, panel1.Controls);//定價查找頁面條件初始化
            clsApp.Initialize_find_value("frmQuotation_Report_browse", tabControl1.TabPages[1].Controls);//報價資料查找頁面條件初始化
            gridView1.IndicatorWidth = 40;
            //str_language = DBUtility._language;
            //NextControl oNext = new NextControl(this, "1");
            //oNext.EnterToTab();
        }

        private void frmQuotation_Report_Load(object sender, EventArgs e)
        {
            //圖樣起止路徑
            //mImagePath = mImagePath.Replace("\\Artwork\\","");
            string ls_ip_address = clsApp.GetLocalIP();
            if (ls_ip_address.Contains("192.168.3."))
            {
                mImagePath = @"\\192.168.3.12\cf_artwork";
            }
            if (ls_ip_address.Contains("192.168.168."))
            {
                mImagePath = @"\\192.168.168.15\cf_artwork";
            }
            if (ls_ip_address.Contains("192.168.18."))
            {
                mImagePath = @"\\192.168.18.24\cf_artwork";
            }            

            //單據前綴
            strArea = clsPublicOfCF01.ExecuteSqlReturnObject("SELECT @@SERVERNAME");
            strArea = strArea.Substring(0, 2);
            if (strArea == "DG")
            {
                strArea = "QD";//DG輸入
            }
            else
            {
                strArea = "QH"; //HK輸入
            }
            //客戶資料           
            string strSql = string.Format(
            @"SELECT '' AS id,'' AS cdesc,'' AS desc_e,'' as money_id,'' AS contact,'' AS tel,'' AS fax,'' AS email
            UNION
            SELECT A.id,A.name as cdesc ,A.english_name as desc_e,ISNULL(A.money_id,'') as money_id,ISNULL(B.linkman,'') AS contact,
	            ISNULL(B.phone,'') AS tel,ISNULL(B.fax,'') AS fax,ISNULL(B.email,'') AS email
            FROM {0}it_customer A with(nolock),{0}it_shipment_address B with(nolock)
            WHERE A.within_code=B.within_code and A.id=B.id AND A.within_code='0000' AND A.state<>'2' 
            ORDER BY A.id", DBUtility.remote_db);
            DataTable dtCust = new DataTable();
            dtCust = clsPublicOfCF01.GetDataTable(strSql);
            txtCustomer_id.Properties.DataSource = dtCust;
            txtCustomer_id.Properties.ValueMember = "id";
            txtCustomer_id.Properties.DisplayMember = "id";

            //生成gridview1明細表結構
            dtQuotation_details = clsPublicOfCF01.GetDataTable(@"SELECT a.*,b.name as name_brand FROM quotation_details a,v_brand_customer b  WHERE 1=0");
            gridControl1.DataSource = dtQuotation_details;
            
            //臨時項目刪除表結構
            dtTempDel = dtQuotation_details.Clone();
            
            DataTable dtAddress = new DataTable();
            dtAddress = clsPublicOfCF01.GetDataTable("SELECT id,Convert(varchar(5),id)+'['+area+']' as cdesc FROM dbo.quotation_address GROUP BY id,area ORDER BY id,area");
            txtAddress_id.Properties.DataSource = dtAddress;
            txtAddress_id.Properties.ValueMember = "id";
            txtAddress_id.Properties.DisplayMember = "cdesc";
            dtAddress1 = clsPublicOfCF01.GetDataTable("select id,item from dbo.quotation_address order by id,seq");

            DataTable dtTerm = new DataTable();
            dtTerm = clsPublicOfCF01.GetDataTable("SELECT id FROM dbo.quotation_term GROUP BY id ORDER BY id");
            txtTerm_id.Properties.DataSource = dtTerm;
            txtTerm_id.Properties.ValueMember = "id";
            txtTerm_id.Properties.DisplayMember = "id";
            dtTerm1 = clsPublicOfCF01.GetDataTable("SELECT id,item FROM dbo.quotation_term ORDER BY id,seq");
            //tabPage3.Parent = null;
            tabControl1.SelectTab(2);
            chkSelectAll.Checked = false;

            for (int i = 1; i < dgvDetails.ColumnCount; i++)
            {
                dgvDetails.Columns[i].ReadOnly = true;
            }
            if (BTNSAVE_PRICE.Enabled)
            {
                dgvDetails.Columns[24].ReadOnly = false;
                dgvDetails.Columns[25].ReadOnly = false;
                dgvDetails.Columns[26].ReadOnly = false;
            }
            else
            {
                dgvDetails.Columns[24].ReadOnly = true;
                dgvDetails.Columns[25].ReadOnly = true;
                dgvDetails.Columns[26].ReadOnly = true;
            }
            
                //BTNSAVE_PRICE.Enabled;// false;//設置Price_salesperson為可編輯

            using (DataTable dtSales_Group = clsPublicOfCF01.GetDataTable(@"Select typ_code AS id From bs_type Where typ_group='3'"))
            {
                for (int i = 0; i < dtSales_Group.Rows.Count; i++)
                {
                    txtSales_group.Items.Add(dtSales_Group.Rows[i][0].ToString());
                }

            }

            System.Data.DataTable dtUnit = new System.Data.DataTable();
            dtUnit = clsPublicOfCF01.GetDataTable(@"SELECT '' AS id Union SELECT unit_id as id FROM dbo.bs_unit Where unit_id<>'000'");
            clPrice_unit.DataSource = dtUnit;
            clPrice_unit.ValueMember = "id";
            clPrice_unit.DisplayMember = "id";

            System.Data.DataTable dtCny = new System.Data.DataTable();
            dtCny = clsConErp.GetDataTable("SELECT id,name as cdesc From cd_money Where state='0'");
            txtMoney_id.Properties.DataSource = dtCny;
            txtMoney_id.Properties.ValueMember = "id";
            txtMoney_id.Properties.DisplayMember = "id";


            //顯示PDD備註
            clsQuotation.IsDisplayRemark_PDD(dgvDetails, remark_pdd);

            //從定價資料中生成報價單
            if (mList.Count > 0)
            {
                Add_From_Master();
                tabControl1.SelectTab(0);
            }

            //設置選擇報表格式
            System.Data.DataTable dtReportFormat = new System.Data.DataTable();
            //可以通用戶控制只可以看哪幾種報表
            //strSql = string.Format("Select A.report_id as id,B.typ_cdesc as cdesc FROM dbo.quotation_report A,bs_type B WHERE A.user_id='{0}' AND A.report_id=B.typ_code AND B.typ_group='AA'", DBUtility._user_id);
            strSql ="Select typ_code as id,typ_cdesc as cdesc From bs_type Where typ_group ='AA'";
            dtReportFormat = clsPublicOfCF01.GetDataTable(strSql);
            txtReportFormat.Properties.DataSource = dtReportFormat;
            txtReportFormat.Properties.ValueMember = "id";
            txtReportFormat.Properties.DisplayMember = "cdesc";
            if (dtReportFormat.Rows.Count > 0)
            {
                txtReportFormat.EditValue = dtReportFormat.Rows[0]["id"].ToString();
            }

            //初始化數據瀏覽頁數據源dtReport
            strSql = string.Format(
           @"SELECT A.id as id_h,A.version,Convert(char(10),A.quota_date,120) as quota_date_h,A.customer_id,A.address_id,A.term_id,A.remark as remark_h,A.id_referred,
            dbo.fn_getTermRemark(A.term_id,A.valid_date,'0') as terms,dbo.fn_getAddress(A.address_id) as address,Convert(char(10),A.valid_date) as valid_date,A.money_id,A.contact as contact_h,A.tel,A.fax,A.email,
            A.isusd,A.ishkd,A.isrmb,B.seq_id,B.brand,B.division,B.contact,B.material,B.size,B.product_desc,B.cust_code,
            B.cf_code,B.cust_color,B.cf_color,B.price_usd,B.price_hkd,B.price_rmb,B.moq,B.price_unit,B.remark,ISNULL(C.name,'') AS name_customer,SS.name AS name_brand,
            B.moq_unit,B.season,B.salesman,B.mwq,B.lead_time_min,B.lead_time_max,B.lead_time_unit,B.md_charge,B.md_charge_cny, B.number_enter,B.sales_group,
            B.hkd_ex_fty,B.usd_ex_fty,B.usd_dap,B.usd_lab_test_prx,B.ex_fty_hkd,B.ex_fty_usd,B.moq_for_test,
            B.discount,B.disc_price_usd,B.disc_price_hkd,B.disc_price_rmb,B.disc_hkd_ex_fty,B.actual_price,B.actual_price_type,B.die_mould_usd,B.die_mould_usd,B.die_mould_cny,  
            CASE WHEN Isnull(D.polo_care,'')='' THEN '' ELSE dbo.fn_getPoloCare(D.polo_care) END AS polo_care,isnull(D.moq_desc,'') AS moqdesc,B.rmb_remark           
            FROM dbo.quotation_mostly A with(nolock)
                INNER JOIN dbo.quotation_details B with(nolock) ON A.id=B.id And A.version=B.version
                INNER JOIN dbo.quotation D with(nolock) ON B.temp_code=D.temp_code
                LEFT JOIN {0}it_customer C with(nolock) ON C.within_code='0000' and A.customer_id=C.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                LEFT JOIN v_brand_customer SS ON ISNULL(B.brand,'')=SS.id COLLATE Chinese_Taiwan_Stroke_CI_AS
            WHERE 1=0 ", DBUtility.remote_db);
            //B.number_enter AS ex_fty_hkd,Round(Convert(float,Isnull(B.number_enter,0)/7.8),2) AS ex_fty_usd,
            dtReport = clsPublicOfCF01.GetDataTable(strSql);

            //DataGridViewComboBoxColumn cmbox = dgvDetails.Columns["price_kind"] as DataGridViewComboBoxColumn ;  
            //List<string> list_price=new List<string>();
            //list_price.Add("EX-FTY");
            //list_price.Add("FOB HK");
            //list_price.Add("USD");
            //list_price.Add("HKD");
            //list_price.Add("RMB");
            //cmbox.DataSource =list_price; //下框的数据源
            //cmbox.DataPropertyName= "price_kind";//datagrid的数据源的要绑定的列；  
            //cmbox.DisplayMember="price_kind";//下拉框显示的TEXT";  
            //cmbox.ValueMember="price_kind";//"隐藏的值"； 
            //this.dgvDetails.Columns.Add(cmbox);

            dgvDetails.AutoGenerateColumns = false;
            chkHidenCancel.Checked = true;

        }


        private static string Get_Remark(DataTable dt, string strid)
        {
            int id = Int32.Parse(strid);
            string strResult = "";
            DataRow[] arryDr = dt.Select(string.Format("id={0}", id));
            for (int i = 0; i < arryDr.Length; i++)
            {
                strResult = strResult + arryDr[i]["item"] + "\r\n";
            }
            return strResult;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();//刪除主檔資料
        }

        private void BTNITEMADD_Click(object sender, EventArgs e)
        {
            AddNew_Item();
        }

        private void BTNITEMDEL_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int curRow = gridView1.FocusedRowHandle;
                string seq_id_del;
                //將當前行刪除幷加到臨時表中
                DataRow dr = dtTempDel.NewRow();
                dr["id"] = txtID.Text;
                dr["version"] = txtVersion.Text;
                dr["seq_id"] = gridView1.GetRowCellDisplayText(curRow, "seq_id");
                seq_id_del = gridView1.GetRowCellDisplayText(curRow, "seq_id");
                dtTempDel.Rows.Add(dr);
                gridView1.DeleteRow(curRow);//移走當前行

                //移走查找面頁中的行
                for (int i = dgvFind.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgvFind.Rows[i].Cells["quotaion_id"].Value.ToString() == txtID.Text &&
                        dgvFind.Rows[i].Cells["version_h"].Value.ToString() == txtVersion.Text && 
                        dgvFind.Rows[i].Cells["seqno"].Value.ToString() == seq_id_del)
                    {
                        dtReport.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtID.Focus();//Toolscript焦點問題
            //gridView1.CloseEditor();
            Save_New();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            if (mState == "" && !string.IsNullOrEmpty(txtID.Text))
            {
                get_print_data();
                //Load_Data();//只列印當前報價單
                //if (dgvFind.RowCount > 0)
                //{
                //    Print();
                //}
            }
            else
            {
                MessageBox.Show("請先查詢出報價單數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        public void AddNew()  //新增
        {
            tabControl1.SelectTab(0);
            mState = "NEW";
            txtID.Focus();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            Set_Grid_Status(true);

            btnCopy.Enabled = true;
            GetDocNo();
            txtVersion.Text = "0";
            txtDate.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtValid_date.EditValue = txtDate.DateTime.AddDays(30).ToString("yyyy-MM-dd");
            txtAddress_id.EditValue = 0;
            txtTerm_id.EditValue = 0;
            txtMoney_id.EditValue = "HKD";

            txtID.Properties.ReadOnly = true;

            memRemark.Properties.ReadOnly = true;
            memRemark.BackColor = Color.LightGray;

            DataRow dr = dtQuotation_mostly.NewRow(); //插一空行
            dtQuotation_mostly.Rows.InsertAt(dr, 0);

            dtQuotation_details.Clear();
            gridControl1.DataSource = dtQuotation_details;

        }

        private void Add_From_Master()
        {
            if (mList.Count > 0)
            {
                GetDocNo();
                txtAddress_id.EditValue = 1;
                txtTerm_id.EditValue = 0;
                txtMoney_id.EditValue = "HKD";
                chkHkd.Checked = true;

                foreach (mdlQuotation_Reprot stu in mList)
                {
                    gridView1.AddNewRow();//新增
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "brand", stu.brand);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "division", stu.division);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "contact", stu.contact);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "material", stu.material);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "size", stu.size);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "product_desc", stu.product_desc);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cust_code", stu.cust_code);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cf_code", stu.cf_code);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cust_color", stu.cust_color);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cf_color", stu.cf_color);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_usd", stu.price_usd);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_hkd", stu.price_hkd);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_rmb", stu.price_rmb);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "moq", stu.moq);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "price_unit", stu.price_unit);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "remark", stu.remark);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "temp_code", stu.temp_code);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ver", stu.ver);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "id2", txtID.Text);

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "moq_desc", stu.moq_desc);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "moq_unit",stu.moq_unit);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "season", stu.season);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "salesman", stu.salesman);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "mwq", stu.mwq);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "lead_time_min", stu.lead_time_min);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "lead_time_max", stu.lead_time_max);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "lead_time_unit", stu.lead_time_unit);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "md_charge", stu.md_charge);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "md_charge_cny", stu.md_charge_cny);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "number_enter", stu.number_enter);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "hkd_ex_fty", stu.hkd_ex_fty);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "usd_ex_fty", stu.usd_ex_fty);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "sales_group", stu.sales_group);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "moq_for_test", stu.moq_for_test);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "usd_dap", stu.usd_dap);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "usd_lab_test_prx", stu.usd_lab_test_prx);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ex_fty_hkd", stu.ex_fty_hkd);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "ex_fty_usd", stu.ex_fty_usd);

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "discount", stu.discount);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "disc_price_usd", stu.disc_price_usd);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "disc_price_hkd", stu.disc_price_hkd);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "disc_price_rmb", stu.disc_price_rmb);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "disc_hkd_ex_fty", stu.disc_hkd_ex_fty);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "die_mould_usd", stu.die_mould_usd);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "die_mould_cny", stu.die_mould_cny);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "rmb_remark", stu.rmb_remark);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "cust_artwork", stu.cust_artwork);
                }
                gridView1.AddNewRow();//因保存時不知何原因總少一行，故新增一行再移走，估計都是焦點問題
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                Set_Cell_Focus(gridView1);

            }
        }

        /// <summary>
        /// DEV gridView 某單元格的焦點
        /// </summary>
        /// <param name="objGridView"></param>
        private void Set_Cell_Focus(DevExpress.XtraGrid.Views.Grid.GridView objGridView)
        {
            ColumnView view = (ColumnView)objGridView;//初始單元格焦點          
            // view.FocusedRowHandle = 0;
            view.FocusedColumn = view.Columns["material"];
            view.Focus();
        }

        private void Edit()  //編輯
        {
            if (txtID.Text == "")
            {
                return;
            }
            if (gridView1.RowCount == 0)
            {
                return;
            }
            tabControl1.SelectTab(0);
            SetButtonSatus(false);

            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            Set_Grid_Status(true);
            mState = "EDIT";

            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
            memRemark.Properties.ReadOnly = true;
            memRemark.BackColor = Color.LightGray;
        }

        private void SetButtonSatus(bool _flag) //設置工具欄
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            //BTNFIND.Enabled = _flag;
            BTNNEWVER.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;
            BTNITEMADD.Enabled = !_flag;
            BTNITEMDEL.Enabled = !_flag;
            btnPrice.Enabled = !_flag;
            btnAddOther.Enabled = !_flag;

            //clsApp.SetToolBarEnable(this.Name, this.Controls);
            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }

        private void Set_Grid_Status(bool _flag) // 表格是否可編輯
        {
            //false--不可編輯;true--可以編輯
            gridView1.OptionsBehavior.Editable = _flag;
            //gridView2.OptionsBehavior.Editable = _flag; 
        }

        private void Delete() //刪除當前行
        {
            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtCustomer_id.Text))
            {
                return;
            }

            if (txtCrusr.Text != DBUtility._user_id)
            {
                if (DBUtility._user_id != "ADMIN")
                {
                    MessageBox.Show("注意：當前用戶無此操作權限!", "提示信息", MessageBoxButtons.OK);
                    return;
                }
            }

            if (MessageBox.Show("注意：此操作將刪除主表及明細資料,請謹慎進行此操作!", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                mDel_ID = txtID.Text.Trim();
                const string sql_del = @"DELETE FROM dbo.quotation_mostly WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);//舊的                
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;//刪除主檔
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", mDel_ID);
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit(); //數據提交           
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetObjValue.ClearObjValue(this.Controls, "1");
                        dtQuotation_details.Clear();
                    }
                    catch (Exception E)
                    {
                        myTrans.Rollback(); //數據回滾
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }
                myTrans.Dispose();

                //移走表格中已刪除的記錄
                //应该采用倒序循环刪除,因为正序删除时索引会发生变化
                for (int i = dgvFind.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgvFind.Rows[i].Cells["quotaion_id"].Value.ToString() == mDel_ID)
                    {
                        dtReport.Rows.RemoveAt(i);
                    }
                }
                mDel_ID = "";
            }
        }

        private void AddNew_Item()
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
            {
                chkSelectAll.Checked = false;
                tabPage3.Parent = tabControl1;
                tabControl1.SelectTab(2);
            }
            else
            {
                MessageBox.Show("報價單編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomer_id.Focus();
            }
        }

        private bool Check_Details_Valid() //檢查明細資料的有效性
        {
            //測試項目必須有輸入
            bool _flag = false;
            if (gridView1.RowCount > 0)
            {
                txtRemark.Focus();
                int curRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    curRow = gridView1.GetRowHandle(i);
                    if (String.IsNullOrEmpty(gridView1.GetRowCellDisplayText(curRow, "brand")))
                    {
                        _flag = true;
                        MessageBox.Show("牌子編號不可以爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ColumnView view1 = (ColumnView)gridView1;
                        view1.FocusedColumn = view1.Columns["brand"]; //設置單元格焦點                        
                        break;
                    }
                }
            }
            return _flag;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            Edit_Columns(true);

            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "2");
            Set_Grid_Status(false);

            dtTempDel.Clear();
            dtQuotation_details.Clear();
            gridControl1.DataSource = dtQuotation_details;

            mState = "";
            if (!String.IsNullOrEmpty(mID))
            {
               // Find_Data();
                Find_doc(mID,mVersion);
            }
            memRemark.Properties.ReadOnly = true;
            memRemark.BackColor = Color.LightGray;
            btnCopy.Enabled = false;
            //tabPage3.Parent = null;
            tabControl1.SelectTab(0);
            mList.Clear();

        }

        private void Find_doc(string temp_id,string pVer) //主檔非新增的情況下，保存或取消時重新查出資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                //主表
                string sql_h = String.Format(
                @"SELECT A.*,B.name as name_customer FROM dbo.quotation_mostly A with(nolock) 
                  LEFT JOIN {0}it_customer B with(nolock) ON B.within_code='0000' and A.customer_id=B.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                  WHERE A.id ='{1}' AND A.version='{2}'", DBUtility.remote_db, temp_id,pVer);
                //明細表
                string sql_d = String.Format(
                @"SELECT A.*,A.usd_ex_fty,B.name as name_brand 
                FROM dbo.quotation_details A with(nolock) 
                LEFT JOIN v_brand_customer B ON A.brand=B.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                WHERE A.id='{0}' And A.version='{1}'", temp_id, pVer);
                /*
                string sql_d = String.Format(
                @"SELECT A.*,Round(Convert(float,Isnull(A.number_enter,0)/7.8),2) AS usd_ex_fty,B.name as name_brand 
                FROM dbo.quotation_details A with(nolock) 
                LEFT JOIN v_brand_customer B ON A.brand=B.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                WHERE A.id='{0}' And A.version='{1}'", temp_id, pVer);*/

                dtQuotation_mostly = clsPublicOfCF01.GetDataTable(sql_h);
                if (dtQuotation_mostly.Rows.Count > 0)
                    Set_Master_Data(dtQuotation_mostly);
                else
                {
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    dtReport.Clear();
                    return;
                }
                dtQuotation_details.Clear();
                dtQuotation_details = clsPublicOfCF01.GetDataTable(sql_d);
                gridControl1.DataSource = dtQuotation_details;

                mID = txtID.Text; //保存臨時的ID
                mVersion = txtVersion.Text; //保存臨時的version
            }
        }

        #region  Save_New 保存新增 新的處理方法
        private void Save_New() //保存__新的處理方法
        {
            if (!Save_Before_Valid())
            {
                return;
            }
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("明細資料不可為空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            save_flag = false;
            //新增主表
            const string sql_insert =
                @"INSERT INTO dbo.quotation_mostly(id,version,quota_date,customer_id,term_id,address_id,remark,remark_other,crusr,crtim,id_referred,valid_date,money_id,tel,fax,email,contact,isusd,ishkd,isrmb)
					VALUES (@id,@version,@quota_date,@customer_id,@term_id,@address_id,@remark,@remark_other,@user_id,getdate(),@id_referred,@valid_date,@money_id,@tel,@fax,@email,@contact,@isusd,@ishkd,@isrmb)";
            //新增明細表
            const string sql_detail_insert =
                @"INSERT INTO dbo.quotation_details(id,version,seq_id,brand,division,contact,material,size,product_desc,cust_code,cf_code,
                    cust_color,cf_color,price_usd,price_hkd,price_rmb,moq,price_unit,remark,temp_code,ver,moq_desc,moq_unit,season,salesman,mwq,lead_time_min,lead_time_max,lead_time_unit,md_charge,md_charge_cny,moq_for_test,
                    number_enter,hkd_ex_fty,usd_ex_fty,sales_group,usd_dap,usd_lab_test_prx,ex_fty_hkd,ex_fty_usd,discount,disc_price_usd,disc_price_hkd,disc_price_rmb,disc_hkd_ex_fty,actual_price,actual_price_type,
                    die_mould_usd,die_mould_cny,rmb_remark,cust_artwork) 
					VALUES (@id,@version,@seq_id,@brand,@division,@contact,@material,@size,@product_desc,@cust_code,@cf_code,@cust_color,@cf_color,
                    @price_usd,@price_hkd,@price_rmb,@moq,@price_unit,@remark,@temp_code,@ver,@moq_desc,@moq_unit,
                    @season,@salesman,@mwq,@lead_time_min,@lead_time_max,@lead_time_unit,@md_charge,@md_charge_cny,@moq_for_test,@number_enter,@hkd_ex_fty,@usd_ex_fty,@sales_group,@usd_dap,@usd_lab_test_prx,@ex_fty_hkd,@ex_fty_usd,
                    @discount,@disc_price_usd,@disc_price_hkd,@disc_price_rmb,@disc_hkd_ex_fty,@actual_price,@actual_price_type,@die_mould_usd,@die_mould_cny,@rmb_remark,@cust_artwork)";
            //更新主表
            const string sql_update =
                @"UPDATE dbo.quotation_mostly
					SET quota_date=@quota_date,customer_id=@customer_id,term_id=@term_id,address_id=@address_id,remark=@remark,remark_other=@remark_other,amusr=@user_id,amtim=getdate(),
                        id_referred=@id_referred,valid_date=@valid_date,money_id=@money_id,tel=@tel,fax=@fax,email=@email,contact=@contact,isusd=@isusd,ishkd=@ishkd,isrmb=@isrmb 
					WHERE id=@id AND version=@version";
            //更新明細表
            const string sql_detail_update =
                @"UPDATE dbo.quotation_details 
					SET brand=@brand,division=@division,contact=@contact,material=@material,size=@size,product_desc=@product_desc,
                        cust_code=@cust_code,cf_code=@cf_code,cust_color=@cust_color,cf_color=@cf_color,price_usd=@price_usd,
                        price_hkd=@price_hkd,price_rmb=@price_rmb,moq=@moq,price_unit=@price_unit,remark=@remark,temp_code=@temp_code,ver=@ver,moq_desc=@moq_desc,moq_unit=@moq_unit,season=@season,salesman=@salesman,mwq=@mwq,
                        lead_time_min=@lead_time_min,lead_time_max=@lead_time_max,lead_time_unit=@lead_time_unit,md_charge=@md_charge,md_charge_cny=@md_charge_cny,moq_for_test=@moq_for_test,
                        number_enter=@number_enter,hkd_ex_fty=@hkd_ex_fty,usd_ex_fty=@usd_ex_fty,sales_group=@sales_group,
                        usd_dap=@usd_dap,usd_lab_test_prx=@usd_lab_test_prx,ex_fty_hkd=@ex_fty_hkd,ex_fty_usd=@ex_fty_usd,
                        discount=@discount,disc_price_usd=@disc_price_usd,disc_price_hkd=@disc_price_hkd,disc_price_rmb=@disc_price_rmb,disc_hkd_ex_fty=@disc_hkd_ex_fty,
                        actual_price=@actual_price,actual_price_type=@actual_price_type,die_mould_usd=@die_mould_usd,die_mould_cny=@die_mould_cny,rmb_remark=@rmb_remark,cust_artwork=@cust_artwork
					WHERE id=@id AND version=@version AND seq_id=@seq_id";
            const string sql_item_d = @"DELETE FROM dbo.quotation_details WHERE id=@id AND version=@version AND seq_id=@seq_id";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@version", txtVersion.Text.Trim());
                    myCommand.Parameters.AddWithValue("@quota_date", txtDate.EditValue);
                    myCommand.Parameters.AddWithValue("@customer_id", txtCustomer_id.EditValue);
                    myCommand.Parameters.AddWithValue("@term_id", txtTerm_id.EditValue);
                    myCommand.Parameters.AddWithValue("@address_id", txtAddress_id.EditValue);
                    myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
                    myCommand.Parameters.AddWithValue("@remark_other", txtRemark_other.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);
                    myCommand.Parameters.AddWithValue("@id_referred", txtId_referred.Text);
                    myCommand.Parameters.AddWithValue("@valid_date", txtValid_date.EditValue);
                    myCommand.Parameters.AddWithValue("@money_id", txtMoney_id.EditValue);
                    myCommand.Parameters.AddWithValue("@tel", txtTel.Text);
                    myCommand.Parameters.AddWithValue("@fax", txtFax.Text);
                    myCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    myCommand.Parameters.AddWithValue("@contact", txtContact.Text);
                    bool blChecked;
                    if (chkUsd.Checked)
                        blChecked = true;
                    else
                        blChecked = false;
                    myCommand.Parameters.AddWithValue("@isusd", blChecked);
                    if (chkHkd.Checked)
                        blChecked = true;
                    else
                        blChecked = false;
                    myCommand.Parameters.AddWithValue("@ishkd", blChecked);
                    if (chkRmb.Checked)
                        blChecked = true;
                    else
                        blChecked = false;
                    myCommand.Parameters.AddWithValue("@isrmb", blChecked);

                    if (mState == "NEW")
                    {
                        if (Valid_Doc())
                        {
                            //新增的報價編號已存在時重新取值
                            GetDocNo();
                        }
                        myCommand.CommandText = sql_insert;
                    }
                    else
                        myCommand.CommandText = sql_update;

                    myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    myCommand.ExecuteNonQuery();


                    //處理明細表
                    //刪除明細資料
                    if (mState == "EDIT")
                    {
                        
                        for (int i = 0; i < dtTempDel.Rows.Count; i++)
                        {
                            myCommand.CommandText = sql_item_d;
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                            myCommand.Parameters.AddWithValue("@version", txtVersion.Text.Trim());
                            myCommand.Parameters.AddWithValue("@seq_id", dtTempDel.Rows[i]["seq_id"].ToString());
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    //保存或新增明細資料
                    if (gridView1.RowCount > 0)
                    {
                        string strSeq_id = "";
                        string rowStatus;
                        for (int i = 0; i < dtQuotation_details.Rows.Count; i++)
                        {
                            rowStatus = dtQuotation_details.Rows[i].RowState.ToString();
                            if (rowStatus == "Added" || rowStatus == "Modified")
                            {
                                myCommand.Parameters.Clear();
                                if (rowStatus == "Added")
                                {
                                    myCommand.CommandText = sql_detail_insert;
                                    strSeq_id = Get_Details_Seq(txtID.Text.Trim(),txtVersion.Text.Trim()); //新增狀態重新取最大序號
                                    //insert
                                }
                                if (rowStatus == "Modified")
                                {
                                    myCommand.CommandText = sql_detail_update;
                                    strSeq_id = dtQuotation_details.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變
                                }
                                myCommand.Parameters.AddWithValue("@id", txtID.Text.Trim());
                                myCommand.Parameters.AddWithValue("@version", txtVersion.Text.Trim());
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@brand", dtQuotation_details.Rows[i]["brand"].ToString());
                                myCommand.Parameters.AddWithValue("@division", dtQuotation_details.Rows[i]["division"].ToString());
                                myCommand.Parameters.AddWithValue("@contact", dtQuotation_details.Rows[i]["contact"].ToString());
                                myCommand.Parameters.AddWithValue("@material", dtQuotation_details.Rows[i]["material"].ToString());
                                myCommand.Parameters.AddWithValue("@size", dtQuotation_details.Rows[i]["size"]);
                                myCommand.Parameters.AddWithValue("@product_desc", dtQuotation_details.Rows[i]["product_desc"].ToString());
                                myCommand.Parameters.AddWithValue("@cust_code", dtQuotation_details.Rows[i]["cust_code"].ToString());
                                myCommand.Parameters.AddWithValue("@cf_code", dtQuotation_details.Rows[i]["cf_code"].ToString());
                                myCommand.Parameters.AddWithValue("@cust_color", dtQuotation_details.Rows[i]["cust_color"].ToString());
                                myCommand.Parameters.AddWithValue("@cf_color", dtQuotation_details.Rows[i]["cf_color"].ToString());

                                myCommand.Parameters.AddWithValue("@price_usd", Return_Float_Value(dtQuotation_details.Rows[i]["price_usd"].ToString()));
                                myCommand.Parameters.AddWithValue("@price_hkd", Return_Float_Value(dtQuotation_details.Rows[i]["price_hkd"].ToString()));
                                myCommand.Parameters.AddWithValue("@price_rmb", Return_Float_Value(dtQuotation_details.Rows[i]["price_rmb"].ToString()));

                                myCommand.Parameters.AddWithValue("@moq", dtQuotation_details.Rows[i]["moq"]);
                                myCommand.Parameters.AddWithValue("@price_unit", dtQuotation_details.Rows[i]["price_unit"].ToString());
                                myCommand.Parameters.AddWithValue("@remark", dtQuotation_details.Rows[i]["remark"].ToString());
                                myCommand.Parameters.AddWithValue("@temp_code", dtQuotation_details.Rows[i]["temp_code"].ToString());
                                myCommand.Parameters.AddWithValue("@ver", dtQuotation_details.Rows[i]["ver"]);
                                
                                //--Katie報表格式新加的字段
                                myCommand.Parameters.AddWithValue("@moq_desc", dtQuotation_details.Rows[i]["moq_desc"].ToString());
                                myCommand.Parameters.AddWithValue("@moq_unit", dtQuotation_details.Rows[i]["moq_unit"].ToString());
                                myCommand.Parameters.AddWithValue("@season", dtQuotation_details.Rows[i]["season"].ToString());
                                myCommand.Parameters.AddWithValue("@salesman", dtQuotation_details.Rows[i]["salesman"].ToString());
                                myCommand.Parameters.AddWithValue("@mwq", dtQuotation_details.Rows[i]["mwq"]);
                                myCommand.Parameters.AddWithValue("@lead_time_min", dtQuotation_details.Rows[i]["lead_time_min"]);
                                myCommand.Parameters.AddWithValue("@lead_time_max", dtQuotation_details.Rows[i]["lead_time_max"]);
                                myCommand.Parameters.AddWithValue("@lead_time_unit", dtQuotation_details.Rows[i]["lead_time_unit"].ToString());
                                myCommand.Parameters.AddWithValue("@md_charge", dtQuotation_details.Rows[i]["md_charge"]);
                                myCommand.Parameters.AddWithValue("@md_charge_cny", dtQuotation_details.Rows[i]["md_charge_cny"].ToString());
                                myCommand.Parameters.AddWithValue("@moq_for_test", dtQuotation_details.Rows[i]["moq_for_test"]);
                                myCommand.Parameters.AddWithValue("@number_enter", dtQuotation_details.Rows[i]["number_enter"]);
                                myCommand.Parameters.AddWithValue("@hkd_ex_fty", dtQuotation_details.Rows[i]["hkd_ex_fty"]);
                                myCommand.Parameters.AddWithValue("@usd_ex_fty", dtQuotation_details.Rows[i]["usd_ex_fty"]);
                                myCommand.Parameters.AddWithValue("@sales_group", dtQuotation_details.Rows[i]["sales_group"]);
                                myCommand.Parameters.AddWithValue("@usd_dap", dtQuotation_details.Rows[i]["usd_dap"]);
                                myCommand.Parameters.AddWithValue("@usd_lab_test_prx", dtQuotation_details.Rows[i]["usd_lab_test_prx"]);
                                myCommand.Parameters.AddWithValue("@ex_fty_hkd", dtQuotation_details.Rows[i]["ex_fty_hkd"]);
                                myCommand.Parameters.AddWithValue("@ex_fty_usd", dtQuotation_details.Rows[i]["ex_fty_usd"]);
                                //折扣后
                                myCommand.Parameters.AddWithValue("@discount", dtQuotation_details.Rows[i]["discount"]);
                                myCommand.Parameters.AddWithValue("@disc_price_usd", dtQuotation_details.Rows[i]["disc_price_usd"]);
                                myCommand.Parameters.AddWithValue("@disc_price_hkd", dtQuotation_details.Rows[i]["disc_price_hkd"]);
                                myCommand.Parameters.AddWithValue("@disc_price_rmb", dtQuotation_details.Rows[i]["disc_price_rmb"]);
                                myCommand.Parameters.AddWithValue("@disc_hkd_ex_fty", dtQuotation_details.Rows[i]["disc_hkd_ex_fty"]);
                                //實際報價
                                myCommand.Parameters.AddWithValue("@actual_price", dtQuotation_details.Rows[i]["actual_price"]);
                                myCommand.Parameters.AddWithValue("@actual_price_type", dtQuotation_details.Rows[i]["actual_price_type"].ToString());
                                //打模費
                                myCommand.Parameters.AddWithValue("@die_mould_usd", dtQuotation_details.Rows[i]["die_mould_usd"]);
                                myCommand.Parameters.AddWithValue("@die_mould_cny", dtQuotation_details.Rows[i]["die_mould_cny"].ToString());
                                myCommand.Parameters.AddWithValue("@rmb_remark", dtQuotation_details.Rows[i]["rmb_remark"].ToString());
                                myCommand.Parameters.AddWithValue("@cust_artwork", dtQuotation_details.Rows[i]["cust_artwork"].ToString());
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }
            }

            SetButtonSatus(true);
            Edit_Columns(true);

            temp_state = mState; //將更改的值寫入dgvFind     

            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);
            Set_Grid_Status(false);
            mState = "";
            btnCopy.Enabled = false;
            memRemark.Properties.ReadOnly = true;
            memRemark.BackColor = Color.LightGray;
            //tabPage3.Parent = null;//不顯示Tabpag3
            tabControl1.SelectTab(0);

            txtCustomer_id.Enabled = false;
            dtTempDel.Clear();
            mList.Clear();
            if (save_flag)
            {
                Find_doc(txtID.Text, txtVersion.Text);
                //MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBoxTimeout((IntPtr)0, myMsg.msgSave_ok, myMsg.msgTitle, 0, 0, 1000); //提示窗體1秒后自動關閉    
                if (temp_state == "EDIT" || temp_state == "NEW")
                {
                    ReSet_Datagrid_Value();//將值更新回查詢頁面
                    if (temp_state == "NEW" && dgvFind.Rows.Count>0)
                    {
                        //新增時將光標定位到最后一行
                        dgvFind.CurrentCell = dgvFind.Rows[dgvFind.Rows.Count - 1].Cells[1];
                        dgvFind.BeginEdit(true);
                        int curent_row = dgvFind.CurrentRow.Index;
                        dgvFind.Rows[curent_row].Selected = true; //選中整行
                    }
                }
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        private bool Save_Before_Valid() //保存前檢查主檔資料有效性
        {
            if (mState == "NEW")
            {
                GetDocNo();
            }
            if (txtID.Text == "" || txtDate.Text == "" || txtTerm_id.Text == "" || txtAddress_id.Text == "" || txtValid_date.Text == "" || txtMoney_id.Text == "")
            {
                MessageBox.Show("注意:藍色字欄位資料不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Valid_Doc() //主建是否已存在
        {
            bool flag;
            string doc = txtID.Text.Trim();
            string strSql = String.Format("Select '1' FROM dbo.quotation_mostly WHERE id='{0}' AND version='{1}'", txtID.Text.Trim(), txtVersion.Text.Trim());
            DataTable dt = clsPublicOfCF01.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(myMsg.msgIsExists + String.Format("【{0}】", doc), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            else
            {
                flag = false;
            }
            dt.Dispose();
            return flag;
        }

        private string Get_Details_Seq(string pID,string pVer) //取明細的序號
        {
            DataTable dtMaxseq = new DataTable();
            dtMaxseq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(seq_id) as seq_id FROM dbo.quotation_details with(nolock) WHERE id ='{0}' and version='{1}'", pID,pVer));

            string strSeq;
            if (String.IsNullOrEmpty(dtMaxseq.Rows[0]["seq_id"].ToString()))
            {
                strSeq = "0001";
            }
            else
            {
                strSeq = dtMaxseq.Rows[0]["seq_id"].ToString();
                strSeq = strSeq.Substring(0, 4);
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("0000");
            }
            dtMaxseq.Dispose();
            return strSeq;
        }

        private void GetDocNo() //取最大單據編號
        {
            string strYear = clsPublicOfCF01.ExecuteSqlReturnObject("Select substring(convert(varchar(10),GETDATE(),120),1,4)");
            string strDoc = String.Format("{0}{1}", strArea, strYear);
            string strSeq;
            string strMaxSeq;
            DataTable dtMaxSeq = new DataTable();
            dtMaxSeq = clsPublicOfCF01.GetDataTable(String.Format("SELECT MAX(id) as id FROM dbo.quotation_mostly WHERE id LIKE '{0}%'", strDoc));
            if (String.IsNullOrEmpty(dtMaxSeq.Rows[0]["id"].ToString()))
            {
                strSeq = "000001";
            }
            else
            {
                strMaxSeq = dtMaxSeq.Rows[0]["id"].ToString();
                strSeq = strMaxSeq.Substring(strMaxSeq.Length - 6);
                strSeq = (Convert.ToInt32(strSeq) + 1).ToString("000000");
            }
            strMaxSeq = strDoc + strSeq;
            txtID.Text = strMaxSeq;
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (gridView1.GetDataRow(e.RowHandle) == null)
            {
                return;
            }
            string rowStatus = gridView1.GetDataRow(e.RowHandle).RowState.ToString();
            if (rowStatus == "Added" || rowStatus == "Modified")
            {
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void Set_Master_Data(DataTable dt) //綁定主檔資料
        {
            txtID.Text = dt.Rows[0]["id"].ToString();
            txtVersion.Text = dt.Rows[0]["version"].ToString();            
            txtDate.EditValue = clsApp.Return_String_Date(dt.Rows[0]["quota_date"].ToString());
            txtCustomer_id.EditValue = dt.Rows[0]["customer_id"].ToString();
            txtCust_desc.Text = dt.Rows[0]["name_customer"].ToString();
            txtTerm_id.EditValue = dt.Rows[0]["term_id"];
            txtAddress_id.EditValue = dt.Rows[0]["address_id"];
            txtRemark.Text = dt.Rows[0]["remark"].ToString();
            txtRemark_other.Text = dt.Rows[0]["remark_other"].ToString();
            txtId_referred.Text = dt.Rows[0]["id_referred"].ToString();

            txtCrusr.Text = dt.Rows[0]["crusr"].ToString();
            txtCrtim.Text = dt.Rows[0]["crtim"].ToString();
            txtAmusr.Text = dt.Rows[0]["amusr"].ToString();
            txtAmtim.Text = dt.Rows[0]["amtim"].ToString();
            
            if (!string.IsNullOrEmpty(dt.Rows[0]["valid_date"].ToString()))
                txtValid_date.EditValue = clsApp.Return_String_Date(dt.Rows[0]["valid_date"].ToString()); 
            else
                txtValid_date.EditValue = "";
            txtMoney_id.EditValue = dt.Rows[0]["money_id"].ToString();
            txtContact.Text = dt.Rows[0]["contact"].ToString();
            txtTel.Text = dt.Rows[0]["tel"].ToString();
            txtFax.Text = dt.Rows[0]["fax"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();

            if (dt.Rows[0]["isusd"].ToString() == "True")
                chkUsd.Checked = true;
            else
                chkUsd.Checked = false;
            if (dt.Rows[0]["ishkd"].ToString() == "True")
                chkHkd.Checked = true;
            else
                chkHkd.Checked = false;
            if (dt.Rows[0]["isrmb"].ToString() == "True")
                chkRmb.Checked = true;
            else
                chkRmb.Checked = false;
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                if (mState == "") //流覽模式
                {
                    Find_doc(txtID.Text,txtVersion.Text);
                }
            }
        }

        //private string GetConString(string _all_path, string _public_path)
        //{
        //    string str_result = "";
        //    int lenth_all = _all_path.Length;
        //    int lenth_public = _public_path.Length;
        //    str_result = _all_path.Substring(lenth_public, lenth_all - lenth_public);
        //    return str_result;
        //}

        private void txtCustomer_id_Click(object sender, EventArgs e)
        {
            txtCustomer_id.SelectAll();
        }

        private void txtAddress_id_Click(object sender, EventArgs e)
        {
            txtAddress_id.SelectAll();
            if (!string.IsNullOrEmpty(txtAddress_id.EditValue.ToString()))
            {
                memRemark.Text = Get_Remark(dtAddress1, txtAddress_id.EditValue.ToString());
            }
        }

        private void txtTerm_id_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTerm_id.EditValue.ToString()))
            {
                memRemark.Text = Get_Remark(dtTerm1, txtTerm_id.EditValue.ToString());
            }
        }


        /// <summary>
        /// 反回三位小數的浮點數
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static float Return_Float_Value(string pValue)
        {
            float fResult;

            if (!string.IsNullOrEmpty(pValue))
            {
                fResult = float.Parse(pValue);
            }
            else
            {
                fResult = 0.000f;
            }

            if (fResult > 0)
            {
                fResult = (float)Math.Round(fResult, 3);
            }
            else
            {
                fResult = 0;
            }
            return fResult;
        }

        private void BTNFIND3_Click(object sender, EventArgs e)
        {           
            DataRow[] drs = null;
            if (dgvDetails.RowCount > 0)
            {
                bool select_flag = false;
                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                    {
                        select_flag = true;
                        break;
                    }
                }
                if (select_flag)
                {
                    drs = dtFind.Select("flag_select=true");
                }
            }

            string strDat1, strDat2, ls_crtim1, ls_crtim2;
            strDat1 = txtDate1.Text;
            strDat2 = txtDate2.Text;
            ls_crtim1 = txtCrtim1.Text;
            ls_crtim2 = txtCrtim2.Text;
            if (strDat1 == "    /  /")
            {
                strDat1 = "";
            }
            if (strDat2 == "    /  /")
            {
                strDat2 = "";
            }
            if (ls_crtim1 == "    /  /")
            {
                ls_crtim1 = "";
            }
            if (ls_crtim2 == "    /  /")
            {
                ls_crtim2 = "";
            }

            SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@user_id",DBUtility._user_id),
                       new SqlParameter("@sales_group",txtSales_group.Text),
                       new SqlParameter("@brand",txtBrand.Text),
                       new SqlParameter("@material",txtMaterial.Text),
                       new SqlParameter("@cust_code",txtCust_code.Text),
                       new SqlParameter("@cust_color",txtCust_color.Text),
                       new SqlParameter("@cf_code",txtCf_code.Text),
                       new SqlParameter("@cf_color",txtCf_color.Text),
                       new SqlParameter("@season",txtSeason.Text),
                       new SqlParameter("@temp_code",txtTemp_code.Text),
                       new SqlParameter("@size",txtSize.Text),
                       new SqlParameter("@dat1",strDat1), 
                       new SqlParameter("@dat2",strDat2),
                       new SqlParameter("@mo_id",txtMo_id.Text),
                       new SqlParameter("@sub_mo_id",txtSub.Text),
                       new SqlParameter("@plm_code",txtPlm_Code.Text),
                       new SqlParameter("@product_desc",txtProductDesc.Text),
                       new SqlParameter("@remark",""),
                       new SqlParameter("@other_remark",""),
                       new SqlParameter("@remark_for_pdd",""),
                       new SqlParameter("@reason_edit",""),
                       new SqlParameter("@crtim_s",ls_crtim1),
                       new SqlParameter("@crtim_e",ls_crtim2),
                       new SqlParameter("@include_mat","1"),
                       new SqlParameter("@include_brand","1"),
                       new SqlParameter("@is_hiden_cancel_data",chkHidenCancel.Checked?"1":"0"),
                       new SqlParameter("@account_code",txtAccount_Code.Text)
            };

            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //************************
            dtFind = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_qoutation_find", paras); //数据处理
            //************************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });


            //------------ 
            //導入前一次打勾的記錄
            if (drs != null)
            {
                if (drs.Length > 0)
                {
                    DataRow[] drs_del;
                    foreach (DataRow row in drs)
                    {
                        drs_del = dtFind.Select(string.Format("id={0}", row["id"]));
                        foreach (DataRow row_del in drs_del)
                        {
                            dtFind.Rows.Remove(row_del);//先移走已存在的行
                        }
                    }
                    
                    //將打勾的添加進新查詢的結果中
                    foreach (DataRow dr in drs)
                    {
                        dtFind.ImportRow(dr);
                    }
                }
            }

            DataView dv = dtFind.DefaultView;
            dv.Sort = "flag_select DESC";  //按Flag_select列 排序            
            dtFind = dv.ToTable();
            //------------

            
            //dtFind.Columns.Add("flag_select", System.Type.GetType("System.Boolean"));           
            dgvDetails.DataSource = dtFind;
            //dgvDetails.Columns["season"].Frozen = true;
        }

        private void BTNADD_BATCH1_Click(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                return;
            }

            if (mState == "")
            {
                MessageBox.Show("非新增或編輯狀態不可以使用此功能!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool select_flag = false;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {
                    select_flag = true;
                    break;
                }
            }
            if (!select_flag)
            {
                MessageBox.Show("請選擇要添加的記錄!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int cur_row = 0;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {
                    gridView1.AddNewRow();//新增
                    cur_row = gridView1.FocusedRowHandle;
                    gridView1.SetRowCellValue(cur_row, "brand", dtFind.Rows[i]["brand"].ToString());
                    gridView1.SetRowCellValue(cur_row, "division", dtFind.Rows[i]["division"].ToString());
                    gridView1.SetRowCellValue(cur_row, "contact", dtFind.Rows[i]["contact"].ToString());
                    gridView1.SetRowCellValue(cur_row, "material", dtFind.Rows[i]["material"].ToString());
                    gridView1.SetRowCellValue(cur_row, "size", dtFind.Rows[i]["size"].ToString());
                    gridView1.SetRowCellValue(cur_row, "product_desc", dtFind.Rows[i]["product_desc"].ToString());
                    gridView1.SetRowCellValue(cur_row, "cust_code", dtFind.Rows[i]["cust_code"].ToString());
                    gridView1.SetRowCellValue(cur_row, "cf_code", dtFind.Rows[i]["cf_code"].ToString());
                    gridView1.SetRowCellValue(cur_row, "cust_color", dtFind.Rows[i]["cust_color"].ToString());
                    gridView1.SetRowCellValue(cur_row, "cf_color", dtFind.Rows[i]["cf_color"].ToString());
                    gridView1.SetRowCellValue(cur_row, "price_usd", dtFind.Rows[i]["price_usd"].ToString());
                    gridView1.SetRowCellValue(cur_row, "price_hkd", dtFind.Rows[i]["price_hkd"].ToString());
                    gridView1.SetRowCellValue(cur_row, "price_rmb", dtFind.Rows[i]["price_rmb"].ToString());
                    gridView1.SetRowCellValue(cur_row, "moq", dtFind.Rows[i]["moq"].ToString());
                    gridView1.SetRowCellValue(cur_row, "price_unit", dtFind.Rows[i]["price_unit"].ToString());
                    gridView1.SetRowCellValue(cur_row, "remark", dtFind.Rows[i]["remark"].ToString());
                    gridView1.SetRowCellValue(cur_row, "temp_code", dtFind.Rows[i]["temp_code"].ToString());
                    gridView1.SetRowCellValue(cur_row, "ver", dtFind.Rows[i]["ver"].ToString());

                    gridView1.SetRowCellValue(cur_row, "moq_desc", dtFind.Rows[i]["moq_desc"].ToString());
                    gridView1.SetRowCellValue(cur_row, "moq_unit", dtFind.Rows[i]["moq_unit"].ToString());
                    gridView1.SetRowCellValue(cur_row, "season", dtFind.Rows[i]["season"].ToString());
                    gridView1.SetRowCellValue(cur_row, "salesman", dtFind.Rows[i]["salesman"].ToString());
                    gridView1.SetRowCellValue(cur_row, "mwq", dtFind.Rows[i]["mwq"]);
                    gridView1.SetRowCellValue(cur_row, "lead_time_min", dtFind.Rows[i]["lead_time_min"]);
                    gridView1.SetRowCellValue(cur_row, "lead_time_max", dtFind.Rows[i]["lead_time_max"]);
                    gridView1.SetRowCellValue(cur_row, "lead_time_unit", dtFind.Rows[i]["lead_time_unit"].ToString());
                    gridView1.SetRowCellValue(cur_row, "md_charge", dtFind.Rows[i]["md_charge"]);
                    gridView1.SetRowCellValue(cur_row, "md_charge_cny", dtFind.Rows[i]["md_charge_cny"].ToString());
                    gridView1.SetRowCellValue(cur_row, "number_enter", dtFind.Rows[i]["number_enter"]);
                    gridView1.SetRowCellValue(cur_row, "hkd_ex_fty", dtFind.Rows[i]["hkd_ex_fty"]);
                    gridView1.SetRowCellValue(cur_row, "usd_ex_fty", dtFind.Rows[i]["usd_ex_fty"]);
                    gridView1.SetRowCellValue(cur_row, "sales_group", dtFind.Rows[i]["sales_group"]);
                    gridView1.SetRowCellValue(cur_row, "moq_for_test", dtFind.Rows[i]["moq_for_test"]);
                    gridView1.SetRowCellValue(cur_row, "usd_dap", dtFind.Rows[i]["usd_dap"]);
                    gridView1.SetRowCellValue(cur_row, "usd_lab_test_prx", dtFind.Rows[i]["usd_lab_test_prx"]);
                    gridView1.SetRowCellValue(cur_row, "ex_fty_hkd", dtFind.Rows[i]["ex_fty_hkd"]);
                    gridView1.SetRowCellValue(cur_row, "ex_fty_usd", dtFind.Rows[i]["ex_fty_usd"]);

                    gridView1.SetRowCellValue(cur_row, "discount", dtFind.Rows[i]["discount"]);
                    gridView1.SetRowCellValue(cur_row, "disc_price_usd", dtFind.Rows[i]["disc_price_usd"]);
                    gridView1.SetRowCellValue(cur_row, "disc_price_hkd", dtFind.Rows[i]["disc_price_hkd"]);
                    gridView1.SetRowCellValue(cur_row, "disc_price_rmb", dtFind.Rows[i]["disc_price_rmb"]);
                    gridView1.SetRowCellValue(cur_row, "disc_hkd_ex_fty", dtFind.Rows[i]["disc_hkd_ex_fty"]);
                    gridView1.SetRowCellValue(cur_row, "die_mould_usd", dtFind.Rows[i]["die_mould_usd"]);
                    gridView1.SetRowCellValue(cur_row, "die_mould_cny", dtFind.Rows[i]["die_mould_cny"].ToString());                   
                    gridView1.SetRowCellValue(cur_row, "actual_price", dtFind.Rows[i]["price_salesperson"].ToString());
                    gridView1.SetRowCellValue(cur_row, "rmb_remark", dtFind.Rows[i]["rmb_remark"].ToString());
                    gridView1.SetRowCellValue(cur_row, "cust_artwork", dtFind.Rows[i]["cust_artwork"].ToString()); 
                }
            }
            //取消選中的
            for (int i = 0; i < dtFind.Rows.Count; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {
                    dtFind.Rows[i]["flag_select"] = false;
                }
            }
            tabControl1.SelectTab(0);
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
           Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {
                if (grd.Rows[e.RowIndex].Cells["pending"].Value.ToString() == "")
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                }
                else
                {
                    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkMagenta;//紫色字體
                    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                }
                ////備註字段不顯示刪除線
                //grd.Rows[e.RowIndex].Cells["remark"].Style.ForeColor = Color.Black;
                //grd.Rows[e.RowIndex].Cells["remark"].Style.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular); 
            }
            if (grd.Rows[e.RowIndex].Cells["special_price"].Value.ToString() == "True")
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {

            if (clsApp.set_find_Value(Name, panel1.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Find_Data();
        }


        private void Find_Data()
        {
            if (BTNCANCEL.Enabled)
            {
                Cancel();
                tabControl1.SelectTab(1);
            }
            StringBuilder sb = new StringBuilder(Get_Str_Find());
            if (txtQuotation1.Text != "")
                sb.Append(string.Format(" AND A.id>='{0}'", txtQuotation1.Text));
            if (txtQuotation2.Text != "")
                sb.Append(string.Format(" AND A.id<='{0}'", txtQuotation2.Text));
            if (txtDat1.Text != "")
                sb.Append(string.Format(" AND A.quota_date>='{0}'", txtDat1.Text));
            if (txtDat2.Text != "")
                sb.Append(string.Format(" AND A.quota_date<='{0}'", txtDat2.Text));
            if (txtCust_id1.Text != "")
                sb.Append(string.Format(" AND A.customer_id>='{0}'", txtCust_id1.Text));
            if (txtCust_id2.Text != "")
                sb.Append(string.Format(" AND A.customer_id<='{0}'", txtCust_id2.Text));
            if(txtCreateby.Text != "")
                sb.Append(string.Format(" AND A.crusr='{0}'", txtCreateby.Text));
            if (txtBrand_id1.Text != "")
                sb.Append(string.Format(" AND B.brand>='{0}'", txtBrand_id1.Text));
            if (txtBrand_id2.Text != "")
                sb.Append(string.Format(" AND B.brand<='{0}'", txtBrand_id2.Text));
            if (txtCust_code1.Text != "")
                sb.Append(string.Format(" AND B.cust_code Like '%{0}%'", txtCust_code1.Text));
            if (txtCf_code1.Text != "")
                sb.Append(string.Format(" AND B.cf_code Like '%{0}%'", txtCf_code1.Text));
            if (txtCust_color1.Text != "")
                sb.Append(string.Format(" AND B.cust_color Like '%{0}%'", txtCust_color1.Text));
            if (txtCf_color1.Text != "")
                sb.Append(string.Format(" AND B.cf_color Like '%{0}%'", txtCf_color1.Text));
            if (txtSize1.Text != "")
                sb.Append(string.Format(" AND B.size Like '%{0}%'", txtSize1.Text));
            sb.Append(" ORDER BY A.id,B.seq_id");
            dtReport = clsPublicOfCF01.GetDataTable(sb.ToString());

            dgvFind.DataSource = dtReport;
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Load_Data()
        {
            if (BTNCANCEL.Enabled)
            {
                Cancel();
                tabControl1.SelectTab(1);
            }
            StringBuilder sb = new StringBuilder(Get_Str_Find());
            sb.Append(string.Format(" and A.id='{0}' ORDER BY A.id,B.seq_id", txtID.Text));
            dtReport = clsPublicOfCF01.GetDataTable(sb.ToString());
            dgvFind.DataSource = dtReport;
        }

        private string Get_Str_Find()
        {
            string strsql = string.Format(
           @"SELECT A.id as id_h,A.version,Convert(char(10),A.quota_date,120) as quota_date_h,A.customer_id,A.address_id,A.term_id,A.remark as remark_h,A.id_referred,
            '' as terms,'' as address,Convert(char(10),A.valid_date) as valid_date,A.money_id,A.contact as contact_h,A.tel,A.fax,A.email,
            A.isusd,A.ishkd,A.isrmb,B.seq_id,B.brand,SS.name AS name_brand,B.division,B.contact,B.material,B.size,B.product_desc,B.cust_code,
            B.cf_code,B.cust_color,B.cf_color,B.price_usd,B.price_hkd,B.price_rmb,B.moq,B.price_unit,B.remark,ISNULL(C.name,'') AS name_customer,
            B.moq_unit,B.season,B.salesman,B.mwq,B.lead_time_min,B.lead_time_max,B.lead_time_unit,B.md_charge,B.md_charge_cny, B.number_enter,            
            B.hkd_ex_fty,B.usd_ex_fty,B.usd_dap,B.usd_lab_test_prx,B.ex_fty_hkd,B.ex_fty_usd,B.moq_for_test,B.sales_group,
            B.discount,B.disc_price_usd,B.disc_price_hkd,B.disc_price_rmb,B.disc_hkd_ex_fty,B.actual_price,B.actual_price_type,B.die_mould_usd,B.die_mould_cny,
            '' AS polo_care,isnull(D.moq_desc,'') AS moqdesc,B.rmb_remark,B.cust_artwork
            FROM dbo.quotation_mostly A with(nolock)
                INNER JOIN dbo.quotation_details B with(nolock) ON A.id=B.id And A.version=B.version
                LEFT JOIN dbo.quotation D with(nolock) ON B.temp_code=D.temp_code
                LEFT JOIN {0}it_customer C with(nolock) ON C.within_code='0000' and A.customer_id=C.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                LEFT JOIN v_brand_customer SS ON ISNULL(B.brand,'')=SS.id COLLATE Chinese_Taiwan_Stroke_CI_AS
            WHERE 1>0 ", DBUtility.remote_db);

//            string strsql = string.Format(
//            @"SELECT A.id as id_h,A.version,Convert(char(10),A.quota_date,120) as quota_date_h,A.customer_id,A.address_id,A.term_id,A.remark as remark_h,A.id_referred,
//            dbo.fn_getTermRemark(A.term_id,A.valid_date) as terms,dbo.fn_getAddress(A.address_id) as address,Convert(char(10),A.valid_date) as valid_date,A.money_id,A.contact as contact_h,A.tel,A.fax,A.email,
//            A.isusd,A.ishkd,A.isrmb,B.seq_id,B.brand,SS.name AS name_brand,B.division,B.contact,B.material,B.size,B.product_desc,B.cust_code,
//            B.cf_code,B.cust_color,B.cf_color,B.price_usd,B.price_hkd,B.price_rmb,B.moq,B.price_unit,B.remark,ISNULL(C.name,'') AS name_customer,
//            B.moq_unit,B.season,B.salesman,B.mwq,B.lead_time_min,B.lead_time_max,B.lead_time_unit,B.md_charge,B.md_charge_cny, B.number_enter,
//            Round(Convert(float,B.price_usd*(1-0.025)),2) AS usd_discount,Round(Convert(float,B.price_hkd*(1-0.025)),2) AS hkd_discount,
//            B.hkd_ex_fty,Round(Convert(float,Isnull(B.number_enter,0)/7.8),2) AS usd_ex_fty,B.usd_dap,B.usd_lab_test_prx,B.ex_fty_hkd,B.ex_fty_usd,
//            CASE WHEN Isnull(D.polo_care,'')='' THEN '' ELSE dbo.fn_getPoloCare(D.polo_care) END AS polo_care,B.moq_for_test,isnull(D.moq_desc,'') AS moqdesc,B.sales_group,
//            B.discount,B.disc_price_usd,B.disc_price_hkd,B.disc_price_rmb,B.disc_hkd_ex_fty
//            FROM dbo.quotation_mostly A with(nolock)
//                INNER JOIN dbo.quotation_details B with(nolock) ON A.id=B.id And A.version=B.version
//                LEFT JOIN dbo.quotation D with(nolock) ON B.temp_code=D.temp_code
//                LEFT JOIN {0}it_customer C with(nolock) ON C.within_code='0000' and A.customer_id=C.id COLLATE Chinese_Taiwan_Stroke_CI_AS
//                LEFT JOIN v_brand_customer SS ON ISNULL(B.brand,'')=SS.id COLLATE Chinese_Taiwan_Stroke_CI_AS
//            WHERE 1>0 ", DBUtility.remote_db);
            //LEFT JOIN (select id,name from {0}cd_brand with(nolock) Union all select id,name from {0}it_customer with(nolock)) SS
            //B.number_enter AS ex_fty_hkd
            return strsql;
        }

        
        private void txtQuotation1_Leave(object sender, EventArgs e)
        {
            txtQuotation2.Text = txtQuotation1.Text;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void txtCust_id1_Leave(object sender, EventArgs e)
        {
            txtCust_id2.Text = txtCust_id1.Text;
        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            txtBrand_id2.Text = txtBrand_id1.Text;
        }

        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strName = dgvFind.Columns[e.ColumnIndex].Name;
            if (strName == "quotaion_id")
            {
                txtID.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["quotaion_id"].Value.ToString();
                txtVersion.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["version_h"].Value.ToString();
                tabControl1.SelectTab(0);
                Find_doc(txtID.Text, txtVersion.Text);
            }
        }

        private void dgvFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFind.RowCount > 0)
            {               
                if (txtID.Text != dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["quotaion_id"].Value.ToString())
                {
                    txtID.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["quotaion_id"].Value.ToString();
                    txtVersion.Text = dgvFind.Rows[dgvFind.CurrentCell.RowIndex].Cells["version_h"].Value.ToString();
                    Find_doc(txtID.Text, txtVersion.Text);
                }
            }          
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件
            if(clsApp.set_find_Value("frmQuotation_Report_browse", tabControl1.TabPages[1].Controls)>0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            using (frmQuotation_Copy ofrmCopy = new frmQuotation_Copy())
            {
                ofrmCopy.ShowDialog();
                if (ofrmCopy.dr_copy == null)
                {
                    return;
                }
                
                if (ofrmCopy.dr_copy.Length > 0)
                {
                    int cur_row;
                    string strDate;
                    for (int i = 0; i < ofrmCopy.dr_copy.Length; i++)
                    {
                        if (i == 0)
                        {
                            //strDate = ofrmCopy.dr_copy[0]["quota_date"].ToString();
                            //strDate = DateTime.Parse(strDate).ToString("yyyy-MM-dd");                           
                            //txtDate.EditValue = strDate;
                            txtDate.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                            txtCustomer_id.EditValue = ofrmCopy.dr_copy[0]["customer_id"].ToString();
                            txtCust_desc.Text = ofrmCopy.dr_copy[0]["name_customer"].ToString();
                            txtTerm_id.EditValue = ofrmCopy.dr_copy[0]["term_id"];
                            txtAddress_id.EditValue = ofrmCopy.dr_copy[0]["address_id"];
                            txtRemark.Text = ofrmCopy.dr_copy[0]["remark"].ToString();
                            txtRemark_other.Text = ofrmCopy.dr_copy[0]["remark_other"].ToString();
                            txtId_referred.Text = ofrmCopy.dr_copy[0]["id"].ToString();

                            strDate = ofrmCopy.dr_copy[0]["valid_date"].ToString();
                            if (!string.IsNullOrEmpty(strDate))
                                txtValid_date.EditValue = DateTime.Parse(strDate).ToString("yyyy-MM-dd");
                            else
                                txtValid_date.EditValue = "";
                            txtMoney_id.EditValue = ofrmCopy.dr_copy[0]["money_id"].ToString();
                            txtContact.Text = ofrmCopy.dr_copy[0]["contact_h"].ToString();
                            txtTel.Text = ofrmCopy.dr_copy[0]["tel"].ToString();
                            txtFax.Text = ofrmCopy.dr_copy[0]["fax"].ToString();
                            txtEmail.Text = ofrmCopy.dr_copy[0]["email"].ToString();
                            if (ofrmCopy.dr_copy[0]["isusd"].ToString() == "True")
                                chkUsd.Checked = true;
                            else
                                chkUsd.Checked = false;
                            if (ofrmCopy.dr_copy[0]["ishkd"].ToString() == "True")
                                chkHkd.Checked = true;
                            else
                                chkHkd.Checked = false;

                            if (ofrmCopy.dr_copy[0]["isrmb"].ToString() == "True")
                                chkRmb.Checked = true;
                            else
                                chkRmb.Checked = false;
                        }

                        gridView1.AddNewRow();//新增
                        cur_row = gridView1.FocusedRowHandle;
                        gridView1.SetRowCellValue(cur_row, "brand", ofrmCopy.dr_copy[i]["brand"].ToString());
                        gridView1.SetRowCellValue(cur_row, "division", ofrmCopy.dr_copy[i]["division"].ToString());
                        gridView1.SetRowCellValue(cur_row, "contact", ofrmCopy.dr_copy[i]["contact"].ToString());
                        gridView1.SetRowCellValue(cur_row, "material", ofrmCopy.dr_copy[i]["material"].ToString());
                        gridView1.SetRowCellValue(cur_row, "size", ofrmCopy.dr_copy[i]["size"].ToString());
                        gridView1.SetRowCellValue(cur_row, "product_desc", ofrmCopy.dr_copy[i]["product_desc"].ToString());
                        gridView1.SetRowCellValue(cur_row, "cust_code", ofrmCopy.dr_copy[i]["cust_code"].ToString());
                        gridView1.SetRowCellValue(cur_row, "cf_code", ofrmCopy.dr_copy[i]["cf_code"].ToString());
                        gridView1.SetRowCellValue(cur_row, "cust_color", ofrmCopy.dr_copy[i]["cust_color"].ToString());
                        gridView1.SetRowCellValue(cur_row, "cf_color", ofrmCopy.dr_copy[i]["cf_color"].ToString());
                        gridView1.SetRowCellValue(cur_row, "price_usd", ofrmCopy.dr_copy[i]["price_usd"]);
                        gridView1.SetRowCellValue(cur_row, "price_hkd", ofrmCopy.dr_copy[i]["price_hkd"]);
                        gridView1.SetRowCellValue(cur_row, "price_rmb", ofrmCopy.dr_copy[i]["price_rmb"]);
                        gridView1.SetRowCellValue(cur_row, "moq", ofrmCopy.dr_copy[i]["moq"]);
                        gridView1.SetRowCellValue(cur_row, "price_unit", ofrmCopy.dr_copy[i]["price_unit"].ToString());
                        gridView1.SetRowCellValue(cur_row, "remark", ofrmCopy.dr_copy[i]["remark"].ToString());
                        gridView1.SetRowCellValue(cur_row, "temp_code", ofrmCopy.dr_copy[i]["temp_code"].ToString());
                        gridView1.SetRowCellValue(cur_row, "ver", ofrmCopy.dr_copy[i]["ver"].ToString());

                        gridView1.SetRowCellValue(cur_row, "moq_unit", ofrmCopy.dr_copy[i]["moq_unit"].ToString());
                        gridView1.SetRowCellValue(cur_row, "season", ofrmCopy.dr_copy[i]["season"].ToString());
                        gridView1.SetRowCellValue(cur_row, "salesman", ofrmCopy.dr_copy[i]["salesman"].ToString());
                        gridView1.SetRowCellValue(cur_row, "mwq", ofrmCopy.dr_copy[i]["mwq"]);
                        gridView1.SetRowCellValue(cur_row, "lead_time_min", ofrmCopy.dr_copy[i]["lead_time_min"]);
                        gridView1.SetRowCellValue(cur_row, "lead_time_max", ofrmCopy.dr_copy[i]["lead_time_max"]);
                        gridView1.SetRowCellValue(cur_row, "lead_time_unit", ofrmCopy.dr_copy[i]["lead_time_unit"].ToString());
                        gridView1.SetRowCellValue(cur_row, "md_charge", ofrmCopy.dr_copy[i]["md_charge"]);
                        gridView1.SetRowCellValue(cur_row, "md_charge_cny", ofrmCopy.dr_copy[i]["md_charge_cny"].ToString());
                        gridView1.SetRowCellValue(cur_row, "moq_for_test", ofrmCopy.dr_copy[i]["moq_for_test"]);
                        gridView1.SetRowCellValue(cur_row, "number_enter", ofrmCopy.dr_copy[i]["number_enter"]);
                        gridView1.SetRowCellValue(cur_row, "hkd_ex_fty", ofrmCopy.dr_copy[i]["hkd_ex_fty"]);
                        gridView1.SetRowCellValue(cur_row, "usd_ex_fty", ofrmCopy.dr_copy[i]["usd_ex_fty"]);
                        gridView1.SetRowCellValue(cur_row, "sales_group", ofrmCopy.dr_copy[i]["sales_group"]);
                        gridView1.SetRowCellValue(cur_row, "usd_dap", ofrmCopy.dr_copy[i]["usd_dap"]);
                        gridView1.SetRowCellValue(cur_row, "usd_lab_test_prx", ofrmCopy.dr_copy[i]["usd_lab_test_prx"]);
                        gridView1.SetRowCellValue(cur_row, "ex_fty_hkd", ofrmCopy.dr_copy[i]["ex_fty_hkd"]);
                        gridView1.SetRowCellValue(cur_row, "ex_fty_usd", ofrmCopy.dr_copy[i]["ex_fty_usd"]);
                        
                        gridView1.SetRowCellValue(cur_row, "discount", ofrmCopy.dr_copy[i]["discount"]);
                        gridView1.SetRowCellValue(cur_row, "disc_price_usd", ofrmCopy.dr_copy[i]["disc_price_usd"]);
                        gridView1.SetRowCellValue(cur_row, "disc_price_hkd", ofrmCopy.dr_copy[i]["disc_price_hkd"]);
                        gridView1.SetRowCellValue(cur_row, "disc_price_rmb", ofrmCopy.dr_copy[i]["disc_price_rmb"]);
                        gridView1.SetRowCellValue(cur_row, "disc_hkd_ex_fty", ofrmCopy.dr_copy[i]["disc_hkd_ex_fty"]);
                        gridView1.SetRowCellValue(cur_row, "actual_price", ofrmCopy.dr_copy[i]["actual_price"]);
                        gridView1.SetRowCellValue(cur_row, "actual_price_type", ofrmCopy.dr_copy[i]["actual_price_type"].ToString());
                        gridView1.SetRowCellValue(cur_row, "die_mould_usd", ofrmCopy.dr_copy[i]["die_mould_usd"]);
                        gridView1.SetRowCellValue(cur_row, "die_mould_cny", ofrmCopy.dr_copy[i]["die_mould_cny"].ToString());

                    }
                    //dsCopy.Tables.Clear();
                    ofrmCopy.dr_copy = null;
                    //奇怪焦點需設置跳轉到另一列的單元格才行，不然保存會少一行
                    Set_Cell_Focus(gridView1);

                }
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dgvFind_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnCopy_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip() { ShowAlways = true };
            p.SetToolTip(btnCopy, "從已存在的報價單中翻單.");
        }

        private void txtCustomer_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState == "EDIT")
            {
                Set_cust_info();
            }
        }

        private void txtCustomer_id_Leave(object sender, EventArgs e)
        {
            if (mState == "NEW")
            {
                Set_cust_info();
            }
        }

        private void Set_cust_info()
        {
            txtCust_desc.Text = txtCustomer_id.GetColumnValue("cdesc").ToString();
            txtMoney_id.EditValue = txtCustomer_id.GetColumnValue("money_id").ToString();
            txtTel.Text = txtCustomer_id.GetColumnValue("tel").ToString();
            txtFax.Text = txtCustomer_id.GetColumnValue("fax").ToString();
            txtEmail.Text = txtCustomer_id.GetColumnValue("email").ToString();
            txtContact.Text = txtCustomer_id.GetColumnValue("contact").ToString();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (txtDate.Text != "")
            {
                txtValid_date.EditValue = txtDate.DateTime.AddDays(90).ToString("yyyy-MM-dd");
            }
        }

        private void btnPrints_Click(object sender, EventArgs e)
        {
            if (dgvFind.RowCount > 0)
            {
               // Print();
            }
            else
            {
                MessageBox.Show("請先查詢出要列印的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Print(DataTable dt)
        {
            string strReport = txtReportFormat.EditValue.ToString();
            if (strReport == "04" || strReport == "05")
            {
                bool flag_gap = false;
                string strBrand_id="";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strBrand_id=dt.Rows[i]["brand"].ToString();
                    if (strBrand_id.Contains("GAP") || strBrand_id.Contains("BANA-"))                    
                    {
                        flag_gap = true;
                        break;
                    }                   
                }
                if (!flag_gap)
                {
                    MessageBox.Show("GAP/BANA 的牌子方可以調用此報表!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (string.IsNullOrEmpty(strReport))
            {
                MessageBox.Show("請首先選擇要列印的報表格式!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            switch (strReport)
            {
                case "01": //格式一通用
                    using (xrQuotation myReport1 = new xrQuotation() { DataSource = dt })
                    {
                        myReport1.CreateDocument();
                        myReport1.PrintingSystem.ShowMarginsWarning = false;
                        myReport1.ShowPreviewDialog();

                        //報表轉成圖片
                        //FolderBrowserDialog fbd = new FolderBrowserDialog();
                        ////选择导出文件位置
                        //if (fbd.ShowDialog() == DialogResult.OK)
                        //{
                        //    //导出路径
                        //    string outPath = fbd.SelectedPath.ToString();
                        //    string fileName = @"\\dgfs2\cf_artwork\Artwork\ProductCard\" + "頁數" + ".jpg";
                        //    //输出图片到指定位置
                        //    myReport1.ExportToImage(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //}
                        
                    }
                    break;
                case "02": //格式二(1)，一般格式USD,HKD,RMB
                     using (xrQuotation2a myReport21 = new xrQuotation2a() { DataSource = dt })
                    {
                        myReport21.CreateDocument();
                        myReport21.PrintingSystem.ShowMarginsWarning = false;
                        myReport21.ShowPreviewDialog();
                    }
                    break;
                case "03": //格式二(2)，一般格式USD
                    using (xrQuotation2b myReport22 = new xrQuotation2b() { DataSource = dt })
                    {
                        myReport22.CreateDocument();
                        myReport22.PrintingSystem.ShowMarginsWarning = false;
                        myReport22.ShowPreviewDialog();
                    }
                    break;
                case "04": //格式三（1）USD only GAP/BANA
                    using (xrQuotation31 myReport31 = new xrQuotation31() { DataSource = dt })
                    {
                        myReport31.CreateDocument();
                        myReport31.PrintingSystem.ShowMarginsWarning = false;
                        myReport31.ShowPreviewDialog();
                    }
                    break;
                case "05": //格式三（2）USD & HKD GAP/BANA
                    using (xrQuotation32 myReport32 = new xrQuotation32() { DataSource = dt })
                    {
                        myReport32.CreateDocument();
                        myReport32.PrintingSystem.ShowMarginsWarning = false;
                        myReport32.ShowPreviewDialog();
                    }
                    break;
                case "06":  //格式四ex_fty_usd,ex_fty_hkd
                    using (xrQuotation4 myReport4 = new xrQuotation4() { DataSource = dt })
                    {
                        myReport4.CreateDocument();
                        myReport4.PrintingSystem.ShowMarginsWarning = false;
                        myReport4.ShowPreviewDialog();
                    }
                    break;
                case "07"://格式五
                    using (xrQuotation5 myReport5 = new xrQuotation5() { DataSource = dt })
                    {
                        myReport5.CreateDocument();
                        myReport5.PrintingSystem.ShowMarginsWarning = false;
                        myReport5.ShowPreviewDialog();
                    }
                    break;
                case "08"://格式六1
                    using (xrQuotation61 myReport61 = new xrQuotation61() { DataSource = dt })
                    {
                        myReport61.CreateDocument();
                        myReport61.PrintingSystem.ShowMarginsWarning = false;
                        myReport61.ShowPreviewDialog();
                    }
                    break;
                case "09"://格式六2
                    using (xrQuotation62 myReport62 = new xrQuotation62() { DataSource = dt })
                    {
                        myReport62.CreateDocument();
                        myReport62.PrintingSystem.ShowMarginsWarning = false;
                        myReport62.ShowPreviewDialog();
                    }
                    break;
                case "10"://格式七1
                    using (xrQuotation71 myReport71 = new xrQuotation71() { DataSource = dt })
                    {
                        myReport71.CreateDocument();
                        myReport71.PrintingSystem.ShowMarginsWarning = false;
                        myReport71.ShowPreviewDialog();
                    }
                    break;
                case "11"://格式七2
                    using (xrQuotation72 myReport72 = new xrQuotation72() { DataSource = dt })
                    {
                        myReport72.CreateDocument();
                        myReport72.PrintingSystem.ShowMarginsWarning = false;
                        myReport72.ShowPreviewDialog();
                    }
                    break;
                case "12"://格式八HKD_EX_FTY
                    using (xrQuotation8 myReport8= new xrQuotation8() { DataSource = dt })
                    {
                        myReport8.CreateDocument();
                        myReport8.PrintingSystem.ShowMarginsWarning = false;
                        myReport8.ShowPreviewDialog();
                    }
                    break;
                case "13"://格式九HKD_EX_FTY
                    using (xrQuotation9 myReport9 = new xrQuotation9() { DataSource = dt })
                    {
                        myReport9.CreateDocument();
                        myReport9.PrintingSystem.ShowMarginsWarning = false;
                        myReport9.ShowPreviewDialog();
                    }
                    break;
                case "14"://格式十RMB
                    using (xrQuotation10 myReport10 = new xrQuotation10() { DataSource = dt })
                    {
                        myReport10.CreateDocument();
                        myReport10.PrintingSystem.ShowMarginsWarning = false;
                        myReport10.ShowPreviewDialog();
                    }
                    break;
                case "15"://格式十一 HKD EX-FTY，USD EX-FTY,USD FOB-HK,RMB(including 17% VAT TAX)
                    using (xrQuotation11 myReport11 = new xrQuotation11() { DataSource = dt })
                    {
                        myReport11.CreateDocument();
                        myReport11.PrintingSystem.ShowMarginsWarning = false;
                        myReport11.ShowPreviewDialog();
                    }
                    break;
                case "16"://格式十二 USD EX-FTY,USD FOB-USD,
                    using (xrQuotation12 myReport12 = new xrQuotation12() { DataSource = dt })
                    {
                        myReport12.CreateDocument();
                        myReport12.PrintingSystem.ShowMarginsWarning = false;
                        myReport12.ShowPreviewDialog();
                    }
                    break;
                case "17"://格式十三 FOB-USD有圖樣
                    using (xrQuotation13 myReport13 = new xrQuotation13() { DataSource = dt })
                    {
                        myReport13.CreateDocument();
                        myReport13.PrintingSystem.ShowMarginsWarning = false;
                        myReport13.ShowPreviewDialog();
                    }
                    break;
                case "18"://格式十四(無條款 USD EX-FTY)
                    using (xrQuotation14 myReport14 = new xrQuotation14() { DataSource = dt })
                    {
                        myReport14.CreateDocument();
                        myReport14.PrintingSystem.ShowMarginsWarning = false;
                        myReport14.ShowPreviewDialog();
                    }
                    break;
                case "19"://格式十五(TORY HK)
                    using (xrQuotation15 myReport15 = new xrQuotation15() { DataSource = dt })
                    {
                        myReport15.CreateDocument();
                        myReport15.PrintingSystem.ShowMarginsWarning = false;
                        myReport15.ShowPreviewDialog();
                    }
                    break;
                case "20"://格式十六(TORY US)
                    using (xrQuotation16 myReport16 = new xrQuotation16() { DataSource = dt })
                    {
                        myReport16.CreateDocument();
                        myReport16.PrintingSystem.ShowMarginsWarning = false;
                        myReport16.ShowPreviewDialog();
                    }
                    break;
                case "21"://格式十七(Ex-fty HKD & Ex-fty USD)
                    using (xrQuotation17 myReport17 = new xrQuotation17() { DataSource = dt })
                    {
                        myReport17.CreateDocument();
                        myReport17.PrintingSystem.ShowMarginsWarning = false;
                        myReport17.ShowPreviewDialog();
                    }
                    break;
                case "22"://格式十八(無條款 RMB)
                    using (xrQuotation18 myReport18 = new xrQuotation18() { DataSource = dt })
                    {
                        myReport18.CreateDocument();
                        myReport18.PrintingSystem.ShowMarginsWarning = false;
                        myReport18.ShowPreviewDialog();
                    }
                    break;
                case "23"://格式十九(price remark)
                    using (xrQuotation19 myReport19 = new xrQuotation19() { DataSource = dt })
                    {
                        myReport19.CreateDocument();
                        myReport19.PrintingSystem.ShowMarginsWarning = false;
                        myReport19.ShowPreviewDialog();
                    }
                    break;
                case "24"://格式二十(Usd ex_fty & price remark)
                    using (xrQuotation20 myReport20 = new xrQuotation20() { DataSource = dt })
                    {
                        myReport20.CreateDocument();
                        myReport20.PrintingSystem.ShowMarginsWarning = false;
                        myReport20.ShowPreviewDialog();
                    }
                    break;
            }
        }

     
        private void txtMoney_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                if (txtMoney_id.Text == "HKD")
                    chkHkd.Checked = true;
                if (txtMoney_id.Text == "USD")
                    chkUsd.Checked = true;
                if (txtMoney_id.Text == "RMB")
                    chkRmb.Checked = true;
            }
        }

        //private void BTNFIND_Click_1(object sender, EventArgs e)
        //{            
        //    //tabControl1.SelectTab(1);
        //    //if (txtDat1.Text == "" && txtDat2.Text == "")
        //    //{
        //    //    txtDat1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        //    //    txtDat2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        //    //}
        //}


        private void ReSet_Datagrid_Value()
        {            
            string strSql = string.Format(@"Select dbo.fn_getAddress('{0}') as address", txtAddress_id.EditValue);
            string strAddress = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
            strSql = string.Format(@"Select dbo.fn_getTermRemark('{0}','{1}','0') as terms", txtTerm_id.EditValue, txtValid_date.Text);
            string strTerms = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);                
            string strName_brand = "";
            bool flag_update;
            for (int i=0; i<dtQuotation_details.Rows.Count; i++)
            {
                strSql = string.Format("Select SS.name AS name_brand FROM (select id,name from {0}cd_brand with(nolock) Union all select id,name from {0}it_customer with(nolock)) SS Where SS.id='{1}'",
                            DBUtility.remote_db, dtQuotation_details.Rows[i]["brand"]);
                strName_brand = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
                flag_update = false;
                //更新舊值
                for (int ii = 0; ii < dgvFind.RowCount; ii++)
                {
                    if (dtReport.Rows[ii]["id_h"].ToString() == txtID.Text && dtReport.Rows[ii]["version"].ToString() ==  txtVersion.Text &&
                        dtReport.Rows[ii]["seq_id"].ToString() == dtQuotation_details.Rows[i]["seq_id"].ToString())
                    {                        
                        dtReport.Rows[ii]["quota_date_h"] = txtDate.Text;
                        dtReport.Rows[ii]["customer_id"] = txtCustomer_id.EditValue;
                        dtReport.Rows[ii]["name_customer"] = txtCust_desc.Text;
                        dtReport.Rows[ii]["address_id"] = txtAddress_id.EditValue;
                        strSql = string.Format(@"Select dbo.fn_getAddress('{0}') as address", txtAddress_id.EditValue);
                        dtReport.Rows[ii]["address"] = strAddress;
                        dtReport.Rows[ii]["term_id"] = txtTerm_id.EditValue;
                        dtReport.Rows[ii]["terms"] = strTerms;
                        dtReport.Rows[ii]["valid_date"] = txtValid_date.Text;
                        dtReport.Rows[ii]["money_id"] = txtMoney_id.EditValue;
                        dtReport.Rows[ii]["contact_h"] = txtContact.Text;
                        dtReport.Rows[ii]["tel"] = txtTel.Text;
                        dtReport.Rows[ii]["fax"] = txtFax.Text;
                        dtReport.Rows[ii]["email"] = txtEmail.Text;
                        if (chkUsd.Checked)
                            dtReport.Rows[ii]["isusd"] = true;    
                        else
                            dtReport.Rows[ii]["isusd"] = false;
                        if (chkHkd.Checked)
                            dtReport.Rows[ii]["ishkd"] = true;
                        else
                            dtReport.Rows[ii]["ishkd"] = false;
                        if (chkRmb.Checked)
                            dtReport.Rows[ii]["isrmb"] = true;
                        else
                            dtReport.Rows[ii]["isrmb"] = false;
                        dtReport.Rows[ii]["seq_id"] = dtQuotation_details.Rows[i]["seq_id"].ToString();
                        dtReport.Rows[ii]["brand"] = dtQuotation_details.Rows[i]["brand"].ToString();
                        dtReport.Rows[ii]["division"] = dtQuotation_details.Rows[i]["division"].ToString();
                        dtReport.Rows[ii]["contact"] = dtQuotation_details.Rows[i]["contact"].ToString();
                        dtReport.Rows[ii]["material"] = dtQuotation_details.Rows[i]["material"].ToString();
                        dtReport.Rows[ii]["size"] = dtQuotation_details.Rows[i]["size"].ToString();
                        dtReport.Rows[ii]["product_desc"] = dtQuotation_details.Rows[i]["product_desc"].ToString();
                        dtReport.Rows[ii]["cust_code"] = dtQuotation_details.Rows[i]["cust_code"].ToString();
                        dtReport.Rows[ii]["cf_code"] = dtQuotation_details.Rows[i]["cf_code"].ToString();
                        dtReport.Rows[ii]["cust_color"] = dtQuotation_details.Rows[i]["cust_color"].ToString();
                        dtReport.Rows[ii]["cf_color"] = dtQuotation_details.Rows[i]["cf_color"].ToString();
                        dtReport.Rows[ii]["price_usd"] = dtQuotation_details.Rows[i]["price_usd"];
                        dtReport.Rows[ii]["price_hkd"] = dtQuotation_details.Rows[i]["price_hkd"];
                        dtReport.Rows[ii]["price_rmb"] = dtQuotation_details.Rows[i]["price_rmb"];
                        dtReport.Rows[ii]["moq"] = dtQuotation_details.Rows[i]["moq"];
                        dtReport.Rows[ii]["price_unit"] = dtQuotation_details.Rows[i]["price_unit"].ToString();
                        dtReport.Rows[ii]["remark_h"] = txtRemark.Text;                            
                        dtReport.Rows[ii]["name_brand"] = strName_brand;

                        dtReport.Rows[ii]["moq_unit"] = dtQuotation_details.Rows[i]["moq_unit"].ToString();
                        dtReport.Rows[ii]["season"] = dtQuotation_details.Rows[i]["season"].ToString();
                        dtReport.Rows[ii]["salesman"] = dtQuotation_details.Rows[i]["salesman"].ToString();
                        dtReport.Rows[ii]["mwq"] = dtQuotation_details.Rows[i]["mwq"];
                        dtReport.Rows[ii]["lead_time_min"] = dtQuotation_details.Rows[i]["lead_time_min"];
                        dtReport.Rows[ii]["lead_time_max"] = dtQuotation_details.Rows[i]["lead_time_max"];
                        dtReport.Rows[ii]["lead_time_unit"] = dtQuotation_details.Rows[i]["lead_time_unit"].ToString();
                        dtReport.Rows[ii]["md_charge"] = dtQuotation_details.Rows[i]["md_charge"];
                        dtReport.Rows[ii]["md_charge_cny"] = dtQuotation_details.Rows[i]["md_charge_cny"].ToString();
                        dtReport.Rows[ii]["moq_for_test"] = dtQuotation_details.Rows[i]["moq_for_test"];
                        dtReport.Rows[ii]["number_enter"] = dtQuotation_details.Rows[i]["number_enter"];
                        dtReport.Rows[ii]["hkd_ex_fty"] = dtQuotation_details.Rows[i]["hkd_ex_fty"];
                        dtReport.Rows[ii]["usd_ex_fty"] = dtQuotation_details.Rows[i]["usd_ex_fty"];
                        dtReport.Rows[ii]["sales_group"] = dtQuotation_details.Rows[i]["sales_group"];

                        dtReport.Rows[ii]["usd_dap"] = dtQuotation_details.Rows[i]["usd_dap"];
                        dtReport.Rows[ii]["usd_lab_test_prx"] = dtQuotation_details.Rows[i]["usd_lab_test_prx"];
                        dtReport.Rows[ii]["ex_fty_hkd"] = dtQuotation_details.Rows[i]["ex_fty_hkd"];
                        dtReport.Rows[ii]["ex_fty_usd"] = dtQuotation_details.Rows[i]["ex_fty_usd"];

                        dtReport.Rows[ii]["discount"] = dtQuotation_details.Rows[i]["discount"];
                        dtReport.Rows[ii]["disc_price_usd"] = dtQuotation_details.Rows[i]["disc_price_usd"];
                        dtReport.Rows[ii]["disc_price_hkd"] = dtQuotation_details.Rows[i]["disc_price_hkd"];
                        dtReport.Rows[ii]["disc_price_rmb"] = dtQuotation_details.Rows[i]["disc_price_rmb"];
                        dtReport.Rows[ii]["disc_hkd_ex_fty"] = dtQuotation_details.Rows[i]["disc_hkd_ex_fty"];
                        dtReport.Rows[ii]["actual_price"] = dtQuotation_details.Rows[i]["actual_price"];
                        dtReport.Rows[ii]["actual_price_type"] = dtQuotation_details.Rows[i]["actual_price_type"].ToString();
                        dtReport.Rows[ii]["die_mould_usd"] = dtQuotation_details.Rows[i]["die_mould_usd"];
                        dtReport.Rows[ii]["die_mould_cny"] = dtQuotation_details.Rows[i]["die_mould_cny"].ToString(); 
                        flag_update = true;
                    }
                }
                
                //插入新增加值
                if (flag_update == false )
                {
                    DataRow dr = dtReport.NewRow();
                    dr["id_h"] = txtID.Text;
                    dr["version"] = txtVersion.Text;
                    dr["seq_id"] = dtQuotation_details.Rows[i]["seq_id"].ToString();
                    dr["quota_date_h"] = txtDate.Text;
                    dr["customer_id"] = txtCustomer_id.EditValue;
                    dr["name_customer"] = txtCust_desc.Text;
                    dr["address_id"] = txtAddress_id.EditValue;                        
                    dr["address"] =strAddress;
                    dr["term_id"] = txtTerm_id.EditValue;                        
                    dr["terms"] = strTerms;
                    dr["valid_date"] = txtValid_date.Text;
                    dr["money_id"] = txtMoney_id.EditValue;
                    dr["contact_h"] = txtContact.Text;
                    dr["tel"] = txtTel.Text;
                    dr["fax"] = txtFax.Text;
                    dr["email"] = txtEmail.Text;
                    if (chkUsd.Checked)
                        dr["isusd"] = true;
                    else
                        dr["isusd"] = false;
                    if (chkHkd.Checked)
                        dr["ishkd"] = true;
                    else
                        dr["ishkd"] = false;
                    if (chkRmb.Checked)
                        dr["isrmb"] = true;
                    else
                        dr["isrmb"] = false;
                    dr["seq_id"] = dtQuotation_details.Rows[i]["seq_id"].ToString();
                    dr["brand"] = dtQuotation_details.Rows[i]["brand"].ToString();
                    dr["division"] = dtQuotation_details.Rows[i]["division"].ToString();
                    dr["contact"] = dtQuotation_details.Rows[i]["contact"].ToString();
                    dr["material"] = dtQuotation_details.Rows[i]["material"].ToString();
                    dr["size"] = dtQuotation_details.Rows[i]["size"].ToString();
                    dr["product_desc"] = dtQuotation_details.Rows[i]["product_desc"].ToString();
                    dr["cust_code"] = dtQuotation_details.Rows[i]["cust_code"].ToString();
                    dr["cf_code"] = dtQuotation_details.Rows[i]["cf_code"].ToString();
                    dr["cust_color"] = dtQuotation_details.Rows[i]["cust_color"].ToString();
                    dr["cf_color"] = dtQuotation_details.Rows[i]["cf_color"].ToString();
                    dr["price_usd"] = dtQuotation_details.Rows[i]["price_usd"];
                    dr["price_hkd"] = dtQuotation_details.Rows[i]["price_hkd"];
                    dr["price_rmb"] = dtQuotation_details.Rows[i]["price_rmb"];
                    dr["moq"] = dtQuotation_details.Rows[i]["moq"];
                    dr["price_unit"] = dtQuotation_details.Rows[i]["price_unit"].ToString();
                    dr["remark_h"] = txtRemark.Text;                       
                    dr["name_brand"] = strName_brand;

                    dr["moq_unit"] = dtQuotation_details.Rows[i]["moq_unit"].ToString();
                    dr["season"] = dtQuotation_details.Rows[i]["season"].ToString();
                    dr["salesman"] = dtQuotation_details.Rows[i]["salesman"].ToString();
                    dr["mwq"] = dtQuotation_details.Rows[i]["mwq"];
                    dr["lead_time_min"] = dtQuotation_details.Rows[i]["lead_time_min"];
                    dr["lead_time_max"] = dtQuotation_details.Rows[i]["lead_time_max"];
                    dr["lead_time_unit"] = dtQuotation_details.Rows[i]["lead_time_unit"].ToString();
                    dr["md_charge"] = dtQuotation_details.Rows[i]["md_charge"];
                    dr["md_charge_cny"] = dtQuotation_details.Rows[i]["md_charge_cny"].ToString();
                    dr["moq_for_test"] = dtQuotation_details.Rows[i]["moq_for_test"];
                    dr["number_enter"] = dtQuotation_details.Rows[i]["number_enter"];
                    dr["hkd_ex_fty"] = dtQuotation_details.Rows[i]["hkd_ex_fty"];
                    dr["usd_ex_fty"] = dtQuotation_details.Rows[i]["usd_ex_fty"]; 
                    dr["sales_group"] = dtQuotation_details.Rows[i]["sales_group"].ToString();

                    dr["usd_dap"] = dtQuotation_details.Rows[i]["usd_dap"];
                    dr["usd_lab_test_prx"] = dtQuotation_details.Rows[i]["usd_lab_test_prx"];
                    dr["ex_fty_hkd"] = dtQuotation_details.Rows[i]["ex_fty_hkd"];
                    dr["ex_fty_usd"] = dtQuotation_details.Rows[i]["ex_fty_usd"];

                    dr["discount"] = dtQuotation_details.Rows[i]["discount"];
                    dr["disc_price_usd"] = dtQuotation_details.Rows[i]["disc_price_usd"];
                    dr["disc_price_hkd"] = dtQuotation_details.Rows[i]["disc_price_hkd"];
                    dr["disc_price_rmb"] = dtQuotation_details.Rows[i]["disc_price_rmb"];
                    dr["disc_hkd_ex_fty"] = dtQuotation_details.Rows[i]["disc_hkd_ex_fty"];
                    dr["actual_price"] = dtQuotation_details.Rows[i]["actual_price"];
                    dr["actual_price_type"] = dtQuotation_details.Rows[i]["actual_price_type"].ToString();
                    dr["die_mould_usd"] = dtQuotation_details.Rows[i]["die_mould_usd"];
                    dr["die_mould_cny"] = dtQuotation_details.Rows[i]["die_mould_cny"].ToString();
                    dtReport.Rows.Add(dr);
                }
            }
            dtReport.AcceptChanges();            
            //重新排序
            dgvFind.Sort(dgvFind.Columns["quotaion_id"], ListSortDirection.Ascending);
           
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                Select_All(true);
            }
            else
            {
                Select_All(false);
            }        
        }

        private void Select_All(bool _flag)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dtFind.Rows.Count; i++)
                {
                    dtFind.Rows[i]["flag_select"] = _flag;
                }
            }
        }

        private void btnExcel_d_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                //ExpToExcel.DataGridViewToExcel(dgvDetails);
                clsQuotation.Export_To_Excel(dgvDetails);
            }
            else
            {
                MessageBox.Show("沒有可匯出到Excel的數據。","提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private string Return_New_Version(string pOldVer)
        {
            string strVer = (Convert.ToInt16(pOldVer) + 1).ToString();
            return strVer;
        }

        private void BTNNEWVER_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0)
            {
                tabControl1.SelectTab(0);
                DialogResult result = MessageBox.Show(string.Format("當前報價單號【{0}】確定是否真的要產生新版本?", txtID.Text), "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strNew_version = Return_New_Version(txtVersion.Text);
                    SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@id",txtID.Text),
                        new SqlParameter("@old_version",txtVersion.Text),
                        new SqlParameter("@new_version",strNew_version),
                        new SqlParameter("@user_id",DBUtility._user_id),
                    };
                  
                  string strSql,strResult;
                  strSql = string.Format(@"Select '1' From dbo.quotation_mostly with(nolock) Where id='{0}' and version='{1}'", txtID.Text, strNew_version);
                  strResult = clsPublicOfCF01.ExecuteSqlReturnObject(strSql);
                  if (strResult != "")
                  {
                      MessageBox.Show("另一用戶已對此報價單做了新版本，請返回查詢!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      return;
                  }
                  int Result = clsPublicOfCF01.ExecuteNonQuery("usp_qt_new_version", paras, true);
                  if (Result > 0)
                  {
                      Find_doc(txtID.Text, strNew_version);
                      for(int i=0;i< dtReport.Rows.Count;i++)
                      {
                          if (dtReport.Rows[i]["id_h"].ToString() == txtID.Text)
                          {
                              dtReport.Rows[i]["version"] = strNew_version;
                          }
                      }
                      MessageBox.Show("已成功生成新的報價單版本", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  else
                      MessageBox.Show(" 產生新的報價單版本失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //編號狀態禁止點擊數據瀏覽頁
            if (mState != "")
            {
                if (e.TabPageIndex == 1)
                {
                    e.Cancel = true;
                }
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            Export_to_Excel("1");//無圖樣
            //if (gridView1.RowCount > 0)
            //{
            //    //bool fileSaved = false; 
            //    SaveFileDialog saveDialog = new SaveFileDialog();
            //    //saveDialog.DefaultExt = "";
            //    saveDialog.Title = "保存EXECL文件";
            //    saveDialog.Filter = "EXECL文件|*.xls";
            //    saveDialog.FilterIndex = 1;
            //    if (saveDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string FileName = saveDialog.FileName;
            //        if (File.Exists(FileName))
            //        {
            //            File.Delete(FileName);
            //        }
            //        int FormatNum;//保存excel文件的格式
            //        string Version;//excel版本號

            //        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //        if (xlApp == null)
            //        {
            //            MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
            //            return;
            //        }
            //        Version = xlApp.Version;//獲取當前使用excel版本號
            //        if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
            //        {
            //            FormatNum = -4143;
            //        }
            //        else //you use excel 2007 or later
            //        {
            //            FormatNum = 56;
            //        }
            //        Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //        Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
            //        SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id", txtID.Text) };
                    
            //        DataTable dtHead = new DataTable();
            //        dtHead = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_info_convert", paras);
            //        //第一行为报表名称
            //        worksheet.Cells[1, 1] = dtHead.Rows[0]["address_id"].ToString(); //標題地址
            //        worksheet.Cells[2, 1] = dtHead.Rows[0]["terms"].ToString();      //條款
            //        worksheet.Cells[2, 11] = dtHead.Rows[0]["cust_info"].ToString();
                    
            //        worksheet.Range["A1:M1"].Merge(0);//合并单元格
            //        worksheet.Rows[1].Font.Size = 9;
            //        worksheet.Rows[1].Font.Bold = true;//粗體
            //        worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        worksheet.Rows[1].RowHeight = 75;
            //        //條款
            //        worksheet.Range["A2:J2"].Merge(0);//合并单元格
            //        worksheet.Rows[2].Font.Size = 9;
            //        worksheet.Rows[2].RowHeight =190;
            //        //客戶信息
            //        worksheet.Range["K2:O2"].Merge(0);//合并单元格 
            //        worksheet.Range["K2:O2"].Font.Bold = true;
            //        worksheet.Rows[3].Font.Size = 9;
            //        worksheet.Rows[3].Font.Bold = true;//粗體                    
                   
            //        cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
            //        new Thread((ThreadStart)delegate
            //        {
            //            wForm.TopMost = true;
            //            wForm.ShowDialog();
            //        }).Start();

            //        //寫入欄位標題                   
            //        for (int i = 0; i < gridView1.Columns.Count; i++)
            //        {
            //            if (gridView1.Columns[i].Visible || gridView1.Columns[i].FieldName == "seq_id" || gridView1.Columns[i].FieldName == "name_brand")
            //            {
            //                worksheet.Cells[3, i + 1] = gridView1.Columns[i].Caption;
            //                if (gridView1.Columns[i].FieldName == "cust_artwork")
            //                {                                
            //                    worksheet.Cells[3, i + 1] = "ArtWork";
            //                }                            
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //        worksheet.Rows[3].RowHeight = 23;
            //        //寫入數值
            //        string field_name;
            //        for (int r = 0; r < gridView1.RowCount; r++)//行
            //        {
            //            for (int i = 0; i < gridView1.Columns.Count; i++) //列
            //            {
            //                if (gridView1.Columns[i].Visible || gridView1.Columns[i].FieldName == "seq_id" || gridView1.Columns[i].FieldName == "name_brand")
            //                {
            //                    field_name = gridView1.Columns[i].FieldName;
            //                    if (field_name == "price_unit") //2017/03/15將H轉成100Pcs
            //                    {
            //                        if (gridView1.GetRowCellValue(r, field_name).ToString() == "H")
            //                            worksheet.Cells[r + 4, i + 1] = "100PCS";
            //                    }
            //                    worksheet.Cells[r + 4, i + 1] = gridView1.GetRowCellValue(r, field_name).ToString();
            //                    worksheet.Rows[r + 4].Font.Size = 10;
            //                    if (field_name == "cust_artwork")
            //                    {
            //                        worksheet.Cells[r + 4, i + 1] = "";
            //                    }
            //                }
            //                else
            //                {
            //                    continue;
            //                }
            //            }
            //            System.Windows.Forms.Application.DoEvents();
            //        }
            //        worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
            //        worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;               
                    
            //        wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            //        if (FileName != "")
            //        {
            //            try
            //            {
            //                workbook.Saved = true;
            //                //workbook.SaveCopyAs(saveFileName);
            //                workbook.SaveAs(FileName, FormatNum);
            //                //fileSaved = true;  
            //            }
            //            catch (Exception ex)
            //            {
            //                //fileSaved = false;  
            //                MessageBox.Show("導出文件出錯或者文件可能已被打開!\n" + ex.Message);
            //            }
            //        }
            //        xlApp.Quit();
            //        GC.Collect();//强行销毁
            //        // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
            //        MessageBox.Show(String.Format("[{0}]匯出EXCEL成功!", txtID.Text), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void cl_discount_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                //折扣前單價
                int row= gridView1.FocusedRowHandle;                
                mdlFormula_Result objDisc = new mdlFormula_Result();
                objDisc.price_usd = clsApp.Return_Float_Value(gridView1.GetRowCellValue(row, "price_usd").ToString());
                objDisc.price_hkd = clsApp.Return_Float_Value(gridView1.GetRowCellValue(row, "price_hkd").ToString());
                objDisc.price_rmb = clsApp.Return_Float_Value(gridView1.GetRowCellValue(row, "price_rmb").ToString());
                objDisc.hkd_ex_fty = clsApp.Return_Float_Value(gridView1.GetRowCellValue(row, "hkd_ex_fty").ToString());

                //返回折扣后單價
                objDisc = clsQuotation.Get_Cust_Formula_Disc(gridView1.GetRowCellValue(row, "brand").ToString(),
                                                             gridView1.GetRowCellValue(row, "discount").ToString(), objDisc, 
                                                             gridView1.GetRowCellValue(row, "price_unit").ToString());
                gridView1.SetRowCellValue(row, "disc_price_usd", objDisc.disc_price_usd.ToString());
                gridView1.SetRowCellValue(row, "disc_price_hkd", objDisc.disc_price_hkd.ToString());
                gridView1.SetRowCellValue(row, "disc_price_rmb", objDisc.disc_price_rmb.ToString());
                gridView1.SetRowCellValue(row, "disc_hkd_ex_fty", objDisc.disc_hkd_ex_fty.ToString());
            }
        }

        private void txtDate1_Leave(object sender, EventArgs e)
        {
            if (txtDate1.Text != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(txtDate1.Text))
                {
                    MessageBox.Show("日期格式不正確！", "提示信息");
                    txtDate1.Focus();
                    return;
                }
            }            
            txtDate2.Text = txtDate1.Text;
        }

        private void txtDate2_Leave(object sender, EventArgs e)
        {
            if (txtDate2.Text != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(txtDate2.Text))
                {
                    MessageBox.Show("日期格式不正確！", "提示信息");
                    txtDate2.Focus();
                    return;
                }
            }
        }

        private void txtCrtim1_Leave(object sender, EventArgs e)
        {
            if (txtCrtim1.Text != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(txtCrtim1.Text))
                {
                    MessageBox.Show("日期格式不正確！", "提示信息");
                    txtCrtim1.Focus();
                    return;
                }
            }
            txtCrtim2.Text = txtCrtim1.Text;
        }

        private void txtCrtim2_Leave(object sender, EventArgs e)
        {
            if (txtCrtim2.Text != "    /  /")
            {
                if (!clsValidRule.CheckDateFormat(txtCrtim2.Text))
                {
                    MessageBox.Show("日期格式不正確！", "提示信息");
                    txtCrtim2.Focus();
                    return;
                }
            }
        }


        private void txtSales_group_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");                
            }
        }

        private void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTemp_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSeason_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCust_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCust_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCf_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCf_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMo_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            using (frmQuotation_Actual_Price ofrm = new frmQuotation_Actual_Price(txtMoney_id.EditValue.ToString()))
            {
                ofrm.ShowDialog();
                string strSelect, field_name;                
                strSelect = ofrm.selected_price;
                if (strSelect == "")
                {
                    return;
                }                
               
                field_name = "";
                switch (strSelect)
                {
                    case "HKD":
                        field_name = "disc_price_hkd";
                        break;
                    case "HKD EX-FTY":
                        field_name = "disc_hkd_ex_fty";
                        break;
                    case "USD":
                        field_name = "disc_price_usd";
                        break;
                    case "USD EX-FTY":
                        field_name = "usd_ex_fty";
                        break;
                    case "RMB":
                        field_name = "disc_price_rmb";
                        break;
                }
                if (field_name == "")
                {
                    MessageBox.Show("請選擇正確的貨幣（HKD,USD,RMB）!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, "actual_price", dtQuotation_details.Rows[i][field_name]);
                    gridView1.SetRowCellValue(i, "actual_price_type", strSelect);
                }
            }
        }

        private void get_print_data()
        {
            /*2021/04/01改為報價單日期加3個月,
             *New code:dbo.fn_getTermRemark(A.term_id, A.quota_date, '0')
             *original code:dbo.fn_getTermRemark(A.term_id, A.valid_date, '0')
            */
            string strsql = string.Format(
          @"SELECT A.id as id_h,A.version,Convert(char(10),A.quota_date,120) as quota_date_h,A.customer_id,A.address_id,A.term_id,A.remark as remark_h,A.id_referred,
            dbo.fn_getTermRemark(A.term_id,A.quota_date,'0') as terms,dbo.fn_getTermRemark(A.term_id,A.quota_date,'1') as terms_other,
            dbo.fn_getAddress(A.address_id) as address,Convert(char(10),A.valid_date) as valid_date,A.money_id,
            A.contact as contact_h,A.tel,A.fax,A.email,A.isusd,A.ishkd,A.isrmb,B.seq_id,B.brand,SS.name AS name_brand,B.division,B.contact,B.material,B.size,
            B.product_desc,B.cust_code,B.cf_code,B.cust_color,B.cf_color,B.price_usd,B.price_hkd,B.price_rmb,B.moq,B.price_unit,Isnull(B.remark,'') as remark,
            ISNULL(C.name,'') AS name_customer,B.moq_unit,B.season,B.salesman,B.mwq,B.lead_time_min,B.lead_time_max,B.lead_time_unit,B.md_charge,B.md_charge_cny, 
            B.number_enter,B.hkd_ex_fty,B.usd_ex_fty,B.usd_dap,B.usd_lab_test_prx,B.ex_fty_hkd,B.ex_fty_usd,B.moq_for_test,B.sales_group,
            B.discount,B.disc_price_usd,B.disc_price_hkd,B.disc_price_rmb,B.disc_hkd_ex_fty,B.actual_price,B.actual_price_type,B.die_mould_usd,B.die_mould_cny,
            CASE WHEN Isnull(D.polo_care,'')='' THEN '' ELSE dbo.fn_getPoloCare(D.polo_care) END AS polo_care,ISNULL(D.moq_desc,'') AS moqdesc,
            dbo.fn_get_picture_name_of_artwork('0000',Substring(Isnull(B.cf_code,''),1,7),'OUT') AS picture_name,Isnull(B.cust_artwork,'') AS cust_artwork,D.termremark        
            FROM dbo.quotation_mostly A with(nolock)
                INNER JOIN dbo.quotation_details B with(nolock) ON A.id=B.id And A.version=B.version
                LEFT JOIN dbo.quotation D with(nolock) ON B.temp_code=D.temp_code
                LEFT JOIN {0}it_customer C with(nolock) ON C.within_code='0000' and A.customer_id=C.id COLLATE Chinese_Taiwan_Stroke_CI_AS
                LEFT JOIN v_brand_customer SS ON ISNULL(B.brand,'')=SS.id COLLATE Chinese_Taiwan_Stroke_CI_AS
            WHERE A.id='{1}' ORDER BY A.id,B.seq_id ", DBUtility.remote_db, txtID.Text);
          DataTable dtPrint = clsPublicOfCF01.GetDataTable(strsql);
          if (dtPrint.Rows.Count > 0)
          {
              for (int i = 0; i < dtPrint.Rows.Count; i++)
              {
                  if(string.IsNullOrEmpty(dtPrint.Rows[i]["picture_name"].ToString()) && !string.IsNullOrEmpty(dtPrint.Rows[i]["cust_artwork"].ToString()))
                  {
                      dtPrint.Rows[i]["picture_name"] =mImagePath + dtPrint.Rows[i]["cust_artwork"];
                  }
              }
              Print(dtPrint);
          }
          else
          {
              MessageBox.Show("沒有要列印的數據!");
          }
        }

        private void btnAddOther_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text.Trim())) // 有內容
            {
                chkSelectAll.Checked = false;
                gridView1.AddNewRow();//新增
                Edit_Columns(false);
            }
            else
            {
                MessageBox.Show("報價單編號不可爲空!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomer_id.Focus();
            }
        }

        private void Edit_Columns(bool _flag)
        {
            gridView1.Columns["brand"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["division"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["contact"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["material"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["size"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["product_desc"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["cust_code"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["cf_code"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["cust_color"].OptionsColumn.ReadOnly = _flag;
            gridView1.Columns["cf_color"].OptionsColumn.ReadOnly = _flag;   
        }

        private void frmQuotation_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
             clsApp = null;
             clsConErp = null;
             dtQuotation_mostly = null;
             dtQuotation_details = null;
             dtTempDel = null;
             dtTerm1 = null;
             dtAddress1 = null;
             dtFind = null;
             dtReport = null;        
             dsCopy = null ;
             mList = null;
        }

        public DataGridViewTextBoxEditingControl CellEdit = null;

        private void dgvDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dgvDetails.CurrentCellAddress.X == 84)
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
            }
        }

        private void Cells_KeyPress(object sender, KeyPressEventArgs e) //自定义事件
        {
            if ((this.dgvDetails.CurrentCellAddress.X == 84) )
            {
                if (e.KeyChar=='\b')
                {
                    if (CellEdit.Text.Length == 1)
                        CellEdit.Text = "0.000";
                }

                //判斷輸入的是否為非數值类型。
                if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                {
                    e.Handled = true;
                }

                //小数点的处理。
                if ((int)e.KeyChar == 46)      //小数点
                {
                    if (CellEdit.Text.Length <= 0)
                        e.Handled = true;   //小数点不能在第一位
                    else
                    {
                        float f;
                        float oldf;
                        bool b1 = false, b2 = false;
                        b1 = float.TryParse(CellEdit.Text, out oldf);
                        b2 = float.TryParse(CellEdit.Text + e.KeyChar.ToString(), out f);
                        if (b2 == false)
                        {
                            if (b1 == true)
                                e.Handled = true;
                            else
                                e.Handled = false;
                        }
                    }
                }
                //if (e.KeyChar == 13)
                //{
                //    SendKeys.Send("{TAB}");
                //}

            }
        }

        private void BTNSAVE_PRICE_Click(object sender, EventArgs e)
        {
            txtProductDesc.Focus();
            if (dtFind.Rows.Count == 0)
            {
                return;
            }
            if (mState != "")
            {
                MessageBox.Show("新增或編輯狀態下不可以使用此功能!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            //判斷是否有選中記錄
            DataRow[] drows = dtFind.Select("flag_select=true");
            if (drows.Length==0)
            {
                MessageBox.Show("請至少選擇一條記錄!", "提示信息");
                return;
            }
            drows = null;//釋放所點內存 

            bool isEmpty_Price_Kind = false;  
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {                    
                    if (float.Parse(dtFind.Rows[i]["price_salesperson"].ToString()) > 0)
                    {
                        if (string.IsNullOrEmpty(dtFind.Rows[i]["price_kind"].ToString()))
                        {
                            isEmpty_Price_Kind = true;
                            break;
                        }
                        else
                        {
                            isEmpty_Price_Kind = false;
                        }
                    }           
                }
            }
            if (isEmpty_Price_Kind)
            {
                MessageBox.Show("單價類型不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            string strSql, strIsSave="", strTempCode,strPriceKind,strRemarkSales;             
            float fltPriceSales = 0.00f;
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dtFind.Rows[i]["flag_select"].ToString() == "True")
                {                                         
                    fltPriceSales = clsApp.Return_Float_Value(dtFind.Rows[i]["price_salesperson"].ToString());
                    strPriceKind = dtFind.Rows[i]["price_kind"].ToString();
                    strRemarkSales = dtFind.Rows[i]["remark_salesperson"].ToString();
                    strTempCode = dtFind.Rows[i]["temp_code"].ToString();
                    strSql = string.Format(@"Update quotation SET price_salesperson={0},price_kind='{1}',remark_salesperson='{2}' WHERE temp_code='{3}'", fltPriceSales, strPriceKind, strRemarkSales, strTempCode);
                    strIsSave = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
                    if (strIsSave != "")
                    {
                        break;
                    }                    
                }
            }
            if (strIsSave == "")            
                MessageBox.Show("當前記錄更新成功！", "提示信息");            
            else
                MessageBox.Show("當前記錄更新失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        }

        //private void clCf_code_Leave(object sender, EventArgs e)
        //{
        //    int curRow = gridView1.FocusedRowHandle;
        //    string strCf_Code=gridView1.GetRowCellDisplayText(curRow, "cf_code");

        //    if (mState != "" && !string.IsNullOrEmpty(strCf_Code))
        //    {                
        //        if (!clsQuotation.Check_Artwork(gridView1.GetRowCellDisplayText(curRow, "cf_code")))
        //        {
        //            MessageBox.Show("CF圖樣代碼不存在！", "提示信息");
        //            //gridView1.SetRowCellValue(curRow, "cf_code", "");
        //        }
        //    }
        //}

        private void clCust_artwork_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string cust_artwork_path = clsQuotation.cust_artwork_path; 
            if (mState == "NEW" || mState == "EDIT")
            {
                OpenFileDialog openFile = new OpenFileDialog()
                {
                    Filter = "Files Path|*.BMP;*.JPG",
                    RestoreDirectory = true,
                    Title = "客戶圖樣相關文檔",
                    InitialDirectory = cust_artwork_path /*初始測試報告路徑      */
                };
                openFile.ShowDialog();
                int curRow = gridView1.FocusedRowHandle;
                string strFile = openFile.FileName;
                if (strFile != "")
                {
                    gridView1.SetRowCellValue(curRow, "cust_artwork", strFile);
                }
            }
        }

        private void BTNEXCEL2_Click(object sender, EventArgs e)
        {
            Export_to_Excel("2");//有圖樣
        }

        private void BTNEXCEL_TOMMY_Click(object sender, EventArgs e)
        {
            Export_To_Excel();//TOMMY專用
        }

        /// <summary>
        /// 參數：strType=1無圖樣;strType=2有圖樣
        /// </summary>
        /// <param name="strType"></param>
        private void Export_to_Excel(string strType)
        {
            if (gridView1.RowCount > 0)
            {
                //bool fileSaved = false; 
                SaveFileDialog saveDialog = new SaveFileDialog() { 
                    /*saveDialog.DefaultExt = "";*/
                    Title = "保存EXECL文件", 
                    Filter = "EXECL文件|*.xls", 
                    FilterIndex = 1 
                };
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
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
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
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id", txtID.Text) };

                    DataTable dtHead = new DataTable();
                    dtHead = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_info_convert", paras);
                    //第一行为报表名称
                    worksheet.Cells[1, 1] = dtHead.Rows[0]["address_id"].ToString(); //標題地址
                    worksheet.Cells[2, 1] = dtHead.Rows[0]["terms"].ToString();      //條款
                    worksheet.Cells[2, 11] = dtHead.Rows[0]["cust_info"].ToString();

                    worksheet.Range["A1:M1"].Merge(0);//合并单元格
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體
                    worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].RowHeight = 75;
                    //條款
                    worksheet.Range["A2:J2"].Merge(0);//合并单元格
                    worksheet.Rows[2].Font.Size = 9;
                    worksheet.Rows[2].RowHeight = 190;
                    //客戶信息
                    worksheet.Range["K2:O2"].Merge(0);//合并单元格 
                    worksheet.Range["K2:O2"].Font.Bold = true;
                    worksheet.Rows[3].Font.Size = 9;
                    worksheet.Rows[3].Font.Bold = true;//粗體                    

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();

                    //寫入欄位標題                   
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        //列是可見的或都列名是(隱藏的列seq_id，name_brand)
                        if (gridView1.Columns[i].Visible || gridView1.Columns[i].FieldName == "seq_id" || gridView1.Columns[i].FieldName == "name_brand")
                        {
                            worksheet.Cells[3, i + 1] = gridView1.Columns[i].Caption;
                            if (gridView1.Columns[i].FieldName == "cust_artwork")
                            {
                                worksheet.Cells[3, i + 1] = "ArtWork";
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    worksheet.Rows[3].RowHeight = 23;

                    //寫入數值
                    string field_name, rang = "";
                    string pictrue_path = "";
                    string strSql = "";
                    DataTable dt = new DataTable();

                    for (int r = 0; r < gridView1.RowCount; r++)//行
                    {
                        if (strType == "2")
                        {
                            //圖片路徑,有CF圖樣以CF圖樣為準，沒有就以客戶圖樣為準
                            if (!string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(r, "cf_code")))
                            {
                                strSql = string.Format(
                                @"Select TOP 1 Isnull(picture_name,'') as picture_name From {0}cd_pattern_details with(nolock)
                            Where within_code='0000' and id='{1}'", DBUtility.remote_db, gridView1.GetRowCellDisplayText(r, "cf_code"));
                                dt = clsPublicOfCF01.GetDataTable(strSql);
                                if (dt.Rows.Count > 0)
                                {
                                    pictrue_path = @"\\192.168.3.12\cf_artwork\Artwork\" + dt.Rows[0]["picture_name"];
                                }
                                else
                                {
                                    pictrue_path = "";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(r, "cust_artwork")))
                                {
                                    pictrue_path = "";
                                }
                                else
                                {
                                    pictrue_path = gridView1.GetRowCellDisplayText(r, "cust_artwork");
                                }
                            }
                            worksheet.Columns[11].ColumnWidth = 11;//圖樣
                        }

                        for (int i = 0; i < gridView1.Columns.Count; i++) //列
                        {
                            if (gridView1.Columns[i].Visible || gridView1.Columns[i].FieldName == "seq_id" || gridView1.Columns[i].FieldName == "name_brand")
                            {
                                field_name = gridView1.Columns[i].FieldName;
                                if (field_name == "price_unit") //2017/03/15將H轉成100Pcs
                                {
                                    if (gridView1.GetRowCellValue(r, field_name).ToString() == "H")
                                    {
                                        worksheet.Cells[r + 4, i + 1] = "100PCS";
                                    }
                                }
                                worksheet.Cells[r + 4, i + 1] = gridView1.GetRowCellValue(r, field_name).ToString();
                                worksheet.Rows[r + 4].Font.Size = 10;

                                
                                if (field_name == "cust_artwork")
                                {
                                    if (strType == "2")
                                    {
                                        worksheet.Cells[r + 4, i + 1] = "";
                                        rang = "K" + (r + 4);
                                        if (File.Exists(pictrue_path))
                                        {
                                            worksheet.Rows[r + 4].RowHeight = 70;
                                       clsQuotation.InsertPicture(rang, worksheet, pictrue_path);//插入圖片
                                        }
                                    }
                                    else
                                    {
                                        worksheet.Cells[r + 4, i + 1] = "";
                                    }
                                }

                            }
                            else
                            {
                                continue;
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                    if (strType == "2")
                    {
                        worksheet.Columns[11].ColumnWidth = 12;
                    }
                    worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

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
                    MessageBox.Show(String.Format("[{0}]匯出EXCEL成功!", txtID.Text), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///// 将图片插入到指定的单元格位置，并设置图片的宽度和高度。
        ///// 注意：图片必须是绝对物理路径
        ///// </summary>
        ///// <param name="RangeName">单元格名称，例如：B4</param>
        ///// <param name="PicturePath">要插入图片的绝对路径。</param>
        //private static void InsertPicture(string RangeName, Microsoft.Office.Interop.Excel._Worksheet sheet, string PicturePath)
        //{
        //    Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(RangeName, Type.Missing);
        //    rng.Select();
        //    try
        //    {
        //        sheet.Shapes.AddPicture(PicturePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue,
        //           Convert.ToSingle(rng.Left) + 5, Convert.ToSingle(rng.Top) + 5, rng.Width - 5, rng.Height - 5);   //插入图片 
        //    }
        //    catch (Exception E)
        //    {
        //        MessageBox.Show(E.Message.ToString());
        //    }
        //}


        /// <summary>
        /// TOMMY專用;strType=2有圖樣
        /// </summary>
        /// <param name="strType"></param>
        private void Export_To_Excel()
        {
            if (gridView1.RowCount > 0)
            {
                //bool fileSaved = false; 
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    /*saveDialog.DefaultExt = "";*/
                    Title = "保存EXECL文件",
                    Filter = "EXECL文件|*.xls",
                    FilterIndex = 1
                };
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
                        MessageBox.Show("无法创建Excel对象,可能您的机子未安装Excel");
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
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id", txtID.Text) };

                    DataTable dtHead = new DataTable();
                    dtHead = clsPublicOfCF01.ExecuteProcedureReturnTable("usp_quotation_info_convert", paras);
                    //第一行为报表名称
                    worksheet.Cells[1, 1] = dtHead.Rows[0]["address_id"].ToString(); //標題地址
                    worksheet.Cells[2, 1] = dtHead.Rows[0]["terms"].ToString();      //條款
                    worksheet.Cells[2, 11] = dtHead.Rows[0]["cust_info"].ToString();

                    worksheet.Range["A1:M1"].Merge(0);//合并单元格
                    worksheet.Rows[1].Font.Size = 9;
                    worksheet.Rows[1].Font.Bold = true;//粗體
                    worksheet.Rows[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].RowHeight = 75;
                    //條款
                    worksheet.Range["A2:J2"].Merge(0);//合并单元格
                    worksheet.Rows[2].Font.Size = 9;
                    worksheet.Rows[2].RowHeight = 190;
                    //客戶信息
                    worksheet.Range["K2:O2"].Merge(0);//合并单元格 
                    worksheet.Range["K2:O2"].Font.Bold = true;
                    worksheet.Rows[3].Font.Size = 9;
                    worksheet.Rows[3].Font.Bold = true;//粗體                    

                    cf01.Forms.frmProgress wForm = new cf01.Forms.frmProgress();
                    new Thread((ThreadStart)delegate
                    {
                        wForm.TopMost = true;
                        wForm.ShowDialog();
                    }).Start();

                    //寫入欄位標題
                    worksheet.Cells[3, 1] = "Brand";
                    worksheet.Cells[3, 2] = "Season";
                    worksheet.Cells[3, 3] = "Division";
                    worksheet.Cells[3, 4] = "Material";
                    worksheet.Cells[3, 5] = "Size";
                    worksheet.Cells[3, 6] = "Desc.";
                    worksheet.Cells[3, 7] = "Customer Code";
                    worksheet.Cells[3, 8] = "CF Code#/Artwork Code";
                    worksheet.Cells[3, 9] = "Customer Colour";
                    worksheet.Cells[3, 10] = "CF Colour";
                    worksheet.Cells[3, 11] = "Ex-fty HK USD$";
                    worksheet.Cells[3, 12] = "Ex-fty HK HKD$";
                    worksheet.Cells[3, 13] = "Unit";
                    worksheet.Cells[3, 14] = "ArtWork";
                    worksheet.Cells[3, 15] = "MOQ";
                    worksheet.Cells[3, 16] = "MWQ";
                    worksheet.Cells[3, 17] = "MOQ Unit";
                    worksheet.Cells[3, 18] = "Lead Time (Min)";
                    worksheet.Cells[3, 19] = "Lead Time (Max)";
                    worksheet.Cells[3, 20] = "Lead Time Unit";
                    worksheet.Cells[3, 21] = "Mould Engraving Charge";//Delelopment Charge
                    worksheet.Cells[3, 22] = "remark";
              
                    worksheet.Cells[3, 23] = "Range1";
                    worksheet.Cells[3, 24] = "Price USD1";
                    worksheet.Cells[3, 25] = "Price HKD1";
                    worksheet.Cells[3, 26] = "Range2";
                    worksheet.Cells[3, 27] = "Price USD2";
                    worksheet.Cells[3, 28] = "Price HKD2";
                    worksheet.Cells[3, 29] = "Range3";
                    worksheet.Cells[3, 30] = "Price USD3";
                    worksheet.Cells[3, 31] = "Price HKD3";
                    worksheet.Cells[3, 32] = "Range4";
                    worksheet.Cells[3, 33] = "Price USD4";
                    worksheet.Cells[3, 34] = "Price HKD4";
                    worksheet.Cells[3, 35] = "Range5";
                    worksheet.Cells[3, 36] = "Price USD5";
                    worksheet.Cells[3, 37] = "Price HKD5";
                    worksheet.Cells[3, 38] = "Unit (Range)";
                    worksheet.Rows[3].RowHeight = 40;
                    worksheet.Rows[3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    //標題自動換行
                    Microsoft.Office.Interop.Excel.Range Range1 = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A3", "AL3");
                    Range1.WrapText = true;

                    //寫入數值
                    string field_name, rang = "";
                    string pictrue_path = "";
                    string strSql = "";
                    float lf_finish_price_usd = 0.0000f;
                   
                    DataTable dt = new DataTable();

                    for (int r = 0; r < gridView1.RowCount; r++)//行
                    {
                        
                        if ("2" == "2")
                        {
                            //圖片路徑,有CF圖樣以CF圖樣為準，沒有就以客戶圖樣為準
                            if (!string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(r, "cf_code")))
                            {
                                strSql = string.Format(
                                @"Select TOP 1 Isnull(picture_name,'') as picture_name From {0}cd_pattern_details with(nolock)
                                  Where within_code='0000' and id='{1}'", DBUtility.remote_db, gridView1.GetRowCellDisplayText(r, "cf_code"));
                                dt = clsPublicOfCF01.GetDataTable(strSql);
                                if (dt.Rows.Count > 0)
                                {
                                    pictrue_path = @"\\192.168.3.12\cf_artwork\Artwork\" + dt.Rows[0]["picture_name"];
                                }
                                else
                                {
                                    pictrue_path = "";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(gridView1.GetRowCellDisplayText(r, "cust_artwork")))
                                {
                                    pictrue_path = "";
                                }
                                else
                                {
                                    pictrue_path = gridView1.GetRowCellDisplayText(r, "cust_artwork");
                                }
                            }
                            worksheet.Columns[14].ColumnWidth = 11;//圖樣
                        }

                        //列
                        worksheet.Cells[r + 4, 1] = gridView1.GetRowCellValue(r, "name_brand").ToString();
                        worksheet.Cells[r + 4, 2] = gridView1.GetRowCellValue(r, "season").ToString();
                        worksheet.Cells[r + 4, 3] = gridView1.GetRowCellValue(r, "division").ToString();
                        worksheet.Cells[r + 4, 4] = gridView1.GetRowCellValue(r, "material").ToString();
                        worksheet.Cells[r + 4, 5] = gridView1.GetRowCellValue(r, "size").ToString();
                        worksheet.Cells[r + 4, 6] = gridView1.GetRowCellValue(r, "product_desc").ToString();
                        worksheet.Cells[r + 4, 7] = gridView1.GetRowCellValue(r, "cust_code").ToString();
                        worksheet.Cells[r + 4, 8] = gridView1.GetRowCellValue(r, "cf_code").ToString();
                        worksheet.Cells[r + 4, 9] = gridView1.GetRowCellValue(r, "cust_color").ToString();
                        worksheet.Cells[r + 4, 10] = gridView1.GetRowCellValue(r, "cf_color").ToString();
                        worksheet.Cells[r + 4, 11] = gridView1.GetRowCellValue(r, "usd_ex_fty").ToString();
                        worksheet.Cells[r + 4, 12] = gridView1.GetRowCellValue(r, "hkd_ex_fty").ToString();
                        worksheet.Cells[r + 4, 13] = gridView1.GetRowCellValue(r, "price_unit").ToString();
                        if (gridView1.GetRowCellValue(r, "price_unit").ToString() == "H")
                        {
                            worksheet.Cells[r + 4, 13] = "100PCS";
                        }
                        //插入圖片
                        worksheet.Cells[r + 4, 14] = "";
                        rang = "N" + (r + 4);
                        if (File.Exists(pictrue_path))
                        {
                            worksheet.Rows[r + 4].RowHeight = 70;
                            clsQuotation.InsertPicture(rang, worksheet, pictrue_path);//插入圖片
                        }
                        //
                        worksheet.Cells[r + 4, 15] = gridView1.GetRowCellValue(r, "moq").ToString();
                        worksheet.Cells[r + 4, 16] = gridView1.GetRowCellValue(r, "mwq").ToString();
                        worksheet.Cells[r + 4, 17] = gridView1.GetRowCellValue(r, "moq_unit").ToString();
                        worksheet.Cells[r + 4, 18] = gridView1.GetRowCellValue(r, "lead_time_min").ToString();
                        worksheet.Cells[r + 4, 19] = gridView1.GetRowCellValue(r, "lead_time_max").ToString();
                        worksheet.Cells[r + 4, 20] = gridView1.GetRowCellValue(r, "lead_time_unit").ToString();
                        worksheet.Cells[r + 4, 21] = String.Format("{0}/{1}", gridView1.GetRowCellValue(r, "md_charge"), gridView1.GetRowCellValue(r, "md_charge_cny"));
                        worksheet.Cells[r + 4, 22] = gridView1.GetRowCellValue(r, "remark").ToString();

                        SqlParameter[] spars = new SqlParameter[]{
                            new SqlParameter("@temp_code",gridView1.GetRowCellValue(r, "temp_code").ToString()),
                            new SqlParameter("@brand_id",gridView1.GetRowCellValue(r, "brand").ToString())                        
                        };
                        dt =clsPublicOfCF01.ExecuteProcedureReturnTable("usp_get_price_range", spars);
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            switch (k)
                            {
                                case 0:
                                    worksheet.Cells[r + 4, 23] = string.Format("{0}~{1}", dt.Rows[k]["range_begin"], dt.Rows[k]["range_end"]);                                    
                                    lf_finish_price_usd = clsApp.Return_Float_Value_4(gridView1.GetRowCellValue(r, "usd_ex_fty").ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["cost_lab_test"].ToString()) / clsApp.Return_Float_Value(dt.Rows[k]["range_begin"].ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["price_add"].ToString());
                                    worksheet.Cells[r + 4, 24] = Math.Round(lf_finish_price_usd, 2).ToString();//range_price_usd
                                    worksheet.Cells[r + 4, 25] = Math.Round(Math.Round(lf_finish_price_usd, 2) * clsApp.Return_Float_Value(dt.Rows[k]["rate"].ToString()), 2).ToString(); //range_price_hkd
                                    break;
                                case 1:
                                    worksheet.Cells[r + 4, 26] = string.Format("{0}~{1}", dt.Rows[k]["range_begin"], dt.Rows[k]["range_end"]);
                                    lf_finish_price_usd = clsApp.Return_Float_Value_4(gridView1.GetRowCellValue(r, "usd_ex_fty").ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["cost_lab_test"].ToString()) / clsApp.Return_Float_Value(dt.Rows[k]["range_begin"].ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["price_add"].ToString());
                                    worksheet.Cells[r + 4, 27] = Math.Round(lf_finish_price_usd, 2).ToString();//range_price_usd
                                    worksheet.Cells[r + 4, 28] = Math.Round(Math.Round(lf_finish_price_usd, 2) * clsApp.Return_Float_Value(dt.Rows[k]["rate"].ToString()), 2).ToString(); //range_price_hkd
                                    break;
                                case 2:
                                    worksheet.Cells[r + 4, 29] = string.Format("{0}~{1}", dt.Rows[k]["range_begin"], dt.Rows[k]["range_end"]);
                                    lf_finish_price_usd = clsApp.Return_Float_Value_4(gridView1.GetRowCellValue(r, "usd_ex_fty").ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["cost_lab_test"].ToString()) / clsApp.Return_Float_Value(dt.Rows[k]["range_begin"].ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["price_add"].ToString());
                                    worksheet.Cells[r + 4, 30] = Math.Round(lf_finish_price_usd, 2).ToString();//range_price_usd
                                    worksheet.Cells[r + 4, 31] = Math.Round(Math.Round(lf_finish_price_usd, 2) * clsApp.Return_Float_Value(dt.Rows[k]["rate"].ToString()), 2).ToString(); //range_price_hkd
                                    break;
                                case 3:
                                    worksheet.Cells[r + 4, 32] = string.Format("{0}~{1}", dt.Rows[k]["range_begin"], dt.Rows[k]["range_end"]);
                                    lf_finish_price_usd = clsApp.Return_Float_Value_4(gridView1.GetRowCellValue(r, "usd_ex_fty").ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["cost_lab_test"].ToString()) / clsApp.Return_Float_Value(dt.Rows[k]["range_begin"].ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["price_add"].ToString());
                                    worksheet.Cells[r + 4, 33] = Math.Round(lf_finish_price_usd, 2).ToString();//range_price_usd
                                    worksheet.Cells[r + 4, 34] = Math.Round(Math.Round(lf_finish_price_usd, 2) * clsApp.Return_Float_Value(dt.Rows[k]["rate"].ToString()), 2).ToString(); //range_price_hkd
                                    break;
                                case 4:
                                    worksheet.Cells[r + 4, 35] = string.Format("{0}~{1}", dt.Rows[k]["range_begin"], dt.Rows[k]["range_end"]);
                                    lf_finish_price_usd = clsApp.Return_Float_Value_4(gridView1.GetRowCellValue(r, "usd_ex_fty").ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["cost_lab_test"].ToString()) / clsApp.Return_Float_Value(dt.Rows[k]["range_begin"].ToString()) + clsApp.Return_Float_Value(dt.Rows[k]["price_add"].ToString());
                                    worksheet.Cells[r + 4, 36] = Math.Round(lf_finish_price_usd, 2).ToString();//range_price_usd
                                    worksheet.Cells[r + 4, 37] = Math.Round(Math.Round(lf_finish_price_usd, 2) * clsApp.Return_Float_Value(dt.Rows[k]["rate"].ToString()), 2).ToString(); //range_price_hkd
                                    break;
                                default :
                                    break ;
                            }
                        }
                        if (dt.Rows.Count > 0)
                        {
                            worksheet.Cells[r + 4, 38] = dt.Rows[0]["unit_code"].ToString();
                        }
                        worksheet.Rows[r + 4].Font.Size = 10;
                        System.Windows.Forms.Application.DoEvents();
                    }
                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                    worksheet.Columns[14].ColumnWidth = 12;                    
                    worksheet.Columns[1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Columns[11].ColumnWidth = 7;
                    worksheet.Columns[12].ColumnWidth = 7;
                    worksheet.Columns[13].ColumnWidth = 7;
                    worksheet.Columns[15].ColumnWidth = 5;
                    worksheet.Columns[16].ColumnWidth = 5;
                    worksheet.Columns[17].ColumnWidth = 5;
                    worksheet.Columns[18].ColumnWidth = 5;
                    worksheet.Columns[19].ColumnWidth = 5;
                    worksheet.Columns[21].ColumnWidth = 11;
                    worksheet.Columns[38].ColumnWidth = 6;  
                    //畫边框线
                    //获取Excel多个单元格区域
                    string range_right = string.Format("AL{0}",  gridView1.RowCount + 3);//右下角座標
                    Microsoft.Office.Interop.Excel.Range excelRange = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range("A3", range_right);
                    //单元格边框线类型(线型,虚线型)
                    excelRange.Borders.LineStyle = 1;
                    excelRange.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

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
                    MessageBox.Show(String.Format("[{0}]匯出EXCEL成功!", txtID.Text), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("當前資料為空,請首先查詢出數據!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTestReport_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount ==0 )
            {
                return;
            }
            int li_currentRow = dgvDetails.CurrentRow.Index;
            if(li_currentRow<0)
            {
                return;
            }
            string ls_cust_code = dtFind.Rows[li_currentRow]["cust_code"].ToString();
            string ls_cust_color = dtFind.Rows[li_currentRow]["cust_color"].ToString();            
            if (!string.IsNullOrEmpty(ls_cust_code))
            {
                clsTestExcel.Open_Test_Report(ls_cust_code, ls_cust_color);                
            }           
        }
     

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtFind.Rows.Count == 0)
            {
                return;
            }
            int li_currentRow = dgvDetails.CurrentCell.RowIndex;
            if (li_currentRow >= 0)
            {
                string ls_cust_code = dtFind.Rows[li_currentRow]["cust_code"].ToString();
                string ls_cust_color = dtFind.Rows[li_currentRow]["cust_color"].ToString();
                string ls_sql = string.Format(
                    @"Select Top 1 Isnull(test_report_path,'') as test_report_path 
                From dbo.bs_test_excel with(nolock) 
                Where trim_code='{0}' and finish_name='{1}'", ls_cust_code, ls_cust_color);
                lblTestReportPath.Text = clsPublicOfCF01.ExecuteSqlReturnObject(ls_sql);
            }
        }

    }
}
