using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using cf01.ModuleClass;
using cf01.CLS;
using System.Data.SqlClient;
using System.Data.Common;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace cf01.Forms
{
    public partial class frmSpray_Data : Form
    {
        public string mID = "";    //臨時的主鍵值
        public string mState = ""; //新增或編號的狀態
        public static string str_language = "0";
        public string msgCustom;
        public int row_delete;
        private clsAppPublic clsApp = new clsAppPublic();
        private System.Data.DataTable dtDetail = new System.Data.DataTable();
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        private DataGridViewRow dgvrow = new DataGridViewRow();
        bool flag_import;

        public frmSpray_Data()
        {            
            InitializeComponent();
            try
            {
                //舊的菜單按鈕的權限及翻譯
                //clsControlInfoHelper control = new clsControlInfoHelper(this.Name, this.Controls);
                //control.GenerateContorl();
                ////控件翻譯
                //clsTranslate obj_ctl = new clsTranslate(this.Name, this.Controls, DBUtility._language);
                //obj_ctl.Translate();
                //設置菜單按鈕的權限
                clsApp.SetToolBarEnable(this.Name, this.Controls);
                clsApp.RetSetImage(toolStrip1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvDetails.RowHeadersVisible = true;  //因類clsControlInfoHelper DataGridView中已屏蔽行標頭,此處重新恢覆回來
            dgvDetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; //因類clsControlInfoHelper的問題，此處重新恢覆整行選中的屬性
        }

        private void frmSpray_Data_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dtDept = new System.Data.DataTable();
            dtDept = clsPublicOfCF01.GetDataTable(string.Format(@"SELECT '' AS id,'' as cdesc UNION SELECT id,id + ' ['+name+']' as cdesc FROM {0}cd_department with(nolock) Where within_code='0000' and state='0' order by id",DBUtility.remote_db));
            txtDept_id.Properties.DataSource = dtDept;
            txtDept_id.Properties.ValueMember = "id";
            txtDept_id.Properties.DisplayMember = "cdesc";

            txtDept1.Properties.DataSource = dtDept;
            txtDept1.Properties.ValueMember = "id";
            txtDept1.Properties.DisplayMember = "cdesc";

            txtDept2.Properties.DataSource = dtDept;
            txtDept2.Properties.ValueMember = "id";
            txtDept2.Properties.DisplayMember = "cdesc";
            txtDept1.EditValue = "J07";
            txtDept2.EditValue = "J07";

            dtDetail = clsPublicOfCF01.GetDataTable("SELECT * FROM bs_spray_data WHERE 1=0");
            dgvDetails.DataSource = dtDetail;

        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void BTNNEW_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BTNPRINT_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void BTNEXCEL_Click(object sender, EventArgs e)
        {
            Excel();
        }


        // ===============以下爲自定義方法=======================

        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;
            BTNPRINT.Enabled = _flag;
            BTNDELETE.Enabled = _flag;
            //BTNFIND.Enabled = _flag;
            BTNEXCEL.Enabled = _flag;
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            clsApp.SetToolBarEnable(this.Name, this.Controls);
        }

        private bool Save_Before_Valid() //保存前檢查
        {
            if (string.IsNullOrEmpty(txtDate.Text) || txtDept_id.Text == "" || txtGoods_id.Text == "" )
            {               
                MessageBox.Show("注意：藍色字體部分的資料為必填項，不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (mState == "NEW")
                {
                    string strsql = String.Format(
                    @"SELECT '1' FROM dbo.bs_spray_data with(nolock) WHERE dept_id='{0}' and goods_id='{1}'",
                    txtDept_id.EditValue, txtGoods_id.Text);
                    System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(string.Format("注意:\n\r部門編號[{0}]\n\r貨品編號[{1}] \n\r\n\r已存在,不可以再重復!",
                            txtDept_id.EditValue, txtGoods_id.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;
            }
        }


        private void Set_Row_Position(string _dept_id,string _mo_id,string _goods_id) //定位到當前行 
        {
            Find();
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (_dept_id == dgvDetails.Rows[i].Cells["dept_id"].Value.ToString() &&
                    _mo_id == dgvDetails.Rows[i].Cells["mo_id"].Value.ToString() && 
                    _goods_id == dgvDetails.Rows[i].Cells["goods_id"].Value.ToString())
                {
                    dgvDetails.Rows[i].Selected = true;
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells["dept_id"]; //設置光標定位到當前選中的行
                    break;
                }
            }
        }

        private void AddNew()  //新增
        {
            tabControl1.SelectTab(0);
            mState = "NEW";
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            txtDo_color.Properties.ReadOnly = true;
            txtDo_color.BackColor = Color.White;
            SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            dgvDetails.Enabled = false;
            txtDate.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            txtDept_id.Focus();
            txtDept_id.EditValue = "J07";
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)
            {
                return;
            }
            tabControl1.SelectTab(0);
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, true);
            dgvDetails.Enabled = false;
            mState = "EDIT";
            
            txtDept_id.Properties.ReadOnly = true;
            //txtMo_id.Properties.ReadOnly = true;
            txtGoods_id.Properties.ReadOnly = true;
            txtDept_id.BackColor = System.Drawing.Color.White;
            //txtMo_id.BackColor = System.Drawing.Color.White;
            txtGoods_id.BackColor = System.Drawing.Color.White;

            txtDo_color.Properties.ReadOnly = true;
            txtDo_color.BackColor = Color.White;
        }

        private void Cancel() //取消
        {
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);
            txtDept_id.Properties.ReadOnly = false;
            txtDept_id.Enabled = false;
            dgvDetails.Enabled = true;
            mState = "";
            leGoods_id.Visible = false;
            txtGoods_id.Visible = true;
            //SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
            if (!String.IsNullOrEmpty(mID))
            {
                Find_doc(mID);
            }      
            else
                SetObjValue.ClearObjValue(tabControl1.TabPages[0].Controls, "1");
        }

        private void Save()  //保存新增或修改的資料
        {
            txtDate.Focus();

            if (!Save_Before_Valid())
            {
                return;
            }
            bool save_flag = false;
            const string sql_new =
            @"INSERT INTO bs_spray_data(spray_date,dept_id,mo_id,goods_id,pub_count,spray_count,one_time,oven_time,remark,crusr,crtim)            
            VALUES(@spray_date,@dept_id,@mo_id,@goods_id,@pub_count,@spray_count,@one_time,@oven_time,@remark,@user_id,getdate())";
            const string sql_update =
            @"UPDATE bs_spray_data 
            SET spray_date=CASE LEN(@spray_date) WHEN 0 THEN null ELSE @spray_date END,dept_id=@dept_id,mo_id=@mo_id,goods_id=@goods_id,pub_count=@pub_count,
                spray_count=@spray_count,one_time=@one_time,oven_time=@oven_time,remark=@remark,amusr=@user_id,amtim=Getdate()                
            WHERE id=@id";

            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    myCommand.Parameters.Clear();
                    if (mState == "NEW")
                        myCommand.CommandText = sql_new;
                    else
                    {
                        //mState == "EDIT"编辑状态
                        myCommand.CommandText = sql_update;
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                    }
                    myCommand.Parameters.AddWithValue("@spray_date", clsApp.Return_String_Date(txtDate.Text));
                    myCommand.Parameters.AddWithValue("@dept_id", txtDept_id.EditValue);
                    myCommand.Parameters.AddWithValue("@mo_id", txtMo_id.Text);
                    myCommand.Parameters.AddWithValue("@goods_id", txtGoods_id.Text);
                    myCommand.Parameters.AddWithValue("@pub_count", txtPub_count.EditValue);
                    myCommand.Parameters.AddWithValue("@spray_count", txtSpray_count.EditValue);
                    myCommand.Parameters.AddWithValue("@one_time", txtOne_time.EditValue);
                    myCommand.Parameters.AddWithValue("@oven_time", txtOven_time.EditValue);
                    myCommand.Parameters.AddWithValue("@remark", txtRemark.Text);
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
                }
            }
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(tabControl1.TabPages[0].Controls, false);

            dgvDetails.Enabled = true;
            Set_Row_Position(txtDept_id.EditValue.ToString(),txtMo_id.Text,txtGoods_id.Text);
            mState = "";

            leGoods_id.Visible = false;
            txtGoods_id.Visible = true;

            if (save_flag)
            {
                MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtDept_id.Text))
            {
                return;
            }
            tabControl1.SelectTab(0);
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                const string sql_del = "DELETE FROM dbo.bs_spray_data WHERE id=@id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        myCommand.CommandText = sql_del;
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@id", txtID.EditValue);
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit(); //數據提交
                        dgvDetails.Rows.Remove(dgvDetails.CurrentRow);//移走當前行
                        MessageBox.Show(myMsg.msgSave_ok, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Find() //查詢出所有數據
        {
            dgvDetails.Focus();           
            string strRemote_db = DBUtility.remote_db;
            StringBuilder sb = new StringBuilder(string.Format(
                @"SELECT TOP 25 A.*,B.name as dept_name,S1.goods_name,S1.name_color,S1.do_color 
                FROM dbo.bs_spray_data A with(nolock) 
                    INNER JOIN {0}cd_department B with(nolock) ON B.within_code='0000' AND A.dept_id=B.id COLLATE Chinese_PRC_CI_AS
                    INNER JOIN (Select a.id,a.name as goods_name,b.name as name_color,b.do_color
                                From {0}it_goods a with(nolock) Inner Join {0}cd_color b with(nolock) on a.within_code=b.within_code and a.color=b.id
                                Where a.within_code='0000' AND a.state<>'2') S1 ON A.goods_id=S1.id COLLATE Chinese_PRC_CI_AS                     
                WHERE ", strRemote_db, strRemote_db));
            if (mState == "NEW")
            {               
                sb.Append(string.Format("A.crusr='{0}' Order by A.crtim DESC",DBUtility._user_id));
            }
            else
            {
                sb.Append(string.Format("A.amusr='{0}' Order by A.amtim DESC", DBUtility._user_id));               
            }            
            dtDetail = clsPublicOfCF01.GetDataTable(sb.ToString());
            dgvDetails.DataSource = dtDetail;
        }

        private void Print() //通用的打印方法
        {
            tabControl1.SelectTab(1);
            if (dgvDetails.RowCount > 0)
            {
                clsGeneralDataConvert.GridView_To_Print(dgvDetails);
            }
        }

        private void Excel() //匯出EXCEL
        {
            tabControl1.SelectTab(1);            
            if (dgvDetails.RowCount > 0)
            {
                ExpToExcel oxls = new ExpToExcel();
                oxls.ExportExcel(dgvDetails);
            }
        }

        //===========以下爲控件中的方法================     

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                Set_head(dgvrow);
            }
        }

        private void Set_head(DataGridViewRow pdr)
        {
            txtID.Text = pdr.Cells["id"].Value.ToString();            
            txtDept_id.EditValue = pdr.Cells["dept_id"].Value.ToString();
            string strDat = pdr.Cells["spray_date"].Value.ToString();
            if (!string.IsNullOrEmpty(strDat))
            {
                //strDat = strDat.Substring(0, 10);
                strDat = Convert.ToDateTime(strDat).ToString("yyyy-MM-dd");
            }
            else
            {
                strDat = "";
            }
            txtDate.EditValue = strDat;
            txtMo_id.Text = pdr.Cells["mo_id"].Value.ToString();
            txtGoods_id.Text = pdr.Cells["goods_id"].Value.ToString();
            txtGoods_name.Text = pdr.Cells["goods_name"].Value.ToString();
            txtPub_count.EditValue = pdr.Cells["pub_count"].Value.ToString();
            txtSpray_count.EditValue = pdr.Cells["spray_count"].Value.ToString();
            txtOne_time.EditValue = pdr.Cells["one_time"].Value.ToString();
            txtOven_time.EditValue = pdr.Cells["Oven_time"].Value.ToString();
            txtCrusr.Text = pdr.Cells["crusr"].Value.ToString();
            txtCrtim.Text = pdr.Cells["crtim"].Value.ToString();
            txtAmusr.Text = pdr.Cells["amusr"].Value.ToString();
            txtAmtim.Text = pdr.Cells["amtim"].Value.ToString();
            txtName_color.Text = pdr.Cells["namecolor"].Value.ToString();
            txtDo_color.Text = pdr.Cells["docolor"].Value.ToString();
            mID = pdr.Cells["id"].Value.ToString();
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
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            //DataGridView grd = sender as DataGridView;
            //if (grd.Rows[e.RowIndex].Cells["status_cancel"].Value.ToString() == "True")
            //{
            //    grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //    grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout); ;
            //}
        }

        private void txtPub_count_Click(object sender, EventArgs e)
        {
            //txtPub_count.Select(0, 0); //光标定位
            txtPub_count.SelectAll();
        }
        private void txtSpray_count_Click(object sender, EventArgs e)
        {            
            txtSpray_count.SelectAll();
        }

        private void txtOne_time_Click(object sender, EventArgs e)
        {
            txtOne_time.SelectAll();
        }

        private void txtOven_time_Click(object sender, EventArgs e)
        {
            txtOven_time.SelectAll();
        }

        private void txtDept_id_Click(object sender, EventArgs e)
        {
            txtDept_id.SelectAll();
        }

        private void BTNNEWCOPY_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            if (dgvDetails.RowCount > 0)
            {
                dgvrow = dgvDetails.CurrentRow;
                AddNew();
                Set_head(dgvrow);
                txtID.EditValue = "";
            }
            else
            {
                MessageBox.Show("註意:當前數據爲空格,或者請首先將當前光標定位到要覆制的行!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        string strFile_Excel = "";
        private void BTNIMPORT_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "Execl files (*.xls)|*.xls", FilterIndex = 0, RestoreDirectory = true, Title = "導入EXCEL文件路徑", FileName = null };
            openFileDialog1.ShowDialog();
            strFile_Excel = openFileDialog1.FileName;
            Refresh();
            if (string.IsNullOrEmpty(strFile_Excel))
            {
                return;
            }
            if (!File.Exists(strFile_Excel))
            {
                MessageBox.Show("指定的EXCEL文件不存在，請返回檢查!");
                return;
            }

            flag_import = false;
            Load_Excel();
            if (flag_import)
            {
                MessageBox.Show("導入EXCEL成功!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("導入EXCEL失敗!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_Excel()
        {
            //僅限小等于office2003,之前的版本,栏位名称后面不可以空格
            //導入EXCEL頁數,相當于批量新增
            const String strExcel = @"SELECT * FROM [Sheet1$]";
            try
            {
                Inport_excel(strExcel);
                flag_import = true;
            }
            catch (SqlException E)
            {
                flag_import = false;
                throw new Exception(E.Message);
            }
        }
        #region Inport_excel
        private void Inport_excel(string _strExcel)
        {

            String connStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0;", strFile_Excel);
            using (OleDbDataAdapter da = new OleDbDataAdapter(_strExcel, connStr))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                System.Data.DataTable dtExcel = ds.Tables[0];

                SqlConnection sqlconn = new SqlConnection(DBUtility.connectionString);
                sqlconn.Open();
                SqlTransaction myTrans = sqlconn.BeginTransaction();
                const string strSql_i =
               @"Insert into bs_spray_data(dept_id,spray_date,mo_id,goods_id,pub_count,spray_count,one_time,oven_time,remark)
                            VALUES (@dept_id,CASE LEN(@spray_date) WHEN 0 THEN null ELSE @spray_date END,@mo_id,@goods_id,@pub_count,@spray_count,@one_time,@oven_time,@remark)";
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Maximum = dtExcel.Rows.Count;

                SqlCommand myCommand = new SqlCommand() { Connection = sqlconn, Transaction = myTrans };
                myCommand.CommandText = strSql_i;
                try
                {                   
                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        progressBar1.Value += progressBar1.Step;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Enabled = false;
                            progressBar1.Visible = false;
                        }                        
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@dept_id", dtExcel.Rows[i]["dept_id"].ToString());
                        myCommand.Parameters.AddWithValue("@spray_date", clsApp.Return_String_Date(dtExcel.Rows[i]["spray_date"].ToString().Trim()));
                        myCommand.Parameters.AddWithValue("@mo_id", dtExcel.Rows[i]["mo_id"].ToString());
                        myCommand.Parameters.AddWithValue("@goods_id", dtExcel.Rows[i]["goods_id"].ToString());                    
                        myCommand.Parameters.AddWithValue("@pub_count", clsApp.Return_Float_Value(dtExcel.Rows[i]["pub_count"].ToString()));
                        myCommand.Parameters.AddWithValue("@spray_count", clsApp.Return_Float_Value(dtExcel.Rows[i]["spray_count"].ToString()));
                        myCommand.Parameters.AddWithValue("@one_time", clsApp.Return_Float_Value(dtExcel.Rows[i]["one_time"].ToString()));
                        myCommand.Parameters.AddWithValue("@oven_time", clsApp.Return_Float_Value(dtExcel.Rows[i]["oven_time"].ToString()));                        
                        myCommand.Parameters.AddWithValue("@remark", dtExcel.Rows[i]["remark"].ToString());
                        myCommand.ExecuteNonQuery();
                    }
                    myTrans.Commit(); //數據提交
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    throw new Exception(E.Message);
                }
                finally
                {
                    sqlconn.Close();
                    sqlconn.Dispose();
                }
                progressBar1.Enabled = false;
                progressBar1.Visible = false;
            }  
        }
        # endregion

        private void Find_doc(string temp_id) //非新增或編號狀態下帶出的資料
        {
            if (!String.IsNullOrEmpty(temp_id))
            {
                string strRemoeDB = DBUtility.remote_db;
                string strsql = String.Format(
                @"SELECT A.*,S2.dept_name,S1.goods_name,S1.name_color,S1.do_color
                FROM dbo.bs_spray_data A with(nolock) 
                INNER JOIN (Select a.id,a.name as goods_name,b.name as name_color,b.do_color
                            From {0}it_goods a with(nolock) Inner Join {0}cd_color b with(nolock) on a.within_code=b.within_code and a.color=b.id
                            Where a.within_code='0000' AND a.state<>'2') S1
	                ON A.goods_id=S1.id COLLATE Chinese_PRC_CI_AS 
                INNER JOIN (Select id,name as dept_name from {0}cd_department with(nolock) Where within_code='0000' AND state<>'2') S2
	                ON A.dept_id=S2.id COLLATE Chinese_PRC_CI_AS 
                WHERE A.id='{1}'", strRemoeDB, temp_id);                                
               
                System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql);
                dgvDetails.DataSource = dt;
                if (dt.Rows.Count == 0)
                {                    
                    MessageBox.Show("資料不存在!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetObjValue.ClearObjValue(this.Controls, "2");
                    return;
                }
                else
                {
                    mID = txtID.Text;//保存臨時的ID號
                }
                Set_head(dgvDetails.CurrentRow);
            }
        }

        private void txtDept1_Leave(object sender, EventArgs e)
        {
            txtDept2.EditValue= txtDept1.EditValue;
        }

        private void txtDat1_Leave(object sender, EventArgs e)
        {
            txtDat2.EditValue = txtDat1.EditValue;
        }

        private void txtMo1_Leave(object sender, EventArgs e)
        {
            txtMo2.Text = txtMo1.Text;
        }

        private void txtGoods_id1_Leave(object sender, EventArgs e)
        {
            txtGoods_id2.Text = txtGoods_id1.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BTNSAVE.Enabled)
            {
                Cancel();
            }
            if (txtDat1.Text == "" && txtDat2.Text == "" &&
                txtDept1.Text == "" && txtDept2.Text == "" &&
                txtMo1.Text == "" && txtMo2.Text == "" && 
                txtGoods_id1.Text == "" && txtGoods_id2.Text == "")
            {
                MessageBox.Show("注意：查詢條件不可以為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ;
            }
            string strRemote_db = DBUtility.remote_db;
            StringBuilder sb = new StringBuilder(string.Format(
                @"SELECT A.spray_date,A.dept_id,B.name as dept_name,A.mo_id,A.goods_id,C.name as goods_name,D.name as name_color,D.do_color,
                    A.pub_count,A.spray_count,A.one_time,
                    A.oven_time,A.remark,A.crusr,A.crtim,A.amusr,A.amtim,A.id
                FROM dbo.bs_spray_data A with(nolock) 
                    INNER JOIN {0}cd_department B with(nolock) ON B.within_code='0000' AND A.dept_id=B.id COLLATE Chinese_PRC_CI_AS
                    INNER JOIN {1}it_goods C with(nolock) ON C.within_code='0000' AND A.goods_id=C.id COLLATE Chinese_PRC_CI_AS 
                    INNER JOIN {1}cd_color D with(nolock) ON C.within_code=D.within_code and C.color=D.id
                WHERE A.id>0 ", strRemote_db, strRemote_db));
            if (txtDat1.Text != "")
            {
                sb.Append(string.Format(" and A.spray_date>='{0}'", txtDat1.Text));
            }
            if (txtDat2.Text != "")
            {
                sb.Append(string.Format(" and A.spray_date<='{0}'", txtDat2.Text));
            }
            if (!string.IsNullOrEmpty(txtDept1.Text))
            {
                sb.Append(string.Format(" and A.dept_id>='{0}'", txtDept1.EditValue));
            }
            if (!string.IsNullOrEmpty(txtDept2.Text))
            {
                sb.Append(string.Format(" and A.dept_id<='{0}'", txtDept2.EditValue));
            }
            if (txtMo1.Text != "")
            {
                sb.Append(string.Format(" and A.mo_id>='{0}'", txtMo1.Text));
            }
            if (txtMo2.Text != "")
            {
                sb.Append(string.Format(" and A.mo_id<='{0}'", txtMo2.Text));
            }
            if (txtGoods_id1.Text != "")
            {
                if (txtGoods_id1.Text.Length == 18)
                    sb.Append(string.Format(" and A.goods_id='{0}'", txtGoods_id1.Text));
                else
                    sb.Append(string.Format(" and A.goods_id Like '%{0}%'", txtGoods_id1.Text));
            }
            //if (txtGoods_id2.Text != "")
            //{
            //    sb.Append(string.Format(" and A.goods_id<='{0}'", txtGoods_id2.Text));
            //}            
            dtDetail = clsPublicOfCF01.GetDataTable(sb.ToString());
            dgvDetails.DataSource = dtDetail;
            dgvDetails2.DataSource = dtDetail;
            if (dtDetail.Rows.Count == 0)
            {
                MessageBox.Show(string.Format("沒有滿足查詢條件的數據!", txtGoods_id.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtGoods_id_Leave(object sender, EventArgs e)
        {
            if (txtGoods_id.Text != "")
            {
                string strsql = String.Format(
                    @"SELECT name FROM {0}it_goods with(nolock) WHERE within_code='0000' and id='{1}' and state<>'2'", DBUtility.remote_db, txtGoods_id.Text);
                using (System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql))
                {
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(string.Format("該貨品編號[{0}]不存在!", txtGoods_id.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtGoods_id.Focus();
                    }
                    else
                        txtGoods_name.Text = dt.Rows[0]["name"].ToString();
                }
            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if (txtMo_id.Text != "" && mState =="NEW")
            {
                string strsql = String.Format(
                @"SELECT B.goods_id,C.name as goods_name,B.wp_id
                FROM {0}jo_bill_mostly A with(nolock) 
	                INNER JOIN {0}jo_bill_goods_details B with(nolock) ON A.within_code=B.within_code AND A.id=B.id AND A.ver=B.ver 
	                INNER JOIN {0}it_goods C with(nolock) ON B.within_code=C.within_code AND B.goods_id=C.id
                WHERE A.within_code='0000' AND A.mo_id ='{1}' AND A.state NOT IN ('2','V') AND
	                (B.wp_id='510' or B.wp_id='107') AND B.next_wp_id<>'702'", DBUtility.remote_db, txtMo_id.Text);                
                using (System.Data.DataTable dt = clsPublicOfCF01.GetDataTable(strsql))
                {                    
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(string.Format("該頁數[{0}]不存在或者沒有對應流程!", txtMo_id.Text), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        leGoods_id.Properties.DataSource = dt;
                        leGoods_id.Properties.ValueMember = "goods_id";
                        leGoods_id.Properties.DisplayMember = "goods_id";

                        txtGoods_id.Visible = false;
                        leGoods_id.Visible = true;
                    }
                }
            }
        }

        private void leGoods_id_EditValueChanged(object sender, EventArgs e)
        {
            if (leGoods_id.EditValue.ToString() != "")
            {
                txtGoods_name.Text = leGoods_id.GetColumnValue("goods_name").ToString();
                txtGoods_id.Text = leGoods_id.EditValue.ToString();
            }
            leGoods_id.Visible = false;
            txtGoods_id.Visible = true;
        }
        
        private void Get_Formula()
        {
            if (mState != "")
            {
                if (txtSpray_count.Text != "" && txtOne_time.Text != "")
                {
                    txtOven_time.EditValue = Int32.Parse(txtSpray_count.Text) * Int32.Parse(txtOne_time.Text);
                }
            }
        }

        private void txtSpray_count_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                Get_Formula();
            }
        }

        private void txtOne_time_Leave(object sender, EventArgs e)
        {
            if (mState != "")
            {
                Get_Formula();
            }
        }

        private void dgvDetails2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails2.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails2.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails2.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDetails2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectTab(0);
        }


        //private void dgvDetails_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    //单元格列为“Column1”时           
        //    if ((dgv.Columns[e.ColumnIndex].Name == "sales_group" ||
        //        dgv.Columns[e.ColumnIndex].Name == "brand" ||
        //        dgv.Columns[e.ColumnIndex].Name == "temp_code" ||
        //        dgv.Columns[e.ColumnIndex].Name == "season" ||
        //        dgv.Columns[e.ColumnIndex].Name == "cust_code" ||
        //        dgv.Columns[e.ColumnIndex].Name == "cf_code") &&
        //        !string.IsNullOrEmpty(e.Value.ToString()))
        //    {
        //        //将单元格值设为大写
        //        e.Value = e.Value.ToString().ToUpper();
        //        //解析完毕
        //        e.ParsingApplied = true;
        //    }
        //} 

    }
}
