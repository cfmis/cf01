/*
 * Create by :   Allen Leung 
 * Create Date : 2018-11-06
 * remark:
 * HK E組 TOMMY 牌子客戶測試報告別記錄
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
using System.Runtime.InteropServices;

namespace cf01.Forms
{
    public partial class frmTommyTest : Form
    {
        public string mID = "";    //臨時的主鍵值
        public int row_reset = 0;
        public DataTable dtDetail = new DataTable();
        public DataTable dtReSet = new DataTable();
        public DataTable dtMO = new DataTable();        
        public string mState = "";         
        clsToolBar objToolbar;
        private clsAppPublic clsApp = new clsAppPublic();
        private DataGridViewRow dgvrow = new DataGridViewRow();

        //提示信息窗口自動關閉聲明
        //需引入using System.Runtime.InteropServices;
        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeout(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);


        public frmTommyTest()
        {
            InitializeComponent();

            //權限
            objToolbar = new clsToolBar(this.Name, this.Controls);
            objToolbar.SetToolBar();            
              
        }

        private void frmTommyTest_Load(object sender, EventArgs e)
        {
            //Load_Date();
            const string sql = @"SELECT * From tommy_test_record with(nolock) where 1=0 ";
            dtDetail = clsPublicOfCF01.GetDataTable(sql);           
            dgvDetails.DataSource = dtDetail;

            clsQuotation.Set_Unit(lkep_unit1);
            clsQuotation.Set_Unit(lkep_unit2);
            clsQuotation.Set_Unit(lkep_unit3);
            clsQuotation.Set_Unit(lkep_unit4);
            clsQuotation.Set_Unit(lkep_unit5);
            DataTable dtMoney = clsPublicOfCF01.GetDataTable(@"SELECT '' as id,'' as cdesc Union SELECT id,name as cdesc FROM dgerp2.cferp.dbo.cd_money WHERE state='0'");
            lkem_id1.Properties.DataSource = dtMoney;
            lkem_id1.Properties.ValueMember = "id";
            lkem_id1.Properties.DisplayMember = "id";

            lkem_id2.Properties.DataSource = dtMoney;
            lkem_id2.Properties.ValueMember = "id";
            lkem_id2.Properties.DisplayMember = "id";

            lkem_id3.Properties.DataSource = dtMoney;
            lkem_id3.Properties.ValueMember = "id";
            lkem_id3.Properties.DisplayMember = "id";

            lkem_id4.Properties.DataSource = dtMoney;
            lkem_id4.Properties.ValueMember = "id";
            lkem_id4.Properties.DisplayMember = "id";

            lkem_id5.Properties.DataSource = dtMoney;
            lkem_id5.Properties.ValueMember = "id";
            lkem_id5.Properties.DisplayMember = "id";

            const string strSql = @"Select '' as id,'' as cdesc Union Select id,name as cdesc From dgerp2.cferp.dbo.cd_season where state='0' Order by id";
            DataTable dtSeason = new DataTable();
            dtSeason = clsPublicOfCF01.GetDataTable(strSql);
            txtseason.Properties.DataSource = dtSeason;
            txtseason.Properties.ValueMember = "id";
            txtseason.Properties.DisplayMember = "cdesc";

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
            txtdate.Text = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
            txtserial_no.Text = clsTommyTest.GetSeqNo("tommy_test_record","serial_no");
            txtsupplier_name.Text = "CHING FUNG / CHING FUNG METAL MANUFACTORY (LONGNAM)CO.,LTD";
            txtcountry.Text = "MADE IN CHINA";
            txtmoq_usa.Text = "NA";
            txtmoq_eur.Text = "NA";
            txtleadtime_sample.Text = "2 WEEKS";
            txtsurcharge_usa.Text = "NA";
            txtsurcharge_eur.Text = "NA";
            txtleadtime_bulk.Text = "4 WEEKS";
            txttrim_must_tommy.Text = "YES";
            txtoekotex.Text = "OEKO-TEX STANDARD 100 # HKS 18549 TESTEX";

            txtserial_no.Properties.ReadOnly = true;
            txtserial_no.BackColor = Color.White;

            dgvDetails.Enabled = false;
            txtseason.Focus();    
        }

        private void Save()
        {
            txtserial_no.Focus();
            if (txtserial_no.Text == "" && txtdate.Text == "")
            {
                MessageBox.Show("Serial No.、日期不可为空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdate.Focus();
                return;
            }
            //bds1.EndEdit();
            //dgvDetails.CurrentCell.RowIndex;行號 
            //Select a Cell Focus
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO tommy_test_record(serial_no,season,date,trim_code,requests_by,delivery,pvh_jv_ref,supplier_name,material,size,country,color,artwork_limit,
            tiered_qty1,price_size1,m_id1,price1,p_unit1,tiered_qty2,price_size2,m_id2,price2,p_unit2,tiered_qty3,price_size3,m_id3,price3,p_unit3,tiered_qty4,price_size4,m_id4,price4,p_unit4,tiered_qty5,price_size5,m_id5,price5,p_unit5,
            moq_usa,surcharge_usa,moq_eur,surcharge_eur,leadtime_sample,leadtime_bulk,trim_must_tommy,oekotex,suggested_care,machine_washable,drycleanable,dryclean_only,do_not_dryclean,
            use_for_swimwear,use_for_childrenswear,cannot_pass_needle,quality_callouts,used_on_sms_eur,latest_submit_ref,best_vendor_do,bulk_reference,color_approved_size,
            quality_approval,size_approved_color,submit1,submit2,submit3,urgent,cs_mens,cs_womens,cs_boys,cs_girls,thm,thd,branding,th_spw_msw,th_spw_wsw,th_col_msw,th_col_wsw,
            th_kids,th_swim,th_underwear,th_acc_ftw,th_tailored,tommy_jeans,th_sport,mo_id1,mo_id2,mo_id3,color1,color2,color3,size1,size2,size3,create_by,create_date) 
            VALUES(@serial_no,@season,@date,@trim_code,@requests_by,@delivery,@pvh_jv_ref,@supplier_name,@material,@size,@country,@color,@artwork_limit,
            @tiered_qty1,@price_size1,@m_id1,@price1,@p_unit1,@tiered_qty2,@price_size2,@m_id2,@price2,@p_unit2,@tiered_qty3,@price_size3,@m_id3,@price3,@p_unit3,@tiered_qty4,@price_size4,@m_id4,@price4,@p_unit4,@tiered_qty5,@price_size5,@m_id5,@price5,@p_unit5,
            @moq_usa,@surcharge_usa,@moq_eur,@surcharge_eur,@leadtime_sample,@leadtime_bulk,@trim_must_tommy,@oekotex,@suggested_care,@machine_washable,@drycleanable,@dryclean_only,@do_not_dryclean,
            @use_for_swimwear,@use_for_childrenswear,@cannot_pass_needle,@quality_callouts,@used_on_sms_eur,@latest_submit_ref,@best_vendor_do,@bulk_reference,@color_approved_size,
            @quality_approval,@size_approved_color,@submit1,@submit2,@submit3,@urgent,@cs_mens,@cs_womens,@cs_boys,@cs_girls,@thm,@thd,@branding,@th_spw_msw,@th_spw_wsw,@th_col_msw,@th_col_wsw,
            @th_kids,@th_swim,@th_underwear,@th_acc_ftw,@th_tailored,@tommy_jeans,@th_sport,@mo_id1,@mo_id2,@mo_id3,@color1,@color2,@color3,@size1,@size2,@size3,@user_id,getdate())";

            const string sql_update =
            @"Update tommy_test_record 
            SET season=@season,date=@date,trim_code=@trim_code,requests_by=@requests_by,delivery=@delivery,pvh_jv_ref=@pvh_jv_ref,supplier_name=@supplier_name,material=@material,size=@size,country=@country,color=@color,artwork_limit=@artwork_limit,
            tiered_qty1=@tiered_qty1,price_size1=@price_size1,m_id1=@m_id1,price1=@price1,p_unit1=@p_unit1,tiered_qty2=@tiered_qty2,price_size2=@price_size2,m_id2=@m_id2,price2=@price2,p_unit2=@p_unit2,tiered_qty3=@tiered_qty3,price_size3=@price_size3,m_id3=@m_id3,price3=@price3,p_unit3=@p_unit3,
            tiered_qty4=@tiered_qty4,price_size4=@price_size4,m_id4=@m_id4,price4=@price4,p_unit4=@p_unit4,tiered_qty5=@tiered_qty5,price_size5=@price_size5,m_id5=@m_id5,price5=@price5,p_unit5=@p_unit5,
            moq_usa=@moq_usa,surcharge_usa=@surcharge_usa,moq_eur=@moq_eur,surcharge_eur=@surcharge_eur,leadtime_sample=@leadtime_sample,leadtime_bulk=@leadtime_bulk,trim_must_tommy=@trim_must_tommy,oekotex=@oekotex,suggested_care=@suggested_care,machine_washable=@machine_washable,drycleanable=@drycleanable,dryclean_only=@dryclean_only,do_not_dryclean=@do_not_dryclean,
            use_for_swimwear=@use_for_swimwear,use_for_childrenswear=@use_for_childrenswear,cannot_pass_needle=@cannot_pass_needle,quality_callouts=@quality_callouts,used_on_sms_eur=@used_on_sms_eur,latest_submit_ref=@latest_submit_ref,best_vendor_do=@best_vendor_do,bulk_reference=@bulk_reference,color_approved_size=@color_approved_size,
            quality_approval=@quality_approval,size_approved_color=@size_approved_color,submit1=@submit1,submit2=@submit2,submit3=@submit3,urgent=@urgent,cs_mens=@cs_mens,cs_womens=@cs_womens,cs_boys=@cs_boys,cs_girls=@cs_girls,thm=@thm,thd=@thd,branding=@branding,th_spw_msw=@th_spw_msw,th_spw_wsw=@th_spw_wsw,th_col_msw=@th_col_msw,th_col_wsw=@th_col_wsw,
            th_kids=@th_kids,th_swim=@th_swim,th_underwear=@th_underwear,th_acc_ftw=@th_acc_ftw,th_tailored=@th_tailored,tommy_jeans=@tommy_jeans,th_sport=@th_sport,mo_id1=@mo_id1,mo_id2=@mo_id2,mo_id3=@mo_id3,color1=@color1,color2=@color2,color3=@color3,size1=@size1,size2=@size2,size3=@size3,update_by=@user_id,update_date=getdate()
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
                        strSerial_no = clsTommyTest.GetSeqNo("tommy_test_record", "serial_no");
                        myCommand.Parameters.AddWithValue("@serial_no", strSerial_no);
                    }
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@serial_no", txtserial_no.Text);
                        strSerial_no = txtserial_no.Text;
                    }
                    myCommand.Parameters.AddWithValue("@season", txtseason.EditValue);
                    myCommand.Parameters.AddWithValue("@date", clsApp.Return_String_Date(txtdate.Text));
                    myCommand.Parameters.AddWithValue("@trim_code", txttrim_code.Text);
                    myCommand.Parameters.AddWithValue("@requests_by", txtrequests_by.Text);
                    myCommand.Parameters.AddWithValue("@delivery", txtdelivery.Text);
                    myCommand.Parameters.AddWithValue("@pvh_jv_ref", txtpvh_jv_ref.Text);
                    myCommand.Parameters.AddWithValue("@supplier_name", txtsupplier_name.Text);
                    myCommand.Parameters.AddWithValue("@material", txtmaterial.Text);
                    myCommand.Parameters.AddWithValue("@size", txtsize.Text);
                    myCommand.Parameters.AddWithValue("@country", txtcountry.Text);
                    myCommand.Parameters.AddWithValue("@color", txtcolor.Text);
                    myCommand.Parameters.AddWithValue("@artwork_limit", txtartwork_limit.Text);
                    //----------------------------------------------------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@tiered_qty1", clsTommyTest.Get_int(txttiered_qty1.Text));
                    myCommand.Parameters.AddWithValue("@price_size1", txtprice_size1.Text);
                    myCommand.Parameters.AddWithValue("@m_id1", lkem_id1.EditValue);
                    myCommand.Parameters.AddWithValue("@price1", clsApp.Return_Float_Value_4(txtprice1.Text));
                    myCommand.Parameters.AddWithValue("@p_unit1", lkep_unit1.EditValue);

                    myCommand.Parameters.AddWithValue("@tiered_qty2", clsTommyTest.Get_int(txttiered_qty2.Text));
                    myCommand.Parameters.AddWithValue("@price_size2", txtprice_size2.Text);
                    myCommand.Parameters.AddWithValue("@m_id2", lkem_id2.EditValue);
                    myCommand.Parameters.AddWithValue("@price2", clsApp.Return_Float_Value_4(txtprice2.Text));
                    myCommand.Parameters.AddWithValue("@p_unit2", lkep_unit2.EditValue);
                    myCommand.Parameters.AddWithValue("@tiered_qty3", clsTommyTest.Get_int(txttiered_qty3.Text));
                    myCommand.Parameters.AddWithValue("@price_size3", txtprice_size3.Text);
                    myCommand.Parameters.AddWithValue("@m_id3", lkem_id3.EditValue);
                    myCommand.Parameters.AddWithValue("@price3", clsApp.Return_Float_Value_4(txtprice3.Text));
                    myCommand.Parameters.AddWithValue("@p_unit3", lkep_unit3.EditValue);
                    myCommand.Parameters.AddWithValue("@tiered_qty4", clsTommyTest.Get_int(txttiered_qty4.Text));
                    myCommand.Parameters.AddWithValue("@price_size4", txtprice_size4.Text);
                    myCommand.Parameters.AddWithValue("@m_id4", lkem_id4.EditValue);
                    myCommand.Parameters.AddWithValue("@price4", clsApp.Return_Float_Value_4(txtprice4.Text));
                    myCommand.Parameters.AddWithValue("@p_unit4", lkep_unit4.EditValue);
                    myCommand.Parameters.AddWithValue("@tiered_qty5", clsTommyTest.Get_int(txttiered_qty5.Text));
                    myCommand.Parameters.AddWithValue("@price_size5", txtprice_size5.Text);
                    myCommand.Parameters.AddWithValue("@m_id5", lkem_id5.EditValue);
                    myCommand.Parameters.AddWithValue("@price5", clsApp.Return_Float_Value_4(txtprice5.Text));
                    myCommand.Parameters.AddWithValue("@p_unit5", lkep_unit5.EditValue);
                    myCommand.Parameters.AddWithValue("@moq_usa", txtmoq_usa.Text);
                    myCommand.Parameters.AddWithValue("@surcharge_usa", txtsurcharge_usa.Text);
                    myCommand.Parameters.AddWithValue("@moq_eur", txtmoq_eur.Text);
                    myCommand.Parameters.AddWithValue("@surcharge_eur", txtsurcharge_eur.Text);
                    myCommand.Parameters.AddWithValue("@leadtime_sample", txtleadtime_sample.Text);
                    myCommand.Parameters.AddWithValue("@leadtime_bulk", txtleadtime_bulk.Text);
                    //-----------------------------------------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@trim_must_tommy", txttrim_must_tommy.Text);
                    myCommand.Parameters.AddWithValue("@oekotex", txtoekotex.Text);
                    myCommand.Parameters.AddWithValue("@suggested_care", txtsuggested_care.Text);
                    //---------------------------------------------------------
                    myCommand.Parameters.AddWithValue("@machine_washable", chkmachine_washable.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@drycleanable", chkdrycleanable.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@dryclean_only", chkdryclean_only.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@do_not_dryclean", chkdo_not_dryclean.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@use_for_swimwear", chkuse_for_swimwear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@use_for_childrenswear", chkuse_for_childrenswear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cannot_pass_needle", chkcannot_pass_needle.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@quality_callouts", memquality_callouts.Text);
                    //-----------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@used_on_sms_eur", txtused_on_sms_eur.Text);
                    myCommand.Parameters.AddWithValue("@latest_submit_ref", txtlatest_submit_ref.Text);
                    myCommand.Parameters.AddWithValue("@best_vendor_do", txtbest_vendor_do.Text);
                    myCommand.Parameters.AddWithValue("@bulk_reference", txtbulk_reference.Text);
                    myCommand.Parameters.AddWithValue("@color_approved_size", txtcolor_approved_size.Text);
                    myCommand.Parameters.AddWithValue("@quality_approval", txtquality_approval.Text);
                    myCommand.Parameters.AddWithValue("@size_approved_color", txtsize_approved_color.Text);
                    //-----------------------------------------------------------                    
                    myCommand.Parameters.AddWithValue("@submit1", chksubmit1.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@submit2", chksubmit2.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@submit3", chksubmit3.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@urgent", chkurgent.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_mens", chkcs_mens.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_womens", chkcs_womens.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_boys", chkcs_boys.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@cs_girls", chkcs_girls.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@thm", chkthm.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@thd", chkthd.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@branding", chkbranding.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_spw_msw", chkth_spw_msw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_spw_wsw", chkth_spw_wsw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_col_msw", chkth_col_msw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_col_wsw", chkth_col_wsw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_kids", chkth_kids.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_swim", chkth_swim.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_underwear", chkth_underwear.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_acc_ftw", chkth_acc_ftw.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_tailored", chkth_tailored.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@tommy_jeans", chktommy_jeans.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@th_sport", chkth_sport.Checked ? true : false);
                    myCommand.Parameters.AddWithValue("@mo_id1", txtmo_id1.Text);
                    myCommand.Parameters.AddWithValue("@mo_id2", txtmo_id2.Text);
                    myCommand.Parameters.AddWithValue("@mo_id3", txtmo_id3.Text);
                    myCommand.Parameters.AddWithValue("@color1", txtcolor1.Text);
                    myCommand.Parameters.AddWithValue("@color2", txtcolor2.Text);
                    myCommand.Parameters.AddWithValue("@color3", txtcolor3.Text);
                    myCommand.Parameters.AddWithValue("@size1", txtsize1.Text);
                    myCommand.Parameters.AddWithValue("@size2", txtsize2.Text);
                    myCommand.Parameters.AddWithValue("@size3", txtsize3.Text);
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
                MessageBoxTimeout((IntPtr )0,"數據保存成功!","提示信息",0,0,1000); //提示窗體1秒后自動關閉               
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
                const string sql_del = "DELETE FROM dbo.tommy_test_record WHERE serial_no=@serial_no";
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

        private void frmTommyTest_FormClosed(object sender, FormClosedEventArgs e)
        {
           dtDetail.Dispose();
           dtReSet.Dispose();
           dtMO.Dispose();
           objToolbar = null;
           clsApp = null;
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
            string sql = @"SELECT * From tommy_test_record with(nolock) Where 1=1 ";
            if (txtId1.Text == "" && txtId2.Text == "" && dtDat1.Text == "" && dtDat2.Text == "")
                sql = @"SELECT * From tommy_test_record with(nolock)";
            else
            {                
                if (txtId1.Text != "")
                {
                    sql = sql + string.Format(" and serial_no>='{0}'", txtId1.Text);
                }
                if (txtId2.Text != "")
                {
                    sql = sql + string.Format(" and serial_no<='{0}'", txtId2.Text);
                }
                if (dtDat1.Text != "")
                {
                    sql = sql + string.Format(" and date>='{0}'", clsApp.Return_String_Date(dtDat1.Text));
                }
                if (dtDat2.Text != "")
                {
                    sql = sql + string.Format(" and date<='{0}'", clsApp.Return_String_Date(dtDat2.Text));
                }
            }
            dtDetail = clsPublicOfCF01.GetDataTable(sql);
            //bds1.DataSource = dtDetail;
            dgvDetails.DataSource = dtDetail;
            dgvFind.DataSource = dtDetail;
        }
     
        private void txtprice1_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice1); 
        }

        private void txtprice2_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice2); 
        }

        private void txtprice3_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice3); 
        }

        private void txtprice4_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice4); 
        }

        private void txtprice5_Click(object sender, EventArgs e)
        {
            Set_Number_Focus(txtprice5); 
        }

        private static void Set_Number_Focus(DevExpress.XtraEditors.TextEdit objTextEdit)
        {
            if (objTextEdit.Text == "0.0000")
            {
                objTextEdit.Select(1, 0);
            }
        }

        /// <summary>
        /// 新增或編號時更新Datagridview的值
        /// 不必從服務端重新下載
        /// </summary>
        private void ReSet_Datagrid_Value()
        {
            string strSerial_no = txtserial_no.Text;
            if (mState == "NEW" || mState == "EDIT")
            {
                //取得當前新增或修改的行
                dtReSet = clsPublicOfCF01.GetDataTable(string.Format("Select serial_no,create_by,create_date,update_by,update_date From dbo.tommy_test_record with(nolock) WHERE serial_no='{0}'", strSerial_no));
                if (mState == "NEW")
                {
                    //dgvDetails.AllowUserToAddRows = true;                    
                    DataRow row = dtDetail.NewRow();//插一空行                   
                    //--------------------------------------------------------------
                    row["serial_no"]=txtserial_no.Text ;
                    row["season"] = txtseason.EditValue;
                    row["date"] = clsApp.Return_String_Date(txtdate.Text);
                    row["trim_code"] = txttrim_code.Text;
                    row["requests_by"] = txtrequests_by.Text;
                    row["delivery"] = txtdelivery.Text;
                    row["pvh_jv_ref"] = txtpvh_jv_ref.Text;
                    row["supplier_name"] = txtsupplier_name.Text ;
                    row["material"] = txtmaterial.Text;
                    row["size"] = txtsize.Text;
                    row["country"] = txtcountry.Text;
                    row["color"] = txtcolor.Text;
                    row["artwork_limit"] = txtartwork_limit.Text;
                    //===============================================================
                    row["tiered_qty1"] = clsTommyTest.Get_int(txttiered_qty1.Text);
                    row["price_size1"] = txtprice_size1.Text;
                    row["m_id1"] = lkem_id1.EditValue;
                    row["price1"] = clsApp.Return_Float_Value_4(txtprice1.Text);
                    row["p_unit1"] = lkep_unit1.EditValue;
                    //
                    row["tiered_qty2"] = clsTommyTest.Get_int(txttiered_qty2.Text);
                    row["price_size2"] = txtprice_size2.Text;
                    row["m_id2"] = lkem_id2.EditValue;
                    row["price2"] = clsApp.Return_Float_Value_4(txtprice2.Text);
                    row["p_unit2"] = lkep_unit2.EditValue;
                    //
                    row["tiered_qty3"] = clsTommyTest.Get_int(txttiered_qty3.Text);
                    row["price_size3"] = txtprice_size3.Text;
                    row["m_id3"] = lkem_id3.EditValue;
                    row["price3"] = clsApp.Return_Float_Value_4(txtprice3.Text);
                    row["p_unit3"] = lkep_unit3.EditValue;
                    //
                    row["tiered_qty4"] = clsTommyTest.Get_int(txttiered_qty4.Text);
                    row["price_size4"] = txtprice_size4.Text;
                    row["m_id4"] = lkem_id4.EditValue;
                    row["price4"] = clsApp.Return_Float_Value_4(txtprice4.Text);
                    row["p_unit4"] = lkep_unit4.EditValue;
                    //
                    row["tiered_qty5"] = clsTommyTest.Get_int(txttiered_qty5.Text);
                    row["price_size5"] = txtprice_size5.Text;
                    row["m_id5"] = lkem_id5.EditValue;
                    row["price5"] = clsApp.Return_Float_Value_4(txtprice5.Text);
                    row["p_unit5"] = lkep_unit5.EditValue;
                    //
                    row["moq_usa"] = txtmoq_usa.Text;
                    row["surcharge_usa"] = txtsurcharge_usa.Text;
                    row["moq_eur"] = txtmoq_eur.Text;
                    row["surcharge_eur"] = txtsurcharge_eur.Text;
                    row["leadtime_sample"] = txtleadtime_sample.Text;
                    row["leadtime_bulk"] = txtleadtime_bulk.Text;
                    //=================================================================
                    row["trim_must_tommy"] = txttrim_must_tommy.Text;
                    row["oekotex"] = txtoekotex.Text;
                    row["suggested_care"] = txtsuggested_care.Text;
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
                    //=================================================================
                    row["machine_washable"] = chkmachine_washable.Checked ? true : false;
                    row["drycleanable"] = chkdrycleanable.Checked ? true : false;
                    row["dryclean_only"] = chkdryclean_only.Checked ? true : false;
                    row["do_not_dryclean"] = chkdo_not_dryclean.Checked ? true : false;
                    row["use_for_swimwear"] = chkuse_for_swimwear.Checked ? true : false;
                    row["use_for_childrenswear"] = chkuse_for_childrenswear.Checked ? true : false;
                    row["cannot_pass_needle"] = chkcannot_pass_needle.Checked ? true : false;
                    row["quality_callouts"] = memquality_callouts.Text;
                    //=================================================================
                    row["used_on_sms_eur"] = txtused_on_sms_eur.Text;
                    row["latest_submit_ref"] = txtlatest_submit_ref.Text;
                    row["best_vendor_do"] = txtbest_vendor_do.Text;
                    row["bulk_reference"] = txtbulk_reference.Text;
                    row["color_approved_size"] = txtcolor_approved_size.Text;
                    row["quality_approval"] = txtquality_approval.Text;
                    row["size_approved_color"] = txtsize_approved_color.Text;
                    //=================================================================
                    row["submit1"] = chksubmit1.Checked ? true : false;
                    row["submit2"] = chksubmit2.Checked ? true : false;
                    row["submit3"] = chksubmit3.Checked ? true : false;
                    row["urgent"] = chkurgent.Checked ? true : false;
                    row["cs_mens"] = chkcs_mens.Checked ? true : false;
                    row["cs_womens"] = chkcs_womens.Checked ? true : false;
                    row["cs_boys"] = chkcs_boys.Checked ? true : false;
                    row["cs_girls"] = chkcs_girls.Checked ? true : false;
                    row["thm"] = chkthm.Checked ? true : false;
                    row["thd"] = chkthd.Checked ? true : false;
                    row["branding"] = chkbranding.Checked ? true : false;
                    row["th_spw_msw"] = chkth_spw_msw.Checked ? true : false;
                    row["th_spw_wsw"] = chkth_spw_wsw.Checked ? true : false;
                    row["th_col_msw"] = chkth_col_msw.Checked ? true : false;
                    row["th_col_wsw"] = chkth_col_wsw.Checked ? true : false;
                    row["th_kids"] = chkth_kids.Checked ? true : false;
                    row["th_swim"] = chkth_swim.Checked ? true : false;
                    row["th_underwear"] = chkth_underwear.Checked ? true : false;
                    row["th_acc_ftw"] = chkth_acc_ftw.Checked ? true : false;
                    row["th_tailored"] = chkth_tailored.Checked ? true : false;
                    row["tommy_jeans"] = chktommy_jeans.Checked ? true : false;
                    row["th_sport"] = chkth_sport.Checked ? true : false;
                    row["mo_id1"] = txtmo_id1.Text;
                    row["mo_id2"] = txtmo_id2.Text;
                    row["mo_id3"] = txtmo_id3.Text;
                    row["color1"] = txtcolor1.Text;
                    row["color2"] = txtcolor2.Text;
                    row["color3"] = txtcolor3.Text;
                    row["size1"] = txtsize1.Text;
                    row["size2"] = txtsize2.Text;
                    row["size3"] = txtsize3.Text; 
                    dtDetail.Rows.Add(row);
                }
                else
                {                                      
                    //--------------------------------------------------------------
                    dtDetail.Rows[row_reset]["serial_no"] = txtserial_no.Text;
                    dtDetail.Rows[row_reset]["season"] = txtseason.EditValue;
                    dtDetail.Rows[row_reset]["date"] = clsApp.Return_String_Date(txtdate.Text);
                    dtDetail.Rows[row_reset]["trim_code"] = txttrim_code.Text;
                    dtDetail.Rows[row_reset]["requests_by"] = txtrequests_by.Text;
                    dtDetail.Rows[row_reset]["delivery"] = txtdelivery.Text;
                    dtDetail.Rows[row_reset]["pvh_jv_ref"] = txtpvh_jv_ref.Text;
                    dtDetail.Rows[row_reset]["supplier_name"] = txtsupplier_name.Text;
                    dtDetail.Rows[row_reset]["material"] = txtmaterial.Text;
                    dtDetail.Rows[row_reset]["size"] = txtsize.Text;
                    dtDetail.Rows[row_reset]["country"] = txtcountry.Text;
                    dtDetail.Rows[row_reset]["color"] = txtcolor.Text;
                    dtDetail.Rows[row_reset]["artwork_limit"] = txtartwork_limit.Text;
                    //===============================================================
                    dtDetail.Rows[row_reset]["tiered_qty1"] = clsTommyTest.Get_int(txttiered_qty1.Text);
                    dtDetail.Rows[row_reset]["price_size1"] = txtprice_size1.Text;
                    dtDetail.Rows[row_reset]["m_id1"] = lkem_id1.EditValue;
                    dtDetail.Rows[row_reset]["price1"] = clsApp.Return_Float_Value_4(txtprice1.Text);
                    dtDetail.Rows[row_reset]["p_unit1"] = lkep_unit1.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty2"] = clsTommyTest.Get_int(txttiered_qty2.Text);
                    dtDetail.Rows[row_reset]["price_size2"] = txtprice_size2.Text;
                    dtDetail.Rows[row_reset]["m_id2"] = lkem_id2.EditValue;
                    dtDetail.Rows[row_reset]["price2"] = clsApp.Return_Float_Value_4(txtprice2.Text);
                    dtDetail.Rows[row_reset]["p_unit2"] = lkep_unit2.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty3"] = clsTommyTest.Get_int(txttiered_qty3.Text);
                    dtDetail.Rows[row_reset]["price_size3"] = txtprice_size3.Text;
                    dtDetail.Rows[row_reset]["m_id3"] = lkem_id3.EditValue;
                    dtDetail.Rows[row_reset]["price3"] = clsApp.Return_Float_Value_4(txtprice3.Text);
                    dtDetail.Rows[row_reset]["p_unit3"] = lkep_unit3.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty4"] = clsTommyTest.Get_int(txttiered_qty4.Text);
                    dtDetail.Rows[row_reset]["price_size4"] = txtprice_size4.Text;
                    dtDetail.Rows[row_reset]["m_id4"] = lkem_id4.EditValue;
                    dtDetail.Rows[row_reset]["price4"] = clsApp.Return_Float_Value_4(txtprice4.Text);
                    dtDetail.Rows[row_reset]["p_unit4"] = lkep_unit4.EditValue;
                    //
                    dtDetail.Rows[row_reset]["tiered_qty5"] = clsTommyTest.Get_int(txttiered_qty5.Text);
                    dtDetail.Rows[row_reset]["price_size5"] = txtprice_size5.Text;
                    dtDetail.Rows[row_reset]["m_id5"] = lkem_id5.EditValue;
                    dtDetail.Rows[row_reset]["price5"] = clsApp.Return_Float_Value_4(txtprice5.Text);
                    dtDetail.Rows[row_reset]["p_unit5"] = lkep_unit5.EditValue;
                    //
                    dtDetail.Rows[row_reset]["moq_usa"] = txtmoq_usa.Text;
                    dtDetail.Rows[row_reset]["surcharge_usa"] = txtsurcharge_usa.Text;
                    dtDetail.Rows[row_reset]["moq_eur"] = txtmoq_eur.Text;
                    dtDetail.Rows[row_reset]["surcharge_eur"] = txtsurcharge_eur.Text;
                    dtDetail.Rows[row_reset]["leadtime_sample"] = txtleadtime_sample.Text;
                    dtDetail.Rows[row_reset]["leadtime_bulk"] = txtleadtime_bulk.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["trim_must_tommy"] = txttrim_must_tommy.Text;
                    dtDetail.Rows[row_reset]["oekotex"] = txtoekotex.Text;
                    dtDetail.Rows[row_reset]["suggested_care"] = txtsuggested_care.Text;
                    dtDetail.Rows[row_reset]["create_by"] = txtCreate_by.Text;
                    dtDetail.Rows[row_reset]["create_date"] = txtCreate_date.Text;
                    dtDetail.Rows[row_reset]["update_by"] = txtUpdate_by.Text;
                    dtDetail.Rows[row_reset]["update_date"] = txtUpdate_date.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["machine_washable"] = chkmachine_washable.Checked ? true : false;
                    dtDetail.Rows[row_reset]["drycleanable"] = chkdrycleanable.Checked ? true : false;
                    dtDetail.Rows[row_reset]["dryclean_only"] = chkdryclean_only.Checked ? true : false;
                    dtDetail.Rows[row_reset]["do_not_dryclean"] = chkdo_not_dryclean.Checked ? true : false;
                    dtDetail.Rows[row_reset]["use_for_swimwear"] = chkuse_for_swimwear.Checked ? true : false;
                    dtDetail.Rows[row_reset]["use_for_childrenswear"] = chkuse_for_childrenswear.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cannot_pass_needle"] = chkcannot_pass_needle.Checked ? true : false;
                    dtDetail.Rows[row_reset]["quality_callouts"] = memquality_callouts.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["used_on_sms_eur"] = txtused_on_sms_eur.Text;
                    dtDetail.Rows[row_reset]["latest_submit_ref"] = txtlatest_submit_ref.Text;
                    dtDetail.Rows[row_reset]["best_vendor_do"] = txtbest_vendor_do.Text;
                    dtDetail.Rows[row_reset]["bulk_reference"] = txtbulk_reference.Text;
                    dtDetail.Rows[row_reset]["color_approved_size"] = txtcolor_approved_size.Text;
                    dtDetail.Rows[row_reset]["quality_approval"] = txtquality_approval.Text;
                    dtDetail.Rows[row_reset]["size_approved_color"] = txtsize_approved_color.Text;
                    //=================================================================
                    dtDetail.Rows[row_reset]["submit1"] = chksubmit1.Checked ? true : false;
                    dtDetail.Rows[row_reset]["submit2"] = chksubmit2.Checked ? true : false;
                    dtDetail.Rows[row_reset]["submit3"] = chksubmit3.Checked ? true : false;
                    dtDetail.Rows[row_reset]["urgent"] = chkurgent.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_mens"] = chkcs_mens.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_womens"] = chkcs_womens.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_boys"] = chkcs_boys.Checked ? true : false;
                    dtDetail.Rows[row_reset]["cs_girls"] = chkcs_girls.Checked ? true : false;
                    dtDetail.Rows[row_reset]["thm"] = chkthm.Checked ? true : false;
                    dtDetail.Rows[row_reset]["thd"] = chkthd.Checked ? true : false;
                    dtDetail.Rows[row_reset]["branding"] = chkbranding.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_spw_msw"] = chkth_spw_msw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_spw_wsw"] = chkth_spw_wsw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_col_msw"] = chkth_col_msw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_col_wsw"] = chkth_col_wsw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_kids"] = chkth_kids.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_swim"] = chkth_swim.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_underwear"] = chkth_underwear.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_acc_ftw"] = chkth_acc_ftw.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_tailored"] = chkth_tailored.Checked ? true : false;
                    dtDetail.Rows[row_reset]["tommy_jeans"] = chktommy_jeans.Checked ? true : false;
                    dtDetail.Rows[row_reset]["th_sport"] = chkth_sport.Checked ? true : false;
                    dtDetail.Rows[row_reset]["mo_id1"] = txtmo_id1.Text;
                    dtDetail.Rows[row_reset]["mo_id2"] = txtmo_id2.Text;
                    dtDetail.Rows[row_reset]["mo_id3"] = txtmo_id3.Text;
                    dtDetail.Rows[row_reset]["color1"] = txtcolor1.Text;
                    dtDetail.Rows[row_reset]["color2"] = txtcolor2.Text;
                    dtDetail.Rows[row_reset]["color3"] = txtcolor3.Text;
                    dtDetail.Rows[row_reset]["size1"] = txtsize1.Text;
                    dtDetail.Rows[row_reset]["size2"] = txtsize2.Text;
                    dtDetail.Rows[row_reset]["size3"] = txtsize3.Text; 
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
            txtdate.EditValue = Convert.ToDateTime(pdr.Cells["date"].Value.ToString()).ToString("yyyy-MM-dd");
            txtseason.EditValue = pdr.Cells["season"].Value.ToString();
            txttrim_code.Text = pdr.Cells["trim_code"].Value.ToString();
            txtrequests_by.Text = pdr.Cells["requests_by"].Value.ToString();
            txtdelivery.Text = pdr.Cells["delivery"].Value.ToString();
            txtpvh_jv_ref.Text = pdr.Cells["pvh_jv_ref"].Value.ToString();
            txtsupplier_name.Text = pdr.Cells["supplier_name"].Value.ToString();
            txtmaterial.Text = pdr.Cells["material"].Value.ToString();
            txtsize.Text = pdr.Cells["size"].Value.ToString();
            txtcountry.Text = pdr.Cells["country"].Value.ToString();
            txtcolor.Text = pdr.Cells["color"].Value.ToString();
            txtartwork_limit.Text = pdr.Cells["artwork_limit"].Value.ToString();            
            //===============================================================
            txttiered_qty1.Text = pdr.Cells["tiered_qty1"].Value.ToString();
            txtprice_size1.Text = pdr.Cells["price_size1"].Value.ToString();
            lkem_id1.EditValue = pdr.Cells["m_id1"].Value.ToString();
            txtprice1.Text = pdr.Cells["price1"].Value.ToString();
            lkep_unit1.EditValue = pdr.Cells["p_unit1"].Value.ToString();            
            //
            txttiered_qty2.Text = pdr.Cells["tiered_qty2"].Value.ToString();
            txtprice_size2.Text = pdr.Cells["price_size2"].Value.ToString();
            lkem_id2.EditValue = pdr.Cells["m_id2"].Value.ToString();
            txtprice2.Text = pdr.Cells["price2"].Value.ToString();
            lkep_unit2.EditValue = pdr.Cells["p_unit2"].Value.ToString();            
            //
            txttiered_qty3.Text = pdr.Cells["tiered_qty3"].Value.ToString();
            txtprice_size3.Text = pdr.Cells["price_size3"].Value.ToString();
            lkem_id3.EditValue = pdr.Cells["m_id3"].Value.ToString();
            txtprice3.Text = pdr.Cells["price3"].Value.ToString();
            lkep_unit3.EditValue = pdr.Cells["p_unit3"].Value.ToString();  
            //
            txttiered_qty4.Text = pdr.Cells["tiered_qty4"].Value.ToString();
            txtprice_size4.Text = pdr.Cells["price_size4"].Value.ToString();
            lkem_id4.EditValue = pdr.Cells["m_id4"].Value.ToString();
            txtprice4.Text = pdr.Cells["price4"].Value.ToString();
            lkep_unit4.EditValue = pdr.Cells["p_unit4"].Value.ToString();  
            //
            txttiered_qty5.Text = pdr.Cells["tiered_qty5"].Value.ToString();
            txtprice_size5.Text = pdr.Cells["price_size5"].Value.ToString();
            lkem_id5.EditValue = pdr.Cells["m_id5"].Value.ToString();
            txtprice5.Text = pdr.Cells["price5"].Value.ToString();
            lkep_unit5.EditValue = pdr.Cells["p_unit5"].Value.ToString();  
            //
            txtmoq_usa.Text = pdr.Cells["moq_usa"].Value.ToString();
            txtsurcharge_usa.Text = pdr.Cells["surcharge_usa"].Value.ToString();
            txtmoq_eur.Text = pdr.Cells["moq_eur"].Value.ToString();
            txtsurcharge_eur.Text = pdr.Cells["surcharge_eur"].Value.ToString();
            txtleadtime_sample.Text = pdr.Cells["leadtime_sample"].Value.ToString();
            txtleadtime_bulk.Text = pdr.Cells["leadtime_bulk"].Value.ToString();            
            //=================================================================
            txttrim_must_tommy.Text = pdr.Cells["trim_must_tommy"].Value.ToString();
            txtoekotex.Text= pdr.Cells["oekotex"].Value.ToString();
            txtsuggested_care.Text = pdr.Cells["suggested_care"].Value.ToString();
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
            //=================================================================
            chkmachine_washable.Checked = pdr.Cells["machine_washable"].Value.ToString() == "True" ? true : false;
            chkdrycleanable.Checked = pdr.Cells["drycleanable"].Value.ToString() == "True" ? true : false;
            chkdryclean_only.Checked = pdr.Cells["dryclean_only"].Value.ToString() == "True" ? true : false;
            chkdo_not_dryclean.Checked = pdr.Cells["do_not_dryclean"].Value.ToString() == "True" ? true : false;
            chkuse_for_swimwear.Checked = pdr.Cells["use_for_swimwear"].Value.ToString() == "True" ? true : false;
            chkuse_for_childrenswear.Checked = pdr.Cells["use_for_childrenswear"].Value.ToString() == "True" ? true : false;
            chkcannot_pass_needle.Checked = pdr.Cells["cannot_pass_needle"].Value.ToString() == "True" ? true : false;
            memquality_callouts.Text = pdr.Cells["quality_callouts"].Value.ToString() ;            
            //=================================================================
            txtused_on_sms_eur.Text = pdr.Cells["used_on_sms_eur"].Value.ToString();
            txtlatest_submit_ref.Text = pdr.Cells["latest_submit_ref"].Value.ToString();
            txtbest_vendor_do.Text = pdr.Cells["best_vendor_do"].Value.ToString();
            txtbulk_reference.Text = pdr.Cells["bulk_reference"].Value.ToString();
            txtcolor_approved_size.Text = pdr.Cells["color_approved_size"].Value.ToString();
            txtquality_approval.Text = pdr.Cells["quality_approval"].Value.ToString();
            txtsize_approved_color.Text = pdr.Cells["size_approved_color"].Value.ToString();            
            //=================================================================
            chksubmit1.Checked = pdr.Cells["submit1"].Value.ToString() == "True" ? true : false;
            chksubmit2.Checked = pdr.Cells["submit2"].Value.ToString() == "True" ? true : false;
            chksubmit3.Checked = pdr.Cells["submit3"].Value.ToString() == "True" ? true : false;
            chkurgent.Checked = pdr.Cells["urgent"].Value.ToString() == "True" ? true : false;
            chkcs_mens.Checked = pdr.Cells["cs_mens"].Value.ToString() == "True" ? true : false;
            chkcs_womens.Checked = pdr.Cells["cs_womens"].Value.ToString() == "True" ? true : false;
            chkcs_boys.Checked = pdr.Cells["cs_boys"].Value.ToString() == "True" ? true : false;
            chkcs_girls.Checked = pdr.Cells["cs_girls"].Value.ToString() == "True" ? true : false;
            chkthm.Checked = pdr.Cells["thm"].Value.ToString() == "True" ? true : false;
            chkthd.Checked = pdr.Cells["thd"].Value.ToString() == "True" ? true : false;
            chkbranding.Checked = pdr.Cells["branding"].Value.ToString() == "True" ? true : false;
            chkth_spw_msw.Checked = pdr.Cells["th_spw_msw"].Value.ToString() == "True" ? true : false;
            chkth_spw_wsw.Checked = pdr.Cells["th_spw_wsw"].Value.ToString() == "True" ? true : false;
            chkth_col_msw.Checked = pdr.Cells["th_col_msw"].Value.ToString() == "True" ? true : false;
            chkth_col_wsw.Checked = pdr.Cells["th_col_wsw"].Value.ToString() == "True" ? true : false;
            chkth_kids.Checked = pdr.Cells["th_kids"].Value.ToString() == "True" ? true : false;
            chkth_swim.Checked = pdr.Cells["th_swim"].Value.ToString() == "True" ? true : false;
            chkth_underwear.Checked = pdr.Cells["th_underwear"].Value.ToString() == "True" ? true : false;
            chkth_acc_ftw.Checked = pdr.Cells["th_acc_ftw"].Value.ToString() == "True" ? true : false;
            chkth_tailored.Checked = pdr.Cells["th_tailored"].Value.ToString() == "True" ? true : false;
            chktommy_jeans.Checked = pdr.Cells["tommy_jeans"].Value.ToString() == "True" ? true : false;
            chkth_sport.Checked = pdr.Cells["th_sport"].Value.ToString() == "True" ? true : false;
            txtmo_id1.Text = pdr.Cells["mo_id1"].Value.ToString();
            txtmo_id2.Text = pdr.Cells["mo_id2"].Value.ToString();
            txtmo_id3.Text = pdr.Cells["mo_id3"].Value.ToString();
            txtcolor1.Text = pdr.Cells["color1"].Value.ToString();
            txtcolor2.Text = pdr.Cells["color2"].Value.ToString();
            txtcolor3.Text = pdr.Cells["color3"].Value.ToString();
            txtsize1.Text = pdr.Cells["size1"].Value.ToString();
            txtsize2.Text = pdr.Cells["size2"].Value.ToString();
            txtsize3.Text = pdr.Cells["size3"].Value.ToString();
        }

        private void txtId1_Leave(object sender, EventArgs e)
        {
            txtId2.Text = txtId1.Text;
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
            string strsql = string.Format(@"Select * FROM dbo.tommy_test_record WHERE serial_no='{0}'",txtserial_no.Text);
            DataTable dtReport = clsPublicOfCF01.GetDataTable(strsql);
            if (radGrp1.SelectedIndex == 0)
            {
                using (xrTommyTest1 rpt = new xrTommyTest1() { DataSource = dtReport })
                {
                    rpt.CreateDocument();
                    rpt.PrintingSystem.ShowMarginsWarning = false;
                    rpt.ShowPreviewDialog();
                }
            }
            else
            {
                using (txttitered_qty2 rpt = new txttitered_qty2() { DataSource = dtReport })
                {
                    rpt.CreateDocument();
                    rpt.PrintingSystem.ShowMarginsWarning = false;
                    rpt.ShowPreviewDialog();
                }
            }
        }

        private void txttrim_code_Leave(object sender, EventArgs e)
        {
            if (mState != "" && !string.IsNullOrEmpty(txttrim_code.Text))
            {
                string strsql = string.Format(
                @"SELECT TOP 1 ISNULL(A.season,'') AS season,A.m_id,B.customer_goods,B.mo_id,
                ROUND(CONVERT(float,B.unit_price),3) AS unit_price,B.goods_unit
                FROM dgerp2.cferp.dbo.so_order_manage A with(nolock),dgerp2.cferp.dbo.so_order_details B with(nolock)
                WHERE A.within_code=B.within_code AND A.id=B.id and A.ver=B.ver AND A.within_code='0000' and A.state NOT IN ('2','V') AND
                B.customer_goods LIKE '%{0}%' 
                ORDER BY A.order_date DESC", txttrim_code.Text );
                dtMO = clsPublicOfCF01.GetDataTable(strsql);
                if (dtMO.Rows.Count > 0)
                {
                    txtseason.EditValue = dtMO.Rows[0]["season"].ToString();
                    txtmo_id1.Text = dtMO.Rows[0]["mo_id"].ToString();
                    lkem_id1.EditValue = dtMO.Rows[0]["m_id"].ToString();
                    txtprice1.Text = dtMO.Rows[0]["unit_price"].ToString();
                    lkep_unit1.EditValue = dtMO.Rows[0]["goods_unit"].ToString();
                }
            }
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                AddNew();
                Set_head(dgvrow);
                txtdate.EditValue = DateTime.Now.Date.ToString("yyyy/MM/dd").Substring(0, 10);
                string max_serial_no = clsTommyTest.GetSeqNo("tommy_test_record", "serial_no");
                txtserial_no.Text = max_serial_no;
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtmo_id1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmo_id1.Text) && mState != "")
            {
                if (!Get_Cust_color(txtmo_id1.Text, "A"))
                {
                    MessageBox.Show(string.Format("當前頁數【{0}】不正確！", txtmo_id1.Text), "提示信息");
                    txtmo_id1.Focus();
                    txtmo_id1.SelectAll();
                }
            }
        }

        private void txtmo_id2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmo_id2.Text) && mState != "")
            {
                if (!Get_Cust_color(txtmo_id2.Text, "B"))
                {
                    MessageBox.Show(string.Format("當前頁數【{0}】不正確！", txtmo_id2.Text), "提示信息");
                    txtmo_id2.Focus();
                    txtmo_id2.SelectAll();
                }
            }
            
        }

        private void txtmo_id3_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmo_id3.Text) && mState != "")
            {
                if (!Get_Cust_color(txtmo_id3.Text, "C"))
                {
                    MessageBox.Show(string.Format("當前頁數【{0}】不正確！", txtmo_id3.Text), "提示信息");
                    txtmo_id3.Focus();
                    txtmo_id3.SelectAll();
                }
            }
        }

        private  bool Get_Cust_color(string strMo_id,string strObject)
        {
            bool blResult = true;
            string sql = string.Format(
                @"SELECT ISNULL(customer_color_id,'') AS customer_color_id,ISNULL(customer_size,'') AS customer_size 
                From dgerp2.cferp.dbo.so_order_details with(nolock) WHERE mo_id='{0}'", strMo_id);
            DataTable dt = clsPublicOfCF01.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["customer_color_id"].ToString()))
                {
                    switch (strObject)
                    {
                        case "A":
                            txtcolor1.Text = dt.Rows[0]["customer_color_id"].ToString();                            
                            break;
                        case "B":
                            txtcolor2.Text = dt.Rows[0]["customer_color_id"].ToString();                            
                            break;
                        case "C":
                            txtcolor3.Text = dt.Rows[0]["customer_color_id"].ToString();                            
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["customer_size"].ToString()))
                {
                    switch (strObject)
                    {
                        case "A":
                            txtsize1.Text = dt.Rows[0]["customer_size"].ToString();
                            break;
                        case "B":
                            txtsize2.Text = dt.Rows[0]["customer_size"].ToString();
                            break;
                        case "C":
                            txtsize3.Text = dt.Rows[0]["customer_size"].ToString();
                            break;
                    }
                }
                blResult = true;
            }
            else
            {               
                blResult = false ;                
            }
            return blResult;
        }

        private void dgvFind_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFind.Rows.Count == 0)
            {
                return;
            }
            tabControl1.SelectedIndex = 0;
        }
     
    }
}
