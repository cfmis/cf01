using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Threading;
using cf01.Forms;
using cf01.Reports;
using cf01.ModuleClass;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmArtworkSearch : Form
    {
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        clsCommonUse commUse = new clsCommonUse();

        DataTable tbProduct_type;
        DataTable tbMateriel_type;
        DataTable tbGoods_type;
        DataTable tbRange_size;
        DataTable tbBrand;
        DataTable tbArtwork;
        DataSet ds;

        public static DataTable tbDetails;
        public static DataTable dtTemp_details;//顯示祥細表單調用此對象
        public static DataTable tbReport;

        public static string str_language = "0";

        public frmArtworkSearch()
        {
            InitializeComponent();
            str_language = DBUtility._language;

            tbReport = new DataTable();
            tbReport.Columns.Add("art_id", Type.GetType("System.String"));
            tbReport.Columns.Add("name_prc", Type.GetType("System.String"));
            tbReport.Columns.Add("name_en", Type.GetType("System.String"));
            tbReport.Columns.Add("picture_name", Type.GetType("System.String"));
            tbReport.Columns.Add("customer_goods", Type.GetType("System.String"));
            tbReport.Columns.Add("alltitle", Type.GetType("System.String"));

            tbArtwork = new DataTable();
            dtTemp_details = new DataTable();

            clsControlInfoHelper oMutilang = new clsControlInfoHelper(this.Name, this.Controls);
            oMutilang.GenerateContorl();
        }



        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            //ReportForm.frmLoadCust frmCust = new ReportForm.frmLoadCust();
            frmFindDataBase frmCust = new frmFindDataBase(btnFindCustomer.Name);
            frmCust.Owner = this;
            frmCust.ShowDialog();
            txtCustomer1.Text = DBUtility.get_query_id;
            //txtCustomer2.Text = DBUtility.get_query_id;
        }

        private void btnFindBrand_Click(object sender, EventArgs e)
        {
            frmFindDataBase frmBrand = new frmFindDataBase(btnFindBrand.Name);
            frmBrand.Owner = this;
            frmBrand.ShowDialog();

            txtBrand_id.EditValue = DBUtility.get_query_id;
            //txtBrand_id1.EditValue = DBUtility.get_query_id;
            //txtBrand_id2.EditValue = DBUtility.get_query_id;
        }



        private static void CheckDate(object obj, string strdate)
        {
            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Data Fromat is Error.";
                else
                    strMsg = "輸入的日期有誤！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void deDevelop_Date1_Leave(object sender, EventArgs e)
        {
            string strdate = deDevelop_Date1.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
            if (deDevelop_Date2.EditValue == null)
            {
                deDevelop_Date2.EditValue = deDevelop_Date1.EditValue; //只能用EditValue屬性,用Text會產生奇怪的值            
            }
        }

        private void deDevelop_Date2_Leave(object sender, EventArgs e)
        {
            string strdate = deDevelop_Date2.Text;
            if (strdate != "")
            {
                CheckDate(sender, strdate);
            }
        }

        private void frmArtworkSearch_Load(object sender, EventArgs e)
        {
            string sql_produt_type;   //只針對圖樣代碼資料
            string sql_materiel_type; //18位產品編號的第1、2位
            string sql_goods_type;    //18位產品編號的第3、4位
            string sql_range_size;    //圖樣中的尺寸范圍            
            string sql_brand;

            if (str_language == "0")  //中文
            {
                sql_produt_type = "select id,name from dbo.cd_acus where within_code ='0000'";
                sql_materiel_type = "select id,name from dbo.cd_datum where within_code ='0000'";
                sql_goods_type = "select id,name from dbo.cd_goods_class where within_code ='0000'";
                sql_range_size = "Select id,name from dbo.cd_size_range";
                sql_brand = "select id,name from dbo.cd_brand";
            }
            else //英文
            {
                sql_produt_type = "select id,english_name as name from dbo.cd_acus where within_code ='0000'";
                sql_materiel_type = "select english_name as name,id from dbo.cd_datum where within_code ='0000'";
                sql_goods_type = "select id,english_name as name from dbo.cd_goods_class where within_code ='0000'";
                sql_range_size = "Select id,english_name as name from dbo.cd_size_range";
                sql_brand = "select id,english_name as name from dbo.cd_brand";
            }
            tbMateriel_type = clsConErp.GetDataTable(sql_materiel_type);
            tbProduct_type = clsConErp.GetDataTable(sql_produt_type);
            tbGoods_type = clsConErp.GetDataTable(sql_goods_type);
            tbRange_size = clsConErp.GetDataTable(sql_range_size);
            tbBrand = clsConErp.GetDataTable(sql_brand);

            //爲下拉列表框中加一空行            
            DataRow row1 = tbMateriel_type.NewRow();
            tbMateriel_type.Rows.Add(row1);
            tbMateriel_type.DefaultView.Sort = "id ASC";//排序
            tbMateriel_type = tbMateriel_type.DefaultView.ToTable();//排序後重新賦值

            DataRow row2 = tbProduct_type.NewRow();
            tbProduct_type.Rows.Add(row2);
            tbProduct_type.DefaultView.Sort = "id ASC";
            tbProduct_type = tbProduct_type.DefaultView.ToTable();

            DataRow row3 = tbGoods_type.NewRow();
            tbGoods_type.Rows.Add(row3);
            tbGoods_type.DefaultView.Sort = "id ASC";
            tbGoods_type = tbGoods_type.DefaultView.ToTable();

            DataRow row4 = tbRange_size.NewRow();
            tbRange_size.Rows.Add(row4);
            tbRange_size.DefaultView.Sort = "id ASC";
            tbRange_size = tbRange_size.DefaultView.ToTable();

            DataRow row6 = tbBrand.NewRow();
            tbBrand.Rows.Add(row6);
            tbBrand.DefaultView.Sort = "id ASC";
            tbBrand = tbBrand.DefaultView.ToTable();


            //爲下拉表表框綁定數據          
            txtMateriel_id.Properties.DataSource = tbMateriel_type; //物料類型           
            txtMateriel_id.Properties.ValueMember = "id";
            txtMateriel_id.Properties.DisplayMember = "id";

            txtProdution_id.Properties.DataSource = tbProduct_type; //產品類型
            txtProdution_id.Properties.ValueMember = "id";
            txtProdution_id.Properties.DisplayMember = "id";

            txtRange_Size.Properties.DataSource = tbRange_size;   //尺寸范圍
            txtRange_Size.Properties.ValueMember = "id";
            txtRange_Size.Properties.DisplayMember = "name";

            //txtBrand_id1.Properties.DataSource = tbBrand;   //牌子
            //txtBrand_id1.Properties.ValueMember = "id";
            //txtBrand_id1.Properties.DisplayMember = "id";
            //txtBrand_id2.Properties.DataSource = tbBrand;
            //txtBrand_id2.Properties.ValueMember = "id";
            //txtBrand_id2.Properties.DisplayMember = "id";

            chkFrom_oc.Checked = true;

        }

        private void frmArtworkSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            tbProduct_type.Dispose();
            tbMateriel_type.Dispose();
            tbGoods_type.Dispose();
            tbRange_size.Dispose();
            tbBrand.Dispose();
            tbArtwork.Dispose();
            tbReport.Dispose();
            //tbDetails.Dispose();
            //ds.Dispose();
        }

        private void chkMulticolor_CheckedChanged(object sender, EventArgs e)
        {
            //已有查詢結果的情況下才會執行以代碼
            if (ds != null)
            {
                if (!chkMulticolor.Checked)
                {
                    tbArtwork = ds.Tables[1];//產品圖
                }
                else
                {
                    tbArtwork = ds.Tables[2];//彩色圖                   
                }

                if (tbArtwork.Rows.Count > 0)
                {
                    Add_Date_to_ListView();
                }
                else
                {
                    listView1.Clear();
                    listView1.Items.Clear();
                }
            }
        }

        private void chkFrom_oc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFrom_oc.Checked)
            {
                txtProdution_id.Properties.DataSource = tbGoods_type; //當從OC中找資料時重新綁定下拉框
                SetGoodid_Visible(true);
            }
            else
            {
                txtProdution_id.Properties.DataSource = tbProduct_type;//重新綁定圖樣中的產品類型編號
                SetGoodid_Visible(false);
            }
        }

        private void SetGoodid_Visible(bool setflag)
        {
            //訂單資料選項
            txtGoods_id.Enabled = setflag;
            lblGoods_id.Enabled = setflag;
            lblOrder_Date.Visible = setflag;
            txtCustName.Enabled = setflag;
            txtCustName_en.Enabled = setflag;
            txtCust_product_code.Enabled = setflag;
            txtCust_color_code.Enabled = setflag;

            //圖樣代碼資料選項
            lblDevelop_Date.Visible = !setflag;
            txtMark_Content.Enabled = !setflag;
            txtRange_Size.Enabled = !setflag;
            txtActualSize.Enabled = !setflag;
            txtDraw_id.Enabled = !setflag;

        }

        private void txtBrand_id1_Leave(object sender, EventArgs e)
        {
            //txtBrand_id2.EditValue = txtBrand_id1.EditValue;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!Check_Before_Search())
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "The query could not be empty, please specify a query condition.";
                else
                    strMsg = "查詢找條件不可爲空，請指定一查詢條件！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            Load_data(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

            if (tbArtwork.Rows.Count == 0)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Can not find qualified data.";
                else
                    strMsg = "沒有符合條的數據！";
                listView1.Clear();
                listView1.Items.Clear();
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Load_data()
        {
            string type = "1";
            if (chkFrom_oc.Checked)
            {
                type = "2"; //從訂單資料查詢
            }
            else
            {
                type = "1"; //從畫稿資料查詢
            }
            string artwork_id_s = txtArtwork_id1.Text;            
            string artwork_name = txtArtwork_Name_prc.Text;
            string artwork_name_en = txtArtwork_Name_en.Text;
            string customer_id_s = txtCustomer1.Text;            
            string materiel_id = txtMateriel_id.Text;
            string products_type = txtProdution_id.Text;
            string develop_date_s = deDevelop_Date1.Text;//.EditValue.ToString();
            string develop_date_e = deDevelop_Date2.Text;//.EditValue.ToString();
            string brand_no_s = txtBrand_id.Text;            
            string markcontent = txtMark_Content.Text;
            string size_range = txtRange_Size.EditValue.ToString();
            string actual_size = txtActualSize.Text;
            string draw_no = txtDraw_id.Text;

            string goods_id = txtGoods_id.Text;
            string custname = txtCustName.Text;
            string custname_en = txtCustName_en.Text;
            string customer_product_code = txtCust_product_code.Text.Trim();
            string customer_color_code = txtCust_color_code.Text.Trim();
            string image_path = clsConErp.getErpImagePath();


            ds = commUse.getDataSet("z_artwork_search01",
                                               new object[]
                                               {
                                                  image_path,
                                                  type,
                                                  artwork_id_s,                                                  
                                                  artwork_name,
                                                  artwork_name_en,
                                                  customer_id_s,                                                
                                                  materiel_id,
                                                  products_type,
                                                  develop_date_s,
                                                  develop_date_e,
                                                  brand_no_s,                                                  
                                                  markcontent,
                                                  size_range,
                                                  actual_size,
                                                  draw_no,
                                                  goods_id,
                                                  custname,
                                                  custname_en,
                                                  customer_product_code,
                                                  customer_color_code
                                               });

            if (!chkMulticolor.Checked)
            {
                tbArtwork = ds.Tables[1];//產品圖               
            }
            else
            {
                tbArtwork = ds.Tables[2];//彩色圖
            }


            //刪除不存在的圖片路徑
            if (tbArtwork.Rows.Count > 0)
            {
                for (int i = tbArtwork.Rows.Count - 1; i >= 0; i--)
                {
                    if (!File.Exists(tbArtwork.Rows[i]["picture_name"].ToString()))
                    {
                        tbArtwork.Rows.RemoveAt(i);
                    }
                }
            }

            Add_Date_to_ListView();

            tbDetails = ds.Tables[0];    //祥細資料
        }

        /// <summary>
        /// 給ListView控件加載數據
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Date_to_ListView()
        {
            if (tbArtwork.Rows.Count == 0)
            {
                listView1.Clear();
                listView1.Items.Clear();
                return;
            }

            int iRows = tbArtwork.Rows.Count;
            lblTotal.Text = iRows.ToString();
            imageList1.Images.Clear();
            listView1.Clear();
            listView1.Items.Clear();
            imageList1.ColorDepth = ColorDepth.Depth24Bit;
            imageList1.ImageSize = new Size(120, 120);

            //加載圖片
            string strFileName = "";
            string strCust_goods = "";
            listView1.LargeImageList = imageList1;
            listView1.BeginUpdate();
            StringBuilder myString = new StringBuilder("");
            int x;
            for (int i = 0; i < iRows; i++)
            {
                //strFileName = gridView1.GetRowCellDisplayText(i, "picture_name");
                strFileName = tbArtwork.Rows[i]["picture_name"].ToString();
                if (File.Exists(@strFileName))
                {
                    imageList1.Images.Add(Image.FromFile(strFileName));
                    x = 0;
                    //StringBuilder myString = new StringBuilder("");
                    myString.Clear();
                    if (chk_name_prc.Checked)//顯示圖樣中文描述
                    {
                        myString.Append(tbArtwork.Rows[i]["name_prc"].ToString().Trim());
                        x = x + 1;
                    }
                    if (chk_name_en.Checked)//顯示圖樣英文描述
                    {
                        if (x > 0)
                        {
                            myString.Append(String.Format("\n{0}", tbArtwork.Rows[i]["name_en"].ToString().Trim()));
                        }
                        else
                        {
                            myString.Append(tbArtwork.Rows[i]["name_en"].ToString().Trim());
                            x = x + 1;
                        }
                    }
                    if (chk_product_code.Checked)//顯示客戶產品編號
                    {
                        strCust_goods = tbArtwork.Rows[i]["customer_goods"].ToString();
                        if (string.IsNullOrEmpty(strCust_goods))
                            strCust_goods = "";
                        else
                            strCust_goods = strCust_goods.Trim();
                        if (x > 0)
                        {
                            //myString.Append(String.Format("\n{0}", tbArtwork.Rows[i]["customer_goods"].ToString().Trim()));
                            myString.Append(String.Format("\n{0}", strCust_goods));
                        }
                        else
                        {
                            //myString.Append(tbArtwork.Rows[i]["customer_goods"].ToString().Trim());
                            myString.Append(strCust_goods);
                            x = x + 1;
                        }
                    }
                    listView1.Items.Add(myString.ToString());

                    /* //舊的代碼
                    if (chk_name_prc.Checked && chk_name_en.Checked)//顯示中英文描述
                    {
                        listView1.Items.Add(String.Format("{0}\n{1}", tbArtwork.Rows[i]["name_prc"].ToString(), tbArtwork.Rows[i]["name_en"].ToString()));
                    }
                    else
                    {
                        if (chk_name_prc.Checked)//顯示中文描述
                        {
                            listView1.Items.Add(tbArtwork.Rows[i]["name_prc"].ToString());
                        }
                        if (chk_name_en.Checked) //顯示英文描述
                        {
                            listView1.Items.Add(tbArtwork.Rows[i]["name_en"].ToString());
                        }
                        if (!chk_name_prc.Checked && !chk_name_en.Checked)//不顯示中英,文描述
                        {
                            listView1.Items.Add("");                            
                        }
                    }*/

                    listView1.Items[i].ImageIndex = i;
                    listView1.Items[i].Tag = strFileName;
                    listView1.Items[i].Name = tbArtwork.Rows[i]["art_id"].ToString();
                    listView1.Items[i].ToolTipText = tbArtwork.Rows[i]["customer_goods"].ToString().Trim();//用來保存臨時的客戶產品編號

                }
            }
            listView1.EndUpdate();
        }


        private void txtArtwork_id1_Leave(object sender, EventArgs e)
        {
            //txtArtwork_id2.Text = txtArtwork_id1.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tbReport.Rows.Count == 0)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Please select the pictures to be printed, and added to the report.";
                else
                    strMsg = "請先選擇要列印的圖樣,幷添加到報表.";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //加載報表
            xrArtwork mMyRepot = new xrArtwork() { DataSource = tbReport };
            mMyRepot.ShowPreview();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (tbReport.Rows.Count == 0)
            {
                return;
            }
            else
            {
                tbReport.Rows.Clear();
            }
        }

        private void chk_name_prc_CheckedChanged(object sender, EventArgs e)
        {
            if (ds != null)
            {
                Add_Date_to_ListView();
            }
        }

        private void chk_name_en_CheckedChanged(object sender, EventArgs e)
        {
            if (ds != null)
            {
                Add_Date_to_ListView();
            }
        }

        private void chk_product_code_CheckedChanged(object sender, EventArgs e)
        {
            if (ds != null)
            {
                Add_Date_to_ListView();
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count > 0)
            {
                foreach (ListViewItem lvItem in this.listView1.Items)
                {
                    listView1.Items[lvItem.Index].Checked = chkSelectAll.Checked;
                    listView1.Items[lvItem.Index].Selected = chkSelectAll.Checked;
                }
                if (listView1.CheckedItems.Count > 0)
                {
                    lblTotal.Text = String.Format("{0}/{1}", listView1.CheckedItems.Count, listView1.Items.Count);
                }
                else
                {
                    lblTotal.Text = listView1.Items.Count.ToString();
                }
            }


        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem lvItem in this.listView1.CheckedItems)//已選中的記錄
            {
                if (lvItem.Checked)
                {
                    lvItem.Selected = true;  //Hilight
                }
            }

            if (listView1.CheckedItems.Count > 0)
            {
                lblTotal.Text = String.Format("{0}/{1}", listView1.CheckedItems.Count, listView1.Items.Count);
            }
            else
            {
                lblTotal.Text = listView1.Items.Count.ToString();
            }
        }

        private void txtCustomer1_Leave(object sender, EventArgs e)
        {
            //this.txtCustomer2.Text = this.txtCustomer1.Text;
        }

        private bool Check_Before_Search()
        {
            string strSearch = "";
            foreach (Control c in this.panel1.Controls)
            {
                if (c is Label)
                {
                    continue;
                }
                if (c is TextEdit)
                {
                    if (!c.Enabled && c.Text != "")
                    {
                        c.Text = "";
                    }
                    strSearch = strSearch + c.Text;
                }

                if (c is LookUpEdit)
                {
                    if (!c.Enabled && c.Text != "")
                    {
                        c.Text = "";
                    }
                    strSearch = strSearch + c.Text;
                }
                if (c is DateEdit)
                {
                    strSearch = strSearch + c.Text;
                }
                if (!string.IsNullOrEmpty(strSearch)) //條件不爲空直接退出循環
                {
                    break;
                }
            }

            if (string.IsNullOrEmpty(strSearch))
            {
                return false;//查詢條件爲空                
            }
            else
            {
                return true;
            }

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (tbArtwork.Rows.Count == 0)
            {
                return;
            }
            if (listView1.CheckedItems.Count == 0)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Please select the relevant pictures.";
                else
                    strMsg = "請選擇相關的圖樣.";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtTemp_details.Clear();
            dtTemp_details = tbDetails.Clone();//COPY表結構  
            DataRow[] dr;
            foreach (ListViewItem lvi in listView1.CheckedItems) //選中項遍曆.SelectedItems
            {
                if(!chkFrom_oc.Checked)
                    dr = tbDetails.Select(String.Format("artwork_code='{0}'", lvi.Name));
                else
                    dr = tbDetails.Select(String.Format("artwork_code='{0}' and customer_goods='{1}'", lvi.Name, lvi.ToolTipText));
                for (int i = 0; i < dr.Length; i++)
                {
                    dtTemp_details.ImportRow((DataRow)dr[i]);
                }
            }

            if (dtTemp_details != null)
            {
                frmArtworkShow frm = new frmArtworkShow();
                frm.ShowDialog();
            }
        }


        private void btnAddReport_Click(object sender, EventArgs e)
        {
            if (tbArtwork.Rows.Count == 0)
            {
                return;
            }
            if (listView1.CheckedItems.Count == 0)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Please select the pictures to be printed.";
                else
                    strMsg = "請先選擇要列印的圖樣.";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string strCust_product_code;
            string strAllTitle;
            int iIndex = 0;
            string strImagePath = "";
            DataRow[] dr = null;
            DataRow[] dr_add = null;
            DataRow newRow = null;
            foreach (ListViewItem lvi in listView1.CheckedItems) //選中項遍曆.SelectedItems
            {
                strImagePath = lvi.Tag.ToString();
                iIndex = lvi.Index;
                strAllTitle = lvi.Text;
                strCust_product_code = lvi.ToolTipText; //取客戶產品編號
                //DataRow[] dr = tbArtwork.Select(String.Format("picture_name = '{0}'", strImagePath));   //篩選出打勾的圖樣
                dr = tbArtwork.Select(String.Format("picture_name = '{0}' and customer_goods='{1}'", strImagePath, strCust_product_code));   //篩選出打勾的圖樣                               
                //DataRow[] dr_add = tbReport.Select(String.Format("picture_name = '{0}'", strImagePath));
                dr_add = tbReport.Select(String.Format("picture_name = '{0}' and customer_goods='{1}'", strImagePath, strCust_product_code));
                if (dr_add.Length == 0)   //是否已添加了圖樣             
                {
                    newRow = tbReport.NewRow();
                    newRow["art_id"] = dr[0]["art_id"].ToString();
                    if (chk_name_prc.Checked)//顯示中文描述
                    {
                        newRow["name_prc"] = dr[0]["name_prc"].ToString();
                    }
                    else
                    {
                        newRow["name_prc"] = "";
                    }
                    if (chk_name_en.Checked)//顯示英文描述
                    {
                        newRow["name_en"] = dr[0]["name_en"].ToString();
                    }
                    else
                    {
                        newRow["name_en"] = "";
                    }
                    if (chk_product_code.Checked)//顯示客戶產品編號
                    {
                        //newRow["customer_goods"] = dr[0]["customer_goods"].ToString();
                        newRow["customer_goods"] = strCust_product_code;
                    }
                    else
                    {
                        newRow["customer_goods"] = "";
                    }
                    newRow["alltitle"] = strAllTitle;

                    /*//舊代碼
                    if (chk_name_prc.Checked && chk_name_en.Checked)//顯示中英文描述
                    {
                        newRow["name_prc"] = dr[0]["name_prc"].ToString();
                        newRow["name_en"] = dr[0]["name_en"].ToString();
                    }
                    else
                    {
                        if (chk_name_prc.Checked)//顯示中文描述
                        {
                            newRow["name_prc"] = dr[0]["name_prc"].ToString();
                            newRow["name_en"] = "";
                        }
                        if (chk_name_en.Checked) //顯示英文描述
                        {
                            newRow["name_prc"] = "";
                            newRow["name_en"] = dr[0]["name_en"].ToString();
                        }
                        if (!chk_name_prc.Checked && !chk_name_en.Checked)//不顯示中英,文描述
                        {
                            newRow["name_prc"] = "";
                            newRow["name_en"] = "";
                        }
                    }*/
                    newRow["picture_name"] = dr[0]["picture_name"].ToString();
                    tbReport.Rows.Add(newRow);
                }
            }

            string strMsgtotal;
            if (str_language == "2")
                strMsgtotal = String.Format("Total added {0} pictures.", listView1.CheckedItems.Count);
            else
                strMsgtotal = String.Format("總共添加了{0}張圖樣！", listView1.CheckedItems.Count);
            MessageBox.Show(strMsgtotal, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLarge_Click(object sender, EventArgs e)
        {
            if (tbArtwork.Rows.Count == 0)
            {
                return;
            }
            if (tbReport.Rows.Count == 0)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Please select the pictures to be preview, and added to the report.";
                else
                    strMsg = "請先選擇要瀏覽的圖樣,幷添加到報表.";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tbReport != null)
            {
                frmPreviewImage frm = new frmPreviewImage(tbReport);
                frm.ShowDialog();
            }
        }



    }
}
