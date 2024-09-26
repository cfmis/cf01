using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;
using cf01.ModuleClass;

namespace cf01.ReportForm
{
    public partial class frmArtworkMould : Form
    {
        private clsAppPublic clsApp = new clsAppPublic();
        private clsPublicOfGEO objGeo = new clsPublicOfGEO();
        string strFind_condition_art="";
        string strFind_condition_oc="";
        public frmArtworkMould()
        {
            InitializeComponent();
            clsApp.Initialize_find_value(Name, pnlFind.Controls);           
        }

     

        private void frmArtworkMould_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDat1.Text))
            {
                txtDat1.EditValue = DateTime.Now;
            }
            if (string.IsNullOrEmpty(txtDat2.Text))
            {
                txtDat2.EditValue = DateTime.Now;
            }

            this.ActiveControl = txtDat2;  //設置獲得點的控件必須與txtPassword.Focus()一起使用否則不起作用
            txtDat2.Focus();
            
            //記錄初始值，因查詢條件可能已有保存
            string strSeller_id1, strSeller_id2, strMo_group, strMo_type, strMerchandiser1, strMerchandiser2;
            strSeller_id1 = cboSeller_id1.Text;
            strSeller_id2 = cboSeller_id2.Text;
            strMerchandiser1 = cboMerchandiser1.Text;
            strMerchandiser2 = cboMerchandiser2.Text;

            strMo_group = cboMo_group.Text;
            strMo_type = cboMo_type.Text;

            //Sellers Data 起模人
            //string ls_sql = @"Select Distinct abbrev_id as id,name FROM cd_personnel Where ISNULL(abbrev_id,'')<>'' and state='0' Order By abbrev_id";
            string ls_sql = @"Select '' as id,'' as name Union Select id,REPLACE(english_name,' ','_') as name FROM cd_personnel with(nolock) Where sales_group='6Q' and state='0' Order By id";
            DataTable dtSales1 = objGeo.GetDataTable(ls_sql);
            DataTable dtSales2 = dtSales1.Copy();
            cboSeller_id1.DataSource = dtSales1;
            cboSeller_id1.ValueMember = "id";
            cboSeller_id1.DisplayMember = "id";

            cboSeller_id2.DataSource = dtSales2;
            cboSeller_id2.ValueMember = "id";
            cboSeller_id2.DisplayMember = "id";
            //MO Group
            ls_sql = "SELECT id,name FROM cd_mo_type with(nolock) WHERE mo_type ='3' and id>='A' order by id";
            DataTable dtMo_group = objGeo.GetDataTable(ls_sql);
            cboMo_group.DataSource = dtMo_group;
            cboMo_group.ValueMember = "id";
            cboMo_group.DisplayMember = "id";
            //MO Type
            ls_sql = "SELECT id,name FROM cd_mo_type with(nolock) WHERE mo_type ='1' order by id";
            DataTable dtMo_type = objGeo.GetDataTable(ls_sql);
            cboMo_type.DataSource = dtMo_type;
            cboMo_type.ValueMember = "id";
            cboMo_type.DisplayMember = "id";

            //merchandiser跟單員
            ls_sql = @"Select '' as id,'' as name Union Select id,name FROM cd_personnel with(nolock) Where sales_group='6Q' and state='0' Order By id";
            DataTable dtMerchandiser1 = objGeo.GetDataTable(ls_sql);
            DataTable dtMerchandiser2 = dtMerchandiser1.Copy();
            cboMerchandiser1.DataSource = dtMerchandiser1;
            cboMerchandiser1.ValueMember = "id";
            cboMerchandiser1.DisplayMember = "id";          
            
            cboMerchandiser2.DataSource = dtMerchandiser2;
            cboMerchandiser2.ValueMember = "id";
            cboMerchandiser2.DisplayMember = "id";

            //Setting Combox DropDown object Multiple Column
            MultipleColumnComboBox mltComBox = new MultipleColumnComboBox();
            mltComBox.DesignComboBoxColummn(cboSeller_id1, "id", "name");
            mltComBox.DesignComboBoxColummn(cboSeller_id2, "id", "name");
            mltComBox.DesignComboBoxColummn(cboMo_group, "id", "name");
            mltComBox.DesignComboBoxColummn(cboMo_type, "id", "name");
            mltComBox.DesignComboBoxColummn(cboMerchandiser1, "id", "name");
            mltComBox.DesignComboBoxColummn(cboMerchandiser2, "id", "name");

            cboSeller_id1.Text = strSeller_id1;
            if (cboSeller_id1.Text == "")
            {
                lblmd1.Text = "";
            }
            cboSeller_id2.Text = strSeller_id2;
            if (cboSeller_id2.Text == "")
            {
                lblmd2.Text = "";
            }
            cboMerchandiser1.Text = strMerchandiser1;
            if (cboMerchandiser1.Text == "")
            {
                lblSeller1.Text = "";
            }
            cboMerchandiser2.Text = strMerchandiser2;
            if (cboMerchandiser2.Text == "")
            {
                lblSeller2.Text = "";
            }

            if (strMo_group == "")
                cboMo_group.Text = "Q";
            else
            {
                cboMo_group.Text = strMo_group;
            }
            if (strMo_type == "")
            {
                cboMo_type.Text = "N";
            }
            else
            {
                cboMo_type.Text = strMo_type;
            }           
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            txtDat1.Text = "";
            txtDat2.Text = "";
            cboMerchandiser1.Text = "";
            cboMerchandiser2.Text = "";
            cboSeller_id1.Text = "";
            cboSeller_id2.Text = "";
            cboMo_group.Text = "";
            cboMo_type.Text = "";
            lblmd1.Text = "";
            lblmd2.Text = "";
            lblSeller1.Text = "";
            lblSeller2.Text = "";
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {            
            if (rdo1.Checked)
            {
                if (txtDat1.Text == "" && txtDat2.Text == "" && cboSeller_id1.Text == "" && cboSeller_id2.Text == "")
                {
                    MessageBox.Show("查詢條件不可爲空!", "提示信息");
                    txtDat1.Focus();
                    return;
                }
            }
            else
            {
                if (txtDat1.Text == "" && txtDat2.Text == "" && cboMerchandiser1.Text == "" && cboMerchandiser2.Text == "" && cboMo_group.Text == "" && cboMo_type.Text == "")
                {
                    MessageBox.Show("查詢條件不可爲空!", "提示信息");
                    txtDat1.Focus();
                    return;
                }
            }


            string rpt_type, date_s, date_e, seller_id_s, seller_id_e, mo_group, mo_type ;
            if (rdo1.Checked)
            {
                rpt_type = "1";//畫稿
                date_s = txtDat1.Text;
                date_e = txtDat2.Text;
                seller_id_s = cboSeller_id1.Text == "" ? "" : cboSeller_id1.SelectedValue.ToString();
                seller_id_e = cboSeller_id2.Text == "" ? "" : cboSeller_id2.SelectedValue.ToString();               
                mo_group = "";
                mo_type = "";
                strFind_condition_art = String.Format("日期From: {0} To: {1}\n\r起模人From: {2} To: {3}", date_s, date_e, seller_id_s, seller_id_e);
            }
            else
            {
                rpt_type = "2";//落單
                date_s = txtDat1.Text;
                date_e = txtDat2.Text;
                
                seller_id_s = cboMerchandiser1.Text ==""? "": cboMerchandiser1.SelectedValue.ToString();
                seller_id_e = cboMerchandiser2.Text == "" ? "" : cboMerchandiser2.SelectedValue.ToString();               
                mo_group = cboMo_group.Text ;
                mo_type = cboMo_type.Text ;
                strFind_condition_oc = String.Format("日期From: {0} To: {1}\n\r跟單員From: {2} To: {3}\n\r組別: {4} ; 制單類型: {5}", date_s, date_e, seller_id_s, seller_id_e, mo_group, mo_type);
            }

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@rpt_type",rpt_type ),
                new SqlParameter("@date_s", date_s),
                new SqlParameter("@date_e", date_e),
                new SqlParameter("@seller_id_s", seller_id_s),
                new SqlParameter("@seller_id_e",  seller_id_e),                              
                new SqlParameter("@mo_group", mo_group),
                new SqlParameter("@mo_type",  mo_type)
            };

            DataSet dts = clsPublicOfCF01.ExecuteProcedureReturnDataSet("usp_rpt_artwork_md", paras, null);
            if (dts.Tables.Count == 0)
            {
                return;
            }
            if (rdo1.Checked)
            {               
                dgvArt_Md1.DataSource = dts.Tables[0];//匯總表
                dgvArt_Md2.DataSource = dts.Tables[1];//明細表
            }
            else
            {
                dgvOc1.DataSource = dts.Tables[0];//年度月份匯總
                dgvOc2.DataSource = dts.Tables[1];//用戶年度組別明細   
                dgvOc3.DataSource = dts.Tables[2];//用戶組別明細
            }           
                
            if (dts.Tables[0].Rows.Count == 0)
            {
                for (int i = 0; i < dts.Tables.Count; i++)
                {
                    dts.Tables[i].Clear();
                }                  
                MessageBox.Show("沒有滿足查詢條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNSAVESET_Click(object sender, EventArgs e)
        {
            if (clsApp.set_find_Value(this.Name, pnlFind.Controls) > 0)
            {
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            }
            else
            {
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void Print() //通用的打印方法
        {
            string strTitle = "";
            if (rdo2.Checked)//OC
            {
                if (dgvOc1.Rows.Count == 0)
                {
                    MessageBox.Show("請首先查詢出要列印的OC落單資料!", "提示信息");
                    return;
                }
                if (rbtnOc1.Checked)
                {
                    strTitle = String.Format("落單按年度匯總\n\r{0}", strFind_condition_oc);
                    PrintDGV.Print_DataGridView(dgvOc1, strTitle);//OC匯總表
                    return;
                }
                if (rbtnOc2.Checked)
                {
                    strTitle = String.Format("落單按用戶、年度、組別、制單類型分組\n\r{0}", strFind_condition_oc);
                    PrintDGV.Print_DataGridView(dgvOc2, strTitle);
                    return;
                }
                if (rbtnOc3.Checked)
                {
                    strTitle = String.Format("落單明細", strFind_condition_oc);
                    PrintDGV.Print_DataGridView(dgvOc3, strTitle);
                    return;
                }
            }
            else  //artwork Mould
            {
                if (dgvArt_Md1.Rows.Count == 0)
                {
                    MessageBox.Show("請首先查詢出要列印的畫稿資料!", "提示信息");
                    return;
                }
                if (rbtnArt1.Checked)
                {
                    strTitle = String.Format("畫稿/起模年度匯總\n\r{0}",strFind_condition_art);
                    PrintDGV.Print_DataGridView(dgvArt_Md1, strTitle);
                    return;
                }
                if (rbtnArt2.Checked)
                {
                    strTitle = String.Format("畫稿/起模年度匯總明細\n\r{0}", strFind_condition_art);
                    PrintDGV.Print_DataGridView(dgvArt_Md2, strTitle);
                    return;
                }
            }
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            if (rdo2.Checked)//OC
            {
                if (dgvOc1.Rows.Count == 0)
                {
                    MessageBox.Show("請首先查詢出要列印的OC落單資料!", "提示信息");
                    return;
                }                
            }
            else  //artwork Mould
            {
                if (dgvArt_Md1.Rows.Count == 0)
                {
                    MessageBox.Show("請首先查詢出要列印的畫稿資料!", "提示信息");
                    return;
                }                
            }
            Excel();
        }

        private void Excel() //匯出EXCEL
        {
            ExpToExcel oxls = new ExpToExcel();            
            if (rdo2.Checked)//OC
            {
                if (rbtnOc1.Checked)
                {
                    oxls.ExportExcel(dgvOc1);
                    return;
                }
                if (rbtnOc2.Checked)
                {
                    oxls.ExportExcel(dgvOc2);
                    return;
                }
                if (rbtnOc3.Checked)
                {
                    oxls.ExportExcel(dgvOc3);
                    return;
                }
            }
            else  //artwork Mould
            {
                if (rbtnArt1.Checked)
                {
                    oxls.ExportExcel(dgvArt_Md1);
                    return;
                }
                if (rbtnArt2.Checked)
                {
                    oxls.ExportExcel(dgvArt_Md2);
                    return;
                }
            }
            oxls = null;     
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1.Checked)
            {
                rdo2.Checked = false;
                pnlArtwork.Visible = true ;
                pnlOc.Visible = false;
                lblDate.Text = "畫稿日期";
                pnlOcResult.Visible = false;
                pnlArtworkResult.Visible = true;
            }
            else
            {
                rdo2.Checked = true;
                pnlArtwork.Visible = false;
                pnlOc.Visible = true;
                lblDate.Text = "落單日期";
                pnlOcResult.Visible = true;
                pnlArtworkResult.Visible = false;
            }
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo2.Checked)
            {
                rdo1.Checked = false ;
                pnlArtwork.Visible = false ;
                pnlOc.Visible = true ;
                pnlOc.Location = new System.Drawing.Point(25, 26) ;
                lblDate.Text = "落單日期" ;
                pnlOcResult.Visible = true ;
                pnlArtworkResult.Visible = false ;
            }
            else
            {
                rdo1.Checked = true;
                pnlArtwork.Visible = true ;
                pnlOc.Visible = false ;
                lblDate.Text = "畫稿日期" ;
                pnlOcResult.Visible = false ;
                pnlArtworkResult.Visible = true ;
            }
        }     

        private void cboMerchandiser1_Leave(object sender, EventArgs e)
        {
            cboMerchandiser2.Text = cboMerchandiser1.Text;
            if (cboMerchandiser1.Text != "")
            {
                DataRowView drv = (DataRowView)cboMerchandiser2.SelectedItem;
                lblSeller2.Text = drv["name"].ToString();
            }
            else
            {
                lblSeller1.Text = "";
                lblSeller2.Text = "";
            }
        }

        private void frmArtworkMould_FormClosed(object sender, FormClosedEventArgs e)
        {
            objGeo = null;
            clsApp = null;
        }

        private void cboSeller_id1_Leave(object sender, EventArgs e)
        {
            cboSeller_id2.Text = cboSeller_id1.Text;
            if (cboSeller_id1.Text != "")
            {
                DataRowView drv = (DataRowView)cboSeller_id2.SelectedItem;
                lblmd2.Text = drv["name"].ToString();
            }
            else
            {
                lblmd1.Text = "";
                lblmd2.Text = "";
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (rdo1.Checked)
            {
                dgvArt_Md1.Focus();
            }
            else
            {
                dgvOc1.Focus();
            }
        }

        private void cboSeller_id1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboSeller_id1.SelectedItem;
            lblmd1.Text = drv["name"].ToString();
        }

        private void cboSeller_id2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboSeller_id2.SelectedItem;
            lblmd2.Text = drv["name"].ToString();
        }

        private void cboMerchandiser1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboMerchandiser1.SelectedItem;
            lblSeller1.Text = drv["name"].ToString();
        }

        private void cboMerchandiser2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboMerchandiser2.SelectedItem;
            lblSeller2.Text = drv["name"].ToString();
        }

        private void cboSeller_id2_Leave(object sender, EventArgs e)
        {
            if (cboSeller_id2.Text == "")
            {
                lblmd2.Text = "";
            }
        }

        private void cboMerchandiser2_Leave(object sender, EventArgs e)
        {
            if (cboMerchandiser2.Text == "")
            {
                lblSeller2.Text = "";
            }
        }
        
    }
}
