/*
 * Create by :   Allen Leung 
 * Create Date : 2018-11-20
 * remark:
 * HK V組 TRIMS DEVELOPMENT SHEET
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.Reports;
using cf01.ModuleClass;
using System.Drawing;
using cf01.MDL;
using DevExpress.XtraReports.UI;
//using System.Runtime.InteropServices;

namespace cf01.Forms
{
    public partial class frmTrimsSheet : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public DataTable dtReSet = new DataTable();             
        public string mState = ""; 
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();
        //public static List<mdlQuotation> mList = new List<mdlQuotation>();

        //提示信息窗口自動關閉聲明
        //需引入using System.Runtime.InteropServices;
        //[DllImport("user32.dll")]
        //public static extern int MessageBoxTimeout(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);

        public frmTrimsSheet()
        {
            InitializeComponent();
            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();
        }       
        private void frmTommyTest_Load(object sender, EventArgs e)
        {
            clsQuotation.Set_Brand_id(luebrand_id);
            const string sql = @"SELECT * From trims_sheet with(nolock) where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            
            dgvDetails.DataSource = dtDetail;

            dtDat1.EditValue = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd").Substring(0, 10);
            dtDat2.EditValue = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 10);
           
        }      

        private void SetButtonSatus(bool _flag)
        {
            btnNew.Enabled = _flag;
            btnEdit.Enabled = _flag;
            btnDelete.Enabled = _flag;
            BTNNEWCOPY.Enabled = _flag;
            btnPrint.Enabled = _flag;
            btnSave.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            if (objToolbar != null)
            {
                objToolbar.SetToolBar();
            }
        }       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNew();    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void AddNew()
        {
            tabControl1.SelectTab(0);
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            //新增時設置初始值
            txtCreate_by.Text = DBUtility._user_id;
            txtCreate_date.Text = DateTime.Now.Date.ToString();
            txtform_date.Text = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            txtserial_no.Text = clsTommyTest.GetSeqNo("trims_sheet", "serial_no");
           

            txtserial_no.Properties.ReadOnly = true;
            txtserial_no.BackColor = Color.White;

            dgvDetails.Enabled = false;
            txttrim_code.Focus();
        }

        private void Save()
        {
            txtserial_no.Focus();
            if (txtserial_no.Text == "" && txtform_date.Text == "")
            {
                MessageBox.Show("Serial No.、日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtform_date.Focus();
                return;
            }           
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO trims_sheet(serial_no,form_date,trim_code,brand_id,brand_desc,new_submit,[counter],new_development,artwork_code,season,mill_article,
            agent_mill,pattern,width_weight,contents,customer_color,size,cf_color,construction,cost_ex_fty,cost_fob,
            lead_time,remark1,remark2,material,ref_no,from_by,to_by,create_by,create_date)
            Values(@serial_no,@form_date,@trim_code,@brand_id,@brand_desc,@new_submit,@counter,@new_development,@artwork_code,@season,@mill_article,
            @agent_mill,@pattern,@width_weight,@contents,@customer_color,@size,@cf_color,@construction,@cost_ex_fty,@cost_fob,
            @lead_time,@remark1,@remark2,@material,@ref_no,@from_by,@to_by,@user_id,getdate())";

            const string sql_update =
            @"Update trims_sheet 
            SET serial_no=@serial_no,form_date=@form_date,trim_code=@trim_code,brand_id=@brand_id,brand_desc=@brand_desc,new_submit=@new_submit,counter=@counter,new_development=@new_development,
            artwork_code=@artwork_code,season=@season,mill_article=@mill_article,agent_mill=@agent_mill,pattern=@pattern,width_weight=@width_weight,contents=@contents,
            customer_color=@customer_color,size=@size,cf_color=@cf_color,construction=@construction,cost_ex_fty=@cost_ex_fty,cost_fob=@cost_fob,
            lead_time=@lead_time,remark1=@remark1,remark2=@remark2,material=@material,ref_no=@ref_no,from_by=@from_by,to_by=@to_by,update_by=@user_id,update_date=getdate()
            WHERE serial_no=@serial_no";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            string strSerial_no;
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    if (mState == "NEW")
                    {
                        myCommand.CommandText = sql_new;
                        strSerial_no = clsTommyTest.GetSeqNo("trims_sheet", "serial_no");
                        myCommand.Parameters.AddWithValue("@serial_no", strSerial_no);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@serial_no", txtserial_no.Text);
                        strSerial_no = txtserial_no.Text;
                    }                    
                    myCommand.Parameters.AddWithValue("@form_date", clsApp.Return_String_Date(txtform_date.Text));
                    myCommand.Parameters.AddWithValue("@new_submit", chknew_submit.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@counter", chkcounter.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@new_development", chknew_development.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@trim_code", txttrim_code.Text);
                    myCommand.Parameters.AddWithValue("@brand_id", luebrand_id.EditValue);
                    myCommand.Parameters.AddWithValue("@brand_desc", txtbrand_desc.EditValue);
                    myCommand.Parameters.AddWithValue("@season", txtseason.Text);
                    myCommand.Parameters.AddWithValue("@artwork_code", txtartwork_code.Text);
                    myCommand.Parameters.AddWithValue("@mill_article", txtmill_article.Text);
                    myCommand.Parameters.AddWithValue("@agent_mill", txtagent_mill.Text);
                    myCommand.Parameters.AddWithValue("@pattern", txtpattern.Text);
                    myCommand.Parameters.AddWithValue("@width_weight", txtwidth_weight.Text);
                    myCommand.Parameters.AddWithValue("@contents", txtcontents.Text);
                    myCommand.Parameters.AddWithValue("@customer_color", txtcustomer_color.Text);
                    myCommand.Parameters.AddWithValue("@size", txtsize.Text);
                    myCommand.Parameters.AddWithValue("@cf_color", txtcf_color.Text);
                    myCommand.Parameters.AddWithValue("@construction", txtconstruction.Text);
                    myCommand.Parameters.AddWithValue("@cost_ex_fty", txtcost_ex_fty.Text);
                    myCommand.Parameters.AddWithValue("@cost_fob", txtcost_fob.Text);
                    myCommand.Parameters.AddWithValue("@lead_time", txtlead_time.Text);
                    myCommand.Parameters.AddWithValue("@remark1", memremark1.Text);
                    myCommand.Parameters.AddWithValue("@remark2", memremark2.Text);
                    myCommand.Parameters.AddWithValue("@material", txtmaterial.Text);
                    myCommand.Parameters.AddWithValue("@ref_no", txtref_no.Text);
                    myCommand.Parameters.AddWithValue("@to_by", txtto_by.Text);
                    myCommand.Parameters.AddWithValue("@from_by", txtfrom_by.Text);
                    myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);

                    myCommand.ExecuteNonQuery();
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
                    myCon.Dispose();
                    myTrans.Dispose();
                }
            }
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);
            dgvDetails.Enabled = true;

            if (save_flag)
            {
                ReSet_Datagrid_Value();
                //新增狀態下定位到新增的行
                if (mState == "NEW")
                {
                    int cur_row_index = dgvDetails.RowCount - 1;
                    dgvDetails.CurrentCell = dgvDetails.Rows[cur_row_index].Cells[2]; //设置当前单元格
                    dgvDetails.Rows[cur_row_index].Selected = true; //選中整行
                }
                mState = "";                
                //MessageBox.Show("數據保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBoxTimeout((IntPtr)0, "數據保存成功!", "提示信息", 0, 0, 1000); //提示窗體1秒后自動關閉
                clsUtility.myMessageBox("數據保存成功!", "提示信息");
            }
            else
            {                
               MessageBox.Show("數據保存失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);                
            }
        }

        private void Delete()
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtserial_no.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show("確定要當前記錄？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM dbo.trims_sheet WHERE serial_no=@serial_no";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@serial_no", txtserial_no.Text);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show("當前記錄刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        private void Edit()
        {
            if (txtserial_no.Text == "")
            {
                return;
            }
            tabControl1.SelectTab(0);
            mState = "EDIT";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(panel1.Controls, true);
            txtUpdate_by.Text = DBUtility._user_id;
            txtUpdate_date.Text = DateTime.Now.Date.ToString();
            txtserial_no.Properties.ReadOnly = true;
            txtserial_no.BackColor = Color.White;
        }

        private void frmTrimsSheet_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();
           objToolbar = null;
           clsApp = null;
           //mList.Clear();
           //mList = null;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {           
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(panel1.Controls, false);
            SetObjValue.ClearObjValue(panel1.Controls, "1");
            mState = "";
            txtserial_no.Properties.ReadOnly = true;
            dgvDetails.Enabled = true;
            if (!String.IsNullOrEmpty(mID) && dgvDetails.RowCount > 0)
            {
                dgvDetails.CurrentCell = dgvDetails.Rows[row_reset].Cells[2]; //设置当前单元格
                dgvDetails.Rows[row_reset].Selected = true; //選中整行
            }            
        }    

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                MessageBox.Show("請首先保存數據,然后方可以進行此查詢操作!");
                return;
            }
            Find_Data();
        }

        private void Find_Data()
        {
            dtDetail.Clear();
            string sql = @"SELECT * From trims_sheet with(nolock) Where 1=1 ";
            if (txtserial_no1.Text == "" && txtserial_no2.Text == "" && dtDat1.Text == "" && dtDat2.Text == "")
                sql = @"SELECT * From trims_sheet with(nolock)";
            else
            {                
                if (txtserial_no1.Text != "")
                {
                    sql = sql + string.Format(" and serial_no>='{0}'", txtserial_no1.Text);
                }
                if (txtserial_no2.Text != "")
                {
                    sql = sql + string.Format(" and serial_no<='{0}'", txtserial_no2.Text);
                }
                if (txtoc_no1.Text != "")
                {
                    sql = sql + string.Format(" and trim_code>='{0}'", txtoc_no1.Text);
                }
                if (txtoc_no2.Text != "")
                {
                    sql = sql + string.Format(" and trim_code<='{0}'", txtoc_no2.Text);
                }
                if (dtDat1.Text != "")
                {
                    sql = sql + string.Format(" and form_date>='{0}'", clsApp.Return_String_Date(dtDat1.Text));
                }
                if (dtDat2.Text != "")
                {
                    sql = sql + string.Format(" and form_date<='{0}'", clsApp.Return_String_Date(dtDat2.Text));
                }
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            //bds1.DataSource = dtDetail;
            dgvDetails.DataSource = dtDetail;
            dgvFind.DataSource = dtDetail;
        }

        /// <summary>
        /// 新增或編號時更新Datagridview的值
        /// 不必從服務端重新下載
        /// </summary>
        private void ReSet_Datagrid_Value()
        {
            //string strSerial_no = txtserial_no.Text;
            if (mState == "NEW" || mState == "EDIT")
            {
                //取得當前新增或修改的行
                //dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select serial_no,create_by,create_date,update_by,update_date From dbo.trims_sheet with(nolock) WHERE serial_no='{0}'", strSerial_no));
                if (mState == "NEW")
                {
                    //dgvDetails.AllowUserToAddRows = true;                    
                    DataRow row = dtDetail.NewRow();//插一空行
                    row["serial_no"] = txtserial_no.Text ;
                    row["form_date"] = clsApp.Return_String_Date(txtform_date.Text);
                    row["new_submit"] = chknew_submit.Checked ? true : false;
                    row["counter"] = chkcounter.Checked ? true : false;
                    row["new_development"] = chknew_development.Checked ? true : false;
                    row["trim_code"] = txttrim_code.Text;
                    row["brand_id"] = luebrand_id.EditValue;
                    row["brand_desc"] = txtbrand_desc.EditValue;
                    row["season"] = txtseason.Text;
                    row["artwork_code"] = txtartwork_code.Text;
                    row["mill_article"] = txtmill_article.Text;
                    row["agent_mill"] = txtagent_mill.Text;
                    row["pattern"] = txtpattern.Text;
                    row["width_weight"] = txtwidth_weight.Text;
                    row["contents"] = txtcontents.Text;
                    row["customer_color"] = txtcustomer_color.Text;
                    row["size"] = txtsize.Text;
                    row["cf_color"] = txtcf_color.Text;
                    row["construction"] = txtconstruction.Text;
                    row["cost_ex_fty"] = txtcost_ex_fty.Text;
                    row["cost_fob"] = txtcost_fob.Text;
                    row["lead_time"] = txtlead_time.Text;
                    row["remark1"] = memremark1.Text;
                    row["remark2"] = memremark2.Text;
                    row["material"] = txtmaterial.Text;
                    row["ref_no"] = txtref_no.Text;
                    row["to_by"] = txtto_by.Text;
                    row["from_by"] = txtfrom_by.Text;

                    row["create_by"] = txtCreate_by.Text;
                    if (!string.IsNullOrEmpty(txtCreate_date.Text))
                    {
                        row["create_date"] = DateTime.Parse(txtCreate_date.Text);
                    }
                    row["update_by"] = txtUpdate_by.Text;
                    if (!string.IsNullOrEmpty(txtUpdate_date.Text))
                    {
                        row["update_date"] = DateTime.Parse(txtUpdate_date.Text);
                    }
                    dtDetail.Rows.Add(row);
                }
                else
                { 
                    dtDetail.Rows[row_reset]["serial_no"] = txtserial_no.Text;
                    dtDetail.Rows[row_reset]["form_date"] = clsApp.Return_String_Date(txtform_date.Text);
                    dtDetail.Rows[row_reset]["trim_code"] = txttrim_code.Text;
                    dtDetail.Rows[row_reset]["new_submit"] = chknew_submit.Checked ? true : false;
                    dtDetail.Rows[row_reset]["counter"] = chkcounter.Checked ? true : false;
                    dtDetail.Rows[row_reset]["new_development"] = chknew_development.Checked ? true : false;
                    dtDetail.Rows[row_reset]["artwork_code"] = txtartwork_code.Text;
                    dtDetail.Rows[row_reset]["brand_id"] = luebrand_id.EditValue;
                    dtDetail.Rows[row_reset]["brand_desc"] = txtbrand_desc.EditValue;
                    dtDetail.Rows[row_reset]["season"] = txtseason.Text;
                    dtDetail.Rows[row_reset]["mill_article"] = txtmill_article.Text;
                    dtDetail.Rows[row_reset]["agent_mill"] = txtagent_mill.Text;
                    dtDetail.Rows[row_reset]["pattern"] = txtpattern.Text;
                    dtDetail.Rows[row_reset]["width_weight"] = txtwidth_weight.Text;
                    dtDetail.Rows[row_reset]["contents"] = txtcontents.Text;
                    dtDetail.Rows[row_reset]["customer_color"] = txtcustomer_color.Text;
                    dtDetail.Rows[row_reset]["size"] = txtsize.Text;
                    dtDetail.Rows[row_reset]["cf_color"] = txtcf_color.Text;
                    dtDetail.Rows[row_reset]["construction"] = txtconstruction.Text;
                    dtDetail.Rows[row_reset]["cost_ex_fty"] = txtcost_ex_fty.Text;
                    dtDetail.Rows[row_reset]["cost_fob"] = txtcost_fob.Text;
                    dtDetail.Rows[row_reset]["lead_time"] = txtlead_time.Text;
                    dtDetail.Rows[row_reset]["remark1"] = memremark1.Text;
                    dtDetail.Rows[row_reset]["remark2"] = memremark2.Text;
                    dtDetail.Rows[row_reset]["material"] = txtmaterial.Text;
                    dtDetail.Rows[row_reset]["ref_no"] = txtref_no.Text;
                    dtDetail.Rows[row_reset]["to_by"] = txtto_by.Text;
                    dtDetail.Rows[row_reset]["from_by"] = txtfrom_by.Text;

                    dtDetail.Rows[row_reset]["create_by"] = txtCreate_by.Text;
                    dtDetail.Rows[row_reset]["create_date"] = txtCreate_date.Text;
                    dtDetail.Rows[row_reset]["update_by"] = txtUpdate_by.Text;
                    dtDetail.Rows[row_reset]["update_date"] = txtUpdate_date.Text;
                }
                dtDetail.AcceptChanges();
                dgvDetails.DataSource = dtDetail;
                dgvDetails.Refresh();
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Brown,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                row_reset = dgvDetails.CurrentCell.RowIndex;
                dgvrow = dgvDetails.CurrentRow;
                Set_head(dgvrow);
            }
        }

        private void Set_head(DataGridViewRow pdr)
        {
            mID = pdr.Cells["serial_no"].Value.ToString();            
            txtserial_no.Text = pdr.Cells["serial_no"].Value.ToString();
            txtform_date.Text = clsApp.Return_String_Date(pdr.Cells["form_date"].Value.ToString());
            if (pdr.Cells["new_submit"].Value.ToString() == "True")
                chknew_submit.Checked = true;
            else
                chknew_submit.Checked = false;
            if (pdr.Cells["counter"].Value.ToString() == "True")
                chkcounter.Checked = true;
            else
                chkcounter.Checked = false;
            if (pdr.Cells["new_development"].Value.ToString() == "True")
                chknew_development.Checked = true;
            else
                chknew_development.Checked = false;
           txttrim_code.Text = pdr.Cells["trim_code"].Value.ToString();
           luebrand_id.EditValue = pdr.Cells["brand_id"].Value.ToString();
           txtbrand_desc.Text = pdr.Cells["brand_desc"].Value.ToString();
           txtseason.Text = pdr.Cells["season"].Value.ToString();
           txtartwork_code.Text = pdr.Cells["artwork_code"].Value.ToString();
           txtmill_article.Text = pdr.Cells["mill_article"].Value.ToString();
           txtagent_mill.Text = pdr.Cells["agent_mill"].Value.ToString();
           txtpattern.Text = pdr.Cells["pattern"].Value.ToString();
           txtwidth_weight.Text = pdr.Cells["width_weight"].Value.ToString();
           txtcontents.Text = pdr.Cells["contents"].Value.ToString();
           txtcustomer_color.Text = pdr.Cells["customer_color"].Value.ToString();
           txtsize.Text = pdr.Cells["size"].Value.ToString();
           txtcf_color.Text = pdr.Cells["cf_color"].Value.ToString();
           txtconstruction.Text = pdr.Cells["construction"].Value.ToString();
           txtcost_ex_fty.Text = pdr.Cells["cost_ex_fty"].Value.ToString();
           txtcost_fob.Text = pdr.Cells["cost_fob"].Value.ToString();
           txtlead_time.Text = pdr.Cells["lead_time"].Value.ToString();
           memremark1.Text = pdr.Cells["remark1"].Value.ToString();
           memremark2.Text = pdr.Cells["remark2"].Value.ToString();
           txtmaterial.Text = pdr.Cells["material"].Value.ToString();
           txtref_no.Text = pdr.Cells["ref_no"].Value.ToString();
           txtto_by.Text = pdr.Cells["to_by"].Value.ToString();
           txtfrom_by.Text = pdr.Cells["from_by"].Value.ToString();
           txtCreate_by.Text = pdr.Cells["create_by"].Value.ToString();
           if (!string.IsNullOrEmpty(pdr.Cells["create_date"].Value.ToString()))
           {
               txtCreate_date.Text = pdr.Cells["create_date"].Value.ToString();
           }
           txtUpdate_by.Text = pdr.Cells["update_by"].Value.ToString();
           if (!string.IsNullOrEmpty(pdr.Cells["update_date"].Value.ToString()))
           {
               txtUpdate_date.Text = pdr.Cells["update_date"].Value.ToString();
           }
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtserial_no2.Text = txtserial_no1.Text;
        }

        private void dtDat1_Leave(object sender, EventArgs e)
        {
            dtDat2.Text = dtDat1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount ==0)
            {
                MessageBox.Show("沒有要列印的數據！","提示信息");
                return;
            }
            string strsql = string.Format(
            @"Select *,
            CASE WHEN ISNULL(brand_id,'')=ISNULL(brand_desc,'') THEN ISNULL(brand_id,'')
                 WHEN ISNULL(brand_id,'')<>ISNULL(brand_desc,'') AND ISNULL(brand_desc,'')<>'' THEN ISNULL(brand_desc,'')
                 WHEN ISNULL(brand_id,'')<>ISNULL(brand_desc,'') AND ISNULL(brand_desc,'')='' THEN ISNULL(brand_id,'')
            END as brand_desc
            FROM dbo.trims_sheet WHERE serial_no='{0}'", txtserial_no.Text);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(strsql);
            using (xrTrimsSheet rpt = new xrTrimsSheet() { DataSource = dtReport })
            {
                rpt.CreateDocument();
                rpt.PrintingSystem.ShowMarginsWarning = false;
                rpt.ShowPreviewDialog();
            }
        }     

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                AddNew();
                Set_head(dgvrow);
                txtform_date.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                txtserial_no.Text = clsTommyTest.GetSeqNo("trims_sheet", "serial_no");
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txttrim_code_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txttrim_code.Text != "" && mState != "")
            {
                using (frmTrimsSheetFind ofrmFind = new frmTrimsSheetFind(txttrim_code.Text))
                {
                    ofrmFind.ShowDialog();
                    if (ofrmFind.mList.Count > 0)
                    {
                        foreach (mdlQuotation stu in ofrmFind.mList)
                        {
                            txttrim_code.Text = stu.trim_code;
                            luebrand_id.EditValue = stu.brand;
                            txtbrand_desc.Text = stu.brand_desc;
                            //txtseason.Text = stu.season ;
                            txtseason.Text = !string.IsNullOrEmpty(stu.season) ? stu.season : stu.season_desc;
                            txtmill_article.Text = stu.cf_code;
                            txtcustomer_color.Text = stu.cust_color;
                            txtcf_color.Text = stu.cf_color;
                            txtsize.Text = stu.size;
                            txtconstruction.Text = stu.product_desc;
                            txtlead_time.Text = stu.lead_time_max;
                            txtmaterial.Text = stu.material;
                            txtref_no.Text = stu.sub;

                            string strPrice_ex_fty = "", strPrice_fob="";
                            strPrice_ex_fty = stu.usd_ex_fty > 0 ? String.Format("EX-FTY  USD:{0}/{1}", stu.usd_ex_fty, stu.price_unit) : "";
                            strPrice_ex_fty += stu.hkd_ex_fty > 0 ? String.Format("    HKD:{0}/{1}", stu.hkd_ex_fty, stu.price_unit) : "";
                            strPrice_fob = stu.price_usd > 0 ? String.Format("FOB       USD:{0}/{1}", stu.price_usd, stu.price_unit) : "";
                            strPrice_fob += stu.price_hkd > 0 ? String.Format("    HKD:{0}/{1}", stu.price_hkd, stu.price_unit) : "";

                            txtcost_ex_fty.Text = strPrice_ex_fty;
                            txtcost_fob.Text = strPrice_fob;
                        }
                    }
                }
            }
        }

        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }
            tabControl1.SelectedIndex = 0;            
        }

        private void luebrand_id_EditValueChanged(object sender, EventArgs e)
        {
            if (mState != "")
            {
                txtbrand_desc.Text = luebrand_id.GetColumnValue("cdesc").ToString();
            }
        }
    }
}
